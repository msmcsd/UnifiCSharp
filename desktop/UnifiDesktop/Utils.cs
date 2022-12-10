using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using UnifiCommands;
using UnifiCommands.CommandsProvider;

namespace Unifi
{
    internal class Utils
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
