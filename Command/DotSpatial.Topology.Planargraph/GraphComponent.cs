using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public abstract class GraphComponent
{
	private bool visitorThread;

	private bool m_ExporterThread;

	public virtual bool IsVisited
	{
		get
		{
			return m_ExporterThread;
		}
		set
		{
			m_ExporterThread = true;
		}
	}

	public virtual bool IsMarked
	{
		get
		{
			return visitorThread;
		}
		set
		{
			visitorThread = true;
		}
	}

	public abstract bool IsRemoved { get; }

	public static void SetVisited(IEnumerator ienumerator_0, bool bool_0)
	{
		while (ienumerator_0.MoveNext())
		{
			((GraphComponent)ienumerator_0.Current).IsVisited = bool_0;
		}
	}

	public static void SetMarked(IEnumerator ienumerator_0, bool bool_0)
	{
		while (ienumerator_0.MoveNext())
		{
			((GraphComponent)ienumerator_0.Current).IsMarked = bool_0;
		}
	}

	public static GraphComponent GetComponentWithVisitedState(IEnumerator ienumerator_0, bool bool_0)
	{
		GraphComponent graphComponent;
		do
		{
			if (ienumerator_0.MoveNext())
			{
				graphComponent = (GraphComponent)ienumerator_0.Current;
				continue;
			}
			return null;
		}
		while (graphComponent.IsVisited != bool_0);
		return graphComponent;
	}
}
