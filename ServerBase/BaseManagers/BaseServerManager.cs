using ServerBase.ServerLoger;
using ServerBase.Service;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerBase.BaseManagers
{
    /// <summary>
    /// 服务器游戏数据
    /// </summary>
    public static class BaseServerManager
    {
        //游戏基础数据
        public static BaseDataServer DatasServerBase = new BaseDataServer();

        //存档
        public static void SaveData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                loger.Fatal($"保存 {BaseServerInfo.ServerZone} 数据 错误", ex);
            }
        }

        //读取
        public static void LoadData()
        {            
            try
            {
                
            }
            catch (Exception ex)
            {
                loger.Fatal($"读取 {BaseServerInfo.ServerZone} 数据 错误", ex);
            }

            //创建新数据
            DatasServerBase = new BaseDataServer();
            SaveData();
            loger.Info($"创建 {BaseServerInfo.ServerZone} 数据 成功");
        }
    }
    /// <summary>
    /// 游戏基础数据
    /// </summary>
    [DataContract]
    public class BaseDataServer
    {
        //时间组
        [DataMember]
        public Dictionary<int, DateTime> DictBaseDatetime = new Dictionary<int, DateTime>();
        //字符串组
        [DataMember]
        public Dictionary<int, string> DictBaseString = new Dictionary<int, string>();

        //构造函数
        public BaseDataServer()
        {
        }
        //获取 时间组
        public DateTime GetBaseDatetime(EBaseDatetimeKey key)
        {
            if (DictBaseDatetime.TryGetValue((int)key, out var value))
            {
                return value;
            }
            else
            {
                return new DateTime();
            }
        }
        //修改 时间组
        public DateTime SetBaseDatetime(EBaseDatetimeKey key, DateTime value)
        {
            DictBaseDatetime[(int)key] = value;
            return value;
        }
        //获取 字符串组
        public string GetBaseString(EBaseStringKey key)
        {
            if (DictBaseString.TryGetValue((int)key, out var value))
            {
                return value;
            }
            else
            {
                return "";
            }
        }
        //修改 字符串组
        public string SetBaseString(EBaseStringKey key, string value)
        {
            DictBaseString[(int)key] = value;
            return value;
        }
    }


    // 时间组 关键字
    public enum EBaseDatetimeKey
    {
        未知 = 0,
        日更新 = 1,
        日五点 = 2,
        日六点 = 3,
        日整点 = 4,
        日结束 = 9,
        周更新 = 11,
        月更新 = 12,
    }
    // 字符串组 关键字
    public enum EBaseStringKey
    {
        未知 = 0,
    }
}