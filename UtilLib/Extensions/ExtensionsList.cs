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
        /// 比较两个List相等 
        /// 数量相等，元素值相等即为True；与元素顺序无关；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ListA"></param>
        /// <param name="ListB"></param>
        /// <returns></returns>
        public static bool ListSameElement<T>(this List<T> ListA, List<T> ListB)
        {
            return (ListA.Count == ListB.Count && ListA.Count(it => !ListB.Contains(it)) == 0);
        }

        /// <summary>
        /// 移除成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="collection"></param>
        public static void RemoveAll<T>(this ICollection<T> list, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                list.Remove(item);
            }
        }

    }
}
