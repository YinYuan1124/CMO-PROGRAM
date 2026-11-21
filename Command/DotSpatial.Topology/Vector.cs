using System;

namespace DotSpatial.Topology;

public class Vector : Coordinate
{
	public double Length
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}
		set
		{
			double length = Length;
			if (length == 0.0)
			{
				X = value;
				return;
			}
			double num = value / length;
			X *= num;
			Y *= num;
			Z *= num;
		}
	}

	public double Length2D
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y);
		}
		set
		{
			double length2D = Length2D;
			if (length2D == 0.0)
			{
				X = value;
				return;
			}
			double num = value / length2D;
			X *= num;
			Y *= num;
		}
	}

	public double Phi
	{
		get
		{
			double length = Length;
			if (length == 0.0)
			{
				return 0.0;
			}
			return Math.Asin(Z / length);
		}
		set
		{
			double length = Length;
			if (length == 0.0)
			{
				X = Math.Cos(value);
				Z = Math.Sin(value);
			}
			else
			{
				Z = length * Math.Sin(value);
				Length2D = length * Math.Cos(value);
			}
		}
	}

	public double Theta
	{
		get
		{
			if (Length2D == 0.0)
			{
				return 0.0;
			}
			double num = Math.Atan(Y / X);
			if (X < 0.0)
			{
				num = Math.PI - num;
			}
			if (X > 0.0 && Y < 0.0)
			{
				num = Math.PI * 2.0 + num;
			}
			return num;
		}
		set
		{
			double length2D = Length2D;
			if (length2D == 0.0)
			{
				X = Math.Cos(value);
				Y = Math.Sin(value);
			}
			else
			{
				X = length2D * Math.Cos(value);
				Y = length2D * Math.Sin(value);
			}
		}
	}

	public Vector()
	{
	}

	public Vector(Coordinate coordinate_0)
	{
		X = coordinate_0.X;
		Y = coordinate_0.Y;
		Z = coordinate_0.Z;
		LoginRule();
	}

	public Vector(ICoordinate icoordinate_0)
	{
		X = icoordinate_0.X;
		Y = icoordinate_0.Y;
		Z = icoordinate_0.Z;
	}

	public Vector(ILineSegmentBase ilineSegmentBase_0)
	{
		X = ilineSegmentBase_0.P1.X - ilineSegmentBase_0.P0.X;
		Y = ilineSegmentBase_0.P1.Y - ilineSegmentBase_0.P0.Y;
		Z = ilineSegmentBase_0.P1.Z - ilineSegmentBase_0.P0.Z;
	}

	public Vector(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		X = coordinate_1.X - coordinate_0.X;
		Y = coordinate_1.Y - coordinate_0.Y;
		Z = coordinate_1.Z - coordinate_0.Z;
	}

	public Vector(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		X = double_3 - double_0;
		Y = double_4 - double_1;
		Z = double_5 - double_2;
	}

	public Vector(double double_0, double double_1, double double_2)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
	}

	public Vector(double double_0, Angle angle_0, Angle angle_1)
	{
		X = double_0 * Angle.Cos(angle_0) * Angle.Cos(angle_1);
		Y = double_0 * Angle.Sin(angle_0) * Angle.Cos(angle_1);
		Z = double_0 * Angle.Sin(angle_1);
	}

	public Vector(double double_0, Angle angle_0)
	{
		X = double_0 * Angle.Cos(angle_0);
		Y = double_0 * Angle.Sin(angle_0);
		Z = 0.0;
	}

	public Vector(Vector vector_0)
	{
		X = vector_0.X;
		Y = vector_0.Y;
		Z = vector_0.Z;
	}

	public Vector(IMatrixD imatrixD_0)
	{
		X = imatrixD_0.Values[0, 0];
		Y = imatrixD_0.Values[0, 1];
		Z = imatrixD_0.Values[0, 2];
	}

	private void LoginRule()
	{
		if (double.IsNaN(X))
		{
			X = 0.0;
		}
		if (double.IsNaN(Y))
		{
			Y = 0.0;
		}
		if (double.IsNaN(Z))
		{
			Z = 0.0;
		}
	}

	public Vector Add(Vector vector_0)
	{
		return new Vector(X + vector_0.X, Y + vector_0.Y, Z + vector_0.Z);
	}

	public double Norm2()
	{
		return X * X + Y * Y + Z * Z;
	}

	public virtual Vector RotateX(double double_0)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationX(double_0)));
	}

	public virtual Vector RotateY(double double_0)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationY(double_0)));
	}

	public virtual Vector RotateZ(double double_0)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationZ(double_0)));
	}

	public IPoint ToPoint()
	{
		return new Point(X, Y, Z);
	}

	public ILineSegment ToLineSegment()
	{
		return new LineSegment(new Coordinate(0.0, 0.0, 0.0), ToCoordinate());
	}

	public Coordinate ToCoordinate()
	{
		return new Coordinate(X, Y, Z);
	}

	public Vector TransformCoordinate(IMatrix4 imatrix4_0)
	{
		double[,] values = ToMatrix().Multiply(imatrix4_0).Values;
		return new Vector(values[0, 0], values[0, 1], values[0, 2]);
	}

	public IMatrixD ToMatrix()
	{
		MatrixD matrixD = new MatrixD(1, 4);
		double[,] values = ((IMatrixD)matrixD).Values;
		values[0, 0] = base[0];
		values[0, 1] = base[1];
		values[0, 2] = base[2];
		values[0, 3] = 1.0;
		return matrixD;
	}

	public Vector Subtract(Vector vector_0)
	{
		return new Vector(X - vector_0.X, Y - vector_0.Y, Z - vector_0.Z);
	}

	public void Normalize()
	{
		double num = Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0) + Math.Pow(Z, 2.0));
		if (num > 0.0)
		{
			X /= num;
			Y /= num;
			Z /= num;
		}
	}

	public Vector Cross(Vector vector_0)
	{
		return new Vector
		{
			X = Y * vector_0.Z - Z * vector_0.Y,
			Y = Z * vector_0.X - X * vector_0.Z,
			Z = X * vector_0.Y - Y * vector_0.X
		};
	}

	public double Dot(Vector vector_0)
	{
		return X * vector_0.X + Y * vector_0.Y + Z * vector_0.Z;
	}

	public bool Intersects(Vector vector_0)
	{
		if (X == vector_0.X && Y == vector_0.Y && Z == vector_0.Z)
		{
			return true;
		}
		return false;
	}

	public bool Equals(Vector vector_0)
	{
		if (X == vector_0.X && Y == vector_0.Y && Z == vector_0.Z)
		{
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj.GetType() == typeof(Vector))
		{
			Vector vector = (Vector)obj;
			if (X == vector.X && Y == vector.Y)
			{
				return Z == vector.Z;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public Vector Multiply(double double_0)
	{
		return new Vector(X * double_0, Y * double_0, Z * double_0);
	}

	public static Vector Add(Vector vector_0, Vector vector_1)
	{
		return new Vector(vector_0.X + vector_1.X, vector_0.Y + vector_1.Y, vector_0.Z + vector_1.Z);
	}

	public static Vector CrossProduct(Vector vector_0, Vector vector_1)
	{
		return new Vector
		{
			X = vector_0.Y * vector_1.Z - vector_0.Z * vector_1.Y,
			Y = vector_0.Z * vector_1.X - vector_0.X * vector_1.Z,
			Z = vector_0.X * vector_1.Y - vector_0.Y * vector_1.X
		};
	}

	public static Vector Divide(Vector vector_0, double double_0)
	{
		if (double_0 == 0.0)
		{
			throw new ArgumentException("Divisor cannot be 0.");
		}
		return new Vector(vector_0.X / double_0, vector_0.Y / double_0, vector_0.Z / double_0);
	}

	public static double DotProduct(Vector vector_0, Vector vector_1)
	{
		return vector_0.X * vector_1.X + vector_0.Y * vector_1.Y + vector_0.Z * vector_1.Z;
	}

	public static double Norm2(Vector vector_0)
	{
		return vector_0.X * vector_0.X + vector_0.Y * vector_0.Y + vector_0.Z * vector_0.Z;
	}

	public static Vector Multiply(Vector vector_0, double double_0)
	{
		return new Vector(vector_0.X * double_0, vector_0.Y * double_0, vector_0.Z * double_0);
	}

	public static Vector Subtract(Vector vector_0, Vector vector_1)
	{
		return new Vector(vector_0.X - vector_1.X, vector_0.Y - vector_1.Y, vector_0.Z - vector_1.Z);
	}

	public static Vector operator +(Vector vector_0, Vector vector_1)
	{
		return new Vector(vector_0.X + vector_1.X, vector_0.Y + vector_1.Y, vector_0.Z + vector_1.Z);
	}

	public static bool operator ==(Vector vector_0, Vector vector_1)
	{
		if (vector_0.X == vector_1.X && vector_0.Y == vector_1.Y && vector_0.Z == vector_1.Z)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Vector vector_0, Vector vector_1)
	{
		if (vector_0.X == vector_1.X && vector_0.Y == vector_1.Y && vector_0.Z == vector_1.Z)
		{
			return false;
		}
		return true;
	}

	public static Vector operator ^(Vector vector_0, Vector vector_1)
	{
		return new Vector
		{
			X = vector_0.Y * vector_1.Z - vector_0.Z * vector_1.Y,
			Y = vector_0.Z * vector_1.X - vector_0.X * vector_1.Z,
			Z = vector_0.X * vector_1.Y - vector_0.Y * vector_1.X
		};
	}

	public static double operator *(Vector vector_0, Vector vector_1)
	{
		return vector_0.X * vector_1.X + vector_0.Y * vector_1.Y + vector_0.Z * vector_1.Z;
	}

	public static Vector operator *(double double_0, Vector vector_0)
	{
		return new Vector(vector_0.X * double_0, vector_0.Y * double_0, vector_0.Z * double_0);
	}

	public static Vector operator *(Vector vector_0, double double_0)
	{
		return new Vector(vector_0.X * double_0, vector_0.Y * double_0, vector_0.Z * double_0);
	}

	public static Vector operator -(Vector vector_0, Vector vector_1)
	{
		return new Vector(vector_0.X - vector_1.X, vector_0.Y - vector_1.Y, vector_0.Z - vector_1.Z);
	}
}
