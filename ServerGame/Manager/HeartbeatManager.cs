using ServerBase.GameObject;
using ServerBase.IniFile;
using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;
using UtilLib;

namespace ServerGame.Manager
{
    /// <summary>
    /// 心跳管理器
    /// </summary>
    public static class HeartbeatManager
    {
        /// <summary>
        /// 玩家心跳
        /// </summary>
        public static void HeartbeatAllPlayerSecond()
        {
            foreach (var p in PlayerManager.DictPlayerOnline.Values)
            {
                HeartbeatPlayerSecond(p);
            }
        }
        /// <summary>
        /// 玩家心跳 10秒一次
        /// </summary>
        public static void HeartbeatAllPlayerSecond10()
        {
            foreach (var p in PlayerManager.DictPlayerOnline.Values)
            {
                HeartbeatPlayerSecond10(p);
            }
        }

        /// <summary>
        /// 秒心跳
        /// </summary>
        public static void HeartbeatPlayerSecond(Player player, bool bInitPlayer = false)
        {
            player.TimeHeartbeat = DateTime.Now;

            //秒更新
            PlayerUpdateSecond(player);            
        }

        /// <summary>
        /// 10秒心跳
        /// </summary>
        public static void HeartbeatPlayerSecond10(Player player, bool bInitPlayer = false)
        {
            player.TimeHeartbeat = DateTime.Now;

            //10秒更新
            PlayerUpdateSecond10(player);

            //日零点更新
            PlayerUpdateDayZeroOClock(player);

            //日五点更新
            PlayerUpdateDayFiveOClock(player);

            //日小时更新
            PlayerUpdateDayXXOClock(player, bInitPlayer);

            //周零点更新
            PlayerUpdateWeekZeroOClock(player);

            //周五点更新
            PlayerUpdateWeekFiveOClock(player);

            //月零点更新
            PlayerUpdateMonthZeroOClock(player);

            //分钟更新 1
            PlayerUpdateMinite1(player);

            //分钟更新 3
            PlayerUpdateMinite3(player);

            //分钟更新 5
            PlayerUpdateMinite5(player);

            //分钟更新 30
            PlayerUpdateMinite30(player);

            //小时更新 1
            PlayerUpdateHour1(player);

            //临时数据更新
            PlayerUpdateTemp(player);
        }

        /// <summary>
        /// 玩家零点更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateDayZeroOClock(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.日零点更新;
            if (!player.TimeHeartbeat.SameDay(player.DaHeartbeat.GetHeartbeatDatetime(timeKey)))
            {
                loger.Debug($"PlayerUpdateDayZeroOClock player:{player.Id}");

                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }

        /// <summary>
        /// 玩家五点更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateDayFiveOClock(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.日五点更新;
            if (!(player.TimeHeartbeat.AddHours(-5)).SameDay(player.DaHeartbeat.GetHeartbeatDatetime(timeKey).AddHours(-5)))
            {
                loger.Debug($"PlayerUpdateDayFiveOClock player:{player.Id}");

                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }

        /// <summary>
        /// 玩家小时更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateDayXXOClock(Player player, bool bInitPlayer = false)
        {
            if (true)
            {
                //日0 6 12 18点更新
                var dtNow = player.TimeHeartbeat;
                bool brefresh = false;
                var listscale = new List<int>() { 0, 6, 12, 18 };
                var timeKey = EDataHeartbeatDatetimeKey.日X点更新;
                foreach (var nn in listscale)
                {
                    if (dtNow.SameDay(player.DaHeartbeat.GetHeartbeatDatetime(timeKey)))
                    {
                        if (dtNow.Hour >= nn && dtNow.Hour != player.DaHeartbeat.GetHeartbeatDatetime(timeKey).Hour)
                        {
                            brefresh = true;
                        }
                    }
                    else
                    {
                        if (dtNow.Hour >= nn)
                        {
                            brefresh = true;
                        }
                    }
                }
                if (brefresh)
                {
                    loger.Debug($"PlayerUpdateDayXXOClock player:{player.Id}");
					
                    //设置了重置时间
                    player.DaHeartbeat.SetHeartbeatDatetime(timeKey, dtNow);
                }
            }
        }

        /// <summary>
        /// 玩家每周零点更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateWeekZeroOClock(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.周零点更新;
            if (!player.TimeHeartbeat.SameWeek(player.DaHeartbeat.GetHeartbeatDatetime(timeKey)))
            {
                loger.Debug($"PlayerUpdateWeekZeroOClock player:{player.Id}");

                

                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }

        /// <summary>
        /// 玩家每周五点更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateWeekFiveOClock(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.周五点更新;
            if (!(player.TimeHeartbeat.AddHours(-5)).SameWeek(player.DaHeartbeat.GetHeartbeatDatetime(timeKey).AddHours(-5)))
            {
                loger.Debug($"PlayerUpdateWeekFiveOClock player:{player.Id}");
                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }

        /// <summary>
        /// 玩家每月零点更新
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerUpdateMonthZeroOClock(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.月零点更新;
            if (!player.TimeHeartbeat.SameMonth(player.DaHeartbeat.GetHeartbeatDatetime(timeKey)))
            {
                loger.Debug($"PlayerUpdateMonthZeroOClock player:{player.Id}");
                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }

        // 秒更新
        public static void PlayerUpdateSecond(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.秒更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            long count = (long)(ts.TotalSeconds);
            if (count > 0)
            {               
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 10秒更新
        public static void PlayerUpdateSecond10(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.十秒更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            long count = (long)(ts.TotalSeconds);
            if (count > 0)
            {
                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 分钟更新 1
        public static void PlayerUpdateMinite1(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.一分钟更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            int count = (int)(ts.TotalMinutes);
            if (count > 0)
            {
              
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 分钟更新 3
        public static void PlayerUpdateMinite3(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.三分钟更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            int count = (int)(ts.TotalMinutes / 3);
            if (count > 0)
            {

                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 分钟更新 5
        public static void PlayerUpdateMinite5(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.五分钟更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            int count = (int)(ts.TotalMinutes / 5);
            if (count > 0)
            {
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 分钟更新 30
        public static void PlayerUpdateMinite30(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.三十分钟更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            int count = (int)(ts.TotalMinutes / 30);
            if (count > 0)
            {
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 小时更新 1
        public static void PlayerUpdateHour1(Player player)
        {
            var timeKey = EDataHeartbeatDatetimeKey.一小时更新;
            var ts = player.TimeHeartbeat - player.DaHeartbeat.GetHeartbeatDatetime(timeKey);
            int count = (int)(ts.TotalHours / 1);
            if (count > 0)
            {                
                //设置了重置时间
                player.DaHeartbeat.SetHeartbeatDatetime(timeKey, player.TimeHeartbeat);
            }
        }
        // 临时数据更新
        public static void PlayerUpdateTemp(Player player)
        {
            //半小时存一次档
            TimeSpan tsSave = DateTime.Now - player.TimeLastAutoSave;
            if (tsSave.Minutes >= 10)
            {
                player.AutoSave();
                player.TimeLastAutoSave = DateTime.Now;
            }
        }
    }
}