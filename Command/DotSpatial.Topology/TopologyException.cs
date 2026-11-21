using System;

namespace DotSpatial.Topology;

public class TopologyException : ApplicationException
{
	private readonly Coordinate m_WorkerProcess;

	public virtual Coordinate Coordinate => m_WorkerProcess;

	public TopologyException(string string_0)
		: base(string_0)
	{
	}

	public TopologyException(string string_0, Coordinate coordinate_0)
		: base(ValidateRule(string_0, coordinate_0))
	{
		m_WorkerProcess = new Coordinate(coordinate_0);
	}

	private static string ValidateRule(string string_0, Coordinate coordinate_0)
	{
		if (coordinate_0 == null)
		{
			return string_0;
		}
		return string_0 + " [ " + ((object)coordinate_0)?.ToString() + " ]";
	}
}
