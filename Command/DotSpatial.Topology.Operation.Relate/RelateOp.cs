namespace DotSpatial.Topology.Operation.Relate;

public class RelateOp : GeometryGraphOperation
{
	private readonly RelateComputer _AuthenticationThread;

	public virtual IntersectionMatrix IntersectionMatrix => _AuthenticationThread.ComputeIm();

	public RelateOp(IGeometry igeometry_0, IGeometry igeometry_1)
		: base(igeometry_0, igeometry_1)
	{
		_AuthenticationThread = new RelateComputer(Arg);
	}

	public static IntersectionMatrix Relate(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		return new RelateOp(igeometry_0, igeometry_1).IntersectionMatrix;
	}
}
