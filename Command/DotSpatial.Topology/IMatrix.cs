namespace DotSpatial.Topology;

public interface IMatrix
{
	int NumRows { get; }

	int NumColumns { get; }

	IMatrix Multiply(IMatrix imatrix_0);
}
