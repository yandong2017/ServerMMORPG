using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using UtilLib;

namespace ServerBase.IniFile
{
    /// <summary>
    /// 读取类
    /// </summary>
    public static class IniRead
    {
        public const string strSeparatorVertical = "|";
        public const string strSeparatorUnderline = "_";

        /// <summary>
        /// 读取节点配置
        /// </summary>
        public static bool ReadClass<T>(string filename, string Section, ref T conf)
        {
            var inifile = new IniFiles(filename);
            if (!inifile.ExistINIFile())
            {
                loger.Warn($"IniRead ReadClass 文件不存在 {filename}");
                return false;
            }

            string[] args = new string[] { };
            Type type = typeof(T);
            object obj = type.InvokeMember(null, BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                var nodestring = inifile.IniReadValue(Section, field.Name);
                switch (field.FieldType.Name)
                {
                    case "Boolean":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring.ToBool() });
                        break;

                    case "String":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring });
                        break;

                    case "Int32":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring.ToInt() });
                        break;

                    case "Int64":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring.ToLong() });
                        break;

                    case "Single":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring.ToFloat() });
                        break;

                    case "DateTime":
                        type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { nodestring.ToDateTime() });
                        break;

                    case "List`1":
                        switch (field.FieldType.GetGenericArguments()[0].Name)
                        {
                            case "String":
                                var liststr = nodestring.ToListString(strSeparatorVertical);
                                if (liststr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { liststr }); }
                                break;

                            case "Int32":
                                var listint = nodestring.ToListInt(strSeparatorVertical);
                                if (listint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listint }); }
                                break;

                            case "Int64":
                                var listlong = nodestring.ToListLong(strSeparatorVertical);
                                if (listlong.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listlong }); }
                                break;

                            case "Single":
                                var listfloat = nodestring.ToListFloat(strSeparatorVertical);
                                if (listfloat.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listfloat }); }
                                break;

                            case "List`1":
                                switch (field.FieldType.GetGenericArguments()[0].GetGenericArguments()[0].Name)
                                {
                                    case "String":
                                        var liststrstr = nodestring.ToListListString(strSeparatorVertical, strSeparatorUnderline);
                                        if (liststrstr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { liststrstr }); }
                                        break;
                                    case "Int32":
                                        var listintint = nodestring.ToListListInt(strSeparatorVertical, strSeparatorUnderline);
                                        if (listintint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listintint }); }
                                        break;
                                    case "Single":
                                        var listlistfloat = nodestring.ToListListFloat(strSeparatorVertical, strSeparatorUnderline);
                                        if (listlistfloat.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listlistfloat }); }
                                        break;
                                }
                                break;
                        }
                        break;

                    case "Dictionary`2":
                        switch (field.FieldType.GetGenericArguments()[0].Name)
                        {
                            case "String":
                                var dicstr = nodestring.ToDictionaryString(strSeparatorVertical, strSeparatorUnderline);
                                if (dicstr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { dicstr }); }
                                break;

                            case "Int32":
                                var dicint = nodestring.ToDictionaryInt(strSeparatorVertical, strSeparatorUnderline);
                                if (dicint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { dicint }); }
                                break;

                            case "Int64":
                                var diclong = nodestring.ToDictionaryLong(strSeparatorVertical, strSeparatorUnderline);
                                if (diclong.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { diclong }); }
                                break;
                        }
                        break;

                    default:
                        loger.Fatal("错误的配置类型：" + field.FieldType.Name);
                        return false;
                }
            }
            conf = (T)obj;
            return true;
        }
    }
}
