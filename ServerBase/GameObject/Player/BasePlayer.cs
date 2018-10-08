using ServerBase.Protocol;
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
        ///// <summary>
        ///// 网关连接
        ///// </summary>
        //public LunarSession GateSession { get; set; }
        ///// <summary>
        ///// 客户端连接
        ///// </summary>
        //public LunarSession ClientSession { get; set; }

        // 心跳开始时间
        public DateTime TimeHeartbeat = DateTime.Now;

        public CLS_PlayerXY XY = new CLS_PlayerXY();

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
        /// 判断是否登陆
        /// </summary>
        /// <returns></returns>
        public bool Logined = false;
        /// <summary>
        /// 玩家登入
        /// </summary>
        public void LoginOn()
        {
            //设置连接已登陆
            //ClientSession.SessionState = (short)ESessionState.Logined;  
            Logined = true;
        }

        /// <summary>
        /// 玩家登出
        /// </summary>
        public void LoginOut()
        {
            //设置连接未登陆
            //if (ClientSession != null)
            //{
            //    ClientSession.SessionState = (short)ESessionState.Logining;
            //}
            Logined = false;
        }



    }
}