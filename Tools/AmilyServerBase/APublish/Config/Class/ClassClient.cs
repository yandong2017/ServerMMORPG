using System.Collections.Generic;

public class ConfigLanguage
{
	public readonly string Id;
	public readonly string Ch;
	public readonly string En;
	public readonly string r;
	public readonly string e;
	public readonly string f;
	public readonly string d;
	public readonly string p;
	public readonly string x;
	public readonly string a;
}
public class ConfigBag
{
	public readonly int Id;
	public readonly string Name;
	public readonly string Desc;
	public readonly int TypeBag;
}
public class ConfigDrop
{
	public readonly int Id;
	public readonly int DropType;
}
public class ConfigDropLimit
{
	public readonly int Id;
}
public class GlobalConfig
{
	public readonly int Id;
	public readonly string Name;
	public readonly string Desc;
	public readonly string Value;
}
public class ConfigExp
{
	public readonly int Id;
	public readonly int BreakLevel;
	public readonly int Level;
	public readonly string ExpCost;
	public readonly int PowerGrow;
}
public class ConfigBreak
{
	public readonly int Id;
	public readonly int BreakPower;
	public readonly int LevelMax;
	public readonly int AfterLevel;
	public readonly string ItemCost;
}
public class ConfigForge
{
	public readonly int Id;
	public readonly string ItemCost;
	public readonly int PowerPer;
}
public class ConfigReforgeCost
{
	public readonly int Id;
	public readonly int LevelNeed;
	public readonly string ItemCost;
}
public class ConfigStarCost
{
	public readonly int Id;
	public readonly int Quality;
	public readonly int StarLevel;
	public readonly string ItemCost;
	public readonly string Decomposed;
}
public class ConfigHelp
{
	public readonly int Id;
	public readonly string Title;
	public readonly string Desc;
}
public class ConfigDraw
{
	public readonly int Id;
	public readonly string Name;
	public readonly string Desc1;
	public readonly string Desc2;
	public readonly string OneCost;
	public readonly string OneItemCost;
	public readonly string TenCost;
	public readonly string TenItemCost;
	public readonly string OneAward;
	public readonly string TenAward;
	public readonly int PoolType;
}
public class ConfigDrawPool
{
	public readonly int Id;
	public readonly int PoolType;
	public readonly int Weight;
	public readonly int MultipleWeight;
	public readonly string Award;
}
public class ConfigItem
{
	public readonly int Id;
	public readonly string Name;
	public readonly string Icon;
	public readonly string Intr;
	public readonly int Quality;
	public readonly string ItemType;
	public readonly int BagLabel;
	public readonly int MaxOwn;
	public readonly int CanSell;
	public readonly int SellPrice;
	public readonly int CanUse;
	public readonly int CanUseBatch;
	public readonly int UseEffect;
	public readonly int UseEffectArgs;
	public readonly int CompoundNumber;
	public readonly int CompoundHero;
	public readonly int DayUseLimit;
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
