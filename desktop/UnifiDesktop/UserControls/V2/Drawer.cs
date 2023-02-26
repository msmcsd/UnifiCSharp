using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using UnifiCommands.Logging;

namespace UnifiDesktop.UserControls.V2
{
    /// <summary>
    /// Allows adding control to panel at design time: step 3 of 3.
    /// </summary>
    [Designer(typeof(CustomControlDesigner))]
    public partial class Drawer : UserControl
    {
        public event EventHandler CloseClick;

        private readonly ILogger _logger;
        private const int LoopCount = 10;

        public Drawer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows adding control to panel at design time: step 1 of 3.
        /// Panel for Install and Download commands.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel InnerPanel
        {
            get { return pnlDrawer; }
            set { pnlDrawer = value; }
        }

        public Drawer(ILogger logger) : this()
        {
            _logger = logger;
        }

        public void OpenPanel()
        {
            _logger.LogInfo("Open panel");
        }

        public void ClosePanel()
        {
            _logger.LogInfo("Close panel");
        }

        private void SwipablePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.Escape)
            {
                ClosePanel();
            }
        }

        private void lblCloseDrawer_Click(object sender, EventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }

        public int ClosePanelHeight
        { 
            get { return pnlCloseMenu.Height;} 
            set { pnlCloseMenu.Height = value; }
        }

        private void pnlCloseMenu_Resize(object sender, EventArgs e)
        {
            lblCloseDrawer.Top = (pnlCloseMenu.Height - lblCloseDrawer.Height) / 2;
        }
    }

    /// <summary>
    /// Allows adding control to panel at design time: step 2 of 3.
    /// </summary>
    class CustomControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            Drawer drawer = component as Drawer;
            this.EnableDesignMode(drawer.InnerPanel, "InnerPanel");

        }

    }
}
