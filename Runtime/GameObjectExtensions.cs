using System.Collections.Generic;
using UnityEngine;

namespace Extensions.Runtime
{
    public static class GameObjectExtensions
    {
        private static readonly List<Component> ComponentCache = new List<Component>();

        /// <summary>
        /// Grabs a component without allocating memory uselessly
        /// </summary>
        /// <param name="this"></param>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public static Component GetComponentNoAlloc(this GameObject @this, System.Type componentType)
        {
            @this.GetComponents(componentType, ComponentCache);
            var component = ComponentCache.Count > 0 ? ComponentCache[0] : null;
            ComponentCache.Clear();
            return component;
        }

        /// <summary>
        /// Grabs a component without allocating memory uselessly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T GetComponentNoAlloc<T>(this GameObject @this) where T : Component
        {
            @this.GetComponents(typeof(T), ComponentCache);
            var component = ComponentCache.Count > 0 ? ComponentCache[0] : null;
            ComponentCache.Clear();
            return component as T;
        }
        
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (result == null)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}