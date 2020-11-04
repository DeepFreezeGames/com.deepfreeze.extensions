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

        public static void ResetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void ResetWorld(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        
        public static void Unparent(this Transform transform, bool worldPositionStays = false)
        {
            transform.SetParent(null, worldPositionStays);
        }

        public static bool IsChildOf(this Transform child, Transform parent)
        {
            if (child.root == parent)
            {
                return true;
            }

            while (child != null)
            {
                if (child == parent)
                {
                    return true;
                }

                var parent1 = child.parent;
                child = parent1 != null ? parent1 : null;
            }

            return false;
        }
    }
}
