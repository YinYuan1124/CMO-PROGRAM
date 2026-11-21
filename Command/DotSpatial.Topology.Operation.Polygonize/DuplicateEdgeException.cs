using System;
using Command.Listeners;

namespace DotSpatial.Topology.Operation.Polygonize;

public class DuplicateEdgeException : Exception
{
	public DuplicateEdgeException()
		: base(AccountProcess.DuplicateEdgeException)
	{
	}
}
