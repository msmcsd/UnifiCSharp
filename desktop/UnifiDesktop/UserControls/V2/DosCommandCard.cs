using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;
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
            int clientHeight = Height - lstCommand.Height;
            lstCommand.DataSource = _testTask.Commands;
            label1.Text = _testTask.Name;
            int height = (lstCommand.Items.Count + 1) * lstCommand.ItemHeight + clientHeight;
            if (height > Height) Height = height;
        }

        private void lstCommand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right && e.Button != MouseButtons.Left) return;
            if (lstCommand.Items.Count <= 0 ) return;

            // Do not run when clicking on empty area
            Rectangle rect = lstCommand.GetItemRectangle(lstCommand.Items.Count - 1);
            if (e.Y > rect.Bottom)
            {
                return;
            }

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

        private void DosCommandCard_Paint(object sender, PaintEventArgs e)
        {
            DrawingHelper.DrawRoundBorder(this, e.Graphics, 3);
        }

    }
}
