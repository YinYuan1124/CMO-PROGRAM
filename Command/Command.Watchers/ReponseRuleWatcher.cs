using System.Collections.Generic;
using System.Linq;

namespace Command.Watchers;

internal static class ReponseRuleWatcher
{
	internal static bool LoginListener<T>(this IEnumerable<T> ienumerable_0, T item)
	{
		T val = ienumerable_0.LastOrDefault();
		if (val == null)
		{
			return false;
		}
		return item.Equals(val);
	}

	internal static bool GetListener<T>(this IEnumerable<T> ienumerable_0, T item)
	{
		T val = ienumerable_0.FirstOrDefault();
		if (val == null)
		{
			return false;
		}
		return item.Equals(val);
	}

	internal static bool WriteListener<T>(this IEnumerable<T> ienumerable_0, T item)
	{
		if (ienumerable_0.GetListener(item))
		{
			return true;
		}
		return ienumerable_0.LoginListener(item);
	}
}
