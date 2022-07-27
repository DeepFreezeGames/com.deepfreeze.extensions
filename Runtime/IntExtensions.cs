﻿namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return !value.IsEven();
        }
    }
}