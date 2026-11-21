using System;
using Command.Listeners;

namespace DotSpatial.Topology;

public class GeometryCollectionNotSupportedException : ApplicationException
{
	public GeometryCollectionNotSupportedException()
		: base(AccountProcess.GeometryCollectionNotSupportedException)
	{
	}
}
