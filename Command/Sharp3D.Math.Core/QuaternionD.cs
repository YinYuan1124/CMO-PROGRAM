using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sharp3D.Math.Core;

[Serializable]
public struct QuaternionD : ICloneable
{
	private double _w;

	private double _x;

	private double _y;

	private double _z;

	public static readonly QuaternionD Zero;

	public static readonly QuaternionD Identity;

	public static readonly QuaternionD XAxis;

	public static readonly QuaternionD YAxis;

	public static readonly QuaternionD ZAxis;

	public static readonly QuaternionD WAxis;

	public double W
	{
		get
		{
			return _w;
		}
		set
		{
			_w = value;
		}
	}

	public double X
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

	public double Y
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

	public double Z
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

	public double Modulus => System.Math.Sqrt(_w * _w + _x * _x + _y * _y + _z * _z);

	public double ModulusSquared => _w * _w + _x * _x + _y * _y + _z * _z;

	public QuaternionD Conjugate
	{
		get
		{
			return new QuaternionD(_w, 0.0 - _x, 0.0 - _y, 0.0 - _z);
		}
		set
		{
			this = value.Conjugate;
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
				0 => _w, 
				1 => _x, 
				2 => _y, 
				3 => _z, 
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
				_w = value;
				break;
			case 1:
				_x = value;
				break;
			case 2:
				_y = value;
				break;
			case 3:
				_z = value;
				break;
			}
		}
	}

	public QuaternionD(double double_0, double double_1, double double_2, double double_3)
	{
		_w = double_0;
		_x = double_1;
		_y = double_2;
		_z = double_3;
	}

	public QuaternionD(double[] double_0)
	{
		_w = double_0[0];
		_x = double_0[1];
		_y = double_0[2];
		_z = double_0[3];
	}

	public QuaternionD(QuaternionD quaternionD_0)
	{
		_w = quaternionD_0.W;
		_x = quaternionD_0.X;
		_y = quaternionD_0.Y;
		_z = quaternionD_0.Z;
	}

	object ICloneable.Clone()
	{
		return new QuaternionD(this);
	}

	public QuaternionD Clone()
	{
		return new QuaternionD(this);
	}

	public static QuaternionD Parse(string string_0)
	{
		Match match = new Regex("\\((?<w>.*),(?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.None).Match(string_0);
		if (!match.Success)
		{
			throw new ParseException("Unsuccessful Match.");
		}
		return new QuaternionD(double.Parse(match.Result("${w}")), double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")));
	}

	public static bool TryParse(string string_0, out QuaternionD quaternionD_0)
	{
		Match match = new Regex("\\((?<w>.*),(?<x>.*),(?<y>.*),(?<z>.*)\\)", RegexOptions.None).Match(string_0);
		if (match.Success)
		{
			quaternionD_0 = new QuaternionD(double.Parse(match.Result("${x}")), double.Parse(match.Result("${y}")), double.Parse(match.Result("${z}")), double.Parse(match.Result("${w}")));
			return true;
		}
		quaternionD_0 = Zero;
		return false;
	}

	public static QuaternionD Add(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return new QuaternionD(quaternionD_0.W + quaternionD_1.W, quaternionD_0.X + quaternionD_1.X, quaternionD_0.Y + quaternionD_1.Y, quaternionD_0.Z + quaternionD_1.Z);
	}

	public static void Add(QuaternionD quaternionD_0, QuaternionD quaternionD_1, ref QuaternionD quaternionD_2)
	{
		quaternionD_2.W = quaternionD_0.W + quaternionD_1.W;
		quaternionD_2.X = quaternionD_0.X + quaternionD_1.X;
		quaternionD_2.Y = quaternionD_0.Y + quaternionD_1.Y;
		quaternionD_2.Z = quaternionD_0.Z + quaternionD_1.Z;
	}

	public static QuaternionD Subtract(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return new QuaternionD(quaternionD_0.W - quaternionD_1.W, quaternionD_0.X - quaternionD_1.X, quaternionD_0.Y - quaternionD_1.Y, quaternionD_0.Z - quaternionD_1.Z);
	}

	public static void Subtract(QuaternionD quaternionD_0, QuaternionD quaternionD_1, ref QuaternionD quaternionD_2)
	{
		quaternionD_2.W = quaternionD_0.W - quaternionD_1.W;
		quaternionD_2.X = quaternionD_0.X - quaternionD_1.X;
		quaternionD_2.Y = quaternionD_0.Y - quaternionD_1.Y;
		quaternionD_2.Z = quaternionD_0.Z - quaternionD_1.Z;
	}

	public static QuaternionD Multiply(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		QuaternionD result = default(QuaternionD);
		result.W = quaternionD_0.W * quaternionD_1.W - quaternionD_0.X * quaternionD_1.X - quaternionD_0.Y * quaternionD_1.Y - quaternionD_0.Z * quaternionD_1.Z;
		result.X = quaternionD_0.W * quaternionD_1.X + quaternionD_0.X * quaternionD_1.W + quaternionD_0.Y * quaternionD_1.Z - quaternionD_0.Z * quaternionD_1.Y;
		result.Y = quaternionD_0.W * quaternionD_1.Y + quaternionD_0.Y * quaternionD_1.W + quaternionD_0.Z * quaternionD_1.X - quaternionD_0.X * quaternionD_1.Z;
		result.Z = quaternionD_0.W * quaternionD_1.Z + quaternionD_0.Z * quaternionD_1.W + quaternionD_0.X * quaternionD_1.Y - quaternionD_0.Y * quaternionD_1.X;
		return result;
	}

	public static void Multiply(QuaternionD quaternionD_0, QuaternionD quaternionD_1, ref QuaternionD quaternionD_2)
	{
		quaternionD_2.W = quaternionD_0.W * quaternionD_1.W - quaternionD_0.X * quaternionD_1.X - quaternionD_0.Y * quaternionD_1.Y - quaternionD_0.Z * quaternionD_1.Z;
		quaternionD_2.X = quaternionD_0.W * quaternionD_1.X + quaternionD_0.X * quaternionD_1.W + quaternionD_0.Y * quaternionD_1.Z - quaternionD_0.Z * quaternionD_1.Y;
		quaternionD_2.Y = quaternionD_0.W * quaternionD_1.Y + quaternionD_0.Y * quaternionD_1.W + quaternionD_0.Z * quaternionD_1.X - quaternionD_0.X * quaternionD_1.Z;
		quaternionD_2.Z = quaternionD_0.W * quaternionD_1.Z + quaternionD_0.Z * quaternionD_1.W + quaternionD_0.X * quaternionD_1.Y - quaternionD_0.Y * quaternionD_1.X;
	}

	public static QuaternionD Multiply(QuaternionD quaternionD_0, double double_0)
	{
		QuaternionD result = new QuaternionD(quaternionD_0);
		result.W *= double_0;
		result.X *= double_0;
		result.Y *= double_0;
		result.Z *= double_0;
		return result;
	}

	public static void Multiply(QuaternionD quaternionD_0, double double_0, ref QuaternionD quaternionD_1)
	{
		quaternionD_1.W = quaternionD_0.W * double_0;
		quaternionD_1.X = quaternionD_0.X * double_0;
		quaternionD_1.Y = quaternionD_0.Y * double_0;
		quaternionD_1.Z = quaternionD_0.Z * double_0;
	}

	public static QuaternionD Divide(QuaternionD quaternionD_0, double double_0)
	{
		if (double_0 == 0.0)
		{
			throw new DivideByZeroException("Dividing quaternion by zero");
		}
		QuaternionD result = new QuaternionD(quaternionD_0);
		result.W /= double_0;
		result.X /= double_0;
		result.Y /= double_0;
		result.Z /= double_0;
		return result;
	}

	public static void Divide(QuaternionD quaternionD_0, double double_0, ref QuaternionD quaternionD_1)
	{
		if (double_0 == 0.0)
		{
			throw new DivideByZeroException("Dividing quaternion by zero");
		}
		quaternionD_1.W = quaternionD_0.W / double_0;
		quaternionD_1.X = quaternionD_0.X / double_0;
		quaternionD_1.Y = quaternionD_0.Y / double_0;
		quaternionD_1.Z = quaternionD_0.Z / double_0;
	}

	public static double DotProduct(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return quaternionD_0.W * quaternionD_1.W + quaternionD_0.X * quaternionD_1.X + quaternionD_0.Y * quaternionD_1.Y + quaternionD_0.Z * quaternionD_1.Z;
	}

	public static QuaternionD Log(QuaternionD quaternionD_0)
	{
		QuaternionD result = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		if (MathFunctions.Abs(quaternionD_0.W) < 1.0)
		{
			double num = System.Math.Acos(quaternionD_0.W);
			double num2 = System.Math.Sin(num);
			if (MathFunctions.Abs(num2) < 0.0)
			{
				result.X = quaternionD_0.X;
				result.Y = quaternionD_0.Y;
				result.Z = quaternionD_0.Z;
			}
			else
			{
				double num3 = num / num2;
				result.X = num3 * quaternionD_0.X;
				result.Y = num3 * quaternionD_0.Y;
				result.Z = num3 * quaternionD_0.Z;
			}
		}
		return result;
	}

	public QuaternionD Exp(QuaternionD quaternionD_0)
	{
		QuaternionD result = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		double num = System.Math.Sqrt(quaternionD_0.X * quaternionD_0.X + quaternionD_0.Y * quaternionD_0.Y + quaternionD_0.Z * quaternionD_0.Z);
		double num2 = System.Math.Sin(num);
		if (MathFunctions.Abs(num2) <= 0.0)
		{
			result.X = quaternionD_0.X;
			result.Y = quaternionD_0.Y;
			result.Z = quaternionD_0.Z;
		}
		else
		{
			double num3 = num / num2;
			result.X = num3 * quaternionD_0.X;
			result.Y = num3 * quaternionD_0.Y;
			result.Z = num3 * quaternionD_0.Z;
		}
		return result;
	}

	public void Inverse()
	{
		double modulusSquared = ModulusSquared;
		if (modulusSquared <= 0.0)
		{
			throw new QuaternionNotInvertibleException("Quaternion " + ToString() + " is not invertable");
		}
		double num = 1.0 / modulusSquared;
		_w *= num;
		_x *= 0.0 - num;
		_y *= 0.0 - num;
		_z *= 0.0 - num;
	}

	public void Normalize()
	{
		double modulus = Modulus;
		if (modulus == 0.0)
		{
			throw new DivideByZeroException("Trying to normalize a quaternion with modulus of zero.");
		}
		_w /= modulus;
		_x /= modulus;
		_y /= modulus;
		_z /= modulus;
	}

	public void ClampZero(double double_0)
	{
		_x = MathFunctions.Clamp(_x, 0.0, double_0);
		_y = MathFunctions.Clamp(_y, 0.0, double_0);
		_z = MathFunctions.Clamp(_z, 0.0, double_0);
		_w = MathFunctions.Clamp(_w, 0.0, double_0);
	}

	public void ClampZero()
	{
		_x = MathFunctions.Clamp(_x, 0.0);
		_y = MathFunctions.Clamp(_y, 0.0);
		_z = MathFunctions.Clamp(_z, 0.0);
		_w = MathFunctions.Clamp(_w, 0.0);
	}

	public override int GetHashCode()
	{
		return _w.GetHashCode() ^ _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is QuaternionD quaternionD)
		{
			if (_w == quaternionD.W && _x == quaternionD.X && _y == quaternionD.Y)
			{
				return _z == quaternionD.Z;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2}, {3})", _w, _x, _y, _z);
	}

	public static bool operator ==(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return object.Equals(quaternionD_0, quaternionD_1);
	}

	public static bool operator !=(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return !object.Equals(quaternionD_0, quaternionD_1);
	}

	public static QuaternionD operator +(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return Add(quaternionD_0, quaternionD_1);
	}

	public static QuaternionD operator -(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return Subtract(quaternionD_0, quaternionD_1);
	}

	public static QuaternionD operator *(QuaternionD quaternionD_0, QuaternionD quaternionD_1)
	{
		return Multiply(quaternionD_0, quaternionD_1);
	}

	public static QuaternionD operator *(QuaternionD quaternionD_0, double double_0)
	{
		return Multiply(quaternionD_0, double_0);
	}

	public static QuaternionD operator *(double double_0, QuaternionD quaternionD_0)
	{
		return Multiply(quaternionD_0, double_0);
	}

	public static QuaternionD operator /(QuaternionD quaternionD_0, double double_0)
	{
		return Divide(quaternionD_0, double_0);
	}

	public static QuaternionD operator /(double double_0, QuaternionD quaternionD_0)
	{
		return Multiply(quaternionD_0, 1.0 / double_0);
	}

	public static explicit operator double[](QuaternionD quaternionD_0)
	{
		return new double[4] { quaternionD_0.W, quaternionD_0.X, quaternionD_0.Y, quaternionD_0.Z };
	}

	static QuaternionD()
	{
		Zero = new QuaternionD(0.0, 0.0, 0.0, 0.0);
		Identity = new QuaternionD(1.0, 0.0, 0.0, 0.0);
		XAxis = new QuaternionD(0.0, 1.0, 0.0, 0.0);
		YAxis = new QuaternionD(0.0, 0.0, 1.0, 0.0);
		ZAxis = new QuaternionD(0.0, 0.0, 0.0, 1.0);
		WAxis = new QuaternionD(1.0, 0.0, 0.0, 0.0);
	}
}
