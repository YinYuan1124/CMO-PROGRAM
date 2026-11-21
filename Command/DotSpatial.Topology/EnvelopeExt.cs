using System;

namespace DotSpatial.Topology;

public static class EnvelopeExt
{
	public static double Area(this IEnvelope ienvelope_0)
	{
		if (ienvelope_0 == null)
		{
			return -1.0;
		}
		return ienvelope_0.Width * ienvelope_0.Height;
	}

	public static ILinearRing Border(this IEnvelope ienvelope_0)
	{
		return ienvelope_0?.ToLinearRing();
	}

	public static ILineSegment[] BorderSegments(this IEnvelope ienvelope_0)
	{
		return new ILineSegment[4]
		{
			ienvelope_0.TopBorder(),
			ienvelope_0.RightBorder(),
			ienvelope_0.BottomBorder(),
			ienvelope_0.LeftBorder()
		};
	}

	public static double Bottom(this IEnvelope ienvelope_0)
	{
		return ienvelope_0.Y - ienvelope_0.Height;
	}

	public static ILineSegment BottomBorder(this IEnvelope ienvelope_0)
	{
		return new LineSegment(ienvelope_0.BottomRight(), ienvelope_0.BottomLeft());
	}

	public static Coordinate BottomLeft(this IEnvelope ienvelope_0)
	{
		return new Coordinate(ienvelope_0.Left(), ienvelope_0.Bottom());
	}

	public static Coordinate BottomRight(this IEnvelope ienvelope_0)
	{
		return new Coordinate(ienvelope_0.Right(), ienvelope_0.Bottom());
	}

	public static Coordinate Center(this IEnvelope ienvelope_0)
	{
		if (ienvelope_0 == null)
		{
			return null;
		}
		if (ienvelope_0.IsNull)
		{
			return null;
		}
		Coordinate coordinate = new Coordinate();
		for (int i = 0; i < ienvelope_0.NumOrdinates; i++)
		{
			coordinate[i] = (ienvelope_0.Minimum[i] + ienvelope_0.Maximum[i]) / 2.0;
		}
		return coordinate;
	}

	public static double Left(this IEnvelope ienvelope_0)
	{
		return ienvelope_0.X;
	}

	public static ILineSegment LeftBorder(this IEnvelope ienvelope_0)
	{
		return new LineSegment(ienvelope_0.BottomLeft(), ienvelope_0.TopLeft());
	}

	public static double Right(this IEnvelope ienvelope_0)
	{
		return ienvelope_0.X + ienvelope_0.Width;
	}

	public static ILineSegment RightBorder(this IEnvelope ienvelope_0)
	{
		if (ienvelope_0 == null)
		{
			return null;
		}
		return new LineSegment(ienvelope_0.TopRight(), ienvelope_0.BottomRight());
	}

	public static ILinearRing ToLinearRing(this IEnvelope ienvelope_0)
	{
		return new LinearRing(new CoordinateListSequence
		{
			ienvelope_0.TopLeft(),
			ienvelope_0.TopRight(),
			ienvelope_0.BottomRight(),
			ienvelope_0.BottomLeft(),
			ienvelope_0.TopLeft()
		});
	}

	public static ILineSegment TopBorder(this IEnvelope ienvelope_0)
	{
		return new LineSegment(ienvelope_0.TopLeft(), ienvelope_0.TopRight());
	}

	public static Coordinate TopLeft(this IEnvelope ienvelope_0)
	{
		return new Coordinate(ienvelope_0.Minimum.X, ienvelope_0.Maximum.Y);
	}

	public static IPolygon ToPolygon(this IEnvelope ienvelope_0)
	{
		return new Polygon(ienvelope_0.ToLinearRing());
	}

	public static Coordinate TopRight(this IEnvelope ienvelope_0)
	{
		return new Coordinate(ienvelope_0.Maximum.X, ienvelope_0.Maximum.Y);
	}

	public static void Zoom(this IEnvelope ienvelope_0, double double_0)
	{
		if (ienvelope_0 != null && !ienvelope_0.IsNull)
		{
			double num = double_0 / 100.0;
			Coordinate coordinate = new Coordinate();
			for (int i = 0; i < ienvelope_0.NumOrdinates; i++)
			{
				double num2 = ienvelope_0.Maximum[i] - ienvelope_0.Minimum[i];
				coordinate[i] = num2 + num * num2;
			}
			ienvelope_0.SetCenter(ienvelope_0.Center(), coordinate);
		}
	}

	public static IEnvelope Union(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		IEnvelope envelope = ienvelope_0.Copy();
		envelope.ExpandToInclude(coordinate_0);
		return envelope;
	}

	public static IEnvelope Union(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_1 == null)
		{
			return ienvelope_0.Copy();
		}
		if (ienvelope_1.IsNull)
		{
			return ienvelope_0.Copy();
		}
		if (ienvelope_0 == null)
		{
			return ienvelope_1.Copy();
		}
		if (ienvelope_0.IsNull)
		{
			return ienvelope_1.Copy();
		}
		IEnvelope envelope = ienvelope_0.Copy();
		envelope.ExpandToInclude(ienvelope_1);
		return envelope;
	}

	public static void SetCenter(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		ienvelope_0.SetCenter(coordinate_0, null);
	}

	public static void SetCenter(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		ienvelope_0.SetCenter(null, new Coordinate(double_0, double_1));
	}

	public static void SetCenter(this IEnvelope ienvelope_0, Coordinate coordinate_0, double double_0, double double_1)
	{
		Coordinate coordinate_ = new Coordinate(double_0, double_1);
		ienvelope_0.SetCenter(coordinate_0, coordinate_);
	}

	public static void SetCenter(this IEnvelope ienvelope_0, Coordinate coordinate_0, Coordinate coordinate_1)
	{
		int num = 0;
		int num2 = 0;
		if (ienvelope_0 == null)
		{
			return;
		}
		if (coordinate_0 != null)
		{
			num = coordinate_0.NumOrdinates;
		}
		if (coordinate_1 != null)
		{
			num2 = coordinate_1.NumOrdinates;
		}
		int val = Math.Min(num, num2);
		int num3 = Math.Max(ienvelope_0.NumOrdinates, val);
		Coordinate coordinate = new Coordinate();
		Coordinate coordinate2 = new Coordinate();
		for (int i = 0; i < num3; i++)
		{
			if (num > i && num2 > i && coordinate_0 != null && coordinate_1 != null)
			{
				coordinate[i] = coordinate_0[i] - coordinate_1[i] / 2.0;
				coordinate2[i] = coordinate_0[i] + coordinate_1[i] / 2.0;
			}
			if (num <= i && num2 <= i)
			{
				coordinate[i] = ienvelope_0.Minimum[i];
				coordinate2[i] = ienvelope_0.Maximum[i];
			}
			if (num > i && num2 <= i)
			{
				double num4 = ienvelope_0.Maximum[i] - ienvelope_0.Minimum[i];
				if (coordinate_0 != null)
				{
					coordinate[i] = coordinate_0[i] - num4 / 2.0;
					coordinate2[i] = coordinate_0[i] + num4 / 2.0;
				}
			}
			if (num <= i && num2 > i)
			{
				double num5 = (ienvelope_0.Minimum[i] + ienvelope_0.Maximum[i]) / 2.0;
				if (coordinate_1 != null)
				{
					coordinate[i] = num5 - coordinate_1[i];
					coordinate2[i] = num5 + coordinate_1[i];
				}
			}
		}
		ienvelope_0.Init(coordinate, coordinate2);
	}

	public static void SetExtents(this IEnvelope ienvelope_0, double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		if (ienvelope_0 != null)
		{
			Coordinate coordinate_ = new Coordinate(double_0, double_1, double_2);
			Coordinate coordinate_2 = new Coordinate(double_3, double_4, double_5);
			ienvelope_0.Init(coordinate_, coordinate_2);
		}
	}

	public static void SetExtents(this IEnvelope ienvelope_0, double double_0, double double_1, double double_2, double double_3)
	{
		if (ienvelope_0 != null)
		{
			Coordinate coordinate_ = new Coordinate(double_0, double_1);
			Coordinate coordinate_2 = new Coordinate(double_2, double_3);
			ienvelope_0.Init(coordinate_, coordinate_2);
		}
	}

	public static double Top(this IEnvelope ienvelope_0)
	{
		return ienvelope_0.Y;
	}

	public static void Translate(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		ienvelope_0.Translate(new Coordinate(double_0, double_1));
	}

	public static void Translate(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		if (ienvelope_0 != null && !ienvelope_0.IsNull && coordinate_0 != null)
		{
			Coordinate minimum = ienvelope_0.Minimum;
			Coordinate maximum = ienvelope_0.Maximum;
			int num = Math.Min(ienvelope_0.NumOrdinates, coordinate_0.NumOrdinates);
			for (int i = 0; i < num; i++)
			{
				minimum[i] += coordinate_0[i];
				maximum[i] += coordinate_0[i];
			}
			ienvelope_0.Init(minimum, maximum);
		}
	}

	public static bool Overlaps(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_0.Intersects(ienvelope_1))
		{
			if (ienvelope_0.Contains(ienvelope_1))
			{
				return false;
			}
			if (ienvelope_1.Contains(ienvelope_0))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool Overlaps(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		return ienvelope_0.Intersects(coordinate_0);
	}

	public static bool Overlaps(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		return ienvelope_0.Intersects(new Coordinate(double_0, double_1));
	}

	public static bool Contains(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		if (ienvelope_0 == null)
		{
			return false;
		}
		if (ienvelope_0.IsNull)
		{
			return false;
		}
		int num = Math.Min(ienvelope_0.NumOrdinates, coordinate_0.NumOrdinates);
		for (int i = 0; i < num; i++)
		{
			if (!(coordinate_0[i] >= ienvelope_0.Minimum[i]) || !(coordinate_0[i] <= ienvelope_0.Maximum[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static bool Contains(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		return ienvelope_0.Contains(new Coordinate(double_0, double_1));
	}

	public static bool Contains(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_0 != null && ienvelope_1 != null)
		{
			if (!ienvelope_0.IsNull && !ienvelope_1.IsNull)
			{
				int num = Math.Min(ienvelope_0.NumOrdinates, ienvelope_1.NumOrdinates);
				for (int i = 0; i < num; i++)
				{
					if (!(ienvelope_1.Minimum[i] >= ienvelope_0.Minimum[i]) || !(ienvelope_1.Maximum[i] <= ienvelope_0.Maximum[i]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static double Distance(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_0 == null)
		{
			return -1.0;
		}
		if (ienvelope_1 == null)
		{
			return -1.0;
		}
		return ViewRule(ienvelope_0, ienvelope_1, Math.Min(ienvelope_0.NumOrdinates, ienvelope_1.NumOrdinates));
	}

	public static double smethod_0(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		return ViewRule(ienvelope_0, ienvelope_1, 2);
	}

	public static double smethod_1(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		return ViewRule(ienvelope_0, ienvelope_1, 3);
	}

	private static double ViewRule(IEnvelope ienvelope_0, IEnvelope ienvelope_1, int int_0)
	{
		if (ienvelope_0 != null && ienvelope_1 != null)
		{
			if (!ienvelope_0.IsNull && !ienvelope_1.IsNull)
			{
				if (ienvelope_0.NumOrdinates < int_0 && ienvelope_1.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("both envelopes");
				}
				if (ienvelope_0.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("this envelope");
				}
				if (ienvelope_0.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("the other envelope");
				}
				if (ienvelope_0.Intersects(ienvelope_1))
				{
					return 0.0;
				}
				Coordinate coordinate = new Coordinate();
				for (int i = 0; i < coordinate.NumOrdinates; i++)
				{
					if (ienvelope_0.Maximum[i] < ienvelope_1.Minimum[i])
					{
						coordinate[i] = ienvelope_1.Minimum.X - ienvelope_0.Maximum.X;
					}
					if (ienvelope_0.Minimum[i] > ienvelope_1.Maximum[i])
					{
						coordinate[i] = ienvelope_0.Minimum[i] - ienvelope_1.Minimum[i];
					}
				}
				double num = 0.0;
				for (int j = 0; j < int_0; j++)
				{
					num += coordinate[j] * coordinate[j];
					if (coordinate[j] == 0.0)
					{
						return 0.0;
					}
				}
				return Math.Sqrt(num);
			}
			return -1.0;
		}
		return -1.0;
	}

	public static void ExpandBy(this IEnvelope ienvelope_0, double double_0)
	{
		if (ienvelope_0 != null)
		{
			int numOrdinates = ienvelope_0.NumOrdinates;
			Coordinate minimum = ienvelope_0.Minimum;
			Coordinate maximum = ienvelope_0.Maximum;
			for (int i = 0; i < numOrdinates; i++)
			{
				minimum[i] -= double_0;
				maximum[i] += double_0;
			}
			ienvelope_0.Init(minimum, maximum);
		}
	}

	public static void ExpandBy(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		if (ienvelope_0 != null)
		{
			int num = Math.Min(ienvelope_0.NumOrdinates, coordinate_0.NumOrdinates);
			Coordinate minimum = ienvelope_0.Minimum;
			Coordinate maximum = ienvelope_0.Maximum;
			for (int i = 0; i < num; i++)
			{
				minimum[i] -= coordinate_0[i];
				maximum[i] += coordinate_0[i];
			}
			ienvelope_0.Init(minimum, maximum);
		}
	}

	public static void ExpandBy(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		if (ienvelope_0 != null)
		{
			Coordinate coordinate_ = new Coordinate(double_0, double_1);
			ienvelope_0.ExpandBy(coordinate_);
		}
	}

	public static void ExpandToInclude(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		if (ienvelope_0 == null)
		{
			return;
		}
		if (ienvelope_0.IsNull)
		{
			ienvelope_0.Init(coordinate_0, coordinate_0);
			return;
		}
		int num = Math.Min(ienvelope_0.NumOrdinates, coordinate_0.NumOrdinates);
		Coordinate minimum = ienvelope_0.Minimum;
		Coordinate maximum = ienvelope_0.Maximum;
		for (int i = 0; i < num; i++)
		{
			if (coordinate_0[i] < minimum[i])
			{
				minimum[i] = coordinate_0[i];
			}
			if (coordinate_0[i] > maximum[i])
			{
				maximum[i] = coordinate_0[i];
			}
		}
		ienvelope_0.Init(minimum, maximum);
	}

	public static void ExpandToInclude(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		ienvelope_0.ExpandToInclude(new Coordinate(double_0, double_1));
	}

	public static void ExpandToInclude(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_0 == null || ienvelope_1 == null || ienvelope_1.IsNull)
		{
			return;
		}
		if (ienvelope_0.IsNull)
		{
			ienvelope_0.Init(ienvelope_1.Minimum, ienvelope_1.Maximum);
			return;
		}
		int num = Math.Min(ienvelope_0.NumOrdinates, ienvelope_1.NumOrdinates);
		Coordinate minimum = ienvelope_0.Minimum;
		Coordinate maximum = ienvelope_0.Maximum;
		for (int i = 0; i < num; i++)
		{
			if (ienvelope_1.Minimum[i] < minimum[i])
			{
				minimum[i] = ienvelope_1.Minimum[i];
			}
			if (ienvelope_1.Maximum[i] > maximum[i])
			{
				maximum[i] = ienvelope_1.Maximum[i];
			}
		}
		ienvelope_0.Init(minimum, maximum);
	}

	public static ILineSegment Intersection(this IEnvelope ienvelope_0, ILineSegment ilineSegment_0)
	{
		if (ienvelope_0 != null)
		{
			if (ienvelope_0.IsNull)
			{
				return null;
			}
			if (ilineSegment_0 == null)
			{
				return null;
			}
			if (ienvelope_0.Contains(ilineSegment_0.P0) && ienvelope_0.Contains(ilineSegment_0.P1))
			{
				return ilineSegment_0;
			}
			int num = 0;
			Coordinate[] array = new Coordinate[2];
			ILineSegment[] array2 = ienvelope_0.BorderSegments();
			for (int i = 0; i < 4; i++)
			{
				array[num] = array2[i].Intersection(ilineSegment_0);
				if (array[num] != null)
				{
					num++;
					if (num > 1)
					{
						break;
					}
				}
			}
			switch (num)
			{
			default:
				return null;
			case 2:
			{
				Vector vector_ = new Vector(ilineSegment_0.P0, ilineSegment_0.P1);
				if (new Vector(array[0], array[1]).Dot(vector_) < 0.0)
				{
					return new LineSegment(array[1], array[0]);
				}
				return new LineSegment(array[0], array[1]);
			}
			case 1:
				if (ienvelope_0.Contains(ilineSegment_0.P0))
				{
					return new LineSegment(ilineSegment_0.P0, array[0]);
				}
				if (ienvelope_0.Contains(ilineSegment_0.P1))
				{
					return new LineSegment(array[0], ilineSegment_0.P1);
				}
				return new LineSegment(array[0], array[0]);
			}
		}
		return null;
	}

	public static IEnvelope Intersection(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (!ienvelope_0.IsNull && !ienvelope_1.IsNull && ienvelope_0.Intersects(ienvelope_1))
		{
			IEnvelope envelope;
			IEnvelope envelope2;
			if (ienvelope_1.NumOrdinates <= ienvelope_0.NumOrdinates)
			{
				envelope = ienvelope_0;
				envelope2 = ienvelope_1;
			}
			else
			{
				envelope = ienvelope_1;
				envelope2 = ienvelope_0;
			}
			Coordinate coordinate = envelope.Minimum.Copy();
			Coordinate coordinate2 = envelope.Maximum.Copy();
			for (int i = 0; i < envelope2.NumOrdinates; i++)
			{
				if (envelope2.Minimum[i] > coordinate[i])
				{
					coordinate[i] = envelope2.Minimum[i];
				}
				if (envelope2.Maximum[i] < coordinate2[i])
				{
					coordinate2[i] = envelope2.Maximum[i];
				}
			}
			return new Envelope(coordinate, coordinate2);
		}
		return new Envelope();
	}

	public static IBasicGeometry Intersection(this IEnvelope ienvelope_0, IBasicGeometry ibasicGeometry_0)
	{
		if (ienvelope_0 != null && ibasicGeometry_0 != null)
		{
			if (ienvelope_0.IsNull)
			{
				return null;
			}
			IEnvelope envelope = ibasicGeometry_0.Envelope;
			if (envelope.Intersects(ienvelope_0))
			{
				if (ienvelope_0.Contains(envelope))
				{
					return ibasicGeometry_0;
				}
				return Geometry.FromBasicGeometry(ibasicGeometry_0).Intersection(ienvelope_0.ToPolygon());
			}
			return null;
		}
		return null;
	}

	public static bool Intersects(this IEnvelope ienvelope_0, Coordinate coordinate_0)
	{
		if (ienvelope_0 != null && !(coordinate_0 == null))
		{
			if (ienvelope_0.IsNull)
			{
				return false;
			}
			int num = Math.Min(ienvelope_0.NumOrdinates, coordinate_0.NumOrdinates);
			for (int i = 0; i < num; i++)
			{
				if (!(coordinate_0[i] >= ienvelope_0.Minimum[i]) || !(coordinate_0[i] <= ienvelope_0.Maximum[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static bool Intersects(this IEnvelope ienvelope_0, double double_0, double double_1)
	{
		return ienvelope_0.Intersects(new Coordinate(double_0, double_1));
	}

	public static bool Intersects(this IEnvelope ienvelope_0, ILineSegment ilineSegment_0)
	{
		if (ienvelope_0.Intersection(ilineSegment_0) == null)
		{
			return false;
		}
		return true;
	}

	public static bool Intersects(this IEnvelope ienvelope_0, IEnvelope ienvelope_1)
	{
		if (ienvelope_0 != null && ienvelope_1 != null)
		{
			if (!ienvelope_0.IsNull && !ienvelope_1.IsNull)
			{
				int num = Math.Min(ienvelope_0.NumOrdinates, ienvelope_1.NumOrdinates);
				for (int i = 0; i < num; i++)
				{
					if (!(ienvelope_1.Minimum[i] <= ienvelope_0.Maximum[i]) || !(ienvelope_1.Maximum[i] >= ienvelope_0.Minimum[i]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}
}
