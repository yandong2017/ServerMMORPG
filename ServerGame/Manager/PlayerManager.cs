using ServerBase.Dispatch;
using ServerBase.GameObject;
using ServerBase.Protocol;
using SuperSocket.SocketLuanr;
using System.Collections.Generic;
using System.Linq;

namespace ServerGame.Manager
{
    public static class PlayerManager
    {
        //public static Dictionary<long, CLS_PlayerXY> m_DictPlayerXY = new Dictionary<long, CLS_PlayerXY>();
        public static Dictionary<long, Player> DictPlayerOnline = new Dictionary<long, Player>();

        
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            BaseDispatch.BindEventHandler(OnPlayerXY, EProtocolId.E2G_GAME_PLAYERXY);
            BaseDispatch.BindEventHandler(OnLogin, EProtocolId.L2E_GAME_LOGINSERVER);
            BaseDispatch.BindEventHandler(OnRegister, EProtocolId.L2E_GAME_REGISTER);
            BaseDispatch.BindEventHandler(OnLoginOut, EProtocolId.E2G_GAME_LOGINOUT);
            //BaseDispatch.BindEventHandler(OnPlayerMapIn, EProtocolId.E2G_GAME_MAPIN);
        }

        //private static bool isMove = false;
        public static void OnPlayerXY(LunarSession session, LunarRequestInfo requestInfo)
        {            
            var Req = new E2G_Game_PlayerXY(requestInfo.Body);
            var player = session.player;
            var rsp = new G2E_Game_PlayerXY();
            rsp.PlayerXY = Req.PlayerXY;
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == player.Id)
                {
                    continue;
                }
                rsp.Shuttle = Req.Shuttle;
                BaseDispatch.SendAll(rsp);
            }
            //m_DictPlayerXY[player.Id] =  Req.PlayerXY;
            //isMove = true;
        }

        internal static void Heartbeat()
        {            
            foreach (var player in DictPlayerOnline.Values)
            {
                //if (!m_DictPlayerXY.ContainsKey(player.Id))
                //{
                //    m_DictPlayerXY[player.Id] = new CLS_PlayerXY() { Uid = player.Id };
                //}
            }
            //if (isMove && m_DictPlayerXY.Count > 0)
            //{
            //    var rsp = new G2E_Game_PlayerXY();
            //    rsp.ListPlayerXY = m_DictPlayerXY.Values.ToList();
            //    BaseDispatch.SendAll(rsp);
            //    isMove = false;
            //}                    
        }

        internal static void OnLoginOut(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new E2G_Game_LoginOut(requestInfo.Body);
            DictPlayerOnline.Remove(Req.Puid);
            //m_DictPlayerXY.Remove(Req.Puid);
                        
            var rsp = new G2E_Game_LoginOut();
            rsp.Puid = Req.Puid;
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == session.player.Id)
                {
                    continue;
                }
                BaseDispatch.SendAll(rsp);
            }
        }

        internal static void OnLogin(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new L2E_Game_LoginServer(requestInfo.Body);

            var player = new Player(Req.Puid);
            if (!player.Load())
            {
                
            }
            session.player = player;
            player.ClientSession = session;
            DictPlayerOnline[Req.Puid] = player;
            var rsp = new G2E_Game_MapIn();
            rsp.Puid = Req.Puid;
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == player.Id)
                {
                    continue;
                }
                rsp.Shuttle = Req.Shuttle;
                BaseDispatch.SendAll(rsp);


            }


        }

        internal static void OnRegister(LunarSession session, LunarRequestInfo requestInfo)
        {
            
        }
    }
}
