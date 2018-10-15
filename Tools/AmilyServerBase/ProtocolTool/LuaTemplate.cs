namespace ProtocolTool
{
    partial class Program
    {
        //Enum
        public static readonly string Filepath_EnumLua = @"LuaProtocolEnum.lua";

        public static readonly string Template_EnumLua = @"
-- 游戏协议枚举

$Enum$


";

        //ClassId
        public static readonly string Filepath_ClassIdLua = @"LuaProtocolId.lua";

        public static readonly string Template_ClassIdLua = @"
-- 协议号

LuaProtocolId =
{
$ClassId$
}

";

        //ClassBase
        public static readonly string Filepath_ClassLua = @"LuaProtocolClass.lua";

        public static readonly string Template_ClassLua =
@"require(""Net/LuaProtocolId"")
require(""Net/LuaProtocolEnum"")
require(""Base/Class"")
require(""Base/DataStructure"")

local Base = require ""Base/ProtocolMsgBase""

-- 对前端而言
-- 发送消息只需要 Serialize
-- 接收消息只需要 Unserialize

$Class$

";

    }
}