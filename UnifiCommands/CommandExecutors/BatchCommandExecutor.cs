using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;

namespace UnifiCommands.CommandExecutors
{
    /// <summary>
    /// Runs a list of commands. Reports start and end of command back to the observer.
    /// </summary>
    public class BatchCommandExecutor
    {
        private readonly List<FullCommandInfo> _commandInfos;
        private readonly bool _checkReturnValue;
        private readonly object _uiObserver;
        private readonly ILogger _logger;
        private readonly AppType _appType;
        //private IObserver _observer;

        public BatchCommandExecutor(List<FullCommandInfo> commandInfos, bool checkReturnValue, object uiObserver, ILogger logger, AppType appType)
        {
            _commandInfos = commandInfos;
            _checkReturnValue = checkReturnValue;
            _uiObserver = uiObserver;
            _logger = logger;
            _appType = appType;
        }

        public async Task Execute()
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
                //NotifyObserverCommandStart(task.CommandInfo);
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
                    await continuation.ContinueWith(t => { result = continuation.Result; }
                    );

                    if (_checkReturnValue)
                    {
                        if (result == null)
                        {
                            ret = false;
                            //NotifyObserverCommandEnd(task.CommandInfo);
                            break;
                        }

                        // _console.LogInfo($"ret={result.Status}");
                    }
                }
                //NotifyObserverCommandEnd(task.CommandInfo);
            }

            if (_checkReturnValue)
            {
                _logger.LogInfo("<<Batch command finished" + (ret ? "" : " early"));
            }
        }

        //public void RegisterObserver(IObserver observer)
        //{
        //    _observer = observer;
        //    Debug.WriteLine(GetType(), _observer != null ? $"Observer of type {_observer.GetType()} registered" : $"{nameof(_observer)} is null");
        //}

        //public void NotifyObserverCommandStart(FullCommandInfo info)
        //{
        //    Debug.WriteLine(GetType(), $"Command starts {info.Command}");
        //    _observer?.StatusUpdateAtCommandStart(info);
        //}
        //public void NotifyObserverCommandEnd(FullCommandInfo info)
        //{
        //    _observer?.StatusUpdateAtCommandEnd(info);
        //    Debug.WriteLine(GetType(), $"Command ends {info.Command}");
        //}
    }

    internal class CommandTask
    {
        public FullCommandInfo CommandInfo { get; set; }
        public Func<Task> Task { get; set; }
    }
}
