using ServerBase.GameObject;
using ServerBase.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerGame
{
    public class PlayerClientSocket : ServerSocket
    {
        public Player SocketPlayer
        {
            get;
            set;
        }

        public PlayerClientSocket(Socket socket,Player player) : base(socket)
        {
            SocketPlayer = player;
        }

    }
}
