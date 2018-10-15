using System.IO;
using System.Text;
using System;
using Microsoft.Office.Interop.Word;

namespace ProtocolTool
{
    partial class Program
    {
        //成员和初始化
        public static string GetClassBodyFromNodeLua(CClassNode v)
        {
            var sb = new StringBuilder();

            switch (v.Ctype)
            {
                case "bool":
                    sb.Append($"    self.{v.Body} = false");
                    break;
                case "byte":
                case "short":
                case "int":
                case "uint":
                case "long":
                case "float":
                    sb.Append($"    self.{v.Body} = 0");
                    break;

                case "string":
                    sb.Append($"    self.{v.Body} = \"\"");
                    break;

                case "dt":
                case "datetime":
                case "DateTime":
                    //sb.Append($"        public {v.Ctype} {v.Body} = {v.Ctype}.Now;");
                    break;

                case "ts":
                case "timespan":
                case "TimeSpan":
                    break;

                case "list":
                    sb.Append($"    self.{v.Body} = List:New(Lua{v.Ctype1})");
                    break;

                case "dict":
                    sb.Append($"    self.{v.Body} = Dictionary:New()");
                    break;

                default:
                    if (v.Ctype.Length > 0 && v.Ctype[0] == 'E')
                    {
                        sb.Append($"    self.{v.Body} = 0");
                    }
                    else
                    {
                        sb.Append($"    self.{v.Body} = Lua{v.Ctype}.new()");
                    }
                    break;
            }
            if (sb.Length > 0)
            {
                if (v.Desc != "")
                {
                    sb.Append($"    -- {v.Desc}");
                }
            }
            return sb.ToString();
        }
        //成员序列化
        public static string GetClassSerializeFromNodeTypeListLua(CClassNode v)
        {
            var sb = new StringBuilder();
            switch (v.Ctype1)
            {
                case "bool":
                    sb.Append($"nbs:WriteBool(self.{v.Body}[i])");
                    break;
                case "byte":
                    sb.Append($"nbs:WriteByte(self.{v.Body}[i])");
                    break;
                case "short":
                    sb.Append($"nbs:WriteShort(self.{v.Body}[i])");
                    break;
                case "int":
                    sb.Append($"nbs:WriteInt(self.{v.Body}[i])");
                    break;
                case "uint":
                    sb.Append($"nbs:WriteUInt(self.{v.Body}[i])");
                    break;
                case "long":
                    sb.Append($"nbs:WriteLong(self.{v.Body}[i])");
                    break;
                case "float":
                    sb.Append($"nbs:WriteFloat(self.{v.Body}[i])");
                    break;
                case "string":
                    sb.Append($"nbs:WriteString(self.{v.Body}[i])");
                    break;
                case "DateTime":
                    sb.Append($"nbs:WriteDateTime(self.{v.Body}[i])");
                    break;
                case "TimeSpan":
                    sb.Append($"nbs.WriteTimeSpan(self.{v.Body}[i])");
                    break;

                default:
                    sb.Append($"(self.{v.Body}[i]):Serialize(nbs)");
                    break;
            }
            return sb.ToString();
        }
        //成员序列化
        public static string GetClassSerializeFromNodeTypeDictLua(CClassNode v)
        {
            var sb = new StringBuilder();
            switch (v.Ctype1)
            {
                case "bool":
                    sb.Append($"nbs:WriteBool(key)");
                    break;
                case "byte":
                    sb.Append($"nbs:WriteByte(key)");
                    break;
                case "short":
                    sb.Append($"nbs:WriteShort(key)");
                    break;
                case "int":
                    sb.Append($"nbs:WriteInt(key)");
                    break;
                case "uint":
                    sb.Append($"nbs:WriteUInt(key)");
                    break;
                case "long":
                    sb.Append($"nbs:WriteLong(key)");
                    break;
                case "float":
                    sb.Append($"nbs:WriteFloat(key)");
                    break;
                case "string":
                    sb.Append($"nbs:WriteString(key)");
                    break;
                case "DateTime":
                    sb.Append($"nbs:WriteDateTime(key)");
                    break;
                case "TimeSpan":
                    sb.Append($"nbs:WriteTimeSpan(key)");
                    break;

                default:
                    sb.Append($"key:Serialize(nbs)");
                    break;
            }
            sb.AppendLine();
            sb.Append("        ");
            switch (v.Ctype2)
            {
                case "bool":
                    sb.Append($"nbs:WriteBool(value)");
                    break;
                case "byte":
                    sb.Append($"nbs:WriteByte(value)");
                    break;
                case "short":
                    sb.Append($"nbs:WriteShort(value)");
                    break;
                case "int":
                    sb.Append($"nbs:WriteInt(value)");
                    break;
                case "uint":
                    sb.Append($"nbs:WriteUInt(value)");
                    break;
                case "long":
                    sb.Append($"nbs:WriteLong(value)");
                    break;
                case "float":
                    sb.Append($"nbs:WriteFloat(value)");
                    break;
                case "string":
                    sb.Append($"nbs:WriteString(value)");
                    break;
                case "DateTime":
                    sb.Append($"nbs:WriteDateTime(value)");
                    break;
                case "TimeSpan":
                    sb.Append($"nbs:WriteTimeSpan(value)");
                    break;

                default:
                    sb.Append($"value:Serialize(nbs)");
                    break;
            }
            return sb.ToString();
        }
        //成员序列化
        public static string GetClassSerializeFromNodeLua(CClassNode v, string space)
        {
            var sb = new StringBuilder();
            switch (v.Ctype)
            {
                case "bool":
                    sb.Append($"{space}nbs:WriteBool(self.{v.Body})");
                    break;
                case "byte":
                    sb.Append($"{space}nbs:WriteByte(self.{v.Body})");
                    break;
                case "short":
                    sb.Append($"{space}nbs:WriteShort(self.{v.Body})");
                    break;
                case "int":
                    sb.Append($"{space}nbs:WriteInt(self.{v.Body})");
                    break;
                case "uint":
                    sb.Append($"{space}nbs:WriteUInt(self.{v.Body})");
                    break;
                case "long":
                    sb.Append($"{space}nbs:WriteLong(self.{v.Body})");
                    break;
                case "float":
                    sb.Append($"{space}nbs:WriteFloat(self.{v.Body})");
                    break;
                case "string":
                    sb.Append($"{space}nbs:WriteString(self.{v.Body})");
                    break;
                case "DateTime":
                    sb.Append($"{space}nbs:WriteDateTime(self.{v.Body})");
                    break;
                case "TimeSpan":
                    sb.Append($"{space}nbs:WriteTimeSpan(self.{v.Body})");
                    break;

                case "list":
                    sb.AppendLine($"{space}nbs:WriteInt(#self.{v.Body})");
                    sb.AppendLine($"{space}for i = 1, #self.{v.Body} do");
                    sb.AppendLine($"    {space}{GetClassSerializeFromNodeTypeListLua(v)}");
                    sb.Append($"{space}end");
                    break;

                case "dict":
                    sb.AppendLine($"{space}nbs:WriteInt(#self.{v.Body})");
                    sb.AppendLine($"{space}for key, value in pairs(self.{v.Body}) do");
                    sb.AppendLine($"    {space}{GetClassSerializeFromNodeTypeDictLua(v)}");
                    sb.Append($"{space}end");
                    break;

                default:
                    if (v.Ctype.Length > 0 && v.Ctype[0] == 'E')
                    {
                        sb.Append($"{space}nbs:WriteShort({v.Body})");
                    }
                    else
                    {
                        sb.Append($"{space}{v.Body}:Serialize(nbs)");
                    }
                    break;
            }
            return sb.ToString();
        }
        //成员反序列化
        public static string GetClassUnserializeFromNodeTypeListLua(CClassNode v)
        {
            var sb = new StringBuilder();
            string varname = GetVariablesId();
            switch (v.Ctype1)
            {
                case "bool":
                    sb.AppendLine($"local {varname} = nbs:ReadBool()");
                    break;
                case "byte":
                    sb.AppendLine($"local {varname} = nbs:ReadByte()");
                    break;
                case "short":
                    sb.AppendLine($"local {varname} = nbs:ReadShort()");
                    break;
                case "int":
                    sb.AppendLine($"local {varname} = nbs:ReadInt()");
                    break;
                case "uint":
                    sb.AppendLine($"local {varname} = nbs:ReadUint()");
                    break;
                case "long":
                    sb.AppendLine($"local {varname} = nbs:ReadLong()");
                    break;
                case "float":
                    sb.AppendLine($"local {varname} = nbs:ReadFloat()");
                    break;
                case "string":
                    sb.AppendLine($"local {varname} = nbs:ReadString()");
                    break;
                case "DateTime":
                    sb.AppendLine($"local {varname} = nbs:ReadDateTime()");
                    break;
                case "TimeSpan":
                    sb.AppendLine($"local {varname} = nbs:ReadTimeSpan()");
                    break;

                default:
                    sb.AppendLine($"local {varname} = Lua{v.Ctype1}.new()");
                    sb.AppendLine($"        {varname}:Unserialize(nbs)");
                    break;
            }
            sb.Append($"        self.{v.Body}:Add({varname})");
            return sb.ToString();
        }
        //成员反序列化
        public static string GetClassUnserializeFromNodeTypeDictLua(CClassNode v)
        {
            var sb = new StringBuilder();
            string varname = GetVariablesId();
            switch (v.Ctype1)
            {
                case "bool":
                    sb.AppendLine($"local {varname} = nbs:ReadBool()");
                    break;
                case "byte":
                    sb.AppendLine($"local {varname} = nbs:ReadByte()");
                    break;
                case "short":
                    sb.AppendLine($"local {varname} = nbs:ReadShort()");
                    break;
                case "int":
                    sb.AppendLine($"local {varname} = nbs:ReadInt()");
                    break;
                case "uint":
                    sb.AppendLine($"local {varname} = nbs:ReadUint()");
                    break;
                case "long":
                    sb.AppendLine($"local {varname} = nbs:ReadLong()");
                    break;
                case "float":
                    sb.AppendLine($"local {varname} = nbs:ReadFloat()");
                    break;
                case "string":
                    sb.AppendLine($"local {varname} = nbs:ReadString()");
                    break;
                case "DateTime":
                    sb.AppendLine($"local {varname} = nbs:ReadDateTime()");
                    break;
                case "TimeSpan":
                    sb.AppendLine($"local {varname} = nbs:ReadTimeSpan()");
                    break;

                default:
                    sb.AppendLine($"local {varname} = Lua{v.Ctype1}.new()");
                    sb.AppendLine($"        {varname}:Unserialize(nbs)");
                    break;
            }
            string varname2 = GetVariablesId();
            switch (v.Ctype2)
            {
                case "bool":
                    sb.AppendLine($"        local {varname2} = nbs:ReadBool()");
                    break;
                case "byte":
                    sb.AppendLine($"        local {varname2} = nbs:ReadByte()");
                    break;
                case "short":
                    sb.AppendLine($"        local {varname2} = nbs:ReadShort()");
                    break;
                case "int":
                    sb.AppendLine($"        local {varname2} = nbs:ReadInt()");
                    break;
                case "uint":
                    sb.AppendLine($"        local {varname2} = nbs:ReadUint()");
                    break;
                case "long":
                    sb.AppendLine($"        local {varname2} = nbs:ReadLong()");
                    break;
                case "float":
                    sb.AppendLine($"        local {varname2} = nbs:ReadFloat()");
                    break;
                case "string":
                    sb.AppendLine($"        local {varname2} = nbs:ReadString()");
                    break;
                case "DateTime":
                    sb.AppendLine($"        local {varname2} = nbs:ReadDateTime()");
                    break;
                case "TimeSpan":
                    sb.AppendLine($"        local {varname2} = nbs:ReadTimeSpan()");
                    break;

                default:
                    sb.AppendLine($"        local {varname2} = Lua{v.Ctype2}.new()");
                    sb.AppendLine($"        {varname2}:Unserialize(nbs)");
                    break;
            }
            sb.Append($"        self.{v.Body}:Add({varname}, {varname2})");
            return sb.ToString();
        }
        //成员反序列化
        public static string GetClassUnserializeFromNodeLua(CClassNode v, string space)
        {
            var sb = new StringBuilder();
            string varname = GetVariablesId();
            switch (v.Ctype)
            {
                case "bool":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadBool()");
                    break;
                case "byte":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadByte()");
                    break;
                case "short":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadShort()");
                    break;
                case "int":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadInt()");
                    break;
                case "uint":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadUint()");
                    break;
                case "long":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadLong()");
                    break;
                case "float":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadFloat()");
                    break;
                case "string":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadString()");
                    break;
                case "DateTime":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadDateTime()");
                    break;
                case "TimeSpan":
                    sb.Append($"{space}self.{v.Body} = nbs:ReadTimeSpan()");
                    break;

                case "list":
                    sb.AppendLine($"{space}local {varname} = nbs:ReadInt()");
                    sb.AppendLine($"{space}for i = 1, {varname} do");
                    sb.AppendLine($"    {space}{GetClassUnserializeFromNodeTypeListLua(v)}");
                    sb.Append($"{space}end");
                    break;

                case "dict":
                    sb.AppendLine($"{space}local {varname} = nbs:ReadInt()");
                    sb.AppendLine($"{space}for i = 1, {varname} do");
                    sb.AppendLine($"    {space}{GetClassUnserializeFromNodeTypeDictLua(v)}");
                    sb.Append($"{space}end");
                    break;

                default:
                    if (v.Ctype.Length > 0 && v.Ctype[0] == 'E')
                    {
                        sb.Append($"{space}self.{v.Body} = nbs:ReadShort()");
                    }
                    else
                    {
                        sb.Append($"{space}self.{v.Body}:Unserialize(nbs)");
                    }
                    break;
            }
            return sb.ToString();
        }

    }
}