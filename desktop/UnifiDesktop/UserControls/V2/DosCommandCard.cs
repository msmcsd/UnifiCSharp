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
using static System.Net.Mime.MediaTypeNames;

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

            // Draw the text 2 pixel down to make the text show vertically centered. 
            Rectangle bounds = new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.DrawString(lstCommand.Items[e.Index].ToString(), e.Font, brush, bounds, StringFormat.GenericDefault);
            
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void DosCommandCard_Paint(object sender, PaintEventArgs e)
        {
            DrawingHelper.DrawRoundBorder(this, e.Graphics, 3);
        }

        private void lstCommand_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            StringFormat sfFmt = new StringFormat(StringFormatFlags.LineLimit);
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            string text = lstCommand.Items[e.Index].ToString();
            int maxWidth = lstCommand.Width;

            int totalHeight = (int)g.MeasureString(text, lstCommand.Font, maxWidth, sfFmt).Height;
            int oneLineHeight = (int)g.MeasureString("Z", lstCommand.Font, maxWidth, sfFmt).Height;
            int additionalLineCount = totalHeight == oneLineHeight? 0 : (int)Math.Floor((decimal)totalHeight / oneLineHeight);

            if (additionalLineCount > 0)
                e.ItemHeight = lstCommand.ItemHeight + additionalLineCount * oneLineHeight;

        }
    }
}
