using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace GodSharp.Sockets;

public static class ITcpConnectionExtensions
{
	[CompilerGenerated]
	private sealed class MerchantPrototype
	{
		public ITcpConnection connection;

		public byte[] buffer;

		internal int ValidateInterruptibleMapping()
		{
			return connection.Instance.Send(buffer);
		}
	}

	[CompilerGenerated]
	private sealed class CallbackPrototype
	{
		public ITcpConnection connection;

		public string str;

		public Encoding encoding;

		internal int LoginInterruptibleMapping()
		{
			return connection.Instance.Send(str, encoding);
		}
	}

	[CompilerGenerated]
	private sealed class AnnotationProcessResolver
	{
		public ITcpConnection connection;

		public byte[] buffer;

		public int offset;

		public int size;

		public SocketFlags socketFlags;

		internal int GetInterruptibleMapping()
		{
			return connection.Instance.Send(buffer, offset, size, socketFlags);
		}
	}

	[CompilerGenerated]
	private sealed class UtilsCallbackCandidate
	{
		public ITcpConnection connection;

		public SocketAsyncEventArgs e;

		internal bool WriteInterruptibleMapping()
		{
			return connection.Instance.SendAsync(e);
		}
	}

	[CompilerGenerated]
	private sealed class ListenerCollectionTask
	{
		public ITcpConnection connection;

		public string str;

		public AsyncCallback callback;

		public object state;

		public Encoding encoding;

		internal IAsyncResult NewInterruptibleMapping()
		{
			return connection.Instance.BeginSend(str, callback, state, encoding);
		}
	}

	[CompilerGenerated]
	private sealed class DecoratorPrototype
	{
		public ITcpConnection connection;

		public IAsyncResult asyncResult;

		internal int PushInterruptibleMapping()
		{
			return connection.Instance.EndSend(asyncResult);
		}
	}

	[CompilerGenerated]
	private sealed class AttrThreadBridge
	{
		public ITcpConnection connection;

		public byte[] buffer;

		internal int InvokeInterruptibleMapping()
		{
			return connection.Instance.Receive(buffer);
		}
	}

	[CompilerGenerated]
	private sealed class ProcessPrototype
	{
		public ITcpConnection connection;

		public SocketAsyncEventArgs e;

		internal bool SetupInterruptibleMapping()
		{
			return connection.Instance.ReceiveAsync(e);
		}
	}

	[CompilerGenerated]
	private sealed class ThreadPrototype
	{
		public ITcpConnection connection;

		public IAsyncResult asyncResult;

		internal int ExcludeInterruptibleMapping()
		{
			return connection.Instance.EndReceive(asyncResult);
		}
	}

	private static T UpdateProcess<T>(ITcpConnection itcpConnection_0, Func<T> func_0, T gparam_0)
	{
		if (InsertProcess(itcpConnection_0))
		{
			return func_0();
		}
		return gparam_0;
	}

	private static bool InsertProcess(ITcpConnection itcpConnection_0)
	{
		if (itcpConnection_0 == null)
		{
			return false;
		}
		if (itcpConnection_0.Listener == null)
		{
			return false;
		}
		if (itcpConnection_0.Listener.Running)
		{
			return true;
		}
		return false;
	}

	public static int Send(this ITcpConnection itcpConnection_0, byte[] byte_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.Send(byte_0), -1);
	}

	public static int Send(this ITcpConnection itcpConnection_0, string string_0, Encoding encoding_0 = null)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.Send(string_0, encoding_0), -1);
	}

	public static int Send(this ITcpConnection itcpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0 = SocketFlags.None)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.Send(byte_0, int_0, int_1, socketFlags_0), -1);
	}

	public static bool SendAsync(this ITcpConnection itcpConnection_0, SocketAsyncEventArgs socketAsyncEventArgs_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.SendAsync(socketAsyncEventArgs_0), gparam_0: false);
	}

	public static IAsyncResult BeginSend(this ITcpConnection itcpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0, out SocketError socketError_0, AsyncCallback asyncCallback_0, object object_0)
	{
		socketError_0 = SocketError.Success;
		if (InsertProcess(itcpConnection_0))
		{
			return itcpConnection_0.Instance.BeginSend(byte_0, int_0, int_1, socketFlags_0, out socketError_0, asyncCallback_0, object_0);
		}
		return null;
	}

	public static IAsyncResult BeginSend(this ITcpConnection itcpConnection_0, string string_0, AsyncCallback asyncCallback_0, object object_0, Encoding encoding_0 = null)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.BeginSend(string_0, asyncCallback_0, object_0, encoding_0), null);
	}

	public static int EndSend(this ITcpConnection itcpConnection_0, IAsyncResult iasyncResult_0, out SocketError socketError_0)
	{
		socketError_0 = SocketError.Success;
		if (InsertProcess(itcpConnection_0))
		{
			return itcpConnection_0.Instance.EndSend(iasyncResult_0, out socketError_0);
		}
		return -1;
	}

	public static int EndSend(this ITcpConnection itcpConnection_0, IAsyncResult iasyncResult_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.EndSend(iasyncResult_0), -1);
	}

	public static int Receive(this ITcpConnection itcpConnection_0, byte[] byte_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.Receive(byte_0), -1);
	}

	public static bool ReceiveAsync(this ITcpConnection itcpConnection_0, SocketAsyncEventArgs socketAsyncEventArgs_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.ReceiveAsync(socketAsyncEventArgs_0), gparam_0: false);
	}

	public static IAsyncResult BeginReceive(this ITcpConnection itcpConnection_0, byte[] byte_0, int int_0, int int_1, SocketFlags socketFlags_0, out SocketError socketError_0, AsyncCallback asyncCallback_0, object object_0)
	{
		socketError_0 = SocketError.Success;
		if (InsertProcess(itcpConnection_0))
		{
			return itcpConnection_0.Instance.BeginReceive(byte_0, int_0, int_1, socketFlags_0, out socketError_0, asyncCallback_0, object_0);
		}
		return null;
	}

	public static int EndReceive(this ITcpConnection itcpConnection_0, IAsyncResult iasyncResult_0, out SocketError socketError_0)
	{
		socketError_0 = SocketError.Success;
		if (InsertProcess(itcpConnection_0))
		{
			return itcpConnection_0.Instance.EndReceive(iasyncResult_0, out socketError_0);
		}
		return -1;
	}

	public static int EndReceive(this ITcpConnection itcpConnection_0, IAsyncResult iasyncResult_0)
	{
		return UpdateProcess(itcpConnection_0, () => itcpConnection_0.Instance.EndReceive(iasyncResult_0), -1);
	}
}
