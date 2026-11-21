using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation;

public class GeometryGraphOperation
{
	protected readonly GeometryGraph[] Arg;

	private LineIntersector mappingThread = new RobustLineIntersector();

	[CompilerGenerated]
	private PrecisionModel mockThread;

	protected LineIntersector LineIntersector
	{
		get
		{
			return mappingThread;
		}
		set
		{
			mappingThread = value;
		}
	}

	protected PrecisionModel ResultPrecisionModel
	{
		[CompilerGenerated]
		get
		{
			return mockThread;
		}
		[CompilerGenerated]
		set
		{
			mockThread = value;
		}
	}

	protected PrecisionModel ComputationPrecision
	{
		get
		{
			return ResultPrecisionModel;
		}
		set
		{
			ResultPrecisionModel = value;
			LineIntersector.PrecisionModel = ResultPrecisionModel;
		}
	}

	public GeometryGraphOperation(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		ComputationPrecision = ((igeometry_0.PrecisionModel.CompareTo(igeometry_1.PrecisionModel) < 0) ? new PrecisionModel(igeometry_1.PrecisionModel) : new PrecisionModel(igeometry_0.PrecisionModel));
		Arg = new GeometryGraph[2];
		Arg[0] = new GeometryGraph(0, igeometry_0);
		Arg[1] = new GeometryGraph(1, igeometry_1);
	}

	public GeometryGraphOperation(IGeometry igeometry_0)
	{
		ComputationPrecision = new PrecisionModel(igeometry_0.PrecisionModel);
		Arg = new GeometryGraph[1];
		Arg[0] = new GeometryGraph(0, igeometry_0);
	}

	public IGeometry GetArgGeometry(int int_0)
	{
		return Arg[int_0].Geometry;
	}
}
