
using System;
using System.IO;
using System.Security.Policy;

namespace UnifiCommands.Socket.MessageClasses
{
    public class InstallParameters
    {
        public string CylanceDesktopFolder { get; set; }

        public string GetConfig { get; set; }

        public string GetInstallMode { get; set; }

        public string GetToken { get; set; }

        public string CompileMode { get; set; }

        public string OpticsInstallerName { get; set; }

        private string ProtectLogPath => Path.Combine(CylanceDesktopFolder, $@"log\{DateTime.Today:yyyy-MM-dd}.log");

        private string OpticsLogPath => Path.Combine("C:\\ProgramData\\Cylance\\Optics\\Log", $@"Optics-{DateTime.Today:yyyy-MM-dd}.csv");

    }

}
