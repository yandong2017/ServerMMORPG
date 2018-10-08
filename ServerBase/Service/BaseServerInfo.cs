using SuperSocket.SocketLuanr;
using ServerBase.DataBaseMysql;
using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilLib;
using ServerBase.Config;
using System.Collections.Concurrent;

namespace ServerBase.Service
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    public static class BaseServerInfo
    {
        //服务器APP
        public static LunarServerBase m_appServer = new LunarServerBase();
        public static LunarServerBase AppServer { get { return m_appServer; } }

        public static ConcurrentDictionary<string, LunarSession> AllSessions = new ConcurrentDictionary<string, LunarSession>();

        // 服务器运行模式
        public static EAccess ServerRunMode = EAccess.本机调试;

        // 服务器类型
        public static EServerType SessionType = EServerType.游戏;

        // 服务器状态
        public static int ServerState = 0;

        // 服务器默认端口
        public static int ServerID = 12101;

        // 服务器IP
        public static string ServerIP = "127.0.0.1";

        // 对外地址
        public static string ServerExtern = "127.0.0.1";

        // 服务器默认区名
        public static string ServerZone = "测试服务器";

        // 服务器默认区名
        public static string ServerZoneSimple = "服务器";

        // 默认服务器编码
        public static string ServerEncoding = "UTF-8";

        // 默认心跳时间
        public static int ServerHeartbeat = 10;

        // 服务器启动时间
        public static DateTime ServerStartTime = DateTime.Now;

        // 是否显示协议内容
        public static bool ShowProtocol = false;

        // 是否允许调试
        public static bool ClientDebugCommandEnable = true;

        //调试用数目
        public static int DebugTestCount = 100;
        //调试用数目
        public static int DebugTestCountMax = 1_0000;

        // 添加读取指令的线程
        public static Thread threadDriverCmds = null;

        // 发送消息线程
        public static Thread threadSend = null;

        // 数据库线程
        public static Thread threadDbMysql = null;

        // 主线程数据库连接
        public static DbMysql DbMysqlMain = null;

        // 数据库线程数据库连接
        public static DbMysql DbMysqlSecond = null;

        // 当前进程
        public static Process ServerCurrentProcess { get { return Process.GetCurrentProcess(); } }

        //进程ID
        public static int ServerCurrentProcessID { get { return ServerCurrentProcess.Id; } }

        //CPU使用率
        public static float ServerCurrentProcessCpu
        {
            get
            {
                return ((float)(ServerCurrentProcess.UserProcessorTime.TotalMilliseconds / ServerCurrentProcess.TotalProcessorTime.TotalMilliseconds));
            }
        }

        //内存
        public static long ServerCurrentProcessMemory { get { return ServerCurrentProcess.WorkingSet64; } }

        //线程数
        public static int ServerCurrentProcessThreads { get { return ServerCurrentProcess.Threads.Count; } }
    }
}
