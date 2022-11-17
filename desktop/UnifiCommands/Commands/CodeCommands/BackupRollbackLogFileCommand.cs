using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Win32;
using UnifiCommands.Logging;

[assembly: InternalsVisibleTo("Unifi.UnitTests")]

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Back up rollback log file based on rollback category set in RollbackCategory.txt and rollback position set in Rollback.txt
    /// </summary>
    internal class BackupRollbackLogFileCommand : Command
    {
        private readonly string _logFilePath;
        private string _rollbackCategory;
        private string _rollbackPosition;

        public BackupRollbackLogFileCommand(string logFilePath, ILogger logger) : base(logger)
        {
            _logFilePath = logFilePath;
        }

        public override void LogParameters()
        {
            _rollbackPosition = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("Rollback") as string;
            _rollbackCategory = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("RollbackCategory") as string;

            LogCommand($"Log file: {_logFilePath}", $"Rollback category: {_rollbackCategory}", $"Rollback position: {_rollbackPosition}");
        }

        protected override Task<string> ExecuteCommand()
        {
            if (string.IsNullOrEmpty(_logFilePath) || !File.Exists(_logFilePath))
            {
                Logger.LogError($"File not found: {_logFilePath}");
                return Task.FromResult("");
            }

            string saveToFolder = GetSaveLogDirectory();
            string saveToPath = Path.Combine(saveToFolder, Path.GetFileName(_logFilePath));

            File.Copy(_logFilePath, saveToPath, true);

            Logger.LogInfo($"Copied log file to \"{saveToPath}\"");

            return Task.FromResult(saveToPath);
        }

        private string GetSaveLogDirectory()
        {
            string archFolder = Environment.OSVersion.Version.CompareTo(new Version("6.2")) < 0
                ? "Win7"
                : Environment.Is64BitOperatingSystem ? "x64" : "x86";

            var infos = Rollback.RollbackPositionsList.FirstOrDefault(a => a.Key.Equals(_rollbackCategory, StringComparison.InvariantCultureIgnoreCase)).Value;
            var info = infos.FirstOrDefault(i => i.DisplayText.Equals(_rollbackPosition, StringComparison.InvariantCultureIgnoreCase));
            string saveFolder = Path.Combine(Variables.VmWareSharedFolder, $@"TestTools\Rollback\RollbackTestLogs\{archFolder}");

            if (!string.IsNullOrEmpty(_rollbackCategory) && !string.IsNullOrEmpty(_rollbackPosition))
                saveFolder = $@"{saveFolder}\{_rollbackCategory}\{info.Arguments}-{info.DisplayText}";

            if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);

            return saveFolder;
        }
    }
}
