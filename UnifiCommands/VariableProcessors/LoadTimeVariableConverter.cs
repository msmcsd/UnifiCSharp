using System.Reflection;

namespace UnifiCommands.VariableProcessors
{
    public class LoadTimeVariableConverter : VariableConverter
    {
        public LoadTimeVariableConverter()
        {
            VariableIndicator = new LoadTimeVariable();
        }

        protected override string ReplaceString(string propertyName)
        {
            return (string)typeof(Variables).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static).GetValue(null);
        }
    }
}
