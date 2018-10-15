using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool
{
    public static class XGlobal
    {
        /// <summary>
        /// 获取父目录
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filename"></param>
        public static void DeleteFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
        /// <summary>
        /// 清空目录
        /// </summary>
        /// <param name="dir"></param>
        public static void EmptyFolder(string dir)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        File.Delete(d);
                    }
                    else
                    {
                        DeleteFolder(d);
                    }
                }
            }
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir))
            {
                EmptyFolder(dir);
                Directory.Delete(dir);
            }
        }


    }
}
