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

using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using System;

namespace SuperSocket.SocketLuanr
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public class LunarReceiveFilter : FixedHeaderReceiveFilter<LunarRequestInfo>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public LunarReceiveFilter()
            : base(4)
        {
        }

        /// <summary>
        /// 获取长度
        /// </summary>
        /// <param name="header"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            int iLength = BitConverter.ToInt32(header, offset);
            return iLength;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="header"></param>
        /// <param name="bodyBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override LunarRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            return new LunarRequestInfo(bodyBuffer.CloneRange(offset, length));
        }
    }
}