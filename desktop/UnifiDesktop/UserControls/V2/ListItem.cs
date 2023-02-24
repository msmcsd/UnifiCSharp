using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
    public partial class ListItem : UserControl
    {
        public event SelectedItemEventHandler SelectedItemEventHandler;
        public int Index { get; set; }  

        public Label Label => label1;

        private Color _selectedBackColor = Color.FromArgb(80,169,45);
        private Color _unselectedBackColor = Color.White;

        private Color _selectedForeColor = Color.White;
        private Color _unselectedForeColor = Color.Black;


        private bool _selected = false;
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

        public ListItem()
        {
            InitializeComponent();
        }

        private void DosListItem_Paint(object sender, PaintEventArgs e)
        {
            DrawControlBorder.Draw(this, e.Graphics, 3);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = _selectedBackColor;
            Selected = true;
            SelectedItemEventHandler?.Invoke(sender, new SelectedItemEventArgs() { SelectedIndex = Index });
        }
    }

    public class SelectedItemEventArgs : EventArgs
    {
        public int SelectedIndex { get; set; }
    }

    public delegate void SelectedItemEventHandler(object sender, SelectedItemEventArgs e);
}
