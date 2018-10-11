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
        static void Main(string[] args)
        {
            for (int i = 0; i < 500; i++)
            {
                Thread thread = new Thread(OnUpdate);
                thread.Start();                
            }

            Console.ReadLine();
        }

        private static void OnUpdate()
        {
            NetWorkSocket nt = new NetWorkSocket();
            nt.Connect(m_ServerIP, m_Port);
            while (true)
            {
                Thread.Sleep(100);
                nt.SendMsg(new byte[] { 5, 1, 1, 1, 1, 1 });
            }
        }
    }
}
