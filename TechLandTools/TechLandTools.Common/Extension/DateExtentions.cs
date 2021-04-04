using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TechLandTools.Common.Extension
{
    public static class DateTimeConstant
    {

        public static readonly string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
    }
    public static class DateExtentions
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTime(this DateTime date)
        {
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }
        public static DateTime FromUnixTime(this long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }

        public static DateTime FromStringUnixTime(this string epochTime)
        {
            long unixTime = 0;
            if (epochTime.Contains("|"))
            {
                var parts = epochTime.Split("|");
                unixTime = long.Parse(parts[0]) + long.Parse(parts[1]) + long.Parse(parts[2]);
            }
            return epoch.AddSeconds(unixTime);
        }
        public static DateTime ToGlubalDateTime(this string DateTime)
        {

            var pc = new PersianCalendar();
            var data = DateTime.Trim().Split(' ');
            var times = new string[] { "0", "0", "0" };
            if (data.Length == 2)
                times = data[1].Trim().Split(':');
            var datas = data[0].Trim().Split('/');
            int year = 0;

            int month = 0;

            int day = 0;
            int houre = 0;

            int minute = 0;

            int second = 0;
            int YearIndex = 0;
            int DayIndex = 2;
            if (datas.Length == 3)
            {
                int.TryParse(datas[1], out month);
                if (datas[2].Length == 4)
                {
                    YearIndex = 2;
                    DayIndex = 0;
                }
                int.TryParse(datas[DayIndex], out day);
                int.TryParse(datas[YearIndex], out year);
            }
            if (times.Length >= 1)
            {
                int.TryParse(times[0], out houre);
                if (times.Length >= 2)
                    int.TryParse(times[1], out minute);
                if (times.Length == 3)
                    int.TryParse(times[2], out second);
            }
            return pc.ToDateTime(year, month, day, houre, minute, second, 0);
        }
        public static string ToPersianDate(this DateTime value)
        {
            if (value.CompareTo(DateTime.MinValue) <= 0)
                return "";
            var calendar = new PersianCalendar();

            var year = calendar.GetYear(value);
            var month = calendar.GetMonth(value);
            var day = calendar.GetDayOfMonth(value);
            return string.Format("{0}/{1:D2}/{2:D2}", year, month, day);
        }
        public static string ToPersianDateTime(this DateTime value)
        {
            if (value.CompareTo(DateTime.MinValue) <= 0)
                return "";
            return string.Format("{0} {1}", value.ToPersianDate(), value.ToShortTimeString());
        }
        public static string ToPersianDate(this DateTime? value)
        {
            if (value.HasValue)
                return ToPersianDate(value.Value);
            return "";
        }
        public static string GetTime(this DateTime value)
        {
            return string.Format("{0}:{1:D2}", value.Hour, value.Minute); ;
        }

        public static string ToPersianDateFullTime(this DateTime value)
        {
            if (value.CompareTo(DateTime.MinValue) <= 0)
                return "";
            return string.Format("{0} {1}", value.ToPersianDate(), value.ToLongTimeString());
        }
    }
}
