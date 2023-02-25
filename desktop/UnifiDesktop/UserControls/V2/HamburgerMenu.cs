using System.Drawing;
using System.Windows.Forms;

namespace UnifiDesktop.UserControls.V2
{
    public partial class HamburgerMenu : UserControl
    {
        public HamburgerMenu()
        {
            InitializeComponent();
        }

        public HamburgerMenu (Color foreColor, Color backColor) : this() 
        {
            label1.ForeColor= foreColor;
            label2.ForeColor= foreColor;
            label3.ForeColor= foreColor;

            BackColor = BackColor;
        }
    }
}
