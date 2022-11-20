using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandExecutors;
using UnifiCommands.Commands;
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

        public object MainForm { get; set; }

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
            List<ReportItem> reportItems = RunReport(DosTasks, isInstall);
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

        private List<ReportItem> RunReport(List<TestTask> dosTasks, bool isInstall)
        {
            List<ReportItem> reportItems = new List<ReportItem>();
            ReportCommandExecutor reportExecutor = new ReportCommandExecutor(Logger);

            foreach (var task in dosTasks)
            {
                string category = task.Name;
                string preCategory = "";

                foreach (var commandInfo in task.Commands)
                {
                    if (!commandInfo.Visible || string.IsNullOrEmpty(commandInfo.KeywordForSuccess)) continue;

                    string output;
                    if (commandInfo.Type == CommandInfo.CommandType.Dos)
                    {
                        output = reportExecutor.Run(commandInfo, null);
                    }
                    else
                    {
                        Command command = CommandFactory.CreateCommand(commandInfo, Logger, AppType.Desktop);
                        output = command.Execute().GetAwaiter().GetResult();
                    }

                    bool containsKeyword = output.ToLower().Contains(commandInfo.KeywordForSuccess.ToLower());

                    if (!isInstall) containsKeyword = !containsKeyword;

                    reportItems.Add(new ReportItem
                    {
                        Category = category == preCategory ? "" : category,
                        Test = commandInfo.DisplayText,
                        Passed = containsKeyword,
                        Command = commandInfo
                    });

                    preCategory = category;
                }
            }

            return reportItems;
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
            if (lstReport.SelectedItems.Count <= 0) return;

            CommandInfo commandInfo = (CommandInfo)lstReport.SelectedItems[0].Tag;
            if (commandInfo == null) return;

            Command command = CommandFactory.CreateCommand(commandInfo, Logger, AppType.Desktop);

            await command.Execute();
        }

    }
}
