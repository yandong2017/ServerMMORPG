
using ServerBase.ServerLoger;
using System;


namespace ServerBase.GameObject
{

    /// <summary>
    /// 玩家存档读档
    /// </summary>
    partial class Player
    {
        // 读取玩家数据
        public bool Load()
        {

            loger.Debug($"Player.Load，玩家ID：{Id}");
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                loger.Debug($"Player.Load 失败 玩家ID：{Id}", ex);
                return false;
            }
        }  

    }

}