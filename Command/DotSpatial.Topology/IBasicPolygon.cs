using System;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface IBasicPolygon : ICloneable, IBasicGeometry
{
	ICollection<IBasicLineString> Holes { get; set; }

	IBasicLineString Shell { get; set; }

	int NumHoles { get; }
}
