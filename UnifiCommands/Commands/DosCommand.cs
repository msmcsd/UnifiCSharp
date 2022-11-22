﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using UnifiCommands.CommandExecutors;
using UnifiCommands.CommandInfo;
using UnifiCommands.Logging;
using Timer = System.Timers.Timer;

namespace UnifiCommands.Commands
{
    /// <summary>
    /// Runs a DOS command.
    /// </summary>
    public class DosCommand : Command
    {
        private readonly FullCommandInfo _command;
        private readonly CommandExecutor _executor;

        public DosCommand(FullCommandInfo command, ILogger logger) : base(logger)
        {
            _command = command;
            _executor = new DosCommandExecutor(logger);
        }

        protected override Task<string> ExecuteCommand()
        {
            Timer callbackTimer = null;
            bool hasCallback = !string.IsNullOrEmpty(_command.Callback);
            ElapsedEventHandler del = null;
            if (hasCallback)
            {
                callbackTimer = new Timer(2000);
                MethodInfo method = _command.VariableValueSource.GetType().GetMethod(_command.Callback, BindingFlags.Instance | BindingFlags.NonPublic);
                del = (ElapsedEventHandler)Delegate.CreateDelegate(typeof(ElapsedEventHandler), _command.VariableValueSource, method);
                callbackTimer.Elapsed += del;
                callbackTimer.AutoReset = true;
            }

            string ret = _executor.Run(_command, callbackTimer);

            if (hasCallback)
            {
                callbackTimer.Elapsed -= del;
            }

            return Task.FromResult(ret);
        }

        public override void LogParameters()
        {
            LogCommand($"{_command.Command} {_command.Arguments}");
        }
    }
}