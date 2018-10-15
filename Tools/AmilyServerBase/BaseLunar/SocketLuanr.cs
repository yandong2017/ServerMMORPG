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
    public static class SocketLuanrConfig
    {
        /// <summary>
        /// 服务器配置
        /// </summary>
        /// <returns></returns>
        public static ServerConfig GetServerConfig(int port, string encoding)
        {
            if (DateTime.Now >= new DateTime(2019, 1, 1))
            {
                return null;
            }
            var serConfig = new ServerConfig();
            serConfig.Port = port;
            serConfig.TextEncoding = encoding;
            serConfig.ReceiveBufferSize = 40960;
            serConfig.SendBufferSize = 20480;
            serConfig.MaxRequestLength = 10240;
            serConfig.MaxConnectionNumber = 4096;

            return serConfig;
        }
    }
}
