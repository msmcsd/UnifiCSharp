using System;
using System.Linq;
using System.Reflection;
using UnifiCommands.Logging;
using UnifiCommands.Socket.Behaviors;
using WebSocketSharp.Server;

namespace UnifiCommands.Socket
{
    public class SocketCommandServer
    {
        public const string SocketUrl = "ws://localhost:12345";

        private readonly WebSocketServer _wssv;
        private static readonly Lazy<SocketCommandServer> lazy = new Lazy<SocketCommandServer>(() => new SocketCommandServer());
        private ILogger _logger;

        public static SocketCommandServer Instance { get { return lazy.Value; } }

        private SocketCommandServer()
        {
            _wssv = new WebSocketServer(SocketUrl);
            AddChannels();
        }

        private void AddChannels()
        {
            var behaviorTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && typeof(BaseBehavior).IsAssignableFrom(t) && !typeof(BaseBehavior).Equals(t)).ToList();
            var addWebSocketServiceMethod = typeof(WebSocketServer).GetMethod("AddWebSocketService", new Type[] { typeof(string) });

            foreach (var t in behaviorTypes)
            {
                var typedMethod = addWebSocketServiceMethod.MakeGenericMethod(t);
                string channel = (string)t.GetField("ChannelName", BindingFlags.Public | BindingFlags.Static).GetValue(null);
                typedMethod.Invoke(_wssv, new object[] { $"/{channel}" });
            }
        }

        private void ListChannels()
        {
            LogMessage($"Socket channel list:");
            foreach (var channel in _wssv.WebSocketServices.Paths)
            {
                LogMessage(channel);
            }
        }

        public void Start(ILogger logger)
        {
            _logger = logger;
            ListChannels();
            _wssv.Start();
            LogMessage($"Socket server started. IsListening: {_wssv.IsListening}");
        }

        public void Stop()
        {
            _wssv.Stop();
            LogMessage("Socket server stopped.");
        }

        public void LogMessage(string message)
        {
            _logger?.LogSocketMessage(GetType(), $"{message}");
        }
    }
}
