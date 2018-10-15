using System.IO;
using System.Text;
using System;
using Microsoft.Office.Interop.Word;

namespace ProtocolTool
{
    partial class Program
    {
        /// <summary>
        /// 生成枚举表文件
        /// </summary>
        private static void ProtocolConverterLuaEnum()
        {
            Show("ProtocolConverterLuaEnum");
            var sb = new StringBuilder();

            foreach (var kvp in DictEnum)
            {
                if (kvp.Value.Desc != "")
                {
                    sb.Append($"-- {kvp.Value.Desc}\r\n");
                }
                sb.Append($"Lua{kvp.Value.Name} =\r\n");
                sb.Append("{\r\n");
                foreach (var kvp2 in kvp.Value.DictBody)
                {
                    if (kvp2.Value.Desc != "")
                    {
                        sb.Append($"    -- {kvp2.Value.Desc}\r\n");
                    }
                    sb.Append($"    [\"{kvp2.Value.Body}\"]");
                    if (kvp2.Value.Value != -100000)
                    {
                        sb.Append($" = {kvp2.Value.Value}");
                    }
                    sb.Append(",\r\n");
                }
                sb.Append("}\r\n\r\n");
            }
            string txt = Template_EnumLua;
            FileStream fs = new FileStream(PathCurrentLua + Filepath_EnumLua, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UTF8Encoding(false));
            txt = txt.Replace("$Enum$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_EnumLua);
        }
        /// <summary>
        /// 生成协议号文件
        /// </summary>
        private static void ProtocolConverterLuaClassId()
        {
            Show("ProtocolConverterLuaClassId");
            var sb = new StringBuilder();

            foreach (var nn in DictClass.Values)
            {
                if (nn.ClassType != 0)
                {
                    continue;
                }
                if (nn.Id != -100000)
                {
                    sb.Append($"    [\"{nn.NameId}\"] = {nn.Id},\r\n");
                }
                else
                {
                    sb.Append($"    [\"{nn.NameId}\"],\r\n");
                }
            }
            string txt = Template_ClassIdLua;
            FileStream fs = new FileStream(PathCurrentLua + Filepath_ClassIdLua, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UTF8Encoding(false));
            txt = txt.Replace("$ClassId$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_ClassIdLua);
        }
        /// <summary>
        /// 生成结构体文件
        /// </summary>
        private static void ProtocolConverterLuaClass()
        {
            Show("ProtocolConverterLuaClass");
            var sb = new StringBuilder();

            foreach (var kvp in DictClass)
            {
                sb.AppendLine($"-- Lua{kvp.Value.Name} begin");
                if (kvp.Value.Desc != "")
                {
                    sb.AppendLine($"-- {kvp.Value.Desc}");
                }

                //结构体
                if (kvp.Value.ClassType == 0)
                {
                    sb.AppendLine($"Lua{kvp.Value.Name} = Class(Base)");
                }
                else
                {
                    sb.AppendLine($"Lua{kvp.Value.Name} = Class()");
                }
                sb.AppendLine($"function Lua{kvp.Value.Name}:ctor()");
                if (kvp.Value.ClassType == 0)
                {
                    sb.AppendLine($"    self._protocol = LuaProtocolId[\"{kvp.Value.NameId}\"]");
                }
                foreach (var kvp2 in kvp.Value.DictBody)
                {
                    var node = GetClassBodyFromNodeLua(kvp2.Value);
                    if (!string.IsNullOrEmpty(node))
                    {
                        sb.AppendLine($"{node}");
                    }
                }
                sb.AppendLine($"end");

                var phead = kvp.Value.Name.Substring(0, 3);
                //序列化
                if (kvp.Value.ClassType == 0)
                {
                    if (phead.Equals("C2G"))
                    {
                        sb.AppendLine($"function Lua{kvp.Value.Name}:Serialize()");
                        sb.AppendLine($"    local nbs = NetBitStreamLua()");
                        sb.AppendLine($"    nbs:WriteShort(self._protocol)");
                        sb.AppendLine($"    nbs:WriteShort(self._result)");
                        sb.AppendLine($"    nbs:WriteLong(self.Pin)");
                        sb.AppendLine($"    nbs:WriteLong(self.Puid)");
                        sb.AppendLine($"    nbs:WriteString(self.Shuttle)");

                        foreach (var kvp2 in kvp.Value.DictBody)
                        {
                            sb.AppendLine($"{GetClassSerializeFromNodeLua(kvp2.Value, "    ")}");
                        }

                        sb.AppendLine($"    nbs:WriteEnd()");
                        sb.AppendLine($"    return nbs");
                        sb.AppendLine($"end");
                    }
                }
                else
                {
                    sb.AppendLine($"function Lua{kvp.Value.Name}:Serialize(nbs)");

                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.AppendLine($"{GetClassSerializeFromNodeLua(kvp2.Value, "    ")}");
                    }

                    sb.AppendLine($"    return nbs");
                    sb.AppendLine($"end");
                }

                //反序列化
                if (kvp.Value.ClassType == 0)
                {
                    if (phead.Equals("G2C"))
                    {
                        sb.AppendLine($"function Lua{kvp.Value.Name}:Unserialize(buffer)");

                        sb.AppendLine($"    local nbs = NetBitStreamLua()");
                        sb.AppendLine($"    nbs:BeginRead(buffer)");
                        sb.AppendLine($"    self._protocol = nbs:ReadShort()");
                        sb.AppendLine($"    self._result = nbs:ReadShort()");
                        sb.AppendLine($"    self.Pin = nbs:ReadLong()");
                        sb.AppendLine($"    self.Puid = nbs:ReadLong()");
                        sb.AppendLine($"    self.Shuttle = nbs:ReadString()");

                        foreach (var kvp2 in kvp.Value.DictBody)
                        {
                            sb.AppendLine($"{GetClassUnserializeFromNodeLua(kvp2.Value, "    ")}");
                        }

                        sb.AppendLine($"end");
                    }
                }
                else
                {
                    sb.AppendLine($"function Lua{kvp.Value.Name}:Unserialize(nbs)");

                    foreach (var kvp2 in kvp.Value.DictBody)
                    {
                        sb.AppendLine($"{GetClassUnserializeFromNodeLua(kvp2.Value, "    ")}");
                    }

                    sb.AppendLine($"end");
                }

                sb.AppendLine($"-- Lua{kvp.Value.Name} end");
                sb.AppendLine(); sb.AppendLine();
            }
            string txt = Template_ClassLua;
            FileStream fs = new FileStream(PathCurrentLua + Filepath_ClassLua, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UTF8Encoding(false));
            txt = txt.Replace("$Class$", sb.ToString());
            sw.Write(txt);
            sw.Close();
            Show("输出文件：" + Filepath_ClassLua);
        }

    }
}