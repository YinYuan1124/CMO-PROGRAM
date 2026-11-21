using System;
using Command.Listeners;

namespace DotSpatial.Topology.KDTree;

public class KeyDuplicateException : Exception
{
	public KeyDuplicateException()
		: base(AccountProcess.KeyDuplicateException)
	{
	}
}
