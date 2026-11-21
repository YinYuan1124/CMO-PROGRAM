using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace GodSharp.Sockets;

public static class SocketExtensions
{
	public static int Send(this Socket socket_0, string string_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		return socket_0.Send(encoding_0.GetBytes(string_0));
	}

	public static IAsyncResult BeginSend(this Socket socket_0, string string_0, AsyncCallback asyncCallback_0, object object_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		byte[] bytes = encoding_0.GetBytes(string_0);
		return socket_0.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, asyncCallback_0, object_0);
	}

	public static int Send(this Socket socket_0, string string_0, SocketFlags socketFlags_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		return socket_0.Send(encoding_0.GetBytes(string_0), socketFlags_0);
	}

	public static int Send(this Socket socket_0, string string_0, SocketFlags socketFlags_0, out SocketError socketError_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		byte[] bytes = encoding_0.GetBytes(string_0);
		return socket_0.Send(bytes, 0, bytes.Length, socketFlags_0, out socketError_0);
	}

	public static int SendTo(this Socket socket_0, string string_0, EndPoint endPoint_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		return socket_0.SendTo(encoding_0.GetBytes(string_0), endPoint_0);
	}

	public static int SendTo(this Socket socket_0, string string_0, SocketFlags socketFlags_0, EndPoint endPoint_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		return socket_0.SendTo(encoding_0.GetBytes(string_0), socketFlags_0, endPoint_0);
	}

	public static IAsyncResult BeginSendTo(this Socket socket_0, byte[] byte_0, EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0)
	{
		return socket_0.BeginSendTo(byte_0, 0, byte_0.Length, SocketFlags.None, endPoint_0, asyncCallback_0, object_0);
	}

	public static IAsyncResult BeginSendTo(this Socket socket_0, string string_0, EndPoint endPoint_0, AsyncCallback asyncCallback_0, object object_0, Encoding encoding_0 = null)
	{
		if (encoding_0 == null)
		{
			encoding_0 = Encoding.UTF8;
		}
		byte[] bytes = encoding_0.GetBytes(string_0);
		return socket_0.BeginSendTo(bytes, 0, bytes.Length, SocketFlags.None, endPoint_0, asyncCallback_0, object_0);
	}

	public static void KeepAlive(this Socket socket_0, int int_0 = 5000, int int_1 = 1000)
	{
		byte[] array = new byte[Marshal.SizeOf(0u) * 3];
		BitConverter.GetBytes(1u).CopyTo(array, 0);
		BitConverter.GetBytes((uint)int_0).CopyTo(array, Marshal.SizeOf(0u));
		BitConverter.GetBytes((uint)int_1).CopyTo(array, Marshal.SizeOf(0u) * 2);
		socket_0.IOControl(IOControlCode.KeepAliveValues, array, null);
	}
}
