using ServerBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerGate
{
    public class GateClientManager
    {
        public static Dictionary<int, GateClientSocket> DictServerLinkGame = new Dictionary<int, GateClientSocket>();
        public static Dictionary<int, GateClientSocket> DictServerLinkLogin = new Dictionary<int, GateClientSocket>();
        public static bool Start()
        {
            try
            {
                IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
                string ipa = ipe.AddressList[2].ToString();

                //先写两个测试用，后面读取配置
                var LoginClient = new GateClientSocket(ipa, 1034, 1);
                DictServerLinkLogin.Add(LoginClient.id, LoginClient);

                var GameClient = new GateClientSocket(ipa, 1038, 1);
                DictServerLinkGame.Add(GameClient.id, GameClient);

                AutoCheckLink();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void AutoCheckLink()
        {
            //遍历并连接
            foreach (var client in DictServerLinkLogin.Values)
            {
                if (!client.IsConnectedOk)
                {
                    client.Connect();
                }
                var all = new All_Base_Ping();
                client.SendMsg(all.Serialize());
            }
            foreach (var client in DictServerLinkGame.Values)
            {
                if (!client.IsConnectedOk)
                {
                    client.Connect();
                }
                var all = new All_Base_Ping();
                client.SendMsg(all.Serialize());
            }
        }
    }
}
