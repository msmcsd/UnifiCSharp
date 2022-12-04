using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.CommandExecutors;
using UnifiCommands.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly ICommandsProvider _commandsProvider;

        public CommandController(ILogger<CommandController> logger, ICommandsProvider commandsProvider)
        {
            _commandsProvider = commandsProvider;
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<string> GetCommand(string taskName, string displayText)
        {
            FullCommandInfo command = _commandsProvider.FindCommand(taskName, displayText);
            if (command == null) return "Command not found";

            AutoResetEvent ev = new AutoResetEvent(false); // Ensure socket server is connected before running commands.
            UnifiCommands.Logging.ILogger webLogger = new WebLogger(ev);
            ev.WaitOne();
            
            await RunCommands(new List<FullCommandInfo>() { command }, webLogger);
            (webLogger as IDisposable).Dispose();
            
            return "{\"result\": \"Command finishes running\"}";
        }

        //private void RunCommands(List<FullCommandInfo> commandInfos, IObserver observer = null, bool checkReturnValue = false)
        private async Task RunCommands(List<FullCommandInfo> commandInfos, UnifiCommands.Logging.ILogger logger, bool checkReturnValue = false)
        {
            var b = new BatchCommandExecutor(commandInfos, checkReturnValue, null, logger, AppType.Web);
            //b.RegisterObserver(observer);
            await b.Execute();
        }

        [HttpGet("Commands")]
        public List<WebTestTask> GetAllCommands()
        {
            var a = _commandsProvider.WebTestTasks;
            return a;
        }

        [HttpPut]
        [Route("[controller]")]
        public string RunCommand(string commandId)
        {
            return $"Run {commandId}";
        }
    }
}