using System;
using Command.Listeners;

namespace DotSpatial.Topology.GeometriesGraph;

public class TwoHorizontalEdgesException : Exception
{
	public TwoHorizontalEdgesException()
		: base(AccountProcess.TwoHorizontalEdgesException)
	{
	}
}
