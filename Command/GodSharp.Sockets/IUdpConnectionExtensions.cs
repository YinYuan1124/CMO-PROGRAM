using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace GodSharp.Sockets;

public static class IUdpConnectionExtensions
{
	[CompilerGenerated]
	private sealed class RulePrototype
	{
		public IUdpConnection connection;

		public byte[] buffer;

		public EndPoint remoteEP;

		internal int IncludeInterruptibleMapping()
		{
			return connection.Instance.SendTo(buffer, remoteEP);
		}
	}

	[CompilerGenerated]
	private sealed class IteratorProcessResolver
	{
		public IUdpConnection connection;

		public string str;

		public EndPoint remoteEP;

		internal int SearchInterruptibleMapping()
		{
			return connection.Instance.SendTo(str, remoteEP);
		}
	}

	[CompilerGenerated]
	private sealed class CollectionPrototype
	{
		public IUdpConnection connection;

		public byte[] buffer;

		public int offset;

		public int size;

		public SocketFlags socketFlags;

		public EndPoint remoteEP;

		internal int EnableInterruptibleMapping()
		{
			return connection.Instance.SendTo(buffer, offset, size, socketFlags, remoteEP);
		}
	}

	[CompilerGenerated]
	private sealed class ErrorDispatcherList
	{
		public IUdpConnection connection;

		public SocketAsyncEventArgs e;

		internal bool ChangeInterruptibleMapping()
		{
			return connection.Instance.SendToAsync(e);
		}
	}

	[CompilerGenerated]
	private sealed class InstancePrototype
	{
		public IUdpConnection connection;

		public byte[] buffer;

		public int offset;

		public int size;

		public SocketFlags socketFlags;

		public EndPoint remoteEP;

		public AsyncCallback callback;

		public object state;

		internal IAsyncResult InitInterruptibleMapping()
		{
			return connection.Instance.BeginSendTo(buffer, offset, size, socketFlags, remoteEP, callback, state);
		}
	}

	[CompilerGenerated]
	private sealed class ProcListenerManager
	{
		public IUdpConnection connection;

		public byte[] buffer;

		public EndPoint remoteEP;

		public AsyncCallback callback;

		public object state;

		internal IAsyncResult CheckInterruptibleMapping()
		{
			return connection.Instance.BeginSendTo(buffer, remoteEP, callback, state);
		}
	}

	[CompilerGenerated]
	private sealed class InitializerProcessResolver
	{
		public IUdpConnection connection;

		public string str;

		public EndPoint remoteEP;

		public AsyncCallback callback;

		public object state;

		public Encoding encoding;

		internal IAsyncResult ConcatInterruptibleMapping()
		{
			return connection.Instance.BeginSendTo(str, remoteEP, callback, state, encoding);
		}
	}

	[CompilerGenerated]
	private sealed class GlobalParameterMock
	{
		public IUdpConnection connection;

		public IAsyncResult asyncResult;

		internal int InterruptInterruptibleMapping()
		{
			return connection.Instance.EndSendTo(asyncResult);
		}
	}

	[CompilerGenerated]
	private sealed class IteratorCollectionRecord
	{
		public IUdpConnection connection;

		public SocketAsyncEventArgs e;

		internal bool RemoveInterruptibleMapping()
		{
			return connection.Instance.ReceiveFromAsync(e);
		}
	}

	private static T PrepareProcess<T>(IUdpConnection iudpConnection_0, Func<T> func_0, T gparam_0)
	{
		if (ReflectProcess(iudpConnection_0))
		{
			return func_0();
		}
		return gparam_0;
	}

	private static bool ReflectProcess(IUdpConnection iudpConnection_0)
	{
		if (iudpConnection_0 == null)
		{
			return false;
		}
		if (iudpConnection_0.Listener == null)
		{
			return false;
		}
		if (iudpConnection_0.Listener.Running)
		{
			return true;
		}
		return false;
	}

	public static int SendTo(this IUdpConnection iudpConnection_0, byte[] byte_0, EndPoint endPoint_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.SendTo(byte_0, endPoint_0), -1);
	}

	public static int SendTo(this IUdpConnection iudpConnection_0, string string_0, EndPoint endPoint_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.SendTo(string_0, endPoint_0), -1);
	}

	public static int SendTo(this IUdpConnection iudpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0, EndPoint endPoint_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.SendTo(byte_0, int_0, int_1, socketFlags_0, endPoint_0), -1);
	}

	public static bool SendToAsync(this IUdpConnection iudpConnection_0, SocketAsyncEventArgs socketAsyncEventArgs_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.SendToAsync(socketAsyncEventArgs_0), gparam_0: false);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection iudpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0, EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.BeginSendTo(byte_0, int_0, int_1, socketFlags_0, endPoint_0, asyncCallback_0, object_0), null);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection iudpConnection_0, byte[] byte_0, EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.BeginSendTo(byte_0, endPoint_0, asyncCallback_0, object_0), null);
	}

	public static IAsyncResult BeginSendTo(this IUdpConnection iudpConnection_0, string string_0, EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0, Encoding encoding_0 = null)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.BeginSendTo(string_0, endPoint_0, asyncCallback_0, object_0, encoding_0), null);
	}

	public static int EndSendTo(this IUdpConnection iudpConnection_0, IAsyncResult iasyncResult_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.EndSendTo(iasyncResult_0), -1);
	}

	public static int ReceiveFrom(this IUdpConnection iudpConnection_0, byte[] byte_0, ref EndPoint endPoint_0)
	{
		if (ReflectProcess(iudpConnection_0))
		{
			return iudpConnection_0.Instance.ReceiveFrom(byte_0, ref endPoint_0);
		}
		return -1;
	}

	public static bool ReceiveFromAsync(this IUdpConnection iudpConnection_0, SocketAsyncEventArgs socketAsyncEventArgs_0)
	{
		return PrepareProcess(iudpConnection_0, () => iudpConnection_0.Instance.ReceiveFromAsync(socketAsyncEventArgs_0), gparam_0: false);
	}

	public static IAsyncResult BeginReceiveFrom(this IUdpConnection iudpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0, ref EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0)
	{
		if (ReflectProcess(iudpConnection_0))
		{
			return iudpConnection_0.Instance.BeginReceiveFrom(byte_0, int_0, int_1, socketFlags_0, ref endPoint_0, asyncCallback_0, object_0);
		}
		return null;
	}

	public static int EndReceiveFrom(this IUdpConnection iudpConnection_0, IAsyncResult iasyncResult_0, ref EndPoint endPoint_0)
	{
		if (ReflectProcess(iudpConnection_0))
		{
			return iudpConnection_0.Instance.EndReceiveFrom(iasyncResult_0, ref endPoint_0);
		}
		return -1;
	}
}
