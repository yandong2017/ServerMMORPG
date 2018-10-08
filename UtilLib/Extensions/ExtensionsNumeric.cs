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
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ToFileSizeDisplay(this int i)
        {
            return ToFileSizeDisplay((long)i, 2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static string ToFileSizeDisplay(this int i, int decimals)
        {
            return ToFileSizeDisplay((long)i, decimals);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ToFileSizeDisplay(this long i)
        {
            return ToFileSizeDisplay(i, 2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static string ToFileSizeDisplay(this long i, int decimals)
        {
            if (i < 1024 * 1024 * 1024) // 1 GB
            {
                string value = Math.Round((decimal)i / 1024m / 1024m, decimals).ToString("N" + decimals);
                if (decimals > 0 && value.EndsWith(new string('0', decimals)))
                    value = value.Substring(0, value.Length - decimals - 1);

                return String.Concat(value, " MB");
            }
            else
            {
                string value = Math.Round((decimal)i / 1024m / 1024m / 1024m, decimals).ToString("N" + decimals);
                if (decimals > 0 && value.EndsWith(new string('0', decimals)))
                    value = value.Substring(0, value.Length - decimals - 1);

                return String.Concat(value, " GB");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToOrdinal(this int num)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num.ToString("#,###0") + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num.ToString("#,###0") + "st";

                case 2:
                    return num.ToString("#,###0") + "nd";

                case 3:
                    return num.ToString("#,###0") + "rd";

                default:
                    return num.ToString("#,###0") + "th";
            }
        }

    }
}
