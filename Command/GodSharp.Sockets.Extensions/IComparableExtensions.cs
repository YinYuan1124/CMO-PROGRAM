using System;

namespace GodSharp.Sockets.Extensions;

public static class IComparableExtensions
{
	public static bool In<T>(this T value, T min, T max) where T : struct, IComparable<T>
	{
		return !value.NotIn(min, max);
	}

	public static bool NotIn<T>(this T value, T min, T max) where T : struct, IComparable<T>
	{
		if (value.CompareTo(min) < 0)
		{
			return true;
		}
		return value.CompareTo(max) > 0;
	}
}
