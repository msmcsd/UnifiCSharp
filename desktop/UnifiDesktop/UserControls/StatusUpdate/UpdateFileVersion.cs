using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    public partial class UpdateFileVersion : UpdateByInterval
    {
        protected override string ChannelName => UpdateFileVersionBehavior.ChannelName;

        public UpdateFileVersion()
        {
            InitializeComponent();
        }

        protected override void SetupListView()
        {
            colField1.Width = 50;
            colField2.Width = 105;
            colField1.Text = "File";
            colField2.Text = "Version";
        }
    }
}
