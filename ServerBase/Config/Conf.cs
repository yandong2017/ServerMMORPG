
 

 
 

















using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using UtilLib;

namespace ServerBase.Config
{
    /// <summary>
    /// 配置类公用接口
    /// </summary>
    public interface IConfigBase
    {
        object GetKey();
    }

    /// <summary>
    /// 配置文件
    /// </summary>
    public static partial class Conf
    {
        /// <summary>
        /// 配置文件目录
        /// </summary>
        public const string eConfNormalPath = @"../Config/Xml/";

        public static string ConfListSeparator = UtilEnum.分隔符竖线;
        public static string ConfDictionarySeparator1 = UtilEnum.分隔符竖线;
        public static string ConfDictionarySeparator2 = UtilEnum.分隔符下划线;

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <returns></returns>
        public static bool InitConf()
        {
            return InitConfSettings();            
        }

        /// <summary>
        /// 读取节点配置
        /// </summary>
        public static bool ReadConfig<T>(XElement node, ref T conf)
        {
            string[] args = new string[] { };
            Type type = typeof(T);
            object obj = type.InvokeMember(null, BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                var nodestring = node.Element(field.Name).Value;
                switch (field.FieldType.Name)
                {
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
                                var liststr = nodestring.ToListString(ConfListSeparator);
                                if (liststr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { liststr }); }
                                break;

                            case "Int32":
                                var listint = nodestring.ToListInt(ConfListSeparator);
                                if (listint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listint }); }
                                break;

                            case "Int64":
                                var listlong = nodestring.ToListLong(ConfListSeparator);
                                if (listlong.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listlong }); }
                                break;

                            case "Single":
                                var listfloat = nodestring.ToListFloat(ConfListSeparator);
                                if (listfloat.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listfloat }); }
                                break;

                            case "List`1":
                                switch (field.FieldType.GetGenericArguments()[0].GetGenericArguments()[0].Name)
                                {
                                    case "String":
                                        var liststrstr = nodestring.ToListListString(ConfDictionarySeparator1, ConfDictionarySeparator2);
                                        if (liststrstr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { liststrstr }); }
                                        break;
                                    case "Int32":
                                        var listintint = nodestring.ToListListInt(ConfDictionarySeparator1, ConfDictionarySeparator2);
                                        if (listintint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { listintint }); }
                                        break;
                                    case "Single":
                                        var listlistfloat = nodestring.ToListListFloat(ConfDictionarySeparator1, ConfDictionarySeparator2);
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
                                var dicstr = nodestring.ToDictionaryString(ConfDictionarySeparator1, ConfDictionarySeparator2);
                                if (dicstr.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { dicstr }); }
                                break;

                            case "Int32":
                                var dicint = nodestring.ToDictionaryInt(ConfDictionarySeparator1, ConfDictionarySeparator2);
                                if (dicint.Count > 0) { type.InvokeMember(field.Name, BindingFlags.SetField, null, obj, new object[] { dicint }); }
                                break;

                            case "Int64":
                                var diclong = nodestring.ToDictionaryLong(ConfDictionarySeparator1, ConfDictionarySeparator2);
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

        /// <summary>
        /// 读取单行配置
        /// </summary>
        public static bool ReadConfig<T>(string Name, ref T conf, string pathName = eConfNormalPath)
        {
            string ConfName = $"{pathName}{Name}.xml";
            try
            {
                var XmlSet = XElement.Load(ConfName);
                var Nodes = from ele in XmlSet.Elements("Node") select ele;
                var node = Nodes.First();

                ReadConfig(node, ref conf);
                loger.Info($"读取配置-> {ConfName,-40} <-成功");
            }
            catch (Exception e)
            {
                loger.Fatal($"读取配置-> {ConfName,-40} <-失败", e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取Dictionary配置
        /// </summary>
        /// <param name="ConfName"></param>
        /// <returns></returns>
        public static bool ReadConfig<T1, T2>(string Name, ref Dictionary<T1, T2> confDic, string pathName = eConfNormalPath)
        {
            string ConfName = $"{pathName}{Name}.xml";
            try
            {
                var XmlSet = XElement.Load(ConfName);
                var Nodes = from ele in XmlSet.Elements("Node") select ele;

                confDic.Clear();
                foreach (var node in Nodes)
                {
                    var conf = default(T2);
                    ReadConfig(node, ref conf);
                    if (confDic.ContainsKey((T1)(((IConfigBase)conf).GetKey())))
                    {
                        loger.Fatal($"读取配置->{ConfName}<-  重复的配置主项 {(T1)(((IConfigBase)conf).GetKey())} ");
                        continue;
                    }
                    confDic.Add((T1)(((IConfigBase)conf).GetKey()), conf);
                }

                //loger.Info($"读取配置-> {ConfName,-40} <-成功 共{confDic.Count}项");
            }
            catch (Exception e)
            {
                loger.Fatal($"读取配置-> {ConfName,-40} <-失败", e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取SortedDictionary配置
        /// </summary>
        /// <param name="ConfName"></param>
        /// <returns></returns>
        public static bool ReadConfig<T1, T2>(string Name, ref SortedDictionary<T1, T2> confDic, string pathName = eConfNormalPath)
        {
            string ConfName = $"{pathName}{Name}.xml";
            try
            {
                var XmlSet = XElement.Load(ConfName);
                var Nodes = from ele in XmlSet.Elements("Node") select ele;

                confDic.Clear();
                foreach (var node in Nodes)
                {
                    var conf = default(T2);
                    ReadConfig(node, ref conf);
                    if (confDic.ContainsKey((T1)(((IConfigBase)conf).GetKey())))
                    {
                        loger.Fatal($"读取配置->{ConfName}<-  重复的配置主项 {(T1)(((IConfigBase)conf).GetKey())} ");
                        continue;
                    }
                    confDic.Add((T1)(((IConfigBase)conf).GetKey()), conf);
                }

                loger.Info($"读取配置-> {ConfName,-40} <-成功 共{confDic.Count}项");
            }
            catch (Exception e)
            {
                loger.Fatal($"读取配置-> {ConfName,-40} <-失败", e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取List配置
        /// </summary>
        /// <param name="ConfName"></param>
        /// <returns></returns>
        public static bool ReadConfig<T>(string Name, ref List<T> confList, string pathName = eConfNormalPath)
        {
            string ConfName = $"{pathName}{Name}.xml";
            try
            {
                var XmlSet = XElement.Load(ConfName);
                var Nodes = from ele in XmlSet.Elements("Node") select ele;

                confList.Clear();
                foreach (var node in Nodes)
                {
                    var conf = default(T);
                    ReadConfig(node, ref conf);
                    confList.Add(conf);
                }

                loger.Info($"读取配置-> {ConfName,-40} <-成功 共{confList.Count}项");
            }
            catch (Exception e)
            {
                loger.Fatal($"读取配置-> {ConfName,-40} <-失败", e);
                return false;
            }
            return true;
        }
    }
}