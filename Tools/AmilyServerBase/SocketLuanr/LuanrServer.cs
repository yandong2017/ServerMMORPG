using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;


namespace SuperSocket.SocketLuanr
{
    public static class LuanrServer
    {
        /// <summary>
        /// 服务器配置
        /// </summary>
        /// <returns></returns>
        public static ServerConfig GetConfig(int port, string encoding)
        {
            if (DateTime.Now >= new DateTime(2030, 1, 1))
            {
                return null;
            }
            var serConfig = new ServerConfig();
            serConfig.Port = port;
            serConfig.TextEncoding = encoding;
            serConfig.ReceiveBufferSize = 409600;
            serConfig.SendBufferSize = 409600;
            serConfig.MaxRequestLength = 409600;
            serConfig.MaxConnectionNumber = 4096;

            return serConfig;
        }
        /// <summary>
        /// 服务器启动
        /// </summary>
        /// <returns></returns>
        public static bool Start(AppServer server)
        {
            return server.Start();
        }
    }
}
