using System.Windows.Forms;
using UnifiCommands.Logging;

namespace UnifiDesktop.UserControls.V2
{
    public partial class NavDrawer : UserControl
    {
        private readonly ILogger _logger;
        private const int LoopCount = 10;

        public NavDrawer()
        {
            InitializeComponent();
        }

        public NavDrawer(ILogger logger) : this()
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
    }
}
