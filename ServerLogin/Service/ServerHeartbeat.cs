using ServerBase.Dispatch;

namespace ServerLogin.Service
{
    /// <summary>
    /// 心跳守护
    /// </summary>
    public static class ServerHeartbeat
    {        
        /// <summary>
        /// 服务器心跳
        /// </summary>
        public static void Heartbeat()
        {            
            HeartbeatExecute();
        }

        // 心跳循环内容
        public static void HeartbeatExecute()
        {
            //消息分发
            BaseDispatch.Heartbeat();
        }
    }
}