require("Net/LuaProtocolId")
require("Net/LuaProtocolEnum")
require("Base/Class")
require("Base/DataStructure")

local Base = require "Base/ProtocolMsgBase"

-- 对前端而言
-- 发送消息只需要 Serialize
-- 接收消息只需要 Unserialize

-- LuaCLS_AwardItem begin
-- 奖励物品
LuaCLS_AwardItem = Class()
function LuaCLS_AwardItem:ctor()
    self.Type = 0    -- 类型 对应 EAwardType
    self.ConfigId = 0    -- 奖励配置ID
    self.Count = 0    -- 奖励数量
    self.Level = 0    -- 等级
end
function LuaCLS_AwardItem:Serialize(nbs)
    nbs:WriteShort(self.Type)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteLong(self.Count)
    nbs:WriteInt(self.Level)
    return nbs
end
function LuaCLS_AwardItem:Unserialize(nbs)
    self.Type = nbs:ReadShort()
    self.ConfigId = nbs:ReadInt()
    self.Count = nbs:ReadLong()
    self.Level = nbs:ReadInt()
end
-- LuaCLS_AwardItem end


-- LuaCLS_CountInfo begin
-- 当前数量和上限数量
LuaCLS_CountInfo = Class()
function LuaCLS_CountInfo:ctor()
    self.Value = 0    -- 当前
    self.Limit = 0    -- 上限
end
function LuaCLS_CountInfo:Serialize(nbs)
    nbs:WriteLong(self.Value)
    nbs:WriteLong(self.Limit)
    return nbs
end
function LuaCLS_CountInfo:Unserialize(nbs)
    self.Value = nbs:ReadLong()
    self.Limit = nbs:ReadLong()
end
-- LuaCLS_CountInfo end


-- LuaCLS_NeedInfo begin
-- 需求数量和当前数量
LuaCLS_NeedInfo = Class()
function LuaCLS_NeedInfo:ctor()
    self.Need = 0    -- 需求
    self.Value = 0    -- 当前
end
function LuaCLS_NeedInfo:Serialize(nbs)
    nbs:WriteLong(self.Need)
    nbs:WriteLong(self.Value)
    return nbs
end
function LuaCLS_NeedInfo:Unserialize(nbs)
    self.Need = nbs:ReadLong()
    self.Value = nbs:ReadLong()
end
-- LuaCLS_NeedInfo end


-- LuaCLS_ValueChangeInfo begin
-- 当前数量和原来数量
LuaCLS_ValueChangeInfo = Class()
function LuaCLS_ValueChangeInfo:ctor()
    self.ValueOld = 0    -- 原数值
    self.ValueNew = 0    -- 当前
end
function LuaCLS_ValueChangeInfo:Serialize(nbs)
    nbs:WriteLong(self.ValueOld)
    nbs:WriteLong(self.ValueNew)
    return nbs
end
function LuaCLS_ValueChangeInfo:Unserialize(nbs)
    self.ValueOld = nbs:ReadLong()
    self.ValueNew = nbs:ReadLong()
end
-- LuaCLS_ValueChangeInfo end


-- LuaCLS_ItemNeedInfo begin
-- 道具需求信息
LuaCLS_ItemNeedInfo = Class()
function LuaCLS_ItemNeedInfo:ctor()
    self.Id = 0    -- ID(配置ID)
    self.Count = 0    -- 数量
    self.CountNeed = 0    -- 需求数量
end
function LuaCLS_ItemNeedInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    nbs:WriteInt(self.CountNeed)
    return nbs
end
function LuaCLS_ItemNeedInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.Count = nbs:ReadInt()
    self.CountNeed = nbs:ReadInt()
end
-- LuaCLS_ItemNeedInfo end


-- LuaCLS_PubPlayerBase begin
-- 玩家公共信息
LuaCLS_PubPlayerBase = Class()
function LuaCLS_PubPlayerBase:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.Name = ""    -- 名字
    self.HeadIndex = 0    -- 头像序号
    self.StateId = 0    -- 所属州ID
    self.Level = 0    -- 等级
    self.GuildUid = 0    -- 所属势力唯一ID
    self.GuildOffice = 0    -- 势力官职 EGuildOffice
    self.CombatPower = 0    -- 战斗力
    self.TickTimeLastLogin = 0    -- 上次登录时间
    self.bGoddess = false    -- 圣女资格
end
function LuaCLS_PubPlayerBase:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteInt(self.StateId)
    nbs:WriteInt(self.Level)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteInt(self.GuildOffice)
    nbs:WriteInt(self.CombatPower)
    nbs:WriteLong(self.TickTimeLastLogin)
    nbs:WriteBool(self.bGoddess)
    return nbs
end
function LuaCLS_PubPlayerBase:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.HeadIndex = nbs:ReadInt()
    self.StateId = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.GuildUid = nbs:ReadLong()
    self.GuildOffice = nbs:ReadInt()
    self.CombatPower = nbs:ReadInt()
    self.TickTimeLastLogin = nbs:ReadLong()
    self.bGoddess = nbs:ReadBool()
end
-- LuaCLS_PubPlayerBase end


-- LuaCLS_DataSnap begin
-- 快照数据
LuaCLS_DataSnap = Class()
function LuaCLS_DataSnap:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.ServerID = 0    -- 服务器ID
    self.Name = ""    -- 昵称
    self.HeadIndex = 0    -- 头像序号(序号为0时使用图像数据)
    self.StateId = 0    -- 所属州ID
    self.Gem = 0    -- 元宝
    self.Level = 0    -- 等级
    self.TickTimeLastLogin = 0    -- 上次登录时间
    self.ActivityLevel = 0    -- 活跃度状态 见EActivityLevel
    self.Mansion = 0    -- 所属府ID
    self.GuildUid = 0    -- 所属势力唯一ID
    self.GuildOffice = 0    -- 势力官职 EGuildOffice
    self.Contribution = 0    -- 贡献
    self.ContributionTotal = 0    -- 历史贡献
    self.CombatPower = 0    -- 战斗力
    self.AllArenaCombatPower = 0    -- 主角加竞技场武将战力
    self.PlayerData = LuaCLS_PlayerData.new()    -- 玩家单条信息
    self.bGoddess = false    -- 圣女资格
end
function LuaCLS_DataSnap:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteInt(self.ServerID)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteInt(self.StateId)
    nbs:WriteLong(self.Gem)
    nbs:WriteInt(self.Level)
    nbs:WriteLong(self.TickTimeLastLogin)
    nbs:WriteInt(self.ActivityLevel)
    nbs:WriteLong(self.Mansion)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteInt(self.GuildOffice)
    nbs:WriteInt(self.Contribution)
    nbs:WriteInt(self.ContributionTotal)
    nbs:WriteInt(self.CombatPower)
    nbs:WriteInt(self.AllArenaCombatPower)
    PlayerData:Serialize(nbs)
    nbs:WriteBool(self.bGoddess)
    return nbs
end
function LuaCLS_DataSnap:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.ServerID = nbs:ReadInt()
    self.Name = nbs:ReadString()
    self.HeadIndex = nbs:ReadInt()
    self.StateId = nbs:ReadInt()
    self.Gem = nbs:ReadLong()
    self.Level = nbs:ReadInt()
    self.TickTimeLastLogin = nbs:ReadLong()
    self.ActivityLevel = nbs:ReadInt()
    self.Mansion = nbs:ReadLong()
    self.GuildUid = nbs:ReadLong()
    self.GuildOffice = nbs:ReadInt()
    self.Contribution = nbs:ReadInt()
    self.ContributionTotal = nbs:ReadInt()
    self.CombatPower = nbs:ReadInt()
    self.AllArenaCombatPower = nbs:ReadInt()
    self.PlayerData:Unserialize(nbs)
    self.bGoddess = nbs:ReadBool()
end
-- LuaCLS_DataSnap end


-- LuaCLS_PlayerData begin
-- 玩家单条信息
LuaCLS_PlayerData = Class()
function LuaCLS_PlayerData:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.HeadIndex = 0    -- 头像序号(序号为0时使用图像数据)
    self.Name = ""    -- 名字
    self.Score = 0    -- 分数
    self.Level = 0    -- 等级
    self.DictArenaWarrior = Dictionary:New()    -- 防守队伍信息<位置，信息>
    self.Signature = ""    -- 个人签名
    self.GuildName = ""    -- 势力名称
end
function LuaCLS_PlayerData:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteString(self.Name)
    nbs:WriteLong(self.Score)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(#self.DictArenaWarrior)
    for key, value in pairs(self.DictArenaWarrior) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    nbs:WriteString(self.Signature)
    nbs:WriteString(self.GuildName)
    return nbs
end
function LuaCLS_PlayerData:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.HeadIndex = nbs:ReadInt()
    self.Name = nbs:ReadString()
    self.Score = nbs:ReadLong()
    self.Level = nbs:ReadInt()
    local var2939 = nbs:ReadInt()
    for i = 1, var2939 do
        local var2940 = nbs:ReadInt()
        local var2941 = LuaCLS_WarriorInfo.new()
        var2941:Unserialize(nbs)
        self.DictArenaWarrior:Add(var2940, var2941)
    end
    self.Signature = nbs:ReadString()
    self.GuildName = nbs:ReadString()
end
-- LuaCLS_PlayerData end


-- LuaCLS_GameLog begin
-- 动态日志
LuaCLS_GameLog = Class()
function LuaCLS_GameLog:ctor()
    self.GameLogType = 0    -- 动态日志类型 EGameLogType
    self.Args = List:New(Luastring)    -- 参数
end
function LuaCLS_GameLog:Serialize(nbs)
    nbs:WriteDateTime(self.GameLogTime)
    nbs:WriteShort(GameLogType)
    nbs:WriteInt(#self.Args)
    for i = 1, #self.Args do
        nbs:WriteString(self.Args[i])
    end
    return nbs
end
function LuaCLS_GameLog:Unserialize(nbs)
    self.GameLogTime = nbs:ReadDateTime()
    self.GameLogType = nbs:ReadShort()
    local var2946 = nbs:ReadInt()
    for i = 1, var2946 do
        local var2947 = nbs:ReadString()
        self.Args:Add(var2947)
    end
end
-- LuaCLS_GameLog end


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


-- LuaC2G_Debug_Cmd begin
-- 请求 调试指令
LuaC2G_Debug_Cmd = Class(Base)
function LuaC2G_Debug_Cmd:ctor()
    self._protocol = LuaProtocolId["C2G_DEBUG_CMD"]
    self.Cmd = 0
    self.ListArgs = List:New(Luastring)
end
function LuaC2G_Debug_Cmd:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Cmd)
    nbs:WriteInt(#self.ListArgs)
    for i = 1, #self.ListArgs do
        nbs:WriteString(self.ListArgs[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Debug_Cmd end


-- LuaG2C_Debug_Cmd begin
-- 返回 调试指令
LuaG2C_Debug_Cmd = Class(Base)
function LuaG2C_Debug_Cmd:ctor()
    self._protocol = LuaProtocolId["G2C_DEBUG_CMD"]
end
function LuaG2C_Debug_Cmd:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Debug_Cmd end


-- LuaG2C_Login_Connect begin
-- 连接成功
LuaG2C_Login_Connect = Class(Base)
function LuaG2C_Login_Connect:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_CONNECT"]
end
function LuaG2C_Login_Connect:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_Connect end


-- LuaC2L_Login_UserLogin begin
-- 请求 登陆用户账号
LuaC2L_Login_UserLogin = Class(Base)
function LuaC2L_Login_UserLogin:ctor()
    self._protocol = LuaProtocolId["C2L_LOGIN_USERLOGIN"]
    self.Account = ""    -- 账号
    self.Password = ""    -- 密码
end
-- LuaC2L_Login_UserLogin end


-- LuaL2C_Login_UserLogin begin
-- 返回 登陆用户账号
LuaL2C_Login_UserLogin = Class(Base)
function LuaL2C_Login_UserLogin:ctor()
    self._protocol = LuaProtocolId["L2C_LOGIN_USERLOGIN"]
    self.Uuid = 0    -- 用户id
    self.Code = 0    -- 验证码
    self.NeedAgree = false    -- 是否需要显示协议
end
-- LuaL2C_Login_UserLogin end


-- LuaC2G_Login_PlayerLogin begin
-- 请求 登陆玩家
LuaC2G_Login_PlayerLogin = Class(Base)
function LuaC2G_Login_PlayerLogin:ctor()
    self._protocol = LuaProtocolId["C2G_LOGIN_PLAYERLOGIN"]
    self.Uuid = 0    -- 用户id
    self.Code = 0    -- 验证码
end
function LuaC2G_Login_PlayerLogin:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uuid)
    nbs:WriteLong(self.Code)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Login_PlayerLogin end


-- LuaG2C_Login_PlayerLogin begin
-- 返回 登陆玩家
LuaG2C_Login_PlayerLogin = Class(Base)
function LuaG2C_Login_PlayerLogin:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_PLAYERLOGIN"]
end
function LuaG2C_Login_PlayerLogin:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_PlayerLogin end


-- LuaC2G_Login_PlayerCreate begin
-- 请求 玩家创建
LuaC2G_Login_PlayerCreate = Class(Base)
function LuaC2G_Login_PlayerCreate:ctor()
    self._protocol = LuaProtocolId["C2G_LOGIN_PLAYERCREATE"]
    self.Name = ""    -- 玩家名字
    self.Head = 0    -- 头像
    self.StateId = 0    -- 所属州ID
end
function LuaC2G_Login_PlayerCreate:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.Head)
    nbs:WriteInt(self.StateId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Login_PlayerCreate end


-- LuaG2C_Login_PlayerCreate begin
-- 返回 玩家创建
LuaG2C_Login_PlayerCreate = Class(Base)
function LuaG2C_Login_PlayerCreate:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_PLAYERCREATE"]
end
function LuaG2C_Login_PlayerCreate:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_PlayerCreate end


-- LuaG2C_Login_Replaced begin
-- 通知玩家被取代连接
LuaG2C_Login_Replaced = Class(Base)
function LuaG2C_Login_Replaced:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_REPLACED"]
end
function LuaG2C_Login_Replaced:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_Replaced end


-- LuaG2C_Login_Ban begin
-- 通知玩家被封号
LuaG2C_Login_Ban = Class(Base)
function LuaG2C_Login_Ban:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_BAN"]
end
function LuaG2C_Login_Ban:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_Ban end


-- LuaCLS_LoginStateInfo begin
-- 州信息
LuaCLS_LoginStateInfo = Class()
function LuaCLS_LoginStateInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.Population = 0    -- 人口数
end
function LuaCLS_LoginStateInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.Population)
    return nbs
end
function LuaCLS_LoginStateInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.Population = nbs:ReadLong()
end
-- LuaCLS_LoginStateInfo end


-- LuaC2G_Login_ListState begin
-- 请求 州信息
LuaC2G_Login_ListState = Class(Base)
function LuaC2G_Login_ListState:ctor()
    self._protocol = LuaProtocolId["C2G_LOGIN_LISTSTATE"]
end
function LuaC2G_Login_ListState:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Login_ListState end


-- LuaG2C_Login_ListState begin
-- 返回 州信息
LuaG2C_Login_ListState = Class(Base)
function LuaG2C_Login_ListState:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_LISTSTATE"]
    self.ListState = List:New(LuaCLS_LoginStateInfo)    -- 州信息
end
function LuaG2C_Login_ListState:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var2960 = nbs:ReadInt()
    for i = 1, var2960 do
        local var2961 = LuaCLS_LoginStateInfo.new()
        var2961:Unserialize(nbs)
        self.ListState:Add(var2961)
    end
end
-- LuaG2C_Login_ListState end


-- LuaC2G_Login_CheckName begin
-- 请求 检测名字
LuaC2G_Login_CheckName = Class(Base)
function LuaC2G_Login_CheckName:ctor()
    self._protocol = LuaProtocolId["C2G_LOGIN_CHECKNAME"]
    self.Name = ""    -- 玩家名字
end
function LuaC2G_Login_CheckName:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Name)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Login_CheckName end


-- LuaG2C_Login_CheckName begin
-- 返回 检测名字
LuaG2C_Login_CheckName = Class(Base)
function LuaG2C_Login_CheckName:ctor()
    self._protocol = LuaProtocolId["G2C_LOGIN_CHECKNAME"]
end
function LuaG2C_Login_CheckName:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Login_CheckName end


-- LuaCLS_Info_Base begin
-- 玩家基本信息
LuaCLS_Info_Base = Class()
function LuaCLS_Info_Base:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.Name = ""    -- 名字
    self.HeadIndex = 0    -- 头像序号(序号为0时使用图像数据)
    self.StateId = 0    -- 所属州ID
    self.Gem = 0    -- 元宝
    self.Gold = 0    -- 金币
    self.FuYu = 0    -- 府玉
    self.Silver = 0    -- 银两
    self.Wood = 0    -- 木材
    self.Iron = 0    -- 铁矿
    self.Food = 0    -- 粮草
    self.CapacityWood = 0    -- 木材容量
    self.CapacityIron = 0    -- 铁矿容量
    self.CapacityFood = 0    -- 粮草容量
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验值
    self.VipLevel = 0    -- VIP等级
    self.VipExp = 0    -- Vip经验值
    self.Spirit = 0    -- 体力
    self.TowerToken = 0    -- 挑战令牌
    self.TowerScore = 0    -- 武神积分
    self.Card = 0    -- 军牌
    self.Prestige = 0    -- 声望
    self.DrawScore = 0    -- 宴会厅积分
    self.GuildUid = 0    -- 所属势力唯一ID
    self.GuildOffice = 0    -- 势力官职 EGuildOffice
    self.GuildName = ""    -- 所属势力名字
    self.MyCapitalCity = 0    -- 势力都城
    self.GuildState = 0    -- 势力所属州
    self.Soldiers1 = 0    -- 预备步兵
    self.Soldiers2 = 0    -- 预备骑兵
    self.Soldiers3 = 0    -- 预备弓兵
    self.BuyGoldTimes = 0    -- 购买金币次数
end
function LuaCLS_Info_Base:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteInt(self.StateId)
    nbs:WriteLong(self.Gem)
    nbs:WriteLong(self.Gold)
    nbs:WriteLong(self.FuYu)
    nbs:WriteLong(self.Silver)
    nbs:WriteLong(self.Wood)
    nbs:WriteLong(self.Iron)
    nbs:WriteLong(self.Food)
    nbs:WriteLong(self.CapacityWood)
    nbs:WriteLong(self.CapacityIron)
    nbs:WriteLong(self.CapacityFood)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.Exp)
    nbs:WriteInt(self.VipLevel)
    nbs:WriteInt(self.VipExp)
    nbs:WriteInt(self.Spirit)
    nbs:WriteInt(self.TowerToken)
    nbs:WriteInt(self.TowerScore)
    nbs:WriteInt(self.Card)
    nbs:WriteInt(self.Prestige)
    nbs:WriteInt(self.DrawScore)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteInt(self.GuildOffice)
    nbs:WriteString(self.GuildName)
    nbs:WriteInt(self.MyCapitalCity)
    nbs:WriteInt(self.GuildState)
    nbs:WriteInt(self.Soldiers1)
    nbs:WriteInt(self.Soldiers2)
    nbs:WriteInt(self.Soldiers3)
    nbs:WriteInt(self.BuyGoldTimes)
    return nbs
end
function LuaCLS_Info_Base:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.HeadIndex = nbs:ReadInt()
    self.StateId = nbs:ReadInt()
    self.Gem = nbs:ReadLong()
    self.Gold = nbs:ReadLong()
    self.FuYu = nbs:ReadLong()
    self.Silver = nbs:ReadLong()
    self.Wood = nbs:ReadLong()
    self.Iron = nbs:ReadLong()
    self.Food = nbs:ReadLong()
    self.CapacityWood = nbs:ReadLong()
    self.CapacityIron = nbs:ReadLong()
    self.CapacityFood = nbs:ReadLong()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
    self.VipLevel = nbs:ReadInt()
    self.VipExp = nbs:ReadInt()
    self.Spirit = nbs:ReadInt()
    self.TowerToken = nbs:ReadInt()
    self.TowerScore = nbs:ReadInt()
    self.Card = nbs:ReadInt()
    self.Prestige = nbs:ReadInt()
    self.DrawScore = nbs:ReadInt()
    self.GuildUid = nbs:ReadLong()
    self.GuildOffice = nbs:ReadInt()
    self.GuildName = nbs:ReadString()
    self.MyCapitalCity = nbs:ReadInt()
    self.GuildState = nbs:ReadInt()
    self.Soldiers1 = nbs:ReadInt()
    self.Soldiers2 = nbs:ReadInt()
    self.Soldiers3 = nbs:ReadInt()
    self.BuyGoldTimes = nbs:ReadInt()
end
-- LuaCLS_Info_Base end


-- LuaCLS_Info_Misc begin
-- 玩家杂项信息
LuaCLS_Info_Misc = Class()
function LuaCLS_Info_Misc:ctor()
    self.dictFlagClient = Dictionary:New()    -- 客户端特殊标记
    self.WoodFull = false    -- 木材已满
    self.IronFull = false    -- 铁矿已满
    self.FoodFull = false    -- 粮草已满
    self.CanSign = false    -- 可以签到
    self.MailUnread = 0    -- 未读邮件数目
    self.BankStatus = 0    -- 长安夺宝活动状态 1 开启 0未开启
    self.WarriorBagId = 0    -- 武将背包当前已买ID
    self.WarriorCount = 0    -- 当前武将数目
    self.WarriorCountMax = 0    -- 武将背包上限
    self.Signature = ""    -- 个人签名
    self.bFriend = false    -- 好友提示
    self.bChat = false    -- 私聊提示
    self.TickTimeRegister = 0    -- 注册时间
    self.ListAlliance = List:New(Lualong)    -- 同盟势力
    self.ListGuildCityMy = List:New(Luaint)    -- 我方城池
    self.ListGuildCityAlliance = List:New(Luaint)    -- 同盟城池
    self.WelfareIsOpen = false    -- 福利开启
    self.WelfareNoticeNum = 0    -- 福利完成数目
end
function LuaCLS_Info_Misc:Serialize(nbs)
    nbs:WriteInt(#self.dictFlagClient)
    for key, value in pairs(self.dictFlagClient) do
        nbs:WriteInt(key)
        nbs:WriteInt(value)
    end
    nbs:WriteBool(self.WoodFull)
    nbs:WriteBool(self.IronFull)
    nbs:WriteBool(self.FoodFull)
    nbs:WriteBool(self.CanSign)
    nbs:WriteInt(self.MailUnread)
    nbs:WriteInt(self.BankStatus)
    nbs:WriteInt(self.WarriorBagId)
    nbs:WriteInt(self.WarriorCount)
    nbs:WriteInt(self.WarriorCountMax)
    nbs:WriteString(self.Signature)
    nbs:WriteBool(self.bFriend)
    nbs:WriteBool(self.bChat)
    nbs:WriteLong(self.TickTimeRegister)
    nbs:WriteInt(#self.ListAlliance)
    for i = 1, #self.ListAlliance do
        nbs:WriteLong(self.ListAlliance[i])
    end
    nbs:WriteInt(#self.ListGuildCityMy)
    for i = 1, #self.ListGuildCityMy do
        nbs:WriteInt(self.ListGuildCityMy[i])
    end
    nbs:WriteInt(#self.ListGuildCityAlliance)
    for i = 1, #self.ListGuildCityAlliance do
        nbs:WriteInt(self.ListGuildCityAlliance[i])
    end
    nbs:WriteBool(self.WelfareIsOpen)
    nbs:WriteInt(self.WelfareNoticeNum)
    return nbs
end
function LuaCLS_Info_Misc:Unserialize(nbs)
    local var2995 = nbs:ReadInt()
    for i = 1, var2995 do
        local var2996 = nbs:ReadInt()
        local var2997 = nbs:ReadInt()
        self.dictFlagClient:Add(var2996, var2997)
    end
    self.WoodFull = nbs:ReadBool()
    self.IronFull = nbs:ReadBool()
    self.FoodFull = nbs:ReadBool()
    self.CanSign = nbs:ReadBool()
    self.MailUnread = nbs:ReadInt()
    self.BankStatus = nbs:ReadInt()
    self.WarriorBagId = nbs:ReadInt()
    self.WarriorCount = nbs:ReadInt()
    self.WarriorCountMax = nbs:ReadInt()
    self.Signature = nbs:ReadString()
    self.bFriend = nbs:ReadBool()
    self.bChat = nbs:ReadBool()
    self.TickTimeRegister = nbs:ReadLong()
    local var3011 = nbs:ReadInt()
    for i = 1, var3011 do
        local var3012 = nbs:ReadLong()
        self.ListAlliance:Add(var3012)
    end
    local var3013 = nbs:ReadInt()
    for i = 1, var3013 do
        local var3014 = nbs:ReadInt()
        self.ListGuildCityMy:Add(var3014)
    end
    local var3015 = nbs:ReadInt()
    for i = 1, var3015 do
        local var3016 = nbs:ReadInt()
        self.ListGuildCityAlliance:Add(var3016)
    end
    self.WelfareIsOpen = nbs:ReadBool()
    self.WelfareNoticeNum = nbs:ReadInt()
end
-- LuaCLS_Info_Misc end


-- LuaC2G_Info_GetAll begin
-- 请求 玩家全部信息
LuaC2G_Info_GetAll = Class(Base)
function LuaC2G_Info_GetAll:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_GETALL"]
end
function LuaC2G_Info_GetAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_GetAll end


-- LuaG2C_Info_GetAll begin
-- 返回 玩家全部信息
LuaG2C_Info_GetAll = Class(Base)
function LuaG2C_Info_GetAll:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_GETALL"]
    self.InfoBase = LuaCLS_Info_Base.new()
    self.InfoMisc = LuaCLS_Info_Misc.new()
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Info_GetAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.InfoBase:Unserialize(nbs)
    self.InfoMisc:Unserialize(nbs)
    local var3021 = nbs:ReadInt()
    for i = 1, var3021 do
        local var3022 = LuaCLS_ItemInfo.new()
        var3022:Unserialize(nbs)
        self.ListItem:Add(var3022)
    end
end
-- LuaG2C_Info_GetAll end


-- LuaG2C_Info_PushAll begin
-- 推送 玩家信息 全部
LuaG2C_Info_PushAll = Class(Base)
function LuaG2C_Info_PushAll:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PUSHALL"]
    self.InfoBase = LuaCLS_Info_Base.new()
    self.InfoMisc = LuaCLS_Info_Misc.new()
end
function LuaG2C_Info_PushAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.InfoBase:Unserialize(nbs)
    self.InfoMisc:Unserialize(nbs)
end
-- LuaG2C_Info_PushAll end


-- LuaG2C_Info_PushItem begin
-- 推送 玩家信息 道具
LuaG2C_Info_PushItem = Class(Base)
function LuaG2C_Info_PushItem:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PUSHITEM"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Info_PushItem:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3025 = nbs:ReadInt()
    for i = 1, var3025 do
        local var3026 = LuaCLS_ItemInfo.new()
        var3026:Unserialize(nbs)
        self.ListItem:Add(var3026)
    end
end
-- LuaG2C_Info_PushItem end


-- LuaG2C_Info_PushEquip begin
-- 推送 玩家信息 装备
LuaG2C_Info_PushEquip = Class(Base)
function LuaG2C_Info_PushEquip:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PUSHEQUIP"]
    self.PageIndex = 0    -- 页码1-n (返回每页100条) (0=结束)
    self.DictEquip = Dictionary:New()    -- 装备列表
end
function LuaG2C_Info_PushEquip:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PageIndex = nbs:ReadInt()
    local var3028 = nbs:ReadInt()
    for i = 1, var3028 do
        local var3029 = nbs:ReadLong()
        local var3030 = LuaCLS_EquipInfo.new()
        var3030:Unserialize(nbs)
        self.DictEquip:Add(var3029, var3030)
    end
end
-- LuaG2C_Info_PushEquip end


-- LuaG2C_Info_PushWarrior begin
-- 推送 玩家信息 武将
LuaG2C_Info_PushWarrior = Class(Base)
function LuaG2C_Info_PushWarrior:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PUSHWARRIOR"]
    self.PageIndex = 0    -- 页码1-n (返回每页100条) (0=结束)
    self.ListWarrior = List:New(LuaCLS_WarriorInfo)    -- 武将列表
end
function LuaG2C_Info_PushWarrior:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PageIndex = nbs:ReadInt()
    local var3032 = nbs:ReadInt()
    for i = 1, var3032 do
        local var3033 = LuaCLS_WarriorInfo.new()
        var3033:Unserialize(nbs)
        self.ListWarrior:Add(var3033)
    end
end
-- LuaG2C_Info_PushWarrior end


-- LuaCLS_UpdateInfoItem begin
-- 更新 道具
LuaCLS_UpdateInfoItem = Class()
function LuaCLS_UpdateInfoItem:ctor()
    self.Mode = 0
    self.ItemInfo = LuaCLS_ItemInfo.new()
end
function LuaCLS_UpdateInfoItem:Serialize(nbs)
    nbs:WriteByte(self.Mode)
    ItemInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_UpdateInfoItem:Unserialize(nbs)
    self.Mode = nbs:ReadByte()
    self.ItemInfo:Unserialize(nbs)
end
-- LuaCLS_UpdateInfoItem end


-- LuaCLS_UpdateInfoEquip begin
-- 更新 装备
LuaCLS_UpdateInfoEquip = Class()
function LuaCLS_UpdateInfoEquip:ctor()
    self.Mode = 0
    self.EquipInfo = LuaCLS_EquipInfo.new()
end
function LuaCLS_UpdateInfoEquip:Serialize(nbs)
    nbs:WriteByte(self.Mode)
    EquipInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_UpdateInfoEquip:Unserialize(nbs)
    self.Mode = nbs:ReadByte()
    self.EquipInfo:Unserialize(nbs)
end
-- LuaCLS_UpdateInfoEquip end


-- LuaCLS_UpdateInfoWarrior begin
-- 更新 武将
LuaCLS_UpdateInfoWarrior = Class()
function LuaCLS_UpdateInfoWarrior:ctor()
    self.Mode = 0
    self.WarriorInfo = LuaCLS_WarriorInfo.new()
end
function LuaCLS_UpdateInfoWarrior:Serialize(nbs)
    nbs:WriteByte(self.Mode)
    WarriorInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_UpdateInfoWarrior:Unserialize(nbs)
    self.Mode = nbs:ReadByte()
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaCLS_UpdateInfoWarrior end


-- LuaG2C_Info_PushUpdate begin
-- 推送 玩家信息 更新
LuaG2C_Info_PushUpdate = Class(Base)
function LuaG2C_Info_PushUpdate:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PUSHUPDATE"]
    self.ListUpdateItem = List:New(LuaCLS_UpdateInfoItem)
    self.ListUpdateEquip = List:New(LuaCLS_UpdateInfoEquip)
    self.ListUpdateWarrior = List:New(LuaCLS_UpdateInfoWarrior)
end
function LuaG2C_Info_PushUpdate:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3040 = nbs:ReadInt()
    for i = 1, var3040 do
        local var3041 = LuaCLS_UpdateInfoItem.new()
        var3041:Unserialize(nbs)
        self.ListUpdateItem:Add(var3041)
    end
    local var3042 = nbs:ReadInt()
    for i = 1, var3042 do
        local var3043 = LuaCLS_UpdateInfoEquip.new()
        var3043:Unserialize(nbs)
        self.ListUpdateEquip:Add(var3043)
    end
    local var3044 = nbs:ReadInt()
    for i = 1, var3044 do
        local var3045 = LuaCLS_UpdateInfoWarrior.new()
        var3045:Unserialize(nbs)
        self.ListUpdateWarrior:Add(var3045)
    end
end
-- LuaG2C_Info_PushUpdate end


-- LuaC2G_Info_ChangeName begin
-- 请求 更改姓名
LuaC2G_Info_ChangeName = Class(Base)
function LuaC2G_Info_ChangeName:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_CHANGENAME"]
    self.Name = ""
end
function LuaC2G_Info_ChangeName:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Name)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_ChangeName end


-- LuaG2C_Info_ChangeName begin
-- 返回 更改姓名
LuaG2C_Info_ChangeName = Class(Base)
function LuaG2C_Info_ChangeName:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_CHANGENAME"]
    self.Name = ""
end
function LuaG2C_Info_ChangeName:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Name = nbs:ReadString()
end
-- LuaG2C_Info_ChangeName end


-- LuaC2G_Info_ChangeFlagClient begin
-- 请求 更改客户端特殊标记
LuaC2G_Info_ChangeFlagClient = Class(Base)
function LuaC2G_Info_ChangeFlagClient:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_CHANGEFLAGCLIENT"]
    self.FlagKey = 0
    self.FlagValue = 0
end
function LuaC2G_Info_ChangeFlagClient:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.FlagKey)
    nbs:WriteInt(self.FlagValue)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_ChangeFlagClient end


-- LuaG2C_Info_ChangeFlagClient begin
-- 返回 更改客户端特殊标记
LuaG2C_Info_ChangeFlagClient = Class(Base)
function LuaG2C_Info_ChangeFlagClient:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_CHANGEFLAGCLIENT"]
    self.FlagKey = 0
    self.FlagValue = 0
end
function LuaG2C_Info_ChangeFlagClient:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.FlagKey = nbs:ReadInt()
    self.FlagValue = nbs:ReadInt()
end
-- LuaG2C_Info_ChangeFlagClient end


-- LuaC2G_Info_ChangeHeadIndex begin
-- 请求 更换头像
LuaC2G_Info_ChangeHeadIndex = Class(Base)
function LuaC2G_Info_ChangeHeadIndex:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_CHANGEHEADINDEX"]
    self.HeadIndex = 0    -- 头像序号(序号为0时使用图像数据)
end
function LuaC2G_Info_ChangeHeadIndex:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_ChangeHeadIndex end


-- LuaG2C_Info_ChangeHeadIndex begin
-- 返回 更换头像
LuaG2C_Info_ChangeHeadIndex = Class(Base)
function LuaG2C_Info_ChangeHeadIndex:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_CHANGEHEADINDEX"]
    self.HeadIndex = 0    -- 头像序号(序号为0时使用图像数据)
end
function LuaG2C_Info_ChangeHeadIndex:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.HeadIndex = nbs:ReadInt()
end
-- LuaG2C_Info_ChangeHeadIndex end


-- LuaC2G_Info_ChangeHeadData begin
-- 请求 上传头像数据
LuaC2G_Info_ChangeHeadData = Class(Base)
function LuaC2G_Info_ChangeHeadData:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_CHANGEHEADDATA"]
    self.HeadData = List:New(Luabyte)    -- 头像数据
end
function LuaC2G_Info_ChangeHeadData:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.HeadData)
    for i = 1, #self.HeadData do
        nbs:WriteByte(self.HeadData[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_ChangeHeadData end


-- LuaG2C_Info_ChangeHeadData begin
-- 返回 上传头像数据
LuaG2C_Info_ChangeHeadData = Class(Base)
function LuaG2C_Info_ChangeHeadData:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_CHANGEHEADDATA"]
end
function LuaG2C_Info_ChangeHeadData:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Info_ChangeHeadData end


-- LuaC2G_Info_SubmitBug begin
-- 请求 反馈问题
LuaC2G_Info_SubmitBug = Class(Base)
function LuaC2G_Info_SubmitBug:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_SUBMITBUG"]
    self.Text = ""
end
function LuaC2G_Info_SubmitBug:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Text)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_SubmitBug end


-- LuaG2C_Info_SubmitBug begin
-- 返回 反馈问题
LuaG2C_Info_SubmitBug = Class(Base)
function LuaG2C_Info_SubmitBug:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_SUBMITBUG"]
end
function LuaG2C_Info_SubmitBug:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Info_SubmitBug end


-- LuaG2C_Info_NotifyLevelUp begin
-- 通知 玩家升级
LuaG2C_Info_NotifyLevelUp = Class(Base)
function LuaG2C_Info_NotifyLevelUp:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_NOTIFYLEVELUP"]
    self.ChangeLevel = LuaCLS_ValueChangeInfo.new()    -- 等级变化
    self.ChangeExp = LuaCLS_ValueChangeInfo.new()    -- 经验变化
    self.ChangeSpirit = LuaCLS_ValueChangeInfo.new()    -- 体力变化
end
function LuaG2C_Info_NotifyLevelUp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ChangeLevel:Unserialize(nbs)
    self.ChangeExp:Unserialize(nbs)
    self.ChangeSpirit:Unserialize(nbs)
end
-- LuaG2C_Info_NotifyLevelUp end


-- LuaC2G_Info_PlayerData begin
-- 请求 玩家单条信息
LuaC2G_Info_PlayerData = Class(Base)
function LuaC2G_Info_PlayerData:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_PLAYERDATA"]
    self.Id = 0    -- 唯一ID
end
function LuaC2G_Info_PlayerData:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_PlayerData end


-- LuaG2C_Info_PlayerData begin
-- 返回 玩家单条信息
LuaG2C_Info_PlayerData = Class(Base)
function LuaG2C_Info_PlayerData:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_PLAYERDATA"]
    self.PlayerInfo = LuaCLS_PlayerData.new()    -- 玩家单条信息
    self.bFriend = false    -- 是否是好友
    self.bScreen = false    -- 是否已屏蔽
end
function LuaG2C_Info_PlayerData:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PlayerInfo:Unserialize(nbs)
    self.bFriend = nbs:ReadBool()
    self.bScreen = nbs:ReadBool()
end
-- LuaG2C_Info_PlayerData end


-- LuaC2G_Info_ChangeSignature begin
-- 请求 更改个人签名
LuaC2G_Info_ChangeSignature = Class(Base)
function LuaC2G_Info_ChangeSignature:ctor()
    self._protocol = LuaProtocolId["C2G_INFO_CHANGESIGNATURE"]
    self.Signature = ""
end
function LuaC2G_Info_ChangeSignature:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Signature)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Info_ChangeSignature end


-- LuaG2C_Info_ChangeSignature begin
-- 返回 更改个人签名
LuaG2C_Info_ChangeSignature = Class(Base)
function LuaG2C_Info_ChangeSignature:ctor()
    self._protocol = LuaProtocolId["G2C_INFO_CHANGESIGNATURE"]
    self.Signature = ""
end
function LuaG2C_Info_ChangeSignature:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Signature = nbs:ReadString()
end
-- LuaG2C_Info_ChangeSignature end


-- LuaC2G_Notice_System begin
-- 请求 系统公告
LuaC2G_Notice_System = Class(Base)
function LuaC2G_Notice_System:ctor()
    self._protocol = LuaProtocolId["C2G_NOTICE_SYSTEM"]
end
function LuaC2G_Notice_System:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Notice_System end


-- LuaG2C_Notice_System begin
-- 返回 系统公告
LuaG2C_Notice_System = Class(Base)
function LuaG2C_Notice_System:ctor()
    self._protocol = LuaProtocolId["G2C_NOTICE_SYSTEM"]
    self.Text = ""    -- 内容
end
function LuaG2C_Notice_System:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Text = nbs:ReadString()
end
-- LuaG2C_Notice_System end


-- LuaC2G_Notice_Activity begin
-- 请求 活动公告
LuaC2G_Notice_Activity = Class(Base)
function LuaC2G_Notice_Activity:ctor()
    self._protocol = LuaProtocolId["C2G_NOTICE_ACTIVITY"]
end
function LuaC2G_Notice_Activity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Notice_Activity end


-- LuaG2C_Notice_Activity begin
-- 返回 活动公告
LuaG2C_Notice_Activity = Class(Base)
function LuaG2C_Notice_Activity:ctor()
    self._protocol = LuaProtocolId["G2C_NOTICE_ACTIVITY"]
    self.ListText = List:New(Luastring)    -- 内容
end
function LuaG2C_Notice_Activity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3058 = nbs:ReadInt()
    for i = 1, var3058 do
        local var3059 = nbs:ReadString()
        self.ListText:Add(var3059)
    end
end
-- LuaG2C_Notice_Activity end


-- LuaG2C_Notice_Rolling begin
-- 发送 走马灯
LuaG2C_Notice_Rolling = Class(Base)
function LuaG2C_Notice_Rolling:ctor()
    self._protocol = LuaProtocolId["G2C_NOTICE_ROLLING"]
    self.Type = 0    -- 走马灯类型 见ENoticeRollingType
    self.Text = ""    -- 内容
    self.Count = 0    -- 播放次数
end
function LuaG2C_Notice_Rolling:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Type = nbs:ReadByte()
    self.Text = nbs:ReadString()
    self.Count = nbs:ReadInt()
end
-- LuaG2C_Notice_Rolling end


-- LuaCLS_MailInfo begin
-- 邮件信息
LuaCLS_MailInfo = Class()
function LuaCLS_MailInfo:ctor()
    self.Id = 0    -- 邮件ID
    self.MailType = 0    -- 邮件类型
    self.Title = ""    -- 标题
    self.HasAttachments = false    -- 是否有附件
    self.Readed = false    -- 已读
    self.Got = false    -- 已领
    self.Saved = false    -- 保存
    self.CreateTime = ""    -- 发送时间
    self.Sended = false    -- 已发邮件
    self.ReceiveName = ""    -- 收件人(已发邮件生效 个人邮件:名字 郡邮件:郡ID 府邮件:府ID)
    self.SenderName = ""    -- 发件人名字
end
function LuaCLS_MailInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteShort(self.MailType)
    nbs:WriteString(self.Title)
    nbs:WriteBool(self.HasAttachments)
    nbs:WriteBool(self.Readed)
    nbs:WriteBool(self.Got)
    nbs:WriteBool(self.Saved)
    nbs:WriteString(self.CreateTime)
    nbs:WriteBool(self.Sended)
    nbs:WriteString(self.ReceiveName)
    nbs:WriteString(self.SenderName)
    return nbs
end
function LuaCLS_MailInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.MailType = nbs:ReadShort()
    self.Title = nbs:ReadString()
    self.HasAttachments = nbs:ReadBool()
    self.Readed = nbs:ReadBool()
    self.Got = nbs:ReadBool()
    self.Saved = nbs:ReadBool()
    self.CreateTime = nbs:ReadString()
    self.Sended = nbs:ReadBool()
    self.ReceiveName = nbs:ReadString()
    self.SenderName = nbs:ReadString()
end
-- LuaCLS_MailInfo end


-- LuaCLS_MailInfoDetails begin
-- 邮件信息 详细
LuaCLS_MailInfoDetails = Class()
function LuaCLS_MailInfoDetails:ctor()
    self.Id = 0    -- 邮件ID
    self.MailInfo = LuaCLS_MailInfo.new()    -- 邮件信息
    self.Body = ""    -- 正文
    self.listAward = List:New(LuaCLS_AwardItem)    -- 附件列表
end
function LuaCLS_MailInfoDetails:Serialize(nbs)
    nbs:WriteLong(self.Id)
    MailInfo:Serialize(nbs)
    nbs:WriteString(self.Body)
    nbs:WriteInt(#self.listAward)
    for i = 1, #self.listAward do
        (self.listAward[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_MailInfoDetails:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.MailInfo:Unserialize(nbs)
    self.Body = nbs:ReadString()
    local var3077 = nbs:ReadInt()
    for i = 1, var3077 do
        local var3078 = LuaCLS_AwardItem.new()
        var3078:Unserialize(nbs)
        self.listAward:Add(var3078)
    end
end
-- LuaCLS_MailInfoDetails end


-- LuaCLS_MailInfoSend begin
-- 邮件信息 发送
LuaCLS_MailInfoSend = Class()
function LuaCLS_MailInfoSend:ctor()
    self.MailType = 0
    self.Title = ""    -- 标题
    self.Body = ""    -- 正文
    self.SenderName = ""    -- 发件人名字
    self.ReceiveName = ""    -- 收件人名字
end
function LuaCLS_MailInfoSend:Serialize(nbs)
    nbs:WriteShort(self.MailType)
    nbs:WriteString(self.Title)
    nbs:WriteString(self.Body)
    nbs:WriteString(self.SenderName)
    nbs:WriteString(self.ReceiveName)
    return nbs
end
function LuaCLS_MailInfoSend:Unserialize(nbs)
    self.MailType = nbs:ReadShort()
    self.Title = nbs:ReadString()
    self.Body = nbs:ReadString()
    self.SenderName = nbs:ReadString()
    self.ReceiveName = nbs:ReadString()
end
-- LuaCLS_MailInfoSend end


-- LuaCLS_SystemMailInfoSend begin
--  系统给玩家发送邮件信息
LuaCLS_SystemMailInfoSend = Class()
function LuaCLS_SystemMailInfoSend:ctor()
    self.Id = 0    -- 邮件ID
    self.TargetType = 0
    self.ListTarget = List:New(Luastring)    -- 接收者列表
    self.Title = ""    -- 标题
    self.Body = ""    -- 正文
    self.SenderName = ""    -- 邮件发送者
    self.ListAttachments = List:New(LuaCLS_AwardItem)    -- 附件列表
end
function LuaCLS_SystemMailInfoSend:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteShort(self.TargetType)
    nbs:WriteInt(#self.ListTarget)
    for i = 1, #self.ListTarget do
        nbs:WriteString(self.ListTarget[i])
    end
    nbs:WriteString(self.Title)
    nbs:WriteString(self.Body)
    nbs:WriteString(self.SenderName)
    nbs:WriteInt(#self.ListAttachments)
    for i = 1, #self.ListAttachments do
        (self.ListAttachments[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_SystemMailInfoSend:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.TargetType = nbs:ReadShort()
    local var3086 = nbs:ReadInt()
    for i = 1, var3086 do
        local var3087 = nbs:ReadString()
        self.ListTarget:Add(var3087)
    end
    self.Title = nbs:ReadString()
    self.Body = nbs:ReadString()
    self.SenderName = nbs:ReadString()
    local var3091 = nbs:ReadInt()
    for i = 1, var3091 do
        local var3092 = LuaCLS_AwardItem.new()
        var3092:Unserialize(nbs)
        self.ListAttachments:Add(var3092)
    end
end
-- LuaCLS_SystemMailInfoSend end


-- LuaC2G_Mail_List begin
-- 请求 邮件列表
LuaC2G_Mail_List = Class(Base)
function LuaC2G_Mail_List:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_LIST"]
end
function LuaC2G_Mail_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_List end


-- LuaG2C_Mail_List begin
-- 返回 邮件列表
LuaG2C_Mail_List = Class(Base)
function LuaG2C_Mail_List:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_LIST"]
    self.ListMail = List:New(LuaCLS_MailInfo)    -- 邮件列表
end
function LuaG2C_Mail_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3093 = nbs:ReadInt()
    for i = 1, var3093 do
        local var3094 = LuaCLS_MailInfo.new()
        var3094:Unserialize(nbs)
        self.ListMail:Add(var3094)
    end
end
-- LuaG2C_Mail_List end


-- LuaC2G_Mail_Read begin
-- 请求 邮件读取
LuaC2G_Mail_Read = Class(Base)
function LuaC2G_Mail_Read:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_READ"]
    self.Id = 0    -- 邮件ID
end
function LuaC2G_Mail_Read:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_Read end


-- LuaG2C_Mail_Read begin
-- 返回 邮件读取
LuaG2C_Mail_Read = Class(Base)
function LuaG2C_Mail_Read:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_READ"]
    self.Id = 0    -- 邮件ID
    self.Details = LuaCLS_MailInfoDetails.new()    -- 邮件信息详细
end
function LuaG2C_Mail_Read:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
    self.Details:Unserialize(nbs)
end
-- LuaG2C_Mail_Read end


-- LuaC2G_Mail_Get begin
-- 请求 邮件领取附件
LuaC2G_Mail_Get = Class(Base)
function LuaC2G_Mail_Get:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_GET"]
    self.Id = 0    -- 邮件ID
end
function LuaC2G_Mail_Get:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_Get end


-- LuaG2C_Mail_Get begin
-- 返回 邮件领取附件
LuaG2C_Mail_Get = Class(Base)
function LuaG2C_Mail_Get:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_GET"]
    self.Id = 0    -- 邮件ID
    self.listAward = List:New(LuaCLS_AwardItem)    -- 附件列表
end
function LuaG2C_Mail_Get:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
    local var3098 = nbs:ReadInt()
    for i = 1, var3098 do
        local var3099 = LuaCLS_AwardItem.new()
        var3099:Unserialize(nbs)
        self.listAward:Add(var3099)
    end
end
-- LuaG2C_Mail_Get end


-- LuaC2G_Mail_GetAll begin
-- 请求 邮件一键领取
LuaC2G_Mail_GetAll = Class(Base)
function LuaC2G_Mail_GetAll:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_GETALL"]
end
function LuaC2G_Mail_GetAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_GetAll end


-- LuaG2C_Mail_GetAll begin
-- 返回 邮件一键领取
LuaG2C_Mail_GetAll = Class(Base)
function LuaG2C_Mail_GetAll:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_GETALL"]
    self.listAward = List:New(LuaCLS_AwardItem)    -- 附件列表
end
function LuaG2C_Mail_GetAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3100 = nbs:ReadInt()
    for i = 1, var3100 do
        local var3101 = LuaCLS_AwardItem.new()
        var3101:Unserialize(nbs)
        self.listAward:Add(var3101)
    end
end
-- LuaG2C_Mail_GetAll end


-- LuaC2G_Mail_Delete begin
-- 请求 邮件删除
LuaC2G_Mail_Delete = Class(Base)
function LuaC2G_Mail_Delete:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_DELETE"]
    self.Id = 0    -- 邮件ID
end
function LuaC2G_Mail_Delete:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_Delete end


-- LuaG2C_Mail_Delete begin
-- 返回 邮件删除
LuaG2C_Mail_Delete = Class(Base)
function LuaG2C_Mail_Delete:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_DELETE"]
    self.Id = 0    -- 邮件ID
end
function LuaG2C_Mail_Delete:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
end
-- LuaG2C_Mail_Delete end


-- LuaC2G_Mail_DeleteReaded begin
-- 请求 邮件清理已读
LuaC2G_Mail_DeleteReaded = Class(Base)
function LuaC2G_Mail_DeleteReaded:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_DELETEREADED"]
    self.MailType = 0    -- 要删除的当前页面类型
end
function LuaC2G_Mail_DeleteReaded:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteShort(self.MailType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_DeleteReaded end


-- LuaG2C_Mail_DeleteReaded begin
-- 返回 邮件清理已读
LuaG2C_Mail_DeleteReaded = Class(Base)
function LuaG2C_Mail_DeleteReaded:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_DELETEREADED"]
    self.ListMail = List:New(LuaCLS_MailInfo)    -- 刷新后邮件列表
end
function LuaG2C_Mail_DeleteReaded:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3103 = nbs:ReadInt()
    for i = 1, var3103 do
        local var3104 = LuaCLS_MailInfo.new()
        var3104:Unserialize(nbs)
        self.ListMail:Add(var3104)
    end
end
-- LuaG2C_Mail_DeleteReaded end


-- LuaC2G_Mail_Save begin
-- 请求 邮件保存/取消保存
LuaC2G_Mail_Save = Class(Base)
function LuaC2G_Mail_Save:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_SAVE"]
    self.Id = 0    -- 邮件ID
end
function LuaC2G_Mail_Save:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_Save end


-- LuaG2C_Mail_Save begin
-- 返回 邮件保存/取消保存
LuaG2C_Mail_Save = Class(Base)
function LuaG2C_Mail_Save:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_SAVE"]
    self.Id = 0    -- 邮件ID
end
function LuaG2C_Mail_Save:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
end
-- LuaG2C_Mail_Save end


-- LuaC2G_Mail_Send begin
-- 请求 邮件发送
LuaC2G_Mail_Send = Class(Base)
function LuaC2G_Mail_Send:ctor()
    self._protocol = LuaProtocolId["C2G_MAIL_SEND"]
    self.MailInfoSend = LuaCLS_MailInfoSend.new()    -- 邮件发送信息
end
function LuaC2G_Mail_Send:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    MailInfoSend:Serialize(nbs)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Mail_Send end


-- LuaG2C_Mail_Send begin
-- 返回 邮件发送
LuaG2C_Mail_Send = Class(Base)
function LuaG2C_Mail_Send:ctor()
    self._protocol = LuaProtocolId["G2C_MAIL_SEND"]
    self.MailInfo = LuaCLS_MailInfo.new()    -- 新加的已发邮件列表
end
function LuaG2C_Mail_Send:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.MailInfo:Unserialize(nbs)
end
-- LuaG2C_Mail_Send end


-- LuaCLS_ChatPlayerBase begin
-- 聊天玩家信息
LuaCLS_ChatPlayerBase = Class()
function LuaCLS_ChatPlayerBase:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.Name = ""    -- 名字
    self.HeadIndex = 0    -- 头像序号
end
function LuaCLS_ChatPlayerBase:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.HeadIndex)
    return nbs
end
function LuaCLS_ChatPlayerBase:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.HeadIndex = nbs:ReadInt()
end
-- LuaCLS_ChatPlayerBase end


-- LuaCLS_ChatMsg begin
-- 聊天信息
LuaCLS_ChatMsg = Class()
function LuaCLS_ChatMsg:ctor()
    self.Channel = 0    -- 聊天频道 见EChatChannel
    self.SenderInfo = LuaCLS_ChatPlayerBase.new()    -- 发送者信息
    self.Text = ""    -- 文本
end
function LuaCLS_ChatMsg:Serialize(nbs)
    nbs:WriteDateTime(self.ChatTime)
    nbs:WriteShort(self.Channel)
    SenderInfo:Serialize(nbs)
    nbs:WriteString(self.Text)
    return nbs
end
function LuaCLS_ChatMsg:Unserialize(nbs)
    self.ChatTime = nbs:ReadDateTime()
    self.Channel = nbs:ReadShort()
    self.SenderInfo:Unserialize(nbs)
    self.Text = nbs:ReadString()
end
-- LuaCLS_ChatMsg end


-- LuaCLS_ChatList begin
-- 私聊记录
LuaCLS_ChatList = Class()
function LuaCLS_ChatList:ctor()
    self.Info = LuaCLS_ChatPlayerBase.new()    -- 对方信息
    self.ListChatMsgs = List:New(LuaCLS_ChatMsg)
end
function LuaCLS_ChatList:Serialize(nbs)
    Info:Serialize(nbs)
    nbs:WriteInt(#self.ListChatMsgs)
    for i = 1, #self.ListChatMsgs do
        (self.ListChatMsgs[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_ChatList:Unserialize(nbs)
    self.Info:Unserialize(nbs)
    local var3115 = nbs:ReadInt()
    for i = 1, var3115 do
        local var3116 = LuaCLS_ChatMsg.new()
        var3116:Unserialize(nbs)
        self.ListChatMsgs:Add(var3116)
    end
end
-- LuaCLS_ChatList end


-- LuaC2G_Chat_Send begin
-- 请求 聊天信息发送
LuaC2G_Chat_Send = Class(Base)
function LuaC2G_Chat_Send:ctor()
    self._protocol = LuaProtocolId["C2G_CHAT_SEND"]
    self.Channel = 0    -- 聊天频道 见EChatChannel
    self.Text = ""    -- 文本
    self.Uid = 0    -- 对方唯一ID
end
function LuaC2G_Chat_Send:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteShort(self.Channel)
    nbs:WriteString(self.Text)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Chat_Send end


-- LuaG2C_Chat_Send begin
-- 返回 聊天信息发送
LuaG2C_Chat_Send = Class(Base)
function LuaG2C_Chat_Send:ctor()
    self._protocol = LuaProtocolId["G2C_CHAT_SEND"]
end
function LuaG2C_Chat_Send:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Chat_Send end


-- LuaG2C_Chat_Receive begin
-- 通知 聊天信息接收
LuaG2C_Chat_Receive = Class(Base)
function LuaG2C_Chat_Receive:ctor()
    self._protocol = LuaProtocolId["G2C_CHAT_RECEIVE"]
    self.ListChatMsgs = List:New(LuaCLS_ChatMsg)    -- 聊天信息列表
end
function LuaG2C_Chat_Receive:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3117 = nbs:ReadInt()
    for i = 1, var3117 do
        local var3118 = LuaCLS_ChatMsg.new()
        var3118:Unserialize(nbs)
        self.ListChatMsgs:Add(var3118)
    end
end
-- LuaG2C_Chat_Receive end


-- LuaC2G_Chat_GetPrivateChat begin
-- 请求 请求私聊数据
LuaC2G_Chat_GetPrivateChat = Class(Base)
function LuaC2G_Chat_GetPrivateChat:ctor()
    self._protocol = LuaProtocolId["C2G_CHAT_GETPRIVATECHAT"]
end
function LuaC2G_Chat_GetPrivateChat:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Chat_GetPrivateChat end


-- LuaG2C_Chat_GetPrivateChat begin
-- 返回 聊天信息发送
LuaG2C_Chat_GetPrivateChat = Class(Base)
function LuaG2C_Chat_GetPrivateChat:ctor()
    self._protocol = LuaProtocolId["G2C_CHAT_GETPRIVATECHAT"]
    self.DictChatInfo = Dictionary:New()
end
function LuaG2C_Chat_GetPrivateChat:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3119 = nbs:ReadInt()
    for i = 1, var3119 do
        local var3120 = nbs:ReadLong()
        local var3121 = LuaCLS_ChatList.new()
        var3121:Unserialize(nbs)
        self.DictChatInfo:Add(var3120, var3121)
    end
end
-- LuaG2C_Chat_GetPrivateChat end


-- LuaC2G_Chat_Remove begin
-- 请求 删除最近联系人
LuaC2G_Chat_Remove = Class(Base)
function LuaC2G_Chat_Remove:ctor()
    self._protocol = LuaProtocolId["C2G_CHAT_REMOVE"]
    self.Uid = 0
end
function LuaC2G_Chat_Remove:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Chat_Remove end


-- LuaG2C_Chat_Remove begin
-- 返回 删除最近联系人
LuaG2C_Chat_Remove = Class(Base)
function LuaG2C_Chat_Remove:ctor()
    self._protocol = LuaProtocolId["G2C_CHAT_REMOVE"]
    self.Uid = 0
end
function LuaG2C_Chat_Remove:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadLong()
end
-- LuaG2C_Chat_Remove end


-- LuaCLS_FriendInfo begin
-- 玩家单条信息
LuaCLS_FriendInfo = Class()
function LuaCLS_FriendInfo:ctor()
    self.Uid = 0    -- 玩家唯一ID
    self.HeadIndex = 0    -- 头像
    self.Name = ""    -- 名字
    self.Level = 0    -- 等级
    self.Signature = ""    -- 个人签名
    self.GiveState = 0    -- 体力状态：1-可领取 2-可赠送 3-已赠送
    self.bOnline = false    -- 是否在线
end
function LuaCLS_FriendInfo:Serialize(nbs)
    nbs:WriteLong(self.Uid)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.Level)
    nbs:WriteString(self.Signature)
    nbs:WriteInt(self.GiveState)
    nbs:WriteBool(self.bOnline)
    return nbs
end
function LuaCLS_FriendInfo:Unserialize(nbs)
    self.Uid = nbs:ReadLong()
    self.HeadIndex = nbs:ReadInt()
    self.Name = nbs:ReadString()
    self.Level = nbs:ReadInt()
    self.Signature = nbs:ReadString()
    self.GiveState = nbs:ReadInt()
    self.bOnline = nbs:ReadBool()
end
-- LuaCLS_FriendInfo end


-- LuaC2G_Friend_List begin
-- 请求 好友列表
LuaC2G_Friend_List = Class(Base)
function LuaC2G_Friend_List:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_LIST"]
end
function LuaC2G_Friend_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_List end


-- LuaG2C_Friend_List begin
-- 返回 好友列表
LuaG2C_Friend_List = Class(Base)
function LuaG2C_Friend_List:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_LIST"]
    self.ListItem = List:New(LuaCLS_FriendInfo)    -- 好友列表
end
function LuaG2C_Friend_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3130 = nbs:ReadInt()
    for i = 1, var3130 do
        local var3131 = LuaCLS_FriendInfo.new()
        var3131:Unserialize(nbs)
        self.ListItem:Add(var3131)
    end
end
-- LuaG2C_Friend_List end


-- LuaC2G_Friend_ListApply begin
-- 请求 申请列表
LuaC2G_Friend_ListApply = Class(Base)
function LuaC2G_Friend_ListApply:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_LISTAPPLY"]
end
function LuaC2G_Friend_ListApply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_ListApply end


-- LuaG2C_Friend_ListApply begin
-- 返回 申请列表
LuaG2C_Friend_ListApply = Class(Base)
function LuaG2C_Friend_ListApply:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_LISTAPPLY"]
    self.ListItem = List:New(LuaCLS_FriendInfo)    -- 申请列表
end
function LuaG2C_Friend_ListApply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3132 = nbs:ReadInt()
    for i = 1, var3132 do
        local var3133 = LuaCLS_FriendInfo.new()
        var3133:Unserialize(nbs)
        self.ListItem:Add(var3133)
    end
end
-- LuaG2C_Friend_ListApply end


-- LuaC2G_Friend_ListRecommend begin
-- 请求 推荐列表
LuaC2G_Friend_ListRecommend = Class(Base)
function LuaC2G_Friend_ListRecommend:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_LISTRECOMMEND"]
end
function LuaC2G_Friend_ListRecommend:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_ListRecommend end


-- LuaG2C_Friend_ListRecommend begin
-- 返回 推荐列表
LuaG2C_Friend_ListRecommend = Class(Base)
function LuaG2C_Friend_ListRecommend:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_LISTRECOMMEND"]
    self.ListItem = List:New(LuaCLS_FriendInfo)    -- 推荐列表
end
function LuaG2C_Friend_ListRecommend:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3134 = nbs:ReadInt()
    for i = 1, var3134 do
        local var3135 = LuaCLS_FriendInfo.new()
        var3135:Unserialize(nbs)
        self.ListItem:Add(var3135)
    end
end
-- LuaG2C_Friend_ListRecommend end


-- LuaC2G_Friend_Apply begin
-- 请求 申请好友
LuaC2G_Friend_Apply = Class(Base)
function LuaC2G_Friend_Apply:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_APPLY"]
    self.Uid = 0    -- 对象玩家唯一ID
end
function LuaC2G_Friend_Apply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Apply end


-- LuaG2C_Friend_Apply begin
-- 返回 申请好友
LuaG2C_Friend_Apply = Class(Base)
function LuaG2C_Friend_Apply:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_APPLY"]
    self.Uid = 0    -- 对象玩家唯一ID
    self.bFriend = false
end
function LuaG2C_Friend_Apply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadLong()
    self.bFriend = nbs:ReadBool()
end
-- LuaG2C_Friend_Apply end


-- LuaC2G_Friend_Add begin
-- 请求 添加好友
LuaC2G_Friend_Add = Class(Base)
function LuaC2G_Friend_Add:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_ADD"]
    self.bAgree = false    -- 是否同意
    self.bAll = false    -- 是否全部
    self.Uid = 0    -- 对象玩家唯一ID
end
function LuaC2G_Friend_Add:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteBool(self.bAgree)
    nbs:WriteBool(self.bAll)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Add end


-- LuaG2C_Friend_Add begin
-- 返回 添加好友
LuaG2C_Friend_Add = Class(Base)
function LuaG2C_Friend_Add:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_ADD"]
end
function LuaG2C_Friend_Add:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Friend_Add end


-- LuaC2G_Friend_Remove begin
-- 请求 请求删除
LuaC2G_Friend_Remove = Class(Base)
function LuaC2G_Friend_Remove:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_REMOVE"]
    self.Uid = 0    -- 对象玩家唯一ID
end
function LuaC2G_Friend_Remove:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Remove end


-- LuaG2C_Friend_Remove begin
-- 返回 请求删除
LuaG2C_Friend_Remove = Class(Base)
function LuaG2C_Friend_Remove:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_REMOVE"]
end
function LuaG2C_Friend_Remove:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Friend_Remove end


-- LuaC2G_Friend_Give begin
-- 请求 赠送体力
LuaC2G_Friend_Give = Class(Base)
function LuaC2G_Friend_Give:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_GIVE"]
    self.bAll = false    -- 全部赠送
    self.Uid = 0    -- 对象玩家唯一ID
end
function LuaC2G_Friend_Give:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteBool(self.bAll)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Give end


-- LuaG2C_Friend_Give begin
-- 返回 赠送体力
LuaG2C_Friend_Give = Class(Base)
function LuaG2C_Friend_Give:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_GIVE"]
    self.total = 0    -- 赠送体力
end
function LuaG2C_Friend_Give:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.total = nbs:ReadInt()
end
-- LuaG2C_Friend_Give end


-- LuaC2G_Friend_Receive begin
-- 请求 领取体力
LuaC2G_Friend_Receive = Class(Base)
function LuaC2G_Friend_Receive:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_RECEIVE"]
    self.bAll = false    -- 全部领取
    self.Uid = 0    -- 对象玩家唯一ID
end
function LuaC2G_Friend_Receive:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteBool(self.bAll)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Receive end


-- LuaG2C_Friend_Receive begin
-- 返回 领取体力
LuaG2C_Friend_Receive = Class(Base)
function LuaG2C_Friend_Receive:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_RECEIVE"]
    self.total = 0    -- 领取体力
end
function LuaG2C_Friend_Receive:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.total = nbs:ReadInt()
end
-- LuaG2C_Friend_Receive end


-- LuaC2G_Friend_Screen begin
-- 请求 屏蔽好友
LuaC2G_Friend_Screen = Class(Base)
function LuaC2G_Friend_Screen:ctor()
    self._protocol = LuaProtocolId["C2G_FRIEND_SCREEN"]
    self.Uid = 0    -- 对象玩家唯一ID
    self.bScreen = false    -- 是否屏蔽
end
function LuaC2G_Friend_Screen:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteBool(self.bScreen)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Friend_Screen end


-- LuaG2C_Friend_Screen begin
-- 返回 屏蔽好友
LuaG2C_Friend_Screen = Class(Base)
function LuaG2C_Friend_Screen:ctor()
    self._protocol = LuaProtocolId["G2C_FRIEND_SCREEN"]
    self.Uid = 0    -- 对象玩家唯一ID
    self.bScreen = false    -- 是否屏蔽
end
function LuaG2C_Friend_Screen:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadLong()
    self.bScreen = nbs:ReadBool()
end
-- LuaG2C_Friend_Screen end


-- LuaCLS_MapCitySimple begin
-- 城池信息简单
LuaCLS_MapCitySimple = Class()
function LuaCLS_MapCitySimple:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.Ownership = 0    -- 城池归属 EOwnership
end
function LuaCLS_MapCitySimple:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteByte(self.Ownership)
    return nbs
end
function LuaCLS_MapCitySimple:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.Ownership = nbs:ReadByte()
end
-- LuaCLS_MapCitySimple end


-- LuaC2G_Map_ListCity begin
-- 请求 城池列表
LuaC2G_Map_ListCity = Class(Base)
function LuaC2G_Map_ListCity:ctor()
    self._protocol = LuaProtocolId["C2G_MAP_LISTCITY"]
end
function LuaC2G_Map_ListCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Map_ListCity end


-- LuaG2C_Map_ListCity begin
-- 返回 城池列表
LuaG2C_Map_ListCity = Class(Base)
function LuaG2C_Map_ListCity:ctor()
    self._protocol = LuaProtocolId["G2C_MAP_LISTCITY"]
    self.ListCity = List:New(LuaCLS_MapCitySimple)    -- 城池列表
    self.ListAlliance = List:New(Lualong)    -- 同盟势力
    self.ListGuildCityMy = List:New(Luaint)    -- 我方城池
    self.ListGuildCityAlliance = List:New(Luaint)    -- 同盟城池
end
function LuaG2C_Map_ListCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3144 = nbs:ReadInt()
    for i = 1, var3144 do
        local var3145 = LuaCLS_MapCitySimple.new()
        var3145:Unserialize(nbs)
        self.ListCity:Add(var3145)
    end
    local var3146 = nbs:ReadInt()
    for i = 1, var3146 do
        local var3147 = nbs:ReadLong()
        self.ListAlliance:Add(var3147)
    end
    local var3148 = nbs:ReadInt()
    for i = 1, var3148 do
        local var3149 = nbs:ReadInt()
        self.ListGuildCityMy:Add(var3149)
    end
    local var3150 = nbs:ReadInt()
    for i = 1, var3150 do
        local var3151 = nbs:ReadInt()
        self.ListGuildCityAlliance:Add(var3151)
    end
end
-- LuaG2C_Map_ListCity end


-- LuaCLS_MapCityInfo begin
-- 城池信息
LuaCLS_MapCityInfo = Class()
function LuaCLS_MapCityInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.GuildName = ""    -- 占据势力名
    self.LeaderName = ""    -- 太守名
    self.Prosperity = 0    -- 繁荣度
end
function LuaCLS_MapCityInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteString(self.GuildName)
    nbs:WriteString(self.LeaderName)
    nbs:WriteLong(self.Prosperity)
    return nbs
end
function LuaCLS_MapCityInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.GuildName = nbs:ReadString()
    self.LeaderName = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
end
-- LuaCLS_MapCityInfo end


-- LuaC2G_Map_CityInfo begin
-- 请求 城池信息
LuaC2G_Map_CityInfo = Class(Base)
function LuaC2G_Map_CityInfo:ctor()
    self._protocol = LuaProtocolId["C2G_MAP_CITYINFO"]
    self.Uid = 0    -- 唯一ID(配置ID)
end
function LuaC2G_Map_CityInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Map_CityInfo end


-- LuaG2C_Map_CityInfo begin
-- 返回 城池信息
LuaG2C_Map_CityInfo = Class(Base)
function LuaG2C_Map_CityInfo:ctor()
    self._protocol = LuaProtocolId["G2C_MAP_CITYINFO"]
    self.CityInfo = LuaCLS_MapCityInfo.new()    -- 城池信息
end
function LuaG2C_Map_CityInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityInfo:Unserialize(nbs)
end
-- LuaG2C_Map_CityInfo end


-- LuaCLS_MapMyCityInfo begin
-- 我方城池信息
LuaCLS_MapMyCityInfo = Class()
function LuaCLS_MapMyCityInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.Prosperity = 0    -- 繁荣度
end
function LuaCLS_MapMyCityInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.Prosperity)
    return nbs
end
function LuaCLS_MapMyCityInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.Prosperity = nbs:ReadLong()
end
-- LuaCLS_MapMyCityInfo end


-- LuaC2G_Map_ListMyCity begin
-- 请求 我方城池列表
LuaC2G_Map_ListMyCity = Class(Base)
function LuaC2G_Map_ListMyCity:ctor()
    self._protocol = LuaProtocolId["C2G_MAP_LISTMYCITY"]
end
function LuaC2G_Map_ListMyCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Map_ListMyCity end


-- LuaG2C_Map_ListMyCity begin
-- 返回 我方城池列表
LuaG2C_Map_ListMyCity = Class(Base)
function LuaG2C_Map_ListMyCity:ctor()
    self._protocol = LuaProtocolId["G2C_MAP_LISTMYCITY"]
    self.ListMyCity = List:New(LuaCLS_MapMyCityInfo)    -- 我方城池列表
end
function LuaG2C_Map_ListMyCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3159 = nbs:ReadInt()
    for i = 1, var3159 do
        local var3160 = LuaCLS_MapMyCityInfo.new()
        var3160:Unserialize(nbs)
        self.ListMyCity:Add(var3160)
    end
end
-- LuaG2C_Map_ListMyCity end


-- LuaCLS_ItemInfo begin
-- 道具信息
LuaCLS_ItemInfo = Class()
function LuaCLS_ItemInfo:ctor()
    self.Id = 0    -- ID(配置ID)
    self.Count = 0    -- 数量
end
function LuaCLS_ItemInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    return nbs
end
function LuaCLS_ItemInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.Count = nbs:ReadInt()
end
-- LuaCLS_ItemInfo end


-- LuaC2G_Item_List begin
-- 请求 道具列表
LuaC2G_Item_List = Class(Base)
function LuaC2G_Item_List:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_LIST"]
end
function LuaC2G_Item_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_List end


-- LuaG2C_Item_List begin
-- 返回 道具列表
LuaG2C_Item_List = Class(Base)
function LuaG2C_Item_List:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_LIST"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Item_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3163 = nbs:ReadInt()
    for i = 1, var3163 do
        local var3164 = LuaCLS_ItemInfo.new()
        var3164:Unserialize(nbs)
        self.ListItem:Add(var3164)
    end
end
-- LuaG2C_Item_List end


-- LuaC2G_Item_Sell begin
-- 请求 道具卖店
LuaC2G_Item_Sell = Class(Base)
function LuaC2G_Item_Sell:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_SELL"]
    self.Id = 0    -- ID(配置ID)
    self.Count = 0    -- 数量
end
function LuaC2G_Item_Sell:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_Sell end


-- LuaG2C_Item_Sell begin
-- 返回 道具卖店
LuaG2C_Item_Sell = Class(Base)
function LuaG2C_Item_Sell:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_SELL"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Item_Sell:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3165 = nbs:ReadInt()
    for i = 1, var3165 do
        local var3166 = LuaCLS_ItemInfo.new()
        var3166:Unserialize(nbs)
        self.ListItem:Add(var3166)
    end
end
-- LuaG2C_Item_Sell end


-- LuaC2G_Item_Use begin
-- 请求 道具使用
LuaC2G_Item_Use = Class(Base)
function LuaC2G_Item_Use:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_USE"]
    self.Id = 0    -- ID(配置ID)
    self.Type = 0    -- 类型0:使用，1:合成
    self.Count = 0    -- 数量
end
function LuaC2G_Item_Use:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Type)
    nbs:WriteInt(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_Use end


-- LuaG2C_Item_Use begin
-- 返回 道具使用
LuaG2C_Item_Use = Class(Base)
function LuaG2C_Item_Use:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_USE"]
    self.Type = 0    -- 类型0:使用，1:合成
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Item_Use:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Type = nbs:ReadInt()
    local var3168 = nbs:ReadInt()
    for i = 1, var3168 do
        local var3169 = LuaCLS_ItemInfo.new()
        var3169:Unserialize(nbs)
        self.ListItem:Add(var3169)
    end
    local var3170 = nbs:ReadInt()
    for i = 1, var3170 do
        local var3171 = LuaCLS_AwardItem.new()
        var3171:Unserialize(nbs)
        self.ListAward:Add(var3171)
    end
end
-- LuaG2C_Item_Use end


-- LuaC2G_Item_ResourcesList begin
-- 请求 资源道具列表
LuaC2G_Item_ResourcesList = Class(Base)
function LuaC2G_Item_ResourcesList:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_RESOURCESLIST"]
    self.Type = 0    -- 道具类型 EUseEffect
end
function LuaC2G_Item_ResourcesList:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_ResourcesList end


-- LuaG2C_Item_ResourcesList begin
-- 返回 资源道具列表
LuaG2C_Item_ResourcesList = Class(Base)
function LuaG2C_Item_ResourcesList:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_RESOURCESLIST"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Item_ResourcesList:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3172 = nbs:ReadInt()
    for i = 1, var3172 do
        local var3173 = LuaCLS_ItemInfo.new()
        var3173:Unserialize(nbs)
        self.ListItem:Add(var3173)
    end
end
-- LuaG2C_Item_ResourcesList end


-- LuaC2G_Item_ResourcesUse begin
-- 请求 资源道具使用
LuaC2G_Item_ResourcesUse = Class(Base)
function LuaC2G_Item_ResourcesUse:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_RESOURCESUSE"]
    self.Items = List:New(LuaCLS_ItemInfo)    -- 道具
    self.Type = 0    -- 道具类型 EUseEffect
end
function LuaC2G_Item_ResourcesUse:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.Items)
    for i = 1, #self.Items do
        (self.Items[i]):Serialize(nbs)
    end
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_ResourcesUse end


-- LuaG2C_Item_ResourcesUse begin
-- 返回 资源道具使用
LuaG2C_Item_ResourcesUse = Class(Base)
function LuaG2C_Item_ResourcesUse:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_RESOURCESUSE"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Item_ResourcesUse:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3174 = nbs:ReadInt()
    for i = 1, var3174 do
        local var3175 = LuaCLS_ItemInfo.new()
        var3175:Unserialize(nbs)
        self.ListItem:Add(var3175)
    end
    local var3176 = nbs:ReadInt()
    for i = 1, var3176 do
        local var3177 = LuaCLS_AwardItem.new()
        var3177:Unserialize(nbs)
        self.ListAward:Add(var3177)
    end
end
-- LuaG2C_Item_ResourcesUse end


-- LuaC2G_Item_ResourcesBuy begin
-- 请求 资源道具购买
LuaC2G_Item_ResourcesBuy = Class(Base)
function LuaC2G_Item_ResourcesBuy:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_RESOURCESBUY"]
    self.ID = 0    -- 道具ID ShopSpeedUp表里的ID
    self.Amount = 0    -- 数量
    self.Type = 0    -- 道具类型 EUseEffect
end
function LuaC2G_Item_ResourcesBuy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.ID)
    nbs:WriteInt(self.Amount)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_ResourcesBuy end


-- LuaG2C_Item_ResourcesBuy begin
-- 返回 资源道具购买
LuaG2C_Item_ResourcesBuy = Class(Base)
function LuaG2C_Item_ResourcesBuy:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_RESOURCESBUY"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Item_ResourcesBuy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3178 = nbs:ReadInt()
    for i = 1, var3178 do
        local var3179 = LuaCLS_ItemInfo.new()
        var3179:Unserialize(nbs)
        self.ListItem:Add(var3179)
    end
    local var3180 = nbs:ReadInt()
    for i = 1, var3180 do
        local var3181 = LuaCLS_AwardItem.new()
        var3181:Unserialize(nbs)
        self.ListAward:Add(var3181)
    end
end
-- LuaG2C_Item_ResourcesBuy end


-- LuaC2G_Item_CombatUse begin
-- 请求 战斗使用道具
LuaC2G_Item_CombatUse = Class(Base)
function LuaC2G_Item_CombatUse:ctor()
    self._protocol = LuaProtocolId["C2G_ITEM_COMBATUSE"]
    self.Id = 0    -- ID(配置ID)
    self.Count = 0    -- 数量
    self.CombatType = 0    -- 转发战斗效果
end
function LuaC2G_Item_CombatUse:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    nbs:WriteInt(self.CombatType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Item_CombatUse end


-- LuaG2C_Item_CombatUse begin
-- 返回 战斗使用道具
LuaG2C_Item_CombatUse = Class(Base)
function LuaG2C_Item_CombatUse:ctor()
    self._protocol = LuaProtocolId["G2C_ITEM_COMBATUSE"]
    self.Id = 0    -- ID(配置ID)
    self.Count = 0    -- 数量
    self.CombatType = 0    -- 转发战斗效果
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表
end
function LuaG2C_Item_CombatUse:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    self.Count = nbs:ReadInt()
    self.CombatType = nbs:ReadInt()
    local var3185 = nbs:ReadInt()
    for i = 1, var3185 do
        local var3186 = LuaCLS_ItemInfo.new()
        var3186:Unserialize(nbs)
        self.ListItem:Add(var3186)
    end
end
-- LuaG2C_Item_CombatUse end


-- LuaCLS_EquipSuffix begin
-- 装备高级属性
LuaCLS_EquipSuffix = Class()
function LuaCLS_EquipSuffix:ctor()
    self.ConfigId = 0    -- 配置ID
    self.PassiveType = 0    -- 属性类型 见EPassiveType
    self.SuffixValue = 0    -- 属性制
end
function LuaCLS_EquipSuffix:Serialize(nbs)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteInt(self.PassiveType)
    nbs:WriteFloat(self.SuffixValue)
    return nbs
end
function LuaCLS_EquipSuffix:Unserialize(nbs)
    self.ConfigId = nbs:ReadInt()
    self.PassiveType = nbs:ReadInt()
    self.SuffixValue = nbs:ReadFloat()
end
-- LuaCLS_EquipSuffix end


-- LuaCLS_EquipInfo begin
-- 装备信息
LuaCLS_EquipInfo = Class()
function LuaCLS_EquipInfo:ctor()
    self.Id = 0    -- 装备唯一ID
    self.ConfigId = 0    -- 配置ID
    self.EquipType = 0    -- 装备类型 见EEquipType
    self.Intensify = 0    -- 强化等级
    self.CombatProperty = Dictionary:New()    -- 战斗属性
    self.MarkName = ""    -- 自定义名称
    self.SuffixProperty = List:New(LuaCLS_EquipSuffix)
end
function LuaCLS_EquipInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteInt(self.EquipType)
    nbs:WriteInt(self.Intensify)
    nbs:WriteInt(#self.CombatProperty)
    for key, value in pairs(self.CombatProperty) do
        nbs:WriteInt(key)
        nbs:WriteFloat(value)
    end
    nbs:WriteString(self.MarkName)
    nbs:WriteInt(#self.SuffixProperty)
    for i = 1, #self.SuffixProperty do
        (self.SuffixProperty[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_EquipInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.ConfigId = nbs:ReadInt()
    self.EquipType = nbs:ReadInt()
    self.Intensify = nbs:ReadInt()
    local var3194 = nbs:ReadInt()
    for i = 1, var3194 do
        local var3195 = nbs:ReadInt()
        local var3196 = nbs:ReadFloat()
        self.CombatProperty:Add(var3195, var3196)
    end
    self.MarkName = nbs:ReadString()
    local var3198 = nbs:ReadInt()
    for i = 1, var3198 do
        local var3199 = LuaCLS_EquipSuffix.new()
        var3199:Unserialize(nbs)
        self.SuffixProperty:Add(var3199)
    end
end
-- LuaCLS_EquipInfo end


-- LuaC2G_Equip_List begin
-- 请求 装备列表
LuaC2G_Equip_List = Class(Base)
function LuaC2G_Equip_List:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_LIST"]
end
function LuaC2G_Equip_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_List end


-- LuaG2C_Equip_List begin
-- 返回 装备列表
LuaG2C_Equip_List = Class(Base)
function LuaG2C_Equip_List:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_LIST"]
    self.PageIndex = 0    -- 页码1-n (返回每页100条) (0=结束)
    self.DictEquip = Dictionary:New()    -- 装备列表
end
function LuaG2C_Equip_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PageIndex = nbs:ReadInt()
    local var3201 = nbs:ReadInt()
    for i = 1, var3201 do
        local var3202 = nbs:ReadLong()
        local var3203 = LuaCLS_EquipInfo.new()
        var3203:Unserialize(nbs)
        self.DictEquip:Add(var3202, var3203)
    end
end
-- LuaG2C_Equip_List end


-- LuaC2G_Equip_WarriorList begin
-- 请求 武将装备列表
LuaC2G_Equip_WarriorList = Class(Base)
function LuaC2G_Equip_WarriorList:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_WARRIORLIST"]
    self.Id = 0    -- 武将唯一ID
end
function LuaC2G_Equip_WarriorList:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_WarriorList end


-- LuaG2C_Equip_WarriorList begin
-- 返回 武将装备列表
LuaG2C_Equip_WarriorList = Class(Base)
function LuaG2C_Equip_WarriorList:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_WARRIORLIST"]
    self.DictEquiped = Dictionary:New()    -- 武将已装备列表<装备位置, 信息>
    self.DictEquip = Dictionary:New()    -- 武将装备列表
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将现信息
end
function LuaG2C_Equip_WarriorList:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3204 = nbs:ReadInt()
    for i = 1, var3204 do
        local var3205 = nbs:ReadInt()
        local var3206 = LuaCLS_EquipInfo.new()
        var3206:Unserialize(nbs)
        self.DictEquiped:Add(var3205, var3206)
    end
    local var3207 = nbs:ReadInt()
    for i = 1, var3207 do
        local var3208 = nbs:ReadLong()
        local var3209 = LuaCLS_EquipInfo.new()
        var3209:Unserialize(nbs)
        self.DictEquip:Add(var3208, var3209)
    end
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Equip_WarriorList end


-- LuaC2G_Equip_WarriorAll begin
-- 请求 所有武将装备列表
LuaC2G_Equip_WarriorAll = Class(Base)
function LuaC2G_Equip_WarriorAll:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_WARRIORALL"]
end
function LuaC2G_Equip_WarriorAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_WarriorAll end


-- LuaG2C_Equip_WarriorAll begin
-- 返回 所有武将装备列表
LuaG2C_Equip_WarriorAll = Class(Base)
function LuaG2C_Equip_WarriorAll:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_WARRIORALL"]
    self.DictEquip = Dictionary:New()    -- 武将装备列表
end
function LuaG2C_Equip_WarriorAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3211 = nbs:ReadInt()
    for i = 1, var3211 do
        local var3212 = nbs:ReadLong()
        local var3213 = LuaCLS_EquipInfo.new()
        var3213:Unserialize(nbs)
        self.DictEquip:Add(var3212, var3213)
    end
end
-- LuaG2C_Equip_WarriorAll end


-- LuaC2G_Equip_WarriorWield begin
-- 请求 武将装备运用
LuaC2G_Equip_WarriorWield = Class(Base)
function LuaC2G_Equip_WarriorWield:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_WARRIORWIELD"]
    self.WarriorId = 0    -- 武将唯一ID
    self.Id = 0    -- 装备唯一ID
end
function LuaC2G_Equip_WarriorWield:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.WarriorId)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_WarriorWield end


-- LuaG2C_Equip_WarriorWield begin
-- 返回 武将装备运用
LuaG2C_Equip_WarriorWield = Class(Base)
function LuaG2C_Equip_WarriorWield:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_WARRIORWIELD"]
    self.DictEquiped = Dictionary:New()    -- 武将已装备列表<装备位置, 信息>
    self.DictEquip = Dictionary:New()    -- 武将装备列表
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将现信息
end
function LuaG2C_Equip_WarriorWield:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3214 = nbs:ReadInt()
    for i = 1, var3214 do
        local var3215 = nbs:ReadInt()
        local var3216 = LuaCLS_EquipInfo.new()
        var3216:Unserialize(nbs)
        self.DictEquiped:Add(var3215, var3216)
    end
    local var3217 = nbs:ReadInt()
    for i = 1, var3217 do
        local var3218 = nbs:ReadLong()
        local var3219 = LuaCLS_EquipInfo.new()
        var3219:Unserialize(nbs)
        self.DictEquip:Add(var3218, var3219)
    end
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Equip_WarriorWield end


-- LuaC2G_Equip_WarriorRemove begin
-- 请求 武将装备卸下
LuaC2G_Equip_WarriorRemove = Class(Base)
function LuaC2G_Equip_WarriorRemove:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_WARRIORREMOVE"]
    self.WarriorId = 0    -- 武将唯一ID
    self.EquipType = 0    -- 装备位置(装备类型)
end
function LuaC2G_Equip_WarriorRemove:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.WarriorId)
    nbs:WriteInt(self.EquipType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_WarriorRemove end


-- LuaG2C_Equip_WarriorRemove begin
-- 返回 武将装备卸下
LuaG2C_Equip_WarriorRemove = Class(Base)
function LuaG2C_Equip_WarriorRemove:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_WARRIORREMOVE"]
    self.DictEquiped = Dictionary:New()    -- 武将已装备列表<装备位置, 信息>
    self.DictEquip = Dictionary:New()    -- 武将装备列表
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将现信息
end
function LuaG2C_Equip_WarriorRemove:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3221 = nbs:ReadInt()
    for i = 1, var3221 do
        local var3222 = nbs:ReadInt()
        local var3223 = LuaCLS_EquipInfo.new()
        var3223:Unserialize(nbs)
        self.DictEquiped:Add(var3222, var3223)
    end
    local var3224 = nbs:ReadInt()
    for i = 1, var3224 do
        local var3225 = nbs:ReadLong()
        local var3226 = LuaCLS_EquipInfo.new()
        var3226:Unserialize(nbs)
        self.DictEquip:Add(var3225, var3226)
    end
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Equip_WarriorRemove end


-- LuaC2G_Equip_WarriorResolve begin
-- 请求 武将装备分解
LuaC2G_Equip_WarriorResolve = Class(Base)
function LuaC2G_Equip_WarriorResolve:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_WARRIORRESOLVE"]
    self.Id = List:New(Lualong)    -- 分解装备列表唯一ID
end
function LuaC2G_Equip_WarriorResolve:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.Id)
    for i = 1, #self.Id do
        nbs:WriteLong(self.Id[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_WarriorResolve end


-- LuaG2C_Equip_WarriorResolve begin
-- 返回 武将装备分解
LuaG2C_Equip_WarriorResolve = Class(Base)
function LuaG2C_Equip_WarriorResolve:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_WARRIORRESOLVE"]
    self.ListAward = List:New(LuaCLS_AwardItem)
end
function LuaG2C_Equip_WarriorResolve:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3228 = nbs:ReadInt()
    for i = 1, var3228 do
        local var3229 = LuaCLS_AwardItem.new()
        var3229:Unserialize(nbs)
        self.ListAward:Add(var3229)
    end
end
-- LuaG2C_Equip_WarriorResolve end


-- LuaC2G_Equip_Rename begin
-- 请求 装备修改名称
LuaC2G_Equip_Rename = Class(Base)
function LuaC2G_Equip_Rename:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_RENAME"]
    self.MarkName = ""    -- 装备自定义名称
end
function LuaC2G_Equip_Rename:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.MarkName)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_Rename end


-- LuaG2C_Equip_Rename begin
-- 返回 装备修改名称
LuaG2C_Equip_Rename = Class(Base)
function LuaG2C_Equip_Rename:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_RENAME"]
end
function LuaG2C_Equip_Rename:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Equip_Rename end


-- LuaC2G_Equip_IntensifyInfo begin
-- 请求 装备强化信息
LuaC2G_Equip_IntensifyInfo = Class(Base)
function LuaC2G_Equip_IntensifyInfo:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_INTENSIFYINFO"]
    self.EquipID = 0    -- 装备ID
end
function LuaC2G_Equip_IntensifyInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.EquipID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_IntensifyInfo end


-- LuaG2C_Equip_IntensifyInfo begin
-- 返回 装备强化信息
LuaG2C_Equip_IntensifyInfo = Class(Base)
function LuaG2C_Equip_IntensifyInfo:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_INTENSIFYINFO"]
    self.IntensityInfo = LuaCLS_EquipIntensifyInfo.new()    -- 强化信息
end
function LuaG2C_Equip_IntensifyInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.IntensityInfo:Unserialize(nbs)
end
-- LuaG2C_Equip_IntensifyInfo end


-- LuaC2G_Equip_Intensify begin
-- 请求 装备强化
LuaC2G_Equip_Intensify = Class(Base)
function LuaC2G_Equip_Intensify:ctor()
    self._protocol = LuaProtocolId["C2G_EQUIP_INTENSIFY"]
    self.EquipID = 0    -- 装备ID
end
function LuaC2G_Equip_Intensify:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.EquipID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Equip_Intensify end


-- LuaG2C_Equip_Intensify begin
-- 返回 装备强化
LuaG2C_Equip_Intensify = Class(Base)
function LuaG2C_Equip_Intensify:ctor()
    self._protocol = LuaProtocolId["G2C_EQUIP_INTENSIFY"]
    self.IntensityInfo = LuaCLS_EquipIntensifyInfo.new()    -- 强化信息
    self.IntensifyResult = 0    -- 结果 对应EIntensifyResult
    self.AwardItem = List:New(LuaCLS_AwardItem)    -- 产物
end
function LuaG2C_Equip_Intensify:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.IntensityInfo:Unserialize(nbs)
    self.IntensifyResult = nbs:ReadInt()
    local var3233 = nbs:ReadInt()
    for i = 1, var3233 do
        local var3234 = LuaCLS_AwardItem.new()
        var3234:Unserialize(nbs)
        self.AwardItem:Add(var3234)
    end
end
-- LuaG2C_Equip_Intensify end


-- LuaCLS_EquipIntensifyInfo begin
-- 装备强化信息
LuaCLS_EquipIntensifyInfo = Class()
function LuaCLS_EquipIntensifyInfo:ctor()
    self.IntensityId = 0    -- 强化等级
    self.Atk = 0    -- 攻击
    self.Def = 0    -- 防御
    self.Hp = 0    -- 兵力
    self.Inte = 0    -- 谋略
    self.IntensityAtk = 0    -- 强化后攻击
    self.IntensityDef = 0    -- 强化后防御
    self.IntensityInte = 0    -- 强化后谋略
    self.IntensityHp = 0    -- 强化后兵力
    self.Gold = 0    -- 银两消耗
    self.ListItemNeedInfo = List:New(LuaCLS_ItemNeedInfo)    -- 需求道具列表
end
function LuaCLS_EquipIntensifyInfo:Serialize(nbs)
    nbs:WriteInt(self.IntensityId)
    nbs:WriteFloat(self.Atk)
    nbs:WriteFloat(self.Def)
    nbs:WriteInt(self.Hp)
    nbs:WriteFloat(self.Inte)
    nbs:WriteFloat(self.IntensityAtk)
    nbs:WriteFloat(self.IntensityDef)
    nbs:WriteFloat(self.IntensityInte)
    nbs:WriteInt(self.IntensityHp)
    nbs:WriteInt(self.Gold)
    nbs:WriteInt(#self.ListItemNeedInfo)
    for i = 1, #self.ListItemNeedInfo do
        (self.ListItemNeedInfo[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_EquipIntensifyInfo:Unserialize(nbs)
    self.IntensityId = nbs:ReadInt()
    self.Atk = nbs:ReadFloat()
    self.Def = nbs:ReadFloat()
    self.Hp = nbs:ReadInt()
    self.Inte = nbs:ReadFloat()
    self.IntensityAtk = nbs:ReadFloat()
    self.IntensityDef = nbs:ReadFloat()
    self.IntensityInte = nbs:ReadFloat()
    self.IntensityHp = nbs:ReadInt()
    self.Gold = nbs:ReadInt()
    local var3245 = nbs:ReadInt()
    for i = 1, var3245 do
        local var3246 = LuaCLS_ItemNeedInfo.new()
        var3246:Unserialize(nbs)
        self.ListItemNeedInfo:Add(var3246)
    end
end
-- LuaCLS_EquipIntensifyInfo end


-- LuaCLS_SkillInfo begin
-- 技能信息
LuaCLS_SkillInfo = Class()
function LuaCLS_SkillInfo:ctor()
    self.SkillId = 0    -- 技能ID(配置ID SkillId)
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验值
end
function LuaCLS_SkillInfo:Serialize(nbs)
    nbs:WriteInt(self.SkillId)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.Exp)
    return nbs
end
function LuaCLS_SkillInfo:Unserialize(nbs)
    self.SkillId = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
end
-- LuaCLS_SkillInfo end


-- LuaCLS_WarriorCollect begin
-- 组合信息
LuaCLS_WarriorCollect = Class()
function LuaCLS_WarriorCollect:ctor()
    self.CollectId = 0    -- 组合ID(配置ID)
    self.Valid = false    -- 是否生效
    self.DictHas = Dictionary:New()    -- 已有武将配置ID<武将ID 是否有>
end
function LuaCLS_WarriorCollect:Serialize(nbs)
    nbs:WriteInt(self.CollectId)
    nbs:WriteBool(self.Valid)
    nbs:WriteInt(#self.DictHas)
    for key, value in pairs(self.DictHas) do
        nbs:WriteInt(key)
        nbs:WriteBool(value)
    end
    return nbs
end
function LuaCLS_WarriorCollect:Unserialize(nbs)
    self.CollectId = nbs:ReadInt()
    self.Valid = nbs:ReadBool()
    local var3252 = nbs:ReadInt()
    for i = 1, var3252 do
        local var3253 = nbs:ReadInt()
        local var3254 = nbs:ReadBool()
        self.DictHas:Add(var3253, var3254)
    end
end
-- LuaCLS_WarriorCollect end


-- LuaCLS_WarriorInfo begin
-- 武将信息
LuaCLS_WarriorInfo = Class()
function LuaCLS_WarriorInfo:ctor()
    self.Id = 0    -- 唯一ID
    self.ConfigId = 0    -- 配置ID
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验
    self.MarkName = ""    -- 武将自定义名称
    self.Lock = false    -- 锁定
    self.InRecruit = false    -- 募兵
    self.InBattle = false    -- 上阵
    self.Captive = false    -- 被俘虏
    self.Employed = false    -- 被雇佣
    self.InArmy = false    -- 出征PVP
    self.InAffairs = false    -- 军务中
    self.InGrab = false    -- 矿点占领
    self.ListSkill = List:New(LuaCLS_SkillInfo)    -- 武将技能列表
    self.AdvanceLv = 0    -- 进阶等级
    self.BaseAtk = 0    -- 固定攻击
    self.BaseDef = 0    -- 固定防御
    self.BaseHp = 0    -- 固定生命
    self.BaseInte = 0    -- 固定谋略
    self.BaseBreak = 0    -- 固定攻城
    self.CombatProperty = Dictionary:New()    -- 战斗属性
    self.CurrentHp = 0    -- 当前兵力
    self.CombatPower = 0    -- 战斗力
    self.DictEquiped = Dictionary:New()    -- 武将已装备列表<装备位置, 信息>
    self.Satr = 0    -- 星级
    self.WakeLevel = 0    -- 觉醒等级
    self.DictWake = Dictionary:New()    -- 武将觉醒列表<觉醒位置, 等级>
    self.DictStremgthen = Dictionary:New()    -- 武将强化列表<强化id, 值>
    self.DictWarriorCollect = Dictionary:New()    -- 武将组合列表<组合id, 组合内容>
end
function LuaCLS_WarriorInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.Exp)
    nbs:WriteString(self.MarkName)
    nbs:WriteBool(self.Lock)
    nbs:WriteBool(self.InRecruit)
    nbs:WriteBool(self.InBattle)
    nbs:WriteBool(self.Captive)
    nbs:WriteBool(self.Employed)
    nbs:WriteBool(self.InArmy)
    nbs:WriteBool(self.InAffairs)
    nbs:WriteBool(self.InGrab)
    nbs:WriteInt(#self.ListSkill)
    for i = 1, #self.ListSkill do
        (self.ListSkill[i]):Serialize(nbs)
    end
    nbs:WriteInt(self.AdvanceLv)
    nbs:WriteFloat(self.BaseAtk)
    nbs:WriteFloat(self.BaseDef)
    nbs:WriteInt(self.BaseHp)
    nbs:WriteFloat(self.BaseInte)
    nbs:WriteFloat(self.BaseBreak)
    nbs:WriteInt(#self.CombatProperty)
    for key, value in pairs(self.CombatProperty) do
        nbs:WriteInt(key)
        nbs:WriteFloat(value)
    end
    nbs:WriteInt(self.CurrentHp)
    nbs:WriteInt(self.CombatPower)
    nbs:WriteInt(#self.DictEquiped)
    for key, value in pairs(self.DictEquiped) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    nbs:WriteInt(self.Satr)
    nbs:WriteInt(self.WakeLevel)
    nbs:WriteInt(#self.DictWake)
    for key, value in pairs(self.DictWake) do
        nbs:WriteInt(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(#self.DictStremgthen)
    for key, value in pairs(self.DictStremgthen) do
        nbs:WriteInt(key)
        nbs:WriteFloat(value)
    end
    nbs:WriteInt(#self.DictWarriorCollect)
    for key, value in pairs(self.DictWarriorCollect) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_WarriorInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.ConfigId = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
    self.MarkName = nbs:ReadString()
    self.Lock = nbs:ReadBool()
    self.InRecruit = nbs:ReadBool()
    self.InBattle = nbs:ReadBool()
    self.Captive = nbs:ReadBool()
    self.Employed = nbs:ReadBool()
    self.InArmy = nbs:ReadBool()
    self.InAffairs = nbs:ReadBool()
    self.InGrab = nbs:ReadBool()
    local var3268 = nbs:ReadInt()
    for i = 1, var3268 do
        local var3269 = LuaCLS_SkillInfo.new()
        var3269:Unserialize(nbs)
        self.ListSkill:Add(var3269)
    end
    self.AdvanceLv = nbs:ReadInt()
    self.BaseAtk = nbs:ReadFloat()
    self.BaseDef = nbs:ReadFloat()
    self.BaseHp = nbs:ReadInt()
    self.BaseInte = nbs:ReadFloat()
    self.BaseBreak = nbs:ReadFloat()
    local var3276 = nbs:ReadInt()
    for i = 1, var3276 do
        local var3277 = nbs:ReadInt()
        local var3278 = nbs:ReadFloat()
        self.CombatProperty:Add(var3277, var3278)
    end
    self.CurrentHp = nbs:ReadInt()
    self.CombatPower = nbs:ReadInt()
    local var3281 = nbs:ReadInt()
    for i = 1, var3281 do
        local var3282 = nbs:ReadInt()
        local var3283 = LuaCLS_EquipInfo.new()
        var3283:Unserialize(nbs)
        self.DictEquiped:Add(var3282, var3283)
    end
    self.Satr = nbs:ReadInt()
    self.WakeLevel = nbs:ReadInt()
    local var3286 = nbs:ReadInt()
    for i = 1, var3286 do
        local var3287 = nbs:ReadInt()
        local var3288 = nbs:ReadInt()
        self.DictWake:Add(var3287, var3288)
    end
    local var3289 = nbs:ReadInt()
    for i = 1, var3289 do
        local var3290 = nbs:ReadInt()
        local var3291 = nbs:ReadFloat()
        self.DictStremgthen:Add(var3290, var3291)
    end
    local var3292 = nbs:ReadInt()
    for i = 1, var3292 do
        local var3293 = nbs:ReadInt()
        local var3294 = LuaCLS_WarriorCollect.new()
        var3294:Unserialize(nbs)
        self.DictWarriorCollect:Add(var3293, var3294)
    end
end
-- LuaCLS_WarriorInfo end


-- LuaC2G_Warrior_WarriorList begin
-- 请求 武将列表
LuaC2G_Warrior_WarriorList = Class(Base)
function LuaC2G_Warrior_WarriorList:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_WARRIORLIST"]
end
function LuaC2G_Warrior_WarriorList:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_WarriorList end


-- LuaG2C_Warrior_WarriorList begin
-- 返回 武将列表
LuaG2C_Warrior_WarriorList = Class(Base)
function LuaG2C_Warrior_WarriorList:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_WARRIORLIST"]
    self.ListWarrior = List:New(LuaCLS_WarriorInfo)    -- 武将列表
    self.ListInBattle = List:New(Lualong)    -- 上阵列表
end
function LuaG2C_Warrior_WarriorList:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3295 = nbs:ReadInt()
    for i = 1, var3295 do
        local var3296 = LuaCLS_WarriorInfo.new()
        var3296:Unserialize(nbs)
        self.ListWarrior:Add(var3296)
    end
    local var3297 = nbs:ReadInt()
    for i = 1, var3297 do
        local var3298 = nbs:ReadLong()
        self.ListInBattle:Add(var3298)
    end
end
-- LuaG2C_Warrior_WarriorList end


-- LuaC2G_Warrior_Lock begin
-- 请求 武将锁定/解锁
LuaC2G_Warrior_Lock = Class(Base)
function LuaC2G_Warrior_Lock:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_LOCK"]
    self.Id = 0    -- 唯一ID
end
function LuaC2G_Warrior_Lock:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Lock end


-- LuaG2C_Warrior_Lock begin
-- 返回 武将锁定/解锁
LuaG2C_Warrior_Lock = Class(Base)
function LuaG2C_Warrior_Lock:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_LOCK"]
    self.Id = 0    -- 唯一ID
end
function LuaG2C_Warrior_Lock:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
end
-- LuaG2C_Warrior_Lock end


-- LuaC2G_Warrior_Advance begin
-- 请求 武将进阶
LuaC2G_Warrior_Advance = Class(Base)
function LuaC2G_Warrior_Advance:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_ADVANCE"]
    self.Id = 0    -- 唯一ID
    self.MateriaWarriorID = List:New(Lualong)    -- 材料武将ID
end
function LuaC2G_Warrior_Advance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(#self.MateriaWarriorID)
    for i = 1, #self.MateriaWarriorID do
        nbs:WriteLong(self.MateriaWarriorID[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Advance end


-- LuaG2C_Warrior_Advance begin
-- 返回 武将进阶
LuaG2C_Warrior_Advance = Class(Base)
function LuaG2C_Warrior_Advance:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_ADVANCE"]
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将信息
end
function LuaG2C_Warrior_Advance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Warrior_Advance end


-- LuaC2G_Warrior_Rename begin
-- 请求 武将修改昵称
LuaC2G_Warrior_Rename = Class(Base)
function LuaC2G_Warrior_Rename:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_RENAME"]
    self.Id = 0    -- 唯一ID
    self.MarkName = ""    -- 武将自定义名称
end
function LuaC2G_Warrior_Rename:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteString(self.MarkName)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Rename end


-- LuaG2C_Warrior_Rename begin
-- 返回 武将修改昵称
LuaG2C_Warrior_Rename = Class(Base)
function LuaG2C_Warrior_Rename:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_RENAME"]
end
function LuaG2C_Warrior_Rename:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_Rename end


-- LuaC2G_Warrior_UpLevel begin
-- 请求 武将升级
LuaC2G_Warrior_UpLevel = Class(Base)
function LuaC2G_Warrior_UpLevel:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_UPLEVEL"]
    self.Id = 0    -- 唯一ID
    self.ListWarrior = List:New(Lualong)    -- 使用武将信息
end
function LuaC2G_Warrior_UpLevel:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(#self.ListWarrior)
    for i = 1, #self.ListWarrior do
        nbs:WriteLong(self.ListWarrior[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_UpLevel end


-- LuaG2C_Warrior_UpLevel begin
-- 返回 武将升级
LuaG2C_Warrior_UpLevel = Class(Base)
function LuaG2C_Warrior_UpLevel:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_UPLEVEL"]
    self.Id = 0    -- 唯一ID
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验
end
function LuaG2C_Warrior_UpLevel:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadLong()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
end
-- LuaG2C_Warrior_UpLevel end


-- LuaG2C_Warrior_NotifyLevelUp begin
-- 通知 武将升级
LuaG2C_Warrior_NotifyLevelUp = Class(Base)
function LuaG2C_Warrior_NotifyLevelUp:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_NOTIFYLEVELUP"]
end
function LuaG2C_Warrior_NotifyLevelUp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_NotifyLevelUp end


-- LuaC2G_Warrior_ImproveInfo begin
-- 请求 武将培养信息
LuaC2G_Warrior_ImproveInfo = Class(Base)
function LuaC2G_Warrior_ImproveInfo:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_IMPROVEINFO"]
end
function LuaC2G_Warrior_ImproveInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_ImproveInfo end


-- LuaG2C_Warrior_ImproveInfo begin
-- 返回 武将培养信息
LuaG2C_Warrior_ImproveInfo = Class(Base)
function LuaG2C_Warrior_ImproveInfo:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_IMPROVEINFO"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表(武将培养类)
end
function LuaG2C_Warrior_ImproveInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3304 = nbs:ReadInt()
    for i = 1, var3304 do
        local var3305 = LuaCLS_ItemInfo.new()
        var3305:Unserialize(nbs)
        self.ListItem:Add(var3305)
    end
end
-- LuaG2C_Warrior_ImproveInfo end


-- LuaC2G_Warrior_Improve begin
-- 请求 武将培养
LuaC2G_Warrior_Improve = Class(Base)
function LuaC2G_Warrior_Improve:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_IMPROVE"]
    self.Id = 0    -- 唯一ID
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 使用道具信息
end
function LuaC2G_Warrior_Improve:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    ItemInfo:Serialize(nbs)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Improve end


-- LuaG2C_Warrior_Improve begin
-- 返回 武将培养
LuaG2C_Warrior_Improve = Class(Base)
function LuaG2C_Warrior_Improve:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_IMPROVE"]
end
function LuaG2C_Warrior_Improve:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_Improve end


-- LuaC2G_Warrior_Star begin
-- 请求 武将升星
LuaC2G_Warrior_Star = Class(Base)
function LuaC2G_Warrior_Star:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_STAR"]
    self.Id = 0    -- 升星武将唯一ID
    self.MateriaWarriorID = List:New(Lualong)    -- 材料武将ID
end
function LuaC2G_Warrior_Star:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(#self.MateriaWarriorID)
    for i = 1, #self.MateriaWarriorID do
        nbs:WriteLong(self.MateriaWarriorID[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Star end


-- LuaG2C_Warrior_Star begin
-- 返回 武将升星
LuaG2C_Warrior_Star = Class(Base)
function LuaG2C_Warrior_Star:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_STAR"]
end
function LuaG2C_Warrior_Star:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_Star end


-- LuaC2G_Warrior_Skill begin
-- 请求 武将技能
LuaC2G_Warrior_Skill = Class(Base)
function LuaC2G_Warrior_Skill:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_SKILL"]
    self.Id = 0    -- 武将唯一ID
    self.Skill = 0    -- 技能ID
end
function LuaC2G_Warrior_Skill:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.Skill)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Skill end


-- LuaG2C_Warrior_Skill begin
-- 返回 武将技能
LuaG2C_Warrior_Skill = Class(Base)
function LuaG2C_Warrior_Skill:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_SKILL"]
end
function LuaG2C_Warrior_Skill:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_Skill end


-- LuaC2G_Warrior_WakeUnlock begin
-- 请求 武将觉醒条件激活
LuaC2G_Warrior_WakeUnlock = Class(Base)
function LuaC2G_Warrior_WakeUnlock:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_WAKEUNLOCK"]
    self.Id = 0    -- 武将唯一ID
    self.Type = 0    -- 激活类型  EWakeDataType
end
function LuaC2G_Warrior_WakeUnlock:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_WakeUnlock end


-- LuaG2C_Warrior_WakeUnlock begin
-- 返回 武将觉醒条件激活
LuaG2C_Warrior_WakeUnlock = Class(Base)
function LuaG2C_Warrior_WakeUnlock:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_WAKEUNLOCK"]
end
function LuaG2C_Warrior_WakeUnlock:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_WakeUnlock end


-- LuaC2G_Warrior_WakeInfo begin
-- 请求 武将觉醒材料信息
LuaC2G_Warrior_WakeInfo = Class(Base)
function LuaC2G_Warrior_WakeInfo:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_WAKEINFO"]
    self.Id = 0    -- 武将唯一ID
    self.Type = 0    -- 激活类型  EWakeDataType
end
function LuaC2G_Warrior_WakeInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_WakeInfo end


-- LuaG2C_Warrior_WakeInfo begin
-- 返回 武将觉醒材料信息
LuaG2C_Warrior_WakeInfo = Class(Base)
function LuaG2C_Warrior_WakeInfo:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_WAKEINFO"]
    self.ListItemNeedInfo = List:New(LuaCLS_ItemNeedInfo)    -- 需求道具列表
    self.maxStoryId = 0    -- 最大关卡ID
end
function LuaG2C_Warrior_WakeInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3306 = nbs:ReadInt()
    for i = 1, var3306 do
        local var3307 = LuaCLS_ItemNeedInfo.new()
        var3307:Unserialize(nbs)
        self.ListItemNeedInfo:Add(var3307)
    end
    self.maxStoryId = nbs:ReadInt()
end
-- LuaG2C_Warrior_WakeInfo end


-- LuaC2G_Warrior_WakeUp begin
-- 请求 武将觉醒
LuaC2G_Warrior_WakeUp = Class(Base)
function LuaC2G_Warrior_WakeUp:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_WAKEUP"]
    self.Id = 0    -- 唯一ID
end
function LuaC2G_Warrior_WakeUp:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_WakeUp end


-- LuaG2C_Warrior_WakeUp begin
-- 返回 武将觉醒
LuaG2C_Warrior_WakeUp = Class(Base)
function LuaG2C_Warrior_WakeUp:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_WAKEUP"]
end
function LuaG2C_Warrior_WakeUp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_WakeUp end


-- LuaC2G_Warrior_Sell begin
-- 请求 武将出售
LuaC2G_Warrior_Sell = Class(Base)
function LuaC2G_Warrior_Sell:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_SELL"]
    self.ListIds = List:New(Lualong)    -- 唯一ID
end
function LuaC2G_Warrior_Sell:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.ListIds)
    for i = 1, #self.ListIds do
        nbs:WriteLong(self.ListIds[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_Sell end


-- LuaG2C_Warrior_Sell begin
-- 返回 武将出售
LuaG2C_Warrior_Sell = Class(Base)
function LuaG2C_Warrior_Sell:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_SELL"]
    self.Money = 0    -- 卖店价格
end
function LuaG2C_Warrior_Sell:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Money = nbs:ReadInt()
end
-- LuaG2C_Warrior_Sell end


-- LuaCLS_BuildingPlayerInfo begin
-- 封地建筑信息
LuaCLS_BuildingPlayerInfo = Class()
function LuaCLS_BuildingPlayerInfo:ctor()
    self.Id = 0    -- ID(位置)
    self.BuildingType = 0    -- 建筑类型
    self.Level = 0    -- 等级
    self.Capacity = 0    -- 容量
    self.Stock = 0    -- 库存
    self.StoreCapacity = 0    -- 仓库容量
    self.StoreStock = 0    -- 仓库库存
    self.CapacityNextLevelAdd = 0    -- 容量下一级增量
    self.IsInBuilding = false    -- 是否在建造中
    self.BuildEndMs = 0    -- 剩余毫秒数
    self.YieldPerHour = 0    -- 每小时产量
    self.YieldPerHourNextLevelAdd = 0    -- 每小时产量下一级增量
    self.CostGold = 0    -- 建造消耗游戏币
    self.CostFood = 0    -- 建造消耗粮草
    self.CostWood = 0    -- 建造消耗木材
    self.CostIron = 0    -- 建造消耗铁矿
end
function LuaCLS_BuildingPlayerInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.BuildingType)
    nbs:WriteInt(self.Level)
    nbs:WriteLong(self.Capacity)
    nbs:WriteLong(self.Stock)
    nbs:WriteLong(self.StoreCapacity)
    nbs:WriteLong(self.StoreStock)
    nbs:WriteLong(self.CapacityNextLevelAdd)
    nbs:WriteBool(self.IsInBuilding)
    nbs:WriteLong(self.BuildEndMs)
    nbs:WriteInt(self.YieldPerHour)
    nbs:WriteInt(self.YieldPerHourNextLevelAdd)
    nbs:WriteTimeSpan(self.CostTime)
    nbs:WriteInt(self.CostGold)
    nbs:WriteInt(self.CostFood)
    nbs:WriteInt(self.CostWood)
    nbs:WriteInt(self.CostIron)
    return nbs
end
function LuaCLS_BuildingPlayerInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.BuildingType = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Capacity = nbs:ReadLong()
    self.Stock = nbs:ReadLong()
    self.StoreCapacity = nbs:ReadLong()
    self.StoreStock = nbs:ReadLong()
    self.CapacityNextLevelAdd = nbs:ReadLong()
    self.IsInBuilding = nbs:ReadBool()
    self.BuildEndMs = nbs:ReadLong()
    self.YieldPerHour = nbs:ReadInt()
    self.YieldPerHourNextLevelAdd = nbs:ReadInt()
    self.CostTime = nbs:ReadTimeSpan()
    self.CostGold = nbs:ReadInt()
    self.CostFood = nbs:ReadInt()
    self.CostWood = nbs:ReadInt()
    self.CostIron = nbs:ReadInt()
end
-- LuaCLS_BuildingPlayerInfo end


-- LuaCLS_BuildingPlayerInfoSimple begin
-- 封地建筑简易信息 用来推送
LuaCLS_BuildingPlayerInfoSimple = Class()
function LuaCLS_BuildingPlayerInfoSimple:ctor()
    self.Id = 0    -- ID(位置)
    self.Stock = 0    -- 库存
end
function LuaCLS_BuildingPlayerInfoSimple:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteLong(self.Stock)
    return nbs
end
function LuaCLS_BuildingPlayerInfoSimple:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.Stock = nbs:ReadLong()
end
-- LuaCLS_BuildingPlayerInfoSimple end


-- LuaC2G_BuildingPlayer_List begin
-- 请求 封地建筑列表
LuaC2G_BuildingPlayer_List = Class(Base)
function LuaC2G_BuildingPlayer_List:ctor()
    self._protocol = LuaProtocolId["C2G_BUILDINGPLAYER_LIST"]
end
function LuaC2G_BuildingPlayer_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_BuildingPlayer_List end


-- LuaG2C_BuildingPlayer_List begin
-- 返回 封地建筑列表
LuaG2C_BuildingPlayer_List = Class(Base)
function LuaG2C_BuildingPlayer_List:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_LIST"]
    self.DictBuilding = Dictionary:New()    -- 封地建筑列表
end
function LuaG2C_BuildingPlayer_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3329 = nbs:ReadInt()
    for i = 1, var3329 do
        local var3330 = nbs:ReadInt()
        local var3331 = LuaCLS_BuildingPlayerInfo.new()
        var3331:Unserialize(nbs)
        self.DictBuilding:Add(var3330, var3331)
    end
end
-- LuaG2C_BuildingPlayer_List end


-- LuaG2C_BuildingPlayer_PushInfoSimple begin
-- 推送 封地建筑简易信息
LuaG2C_BuildingPlayer_PushInfoSimple = Class(Base)
function LuaG2C_BuildingPlayer_PushInfoSimple:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_PUSHINFOSIMPLE"]
    self.DictBuilding = Dictionary:New()    -- 封地建筑简易信息
end
function LuaG2C_BuildingPlayer_PushInfoSimple:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3332 = nbs:ReadInt()
    for i = 1, var3332 do
        local var3333 = nbs:ReadInt()
        local var3334 = LuaCLS_BuildingPlayerInfoSimple.new()
        var3334:Unserialize(nbs)
        self.DictBuilding:Add(var3333, var3334)
    end
end
-- LuaG2C_BuildingPlayer_PushInfoSimple end


-- LuaC2G_BuildingPlayer_Harvest begin
-- 请求 封地建筑收获
LuaC2G_BuildingPlayer_Harvest = Class(Base)
function LuaC2G_BuildingPlayer_Harvest:ctor()
    self._protocol = LuaProtocolId["C2G_BUILDINGPLAYER_HARVEST"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_BuildingPlayer_Harvest:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_BuildingPlayer_Harvest end


-- LuaG2C_BuildingPlayer_Harvest begin
-- 返回 封地建筑收获
LuaG2C_BuildingPlayer_Harvest = Class(Base)
function LuaG2C_BuildingPlayer_Harvest:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_HARVEST"]
    self.CountHarvest = 0    -- 收取数量
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
end
function LuaG2C_BuildingPlayer_Harvest:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CountHarvest = nbs:ReadInt()
    self.Building:Unserialize(nbs)
end
-- LuaG2C_BuildingPlayer_Harvest end


-- LuaC2G_BuildingPlayer_HarvestAll begin
-- 请求 封地建筑一键收获
LuaC2G_BuildingPlayer_HarvestAll = Class(Base)
function LuaC2G_BuildingPlayer_HarvestAll:ctor()
    self._protocol = LuaProtocolId["C2G_BUILDINGPLAYER_HARVESTALL"]
end
function LuaC2G_BuildingPlayer_HarvestAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_BuildingPlayer_HarvestAll end


-- LuaG2C_BuildingPlayer_HarvestAll begin
-- 返回 封地建筑一键收获
LuaG2C_BuildingPlayer_HarvestAll = Class(Base)
function LuaG2C_BuildingPlayer_HarvestAll:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_HARVESTALL"]
    self.DictBuilding = Dictionary:New()    -- 封地建筑列表
end
function LuaG2C_BuildingPlayer_HarvestAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3337 = nbs:ReadInt()
    for i = 1, var3337 do
        local var3338 = nbs:ReadInt()
        local var3339 = LuaCLS_BuildingPlayerInfo.new()
        var3339:Unserialize(nbs)
        self.DictBuilding:Add(var3338, var3339)
    end
end
-- LuaG2C_BuildingPlayer_HarvestAll end


-- LuaC2G_BuildingPlayer_Build begin
-- 请求 封地建筑建造/升级
LuaC2G_BuildingPlayer_Build = Class(Base)
function LuaC2G_BuildingPlayer_Build:ctor()
    self._protocol = LuaProtocolId["C2G_BUILDINGPLAYER_BUILD"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_BuildingPlayer_Build:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_BuildingPlayer_Build end


-- LuaG2C_BuildingPlayer_Build begin
-- 返回 封地建筑建造/升级
LuaG2C_BuildingPlayer_Build = Class(Base)
function LuaG2C_BuildingPlayer_Build:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_BUILD"]
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
end
function LuaG2C_BuildingPlayer_Build:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Building:Unserialize(nbs)
end
-- LuaG2C_BuildingPlayer_Build end


-- LuaG2C_BuildingPlayer_NotifyBuilt begin
-- 通知建筑完成
LuaG2C_BuildingPlayer_NotifyBuilt = Class(Base)
function LuaG2C_BuildingPlayer_NotifyBuilt:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_NOTIFYBUILT"]
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
end
function LuaG2C_BuildingPlayer_NotifyBuilt:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Building:Unserialize(nbs)
end
-- LuaG2C_BuildingPlayer_NotifyBuilt end


-- LuaCLS_SmithSimple begin
-- 匠工坊单条信息 用来推送
LuaCLS_SmithSimple = Class()
function LuaCLS_SmithSimple:ctor()
    self.Id = 0    -- ID
    self.ListItemNeedInfo = List:New(LuaCLS_ItemNeedInfo)    -- 需求道具列表
    self.Lock = false    -- 是否解锁
    self.num = 0    -- 已有数量
end
function LuaCLS_SmithSimple:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(#self.ListItemNeedInfo)
    for i = 1, #self.ListItemNeedInfo do
        (self.ListItemNeedInfo[i]):Serialize(nbs)
    end
    nbs:WriteBool(self.Lock)
    nbs:WriteInt(self.num)
    return nbs
end
function LuaCLS_SmithSimple:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    local var3343 = nbs:ReadInt()
    for i = 1, var3343 do
        local var3344 = LuaCLS_ItemNeedInfo.new()
        var3344:Unserialize(nbs)
        self.ListItemNeedInfo:Add(var3344)
    end
    self.Lock = nbs:ReadBool()
    self.num = nbs:ReadInt()
end
-- LuaCLS_SmithSimple end


-- LuaC2G_Smith_Start begin
-- 请求 匠工坊列表
LuaC2G_Smith_Start = Class(Base)
function LuaC2G_Smith_Start:ctor()
    self._protocol = LuaProtocolId["C2G_SMITH_START"]
end
function LuaC2G_Smith_Start:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Smith_Start end


-- LuaG2C_Smith_Start begin
-- 返回 匠工坊列表
LuaG2C_Smith_Start = Class(Base)
function LuaG2C_Smith_Start:ctor()
    self._protocol = LuaProtocolId["G2C_SMITH_START"]
    self.DicSmithInfo = Dictionary:New()    -- 唯一ID列表  匠工房制作消耗
end
function LuaG2C_Smith_Start:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3347 = nbs:ReadInt()
    for i = 1, var3347 do
        local var3348 = nbs:ReadInt()
        local var3349 = LuaCLS_SmithSimple.new()
        var3349:Unserialize(nbs)
        self.DicSmithInfo:Add(var3348, var3349)
    end
end
-- LuaG2C_Smith_Start end


-- LuaC2G_Smith_Do begin
-- 请求 匠工坊制作
LuaC2G_Smith_Do = Class(Base)
function LuaC2G_Smith_Do:ctor()
    self._protocol = LuaProtocolId["C2G_SMITH_DO"]
    self.ID = 0    -- 唯一ID
    self.Count = 0    -- 制作数量
end
function LuaC2G_Smith_Do:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.ID)
    nbs:WriteInt(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Smith_Do end


-- LuaG2C_Smith_Do begin
-- 返回 匠工坊制作 产出
LuaG2C_Smith_Do = Class(Base)
function LuaG2C_Smith_Do:ctor()
    self._protocol = LuaProtocolId["G2C_SMITH_DO"]
    self.Items = List:New(LuaCLS_AwardItem)    -- 匠工房产出
    self.EquipInfo = List:New(LuaCLS_EquipInfo)    -- 装备信息
end
function LuaG2C_Smith_Do:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3350 = nbs:ReadInt()
    for i = 1, var3350 do
        local var3351 = LuaCLS_AwardItem.new()
        var3351:Unserialize(nbs)
        self.Items:Add(var3351)
    end
    local var3352 = nbs:ReadInt()
    for i = 1, var3352 do
        local var3353 = LuaCLS_EquipInfo.new()
        var3353:Unserialize(nbs)
        self.EquipInfo:Add(var3353)
    end
end
-- LuaG2C_Smith_Do end


-- LuaCLS_ScienceInfo begin
-- 兵法信息
LuaCLS_ScienceInfo = Class()
function LuaCLS_ScienceInfo:ctor()
    self.ScienceType = 0    -- 兵法类型
    self.Level = 0    -- 等级
    self.ConfigID = 0    -- 配置ID
    self.IsInLearning = false    -- 是否在建造中
    self.LearnEndMs = 0    -- 剩余毫秒数
    self.CompleteNeed = 0    -- 立即完成需要金币
end
function LuaCLS_ScienceInfo:Serialize(nbs)
    nbs:WriteInt(self.ScienceType)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.ConfigID)
    nbs:WriteBool(self.IsInLearning)
    nbs:WriteLong(self.LearnEndMs)
    nbs:WriteLong(self.CompleteNeed)
    return nbs
end
function LuaCLS_ScienceInfo:Unserialize(nbs)
    self.ScienceType = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.ConfigID = nbs:ReadInt()
    self.IsInLearning = nbs:ReadBool()
    self.LearnEndMs = nbs:ReadLong()
    self.CompleteNeed = nbs:ReadLong()
end
-- LuaCLS_ScienceInfo end


-- LuaC2G_Science_List begin
-- 请求 兵法列表
LuaC2G_Science_List = Class(Base)
function LuaC2G_Science_List:ctor()
    self._protocol = LuaProtocolId["C2G_SCIENCE_LIST"]
end
function LuaC2G_Science_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Science_List end


-- LuaG2C_Science_List begin
-- 返回 兵法列表
LuaG2C_Science_List = Class(Base)
function LuaG2C_Science_List:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_LIST"]
    self.DictScience = Dictionary:New()    -- 兵法列表
end
function LuaG2C_Science_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3360 = nbs:ReadInt()
    for i = 1, var3360 do
        local var3361 = nbs:ReadInt()
        local var3362 = LuaCLS_ScienceInfo.new()
        var3362:Unserialize(nbs)
        self.DictScience:Add(var3361, var3362)
    end
end
-- LuaG2C_Science_List end


-- LuaC2G_Science_Learn begin
-- 请求 兵法研究
LuaC2G_Science_Learn = Class(Base)
function LuaC2G_Science_Learn:ctor()
    self._protocol = LuaProtocolId["C2G_SCIENCE_LEARN"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_Science_Learn:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Science_Learn end


-- LuaG2C_Science_Learn begin
-- 返回 兵法研究
LuaG2C_Science_Learn = Class(Base)
function LuaG2C_Science_Learn:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_LEARN"]
    self.Info = LuaCLS_ScienceInfo.new()    -- 兵法信息
end
function LuaG2C_Science_Learn:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Science_Learn end


-- LuaC2G_Science_Info begin
-- 请求 兵法信息
LuaC2G_Science_Info = Class(Base)
function LuaC2G_Science_Info:ctor()
    self._protocol = LuaProtocolId["C2G_SCIENCE_INFO"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_Science_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Science_Info end


-- LuaG2C_Science_Info begin
-- 返回 兵法信息
LuaG2C_Science_Info = Class(Base)
function LuaG2C_Science_Info:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_INFO"]
    self.Info = LuaCLS_ScienceInfo.new()    -- 兵法信息
end
function LuaG2C_Science_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Science_Info end


-- LuaC2G_Science_Cancel begin
-- 请求 兵法取消研究
LuaC2G_Science_Cancel = Class(Base)
function LuaC2G_Science_Cancel:ctor()
    self._protocol = LuaProtocolId["C2G_SCIENCE_CANCEL"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_Science_Cancel:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Science_Cancel end


-- LuaG2C_Science_Cancel begin
-- 返回 兵法取消研究
LuaG2C_Science_Cancel = Class(Base)
function LuaG2C_Science_Cancel:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_CANCEL"]
    self.Info = LuaCLS_ScienceInfo.new()    -- 兵法信息
end
function LuaG2C_Science_Cancel:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Science_Cancel end


-- LuaG2C_Science_Notify begin
-- 通知兵法完成
LuaG2C_Science_Notify = Class(Base)
function LuaG2C_Science_Notify:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_NOTIFY"]
    self.ScienceInfo = LuaCLS_ScienceInfo.new()    -- 刷新兵法信息
end
function LuaG2C_Science_Notify:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ScienceInfo:Unserialize(nbs)
end
-- LuaG2C_Science_Notify end


-- LuaCLS_RecruitInfo begin
-- 兵营募兵信息
LuaCLS_RecruitInfo = Class()
function LuaCLS_RecruitInfo:ctor()
    self.Id = 0    -- ID(位置)
    self.ERecruitStatus = 0    -- 募兵状态 ERecruitStatus
end
function LuaCLS_RecruitInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteByte(self.ERecruitStatus)
    nbs:WriteDateTime(self.DtRecruitStart)
    nbs:WriteDateTime(self.DtRecruitEnd)
    return nbs
end
function LuaCLS_RecruitInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.ERecruitStatus = nbs:ReadByte()
    self.DtRecruitStart = nbs:ReadDateTime()
    self.DtRecruitEnd = nbs:ReadDateTime()
end
-- LuaCLS_RecruitInfo end


-- LuaC2G_Recruit_Info begin
-- 请求 兵营募兵信息
LuaC2G_Recruit_Info = Class(Base)
function LuaC2G_Recruit_Info:ctor()
    self._protocol = LuaProtocolId["C2G_RECRUIT_INFO"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_Recruit_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Recruit_Info end


-- LuaG2C_Recruit_Info begin
-- 返回 兵营募兵信息
LuaG2C_Recruit_Info = Class(Base)
function LuaG2C_Recruit_Info:ctor()
    self._protocol = LuaProtocolId["G2C_RECRUIT_INFO"]
    self.Id = 0    -- ID(位置)
    self.RecruitInfo = LuaCLS_RecruitInfo.new()    -- 兵营募兵信息
end
function LuaG2C_Recruit_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    self.RecruitInfo:Unserialize(nbs)
end
-- LuaG2C_Recruit_Info end


-- LuaC2G_Recruit_Start begin
-- 请求 兵营募兵
LuaC2G_Recruit_Start = Class(Base)
function LuaC2G_Recruit_Start:ctor()
    self._protocol = LuaProtocolId["C2G_RECRUIT_START"]
    self.Id = 0    -- ID(位置)
    self.Count = 0    -- 数量
end
function LuaC2G_Recruit_Start:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Recruit_Start end


-- LuaG2C_Recruit_Start begin
-- 返回 兵营募兵
LuaG2C_Recruit_Start = Class(Base)
function LuaG2C_Recruit_Start:ctor()
    self._protocol = LuaProtocolId["G2C_RECRUIT_START"]
    self.Id = 0    -- ID(位置)
    self.Count = 0    -- 数量
    self.RecruitInfo = LuaCLS_RecruitInfo.new()    -- 兵营募兵信息
end
function LuaG2C_Recruit_Start:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    self.Count = nbs:ReadInt()
    self.RecruitInfo:Unserialize(nbs)
end
-- LuaG2C_Recruit_Start end


-- LuaG2C_Recruit_NotifyComplete begin
-- 通知募兵完成
LuaG2C_Recruit_NotifyComplete = Class(Base)
function LuaG2C_Recruit_NotifyComplete:ctor()
    self._protocol = LuaProtocolId["G2C_RECRUIT_NOTIFYCOMPLETE"]
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
end
function LuaG2C_Recruit_NotifyComplete:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Building:Unserialize(nbs)
end
-- LuaG2C_Recruit_NotifyComplete end


-- LuaC2G_Player_SpeedupInfo begin
-- 请求 通用加速信息
LuaC2G_Player_SpeedupInfo = Class(Base)
function LuaC2G_Player_SpeedupInfo:ctor()
    self._protocol = LuaProtocolId["C2G_PLAYER_SPEEDUPINFO"]
    self.Id = 0    -- ID(位置)
    self.Type = 0    -- 类型ESpeedup
end
function LuaC2G_Player_SpeedupInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Player_SpeedupInfo end


-- LuaG2C_Player_SpeedupInfo begin
-- 返回 通用加速信息
LuaG2C_Player_SpeedupInfo = Class(Base)
function LuaG2C_Player_SpeedupInfo:ctor()
    self._protocol = LuaProtocolId["G2C_PLAYER_SPEEDUPINFO"]
    self.EndMs = 0    -- 剩余毫秒数
    self.CompleteNeed = 0    -- 立即完成需要金币
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表(加速类)
end
function LuaG2C_Player_SpeedupInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.EndMs = nbs:ReadLong()
    self.CompleteNeed = nbs:ReadLong()
    local var3379 = nbs:ReadInt()
    for i = 1, var3379 do
        local var3380 = LuaCLS_ItemInfo.new()
        var3380:Unserialize(nbs)
        self.ListItem:Add(var3380)
    end
end
-- LuaG2C_Player_SpeedupInfo end


-- LuaC2G_BuildingPlayer_SpeedupComplete begin
-- 请求 封地建筑建造加速立即完成
LuaC2G_BuildingPlayer_SpeedupComplete = Class(Base)
function LuaC2G_BuildingPlayer_SpeedupComplete:ctor()
    self._protocol = LuaProtocolId["C2G_BUILDINGPLAYER_SPEEDUPCOMPLETE"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_BuildingPlayer_SpeedupComplete:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_BuildingPlayer_SpeedupComplete end


-- LuaG2C_BuildingPlayer_SpeedupComplete begin
-- 返回 封地建筑建造加速立即完成
LuaG2C_BuildingPlayer_SpeedupComplete = Class(Base)
function LuaG2C_BuildingPlayer_SpeedupComplete:ctor()
    self._protocol = LuaProtocolId["G2C_BUILDINGPLAYER_SPEEDUPCOMPLETE"]
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
end
function LuaG2C_BuildingPlayer_SpeedupComplete:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Building:Unserialize(nbs)
end
-- LuaG2C_BuildingPlayer_SpeedupComplete end


-- LuaC2G_Recruit_Speedup begin
-- 请求 兵营募兵加速
LuaC2G_Recruit_Speedup = Class(Base)
function LuaC2G_Recruit_Speedup:ctor()
    self._protocol = LuaProtocolId["C2G_RECRUIT_SPEEDUP"]
    self.Id = 0    -- ID(位置)
    self.Type = 0    -- 类型ESpeedup
end
function LuaC2G_Recruit_Speedup:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Recruit_Speedup end


-- LuaG2C_Recruit_Speedup begin
-- 返回 兵营募兵加速
LuaG2C_Recruit_Speedup = Class(Base)
function LuaG2C_Recruit_Speedup:ctor()
    self._protocol = LuaProtocolId["G2C_RECRUIT_SPEEDUP"]
    self.Id = 0    -- ID(位置)
    self.RecruitInfo = LuaCLS_RecruitInfo.new()    -- 兵营募兵信息
end
function LuaG2C_Recruit_Speedup:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    self.RecruitInfo:Unserialize(nbs)
end
-- LuaG2C_Recruit_Speedup end


-- LuaC2G_Science_Fast begin
-- 请求 兵法立即研究或加速信息
LuaC2G_Science_Fast = Class(Base)
function LuaC2G_Science_Fast:ctor()
    self._protocol = LuaProtocolId["C2G_SCIENCE_FAST"]
    self.Id = 0    -- ID(位置)
end
function LuaC2G_Science_Fast:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Science_Fast end


-- LuaG2C_Science_Fast begin
-- 返回 兵法立即研究或加速信息
LuaG2C_Science_Fast = Class(Base)
function LuaG2C_Science_Fast:ctor()
    self._protocol = LuaProtocolId["G2C_SCIENCE_FAST"]
    self.Info = LuaCLS_ScienceInfo.new()    -- 兵法信息
end
function LuaG2C_Science_Fast:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Science_Fast end


-- LuaC2G_Player_SpeedupBuy begin
-- 请求 加速道具购买
LuaC2G_Player_SpeedupBuy = Class(Base)
function LuaC2G_Player_SpeedupBuy:ctor()
    self._protocol = LuaProtocolId["C2G_PLAYER_SPEEDUPBUY"]
    self.Id = 0    -- ID ShopSpeedUp表里的ID
    self.Amount = 0    -- 数量
    self.Type = 0    -- 类型ESpeedup
end
function LuaC2G_Player_SpeedupBuy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Amount)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Player_SpeedupBuy end


-- LuaG2C_Player_SpeedupBuy begin
-- 返回 加速道具购买
LuaG2C_Player_SpeedupBuy = Class(Base)
function LuaG2C_Player_SpeedupBuy:ctor()
    self._protocol = LuaProtocolId["G2C_PLAYER_SPEEDUPBUY"]
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表(加速类)
end
function LuaG2C_Player_SpeedupBuy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3385 = nbs:ReadInt()
    for i = 1, var3385 do
        local var3386 = LuaCLS_ItemInfo.new()
        var3386:Unserialize(nbs)
        self.ListItem:Add(var3386)
    end
end
-- LuaG2C_Player_SpeedupBuy end


-- LuaC2G_Player_Speedup begin
-- 请求 加速使用道具
LuaC2G_Player_Speedup = Class(Base)
function LuaC2G_Player_Speedup:ctor()
    self._protocol = LuaProtocolId["C2G_PLAYER_SPEEDUP"]
    self.Id = 0    -- ID(位置)
    self.Items = List:New(LuaCLS_ItemInfo)    -- 道具
    self.Type = 0    -- 类型ESpeedup
end
function LuaC2G_Player_Speedup:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(#self.Items)
    for i = 1, #self.Items do
        (self.Items[i]):Serialize(nbs)
    end
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Player_Speedup end


-- LuaG2C_Player_Speedup begin
-- 返回 加速使用道具
LuaG2C_Player_Speedup = Class(Base)
function LuaG2C_Player_Speedup:ctor()
    self._protocol = LuaProtocolId["G2C_PLAYER_SPEEDUP"]
    self.Type = 0    -- 类型ESpeedup
    self.Building = LuaCLS_BuildingPlayerInfo.new()    -- 刷新建筑信息
    self.RecruitInfo = LuaCLS_RecruitInfo.new()    -- 兵营募兵信息
    self.ScienceInfo = LuaCLS_ScienceInfo.new()    -- 兵法信息
    self.ListItem = List:New(LuaCLS_ItemInfo)    -- 道具列表(加速类)
    self.EndMs = 0    -- 剩余毫秒数
    self.CompleteNeed = 0    -- 立即完成需要金币
end
function LuaG2C_Player_Speedup:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Type = nbs:ReadInt()
    self.Building:Unserialize(nbs)
    self.RecruitInfo:Unserialize(nbs)
    self.ScienceInfo:Unserialize(nbs)
    local var3391 = nbs:ReadInt()
    for i = 1, var3391 do
        local var3392 = LuaCLS_ItemInfo.new()
        var3392:Unserialize(nbs)
        self.ListItem:Add(var3392)
    end
    self.EndMs = nbs:ReadLong()
    self.CompleteNeed = nbs:ReadLong()
end
-- LuaG2C_Player_Speedup end


-- LuaC2G_Help_Fast begin
-- 请求 小助手
LuaC2G_Help_Fast = Class(Base)
function LuaC2G_Help_Fast:ctor()
    self._protocol = LuaProtocolId["C2G_HELP_FAST"]
end
function LuaC2G_Help_Fast:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Help_Fast end


-- LuaG2C_Help_Fast begin
-- 返回 小助手
LuaG2C_Help_Fast = Class(Base)
function LuaG2C_Help_Fast:ctor()
    self._protocol = LuaProtocolId["G2C_HELP_FAST"]
    self.Building1 = LuaCLS_BuildingPlayerInfo.new()    -- 建筑队列1信息
    self.Building2 = LuaCLS_BuildingPlayerInfo.new()    -- 建筑队列2信息
    self.ScienceInfo = LuaCLS_ScienceInfo.new()    -- 兵法信息
    self.RecruitInfoBu = LuaCLS_RecruitInfo.new()    -- 步兵营募兵信息
    self.RecruitInfoQi = LuaCLS_RecruitInfo.new()    -- 骑兵营募兵信息
    self.RecruitInfoGong = LuaCLS_RecruitInfo.new()    -- 弓兵营募兵信息
end
function LuaG2C_Help_Fast:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Building1:Unserialize(nbs)
    self.Building2:Unserialize(nbs)
    self.ScienceInfo:Unserialize(nbs)
    self.RecruitInfoBu:Unserialize(nbs)
    self.RecruitInfoQi:Unserialize(nbs)
    self.RecruitInfoGong:Unserialize(nbs)
end
-- LuaG2C_Help_Fast end


-- LuaCLS_CityInfoBase begin
-- 城池信息
LuaCLS_CityInfoBase = Class()
function LuaCLS_CityInfoBase:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.LeaderPuid = 0    -- 太守Id
    self.LeaderName = ""    -- 太守名字
    self.Prosperity = 0    -- 繁荣度
end
function LuaCLS_CityInfoBase:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.LeaderPuid)
    nbs:WriteString(self.LeaderName)
    nbs:WriteLong(self.Prosperity)
    return nbs
end
function LuaCLS_CityInfoBase:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.LeaderPuid = nbs:ReadLong()
    self.LeaderName = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
end
-- LuaCLS_CityInfoBase end


-- LuaCLS_CityInfo4Guild begin
-- 势力城池信息
LuaCLS_CityInfo4Guild = Class()
function LuaCLS_CityInfo4Guild:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.LeaderPuid = 0    -- 太守Id
    self.LeaderName = ""    -- 太守名字
    self.Prosperity = 0    -- 繁荣度
    self.Revenue = 0    -- 本周收入(府库库存)
end
function LuaCLS_CityInfo4Guild:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.LeaderPuid)
    nbs:WriteString(self.LeaderName)
    nbs:WriteLong(self.Prosperity)
    nbs:WriteInt(self.Revenue)
    return nbs
end
function LuaCLS_CityInfo4Guild:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.LeaderPuid = nbs:ReadLong()
    self.LeaderName = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
    self.Revenue = nbs:ReadInt()
end
-- LuaCLS_CityInfo4Guild end


-- LuaC2G_City_CityInfo begin
-- 请求 城池信息
LuaC2G_City_CityInfo = Class(Base)
function LuaC2G_City_CityInfo:ctor()
    self._protocol = LuaProtocolId["C2G_CITY_CITYINFO"]
    self.Uid = 0    -- 城池唯一ID(配置ID)
end
function LuaC2G_City_CityInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_City_CityInfo end


-- LuaG2C_City_CityInfo begin
-- 返回 城池信息
LuaG2C_City_CityInfo = Class(Base)
function LuaG2C_City_CityInfo:ctor()
    self._protocol = LuaProtocolId["G2C_CITY_CITYINFO"]
    self.CityInfo = LuaCLS_CityInfoBase.new()    -- 城池信息
end
function LuaG2C_City_CityInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityInfo:Unserialize(nbs)
end
-- LuaG2C_City_CityInfo end


-- LuaC2G_City_ListCity begin
-- 请求 城池列表
LuaC2G_City_ListCity = Class(Base)
function LuaC2G_City_ListCity:ctor()
    self._protocol = LuaProtocolId["C2G_CITY_LISTCITY"]
end
function LuaC2G_City_ListCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_City_ListCity end


-- LuaG2C_City_ListCity begin
-- 返回 城池列表
LuaG2C_City_ListCity = Class(Base)
function LuaG2C_City_ListCity:ctor()
    self._protocol = LuaProtocolId["G2C_CITY_LISTCITY"]
    self.CapitalCity = 0    -- 都城ID
    self.DictCity = Dictionary:New()    -- 城池列表
end
function LuaG2C_City_ListCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CapitalCity = nbs:ReadInt()
    local var3412 = nbs:ReadInt()
    for i = 1, var3412 do
        local var3413 = nbs:ReadInt()
        local var3414 = LuaCLS_CityInfoBase.new()
        var3414:Unserialize(nbs)
        self.DictCity:Add(var3413, var3414)
    end
end
-- LuaG2C_City_ListCity end


-- LuaC2G_City_DepotInfo begin
-- 请求 府库
LuaC2G_City_DepotInfo = Class(Base)
function LuaC2G_City_DepotInfo:ctor()
    self._protocol = LuaProtocolId["C2G_CITY_DEPOTINFO"]
    self.CityUid = 0    -- 城池ID
end
function LuaC2G_City_DepotInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_City_DepotInfo end


-- LuaG2C_City_DepotInfo begin
-- 返回 府库
LuaG2C_City_DepotInfo = Class(Base)
function LuaG2C_City_DepotInfo:ctor()
    self._protocol = LuaProtocolId["G2C_CITY_DEPOTINFO"]
    self.Prosperity = 0    -- 繁荣度
    self.RevenueDay = 0    -- 本日预期收益
    self.RevenueAll = 0    -- 本期预期收益
end
function LuaG2C_City_DepotInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
    self.RevenueDay = nbs:ReadInt()
    self.RevenueAll = nbs:ReadInt()
end
-- LuaG2C_City_DepotInfo end


-- LuaCLS_BuildingItemNeedInfo begin
-- 建筑道具需求
LuaCLS_BuildingItemNeedInfo = Class()
function LuaCLS_BuildingItemNeedInfo:ctor()
    self.ItemId = 0    -- 道具Id
    self.Built = 0    -- 已建
    self.Need = 0    -- 需求
    self.Value = 0    -- 自己拥有
end
function LuaCLS_BuildingItemNeedInfo:Serialize(nbs)
    nbs:WriteInt(self.ItemId)
    nbs:WriteInt(self.Built)
    nbs:WriteInt(self.Need)
    nbs:WriteInt(self.Value)
    return nbs
end
function LuaCLS_BuildingItemNeedInfo:Unserialize(nbs)
    self.ItemId = nbs:ReadInt()
    self.Built = nbs:ReadInt()
    self.Need = nbs:ReadInt()
    self.Value = nbs:ReadInt()
end
-- LuaCLS_BuildingItemNeedInfo end


-- LuaCLS_CityBuildingInfo begin
-- 城池建筑信息
LuaCLS_CityBuildingInfo = Class()
function LuaCLS_CityBuildingInfo:ctor()
    self.Pos = 0    -- (位置)
    self.BuildingType = 0    -- 建筑类型
    self.Level = 0    -- 等级
    self.DictNeedInfo = Dictionary:New()    -- 建筑道具需求
end
function LuaCLS_CityBuildingInfo:Serialize(nbs)
    nbs:WriteInt(self.Pos)
    nbs:WriteInt(self.BuildingType)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(#self.DictNeedInfo)
    for key, value in pairs(self.DictNeedInfo) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_CityBuildingInfo:Unserialize(nbs)
    self.Pos = nbs:ReadInt()
    self.BuildingType = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    local var3425 = nbs:ReadInt()
    for i = 1, var3425 do
        local var3426 = nbs:ReadInt()
        local var3427 = LuaCLS_BuildingItemNeedInfo.new()
        var3427:Unserialize(nbs)
        self.DictNeedInfo:Add(var3426, var3427)
    end
end
-- LuaCLS_CityBuildingInfo end


-- LuaC2G_CityBuilding_List begin
-- 请求 建筑列表
LuaC2G_CityBuilding_List = Class(Base)
function LuaC2G_CityBuilding_List:ctor()
    self._protocol = LuaProtocolId["C2G_CITYBUILDING_LIST"]
    self.Uid = 0    -- 城池ID
end
function LuaC2G_CityBuilding_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_CityBuilding_List end


-- LuaG2C_CityBuilding_List begin
-- 返回 建筑列表
LuaG2C_CityBuilding_List = Class(Base)
function LuaG2C_CityBuilding_List:ctor()
    self._protocol = LuaProtocolId["G2C_CITYBUILDING_LIST"]
    self.DictBuilding = Dictionary:New()    -- 府城建筑列表
end
function LuaG2C_CityBuilding_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3428 = nbs:ReadInt()
    for i = 1, var3428 do
        local var3429 = nbs:ReadInt()
        local var3430 = LuaCLS_CityBuildingInfo.new()
        var3430:Unserialize(nbs)
        self.DictBuilding:Add(var3429, var3430)
    end
end
-- LuaG2C_CityBuilding_List end


-- LuaC2G_CityBuilding_Build begin
-- 请求 建筑升级
LuaC2G_CityBuilding_Build = Class(Base)
function LuaC2G_CityBuilding_Build:ctor()
    self._protocol = LuaProtocolId["C2G_CITYBUILDING_BUILD"]
    self.Uid = 0    -- 城池ID
    self.Pos = 0    -- (位置)
    self.DictBuildUse = Dictionary:New()    -- 建筑使用(道具ID 数量)
end
function LuaC2G_CityBuilding_Build:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteInt(self.Pos)
    nbs:WriteInt(#self.DictBuildUse)
    for key, value in pairs(self.DictBuildUse) do
        nbs:WriteInt(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_CityBuilding_Build end


-- LuaG2C_CityBuilding_Build begin
-- 返回 建筑升级
LuaG2C_CityBuilding_Build = Class(Base)
function LuaG2C_CityBuilding_Build:ctor()
    self._protocol = LuaProtocolId["G2C_CITYBUILDING_BUILD"]
    self.BuildingInfo = LuaCLS_CityBuildingInfo.new()    -- 建筑信息
end
function LuaG2C_CityBuilding_Build:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BuildingInfo:Unserialize(nbs)
end
-- LuaG2C_CityBuilding_Build end


-- LuaCLS_CampWallInfo begin
-- 守备营城墙信息
LuaCLS_CampWallInfo = Class()
function LuaCLS_CampWallInfo:ctor()
    self.Uid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallHp = LuaCLS_CountInfo.new()    -- 城墙耐久
    self.Bowls = 0    -- 滚木
    self.Frise = 0    -- 拒马
    self.Trap = 0    -- 陷阱
    self.DictNeedInfo = Dictionary:New()    -- 建筑道具需求
end
function LuaCLS_CampWallInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    WallHp:Serialize(nbs)
    nbs:WriteTimeSpan(self.TsCooldownRepair)
    nbs:WriteInt(self.Bowls)
    nbs:WriteInt(self.Frise)
    nbs:WriteInt(self.Trap)
    nbs:WriteInt(#self.DictNeedInfo)
    for key, value in pairs(self.DictNeedInfo) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_CampWallInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.WallHp:Unserialize(nbs)
    self.TsCooldownRepair = nbs:ReadTimeSpan()
    self.Bowls = nbs:ReadInt()
    self.Frise = nbs:ReadInt()
    self.Trap = nbs:ReadInt()
    local var3438 = nbs:ReadInt()
    for i = 1, var3438 do
        local var3439 = nbs:ReadInt()
        local var3440 = LuaCLS_ItemNeedInfo.new()
        var3440:Unserialize(nbs)
        self.DictNeedInfo:Add(var3439, var3440)
    end
end
-- LuaCLS_CampWallInfo end


-- LuaCLS_WallInfo begin
-- 城墙信息
LuaCLS_WallInfo = Class()
function LuaCLS_WallInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.Level = 0    -- 等级
    self.DictCampWall = Dictionary:New()    -- 守备营城墙信息
end
function LuaCLS_WallInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(#self.DictCampWall)
    for key, value in pairs(self.DictCampWall) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_WallInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    local var3443 = nbs:ReadInt()
    for i = 1, var3443 do
        local var3444 = nbs:ReadInt()
        local var3445 = LuaCLS_CampWallInfo.new()
        var3445:Unserialize(nbs)
        self.DictCampWall:Add(var3444, var3445)
    end
end
-- LuaCLS_WallInfo end


-- LuaC2G_Wall_Info begin
-- 请求 城墙信息
LuaC2G_Wall_Info = Class(Base)
function LuaC2G_Wall_Info:ctor()
    self._protocol = LuaProtocolId["C2G_WALL_INFO"]
    self.CityUid = 0    -- 城池ID
end
function LuaC2G_Wall_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Wall_Info end


-- LuaG2C_Wall_Info begin
-- 返回 城墙信息
LuaG2C_Wall_Info = Class(Base)
function LuaG2C_Wall_Info:ctor()
    self._protocol = LuaProtocolId["G2C_WALL_INFO"]
    self.CityUid = 0    -- 城池ID
    self.WallInfo = LuaCLS_WallInfo.new()    -- 城墙信息
end
function LuaG2C_Wall_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.WallInfo:Unserialize(nbs)
end
-- LuaG2C_Wall_Info end


-- LuaC2G_Wall_Repair begin
-- 请求 城墙修复
LuaC2G_Wall_Repair = Class(Base)
function LuaC2G_Wall_Repair:ctor()
    self._protocol = LuaProtocolId["C2G_WALL_REPAIR"]
    self.CityUid = 0    -- 城池ID
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
end
function LuaC2G_Wall_Repair:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Wall_Repair end


-- LuaG2C_Wall_Repair begin
-- 返回 城墙修复
LuaG2C_Wall_Repair = Class(Base)
function LuaG2C_Wall_Repair:ctor()
    self._protocol = LuaProtocolId["G2C_WALL_REPAIR"]
    self.CityUid = 0    -- 城池ID
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallInfo = LuaCLS_WallInfo.new()    -- 城墙信息
end
function LuaG2C_Wall_Repair:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.WallInfo:Unserialize(nbs)
end
-- LuaG2C_Wall_Repair end


-- LuaC2G_Wall_MakeWork begin
-- 请求 城墙建造器械
LuaC2G_Wall_MakeWork = Class(Base)
function LuaC2G_Wall_MakeWork:ctor()
    self._protocol = LuaProtocolId["C2G_WALL_MAKEWORK"]
    self.CityUid = 0    -- 城池ID
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallWorkType = 0    -- 城墙器械类型 EWallWorkType
    self.MakeCount = 0    -- 建造数目
end
function LuaC2G_Wall_MakeWork:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteInt(self.WallWorkType)
    nbs:WriteInt(self.MakeCount)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Wall_MakeWork end


-- LuaG2C_Wall_MakeWork begin
-- 返回 城墙建造器械
LuaG2C_Wall_MakeWork = Class(Base)
function LuaG2C_Wall_MakeWork:ctor()
    self._protocol = LuaProtocolId["G2C_WALL_MAKEWORK"]
    self.CityUid = 0    -- 城池ID
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallWorkType = 0    -- 城墙器械类型 EWallWorkType
    self.MakeCount = 0    -- 建造数目
    self.WallInfo = LuaCLS_WallInfo.new()    -- 城墙信息
end
function LuaG2C_Wall_MakeWork:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.WallWorkType = nbs:ReadInt()
    self.MakeCount = nbs:ReadInt()
    self.WallInfo:Unserialize(nbs)
end
-- LuaG2C_Wall_MakeWork end


-- LuaCLS_CampNpcInfo begin
-- 守军NPC信息
LuaCLS_CampNpcInfo = Class()
function LuaCLS_CampNpcInfo:ctor()
    self.Uid = 0    -- 唯一ID(1-n)
    self.StageId = 0    -- 关卡配置ID
    self.IsAlive = false    -- 存活
end
function LuaCLS_CampNpcInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteInt(self.StageId)
    nbs:WriteBool(self.IsAlive)
    nbs:WriteTimeSpan(self.TsRevive)
    return nbs
end
function LuaCLS_CampNpcInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.StageId = nbs:ReadInt()
    self.IsAlive = nbs:ReadBool()
    self.TsRevive = nbs:ReadTimeSpan()
end
-- LuaCLS_CampNpcInfo end


-- LuaCLS_CampInfo begin
-- 守备营信息
LuaCLS_CampInfo = Class()
function LuaCLS_CampInfo:ctor()
    self.Uid = 0    -- 唯一ID(1-5)(1=主营)
    self.DictCampNpc = Dictionary:New()    -- 守军NPC
end
function LuaCLS_CampInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteInt(#self.DictCampNpc)
    for key, value in pairs(self.DictCampNpc) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_CampInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    local var3461 = nbs:ReadInt()
    for i = 1, var3461 do
        local var3462 = nbs:ReadInt()
        local var3463 = LuaCLS_CampNpcInfo.new()
        var3463:Unserialize(nbs)
        self.DictCampNpc:Add(var3462, var3463)
    end
end
-- LuaCLS_CampInfo end


-- LuaC2G_Camp_Info begin
-- 请求 守备营信息
LuaC2G_Camp_Info = Class(Base)
function LuaC2G_Camp_Info:ctor()
    self._protocol = LuaProtocolId["C2G_CAMP_INFO"]
    self.CityUid = 0    -- 城池ID
end
function LuaC2G_Camp_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Camp_Info end


-- LuaG2C_Camp_Info begin
-- 返回 守备营信息
LuaG2C_Camp_Info = Class(Base)
function LuaG2C_Camp_Info:ctor()
    self._protocol = LuaProtocolId["G2C_CAMP_INFO"]
    self.CityUid = 0    -- 城池ID
    self.DictCamp = Dictionary:New()    -- 守备营信息
end
function LuaG2C_Camp_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    local var3465 = nbs:ReadInt()
    for i = 1, var3465 do
        local var3466 = nbs:ReadInt()
        local var3467 = LuaCLS_CampInfo.new()
        var3467:Unserialize(nbs)
        self.DictCamp:Add(var3466, var3467)
    end
end
-- LuaG2C_Camp_Info end


-- LuaC2G_City_ShopInfo begin
-- 请求 城池珍宝阁信息
LuaC2G_City_ShopInfo = Class(Base)
function LuaC2G_City_ShopInfo:ctor()
    self._protocol = LuaProtocolId["C2G_CITY_SHOPINFO"]
    self.CityUid = 0    -- 城池ID
end
function LuaC2G_City_ShopInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_City_ShopInfo end


-- LuaG2C_City_ShopInfo begin
-- 返回 城池珍宝阁信息
LuaG2C_City_ShopInfo = Class(Base)
function LuaG2C_City_ShopInfo:ctor()
    self._protocol = LuaProtocolId["G2C_CITY_SHOPINFO"]
    self.CityUid = 0    -- 城池ID
    self.GoodsInfo = List:New(LuaCLS_ShopGoodsInfo)    -- 商品信息
    self.SpecialtyGoodsInfo = Dictionary:New()    -- 特产商品信息
    self.Contribution = 0    -- 拥有的贡献
end
function LuaG2C_City_ShopInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    local var3469 = nbs:ReadInt()
    for i = 1, var3469 do
        local var3470 = LuaCLS_ShopGoodsInfo.new()
        var3470:Unserialize(nbs)
        self.GoodsInfo:Add(var3470)
    end
    local var3471 = nbs:ReadInt()
    for i = 1, var3471 do
        local var3472 = nbs:ReadInt()
        local var3473 = nbs:ReadInt()
        self.SpecialtyGoodsInfo:Add(var3472, var3473)
    end
    self.Contribution = nbs:ReadInt()
end
-- LuaG2C_City_ShopInfo end


-- LuaC2G_City_ShopBuy begin
-- 请求 处理城池珍宝阁购买
LuaC2G_City_ShopBuy = Class(Base)
function LuaC2G_City_ShopBuy:ctor()
    self._protocol = LuaProtocolId["C2G_CITY_SHOPBUY"]
    self.CityUid = 0    -- 城池ID
    self.Config = 0    -- 配置ID
    self.Amount = 0    -- 数量
end
function LuaC2G_City_ShopBuy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.Config)
    nbs:WriteInt(self.Amount)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_City_ShopBuy end


-- LuaG2C_City_ShopBuy begin
-- 返回 处理城池珍宝阁购买
LuaG2C_City_ShopBuy = Class(Base)
function LuaG2C_City_ShopBuy:ctor()
    self._protocol = LuaProtocolId["G2C_CITY_SHOPBUY"]
    self.GoodsInfo = List:New(LuaCLS_ShopGoodsInfo)    -- 商品信息
    self.Contribution = 0    -- 拥有的贡献
    self.CityUid = 0    -- 城池ID
    self.SpecialtyGoodsInfo = Dictionary:New()    -- 特产商品信息
end
function LuaG2C_City_ShopBuy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3475 = nbs:ReadInt()
    for i = 1, var3475 do
        local var3476 = LuaCLS_ShopGoodsInfo.new()
        var3476:Unserialize(nbs)
        self.GoodsInfo:Add(var3476)
    end
    self.Contribution = nbs:ReadInt()
    self.CityUid = nbs:ReadInt()
    local var3479 = nbs:ReadInt()
    for i = 1, var3479 do
        local var3480 = nbs:ReadInt()
        local var3481 = nbs:ReadInt()
        self.SpecialtyGoodsInfo:Add(var3480, var3481)
    end
end
-- LuaG2C_City_ShopBuy end


-- LuaCLS_ShopPageInfo begin
-- 商城页面信息
LuaCLS_ShopPageInfo = Class()
function LuaCLS_ShopPageInfo:ctor()
    self.Id = 0    -- ID
    self.DictGoods = Dictionary:New()    -- 商品列表
    self.Cooldown = 0    -- 剩余刷新时间 -1=无限制
end
function LuaCLS_ShopPageInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(#self.DictGoods)
    for key, value in pairs(self.DictGoods) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    nbs:WriteInt(self.Cooldown)
    return nbs
end
function LuaCLS_ShopPageInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    local var3483 = nbs:ReadInt()
    for i = 1, var3483 do
        local var3484 = nbs:ReadInt()
        local var3485 = LuaCLS_ShopGoodsInfo.new()
        var3485:Unserialize(nbs)
        self.DictGoods:Add(var3484, var3485)
    end
    self.Cooldown = nbs:ReadInt()
end
-- LuaCLS_ShopPageInfo end


-- LuaCLS_ShopGoodsInfo begin
-- 商城货物信息
LuaCLS_ShopGoodsInfo = Class()
function LuaCLS_ShopGoodsInfo:ctor()
    self.Id = 0    -- ID
    self.Count = 0    -- 已有数量
    self.AmoutCanBuy = 0    -- 可买数量 -1=无限制
end
function LuaCLS_ShopGoodsInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Count)
    nbs:WriteInt(self.AmoutCanBuy)
    return nbs
end
function LuaCLS_ShopGoodsInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.Count = nbs:ReadInt()
    self.AmoutCanBuy = nbs:ReadInt()
end
-- LuaCLS_ShopGoodsInfo end


-- LuaC2G_Shop_List begin
-- 请求 商城列表
LuaC2G_Shop_List = Class(Base)
function LuaC2G_Shop_List:ctor()
    self._protocol = LuaProtocolId["C2G_SHOP_LIST"]
end
function LuaC2G_Shop_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Shop_List end


-- LuaG2C_Shop_List begin
-- 返回 商城列表
LuaG2C_Shop_List = Class(Base)
function LuaG2C_Shop_List:ctor()
    self._protocol = LuaProtocolId["G2C_SHOP_LIST"]
    self.DictPage = Dictionary:New()    -- 商城页面
    self.RefreshTotal = 0    -- 钻石商城累计刷新次数
    self.RefreshCost = 0    -- 钻石商城当前刷新消耗
end
function LuaG2C_Shop_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3490 = nbs:ReadInt()
    for i = 1, var3490 do
        local var3491 = nbs:ReadInt()
        local var3492 = LuaCLS_ShopPageInfo.new()
        var3492:Unserialize(nbs)
        self.DictPage:Add(var3491, var3492)
    end
    self.RefreshTotal = nbs:ReadInt()
    self.RefreshCost = nbs:ReadInt()
end
-- LuaG2C_Shop_List end


-- LuaC2G_Shop_Buy begin
-- 请求 商城购买
LuaC2G_Shop_Buy = Class(Base)
function LuaC2G_Shop_Buy:ctor()
    self._protocol = LuaProtocolId["C2G_SHOP_BUY"]
    self.Id = 0    -- ID
    self.Amount = 0    -- 购买数量
end
function LuaC2G_Shop_Buy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Amount)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Shop_Buy end


-- LuaG2C_Shop_Buy begin
-- 返回 商城购买
LuaG2C_Shop_Buy = Class(Base)
function LuaG2C_Shop_Buy:ctor()
    self._protocol = LuaProtocolId["G2C_SHOP_BUY"]
    self.DictPage = Dictionary:New()    -- 商城页面
end
function LuaG2C_Shop_Buy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3495 = nbs:ReadInt()
    for i = 1, var3495 do
        local var3496 = nbs:ReadInt()
        local var3497 = LuaCLS_ShopPageInfo.new()
        var3497:Unserialize(nbs)
        self.DictPage:Add(var3496, var3497)
    end
end
-- LuaG2C_Shop_Buy end


-- LuaC2G_Shop_QuickBuy begin
-- 请求 商城快捷购买
LuaC2G_Shop_QuickBuy = Class(Base)
function LuaC2G_Shop_QuickBuy:ctor()
    self._protocol = LuaProtocolId["C2G_SHOP_QUICKBUY"]
    self.Id = 0    -- ID
    self.Amount = 0    -- 购买数量
end
function LuaC2G_Shop_QuickBuy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteInt(self.Amount)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Shop_QuickBuy end


-- LuaG2C_Shop_QuickBuy begin
-- 返回 商城快捷购买
LuaG2C_Shop_QuickBuy = Class(Base)
function LuaG2C_Shop_QuickBuy:ctor()
    self._protocol = LuaProtocolId["G2C_SHOP_QUICKBUY"]
    self.Id = 0    -- ID
end
function LuaG2C_Shop_QuickBuy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
end
-- LuaG2C_Shop_QuickBuy end


-- LuaC2G_Refresh_Diamond_Store begin
-- 请求 刷新钻石商城
LuaC2G_Refresh_Diamond_Store = Class(Base)
function LuaC2G_Refresh_Diamond_Store:ctor()
    self._protocol = LuaProtocolId["C2G_REFRESH_DIAMOND_STORE"]
end
function LuaC2G_Refresh_Diamond_Store:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Refresh_Diamond_Store end


-- LuaG2C_Refresh_Diamond_Store begin
-- 返回 刷新钻石商城
LuaG2C_Refresh_Diamond_Store = Class(Base)
function LuaG2C_Refresh_Diamond_Store:ctor()
    self._protocol = LuaProtocolId["G2C_REFRESH_DIAMOND_STORE"]
    self.RefreshTotal = 0    -- 累计刷新次数
    self.RefreshCost = 0    -- 当前刷新消耗
    self.DictPage = Dictionary:New()    -- 商城页面
end
function LuaG2C_Refresh_Diamond_Store:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.RefreshTotal = nbs:ReadInt()
    self.RefreshCost = nbs:ReadInt()
    local var3501 = nbs:ReadInt()
    for i = 1, var3501 do
        local var3502 = nbs:ReadInt()
        local var3503 = LuaCLS_ShopPageInfo.new()
        var3503:Unserialize(nbs)
        self.DictPage:Add(var3502, var3503)
    end
end
-- LuaG2C_Refresh_Diamond_Store end


-- LuaC2G_Shop_BuyWarriorBag begin
-- 请求 商城购买武将背包上限
LuaC2G_Shop_BuyWarriorBag = Class(Base)
function LuaC2G_Shop_BuyWarriorBag:ctor()
    self._protocol = LuaProtocolId["C2G_SHOP_BUYWARRIORBAG"]
    self.Id = 0    -- ID
end
function LuaC2G_Shop_BuyWarriorBag:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Shop_BuyWarriorBag end


-- LuaG2C_Shop_BuyWarriorBag begin
-- 返回 商城购买武将背包上限
LuaG2C_Shop_BuyWarriorBag = Class(Base)
function LuaG2C_Shop_BuyWarriorBag:ctor()
    self._protocol = LuaProtocolId["G2C_SHOP_BUYWARRIORBAG"]
    self.Id = 0    -- ID
end
function LuaG2C_Shop_BuyWarriorBag:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
end
-- LuaG2C_Shop_BuyWarriorBag end


-- LuaC2G_Buy_Gold begin
-- 请求 金币兑换
LuaC2G_Buy_Gold = Class(Base)
function LuaC2G_Buy_Gold:ctor()
    self._protocol = LuaProtocolId["C2G_BUY_GOLD"]
    self.times = 0
end
function LuaC2G_Buy_Gold:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.times)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Buy_Gold end


-- LuaG2C_Buy_Gold begin
-- 返回
LuaG2C_Buy_Gold = Class(Base)
function LuaG2C_Buy_Gold:ctor()
    self._protocol = LuaProtocolId["G2C_BUY_GOLD"]
    self.addGold = 0    -- 增加的金币
    self.useGem = 0    -- 消耗的元宝
end
function LuaG2C_Buy_Gold:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.addGold = nbs:ReadInt()
    self.useGem = nbs:ReadInt()
end
-- LuaG2C_Buy_Gold end


-- LuaCLS_DesignInfo begin
-- 单子信息
LuaCLS_DesignInfo = Class()
function LuaCLS_DesignInfo:ctor()
    self.Id = 0    -- 单号 唯一ID
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.Puid = 0    -- 挂单玩家唯一ID
    self.Name = ""    -- 挂单玩家名字
    self.Price = 0    -- 单手价格(每手100)
    self.Count = 0    -- 挂单数量
end
function LuaCLS_DesignInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteLong(self.Price)
    nbs:WriteLong(self.Count)
    nbs:WriteDateTime(self.DtExpire)
    nbs:WriteTimeSpan(self.TsRemainder)
    return nbs
end
function LuaCLS_DesignInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.DesignMode = nbs:ReadInt()
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.Price = nbs:ReadLong()
    self.Count = nbs:ReadLong()
    self.DtExpire = nbs:ReadDateTime()
    self.TsRemainder = nbs:ReadTimeSpan()
end
-- LuaCLS_DesignInfo end


-- LuaCLS_TransactionInfo begin
-- 上次交易信息
LuaCLS_TransactionInfo = Class()
function LuaCLS_TransactionInfo:ctor()
    self.Price = 0    -- 成交单价(每手100)
end
function LuaCLS_TransactionInfo:Serialize(nbs)
    nbs:WriteLong(self.Price)
    nbs:WriteDateTime(self.DtTransaction)
    return nbs
end
function LuaCLS_TransactionInfo:Unserialize(nbs)
    self.Price = nbs:ReadLong()
    self.DtTransaction = nbs:ReadDateTime()
end
-- LuaCLS_TransactionInfo end


-- LuaC2G_Exchange_List begin
-- 请求 挂单列表
LuaC2G_Exchange_List = Class(Base)
function LuaC2G_Exchange_List:ctor()
    self._protocol = LuaProtocolId["C2G_EXCHANGE_LIST"]
    self.DesignFlag = 0    -- 交易类型 对应EDesignFlag
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.PageIndex = 0    -- 页码1-n
end
function LuaC2G_Exchange_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DesignFlag)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteInt(self.PageIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Exchange_List end


-- LuaG2C_Exchange_List begin
-- 返回 挂单列表
LuaG2C_Exchange_List = Class(Base)
function LuaG2C_Exchange_List:ctor()
    self._protocol = LuaProtocolId["G2C_EXCHANGE_LIST"]
    self.DesignFlag = 0    -- 交易类型 对应EDesignFlag
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.PageIndex = 0    -- 页码1-n
    self.DesignCount = 0    -- 单子总数目
    self.ListDesign = List:New(LuaCLS_DesignInfo)    -- 挂单列表
    self.TransactionInfo = LuaCLS_TransactionInfo.new()    -- 上次交易信息(Price=0时未发生交易)
end
function LuaG2C_Exchange_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DesignFlag = nbs:ReadInt()
    self.DesignMode = nbs:ReadInt()
    self.PageIndex = nbs:ReadInt()
    self.DesignCount = nbs:ReadInt()
    local var3521 = nbs:ReadInt()
    for i = 1, var3521 do
        local var3522 = LuaCLS_DesignInfo.new()
        var3522:Unserialize(nbs)
        self.ListDesign:Add(var3522)
    end
    self.TransactionInfo:Unserialize(nbs)
end
-- LuaG2C_Exchange_List end


-- LuaC2G_Exchange_Shelves begin
-- 请求 挂单买卖
LuaC2G_Exchange_Shelves = Class(Base)
function LuaC2G_Exchange_Shelves:ctor()
    self._protocol = LuaProtocolId["C2G_EXCHANGE_SHELVES"]
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.Price = 0    -- 单手价格(每手100)
    self.Count = 0    -- 挂单数量
end
function LuaC2G_Exchange_Shelves:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteLong(self.Price)
    nbs:WriteLong(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Exchange_Shelves end


-- LuaG2C_Exchange_Shelves begin
-- 返回 挂单买卖
LuaG2C_Exchange_Shelves = Class(Base)
function LuaG2C_Exchange_Shelves:ctor()
    self._protocol = LuaProtocolId["G2C_EXCHANGE_SHELVES"]
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.DesignInfo = LuaCLS_DesignInfo.new()    -- 更新单子信息
end
function LuaG2C_Exchange_Shelves:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DesignMode = nbs:ReadInt()
    self.DesignInfo:Unserialize(nbs)
end
-- LuaG2C_Exchange_Shelves end


-- LuaC2G_Exchange_Revoke begin
-- 请求 挂单撤销
LuaC2G_Exchange_Revoke = Class(Base)
function LuaC2G_Exchange_Revoke:ctor()
    self._protocol = LuaProtocolId["C2G_EXCHANGE_REVOKE"]
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Exchange_Revoke:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Exchange_Revoke end


-- LuaG2C_Exchange_Revoke begin
-- 返回 挂单撤销
LuaG2C_Exchange_Revoke = Class(Base)
function LuaG2C_Exchange_Revoke:ctor()
    self._protocol = LuaProtocolId["G2C_EXCHANGE_REVOKE"]
end
function LuaG2C_Exchange_Revoke:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Exchange_Revoke end


-- LuaC2G_Exchange_Transaction begin
-- 请求 交易买卖
LuaC2G_Exchange_Transaction = Class(Base)
function LuaC2G_Exchange_Transaction:ctor()
    self._protocol = LuaProtocolId["C2G_EXCHANGE_TRANSACTION"]
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.Id = 0    -- 单号 唯一ID
    self.Count = 0    -- 交易数量
end
function LuaC2G_Exchange_Transaction:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteLong(self.Id)
    nbs:WriteLong(self.Count)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Exchange_Transaction end


-- LuaG2C_Exchange_Transaction begin
-- 返回 交易买卖
LuaG2C_Exchange_Transaction = Class(Base)
function LuaG2C_Exchange_Transaction:ctor()
    self._protocol = LuaProtocolId["G2C_EXCHANGE_TRANSACTION"]
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.DesignInfo = LuaCLS_DesignInfo.new()    -- 更新单子信息
end
function LuaG2C_Exchange_Transaction:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DesignMode = nbs:ReadInt()
    self.DesignInfo:Unserialize(nbs)
end
-- LuaG2C_Exchange_Transaction end


-- LuaCLS_TransactionLog begin
--  交易信息
LuaCLS_TransactionLog = Class()
function LuaCLS_TransactionLog:ctor()
    self.DesignMode = 0    -- 交易方式 对应EDesignMode
    self.MoneyType = 0    -- 货币类型
    self.Price = 0    -- 交易单价
    self.Count = 0    -- 交易数量
end
function LuaCLS_TransactionLog:Serialize(nbs)
    nbs:WriteInt(self.DesignMode)
    nbs:WriteInt(self.MoneyType)
    nbs:WriteLong(self.Price)
    nbs:WriteLong(self.Count)
    return nbs
end
function LuaCLS_TransactionLog:Unserialize(nbs)
    self.DesignMode = nbs:ReadInt()
    self.MoneyType = nbs:ReadInt()
    self.Price = nbs:ReadLong()
    self.Count = nbs:ReadLong()
end
-- LuaCLS_TransactionLog end


-- LuaC2G_GetTransactionLogList begin
-- 请求 交易记录
LuaC2G_GetTransactionLogList = Class(Base)
function LuaC2G_GetTransactionLogList:ctor()
    self._protocol = LuaProtocolId["C2G_GETTRANSACTIONLOGLIST"]
    self.Type = 0    -- 查询类型（1:购买记录;2:出售记录）
end
function LuaC2G_GetTransactionLogList:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GetTransactionLogList end


-- LuaG2C_GetTransactionLogList begin
-- 返回 交易记录
LuaG2C_GetTransactionLogList = Class(Base)
function LuaG2C_GetTransactionLogList:ctor()
    self._protocol = LuaProtocolId["G2C_GETTRANSACTIONLOGLIST"]
    self.Type = 0    -- 查询类型（1:购买记录;2:出售记录）
    self.ListTransactionLog = List:New(LuaCLS_TransactionLog)    -- 交易记录
end
function LuaG2C_GetTransactionLogList:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Type = nbs:ReadInt()
    local var3533 = nbs:ReadInt()
    for i = 1, var3533 do
        local var3534 = LuaCLS_TransactionLog.new()
        var3534:Unserialize(nbs)
        self.ListTransactionLog:Add(var3534)
    end
end
-- LuaG2C_GetTransactionLogList end


-- LuaCLS_AuctionInfoBase begin
-- 商会单子信息 基础
LuaCLS_AuctionInfoBase = Class()
function LuaCLS_AuctionInfoBase:ctor()
    self.Id = 0    -- 单号 唯一ID
    self.Puid = 0    -- 挂单玩家唯一ID
    self.Name = ""    -- 挂单玩家名字
    self.Price = 0    -- 价格(单位：分)
end
function LuaCLS_AuctionInfoBase:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteLong(self.Price)
    nbs:WriteDateTime(self.DtExpire)
    nbs:WriteTimeSpan(self.TsRemainder)
    return nbs
end
function LuaCLS_AuctionInfoBase:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.Price = nbs:ReadLong()
    self.DtExpire = nbs:ReadDateTime()
    self.TsRemainder = nbs:ReadTimeSpan()
end
-- LuaCLS_AuctionInfoBase end


-- LuaCLS_AuctionInfoItem begin
-- 商会单子信息 道具
LuaCLS_AuctionInfoItem = Class()
function LuaCLS_AuctionInfoItem:ctor()
    self.AuctionInfoBase = LuaCLS_AuctionInfoBase.new()    -- 基础信息
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 道具信息
end
function LuaCLS_AuctionInfoItem:Serialize(nbs)
    AuctionInfoBase:Serialize(nbs)
    ItemInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_AuctionInfoItem:Unserialize(nbs)
    self.AuctionInfoBase:Unserialize(nbs)
    self.ItemInfo:Unserialize(nbs)
end
-- LuaCLS_AuctionInfoItem end


-- LuaC2G_Auction_ListItem begin
-- 请求 商会列表 道具
LuaC2G_Auction_ListItem = Class(Base)
function LuaC2G_Auction_ListItem:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_LISTITEM"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
end
function LuaC2G_Auction_ListItem:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Order)
    nbs:WriteInt(self.AuctionFlag)
    nbs:WriteInt(self.SubType)
    nbs:WriteInt(self.PageIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ListItem end


-- LuaG2C_Auction_ListItem begin
-- 返回 商会列表 道具
LuaG2C_Auction_ListItem = Class(Base)
function LuaG2C_Auction_ListItem:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_LISTITEM"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
    self.TotalCount = 0    -- 总数目
    self.DictItem = Dictionary:New()    -- 列表
end
function LuaG2C_Auction_ListItem:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Order = nbs:ReadInt()
    self.AuctionFlag = nbs:ReadInt()
    self.SubType = nbs:ReadInt()
    self.PageIndex = nbs:ReadInt()
    self.TotalCount = nbs:ReadInt()
    local var3548 = nbs:ReadInt()
    for i = 1, var3548 do
        local var3549 = nbs:ReadLong()
        local var3550 = LuaCLS_AuctionInfoItem.new()
        var3550:Unserialize(nbs)
        self.DictItem:Add(var3549, var3550)
    end
end
-- LuaG2C_Auction_ListItem end


-- LuaC2G_Auction_SellItem begin
-- 请求 商会出售 道具
LuaC2G_Auction_SellItem = Class(Base)
function LuaC2G_Auction_SellItem:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_SELLITEM"]
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 道具信息
    self.Price = 0    -- 出售单价(单位：分)
end
function LuaC2G_Auction_SellItem:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    ItemInfo:Serialize(nbs)
    nbs:WriteLong(self.Price)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_SellItem end


-- LuaG2C_Auction_SellItem begin
-- 返回 商会出售 道具
LuaG2C_Auction_SellItem = Class(Base)
function LuaG2C_Auction_SellItem:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_SELLITEM"]
    self.AuctionInfoItem = LuaCLS_AuctionInfoItem.new()    -- 商会单子信息
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 刷新道具信息
end
function LuaG2C_Auction_SellItem:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AuctionInfoItem:Unserialize(nbs)
    self.ItemInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_SellItem end


-- LuaC2G_Auction_ReturnItem begin
-- 请求 商会撤卖 道具
LuaC2G_Auction_ReturnItem = Class(Base)
function LuaC2G_Auction_ReturnItem:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_RETURNITEM"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_ReturnItem:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ReturnItem end


-- LuaG2C_Auction_ReturnItem begin
-- 返回 商会撤卖 道具
LuaG2C_Auction_ReturnItem = Class(Base)
function LuaG2C_Auction_ReturnItem:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_RETURNITEM"]
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 刷新道具信息
end
function LuaG2C_Auction_ReturnItem:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ItemInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_ReturnItem end


-- LuaC2G_Auction_BuyItem begin
-- 请求 商会买入 道具
LuaC2G_Auction_BuyItem = Class(Base)
function LuaC2G_Auction_BuyItem:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_BUYITEM"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_BuyItem:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_BuyItem end


-- LuaG2C_Auction_BuyItem begin
-- 返回 商会买入 道具
LuaG2C_Auction_BuyItem = Class(Base)
function LuaG2C_Auction_BuyItem:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_BUYITEM"]
    self.ItemInfo = LuaCLS_ItemInfo.new()    -- 刷新道具信息
end
function LuaG2C_Auction_BuyItem:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ItemInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_BuyItem end


-- LuaCLS_AuctionInfoEquip begin
-- 商会单子信息 装备
LuaCLS_AuctionInfoEquip = Class()
function LuaCLS_AuctionInfoEquip:ctor()
    self.AuctionInfoBase = LuaCLS_AuctionInfoBase.new()    -- 基础信息
    self.EquipInfo = LuaCLS_EquipInfo.new()    -- 装备信息
end
function LuaCLS_AuctionInfoEquip:Serialize(nbs)
    AuctionInfoBase:Serialize(nbs)
    EquipInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_AuctionInfoEquip:Unserialize(nbs)
    self.AuctionInfoBase:Unserialize(nbs)
    self.EquipInfo:Unserialize(nbs)
end
-- LuaCLS_AuctionInfoEquip end


-- LuaC2G_Auction_ListEquip begin
-- 请求 商会列表 装备
LuaC2G_Auction_ListEquip = Class(Base)
function LuaC2G_Auction_ListEquip:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_LISTEQUIP"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
end
function LuaC2G_Auction_ListEquip:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Order)
    nbs:WriteInt(self.AuctionFlag)
    nbs:WriteInt(self.SubType)
    nbs:WriteInt(self.PageIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ListEquip end


-- LuaG2C_Auction_ListEquip begin
-- 返回 商会列表 装备
LuaG2C_Auction_ListEquip = Class(Base)
function LuaG2C_Auction_ListEquip:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_LISTEQUIP"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
    self.TotalCount = 0    -- 总数目
    self.DictEquip = Dictionary:New()    -- 列表
end
function LuaG2C_Auction_ListEquip:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Order = nbs:ReadInt()
    self.AuctionFlag = nbs:ReadInt()
    self.SubType = nbs:ReadInt()
    self.PageIndex = nbs:ReadInt()
    self.TotalCount = nbs:ReadInt()
    local var3562 = nbs:ReadInt()
    for i = 1, var3562 do
        local var3563 = nbs:ReadLong()
        local var3564 = LuaCLS_AuctionInfoEquip.new()
        var3564:Unserialize(nbs)
        self.DictEquip:Add(var3563, var3564)
    end
end
-- LuaG2C_Auction_ListEquip end


-- LuaC2G_Auction_SellEquip begin
-- 请求 商会出售 装备
LuaC2G_Auction_SellEquip = Class(Base)
function LuaC2G_Auction_SellEquip:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_SELLEQUIP"]
    self.EquipId = 0    -- 装备唯一ID
    self.Price = 0    -- 出售单价(单位：分)
end
function LuaC2G_Auction_SellEquip:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.EquipId)
    nbs:WriteLong(self.Price)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_SellEquip end


-- LuaG2C_Auction_SellEquip begin
-- 返回 商会出售 装备
LuaG2C_Auction_SellEquip = Class(Base)
function LuaG2C_Auction_SellEquip:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_SELLEQUIP"]
    self.AuctionInfoEquip = LuaCLS_AuctionInfoEquip.new()    -- 商会单子信息
end
function LuaG2C_Auction_SellEquip:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AuctionInfoEquip:Unserialize(nbs)
end
-- LuaG2C_Auction_SellEquip end


-- LuaC2G_Auction_ReturnEquip begin
-- 请求 商会撤卖 装备
LuaC2G_Auction_ReturnEquip = Class(Base)
function LuaC2G_Auction_ReturnEquip:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_RETURNEQUIP"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_ReturnEquip:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ReturnEquip end


-- LuaG2C_Auction_ReturnEquip begin
-- 返回 商会撤卖 装备
LuaG2C_Auction_ReturnEquip = Class(Base)
function LuaG2C_Auction_ReturnEquip:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_RETURNEQUIP"]
    self.EquipInfo = LuaCLS_EquipInfo.new()    -- 刷新装备信息
end
function LuaG2C_Auction_ReturnEquip:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.EquipInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_ReturnEquip end


-- LuaC2G_Auction_BuyEquip begin
-- 请求 商会买入 装备
LuaC2G_Auction_BuyEquip = Class(Base)
function LuaC2G_Auction_BuyEquip:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_BUYEQUIP"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_BuyEquip:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_BuyEquip end


-- LuaG2C_Auction_BuyEquip begin
-- 返回 商会买入 装备
LuaG2C_Auction_BuyEquip = Class(Base)
function LuaG2C_Auction_BuyEquip:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_BUYEQUIP"]
    self.EquipInfo = LuaCLS_EquipInfo.new()    -- 刷新装备信息
end
function LuaG2C_Auction_BuyEquip:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.EquipInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_BuyEquip end


-- LuaCLS_AuctionInfoWarrior begin
-- 商会单子信息 武将
LuaCLS_AuctionInfoWarrior = Class()
function LuaCLS_AuctionInfoWarrior:ctor()
    self.AuctionInfoBase = LuaCLS_AuctionInfoBase.new()    -- 基础信息
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将信息
end
function LuaCLS_AuctionInfoWarrior:Serialize(nbs)
    AuctionInfoBase:Serialize(nbs)
    WarriorInfo:Serialize(nbs)
    return nbs
end
function LuaCLS_AuctionInfoWarrior:Unserialize(nbs)
    self.AuctionInfoBase:Unserialize(nbs)
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaCLS_AuctionInfoWarrior end


-- LuaC2G_Auction_ListWarrior begin
-- 请求 商会列表 武将
LuaC2G_Auction_ListWarrior = Class(Base)
function LuaC2G_Auction_ListWarrior:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_LISTWARRIOR"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
end
function LuaC2G_Auction_ListWarrior:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Order)
    nbs:WriteInt(self.AuctionFlag)
    nbs:WriteInt(self.SubType)
    nbs:WriteInt(self.PageIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ListWarrior end


-- LuaG2C_Auction_ListWarrior begin
-- 返回 商会列表 武将
LuaG2C_Auction_ListWarrior = Class(Base)
function LuaG2C_Auction_ListWarrior:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_LISTWARRIOR"]
    self.Order = 0    -- 排序类型 对应EOrder
    self.AuctionFlag = 0    -- 交易类型 对应EAuctionFlag
    self.SubType = 0    -- 子类ID
    self.PageIndex = 0    -- 页码1-n (返回每页100条)
    self.TotalCount = 0    -- 总数目
    self.DictWarrior = Dictionary:New()    -- 列表
end
function LuaG2C_Auction_ListWarrior:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Order = nbs:ReadInt()
    self.AuctionFlag = nbs:ReadInt()
    self.SubType = nbs:ReadInt()
    self.PageIndex = nbs:ReadInt()
    self.TotalCount = nbs:ReadInt()
    local var3575 = nbs:ReadInt()
    for i = 1, var3575 do
        local var3576 = nbs:ReadLong()
        local var3577 = LuaCLS_AuctionInfoWarrior.new()
        var3577:Unserialize(nbs)
        self.DictWarrior:Add(var3576, var3577)
    end
end
-- LuaG2C_Auction_ListWarrior end


-- LuaC2G_Auction_SellWarrior begin
-- 请求 商会出售 武将
LuaC2G_Auction_SellWarrior = Class(Base)
function LuaC2G_Auction_SellWarrior:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_SELLWARRIOR"]
    self.WarriorId = 0    -- 武将唯一ID
    self.Price = 0    -- 出售单价(单位：分)
end
function LuaC2G_Auction_SellWarrior:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.WarriorId)
    nbs:WriteLong(self.Price)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_SellWarrior end


-- LuaG2C_Auction_SellWarrior begin
-- 返回 商会出售 武将
LuaG2C_Auction_SellWarrior = Class(Base)
function LuaG2C_Auction_SellWarrior:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_SELLWARRIOR"]
    self.AuctionInfoWarrior = LuaCLS_AuctionInfoWarrior.new()    -- 商会单子信息
end
function LuaG2C_Auction_SellWarrior:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AuctionInfoWarrior:Unserialize(nbs)
end
-- LuaG2C_Auction_SellWarrior end


-- LuaC2G_Auction_ReturnWarrior begin
-- 请求 商会撤卖 武将
LuaC2G_Auction_ReturnWarrior = Class(Base)
function LuaC2G_Auction_ReturnWarrior:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_RETURNWARRIOR"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_ReturnWarrior:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_ReturnWarrior end


-- LuaG2C_Auction_ReturnWarrior begin
-- 返回 商会撤卖 武将
LuaG2C_Auction_ReturnWarrior = Class(Base)
function LuaG2C_Auction_ReturnWarrior:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_RETURNWARRIOR"]
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 刷新武将信息
end
function LuaG2C_Auction_ReturnWarrior:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_ReturnWarrior end


-- LuaC2G_Auction_BuyWarrior begin
-- 请求 商会买入 武将
LuaC2G_Auction_BuyWarrior = Class(Base)
function LuaC2G_Auction_BuyWarrior:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_BUYWARRIOR"]
    self.Id = 0    -- 单号 唯一ID
end
function LuaC2G_Auction_BuyWarrior:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_BuyWarrior end


-- LuaG2C_Auction_BuyWarrior begin
-- 返回 商会买入 武将
LuaG2C_Auction_BuyWarrior = Class(Base)
function LuaG2C_Auction_BuyWarrior:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_BUYWARRIOR"]
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 刷新武将信息
end
function LuaG2C_Auction_BuyWarrior:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.WarriorInfo:Unserialize(nbs)
end
-- LuaG2C_Auction_BuyWarrior end


-- LuaC2G_Auction_Search begin
-- 请求 商会搜索
LuaC2G_Auction_Search = Class(Base)
function LuaC2G_Auction_Search:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_SEARCH"]
    self.SearchKey = ""    -- 搜索关键字
end
function LuaC2G_Auction_Search:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.SearchKey)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_Search end


-- LuaG2C_Auction_Search begin
-- 返回 商会搜索
LuaG2C_Auction_Search = Class(Base)
function LuaG2C_Auction_Search:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_SEARCH"]
    self.DictItem = Dictionary:New()    -- 列表
    self.DictEquip = Dictionary:New()    -- 列表
    self.DictWarrior = Dictionary:New()    -- 列表
end
function LuaG2C_Auction_Search:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3581 = nbs:ReadInt()
    for i = 1, var3581 do
        local var3582 = nbs:ReadLong()
        local var3583 = LuaCLS_AuctionInfoItem.new()
        var3583:Unserialize(nbs)
        self.DictItem:Add(var3582, var3583)
    end
    local var3584 = nbs:ReadInt()
    for i = 1, var3584 do
        local var3585 = nbs:ReadLong()
        local var3586 = LuaCLS_AuctionInfoEquip.new()
        var3586:Unserialize(nbs)
        self.DictEquip:Add(var3585, var3586)
    end
    local var3587 = nbs:ReadInt()
    for i = 1, var3587 do
        local var3588 = nbs:ReadLong()
        local var3589 = LuaCLS_AuctionInfoWarrior.new()
        var3589:Unserialize(nbs)
        self.DictWarrior:Add(var3588, var3589)
    end
end
-- LuaG2C_Auction_Search end


-- LuaCLS_AuctionLog begin
-- 商会交易记录
LuaCLS_AuctionLog = Class()
function LuaCLS_AuctionLog:ctor()
    self.AuctionLogItemType = 0    -- 大类 见EAuctionLogItemType
    self.ConfigId = 0    -- 配置ID
    self.Count = 0    -- 数量
    self.PlayerName = ""    -- 交易对象名字
    self.Price = 0    -- 价格(单位：分)
end
function LuaCLS_AuctionLog:Serialize(nbs)
    nbs:WriteShort(self.AuctionLogItemType)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteInt(self.Count)
    nbs:WriteString(self.PlayerName)
    nbs:WriteLong(self.Price)
    return nbs
end
function LuaCLS_AuctionLog:Unserialize(nbs)
    self.AuctionLogItemType = nbs:ReadShort()
    self.ConfigId = nbs:ReadInt()
    self.Count = nbs:ReadInt()
    self.PlayerName = nbs:ReadString()
    self.Price = nbs:ReadLong()
end
-- LuaCLS_AuctionLog end


-- LuaC2G_Auction_GetLog begin
-- 请求 商会交易记录
LuaC2G_Auction_GetLog = Class(Base)
function LuaC2G_Auction_GetLog:ctor()
    self._protocol = LuaProtocolId["C2G_AUCTION_GETLOG"]
    self.AuctionLogType = 0    -- 查询类型 EAuctionLogType
end
function LuaC2G_Auction_GetLog:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.AuctionLogType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Auction_GetLog end


-- LuaG2C_Auction_GetLog begin
-- 返回 商会交易记录
LuaG2C_Auction_GetLog = Class(Base)
function LuaG2C_Auction_GetLog:ctor()
    self._protocol = LuaProtocolId["G2C_AUCTION_GETLOG"]
    self.AuctionLogType = 0    -- 查询类型 EAuctionLogType
    self.ListAuctionLog = List:New(LuaCLS_AuctionLog)    -- 交易记录
end
function LuaG2C_Auction_GetLog:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AuctionLogType = nbs:ReadInt()
    local var3596 = nbs:ReadInt()
    for i = 1, var3596 do
        local var3597 = LuaCLS_AuctionLog.new()
        var3597:Unserialize(nbs)
        self.ListAuctionLog:Add(var3597)
    end
end
-- LuaG2C_Auction_GetLog end


-- LuaC2G_Draw_GetInfo begin
-- 请求 宴会厅数据
LuaC2G_Draw_GetInfo = Class(Base)
function LuaC2G_Draw_GetInfo:ctor()
    self._protocol = LuaProtocolId["C2G_DRAW_GETINFO"]
end
function LuaC2G_Draw_GetInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Draw_GetInfo end


-- LuaG2C_Draw_GetInfo begin
-- 返回 宴会厅数据
LuaG2C_Draw_GetInfo = Class(Base)
function LuaG2C_Draw_GetInfo:ctor()
    self._protocol = LuaProtocolId["G2C_DRAW_GETINFO"]
    self.DrawScore = 0    -- 奖励积分
end
function LuaG2C_Draw_GetInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DrawScore = nbs:ReadInt()
end
-- LuaG2C_Draw_GetInfo end


-- LuaC2G_Draw_Luck begin
-- 请求 宴会厅抽奖
LuaC2G_Draw_Luck = Class(Base)
function LuaC2G_Draw_Luck:ctor()
    self._protocol = LuaProtocolId["C2G_DRAW_LUCK"]
    self.DrawPoolId = 0    -- (配置ID)
    self.DrawType = 0    -- (EDrawType)
end
function LuaC2G_Draw_Luck:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DrawPoolId)
    nbs:WriteInt(self.DrawType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Draw_Luck end


-- LuaG2C_Draw_Luck begin
-- 返回 宴会厅抽奖
LuaG2C_Draw_Luck = Class(Base)
function LuaG2C_Draw_Luck:ctor()
    self._protocol = LuaProtocolId["G2C_DRAW_LUCK"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Draw_Luck:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3599 = nbs:ReadInt()
    for i = 1, var3599 do
        local var3600 = LuaCLS_AwardItem.new()
        var3600:Unserialize(nbs)
        self.ListAward:Add(var3600)
    end
end
-- LuaG2C_Draw_Luck end


-- LuaC2G_Draw_GetAward begin
-- 请求 宴会厅奖励
LuaC2G_Draw_GetAward = Class(Base)
function LuaC2G_Draw_GetAward:ctor()
    self._protocol = LuaProtocolId["C2G_DRAW_GETAWARD"]
end
function LuaC2G_Draw_GetAward:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Draw_GetAward end


-- LuaG2C_Draw_GetAward begin
-- 返回 宴会厅奖励
LuaG2C_Draw_GetAward = Class(Base)
function LuaG2C_Draw_GetAward:ctor()
    self._protocol = LuaProtocolId["G2C_DRAW_GETAWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Draw_GetAward:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3601 = nbs:ReadInt()
    for i = 1, var3601 do
        local var3602 = LuaCLS_AwardItem.new()
        var3602:Unserialize(nbs)
        self.ListAward:Add(var3602)
    end
end
-- LuaG2C_Draw_GetAward end


-- LuaC2G_Cdkey_Use begin
-- 请求 使用兑换码
LuaC2G_Cdkey_Use = Class(Base)
function LuaC2G_Cdkey_Use:ctor()
    self._protocol = LuaProtocolId["C2G_CDKEY_USE"]
    self.Cdkey = ""    -- 兑换码
end
function LuaC2G_Cdkey_Use:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Cdkey)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Cdkey_Use end


-- LuaG2C_Cdkey_Use begin
-- 返回 使用兑换码
LuaG2C_Cdkey_Use = Class(Base)
function LuaG2C_Cdkey_Use:ctor()
    self._protocol = LuaProtocolId["G2C_CDKEY_USE"]
    self.Cdkey = ""    -- 兑换码
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Cdkey_Use:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Cdkey = nbs:ReadString()
    local var3604 = nbs:ReadInt()
    for i = 1, var3604 do
        local var3605 = LuaCLS_AwardItem.new()
        var3605:Unserialize(nbs)
        self.ListAward:Add(var3605)
    end
end
-- LuaG2C_Cdkey_Use end


-- LuaCLS_TopData begin
-- 排行榜单条信息
LuaCLS_TopData = Class()
function LuaCLS_TopData:ctor()
    self.Rank = 0    -- 排行
    self.Puid = 0    -- 唯一ID
    self.Name = ""    -- 名字
    self.Score = 0    -- 分数
    self.Other = ""    -- 存储其他信息，身份或武将名称或道具名称
    self.ConfigId = 0    -- 配置ID
end
function LuaCLS_TopData:Serialize(nbs)
    nbs:WriteInt(self.Rank)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteLong(self.Score)
    nbs:WriteString(self.Other)
    nbs:WriteInt(self.ConfigId)
    return nbs
end
function LuaCLS_TopData:Unserialize(nbs)
    self.Rank = nbs:ReadInt()
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.Score = nbs:ReadLong()
    self.Other = nbs:ReadString()
    self.ConfigId = nbs:ReadInt()
end
-- LuaCLS_TopData end


-- LuaC2G_Top_Toplist begin
-- 请求 排行榜
LuaC2G_Top_Toplist = Class(Base)
function LuaC2G_Top_Toplist:ctor()
    self._protocol = LuaProtocolId["C2G_TOP_TOPLIST"]
    self.type = 0    -- 排行榜类型
    self.PageIndex = 0    -- 页码
end
function LuaC2G_Top_Toplist:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.type)
    nbs:WriteInt(self.PageIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Top_Toplist end


-- LuaG2C_Top_Toplist begin
-- 返回 排行榜
LuaG2C_Top_Toplist = Class(Base)
function LuaG2C_Top_Toplist:ctor()
    self._protocol = LuaProtocolId["G2C_TOP_TOPLIST"]
    self.TopDataList = List:New(LuaCLS_TopData)    -- 排行榜数据
    self.playerTopData = LuaCLS_TopData.new()    -- 玩家数据
    self.type = 0    -- 排行榜类型
end
function LuaG2C_Top_Toplist:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3612 = nbs:ReadInt()
    for i = 1, var3612 do
        local var3613 = LuaCLS_TopData.new()
        var3613:Unserialize(nbs)
        self.TopDataList:Add(var3613)
    end
    self.playerTopData:Unserialize(nbs)
    self.type = nbs:ReadInt()
end
-- LuaG2C_Top_Toplist end


-- LuaC2G_Top_Info begin
-- 请求 排行榜单条具体数据信息
LuaC2G_Top_Info = Class(Base)
function LuaC2G_Top_Info:ctor()
    self._protocol = LuaProtocolId["C2G_TOP_INFO"]
    self.type = 0    -- 排行榜类型
    self.ID = 0    -- 唯一ID
end
function LuaC2G_Top_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.type)
    nbs:WriteLong(self.ID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Top_Info end


-- LuaG2C_Top_Info begin
-- 返回 排行榜单条具体数据信息
LuaG2C_Top_Info = Class(Base)
function LuaG2C_Top_Info:ctor()
    self._protocol = LuaProtocolId["G2C_TOP_INFO"]
    self.type = 0    -- 排行榜类型
    self.EquipInfo = LuaCLS_EquipInfo.new()    -- 装备信息
    self.WarriorInfo = LuaCLS_WarriorInfo.new()    -- 武将信息
    self.PlayerInfo = LuaCLS_PlayerData.new()    -- 主角信息
end
function LuaG2C_Top_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.type = nbs:ReadInt()
    self.EquipInfo:Unserialize(nbs)
    self.WarriorInfo:Unserialize(nbs)
    self.PlayerInfo:Unserialize(nbs)
end
-- LuaG2C_Top_Info end


-- LuaCLS_TaskInfo begin
-- 任务信息
LuaCLS_TaskInfo = Class()
function LuaCLS_TaskInfo:ctor()
    self.Tuid = 0    -- 任务唯一ID(府衙任务用 其他任务和配置ID相同)
    self.Id = 0    -- 任务ID(配置ID)
    self.State = 0    -- 任务状态 对应ETaskState
    self.Schedule = 0    -- 当前进度
    self.ScheduleMax = 0    -- 最大进度
end
function LuaCLS_TaskInfo:Serialize(nbs)
    nbs:WriteLong(self.Tuid)
    nbs:WriteInt(self.Id)
    nbs:WriteByte(self.State)
    nbs:WriteLong(self.Schedule)
    nbs:WriteLong(self.ScheduleMax)
    return nbs
end
function LuaCLS_TaskInfo:Unserialize(nbs)
    self.Tuid = nbs:ReadLong()
    self.Id = nbs:ReadInt()
    self.State = nbs:ReadByte()
    self.Schedule = nbs:ReadLong()
    self.ScheduleMax = nbs:ReadLong()
end
-- LuaCLS_TaskInfo end


-- LuaC2G_Task_List begin
-- 请求 任务列表
LuaC2G_Task_List = Class(Base)
function LuaC2G_Task_List:ctor()
    self._protocol = LuaProtocolId["C2G_TASK_LIST"]
    self.TaskType = 0    -- 任务类型 对应ETaskType
end
function LuaC2G_Task_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteByte(self.TaskType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Task_List end


-- LuaG2C_Task_List begin
-- 返回 任务列表
LuaG2C_Task_List = Class(Base)
function LuaG2C_Task_List:ctor()
    self._protocol = LuaProtocolId["G2C_TASK_LIST"]
    self.TaskType = 0    -- 任务类型 对应ETaskType
    self.ListTask = List:New(LuaCLS_TaskInfo)    -- 任务列表
end
function LuaG2C_Task_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.TaskType = nbs:ReadByte()
    local var3626 = nbs:ReadInt()
    for i = 1, var3626 do
        local var3627 = LuaCLS_TaskInfo.new()
        var3627:Unserialize(nbs)
        self.ListTask:Add(var3627)
    end
end
-- LuaG2C_Task_List end


-- LuaC2G_Task_Get begin
-- 请求 任务领奖
LuaC2G_Task_Get = Class(Base)
function LuaC2G_Task_Get:ctor()
    self._protocol = LuaProtocolId["C2G_TASK_GET"]
    self.TaskType = 0    -- 任务类型 对应ETaskType
    self.Tuid = 0    -- 任务唯一ID(府衙任务用 其他任务和配置ID相同)
end
function LuaC2G_Task_Get:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteByte(self.TaskType)
    nbs:WriteLong(self.Tuid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Task_Get end


-- LuaG2C_Task_Get begin
-- 返回 任务领奖
LuaG2C_Task_Get = Class(Base)
function LuaG2C_Task_Get:ctor()
    self._protocol = LuaProtocolId["G2C_TASK_GET"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Task_Get:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3628 = nbs:ReadInt()
    for i = 1, var3628 do
        local var3629 = LuaCLS_AwardItem.new()
        var3629:Unserialize(nbs)
        self.ListAward:Add(var3629)
    end
end
-- LuaG2C_Task_Get end


-- LuaC2G_Task_GetAll begin
-- 请求 任务领奖一键领取
LuaC2G_Task_GetAll = Class(Base)
function LuaC2G_Task_GetAll:ctor()
    self._protocol = LuaProtocolId["C2G_TASK_GETALL"]
    self.TaskType = 0    -- 任务类型 对应ETaskType
end
function LuaC2G_Task_GetAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteByte(self.TaskType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Task_GetAll end


-- LuaG2C_Task_GetAll begin
-- 返回 任务领奖一键领取
LuaG2C_Task_GetAll = Class(Base)
function LuaG2C_Task_GetAll:ctor()
    self._protocol = LuaProtocolId["G2C_TASK_GETALL"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Task_GetAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3630 = nbs:ReadInt()
    for i = 1, var3630 do
        local var3631 = LuaCLS_AwardItem.new()
        var3631:Unserialize(nbs)
        self.ListAward:Add(var3631)
    end
end
-- LuaG2C_Task_GetAll end


-- LuaC2G_Task_Everyday begin
-- 请求 日常任务
LuaC2G_Task_Everyday = Class(Base)
function LuaC2G_Task_Everyday:ctor()
    self._protocol = LuaProtocolId["C2G_TASK_EVERYDAY"]
end
function LuaC2G_Task_Everyday:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Task_Everyday end


-- LuaG2C_Task_Everyday begin
-- 返回 日常任务
LuaG2C_Task_Everyday = Class(Base)
function LuaG2C_Task_Everyday:ctor()
    self._protocol = LuaProtocolId["G2C_TASK_EVERYDAY"]
    self.ListTask = List:New(LuaCLS_TaskInfo)    -- 任务列表
    self.Activity = 0    -- 活跃值
    self.DictTaskActivity = Dictionary:New()    -- 活跃奖励领取状态(等级ID，ETaskState)
end
function LuaG2C_Task_Everyday:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3632 = nbs:ReadInt()
    for i = 1, var3632 do
        local var3633 = LuaCLS_TaskInfo.new()
        var3633:Unserialize(nbs)
        self.ListTask:Add(var3633)
    end
    self.Activity = nbs:ReadInt()
    local var3635 = nbs:ReadInt()
    for i = 1, var3635 do
        local var3636 = nbs:ReadInt()
        local var3637 = nbs:ReadInt()
        self.DictTaskActivity:Add(var3636, var3637)
    end
end
-- LuaG2C_Task_Everyday end


-- LuaC2G_Task_EverydayAward begin
-- 请求 每日活跃奖励
LuaC2G_Task_EverydayAward = Class(Base)
function LuaC2G_Task_EverydayAward:ctor()
    self._protocol = LuaProtocolId["C2G_TASK_EVERYDAYAWARD"]
    self.ActivityID = 0    -- 活跃ID
end
function LuaC2G_Task_EverydayAward:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.ActivityID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Task_EverydayAward end


-- LuaG2C_Task_EverydayAward begin
-- 返回 每日活跃奖励
LuaG2C_Task_EverydayAward = Class(Base)
function LuaG2C_Task_EverydayAward:ctor()
    self._protocol = LuaProtocolId["G2C_TASK_EVERYDAYAWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Task_EverydayAward:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3638 = nbs:ReadInt()
    for i = 1, var3638 do
        local var3639 = LuaCLS_AwardItem.new()
        var3639:Unserialize(nbs)
        self.ListAward:Add(var3639)
    end
end
-- LuaG2C_Task_EverydayAward end


-- LuaCLS_SignInfo begin
-- 签到信息
LuaCLS_SignInfo = Class()
function LuaCLS_SignInfo:ctor()
    self.IsSigned = false    -- 今天是否已签
    self.SignDays = 0    -- 本轮签到总数
    self.ReSignDays = 0    -- 本轮补签次数
    self.SignIndex = 0    -- 本轮天数索引
    self.AliveTime = 0    -- 剩余秒数
    self.TotalTime = 0    -- 周期秒数
end
function LuaCLS_SignInfo:Serialize(nbs)
    nbs:WriteBool(self.IsSigned)
    nbs:WriteInt(self.SignDays)
    nbs:WriteInt(self.ReSignDays)
    nbs:WriteInt(self.SignIndex)
    nbs:WriteLong(self.AliveTime)
    nbs:WriteLong(self.TotalTime)
    return nbs
end
function LuaCLS_SignInfo:Unserialize(nbs)
    self.IsSigned = nbs:ReadBool()
    self.SignDays = nbs:ReadInt()
    self.ReSignDays = nbs:ReadInt()
    self.SignIndex = nbs:ReadInt()
    self.AliveTime = nbs:ReadLong()
    self.TotalTime = nbs:ReadLong()
end
-- LuaCLS_SignInfo end


-- LuaC2G_Sign_Info begin
-- 请求 获取签到信息
LuaC2G_Sign_Info = Class(Base)
function LuaC2G_Sign_Info:ctor()
    self._protocol = LuaProtocolId["C2G_SIGN_INFO"]
end
function LuaC2G_Sign_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Sign_Info end


-- LuaG2C_Sign_Info begin
-- 返回 获取签到信息
LuaG2C_Sign_Info = Class(Base)
function LuaG2C_Sign_Info:ctor()
    self._protocol = LuaProtocolId["G2C_SIGN_INFO"]
    self.SignInfo = LuaCLS_SignInfo.new()    -- 签到信息
end
function LuaG2C_Sign_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.SignInfo:Unserialize(nbs)
end
-- LuaG2C_Sign_Info end


-- LuaC2G_Sign begin
-- 请求 处理签到
LuaC2G_Sign = Class(Base)
function LuaC2G_Sign:ctor()
    self._protocol = LuaProtocolId["C2G_SIGN"]
end
function LuaC2G_Sign:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Sign end


-- LuaG2C_Sign begin
-- 返回 处理签到
LuaG2C_Sign = Class(Base)
function LuaG2C_Sign:ctor()
    self._protocol = LuaProtocolId["G2C_SIGN"]
    self.SignInfo = LuaCLS_SignInfo.new()    -- 签到信息
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励信息
end
function LuaG2C_Sign:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.SignInfo:Unserialize(nbs)
    local var3648 = nbs:ReadInt()
    for i = 1, var3648 do
        local var3649 = LuaCLS_AwardItem.new()
        var3649:Unserialize(nbs)
        self.ListAward:Add(var3649)
    end
end
-- LuaG2C_Sign end


-- LuaC2G_ReSign begin
-- 请求 处理补签
LuaC2G_ReSign = Class(Base)
function LuaC2G_ReSign:ctor()
    self._protocol = LuaProtocolId["C2G_RESIGN"]
end
function LuaC2G_ReSign:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ReSign end


-- LuaG2C_ReSign begin
-- 返回 处理补签
LuaG2C_ReSign = Class(Base)
function LuaG2C_ReSign:ctor()
    self._protocol = LuaProtocolId["G2C_RESIGN"]
    self.SignInfo = LuaCLS_SignInfo.new()    -- 签到信息
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励信息
end
function LuaG2C_ReSign:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.SignInfo:Unserialize(nbs)
    local var3651 = nbs:ReadInt()
    for i = 1, var3651 do
        local var3652 = LuaCLS_AwardItem.new()
        var3652:Unserialize(nbs)
        self.ListAward:Add(var3652)
    end
end
-- LuaG2C_ReSign end


-- LuaCLS_BuffInfo begin
-- BUFF信息
LuaCLS_BuffInfo = Class()
function LuaCLS_BuffInfo:ctor()
    self.Id = 0    -- 配置ID
    self.AliveTime = 0    -- 剩余秒数(-1:永久有效)
end
function LuaCLS_BuffInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteLong(self.AliveTime)
    return nbs
end
function LuaCLS_BuffInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.AliveTime = nbs:ReadLong()
end
-- LuaCLS_BuffInfo end


-- LuaC2G_Buff_Info begin
-- 请求 获取BUFF信息
LuaC2G_Buff_Info = Class(Base)
function LuaC2G_Buff_Info:ctor()
    self._protocol = LuaProtocolId["C2G_BUFF_INFO"]
end
function LuaC2G_Buff_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Buff_Info end


-- LuaG2C_Buff_Info begin
-- 返回 获取BUFF信息
LuaG2C_Buff_Info = Class(Base)
function LuaG2C_Buff_Info:ctor()
    self._protocol = LuaProtocolId["G2C_BUFF_INFO"]
    self.Info = List:New(LuaCLS_BuffInfo)    -- BUFF信息
end
function LuaG2C_Buff_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3655 = nbs:ReadInt()
    for i = 1, var3655 do
        local var3656 = LuaCLS_BuffInfo.new()
        var3656:Unserialize(nbs)
        self.Info:Add(var3656)
    end
end
-- LuaG2C_Buff_Info end


-- LuaCLS_AcitvityInfo begin
-- 城池信息
LuaCLS_AcitvityInfo = Class()
function LuaCLS_AcitvityInfo:ctor()
    self.Id = 0    -- 活动ID(配置ID)
    self.IsOpen = false    -- 是否开启
end
function LuaCLS_AcitvityInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteBool(self.IsOpen)
    nbs:WriteDateTime(self.TimeOpen)
    nbs:WriteDateTime(self.TimeEnd)
    return nbs
end
function LuaCLS_AcitvityInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.IsOpen = nbs:ReadBool()
    self.TimeOpen = nbs:ReadDateTime()
    self.TimeEnd = nbs:ReadDateTime()
end
-- LuaCLS_AcitvityInfo end


-- LuaC2G_Acitvity_List begin
-- 请求 获取活动列表
LuaC2G_Acitvity_List = Class(Base)
function LuaC2G_Acitvity_List:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_LIST"]
end
function LuaC2G_Acitvity_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_List end


-- LuaG2C_Acitvity_List begin
-- 返回 获取活动列表
LuaG2C_Acitvity_List = Class(Base)
function LuaG2C_Acitvity_List:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_LIST"]
    self.ListInfo = Dictionary:New()    -- 信息列表
end
function LuaG2C_Acitvity_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3661 = nbs:ReadInt()
    for i = 1, var3661 do
        local var3662 = nbs:ReadInt()
        local var3663 = LuaCLS_AcitvityInfo.new()
        var3663:Unserialize(nbs)
        self.ListInfo:Add(var3662, var3663)
    end
end
-- LuaG2C_Acitvity_List end


-- LuaC2G_Acitvity_RebateInfo begin
-- 请求 返利信息
LuaC2G_Acitvity_RebateInfo = Class(Base)
function LuaC2G_Acitvity_RebateInfo:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_REBATEINFO"]
end
function LuaC2G_Acitvity_RebateInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_RebateInfo end


-- LuaG2C_Acitvity_RebateInfo begin
-- 返回 返利信息
LuaG2C_Acitvity_RebateInfo = Class(Base)
function LuaG2C_Acitvity_RebateInfo:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_REBATEINFO"]
    self.Rebate = 0    -- 本周返利
    self.RebateTotal = 0    -- 历史返利
end
function LuaG2C_Acitvity_RebateInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Rebate = nbs:ReadLong()
    self.RebateTotal = nbs:ReadLong()
end
-- LuaG2C_Acitvity_RebateInfo end


-- LuaC2G_Acitvity_7Day begin
-- 请求 获取七日试炼
LuaC2G_Acitvity_7Day = Class(Base)
function LuaC2G_Acitvity_7Day:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_7DAY"]
end
function LuaC2G_Acitvity_7Day:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_7Day end


-- LuaG2C_Acitvity_7Day begin
-- 返回 获取七日试炼
LuaG2C_Acitvity_7Day = Class(Base)
function LuaG2C_Acitvity_7Day:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_7DAY"]
    self.ListTask = List:New(LuaCLS_TaskInfo)    -- 任务列表
end
function LuaG2C_Acitvity_7Day:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3666 = nbs:ReadInt()
    for i = 1, var3666 do
        local var3667 = LuaCLS_TaskInfo.new()
        var3667:Unserialize(nbs)
        self.ListTask:Add(var3667)
    end
end
-- LuaG2C_Acitvity_7Day end


-- LuaC2G_Acitvity_7DayGet begin
-- 请求 七日试炼领奖
LuaC2G_Acitvity_7DayGet = Class(Base)
function LuaC2G_Acitvity_7DayGet:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_7DAYGET"]
    self.confID = 0    -- 配置ID
end
function LuaC2G_Acitvity_7DayGet:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.confID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_7DayGet end


-- LuaG2C_Acitvity_7DayGet begin
-- 返回 七日试炼领奖
LuaG2C_Acitvity_7DayGet = Class(Base)
function LuaG2C_Acitvity_7DayGet:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_7DAYGET"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Acitvity_7DayGet:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3668 = nbs:ReadInt()
    for i = 1, var3668 do
        local var3669 = LuaCLS_AwardItem.new()
        var3669:Unserialize(nbs)
        self.ListAward:Add(var3669)
    end
end
-- LuaG2C_Acitvity_7DayGet end


-- LuaC2G_Acitvity_7DayLoginInfo begin
-- 请求 获取七日登录信息
LuaC2G_Acitvity_7DayLoginInfo = Class(Base)
function LuaC2G_Acitvity_7DayLoginInfo:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_7DAYLOGININFO"]
end
function LuaC2G_Acitvity_7DayLoginInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_7DayLoginInfo end


-- LuaG2C_Acitvity_7DayLoginInfo begin
-- 返回 获取七日登录信息
LuaG2C_Acitvity_7DayLoginInfo = Class(Base)
function LuaG2C_Acitvity_7DayLoginInfo:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_7DAYLOGININFO"]
    self.DictData = Dictionary:New()    -- 七日登录信息<k=日1-7 value=E7DayLoginState>
end
function LuaG2C_Acitvity_7DayLoginInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3670 = nbs:ReadInt()
    for i = 1, var3670 do
        local var3671 = nbs:ReadInt()
        local var3672 = nbs:ReadByte()
        self.DictData:Add(var3671, var3672)
    end
end
-- LuaG2C_Acitvity_7DayLoginInfo end


-- LuaC2G_Acitvity_7DayLoginGet begin
-- 请求 七日登录领奖
LuaC2G_Acitvity_7DayLoginGet = Class(Base)
function LuaC2G_Acitvity_7DayLoginGet:ctor()
    self._protocol = LuaProtocolId["C2G_ACITVITY_7DAYLOGINGET"]
    self.Day = 0    -- 日1-7
end
function LuaC2G_Acitvity_7DayLoginGet:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Day)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Acitvity_7DayLoginGet end


-- LuaG2C_Acitvity_7DayLoginGet begin
-- 返回 七日登录领奖
LuaG2C_Acitvity_7DayLoginGet = Class(Base)
function LuaG2C_Acitvity_7DayLoginGet:ctor()
    self._protocol = LuaProtocolId["G2C_ACITVITY_7DAYLOGINGET"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励项
end
function LuaG2C_Acitvity_7DayLoginGet:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3673 = nbs:ReadInt()
    for i = 1, var3673 do
        local var3674 = LuaCLS_AwardItem.new()
        var3674:Unserialize(nbs)
        self.ListAward:Add(var3674)
    end
end
-- LuaG2C_Acitvity_7DayLoginGet end


-- LuaCLS_WelfareTaskInfo begin
-- 福利信息
LuaCLS_WelfareTaskInfo = Class()
function LuaCLS_WelfareTaskInfo:ctor()
    self.Id = 0    -- 任务ID(配置ID)
    self.State = 0    -- 任务状态 对应EWelfareState
    self.Schedule = 0    -- 当前进度
    self.ScheduleMax = 0    -- 最大进度
end
function LuaCLS_WelfareTaskInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteShort(State)
    nbs:WriteLong(self.Schedule)
    nbs:WriteLong(self.ScheduleMax)
    return nbs
end
function LuaCLS_WelfareTaskInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.State = nbs:ReadShort()
    self.Schedule = nbs:ReadLong()
    self.ScheduleMax = nbs:ReadLong()
end
-- LuaCLS_WelfareTaskInfo end


-- LuaCLS_WelfareInfo begin
-- 福利大类信息
LuaCLS_WelfareInfo = Class()
function LuaCLS_WelfareInfo:ctor()
    self.Id = 0    -- 活动大类ID
    self.IsOpen = false    -- 是否开启
    self.ListTask = Dictionary:New()    -- 任务列表
end
function LuaCLS_WelfareInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteBool(self.IsOpen)
    nbs:WriteDateTime(self.TimeOpen)
    nbs:WriteDateTime(self.TimeEnd)
    nbs:WriteInt(#self.ListTask)
    for key, value in pairs(self.ListTask) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_WelfareInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.IsOpen = nbs:ReadBool()
    self.TimeOpen = nbs:ReadDateTime()
    self.TimeEnd = nbs:ReadDateTime()
    local var3683 = nbs:ReadInt()
    for i = 1, var3683 do
        local var3684 = nbs:ReadInt()
        local var3685 = LuaCLS_WelfareTaskInfo.new()
        var3685:Unserialize(nbs)
        self.ListTask:Add(var3684, var3685)
    end
end
-- LuaCLS_WelfareInfo end


-- LuaC2G_Welfare_Info begin
-- 请求 获取福利信息
LuaC2G_Welfare_Info = Class(Base)
function LuaC2G_Welfare_Info:ctor()
    self._protocol = LuaProtocolId["C2G_WELFARE_INFO"]
end
function LuaC2G_Welfare_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Welfare_Info end


-- LuaG2C_Welfare_Info begin
-- 返回 获取福利信息
LuaG2C_Welfare_Info = Class(Base)
function LuaG2C_Welfare_Info:ctor()
    self._protocol = LuaProtocolId["G2C_WELFARE_INFO"]
    self.ListInfo = Dictionary:New()    -- 信息列表
end
function LuaG2C_Welfare_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3686 = nbs:ReadInt()
    for i = 1, var3686 do
        local var3687 = nbs:ReadInt()
        local var3688 = LuaCLS_WelfareInfo.new()
        var3688:Unserialize(nbs)
        self.ListInfo:Add(var3687, var3688)
    end
end
-- LuaG2C_Welfare_Info end


-- LuaC2G_Welfare_Award begin
-- 请求 领取福利
LuaC2G_Welfare_Award = Class(Base)
function LuaC2G_Welfare_Award:ctor()
    self._protocol = LuaProtocolId["C2G_WELFARE_AWARD"]
    self.Id = 0    -- ID(配置ID)
end
function LuaC2G_Welfare_Award:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Welfare_Award end


-- LuaG2C_Welfare_Award begin
-- 返回 领取福利
LuaG2C_Welfare_Award = Class(Base)
function LuaG2C_Welfare_Award:ctor()
    self._protocol = LuaProtocolId["G2C_WELFARE_AWARD"]
    self.Id = 0    -- ID(配置ID)
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Welfare_Award:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    local var3690 = nbs:ReadInt()
    for i = 1, var3690 do
        local var3691 = LuaCLS_AwardItem.new()
        var3691:Unserialize(nbs)
        self.ListAward:Add(var3691)
    end
end
-- LuaG2C_Welfare_Award end


-- LuaCLS_GuildInfoBase begin
-- 势力基本信息
LuaCLS_GuildInfoBase = Class()
function LuaCLS_GuildInfoBase:ctor()
    self.Uid = 0    -- 唯一ID
    self.Name = ""    -- 名字
    self.LeaderName = ""    -- 领袖名字
    self.StateId = 0    -- 所属州
    self.Level = 0    -- 等级
    self.JoinMode = 0    -- 势力加入方式 EGuildJoinMode
    self.CountMember = LuaCLS_CountInfo.new()    -- 人数
    self.IsAlliance = false    -- 是否同盟关系
end
function LuaCLS_GuildInfoBase:Serialize(nbs)
    nbs:WriteLong(self.Uid)
    nbs:WriteString(self.Name)
    nbs:WriteString(self.LeaderName)
    nbs:WriteInt(self.StateId)
    nbs:WriteInt(self.Level)
    nbs:WriteByte(self.JoinMode)
    CountMember:Serialize(nbs)
    nbs:WriteBool(self.IsAlliance)
    return nbs
end
function LuaCLS_GuildInfoBase:Unserialize(nbs)
    self.Uid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.LeaderName = nbs:ReadString()
    self.StateId = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.JoinMode = nbs:ReadByte()
    self.CountMember:Unserialize(nbs)
    self.IsAlliance = nbs:ReadBool()
end
-- LuaCLS_GuildInfoBase end


-- LuaCLS_GuildInfoDetails begin
-- 势力详细信息
LuaCLS_GuildInfoDetails = Class()
function LuaCLS_GuildInfoDetails:ctor()
    self.Uid = 0    -- 唯一ID
    self.Name = ""    -- 名字
    self.LeaderName = ""    -- 领袖名字
    self.StateId = 0    -- 所属州
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验
    self.Fund = 0    -- 势力资金
    self.Revenue = 0    -- 总收入
    self.JoinMode = 0    -- 势力加入方式 EGuildJoinMode
    self.CountMember = LuaCLS_CountInfo.new()    -- 人数
    self.CapitalCity = 0    -- 都城ID
    self.CountCity = 0    -- 城池数
    self.Manifesto = ""    -- 宣言
    self.Notice = ""    -- 公告
    self.GoddessName = ""    -- 圣女名字
    self.GoddessCity = 0    -- 圣女驻守城池
end
function LuaCLS_GuildInfoDetails:Serialize(nbs)
    nbs:WriteLong(self.Uid)
    nbs:WriteString(self.Name)
    nbs:WriteString(self.LeaderName)
    nbs:WriteInt(self.StateId)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.Exp)
    nbs:WriteInt(self.Fund)
    nbs:WriteInt(self.Revenue)
    nbs:WriteByte(self.JoinMode)
    CountMember:Serialize(nbs)
    nbs:WriteInt(self.CapitalCity)
    nbs:WriteInt(self.CountCity)
    nbs:WriteString(self.Manifesto)
    nbs:WriteString(self.Notice)
    nbs:WriteString(self.GoddessName)
    nbs:WriteInt(self.GoddessCity)
    return nbs
end
function LuaCLS_GuildInfoDetails:Unserialize(nbs)
    self.Uid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.LeaderName = nbs:ReadString()
    self.StateId = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
    self.Fund = nbs:ReadInt()
    self.Revenue = nbs:ReadInt()
    self.JoinMode = nbs:ReadByte()
    self.CountMember:Unserialize(nbs)
    self.CapitalCity = nbs:ReadInt()
    self.CountCity = nbs:ReadInt()
    self.Manifesto = nbs:ReadString()
    self.Notice = nbs:ReadString()
    self.GoddessName = nbs:ReadString()
    self.GoddessCity = nbs:ReadInt()
end
-- LuaCLS_GuildInfoDetails end


-- LuaCLS_GuildInfoMy begin
-- 势力详细我的
LuaCLS_GuildInfoMy = Class()
function LuaCLS_GuildInfoMy:ctor()
    self.GuildInfoDetails = LuaCLS_GuildInfoDetails.new()    -- 详细信息
end
function LuaCLS_GuildInfoMy:Serialize(nbs)
    GuildInfoDetails:Serialize(nbs)
    return nbs
end
function LuaCLS_GuildInfoMy:Unserialize(nbs)
    self.GuildInfoDetails:Unserialize(nbs)
end
-- LuaCLS_GuildInfoMy end


-- LuaC2G_Guild_List begin
-- 请求 势力列表
LuaC2G_Guild_List = Class(Base)
function LuaC2G_Guild_List:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LIST"]
end
function LuaC2G_Guild_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_List end


-- LuaG2C_Guild_List begin
-- 返回 势力列表
LuaG2C_Guild_List = Class(Base)
function LuaG2C_Guild_List:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LIST"]
    self.ListGuildInfoBase = List:New(LuaCLS_GuildInfoBase)    -- 势力列表
end
function LuaG2C_Guild_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3717 = nbs:ReadInt()
    for i = 1, var3717 do
        local var3718 = LuaCLS_GuildInfoBase.new()
        var3718:Unserialize(nbs)
        self.ListGuildInfoBase:Add(var3718)
    end
    self.CdCanJoin = nbs:ReadTimeSpan()
end
-- LuaG2C_Guild_List end


-- LuaC2G_Guild_ListDetails begin
-- 请求 势力详情
LuaC2G_Guild_ListDetails = Class(Base)
function LuaC2G_Guild_ListDetails:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTDETAILS"]
    self.Uid = 0    -- 唯一ID
end
function LuaC2G_Guild_ListDetails:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListDetails end


-- LuaG2C_Guild_ListDetails begin
-- 返回 势力详情
LuaG2C_Guild_ListDetails = Class(Base)
function LuaG2C_Guild_ListDetails:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTDETAILS"]
    self.GuildInfoDetails = LuaCLS_GuildInfoDetails.new()    -- 势力详情
end
function LuaG2C_Guild_ListDetails:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.GuildInfoDetails:Unserialize(nbs)
end
-- LuaG2C_Guild_ListDetails end


-- LuaC2G_Guild_Create begin
-- 请求 势力创建
LuaC2G_Guild_Create = Class(Base)
function LuaC2G_Guild_Create:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_CREATE"]
    self.Name = ""    -- 名字
end
function LuaC2G_Guild_Create:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Name)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Create end


-- LuaG2C_Guild_Create begin
-- 返回 势力创建
LuaG2C_Guild_Create = Class(Base)
function LuaG2C_Guild_Create:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_CREATE"]
end
function LuaG2C_Guild_Create:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_Create end


-- LuaC2G_Guild_TryLeave begin
-- 请求 脱离
LuaC2G_Guild_TryLeave = Class(Base)
function LuaC2G_Guild_TryLeave:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_TRYLEAVE"]
end
function LuaC2G_Guild_TryLeave:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_TryLeave end


-- LuaG2C_Guild_TryLeave begin
-- 返回 脱离
LuaG2C_Guild_TryLeave = Class(Base)
function LuaG2C_Guild_TryLeave:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_TRYLEAVE"]
end
function LuaG2C_Guild_TryLeave:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_TryLeave end


-- LuaC2G_Guild_TryKick begin
-- 请求 逐出
LuaC2G_Guild_TryKick = Class(Base)
function LuaC2G_Guild_TryKick:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_TRYKICK"]
    self.TargetPuid = 0    -- 对象玩家ID
end
function LuaC2G_Guild_TryKick:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.TargetPuid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_TryKick end


-- LuaG2C_Guild_TryKick begin
-- 返回 逐出
LuaG2C_Guild_TryKick = Class(Base)
function LuaG2C_Guild_TryKick:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_TRYKICK"]
end
function LuaG2C_Guild_TryKick:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_TryKick end


-- LuaC2G_Guild_Abdicate begin
-- 请求 禅让
LuaC2G_Guild_Abdicate = Class(Base)
function LuaC2G_Guild_Abdicate:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ABDICATE"]
    self.TargetPuid = 0    -- 对象玩家ID
end
function LuaC2G_Guild_Abdicate:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.TargetPuid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Abdicate end


-- LuaG2C_Guild_Abdicate begin
-- 返回 禅让
LuaG2C_Guild_Abdicate = Class(Base)
function LuaG2C_Guild_Abdicate:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ABDICATE"]
end
function LuaG2C_Guild_Abdicate:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_Abdicate end


-- LuaC2G_Guild_TryJoin begin
-- 请求 申请加入
LuaC2G_Guild_TryJoin = Class(Base)
function LuaC2G_Guild_TryJoin:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_TRYJOIN"]
    self.Uid = 0    -- 唯一ID
end
function LuaC2G_Guild_TryJoin:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_TryJoin end


-- LuaG2C_Guild_TryJoin begin
-- 返回 申请加入
LuaG2C_Guild_TryJoin = Class(Base)
function LuaG2C_Guild_TryJoin:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_TRYJOIN"]
end
function LuaG2C_Guild_TryJoin:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_TryJoin end


-- LuaC2G_Guild_ListApply begin
-- 请求 申请列表
LuaC2G_Guild_ListApply = Class(Base)
function LuaC2G_Guild_ListApply:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTAPPLY"]
end
function LuaC2G_Guild_ListApply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListApply end


-- LuaG2C_Guild_ListApply begin
-- 返回 申请列表
LuaG2C_Guild_ListApply = Class(Base)
function LuaG2C_Guild_ListApply:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTAPPLY"]
    self.ListApply = List:New(LuaCLS_PubPlayerBase)    -- 势力申请列表
end
function LuaG2C_Guild_ListApply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3721 = nbs:ReadInt()
    for i = 1, var3721 do
        local var3722 = LuaCLS_PubPlayerBase.new()
        var3722:Unserialize(nbs)
        self.ListApply:Add(var3722)
    end
end
-- LuaG2C_Guild_ListApply end


-- LuaC2G_Guild_ApplyAction begin
-- 请求 申请处理
LuaC2G_Guild_ApplyAction = Class(Base)
function LuaC2G_Guild_ApplyAction:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_APPLYACTION"]
    self.TargetPuid = 0    -- 对象玩家ID
    self.HandleAction = 0    -- 处理方式 EHandleAction
end
function LuaC2G_Guild_ApplyAction:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.TargetPuid)
    nbs:WriteInt(self.HandleAction)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ApplyAction end


-- LuaG2C_Guild_ApplyAction begin
-- 返回 申请处理
LuaG2C_Guild_ApplyAction = Class(Base)
function LuaG2C_Guild_ApplyAction:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_APPLYACTION"]
    self.TargetPuid = 0    -- 对象玩家ID
    self.HandleAction = 0    -- 处理方式 EHandleAction
    self.CountMember = LuaCLS_CountInfo.new()    -- 人数
end
function LuaG2C_Guild_ApplyAction:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.TargetPuid = nbs:ReadLong()
    self.HandleAction = nbs:ReadInt()
    self.CountMember:Unserialize(nbs)
end
-- LuaG2C_Guild_ApplyAction end


-- LuaCLS_GuildMbsInfo begin
-- 势力成员信息
LuaCLS_GuildMbsInfo = Class()
function LuaCLS_GuildMbsInfo:ctor()
    self.PubPlayerBase = LuaCLS_PubPlayerBase.new()    -- 基本信息
    self.Contribution = 0    -- 贡献
    self.ContributionTotal = 0    -- 历史贡献
end
function LuaCLS_GuildMbsInfo:Serialize(nbs)
    PubPlayerBase:Serialize(nbs)
    nbs:WriteInt(self.Contribution)
    nbs:WriteInt(self.ContributionTotal)
    nbs:WriteDateTime(self.TimeJoin)
    return nbs
end
function LuaCLS_GuildMbsInfo:Unserialize(nbs)
    self.PubPlayerBase:Unserialize(nbs)
    self.Contribution = nbs:ReadInt()
    self.ContributionTotal = nbs:ReadInt()
    self.TimeJoin = nbs:ReadDateTime()
end
-- LuaCLS_GuildMbsInfo end


-- LuaC2G_Guild_ListMbs begin
-- 请求 成员列表
LuaC2G_Guild_ListMbs = Class(Base)
function LuaC2G_Guild_ListMbs:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTMBS"]
end
function LuaC2G_Guild_ListMbs:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListMbs end


-- LuaG2C_Guild_ListMbs begin
-- 返回 成员列表
LuaG2C_Guild_ListMbs = Class(Base)
function LuaG2C_Guild_ListMbs:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTMBS"]
    self.ListMember = List:New(LuaCLS_GuildMbsInfo)    -- 势力成员列表
end
function LuaG2C_Guild_ListMbs:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3730 = nbs:ReadInt()
    for i = 1, var3730 do
        local var3731 = LuaCLS_GuildMbsInfo.new()
        var3731:Unserialize(nbs)
        self.ListMember:Add(var3731)
    end
end
-- LuaG2C_Guild_ListMbs end


-- LuaC2G_Guild_ListLogRecord begin
-- 请求 动态列表
LuaC2G_Guild_ListLogRecord = Class(Base)
function LuaC2G_Guild_ListLogRecord:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTLOGRECORD"]
end
function LuaC2G_Guild_ListLogRecord:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListLogRecord end


-- LuaG2C_Guild_ListLogRecord begin
-- 返回 动态列表
LuaG2C_Guild_ListLogRecord = Class(Base)
function LuaG2C_Guild_ListLogRecord:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTLOGRECORD"]
    self.ListLog = List:New(LuaCLS_GameLog)    -- 势力动态列表
end
function LuaG2C_Guild_ListLogRecord:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3732 = nbs:ReadInt()
    for i = 1, var3732 do
        local var3733 = LuaCLS_GameLog.new()
        var3733:Unserialize(nbs)
        self.ListLog:Add(var3733)
    end
end
-- LuaG2C_Guild_ListLogRecord end


-- LuaC2G_Guild_Rename begin
-- 请求 改名
LuaC2G_Guild_Rename = Class(Base)
function LuaC2G_Guild_Rename:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_RENAME"]
    self.Name = ""    -- 名字
end
function LuaC2G_Guild_Rename:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Name)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Rename end


-- LuaG2C_Guild_Rename begin
-- 返回 改名
LuaG2C_Guild_Rename = Class(Base)
function LuaG2C_Guild_Rename:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_RENAME"]
end
function LuaG2C_Guild_Rename:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_Rename end


-- LuaC2G_Guild_JoinMode begin
-- 请求 修改加入设置
LuaC2G_Guild_JoinMode = Class(Base)
function LuaC2G_Guild_JoinMode:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_JOINMODE"]
    self.JoinMode = 0    -- 势力加入方式 EGuildJoinMode
end
function LuaC2G_Guild_JoinMode:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteByte(self.JoinMode)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_JoinMode end


-- LuaG2C_Guild_JoinMode begin
-- 返回 修改加入设置
LuaG2C_Guild_JoinMode = Class(Base)
function LuaG2C_Guild_JoinMode:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_JOINMODE"]
end
function LuaG2C_Guild_JoinMode:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_JoinMode end


-- LuaC2G_Guild_Manifesto begin
-- 请求 修改宣言
LuaC2G_Guild_Manifesto = Class(Base)
function LuaC2G_Guild_Manifesto:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_MANIFESTO"]
    self.Manifesto = ""    -- 宣言
end
function LuaC2G_Guild_Manifesto:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Manifesto)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Manifesto end


-- LuaG2C_Guild_Manifesto begin
-- 返回 修改宣言
LuaG2C_Guild_Manifesto = Class(Base)
function LuaG2C_Guild_Manifesto:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_MANIFESTO"]
end
function LuaG2C_Guild_Manifesto:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_Manifesto end


-- LuaC2G_Guild_Notice begin
-- 请求 修改公告
LuaC2G_Guild_Notice = Class(Base)
function LuaC2G_Guild_Notice:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_NOTICE"]
    self.Notice = ""    -- 公告
end
function LuaC2G_Guild_Notice:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Notice)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Notice end


-- LuaG2C_Guild_Notice begin
-- 返回 修改公告
LuaG2C_Guild_Notice = Class(Base)
function LuaG2C_Guild_Notice:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_NOTICE"]
end
function LuaG2C_Guild_Notice:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_Notice end


-- LuaC2G_Guild_DonateInfo begin
-- 请求 捐献信息
LuaC2G_Guild_DonateInfo = Class(Base)
function LuaC2G_Guild_DonateInfo:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_DONATEINFO"]
end
function LuaC2G_Guild_DonateInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_DonateInfo end


-- LuaG2C_Guild_DonateInfo begin
-- 返回 捐献信息
LuaG2C_Guild_DonateInfo = Class(Base)
function LuaG2C_Guild_DonateInfo:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_DONATEINFO"]
    self.ListLog = List:New(LuaCLS_GameLog)    -- 捐献记录
    self.DictDonateCount = Dictionary:New()    -- 捐献次数(key=捐献id value=今日次数)
    self.Contribution = 0    -- 贡献值
end
function LuaG2C_Guild_DonateInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3734 = nbs:ReadInt()
    for i = 1, var3734 do
        local var3735 = LuaCLS_GameLog.new()
        var3735:Unserialize(nbs)
        self.ListLog:Add(var3735)
    end
    local var3736 = nbs:ReadInt()
    for i = 1, var3736 do
        local var3737 = nbs:ReadInt()
        local var3738 = nbs:ReadInt()
        self.DictDonateCount:Add(var3737, var3738)
    end
    self.Contribution = nbs:ReadInt()
end
-- LuaG2C_Guild_DonateInfo end


-- LuaC2G_Guild_Donate begin
-- 请求 捐献
LuaC2G_Guild_Donate = Class(Base)
function LuaC2G_Guild_Donate:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_DONATE"]
    self.DonateId = 0
end
function LuaC2G_Guild_Donate:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DonateId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_Donate end


-- LuaG2C_Guild_Donate begin
-- 返回 捐献
LuaG2C_Guild_Donate = Class(Base)
function LuaG2C_Guild_Donate:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_DONATE"]
    self.DonateId = 0
    self.DonateLog = LuaCLS_GameLog.new()    -- 新增捐献记录
    self.GuildInfoDetails = LuaCLS_GuildInfoDetails.new()    -- 详细信息
    self.Contribution = 0    -- 贡献值
end
function LuaG2C_Guild_Donate:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DonateId = nbs:ReadInt()
    self.DonateLog:Unserialize(nbs)
    self.GuildInfoDetails:Unserialize(nbs)
    self.Contribution = nbs:ReadInt()
end
-- LuaG2C_Guild_Donate end


-- LuaC2G_Guild_ListDiplomacy begin
-- 请求 势力关系列表
LuaC2G_Guild_ListDiplomacy = Class(Base)
function LuaC2G_Guild_ListDiplomacy:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTDIPLOMACY"]
end
function LuaC2G_Guild_ListDiplomacy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListDiplomacy end


-- LuaG2C_Guild_ListDiplomacy begin
-- 返回 势力关系列表
LuaG2C_Guild_ListDiplomacy = Class(Base)
function LuaG2C_Guild_ListDiplomacy:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTDIPLOMACY"]
    self.ListGuildInfoBase = List:New(LuaCLS_GuildInfoBase)    -- 势力关系列表
end
function LuaG2C_Guild_ListDiplomacy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3744 = nbs:ReadInt()
    for i = 1, var3744 do
        local var3745 = LuaCLS_GuildInfoBase.new()
        var3745:Unserialize(nbs)
        self.ListGuildInfoBase:Add(var3745)
    end
end
-- LuaG2C_Guild_ListDiplomacy end


-- LuaC2G_Guild_SearchName begin
-- 请求 势力名搜索
LuaC2G_Guild_SearchName = Class(Base)
function LuaC2G_Guild_SearchName:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SEARCHNAME"]
    self.Key = ""    -- 关键字
end
function LuaC2G_Guild_SearchName:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteString(self.Key)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_SearchName end


-- LuaG2C_Guild_SearchName begin
-- 返回 势力名搜索
LuaG2C_Guild_SearchName = Class(Base)
function LuaG2C_Guild_SearchName:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SEARCHNAME"]
    self.ListGuildInfoBase = List:New(LuaCLS_GuildInfoBase)    -- 势力名搜索结果
end
function LuaG2C_Guild_SearchName:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3746 = nbs:ReadInt()
    for i = 1, var3746 do
        local var3747 = LuaCLS_GuildInfoBase.new()
        var3747:Unserialize(nbs)
        self.ListGuildInfoBase:Add(var3747)
    end
end
-- LuaG2C_Guild_SearchName end


-- LuaC2G_Guild_ListAllianceApply begin
-- 请求 同盟申请列表
LuaC2G_Guild_ListAllianceApply = Class(Base)
function LuaC2G_Guild_ListAllianceApply:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTALLIANCEAPPLY"]
end
function LuaC2G_Guild_ListAllianceApply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListAllianceApply end


-- LuaG2C_Guild_ListAllianceApply begin
-- 返回 同盟申请列表
LuaG2C_Guild_ListAllianceApply = Class(Base)
function LuaG2C_Guild_ListAllianceApply:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTALLIANCEAPPLY"]
    self.ListGuildInfoBase = List:New(LuaCLS_GuildInfoBase)    -- 同盟申请列表
end
function LuaG2C_Guild_ListAllianceApply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3748 = nbs:ReadInt()
    for i = 1, var3748 do
        local var3749 = LuaCLS_GuildInfoBase.new()
        var3749:Unserialize(nbs)
        self.ListGuildInfoBase:Add(var3749)
    end
end
-- LuaG2C_Guild_ListAllianceApply end


-- LuaC2G_Guild_AllianceApply begin
-- 请求 同盟申请
LuaC2G_Guild_AllianceApply = Class(Base)
function LuaC2G_Guild_AllianceApply:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ALLIANCEAPPLY"]
    self.Uid = 0    -- 唯一ID
end
function LuaC2G_Guild_AllianceApply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_AllianceApply end


-- LuaG2C_Guild_AllianceApply begin
-- 返回 同盟申请
LuaG2C_Guild_AllianceApply = Class(Base)
function LuaG2C_Guild_AllianceApply:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ALLIANCEAPPLY"]
end
function LuaG2C_Guild_AllianceApply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_AllianceApply end


-- LuaC2G_Guild_AllianceRemove begin
-- 请求 同盟解除
LuaC2G_Guild_AllianceRemove = Class(Base)
function LuaC2G_Guild_AllianceRemove:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ALLIANCEREMOVE"]
    self.Uid = 0    -- 唯一ID
end
function LuaC2G_Guild_AllianceRemove:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_AllianceRemove end


-- LuaG2C_Guild_AllianceRemove begin
-- 返回 同盟解除
LuaG2C_Guild_AllianceRemove = Class(Base)
function LuaG2C_Guild_AllianceRemove:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ALLIANCEREMOVE"]
end
function LuaG2C_Guild_AllianceRemove:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_AllianceRemove end


-- LuaC2G_Guild_AllianceApplyAction begin
-- 请求 同盟申请处理
LuaC2G_Guild_AllianceApplyAction = Class(Base)
function LuaC2G_Guild_AllianceApplyAction:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ALLIANCEAPPLYACTION"]
    self.Uid = 0    -- 对象ID
    self.HandleAction = 0    -- 处理方式 EHandleAction
end
function LuaC2G_Guild_AllianceApplyAction:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.Uid)
    nbs:WriteInt(self.HandleAction)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_AllianceApplyAction end


-- LuaG2C_Guild_AllianceApplyAction begin
-- 返回 同盟申请处理
LuaG2C_Guild_AllianceApplyAction = Class(Base)
function LuaG2C_Guild_AllianceApplyAction:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ALLIANCEAPPLYACTION"]
end
function LuaG2C_Guild_AllianceApplyAction:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_AllianceApplyAction end


-- LuaC2G_Guild_ListCity begin
-- 请求 城池列表
LuaC2G_Guild_ListCity = Class(Base)
function LuaC2G_Guild_ListCity:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTCITY"]
end
function LuaC2G_Guild_ListCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListCity end


-- LuaG2C_Guild_ListCity begin
-- 返回 城池列表
LuaG2C_Guild_ListCity = Class(Base)
function LuaG2C_Guild_ListCity:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTCITY"]
    self.CapitalCity = 0    -- 都城ID
    self.ListCity = List:New(LuaCLS_CityInfo4Guild)    -- 城池列表
end
function LuaG2C_Guild_ListCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CapitalCity = nbs:ReadInt()
    local var3751 = nbs:ReadInt()
    for i = 1, var3751 do
        local var3752 = LuaCLS_CityInfo4Guild.new()
        var3752:Unserialize(nbs)
        self.ListCity:Add(var3752)
    end
end
-- LuaG2C_Guild_ListCity end


-- LuaC2G_Guild_SetCapitalCity begin
-- 请求 设置都城
LuaC2G_Guild_SetCapitalCity = Class(Base)
function LuaC2G_Guild_SetCapitalCity:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SETCAPITALCITY"]
    self.Uid = 0    -- 城池ID
end
function LuaC2G_Guild_SetCapitalCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_SetCapitalCity end


-- LuaG2C_Guild_SetCapitalCity begin
-- 返回 设置都城
LuaG2C_Guild_SetCapitalCity = Class(Base)
function LuaG2C_Guild_SetCapitalCity:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SETCAPITALCITY"]
end
function LuaG2C_Guild_SetCapitalCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_SetCapitalCity end


-- LuaC2G_Guild_SetCityLeader begin
-- 请求 任命太守
LuaC2G_Guild_SetCityLeader = Class(Base)
function LuaC2G_Guild_SetCityLeader:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SETCITYLEADER"]
    self.Uid = 0    -- 城池ID
    self.LeaderPuid = 0    -- 新任命的玩家ID
end
function LuaC2G_Guild_SetCityLeader:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.LeaderPuid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_SetCityLeader end


-- LuaG2C_Guild_SetCityLeader begin
-- 返回 任命太守
LuaG2C_Guild_SetCityLeader = Class(Base)
function LuaG2C_Guild_SetCityLeader:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SETCITYLEADER"]
end
function LuaG2C_Guild_SetCityLeader:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_SetCityLeader end


-- LuaC2G_Guild_RemoveCityLeader begin
-- 请求 撤销太守
LuaC2G_Guild_RemoveCityLeader = Class(Base)
function LuaC2G_Guild_RemoveCityLeader:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_REMOVECITYLEADER"]
    self.Uid = 0    -- 城池ID
end
function LuaC2G_Guild_RemoveCityLeader:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_RemoveCityLeader end


-- LuaG2C_Guild_RemoveCityLeader begin
-- 返回 撤销太守
LuaG2C_Guild_RemoveCityLeader = Class(Base)
function LuaG2C_Guild_RemoveCityLeader:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_REMOVECITYLEADER"]
end
function LuaG2C_Guild_RemoveCityLeader:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_RemoveCityLeader end


-- LuaC2G_Guild_ListLogSituation begin
-- 请求 军情
LuaC2G_Guild_ListLogSituation = Class(Base)
function LuaC2G_Guild_ListLogSituation:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTLOGSITUATION"]
end
function LuaC2G_Guild_ListLogSituation:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListLogSituation end


-- LuaG2C_Guild_ListLogSituation begin
-- 返回 军情
LuaG2C_Guild_ListLogSituation = Class(Base)
function LuaG2C_Guild_ListLogSituation:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTLOGSITUATION"]
    self.ListLog = List:New(LuaCLS_GameLog)    -- 军情列表
end
function LuaG2C_Guild_ListLogSituation:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3753 = nbs:ReadInt()
    for i = 1, var3753 do
        local var3754 = LuaCLS_GameLog.new()
        var3754:Unserialize(nbs)
        self.ListLog:Add(var3754)
    end
end
-- LuaG2C_Guild_ListLogSituation end


-- LuaCLS_GuildTopInfo begin
-- 势力排行信息单条
LuaCLS_GuildTopInfo = Class()
function LuaCLS_GuildTopInfo:ctor()
    self.GuildUid = 0    -- 唯一ID
    self.Name = ""    -- 名字
    self.CountryId = 0    -- 所属国
    self.CountCity = 0    -- 城池数
    self.TsLastSeize = 0    -- 最后占领时间
end
function LuaCLS_GuildTopInfo:Serialize(nbs)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.CountryId)
    nbs:WriteInt(self.CountCity)
    nbs:WriteLong(self.TsLastSeize)
    return nbs
end
function LuaCLS_GuildTopInfo:Unserialize(nbs)
    self.GuildUid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.CountryId = nbs:ReadInt()
    self.CountCity = nbs:ReadInt()
    self.TsLastSeize = nbs:ReadLong()
end
-- LuaCLS_GuildTopInfo end


-- LuaC2G_Guild_ListTop begin
-- 请求 势力排行
LuaC2G_Guild_ListTop = Class(Base)
function LuaC2G_Guild_ListTop:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_LISTTOP"]
end
function LuaC2G_Guild_ListTop:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ListTop end


-- LuaG2C_Guild_ListTop begin
-- 返回 势力排行
LuaG2C_Guild_ListTop = Class(Base)
function LuaG2C_Guild_ListTop:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_LISTTOP"]
    self.ListTop = List:New(LuaCLS_GuildTopInfo)    -- 势力排行
end
function LuaG2C_Guild_ListTop:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3760 = nbs:ReadInt()
    for i = 1, var3760 do
        local var3761 = LuaCLS_GuildTopInfo.new()
        var3761:Unserialize(nbs)
        self.ListTop:Add(var3761)
    end
end
-- LuaG2C_Guild_ListTop end


-- LuaCLS_RedPacketMember begin
-- 红包成员信息
LuaCLS_RedPacketMember = Class()
function LuaCLS_RedPacketMember:ctor()
    self.PlayerID = 0    -- 玩家ID
    self.HeadId = 0    -- 头像ID
    self.Name = ""
    self.Bonus = 0    -- 抢到金额
end
function LuaCLS_RedPacketMember:Serialize(nbs)
    nbs:WriteLong(self.PlayerID)
    nbs:WriteInt(self.HeadId)
    nbs:WriteString(self.Name)
    nbs:WriteInt(self.Bonus)
    return nbs
end
function LuaCLS_RedPacketMember:Unserialize(nbs)
    self.PlayerID = nbs:ReadLong()
    self.HeadId = nbs:ReadInt()
    self.Name = nbs:ReadString()
    self.Bonus = nbs:ReadInt()
end
-- LuaCLS_RedPacketMember end


-- LuaCLS_RedPacketsInfo begin
-- //红包列表
LuaCLS_RedPacketsInfo = Class()
function LuaCLS_RedPacketsInfo:ctor()
    self.RedPacketsID = 0    -- 红包ID
    self.Owner = LuaCLS_RedPacketMember.new()    -- 发起者
    self.State = 0    -- 状态 ERedPacketState
    self.TimeEnd = 0    -- 还剩多少时间(秒)
end
function LuaCLS_RedPacketsInfo:Serialize(nbs)
    nbs:WriteLong(self.RedPacketsID)
    Owner:Serialize(nbs)
    nbs:WriteInt(self.State)
    nbs:WriteInt(self.TimeEnd)
    return nbs
end
function LuaCLS_RedPacketsInfo:Unserialize(nbs)
    self.RedPacketsID = nbs:ReadLong()
    self.Owner:Unserialize(nbs)
    self.State = nbs:ReadInt()
    self.TimeEnd = nbs:ReadInt()
end
-- LuaCLS_RedPacketsInfo end


-- LuaCLS_RedPacket begin
-- //红包信息
LuaCLS_RedPacket = Class()
function LuaCLS_RedPacket:ctor()
    self.RedPacketsID = 0    -- 红包ID
    self.TotalSugar = 0    -- 总金额
    self.TotalNumber = 0    -- 总个数
    self.SurplusSugar = 0    -- 剩余金额
    self.SurplusNumber = 0    -- 剩余个数
    self.Owner = LuaCLS_RedPacketMember.new()    -- 发起者
    self.TimeEnd = 0    -- 还剩多少时间(秒)
    self.ListMember = List:New(LuaCLS_RedPacketMember)    -- 已抢列表
    self.Txt = ""    -- 祝福语
end
function LuaCLS_RedPacket:Serialize(nbs)
    nbs:WriteLong(self.RedPacketsID)
    nbs:WriteInt(self.TotalSugar)
    nbs:WriteInt(self.TotalNumber)
    nbs:WriteInt(self.SurplusSugar)
    nbs:WriteInt(self.SurplusNumber)
    Owner:Serialize(nbs)
    nbs:WriteInt(self.TimeEnd)
    nbs:WriteInt(#self.ListMember)
    for i = 1, #self.ListMember do
        (self.ListMember[i]):Serialize(nbs)
    end
    nbs:WriteString(self.Txt)
    return nbs
end
function LuaCLS_RedPacket:Unserialize(nbs)
    self.RedPacketsID = nbs:ReadLong()
    self.TotalSugar = nbs:ReadInt()
    self.TotalNumber = nbs:ReadInt()
    self.SurplusSugar = nbs:ReadInt()
    self.SurplusNumber = nbs:ReadInt()
    self.Owner:Unserialize(nbs)
    self.TimeEnd = nbs:ReadInt()
    local var3777 = nbs:ReadInt()
    for i = 1, var3777 do
        local var3778 = LuaCLS_RedPacketMember.new()
        var3778:Unserialize(nbs)
        self.ListMember:Add(var3778)
    end
    self.Txt = nbs:ReadString()
end
-- LuaCLS_RedPacket end


-- LuaC2G_Red_Packet_List begin
-- 请求 红包列表
LuaC2G_Red_Packet_List = Class(Base)
function LuaC2G_Red_Packet_List:ctor()
    self._protocol = LuaProtocolId["C2G_RED_PACKET_LIST"]
end
function LuaC2G_Red_Packet_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Red_Packet_List end


-- LuaG2C_Red_Packet_List begin
-- 返回 红包列表
LuaG2C_Red_Packet_List = Class(Base)
function LuaG2C_Red_Packet_List:ctor()
    self._protocol = LuaProtocolId["G2C_RED_PACKET_LIST"]
    self.GetMax = 0    -- 0:领红包未达到上限,1:领红包达到上限
    self.Info = List:New(LuaCLS_RedPacketsInfo)    -- 红包列表
end
function LuaG2C_Red_Packet_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.GetMax = nbs:ReadInt()
    local var3781 = nbs:ReadInt()
    for i = 1, var3781 do
        local var3782 = LuaCLS_RedPacketsInfo.new()
        var3782:Unserialize(nbs)
        self.Info:Add(var3782)
    end
end
-- LuaG2C_Red_Packet_List end


-- LuaC2G_Red_Packet_Info begin
-- 请求 单个红包信息
LuaC2G_Red_Packet_Info = Class(Base)
function LuaC2G_Red_Packet_Info:ctor()
    self._protocol = LuaProtocolId["C2G_RED_PACKET_INFO"]
    self.RedPacketsID = 0    -- 红包ID
end
function LuaC2G_Red_Packet_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.RedPacketsID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Red_Packet_Info end


-- LuaG2C_Red_Packet_Info begin
-- 返回 单个红包信息
LuaG2C_Red_Packet_Info = Class(Base)
function LuaG2C_Red_Packet_Info:ctor()
    self._protocol = LuaProtocolId["G2C_RED_PACKET_INFO"]
    self.Error = 0    -- 状态
    self.Info = LuaCLS_RedPacket.new()    -- 红包信息
end
function LuaG2C_Red_Packet_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Error = nbs:ReadInt()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Red_Packet_Info end


-- LuaC2G_Give_Red_Packet begin
-- 请求 发红包
LuaC2G_Give_Red_Packet = Class(Base)
function LuaC2G_Give_Red_Packet:ctor()
    self._protocol = LuaProtocolId["C2G_GIVE_RED_PACKET"]
    self.Sugar = 0    -- 金额
    self.Number = 0    -- 个数
    self.Txt = ""    -- 祝福语
end
function LuaC2G_Give_Red_Packet:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Sugar)
    nbs:WriteInt(self.Number)
    nbs:WriteString(self.Txt)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Give_Red_Packet end


-- LuaG2C_Give_Red_Packet begin
-- 返回 发红包
LuaG2C_Give_Red_Packet = Class(Base)
function LuaG2C_Give_Red_Packet:ctor()
    self._protocol = LuaProtocolId["G2C_GIVE_RED_PACKET"]
end
function LuaG2C_Give_Red_Packet:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Give_Red_Packet end


-- LuaG2C_Red_Packet_Receive begin
-- 返回 发红包
LuaG2C_Red_Packet_Receive = Class(Base)
function LuaG2C_Red_Packet_Receive:ctor()
    self._protocol = LuaProtocolId["G2C_RED_PACKET_RECEIVE"]
    self.Info = LuaCLS_RedPacketsInfo.new()    -- 红包信息
    self.InfoList = List:New(LuaCLS_RedPacketsInfo)    -- 红包列表
end
function LuaG2C_Red_Packet_Receive:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
    local var3786 = nbs:ReadInt()
    for i = 1, var3786 do
        local var3787 = LuaCLS_RedPacketsInfo.new()
        var3787:Unserialize(nbs)
        self.InfoList:Add(var3787)
    end
end
-- LuaG2C_Red_Packet_Receive end


-- LuaC2G_Get_Red_Packet begin
-- 请求 抢红包
LuaC2G_Get_Red_Packet = Class(Base)
function LuaC2G_Get_Red_Packet:ctor()
    self._protocol = LuaProtocolId["C2G_GET_RED_PACKET"]
    self.RedPacketsID = 0    -- 红包ID
end
function LuaC2G_Get_Red_Packet:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.RedPacketsID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Get_Red_Packet end


-- LuaG2C_Get_Red_Packet begin
-- 返回 抢红包
LuaG2C_Get_Red_Packet = Class(Base)
function LuaG2C_Get_Red_Packet:ctor()
    self._protocol = LuaProtocolId["G2C_GET_RED_PACKET"]
    self.Error = 0    -- 状态
    self.Bonus = 0    -- 抢到的金额
    self.GetMax = 0    -- 0:领红包未达到上限,1:领红包达到上限
    self.Info = LuaCLS_RedPacket.new()    -- 红包信息
end
function LuaG2C_Get_Red_Packet:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Error = nbs:ReadInt()
    self.Bonus = nbs:ReadInt()
    self.GetMax = nbs:ReadInt()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Get_Red_Packet end


-- LuaC2G_MansionBoss_Info begin
-- 请求 获取府Boss信息
LuaC2G_MansionBoss_Info = Class(Base)
function LuaC2G_MansionBoss_Info:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_INFO"]
    self.MansionId = 0    -- 府ID
end
function LuaC2G_MansionBoss_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Info end


-- LuaG2C_MansionBoss_Info begin
-- 返回 获取府Boss信息
LuaG2C_MansionBoss_Info = Class(Base)
function LuaG2C_MansionBoss_Info:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_INFO"]
    self.IsOpen = false    -- 是否已开启
    self.OpenCount = 0    -- 今日可开启次数
    self.ConfigID = 0    -- ConfigID
    self.EndTs = 0    -- 剩余毫秒
    self.Count = 0    -- 本日可挑战次数
    self.CountMax = 0    -- 最大可挑战次数
    self.HpCur = 0    -- 当前血量
    self.Rank = 0    -- 玩家排名
end
function LuaG2C_MansionBoss_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.IsOpen = nbs:ReadBool()
    self.OpenCount = nbs:ReadInt()
    self.ConfigID = nbs:ReadInt()
    self.EndTs = nbs:ReadLong()
    self.Count = nbs:ReadInt()
    self.CountMax = nbs:ReadInt()
    self.HpCur = nbs:ReadLong()
    self.Rank = nbs:ReadInt()
end
-- LuaG2C_MansionBoss_Info end


-- LuaC2G_MansionBoss_Open begin
-- 请求 处理府Boss开启
LuaC2G_MansionBoss_Open = Class(Base)
function LuaC2G_MansionBoss_Open:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_OPEN"]
    self.MansionId = 0    -- 府ID
end
function LuaC2G_MansionBoss_Open:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Open end


-- LuaG2C_MansionBoss_Open begin
-- 返回 处理府Boss开启
LuaG2C_MansionBoss_Open = Class(Base)
function LuaG2C_MansionBoss_Open:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_OPEN"]
end
function LuaG2C_MansionBoss_Open:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_MansionBoss_Open end


-- LuaCLS_MansionBoss_PlayerInfo begin
-- Boss排行玩家信息
LuaCLS_MansionBoss_PlayerInfo = Class()
function LuaCLS_MansionBoss_PlayerInfo:ctor()
    self.Id = 0    -- 玩家ID
    self.Headindex = 0    -- 头像
    self.Name = ""    -- 名字
    self.Hurt = 0    -- 伤害
    self.HurtPer = 0    -- 伤害百分比
end
function LuaCLS_MansionBoss_PlayerInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteInt(self.Headindex)
    nbs:WriteString(self.Name)
    nbs:WriteLong(self.Hurt)
    nbs:WriteFloat(self.HurtPer)
    return nbs
end
function LuaCLS_MansionBoss_PlayerInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.Headindex = nbs:ReadInt()
    self.Name = nbs:ReadString()
    self.Hurt = nbs:ReadLong()
    self.HurtPer = nbs:ReadFloat()
end
-- LuaCLS_MansionBoss_PlayerInfo end


-- LuaC2G_MansionBoss_Top begin
-- 请求 获取府Boss伤害排行
LuaC2G_MansionBoss_Top = Class(Base)
function LuaC2G_MansionBoss_Top:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_TOP"]
    self.MansionId = 0    -- 府ID
end
function LuaC2G_MansionBoss_Top:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Top end


-- LuaG2C_MansionBoss_Top begin
-- 返回 获取府Boss伤害排行
LuaG2C_MansionBoss_Top = Class(Base)
function LuaG2C_MansionBoss_Top:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_TOP"]
    self.TopPlayers = List:New(LuaCLS_MansionBoss_PlayerInfo)    -- 玩家排行
    self.player = LuaCLS_MansionBoss_PlayerInfo.new()    -- 玩家自己
    self.Rank = 0    -- 玩家排名
end
function LuaG2C_MansionBoss_Top:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3805 = nbs:ReadInt()
    for i = 1, var3805 do
        local var3806 = LuaCLS_MansionBoss_PlayerInfo.new()
        var3806:Unserialize(nbs)
        self.TopPlayers:Add(var3806)
    end
    self.player:Unserialize(nbs)
    self.Rank = nbs:ReadInt()
end
-- LuaG2C_MansionBoss_Top end


-- LuaC2G_MansionBoss_Battle begin
-- 请求 处理府Boss进入战斗
LuaC2G_MansionBoss_Battle = Class(Base)
function LuaC2G_MansionBoss_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_BATTLE"]
    self.MansionId = 0    -- 府ID
end
function LuaC2G_MansionBoss_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Battle end


-- LuaG2C_MansionBoss_Battle begin
-- 返回 处理府Boss进入战斗
LuaG2C_MansionBoss_Battle = Class(Base)
function LuaG2C_MansionBoss_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_BATTLE"]
end
function LuaG2C_MansionBoss_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_MansionBoss_Battle end


-- LuaC2G_MansionBoss_Balance begin
-- 请求 处理府Boss战斗结算
LuaC2G_MansionBoss_Balance = Class(Base)
function LuaC2G_MansionBoss_Balance:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_BALANCE"]
    self.MansionId = 0    -- 府ID
    self.HurtHp = 0    -- 造成伤害
    self.BattleKey = 0    -- 战斗Key
    self.PlayerExpendHp = 0    -- 玩家消耗兵力
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
    self.State = 0    -- 战斗结果
end
function LuaC2G_MansionBoss_Balance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteLong(self.HurtHp)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.PlayerExpendHp)
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(self.State)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Balance end


-- LuaG2C_MansionBoss_Balance begin
-- 返回 处理府Boss战斗结算
LuaG2C_MansionBoss_Balance = Class(Base)
function LuaG2C_MansionBoss_Balance:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_BALANCE"]
end
function LuaG2C_MansionBoss_Balance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_MansionBoss_Balance end


-- LuaG2C_MansionBoss_TakeBalance begin
-- 返回 处理府Boss主动战斗结算
LuaG2C_MansionBoss_TakeBalance = Class(Base)
function LuaG2C_MansionBoss_TakeBalance:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_TAKEBALANCE"]
end
function LuaG2C_MansionBoss_TakeBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_MansionBoss_TakeBalance end


-- LuaC2G_MansionBoss_Buff begin
-- 请求 处理府BossBuff信息和购买
LuaC2G_MansionBoss_Buff = Class(Base)
function LuaC2G_MansionBoss_Buff:ctor()
    self._protocol = LuaProtocolId["C2G_MANSIONBOSS_BUFF"]
    self.MansionId = 0    -- 府ID
    self.Config = 0    -- 购买buff配置ID  为0 则是查看信息
end
function LuaC2G_MansionBoss_Buff:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.MansionId)
    nbs:WriteInt(self.Config)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_MansionBoss_Buff end


-- LuaG2C_MansionBoss_Buff begin
-- 返回 处理府BossBuff信息和购买
LuaG2C_MansionBoss_Buff = Class(Base)
function LuaG2C_MansionBoss_Buff:ctor()
    self._protocol = LuaProtocolId["G2C_MANSIONBOSS_BUFF"]
    self.BuffIds = List:New(Luaint)    -- Buffid
    self.CurBuff = Dictionary:New()    -- 已经拥有的buffid，剩余时间
    self.FuYu = 0    -- 拥有的府玉
end
function LuaG2C_MansionBoss_Buff:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3809 = nbs:ReadInt()
    for i = 1, var3809 do
        local var3810 = nbs:ReadInt()
        self.BuffIds:Add(var3810)
    end
    local var3811 = nbs:ReadInt()
    for i = 1, var3811 do
        local var3812 = nbs:ReadInt()
        local var3813 = nbs:ReadLong()
        self.CurBuff:Add(var3812, var3813)
    end
    self.FuYu = nbs:ReadLong()
end
-- LuaG2C_MansionBoss_Buff end


-- LuaCLS_Liveness_Info begin
-- 单条活跃状态
LuaCLS_Liveness_Info = Class()
function LuaCLS_Liveness_Info:ctor()
    self.Num = 0    -- 数值
    self.DictAwardState = Dictionary:New()    -- 是否已经领取
end
function LuaCLS_Liveness_Info:Serialize(nbs)
    nbs:WriteInt(self.Num)
    nbs:WriteInt(#self.DictAwardState)
    for key, value in pairs(self.DictAwardState) do
        nbs:WriteInt(key)
        nbs:WriteBool(value)
    end
    return nbs
end
function LuaCLS_Liveness_Info:Unserialize(nbs)
    self.Num = nbs:ReadInt()
    local var3816 = nbs:ReadInt()
    for i = 1, var3816 do
        local var3817 = nbs:ReadInt()
        local var3818 = nbs:ReadBool()
        self.DictAwardState:Add(var3817, var3818)
    end
end
-- LuaCLS_Liveness_Info end


-- LuaC2G_Guild_GetActive begin
-- 请求 府活跃度
LuaC2G_Guild_GetActive = Class(Base)
function LuaC2G_Guild_GetActive:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_GETACTIVE"]
    self.GuildId = 0    -- 府id
end
function LuaC2G_Guild_GetActive:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.GuildId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_GetActive end


-- LuaG2C_Guild_GetActive begin
-- 返回 府活跃度
LuaG2C_Guild_GetActive = Class(Base)
function LuaG2C_Guild_GetActive:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_GETACTIVE"]
    self.DictLivenessInfo = Dictionary:New()    -- 活跃状态
end
function LuaG2C_Guild_GetActive:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3819 = nbs:ReadInt()
    for i = 1, var3819 do
        local var3820 = nbs:ReadInt()
        local var3821 = LuaCLS_Liveness_Info.new()
        var3821:Unserialize(nbs)
        self.DictLivenessInfo:Add(var3820, var3821)
    end
end
-- LuaG2C_Guild_GetActive end


-- LuaC2G_Guild_ActiveAward begin
-- 请求 府活跃度奖励领取
LuaC2G_Guild_ActiveAward = Class(Base)
function LuaC2G_Guild_ActiveAward:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ACTIVEAWARD"]
    self.GuildId = 0    -- 府id
    self.BoxID = 0    -- 箱子编号
end
function LuaC2G_Guild_ActiveAward:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.GuildId)
    nbs:WriteInt(self.BoxID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ActiveAward end


-- LuaG2C_Guild_ActiveAward begin
-- 返回 府活跃度奖励领取
LuaG2C_Guild_ActiveAward = Class(Base)
function LuaG2C_Guild_ActiveAward:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ACTIVEAWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
    self.DictLivenessInfo = Dictionary:New()    -- 活跃状态
end
function LuaG2C_Guild_ActiveAward:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3822 = nbs:ReadInt()
    for i = 1, var3822 do
        local var3823 = LuaCLS_AwardItem.new()
        var3823:Unserialize(nbs)
        self.ListAward:Add(var3823)
    end
    local var3824 = nbs:ReadInt()
    for i = 1, var3824 do
        local var3825 = nbs:ReadInt()
        local var3826 = LuaCLS_Liveness_Info.new()
        var3826:Unserialize(nbs)
        self.DictLivenessInfo:Add(var3825, var3826)
    end
end
-- LuaG2C_Guild_ActiveAward end


-- LuaC2G_Guild_ActiveAwardAll begin
-- 请求 府活跃度奖励全部领取
LuaC2G_Guild_ActiveAwardAll = Class(Base)
function LuaC2G_Guild_ActiveAwardAll:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_ACTIVEAWARDALL"]
end
function LuaC2G_Guild_ActiveAwardAll:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ActiveAwardAll end


-- LuaG2C_Guild_ActiveAwardAll begin
-- 返回 府活跃度奖励全部领取
LuaG2C_Guild_ActiveAwardAll = Class(Base)
function LuaG2C_Guild_ActiveAwardAll:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_ACTIVEAWARDALL"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
    self.DictLivenessInfo = Dictionary:New()    -- 活跃状态
end
function LuaG2C_Guild_ActiveAwardAll:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3827 = nbs:ReadInt()
    for i = 1, var3827 do
        local var3828 = LuaCLS_AwardItem.new()
        var3828:Unserialize(nbs)
        self.ListAward:Add(var3828)
    end
    local var3829 = nbs:ReadInt()
    for i = 1, var3829 do
        local var3830 = nbs:ReadInt()
        local var3831 = LuaCLS_Liveness_Info.new()
        var3831:Unserialize(nbs)
        self.DictLivenessInfo:Add(var3830, var3831)
    end
end
-- LuaG2C_Guild_ActiveAwardAll end


-- LuaC2G_Guild_ScienceInfo begin
-- 请求 书院信息
LuaC2G_Guild_ScienceInfo = Class(Base)
function LuaC2G_Guild_ScienceInfo:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SCIENCEINFO"]
end
function LuaC2G_Guild_ScienceInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ScienceInfo end


-- LuaG2C_Guild_ScienceInfo begin
-- 返回 书院信息
LuaG2C_Guild_ScienceInfo = Class(Base)
function LuaG2C_Guild_ScienceInfo:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SCIENCEINFO"]
    self.ListTechnology = List:New(Luaint)    -- 科技ID列表
end
function LuaG2C_Guild_ScienceInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3832 = nbs:ReadInt()
    for i = 1, var3832 do
        local var3833 = nbs:ReadInt()
        self.ListTechnology:Add(var3833)
    end
end
-- LuaG2C_Guild_ScienceInfo end


-- LuaC2G_Guild_ScienceLevelUp begin
-- 请求 势力科技升级
LuaC2G_Guild_ScienceLevelUp = Class(Base)
function LuaC2G_Guild_ScienceLevelUp:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SCIENCELEVELUP"]
    self.ID = 0    -- 科技ID
end
function LuaC2G_Guild_ScienceLevelUp:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.ID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ScienceLevelUp end


-- LuaG2C_Guild_ScienceLevelUp begin
-- 返回 势力科技升级
LuaG2C_Guild_ScienceLevelUp = Class(Base)
function LuaG2C_Guild_ScienceLevelUp:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SCIENCELEVELUP"]
end
function LuaG2C_Guild_ScienceLevelUp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Guild_ScienceLevelUp end


-- LuaCLS_GuildShopInfo begin
-- 势力商店信息
LuaCLS_GuildShopInfo = Class()
function LuaCLS_GuildShopInfo:ctor()
    self.GoodsInfo = List:New(LuaCLS_ShopGoodsInfo)    -- 商品信息
    self.Contribution = 0    -- 拥有的贡献
    self.RefreshFreeTotal = 0    -- 累计免费刷新次数
    self.RefreshTotal = 0    -- 累计刷新次数
    self.RefreshItemCount = 0    -- 刷新道具数量
end
function LuaCLS_GuildShopInfo:Serialize(nbs)
    nbs:WriteInt(#self.GoodsInfo)
    for i = 1, #self.GoodsInfo do
        (self.GoodsInfo[i]):Serialize(nbs)
    end
    nbs:WriteInt(self.Contribution)
    nbs:WriteInt(self.RefreshFreeTotal)
    nbs:WriteInt(self.RefreshTotal)
    nbs:WriteInt(self.RefreshItemCount)
    return nbs
end
function LuaCLS_GuildShopInfo:Unserialize(nbs)
    local var3834 = nbs:ReadInt()
    for i = 1, var3834 do
        local var3835 = LuaCLS_ShopGoodsInfo.new()
        var3835:Unserialize(nbs)
        self.GoodsInfo:Add(var3835)
    end
    self.Contribution = nbs:ReadInt()
    self.RefreshFreeTotal = nbs:ReadInt()
    self.RefreshTotal = nbs:ReadInt()
    self.RefreshItemCount = nbs:ReadInt()
end
-- LuaCLS_GuildShopInfo end


-- LuaC2G_Guild_ShopInfo begin
-- 请求 处理势力商店信息
LuaC2G_Guild_ShopInfo = Class(Base)
function LuaC2G_Guild_ShopInfo:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SHOPINFO"]
end
function LuaC2G_Guild_ShopInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ShopInfo end


-- LuaG2C_Guild_ShopInfo begin
-- 返回 处理势力商店信息
LuaG2C_Guild_ShopInfo = Class(Base)
function LuaG2C_Guild_ShopInfo:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SHOPINFO"]
    self.ShopInfo = LuaCLS_GuildShopInfo.new()    -- 商品信息
end
function LuaG2C_Guild_ShopInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ShopInfo:Unserialize(nbs)
end
-- LuaG2C_Guild_ShopInfo end


-- LuaC2G_Guild_ShopBuy begin
-- 请求 处理势力商店购买
LuaC2G_Guild_ShopBuy = Class(Base)
function LuaC2G_Guild_ShopBuy:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SHOPBUY"]
    self.Config = 0    -- 配置ID
    self.Amount = 0    -- 数量
end
function LuaC2G_Guild_ShopBuy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Config)
    nbs:WriteInt(self.Amount)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ShopBuy end


-- LuaG2C_Guild_ShopBuy begin
-- 返回 处理势力商店购买
LuaG2C_Guild_ShopBuy = Class(Base)
function LuaG2C_Guild_ShopBuy:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SHOPBUY"]
    self.ShopInfo = LuaCLS_GuildShopInfo.new()    -- 商品信息
end
function LuaG2C_Guild_ShopBuy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ShopInfo:Unserialize(nbs)
end
-- LuaG2C_Guild_ShopBuy end


-- LuaC2G_Guild_ShopRefresh begin
-- 请求 处理势力商店刷新
LuaC2G_Guild_ShopRefresh = Class(Base)
function LuaC2G_Guild_ShopRefresh:ctor()
    self._protocol = LuaProtocolId["C2G_GUILD_SHOPREFRESH"]
end
function LuaC2G_Guild_ShopRefresh:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Guild_ShopRefresh end


-- LuaG2C_Guild_ShopRefresh begin
-- 返回 处理势力商店刷新
LuaG2C_Guild_ShopRefresh = Class(Base)
function LuaG2C_Guild_ShopRefresh:ctor()
    self._protocol = LuaProtocolId["G2C_GUILD_SHOPREFRESH"]
    self.ShopInfo = LuaCLS_GuildShopInfo.new()    -- 商品信息
end
function LuaG2C_Guild_ShopRefresh:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.ShopInfo:Unserialize(nbs)
end
-- LuaG2C_Guild_ShopRefresh end


-- LuaCLS_GuildSalaryMbsInfo begin
-- 势力成员俸禄信息
LuaCLS_GuildSalaryMbsInfo = Class()
function LuaCLS_GuildSalaryMbsInfo:ctor()
    self.PubPlayerBase = LuaCLS_PubPlayerBase.new()    -- 基本信息
    self.ContributionWeekLast = 0    -- 上周贡献
    self.ContributionWeekThis = 0    -- 本周贡献
end
function LuaCLS_GuildSalaryMbsInfo:Serialize(nbs)
    PubPlayerBase:Serialize(nbs)
    nbs:WriteInt(self.ContributionWeekLast)
    nbs:WriteInt(self.ContributionWeekThis)
    return nbs
end
function LuaCLS_GuildSalaryMbsInfo:Unserialize(nbs)
    self.PubPlayerBase:Unserialize(nbs)
    self.ContributionWeekLast = nbs:ReadInt()
    self.ContributionWeekThis = nbs:ReadInt()
end
-- LuaCLS_GuildSalaryMbsInfo end


-- LuaC2G_GuildSalary_ListMbs begin
-- 请求 俸禄成员列表
LuaC2G_GuildSalary_ListMbs = Class(Base)
function LuaC2G_GuildSalary_ListMbs:ctor()
    self._protocol = LuaProtocolId["C2G_GUILDSALARY_LISTMBS"]
end
function LuaC2G_GuildSalary_ListMbs:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GuildSalary_ListMbs end


-- LuaG2C_GuildSalary_ListMbs begin
-- 返回 俸禄成员列表
LuaG2C_GuildSalary_ListMbs = Class(Base)
function LuaG2C_GuildSalary_ListMbs:ctor()
    self._protocol = LuaProtocolId["G2C_GUILDSALARY_LISTMBS"]
    self.ListMember = List:New(LuaCLS_GuildSalaryMbsInfo)    -- 势力成员列表
end
function LuaG2C_GuildSalary_ListMbs:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DtAutoBalance = nbs:ReadDateTime()
    local var3847 = nbs:ReadInt()
    for i = 1, var3847 do
        local var3848 = LuaCLS_GuildSalaryMbsInfo.new()
        var3848:Unserialize(nbs)
        self.ListMember:Add(var3848)
    end
end
-- LuaG2C_GuildSalary_ListMbs end


-- LuaC2G_GuildSalary_Pay begin
-- 请求 俸禄发放
LuaC2G_GuildSalary_Pay = Class(Base)
function LuaC2G_GuildSalary_Pay:ctor()
    self._protocol = LuaProtocolId["C2G_GUILDSALARY_PAY"]
    self.DictPay = Dictionary:New()    -- <对象玩家ID, 金币数量>
end
function LuaC2G_GuildSalary_Pay:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.DictPay)
    for key, value in pairs(self.DictPay) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GuildSalary_Pay end


-- LuaG2C_GuildSalary_Pay begin
-- 返回 俸禄发放
LuaG2C_GuildSalary_Pay = Class(Base)
function LuaG2C_GuildSalary_Pay:ctor()
    self._protocol = LuaProtocolId["G2C_GUILDSALARY_PAY"]
    self.DictPay = Dictionary:New()    -- <对象玩家ID, 金币数量>
end
function LuaG2C_GuildSalary_Pay:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3849 = nbs:ReadInt()
    for i = 1, var3849 do
        local var3850 = nbs:ReadLong()
        local var3851 = nbs:ReadInt()
        self.DictPay:Add(var3850, var3851)
    end
end
-- LuaG2C_GuildSalary_Pay end


-- LuaCLS_GuildSalaryCityInfo begin
-- 势力城市俸禄信息
LuaCLS_GuildSalaryCityInfo = Class()
function LuaCLS_GuildSalaryCityInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.LeaderPuid = 0    -- 太守Id
    self.LeaderName = ""    -- 太守名字
    self.Prosperity = 0    -- 繁荣度
    self.Revenue = 0    -- 预期收益
end
function LuaCLS_GuildSalaryCityInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.LeaderPuid)
    nbs:WriteString(self.LeaderName)
    nbs:WriteLong(self.Prosperity)
    nbs:WriteInt(self.Revenue)
    return nbs
end
function LuaCLS_GuildSalaryCityInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.LeaderPuid = nbs:ReadLong()
    self.LeaderName = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
    self.Revenue = nbs:ReadInt()
end
-- LuaCLS_GuildSalaryCityInfo end


-- LuaC2G_GuildSalary_ListCity begin
-- 请求 俸禄城市列表
LuaC2G_GuildSalary_ListCity = Class(Base)
function LuaC2G_GuildSalary_ListCity:ctor()
    self._protocol = LuaProtocolId["C2G_GUILDSALARY_LISTCITY"]
end
function LuaC2G_GuildSalary_ListCity:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GuildSalary_ListCity end


-- LuaG2C_GuildSalary_ListCity begin
-- 返回 俸禄城市列表
LuaG2C_GuildSalary_ListCity = Class(Base)
function LuaG2C_GuildSalary_ListCity:ctor()
    self._protocol = LuaProtocolId["G2C_GUILDSALARY_LISTCITY"]
    self.ListCity = List:New(LuaCLS_GuildSalaryCityInfo)    -- 势力城市列表
end
function LuaG2C_GuildSalary_ListCity:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3857 = nbs:ReadInt()
    for i = 1, var3857 do
        local var3858 = LuaCLS_GuildSalaryCityInfo.new()
        var3858:Unserialize(nbs)
        self.ListCity:Add(var3858)
    end
end
-- LuaG2C_GuildSalary_ListCity end


-- LuaCLS_GoddessArmy begin
-- 圣女卫队阵亡信息
LuaCLS_GoddessArmy = Class()
function LuaCLS_GoddessArmy:ctor()
    self.index = 0    -- 卫队编号
end
function LuaCLS_GoddessArmy:Serialize(nbs)
    nbs:WriteInt(self.index)
    nbs:WriteDateTime(self.ReviveTime)
    return nbs
end
function LuaCLS_GoddessArmy:Unserialize(nbs)
    self.index = nbs:ReadInt()
    self.ReviveTime = nbs:ReadDateTime()
end
-- LuaCLS_GoddessArmy end


-- LuaCLS_GoddessInfo begin
-- 圣女信息
LuaCLS_GoddessInfo = Class()
function LuaCLS_GoddessInfo:ctor()
    self.PlayerId = 0    -- 所属玩家Id
    self.PlayerName = ""    -- 所属玩家名
    self.Advance = 0    -- 阶级
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验
    self.CityId = 0    -- 驻守城池
    self.bCaptive = false    -- 是否被俘
    self.OtherId = 0    -- 俘虏方势力Id
    self.OtherName = ""    -- 俘虏方势力名
    self.ArmyInfo = List:New(LuaCLS_GoddessArmy)    -- 卫队阵亡列表
end
function LuaCLS_GoddessInfo:Serialize(nbs)
    nbs:WriteLong(self.PlayerId)
    nbs:WriteString(self.PlayerName)
    nbs:WriteInt(self.Advance)
    nbs:WriteInt(self.Level)
    nbs:WriteInt(self.Exp)
    nbs:WriteInt(self.CityId)
    nbs:WriteBool(self.bCaptive)
    nbs:WriteLong(self.OtherId)
    nbs:WriteString(self.OtherName)
    nbs:WriteDateTime(self.FreeTime)
    nbs:WriteInt(#self.ArmyInfo)
    for i = 1, #self.ArmyInfo do
        (self.ArmyInfo[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_GoddessInfo:Unserialize(nbs)
    self.PlayerId = nbs:ReadLong()
    self.PlayerName = nbs:ReadString()
    self.Advance = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
    self.CityId = nbs:ReadInt()
    self.bCaptive = nbs:ReadBool()
    self.OtherId = nbs:ReadLong()
    self.OtherName = nbs:ReadString()
    self.FreeTime = nbs:ReadDateTime()
    local var3871 = nbs:ReadInt()
    for i = 1, var3871 do
        local var3872 = LuaCLS_GoddessArmy.new()
        var3872:Unserialize(nbs)
        self.ArmyInfo:Add(var3872)
    end
end
-- LuaCLS_GoddessInfo end


-- LuaCLS_GoddessDonate begin
-- 圣女捐献信息
LuaCLS_GoddessDonate = Class()
function LuaCLS_GoddessDonate:ctor()
    self.PlayerName = ""    -- 玩家名
    self.Donate = 0    -- 当前阶段贡献
end
function LuaCLS_GoddessDonate:Serialize(nbs)
    nbs:WriteString(self.PlayerName)
    nbs:WriteInt(self.Donate)
    return nbs
end
function LuaCLS_GoddessDonate:Unserialize(nbs)
    self.PlayerName = nbs:ReadString()
    self.Donate = nbs:ReadInt()
end
-- LuaCLS_GoddessDonate end


-- LuaC2G_Goddess_Seniority begin
-- 请求 圣女资格
LuaC2G_Goddess_Seniority = Class(Base)
function LuaC2G_Goddess_Seniority:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_SENIORITY"]
end
function LuaC2G_Goddess_Seniority:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_Seniority end


-- LuaG2C_Goddess_Seniority begin
-- 返回 圣女资格
LuaG2C_Goddess_Seniority = Class(Base)
function LuaG2C_Goddess_Seniority:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_SENIORITY"]
    self.Info = List:New(LuaCLS_GuildMbsInfo)    -- 拥有资格的成员
end
function LuaG2C_Goddess_Seniority:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3875 = nbs:ReadInt()
    for i = 1, var3875 do
        local var3876 = LuaCLS_GuildMbsInfo.new()
        var3876:Unserialize(nbs)
        self.Info:Add(var3876)
    end
end
-- LuaG2C_Goddess_Seniority end


-- LuaC2G_Goddess_GetInfo begin
-- 请求 圣女信息
LuaC2G_Goddess_GetInfo = Class(Base)
function LuaC2G_Goddess_GetInfo:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_GETINFO"]
end
function LuaC2G_Goddess_GetInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_GetInfo end


-- LuaG2C_Goddess_GetInfo begin
-- 返回 圣女信息
LuaG2C_Goddess_GetInfo = Class(Base)
function LuaG2C_Goddess_GetInfo:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_GETINFO"]
    self.Info = LuaCLS_GoddessInfo.new()    -- 圣女
    self.DonateInfo = List:New(LuaCLS_GoddessDonate)    -- 贡献列表
    self.DictDonate = Dictionary:New()    -- 捐献次数(key=捐献id value=今日次数)
end
function LuaG2C_Goddess_GetInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
    local var3878 = nbs:ReadInt()
    for i = 1, var3878 do
        local var3879 = LuaCLS_GoddessDonate.new()
        var3879:Unserialize(nbs)
        self.DonateInfo:Add(var3879)
    end
    local var3880 = nbs:ReadInt()
    for i = 1, var3880 do
        local var3881 = nbs:ReadInt()
        local var3882 = nbs:ReadInt()
        self.DictDonate:Add(var3881, var3882)
    end
end
-- LuaG2C_Goddess_GetInfo end


-- LuaC2G_Goddess_Choose begin
-- 请求 圣女选择
LuaC2G_Goddess_Choose = Class(Base)
function LuaC2G_Goddess_Choose:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_CHOOSE"]
    self.PlayerId = 0    -- 拥有资格的成员ID
end
function LuaC2G_Goddess_Choose:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.PlayerId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_Choose end


-- LuaG2C_Goddess_Choose begin
-- 返回 圣女选择
LuaG2C_Goddess_Choose = Class(Base)
function LuaG2C_Goddess_Choose:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_CHOOSE"]
    self.Info = LuaCLS_GoddessInfo.new()    -- 圣女
end
function LuaG2C_Goddess_Choose:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
end
-- LuaG2C_Goddess_Choose end


-- LuaC2G_Goddess_Donate begin
-- 请求 圣女捐献
LuaC2G_Goddess_Donate = Class(Base)
function LuaC2G_Goddess_Donate:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_DONATE"]
    self.DonateId = 0
end
function LuaC2G_Goddess_Donate:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DonateId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_Donate end


-- LuaG2C_Goddess_Donate begin
-- 返回 圣女捐献
LuaG2C_Goddess_Donate = Class(Base)
function LuaG2C_Goddess_Donate:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_DONATE"]
    self.Advance = 0    -- 阶级
    self.Level = 0    -- 等级
    self.Exp = 0    -- 经验
    self.DonateInfo = List:New(LuaCLS_GoddessDonate)    -- 贡献列表
    self.DictDonate = Dictionary:New()    -- 捐献次数(key=捐献id value=今日次数)
end
function LuaG2C_Goddess_Donate:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Advance = nbs:ReadInt()
    self.Level = nbs:ReadInt()
    self.Exp = nbs:ReadInt()
    local var3887 = nbs:ReadInt()
    for i = 1, var3887 do
        local var3888 = LuaCLS_GoddessDonate.new()
        var3888:Unserialize(nbs)
        self.DonateInfo:Add(var3888)
    end
    local var3889 = nbs:ReadInt()
    for i = 1, var3889 do
        local var3890 = nbs:ReadInt()
        local var3891 = nbs:ReadInt()
        self.DictDonate:Add(var3890, var3891)
    end
end
-- LuaG2C_Goddess_Donate end


-- LuaC2G_Goddess_Save begin
-- 请求 圣女赎回
LuaC2G_Goddess_Save = Class(Base)
function LuaC2G_Goddess_Save:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_SAVE"]
    self.DonateId = 0
end
function LuaC2G_Goddess_Save:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.DonateId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_Save end


-- LuaG2C_Goddess_Save begin
-- 返回 圣女赎回
LuaG2C_Goddess_Save = Class(Base)
function LuaG2C_Goddess_Save:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_SAVE"]
    self.Info = LuaCLS_GoddessInfo.new()    -- 圣女
    self.DonateInfo = List:New(LuaCLS_GoddessDonate)    -- 赎回列表
    self.DictDonate = Dictionary:New()    -- 赎回次数(key=捐献id value=今日次数)
end
function LuaG2C_Goddess_Save:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Info:Unserialize(nbs)
    local var3893 = nbs:ReadInt()
    for i = 1, var3893 do
        local var3894 = LuaCLS_GoddessDonate.new()
        var3894:Unserialize(nbs)
        self.DonateInfo:Add(var3894)
    end
    local var3895 = nbs:ReadInt()
    for i = 1, var3895 do
        local var3896 = nbs:ReadInt()
        local var3897 = nbs:ReadInt()
        self.DictDonate:Add(var3896, var3897)
    end
end
-- LuaG2C_Goddess_Save end


-- LuaC2G_Goddess_Defend begin
-- 请求 圣女驻守
LuaC2G_Goddess_Defend = Class(Base)
function LuaC2G_Goddess_Defend:ctor()
    self._protocol = LuaProtocolId["C2G_GODDESS_DEFEND"]
    self.CityId = 0    -- 驻守城池
end
function LuaC2G_Goddess_Defend:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Goddess_Defend end


-- LuaG2C_Goddess_Defend begin
-- 返回 圣女驻守
LuaG2C_Goddess_Defend = Class(Base)
function LuaG2C_Goddess_Defend:ctor()
    self._protocol = LuaProtocolId["G2C_GODDESS_DEFEND"]
    self.CityId = 0    -- 驻守城池
end
function LuaG2C_Goddess_Defend:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityId = nbs:ReadInt()
end
-- LuaG2C_Goddess_Defend end


-- LuaC2G_Warrior_InBattle begin
-- 请求 武将上阵PVE
LuaC2G_Warrior_InBattle = Class(Base)
function LuaC2G_Warrior_InBattle:ctor()
    self._protocol = LuaProtocolId["C2G_WARRIOR_INBATTLE"]
    self.ListInBattle = List:New(Lualong)    -- 上阵列表
end
function LuaC2G_Warrior_InBattle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.ListInBattle)
    for i = 1, #self.ListInBattle do
        nbs:WriteLong(self.ListInBattle[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Warrior_InBattle end


-- LuaG2C_Warrior_InBattle begin
-- 返回 武将上阵PVE
LuaG2C_Warrior_InBattle = Class(Base)
function LuaG2C_Warrior_InBattle:ctor()
    self._protocol = LuaProtocolId["G2C_WARRIOR_INBATTLE"]
end
function LuaG2C_Warrior_InBattle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Warrior_InBattle end


-- LuaCLS_ArmyInfo begin
-- 单个队伍信息
LuaCLS_ArmyInfo = Class()
function LuaCLS_ArmyInfo:ctor()
    self.ArmyId = 0    -- PVE阵容ID(012)
    self.DictWarrior = Dictionary:New()    -- 成员列表 <位置 武将唯一ID>
end
function LuaCLS_ArmyInfo:Serialize(nbs)
    nbs:WriteInt(self.ArmyId)
    nbs:WriteInt(#self.DictWarrior)
    for key, value in pairs(self.DictWarrior) do
        nbs:WriteInt(key)
        nbs:WriteLong(value)
    end
    return nbs
end
function LuaCLS_ArmyInfo:Unserialize(nbs)
    self.ArmyId = nbs:ReadInt()
    local var3900 = nbs:ReadInt()
    for i = 1, var3900 do
        local var3901 = nbs:ReadInt()
        local var3902 = nbs:ReadLong()
        self.DictWarrior:Add(var3901, var3902)
    end
end
-- LuaCLS_ArmyInfo end


-- LuaCLS_PveTypeArmyInfo begin
-- PVE某种战斗类型队伍信息
LuaCLS_PveTypeArmyInfo = Class()
function LuaCLS_PveTypeArmyInfo:ctor()
    self.PveType = 0    -- PVE类型(ETeamType)
    self.PveArmyId = 0    -- 当前PVE阵容ID(012)
    self.DictArmyInfo = Dictionary:New()    -- k=ArmyId v=ArmyInfo
end
function LuaCLS_PveTypeArmyInfo:Serialize(nbs)
    nbs:WriteInt(self.PveType)
    nbs:WriteInt(self.PveArmyId)
    nbs:WriteInt(#self.DictArmyInfo)
    for key, value in pairs(self.DictArmyInfo) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_PveTypeArmyInfo:Unserialize(nbs)
    self.PveType = nbs:ReadInt()
    self.PveArmyId = nbs:ReadInt()
    local var3905 = nbs:ReadInt()
    for i = 1, var3905 do
        local var3906 = nbs:ReadInt()
        local var3907 = LuaCLS_ArmyInfo.new()
        var3907:Unserialize(nbs)
        self.DictArmyInfo:Add(var3906, var3907)
    end
end
-- LuaCLS_PveTypeArmyInfo end


-- LuaC2G_Pve_ArmyInfo begin
-- 请求 PVE阵容信息
LuaC2G_Pve_ArmyInfo = Class(Base)
function LuaC2G_Pve_ArmyInfo:ctor()
    self._protocol = LuaProtocolId["C2G_PVE_ARMYINFO"]
    self.PveType = 0    -- PVE类型
end
function LuaC2G_Pve_ArmyInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.PveType)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Pve_ArmyInfo end


-- LuaG2C_Pve_ArmyInfo begin
-- 返回 PVE阵容信息
LuaG2C_Pve_ArmyInfo = Class(Base)
function LuaG2C_Pve_ArmyInfo:ctor()
    self._protocol = LuaProtocolId["G2C_PVE_ARMYINFO"]
    self.PveType = 0    -- PVE类型(ETeamType)
    self.PveArmyId = 0    -- 当前PVE阵容ID(012)
    self.DictArmyInfo = Dictionary:New()    -- k=ArmyId v=ArmyInfo
end
function LuaG2C_Pve_ArmyInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PveType = nbs:ReadInt()
    self.PveArmyId = nbs:ReadInt()
    local var3910 = nbs:ReadInt()
    for i = 1, var3910 do
        local var3911 = nbs:ReadInt()
        local var3912 = LuaCLS_ArmyInfo.new()
        var3912:Unserialize(nbs)
        self.DictArmyInfo:Add(var3911, var3912)
    end
end
-- LuaG2C_Pve_ArmyInfo end


-- LuaC2G_Pve_ArmyChange begin
-- 请求 PVE阵容更改
LuaC2G_Pve_ArmyChange = Class(Base)
function LuaC2G_Pve_ArmyChange:ctor()
    self._protocol = LuaProtocolId["C2G_PVE_ARMYCHANGE"]
    self.PveType = 0    -- PVE类型(ETeamType)
    self.PveArmyId = 0    -- 当前PVE阵容ID(012)
    self.DictArmyInfo = Dictionary:New()    -- k=ArmyId v=ArmyInfo
end
function LuaC2G_Pve_ArmyChange:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.PveType)
    nbs:WriteInt(self.PveArmyId)
    nbs:WriteInt(#self.DictArmyInfo)
    for key, value in pairs(self.DictArmyInfo) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Pve_ArmyChange end


-- LuaG2C_Pve_ArmyChange begin
-- 返回 PVE阵容更改
LuaG2C_Pve_ArmyChange = Class(Base)
function LuaG2C_Pve_ArmyChange:ctor()
    self._protocol = LuaProtocolId["G2C_PVE_ARMYCHANGE"]
    self.PveType = 0    -- PVE类型(ETeamType)
end
function LuaG2C_Pve_ArmyChange:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PveType = nbs:ReadInt()
end
-- LuaG2C_Pve_ArmyChange end


-- LuaC2G_Pve_GoBattle begin
-- 请求 PVE出征
LuaC2G_Pve_GoBattle = Class(Base)
function LuaC2G_Pve_GoBattle:ctor()
    self._protocol = LuaProtocolId["C2G_PVE_GOBATTLE"]
    self.PveType = 0    -- PVE类型(ETeamType)
    self.BattleId = 0    -- 对应战斗内容ID
end
function LuaC2G_Pve_GoBattle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.PveType)
    nbs:WriteInt(self.BattleId)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Pve_GoBattle end


-- LuaG2C_Pve_GoBattle begin
-- 返回 PVE出征
LuaG2C_Pve_GoBattle = Class(Base)
function LuaG2C_Pve_GoBattle:ctor()
    self._protocol = LuaProtocolId["G2C_PVE_GOBATTLE"]
    self.PveType = 0    -- PVE类型(ETeamType)
    self.BattleId = 0    -- 对应战斗内容ID
    self.BattleCode = 0    -- 战斗验证码
    self.DictWarrior = Dictionary:New()    -- 成员列表 <位置 武将战斗信息>
end
function LuaG2C_Pve_GoBattle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PveType = nbs:ReadInt()
    self.BattleId = nbs:ReadInt()
    self.BattleCode = nbs:ReadLong()
    local var3917 = nbs:ReadInt()
    for i = 1, var3917 do
        local var3918 = nbs:ReadInt()
        local var3919 = LuaCLS_WarriorInfo.new()
        var3919:Unserialize(nbs)
        self.DictWarrior:Add(var3918, var3919)
    end
end
-- LuaG2C_Pve_GoBattle end


-- LuaG2C_Pve_BattleBalance begin
-- 推送 战斗结束武将数据
LuaG2C_Pve_BattleBalance = Class(Base)
function LuaG2C_Pve_BattleBalance:ctor()
    self._protocol = LuaProtocolId["G2C_PVE_BATTLEBALANCE"]
    self.PveType = 0    -- PVE类型(ETeamType)
    self.DictWarrior = Dictionary:New()    -- 成员列表 <位置 武将战斗信息>
end
function LuaG2C_Pve_BattleBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PveType = nbs:ReadInt()
    local var3921 = nbs:ReadInt()
    for i = 1, var3921 do
        local var3922 = nbs:ReadInt()
        local var3923 = LuaCLS_WarriorInfo.new()
        var3923:Unserialize(nbs)
        self.DictWarrior:Add(var3922, var3923)
    end
end
-- LuaG2C_Pve_BattleBalance end


-- LuaCLS_StoryState begin
-- 剧情关卡结果
LuaCLS_StoryState = Class()
function LuaCLS_StoryState:ctor()
    self.ListState = List:New(Luabool)    -- 战斗结果
    self.Ticks = 0    -- 日挑战次数
end
function LuaCLS_StoryState:Serialize(nbs)
    nbs:WriteInt(#self.ListState)
    for i = 1, #self.ListState do
        nbs:WriteBool(self.ListState[i])
    end
    nbs:WriteInt(self.Ticks)
    return nbs
end
function LuaCLS_StoryState:Unserialize(nbs)
    local var3924 = nbs:ReadInt()
    for i = 1, var3924 do
        local var3925 = nbs:ReadBool()
        self.ListState:Add(var3925)
    end
    self.Ticks = nbs:ReadInt()
end
-- LuaCLS_StoryState end


-- LuaC2G_GameLevelStory_Info begin
-- 请求 剧情关卡列表
LuaC2G_GameLevelStory_Info = Class(Base)
function LuaC2G_GameLevelStory_Info:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORY_INFO"]
    self.StoryID = 0    -- 章节ID
end
function LuaC2G_GameLevelStory_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.StoryID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStory_Info end


-- LuaG2C_GameLevelStory_Info begin
-- 返回 剧情关卡列表
LuaG2C_GameLevelStory_Info = Class(Base)
function LuaG2C_GameLevelStory_Info:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORY_INFO"]
    self.DicStory = Dictionary:New()    -- 副本字典<关卡ID，通关状态>
    self.Power = 0    -- 体力
    self.RecoveryTime = 0    -- 恢复时间
    self.ListReward = List:New(Luabool)    -- 奖励是否已经领取
    self.BuyCount = 0    -- 购买次数
end
function LuaG2C_GameLevelStory_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3927 = nbs:ReadInt()
    for i = 1, var3927 do
        local var3928 = nbs:ReadInt()
        local var3929 = LuaCLS_StoryState.new()
        var3929:Unserialize(nbs)
        self.DicStory:Add(var3928, var3929)
    end
    self.Power = nbs:ReadInt()
    self.RecoveryTime = nbs:ReadLong()
    local var3932 = nbs:ReadInt()
    for i = 1, var3932 do
        local var3933 = nbs:ReadBool()
        self.ListReward:Add(var3933)
    end
    self.BuyCount = nbs:ReadInt()
end
-- LuaG2C_GameLevelStory_Info end


-- LuaC2G_GameLevelStory_Battle begin
-- 请求 剧情副本战斗
LuaC2G_GameLevelStory_Battle = Class(Base)
function LuaC2G_GameLevelStory_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORY_BATTLE"]
    self.Id = 0    -- 副本ID
end
function LuaC2G_GameLevelStory_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStory_Battle end


-- LuaG2C_GameLevelStory_Battle begin
-- 返回 剧情副本战斗
LuaG2C_GameLevelStory_Battle = Class(Base)
function LuaG2C_GameLevelStory_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORY_BATTLE"]
    self.Id = 0    -- 关卡ID
end
function LuaG2C_GameLevelStory_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
end
-- LuaG2C_GameLevelStory_Battle end


-- LuaC2G_GameLevelStory_Balance begin
-- 请求 剧情副本结算
LuaC2G_GameLevelStory_Balance = Class(Base)
function LuaC2G_GameLevelStory_Balance:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORY_BALANCE"]
    self.BattleKey = 0    -- 战斗Key
    self.PlayerExpendHp = 0    -- 玩家消耗兵力
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
    self.ListState = List:New(Luabool)    -- 战斗星级结果
    self.State = 0    -- 战斗结果
end
function LuaC2G_GameLevelStory_Balance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.PlayerExpendHp)
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(#self.ListState)
    for i = 1, #self.ListState do
        nbs:WriteBool(self.ListState[i])
    end
    nbs:WriteInt(self.State)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStory_Balance end


-- LuaG2C_GameLevelStory_Balance begin
-- 返回 剧情副本结算
LuaG2C_GameLevelStory_Balance = Class(Base)
function LuaG2C_GameLevelStory_Balance:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORY_BALANCE"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 结算奖励列表
end
function LuaG2C_GameLevelStory_Balance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3936 = nbs:ReadInt()
    for i = 1, var3936 do
        local var3937 = LuaCLS_AwardItem.new()
        var3937:Unserialize(nbs)
        self.ListAward:Add(var3937)
    end
end
-- LuaG2C_GameLevelStory_Balance end


-- LuaC2G_GameLevelStory_Reward begin
-- 请求 剧情副本领取奖励
LuaC2G_GameLevelStory_Reward = Class(Base)
function LuaC2G_GameLevelStory_Reward:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORY_REWARD"]
    self.StoryID = 0    -- 章节ID
    self.Index = 0    -- 箱子编号（0,1,2）
end
function LuaC2G_GameLevelStory_Reward:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.StoryID)
    nbs:WriteInt(self.Index)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStory_Reward end


-- LuaG2C_GameLevelStory_Reward begin
-- 返回 剧情副本领取奖励
LuaG2C_GameLevelStory_Reward = Class(Base)
function LuaG2C_GameLevelStory_Reward:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORY_REWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 结算奖励列表
end
function LuaG2C_GameLevelStory_Reward:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3938 = nbs:ReadInt()
    for i = 1, var3938 do
        local var3939 = LuaCLS_AwardItem.new()
        var3939:Unserialize(nbs)
        self.ListAward:Add(var3939)
    end
end
-- LuaG2C_GameLevelStory_Reward end


-- LuaC2G_GameLevelStoryBuyPower begin
-- 请求 剧情副本购买体力
LuaC2G_GameLevelStoryBuyPower = Class(Base)
function LuaC2G_GameLevelStoryBuyPower:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORYBUYPOWER"]
end
function LuaC2G_GameLevelStoryBuyPower:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStoryBuyPower end


-- LuaG2C_GameLevelStoryBuyPower begin
-- 返回 剧情副本购买体力
LuaG2C_GameLevelStoryBuyPower = Class(Base)
function LuaG2C_GameLevelStoryBuyPower:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORYBUYPOWER"]
    self.Power = 0    -- 体力
    self.RecoveryTime = 0    -- 恢复时间
    self.BuyCount = 0    -- 购买次数
end
function LuaG2C_GameLevelStoryBuyPower:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Power = nbs:ReadInt()
    self.RecoveryTime = nbs:ReadLong()
    self.BuyCount = nbs:ReadInt()
end
-- LuaG2C_GameLevelStoryBuyPower end


-- LuaC2G_GameLevelStory begin
-- 请求 剧情章节列表
LuaC2G_GameLevelStory = Class(Base)
function LuaC2G_GameLevelStory:ctor()
    self._protocol = LuaProtocolId["C2G_GAMELEVELSTORY"]
end
function LuaC2G_GameLevelStory:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_GameLevelStory end


-- LuaG2C_GameLevelStory begin
-- 返回 剧情章节列表
LuaG2C_GameLevelStory = Class(Base)
function LuaG2C_GameLevelStory:ctor()
    self._protocol = LuaProtocolId["G2C_GAMELEVELSTORY"]
    self.StoryID = 0    -- 当前章节ID
    self.Power = 0    -- 体力
    self.RecoveryTime = 0    -- 恢复时间
    self.BuyCount = 0    -- 购买次数
end
function LuaG2C_GameLevelStory:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.StoryID = nbs:ReadInt()
    self.Power = nbs:ReadInt()
    self.RecoveryTime = nbs:ReadLong()
    self.BuyCount = nbs:ReadInt()
end
-- LuaG2C_GameLevelStory end


-- LuaCLS_TowerInfo begin
-- 单层信息
LuaCLS_TowerInfo = Class()
function LuaCLS_TowerInfo:ctor()
    self.Id = 0    -- ConfigId
    self.TowerState = 0    -- ETowerState
end
function LuaCLS_TowerInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteByte(self.TowerState)
    return nbs
end
function LuaCLS_TowerInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.TowerState = nbs:ReadByte()
end
-- LuaCLS_TowerInfo end


-- LuaC2G_Tower_Info begin
-- 请求 古塔信息
LuaC2G_Tower_Info = Class(Base)
function LuaC2G_Tower_Info:ctor()
    self._protocol = LuaProtocolId["C2G_TOWER_INFO"]
end
function LuaC2G_Tower_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Tower_Info end


-- LuaG2C_Tower_Info begin
-- 返回 古塔信息
LuaG2C_Tower_Info = Class(Base)
function LuaG2C_Tower_Info:ctor()
    self._protocol = LuaProtocolId["G2C_TOWER_INFO"]
    self.LevelStart = 0    -- 可进入等级
    self.TowerToken = 0    -- 挑战令牌
    self.TowerTokenMax = 0    -- 挑战令牌上限
    self.TowerTokenOnceUse = 0    -- 古塔挑战令牌单次消耗
    self.ListTowerInfo = List:New(LuaCLS_TowerInfo)    -- 层信息
end
function LuaG2C_Tower_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.LevelStart = nbs:ReadInt()
    self.TowerToken = nbs:ReadInt()
    self.TowerTokenMax = nbs:ReadInt()
    self.TowerTokenOnceUse = nbs:ReadInt()
    local var3953 = nbs:ReadInt()
    for i = 1, var3953 do
        local var3954 = LuaCLS_TowerInfo.new()
        var3954:Unserialize(nbs)
        self.ListTowerInfo:Add(var3954)
    end
end
-- LuaG2C_Tower_Info end


-- LuaC2G_Tower_Battle begin
-- 请求 古塔战斗
LuaC2G_Tower_Battle = Class(Base)
function LuaC2G_Tower_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_TOWER_BATTLE"]
    self.Id = 0    -- ConfigId
end
function LuaC2G_Tower_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Tower_Battle end


-- LuaG2C_Tower_Battle begin
-- 返回 古塔战斗
LuaG2C_Tower_Battle = Class(Base)
function LuaG2C_Tower_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_TOWER_BATTLE"]
    self.Id = 0    -- ConfigId
end
function LuaG2C_Tower_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
end
-- LuaG2C_Tower_Battle end


-- LuaC2G_Tower_BattleEnd begin
-- 请求 古塔战斗结束
LuaC2G_Tower_BattleEnd = Class(Base)
function LuaC2G_Tower_BattleEnd:ctor()
    self._protocol = LuaProtocolId["C2G_TOWER_BATTLEEND"]
    self.Id = 0    -- ConfigId
    self.BattleKey = 0    -- 战斗Key
    self.PlayerExpendHp = 0    -- 玩家消耗兵力
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
    self.State = 0    -- 战斗结果
    self.BattleRecord = ""    -- 战斗记录
end
function LuaC2G_Tower_BattleEnd:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.PlayerExpendHp)
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(self.State)
    nbs:WriteString(self.BattleRecord)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Tower_BattleEnd end


-- LuaG2C_Tower_BattleEnd begin
-- 返回 古塔战斗结束
LuaG2C_Tower_BattleEnd = Class(Base)
function LuaG2C_Tower_BattleEnd:ctor()
    self._protocol = LuaProtocolId["G2C_TOWER_BATTLEEND"]
    self.Id = 0    -- ConfigId
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Tower_BattleEnd:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    local var3957 = nbs:ReadInt()
    for i = 1, var3957 do
        local var3958 = LuaCLS_AwardItem.new()
        var3958:Unserialize(nbs)
        self.ListAward:Add(var3958)
    end
end
-- LuaG2C_Tower_BattleEnd end


-- LuaCLS_ArenaTopData begin
-- Arena排行榜信息
LuaCLS_ArenaTopData = Class()
function LuaCLS_ArenaTopData:ctor()
    self.Rank = 0    -- 排行
    self.Puid = 0    -- 唯一ID
    self.Name = ""    -- 名字
    self.GuildName = ""    -- 势力名字
    self.Score = 0    -- 分数
    self.HeadIndex = 0    -- 头像ID
    self.Level = 0    -- 等级 排行榜用
end
function LuaCLS_ArenaTopData:Serialize(nbs)
    nbs:WriteInt(self.Rank)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteString(self.GuildName)
    nbs:WriteInt(self.Score)
    nbs:WriteInt(self.HeadIndex)
    nbs:WriteInt(self.Level)
    return nbs
end
function LuaCLS_ArenaTopData:Unserialize(nbs)
    self.Rank = nbs:ReadInt()
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.GuildName = nbs:ReadString()
    self.Score = nbs:ReadInt()
    self.HeadIndex = nbs:ReadInt()
    self.Level = nbs:ReadInt()
end
-- LuaCLS_ArenaTopData end


-- LuaC2G_Arena_Info begin
-- 请求 获取竞技场信息
LuaC2G_Arena_Info = Class(Base)
function LuaC2G_Arena_Info:ctor()
    self._protocol = LuaProtocolId["C2G_ARENA_INFO"]
end
function LuaC2G_Arena_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Arena_Info end


-- LuaG2C_Arena_Info begin
-- 返回 获取竞技场信息
LuaG2C_Arena_Info = Class(Base)
function LuaG2C_Arena_Info:ctor()
    self._protocol = LuaProtocolId["G2C_ARENA_INFO"]
    self.Rank = 0    -- 排名
    self.HistoryRank = 0    -- 历史排名
    self.WinRate = 0    -- 胜率
    self.MatchTicks = 0    -- 挑战次数
    self.MaxTicks = 0    -- 最大挑战次数
    self.BuyMatchTicks = 0    -- 竞技场已购买次数
    self.ArenaMatchPlayers = List:New(LuaCLS_ArenaTopData)    -- 匹配的玩家
    self.TsEnd = 0    -- 挑战刷新剩余时间
end
function LuaG2C_Arena_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Rank = nbs:ReadInt()
    self.HistoryRank = nbs:ReadInt()
    self.WinRate = nbs:ReadFloat()
    self.MatchTicks = nbs:ReadInt()
    self.MaxTicks = nbs:ReadInt()
    self.BuyMatchTicks = nbs:ReadInt()
    local var3972 = nbs:ReadInt()
    for i = 1, var3972 do
        local var3973 = LuaCLS_ArenaTopData.new()
        var3973:Unserialize(nbs)
        self.ArenaMatchPlayers:Add(var3973)
    end
    self.TsEnd = nbs:ReadLong()
end
-- LuaG2C_Arena_Info end


-- LuaC2G_Arena_TOP begin
-- 请求 获取竞技场排行榜
LuaC2G_Arena_TOP = Class(Base)
function LuaC2G_Arena_TOP:ctor()
    self._protocol = LuaProtocolId["C2G_ARENA_TOP"]
end
function LuaC2G_Arena_TOP:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Arena_TOP end


-- LuaG2C_Arena_TOP begin
-- 返回 Arena排行榜
LuaG2C_Arena_TOP = Class(Base)
function LuaG2C_Arena_TOP:ctor()
    self._protocol = LuaProtocolId["G2C_ARENA_TOP"]
    self.ListArenaTopData = List:New(LuaCLS_ArenaTopData)    -- Arena排行榜数据
    self.PlayerData = LuaCLS_ArenaTopData.new()    -- 玩家数据
end
function LuaG2C_Arena_TOP:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3975 = nbs:ReadInt()
    for i = 1, var3975 do
        local var3976 = LuaCLS_ArenaTopData.new()
        var3976:Unserialize(nbs)
        self.ListArenaTopData:Add(var3976)
    end
    self.PlayerData:Unserialize(nbs)
end
-- LuaG2C_Arena_TOP end


-- LuaC2G_ArenaMatch_Refresh begin
-- 请求 Arena刷新
LuaC2G_ArenaMatch_Refresh = Class(Base)
function LuaC2G_ArenaMatch_Refresh:ctor()
    self._protocol = LuaProtocolId["C2G_ARENAMATCH_REFRESH"]
end
function LuaC2G_ArenaMatch_Refresh:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ArenaMatch_Refresh end


-- LuaG2C_ArenaMatch_Refresh begin
-- 返回 Arena刷新
LuaG2C_ArenaMatch_Refresh = Class(Base)
function LuaG2C_ArenaMatch_Refresh:ctor()
    self._protocol = LuaProtocolId["G2C_ARENAMATCH_REFRESH"]
end
function LuaG2C_ArenaMatch_Refresh:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_ArenaMatch_Refresh end


-- LuaC2G_ArenaMatch_Battle begin
-- 请求 Arena战斗
LuaC2G_ArenaMatch_Battle = Class(Base)
function LuaC2G_ArenaMatch_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_ARENAMATCH_BATTLE"]
    self.index = 0    -- 挑战的第几位玩家 0,1,2,3
end
function LuaC2G_ArenaMatch_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.index)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ArenaMatch_Battle end


-- LuaG2C_ArenaMatch_Battle begin
-- 返回 Arena战斗
LuaG2C_ArenaMatch_Battle = Class(Base)
function LuaG2C_ArenaMatch_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_ARENAMATCH_BATTLE"]
    self.StageId = 0    -- 关卡配置 0则是玩家
    self.ListWarriorOther = List:New(LuaCLS_WarriorInfo)    -- 对战武将战斗信息列表
end
function LuaG2C_ArenaMatch_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.StageId = nbs:ReadInt()
    local var3979 = nbs:ReadInt()
    for i = 1, var3979 do
        local var3980 = LuaCLS_WarriorInfo.new()
        var3980:Unserialize(nbs)
        self.ListWarriorOther:Add(var3980)
    end
end
-- LuaG2C_ArenaMatch_Battle end


-- LuaC2G_ArenaMatch_Balance begin
-- 请求 Arena结算
LuaC2G_ArenaMatch_Balance = Class(Base)
function LuaC2G_ArenaMatch_Balance:ctor()
    self._protocol = LuaProtocolId["C2G_ARENAMATCH_BALANCE"]
    self.BattleKey = 0    -- 战斗Key
    self.State = 0    -- 战斗结果
end
function LuaC2G_ArenaMatch_Balance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.State)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ArenaMatch_Balance end


-- LuaG2C_ArenaMatch_Balance begin
-- 返回 Arena结算
LuaG2C_ArenaMatch_Balance = Class(Base)
function LuaG2C_ArenaMatch_Balance:ctor()
    self._protocol = LuaProtocolId["G2C_ARENAMATCH_BALANCE"]
    self.PlayerRank = 0    -- 玩家当前排名
    self.PlayerNewRank = 0    -- 玩家新排名
    self.AwardItem = List:New(LuaCLS_AwardItem)    -- 奖励
end
function LuaG2C_ArenaMatch_Balance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PlayerRank = nbs:ReadInt()
    self.PlayerNewRank = nbs:ReadInt()
    local var3983 = nbs:ReadInt()
    for i = 1, var3983 do
        local var3984 = LuaCLS_AwardItem.new()
        var3984:Unserialize(nbs)
        self.AwardItem:Add(var3984)
    end
end
-- LuaG2C_ArenaMatch_Balance end


-- LuaCLS_ArenaBattleReport begin
-- Arena战报单条信息
LuaCLS_ArenaBattleReport = Class()
function LuaCLS_ArenaBattleReport:ctor()
    self.Victory = false    -- 胜利
    self.IsAttack = false    -- 是否是进攻
    self.MatchPlayerName = ""    -- 名字
    self.MatchPlayerHeadIndex = 0    -- 头像
    self.GuildName = ""    -- 势力名称
    self.Rank = 0    -- 排名变化
    self.CurRank = 0    -- 当前排名
end
function LuaCLS_ArenaBattleReport:Serialize(nbs)
    nbs:WriteBool(self.Victory)
    nbs:WriteBool(self.IsAttack)
    nbs:WriteString(self.MatchPlayerName)
    nbs:WriteInt(self.MatchPlayerHeadIndex)
    nbs:WriteString(self.GuildName)
    nbs:WriteFloat(self.Rank)
    nbs:WriteInt(self.CurRank)
    return nbs
end
function LuaCLS_ArenaBattleReport:Unserialize(nbs)
    self.Victory = nbs:ReadBool()
    self.IsAttack = nbs:ReadBool()
    self.MatchPlayerName = nbs:ReadString()
    self.MatchPlayerHeadIndex = nbs:ReadInt()
    self.GuildName = nbs:ReadString()
    self.Rank = nbs:ReadFloat()
    self.CurRank = nbs:ReadInt()
end
-- LuaCLS_ArenaBattleReport end


-- LuaC2G_ArenaBattleReport begin
-- 请求 Arena战报
LuaC2G_ArenaBattleReport = Class(Base)
function LuaC2G_ArenaBattleReport:ctor()
    self._protocol = LuaProtocolId["C2G_ARENABATTLEREPORT"]
end
function LuaC2G_ArenaBattleReport:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ArenaBattleReport end


-- LuaG2C_ArenaBattleReport begin
-- 返回 Arena战报
LuaG2C_ArenaBattleReport = Class(Base)
function LuaG2C_ArenaBattleReport:ctor()
    self._protocol = LuaProtocolId["G2C_ARENABATTLEREPORT"]
    self.ArenaBattleReportList = List:New(LuaCLS_ArenaBattleReport)    -- 战报列表
end
function LuaG2C_ArenaBattleReport:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3992 = nbs:ReadInt()
    for i = 1, var3992 do
        local var3993 = LuaCLS_ArenaBattleReport.new()
        var3993:Unserialize(nbs)
        self.ArenaBattleReportList:Add(var3993)
    end
end
-- LuaG2C_ArenaBattleReport end


-- LuaC2G_ArenaMatch_Buy begin
-- 请求 竞技场次数购买
LuaC2G_ArenaMatch_Buy = Class(Base)
function LuaC2G_ArenaMatch_Buy:ctor()
    self._protocol = LuaProtocolId["C2G_ARENAMATCH_BUY"]
end
function LuaC2G_ArenaMatch_Buy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_ArenaMatch_Buy end


-- LuaG2C_ArenaMatch_Buy begin
-- 返回 竞技场次数购买
LuaG2C_ArenaMatch_Buy = Class(Base)
function LuaG2C_ArenaMatch_Buy:ctor()
    self._protocol = LuaProtocolId["G2C_ARENAMATCH_BUY"]
    self.MatchTicks = 0    -- 挑战次数
end
function LuaG2C_ArenaMatch_Buy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.MatchTicks = nbs:ReadInt()
end
-- LuaG2C_ArenaMatch_Buy end


-- LuaC2G_Arena_Defense begin
-- 请求 查看竞技场防守队伍
LuaC2G_Arena_Defense = Class(Base)
function LuaC2G_Arena_Defense:ctor()
    self._protocol = LuaProtocolId["C2G_ARENA_DEFENSE"]
end
function LuaC2G_Arena_Defense:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Arena_Defense end


-- LuaG2C_Arena_Defense begin
-- 返回 查看竞技场防守队伍
LuaG2C_Arena_Defense = Class(Base)
function LuaG2C_Arena_Defense:ctor()
    self._protocol = LuaProtocolId["G2C_ARENA_DEFENSE"]
    self.DictWarriorInfo = Dictionary:New()    -- 防守队伍信息<位置，信息>
end
function LuaG2C_Arena_Defense:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var3995 = nbs:ReadInt()
    for i = 1, var3995 do
        local var3996 = nbs:ReadInt()
        local var3997 = LuaCLS_WarriorInfo.new()
        var3997:Unserialize(nbs)
        self.DictWarriorInfo:Add(var3996, var3997)
    end
end
-- LuaG2C_Arena_Defense end


-- LuaC2G_Arena_SetDefense begin
-- 请求 竞技场设置防守队伍
LuaC2G_Arena_SetDefense = Class(Base)
function LuaC2G_Arena_SetDefense:ctor()
    self._protocol = LuaProtocolId["C2G_ARENA_SETDEFENSE"]
    self.DictDefenses = Dictionary:New()    -- 防守队伍<位置，ID>
end
function LuaC2G_Arena_SetDefense:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.DictDefenses)
    for key, value in pairs(self.DictDefenses) do
        nbs:WriteInt(key)
        nbs:WriteLong(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Arena_SetDefense end


-- LuaG2C_Arena_SetDefense begin
-- 返回 竞技场设置防守队伍
LuaG2C_Arena_SetDefense = Class(Base)
function LuaG2C_Arena_SetDefense:ctor()
    self._protocol = LuaProtocolId["G2C_ARENA_SETDEFENSE"]
end
function LuaG2C_Arena_SetDefense:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Arena_SetDefense end


-- LuaCLS_BankInfo begin
-- 长安夺宝信息
LuaCLS_BankInfo = Class()
function LuaCLS_BankInfo:ctor()
    self.IsCanFight = false    -- 是否已到活动时间
    self.IsSignUp = false    -- 是否已经报名
    self.GoldCoin = 0    -- 金币
    self.ActiveTick = 0    -- 每日挑战次数
    self.ActiveAllTick = 0    -- 总共挑战次数
    self.bankConf = LuaCLS_BankConf.new()    -- 配置（时间）
end
function LuaCLS_BankInfo:Serialize(nbs)
    nbs:WriteBool(self.IsCanFight)
    nbs:WriteBool(self.IsSignUp)
    nbs:WriteLong(self.GoldCoin)
    nbs:WriteInt(self.ActiveTick)
    nbs:WriteInt(self.ActiveAllTick)
    bankConf:Serialize(nbs)
    return nbs
end
function LuaCLS_BankInfo:Unserialize(nbs)
    self.IsCanFight = nbs:ReadBool()
    self.IsSignUp = nbs:ReadBool()
    self.GoldCoin = nbs:ReadLong()
    self.ActiveTick = nbs:ReadInt()
    self.ActiveAllTick = nbs:ReadInt()
    self.bankConf:Unserialize(nbs)
end
-- LuaCLS_BankInfo end


-- LuaC2G_Bank_Info begin
-- 请求 长安夺宝面板
LuaC2G_Bank_Info = Class(Base)
function LuaC2G_Bank_Info:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_INFO"]
end
function LuaC2G_Bank_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_Info end


-- LuaG2C_Bank_Info begin
-- 返回 长安夺宝面板
LuaG2C_Bank_Info = Class(Base)
function LuaG2C_Bank_Info:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_INFO"]
    self.BankInfo = LuaCLS_BankInfo.new()    -- 长安夺宝信息
end
function LuaG2C_Bank_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BankInfo:Unserialize(nbs)
end
-- LuaG2C_Bank_Info end


-- LuaC2G_Bank_SignIn begin
-- 请求 长安夺宝报名
LuaC2G_Bank_SignIn = Class(Base)
function LuaC2G_Bank_SignIn:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_SIGNIN"]
    self.WarZone = 0    -- 战区
end
function LuaC2G_Bank_SignIn:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.WarZone)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_SignIn end


-- LuaG2C_Bank_SignIn begin
-- 返回 长安夺宝报名
LuaG2C_Bank_SignIn = Class(Base)
function LuaG2C_Bank_SignIn:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_SIGNIN"]
    self.BankInfo = LuaCLS_BankInfo.new()    -- 长安夺宝信息
end
function LuaG2C_Bank_SignIn:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BankInfo:Unserialize(nbs)
end
-- LuaG2C_Bank_SignIn end


-- LuaCLS_WarZoneInfo begin
-- 战区关卡信息
LuaCLS_WarZoneInfo = Class()
function LuaCLS_WarZoneInfo:ctor()
    self.ConfigID = 0    -- 配置ID
    self.BankDefend = 0    -- 守军关卡状态
    self.Hp = 0    -- 剩余血量
    self.ArmyHp = 0    -- 剩余士兵血量
    self.GoldHp = 0    -- 每滴血金币
    self.ArmyGoldHp = 0    -- 士兵每滴血金币
end
function LuaCLS_WarZoneInfo:Serialize(nbs)
    nbs:WriteInt(self.ConfigID)
    nbs:WriteShort(BankDefend)
    nbs:WriteLong(self.Hp)
    nbs:WriteLong(self.ArmyHp)
    nbs:WriteFloat(self.GoldHp)
    nbs:WriteFloat(self.ArmyGoldHp)
    return nbs
end
function LuaCLS_WarZoneInfo:Unserialize(nbs)
    self.ConfigID = nbs:ReadInt()
    self.BankDefend = nbs:ReadShort()
    self.Hp = nbs:ReadLong()
    self.ArmyHp = nbs:ReadLong()
    self.GoldHp = nbs:ReadFloat()
    self.ArmyGoldHp = nbs:ReadFloat()
end
-- LuaCLS_WarZoneInfo end


-- LuaC2G_Bank_WarZone begin
-- 请求 长安夺宝战区信息
LuaC2G_Bank_WarZone = Class(Base)
function LuaC2G_Bank_WarZone:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_WARZONE"]
end
function LuaC2G_Bank_WarZone:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_WarZone end


-- LuaG2C_Bank_WarZone begin
-- 返回 长安夺宝战区信息
LuaG2C_Bank_WarZone = Class(Base)
function LuaG2C_Bank_WarZone:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_WARZONE"]
    self.ListWarZone = List:New(LuaCLS_WarZoneInfo)    -- 战区信息
    self.ListContribution = List:New(LuaCLS_BankCountryTop)    -- 贡献值
    self.CountryId = 0    -- 自国家
    self.ListWelfareState = List:New(Luabool)    -- 贡献奖励领取状态
    self.RecoveryTime = 0    -- 次数恢复时间点
    self.Ticks = 0    -- 挑战次数
end
function LuaG2C_Bank_WarZone:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4012 = nbs:ReadInt()
    for i = 1, var4012 do
        local var4013 = LuaCLS_WarZoneInfo.new()
        var4013:Unserialize(nbs)
        self.ListWarZone:Add(var4013)
    end
    local var4014 = nbs:ReadInt()
    for i = 1, var4014 do
        local var4015 = LuaCLS_BankCountryTop.new()
        var4015:Unserialize(nbs)
        self.ListContribution:Add(var4015)
    end
    self.CountryId = nbs:ReadInt()
    local var4017 = nbs:ReadInt()
    for i = 1, var4017 do
        local var4018 = nbs:ReadBool()
        self.ListWelfareState:Add(var4018)
    end
    self.RecoveryTime = nbs:ReadLong()
    self.Ticks = nbs:ReadLong()
end
-- LuaG2C_Bank_WarZone end


-- LuaC2G_Bank_WarZoneAward begin
-- 请求 长安夺宝战区领奖
LuaC2G_Bank_WarZoneAward = Class(Base)
function LuaC2G_Bank_WarZoneAward:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_WARZONEAWARD"]
    self.ConfigID = 0    -- 领奖ID
end
function LuaC2G_Bank_WarZoneAward:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.ConfigID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_WarZoneAward end


-- LuaG2C_Bank_WarZoneAward begin
-- 返回 长安夺宝战区领奖
LuaG2C_Bank_WarZoneAward = Class(Base)
function LuaG2C_Bank_WarZoneAward:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_WARZONEAWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 结算奖励列表
    self.ListWelfareState = List:New(Luabool)    -- 贡献奖励领取状态
end
function LuaG2C_Bank_WarZoneAward:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4021 = nbs:ReadInt()
    for i = 1, var4021 do
        local var4022 = LuaCLS_AwardItem.new()
        var4022:Unserialize(nbs)
        self.ListAward:Add(var4022)
    end
    local var4023 = nbs:ReadInt()
    for i = 1, var4023 do
        local var4024 = nbs:ReadBool()
        self.ListWelfareState:Add(var4024)
    end
end
-- LuaG2C_Bank_WarZoneAward end


-- LuaC2G_Bank_WarZoneFight begin
-- 请求 长安夺宝战区战斗
LuaC2G_Bank_WarZoneFight = Class(Base)
function LuaC2G_Bank_WarZoneFight:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_WARZONEFIGHT"]
    self.StrongHold = 0    -- 据点ID
end
function LuaC2G_Bank_WarZoneFight:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.StrongHold)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_WarZoneFight end


-- LuaG2C_Bank_WarZoneFight begin
-- 返回 长安夺宝战区战斗
LuaG2C_Bank_WarZoneFight = Class(Base)
function LuaG2C_Bank_WarZoneFight:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_WARZONEFIGHT"]
end
function LuaG2C_Bank_WarZoneFight:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Bank_WarZoneFight end


-- LuaC2G_Bank_WarZoneBalance begin
-- 请求 长安夺宝战区战斗结算
LuaC2G_Bank_WarZoneBalance = Class(Base)
function LuaC2G_Bank_WarZoneBalance:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_WARZONEBALANCE"]
    self.HurtHp = 0    -- 造成伤害
    self.HurtArmyHp = 0    -- 造成士兵伤害
    self.BattleKey = 0    -- 战斗Key
    self.State = 0    -- 战斗结果
end
function LuaC2G_Bank_WarZoneBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.HurtHp)
    nbs:WriteLong(self.HurtArmyHp)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.State)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_WarZoneBalance end


-- LuaG2C_Bank_WarZoneBalance begin
-- 返回 长安夺宝战区战斗结算
LuaG2C_Bank_WarZoneBalance = Class(Base)
function LuaG2C_Bank_WarZoneBalance:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_WARZONEBALANCE"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 结算奖励列表
end
function LuaG2C_Bank_WarZoneBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4025 = nbs:ReadInt()
    for i = 1, var4025 do
        local var4026 = LuaCLS_AwardItem.new()
        var4026:Unserialize(nbs)
        self.ListAward:Add(var4026)
    end
end
-- LuaG2C_Bank_WarZoneBalance end


-- LuaC2G_Bank_WarZoneHurtHp begin
-- 请求 长安夺宝战区战斗伤害(每秒计算)
LuaC2G_Bank_WarZoneHurtHp = Class(Base)
function LuaC2G_Bank_WarZoneHurtHp:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_WARZONEHURTHP"]
    self.HurtHp = 0    -- 造成伤害
    self.BattleKey = 0    -- 战斗Key
end
function LuaC2G_Bank_WarZoneHurtHp:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.HurtHp)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_WarZoneHurtHp end


-- LuaG2C_Bank_WarZoneHurtHp begin
-- 返回 长安夺宝战区战斗伤害
LuaG2C_Bank_WarZoneHurtHp = Class(Base)
function LuaG2C_Bank_WarZoneHurtHp:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_WARZONEHURTHP"]
    self.Hp = 0    -- 血量
end
function LuaG2C_Bank_WarZoneHurtHp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Hp = nbs:ReadLong()
end
-- LuaG2C_Bank_WarZoneHurtHp end


-- LuaC2G_Bank_RobberFight begin
-- 请求 长安夺宝清缴匪盗
LuaC2G_Bank_RobberFight = Class(Base)
function LuaC2G_Bank_RobberFight:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_ROBBERFIGHT"]
end
function LuaC2G_Bank_RobberFight:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_RobberFight end


-- LuaG2C_Bank_RobberFight begin
-- 返回 长安夺宝清缴匪盗
LuaG2C_Bank_RobberFight = Class(Base)
function LuaG2C_Bank_RobberFight:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_ROBBERFIGHT"]
end
function LuaG2C_Bank_RobberFight:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Bank_RobberFight end


-- LuaC2G_Bank_RobberBalance begin
-- 请求 长安夺宝清缴匪盗结算
LuaC2G_Bank_RobberBalance = Class(Base)
function LuaC2G_Bank_RobberBalance:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_ROBBERBALANCE"]
    self.BattleKey = 0    -- 战斗Key
    self.State = 0    -- 战斗结果
end
function LuaC2G_Bank_RobberBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.State)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_RobberBalance end


-- LuaG2C_Bank_RobberBalance begin
-- 返回 长安夺宝清缴匪盗结算
LuaG2C_Bank_RobberBalance = Class(Base)
function LuaG2C_Bank_RobberBalance:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_ROBBERBALANCE"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 结算奖励列表
end
function LuaG2C_Bank_RobberBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4028 = nbs:ReadInt()
    for i = 1, var4028 do
        local var4029 = LuaCLS_AwardItem.new()
        var4029:Unserialize(nbs)
        self.ListAward:Add(var4029)
    end
end
-- LuaG2C_Bank_RobberBalance end


-- LuaCLS_BankTop begin
-- 长安夺宝排行
LuaCLS_BankTop = Class()
function LuaCLS_BankTop:ctor()
    self.Uid = 0    -- 唯一ID（玩家或者势力）
    self.HurtHp = 0    -- 伤害
    self.Level = 0    -- 等级
    self.PlayerName = ""    -- 玩家名
    self.GuildName = ""    -- 势力名
    self.Country = 0    -- 国家
    self.WarZone = 0    -- 战区
end
function LuaCLS_BankTop:Serialize(nbs)
    nbs:WriteLong(self.Uid)
    nbs:WriteLong(self.HurtHp)
    nbs:WriteInt(self.Level)
    nbs:WriteString(self.PlayerName)
    nbs:WriteString(self.GuildName)
    nbs:WriteInt(self.Country)
    nbs:WriteInt(self.WarZone)
    return nbs
end
function LuaCLS_BankTop:Unserialize(nbs)
    self.Uid = nbs:ReadLong()
    self.HurtHp = nbs:ReadLong()
    self.Level = nbs:ReadInt()
    self.PlayerName = nbs:ReadString()
    self.GuildName = nbs:ReadString()
    self.Country = nbs:ReadInt()
    self.WarZone = nbs:ReadInt()
end
-- LuaCLS_BankTop end


-- LuaC2G_Bank_Top begin
-- 请求 长安夺宝排行榜
LuaC2G_Bank_Top = Class(Base)
function LuaC2G_Bank_Top:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_TOP"]
    self.WarZoneID = 0    -- 战区ID
end
function LuaC2G_Bank_Top:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.WarZoneID)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_Top end


-- LuaG2C_Bank_Top begin
-- 返回 长安夺宝排行榜
LuaG2C_Bank_Top = Class(Base)
function LuaG2C_Bank_Top:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_TOP"]
    self.ListGuildTop = List:New(LuaCLS_BankTop)    -- 战区势力排行数据
    self.ListPlayerTop = List:New(LuaCLS_BankTop)    -- 战区个人排行数据
end
function LuaG2C_Bank_Top:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4037 = nbs:ReadInt()
    for i = 1, var4037 do
        local var4038 = LuaCLS_BankTop.new()
        var4038:Unserialize(nbs)
        self.ListGuildTop:Add(var4038)
    end
    local var4039 = nbs:ReadInt()
    for i = 1, var4039 do
        local var4040 = LuaCLS_BankTop.new()
        var4040:Unserialize(nbs)
        self.ListPlayerTop:Add(var4040)
    end
end
-- LuaG2C_Bank_Top end


-- LuaCLS_BankCountryTop begin
-- 长安夺宝国家排行
LuaCLS_BankCountryTop = Class()
function LuaCLS_BankCountryTop:ctor()
    self.Countryid = 0    -- 国家ID
    self.HurtHp = 0    -- 伤害
    self.TopThree = List:New(LuaCLS_PlayerData)    -- 国家前三名数据
    self.ListPlayerTop = List:New(LuaCLS_BankTop)    -- 国家个人排行数据
end
function LuaCLS_BankCountryTop:Serialize(nbs)
    nbs:WriteInt(self.Countryid)
    nbs:WriteLong(self.HurtHp)
    nbs:WriteInt(#self.TopThree)
    for i = 1, #self.TopThree do
        (self.TopThree[i]):Serialize(nbs)
    end
    nbs:WriteInt(#self.ListPlayerTop)
    for i = 1, #self.ListPlayerTop do
        (self.ListPlayerTop[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_BankCountryTop:Unserialize(nbs)
    self.Countryid = nbs:ReadInt()
    self.HurtHp = nbs:ReadLong()
    local var4043 = nbs:ReadInt()
    for i = 1, var4043 do
        local var4044 = LuaCLS_PlayerData.new()
        var4044:Unserialize(nbs)
        self.TopThree:Add(var4044)
    end
    local var4045 = nbs:ReadInt()
    for i = 1, var4045 do
        local var4046 = LuaCLS_BankTop.new()
        var4046:Unserialize(nbs)
        self.ListPlayerTop:Add(var4046)
    end
end
-- LuaCLS_BankCountryTop end


-- LuaC2G_Bank_TopCountry begin
-- 请求 长安夺宝国家排行榜
LuaC2G_Bank_TopCountry = Class(Base)
function LuaC2G_Bank_TopCountry:ctor()
    self._protocol = LuaProtocolId["C2G_BANK_TOPCOUNTRY"]
end
function LuaC2G_Bank_TopCountry:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bank_TopCountry end


-- LuaG2C_Bank_TopCountry begin
-- 返回 长安夺宝国家排行榜
LuaG2C_Bank_TopCountry = Class(Base)
function LuaG2C_Bank_TopCountry:ctor()
    self._protocol = LuaProtocolId["G2C_BANK_TOPCOUNTRY"]
    self.ListTop = List:New(LuaCLS_BankCountryTop)    -- 国家排行数据
end
function LuaG2C_Bank_TopCountry:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4047 = nbs:ReadInt()
    for i = 1, var4047 do
        local var4048 = LuaCLS_BankCountryTop.new()
        var4048:Unserialize(nbs)
        self.ListTop:Add(var4048)
    end
end
-- LuaG2C_Bank_TopCountry end


-- LuaCLS_BankConf begin
-- 长安夺宝配置
LuaCLS_BankConf = Class()
function LuaCLS_BankConf:ctor()
    self.IsSeted = false    -- 是否已设置
    self.IsSended = false    -- 是否已发送奖励
    self.GoldShow = 0    -- 显示金币
    self.Gold = 0    -- 金币
    self.ArmyGold = 0    -- 士兵金币
    self.PlayerRatio = 0    -- 玩家分配比例（50代表50%）
end
function LuaCLS_BankConf:Serialize(nbs)
    nbs:WriteBool(self.IsSeted)
    nbs:WriteBool(self.IsSended)
    nbs:WriteLong(self.GoldShow)
    nbs:WriteLong(self.Gold)
    nbs:WriteLong(self.ArmyGold)
    nbs:WriteInt(self.PlayerRatio)
    nbs:WriteDateTime(self.TimeSignIn)
    nbs:WriteDateTime(self.TimeBegin)
    nbs:WriteDateTime(self.TimeEnd)
    return nbs
end
function LuaCLS_BankConf:Unserialize(nbs)
    self.IsSeted = nbs:ReadBool()
    self.IsSended = nbs:ReadBool()
    self.GoldShow = nbs:ReadLong()
    self.Gold = nbs:ReadLong()
    self.ArmyGold = nbs:ReadLong()
    self.PlayerRatio = nbs:ReadInt()
    self.TimeSignIn = nbs:ReadDateTime()
    self.TimeBegin = nbs:ReadDateTime()
    self.TimeEnd = nbs:ReadDateTime()
end
-- LuaCLS_BankConf end


-- LuaCLS_Affairs begin
-- 军务信息
LuaCLS_Affairs = Class()
function LuaCLS_Affairs:ctor()
    self.AffairsIndex = 0    -- 0-5普通 6每周
    self.configid = 0    -- 配置ID
    self.State = 0    -- 状态:EAffairsState
    self.ListJob = List:New(Luaint)    -- 武将职业
    self.ListWarrior = List:New(Lualong)    -- 武将
end
function LuaCLS_Affairs:Serialize(nbs)
    nbs:WriteInt(self.AffairsIndex)
    nbs:WriteInt(self.configid)
    nbs:WriteInt(self.State)
    nbs:WriteDateTime(self.StartTime)
    nbs:WriteDateTime(self.EndTime)
    nbs:WriteInt(#self.ListJob)
    for i = 1, #self.ListJob do
        nbs:WriteInt(self.ListJob[i])
    end
    nbs:WriteInt(#self.ListWarrior)
    for i = 1, #self.ListWarrior do
        nbs:WriteLong(self.ListWarrior[i])
    end
    return nbs
end
function LuaCLS_Affairs:Unserialize(nbs)
    self.AffairsIndex = nbs:ReadInt()
    self.configid = nbs:ReadInt()
    self.State = nbs:ReadInt()
    self.StartTime = nbs:ReadDateTime()
    self.EndTime = nbs:ReadDateTime()
    local var4063 = nbs:ReadInt()
    for i = 1, var4063 do
        local var4064 = nbs:ReadInt()
        self.ListJob:Add(var4064)
    end
    local var4065 = nbs:ReadInt()
    for i = 1, var4065 do
        local var4066 = nbs:ReadLong()
        self.ListWarrior:Add(var4066)
    end
end
-- LuaCLS_Affairs end


-- LuaC2G_Affairs_List begin
-- 请求 获取军务列表
LuaC2G_Affairs_List = Class(Base)
function LuaC2G_Affairs_List:ctor()
    self._protocol = LuaProtocolId["C2G_AFFAIRS_LIST"]
end
function LuaC2G_Affairs_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Affairs_List end


-- LuaG2C_Affairs_List begin
-- 返回 获取军务列表
LuaG2C_Affairs_List = Class(Base)
function LuaG2C_Affairs_List:ctor()
    self._protocol = LuaProtocolId["G2C_AFFAIRS_LIST"]
    self.ListAffairs = List:New(LuaCLS_Affairs)    -- 军务列表
end
function LuaG2C_Affairs_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4067 = nbs:ReadInt()
    for i = 1, var4067 do
        local var4068 = LuaCLS_Affairs.new()
        var4068:Unserialize(nbs)
        self.ListAffairs:Add(var4068)
    end
end
-- LuaG2C_Affairs_List end


-- LuaC2G_Affairs_Begin begin
-- 请求 开始军务
LuaC2G_Affairs_Begin = Class(Base)
function LuaC2G_Affairs_Begin:ctor()
    self._protocol = LuaProtocolId["C2G_AFFAIRS_BEGIN"]
    self.AffairsIndex = 0    -- 0-5普通 6每周
    self.ListWarrior = List:New(Lualong)    -- 武将
end
function LuaC2G_Affairs_Begin:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.AffairsIndex)
    nbs:WriteInt(#self.ListWarrior)
    for i = 1, #self.ListWarrior do
        nbs:WriteLong(self.ListWarrior[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Affairs_Begin end


-- LuaG2C_Affairs_Begin begin
-- 返回 开始军务
LuaG2C_Affairs_Begin = Class(Base)
function LuaG2C_Affairs_Begin:ctor()
    self._protocol = LuaProtocolId["G2C_AFFAIRS_BEGIN"]
    self.AffairsInfo = LuaCLS_Affairs.new()    -- 军务信息
end
function LuaG2C_Affairs_Begin:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AffairsInfo:Unserialize(nbs)
end
-- LuaG2C_Affairs_Begin end


-- LuaC2G_Affairs_Award begin
-- 请求 军务领奖
LuaC2G_Affairs_Award = Class(Base)
function LuaC2G_Affairs_Award:ctor()
    self._protocol = LuaProtocolId["C2G_AFFAIRS_AWARD"]
    self.AffairsIndex = 0    -- 0-5普通 6每周
end
function LuaC2G_Affairs_Award:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.AffairsIndex)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Affairs_Award end


-- LuaG2C_Affairs_Award begin
-- 返回 军务领奖
LuaG2C_Affairs_Award = Class(Base)
function LuaG2C_Affairs_Award:ctor()
    self._protocol = LuaProtocolId["G2C_AFFAIRS_AWARD"]
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
end
function LuaG2C_Affairs_Award:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4070 = nbs:ReadInt()
    for i = 1, var4070 do
        local var4071 = LuaCLS_AwardItem.new()
        var4071:Unserialize(nbs)
        self.ListAward:Add(var4071)
    end
end
-- LuaG2C_Affairs_Award end


-- LuaG2C_Affairs_Notify begin
-- 通知军务完成
LuaG2C_Affairs_Notify = Class(Base)
function LuaG2C_Affairs_Notify:ctor()
    self._protocol = LuaProtocolId["G2C_AFFAIRS_NOTIFY"]
    self.AffairsInfo = LuaCLS_Affairs.new()    -- 刷新军务信息
end
function LuaG2C_Affairs_Notify:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.AffairsInfo:Unserialize(nbs)
end
-- LuaG2C_Affairs_Notify end


-- LuaCLS_Grab_ArmyInfo begin
-- 矿点信息
LuaCLS_Grab_ArmyInfo = Class()
function LuaCLS_Grab_ArmyInfo:ctor()
    self.Id = 0    -- 矿点ID
    self.PalyerId = 0    -- 占领者
    self.Name = ""    -- 占领者
    self.GuildName = ""    -- 占领者所属势力
    self.DictWarrior = Dictionary:New()    -- 队伍列表 <位置 武将唯一ID>
end
function LuaCLS_Grab_ArmyInfo:Serialize(nbs)
    nbs:WriteInt(self.Id)
    nbs:WriteLong(self.PalyerId)
    nbs:WriteString(self.Name)
    nbs:WriteString(self.GuildName)
    nbs:WriteInt(#self.DictWarrior)
    for key, value in pairs(self.DictWarrior) do
        nbs:WriteInt(key)
        nbs:WriteLong(value)
    end
    nbs:WriteDateTime(self.BeginTime)
    nbs:WriteDateTime(self.EndTime)
    return nbs
end
function LuaCLS_Grab_ArmyInfo:Unserialize(nbs)
    self.Id = nbs:ReadInt()
    self.PalyerId = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.GuildName = nbs:ReadString()
    local var4077 = nbs:ReadInt()
    for i = 1, var4077 do
        local var4078 = nbs:ReadInt()
        local var4079 = nbs:ReadLong()
        self.DictWarrior:Add(var4078, var4079)
    end
    self.BeginTime = nbs:ReadDateTime()
    self.EndTime = nbs:ReadDateTime()
end
-- LuaCLS_Grab_ArmyInfo end


-- LuaC2G_Grab_List begin
-- 请求 资源点信息
LuaC2G_Grab_List = Class(Base)
function LuaC2G_Grab_List:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_LIST"]
    self.StateId = 0    -- 州ID
    self.Type = 0    -- 资源类型
end
function LuaC2G_Grab_List:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.StateId)
    nbs:WriteInt(self.Type)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_List end


-- LuaG2C_Grab_List begin
-- 返回 资源点信息
LuaG2C_Grab_List = Class(Base)
function LuaG2C_Grab_List:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_LIST"]
    self.Buy = 0    -- 购买次数
    self.Total = 0    -- 剩余挑战次数
    self.ListItem = List:New(LuaCLS_Grab_ArmyInfo)
end
function LuaG2C_Grab_List:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Buy = nbs:ReadInt()
    self.Total = nbs:ReadInt()
    local var4084 = nbs:ReadInt()
    for i = 1, var4084 do
        local var4085 = LuaCLS_Grab_ArmyInfo.new()
        var4085:Unserialize(nbs)
        self.ListItem:Add(var4085)
    end
end
-- LuaG2C_Grab_List end


-- LuaC2G_Grab_Battle begin
-- 请求 矿点战斗
LuaC2G_Grab_Battle = Class(Base)
function LuaC2G_Grab_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_BATTLE"]
    self.Id = 0    -- 矿点ID
end
function LuaC2G_Grab_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_Battle end


-- LuaG2C_Grab_Battle begin
-- 返回 矿点战斗
LuaG2C_Grab_Battle = Class(Base)
function LuaG2C_Grab_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_BATTLE"]
    self.ListWarriorOther = List:New(LuaCLS_WarriorInfo)    -- 对战武将战斗信息列表
end
function LuaG2C_Grab_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4086 = nbs:ReadInt()
    for i = 1, var4086 do
        local var4087 = LuaCLS_WarriorInfo.new()
        var4087:Unserialize(nbs)
        self.ListWarriorOther:Add(var4087)
    end
end
-- LuaG2C_Grab_Battle end


-- LuaC2G_Grab_Fight begin
-- 请求 占领矿点
LuaC2G_Grab_Fight = Class(Base)
function LuaC2G_Grab_Fight:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_FIGHT"]
    self.BattleUid = 0    -- 战斗ID
    self.BattleResult = false    -- 战斗结果 攻击方胜利=true 防守方胜利=false
    self.DictExpendHpAtt = Dictionary:New()    -- 武将消耗兵力
    self.DictExpendHpDef = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Grab_Fight:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleUid)
    nbs:WriteBool(self.BattleResult)
    nbs:WriteInt(#self.DictExpendHpAtt)
    for key, value in pairs(self.DictExpendHpAtt) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(#self.DictExpendHpDef)
    for key, value in pairs(self.DictExpendHpDef) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_Fight end


-- LuaG2C_Grab_Fight begin
-- 返回 占领矿点
LuaG2C_Grab_Fight = Class(Base)
function LuaG2C_Grab_Fight:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_FIGHT"]
    self.bSuccess = false    -- 胜利与否
end
function LuaG2C_Grab_Fight:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.bSuccess = nbs:ReadBool()
end
-- LuaG2C_Grab_Fight end


-- LuaC2G_Grab_Info begin
-- 请求 查看矿点
LuaC2G_Grab_Info = Class(Base)
function LuaC2G_Grab_Info:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_INFO"]
    self.Id = 0    -- 矿点ID
end
function LuaC2G_Grab_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_Info end


-- LuaG2C_Grab_Info begin
-- 返回 查看矿点
LuaG2C_Grab_Info = Class(Base)
function LuaG2C_Grab_Info:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_INFO"]
    self.Id = 0    -- 矿点ID
    self.PalyerId = 0    -- 占领者
    self.Name = ""    -- 占领者
    self.GuildName = ""    -- 占领者所属势力
    self.DictWarrior = Dictionary:New()    -- 防守队伍信息<位置，信息>
end
function LuaG2C_Grab_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
    self.PalyerId = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.GuildName = nbs:ReadString()
    local var4093 = nbs:ReadInt()
    for i = 1, var4093 do
        local var4094 = nbs:ReadInt()
        local var4095 = LuaCLS_WarriorInfo.new()
        var4095:Unserialize(nbs)
        self.DictWarrior:Add(var4094, var4095)
    end
    self.EndTime = nbs:ReadDateTime()
end
-- LuaG2C_Grab_Info end


-- LuaC2G_Grab_GiveUp begin
-- 请求 放弃矿点
LuaC2G_Grab_GiveUp = Class(Base)
function LuaC2G_Grab_GiveUp:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_GIVEUP"]
    self.Id = 0    -- 矿点ID
end
function LuaC2G_Grab_GiveUp:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Id)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_GiveUp end


-- LuaG2C_Grab_GiveUp begin
-- 返回 放弃矿点
LuaG2C_Grab_GiveUp = Class(Base)
function LuaG2C_Grab_GiveUp:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_GIVEUP"]
    self.Id = 0    -- 矿点ID
end
function LuaG2C_Grab_GiveUp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Id = nbs:ReadInt()
end
-- LuaG2C_Grab_GiveUp end


-- LuaC2G_Grab_Mine begin
-- 请求 自己的资源点信息
LuaC2G_Grab_Mine = Class(Base)
function LuaC2G_Grab_Mine:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_MINE"]
end
function LuaC2G_Grab_Mine:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_Mine end


-- LuaG2C_Grab_Mine begin
-- 返回 自己的资源点信息
LuaG2C_Grab_Mine = Class(Base)
function LuaG2C_Grab_Mine:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_MINE"]
    self.ListItem = List:New(LuaCLS_Grab_ArmyInfo)
end
function LuaG2C_Grab_Mine:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4098 = nbs:ReadInt()
    for i = 1, var4098 do
        local var4099 = LuaCLS_Grab_ArmyInfo.new()
        var4099:Unserialize(nbs)
        self.ListItem:Add(var4099)
    end
end
-- LuaG2C_Grab_Mine end


-- LuaC2G_Grab_Buy begin
-- 请求 购买挑战次数
LuaC2G_Grab_Buy = Class(Base)
function LuaC2G_Grab_Buy:ctor()
    self._protocol = LuaProtocolId["C2G_GRAB_BUY"]
end
function LuaC2G_Grab_Buy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Grab_Buy end


-- LuaG2C_Grab_Buy begin
-- 返回 购买挑战次数
LuaG2C_Grab_Buy = Class(Base)
function LuaG2C_Grab_Buy:ctor()
    self._protocol = LuaProtocolId["G2C_GRAB_BUY"]
    self.Buy = 0    -- 购买次数
    self.Total = 0    -- 剩余挑战次数
end
function LuaG2C_Grab_Buy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Buy = nbs:ReadInt()
    self.Total = nbs:ReadInt()
end
-- LuaG2C_Grab_Buy end


-- LuaCLS_BanditsArmyInfo begin
-- 匪寇信息单条
LuaCLS_BanditsArmyInfo = Class()
function LuaCLS_BanditsArmyInfo:ctor()
    self.Uid = 0    -- 队伍ID
    self.ConfigId = 0    -- 配置ID
    self.IsAlive = false    -- 存活
    self.TicksDeath = 0    -- 死亡时间
end
function LuaCLS_BanditsArmyInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteInt(self.ConfigId)
    nbs:WriteBool(self.IsAlive)
    nbs:WriteLong(self.TicksDeath)
    return nbs
end
function LuaCLS_BanditsArmyInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.ConfigId = nbs:ReadInt()
    self.IsAlive = nbs:ReadBool()
    self.TicksDeath = nbs:ReadLong()
end
-- LuaCLS_BanditsArmyInfo end


-- LuaCLS_BanditsInfo begin
-- 匪寇信息
LuaCLS_BanditsInfo = Class()
function LuaCLS_BanditsInfo:ctor()
    self.BanditsBuyTimes = 0    -- 今天购买次数
    self.BanditsCount = 0    -- 剩余挑战次数
    self.DictBandits = Dictionary:New()    -- 匪寇列表
end
function LuaCLS_BanditsInfo:Serialize(nbs)
    nbs:WriteInt(self.BanditsBuyTimes)
    nbs:WriteInt(self.BanditsCount)
    nbs:WriteInt(#self.DictBandits)
    for key, value in pairs(self.DictBandits) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_BanditsInfo:Unserialize(nbs)
    self.BanditsBuyTimes = nbs:ReadInt()
    self.BanditsCount = nbs:ReadInt()
    local var4108 = nbs:ReadInt()
    for i = 1, var4108 do
        local var4109 = nbs:ReadInt()
        local var4110 = LuaCLS_BanditsArmyInfo.new()
        var4110:Unserialize(nbs)
        self.DictBandits:Add(var4109, var4110)
    end
end
-- LuaCLS_BanditsInfo end


-- LuaC2G_Bandits_Info begin
-- 请求 征讨匪寇信息
LuaC2G_Bandits_Info = Class(Base)
function LuaC2G_Bandits_Info:ctor()
    self._protocol = LuaProtocolId["C2G_BANDITS_INFO"]
end
function LuaC2G_Bandits_Info:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bandits_Info end


-- LuaG2C_Bandits_Info begin
-- 返回 征讨匪寇信息
LuaG2C_Bandits_Info = Class(Base)
function LuaG2C_Bandits_Info:ctor()
    self._protocol = LuaProtocolId["G2C_BANDITS_INFO"]
    self.BanditsInfo = LuaCLS_BanditsInfo.new()    -- 征讨匪寇信息
end
function LuaG2C_Bandits_Info:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BanditsInfo:Unserialize(nbs)
end
-- LuaG2C_Bandits_Info end


-- LuaC2G_Bandits_Battle begin
-- 请求 征讨匪寇战斗
LuaC2G_Bandits_Battle = Class(Base)
function LuaC2G_Bandits_Battle:ctor()
    self._protocol = LuaProtocolId["C2G_BANDITS_BATTLE"]
    self.Uid = 0    -- 队伍ID
end
function LuaC2G_Bandits_Battle:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bandits_Battle end


-- LuaG2C_Bandits_Battle begin
-- 返回 征讨匪寇战斗
LuaG2C_Bandits_Battle = Class(Base)
function LuaG2C_Bandits_Battle:ctor()
    self._protocol = LuaProtocolId["G2C_BANDITS_BATTLE"]
    self.Uid = 0    -- 队伍ID
    self.BanditsCount = 0    -- 剩余挑战次数
end
function LuaG2C_Bandits_Battle:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadInt()
    self.BanditsCount = nbs:ReadInt()
end
-- LuaG2C_Bandits_Battle end


-- LuaC2G_Bandits_BattleEnd begin
-- 请求 征讨匪寇战斗结束
LuaC2G_Bandits_BattleEnd = Class(Base)
function LuaC2G_Bandits_BattleEnd:ctor()
    self._protocol = LuaProtocolId["C2G_BANDITS_BATTLEEND"]
    self.Uid = 0    -- 队伍ID
    self.BattleKey = 0    -- 战斗Key
    self.State = 0    -- 战斗结果
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Bandits_BattleEnd:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.BattleKey)
    nbs:WriteInt(self.State)
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bandits_BattleEnd end


-- LuaG2C_Bandits_BattleEnd begin
-- 返回 征讨匪寇战斗结束
LuaG2C_Bandits_BattleEnd = Class(Base)
function LuaG2C_Bandits_BattleEnd:ctor()
    self._protocol = LuaProtocolId["G2C_BANDITS_BATTLEEND"]
    self.Uid = 0    -- 队伍ID
    self.ListAward = List:New(LuaCLS_AwardItem)    -- 奖励列表
    self.BanditsInfo = LuaCLS_BanditsInfo.new()    -- 征讨匪寇信息
end
function LuaG2C_Bandits_BattleEnd:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadInt()
    local var4115 = nbs:ReadInt()
    for i = 1, var4115 do
        local var4116 = LuaCLS_AwardItem.new()
        var4116:Unserialize(nbs)
        self.ListAward:Add(var4116)
    end
    self.BanditsInfo:Unserialize(nbs)
end
-- LuaG2C_Bandits_BattleEnd end


-- LuaC2G_Bandits_Buy begin
-- 请求 购买挑战次数
LuaC2G_Bandits_Buy = Class(Base)
function LuaC2G_Bandits_Buy:ctor()
    self._protocol = LuaProtocolId["C2G_BANDITS_BUY"]
end
function LuaC2G_Bandits_Buy:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bandits_Buy end


-- LuaG2C_Bandits_Buy begin
-- 返回 购买挑战次数
LuaG2C_Bandits_Buy = Class(Base)
function LuaG2C_Bandits_Buy:ctor()
    self._protocol = LuaProtocolId["G2C_BANDITS_BUY"]
    self.BanditsBuyTimes = 0    -- 今天购买次数
    self.BanditsCount = 0    -- 剩余挑战次数
end
function LuaG2C_Bandits_Buy:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BanditsBuyTimes = nbs:ReadInt()
    self.BanditsCount = nbs:ReadInt()
end
-- LuaG2C_Bandits_Buy end


-- LuaC2G_Bandits_Reset begin
-- 请求 购买怪物重置
LuaC2G_Bandits_Reset = Class(Base)
function LuaC2G_Bandits_Reset:ctor()
    self._protocol = LuaProtocolId["C2G_BANDITS_RESET"]
end
function LuaC2G_Bandits_Reset:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Bandits_Reset end


-- LuaG2C_Bandits_Reset begin
-- 返回 购买怪物重置
LuaG2C_Bandits_Reset = Class(Base)
function LuaG2C_Bandits_Reset:ctor()
    self._protocol = LuaProtocolId["G2C_BANDITS_RESET"]
    self.BanditsInfo = LuaCLS_BanditsInfo.new()    -- 征讨匪寇信息
end
function LuaG2C_Bandits_Reset:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BanditsInfo:Unserialize(nbs)
end
-- LuaG2C_Bandits_Reset end


-- LuaC2G_Supply_Supply begin
-- 请求 补兵
LuaC2G_Supply_Supply = Class(Base)
function LuaC2G_Supply_Supply:ctor()
    self._protocol = LuaProtocolId["C2G_SUPPLY_SUPPLY"]
    self.DictWarrior = Dictionary:New()    -- k=武将唯一ID v=当前兵数
end
function LuaC2G_Supply_Supply:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.DictWarrior)
    for key, value in pairs(self.DictWarrior) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Supply_Supply end


-- LuaG2C_Supply_Supply begin
-- 返回 补兵
LuaG2C_Supply_Supply = Class(Base)
function LuaG2C_Supply_Supply:ctor()
    self._protocol = LuaProtocolId["G2C_SUPPLY_SUPPLY"]
    self.DictWarrior = Dictionary:New()    -- 成员列表 <武将信息>
end
function LuaG2C_Supply_Supply:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4121 = nbs:ReadInt()
    for i = 1, var4121 do
        local var4122 = nbs:ReadLong()
        local var4123 = LuaCLS_WarriorInfo.new()
        var4123:Unserialize(nbs)
        self.DictWarrior:Add(var4122, var4123)
    end
end
-- LuaG2C_Supply_Supply end


-- LuaC2G_Supply_SupplyAuto begin
-- 请求 一键补兵
LuaC2G_Supply_SupplyAuto = Class(Base)
function LuaC2G_Supply_SupplyAuto:ctor()
    self._protocol = LuaProtocolId["C2G_SUPPLY_SUPPLYAUTO"]
    self.ListWarrior = List:New(Lualong)    -- k=武将唯一ID
end
function LuaC2G_Supply_SupplyAuto:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(#self.ListWarrior)
    for i = 1, #self.ListWarrior do
        nbs:WriteLong(self.ListWarrior[i])
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Supply_SupplyAuto end


-- LuaG2C_Supply_SupplyAuto begin
-- 返回 一键补兵
LuaG2C_Supply_SupplyAuto = Class(Base)
function LuaG2C_Supply_SupplyAuto:ctor()
    self._protocol = LuaProtocolId["G2C_SUPPLY_SUPPLYAUTO"]
    self.DictWarrior = Dictionary:New()    -- 成员列表 <武将信息>
end
function LuaG2C_Supply_SupplyAuto:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4124 = nbs:ReadInt()
    for i = 1, var4124 do
        local var4125 = nbs:ReadLong()
        local var4126 = LuaCLS_WarriorInfo.new()
        var4126:Unserialize(nbs)
        self.DictWarrior:Add(var4125, var4126)
    end
end
-- LuaG2C_Supply_SupplyAuto end


-- LuaCLS_StrategyCityInfoBase begin
-- 城池战略信息基础
LuaCLS_StrategyCityInfoBase = Class()
function LuaCLS_StrategyCityInfoBase:ctor()
    self.GuildUid = 0    -- 所属势力唯一ID(0=无人占领)
    self.GuildName = ""    -- 所属势力名
    self.CountryId = 0    -- 势力所属国家ID
    self.Ownership = 0    -- 归属 EOwnership
end
function LuaCLS_StrategyCityInfoBase:Serialize(nbs)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteString(self.GuildName)
    nbs:WriteInt(self.CountryId)
    nbs:WriteByte(self.Ownership)
    nbs:WriteTimeSpan(self.TsCooldownProtected)
    return nbs
end
function LuaCLS_StrategyCityInfoBase:Unserialize(nbs)
    self.GuildUid = nbs:ReadLong()
    self.GuildName = nbs:ReadString()
    self.CountryId = nbs:ReadInt()
    self.Ownership = nbs:ReadByte()
    self.TsCooldownProtected = nbs:ReadTimeSpan()
end
-- LuaCLS_StrategyCityInfoBase end


-- LuaCLS_StrategyCityInfo begin
-- 战略城池信息
LuaCLS_StrategyCityInfo = Class()
function LuaCLS_StrategyCityInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.LeaderPuid = 0    -- 太守Id
    self.LeaderName = ""    -- 太守名字
    self.Prosperity = 0    -- 繁荣度
    self.CityInfoBase = LuaCLS_StrategyCityInfoBase.new()    -- 城池战略信息基础
    self.CityInfoMetro = LuaCLS_StrategyCityInfoMetro.new()    -- 城池战略信息大城池
end
function LuaCLS_StrategyCityInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    nbs:WriteLong(self.LeaderPuid)
    nbs:WriteString(self.LeaderName)
    nbs:WriteLong(self.Prosperity)
    CityInfoBase:Serialize(nbs)
    CityInfoMetro:Serialize(nbs)
    return nbs
end
function LuaCLS_StrategyCityInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.LeaderPuid = nbs:ReadLong()
    self.LeaderName = nbs:ReadString()
    self.Prosperity = nbs:ReadLong()
    self.CityInfoBase:Unserialize(nbs)
    self.CityInfoMetro:Unserialize(nbs)
end
-- LuaCLS_StrategyCityInfo end


-- LuaC2G_Strategy_Map begin
-- 请求 战略地图
LuaC2G_Strategy_Map = Class(Base)
function LuaC2G_Strategy_Map:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_MAP"]
end
function LuaC2G_Strategy_Map:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_Map end


-- LuaG2C_Strategy_Map begin
-- 返回 战略地图
LuaG2C_Strategy_Map = Class(Base)
function LuaG2C_Strategy_Map:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_MAP"]
    self.DictCity = Dictionary:New()    -- 城池列表
    self.MetroPvpInfo = LuaCLS_MetroPvpInfo.new()    -- 大城池PVP综合信息
    self.ListAlliance = List:New(Lualong)    -- 同盟势力
    self.ListGuildCityMy = List:New(Luaint)    -- 我方城池
    self.ListGuildCityAlliance = List:New(Luaint)    -- 同盟城池
    self.BanditsInfo = LuaCLS_BanditsInfo.new()    -- 征讨匪寇信息
end
function LuaG2C_Strategy_Map:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4138 = nbs:ReadInt()
    for i = 1, var4138 do
        local var4139 = nbs:ReadInt()
        local var4140 = LuaCLS_StrategyCityInfo.new()
        var4140:Unserialize(nbs)
        self.DictCity:Add(var4139, var4140)
    end
    self.MetroPvpInfo:Unserialize(nbs)
    local var4142 = nbs:ReadInt()
    for i = 1, var4142 do
        local var4143 = nbs:ReadLong()
        self.ListAlliance:Add(var4143)
    end
    local var4144 = nbs:ReadInt()
    for i = 1, var4144 do
        local var4145 = nbs:ReadInt()
        self.ListGuildCityMy:Add(var4145)
    end
    local var4146 = nbs:ReadInt()
    for i = 1, var4146 do
        local var4147 = nbs:ReadInt()
        self.ListGuildCityAlliance:Add(var4147)
    end
    self.BanditsInfo:Unserialize(nbs)
end
-- LuaG2C_Strategy_Map end


-- LuaC2G_Strategy_CityInfo begin
-- 请求 城池信息
LuaC2G_Strategy_CityInfo = Class(Base)
function LuaC2G_Strategy_CityInfo:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_CITYINFO"]
    self.Uid = 0    -- 城池唯一ID(配置ID)
end
function LuaC2G_Strategy_CityInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_CityInfo end


-- LuaG2C_Strategy_CityInfo begin
-- 返回 城池信息
LuaG2C_Strategy_CityInfo = Class(Base)
function LuaG2C_Strategy_CityInfo:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_CITYINFO"]
    self.CityInfo = LuaCLS_StrategyCityInfo.new()    -- 城池信息
end
function LuaG2C_Strategy_CityInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityInfo:Unserialize(nbs)
end
-- LuaG2C_Strategy_CityInfo end


-- LuaCLS_StrategyFightCampInfo begin
-- 城池战斗守备营信息
LuaCLS_StrategyFightCampInfo = Class()
function LuaCLS_StrategyFightCampInfo:ctor()
    self.Uid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallHp = LuaCLS_CountInfo.new()    -- 城墙耐久
    self.ListLastAttacker = List:New(Luastring)    -- 攻击者列表
end
function LuaCLS_StrategyFightCampInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    WallHp:Serialize(nbs)
    nbs:WriteInt(#self.ListLastAttacker)
    for i = 1, #self.ListLastAttacker do
        nbs:WriteString(self.ListLastAttacker[i])
    end
    return nbs
end
function LuaCLS_StrategyFightCampInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.WallHp:Unserialize(nbs)
    local var4152 = nbs:ReadInt()
    for i = 1, var4152 do
        local var4153 = nbs:ReadString()
        self.ListLastAttacker:Add(var4153)
    end
end
-- LuaCLS_StrategyFightCampInfo end


-- LuaCLS_StrategyFightInfo begin
-- 城池战斗信息
LuaCLS_StrategyFightInfo = Class()
function LuaCLS_StrategyFightInfo:ctor()
    self.Uid = 0    -- 唯一ID(配置ID)
    self.CityInfoBase = LuaCLS_StrategyCityInfoBase.new()    -- 城池战略信息基础
    self.DictCamp = Dictionary:New()    -- 城池战斗守备营信息
end
function LuaCLS_StrategyFightInfo:Serialize(nbs)
    nbs:WriteInt(self.Uid)
    CityInfoBase:Serialize(nbs)
    nbs:WriteInt(#self.DictCamp)
    for key, value in pairs(self.DictCamp) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_StrategyFightInfo:Unserialize(nbs)
    self.Uid = nbs:ReadInt()
    self.CityInfoBase:Unserialize(nbs)
    local var4156 = nbs:ReadInt()
    for i = 1, var4156 do
        local var4157 = nbs:ReadInt()
        local var4158 = LuaCLS_StrategyFightCampInfo.new()
        var4158:Unserialize(nbs)
        self.DictCamp:Add(var4157, var4158)
    end
end
-- LuaCLS_StrategyFightInfo end


-- LuaC2G_Strategy_FightInfo begin
-- 请求 城池战斗信息
LuaC2G_Strategy_FightInfo = Class(Base)
function LuaC2G_Strategy_FightInfo:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_FIGHTINFO"]
    self.Uid = 0    -- 城池唯一ID(配置ID)
end
function LuaC2G_Strategy_FightInfo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_FightInfo end


-- LuaG2C_Strategy_FightInfo begin
-- 返回 城池战斗信息
LuaG2C_Strategy_FightInfo = Class(Base)
function LuaG2C_Strategy_FightInfo:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_FIGHTINFO"]
    self.CityInfo = LuaCLS_StrategyFightInfo.new()    -- 城池战斗信息
end
function LuaG2C_Strategy_FightInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityInfo:Unserialize(nbs)
end
-- LuaG2C_Strategy_FightInfo end


-- LuaG2C_Strategy_NotifyRefreshWallHp begin
-- 通知 城墙血量刷新
LuaG2C_Strategy_NotifyRefreshWallHp = Class(Base)
function LuaG2C_Strategy_NotifyRefreshWallHp:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYREFRESHWALLHP"]
    self.CityUid = 0    -- 城池ID
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallHp = LuaCLS_CountInfo.new()    -- 城墙耐久
end
function LuaG2C_Strategy_NotifyRefreshWallHp:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.WallHp:Unserialize(nbs)
end
-- LuaG2C_Strategy_NotifyRefreshWallHp end


-- LuaG2C_Strategy_NotifyRefreshCityInfo begin
-- 通知 城池信息刷新
LuaG2C_Strategy_NotifyRefreshCityInfo = Class(Base)
function LuaG2C_Strategy_NotifyRefreshCityInfo:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYREFRESHCITYINFO"]
    self.CityInfo = LuaCLS_StrategyCityInfo.new()    -- 城池信息
end
function LuaG2C_Strategy_NotifyRefreshCityInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityInfo:Unserialize(nbs)
end
-- LuaG2C_Strategy_NotifyRefreshCityInfo end


-- LuaG2C_Strategy_NotifyRefreshCitys begin
-- 通知 城池信息刷新多个
LuaG2C_Strategy_NotifyRefreshCitys = Class(Base)
function LuaG2C_Strategy_NotifyRefreshCitys:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYREFRESHCITYS"]
    self.DictCity = Dictionary:New()    -- 城池列表
end
function LuaG2C_Strategy_NotifyRefreshCitys:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4164 = nbs:ReadInt()
    for i = 1, var4164 do
        local var4165 = nbs:ReadInt()
        local var4166 = LuaCLS_StrategyCityInfo.new()
        var4166:Unserialize(nbs)
        self.DictCity:Add(var4165, var4166)
    end
end
-- LuaG2C_Strategy_NotifyRefreshCitys end


-- LuaC2G_Strategy_MatchingCancel begin
-- 请求 城池战斗匹配取消
LuaC2G_Strategy_MatchingCancel = Class(Base)
function LuaC2G_Strategy_MatchingCancel:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_MATCHINGCANCEL"]
end
function LuaC2G_Strategy_MatchingCancel:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_MatchingCancel end


-- LuaG2C_Strategy_MatchingCancel begin
-- 返回 城池战斗匹配取消
LuaG2C_Strategy_MatchingCancel = Class(Base)
function LuaG2C_Strategy_MatchingCancel:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_MATCHINGCANCEL"]
end
function LuaG2C_Strategy_MatchingCancel:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Strategy_MatchingCancel end


-- LuaC2G_Strategy_Defense begin
-- 请求 城池战斗防守
LuaC2G_Strategy_Defense = Class(Base)
function LuaC2G_Strategy_Defense:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_DEFENSE"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
end
function LuaC2G_Strategy_Defense:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_Defense end


-- LuaG2C_Strategy_Defense begin
-- 返回 城池战斗防守
LuaG2C_Strategy_Defense = Class(Base)
function LuaG2C_Strategy_Defense:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_DEFENSE"]
end
function LuaG2C_Strategy_Defense:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DtMatchingStart = nbs:ReadDateTime()
    self.DtMatchingEnd = nbs:ReadDateTime()
end
-- LuaG2C_Strategy_Defense end


-- LuaC2G_Strategy_Attack begin
-- 请求 城池战斗进攻
LuaC2G_Strategy_Attack = Class(Base)
function LuaC2G_Strategy_Attack:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_ATTACK"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
end
function LuaC2G_Strategy_Attack:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_Attack end


-- LuaG2C_Strategy_Attack begin
-- 返回 城池战斗进攻
LuaG2C_Strategy_Attack = Class(Base)
function LuaG2C_Strategy_Attack:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_ATTACK"]
end
function LuaG2C_Strategy_Attack:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DtMatchingStart = nbs:ReadDateTime()
    self.DtMatchingEnd = nbs:ReadDateTime()
end
-- LuaG2C_Strategy_Attack end


-- LuaG2C_Strategy_NotifyMatchingEndDefense begin
-- 通知 城池战斗匹配结束防守
LuaG2C_Strategy_NotifyMatchingEndDefense = Class(Base)
function LuaG2C_Strategy_NotifyMatchingEndDefense:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYMATCHINGENDDEFENSE"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallHp = 0    -- 城墙血量当前值
    self.WallHpAdded = 0    -- 城墙血量增加值
end
function LuaG2C_Strategy_NotifyMatchingEndDefense:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.WallHp = nbs:ReadLong()
    self.WallHpAdded = nbs:ReadLong()
end
-- LuaG2C_Strategy_NotifyMatchingEndDefense end


-- LuaG2C_Strategy_NotifyMatchingAttackNpc begin
-- 通知 城池战斗匹配攻击NPC
LuaG2C_Strategy_NotifyMatchingAttackNpc = Class(Base)
function LuaG2C_Strategy_NotifyMatchingAttackNpc:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYMATCHINGATTACKNPC"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.CampNpc = LuaCLS_CampNpc.new()    -- 被攻击的NPC信息
end
function LuaG2C_Strategy_NotifyMatchingAttackNpc:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.CampNpc:Unserialize(nbs)
end
-- LuaG2C_Strategy_NotifyMatchingAttackNpc end


-- LuaG2C_Strategy_NotifyMatchingAttackWall begin
-- 通知 城池战斗匹配攻击城墙
LuaG2C_Strategy_NotifyMatchingAttackWall = Class(Base)
function LuaG2C_Strategy_NotifyMatchingAttackWall:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYMATCHINGATTACKWALL"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallLevel = 0    -- 城墙等级
    self.WallHp = LuaCLS_CountInfo.new()    -- 城墙耐久
end
function LuaG2C_Strategy_NotifyMatchingAttackWall:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.WallLevel = nbs:ReadInt()
    self.WallHp:Unserialize(nbs)
end
-- LuaG2C_Strategy_NotifyMatchingAttackWall end


-- LuaCLS_CampNpcMonster begin
-- 守军NPC兵力
LuaCLS_CampNpcMonster = Class()
function LuaCLS_CampNpcMonster:ctor()
    self.MonsterUid = 0    -- ID(位置0-n)
    self.MonsterId = 0    -- 怪物ID
    self.Hp = 0    -- 兵力
end
function LuaCLS_CampNpcMonster:Serialize(nbs)
    nbs:WriteInt(self.MonsterUid)
    nbs:WriteInt(self.MonsterId)
    nbs:WriteLong(self.Hp)
    return nbs
end
function LuaCLS_CampNpcMonster:Unserialize(nbs)
    self.MonsterUid = nbs:ReadInt()
    self.MonsterId = nbs:ReadInt()
    self.Hp = nbs:ReadLong()
end
-- LuaCLS_CampNpcMonster end


-- LuaCLS_CampNpc begin
-- 守军NPC
LuaCLS_CampNpc = Class()
function LuaCLS_CampNpc:ctor()
    self.NpcUid = 0    -- ID(1-n)
    self.StageId = 0    -- 关卡配置ID
    self.DictMonster = Dictionary:New()    -- NPC部队兵力 k=位置0-n
end
function LuaCLS_CampNpc:Serialize(nbs)
    nbs:WriteInt(self.NpcUid)
    nbs:WriteInt(self.StageId)
    nbs:WriteInt(#self.DictMonster)
    for key, value in pairs(self.DictMonster) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_CampNpc:Unserialize(nbs)
    self.NpcUid = nbs:ReadInt()
    self.StageId = nbs:ReadInt()
    local var4187 = nbs:ReadInt()
    for i = 1, var4187 do
        local var4188 = nbs:ReadInt()
        local var4189 = LuaCLS_CampNpcMonster.new()
        var4189:Unserialize(nbs)
        self.DictMonster:Add(var4188, var4189)
    end
end
-- LuaCLS_CampNpc end


-- LuaC2G_Strategy_AttackNpcBalance begin
-- 请求 城池战斗匹配攻击NPC结算
LuaC2G_Strategy_AttackNpcBalance = Class(Base)
function LuaC2G_Strategy_AttackNpcBalance:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_ATTACKNPCBALANCE"]
    self.BattleCode = 0    -- 战斗验证码
    self.BattleResult = 0    -- 战斗结果 EBattleResult
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.NpcUid = 0    -- ID(1-n)
    self.DictMonster = Dictionary:New()    -- NPC部队兵力 k=位置0-n
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Strategy_AttackNpcBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleCode)
    nbs:WriteInt(self.BattleResult)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteInt(self.NpcUid)
    nbs:WriteInt(#self.DictMonster)
    for key, value in pairs(self.DictMonster) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_AttackNpcBalance end


-- LuaG2C_Strategy_AttackNpcBalance begin
-- 返回 城池战斗匹配攻击NPC结算
LuaG2C_Strategy_AttackNpcBalance = Class(Base)
function LuaG2C_Strategy_AttackNpcBalance:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_ATTACKNPCBALANCE"]
end
function LuaG2C_Strategy_AttackNpcBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Strategy_AttackNpcBalance end


-- LuaC2G_Strategy_AttackWallBalance begin
-- 请求 城池战斗匹配攻击城墙结算
LuaC2G_Strategy_AttackWallBalance = Class(Base)
function LuaC2G_Strategy_AttackWallBalance:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_ATTACKWALLBALANCE"]
    self.BattleCode = 0    -- 战斗验证码
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.WallHpDamage = 0    -- 城墙血量损失
    self.DictExpendHp = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Strategy_AttackWallBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.BattleCode)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    nbs:WriteLong(self.WallHpDamage)
    nbs:WriteInt(#self.DictExpendHp)
    for key, value in pairs(self.DictExpendHp) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_AttackWallBalance end


-- LuaG2C_Strategy_AttackWallBalance begin
-- 返回 城池战斗匹配攻击城墙结算
LuaG2C_Strategy_AttackWallBalance = Class(Base)
function LuaG2C_Strategy_AttackWallBalance:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_ATTACKWALLBALANCE"]
    self.ListAwardFirst = List:New(LuaCLS_AwardItem)    -- 首次攻占城池奖励
end
function LuaG2C_Strategy_AttackWallBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    local var4190 = nbs:ReadInt()
    for i = 1, var4190 do
        local var4191 = LuaCLS_AwardItem.new()
        var4191:Unserialize(nbs)
        self.ListAwardFirst:Add(var4191)
    end
end
-- LuaG2C_Strategy_AttackWallBalance end


-- LuaG2C_Strategy_NotifyMatchingAttackPlayer begin
-- 通知 城池战斗匹配攻击玩家
LuaG2C_Strategy_NotifyMatchingAttackPlayer = Class(Base)
function LuaG2C_Strategy_NotifyMatchingAttackPlayer:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_NOTIFYMATCHINGATTACKPLAYER"]
    self.BattleInfo = LuaCLS_BattleInfo.new()    -- 战场信息
end
function LuaG2C_Strategy_NotifyMatchingAttackPlayer:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BattleInfo:Unserialize(nbs)
end
-- LuaG2C_Strategy_NotifyMatchingAttackPlayer end


-- LuaC2G_Strategy_AttackPlayerBalance begin
-- 请求 城池战斗匹配攻击玩家结算
LuaC2G_Strategy_AttackPlayerBalance = Class(Base)
function LuaC2G_Strategy_AttackPlayerBalance:ctor()
    self._protocol = LuaProtocolId["C2G_STRATEGY_ATTACKPLAYERBALANCE"]
    self.BattleUid = 0    -- 战斗ID
    self.BattleResult = false    -- 战斗结果 攻击方胜利=true 防守方胜利=false
    self.DictExpendHpAtt = Dictionary:New()    -- 武将消耗兵力
    self.DictExpendHpDef = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Strategy_AttackPlayerBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.BattleUid)
    nbs:WriteBool(self.BattleResult)
    nbs:WriteInt(#self.DictExpendHpAtt)
    for key, value in pairs(self.DictExpendHpAtt) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(#self.DictExpendHpDef)
    for key, value in pairs(self.DictExpendHpDef) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Strategy_AttackPlayerBalance end


-- LuaG2C_Strategy_AttackPlayerBalance begin
-- 返回 城池战斗匹配攻击玩家结算
LuaG2C_Strategy_AttackPlayerBalance = Class(Base)
function LuaG2C_Strategy_AttackPlayerBalance:ctor()
    self._protocol = LuaProtocolId["G2C_STRATEGY_ATTACKPLAYERBALANCE"]
    self.BattleUid = 0    -- 战斗ID
    self.DictBattleResult = Dictionary:New()    -- k=Puid v=结果 胜利=true 失败=false
end
function LuaG2C_Strategy_AttackPlayerBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BattleUid = nbs:ReadInt()
    local var4194 = nbs:ReadInt()
    for i = 1, var4194 do
        local var4195 = nbs:ReadLong()
        local var4196 = nbs:ReadBool()
        self.DictBattleResult:Add(var4195, var4196)
    end
end
-- LuaG2C_Strategy_AttackPlayerBalance end


-- LuaCLS_MetroPvpInfo begin
-- 大城池PVP综合信息
LuaCLS_MetroPvpInfo = Class()
function LuaCLS_MetroPvpInfo:ctor()
    self.MetroPvpState = 0    -- 大城池PVP综合状态
end
function LuaCLS_MetroPvpInfo:Serialize(nbs)
    nbs:WriteShort(MetroPvpState)
    nbs:WriteDateTime(self.DtMetroPvpStart)
    nbs:WriteDateTime(self.DtMetroPvpEnd)
    return nbs
end
function LuaCLS_MetroPvpInfo:Unserialize(nbs)
    self.MetroPvpState = nbs:ReadShort()
    self.DtMetroPvpStart = nbs:ReadDateTime()
    self.DtMetroPvpEnd = nbs:ReadDateTime()
end
-- LuaCLS_MetroPvpInfo end


-- LuaCLS_StrategyCityInfoMetro begin
-- 城池战略信息大城池
LuaCLS_StrategyCityInfoMetro = Class()
function LuaCLS_StrategyCityInfoMetro:ctor()
    self.MetroCityStatus = 0    -- 大城池状态
end
function LuaCLS_StrategyCityInfoMetro:Serialize(nbs)
    nbs:WriteShort(MetroCityStatus)
    nbs:WriteTimeSpan(self.TsCooldownSeize)
    return nbs
end
function LuaCLS_StrategyCityInfoMetro:Unserialize(nbs)
    self.MetroCityStatus = nbs:ReadShort()
    self.TsCooldownSeize = nbs:ReadTimeSpan()
end
-- LuaCLS_StrategyCityInfoMetro end


-- LuaG2C_Metro_NotifyRefreshInfo begin
-- 通知 大城池PVP综合信息
LuaG2C_Metro_NotifyRefreshInfo = Class(Base)
function LuaG2C_Metro_NotifyRefreshInfo:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_NOTIFYREFRESHINFO"]
    self.MetroPvpInfo = LuaCLS_MetroPvpInfo.new()    -- 大城池PVP综合信息
end
function LuaG2C_Metro_NotifyRefreshInfo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.MetroPvpInfo:Unserialize(nbs)
end
-- LuaG2C_Metro_NotifyRefreshInfo end


-- LuaCLS_MetroTopScoreNode begin
-- 积分榜单条
LuaCLS_MetroTopScoreNode = Class()
function LuaCLS_MetroTopScoreNode:ctor()
    self.Rank = 0    -- 排名
    self.GuildUid = 0    -- 势力唯一ID
    self.GuildName = ""    -- 势力名
    self.Score = 0    -- 积分
end
function LuaCLS_MetroTopScoreNode:Serialize(nbs)
    nbs:WriteInt(self.Rank)
    nbs:WriteLong(self.GuildUid)
    nbs:WriteString(self.GuildName)
    nbs:WriteLong(self.Score)
    return nbs
end
function LuaCLS_MetroTopScoreNode:Unserialize(nbs)
    self.Rank = nbs:ReadInt()
    self.GuildUid = nbs:ReadLong()
    self.GuildName = nbs:ReadString()
    self.Score = nbs:ReadLong()
end
-- LuaCLS_MetroTopScoreNode end


-- LuaC2G_Metro_TopScore begin
-- 请求 郡城势力积分榜
LuaC2G_Metro_TopScore = Class(Base)
function LuaC2G_Metro_TopScore:ctor()
    self._protocol = LuaProtocolId["C2G_METRO_TOPSCORE"]
    self.Uid = 0    -- 城池唯一ID(配置ID)
end
function LuaC2G_Metro_TopScore:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.Uid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Metro_TopScore end


-- LuaG2C_Metro_TopScore begin
-- 返回 郡城势力积分榜
LuaG2C_Metro_TopScore = Class(Base)
function LuaG2C_Metro_TopScore:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_TOPSCORE"]
    self.Uid = 0    -- 城池唯一ID(配置ID)
    self.ScoreMy = LuaCLS_MetroTopScoreNode.new()    -- 自己
    self.ListScore = List:New(LuaCLS_MetroTopScoreNode)    -- 前十
end
function LuaG2C_Metro_TopScore:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.Uid = nbs:ReadInt()
    self.ScoreMy:Unserialize(nbs)
    local var4209 = nbs:ReadInt()
    for i = 1, var4209 do
        local var4210 = LuaCLS_MetroTopScoreNode.new()
        var4210:Unserialize(nbs)
        self.ListScore:Add(var4210)
    end
end
-- LuaG2C_Metro_TopScore end


-- LuaC2G_Metro_Matching begin
-- 请求 郡城匹配
LuaC2G_Metro_Matching = Class(Base)
function LuaC2G_Metro_Matching:ctor()
    self._protocol = LuaProtocolId["C2G_METRO_MATCHING"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
end
function LuaC2G_Metro_Matching:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.CityUid)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Metro_Matching end


-- LuaG2C_Metro_Matching begin
-- 返回 郡城匹配
LuaG2C_Metro_Matching = Class(Base)
function LuaG2C_Metro_Matching:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_MATCHING"]
end
function LuaG2C_Metro_Matching:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.DtMatchingStart = nbs:ReadDateTime()
    self.DtMatchingEnd = nbs:ReadDateTime()
end
-- LuaG2C_Metro_Matching end


-- LuaC2G_Metro_MatchingCancel begin
-- 请求 郡城匹配取消
LuaC2G_Metro_MatchingCancel = Class(Base)
function LuaC2G_Metro_MatchingCancel:ctor()
    self._protocol = LuaProtocolId["C2G_METRO_MATCHINGCANCEL"]
end
function LuaC2G_Metro_MatchingCancel:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Metro_MatchingCancel end


-- LuaG2C_Metro_MatchingCancel begin
-- 返回 郡城匹配取消
LuaG2C_Metro_MatchingCancel = Class(Base)
function LuaG2C_Metro_MatchingCancel:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_MATCHINGCANCEL"]
end
function LuaG2C_Metro_MatchingCancel:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Metro_MatchingCancel end


-- LuaG2C_Metro_NotifyMatchingEnd begin
-- 通知 郡城匹配结束
LuaG2C_Metro_NotifyMatchingEnd = Class(Base)
function LuaG2C_Metro_NotifyMatchingEnd:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_NOTIFYMATCHINGEND"]
    self.CityUid = 0    -- 城池唯一ID(配置ID)
end
function LuaG2C_Metro_NotifyMatchingEnd:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.CityUid = nbs:ReadInt()
end
-- LuaG2C_Metro_NotifyMatchingEnd end


-- LuaG2C_Metro_NotifyMatchingMetro begin
-- 通知 郡城匹配成功
LuaG2C_Metro_NotifyMatchingMetro = Class(Base)
function LuaG2C_Metro_NotifyMatchingMetro:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_NOTIFYMATCHINGMETRO"]
    self.BattleInfo = LuaCLS_BattleInfo.new()    -- 战场信息
end
function LuaG2C_Metro_NotifyMatchingMetro:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BattleInfo:Unserialize(nbs)
end
-- LuaG2C_Metro_NotifyMatchingMetro end


-- LuaC2G_Metro_AttackPlayerBalance begin
-- 请求 郡城战斗结算
LuaC2G_Metro_AttackPlayerBalance = Class(Base)
function LuaC2G_Metro_AttackPlayerBalance:ctor()
    self._protocol = LuaProtocolId["C2G_METRO_ATTACKPLAYERBALANCE"]
    self.BattleUid = 0    -- 战斗ID
    self.BattleResult = false    -- 战斗结果 攻击方胜利=true 防守方胜利=false
    self.DictExpendHpAtt = Dictionary:New()    -- 武将消耗兵力
    self.DictExpendHpDef = Dictionary:New()    -- 武将消耗兵力
end
function LuaC2G_Metro_AttackPlayerBalance:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteInt(self.BattleUid)
    nbs:WriteBool(self.BattleResult)
    nbs:WriteInt(#self.DictExpendHpAtt)
    for key, value in pairs(self.DictExpendHpAtt) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteInt(#self.DictExpendHpDef)
    for key, value in pairs(self.DictExpendHpDef) do
        nbs:WriteLong(key)
        nbs:WriteInt(value)
    end
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Metro_AttackPlayerBalance end


-- LuaG2C_Metro_AttackPlayerBalance begin
-- 返回 郡城战斗结算
LuaG2C_Metro_AttackPlayerBalance = Class(Base)
function LuaG2C_Metro_AttackPlayerBalance:ctor()
    self._protocol = LuaProtocolId["G2C_METRO_ATTACKPLAYERBALANCE"]
    self.BattleUid = 0    -- 战斗ID
    self.DictBattleResult = Dictionary:New()    -- k=Puid v=结果 胜利=true 失败=false
end
function LuaG2C_Metro_AttackPlayerBalance:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.BattleUid = nbs:ReadInt()
    local var4216 = nbs:ReadInt()
    for i = 1, var4216 do
        local var4217 = nbs:ReadLong()
        local var4218 = nbs:ReadBool()
        self.DictBattleResult:Add(var4217, var4218)
    end
end
-- LuaG2C_Metro_AttackPlayerBalance end


-- LuaCLS_BattlePlayer begin
-- 即时对战玩家信息
LuaCLS_BattlePlayer = Class()
function LuaCLS_BattlePlayer:ctor()
    self.Puid = 0    -- 玩家唯一ID
    self.Name = ""    -- 玩家昵称
    self.IsReady = false    -- 已准备
    self.DictWarrior = Dictionary:New()    -- 成员列表 <位置 武将战斗信息>
end
function LuaCLS_BattlePlayer:Serialize(nbs)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Name)
    nbs:WriteBool(self.IsReady)
    nbs:WriteInt(#self.DictWarrior)
    for key, value in pairs(self.DictWarrior) do
        nbs:WriteInt(key)
        value:Serialize(nbs)
    end
    return nbs
end
function LuaCLS_BattlePlayer:Unserialize(nbs)
    self.Puid = nbs:ReadLong()
    self.Name = nbs:ReadString()
    self.IsReady = nbs:ReadBool()
    local var4222 = nbs:ReadInt()
    for i = 1, var4222 do
        local var4223 = nbs:ReadInt()
        local var4224 = LuaCLS_WarriorInfo.new()
        var4224:Unserialize(nbs)
        self.DictWarrior:Add(var4223, var4224)
    end
end
-- LuaCLS_BattlePlayer end


-- LuaCLS_BattleInfo begin
-- 战场信息
LuaCLS_BattleInfo = Class()
function LuaCLS_BattleInfo:ctor()
    self.BattleUid = 0    -- 战斗ID
    self.BattleType = 0    -- 战场类型
    self.IsReadyAll = false    -- 已准备全部
    self.CityUid = 0    -- 城池唯一ID(配置ID)
    self.CampUid = 0    -- 唯一ID(1-5)(1=主营)
    self.BattlePlayerAtt = LuaCLS_BattlePlayer.new()    -- 攻击方
    self.BattlePlayerDef = LuaCLS_BattlePlayer.new()    -- 防守方
end
function LuaCLS_BattleInfo:Serialize(nbs)
    nbs:WriteInt(self.BattleUid)
    nbs:WriteShort(BattleType)
    nbs:WriteBool(self.IsReadyAll)
    nbs:WriteInt(self.CityUid)
    nbs:WriteInt(self.CampUid)
    BattlePlayerAtt:Serialize(nbs)
    BattlePlayerDef:Serialize(nbs)
    return nbs
end
function LuaCLS_BattleInfo:Unserialize(nbs)
    self.BattleUid = nbs:ReadInt()
    self.BattleType = nbs:ReadShort()
    self.IsReadyAll = nbs:ReadBool()
    self.CityUid = nbs:ReadInt()
    self.CampUid = nbs:ReadInt()
    self.BattlePlayerAtt:Unserialize(nbs)
    self.BattlePlayerDef:Unserialize(nbs)
end
-- LuaCLS_BattleInfo end


-- LuaC2G_Battle_Demo begin
-- 请求 测试
LuaC2G_Battle_Demo = Class(Base)
function LuaC2G_Battle_Demo:ctor()
    self._protocol = LuaProtocolId["C2G_BATTLE_DEMO"]
end
function LuaC2G_Battle_Demo:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Battle_Demo end


-- LuaG2C_Battle_Demo begin
-- 返回 测试
LuaG2C_Battle_Demo = Class(Base)
function LuaG2C_Battle_Demo:ctor()
    self._protocol = LuaProtocolId["G2C_BATTLE_DEMO"]
end
function LuaG2C_Battle_Demo:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Battle_Demo end


-- LuaC2G_Battle_Ready begin
-- 请求 准备
LuaC2G_Battle_Ready = Class(Base)
function LuaC2G_Battle_Ready:ctor()
    self._protocol = LuaProtocolId["C2G_BATTLE_READY"]
end
function LuaC2G_Battle_Ready:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Battle_Ready end


-- LuaG2C_Battle_Ready begin
-- 返回 准备
LuaG2C_Battle_Ready = Class(Base)
function LuaG2C_Battle_Ready:ctor()
    self._protocol = LuaProtocolId["G2C_BATTLE_READY"]
end
function LuaG2C_Battle_Ready:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
end
-- LuaG2C_Battle_Ready end


-- LuaG2C_Battle_NotifyReady begin
-- 通知 准备状态
LuaG2C_Battle_NotifyReady = Class(Base)
function LuaG2C_Battle_NotifyReady:ctor()
    self._protocol = LuaProtocolId["G2C_BATTLE_NOTIFYREADY"]
    self.IsReadyAll = false    -- 已准备全部
end
function LuaG2C_Battle_NotifyReady:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.IsReadyAll = nbs:ReadBool()
end
-- LuaG2C_Battle_NotifyReady end


-- LuaCLS_ForwardData begin
-- 转发数据
LuaCLS_ForwardData = Class()
function LuaCLS_ForwardData:ctor()
    self.Status = 0    -- 状态类型
    self.DictStatusData = Dictionary:New()    -- 状态数据
    self.Action = 0    -- 操作类型
    self.DictActionData = Dictionary:New()    -- 操作数据
end
function LuaCLS_ForwardData:Serialize(nbs)
    nbs:WriteShort(self.Status)
    nbs:WriteInt(#self.DictStatusData)
    for key, value in pairs(self.DictStatusData) do
        nbs:WriteString(key)
        nbs:WriteString(value)
    end
    nbs:WriteShort(self.Action)
    nbs:WriteInt(#self.DictActionData)
    for key, value in pairs(self.DictActionData) do
        nbs:WriteString(key)
        nbs:WriteString(value)
    end
    return nbs
end
function LuaCLS_ForwardData:Unserialize(nbs)
    self.Status = nbs:ReadShort()
    local var4234 = nbs:ReadInt()
    for i = 1, var4234 do
        local var4235 = nbs:ReadString()
        local var4236 = nbs:ReadString()
        self.DictStatusData:Add(var4235, var4236)
    end
    self.Action = nbs:ReadShort()
    local var4238 = nbs:ReadInt()
    for i = 1, var4238 do
        local var4239 = nbs:ReadString()
        local var4240 = nbs:ReadString()
        self.DictActionData:Add(var4239, var4240)
    end
end
-- LuaCLS_ForwardData end


-- LuaC2G_Battle_ForwardData begin
-- 请求 转发数据
LuaC2G_Battle_ForwardData = Class(Base)
function LuaC2G_Battle_ForwardData:ctor()
    self._protocol = LuaProtocolId["C2G_BATTLE_FORWARDDATA"]
    self.WarriorUid = 0    -- 武将唯一ID
    self.ForwardData = LuaCLS_ForwardData.new()    -- 转发数据
end
function LuaC2G_Battle_ForwardData:Serialize()
    local nbs = NetBitStreamLua()
    nbs:WriteShort(self._protocol)
    nbs:WriteShort(self._result)
    nbs:WriteLong(self.Pin)
    nbs:WriteLong(self.Puid)
    nbs:WriteString(self.Shuttle)
    nbs:WriteLong(self.WarriorUid)
    ForwardData:Serialize(nbs)
    nbs:WriteEnd()
    return nbs
end
-- LuaC2G_Battle_ForwardData end


-- LuaG2C_Battle_ForwardData begin
-- 返回 转发数据
LuaG2C_Battle_ForwardData = Class(Base)
function LuaG2C_Battle_ForwardData:ctor()
    self._protocol = LuaProtocolId["G2C_BATTLE_FORWARDDATA"]
    self.PlayerId = 0    -- 玩家唯一ID
    self.WarriorUid = 0    -- 武将唯一ID
    self.ForwardData = LuaCLS_ForwardData.new()    -- 转发数据
end
function LuaG2C_Battle_ForwardData:Unserialize(buffer)
    local nbs = NetBitStreamLua()
    nbs:BeginRead(buffer)
    self._protocol = nbs:ReadShort()
    self._result = nbs:ReadShort()
    self.Pin = nbs:ReadLong()
    self.Puid = nbs:ReadLong()
    self.Shuttle = nbs:ReadString()
    self.PlayerId = nbs:ReadLong()
    self.WarriorUid = nbs:ReadLong()
    self.ForwardData:Unserialize(nbs)
end
-- LuaG2C_Battle_ForwardData end


-- LuaG2A_Load_SetLoad begin
-- 集群服务器发送负载给中心服务器
LuaG2A_Load_SetLoad = Class(Base)
function LuaG2A_Load_SetLoad:ctor()
    self._protocol = LuaProtocolId["G2A_LOAD_SETLOAD"]
    self.Id = 0    -- 服务器ID
    self.Ip = ""    -- 服务器IP地址
    self.LinkType = 0    -- 服务器类型
    self.Name = ""    -- 服务器名字
    self.Load = 0    -- 负载人数
    self.ProcessID = 0    -- 进程ID
    self.Cpu = 0    -- 使用CPU
    self.Memory = 0    -- 使用内存
    self.Threads = 0    -- 使用线程
end
-- LuaG2A_Load_SetLoad end


-- LuaB2T_GM_Start begin
-- 集群服务器发送负载给中心服务器
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


-- LuaT2B_Mail_GlobalList begin
-- 请求 邮件列表
LuaT2B_Mail_GlobalList = Class(Base)
function LuaT2B_Mail_GlobalList:ctor()
    self._protocol = LuaProtocolId["T2B_MAIL_GLOBALLIST"]
end
-- LuaT2B_Mail_GlobalList end


-- LuaB2T_Mail_GlobalList begin
-- 返回 邮件列表
LuaB2T_Mail_GlobalList = Class(Base)
function LuaB2T_Mail_GlobalList:ctor()
    self._protocol = LuaProtocolId["B2T_MAIL_GLOBALLIST"]
    self.ListMail = List:New(LuaCLS_MailInfoDetails)    -- 邮件列表
end
-- LuaB2T_Mail_GlobalList end


-- LuaCLS_GmMailInfo begin
-- GM给玩家发送邮件信息
LuaCLS_GmMailInfo = Class()
function LuaCLS_GmMailInfo:ctor()
    self.Id = 0    -- 邮件ID
    self.TargetType = 0
    self.ListTarget = List:New(Luastring)    -- 接收者列表
    self.Title = ""    -- 标题
    self.Body = ""    -- 正文
    self.SenderName = ""    -- 邮件发送者
    self.ListAttachments = List:New(LuaCLS_AwardItem)    -- 附件列表
end
function LuaCLS_GmMailInfo:Serialize(nbs)
    nbs:WriteLong(self.Id)
    nbs:WriteShort(self.TargetType)
    nbs:WriteInt(#self.ListTarget)
    for i = 1, #self.ListTarget do
        nbs:WriteString(self.ListTarget[i])
    end
    nbs:WriteString(self.Title)
    nbs:WriteString(self.Body)
    nbs:WriteString(self.SenderName)
    nbs:WriteInt(#self.ListAttachments)
    for i = 1, #self.ListAttachments do
        (self.ListAttachments[i]):Serialize(nbs)
    end
    return nbs
end
function LuaCLS_GmMailInfo:Unserialize(nbs)
    self.Id = nbs:ReadLong()
    self.TargetType = nbs:ReadShort()
    local var4246 = nbs:ReadInt()
    for i = 1, var4246 do
        local var4247 = nbs:ReadString()
        self.ListTarget:Add(var4247)
    end
    self.Title = nbs:ReadString()
    self.Body = nbs:ReadString()
    self.SenderName = nbs:ReadString()
    local var4251 = nbs:ReadInt()
    for i = 1, var4251 do
        local var4252 = LuaCLS_AwardItem.new()
        var4252:Unserialize(nbs)
        self.ListAttachments:Add(var4252)
    end
end
-- LuaCLS_GmMailInfo end


-- LuaB2T_GmMail_Send begin
-- 请求 GM给玩家发送邮件
LuaB2T_GmMail_Send = Class(Base)
function LuaB2T_GmMail_Send:ctor()
    self._protocol = LuaProtocolId["B2T_GMMAIL_SEND"]
    self.MailInfo = LuaCLS_GmMailInfo.new()    -- 邮件信息
end
-- LuaB2T_GmMail_Send end


-- LuaT2B_GmMail_Send begin
-- 返回 GM给玩家发送邮件
LuaT2B_GmMail_Send = Class(Base)
function LuaT2B_GmMail_Send:ctor()
    self._protocol = LuaProtocolId["T2B_GMMAIL_SEND"]
    self.Msg = ""    -- 错误字符串
end
-- LuaT2B_GmMail_Send end


-- LuaB2T_Edit_Player begin
-- 发送 修改玩家数据
LuaB2T_Edit_Player = Class(Base)
function LuaB2T_Edit_Player:ctor()
    self._protocol = LuaProtocolId["B2T_EDIT_PLAYER"]
    self.IdType = ""
    self.Id = ""
    self.Mode = ""
    self.Arg = ""
end
-- LuaB2T_Edit_Player end


-- LuaT2B_Edit_Player begin
-- 返回 修改玩家数据
LuaT2B_Edit_Player = Class(Base)
function LuaT2B_Edit_Player:ctor()
    self._protocol = LuaProtocolId["T2B_EDIT_PLAYER"]
    self.Msg = ""    -- 错误字符串
end
-- LuaT2B_Edit_Player end


-- LuaB2T_Bank_Conf begin
-- 请求 长安夺宝配置
LuaB2T_Bank_Conf = Class(Base)
function LuaB2T_Bank_Conf:ctor()
    self._protocol = LuaProtocolId["B2T_BANK_CONF"]
    self.BankConf = LuaCLS_BankConf.new()    -- 配置 （根据IsSeted判断是查看还是设置）
end
-- LuaB2T_Bank_Conf end


-- LuaT2B_Bank_Conf begin
-- 返回 长安夺宝配置
LuaT2B_Bank_Conf = Class(Base)
function LuaT2B_Bank_Conf:ctor()
    self._protocol = LuaProtocolId["T2B_BANK_CONF"]
    self.BankConf = LuaCLS_BankConf.new()    -- 配置
end
-- LuaT2B_Bank_Conf end


-- LuaB2T_Bank_Info begin
-- 请求 长安夺宝详情
LuaB2T_Bank_Info = Class(Base)
function LuaB2T_Bank_Info:ctor()
    self._protocol = LuaProtocolId["B2T_BANK_INFO"]
end
-- LuaB2T_Bank_Info end


-- LuaT2B_Bank_Info begin
-- 返回 长安夺宝详情
LuaT2B_Bank_Info = Class(Base)
function LuaT2B_Bank_Info:ctor()
    self._protocol = LuaProtocolId["T2B_BANK_INFO"]
    self.Infos = List:New(LuaCLS_WarZoneInfo)    -- 详情
end
-- LuaT2B_Bank_Info end


-- LuaB2T_GM_End begin
-- 返回 长安夺宝详情
LuaB2T_GM_End = Class(Base)
function LuaB2T_GM_End:ctor()
    self._protocol = LuaProtocolId["B2T_GM_END"]
end
-- LuaB2T_GM_End end




