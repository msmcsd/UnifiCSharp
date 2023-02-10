using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnifiCommands.CommandInfo;
using UnifiCommands.VariableProcessors;

namespace UnifiCommands.CommandsProvider
{
    public class JsonCommandsProvider : ICommandsProvider
    {
        private ShowCommandOnMachine _showOnMachine;

        public struct TaskGroup
        {
            public static string AddAmpplPositions = "Rollback-Add AM-PPL";
            public static string RemoveAmpplPositions = "Rollback-Remove AM-PPL";
            public static string UpdateAmpplPositions = "Rollback-Update AM-PPL";
        }

        public List<TestTask> TestTasks { get; set; }
        
        public List<WebTestTask> WebTestTasks { get; set; }

        public List<TestTask> DosTasks { get; set; }

        public List<FullCommandInfo> TaskBarCommands { get; set; }

        public List<FullCommandInfo> DownloadCommands { get; set; }

        public List<FullCommandInfo> AddAmpplRollbackPositions { get; set; }

        public List<FullCommandInfo> RemoveAmpplRollbackPositions { get; set; }

        public List<FullCommandInfo> UpdateAmpplRollbackPositions { get; set; }

        /// <summary>
        /// A list of commands, like a function, can be reused in the XML.
        /// The function command is replaced by actual commands when parsing XML.
        /// </summary>
        public List<TestTask> FunctionCommands { get; set; }

        public List<TestTask> BatchTasks { get; set; }

        private readonly object _variableValueSource;

        private readonly AppType _appType;

        public JsonCommandsProvider()
        {
            _appType = AppType.Web;
            
            ConvertJsonToCommands();
        }

        public JsonCommandsProvider(object variableValueSource)
        {
            _appType = AppType.Desktop;
            _variableValueSource = variableValueSource;
            
            ConvertJsonToCommands();
        }

        private void ConvertJsonToCommands()
        {
            string configFile = Variables.LocalJsonConfigPath;
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException($"File not found. {configFile}.");
            }

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
            // _showOnMachine depends on result from previous line.
            _showOnMachine = BaseCommandInfo.GetShowCommandOnMachine();

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

            if (_appType == AppType.Web)
            {
                CreateWebTasks();
            }
        }

        /// <summary>
        /// Instantiate WebTestTasks object which use WebCommandInfo as Command. This object contains less info
        /// than TestTasks so less info is sent back to web client from server.
        /// </summary>
        private void CreateWebTasks()
        {
            WebTestTasks = new List<WebTestTask>();

            foreach(var task in TestTasks.Where(t => t.UsedInWeb))
            {
                var webtask = new WebTestTask
                {
                    Name = task.Name,
                    CommandGroup = task.CommandGroup
                };

                if (task.CommandGroup != CommandGroup.Install)
                {
                    webtask.Commands = new List<BaseCommandInfo>();

                    foreach (var command in task.Commands)
                    {
                        webtask.Commands.Add(command.CreateBaseCommand());
                    }
                }

                WebTestTasks.Add(webtask);
            }
        }

        /// <summary>
        /// Filters commands to show according to the the criteria:
        /// 1. Commands are visible
        /// 2. Commands for Dev or Test machines
        /// 3. Commands for platform x64 or x86
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        private List<FullCommandInfo> FilterCommands(List<FullCommandInfo> commands)
        {
            string platform = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            return commands.Where(c => c.Visible &&
                                       //(c.ShowOnMachine & _showOnMachine) == _showOnMachine &&
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
            //return TestTasks.Where(t => (t.ShowTaskOnMachine & _showOnMachine) == _showOnMachine).ToList();
            return tasks;
        }

        /// <summary>
        /// Sets the variables in Variables class with values from JSON.
        /// </summary>
        /// <param name="variableCommands"></param>
        private void SetVariablesValues(List<FullCommandInfo> variableCommands)
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
            VariableConverter converter = new LoadTimeVariableConverter();

            foreach (var task in TestTasks)
            {
                task.Commands = FilterCommands(task.Commands);

                foreach (var command in task.Commands)
                {
                    command.Command = converter.ReplaceVariables(command.Command);
                    command.VariableValueSource = _variableValueSource;

                    if (!string.IsNullOrEmpty(command.Arguments))
                        command.Arguments = converter.ReplaceVariables(command.Arguments);

                    if (!string.IsNullOrEmpty(command.IconSourcePath))
                        command.IconSourcePath = converter.ReplaceVariables(command.IconSourcePath);

                    if (!string.IsNullOrEmpty(command.DisplayText))
                        command.DisplayText = converter.ReplaceVariables(command.DisplayText);

                    // if (!string.IsNullOrEmpty(command.DllPath))
                    //     command.DllPath = converter.ReplaceVariable(command.DllPath);
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
                while (task.Commands.FirstOrDefault(cmd => cmd.Type == CommandType.Function) != null)
                {
                    var commands = new List<FullCommandInfo>();
                    bool functionReplaced = false;

                    foreach (var command in task.Commands)
                    {
                        if (command.Type == CommandType.Function)
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

        public FullCommandInfo FindCommand(string commandGroup, string displayText)
        {
            FullCommandInfo command = TestTasks.FirstOrDefault(t => t.Name.Equals(commandGroup, StringComparison.InvariantCultureIgnoreCase))
                                     .Commands?.FirstOrDefault(c => c.DisplayText.Equals(displayText, StringComparison.InvariantCultureIgnoreCase));

            return command == null ? null : (FullCommandInfo)command.Clone();
        }

        public TestTask FindTask(string taskName)
        {
            TestTask task = TestTasks.FirstOrDefault(t => t.Name.Equals(taskName, StringComparison.InvariantCultureIgnoreCase));

            return task;
        }
    }
}
