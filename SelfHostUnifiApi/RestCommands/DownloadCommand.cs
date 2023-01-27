using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.CommandsProvider;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

namespace SelfHostUnifiApi.RestCommands
{
    /// <summary>
    /// Downloads an installer basd on type.
    /// </summary>
    internal class DownloadCommand : WebCommand
    {
        private readonly InstallerType _installerType;

        public DownloadCommand(string parameters) : base(null, null, null, parameters)
        {
        }

        protected override bool FindCommand(out string result)
        {
            result = null;

            string version = "";
            string buildNumber = "";

            switch (variables.BuildJobTypeInfo.BuildType)
            {
                case BuildType.Latest:
                    version = "Latest";
                    buildNumber = Variables.LastSuccessfulBuild;
                    break;
                case BuildType.Version:
                    version = variables.BuildJobTypeInfo.BuildVersion;
                    buildNumber = DownloadInstallerCommand.GetBuildNumberByVersion(variables.BuildJobSourceInfo.BuildJobUrl, version, logger).Result;
                    break;
                case BuildType.BuildNumber:
                    buildNumber = variables.BuildJobTypeInfo.BuildNumber;
                    version = DownloadInstallerCommand.GetVersionByBuildNumber(variables.BuildJobSourceInfo.BuildJobUrl, int.Parse(buildNumber), logger).Result;
                    break;
            }

            command = new FullCommandInfo
            {
                Command = variables.BuildJobSourceInfo.BuildJobUrl,
                Arguments = buildNumber,
                DisplayText = version
            };
            return true;
        }

        protected override async Task<string> ExecuteCommand()
        {
            command = SetUpCommand(command, variables.InstallerType);
            await RunCommands(new List<FullCommandInfo>() { command }, false, null, logger);
            
            return "";
        }
    }
}
