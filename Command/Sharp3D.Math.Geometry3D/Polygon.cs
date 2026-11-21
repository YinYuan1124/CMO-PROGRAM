using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Sharp3D.Math.Core;

namespace Sharp3D.Math.Geometry3D;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class Polygon : ICloneable
{
	private List<Vector3F> list_0 = new List<Vector3F>();

	[XmlArrayItem(Type = typeof(Vector3F))]
	public List<Vector3F> Points => list_0;

	public int Count => list_0.Count;

	public Polygon()
	{
	}

	public Polygon(Vector3F[] vector3F_0)
	{
		list_0.AddRange(vector3F_0);
	}

	public Polygon(List<Vector3F> list_1)
	{
		list_0.AddRange(list_1);
	}

	public Polygon(Polygon polygon_0)
	{
		list_0.AddRange(polygon_0.list_0);
	}

	object ICloneable.Clone()
	{
		return new Polygon(this);
	}

	public Polygon Clone()
	{
		return new Polygon(this);
	}

	public void Flip()
	{
		list_0.Reverse();
	}
}
