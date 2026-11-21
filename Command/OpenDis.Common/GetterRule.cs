using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DotSpatial.Topology.Noding;

namespace OpenDis.Common;

internal class GetterRule : IEnumerator
{
	private readonly SegmentString producerRule;

	private readonly IEnumerator _ProcRule;

	private readonly SegmentNodeList m_StructCollection;

	private SegmentNode m_MerchantCollection;

	private int _CallbackCollection;

	private SegmentNode decoratorCollection;

	public object Current => m_MerchantCollection;

	[SpecialName]
	public int CompareObject()
	{
		return _CallbackCollection;
	}

	[SpecialName]
	public SegmentString DisableObject()
	{
		return producerRule;
	}

	[SpecialName]
	public SegmentNodeList InsertObject()
	{
		return m_StructCollection;
	}

	private GetterRule(SegmentNodeList segmentNodeList_0)
	{
		m_StructCollection = segmentNodeList_0;
		producerRule = segmentNodeList_0.Edge;
		_ProcRule = segmentNodeList_0.GetEnumerator();
	}

	public bool MoveNext()
	{
		if (m_MerchantCollection == null)
		{
			m_MerchantCollection = decoratorCollection;
			_CallbackCollection = m_MerchantCollection.SegmentIndex;
			CreateObject();
			return true;
		}
		if (decoratorCollection == null)
		{
			return false;
		}
		if (decoratorCollection.SegmentIndex == m_MerchantCollection.SegmentIndex)
		{
			m_MerchantCollection = decoratorCollection;
			_CallbackCollection = m_MerchantCollection.SegmentIndex;
			CreateObject();
			return true;
		}
		return false;
	}

	public void Reset()
	{
		_ProcRule.Reset();
	}

	private void CreateObject()
	{
		if (_ProcRule.MoveNext())
		{
			decoratorCollection = (SegmentNode)_ProcRule.Current;
		}
		else
		{
			decoratorCollection = null;
		}
	}

	[Obsolete("Not implemented!")]
	public void Remove()
	{
		throw new NotSupportedException(GetType().Name);
	}
}
