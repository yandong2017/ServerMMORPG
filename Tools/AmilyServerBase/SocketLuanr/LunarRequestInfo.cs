/****************************************************************************
Copyright (c) 2014-2015 凌惊雪 微信:Lingjingxue 邮箱:lingjingxue@sina.com QQ:271487457

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/

using SuperSocket.SocketBase.Protocol;

namespace SuperSocket.SocketLuanr
{
    /// <summary>
    /// 协议请求
    /// </summary>
    public class LunarRequestInfo : RequestInfo<byte[]>
    {
        /// <summary>
        /// 协议ID号
        /// </summary>
        public short ProtocolID { get; set; }

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="body"></param>
        public LunarRequestInfo(byte[] body)
            : base("", body)
        {
            if (body.Length < 2)
            {
                ProtocolID = 0;
            }
            else
            {
                ProtocolID = System.BitConverter.ToInt16(body, 0);
            }
        }
    }
}