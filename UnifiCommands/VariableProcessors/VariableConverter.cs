using System;

namespace UnifiCommands.VariableProcessors
{
    public abstract class VariableConverter
    {
        protected IVariable VariableIndicator;

        public string ReplaceVariables(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return "";

            propertyName = propertyName.Trim();
            int start = propertyName.IndexOf(VariableIndicator.LeftIndicator, StringComparison.Ordinal);
            while (start >= 0)
            {
                int end = propertyName.IndexOf(VariableIndicator.RightIndicator, start, StringComparison.Ordinal);
                string property = propertyName.Substring(start + VariableIndicator.LeftIndicator.Length, end - start - VariableIndicator.LeftIndicator.Length);
                string variableValue = ReplaceString(property);
                propertyName = propertyName.Replace(VariableIndicator.LeftIndicator + property + VariableIndicator.RightIndicator, variableValue);

                start = propertyName.IndexOf(VariableIndicator.LeftIndicator, StringComparison.Ordinal);
            }

            return propertyName;
        }

        protected virtual string ReplaceString(string propertyName)
        {
            return "";
        }
    }

    public interface IVariable
    {
        string LeftIndicator { get; }
        string RightIndicator { get; }
    }

    public class LoadTimeVariable : IVariable
    {
        public string LeftIndicator => "${";
        public string RightIndicator => "}";
    }

    public class RunTimeVariable : IVariable
    {
        public string LeftIndicator => "$[";
        public string RightIndicator => "]";
    }
}
