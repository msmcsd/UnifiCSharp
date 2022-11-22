using System.Collections.Generic;
using UnifiCommands.CommandInfo;

namespace UnifiCommands.CommandsProvider
{
    public interface ICommandsProvider
    {
        List<TestTask> DosTasks { get; set; }

        List<FullCommandInfo> TaskBarCommands { get; set; }

        List<FullCommandInfo> DownloadCommands { get; set; }

        List<FullCommandInfo> AddAmpplRollbackPositions { get; set; }

        List<FullCommandInfo> RemoveAmpplRollbackPositions { get; set; }

        List<FullCommandInfo> UpdateAmpplRollbackPositions { get; set; }

        List<TestTask> FunctionCommands { get; set; }

        List<TestTask> BatchTasks { get; set; }

        List<TestTask> TestTasks { get; set; }
    }
}