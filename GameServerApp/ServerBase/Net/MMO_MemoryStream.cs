using ServerBase.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ProtocolMsgBase
{
    public short _protocol;
    public short _result;
    public long Puid;
    public List<long> RspPuids = new List<long>();
    public string Shuttle = string.Empty;
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
}

public class MMO_MemoryStream : MemoryStream
{
    public MMO_MemoryStream()
    {

    }

    public MMO_MemoryStream(byte[] buffer) : base(buffer)
    {

    }

    #region Short
    /// <summary>
    /// 从流中读取一个short数据
    /// </summary>
    /// <returns></returns>
    public void Read(out short v)
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        v = BitConverter.ToInt16(arr, 0);
    }

    /// <summary>
    /// 把一个short数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(short value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion
        
    #region UShort
    /// <summary>
    /// 从流中读取一个ushort数据
    /// </summary>
    /// <returns></returns>
    public void Read(out ushort v)
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        v = BitConverter.ToUInt16(arr, 0);
    }

    /// <summary>
    /// 把一个ushort数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(ushort value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Int
    /// <summary>
    /// 从流中读取一个int数据
    /// </summary>
    /// <returns></returns>
    public void Read(out int v)
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        v = BitConverter.ToInt32(arr, 0);
    }

    /// <summary>
    /// 把一个int数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(int value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region UInt
    /// <summary>
    /// 从流中读取一个uint数据
    /// </summary>
    /// <returns></returns>
    public void Read(out uint v)
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        v = BitConverter.ToUInt32(arr, 0);
    }

    /// <summary>
    /// 把一个uint数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(uint value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Long
    /// <summary>
    /// 从流中读取一个long数据
    /// </summary>
    /// <returns></returns>
    public void Read(out long v)
    {
        byte[] arr = new byte[8];
        base.Read(arr, 0, 8);
        v = BitConverter.ToInt64(arr, 0);
    }

    /// <summary>
    /// 把一个long数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(long value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region ULong
    /// <summary>
    /// 从流中读取一个ulong数据
    /// </summary>
    /// <returns></returns>
    public void Read(out ulong v)
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        v = BitConverter.ToUInt64(arr, 0);
    }

    /// <summary>
    /// 把一个ulong数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(ulong value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Float
    /// <summary>
    /// 从流中读取一个float数据
    /// </summary>
    /// <returns></returns>
    public void Read(out float v)
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        v = BitConverter.ToSingle(arr, 0);
    }

    /// <summary>
    /// 把一个float数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(float value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Double
    /// <summary>
    /// 从流中读取一个double数据
    /// </summary>
    /// <returns></returns>
    public void Read(out double v)
    {
        byte[] arr = new byte[8];
        base.Read(arr, 0, 8);
        v = BitConverter.ToDouble(arr, 0);
    }

    /// <summary>
    /// 把一个double数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(double value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Bool
    /// <summary>
    /// 从流中读取一个bool数据
    /// </summary>
    /// <returns></returns>
    public void Read(out bool v)
    {
        v = base.ReadByte() == 1;
    }

    /// <summary>
    /// 把一个bool数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(bool value)
    {
        base.WriteByte((byte)(value == true ? 1 : 0));
    }
    #endregion
    #region Byte
    /// <summary>
    /// 从流中读取一个byte数据
    /// </summary>
    /// <returns></returns>
    public void Read(out byte v)
    {
        v = (byte)base.ReadByte();
    }

    /// <summary>
    /// 把一个byte数据写入流
    /// </summary>
    /// <param name="value"></param>
    public void Write(byte value)
    {
        base.WriteByte(value);
    }
    #endregion
    #region UTF8String
    /// <summary>
    /// 从流中读取一个sting数组
    /// </summary>
    /// <returns></returns>
    public void Read(out string v)
    {
        this.Read(out ushort len);
        byte[] arr = new byte[len];
        base.Read(arr, 0, len);
        v = Encoding.UTF8.GetString(arr);
    }

    /// <summary>
    /// 把一个string数据写入流
    /// </summary>
    /// <param name="str"></param>
    public void Write(string str)
    {
        if (str == null) str = string.Empty;

        byte[] arr = Encoding.UTF8.GetBytes(str);
        if (arr.Length > 65535)
        {
            throw new InvalidCastException("字符串超出范围");
        }
        Write((ushort)arr.Length);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region DateTime
    /// <summary>
    /// 从流中读取一个DateTime
    /// </summary>
    /// <returns></returns>
    public void Read(out DateTime v)
    {
        Read(out long tick);
        v = new DateTime(tick);
    }

    /// <summary>
    /// 把一个DateTime数据写入流
    /// </summary>
    /// <param name="str"></param>
    public void Write(DateTime v)
    {        
        Write(v.Ticks);        
    }
    #endregion

    #region TimeSpan
    /// <summary>
    /// 从流中读取一个TimeSpan
    /// </summary>
    /// <returns></returns>
    public void Read(out TimeSpan v)
    {
        Read(out long tick);
        v = new TimeSpan(tick);
    }

    /// <summary>
    /// 把一个TimeSpan数据写入流
    /// </summary>
    /// <param name="str"></param>
    public void Write(TimeSpan v)
    {
        Write(v.Ticks);
    }
    #endregion
}