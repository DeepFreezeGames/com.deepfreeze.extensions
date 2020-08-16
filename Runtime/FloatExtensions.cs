using System;
using System.Collections.Generic;

namespace Extensions.Runtime
{
    public static class FloatExtensions
    {
        private const float Epsilon = 0.0001f;
        
        public static int NearCompareTo(this float a, float b)
        {
            float diff = a - b;
            if (Math.Abs(diff) < Epsilon) return 0;
            if (a < b) return -1;
            return 1;
        }

        public class NearComparer : IComparer<float>
        {
            public static readonly NearComparer Instance = new NearComparer();
            public int Compare(float x, float y)
            {
                return x.NearCompareTo(y);
            }
        }

        public class NearEqualityComparer : IEqualityComparer<float>
        {
            private const int RoundDigits = 3;
            public static readonly NearEqualityComparer Instance = new NearEqualityComparer();

            public bool Equals(float x, float y)
            {
                return NearCompareTo(x, y) == 0;
            }

            public int GetHashCode(float obj)
            {
                return (int) (Math.Round(obj, RoundDigits) * 1000);
            }
        }
    }
}