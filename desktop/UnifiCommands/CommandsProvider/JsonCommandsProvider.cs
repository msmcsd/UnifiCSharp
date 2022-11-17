using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnifiCommands.Commands;

namespace UnifiCommands.CommandsProvider
{
    public class JsonCommandsProvider : ICommandsProvider
    {
        private readonly CommandInfo.ShowCommandOnMachine _showOnMachine;

        public struct TaskGroup
        {
            public static string AddAmpplPositions = "Rollback-Add AM-PPL";
            public static string RemoveAmpplPositions = "Rollback-Remove AM-PPL";
            public static string UpdateAmpplPositions = "Rollback-Update AM-PPL";
        }

        public List<TestTask> TestTasks { get; set; }

        public List<TestTask> DosTasks { get; set; }

        public List<CommandInfo> TaskBarCommands { get; set; }

        public List<CommandInfo> DownloadCommands { get; set; }

        public List<CommandInfo> AddAmpplRollbackPositions { get; set; }

        public List<CommandInfo> RemoveAmpplRollbackPositions { get; set; }

        public List<CommandInfo> UpdateAmpplRollbackPositions { get; set; }

        /// <summary>
        /// A list of commands, like a function, can be reused in the XML.
        /// The function command is replaced by actual commands when parsing XML.
        /// </summary>
        public List<TestTask> FunctionCommands { get; set; }

        public List<TestTask> BatchTasks { get; set; }

        public JsonCommandsProvider(string configFile, CommandInfo.ShowCommandOnMachine showOnMachine)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException($"File not found. {configFile}.");
            }

            _showOnMachine = showOnMachine;

            LoadTasksFromJson(configFile);
        }

        private void LoadTasksFromJson(string configJsonPath)
        {
            string json = File.ReadAllText(configJsonPath);
            // var c = new JsonStringEnumConverter(); // Allow using of enum names in JSON string instead of enum values.
            // var o = new JsonSerializerOptions();
            // o.Converters.Add(c);
            // TestTasks = JsonSerializer.Deserialize<List<TestTask>>(json, o);
            TestTasks = JsonConvert.DeserializeObject<List<TestTask>>(json, new StringEnumConverter());

            SetVariablesValues(TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.Variable)?.Commands);

            TestTasks = FilterTasks(TestTasks);

            ReplaceLoadTimeVariables();

            DosTasks = TestTasks.Where(t => t.CommandGroup == CommandGroup.Dos).ToList();
            TaskBarCommands = TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.Taskbar)?.Commands;
            DownloadCommands = TestTasks.FirstOrDefault(t => t.CommandGroup == CommandGroup.Download)?.Commands;
            AddAmpplRollbackPositions = TestTasks.FirstOrDefault(t => t.Name == TaskGroup.AddAmpplPositions)?.Commands;
            RemoveAmpplRollbackPositions = TestTasks.FirstOrDefault(t => t.Name == TaskGroup.RemoveAmpplPositions)?.Commands;
            UpdateAmpplRollbackPositions = TestTasks.FirstOrDefault(t => t.Name == TaskGroup.UpdateAmpplPositions)?.Commands;
            BatchTasks = TestTasks.Where(t => t.CommandGroup == CommandGroup.Batch).ToList();

            FunctionCommands = TestTasks.Where(t => t.CommandGroup == CommandGroup.Function).ToList();

            ReplaceFunctionCommands();
        }

        /// <summary>
        /// Filters commands to show according to the the criteria:
        /// 1. Commands are visible
        /// 2. Commands for Dev or Test machines
        /// 3. Commands for platform x64 or x86
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        private List<CommandInfo> FilterCommands(List<CommandInfo> commands)
        {
            string platform = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            return commands.Where(c => c.Visible &&
                                       (c.ShowOnMachine & _showOnMachine) == _showOnMachine &&
                                       (string.IsNullOrEmpty(c.Platform) || c.Platform == platform) &&
                                       c.BatchEnabled).ToList();
        }

        /// <summary>
        /// Filters tasks to show based on criteria:
        /// 1. Tasks for Dev or Test machines.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        private List<TestTask> FilterTasks(List<TestTask> tasks)
        {
            return TestTasks.Where(t => (t.ShowTaskOnMachine & _showOnMachine) == _showOnMachine).ToList();
        }

        /// <summary>
        /// Sets the variables in Variables class with values from JSON.
        /// </summary>
        /// <param name="variableCommands"></param>
        private void SetVariablesValues(List<CommandInfo> variableCommands)
        {
            foreach (var command in variableCommands)
            {
                var property = typeof(Variables).GetProperty(command.Variable, BindingFlags.Public | BindingFlags.Static);
                if (property == null)
                {
                    Debug.Fail($"Variable {command.Variable} not found");
                }

                property?.SetValue(null, command.Value);
            }
        }

        private void ReplaceLoadTimeVariables()
        {
            foreach (var task in TestTasks)
            {
                task.Commands = FilterCommands(task.Commands);

                foreach (var command in task.Commands)
                {
                    command.Command = Variables.ReplaceLoadTimeVariables(command.Command);

                    if (!string.IsNullOrEmpty(command.Arguments))
                        command.Arguments = Variables.ReplaceLoadTimeVariables(command.Arguments);

                    if (!string.IsNullOrEmpty(command.IconSourcePath))
                        command.IconSourcePath = Variables.ReplaceLoadTimeVariables(command.IconSourcePath);

                    if (!string.IsNullOrEmpty(command.DisplayText))
                        command.DisplayText = Variables.ReplaceLoadTimeVariables(command.DisplayText);

                    // if (!string.IsNullOrEmpty(command.DllPath))
                    //     command.DllPath = Variables.ReplaceLoadTimeVariables(command.DllPath);
                }
            }
        }

        /// <summary>
        /// Replaces commands that use Function commands.
        /// </summary>
        private void ReplaceFunctionCommands()
        {
            foreach (var task in TestTasks.Where(t => t.CommandGroup != CommandGroup.Function))
            {
                while (task.Commands.FirstOrDefault(cmd => cmd.Type == CommandInfo.CommandType.Function) != null)
                {
                    var commands = new List<CommandInfo>();
                    bool functionReplaced = false;

                    foreach (var command in task.Commands)
                    {
                        if (command.Type == CommandInfo.CommandType.Function)
                        {
                            var fun = FunctionCommands.FirstOrDefault(f => f.Name == command.Command);
                            if (fun == null) throw new KeyNotFoundException($"Function command {command.Command} not found.");

                            commands.AddRange(fun.Commands);
                            functionReplaced = true;
                        }
                        else
                        {
                            commands.Add(command);
                        }
                    }

                    if (functionReplaced) task.Commands = commands;
                }
            }
        }
    }
}
