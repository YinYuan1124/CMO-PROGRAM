using System;
using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets;

public interface IUdpClient : INetBase<IUdpConnection>, IDisposable, IEvent<IUdpConnection, NetClientEventArgs<IUdpConnection>>, IUdpClientEvents
{
	IUdpConnection Connection { get; }
}
