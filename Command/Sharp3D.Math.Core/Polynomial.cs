using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class Polynomial : ICloneable, IComparable
{
	private double[] double_0;

	public int Order
	{
		get
		{
			return double_0.Length - 1;
		}
		set
		{
			if (value != double_0.Length - 1)
			{
				double[] array = new double[value + 1];
				double_0.CopyTo(array, 0);
				double_0 = array;
			}
		}
	}

	public double this[int int_0]
	{
		get
		{
			return double_0[int_0];
		}
		set
		{
			double_0[int_0] = value;
		}
	}

	public Polynomial(int int_0)
	{
		double_0 = new double[int_0 + 1];
	}

	public Polynomial(double[] double_1)
	{
		double_0 = new double[double_1.Length];
		for (int i = 0; i < double_1.Length; i++)
		{
			double_0[i] = double_1[i];
		}
	}

	public Polynomial(List<double> list_0)
	{
		double_0 = new double[list_0.Count];
		for (int i = 0; i < list_0.Count; i++)
		{
			double_0[i] = list_0[i];
		}
	}

	public Polynomial(Polynomial polynomial_0)
	{
		double_0 = new double[polynomial_0.double_0.Length];
		for (int i = 0; i < double_0.Length; i++)
		{
			double_0[i] = polynomial_0.double_0[i];
		}
	}

	object ICloneable.Clone()
	{
		return new Polynomial(this);
	}

	public Polynomial Clone()
	{
		return new Polynomial(this);
	}

	int IComparable.CompareTo(object obj)
	{
		if (obj == null)
		{
			throw new ArgumentException("Parameter cannot be null.", "obj");
		}
		Polynomial polynomial = obj as Polynomial;
		if (polynomial == null)
		{
			throw new ArgumentException("Type mismatch: polynomial expected.", "obj");
		}
		return CompareTo(polynomial);
	}

	public int CompareTo(Polynomial polynomial_0)
	{
		int num = double_0.Length - 1;
		int num2 = polynomial_0.double_0.Length - 1;
		while (true)
		{
			if (num != num2)
			{
				if (num <= num2)
				{
					if (polynomial_0.double_0[num2--] != 0.0)
					{
						return -1;
					}
				}
				else if (double_0[num--] != 0.0)
				{
					break;
				}
				continue;
			}
			while (true)
			{
				if (num >= 0)
				{
					if (!(double_0[num] <= polynomial_0.double_0[num]))
					{
						break;
					}
					if (!(double_0[num] < polynomial_0.double_0[num]))
					{
						num--;
						continue;
					}
					return -1;
				}
				return 0;
			}
			return 1;
		}
		return 1;
	}

	public Polynomial GetInverse()
	{
		int order = Order;
		Polynomial polynomial = new Polynomial(order);
		for (int i = 0; i < double_0.Length; i++)
		{
			polynomial.double_0[i] = double_0[order - i];
		}
		return polynomial;
	}

	public Polynomial GetDerivative()
	{
		throw new NotImplementedException();
	}

	public void Compress(double double_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Add(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		Polynomial polynomial_2;
		Polynomial polynomial;
		if (polynomial_0.Order < polynomial_1.Order)
		{
			polynomial_2 = polynomial_1;
			polynomial = polynomial_0;
		}
		else
		{
			polynomial_2 = polynomial_0;
			polynomial = polynomial_1;
		}
		Polynomial polynomial2 = new Polynomial(polynomial_2);
		for (int i = 0; i < polynomial.double_0.Length; i++)
		{
			polynomial2.double_0[i] += polynomial.double_0[i];
		}
		return polynomial2;
	}

	public static Polynomial Add(Polynomial polynomial_0, double double_1)
	{
		throw new NotImplementedException();
	}

	public static void Add(Polynomial polynomial_0, Polynomial polynomial_1, Polynomial polynomial_2)
	{
		Polynomial polynomial;
		Polynomial polynomial2;
		if (polynomial_0.Order < polynomial_1.Order)
		{
			polynomial = polynomial_1;
			polynomial2 = polynomial_0;
		}
		else
		{
			polynomial = polynomial_0;
			polynomial2 = polynomial_1;
		}
		polynomial_2.Order = polynomial.Order;
		for (int i = 0; i < polynomial2.double_0.Length; i++)
		{
			polynomial_2.double_0[i] = polynomial.double_0[i] + polynomial2.double_0[i];
		}
		for (int j = polynomial2.double_0.Length; j < polynomial.double_0.Length; j++)
		{
			polynomial_2.double_0[j] = polynomial.double_0[j];
		}
	}

	public static void Add(Polynomial polynomial_0, double double_1, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(Polynomial polynomial_0, double double_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(double double_1, Polynomial polynomial_0)
	{
		throw new NotImplementedException();
	}

	public static void Subtract(Polynomial polynomial_0, Polynomial polynomial_1, Polynomial polynomial_2)
	{
		Polynomial polynomial;
		Polynomial polynomial2;
		if (polynomial_0.Order < polynomial_1.Order)
		{
			polynomial = polynomial_1;
			polynomial2 = polynomial_0;
		}
		else
		{
			polynomial = polynomial_0;
			polynomial2 = polynomial_1;
		}
		polynomial_2.Order = polynomial.Order;
		for (int i = 0; i < polynomial2.double_0.Length; i++)
		{
			polynomial_2.double_0[i] = polynomial.double_0[i] + polynomial2.double_0[i];
		}
		for (int j = polynomial2.double_0.Length; j < polynomial.double_0.Length; j++)
		{
			polynomial_2.double_0[j] = polynomial.double_0[j];
		}
	}

	public static void Subtract(Polynomial polynomial_0, double double_1, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static void Subtract(double double_1, Polynomial polynomial_0, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Multiply(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Multiply(Polynomial polynomial_0, double double_1)
	{
		throw new NotImplementedException();
	}

	public static void Multiply(Polynomial polynomial_0, Polynomial polynomial_1, Polynomial polynomial_2)
	{
		throw new NotImplementedException();
	}

	public static void Multiply(Polynomial polynomial_0, double double_1, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Divide(Polynomial polynomial_0, double double_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Divide(double double_1, Polynomial polynomial_0)
	{
		throw new NotImplementedException();
	}

	public static void Divide(Polynomial polynomial_0, double double_1, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static void Divide(double double_1, Polynomial polynomial_0, Polynomial polynomial_1)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Negate(Polynomial polynomial_0)
	{
		throw new NotImplementedException();
	}

	public override bool Equals(object obj)
	{
		Polynomial polynomial_ = obj as Polynomial;
		if (obj == null)
		{
			return false;
		}
		return CompareTo(polynomial_) == 0;
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < double_0.Length; i++)
		{
			if (double_0[i] != 0.0)
			{
				stringBuilder.Append((double_0[i] < 0.0) ? "-" : "+");
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}", double_0[i]));
				stringBuilder.Append("x");
				if (i > 1)
				{
					stringBuilder.Append("^");
					stringBuilder.Append(i.ToString());
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static bool operator ==(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return polynomial_0.Equals(polynomial_1);
	}

	public static bool operator !=(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return !polynomial_0.Equals(polynomial_1);
	}

	public static bool operator >(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return polynomial_0.CompareTo(polynomial_1) == 1;
	}

	public static bool operator <(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return polynomial_0.CompareTo(polynomial_1) == -1;
	}

	public static bool operator >=(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return polynomial_0.CompareTo(polynomial_1) >= 0;
	}

	public static bool operator <=(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return polynomial_0.CompareTo(polynomial_1) <= 0;
	}

	public static Polynomial operator -(Polynomial polynomial_0)
	{
		return Negate(polynomial_0);
	}

	public static Polynomial operator +(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return Add(polynomial_0, polynomial_1);
	}

	public static Polynomial operator +(Polynomial polynomial_0, double double_1)
	{
		return Add(polynomial_0, double_1);
	}

	public static Polynomial operator +(double double_1, Polynomial polynomial_0)
	{
		return Add(polynomial_0, double_1);
	}

	public static Polynomial operator -(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return Subtract(polynomial_0, polynomial_1);
	}

	public static Polynomial operator -(Polynomial polynomial_0, double double_1)
	{
		return Subtract(polynomial_0, double_1);
	}

	public static Polynomial operator -(double double_1, Polynomial polynomial_0)
	{
		return Subtract(double_1, polynomial_0);
	}

	public static Polynomial operator *(Polynomial polynomial_0, Polynomial polynomial_1)
	{
		return Multiply(polynomial_0, polynomial_1);
	}

	public static Polynomial operator *(Polynomial polynomial_0, double double_1)
	{
		return Multiply(polynomial_0, double_1);
	}

	public static Polynomial operator *(double double_1, Polynomial polynomial_0)
	{
		return Multiply(polynomial_0, double_1);
	}

	public static Polynomial operator /(Polynomial polynomial_0, double double_1)
	{
		return Divide(polynomial_0, double_1);
	}

	public static Polynomial operator /(double double_1, Polynomial polynomial_0)
	{
		return Divide(double_1, polynomial_0);
	}
}
