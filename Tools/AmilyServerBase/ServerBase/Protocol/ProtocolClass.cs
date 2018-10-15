
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    [Desc("奖励物品")]
    public partial class CLS_AwardItem
    {
        [Desc("类型 对应 EAwardType")]
        public short Type = 0;
        [Desc("奖励配置ID")]
        public int ConfigId = 0;
        [Desc("奖励数量")]
        public long Count = 0;
        [Desc("等级")]
        public int Level = 0;
    };
    [Desc("当前数量和上限数量")]
    public partial class CLS_CountInfo
    {
        [Desc("当前")]
        public long Value = 0;
        [Desc("上限")]
        public long Limit = 0;
    };
    [Desc("需求数量和当前数量")]
    public partial class CLS_NeedInfo
    {
        [Desc("需求")]
        public long Need = 0;
        [Desc("当前")]
        public long Value = 0;
    };
    [Desc("当前数量和原来数量")]
    public partial class CLS_ValueChangeInfo
    {
        [Desc("原数值")]
        public long ValueOld = 0;
        [Desc("当前")]
        public long ValueNew = 0;
    };
    [Desc("道具需求信息")]
    public partial class CLS_ItemNeedInfo
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        [Desc("需求数量")]
        public int CountNeed = 0;
    };
    [Desc("玩家公共信息")]
    public partial class CLS_PubPlayerBase
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("头像序号")]
        public int HeadIndex = 0;
        [Desc("所属州ID")]
        public int StateId = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("所属势力唯一ID")]
        public long GuildUid = 0;
        [Desc("势力官职 EGuildOffice")]
        public int GuildOffice = 0;
        [Desc("战斗力")]
        public int CombatPower = 0;
        [Desc("上次登录时间")]
        public long TickTimeLastLogin = 0;
        [Desc("圣女资格")]
        public bool bGoddess = false;
    };
    [Desc("快照数据")]
    public partial class CLS_DataSnap
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("服务器ID")]
        public int ServerID = 0;
        [Desc("昵称")]
        public string Name = "";
        [Desc("头像序号(序号为0时使用图像数据)")]
        public int HeadIndex = 0;
        [Desc("所属州ID")]
        public int StateId = 0;
        [Desc("元宝")]
        public long Gem = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("上次登录时间")]
        public long TickTimeLastLogin = 0;
        [Desc("活跃度状态 见EActivityLevel")]
        public int ActivityLevel = 0;
        [Desc("所属府ID")]
        public long Mansion = 0;
        [Desc("所属势力唯一ID")]
        public long GuildUid = 0;
        [Desc("势力官职 EGuildOffice")]
        public int GuildOffice = 0;
        [Desc("贡献")]
        public int Contribution = 0;
        [Desc("历史贡献")]
        public int ContributionTotal = 0;
        [Desc("战斗力")]
        public int CombatPower = 0;
        [Desc("主角加竞技场武将战力")]
        public int AllArenaCombatPower = 0;
        [Desc("玩家单条信息")]
        public CLS_PlayerData PlayerData = new CLS_PlayerData();
        [Desc("圣女资格")]
        public bool bGoddess = false;
    };
    [Desc("玩家单条信息")]
    public partial class CLS_PlayerData
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("头像序号(序号为0时使用图像数据)")]
        public int HeadIndex = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("分数")]
        public long Score = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("防守队伍信息<位置，信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictArenaWarrior = new Dictionary<int, CLS_WarriorInfo>();
        [Desc("个人签名")]
        public string Signature = "";
        [Desc("势力名称")]
        public string GuildName = "";
    };
    [Desc("动态日志")]
    public partial class CLS_GameLog
    {
        public DateTime GameLogTime = DateTime.Now;
        [Desc("动态日志类型 EGameLogType")]
        public EGameLogType GameLogType = new EGameLogType();
        [Desc("参数")]
        public List<string> Args = new List<string>();
    };
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
    [Desc("请求 调试指令")]
    public partial class C2G_Debug_Cmd : ProtocolMsgBase, INbsSerializer
    {
        public int Cmd = 0;
        public List<string> ListArgs = new List<string>();
        public C2G_Debug_Cmd() { ProtocolId = EProtocolId.C2G_DEBUG_CMD; }
        public C2G_Debug_Cmd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 调试指令")]
    public partial class G2C_Debug_Cmd : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Debug_Cmd() { ProtocolId = EProtocolId.G2C_DEBUG_CMD; }
        public G2C_Debug_Cmd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("连接成功")]
    public partial class G2C_Login_Connect : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_Connect() { ProtocolId = EProtocolId.G2C_LOGIN_CONNECT; }
        public G2C_Login_Connect(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 登陆用户账号")]
    public partial class C2L_Login_UserLogin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("账号")]
        public string Account = "";
        [Desc("密码")]
        public string Password = "";
        public C2L_Login_UserLogin() { ProtocolId = EProtocolId.C2L_LOGIN_USERLOGIN; }
        public C2L_Login_UserLogin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 登陆用户账号")]
    public partial class L2C_Login_UserLogin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("用户id")]
        public long Uuid = 0;
        [Desc("验证码")]
        public long Code = 0;
        [Desc("是否需要显示协议")]
        public bool NeedAgree = false;
        public L2C_Login_UserLogin() { ProtocolId = EProtocolId.L2C_LOGIN_USERLOGIN; }
        public L2C_Login_UserLogin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 登陆玩家")]
    public partial class C2G_Login_PlayerLogin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("用户id")]
        public long Uuid = 0;
        [Desc("验证码")]
        public long Code = 0;
        public C2G_Login_PlayerLogin() { ProtocolId = EProtocolId.C2G_LOGIN_PLAYERLOGIN; }
        public C2G_Login_PlayerLogin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 登陆玩家")]
    public partial class G2C_Login_PlayerLogin : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_PlayerLogin() { ProtocolId = EProtocolId.G2C_LOGIN_PLAYERLOGIN; }
        public G2C_Login_PlayerLogin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 玩家创建")]
    public partial class C2G_Login_PlayerCreate : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家名字")]
        public string Name = "";
        [Desc("头像")]
        public int Head = 0;
        [Desc("所属州ID")]
        public int StateId = 0;
        public C2G_Login_PlayerCreate() { ProtocolId = EProtocolId.C2G_LOGIN_PLAYERCREATE; }
        public C2G_Login_PlayerCreate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 玩家创建")]
    public partial class G2C_Login_PlayerCreate : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_PlayerCreate() { ProtocolId = EProtocolId.G2C_LOGIN_PLAYERCREATE; }
        public G2C_Login_PlayerCreate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知玩家被取代连接")]
    public partial class G2C_Login_Replaced : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_Replaced() { ProtocolId = EProtocolId.G2C_LOGIN_REPLACED; }
        public G2C_Login_Replaced(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知玩家被封号")]
    public partial class G2C_Login_Ban : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_Ban() { ProtocolId = EProtocolId.G2C_LOGIN_BAN; }
        public G2C_Login_Ban(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("州信息")]
    public partial class CLS_LoginStateInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("人口数")]
        public long Population = 0;
    };
    [Desc("请求 州信息")]
    public partial class C2G_Login_ListState : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Login_ListState() { ProtocolId = EProtocolId.C2G_LOGIN_LISTSTATE; }
        public C2G_Login_ListState(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 州信息")]
    public partial class G2C_Login_ListState : ProtocolMsgBase, INbsSerializer
    {
        [Desc("州信息")]
        public List<CLS_LoginStateInfo> ListState = new List<CLS_LoginStateInfo>();
        public G2C_Login_ListState() { ProtocolId = EProtocolId.G2C_LOGIN_LISTSTATE; }
        public G2C_Login_ListState(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 检测名字")]
    public partial class C2G_Login_CheckName : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家名字")]
        public string Name = "";
        public C2G_Login_CheckName() { ProtocolId = EProtocolId.C2G_LOGIN_CHECKNAME; }
        public C2G_Login_CheckName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 检测名字")]
    public partial class G2C_Login_CheckName : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Login_CheckName() { ProtocolId = EProtocolId.G2C_LOGIN_CHECKNAME; }
        public G2C_Login_CheckName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("玩家基本信息")]
    public partial class CLS_Info_Base
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("头像序号(序号为0时使用图像数据)")]
        public int HeadIndex = 0;
        [Desc("所属州ID")]
        public int StateId = 0;
        [Desc("元宝")]
        public long Gem = 0;
        [Desc("金币")]
        public long Gold = 0;
        [Desc("府玉")]
        public long FuYu = 0;
        [Desc("银两")]
        public long Silver = 0;
        [Desc("木材")]
        public long Wood = 0;
        [Desc("铁矿")]
        public long Iron = 0;
        [Desc("粮草")]
        public long Food = 0;
        [Desc("木材容量")]
        public long CapacityWood = 0;
        [Desc("铁矿容量")]
        public long CapacityIron = 0;
        [Desc("粮草容量")]
        public long CapacityFood = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验值")]
        public int Exp = 0;
        [Desc("VIP等级")]
        public int VipLevel = 0;
        [Desc("Vip经验值")]
        public int VipExp = 0;
        [Desc("体力")]
        public int Spirit = 0;
        [Desc("挑战令牌")]
        public int TowerToken = 0;
        [Desc("武神积分")]
        public int TowerScore = 0;
        [Desc("军牌")]
        public int Card = 0;
        [Desc("声望")]
        public int Prestige = 0;
        [Desc("宴会厅积分")]
        public int DrawScore = 0;
        [Desc("所属势力唯一ID")]
        public long GuildUid = 0;
        [Desc("势力官职 EGuildOffice")]
        public int GuildOffice = 0;
        [Desc("所属势力名字")]
        public string GuildName = "";
        [Desc("势力都城")]
        public int MyCapitalCity = 0;
        [Desc("势力所属州")]
        public int GuildState = 0;
        [Desc("预备步兵")]
        public int Soldiers1 = 0;
        [Desc("预备骑兵")]
        public int Soldiers2 = 0;
        [Desc("预备弓兵")]
        public int Soldiers3 = 0;
        [Desc("购买金币次数")]
        public int BuyGoldTimes = 0;
    };
    [Desc("玩家杂项信息")]
    public partial class CLS_Info_Misc
    {
        [Desc("客户端特殊标记")]
        public Dictionary<int, int> dictFlagClient = new Dictionary<int, int>();
        [Desc("木材已满")]
        public bool WoodFull = false;
        [Desc("铁矿已满")]
        public bool IronFull = false;
        [Desc("粮草已满")]
        public bool FoodFull = false;
        [Desc("可以签到")]
        public bool CanSign = false;
        [Desc("未读邮件数目")]
        public int MailUnread = 0;
        [Desc("长安夺宝活动状态 1 开启 0未开启")]
        public int BankStatus = 0;
        [Desc("武将背包当前已买ID")]
        public int WarriorBagId = 0;
        [Desc("当前武将数目")]
        public int WarriorCount = 0;
        [Desc("武将背包上限")]
        public int WarriorCountMax = 0;
        [Desc("个人签名")]
        public string Signature = "";
        [Desc("好友提示")]
        public bool bFriend = false;
        [Desc("私聊提示")]
        public bool bChat = false;
        [Desc("注册时间")]
        public long TickTimeRegister = 0;
        [Desc("同盟势力")]
        public List<long> ListAlliance = new List<long>();
        [Desc("我方城池")]
        public List<int> ListGuildCityMy = new List<int>();
        [Desc("同盟城池")]
        public List<int> ListGuildCityAlliance = new List<int>();
        [Desc("福利开启")]
        public bool WelfareIsOpen = false;
        [Desc("福利完成数目")]
        public int WelfareNoticeNum = 0;
    };
    [Desc("请求 玩家全部信息")]
    public partial class C2G_Info_GetAll : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Info_GetAll() { ProtocolId = EProtocolId.C2G_INFO_GETALL; }
        public C2G_Info_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 玩家全部信息")]
    public partial class G2C_Info_GetAll : ProtocolMsgBase, INbsSerializer
    {
        public CLS_Info_Base InfoBase = new CLS_Info_Base();
        public CLS_Info_Misc InfoMisc = new CLS_Info_Misc();
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Info_GetAll() { ProtocolId = EProtocolId.G2C_INFO_GETALL; }
        public G2C_Info_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 玩家信息 全部")]
    public partial class G2C_Info_PushAll : ProtocolMsgBase, INbsSerializer
    {
        public CLS_Info_Base InfoBase = new CLS_Info_Base();
        public CLS_Info_Misc InfoMisc = new CLS_Info_Misc();
        public G2C_Info_PushAll() { ProtocolId = EProtocolId.G2C_INFO_PUSHALL; }
        public G2C_Info_PushAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 玩家信息 道具")]
    public partial class G2C_Info_PushItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Info_PushItem() { ProtocolId = EProtocolId.G2C_INFO_PUSHITEM; }
        public G2C_Info_PushItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 玩家信息 装备")]
    public partial class G2C_Info_PushEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("页码1-n (返回每页100条) (0=结束)")]
        public int PageIndex = 0;
        [Desc("装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        public G2C_Info_PushEquip() { ProtocolId = EProtocolId.G2C_INFO_PUSHEQUIP; }
        public G2C_Info_PushEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 玩家信息 武将")]
    public partial class G2C_Info_PushWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("页码1-n (返回每页100条) (0=结束)")]
        public int PageIndex = 0;
        [Desc("武将列表")]
        public List<CLS_WarriorInfo> ListWarrior = new List<CLS_WarriorInfo>();
        public G2C_Info_PushWarrior() { ProtocolId = EProtocolId.G2C_INFO_PUSHWARRIOR; }
        public G2C_Info_PushWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("更新 道具")]
    public partial class CLS_UpdateInfoItem
    {
        public byte Mode = 0;
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
    };
    [Desc("更新 装备")]
    public partial class CLS_UpdateInfoEquip
    {
        public byte Mode = 0;
        public CLS_EquipInfo EquipInfo = new CLS_EquipInfo();
    };
    [Desc("更新 武将")]
    public partial class CLS_UpdateInfoWarrior
    {
        public byte Mode = 0;
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
    };
    [Desc("推送 玩家信息 更新")]
    public partial class G2C_Info_PushUpdate : ProtocolMsgBase, INbsSerializer
    {
        public List<CLS_UpdateInfoItem> ListUpdateItem = new List<CLS_UpdateInfoItem>();
        public List<CLS_UpdateInfoEquip> ListUpdateEquip = new List<CLS_UpdateInfoEquip>();
        public List<CLS_UpdateInfoWarrior> ListUpdateWarrior = new List<CLS_UpdateInfoWarrior>();
        public G2C_Info_PushUpdate() { ProtocolId = EProtocolId.G2C_INFO_PUSHUPDATE; }
        public G2C_Info_PushUpdate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 更改姓名")]
    public partial class C2G_Info_ChangeName : ProtocolMsgBase, INbsSerializer
    {
        public string Name = "";
        public C2G_Info_ChangeName() { ProtocolId = EProtocolId.C2G_INFO_CHANGENAME; }
        public C2G_Info_ChangeName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 更改姓名")]
    public partial class G2C_Info_ChangeName : ProtocolMsgBase, INbsSerializer
    {
        public string Name = "";
        public G2C_Info_ChangeName() { ProtocolId = EProtocolId.G2C_INFO_CHANGENAME; }
        public G2C_Info_ChangeName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 更改客户端特殊标记")]
    public partial class C2G_Info_ChangeFlagClient : ProtocolMsgBase, INbsSerializer
    {
        public int FlagKey = 0;
        public int FlagValue = 0;
        public C2G_Info_ChangeFlagClient() { ProtocolId = EProtocolId.C2G_INFO_CHANGEFLAGCLIENT; }
        public C2G_Info_ChangeFlagClient(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 更改客户端特殊标记")]
    public partial class G2C_Info_ChangeFlagClient : ProtocolMsgBase, INbsSerializer
    {
        public int FlagKey = 0;
        public int FlagValue = 0;
        public G2C_Info_ChangeFlagClient() { ProtocolId = EProtocolId.G2C_INFO_CHANGEFLAGCLIENT; }
        public G2C_Info_ChangeFlagClient(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 更换头像")]
    public partial class C2G_Info_ChangeHeadIndex : ProtocolMsgBase, INbsSerializer
    {
        [Desc("头像序号(序号为0时使用图像数据)")]
        public int HeadIndex = 0;
        public C2G_Info_ChangeHeadIndex() { ProtocolId = EProtocolId.C2G_INFO_CHANGEHEADINDEX; }
        public C2G_Info_ChangeHeadIndex(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 更换头像")]
    public partial class G2C_Info_ChangeHeadIndex : ProtocolMsgBase, INbsSerializer
    {
        [Desc("头像序号(序号为0时使用图像数据)")]
        public int HeadIndex = 0;
        public G2C_Info_ChangeHeadIndex() { ProtocolId = EProtocolId.G2C_INFO_CHANGEHEADINDEX; }
        public G2C_Info_ChangeHeadIndex(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 上传头像数据")]
    public partial class C2G_Info_ChangeHeadData : ProtocolMsgBase, INbsSerializer
    {
        [Desc("头像数据")]
        public List<byte> HeadData = new List<byte>();
        public C2G_Info_ChangeHeadData() { ProtocolId = EProtocolId.C2G_INFO_CHANGEHEADDATA; }
        public C2G_Info_ChangeHeadData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 上传头像数据")]
    public partial class G2C_Info_ChangeHeadData : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Info_ChangeHeadData() { ProtocolId = EProtocolId.G2C_INFO_CHANGEHEADDATA; }
        public G2C_Info_ChangeHeadData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 反馈问题")]
    public partial class C2G_Info_SubmitBug : ProtocolMsgBase, INbsSerializer
    {
        public string Text = "";
        public C2G_Info_SubmitBug() { ProtocolId = EProtocolId.C2G_INFO_SUBMITBUG; }
        public C2G_Info_SubmitBug(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 反馈问题")]
    public partial class G2C_Info_SubmitBug : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Info_SubmitBug() { ProtocolId = EProtocolId.G2C_INFO_SUBMITBUG; }
        public G2C_Info_SubmitBug(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 玩家升级")]
    public partial class G2C_Info_NotifyLevelUp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("等级变化")]
        public CLS_ValueChangeInfo ChangeLevel = new CLS_ValueChangeInfo();
        [Desc("经验变化")]
        public CLS_ValueChangeInfo ChangeExp = new CLS_ValueChangeInfo();
        [Desc("体力变化")]
        public CLS_ValueChangeInfo ChangeSpirit = new CLS_ValueChangeInfo();
        public G2C_Info_NotifyLevelUp() { ProtocolId = EProtocolId.G2C_INFO_NOTIFYLEVELUP; }
        public G2C_Info_NotifyLevelUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 玩家单条信息")]
    public partial class C2G_Info_PlayerData : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        public C2G_Info_PlayerData() { ProtocolId = EProtocolId.C2G_INFO_PLAYERDATA; }
        public C2G_Info_PlayerData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 玩家单条信息")]
    public partial class G2C_Info_PlayerData : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家单条信息")]
        public CLS_PlayerData PlayerInfo = new CLS_PlayerData();
        [Desc("是否是好友")]
        public bool bFriend = false;
        [Desc("是否已屏蔽")]
        public bool bScreen = false;
        public G2C_Info_PlayerData() { ProtocolId = EProtocolId.G2C_INFO_PLAYERDATA; }
        public G2C_Info_PlayerData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 更改个人签名")]
    public partial class C2G_Info_ChangeSignature : ProtocolMsgBase, INbsSerializer
    {
        public string Signature = "";
        public C2G_Info_ChangeSignature() { ProtocolId = EProtocolId.C2G_INFO_CHANGESIGNATURE; }
        public C2G_Info_ChangeSignature(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 更改个人签名")]
    public partial class G2C_Info_ChangeSignature : ProtocolMsgBase, INbsSerializer
    {
        public string Signature = "";
        public G2C_Info_ChangeSignature() { ProtocolId = EProtocolId.G2C_INFO_CHANGESIGNATURE; }
        public G2C_Info_ChangeSignature(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 系统公告")]
    public partial class C2G_Notice_System : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Notice_System() { ProtocolId = EProtocolId.C2G_NOTICE_SYSTEM; }
        public C2G_Notice_System(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 系统公告")]
    public partial class G2C_Notice_System : ProtocolMsgBase, INbsSerializer
    {
        [Desc("内容")]
        public string Text = "";
        public G2C_Notice_System() { ProtocolId = EProtocolId.G2C_NOTICE_SYSTEM; }
        public G2C_Notice_System(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 活动公告")]
    public partial class C2G_Notice_Activity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Notice_Activity() { ProtocolId = EProtocolId.C2G_NOTICE_ACTIVITY; }
        public C2G_Notice_Activity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 活动公告")]
    public partial class G2C_Notice_Activity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("内容")]
        public List<string> ListText = new List<string>();
        public G2C_Notice_Activity() { ProtocolId = EProtocolId.G2C_NOTICE_ACTIVITY; }
        public G2C_Notice_Activity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("发送 走马灯")]
    public partial class G2C_Notice_Rolling : ProtocolMsgBase, INbsSerializer
    {
        [Desc("走马灯类型 见ENoticeRollingType")]
        public byte Type = 0;
        [Desc("内容")]
        public string Text = "";
        [Desc("播放次数")]
        public int Count = 0;
        public G2C_Notice_Rolling() { ProtocolId = EProtocolId.G2C_NOTICE_ROLLING; }
        public G2C_Notice_Rolling(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("邮件信息")]
    public partial class CLS_MailInfo
    {
        [Desc("邮件ID")]
        public long Id = 0;
        [Desc("邮件类型")]
        public short MailType = 0;
        [Desc("标题")]
        public string Title = "";
        [Desc("是否有附件")]
        public bool HasAttachments = false;
        [Desc("已读")]
        public bool Readed = false;
        [Desc("已领")]
        public bool Got = false;
        [Desc("保存")]
        public bool Saved = false;
        [Desc("发送时间")]
        public string CreateTime = "";
        [Desc("已发邮件")]
        public bool Sended = false;
        [Desc("收件人(已发邮件生效 个人邮件:名字 郡邮件:郡ID 府邮件:府ID)")]
        public string ReceiveName = "";
        [Desc("发件人名字")]
        public string SenderName = "";
    };
    [Desc("邮件信息 详细")]
    public partial class CLS_MailInfoDetails
    {
        [Desc("邮件ID")]
        public long Id = 0;
        [Desc("邮件信息")]
        public CLS_MailInfo MailInfo = new CLS_MailInfo();
        [Desc("正文")]
        public string Body = "";
        [Desc("附件列表")]
        public List<CLS_AwardItem> listAward = new List<CLS_AwardItem>();
    };
    [Desc("邮件信息 发送")]
    public partial class CLS_MailInfoSend
    {
        public short MailType = 0;
        [Desc("标题")]
        public string Title = "";
        [Desc("正文")]
        public string Body = "";
        [Desc("发件人名字")]
        public string SenderName = "";
        [Desc("收件人名字")]
        public string ReceiveName = "";
    };
    [Desc(" 系统给玩家发送邮件信息")]
    public partial class CLS_SystemMailInfoSend
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public short TargetType = 0;
        [Desc("接收者列表")]
        public List<string> ListTarget = new List<string>();
        [Desc("标题")]
        public string Title = "";
        [Desc("正文")]
        public string Body = "";
        [Desc("邮件发送者")]
        public string SenderName = "";
        [Desc("附件列表")]
        public List<CLS_AwardItem> ListAttachments = new List<CLS_AwardItem>();
    };
    [Desc("请求 邮件列表")]
    public partial class C2G_Mail_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Mail_List() { ProtocolId = EProtocolId.C2G_MAIL_LIST; }
        public C2G_Mail_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件列表")]
    public partial class G2C_Mail_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件列表")]
        public List<CLS_MailInfo> ListMail = new List<CLS_MailInfo>();
        public G2C_Mail_List() { ProtocolId = EProtocolId.G2C_MAIL_LIST; }
        public G2C_Mail_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件读取")]
    public partial class C2G_Mail_Read : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public C2G_Mail_Read() { ProtocolId = EProtocolId.C2G_MAIL_READ; }
        public C2G_Mail_Read(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件读取")]
    public partial class G2C_Mail_Read : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        [Desc("邮件信息详细")]
        public CLS_MailInfoDetails Details = new CLS_MailInfoDetails();
        public G2C_Mail_Read() { ProtocolId = EProtocolId.G2C_MAIL_READ; }
        public G2C_Mail_Read(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件领取附件")]
    public partial class C2G_Mail_Get : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public C2G_Mail_Get() { ProtocolId = EProtocolId.C2G_MAIL_GET; }
        public C2G_Mail_Get(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件领取附件")]
    public partial class G2C_Mail_Get : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        [Desc("附件列表")]
        public List<CLS_AwardItem> listAward = new List<CLS_AwardItem>();
        public G2C_Mail_Get() { ProtocolId = EProtocolId.G2C_MAIL_GET; }
        public G2C_Mail_Get(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件一键领取")]
    public partial class C2G_Mail_GetAll : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Mail_GetAll() { ProtocolId = EProtocolId.C2G_MAIL_GETALL; }
        public C2G_Mail_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件一键领取")]
    public partial class G2C_Mail_GetAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("附件列表")]
        public List<CLS_AwardItem> listAward = new List<CLS_AwardItem>();
        public G2C_Mail_GetAll() { ProtocolId = EProtocolId.G2C_MAIL_GETALL; }
        public G2C_Mail_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件删除")]
    public partial class C2G_Mail_Delete : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public C2G_Mail_Delete() { ProtocolId = EProtocolId.C2G_MAIL_DELETE; }
        public C2G_Mail_Delete(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件删除")]
    public partial class G2C_Mail_Delete : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public G2C_Mail_Delete() { ProtocolId = EProtocolId.G2C_MAIL_DELETE; }
        public G2C_Mail_Delete(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件清理已读")]
    public partial class C2G_Mail_DeleteReaded : ProtocolMsgBase, INbsSerializer
    {
        [Desc("要删除的当前页面类型")]
        public short MailType = 0;
        public C2G_Mail_DeleteReaded() { ProtocolId = EProtocolId.C2G_MAIL_DELETEREADED; }
        public C2G_Mail_DeleteReaded(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件清理已读")]
    public partial class G2C_Mail_DeleteReaded : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新后邮件列表")]
        public List<CLS_MailInfo> ListMail = new List<CLS_MailInfo>();
        public G2C_Mail_DeleteReaded() { ProtocolId = EProtocolId.G2C_MAIL_DELETEREADED; }
        public G2C_Mail_DeleteReaded(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件保存/取消保存")]
    public partial class C2G_Mail_Save : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public C2G_Mail_Save() { ProtocolId = EProtocolId.C2G_MAIL_SAVE; }
        public C2G_Mail_Save(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件保存/取消保存")]
    public partial class G2C_Mail_Save : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public G2C_Mail_Save() { ProtocolId = EProtocolId.G2C_MAIL_SAVE; }
        public G2C_Mail_Save(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 邮件发送")]
    public partial class C2G_Mail_Send : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件发送信息")]
        public CLS_MailInfoSend MailInfoSend = new CLS_MailInfoSend();
        public C2G_Mail_Send() { ProtocolId = EProtocolId.C2G_MAIL_SEND; }
        public C2G_Mail_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件发送")]
    public partial class G2C_Mail_Send : ProtocolMsgBase, INbsSerializer
    {
        [Desc("新加的已发邮件列表")]
        public CLS_MailInfo MailInfo = new CLS_MailInfo();
        public G2C_Mail_Send() { ProtocolId = EProtocolId.G2C_MAIL_SEND; }
        public G2C_Mail_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("聊天玩家信息")]
    public partial class CLS_ChatPlayerBase
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("头像序号")]
        public int HeadIndex = 0;
    };
    [Desc("聊天信息")]
    public partial class CLS_ChatMsg
    {
        [Desc("消息时间")]
        public DateTime ChatTime = DateTime.Now;
        [Desc("聊天频道 见EChatChannel")]
        public short Channel = 0;
        [Desc("发送者信息")]
        public CLS_ChatPlayerBase SenderInfo = new CLS_ChatPlayerBase();
        [Desc("文本")]
        public string Text = "";
    };
    [Desc("私聊记录")]
    public partial class CLS_ChatList
    {
        [Desc("对方信息")]
        public CLS_ChatPlayerBase Info = new CLS_ChatPlayerBase();
        public List<CLS_ChatMsg> ListChatMsgs = new List<CLS_ChatMsg>();
    };
    [Desc("请求 聊天信息发送")]
    public partial class C2G_Chat_Send : ProtocolMsgBase, INbsSerializer
    {
        [Desc("聊天频道 见EChatChannel")]
        public short Channel = 0;
        [Desc("文本")]
        public string Text = "";
        [Desc("对方唯一ID")]
        public long Uid = 0;
        public C2G_Chat_Send() { ProtocolId = EProtocolId.C2G_CHAT_SEND; }
        public C2G_Chat_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 聊天信息发送")]
    public partial class G2C_Chat_Send : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Chat_Send() { ProtocolId = EProtocolId.G2C_CHAT_SEND; }
        public G2C_Chat_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 聊天信息接收")]
    public partial class G2C_Chat_Receive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("聊天信息列表")]
        public List<CLS_ChatMsg> ListChatMsgs = new List<CLS_ChatMsg>();
        public G2C_Chat_Receive() { ProtocolId = EProtocolId.G2C_CHAT_RECEIVE; }
        public G2C_Chat_Receive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 请求私聊数据")]
    public partial class C2G_Chat_GetPrivateChat : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Chat_GetPrivateChat() { ProtocolId = EProtocolId.C2G_CHAT_GETPRIVATECHAT; }
        public C2G_Chat_GetPrivateChat(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 聊天信息发送")]
    public partial class G2C_Chat_GetPrivateChat : ProtocolMsgBase, INbsSerializer
    {
        public Dictionary<long, CLS_ChatList> DictChatInfo = new Dictionary<long, CLS_ChatList>();
        public G2C_Chat_GetPrivateChat() { ProtocolId = EProtocolId.G2C_CHAT_GETPRIVATECHAT; }
        public G2C_Chat_GetPrivateChat(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 删除最近联系人")]
    public partial class C2G_Chat_Remove : ProtocolMsgBase, INbsSerializer
    {
        public long Uid = 0;
        public C2G_Chat_Remove() { ProtocolId = EProtocolId.C2G_CHAT_REMOVE; }
        public C2G_Chat_Remove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 删除最近联系人")]
    public partial class G2C_Chat_Remove : ProtocolMsgBase, INbsSerializer
    {
        public long Uid = 0;
        public G2C_Chat_Remove() { ProtocolId = EProtocolId.G2C_CHAT_REMOVE; }
        public G2C_Chat_Remove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("玩家单条信息")]
    public partial class CLS_FriendInfo
    {
        [Desc("玩家唯一ID")]
        public long Uid = 0;
        [Desc("头像")]
        public int HeadIndex = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("等级")]
        public int Level = 0;
        [Desc("个人签名")]
        public string Signature = "";
        [Desc("体力状态：1-可领取 2-可赠送 3-已赠送")]
        public int GiveState = 0;
        [Desc("是否在线")]
        public bool bOnline = false;
    };
    [Desc("请求 好友列表")]
    public partial class C2G_Friend_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Friend_List() { ProtocolId = EProtocolId.C2G_FRIEND_LIST; }
        public C2G_Friend_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 好友列表")]
    public partial class G2C_Friend_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("好友列表")]
        public List<CLS_FriendInfo> ListItem = new List<CLS_FriendInfo>();
        public G2C_Friend_List() { ProtocolId = EProtocolId.G2C_FRIEND_LIST; }
        public G2C_Friend_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 申请列表")]
    public partial class C2G_Friend_ListApply : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Friend_ListApply() { ProtocolId = EProtocolId.C2G_FRIEND_LISTAPPLY; }
        public C2G_Friend_ListApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 申请列表")]
    public partial class G2C_Friend_ListApply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("申请列表")]
        public List<CLS_FriendInfo> ListItem = new List<CLS_FriendInfo>();
        public G2C_Friend_ListApply() { ProtocolId = EProtocolId.G2C_FRIEND_LISTAPPLY; }
        public G2C_Friend_ListApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 推荐列表")]
    public partial class C2G_Friend_ListRecommend : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Friend_ListRecommend() { ProtocolId = EProtocolId.C2G_FRIEND_LISTRECOMMEND; }
        public C2G_Friend_ListRecommend(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 推荐列表")]
    public partial class G2C_Friend_ListRecommend : ProtocolMsgBase, INbsSerializer
    {
        [Desc("推荐列表")]
        public List<CLS_FriendInfo> ListItem = new List<CLS_FriendInfo>();
        public G2C_Friend_ListRecommend() { ProtocolId = EProtocolId.G2C_FRIEND_LISTRECOMMEND; }
        public G2C_Friend_ListRecommend(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 申请好友")]
    public partial class C2G_Friend_Apply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public C2G_Friend_Apply() { ProtocolId = EProtocolId.C2G_FRIEND_APPLY; }
        public C2G_Friend_Apply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 申请好友")]
    public partial class G2C_Friend_Apply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public bool bFriend = false;
        public G2C_Friend_Apply() { ProtocolId = EProtocolId.G2C_FRIEND_APPLY; }
        public G2C_Friend_Apply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 添加好友")]
    public partial class C2G_Friend_Add : ProtocolMsgBase, INbsSerializer
    {
        [Desc("是否同意")]
        public bool bAgree = false;
        [Desc("是否全部")]
        public bool bAll = false;
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public C2G_Friend_Add() { ProtocolId = EProtocolId.C2G_FRIEND_ADD; }
        public C2G_Friend_Add(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 添加好友")]
    public partial class G2C_Friend_Add : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Friend_Add() { ProtocolId = EProtocolId.G2C_FRIEND_ADD; }
        public G2C_Friend_Add(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 请求删除")]
    public partial class C2G_Friend_Remove : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public C2G_Friend_Remove() { ProtocolId = EProtocolId.C2G_FRIEND_REMOVE; }
        public C2G_Friend_Remove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 请求删除")]
    public partial class G2C_Friend_Remove : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Friend_Remove() { ProtocolId = EProtocolId.G2C_FRIEND_REMOVE; }
        public G2C_Friend_Remove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 赠送体力")]
    public partial class C2G_Friend_Give : ProtocolMsgBase, INbsSerializer
    {
        [Desc("全部赠送")]
        public bool bAll = false;
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public C2G_Friend_Give() { ProtocolId = EProtocolId.C2G_FRIEND_GIVE; }
        public C2G_Friend_Give(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 赠送体力")]
    public partial class G2C_Friend_Give : ProtocolMsgBase, INbsSerializer
    {
        [Desc("赠送体力")]
        public int total = 0;
        public G2C_Friend_Give() { ProtocolId = EProtocolId.G2C_FRIEND_GIVE; }
        public G2C_Friend_Give(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 领取体力")]
    public partial class C2G_Friend_Receive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("全部领取")]
        public bool bAll = false;
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        public C2G_Friend_Receive() { ProtocolId = EProtocolId.C2G_FRIEND_RECEIVE; }
        public C2G_Friend_Receive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 领取体力")]
    public partial class G2C_Friend_Receive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("领取体力")]
        public int total = 0;
        public G2C_Friend_Receive() { ProtocolId = EProtocolId.G2C_FRIEND_RECEIVE; }
        public G2C_Friend_Receive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 屏蔽好友")]
    public partial class C2G_Friend_Screen : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        [Desc("是否屏蔽")]
        public bool bScreen = false;
        public C2G_Friend_Screen() { ProtocolId = EProtocolId.C2G_FRIEND_SCREEN; }
        public C2G_Friend_Screen(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 屏蔽好友")]
    public partial class G2C_Friend_Screen : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家唯一ID")]
        public long Uid = 0;
        [Desc("是否屏蔽")]
        public bool bScreen = false;
        public G2C_Friend_Screen() { ProtocolId = EProtocolId.G2C_FRIEND_SCREEN; }
        public G2C_Friend_Screen(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池信息简单")]
    public partial class CLS_MapCitySimple
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("城池归属 EOwnership")]
        public byte Ownership = 0;
    };
    [Desc("请求 城池列表")]
    public partial class C2G_Map_ListCity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Map_ListCity() { ProtocolId = EProtocolId.C2G_MAP_LISTCITY; }
        public C2G_Map_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池列表")]
    public partial class G2C_Map_ListCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池列表")]
        public List<CLS_MapCitySimple> ListCity = new List<CLS_MapCitySimple>();
        [Desc("同盟势力")]
        public List<long> ListAlliance = new List<long>();
        [Desc("我方城池")]
        public List<int> ListGuildCityMy = new List<int>();
        [Desc("同盟城池")]
        public List<int> ListGuildCityAlliance = new List<int>();
        public G2C_Map_ListCity() { ProtocolId = EProtocolId.G2C_MAP_LISTCITY; }
        public G2C_Map_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池信息")]
    public partial class CLS_MapCityInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("占据势力名")]
        public string GuildName = "";
        [Desc("太守名")]
        public string LeaderName = "";
        [Desc("繁荣度")]
        public long Prosperity = 0;
    };
    [Desc("请求 城池信息")]
    public partial class C2G_Map_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        public C2G_Map_CityInfo() { ProtocolId = EProtocolId.C2G_MAP_CITYINFO; }
        public C2G_Map_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池信息")]
    public partial class G2C_Map_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池信息")]
        public CLS_MapCityInfo CityInfo = new CLS_MapCityInfo();
        public G2C_Map_CityInfo() { ProtocolId = EProtocolId.G2C_MAP_CITYINFO; }
        public G2C_Map_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("我方城池信息")]
    public partial class CLS_MapMyCityInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("繁荣度")]
        public long Prosperity = 0;
    };
    [Desc("请求 我方城池列表")]
    public partial class C2G_Map_ListMyCity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Map_ListMyCity() { ProtocolId = EProtocolId.C2G_MAP_LISTMYCITY; }
        public C2G_Map_ListMyCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 我方城池列表")]
    public partial class G2C_Map_ListMyCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("我方城池列表")]
        public List<CLS_MapMyCityInfo> ListMyCity = new List<CLS_MapMyCityInfo>();
        public G2C_Map_ListMyCity() { ProtocolId = EProtocolId.G2C_MAP_LISTMYCITY; }
        public G2C_Map_ListMyCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("道具信息")]
    public partial class CLS_ItemInfo
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
    };
    [Desc("请求 道具列表")]
    public partial class C2G_Item_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Item_List() { ProtocolId = EProtocolId.C2G_ITEM_LIST; }
        public C2G_Item_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 道具列表")]
    public partial class G2C_Item_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Item_List() { ProtocolId = EProtocolId.G2C_ITEM_LIST; }
        public G2C_Item_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 道具卖店")]
    public partial class C2G_Item_Sell : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        public C2G_Item_Sell() { ProtocolId = EProtocolId.C2G_ITEM_SELL; }
        public C2G_Item_Sell(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 道具卖店")]
    public partial class G2C_Item_Sell : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Item_Sell() { ProtocolId = EProtocolId.G2C_ITEM_SELL; }
        public G2C_Item_Sell(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 道具使用")]
    public partial class C2G_Item_Use : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("类型0:使用，1:合成")]
        public int Type = 0;
        [Desc("数量")]
        public int Count = 0;
        public C2G_Item_Use() { ProtocolId = EProtocolId.C2G_ITEM_USE; }
        public C2G_Item_Use(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 道具使用")]
    public partial class G2C_Item_Use : ProtocolMsgBase, INbsSerializer
    {
        [Desc("类型0:使用，1:合成")]
        public int Type = 0;
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Item_Use() { ProtocolId = EProtocolId.G2C_ITEM_USE; }
        public G2C_Item_Use(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 资源道具列表")]
    public partial class C2G_Item_ResourcesList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具类型 EUseEffect")]
        public int Type = 0;
        public C2G_Item_ResourcesList() { ProtocolId = EProtocolId.C2G_ITEM_RESOURCESLIST; }
        public C2G_Item_ResourcesList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 资源道具列表")]
    public partial class G2C_Item_ResourcesList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Item_ResourcesList() { ProtocolId = EProtocolId.G2C_ITEM_RESOURCESLIST; }
        public G2C_Item_ResourcesList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 资源道具使用")]
    public partial class C2G_Item_ResourcesUse : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具")]
        public List<CLS_ItemInfo> Items = new List<CLS_ItemInfo>();
        [Desc("道具类型 EUseEffect")]
        public int Type = 0;
        public C2G_Item_ResourcesUse() { ProtocolId = EProtocolId.C2G_ITEM_RESOURCESUSE; }
        public C2G_Item_ResourcesUse(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 资源道具使用")]
    public partial class G2C_Item_ResourcesUse : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Item_ResourcesUse() { ProtocolId = EProtocolId.G2C_ITEM_RESOURCESUSE; }
        public G2C_Item_ResourcesUse(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 资源道具购买")]
    public partial class C2G_Item_ResourcesBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具ID ShopSpeedUp表里的ID")]
        public int ID = 0;
        [Desc("数量")]
        public int Amount = 0;
        [Desc("道具类型 EUseEffect")]
        public int Type = 0;
        public C2G_Item_ResourcesBuy() { ProtocolId = EProtocolId.C2G_ITEM_RESOURCESBUY; }
        public C2G_Item_ResourcesBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 资源道具购买")]
    public partial class G2C_Item_ResourcesBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Item_ResourcesBuy() { ProtocolId = EProtocolId.G2C_ITEM_RESOURCESBUY; }
        public G2C_Item_ResourcesBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 战斗使用道具")]
    public partial class C2G_Item_CombatUse : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        [Desc("转发战斗效果")]
        public int CombatType = 0;
        public C2G_Item_CombatUse() { ProtocolId = EProtocolId.C2G_ITEM_COMBATUSE; }
        public C2G_Item_CombatUse(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 战斗使用道具")]
    public partial class G2C_Item_CombatUse : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        [Desc("转发战斗效果")]
        public int CombatType = 0;
        [Desc("道具列表")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Item_CombatUse() { ProtocolId = EProtocolId.G2C_ITEM_COMBATUSE; }
        public G2C_Item_CombatUse(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("装备高级属性")]
    public partial class CLS_EquipSuffix
    {
        [Desc("配置ID")]
        public int ConfigId = 0;
        [Desc("属性类型 见EPassiveType")]
        public int PassiveType = 0;
        [Desc("属性制")]
        public float SuffixValue = 0.0f;
    };
    [Desc("装备信息")]
    public partial class CLS_EquipInfo
    {
        [Desc("装备唯一ID")]
        public long Id = 0;
        [Desc("配置ID")]
        public int ConfigId = 0;
        [Desc("装备类型 见EEquipType")]
        public int EquipType = 0;
        [Desc("强化等级")]
        public int Intensify = 0;
        [Desc("战斗属性")]
        public Dictionary<int, float> CombatProperty = new Dictionary<int, float>();
        [Desc("自定义名称")]
        public string MarkName = "";
        public List<CLS_EquipSuffix> SuffixProperty = new List<CLS_EquipSuffix>();
    };
    [Desc("请求 装备列表")]
    public partial class C2G_Equip_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Equip_List() { ProtocolId = EProtocolId.C2G_EQUIP_LIST; }
        public C2G_Equip_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 装备列表")]
    public partial class G2C_Equip_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("页码1-n (返回每页100条) (0=结束)")]
        public int PageIndex = 0;
        [Desc("装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        public G2C_Equip_List() { ProtocolId = EProtocolId.G2C_EQUIP_LIST; }
        public G2C_Equip_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将装备列表")]
    public partial class C2G_Equip_WarriorList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long Id = 0;
        public C2G_Equip_WarriorList() { ProtocolId = EProtocolId.C2G_EQUIP_WARRIORLIST; }
        public C2G_Equip_WarriorList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将装备列表")]
    public partial class G2C_Equip_WarriorList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将已装备列表<装备位置, 信息>")]
        public Dictionary<int, CLS_EquipInfo> DictEquiped = new Dictionary<int, CLS_EquipInfo>();
        [Desc("武将装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        [Desc("武将现信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Equip_WarriorList() { ProtocolId = EProtocolId.G2C_EQUIP_WARRIORLIST; }
        public G2C_Equip_WarriorList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 所有武将装备列表")]
    public partial class C2G_Equip_WarriorAll : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Equip_WarriorAll() { ProtocolId = EProtocolId.C2G_EQUIP_WARRIORALL; }
        public C2G_Equip_WarriorAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 所有武将装备列表")]
    public partial class G2C_Equip_WarriorAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        public G2C_Equip_WarriorAll() { ProtocolId = EProtocolId.G2C_EQUIP_WARRIORALL; }
        public G2C_Equip_WarriorAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将装备运用")]
    public partial class C2G_Equip_WarriorWield : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long WarriorId = 0;
        [Desc("装备唯一ID")]
        public long Id = 0;
        public C2G_Equip_WarriorWield() { ProtocolId = EProtocolId.C2G_EQUIP_WARRIORWIELD; }
        public C2G_Equip_WarriorWield(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将装备运用")]
    public partial class G2C_Equip_WarriorWield : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将已装备列表<装备位置, 信息>")]
        public Dictionary<int, CLS_EquipInfo> DictEquiped = new Dictionary<int, CLS_EquipInfo>();
        [Desc("武将装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        [Desc("武将现信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Equip_WarriorWield() { ProtocolId = EProtocolId.G2C_EQUIP_WARRIORWIELD; }
        public G2C_Equip_WarriorWield(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将装备卸下")]
    public partial class C2G_Equip_WarriorRemove : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long WarriorId = 0;
        [Desc("装备位置(装备类型)")]
        public int EquipType = 0;
        public C2G_Equip_WarriorRemove() { ProtocolId = EProtocolId.C2G_EQUIP_WARRIORREMOVE; }
        public C2G_Equip_WarriorRemove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将装备卸下")]
    public partial class G2C_Equip_WarriorRemove : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将已装备列表<装备位置, 信息>")]
        public Dictionary<int, CLS_EquipInfo> DictEquiped = new Dictionary<int, CLS_EquipInfo>();
        [Desc("武将装备列表")]
        public Dictionary<long, CLS_EquipInfo> DictEquip = new Dictionary<long, CLS_EquipInfo>();
        [Desc("武将现信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Equip_WarriorRemove() { ProtocolId = EProtocolId.G2C_EQUIP_WARRIORREMOVE; }
        public G2C_Equip_WarriorRemove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将装备分解")]
    public partial class C2G_Equip_WarriorResolve : ProtocolMsgBase, INbsSerializer
    {
        [Desc("分解装备列表唯一ID")]
        public List<long> Id = new List<long>();
        public C2G_Equip_WarriorResolve() { ProtocolId = EProtocolId.C2G_EQUIP_WARRIORRESOLVE; }
        public C2G_Equip_WarriorResolve(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将装备分解")]
    public partial class G2C_Equip_WarriorResolve : ProtocolMsgBase, INbsSerializer
    {
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Equip_WarriorResolve() { ProtocolId = EProtocolId.G2C_EQUIP_WARRIORRESOLVE; }
        public G2C_Equip_WarriorResolve(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 装备修改名称")]
    public partial class C2G_Equip_Rename : ProtocolMsgBase, INbsSerializer
    {
        [Desc("装备自定义名称")]
        public string MarkName = "";
        public C2G_Equip_Rename() { ProtocolId = EProtocolId.C2G_EQUIP_RENAME; }
        public C2G_Equip_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 装备修改名称")]
    public partial class G2C_Equip_Rename : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Equip_Rename() { ProtocolId = EProtocolId.G2C_EQUIP_RENAME; }
        public G2C_Equip_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 装备强化信息")]
    public partial class C2G_Equip_IntensifyInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("装备ID")]
        public long EquipID = 0;
        public C2G_Equip_IntensifyInfo() { ProtocolId = EProtocolId.C2G_EQUIP_INTENSIFYINFO; }
        public C2G_Equip_IntensifyInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 装备强化信息")]
    public partial class G2C_Equip_IntensifyInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("强化信息")]
        public CLS_EquipIntensifyInfo IntensityInfo = new CLS_EquipIntensifyInfo();
        public G2C_Equip_IntensifyInfo() { ProtocolId = EProtocolId.G2C_EQUIP_INTENSIFYINFO; }
        public G2C_Equip_IntensifyInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 装备强化")]
    public partial class C2G_Equip_Intensify : ProtocolMsgBase, INbsSerializer
    {
        [Desc("装备ID")]
        public long EquipID = 0;
        public C2G_Equip_Intensify() { ProtocolId = EProtocolId.C2G_EQUIP_INTENSIFY; }
        public C2G_Equip_Intensify(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 装备强化")]
    public partial class G2C_Equip_Intensify : ProtocolMsgBase, INbsSerializer
    {
        [Desc("强化信息")]
        public CLS_EquipIntensifyInfo IntensityInfo = new CLS_EquipIntensifyInfo();
        [Desc("结果 对应EIntensifyResult")]
        public int IntensifyResult = 0;
        [Desc("产物")]
        public List<CLS_AwardItem> AwardItem = new List<CLS_AwardItem>();
        public G2C_Equip_Intensify() { ProtocolId = EProtocolId.G2C_EQUIP_INTENSIFY; }
        public G2C_Equip_Intensify(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("装备强化信息")]
    public partial class CLS_EquipIntensifyInfo
    {
        [Desc("强化等级")]
        public int IntensityId = 0;
        [Desc("攻击")]
        public float Atk = 0.0f;
        [Desc("防御")]
        public float Def = 0.0f;
        [Desc("兵力")]
        public int Hp = 0;
        [Desc("谋略")]
        public float Inte = 0.0f;
        [Desc("强化后攻击")]
        public float IntensityAtk = 0.0f;
        [Desc("强化后防御")]
        public float IntensityDef = 0.0f;
        [Desc("强化后谋略")]
        public float IntensityInte = 0.0f;
        [Desc("强化后兵力")]
        public int IntensityHp = 0;
        [Desc("银两消耗")]
        public int Gold = 0;
        [Desc("需求道具列表")]
        public List<CLS_ItemNeedInfo> ListItemNeedInfo = new List<CLS_ItemNeedInfo>();
    };
    [Desc("技能信息")]
    public partial class CLS_SkillInfo
    {
        [Desc("技能ID(配置ID SkillId)")]
        public int SkillId = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验值")]
        public int Exp = 0;
    };
    [Desc("组合信息")]
    public partial class CLS_WarriorCollect
    {
        [Desc("组合ID(配置ID)")]
        public int CollectId = 0;
        [Desc("是否生效")]
        public bool Valid = false;
        [Desc("已有武将配置ID<武将ID 是否有>")]
        public Dictionary<int, bool> DictHas = new Dictionary<int, bool>();
    };
    [Desc("武将信息")]
    public partial class CLS_WarriorInfo
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("配置ID")]
        public int ConfigId = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验")]
        public int Exp = 0;
        [Desc("武将自定义名称")]
        public string MarkName = "";
        [Desc("锁定")]
        public bool Lock = false;
        [Desc("募兵")]
        public bool InRecruit = false;
        [Desc("上阵")]
        public bool InBattle = false;
        [Desc("被俘虏")]
        public bool Captive = false;
        [Desc("被雇佣")]
        public bool Employed = false;
        [Desc("出征PVP")]
        public bool InArmy = false;
        [Desc("军务中")]
        public bool InAffairs = false;
        [Desc("矿点占领")]
        public bool InGrab = false;
        [Desc("武将技能列表")]
        public List<CLS_SkillInfo> ListSkill = new List<CLS_SkillInfo>();
        [Desc("进阶等级")]
        public int AdvanceLv = 0;
        [Desc("固定攻击")]
        public float BaseAtk = 0.0f;
        [Desc("固定防御")]
        public float BaseDef = 0.0f;
        [Desc("固定生命")]
        public int BaseHp = 0;
        [Desc("固定谋略")]
        public float BaseInte = 0.0f;
        [Desc("固定攻城")]
        public float BaseBreak = 0.0f;
        [Desc("战斗属性")]
        public Dictionary<int, float> CombatProperty = new Dictionary<int, float>();
        [Desc("当前兵力")]
        public int CurrentHp = 0;
        [Desc("战斗力")]
        public int CombatPower = 0;
        [Desc("武将已装备列表<装备位置, 信息>")]
        public Dictionary<int, CLS_EquipInfo> DictEquiped = new Dictionary<int, CLS_EquipInfo>();
        [Desc("星级")]
        public int Satr = 0;
        [Desc("觉醒等级")]
        public int WakeLevel = 0;
        [Desc("武将觉醒列表<觉醒位置, 等级>")]
        public Dictionary<int, int> DictWake = new Dictionary<int, int>();
        [Desc("武将强化列表<强化id, 值>")]
        public Dictionary<int, float> DictStremgthen = new Dictionary<int, float>();
        [Desc("武将组合列表<组合id, 组合内容>")]
        public Dictionary<int, CLS_WarriorCollect> DictWarriorCollect = new Dictionary<int, CLS_WarriorCollect>();
    };
    [Desc("请求 武将列表")]
    public partial class C2G_Warrior_WarriorList : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Warrior_WarriorList() { ProtocolId = EProtocolId.C2G_WARRIOR_WARRIORLIST; }
        public C2G_Warrior_WarriorList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将列表")]
    public partial class G2C_Warrior_WarriorList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将列表")]
        public List<CLS_WarriorInfo> ListWarrior = new List<CLS_WarriorInfo>();
        [Desc("上阵列表")]
        public List<long> ListInBattle = new List<long>();
        public G2C_Warrior_WarriorList() { ProtocolId = EProtocolId.G2C_WARRIOR_WARRIORLIST; }
        public G2C_Warrior_WarriorList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将锁定/解锁")]
    public partial class C2G_Warrior_Lock : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        public C2G_Warrior_Lock() { ProtocolId = EProtocolId.C2G_WARRIOR_LOCK; }
        public C2G_Warrior_Lock(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将锁定/解锁")]
    public partial class G2C_Warrior_Lock : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        public G2C_Warrior_Lock() { ProtocolId = EProtocolId.G2C_WARRIOR_LOCK; }
        public G2C_Warrior_Lock(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将进阶")]
    public partial class C2G_Warrior_Advance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("材料武将ID")]
        public List<long> MateriaWarriorID = new List<long>();
        public C2G_Warrior_Advance() { ProtocolId = EProtocolId.C2G_WARRIOR_ADVANCE; }
        public C2G_Warrior_Advance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将进阶")]
    public partial class G2C_Warrior_Advance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Warrior_Advance() { ProtocolId = EProtocolId.G2C_WARRIOR_ADVANCE; }
        public G2C_Warrior_Advance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将修改昵称")]
    public partial class C2G_Warrior_Rename : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("武将自定义名称")]
        public string MarkName = "";
        public C2G_Warrior_Rename() { ProtocolId = EProtocolId.C2G_WARRIOR_RENAME; }
        public C2G_Warrior_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将修改昵称")]
    public partial class G2C_Warrior_Rename : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_Rename() { ProtocolId = EProtocolId.G2C_WARRIOR_RENAME; }
        public G2C_Warrior_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将升级")]
    public partial class C2G_Warrior_UpLevel : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("使用武将信息")]
        public List<long> ListWarrior = new List<long>();
        public C2G_Warrior_UpLevel() { ProtocolId = EProtocolId.C2G_WARRIOR_UPLEVEL; }
        public C2G_Warrior_UpLevel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将升级")]
    public partial class G2C_Warrior_UpLevel : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验")]
        public int Exp = 0;
        public G2C_Warrior_UpLevel() { ProtocolId = EProtocolId.G2C_WARRIOR_UPLEVEL; }
        public G2C_Warrior_UpLevel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 武将升级")]
    public partial class G2C_Warrior_NotifyLevelUp : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_NotifyLevelUp() { ProtocolId = EProtocolId.G2C_WARRIOR_NOTIFYLEVELUP; }
        public G2C_Warrior_NotifyLevelUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将培养信息")]
    public partial class C2G_Warrior_ImproveInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Warrior_ImproveInfo() { ProtocolId = EProtocolId.C2G_WARRIOR_IMPROVEINFO; }
        public C2G_Warrior_ImproveInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将培养信息")]
    public partial class G2C_Warrior_ImproveInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表(武将培养类)")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Warrior_ImproveInfo() { ProtocolId = EProtocolId.G2C_WARRIOR_IMPROVEINFO; }
        public G2C_Warrior_ImproveInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将培养")]
    public partial class C2G_Warrior_Improve : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        [Desc("使用道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
        public C2G_Warrior_Improve() { ProtocolId = EProtocolId.C2G_WARRIOR_IMPROVE; }
        public C2G_Warrior_Improve(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将培养")]
    public partial class G2C_Warrior_Improve : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_Improve() { ProtocolId = EProtocolId.G2C_WARRIOR_IMPROVE; }
        public G2C_Warrior_Improve(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将升星")]
    public partial class C2G_Warrior_Star : ProtocolMsgBase, INbsSerializer
    {
        [Desc("升星武将唯一ID")]
        public long Id = 0;
        [Desc("材料武将ID")]
        public List<long> MateriaWarriorID = new List<long>();
        public C2G_Warrior_Star() { ProtocolId = EProtocolId.C2G_WARRIOR_STAR; }
        public C2G_Warrior_Star(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将升星")]
    public partial class G2C_Warrior_Star : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_Star() { ProtocolId = EProtocolId.G2C_WARRIOR_STAR; }
        public G2C_Warrior_Star(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将技能")]
    public partial class C2G_Warrior_Skill : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long Id = 0;
        [Desc("技能ID")]
        public int Skill = 0;
        public C2G_Warrior_Skill() { ProtocolId = EProtocolId.C2G_WARRIOR_SKILL; }
        public C2G_Warrior_Skill(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将技能")]
    public partial class G2C_Warrior_Skill : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_Skill() { ProtocolId = EProtocolId.G2C_WARRIOR_SKILL; }
        public G2C_Warrior_Skill(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将觉醒条件激活")]
    public partial class C2G_Warrior_WakeUnlock : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long Id = 0;
        [Desc("激活类型  EWakeDataType")]
        public int Type = 0;
        public C2G_Warrior_WakeUnlock() { ProtocolId = EProtocolId.C2G_WARRIOR_WAKEUNLOCK; }
        public C2G_Warrior_WakeUnlock(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将觉醒条件激活")]
    public partial class G2C_Warrior_WakeUnlock : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_WakeUnlock() { ProtocolId = EProtocolId.G2C_WARRIOR_WAKEUNLOCK; }
        public G2C_Warrior_WakeUnlock(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将觉醒材料信息")]
    public partial class C2G_Warrior_WakeInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long Id = 0;
        [Desc("激活类型  EWakeDataType")]
        public int Type = 0;
        public C2G_Warrior_WakeInfo() { ProtocolId = EProtocolId.C2G_WARRIOR_WAKEINFO; }
        public C2G_Warrior_WakeInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将觉醒材料信息")]
    public partial class G2C_Warrior_WakeInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("需求道具列表")]
        public List<CLS_ItemNeedInfo> ListItemNeedInfo = new List<CLS_ItemNeedInfo>();
        [Desc("最大关卡ID")]
        public int maxStoryId = 0;
        public G2C_Warrior_WakeInfo() { ProtocolId = EProtocolId.G2C_WARRIOR_WAKEINFO; }
        public G2C_Warrior_WakeInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将觉醒")]
    public partial class C2G_Warrior_WakeUp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Id = 0;
        public C2G_Warrior_WakeUp() { ProtocolId = EProtocolId.C2G_WARRIOR_WAKEUP; }
        public C2G_Warrior_WakeUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将觉醒")]
    public partial class G2C_Warrior_WakeUp : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_WakeUp() { ProtocolId = EProtocolId.G2C_WARRIOR_WAKEUP; }
        public G2C_Warrior_WakeUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将出售")]
    public partial class C2G_Warrior_Sell : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public List<long> ListIds = new List<long>();
        public C2G_Warrior_Sell() { ProtocolId = EProtocolId.C2G_WARRIOR_SELL; }
        public C2G_Warrior_Sell(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将出售")]
    public partial class G2C_Warrior_Sell : ProtocolMsgBase, INbsSerializer
    {
        [Desc("卖店价格")]
        public int Money = 0;
        public G2C_Warrior_Sell() { ProtocolId = EProtocolId.G2C_WARRIOR_SELL; }
        public G2C_Warrior_Sell(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("封地建筑信息")]
    public partial class CLS_BuildingPlayerInfo
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("建筑类型")]
        public int BuildingType = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("容量")]
        public long Capacity = 0;
        [Desc("库存")]
        public long Stock = 0;
        [Desc("仓库容量")]
        public long StoreCapacity = 0;
        [Desc("仓库库存")]
        public long StoreStock = 0;
        [Desc("容量下一级增量")]
        public long CapacityNextLevelAdd = 0;
        [Desc("是否在建造中")]
        public bool IsInBuilding = false;
        [Desc("剩余毫秒数")]
        public long BuildEndMs = 0;
        [Desc("每小时产量")]
        public int YieldPerHour = 0;
        [Desc("每小时产量下一级增量")]
        public int YieldPerHourNextLevelAdd = 0;
        [Desc("建造消耗时间")]
        public TimeSpan CostTime = new TimeSpan();
        [Desc("建造消耗游戏币")]
        public int CostGold = 0;
        [Desc("建造消耗粮草")]
        public int CostFood = 0;
        [Desc("建造消耗木材")]
        public int CostWood = 0;
        [Desc("建造消耗铁矿")]
        public int CostIron = 0;
    };
    [Desc("封地建筑简易信息 用来推送")]
    public partial class CLS_BuildingPlayerInfoSimple
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("库存")]
        public long Stock = 0;
    };
    [Desc("请求 封地建筑列表")]
    public partial class C2G_BuildingPlayer_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_BuildingPlayer_List() { ProtocolId = EProtocolId.C2G_BUILDINGPLAYER_LIST; }
        public C2G_BuildingPlayer_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 封地建筑列表")]
    public partial class G2C_BuildingPlayer_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("封地建筑列表")]
        public Dictionary<int, CLS_BuildingPlayerInfo> DictBuilding = new Dictionary<int, CLS_BuildingPlayerInfo>();
        public G2C_BuildingPlayer_List() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_LIST; }
        public G2C_BuildingPlayer_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 封地建筑简易信息")]
    public partial class G2C_BuildingPlayer_PushInfoSimple : ProtocolMsgBase, INbsSerializer
    {
        [Desc("封地建筑简易信息")]
        public Dictionary<int, CLS_BuildingPlayerInfoSimple> DictBuilding = new Dictionary<int, CLS_BuildingPlayerInfoSimple>();
        public G2C_BuildingPlayer_PushInfoSimple() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_PUSHINFOSIMPLE; }
        public G2C_BuildingPlayer_PushInfoSimple(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 封地建筑收获")]
    public partial class C2G_BuildingPlayer_Harvest : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_BuildingPlayer_Harvest() { ProtocolId = EProtocolId.C2G_BUILDINGPLAYER_HARVEST; }
        public C2G_BuildingPlayer_Harvest(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 封地建筑收获")]
    public partial class G2C_BuildingPlayer_Harvest : ProtocolMsgBase, INbsSerializer
    {
        [Desc("收取数量")]
        public int CountHarvest = 0;
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        public G2C_BuildingPlayer_Harvest() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_HARVEST; }
        public G2C_BuildingPlayer_Harvest(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 封地建筑一键收获")]
    public partial class C2G_BuildingPlayer_HarvestAll : ProtocolMsgBase, INbsSerializer
    {
        public C2G_BuildingPlayer_HarvestAll() { ProtocolId = EProtocolId.C2G_BUILDINGPLAYER_HARVESTALL; }
        public C2G_BuildingPlayer_HarvestAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 封地建筑一键收获")]
    public partial class G2C_BuildingPlayer_HarvestAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("封地建筑列表")]
        public Dictionary<int, CLS_BuildingPlayerInfo> DictBuilding = new Dictionary<int, CLS_BuildingPlayerInfo>();
        public G2C_BuildingPlayer_HarvestAll() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_HARVESTALL; }
        public G2C_BuildingPlayer_HarvestAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 封地建筑建造/升级")]
    public partial class C2G_BuildingPlayer_Build : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_BuildingPlayer_Build() { ProtocolId = EProtocolId.C2G_BUILDINGPLAYER_BUILD; }
        public C2G_BuildingPlayer_Build(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 封地建筑建造/升级")]
    public partial class G2C_BuildingPlayer_Build : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        public G2C_BuildingPlayer_Build() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_BUILD; }
        public G2C_BuildingPlayer_Build(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知建筑完成")]
    public partial class G2C_BuildingPlayer_NotifyBuilt : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        public G2C_BuildingPlayer_NotifyBuilt() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_NOTIFYBUILT; }
        public G2C_BuildingPlayer_NotifyBuilt(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("匠工坊单条信息 用来推送")]
    public partial class CLS_SmithSimple
    {
        [Desc("ID")]
        public int Id = 0;
        [Desc("需求道具列表")]
        public List<CLS_ItemNeedInfo> ListItemNeedInfo = new List<CLS_ItemNeedInfo>();
        [Desc("是否解锁")]
        public bool Lock = false;
        [Desc("已有数量")]
        public int num = 0;
    };
    [Desc("请求 匠工坊列表")]
    public partial class C2G_Smith_Start : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Smith_Start() { ProtocolId = EProtocolId.C2G_SMITH_START; }
        public C2G_Smith_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 匠工坊列表")]
    public partial class G2C_Smith_Start : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID列表  匠工房制作消耗")]
        public Dictionary<int, CLS_SmithSimple> DicSmithInfo = new Dictionary<int, CLS_SmithSimple>();
        public G2C_Smith_Start() { ProtocolId = EProtocolId.G2C_SMITH_START; }
        public G2C_Smith_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 匠工坊制作")]
    public partial class C2G_Smith_Do : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public int ID = 0;
        [Desc("制作数量")]
        public int Count = 0;
        public C2G_Smith_Do() { ProtocolId = EProtocolId.C2G_SMITH_DO; }
        public C2G_Smith_Do(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 匠工坊制作 产出")]
    public partial class G2C_Smith_Do : ProtocolMsgBase, INbsSerializer
    {
        [Desc("匠工房产出")]
        public List<CLS_AwardItem> Items = new List<CLS_AwardItem>();
        [Desc("装备信息")]
        public List<CLS_EquipInfo> EquipInfo = new List<CLS_EquipInfo>();
        public G2C_Smith_Do() { ProtocolId = EProtocolId.G2C_SMITH_DO; }
        public G2C_Smith_Do(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("兵法信息")]
    public partial class CLS_ScienceInfo
    {
        [Desc("兵法类型")]
        public int ScienceType = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("配置ID")]
        public int ConfigID = 0;
        [Desc("是否在建造中")]
        public bool IsInLearning = false;
        [Desc("剩余毫秒数")]
        public long LearnEndMs = 0;
        [Desc("立即完成需要金币")]
        public long CompleteNeed = 0;
    };
    [Desc("请求 兵法列表")]
    public partial class C2G_Science_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Science_List() { ProtocolId = EProtocolId.C2G_SCIENCE_LIST; }
        public C2G_Science_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵法列表")]
    public partial class G2C_Science_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兵法列表")]
        public Dictionary<int, CLS_ScienceInfo> DictScience = new Dictionary<int, CLS_ScienceInfo>();
        public G2C_Science_List() { ProtocolId = EProtocolId.G2C_SCIENCE_LIST; }
        public G2C_Science_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵法研究")]
    public partial class C2G_Science_Learn : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_Science_Learn() { ProtocolId = EProtocolId.C2G_SCIENCE_LEARN; }
        public C2G_Science_Learn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵法研究")]
    public partial class G2C_Science_Learn : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兵法信息")]
        public CLS_ScienceInfo Info = new CLS_ScienceInfo();
        public G2C_Science_Learn() { ProtocolId = EProtocolId.G2C_SCIENCE_LEARN; }
        public G2C_Science_Learn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵法信息")]
    public partial class C2G_Science_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_Science_Info() { ProtocolId = EProtocolId.C2G_SCIENCE_INFO; }
        public C2G_Science_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵法信息")]
    public partial class G2C_Science_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兵法信息")]
        public CLS_ScienceInfo Info = new CLS_ScienceInfo();
        public G2C_Science_Info() { ProtocolId = EProtocolId.G2C_SCIENCE_INFO; }
        public G2C_Science_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵法取消研究")]
    public partial class C2G_Science_Cancel : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_Science_Cancel() { ProtocolId = EProtocolId.C2G_SCIENCE_CANCEL; }
        public C2G_Science_Cancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵法取消研究")]
    public partial class G2C_Science_Cancel : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兵法信息")]
        public CLS_ScienceInfo Info = new CLS_ScienceInfo();
        public G2C_Science_Cancel() { ProtocolId = EProtocolId.G2C_SCIENCE_CANCEL; }
        public G2C_Science_Cancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知兵法完成")]
    public partial class G2C_Science_Notify : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新兵法信息")]
        public CLS_ScienceInfo ScienceInfo = new CLS_ScienceInfo();
        public G2C_Science_Notify() { ProtocolId = EProtocolId.G2C_SCIENCE_NOTIFY; }
        public G2C_Science_Notify(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("兵营募兵信息")]
    public partial class CLS_RecruitInfo
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("募兵状态 ERecruitStatus")]
        public byte ERecruitStatus = 0;
        [Desc("募兵开始时间")]
        public DateTime DtRecruitStart = DateTime.Now;
        [Desc("募兵结束时间")]
        public DateTime DtRecruitEnd = DateTime.Now;
    };
    [Desc("请求 兵营募兵信息")]
    public partial class C2G_Recruit_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_Recruit_Info() { ProtocolId = EProtocolId.C2G_RECRUIT_INFO; }
        public C2G_Recruit_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵营募兵信息")]
    public partial class G2C_Recruit_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfo = new CLS_RecruitInfo();
        public G2C_Recruit_Info() { ProtocolId = EProtocolId.G2C_RECRUIT_INFO; }
        public G2C_Recruit_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵营募兵")]
    public partial class C2G_Recruit_Start : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        public C2G_Recruit_Start() { ProtocolId = EProtocolId.C2G_RECRUIT_START; }
        public C2G_Recruit_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵营募兵")]
    public partial class G2C_Recruit_Start : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("数量")]
        public int Count = 0;
        [Desc("兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfo = new CLS_RecruitInfo();
        public G2C_Recruit_Start() { ProtocolId = EProtocolId.G2C_RECRUIT_START; }
        public G2C_Recruit_Start(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知募兵完成")]
    public partial class G2C_Recruit_NotifyComplete : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        public G2C_Recruit_NotifyComplete() { ProtocolId = EProtocolId.G2C_RECRUIT_NOTIFYCOMPLETE; }
        public G2C_Recruit_NotifyComplete(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 通用加速信息")]
    public partial class C2G_Player_SpeedupInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("类型ESpeedup")]
        public int Type = 0;
        public C2G_Player_SpeedupInfo() { ProtocolId = EProtocolId.C2G_PLAYER_SPEEDUPINFO; }
        public C2G_Player_SpeedupInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 通用加速信息")]
    public partial class G2C_Player_SpeedupInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("剩余毫秒数")]
        public long EndMs = 0;
        [Desc("立即完成需要金币")]
        public long CompleteNeed = 0;
        [Desc("道具列表(加速类)")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Player_SpeedupInfo() { ProtocolId = EProtocolId.G2C_PLAYER_SPEEDUPINFO; }
        public G2C_Player_SpeedupInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 封地建筑建造加速立即完成")]
    public partial class C2G_BuildingPlayer_SpeedupComplete : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_BuildingPlayer_SpeedupComplete() { ProtocolId = EProtocolId.C2G_BUILDINGPLAYER_SPEEDUPCOMPLETE; }
        public C2G_BuildingPlayer_SpeedupComplete(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 封地建筑建造加速立即完成")]
    public partial class G2C_BuildingPlayer_SpeedupComplete : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        public G2C_BuildingPlayer_SpeedupComplete() { ProtocolId = EProtocolId.G2C_BUILDINGPLAYER_SPEEDUPCOMPLETE; }
        public G2C_BuildingPlayer_SpeedupComplete(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵营募兵加速")]
    public partial class C2G_Recruit_Speedup : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("类型ESpeedup")]
        public int Type = 0;
        public C2G_Recruit_Speedup() { ProtocolId = EProtocolId.C2G_RECRUIT_SPEEDUP; }
        public C2G_Recruit_Speedup(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵营募兵加速")]
    public partial class G2C_Recruit_Speedup : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfo = new CLS_RecruitInfo();
        public G2C_Recruit_Speedup() { ProtocolId = EProtocolId.G2C_RECRUIT_SPEEDUP; }
        public G2C_Recruit_Speedup(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 兵法立即研究或加速信息")]
    public partial class C2G_Science_Fast : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        public C2G_Science_Fast() { ProtocolId = EProtocolId.C2G_SCIENCE_FAST; }
        public C2G_Science_Fast(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 兵法立即研究或加速信息")]
    public partial class G2C_Science_Fast : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兵法信息")]
        public CLS_ScienceInfo Info = new CLS_ScienceInfo();
        public G2C_Science_Fast() { ProtocolId = EProtocolId.G2C_SCIENCE_FAST; }
        public G2C_Science_Fast(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 加速道具购买")]
    public partial class C2G_Player_SpeedupBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID ShopSpeedUp表里的ID")]
        public int Id = 0;
        [Desc("数量")]
        public int Amount = 0;
        [Desc("类型ESpeedup")]
        public int Type = 0;
        public C2G_Player_SpeedupBuy() { ProtocolId = EProtocolId.C2G_PLAYER_SPEEDUPBUY; }
        public C2G_Player_SpeedupBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 加速道具购买")]
    public partial class G2C_Player_SpeedupBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具列表(加速类)")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        public G2C_Player_SpeedupBuy() { ProtocolId = EProtocolId.G2C_PLAYER_SPEEDUPBUY; }
        public G2C_Player_SpeedupBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 加速使用道具")]
    public partial class C2G_Player_Speedup : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(位置)")]
        public int Id = 0;
        [Desc("道具")]
        public List<CLS_ItemInfo> Items = new List<CLS_ItemInfo>();
        [Desc("类型ESpeedup")]
        public int Type = 0;
        public C2G_Player_Speedup() { ProtocolId = EProtocolId.C2G_PLAYER_SPEEDUP; }
        public C2G_Player_Speedup(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 加速使用道具")]
    public partial class G2C_Player_Speedup : ProtocolMsgBase, INbsSerializer
    {
        [Desc("类型ESpeedup")]
        public int Type = 0;
        [Desc("刷新建筑信息")]
        public CLS_BuildingPlayerInfo Building = new CLS_BuildingPlayerInfo();
        [Desc("兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfo = new CLS_RecruitInfo();
        [Desc("兵法信息")]
        public CLS_ScienceInfo ScienceInfo = new CLS_ScienceInfo();
        [Desc("道具列表(加速类)")]
        public List<CLS_ItemInfo> ListItem = new List<CLS_ItemInfo>();
        [Desc("剩余毫秒数")]
        public long EndMs = 0;
        [Desc("立即完成需要金币")]
        public long CompleteNeed = 0;
        public G2C_Player_Speedup() { ProtocolId = EProtocolId.G2C_PLAYER_SPEEDUP; }
        public G2C_Player_Speedup(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 小助手")]
    public partial class C2G_Help_Fast : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Help_Fast() { ProtocolId = EProtocolId.C2G_HELP_FAST; }
        public C2G_Help_Fast(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 小助手")]
    public partial class G2C_Help_Fast : ProtocolMsgBase, INbsSerializer
    {
        [Desc("建筑队列1信息")]
        public CLS_BuildingPlayerInfo Building1 = new CLS_BuildingPlayerInfo();
        [Desc("建筑队列2信息")]
        public CLS_BuildingPlayerInfo Building2 = new CLS_BuildingPlayerInfo();
        [Desc("兵法信息")]
        public CLS_ScienceInfo ScienceInfo = new CLS_ScienceInfo();
        [Desc("步兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfoBu = new CLS_RecruitInfo();
        [Desc("骑兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfoQi = new CLS_RecruitInfo();
        [Desc("弓兵营募兵信息")]
        public CLS_RecruitInfo RecruitInfoGong = new CLS_RecruitInfo();
        public G2C_Help_Fast() { ProtocolId = EProtocolId.G2C_HELP_FAST; }
        public G2C_Help_Fast(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池信息")]
    public partial class CLS_CityInfoBase
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("太守Id")]
        public long LeaderPuid = 0;
        [Desc("太守名字")]
        public string LeaderName = "";
        [Desc("繁荣度")]
        public long Prosperity = 0;
    };
    [Desc("势力城池信息")]
    public partial class CLS_CityInfo4Guild
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("太守Id")]
        public long LeaderPuid = 0;
        [Desc("太守名字")]
        public string LeaderName = "";
        [Desc("繁荣度")]
        public long Prosperity = 0;
        [Desc("本周收入(府库库存)")]
        public int Revenue = 0;
    };
    [Desc("请求 城池信息")]
    public partial class C2G_City_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int Uid = 0;
        public C2G_City_CityInfo() { ProtocolId = EProtocolId.C2G_CITY_CITYINFO; }
        public C2G_City_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池信息")]
    public partial class G2C_City_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池信息")]
        public CLS_CityInfoBase CityInfo = new CLS_CityInfoBase();
        public G2C_City_CityInfo() { ProtocolId = EProtocolId.G2C_CITY_CITYINFO; }
        public G2C_City_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池列表")]
    public partial class C2G_City_ListCity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_City_ListCity() { ProtocolId = EProtocolId.C2G_CITY_LISTCITY; }
        public C2G_City_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池列表")]
    public partial class G2C_City_ListCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("都城ID")]
        public int CapitalCity = 0;
        [Desc("城池列表")]
        public Dictionary<int, CLS_CityInfoBase> DictCity = new Dictionary<int, CLS_CityInfoBase>();
        public G2C_City_ListCity() { ProtocolId = EProtocolId.G2C_CITY_LISTCITY; }
        public G2C_City_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 府库")]
    public partial class C2G_City_DepotInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        public C2G_City_DepotInfo() { ProtocolId = EProtocolId.C2G_CITY_DEPOTINFO; }
        public C2G_City_DepotInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 府库")]
    public partial class G2C_City_DepotInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("繁荣度")]
        public long Prosperity = 0;
        [Desc("本日预期收益")]
        public int RevenueDay = 0;
        [Desc("本期预期收益")]
        public int RevenueAll = 0;
        public G2C_City_DepotInfo() { ProtocolId = EProtocolId.G2C_CITY_DEPOTINFO; }
        public G2C_City_DepotInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("建筑道具需求")]
    public partial class CLS_BuildingItemNeedInfo
    {
        [Desc("道具Id")]
        public int ItemId = 0;
        [Desc("已建")]
        public int Built = 0;
        [Desc("需求")]
        public int Need = 0;
        [Desc("自己拥有")]
        public int Value = 0;
    };
    [Desc("城池建筑信息")]
    public partial class CLS_CityBuildingInfo
    {
        [Desc("(位置)")]
        public int Pos = 0;
        [Desc("建筑类型")]
        public int BuildingType = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("建筑道具需求")]
        public Dictionary<int, CLS_BuildingItemNeedInfo> DictNeedInfo = new Dictionary<int, CLS_BuildingItemNeedInfo>();
    };
    [Desc("请求 建筑列表")]
    public partial class C2G_CityBuilding_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int Uid = 0;
        public C2G_CityBuilding_List() { ProtocolId = EProtocolId.C2G_CITYBUILDING_LIST; }
        public C2G_CityBuilding_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 建筑列表")]
    public partial class G2C_CityBuilding_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府城建筑列表")]
        public Dictionary<int, CLS_CityBuildingInfo> DictBuilding = new Dictionary<int, CLS_CityBuildingInfo>();
        public G2C_CityBuilding_List() { ProtocolId = EProtocolId.G2C_CITYBUILDING_LIST; }
        public G2C_CityBuilding_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 建筑升级")]
    public partial class C2G_CityBuilding_Build : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int Uid = 0;
        [Desc("(位置)")]
        public int Pos = 0;
        [Desc("建筑使用(道具ID 数量)")]
        public Dictionary<int, int> DictBuildUse = new Dictionary<int, int>();
        public C2G_CityBuilding_Build() { ProtocolId = EProtocolId.C2G_CITYBUILDING_BUILD; }
        public C2G_CityBuilding_Build(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 建筑升级")]
    public partial class G2C_CityBuilding_Build : ProtocolMsgBase, INbsSerializer
    {
        [Desc("建筑信息")]
        public CLS_CityBuildingInfo BuildingInfo = new CLS_CityBuildingInfo();
        public G2C_CityBuilding_Build() { ProtocolId = EProtocolId.G2C_CITYBUILDING_BUILD; }
        public G2C_CityBuilding_Build(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("守备营城墙信息")]
    public partial class CLS_CampWallInfo
    {
        [Desc("唯一ID(1-5)(1=主营)")]
        public int Uid = 0;
        [Desc("城墙耐久")]
        public CLS_CountInfo WallHp = new CLS_CountInfo();
        [Desc("可修复CD")]
        public TimeSpan TsCooldownRepair = new TimeSpan();
        [Desc("滚木")]
        public int Bowls = 0;
        [Desc("拒马")]
        public int Frise = 0;
        [Desc("陷阱")]
        public int Trap = 0;
        [Desc("建筑道具需求")]
        public Dictionary<int, CLS_ItemNeedInfo> DictNeedInfo = new Dictionary<int, CLS_ItemNeedInfo>();
    };
    [Desc("城墙信息")]
    public partial class CLS_WallInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("守备营城墙信息")]
        public Dictionary<int, CLS_CampWallInfo> DictCampWall = new Dictionary<int, CLS_CampWallInfo>();
    };
    [Desc("请求 城墙信息")]
    public partial class C2G_Wall_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        public C2G_Wall_Info() { ProtocolId = EProtocolId.C2G_WALL_INFO; }
        public C2G_Wall_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城墙信息")]
    public partial class G2C_Wall_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("城墙信息")]
        public CLS_WallInfo WallInfo = new CLS_WallInfo();
        public G2C_Wall_Info() { ProtocolId = EProtocolId.G2C_WALL_INFO; }
        public G2C_Wall_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城墙修复")]
    public partial class C2G_Wall_Repair : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        public C2G_Wall_Repair() { ProtocolId = EProtocolId.C2G_WALL_REPAIR; }
        public C2G_Wall_Repair(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城墙修复")]
    public partial class G2C_Wall_Repair : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙信息")]
        public CLS_WallInfo WallInfo = new CLS_WallInfo();
        public G2C_Wall_Repair() { ProtocolId = EProtocolId.G2C_WALL_REPAIR; }
        public G2C_Wall_Repair(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城墙建造器械")]
    public partial class C2G_Wall_MakeWork : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙器械类型 EWallWorkType")]
        public int WallWorkType = 0;
        [Desc("建造数目")]
        public int MakeCount = 0;
        public C2G_Wall_MakeWork() { ProtocolId = EProtocolId.C2G_WALL_MAKEWORK; }
        public C2G_Wall_MakeWork(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城墙建造器械")]
    public partial class G2C_Wall_MakeWork : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙器械类型 EWallWorkType")]
        public int WallWorkType = 0;
        [Desc("建造数目")]
        public int MakeCount = 0;
        [Desc("城墙信息")]
        public CLS_WallInfo WallInfo = new CLS_WallInfo();
        public G2C_Wall_MakeWork() { ProtocolId = EProtocolId.G2C_WALL_MAKEWORK; }
        public G2C_Wall_MakeWork(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("守军NPC信息")]
    public partial class CLS_CampNpcInfo
    {
        [Desc("唯一ID(1-n)")]
        public int Uid = 0;
        [Desc("关卡配置ID")]
        public int StageId = 0;
        [Desc("存活")]
        public bool IsAlive = false;
        [Desc("剩余复活时间")]
        public TimeSpan TsRevive = new TimeSpan();
    };
    [Desc("守备营信息")]
    public partial class CLS_CampInfo
    {
        [Desc("唯一ID(1-5)(1=主营)")]
        public int Uid = 0;
        [Desc("守军NPC")]
        public Dictionary<int, CLS_CampNpcInfo> DictCampNpc = new Dictionary<int, CLS_CampNpcInfo>();
    };
    [Desc("请求 守备营信息")]
    public partial class C2G_Camp_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        public C2G_Camp_Info() { ProtocolId = EProtocolId.C2G_CAMP_INFO; }
        public C2G_Camp_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 守备营信息")]
    public partial class G2C_Camp_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("守备营信息")]
        public Dictionary<int, CLS_CampInfo> DictCamp = new Dictionary<int, CLS_CampInfo>();
        public G2C_Camp_Info() { ProtocolId = EProtocolId.G2C_CAMP_INFO; }
        public G2C_Camp_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池珍宝阁信息")]
    public partial class C2G_City_ShopInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        public C2G_City_ShopInfo() { ProtocolId = EProtocolId.C2G_CITY_SHOPINFO; }
        public C2G_City_ShopInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池珍宝阁信息")]
    public partial class G2C_City_ShopInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("商品信息")]
        public List<CLS_ShopGoodsInfo> GoodsInfo = new List<CLS_ShopGoodsInfo>();
        [Desc("特产商品信息")]
        public Dictionary<int, int> SpecialtyGoodsInfo = new Dictionary<int, int>();
        [Desc("拥有的贡献")]
        public int Contribution = 0;
        public G2C_City_ShopInfo() { ProtocolId = EProtocolId.G2C_CITY_SHOPINFO; }
        public G2C_City_ShopInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理城池珍宝阁购买")]
    public partial class C2G_City_ShopBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("配置ID")]
        public int Config = 0;
        [Desc("数量")]
        public int Amount = 0;
        public C2G_City_ShopBuy() { ProtocolId = EProtocolId.C2G_CITY_SHOPBUY; }
        public C2G_City_ShopBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理城池珍宝阁购买")]
    public partial class G2C_City_ShopBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商品信息")]
        public List<CLS_ShopGoodsInfo> GoodsInfo = new List<CLS_ShopGoodsInfo>();
        [Desc("拥有的贡献")]
        public int Contribution = 0;
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("特产商品信息")]
        public Dictionary<int, int> SpecialtyGoodsInfo = new Dictionary<int, int>();
        public G2C_City_ShopBuy() { ProtocolId = EProtocolId.G2C_CITY_SHOPBUY; }
        public G2C_City_ShopBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("商城页面信息")]
    public partial class CLS_ShopPageInfo
    {
        [Desc("ID")]
        public int Id = 0;
        [Desc("商品列表")]
        public Dictionary<int, CLS_ShopGoodsInfo> DictGoods = new Dictionary<int, CLS_ShopGoodsInfo>();
        [Desc("剩余刷新时间 -1=无限制")]
        public int Cooldown = 0;
    };
    [Desc("商城货物信息")]
    public partial class CLS_ShopGoodsInfo
    {
        [Desc("ID")]
        public int Id = 0;
        [Desc("已有数量")]
        public int Count = 0;
        [Desc("可买数量 -1=无限制")]
        public int AmoutCanBuy = 0;
    };
    [Desc("请求 商城列表")]
    public partial class C2G_Shop_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Shop_List() { ProtocolId = EProtocolId.C2G_SHOP_LIST; }
        public C2G_Shop_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商城列表")]
    public partial class G2C_Shop_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商城页面")]
        public Dictionary<int, CLS_ShopPageInfo> DictPage = new Dictionary<int, CLS_ShopPageInfo>();
        [Desc("钻石商城累计刷新次数")]
        public int RefreshTotal = 0;
        [Desc("钻石商城当前刷新消耗")]
        public int RefreshCost = 0;
        public G2C_Shop_List() { ProtocolId = EProtocolId.G2C_SHOP_LIST; }
        public G2C_Shop_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商城购买")]
    public partial class C2G_Shop_Buy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID")]
        public int Id = 0;
        [Desc("购买数量")]
        public int Amount = 0;
        public C2G_Shop_Buy() { ProtocolId = EProtocolId.C2G_SHOP_BUY; }
        public C2G_Shop_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商城购买")]
    public partial class G2C_Shop_Buy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商城页面")]
        public Dictionary<int, CLS_ShopPageInfo> DictPage = new Dictionary<int, CLS_ShopPageInfo>();
        public G2C_Shop_Buy() { ProtocolId = EProtocolId.G2C_SHOP_BUY; }
        public G2C_Shop_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商城快捷购买")]
    public partial class C2G_Shop_QuickBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID")]
        public int Id = 0;
        [Desc("购买数量")]
        public int Amount = 0;
        public C2G_Shop_QuickBuy() { ProtocolId = EProtocolId.C2G_SHOP_QUICKBUY; }
        public C2G_Shop_QuickBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商城快捷购买")]
    public partial class G2C_Shop_QuickBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID")]
        public int Id = 0;
        public G2C_Shop_QuickBuy() { ProtocolId = EProtocolId.G2C_SHOP_QUICKBUY; }
        public G2C_Shop_QuickBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 刷新钻石商城")]
    public partial class C2G_Refresh_Diamond_Store : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Refresh_Diamond_Store() { ProtocolId = EProtocolId.C2G_REFRESH_DIAMOND_STORE; }
        public C2G_Refresh_Diamond_Store(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 刷新钻石商城")]
    public partial class G2C_Refresh_Diamond_Store : ProtocolMsgBase, INbsSerializer
    {
        [Desc("累计刷新次数")]
        public int RefreshTotal = 0;
        [Desc("当前刷新消耗")]
        public int RefreshCost = 0;
        [Desc("商城页面")]
        public Dictionary<int, CLS_ShopPageInfo> DictPage = new Dictionary<int, CLS_ShopPageInfo>();
        public G2C_Refresh_Diamond_Store() { ProtocolId = EProtocolId.G2C_REFRESH_DIAMOND_STORE; }
        public G2C_Refresh_Diamond_Store(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商城购买武将背包上限")]
    public partial class C2G_Shop_BuyWarriorBag : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID")]
        public int Id = 0;
        public C2G_Shop_BuyWarriorBag() { ProtocolId = EProtocolId.C2G_SHOP_BUYWARRIORBAG; }
        public C2G_Shop_BuyWarriorBag(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商城购买武将背包上限")]
    public partial class G2C_Shop_BuyWarriorBag : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID")]
        public int Id = 0;
        public G2C_Shop_BuyWarriorBag() { ProtocolId = EProtocolId.G2C_SHOP_BUYWARRIORBAG; }
        public G2C_Shop_BuyWarriorBag(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 金币兑换")]
    public partial class C2G_Buy_Gold : ProtocolMsgBase, INbsSerializer
    {
        public int times = 0;
        public C2G_Buy_Gold() { ProtocolId = EProtocolId.C2G_BUY_GOLD; }
        public C2G_Buy_Gold(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回")]
    public partial class G2C_Buy_Gold : ProtocolMsgBase, INbsSerializer
    {
        [Desc("增加的金币")]
        public int addGold = 0;
        [Desc("消耗的元宝")]
        public int useGem = 0;
        public G2C_Buy_Gold() { ProtocolId = EProtocolId.G2C_BUY_GOLD; }
        public G2C_Buy_Gold(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("单子信息")]
    public partial class CLS_DesignInfo
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("挂单玩家唯一ID")]
        public long Puid = 0;
        [Desc("挂单玩家名字")]
        public string Name = "";
        [Desc("单手价格(每手100)")]
        public long Price = 0;
        [Desc("挂单数量")]
        public long Count = 0;
        [Desc("到期时间")]
        public DateTime DtExpire = DateTime.Now;
        [Desc("剩余时间")]
        public TimeSpan TsRemainder = new TimeSpan();
    };
    [Desc("上次交易信息")]
    public partial class CLS_TransactionInfo
    {
        [Desc("成交单价(每手100)")]
        public long Price = 0;
        [Desc("交易时间")]
        public DateTime DtTransaction = DateTime.Now;
    };
    [Desc("请求 挂单列表")]
    public partial class C2G_Exchange_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易类型 对应EDesignFlag")]
        public int DesignFlag = 0;
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("页码1-n")]
        public int PageIndex = 0;
        public C2G_Exchange_List() { ProtocolId = EProtocolId.C2G_EXCHANGE_LIST; }
        public C2G_Exchange_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 挂单列表")]
    public partial class G2C_Exchange_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易类型 对应EDesignFlag")]
        public int DesignFlag = 0;
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("页码1-n")]
        public int PageIndex = 0;
        [Desc("单子总数目")]
        public int DesignCount = 0;
        [Desc("挂单列表")]
        public List<CLS_DesignInfo> ListDesign = new List<CLS_DesignInfo>();
        [Desc("上次交易信息(Price=0时未发生交易)")]
        public CLS_TransactionInfo TransactionInfo = new CLS_TransactionInfo();
        public G2C_Exchange_List() { ProtocolId = EProtocolId.G2C_EXCHANGE_LIST; }
        public G2C_Exchange_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 挂单买卖")]
    public partial class C2G_Exchange_Shelves : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("单手价格(每手100)")]
        public long Price = 0;
        [Desc("挂单数量")]
        public long Count = 0;
        public C2G_Exchange_Shelves() { ProtocolId = EProtocolId.C2G_EXCHANGE_SHELVES; }
        public C2G_Exchange_Shelves(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 挂单买卖")]
    public partial class G2C_Exchange_Shelves : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("更新单子信息")]
        public CLS_DesignInfo DesignInfo = new CLS_DesignInfo();
        public G2C_Exchange_Shelves() { ProtocolId = EProtocolId.G2C_EXCHANGE_SHELVES; }
        public G2C_Exchange_Shelves(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 挂单撤销")]
    public partial class C2G_Exchange_Revoke : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Exchange_Revoke() { ProtocolId = EProtocolId.C2G_EXCHANGE_REVOKE; }
        public C2G_Exchange_Revoke(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 挂单撤销")]
    public partial class G2C_Exchange_Revoke : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Exchange_Revoke() { ProtocolId = EProtocolId.G2C_EXCHANGE_REVOKE; }
        public G2C_Exchange_Revoke(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 交易买卖")]
    public partial class C2G_Exchange_Transaction : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("单号 唯一ID")]
        public long Id = 0;
        [Desc("交易数量")]
        public long Count = 0;
        public C2G_Exchange_Transaction() { ProtocolId = EProtocolId.C2G_EXCHANGE_TRANSACTION; }
        public C2G_Exchange_Transaction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 交易买卖")]
    public partial class G2C_Exchange_Transaction : ProtocolMsgBase, INbsSerializer
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("更新单子信息")]
        public CLS_DesignInfo DesignInfo = new CLS_DesignInfo();
        public G2C_Exchange_Transaction() { ProtocolId = EProtocolId.G2C_EXCHANGE_TRANSACTION; }
        public G2C_Exchange_Transaction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc(" 交易信息")]
    public partial class CLS_TransactionLog
    {
        [Desc("交易方式 对应EDesignMode")]
        public int DesignMode = 0;
        [Desc("货币类型")]
        public int MoneyType = 0;
        [Desc("交易单价")]
        public long Price = 0;
        [Desc("交易数量")]
        public long Count = 0;
    };
    [Desc("请求 交易记录")]
    public partial class C2G_GetTransactionLogList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("查询类型（1:购买记录;2:出售记录）")]
        public int Type = 0;
        public C2G_GetTransactionLogList() { ProtocolId = EProtocolId.C2G_GETTRANSACTIONLOGLIST; }
        public C2G_GetTransactionLogList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 交易记录")]
    public partial class G2C_GetTransactionLogList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("查询类型（1:购买记录;2:出售记录）")]
        public int Type = 0;
        [Desc("交易记录")]
        public List<CLS_TransactionLog> ListTransactionLog = new List<CLS_TransactionLog>();
        public G2C_GetTransactionLogList() { ProtocolId = EProtocolId.G2C_GETTRANSACTIONLOGLIST; }
        public G2C_GetTransactionLogList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("商会单子信息 基础")]
    public partial class CLS_AuctionInfoBase
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        [Desc("挂单玩家唯一ID")]
        public long Puid = 0;
        [Desc("挂单玩家名字")]
        public string Name = "";
        [Desc("价格(单位：分)")]
        public long Price = 0;
        [Desc("到期时间")]
        public DateTime DtExpire = DateTime.Now;
        [Desc("剩余时间")]
        public TimeSpan TsRemainder = new TimeSpan();
    };
    [Desc("商会单子信息 道具")]
    public partial class CLS_AuctionInfoItem
    {
        [Desc("基础信息")]
        public CLS_AuctionInfoBase AuctionInfoBase = new CLS_AuctionInfoBase();
        [Desc("道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
    };
    [Desc("请求 商会列表 道具")]
    public partial class C2G_Auction_ListItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        public C2G_Auction_ListItem() { ProtocolId = EProtocolId.C2G_AUCTION_LISTITEM; }
        public C2G_Auction_ListItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会列表 道具")]
    public partial class G2C_Auction_ListItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        [Desc("总数目")]
        public int TotalCount = 0;
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoItem> DictItem = new Dictionary<long, CLS_AuctionInfoItem>();
        public G2C_Auction_ListItem() { ProtocolId = EProtocolId.G2C_AUCTION_LISTITEM; }
        public G2C_Auction_ListItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会出售 道具")]
    public partial class C2G_Auction_SellItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
        [Desc("出售单价(单位：分)")]
        public long Price = 0;
        public C2G_Auction_SellItem() { ProtocolId = EProtocolId.C2G_AUCTION_SELLITEM; }
        public C2G_Auction_SellItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会出售 道具")]
    public partial class G2C_Auction_SellItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商会单子信息")]
        public CLS_AuctionInfoItem AuctionInfoItem = new CLS_AuctionInfoItem();
        [Desc("刷新道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
        public G2C_Auction_SellItem() { ProtocolId = EProtocolId.G2C_AUCTION_SELLITEM; }
        public G2C_Auction_SellItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会撤卖 道具")]
    public partial class C2G_Auction_ReturnItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_ReturnItem() { ProtocolId = EProtocolId.C2G_AUCTION_RETURNITEM; }
        public C2G_Auction_ReturnItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会撤卖 道具")]
    public partial class G2C_Auction_ReturnItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
        public G2C_Auction_ReturnItem() { ProtocolId = EProtocolId.G2C_AUCTION_RETURNITEM; }
        public G2C_Auction_ReturnItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会买入 道具")]
    public partial class C2G_Auction_BuyItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_BuyItem() { ProtocolId = EProtocolId.C2G_AUCTION_BUYITEM; }
        public C2G_Auction_BuyItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会买入 道具")]
    public partial class G2C_Auction_BuyItem : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新道具信息")]
        public CLS_ItemInfo ItemInfo = new CLS_ItemInfo();
        public G2C_Auction_BuyItem() { ProtocolId = EProtocolId.G2C_AUCTION_BUYITEM; }
        public G2C_Auction_BuyItem(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("商会单子信息 装备")]
    public partial class CLS_AuctionInfoEquip
    {
        [Desc("基础信息")]
        public CLS_AuctionInfoBase AuctionInfoBase = new CLS_AuctionInfoBase();
        [Desc("装备信息")]
        public CLS_EquipInfo EquipInfo = new CLS_EquipInfo();
    };
    [Desc("请求 商会列表 装备")]
    public partial class C2G_Auction_ListEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        public C2G_Auction_ListEquip() { ProtocolId = EProtocolId.C2G_AUCTION_LISTEQUIP; }
        public C2G_Auction_ListEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会列表 装备")]
    public partial class G2C_Auction_ListEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        [Desc("总数目")]
        public int TotalCount = 0;
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoEquip> DictEquip = new Dictionary<long, CLS_AuctionInfoEquip>();
        public G2C_Auction_ListEquip() { ProtocolId = EProtocolId.G2C_AUCTION_LISTEQUIP; }
        public G2C_Auction_ListEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会出售 装备")]
    public partial class C2G_Auction_SellEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("装备唯一ID")]
        public long EquipId = 0;
        [Desc("出售单价(单位：分)")]
        public long Price = 0;
        public C2G_Auction_SellEquip() { ProtocolId = EProtocolId.C2G_AUCTION_SELLEQUIP; }
        public C2G_Auction_SellEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会出售 装备")]
    public partial class G2C_Auction_SellEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商会单子信息")]
        public CLS_AuctionInfoEquip AuctionInfoEquip = new CLS_AuctionInfoEquip();
        public G2C_Auction_SellEquip() { ProtocolId = EProtocolId.G2C_AUCTION_SELLEQUIP; }
        public G2C_Auction_SellEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会撤卖 装备")]
    public partial class C2G_Auction_ReturnEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_ReturnEquip() { ProtocolId = EProtocolId.C2G_AUCTION_RETURNEQUIP; }
        public C2G_Auction_ReturnEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会撤卖 装备")]
    public partial class G2C_Auction_ReturnEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新装备信息")]
        public CLS_EquipInfo EquipInfo = new CLS_EquipInfo();
        public G2C_Auction_ReturnEquip() { ProtocolId = EProtocolId.G2C_AUCTION_RETURNEQUIP; }
        public G2C_Auction_ReturnEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会买入 装备")]
    public partial class C2G_Auction_BuyEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_BuyEquip() { ProtocolId = EProtocolId.C2G_AUCTION_BUYEQUIP; }
        public C2G_Auction_BuyEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会买入 装备")]
    public partial class G2C_Auction_BuyEquip : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新装备信息")]
        public CLS_EquipInfo EquipInfo = new CLS_EquipInfo();
        public G2C_Auction_BuyEquip() { ProtocolId = EProtocolId.G2C_AUCTION_BUYEQUIP; }
        public G2C_Auction_BuyEquip(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("商会单子信息 武将")]
    public partial class CLS_AuctionInfoWarrior
    {
        [Desc("基础信息")]
        public CLS_AuctionInfoBase AuctionInfoBase = new CLS_AuctionInfoBase();
        [Desc("武将信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
    };
    [Desc("请求 商会列表 武将")]
    public partial class C2G_Auction_ListWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        public C2G_Auction_ListWarrior() { ProtocolId = EProtocolId.C2G_AUCTION_LISTWARRIOR; }
        public C2G_Auction_ListWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会列表 武将")]
    public partial class G2C_Auction_ListWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排序类型 对应EOrder")]
        public int Order = 0;
        [Desc("交易类型 对应EAuctionFlag")]
        public int AuctionFlag = 0;
        [Desc("子类ID")]
        public int SubType = 0;
        [Desc("页码1-n (返回每页100条)")]
        public int PageIndex = 0;
        [Desc("总数目")]
        public int TotalCount = 0;
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoWarrior> DictWarrior = new Dictionary<long, CLS_AuctionInfoWarrior>();
        public G2C_Auction_ListWarrior() { ProtocolId = EProtocolId.G2C_AUCTION_LISTWARRIOR; }
        public G2C_Auction_ListWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会出售 武将")]
    public partial class C2G_Auction_SellWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long WarriorId = 0;
        [Desc("出售单价(单位：分)")]
        public long Price = 0;
        public C2G_Auction_SellWarrior() { ProtocolId = EProtocolId.C2G_AUCTION_SELLWARRIOR; }
        public C2G_Auction_SellWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会出售 武将")]
    public partial class G2C_Auction_SellWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商会单子信息")]
        public CLS_AuctionInfoWarrior AuctionInfoWarrior = new CLS_AuctionInfoWarrior();
        public G2C_Auction_SellWarrior() { ProtocolId = EProtocolId.G2C_AUCTION_SELLWARRIOR; }
        public G2C_Auction_SellWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会撤卖 武将")]
    public partial class C2G_Auction_ReturnWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_ReturnWarrior() { ProtocolId = EProtocolId.C2G_AUCTION_RETURNWARRIOR; }
        public C2G_Auction_ReturnWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会撤卖 武将")]
    public partial class G2C_Auction_ReturnWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新武将信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Auction_ReturnWarrior() { ProtocolId = EProtocolId.G2C_AUCTION_RETURNWARRIOR; }
        public G2C_Auction_ReturnWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会买入 武将")]
    public partial class C2G_Auction_BuyWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("单号 唯一ID")]
        public long Id = 0;
        public C2G_Auction_BuyWarrior() { ProtocolId = EProtocolId.C2G_AUCTION_BUYWARRIOR; }
        public C2G_Auction_BuyWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会买入 武将")]
    public partial class G2C_Auction_BuyWarrior : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新武将信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        public G2C_Auction_BuyWarrior() { ProtocolId = EProtocolId.G2C_AUCTION_BUYWARRIOR; }
        public G2C_Auction_BuyWarrior(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 商会搜索")]
    public partial class C2G_Auction_Search : ProtocolMsgBase, INbsSerializer
    {
        [Desc("搜索关键字")]
        public string SearchKey = "";
        public C2G_Auction_Search() { ProtocolId = EProtocolId.C2G_AUCTION_SEARCH; }
        public C2G_Auction_Search(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会搜索")]
    public partial class G2C_Auction_Search : ProtocolMsgBase, INbsSerializer
    {
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoItem> DictItem = new Dictionary<long, CLS_AuctionInfoItem>();
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoEquip> DictEquip = new Dictionary<long, CLS_AuctionInfoEquip>();
        [Desc("列表")]
        public Dictionary<long, CLS_AuctionInfoWarrior> DictWarrior = new Dictionary<long, CLS_AuctionInfoWarrior>();
        public G2C_Auction_Search() { ProtocolId = EProtocolId.G2C_AUCTION_SEARCH; }
        public G2C_Auction_Search(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("商会交易记录")]
    public partial class CLS_AuctionLog
    {
        [Desc("大类 见EAuctionLogItemType")]
        public short AuctionLogItemType = 0;
        [Desc("配置ID")]
        public int ConfigId = 0;
        [Desc("数量")]
        public int Count = 0;
        [Desc("交易对象名字")]
        public string PlayerName = "";
        [Desc("价格(单位：分)")]
        public long Price = 0;
    };
    [Desc("请求 商会交易记录")]
    public partial class C2G_Auction_GetLog : ProtocolMsgBase, INbsSerializer
    {
        [Desc("查询类型 EAuctionLogType")]
        public int AuctionLogType = 0;
        public C2G_Auction_GetLog() { ProtocolId = EProtocolId.C2G_AUCTION_GETLOG; }
        public C2G_Auction_GetLog(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 商会交易记录")]
    public partial class G2C_Auction_GetLog : ProtocolMsgBase, INbsSerializer
    {
        [Desc("查询类型 EAuctionLogType")]
        public int AuctionLogType = 0;
        [Desc("交易记录")]
        public List<CLS_AuctionLog> ListAuctionLog = new List<CLS_AuctionLog>();
        public G2C_Auction_GetLog() { ProtocolId = EProtocolId.G2C_AUCTION_GETLOG; }
        public G2C_Auction_GetLog(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 宴会厅数据")]
    public partial class C2G_Draw_GetInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Draw_GetInfo() { ProtocolId = EProtocolId.C2G_DRAW_GETINFO; }
        public C2G_Draw_GetInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 宴会厅数据")]
    public partial class G2C_Draw_GetInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励积分")]
        public int DrawScore = 0;
        public G2C_Draw_GetInfo() { ProtocolId = EProtocolId.G2C_DRAW_GETINFO; }
        public G2C_Draw_GetInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 宴会厅抽奖")]
    public partial class C2G_Draw_Luck : ProtocolMsgBase, INbsSerializer
    {
        [Desc("(配置ID)")]
        public int DrawPoolId = 0;
        [Desc("(EDrawType)")]
        public int DrawType = 0;
        public C2G_Draw_Luck() { ProtocolId = EProtocolId.C2G_DRAW_LUCK; }
        public C2G_Draw_Luck(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 宴会厅抽奖")]
    public partial class G2C_Draw_Luck : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Draw_Luck() { ProtocolId = EProtocolId.G2C_DRAW_LUCK; }
        public G2C_Draw_Luck(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 宴会厅奖励")]
    public partial class C2G_Draw_GetAward : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Draw_GetAward() { ProtocolId = EProtocolId.C2G_DRAW_GETAWARD; }
        public C2G_Draw_GetAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 宴会厅奖励")]
    public partial class G2C_Draw_GetAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Draw_GetAward() { ProtocolId = EProtocolId.G2C_DRAW_GETAWARD; }
        public G2C_Draw_GetAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 使用兑换码")]
    public partial class C2G_Cdkey_Use : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兑换码")]
        public string Cdkey = "";
        public C2G_Cdkey_Use() { ProtocolId = EProtocolId.C2G_CDKEY_USE; }
        public C2G_Cdkey_Use(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 使用兑换码")]
    public partial class G2C_Cdkey_Use : ProtocolMsgBase, INbsSerializer
    {
        [Desc("兑换码")]
        public string Cdkey = "";
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Cdkey_Use() { ProtocolId = EProtocolId.G2C_CDKEY_USE; }
        public G2C_Cdkey_Use(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("排行榜单条信息")]
    public partial class CLS_TopData
    {
        [Desc("排行")]
        public int Rank = 0;
        [Desc("唯一ID")]
        public long Puid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("分数")]
        public long Score = 0;
        [Desc("存储其他信息，身份或武将名称或道具名称")]
        public string Other = "";
        [Desc("配置ID")]
        public int ConfigId = 0;
    };
    [Desc("请求 排行榜")]
    public partial class C2G_Top_Toplist : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排行榜类型")]
        public int type = 0;
        [Desc("页码")]
        public int PageIndex = 0;
        public C2G_Top_Toplist() { ProtocolId = EProtocolId.C2G_TOP_TOPLIST; }
        public C2G_Top_Toplist(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 排行榜")]
    public partial class G2C_Top_Toplist : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排行榜数据")]
        public List<CLS_TopData> TopDataList = new List<CLS_TopData>();
        [Desc("玩家数据")]
        public CLS_TopData playerTopData = new CLS_TopData();
        [Desc("排行榜类型")]
        public int type = 0;
        public G2C_Top_Toplist() { ProtocolId = EProtocolId.G2C_TOP_TOPLIST; }
        public G2C_Top_Toplist(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 排行榜单条具体数据信息")]
    public partial class C2G_Top_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排行榜类型")]
        public int type = 0;
        [Desc("唯一ID")]
        public long ID = 0;
        public C2G_Top_Info() { ProtocolId = EProtocolId.C2G_TOP_INFO; }
        public C2G_Top_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 排行榜单条具体数据信息")]
    public partial class G2C_Top_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排行榜类型")]
        public int type = 0;
        [Desc("装备信息")]
        public CLS_EquipInfo EquipInfo = new CLS_EquipInfo();
        [Desc("武将信息")]
        public CLS_WarriorInfo WarriorInfo = new CLS_WarriorInfo();
        [Desc("主角信息")]
        public CLS_PlayerData PlayerInfo = new CLS_PlayerData();
        public G2C_Top_Info() { ProtocolId = EProtocolId.G2C_TOP_INFO; }
        public G2C_Top_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("任务信息")]
    public partial class CLS_TaskInfo
    {
        [Desc("任务唯一ID(府衙任务用 其他任务和配置ID相同)")]
        public long Tuid = 0;
        [Desc("任务ID(配置ID)")]
        public int Id = 0;
        [Desc("任务状态 对应ETaskState")]
        public byte State = 0;
        [Desc("当前进度")]
        public long Schedule = 0;
        [Desc("最大进度")]
        public long ScheduleMax = 0;
    };
    [Desc("请求 任务列表")]
    public partial class C2G_Task_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务类型 对应ETaskType")]
        public byte TaskType = 0;
        public C2G_Task_List() { ProtocolId = EProtocolId.C2G_TASK_LIST; }
        public C2G_Task_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 任务列表")]
    public partial class G2C_Task_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务类型 对应ETaskType")]
        public byte TaskType = 0;
        [Desc("任务列表")]
        public List<CLS_TaskInfo> ListTask = new List<CLS_TaskInfo>();
        public G2C_Task_List() { ProtocolId = EProtocolId.G2C_TASK_LIST; }
        public G2C_Task_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 任务领奖")]
    public partial class C2G_Task_Get : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务类型 对应ETaskType")]
        public byte TaskType = 0;
        [Desc("任务唯一ID(府衙任务用 其他任务和配置ID相同)")]
        public long Tuid = 0;
        public C2G_Task_Get() { ProtocolId = EProtocolId.C2G_TASK_GET; }
        public C2G_Task_Get(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 任务领奖")]
    public partial class G2C_Task_Get : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Task_Get() { ProtocolId = EProtocolId.G2C_TASK_GET; }
        public G2C_Task_Get(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 任务领奖一键领取")]
    public partial class C2G_Task_GetAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务类型 对应ETaskType")]
        public byte TaskType = 0;
        public C2G_Task_GetAll() { ProtocolId = EProtocolId.C2G_TASK_GETALL; }
        public C2G_Task_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 任务领奖一键领取")]
    public partial class G2C_Task_GetAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Task_GetAll() { ProtocolId = EProtocolId.G2C_TASK_GETALL; }
        public G2C_Task_GetAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 日常任务")]
    public partial class C2G_Task_Everyday : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Task_Everyday() { ProtocolId = EProtocolId.C2G_TASK_EVERYDAY; }
        public C2G_Task_Everyday(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 日常任务")]
    public partial class G2C_Task_Everyday : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务列表")]
        public List<CLS_TaskInfo> ListTask = new List<CLS_TaskInfo>();
        [Desc("活跃值")]
        public int Activity = 0;
        [Desc("活跃奖励领取状态(等级ID，ETaskState)")]
        public Dictionary<int, int> DictTaskActivity = new Dictionary<int, int>();
        public G2C_Task_Everyday() { ProtocolId = EProtocolId.G2C_TASK_EVERYDAY; }
        public G2C_Task_Everyday(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 每日活跃奖励")]
    public partial class C2G_Task_EverydayAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("活跃ID")]
        public int ActivityID = 0;
        public C2G_Task_EverydayAward() { ProtocolId = EProtocolId.C2G_TASK_EVERYDAYAWARD; }
        public C2G_Task_EverydayAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 每日活跃奖励")]
    public partial class G2C_Task_EverydayAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Task_EverydayAward() { ProtocolId = EProtocolId.G2C_TASK_EVERYDAYAWARD; }
        public G2C_Task_EverydayAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("签到信息")]
    public partial class CLS_SignInfo
    {
        [Desc("今天是否已签")]
        public bool IsSigned = false;
        [Desc("本轮签到总数")]
        public int SignDays = 0;
        [Desc("本轮补签次数")]
        public int ReSignDays = 0;
        [Desc("本轮天数索引")]
        public int SignIndex = 0;
        [Desc("剩余秒数")]
        public long AliveTime = 0;
        [Desc("周期秒数")]
        public long TotalTime = 0;
    };
    [Desc("请求 获取签到信息")]
    public partial class C2G_Sign_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Sign_Info() { ProtocolId = EProtocolId.C2G_SIGN_INFO; }
        public C2G_Sign_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取签到信息")]
    public partial class G2C_Sign_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("签到信息")]
        public CLS_SignInfo SignInfo = new CLS_SignInfo();
        public G2C_Sign_Info() { ProtocolId = EProtocolId.G2C_SIGN_INFO; }
        public G2C_Sign_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理签到")]
    public partial class C2G_Sign : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Sign() { ProtocolId = EProtocolId.C2G_SIGN; }
        public C2G_Sign(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理签到")]
    public partial class G2C_Sign : ProtocolMsgBase, INbsSerializer
    {
        [Desc("签到信息")]
        public CLS_SignInfo SignInfo = new CLS_SignInfo();
        [Desc("奖励信息")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Sign() { ProtocolId = EProtocolId.G2C_SIGN; }
        public G2C_Sign(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理补签")]
    public partial class C2G_ReSign : ProtocolMsgBase, INbsSerializer
    {
        public C2G_ReSign() { ProtocolId = EProtocolId.C2G_RESIGN; }
        public C2G_ReSign(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理补签")]
    public partial class G2C_ReSign : ProtocolMsgBase, INbsSerializer
    {
        [Desc("签到信息")]
        public CLS_SignInfo SignInfo = new CLS_SignInfo();
        [Desc("奖励信息")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_ReSign() { ProtocolId = EProtocolId.G2C_RESIGN; }
        public G2C_ReSign(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("BUFF信息")]
    public partial class CLS_BuffInfo
    {
        [Desc("配置ID")]
        public int Id = 0;
        [Desc("剩余秒数(-1:永久有效)")]
        public long AliveTime = 0;
    };
    [Desc("请求 获取BUFF信息")]
    public partial class C2G_Buff_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Buff_Info() { ProtocolId = EProtocolId.C2G_BUFF_INFO; }
        public C2G_Buff_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取BUFF信息")]
    public partial class G2C_Buff_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("BUFF信息")]
        public List<CLS_BuffInfo> Info = new List<CLS_BuffInfo>();
        public G2C_Buff_Info() { ProtocolId = EProtocolId.G2C_BUFF_INFO; }
        public G2C_Buff_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池信息")]
    public partial class CLS_AcitvityInfo
    {
        [Desc("活动ID(配置ID)")]
        public int Id = 0;
        [Desc("是否开启")]
        public bool IsOpen = false;
        [Desc("开启时间")]
        public DateTime TimeOpen = DateTime.Now;
        [Desc("截止时间")]
        public DateTime TimeEnd = DateTime.Now;
    };
    [Desc("请求 获取活动列表")]
    public partial class C2G_Acitvity_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Acitvity_List() { ProtocolId = EProtocolId.C2G_ACITVITY_LIST; }
        public C2G_Acitvity_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取活动列表")]
    public partial class G2C_Acitvity_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("信息列表")]
        public Dictionary<int, CLS_AcitvityInfo> ListInfo = new Dictionary<int, CLS_AcitvityInfo>();
        public G2C_Acitvity_List() { ProtocolId = EProtocolId.G2C_ACITVITY_LIST; }
        public G2C_Acitvity_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 返利信息")]
    public partial class C2G_Acitvity_RebateInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Acitvity_RebateInfo() { ProtocolId = EProtocolId.C2G_ACITVITY_REBATEINFO; }
        public C2G_Acitvity_RebateInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 返利信息")]
    public partial class G2C_Acitvity_RebateInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("本周返利")]
        public long Rebate = 0;
        [Desc("历史返利")]
        public long RebateTotal = 0;
        public G2C_Acitvity_RebateInfo() { ProtocolId = EProtocolId.G2C_ACITVITY_REBATEINFO; }
        public G2C_Acitvity_RebateInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 获取七日试炼")]
    public partial class C2G_Acitvity_7Day : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Acitvity_7Day() { ProtocolId = EProtocolId.C2G_ACITVITY_7DAY; }
        public C2G_Acitvity_7Day(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取七日试炼")]
    public partial class G2C_Acitvity_7Day : ProtocolMsgBase, INbsSerializer
    {
        [Desc("任务列表")]
        public List<CLS_TaskInfo> ListTask = new List<CLS_TaskInfo>();
        public G2C_Acitvity_7Day() { ProtocolId = EProtocolId.G2C_ACITVITY_7DAY; }
        public G2C_Acitvity_7Day(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 七日试炼领奖")]
    public partial class C2G_Acitvity_7DayGet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("配置ID")]
        public int confID = 0;
        public C2G_Acitvity_7DayGet() { ProtocolId = EProtocolId.C2G_ACITVITY_7DAYGET; }
        public C2G_Acitvity_7DayGet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 七日试炼领奖")]
    public partial class G2C_Acitvity_7DayGet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Acitvity_7DayGet() { ProtocolId = EProtocolId.G2C_ACITVITY_7DAYGET; }
        public G2C_Acitvity_7DayGet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 获取七日登录信息")]
    public partial class C2G_Acitvity_7DayLoginInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Acitvity_7DayLoginInfo() { ProtocolId = EProtocolId.C2G_ACITVITY_7DAYLOGININFO; }
        public C2G_Acitvity_7DayLoginInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取七日登录信息")]
    public partial class G2C_Acitvity_7DayLoginInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("七日登录信息<k=日1-7 value=E7DayLoginState>")]
        public Dictionary<int, byte> DictData = new Dictionary<int, byte>();
        public G2C_Acitvity_7DayLoginInfo() { ProtocolId = EProtocolId.G2C_ACITVITY_7DAYLOGININFO; }
        public G2C_Acitvity_7DayLoginInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 七日登录领奖")]
    public partial class C2G_Acitvity_7DayLoginGet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("日1-7")]
        public int Day = 0;
        public C2G_Acitvity_7DayLoginGet() { ProtocolId = EProtocolId.C2G_ACITVITY_7DAYLOGINGET; }
        public C2G_Acitvity_7DayLoginGet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 七日登录领奖")]
    public partial class G2C_Acitvity_7DayLoginGet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励项")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Acitvity_7DayLoginGet() { ProtocolId = EProtocolId.G2C_ACITVITY_7DAYLOGINGET; }
        public G2C_Acitvity_7DayLoginGet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("福利信息")]
    public partial class CLS_WelfareTaskInfo
    {
        [Desc("任务ID(配置ID)")]
        public int Id = 0;
        [Desc("任务状态 对应EWelfareState")]
        public EWelfareState State = new EWelfareState();
        [Desc("当前进度")]
        public long Schedule = 0;
        [Desc("最大进度")]
        public long ScheduleMax = 0;
    };
    [Desc("福利大类信息")]
    public partial class CLS_WelfareInfo
    {
        [Desc("活动大类ID")]
        public int Id = 0;
        [Desc("是否开启")]
        public bool IsOpen = false;
        [Desc("开启时间")]
        public DateTime TimeOpen = DateTime.Now;
        [Desc("截止时间")]
        public DateTime TimeEnd = DateTime.Now;
        [Desc("任务列表")]
        public Dictionary<int, CLS_WelfareTaskInfo> ListTask = new Dictionary<int, CLS_WelfareTaskInfo>();
    };
    [Desc("请求 获取福利信息")]
    public partial class C2G_Welfare_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Welfare_Info() { ProtocolId = EProtocolId.C2G_WELFARE_INFO; }
        public C2G_Welfare_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取福利信息")]
    public partial class G2C_Welfare_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("信息列表")]
        public Dictionary<int, CLS_WelfareInfo> ListInfo = new Dictionary<int, CLS_WelfareInfo>();
        public G2C_Welfare_Info() { ProtocolId = EProtocolId.G2C_WELFARE_INFO; }
        public G2C_Welfare_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 领取福利")]
    public partial class C2G_Welfare_Award : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        public C2G_Welfare_Award() { ProtocolId = EProtocolId.C2G_WELFARE_AWARD; }
        public C2G_Welfare_Award(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 领取福利")]
    public partial class G2C_Welfare_Award : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ID(配置ID)")]
        public int Id = 0;
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Welfare_Award() { ProtocolId = EProtocolId.G2C_WELFARE_AWARD; }
        public G2C_Welfare_Award(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力基本信息")]
    public partial class CLS_GuildInfoBase
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("领袖名字")]
        public string LeaderName = "";
        [Desc("所属州")]
        public int StateId = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("势力加入方式 EGuildJoinMode")]
        public byte JoinMode = 0;
        [Desc("人数")]
        public CLS_CountInfo CountMember = new CLS_CountInfo();
        [Desc("是否同盟关系")]
        public bool IsAlliance = false;
    };
    [Desc("势力详细信息")]
    public partial class CLS_GuildInfoDetails
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("领袖名字")]
        public string LeaderName = "";
        [Desc("所属州")]
        public int StateId = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验")]
        public int Exp = 0;
        [Desc("势力资金")]
        public int Fund = 0;
        [Desc("总收入")]
        public int Revenue = 0;
        [Desc("势力加入方式 EGuildJoinMode")]
        public byte JoinMode = 0;
        [Desc("人数")]
        public CLS_CountInfo CountMember = new CLS_CountInfo();
        [Desc("都城ID")]
        public int CapitalCity = 0;
        [Desc("城池数")]
        public int CountCity = 0;
        [Desc("宣言")]
        public string Manifesto = "";
        [Desc("公告")]
        public string Notice = "";
        [Desc("圣女名字")]
        public string GoddessName = "";
        [Desc("圣女驻守城池")]
        public int GoddessCity = 0;
    };
    [Desc("势力详细我的")]
    public partial class CLS_GuildInfoMy
    {
        [Desc("详细信息")]
        public CLS_GuildInfoDetails GuildInfoDetails = new CLS_GuildInfoDetails();
    };
    [Desc("请求 势力列表")]
    public partial class C2G_Guild_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_List() { ProtocolId = EProtocolId.C2G_GUILD_LIST; }
        public C2G_Guild_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力列表")]
    public partial class G2C_Guild_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力列表")]
        public List<CLS_GuildInfoBase> ListGuildInfoBase = new List<CLS_GuildInfoBase>();
        [Desc("剩余可加入时间(0为可加入)")]
        public TimeSpan CdCanJoin = new TimeSpan();
        public G2C_Guild_List() { ProtocolId = EProtocolId.G2C_GUILD_LIST; }
        public G2C_Guild_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 势力详情")]
    public partial class C2G_Guild_ListDetails : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        public C2G_Guild_ListDetails() { ProtocolId = EProtocolId.C2G_GUILD_LISTDETAILS; }
        public C2G_Guild_ListDetails(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力详情")]
    public partial class G2C_Guild_ListDetails : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力详情")]
        public CLS_GuildInfoDetails GuildInfoDetails = new CLS_GuildInfoDetails();
        public G2C_Guild_ListDetails() { ProtocolId = EProtocolId.G2C_GUILD_LISTDETAILS; }
        public G2C_Guild_ListDetails(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 势力创建")]
    public partial class C2G_Guild_Create : ProtocolMsgBase, INbsSerializer
    {
        [Desc("名字")]
        public string Name = "";
        public C2G_Guild_Create() { ProtocolId = EProtocolId.C2G_GUILD_CREATE; }
        public C2G_Guild_Create(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力创建")]
    public partial class G2C_Guild_Create : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_Create() { ProtocolId = EProtocolId.G2C_GUILD_CREATE; }
        public G2C_Guild_Create(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 脱离")]
    public partial class C2G_Guild_TryLeave : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_TryLeave() { ProtocolId = EProtocolId.C2G_GUILD_TRYLEAVE; }
        public C2G_Guild_TryLeave(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 脱离")]
    public partial class G2C_Guild_TryLeave : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_TryLeave() { ProtocolId = EProtocolId.G2C_GUILD_TRYLEAVE; }
        public G2C_Guild_TryLeave(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 逐出")]
    public partial class C2G_Guild_TryKick : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家ID")]
        public long TargetPuid = 0;
        public C2G_Guild_TryKick() { ProtocolId = EProtocolId.C2G_GUILD_TRYKICK; }
        public C2G_Guild_TryKick(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 逐出")]
    public partial class G2C_Guild_TryKick : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_TryKick() { ProtocolId = EProtocolId.G2C_GUILD_TRYKICK; }
        public G2C_Guild_TryKick(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 禅让")]
    public partial class C2G_Guild_Abdicate : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家ID")]
        public long TargetPuid = 0;
        public C2G_Guild_Abdicate() { ProtocolId = EProtocolId.C2G_GUILD_ABDICATE; }
        public C2G_Guild_Abdicate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 禅让")]
    public partial class G2C_Guild_Abdicate : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_Abdicate() { ProtocolId = EProtocolId.G2C_GUILD_ABDICATE; }
        public G2C_Guild_Abdicate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 申请加入")]
    public partial class C2G_Guild_TryJoin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        public C2G_Guild_TryJoin() { ProtocolId = EProtocolId.C2G_GUILD_TRYJOIN; }
        public C2G_Guild_TryJoin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 申请加入")]
    public partial class G2C_Guild_TryJoin : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_TryJoin() { ProtocolId = EProtocolId.G2C_GUILD_TRYJOIN; }
        public G2C_Guild_TryJoin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 申请列表")]
    public partial class C2G_Guild_ListApply : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListApply() { ProtocolId = EProtocolId.C2G_GUILD_LISTAPPLY; }
        public C2G_Guild_ListApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 申请列表")]
    public partial class G2C_Guild_ListApply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力申请列表")]
        public List<CLS_PubPlayerBase> ListApply = new List<CLS_PubPlayerBase>();
        public G2C_Guild_ListApply() { ProtocolId = EProtocolId.G2C_GUILD_LISTAPPLY; }
        public G2C_Guild_ListApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 申请处理")]
    public partial class C2G_Guild_ApplyAction : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家ID")]
        public long TargetPuid = 0;
        [Desc("处理方式 EHandleAction")]
        public int HandleAction = 0;
        public C2G_Guild_ApplyAction() { ProtocolId = EProtocolId.C2G_GUILD_APPLYACTION; }
        public C2G_Guild_ApplyAction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 申请处理")]
    public partial class G2C_Guild_ApplyAction : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象玩家ID")]
        public long TargetPuid = 0;
        [Desc("处理方式 EHandleAction")]
        public int HandleAction = 0;
        [Desc("人数")]
        public CLS_CountInfo CountMember = new CLS_CountInfo();
        public G2C_Guild_ApplyAction() { ProtocolId = EProtocolId.G2C_GUILD_APPLYACTION; }
        public G2C_Guild_ApplyAction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力成员信息")]
    public partial class CLS_GuildMbsInfo
    {
        [Desc("基本信息")]
        public CLS_PubPlayerBase PubPlayerBase = new CLS_PubPlayerBase();
        [Desc("贡献")]
        public int Contribution = 0;
        [Desc("历史贡献")]
        public int ContributionTotal = 0;
        [Desc("加入势力时间")]
        public DateTime TimeJoin = DateTime.Now;
    };
    [Desc("请求 成员列表")]
    public partial class C2G_Guild_ListMbs : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListMbs() { ProtocolId = EProtocolId.C2G_GUILD_LISTMBS; }
        public C2G_Guild_ListMbs(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 成员列表")]
    public partial class G2C_Guild_ListMbs : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力成员列表")]
        public List<CLS_GuildMbsInfo> ListMember = new List<CLS_GuildMbsInfo>();
        public G2C_Guild_ListMbs() { ProtocolId = EProtocolId.G2C_GUILD_LISTMBS; }
        public G2C_Guild_ListMbs(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 动态列表")]
    public partial class C2G_Guild_ListLogRecord : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListLogRecord() { ProtocolId = EProtocolId.C2G_GUILD_LISTLOGRECORD; }
        public C2G_Guild_ListLogRecord(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 动态列表")]
    public partial class G2C_Guild_ListLogRecord : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力动态列表")]
        public List<CLS_GameLog> ListLog = new List<CLS_GameLog>();
        public G2C_Guild_ListLogRecord() { ProtocolId = EProtocolId.G2C_GUILD_LISTLOGRECORD; }
        public G2C_Guild_ListLogRecord(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 改名")]
    public partial class C2G_Guild_Rename : ProtocolMsgBase, INbsSerializer
    {
        [Desc("名字")]
        public string Name = "";
        public C2G_Guild_Rename() { ProtocolId = EProtocolId.C2G_GUILD_RENAME; }
        public C2G_Guild_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 改名")]
    public partial class G2C_Guild_Rename : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_Rename() { ProtocolId = EProtocolId.G2C_GUILD_RENAME; }
        public G2C_Guild_Rename(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 修改加入设置")]
    public partial class C2G_Guild_JoinMode : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力加入方式 EGuildJoinMode")]
        public byte JoinMode = 0;
        public C2G_Guild_JoinMode() { ProtocolId = EProtocolId.C2G_GUILD_JOINMODE; }
        public C2G_Guild_JoinMode(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 修改加入设置")]
    public partial class G2C_Guild_JoinMode : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_JoinMode() { ProtocolId = EProtocolId.G2C_GUILD_JOINMODE; }
        public G2C_Guild_JoinMode(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 修改宣言")]
    public partial class C2G_Guild_Manifesto : ProtocolMsgBase, INbsSerializer
    {
        [Desc("宣言")]
        public string Manifesto = "";
        public C2G_Guild_Manifesto() { ProtocolId = EProtocolId.C2G_GUILD_MANIFESTO; }
        public C2G_Guild_Manifesto(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 修改宣言")]
    public partial class G2C_Guild_Manifesto : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_Manifesto() { ProtocolId = EProtocolId.G2C_GUILD_MANIFESTO; }
        public G2C_Guild_Manifesto(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 修改公告")]
    public partial class C2G_Guild_Notice : ProtocolMsgBase, INbsSerializer
    {
        [Desc("公告")]
        public string Notice = "";
        public C2G_Guild_Notice() { ProtocolId = EProtocolId.C2G_GUILD_NOTICE; }
        public C2G_Guild_Notice(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 修改公告")]
    public partial class G2C_Guild_Notice : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_Notice() { ProtocolId = EProtocolId.G2C_GUILD_NOTICE; }
        public G2C_Guild_Notice(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 捐献信息")]
    public partial class C2G_Guild_DonateInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_DonateInfo() { ProtocolId = EProtocolId.C2G_GUILD_DONATEINFO; }
        public C2G_Guild_DonateInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 捐献信息")]
    public partial class G2C_Guild_DonateInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("捐献记录")]
        public List<CLS_GameLog> ListLog = new List<CLS_GameLog>();
        [Desc("捐献次数(key=捐献id value=今日次数)")]
        public Dictionary<int, int> DictDonateCount = new Dictionary<int, int>();
        [Desc("贡献值")]
        public int Contribution = 0;
        public G2C_Guild_DonateInfo() { ProtocolId = EProtocolId.G2C_GUILD_DONATEINFO; }
        public G2C_Guild_DonateInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 捐献")]
    public partial class C2G_Guild_Donate : ProtocolMsgBase, INbsSerializer
    {
        public int DonateId = 0;
        public C2G_Guild_Donate() { ProtocolId = EProtocolId.C2G_GUILD_DONATE; }
        public C2G_Guild_Donate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 捐献")]
    public partial class G2C_Guild_Donate : ProtocolMsgBase, INbsSerializer
    {
        public int DonateId = 0;
        [Desc("新增捐献记录")]
        public CLS_GameLog DonateLog = new CLS_GameLog();
        [Desc("详细信息")]
        public CLS_GuildInfoDetails GuildInfoDetails = new CLS_GuildInfoDetails();
        [Desc("贡献值")]
        public int Contribution = 0;
        public G2C_Guild_Donate() { ProtocolId = EProtocolId.G2C_GUILD_DONATE; }
        public G2C_Guild_Donate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 势力关系列表")]
    public partial class C2G_Guild_ListDiplomacy : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListDiplomacy() { ProtocolId = EProtocolId.C2G_GUILD_LISTDIPLOMACY; }
        public C2G_Guild_ListDiplomacy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力关系列表")]
    public partial class G2C_Guild_ListDiplomacy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力关系列表")]
        public List<CLS_GuildInfoBase> ListGuildInfoBase = new List<CLS_GuildInfoBase>();
        public G2C_Guild_ListDiplomacy() { ProtocolId = EProtocolId.G2C_GUILD_LISTDIPLOMACY; }
        public G2C_Guild_ListDiplomacy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 势力名搜索")]
    public partial class C2G_Guild_SearchName : ProtocolMsgBase, INbsSerializer
    {
        [Desc("关键字")]
        public string Key = "";
        public C2G_Guild_SearchName() { ProtocolId = EProtocolId.C2G_GUILD_SEARCHNAME; }
        public C2G_Guild_SearchName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力名搜索")]
    public partial class G2C_Guild_SearchName : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力名搜索结果")]
        public List<CLS_GuildInfoBase> ListGuildInfoBase = new List<CLS_GuildInfoBase>();
        public G2C_Guild_SearchName() { ProtocolId = EProtocolId.G2C_GUILD_SEARCHNAME; }
        public G2C_Guild_SearchName(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 同盟申请列表")]
    public partial class C2G_Guild_ListAllianceApply : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListAllianceApply() { ProtocolId = EProtocolId.C2G_GUILD_LISTALLIANCEAPPLY; }
        public C2G_Guild_ListAllianceApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 同盟申请列表")]
    public partial class G2C_Guild_ListAllianceApply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("同盟申请列表")]
        public List<CLS_GuildInfoBase> ListGuildInfoBase = new List<CLS_GuildInfoBase>();
        public G2C_Guild_ListAllianceApply() { ProtocolId = EProtocolId.G2C_GUILD_LISTALLIANCEAPPLY; }
        public G2C_Guild_ListAllianceApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 同盟申请")]
    public partial class C2G_Guild_AllianceApply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        public C2G_Guild_AllianceApply() { ProtocolId = EProtocolId.C2G_GUILD_ALLIANCEAPPLY; }
        public C2G_Guild_AllianceApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 同盟申请")]
    public partial class G2C_Guild_AllianceApply : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_AllianceApply() { ProtocolId = EProtocolId.G2C_GUILD_ALLIANCEAPPLY; }
        public G2C_Guild_AllianceApply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 同盟解除")]
    public partial class C2G_Guild_AllianceRemove : ProtocolMsgBase, INbsSerializer
    {
        [Desc("唯一ID")]
        public long Uid = 0;
        public C2G_Guild_AllianceRemove() { ProtocolId = EProtocolId.C2G_GUILD_ALLIANCEREMOVE; }
        public C2G_Guild_AllianceRemove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 同盟解除")]
    public partial class G2C_Guild_AllianceRemove : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_AllianceRemove() { ProtocolId = EProtocolId.G2C_GUILD_ALLIANCEREMOVE; }
        public G2C_Guild_AllianceRemove(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 同盟申请处理")]
    public partial class C2G_Guild_AllianceApplyAction : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对象ID")]
        public long Uid = 0;
        [Desc("处理方式 EHandleAction")]
        public int HandleAction = 0;
        public C2G_Guild_AllianceApplyAction() { ProtocolId = EProtocolId.C2G_GUILD_ALLIANCEAPPLYACTION; }
        public C2G_Guild_AllianceApplyAction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 同盟申请处理")]
    public partial class G2C_Guild_AllianceApplyAction : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_AllianceApplyAction() { ProtocolId = EProtocolId.G2C_GUILD_ALLIANCEAPPLYACTION; }
        public G2C_Guild_AllianceApplyAction(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池列表")]
    public partial class C2G_Guild_ListCity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListCity() { ProtocolId = EProtocolId.C2G_GUILD_LISTCITY; }
        public C2G_Guild_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池列表")]
    public partial class G2C_Guild_ListCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("都城ID")]
        public int CapitalCity = 0;
        [Desc("城池列表")]
        public List<CLS_CityInfo4Guild> ListCity = new List<CLS_CityInfo4Guild>();
        public G2C_Guild_ListCity() { ProtocolId = EProtocolId.G2C_GUILD_LISTCITY; }
        public G2C_Guild_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 设置都城")]
    public partial class C2G_Guild_SetCapitalCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int Uid = 0;
        public C2G_Guild_SetCapitalCity() { ProtocolId = EProtocolId.C2G_GUILD_SETCAPITALCITY; }
        public C2G_Guild_SetCapitalCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 设置都城")]
    public partial class G2C_Guild_SetCapitalCity : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_SetCapitalCity() { ProtocolId = EProtocolId.G2C_GUILD_SETCAPITALCITY; }
        public G2C_Guild_SetCapitalCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 任命太守")]
    public partial class C2G_Guild_SetCityLeader : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int Uid = 0;
        [Desc("新任命的玩家ID")]
        public long LeaderPuid = 0;
        public C2G_Guild_SetCityLeader() { ProtocolId = EProtocolId.C2G_GUILD_SETCITYLEADER; }
        public C2G_Guild_SetCityLeader(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 任命太守")]
    public partial class G2C_Guild_SetCityLeader : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_SetCityLeader() { ProtocolId = EProtocolId.G2C_GUILD_SETCITYLEADER; }
        public G2C_Guild_SetCityLeader(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 撤销太守")]
    public partial class C2G_Guild_RemoveCityLeader : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int Uid = 0;
        public C2G_Guild_RemoveCityLeader() { ProtocolId = EProtocolId.C2G_GUILD_REMOVECITYLEADER; }
        public C2G_Guild_RemoveCityLeader(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 撤销太守")]
    public partial class G2C_Guild_RemoveCityLeader : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_RemoveCityLeader() { ProtocolId = EProtocolId.G2C_GUILD_REMOVECITYLEADER; }
        public G2C_Guild_RemoveCityLeader(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 军情")]
    public partial class C2G_Guild_ListLogSituation : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListLogSituation() { ProtocolId = EProtocolId.C2G_GUILD_LISTLOGSITUATION; }
        public C2G_Guild_ListLogSituation(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 军情")]
    public partial class G2C_Guild_ListLogSituation : ProtocolMsgBase, INbsSerializer
    {
        [Desc("军情列表")]
        public List<CLS_GameLog> ListLog = new List<CLS_GameLog>();
        public G2C_Guild_ListLogSituation() { ProtocolId = EProtocolId.G2C_GUILD_LISTLOGSITUATION; }
        public G2C_Guild_ListLogSituation(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力排行信息单条")]
    public partial class CLS_GuildTopInfo
    {
        [Desc("唯一ID")]
        public long GuildUid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("所属国")]
        public int CountryId = 0;
        [Desc("城池数")]
        public int CountCity = 0;
        [Desc("最后占领时间")]
        public long TsLastSeize = 0;
    };
    [Desc("请求 势力排行")]
    public partial class C2G_Guild_ListTop : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ListTop() { ProtocolId = EProtocolId.C2G_GUILD_LISTTOP; }
        public C2G_Guild_ListTop(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力排行")]
    public partial class G2C_Guild_ListTop : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力排行")]
        public List<CLS_GuildTopInfo> ListTop = new List<CLS_GuildTopInfo>();
        public G2C_Guild_ListTop() { ProtocolId = EProtocolId.G2C_GUILD_LISTTOP; }
        public G2C_Guild_ListTop(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("红包成员信息")]
    public partial class CLS_RedPacketMember
    {
        [Desc("玩家ID")]
        public long PlayerID = 0;
        [Desc("头像ID")]
        public int HeadId = 0;
        public string Name = "";
        [Desc("抢到金额")]
        public int Bonus = 0;
    };
    [Desc("//红包列表")]
    public partial class CLS_RedPacketsInfo
    {
        [Desc("红包ID")]
        public long RedPacketsID = 0;
        [Desc("发起者")]
        public CLS_RedPacketMember Owner = new CLS_RedPacketMember();
        [Desc("状态 ERedPacketState")]
        public int State = 0;
        [Desc("还剩多少时间(秒)")]
        public int TimeEnd = 0;
    };
    [Desc("//红包信息")]
    public partial class CLS_RedPacket
    {
        [Desc("红包ID")]
        public long RedPacketsID = 0;
        [Desc("总金额")]
        public int TotalSugar = 0;
        [Desc("总个数")]
        public int TotalNumber = 0;
        [Desc("剩余金额")]
        public int SurplusSugar = 0;
        [Desc("剩余个数")]
        public int SurplusNumber = 0;
        [Desc("发起者")]
        public CLS_RedPacketMember Owner = new CLS_RedPacketMember();
        [Desc("还剩多少时间(秒)")]
        public int TimeEnd = 0;
        [Desc("已抢列表")]
        public List<CLS_RedPacketMember> ListMember = new List<CLS_RedPacketMember>();
        [Desc("祝福语")]
        public string Txt = "";
    };
    [Desc("请求 红包列表")]
    public partial class C2G_Red_Packet_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Red_Packet_List() { ProtocolId = EProtocolId.C2G_RED_PACKET_LIST; }
        public C2G_Red_Packet_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 红包列表")]
    public partial class G2C_Red_Packet_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("0:领红包未达到上限,1:领红包达到上限")]
        public int GetMax = 0;
        [Desc("红包列表")]
        public List<CLS_RedPacketsInfo> Info = new List<CLS_RedPacketsInfo>();
        public G2C_Red_Packet_List() { ProtocolId = EProtocolId.G2C_RED_PACKET_LIST; }
        public G2C_Red_Packet_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 单个红包信息")]
    public partial class C2G_Red_Packet_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("红包ID")]
        public long RedPacketsID = 0;
        public C2G_Red_Packet_Info() { ProtocolId = EProtocolId.C2G_RED_PACKET_INFO; }
        public C2G_Red_Packet_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 单个红包信息")]
    public partial class G2C_Red_Packet_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("状态")]
        public int Error = 0;
        [Desc("红包信息")]
        public CLS_RedPacket Info = new CLS_RedPacket();
        public G2C_Red_Packet_Info() { ProtocolId = EProtocolId.G2C_RED_PACKET_INFO; }
        public G2C_Red_Packet_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 发红包")]
    public partial class C2G_Give_Red_Packet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("金额")]
        public int Sugar = 0;
        [Desc("个数")]
        public int Number = 0;
        [Desc("祝福语")]
        public string Txt = "";
        public C2G_Give_Red_Packet() { ProtocolId = EProtocolId.C2G_GIVE_RED_PACKET; }
        public C2G_Give_Red_Packet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 发红包")]
    public partial class G2C_Give_Red_Packet : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Give_Red_Packet() { ProtocolId = EProtocolId.G2C_GIVE_RED_PACKET; }
        public G2C_Give_Red_Packet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 发红包")]
    public partial class G2C_Red_Packet_Receive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("红包信息")]
        public CLS_RedPacketsInfo Info = new CLS_RedPacketsInfo();
        [Desc("红包列表")]
        public List<CLS_RedPacketsInfo> InfoList = new List<CLS_RedPacketsInfo>();
        public G2C_Red_Packet_Receive() { ProtocolId = EProtocolId.G2C_RED_PACKET_RECEIVE; }
        public G2C_Red_Packet_Receive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 抢红包")]
    public partial class C2G_Get_Red_Packet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("红包ID")]
        public long RedPacketsID = 0;
        public C2G_Get_Red_Packet() { ProtocolId = EProtocolId.C2G_GET_RED_PACKET; }
        public C2G_Get_Red_Packet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 抢红包")]
    public partial class G2C_Get_Red_Packet : ProtocolMsgBase, INbsSerializer
    {
        [Desc("状态")]
        public int Error = 0;
        [Desc("抢到的金额")]
        public int Bonus = 0;
        [Desc("0:领红包未达到上限,1:领红包达到上限")]
        public int GetMax = 0;
        [Desc("红包信息")]
        public CLS_RedPacket Info = new CLS_RedPacket();
        public G2C_Get_Red_Packet() { ProtocolId = EProtocolId.G2C_GET_RED_PACKET; }
        public G2C_Get_Red_Packet(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 获取府Boss信息")]
    public partial class C2G_MansionBoss_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        public C2G_MansionBoss_Info() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_INFO; }
        public C2G_MansionBoss_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取府Boss信息")]
    public partial class G2C_MansionBoss_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("是否已开启")]
        public bool IsOpen = false;
        [Desc("今日可开启次数")]
        public int OpenCount = 0;
        [Desc("ConfigID")]
        public int ConfigID = 0;
        [Desc("剩余毫秒")]
        public long EndTs = 0;
        [Desc("本日可挑战次数")]
        public int Count = 0;
        [Desc("最大可挑战次数")]
        public int CountMax = 0;
        [Desc("当前血量")]
        public long HpCur = 0;
        [Desc("玩家排名")]
        public int Rank = 0;
        public G2C_MansionBoss_Info() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_INFO; }
        public G2C_MansionBoss_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理府Boss开启")]
    public partial class C2G_MansionBoss_Open : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        public C2G_MansionBoss_Open() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_OPEN; }
        public C2G_MansionBoss_Open(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理府Boss开启")]
    public partial class G2C_MansionBoss_Open : ProtocolMsgBase, INbsSerializer
    {
        public G2C_MansionBoss_Open() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_OPEN; }
        public G2C_MansionBoss_Open(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("Boss排行玩家信息")]
    public partial class CLS_MansionBoss_PlayerInfo
    {
        [Desc("玩家ID")]
        public long Id = 0;
        [Desc("头像")]
        public int Headindex = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("伤害")]
        public long Hurt = 0;
        [Desc("伤害百分比")]
        public float HurtPer = 0.0f;
    };
    [Desc("请求 获取府Boss伤害排行")]
    public partial class C2G_MansionBoss_Top : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        public C2G_MansionBoss_Top() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_TOP; }
        public C2G_MansionBoss_Top(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取府Boss伤害排行")]
    public partial class G2C_MansionBoss_Top : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家排行")]
        public List<CLS_MansionBoss_PlayerInfo> TopPlayers = new List<CLS_MansionBoss_PlayerInfo>();
        [Desc("玩家自己")]
        public CLS_MansionBoss_PlayerInfo player = new CLS_MansionBoss_PlayerInfo();
        [Desc("玩家排名")]
        public int Rank = 0;
        public G2C_MansionBoss_Top() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_TOP; }
        public G2C_MansionBoss_Top(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理府Boss进入战斗")]
    public partial class C2G_MansionBoss_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        public C2G_MansionBoss_Battle() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_BATTLE; }
        public C2G_MansionBoss_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理府Boss进入战斗")]
    public partial class G2C_MansionBoss_Battle : ProtocolMsgBase, INbsSerializer
    {
        public G2C_MansionBoss_Battle() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_BATTLE; }
        public G2C_MansionBoss_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理府Boss战斗结算")]
    public partial class C2G_MansionBoss_Balance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        [Desc("造成伤害")]
        public long HurtHp = 0;
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("玩家消耗兵力")]
        public int PlayerExpendHp = 0;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        [Desc("战斗结果")]
        public int State = 0;
        public C2G_MansionBoss_Balance() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_BALANCE; }
        public C2G_MansionBoss_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理府Boss战斗结算")]
    public partial class G2C_MansionBoss_Balance : ProtocolMsgBase, INbsSerializer
    {
        public G2C_MansionBoss_Balance() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_BALANCE; }
        public G2C_MansionBoss_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理府Boss主动战斗结算")]
    public partial class G2C_MansionBoss_TakeBalance : ProtocolMsgBase, INbsSerializer
    {
        public G2C_MansionBoss_TakeBalance() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_TAKEBALANCE; }
        public G2C_MansionBoss_TakeBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理府BossBuff信息和购买")]
    public partial class C2G_MansionBoss_Buff : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府ID")]
        public long MansionId = 0;
        [Desc("购买buff配置ID  为0 则是查看信息")]
        public int Config = 0;
        public C2G_MansionBoss_Buff() { ProtocolId = EProtocolId.C2G_MANSIONBOSS_BUFF; }
        public C2G_MansionBoss_Buff(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理府BossBuff信息和购买")]
    public partial class G2C_MansionBoss_Buff : ProtocolMsgBase, INbsSerializer
    {
        [Desc("Buffid")]
        public List<int> BuffIds = new List<int>();
        [Desc("已经拥有的buffid，剩余时间")]
        public Dictionary<int, long> CurBuff = new Dictionary<int, long>();
        [Desc("拥有的府玉")]
        public long FuYu = 0;
        public G2C_MansionBoss_Buff() { ProtocolId = EProtocolId.G2C_MANSIONBOSS_BUFF; }
        public G2C_MansionBoss_Buff(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("单条活跃状态")]
    public partial class CLS_Liveness_Info
    {
        [Desc("数值")]
        public int Num = 0;
        [Desc("是否已经领取")]
        public Dictionary<int, bool> DictAwardState = new Dictionary<int, bool>();
    };
    [Desc("请求 府活跃度")]
    public partial class C2G_Guild_GetActive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府id")]
        public long GuildId = 0;
        public C2G_Guild_GetActive() { ProtocolId = EProtocolId.C2G_GUILD_GETACTIVE; }
        public C2G_Guild_GetActive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 府活跃度")]
    public partial class G2C_Guild_GetActive : ProtocolMsgBase, INbsSerializer
    {
        [Desc("活跃状态")]
        public Dictionary<int, CLS_Liveness_Info> DictLivenessInfo = new Dictionary<int, CLS_Liveness_Info>();
        public G2C_Guild_GetActive() { ProtocolId = EProtocolId.G2C_GUILD_GETACTIVE; }
        public G2C_Guild_GetActive(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 府活跃度奖励领取")]
    public partial class C2G_Guild_ActiveAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("府id")]
        public long GuildId = 0;
        [Desc("箱子编号")]
        public int BoxID = 0;
        public C2G_Guild_ActiveAward() { ProtocolId = EProtocolId.C2G_GUILD_ACTIVEAWARD; }
        public C2G_Guild_ActiveAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 府活跃度奖励领取")]
    public partial class G2C_Guild_ActiveAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        [Desc("活跃状态")]
        public Dictionary<int, CLS_Liveness_Info> DictLivenessInfo = new Dictionary<int, CLS_Liveness_Info>();
        public G2C_Guild_ActiveAward() { ProtocolId = EProtocolId.G2C_GUILD_ACTIVEAWARD; }
        public G2C_Guild_ActiveAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 府活跃度奖励全部领取")]
    public partial class C2G_Guild_ActiveAwardAll : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ActiveAwardAll() { ProtocolId = EProtocolId.C2G_GUILD_ACTIVEAWARDALL; }
        public C2G_Guild_ActiveAwardAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 府活跃度奖励全部领取")]
    public partial class G2C_Guild_ActiveAwardAll : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        [Desc("活跃状态")]
        public Dictionary<int, CLS_Liveness_Info> DictLivenessInfo = new Dictionary<int, CLS_Liveness_Info>();
        public G2C_Guild_ActiveAwardAll() { ProtocolId = EProtocolId.G2C_GUILD_ACTIVEAWARDALL; }
        public G2C_Guild_ActiveAwardAll(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 书院信息")]
    public partial class C2G_Guild_ScienceInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ScienceInfo() { ProtocolId = EProtocolId.C2G_GUILD_SCIENCEINFO; }
        public C2G_Guild_ScienceInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 书院信息")]
    public partial class G2C_Guild_ScienceInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("科技ID列表")]
        public List<int> ListTechnology = new List<int>();
        public G2C_Guild_ScienceInfo() { ProtocolId = EProtocolId.G2C_GUILD_SCIENCEINFO; }
        public G2C_Guild_ScienceInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 势力科技升级")]
    public partial class C2G_Guild_ScienceLevelUp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("科技ID")]
        public int ID = 0;
        public C2G_Guild_ScienceLevelUp() { ProtocolId = EProtocolId.C2G_GUILD_SCIENCELEVELUP; }
        public C2G_Guild_ScienceLevelUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 势力科技升级")]
    public partial class G2C_Guild_ScienceLevelUp : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Guild_ScienceLevelUp() { ProtocolId = EProtocolId.G2C_GUILD_SCIENCELEVELUP; }
        public G2C_Guild_ScienceLevelUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力商店信息")]
    public partial class CLS_GuildShopInfo
    {
        [Desc("商品信息")]
        public List<CLS_ShopGoodsInfo> GoodsInfo = new List<CLS_ShopGoodsInfo>();
        [Desc("拥有的贡献")]
        public int Contribution = 0;
        [Desc("累计免费刷新次数")]
        public int RefreshFreeTotal = 0;
        [Desc("累计刷新次数")]
        public int RefreshTotal = 0;
        [Desc("刷新道具数量")]
        public int RefreshItemCount = 0;
    };
    [Desc("请求 处理势力商店信息")]
    public partial class C2G_Guild_ShopInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ShopInfo() { ProtocolId = EProtocolId.C2G_GUILD_SHOPINFO; }
        public C2G_Guild_ShopInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理势力商店信息")]
    public partial class G2C_Guild_ShopInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商品信息")]
        public CLS_GuildShopInfo ShopInfo = new CLS_GuildShopInfo();
        public G2C_Guild_ShopInfo() { ProtocolId = EProtocolId.G2C_GUILD_SHOPINFO; }
        public G2C_Guild_ShopInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理势力商店购买")]
    public partial class C2G_Guild_ShopBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("配置ID")]
        public int Config = 0;
        [Desc("数量")]
        public int Amount = 0;
        public C2G_Guild_ShopBuy() { ProtocolId = EProtocolId.C2G_GUILD_SHOPBUY; }
        public C2G_Guild_ShopBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理势力商店购买")]
    public partial class G2C_Guild_ShopBuy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商品信息")]
        public CLS_GuildShopInfo ShopInfo = new CLS_GuildShopInfo();
        public G2C_Guild_ShopBuy() { ProtocolId = EProtocolId.G2C_GUILD_SHOPBUY; }
        public G2C_Guild_ShopBuy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 处理势力商店刷新")]
    public partial class C2G_Guild_ShopRefresh : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Guild_ShopRefresh() { ProtocolId = EProtocolId.C2G_GUILD_SHOPREFRESH; }
        public C2G_Guild_ShopRefresh(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 处理势力商店刷新")]
    public partial class G2C_Guild_ShopRefresh : ProtocolMsgBase, INbsSerializer
    {
        [Desc("商品信息")]
        public CLS_GuildShopInfo ShopInfo = new CLS_GuildShopInfo();
        public G2C_Guild_ShopRefresh() { ProtocolId = EProtocolId.G2C_GUILD_SHOPREFRESH; }
        public G2C_Guild_ShopRefresh(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力成员俸禄信息")]
    public partial class CLS_GuildSalaryMbsInfo
    {
        [Desc("基本信息")]
        public CLS_PubPlayerBase PubPlayerBase = new CLS_PubPlayerBase();
        [Desc("上周贡献")]
        public int ContributionWeekLast = 0;
        [Desc("本周贡献")]
        public int ContributionWeekThis = 0;
    };
    [Desc("请求 俸禄成员列表")]
    public partial class C2G_GuildSalary_ListMbs : ProtocolMsgBase, INbsSerializer
    {
        public C2G_GuildSalary_ListMbs() { ProtocolId = EProtocolId.C2G_GUILDSALARY_LISTMBS; }
        public C2G_GuildSalary_ListMbs(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 俸禄成员列表")]
    public partial class G2C_GuildSalary_ListMbs : ProtocolMsgBase, INbsSerializer
    {
        [Desc("自动结算时间")]
        public DateTime DtAutoBalance = DateTime.Now;
        [Desc("势力成员列表")]
        public List<CLS_GuildSalaryMbsInfo> ListMember = new List<CLS_GuildSalaryMbsInfo>();
        public G2C_GuildSalary_ListMbs() { ProtocolId = EProtocolId.G2C_GUILDSALARY_LISTMBS; }
        public G2C_GuildSalary_ListMbs(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 俸禄发放")]
    public partial class C2G_GuildSalary_Pay : ProtocolMsgBase, INbsSerializer
    {
        [Desc("<对象玩家ID, 金币数量>")]
        public Dictionary<long, int> DictPay = new Dictionary<long, int>();
        public C2G_GuildSalary_Pay() { ProtocolId = EProtocolId.C2G_GUILDSALARY_PAY; }
        public C2G_GuildSalary_Pay(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 俸禄发放")]
    public partial class G2C_GuildSalary_Pay : ProtocolMsgBase, INbsSerializer
    {
        [Desc("<对象玩家ID, 金币数量>")]
        public Dictionary<long, int> DictPay = new Dictionary<long, int>();
        public G2C_GuildSalary_Pay() { ProtocolId = EProtocolId.G2C_GUILDSALARY_PAY; }
        public G2C_GuildSalary_Pay(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("势力城市俸禄信息")]
    public partial class CLS_GuildSalaryCityInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("太守Id")]
        public long LeaderPuid = 0;
        [Desc("太守名字")]
        public string LeaderName = "";
        [Desc("繁荣度")]
        public long Prosperity = 0;
        [Desc("预期收益")]
        public int Revenue = 0;
    };
    [Desc("请求 俸禄城市列表")]
    public partial class C2G_GuildSalary_ListCity : ProtocolMsgBase, INbsSerializer
    {
        public C2G_GuildSalary_ListCity() { ProtocolId = EProtocolId.C2G_GUILDSALARY_LISTCITY; }
        public C2G_GuildSalary_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 俸禄城市列表")]
    public partial class G2C_GuildSalary_ListCity : ProtocolMsgBase, INbsSerializer
    {
        [Desc("势力城市列表")]
        public List<CLS_GuildSalaryCityInfo> ListCity = new List<CLS_GuildSalaryCityInfo>();
        public G2C_GuildSalary_ListCity() { ProtocolId = EProtocolId.G2C_GUILDSALARY_LISTCITY; }
        public G2C_GuildSalary_ListCity(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("圣女卫队阵亡信息")]
    public partial class CLS_GoddessArmy
    {
        [Desc("卫队编号")]
        public int index = 0;
        [Desc("复活时间")]
        public DateTime ReviveTime = DateTime.Now;
    };
    [Desc("圣女信息")]
    public partial class CLS_GoddessInfo
    {
        [Desc("所属玩家Id")]
        public long PlayerId = 0;
        [Desc("所属玩家名")]
        public string PlayerName = "";
        [Desc("阶级")]
        public int Advance = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验")]
        public int Exp = 0;
        [Desc("驻守城池")]
        public int CityId = 0;
        [Desc("是否被俘")]
        public bool bCaptive = false;
        [Desc("俘虏方势力Id")]
        public long OtherId = 0;
        [Desc("俘虏方势力名")]
        public string OtherName = "";
        [Desc("释放时间")]
        public DateTime FreeTime = DateTime.Now;
        [Desc("卫队阵亡列表")]
        public List<CLS_GoddessArmy> ArmyInfo = new List<CLS_GoddessArmy>();
    };
    [Desc("圣女捐献信息")]
    public partial class CLS_GoddessDonate
    {
        [Desc("玩家名")]
        public string PlayerName = "";
        [Desc("当前阶段贡献")]
        public int Donate = 0;
    };
    [Desc("请求 圣女资格")]
    public partial class C2G_Goddess_Seniority : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Goddess_Seniority() { ProtocolId = EProtocolId.C2G_GODDESS_SENIORITY; }
        public C2G_Goddess_Seniority(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女资格")]
    public partial class G2C_Goddess_Seniority : ProtocolMsgBase, INbsSerializer
    {
        [Desc("拥有资格的成员")]
        public List<CLS_GuildMbsInfo> Info = new List<CLS_GuildMbsInfo>();
        public G2C_Goddess_Seniority() { ProtocolId = EProtocolId.G2C_GODDESS_SENIORITY; }
        public G2C_Goddess_Seniority(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 圣女信息")]
    public partial class C2G_Goddess_GetInfo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Goddess_GetInfo() { ProtocolId = EProtocolId.C2G_GODDESS_GETINFO; }
        public C2G_Goddess_GetInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女信息")]
    public partial class G2C_Goddess_GetInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("圣女")]
        public CLS_GoddessInfo Info = new CLS_GoddessInfo();
        [Desc("贡献列表")]
        public List<CLS_GoddessDonate> DonateInfo = new List<CLS_GoddessDonate>();
        [Desc("捐献次数(key=捐献id value=今日次数)")]
        public Dictionary<int, int> DictDonate = new Dictionary<int, int>();
        public G2C_Goddess_GetInfo() { ProtocolId = EProtocolId.G2C_GODDESS_GETINFO; }
        public G2C_Goddess_GetInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 圣女选择")]
    public partial class C2G_Goddess_Choose : ProtocolMsgBase, INbsSerializer
    {
        [Desc("拥有资格的成员ID")]
        public long PlayerId = 0;
        public C2G_Goddess_Choose() { ProtocolId = EProtocolId.C2G_GODDESS_CHOOSE; }
        public C2G_Goddess_Choose(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女选择")]
    public partial class G2C_Goddess_Choose : ProtocolMsgBase, INbsSerializer
    {
        [Desc("圣女")]
        public CLS_GoddessInfo Info = new CLS_GoddessInfo();
        public G2C_Goddess_Choose() { ProtocolId = EProtocolId.G2C_GODDESS_CHOOSE; }
        public G2C_Goddess_Choose(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 圣女捐献")]
    public partial class C2G_Goddess_Donate : ProtocolMsgBase, INbsSerializer
    {
        public int DonateId = 0;
        public C2G_Goddess_Donate() { ProtocolId = EProtocolId.C2G_GODDESS_DONATE; }
        public C2G_Goddess_Donate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女捐献")]
    public partial class G2C_Goddess_Donate : ProtocolMsgBase, INbsSerializer
    {
        [Desc("阶级")]
        public int Advance = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("经验")]
        public int Exp = 0;
        [Desc("贡献列表")]
        public List<CLS_GoddessDonate> DonateInfo = new List<CLS_GoddessDonate>();
        [Desc("捐献次数(key=捐献id value=今日次数)")]
        public Dictionary<int, int> DictDonate = new Dictionary<int, int>();
        public G2C_Goddess_Donate() { ProtocolId = EProtocolId.G2C_GODDESS_DONATE; }
        public G2C_Goddess_Donate(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 圣女赎回")]
    public partial class C2G_Goddess_Save : ProtocolMsgBase, INbsSerializer
    {
        public int DonateId = 0;
        public C2G_Goddess_Save() { ProtocolId = EProtocolId.C2G_GODDESS_SAVE; }
        public C2G_Goddess_Save(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女赎回")]
    public partial class G2C_Goddess_Save : ProtocolMsgBase, INbsSerializer
    {
        [Desc("圣女")]
        public CLS_GoddessInfo Info = new CLS_GoddessInfo();
        [Desc("赎回列表")]
        public List<CLS_GoddessDonate> DonateInfo = new List<CLS_GoddessDonate>();
        [Desc("赎回次数(key=捐献id value=今日次数)")]
        public Dictionary<int, int> DictDonate = new Dictionary<int, int>();
        public G2C_Goddess_Save() { ProtocolId = EProtocolId.G2C_GODDESS_SAVE; }
        public G2C_Goddess_Save(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 圣女驻守")]
    public partial class C2G_Goddess_Defend : ProtocolMsgBase, INbsSerializer
    {
        [Desc("驻守城池")]
        public int CityId = 0;
        public C2G_Goddess_Defend() { ProtocolId = EProtocolId.C2G_GODDESS_DEFEND; }
        public C2G_Goddess_Defend(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 圣女驻守")]
    public partial class G2C_Goddess_Defend : ProtocolMsgBase, INbsSerializer
    {
        [Desc("驻守城池")]
        public int CityId = 0;
        public G2C_Goddess_Defend() { ProtocolId = EProtocolId.G2C_GODDESS_DEFEND; }
        public G2C_Goddess_Defend(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 武将上阵PVE")]
    public partial class C2G_Warrior_InBattle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("上阵列表")]
        public List<long> ListInBattle = new List<long>();
        public C2G_Warrior_InBattle() { ProtocolId = EProtocolId.C2G_WARRIOR_INBATTLE; }
        public C2G_Warrior_InBattle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 武将上阵PVE")]
    public partial class G2C_Warrior_InBattle : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Warrior_InBattle() { ProtocolId = EProtocolId.G2C_WARRIOR_INBATTLE; }
        public G2C_Warrior_InBattle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("单个队伍信息")]
    public partial class CLS_ArmyInfo
    {
        [Desc("PVE阵容ID(012)")]
        public int ArmyId = 0;
        [Desc("成员列表 <位置 武将唯一ID>")]
        public Dictionary<int, long> DictWarrior = new Dictionary<int, long>();
    };
    [Desc("PVE某种战斗类型队伍信息")]
    public partial class CLS_PveTypeArmyInfo
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("当前PVE阵容ID(012)")]
        public int PveArmyId = 0;
        [Desc("k=ArmyId v=ArmyInfo")]
        public Dictionary<int, CLS_ArmyInfo> DictArmyInfo = new Dictionary<int, CLS_ArmyInfo>();
    };
    [Desc("请求 PVE阵容信息")]
    public partial class C2G_Pve_ArmyInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型")]
        public int PveType = 0;
        public C2G_Pve_ArmyInfo() { ProtocolId = EProtocolId.C2G_PVE_ARMYINFO; }
        public C2G_Pve_ArmyInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 PVE阵容信息")]
    public partial class G2C_Pve_ArmyInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("当前PVE阵容ID(012)")]
        public int PveArmyId = 0;
        [Desc("k=ArmyId v=ArmyInfo")]
        public Dictionary<int, CLS_ArmyInfo> DictArmyInfo = new Dictionary<int, CLS_ArmyInfo>();
        public G2C_Pve_ArmyInfo() { ProtocolId = EProtocolId.G2C_PVE_ARMYINFO; }
        public G2C_Pve_ArmyInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 PVE阵容更改")]
    public partial class C2G_Pve_ArmyChange : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("当前PVE阵容ID(012)")]
        public int PveArmyId = 0;
        [Desc("k=ArmyId v=ArmyInfo")]
        public Dictionary<int, CLS_ArmyInfo> DictArmyInfo = new Dictionary<int, CLS_ArmyInfo>();
        public C2G_Pve_ArmyChange() { ProtocolId = EProtocolId.C2G_PVE_ARMYCHANGE; }
        public C2G_Pve_ArmyChange(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 PVE阵容更改")]
    public partial class G2C_Pve_ArmyChange : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        public G2C_Pve_ArmyChange() { ProtocolId = EProtocolId.G2C_PVE_ARMYCHANGE; }
        public G2C_Pve_ArmyChange(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 PVE出征")]
    public partial class C2G_Pve_GoBattle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("对应战斗内容ID")]
        public int BattleId = 0;
        public C2G_Pve_GoBattle() { ProtocolId = EProtocolId.C2G_PVE_GOBATTLE; }
        public C2G_Pve_GoBattle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 PVE出征")]
    public partial class G2C_Pve_GoBattle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("对应战斗内容ID")]
        public int BattleId = 0;
        [Desc("战斗验证码")]
        public long BattleCode = 0;
        [Desc("成员列表 <位置 武将战斗信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictWarrior = new Dictionary<int, CLS_WarriorInfo>();
        public G2C_Pve_GoBattle() { ProtocolId = EProtocolId.G2C_PVE_GOBATTLE; }
        public G2C_Pve_GoBattle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("推送 战斗结束武将数据")]
    public partial class G2C_Pve_BattleBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("PVE类型(ETeamType)")]
        public int PveType = 0;
        [Desc("成员列表 <位置 武将战斗信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictWarrior = new Dictionary<int, CLS_WarriorInfo>();
        public G2C_Pve_BattleBalance() { ProtocolId = EProtocolId.G2C_PVE_BATTLEBALANCE; }
        public G2C_Pve_BattleBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("剧情关卡结果")]
    public partial class CLS_StoryState
    {
        [Desc("战斗结果")]
        public List<bool> ListState = new List<bool>();
        [Desc("日挑战次数")]
        public int Ticks = 0;
    };
    [Desc("请求 剧情关卡列表")]
    public partial class C2G_GameLevelStory_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("章节ID")]
        public int StoryID = 0;
        public C2G_GameLevelStory_Info() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORY_INFO; }
        public C2G_GameLevelStory_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情关卡列表")]
    public partial class G2C_GameLevelStory_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("副本字典<关卡ID，通关状态>")]
        public Dictionary<int, CLS_StoryState> DicStory = new Dictionary<int, CLS_StoryState>();
        [Desc("体力")]
        public int Power = 0;
        [Desc("恢复时间")]
        public long RecoveryTime = 0;
        [Desc("奖励是否已经领取")]
        public List<bool> ListReward = new List<bool>();
        [Desc("购买次数")]
        public int BuyCount = 0;
        public G2C_GameLevelStory_Info() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORY_INFO; }
        public G2C_GameLevelStory_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 剧情副本战斗")]
    public partial class C2G_GameLevelStory_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("副本ID")]
        public int Id = 0;
        public C2G_GameLevelStory_Battle() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORY_BATTLE; }
        public C2G_GameLevelStory_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情副本战斗")]
    public partial class G2C_GameLevelStory_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("关卡ID")]
        public int Id = 0;
        public G2C_GameLevelStory_Battle() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORY_BATTLE; }
        public G2C_GameLevelStory_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 剧情副本结算")]
    public partial class C2G_GameLevelStory_Balance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("玩家消耗兵力")]
        public int PlayerExpendHp = 0;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        [Desc("战斗星级结果")]
        public List<bool> ListState = new List<bool>();
        [Desc("战斗结果")]
        public int State = 0;
        public C2G_GameLevelStory_Balance() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORY_BALANCE; }
        public C2G_GameLevelStory_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情副本结算")]
    public partial class G2C_GameLevelStory_Balance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("结算奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_GameLevelStory_Balance() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORY_BALANCE; }
        public G2C_GameLevelStory_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 剧情副本领取奖励")]
    public partial class C2G_GameLevelStory_Reward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("章节ID")]
        public int StoryID = 0;
        [Desc("箱子编号（0,1,2）")]
        public int Index = 0;
        public C2G_GameLevelStory_Reward() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORY_REWARD; }
        public C2G_GameLevelStory_Reward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情副本领取奖励")]
    public partial class G2C_GameLevelStory_Reward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("结算奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_GameLevelStory_Reward() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORY_REWARD; }
        public G2C_GameLevelStory_Reward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 剧情副本购买体力")]
    public partial class C2G_GameLevelStoryBuyPower : ProtocolMsgBase, INbsSerializer
    {
        public C2G_GameLevelStoryBuyPower() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORYBUYPOWER; }
        public C2G_GameLevelStoryBuyPower(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情副本购买体力")]
    public partial class G2C_GameLevelStoryBuyPower : ProtocolMsgBase, INbsSerializer
    {
        [Desc("体力")]
        public int Power = 0;
        [Desc("恢复时间")]
        public long RecoveryTime = 0;
        [Desc("购买次数")]
        public int BuyCount = 0;
        public G2C_GameLevelStoryBuyPower() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORYBUYPOWER; }
        public G2C_GameLevelStoryBuyPower(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 剧情章节列表")]
    public partial class C2G_GameLevelStory : ProtocolMsgBase, INbsSerializer
    {
        public C2G_GameLevelStory() { ProtocolId = EProtocolId.C2G_GAMELEVELSTORY; }
        public C2G_GameLevelStory(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 剧情章节列表")]
    public partial class G2C_GameLevelStory : ProtocolMsgBase, INbsSerializer
    {
        [Desc("当前章节ID")]
        public int StoryID = 0;
        [Desc("体力")]
        public int Power = 0;
        [Desc("恢复时间")]
        public long RecoveryTime = 0;
        [Desc("购买次数")]
        public int BuyCount = 0;
        public G2C_GameLevelStory() { ProtocolId = EProtocolId.G2C_GAMELEVELSTORY; }
        public G2C_GameLevelStory(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("单层信息")]
    public partial class CLS_TowerInfo
    {
        [Desc("ConfigId")]
        public int Id = 0;
        [Desc("ETowerState")]
        public byte TowerState = 0;
    };
    [Desc("请求 古塔信息")]
    public partial class C2G_Tower_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Tower_Info() { ProtocolId = EProtocolId.C2G_TOWER_INFO; }
        public C2G_Tower_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 古塔信息")]
    public partial class G2C_Tower_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("可进入等级")]
        public int LevelStart = 0;
        [Desc("挑战令牌")]
        public int TowerToken = 0;
        [Desc("挑战令牌上限")]
        public int TowerTokenMax = 0;
        [Desc("古塔挑战令牌单次消耗")]
        public int TowerTokenOnceUse = 0;
        [Desc("层信息")]
        public List<CLS_TowerInfo> ListTowerInfo = new List<CLS_TowerInfo>();
        public G2C_Tower_Info() { ProtocolId = EProtocolId.G2C_TOWER_INFO; }
        public G2C_Tower_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 古塔战斗")]
    public partial class C2G_Tower_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ConfigId")]
        public int Id = 0;
        public C2G_Tower_Battle() { ProtocolId = EProtocolId.C2G_TOWER_BATTLE; }
        public C2G_Tower_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 古塔战斗")]
    public partial class G2C_Tower_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ConfigId")]
        public int Id = 0;
        public G2C_Tower_Battle() { ProtocolId = EProtocolId.G2C_TOWER_BATTLE; }
        public G2C_Tower_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 古塔战斗结束")]
    public partial class C2G_Tower_BattleEnd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ConfigId")]
        public int Id = 0;
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("玩家消耗兵力")]
        public int PlayerExpendHp = 0;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        [Desc("战斗结果")]
        public int State = 0;
        [Desc("战斗记录")]
        public string BattleRecord = "";
        public C2G_Tower_BattleEnd() { ProtocolId = EProtocolId.C2G_TOWER_BATTLEEND; }
        public C2G_Tower_BattleEnd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 古塔战斗结束")]
    public partial class G2C_Tower_BattleEnd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("ConfigId")]
        public int Id = 0;
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Tower_BattleEnd() { ProtocolId = EProtocolId.G2C_TOWER_BATTLEEND; }
        public G2C_Tower_BattleEnd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("Arena排行榜信息")]
    public partial class CLS_ArenaTopData
    {
        [Desc("排行")]
        public int Rank = 0;
        [Desc("唯一ID")]
        public long Puid = 0;
        [Desc("名字")]
        public string Name = "";
        [Desc("势力名字")]
        public string GuildName = "";
        [Desc("分数")]
        public int Score = 0;
        [Desc("头像ID")]
        public int HeadIndex = 0;
        [Desc("等级 排行榜用")]
        public int Level = 0;
    };
    [Desc("请求 获取竞技场信息")]
    public partial class C2G_Arena_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Arena_Info() { ProtocolId = EProtocolId.C2G_ARENA_INFO; }
        public C2G_Arena_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取竞技场信息")]
    public partial class G2C_Arena_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("排名")]
        public int Rank = 0;
        [Desc("历史排名")]
        public int HistoryRank = 0;
        [Desc("胜率")]
        public float WinRate = 0.0f;
        [Desc("挑战次数")]
        public int MatchTicks = 0;
        [Desc("最大挑战次数")]
        public int MaxTicks = 0;
        [Desc("竞技场已购买次数")]
        public int BuyMatchTicks = 0;
        [Desc("匹配的玩家")]
        public List<CLS_ArenaTopData> ArenaMatchPlayers = new List<CLS_ArenaTopData>();
        [Desc("挑战刷新剩余时间")]
        public long TsEnd = 0;
        public G2C_Arena_Info() { ProtocolId = EProtocolId.G2C_ARENA_INFO; }
        public G2C_Arena_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 获取竞技场排行榜")]
    public partial class C2G_Arena_TOP : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Arena_TOP() { ProtocolId = EProtocolId.C2G_ARENA_TOP; }
        public C2G_Arena_TOP(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 Arena排行榜")]
    public partial class G2C_Arena_TOP : ProtocolMsgBase, INbsSerializer
    {
        [Desc("Arena排行榜数据")]
        public List<CLS_ArenaTopData> ListArenaTopData = new List<CLS_ArenaTopData>();
        [Desc("玩家数据")]
        public CLS_ArenaTopData PlayerData = new CLS_ArenaTopData();
        public G2C_Arena_TOP() { ProtocolId = EProtocolId.G2C_ARENA_TOP; }
        public G2C_Arena_TOP(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 Arena刷新")]
    public partial class C2G_ArenaMatch_Refresh : ProtocolMsgBase, INbsSerializer
    {
        public C2G_ArenaMatch_Refresh() { ProtocolId = EProtocolId.C2G_ARENAMATCH_REFRESH; }
        public C2G_ArenaMatch_Refresh(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 Arena刷新")]
    public partial class G2C_ArenaMatch_Refresh : ProtocolMsgBase, INbsSerializer
    {
        public G2C_ArenaMatch_Refresh() { ProtocolId = EProtocolId.G2C_ARENAMATCH_REFRESH; }
        public G2C_ArenaMatch_Refresh(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 Arena战斗")]
    public partial class C2G_ArenaMatch_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("挑战的第几位玩家 0,1,2,3")]
        public int index = 0;
        public C2G_ArenaMatch_Battle() { ProtocolId = EProtocolId.C2G_ARENAMATCH_BATTLE; }
        public C2G_ArenaMatch_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 Arena战斗")]
    public partial class G2C_ArenaMatch_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("关卡配置 0则是玩家")]
        public int StageId = 0;
        [Desc("对战武将战斗信息列表")]
        public List<CLS_WarriorInfo> ListWarriorOther = new List<CLS_WarriorInfo>();
        public G2C_ArenaMatch_Battle() { ProtocolId = EProtocolId.G2C_ARENAMATCH_BATTLE; }
        public G2C_ArenaMatch_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 Arena结算")]
    public partial class C2G_ArenaMatch_Balance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("战斗结果")]
        public int State = 0;
        public C2G_ArenaMatch_Balance() { ProtocolId = EProtocolId.C2G_ARENAMATCH_BALANCE; }
        public C2G_ArenaMatch_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 Arena结算")]
    public partial class G2C_ArenaMatch_Balance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家当前排名")]
        public int PlayerRank = 0;
        [Desc("玩家新排名")]
        public int PlayerNewRank = 0;
        [Desc("奖励")]
        public List<CLS_AwardItem> AwardItem = new List<CLS_AwardItem>();
        public G2C_ArenaMatch_Balance() { ProtocolId = EProtocolId.G2C_ARENAMATCH_BALANCE; }
        public G2C_ArenaMatch_Balance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("Arena战报单条信息")]
    public partial class CLS_ArenaBattleReport
    {
        [Desc("胜利")]
        public bool Victory = false;
        [Desc("是否是进攻")]
        public bool IsAttack = false;
        [Desc("名字")]
        public string MatchPlayerName = "";
        [Desc("头像")]
        public int MatchPlayerHeadIndex = 0;
        [Desc("势力名称")]
        public string GuildName = "";
        [Desc("排名变化")]
        public float Rank = 0.0f;
        [Desc("当前排名")]
        public int CurRank = 0;
    };
    [Desc("请求 Arena战报")]
    public partial class C2G_ArenaBattleReport : ProtocolMsgBase, INbsSerializer
    {
        public C2G_ArenaBattleReport() { ProtocolId = EProtocolId.C2G_ARENABATTLEREPORT; }
        public C2G_ArenaBattleReport(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 Arena战报")]
    public partial class G2C_ArenaBattleReport : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战报列表")]
        public List<CLS_ArenaBattleReport> ArenaBattleReportList = new List<CLS_ArenaBattleReport>();
        public G2C_ArenaBattleReport() { ProtocolId = EProtocolId.G2C_ARENABATTLEREPORT; }
        public G2C_ArenaBattleReport(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 竞技场次数购买")]
    public partial class C2G_ArenaMatch_Buy : ProtocolMsgBase, INbsSerializer
    {
        public C2G_ArenaMatch_Buy() { ProtocolId = EProtocolId.C2G_ARENAMATCH_BUY; }
        public C2G_ArenaMatch_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 竞技场次数购买")]
    public partial class G2C_ArenaMatch_Buy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("挑战次数")]
        public int MatchTicks = 0;
        public G2C_ArenaMatch_Buy() { ProtocolId = EProtocolId.G2C_ARENAMATCH_BUY; }
        public G2C_ArenaMatch_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 查看竞技场防守队伍")]
    public partial class C2G_Arena_Defense : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Arena_Defense() { ProtocolId = EProtocolId.C2G_ARENA_DEFENSE; }
        public C2G_Arena_Defense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 查看竞技场防守队伍")]
    public partial class G2C_Arena_Defense : ProtocolMsgBase, INbsSerializer
    {
        [Desc("防守队伍信息<位置，信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictWarriorInfo = new Dictionary<int, CLS_WarriorInfo>();
        public G2C_Arena_Defense() { ProtocolId = EProtocolId.G2C_ARENA_DEFENSE; }
        public G2C_Arena_Defense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 竞技场设置防守队伍")]
    public partial class C2G_Arena_SetDefense : ProtocolMsgBase, INbsSerializer
    {
        [Desc("防守队伍<位置，ID>")]
        public Dictionary<int, long> DictDefenses = new Dictionary<int, long>();
        public C2G_Arena_SetDefense() { ProtocolId = EProtocolId.C2G_ARENA_SETDEFENSE; }
        public C2G_Arena_SetDefense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 竞技场设置防守队伍")]
    public partial class G2C_Arena_SetDefense : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Arena_SetDefense() { ProtocolId = EProtocolId.G2C_ARENA_SETDEFENSE; }
        public G2C_Arena_SetDefense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("长安夺宝信息")]
    public partial class CLS_BankInfo
    {
        [Desc("是否已到活动时间")]
        public bool IsCanFight = false;
        [Desc("是否已经报名")]
        public bool IsSignUp = false;
        [Desc("金币")]
        public long GoldCoin = 0;
        [Desc("每日挑战次数")]
        public int ActiveTick = 0;
        [Desc("总共挑战次数")]
        public int ActiveAllTick = 0;
        [Desc("配置（时间）")]
        public CLS_BankConf bankConf = new CLS_BankConf();
    };
    [Desc("请求 长安夺宝面板")]
    public partial class C2G_Bank_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bank_Info() { ProtocolId = EProtocolId.C2G_BANK_INFO; }
        public C2G_Bank_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝面板")]
    public partial class G2C_Bank_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("长安夺宝信息")]
        public CLS_BankInfo BankInfo = new CLS_BankInfo();
        public G2C_Bank_Info() { ProtocolId = EProtocolId.G2C_BANK_INFO; }
        public G2C_Bank_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝报名")]
    public partial class C2G_Bank_SignIn : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战区")]
        public int WarZone = 0;
        public C2G_Bank_SignIn() { ProtocolId = EProtocolId.C2G_BANK_SIGNIN; }
        public C2G_Bank_SignIn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝报名")]
    public partial class G2C_Bank_SignIn : ProtocolMsgBase, INbsSerializer
    {
        [Desc("长安夺宝信息")]
        public CLS_BankInfo BankInfo = new CLS_BankInfo();
        public G2C_Bank_SignIn() { ProtocolId = EProtocolId.G2C_BANK_SIGNIN; }
        public G2C_Bank_SignIn(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("战区关卡信息")]
    public partial class CLS_WarZoneInfo
    {
        [Desc("配置ID")]
        public int ConfigID = 0;
        [Desc("守军关卡状态")]
        public EBankDefend BankDefend = new EBankDefend();
        [Desc("剩余血量")]
        public long Hp = 0;
        [Desc("剩余士兵血量")]
        public long ArmyHp = 0;
        [Desc("每滴血金币")]
        public float GoldHp = 0.0f;
        [Desc("士兵每滴血金币")]
        public float ArmyGoldHp = 0.0f;
    };
    [Desc("请求 长安夺宝战区信息")]
    public partial class C2G_Bank_WarZone : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bank_WarZone() { ProtocolId = EProtocolId.C2G_BANK_WARZONE; }
        public C2G_Bank_WarZone(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝战区信息")]
    public partial class G2C_Bank_WarZone : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战区信息")]
        public List<CLS_WarZoneInfo> ListWarZone = new List<CLS_WarZoneInfo>();
        [Desc("贡献值")]
        public List<CLS_BankCountryTop> ListContribution = new List<CLS_BankCountryTop>();
        [Desc("自国家")]
        public int CountryId = 0;
        [Desc("贡献奖励领取状态")]
        public List<bool> ListWelfareState = new List<bool>();
        [Desc("次数恢复时间点")]
        public long RecoveryTime = 0;
        [Desc("挑战次数")]
        public long Ticks = 0;
        public G2C_Bank_WarZone() { ProtocolId = EProtocolId.G2C_BANK_WARZONE; }
        public G2C_Bank_WarZone(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝战区领奖")]
    public partial class C2G_Bank_WarZoneAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("领奖ID")]
        public int ConfigID = 0;
        public C2G_Bank_WarZoneAward() { ProtocolId = EProtocolId.C2G_BANK_WARZONEAWARD; }
        public C2G_Bank_WarZoneAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝战区领奖")]
    public partial class G2C_Bank_WarZoneAward : ProtocolMsgBase, INbsSerializer
    {
        [Desc("结算奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        [Desc("贡献奖励领取状态")]
        public List<bool> ListWelfareState = new List<bool>();
        public G2C_Bank_WarZoneAward() { ProtocolId = EProtocolId.G2C_BANK_WARZONEAWARD; }
        public G2C_Bank_WarZoneAward(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝战区战斗")]
    public partial class C2G_Bank_WarZoneFight : ProtocolMsgBase, INbsSerializer
    {
        [Desc("据点ID")]
        public int StrongHold = 0;
        public C2G_Bank_WarZoneFight() { ProtocolId = EProtocolId.C2G_BANK_WARZONEFIGHT; }
        public C2G_Bank_WarZoneFight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝战区战斗")]
    public partial class G2C_Bank_WarZoneFight : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Bank_WarZoneFight() { ProtocolId = EProtocolId.G2C_BANK_WARZONEFIGHT; }
        public G2C_Bank_WarZoneFight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝战区战斗结算")]
    public partial class C2G_Bank_WarZoneBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("造成伤害")]
        public long HurtHp = 0;
        [Desc("造成士兵伤害")]
        public long HurtArmyHp = 0;
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("战斗结果")]
        public int State = 0;
        public C2G_Bank_WarZoneBalance() { ProtocolId = EProtocolId.C2G_BANK_WARZONEBALANCE; }
        public C2G_Bank_WarZoneBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝战区战斗结算")]
    public partial class G2C_Bank_WarZoneBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("结算奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Bank_WarZoneBalance() { ProtocolId = EProtocolId.G2C_BANK_WARZONEBALANCE; }
        public G2C_Bank_WarZoneBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝战区战斗伤害(每秒计算)")]
    public partial class C2G_Bank_WarZoneHurtHp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("造成伤害")]
        public long HurtHp = 0;
        [Desc("战斗Key")]
        public long BattleKey = 0;
        public C2G_Bank_WarZoneHurtHp() { ProtocolId = EProtocolId.C2G_BANK_WARZONEHURTHP; }
        public C2G_Bank_WarZoneHurtHp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝战区战斗伤害")]
    public partial class G2C_Bank_WarZoneHurtHp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("血量")]
        public long Hp = 0;
        public G2C_Bank_WarZoneHurtHp() { ProtocolId = EProtocolId.G2C_BANK_WARZONEHURTHP; }
        public G2C_Bank_WarZoneHurtHp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝清缴匪盗")]
    public partial class C2G_Bank_RobberFight : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bank_RobberFight() { ProtocolId = EProtocolId.C2G_BANK_ROBBERFIGHT; }
        public C2G_Bank_RobberFight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝清缴匪盗")]
    public partial class G2C_Bank_RobberFight : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Bank_RobberFight() { ProtocolId = EProtocolId.G2C_BANK_ROBBERFIGHT; }
        public G2C_Bank_RobberFight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝清缴匪盗结算")]
    public partial class C2G_Bank_RobberBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("战斗结果")]
        public int State = 0;
        public C2G_Bank_RobberBalance() { ProtocolId = EProtocolId.C2G_BANK_ROBBERBALANCE; }
        public C2G_Bank_RobberBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝清缴匪盗结算")]
    public partial class G2C_Bank_RobberBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("结算奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Bank_RobberBalance() { ProtocolId = EProtocolId.G2C_BANK_ROBBERBALANCE; }
        public G2C_Bank_RobberBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("长安夺宝排行")]
    public partial class CLS_BankTop
    {
        [Desc("唯一ID（玩家或者势力）")]
        public long Uid = 0;
        [Desc("伤害")]
        public long HurtHp = 0;
        [Desc("等级")]
        public int Level = 0;
        [Desc("玩家名")]
        public string PlayerName = "";
        [Desc("势力名")]
        public string GuildName = "";
        [Desc("国家")]
        public int Country = 0;
        [Desc("战区")]
        public int WarZone = 0;
    };
    [Desc("请求 长安夺宝排行榜")]
    public partial class C2G_Bank_Top : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战区ID")]
        public int WarZoneID = 0;
        public C2G_Bank_Top() { ProtocolId = EProtocolId.C2G_BANK_TOP; }
        public C2G_Bank_Top(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝排行榜")]
    public partial class G2C_Bank_Top : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战区势力排行数据")]
        public List<CLS_BankTop> ListGuildTop = new List<CLS_BankTop>();
        [Desc("战区个人排行数据")]
        public List<CLS_BankTop> ListPlayerTop = new List<CLS_BankTop>();
        public G2C_Bank_Top() { ProtocolId = EProtocolId.G2C_BANK_TOP; }
        public G2C_Bank_Top(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("长安夺宝国家排行")]
    public partial class CLS_BankCountryTop
    {
        [Desc("国家ID")]
        public int Countryid = 0;
        [Desc("伤害")]
        public long HurtHp = 0;
        [Desc("国家前三名数据")]
        public List<CLS_PlayerData> TopThree = new List<CLS_PlayerData>();
        [Desc("国家个人排行数据")]
        public List<CLS_BankTop> ListPlayerTop = new List<CLS_BankTop>();
    };
    [Desc("请求 长安夺宝国家排行榜")]
    public partial class C2G_Bank_TopCountry : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bank_TopCountry() { ProtocolId = EProtocolId.C2G_BANK_TOPCOUNTRY; }
        public C2G_Bank_TopCountry(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝国家排行榜")]
    public partial class G2C_Bank_TopCountry : ProtocolMsgBase, INbsSerializer
    {
        [Desc("国家排行数据")]
        public List<CLS_BankCountryTop> ListTop = new List<CLS_BankCountryTop>();
        public G2C_Bank_TopCountry() { ProtocolId = EProtocolId.G2C_BANK_TOPCOUNTRY; }
        public G2C_Bank_TopCountry(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("长安夺宝配置")]
    public partial class CLS_BankConf
    {
        [Desc("是否已设置")]
        public bool IsSeted = false;
        [Desc("是否已发送奖励")]
        public bool IsSended = false;
        [Desc("显示金币")]
        public long GoldShow = 0;
        [Desc("金币")]
        public long Gold = 0;
        [Desc("士兵金币")]
        public long ArmyGold = 0;
        [Desc("玩家分配比例（50代表50%）")]
        public int PlayerRatio = 0;
        [Desc("报名时间")]
        public DateTime TimeSignIn = DateTime.Now;
        [Desc("开始时间")]
        public DateTime TimeBegin = DateTime.Now;
        [Desc("结束时间")]
        public DateTime TimeEnd = DateTime.Now;
    };
    [Desc("军务信息")]
    public partial class CLS_Affairs
    {
        [Desc("0-5普通 6每周")]
        public int AffairsIndex = 0;
        [Desc("配置ID")]
        public int configid = 0;
        [Desc("状态:EAffairsState")]
        public int State = 0;
        [Desc("开始时间")]
        public DateTime StartTime = DateTime.Now;
        [Desc("结束时间")]
        public DateTime EndTime = DateTime.Now;
        [Desc("武将职业")]
        public List<int> ListJob = new List<int>();
        [Desc("武将")]
        public List<long> ListWarrior = new List<long>();
    };
    [Desc("请求 获取军务列表")]
    public partial class C2G_Affairs_List : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Affairs_List() { ProtocolId = EProtocolId.C2G_AFFAIRS_LIST; }
        public C2G_Affairs_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 获取军务列表")]
    public partial class G2C_Affairs_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("军务列表")]
        public List<CLS_Affairs> ListAffairs = new List<CLS_Affairs>();
        public G2C_Affairs_List() { ProtocolId = EProtocolId.G2C_AFFAIRS_LIST; }
        public G2C_Affairs_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 开始军务")]
    public partial class C2G_Affairs_Begin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("0-5普通 6每周")]
        public int AffairsIndex = 0;
        [Desc("武将")]
        public List<long> ListWarrior = new List<long>();
        public C2G_Affairs_Begin() { ProtocolId = EProtocolId.C2G_AFFAIRS_BEGIN; }
        public C2G_Affairs_Begin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 开始军务")]
    public partial class G2C_Affairs_Begin : ProtocolMsgBase, INbsSerializer
    {
        [Desc("军务信息")]
        public CLS_Affairs AffairsInfo = new CLS_Affairs();
        public G2C_Affairs_Begin() { ProtocolId = EProtocolId.G2C_AFFAIRS_BEGIN; }
        public G2C_Affairs_Begin(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 军务领奖")]
    public partial class C2G_Affairs_Award : ProtocolMsgBase, INbsSerializer
    {
        [Desc("0-5普通 6每周")]
        public int AffairsIndex = 0;
        public C2G_Affairs_Award() { ProtocolId = EProtocolId.C2G_AFFAIRS_AWARD; }
        public C2G_Affairs_Award(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 军务领奖")]
    public partial class G2C_Affairs_Award : ProtocolMsgBase, INbsSerializer
    {
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        public G2C_Affairs_Award() { ProtocolId = EProtocolId.G2C_AFFAIRS_AWARD; }
        public G2C_Affairs_Award(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知军务完成")]
    public partial class G2C_Affairs_Notify : ProtocolMsgBase, INbsSerializer
    {
        [Desc("刷新军务信息")]
        public CLS_Affairs AffairsInfo = new CLS_Affairs();
        public G2C_Affairs_Notify() { ProtocolId = EProtocolId.G2C_AFFAIRS_NOTIFY; }
        public G2C_Affairs_Notify(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("矿点信息")]
    public partial class CLS_Grab_ArmyInfo
    {
        [Desc("矿点ID")]
        public int Id = 0;
        [Desc("占领者")]
        public long PalyerId = 0;
        [Desc("占领者")]
        public string Name = "";
        [Desc("占领者所属势力")]
        public string GuildName = "";
        [Desc("队伍列表 <位置 武将唯一ID>")]
        public Dictionary<int, long> DictWarrior = new Dictionary<int, long>();
        [Desc("占领时间")]
        public DateTime BeginTime = DateTime.Now;
        [Desc("结束时间")]
        public DateTime EndTime = DateTime.Now;
    };
    [Desc("请求 资源点信息")]
    public partial class C2G_Grab_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("州ID")]
        public int StateId = 0;
        [Desc("资源类型")]
        public int Type = 0;
        public C2G_Grab_List() { ProtocolId = EProtocolId.C2G_GRAB_LIST; }
        public C2G_Grab_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 资源点信息")]
    public partial class G2C_Grab_List : ProtocolMsgBase, INbsSerializer
    {
        [Desc("购买次数")]
        public int Buy = 0;
        [Desc("剩余挑战次数")]
        public int Total = 0;
        public List<CLS_Grab_ArmyInfo> ListItem = new List<CLS_Grab_ArmyInfo>();
        public G2C_Grab_List() { ProtocolId = EProtocolId.G2C_GRAB_LIST; }
        public G2C_Grab_List(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 矿点战斗")]
    public partial class C2G_Grab_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("矿点ID")]
        public int Id = 0;
        public C2G_Grab_Battle() { ProtocolId = EProtocolId.C2G_GRAB_BATTLE; }
        public C2G_Grab_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 矿点战斗")]
    public partial class G2C_Grab_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("对战武将战斗信息列表")]
        public List<CLS_WarriorInfo> ListWarriorOther = new List<CLS_WarriorInfo>();
        public G2C_Grab_Battle() { ProtocolId = EProtocolId.G2C_GRAB_BATTLE; }
        public G2C_Grab_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 占领矿点")]
    public partial class C2G_Grab_Fight : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗ID")]
        public long BattleUid = 0;
        [Desc("战斗结果 攻击方胜利=true 防守方胜利=false")]
        public bool BattleResult = false;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpAtt = new Dictionary<long, int>();
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpDef = new Dictionary<long, int>();
        public C2G_Grab_Fight() { ProtocolId = EProtocolId.C2G_GRAB_FIGHT; }
        public C2G_Grab_Fight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 占领矿点")]
    public partial class G2C_Grab_Fight : ProtocolMsgBase, INbsSerializer
    {
        [Desc("胜利与否")]
        public bool bSuccess = false;
        public G2C_Grab_Fight() { ProtocolId = EProtocolId.G2C_GRAB_FIGHT; }
        public G2C_Grab_Fight(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 查看矿点")]
    public partial class C2G_Grab_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("矿点ID")]
        public int Id = 0;
        public C2G_Grab_Info() { ProtocolId = EProtocolId.C2G_GRAB_INFO; }
        public C2G_Grab_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 查看矿点")]
    public partial class G2C_Grab_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("矿点ID")]
        public int Id = 0;
        [Desc("占领者")]
        public long PalyerId = 0;
        [Desc("占领者")]
        public string Name = "";
        [Desc("占领者所属势力")]
        public string GuildName = "";
        [Desc("防守队伍信息<位置，信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictWarrior = new Dictionary<int, CLS_WarriorInfo>();
        [Desc("结束时间")]
        public DateTime EndTime = DateTime.Now;
        public G2C_Grab_Info() { ProtocolId = EProtocolId.G2C_GRAB_INFO; }
        public G2C_Grab_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 放弃矿点")]
    public partial class C2G_Grab_GiveUp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("矿点ID")]
        public int Id = 0;
        public C2G_Grab_GiveUp() { ProtocolId = EProtocolId.C2G_GRAB_GIVEUP; }
        public C2G_Grab_GiveUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 放弃矿点")]
    public partial class G2C_Grab_GiveUp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("矿点ID")]
        public int Id = 0;
        public G2C_Grab_GiveUp() { ProtocolId = EProtocolId.G2C_GRAB_GIVEUP; }
        public G2C_Grab_GiveUp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 自己的资源点信息")]
    public partial class C2G_Grab_Mine : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Grab_Mine() { ProtocolId = EProtocolId.C2G_GRAB_MINE; }
        public C2G_Grab_Mine(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 自己的资源点信息")]
    public partial class G2C_Grab_Mine : ProtocolMsgBase, INbsSerializer
    {
        public List<CLS_Grab_ArmyInfo> ListItem = new List<CLS_Grab_ArmyInfo>();
        public G2C_Grab_Mine() { ProtocolId = EProtocolId.G2C_GRAB_MINE; }
        public G2C_Grab_Mine(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 购买挑战次数")]
    public partial class C2G_Grab_Buy : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Grab_Buy() { ProtocolId = EProtocolId.C2G_GRAB_BUY; }
        public C2G_Grab_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 购买挑战次数")]
    public partial class G2C_Grab_Buy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("购买次数")]
        public int Buy = 0;
        [Desc("剩余挑战次数")]
        public int Total = 0;
        public G2C_Grab_Buy() { ProtocolId = EProtocolId.G2C_GRAB_BUY; }
        public G2C_Grab_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("匪寇信息单条")]
    public partial class CLS_BanditsArmyInfo
    {
        [Desc("队伍ID")]
        public int Uid = 0;
        [Desc("配置ID")]
        public int ConfigId = 0;
        [Desc("存活")]
        public bool IsAlive = false;
        [Desc("死亡时间")]
        public long TicksDeath = 0;
    };
    [Desc("匪寇信息")]
    public partial class CLS_BanditsInfo
    {
        [Desc("今天购买次数")]
        public int BanditsBuyTimes = 0;
        [Desc("剩余挑战次数")]
        public int BanditsCount = 0;
        [Desc("匪寇列表")]
        public Dictionary<int, CLS_BanditsArmyInfo> DictBandits = new Dictionary<int, CLS_BanditsArmyInfo>();
    };
    [Desc("请求 征讨匪寇信息")]
    public partial class C2G_Bandits_Info : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bandits_Info() { ProtocolId = EProtocolId.C2G_BANDITS_INFO; }
        public C2G_Bandits_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 征讨匪寇信息")]
    public partial class G2C_Bandits_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("征讨匪寇信息")]
        public CLS_BanditsInfo BanditsInfo = new CLS_BanditsInfo();
        public G2C_Bandits_Info() { ProtocolId = EProtocolId.G2C_BANDITS_INFO; }
        public G2C_Bandits_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 征讨匪寇战斗")]
    public partial class C2G_Bandits_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("队伍ID")]
        public int Uid = 0;
        public C2G_Bandits_Battle() { ProtocolId = EProtocolId.C2G_BANDITS_BATTLE; }
        public C2G_Bandits_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 征讨匪寇战斗")]
    public partial class G2C_Bandits_Battle : ProtocolMsgBase, INbsSerializer
    {
        [Desc("队伍ID")]
        public int Uid = 0;
        [Desc("剩余挑战次数")]
        public int BanditsCount = 0;
        public G2C_Bandits_Battle() { ProtocolId = EProtocolId.G2C_BANDITS_BATTLE; }
        public G2C_Bandits_Battle(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 征讨匪寇战斗结束")]
    public partial class C2G_Bandits_BattleEnd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("队伍ID")]
        public int Uid = 0;
        [Desc("战斗Key")]
        public long BattleKey = 0;
        [Desc("战斗结果")]
        public int State = 0;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        public C2G_Bandits_BattleEnd() { ProtocolId = EProtocolId.C2G_BANDITS_BATTLEEND; }
        public C2G_Bandits_BattleEnd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 征讨匪寇战斗结束")]
    public partial class G2C_Bandits_BattleEnd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("队伍ID")]
        public int Uid = 0;
        [Desc("奖励列表")]
        public List<CLS_AwardItem> ListAward = new List<CLS_AwardItem>();
        [Desc("征讨匪寇信息")]
        public CLS_BanditsInfo BanditsInfo = new CLS_BanditsInfo();
        public G2C_Bandits_BattleEnd() { ProtocolId = EProtocolId.G2C_BANDITS_BATTLEEND; }
        public G2C_Bandits_BattleEnd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 购买挑战次数")]
    public partial class C2G_Bandits_Buy : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bandits_Buy() { ProtocolId = EProtocolId.C2G_BANDITS_BUY; }
        public C2G_Bandits_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 购买挑战次数")]
    public partial class G2C_Bandits_Buy : ProtocolMsgBase, INbsSerializer
    {
        [Desc("今天购买次数")]
        public int BanditsBuyTimes = 0;
        [Desc("剩余挑战次数")]
        public int BanditsCount = 0;
        public G2C_Bandits_Buy() { ProtocolId = EProtocolId.G2C_BANDITS_BUY; }
        public G2C_Bandits_Buy(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 购买怪物重置")]
    public partial class C2G_Bandits_Reset : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Bandits_Reset() { ProtocolId = EProtocolId.C2G_BANDITS_RESET; }
        public C2G_Bandits_Reset(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 购买怪物重置")]
    public partial class G2C_Bandits_Reset : ProtocolMsgBase, INbsSerializer
    {
        [Desc("征讨匪寇信息")]
        public CLS_BanditsInfo BanditsInfo = new CLS_BanditsInfo();
        public G2C_Bandits_Reset() { ProtocolId = EProtocolId.G2C_BANDITS_RESET; }
        public G2C_Bandits_Reset(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 补兵")]
    public partial class C2G_Supply_Supply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("k=武将唯一ID v=当前兵数")]
        public Dictionary<long, int> DictWarrior = new Dictionary<long, int>();
        public C2G_Supply_Supply() { ProtocolId = EProtocolId.C2G_SUPPLY_SUPPLY; }
        public C2G_Supply_Supply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 补兵")]
    public partial class G2C_Supply_Supply : ProtocolMsgBase, INbsSerializer
    {
        [Desc("成员列表 <武将信息>")]
        public Dictionary<long, CLS_WarriorInfo> DictWarrior = new Dictionary<long, CLS_WarriorInfo>();
        public G2C_Supply_Supply() { ProtocolId = EProtocolId.G2C_SUPPLY_SUPPLY; }
        public G2C_Supply_Supply(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 一键补兵")]
    public partial class C2G_Supply_SupplyAuto : ProtocolMsgBase, INbsSerializer
    {
        [Desc("k=武将唯一ID")]
        public List<long> ListWarrior = new List<long>();
        public C2G_Supply_SupplyAuto() { ProtocolId = EProtocolId.C2G_SUPPLY_SUPPLYAUTO; }
        public C2G_Supply_SupplyAuto(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 一键补兵")]
    public partial class G2C_Supply_SupplyAuto : ProtocolMsgBase, INbsSerializer
    {
        [Desc("成员列表 <武将信息>")]
        public Dictionary<long, CLS_WarriorInfo> DictWarrior = new Dictionary<long, CLS_WarriorInfo>();
        public G2C_Supply_SupplyAuto() { ProtocolId = EProtocolId.G2C_SUPPLY_SUPPLYAUTO; }
        public G2C_Supply_SupplyAuto(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池战略信息基础")]
    public partial class CLS_StrategyCityInfoBase
    {
        [Desc("所属势力唯一ID(0=无人占领)")]
        public long GuildUid = 0;
        [Desc("所属势力名")]
        public string GuildName = "";
        [Desc("势力所属国家ID")]
        public int CountryId = 0;
        [Desc("归属 EOwnership")]
        public byte Ownership = 0;
        [Desc("倒计时受保护")]
        public TimeSpan TsCooldownProtected = new TimeSpan();
    };
    [Desc("战略城池信息")]
    public partial class CLS_StrategyCityInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("太守Id")]
        public long LeaderPuid = 0;
        [Desc("太守名字")]
        public string LeaderName = "";
        [Desc("繁荣度")]
        public long Prosperity = 0;
        [Desc("城池战略信息基础")]
        public CLS_StrategyCityInfoBase CityInfoBase = new CLS_StrategyCityInfoBase();
        [Desc("城池战略信息大城池")]
        public CLS_StrategyCityInfoMetro CityInfoMetro = new CLS_StrategyCityInfoMetro();
    };
    [Desc("请求 战略地图")]
    public partial class C2G_Strategy_Map : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Strategy_Map() { ProtocolId = EProtocolId.C2G_STRATEGY_MAP; }
        public C2G_Strategy_Map(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 战略地图")]
    public partial class G2C_Strategy_Map : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池列表")]
        public Dictionary<int, CLS_StrategyCityInfo> DictCity = new Dictionary<int, CLS_StrategyCityInfo>();
        [Desc("大城池PVP综合信息")]
        public CLS_MetroPvpInfo MetroPvpInfo = new CLS_MetroPvpInfo();
        [Desc("同盟势力")]
        public List<long> ListAlliance = new List<long>();
        [Desc("我方城池")]
        public List<int> ListGuildCityMy = new List<int>();
        [Desc("同盟城池")]
        public List<int> ListGuildCityAlliance = new List<int>();
        [Desc("征讨匪寇信息")]
        public CLS_BanditsInfo BanditsInfo = new CLS_BanditsInfo();
        public G2C_Strategy_Map() { ProtocolId = EProtocolId.G2C_STRATEGY_MAP; }
        public G2C_Strategy_Map(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池信息")]
    public partial class C2G_Strategy_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int Uid = 0;
        public C2G_Strategy_CityInfo() { ProtocolId = EProtocolId.C2G_STRATEGY_CITYINFO; }
        public C2G_Strategy_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池信息")]
    public partial class G2C_Strategy_CityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池信息")]
        public CLS_StrategyCityInfo CityInfo = new CLS_StrategyCityInfo();
        public G2C_Strategy_CityInfo() { ProtocolId = EProtocolId.G2C_STRATEGY_CITYINFO; }
        public G2C_Strategy_CityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("城池战斗守备营信息")]
    public partial class CLS_StrategyFightCampInfo
    {
        [Desc("唯一ID(1-5)(1=主营)")]
        public int Uid = 0;
        [Desc("城墙耐久")]
        public CLS_CountInfo WallHp = new CLS_CountInfo();
        [Desc("攻击者列表")]
        public List<string> ListLastAttacker = new List<string>();
    };
    [Desc("城池战斗信息")]
    public partial class CLS_StrategyFightInfo
    {
        [Desc("唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("城池战略信息基础")]
        public CLS_StrategyCityInfoBase CityInfoBase = new CLS_StrategyCityInfoBase();
        [Desc("城池战斗守备营信息")]
        public Dictionary<int, CLS_StrategyFightCampInfo> DictCamp = new Dictionary<int, CLS_StrategyFightCampInfo>();
    };
    [Desc("请求 城池战斗信息")]
    public partial class C2G_Strategy_FightInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int Uid = 0;
        public C2G_Strategy_FightInfo() { ProtocolId = EProtocolId.C2G_STRATEGY_FIGHTINFO; }
        public C2G_Strategy_FightInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗信息")]
    public partial class G2C_Strategy_FightInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池战斗信息")]
        public CLS_StrategyFightInfo CityInfo = new CLS_StrategyFightInfo();
        public G2C_Strategy_FightInfo() { ProtocolId = EProtocolId.G2C_STRATEGY_FIGHTINFO; }
        public G2C_Strategy_FightInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城墙血量刷新")]
    public partial class G2C_Strategy_NotifyRefreshWallHp : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池ID")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙耐久")]
        public CLS_CountInfo WallHp = new CLS_CountInfo();
        public G2C_Strategy_NotifyRefreshWallHp() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYREFRESHWALLHP; }
        public G2C_Strategy_NotifyRefreshWallHp(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池信息刷新")]
    public partial class G2C_Strategy_NotifyRefreshCityInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池信息")]
        public CLS_StrategyCityInfo CityInfo = new CLS_StrategyCityInfo();
        public G2C_Strategy_NotifyRefreshCityInfo() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYREFRESHCITYINFO; }
        public G2C_Strategy_NotifyRefreshCityInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池信息刷新多个")]
    public partial class G2C_Strategy_NotifyRefreshCitys : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池列表")]
        public Dictionary<int, CLS_StrategyCityInfo> DictCity = new Dictionary<int, CLS_StrategyCityInfo>();
        public G2C_Strategy_NotifyRefreshCitys() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYREFRESHCITYS; }
        public G2C_Strategy_NotifyRefreshCitys(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池战斗匹配取消")]
    public partial class C2G_Strategy_MatchingCancel : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Strategy_MatchingCancel() { ProtocolId = EProtocolId.C2G_STRATEGY_MATCHINGCANCEL; }
        public C2G_Strategy_MatchingCancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗匹配取消")]
    public partial class G2C_Strategy_MatchingCancel : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Strategy_MatchingCancel() { ProtocolId = EProtocolId.G2C_STRATEGY_MATCHINGCANCEL; }
        public G2C_Strategy_MatchingCancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池战斗防守")]
    public partial class C2G_Strategy_Defense : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        public C2G_Strategy_Defense() { ProtocolId = EProtocolId.C2G_STRATEGY_DEFENSE; }
        public C2G_Strategy_Defense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗防守")]
    public partial class G2C_Strategy_Defense : ProtocolMsgBase, INbsSerializer
    {
        [Desc("匹配开始时间")]
        public DateTime DtMatchingStart = DateTime.Now;
        [Desc("匹配结束时间")]
        public DateTime DtMatchingEnd = DateTime.Now;
        public G2C_Strategy_Defense() { ProtocolId = EProtocolId.G2C_STRATEGY_DEFENSE; }
        public G2C_Strategy_Defense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池战斗进攻")]
    public partial class C2G_Strategy_Attack : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        public C2G_Strategy_Attack() { ProtocolId = EProtocolId.C2G_STRATEGY_ATTACK; }
        public C2G_Strategy_Attack(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗进攻")]
    public partial class G2C_Strategy_Attack : ProtocolMsgBase, INbsSerializer
    {
        [Desc("匹配开始时间")]
        public DateTime DtMatchingStart = DateTime.Now;
        [Desc("匹配结束时间")]
        public DateTime DtMatchingEnd = DateTime.Now;
        public G2C_Strategy_Attack() { ProtocolId = EProtocolId.G2C_STRATEGY_ATTACK; }
        public G2C_Strategy_Attack(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池战斗匹配结束防守")]
    public partial class G2C_Strategy_NotifyMatchingEndDefense : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙血量当前值")]
        public long WallHp = 0;
        [Desc("城墙血量增加值")]
        public long WallHpAdded = 0;
        public G2C_Strategy_NotifyMatchingEndDefense() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGENDDEFENSE; }
        public G2C_Strategy_NotifyMatchingEndDefense(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池战斗匹配攻击NPC")]
    public partial class G2C_Strategy_NotifyMatchingAttackNpc : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("被攻击的NPC信息")]
        public CLS_CampNpc CampNpc = new CLS_CampNpc();
        public G2C_Strategy_NotifyMatchingAttackNpc() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKNPC; }
        public G2C_Strategy_NotifyMatchingAttackNpc(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池战斗匹配攻击城墙")]
    public partial class G2C_Strategy_NotifyMatchingAttackWall : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙等级")]
        public int WallLevel = 0;
        [Desc("城墙耐久")]
        public CLS_CountInfo WallHp = new CLS_CountInfo();
        public G2C_Strategy_NotifyMatchingAttackWall() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKWALL; }
        public G2C_Strategy_NotifyMatchingAttackWall(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("守军NPC兵力")]
    public partial class CLS_CampNpcMonster
    {
        [Desc("ID(位置0-n)")]
        public int MonsterUid = 0;
        [Desc("怪物ID")]
        public int MonsterId = 0;
        [Desc("兵力")]
        public long Hp = 0;
    };
    [Desc("守军NPC")]
    public partial class CLS_CampNpc
    {
        [Desc("ID(1-n)")]
        public int NpcUid = 0;
        [Desc("关卡配置ID")]
        public int StageId = 0;
        [Desc("NPC部队兵力 k=位置0-n")]
        public Dictionary<int, CLS_CampNpcMonster> DictMonster = new Dictionary<int, CLS_CampNpcMonster>();
    };
    [Desc("请求 城池战斗匹配攻击NPC结算")]
    public partial class C2G_Strategy_AttackNpcBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗验证码")]
        public long BattleCode = 0;
        [Desc("战斗结果 EBattleResult")]
        public int BattleResult = 0;
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("ID(1-n)")]
        public int NpcUid = 0;
        [Desc("NPC部队兵力 k=位置0-n")]
        public Dictionary<int, CLS_CampNpcMonster> DictMonster = new Dictionary<int, CLS_CampNpcMonster>();
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        public C2G_Strategy_AttackNpcBalance() { ProtocolId = EProtocolId.C2G_STRATEGY_ATTACKNPCBALANCE; }
        public C2G_Strategy_AttackNpcBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗匹配攻击NPC结算")]
    public partial class G2C_Strategy_AttackNpcBalance : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Strategy_AttackNpcBalance() { ProtocolId = EProtocolId.G2C_STRATEGY_ATTACKNPCBALANCE; }
        public G2C_Strategy_AttackNpcBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池战斗匹配攻击城墙结算")]
    public partial class C2G_Strategy_AttackWallBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗验证码")]
        public long BattleCode = 0;
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("城墙血量损失")]
        public long WallHpDamage = 0;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHp = new Dictionary<long, int>();
        public C2G_Strategy_AttackWallBalance() { ProtocolId = EProtocolId.C2G_STRATEGY_ATTACKWALLBALANCE; }
        public C2G_Strategy_AttackWallBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗匹配攻击城墙结算")]
    public partial class G2C_Strategy_AttackWallBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("首次攻占城池奖励")]
        public List<CLS_AwardItem> ListAwardFirst = new List<CLS_AwardItem>();
        public G2C_Strategy_AttackWallBalance() { ProtocolId = EProtocolId.G2C_STRATEGY_ATTACKWALLBALANCE; }
        public G2C_Strategy_AttackWallBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 城池战斗匹配攻击玩家")]
    public partial class G2C_Strategy_NotifyMatchingAttackPlayer : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战场信息")]
        public CLS_BattleInfo BattleInfo = new CLS_BattleInfo();
        public G2C_Strategy_NotifyMatchingAttackPlayer() { ProtocolId = EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKPLAYER; }
        public G2C_Strategy_NotifyMatchingAttackPlayer(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 城池战斗匹配攻击玩家结算")]
    public partial class C2G_Strategy_AttackPlayerBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗ID")]
        public int BattleUid = 0;
        [Desc("战斗结果 攻击方胜利=true 防守方胜利=false")]
        public bool BattleResult = false;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpAtt = new Dictionary<long, int>();
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpDef = new Dictionary<long, int>();
        public C2G_Strategy_AttackPlayerBalance() { ProtocolId = EProtocolId.C2G_STRATEGY_ATTACKPLAYERBALANCE; }
        public C2G_Strategy_AttackPlayerBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 城池战斗匹配攻击玩家结算")]
    public partial class G2C_Strategy_AttackPlayerBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗ID")]
        public int BattleUid = 0;
        [Desc("k=Puid v=结果 胜利=true 失败=false")]
        public Dictionary<long, bool> DictBattleResult = new Dictionary<long, bool>();
        public G2C_Strategy_AttackPlayerBalance() { ProtocolId = EProtocolId.G2C_STRATEGY_ATTACKPLAYERBALANCE; }
        public G2C_Strategy_AttackPlayerBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("大城池PVP综合信息")]
    public partial class CLS_MetroPvpInfo
    {
        [Desc("大城池PVP综合状态")]
        public EMetroPvpState MetroPvpState = new EMetroPvpState();
        [Desc("开始时间")]
        public DateTime DtMetroPvpStart = DateTime.Now;
        [Desc("结束时间")]
        public DateTime DtMetroPvpEnd = DateTime.Now;
    };
    [Desc("城池战略信息大城池")]
    public partial class CLS_StrategyCityInfoMetro
    {
        [Desc("大城池状态")]
        public EMetroCityStatus MetroCityStatus = new EMetroCityStatus();
        [Desc("倒计时占领")]
        public TimeSpan TsCooldownSeize = new TimeSpan();
    };
    [Desc("通知 大城池PVP综合信息")]
    public partial class G2C_Metro_NotifyRefreshInfo : ProtocolMsgBase, INbsSerializer
    {
        [Desc("大城池PVP综合信息")]
        public CLS_MetroPvpInfo MetroPvpInfo = new CLS_MetroPvpInfo();
        public G2C_Metro_NotifyRefreshInfo() { ProtocolId = EProtocolId.G2C_METRO_NOTIFYREFRESHINFO; }
        public G2C_Metro_NotifyRefreshInfo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("积分榜单条")]
    public partial class CLS_MetroTopScoreNode
    {
        [Desc("排名")]
        public int Rank = 0;
        [Desc("势力唯一ID")]
        public long GuildUid = 0;
        [Desc("势力名")]
        public string GuildName = "";
        [Desc("积分")]
        public long Score = 0;
    };
    [Desc("请求 郡城势力积分榜")]
    public partial class C2G_Metro_TopScore : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int Uid = 0;
        public C2G_Metro_TopScore() { ProtocolId = EProtocolId.C2G_METRO_TOPSCORE; }
        public C2G_Metro_TopScore(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 郡城势力积分榜")]
    public partial class G2C_Metro_TopScore : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int Uid = 0;
        [Desc("自己")]
        public CLS_MetroTopScoreNode ScoreMy = new CLS_MetroTopScoreNode();
        [Desc("前十")]
        public List<CLS_MetroTopScoreNode> ListScore = new List<CLS_MetroTopScoreNode>();
        public G2C_Metro_TopScore() { ProtocolId = EProtocolId.G2C_METRO_TOPSCORE; }
        public G2C_Metro_TopScore(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 郡城匹配")]
    public partial class C2G_Metro_Matching : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        public C2G_Metro_Matching() { ProtocolId = EProtocolId.C2G_METRO_MATCHING; }
        public C2G_Metro_Matching(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 郡城匹配")]
    public partial class G2C_Metro_Matching : ProtocolMsgBase, INbsSerializer
    {
        [Desc("匹配开始时间")]
        public DateTime DtMatchingStart = DateTime.Now;
        [Desc("匹配结束时间")]
        public DateTime DtMatchingEnd = DateTime.Now;
        public G2C_Metro_Matching() { ProtocolId = EProtocolId.G2C_METRO_MATCHING; }
        public G2C_Metro_Matching(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 郡城匹配取消")]
    public partial class C2G_Metro_MatchingCancel : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Metro_MatchingCancel() { ProtocolId = EProtocolId.C2G_METRO_MATCHINGCANCEL; }
        public C2G_Metro_MatchingCancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 郡城匹配取消")]
    public partial class G2C_Metro_MatchingCancel : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Metro_MatchingCancel() { ProtocolId = EProtocolId.G2C_METRO_MATCHINGCANCEL; }
        public G2C_Metro_MatchingCancel(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 郡城匹配结束")]
    public partial class G2C_Metro_NotifyMatchingEnd : ProtocolMsgBase, INbsSerializer
    {
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        public G2C_Metro_NotifyMatchingEnd() { ProtocolId = EProtocolId.G2C_METRO_NOTIFYMATCHINGEND; }
        public G2C_Metro_NotifyMatchingEnd(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 郡城匹配成功")]
    public partial class G2C_Metro_NotifyMatchingMetro : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战场信息")]
        public CLS_BattleInfo BattleInfo = new CLS_BattleInfo();
        public G2C_Metro_NotifyMatchingMetro() { ProtocolId = EProtocolId.G2C_METRO_NOTIFYMATCHINGMETRO; }
        public G2C_Metro_NotifyMatchingMetro(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 郡城战斗结算")]
    public partial class C2G_Metro_AttackPlayerBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗ID")]
        public int BattleUid = 0;
        [Desc("战斗结果 攻击方胜利=true 防守方胜利=false")]
        public bool BattleResult = false;
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpAtt = new Dictionary<long, int>();
        [Desc("武将消耗兵力")]
        public Dictionary<long, int> DictExpendHpDef = new Dictionary<long, int>();
        public C2G_Metro_AttackPlayerBalance() { ProtocolId = EProtocolId.C2G_METRO_ATTACKPLAYERBALANCE; }
        public C2G_Metro_AttackPlayerBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 郡城战斗结算")]
    public partial class G2C_Metro_AttackPlayerBalance : ProtocolMsgBase, INbsSerializer
    {
        [Desc("战斗ID")]
        public int BattleUid = 0;
        [Desc("k=Puid v=结果 胜利=true 失败=false")]
        public Dictionary<long, bool> DictBattleResult = new Dictionary<long, bool>();
        public G2C_Metro_AttackPlayerBalance() { ProtocolId = EProtocolId.G2C_METRO_ATTACKPLAYERBALANCE; }
        public G2C_Metro_AttackPlayerBalance(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("即时对战玩家信息")]
    public partial class CLS_BattlePlayer
    {
        [Desc("玩家唯一ID")]
        public long Puid = 0;
        [Desc("玩家昵称")]
        public string Name = "";
        [Desc("已准备")]
        public bool IsReady = false;
        [Desc("成员列表 <位置 武将战斗信息>")]
        public Dictionary<int, CLS_WarriorInfo> DictWarrior = new Dictionary<int, CLS_WarriorInfo>();
    };
    [Desc("战场信息")]
    public partial class CLS_BattleInfo
    {
        [Desc("战斗ID")]
        public int BattleUid = 0;
        [Desc("战场类型")]
        public EBattleType BattleType = new EBattleType();
        [Desc("已准备全部")]
        public bool IsReadyAll = false;
        [Desc("城池唯一ID(配置ID)")]
        public int CityUid = 0;
        [Desc("唯一ID(1-5)(1=主营)")]
        public int CampUid = 0;
        [Desc("攻击方")]
        public CLS_BattlePlayer BattlePlayerAtt = new CLS_BattlePlayer();
        [Desc("防守方")]
        public CLS_BattlePlayer BattlePlayerDef = new CLS_BattlePlayer();
    };
    [Desc("请求 测试")]
    public partial class C2G_Battle_Demo : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Battle_Demo() { ProtocolId = EProtocolId.C2G_BATTLE_DEMO; }
        public C2G_Battle_Demo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 测试")]
    public partial class G2C_Battle_Demo : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Battle_Demo() { ProtocolId = EProtocolId.G2C_BATTLE_DEMO; }
        public G2C_Battle_Demo(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 准备")]
    public partial class C2G_Battle_Ready : ProtocolMsgBase, INbsSerializer
    {
        public C2G_Battle_Ready() { ProtocolId = EProtocolId.C2G_BATTLE_READY; }
        public C2G_Battle_Ready(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 准备")]
    public partial class G2C_Battle_Ready : ProtocolMsgBase, INbsSerializer
    {
        public G2C_Battle_Ready() { ProtocolId = EProtocolId.G2C_BATTLE_READY; }
        public G2C_Battle_Ready(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("通知 准备状态")]
    public partial class G2C_Battle_NotifyReady : ProtocolMsgBase, INbsSerializer
    {
        [Desc("已准备全部")]
        public bool IsReadyAll = false;
        public G2C_Battle_NotifyReady() { ProtocolId = EProtocolId.G2C_BATTLE_NOTIFYREADY; }
        public G2C_Battle_NotifyReady(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("转发数据")]
    public partial class CLS_ForwardData
    {
        [Desc("状态类型")]
        public short Status = 0;
        [Desc("状态数据")]
        public Dictionary<string, string> DictStatusData = new Dictionary<string, string>();
        [Desc("操作类型")]
        public short Action = 0;
        [Desc("操作数据")]
        public Dictionary<string, string> DictActionData = new Dictionary<string, string>();
    };
    [Desc("请求 转发数据")]
    public partial class C2G_Battle_ForwardData : ProtocolMsgBase, INbsSerializer
    {
        [Desc("武将唯一ID")]
        public long WarriorUid = 0;
        [Desc("转发数据")]
        public CLS_ForwardData ForwardData = new CLS_ForwardData();
        public C2G_Battle_ForwardData() { ProtocolId = EProtocolId.C2G_BATTLE_FORWARDDATA; }
        public C2G_Battle_ForwardData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 转发数据")]
    public partial class G2C_Battle_ForwardData : ProtocolMsgBase, INbsSerializer
    {
        [Desc("玩家唯一ID")]
        public long PlayerId = 0;
        [Desc("武将唯一ID")]
        public long WarriorUid = 0;
        [Desc("转发数据")]
        public CLS_ForwardData ForwardData = new CLS_ForwardData();
        public G2C_Battle_ForwardData() { ProtocolId = EProtocolId.G2C_BATTLE_FORWARDDATA; }
        public G2C_Battle_ForwardData(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("集群服务器发送负载给中心服务器")]
    public partial class G2A_Load_SetLoad : ProtocolMsgBase, INbsSerializer
    {
        [Desc("服务器ID")]
        public int Id = 0;
        [Desc("服务器IP地址")]
        public string Ip = "";
        [Desc("服务器类型")]
        public short LinkType = 0;
        [Desc("服务器名字")]
        public string Name = "";
        [Desc("负载人数")]
        public int Load = 0;
        [Desc("进程ID")]
        public int ProcessID = 0;
        [Desc("使用CPU")]
        public float Cpu = 0.0f;
        [Desc("使用内存")]
        public long Memory = 0;
        [Desc("使用线程")]
        public int Threads = 0;
        public G2A_Load_SetLoad() { ProtocolId = EProtocolId.G2A_LOAD_SETLOAD; }
        public G2A_Load_SetLoad(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("集群服务器发送负载给中心服务器")]
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
    [Desc("请求 邮件列表")]
    public partial class T2B_Mail_GlobalList : ProtocolMsgBase, INbsSerializer
    {
        public T2B_Mail_GlobalList() { ProtocolId = EProtocolId.T2B_MAIL_GLOBALLIST; }
        public T2B_Mail_GlobalList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 邮件列表")]
    public partial class B2T_Mail_GlobalList : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件列表")]
        public List<CLS_MailInfoDetails> ListMail = new List<CLS_MailInfoDetails>();
        public B2T_Mail_GlobalList() { ProtocolId = EProtocolId.B2T_MAIL_GLOBALLIST; }
        public B2T_Mail_GlobalList(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("GM给玩家发送邮件信息")]
    public partial class CLS_GmMailInfo
    {
        [Desc("邮件ID")]
        public long Id = 0;
        public short TargetType = 0;
        [Desc("接收者列表")]
        public List<string> ListTarget = new List<string>();
        [Desc("标题")]
        public string Title = "";
        [Desc("正文")]
        public string Body = "";
        [Desc("邮件发送者")]
        public string SenderName = "";
        [Desc("附件列表")]
        public List<CLS_AwardItem> ListAttachments = new List<CLS_AwardItem>();
    };
    [Desc("请求 GM给玩家发送邮件")]
    public partial class B2T_GmMail_Send : ProtocolMsgBase, INbsSerializer
    {
        [Desc("邮件信息")]
        public CLS_GmMailInfo MailInfo = new CLS_GmMailInfo();
        public B2T_GmMail_Send() { ProtocolId = EProtocolId.B2T_GMMAIL_SEND; }
        public B2T_GmMail_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 GM给玩家发送邮件")]
    public partial class T2B_GmMail_Send : ProtocolMsgBase, INbsSerializer
    {
        [Desc("错误字符串")]
        public string Msg = "";
        public T2B_GmMail_Send() { ProtocolId = EProtocolId.T2B_GMMAIL_SEND; }
        public T2B_GmMail_Send(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("发送 修改玩家数据")]
    public partial class B2T_Edit_Player : ProtocolMsgBase, INbsSerializer
    {
        public string IdType = "";
        public string Id = "";
        public string Mode = "";
        public string Arg = "";
        public B2T_Edit_Player() { ProtocolId = EProtocolId.B2T_EDIT_PLAYER; }
        public B2T_Edit_Player(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 修改玩家数据")]
    public partial class T2B_Edit_Player : ProtocolMsgBase, INbsSerializer
    {
        [Desc("错误字符串")]
        public string Msg = "";
        public T2B_Edit_Player() { ProtocolId = EProtocolId.T2B_EDIT_PLAYER; }
        public T2B_Edit_Player(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝配置")]
    public partial class B2T_Bank_Conf : ProtocolMsgBase, INbsSerializer
    {
        [Desc("配置 （根据IsSeted判断是查看还是设置）")]
        public CLS_BankConf BankConf = new CLS_BankConf();
        public B2T_Bank_Conf() { ProtocolId = EProtocolId.B2T_BANK_CONF; }
        public B2T_Bank_Conf(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝配置")]
    public partial class T2B_Bank_Conf : ProtocolMsgBase, INbsSerializer
    {
        [Desc("配置")]
        public CLS_BankConf BankConf = new CLS_BankConf();
        public T2B_Bank_Conf() { ProtocolId = EProtocolId.T2B_BANK_CONF; }
        public T2B_Bank_Conf(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("请求 长安夺宝详情")]
    public partial class B2T_Bank_Info : ProtocolMsgBase, INbsSerializer
    {
        public B2T_Bank_Info() { ProtocolId = EProtocolId.B2T_BANK_INFO; }
        public B2T_Bank_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝详情")]
    public partial class T2B_Bank_Info : ProtocolMsgBase, INbsSerializer
    {
        [Desc("详情")]
        public List<CLS_WarZoneInfo> Infos = new List<CLS_WarZoneInfo>();
        public T2B_Bank_Info() { ProtocolId = EProtocolId.T2B_BANK_INFO; }
        public T2B_Bank_Info(byte[] buffer) { Unserialize(buffer); }
    };
    [Desc("返回 长安夺宝详情")]
    public partial class B2T_GM_End : ProtocolMsgBase, INbsSerializer
    {
        public B2T_GM_End() { ProtocolId = EProtocolId.B2T_GM_END; }
        public B2T_GM_End(byte[] buffer) { Unserialize(buffer); }
    };

}

