using System;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Noding.Snapround;

public class HotPixel
{
	private readonly Coordinate[] m_FacadeCollection = new Coordinate[4];

	private readonly LineIntersector m_ProxyCollection;

	private readonly Coordinate _ReaderCollection;

	private readonly Coordinate propertyCollection;

	private readonly Coordinate m_ImporterCollection;

	private readonly Coordinate m_RepositoryCollection;

	private readonly double _BridgeCollection;

	private double invocationCollection;

	private double classCollection;

	private double m_RequestCollection;

	private double _ValueCollection;

	private Envelope _TokenizerCollection;

	public Coordinate Coordinate => _ReaderCollection;

	public HotPixel(Coordinate coordinate_0, double double_0, LineIntersector lineIntersector_0)
	{
		_ReaderCollection = coordinate_0;
		m_RepositoryCollection = coordinate_0;
		_BridgeCollection = double_0;
		m_ProxyCollection = lineIntersector_0;
		if (double_0 != 1.0)
		{
			m_RepositoryCollection = new Coordinate(ManageObject(coordinate_0.X), ManageObject(coordinate_0.Y));
			propertyCollection = new Coordinate();
			m_ImporterCollection = new Coordinate();
		}
		RegisterObject(m_RepositoryCollection);
	}

	public Envelope GetSafeEnvelope()
	{
		if (_TokenizerCollection == null)
		{
			double num = 0.75 / _BridgeCollection;
			_TokenizerCollection = new Envelope(_ReaderCollection.X - num, _ReaderCollection.X + num, _ReaderCollection.Y - num, _ReaderCollection.Y + num);
		}
		return _TokenizerCollection;
	}

	private void RegisterObject(Coordinate coordinate_0)
	{
		m_RequestCollection = coordinate_0.X - 0.5;
		invocationCollection = coordinate_0.X + 0.5;
		_ValueCollection = coordinate_0.Y - 0.5;
		classCollection = coordinate_0.Y + 0.5;
		m_FacadeCollection[0] = new Coordinate(invocationCollection, classCollection);
		m_FacadeCollection[1] = new Coordinate(m_RequestCollection, classCollection);
		m_FacadeCollection[2] = new Coordinate(m_RequestCollection, _ValueCollection);
		m_FacadeCollection[3] = new Coordinate(invocationCollection, _ValueCollection);
	}

	private double ManageObject(double double_0)
	{
		return Math.Round(double_0 * _BridgeCollection);
	}

	public bool Intersects(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		if (_BridgeCollection == 1.0)
		{
			return IntersectsScaled(coordinate_0, coordinate_1);
		}
		RevertObject(coordinate_0, propertyCollection);
		RevertObject(coordinate_1, m_ImporterCollection);
		return IntersectsScaled(propertyCollection, m_ImporterCollection);
	}

	private void RevertObject(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		coordinate_1.X = ManageObject(coordinate_0.X);
		coordinate_1.Y = ManageObject(coordinate_0.Y);
	}

	public bool IntersectsScaled(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		double num = Math.Min(coordinate_0.X, coordinate_1.X);
		double num2 = Math.Max(coordinate_0.X, coordinate_1.X);
		double num3 = Math.Min(coordinate_0.Y, coordinate_1.Y);
		double num4 = Math.Max(coordinate_0.Y, coordinate_1.Y);
		if (invocationCollection >= num && m_RequestCollection <= num2 && classCollection >= num3 && _ValueCollection <= num4)
		{
			bool num5 = CountParameter(coordinate_0, coordinate_1);
			Assert.IsTrue(!num5, "Found bad envelope test");
			return num5;
		}
		return false;
	}

	private bool CountParameter(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		bool flag = false;
		bool flag2 = false;
		m_ProxyCollection.ComputeIntersection(coordinate_0, coordinate_1, m_FacadeCollection[0], m_FacadeCollection[1]);
		if (m_ProxyCollection.IsProper)
		{
			return true;
		}
		m_ProxyCollection.ComputeIntersection(coordinate_0, coordinate_1, m_FacadeCollection[1], m_FacadeCollection[2]);
		if (m_ProxyCollection.IsProper)
		{
			return true;
		}
		if (m_ProxyCollection.HasIntersection)
		{
			flag = true;
		}
		m_ProxyCollection.ComputeIntersection(coordinate_0, coordinate_1, m_FacadeCollection[2], m_FacadeCollection[3]);
		if (m_ProxyCollection.IsProper)
		{
			return true;
		}
		if (m_ProxyCollection.HasIntersection)
		{
			flag2 = true;
		}
		m_ProxyCollection.ComputeIntersection(coordinate_0, coordinate_1, m_FacadeCollection[3], m_FacadeCollection[0]);
		if (m_ProxyCollection.IsProper)
		{
			return true;
		}
		if (flag && flag2)
		{
			return true;
		}
		if (coordinate_0.Equals(m_RepositoryCollection))
		{
			return true;
		}
		if (coordinate_1.Equals(m_RepositoryCollection))
		{
			return true;
		}
		return false;
	}
}
