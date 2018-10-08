
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    /// <summary>
    /// 类示例
    /// <summary>
    public partial class CLS_BaseDemo
    {
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(a1);
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
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out a1);
            nbs.Read(out a2);
            nbs.Read(out a3);
            nbs.Read(out a4);
            nbs.Read(out a5);
            nbs.Read(out a6);
            nbs.Read(out a7);
            nbs.Read(out d1);
            nbs.Read(out d2);
            if (true) { var etemp = nbs.ReadShort(); BaseDemo = (EnumBaseDemo)etemp; }
        }
    };
    /// <summary>
    /// 对应协议枚举-> ALL_BASE_DEMO
    /// 示例
    /// <summary>
    public partial class All_Base_Demo : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
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
            BaseDemo.Serialize(ref nbs);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
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
            if (true) { var etemp = nbs.ReadShort(); eBaseDemo = (EnumBaseDemo)etemp; }
            BaseDemo.Unserialize(ref nbs);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
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
            BaseDemo.Serialize(ref nbs);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
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
            if (true) { var etemp = nbs.ReadShort(); eBaseDemo = (EnumBaseDemo)etemp; }
            BaseDemo.Unserialize(ref nbs);
        }
    };
    /// <summary>
    /// 对应协议枚举-> ALL_BASE_RESULT
    /// 结果返回
    /// <summary>
    public partial class All_Base_Result : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(HandleId);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out HandleId);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(HandleId);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out HandleId);
        }
    };
    /// <summary>
    /// 对应协议枚举-> ALL_BASE_PING
    /// Ping服务器
    /// <summary>
    public partial class All_Base_Ping : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerTime);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerTime);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerTime);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerTime);
        }
    };
    /// <summary>
    /// 对应协议枚举-> ALL_BASE_GAMEVERSION
    /// 同步版本号
    /// <summary>
    public partial class All_Base_GameVersion : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(GameVersion);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out GameVersion);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(GameVersion);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out GameVersion);
        }
    };
    /// <summary>
    /// 对应协议枚举-> S2C_SERVER_CONNECT
    /// 服务器类型
    /// <summary>
    public partial class S2C_Server_Connect : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerID);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerID);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerID);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerID);
        }
    };
    /// <summary>
    /// 对应协议枚举-> C2S_SERVER_CONNECT
    /// 服务器类型
    /// <summary>
    public partial class C2S_Server_Connect : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(SessionType);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out SessionType);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(SessionType);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out SessionType);
        }
    };
    /// <summary>
    /// 对应协议枚举-> B2T_GM_START
    /// 服务器类型
    /// <summary>
    public partial class B2T_GM_Start : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> B2T_GM_LOGIN
    /// 请求 GM登陆
    /// <summary>
    public partial class B2T_GM_Login : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
    };
    /// <summary>
    /// 对应协议枚举-> T2B_GM_LOGIN
    /// 返回 GM登陆
    /// <summary>
    public partial class T2B_GM_Login : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> B2G_GM_CMD
    /// 请求 GM特殊功能
    /// <summary>
    public partial class B2G_GM_Cmd : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Cmd);
            nbs.Write(Args.Count);
            foreach (var k in Args)
            {
                nbs.Write(k);
            }
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Cmd);
            int var47 = nbs.ReadInt();
            for (int k = 0; k < var47; k++)
            {
                string var48 = nbs.ReadString();Args.Add(var48);
            }
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Cmd);
            nbs.Write(Args.Count);
            foreach (var k in Args)
            {
                nbs.Write(k);
            }
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Cmd);
            int var50 = nbs.ReadInt();
            for (int k = 0; k < var50; k++)
            {
                string var51 = nbs.ReadString();Args.Add(var51);
            }
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2B_GM_CMD
    /// 请求 GM特殊功能
    /// <summary>
    public partial class G2B_GM_Cmd : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Cmd);
            nbs.Write(Args.Count);
            foreach (var k in Args)
            {
                nbs.Write(k);
            }
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Cmd);
            int var53 = nbs.ReadInt();
            for (int k = 0; k < var53; k++)
            {
                string var54 = nbs.ReadString();Args.Add(var54);
            }
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Cmd);
            nbs.Write(Args.Count);
            foreach (var k in Args)
            {
                nbs.Write(k);
            }
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Cmd);
            int var56 = nbs.ReadInt();
            for (int k = 0; k < var56; k++)
            {
                string var57 = nbs.ReadString();Args.Add(var57);
            }
        }
    };
    /// <summary>
    /// 对应协议枚举-> B2T_GM_END
    /// 请求 GM特殊功能
    /// <summary>
    public partial class B2T_GM_End : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2D_GAME_SERVER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class G2D_Game_Server : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerID);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerID);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(ServerID);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out ServerID);
        }
    };
    /// <summary>
    /// 对应协议枚举-> D2G_GAME_SERVER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class D2G_Game_Server : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Data);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Data);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Data);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Data);
        }
    };
    /// <summary>
    /// 对应协议枚举-> L2E_GAME_START
    /// 请求 GM特殊功能
    /// <summary>
    public partial class L2E_Game_Start : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2L_GAME_LOGINSERVER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class E2L_Game_LoginServer : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
    };
    /// <summary>
    /// 对应协议枚举-> L2E_GAME_LOGINSERVER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class L2E_Game_LoginServer : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2L_GAME_REGISTER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class E2L_Game_Register : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Account);
            nbs.Write(Password);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Account);
            nbs.Read(out Password);
        }
    };
    /// <summary>
    /// 对应协议枚举-> L2E_GAME_REGISTER
    /// 请求 GM特殊功能
    /// <summary>
    public partial class L2E_Game_Register : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2L_GAME_CREATE
    /// 请求 GM特殊功能
    /// <summary>
    public partial class E2L_Game_Create : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Name);
            nbs.Write(HeroID);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Name);
            nbs.Read(out HeroID);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.Write(Name);
            nbs.Write(HeroID);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            nbs.Read(out Name);
            nbs.Read(out HeroID);
        }
    };
    /// <summary>
    /// 对应协议枚举-> L2E_GAME_CREATE
    /// 请求 GM特殊功能
    /// <summary>
    public partial class L2E_Game_Create : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> L2E_GAME_END
    /// 请求 GM特殊功能
    /// <summary>
    public partial class L2E_Game_End : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_START
    /// 请求 GM特殊功能
    /// <summary>
    public partial class E2G_Game_Start : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 类示例
    /// <summary>
    public partial class CLS_PlayerXY
    {
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(Uid);
            nbs.Write(Left);
            nbs.Write(Top);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out Uid);
            nbs.Read(out Left);
            nbs.Read(out Top);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_PLAYERXY
    /// 类示例
    /// <summary>
    public partial class E2G_Game_PlayerXY : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            PlayerXY.Serialize(ref nbs);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            PlayerXY.Unserialize(ref nbs);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            PlayerXY.Serialize(ref nbs);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            PlayerXY.Unserialize(ref nbs);
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2E_GAME_PLAYERXY
    /// 类示例
    /// <summary>
    public partial class G2E_Game_PlayerXY : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            PlayerXY.Serialize(ref nbs);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            PlayerXY.Unserialize(ref nbs);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            PlayerXY.Serialize(ref nbs);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
            PlayerXY.Unserialize(ref nbs);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_MAPIN
    /// 类示例
    /// <summary>
    public partial class E2G_Game_MapIn : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2E_GAME_MAPIN
    /// 类示例
    /// <summary>
    public partial class G2E_Game_MapIn : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_MAPOUT
    /// 类示例
    /// <summary>
    public partial class E2G_Game_MapOut : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2E_GAME_MAPOUT
    /// 类示例
    /// <summary>
    public partial class G2E_Game_MapOut : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_LOGINOUT
    /// 类示例
    /// <summary>
    public partial class E2G_Game_LoginOut : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> G2E_GAME_LOGINOUT
    /// 类示例
    /// <summary>
    public partial class G2E_Game_LoginOut : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };
    /// <summary>
    /// 对应协议枚举-> E2G_GAME_END
    /// 类示例
    /// <summary>
    public partial class E2G_Game_End : ProtocolMsgBase, INbsSerializer
    {
        public NetBitStream Serialize()
        {
            NetBitStream nbs = new NetBitStream();
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
            nbs.WriteEnd();
            return nbs;
        }
        public void Unserialize(byte[] buffer)
        {
            NetBitStream nbs = new NetBitStream();
            nbs.BeginRead(buffer);
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
        public void Serialize(ref NetBitStream nbs)
        {
            nbs.Write(_protocol);
            nbs.Write(_result);
            nbs.Write(Pin);
            nbs.Write(Puid);
            nbs.Write(Shuttle);
        }
        public void Unserialize(ref NetBitStream nbs)
        {
            nbs.Read(out _protocol);
            nbs.Read(out _result);
            nbs.Read(out Pin);
            nbs.Read(out Puid);
            nbs.Read(out Shuttle);
        }
    };

}

