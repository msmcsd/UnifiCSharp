﻿using System;
using System.IO;
using System.Reflection;
using UnifiCommands.VariableProcessors;

namespace UnifiCommands
{
    /// <summary>
    /// Variables Used in JSON
    /// </summary>
    public class Variables
    {
        #region Environment Variables

        public static string ExplorerPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");

        public static string SystemFolder => Environment.SystemDirectory;

        public static string CmdPath => Path.Combine(Environment.SystemDirectory, "cmd.exe");

        public static string UserProfileFolder => $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";

        public static string UserDesktopFolder => $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";

        public static string RegistryPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "regedit.exe");

        #endregion

        #region VMWare constants
        public static string VmWareSharedFolder => @"\\vmware-host\Shared Folders\VMWare-Share";

        public static string JsonConfigFileName = "UnifiTasks.json";

        public static string LocalJsonConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), JsonConfigFileName);

        public static string ProgramPath => Path.Combine(VmWareSharedFolder, @"TestTools\Program");

        public static string JsonConfigPath => Path.Combine(ProgramPath, JsonConfigFileName);

        public static string InstallersFolder => Path.Combine(VmWareSharedFolder, @"TestTools\Installers");

        public static string DebugInstallersFolder => Path.Combine(VmWareSharedFolder, @"TestTools\Installers\Debug");

        public static string ProgramSettingFilePath => Path.Combine(ProgramPath, "Settings.json");

        #endregion

        #region Third party executable constants

        public static string PsExecPath => @"C:\Program Files\SysInternals\PsExec.exe";

        public static string NotepadPath => @"C:\Program Files\Notepad++\notepad++.exe";

        public static string OrcaPath => $@"C:\Program Files{(Environment.Is64BitOperatingSystem ? " (x86)" : "")}\Orca\Orca.exe";

        #endregion

        #region Protect folder constants

        public const string DefaultInstallFolder = @"C:\Program Files\Cylance\Desktop";

        public static string CylanceDesktopFolder { get; set; } = DefaultInstallFolder;

        public static string CylanceUiPath => Path.Combine(CylanceDesktopFolder, "CylanceUI.exe");

        public static string VersionDll => Path.Combine(CylanceDesktopFolder, "Cylance.Host.Versions.dll");

        public static string UpdaterDll => Path.Combine(CylanceDesktopFolder, "Cylance.Host.Updater.dll");

        public static string CustomActionDll => Path.Combine(CylanceDesktopFolder, $"Cylance.Host.Installer.CustomActions.CA_x{Arch32}.dll");

        public static string DriverPath => $@"{SystemFolder}\drivers\CylanceDrv{Arch32}.sys";

        public static string ElamDriverPath => $@"{SystemFolder}\drivers\CyElamDrv{Arch32}.sys";

        public static string UpdaterDownloadFolder => CylanceDesktopFolder;

        #endregion

        #region Protect Config Constants
        public static string ConfigPath => Path.Combine(VmWareSharedFolder, @"Shortcuts\{0}\config.xml");

        public static string R01Token { get; set; } // Retrieved at runtime from JSON.

        public static string R02Token { get; set; } // Retrieved at runtime from JSON.

        public static string QA2Token { get; set; } // Retrieved at runtime from JSON.

        #endregion

        #region Installer constants
        public static string MsiLogFolder { get; set; } // Retrieved at runtime from JSON.

        public static string MsiInstallLogPath => $@"{MsiLogFolder}\MsiInstall-Protect.log";

        public static string MsiUninstallLogPath => $@"{MsiLogFolder}\MsiUninstall-Protect.log";

        public static string BootstrapperInstallLogPath => $@"{MsiLogFolder}\MsiInstall-Protect_000_CylanceProtectSetup_x{Arch86}.log";

        public static string InstallerDownloadFolder => UserDesktopFolder;

        public static string Arch86 => Environment.Is64BitOperatingSystem ? "64" : "86";

        public static string Arch32 => Environment.Is64BitOperatingSystem ? "64" : "32";

        public static string ArchNone => Environment.Is64BitOperatingSystem ? "64" : "";

        public static string ProtectMsiNameTemplate => "CylanceProtect_x{0}.msi";

        public static string ProtectMsiNameByVmArch => string.Format(ProtectMsiNameTemplate, Arch86);

        public static string ProtectMsiToRun => $@"{InstallerDownloadFolder}\{ProtectMsiNameByVmArch}";

        public static string DtdInstallerName => $"DellThreatDefense_x{Arch86}.msi";

        public static string EsseInstallerName => $"DDP_ATP_Release_x{Arch86}.msi";

        public static string EsseUpgradeInstallerName => "DDP_ATP_Upgrade.exe";

        public static string DtdUiPath => $@"{CylanceDesktopFolder}\Dell.ThreatDefense.exe";

        public static string ProtectUpgradeInstallerName => "CyUpgrade.exe";

        public static string ProtectBootstrapperName => "CylanceProtectSetup.exe";

        public static string ProtectProductCode { get; set; } = ""; // Retrieved at runtime from JSON.

        #endregion

        #region Dev Constants
        public static string ProjectsFolder { get; set; } = ""; // Retrieved at runtime from JSON.

        public static string ProtectProjectFolder => Path.Combine(ProjectsFolder, "CylanceProtect");

        public static string ProtectDebugFolder => Path.Combine(ProtectProjectFolder, @"src\bin\Debug");

        public static string DevLogPath => $@"{ProtectDebugFolder}\log\$[GetProtectLogFileName]";

        public static string ProtectJenkinsUrl { get; set; }    // Retrieved at runtime from JSON.

        public static string DellJenkinsUrl { get; set; }   // Retrieved at runtime from JSON.

        public static string LastSuccessfulBuild => "lastSuccessfulBuild";

        public static string AllBuildsInfoUrl { get; set; }    // Retrieved at runtime from JSON.

        public const string RegistryKey = "Software\\Cylance\\Desktop";

        #endregion

    }
}
