using System.Collections.Generic;
using System.IO;
using System.Text;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph.Index;

namespace DotSpatial.Topology.GeometriesGraph;

public class Edge : GraphComponent
{
	private readonly Depth _CollectionInstance = new Depth();

	private readonly EdgeIntersectionList instanceInstance;

	private int m_ObjectInstance;

	private Envelope _ParameterInstance;

	private bool _ExpressionInstance = true;

	private MonotoneChainEdge _DispatcherInstance;

	private string m_ListenerInstance;

	private IList<Coordinate> m_ConfigInstance;

	public virtual IList<Coordinate> Points
	{
		get
		{
			return m_ConfigInstance;
		}
		set
		{
			m_ConfigInstance = value;
		}
	}

	public virtual int NumPoints => m_ConfigInstance.Count;

	public virtual string Name
	{
		get
		{
			return m_ListenerInstance;
		}
		set
		{
			m_ListenerInstance = value;
		}
	}

	public virtual IList<Coordinate> Coordinates => m_ConfigInstance;

	public override Coordinate Coordinate
	{
		get
		{
			if (Points.Count <= 0)
			{
				return Coordinate.Empty;
			}
			return Points[0];
		}
		set
		{
			if (Points.Count > 0)
			{
				Points[0] = value;
			}
		}
	}

	public virtual Envelope Envelope
	{
		get
		{
			if (_ParameterInstance == null)
			{
				_ParameterInstance = new Envelope();
				for (int i = 0; i < Points.Count; i++)
				{
					_ParameterInstance.ExpandToInclude(Points[i]);
				}
			}
			return _ParameterInstance;
		}
	}

	public virtual Depth Depth => _CollectionInstance;

	public virtual int DepthDelta
	{
		get
		{
			return m_ObjectInstance;
		}
		set
		{
			m_ObjectInstance = value;
		}
	}

	public virtual int MaximumSegmentIndex => Points.Count - 1;

	public virtual EdgeIntersectionList EdgeIntersectionList => instanceInstance;

	public virtual MonotoneChainEdge MonotoneChainEdge
	{
		get
		{
			if (_DispatcherInstance == null)
			{
				_DispatcherInstance = new MonotoneChainEdge(this);
			}
			return _DispatcherInstance;
		}
	}

	public virtual bool IsClosed => Points[0].Equals(Points[Points.Count - 1]);

	public virtual bool IsCollapsed
	{
		get
		{
			if (Label.IsArea())
			{
				if (Points.Count == 3)
				{
					if (Points[0].Equals(Points[2]))
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public virtual Edge CollapsedEdge => new Edge(new Coordinate[2]
	{
		Points[0],
		Points[1]
	}, Label.ToLineLabel(Label));

	public virtual bool Isolated
	{
		get
		{
			return _ExpressionInstance;
		}
		set
		{
			_ExpressionInstance = value;
		}
	}

	public override bool IsIsolated => _ExpressionInstance;

	public Edge(IList<Coordinate> ilist_0, Label label_0)
	{
		instanceInstance = new EdgeIntersectionList(this);
		m_ConfigInstance = ilist_0;
		base.Label = label_0;
	}

	public Edge(IList<Coordinate> ilist_0)
		: this(ilist_0, null)
	{
	}

	public static void UpdateIm(Label label_0, IntersectionMatrix intersectionMatrix_0)
	{
		intersectionMatrix_0.SetAtLeastIfValid(label_0.GetLocation(0, PositionType.On), label_0.GetLocation(1, PositionType.On), DimensionType.Curve);
		if (label_0.IsArea())
		{
			intersectionMatrix_0.SetAtLeastIfValid(label_0.GetLocation(0, PositionType.Left), label_0.GetLocation(1, PositionType.Left), DimensionType.Surface);
			intersectionMatrix_0.SetAtLeastIfValid(label_0.GetLocation(0, PositionType.Right), label_0.GetLocation(1, PositionType.Right), DimensionType.Surface);
		}
	}

	public virtual Coordinate GetCoordinate(int int_0)
	{
		return Points[int_0];
	}

	public virtual void AddIntersections(LineIntersector lineIntersector_0, int int_0, int int_1)
	{
		for (int i = 0; i < lineIntersector_0.IntersectionNum; i++)
		{
			AddIntersection(lineIntersector_0, int_0, int_1, i);
		}
	}

	public virtual void AddIntersection(LineIntersector lineIntersector_0, int int_0, int int_1, int int_2)
	{
		Coordinate coordinate = new Coordinate(lineIntersector_0.GetIntersection(int_2));
		int num = int_0;
		double double_ = lineIntersector_0.GetEdgeDistance(int_1, int_2);
		int num2 = num + 1;
		if (num2 < Points.Count)
		{
			Coordinate coordinate_ = Points[num2];
			if (coordinate.Equals2D(coordinate_))
			{
				num = num2;
				double_ = 0.0;
			}
			EdgeIntersectionList.Add(coordinate, num, double_);
		}
	}

	public override void ComputeIm(IntersectionMatrix intersectionMatrix_0)
	{
		UpdateIm(Label, intersectionMatrix_0);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Edge)
		{
			return Equals(obj as Edge);
		}
		return false;
	}

	protected virtual bool Equals(Edge edge_0)
	{
		if (Points.Count == edge_0.Points.Count)
		{
			bool flag = true;
			bool flag2 = true;
			int num = Points.Count;
			int num2 = 0;
			while (true)
			{
				if (num2 < Points.Count)
				{
					if (!Points[num2].Equals2D(edge_0.Points[num2]))
					{
						flag = false;
					}
					if (!Points[num2].Equals2D(edge_0.Points[--num]))
					{
						flag2 = false;
					}
					if (!flag && !flag2)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(Edge edge_0, Edge edge_1)
	{
		return object.Equals(edge_0, edge_1);
	}

	public static bool operator !=(Edge edge_0, Edge edge_1)
	{
		return !(edge_0 == edge_1);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual bool IsPointwiseEqual(Edge edge_0)
	{
		if (Points.Count == edge_0.Points.Count)
		{
			int num = 0;
			while (true)
			{
				if (num < Points.Count)
				{
					if (!Points[num].Equals2D(edge_0.Points[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write("edge " + m_ListenerInstance + ": ");
		streamWriter_0.Write("LINESTRING (");
		for (int i = 0; i < Points.Count; i++)
		{
			if (i > 0)
			{
				streamWriter_0.Write(",");
			}
			streamWriter_0.Write(Points[i].X + " " + Points[i].Y);
		}
		streamWriter_0.Write(")  " + Label?.ToString() + " " + m_ObjectInstance);
	}

	public virtual void WriteReverse(StreamWriter streamWriter_0)
	{
		streamWriter_0.Write("edge " + m_ListenerInstance + ": ");
		for (int num = Points.Count - 1; num >= 0; num--)
		{
			streamWriter_0.Write(((object)Points[num])?.ToString() + " ");
		}
		streamWriter_0.WriteLine(string.Empty);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("edge " + m_ListenerInstance + ": ");
		stringBuilder.Append("LINESTRING (");
		for (int i = 0; i < Points.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(Points[i].X + " " + Points[i].Y);
		}
		stringBuilder.Append(")  " + Label?.ToString() + " " + m_ObjectInstance);
		return stringBuilder.ToString();
	}
}
