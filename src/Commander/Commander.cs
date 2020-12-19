using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Commander.Attributes;
using Commander.Exceptions;
using Commander.Extensions;
using Commander.Utilities;

namespace Commander
{
    internal class Commander : ICommander
    {
        private readonly IList<Command> _commands = GenerateCommands();

        private readonly IServiceProvider _services;

        public Commander(IServiceProvider services)
        {
            _services = services;
        }

        public async Task InvokeAsync(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (FindCommand(input) is var command && command == null)
            {
                throw new CommandNotFoundException();
            }

            var instance = _services.GetService(command.Type);
            var builder = new CommandParameterBuilder(command);

            builder.TryAddValue(input);
            builder.TryAddOptions(input);

            await InvokeAsync(command, builder, instance);
        }

        #region Private Methods

        private async Task InvokeAsync(Command command, CommandParameterBuilder builder, object instance)
        {
            if (!command.Method.ReturnType.IsLike<Task>())
            {
                command.Method.Invoke(instance, builder.Build());
            }
            else if (command.Method.Invoke(instance, builder.Build()) is Task task)
            {
                await task;
            }
        }

        private Command FindCommand(string input)
        {
            return _commands.FirstOrDefault(command => input.Equals(command.Name) ||
                                                       input.StartsWith($"{command.Name} "));
        }

        private static IList<Command> GenerateCommands()
        {
            var commands = new List<Command>();
            var controllers = AssemblyUtility.GetControllerTypes();

            foreach (var controller in controllers)
            {
                foreach (var method in controller.GetMethods())
                {
                    if (method.GetCustomAttribute(typeof(CommandAttribute)) is CommandAttribute)
                    {
                        commands.Add(new Command(controller, method));
                    }
                }
            }

            return commands.OrderBy(command => command.Name).ToList();
        }

        #endregion
    }
}
