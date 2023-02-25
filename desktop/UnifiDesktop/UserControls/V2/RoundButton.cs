using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
    public partial class RoundButton : UserControl
    {
        public RoundButton()
        {
            InitializeComponent();
            DrawingUtils.DrawingHelper.RoundControl(this, 8);
            //DrawControlBorder.RoundControl(button1, 8);
        }
    }
}
