using System;
using Command.Listeners;

namespace DotSpatial.Topology.KDTree;

public class NeighborsOutOfRangeException : ArgumentOutOfRangeException
{
	public NeighborsOutOfRangeException()
		: base(AccountProcess.ArgumentOutOfRangeException_S.Replace("%S", "numNeighbors"))
	{
	}
}
