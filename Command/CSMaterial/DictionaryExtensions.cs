using System.Collections.Generic;

namespace CSMaterial;

public static class DictionaryExtensions
{
	public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary_0, TKey key, TValue newVal)
	{
		if (dictionary_0.TryGetValue(key, out var _))
		{
			dictionary_0[key] = newVal;
		}
		else
		{
			dictionary_0.Add(key, newVal);
		}
	}
}
