using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class NetClientEventArgs<T> : NetEventArgs where T : INetConnection
{
	[CompilerGenerated]
	private IPEndPoint strategyDecorator;

	[CompilerGenerated]
	private IPEndPoint m_ConfigurationDecorator;

	[CompilerGenerated]
	private T m_TokenDecorator;

	private static object m_IndexerDecorator;

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return strategyDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			strategyDecorator = value;
		}
	}

	public IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			m_ConfigurationDecorator = value;
		}
	}

	public T NetConnection
	{
		[CompilerGenerated]
		get
		{
			return m_TokenDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			m_TokenDecorator = value;
		}
	}

	public NetClientEventArgs(T connection)
	{
		NetConnection = connection;
		RemoteEndPoint = connection?.RemoteEndPoint;
		LocalEndPoint = connection?.LocalEndPoint;
	}

	public NetClientEventArgs(T connection, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null)
		: this(connection)
	{
		if (ipendPoint_0 != null)
		{
			RemoteEndPoint = ipendPoint_0;
		}
		if (ipendPoint_1 != null)
		{
			LocalEndPoint = ipendPoint_1;
		}
	}

	internal static bool VisitProcess()
	{
		return m_IndexerDecorator == null;
	}
}
