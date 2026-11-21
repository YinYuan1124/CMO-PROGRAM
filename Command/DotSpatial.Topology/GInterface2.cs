using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public interface GInterface2 : ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable
{
	int Dimension { get; }

	Coordinate this[int int_0] { get; set; }

	int VersionID { get; }

	double GetOrdinate(int int_0, Ordinate ordinate_0);

	void SetOrdinate(int int_0, Ordinate ordinate_0, double double_0);

	Coordinate[] ToCoordinateArray();

	IEnvelope ExpandEnvelope(IEnvelope ienvelope_0);
}
