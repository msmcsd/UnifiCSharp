using SelfHostUnifiApi.RestCommands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using UnifiCommands.CommandsProvider;

namespace SelfHostUnifiApi
{
    public class CommandsController : ApiController
    {
        private static ICommandsProvider _commandsProvider = null;
        private static readonly object _lock = new object();

        public CommandsController()
        {
            if (_commandsProvider == null)
            {
                lock (_lock)
                {
                    if (_commandsProvider == null)
                    {
                        _commandsProvider = new JsonCommandsProvider();
                    }
                }
            }
        }

        [HttpGet]
        //[Route("api/[controller]/command")]
        [ActionName("Command")]
        public async Task<string> RunCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new SelfHostUnifiApi.RestCommands.DosCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        //[Route("api/[controller]/report")]
        [ActionName("Report")]
        public async Task<string> ReportCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new SelfHostUnifiApi.RestCommands.ShowReportCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        //[Route("[controller]/DisplayCommand")]
        [ActionName("DisplayCommand")]
        public async Task<string> DisplayCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DisplayCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        //[Route("[controller]/DisplayTask")]
        [ActionName("DisplayTask")]
        public async Task<string> DisplayTask(string taskName, string parameters)
        {
            var cmd = new DisplayTaskCommand(_commandsProvider, taskName, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        //[Route("[controller]/Download")]
        [ActionName("Download")]
        public async Task<string> DownloadCommand(string taskName, string displayText, string parameters)
        {
            var cmd = new DownloadCommand(_commandsProvider, taskName, displayText, parameters);
            return await cmd.Execute();
        }

        [HttpGet]
        //[Route("[controller]/Install")]
        [ActionName("Install")]
        public async Task<string> Install(string taskName, string parameters)
        {
            var cmd = new InstallCommand(_commandsProvider, taskName, parameters);
            return await cmd.Execute();
        }

        public IEnumerable<WebTestTask> GetAllTasks()
        {
            return _commandsProvider.WebTestTasks;
        }
    }
}
