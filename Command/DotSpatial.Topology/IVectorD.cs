using System;

namespace DotSpatial.Topology;

public interface IVectorD : ICloneable, IComparable, ICoordinate
{
	double Length { get; }

	Vector Add(Vector vector_0);

	Vector Cross(Vector vector_0);

	double Dot(Vector vector_0);

	Vector Multiply(double double_0);

	void Normalize();

	Vector Subtract(Vector vector_0);
}
