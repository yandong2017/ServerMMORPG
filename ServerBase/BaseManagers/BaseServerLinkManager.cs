using ServerBase.Config;
using ServerBase.Dispatch;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using SuperSocket.SocketLuanr;
using System.Collections.Generic;
using System.Linq;
using UtilLib;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerBase.BaseManagers
{
    // 服务器负载
    public class ServerLoadInfo
    {
        public int ID;
        public int LinkType;
        public string SessionID;        
        public int load;        
    }
    public static class BaseServerLinkManager
    {
        // 负载列表
        public static Dictionary<int, ServerLoadInfo> DictServerLink = new Dictionary<int, ServerLoadInfo>();

        public static Dictionary<int, ServerLoadInfo> DictServerLinkGame = new Dictionary<int, ServerLoadInfo>();
        public static Dictionary<int, ServerLoadInfo> DictServerLinkLogin = new Dictionary<int, ServerLoadInfo>();


        //刷新负载列表
        public static void RefreshServerLinkList()
        {
            DictServerLinkGame.Clear();
            DictServerLinkLogin.Clear();
            foreach (var item in DictServerLink.Values)
            {
                if ((EServerType)item.LinkType == EServerType.游戏)
                {
                    DictServerLinkGame.Add(item.ID, item);
                }
                else if ((EServerType)item.LinkType == EServerType.登陆)
                {
                    DictServerLinkGame.Add(item.ID, item);
                }
            }
        }

        //添加负载列表
        public static void AddServerLinkList(ServerLoadInfo load)
        {
            DictServerLink[load.ID] = load;
            RefreshServerLinkList();
        }

        //清除负载列表
        public static void RemoveServerLinkList(LunarSession session)
        {
            if (DictServerLink.ContainsKey((int)session.SessionUuid))
            {
                DictServerLink.Remove((int)session.SessionUuid);
                loger.Debug("服务器关闭 清除负载列表ID： " + session.SessionUuid.ToString());
            }
            RefreshServerLinkList();
        }

        //获取一个低负载的服务器
        public static int GetLowLoadServer(int linktype, int serverid = 0)
        {
            int result = serverid;
            if (DictServerLink.ContainsKey(serverid))
            {
                return result;
            }
            else
            {
                var ListLinkFilter = (from item in DictServerLink.Values
                                      where item.LinkType == linktype
                                      select item).ToList();
                if (ListLinkFilter.Count > 0)
                {
                    var sv = ListLinkFilter.RandomSingle();
                    result = sv.ID;
                }
                return result;
            }
        }

        //发送给游戏服务器消息
        public static void SendToGame(int serverID, INbsSerializer objMsg)
        {
            var nbs = objMsg.Serialize();
            if (DictServerLinkGame.TryGetValue(serverID, out var serverlink))
            {
                var session = BaseServerInfo.AppServer.GetSessionByID(serverlink.SessionID);
                BaseDispatch.Send(session,objMsg);
            }
        }

        //广播给游戏服务器消息
        public static void BoardcastToGame(INbsSerializer objMsg)
        {
            var nbs = objMsg.Serialize();
            foreach (var item in DictServerLinkGame.Values)
            {
                var session = BaseServerInfo.AppServer.GetSessionByID(item.SessionID);
                BaseDispatch.Send(session, objMsg);
            }
        }
    }
}