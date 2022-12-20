using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnifiApi.RestCommands;
using UnifiCommands.CommandsProvider;

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
        public async Task<string> GetCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DosCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }
        
        [HttpGet]
        [Route("[controller]/Report")]
        public async Task<string> ReportCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new ShowReportCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        [Route("[controller]/DisplayCommand")]
        public async Task<string> DisplayCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DisplayCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        [Route("[controller]/DisplayTask")]
        public async Task<string> DisplayTask(string taskName, string parameters)
        {
            var cmd = new DisplayTaskCommand(_commandsProvider, taskName, parameters);
            return await cmd.Execute();
        }
        
        [HttpGet]
        [Route("[controller]/Install")]
        public async Task<string> Install(string taskName, string parameters)
        {
            var cmd = new InstallCommand(_commandsProvider, taskName, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        [Route("[controller]/Download")]
        public async Task<string> DownloadCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DownloadCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet("Commands")]
        public List<WebTestTask> GetAllCommands()
        {
            var a = _commandsProvider.WebTestTasks;
            return a;
        }
    }
}