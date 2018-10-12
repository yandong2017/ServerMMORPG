using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerBase.Protocol
{
    [Desc("协议基类")]
    public class ProtocolMsgBase
    {
        [Desc("协议号")]
        public short _protocol;
        [Desc("结果码")]
        public short _result;
        [Desc("Pin码")]
        public long Pin;
        [Desc("玩家唯一ID")]
        public long Puid;
        [Desc("附加中转信息")]
        public string Shuttle = "";
        public EProtocolId ProtocolId
        {
            get { return (EProtocolId)_protocol; }
            set { _protocol = (short)value; }
        }
        public EProtocolResult Result
        {
            get { return (EProtocolResult)_result; }
            set { _result = (short)value; }
        }
        //判断是否正常
        public bool Success
        {
            get { return (_result == 0); }
        }
        //同步中转数据
        public void Sync(ProtocolMsgBase v)
        {
            _result = v._result;
            Pin = v.Pin;
            Puid = v.Puid;
            Shuttle = v.Shuttle;
        }
        //同步中转数据
        public void ShuttleAppend(object v)
        {
            Shuttle = string.Format("{0}|{1}", Shuttle, v);
        }
    }

    /// <summary>
    /// 序列化反序列化接口
    /// </summary>
    public interface INbsSerializer
    {
        NetBitStream Serialize();

        void Unserialize(byte[] buffer);
    }

    /// <summary>
    /// 属性字符串
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class DescAttribute : Attribute
    {
        public string DescStr { get; set; }
        public DescAttribute(string v) { DescStr = v; }
    }


    /// <summary>
    /// 数据体类
    /// </summary>
    public class NetBitStream
    {
        //单位容量长度
        public const int capacity_length = 1024;
        //包长 长度
        public const int header_length = 4;
        //协议号 长度
        public const int protocolId_length = 2;

        //容量
        public int capacity = 1;
        //包长度
        public int max_body_length = 1024;

        //包
        private byte[] buf = null;

        public byte[] BYTES
        {
            get
            {
                return buf;
            }
            set
            {
                buf = value;
            }
        }


        // 当前数据体长
        private int dataLen = 0;
        //读取偏移
        public int offset = 0;

        public int BodyLength
        {
            get
            {
                return dataLen;
            }
            set
            {
                dataLen = value;
            }
        }

        //byte 数组总长
        public int Length
        {
            get
            {
                return header_length + dataLen;
            }
        }

        // 构造函数
        public NetBitStream()
        {
            capacity = 1;
            dataLen = 0;
            max_body_length = capacity_length * capacity;
            buf = new byte[header_length + max_body_length];
            buf.Initialize();
        }

        //扩容
        protected void ReserveCoreCount(int v = 1)
        {
            capacity += v;
            max_body_length = capacity_length * capacity;
            Array.Resize(ref buf, header_length + max_body_length);
        }

        //扩容
        protected void ReserveCoreLength(int v = 1)
        {
            max_body_length = v;
            Array.Resize(ref buf, header_length + max_body_length);
        }

        #region 写入

        //写入完成 把长度写在头四位
        public void WriteEnd()
        {
            buf[0] = (byte)(dataLen & 0xff);
            buf[1] = (byte)((dataLen & 0xff00) >> 8);
            buf[2] = (byte)((dataLen & 0xff0000) >> 16);
            buf[3] = (byte)((dataLen & 0xff000000) >> 24);
        }

        //写入一个bool
        public void Write(bool v)
        {
            Write(v ? (byte)1 : (byte)0);
        }

        //写入一个byte
        public void Write(byte v)
        {
            //检测 如果长度超过byte 数组最大值，退出
            if (header_length + dataLen + 1 > max_body_length)
                ReserveCoreCount();
            buf[header_length + dataLen] = v;
            dataLen += 1;
        }

        //写入短整型
        public void Write(short v)
        {
            Write((ushort)v);
        }

        //写入无符号短整型
        public void Write(ushort v)
        {
            if (header_length + dataLen + 2 > max_body_length)
                ReserveCoreCount();
            buf[header_length + dataLen] = (byte)(v & 0xff);
            buf[header_length + dataLen + 1] = (byte)((v & 0xff00) >> 8);
            dataLen += 2;
        }

        //写整型
        public void Write(int v)
        {
            Write((uint)v);
        }

        //写入无符号整数
        public void Write(uint v)
        {
            if (header_length + dataLen + 4 > max_body_length)
                ReserveCoreCount();
            buf[header_length + dataLen] = (byte)(v & 0xff);
            buf[header_length + dataLen + 1] = (byte)((v & 0xff00) >> 8);
            buf[header_length + dataLen + 2] = (byte)((v & 0xff0000) >> 16);
            buf[header_length + dataLen + 3] = (byte)((v & 0xff000000) >> 24);
            dataLen += 4;
        }

        //写入有符号INT64
        public void Write(long v)
        {
            Write((ulong)v);
        }

        //写入无符号INT64
        public void Write(ulong v)
        {
            if (header_length + dataLen + 8 > max_body_length)
                ReserveCoreCount();
            buf[header_length + dataLen + 0] = (byte)v;
            buf[header_length + dataLen + 1] = (byte)(v >> 8);
            buf[header_length + dataLen + 2] = (byte)(v >> 16);
            buf[header_length + dataLen + 3] = (byte)(v >> 24);
            buf[header_length + dataLen + 4] = (byte)(v >> 32);
            buf[header_length + dataLen + 5] = (byte)(v >> 40);
            buf[header_length + dataLen + 6] = (byte)(v >> 48);
            buf[header_length + dataLen + 7] = (byte)(v >> 56);
            dataLen += 8;
        }

        //写入浮点数
        public void Write(float v)
        {
            var tmpbuf = BitConverter.GetBytes(v);
            if (header_length + dataLen + 4 > max_body_length)
                ReserveCoreCount();
            Array.Copy(tmpbuf, 0, buf, header_length + dataLen, 4);
            dataLen += 4;
        }

        //写入字符串 因为字符串的长度不固定，所以写入字符串时是发送两条数据(ushort型的长度 + 字符串本身)
        public void Write(string v)
        {
            //loger.Error($". ");
            var sbuf = System.Text.Encoding.UTF8.GetBytes(v);
            ushort sbufLen = (ushort)sbuf.Length;
            Write(sbufLen);
            if (header_length + dataLen + sbufLen > max_body_length)
            {
                //ReserveCoreCount();
                ReserveCoreLength(header_length + dataLen + sbufLen);
            }
            Array.Copy(sbuf, 0, buf, header_length + dataLen, sbufLen);
            dataLen += sbufLen;
        }

        //写入DateTime
        public void Write(DateTime v)
        {
            Write(v.Ticks);
        }
        //写入TimeSpan
        public void Write(TimeSpan v)
        {
            Write(v.Ticks);
        }

        #endregion 写入

        #region 读取

        //相关读出数据
        public void BeginReadWithLength(byte[] buffer)
        {
            buf = buffer;
        }

        //相关读出数据
        public void BeginRead(byte[] buffer)
        {
            if (buf.Length < (buffer.Length + header_length))
            {
                ReserveCoreLength(buffer.Length);
            }
            buffer.CopyTo(buf, header_length);
            offset = header_length;
        }

        //读取bool
        public bool ReadBool()
        {
            bool v = (buf[offset++] == 1);
            return v;
        }

        //读取一个bool
        public void Read(out bool v)
        {
            v = ReadBool();
        }

        //读取byte
        public byte ReadByte()
        {
            byte v = buf[offset++];
            return v;
        }

        //读取一个byte
        public void Read(out byte v)
        {
            v = ReadByte();
        }

        //读取short
        public short ReadShort()
        {
            short v = (short)((0xff & buf[offset])
                | (0xff00 & (buf[offset + 1] << 8)));
            offset += 2;
            return v;
        }

        //读取short
        public void Read(out short v)
        {
            v = ReadShort();
        }

        //读取ushort
        public ushort ReadUshort()
        {
            ushort v = (ushort)((0xff & buf[offset])
                | (0xff00 & (buf[offset + 1] << 8)));
            offset += 2;
            return v;
        }

        //读取ushort
        public void Read(out ushort v)
        {
            v = ReadUshort();
        }

        //读取int
        public int ReadInt()
        {
            int v = buf[offset]
                | (buf[offset + 1] << 8)
                | (buf[offset + 2] << 16)
                | (buf[offset + 3] << 24);
            offset += 4;
            return v;
        }

        //读取int
        public void Read(out int v)
        {
            v = ReadInt();
        }

        //读取uint
        public uint ReadUint()
        {
            uint v = (uint)(buf[offset]
                | (buf[offset + 1] << 8)
                | (buf[offset + 2] << 16)
                | (buf[offset + 3] << 24));
            offset += 4;
            return v;
        }

        //读取uint
        public void Read(out uint v)
        {
            v = ReadUint();
        }

        //读取long
        public long ReadLong()
        {
            long v = ((long)buf[offset])
                | (((long)buf[offset + 1] << 8))
                | (((long)buf[offset + 2] << 16))
                | (((long)buf[offset + 3] << 24))
                | (((long)buf[offset + 4] << 32))
                | (((long)buf[offset + 5] << 40))
                | (((long)buf[offset + 6] << 48))
                | (((long)buf[offset + 7] << 56));
            offset += 8;
            return v;
        }

        //读取long
        public void Read(out long v)
        {
            v = ReadLong();
        }

        //读取float
        public float ReadFloat()
        {
            float v = BitConverter.ToSingle(buf, offset);
            offset += 4;
            return v;
        }

        //读取float
        public void Read(out float v)
        {
            v = ReadFloat();
        }

        //读取string 与写入时一样 首先读取一个ushort，它是字符串的长度 然后再读取字符串
        public string ReadString()
        {
            string v = "";
            ushort len = ReadUshort();
            v = System.Text.Encoding.UTF8.GetString(buf, offset, len);
            offset += len;
            return v;
        }

        //读取string
        public void Read(out string v)
        {
            v = ReadString();
        }

        //读取DateTime
        public DateTime ReadDateTime()
        {
            long v = ReadLong();
            return new DateTime(v);
        }

        //读取DateTime
        public void Read(out DateTime v)
        {
            v = ReadDateTime();
        }

        //读取TimeSpan
        public TimeSpan ReadTimeSpan()
        {
            long v = ReadLong();
            return new TimeSpan(v);
        }

        //读取TimeSpan
        public void Read(out TimeSpan v)
        {
            v = ReadTimeSpan();
        }

        #endregion 读取

        #region 截取

        //获取协议号
        public ushort ReadProtocolHeader()
        {
            if (dataLen + 2 > buf.Length)
                return 0;
            ushort v = BitConverter.ToUInt16(buf, header_length);
            return v;
        }

        //获取错误码
        public ushort ReadProtocolResult()
        {
            if (dataLen + 2 > buf.Length)
                return 0;
            ushort v = BitConverter.ToUInt16(buf, header_length + 2);
            return v;
        }

        //获取协议结构本体
        public byte[] ReadProtocolBody()
        {
            byte[] bByte = new byte[max_body_length];
            Array.Copy(buf, header_length, bByte, 0, dataLen);
            return bByte;
        }

        //获取协议结构截断包(协议号 + 本体)
        public byte[] ProtocolMsg
        {
            get
            {
                byte[] bByte = new byte[dataLen];
                Array.Copy(buf, header_length, bByte, 0, dataLen);
                return bByte;
            }
        }

        //获取协议结构截断包(本体 无 长度+协议号)
        public byte[] ProtocolBody
        {
            get
            {
                byte[] bByte = new byte[dataLen - protocolId_length];
                Array.Copy(buf, (header_length + protocolId_length), bByte, 0, (dataLen - protocolId_length));
                return bByte;
            }
        }

        #endregion



        #region 打印

        public void Dump(ref StringBuilder s)
        {
            Dump(ref s, buf, dataLen);
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            Dump(ref s);
            return s.ToString();
        }


        protected static void DumpAscII(ref StringBuilder s, byte[] buf, int offset, int len)
        {
            for (int i = offset; i < offset + len; ++i)
            {
                byte c = buf[i];
                if (c < 32 || c > 126)
                    s.Append('.');
                else
                    s.Append((char)c);
            }
        }

        // write buf's binary dump text to s
        protected static void Dump(ref StringBuilder s, byte[] buf, int len = 0)
        {
            if (buf == null || buf.Length == 0)
                return;
            if (len == 0)
                len = buf.Length;
            s.Append("--------  0  1  2  3 | 4  5  6  7 | 8  9  A  B | C  D  E  F");
            s.Append("   dataLen = " + len);
            int i = 0;
            for (; i < len; ++i)
            {
                if ((i % 16) == 0)
                {
                    if (i > 0)
                    {           // output ascii to the end of the line
                        s.Append("  ");
                        DumpAscII(ref s, buf, i - 16, 16);
                    }
                    s.Append('\n');
                    s.Append(i.ToString("x8"));
                    s.Append("  ");
                }
                else if ((i > 0 && (i % 4 == 0)))
                {
                    s.Append("  ");
                }
                else
                    s.Append(' ');
                s.Append(BitConverter.ToString(buf, i, 1));
            }
            int left = i % 16;
            if (left == 0)
            {
                left = 16;
            }
            if (left > 0)
            {
                len = len + 16 - left;
                for (; i < len; ++i)
                {
                    if (i > 0 && (i % 4 == 0))
                        s.Append("  ");
                    else
                        s.Append(' ');
                    s.Append("  ");
                }
                s.Append("  ");
                DumpAscII(ref s, buf, i - 16, left);
            }
            s.Append('\n');
        }

        protected static string Dump(byte[] buf, int len = 0)
        {
            var sb = new StringBuilder();
            Dump(ref sb, buf, len);
            return sb.ToString();
        }

        #endregion

    }
}
