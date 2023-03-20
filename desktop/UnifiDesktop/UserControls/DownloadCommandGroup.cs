using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Unifi;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Logging;
using static UnifiCommands.Commands.CodeCommands.DownloadInstallerCommand;

namespace UnifiDesktop.UserControls
{
    internal partial class DownloadCommandGroup : UserControl
    {
        public ILogger Logger { get; set; }

        public CommandsRunner CommandsRunner { get; set; }

        public DownloadCommandGroup()
        {
            InitializeComponent();
            SetupEventHandlers();
            AddRelaseUrlList();
        }

        private void SetupEventHandlers()
        {
            pnlJenkins.DoubleClick += DownloadInstaller;
            pnlBuild.DoubleClick += DownloadInstaller;
            pnlInstaller.DoubleClick += DownloadInstaller;
        }

        private class ReleaseUrl
        {
            public string Name { get; set; }

            public string Url { get; set; }
        }

        private List<ReleaseUrl> _releaseUrls = new List<ReleaseUrl>
        {
            new ReleaseUrl { Name="3.1", Url = "Protect/job/Agent/job/REL/job/3-1/job/agent-x-3-1-dna" },
            new ReleaseUrl { Name="3.0", Url = "Protect/job/Agent/job/REL/job/3-0/job/agent-x-3-0-dna" },
            new ReleaseUrl { Name="2.1.1580", Url = "Protect/job/Agent/job/REL/job/1580/job/agent-x-1580-dna" },
            new ReleaseUrl { Name="2.1.1578", Url = "Protect/job/Agent/job/REL/job/1570/job/agent-x-1570-dna" }
        };

        private void AddRelaseUrlList()
        {
            cmbReleaseUrls.DataSource = _releaseUrls;
            cmbReleaseUrls.DisplayMember = "Name";
            cmbReleaseUrls.ValueMember = "Url";
        }

        private async void DownloadInstaller(object sender, EventArgs e)
        {
            string url = GetTagOfSelectedOption(pnlJenkins);

            //if (!GetBuildNumber(url, out string argument, out string version)) return;
            // Get build number and version
            string buildNumber = null;
            string version = null;
            if (rbLatestBuild.Checked)
            {
                buildNumber = Variables.LastSuccessfulBuild;
            }
            else if (rbBuildVersion.Checked)
            {
                if (!Version.TryParse(cmbVersion.Text, out _))
                {
                    MessageBox.Show("Invalid version.");
                    return;
                }

                version = cmbVersion.Text;
                string installerName = GetMsiInstallerName(url);
                string installerFile = Path.Combine(Variables.InstallersFolder, version);
                installerFile = Path.Combine(installerFile, installerName);
                if (File.Exists(installerFile))
                {
                    File.Copy(installerFile, Path.Combine(Variables.UserDesktopFolder, installerName), true);
                    Logger.LogInfo($"Copied {installerFile}");
                    return;
                }

                buildNumber = await GetBuildNumberByVersion(url, version, Logger);
                if (buildNumber == null) return;
            }
            else
            {
                if (string.IsNullOrEmpty(txtBuildNumber.Text) || !int.TryParse(txtBuildNumber.Text, out _))
                {
                    MessageBox.Show("Invalid build number.");
                    return;
                }

                buildNumber = txtBuildNumber.Text;
                version = await GetVersionByBuildNumber(url, int.Parse(buildNumber), Logger);
                if (version == null) return;
            }

            FullCommandInfo command = new FullCommandInfo
            {
                Command = url,
                Arguments = buildNumber,
                DisplayText = version
            };

            string type = GetTagOfSelectedOption(pnlInstaller);
            InstallerType installerType = (InstallerType)Enum.Parse(typeof(InstallerType), type);

            command = SetUpCommand(command, installerType);
            CommandsRunner.RunCommands(new List<FullCommandInfo> { command });
        }

        private string GetTagOfSelectedOption(Panel grp)
        {
            foreach (var control in grp.Controls)
            {
                if (control is RadioButton)
                    if (((RadioButton)control).Checked)
                        return ((RadioButton)control).Tag.ToString();
            }

            return "";
        }

        private void OnControlKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                DownloadInstaller(null, null);
            }
        }

        private void cmbReleaseUrls_Click(object sender, EventArgs e)
        {
            rbReleaseBuild.Checked = true;
        }

        private void cmbReleaseUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReleaseUrls.SelectedValue is ReleaseUrl)
                rbReleaseBuild.Tag = ((ReleaseUrl)cmbReleaseUrls.SelectedValue).Url;
            else
                rbReleaseBuild.Tag = cmbReleaseUrls.SelectedValue;
        }

        private void cmbVersion_Click(object sender, EventArgs e)
        {
            rbBuildVersion.Checked = true;
        }

        private void OnControlMouseDown(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox) rbBuildVersion.Checked = true;
            if (sender is TextBox) rbBuildNo.Checked = true;
        }
    }
}
