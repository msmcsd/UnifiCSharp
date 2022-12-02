// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;

ExecuteServer();

static void ExecuteServer()
{
    const string EOF = "<EOF>";

    // Establish the local endpoint
    // for the socket. Dns.GetHostName
    // returns the name of the host
    // running the application.
    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
    IPAddress ipAddr = ipHost.AddressList[0];
    IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

    // Creation TCP/IP Socket using
    // Socket Class Constructor
    Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

    try
    {

        // Using Bind() method we associate a
        // network address to the Server Socket
        // All client that will connect to this
        // Server Socket must know this network
        // Address
        listener.Bind(localEndPoint);

        // Using Listen() method we create
        // the Client list that will want
        // to connect to Server
        listener.Listen(10);

        while (true)
        {

            Console.WriteLine("Waiting connection ... ");

            // Suspend while waiting for
            // incoming connection Using
            // Accept() method the server
            // will accept connection of client
            Socket clientSocket = listener.Accept();
            Console.WriteLine("Client connected");

            // Data buffer
            byte[] bytes = new Byte[1024];
            string data = "";

            while (true)
            {
                int numByte = 0;

                try
                {
                    numByte = clientSocket.Receive(bytes);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Client exited");
                    break;
                }

                string s = Encoding.ASCII.GetString(bytes, 0, numByte);
                if (!s.Equals(EOF, StringComparison.InvariantCultureIgnoreCase))
                {
                    data += Encoding.ASCII.GetString(bytes, 0, numByte);
                }

                if (s.IndexOf(EOF) >= 0)
                    break;
            }

            if (data.EndsWith(EOF, StringComparison.InvariantCultureIgnoreCase))
            {
                data = data.Substring(0, data.Length - EOF.Length);
            }

            Console.WriteLine("Text received -> {0} ", data);

            // Send a message to Client
            // using Send() method
            try
            {
                clientSocket.Send(Encoding.ASCII.GetBytes(data));
            }
            catch (SocketException)
            {
                Console.WriteLine("Client exited");
            }

            // Close client Socket using the
            // Close() method. After closing,
            // we can use the closed Socket
            // for a new Client Connection
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
}