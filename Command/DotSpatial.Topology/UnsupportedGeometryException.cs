using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class UnsupportedGeometryException : Exception
{
	public UnsupportedGeometryException()
		: base(AccountProcess.UnsupportedGeometryException)
	{
	}
}
