using System;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface ITcpConnection : IEvent<ITcpConnection, NetClientEventArgs<ITcpConnection>>, IDisposable, INetConnection
{
	int ConnectTimeout { get; }

	ITcpListener Listener { get; }
}
