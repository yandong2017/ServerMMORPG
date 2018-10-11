using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppClient
{
    public class Program
    {
        public static int maxnum = 0;
        private static string m_ServerIP = "127.0.0.1";
        private static int m_Port = 1038;
        static List<NetWorkSocket> netWorkSockets = new List<NetWorkSocket>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 500; i++)
            {                
                NetWorkSocket nt = new NetWorkSocket(i);
                nt.Connect(m_ServerIP, m_Port);
                netWorkSockets.Add(nt);
            }
            int 退出 = 0;
            while (true)
            {
                foreach (var item in netWorkSockets)
                {
                    item.SendMsg(new byte[] { 5, 1, 1, 1, 1, 1 });
                }
                Thread.Sleep(100);
                退出 += 100;
                if (退出 > 50000)
                {
                    Console.WriteLine("结束");
                    foreach (var item in netWorkSockets)
                    {
                        item.DisConnect();
                    }
                    
                    break;
                }
            }
            Console.ReadLine();
        }

        private static void OnUpdate()
        {
            
            
            
        }
    }
}
