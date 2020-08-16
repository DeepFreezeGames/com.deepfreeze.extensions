using System;

namespace Extensions.Runtime
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] list)
        {
            return list[UnityEngine.Random.Range(0, list.Length)];
        }
        
        public static T[] ChangeEach<T>(this T[] array, Func<T, T> mutator)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = mutator(array[i]);
            }
            return array;
        }
    }
}