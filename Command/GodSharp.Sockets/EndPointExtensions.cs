using System.Net;

namespace GodSharp.Sockets;

public static class EndPointExtensions
{
	public static IPEndPoint As(this EndPoint endPoint_0)
	{
		return endPoint_0 as IPEndPoint;
	}

	public static EndPoint As(this IPEndPoint ipendPoint_0)
	{
		return ipendPoint_0;
	}
}
