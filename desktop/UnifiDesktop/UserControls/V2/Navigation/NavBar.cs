using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.V2
{
    public partial class NavBar : UserControl
    {
        [Browsable(true)]
        public event EventHandler MenuClick;

        public NavBar()
        {
            InitializeComponent();
            hamburgerMenu1.HamburgerClicked += ClickMenu;
        }

        private void ClickMenu(object sender, EventArgs e)
        {
            MenuClick?.Invoke(this, e);   
        }

        private void NavBar_Resize(object sender, EventArgs e)
        {
            hamburgerMenu1.Top = (Height - hamburgerMenu1.Height) / 2;
            lblAppName.Top = (Height - lblAppName.Height) / 2;
        }
    }
}
