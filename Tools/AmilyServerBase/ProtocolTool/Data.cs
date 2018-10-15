using System.Collections.Generic;

namespace ProtocolTool
{
    partial class Program
    {
        //常量
        public static readonly string[] strSeparators1 = { "@", "//" };

        public static readonly string[] strSeparators2 = { ":", ";" };

        public enum EBodyType
        {
            eBodyTypeEnum = 1,
            eBodyTypeClass = 2,
        }

        //全局变量
        //行数
        public static int LineCount = 0;

        //行内容
        public static string LineText = "";

        //当前模块1
        public static string MMode1 = "";
        //当前模块2
        public static string MMode2 = "";

        //当前结构注释
        public static string ClassDesc = "";

        //当前行注释
        public static string LineDesc = "";

        //当前行结构
        public static List<string> LineContect = new List<string>();

        //当前正文类型
        public static EBodyType BodyType = EBodyType.eBodyTypeEnum;

        //枚举
        //当前类协议ID号
        public static int CEnumId = 0;
        //枚举结构
        public class CEnum
        {
            public CEnum(string name, string desc)
            {
                Name = name;
                Desc = desc;
            }

            public class Node
            {
                public int Line = 0;
                public string Body = "";
                public int Value = -100000;
                public string Desc = "";
            }

            public string Name = "";
            public string Desc = "";
            public Dictionary<int, Node> DictBody = new Dictionary<int, Node>();
        }

        //枚举列表
        public static Dictionary<string, CEnum> DictEnum = new Dictionary<string, CEnum>();

        //当前枚举
        public static CEnum EnumCurrent;

        //类
        //当前类协议ID号
        public static int ClassId = 0;
        //类成员结构
        public class CClassNode
        {
            public int Line = 0;
            public string Ctype = "";
            public string Ctype1 = "";
            public string Ctype2 = "";
            public string Body = "";
            public string Desc = "";
        }

        //类结构
        public class CClass
        {
            public CClass(int classtype, string name, string desc, int id = -100000)
            {
                ClassType = classtype;
                Name = name;
                NameId = Name.ToUpper();
                if (id == -100000)
                {
                    ClassId ++;
                    Id = ClassId;
                }
                else
                {
                    ClassId = id;
                    Id = ClassId;
                }
                Desc = desc;
                Mode1 = MMode1;
                Mode2 = MMode2;

                if (true)
                {
                    try
                    {
                        var listtxt = new List<string>();
                        StrTo(Name, ref listtxt, "_");
                        EventName = $"On{listtxt[1]}{listtxt[2]}";
                    }
                    catch { }
                }
            }

            public int ClassType = 0; // 0=消息 1=公共结构体
            public string Name = "";
            public string NameId = "";
            public int Id = -100000;
            public string Desc = "";
            public string Mode1 = "";
            public string Mode2 = "";
            public string EventName = "";//事件方法名
            public Dictionary<int, CClassNode> DictBody = new Dictionary<int, CClassNode>();
        }

        //类列表
        public static Dictionary<string, CClass> DictClass = new Dictionary<string, CClass>();

        //当前类
        public static CClass ClassCurrent;
    }
}