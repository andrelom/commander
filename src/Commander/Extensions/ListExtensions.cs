using System.Collections.Generic;

namespace Commander.Extensions
{
    internal static class ListExtensions
    {
        public static T GetValueAt<T>(this List<T> collection, int index)
        {
            return collection.Count >= index ? collection[index] : default;
        }
    }
}
