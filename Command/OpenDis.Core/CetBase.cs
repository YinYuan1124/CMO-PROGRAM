using System;

namespace OpenDis.Core;

public class CetBase
{
	protected void VerifyNumericString(string string_0, bool bool_0)
	{
		if (!bool_0 && string.IsNullOrEmpty(string_0))
		{
			throw new ArgumentNullException("Value must be greater or equal to 0.");
		}
		if (string_0 == null)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string_0[num] < '0' || string_0[num] > '9')
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		throw new ArgumentOutOfRangeException("Value must be greater or equal to 0.");
	}
}
