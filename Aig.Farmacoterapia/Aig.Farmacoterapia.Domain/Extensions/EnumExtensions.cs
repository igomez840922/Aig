using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Aig.Farmacoterapia.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum val)
        {
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?.Length > 0
                ? attributes[0].Description
                : val.ToString();
        }
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static string ToEnumMemberAttr(this Enum value)
        {
            var attr = value.GetType().GetMember(value.ToString()).FirstOrDefault()?.
                    GetCustomAttributes(false).OfType<EnumMemberAttribute>().
                    FirstOrDefault();
            return attr == null ? value.ToString() : attr.Value;
        }
    }
}