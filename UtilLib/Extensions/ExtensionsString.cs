using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
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
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string item)
        {
            return String.IsNullOrEmpty(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string item)
        {
            return String.IsNullOrEmpty(item) || item.All(Char.IsWhiteSpace);
        }
        /// <summary>
        /// Determines whether the specified string is not <see cref="IsNullOrEmpty"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="value"/> is not <see cref="IsNullOrEmpty"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        /// <summary>
        /// Uses the string as a format
        /// </summary>
        /// <param name="format">A string reference</param>
        /// <param name="args">Object parameters that should be formatted</param>
        /// <returns>Formatted string</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            return string.Format(format, args);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="ending"></param>
        /// <returns></returns>
        public static string EnsureEndsWith(this string s, string ending)
        {
            if (s == null) return null;

            return s.EndsWith(ending) ? s : string.Concat(s, ending);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="howMany"></param>
        /// <returns></returns>
        public static string TakeFirst(this string s, int howMany = 1)
        {
            if (s.IsNullOrEmpty())
                return String.Empty;

            if (s.Length <= howMany)
                return s;

            return s.Substring(0, howMany);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] Split(this string s, string separator)
        {
            if (s.IsNullOrEmpty())
                return new string[0];

            return s.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }


        /// <summary>
        /// string->bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ToBool(this string str)
        {
            bool.TryParse(str, out bool result);
            return result;
        }
        /// <summary>
        /// string->int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            int.TryParse(str, out int result);
            return result;
        }
        /// <summary>
        /// string->long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToLong(this string str)
        {
            long.TryParse(str, out long result);
            return result;
        }
        /// <summary>
        /// string->float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str)
        {
            float.TryParse(str, out float result);
            return result;
        }
        /// <summary>
        /// string->float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            if (!DateTime.TryParse(str, out var result))
            {
                return new DateTime();
            }
            return result;
        }
        /// <summary>
        /// string->List(string)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator"></param>
        /// <returns></returns>
        public static List<string> ToListString(this string str, string strSeparator = UtilEnum.分隔符分号)
        {
            string[] nodes = str.Split(strSeparator);
            return nodes.ToList();
        }
        /// <summary>
        /// string->List(int)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator"></param>
        /// <returns></returns>
        public static List<int> ToListInt(this string str, string strSeparator = UtilEnum.分隔符分号)
        {
            string[] nodes = str.Split(strSeparator);
            int[] nodesresult = Array.ConvertAll(nodes, delegate (string s) { return s.ToInt(); });
            return nodesresult.ToList();
        }
        /// <summary>
        /// string->List(long)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator"></param>
        /// <returns></returns>
        public static List<long> ToListLong(this string str, string strSeparator = UtilEnum.分隔符分号)
        {
            string[] nodes = str.Split(strSeparator);
            long[] nodesresult = Array.ConvertAll(nodes, delegate (string s) { return s.ToLong(); });
            return nodesresult.ToList();
        }
        /// <summary>
        /// string->List(float)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator"></param>
        /// <returns></returns>
        public static List<float> ToListFloat(this string str, string strSeparator = UtilEnum.分隔符分号)
        {
            string[] nodes = str.Split(strSeparator);
            float[] nodesresult = Array.ConvertAll(nodes, delegate (string s) { return s.ToFloat(); });
            return nodesresult.ToList();
        }
        /// <summary>
        /// string->List(List(string))
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static List<List<string>> ToListListString(this string str, string strSeparator1 = UtilEnum.分隔符分号, string strSeparator2 = UtilEnum.分隔符逗号)
        {
            string[] nodes1 = str.Split(strSeparator1);
            var result = new List<List<string>>();
            foreach (var nn in nodes1)
            {
                string[] nodes2 = nn.Split(strSeparator2);
                result.Add(nodes2.ToList());
            }
            return result;
        }
        /// <summary>
        /// string->List(List(int))
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static List<List<int>> ToListListInt(this string str, string strSeparator1 = UtilEnum.分隔符分号, string strSeparator2 = UtilEnum.分隔符逗号)
        {
            string[] nodes1 = str.Split(strSeparator1);
            var result = new List<List<int>>();
            foreach (var nn in nodes1)
            {
                string[] nodes2 = nn.Split(strSeparator2);
                int[] nodesresult = Array.ConvertAll(nodes2, delegate (string s) { return s.ToInt(); });
                result.Add(nodesresult.ToList());
            }
            return result;
        }
        /// <summary>
        /// string->List(List(float))
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static List<List<float>> ToListListFloat(this string str, string strSeparator1 = UtilEnum.分隔符分号, string strSeparator2 = UtilEnum.分隔符逗号)
        {
            string[] nodes1 = str.Split(strSeparator1);
            var result = new List<List<float>>();
            foreach (var nn in nodes1)
            {
                string[] nodes2 = nn.Split(strSeparator2);
                float[] nodesresult = Array.ConvertAll(nodes2, delegate (string s) { return s.ToFloat(); });
                result.Add(nodesresult.ToList());
            }
            return result;
        }
        /// <summary>
        /// string->Dictionary(string, string)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionaryString(this string str, string strSeparator1 = UtilEnum.分隔符逗号, string strSeparator2 = UtilEnum.分隔符冒号)
        {
            var result = new Dictionary<string, string>();
            string[] nodes = str.Split(strSeparator1);
            foreach (var node in nodes)
            {
                string[] nodes2 = node.Split(strSeparator2);
                if (nodes2.Length > 1)
                {
                    result[nodes2[0]] = nodes2[1];
                }
            }
            return result;
        }
        /// <summary>
        /// string->Dictionary(int, int)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static Dictionary<int, int> ToDictionaryInt(this string str, string strSeparator1 = UtilEnum.分隔符逗号, string strSeparator2 = UtilEnum.分隔符冒号)
        {
            var result = new Dictionary<int, int>();
            string[] nodes = str.Split(strSeparator1);
            foreach (var node in nodes)
            {
                string[] nodes2 = node.Split(strSeparator2);
                if (nodes2.Length > 1)
                {
                    result[nodes2[0].ToInt()] = nodes2[1].ToInt();
                }
            }
            return result;
        }
        /// <summary>
        /// string->Dictionary(long, long)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static Dictionary<long, long> ToDictionaryLong(this string str, string strSeparator1 = UtilEnum.分隔符逗号, string strSeparator2 = UtilEnum.分隔符冒号)
        {
            var result = new Dictionary<long, long>();
            string[] nodes = str.Split(strSeparator1);
            foreach (var node in nodes)
            {
                string[] nodes2 = node.Split(strSeparator2);
                if (nodes2.Length > 1)
                {
                    result[nodes2[0].ToLong()] = nodes2[1].ToLong();
                }
            }
            return result;
        }
        /// <summary>
        /// List(T)->string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="strSeparator"></param>
        /// <returns></returns>
        public static string ToStr<T>(this List<T> input, string strSeparator = UtilEnum.分隔符逗号)
        {
            string[] arrinput = input.ConvertAll(delegate (T v) { return v.ToString(); }).ToArray();
            return string.Join(strSeparator, arrinput);
        }
        /// <summary>
        /// Dictionary(T1, T2)->string
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="input"></param>
        /// <param name="strSeparator1"></param>
        /// <param name="strSeparator2"></param>
        /// <returns></returns>
        public static string ToStr<T1, T2>(this Dictionary<T1, T2> input, string strSeparator1 = UtilEnum.分隔符逗号, string strSeparator2 = UtilEnum.分隔符冒号)
        {
            List<string> listinput = new List<string>();
            foreach (var kvp in input)
            {
                listinput.Add(string.Format("{0}{1}{2}", kvp.Key, strSeparator2, kvp.Value));
            }
            return string.Join(strSeparator1, listinput);
        }


    }
}
