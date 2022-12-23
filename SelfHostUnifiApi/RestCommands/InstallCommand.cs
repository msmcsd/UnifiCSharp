using System.Threading.Tasks;
using UnifiCommands.CommandsProvider;

namespace SelfHostUnifiApi.RestCommands
{
    internal class InstallCommand : DisplayTaskCommand
    {
        public InstallCommand(ICommandsProvider commandsProvider, string taskName, string parameters) : base(commandsProvider, taskName, parameters)
        {
        }

        protected async override Task<string> ExecuteCommand()
        {
            await WebCommand.RunCommands(_task.Commands, false, null, logger);
            return "";
        }
    }
}
