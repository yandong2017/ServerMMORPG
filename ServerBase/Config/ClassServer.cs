using System.Collections.Generic;

namespace ServerBase.Config
{
	public class SysServerList : IConfigBase	//文件 F_服务器配置.xlsx
	{
		public int Id; //ID
		public int ServerType; //服务器类型
		public string Desc; //描述
		public string ServerTransit; //服务器互联地址
		public string ServerExternal; //服务器对外地址
		public object GetKey() { return Id; }
	}
	public class GlobalConfig : IConfigBase	//文件 Q_全局常数.xlsx
	{
		public int GlobalId; //ID
		public string Value; //配置值
		public object GetKey() { return GlobalId; }
	}
	public enum EServerType
	{
		客户端 = 0,
		网关 = 1,
		世界 = 2,
		登陆 = 3,
		游戏 = 4,
		数据中心 = 5,
		后台工具 = 6,
	}
	public enum EAccess
	{
		本机调试 = 0,
		内网版本 = 1,
		外网版本 = 2,
	}
	public enum EMoneyType
	{
		游戏币 = 1,
	}
	public enum EQuality
	{
		普通 = 1,
		优秀 = 2,
		稀有 = 3,
		史诗 = 4,
		传奇 = 5,
	}
	public enum EGlobalId
	{
		账号长度最小 = 1,
		账号长度最大 = 2,
		密码长度最小 = 3,
		密码长度最大 = 4,
		昵称长度最小 = 5,
		昵称长度最大 = 6,
		玩家初始等级 = 8,
		玩家初始银币 = 9,
	}
}
