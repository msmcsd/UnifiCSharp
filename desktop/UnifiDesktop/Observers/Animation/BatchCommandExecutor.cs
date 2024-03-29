﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;
using UnifiCommands.Socket.MessageClasses;
using WebSocketSharp;

namespace Unifi.Observers.Animation
{
    /// <summary>
    /// Runs a list of commands. Reports start and end of command back to the observer.
    /// </summary>
    internal class BatchCommandExecutor : IObservable
    {
        private readonly List<FullCommandInfo> _commandInfos;
        private readonly bool _checkReturnValue;
        private readonly object _uiObserver;
        private readonly ILogger _logger;
        private readonly AppType _appType;
        private IObserver _observer;
        private WebSocket _clientSocket;
        private InstallParameters _installParameters;
        private EventWaitHandle _waitForSocket = new EventWaitHandle(false, EventResetMode.ManualReset);
        private bool _hasRuntimeVariables;

        public BatchCommandExecutor(List<FullCommandInfo> commandInfos, bool checkReturnValue, object uiObserver, ILogger logger, AppType appType)
        {
            _commandInfos = commandInfos;
            _checkReturnValue = checkReturnValue;
            _uiObserver = uiObserver;
            _logger = logger;
            _appType = appType;

            _hasRuntimeVariables = HasRuntimeVariables();
            
            if (_hasRuntimeVariables) Task.Run(SetupSocket);
        }

        private void SetupSocket()
        {
            _clientSocket = SocketUtils.CreateSocketClient(BroadcastInstallParametersBehavior.ChannelName,
                                                            GetType().Name,
                                                            OnReceiveIntallParameters,
                                                            (sender, e) => _logger.LogError($"[BatchCommandExecutor] {e.Message}"));
        }

        private void OnReceiveIntallParameters(object sender, MessageEventArgs e)
        {
            _clientSocket.CloseAsync();

            _logger.LogSocketMessage(GetType(), $"Received data {e.Data}");

            SocketMessage m = SocketUtils.DeserializeMessage(e.Data);
            if (m == null)
            {
                _logger.LogSocketError(GetType(), "Not a valid ScoketMessage");
            }
            else if (m.Type != SocketMessageType.BroadcastInstallParameters)
            {
                _logger.LogSocketError(GetType(), $"Type of socket message is not {SocketMessageType.BroadcastInstallParameters}");
                return;
            }
            else
            {
                _logger.LogSocketMessage(GetType(), $"Received {m.Type} message");
                _installParameters = JsonConvert.DeserializeObject<InstallParameters>(m.Data);
                foreach (var command in _commandInfos)
                    command.VariableValueSource = _installParameters;
            }

            _waitForSocket.Set();
        }

        private bool HasRuntimeVariables()
        {
            foreach(var command in _commandInfos)
            {
                if (command.Command.Contains("$[") || command.Arguments != null && command.Arguments.Contains("$[")) return true;
            }    

            return false;   
        }

        public async void Execute()
        {
            _logger.LogInfo(">> Batch commands started");

            if (_hasRuntimeVariables)
            {
                _installParameters = null;

                _logger.LogSocketMessage(GetType(), "Requests install parameters");
                SocketUtils.SendCommandToChannel(RequestInstallParametersBehavior.ChannelName,
                                                 JsonConvert.SerializeObject(new SocketMessage { Type = SocketMessageType.RequestInstallParameters }),
                                                 (sender, e) => _logger.LogSocketError(GetType(), e.Message));

                _waitForSocket.WaitOne(5000);
                if (_installParameters == null)
                {
                    _logger.LogSocketError(GetType(), "InstallParameters is null");
                    _logger.LogInfo("<< Batch commands finished");
                    return;
                }
            }

            List<CommandTask> tasks = new List<CommandTask>();
            bool ret = true;

            Task currentTask = Task.FromResult("");

            foreach (var info in _commandInfos)
            {
                Command command = CommandFactory.CreateCommand(info, _logger, _appType);

                if (command == null)
                {
                    _logger.LogError("Created cmmand is null");
                    ret = false;
                    break;
                }

                if (command is IUiObservable observable)
                {
                    observable.RegisterObserver(_uiObserver as IUiObserver);
                }

                var task = new CommandTask
                {
                    CommandInfo = info,
                    Task = () => command.Execute()
                };

                NotifyObserverCommandStart(info);
                if (info.FireAndForget)
                {
                    _ = Task.Run(() => command.Execute());
                }
                else
                {
                    Task result = null;
                    if (info.Type == CommandType.Dos)
                    {
                        Task<Task> continuation = currentTask.ContinueWith(t => task.Task(),
                            TaskContinuationOptions.OnlyOnRanToCompletion);

                        currentTask = continuation.Unwrap();

                        await continuation.ContinueWith(t => { result = continuation.Result; });
                    }
                    else
                    {
                        string ret1 = await command.Execute();
                        result = ret1 == null ? null : Task.FromResult(result);
                    }

                    if (_checkReturnValue)
                    {
                        if (result == null)
                        {
                            ret = false;
                            NotifyObserverCommandEnd(task.CommandInfo);
                            break;
                        }
                    }
                }
                NotifyObserverCommandEnd(task.CommandInfo);
            }

            _logger.LogInfo("<<Batch commands finished" + (ret ? "" : " early"));
        }

        public async void Execute1()
        {
            List<CommandTask> tasks = new List<CommandTask>();

            foreach (var info in _commandInfos)
            {
                Command command = CommandFactory.CreateCommand(info, _logger, _appType);

                if (command == null) return;

                if (command is IUiObservable observable)
                {
                    observable.RegisterObserver(_uiObserver as IUiObserver);
                }

                tasks.Add(new CommandTask
                {
                    CommandInfo = info,
                    Task = () => command.Execute()
                });
            }

            bool ret = true;

            Task currentTask = Task.FromResult("");
            foreach (var task in tasks)
            {
                NotifyObserverCommandStart(task.CommandInfo);
                if (task.CommandInfo.FireAndForget)
                {
                    _ = Task.Run(() => task.Task());
                }
                else
                {
                    Task<Task> continuation = currentTask.ContinueWith(t => task.Task(),
                        TaskContinuationOptions.OnlyOnRanToCompletion);

                    currentTask = continuation.Unwrap();

                    Task result = null;
                    await continuation.ContinueWith(t => { result = continuation.Result; });

                    if (_checkReturnValue)
                    {
                        if (result == null)
                        {
                            ret = false;
                            NotifyObserverCommandEnd(task.CommandInfo);
                            break;
                        }

                        // _console.LogInfo($"ret={result.Status}");
                    }
                }
                NotifyObserverCommandEnd(task.CommandInfo);
            }

            if (_checkReturnValue)
            {
                _logger.LogInfo("<<Batch command finished" + (ret ? "" : " early"));
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observer = observer;
            Debug.WriteLine(GetType(), _observer != null ? $"Observer of type {_observer.GetType()} registered" : $"{nameof(_observer)} is null");
        }

        public void NotifyObserverCommandStart(FullCommandInfo info)
        {
            Debug.WriteLine(GetType(), $"Command starts {info.Command}");
            _observer?.StatusUpdateAtCommandStart(info);
        }
        public void NotifyObserverCommandEnd(FullCommandInfo info)
        {
            _observer?.StatusUpdateAtCommandEnd(info);
            Debug.WriteLine(GetType(), $"Command ends {info.Command}");
        }
    }

    internal class CommandTask
    {
        public FullCommandInfo CommandInfo { get; set; }
        public Func<Task> Task { get; set; }
    }
}
