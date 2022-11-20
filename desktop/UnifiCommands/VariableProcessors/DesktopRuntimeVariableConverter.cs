using System.Reflection;

namespace UnifiCommands.VariableProcessors
{
    /// <summary>
    /// Values of runtime variables are from the functions, which get certain values from UI, in the main desktop form.
    /// </summary>
    public class DesktopRuntimeVariableConverter : VariableConverter
    {
        private readonly object _formObject;

        public DesktopRuntimeVariableConverter(object formObject)
        {
            _formObject = formObject;
            VariableIndicator = new RunTimeVariable();
        }

        protected override string ReplaceString(string propertyName)
        {
            return (string)_formObject.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).GetValue(_formObject);
        }
    }
}
