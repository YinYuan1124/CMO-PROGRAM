using System.Net;
using System.Net.Sockets;

namespace GodSharp.Sockets;

public class SocketFactory : ISocketFactory
{
	public ITcpClient CreateTcpClient(TcpClientOptions tcpClientOptions_0)
	{
		return new TcpClient(tcpClientOptions_0);
	}

	public ITcpClient CreateTcpClient(string string_0, int int_0, int int_1 = 0, string string_1 = null, int int_2 = 3000, string string_2 = null, int int_3 = 0)
	{
		return new TcpClient(string_0, int_0, int_1, string_1, int_2, string_2, int_3);
	}

	public ITcpServer CreateTcpServer(TcpServerOptions tcpServerOptions_0)
	{
		return new TcpServer(tcpServerOptions_0);
	}

	public ITcpServer CreateTcpServer(int int_0 = 7788, string string_0 = null, int int_1 = int.MaxValue, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_1 = null, int int_2 = 0)
	{
		return new TcpServer(int_0, string_0, int_1, addressFamily_0, string_1, int_2);
	}

	public IUdpClient CreateUdpClient(UdpClientOptions udpClientOptions_0)
	{
		return new UdpClient(udpClientOptions_0);
	}

	public IUdpClient CreateUdpClient(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_0 = null, int int_0 = 0)
	{
		return new UdpClient(ipendPoint_0, ipendPoint_1, addressFamily_0, string_0, int_0);
	}

	public IUdpClient CreateUdpClient(string string_0, int int_0, int int_1 = 0, string string_1 = null, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_2 = null, int int_2 = 0)
	{
		return new UdpClient(string_0, int_0, int_1, string_1, addressFamily_0, string_2, int_2);
	}
}
