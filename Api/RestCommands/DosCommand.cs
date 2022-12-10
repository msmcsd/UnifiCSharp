using System.Threading.Tasks;
using UnifiCommands.CommandsProvider;

namespace UnifiApi.RestCommands
{
    /// <summary>
    /// Runs a DOS command.
    /// </summary>
    internal class DosCommand : WebCommand
    {
        public DosCommand(ICommandsProvider commandsProvider, string taskName, string displayText, string parameters) : base(commandsProvider, taskName, displayText, parameters) { }

        protected override async Task<string> ExecuteCommand()
        {
            await WebCommand.RunCommands(command, false, null, logger);
            return "";
        }
    }
}
