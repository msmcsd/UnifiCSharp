using System;
using System.Threading.Tasks;
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
            Task.Run(SetupSocket);
        }

        private void SetupSocket()
        {
            SocketUtils.CreateSocketClient(MonitorKeywordsBehavior.ChannelName, GetType().Name, OnReceiveMessage, null);
            Click += (sender, e) => Clear();
        }

        private void OnReceiveMessage(object sender, MessageEventArgs e)
        {
            SocketMessage message = SocketUtils.DeserializeMessage(e.Data);
            if (message != null && message.Type == SocketMessageType.DisplayKeywords)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    AppendText(message.Data + Environment.NewLine);
                    ScrollToCaret();
                }));
            }
        }
    }
}
