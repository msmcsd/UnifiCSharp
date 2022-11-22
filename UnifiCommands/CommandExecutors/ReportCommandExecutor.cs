using System;
using System.Diagnostics;
using System.Timers;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;

namespace UnifiCommands.CommandExecutors
{
    /// <summary>
    /// Executor used for running commands used for report. The result does not output to console but is used to determine if the result of of a command succeeds.
    /// </summary>
    public class ReportCommandExecutor : CommandExecutor
    {
        public ReportCommandExecutor(ILogger logger) : base(logger) { }

        public override string Run(FullCommandInfo commandInfo, Timer callbackTimer)
        {
            if (!CommandSupportedOnPlatform(commandInfo))
            {
                return "";
            }

            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = commandInfo.Command,
                    Arguments = commandInfo.Arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            string ret = "";

            try
            {
                p.Start();

                ret = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }

            return ret;
        }
    }
}