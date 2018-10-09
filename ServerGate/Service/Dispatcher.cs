using System;
using System.Collections.Generic;
using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerGate.ServerLink;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerGate.Service
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public static class Dispatcher
    {        
        internal static void OnSessionConnected(LunarSession session)
        {
            loger.Debug("接收到连接: " + session.SessionID);
            session.SessionType = (short)EServerType.客户端;
            BaseServerInfo.AllSessions.TryAdd(session.SessionID, session);
        }

        internal static void OnSessionClosed(LunarSession session, CloseReason value)
        {
            BaseServerInfo.AllSessions.TryRemove(session.SessionID, out var tt);

            {
                var rsp = new E2G_Game_LoginOut();
                rsp.Puid = session.SessionUuid;
                SendToGame(rsp);
                DictPuidSession.Remove(rsp.Puid);
            }
        }

        internal static LunarSession GetSession(string SessionID)
        {
            if (BaseServerInfo.AllSessions.TryGetValue(SessionID, out var Session))
            {
                return Session;
            }
            else
            {
                return null;
            }
        }
        public static Dictionary<long, string> DictPuidSession = new Dictionary<long, string>();
        internal static void OnDispatch(LunarSession session, LunarRequestInfo requestInfo)
        {
            if (requestInfo.ProtocolID <= 0)
            {
                loger.Warn("收到空消息");
                return;
            }
            
            EProtocolId id = (EProtocolId)requestInfo.ProtocolID;
            loger.Info($"处理{(EServerType)session.SessionType} 协议->{id} -> {(int)id} 。");
            var objMsg = ProtocolDump.Dump(id, requestInfo.Body);
            if (objMsg == null)
            {
                loger.Warn("错误协议！");
                return;
            }
            ((ProtocolMsgBase)objMsg).Shuttle = session.SessionID;
            
            //登录服务器消息
            if (id > EProtocolId.L2E_GAME_START && id < EProtocolId.L2E_GAME_END)
            {
                //检测连接状态
                ESessionState SessionState = (ESessionState)session.SessionState;
                if (SessionState == ESessionState.Logined)
                {
                    loger.Warn($"已登陆收到登陆协议->  {id} -> {(int)id} 。");
                    return;
                }
                else
                {   //后期人多则会添加登录服务器获取人少的服
                    SendToLogin(objMsg);
                }
            }            
            else if (id > EProtocolId.B2T_GM_START && id < EProtocolId.B2T_GM_END)
            {
                if (session.SessionType != (short)EServerType.后台工具)
                {
                    loger.Warn($"错误的GM协议->  {id} -> {(int)id} 。");
                    return;
                }
            }
            //游戏服消息
            else
            {
                ((ProtocolMsgBase)objMsg).Puid = session.SessionUuid;
                //DictPuidSession.TryGetValue(session.SessionID,out ((ProtocolMsgBase)objMsg).Puid);
                SendToGame(objMsg);
            }
        }
       
        public static void SendToLogin(INbsSerializer objMsg, int serverID = 12101)
        {
            if (GateServerLinkManager.DictServerLinkLogin.TryGetValue(serverID, out var login))
            {
                login.Send(objMsg);
            }
            else
            {
                loger.Warn($"发送错误，登录服务器ID->  {serverID}");
            }
        }
        

        public static void SendToGame(INbsSerializer objMsg, int serverID = 12011)
        {
            if (GateServerLinkManager.DictServerLinkGame.TryGetValue(serverID, out var game))
            {  
                game.Send(objMsg);
            }
            else
            {
                loger.Warn($"发送错误，游戏服务器ID->  {serverID}");
            }
        }
        public static void SendByServerID(int serverID, INbsSerializer objMsg)
        {
            if (GateServerLinkManager.DictServerLinkLogin.TryGetValue(serverID, out var login))
            {
                login.Send(objMsg);                
            }
            else if (GateServerLinkManager.DictServerLinkGame.TryGetValue(serverID, out var game))
            {
                game.Send(objMsg);
            }
        }
    }
}