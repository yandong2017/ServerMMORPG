using System.Collections.Generic;

using XLua;

[CSharpCallLua]
public interface ConfigLanguage
{
	string Id { get; }
	string Ch { get; }
	string En { get; }
	string r { get; }
	string e { get; }
	string f { get; }
	string d { get; }
	string p { get; }
	string x { get; }
	string a { get; }
}
[CSharpCallLua]
public interface ConfigBag
{
	int Id { get; }
	string Name { get; }
	string Desc { get; }
	int TypeBag { get; }
}
[CSharpCallLua]
public interface ConfigDrop
{
	int Id { get; }
	int DropType { get; }
}
[CSharpCallLua]
public interface ConfigDropLimit
{
	int Id { get; }
}
[CSharpCallLua]
public interface GlobalConfig
{
	int Id { get; }
	string Name { get; }
	string Desc { get; }
	string Value { get; }
}
[CSharpCallLua]
public interface ConfigExp
{
	int Id { get; }
	int BreakLevel { get; }
	int Level { get; }
	string ExpCost { get; }
	int PowerGrow { get; }
}
[CSharpCallLua]
public interface ConfigBreak
{
	int Id { get; }
	int BreakPower { get; }
	int LevelMax { get; }
	int AfterLevel { get; }
	string ItemCost { get; }
}
[CSharpCallLua]
public interface ConfigForge
{
	int Id { get; }
	string ItemCost { get; }
	int PowerPer { get; }
}
[CSharpCallLua]
public interface ConfigReforgeCost
{
	int Id { get; }
	int LevelNeed { get; }
	string ItemCost { get; }
}
[CSharpCallLua]
public interface ConfigStarCost
{
	int Id { get; }
	int Quality { get; }
	int StarLevel { get; }
	string ItemCost { get; }
	string Decomposed { get; }
}
[CSharpCallLua]
public interface ConfigHelp
{
	int Id { get; }
	string Title { get; }
	string Desc { get; }
}
[CSharpCallLua]
public interface ConfigDraw
{
	int Id { get; }
	string Name { get; }
	string Desc1 { get; }
	string Desc2 { get; }
	string OneCost { get; }
	string OneItemCost { get; }
	string TenCost { get; }
	string TenItemCost { get; }
	string OneAward { get; }
	string TenAward { get; }
	int PoolType { get; }
}
[CSharpCallLua]
public interface ConfigDrawPool
{
	int Id { get; }
	int PoolType { get; }
	int Weight { get; }
	int MultipleWeight { get; }
	string Award { get; }
}
[CSharpCallLua]
public interface ConfigItem
{
	int Id { get; }
	string Name { get; }
	string Icon { get; }
	string Intr { get; }
	int Quality { get; }
	string ItemType { get; }
	int BagLabel { get; }
	int MaxOwn { get; }
	int CanSell { get; }
	int SellPrice { get; }
	int CanUse { get; }
	int CanUseBatch { get; }
	int UseEffect { get; }
	int UseEffectArgs { get; }
	int CompoundNumber { get; }
	int CompoundHero { get; }
	int DayUseLimit { get; }
}
public enum EServerType
{
	客户端 = 0,
	中心 = 1,
	世界 = 2,
	社交 = 3,
	平台 = 4,
	登陆 = 10,
	游戏 = 20,
	战斗 = 30,
	HTTP = 31,
	后台工具 = 100,
}
public enum EAccess
{
	本机调试 = 0,
	内网版本 = 1,
	外网版本 = 2,
}
public enum EAwardType
{
	经验 = 1,
	银两 = 2,
	元宝 = 3,
	木材 = 4,
	食物 = 5,
	铁矿 = 6,
	道具 = 7,
	武将 = 10,
	VIP经验 = 11,
}
public enum EDropType
{
	固定掉落 = 0,
	独立掉落 = 1,
	抽取放回 = 2,
	抽取不放回 = 3,
}
public enum EGlobalId
{
	账号长度最小 = 1,
	账号长度最大 = 2,
	密码长度最小 = 3,
	密码长度最大 = 4,
	昵称长度最小 = 5,
	昵称长度最大 = 6,
	默认英雄列表 = 8,
	最大突破等级 = 10,
	最大星级 = 11,
	最大重铸等级 = 12,
	防御系数 = 14,
	闪避系数 = 15,
	王者系数 = 16,
	普攻系数1 = 17,
	普攻系数2 = 18,
	先攻增加暴击伤害系数 = 19,
	闪避增加恢复效果系数 = 20,
	最小伤害值 = 21,
	抽卡积分上限 = 23,
	抽卡积分赠送道具 = 24,
}
