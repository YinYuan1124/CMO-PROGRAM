using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets.Utils;

public class NetworkHelper
{
	[CompilerGenerated]
	private sealed class RuleMerchantPage
	{
		public int port;

		internal bool FindInterruptibleMapping(TcpConnectionInformation x)
		{
			return x.LocalEndPoint.Port == port;
		}

		internal bool SetInterruptibleMapping(IPEndPoint x)
		{
			return x.Port == port;
		}

		internal bool FillInterruptibleMapping(IPEndPoint x)
		{
			return x.Port == port;
		}
	}

	[CompilerGenerated]
	private sealed class ObjectPrototype
	{
		public int remote;

		public int local;

		internal bool CalculateInterruptibleMapping(TcpConnectionInformation x)
		{
			return x.RemoteEndPoint.Port == remote;
		}

		internal bool PopInterruptibleMapping(TcpConnectionInformation x)
		{
			return x.LocalEndPoint.Port == local;
		}

		internal bool InstantiateInterruptibleMapping(TcpConnectionInformation x)
		{
			if (x.LocalEndPoint.Port == local)
			{
				return x.RemoteEndPoint.Port == remote;
			}
			return false;
		}
	}

	public static bool LocalPortUsed(int int_0)
	{
		IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
		if (iPGlobalProperties.GetActiveTcpConnections().FirstOrDefault((TcpConnectionInformation x) => x.LocalEndPoint.Port == int_0) == null)
		{
			if (iPGlobalProperties.GetActiveTcpListeners().FirstOrDefault((IPEndPoint x) => x.Port == int_0) == null)
			{
				if (iPGlobalProperties.GetActiveUdpListeners().FirstOrDefault((IPEndPoint x) => x.Port == int_0) == null)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public static TcpConnectionInformation GetTcpConnectionInformation(int int_0, int int_1 = 0)
	{
		IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
		Func<TcpConnectionInformation, bool> func = null;
		if (int_0 > 0 && int_1 > 0)
		{
			func = (TcpConnectionInformation x) => x.LocalEndPoint.Port == int_0 && x.RemoteEndPoint.Port == int_1;
			if (iPGlobalProperties != null)
			{
				goto IL_00c1;
			}
		}
		else if (int_0 <= 0)
		{
			if (int_1 <= 0)
			{
				throw new ArgumentException("local and remote is invalid.");
			}
			func = (TcpConnectionInformation x) => x.RemoteEndPoint.Port == int_1;
			if (iPGlobalProperties != null)
			{
				goto IL_00c1;
			}
		}
		else
		{
			func = (TcpConnectionInformation x) => x.LocalEndPoint.Port == int_0;
			if (iPGlobalProperties != null)
			{
				goto IL_00c1;
			}
		}
		return null;
		IL_00c1:
		return iPGlobalProperties.GetActiveTcpConnections()?.FirstOrDefault(func);
	}

	public static IPAddress[] GetHostAddresses(string string_0 = null)
	{
		return Dns.GetHostAddresses(string_0 ?? Dns.GetHostName());
	}
}
