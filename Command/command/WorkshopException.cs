using System;

namespace Command;

public class WorkshopException : Exception
{
	public WorkshopException()
	{
	}

	public WorkshopException(string string_0)
		: base(string_0)
	{
	}
}
