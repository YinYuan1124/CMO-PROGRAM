using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class InsufficientDimensionsException : ArgumentException
{
	public InsufficientDimensionsException()
		: base(AccountProcess.InsufficientDimensions)
	{
	}

	public InsufficientDimensionsException(string string_0)
		: base(AccountProcess.InsufficientDimensions_S.Replace("%S", string_0))
	{
	}
}
