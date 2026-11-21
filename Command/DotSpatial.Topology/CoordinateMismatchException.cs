using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class CoordinateMismatchException : ArgumentException
{
	public CoordinateMismatchException()
		: base(AccountProcess.CoordinateMismatchException)
	{
	}
}
