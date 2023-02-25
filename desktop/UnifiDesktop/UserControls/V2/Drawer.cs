using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;
using UnifiCommands.Logging;
using System.Windows.Forms.Design;

namespace UnifiDesktop.UserControls.V2
{
    [Designer(typeof(CustomControlDesigner))]
    public partial class Drawer : UserControl
    {
        private readonly ILogger _logger;
        private const int LoopCount = 10;

        public Drawer()
        {
            InitializeComponent();
        }

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

        private void lblCloseDrawer_Click(object sender, System.EventArgs e)
        {
            Visible = false;
        }
    }

    /// <summary>
    /// This class allows adding controls to pnlDrawer at design time.
    /// </summary>
    class CustomControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            Drawer myPanel = component as Drawer;
            this.EnableDesignMode(myPanel.InnerPanel, "InnerPanel");

        }

    }
}
