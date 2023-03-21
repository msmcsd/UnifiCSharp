using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unifi.Observers.Animation;
using Unifi.UserControls;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;

namespace UnifiDesktop.UserControls
{
    public partial class InstallOptionsGroup : UserControl
    {
        public List<FullCommandInfo> SetupCommands { get; set; }
        
        public FullCommandInfo InstallCommand { get; set; }

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
            List<FullCommandInfo> commands = new List<FullCommandInfo>();
            commands.AddRange(SetupCommands);
            commands.Add(InstallCommand);

            foreach (var command in commands)
            {
                command.VariableValueSource = this;
            }

            var b = new BatchCommandExecutor(commands, false, null, Logger, AppType.Desktop);
            b.Execute();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {

        }

        #region Reflection Methods

        private string CylanceDesktopFolder => txtInstallDir.Text;

        private string CompileMode => chkDebugBuild.Checked ? "Debug" : "";

        private string GetConfig
        {
            get
            {
                if (rbR02.Checked)
                    return rbR02.Text;
                else if (rbQa2.Checked)
                    return rbQa2.Text;
                else
                    return rbR01.Text;
            }
        }

        private string GetToken
        {
            get
            {
                if (rbR02.Checked) return Variables.R02Token;

                if (rbQa2.Checked) return Variables.QA2Token;

                return Variables.R01Token;
            }
        }

        #endregion
    }
}
