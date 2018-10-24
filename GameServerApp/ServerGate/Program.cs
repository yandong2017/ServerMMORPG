using ServerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerGate
{
    class Program
    {
        private static int m_Port = 1035;
        private static string ServerType = "网关";        

        static void Main(string[] args)
        {
            #region 1、日志,配置,建立Socket,监听端口
            BaseProgram.PubMain1(ServerType, m_Port);
            #endregion

            #region 2、连接事件
            Thread mThread = new Thread(ListenClientCallBack);
            mThread.Start();
            #endregion

            #region 连接其他服务器
            GateClientManager.Start();

            #endregion

            #region 主循环
            while (true)
            {
                Thread.CurrentThread.Join(10);
                try
                {
                    ServerHeartbeat.Heartbeat();
                }
                catch (Exception ex)
                {
                    Loger.Error($"服务器错误{ex}");
                }
            }
            #endregion
        }
        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private static void ListenClientCallBack()
        {
            while (true)
            {
                //接收客户端请求
                Socket socket = BaseServer.ServerSocket.Accept();

                Loger.Debug($"客户端{socket.RemoteEndPoint.ToString()}已经连接");

                GateServerSocket clientSocket = new GateServerSocket(socket, null);
                GateLinkManager.ListClientLink.Add(clientSocket);
                Loger.Debug($"客户端个数{GateLinkManager.ListClientLink.Count}");                
            }
        }
    }
}
