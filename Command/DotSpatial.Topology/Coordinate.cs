using System;
using Command.Listeners;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

[Serializable]
public class Coordinate : IComparable<Coordinate>, ICloneable, IComparable
{
	[Serialize("M")]
	public double M;

	[Serialize("X")]
	public double X;

	[Serialize("Y")]
	public double Y;

	[Serialize("Z")]
	public double Z;

	public static Coordinate Empty => new Coordinate(double.NaN, double.NaN);

	public double this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			double result = int_0 switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
				_ => throw new IndexOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		set
		{
			switch (int_0)
			{
			default:
				throw new IndexOutOfRangeException();
			case 0:
				X = value;
				break;
			case 1:
				Y = value;
				break;
			case 2:
				Z = value;
				break;
			}
		}
	}

	public int NumOrdinates
	{
		get
		{
			if (double.IsNaN(Z))
			{
				return 2;
			}
			return 3;
		}
	}

	public Coordinate()
	{
		X = double.NaN;
		Y = double.NaN;
		Z = double.NaN;
		M = double.NaN;
	}

	public Coordinate(double double_0, double double_1)
	{
		X = double_0;
		Y = double_1;
		Z = double.NaN;
		M = double.NaN;
	}

	public Coordinate(double double_0, double double_1, double double_2)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
		M = double.NaN;
	}

	public Coordinate(double[] double_0)
	{
		if (double_0.Length != 0)
		{
			X = double_0[0];
		}
		if (double_0.Length > 1)
		{
			Y = double_0[1];
		}
		if (double_0.Length > 2)
		{
			Z = double_0[2];
		}
	}

	public Coordinate(ICoordinate icoordinate_0)
	{
		double[] values = icoordinate_0.Values;
		if (values.Length != 0)
		{
			X = values[0];
		}
		if (values.Length > 1)
		{
			Y = values[1];
		}
		if (values.Length > 2)
		{
			Z = values[2];
		}
		M = icoordinate_0.M;
	}

	public Coordinate(Coordinate coordinate_0)
	{
		X = coordinate_0.X;
		Y = coordinate_0.Y;
		Z = coordinate_0.Z;
		M = coordinate_0.M;
	}

	public Coordinate(double double_0, double double_1, double double_2, double double_3)
	{
		X = double_0;
		Y = double_1;
		Z = double_2;
		M = double_3;
	}

	public override bool Equals(object obj)
	{
		if (obj is Coordinate)
		{
			Coordinate coordinate = (Coordinate)obj;
			if (!double.IsNaN(Z) && !double.IsNaN(coordinate.Z))
			{
				if (coordinate.X == X && coordinate.Y == Y)
				{
					return coordinate.Z == Z;
				}
				return false;
			}
			if (coordinate.X == X)
			{
				return coordinate.Y == Y;
			}
			return false;
		}
		if (obj is ICoordinate coordinate2)
		{
			if (!double.IsNaN(Z) && !double.IsNaN(coordinate2.Z))
			{
				if (coordinate2.X == X && coordinate2.Y == Y)
				{
					return coordinate2.Z == Z;
				}
				return false;
			}
			if (coordinate2.X == X)
			{
				return coordinate2.Y == Y;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public double[] ToArray()
	{
		if (!double.IsNaN(Z))
		{
			return new double[3] { X, Y, Z };
		}
		return new double[2] { X, Y };
	}

	public double Distance(Coordinate coordinate_0)
	{
		double num = coordinate_0.X - X;
		double num2 = coordinate_0.Y - Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public bool Equals2D(Coordinate coordinate_0)
	{
		if (X == coordinate_0.X && Y == coordinate_0.Y)
		{
			return true;
		}
		return false;
	}

	public bool Equals3D(Coordinate coordinate_0)
	{
		if (X == coordinate_0.X && Y == coordinate_0.Y)
		{
			if (Z == coordinate_0.Z)
			{
				return true;
			}
			if (double.IsNaN(Z))
			{
				return double.IsNaN(coordinate_0.Z);
			}
			return false;
		}
		return false;
	}

	public double HyperDistance(Coordinate coordinate_0)
	{
		if (NumOrdinates == coordinate_0.NumOrdinates)
		{
			double num = 0.0;
			double[] array = ToArray();
			double[] array2 = coordinate_0.ToArray();
			for (int i = 0; i < NumOrdinates; i++)
			{
				double num2 = array2[i] - array[i];
				num += num2 * num2;
			}
			return Math.Sqrt(num);
		}
		throw new CoordinateMismatchException();
	}

	public new string ToString()
	{
		string text = "(" + X;
		for (int i = 1; i < NumOrdinates; i++)
		{
			text = text + ", " + this[i];
		}
		return text + ")";
	}

	int IComparable.CompareTo(object obj)
	{
		Coordinate coordinate = obj as Coordinate;
		if (coordinate == null)
		{
			throw new ArgumentException(AccountProcess.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
		}
		if (X < coordinate.X)
		{
			return -1;
		}
		if (X <= coordinate.X)
		{
			if (Y < coordinate.Y)
			{
				return -1;
			}
			if (Y <= coordinate.Y)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}

	public virtual int CompareTo(Coordinate other)
	{
		if (other == null)
		{
			throw new ArgumentException(AccountProcess.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
		}
		if (X < other.X)
		{
			return -1;
		}
		if (X <= other.X)
		{
			if (Y < other.Y)
			{
				return -1;
			}
			if (Y <= other.Y)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}

	public bool IsEmpty()
	{
		if (double.IsNaN(X))
		{
			return true;
		}
		return double.IsNaN(Y);
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public static bool operator ==(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return object.Equals(coordinate_0, coordinate_1);
	}

	public static bool operator !=(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return !(coordinate_0 == coordinate_1);
	}

	public static Coordinate operator +(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return new Coordinate(coordinate_0.X + coordinate_1.X, coordinate_0.Y + coordinate_1.Y, coordinate_0.Z + coordinate_1.Z);
	}

	public static Coordinate operator +(Coordinate coordinate_0, double double_0)
	{
		return new Coordinate(coordinate_0.X + double_0, coordinate_0.Y + double_0, coordinate_0.Z + double_0);
	}

	public static Coordinate operator +(double double_0, Coordinate coordinate_0)
	{
		return coordinate_0 + double_0;
	}

	public static Coordinate operator *(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return new Coordinate(coordinate_0.X * coordinate_1.X, coordinate_0.Y * coordinate_1.Y, coordinate_0.Z * coordinate_1.Z);
	}

	public static Coordinate operator *(Coordinate coordinate_0, double double_0)
	{
		return new Coordinate(coordinate_0.X * double_0, coordinate_0.Y * double_0, coordinate_0.Z * double_0);
	}

	public static Coordinate operator *(double double_0, Coordinate coordinate_0)
	{
		return coordinate_0 * double_0;
	}

	public static Coordinate operator -(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return new Coordinate(coordinate_0.X - coordinate_1.X, coordinate_0.Y - coordinate_1.Y, coordinate_0.Z - coordinate_1.Z);
	}

	public static Coordinate operator -(Coordinate coordinate_0, double double_0)
	{
		return new Coordinate(coordinate_0.X - double_0, coordinate_0.Y - double_0, coordinate_0.Z - double_0);
	}

	public static Coordinate operator -(double double_0, Coordinate coordinate_0)
	{
		return coordinate_0 - double_0;
	}

	public static Coordinate operator /(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		return new Coordinate(coordinate_0.X / coordinate_1.X, coordinate_0.Y / coordinate_1.Y, coordinate_0.Z / coordinate_1.Z);
	}

	public static Coordinate operator /(Coordinate coordinate_0, double double_0)
	{
		return new Coordinate(coordinate_0.X / double_0, coordinate_0.Y / double_0, coordinate_0.Z / double_0);
	}

	public static Coordinate operator /(double double_0, Coordinate coordinate_0)
	{
		return coordinate_0 / double_0;
	}
}
