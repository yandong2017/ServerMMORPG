using ServerBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerBase
{
    public class GameServerSocket : ServerSocket
    {        
        public GateInfo SocketGate
        {
            get;
            set;
        }
        public GameServerSocket(Socket socket, GateInfo info) : base(socket)
        {
            SocketGate = info;
        }

        public override void ProcessMessage(short protoCode, byte[] buffer)
        {
            if (protoCode == (short)EProtocolId.ALL_BASE_PING)
            {
                All_Base_Ping all = new All_Base_Ping(buffer);
                Loger.Debug(all.ServerTime.ToString() + ":" + all.ServerTime.Millisecond);
            }
        }
    }
}
