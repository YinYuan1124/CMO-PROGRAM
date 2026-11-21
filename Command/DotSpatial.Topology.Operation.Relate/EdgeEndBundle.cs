using System.Collections;
using System.IO;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBundle : EdgeEnd
{
	private readonly IList factoryThread = new ArrayList();

	public virtual IList EdgeEnds => factoryThread;

	public EdgeEndBundle(EdgeEnd edgeEnd_0)
		: base(edgeEnd_0.Edge, edgeEnd_0.Coordinate, edgeEnd_0.DirectedCoordinate, new Label(edgeEnd_0.Label))
	{
		Insert(edgeEnd_0);
	}

	public virtual IEnumerator GetEnumerator()
	{
		return factoryThread.GetEnumerator();
	}

	public void Insert(EdgeEnd edgeEnd_0)
	{
		factoryThread.Add(edgeEnd_0);
	}

	public override void ComputeLabel()
	{
		bool flag = false;
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (((EdgeEnd)enumerator.Current).Label.IsArea())
			{
				flag = true;
			}
		}
		if (flag)
		{
			Label = new Label(LocationType.Null, LocationType.Null, LocationType.Null);
		}
		else
		{
			Label = new Label(LocationType.Null);
		}
		for (int i = 0; i < 2; i++)
		{
			PrepareCollection(i);
			if (flag)
			{
				ReflectCollection(i);
			}
		}
	}

	private void PrepareCollection(int int_0)
	{
		int num = 0;
		bool flag = false;
		IEnumerator enumerator = GetEnumerator();
		LocationType location;
		while (enumerator.MoveNext())
		{
			location = ((EdgeEnd)enumerator.Current).Label.GetLocation(int_0);
			if (location == LocationType.Boundary)
			{
				num++;
			}
			if (location == LocationType.Interior)
			{
				flag = true;
			}
		}
		location = LocationType.Null;
		if (flag)
		{
			location = LocationType.Interior;
		}
		if (num > 0)
		{
			location = GeometryGraph.DetermineBoundary(num);
		}
		Label.SetLocation(int_0, location);
	}

	private void ReflectCollection(int int_0)
	{
		VisitCollection(int_0, PositionType.Left);
		VisitCollection(int_0, PositionType.Right);
	}

	private void VisitCollection(int int_0, PositionType positionType_0)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd edgeEnd = (EdgeEnd)enumerator.Current;
			if (edgeEnd.Label.IsArea())
			{
				switch (edgeEnd.Label.GetLocation(int_0, positionType_0))
				{
				case LocationType.Exterior:
					Label.SetLocation(int_0, positionType_0, LocationType.Exterior);
					break;
				case LocationType.Interior:
					Label.SetLocation(int_0, positionType_0, LocationType.Interior);
					return;
				}
			}
		}
	}

	public virtual void UpdateIm(IntersectionMatrix intersectionMatrix_0)
	{
		Edge.UpdateIm(Label, intersectionMatrix_0);
	}

	public override void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.WriteLine("EdgeEndBundle--> Label: " + Label);
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEnd)enumerator.Current).Write(streamWriter_0);
			streamWriter_0.WriteLine();
		}
	}
}
