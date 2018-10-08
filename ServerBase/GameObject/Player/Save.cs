using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;

namespace ServerBase.GameObject
{
    /// <summary>
    /// 玩家存档读档
    /// </summary>
    partial class Player
    {
        // 玩家存储内容
        public int PlayerSaveContent { get; set; }

        // 上次存档时间
        public DateTime TimeLastAutoSave = DateTime.Now;
        // 存储玩家数据
        public bool Save()
        {
            loger.Debug($"Player.Save 玩家PUID：{Id} ");
                       
            bool result = true;           
            try
            {
                //方便查看异常数据，分开写入字典
                var datas = new Dictionary<string, object>();

                //datas[nameof(DaBasic)] = SerializerSingleData(DaBasic);
                //datas[nameof(DaHeartbeat)] = SerializerSingleData(DaHeartbeat);
                //datas[nameof(DaMisc)] = SerializerSingleData(DaMisc);
                //datas[nameof(DaMail)] = SerializerSingleData(DaMail);               

                if (!result)
                {
                    loger.Fatal($"Player.Save，失败： 玩家PUID：{Id} ");
                }

                return result;
            }
            catch (Exception ex)
            {
                loger.Fatal($"Player.Save，失败：玩家PUID：{Id} ", ex);
                return false;
            }
        }
        // 自动存储
        public bool AutoSave()
        {
            loger.Debug("AutoSave");
            return Save();
        }
    }
}