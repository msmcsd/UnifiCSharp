using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Command to copy a file.
    /// </summary>
    public class FileCopyCommand : Command
    {
        private readonly string _srcFilePath;
        private string _destFilePath;

        public FileCopyCommand(string srcFilePath, string destFilePath, ILogger logger) : base(logger)
        {
            if (string.IsNullOrEmpty(srcFilePath)) throw new ArgumentNullException($"{nameof(srcFilePath)} is null");

            _srcFilePath = srcFilePath;
            _destFilePath = destFilePath;
        }

        public override void LogParameters()
        {
            LogCommand($"Source: \"{_srcFilePath}\"",
                $"Dest: \"{_destFilePath}\"");
        }

        protected override Task<string> ExecuteCommand()
        {
            if (!File.Exists(_srcFilePath))
            {
                LogError($"Source not found \"{_srcFilePath}\"");
                return Task.FromResult("");
            }

            try
            {
                if (File.GetAttributes(_destFilePath).HasFlag(FileAttributes.Directory))
                {
                    _destFilePath = Path.Combine(_destFilePath, Path.GetFileName(_srcFilePath));
                }

                File.Copy(_srcFilePath, _destFilePath, true);
                LogInfo($"Copied \"{_srcFilePath}\" to \"{_destFilePath}\" {FileVersionInfo.GetVersionInfo(_destFilePath).FileVersion}");

                return Task.FromResult(_srcFilePath);
            }
            catch (Exception e)
            {
                LogError(e.Message);
                LogError($"Source=\"{_srcFilePath}\"");
                LogError($"Dest=\"{_destFilePath}\"");
            }
            return null;
        }
    }
}