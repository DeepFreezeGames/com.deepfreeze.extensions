using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class ComponentExtensions
    {
        public static bool IsWorldSpace(this Component component)
        {
            var canvas = component == null ? null : component.GetComponentInParent<Canvas>();
            var isWorldSpace = component != null && (canvas == null || canvas.renderMode == RenderMode.WorldSpace);
            return isWorldSpace;
        }

        public static T CopyComponent<T>(this T original, GameObject destination) where T : Component
        {
            var type = original.GetType();
            var copy = destination.AddComponent(type);
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                field.SetValue(copy, field.GetValue(original));
            }
            return copy as T;
        }

        public static string FullName(this Component original)
        {
            return FullName(original, Path.DirectorySeparatorChar);
        }

        public static string FullName(this Component original, char separator)
        {
            var parent = original.transform.parent;
            return parent != null 
                ? $"{FullName(parent, separator)}{separator.ToString()}{original.name}" 
                : $"{SceneManager.GetActiveScene().name}{separator.ToString()}{original.transform.name}";
        }
    }
}