using System;
using Command.Listeners;

namespace DotSpatial.Topology.Operation.Polygonize;

public class NullEdgeException : Exception
{
	public NullEdgeException()
		: base(AccountProcess.NullEdgeException)
	{
	}
}
