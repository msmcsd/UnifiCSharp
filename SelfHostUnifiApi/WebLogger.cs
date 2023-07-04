using SocketIOClient;
using System;
using System.Net.Sockets;
using System.Threading;
using UnifiCommands.Logging;

namespace SelfHostUnifiApi
{
    /// <summary>
    /// Implemented using socket.io-client-csharp https://github.com/doghappy/socket.io-client-csharp/tree/master/src/SocketIOClient
    /// </summary>
    public class WebLogger : ILogger, IDisposable
    {
        private bool _disposed = false;
        private SocketIO _client = new SocketIO("http://localhost:10000/");
        private string _socketId;

        private enum SocketEvent
        {
            Error,
            Info,
            Parameters,
            Progress,
            Report
        }

        public WebLogger(AutoResetEvent ev)
        {
            //_client.On("hi", response =>
            //{
            //    // You can print the returned data first to decide what to do next.
            //    // output: ["hi client"]
            //    Console.WriteLine(response);

            //    string text = response.GetValue<string>();

            //    // The socket.io server code looks like this:
            //    // socket.emit('hi', 'hi client');
            //});

            _client.On("disconnecting", response =>
            {
                LogInfo($"{GetType().Name} disconnecting from socket serer");
                // You can print the returned data first to decide what to do next.
                // output: ["ok",{"id":1,"name":"tom"}]
                //Console.WriteLine($"From server >> {response}");

                // Get the first data in the response
                //string text = response.GetValue<string>();
                //Console.WriteLine($"From server >> {text}");
                // Get the second data in the response
                //var dto = response.GetValue<TestDTO>(1);

                // The socket.io server code looks like this:
                // socket.emit('hi', 'ok', { id: 1, name: 'tom'});
            });

            _client.OnConnected += async (sender, e) =>
            {
                //LogInfo($"{GetType().Name} connected to socket server.");
                ev.Set();

                _socketId = (sender as SocketIO).Id;
                Log("Connect", "connect to socket server");
                //Console.WriteLine($"Connected.");
                // Emit a string

                //string s = "test string";
                //Console.WriteLine($"Sending to server: {s}");
                //await _client.EmitAsync("ping", s);

                // Emit a string and an object
                //var dto = new TestDTO { Id = 123, Name = "bob" };
                //await client.EmitAsync("register", "source", dto);
            };

            _client.ConnectAsync();
        }

        public void LogCommand(string message, bool newLine)
        {
            SendMessageToSocketServer(SocketEvent.Parameters, message);
        }

        public void LogError(string message)
        {
            SendMessageToSocketServer(SocketEvent.Error, message);
        }

        public void LogInfo(string message)
        {
            SendMessageToSocketServer(SocketEvent.Info, message);
        }

        public void LogProgress(string message)
        {
            SendMessageToSocketServer(SocketEvent.Progress, message);
        }

        public void LogSocketMessage(Type type, string message) { }

        public void LogSocketError(Type type, string message) { }

        public void SendReport(string json)
        {
            SendMessageToSocketServer(SocketEvent.Report, json);
        }

        private void SendMessageToSocketServer(SocketEvent socketEvent, string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            _client.EmitAsync(socketEvent.ToString(), message);
            Log(socketEvent.ToString(), message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Log(string socketEvent, string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.ffff tt")}][{_socketId}][{socketEvent}] {message}");
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    try
                    {
                        foreach (var e in Enum.GetNames(typeof(SocketEvent)))
                        {
                            _client?.Off(e);
                            Log("Unregister", $"unregistering socket event {e}");
                        }
                        _client?.DisconnectAsync();
                        Log("Disconnect", "disconnect socket");
                    }
                    finally
                    {
                        _client?.Dispose();
                        Log("Dispose", "socket object disposed");
                    }
                }

                // Note disposing has been done.
                _disposed = true;
            }
        }
    }
}