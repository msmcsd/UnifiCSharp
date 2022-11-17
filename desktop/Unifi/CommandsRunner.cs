using System.Collections.Generic;
using Unifi.Observers.Animation;
using UnifiCommands.Commands;
using UnifiCommands.Logging;

namespace Unifi
{
    internal class CommandsRunner
    {
        private readonly IObserver _observer;
        private readonly ILogger _logger;
        private readonly object _mainForm;
        private readonly object _uiObserver;
        private readonly bool _checkReturnValue;

        /// <summary>
        /// Main function to run commands.
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="uiObserver"></param>
        /// <param name="checkReturnValue"></param>
        /// <param name="logger"></param>
        /// <param name="mainForm"></param>
        public CommandsRunner(object uiObserver, bool checkReturnValue, IObserver observer, ILogger logger, object mainForm)
        {
            _uiObserver = uiObserver;
            _checkReturnValue = checkReturnValue;
            _observer = observer;
            _logger = logger;
            _mainForm = mainForm;
        }

        public void RunCommands(List<CommandInfo> commandInfos)
        {
            var b = new BatchCommandExecutor(commandInfos, _checkReturnValue, _uiObserver, _logger, _mainForm);
            if (_observer != null)
            {
                b.RegisterObserver(_observer);
            }
            
            b.Execute();
        }
    }
}
