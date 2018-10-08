using ServerBase.Dispatch;
using ServerBase.Protocol;
using SuperSocket.SocketLuanr;

namespace ServerDC.Manager
{
    public static class GameManager
    {        
        public static void Init()
        {
            BaseDispatch.BindEventHandler(OnServerInfo, EProtocolId.G2D_GAME_SERVER);
        }

        internal static void OnServerInfo(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new G2D_Game_Server(requestInfo.Body);
            var Rsp = new D2G_Game_Server();
            //Rsp.Data = RedisGame.KvGet($"{RdsServerData}:{Req.ServerID}");
            //Send(session,Rsp);
        }
    }
}
