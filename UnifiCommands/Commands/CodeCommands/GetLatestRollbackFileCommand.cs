using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Gets the latest rollback log file based on rollback category and position.
    /// </summary>
    internal class GetLatestRollbackFileCommand : Command
    {
        private readonly string _notepadPath;
        private readonly ILogger _logger;
        string _rollbackPosition;
        string _rollbackCategory;

        public GetLatestRollbackFileCommand(string notepadPath, ILogger logger) : base(logger)
        {
            _notepadPath = notepadPath;
            _logger = logger;
        }

        public override void LogParameters()
        {
            _rollbackPosition = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("Rollback") as string;
            _rollbackCategory = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("RollbackCategory") as string;

            LogCommand($"Notepad++ path file: {_notepadPath}", $"Rollback category: {_rollbackCategory}", $"Rollback position: {_rollbackPosition}");
        }

        protected override Task<string> ExecuteCommand()
        {
            if (string.IsNullOrEmpty(_notepadPath) || !File.Exists(_notepadPath))
            {
                Logger.LogError($"File not found: {_notepadPath}");
                return Task.FromResult("");
            }

            string saveToFolder = BackupRollbackLogFileCommand.GetSaveLogDirectory(_rollbackCategory, _rollbackPosition);
            var file = new DirectoryInfo(saveToFolder).GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
            if (file == null)
            {
                _logger.LogInfo($"No files found in the {saveToFolder}.");
                return Task.FromResult("");
            }

            string logFile = Path.Combine(saveToFolder, file.Name);

            Process p =  new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = _notepadPath,
                    Arguments = logFile,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                }
            };

            p.Start();

            return Task.FromResult(logFile);
        }
    }
}
