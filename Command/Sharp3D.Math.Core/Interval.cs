using System;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Interval : ICloneable
{
	public enum Type
	{
		Open,
		Closed,
		OpenClosed,
		ClosedOpen
	}

	private Type _ObjectCallback;

	private double _ParameterCallback;

	private double expressionCallback;

	public Type IntervalType
	{
		get
		{
			return _ObjectCallback;
		}
		set
		{
			_ObjectCallback = value;
		}
	}

	public double Min
	{
		get
		{
			return _ParameterCallback;
		}
		set
		{
			_ParameterCallback = value;
		}
	}

	public double Max
	{
		get
		{
			return expressionCallback;
		}
		set
		{
			expressionCallback = value;
		}
	}

	public Interval()
	{
		_ObjectCallback = Type.Open;
		_ParameterCallback = 0.0;
		expressionCallback = 1.0;
	}

	public Interval(Type type_0, double double_0, double double_1)
	{
		_ObjectCallback = type_0;
		_ParameterCallback = double_0;
		expressionCallback = double_1;
	}

	public Interval(Interval interval_0)
	{
		_ObjectCallback = interval_0.IntervalType;
		_ParameterCallback = interval_0.Min;
		expressionCallback = interval_0.Max;
	}

	object ICloneable.Clone()
	{
		return new Interval(this);
	}

	public Interval Clone()
	{
		return new Interval(this);
	}

	public override int GetHashCode()
	{
		return _ParameterCallback.GetHashCode() ^ expressionCallback.GetHashCode() ^ _ObjectCallback.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is Interval)
		{
			Interval interval = (Interval)obj;
			if (_ParameterCallback == interval.Min && expressionCallback == interval.Max)
			{
				return _ObjectCallback == interval.IntervalType;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		Type objectCallback = _ObjectCallback;
		if (1 == 0)
		{
		}
		string result = objectCallback switch
		{
			Type.Open => string.Format(CultureInfo.InvariantCulture, "({0}, {1})", _ParameterCallback, expressionCallback), 
			Type.Closed => string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", _ParameterCallback, expressionCallback), 
			Type.OpenClosed => string.Format(CultureInfo.InvariantCulture, "({0}, {1}]", _ParameterCallback, expressionCallback), 
			Type.ClosedOpen => string.Format(CultureInfo.InvariantCulture, "[{0}, {1})", _ParameterCallback, expressionCallback), 
			_ => "Unknown interval type.", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public bool IsInside(double double_0)
	{
		if (_ParameterCallback < double_0 && double_0 < expressionCallback)
		{
			return true;
		}
		if (_ObjectCallback == Type.Open)
		{
			return false;
		}
		if (double_0 == _ParameterCallback)
		{
			if (_ObjectCallback != Type.Closed && _ObjectCallback != Type.ClosedOpen)
			{
				return false;
			}
			return true;
		}
		if (double_0 == expressionCallback)
		{
			if (_ObjectCallback != Type.Closed && _ObjectCallback != Type.OpenClosed)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool operator ==(Interval interval_0, Interval interval_1)
	{
		return object.Equals(interval_0, interval_1);
	}

	public static bool operator !=(Interval interval_0, Interval interval_1)
	{
		return !object.Equals(interval_0, interval_1);
	}
}
