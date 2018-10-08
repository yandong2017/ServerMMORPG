require("Net/LuaProtocolId")
require("Net/LuaProtocolEnum")
require("Base/Class")
require("Base/DataStructure")

local Base = require "Base/ProtocolMsgBase"

-- 对前端而言
-- 发送消息只需要 Serialize
-- 接收消息只需要 Unserialize

-- LuaCLS_BaseDemo begin
-- 类示例
LuaCLS_BaseDemo = Class()
function LuaCLS_BaseDemo:ctor()
    self.a1 = 0
    self.a2 = 0
    self.a3 = 0
    self.a4 = 0
    self.a5 = 0
    self.a6 = ""
    self.a7 = false
    self.BaseDemo = 0
end
function LuaCLS_BaseDemo:Serialize(nbs)
    nbs:WriteByte(self.a1)
    nbs:WriteShort(self.a2)
    nbs:WriteInt(self.a3)
    nbs:WriteLong(self.a4)
    nbs:WriteFloat(self.a5)
    nbs:WriteString(self.a6)
    nbs:WriteBool(self.a7)
    nbs:WriteDateTime(self.d1)
    nbs:WriteTimeSpan(self.d2)
    nbs:WriteShort(BaseDemo)
    return nbs
end
function LuaCLS_BaseDemo:Unserialize(nbs)
    self.a1 = nbs:ReadByte()
    self.a2 = nbs:ReadShort()
    self.a3 = nbs:ReadInt()
    self.a4 = nbs:ReadLong()
    self.a5 = nbs:ReadFloat()
    self.a6 = nbs:ReadString()
    self.a7 = nbs:ReadBool()
    self.d1 = nbs:ReadDateTime()
    self.d2 = nbs:ReadTimeSpan()
    self.BaseDemo = nbs:ReadShort()
end
-- LuaCLS_BaseDemo end


-- LuaAll_Base_Demo begin
-- 示例
LuaAll_Base_Demo = Class(Base)
function LuaAll_Base_Demo:ctor()
    self._protocol = LuaProtocolId["ALL_BASE_DEMO"]
    self.a1 = 0
    self.a2 = 0
    self.a3 = 0
    self.a4 = 0
    self.a5 = 0
    self.a6 = ""
    self.a7 = false
    self.eBaseDemo = 0
    self.BaseDemo = LuaCLS_BaseDemo.new()
end
-- LuaAll_Base_Demo end


-- LuaAll_Base_Result begin
-- 结果返回
LuaAll_Base_Result = Class(Base)
function LuaAll_Base_Result:ctor()
    self._protocol = LuaProtocolId["ALL_BASE_RESULT"]
    self.HandleId = 0    -- 协议ID
end
-- LuaAll_Base_Result end


-- LuaAll_Base_Ping begin
-- Ping服务器
LuaAll_Base_Ping = Class(Base)
function LuaAll_Base_Ping:ctor()
    self._protocol = LuaProtocolId["ALL_BASE_PING"]
end
-- LuaAll_Base_Ping end


-- LuaAll_Base_GameVersion begin
-- 同步版本号
LuaAll_Base_GameVersion = Class(Base)
function LuaAll_Base_GameVersion:ctor()
    self._protocol = LuaProtocolId["ALL_BASE_GAMEVERSION"]
    self.GameVersion = ""    -- 同步版本号
end
-- LuaAll_Base_GameVersion end


-- LuaB2T_GM_Start begin
-- 同步版本号
LuaB2T_GM_Start = Class(Base)
function LuaB2T_GM_Start:ctor()
    self._protocol = LuaProtocolId["B2T_GM_START"]
end
-- LuaB2T_GM_Start end


-- LuaB2T_GM_Login begin
-- 请求 GM登陆
LuaB2T_GM_Login = Class(Base)
function LuaB2T_GM_Login:ctor()
    self._protocol = LuaProtocolId["B2T_GM_LOGIN"]
    self.Account = ""    -- 账号
    self.Password = ""    -- 密码
end
-- LuaB2T_GM_Login end


-- LuaT2B_GM_Login begin
-- 返回 GM登陆
LuaT2B_GM_Login = Class(Base)
function LuaT2B_GM_Login:ctor()
    self._protocol = LuaProtocolId["T2B_GM_LOGIN"]
end
-- LuaT2B_GM_Login end


-- LuaB2G_GM_Cmd begin
-- 请求 GM特殊功能
LuaB2G_GM_Cmd = Class(Base)
function LuaB2G_GM_Cmd:ctor()
    self._protocol = LuaProtocolId["B2G_GM_CMD"]
    self.Cmd = ""    -- 指令
    self.Args = List:New(Luastring)
end
-- LuaB2G_GM_Cmd end


-- LuaG2B_GM_Cmd begin
-- 请求 GM特殊功能
LuaG2B_GM_Cmd = Class(Base)
function LuaG2B_GM_Cmd:ctor()
    self._protocol = LuaProtocolId["G2B_GM_CMD"]
    self.Cmd = ""    -- 指令
    self.Args = List:New(Luastring)
end
-- LuaG2B_GM_Cmd end


-- LuaB2T_GM_End begin
-- 请求 GM特殊功能
LuaB2T_GM_End = Class(Base)
function LuaB2T_GM_End:ctor()
    self._protocol = LuaProtocolId["B2T_GM_END"]
end
-- LuaB2T_GM_End end




