using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.Utilities
{
    internal static class AssemblyUtility
    {
        public static IEnumerable<Type> GetControllerTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && !type.IsAbstract && !type.IsGenericType && !type.IsNested)
                .Where(type => type.IsSubclassOf(typeof(Controller)));
        }
    }
}
