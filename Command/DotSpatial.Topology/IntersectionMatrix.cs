using System;
using System.Text;

namespace DotSpatial.Topology;

public class IntersectionMatrix : GInterface4
{
	private readonly DimensionType[,] factoryProcess;

	public DimensionType this[LocationType locationType_0, LocationType locationType_1]
	{
		get
		{
			return Get(locationType_0, locationType_1);
		}
		set
		{
			Set(locationType_0, locationType_1, value);
		}
	}

	public IntersectionMatrix()
	{
		factoryProcess = new DimensionType[3, 3];
		SetAll(DimensionType.False);
	}

	public IntersectionMatrix(string string_0)
		: this()
	{
		Set(string_0);
	}

	public IntersectionMatrix(IntersectionMatrix intersectionMatrix_0)
		: this()
	{
		factoryProcess[0, 0] = intersectionMatrix_0.factoryProcess[0, 0];
		factoryProcess[0, 1] = intersectionMatrix_0.factoryProcess[0, 1];
		factoryProcess[0, 2] = intersectionMatrix_0.factoryProcess[0, 2];
		factoryProcess[1, 0] = intersectionMatrix_0.factoryProcess[1, 0];
		factoryProcess[1, 1] = intersectionMatrix_0.factoryProcess[1, 1];
		factoryProcess[1, 2] = intersectionMatrix_0.factoryProcess[1, 2];
		factoryProcess[2, 0] = intersectionMatrix_0.factoryProcess[2, 0];
		factoryProcess[2, 1] = intersectionMatrix_0.factoryProcess[2, 1];
		factoryProcess[2, 2] = intersectionMatrix_0.factoryProcess[2, 2];
	}

	public virtual void Add(GInterface4 ginterface4_0)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				SetAtLeast((LocationType)i, (LocationType)j, ginterface4_0.Get((LocationType)i, (LocationType)j));
			}
		}
	}

	public virtual void Set(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0)
	{
		factoryProcess[(int)locationType_0, (int)locationType_1] = dimensionType_0;
	}

	public void Set(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			int num = i / 3;
			int num2 = i % 3;
			factoryProcess[num, num2] = Dimension.ToDimensionValue(string_0[i]);
		}
	}

	public virtual void SetAtLeast(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0)
	{
		if (factoryProcess[(int)locationType_0, (int)locationType_1] < dimensionType_0)
		{
			factoryProcess[(int)locationType_0, (int)locationType_1] = dimensionType_0;
		}
	}

	public virtual void SetAtLeastIfValid(LocationType locationType_0, LocationType locationType_1, DimensionType dimensionType_0)
	{
		if (locationType_0 >= LocationType.Interior && locationType_1 >= LocationType.Interior)
		{
			SetAtLeast(locationType_0, locationType_1, dimensionType_0);
		}
	}

	public virtual void SetAtLeast(string string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			int locationType_ = i / 3;
			int locationType_2 = i % 3;
			SetAtLeast((LocationType)locationType_, (LocationType)locationType_2, Dimension.ToDimensionValue(string_0[i]));
		}
	}

	public void SetAll(DimensionType dimensionType_0)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				factoryProcess[i, j] = dimensionType_0;
			}
		}
	}

	public virtual DimensionType Get(LocationType locationType_0, LocationType locationType_1)
	{
		return factoryProcess[(int)locationType_0, (int)locationType_1];
	}

	public virtual bool IsDisjoint()
	{
		if (factoryProcess[0, 0] == DimensionType.False && factoryProcess[0, 1] == DimensionType.False && factoryProcess[1, 0] == DimensionType.False)
		{
			return factoryProcess[1, 1] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsIntersects()
	{
		return !IsDisjoint();
	}

	public virtual bool IsTouches(DimensionType dimensionType_0, DimensionType dimensionType_1)
	{
		if (dimensionType_0 <= dimensionType_1)
		{
			if ((dimensionType_0 == DimensionType.Surface && dimensionType_1 == DimensionType.Surface) || (dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Curve) || (dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Surface) || (dimensionType_0 == DimensionType.Point && dimensionType_1 == DimensionType.Surface) || (dimensionType_0 == DimensionType.Point && dimensionType_1 == DimensionType.Curve))
			{
				if (factoryProcess[0, 0] == DimensionType.False)
				{
					if (!Matches(factoryProcess[0, 1], 'T') && !Matches(factoryProcess[1, 0], 'T'))
					{
						return Matches(factoryProcess[1, 1], 'T');
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return IsTouches(dimensionType_1, dimensionType_0);
	}

	public virtual bool IsCrosses(DimensionType dimensionType_0, DimensionType dimensionType_1)
	{
		if ((dimensionType_0 == DimensionType.Point && dimensionType_1 == DimensionType.Curve) || (dimensionType_0 == DimensionType.Point && dimensionType_1 == DimensionType.Surface) || (dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Surface))
		{
			if (Matches(factoryProcess[0, 0], 'T'))
			{
				return Matches(factoryProcess[0, 2], 'T');
			}
			return false;
		}
		if ((dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Point) || (dimensionType_0 == DimensionType.Surface && dimensionType_1 == DimensionType.Point) || (dimensionType_0 == DimensionType.Surface && dimensionType_1 == DimensionType.Curve))
		{
			if (Matches(factoryProcess[0, 0], 'T'))
			{
				return Matches(factoryProcess[2, 0], 'T');
			}
			return false;
		}
		if (dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Curve)
		{
			return factoryProcess[0, 0] == DimensionType.Point;
		}
		return false;
	}

	public virtual bool IsWithin()
	{
		if (Matches(factoryProcess[0, 0], 'T') && factoryProcess[0, 2] == DimensionType.False)
		{
			return factoryProcess[1, 2] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsContains()
	{
		if (Matches(factoryProcess[0, 0], 'T') && factoryProcess[2, 0] == DimensionType.False)
		{
			return factoryProcess[2, 1] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsCovers()
	{
		if ((Matches(factoryProcess[0, 0], 'T') || Matches(factoryProcess[0, 1], 'T') || Matches(factoryProcess[1, 0], 'T') || Matches(factoryProcess[1, 1], 'T')) && factoryProcess[2, 0] == DimensionType.False)
		{
			return factoryProcess[2, 1] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsEquals(DimensionType dimensionType_0, DimensionType dimensionType_1)
	{
		if (dimensionType_0 == dimensionType_1)
		{
			if (Matches(factoryProcess[0, 0], 'T') && factoryProcess[2, 0] == DimensionType.False && factoryProcess[0, 2] == DimensionType.False && factoryProcess[2, 1] == DimensionType.False)
			{
				return factoryProcess[1, 2] == DimensionType.False;
			}
			return false;
		}
		return false;
	}

	public virtual bool IsOverlaps(DimensionType dimensionType_0, DimensionType dimensionType_1)
	{
		if ((dimensionType_0 == DimensionType.Point && dimensionType_1 == DimensionType.Point) || (dimensionType_0 == DimensionType.Surface && dimensionType_1 == DimensionType.Surface))
		{
			if (Matches(factoryProcess[0, 0], 'T') && Matches(factoryProcess[0, 2], 'T'))
			{
				return Matches(factoryProcess[2, 0], 'T');
			}
			return false;
		}
		if (dimensionType_0 == DimensionType.Curve && dimensionType_1 == DimensionType.Curve)
		{
			if (factoryProcess[0, 0] == DimensionType.Curve && Matches(factoryProcess[0, 2], 'T'))
			{
				return Matches(factoryProcess[2, 0], 'T');
			}
			return false;
		}
		return false;
	}

	public virtual bool Matches(string string_0)
	{
		if (string_0.Length == 9)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (!Matches(factoryProcess[i, j], string_0[3 * i + j]))
					{
						return false;
					}
				}
			}
			return true;
		}
		throw new ArgumentException("Should be length 9: " + string_0);
	}

	public virtual GInterface4 Transpose()
	{
		DimensionType dimensionType = factoryProcess[1, 0];
		factoryProcess[1, 0] = factoryProcess[0, 1];
		factoryProcess[0, 1] = dimensionType;
		dimensionType = factoryProcess[2, 0];
		factoryProcess[2, 0] = factoryProcess[0, 2];
		factoryProcess[0, 2] = dimensionType;
		dimensionType = factoryProcess[2, 1];
		factoryProcess[2, 1] = factoryProcess[1, 2];
		factoryProcess[1, 2] = dimensionType;
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("123456789");
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				stringBuilder[3 * i + j] = Dimension.ToDimensionSymbol(factoryProcess[i, j]);
			}
		}
		return stringBuilder.ToString();
	}

	public static bool Matches(DimensionType dimensionType_0, char char_0)
	{
		if (char_0 != '*')
		{
			if (char_0 != 'T' || (dimensionType_0 < DimensionType.Point && dimensionType_0 != DimensionType.True))
			{
				if (char_0 == 'F' && dimensionType_0 == DimensionType.False)
				{
					return true;
				}
				if (char_0 == '0' && dimensionType_0 == DimensionType.Point)
				{
					return true;
				}
				if (char_0 == '1' && dimensionType_0 == DimensionType.Curve)
				{
					return true;
				}
				if (char_0 == '2' && dimensionType_0 == DimensionType.Surface)
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	public static bool Matches(string string_0, string string_1)
	{
		return new IntersectionMatrix(string_0).Matches(string_1);
	}
}
