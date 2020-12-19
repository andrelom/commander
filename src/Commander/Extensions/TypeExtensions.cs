using System;

namespace Commander.Extensions
{
    internal static class TypeExtensions
    {
        public static bool IsLike<T>(this Type type)
        {
            var tType = typeof(T);

            return type == tType || type?.BaseType == tType;
        }
    }
}
