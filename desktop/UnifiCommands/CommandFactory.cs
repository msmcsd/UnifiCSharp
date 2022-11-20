using System;
using System.Collections.Generic;
using System.Reflection;
using UnifiCommands.VariableProcessors;
using UnifiCommands.Commands;
using UnifiCommands.Logging;

namespace UnifiCommands
{
    public class CommandFactory
    {
        private static CommandInfo ReplaceVariables(CommandInfo commandInfo, object mainForm, AppType appType)
        {
            CommandInfo newCommandInfo = commandInfo.Clone() as CommandInfo;
            VariableConverter converter;
            if (appType == AppType.Desktop)
                converter = new DesktopRuntimeVariableConverter(mainForm);
            else
                converter = new WebRuntimeVariableConverter(null);

            newCommandInfo.Command = converter.ReplaceVariables(newCommandInfo.Command);
            newCommandInfo.Arguments = converter.ReplaceVariables(newCommandInfo.Arguments);

            return newCommandInfo;
        }

        public static Command CreateCommand(CommandInfo commandInfo, ILogger logger, object mainForm, AppType appType)
        {
            return commandInfo.Type == CommandInfo.CommandType.Dos ? CreateDosCommand(commandInfo, logger, mainForm, appType) : CreateCodeCommand(commandInfo, logger, mainForm, appType);
        }

        private static Command CreateDosCommand(CommandInfo commandInfo, ILogger logger, object mainForm, AppType appType)
        {
            commandInfo = ReplaceVariables(commandInfo, mainForm, appType);
            return new DosCommand(commandInfo, logger);
        }

        private static Command CreateCodeCommand(CommandInfo commandInfo, ILogger logger, object mainForm, AppType appType)
        {
            commandInfo = ReplaceVariables(commandInfo, mainForm, appType);

            string typeName = $"UnifiCommands.Commands.CodeCommands.{commandInfo.Command}Command, UnifiCommands";
            Type t = Type.GetType(typeName);

            if (t == null)
            {
                logger.LogError($"Unable to find type {typeName}");
                return null;
            }

            // Assuming all code commands have one constructor.
            ParameterInfo[] ctorInfo = t.GetConstructors()[0].GetParameters();

            // Constructor parameters provided in Json
            string[] args = null;
            if (!string.IsNullOrEmpty(commandInfo.Arguments))
            {
                args = commandInfo.Arguments.Split(',');
            }

            List<object> parameters = new List<object>();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    // string arg = Variables.ReplaceRunTimeVariables(args[i], mainForm);
                    string arg = args[i].Trim();

                    // Convert the argument from Json to match the type of parameter in constructor.
                    if (ctorInfo[i].ParameterType == typeof(bool))
                        parameters.Add(Convert.ToBoolean(arg));
                    else if (ctorInfo[i].ParameterType == typeof(int))
                        parameters.Add(Convert.ToInt32(arg));
                    else
                        parameters.Add(arg);
                }
            }

            parameters.Add(logger);

            return (Command)Activator.CreateInstance(t, parameters.ToArray());
        }
    }
}
