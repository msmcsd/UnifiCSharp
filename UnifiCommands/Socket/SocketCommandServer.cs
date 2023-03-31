//using System;
//using UnifiCommands.Logging;
//using UnifiCommands.Socket.Behaviors;
//using WebSocketSharp.Server;

//namespace UnifiCommands.Socket
//{
//    public class SocketCommandServer
//    {
//        public const string SocketUrl = "ws://localhost:12345";

//        private readonly WebSocketServer _wssv;
//        private static readonly Lazy<SocketCommandServer> lazy = new Lazy<SocketCommandServer>(() => new SocketCommandServer());

//        public static SocketCommandServer Instance { get { return lazy.Value; } }

//        private SocketCommandServer()
//        {
//            _wssv = new WebSocketServer(SocketUrl);
//        }

//        public void Start(ILogger logger)
//        {
//            _wssv.AddWebSocketService<UpdateServiceStateBehavior>("/" + UpdateServiceStateBehavior.ChannelName);
//            _wssv.Start();
//            logger.LogInfo($"Socket server started. IsListening: {_wssv.IsListening}");
//        }

//        public void Stop()
//        {
//            _wssv.Stop();
//        }
//    }
//}
