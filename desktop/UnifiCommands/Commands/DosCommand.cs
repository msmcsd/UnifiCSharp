using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using UnifiCommands.CommandExecutors;
using UnifiCommands.Logging;
using Timer = System.Timers.Timer;

namespace UnifiCommands.Commands
{
    /// <summary>
    /// Runs a DOS command.
    /// </summary>
    public class DosCommand : Command
    {
        private readonly CommandInfo _command;
        private readonly CommandExecutor _executor;

        public DosCommand(CommandInfo command, ILogger logger) : base(logger)
        {
            _command = command;
            _executor = new DosCommandExecutor(logger);
        }

        protected override Task<string> ExecuteCommand()
        {
            Timer callbackTimer = null;
            bool hasCallback = !string.IsNullOrEmpty(_command.Callback);
            ElapsedEventHandler del = null;
            // if (hasCallback)
            // {
            //     callbackTimer = new Timer(2000);
            //     MethodInfo method = MainForm.Instance.GetType().GetMethod(_command.Callback, BindingFlags.Instance | BindingFlags.NonPublic);
            //     del = (ElapsedEventHandler)Delegate.CreateDelegate(typeof(ElapsedEventHandler), MainForm.Instance, method);
            //     callbackTimer.Elapsed += del;
            //     callbackTimer.AutoReset = true;
            // }

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