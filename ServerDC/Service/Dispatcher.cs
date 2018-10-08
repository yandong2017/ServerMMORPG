using ServerBase.Dispatch;
using ServerBase.Protocol;
using ServerBase.ServerLoger;
using ServerBase.Service;
using ServerDC.Manager;
using SuperSocket.SocketBase;
using SuperSocket.SocketLuanr;
using static ServerBase.Dispatch.BaseDispatch;

namespace ServerLogin.Service
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public static class Dispatcher
    {
       
        /// <summary>
        /// 消息注册器即时
        /// </summary>
        public static void RegisterEventHandlerImm()
        {
            try
            {
                //心跳
                //BindEventHandlerImm(InfoManager.OnBasePing, EProtocolId.ALL_BASE_PING);                
            }
            catch
            {
                loger.Fatal("注册即时消息失败！");
            }
        }
    }
}