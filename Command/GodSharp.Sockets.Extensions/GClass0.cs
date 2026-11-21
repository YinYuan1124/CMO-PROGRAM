using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Extensions;

public static class GClass0
{
	[CompilerGenerated]
	private sealed class StructConfigManager
	{
		public int port;

		internal IPEndPoint ReflectInterruptibleMapping(IPAddress x)
		{
			return new IPEndPoint(x, port);
		}
	}

	public static IPEndPoint As(this IPAddress ipaddress_0, int int_0)
	{
		return new IPEndPoint(ipaddress_0, int_0);
	}

	public static IEnumerable<IPEndPoint> As(this IPAddress[] ipaddress_0, int int_0)
	{
		return ipaddress_0?.Select((IPAddress x) => new IPEndPoint(x, int_0));
	}
}
