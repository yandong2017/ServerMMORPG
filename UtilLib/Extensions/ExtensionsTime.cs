using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToStr(this DateTime dt, int format = 0)
        {
            switch (format)
            {
                case 1:
                    return dt.ToString("yyyy年MM月dd日");
                case 2:
                    return dt.ToString("HH时mm分ss秒");
                default:
                    return dt.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            }
        }
        /// <summary>
        /// 获取时间字符串
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToStr(this TimeSpan ts, int format = 0)
        {
            switch (format)
            {
                case 1:
                    return ts.ToString(@"hh\:mm\:ss");
                case 2:
                    return $"{ts.TotalSeconds}";
                case 3:
                    return ts.ToString("G");
                case 4:
                    return $"{(int)Math.Ceiling(ts.TotalDays)}";
                default:
                    return ts.ToString();
            }
        }
        /// <summary>
        /// 获取两个日期之间天数
        /// </summary>
        /// <param name="dtLast">时间一</param>
        /// <param name="dtThis">时间二</param>
        /// <returns></returns>
        public static int IntervalDays(this DateTime dtLast, DateTime dtThis)
        {
            DateTime dt11 = new DateTime(dtLast.Year, dtLast.Month, dtLast.Day);
            DateTime dt22 = new DateTime(dtThis.Year, dtThis.Month, dtThis.Day);
            return (new TimeSpan(dt22.Ticks - dt11.Ticks).Days);
        }
        /// <summary>
        /// 获取剩余时间Ticks
        /// </summary>
        /// <param name="dtLast"></param>
        /// <param name="dtThis"></param>
        /// <param name="abs">是否取绝对值</param>
        /// <returns></returns>
        public static long IntervalTicks(this DateTime dtLast, DateTime dtThis, bool abs = false)
        {
            return (abs ? Math.Max(0, (dtLast - dtThis).Ticks) : (dtLast - dtThis).Ticks);
        }
        /// <summary>
        /// 获取指定日期，在为一年中为第几周
        /// </summary>
        /// <param name="dt">指定时间</param>
        /// <reutrn>返回第几周</reutrn>
        public static int WeekOfYear(this DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }
        /// <summary>
        /// 判断是否是同一天
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static bool SameDay(this DateTime dt1, DateTime dt2)
        {
            if (dt1.Year != dt2.Year || dt1.DayOfYear != dt2.DayOfYear)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否是同一点钟
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static bool SameOClock(this DateTime dt1, DateTime dt2)
        {
            if (dt1.Year != dt2.Year || dt1.DayOfYear != dt2.DayOfYear || dt1.Hour != dt2.Hour)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否是在同一周
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static bool SameWeek(this DateTime dt1, DateTime dt2)
        {
            if (dt1.WeekOfYear() != dt2.WeekOfYear() || dt1.Year != dt2.Year)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否是在同一月
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static bool SameMonth(this DateTime dt1, DateTime dt2)
        {
            if (dt1.Month != dt2.Month || dt1.Year != dt2.Year)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static TimeSpan Min(this TimeSpan source, TimeSpan other)
        {
            return source.Ticks > other.Ticks ? other : source;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static TimeSpan Max(this TimeSpan source, TimeSpan other)
        {
            return source.Ticks < other.Ticks ? other : source;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long ticks)
        {
            return new DateTime(ticks);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticks"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this long ticks)
        {
            return new TimeSpan(ticks);
        }

        #region UnixTime
        private const long UnixEpochTicks = 621355968000000000;
        private const long UnixEpochSeconds = 62135596800;
        private const long UnixEpochMilliseconds = 62135596800000;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTimeOffset FromUnixTimeSeconds(this long seconds)
        {
            long ticks = seconds * TimeSpan.TicksPerSecond + UnixEpochTicks;
            return new DateTime(ticks, DateTimeKind.Utc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime FromUnixTimeMilliseconds(this long milliseconds)
        {
            long ticks = milliseconds * TimeSpan.TicksPerMillisecond + UnixEpochTicks;
            return new DateTime(ticks, DateTimeKind.Utc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            long seconds = dateTime.ToUniversalTime().Ticks / TimeSpan.TicksPerSecond;
            return seconds - UnixEpochSeconds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
        {
            long milliseconds = dateTime.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds - UnixEpochMilliseconds;
        }
        #endregion

    }
}
