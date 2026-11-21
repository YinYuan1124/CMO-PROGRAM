using System.Collections;

namespace DotSpatial.Topology.Operation.Polygonize;

public class Polygonizer
{
	private readonly PolygonizeGraph m_ClientRule = new PolygonizeGraph(new GeometryFactory());

	private readonly LineStringAdder dicRule;

	private IList _ConsumerRule = new ArrayList();

	private IList facadeRule = new ArrayList();

	private IList m_ProxyRule;

	private IList readerRule = new ArrayList();

	private IList propertyRule;

	private IList _ImporterRule;

	public virtual IList Polygons
	{
		get
		{
			ComputeInstance();
			return propertyRule;
		}
	}

	public virtual IList Dangles
	{
		get
		{
			ComputeInstance();
			return facadeRule;
		}
		protected set
		{
			facadeRule = value;
		}
	}

	public virtual IList CutEdges
	{
		get
		{
			ComputeInstance();
			return _ConsumerRule;
		}
		protected set
		{
			_ConsumerRule = value;
		}
	}

	public virtual IList InvalidRingLines
	{
		get
		{
			ComputeInstance();
			return readerRule;
		}
		protected set
		{
			readerRule = value;
		}
	}

	public Polygonizer()
	{
		dicRule = new LineStringAdder(this);
	}

	public virtual void Add(IList ilist_0)
	{
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Geometry igeometry_ = (Geometry)enumerator.Current;
			Add(igeometry_);
		}
	}

	public virtual void Add(IGeometry igeometry_0)
	{
		igeometry_0.Apply(dicRule);
	}

	private void ComputeInstance()
	{
		if (propertyRule != null)
		{
			return;
		}
		propertyRule = new ArrayList();
		if (m_ClientRule != null)
		{
			facadeRule = m_ClientRule.DeleteDangles();
			_ConsumerRule = m_ClientRule.DeleteCutEdges();
			IList edgeRings = m_ClientRule.GetEdgeRings();
			IList list = new ArrayList();
			readerRule = new ArrayList();
			PatchInstance(edgeRings, list, readerRule);
			SelectInstance(list);
			CallInstance(m_ProxyRule, _ImporterRule);
			propertyRule = new ArrayList();
			IEnumerator enumerator = _ImporterRule.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeRing edgeRing = (EdgeRing)enumerator.Current;
				propertyRule.Add(edgeRing.Polygon);
			}
		}
	}

	private static void PatchInstance(IEnumerable ienumerable_0, IList ilist_0, IList ilist_1)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (edgeRing.IsValid)
			{
				ilist_0.Add(edgeRing);
			}
			else
			{
				ilist_1.Add(edgeRing.LineString);
			}
		}
	}

	private void SelectInstance(IEnumerable ienumerable_0)
	{
		m_ProxyRule = new ArrayList();
		_ImporterRule = new ArrayList();
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeRing edgeRing = (EdgeRing)enumerator.Current;
			if (edgeRing.IsHole)
			{
				m_ProxyRule.Add(edgeRing);
			}
			else
			{
				_ImporterRule.Add(edgeRing);
			}
		}
	}

	private static void CallInstance(IEnumerable ienumerable_0, IList ilist_0)
	{
		IEnumerator enumerator = ienumerable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			LogoutInstance((EdgeRing)enumerator.Current, ilist_0);
		}
	}

	private static void LogoutInstance(EdgeRing edgeRing_0, IList ilist_0)
	{
		EdgeRing.FindEdgeRingContaining(edgeRing_0, ilist_0)?.AddHole(edgeRing_0.Ring);
	}
}
