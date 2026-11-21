using System.Net;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class NetServerEventArgs : NetEventArgs
{
	[CompilerGenerated]
	private IPEndPoint m_AdapterDecorator;

	[CompilerGenerated]
	private ITcpConnection m_UtilsDecorator;

	public IPEndPoint LocalEndPoint
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			m_AdapterDecorator = value;
		}
	}

	public ITcpServer TcpServer { get; internal set; }

	public ITcpConnection Connection
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_UtilsDecorator = value;
		}
	}

	public NetServerEventArgs()
	{
	}

	public NetServerEventArgs(ITcpServer itcpServer_0, IPEndPoint ipendPoint_0 = null, ITcpConnection itcpConnection_0 = null)
	{
		if (itcpServer_0 != null)
		{
			TcpServer = itcpServer_0;
		}
		if (ipendPoint_0 != null)
		{
			LocalEndPoint = ipendPoint_0;
		}
		if (itcpConnection_0 != null)
		{
			Connection = itcpConnection_0;
		}
	}
}
