using ServerBase.Dispatch;
using ServerBase.GameObject;
using ServerBase.Protocol;
using SuperSocket.SocketLuanr;
using System;
using System.Collections.Generic;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerLogin.Manager
{
    public static class LoginManager
    {
        public static void Init()
        {
            BaseDispatch.BindEventHandler(OnBasePing, EProtocolId.ALL_BASE_PING);
            BaseDispatch.BindEventHandler(OnLogin, EProtocolId.E2L_GAME_LOGINSERVER);
            BaseDispatch.BindEventHandler(OnRegister, EProtocolId.E2L_GAME_REGISTER);
        }

        private static Dictionary<string, User> DataCache = new Dictionary<string, User>();

        private static int i = 1;
        public static long CreateUuid()
        {
            return i++;
        }
        public static void OnBasePing(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Rsp = new All_Base_Ping()
            {
                ServerTime = DateTime.Now,
            };

            BaseDispatch.Send(session, Rsp);
        }
        internal static void OnLogin(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new E2L_Game_LoginServer(requestInfo.Body);
            var Rsp = new L2E_Game_LoginServer();

            Rsp.Shuttle = Req.Shuttle;
            if (!DataCache.TryGetValue(Req.Account, out var user))
            {
                Rsp.Result = EProtocolResult.账号不存在;
                BaseDispatch.Send(session, Rsp); return;
            }
            if (Req.Password != user.Password)
            {
                Rsp.Result = EProtocolResult.密码错误; BaseDispatch.Send(session, Rsp); return;
            }
            Rsp.Puid = user.Uuid;
            BaseDispatch.Send(session, Rsp);
        }

        internal static void OnRegister(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new E2L_Game_Register(requestInfo.Body);
            var Rsp = new L2E_Game_Register();

            Rsp.Shuttle = Req.Shuttle;
            if (DataCache.TryGetValue(Req.Account, out var user))
            {
                Rsp.Result = EProtocolResult.账号已存在;
                BaseDispatch.Send(session, Rsp); return;
            }

            Rsp.Puid = CreateUuid();

            user = new User();
            user.Uuid = Rsp.Puid;
            user.Account = Req.Account;
            user.Password = Req.Password;

            DataCache[Req.Account] = user;
            user.Save();
            BaseDispatch.Send(session, Rsp);
        }
    }
}
