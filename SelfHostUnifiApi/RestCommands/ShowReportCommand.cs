using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Observers.Report;
using UnifiCommands.Report;

namespace SelfHostUnifiApi.RestCommands
{
    internal class ShowReportCommand : WebCommand, IUiObserver
    {
        List<ReportItem> _items;

        public ShowReportCommand(ICommandsProvider commandsProvider, string taskName, string displayText, string parameters) : base(commandsProvider, taskName, displayText, parameters) { }

        public void ClearReport()
        {
            throw new System.NotImplementedException();
        }

        public void ShowReport(bool installedReport)
        {
            var commands = CommandsProvider.DosTasks.SelectMany(t => t.Commands).Where(c => !string.IsNullOrEmpty(c.KeywordForSuccess)).ToList();
            _items = UnifiCommands.Commands.CodeCommands.ShowReportCommand.RunReport(commands, installedReport, logger, UnifiCommands.AppType.Web);
            string json = JsonConvert.SerializeObject(_items);
            logger.SendReport(json);
        }

        protected override async Task<string> ExecuteCommand()
        {
            await RunCommands(new List<FullCommandInfo>() { command }, false, this, logger);
            return "";
        }
    }
}
