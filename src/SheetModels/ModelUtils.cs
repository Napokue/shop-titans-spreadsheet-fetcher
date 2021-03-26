using System;
using System.Globalization;

namespace SheetModels
{
    internal static class ModelUtils
    {
        private static IFormatProvider _enUs = CultureInfo.CreateSpecificCulture("en-US");
        
        /// <summary>
        /// The spreadsheet uses --- to indicate that an item is not applicable
        /// </summary>
        public const string NotApplicable = "---";

        public static bool IsApplicable(object value)
        {
            return (string) value != NotApplicable;
        }

        public static T Parse<T>(this object value)
        {
            // All cell values are string
            var stringVal = (string) value;

            if (!IsApplicable(stringVal) || string.IsNullOrEmpty(stringVal))
            {
                return default;
            }
            
            if (typeof(T) == typeof(string))
            {
                return (T) (object) stringVal;
            }
            
            if (typeof(T) == typeof(uint))
            {
                return (T) (object) uint.Parse(stringVal, NumberStyles.Any, _enUs);
            }
            
            if (typeof(T) == typeof(byte))
            {
                return (T) (object) byte.Parse(stringVal, NumberStyles.Any, _enUs);
            }
            
            if (typeof(T) == typeof(TimeSpan))
            {
                return (T) (object) TimeSpan.Parse(stringVal, _enUs);
            }
            
            if (typeof(T) == typeof(float))
            {
                return (T) (object) float.Parse(stringVal, NumberStyles.Any, _enUs);
            }

            throw new InvalidCastException();
        }
    }
}
