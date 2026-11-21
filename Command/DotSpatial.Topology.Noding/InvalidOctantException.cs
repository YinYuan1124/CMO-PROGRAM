using System;
using Command.Listeners;

namespace DotSpatial.Topology.Noding;

public class InvalidOctantException : Exception
{
	public InvalidOctantException(string string_0)
		: base(AccountProcess.InvalidOctantException_S.Replace("%S", string_0))
	{
	}
}
