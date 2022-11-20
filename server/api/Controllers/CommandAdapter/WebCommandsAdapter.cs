using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnifiCommands.Commands;

namespace api.Controllers.CommandAdapter
{
    /// <summary>
    /// Adapter classes that converts CommandInfo to WebCommandinfo.
    /// </summary>
    public class WebCommandsAdapter
    {
        private WebCommandInfo _webCommandInfo;

        public WebCommandInfo WebCommandInfo => _webCommandInfo;

        public WebCommandsAdapter(CommandInfo commandInfo)
        {

            if (commandInfo == null) throw new ArgumentNullException($"{nameof(commandInfo)} is null");

            _webCommandInfo = new WebCommandInfo
            {
                Command = commandInfo.Command,
                DisplayText = commandInfo.DisplayText
            };
        }
    }
}