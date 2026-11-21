using System;

namespace DotSpatial.Topology;

[Serializable]
public class PrecisionModel : IComparable
{
	public const double MAXIMUM_PRECISE_VALUE = 9007199254740992.0;

	private readonly PrecisionModelType _modelType;

	private double _scale;

	public virtual bool IsFloating
	{
		get
		{
			if (_modelType == PrecisionModelType.Floating)
			{
				return true;
			}
			return _modelType == PrecisionModelType.FloatingSingle;
		}
	}

	public virtual int MaximumSignificantDigits => _modelType switch
	{
		PrecisionModelType.Floating => 16, 
		PrecisionModelType.FloatingSingle => 6, 
		PrecisionModelType.Fixed => 1 + (int)Math.Ceiling(Math.Log(Scale) / Math.Log(10.0)), 
		_ => throw new ArgumentOutOfRangeException(_modelType.ToString()), 
	};

	public virtual double Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = Math.Abs(value);
		}
	}

	[Obsolete("Offsets are no longer used")]
	public virtual double OffsetX => 0.0;

	[Obsolete("Offsets are no longer used")]
	public virtual double OffsetY => 0.0;

	public PrecisionModel()
	{
		_modelType = PrecisionModelType.Floating;
	}

	public PrecisionModel(PrecisionModelType precisionModelType_0)
	{
		_modelType = precisionModelType_0;
		if (precisionModelType_0 == PrecisionModelType.Fixed)
		{
			_scale = 1.0;
		}
	}

	public PrecisionModel(double double_0)
	{
		_modelType = PrecisionModelType.Fixed;
		_scale = double_0;
	}

	public PrecisionModel(PrecisionModel precisionModel_0)
	{
		_modelType = precisionModel_0._modelType;
		_scale = precisionModel_0._scale;
	}

	public virtual int CompareTo(object target)
	{
		PrecisionModel obj = (PrecisionModel)target;
		int maximumSignificantDigits = MaximumSignificantDigits;
		int maximumSignificantDigits2 = obj.MaximumSignificantDigits;
		return maximumSignificantDigits.CompareTo(maximumSignificantDigits2);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual PrecisionModelType GetPrecisionModelType()
	{
		return _modelType;
	}

	[Obsolete("Use MakePrecise instead")]
	public virtual void ToInternal(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (IsFloating)
		{
			coordinate_1.X = coordinate_0.X;
			coordinate_1.Y = coordinate_0.Y;
		}
		else
		{
			coordinate_1.X = MakePrecise(coordinate_0.X);
			coordinate_1.Y = MakePrecise(coordinate_0.Y);
		}
		coordinate_1.Z = coordinate_0.Z;
	}

	[Obsolete("Use MakePrecise instead")]
	public virtual Coordinate ToInternal(Coordinate coordinate_0)
	{
		Coordinate coordinate = new Coordinate(coordinate_0);
		MakePrecise(coordinate);
		return coordinate;
	}

	[Obsolete("No longer needed, since internal representation is same as external representation")]
	public virtual Coordinate ToExternal(Coordinate coordinate_0)
	{
		return new Coordinate(coordinate_0);
	}

	[Obsolete("No longer needed, since internal representation is same as external representation")]
	public virtual void ToExternal(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		coordinate_1.X = coordinate_0.X;
		coordinate_1.Y = coordinate_0.Y;
	}

	public virtual double MakePrecise(double double_0)
	{
		if (_modelType == PrecisionModelType.FloatingSingle)
		{
			return (float)double_0;
		}
		if (_modelType == PrecisionModelType.Fixed)
		{
			return Math.Floor(double_0 * _scale + 0.5) / _scale;
		}
		return double_0;
	}

	public virtual void MakePrecise(Coordinate coordinate_0)
	{
		if (_modelType != 0)
		{
			coordinate_0.X = MakePrecise(coordinate_0.X);
			coordinate_0.Y = MakePrecise(coordinate_0.Y);
		}
	}

	public override string ToString()
	{
		string result = "UNKNOWN";
		if (_modelType == PrecisionModelType.Floating)
		{
			result = "Floating";
		}
		else if (_modelType == PrecisionModelType.FloatingSingle)
		{
			result = "Floating-Single";
		}
		else if (_modelType == PrecisionModelType.Fixed)
		{
			result = "Fixed (Scale=" + Scale + ")";
		}
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is PrecisionModel)
		{
			PrecisionModel precisionModel = (PrecisionModel)obj;
			if (_modelType == precisionModel._modelType)
			{
				return _scale == precisionModel._scale;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(PrecisionModel precisionModel_0, PrecisionModel precisionModel_1)
	{
		return object.Equals(precisionModel_0, precisionModel_1);
	}

	public static bool operator !=(PrecisionModel precisionModel_0, PrecisionModel precisionModel_1)
	{
		return !(precisionModel_0 == precisionModel_1);
	}
}
