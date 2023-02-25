using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.V2
{
    public delegate void ClickEventHandler(object sender, EventArgs e);   


    public partial class HamburgerMenu : UserControl
    {
        public event ClickEventHandler HamburgerClicked;

        public HamburgerMenu()
        {
            InitializeComponent();
        }

        public Color HamburgerForeColor 
        { 
            get => label1.ForeColor;
            set
            {
                label1.ForeColor = value;
                label2.ForeColor = value;
                label3.ForeColor = value;
            } 
        }

        private void HamburgerMenu_Click(object sender, EventArgs e)
        {
            HamburgerClicked?.Invoke(sender, e);
        }
    }
}
