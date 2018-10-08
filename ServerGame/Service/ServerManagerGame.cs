using ServerBase.BaseManagers;
using ServerGame.Manager;
using System.Diagnostics;
using UtilLib;

namespace ServerGame.Service
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    public static class ServerManagerGame
    {
        /// <summary>
        /// 服务器存档
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public static void ServerSave(bool saveplayer = true)
        {
            Util.BenchmarkStart("服务器存档");

            BaseServerManager.SaveData();

            Util.BenchmarkEnd();

            if (saveplayer)
            {

                Util.BenchmarkStart($"所有玩家存档 {PlayerManager.DictPlayerOnline.Count}");
                foreach (var p in PlayerManager.DictPlayerOnline.Values)
                {
                    p.Save();
                }
                Util.BenchmarkEnd();
            }
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