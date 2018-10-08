using UtilLib;
using System;
using System.Collections.Generic;
using ServerBase.ServerLoger;
using System.Threading;
using static ServerBase.Config.Conf;
using static ServerBase.IniFile.IniConf;
using ServerBase.Service;
using ServerBase.IniFile;
using System.Collections.Concurrent;

namespace ServerBase.DataBaseMysql
{
    /// <summary>
    /// 数据库执行线程
    /// </summary>
    public class ThreadDbMysqlSecond
    {
        // 心跳开始时间
        private static long TicksCur = 0;
        // 心跳计时
        private static long TicksHour = 0;

        /// <summary>
        /// 启动发送消息线程
        /// </summary>
        public static void ThreadDbMysqlSecondStart()
        {
            #region 连接到Mysql数据库

            try
            {
                if (IniConf.ConfSwitch.MysqlState)
                {
                    BaseServerInfo.DbMysqlSecond = new DbMysql(ConfMysql.DataSource, ConfMysql.Port, ConfMysql.UserId, ConfMysql.Password, ConfMysql.Database);
                    BaseServerInfo.DbMysqlSecond.DbMysqlConnect();
                }
            }
            catch (Exception ex)
            {
                loger.Fatal("数据库初始化失败", ex);
            }

            #endregion 连接到Mysql数据库

            while (true)
            {
                TicksCur = DateTime.Now.Ticks;
                //小时心跳
                if (TicksHour < TicksCur)
                {
                    HeartbeatHour();
                    TicksHour = TicksCur + 3600 * UtilEnum.每秒的ticks数;
                }

                try
                {
                    RunAll();
                }
                catch (Exception ex)
                {
                    loger.Fatal("指令线程执行失败", ex);
                }
                Thread.Sleep(100);
            }
        }

        // 小时心跳
        public static void HeartbeatHour()
        {
            if (IniConf.ConfSwitch.MysqlState)
            {
                BaseServerInfo.DbMysqlSecond.HeartbeatExecute();
            }
        }

        //锁
        public static object LockerCmd = new object();
        //待处理操作
        public static ConcurrentQueue<string> ListCmd = new ConcurrentQueue<string>();

        //添加操作
        public static void AddCmd(string cmd)
        {
            ListCmd.Enqueue(cmd);
        }

        //处理操作
        public static void RunAll()
        {
            while (ListCmd.TryDequeue(out var cmd))
            {
                BaseServerInfo.DbMysqlSecond.RunCommand(cmd, true);
            }
        }
    }


}