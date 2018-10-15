using System.IO;
using System.Text;
using System;

namespace ProtocolTool
{
    partial class Program
    {
        /// <summary>
        /// 生成枚举表文件
        /// </summary>
        private static void ProtocolConverterEnum()
        {
            Show("ProtocolConverterEnum");
            var sb = new StringBuilder();

            foreach (var kvp in DictEnum)
            {
                if (kvp.Value.Desc != "")
                {
                    //sb.Append("    /// <summary>\r\n");
                    //sb.Append($"    /// {kvp.Value.Desc}\r\n");
                    //sb.Append("    /// <summary>\r\n");
                    sb.Append($"    [Desc(\"{kvp.Value.Desc}\")]\r\n");
                }
                sb.Append($"    public enum {kvp.Value.Name}\r\n");
                sb.Append("    {\r\n");
                foreach (var kvp2 in kvp.Value.DictBody)
                {
                    if (kvp2.Value.Desc != "")
                    {
                        //sb.Append("        /// <summary>\r\n");
                        //sb.Append($"        /// {kvp2.Value.Desc}\r\n");
                        //sb.Append("        /// <summary>\r\n");
                        sb.Append($"        [Desc(\"{kvp2.Value.Desc}\")]\r\n");
                    }
                    sb.Append($"        {kvp2.Value.Body}");
                    if (kvp2.Value.Value != -100000)
                    {
                        sb.Append($" = {kvp2.Value.Value}");
                    }
                    sb.Append(",\r\n");
                }
                sb.Append("    };\r\n\r\n");
            }
            string txt = Template_Enum;
            FileStream fs = new FileStream(PathCurrent + Filepath_Enum, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            txt = txt.Replace("$Enum$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_Enum);
        }

        /// <summary>
        /// 生成协议号文件
        /// </summary>
        private static void ProtocolConverterClassId()
        {
            Show("ProtocolConverterClassId");
            var sb = new StringBuilder();

            foreach (var nn in DictClass.Values)
            {
                if (nn.ClassType != 0)
                {
                    continue;
                }
                if (nn.Id != -100000)
                {
                    sb.Append($"        // {nn.Name} - {nn.EventName}\r\n");
                    sb.Append($"        {nn.NameId + " = " + nn.Id + ", "}\r\n");
                }
                else
                {
                    sb.Append($"        // {nn.Name} - {nn.EventName}\r\n");
                    sb.Append($"        {nn.NameId + ",  "}\r\n");
                }
            }
            string txt = Template_ClassId;
            FileStream fs = new FileStream(PathCurrent + Filepath_ClassId, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            txt = txt.Replace("$ClassId$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_ClassId);
        }

        /// <summary>
        /// 生成结构体文件
        /// </summary>
        private static void ProtocolConverterClassBase()
        {
            Show("ProtocolConverterClassBase");
            var sb = new StringBuilder();

            foreach (var kvp in DictClass)
            {                
                if (kvp.Value.Desc != "")
                {
                    sb.Append($"    [Desc(\"{kvp.Value.Desc}\")]\r\n");
                }
                if (kvp.Value.ClassType == 0)
                {
                    sb.Append($"    public partial class {kvp.Value.Name} : ProtocolMsgBase, INbsSerializer\r\n");
                }
                else
                {
                    sb.Append($"    public partial class {kvp.Value.Name}\r\n");
                }
                sb.Append("    {\r\n");
                //结构体
                foreach (var kvp2 in kvp.Value.DictBody)
                {
                    sb.Append($"{GetClassBodyFromNode(kvp2.Value)}\r\n");
                }
                if (kvp.Value.ClassType == 0)
                {
                    //sb.Append($"        public ushort ProtocolId {{get;}}\r\n");
                    //sb.Append($"        public EProtocolId ProtocolId {{get;set;}}\r\n");
                    //sb.Append($"        public EProtocolId ProtocolId {{get;set;}}\r\n");
                    sb.Append($"        public {kvp.Value.Name}() {{ ProtocolId = EProtocolId.{kvp.Value.NameId}; }}\r\n");
                    sb.Append($"        public {kvp.Value.Name}(byte[] buffer) {{ Unserialize(buffer); }}\r\n");
                    //序列化
                    sb.Append($"        public NetBitStream Serialize()\r\n");
                    sb.Append("        {\r\n");
                    sb.Append("            using(NetBitStream nbs = new NetBitStream())\r\n");
                    sb.Append("            {\r\n");
                    sb.Append("                nbs.Write(_protocol);\r\n");
                    sb.Append("                nbs.Write(_result);\r\n");
                    //sb.Append("            nbs.Write(Pin);\r\n");
                    sb.Append("                nbs.Write(Puid);\r\n");
                    sb.Append($"                nbs.Write(RspPuids.Count);\r\n");
                    sb.Append($"                foreach (var k in RspPuids)\r\n");
                    sb.Append($"                {{\r\n");
                    sb.Append($"                    nbs.Write(k);\r\n");
                    sb.Append($"                }}\r\n");
                    sb.Append("                nbs.Write(Shuttle);\r\n");

                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.Append($"{GetClassSerializeFromNode(kvp2.Value, "                ")}");
                    }
                    sb.Append("                nbs.WriteEnd();\r\n");
                    sb.Append("                return nbs;\r\n");
                    sb.Append("            }\r\n");
                    sb.Append("        }\r\n");

                    //反序列化
                    sb.Append($"        public void Unserialize(byte[] buffer)\r\n");
                    sb.Append("        {\r\n");
                    sb.Append("            using(NetBitStream nbs = new NetBitStream())\r\n");
                    sb.Append("            {\r\n");
                    sb.Append("                nbs.BeginRead(buffer);\r\n");
                    sb.Append("                nbs.Read(out _protocol);\r\n");
                    sb.Append("                nbs.Read(out _result);\r\n");
                    //sb.Append("            nbs.Read(out Pin);\r\n");
                    sb.Append("                nbs.Read(out Puid);\r\n");
                    sb.Append($"                int count = nbs.ReadInt();\r\n");
                    sb.Append($"                for (int k = 0; k < count; k++)\r\n");
                    sb.Append($"                {{\r\n");
                    sb.Append($"                    RspPuids.Add(nbs.ReadLong());\r\n");
                    sb.Append($"                }}\r\n");                    
                    sb.Append("                nbs.Read(out Shuttle);\r\n");
                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.Append($"{GetClassUnserializeFromNode(kvp2.Value, "                ")}");
                    }
                    sb.Append("            }\r\n");
                    sb.Append("        }\r\n");
                }
                else
                {
                    //序列化
                    sb.Append($"        public void Serialize(NetBitStream nbs)\r\n");
                    sb.Append("        {\r\n");
                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.Append($"{GetClassSerializeFromNode(kvp2.Value, "            ")}");
                    }
                    sb.Append("        }\r\n");

                    //反序列化
                    sb.Append($"        public void Unserialize(NetBitStream nbs)\r\n");
                    sb.Append("        {\r\n");
                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.Append($"{GetClassUnserializeFromNode(kvp2.Value, "            ")}");
                    }
                    sb.Append("        }\r\n");
                }
                sb.Append("    };\r\n");
            }
            string txt = Template_ClassBase;
            FileStream fs = new FileStream(PathCurrent + Filepath_ClassBase, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            txt = txt.Replace("$Class$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_ClassBase);
        }


        /// <summary>
        /// 生成结构体打印文件
        /// </summary>
        private static void ProtocolConverterDump()
        {
            Show("ProtocolConverterDump");
            var sb = new StringBuilder();

            int idx = 0;
            foreach (var kvp in DictClass)
            {
                if (kvp.Value.ClassType == 0)
                {
                    idx++;
                    sb.Append($"                case EProtocolId.{kvp.Value.NameId}:\r\n");
                    sb.Append($"                    return new {kvp.Value.Name}(buffer);\r\n");                    
                }
            }
            string txt = Template_ClassDump;
            FileStream fs = new FileStream(PathCurrent + Filepath_ClassDump, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            txt = txt.Replace("$Class$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_ClassDump);
        }


    }
}