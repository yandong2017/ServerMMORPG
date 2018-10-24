using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/// <summary>>
/// 网络传输Socket
/// </summary>
public class GateClientSocket : ClientSocket
{
    public string LinkIp = "127.0.0.1";
    public int LinkId = 1038;

    public GateClientSocket(string ip,int linkId,int Id = 0):base(Id)
    {
        LinkIp = ip;
        LinkId = linkId;
    }
    public void Connect()
    {
        Connect(LinkIp, LinkId);
    }
}