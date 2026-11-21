namespace DotSpatial.Topology;

public interface IMatrix4 : IMatrix, IMatrixD
{
	IMatrix4 RotateZ(double double_0);

	IMatrix4 RotateX(double double_0);

	IMatrix4 RotateY(double double_0);

	IMatrix4 Translate(double double_0, double double_1, double double_2);
}
