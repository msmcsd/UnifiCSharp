using System.Threading.Tasks;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;

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
            _observer.ShowReport(_isInstallReport);
        }
    }
}