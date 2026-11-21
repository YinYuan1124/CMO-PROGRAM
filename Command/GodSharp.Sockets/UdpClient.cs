using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Udp;

namespace GodSharp.Sockets;

public sealed class UdpClient : NetBase<IUdpConnection, NetClientEventArgs<IUdpConnection>>, INetBase<IUdpConnection>, IDisposable, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IUdpClient, IUdpClientEvents
{
	[CompilerGenerated]
	private UdpConnection m_BroadcasterDecorator;

	public override bool Running
	{
		get
		{
			IUdpConnection udpConnection = Connection;
			if (udpConnection == null)
			{
				return false;
			}
			return udpConnection.Listener?.Running ?? false;
		}
	}

	public override string Key => Connection.Key;

	public override string Name => Connection.Name;

	public override int Id => Connection.Id;

	private UdpConnection connection
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_BroadcasterDecorator = value;
		}
	}

	public IUdpConnection Connection => connection;

	public UdpClient(UdpClientOptions udpClientOptions_0)
	{
		OrderProcess(udpClientOptions_0);
	}

	public UdpClient(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_0 = null, int int_0 = 0)
	{
		OrderProcess(new UdpClientOptions(ipendPoint_1, ipendPoint_0, addressFamily_0)
		{
			Id = int_0,
			Name = string_0
		});
	}

	public UdpClient(int int_0, string string_0 = null, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_1 = null, int int_1 = 0)
	{
		OrderProcess(new UdpClientOptions(new IPEndPoint((!string_0.IsNullOrWhiteSpace()) ? IPAddress.Parse(string_0) : ((addressFamily_0 == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), int_0), null, addressFamily_0)
		{
			Id = int_1,
			Name = string_1
		});
	}

	public UdpClient(string string_0, int int_0, int int_1 = 8899, string string_1 = null, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_2 = null, int int_2 = 0)
	{
		try
		{
			UdpClientOptions udpClientOptions_ = new UdpClientOptions(new IPEndPoint((!string_1.IsNullOrWhiteSpace()) ? IPAddress.Parse(string_1) : ((addressFamily_0 == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), int_1), string_0.IsNullOrWhiteSpace() ? null : new IPEndPoint(IPAddress.Parse(string_0), int_0), addressFamily_0)
			{
				Id = int_2,
				Name = string_2
			};
			OrderProcess(udpClientOptions_);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void OrderProcess(UdpClientOptions udpClientOptions_0)
	{
		if (udpClientOptions_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (udpClientOptions_0.RemoteEndPoint == null && udpClientOptions_0.LocalEndPoint == null)
		{
			throw new ArgumentNullException("RemoteEndPoint");
		}
		connection = new UdpConnection(udpClientOptions_0.RemoteEndPoint, udpClientOptions_0.LocalEndPoint, udpClientOptions_0.Family)
		{
			OnReceived = OnReceivedHandler,
			OnDisconnected = OnDisconnectedHandler,
			OnStarted = OnStartedHandler,
			OnStopped = OnStoppedHandler,
			OnException = OnExceptionHandler
		};
		if (udpClientOptions_0.Id > 0)
		{
			connection.Id = udpClientOptions_0.Id;
		}
		if (!udpClientOptions_0.Name.IsNullOrWhiteSpace())
		{
			connection.Name = udpClientOptions_0.Name;
		}
		if (udpClientOptions_0.OnReceived != null)
		{
			base.OnReceived = udpClientOptions_0.OnReceived;
		}
		if (udpClientOptions_0.OnDisconnected != null)
		{
			base.OnDisconnected = udpClientOptions_0.OnDisconnected;
		}
		if (udpClientOptions_0.OnStarted != null)
		{
			base.OnStarted = udpClientOptions_0.OnStarted;
		}
		if (udpClientOptions_0.OnStopped != null)
		{
			base.OnStopped = udpClientOptions_0.OnStopped;
		}
		if (udpClientOptions_0.OnException != null)
		{
			base.OnException = udpClientOptions_0.OnException;
		}
	}

	public override void Start()
	{
		Connection?.Start();
	}

	public override void Stop()
	{
		Connection?.Stop();
	}

	protected override void OnConnectedHandler(NetClientEventArgs<IUdpConnection> netClientEventArgs_0)
	{
		throw new NotSupportedException();
	}

	public override void Dispose()
	{
		Connection?.Dispose();
	}
}
