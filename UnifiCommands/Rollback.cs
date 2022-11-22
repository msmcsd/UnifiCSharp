using System.Collections.Generic;
using UnifiCommands.CommandInfo;
using UnifiCommands.Commands;

namespace UnifiCommands
{
    public class Rollback
    {
        public struct RollbackCategoryName
        {
            public static string RemoveAmppl = "Remove-AMPPL";
            public static string UpdateAmppl = "Update-AMPPL";
            public static string AddAmppl = "Add-AMPPL";
            public static string None = "None";
        }

        public static Dictionary<string, List<FullCommandInfo>> RollbackPositionsList { get; set; }
    }
}