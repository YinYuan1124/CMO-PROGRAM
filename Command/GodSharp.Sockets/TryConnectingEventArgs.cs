using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class TryConnectingEventArgs<T> : NetClientEventArgs<T> where T : INetConnection
{
	[CompilerGenerated]
	private int baseDecorator;

	internal static object policyDecorator;

	public int Counter
	{
		[CompilerGenerated]
		get
		{
			return baseDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			baseDecorator = value;
		}
	}

	public TryConnectingEventArgs(T connection, int int_0)
		: this(connection, int_0, (IPEndPoint)null, (IPEndPoint)null)
	{
	}

	public TryConnectingEventArgs(T connection, int int_0, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null)
		: base(connection, ipendPoint_0, ipendPoint_1)
	{
		Counter = int_0;
	}

	internal static bool FlushProcess()
	{
		return policyDecorator == null;
	}
}
