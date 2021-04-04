
using System;


namespace TechLandTools.Common.Extension
{
    public static class ObjectExtension
    {
        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNumericType(this Type t)
        {
            switch (Type.GetTypeCode(t.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static T GetInstanceOf<T>(this Type t)
        {
            T instance = (T)Activator.CreateInstance(t);
            return instance;
        }

        public static string ToStringOrNull(this IComparable obj)
        {
            if (obj == null)
            {
                return "null";
            }
            else if (obj.GetType() == typeof(DateTime) || obj.GetType() == typeof(string))
            {
                return $"'{obj.ToString()}'";
            }
            else
            {
                return obj.ToString();
            }

        }
    }
}
