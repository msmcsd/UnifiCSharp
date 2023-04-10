using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands.CodeCommands;
using UnifiCommands.Report;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    internal class UpdateReport : UpdateByInterval
    {
        private enum ReportType
        {
            Install,
            Uninstall,
            Clear
        }

        private ReportType _reportType;

        protected override string ChannelName => UpdateReportBehavior.ChannelName;

        protected override SocketMessageType MessageType => SocketMessageType.SetReportType;

        public UpdateReport()
        {
            try
            {
                string dir = Registry.LocalMachine.OpenSubKey(Variables.RegistryKey, true)?.GetValue("Path") as string;
                bool isInstall = File.Exists(Path.Combine(dir, "CylanceSvc.exe"));
                _reportType = isInstall ? ReportType.Install : ReportType.Uninstall;
            }
            catch { }
        }

        protected override void SetupListView()
        {
            colField1.Width = 150;
            colField2.Width = 150;
            colField1.Text = "Test";
            colField2.Text = "Keyword";
        }

        protected override void ProcessCommand(string socketData)
        {
            switch (socketData)
            {
                case "0":
                    _reportType = ReportType.Install;
                    Logger.LogInfo($"Component {GetType().Name} recieved show install report command.");
                    OnTimerElapse(null, null);
                    break;
                case "1":
                    _reportType = ReportType.Uninstall;
                    Logger.LogInfo($"Component {GetType().Name} recieved show uninstall report command.");
                    OnTimerElapse(null, null);
                    break;
                case "2":
                    _reportType = ReportType.Clear;
                    lstItems.Items.Clear();
                    Logger.LogInfo($"Component {GetType().Name} recieved clear report command.");
                    break;
                default:
                    Logger.LogInfo($"Component {GetType().Name} recieved an invalid report command '{socketData}'.");
                    break;
            }
        }

        protected override string[] ColumnsToShow(FullCommandInfo c)
        {
            return new[] { c.DisplayText, c.KeywordForSuccess };
        }

        protected override async void OnTimerElapse(object sender, EventArgs e)
        {
            if (_reportType == ReportType.Clear) return;

            var reportItems = await Task.Run(()=> ShowReportCommand.RunReport(CommandInfos, _reportType == ReportType.Install, Logger, UnifiCommands.AppType.Desktop));
            lstItems.BeginInvoke(new MethodInvoker(() => PublishReportItems(reportItems)));
        }

        private void PublishReportItems(List<ReportItem> reportItems)
        {
            lstItems.Items.Clear();

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

                var item = new ListViewItem(new[] { reportItem.Test, reportItem.Command.KeywordForSuccess })
                {
                    UseItemStyleForSubItems = true,
                    BackColor = reportItem.Passed ? Color.LightGreen : Color.LightSalmon,
                    Tag = reportItem.Command
                };

                lstItems.Items.Add(item);
            }
        }
    }
}
