using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiCommands;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.Socket.Behaviors;
using WebSocketSharp;

namespace UnifiDesktop.UserControls.StatusUpdate
{
    public partial class UpdateServiceState : UpdateByInterval
    {
        public UpdateServiceState()
        {
            InitializeComponent();
        }

        protected override string ChannelName => UpdateServiceStateBehavior.ChannelName;

        protected override void SetupListView()
        {
            colField1.Width = 50;
            colField2.Width = 105;
            colField1.Text = "Service";
            colField2.Text = "State";
        }

        //protected override void Initialize(List<FullCommandInfo> commandInfos, ILogger logger)
        //{
        //    _commandInfos = commandInfos;
        //    base.Initialize(commandInfos, logger);
        //}
    }
}
