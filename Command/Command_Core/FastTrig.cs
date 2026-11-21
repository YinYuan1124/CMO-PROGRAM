using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class FastTrig
{
	internal static double DisableBridge(double double_0)
	{
		if (double_0 < -3.14159265)
		{
			double_0 += 6.28318531;
		}
		else if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		if (double_0 < 0.0)
		{
			return 1.27323954 * double_0 + 0.405284735 * double_0 * double_0;
		}
		return 1.27323954 * double_0 - 0.405284735 * double_0 * double_0;
	}

	internal static double UpdateBridge(double double_0)
	{
		if (double_0 < -3.14159265)
		{
			double_0 += 6.28318531;
		}
		else if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		double_0 += 1.57079632;
		if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		if (double_0 < 0.0)
		{
			return 1.27323954 * double_0 + 0.405284735 * double_0 * double_0;
		}
		return 1.27323954 * double_0 - 0.405284735 * double_0 * double_0;
	}

	internal static double InsertBridge(double double_0)
	{
		return ReflectBridge(double_0 * 0.0174532925199433);
	}

	internal static double PrepareBridge(double double_0)
	{
		return VisitBridge(double_0 * 0.0174532925199433);
	}

	internal static double ReflectBridge(double double_0)
	{
		if (double_0 < -3.14159265)
		{
			double_0 += 6.28318531;
		}
		else if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		double num;
		if (double_0 < 0.0)
		{
			num = 1.27323954 * double_0 + 0.405284735 * double_0 * double_0;
			if (num < 0.0)
			{
				return 0.225 * (num * (0.0 - num) - num) + num;
			}
			return 0.225 * (num * num - num) + num;
		}
		num = 1.27323954 * double_0 - 0.405284735 * double_0 * double_0;
		if (num < 0.0)
		{
			return 0.225 * (num * (0.0 - num) - num) + num;
		}
		return 0.225 * (num * num - num) + num;
	}

	internal static double VisitBridge(double double_0)
	{
		if (double_0 < -3.14159265)
		{
			double_0 += 6.28318531;
		}
		else if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		double_0 += 1.57079632;
		if (double_0 > 3.14159265)
		{
			double_0 -= 6.28318531;
		}
		double num;
		if (double_0 < 0.0)
		{
			num = 1.27323954 * double_0 + 0.405284735 * double_0 * double_0;
			if (num < 0.0)
			{
				return 0.225 * (num * (0.0 - num) - num) + num;
			}
			return 0.225 * (num * num - num) + num;
		}
		num = 1.27323954 * double_0 - 0.405284735 * double_0 * double_0;
		if (num < 0.0)
		{
			return 0.225 * (num * (0.0 - num) - num) + num;
		}
		return 0.225 * (num * num - num) + num;
	}

	internal static double RestartBridge(double double_0)
	{
		return 0.0 - (1.2732394933700562 * double_0 + -0.40528473258018494 * double_0 * ((double_0 < 0.0) ? (0.0 - double_0) : double_0));
	}
}
