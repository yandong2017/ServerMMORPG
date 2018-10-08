using ServerBase.BaseObjects;
using ServerBase.Client;
using ServerBase.Config;
using ServerBase.ServerLoger;
using ServerBase.Service;
using System.Collections.Generic;

namespace ServerGame.ServerLink
{
    //服务器连接
    public static class GameServerLinkManager
    {
        public class ServerLinkLoger : IUtilLoger
        {
            public void Dump(object o)
            {
                //Loger.Debug(o);
            }
            public void Debug(object o)
            {
                loger.Debug(o);
            }
            public void Error(object o)
            {
                loger.Error(o);
            }
        }       
        //连接列表
        public static Dictionary<int, ClientLink> DictClientLink = new Dictionary<int, ClientLink>();

        /// <summary>
        /// 启动连接
        /// </summary>
        /// <returns></returns>
        public static bool Start()
        {
            try
            {
                ClientDispatcher.SetLoger(new ServerLinkLoger());

                //拷贝配置文件
                DictClientLink.Clear();
                foreach (var conf in Conf.SysServerList.Values)
                {
                    //if (conf.ServerType == (int)EServerType.世界)//|| conf.ServerType == (int)EServerType.数据中心)
                    //{
                    //    var client = new ClientLink();
                    //    client.Setup(ConstsBase.Ip本机, conf.Id, conf.ServerType);
                    //    DictClientLink.Add(client.LinkId, client);
                    //}
                }

                AutoCheckLink();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 秒心跳
        /// </summary>
        public static void HeartbeatSecond10()
        {
            //自动检查断开的连接
            AutoCheckLink();
        }

        /// <summary>
        /// 分钟心跳
        /// </summary>
        public static void HeartbeatMinute()
        {
            //发送负载
            SendServerLoad();
        }

        /// <summary>
        /// 自动检查断开的连接
        /// </summary>
        public static void AutoCheckLink()
        {
            //遍历并连接
            foreach (var client in DictClientLink.Values)
            {
                if (!client.LinkState)
                {
                    client.Start();
                }
            }
        }

        /// <summary>
        /// 发送负载
        /// </summary>
        public static void SendServerLoad()
        {
            try
            {
                
                
            }
            catch
            {
            }
        }
    }
}