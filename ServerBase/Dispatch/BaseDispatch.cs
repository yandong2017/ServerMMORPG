using SuperSocket.SocketLuanr;
using ServerBase.Protocol;
using ServerBase.BaseManagers;
using ServerBase.ServerLoger;
using ServerBase.Service;
using SuperSocket.SocketBase;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UtilLib;
using ServerBase.Config;
using System.Diagnostics;
using System.Threading;

namespace ServerBase.Dispatch
{
    /// <summary>
    /// 消息分发器
    /// </summary>
    public static class BaseDispatch
    {       

        public delegate void DispatcherEventHandler(LunarSession session, LunarRequestInfo requestInfo);       
        //绑定列表
        public static Dictionary<EProtocolId, DispatcherEventHandler> DictProtocolEvent = new Dictionary<EProtocolId, DispatcherEventHandler>();
        /// <summary>
        /// 绑定注册（立即）
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="id"></param>
        public static void BindEventHandler(DispatcherEventHandler handle, EProtocolId id)
        {
            try
            {               
                DictProtocolEvent[id] = handle;                
                loger.Info($"注册消息 {id,-30} -> {(int)id,-10} 成功！");
            }
            catch
            {
                loger.Warn($"注册消息 {id,-30} -> {(int)id,-10} 失败！");
            }
        }

        /// <summary>
        /// 新连接事件
        /// </summary>
        /// <param name="session"></param>
        public static void OnSessionConnected(LunarSession session)
        {
            loger.Debug("接收到连接: " + session.SessionID);
        }

        /// <summary>
        /// 有连接断开
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        public static void OnSessionClosed(LunarSession session, CloseReason reason)
        {
            loger.Debug("连接断开: " + session.SessionID);

            //当连接断开时 检查连接类型 如果类型为服务器 去清除负载列表
            if (session.SessionType != (long)EServerType.客户端)
            {
                BaseServerLinkManager.RemoveServerLinkList(session);
            }
        }

        /// <summary>
        /// 消息分发
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public static void OnDispatch(LunarSession session, LunarRequestInfo requestInfo)
        {
            if (requestInfo.ProtocolID == 0)
            {
                loger.Warn("收到空消息");
                return;
            }
            loger.Info($"收到消息 {(EProtocolId)requestInfo.ProtocolID}");
            ProcessMessage(session, requestInfo);           
            //session.ListReq.Enqueue(requestInfo);
        }
        //当前心跳处理消息数目
        public static int CountMsgs = 0;
        public static void Heartbeat()
        {
            CountMsgs = 0;
            //foreach (var session in BaseServerInfo.AllSessions.Values)
            //{
            //    if (session != null && session.Connected)
            //    {
            //        while (session.ListReq.TryDequeue(out var msg))
            //        {
            //            ProcessMessage(session, msg);
            //            loger.Info($"处理{session.ListReq.Count}消息 {(EProtocolId)msg.ProtocolID}");
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 处理消息立即
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public static void ProcessMessage(LunarSession session, LunarRequestInfo requestInfo)
        {
            EProtocolId id = (EProtocolId)requestInfo.ProtocolID;
            if (id == EProtocolId.C2S_SERVER_CONNECT)
            {
                var sessiontemp = GetSession(session.SessionID);
                if (sessiontemp != null)
                {
                    var Req = new C2S_Server_Connect(requestInfo.Body);
                    sessiontemp.SessionType = Req.SessionType;
                    loger.Debug($"连接类型：{(EServerType)sessiontemp.SessionType}");
                }
                else
                {
                    loger.Error($"连接不存在：{session.SessionUuid}");
                }
                return;
            }
            
            if (DictProtocolEvent.TryGetValue(id, out DispatcherEventHandler handle))
            {                
                try
                {
                    var StopwatchProcess = Stopwatch.StartNew();
                    handle(session,requestInfo);
                    StopwatchProcess.Stop();
                    var UseMs = StopwatchProcess.ElapsedMilliseconds;
                    if (UseMs > 500)
                    {
                        loger.Error($"消息处理超时，消息:{id} 玩家ID:{session.SessionUuid} 耗时:{UseMs} Ms__{CountMsgs}");
                    }
                }
                catch (Exception e)
                {
                    loger.Fatal($"处理协议->  {id} -> {(int)id}出错 玩家ID:{session.SessionUuid}", e);
                    Result(session, EProtocolResult.失败);
                    return;
                }
            }
            else
            {
                loger.Fatal($"处理协议->  {id} -> {(int)id} 未注册");
                Result(session, EProtocolResult.失败);
                return;
            }
        }        

        internal static LunarSession GetSession(string SessionID)
        {
            if (BaseServerInfo.AllSessions.TryGetValue(SessionID, out var Session))
            {
                return Session;
            }
            else
            {
                return null;
            }
        }
        public static void ThreadSendMain()
        {
            while (true)
            {
                try
                {
                    Send();
                }
                catch (Exception ex)
                {
                    loger.Fatal("消息发送线程 执行失败", ex);
                }                
            }
        }
       
        public static void Send()
        {
            foreach (var session in BaseServerInfo.AllSessions.Values)
            {
                if (session != null && session.Connected)
                {  
                    while (session.ListSend.TryDequeue(out var msg))
                    {
                        loger.Info($"消息发送线程{session.ListSend.Count}");
                        Send(session, msg);
                    }
                }
            }
        }
        /// <summary>
        /// 立即发送消息(通过session)
        /// </summary>
        public static void Send(LunarSession session, INbsSerializer objMsg)
        {
            try
            {
                if (session.Connected)
                {
                    var nbs = objMsg.Serialize();
                    ushort id = nbs.ReadProtocolHeader();
                    ushort result = nbs.ReadProtocolResult();
                    loger.Info($"发送{(EServerType)session.SessionType}数据包 协议号：{(EProtocolId)id}->{id} 错误码：{(EProtocolResult)result}->{result} 长度：{nbs.Length}");
                    session.Send(nbs.BYTES, 0, nbs.Length);
                }
            }
            catch (Exception ex)
            {
                loger.Fatal("立即发送消息失败", ex);
            }
        }
        
        public static void SendAll(INbsSerializer objMsg)
        {
            var nbs = objMsg.Serialize();
            foreach (var session in BaseServerInfo.AllSessions.Values)
            {
                Send(session, objMsg);
            }
        }

        /// <summary>
        /// 返回通用错误
        /// </summary>
        public static void Result(LunarSession session, EProtocolResult result = EProtocolResult.失败)
        {
            var objMsg = new All_Base_Result()
            {                
                Result = result,
            };
            Send(session, objMsg);
        }

    }
}