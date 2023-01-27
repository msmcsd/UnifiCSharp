using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using UnifiCommands;
using UnifiCommands.CommandExecutors;
using UnifiCommands.CommandInfo;
using UnifiCommands.CommandsProvider;
using UnifiCommands.Logging;

namespace SelfHostUnifiApi.RestCommands
{
    /// <summary>
    /// Base class for rest commands.
    /// </summary>
    internal abstract class WebCommand
    {
        private readonly string _taskName;
        private readonly string _displayText;
        private string _parameters;

        protected readonly ICommandsProvider CommandsProvider;
        protected ILogger logger;
        protected FullCommandInfo command;
        //protected dynamic variables;
        protected UiSettings variables;

        protected WebCommand(ICommandsProvider commandsProvider, string taskName, string displayText): this (commandsProvider, taskName, displayText, null)
        {
        }

        protected WebCommand(ICommandsProvider commandsProvider, string taskName, string displayText, string parameters)
        {
            CommandsProvider = commandsProvider;
            _taskName = taskName;
            _displayText = displayText;
            _parameters = parameters;
        }

        protected virtual bool ConvertParameters(out UiSettings variables, out string result)
        {
            result = "";
            variables = null;

            if (string.IsNullOrEmpty(_parameters)) return false;

            //_parameters = _parameters.Replace("\\\"", "\"");
            //_parameters = _parameters.Replace("\\\\", "\\");
            //if (_parameters.EndsWith("\"")) _parameters = _parameters.Substring(0, _parameters.Length - 1);
            //if (_parameters.StartsWith("\"")) _parameters = _parameters.Substring(1);

            //var expConverter = new ExpandoObjectConverter();
            try
            {
                //variables = JsonConvert.DeserializeObject<ExpandoObject>(_parameters, expConverter);
                variables = JsonConvert.DeserializeObject<UiSettings>(_parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = "{\"result\": \"" + e.Message + "\"}";
                return false;
            }

            return true;
        }

        public static UiSettings ConvertJsonToUiSettings(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;

            json = json.Replace("\\\"", "\"");
            json = json.Replace("\\\\", "\\");
            if (json.EndsWith("\"")) json = json.Substring(0, json.Length - 1);
            if (json.StartsWith("\"")) json = json.Substring(1);

            return JsonConvert.DeserializeObject<UiSettings>(json);
        }

        protected virtual async Task<string> ExecuteCommand()
        {
            return "";
        }

        protected virtual bool FindCommand(out string result)
        {
            result = "";
            command = CommandsProvider.FindCommand(_taskName, _displayText);
            if (command == null)
            {
                result = "{\"result\": \"Command not found\"}";
                return false;
            }

            return true;
        }

        protected virtual void SetVariableValueSource()
        {
            command.VariableValueSource = variables;
        }

        public virtual async Task<string> Execute()
        {
            string result;
            if (!ConvertParameters(out variables, out result))
            {
                return result;
            }

            if (!FindCommand(out result))
            {
                return result;
            }

            AutoResetEvent ev = new AutoResetEvent(false); // Ensure socket server is connected before running commands.
            logger = new WebLogger(ev);
            ev.WaitOne(5000);

            SetVariableValueSource();

            string msg = "Command finished running";
            string s = await ExecuteCommand();
            if (!string.IsNullOrEmpty(s)) msg = s;

            // TODO: Might need this. A client might still connects to socker server and receives broadcasts after command finishes.
            // Currently commented so the last line of log from command shows in the log. "[Dos] Finished".
            (logger as IDisposable).Dispose();

            return "{\"result\": \"" + msg + "\"}";
        }

        public static async Task RunCommands(List<FullCommandInfo> commands, bool checkReturnValue, object uiObserver, ILogger logger)
        {
            var b = new BatchCommandExecutor(commands, false, uiObserver, logger, AppType.Web);
            //b.RegisterObserver(observer);
            await b.Execute();
        }
    }


}
