using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public class UdpClientOptions : NetOptions<IUdpConnection>
{
	[CompilerGenerated]
	private AddressFamily identifierDecorator = AddressFamily.InterNetwork;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<IUdpConnection>> m_ParserDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<IUdpConnection>> m_AlgoDecorator;

	public AddressFamily Family
	{
		[CompilerGenerated]
		get
		{
			return identifierDecorator;
		}
		[CompilerGenerated]
		set
		{
			identifierDecorator = value;
		}
	}

	public IPEndPoint RemoteEndPoint { get; set; }

	public SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return m_ParserDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ParserDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_AlgoDecorator = value;
		}
	}

	public UdpClientOptions()
	{
	}

	public UdpClientOptions(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily? nullable_0 = null)
	{
		if (ipendPoint_0 != null)
		{
			base.LocalEndPoint = ipendPoint_0;
		}
		if (ipendPoint_1 != null)
		{
			RemoteEndPoint = ipendPoint_1;
		}
		if (nullable_0.HasValue)
		{
			Family = nullable_0.Value;
		}
	}
}
