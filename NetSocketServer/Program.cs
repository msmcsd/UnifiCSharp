using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using WebSocketSharp.Server;
using WebSocketSharp;

namespace NetSocketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartSocketServer();
        }

        private static void StartSocketServer()
        {
            var wssv = new WebSocketServer("ws://localhost:12345");

            wssv.AddWebSocketService<Laputa>("/Laputa");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }

    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data == "BALUS"
                      ? "Are you kidding?"
                      : "I'm not available now.";

            Send(msg);
        }
    }
}