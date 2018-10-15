using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTool
{
    partial class Program
    {
        // string->int
        public static int S2I(string str)
        {
            int.TryParse(str, out int result);
            return result;
        }
        //string->List(string)
        public static void StrTo(string str, ref List<string> result, string strSeparator)
        {
            string[] arraySeparators = new string[] { strSeparator };
            string[] nodes = str.Split(arraySeparators, StringSplitOptions.RemoveEmptyEntries);
            result = nodes.ToList();
        }
        // 获取父目录
        public static string GetParentFolder(string dir, int layer = 1)
        {
            string result = dir;
            try
            {
                for (int i = 0; i < layer; i++)
                {
                    result = Directory.GetParent(result).FullName;
                }
            }
            catch
            {
            }
            return result;
        }

    }
}
