using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class MonitorLogCommand : Command
    {
        private readonly string _filePath;
        private readonly bool _onlineUpdate;
        private readonly int _timeoutMinutes;

        private const string HasUpdateString = "Creating Restore point";
        private const string OfflineUpdateFoundString = "CyServiceFactory: CloseAllServices completed";

        private int _cyUpdatePid;
        private string OnlineUpdateFoundString => $"CyUpdate exit, PID = {_cyUpdatePid}";

        private string EndOfUpdateString => _onlineUpdate ? OnlineUpdateFoundString : OfflineUpdateFoundString;

        /// <summary>
        /// Monitors a text file to see if certain string appears.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="onlineUpdate"></param>
        /// <param name="timeoutMinutes">Number of minutes the command times out.</param>
        public MonitorLogCommand(string filePath, bool onlineUpdate, int timeoutMinutes, ILogger logger) : base(logger)
        {
            _filePath = filePath;
            _onlineUpdate = onlineUpdate;
            _timeoutMinutes = timeoutMinutes;

            if (_timeoutMinutes <= 0) _timeoutMinutes = 5;
        }

        public override void LogParameters()
        {
            LogCommand($"File: \"{_filePath}\"",
                                   $"Has update string: \"{HasUpdateString}\"",
                                   $"End of update string: \"{EndOfUpdateString}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            DateTime endTime = DateTime.Now.AddSeconds(10);
            while (DateTime.Now < endTime)
            {
                if (File.Exists(_filePath)) break;
                Thread.Sleep(1000);
            }

            if (!File.Exists(_filePath))
            {
                LogError($"File not found {_filePath}");
                return null;
            }

            LogInfo($"Monitoring {_filePath} for {_timeoutMinutes} minutes.");

            const int readSize = 1 * 1024 * 1024;
            bool hasUpdate = false;
            var initialFileSize = new FileInfo(_filePath).Length;
            var lastReadLength = initialFileSize - readSize;
            if (lastReadLength < 0) lastReadLength = 0;

            // Combined text for current read and previous read. In case the string we are looking for is cut.
            string previousRead = "";

            DateTime timeout = DateTime.Now.AddMinutes(_timeoutMinutes);

            while (DateTime.Now < timeout)
            {
                try
                {
                    var fileSize = new FileInfo(_filePath).Length;
                    if (fileSize > lastReadLength)
                    {
                        using (var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            fs.Seek(lastReadLength, SeekOrigin.Begin);
                            var buffer = new byte[readSize];

                            while (DateTime.Now < timeout)
                            {
                                var bytesRead = fs.Read(buffer, 0, buffer.Length);
                                lastReadLength += bytesRead;

                                if (bytesRead == 0)
                                    break;

                                var newText = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                                var text = previousRead + newText;

                                //Console.LogInfo(text);

                                if (!hasUpdate)
                                {
                                    hasUpdate = text.Contains(HasUpdateString);
                                    if (hasUpdate)
                                    {
                                        const string findString = "CyUpdate(";
                                        int findStringSize = findString.Length;
                                        int start = text.IndexOf(HasUpdateString, StringComparison.Ordinal);
                                        while (text.Substring(start, findStringSize) != findString)
                                        {
                                            // Try to find the "CyUpdate(" closest to the findString in case there are multiple "CyUpdate(" with different PIDs.
                                            // e.g. the case when updater is updated first and another CyUpdate will run with different PID.
                                            start--;
                                        }

                                        int end = text.IndexOf(")", start + findString.Length, StringComparison.Ordinal);
                                        // LogInfo($"start={text.Substring(start+cyupdate.Length, 1)} end={text.Substring(end, 1)}");
                                        _cyUpdatePid = int.Parse(text.Substring(start + findString.Length,
                                            end - start - findString.Length));
                                        LogInfo($"Update found. Updater PID={_cyUpdatePid}. Monitor string=\"{EndOfUpdateString}\".");
                                    }
                                }

                                if (text.Contains(EndOfUpdateString))
                                {
                                    if (hasUpdate)
                                    {
                                        LogInfo("Update finished");
                                        return Task.FromResult(EndOfUpdateString);
                                    }

                                    LogInfo("No update found");
                                    return Task.FromResult("");
                                }

                                previousRead = text;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogError(e.ToString());
                }

                Thread.Sleep(1000);
            }

            LogInfo($"String not found {EndOfUpdateString}");
            return Task.FromResult("");
        }
    }
}
