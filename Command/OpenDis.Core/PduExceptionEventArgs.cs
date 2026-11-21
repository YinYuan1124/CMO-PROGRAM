using System;
using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public class PduExceptionEventArgs : EventArgs
{
	[CompilerGenerated]
	private Exception pageCallback;

	public Exception Exception
	{
		[CompilerGenerated]
		get
		{
			return pageCallback;
		}
		[CompilerGenerated]
		set
		{
			pageCallback = value;
		}
	}

	public PduExceptionEventArgs(Exception exception_0)
	{
		Exception = exception_0;
	}
}
