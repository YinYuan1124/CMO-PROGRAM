using System.Net;
using System.Net.Sockets;

namespace GodSharp.Sockets;

public interface ISocketFactory
{
	ITcpClient CreateTcpClient(TcpClientOptions tcpClientOptions_0);

	ITcpClient CreateTcpClient(string string_0, int int_0, int int_1 = 0, string string_1 = null, int int_2 = 3000, string string_2 = null, int int_3 = 0);

	ITcpServer CreateTcpServer(TcpServerOptions tcpServerOptions_0);

	ITcpServer CreateTcpServer(int int_0 = 7788, string string_0 = null, int int_1 = int.MaxValue, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_1 = null, int int_2 = 0);

	IUdpClient CreateUdpClient(UdpClientOptions udpClientOptions_0);

	IUdpClient CreateUdpClient(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_0 = null, int int_0 = 0);

	IUdpClient CreateUdpClient(string string_0, int int_0, int int_1 = 0, string string_1 = null, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_2 = null, int int_2 = 0);
}
