namespace GodSharp.Sockets.Abstractions.Events;

public interface INetEventMethods<T, U> where T : INetConnection where U : NetEventArgs
{
	void OnConnectedHandler(NetClientEventArgs<T> netClientEventArgs_0);

	void OnReceivedHandler(NetClientReceivedEventArgs<T> netClientReceivedEventArgs_0);

	void OnDisconnectedHandler(NetClientEventArgs<T> netClientEventArgs_0);

	void OnStartedHandler(U args);

	void OnStoppedHandler(U args);

	void OnExceptionHandler(NetClientEventArgs<T> netClientEventArgs_0);
}
