using System;

namespace Commander.Exceptions
{
    public class CommandParameterInvalidException : Exception
    {
        public CommandParameterInvalidException() { }

        public CommandParameterInvalidException(string message) : base(message) { }

        public CommandParameterInvalidException(string message, Exception inner) : base(message, inner) { }
    }
}
