using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface GInterface3 : IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate
{
	int Count { get; }

	IGeometry this[int int_0] { get; }

	bool IsHomogeneous { get; }

	IGeometry[] Geometries { get; set; }
}
