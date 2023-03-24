using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiCommands.Logging;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace UnifiDesktop.Socket
{
    internal class SocketServer
    {
        public const string SocketUrl = "ws://localhost:12345";
        private readonly WebSocketServer _wssv;
        private static readonly Lazy<SocketServer> lazy = new Lazy<SocketServer>(() => new SocketServer());

        public static SocketServer Instance { get { return lazy.Value; } }

        private SocketServer()
        {
            _wssv = new WebSocketServer(SocketUrl);
        }

        public void Start(ILogger logger)
        {
            _wssv.AddWebSocketService<UpdateServiceStateBehavior>("/" + UpdateServiceStateBehavior.ChannelName);
            _wssv.Start();
            logger.LogInfo($"Socket server started. IsListening = {_wssv.IsListening}");
        }

        public void Stop()
        {
            _wssv.Stop();
        }
    }
}
