using System;

namespace Commander.Exceptions
{
    public class CommandParameterMismatchException : Exception
    {
        public CommandParameterMismatchException() { }

        public CommandParameterMismatchException(string message) : base(message) { }

        public CommandParameterMismatchException(string message, Exception inner) : base(message, inner) { }
    }
}
