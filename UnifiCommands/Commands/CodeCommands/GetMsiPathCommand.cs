using System;
using System.Threading.Tasks;
using UnifiCommands.Logging;

namespace UnifiCommands.Commands.CodeCommands
{
    /// <summary>
    /// Locates Protect installer file path in C:\Windows\installer.
    /// </summary>
    public class GetMsiPathCommand : Command
    {
        private const string ProductName = "CylancePROTECT";

        public GetMsiPathCommand(ILogger logger) : base(logger) { }

        public override void LogParameters()
        {
        }

        protected override Task<string> ExecuteCommand()
        {
            dynamic installer = Activator.CreateInstance(Type.GetTypeFromProgID("WindowsInstaller.Installer"));

            // products has type WindowsInstaller.StringList.
            dynamic products = installer.Products;

            int productCount = products.Count;

            for (int i = 0; i < productCount; i++)
            {
                string productCode = (string)products.Item[i];
                string productName = (string)installer.ProductInfo(productCode, "ProductName");
                if (productName.Equals(ProductName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Task.FromResult((string)installer.ProductInfo(productCode, "LocalPackage"));
                }
            }

            return Task.FromResult("");
        }

        public override string ToString() => "Protect installer path";

    }
}