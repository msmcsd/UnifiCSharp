using System;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands
{
    /// <summary>
    /// Base class for all commands. A Command is a runnable command of CommandInfo.
    /// </summary>
    public abstract class Command
    {
        protected readonly ILogger Logger;

        public abstract void LogParameters();

        protected abstract Task<string> ExecuteCommand();

        protected Command(ILogger logger)
        {
            Logger = logger?? throw new ArgumentNullException($"{nameof(logger)} is null");
        }

        public async Task<string> Execute()
        {
            LogParameters();
            var ret = await ExecuteCommand();
            LogCommandEnd();

            return ret;
        }

        protected void LogCommandEnd()
        {
            //Logger.LogCommand($"{GetCommandName()}Finished {new string('-', 90)}", true);
            Logger.LogCommand($"{GetCommandName()}Finished", true);
            Logger.LogCommand("", false);
        }

        protected void LogCommand(params string[] commands)
        {
            if (commands.Length < 1) return;

            Logger.LogCommand($"{GetCommandName()}{commands[0]}", false);
            for (int i = 1; i < commands.Length; i++)
                Logger.LogCommand($"{GetCommandName()}{commands[i]}", false);
        }

        protected void LogInfo(string info)
        {
            Logger.LogInfo($"{GetCommandName()}{info}");
        }

        protected void LogError(string info)
        {
            Logger.LogError($"{GetCommandName()}{info}");
        }

        private string GetCommandName()
        {
            string className = GetType().Name;
            className = className.EndsWith("Command") ? className.Replace("Command", "") : className;
            return $"[{className}] ";
        }
    }
}