using System;

namespace Catfood.Shapefile;

public static class EndianBitConverter
{
	public static int ToInt32(byte[] byte_0, int int_0, ProvidedOrder providedOrder_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (int_0 + 4 <= byte_0.Length)
		{
			if (BitConverter.IsLittleEndian && providedOrder_0 == ProvidedOrder.Big)
			{
				byte[] array = new byte[4];
				Array.Copy(byte_0, int_0, array, 0, 4);
				Array.Reverse(array);
				return BitConverter.ToInt32(array, 0);
			}
			return BitConverter.ToInt32(byte_0, int_0);
		}
		throw new ArgumentException("startIndex invalid (not enough space in value to extract an integer", "startIndex");
	}

	public static double ToDouble(byte[] byte_0, int int_0, ProvidedOrder providedOrder_0)
	{
		if (byte_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (int_0 + 8 <= byte_0.Length)
		{
			if (BitConverter.IsLittleEndian && providedOrder_0 == ProvidedOrder.Big)
			{
				byte[] array = new byte[8];
				Array.Copy(byte_0, int_0, array, 0, 8);
				Array.Reverse(array);
				return BitConverter.ToDouble(array, 0);
			}
			return BitConverter.ToDouble(byte_0, int_0);
		}
		throw new ArgumentException("startIndex invalid (not enough space in value to extract a double", "startIndex");
	}
}
