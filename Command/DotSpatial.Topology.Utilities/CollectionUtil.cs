using System.Collections;

namespace DotSpatial.Topology.Utilities;

public class CollectionUtil
{
	public delegate T GenericMethod<T>(T obj);

	public static IList Transform(ICollection icollection_0, GenericMethod<object> genericMethod_0)
	{
		IList list = new ArrayList();
		foreach (object item in icollection_0)
		{
			list.Add(genericMethod_0(item));
		}
		return list;
	}

	public static void Apply(ICollection icollection_0, GenericMethod<object> genericMethod_0)
	{
		foreach (object item in icollection_0)
		{
			genericMethod_0(item);
		}
	}

	public static IList Select(ICollection icollection_0, GenericMethod<object> genericMethod_0)
	{
		IList list = new ArrayList();
		foreach (object item in icollection_0)
		{
			if (true.Equals(genericMethod_0(item)))
			{
				list.Add(item);
			}
		}
		return list;
	}
}
