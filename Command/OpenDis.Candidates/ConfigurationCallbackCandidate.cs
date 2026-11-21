using System;
using System.Net;
using System.Net.Sockets;
using GodSharp.Sockets;
using GodSharp.Sockets.Abstractions;

namespace OpenDis.Candidates;

internal sealed class ConfigurationCallbackCandidate : NetListener<ITcpConnection>, INetListener<ITcpConnection>, IDisposable, ITcpListener
{
	public ConfigurationCallbackCandidate(ITcpConnection itcpConnection_0)
		: base(itcpConnection_0)
	{
	}

	protected override void OnBeginReceive(ref byte[] byte_0)
	{
		Connection.Instance.BeginReceive(byte_0, 0, byte_0.Length, SocketFlags.None, ReceivedCallback, null);
	}

	protected override T OnEndReceive<T>(IAsyncResult iasyncResult_0)
	{
		SocketError errorCode;
		return new ReceiveResult(Connection.Instance.EndReceive(iasyncResult_0, out errorCode), Connection.RemoteEndPoint) as T;
	}

	protected override void OnReceiveHandling(byte[] byte_0, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null)
	{
		Connection.OnReceived?.Invoke(new NetClientReceivedEventArgs<ITcpConnection>(Connection, byte_0, ipendPoint_0, ipendPoint_1));
	}

	protected override void OnStop(Exception exception_0)
	{
		Connection.OnDisconnected?.Invoke(new NetClientEventArgs<ITcpConnection>(Connection)
		{
			Exception = exception_0
		});
	}

	protected override void OnException(Exception exception_0)
	{
		Connection.OnException?.Invoke(new NetClientEventArgs<ITcpConnection>(Connection)
		{
			Exception = exception_0
		});
	}

	public override void Dispose()
	{
		Connection = null;
	}
}
