using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Leadzum.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            try
            {
                FieldInfo fileInfo = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fileInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch
            {
                return value.ToString();
            }
        }

        public static string GetAttribute<T>(this Enum value) where T : Attribute
        {
            return value.GetAttribute<T, string>();
        }

        public static TResult GetAttribute<T, TResult>(this Enum value) where T : Attribute
        {
            try
            {
                var type = typeof(T);
                FieldInfo fileInfo = value.GetType().GetField(value.ToString());
                var attributeValue = fileInfo.GetCustomAttribute(type, false);
                return attributeValue == null ? default : (TResult)attributeValue.TypeId;
            }
            catch
            {
                return default;
            }
        }

        public static T GetAttributeObject<T>(this Enum value) where T : Attribute
        {
            try
            {
                var type = typeof(T);
                FieldInfo fileInfo = value.GetType().GetField(value.ToString());
                var attributeValue = fileInfo.GetCustomAttribute(type, false);
                return (T)attributeValue;
            }
            catch
            {
                return default;
            }
        }

        public static T ToEnumValue<T>(this string value, T defaultValue)
        {
            return value.ToEnumValue(defaultValue, true);
        }

        public static T ToEnumValue<T>(this string value, T defaultValue, bool ignoreCase)
        {
            T enumValue = defaultValue;

            if (Enum.IsDefined(typeof(T), value))
            {
                enumValue = (T)Enum.Parse(typeof(T), value, ignoreCase);
            }

            foreach (Enum val in Enum.GetValues(typeof(T)))
            {
                string comparisson = GetDescription(val);
                if (comparisson.Equals(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                {
                    enumValue = (T)Enum.Parse(typeof(T), val.ToString());
                }
            }
            return enumValue;
        }
    }
}
