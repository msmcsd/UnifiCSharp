using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandExecutors;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiCommands.Observers.Report;
using UnifiCommands.Report;

namespace Unifi.UserControls
{
    internal partial class ReportGrid : UserControl, IUiObserver
    {
        public List<TestTask> DosTasks { get; set; }

        public ILogger Logger { get; set; }

        public ReportGrid()
        {
            InitializeComponent();
        }

        private void SetupListView()
        {
            lstReport.Columns[0].Width = 80;
            lstReport.Columns[1].Width = 160;
            lstReport.Columns[2].Width = 160;
        }

        /// <summary>
        /// Implements IUiObserver.ClearReport().
        /// </summary>
        public void ClearReport()
        {
            Invoke(new MethodInvoker(() => lstReport.Items.Clear()));
        }

        /// <summary>
        /// Implements IUiObserver.ShowReport().
        /// </summary>
        public void ShowReport(bool isInstall)
        {
            InvokeUiMethod(() => lstReport.Items.Clear());

            if (DosTasks == null)
            {
                Debug.Fail($"{nameof(DosTasks)} is null");
                return;
            }

            InvokeUiMethod(SetupListView);
            List<ReportItem> reportItems = ShowReportCommand.RunReport(DosTasks, isInstall, Logger, AppType.Desktop);
            InvokeUiMethod(() => PopulateReport(reportItems));
        }

        /// <summary>
        /// Invokes a method on UI thread on the right thread.
        /// </summary>
        /// <param name="action"></param>
        private void InvokeUiMethod(System.Action action)
        {
            if (lstReport.InvokeRequired)
                lstReport.BeginInvoke(new MethodInvoker(action));
            else
                action.Invoke();
        }

        private void PopulateReport(IEnumerable<ReportItem> reportItems)
        {
            lstReport.Items.Clear();

            string category = "";
            foreach (var reportItem in reportItems)
            {
                string newCategory;
                if (category != reportItem.Category)
                {
                    category = reportItem.Category;
                    newCategory = category;
                }
                else
                {
                    newCategory = "";
                }

                var item = new ListViewItem(new[] { newCategory, reportItem.Test, reportItem.Command.KeywordForSuccess })
                {
                    UseItemStyleForSubItems = true,
                    BackColor = reportItem.Passed ? Color.LightGreen : Color.LightSalmon,
                    Tag = reportItem.Command
                };

                lstReport.Items.Add(item);
            }
        }

        private async void lstReport_DoubleClick(object sender, EventArgs e)
        {
            if (lstReport.SelectedItems.Count <= 0)
            {
                return;
            }

            FullCommandInfo commandInfo = (FullCommandInfo)lstReport.SelectedItems[0].Tag;
            if (commandInfo == null) return;

            Command command = CommandFactory.CreateCommand(commandInfo, Logger, AppType.Desktop);

            await command.Execute();
        }

        private async Task CreateReport(bool installed)
        {
            FullCommandInfo command = new FullCommandInfo
            {
                Command = "ShowReport",
                DisplayText = $"Show {(installed? "Installed" : "Uninstalled")} Report",
                Type = CommandType.Code,
                Arguments = installed? "true" : "false"
            };

            var cmd = new BatchCommandExecutor(new List<FullCommandInfo> { command }, false, this, Logger, AppType.Desktop);
            await cmd.Execute();
        }

        private async Task ClearReportItems()
        {
            FullCommandInfo command = new FullCommandInfo
            {
                Command = "ClearReport",
                DisplayText = $"Clear Report",
                Type = CommandType.Code
            };

            var cmd = new BatchCommandExecutor(new List<FullCommandInfo> { command }, false, this, Logger, AppType.Desktop);
            await cmd.Execute();
        }

        private async void lstReport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    await CreateReport(true);
                    break;
                case 1:
                    await CreateReport(false);
                    break;
                case 2:
                    await ClearReportItems();
                    break;
            }
        }
    }
}
