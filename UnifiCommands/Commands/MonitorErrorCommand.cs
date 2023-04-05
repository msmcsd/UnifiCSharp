using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UnifiCommands.Logging;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;
using WebSocketSharp;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Monitors a file for certain keywords.
    /// </summary>
    public class MonitorErrorCommand : Command
    {
        private readonly string _filePath;
        private List<string> KeywordList = new List<string> { "Error", "Exception" };
        private string _keywords;
        private bool _stopMonitoring = false;
        private long _occurances = 0;

        public MonitorErrorCommand(string filePath, ILogger logger) : base(logger)
        {
            _filePath = filePath;
        }

        public override void LogParameters()
        {
            LogCommand($"File: \"{_filePath}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            Task.Run(StartMonitoring);
            return Task.FromResult("");
        }

        private void StartMonitoring()
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
                return;
            }

            LogInfo($"Monitoring '{_filePath}' for errors/exceptions.");

            _keywords = string.Join(", ", KeywordList);
            SocketUtils.CreateSocketClient(MonitorErrorBehavior.ChannelName, GetType().Name, OnReceiveCommand, (sender, e) => LogError(e.Message));

            const int TEXT_PROCESS_SIZE = 1 * 1024 * 1024;
            var initialFileSize = new FileInfo(_filePath).Length;
            var currentFilePosition = initialFileSize - TEXT_PROCESS_SIZE;
            if (currentFilePosition < 0) currentFilePosition = 0;

            string previousBlockRead = "";

            while (File.Exists(_filePath))
            {
                try
                {
                    var fileSize = new FileInfo(_filePath).Length;
                    if (fileSize > currentFilePosition)
                    {
                        using (var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var totalBytesToRead = fileSize - currentFilePosition;
                            fs.Seek(currentFilePosition, SeekOrigin.Begin);

                            // Total bytes read each time might exceed the size, TEXT_PROCESS_SIZE, processed each time.
                            // Do it until all bytes are processed in totalBytesRead.
                            while (totalBytesToRead > 0)
                            {
                                if (_stopMonitoring)
                                {
                                    LogInfo($"[{GetType().Name}] Stopped monitoring {_keywords} in '{_filePath}'");
                                    return;
                                }

                                var readsize = totalBytesToRead > TEXT_PROCESS_SIZE ? TEXT_PROCESS_SIZE : totalBytesToRead;
                                var buffer = new byte[readsize];
                                var bytesRead = fs.Read(buffer, 0, buffer.Length);
                                currentFilePosition += bytesRead;

                                if (bytesRead == 0)
                                    break;

                                var textBlockRead = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                                var textBlockToProcess = textBlockRead;

                                // Each TEXT_PROCESS_SIZE read might not end in end of a line in the file, the logic is to
                                // collect the last partial line from previous block and add it the current block.
                                // For current block read, remove the last part that is not a whole line. This will be prcessed in the next read.

                                // Get the part after the last \r\n in previous read.
                                var indexOfLastCrlf = previousBlockRead.LastIndexOf("\r\n");
                                if (indexOfLastCrlf > 0)
                                {
                                    textBlockToProcess = previousBlockRead.Substring(indexOfLastCrlf) + textBlockToProcess;
                                }

                                // Discard the part after the last \r\n which is not a full line.
                                indexOfLastCrlf = textBlockToProcess.LastIndexOf("\r\n");
                                if (indexOfLastCrlf > 0)
                                {
                                    textBlockToProcess = textBlockToProcess.Substring(0, indexOfLastCrlf);
                                }

                                var lines = textBlockToProcess.Split(new[] { "\r\n" }, StringSplitOptions.None);
                                foreach (var line in lines)
                                {
                                    var matched = KeywordList.Where(keyword => Regex.IsMatch(line, keyword, RegexOptions.IgnoreCase));
                                    if (matched.Count() > 0)
                                    {
                                        _occurances++;
                                        Logger.LogInfo($"[{GetType().Name}] {_occurances} occurances for {_keywords}");
                                    }
                                }

                                previousBlockRead = textBlockRead;
                                totalBytesToRead -= TEXT_PROCESS_SIZE;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogError(e.ToString());
                }

                Thread.Sleep(10000);
            }
        }

        private void OnReceiveCommand(object sender, MessageEventArgs e)
        {
            SocketCommandServer.Instance.LogMessage($"Component '{GetType().Name}' recieved data '{e.Data}'.");
            _stopMonitoring = e.Data == "0";
        }
    }
}
