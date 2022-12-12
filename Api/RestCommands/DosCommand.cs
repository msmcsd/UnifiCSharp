using System.Collections.Generic;
using System.Threading.Tasks;
using UnifiCommands.CommandInfo;
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
            await WebCommand.RunCommands(new List<FullCommandInfo>() { command }, false, null, logger);
            return "";
        }
    }
}
