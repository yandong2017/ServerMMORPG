using ServerBase.Config;
using ServerBase.DataBaseMysql;
using ServerBase.IniFile;
using SuperSocket.SocketLuanr;
using ServerBase.ServerLoger;
using ServerBase.Service;
using System;
using System.IO;
using System.Xml;
using static ServerBase.Config.Conf;
using static ServerBase.IniFile.IniConf;
using System.Text;
using System.Threading;
using ServerBase.BaseObjects;
using System.Net;
using System.Linq;
using UtilLib;

namespace ServerBase.BaseManagers
{
    public static class BaseProgram
    {
        public static void PubMain1(string[] args, EServerType 默认服务器类型)
        {
            #region 初始化日志系统

            {
                try
                {
                    Util.Show("初始化日志系统......");
                    var log4netXmlFs = new FileStream("..//Conf_Log//log4net_tpl.config", FileMode.Open);
                    var log4netXmlSr = new StreamReader(log4netXmlFs);
                    var log4netXmlStr = log4netXmlSr.ReadToEnd();
                    log4netXmlStr = log4netXmlStr.Replace("$$$$$", $"{BaseServerInfo.ServerZoneSimple}{BaseServerInfo.ServerID}");
                    log4netXmlSr.Close();
                    var log4netXmlDoc = new XmlDocument();
                    log4netXmlDoc.LoadXml(log4netXmlStr);
                    var log4netRootElement = log4netXmlDoc.DocumentElement;
                    log4net.Config.XmlConfigurator.Configure(log4netRootElement);                    
                }
                catch
                {
                    loger.Fatal("读取INI配置文件 失败");
                    Console.ReadKey();
                    return;
                }
            }

            //Console.WriteLine("________________________________________________________________________________");
            //Loger.Debug("调试信息");
            //Loger.Info("普通信息");
            //Loger.Warn("警告信息");
            //Loger.Error("错误信息");
            //Loger.Fatal("严重错误");
            //Console.WriteLine("________________________________________________________________________________\n");

            #endregion 初始化日志系统

            #region 读取INI配置文件
            Util.Show("读取INI配置文件 ......");
            if (IniConf.InitIniConf())
            {
                //loger.Info("读取INI配置文件 成功");
            }
            else
            {
                loger.Fatal("读取INI配置文件 失败");
                Console.ReadKey();
                return;
            }

            #endregion 读取游戏配置文件

            #region 读取游戏配置文件

            Util.Show("读取游戏配置文件......");
            if (InitConf())
            {
                //loger.Info("初始化配置文件成功");
            }
            else
            {
                loger.Fatal("初始化配置文件失败");
                Console.ReadKey();
                return;
            }

            #endregion 读取游戏配置文件

            #region 设置窗口属性            
            Console.SetWindowSize(160, 30);
            Console.SetBufferSize(160, 9600);
            #endregion 设置窗口属性

            #region 根据命令行参数重新配置服务器
            // XXX.exe [mode] [ServerID] [ServerIP] [ServerExtern]
            if (args.Length >= 4)
            {
                try
                {
                    BaseServerInfo.ServerRunMode = (EAccess)args[0].ToInt();
                    BaseServerInfo.ServerID = args[1].ToInt();
                    BaseServerInfo.ServerIP = args[2];
                    BaseServerInfo.ServerExtern = args[3];
                    Console.Title = BaseServerInfo.ServerExtern;
                    Util.Show("使用程序 命令行参数 配置服务器");
                }
                catch (Exception)
                {
                    Util.ShowError("使用程序 命令行参数 配置服务器错误");
                    Console.ReadKey();
                    return;
                }
            }
            //本地调试
            else
            {
                var serverconf = Conf.SysServerList.Values.FirstOrDefault(p => p.ServerType == (int)默认服务器类型);
                if (serverconf == null)
                {
                    Util.ShowError("错误的服务器类型");
                    Console.ReadKey();
                    return;
                }
                BaseServerInfo.SessionType = (EServerType)serverconf.ServerType;
                BaseServerInfo.ServerZoneSimple = $"{serverconf.Desc}";
                BaseServerInfo.ServerID = serverconf.Id;
                Console.Title = BaseServerInfo.ServerZoneSimple;

                IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipa = ipe.AddressList[1];
                Util.Show($"服务器IP:{ipa.ToString()}:{BaseServerInfo.ServerID}");
                BaseServerInfo.ServerExtern = ipa.ToString();
            }
            BaseServerInfo.ServerZone = $"{BaseServerInfo.ServerZoneSimple} {BaseServerInfo.ServerID}";

            #endregion
            #region 初始化服务器

            //设置服务器
            if (!BaseServerInfo.AppServer.SetupEx(BaseServerInfo.ServerID, BaseServerInfo.ServerEncoding))
            {
                Util.ShowError("初始化失败!");
                Console.ReadKey();
                return;
            }

            #endregion 初始化服务器
        }

        public static void PubMain2()
        {            
            #region 启动服务

            if (!BaseServerInfo.AppServer.Start())
            {
                Util.ShowError("启动服务失败!");
                Console.ReadKey();
                return;
            }

            #endregion 启动服务

            #region 连接到Mysql数据库

            if (ConfSwitch.MysqlState)
            {
                BaseServerInfo.DbMysqlMain = new DbMysql(ConfMysql.DataSource, ConfMysql.Port, ConfMysql.UserId, ConfMysql.Password, ConfMysql.Database);
                BaseServerInfo.DbMysqlMain.DbMysqlConnect();
            }

            #endregion 连接到Mysql数据库
        }


        public static void PubMain3()
        {
            //记录启动时间
            BaseServerInfo.ServerStartTime = DateTime.Now;

            //读取服务器数据
            BaseServerManager.LoadData();
        }

        //添加数据库线程
        public static void StartThreadDbMysqlSecond()
        {
            if (ConfSwitch.MysqlState)
            {
                BaseServerInfo.threadDbMysql = new Thread(new ThreadStart(ThreadDbMysqlSecond.ThreadDbMysqlSecondStart));
                BaseServerInfo.threadDbMysql.Start();
                Thread.Sleep(1000);
            }
        }      
    }
}
