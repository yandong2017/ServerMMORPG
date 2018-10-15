using ServerBase.BaseManagers;
using ServerBase.BaseObjects;
using ServerBase.Client;
using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerGate.Service;
using System;
using System.Collections.Generic;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerGate.ServerLink
{
    //服务器连接
    public static class GateServerLinkManager
    {
        public class ServerLinkLoger : IUtilLoger
        {
            public void Dump(object o)
            {
                //Loger.Debug(o);
            }
            public void Debug(object o)
            {
                loger.Debug(o);
            }
            public void Error(object o)
            {
                loger.Error(o);
            }
        }

        internal static void OnServerConnect(byte[] buffer)
        {
            var req = new S2C_Server_Connect(buffer);
            var rsp = new C2S_Server_Connect() { SessionType = (short)BaseServerInfo.SessionType };
            loger.Debug($"服务器连接：{req.ServerID}");
            Dispatcher.SendByServerID(req.ServerID, rsp);    
        }

        internal static void OnRegister(byte[] buffer)
        {
            var req = new L2E_Game_Register(buffer);
            var sessionID = req.Shuttle;
            var session = Dispatcher.GetSession(sessionID);
            if (session == null)
            {
                loger.Error($"客户端未找到！{sessionID}");
                return;
            }
            Dispatcher.SendByServerID(12011, req);
            Send(session, req);
        }

        internal static void OnPlayerLoginOut(byte[] buffer)
        {
            var req = new G2E_Game_LoginOut(buffer);
            SendAll(req);
        }

        internal static void OnLogin(byte[] buffer)
        {
            var req = new L2E_Game_LoginServer(buffer);
            var sessionID = req.Shuttle;
            var session = Dispatcher.GetSession(sessionID);
            if (session == null)
            {
                loger.Error($"客户端未找到！{sessionID}");
                return;
            }
            if (req.Success)
            {
                Dispatcher.SendByServerID(12011, req);
                Dispatcher.DictPuidSession[req.Puid.ToString()] = session;
                session.SessionUuid = req.Puid;
            }
           
            Send(session, req);
        }
        
        //连接列表
        public static Dictionary<int, ClientLink> DictServerLinkGame = new Dictionary<int, ClientLink>();
        public static Dictionary<int, ClientLink> DictServerLinkLogin = new Dictionary<int, ClientLink>();
        /// <summary>
        /// 启动连接
        /// </summary>
        /// <returns></returns>
        public static bool Start()
        {
            try
            {
                ClientDispatcher.SetLoger(new ServerLinkLoger());

                DictServerLinkGame.Clear();
                DictServerLinkLogin.Clear();
                foreach (var conf in Conf.SysServerList.Values)
                {
                    if (conf.ServerType == (int)EServerType.游戏)
                    {
                        var client = new ClientLink();
                        client.Setup(ConstsBase.Ip本机, conf.Id, conf.ServerType, conf.Desc);
                        DictServerLinkGame.Add(client.LinkId, client);
                    }
                    else if (conf.ServerType == (int)EServerType.登陆)
                    {
                        var client = new ClientLink();
                        client.Setup(ConstsBase.Ip本机, conf.Id, conf.ServerType, conf.Desc);
                        DictServerLinkLogin.Add(client.LinkId, client);
                    }
                }

                AutoCheckLink();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 秒心跳
        /// </summary>
        public static void HeartbeatSecond10()
        {
            //自动检查断开的连接
            AutoCheckLink();
        }

        /// <summary>
        /// 自动检查断开的连接
        /// </summary>
        public static void AutoCheckLink()
        {
            //遍历并连接
            foreach (var client in DictServerLinkLogin.Values)
            {
                if (!client.LinkState)
                {
                    client.Start();                    
                }
            }
            foreach (var client in DictServerLinkGame.Values)
            {
                if (!client.LinkState)
                {
                    client.Start();
                }
            }
        }
    }
}