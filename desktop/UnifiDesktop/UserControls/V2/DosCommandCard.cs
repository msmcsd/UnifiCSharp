using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
using UnifiCommands.VariableProcessors;
using UnifiDesktop.DrawingUtils;

namespace Unifi.UserControls
{
    internal partial class DosCommandCard : UserControl
    {
        private readonly ILogger _logger;
        private readonly TestTask _testTask;
        private readonly CommandsRunner _commandsRunner;

        public DosCommandCard()
        {
            InitializeComponent();
        }

        public DosCommandCard(TestTask testTask, CommandsRunner commandRunner, ILogger logger) : this()
        {
            if (testTask is null) throw new ArgumentNullException(nameof(testTask));
            if (commandRunner is null) throw new ArgumentNullException(nameof(commandRunner));
            if (logger is null) throw new ArgumentNullException(nameof(logger));

            _testTask = testTask;
            _commandsRunner = commandRunner;
            _logger = logger;

            SetupControl();
        }

        private void SetupControl()
        {
            lstCommand.DataSource = _testTask.Commands;
            label1.Text = _testTask.Name;
            int height = (lstCommand.Items.Count + 1) * lstCommand.ItemHeight + 30;
            if (height > Height) Height = height;
        }

        private void lstCommand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right && e.Button != MouseButtons.Left) return;

            lstCommand.SelectedIndex = lstCommand.IndexFromPoint(e.X, e.Y);
            if (lstCommand.SelectedIndex < 0)
            {
                Debug.WriteLine(GetType(), "lstCommand.SelectedIndex <= 0");
                return;
            }

            if (!(lstCommand.SelectedItem is FullCommandInfo info) || info == null)
            { 
                Debug.WriteLine(GetType(), "lstCommand.SelectedItem is not FullCommandInfo");
                return;
            }

            FullCommandInfo clone = (FullCommandInfo)info.Clone();
            if (e.Button == MouseButtons.Right)
                FullCommandInfo.DisplayCommand(clone, _logger, UnifiCommands.AppType.Desktop);
            else
                _commandsRunner.RunCommands(new List<FullCommandInfo> { clone });
        }

        private void lstCommand_Click(object sender, System.EventArgs e)
        {

        }

        private void lstCommand_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            if (selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.FromArgb(80, 169, 45));//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            Brush brush = selected ? Brushes.White : Brushes.Black;
            e.Graphics.DrawString(lstCommand.Items[e.Index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void DosCommandCard_Paint(object sender, PaintEventArgs e)
        {
            DrawControlBorder.Draw(this, e.Graphics, 3);
        }
    }
}
