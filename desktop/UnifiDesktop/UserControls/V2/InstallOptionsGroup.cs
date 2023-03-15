using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands.CommandsProvider;

namespace UnifiDesktop.UserControls
{
    public partial class InstallOptionsGroup : UserControl
    {
        public InstallOptionsGroup()
        {
            InitializeComponent();
        }

        public TestTask PrerequisiteTask { get; set; }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            InstallProduct();
        }

        private void InstallProduct()
        {

        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {

        }

        #region Reflection Methods

        private string InstallFolder => txtInstallDir.Text;

        private int IsDebugInstaller => chkDebugBuild.Checked ? 1 : 0;

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

        #endregion
    }
}
