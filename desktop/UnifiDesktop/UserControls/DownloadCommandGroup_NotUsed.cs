using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands.CodeCommands;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

namespace Unifi.UserControls
{
    internal partial class DownloadCommandGroup_NotUsed : CommandGroupListBox
    {
        public DownloadCommandGroup_NotUsed()
        {
            InitializeComponent();
        }

        protected override void OnListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                base.OnListMouseDown(sender, e);
                return;
            }

            if (!ValidateProperties()) return;

            ListBox.SelectedIndex = ListBox.IndexFromPoint(e.X, e.Y);
            
            if (ListBox.SelectedItem == null)
            {
                Logger.LogError("Select a download to continue.");
                return;
            }
            
            if (ListBox.Text.IndexOf("---", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return;
            }
            
            InstallerType installerType;
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    installerType = InstallerType.Bootstrapper;
                    break;
                case MouseButtons.Left:
                    if (e.Clicks != 2) return;
                    installerType = InstallerType.Msi;
                    break;
                case MouseButtons.Right:
                    if (e.Clicks != 2) return;
                    installerType = InstallerType.CyUpgrade;
                    break;
                default:
                    return;
            }
            
            FullCommandInfo commandInfo = (FullCommandInfo)ListBox.SelectedItem;
            FullCommandInfo clone = SetUpCommand(commandInfo, installerType);
            //FullCommandInfo clone = (FullCommandInfo)commandInfo.Clone();
            //clone.Command = "DownloadInstaller";
            
            //string installerFileName = DownloadInstallerCommand.GetInstallerNameByType(installerType, commandInfo.Command);
            
            //// Command: build job
            //// Arguments: Version of installer to download
            //clone.Arguments = $"{commandInfo.Command}, {commandInfo.Arguments}, {installerFileName}, {commandInfo.DisplayText}";
            //clone.Type = CommandType.Code;
            
            CommandsRunner.RunCommands(new List<FullCommandInfo> { clone });
        }
    }
}
