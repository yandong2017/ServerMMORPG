using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketLuanr;
using UtilLib;

namespace SuperSocket.SocketLuanr
{
    /// <summary>
    /// 服务器
    /// </summary>
    public class LunarServerBase : AppServer<LunarSession, LunarRequestInfo>
    {
        /// <summary>
        /// 服务器类
        /// </summary>
        public LunarServerBase()
            : base(new DefaultReceiveFilterFactory<LunarReceiveFilter, LunarRequestInfo>())
        {
        }

        /// <summary>
        /// 服务器配置
        /// </summary>
        /// <returns></returns>
        public bool SetupEx(int port, string encoding)
        {
            var conf = LuanrServer.GetConfig(port, encoding);
            return Setup(conf);
        }

        /// <summary>
        /// 服务器启动
        /// </summary>
        /// <returns></returns>
        public override bool Start()
        {
            return base.Start();
        }
    }
}