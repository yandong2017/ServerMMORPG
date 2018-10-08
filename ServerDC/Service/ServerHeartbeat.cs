using ServerBase.Dispatch;
using ServerBase.ServerLoger;
using ServerBase.Service;
using System;
using UtilLib;

namespace ServerLogin.Service
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

        // 心跳计时
        private static long TicksSecond = 0;        
        private static long TicksMinute10 = 0;       

        /// <summary>
        /// 服务器心跳
        /// </summary>
        public static void Heartbeat()
        {
            DtNow = DateTime.Now;
            TicksCur = DtNow.Ticks;

            //需要心跳循环的管理器
            HeartbeatExecute();

            //秒心跳
            if (TicksSecond < TicksCur)
            {
                HeartbeatSecond();
                TicksSecond = TicksCur + UtilEnum.每秒的ticks数;
                                                 
                //10分钟心跳
                if (TicksMinute10 < TicksCur)
                {
                    HeartbeatMinute10();
                    TicksMinute10 = TicksCur + 10 * 60 * UtilEnum.每秒的ticks数;
                } 
            }

            TicksEnd = DateTime.Now.Ticks;

            //如果执行时间超过2秒 提示服务器超载或者是中途逻辑出错
            if (TicksEnd - TicksCur > 2 * UtilEnum.每秒的ticks数)
            {
                loger.Error($"__________等待时间累计超时，耗时:{(TicksEnd - TicksCur) / UtilEnum.每秒的ticks数}秒 连接数:{BaseServerInfo.AppServer.SessionCount}(可能是服务器过载 也可能是服务器内部出错)__________");
            }
        }
               
        // 心跳循环内容
        public static void HeartbeatExecute()
        {
            
        }

        // 秒心跳
        public static void HeartbeatSecond()
        {
                    
        }
                
        // 10分钟心跳
        public static void HeartbeatMinute10()
        {           
            loger.Warn($"服务器十分钟更新");
        }         
    }
}