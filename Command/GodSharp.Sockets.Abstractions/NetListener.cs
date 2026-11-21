using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Abstractions;

public abstract class NetListener<T> : INetListener<T>, IDisposable where T : INetConnection
{
	protected class ReceiveResult
	{
		[CompilerGenerated]
		private int m_RegistryPrototype;

		[CompilerGenerated]
		private IPEndPoint m_DefinitionPrototype;

		internal static object m_ValPrototype;

		public int Length
		{
			[CompilerGenerated]
			get
			{
				return m_RegistryPrototype;
			}
			[CompilerGenerated]
			set
			{
				m_RegistryPrototype = value;
			}
		}

		public IPEndPoint RemoteEndPoint
		{
			[CompilerGenerated]
			get
			{
				return m_DefinitionPrototype;
			}
			[CompilerGenerated]
			set
			{
				m_DefinitionPrototype = value;
			}
		}

		public ReceiveResult()
		{
		}

		public ReceiveResult(int int_0, IPEndPoint ipendPoint_0)
		{
			Length = int_0;
			RemoteEndPoint = ipendPoint_0;
		}

		internal static bool VisitInterruptibleMapping()
		{
			return m_ValPrototype == null;
		}
	}

	private bool valProcess;

	private byte[] wrapperProcess;

	internal static object _ObserverProcess;

	public virtual T Connection { get; internal set; }

	public virtual bool Running
	{
		get
		{
			return valProcess;
		}
		internal set
		{
			valProcess = value;
		}
	}

	public NetListener(T connection)
	{
		if (connection == null)
		{
			throw new ArgumentNullException("connection");
		}
		Connection = connection;
	}

	public virtual void Start()
	{
		if (!Running)
		{
			try
			{
				Connection.Instance.KeepAlive(1000, 500);
				BeginReceive();
				Running = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}

	public void Stop()
	{
		if (!Running)
		{
			return;
		}
		Running = false;
		Exception exception_ = null;
		try
		{
			T connection = Connection;
			if (connection != null)
			{
				connection.Instance.Disconnect(reuseSocket: false);
			}
			connection = Connection;
			if (connection != null)
			{
				connection.Instance.Close();
			}
		}
		catch (Exception ex)
		{
			exception_ = ex;
		}
		OnStop(exception_);
	}

	protected abstract void OnStop(Exception exception_0);

	protected abstract void OnException(Exception exception_0);

	public void BeginReceive()
	{
		wrapperProcess = new byte[Connection.Instance.ReceiveBufferSize];
		OnBeginReceive(ref wrapperProcess);
	}

	protected abstract void OnBeginReceive(ref byte[] byte_0);

	public void ReceivedCallback(IAsyncResult iasyncResult_0)
	{
		bool flag = false;
		try
		{
			if (Running)
			{
				ReceiveResult receiveResult = OnEndReceive<ReceiveResult>(iasyncResult_0);
				if (receiveResult != null && receiveResult.Length > 0)
				{
					byte[] array = new byte[receiveResult.Length];
					Buffer.BlockCopy(wrapperProcess, 0, array, 0, receiveResult.Length);
					BeginReceive();
					OnReceiveHandling(array, receiveResult.RemoteEndPoint, Connection.LocalEndPoint);
				}
				else
				{
					flag = true;
				}
			}
		}
		catch (Exception exception_)
		{
			flag = true;
			OnException(exception_);
		}
		finally
		{
			if (flag)
			{
				Stop();
			}
		}
	}

	protected abstract U OnEndReceive<U>(IAsyncResult iasyncResult_0) where U : ReceiveResult, new();

	protected abstract void OnReceiveHandling(byte[] byte_0, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null);

	public abstract void Dispose();

	internal static bool InvokeThread()
	{
		return _ObserverProcess == null;
	}
}
