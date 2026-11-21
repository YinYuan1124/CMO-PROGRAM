using System.Collections.Generic;
using System.Text;

namespace DotSpatial.Topology.GeometriesGraph;

public class TopologyLocation
{
	private LocationType[] _ResolverInstance;

	public virtual LocationType this[PositionType positionType_0]
	{
		get
		{
			return Get(positionType_0);
		}
		set
		{
			SetLocation(positionType_0, value);
		}
	}

	public virtual bool IsNull
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < _ResolverInstance.Length)
				{
					if (_ResolverInstance[num] != LocationType.Null)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public virtual bool IsAnyNull
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < _ResolverInstance.Length)
				{
					if (_ResolverInstance[num] == LocationType.Null)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public virtual bool IsArea => _ResolverInstance.Length > 1;

	public virtual bool IsLine => _ResolverInstance.Length == 1;

	public TopologyLocation(ICollection<LocationType> icollection_0)
	{
		QueryParameter(icollection_0.Count);
	}

	public TopologyLocation(LocationType locationType_0, LocationType locationType_1, LocationType locationType_2)
	{
		QueryParameter(3);
		_ResolverInstance[0] = locationType_0;
		_ResolverInstance[1] = locationType_1;
		_ResolverInstance[2] = locationType_2;
	}

	public TopologyLocation(LocationType locationType_0)
	{
		QueryParameter(1);
		_ResolverInstance[0] = locationType_0;
	}

	public TopologyLocation(TopologyLocation topologyLocation_0)
	{
		if (topologyLocation_0 != null)
		{
			QueryParameter(topologyLocation_0._ResolverInstance.Length);
			for (int i = 0; i < _ResolverInstance.Length; i++)
			{
				_ResolverInstance[i] = topologyLocation_0._ResolverInstance[i];
			}
		}
	}

	private void QueryParameter(int int_0)
	{
		_ResolverInstance = new LocationType[int_0];
		SetAllLocations(LocationType.Null);
	}

	public virtual LocationType Get(PositionType positionType_0)
	{
		if ((int)positionType_0 < _ResolverInstance.Length)
		{
			return _ResolverInstance[(int)positionType_0];
		}
		return LocationType.Null;
	}

	public virtual bool IsEqualOnSide(TopologyLocation topologyLocation_0, int int_0)
	{
		return _ResolverInstance[int_0] == topologyLocation_0._ResolverInstance[int_0];
	}

	public virtual void Flip()
	{
		if (_ResolverInstance.Length > 1)
		{
			LocationType locationType = _ResolverInstance[1];
			_ResolverInstance[1] = _ResolverInstance[2];
			_ResolverInstance[2] = locationType;
		}
	}

	public virtual void SetAllLocations(LocationType locationType_0)
	{
		for (int i = 0; i < _ResolverInstance.Length; i++)
		{
			_ResolverInstance[i] = locationType_0;
		}
	}

	public virtual void SetAllLocationsIfNull(LocationType locationType_0)
	{
		for (int i = 0; i < _ResolverInstance.Length; i++)
		{
			if (_ResolverInstance[i] == LocationType.Null)
			{
				_ResolverInstance[i] = locationType_0;
			}
		}
	}

	public virtual void SetLocation(PositionType positionType_0, LocationType locationType_0)
	{
		_ResolverInstance[(int)positionType_0] = locationType_0;
	}

	public virtual void SetLocation(LocationType locationType_0)
	{
		SetLocation(PositionType.On, locationType_0);
	}

	public virtual LocationType[] GetLocations()
	{
		return _ResolverInstance;
	}

	public virtual void SetLocations(LocationType locationType_0, LocationType locationType_1, LocationType locationType_2)
	{
		_ResolverInstance[0] = locationType_0;
		_ResolverInstance[1] = locationType_1;
		_ResolverInstance[2] = locationType_2;
	}

	public virtual void SetLocations(TopologyLocation topologyLocation_0)
	{
		for (int i = 0; i < topologyLocation_0._ResolverInstance.Length; i++)
		{
			_ResolverInstance[i] = topologyLocation_0._ResolverInstance[i];
		}
	}

	public virtual bool AllPositionsEqual(LocationType locationType_0)
	{
		for (int i = 0; i < _ResolverInstance.Length; i++)
		{
			if (_ResolverInstance[i] != locationType_0)
			{
				return false;
			}
		}
		return true;
	}

	public virtual void Merge(TopologyLocation topologyLocation_0)
	{
		if (topologyLocation_0._ResolverInstance.Length > _ResolverInstance.Length)
		{
			_ResolverInstance = new LocationType[3]
			{
				_ResolverInstance[0],
				LocationType.Null,
				LocationType.Null
			};
		}
		for (int i = 0; i < _ResolverInstance.Length; i++)
		{
			if (_ResolverInstance[i] == LocationType.Null && i < topologyLocation_0._ResolverInstance.Length)
			{
				_ResolverInstance[i] = topologyLocation_0._ResolverInstance[i];
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (_ResolverInstance.Length > 1)
		{
			stringBuilder.Append(Location.ToLocationSymbol(_ResolverInstance[1]));
		}
		stringBuilder.Append(Location.ToLocationSymbol(_ResolverInstance[0]));
		if (_ResolverInstance.Length > 1)
		{
			stringBuilder.Append(Location.ToLocationSymbol(_ResolverInstance[2]));
		}
		return stringBuilder.ToString();
	}
}
