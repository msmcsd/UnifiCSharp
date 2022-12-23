using System.Web.Http.SelfHost;
using System.Web.Http;
using System;
using System.Web.Http.Cors;

namespace SelfHostUnifiApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var apiUrl = "http://localhost:5000";

            var config = new HttpSelfHostConfiguration(apiUrl);
            config.Routes.MapHttpRoute("default",
                                        "api/{controller}/{action}",
                                        new { controller = "Commands", action = RouteParameter.Optional });

            config.EnableCors(new EnableCorsAttribute("http://localhost:3000, https://msmcsd.github.io", headers: "*", methods: "*"));

            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine($"Web API Server has started at {apiUrl}");
            Console.ReadLine();
        }
    }
}