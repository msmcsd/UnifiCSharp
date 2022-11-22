using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class FileVersionCommand : Command
    {
        private readonly string _filePath;

        public FileVersionCommand(string filePath, ILogger logger) : base(logger)
        {
            _filePath = filePath;
        }

        public override void LogParameters()
        {
            LogCommand($"File: {_filePath}");
        }

        protected override Task<string> ExecuteCommand()
        {
            if (File.Exists(_filePath))
            {
                string version = FileVersionInfo.GetVersionInfo(_filePath).FileVersion;
                LogInfo($"File version: {version}");
                return Task.FromResult(version);
            }

            LogError($"File not found: {_filePath}");
            return Task.FromResult("");
        }
    }
}