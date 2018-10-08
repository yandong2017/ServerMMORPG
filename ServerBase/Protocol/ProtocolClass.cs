
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    [Desc("类示例")]
    public partial class CLS_BaseDemo
    {
        public byte a1 = 0;
        public short a2 = 0;
        public int a3 = 0;
        public long a4 = 0;
        public float a5 = 0.0f;
        public string a6 = "";
        public bool a7 = false;
        public DateTime d1 = DateTime.Now;
        public TimeSpan d2 = new TimeSpan();
        public EnumBaseDemo BaseDemo = new EnumBaseDemo();
    };
    [Desc("示例")]
    public partial class All_Base_Demo : ProtocolMsgBase, INbsSerializer
    {
        public byte a1 = 0;
        public short a2 = 0;
        public int a3 = 0;
        public long a4 = 0;
        public float a5 = 0.0f;
        public string a6 = "";
        public bool a7 = false;
        public DateTime d1 = DateTime.Now;
        public TimeSpan d2 = new TimeSpan();
        public EnumBaseDemo eBaseDemo = new EnumBaseDemo();
        public CLS_BaseDemo BaseDemo = new CLS_BaseDemo();
        public All_Base_Demo() { ProtocolId = EProtocolId.ALL_BASE_DEMO; }
        public All_Base_Demo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("结果返回")]
    public partial class All_Base_Result : ProtocolMsgBase, INbsSerializer
    {
        [Desc("协议ID")]
        public int HandleId = 0;
        public All_Base_Result() { ProtocolId = EProtocolId.ALL_BASE_RESULT; }
        public All_Base_Result(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("Ping服务器")]
    public partial class All_Base_Ping : ProtocolMsgBase, INbsSerializer
    {
        [Desc("服务器时间刻度")]
        public DateTime ServerTime = DateTime.Now;
        public All_Base_Ping() { ProtocolId = EProtocolId.ALL_BASE_PING; }
        public All_Base_Ping(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("同步版本号")]
    public partial class All_Base_GameVersion : ProtocolMsgBase, INbsSerializer
    {
        [Desc("同步版本号")]
        public string GameVersion = "";
        public All_Base_GameVersion() { ProtocolId = EProtocolId.ALL_BASE_GAMEVERSION; }
        public All_Base_GameVersion(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("服务器类型")]
    public partial class S2C_Server_Connect : ProtocolMsgBase, INbsSerializer
    {
        public int ServerID = 0;
        public S2C_Server_Connect() { ProtocolId = EProtocolId.S2C_SERVER_CONNECT; }
        public S2C_Server_Connect(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("服务器类型")]
    public partial class C2S_Server_Connect : ProtocolMsgBase, INbsSerializer
    {
        public short SessionType = 0;
        public C2S_Server_Connect() { ProtocolId = EProtocolId.C2S_SERVER_CONNECT; }
        public C2S_Server_Connect(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("服务器类型")]
    public partial class B2T_GM_Start : ProtocolMsgBase, INbsSerializer
    {
        public B2T_GM_Start() { ProtocolId = EProtocolId.B2T_GM_START; }
        public B2T_GM_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM登陆")]
    public partial class B2T_GM_Login : ProtocolMsgBase, INbsSerializer
    {
        [Desc("账号")]
        public string Account = "";
        [Desc("密码")]
        public string Password = "";
        public B2T_GM_Login() { ProtocolId = EProtocolId.B2T_GM_LOGIN; }
        public B2T_GM_Login(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 GM登陆")]
    public partial class T2B_GM_Login : ProtocolMsgBase, INbsSerializer
    {
        public T2B_GM_Login() { ProtocolId = EProtocolId.T2B_GM_LOGIN; }
        public T2B_GM_Login(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class B2G_GM_Cmd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("指令")]
        public string Cmd = "";
        public List<string> Args = new List<string>();
        public B2G_GM_Cmd() { ProtocolId = EProtocolId.B2G_GM_CMD; }
        public B2G_GM_Cmd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class G2B_GM_Cmd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("指令")]
        public string Cmd = "";
        public List<string> Args = new List<string>();
        public G2B_GM_Cmd() { ProtocolId = EProtocolId.G2B_GM_CMD; }
        public G2B_GM_Cmd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class B2T_GM_End : ProtocolMsgBase, INbsSerializer
    {
        public B2T_GM_End() { ProtocolId = EProtocolId.B2T_GM_END; }
        public B2T_GM_End(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class G2D_Game_Server : ProtocolMsgBase, INbsSerializer
    {
        public int ServerID = 0;
        public G2D_Game_Server() { ProtocolId = EProtocolId.G2D_GAME_SERVER; }
        public G2D_Game_Server(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class D2G_Game_Server : ProtocolMsgBase, INbsSerializer
    {
        public string Data = "";
        public D2G_Game_Server() { ProtocolId = EProtocolId.D2G_GAME_SERVER; }
        public D2G_Game_Server(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class L2E_Game_Start : ProtocolMsgBase, INbsSerializer
    {
        public L2E_Game_Start() { ProtocolId = EProtocolId.L2E_GAME_START; }
        public L2E_Game_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class E2L_Game_LoginServer : ProtocolMsgBase, INbsSerializer
    {
        [Desc("账号")]
        public string Account = "";
        [Desc("密码")]
        public string Password = "";
        public E2L_Game_LoginServer() { ProtocolId = EProtocolId.E2L_GAME_LOGINSERVER; }
        public E2L_Game_LoginServer(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class L2E_Game_LoginServer : ProtocolMsgBase, INbsSerializer
    {
        public L2E_Game_LoginServer() { ProtocolId = EProtocolId.L2E_GAME_LOGINSERVER; }
        public L2E_Game_LoginServer(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class E2L_Game_Register : ProtocolMsgBase, INbsSerializer
    {
        [Desc("账号")]
        public string Account = "";
        [Desc("密码")]
        public string Password = "";
        public E2L_Game_Register() { ProtocolId = EProtocolId.E2L_GAME_REGISTER; }
        public E2L_Game_Register(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class L2E_Game_Register : ProtocolMsgBase, INbsSerializer
    {
        public L2E_Game_Register() { ProtocolId = EProtocolId.L2E_GAME_REGISTER; }
        public L2E_Game_Register(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class E2L_Game_Create : ProtocolMsgBase, INbsSerializer
    {
        public string Name = "";
        [Desc("角色ID")]
        public int HeroID = 0;
        public E2L_Game_Create() { ProtocolId = EProtocolId.E2L_GAME_CREATE; }
        public E2L_Game_Create(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class L2E_Game_Create : ProtocolMsgBase, INbsSerializer
    {
        public L2E_Game_Create() { ProtocolId = EProtocolId.L2E_GAME_CREATE; }
        public L2E_Game_Create(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class L2E_Game_End : ProtocolMsgBase, INbsSerializer
    {
        public L2E_Game_End() { ProtocolId = EProtocolId.L2E_GAME_END; }
        public L2E_Game_End(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 GM特殊功能")]
    public partial class E2G_Game_Start : ProtocolMsgBase, INbsSerializer
    {
        public E2G_Game_Start() { ProtocolId = EProtocolId.E2G_GAME_START; }
        public E2G_Game_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class CLS_PlayerXY
    {
        public long Uid = 0;
        public int Left = 0;
        public int Top = 0;
    };
    [Desc("类示例")]
    public partial class E2G_Game_PlayerXY : ProtocolMsgBase, INbsSerializer
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public E2G_Game_PlayerXY() { ProtocolId = EProtocolId.E2G_GAME_PLAYERXY; }
        public E2G_Game_PlayerXY(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class G2E_Game_PlayerXY : ProtocolMsgBase, INbsSerializer
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public G2E_Game_PlayerXY() { ProtocolId = EProtocolId.G2E_GAME_PLAYERXY; }
        public G2E_Game_PlayerXY(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class E2G_Game_MapIn : ProtocolMsgBase, INbsSerializer
    {
        public E2G_Game_MapIn() { ProtocolId = EProtocolId.E2G_GAME_MAPIN; }
        public E2G_Game_MapIn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class G2E_Game_MapIn : ProtocolMsgBase, INbsSerializer
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public G2E_Game_MapIn() { ProtocolId = EProtocolId.G2E_GAME_MAPIN; }
        public G2E_Game_MapIn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class G2E_Game_MapInOther : ProtocolMsgBase, INbsSerializer
    {
        public List<CLS_PlayerXY> ListPlayerXY = new List<CLS_PlayerXY>();
        public G2E_Game_MapInOther() { ProtocolId = EProtocolId.G2E_GAME_MAPINOTHER; }
        public G2E_Game_MapInOther(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class E2G_Game_MapOut : ProtocolMsgBase, INbsSerializer
    {
        public E2G_Game_MapOut() { ProtocolId = EProtocolId.E2G_GAME_MAPOUT; }
        public E2G_Game_MapOut(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class G2E_Game_MapOut : ProtocolMsgBase, INbsSerializer
    {
        public G2E_Game_MapOut() { ProtocolId = EProtocolId.G2E_GAME_MAPOUT; }
        public G2E_Game_MapOut(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class E2G_Game_LoginOut : ProtocolMsgBase, INbsSerializer
    {
        public E2G_Game_LoginOut() { ProtocolId = EProtocolId.E2G_GAME_LOGINOUT; }
        public E2G_Game_LoginOut(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class G2E_Game_LoginOut : ProtocolMsgBase, INbsSerializer
    {
        public G2E_Game_LoginOut() { ProtocolId = EProtocolId.G2E_GAME_LOGINOUT; }
        public G2E_Game_LoginOut(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("类示例")]
    public partial class E2G_Game_End : ProtocolMsgBase, INbsSerializer
    {
        public E2G_Game_End() { ProtocolId = EProtocolId.E2G_GAME_END; }
        public E2G_Game_End(byte[] buffer) { Unserialize(buffer); }
    };

}

