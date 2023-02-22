using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Unifi.Observers.Animation;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.VariableProcessors;

namespace UnifiDesktop.UserControls
{
    public partial class TaskButton : UserControl
    {
        private readonly FullCommandInfo _commandInfo;
        private readonly ILogger _logger;

        public TaskButton()
        {
            InitializeComponent();
        }

        public TaskButton(FullCommandInfo commandInfo, ILogger logger) : this()
        {
            _commandInfo = commandInfo;
            _logger = logger;

            button1.Image = Unifi.Utils.ExtractIcon(_commandInfo.IconSourcePath, _commandInfo.IconIndex)?.ToBitmap();
            button1.Text = _commandInfo.DisplayText;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.Tag = _commandInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender == null) return;

            FullCommandInfo commandInfo = (FullCommandInfo)((Button)sender).Tag;
            if (commandInfo == null)
            {
                Trace.Fail("Task is null");
                return;
            }
            _commandInfo.CreateNewWindow = true;

            var b = new BatchCommandExecutor(new List<FullCommandInfo> { _commandInfo }, false, null, _logger, AppType.Desktop);
            b.Execute();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FullCommandInfo commandInfo = (FullCommandInfo)((Button)sender).Tag;
                FullCommandInfo.DisplayCommand(commandInfo, _logger, AppType.Desktop);
            }
        }
    }
}
