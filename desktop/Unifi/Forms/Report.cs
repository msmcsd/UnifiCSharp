using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Unifi.Consoles;
using UnifiCommands.CommandExecutors;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Report;

namespace Unifi.Forms
{
    internal partial class Report : Form
    {
        private readonly List<CommandInfo> _commands;
        private readonly bool _isInstall;
        
        // Used when running individual test where output goes to console on the form.
        private TextBoxConsole _console;
        private DosCommandExecutor _executor;

        // Used when running the report where output is parsed to determine if a test succeeds or fails.
        private TextBoxConsole reportConsole;
        private DosCommandExecutor reportExecutor;

        public ILogger Logger { get; set; }


        public Report()
        {
            InitializeComponent();
        }

        public Report(List<CommandInfo> commands, bool isIsInstall) : this()
        {
            _commands = commands;
            _isInstall = isIsInstall;
        }

        private void Report_Load(object sender, EventArgs e)
        {
             _console = new TextBoxConsole(txtConsole);
             // _executor = new CommandExecutor(_console, OutputToConsole);
             _executor = new DosCommandExecutor(Logger);

             reportConsole = new TextBoxConsole(null);
             // reportExecutor = new CommandExecutor(reportConsole, ParseOutput);
             reportExecutor = new DosCommandExecutor(Logger);
            
             SetupListView();
             List<ReportItem> reportItems = RunReport();
            PopulateReport(reportItems);
        }

        private void SetupListView()
        {
            CategoryHeader.Width = 100;
            ResultHeader.Width = 60;
            TestHeader.Width = lstReport.Width - CategoryHeader.Width - ResultHeader.Width - 10;
        }

        private void OutputToConsole(object sender, DataReceivedEventArgs e)
        {
            _console.LogInfo(e.Data);
        }

        private void ParseOutput(object sender, DataReceivedEventArgs e)
        {
            _console.LogInfo(e.Data);
        }

        private List<ReportItem> RunReport()
        {
            List<ReportItem> reportItems = new List<ReportItem>();
            string category = "";

            foreach (var command in _commands)
            {
                if (string.IsNullOrEmpty(command.Command))
                {
                    category = command.DisplayText.Replace("-", "").Trim();
                    continue;
                }

                // string output = await Task.Run(() => reportExecutor.Run(command));
                string output = reportExecutor.Run(command, null);
                
                if (command.KeywordForSuccess == null) continue;
                bool containsKeyword = output.ToLower().Contains(command.KeywordForSuccess.ToLower());

                if (!_isInstall) containsKeyword = !containsKeyword;

                reportItems.Add(new ReportItem
                {
                    Category = category,
                    Test = command.DisplayText,
                    Passed = containsKeyword,
                    Command = command
                });
            }
            return reportItems;
        }

        private void PopulateReport(List<ReportItem> reportItems)
        {
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

                var item = new ListViewItem(new[] {newCategory, reportItem.Test, reportItem.Command.KeywordForSuccess});
                item.Tag = reportItem.Command;
                lstReport.Items.Add(item);
            }
        }

        private void lstReport_DoubleClick(object sender, EventArgs e)
        {
            if (lstReport.SelectedItems.Count <= 0) return;
            
            CommandInfo command = (CommandInfo)lstReport.SelectedItems[0].Tag;
            if (command == null) return;
            
            _executor.Run(command, null);
        }
    }
}
