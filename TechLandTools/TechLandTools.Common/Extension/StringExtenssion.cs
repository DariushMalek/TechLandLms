using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechLandTools.Common.Extension
{
    public static class StringExtensions
    {
        public static string FixFildName(this string name)
        {

            return name?.Replace(".", "", StringComparison.OrdinalIgnoreCase).Replace("[", "", StringComparison.OrdinalIgnoreCase).Replace("]", "", StringComparison.OrdinalIgnoreCase).Replace(" ", "", StringComparison.OrdinalIgnoreCase).Replace("&", "And", StringComparison.OrdinalIgnoreCase).Replace("ColumnItem", "AxisItem", StringComparison.OrdinalIgnoreCase).Replace("ColumnScale", "AxisScale", StringComparison.OrdinalIgnoreCase).Replace("ColumnType", "AxisType", StringComparison.OrdinalIgnoreCase).Replace("ColumnRate", "AxisRate", StringComparison.OrdinalIgnoreCase);
        }
        public static object Pars(this string str, string type)
        {
            if (!string.IsNullOrWhiteSpace(type))
            {
                if (string.IsNullOrWhiteSpace(str))
                    switch (type.ToLower())
                    {
                        case "int": return default(int);
                        case "long": return default(long);
                        case "decimal": return default(decimal);
                        case "datetime": return default(DateTime);
                        case "pdatetime": return default(DateTime);
                        case "pstrdatetime": return "";
                        case "float": return default(float);
                    }
                switch (type.ToLower())
                {
                    case "int": return int.Parse(str);
                    case "long": return long.Parse(str);
                    case "decimal": return decimal.Parse(str);
                    case "datetime": return DateTime.Parse(str);
                    case "pdatetime": return String.IsNullOrWhiteSpace(str) ? default(DateTime) : str.ToGlubalDateTime();
                    case "pstrdatetime": return String.IsNullOrWhiteSpace(str) ? "" : str.ToGlubalDateTime().ToString();
                    case "float": return float.Parse(str);
                }
            }
            return str;
        }
        public static int? ParseInt(this string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            return null;
        }
        public static short? ParseShort(this string value)
        {
            short result;
            if (short.TryParse(value, out result))
                return result;
            return null;
        }

        public static bool ParseBool(this string value)
        {
            bool result;
            if (bool.TryParse(value, out result))
                return result;
            return false;
        }

        public static bool IsNumeric(this string value)
        {
            bool canConvert = long.TryParse(value, out _);
            if (canConvert == true)
                return true;
            canConvert = byte.TryParse(value, out _);
            if (canConvert == true)
                return true;
            canConvert = decimal.TryParse(value, out _);
            if (canConvert == true)
                return true;

            return false;
        }

        public static string ToBase64Image(this string imagePath)
        {
            var fileName = "wwwroot\\" + imagePath;
            if (File.Exists(fileName))
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(fileName);
                string base64 = Convert.ToBase64String(imageArray);
                return $"data:image/jpg;base64,{base64}";
            }
            return null;
        }

        public static bool In(this string str, params string[] strings)
        {
            return strings.ToList().Contains(str);
        }
        public static bool GreaterThan(this string str, string compareStr)
        {
            return str.CompareTo(compareStr) > 0;
        }

        public static bool EqualTo(this string str, string compareStr)
        {
            return str.CompareTo(compareStr) == 0;
        }

        public static bool LessThan(this string str, string compareStr)
        {
            return str.CompareTo(compareStr) < 0;
        }

        public static string CapitalizeFirstChar(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
