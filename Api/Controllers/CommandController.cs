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
            return await ExecuteCommand(taskName, displayText, parameters, true);
        }

        [HttpGet]
        [Route("[controller]/Show")]
        public async Task<string> ShowCommand(string taskName, string displayText, string parameters)
        {
            return await ExecuteCommand(taskName, displayText, parameters, false);
        }

        private async Task<string> ExecuteCommand(string taskName, string displayText, string parameters, bool execute)
        {
            FullCommandInfo command = _commandsProvider.FindCommand(taskName, displayText);
            if (command == null) return "{\"result\": \"Command not found\"}";

            dynamic variables = null;

            if (!string.IsNullOrEmpty(parameters))
            {
                var expConverter = new ExpandoObjectConverter();
                parameters = parameters.Replace("\\\"", "\"");
                parameters = parameters.Replace("\\\\", "\\");
                if (parameters.EndsWith("\"")) parameters = parameters.Substring(0, parameters.Length - 1);
                if (parameters.StartsWith("\"")) parameters = parameters.Substring(1);
                try
                {
                    variables = JsonConvert.DeserializeObject<ExpandoObject>(parameters, expConverter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "{\"result\": \"" + e.Message + "\"}";
                }
            }
            AutoResetEvent ev = new AutoResetEvent(false); // Ensure socket server is connected before running commands.
            UnifiCommands.Logging.ILogger webLogger = new WebLogger(ev);
            ev.WaitOne();

            command.VariableValueSource = variables;
            string msg = "Command finished running";
            if (execute)
            {
                await RunCommands(new List<FullCommandInfo>() { command }, webLogger);
            }
            else
            {
                string s = FullCommandInfo.ShowCommand(command, webLogger, new WebRuntimeVariableConverter(variables));
                if (!string.IsNullOrEmpty(s)) msg = s;
            }
            //(webLogger as IDisposable).Dispose();

            return "{\"result\": \"" + msg + "\"}";
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
    }
}