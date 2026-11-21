using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public class TcpServerOptions : NetOptions<ITcpConnection>
{
	[CompilerGenerated]
	private AddressFamily m_PageDecorator = AddressFamily.InterNetwork;

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> m_SystemDecorator;

	public AddressFamily Family
	{
		[CompilerGenerated]
		get
		{
			return m_PageDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_PageDecorator = value;
		}
	}

	public int Backlog { get; set; } = int.MaxValue;


	public SocketEventHandler<NetClientEventArgs<ITcpConnection>> OnConnected { get; set; }

	public SocketEventHandler<NetServerEventArgs> OnStarted { get; set; }

	public SocketEventHandler<NetServerEventArgs> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return m_SystemDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_SystemDecorator = value;
		}
	}

	public SocketEventHandler<NetServerEventArgs> OnServerException { get; set; }

	public TcpServerOptions()
	{
	}

	public TcpServerOptions(IPEndPoint ipendPoint_0, int int_0 = int.MaxValue, AddressFamily? nullable_0 = null, SocketEventHandler<NetClientReceivedEventArgs<ITcpConnection>> socketEventHandler_0 = null)
	{
		base.LocalEndPoint = ipendPoint_0;
		if (int_0 > 0)
		{
			Backlog = int_0;
		}
		if (nullable_0.HasValue)
		{
			Family = nullable_0.Value;
		}
		if (socketEventHandler_0 != null)
		{
			base.OnReceived = socketEventHandler_0;
		}
	}
}
