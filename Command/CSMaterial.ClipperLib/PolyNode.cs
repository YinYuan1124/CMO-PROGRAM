using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public class PolyNode
{
	internal PolyNode identifierDispatcher;

	internal List<IntPoint> m_PrinterDispatcher = new List<IntPoint>();

	internal int _ParserDispatcher;

	internal JoinType algoDispatcher;

	internal EndType m_DatabaseDispatcher;

	internal List<PolyNode> interceptorDispatcher = new List<PolyNode>();

	[CompilerGenerated]
	private bool messageDispatcher;

	public int ChildCount => interceptorDispatcher.Count;

	public List<IntPoint> Contour => m_PrinterDispatcher;

	public List<PolyNode> Childs => interceptorDispatcher;

	public PolyNode Parent => identifierDispatcher;

	public bool IsHole => ViewWrapper();

	public bool IsOpen
	{
		[CompilerGenerated]
		get
		{
			return messageDispatcher;
		}
		[CompilerGenerated]
		set
		{
			messageDispatcher = value;
		}
	}

	private bool ViewWrapper()
	{
		bool flag = true;
		for (PolyNode polyNode = identifierDispatcher; polyNode != null; polyNode = polyNode.identifierDispatcher)
		{
			flag = !flag;
		}
		return flag;
	}

	internal void ValidateWrapper(PolyNode polyNode_0)
	{
		int count = interceptorDispatcher.Count;
		interceptorDispatcher.Add(polyNode_0);
		polyNode_0.identifierDispatcher = this;
		polyNode_0._ParserDispatcher = count;
	}

	public PolyNode GetNext()
	{
		if (interceptorDispatcher.Count <= 0)
		{
			return LoginWrapper();
		}
		return interceptorDispatcher[0];
	}

	internal PolyNode LoginWrapper()
	{
		if (identifierDispatcher == null)
		{
			return null;
		}
		if (_ParserDispatcher == identifierDispatcher.interceptorDispatcher.Count - 1)
		{
			return identifierDispatcher.LoginWrapper();
		}
		return identifierDispatcher.interceptorDispatcher[_ParserDispatcher + 1];
	}
}
