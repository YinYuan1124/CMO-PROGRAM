using System;

namespace Command_Core;

public sealed class PlatformComponentNotFoundException : Exception
{
	public PlatformComponentNotFoundException(string string_0)
		: base(string_0)
	{
	}

	public PlatformComponentNotFoundException()
	{
	}
}
