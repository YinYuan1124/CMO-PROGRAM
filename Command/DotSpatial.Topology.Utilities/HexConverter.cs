using System;

namespace DotSpatial.Topology.Utilities;

public class HexConverter
{
	private HexConverter()
	{
	}

	public static string ConvertAny2Any(string string_0, int int_0, int int_1)
	{
		string result = "Error";
		string_0 = string_0.ToUpper();
		if (int_0 >= 2 && int_0 <= 36 && int_1 >= 2 && int_1 <= 36)
		{
			if (string_0.Trim().Length == 0)
			{
				return result;
			}
			if (int_0 == int_1)
			{
				return string_0;
			}
			double num = 0.0;
			try
			{
				if (int_0 == 10)
				{
					num = double.Parse(string_0);
				}
				else
				{
					char[] array = string_0.ToCharArray();
					int num2 = array.Length;
					for (int i = 0; i < array.Length; i++)
					{
						int num3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(array[i]);
						if (num3 >= 0 && num3 <= int_0 - 1)
						{
							num2--;
							num += (double)num3 * Math.Pow(int_0, num2);
							continue;
						}
						return result;
					}
				}
				if (int_1 == 10)
				{
					return num.ToString();
				}
				result = string.Empty;
				while (num > 0.0)
				{
					int num4 = (int)(num % (double)int_1);
					num = (num - (double)num4) / (double)int_1;
					result = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(num4, 1) + result;
				}
				return result;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		return result;
	}
}
