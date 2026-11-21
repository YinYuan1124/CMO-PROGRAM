using System;
using System.Collections.Generic;
using System.Linq;

namespace Command.Lists;

internal static class ModelProcess
{
	public static void RemoveThread<T>(this IList<T> ilist_0, IEnumerable<T> ienumerable_0)
	{
		if (ilist_0 == null)
		{
			throw new ArgumentNullException("initial");
		}
		if (ienumerable_0 == null)
		{
			return;
		}
		foreach (T item in ienumerable_0)
		{
			ilist_0.Add(item);
		}
	}

	public static T[] FindThread<T>()
	{
		return (Enumerable.Empty<T>() as T[]) ?? new T[0];
	}
}
