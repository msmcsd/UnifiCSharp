using System;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    public class DownloadRollbackUpdaterCommand : Command
    {
        private readonly string _version;
        private readonly string _url;
        private readonly string _packageName;
        private readonly string _destination;

        public DownloadRollbackUpdaterCommand(string job, string buildNumber, string version, ILogger logger) : base(logger)
        {
            if (!buildNumber.Equals(Variables.LastSuccessfulBuild, StringComparison.InvariantCultureIgnoreCase) &&
                !int.TryParse(buildNumber, out int _))
            {
                throw new ArgumentOutOfRangeException("Invalid build number.");
            }

            _version = version;
            _packageName = $"CyUpdate.{version}.nupkg";
            _url = $"{job}/{buildNumber}/artifact/src/CyUpdate/{_packageName}";
            _destination = $"{Variables.InstallerDownloadFolder}\\{_packageName}";
        }

        public override void LogParameters()
        {
            LogCommand($"File: {_packageName}");
        }

        protected override async Task<string> ExecuteCommand()
        {
            var cmd = new DownloadFileCommand(_url, _destination, "", Logger);
            await cmd.DownloadFile();

            return "";
        }
    }
}