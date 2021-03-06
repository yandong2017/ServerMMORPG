using System.Collections.Generic;
using UtilLib;

namespace ServerBase.Config
{
	public static partial class Conf
	{
		//文本
		public static Dictionary<string, ConfigLanguage> ConfLanguage = new Dictionary<string, ConfigLanguage>();
		//背包
		public static Dictionary<int, ConfigBag> ConfBag = new Dictionary<int, ConfigBag>();
		//掉落
		public static Dictionary<int, ConfigDrop> ConfDrop = new Dictionary<int, ConfigDrop>();
		//掉落限制
		public static Dictionary<int, ConfigDropLimit> ConfDropLimit = new Dictionary<int, ConfigDropLimit>();
		//GlobalConfig
		public static Dictionary<int, GlobalConfig> GlobalConf = new Dictionary<int, GlobalConfig>();
		//经验
		public static Dictionary<int, ConfigExp> ConfExp = new Dictionary<int, ConfigExp>();
		//突破
		public static Dictionary<int, ConfigBreak> ConfBreak = new Dictionary<int, ConfigBreak>();
		//铸造
		public static Dictionary<int, ConfigForge> ConfForge = new Dictionary<int, ConfigForge>();
		//重铸消耗
		public static Dictionary<int, ConfigReforgeCost> ConfReforgeCost = new Dictionary<int, ConfigReforgeCost>();
		//升星消耗
		public static Dictionary<int, ConfigStarCost> ConfStarCost = new Dictionary<int, ConfigStarCost>();
		//返回码带多语言
		public static Dictionary<int, ConfigResultCode> ConfResultCode = new Dictionary<int, ConfigResultCode>();
		//姓
		public static Dictionary<string, ConfigSurname> ConfSurname = new Dictionary<string, ConfigSurname>();
		//男名
		public static Dictionary<string, ConfigMalename> ConfMalename = new Dictionary<string, ConfigMalename>();
		//女名
		public static Dictionary<string, ConfigFemalename> ConfFemalename = new Dictionary<string, ConfigFemalename>();
		//屏蔽字
		public static Dictionary<string, ConfigBadwords> ConfBadwords = new Dictionary<string, ConfigBadwords>();
		//英雄
		public static Dictionary<int, ConfigHero> ConfHero = new Dictionary<int, ConfigHero>();
	}
}
