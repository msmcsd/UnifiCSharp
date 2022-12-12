using System.Threading.Tasks;
using System.Threading;
using UnifiCommands.CommandsProvider;
using UnifiCommands.CommandInfo;
using UnifiCommands.VariableProcessors;

namespace UnifiApi.RestCommands
{
    internal class DisplayTaskCommand : WebCommand
    {
        private readonly ICommandsProvider _commandsProvider;
        private readonly string _taskName;
        protected TestTask _task;

        public DisplayTaskCommand(ICommandsProvider commandsProvider, string taskName, string parameters) : base(commandsProvider, taskName, null, parameters)
        {
            _commandsProvider = commandsProvider;
            _taskName = taskName;
        }

        protected override bool FindCommand(out string result)
        {
            result = "";
            _task = _commandsProvider.FindTask(_taskName);
            if (_task == null)
            {
                result =  "{\"result\": \"Task not found\"}";
                return false;
            }

            return true;
        }

        protected override void SetVariableValueSource()
        {
            foreach (var c in _task.Commands)
                c.VariableValueSource = variables;
        }

        protected override Task<string> ExecuteCommand()
        {
            FullCommandInfo.DisplayTask(_task, logger, new WebRuntimeVariableConverter(variables));
            return Task.FromResult("");
        }
    }
}
