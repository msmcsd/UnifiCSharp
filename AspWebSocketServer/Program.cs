using AspWebSocketServer;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args);
        var app = builder.Build();

        //app.MapGet("/", () => "Hello World!");

        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}