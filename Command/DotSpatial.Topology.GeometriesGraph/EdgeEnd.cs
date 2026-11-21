using System;
using System.IO;
using System.Text;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public class EdgeEnd : IComparable
{
	private double registryInstance;

	private double definitionInstance;

	private Edge _ValInstance;

	private Label wrapperInstance;

	private Node _ObserverInstance;

	private Coordinate m_IssuerInstance;

	private Coordinate clientInstance;

	private int m_DicInstance;

	public virtual Edge Edge
	{
		get
		{
			return _ValInstance;
		}
		protected set
		{
			_ValInstance = value;
		}
	}

	public virtual Label Label
	{
		get
		{
			return wrapperInstance;
		}
		protected set
		{
			wrapperInstance = value;
		}
	}

	public virtual Coordinate Coordinate => m_IssuerInstance;

	public virtual Coordinate DirectedCoordinate => clientInstance;

	public virtual int Quadrant => m_DicInstance;

	public virtual double Dx => registryInstance;

	public virtual double Dy => definitionInstance;

	public virtual Node Node
	{
		get
		{
			return _ObserverInstance;
		}
		set
		{
			_ObserverInstance = value;
		}
	}

	protected EdgeEnd(Edge edge_0)
	{
		_ValInstance = edge_0;
	}

	public EdgeEnd(Edge edge_0, Coordinate coordinate_0, Coordinate coordinate_1)
		: this(edge_0, coordinate_0, coordinate_1, null)
	{
	}

	public EdgeEnd(Edge edge_0, Coordinate coordinate_0, Coordinate coordinate_1, Label label_0)
		: this(edge_0)
	{
		RestartParameter(coordinate_0, coordinate_1);
		wrapperInstance = label_0;
	}

	public virtual int CompareTo(object target)
	{
		EdgeEnd edgeEnd_ = (EdgeEnd)target;
		return CompareDirection(edgeEnd_);
	}

	private void RestartParameter(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		m_IssuerInstance = coordinate_0;
		clientInstance = coordinate_1;
		registryInstance = coordinate_1.X - coordinate_0.X;
		definitionInstance = coordinate_1.Y - coordinate_0.Y;
		m_DicInstance = QuadrantOp.Quadrant(registryInstance, definitionInstance);
		Assert.IsTrue(registryInstance != 0.0 || definitionInstance != 0.0, "EdgeEnd with identical endpoints found");
	}

	protected virtual void Init(Coordinate coordinate_0, Coordinate coordinate_1)
	{
		RestartParameter(coordinate_0, coordinate_1);
	}

	public virtual int CompareDirection(EdgeEnd edgeEnd_0)
	{
		if (registryInstance == edgeEnd_0.registryInstance && definitionInstance == edgeEnd_0.definitionInstance)
		{
			return 0;
		}
		if (m_DicInstance <= edgeEnd_0.m_DicInstance)
		{
			if (m_DicInstance < edgeEnd_0.m_DicInstance)
			{
				return -1;
			}
			return CgAlgorithms.ComputeOrientation(edgeEnd_0.m_IssuerInstance, edgeEnd_0.clientInstance, clientInstance);
		}
		return 1;
	}

	public virtual void ComputeLabel()
	{
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		double num = Math.Atan2(definitionInstance, registryInstance);
		string fullName = GetType().FullName;
		int num2 = fullName.LastIndexOf('.');
		string text = fullName.Substring(num2 + 1);
		streamWriter_0.Write("  " + text + ": " + ((object)m_IssuerInstance)?.ToString() + " - " + ((object)clientInstance)?.ToString() + " " + m_DicInstance + ":" + num + "   " + Label);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		stringBuilder.Append(m_IssuerInstance.X);
		stringBuilder.Append(' ');
		stringBuilder.Append(clientInstance.Y);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}
}
