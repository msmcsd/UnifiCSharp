using System;

namespace SelfHostUnifiApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "-s")
            {
                System.ServiceProcess.ServiceBase.Run(new UnifiService());
            }
            else
            {
                UnifiService.StartApiServer();
                Console.ReadLine();
            }
        }
    }
}