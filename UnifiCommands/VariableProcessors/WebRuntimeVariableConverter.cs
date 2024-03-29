﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnifiCommands.VariableProcessors
{
    /// <summary>
    /// Runtime variables and their values are store in an ExpandoObject, which is a dictionary.
    /// </summary>
    public class WebRuntimeVariableConverter : VariableConverter
    {
        //private readonly IDictionary<string, object> _variables;
        private readonly object _variables;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="variables">Expect to be an ExpandoObject object</param>
        /// <exception cref="ArgumentException"></exception>
        public WebRuntimeVariableConverter(object variables)
        {
            //if (variables.GetType() != typeof(IDictionary<string, object>)) throw new ArgumentException($"Incorrect argument type: {nameof(variables)}");

            //_variables = (IDictionary<string, object>)variables;
            _variables = variables;
            VariableIndicator = new RunTimeVariable();
        }

        protected override string ReplaceString(string propertyName)
        {
            //var p = _variables.FirstOrDefault(kvp => kvp.Key.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
            //return p.Equals(default(KeyValuePair<string, object>)) ? "" : p.Value.ToString();
            string p = (string)_variables.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static).GetValue(null);
            return p;
        }
    }
}
