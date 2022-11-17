using System.Collections.Generic;
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

        public static Dictionary<string, List<CommandInfo>> RollbackPositionsList { get; set; }
    }
}