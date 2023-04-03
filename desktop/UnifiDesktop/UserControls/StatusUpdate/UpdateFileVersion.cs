using UnifiCommands.Socket.Behaviors;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    public partial class UpdateFileVersion : UpdateByInterval
    {
        public UpdateFileVersion()
        {
            InitializeComponent();
        }

        protected override string ChannelName => UpdateFileVersionBehavior.ChannelName;

        protected override void SetupListView()
        {
            colField1.Width = 50;
            colField2.Width = 105;
            colField1.Text = "File";
            colField2.Text = "Version";
        }
    }
}
