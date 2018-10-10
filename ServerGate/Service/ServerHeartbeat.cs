using ServerBase.Dispatch;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerGate.ServerLink;
using System;
using UtilLib;

namespace ServerGate.Service
{
    /// <summary>
    /// 心跳守护
    /// </summary>
    public static class ServerHeartbeat
    {
        // 心跳处理完时间
        private static long TicksEnd = 0;

        // 心跳开始时间
        private static DateTime DtNow = DateTime.Now;
        private static long TicksCur = 0;
        public static DateTime TimeHeartbeat
        {
            get
            {
                return DtNow;
            }
        }

        // 心跳计时
        private static long TicksSecond = 0;
        private static long TicksSecond10 = 0;
        /// <summary>
        /// 服务器心跳
        /// </summary>
        public static void Heartbeat()
        {
            DtNow = DateTime.Now;
            TicksCur = DtNow.Ticks;

            //需要心跳循环的管理器
            //HeartbeatExecute();
            
            //秒心跳
            if (TicksSecond < TicksCur)
            {
                HeartbeatSecond();
                TicksSecond = TicksCur + UtilEnum.每秒的ticks数;
                if (TicksSecond10 < TicksCur)
                {
                    HeartbeatSecond10();
                    TicksSecond10 = TicksCur + 10 * UtilEnum.每秒的ticks数;
                }
           }

            TicksEnd = DateTime.Now.Ticks;

            //如果执行时间超过2秒 提示服务器超载或者是中途逻辑出错
            if (TicksEnd - TicksCur > 2 * UtilEnum.每秒的ticks数)
            {
                loger.Error($"__________等待时间累计超时，耗时:{(TicksEnd - TicksCur) / UtilEnum.每秒的ticks数}秒 连接数:{BaseServerInfo.AppServer.SessionCount} (可能是服务器过载 也可能是服务器内部出错)__________");
            }
        }

        // 心跳循环内容
        public static void HeartbeatExecute()
        {
            foreach (var session in BaseServerInfo.AllSessions.Values)
            {
                if (session != null && session.Connected)
                {
                    while (session.ListReq.TryDequeue(out var msg))
                    {
                        Dispatcher.ProcessMessage(session, msg);
                    }
                }
            }
        }

        // 秒心跳
        public static void HeartbeatSecond()
        {
                       
        }
        // 10秒心跳
        public static void HeartbeatSecond10()
        {
            GateServerLinkManager.HeartbeatSecond10();            
        }
    }
}