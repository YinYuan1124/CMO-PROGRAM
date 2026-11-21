using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface IMultiPoint : IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3
{
	new IPoint this[int int_0] { get; set; }
}
