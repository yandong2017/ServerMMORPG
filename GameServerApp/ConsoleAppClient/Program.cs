using ServerBase.Protocol;
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
        
        private static string m_ServerIP = "127.0.0.1";
        private static int m_Port = 1038;
        static List<ClientSocket> netWorkSockets = new List<ClientSocket>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 1; i++)
            {
                ClientSocket nt = new ClientSocket(i);
                nt.Connect(m_ServerIP, m_Port);
                netWorkSockets.Add(nt);
            }
            int 退出 = 0;
            while (true)
            {
                foreach (var item in netWorkSockets)
                {
                    var all = new All_Base_Ping();                    
                    item.SendMsg(all.Serialize());
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
