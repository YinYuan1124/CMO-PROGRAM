using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public sealed class TcpClient : NetBase<ITcpConnection, NetClientEventArgs<ITcpConnection>>, INetBase<ITcpConnection>, IDisposable, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>, ITcpClient, ITcpClientEvents
{
	private bool _RecordDecorator;

	[CompilerGenerated]
	private TcpConnection exceptionDecorator;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> attrDecorator;

	public override bool Running
	{
		get
		{
			ITcpConnection tcpConnection = Connection;
			if (tcpConnection == null)
			{
				return false;
			}
			return tcpConnection.Listener?.Running ?? false;
		}
	}

	private TcpConnection connection
	{
		[CompilerGenerated]
		get
		{
			return exceptionDecorator;
		}
		[CompilerGenerated]
		set
		{
			exceptionDecorator = value;
		}
	}

	public ITcpConnection Connection => connection;

	public override string Key => Connection.Key;

	public override string Name => Connection.Name;

	public override int Id => Connection.Id;

	public SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> OnTryConnecting
	{
		[CompilerGenerated]
		get
		{
			return attrDecorator;
		}
		[CompilerGenerated]
		set
		{
			attrDecorator = value;
		}
	}

	public TcpClient(TcpClientOptions tcpClientOptions_0)
	{
		AssetProcess(tcpClientOptions_0);
	}

	public TcpClient(string string_0, int int_0, int int_1 = 0, string string_1 = null, int int_2 = -1, string string_2 = null, int int_3 = 0)
	{
		try
		{
			TcpClientOptions tcpClientOptions = new TcpClientOptions
			{
				Id = int_3,
				Name = string_2
			};
			if (int_2 > 0)
			{
				tcpClientOptions.ConnectTimeout = int_2;
			}
			tcpClientOptions.TryConnectionStrategy = new DefaultTryConnectionStrategy();
			tcpClientOptions.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(string_0), int_0);
			tcpClientOptions.LocalEndPoint = ((!string_1.IsNullOrWhiteSpace() || int_1 >= 1) ? new IPEndPoint((tcpClientOptions.RemoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, int_1) : null);
			AssetProcess(tcpClientOptions);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void AssetProcess(TcpClientOptions tcpClientOptions_0)
	{
		if (tcpClientOptions_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (tcpClientOptions_0.RemoteEndPoint == null)
		{
			throw new ArgumentNullException("RemoteEndPoint");
		}
		TcpConnection tcpConnection = new TcpConnection(tcpClientOptions_0.RemoteEndPoint, tcpClientOptions_0.LocalEndPoint);
		tcpConnection.OnConnected = OnConnectedHandler;
		tcpConnection.OnReceived = OnReceivedHandler;
		tcpConnection.OnDisconnected = OnDisconnectedHandler;
		tcpConnection.OnStarted = OnStartedHandler;
		tcpConnection.OnStopped = OnStoppedHandler;
		tcpConnection.OnException = OnExceptionHandler;
		tcpConnection.ConnectTimeout = tcpClientOptions_0.ConnectTimeout;
		tcpConnection.CallThread(OnTryConnectingHandler);
		tcpConnection.ReconnectEnable = tcpClientOptions_0.ReconnectEnable;
		tcpConnection.ValidateThread(tcpClientOptions_0.TryConnectionStrategy);
		connection = tcpConnection;
		if (tcpClientOptions_0.Id > 0)
		{
			connection.Id = tcpClientOptions_0.Id;
		}
		if (!tcpClientOptions_0.Name.IsNullOrWhiteSpace())
		{
			connection.Name = tcpClientOptions_0.Name;
		}
		if (tcpClientOptions_0.OnConnected != null)
		{
			OnConnected = tcpClientOptions_0.OnConnected;
		}
		if (tcpClientOptions_0.OnReceived != null)
		{
			base.OnReceived = tcpClientOptions_0.OnReceived;
		}
		if (tcpClientOptions_0.OnDisconnected != null)
		{
			base.OnDisconnected = tcpClientOptions_0.OnDisconnected;
		}
		if (tcpClientOptions_0.OnStarted != null)
		{
			base.OnStarted = tcpClientOptions_0.OnStarted;
		}
		if (tcpClientOptions_0.OnStopped != null)
		{
			base.OnStopped = tcpClientOptions_0.OnStopped;
		}
		if (tcpClientOptions_0.OnException != null)
		{
			base.OnException = tcpClientOptions_0.OnException;
		}
		if (tcpClientOptions_0.OnTryConnecting != null)
		{
			OnTryConnecting = tcpClientOptions_0.OnTryConnecting;
		}
	}

	public void ReconnectAvailable(bool bool_0)
	{
		connection.ReconnectEnable = bool_0;
	}

	public void UseTryConnectionStrategy(ITryConnectionStrategy itryConnectionStrategy_0)
	{
		connection.ValidateThread(itryConnectionStrategy_0);
	}

	public override void Start()
	{
		_RecordDecorator = false;
		Connection?.Start();
	}

	public override void Stop()
	{
		_RecordDecorator = true;
		Connection?.Stop();
	}

	protected override void OnDisconnectedHandler(NetClientEventArgs<ITcpConnection> netClientEventArgs_0)
	{
		base.OnDisconnectedHandler(netClientEventArgs_0);
		ThreadPool.QueueUserWorkItem(delegate
		{
			connection.ConnectThread();
		});
	}

	protected void OnTryConnectingHandler(TryConnectingEventArgs<ITcpConnection> tryConnectingEventArgs_0)
	{
		OnTryConnecting?.Invoke(tryConnectingEventArgs_0);
	}

	public override void Dispose()
	{
		Connection?.Dispose();
	}

	[CompilerGenerated]
	private void PrintProcess(object object_0)
	{
		connection.ConnectThread();
	}
}
