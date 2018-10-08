using ServerBase.Protocol;
using ServerBase.BaseManagers;
using SuperSocket.SocketBase;
using System.Collections.Generic;
using System.Collections.Concurrent;
using ServerBase.GameObject;

namespace SuperSocket.SocketLuanr
{
    /// <summary>
    /// 连接状态
    /// </summary>
    public enum ESessionState
    {
        [Desc("未登陆")]
        Logining = 0,
        [Desc("已登陆")]
        Logined = 1,
    }

    /// <summary>
    /// 服务器连接
    /// </summary>
    public class LunarSession : AppSession<LunarSession, LunarRequestInfo>
    {
        /// <summary>
        /// 唯一ID(当类型为客户端时为用户唯一ID 当类型为其他服务器时为服务器ID)
        /// </summary>
        public long SessionUuid { get; set; }

        /// <summary>
        /// 连接类型(表明连接来自客户端开始其他服务器 默认为0=客户端)
        /// </summary>
        public short SessionType { get; set; } = 0;

        /// <summary>
        /// 连接状态 0=未登陆 1=已登陆 2=GM登陆
        /// </summary>
        public short SessionState { get; set; } = 0;
    }
}