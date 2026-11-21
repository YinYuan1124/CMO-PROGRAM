using System;
using Command.Listeners;

namespace DotSpatial.Topology.KDTree;

public class NegativeArgumentException : ArgumentException
{
	public NegativeArgumentException(string string_0)
		: base(AccountProcess.ArgumentCannotBeNegative_S.Replace("%S", string_0))
	{
	}
}
