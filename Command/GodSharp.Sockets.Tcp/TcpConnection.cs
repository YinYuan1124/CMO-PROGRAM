using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using GodSharp.Sockets.Abstractions;
using GodSharp.Sockets.Extensions;
using OpenDis.Candidates;

namespace GodSharp.Sockets.Tcp;

public sealed class TcpConnection : NetConnection<ITcpConnection, NetClientEventArgs<ITcpConnection>>, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>, IDisposable, INetConnection, ITcpConnection
{
	private class ParameterPrototype
	{
		[CompilerGenerated]
		private EventWaitHandle expressionPrototype;

		[CompilerGenerated]
		private EventWaitHandle m_DispatcherPrototype;

		[CompilerGenerated]
		private bool? _ListenerPrototype;

		[CompilerGenerated]
		private Exception configPrototype;

		[SpecialName]
		[CompilerGenerated]
		public Exception UpdateInterruptibleMapping()
		{
			return configPrototype;
		}

		[SpecialName]
		[CompilerGenerated]
		public void InsertInterruptibleMapping(Exception exception_0)
		{
			configPrototype = exception_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private EventWaitHandle method_0()
		{
			return expressionPrototype;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(EventWaitHandle eventWaitHandle_0)
		{
			expressionPrototype = eventWaitHandle_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private EventWaitHandle method_2()
		{
			return m_DispatcherPrototype;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_3(EventWaitHandle eventWaitHandle_0)
		{
			m_DispatcherPrototype = eventWaitHandle_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool? method_4()
		{
			return _ListenerPrototype;
		}

		[SpecialName]
		[CompilerGenerated]
		public void method_5(bool? nullable_0)
		{
			_ListenerPrototype = nullable_0;
		}

		public bool CreateInterruptibleMapping(int int_0 = -1)
		{
			if (int_0 < 1)
			{
				return method_0().WaitOne();
			}
			return method_0().WaitOne(int_0);
		}

		public void CompareInterruptibleMapping()
		{
			method_0().Set();
		}

		public bool ReadInterruptibleMapping()
		{
			return method_2().WaitOne();
		}

		public bool DisableInterruptibleMapping()
		{
			return method_2().Set();
		}

		public ParameterPrototype()
		{
			method_1(new ManualResetEvent(initialState: false));
			method_3(new ManualResetEvent(initialState: false));
		}

		public ParameterPrototype(bool bool_0, Exception exception_0 = null)
		{
			method_5(bool_0);
			InsertInterruptibleMapping(exception_0);
		}
	}

	[CompilerGenerated]
	private bool m_AnnotationDecorator;

	[CompilerGenerated]
	private bool _IteratorDecorator;

	[CompilerGenerated]
	private IPEndPoint initializerDecorator;

	[CompilerGenerated]
	private IPEndPoint _RoleDecorator;

	[CompilerGenerated]
	private int m_AttributeDecorator = 3000;

	[CompilerGenerated]
	private bool m_EventDecorator = true;

	private int _GlobalDecorator;

	private bool _WorkerDecorator;

	private bool _AccountDecorator;

	[CompilerGenerated]
	private SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> m_StateDecorator;

	[CompilerGenerated]
	private ITryConnectionStrategy authenticationDecorator;

	public ITcpListener Listener { get; internal set; }

	public int ConnectTimeout
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			m_AttributeDecorator = value;
		}
	}

	public bool ReconnectEnable
	{
		[CompilerGenerated]
		get
		{
			return m_EventDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_EventDecorator = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> SelectThread()
	{
		return m_StateDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void CallThread(SocketEventHandler<TryConnectingEventArgs<ITcpConnection>> socketEventHandler_0)
	{
		m_StateDecorator = socketEventHandler_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal ITryConnectionStrategy ViewThread()
	{
		return authenticationDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void ValidateThread(ITryConnectionStrategy itryConnectionStrategy_0)
	{
		authenticationDecorator = itryConnectionStrategy_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private bool dvxnIfSicrN()
	{
		return m_AnnotationDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void anynIsFgvqa(bool bool_0)
	{
		m_AnnotationDecorator = bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_0()
	{
		return _IteratorDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(bool bool_0)
	{
		_IteratorDecorator = bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private IPEndPoint method_2()
	{
		return initializerDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(IPEndPoint ipendPoint_0)
	{
		initializerDecorator = ipendPoint_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private IPEndPoint method_4()
	{
		return _RoleDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_5(IPEndPoint ipendPoint_0)
	{
		_RoleDecorator = ipendPoint_0;
	}

	internal TcpConnection(Socket socket_0)
	{
		method_1(bool_0: false);
		if (socket_0.LocalEndPoint == null && socket_0.RemoteEndPoint == null)
		{
			throw new ArgumentException("This socket is not connected.");
		}
		Instance = socket_0;
		LocalEndPoint = socket_0.LocalEndPoint.As();
		RemoteEndPoint = socket_0.RemoteEndPoint.As();
		Key = RemoteEndPoint.ToString();
		Name = Name ?? Key;
		anynIsFgvqa(bool_0: true);
	}

	internal TcpConnection(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1)
	{
		CloneThread(ipendPoint_0, ipendPoint_1);
	}

	private void CloneThread(IPEndPoint ipendPoint_0, IPEndPoint ipendPoint_1)
	{
		method_3(ipendPoint_0);
		method_5(ipendPoint_1);
		method_1(bool_0: true);
		try
		{
			if (ipendPoint_0 == null)
			{
				throw new ArgumentNullException("remote");
			}
			AddressFamily addressFamily = ipendPoint_0.AddressFamily;
			if (ipendPoint_0.Port.NotIn(0, 65535))
			{
				throw new ArgumentOutOfRangeException("Port", string.Format("The {0} must between {1} to {2}.", "Port", 0, 65535));
			}
			if (ipendPoint_0.Port < 1)
			{
				throw new ArgumentOutOfRangeException("Port");
			}
			if (addressFamily != AddressFamily.InterNetwork && addressFamily != AddressFamily.InterNetworkV6)
			{
				throw new ArgumentOutOfRangeException("family", "The AddressFamily only support AddressFamily.InterNetwork and AddressFamily.InterNetworkV6.");
			}
			if (ipendPoint_1 != null && ipendPoint_1.AddressFamily != addressFamily)
			{
				throw new ArgumentException("The local and family not match.");
			}
			Instance = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
			if (ipendPoint_1 != null && ipendPoint_1.Port > 0)
			{
				Instance.Bind(ipendPoint_1);
			}
			RemoteEndPoint = ipendPoint_0;
			if (ipendPoint_1 != null && ipendPoint_1.Port > 0)
			{
				LocalEndPoint = ipendPoint_1;
			}
			Key = RemoteEndPoint.ToString();
			Name = Name ?? Key;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	internal void ConnectThread()
	{
		try
		{
			if (!ReconnectEnable || !method_0())
			{
				return;
			}
			_AccountDecorator = true;
			bool flag = false;
			do
			{
				_GlobalDecorator++;
				Console.WriteLine(string.Format("[{0}]try connect to {1} {2} ...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), method_2().As(), _GlobalDecorator));
				SelectThread()?.Invoke(new TryConnectingEventArgs<ITcpConnection>(this, _GlobalDecorator));
				CloneThread(method_2(), method_4());
				if (flag = MoveThread())
				{
					continue;
				}
				try
				{
					if (ViewThread() != null)
					{
						Thread.Sleep(ViewThread().Handle(_GlobalDecorator));
					}
				}
				catch (Exception exception)
				{
					OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
					{
						Exception = exception
					});
				}
			}
			while (!flag);
		}
		finally
		{
			_AccountDecorator = false;
		}
	}

	public override void Start()
	{
		_WorkerDecorator = MoveThread();
		if (!_WorkerDecorator)
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				ConnectThread();
			});
		}
	}

	private bool MoveThread()
	{
		try
		{
			ITcpListener listener = Listener;
			if (listener != null && listener.Running)
			{
				return true;
			}
			int num;
			if (dvxnIfSicrN())
			{
				num = 1;
			}
			else
			{
				num = (DeleteThread(ConnectTimeout) ? 1 : 0);
				if (num == 0)
				{
					goto IL_0078;
				}
			}
			_GlobalDecorator = 0;
			Listener = new ConfigurationCallbackCandidate(this);
			Listener.Start();
			goto IL_0078;
			IL_0078:
			ITcpListener listener2 = Listener;
			if (listener2 != null && listener2.Running)
			{
				OnStarted?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
			}
			if (num != 0)
			{
				if (!_WorkerDecorator)
				{
					_WorkerDecorator = true;
				}
				return true;
			}
		}
		catch (Exception ex)
		{
			OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
			{
				Exception = ex
			});
			if (!dvxnIfSicrN() && !method_0())
			{
				throw ex;
			}
		}
		return false;
	}

	public override void Stop()
	{
		if (Listener != null && Listener.Running)
		{
			try
			{
				Listener?.Stop();
				OnStopped?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
			}
			catch (Exception exception)
			{
				OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
				{
					Exception = exception
				});
			}
		}
	}

	private bool DeleteThread(int int_0 = -1)
	{
		ParameterPrototype parameterPrototype = new ParameterPrototype();
		Instance.BeginConnect(RemoteEndPoint.As(), AddThread, parameterPrototype);
		bool flag;
		if (!(flag = parameterPrototype.CreateInterruptibleMapping(int_0)))
		{
			parameterPrototype.method_5(flag);
		}
		parameterPrototype.ReadInterruptibleMapping();
		if (flag)
		{
			if (parameterPrototype.method_4() == false && parameterPrototype.UpdateInterruptibleMapping() != null)
			{
				OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(this)
				{
					Exception = parameterPrototype.UpdateInterruptibleMapping()
				});
				if (method_0())
				{
					throw parameterPrototype.UpdateInterruptibleMapping();
				}
				return false;
			}
			return parameterPrototype.method_4().GetValueOrDefault();
		}
		throw new SocketException(10060);
	}

	private void AddThread(IAsyncResult iasyncResult_0)
	{
		ParameterPrototype parameterPrototype = iasyncResult_0.AsyncState as ParameterPrototype;
		bool? flag = null;
		parameterPrototype.CompareInterruptibleMapping();
		try
		{
			Instance.EndConnect(iasyncResult_0);
			flag = false;
			if (parameterPrototype.method_4() != false)
			{
				Console.WriteLine("tcp.client connected");
				RemoteEndPoint = Instance.RemoteEndPoint.As();
				LocalEndPoint = Instance.LocalEndPoint.As();
				OnConnected?.Invoke(new NetClientEventArgs<ITcpConnection>(this));
				parameterPrototype.method_5(true);
				flag = true;
			}
		}
		catch (Exception exception_)
		{
			parameterPrototype.method_5(false);
			parameterPrototype.InsertInterruptibleMapping(exception_);
		}
		finally
		{
			Console.WriteLine($"tcp.client ConnectCallback connected:{flag}");
			if (flag == false && parameterPrototype.method_4() == false)
			{
				try
				{
					Instance.Close();
				}
				catch (Exception ex)
				{
					parameterPrototype.InsertInterruptibleMapping(parameterPrototype.UpdateInterruptibleMapping() ?? ex);
				}
			}
			parameterPrototype.DisableInterruptibleMapping();
		}
	}

	public override void Dispose()
	{
		Listener?.Dispose();
	}

	[CompilerGenerated]
	private void DestroyThread(object object_0)
	{
		ConnectThread();
	}
}
