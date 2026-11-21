using System;
using System.ComponentModel;
using DotSpatial.Serialization;

namespace DotSpatial;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class SerializeExtent : ICloneable
{
	[Serialize("XMax")]
	public double XMax;

	[Serialize("XMin")]
	public double XMin;

	[Serialize("YMax")]
	public double YMax;

	[Serialize("YMin")]
	public double YMin;

	public SerializeExtent()
	{
		XMin = double.MaxValue;
		XMax = double.MinValue;
		YMin = double.MaxValue;
		YMax = double.MinValue;
	}

	public SerializeExtent(double double_0, double double_1, double double_2, double double_3)
	{
		XMin = double_0;
		YMin = double_1;
		XMax = double_2;
		YMax = double_3;
	}

	public SerializeExtent(double[] double_0, int int_0)
	{
		XMin = double_0[int_0];
		YMin = double_0[1 + int_0];
		XMax = double_0[2 + int_0];
		YMax = double_0[3 + int_0];
	}

	public SerializeExtent(double[] double_0)
	{
		XMin = double_0[0];
		YMin = double_0[1];
		XMax = double_0[2];
		YMax = double_0[3];
	}

	public object Clone()
	{
		return new SerializeExtent(XMin, YMin, XMax, YMax);
	}

	public bool IsEmpty()
	{
		if (XMin <= XMax && YMin <= YMax)
		{
			return false;
		}
		return true;
	}
}
