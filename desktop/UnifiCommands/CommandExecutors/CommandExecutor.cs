using System;
using System.Runtime.InteropServices;
using System.Timers;
using UnifiCommands.Commands;
using UnifiCommands.Logging;

namespace UnifiCommands.CommandExecutors
{
    public abstract class CommandExecutor
    {
        protected readonly ILogger Logger;

        public abstract string Run(CommandInfo commandInfo, Timer callbackTimer);

        protected CommandExecutor(ILogger logger)
        {
            Logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} is null");
        }

        protected bool CommandSupportedOnPlatform(CommandInfo commandInfo)
        {
            bool supported = !IsWindowsServer() && Environment.OSVersion.Version.CompareTo(new Version("6.2")) >= 0 ||
                             IsWindowsServer() && Environment.OSVersion.Version.CompareTo(new Version("6.3")) >= 0;

            if (commandInfo.Win8OrLater && !supported)
            {
                Logger.LogInfo($"Command '{commandInfo.DisplayText}' is not valid for Windows 7/Windows Server 2012");
                return false;
            }

            return true;
        }

        protected void LogCommand(CommandInfo commandInfo)
        {
            Logger.LogCommand($">>{commandInfo.Command} {commandInfo.Arguments}", false);
        }

        private const int OS_ANYSERVER = 29;
        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        private static extern bool IsOS(int os);

        public static bool IsWindowsServer()
        {
            return IsOS(OS_ANYSERVER);
        }
    }
}