using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class Node : GraphComponent
{
	private Coordinate m_ContextInstance;

	private EdgeEndStar _StatusInstance;

	public override Coordinate Coordinate
	{
		get
		{
			return m_ContextInstance;
		}
		set
		{
			m_ContextInstance = value;
		}
	}

	public virtual EdgeEndStar Edges
	{
		get
		{
			return _StatusInstance;
		}
		protected set
		{
			_StatusInstance = value;
		}
	}

	public override bool IsIsolated => Label.GeometryCount == 1;

	public Node(Coordinate coordinate_0, EdgeEndStar edgeEndStar_0)
	{
		m_ContextInstance = coordinate_0;
		_StatusInstance = edgeEndStar_0;
		base.Label = new Label(0, LocationType.Null);
	}

	public override void ComputeIm(IntersectionMatrix intersectionMatrix_0)
	{
	}

	public virtual void Add(EdgeEnd edgeEnd_0)
	{
		_StatusInstance.Insert(edgeEnd_0);
		edgeEnd_0.Node = this;
	}

	public virtual void MergeLabel(Node node_0)
	{
		MergeLabel(node_0.Label);
	}

	public virtual void MergeLabel(Label label_0)
	{
		for (int i = 0; i < 2; i++)
		{
			LocationType locationType_ = ComputeMergedLocation(label_0, i);
			if (Label.GetLocation(i) == LocationType.Null)
			{
				Label.SetLocation(i, locationType_);
			}
		}
	}

	public virtual void SetLabel(int int_0, LocationType locationType_0)
	{
		if (Label == null)
		{
			Label = new Label(int_0, locationType_0);
		}
		else
		{
			Label.SetLocation(int_0, locationType_0);
		}
	}

	public virtual void SetLabelBoundary(int int_0)
	{
		LocationType locationType = LocationType.Null;
		if (Label != null)
		{
			locationType = Label.GetLocation(int_0);
		}
		Label label = base.Label;
		if (1 == 0)
		{
		}
		LocationType locationType_ = locationType switch
		{
			LocationType.Boundary => LocationType.Interior, 
			LocationType.Interior => LocationType.Boundary, 
			_ => LocationType.Boundary, 
		};
		if (1 == 0)
		{
		}
		label.SetLocation(int_0, locationType_);
	}

	public virtual LocationType ComputeMergedLocation(Label label_0, int int_0)
	{
		LocationType locationType = Label.GetLocation(int_0);
		if (!label_0.IsNull(int_0))
		{
			LocationType location = label_0.GetLocation(int_0);
			if (locationType != LocationType.Boundary)
			{
				locationType = location;
			}
		}
		return locationType;
	}

	public virtual void Write(StreamWriter streamWriter_0)
	{
		streamWriter_0.WriteLine("node " + ((object)m_ContextInstance)?.ToString() + " lbl: " + Label);
	}

	public override string ToString()
	{
		return ((object)m_ContextInstance)?.ToString() + " " + _StatusInstance;
	}
}
