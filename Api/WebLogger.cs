using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnifiCommands.Logging;

public class WebLogger : ILogger, IDisposable
{
    // Establish the remote endpoint
    // for the socket. This example
    // uses port 11111 on the local
    // computer.

    private readonly Socket _sender;
    private bool _disposed = false;
    
    public WebLogger()
    {
        IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

        _sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        _sender.Connect(localEndPoint);

        Console.WriteLine("Socket connected to -> {0} ", _sender.RemoteEndPoint.ToString());
    }

    public void LogCommand(string message, bool newLine)
    {
        SendMessageToSocketServer($"[COMMAND]{message}");
    }

    public void LogError(string message)
    {
        SendMessageToSocketServer($"[ERROR]{message}");
    }

    public void LogInfo(string message)
    {
        SendMessageToSocketServer($"[INFO]{message}");
    }

    public void LogProgress(string message)
    {
        SendMessageToSocketServer($"[PROGRESS]{message}");
    }

    private void SendMessageToSocketServer(string message)
    {
        byte[] messageSent = Encoding.ASCII.GetBytes($"{message}<EOF>");
        int byteSent = _sender.Send(messageSent);
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
                    _sender.Shutdown(SocketShutdown.Both);
                }
                finally
                {
                    _sender.Close();
                }
                _sender.Dispose();
            }

            // Note disposing has been done.
            _disposed = true;
        }
    }
}