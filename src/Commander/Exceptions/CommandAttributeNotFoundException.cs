using System;

namespace Commander.Exceptions
{
    public class CommandAttributeNotFoundException : Exception
    {
        public CommandAttributeNotFoundException() { }

        public CommandAttributeNotFoundException(string message) : base(message)  { }

        public CommandAttributeNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
