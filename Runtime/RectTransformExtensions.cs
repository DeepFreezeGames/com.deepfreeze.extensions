using UnityEngine;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class RectTransformExtensions
    {
        public static Vector2 ProjectToRectTransform(this RectTransform source, RectTransform target)
        {
            //var screenP = RectTransformUtility.WorldToScreenPoint(Camera.current, source.localPosition + source.TransformVector(source.rect.center));
            var screenP = RectTransformUtility.WorldToScreenPoint(Camera.current, source.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(target, screenP, Camera.current, out var localPoint);
            return target.anchoredPosition + localPoint;
        }

        public static Rect ProjectToRectTransform(this RectTransform source, RectTransform target, Canvas canvas)
        {
            var screenP = RectTransformUtility.WorldToScreenPoint(Camera.current, source.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(target, screenP, Camera.current, out var localPoint);
            target.anchoredPosition += localPoint;
            return RectTransformUtility.PixelAdjustRect(target, canvas);
        }

        public static void SetPivotAndAnchors(this RectTransform source, Vector2 anchorPosition)
        {
            source.pivot = anchorPosition;
            source.anchorMin = anchorPosition;
            source.anchorMax = anchorPosition;
        }

        public static Vector2 GetSize(this RectTransform source)
        {
            return source.rect.size;
        }

        public static float GetWidth(this RectTransform source)
        {
            return source.rect.width;
        }

        public static float GetHeight(this RectTransform source)
        {
            return source.rect.height;
        }

        /// <summary>
        /// Copies the rect transform details from the source and apply those details to the target RectTransform
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void Clone(this RectTransform target, RectTransform source)
        {
            if (target.lossyScale != source.lossyScale)
            {
                Debug.LogWarning("Cloning RectTransforms with different scales.\nThe final result won't be the same");
            }
            
            var rect = source.rect;
            target.sizeDelta = source.sizeDelta;
            target.rect.Set(rect.x, rect.y, rect.width, rect.height);
            target.pivot = source.pivot;
            
        }

        public static void SetSize(this RectTransform source, Vector2 newSize)
        {
            var oldSize = source.rect.size;
            var deltaSize = newSize - oldSize;
            var sourcePivot = source.pivot;
            source.offsetMin -= new Vector2(deltaSize.x * sourcePivot.x, deltaSize.y * sourcePivot.y);
            source.offsetMax += new Vector2(deltaSize.x * (1f - sourcePivot.x), deltaSize.y * (1f - sourcePivot.y));
        }

        public static void SetWidth(this RectTransform source, float newSize)
        {
            SetSize(source, new Vector2(newSize, source.rect.size.y));
        }

        public static void SetHeight(this RectTransform source, float newSize)
        {
            SetSize(source, new Vector2(source.rect.size.x, newSize));
        }
        
        private static int CountCornersVisibleFrom(this RectTransform rectTransform, Camera camera)
        {
            var screenBounds = new Rect(0f, 0f, Screen.width, Screen.height); // Screen space bounds (assumes camera renders across the entire screen)
            var objectCorners = new Vector3[4];
            rectTransform.GetWorldCorners(objectCorners);
 
            var visibleCorners = 0;
            foreach (var corner in objectCorners)
            {
                var tempScreenSpaceCorner = camera.WorldToScreenPoint(corner); // Cached
                if (screenBounds.Contains(tempScreenSpaceCorner)) // If the corner is inside the screen
                {
                    visibleCorners++;
                }
            }
            return visibleCorners;
        }
 
        public static bool IsFullyVisibleFrom(this RectTransform rectTransform, Camera camera)
        {
            return CountCornersVisibleFrom(rectTransform, camera) == 4; // True if all 4 corners are visible
        }

        public static bool IsVisibleFrom(this RectTransform rectTransform, Camera camera)
        {
            return CountCornersVisibleFrom(rectTransform, camera) > 0; // True if any corners are visible
        }
    }
}