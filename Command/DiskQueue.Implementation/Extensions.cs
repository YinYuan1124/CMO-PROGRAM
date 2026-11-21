using System.Collections.Generic;

namespace DiskQueue.Implementation;

public static class Extensions
{
	public static T GetOrCreateValue<T, K>(this IDictionary<K, T> idictionary_0, K key) where T : new()
	{
		if (!idictionary_0.TryGetValue(key, out var value))
		{
			value = new T();
			idictionary_0.Add(key, value);
		}
		return value;
	}

	public static T GetValueOrDefault<T, K>(this IDictionary<K, T> idictionary_0, K key)
	{
		if (idictionary_0.TryGetValue(key, out var value))
		{
			return value;
		}
		return default(T);
	}
}
