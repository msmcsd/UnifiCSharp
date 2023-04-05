using System;
using UnifiCommands.Logging;
using WebSocketSharp;

namespace UnifiCommands.Socket
{
    public class SocketUtils
    {
        public static WebSocket CreateSocketClient(string channelName, string typeName, EventHandler<MessageEventArgs> onMessageEventHandler, EventHandler<WebSocketSharp.ErrorEventArgs> errorEventHandler)
        {
            WebSocket _client;

            _client = new WebSocket($"{SocketCommandServer.SocketUrl}/{channelName}");
            _client.OnOpen += (sender, e) =>
            {
                SocketCommandServer.Instance.LogMessage($"{typeName} control connected to socket channel '{channelName}'.");
            };
            _client.OnError += errorEventHandler;
            _client.OnMessage += onMessageEventHandler;
            _client.WaitTime = new TimeSpan(1, 0, 0);
            _client.Connect();

            return _client;
        }

        public static void SendCommandToChannel(string channelName, string command, EventHandler<WebSocketSharp.ErrorEventArgs> errorEventHandler)
        {
            var ws = new WebSocket($"{SocketCommandServer.SocketUrl}/{channelName}");
            // When using is used, the connection might have been disposed before message is sent.
            //using (var ws = new WebSocket($"{SocketCommandServer.SocketUrl}/{channelName}"))
            //{
            ws.OnError += errorEventHandler;
            ws.OnOpen += (sender, e) =>
            {
                SocketCommandServer.Instance.LogMessage($"InvokeSocketCommand connected to channel '{channelName}'");
                ws.Send(command);
                SocketCommandServer.Instance.LogMessage($"Sent data '{command}' to channel '{channelName}'");
            };
            ws.Connect();
            //}
        }

        public static void LogMessage(ILogger logger, string message)
        {
            logger?.LogProgress($"[Socket] {message}");

        }
    }
}
