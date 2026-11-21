using System;
using System.Net;
using System.Net.Sockets;
using GodSharp.Sockets;
using GodSharp.Sockets.Abstractions;

namespace OpenDis.Common;

internal sealed class ProductDecorator : NetListener<IUdpConnection>, INetListener<IUdpConnection>, IDisposable, IUdpListener
{
	public ProductDecorator(IUdpConnection iudpConnection_0)
		: base(iudpConnection_0)
	{
	}

	protected override void OnBeginReceive(ref byte[] byte_0)
	{
		EndPoint remoteEP = Connection.ListenEndPoint.As();
		Connection.Instance.BeginReceiveFrom(byte_0, 0, byte_0.Length, SocketFlags.None, ref remoteEP, ReceivedCallback, remoteEP);
	}

	protected override T OnEndReceive<T>(IAsyncResult iasyncResult_0)
	{
		EndPoint endPoint = iasyncResult_0.AsyncState as EndPoint;
		return new ReceiveResult(Connection.Instance.EndReceiveFrom(iasyncResult_0, ref endPoint), endPoint.As()) as T;
	}

	protected override void OnReceiveHandling(byte[] byte_0, IPEndPoint ipendPoint_0 = null, IPEndPoint ipendPoint_1 = null)
	{
		Connection.OnReceived?.Invoke(new NetClientReceivedEventArgs<IUdpConnection>(Connection, byte_0, ipendPoint_0, ipendPoint_1));
	}

	protected override void OnStop(Exception exception_0)
	{
		Connection.OnDisconnected?.Invoke(new NetClientEventArgs<IUdpConnection>(Connection)
		{
			Exception = exception_0
		});
	}

	protected override void OnException(Exception exception_0)
	{
		Connection.OnException?.Invoke(new NetClientEventArgs<IUdpConnection>(Connection)
		{
			Exception = exception_0
		});
	}

	public override void Dispose()
	{
		Connection = null;
	}
}
