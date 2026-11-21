using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology.Voronoi;

public class HashSet<T> : IEnumerable<T>, IEnumerable, ICollection<T>
{
	private readonly Dictionary<T, T> infoProcess = new Dictionary<T, T>();

	private static object helperProcess;

	public int Count => infoProcess.Count;

	public bool IsReadOnly => false;

	public void Add(T item)
	{
		infoProcess.Add(item, item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return infoProcess.Keys.GetEnumerator();
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		infoProcess.Keys.CopyTo(array, arrayIndex);
	}

	public void Clear()
	{
		infoProcess.Clear();
	}

	public bool Contains(T item)
	{
		return infoProcess.ContainsKey(item);
	}

	public bool Remove(T item)
	{
		return infoProcess.Remove(item);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return infoProcess.Keys.GetEnumerator();
	}

	internal static bool NewRule()
	{
		return helperProcess == null;
	}
}
