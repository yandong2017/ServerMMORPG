
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    public partial class CLS_BaseDemo
    {
        public short a2 = 0;
        public int a3 = 0;
        public long a4 = 0;
        public float a5 = 0.0f;
        public string a6 = "";
        public bool a7 = false;
        public DateTime d1 = DateTime.Now;
        public TimeSpan d2 = new TimeSpan();
        public EnumBaseDemo BaseDemo = new EnumBaseDemo();
        public void Serialize(MMO_MemoryStream nbs)
        {
            nbs.Write(a2);
            nbs.Write(a3);
            nbs.Write(a4);
            nbs.Write(a5);
            nbs.Write(a6);
            nbs.Write(a7);
            nbs.Write(d1);
            nbs.Write(d2);
            nbs.Write((short)BaseDemo);
        }
        public void Unserialize(MMO_MemoryStream nbs)
        {
            nbs.Read(out a2);
            nbs.Read(out a3);
            nbs.Read(out a4);
            nbs.Read(out a5);
            nbs.Read(out a6);
            nbs.Read(out a7);
            nbs.Read(out d1);
            nbs.Read(out d2);
            if (true) { nbs.Read(out short etemp); BaseDemo = (EnumBaseDemo)etemp; }
        }
    };
    public partial class All_Base_Demo : ProtocolMsgBase
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
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(a1);
                nbs.Write(a2);
                nbs.Write(a3);
                nbs.Write(a4);
                nbs.Write(a5);
                nbs.Write(a6);
                nbs.Write(a7);
                nbs.Write(d1);
                nbs.Write(d2);
                nbs.Write((short)eBaseDemo);
                BaseDemo.Serialize(nbs);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out a1);
                nbs.Read(out a2);
                nbs.Read(out a3);
                nbs.Read(out a4);
                nbs.Read(out a5);
                nbs.Read(out a6);
                nbs.Read(out a7);
                nbs.Read(out d1);
                nbs.Read(out d2);
                if (true) { nbs.Read(out short etemp); eBaseDemo = (EnumBaseDemo)etemp; }
                BaseDemo.Unserialize(nbs);
            }
        }
    };
    public partial class All_Base_Result : ProtocolMsgBase
    {
        public int HandleId = 0;
        public All_Base_Result() { ProtocolId = EProtocolId.ALL_BASE_RESULT; }
        public All_Base_Result(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(HandleId);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out HandleId);
            }
        }
    };
    public partial class All_Base_Ping : ProtocolMsgBase
    {
        public DateTime ServerTime = DateTime.Now;
        public All_Base_Ping() { ProtocolId = EProtocolId.ALL_BASE_PING; }
        public All_Base_Ping(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(ServerTime);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out ServerTime);
            }
        }
    };
    public partial class All_Base_GameVersion : ProtocolMsgBase
    {
        public string GameVersion = "";
        public All_Base_GameVersion() { ProtocolId = EProtocolId.ALL_BASE_GAMEVERSION; }
        public All_Base_GameVersion(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(GameVersion);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out GameVersion);
            }
        }
    };
    public partial class S2C_Server_Connect : ProtocolMsgBase
    {
        public int ServerID = 0;
        public S2C_Server_Connect() { ProtocolId = EProtocolId.S2C_SERVER_CONNECT; }
        public S2C_Server_Connect(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(ServerID);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out ServerID);
            }
        }
    };
    public partial class C2S_Server_Connect : ProtocolMsgBase
    {
        public short SessionType = 0;
        public C2S_Server_Connect() { ProtocolId = EProtocolId.C2S_SERVER_CONNECT; }
        public C2S_Server_Connect(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(SessionType);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out SessionType);
            }
        }
    };
    public partial class B2T_GM_Start : ProtocolMsgBase
    {
        public B2T_GM_Start() { ProtocolId = EProtocolId.B2T_GM_START; }
        public B2T_GM_Start(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class B2T_GM_Login : ProtocolMsgBase
    {
        public string Account = "";
        public string Password = "";
        public B2T_GM_Login() { ProtocolId = EProtocolId.B2T_GM_LOGIN; }
        public B2T_GM_Login(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Account);
                nbs.Write(Password);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Account);
                nbs.Read(out Password);
            }
        }
    };
    public partial class T2B_GM_Login : ProtocolMsgBase
    {
        public T2B_GM_Login() { ProtocolId = EProtocolId.T2B_GM_LOGIN; }
        public T2B_GM_Login(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class B2G_GM_Cmd : ProtocolMsgBase
    {
        public string Cmd = "";
        public List<string> Args = new List<string>();
        public B2G_GM_Cmd() { ProtocolId = EProtocolId.B2G_GM_CMD; }
        public B2G_GM_Cmd(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Cmd);
                nbs.Write(Args.Count);
                foreach (var k in Args)
                {
                    nbs.Write(k);
                }
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Cmd);
                nbs.Read(out int var28);
                for (int k = 0; k < var28; k++)
                {
                    nbs.Read(out string var29);Args.Add(var29);
                }
            }
        }
    };
    public partial class G2B_GM_Cmd : ProtocolMsgBase
    {
        public string Cmd = "";
        public List<string> Args = new List<string>();
        public G2B_GM_Cmd() { ProtocolId = EProtocolId.G2B_GM_CMD; }
        public G2B_GM_Cmd(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Cmd);
                nbs.Write(Args.Count);
                foreach (var k in Args)
                {
                    nbs.Write(k);
                }
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Cmd);
                nbs.Read(out int var31);
                for (int k = 0; k < var31; k++)
                {
                    nbs.Read(out string var32);Args.Add(var32);
                }
            }
        }
    };
    public partial class B2T_GM_End : ProtocolMsgBase
    {
        public B2T_GM_End() { ProtocolId = EProtocolId.B2T_GM_END; }
        public B2T_GM_End(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class G2D_Game_Server : ProtocolMsgBase
    {
        public int ServerID = 0;
        public G2D_Game_Server() { ProtocolId = EProtocolId.G2D_GAME_SERVER; }
        public G2D_Game_Server(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(ServerID);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out ServerID);
            }
        }
    };
    public partial class D2G_Game_Server : ProtocolMsgBase
    {
        public string Data = "";
        public D2G_Game_Server() { ProtocolId = EProtocolId.D2G_GAME_SERVER; }
        public D2G_Game_Server(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Data);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Data);
            }
        }
    };
    public partial class L2E_Game_Start : ProtocolMsgBase
    {
        public L2E_Game_Start() { ProtocolId = EProtocolId.L2E_GAME_START; }
        public L2E_Game_Start(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2L_Game_LoginServer : ProtocolMsgBase
    {
        public string Account = "";
        public string Password = "";
        public E2L_Game_LoginServer() { ProtocolId = EProtocolId.E2L_GAME_LOGINSERVER; }
        public E2L_Game_LoginServer(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Account);
                nbs.Write(Password);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Account);
                nbs.Read(out Password);
            }
        }
    };
    public partial class L2E_Game_LoginServer : ProtocolMsgBase
    {
        public L2E_Game_LoginServer() { ProtocolId = EProtocolId.L2E_GAME_LOGINSERVER; }
        public L2E_Game_LoginServer(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2L_Game_Register : ProtocolMsgBase
    {
        public string Account = "";
        public string Password = "";
        public E2L_Game_Register() { ProtocolId = EProtocolId.E2L_GAME_REGISTER; }
        public E2L_Game_Register(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Account);
                nbs.Write(Password);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Account);
                nbs.Read(out Password);
            }
        }
    };
    public partial class L2E_Game_Register : ProtocolMsgBase
    {
        public L2E_Game_Register() { ProtocolId = EProtocolId.L2E_GAME_REGISTER; }
        public L2E_Game_Register(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2L_Game_Create : ProtocolMsgBase
    {
        public string Name = "";
        public int HeroID = 0;
        public E2L_Game_Create() { ProtocolId = EProtocolId.E2L_GAME_CREATE; }
        public E2L_Game_Create(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(Name);
                nbs.Write(HeroID);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out Name);
                nbs.Read(out HeroID);
            }
        }
    };
    public partial class L2E_Game_Create : ProtocolMsgBase
    {
        public L2E_Game_Create() { ProtocolId = EProtocolId.L2E_GAME_CREATE; }
        public L2E_Game_Create(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class L2E_Game_End : ProtocolMsgBase
    {
        public L2E_Game_End() { ProtocolId = EProtocolId.L2E_GAME_END; }
        public L2E_Game_End(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2G_Game_Start : ProtocolMsgBase
    {
        public E2G_Game_Start() { ProtocolId = EProtocolId.E2G_GAME_START; }
        public E2G_Game_Start(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class CLS_PlayerXY
    {
        public long Uid = 0;
        public int Left = 0;
        public int Top = 0;
        public void Serialize(MMO_MemoryStream nbs)
        {
            nbs.Write(Uid);
            nbs.Write(Left);
            nbs.Write(Top);
        }
        public void Unserialize(MMO_MemoryStream nbs)
        {
            nbs.Read(out Uid);
            nbs.Read(out Left);
            nbs.Read(out Top);
        }
    };
    public partial class E2G_Game_PlayerXY : ProtocolMsgBase
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public E2G_Game_PlayerXY() { ProtocolId = EProtocolId.E2G_GAME_PLAYERXY; }
        public E2G_Game_PlayerXY(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                PlayerXY.Serialize(nbs);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                PlayerXY.Unserialize(nbs);
            }
        }
    };
    public partial class G2E_Game_PlayerXY : ProtocolMsgBase
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public G2E_Game_PlayerXY() { ProtocolId = EProtocolId.G2E_GAME_PLAYERXY; }
        public G2E_Game_PlayerXY(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                PlayerXY.Serialize(nbs);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                PlayerXY.Unserialize(nbs);
            }
        }
    };
    public partial class G2E_Game_PlayerXYOther : ProtocolMsgBase
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public G2E_Game_PlayerXYOther() { ProtocolId = EProtocolId.G2E_GAME_PLAYERXYOTHER; }
        public G2E_Game_PlayerXYOther(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                PlayerXY.Serialize(nbs);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                PlayerXY.Unserialize(nbs);
            }
        }
    };
    public partial class E2G_Game_MapIn : ProtocolMsgBase
    {
        public E2G_Game_MapIn() { ProtocolId = EProtocolId.E2G_GAME_MAPIN; }
        public E2G_Game_MapIn(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class G2E_Game_MapIn : ProtocolMsgBase
    {
        public CLS_PlayerXY PlayerXY = new CLS_PlayerXY();
        public G2E_Game_MapIn() { ProtocolId = EProtocolId.G2E_GAME_MAPIN; }
        public G2E_Game_MapIn(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                PlayerXY.Serialize(nbs);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                PlayerXY.Unserialize(nbs);
            }
        }
    };
    public partial class G2E_Game_MapInOther : ProtocolMsgBase
    {
        public List<CLS_PlayerXY> ListPlayerXY = new List<CLS_PlayerXY>();
        public G2E_Game_MapInOther() { ProtocolId = EProtocolId.G2E_GAME_MAPINOTHER; }
        public G2E_Game_MapInOther(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                nbs.Write(ListPlayerXY.Count);
                foreach (var k in ListPlayerXY)
                {
                    k.Serialize(nbs);
                }
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
                nbs.Read(out int var48);
                for (int k = 0; k < var48; k++)
                {
                    var var49 = new CLS_PlayerXY(); var49.Unserialize(nbs);ListPlayerXY.Add(var49);
                }
            }
        }
    };
    public partial class E2G_Game_MapOut : ProtocolMsgBase
    {
        public E2G_Game_MapOut() { ProtocolId = EProtocolId.E2G_GAME_MAPOUT; }
        public E2G_Game_MapOut(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class G2E_Game_MapOut : ProtocolMsgBase
    {
        public G2E_Game_MapOut() { ProtocolId = EProtocolId.G2E_GAME_MAPOUT; }
        public G2E_Game_MapOut(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2G_Game_LoginOut : ProtocolMsgBase
    {
        public E2G_Game_LoginOut() { ProtocolId = EProtocolId.E2G_GAME_LOGINOUT; }
        public E2G_Game_LoginOut(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class G2E_Game_LoginOut : ProtocolMsgBase
    {
        public G2E_Game_LoginOut() { ProtocolId = EProtocolId.G2E_GAME_LOGINOUT; }
        public G2E_Game_LoginOut(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };
    public partial class E2G_Game_End : ProtocolMsgBase
    {
        public E2G_Game_End() { ProtocolId = EProtocolId.E2G_GAME_END; }
        public E2G_Game_End(byte[] buffer) { Unserialize(buffer); }
        public byte[] Serialize()
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream())
            {
                nbs.Write(_protocol);
                nbs.Write(_result);
                nbs.Write(Puid);
                nbs.Write(RspPuids.Count);
                foreach (var k in RspPuids)
                {
                    nbs.Write(k);
                }
                nbs.Write(Shuttle);
                return nbs.ToArray();
            }
        }
        public void Unserialize(byte[] buffer)
        {
            using(MMO_MemoryStream nbs = new MMO_MemoryStream(buffer))
            {
                nbs.Read(out _protocol);
                nbs.Read(out _result);
                nbs.Read(out Puid);
                nbs.Read(out int count);
                for (int k = 0; k < count; k++)
                {
                    nbs.Read(out long longnum);
                    RspPuids.Add(longnum);
                }
                nbs.Read(out Shuttle);
            }
        }
    };

}

