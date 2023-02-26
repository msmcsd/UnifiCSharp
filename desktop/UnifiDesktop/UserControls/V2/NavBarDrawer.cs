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
            navBar1.MenuClick += OnMenuClick;
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            drawer1.Visible = true;
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
