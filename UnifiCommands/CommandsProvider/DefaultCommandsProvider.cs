// using System;
// using System.Collections.Generic;
// using System.IO;
// using Unifi.Commands;
//
// namespace Unifi.CommandsProvider
// {
//     internal class DefaultCommandsProvider : ICommandsProvider
//     {
//         public List<CommandInfo> ProtectInstallCommands
//         {
//             get =>
//                 new List<CommandInfo>
//                 {
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = $"/C rd /s /q \"{Variables.CylanceDesktopFolder}\"",
//                         DisplayText = "Remove Cylance Desktop Directory"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = $"/C mkdir \"{Variables.CylanceDesktopFolder}\"",
//                         DisplayText = "Create Cylance Desktop Directory"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = "/C copy {GetConfigPath} {CylanceDesktopFolder}",
//                         DisplayText = "Copy config.xml"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = @"/C reg add HKLM\Software\Cylance\Desktop /v LogLevel /t REG_DWORD /d 3 /f",
//                         DisplayText = "Set Log Level in Registry"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments =
//                             @"/C reg add HKLM\Software\Cylance\Desktop /v SelfProtectionLevel /t REG_DWORD /d 1 /f",
//                         DisplayText = "Set Self Protection in Registry"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = $"/C mkdir {Variables.MsiLogFolder}",
//                         DisplayText = $"Create {Variables.MsiLogFolder} directory"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "msiexec.exe",
//                         Arguments =
//                             "/Lvx* {MsiInstallLogPath} /i {UserDesktopFolder}\\{InstallerFileNameByVmArch} /qb PIDKEY={GetToken} SELFPROTECTION=1 LAUNCHAPP=1",
//                         DisplayText = "Run Protect Installer"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = $"/C {Variables.CylanceUIPath} /a",
//                         DisplayText = "Start up Cylance UI"
//                     },
//                 };
//             set => throw new NotImplementedException();
//         }
//         
//         public List<CommandInfo> ProtectUninstallCommands
//         {
//             get =>
//                 new List<CommandInfo>
//                 {
//                     new CommandInfo
//                     {
//                         Command = "msiexec.exe",
//                         Arguments =
//                             $"/x {Variables.UserDesktopFolder}\\{Variables.InstallerFileNameByVmArch} /L*V {Variables.MsiUninstallLogPath} /gb",
//                         DisplayText = "Uninstall Protect"
//                     }
//                 };
//             set => throw new NotImplementedException();
//         }
//         public List<CommandInfo> OpticsInstallCommands
//         {
//             get =>
//                 new List<CommandInfo>
//                 {
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = @"/C mkdir C:\\ProgramData\\Cylance\\Optics\\Configuration",
//                         DisplayText = "Uninstall Protect"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "cmd.exe",
//                         Arguments = $@"/C copy ""{Variables.VmWareSharedFolder}\\Shortcuts\\OpticsConfiguration.xml"" C:\ProgramData\Cylance\Optics\Configuration",
//                         DisplayText = "Uninstall Protect"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "msiexec.exe",
//                         Arguments =
//                             $"/Lvx* {Variables.MsiLogFolder}\\MsiInstall-Optics.log /i {Variables.InstallerDownloadFolder}\\OpticsInstaller{Variables.ArchNone}.msi /qb",
//                         DisplayText = "Uninstall Protect"
//                     }
//                 };
//             set => throw new NotImplementedException();
//         }
//         
//         public List<CommandInfo> DosCommands
//         {
//             get =>
//                 new List<CommandInfo>
//                 {
//                     new CommandInfo
//                     {
//                         Command = "sc.exe",
//                         Arguments = "query CylanceSvc",
//                         DisplayText = "Check Protect Service"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "sc.exe",
//                         Arguments = "qprotection CylanceSvc",
//                         DisplayText = "Check AM-PPL Service"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "sc.exe",
//                         Arguments = "query CylanceDrv",
//                         DisplayText = "Check Driver Status"
//                     },
//                     new CommandInfo
//                     {
//                         Command = "sc.exe",
//                         Arguments = "query CyElamDrv",
//                         DisplayText = "Check Elam Driver Status"
//                     },
//                     new CommandInfo
//                     {
//                         // Need to have double slash on the file name.
//                         Command = "wmic",
//                         Arguments = $"datafile where name=\"{Variables.VersionDll}\" get Version /value",
//                         DisplayText = "Protect Version"
//                     }
//                 };
//             set => throw new NotImplementedException();
//         }
//
//         public List<CommandInfo> TaskBarCommands
//         {
//             get =>
//                 new List<CommandInfo>
//                 {
//                     // new CommandInfo
//                     // {
//                     //     Command = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
//                     //     DisplayText = "Chrome",
//                     //     IconSourcePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
//                     // },
//                     new CommandInfo
//                     {
//                         Command = Variables.ExplorerPath,
//                         Arguments = Path.Combine(Variables.SystemFolder, "services.msc"),
//                         DisplayText = "Services",
//                         IconSourcePath = Path.Combine(Variables.SystemFolder, "filemgmt.dll")
//                     },
//                     new CommandInfo
//                     {
//                         Command = Path.Combine(Variables.SystemFolder, "eventvwr.exe"),
//                         Arguments = "",
//                         DisplayText = "Event Viewer",
//                         IconSourcePath = Path.Combine(Variables.SystemFolder, "miguiresource.dll")
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.RegistryPath,
//                         DisplayText = "Registry",
//                         IconSourcePath = Variables.RegistryPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.ExplorerPath,
//                         Arguments = $"\"{Variables.CylanceDesktopFolder}\"",
//                         DisplayText = "Cylance Desktop",
//                         IconSourcePath = Variables.ExplorerPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.NotepadPath,
//                         DisplayText = "Notepad++",
//                         IconSourcePath = Variables.NotepadPath
//                     },
//                     new CommandInfo
//                     {
//                         // When using & to join Dos commands in one line, there is a space after the variable when it's value is printed out.
//                         // Use && to join commands and no space before and after &&
//                         Command = Variables.NotepadPath,
//                         // Arguments = TestTools.ProtectLogPath,
//                         DisplayText = "Protect Log",
//                         IconSourcePath = Variables.NotepadPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.NotepadPath,
//                         Arguments = Variables.MsiInstallLogPath,
//                         DisplayText = "Install Log",
//                         IconSourcePath = Variables.NotepadPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.NotepadPath,
//                         Arguments = Variables.MsiUninstallLogPath,
//                         DisplayText = "Uninstall Log",
//                         IconSourcePath = Variables.NotepadPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.OrcaPath,
//                         Arguments = Path.Combine(Variables.UserDesktopFolder, Variables.InstallerFileNameByVmArch),
//                         DisplayText = "Orca",
//                         IconSourcePath = Variables.OrcaPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.ExplorerPath,
//                         Arguments = Path.Combine(Variables.SystemFolder, "appwiz.cpl"),
//                         DisplayText = "Uninstall",
//                         IconSourcePath = Path.Combine(Variables.SystemFolder, "shell32.dll"),
//                         IconIndex = 207
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.PsExecPath,
//                         Arguments = $"-s -i -d cmd.exe  /K cd {Variables.CylanceDesktopFolder}",
//                         DisplayText = "Cylance Folder",
//                         IconSourcePath = Variables.CmdPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = Variables.PsExecPath,
//                         Arguments = $"-s -i -d cmd.exe /K cd {Variables.UserDesktopFolder}",
//                         DisplayText = "User Desktop",
//                         IconSourcePath = Variables.CmdPath
//                     },
//                     new CommandInfo
//                     {
//                         Command = $"{Variables.UserDesktopFolder}\\CyUpgrade.exe",
//                         Arguments = "",
//                         DisplayText = "CyUpgrade",
//                         IconSourcePath = Variables.CmdPath
//                     },
//                     // new CommandInfo
//                     // {
//                     //     Command = CmdPath,
//                     //     Arguments = $"/K cd {UserDesktop}",
//                     //     DisplayText = "User Desktop",
//                     //     IconSourcePath = CmdPath
//                     // }
//                 };
//             set => throw new NotImplementedException();
//         }
//
//         public List<CommandInfo> DownloadCommands { get; set; }
//         
//         public List<CommandInfo> AddAmpplRollbackPositions { get; set; }
//         
//         public List<CommandInfo> RemoveAmpplRollbackPositions { get; set; }
//         
//         public List<CommandInfo> UpdateAmpplRollbackPositions { get; set; }
//         
//         public TestTask BatchTask { get; set; }
//
//     }
// }
