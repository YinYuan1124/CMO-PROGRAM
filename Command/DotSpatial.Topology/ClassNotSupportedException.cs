using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class ClassNotSupportedException : Exception
{
	public ClassNotSupportedException(string string_0)
		: base(AccountProcess.ClassNotSupportedException_S.Replace("%S", string_0))
	{
	}
}
