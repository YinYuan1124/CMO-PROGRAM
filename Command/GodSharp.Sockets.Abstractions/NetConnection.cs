using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetConnection<T, U> : IEvent<T, U>, IDisposable where T : INetConnection where U : NetEventArgs
{
	[CompilerGenerated]
	private string processProcess;

	[CompilerGenerated]
	private Socket ruleProcess;

	[CompilerGenerated]
	private IPEndPoint m_CollectionProcess;

	[CompilerGenerated]
	private IPEndPoint m_InstanceProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientReceivedEventArgs<T>> parameterProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_ExpressionProcess;

	[CompilerGenerated]
	private SocketEventHandler<U> dispatcherProcess;

	[CompilerGenerated]
	private SocketEventHandler<NetClientEventArgs<T>> m_ConfigProcess;

	internal static object m_RegistryProcess;

	public virtual int Id { get; internal set; }

	public virtual string Name
	{
		[CompilerGenerated]
		get
		{
			return processProcess;
		}
		[CompilerGenerated]
		internal set
		{
			processProcess = value;
		}
	}

	public virtual string Key { get; internal set; }

	public virtual Socket Instance
	{
		[CompilerGenerated]
		get
		{
			return ruleProcess;
		}
		[CompilerGenerated]
		protected set
		{
			ruleProcess = value;
		}
	}

	public virtual IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionProcess;
		}
		[CompilerGenerated]
		protected set
		{
			m_CollectionProcess = value;
		}
	}

	public virtual IPEndPoint RemoteEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceProcess;
		}
		[CompilerGenerated]
		protected set
		{
			m_InstanceProcess = value;
		}
	}

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnConnected { get; internal set; }

	public virtual SocketEventHandler<NetClientReceivedEventArgs<T>> OnReceived
	{
		[CompilerGenerated]
		get
		{
			return parameterProcess;
		}
		[CompilerGenerated]
		internal set
		{
			parameterProcess = value;
		}
	}

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnDisconnected
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionProcess;
		}
		[CompilerGenerated]
		internal set
		{
			m_ExpressionProcess = value;
		}
	}

	public virtual SocketEventHandler<U> OnStarted
	{
		[CompilerGenerated]
		get
		{
			return dispatcherProcess;
		}
		[CompilerGenerated]
		internal set
		{
			dispatcherProcess = value;
		}
	}

	public virtual SocketEventHandler<U> OnStopped { get; internal set; }

	public virtual SocketEventHandler<NetClientEventArgs<T>> OnException
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigProcess;
		}
		[CompilerGenerated]
		internal set
		{
			m_ConfigProcess = value;
		}
	}

	public abstract void Start();

	public abstract void Stop();

	public abstract void Dispose();

	internal static bool NewThread()
	{
		return m_RegistryProcess == null;
	}
}
