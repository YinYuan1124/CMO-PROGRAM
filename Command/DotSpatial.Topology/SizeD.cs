using System;
using System.ComponentModel;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class SizeD : ISize
{
	private double _xSize;

	private double _ySize;

	private double _zSize;

	public virtual double XSize
	{
		get
		{
			return _xSize;
		}
		set
		{
			_xSize = value;
		}
	}

	public virtual double YSize
	{
		get
		{
			return _ySize;
		}
		set
		{
			_ySize = value;
		}
	}

	public virtual double ZSize
	{
		get
		{
			return _zSize;
		}
		set
		{
			_zSize = value;
		}
	}

	public SizeD()
	{
	}

	public SizeD(double double_0, double double_1, double double_2)
	{
		_xSize = double_0;
		_ySize = double_1;
		_zSize = double_2;
	}
}
