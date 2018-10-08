using ServerBase.Dispatch;
using ServerBase.Protocol;
using SuperSocket.SocketLuanr;
using System;

namespace ServerGame.Manager
{
    public static class AllBasePingManager
    {
        public static void Init()
        {
            BaseDispatch.BindEventHandler(OnBasePing, EProtocolId.ALL_BASE_PING);
            BaseDispatch.BindEventHandler(OnBaseServer, EProtocolId.S2C_SERVER_CONNECT);
        }
        public static void OnBasePing(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Rsp = new All_Base_Ping()
            {
                ServerTime = DateTime.Now,
            };

            BaseDispatch.Send(session, Rsp);
        }

        internal static void OnBaseServer(LunarSession session, LunarRequestInfo requestInfo)
        {
            //var rsp = new S2C_Server_Connect()
            //{
            //    SessionType = (short)BaseServerInfo.SessionType
            //};
            //Dispatcher.SendByServerID(((S2C_Server_Connect)objMsg).ServerID, rsp);
        }
    }
}
