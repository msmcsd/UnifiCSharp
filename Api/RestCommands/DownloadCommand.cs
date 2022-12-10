using System;
using System.Threading.Tasks;
using UnifiCommands.CommandsProvider;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

namespace UnifiApi.RestCommands
{
    /// <summary>
    /// Downloads an installer basd on type.
    /// </summary>
    internal class DownloadCommand : WebCommand
    {
        private readonly InstallerType _installerType;

        public DownloadCommand(ICommandsProvider commandsProvider, string taskName, string displayText, string parameters) : base(commandsProvider, taskName, displayText, parameters)
        {
        }

        protected override async Task<string> ExecuteCommand()
        {
            InstallerType installerType;
            try
            {
                if (!Enum.TryParse<InstallerType>(variables.installerType, out installerType))
                {
                    return "Unable to parse installer type";
                }
            }
            catch (Exception e)
            {
                return $"Unable to parse installer type. {e}";
            }

            command = SetUpCommand(command, installerType);
            await RunCommands(command, false, null, logger);
            
            return "";
        }
    }
}
