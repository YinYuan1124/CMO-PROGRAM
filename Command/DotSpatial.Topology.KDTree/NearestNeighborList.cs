using Command.Objects;

namespace DotSpatial.Topology.KDTree;

public class NearestNeighborList
{
	public const int REMOVE_HIGHEST = 1;

	public const int REMOVE_LOWEST = 2;

	private readonly int codeCollection;

	private readonly PageConfigObject _ConnectionCollection;

	public double MaxPriority
	{
		get
		{
			if (_ConnectionCollection.NewParameter() == 0)
			{
				return double.PositiveInfinity;
			}
			return _ConnectionCollection.ViewParameter();
		}
	}

	public bool IsCapacityReached => _ConnectionCollection.NewParameter() >= codeCollection;

	public object Highest => _ConnectionCollection.LogoutParameter();

	public bool IsEmpty => _ConnectionCollection.NewParameter() == 0;

	public int Size => _ConnectionCollection.NewParameter();

	public NearestNeighborList(int int_0)
	{
		codeCollection = int_0;
		_ConnectionCollection = new PageConfigObject(codeCollection, double.PositiveInfinity);
	}

	public bool Insert(object object_0, double double_0)
	{
		if (_ConnectionCollection.NewParameter() < codeCollection)
		{
			_ConnectionCollection.Add(object_0, double_0);
			return true;
		}
		if (double_0 <= _ConnectionCollection.ViewParameter())
		{
			_ConnectionCollection.Remove();
			_ConnectionCollection.Add(object_0, double_0);
			return true;
		}
		return false;
	}

	public object RemoveHighest()
	{
		return _ConnectionCollection.Remove();
	}
}
