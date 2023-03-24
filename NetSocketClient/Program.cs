using System;
using System.Net;
using WebSocketSharp;

namespace NetSocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://localhost:12345/Laputa"))
            {
                ws.OnMessage += (sender, e) =>
                                  Console.WriteLine("Laputa says: " + e.Data);

                ws.Connect();
                ws.Send("BALUS");
                Console.ReadKey(true);
            }
        }
    }
}