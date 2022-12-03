using SocketIOClient;
using SocketIOClient.Messages;
using System;
using System.Net.Sockets;
using UnifiCommands.Logging;

public class WebLogger : ILogger, IDisposable
{
    private bool _disposed = false;
    SocketIO _client = new SocketIO("http://localhost:10000/");

    private enum SocketEvent
    {
        Error,
        Info,
        CommandInfo,
        Progress
    }

    public WebLogger()
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
            LogInfo($"{GetType().Name} connected to socket server.");
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
        SendMessageToSocketServer(SocketEvent.CommandInfo, message);
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

    private void SendMessageToSocketServer(SocketEvent socketEvent, string message)
    {
        _client.EmitAsync(socketEvent.ToString(), message);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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
                    foreach(var e in Enum.GetNames(typeof(SocketEvent)))
                    {
                        //_client?.Off(e);
                    }
                    //_client?.DisconnectAsync();
                }
                finally
                {
                    //_client?.Dispose();
                }
            }

            // Note disposing has been done.
            _disposed = true;
        }
    }
}