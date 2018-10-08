using ServerBase.Protocol;
using ServerBase.Service;
using System.Diagnostics;
using System.Threading;

namespace ServerGate.Service
{
    /// <summary>
    /// 机动的服务器命令行指令分发器
    /// </summary>
    public class DriverCmds : BaseDriverCmds
    {
        /// <summary>
        /// 启动指令线程
        /// </summary>
        public static void ThreadDriverCmds()
        {
            RegisterEventHandler();

            BaseThreadDriverCmds();
        }

        /// <summary>
        /// 指令注册器
        /// </summary>
        public static void RegisterEventHandler()
        {            
            BindEventHandler("exit", CmdExit, "1.关闭", "关闭服务器");
            BindEventHandler("test", CmdTest, "9.测试", "测试");
        }
        public static void CmdExit(string cmd, string[] args)
        {           
            Thread.Sleep(5000);
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void CmdTest(string cmd, string[] args)
        {
            var Req = new All_Base_Ping()
            {                
            };
            Dispatcher.SendToGame(Req);
        }


    }
}