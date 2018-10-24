using ServerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogin
{
    class Program
    {
        private static string ServerType = "登录";
        private static int m_Port = 1034;

        static void Main(string[] args)
        {
            #region 1、日志,配置,建立Socket,监听端口
            BaseProgram.PubMain1(ServerType, m_Port);
            #endregion

            #region 2、连接事件
            Thread mThread = new Thread(ListenClientCallBack);
            mThread.Start();
            #endregion
            Console.ReadLine();
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

                Loger.Debug($"网关{socket.RemoteEndPoint.ToString()}已经连接");

                GameServerSocket clientSocket = new GameServerSocket(socket, null);
                LoginLinkManager.ListClientLink.Add(clientSocket);
                Loger.Debug($"网关个数{LoginLinkManager.ListClientLink.Count}");                
            }
        }
    }
}
