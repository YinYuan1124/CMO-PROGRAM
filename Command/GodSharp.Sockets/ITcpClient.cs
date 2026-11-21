using System;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface ITcpClient : INetBase<ITcpConnection>, IDisposable, IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>, ITcpClientEvents
{
	ITcpConnection Connection { get; }
}
