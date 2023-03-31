using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using UnifiCommands.CommandInfo;

namespace UnifiCommands
{
    public class Utils
    {
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
            out IntPtr piSmallVersion, int amountIcons);

        public static Icon ExtractIcon(string filePath, int iconIndex)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return null;
            }

            try
            {
                if (Path.GetExtension(filePath).ToLower() == ".exe")
                {
                    return Icon.ExtractAssociatedIcon(filePath);
                }

                ExtractIconEx(filePath, iconIndex, out IntPtr large, out IntPtr small, 1);
                return Icon.FromHandle(large);
            }
            catch (Exception)
            {
                // MessageBox.Show($"Extracting icon in {filePath}. \n{e.Message}");
            }

            return null;
        }

        public static string GetMsiInstallerName(string jobUrl)
        {
            if (jobUrl.ToLower().Contains("/dtd/")) return Variables.DtdInstallerName;
            if (jobUrl.ToLower().Contains("/esse/")) return Variables.EsseInstallerName;

            return Variables.ProtectMsiNameByVmArch;
        }

        public static string GetCyUpgradeName(string jobUrl)
        {
            if (jobUrl.ToLower().Contains("esse")) return Variables.EsseUpgradeInstallerName;
            if (!jobUrl.ToLower().Contains("dtd")) return Variables.ProtectUpgradeInstallerName;

            return "";
        }

        public static string GetBootstrapperName(string jobUrl)
        {
            return Variables.ProtectBootstrapperName;
        }

        public static string GetInstallerNameByType(InstallerType installerType, string jobUrl)
        {
            switch (installerType)
            {
                case InstallerType.Msi: return GetMsiInstallerName(jobUrl);
                case InstallerType.CyUpgrade: return GetCyUpgradeName(jobUrl);
                default: return GetBootstrapperName(jobUrl);
            }
        }

        public static bool IsVersion(string version)
        {
            try
            {
                Version.Parse(version);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
