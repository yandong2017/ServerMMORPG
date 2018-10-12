
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System.Text;
using ServerBase.BaseManagers;

namespace ServerBase.Protocol
{
    public static class ProtocolDump
    {
        public static INbsSerializer Dump(EProtocolId id, byte[] buffer)
        {            
            switch (id)
            {
                case EProtocolId.ALL_BASE_DEMO:
                    return new All_Base_Demo(buffer);
                case EProtocolId.ALL_BASE_RESULT:
                    return new All_Base_Result(buffer);
                case EProtocolId.ALL_BASE_PING:
                    return new All_Base_Ping(buffer);
                case EProtocolId.ALL_BASE_GAMEVERSION:
                    return new All_Base_GameVersion(buffer);
                case EProtocolId.S2C_SERVER_CONNECT:
                    return new S2C_Server_Connect(buffer);
                case EProtocolId.C2S_SERVER_CONNECT:
                    return new C2S_Server_Connect(buffer);
                case EProtocolId.B2T_GM_START:
                    return new B2T_GM_Start(buffer);
                case EProtocolId.B2T_GM_LOGIN:
                    return new B2T_GM_Login(buffer);
                case EProtocolId.T2B_GM_LOGIN:
                    return new T2B_GM_Login(buffer);
                case EProtocolId.B2G_GM_CMD:
                    return new B2G_GM_Cmd(buffer);
                case EProtocolId.G2B_GM_CMD:
                    return new G2B_GM_Cmd(buffer);
                case EProtocolId.B2T_GM_END:
                    return new B2T_GM_End(buffer);
                case EProtocolId.G2D_GAME_SERVER:
                    return new G2D_Game_Server(buffer);
                case EProtocolId.D2G_GAME_SERVER:
                    return new D2G_Game_Server(buffer);
                case EProtocolId.L2E_GAME_START:
                    return new L2E_Game_Start(buffer);
                case EProtocolId.E2L_GAME_LOGINSERVER:
                    return new E2L_Game_LoginServer(buffer);
                case EProtocolId.L2E_GAME_LOGINSERVER:
                    return new L2E_Game_LoginServer(buffer);
                case EProtocolId.E2L_GAME_REGISTER:
                    return new E2L_Game_Register(buffer);
                case EProtocolId.L2E_GAME_REGISTER:
                    return new L2E_Game_Register(buffer);
                case EProtocolId.E2L_GAME_CREATE:
                    return new E2L_Game_Create(buffer);
                case EProtocolId.L2E_GAME_CREATE:
                    return new L2E_Game_Create(buffer);
                case EProtocolId.L2E_GAME_END:
                    return new L2E_Game_End(buffer);
                case EProtocolId.E2G_GAME_START:
                    return new E2G_Game_Start(buffer);
                case EProtocolId.E2G_GAME_PLAYERXY:
                    return new E2G_Game_PlayerXY(buffer);
                case EProtocolId.G2E_GAME_PLAYERXY:
                    return new G2E_Game_PlayerXY(buffer);
                case EProtocolId.G2E_GAME_PLAYERXYOTHER:
                    return new G2E_Game_PlayerXYOther(buffer);
                case EProtocolId.E2G_GAME_MAPIN:
                    return new E2G_Game_MapIn(buffer);
                case EProtocolId.G2E_GAME_MAPIN:
                    return new G2E_Game_MapIn(buffer);
                case EProtocolId.G2E_GAME_MAPINOTHER:
                    return new G2E_Game_MapInOther(buffer);
                case EProtocolId.E2G_GAME_MAPOUT:
                    return new E2G_Game_MapOut(buffer);
                case EProtocolId.G2E_GAME_MAPOUT:
                    return new G2E_Game_MapOut(buffer);
                case EProtocolId.E2G_GAME_LOGINOUT:
                    return new E2G_Game_LoginOut(buffer);
                case EProtocolId.G2E_GAME_LOGINOUT:
                    return new G2E_Game_LoginOut(buffer);
                case EProtocolId.E2G_GAME_END:
                    return new E2G_Game_End(buffer);

                default:
                    return null;
            }            
        }
    }
}

