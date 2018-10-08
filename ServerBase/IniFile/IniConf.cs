
 

 
 

















using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using UtilLib;
using ServerBase.Service;
using System.Text;
using ServerBase.Protocol;
using ServerBase.Config;

namespace ServerBase.IniFile
{
    /// <summary>
    /// INI配置文件
    /// </summary>
    public static class IniConf
    {
        // 配置文件目录
        public const string eIniConfPath = @"../IniFiles/";

        // 初始化配置
        public static bool InitIniConf()
        {
            bool result = true;

            if (result) { result = IniRead.ReadClass(文件路径(nameof(ConfSwitch)), 项目名称(), ref ConfSwitch); }

            if (result) { result = IniRead.ReadClass(文件路径(nameof(ConfMysql)), 项目名称(), ref ConfMysql); }

            if (result) { result = IniRead.ReadClass(文件路径(nameof(ConfRedis)), 项目名称(), ref ConfRedis); }

            if (result) { result = IniRead.ReadClass(文件路径(nameof(ConfGm)), 项目名称(), ref ConfGm); }

            return result;
        }

        public static string 文件路径(string name)
        {
            return $"{eIniConfPath}{name}.ini";
        }
        public static string 项目名称()
        {
            switch (BaseServerInfo.ServerRunMode)
            {
                case EAccess.本机调试:
                    return "Debug";
                case EAccess.内网版本:
                    return "Dev";
                case EAccess.外网版本:
                    return "Release";
                default:
                    return "Debug";
            }
        }

        public class CConfigSwitch
        {
            [Desc("数据库状态")]
            public bool MysqlState = false;
            [Desc("Telnet端口")]
            public int TelnetServerPort = 8888;
            [Desc("Http端口")]
            public int HttpServerPort = 8080;
            [Desc("限制登录")]
            public bool RestrictLogin = false;
            [Desc("排行榜异步处理")]
            public bool TopAsynchronousProcessing = true;
            [Desc("版本验证码")]
            public long VersionPin = 1234567890;
        }
        public static CConfigSwitch ConfSwitch = new CConfigSwitch();

        public class CConfigMysql
        {
            public string Name = "数据库";
            public string DataSource = "127.0.0.1";
            public string Port = "3306";
            public string UserId = "root";
            public string Password = "1q2w3e";
            public string Database = "test";
        }
        public static CConfigMysql ConfMysql = new CConfigMysql();

        public class CRedisConfig
        {
            public string Name = "数据库";
            public string Host = "127.0.0.1";
            public int Port = 6379;
            public string Password = "1q2w3e";
            public int DbIndex = 0;
        }
        public static CRedisConfig ConfRedis = new CRedisConfig();

        public class CConfigGm
        {
            public Dictionary<string, string> DictGmList = new Dictionary<string, string>();
        }
        public static CConfigGm ConfGm = new CConfigGm();
    }
}