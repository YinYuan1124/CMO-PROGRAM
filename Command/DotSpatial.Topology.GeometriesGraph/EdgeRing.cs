using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class EdgeRing
{
	private readonly IList m_ValueInstance = new ArrayList();

	private readonly ArrayList m_TokenizerInstance = new ArrayList();

	private readonly IGeometryFactory _StubInstance;

	private readonly Label _WriterInstance = new Label(LocationType.Null);

	private readonly IList specificationInstance = new ArrayList();

	private bool watcherInstance;

	private int _ReponseInstance = -1;

	private ILinearRing m_DescriptorInstance;

	private EdgeRing poolInstance;

	private DirectedEdge _TaskInstance;

	protected IGeometryFactory InnerGeometryFactory => _StubInstance;

	public virtual bool IsIsolated => _WriterInstance.GeometryCount == 1;

	public virtual bool IsHole => watcherInstance;

	public virtual ILinearRing LinearRing => m_DescriptorInstance;

	public virtual Label Label => _WriterInstance;

	public virtual bool IsShell => poolInstance == null;

	public virtual EdgeRing Shell
	{
		get
		{
			return poolInstance;
		}
		set
		{
			poolInstance = value;
			if (value != null)
			{
				poolInstance.AddHole(this);
			}
		}
	}

	public virtual IList Edges => m_ValueInstance;

	protected DirectedEdge StartDe
	{
		get
		{
			return _TaskInstance;
		}
		set
		{
			_TaskInstance = value;
		}
	}

	public virtual int MaxNodeDegree
	{
		get
		{
			if (_ReponseInstance < 0)
			{
				VerifyParameter();
			}
			return _ReponseInstance;
		}
	}

	protected EdgeRing(DirectedEdge directedEdge_0, IGeometryFactory igeometryFactory_0)
	{
		_StubInstance = igeometryFactory_0;
		ComputePoints(directedEdge_0);
		ComputeRing();
	}

	public virtual Coordinate GetCoordinate(int int_0)
	{
		return (Coordinate)specificationInstance[int_0];
	}

	public virtual void AddHole(EdgeRing edgeRing_0)
	{
		m_TokenizerInstance.Add(edgeRing_0);
	}

	public virtual IPolygon ToPolygon(IGeometryFactory igeometryFactory_0)
	{
		ILinearRing[] array3 = new LinearRing[m_TokenizerInstance.Count];
		ILinearRing[] array = array3;
		ILinearRing[] array2 = array;
		for (int i = 0; i < m_TokenizerInstance.Count; i++)
		{
			array2[i] = ((EdgeRing)m_TokenizerInstance[i]).LinearRing;
		}
		return igeometryFactory_0.CreatePolygon(LinearRing, array2);
	}

	public void ComputeRing()
	{
		if (m_DescriptorInstance == null)
		{
			Coordinate[] array = new Coordinate[specificationInstance.Count];
			for (int i = 0; i < specificationInstance.Count; i++)
			{
				array[i] = (Coordinate)specificationInstance[i];
			}
			m_DescriptorInstance = InnerGeometryFactory.CreateLinearRing(array);
			watcherInstance = CgAlgorithms.IsCounterClockwise(m_DescriptorInstance.Coordinates);
		}
	}

	public abstract DirectedEdge GetNext(DirectedEdge directedEdge_0);

	public abstract void SetEdgeRing(DirectedEdge directedEdge_0, EdgeRing edgeRing_0);

	protected void ComputePoints(DirectedEdge directedEdge_0)
	{
		StartDe = directedEdge_0;
		DirectedEdge directedEdge = directedEdge_0;
		bool bool_ = true;
		while (true)
		{
			Assert.IsTrue(directedEdge != null, "found null Directed Edge");
			if (directedEdge != null)
			{
				if (directedEdge.EdgeRing == this)
				{
					break;
				}
				m_ValueInstance.Add(directedEdge);
				Label label = directedEdge.Label;
				Assert.IsTrue(label.IsArea());
				MergeLabel(label);
				AddPoints(directedEdge.Edge, directedEdge.IsForward, bool_);
				bool_ = false;
				SetEdgeRing(directedEdge, this);
				directedEdge = GetNext(directedEdge);
			}
			if (directedEdge == StartDe)
			{
				return;
			}
		}
		throw new TopologyException("Directed Edge visited twice during ring-building at " + (object)directedEdge.Coordinate);
	}

	private void VerifyParameter()
	{
		_ReponseInstance = 0;
		DirectedEdge directedEdge = StartDe;
		do
		{
			int outgoingDegree = ((DirectedEdgeStar)directedEdge.Node.Edges).GetOutgoingDegree(this);
			if (outgoingDegree > _ReponseInstance)
			{
				_ReponseInstance = outgoingDegree;
			}
			directedEdge = GetNext(directedEdge);
		}
		while (directedEdge != StartDe);
		_ReponseInstance *= 2;
	}

	public virtual void SetInResult()
	{
		DirectedEdge directedEdge = StartDe;
		do
		{
			directedEdge.Edge.IsInResult = true;
			directedEdge = directedEdge.Next;
		}
		while (directedEdge != StartDe);
	}

	protected virtual void MergeLabel(Label label_0)
	{
		MergeLabel(label_0, 0);
		MergeLabel(label_0, 1);
	}

	protected virtual void MergeLabel(Label label_0, int int_0)
	{
		LocationType location = label_0.GetLocation(int_0, PositionType.Right);
		if (location != LocationType.Null && _WriterInstance.GetLocation(int_0) == LocationType.Null)
		{
			_WriterInstance.SetLocation(int_0, location);
		}
	}

	protected virtual void AddPoints(Edge edge_0, bool bool_0, bool bool_1)
	{
		IList<Coordinate> coordinates = edge_0.Coordinates;
		if (bool_0)
		{
			int num = 1;
			if (bool_1)
			{
				num = 0;
			}
			for (int i = num; i < coordinates.Count; i++)
			{
				specificationInstance.Add(coordinates[i]);
			}
			return;
		}
		int num2 = coordinates.Count - 2;
		if (bool_1)
		{
			num2 = coordinates.Count - 1;
		}
		for (int num3 = num2; num3 >= 0; num3--)
		{
			specificationInstance.Add(coordinates[num3]);
		}
	}

	public virtual bool ContainsPoint(Coordinate coordinate_0)
	{
		ILinearRing linearRing = LinearRing;
		if (linearRing.EnvelopeInternal.Contains(coordinate_0))
		{
			if (CgAlgorithms.IsPointInRing(coordinate_0, linearRing.Coordinates))
			{
				IEnumerator enumerator = m_TokenizerInstance.GetEnumerator();
				do
				{
					if (!enumerator.MoveNext())
					{
						return true;
					}
				}
				while (!((EdgeRing)enumerator.Current).ContainsPoint(coordinate_0));
				return false;
			}
			return false;
		}
		return false;
	}
}
