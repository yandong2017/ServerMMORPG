using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServerBase
{
    public class BaseProgram
    {
        public static void PubMain1(string ServerType,int ServerID)
        {
            #region 初始化日志系统
            {
                try
                {
                    var log4netXmlFs = new FileStream("log4net_tpl.config", FileMode.Open);
                    var log4netXmlSr = new StreamReader(log4netXmlFs);
                    var log4netXmlStr = log4netXmlSr.ReadToEnd();
                    log4netXmlStr = log4netXmlStr.Replace("$$$$$", $"{ServerType}服务器{ServerID}");
                    log4netXmlSr.Close();
                    var log4netXmlDoc = new XmlDocument();
                    log4netXmlDoc.LoadXml(log4netXmlStr);
                    var log4netRootElement = log4netXmlDoc.DocumentElement;
                    log4net.Config.XmlConfigurator.Configure(log4netRootElement);
                }
                catch
                {
                    Loger.Fatal("读取INI配置文件 失败");
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

            //#region 读取INI配置文件
            //Loger.Info("读取INI配置文件 ......");
            //if (IniConf.InitIniConf())
            //{
            //    //loger.Info("读取INI配置文件 成功");
            //}
            //else
            //{
            //    loger.Fatal("读取INI配置文件 失败");
            //    Console.ReadKey();
            //    return;
            //}

            //#endregion 读取游戏配置文件

            //#region 读取游戏配置文件

            //Util.Show("读取游戏配置文件......");
            //if (InitConf())
            //{
            //    //loger.Info("初始化配置文件成功");
            //}
            //else
            //{
            //    loger.Fatal("初始化配置文件失败");
            //    Console.ReadKey();
            //    return;
            //}

            //#endregion 读取游戏配置文件

            #region 设置窗口属性            
            Console.SetWindowSize(160, 30);
            Console.SetBufferSize(160, 9600);
            Console.Title = ServerType;
            #endregion 设置窗口属性

            #region 根据命令行参数重新配置服务器
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[2];
            Loger.Info($"服务器IP:{ipa.ToString()}:{ServerID}");

            #endregion
            #region 初始化服务器

            BaseServer.Setup(ipa.ToString(), ServerID);

            #endregion 初始化服务器
        }
    }
}
