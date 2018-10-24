using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerBase
{
    public class BaseServer
    {
        public static Socket ServerSocket;
        public static ConcurrentQueue<byte[]> ReceiveQueue = new ConcurrentQueue<byte[]>();

        public static void Setup(string ip,int prot)
        {
            //实例化socket
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //向操作系统申请一个可用的ip和端口用来通讯
            ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), prot));

            //设置最多3000个排队连接请求
            ServerSocket.Listen(3000);
        }
    }
}
