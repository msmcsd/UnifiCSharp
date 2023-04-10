using System;
using System.Windows.Forms;
using UnifiCommands.Socket;
using UnifiCommands.Socket.Behaviors;
using WebSocketSharp;

namespace UnifiDesktop.UserControls
{
    public partial class ErrorConsole : RichTextBox
    {
        public ErrorConsole()
        {
            InitializeComponent();
        }

        public void Initialise()
        {
            SocketUtils.CreateSocketClient(MonitorKeywordsBehavior.ChannelName, GetType().Name, OnReceiveMessage, null);
            Click += (sender, e) => Clear();
        }

        private void OnReceiveMessage(object sender, MessageEventArgs e)
        {
            SocketMessage message = SocketUtils.DeserializeMessage(e.Data);
            if (message != null && message.Type == SocketMessageType.DisplayKeywords)
            {
                AppendText(message.Data + Environment.NewLine);
                ScrollToCaret();
            }
        }
    }
}
