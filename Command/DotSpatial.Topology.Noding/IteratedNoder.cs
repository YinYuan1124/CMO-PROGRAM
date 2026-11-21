using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IteratedNoder : INoder
{
	public const int MAX_ITERATIONS = 5;

	private readonly LineIntersector accountRule;

	private int m_StateRule = 5;

	private IList m_AuthenticationRule;

	public int MaximumIterations
	{
		get
		{
			return m_StateRule;
		}
		set
		{
			m_StateRule = value;
		}
	}

	public IteratedNoder(PrecisionModel precisionModel_0)
	{
		accountRule = new RobustLineIntersector();
		accountRule.PrecisionModel = precisionModel_0;
	}

	public IList GetNodedSubstrings()
	{
		return m_AuthenticationRule;
	}

	public void ComputeNodes(IList ilist_0)
	{
		int[] array = new int[1];
		m_AuthenticationRule = ilist_0;
		int num = 0;
		int num2 = -1;
		while (true)
		{
			PopObject(m_AuthenticationRule, array);
			num++;
			int num3 = array[0];
			if (num2 > 0 && num3 >= num2 && num > m_StateRule)
			{
				break;
			}
			num2 = num3;
			if (num2 <= 0)
			{
				return;
			}
		}
		throw new TopologyException("Iterated noding failed to converge after " + num + " iterations");
	}

	private void PopObject(IList ilist_0, int[] int_0)
	{
		IntersectionAdder intersectionAdder = new IntersectionAdder(accountRule);
		McIndexNoder mcIndexNoder = new McIndexNoder(intersectionAdder);
		mcIndexNoder.ComputeNodes(ilist_0);
		m_AuthenticationRule = mcIndexNoder.GetNodedSubstrings();
		int_0[0] = intersectionAdder.NumInteriorIntersections;
	}
}
