using System;
using System.ServiceProcess;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace SelfHostUnifiApi
{
    internal class UnifiService : ServiceBase
    {

        protected override void OnStart(string[] args)
        {
            StartApiServer();
            base.OnStart(args);
        }

        public static void StartApiServer()
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
        }
    }
}
