using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;
using UnifiCommands.VariableProcessors;

namespace UnifiDesktop.UserControls
{
    public partial class VersionGrid : UserControl
    {
        public List<FullCommandInfo> Commands { get; set; }

        public object FormObject { get; set; }

        public VersionGrid()
        {
            InitializeComponent();
        }

        private void SetupListView()
        {
            lstVersion.Columns[0].Width = 70;
            lstVersion.Columns[1].Width = 110;
        }

        public void PopulateItems()
        {
            if (Commands == null)
            {
                return;
            }

            lstVersion.Items.Clear();
            SetupListView();

            foreach (var c in Commands)
            {
                var item = new ListViewItem(new[] { c.DisplayText, "" })
                {
                    UseItemStyleForSubItems = true,
                    Tag = c
                };

                lstVersion.Items.Add(item);
            }
        }

        public void ShowFilesVersions(object source, ElapsedEventArgs e)
        {
            VariableConverter converter = new DesktopRuntimeVariableConverter(FormObject);

            foreach (ListViewItem item in lstVersion.Items)
            {
                FullCommandInfo info = (FullCommandInfo)item.Tag;
                if (!info.Command.Equals("FileVersion", StringComparison.InvariantCultureIgnoreCase)) continue;

                string filePath = converter.ReplaceVariables(info.Arguments);
                var version = System.IO.File.Exists(filePath) ? FileVersionInfo.GetVersionInfo(filePath).FileVersion : "";

                if (item.SubItems[1].Text != version)
                {
                    item.SubItems[1].Text = version;
                }
            }

        }
    }
}
