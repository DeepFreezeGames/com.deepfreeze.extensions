using UnityEngine;

namespace Extensions.Runtime
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform transform)
        {
            for (var t = transform.childCount - 1; t >= 0; t--)
            {
                if (Application.isPlaying)
                {
                    Object.Destroy(transform.GetChild(t).gameObject);
                }
                else
                {
                    Object.DestroyImmediate(transform.GetChild(t).gameObject);
                }
            }
        }
    }
}