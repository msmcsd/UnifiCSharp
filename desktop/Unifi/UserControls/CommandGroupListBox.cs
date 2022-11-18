using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Unifi.Consoles;
using UnifiCommands;
using UnifiCommands.Commands;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;

namespace Unifi.UserControls
{
    internal partial class CommandGroupListBox : UserControl
    {
        public object SelectedItem => lstCommand.SelectedItem;

        public override string Text => lstCommand.Text;

        public ILogger Logger { get; set; }

        public string GroupName
        {
            get => grpCommand.Text;
            set => grpCommand.Text = value;
        }

        public CommandsRunner CommandsRunner { get; set; }

        public ListBox ListBox => lstCommand;

        public TestTask TestTask
        {
            set
            {
                lstCommand.DataSource = value.Commands;
                grpCommand.Text = value.Name;
                int height = (lstCommand.Items.Count + 1) * lstCommand.ItemHeight + 30;
                if (height > Height) Height = height;
            }
        }

        public CommandGroupListBox()
        {
            InitializeComponent();
        }

        protected bool ValidateProperties()
        {
            if (CommandsRunner == null)
            {
                MessageBox.Show(@"CommandsRunner is not assigned.");
                return false;
            }

            return true;
        }

        private void lstCommand_MouseDown(object sender, MouseEventArgs e)
        {
            OnListMouseDown(sender, e);
        }

        protected virtual void OnListMouseDown(object sender, MouseEventArgs e)
        {
            if (!ValidateProperties()) return;

            if (e.Button != MouseButtons.Right) return;

            lstCommand.SelectedIndex = lstCommand.IndexFromPoint(e.X, e.Y);
            if (lstCommand.SelectedIndex < 0)
            {
                Debug.WriteLine(GetType(),"lstCommand.SelectedIndex <= 0");
                return;
            }

            if (!(lstCommand.SelectedItem is CommandInfo info)) return;

            CommandInfo clone = (CommandInfo)info.Clone();
            clone.Command = Variables.ReplaceRunTimeVariables(clone.Command, clone.MainForm);
            clone.Arguments = Variables.ReplaceRunTimeVariables(clone.Arguments, clone.MainForm);

            Logger.LogCommand(clone.FullCommand, false);
        }

        private void lstCommand_DoubleClick(object sender, System.EventArgs e)
        {
            OnListDoubleClick(sender, e);
        }

        protected virtual void OnListDoubleClick(object sender, System.EventArgs e)
        {

        }

        private void lstCommand_Click(object sender, System.EventArgs e)
        {
            OnListClick(sender, e);
        }

        protected virtual void OnListClick(object sender, System.EventArgs e)
        {

        }

        private void lstCommand_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            if (listBox == null || listBox.Items.Count <= 0 || e.Index < 0) return;

            CommandInfo info = (CommandInfo)listBox.Items[e.Index];

            Font font = new Font(listBox.Font.FontFamily, listBox.Font.Size);

            Brush brush = info.Type == CommandInfo.CommandType.Code ? Brushes.Green : Brushes.Black;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.White;
            }
            e.DrawBackground();
            e.Graphics.DrawString(listBox.Items[e.Index].ToString(), font, brush, e.Bounds);
        }
    }
}
