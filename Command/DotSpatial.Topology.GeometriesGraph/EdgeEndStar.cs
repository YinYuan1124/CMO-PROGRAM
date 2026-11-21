using System.Collections;
using System.IO;
using Command.Listeners;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class EdgeEndStar
{
	private readonly IDictionary consumerInstance = new SortedList();

	private readonly LocationType[] facadeInstance = new LocationType[2]
	{
		LocationType.Null,
		LocationType.Null
	};

	private IList _ProxyInstance;

	protected IDictionary EdgeMap => consumerInstance;

	protected IList EdgeList => _ProxyInstance;

	public virtual Coordinate Coordinate
	{
		get
		{
			IEnumerator enumerator = GetEnumerator();
			if (enumerator.MoveNext())
			{
				return ((EdgeEnd)enumerator.Current).Coordinate;
			}
			return Coordinate.Empty;
		}
	}

	public virtual int Degree => consumerInstance.Count;

	public virtual IList Edges
	{
		get
		{
			InitializeEdges();
			return _ProxyInstance;
		}
	}

	public virtual bool IsAreaLabelsConsistent
	{
		get
		{
			TestParameter();
			return StopParameter(0);
		}
	}

	public abstract void Insert(EdgeEnd edgeEnd_0);

	protected void InsertEdgeEnd(EdgeEnd edgeEnd_0, object object_0)
	{
		if (!consumerInstance.Contains(edgeEnd_0))
		{
			consumerInstance.Add(edgeEnd_0, object_0);
			_ProxyInstance = null;
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		return Edges.GetEnumerator();
	}

	protected void InitializeEdges()
	{
		if (_ProxyInstance == null)
		{
			_ProxyInstance = new ArrayList(consumerInstance.Values);
		}
	}

	public virtual EdgeEnd GetNextCw(EdgeEnd edgeEnd_0)
	{
		InitializeEdges();
		int num = _ProxyInstance.IndexOf(edgeEnd_0);
		int index = num - 1;
		if (num == 0)
		{
			index = _ProxyInstance.Count - 1;
		}
		return (EdgeEnd)_ProxyInstance[index];
	}

	public virtual void ComputeLabelling(GeometryGraph[] geometryGraph_0)
	{
		TestParameter();
		PropagateSideLabels(0);
		PropagateSideLabels(1);
		bool[] array = new bool[2];
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((EdgeEnd)enumerator.Current).Label;
			for (int i = 0; i < 2; i++)
			{
				if (label.IsLine(i) && label.GetLocation(i) == LocationType.Boundary)
				{
					array[i] = true;
				}
			}
		}
		IEnumerator enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator2.Current;
			Label label2 = edgeEnd.Label;
			for (int j = 0; j < 2; j++)
			{
				if (label2.IsAnyNull(j))
				{
					LocationType locationType_;
					if (array[j])
					{
						locationType_ = LocationType.Exterior;
					}
					else
					{
						Coordinate coordinate = edgeEnd.Coordinate;
						locationType_ = GetLocation(j, coordinate, geometryGraph_0);
					}
					label2.SetAllLocationsIfNull(j, locationType_);
				}
			}
		}
	}

	private void TestParameter()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).ComputeLabel();
		}
	}

	public virtual LocationType GetLocation(int int_0, Coordinate coordinate_0, GeometryGraph[] geometryGraph_0)
	{
		if (facadeInstance[int_0] == LocationType.Null)
		{
			facadeInstance[int_0] = SimplePointInAreaLocator.Locate(coordinate_0, geometryGraph_0[int_0].Geometry);
		}
		return facadeInstance[int_0];
	}

	private bool StopParameter(int int_0)
	{
		IList edges = Edges;
		if (edges.Count <= 0)
		{
			return true;
		}
		int index = edges.Count - 1;
		LocationType location = ((EdgeEnd)edges[index]).Label.GetLocation(int_0, PositionType.Left);
		Assert.IsTrue(location != LocationType.Null, "Found unlabelled area edge");
		LocationType locationType = location;
		IEnumerator enumerator = GetEnumerator();
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Label label = ((EdgeEnd)enumerator.Current).Label;
				Assert.IsTrue(label.IsArea(int_0), "Found non-area edge");
				LocationType location2 = label.GetLocation(int_0, PositionType.Left);
				LocationType location3 = label.GetLocation(int_0, PositionType.Right);
				if (location2 != location3)
				{
					if (location3 != locationType)
					{
						break;
					}
					locationType = location2;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public virtual void PropagateSideLabels(int int_0)
	{
		LocationType locationType = LocationType.Null;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Label label = ((EdgeEnd)enumerator.Current).Label;
			if (label.IsArea(int_0) && label.GetLocation(int_0, PositionType.Left) != LocationType.Null)
			{
				locationType = label.GetLocation(int_0, PositionType.Left);
			}
		}
		if (locationType == LocationType.Null)
		{
			return;
		}
		LocationType locationType2 = locationType;
		IEnumerator enumerator2 = GetEnumerator();
		EdgeEnd edgeEnd;
		while (true)
		{
			if (!enumerator2.MoveNext())
			{
				return;
			}
			edgeEnd = (EdgeEnd)enumerator2.Current;
			Label label2 = edgeEnd.Label;
			if (label2.GetLocation(int_0, PositionType.On) == LocationType.Null)
			{
				label2.SetLocation(int_0, PositionType.On, locationType2);
			}
			if (!label2.IsArea(int_0))
			{
				continue;
			}
			LocationType location = label2.GetLocation(int_0, PositionType.Left);
			LocationType location2 = label2.GetLocation(int_0, PositionType.Right);
			if (location2 == LocationType.Null)
			{
				Assert.IsTrue(label2.GetLocation(int_0, PositionType.Left) == LocationType.Null, "found single null side");
				label2.SetLocation(int_0, PositionType.Right, locationType2);
				label2.SetLocation(int_0, PositionType.Left, locationType2);
				continue;
			}
			if (location2 != locationType2)
			{
				break;
			}
			if (location != LocationType.Null)
			{
				locationType2 = location;
				continue;
			}
			throw new TopologyException(AccountProcess.SingleNullSide, edgeEnd.Coordinate);
		}
		throw new TopologyException(AccountProcess.SideLocationConflict, edgeEnd.Coordinate);
	}

	public virtual int FindIndex(EdgeEnd edgeEnd_0)
	{
		GetEnumerator();
		for (int i = 0; i < _ProxyInstance.Count; i++)
		{
			if ((EdgeEnd)_ProxyInstance[i] == edgeEnd_0)
			{
				return i;
			}
		}
		return -1;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).Write(streamWriter_0);
		}
	}
}
