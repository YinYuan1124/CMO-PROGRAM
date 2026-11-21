using System;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Index.Quadtree;

public class DoubleBits
{
	public const int EXPONENT_BIAS = 1023;

	private readonly double m_QueueCollection;

	private long m_RegCollection;

	public virtual double Double => BitConverter.Int64BitsToDouble(m_RegCollection);

	public virtual int BiasedExponent => (int)(m_RegCollection >> 52) & 0x7FF;

	public virtual int Exponent => BiasedExponent - 1023;

	public DoubleBits(double double_0)
	{
		m_QueueCollection = double_0;
		m_RegCollection = BitConverter.DoubleToInt64Bits(double_0);
	}

	public static double PowerOf2(int int_0)
	{
		if (int_0 > 1023 || int_0 < -1022)
		{
			throw new ArgumentException("Exponent out of bounds");
		}
		return BitConverter.Int64BitsToDouble((long)(int_0 + 1023) << 52);
	}

	public static int GetExponent(double double_0)
	{
		return new DoubleBits(double_0).Exponent;
	}

	public static double TruncateToPowerOfTwo(double double_0)
	{
		DoubleBits doubleBits = new DoubleBits(double_0);
		doubleBits.ZeroLowerBits(52);
		return doubleBits.Double;
	}

	public static string ToBinaryString(double double_0)
	{
		return new DoubleBits(double_0).ToString();
	}

	public static double MaximumCommonMantissa(double double_0, double double_1)
	{
		if (double_0 != 0.0 && double_1 != 0.0)
		{
			DoubleBits doubleBits = new DoubleBits(double_0);
			DoubleBits doubleBits2 = new DoubleBits(double_1);
			if (doubleBits.Exponent == doubleBits2.Exponent)
			{
				int num = doubleBits.NumCommonMantissaBits(doubleBits2);
				doubleBits.ZeroLowerBits(64 - (12 + num));
				return doubleBits.Double;
			}
			return 0.0;
		}
		return 0.0;
	}

	public virtual void ZeroLowerBits(int int_0)
	{
		long num = ~((1L << int_0) - 1);
		m_RegCollection &= num;
	}

	public virtual int GetBit(int int_0)
	{
		long num = 1L << int_0;
		if ((m_RegCollection & num) != 0)
		{
			return 1;
		}
		return 0;
	}

	public virtual int NumCommonMantissaBits(DoubleBits doubleBits_0)
	{
		int num = 0;
		while (true)
		{
			if (num < 52)
			{
				if (GetBit(num) != doubleBits_0.GetBit(num))
				{
					break;
				}
				num++;
				continue;
			}
			return 52;
		}
		return num;
	}

	public override string ToString()
	{
		string text = HexConverter.ConvertAny2Any(m_RegCollection.ToString(), 10, 2);
		string text2 = "0000000000000000000000000000000000000000000000000000000000000000" + text;
		string text3 = text2.Substring(text2.Length - 64);
		return text3.Substring(0, 1) + "  " + text3.Substring(1, 12) + "(" + Exponent + ") " + text3.Substring(12) + " [ " + m_QueueCollection + " ]";
	}
}
