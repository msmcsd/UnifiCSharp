using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using UnifiDesktop.DrawingUtils;

namespace UnifiDesktop.UserControls.V2
{
 
    /// <summary>
    /// Allows adding control to panel at design time: step 3 of 3.
    /// </summary>
    [Designer(typeof(NavBarDrawerControlDesigner))]
    public partial class NavBarDrawer : UserControl
    {
        private readonly int _drawerDefaultWidth;
        public NavBarDrawer()
        {
            InitializeComponent();
            navBar1.MenuClick += OnDrawerOpen;
            drawer1.CloseClick += OnDrawerClose;
            _drawerDefaultWidth = drawer1.Width;
        }

        private void OnDrawerOpen(object sender, EventArgs e)
        {
            OpenDrawer(true);
        }

        private void OnDrawerClose(object sender, EventArgs e)
        {
            OpenDrawer(false);
        }

        private void OpenDrawer(bool show)
        {
            if (drawer1.Visible && show) return;

            //int loops = 10;
            //int sign = show? 1 : -1;
            //int offset = sign * _drawerDefaultWidth / 10;

            //for(int i = 0; i < loops; i++)
            //{
            //    if (!show && drawer1.Width + offset <=0 )
            //    {
            //        drawer1.Width = 0;
            //        return;
            //    }

            //    drawer1.Width += offset;
            //    Thread.Sleep(10);
            //}

            DrawingHelper.SuspendDrawing(this);
            drawer1.Visible = show;
            DrawingHelper.ResumeDrawing(this);
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

        [Browsable(true)]
        public Color DrawerBackColor 
        { 
            get { return drawer1.DrawerBackColor; }
            set
            {
                drawer1.DrawerBackColor = value;
            }
        }

        [Browsable(true)]
        public bool DrawerVisible
        {
            get { return drawer1.Visible; }
            set
            {
                OpenDrawer(value);
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
