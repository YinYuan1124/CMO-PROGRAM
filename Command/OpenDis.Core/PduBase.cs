using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public abstract class PduBase
{
	[CompilerGenerated]
	private static bool queueCallback;

	[CompilerGenerated]
	private static bool paramCallback;

	public static bool TraceExceptions
	{
		[CompilerGenerated]
		get
		{
			return queueCallback;
		}
		[CompilerGenerated]
		set
		{
			queueCallback = value;
		}
	}

	public static bool ThrowExceptions { get; set; }

	public static bool FireExceptionEvents
	{
		[CompilerGenerated]
		get
		{
			return paramCallback;
		}
		[CompilerGenerated]
		set
		{
			paramCallback = value;
		}
	}
}
