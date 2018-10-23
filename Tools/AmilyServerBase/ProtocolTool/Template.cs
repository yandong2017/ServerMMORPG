namespace ProtocolTool
{
    partial class Program
    {
        //Enum
        public static readonly string Filepath_Enum = @"ProtocolEnum.cs";

        public static readonly string Template_Enum = @"
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
$Enum$
}

";

        //ClassId
        public static readonly string Filepath_ClassId = @"ProtocolId.cs";

        public static readonly string Template_ClassId = @"
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    public enum EProtocolId : short
    {
        UNKNOWN_TYPE = 0,

$ClassId$
    }
}

";

        //ClassBase
        public static readonly string Filepath_ClassBase = @"ProtocolClass.cs";

        public static readonly string Template_ClassBase = @"
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
$Class$
}

";

        //ClassSerialization
        public static readonly string Filepath_ClassSerialization = @"ProtocolSerialization.cs";

        public static readonly string Template_ClassSerialization = @"
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
$Class$
}

";

        //ClassDump
        public static readonly string Filepath_ClassDump = @"ProtocolDump.cs";

        public static readonly string Template_ClassDump = @"
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System.Text;

namespace ServerBase.Protocol
{
    public static class ProtocolDump
    {
        public static ProtocolMsgBase Dump(EProtocolId id, byte[] buffer)
        {            
            switch (id)
            {
$Class$
                default:
                    return null;
            }            
        }
    }
}

";


    }
}