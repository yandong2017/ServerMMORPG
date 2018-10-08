using ServerBase.Service;
using ServerGame.Manager;

namespace ServerGame.Service
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
            BindEventHandler("saveall", 服务器存档, "4.功能", "服务器存档");
            BindEventHandler("exit", 关闭服务器, "4.功能", "关闭服务器");
            BindEventHandler("game", 游戏服务器信息, "4.功能", "游戏服务器信息");

            BindEventHandler("test", 测试, "9.测试", "测试");

        }
        public static void 服务器存档(string cmd, string[] args)
        {
            ServerManagerGame.ServerSave();
        }
        public static void 游戏服务器信息(string cmd, string[] args)
        {
            //ShowCmdResponse($"缓存玩家数：{PlayerManager.DictPlayer.Count}");
            ShowCmdResponse($"在线玩家数：{PlayerManager.DictPlayerOnline.Count}");
        }
        public static void 关闭服务器(string cmd, string[] args)
        {
            ServerManagerGame.ServerExit();
        }
        
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        public static void 测试(string cmd, string[] args)
        {
            
        }


    }
}