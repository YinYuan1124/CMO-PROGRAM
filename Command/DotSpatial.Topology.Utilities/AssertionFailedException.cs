using System;

namespace DotSpatial.Topology.Utilities;

public class AssertionFailedException : ApplicationException
{
	public AssertionFailedException()
	{
	}

	public AssertionFailedException(string string_0)
		: base(string_0)
	{
	}
}
