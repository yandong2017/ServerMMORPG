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
        /// 压缩
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(this byte[] data)
        {
            byte[] compressesData;
            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(data, 0, data.Length);
                }

                compressesData = outputStream.ToArray();
            }

            return compressesData;
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Decompress(this byte[] data, string encoding)
        {
            byte[] decompressedData = null;
            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(data))
                {
                    if (encoding == "gzip")
                        using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                        {
                            zip.CopyTo(outputStream);
                        }
                    else if (encoding == "deflate")
                        using (var zip = new DeflateStream(inputStream, CompressionMode.Decompress))
                        {
                            zip.CopyTo(outputStream);
                        }
                    else
                        throw new ArgumentException(String.Format("Unsupported encoding type \"{0}\".", encoding), "encoding");
                }

                decompressedData = outputStream.ToArray();
            }

            return decompressedData;
        }

    }
}
