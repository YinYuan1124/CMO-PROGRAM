using System;
using System.Collections.Generic;
using System.Globalization;
using OpenDis.Common;
using OpenDis.Resolver;

namespace Gameloop.Vdf.Linq;

public static class Extensions
{
	public static U Value<U>(this IEnumerable<VToken> ienumerable_0)
	{
		return ienumerable_0.Value<VToken, U>();
	}

	public static U Value<T, U>(this IEnumerable<T> ienumerable_0) where T : VToken
	{
		PrinterProcessResolver.RunThread(ienumerable_0, "value");
		return ((ienumerable_0 as VToken) ?? throw new ArgumentException("Source value must be a JToken.")).StartThread<VToken, U>();
	}

	internal static U StartThread<T, U>(this T gparam_0) where T : VToken
	{
		if (gparam_0 == null)
		{
			return default(U);
		}
		if (gparam_0 is U && typeof(U) != typeof(IComparable) && typeof(U) != typeof(IFormattable))
		{
			return (U)(object)gparam_0;
		}
		if (gparam_0 is VValue { Value: var value } vValue)
		{
			if (!(value is U result))
			{
				Type type = typeof(U);
				if (ErrorProcess.StopThread(type))
				{
					if (vValue.Value == null)
					{
						return default(U);
					}
					type = Nullable.GetUnderlyingType(type);
				}
				if (AssetThread<U>(vValue.Value, out var gparam_))
				{
					return gparam_;
				}
				return (U)Convert.ChangeType(vValue.Value, type, CultureInfo.InvariantCulture);
			}
			return result;
		}
		throw new InvalidCastException($"Cannot cast {gparam_0.GetType()} to {typeof(T)}.");
	}

	private static bool AssetThread<T>(object object_0, out T gparam_0)
	{
		gparam_0 = default(T);
		if (typeof(T) == typeof(bool) || Nullable.GetUnderlyingType(typeof(T)) == typeof(bool))
		{
			string text = object_0 as string;
			if (text == "0")
			{
				gparam_0 = (T)(object)false;
				return true;
			}
			if (text == "1")
			{
				gparam_0 = (T)(object)true;
				return true;
			}
		}
		return false;
	}
}
