using System;
using System.ComponentModel;

namespace Aig.Farmacoterapia.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum val)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return attributes?.Length > 0
                ? attributes[0].Description
                : val.ToString();
        }
    }
}