using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetOptions<T> where T : INetConnection
{
	[CompilerGenerated]
	private string clientProcess;

	[CompilerGenerated]
	private IPEndPoint consumerProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientReceivedEventArgs<T>> facadeProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> proxyProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_ReaderProcess;

	internal static object m_PropertyProcess;

	public int Id { get; set; }

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return clientProcess;
		}
		[CompilerGenerated]
		set
		{
			clientProcess = value;
		}
	}

	public virtual string Key { get; set; }

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return consumerProcess;
		}
		[CompilerGenerated]
		set
		{
			consumerProcess = value;
		}
	}

	public SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return facadeProcess;
		}
		[CompilerGenerated]
		set
		{
			facadeProcess = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return proxyProcess;
		}
		[CompilerGenerated]
		set
		{
			proxyProcess = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderProcess;
		}
		[CompilerGenerated]
		set
		{
			m_ReaderProcess = value;
		}
	}

	internal static bool ExcludeThread()
	{
		return m_PropertyProcess == null;
	}
}
