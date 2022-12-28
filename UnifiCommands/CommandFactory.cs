using System;
using System.Collections.Generic;
using System.Reflection;
using UnifiCommands.VariableProcessors;
using UnifiCommands.Commands;
using UnifiCommands.Logging;
using UnifiCommands.CommandInfo;

namespace UnifiCommands
{
    public class CommandFactory
    {
        public static Command CreateCommand(FullCommandInfo commandInfo, ILogger logger, AppType appType)
        {
            return commandInfo.Type == CommandType.Dos ? CreateDosCommand(commandInfo, logger, appType) : CreateCodeCommand(commandInfo, logger, appType);
        }

        private static FullCommandInfo ReplaceVariables(FullCommandInfo commandInfo, AppType appType)
        {
            FullCommandInfo newCommandInfo = commandInfo.Clone() as FullCommandInfo;
            VariableConverter converter;
            if (appType == AppType.Desktop)
                converter = new DesktopRuntimeVariableConverter(newCommandInfo.VariableValueSource);
            else
                converter = new WebRuntimeVariableConverter(newCommandInfo.VariableValueSource);

            newCommandInfo.Command = converter.ReplaceVariables(newCommandInfo.Command);
            newCommandInfo.Arguments = converter.ReplaceVariables(newCommandInfo.Arguments);

            return newCommandInfo;
        }

        private static Command CreateDosCommand(FullCommandInfo commandInfo, ILogger logger, AppType appType)
        {
            commandInfo = ReplaceVariables(commandInfo, appType);
            return new DosCommand(commandInfo, logger, appType);
        }

        private static Command CreateCodeCommand(FullCommandInfo commandInfo, ILogger logger, AppType appType)
        {
            commandInfo = ReplaceVariables(commandInfo, appType);

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
