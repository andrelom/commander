using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Commander.Exceptions;
using Commander.Extensions;

namespace Commander
{
    internal class CommandParameterBuilder
    {
        private readonly Command _command;

        private readonly IList<object> _parameters;

        public CommandParameterBuilder(Command command)
        {
            _command = command;
            _parameters = new List<object>();
        }

        public void TryAddValue(string input)
        {
            var arguments = GetInputArguments(input);
            var parameters = GetMethodParameters();

            if (arguments.Count != parameters.Count)
            {
                throw new CommandParameterMismatchException();
            }

            foreach (var argument in arguments)
            {
                var index = arguments.IndexOf(argument);
                var parameter = parameters.GetValueAt(index);

                try
                {
                    _parameters.Add(Convert.ChangeType(argument, parameter.ParameterType));
                }
                catch (FormatException ex)
                {
                    throw new CommandParameterInvalidException($"Could not cast '{input}' parameter", ex);
                }
            }
        }

        public void TryAddOptions(string input)
        {
            // TODO: Add options to the command.
        }

        public object[] Build()
        {
            return _parameters.ToArray();
        }

        #region Private Methods

        private string GetInputValue(string input)
        {
            return Regex.Replace(input, @"\s\-.*", "")
                .Replace(_command.Name, "")
                .Trim();
        }

        private List<string> GetInputArguments(string input)
        {
            return Regex.Matches(GetInputValue(input), "(\"(.*?)\")|([^\\s]+)")
                .Where(match => match != null)
                .Select(match => Regex.Replace(match.Value, "^\"|\"$", ""))
                .ToList();
        }

        private List<ParameterInfo> GetMethodParameters()
        {
            return _command.Method.GetParameters().ToList();
        }

        #endregion
    }
}
