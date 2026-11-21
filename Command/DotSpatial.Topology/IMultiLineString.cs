using System;
using System.Collections;

namespace DotSpatial.Topology;

public interface IMultiLineString : IEnumerable, ICloneable, IComparable, IBasicGeometry, IGeometry, IOverlay, IRelate, GInterface3
{
	new ILineString this[int int_0] { get; }
}
