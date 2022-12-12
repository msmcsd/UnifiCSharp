using System.Threading.Tasks;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.VariableProcessors;

namespace UnifiApi.RestCommands
{
    /// <summary>
    /// Displays command details. Does not run the command.
    /// </summary>
    internal class DisplayCommand : WebCommand
    {
        public DisplayCommand(ICommandsProvider commandsProvider, string taskName, string displayText, string parameters) : base(commandsProvider, taskName, displayText, parameters) { }

        protected override Task<string> ExecuteCommand()
        {
            FullCommandInfo.DisplayCommand(command, logger, new WebRuntimeVariableConverter(variables));
            return Task.FromResult("");
        }
    }
}
