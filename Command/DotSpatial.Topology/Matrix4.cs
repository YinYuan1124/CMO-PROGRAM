using System;
using CSMaterial;

namespace DotSpatial.Topology;

public class Matrix4 : MatrixD, IMatrix, IMatrix4, IMatrixD
{
	public static Matrix4 Identity => new Matrix4();

	public Matrix4()
		: base(4)
	{
		base.Values[0, 0] = 1.0;
		base.Values[1, 1] = 1.0;
		base.Values[2, 2] = 1.0;
		base.Values[3, 3] = 1.0;
	}

	public IMatrix4 RotateX(double double_0)
	{
		Matrix4 imatrixD_ = RotationX(double_0);
		return Multiply(imatrixD_) as IMatrix4;
	}

	public IMatrix4 RotateY(double double_0)
	{
		Matrix4 imatrixD_ = RotationY(double_0);
		return Multiply(imatrixD_) as IMatrix4;
	}

	public IMatrix4 RotateZ(double double_0)
	{
		Matrix4 imatrixD_ = RotationZ(double_0);
		return Multiply(imatrixD_) as IMatrix4;
	}

	public IMatrix4 Translate(double double_0, double double_1, double double_2)
	{
		Matrix4 imatrixD_ = Translation(double_0, double_1, double_2);
		return Multiply(imatrixD_) as IMatrix4;
	}

	public static Matrix4 RotationX(double double_0)
	{
		Matrix4 matrix = new Matrix4();
		double num = double_0 * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[1, 1] = Math.Cos(num);
		values[2, 1] = 0.0 - Math.Sin(num);
		values[1, 2] = Math.Sin(num);
		values[2, 2] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 RotationY(double double_0)
	{
		Matrix4 matrix = new Matrix4();
		double num = double_0 * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[0, 0] = Math.Cos(num);
		values[0, 2] = 0.0 - Math.Sin(num);
		values[2, 0] = Math.Sin(num);
		values[2, 2] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 RotationZ(double double_0)
	{
		Matrix4 matrix = new Matrix4();
		double num = double_0 * CSMath.PI_dividedBy_180;
		double[,] values = matrix.Values;
		values[0, 0] = Math.Cos(num);
		values[0, 1] = 0.0 - Math.Sin(num);
		values[1, 0] = Math.Sin(num);
		values[1, 1] = Math.Cos(num);
		return matrix;
	}

	public static Matrix4 Translation(double double_0, double double_1, double double_2)
	{
		Matrix4 matrix = new Matrix4();
		double[,] values = matrix.Values;
		values[3, 0] = double_0;
		values[3, 1] = double_1;
		values[3, 2] = double_2;
		return matrix;
	}
}
