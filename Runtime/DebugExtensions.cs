using UnityEngine;

namespace Extensions.Runtime
{
    public static class DebugExtensions
    {
        public static void DrawX(Vector3 position, float radius, Color color)
        {
            var from1 = position - Vector3.up * radius;
            var to1 = position + Vector3.up * radius;

            var from2 = position - Vector3.right * radius;
            var to2 = position + Vector3.right * radius;
        
            Debug.DrawLine(from1, to1, color);
            Debug.DrawLine(from2, to2, color);
        }
    }
}