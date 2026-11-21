using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Spatial.Euclidean;

namespace CSMaterial;

public static class CSMath
{
	public struct Vector3
	{
		public double x;

		public double y;

		public double z;

		public double len => Math.Sqrt(x * x + y * y + z * z);

		public Vector3(double double_0, double double_1, double double_2)
		{
			x = double_0;
			y = double_1;
			z = double_2;
		}

		public Vector3(Sphere3 sphere3_0)
		{
			x = sphere3_0.r * Math.Cos(sphere3_0.theta) * Math.Cos(sphere3_0.phi);
			y = sphere3_0.r * Math.Sin(sphere3_0.theta);
			z = sphere3_0.r * Math.Cos(sphere3_0.theta) * Math.Sin(sphere3_0.phi);
		}

		public DenseVector ToDV()
		{
			DenseVector val = new DenseVector(3);
			val[0] = x;
			val[1] = y;
			val[2] = z;
			return val;
		}
	}

	public struct Sphere3
	{
		public double r;

		public double theta;

		public double phi;

		public Sphere3(double double_0, double double_1, double double_2)
		{
			r = double_0;
			theta = double_1;
			phi = double_2;
		}

		public Sphere3(Vector3 vector3_0)
		{
			r = vector3_0.len;
			theta = Math.Acos(vector3_0.z / r);
			phi = Math.Atan2(vector3_0.y, vector3_0.x);
		}
	}

	public static double PI_dividedBy_180;

	public static double ClosureRateApprox(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8, double double_9)
	{
		DenseVector val = new Vector3(new Sphere3(6371000.0 + double_2, 0.0174532925199433 * double_0, 0.0174532925199433 * double_1)).ToDV();
		DenseVector val2 = new Vector3(new Sphere3(6371000.0 + double_7, 0.0174532925199433 * double_5, 0.0174532925199433 * double_6)).ToDV();
		DenseVector val3 = val2 - val;
		DenseVector val4 = new Vector3(0.0, double_3 * (463.0 / 900.0) * Math.Cos(0.0174532925199433 * double_4), double_3 * (463.0 / 900.0) * Math.Sin(0.0174532925199433 * double_4)).ToDV();
		DenseVector val5 = new Vector3(0.0, double_8 * (463.0 / 900.0) * Math.Cos(0.0174532925199433 * double_9), double_8 * (463.0 / 900.0) * Math.Sin(0.0174532925199433 * double_9)).ToDV();
		Matrix<double> obj = Matrix3D.RotationTo(UnitVector3D.XAxis, new UnitVector3D(val.Values));
		Matrix<double> val6 = Matrix3D.RotationTo(UnitVector3D.XAxis, new UnitVector3D(val2.Values));
		Vector<double> obj2 = obj * val4;
		Vector<double> val7 = val6 * val5;
		return (obj2 - val7).DotProduct(val3) / ((Vector<double>)val3).L2Norm() * 3600.0 / 1852.0;
	}

	public static bool IsFinite(double double_0)
	{
		if (double_0 <= double.NegativeInfinity)
		{
			return false;
		}
		return double_0 < double.PositiveInfinity;
	}

	public static bool IsFinite(float float_0)
	{
		if (float_0 <= float.NegativeInfinity)
		{
			return false;
		}
		return float_0 < float.PositiveInfinity;
	}

	static CSMath()
	{
		PI_dividedBy_180 = Math.PI / 180.0;
	}
}
