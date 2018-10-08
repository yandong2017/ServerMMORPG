using System.Collections.Generic;
using UtilLib;

namespace ServerBase.Config
{
	public static partial class Conf
	{
		//服务器列表	//文件 F_服务器配置.xlsx
		public static Dictionary<int, SysServerList> SysServerList = new Dictionary<int, SysServerList>();
		//GlobalConfig	//文件 Q_全局常数.xlsx
		public static Dictionary<int, GlobalConfig> GlobalConf = new Dictionary<int, GlobalConfig>();
	}
}
