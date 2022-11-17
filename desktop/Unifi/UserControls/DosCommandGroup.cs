using System.Collections.Generic;
using System.Windows.Forms;
using UnifiCommands.Commands;

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
            CommandInfo info = ((ListBox)sender).SelectedItem as CommandInfo;
            if (info == null) return;
        
            CommandsRunner.RunCommands(new List<CommandInfo> { info });
        }

    }
}
