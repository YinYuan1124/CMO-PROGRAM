using System;
using System.Collections;
using System.IO;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Planargraph;

public class DirectedEdge : GraphComponent, IComparable
{
	private readonly double _IndexerThread;

	private readonly bool resolverThread;

	private readonly Node _PublisherThread;

	private readonly Coordinate m_ServerThread;

	private readonly Coordinate m_AdapterThread;

	private readonly int m_SchemaThread;

	private readonly Node utilsThread;

	private Edge m_PredicateThread;

	private DirectedEdge _SingletonThread;

	public virtual Edge Edge
	{
		get
		{
			return m_PredicateThread;
		}
		set
		{
			m_PredicateThread = value;
		}
	}

	public virtual int Quadrant => m_SchemaThread;

	public virtual Coordinate StartPoint => m_ServerThread;

	public virtual Coordinate EndPoint => m_AdapterThread;

	public virtual bool EdgeDirection => resolverThread;

	public virtual Node FromNode => _PublisherThread;

	public virtual Node ToNode => utilsThread;

	public virtual Coordinate Coordinate => _PublisherThread.Coordinate;

	public virtual double Angle => _IndexerThread;

	public virtual DirectedEdge Sym
	{
		get
		{
			return _SingletonThread;
		}
		set
		{
			_SingletonThread = value;
		}
	}

	public override bool IsRemoved => m_PredicateThread == null;

	public DirectedEdge(Node node_0, Node node_1, Coordinate coordinate_0, bool bool_0)
	{
		_PublisherThread = node_0;
		utilsThread = node_1;
		resolverThread = bool_0;
		m_ServerThread = _PublisherThread.Coordinate;
		m_AdapterThread = coordinate_0;
		double num = m_AdapterThread.X - m_ServerThread.X;
		double num2 = m_AdapterThread.Y - m_ServerThread.Y;
		m_SchemaThread = QuadrantOp.Quadrant(num, num2);
		_IndexerThread = Math.Atan2(num2, num);
	}

	public virtual int CompareTo(object target)
	{
		DirectedEdge directedEdge_ = (DirectedEdge)target;
		return CompareDirection(directedEdge_);
	}

	public static IList ToEdges(IList ilist_0)
	{
		IList list = new ArrayList();
		IEnumerator enumerator = ilist_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			list.Add(((DirectedEdge)enumerator.Current).Edge);
		}
		return list;
	}

	public virtual int CompareDirection(DirectedEdge directedEdge_0)
	{
		if (m_SchemaThread <= directedEdge_0.Quadrant)
		{
			if (m_SchemaThread < directedEdge_0.Quadrant)
			{
				return -1;
			}
			return CgAlgorithms.ComputeOrientation(directedEdge_0.StartPoint, directedEdge_0.EndPoint, m_AdapterThread);
		}
		return 1;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		string fullName = GetType().FullName;
		int num = fullName.LastIndexOf('.');
		string text = fullName.Substring(num + 1);
		streamWriter_0.Write("  " + text + ": " + ((object)m_ServerThread)?.ToString() + " - " + ((object)m_AdapterThread)?.ToString() + " " + m_SchemaThread + ":" + _IndexerThread);
	}

	internal void Remove()
	{
		_SingletonThread = null;
		m_PredicateThread = null;
	}

	public override string ToString()
	{
		return "DirectedEdge: " + ((object)m_ServerThread)?.ToString() + " - " + ((object)m_AdapterThread)?.ToString() + " " + m_SchemaThread + ":" + _IndexerThread;
	}
}
