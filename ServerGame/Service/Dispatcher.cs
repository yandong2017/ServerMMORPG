using ServerBase.Dispatch;
using ServerBase.GameObject;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerGame.Manager;
using ServerGame.ServerLink;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;

namespace ServerGame.Service
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public class Dispatcher
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
       
        public static void SendByServerID(int serverID, INbsSerializer objMsg)
        {
            if (GameServerLinkManager.DictClientLink.TryGetValue(serverID, out var world))
            {
                world.Send(objMsg);
            }            
        }
    }
}