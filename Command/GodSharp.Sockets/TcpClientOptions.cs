using System.Net;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public class TcpClientOptions : NetOptions<ITcpConnection>
{
	[CompilerGenerated]
	private int m_VisitorDecorator = -1;

	[CompilerGenerated]
	private IPEndPoint m_ExporterDecorator;

	[CompilerGenerated]
	private bool m_PrototypeDecorator = true;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> comparatorDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<ITcpConnection>> itemDecorator;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> creatorDecorator;

	public int ConnectTimeout
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_VisitorDecorator = value;
		}
	}

	public IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ExporterDecorator = value;
		}
	}

	public bool ReconnectEnable
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_PrototypeDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnConnected
	{
		[CompilerGenerated]
		get
		{
			return comparatorDecorator;
		}
		[CompilerGenerated]
		set
		{
			comparatorDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return itemDecorator;
		}
		[CompilerGenerated]
		set
		{
			itemDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnStopped { get; set; }

	public SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> OnTryConnecting
	{
		[CompilerGenerated]
		get
		{
			return creatorDecorator;
		}
		[CompilerGenerated]
		set
		{
			creatorDecorator = value;
		}
	}

	public ITryConnectionStrategy TryConnectionStrategy { get; set; } = new DefaultTryConnectionStrategy();


	public TcpClientOptions()
	{
	}

	public TcpClientOptions(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1 = null, SocketEventHandler<NetClientReceivedEventArgs<ITcpConnection>> socketEventHandler_0 = null)
	{
		if (ipendPoint_1 != null)
		{
			base.LocalEndPoint = ipendPoint_1;
		}
		if (ipendPoint_0 != null)
		{
			RemoteEndPoint = ipendPoint_0;
		}
		if (socketEventHandler_0 != null)
		{
			base.OnReceived = socketEventHandler_0;
		}
	}
}
