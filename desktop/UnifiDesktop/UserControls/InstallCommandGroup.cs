using System;
using UnifiCommands.CommandsProvider;

namespace Unifi.UserControls
{
    internal partial class InstallCommandGroup : CommandGroupListBox
    {
        public InstallCommandGroup()
        {
            InitializeComponent();
        }

        protected override void OnListDoubleClick(object sender, EventArgs e)
        {
            // if (string.IsNullOrEmpty(txtInstallDir.Text))
            // {
            //     MessageBox.Show(@"Enter install path.");
            //     return;
            // }
            //
            if (!(ListBox.SelectedItem is TestTask info)) return;
            
            // Variables.CylanceDesktopFolder = txtInstallDir.Text.Trim();
            
            CommandsRunner.RunCommands(info.Commands);
        }

    }
}
