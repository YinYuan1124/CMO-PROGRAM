using System;

namespace Command_Core;

public sealed class DBFileNotFoundException : Exception
{
	public DBFileNotFoundException(string string_0)
		: base(string_0)
	{
	}
}
