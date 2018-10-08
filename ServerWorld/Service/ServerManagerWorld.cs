using ServerBase.BaseManagers;
using System.Diagnostics;
using UtilLib;

namespace ServerWorld.Service
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    public static class ServerManagerWorld
    {
        /// <summary>
        /// 服务器存档
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public static void ServerSave()
        {
            Util.BenchmarkStart("服务器存档");
            BaseServerManager.SaveData();
            //全局数据存储
           
            Util.BenchmarkEnd();
        }

        /// <summary>
        /// 处理Daemon关闭分区服务器
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public static void ServerExit()
        {
            ServerSave();

            System.Threading.Thread.Sleep(5000);
            Process.GetCurrentProcess().Kill();
        }
    }

}