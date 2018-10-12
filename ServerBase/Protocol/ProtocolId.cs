
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    public enum EProtocolId : short
    {
        UNKNOWN_TYPE = 0,

        // All_Base_Demo - OnBaseDemo
        ALL_BASE_DEMO = 10, 
        // All_Base_Result - OnBaseResult
        ALL_BASE_RESULT = 20, 
        // All_Base_Ping - OnBasePing
        ALL_BASE_PING = 21, 
        // All_Base_GameVersion - OnBaseGameVersion
        ALL_BASE_GAMEVERSION = 22, 
        // S2C_Server_Connect - OnServerConnect
        S2C_SERVER_CONNECT = 23, 
        // C2S_Server_Connect - OnServerConnect
        C2S_SERVER_CONNECT = 24, 
        // B2T_GM_Start - OnGMStart
        B2T_GM_START = 100, 
        // B2T_GM_Login - OnGMLogin
        B2T_GM_LOGIN = 101, 
        // T2B_GM_Login - OnGMLogin
        T2B_GM_LOGIN = 102, 
        // B2G_GM_Cmd - OnGMCmd
        B2G_GM_CMD = 103, 
        // G2B_GM_Cmd - OnGMCmd
        G2B_GM_CMD = 104, 
        // B2T_GM_End - OnGMEnd
        B2T_GM_END = 105, 
        // G2D_Game_Server - OnGameServer
        G2D_GAME_SERVER = 300, 
        // D2G_Game_Server - OnGameServer
        D2G_GAME_SERVER = 301, 
        // L2E_Game_Start - OnGameStart
        L2E_GAME_START = 400, 
        // E2L_Game_LoginServer - OnGameLoginServer
        E2L_GAME_LOGINSERVER = 401, 
        // L2E_Game_LoginServer - OnGameLoginServer
        L2E_GAME_LOGINSERVER = 402, 
        // E2L_Game_Register - OnGameRegister
        E2L_GAME_REGISTER = 403, 
        // L2E_Game_Register - OnGameRegister
        L2E_GAME_REGISTER = 404, 
        // E2L_Game_Create - OnGameCreate
        E2L_GAME_CREATE = 405, 
        // L2E_Game_Create - OnGameCreate
        L2E_GAME_CREATE = 406, 
        // L2E_Game_End - OnGameEnd
        L2E_GAME_END = 407, 
        // E2G_Game_Start - OnGameStart
        E2G_GAME_START = 600, 
        // E2G_Game_PlayerXY - OnGamePlayerXY
        E2G_GAME_PLAYERXY = 602, 
        // G2E_Game_PlayerXY - OnGamePlayerXY
        G2E_GAME_PLAYERXY = 603, 
        // G2E_Game_PlayerXYOther - OnGamePlayerXYOther
        G2E_GAME_PLAYERXYOTHER = 604, 
        // E2G_Game_MapIn - OnGameMapIn
        E2G_GAME_MAPIN = 605, 
        // G2E_Game_MapIn - OnGameMapIn
        G2E_GAME_MAPIN = 606, 
        // G2E_Game_MapInOther - OnGameMapInOther
        G2E_GAME_MAPINOTHER = 607, 
        // E2G_Game_MapOut - OnGameMapOut
        E2G_GAME_MAPOUT = 608, 
        // G2E_Game_MapOut - OnGameMapOut
        G2E_GAME_MAPOUT = 609, 
        // E2G_Game_LoginOut - OnGameLoginOut
        E2G_GAME_LOGINOUT = 610, 
        // G2E_Game_LoginOut - OnGameLoginOut
        G2E_GAME_LOGINOUT = 611, 
        // E2G_Game_End - OnGameEnd
        E2G_GAME_END = 612, 

    }
}

