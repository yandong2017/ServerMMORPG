using UtilLib;
using ServerBase.Config;
using ServerBase.ServerLoger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using ServerBase.BaseManagers;
using ServerBase.IniFile;
using static ServerBase.IniFile.IniConf;

namespace ServerBase.Service
{
    /// <summary>
    /// 机动的服务器命令行指令分发器
    /// </summary>
    public class BaseDriverCmds
    {
        //指令
        private class CmdInfo
        {
            public string Cmd;
            public string[] Args;

            public CmdInfo(string cmd, string[] args)
            {
                Cmd = cmd;
                Args = args;
            }
        }

        public delegate void DriverCmdsEventHandler(string cmd, string[] args);

        public class DriverCmdsEvent
        {
            public string Cmd = "";
            public string Desc = "";

            public event DriverCmdsEventHandler EventHandler;

            public void ExecuteDriverCmdsEvent(string cmd, string[] args)
            {
                EventHandler(cmd, args);
            }
        }
        //绑定列表
        private static ConcurrentDictionary<string, DriverCmdsEvent> DriverCmdsEventList = new ConcurrentDictionary<string, DriverCmdsEvent>();

        private static DictList<string, string> CmdsTypeList = new DictList<string, string>();

        /// <summary>
        /// 绑定注册
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="id"></param>
        public static void BindEventHandler(string command, DriverCmdsEventHandler handle, string cmdtype = "8:其他", string desc = "说明")
        {
            string cmd = command.ToLower();
            try
            {
                DriverCmdsEvent Event = new DriverCmdsEvent()
                {
                    Cmd = cmd,
                    Desc = desc,
                };
                Event.EventHandler += new DriverCmdsEventHandler(handle);
                DriverCmdsEventList.TryAdd(cmd, Event);
                //loger.Info($"注册指令 {cmd} 成功");
                if (cmdtype != "")
                {
                    CmdsTypeList.Add(cmdtype, cmd);
                }
            }
            catch
            {
                loger.Warn($"注册指令 {cmd} 失败");
            }
        }

        /// <summary>
        /// 启动指令线程
        /// </summary>
        public static void BaseThreadDriverCmds()
        {
            BaseRegisterEventHandler();
            while (true)
            {
                string Cmd = Console.ReadLine();
                string[] args = Cmd.Split(UtilEnum.分隔符空格);
                if (args.Length > 0)
                {
                    ProcessCmds(args[0], args);
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 指令注册器
        /// </summary>
        public static void BaseRegisterEventHandler()
        {
            BindEventHandler("h", CmdShowHelp, "1.帮助", "显示帮助");
            BindEventHandler("help", CmdShowHelp, "1.帮助", "显示帮助");
            BindEventHandler("ver", CmdShowVersion, "2.信息", "显示版本号");
            BindEventHandler("version", CmdShowVersion, "2.信息", "显示版本号");
            BindEventHandler("conf", CmdReadConfig, "3.配置", "重新读取配置文件");
            BindEventHandler("config", CmdReadConfig, "3.配置", "重新读取配置文件");
            BindEventHandler("ini", CmdReadIni, "3.配置", "重新读取配置INI文件");
            BindEventHandler("log", CmdLogerChanggeLevel, "4.功能", "显示和调整日志等级");
            BindEventHandler("loglv", CmdLogerChanggeLevel, "4.功能", "显示和调整日志等级");
            BindEventHandler("lock", CmdRestrictLoginLock, "4.功能", "登陆锁定");
            BindEventHandler("unlock", CmdRestrictLoginUnlock, "4.功能", "登陆解锁");
            BindEventHandler("info", CmdShowState, "2.信息", "显示服务器信息");
            BindEventHandler("pp", CmdShowProtocol, "4.功能", "开启或关闭显示协议内容");
        }
       
        /// <summary>
        /// 显示反馈的指令
        /// </summary>
        /// <param name="obj"></param>
        public static void Show(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 显示反馈的指令
        /// </summary>
        /// <param name="args"></param>
        public static void Show(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{string.Join(" ", args)}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 显示反馈的信息
        /// </summary>
        /// <param name="obj"></param>
        public static void ShowCmdResponse(object obj)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 处理指令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void ProcessCmds(string cmd, string[] args)
        {
            if (DriverCmdsEventList.ContainsKey(cmd))
            {
                try
                {
                    Show(args);
                    DriverCmdsEventList[cmd].ExecuteDriverCmdsEvent(cmd, args);
                }
                catch (Exception e)
                {
                    loger.Warn($"处理指令：{cmd}  出错", e);
                }
            }
            else
            {
                ShowCmdResponse($"无效指令：{cmd}  请输入 help 查看全部指令");
            }
        }


        /// <summary>
        /// 帮助指令
        /// </summary>
        /// <param name="args"></param>
        public static void CmdShowHelp(string cmd, string[] args)
        {
            foreach (var kvp in CmdsTypeList)
            {
                ShowCmdResponse($"{kvp.Key}");
                foreach (var node in kvp.Value)
                {
                    ShowCmdResponse($"\t{DriverCmdsEventList[node].Cmd}\t{DriverCmdsEventList[node].Desc}");
                }
            }
        }

        /// <summary>
        /// 显示版本指令
        /// </summary>
        /// <param name="args"></param>
        public static void CmdShowVersion(string cmd, string[] args)
        {
            
        }

        /// <summary>
        /// 重新读取配置文件指令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdReadConfig(string cmd, string[] args)
        {
            //Conf.InitConfSvnUpdate();
            //Thread.Sleep(5000);
            if (Conf.InitConf())
            {
                ShowCmdResponse("重新读取配置文件成功");
            }
            else
            {
                ShowCmdResponse("重新读取配置文件失败");
            }
        }

        /// <summary>
        /// 重新读取配置文件指令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdReadIni(string cmd, string[] args)
        {
            //Conf.InitConfSvnUpdate();
            //Thread.Sleep(5000);
            if (IniConf.InitIniConf())
            {
                ShowCmdResponse("重新读取INI配置文件成功");
            }
            else
            {
                ShowCmdResponse("重新读取INI配置文件失败");
            }
        }

        /// <summary>
        /// 改变日志等级
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdLogerChanggeLevel(string cmd, string[] args)
        {
            ELogLevel OldLevel = loger.GetLevel();
            ShowCmdResponse($"当前日志等级为：{OldLevel}={(int)OldLevel}");
            if (args.Length < 2)
            {
                ShowCmdResponse("请输入日志等级(1-6) 例如: log 1");
                return;
            }
            int NewLevl = args[1].ToInt();
            ELogLevel Level = loger.ChangeLevel(NewLevl);
            ShowCmdResponse($"调整日志等级为：{Level}={(int)Level}");
        }

        /// <summary>
        /// 登录锁定
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdRestrictLoginLock(string cmd, string[] args)
        {
            ConfSwitch.RestrictLogin = true;
            ShowCmdResponse($"登录锁定");
        }

        /// <summary>
        /// 登录解锁
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdRestrictLoginUnlock(string cmd, string[] args)
        {
            ConfSwitch.RestrictLogin = false;
            ShowCmdResponse($"登录解锁");
        }

        /// <summary>
        /// 显示服务器状态状态
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdShowState(string cmd, string[] args)
        {
            ShowCmdResponse($"****************************************************************************************");
            ShowCmdResponse("服务器ID：" + BaseServerInfo.ServerID.ToString());
            ShowCmdResponse("服务器地址：" + BaseServerInfo.ServerIP.ToString());
            ShowCmdResponse("服务器端口：" + BaseServerInfo.ServerID.ToString());
            ShowCmdResponse("服务器对外地址：" + BaseServerInfo.ServerExtern.ToString());
            ShowCmdResponse("服务器连接数：" + BaseServerInfo.AppServer.SessionCount.ToString());

            ShowCmdResponse($"****************************************************************************************");
            ShowCmdResponse($"是否连接Mysql数据库：{IniConf.ConfSwitch.MysqlState}");
            ShowCmdResponse($"Telnet服务器端口：{IniConf.ConfSwitch.TelnetServerPort}");
            ShowCmdResponse($"Http服务器端口：{IniConf.ConfSwitch.HttpServerPort}");
            ShowCmdResponse($"是否限制登录：{IniConf.ConfSwitch.RestrictLogin}");
            ShowCmdResponse($"游戏验证PIN码：{IniConf.ConfSwitch.VersionPin}");

            if (BaseServerLinkManager.DictServerLink.Count > 0)
            {
                ShowCmdResponse($"****************************************************************************************");
                ShowCmdResponse("负载列表：");
                foreach (var item in BaseServerLinkManager.DictServerLink.Values)
                {
                    ShowCmdResponse($"\tID:{item.ID} Type:{(EServerType)item.LinkType}:{item.LinkType} load:{item.load}");
                }
            }
            ShowCmdResponse($"****************************************************************************************");
        }

        /// <summary>
        /// 开启或关闭显示协议内容
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdShowProtocol(string cmd, string[] args)
        {
            if (BaseServerInfo.ShowProtocol)
            {
                BaseServerInfo.ShowProtocol = false;
                Util.Show($"关闭显示协议内容");
            }
            else
            {
                BaseServerInfo.ShowProtocol = true;
                Util.Show($"开启显示协议内容");
            }
        }
    }
}