using SocketIOClient;

SocketIO client = new SocketIO("http://localhost:10000/");

ExecuteClient();

string s = Console.ReadLine();
while (!string.IsNullOrEmpty(s))
{
    string[] p = s.Split(new char[] { ',' });     
    await client.EmitAsync(p[0], p[1]);
    s = Console.ReadLine();
}

Console.ReadKey();

async void ExecuteClient()
{

    client.On("hi", response =>
    {
        // You can print the returned data first to decide what to do next.
        // output: ["hi client"]
        Console.WriteLine(response);

        string text = response.GetValue<string>();

        // The socket.io server code looks like this:
        // socket.emit('hi', 'hi client');
    });

    client.On("pong", response =>
    {
        // You can print the returned data first to decide what to do next.
        // output: ["ok",{"id":1,"name":"tom"}]
        //Console.WriteLine($"From server >> {response}");

        // Get the first data in the response
        string text = response.GetValue<string>();
        Console.WriteLine($"From server >> {text}");
        // Get the second data in the response
        //var dto = response.GetValue<TestDTO>(1);

        // The socket.io server code looks like this:
        // socket.emit('hi', 'ok', { id: 1, name: 'tom'});
    });

    client.OnConnected += async (sender, e) =>
    {
        Console.WriteLine($"Connected.");
        // Emit a string

        string s = "test string";
        Console.WriteLine($"Sending to server: {s}");
        await client.EmitAsync("ping", s);

        // Emit a string and an object
        //var dto = new TestDTO { Id = 123, Name = "bob" };
        //await client.EmitAsync("register", "source", dto);
    };

    await client.ConnectAsync();
}
