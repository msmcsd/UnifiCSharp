﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unifi.Observers.Animation;
using Unifi.UserControls;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls
{
    public partial class InstallOptionsGroup : UserControl
    {
        private List<FullCommandInfo> _setupCommands = new List<FullCommandInfo>();
        private List<FullCommandInfo> _installCommands = new List<FullCommandInfo>();

        public void SetCommands(List<FullCommandInfo> setupCommands, List<FullCommandInfo> installCommands)
        {
            _setupCommands = setupCommands;
            _installCommands = installCommands;

            SetVariableSource(_setupCommands);
            SetVariableSource(_installCommands);
        }

        private void SetVariableSource(List<FullCommandInfo> commands)
        {
            foreach (var command in commands)
            {
                command.VariableValueSource = this;
            }
        }

        public ILogger Logger { get; set; }

        public TestTask PrerequisiteTask { get; set; }

        public InstallOptionsGroup()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            InstallProduct();
        }


        private void InstallProduct()
        {
            var commands = GetAllCommands();
            if (commands == null) return;

            var b = new BatchCommandExecutor(commands, false, null, Logger, AppType.Desktop);
            b.Execute();
        }

        private List<FullCommandInfo> GetAllCommands()
        {
            if (_setupCommands.Count <= 0)
            {
                Logger.LogError("Setup commands not found");
                return null;
            }

            if (_installCommands.Count <= 0)
            {
                Logger.LogError("Install commands not found");
                return null;
            }

            List<FullCommandInfo> commands = new List<FullCommandInfo>();
            if (rbMsi.Checked)
            {
                if (!GetInstallerCommand(InstallerType.Msi, out var command)) return null;

                commands.AddRange(_setupCommands);
                commands.Add(command);
            }
            else if (rbBootstrapper.Checked)
            {
                if (!GetInstallerCommand(InstallerType.Bootstrapper, out var command)) return null;

                commands.AddRange(_setupCommands);
                commands.Add(command);
            }
            else
            {
                if (!GetInstallerCommand(InstallerType.CyUpgrade, out var command)) return null;

                commands.Add(command);
            }

            return commands;
        }


        private bool GetInstallerCommand(InstallerType installerType, out FullCommandInfo command)
        {
            command = _installCommands.FirstOrDefault(c => c.InstallerType == installerType);
            if (command == null)
            {
                Logger.LogError($"{installerType} install command not found");
                return false;
            }

            return true;
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {

        }

        private void InstallOptionsGroup_Paint(object sender, PaintEventArgs e)
        {
            DrawingHelper.DrawRoundBorder(this, e.Graphics, 3);
        }

        private void btnInstall_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisplayCommand();
            }
        }

        private void DisplayCommand()
        {
            var commands = GetAllCommands();
            if (commands == null) return;

            foreach (var command in commands)
                FullCommandInfo.DisplayCommand(command, Logger, AppType.Desktop);
        }

        #region Reflection Methods

        private string CylanceDesktopFolder => txtInstallDir.Text;

        private string CompileMode => chkDebugBuild.Checked ? "Debug" : "";

        private string GetConfig
        {
            get
            {
                if (rbR02.Checked)
                    return rbR02.Tag.ToString();
                else if (rbQa2.Checked)
                    return rbQa2.Tag.ToString();
                else if (rbQa2New.Checked)
                    return rbQa2New.Tag.ToString();
                else
                    return rbR01.Tag.ToString();
            }
        }

        private string GetToken
        {
            get
            {
                if (rbR02.Checked) return Variables.R02Token;

                if (rbQa2.Checked) return Variables.QA2Token;
                
                if (rbQa2New.Checked) return Variables.QA2TokenNew;

                return Variables.R01Token;
            }
        }

        private string GetInstallMode
        {
            get
            {
                if (rbMsi.Checked)
                {
                    if (rbQuiet.Checked) return "/qb";
                }
                else if (rbBootstrapper.Checked)
                {
                    if (rbQuiet.Checked) return "/q";
                }
                return "";
            }
        }

        #endregion

    }
}
