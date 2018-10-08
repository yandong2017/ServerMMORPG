using UtilLib;
using ServerBase.DataBaseMysql;
using ServerBase.ServerLoger;
using ServerGame.Manager;
using ServerGame.ServerLink;
using System;
using ServerBase.Config;
using ServerBase.Service;
using ServerBase.BaseObjects;
using ServerBase.Dispatch;
using ServerBase.BaseManagers;
using ServerBase.IniFile;
using System.Collections.Generic;

namespace ServerGame.Service
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
        private static long TicksSecond3 = 0;
        private static long TicksSecond10 = 0;
        private static long TicksMinute = 0;
        private static long TicksMinute10 = 0;
        private static long TicksHour = 0;

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

                //3秒心跳
                if (TicksSecond3 < TicksCur)
                {
                    HeartbeatSecond3();
                    TicksSecond3 = TicksCur + 3 * UtilEnum.每秒的ticks数;
                }

                //10秒心跳
                if (TicksSecond10 < TicksCur)
                {
                    HeartbeatSecond10();
                    TicksSecond10 = TicksCur + 10 * UtilEnum.每秒的ticks数;

                    //分钟心跳
                    if (TicksMinute < TicksCur)
                    {
                        HeartbeatMinute();
                        TicksMinute = TicksCur + 60 * UtilEnum.每秒的ticks数;
                    }
                    //10分钟心跳
                    if (TicksMinute10 < TicksCur)
                    {
                        HeartbeatMinute10();
                        TicksMinute10 = TicksCur + 10 * 60 * UtilEnum.每秒的ticks数;
                    }
                    //小时心跳
                    if (TicksHour < TicksCur)
                    {
                        HeartbeatHour();
                        TicksHour = TicksCur + 3600 * UtilEnum.每秒的ticks数;
                    }
                    //整点心跳
                    if (!DtNow.SameOClock(BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.日整点)))
                    {
                        DayUpdateDayOClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.日整点, DtNow);
                    }
                    //日更新
                    if (!DtNow.SameDay(BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.日更新)))
                    {
                        DayUpdateDayZeroOClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.日更新, DtNow);
                    }
                    //五点心跳
                    var DtDay5 = BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.日五点);
                    if (DtDay5.Equals(new DateTime())
                        || ((DtDay5 > new DateTime().AddHours(5)) && (!DtNow.AddHours(-5).SameDay(DtDay5.AddHours(-5)))))
                    {
                        DayUpdateDayFiveOClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.日五点, DtNow);
                    }
                    //日6点
                    var DtDay6 = BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.日六点);
                    if (DtDay6.Equals(new DateTime())
                        || ((DtDay6 > new DateTime().AddHours(6)) && (!(DtNow.AddHours(-6)).SameDay(DtDay6.AddHours(-6)))))
                    {
                        DayUpdateDaySixOClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.日六点, DtNow);
                    }
                    //日结束
                    var DtDay2359 = BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.日结束);
                    if (DtDay2359.Equals(new DateTime())
                        || ((DtDay2359 > new DateTime().AddMinutes(1438)) && (!(DtNow.AddMinutes(-1438)).SameDay(DtDay2359.AddMinutes(-1438)))))
                    {
                        DayUpdateDay2359OClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.日结束, DtNow);
                    }
                    //周更新
                    if (!DtNow.SameWeek(BaseServerManager.DatasServerBase.GetBaseDatetime(EBaseDatetimeKey.周更新)))
                    {
                        DayUpdateWeekZeroOClock();
                        BaseServerManager.DatasServerBase.SetBaseDatetime(EBaseDatetimeKey.周更新, DtNow);
                    }
                }
            }

            TicksEnd = DateTime.Now.Ticks;

            //如果执行时间超过2秒 提示服务器超载或者是中途逻辑出错
            if (TicksEnd - TicksCur > 2 * UtilEnum.每秒的ticks数)
            {
                loger.Error($"__________等待时间累计超时，耗时:{(TicksEnd - TicksCur) / UtilEnum.每秒的ticks数}秒 连接数:{BaseServerInfo.AppServer.SessionCount} (可能是服务器过载 也可能是服务器内部出错)__________");
            }
        }
               
        private static void DayUpdateDayOClock()
        {

            loger.Info($"服务器整点更新");
        }

        // 心跳循环内容
        public static void HeartbeatExecute()
        {
            PlayerManager.Heartbeat();
        }

        // 秒心跳
        public static void HeartbeatSecond()
        {       
            HeartbeatManager.HeartbeatAllPlayerSecond();
        }

        // 3秒心跳
        public static void HeartbeatSecond3()
        {

        }

        // 10秒心跳
        public static void HeartbeatSecond10()
        {
            GameServerLinkManager.HeartbeatSecond10();

            HeartbeatManager.HeartbeatAllPlayerSecond10();            
        }

        // 分钟心跳
        public static void HeartbeatMinute()
        {
            //重置一下随机数
            Util.RandomReset();

            GameServerLinkManager.HeartbeatMinute();
                       
            loger.Info($"服务器分钟更新");
        }

        // 10分钟心跳
        public static void HeartbeatMinute10()
        {
            //服务器存档
            ServerManagerGame.ServerSave(false);

            loger.Warn($"服务器十分钟更新");
        }

   

        // 小时心跳
        public static void HeartbeatHour()
        {
            if (IniConf.ConfSwitch.MysqlState)
            {
                BaseServerInfo.DbMysqlMain.HeartbeatExecute();
            }

            

            loger.Warn($"服务器小时更新");
        }

        //每日更新
        public static void DayUpdateDayZeroOClock()
        {
            loger.Warn($"服务器日零点更新");

           
        }

        //每日五点更新
        public static void DayUpdateDayFiveOClock()
        {

            loger.Warn($"服务器日五点更新");
        }

        //每日六点更新
        public static void DayUpdateDaySixOClock()
        {
            loger.Warn($"服务器日六点更新");
        }
        //每日结束更新
        public static void DayUpdateDay2359OClock()
        {          

            loger.Warn($"服务器每日结束更新");
        }
        //每周更新
        public static void DayUpdateWeekZeroOClock()
        {
            loger.Warn($"服务器周零点更新");
            
        }

        
    }
}