using System;
using System.IO;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class FileDeleteCommand : Command
    {
        private readonly string _filePath;

        public FileDeleteCommand(string filePath, ILogger logger) : base(logger)
        {
            _filePath = filePath;
        }

        public override void LogParameters()
        {
            LogCommand($"File: \"{_filePath}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            if (!File.Exists(_filePath))
            {
                LogInfo($"File not found \"{_filePath}\"");
                return Task.FromResult(_filePath);
            }

            try
            {
                File.Delete(_filePath);
                LogInfo($"Deleted \"{_filePath}\"");

                return Task.FromResult(_filePath);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }

            return null;
        }
    }
}