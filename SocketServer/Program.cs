using Newtonsoft.Json.Linq;
using SocketIOSharp.Common;
using SocketIOSharp.Server;
using System.Net.Sockets;
using System.Text;

//ExecuteServer();
StartTcpListener();

static void ExecuteServer()
{
    using (SocketIOServer server = new SocketIOServer(new SocketIOServerOption(10000)))
    {
        Console.WriteLine("Listening on " + server.Option.Port);

        server.OnConnection((socket) =>
        {
            Console.WriteLine($"Client connected! {server.ClientsCounts} ");

            socket.On("input", (data) =>
            {
                foreach (JToken token in data)
                {
                    Console.Write(token + " ");
                }

                Console.WriteLine();
                socket.Emit("echo", data);
            });

            socket.On(SocketIOEvent.DISCONNECT, () =>
            {
                Console.WriteLine("Client disconnected!");
            });

            //socket.Emit("echo", new byte[] { 0, 1, 2, 3, 4, 5 });
        });

        server.Start();

        Console.WriteLine("Input /exit to exit program.");
        string line;

        while (!(line = Console.ReadLine())?.Trim()?.ToLower()?.Equals("/exit") ?? false)
        {
            server.Emit("echo", line);
        }
    }

    Console.WriteLine("Press enter to continue...");
    Console.Read();
}

static void StartTcpListener()
{
    TcpListener serverSocket = new TcpListener(10000);
    int requestCount = 0;
    TcpClient clientSocket = default(TcpClient);
    serverSocket.Start();
    Console.WriteLine(" >> Server Started");
    clientSocket = serverSocket.AcceptTcpClient();
    Console.WriteLine(" >> Accept connection from client");
    requestCount = 0;

    while ((true))
    {
        try
        {
            //requestCount = requestCount + 1;
            NetworkStream networkStream = clientSocket.GetStream();
            //byte[] bytesFrom = new byte[10025];
            //networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
            //string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
            //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
            //Console.WriteLine(" >> Data from client - " + dataFromClient);

            //string serverResponse = "Last Message from client" + dataFromClient;
            string serverResponse = "Last Message from client";
            Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream.Flush();
            Console.WriteLine(" >> " + serverResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    clientSocket.Close();
    serverSocket.Stop();
    Console.WriteLine(" >> exit");
    Console.ReadLine();
}