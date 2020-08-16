using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions.Runtime
{
    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 v, float x)
        {
            v.x = x;
            return v;
        }
            
        public static Vector3 SetY(this Vector3 v, float y)
        {
            v.y = y;
            return v;
        }
        
        public static Vector3 SetZ(this Vector3 v, float z)
        {
            v.z = z;
            return v;
        }

        #region ADDITION
        public static Vector3 Add(this Vector3 v, float o)
        {
            return new Vector3(v.x + o, v.y + o, v.z + o);
        }
        public static void Add(this Vector3 v, Vector2 o, ref Vector3 result)
        {
            result.x = v.x + o.x;
            result.y = v.y + o.y;
            result.z = v.z;
        }
        public static void Add(this Vector3 v, Vector3 o, ref Vector3 result)
        {
            result.x = v.x + o.x;
            result.y = v.y + o.y;
            result.z = v.z + o.z;
        }

        public static Vector3Int AddToInt(this Vector3 v, Vector3Int o)
        {
            return new Vector3Int((int)(v.x + o.x), (int)(v.y + o.y), (int)(v.z + o.z));
        }

        public static Vector3Int AddToInt(this Vector3 v, Vector2Int o)
        {
            return new Vector3Int((int)(v.x + o.x), (int)(v.y + o.y), (int)(v.z));
        }

        public static Vector3 Add(this Vector3 v, Vector2Int o)
        {
            return new Vector3(v.x + o.x, v.y + o.y, v.z);
        }

        public static Vector3 Add(this Vector3 v, Vector3Int o)
        {
            return new Vector3(v.x + o.x, v.y + o.y, v.z + o.z);
        }

        public static Vector3 Add(this Vector3 v, Vector2 o)
        {
            return new Vector3(v.x + o.x, v.y + o.y, v.z);
        }
        #endregion

        #region SUBTRACTION
        public static Vector3 Minus(this Vector3 v, float o)
        {
            return new Vector3(v.x - o, v.y - o, v.z - o);
        }
        public static Vector3 Minus(this Vector3 v, Vector2 o)
        {
            return new Vector3(v.x - o.x, v.y - o.y, v.z);
        }
        public static Vector3 Minus(this Vector3 v, Vector3 o)
        {
            return new Vector3(v.x - o.x, v.y - o.y, v.z - o.z);
        }

        public static Vector3Int MinusToInt(this Vector3 v, Vector3Int o)
        {
            return new Vector3Int((int)(v.x - o.x), (int)(v.y - o.y), (int)(v.z - o.z));
        }

        public static Vector3Int MinusToInt(this Vector3 v, Vector2Int o)
        {
            return new Vector3Int((int)(v.x - o.x), (int)(v.y - o.y), (int)(v.z));
        }

        public static Vector3 Minus(this Vector3 v, Vector2Int o)
        {
            return new Vector3(v.x - o.x, v.y - o.y, v.z);
        }

        public static Vector3 Minus(this Vector3 v, Vector3Int o)
        {
            return new Vector3(v.x - o.x, v.y - o.y, v.z - o.z);
        }
        #endregion
        
        #region CONVERSION
        public static Vector3Int ToInt(this Vector3 v)
        {
            return new Vector3Int((int)v.x, (int)v.y, (int)v.z);
        }

        public static Vector2 ToVector2XY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
        public static Vector2 ToVector2XZ(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }
        public static Vector2 ToVector2YZ(this Vector3 v)
        {
            return new Vector2(v.y, v.z);
        }
        #endregion

        #region MULTIPLICATION
        public static Vector3Int MultiplyToInt(this Vector3 v, Vector3Int o)
        {
            return new Vector3Int((int)(v.x * o.x), (int)(v.y * o.y), (int)(v.z * o.z));
        }

        public static Vector3Int MultiplyToInt(this Vector3 v, Vector2Int o)
        {
            return new Vector3Int((int)(v.x * o.x), (int)(v.y * o.y), (int)(v.z));
        }

        public static Vector3 Multiply(this Vector3 v, float o)
        {
            return new Vector3(v.x * o, v.y * o, v.z * o);
        }
        public static Vector3 Multiply(this Vector3 v, Vector3Int o)
        {
            return new Vector3(v.x * o.x, v.y * o.y, v.z * o.z);
        }

        public static Vector3 Multiply(this Vector3 v, Vector2Int o)
        {
            return new Vector3(v.x * o.x, v.y * o.y, v.z);
        }

        public static Vector3 Multiply(this Vector3 v, Vector3 o)
        {
            return new Vector3(v.x * o.x, v.y * o.y, v.z * o.z);
        }

        public static void Multiply(this Vector3 v, Vector3 o, ref Vector3 result)
        {
            result.x = v.x * o.x;
            result.y = v.y * o.y;
            result.z = v.z * o.z;
        }
        #endregion

        #region DIVISION
        public static Vector3Int DivideToInt(this Vector3 v, Vector3Int o)
        {
            return new Vector3Int((int)(v.x / o.x), (int)(v.y / o.y), (int)(v.z / o.z));
        }

        public static Vector3Int DivideToInt(this Vector3 v, Vector2Int o)
        {
            return new Vector3Int((int)(v.x / o.x), (int)(v.y / o.y), (int)(v.z));
        }

        public static Vector3 Divide(this Vector3 v, float o)
        {
            return new Vector3(v.x / o, v.y / o, v.z / o);
        }
        public static Vector3 Divide(this Vector3 v, Vector3Int o)
        {
            return new Vector3(v.x / o.x, v.y / o.y, v.z / o.z);
        }

        public static Vector3 Divide(this Vector3 v, Vector2Int o)
        {
            return new Vector3(v.x / o.x, v.y / o.y, v.z);
        }

        public static Vector3 Divide(this Vector3 v, Vector3 o)
        {
            return new Vector3(v.x / o.x, v.y / o.y, v.z / o.z);
        }

        public static void Divide(this Vector3 v, Vector3 o, ref Vector3 result)
        {
            result.x = v.x / o.x;
            result.y = v.y / o.y;
            result.z = v.z * o.z;
        }
        #endregion
        
        public static Vector3 Between(this Vector3 v, Vector3 to, float percent)
        {
            return v + (to - v) * percent;
        }

        #region Math
        public static Vector3 Randomize(this Vector3 v, Vector2 randomRangeOffset)
        {
            v.x += randomRangeOffset.Random();
            v.y += randomRangeOffset.Random();
            v.z += randomRangeOffset.Random();
            return v;
        }
        #endregion

        public static int NearCompareTo(this Vector3 a, Vector3 b)
        {
            return NearComparer.Instance.Compare(a, b);
        }

        public class NearComparer : IComparer<Vector3>
        {
            public static readonly NearComparer Instance = new NearComparer();
            public int Compare(Vector3 v, Vector3 o)
            {
                int x = NearComparerByX.Instance.Compare(v, o);
                int y = NearComparerByY.Instance.Compare(v, o);
                int z = NearComparerByZ.Instance.Compare(v, o);

                if (x != 0) return x;
                if (y != 0) return y;
                if (z != 0) return z;
                return 0;
            }
        }
        public class NearComparerByX : IComparer<Vector3>
        {
            public static readonly NearComparerByX Instance = new NearComparerByX();
            public int Compare(Vector3 v, Vector3 o)
            {
                return v.x.NearCompareTo(o.x);
            }
        }
        public class NearComparerByY : IComparer<Vector3>
        {
            public static readonly NearComparerByY Instance = new NearComparerByY();
            public int Compare(Vector3 v, Vector3 o)
            {
                return v.y.NearCompareTo(o.y);
            }
        }
        public class NearComparerByZ : IComparer<Vector3>
        {
            public static readonly NearComparerByZ Instance = new NearComparerByZ();
            public int Compare(Vector3 v, Vector3 o)
            {
                return v.z.NearCompareTo(o.z);
            }
        }

        public class NearEqualityComparer : IEqualityComparer<Vector3>
        {
            public const int RoundDigits = 3;
            public static readonly NearEqualityComparer Instance = new NearEqualityComparer();

            public bool Equals(Vector3 v, Vector3 o)
            {
                return NearComparer.Instance.Compare(v, o) == 0;
            }

            public int GetHashCode(Vector3 obj)
            {
                return (int)(Math.Round(obj.x, RoundDigits) * 1000) +
                    (int)(Math.Round(obj.y, RoundDigits) * 1000) +
                    (int)(Math.Round(obj.z, RoundDigits) * 1000);
            }
        }

        public static Vector3 Invert(this Vector3 vector3)
        {
            return new Vector3(
                1f/vector3.x, 
                1f/vector3.y,
                1f/vector3.z);
        }
        
        public static Vector3 Project(this Vector3 vector, Vector3 projectedVector)
        {
            var dot = Vector3.Dot(vector, projectedVector);
            return dot * projectedVector;
        }

        public static Vector3 Reject(this Vector3 vector, Vector3 rejectedVector)
        {
            return vector - vector.Project(rejectedVector);
        }
        
        public static bool TryParse(string rawString, out Vector3 vector3)
        {
            vector3 = Vector3.zero;
            var shards = rawString.Split(',');
            if (!float.TryParse(shards[0].Trim(), out var xValue))
                return false;
            if (!float.TryParse(shards[1].Trim(), out var yValue))
                return false;
            if (!float.TryParse(shards[2].Trim(), out var zValue))
                return false;

            vector3 = new Vector3(xValue, yValue, zValue);
            return true;
        }
    }
}
