using System;
using Command.Listeners;

namespace DotSpatial.Topology.KDTree;

public class KeySizeException : Exception
{
	public KeySizeException()
		: base(AccountProcess.KeySizeException)
	{
	}
}
