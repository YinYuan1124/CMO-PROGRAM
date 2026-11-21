namespace DotSpatial.Topology.Index.Sweepline;

public class SweepLineInterval
{
	private readonly object _SingletonCollection;

	private readonly double _RecordCollection;

	private readonly double _ExceptionCollection;

	public virtual double Min => _ExceptionCollection;

	public virtual double Max => _RecordCollection;

	public virtual object Item => _SingletonCollection;

	public SweepLineInterval(double double_0, double double_1)
		: this(double_0, double_1, null)
	{
	}

	public SweepLineInterval(double double_0, double double_1, object object_0)
	{
		_ExceptionCollection = ((double_0 < double_1) ? double_0 : double_1);
		_RecordCollection = ((double_1 <= double_0) ? double_0 : double_1);
		_SingletonCollection = object_0;
	}
}
