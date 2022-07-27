using UnityEngine;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class Vector2Extensions
    {
        public static Vector2 SetX(this Vector2 vector2, float value)
        {
            vector2.x = value;
            return vector2;
        }

        public static Vector2 SetY(this Vector2 vector2, float value)
        {
            vector2.y = value;
            return vector2;
        }

        #region ADDITION
        public static Vector2Int AddToInt(this Vector2 vector2, Vector2Int value)
        {
            return new Vector2Int((int)(vector2.x + value.x), (int)(vector2.y + value.y));
        }

        public static Vector3Int AddToInt(this Vector2 vector2, Vector3Int value)
        {
            return new Vector3Int((int)(vector2.x + value.x), (int)(vector2.y + value.y), value.z);
        }

        public static Vector3 Add(this Vector2 vector2, Vector3 vector3)
        {
            return new Vector3(vector2.x + vector3.x, vector2.y + vector3.y, vector3.z);
        }

        public static Vector3 Add(this Vector2 vector2, Vector3Int vector3Int)
        {
            return new Vector3(vector2.x + vector3Int.x, vector2.y + vector3Int.y, vector3Int.z);
        }

        public static Vector2 Add(this Vector2 vector2, float value)
        {
            return new Vector2(vector2.x + value, vector2.y + value);
        }
        #endregion

        #region SUBTRACTION
        public static Vector2Int MinusToInt(this Vector2 vector2, Vector2Int vector2Int)
        {
            return new Vector2Int((int)(vector2.x - vector2Int.x), (int)(vector2.y - vector2Int.y));
        }

        public static Vector3Int MinusToInt(this Vector2 vector2, Vector3Int vector3Int)
        {
            return new Vector3Int((int)(vector2.x - vector3Int.x), (int)(vector2.y - vector3Int.y), vector3Int.z);
        }

        public static Vector3 Minus(this Vector2 vector2, Vector3Int vector3Int)
        {
            return new Vector3(vector2.x - vector3Int.x, vector2.y - vector3Int.y, vector3Int.z);
        }

        public static Vector2 Minus(this Vector2 vector2, float value)
        {
            return new Vector2(vector2.x - value, vector2.y - value);
        }
        #endregion

        #region CONVERSION
        public static Vector2Int ToInt(this Vector2 vector2)
        {
            return new Vector2Int((int)vector2.x , (int)vector2.y);
        }
        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y, 0);
        }
        #endregion

        #region Math
        public static Vector2 Rotate(this Vector2 vector2, float value)
        {
            return new Vector2(
                Mathf.Cos(value) * vector2.x - Mathf.Sin(value) * vector2.y,
                Mathf.Sin(value) * vector2.x + Mathf.Cos(value) * vector2.y);
        }
    
        public static Vector2Int MultiplyToInt(this Vector2 vector2, Vector2Int vector2Int)
        {
            return new Vector2Int((int)(vector2.x * vector2Int.x), (int)(vector2.y * vector2Int.y));
        }

        public static Vector3Int MultiplyToInt(this Vector2 vector2, Vector3Int vector3Int)
        {
            return new Vector3Int((int)(vector2.x * vector3Int.x), (int)(vector2.y * vector3Int.y), (int)(vector3Int.z));
        }

        public static Vector3 Multiply(this Vector2 vector2, Vector3Int vector3Int)
        {
            return new Vector3(vector2.x * vector3Int.x, vector2.y * vector3Int.y, vector3Int.z);
        }
        #endregion

        public static float Random(this Vector2 vector2)
        {
            return UnityEngine.Random.Range(vector2.x, vector2.y);
        }
    }
}
