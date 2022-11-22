using System.Collections.Generic;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;

namespace Unifi.UserControls
{
    internal partial class DosCommandGroup : CommandGroupListBox
    {
        public DosCommandGroup()
        {
            InitializeComponent();
        }

        protected override void OnListClick(object sender, System.EventArgs e)
        {
            FullCommandInfo info = ((ListBox)sender).SelectedItem as FullCommandInfo;
            if (info == null) return;
        
            CommandsRunner.RunCommands(new List<FullCommandInfo> { info });
        }

    }
}
