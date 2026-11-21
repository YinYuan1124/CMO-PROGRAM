namespace DotSpatial.Topology.Operation.Valid;

public class TopologyValidationError
{
	private static readonly string[] m_IteratorThread;

	private readonly TopologyValidationErrorType _InitializerThread;

	private readonly Coordinate roleThread;

	public virtual Coordinate Coordinate => roleThread;

	public virtual TopologyValidationErrorType ErrorType => _InitializerThread;

	public virtual string Message => m_IteratorThread[(int)_InitializerThread];

	public TopologyValidationError(TopologyValidationErrorType topologyValidationErrorType_0, Coordinate coordinate_0)
	{
		_InitializerThread = topologyValidationErrorType_0;
		if (coordinate_0 != null)
		{
			roleThread = (Coordinate)coordinate_0.Clone();
		}
	}

	public TopologyValidationError(TopologyValidationErrorType topologyValidationErrorType_0)
		: this(topologyValidationErrorType_0, null)
	{
	}

	public override string ToString()
	{
		return Message + " at or near point " + (object)roleThread;
	}

	static TopologyValidationError()
	{
		m_IteratorThread = new string[11]
		{
			"Topology Validation Error", "Repeated Point", "Hole lies outside shell", "Holes are nested", "Interior is disconnected", "Self-intersection", "Ring Self-intersection", "Nested shells", "Duplicate Rings", "Too few points in geometry component",
			"Invalid Coordinate"
		};
	}
}
