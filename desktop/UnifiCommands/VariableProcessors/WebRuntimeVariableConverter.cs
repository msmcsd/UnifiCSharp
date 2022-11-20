﻿using System;
using System.Collections.Generic;

namespace UnifiCommands.VariableProcessors
{
    /// <summary>
    /// Runtime variables and their values are store in an ExpandoObject, which is a dictionary.
    /// </summary>
    public class WebRuntimeVariableConverter : VariableConverter
    {
        private readonly IDictionary<string, object> _variables;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="variables">Expect to be an ExpandoObject object</param>
        /// <exception cref="ArgumentException"></exception>
        public WebRuntimeVariableConverter(object variables)
        {
            if (variables.GetType() != typeof(IDictionary<string, object>)) throw new ArgumentException($"Incorrect argument type: {nameof(variables)}");

            _variables = (IDictionary<string, object>)variables;
        }

        protected override string ReplaceString(string propertyName)
        {
            if (_variables.TryGetValue(propertyName, out var value))
                return (string)value;

            return "";
        }
    }
}