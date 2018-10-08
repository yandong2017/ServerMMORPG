using ServerBase.DataBaseMysql;
using ServerBase.BaseObjects;
using System.Text;
using UtilLib;
using ServerBase.Protocol;
using ServerBase.Service;
using System;

namespace ServerBase.ServerLoger
{
    /// <summary>
    /// 游戏记录系统
    /// </summary>
    public static class Record
    {
        // 添加记录
        public static void Rec(ERecordType RecType, EActionSource ActionSource, long puid = 0, params object[] args)
        {
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            sb.Append($"insert into {BaseServerInfo.ServerID}{SqlText.GameRecord}{(int)RecType}");
            for (int i = 0; i < args.Length; i++)
            {
                sb1.Append($", v{i + 1}");
                sb2.Append($", '{args[i]}'");
            }
            sb.Append($"(RecDate, RecTime, ActionSource, Puid{sb1}) values ");
            sb.Append($"(Now(), Now(), '{(int)ActionSource}', '{puid}'{sb2})");
            ThreadDbMysqlSecond.AddCmd(sb.ToString());
        }
        // 添加记录
        public static void RecValue(ERecordType RecType, EActionSource ActionSource, long puid = 0, long v0 = 0, params object[] args)
        {
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            sb.Append($"insert into {BaseServerInfo.ServerID}{SqlText.GameRecord}{(int)RecType}");
            for (int i = 0; i < args.Length; i++)
            {
                sb1.Append($", v{i + 1}");
                sb2.Append($", '{args[i]}'");
            }
            sb.Append($"(RecDate, RecTime, ActionSource, Puid, v0{sb1}) values ");
            sb.Append($"(Now(), Now(), '{(int)ActionSource}', '{puid}', '{v0}'{sb2})");
            ThreadDbMysqlSecond.AddCmd(sb.ToString());
        }
    }


}