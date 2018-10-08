using SuperSocket.SocketLuanr;
using System;


namespace ServerBase.GameObject
{
    /// <summary>
    /// 玩家类
    /// </summary>
    public partial class Player
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id;
        /// <summary>
        /// 连接
        /// </summary>
        public LunarSession Session { get; set; }

        // 心跳开始时间
        public DateTime TimeHeartbeat = DateTime.Now;

        /// <summary>
        /// 构造函数 构造一个虚拟玩家
        /// </summary>
        /// <param name="puid"></param>
        public Player(long puid)
        {
            Id =puid;
        }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline = true;

        /// <summary>
        /// 玩家登入
        /// </summary>
        public void LoginOn()
        {     
            //设置连接已登陆
            Session.SessionState = (short)ESessionState.Logined;         
        }

        /// <summary>
        /// 玩家登出
        /// </summary>
        public void LoginOut()
        {
            //设置连接未登陆
            if (Session != null)
            {
                Session.SessionState = (short)ESessionState.Logining;
            }
        }

        /// <summary>
        /// 判断是否登陆
        /// </summary>
        /// <returns></returns>
        public bool Logined => (Session != null ? (Session.SessionState == (short)ESessionState.Logined) : false);

    }
}