using System;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public abstract class NetEventArgs
{
	[CompilerGenerated]
	private Exception serverDecorator;

	public Exception Exception
	{
		[CompilerGenerated]
		get
		{
			return serverDecorator;
		}
		[CompilerGenerated]
		internal set
		{
			serverDecorator = value;
		}
	}
}
