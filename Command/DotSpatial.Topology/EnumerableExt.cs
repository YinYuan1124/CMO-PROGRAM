using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public static class EnumerableExt
{
	public static List<T> CloneList<T>(this IEnumerable<T> ienumerable_0) where T : ICloneable
	{
		List<T> list = new List<T>();
		foreach (T item in ienumerable_0)
		{
			list.Add(LogoutRule<T>(item.Clone()));
		}
		return list;
	}

	private static T LogoutRule<T>(object object_0)
	{
		if (object_0 == null)
		{
			return default(T);
		}
		if (!(object_0 is T result))
		{
			return default(T);
		}
		return result;
	}
}
