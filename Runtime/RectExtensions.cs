using UnityEngine;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class RectExtensions
    {
        public static bool Intersects(this Rect rect, Rect otherRect)
        {
            return !(rect.x > otherRect.xMax || rect.xMax < otherRect.x || rect.y > otherRect.yMax || rect.yMax < otherRect.y);
        }
    }
}