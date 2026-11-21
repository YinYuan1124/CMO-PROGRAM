using System;

namespace DotSpatial.Topology.Precision;

public class EnhancedPrecisionOp
{
	private EnhancedPrecisionOp()
	{
	}

	public static IGeometry Intersection(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		ApplicationException ex2;
		try
		{
			return igeometry_0.Intersection(igeometry_1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(bool_0: true).Intersection(igeometry_0, igeometry_1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry Union(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		ApplicationException ex2;
		try
		{
			return igeometry_0.Union(igeometry_1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(bool_0: true).Union(igeometry_0, igeometry_1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry Difference(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		ApplicationException ex2;
		try
		{
			return igeometry_0.Difference(igeometry_1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(bool_0: true).Difference(igeometry_0, igeometry_1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry SymDifference(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		ApplicationException ex2;
		try
		{
			return igeometry_0.SymmetricDifference(igeometry_1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(bool_0: true).SymDifference(igeometry_0, igeometry_1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	[Obsolete("This method should no longer be necessary, since the buffer algorithm now is highly robust.")]
	public static IGeometry Buffer(Geometry geometry_0, double double_0)
	{
		ApplicationException ex2;
		try
		{
			return (Geometry)geometry_0.Buffer(double_0);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(bool_0: true).Buffer(geometry_0, double_0);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}
}
