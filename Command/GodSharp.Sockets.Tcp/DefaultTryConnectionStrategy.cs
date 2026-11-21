using GodSharp.Sockets.Abstractions;

namespace GodSharp.Sockets.Tcp;

public class DefaultTryConnectionStrategy : ITryConnectionStrategy
{
	public int Handle(int int_0)
	{
		return int_0 % 20 * 3000;
	}
}
