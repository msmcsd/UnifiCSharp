using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using Timer = System.Timers.Timer;

namespace UnifiCommands.CommandExecutors
{
    /// <summary>
    /// Command executor that sends output to console.
    /// </summary>
    public class DosCommandExecutor : CommandExecutor
    {
        public DosCommandExecutor(ILogger logger) : base(logger) { }

        public override string Run(CommandInfo commandInfo, Timer callbackTimer)
        {
            if (commandInfo.DisplayText.StartsWith("-")) return null;

            if (!CommandSupportedOnPlatform(commandInfo))
            {
                return null;
            }

            // LogCommand(commandInfo);

            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = commandInfo.Command,
                    Arguments = commandInfo.Arguments,
                    UseShellExecute = false,
                    CreateNoWindow = !commandInfo.CreateNewWindow
                }
            };

            p.StartInfo.RedirectStandardOutput = commandInfo.RedirectOutputToConsole;
            p.StartInfo.RedirectStandardError = commandInfo.RedirectOutputToConsole;

            if (commandInfo.RunAs == CommandInfo.RunAsUserType.User)
            {
                p.StartInfo.Domain = Environment.UserDomainName;
                p.StartInfo.UserName = Environment.UserName;
            }

            p.StartInfo.WindowStyle = commandInfo.CreateNewWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
            if (commandInfo.RedirectOutputToConsole)
            {
                p.OutputDataReceived += OutputToConsole;
                p.ErrorDataReceived += OutputToConsole;
            }

            if (callbackTimer != null)
            {
                callbackTimer.Start();
                Logger.LogInfo($"Callback {commandInfo.Callback} started");
            }

            if (commandInfo.MinimizeWindow)
            {
                _minimizeWindowTimer = new Timer(500);
                _minimizeWindowTimer.Elapsed += (sender, e) => OnMinimizeWindow(commandInfo, e);
                _minimizeWindowTimer.AutoReset = true;
                _minimizeWindowTimer.Start();
            }

            try
            {
                p.Start();

                if (commandInfo.RedirectOutputToConsole)
                {
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                }
                p.WaitForExit();

                Logger.LogInfo($"'{commandInfo.DisplayText}' return code: {p.ExitCode}");

            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            finally
            {
                if (callbackTimer != null)
                {
                    callbackTimer.Stop();
                    callbackTimer.Dispose();
                    Logger.LogInfo($"Callback {commandInfo.Callback} stopped");
                }

                _minimizeWindowTimer?.Stop();
                _minimizeWindowTimer?.Dispose();
            }

            return "Success";
        }

        private void OutputToConsole(object sender, DataReceivedEventArgs e)
        {
            Logger.LogInfo(e.Data);
        }

        #region Minimizw a Dos Window

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_MINIMIZE = 6;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private Timer _minimizeWindowTimer;

        /// <summary>
        /// Minimizes a DOS window after a Dos command starts.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnMinimizeWindow(object source, ElapsedEventArgs e)
        {
            CommandInfo command = (CommandInfo)source;
            string caption = command.Command.Replace("\"", "");
            var handle = FindWindow("ConsoleWindowClass", caption);
            if (handle != IntPtr.Zero)
            {
                ShowWindow(handle, SW_MINIMIZE);
                _minimizeWindowTimer.Stop();
            }
            else
            {
                Logger.LogError($"Window {caption} not found.");
            }
        }
        #endregion
    }
}
