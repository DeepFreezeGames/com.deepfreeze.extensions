using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions.Runtime
{
    public static class EnumerableExtensions
    {
        public static string PrettyString<T>(this IEnumerable<T> enumerable, Func<T, string> getter)
        {
            var builder = new StringBuilder();

            if (enumerable == null || !enumerable.Any())
            {
                return "EMPTY";
            }

            foreach (var part in enumerable)
            {
                builder.Append(getter(part));
                builder.Append(", ");
            }

            builder.Remove(builder.Length - 2, 2);

            return builder.ToString();
        }

        public static List<T> RemoveDuplicates<T>(this IEnumerable<T> input) where T : class
        {
            var output = new List<T>();
            foreach (var item in input)
            {
                if (output.Contains(item))
                {
                    continue;
                }
                
                output.Add(item);
            }

            return output;
        }
        
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentException("Enumerable was null!");

            var count = enumerable.Count();
            if (count == 0)
                throw new IndexOutOfRangeException("Collection of length 0 provided!");

            var index = UnityEngine.Random.Range(0, count);
            return enumerable.ElementAt(index);
        }
    }
}