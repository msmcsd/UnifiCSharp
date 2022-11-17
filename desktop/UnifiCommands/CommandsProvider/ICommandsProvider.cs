using System.Collections.Generic;
using UnifiCommands.Commands;

namespace UnifiCommands.CommandsProvider
{
    public interface ICommandsProvider
    {
        List<TestTask> DosTasks { get; set; }

        List<CommandInfo> TaskBarCommands { get; set; }

        List<CommandInfo> DownloadCommands { get; set; }

        List<CommandInfo> AddAmpplRollbackPositions { get; set; }

        List<CommandInfo> RemoveAmpplRollbackPositions { get; set; }

        List<CommandInfo> UpdateAmpplRollbackPositions { get; set; }

        List<TestTask> FunctionCommands { get; set; }

        List<TestTask> BatchTasks { get; set; }

        List<TestTask> TestTasks { get; set; }
    }
}