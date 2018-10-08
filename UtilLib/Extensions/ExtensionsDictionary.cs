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
        /// <param name="ListListInt"></param>
        /// <returns></returns>
        public static Dictionary<int, int> ToDictionaryInt(this List<List<int>> ListListInt)
        {
            var result = new Dictionary<int, int>();
            foreach (var node in ListListInt)
            {
                if (node.Count >= 2)
                {
                    result[node[0]] = node[1];
                }
            }
            return result;
        }

    }
}
