namespace UnifiCommands.Observers.Report
{
    // These two interfaces (Observer Pattern) are used to keep UI code out of the ClearReportCommand and ShowReportCommand.

    /// <summary>
    /// Interface that registers ClearReportCommand or ShowReportCommand as an observable so they can send notifications to
    /// main form to do its work on the report list view.
    /// </summary>
    public interface IUiObservable
    {
        void RegisterObserver(IUiObserver observer);

        void NotifyObserver();
    }

    /// <summary>
    /// Interface implemented by main form to watch for notifications from either ClearReportCommand or ShowReportCommand
    /// and do its respective work.
    /// </summary>
    public interface IUiObserver
    {
        /// <summary>
        /// Function called by ClearReportCommand
        /// </summary>
        void ClearReport();

        /// <summary>
        /// Function called by ShowReportCommand.
        /// </summary>
        /// <param name="installedReport"></param>
        void ShowReport(bool installedReport);
    }
}