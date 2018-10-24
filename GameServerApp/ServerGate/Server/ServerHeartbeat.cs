using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGate
{
    public class ServerHeartbeat
    {
        public const long 每秒的ticks数 = 1000_0000;
        private static long TicksCur = 0;

        // 心跳计时
        private static long TicksSecond = 0;
        private static long TicksSecond10 = 0;

        internal static void Heartbeat()
        {            
            TicksCur = DateTime.Now.Ticks;

            //需要心跳循环的管理器
            HeartbeatExecute();

            //秒心跳
            if (TicksSecond < TicksCur)
            {
               // HeartbeatSecond();
                TicksSecond = TicksCur + 每秒的ticks数;
                if (TicksSecond10 < TicksCur)
                {
                    HeartbeatSecond10();
                    TicksSecond10 = TicksCur + 10 * 每秒的ticks数;
                }
            }
        }

        private static void HeartbeatExecute()
        {
            
        }

        // 10秒心跳
        public static void HeartbeatSecond10()
        {
            GateClientManager.AutoCheckLink();
        }
    }
}
