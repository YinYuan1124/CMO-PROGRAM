using System.Text;

namespace DotSpatial.Topology.GeometriesGraph;

public class Label
{
	private readonly TopologyLocation[] connectionInstance = new TopologyLocation[2];

	public virtual int GeometryCount
	{
		get
		{
			int num = 0;
			if (!connectionInstance[0].IsNull)
			{
				num++;
			}
			if (!connectionInstance[1].IsNull)
			{
				num++;
			}
			return num;
		}
	}

	public Label(LocationType locationType_0)
	{
		connectionInstance[0] = new TopologyLocation(locationType_0);
		connectionInstance[1] = new TopologyLocation(locationType_0);
	}

	public Label(int int_0, LocationType locationType_0)
	{
		connectionInstance[0] = new TopologyLocation(LocationType.Null);
		connectionInstance[1] = new TopologyLocation(LocationType.Null);
		connectionInstance[int_0].SetLocation(locationType_0);
	}

	public Label(LocationType locationType_0, LocationType locationType_1, LocationType locationType_2)
	{
		connectionInstance[0] = new TopologyLocation(locationType_0, locationType_1, locationType_2);
		connectionInstance[1] = new TopologyLocation(locationType_0, locationType_1, locationType_2);
	}

	public Label(int int_0, LocationType locationType_0, LocationType locationType_1, LocationType locationType_2)
	{
		connectionInstance[0] = new TopologyLocation(LocationType.Null, LocationType.Null, LocationType.Null);
		connectionInstance[1] = new TopologyLocation(LocationType.Null, LocationType.Null, LocationType.Null);
		connectionInstance[int_0].SetLocations(locationType_0, locationType_1, locationType_2);
	}

	public Label(int int_0, TopologyLocation topologyLocation_0)
	{
		connectionInstance[0] = new TopologyLocation(topologyLocation_0.GetLocations());
		connectionInstance[1] = new TopologyLocation(topologyLocation_0.GetLocations());
		connectionInstance[int_0].SetLocations(topologyLocation_0);
	}

	public Label(Label label_0)
	{
		connectionInstance[0] = new TopologyLocation(label_0.connectionInstance[0]);
		connectionInstance[1] = new TopologyLocation(label_0.connectionInstance[1]);
	}

	public static Label ToLineLabel(Label label_0)
	{
		Label label = new Label(LocationType.Null);
		for (int i = 0; i < 2; i++)
		{
			label.SetLocation(i, label_0.GetLocation(i));
		}
		return label;
	}

	public virtual void Flip()
	{
		connectionInstance[0].Flip();
		connectionInstance[1].Flip();
	}

	public virtual LocationType GetLocation(int int_0, PositionType positionType_0)
	{
		return connectionInstance[int_0].Get(positionType_0);
	}

	public virtual LocationType GetLocation(int int_0)
	{
		return connectionInstance[int_0].Get(PositionType.On);
	}

	public virtual void SetLocation(int int_0, PositionType positionType_0, LocationType locationType_0)
	{
		connectionInstance[int_0].SetLocation(positionType_0, locationType_0);
	}

	public virtual void SetLocation(int int_0, LocationType locationType_0)
	{
		connectionInstance[int_0].SetLocation(PositionType.On, locationType_0);
	}

	public virtual void SetAllLocations(int int_0, LocationType locationType_0)
	{
		connectionInstance[int_0].SetAllLocations(locationType_0);
	}

	public virtual void SetAllLocationsIfNull(int int_0, LocationType locationType_0)
	{
		connectionInstance[int_0].SetAllLocationsIfNull(locationType_0);
	}

	public virtual void SetAllLocationsIfNull(LocationType locationType_0)
	{
		SetAllLocationsIfNull(0, locationType_0);
		SetAllLocationsIfNull(1, locationType_0);
	}

	public virtual void Merge(Label label_0)
	{
		for (int i = 0; i < 2; i++)
		{
			if (connectionInstance[i] == null && label_0.connectionInstance[i] != null)
			{
				connectionInstance[i] = new TopologyLocation(label_0.connectionInstance[i]);
			}
			else
			{
				connectionInstance[i].Merge(label_0.connectionInstance[i]);
			}
		}
	}

	public virtual bool IsNull(int int_0)
	{
		return connectionInstance[int_0].IsNull;
	}

	public virtual bool IsAnyNull(int int_0)
	{
		return connectionInstance[int_0].IsAnyNull;
	}

	public virtual bool IsArea()
	{
		if (connectionInstance[0].IsArea)
		{
			return true;
		}
		return connectionInstance[1].IsArea;
	}

	public virtual bool IsArea(int int_0)
	{
		return connectionInstance[int_0].IsArea;
	}

	public virtual bool IsLine(int int_0)
	{
		return connectionInstance[int_0].IsLine;
	}

	public virtual bool IsEqualOnSide(Label label_0, int int_0)
	{
		if (connectionInstance[0].IsEqualOnSide(label_0.connectionInstance[0], int_0))
		{
			return connectionInstance[1].IsEqualOnSide(label_0.connectionInstance[1], int_0);
		}
		return false;
	}

	public virtual bool AllPositionsEqual(int int_0, LocationType locationType_0)
	{
		return connectionInstance[int_0].AllPositionsEqual(locationType_0);
	}

	public virtual void ToLine(int int_0)
	{
		if (connectionInstance[int_0].IsArea)
		{
			connectionInstance[int_0] = new TopologyLocation(connectionInstance[int_0].GetLocations()[0]);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (connectionInstance[0] != null)
		{
			stringBuilder.Append("a:");
			stringBuilder.Append(connectionInstance[0].ToString());
		}
		if (connectionInstance[1] != null)
		{
			stringBuilder.Append(" b:");
			stringBuilder.Append(connectionInstance[1].ToString());
		}
		return stringBuilder.ToString();
	}
}
