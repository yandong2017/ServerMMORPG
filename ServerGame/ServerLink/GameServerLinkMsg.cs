
 

 
 

















using SuperSocket.SocketLuanr;
using UtilLib;
using ServerBase.ServerLoger;
using ServerBase.Protocol;
using ServerGame.Service;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;
using ServerBase.Client;
using ServerBase.Config;
using ServerBase.Service;

namespace ServerGame.ServerLink
{
    /// <summary>
    /// 服务器消息分发器
    /// </summary>
    public static class GameServerLinkMsg
    {
        /// <summary>
        /// 消息注册器
        /// </summary>
        public static void RegisterEventHandler()
        {
            ClientDispatcher.EventHandler = GameEventHandler;
        }
        private static void GameEventHandler(byte[] buffer)
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

            if (id == EProtocolId.S2C_SERVER_CONNECT)
            {
                var rsp = new C2S_Server_Connect()
                {
                    SessionType = (short)BaseServerInfo.SessionType
                };
                Dispatcher.SendByServerID(((S2C_Server_Connect)objMsg).ServerID, rsp);
                return;
            }
            if ((int)id < 100)
            {
                return;
            }
            if (!ClientDispatcher.DictProtocolEvent.TryGetValue(id, out var protocolevent))
            {
                loger.Debug(string.Format("未注册协议->  {0} -> {1} ......", id, (int)id));
                return;
            }
            try
            {               
                //处理
                protocolevent.ExecuteProtocolEvent(buffer);
            }
            catch (Exception ex)
            {
                loger.Error(string.Format("处理协议->  {0} -> {1}出错 ex:{2}", id, (int)id, ex.Message));
            }
        }

        /// <summary>
        /// 发送消息(通过服务器ID)
        /// </summary>
        /// <param name="serverid"></param>
        /// <param name="nbs"></param>
        public static void SendToServer(int serverid, INbsSerializer objMsg)
        {
            try
            {
                var lk = GameServerLinkManager.DictClientLink[serverid];
                lk.Send(objMsg.Serialize());
            }
            catch
            {
                loger.Error($"发送消息到服务器 {serverid} 失败");
            }
        }

        /// <summary>
        /// 发送消息(通过服务器类型)
        /// </summary>
        /// <param name="linktype"></param>
        /// <param name="nbs"></param>
        public static void SendToType(int linktype, INbsSerializer objMsg)
        {
            var nbs = objMsg.Serialize();
            foreach (var item in GameServerLinkManager.DictClientLink.Values)
            {
                if (item.LinkType == linktype)
                {
                    item.Send(nbs);
                }
            }
        }

        /// <summary>
        /// 发送消息给世界服务器
        /// </summary>
        /// <param name="nbs"></param>
        public static void SendToWorld(INbsSerializer objMsg)
        {
            SendToType((int)EServerType.世界, objMsg);
        }
   
        /// <summary>
        /// 发送消息给登陆服务器
        /// </summary>
        /// <param name="nbs"></param>
        public static void SendToLogin(INbsSerializer objMsg)
        {
            SendToType((int)EServerType.登陆, objMsg);
        }
    }
}