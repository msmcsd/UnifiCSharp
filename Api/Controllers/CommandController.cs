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
using System.ComponentModel;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using UnifiCommands.Commands;
using UnifiCommands.VariableProcessors;
using UnifiApi.RestCommands;

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
            //return await ExecuteCommand(taskName, displayText, parameters, true);
            var cmd = new UnifiApi.RestCommands.DosCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        [Route("[controller]/Show")]
        public async Task<string> ShowCommand(string taskName, string displayText, string parameters)
        {
            //return await ExecuteCommand(taskName, displayText, parameters, false);
            var cmd = new DisplayCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        [Route("[controller]/Download")]
        public async Task<string> DownloadCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DownloadCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

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
    }
}