namespace DotSpatial.Topology.Simplify;

public class TaggedLineSegment : LineSegment
{
	private readonly int _ValueThread;

	private readonly IGeometry tokenizerThread;

	public virtual IGeometry Parent => tokenizerThread;

	public virtual int Index => _ValueThread;

	public TaggedLineSegment(Coordinate coordinate_0, Coordinate coordinate_1, IGeometry igeometry_0, int int_0)
		: base(coordinate_0, coordinate_1)
	{
		tokenizerThread = igeometry_0;
		_ValueThread = int_0;
	}

	public TaggedLineSegment(Coordinate coordinate_0, Coordinate coordinate_1)
		: this(coordinate_0, coordinate_1, null, -1)
	{
	}
}
