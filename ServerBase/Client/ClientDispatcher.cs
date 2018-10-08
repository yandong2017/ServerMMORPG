using ServerBase.Config;
using ServerBase.Protocol;
using ServerBase.Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBase.Client
{
    public interface IUtilLoger
    {
        void Dump(object o);
        void Debug(object o);
        void Error(object o);
    }

    public static class ClientDispatcher
    {
        /// <summary>
        /// 处理器列表
        /// </summary>
        public delegate void DispatcherEventHandler(byte[] buffer);

        public class ProtocolEvent
        {
            public event DispatcherEventHandler EventHandler;

            public void ExecuteProtocolEvent(byte[] buffer)
            {
                EventHandler(buffer);
            }
        }
        //绑定列表
        public static Dictionary<EProtocolId, ProtocolEvent> DictProtocolEvent = new Dictionary<EProtocolId, ProtocolEvent>();
        //绑定注册
        public static void BindEventHandler(DispatcherEventHandler handle, EProtocolId id)
        {
            try
            {
                ProtocolEvent Event = new ProtocolEvent();
                Event.EventHandler += new DispatcherEventHandler(handle);
                DictProtocolEvent.Add(id, Event);
                Debug(string.Format("注册消息->  {0,-30} -> {1,-10} 成功", id, (int)id));
            }
            catch
            {
                Error(string.Format("注册消息->  {0,-30} -> {1,-10} 失败", id, (int)id));
            }
        }

        //消息处理
        public static void OnReceiveData(byte[] msg)
        {
            ProcessMessage(msg);
        }

        public static DispatcherEventHandler EventHandler;
        // 处理消息
        public static void ProcessMessage(byte[] Buffer)
        {
            var nbs = new NetBitStream();
            nbs.BeginRead(Buffer);            
            EProtocolId id = (EProtocolId)nbs.ReadProtocolHeader();

            Debug($"处理协议->  {id} -> {(int)id} ......");

            if (EventHandler!=null)
            {
                EventHandler(Buffer);                
                return;
            }

            if (!DictProtocolEvent.TryGetValue(id, out var protocolevent))
            {
                Debug(string.Format("未注册协议->  {0} -> {1} ......", id, (int)id));
                return;
            }
            try
            {
                //处理
                protocolevent.ExecuteProtocolEvent(Buffer);
            }
            catch (Exception ex)
            {
                Error(string.Format("处理协议->  {0} -> {1}出错 ex:{2}", id, (int)id, ex.Message));
            }
        }

        //日志接口
        private static IUtilLoger MyLoger = null;
        public static void SetLoger(IUtilLoger v)
        {
            MyLoger = v;
        }
        public static void Dump(object o)
        {
            if (MyLoger != null)
            {
                MyLoger.Dump(o);
            }
        }
        public static void Debug(object o)
        {
            if (MyLoger != null)
            {
                MyLoger.Debug(o);
            }
        }
        public static void Error(object o)
        {
            if (MyLoger != null)
            {
                MyLoger.Error(o);
            }
        }

    }
}
