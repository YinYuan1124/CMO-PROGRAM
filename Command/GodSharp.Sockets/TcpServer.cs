using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using GodSharp.Sockets.Tcp;

namespace GodSharp.Sockets;

public sealed class TcpServer : NetBase<ITcpConnection, NetServerEventArgs>, INetBase<ITcpConnection>, IDisposable, IEvent<ITcpConnection, NetServerEventArgs>, ITcpServer, ITcpServerEvents
{
	private readonly object mappingDecorator = new object();

	private bool _MockDecorator;

	private bool m_TagDecorator;

	[CompilerGenerated]
	private Socket m_FieldDecorator;

	[CompilerGenerated]
	private IPEndPoint m_QueueDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetServerEventArgs> paramDecorator;

	public override bool Running => m_TagDecorator;

	public Socket Instance
	{
		[CompilerGenerated]
		get
		{
			return m_FieldDecorator;
		}
		[CompilerGenerated]
		private set
		{
			m_FieldDecorator = value;
		}
	}

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_QueueDecorator;
		}
		[CompilerGenerated]
		private set
		{
			m_QueueDecorator = value;
		}
	}

	public IDictionary<string, ITcpConnection> Connections { get; private set; } = new Dictionary<string, ITcpConnection>();


	public SocketEventHandler<NetServerEventArgs> OnServerException
	{
		[CompilerGenerated]
		get
		{
			return paramDecorator;
		}
		[CompilerGenerated]
		set
		{
			paramDecorator = value;
		}
	}

	public TcpServer(TcpServerOptions tcpServerOptions_0)
	{
		AwakeProcess(tcpServerOptions_0);
	}

	public TcpServer(int int_0 = 7788, string string_0 = null, int int_1 = int.MaxValue, AddressFamily addressFamily_0 = AddressFamily.InterNetwork, string string_1 = null, int int_2 = 0)
	{
		try
		{
			TcpServerOptions tcpServerOptions_ = new TcpServerOptions(new IPEndPoint((!string_0.IsNullOrWhiteSpace()) ? IPAddress.Parse(string_0) : ((addressFamily_0 == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any), int_0), int_1, addressFamily_0)
			{
				Id = int_2,
				Name = string_1
			};
			AwakeProcess(tcpServerOptions_);
		}
		catch (Exception ex)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	private void AwakeProcess(TcpServerOptions tcpServerOptions_0)
	{
		try
		{
			if (tcpServerOptions_0 == null)
			{
				throw new ArgumentNullException("options");
			}
			if (tcpServerOptions_0.LocalEndPoint == null)
			{
				throw new ArgumentNullException("LocalEndPoint");
			}
			if (tcpServerOptions_0.LocalEndPoint.Port.NotIn(0, 65535))
			{
				throw new ArgumentOutOfRangeException("Port", string.Format("The {0} must between {1} to {2}.", "Port", 0, 65535));
			}
			if (tcpServerOptions_0.LocalEndPoint.Port < 1)
			{
				throw new ArgumentOutOfRangeException("Port");
			}
			if (tcpServerOptions_0.Backlog < 1)
			{
				throw new ArgumentOutOfRangeException("Backlog");
			}
			if (tcpServerOptions_0.LocalEndPoint.AddressFamily == tcpServerOptions_0.Family)
			{
				AddressFamily family = tcpServerOptions_0.Family;
				if (family != AddressFamily.InterNetwork && family != AddressFamily.InterNetworkV6)
				{
					throw new ArgumentOutOfRangeException("Family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
				}
				if (tcpServerOptions_0.OnConnected != null)
				{
					OnConnected = tcpServerOptions_0.OnConnected;
				}
				if (tcpServerOptions_0.OnReceived != null)
				{
					base.OnReceived = tcpServerOptions_0.OnReceived;
				}
				if (tcpServerOptions_0.OnDisconnected != null)
				{
					base.OnDisconnected = tcpServerOptions_0.OnDisconnected;
				}
				if (tcpServerOptions_0.OnStarted != null)
				{
					base.OnStarted = tcpServerOptions_0.OnStarted;
				}
				if (tcpServerOptions_0.OnStopped != null)
				{
					base.OnStopped = tcpServerOptions_0.OnStopped;
				}
				if (tcpServerOptions_0.OnException != null)
				{
					base.OnException = tcpServerOptions_0.OnException;
				}
				LocalEndPoint = tcpServerOptions_0.LocalEndPoint;
				Instance = new Socket(tcpServerOptions_0.Family, SocketType.Stream, ProtocolType.Tcp);
				Instance.Bind(tcpServerOptions_0.LocalEndPoint);
				Instance.Listen(tcpServerOptions_0.Backlog);
				Key = tcpServerOptions_0.LocalEndPoint.ToString();
				Name = tcpServerOptions_0.Name ?? Key;
				Id = tcpServerOptions_0.Id;
				return;
			}
			throw new ArgumentException("The AddressFamily and Family not match.");
		}
		catch (Exception ex)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = ex
			});
			throw ex;
		}
	}

	public override void Start()
	{
		if (Running)
		{
			return;
		}
		try
		{
			QueryProcess();
			m_TagDecorator = true;
			base.OnStarted?.Invoke(new NetServerEventArgs(this, LocalEndPoint));
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = exception
			});
		}
	}

	public override void Stop()
	{
		if (!Running)
		{
			return;
		}
		_MockDecorator = true;
		SocketAggregateException ex = null;
		try
		{
			List<Exception> list = new List<Exception>();
			try
			{
				Instance.Close();
			}
			catch (Exception item)
			{
				list.Add(item);
			}
			IDictionary<string, ITcpConnection> connections = Connections;
			if (connections == null || connections.Count <= 0)
			{
				return;
			}
			string[] array = Connections.Keys.ToArray();
			string[] array2 = array;
			foreach (string key in array2)
			{
				try
				{
					Connections[key]?.Stop();
				}
				catch (Exception item2)
				{
					list.Add(item2);
				}
			}
			if (list.Count > 0)
			{
				ex = new SocketAggregateException("The tcp server " + Key + " throw exceptions when stopping.", list.ToArray());
			}
			m_TagDecorator = false;
		}
		finally
		{
			if (ex != null)
			{
				OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
				{
					Exception = ex
				});
				throw ex;
			}
			if (_MockDecorator)
			{
				base.OnStopped?.Invoke(new NetServerEventArgs(this, LocalEndPoint));
			}
			_MockDecorator = false;
		}
	}

	protected override void OnDisconnectedHandler(NetClientEventArgs<ITcpConnection> netClientEventArgs_0)
	{
		MapProcess(netClientEventArgs_0.NetConnection.Key);
		base.OnDisconnected?.Invoke(netClientEventArgs_0);
	}

	private void QueryProcess()
	{
		try
		{
			Instance.BeginAccept(ResetProcess, null);
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = exception
			});
			Stop();
		}
	}

	private void ResetProcess(IAsyncResult iasyncResult_0)
	{
		bool flag = false;
		ITcpConnection tcpConnection = null;
		try
		{
			if (!Running || _MockDecorator)
			{
				return;
			}
			Socket socket_ = Instance.EndAccept(iasyncResult_0);
			if (!_MockDecorator)
			{
				QueryProcess();
				flag = true;
				tcpConnection = new TcpConnection(socket_)
				{
					OnConnected = OnConnectedHandler,
					OnReceived = OnReceivedHandler,
					OnDisconnected = OnDisconnectedHandler,
					OnException = OnExceptionHandler
				};
				tcpConnection.Start();
				MapProcess(tcpConnection.Key);
				lock (mappingDecorator)
				{
					Connections.Add(tcpConnection.Key, tcpConnection);
				}
				OnConnected?.Invoke(new NetClientEventArgs<ITcpConnection>(tcpConnection));
			}
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint, tcpConnection)
			{
				Exception = exception
			});
		}
		finally
		{
			if (Running && !flag && !_MockDecorator)
			{
				QueryProcess();
			}
		}
	}

	private void MapProcess(string string_0)
	{
		bool flag = false;
		lock (mappingDecorator)
		{
			flag = Connections?.ContainsKey(string_0) ?? false;
		}
		try
		{
			if (flag)
			{
				Connections[string_0].Stop();
				Connections[string_0] = null;
			}
		}
		catch (Exception exception)
		{
			OnServerException?.Invoke(new NetServerEventArgs(this, LocalEndPoint)
			{
				Exception = exception
			});
		}
		finally
		{
			if (flag)
			{
				lock (mappingDecorator)
				{
					Connections?.Remove(string_0);
				}
			}
		}
	}

	public override void Dispose()
	{
		if (Running)
		{
			Instance.Close();
		}
	}
}
