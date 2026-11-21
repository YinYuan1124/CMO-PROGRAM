using System.Net;

namespace GodSharp.Sockets;

public class NetClientReceivedEventArgs<T> : NetClientEventArgs<T> where T : INetConnection
{
	internal static object publisherDecorator;

	public byte[] Buffers { get; internal set; }

	public NetClientReceivedEventArgs(T connection, byte[] byte_0)
		: this(connection, byte_0, (IPEndPoint)null, (IPEndPoint)null)
	{
	}

	public NetClientReceivedEventArgs(T connection, byte[] byte_0, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null)
		: base(connection, ipendPoint_0, ipendPoint_1)
	{
		Buffers = byte_0;
	}

	internal static bool VerifyProcess()
	{
		return publisherDecorator == null;
	}
}
