using System;
using System.ComponentModel;
using Command.Listeners;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class CoordinateF
{
	private float _m = float.NaN;

	private float _x = float.NaN;

	private float _y = float.NaN;

	private float _z = float.NaN;

	public float X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public float Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public float Z
	{
		get
		{
			return _z;
		}
		set
		{
			_z = value;
		}
	}

	public float M
	{
		get
		{
			return _m;
		}
		set
		{
			_m = value;
		}
	}

	[Browsable(false)]
	public CoordinateF CoordinateValue
	{
		get
		{
			return this;
		}
		set
		{
			_x = value.X;
			_y = value.Y;
			_z = value.Z;
			_m = value.M;
		}
	}

	public double this[int int_0]
	{
		get
		{
			if (1 == 0)
			{
			}
			double result = int_0 switch
			{
				0 => Convert.ToDouble(_x), 
				1 => Convert.ToDouble(_y), 
				2 => Convert.ToDouble(_z), 
				_ => 0.0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		set
		{
			if (int_0 == 0)
			{
				_x = Convert.ToSingle(value);
			}
			if (int_0 == 1)
			{
				_y = Convert.ToSingle(value);
			}
			if (int_0 == 2)
			{
				_z = Convert.ToSingle(value);
			}
		}
	}

	public int NumOrdinates => 3;

	public double[] Values
	{
		get
		{
			return new double[3]
			{
				Convert.ToSingle(_x),
				Convert.ToSingle(_y),
				Convert.ToSingle(_z)
			};
		}
		set
		{
			if (value.GetLength(0) > 0)
			{
				_x = Convert.ToSingle(value[0]);
			}
			if (value.GetLength(0) > 1)
			{
				_y = Convert.ToSingle(value[1]);
			}
			if (value.GetLength(0) > 2)
			{
				_z = Convert.ToSingle(value[2]);
			}
		}
	}

	public CoordinateF(FloatVector3 floatVector3_0)
	{
		_x = floatVector3_0.X;
		_y = floatVector3_0.Y;
		_z = floatVector3_0.Z;
		_m = float.NaN;
	}

	public CoordinateF(float float_0, float float_1, float float_2, float float_3)
	{
		_x = float_0;
		_y = float_1;
		_z = float_2;
		_m = float_3;
	}

	public CoordinateF(float float_0, float float_1, float float_2)
	{
		_x = float_0;
		_y = float_1;
		_z = float_2;
		_m = 0f;
	}

	public CoordinateF(Coordinate coordinate_0)
	{
		_x = Convert.ToSingle(coordinate_0.X);
		_y = Convert.ToSingle(coordinate_0.Y);
		_z = Convert.ToSingle(coordinate_0.Z);
	}

	public CoordinateF()
		: this(0f, 0f, 0f, 0f)
	{
	}

	public CoordinateF(float float_0, float float_1)
		: this(float_0, float_1, 0f, 0f)
	{
	}

	public bool Equals2D(CoordinateF coordinateF_0)
	{
		if (coordinateF_0 == null)
		{
			if (_x != coordinateF_0.X)
			{
				return false;
			}
			if (_y != coordinateF_0.Y)
			{
				return false;
			}
		}
		else
		{
			if (_x != coordinateF_0.X)
			{
				return false;
			}
			if (_y != coordinateF_0.Y)
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Coordinate)
		{
			return Equals2D((CoordinateF)obj);
		}
		return false;
	}

	public static bool operator ==(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return object.Equals(coordinateF_0, coordinate_0);
	}

	public static bool operator !=(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return !(coordinateF_0 == coordinate_0);
	}

	public int CompareTo(object object_0)
	{
		Coordinate coordinate = object_0 as Coordinate;
		if (coordinate == null)
		{
			throw new ArgumentException(AccountProcess.ArgumentCouldNotBeCast_S1_S2.Replace("%S1", "other").Replace("%S2", "ICoordinate"));
		}
		if ((double)_x < coordinate.X)
		{
			return -1;
		}
		if ((double)_x <= coordinate.X)
		{
			if ((double)_y < coordinate.Y)
			{
				return -1;
			}
			if ((double)_y <= coordinate.Y)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}

	public bool Equals3D(CoordinateF coordinateF_0)
	{
		if (coordinateF_0 == null)
		{
			if (_x == coordinateF_0.X && _y == coordinateF_0.X)
			{
				if (_z == coordinateF_0.Z)
				{
					return true;
				}
				if (double.IsNaN(_z))
				{
					return double.IsNaN(coordinateF_0.Z);
				}
				return false;
			}
			return false;
		}
		if (_x == coordinateF_0.X && _y == coordinateF_0.Y)
		{
			if (_z == coordinateF_0.Z)
			{
				return true;
			}
			if (float.IsNaN(_z))
			{
				return float.IsNaN(coordinateF_0.Z);
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + _x + ", " + _y + ", " + _z + ")";
	}

	public object Clone()
	{
		return new Coordinate(_x, _y, _z, _m);
	}

	public Coordinate Copy()
	{
		return new Coordinate(_x, _y, _z, _m);
	}

	public double Distance(Coordinate coordinate_0)
	{
		double num = (double)_x - coordinate_0.X;
		double num2 = (double)_y - coordinate_0.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public double HyperDistance(Coordinate coordinate_0)
	{
		if (coordinate_0.NumOrdinates != NumOrdinates)
		{
			throw new CoordinateMismatchException();
		}
		double[] array = coordinate_0.ToArray();
		double num = array[0] - Convert.ToDouble(_x);
		double num2 = num * num;
		num = array[1] - Convert.ToDouble(_y);
		double num3 = num2 + num * num;
		num = array[2] - Convert.ToDouble(_z);
		return Math.Sqrt(num3 + num * num);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = 629 + GetHashCode(X);
		return 37 * num + GetHashCode(Y);
	}

	public static int GetHashCode(double double_0)
	{
		long num = BitConverter.DoubleToInt64Bits(double_0);
		return (int)(num ^ (num >> 32));
	}

	public static CoordinateF operator +(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return new CoordinateF(coordinateF_0.X + Convert.ToSingle(coordinate_0.X), coordinateF_0.Y + Convert.ToSingle(coordinate_0.Y), coordinateF_0.Z + Convert.ToSingle(coordinate_0.Z));
	}

	public static CoordinateF operator +(CoordinateF coordinateF_0, float float_0)
	{
		return new CoordinateF(coordinateF_0.X + float_0, coordinateF_0.Y + float_0, coordinateF_0.Z + float_0);
	}

	public static CoordinateF operator +(float float_0, CoordinateF coordinateF_0)
	{
		return coordinateF_0 + float_0;
	}

	public static CoordinateF operator *(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return new CoordinateF(coordinateF_0.X * Convert.ToSingle(coordinate_0.X), coordinateF_0.Y * Convert.ToSingle(coordinate_0.Y), coordinateF_0.Z * Convert.ToSingle(coordinate_0.Z));
	}

	public static CoordinateF operator *(CoordinateF coordinateF_0, float float_0)
	{
		return new CoordinateF(coordinateF_0.X * float_0, coordinateF_0.Y * float_0, coordinateF_0.Z * float_0);
	}

	public static CoordinateF operator *(float float_0, CoordinateF coordinateF_0)
	{
		return coordinateF_0 * float_0;
	}

	public static CoordinateF operator -(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return new CoordinateF(coordinateF_0.X - Convert.ToSingle(coordinate_0.X), coordinateF_0.Y - Convert.ToSingle(coordinate_0.Y), coordinateF_0.Z - Convert.ToSingle(coordinate_0.Z));
	}

	public static CoordinateF operator -(CoordinateF coordinateF_0, float float_0)
	{
		return new CoordinateF(coordinateF_0.X - float_0, coordinateF_0.Y - float_0, coordinateF_0.Z - float_0);
	}

	public static CoordinateF operator -(float float_0, CoordinateF coordinateF_0)
	{
		return coordinateF_0 - float_0;
	}

	public static CoordinateF operator /(CoordinateF coordinateF_0, Coordinate coordinate_0)
	{
		return new CoordinateF(coordinateF_0.X / Convert.ToSingle(coordinate_0.X), coordinateF_0.Y / Convert.ToSingle(coordinate_0.Y), coordinateF_0.Z / Convert.ToSingle(coordinate_0.Z));
	}

	public static CoordinateF operator /(CoordinateF coordinateF_0, float float_0)
	{
		return new CoordinateF(coordinateF_0.X / float_0, coordinateF_0.Y / float_0, coordinateF_0.Z / float_0);
	}

	public static CoordinateF operator /(float float_0, CoordinateF coordinateF_0)
	{
		return coordinateF_0 / float_0;
	}

	public double[] ToArray()
	{
		return new double[3]
		{
			Convert.ToSingle(_x),
			Convert.ToSingle(_y),
			Convert.ToSingle(_z)
		};
	}
}
