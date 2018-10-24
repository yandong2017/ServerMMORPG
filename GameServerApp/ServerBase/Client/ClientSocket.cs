using ServerBase;
using ServerBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/// <summary>>
/// 网络传输Socket
/// </summary>
public abstract class ClientSocket
{
    #region 发送消息所需变量
    //发送消息队列
    private ConcurrentQueue<byte[]> m_SendQueue = new ConcurrentQueue<byte[]>();

    //检查队列的委托
    private Action m_CheckSendQuene;

    //压缩数组的长度界限
    private const int m_CompressLen = 200000;
    #endregion

    //是否连接成功
    public bool IsConnectedOk
    {
        get
        {
            if (m_Client == null)
            {
                return false;
            }
            return m_Client.Connected;
        }
    }

    #region 接收消息所需变量
    //接收数据包的字节数组缓冲区
    private byte[] m_ReceiveBuffer = new byte[1024];

    //接收数据包的缓冲数据流
    private MMO_MemoryStream m_ReceiveMS = new MMO_MemoryStream();

    //接收消息的队列
    private ConcurrentQueue<byte[]> m_ReceiveQueue = new ConcurrentQueue<byte[]>();

    private int m_ReceiveCount = 0;
    #endregion

    /// <summary>
    /// 客户端socket
    /// </summary>
    private Socket m_Client;
    /// <summary>
    /// 通知一个或多个正在等待的线程已发生事件
    /// </summary>
    protected ManualResetEvent are = new ManualResetEvent(false);

    public Action OnConnectOK;
    Thread thread;
    public ClientSocket(int Id = 0)
    {
        id = Id;
        

    }
    public int id = 0;
    public static int maxnum = 0;
    protected void OnUpdate()
    {
        while (true)
        {
            //if (m_IsConnectedOk)
            //{
            //    m_IsConnectedOk = false;
            //    if (OnConnectOK != null)
            //    {
            //        OnConnectOK();
            //    }
            //    //Console.WriteLine("连接成功");
            //}

            #region 从队列中获取数据
            while (m_ReceiveQueue.Count > 0)
            {
                if (m_ReceiveQueue.Count > maxnum)
                {
                    maxnum = m_ReceiveQueue.Count;
                    Loger.Debug($"{DateTime.Now}:{DateTime.Now.Millisecond} {id}接收队列{maxnum}");
                }
                if (!m_ReceiveQueue.TryDequeue(out var buffer))
                {
                    break;
                }
                var protoCodeArr = new byte[2];
                Array.Copy(buffer, protoCodeArr, protoCodeArr.Length);                
                //异或之后的数组
                short protoCode = BitConverter.ToInt16(protoCodeArr, 0);
                ProcessMessage(protoCode, buffer);
            }
            are.Reset();
            /*队列为空等待200毫秒继续*/
            are.WaitOne(100);
        }
        #endregion
    }
    public void ProcessMessage(short protoCode, byte[] buffer)
    {        
        if (protoCode == (short)EProtocolId.ALL_BASE_PING)
        {
            All_Base_Ping all = new All_Base_Ping(buffer);
            Loger.Debug(all.ServerTime.ToString());
        }
    }

    #region Connect 连接到socket服务器
    /// <summary>
    /// 连接到socket服务器
    /// </summary>
    /// <param name="ip">ip</param>
    /// <param name="port">端口号</param>
    public void Connect(string ip, int port)
    {
        //如果socket已经存在 并且处于连接中状态 则直接返回
        if (m_Client != null && m_Client.Connected) return;

        m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        if (thread != null)
        {
            thread.Abort();
        }

        try
        {
            m_Client.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), port), ConnectCallBack, m_Client);

        }
        catch (Exception ex)
        {
            Loger.Error("连接失败=" + ex.Message);
        }
    }

    private void ConnectCallBack(IAsyncResult ar)
    {
        if (m_Client.Connected)
        {
            Loger.Debug("socket连接成功");
            thread = new Thread(OnUpdate);
            thread.Start();

            m_CheckSendQuene = OnCheckSendQueueCallBack;

            ReceiveMsg();
            
            m_Client.EndConnect(ar);
        }
        else
        {
            Loger.Error("socket连接失败");
        }
        
    }
    #endregion

    /// <summary>
    /// 断开连接
    /// </summary>
    public void DisConnect()
    {
        if (m_Client != null && m_Client.Connected)
        {
            m_Client.Shutdown(SocketShutdown.Both);
            m_Client.Close();
        }
        thread.Abort();
    }

    #region OnCheckSendQueueCallBack 检查队列的委托回调
    /// <summary>
    /// 检查队列的委托回调
    /// </summary>
    private void OnCheckSendQueueCallBack()
    {
        //lock (m_SendQueue)
        {
            //如果队列中有数据包 则发送数据包
            if (m_SendQueue.Count > 0)
            {
                //发送数据包
                //Send(m_SendQueue.Dequeue());
                if (m_SendQueue.TryDequeue(out var msg))
                {
                    Send(msg);
                }
            }
        }
    }
    #endregion

    #region MakeData 封装数据包
    /// <summary>
    /// 封装数据包
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private byte[] MakeData(byte[] data)
    {
        byte[] retBuffer = null;

        using (MMO_MemoryStream ms = new MMO_MemoryStream())
        {
            ms.Write((ushort)(data.Length));
            ms.Write(data, 0, data.Length);
            retBuffer = ms.ToArray();
        }
        return retBuffer;
    }
    #endregion

    #region SendMsg 发送消息 把消息加入队列
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="buffer"></param>
    public void SendMsg(byte[] buffer)
    {
        //得到封装后的数据包
        byte[] sendBuffer = MakeData(buffer);

        //lock (m_SendQueue)
        {
            //把数据包加入队列
            m_SendQueue.Enqueue(sendBuffer);

            if (m_CheckSendQuene == null) return;
            //启动委托（执行委托）
            m_CheckSendQuene.BeginInvoke(null, null);
        }
    }
    #endregion

    #region Send 真正发送数据包到服务器
    /// <summary>
    /// 真正发送数据包到服务器
    /// </summary>
    /// <param name="buffer"></param>
    private void Send(byte[] buffer)
    {
        //Console.WriteLine($"{DateTime.Now}:{DateTime.Now.Millisecond} 发送消息");
        m_Client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, m_Client);
    }
    #endregion

    #region SendCallBack 发送数据包的回调
    /// <summary>
    /// 发送数据包的回调
    /// </summary>
    /// <param name="ar"></param>
    private void SendCallBack(IAsyncResult ar)
    {
        m_Client.EndSend(ar);

        //继续检查队列
        OnCheckSendQueueCallBack();
    }
    #endregion

    //====================================================

    #region ReceiveMsg 接收数据
    /// <summary>
    /// 接收数据
    /// </summary>
    private void ReceiveMsg()
    {
        //异步接收数据
        m_Client.BeginReceive(m_ReceiveBuffer, 0, m_ReceiveBuffer.Length, SocketFlags.None, ReceiveCallBack, m_Client);
    }
    #endregion

    #region ReceiveCallBack 接收数据回调    
    /// <summary>
    /// 接收数据回调
    /// </summary>
    /// <param name="ar"></param>
    private void ReceiveCallBack(IAsyncResult ar)
    {
        try
        {
            int len = m_Client.EndReceive(ar);

            if (len > 0)
            {
                //已经接收到数据

                //把接收到数据 写入缓冲数据流的尾部
                m_ReceiveMS.Position = m_ReceiveMS.Length;

                //把指定长度的字节 写入数据流
                m_ReceiveMS.Write(m_ReceiveBuffer, 0, len);

                //如果缓存数据流的长度>2 说明至少有个不完整的包过来了
                //为什么这里是2 因为我们客户端封装数据包 用的ushort 长度就是2
                if (m_ReceiveMS.Length > 2)
                {
                    //进行循环 拆分数据包
                    while (true)
                    {
                        //把数据流指针位置放在0处
                        m_ReceiveMS.Position = 0;

                        //currMsgLen = 包体的长度
                        m_ReceiveMS.Read(out ushort currMsgLen);

                        //currFullMsgLen 总包的长度=包头长度+包体长度
                        int currFullMsgLen = 2 + currMsgLen;

                        //如果数据流的长度>=整包的长度 说明至少收到了一个完整包
                        if (m_ReceiveMS.Length >= currFullMsgLen)
                        {
                            //至少收到一个完整包

                            //定义包体的byte[]数组
                            byte[] buffer = new byte[currMsgLen];

                            //把数据流指针放到2的位置 也就是包体的位置
                            m_ReceiveMS.Position = 2;

                            //把包体读到byte[]数组
                            m_ReceiveMS.Read(buffer, 0, currMsgLen);

                            //lock (m_ReceiveQueue)
                            {
                                m_ReceiveQueue.Enqueue(buffer);
                                are.Set();
                            }
                            //==============处理剩余字节数组===================

                            //剩余字节长度
                            int remainLen = (int)m_ReceiveMS.Length - currFullMsgLen;
                            if (remainLen > 0)
                            {
                                //把指针放在第一个包的尾部
                                m_ReceiveMS.Position = currFullMsgLen;

                                //定义剩余字节数组
                                byte[] remainBuffer = new byte[remainLen];

                                //把数据流读到剩余字节数组
                                m_ReceiveMS.Read(remainBuffer, 0, remainLen);

                                //清空数据流
                                m_ReceiveMS.Position = 0;
                                m_ReceiveMS.SetLength(0);

                                //把剩余字节数组重新写入数据流
                                m_ReceiveMS.Write(remainBuffer, 0, remainBuffer.Length);

                                remainBuffer = null;
                            }
                            else
                            {
                                //没有剩余字节

                                //清空数据流
                                m_ReceiveMS.Position = 0;
                                m_ReceiveMS.SetLength(0);

                                break;
                            }
                        }
                        else
                        {
                            //还没有收到完整包
                            break;
                        }
                    }
                }

                //进行下一次接收数据包
                ReceiveMsg();
            }
            else
            {
                //客户端断开连接
                Loger.Debug(string.Format("服务器{0}断开连接", m_Client.RemoteEndPoint.ToString()));
            }
        }
        catch
        {
            //客户端断开连接
            Loger.Debug(string.Format("服务器断开连接"));
        }
    }
    #endregion
}