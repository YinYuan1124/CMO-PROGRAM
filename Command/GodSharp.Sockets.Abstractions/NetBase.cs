using System;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetBase<T, U> : INetBase<T>, IDisposable, IEvent<T, U> where T : INetConnection where U : NetEventArgs
{
	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_ParamsDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetClientReceivedEventArgs<T>> infoDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_HelperDecorator;

	[CompilerGenerated]
	private SocketEventHandler<U> m_MapperDecorator;

	[CompilerGenerated]
	private SocketEventHandler<U> m_ManagerDecorator;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_GetterDecorator;

	[CompilerGenerated]
	private int m_ProducerDecorator;

	[CompilerGenerated]
	private string m_StructProcess;

	[CompilerGenerated]
	private bool merchantProcess;

	internal static object callbackProcess;

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnConnected
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ParamsDecorator = value;
		}
	}

	public SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return infoDecorator;
		}
		[CompilerGenerated]
		set
		{
			infoDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return m_HelperDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_HelperDecorator = value;
		}
	}

	public SocketEventHandler<U> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return m_MapperDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_MapperDecorator = value;
		}
	}

	public SocketEventHandler<U> OnStopped
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ManagerDecorator = value;
		}
	}

	public SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return m_GetterDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_GetterDecorator = value;
		}
	}

	public virtual int Id
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			m_ProducerDecorator = value;
		}
	}

	public virtual string Name { get; internal set; }

	public virtual string Key
	{
		[CompilerGenerated]
		get
		{
			return m_StructProcess;
		}
		[CompilerGenerated]
		internal set
		{
			m_StructProcess = value;
		}
	}

	public virtual bool Running
	{
		[CompilerGenerated]
		get
		{
			return merchantProcess;
		}
		[CompilerGenerated]
		protected set
		{
			merchantProcess = value;
		}
	}

	public abstract void Start();

	public abstract void Stop();

	protected virtual void OnConnectedHandler(NetClientEventArgs<T> netClientEventArgs_0)
	{
		OnConnected?.Invoke(netClientEventArgs_0);
	}

	protected virtual void OnReceivedHandler(NetClientReceivedEventArgs<T> netClientReceivedEventArgs_0)
	{
		OnReceived?.Invoke(netClientReceivedEventArgs_0);
	}

	protected virtual void OnDisconnectedHandler(NetClientEventArgs<T> netClientEventArgs_0)
	{
		OnDisconnected?.Invoke(netClientEventArgs_0);
	}

	protected virtual void OnStartedHandler(U args)
	{
		OnStarted?.Invoke(args);
	}

	protected virtual void OnStoppedHandler(U args)
	{
		OnStopped?.Invoke(args);
	}

	protected virtual void OnExceptionHandler(NetClientEventArgs<T> netClientEventArgs_0)
	{
		OnException?.Invoke(netClientEventArgs_0);
	}

	public abstract void Dispose();

	internal static bool GetThread()
	{
		return callbackProcess == null;
	}
}
