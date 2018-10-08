using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerLogin.Manager;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerLogin.Service
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public static class Dispatcher
    {
       
        /// <summary>
        /// 新连接事件
        /// </summary>
        /// <param name="session"></param>
        public static void OnSessionConnected(LunarSession session)
        {
            loger.Debug("接收到连接: " + session.SessionID);            
            BaseServerInfo.AllSessions.TryAdd(session.SessionID, session);
            BaseDispatch.Send(session, new S2C_Server_Connect()
            {
                ServerID = BaseServerInfo.ServerID
            });
        }

        /// <summary>
        /// 有连接断开
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        public static void OnSessionClosed(LunarSession session, CloseReason reason)
        {
            loger.Debug("连接断开: " + session.SessionID);
            BaseServerInfo.AllSessions.TryRemove(session.SessionID, out var tt);
        }
    }
}