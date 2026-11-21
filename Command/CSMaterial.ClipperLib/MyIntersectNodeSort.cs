using System.Collections.Generic;

namespace CSMaterial.ClipperLib;

public sealed class MyIntersectNodeSort : IComparer<IntersectNode>
{
	public int Compare(IntersectNode x, IntersectNode y)
	{
		return (int)(y.m_CreatorDispatcher.Y - x.m_CreatorDispatcher.Y);
	}
}
