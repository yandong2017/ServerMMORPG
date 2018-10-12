using ServerBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerBase.Client
{
    public class ClientLink
    {
        private Socket clientSocket = null;

        public int LinkType = 0;
        public string LinkIp = "127.0.0.1";
        public int LinkId = 12201;
        public bool LinkState = false;
        public string Desc = "";

        private byte[] ReadM = new byte[65536];
        public int recvoffest = 0;

        //初始化
        public void Setup(string ip, int port, int type = 0,string desc = "")
        {
            LinkIp = ip;
            LinkId = port;
            LinkType = type;
            Desc = desc;
        }

        public bool Start()
        {
            try
            {
                //if (clientSocket != null)
                //{
                //    clientSocket.Close();
                //}
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(LinkIp, LinkId);

                LinkState = true;

                ClientDispatcher.Debug($"连接成功 {Desc} {LinkType} {LinkIp} {LinkId}！");
                               
                //连接后开始从服务器读取网络消息
                clientSocket.BeginReceive(ReadM, recvoffest, 65536 - recvoffest, SocketFlags.None, new System.AsyncCallback(ReceiveCallBack), ReadM);

                return true;
            }
            catch (SocketException)
            {
                clientSocket = null;

                LinkState = false;
                //网络连接异常

                ClientDispatcher.Error($"连接失败 {Desc} {LinkType} {LinkIp} {LinkId}！");

                return false;
            }
        }
        Stopwatch StopwatchProcess;
        //接收网络消息回调函数
        private void ReceiveCallBack(System.IAsyncResult ar)
        {
            int readCount = 0;

            try
            {
                StopwatchProcess = Stopwatch.StartNew();                
                
                 //读取消息长度
                readCount = clientSocket.EndReceive(ar);//调用这个函数来结束本次接收并返回接收到的数据长度。
                recvoffest += readCount;
                if (recvoffest > 65536)
                {
                    ClientDispatcher.Error($"出现Socket异常");
                    return;
                }

                if (readCount <= 0)
                {
                    recvoffest = 0;
                    //disconnect();
                    return;
                }

                DeCodePacket(ref ReadM, ref recvoffest);
            }
            catch (Exception ex)//出现Socket异常就关闭连接
            {
                recvoffest = 0;
                ClientDispatcher.Error($"出现Socket异常 {Desc} {LinkType} {LinkIp} {LinkId}！{ex.Message}");
                // ClientDispatcher.Error($"ReceiveCallBack. PackLeng:{PackLeng} ProtocolId:{ProtocolId}{(EProtocolId)ProtocolId}");
                Disconnect(0);     //这个函数用来关闭客户端连接
                return;
            }
            clientSocket.BeginReceive(ReadM, recvoffest, 65536 - recvoffest, SocketFlags.None, new System.AsyncCallback(ReceiveCallBack), ReadM);
        }
        public ConcurrentQueue<byte[]> ListReq = new ConcurrentQueue<byte[]>();
        private int DeCodePacket(ref byte[] buf, ref int recvOffest)
        {
            int decodeOffest = 0;
            int datalen = 0;
            int head = 0;
            while (recvOffest - decodeOffest >= 6)
            {
                datalen = BitConverter.ToInt32(buf, decodeOffest);
                head = BitConverter.ToUInt16(buf, decodeOffest + 4);
                if (head < 0 || head > 65536)
                {
                    ClientDispatcher.Error($"出现Socket head异常");
                    return 0;
                }
                //if (datalen  < 0 || datalen > 65536)
                //{
                //    ClientDispatcher.Error($"出现Socket datalen 异常");
                //    return 0;
                //}

                if (datalen > recvOffest - (decodeOffest + 4))
                {
                    //continue recv packet
                    break;
                }

                decodeOffest += 4;
                byte[] buffer = new byte[datalen];
                Buffer.BlockCopy(buf, decodeOffest, buffer, 0, datalen);
                decodeOffest += datalen;

                ListReq.Enqueue(buffer);
                //ClientDispatcher.OnReceiveData(buffer);
                StopwatchProcess.Stop();
                var UseMs = StopwatchProcess.ElapsedMilliseconds;
                if (UseMs > maxMs)
                {
                    maxMs = UseMs;
                    ClientDispatcher.Debug($"消息处理最大耗时：{maxMs}毫秒");
                }
            }

            if (decodeOffest > 0 && decodeOffest < recvOffest)
            {
                Buffer.BlockCopy(buf, decodeOffest, buf, 0, recvOffest - decodeOffest);
            }

            recvOffest = recvOffest - decodeOffest;

            return 1;
        }
        long maxMs = 0;
        //解包处理


        //获得包头相关信息
        private void ParsePacketHead(byte[] buf, int index, out int PackLeng, out short ProtocolId)
        {
            PackLeng = BitConverter.ToInt32(buf, index + 0);
            ProtocolId = BitConverter.ToInt16(buf, index + 2);
        }
        //向登录服务器发送数据
        public void Send(INbsSerializer objMsg)
        {
            Send(objMsg.Serialize());
        }

        //向登录服务器发送数据
        public void Send(NetBitStream bts)
        {
            if (clientSocket == null)
            {
                ClientDispatcher.Error("请先连接到服务器！");
                return;
            }
            if (!clientSocket.Connected)
                return;
            //创建NetWorkStream
            NetworkStream ns;
            //加锁，避免在多线程下出问题
            lock (clientSocket)
            {
                ns = new NetworkStream(clientSocket);
            }
            if (ns.CanWrite)
            {
                try
                {
                    ns.BeginWrite(bts.BYTES, 0, bts.Length, new System.AsyncCallback(SendCallBack), ns);
                }
                catch
                {
                    Disconnect(0);
                }
            }
        }       
        private void SendCallBack(System.IAsyncResult ar)
        {
            NetworkStream ns = (NetworkStream)ar.AsyncState;
            try
            {
                ns.EndWrite(ar);
                ns.Flush();
                ns.Close();
            }
            catch
            {
                Disconnect(0);
            }
        }

        //关闭登录连接
        public void Disconnect(int timeout)
        {
            LinkState = false;
            ClientDispatcher.Error($"连接断开 {Desc} {LinkType} {LinkIp} {LinkId}！");
            try
            {
                if (clientSocket == null) return;
                if (clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Receive);
                    clientSocket.Close(timeout);
                }
                else
                {
                    clientSocket.Close();
                }
            }
            catch
            {
            }
        }
    }
}
