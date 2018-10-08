using ServerBase.Protocol;
using ServerBase.ServerLoger;
using System;
using System.Collections.Generic;

namespace ServerBase.GameObject
{
    [Desc("账号")]
    public class User
    {
        [Desc("账号Id")]
        public long Uuid = 0;
        [Desc("账号")]
        public string Account = "account0";
        [Desc("密码")]
        public string Password = "123456";

        //存储
        public bool Save()
        {
            try
            {
                loger.Debug($"User.Save，账号：{Account}");

                var datas = new Dictionary<string, object>()
                {
                    [nameof(Uuid)] = Uuid,
                    [nameof(Account)] = Account,
                    [nameof(Password)] = Password,                   
                };

               
                return true;
            }
            catch (Exception ex)
            {
                loger.Fatal("User.Save 失败", ex);
                return false;
            }
        }
        // 读取
        public bool Load()
        {
            loger.Debug($"User.Load，账号：{Account}");
            try
            {
                       
                return true;
            }
            catch (Exception ex)
            {
                loger.Debug($"User.Load 失败", ex);
                return false;
            }
        }
    }
}
