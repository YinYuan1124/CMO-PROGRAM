using System;
using Command.Listeners;

namespace DotSpatial.Topology.KDTree;

public class KeyMissingException : Exception
{
	public KeyMissingException()
		: base(AccountProcess.KeyMissingException)
	{
	}
}
