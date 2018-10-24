using ServerBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerBase
{
    /// <summary>
    /// 客户端连接对象 负责和客户端进行通讯的
    /// </summary>
    public abstract class ServerSocket
    {       
        //客户端Socket
        private Socket m_Socket;

        //接收数据的线程
        private Thread m_ReceiveThread;

       
        #region 接收消息所需变量
        //接收数据包的字节数组缓冲区
        private byte[] m_ReceiveBuffer = new byte[2048];

        //接收数据包的缓冲数据流
        private MMO_MemoryStream m_ReceiveMS = new MMO_MemoryStream();
        #endregion

        #region 发送消息所需变量
        //发送消息队列
        private ConcurrentQueue<byte[]> m_SendQueue = new ConcurrentQueue<byte[]>();

        //检查队列的委托
        private Action m_CheckSendQuene;
        
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="role"></param>
        public ServerSocket(Socket socket)
        {
            m_Socket = socket;
            
            //启动线程 进行接收数据
            m_ReceiveThread = new Thread(ReceiveMsg);
            m_ReceiveThread.Start();

            m_CheckSendQuene = OnCheckSendQueueCallBack;
        }

        #region ReceiveMsg 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveMsg()
        {
            //异步接收数据
            m_Socket.BeginReceive(m_ReceiveBuffer, 0, m_ReceiveBuffer.Length, SocketFlags.None, ReceiveCallBack, m_Socket);
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
                int len = m_Socket.EndReceive(ar);

                if (len > 0)
                {
                    //已经接收到数据
                    //Console.WriteLine($"{DateTime.Now}:{DateTime.Now.Millisecond} 接收到数据");
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
                                //把数据流指针放到2的位置 也就是包体的位置
                                m_ReceiveMS.Position = 2;

                                //定义包体的byte[]数组
                                byte[] buffer = new byte[currMsgLen];

                                //把包体读到byte[]数组
                                m_ReceiveMS.Read(buffer, 0, currMsgLen);

                                //===================================================

                                //协议编号
                                //BaseServer.ReceiveQueue.Enqueue(buffer);
                                var protoCodeArr = new byte[2];
                                Array.Copy(buffer, protoCodeArr, protoCodeArr.Length);
                                //异或之后的数组
                                short protoCode = BitConverter.ToInt16(protoCodeArr, 0);

                                ProcessMessage(protoCode,buffer);
                                //EventDispatcher.Instance.Dispatch(protoCode, m_Role, protoContent);                                

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
                    Loger.Debug($"客户端{m_Socket.RemoteEndPoint.ToString()}断开连接");
                    
                }
            }
            catch(Exception ex)
            {
                //客户端断开连接
                Loger.Debug($"客户端{m_Socket.RemoteEndPoint.ToString()}断开连接 原因{1}", ex);
                
            }
        }

        public abstract void ProcessMessage(short protoCode, byte[] buffer);        
        #endregion


        //========================================================


        #region OnCheckSendQueueCallBack 检查队列的委托回调
        /// <summary>
        /// 检查队列的委托回调
        /// </summary>
        private void OnCheckSendQueueCallBack()
        {
            //lock(m_SendQueue)
            {
                //如果队列中有数据包 则发送数据包
                if (m_SendQueue.Count > 0)
                {
                    //发送数据包
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
            try
            {
                m_Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, m_Socket);
            }
            catch (Exception ex)
            {
                Loger.Debug($"{DateTime.Now}:{DateTime.Now.Millisecond} 发送错误！{ex.Message}");
            }
        }
        #endregion

        #region SendCallBack 发送数据包的回调
        /// <summary>
        /// 发送数据包的回调
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallBack(IAsyncResult ar)
        {
            m_Socket.EndSend(ar);

            //继续检查队列
            OnCheckSendQueueCallBack();
        }
        #endregion
    }
}