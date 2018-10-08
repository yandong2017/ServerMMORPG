using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerBase.GameObject
{
    // 时间组 关键字
    public enum EDataHeartbeatDatetimeKey
    {
        未知 = 0,
        日零点更新 = 1,
        日五点更新 = 2,
        日X点更新 = 3,
        周零点更新 = 11,
        周五点更新 = 12,
        月零点更新 = 21,
        秒更新 = 31,
        十秒更新 = 32,
        一分钟更新 = 41,
        三分钟更新 = 42,
        五分钟更新 = 43,
        三十分钟更新 = 44,
        一小时更新 = 51,
    }
    /// <summary>
    /// 玩家心跳
    /// </summary>
    [DataContract]
    public class DataHeartbeat
    {
        //时间
        [DataMember]
        public DateTime HeartbeatDatetimeBase = DateTime.Now;
        //时间组
        [DataMember]
        public Dictionary<int, DateTime> DictHeartbeatDatetime = new Dictionary<int, DateTime>();
        //获取 时间组
        public DateTime GetHeartbeatDatetime(EDataHeartbeatDatetimeKey key)
        {
            if (DictHeartbeatDatetime.TryGetValue((int)key, out var value))
            {
                return value;
            }
            else
            {
                return HeartbeatDatetimeBase;
            }
        }
        //修改 时间组
        public DateTime SetHeartbeatDatetime(EDataHeartbeatDatetimeKey key, DateTime value)
        {
            DictHeartbeatDatetime[(int)key] = value;
            return value;
        }



        //获取当前时间到下次日五点更新时间的间隔(秒数)
        public int GetCooldownFromDayUpdateFiveOClock()
        {
            var timeKey = EDataHeartbeatDatetimeKey.日五点更新;
            var dt1 = GetHeartbeatDatetime(timeKey).AddHours(-5);
            var dt2 = new DateTime(dt1.Year, dt1.Month, dt1.Day);
            dt2 = dt2.AddDays(1);

            return (int)((dt2 - dt1).TotalSeconds);
        }
        //获取当前时间到下次周五点更新时间的间隔(秒数)
        public int GetCooldownFromWeekUpdateFiveOClock()
        {
            var timeKey = EDataHeartbeatDatetimeKey.周五点更新;
            var dt1 = GetHeartbeatDatetime(timeKey).AddHours(-5);
            var dt2 = new DateTime(dt1.Year, dt1.Month, dt1.Day);
            dt2 = dt2.AddDays(7 - (int)dt2.DayOfWeek);

            return (int)((dt2 - dt1).TotalSeconds);
        }

    }
}