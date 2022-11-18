using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public string GetCommand(string id)
        {
            return id;
        }

        [HttpGet("Commands")]
        public string GetAllCommands()
        {
            return "all commands";
        }

        [HttpPut]
        [Route("[controller]")]
        public string RunCommand(string commandId)
        {
            return $"Run {commandId}";
        }
    }
}