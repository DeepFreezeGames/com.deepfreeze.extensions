using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Extensions.Runtime
{
    public static class EnumExtensions
    {
        private static void CheckIsEnum<T>(bool withFlags)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Type '{typeof(T).FullName}' is not an enum");
            }            
            
            if (withFlags && !Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
            {
                throw new ArgumentException($"Type '{typeof(T).FullName}' doesn't have the 'Flags' attribute");
            }
        }
        
        public static bool In(this Enum @this, params Enum[] values)
        {
            return Array.IndexOf(values, @this) != -1;
        }
        
        public static bool NotIn(this Enum @this, params Enum[] values)
        {
            return Array.IndexOf(values, @this) == -1;
        }
        
        public static T Random<T>()
        {
            var values = Enum.GetValues(typeof(T));
            var random = new Random(DateTime.Now.Millisecond);
            return (T)values.GetValue(random.Next(values.Length));
        }

        public static bool IsFlagSet<T>(this T value, T flag) where T : struct
        {
            CheckIsEnum<T>(true);
            var lValue = Convert.ToInt64(value);
            var lFlag = Convert.ToInt64(flag);
            return (lValue & lFlag) != 0;
        }

        public static IEnumerable<T> GetFlags<T>(this T value) where T : struct
        {
            CheckIsEnum<T>(true);
            foreach (var flag in Enum.GetValues(typeof(T)).Cast<T>())
            {
                if (value.IsFlagSet(flag))
                {
                    yield return flag;
                }
            }
        }

        public static T SetFlags<T>(this T value, T flags, bool on) where T : struct
        {
            CheckIsEnum<T>(true);
            var lValue = Convert.ToInt64(value);
            var lFlag = Convert.ToInt64(flags);
            if (on)
            {
                lValue |= lFlag;
            }
            else
            {
                lValue &= (~lFlag);
            }
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static T SetFlags<T>(this T value, T flags) where T : struct
        {
            return value.SetFlags(flags, true);
        }

        public static T ClearFlags<T>(this T value, T flags) where T : struct
        {
            return value.SetFlags(flags, false);
        }

        public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct
        {
            CheckIsEnum<T>(true);
            var lValue = flags.Select(flag => Convert.ToInt64(flag)).Aggregate<long, long>(0, (current, lFlag) => current | lFlag);
            return (T)Enum.ToObject(typeof(T), lValue);
        }

        public static string GetDescription<T>(this T value) where T : struct
        {
            CheckIsEnum<T>(false);
            var name = Enum.GetName(typeof(T), value);
            if (name == null)
            {
                return null;
            }
            
            var field = typeof(T).GetField(name);
            if (field == null)
            {
                return null;
            }
                
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return attr.Description;
            }
            return null;
        }
    }
}
