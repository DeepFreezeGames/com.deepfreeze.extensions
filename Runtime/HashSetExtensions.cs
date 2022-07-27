using System.Collections.Generic;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class HashSetExtensions
    {
        public static T GetRandom<T>(this HashSet<T> hashSet)
        {
            var index = UnityEngine.Random.Range(0, hashSet.Count);
            var iterator = hashSet.GetEnumerator();
            iterator.MoveNext();
            for (var i = 0; i < index; i++)
            {
                iterator.MoveNext();
            }
            
            return iterator.Current;
        }

        public static HashSet<T> Clone<T>(this HashSet<T> hashSet)
        {
            var newHashSet = new HashSet<T>();
            newHashSet.UnionWith(hashSet);
            return newHashSet;
        }
    }
}