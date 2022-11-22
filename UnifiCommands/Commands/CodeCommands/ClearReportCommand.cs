using System.Threading.Tasks;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Uses observer pattern to delegate main form to create and publish the report so UI code can be left out of this class.
    /// </summary>
    public class ClearReportCommand : Command, IUiObservable
    {
        private IUiObserver _observer;

        public ClearReportCommand(ILogger logger) : base(logger) { }

        public override void LogParameters()
        {
            LogCommand("Clear report");
        }

        protected override Task<string> ExecuteCommand()
        {
            NotifyObserver();
            return Task.FromResult("");
        }

        public void RegisterObserver(IUiObserver observer)
        {
            _observer = observer;
        }

        public void NotifyObserver()
        {
            // Notify UI to clear report.
            _observer.ClearReport();
        }
    }
}