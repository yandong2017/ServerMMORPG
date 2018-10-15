using SuperSocket.SocketLuanr;
using UtilLib;
using ServerBase.ServerLoger;
using ServerBase.Protocol;
using ServerGate.Service;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;
using ServerBase.Client;
using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.Service;

namespace ServerGate.ServerLink
{
    /// <summary>
    /// 服务器消息分发器
    /// </summary>
    public static class GateServerLinkMsg
    {
        /// <summary>
        /// 消息注册器
        /// </summary>
        public static void RegisterEventHandler()
        {
            ClientDispatcher.EventHandler = GateEventHandler;
            ClientDispatcher.BindEventHandler(GateServerLinkManager.OnServerConnect, EProtocolId.S2C_SERVER_CONNECT);
            ClientDispatcher.BindEventHandler(GateServerLinkManager.OnLogin, EProtocolId.L2E_GAME_LOGINSERVER);
            ClientDispatcher.BindEventHandler(GateServerLinkManager.OnRegister, EProtocolId.L2E_GAME_REGISTER);
            ClientDispatcher.BindEventHandler(GateServerLinkManager.OnPlayerLoginOut, EProtocolId.G2E_GAME_LOGINOUT);
        }

        private static void GateEventHandler(byte[] buffer)
        {
            var nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            EProtocolId id = (EProtocolId)nbs.ReadProtocolHeader();
            var objMsg = ProtocolDump.Dump(id, buffer);
            if (objMsg == null)
            {
                loger.Error($"错误协议！{id}");
                return;
            }
            if (ClientDispatcher.DictProtocolEvent.TryGetValue(id, out var protocolevent))
            {
                protocolevent.ExecuteProtocolEvent(buffer);
                return;
            }

            if ((int)id < 100)
            {
                return;
            }
            long puid = ((ProtocolMsgBase)objMsg).Puid;
            if (puid == 0 && ((ProtocolMsgBase)objMsg).RspPuids.Count==0)
            {
                loger.Error($"发送客户端消息错误，无发送目标！");
                return;
            }
            List<long> rspId = new List<long>();
            if (puid != 0)
            {
                rspId.Add(puid);
            }
            if (((ProtocolMsgBase)objMsg).RspPuids.Count > 0)
            {
                rspId.AddRange(((ProtocolMsgBase)objMsg).RspPuids);
            }
            SendMsg(objMsg, rspId);
        }
        public static void SendMsg(INbsSerializer msg,List<long> puids)
        {
            foreach (var puid in puids)
            {
                if (Dispatcher.DictPuidSession.TryGetValue(puid.ToString(), out var session))
                {
                    //session.Send(msg);
                    BaseDispatch.Send(session, msg);
                }
            }
        }
    }
}