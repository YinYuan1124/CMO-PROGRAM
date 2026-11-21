using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using OpenDis.Common;

namespace GodSharp.Sockets.Udp;

public sealed class UdpConnection : NetConnection<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IDisposable, INetConnection, IUdpConnection
{
	[CompilerGenerated]
	private IUdpListener databaseDecorator;

	[CompilerGenerated]
	private IPEndPoint interceptorDecorator;

	[CompilerGenerated]
	private bool m_MessageDecorator;

	public override SocketEventHandler<NetClientEventArgs<IUdpConnection>> OnConnected
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public IUdpListener Listener
	{
		[CompilerGenerated]
		get
		{
			return databaseDecorator;
		}
		[CompilerGenerated]
		private set
		{
			databaseDecorator = value;
		}
	}

	public IPEndPoint ListenEndPoint
	{
		[CompilerGenerated]
		get
		{
			return interceptorDecorator;
		}
		[CompilerGenerated]
		private set
		{
			interceptorDecorator = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_0()
	{
		return m_MessageDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(bool bool_0)
	{
		m_MessageDecorator = bool_0;
	}

	internal UdpConnection(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily addressFamily_0 = AddressFamily.InterNetwork)
	{
		RevertProcess(ipendPoint_0, ipendPoint_1, addressFamily_0);
	}

	private void RevertProcess(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1, AddressFamily addressFamily_0 = AddressFamily.InterNetwork)
	{
		try
		{
			if (ipendPoint_0 == null && ipendPoint_1 == null)
			{
				throw new ArgumentNullException("remote,local");
			}
			if (ipendPoint_0 != null && ipendPoint_0.Port.NotIn(0, 65535))
			{
				throw new ArgumentOutOfRangeException("remote", string.Format("The {0} port must between {1} to {2}.", "remote", 0, 65535));
			}
			if (ipendPoint_1 != null && ipendPoint_1.Port.NotIn(0, 65535))
			{
				throw new ArgumentOutOfRangeException("local", string.Format("The {0} port must between {1} to {2}.", "remote", 0, 65535));
			}
			if (ipendPoint_0 != null && ipendPoint_1 != null)
			{
				if (ipendPoint_0.Port < 1 && ipendPoint_1.Port < 1)
				{
					throw new ArgumentNullException("Port, Port");
				}
			}
			else
			{
				if (ipendPoint_0 != null && ipendPoint_0.Port < 1)
				{
					throw new ArgumentOutOfRangeException("Port");
				}
				if (ipendPoint_1 != null && ipendPoint_1.Port < 1)
				{
					throw new ArgumentOutOfRangeException("Port");
				}
			}
			if (addressFamily_0 != AddressFamily.InterNetwork && addressFamily_0 != AddressFamily.InterNetworkV6)
			{
				throw new ArgumentOutOfRangeException("family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
			}
			if (ipendPoint_0 != null && ipendPoint_0.AddressFamily != addressFamily_0)
			{
				throw new ArgumentException("The remote and family not match.");
			}
			if (ipendPoint_1 != null && ipendPoint_1.AddressFamily != addressFamily_0)
			{
				throw new ArgumentException("The local and family not match.");
			}
			method_1(ipendPoint_0 != null && ipendPoint_0.Port > 0);
			ListenEndPoint = (method_0() ? ipendPoint_0 : new IPEndPoint((addressFamily_0 == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, 0));
			Instance = new Socket(addressFamily_0, SocketType.Dgram, ProtocolType.Udp);
			if (ipendPoint_1 != null && ipendPoint_1.Port > 0)
			{
				Instance.Bind(ipendPoint_1);
			}
			LocalEndPoint = ipendPoint_1;
			RemoteEndPoint = ListenEndPoint;
			Key = ipendPoint_1.ToString();
			Name = Name ?? Key;
		}
		catch (Exception ex)
		{
			OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	public override void Start()
	{
		try
		{
			IUdpListener listener = Listener;
			if (listener == null || !listener.Running)
			{
				Listener = new ProductDecorator(this);
				Listener.Start();
				OnStarted?.Invoke(new NetClientEventArgs<IUdpConnection>(this));
			}
		}
		catch (Exception exception)
		{
			OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
			{
				Exception = exception
			});
		}
	}

	public override void Stop()
	{
		if (Listener != null && Listener.Running)
		{
			try
			{
				Listener?.Stop();
				OnStopped?.Invoke(new NetClientEventArgs<IUdpConnection>(this));
			}
			catch (Exception exception)
			{
				OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(this)
				{
					Exception = exception
				});
			}
		}
	}

	public override void Dispose()
	{
		Listener?.Dispose();
	}
}
