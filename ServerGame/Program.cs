/*
                   _ooOoo_
                  o8888888o
                  88" . "88
                  (| -_- |)
                  O\  =  /O
               ____/`---'\____
             .'  \\|     |//  `.
            /  \\|||  :  |||//  \
           /  _||||| -:- |||||-  \
           |   | \\\  -  /// |   |
           | \_|  ''\---/''  |   |
           \  .-\__  `-`  ___/-. /
         ___`. .'  /--.--\  `. . __
      ."" '<  `.___\_<|>_/___.'  >'"".
     | | :  `- \`.;`\ _ /`;.`/ - ` : | |
     \  \ `-.   \_ __\ /__ _/   .-` /  /
======`-.____`-.___\_____/___.-`____.-'======
                   `=---='
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        佛祖保佑    永无BUG    永不修改
佛曰：
          写字楼里写字间，写字间里程序员；
          程序人员写程序，又拿程序换酒钱。
          酒醒只在网上坐，酒醉还来网下眠；
          酒醉酒醒日复日，网上网下年复年。
          但愿老死电脑间，不愿鞠躬老板前；
          奔驰宝马贵者趣，公交自行程序员。
          别人笑我忒疯癫，我笑自己命太贱；
          不见满街漂亮妹，哪个归得程序员？
*/
using ServerBase.BaseManagers;
using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerGame.Manager;
using ServerGame.ServerLink;
using ServerGame.Service;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerGame
{
    /// <summary>
    /// 主守护进程
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 主程序
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            BaseProgram.PubMain1(args, EServerType.游戏);

            #region 启动服务器后执行服务器数据初始化

            OnServerStart();

            #endregion 启动服务器后执行服务器数据初始化


            #region 服务器事件

            //新连接事件
            BaseServerInfo.AppServer.NewSessionConnected += new SessionHandler<LunarSession>(Dispatcher.OnSessionConnected);

            //连接断开事件
            BaseServerInfo.AppServer.SessionClosed += new SessionHandler<LunarSession, CloseReason>(Dispatcher.OnSessionClosed);

            //收到消息事件
            BaseServerInfo.AppServer.NewRequestReceived += new RequestHandler<LunarSession, LunarRequestInfo>(BaseDispatch.OnDispatch);

            #endregion 服务器事件

            BaseProgram.PubMain2();

            BaseProgram.PubMain3();

           
            #region 连接到其他服务器

            if (!GameServerLinkManager.Start())
            {
                loger.Fatal("连接到其他服务器失败");
            }

            #endregion 连接到其他服务器

            #region 添加读取指令的线程

            BaseServerInfo.threadDriverCmds = new Thread(new ThreadStart(DriverCmds.ThreadDriverCmds));
            BaseServerInfo.threadDriverCmds.Start();
            Thread.Sleep(1000);

            #endregion 添加读取指令的线程

            #region 添加发送消息线程

            BaseServerInfo.threadSend = new Thread(new ThreadStart(BaseDispatch.ThreadSendMain));
            BaseServerInfo.threadSend.Start();
            Thread.Sleep(1000);

            #endregion

            BaseProgram.StartThreadDbMysqlSecond();

            #region 进入主循环


            while (true)
            {
                System.Threading.Thread.CurrentThread.Join(BaseServerInfo.ServerHeartbeat);
                try
                {
                    ServerHeartbeat.Heartbeat();
                }
                catch (Exception ex)
                {
                    loger.Fatal("服务器错误", ex);
                }
            }

            #endregion 进入主循环
        }

        /// <summary>
        /// 启动服务器后执行服务器数据初始化
        /// </summary>
        public static void OnServerStart()
        {
            //根据服务器ID和分区设置窗口标题
            Console.Title = BaseServerInfo.ServerZone;

            //注册消息
            PlayerManager.Init();          

            //注册链接消息
            GameServerLinkMsg.RegisterEventHandler();
        }
    }
}