using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServerApp
{
    class Program
    {
        private static string m_ServerIP = "127.0.0.1";
        private static int m_Port = 1038;

        private static Socket m_ServerSocket;

        /// <summary>
        /// 初始化所有控制器
        /// </summary>
        static void InitAllController()
        {
            
        }


        static void Main(string[] args)
        {
            InitAllController();

            //实例化socket
            m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //向操作系统申请一个可用的ip和端口用来通讯
            m_ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(m_ServerIP), m_Port));

            //设置最多3000个排队连接请求
            m_ServerSocket.Listen(3000);

            Console.WriteLine("启动监听{0}成功", m_ServerSocket.LocalEndPoint.ToString());

            Thread mThread = new Thread(ListenClientCallBack);
            mThread.Start();

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
                Socket socket = m_ServerSocket.Accept();

                Console.WriteLine("客户端{0}已经连接", socket.RemoteEndPoint.ToString());

                //Console.WriteLine("客户端{0}已经连接", ((IPEndPoint)socket.RemoteEndPoint).Address.ToString());

               
                {

                    //一个角色 就相当于一个客户端                    
                    ClientSocket clientSocket = new ClientSocket(socket);
                    AllSession.All.Enqueue(clientSocket);
                    Console.WriteLine($"客户端个数{AllSession.All.Count}");

                }
            }
        }
    }
}
