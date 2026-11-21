namespace DotSpatial.Topology;

public interface IVector
{
	double Length { get; set; }

	double Length2D { get; set; }

	double Phi { get; set; }

	double Theta { get; set; }

	IVector TransformCoordinate(IMatrix4 imatrix4_0);

	IMatrixD ToMatrix();

	double Norm2();

	IPoint ToPoint();

	Coordinate ToCoordinate();

	ILineSegment ToLineSegment();

	void Normalize();

	IVector Cross(IVector ivector_0);

	double Dot(IVector ivector_0);

	bool Intersects(IVector ivector_0);

	bool Equals(IVector ivector_0);

	IVector Subtract(IVector ivector_0);

	IVector Add(IVector ivector_0);

	IVector Multiply(double double_0);

	IVector RotateX(double double_0);

	IVector RotateY(double double_0);

	IVector RotateZ(double double_0);
}
