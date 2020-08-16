using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Runtime
{
    public static class ListExtensions
    {
        public static T	Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        
        public static List<T> ChangeEach<T>(this List<T> list, Func<T, T> mutator)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] = mutator(list[i]);
            }
            return list;
        }
        
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        
        public static IList<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        
        public static void Shuffle<T>(this IList<T> list)
        {
            var count = list.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var index = UnityEngine.Random.Range(i, count);
                var temp = list[i];
                list[i] = list[index];
                list[index] = temp;
            }
        }
        
        public static void Swap<T>(this IList<T> list, int target, int source)
        {
            var temp = list[target];
            list[target] = list[source];
            list[source] = temp;
        }
        
        public static T DefaultGet<T>(this List<T> list, int key) where T : class, new()
        {
            return list.DefaultGet(key, () => new T());
        }
        
        public static T DefaultGet<T>(this List<T> list, int key, Func<T> newInstance) where T : class
        {
            if (key < 0)
            {
                throw new IndexOutOfRangeException("Key was " + key);
            }

            // Extend the list to fit the requested index
            while (key >= list.Count)
            {
                list.Add(null);
            }

            // Return the key if its not null
            var instance = list[key];
            if (instance != null)
            {
                return instance;
            }

            // Otherwise, put a new instance at the index
            instance = newInstance();
            list[key] = instance;
            return instance;
        }
    }
}