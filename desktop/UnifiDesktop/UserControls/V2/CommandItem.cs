using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unifi;
using UnifiCommands.CommandInfo;
using UnifiCommands.Logging;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
    public partial class CommandItem : UserControl
    {
        public event SelectedItemEventHandler SelectedItemEventHandler;
        public int Index { get; set; }  

        public Label Label => label1;

        private Color _selectedBackColor = Color.FromArgb(80,169,45);
        private Color _unselectedBackColor = Color.White;

        private Color _selectedForeColor = Color.White;
        private Color _unselectedForeColor = Color.Black;


        private bool _selected = false;
        private readonly ILogger _logger;

        public bool Selected 
        {
            get => _selected;
            
            set 
            {
                _selected = value;
                label1.BackColor= _selected ? _selectedBackColor : _unselectedBackColor;
                label1.ForeColor = _selected ? _selectedForeColor : _unselectedForeColor;
            } 
        }

        public CommandItem()
        {
            InitializeComponent();
        }

        public CommandItem(ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private void DosListItem_Paint(object sender, PaintEventArgs e)
        {
            DrawControlBorder.Draw(this, e.Graphics, 3);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!Selected)
            {
                label1.BackColor = _selectedBackColor;
                Selected = true;
                SelectedItemEventHandler?.Invoke(sender, new SelectedItemEventArgs() { SelectedIndex = Index });
            }

            FullCommandInfo command = (FullCommandInfo)Tag;
            if (command == null)
            {
                _logger.LogError("Command not found");
                return;
            }

            new CommandsRunner(null, false, null, _logger, UnifiCommands.AppType.Desktop).RunCommands(new List<FullCommandInfo> { command });
        }
    }

    public class SelectedItemEventArgs : EventArgs
    {
        public int SelectedIndex { get; set; }
    }

    public delegate void SelectedItemEventHandler(object sender, SelectedItemEventArgs e);
}
