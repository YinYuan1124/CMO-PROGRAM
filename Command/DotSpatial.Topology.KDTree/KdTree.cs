using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class KdTree
{
	private readonly int serializerCollection;

	private int _RefCollection;

	private KdNode _ErrorCollection;

	public int Count => _RefCollection;

	public int K => serializerCollection;

	public KdTree(int int_0)
	{
		if (int_0 < 0)
		{
			throw new NegativeArgumentException("k");
		}
		serializerCollection = int_0;
		_ErrorCollection = null;
	}

	public void Insert(double[] double_0, object object_0)
	{
		if (double_0.Length != serializerCollection)
		{
			throw new KeySizeException();
		}
		_ErrorCollection = KdNode.Insert(new HPoint(double_0), object_0, _ErrorCollection, 0, serializerCollection);
		_RefCollection++;
	}

	public object Search(double[] double_0)
	{
		if (double_0.Length == serializerCollection)
		{
			return KdNode.Search(new HPoint(double_0), _ErrorCollection, serializerCollection)?.m_AdvisorCollection;
		}
		throw new KeySizeException();
	}

	public void Delete(double[] double_0)
	{
		if (double_0.Length != serializerCollection)
		{
			throw new KeySizeException();
		}
		(KdNode.Search(new HPoint(double_0), _ErrorCollection, serializerCollection) ?? throw new KeyMissingException()).IsDeleted = true;
		_RefCollection--;
	}

	public object Nearest(double[] double_0)
	{
		return Nearest(double_0, 1)[0];
	}

	public object[] Nearest(double[] double_0, int int_0)
	{
		if (int_0 >= 0 && int_0 <= _RefCollection)
		{
			if (double_0.Length == serializerCollection)
			{
				object[] array = new object[int_0];
				NearestNeighborList nearestNeighborList = new NearestNeighborList(int_0);
				HRect hrect_ = HRect.InfiniteHRect(double_0.Length);
				HPoint hpoint_ = new HPoint(double_0);
				KdNode.Nnbr(_ErrorCollection, hpoint_, hrect_, 1.79769E+30, 0, serializerCollection, nearestNeighborList);
				for (int i = 0; i < int_0; i++)
				{
					KdNode kdNode = (KdNode)nearestNeighborList.RemoveHighest();
					array[int_0 - i - 1] = kdNode.m_AdvisorCollection;
				}
				return array;
			}
			throw new KeySizeException();
		}
		throw new NeighborsOutOfRangeException();
	}

	public object Farthest(double[] double_0)
	{
		return Farthest(double_0, 1)[0];
	}

	public object[] Farthest(double[] double_0, int int_0)
	{
		if (int_0 >= 0 && int_0 <= _RefCollection)
		{
			if (double_0.Length == serializerCollection)
			{
				object[] array = new object[int_0];
				FarthestNeighborList farthestNeighborList = new FarthestNeighborList(int_0);
				HRect hrect_ = HRect.InfiniteHRect(double_0.Length);
				HPoint hpoint_ = new HPoint(double_0);
				KdNode.FarthestNeighbor(_ErrorCollection, hpoint_, hrect_, 0.0, 0, serializerCollection, farthestNeighborList);
				for (int i = 0; i < int_0; i++)
				{
					KdNode kdNode = (KdNode)farthestNeighborList.RemoveFarthest();
					array[int_0 - i - 1] = kdNode.m_AdvisorCollection;
				}
				return array;
			}
			throw new KeySizeException();
		}
		throw new NeighborsOutOfRangeException();
	}

	public object[] SearchRange(double[] double_0, double[] double_1)
	{
		if (double_0.Length == double_1.Length)
		{
			if (double_0.Length == serializerCollection)
			{
				List<KdNode> list = new List<KdNode>();
				KdNode.SearchRange(new HPoint(double_0), new HPoint(double_1), _ErrorCollection, 0, serializerCollection, list);
				object[] array = new object[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					KdNode kdNode = list[i];
					array[i] = kdNode.m_AdvisorCollection;
				}
				return array;
			}
			throw new KeySizeException();
		}
		throw new KeySizeException();
	}

	public override string ToString()
	{
		return _ErrorCollection.ToString(0);
	}
}
