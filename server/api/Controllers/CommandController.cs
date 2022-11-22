using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnifiCommands;
using UnifiCommands.CommandInfo;
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
        public string GetCommand(string id)
        {
            return id;
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