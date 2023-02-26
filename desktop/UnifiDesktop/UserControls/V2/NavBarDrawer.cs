using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UnifiDesktop.UserControls.V2
{
    /// <summary>
    /// Allows adding control to panel at design time: step 3 of 3.
    /// </summary>
    [Designer(typeof(NavBarDrawerControlDesigner))]
    public partial class NavBarDrawer : UserControl
    {
        public NavBarDrawer()
        {
            InitializeComponent();
            navBar1.MenuClick += OnDrawerOpen;
            drawer1.CloseClick += OnDrawerClose;
        }

        private void OnDrawerOpen(object sender, EventArgs e)
        {
            drawer1.Visible = true;
        }

        private void OnDrawerClose(object sender, EventArgs e)
        {
            drawer1.Visible = false;
        }

        [Browsable(true)]
        public int NavBarHeight 
        { 
            get { return navBar1.Height; }
            set
            {
                navBar1.Height = value;
                drawer1.ClosePanelHeight = value;
            }
        }

        [Browsable(true)]
        public int DrawerWidth 
        { 
            get { return drawer1.Width; }
            set
            {
                drawer1.Width = value;
            }
        }

        /// <summary>
        /// Allows adding control to panel at design time: step 1 of 3.
        /// Panel for Install and Download commands.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel DrawerPanel
        {
            get { return drawer1.InnerPanel; }
            set { drawer1.InnerPanel = value; }
        }

        /// <summary>
        /// Allows adding control to panel at design time: step 1 of 3.
        /// Panel for all other controls.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel MainControlsPanel
        {
            get { return pnlMainControlsPanel; }
            set { pnlMainControlsPanel = value; }
        }
    }

    /// <summary>
    /// Allows adding control to panel at design time: step 2 of 3.
    /// </summary>
    class NavBarDrawerControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            NavBarDrawer drawer = component as NavBarDrawer;
            EnableDesignMode(drawer.DrawerPanel, "DrawerPanel");
            EnableDesignMode(drawer.MainControlsPanel, "MainControlsPanel");

        }

    }
}
