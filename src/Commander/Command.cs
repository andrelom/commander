using System;
using System.Reflection;
using Commander.Attributes;
using Commander.Exceptions;

namespace Commander
{
    internal class Command
    {
        public Command(Type type, MethodInfo method)
        {
            Name = $"{GetCommandName(type)} {GetCommandName(method)}";
            Type = type;
            Method = method;
        }

        public string Name { get; }

        public Type Type { get; }

        public MethodInfo Method { get; }

        #region Private Methods

        private string GetCommandName(MemberInfo member)
        {
            if (member.GetCustomAttribute(typeof(CommandAttribute)) is CommandAttribute attribute)
            {
                return attribute.Name.Trim();
            }

            throw new CommandAttributeNotFoundException($"Command attribute not set for {member.Name}");
        }

        #endregion
    }
}
