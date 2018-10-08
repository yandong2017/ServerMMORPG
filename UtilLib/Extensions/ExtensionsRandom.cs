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
        /// 随机出一个元素
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomSingle<T>(this IEnumerable<T> list)
        {
            int max = list.Count();
            if (max <= 0)
            {
                return default(T);
            }
            return list.ElementAt(Util.Random.Next(max));
        }
        /// <summary>
        /// 随机出N个不重复元素
        /// </summary>
        /// <param name="list"></param>
        /// <param name="n">数目</param>
        /// <returns></returns>
        public static IEnumerable<T> RandomMultiple<T>(this IEnumerable<T> list, int n)
        {
            int max = list.Count();
            int count = n;
            if (max <= 0)
            {
                return list;
            }
            if (count >= max)
            {
                return list;
            }
            var indexs = Util.RandomMultiple(count, 0, max);
            T[] result = Array.ConvertAll(indexs, delegate (int v) { return list.ElementAt(v); });
            return result;
        }
        /// <summary>
        /// 从Dictionary里随机出一个元素
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static T1 RandomSingle<T1, T2>(this Dictionary<T1, T2> dict)
        {
            var rdList = dict.Keys.ToList();
            int max = rdList.Count;
            if (max <= 0)
            {
                return default(T1);
            }
            return rdList[Util.Random.Next(max)];
        }
        /// <summary>
        /// 从Dictionary里随机出N个不重复元素
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="n">数目</param>
        /// <returns></returns>
        public static Dictionary<T1, T2> RandomMultiple<T1, T2>(this Dictionary<T1, T2> dict, int n)
        {
            var result = new Dictionary<T1, T2>();
            var rdList = dict.Keys.ToList();
            var resultList = rdList.RandomMultiple(n);
            resultList.ForEach(ele => result.Add(ele, dict[ele]));
            return result;
        }
        /// <summary>
        /// 随机洗牌List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public static List<T> RandomShuffle<T>(this List<T> inputList)
        {
            T[] copyArray = new T[inputList.Count];
            inputList.CopyTo(copyArray);

            List<T> copyList = new List<T>();
            copyList.AddRange(copyArray);

            List<T> outputList = new List<T>();

            while (copyList.Count > 0)
            {
                int rdIndex = Util.Random.Next(0, copyList.Count - 1);
                T remove = copyList[rdIndex];

                copyList.Remove(remove);
                outputList.Add(remove);
            }
            return outputList;
        }


    }
}
