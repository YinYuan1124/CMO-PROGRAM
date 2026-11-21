namespace DotSpatial.Topology.GeometriesGraph;

public class Depth
{
	private readonly int[,] m_MapperCollection = new int[2, 3];

	public virtual int this[int int_0, PositionType positionType_0]
	{
		get
		{
			return GetDepth(int_0, positionType_0);
		}
		set
		{
			SetDepth(int_0, positionType_0, value);
		}
	}

	public Depth()
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				m_MapperCollection[i, j] = -1;
			}
		}
	}

	public static int DepthAtLocation(LocationType locationType_0)
	{
		if (1 == 0)
		{
		}
		int result = locationType_0 switch
		{
			LocationType.Exterior => 0, 
			LocationType.Interior => 1, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public virtual int GetDepth(int int_0, PositionType positionType_0)
	{
		return m_MapperCollection[int_0, (int)positionType_0];
	}

	public virtual void SetDepth(int int_0, PositionType positionType_0, int int_1)
	{
		m_MapperCollection[int_0, (int)positionType_0] = int_1;
	}

	public virtual LocationType GetLocation(int int_0, PositionType positionType_0)
	{
		if (m_MapperCollection[int_0, (int)positionType_0] <= 0)
		{
			return LocationType.Exterior;
		}
		return LocationType.Interior;
	}

	public virtual void Add(int int_0, PositionType positionType_0, LocationType locationType_0)
	{
		if (locationType_0 == LocationType.Interior)
		{
			m_MapperCollection[int_0, (int)positionType_0]++;
		}
	}

	public virtual bool IsNull()
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (m_MapperCollection[i, j] != -1)
				{
					return false;
				}
			}
		}
		return true;
	}

	public virtual bool IsNull(int int_0)
	{
		return m_MapperCollection[int_0, 1] == -1;
	}

	public virtual bool IsNull(int int_0, PositionType positionType_0)
	{
		return m_MapperCollection[int_0, (int)positionType_0] == -1;
	}

	public virtual void Add(Label label_0)
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 1; j < 3; j++)
			{
				LocationType location = label_0.GetLocation(i, (PositionType)j);
				if (location == LocationType.Exterior || location == LocationType.Interior)
				{
					if (IsNull(i, (PositionType)j))
					{
						m_MapperCollection[i, j] = DepthAtLocation(location);
					}
					else
					{
						m_MapperCollection[i, j] += DepthAtLocation(location);
					}
				}
			}
		}
	}

	public virtual int GetDelta(int int_0)
	{
		return m_MapperCollection[int_0, 2] - m_MapperCollection[int_0, 1];
	}

	public virtual void Normalize()
	{
		for (int i = 0; i < 2; i++)
		{
			if (IsNull(i))
			{
				continue;
			}
			int num = m_MapperCollection[i, 1];
			if (m_MapperCollection[i, 2] < num)
			{
				num = m_MapperCollection[i, 2];
			}
			if (num < 0)
			{
				num = 0;
			}
			for (int j = 1; j < 3; j++)
			{
				int num2 = 0;
				if (m_MapperCollection[i, j] > num)
				{
					num2 = 1;
				}
				m_MapperCollection[i, j] = num2;
			}
		}
	}

	public override string ToString()
	{
		return "A: " + m_MapperCollection[0, 1] + ", " + m_MapperCollection[0, 2] + " B: " + m_MapperCollection[1, 1] + ", " + m_MapperCollection[1, 2];
	}
}
