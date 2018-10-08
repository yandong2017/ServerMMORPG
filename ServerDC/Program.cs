using ServerBase.BaseManagers;
using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerDC.Manager;
using ServerLogin.Service;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;
using System;
using System.Threading;

namespace ServerDC
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.PubMain1(args, EServerType.数据中心);

            #region 服务器事件

            //新连接事件
            BaseServerInfo.AppServer.NewSessionConnected += new SessionHandler<LunarSession>(BaseDispatch.OnSessionConnected);

            //连接断开事件
            BaseServerInfo.AppServer.SessionClosed += new SessionHandler<LunarSession, CloseReason>(BaseDispatch.OnSessionClosed);

            //收到消息事件
            BaseServerInfo.AppServer.NewRequestReceived += new RequestHandler<LunarSession, LunarRequestInfo>(BaseDispatch.OnDispatch);

            #endregion 服务器事件

            BaseProgram.PubMain2();

            BaseProgram.PubMain3();

            #region 启动服务器后执行服务器数据初始化

            OnServerStart();

            #endregion 启动服务器后执行服务器数据初始化

            #region 添加读取指令的线程

            BaseServerInfo.threadDriverCmds = new Thread(new ThreadStart(DriverCmds.ThreadDriverCmds));
            BaseServerInfo.threadDriverCmds.Start();
            Thread.Sleep(1000);

            #endregion 添加读取指令的线程

            #region 添加发送消息线程

            //BaseServerInfo.threadSend = new Thread(new ThreadStart(ThreadSend.ThreadSendMain));
            //BaseServerInfo.threadSend.Start();
            //Thread.Sleep(1000);

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
        public static void OnServerStart()
        {
            //注册消息
            GameManager.Init();
        }
    }
}
