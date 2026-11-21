namespace DotSpatial.Topology;

public interface IMatrixD : IMatrix
{
	double[,] Values { get; set; }

	IMatrixD Multiply(double double_0);

	IMatrixD Multiply(IMatrixD imatrixD_0);
}
