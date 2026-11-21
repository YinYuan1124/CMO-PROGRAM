using System.Collections.Generic;

namespace CSMaterial.ClipperLib;

public sealed class PolyTree : PolyNode
{
	internal List<PolyNode> _ProductDispatcher = new List<PolyNode>();

	public int Total => _ProductDispatcher.Count;

	~PolyTree()
	{
		Clear();
	}

	public void Clear()
	{
		for (int i = 0; i < _ProductDispatcher.Count; i++)
		{
			_ProductDispatcher[i] = null;
		}
		_ProductDispatcher.Clear();
		interceptorDispatcher.Clear();
	}

	public PolyNode GetFirst()
	{
		if (interceptorDispatcher.Count <= 0)
		{
			return null;
		}
		return interceptorDispatcher[0];
	}
}
