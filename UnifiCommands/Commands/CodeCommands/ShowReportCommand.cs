using System.Collections.Generic;
using System.Threading.Tasks;
using UnifiCommands.CommandExecutors;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;
using UnifiCommands.Report;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Uses observer pattern to delegate main form to create and publish the report so UI code can be left out of this class.
    /// </summary>
    public class ShowReportCommand : Command, IUiObservable
    {
        private readonly bool _isInstallReport;
        private IUiObserver _observer;

        public ShowReportCommand(bool isInstallReport, ILogger logger) : base(logger)
        {
            _isInstallReport = isInstallReport;
        }

        public override void LogParameters()
        {
            LogCommand($"Show {(_isInstallReport ? "installed" : "uninstalled")} report");
        }

        protected override Task<string> ExecuteCommand()
        {
            NotifyObserver();

            return Task.FromResult("");
        }

        /// <summary>
        /// Registers UI as an observer.
        /// </summary>
        /// <param name="observer">UI form</param>
        public void RegisterObserver(IUiObserver observer)
        {
            _observer = observer;
        }

        /// <summary>
        /// Notifies UI to create and publish the report.
        /// </summary>
        public void NotifyObserver()
        {
            _observer?.ShowReport(_isInstallReport);
        }

        public static List<ReportItem> RunReport(List<TestTask> dosTasks, bool isInstall, ILogger logger, AppType appType)
        {
            List<ReportItem> reportItems = new List<ReportItem>();
            ReportCommandExecutor reportExecutor = new ReportCommandExecutor(logger);

            int id = 0;
            foreach (var task in dosTasks)
            {
                string category = task.Name;
                string preCategory = "";

                foreach (var commandInfo in task.Commands)
                {
                    if (!commandInfo.Visible || string.IsNullOrEmpty(commandInfo.KeywordForSuccess)) continue;

                    string output;
                    if (commandInfo.Type == CommandType.Dos)
                    {
                        output = reportExecutor.Run(commandInfo, null);
                    }
                    else
                    {
                        Command command = CommandFactory.CreateCommand(commandInfo, logger, appType);
                        output = command.Execute().GetAwaiter().GetResult();
                    }

                    bool containsKeyword = output.ToLower().Contains(commandInfo.KeywordForSuccess.ToLower());

                    if (!isInstall) containsKeyword = !containsKeyword;

                    reportItems.Add(new ReportItem
                    {
                        Id = id,
                        Category = appType== AppType.Desktop? category == preCategory ? "" : category : category,
                        Test = commandInfo.DisplayText,
                        Keyword = commandInfo.KeywordForSuccess,
                        Passed = containsKeyword,
                        Command = commandInfo
                    });

                    id++;

                    preCategory = category;
                }
            }

            return reportItems;
        }
    }
}