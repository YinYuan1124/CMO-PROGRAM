using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Command.Bridges;
using Command.Filter;
using Command.Lists;
using Command.Managers;
using Command.Objects;
using OpenDis.Candidates;

namespace CSMaterial.ClipperLib;

public sealed class Clipper : ClipperBase
{
	internal enum NodeType
	{
		ntAny,
		ntOpen,
		ntClosed
	}

	public const int ioReverseSolution = 1;

	public const int ioStrictlySimple = 2;

	public const int ioPreserveCollinear = 4;

	private List<RulesConfigObject> _ReponseDispatcher;

	private ClipType _DescriptorDispatcher;

	private AnnotationDispatcher m_PoolDispatcher;

	private RefDispatcherList _TaskDispatcher;

	private RefDispatcherList _FilterDispatcher;

	private List<IntersectNode> _TestsDispatcher;

	private IComparer<IntersectNode> interpreterDispatcher;

	private bool _ContainerDispatcher;

	private PolyFillType composerDispatcher;

	private PolyFillType m_ModelDispatcher;

	private List<ExporterInstanceFilter> advisorDispatcher;

	private List<ExporterInstanceFilter> _CustomerDispatcher;

	private bool serializerDispatcher;

	[CompilerGenerated]
	private bool m_ErrorDispatcher;

	public bool ReverseSolution { get; set; }

	public bool StrictlySimple
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorDispatcher;
		}
		[CompilerGenerated]
		set
		{
			m_ErrorDispatcher = value;
		}
	}

	public Clipper(int int_0 = 0)
	{
		m_PoolDispatcher = null;
		_TaskDispatcher = null;
		_FilterDispatcher = null;
		_TestsDispatcher = new List<IntersectNode>();
		interpreterDispatcher = new MyIntersectNodeSort();
		_ContainerDispatcher = false;
		serializerDispatcher = false;
		_ReponseDispatcher = new List<RulesConfigObject>();
		advisorDispatcher = new List<ExporterInstanceFilter>();
		_CustomerDispatcher = new List<ExporterInstanceFilter>();
		ReverseSolution = (1 & int_0) != 0;
		StrictlySimple = (2 & int_0) != 0;
		base.PreserveCollinear = (4 & int_0) != 0;
	}

	private void VerifyDefinition()
	{
		while (m_PoolDispatcher != null)
		{
			AnnotationDispatcher iteratorDispatcher = m_PoolDispatcher._IteratorDispatcher;
			m_PoolDispatcher = null;
			m_PoolDispatcher = iteratorDispatcher;
		}
	}

	protected override void Reset()
	{
		base.Reset();
		m_PoolDispatcher = null;
		_TaskDispatcher = null;
		_FilterDispatcher = null;
		for (IndexerCallbackCandidate queueDispatcher = contextDispatcher; queueDispatcher != null; queueDispatcher = queueDispatcher.m_QueueDispatcher)
		{
			ListDefinition(queueDispatcher.Y);
		}
	}

	private void ListDefinition(long long_0)
	{
		if (m_PoolDispatcher == null)
		{
			m_PoolDispatcher = new AnnotationDispatcher();
			m_PoolDispatcher._IteratorDispatcher = null;
			m_PoolDispatcher.Y = long_0;
		}
		else if (long_0 <= m_PoolDispatcher.Y)
		{
			AnnotationDispatcher annotationDispatcher = m_PoolDispatcher;
			while (annotationDispatcher._IteratorDispatcher != null && long_0 <= annotationDispatcher._IteratorDispatcher.Y)
			{
				annotationDispatcher = annotationDispatcher._IteratorDispatcher;
			}
			if (long_0 != annotationDispatcher.Y)
			{
				AnnotationDispatcher annotationDispatcher2 = new AnnotationDispatcher();
				annotationDispatcher2.Y = long_0;
				annotationDispatcher2._IteratorDispatcher = annotationDispatcher._IteratorDispatcher;
				annotationDispatcher._IteratorDispatcher = annotationDispatcher2;
			}
		}
		else
		{
			AnnotationDispatcher annotationDispatcher3 = new AnnotationDispatcher();
			annotationDispatcher3.Y = long_0;
			annotationDispatcher3._IteratorDispatcher = m_PoolDispatcher;
			m_PoolDispatcher = annotationDispatcher3;
		}
	}

	public bool Execute(ClipType clipType_0, List<List<IntPoint>> list_0, PolyFillType polyFillType_0, PolyFillType polyFillType_1)
	{
		if (_ContainerDispatcher)
		{
			return false;
		}
		if (_ConfigurationDispatcher)
		{
			throw new InfoListenerManager("Error: PolyTree struct is need for open path clipping.");
		}
		_ContainerDispatcher = true;
		list_0.Clear();
		m_ModelDispatcher = polyFillType_0;
		composerDispatcher = polyFillType_1;
		_DescriptorDispatcher = clipType_0;
		serializerDispatcher = false;
		try
		{
			bool result;
			if (result = PostDefinition())
			{
				CompareVal(list_0);
				return result;
			}
			return result;
		}
		finally
		{
			StartDefinition();
			_ContainerDispatcher = false;
		}
	}

	public bool Execute(ClipType clipType_0, PolyTree polyTree_0, PolyFillType polyFillType_0, PolyFillType polyFillType_1)
	{
		if (_ContainerDispatcher)
		{
			return false;
		}
		_ContainerDispatcher = true;
		m_ModelDispatcher = polyFillType_0;
		composerDispatcher = polyFillType_1;
		_DescriptorDispatcher = clipType_0;
		serializerDispatcher = true;
		try
		{
			bool result;
			if (result = PostDefinition())
			{
				ReadVal(polyTree_0);
				return result;
			}
			return result;
		}
		finally
		{
			StartDefinition();
			_ContainerDispatcher = false;
		}
	}

	public bool Execute(ClipType clipType_0, List<List<IntPoint>> list_0)
	{
		return Execute(clipType_0, list_0, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	public bool Execute(ClipType clipType_0, PolyTree polyTree_0)
	{
		return Execute(clipType_0, polyTree_0, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	internal void ResolveDefinition(RulesConfigObject rulesConfigObject_0)
	{
		if (rulesConfigObject_0.candidateDispatcher != null && (rulesConfigObject_0.serviceDispatcher == rulesConfigObject_0.candidateDispatcher.serviceDispatcher || rulesConfigObject_0.candidateDispatcher._BaseDispatcher == null))
		{
			RulesConfigObject candidateDispatcher = rulesConfigObject_0.candidateDispatcher;
			while (candidateDispatcher != null && (candidateDispatcher.serviceDispatcher == rulesConfigObject_0.serviceDispatcher || candidateDispatcher._BaseDispatcher == null))
			{
				candidateDispatcher = candidateDispatcher.candidateDispatcher;
			}
			rulesConfigObject_0.candidateDispatcher = candidateDispatcher;
		}
	}

	private bool PostDefinition()
	{
		try
		{
			Reset();
			if (statusDispatcher == null)
			{
				return false;
			}
			long long_ = RunDefinition();
			do
			{
				AwakeDefinition(long_);
				_CustomerDispatcher.Clear();
				PushVal(bool_0: false);
				if (m_PoolDispatcher == null)
				{
					break;
				}
				long num = RunDefinition();
				if (CheckVal(long_, num))
				{
					PopVal(num);
					long_ = num;
					continue;
				}
				return false;
			}
			while (m_PoolDispatcher != null || statusDispatcher != null);
			for (int i = 0; i < _ReponseDispatcher.Count; i++)
			{
				RulesConfigObject rulesConfigObject = _ReponseDispatcher[i];
				if (rulesConfigObject._BaseDispatcher != null && !rulesConfigObject.m_SystemDispatcher && (rulesConfigObject.serviceDispatcher ^ ReverseSolution) == Area(rulesConfigObject) > 0.0)
				{
					LogoutVal(rulesConfigObject._BaseDispatcher);
				}
			}
			VerifyVal();
			for (int j = 0; j < _ReponseDispatcher.Count; j++)
			{
				RulesConfigObject rulesConfigObject2 = _ReponseDispatcher[j];
				if (rulesConfigObject2._BaseDispatcher != null && !rulesConfigObject2.m_SystemDispatcher)
				{
					DisableVal(rulesConfigObject2);
				}
			}
			if (StrictlySimple)
			{
				ResolveVal();
			}
			return true;
		}
		finally
		{
			advisorDispatcher.Clear();
			_CustomerDispatcher.Clear();
		}
	}

	private long RunDefinition()
	{
		long y = m_PoolDispatcher.Y;
		m_PoolDispatcher = m_PoolDispatcher._IteratorDispatcher;
		return y;
	}

	private void StartDefinition()
	{
		for (int i = 0; i < _ReponseDispatcher.Count; i++)
		{
			AssetDefinition(i);
		}
		_ReponseDispatcher.Clear();
	}

	private void AssetDefinition(int int_0)
	{
		RulesConfigObject rulesConfigObject = _ReponseDispatcher[int_0];
		if (rulesConfigObject._BaseDispatcher != null)
		{
			PrintDefinition(rulesConfigObject._BaseDispatcher);
		}
		rulesConfigObject = null;
		_ReponseDispatcher[int_0] = null;
	}

	private void PrintDefinition(PredicateThreadBridge predicateThreadBridge_0)
	{
		if (predicateThreadBridge_0 != null)
		{
			predicateThreadBridge_0._RulesDispatcher.pageDispatcher = null;
			while (predicateThreadBridge_0 != null)
			{
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
			}
		}
	}

	private void DefineDefinition(PredicateThreadBridge predicateThreadBridge_0, PredicateThreadBridge predicateThreadBridge_1, IntPoint intPoint_0)
	{
		ExporterInstanceFilter exporterInstanceFilter = new ExporterInstanceFilter();
		exporterInstanceFilter.m_TemplateDispatcher = predicateThreadBridge_0;
		exporterInstanceFilter.m_MappingDispatcher = predicateThreadBridge_1;
		exporterInstanceFilter.mockDispatcher = intPoint_0;
		advisorDispatcher.Add(exporterInstanceFilter);
	}

	private void PublishDefinition(PredicateThreadBridge predicateThreadBridge_0, IntPoint intPoint_0)
	{
		ExporterInstanceFilter exporterInstanceFilter = new ExporterInstanceFilter();
		exporterInstanceFilter.m_TemplateDispatcher = predicateThreadBridge_0;
		exporterInstanceFilter.mockDispatcher = intPoint_0;
		_CustomerDispatcher.Add(exporterInstanceFilter);
	}

	private void AwakeDefinition(long long_0)
	{
		while (statusDispatcher != null && statusDispatcher.Y == long_0)
		{
			RefDispatcherList tagDispatcher = statusDispatcher._TagDispatcher;
			RefDispatcherList fieldDispatcher = statusDispatcher.m_FieldDispatcher;
			PopLocalMinima();
			PredicateThreadBridge predicateThreadBridge = null;
			if (tagDispatcher == null)
			{
				QueryDefinition(fieldDispatcher, null);
				RateDefinition(fieldDispatcher);
				if (CalcDefinition(fieldDispatcher))
				{
					predicateThreadBridge = CountVal(fieldDispatcher, fieldDispatcher.m_InitializerDispatcher);
				}
			}
			else if (fieldDispatcher == null)
			{
				QueryDefinition(tagDispatcher, null);
				RateDefinition(tagDispatcher);
				if (CalcDefinition(tagDispatcher))
				{
					predicateThreadBridge = CountVal(tagDispatcher, tagDispatcher.m_InitializerDispatcher);
				}
				ListDefinition(tagDispatcher.Top.Y);
			}
			else
			{
				QueryDefinition(tagDispatcher, null);
				QueryDefinition(fieldDispatcher, tagDispatcher);
				RateDefinition(tagDispatcher);
				fieldDispatcher.accountDispatcher = tagDispatcher.accountDispatcher;
				fieldDispatcher._StateDispatcher = tagDispatcher._StateDispatcher;
				if (CalcDefinition(tagDispatcher))
				{
					predicateThreadBridge = ManageDefinition(tagDispatcher, fieldDispatcher, tagDispatcher.m_InitializerDispatcher);
				}
				ListDefinition(tagDispatcher.Top.Y);
			}
			if (fieldDispatcher != null)
			{
				if (ClipperBase.QueryVal(fieldDispatcher))
				{
					FlushDefinition(fieldDispatcher);
				}
				else
				{
					ListDefinition(fieldDispatcher.Top.Y);
				}
			}
			if (tagDispatcher == null || fieldDispatcher == null)
			{
				continue;
			}
			if (predicateThreadBridge != null && ClipperBase.QueryVal(fieldDispatcher) && _CustomerDispatcher.Count > 0 && fieldDispatcher.workerDispatcher != 0)
			{
				for (int i = 0; i < _CustomerDispatcher.Count; i++)
				{
					ExporterInstanceFilter exporterInstanceFilter = _CustomerDispatcher[i];
					if (CloneVal(exporterInstanceFilter.m_TemplateDispatcher.m_ParamDispatcher, exporterInstanceFilter.mockDispatcher, fieldDispatcher.m_InitializerDispatcher, fieldDispatcher.Top))
					{
						DefineDefinition(exporterInstanceFilter.m_TemplateDispatcher, predicateThreadBridge, exporterInstanceFilter.mockDispatcher);
					}
				}
			}
			if (tagDispatcher.m_AuthenticationDispatcher >= 0 && tagDispatcher._ManagerDispatcher != null && tagDispatcher._ManagerDispatcher.roleDispatcher.X == tagDispatcher.m_InitializerDispatcher.X && tagDispatcher._ManagerDispatcher.m_AuthenticationDispatcher >= 0 && ClipperBase.CalcVal(tagDispatcher._ManagerDispatcher, tagDispatcher, _StrategyDispatcher) && tagDispatcher.workerDispatcher != 0 && tagDispatcher._ManagerDispatcher.workerDispatcher != 0)
			{
				PredicateThreadBridge predicateThreadBridge_ = CountVal(tagDispatcher._ManagerDispatcher, tagDispatcher.m_InitializerDispatcher);
				DefineDefinition(predicateThreadBridge, predicateThreadBridge_, tagDispatcher.Top);
			}
			if (tagDispatcher.mapperDispatcher == fieldDispatcher)
			{
				continue;
			}
			if (fieldDispatcher.m_AuthenticationDispatcher >= 0 && fieldDispatcher._ManagerDispatcher.m_AuthenticationDispatcher >= 0 && ClipperBase.CalcVal(fieldDispatcher._ManagerDispatcher, fieldDispatcher, _StrategyDispatcher) && fieldDispatcher.workerDispatcher != 0 && fieldDispatcher._ManagerDispatcher.workerDispatcher != 0)
			{
				PredicateThreadBridge predicateThreadBridge_2 = CountVal(fieldDispatcher._ManagerDispatcher, fieldDispatcher.m_InitializerDispatcher);
				DefineDefinition(predicateThreadBridge, predicateThreadBridge_2, fieldDispatcher.Top);
			}
			RefDispatcherList mapperDispatcher = tagDispatcher.mapperDispatcher;
			if (mapperDispatcher != null)
			{
				while (mapperDispatcher != fieldDispatcher)
				{
					LoginVal(fieldDispatcher, mapperDispatcher, tagDispatcher.roleDispatcher);
					mapperDispatcher = mapperDispatcher.mapperDispatcher;
				}
			}
		}
	}

	private void QueryDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		if (_TaskDispatcher == null)
		{
			refDispatcherList_0._ManagerDispatcher = null;
			refDispatcherList_0.mapperDispatcher = null;
			_TaskDispatcher = refDispatcherList_0;
			return;
		}
		if (refDispatcherList_1 == null && ResetDefinition(_TaskDispatcher, refDispatcherList_0))
		{
			refDispatcherList_0._ManagerDispatcher = null;
			refDispatcherList_0.mapperDispatcher = _TaskDispatcher;
			_TaskDispatcher._ManagerDispatcher = refDispatcherList_0;
			_TaskDispatcher = refDispatcherList_0;
			return;
		}
		if (refDispatcherList_1 == null)
		{
			refDispatcherList_1 = _TaskDispatcher;
		}
		while (refDispatcherList_1.mapperDispatcher != null && !ResetDefinition(refDispatcherList_1.mapperDispatcher, refDispatcherList_0))
		{
			refDispatcherList_1 = refDispatcherList_1.mapperDispatcher;
		}
		refDispatcherList_0.mapperDispatcher = refDispatcherList_1.mapperDispatcher;
		if (refDispatcherList_1.mapperDispatcher != null)
		{
			refDispatcherList_1.mapperDispatcher._ManagerDispatcher = refDispatcherList_0;
		}
		refDispatcherList_0._ManagerDispatcher = refDispatcherList_1;
		refDispatcherList_1.mapperDispatcher = refDispatcherList_0;
	}

	private bool ResetDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		if (refDispatcherList_1.roleDispatcher.X == refDispatcherList_0.roleDispatcher.X)
		{
			if (refDispatcherList_1.Top.Y <= refDispatcherList_0.Top.Y)
			{
				return refDispatcherList_0.Top.X > FillVal(refDispatcherList_1, refDispatcherList_0.Top.Y);
			}
			return refDispatcherList_1.Top.X < FillVal(refDispatcherList_0, refDispatcherList_1.Top.Y);
		}
		return refDispatcherList_1.roleDispatcher.X < refDispatcherList_0.roleDispatcher.X;
	}

	private bool MapDefinition(RefDispatcherList refDispatcherList_0)
	{
		if (refDispatcherList_0._EventDispatcher == PolyType.ptSubject)
		{
			return m_ModelDispatcher == PolyFillType.pftEvenOdd;
		}
		return composerDispatcher == PolyFillType.pftEvenOdd;
	}

	private bool SortDefinition(RefDispatcherList refDispatcherList_0)
	{
		if (refDispatcherList_0._EventDispatcher == PolyType.ptSubject)
		{
			return composerDispatcher == PolyFillType.pftEvenOdd;
		}
		return m_ModelDispatcher == PolyFillType.pftEvenOdd;
	}

	private bool CalcDefinition(RefDispatcherList refDispatcherList_0)
	{
		PolyFillType modelDispatcher;
		PolyFillType modelDispatcher2;
		if (refDispatcherList_0._EventDispatcher == PolyType.ptSubject)
		{
			modelDispatcher = m_ModelDispatcher;
			modelDispatcher2 = composerDispatcher;
		}
		else
		{
			modelDispatcher = composerDispatcher;
			modelDispatcher2 = m_ModelDispatcher;
		}
		switch (modelDispatcher)
		{
		default:
			if (refDispatcherList_0.accountDispatcher != -1)
			{
				return false;
			}
			break;
		case PolyFillType.pftEvenOdd:
			if (refDispatcherList_0.workerDispatcher == 0 && refDispatcherList_0.accountDispatcher != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftNonZero:
			if (Math.Abs(refDispatcherList_0.accountDispatcher) != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftPositive:
			if (refDispatcherList_0.accountDispatcher != 1)
			{
				return false;
			}
			break;
		}
		switch (_DescriptorDispatcher)
		{
		default:
			return true;
		case ClipType.ctIntersection:
			switch (modelDispatcher2)
			{
			default:
				return refDispatcherList_0._StateDispatcher < 0;
			case PolyFillType.pftPositive:
				return refDispatcherList_0._StateDispatcher > 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return refDispatcherList_0._StateDispatcher != 0;
			}
		case ClipType.ctUnion:
			switch (modelDispatcher2)
			{
			default:
				return refDispatcherList_0._StateDispatcher >= 0;
			case PolyFillType.pftPositive:
				return refDispatcherList_0._StateDispatcher <= 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return refDispatcherList_0._StateDispatcher == 0;
			}
		case ClipType.ctDifference:
			if (refDispatcherList_0._EventDispatcher == PolyType.ptSubject)
			{
				switch (modelDispatcher2)
				{
				default:
					return refDispatcherList_0._StateDispatcher >= 0;
				case PolyFillType.pftPositive:
					return refDispatcherList_0._StateDispatcher <= 0;
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return refDispatcherList_0._StateDispatcher == 0;
				}
			}
			switch (modelDispatcher2)
			{
			default:
				return refDispatcherList_0._StateDispatcher < 0;
			case PolyFillType.pftPositive:
				return refDispatcherList_0._StateDispatcher > 0;
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return refDispatcherList_0._StateDispatcher != 0;
			}
		case ClipType.ctXor:
			if (refDispatcherList_0.workerDispatcher == 0)
			{
				switch (modelDispatcher2)
				{
				default:
					return refDispatcherList_0._StateDispatcher >= 0;
				case PolyFillType.pftPositive:
					return refDispatcherList_0._StateDispatcher <= 0;
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return refDispatcherList_0._StateDispatcher == 0;
				}
			}
			return true;
		}
	}

	private void RateDefinition(RefDispatcherList refDispatcherList_0)
	{
		RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher;
		while (managerDispatcher != null && (managerDispatcher._EventDispatcher != refDispatcherList_0._EventDispatcher || managerDispatcher.workerDispatcher == 0))
		{
			managerDispatcher = managerDispatcher._ManagerDispatcher;
		}
		if (managerDispatcher == null)
		{
			refDispatcherList_0.accountDispatcher = ((refDispatcherList_0.workerDispatcher == 0) ? 1 : refDispatcherList_0.workerDispatcher);
			refDispatcherList_0._StateDispatcher = 0;
			managerDispatcher = _TaskDispatcher;
		}
		else if (refDispatcherList_0.workerDispatcher == 0 && _DescriptorDispatcher != ClipType.ctUnion)
		{
			refDispatcherList_0.accountDispatcher = 1;
			refDispatcherList_0._StateDispatcher = managerDispatcher._StateDispatcher;
			managerDispatcher = managerDispatcher.mapperDispatcher;
		}
		else if (MapDefinition(refDispatcherList_0))
		{
			if (refDispatcherList_0.workerDispatcher == 0)
			{
				bool flag = true;
				for (RefDispatcherList managerDispatcher2 = managerDispatcher._ManagerDispatcher; managerDispatcher2 != null; managerDispatcher2 = managerDispatcher2._ManagerDispatcher)
				{
					if (managerDispatcher2._EventDispatcher == managerDispatcher._EventDispatcher && managerDispatcher2.workerDispatcher != 0)
					{
						flag = !flag;
					}
				}
				refDispatcherList_0.accountDispatcher = ((!flag) ? 1 : 0);
			}
			else
			{
				refDispatcherList_0.accountDispatcher = refDispatcherList_0.workerDispatcher;
			}
			refDispatcherList_0._StateDispatcher = managerDispatcher._StateDispatcher;
			managerDispatcher = managerDispatcher.mapperDispatcher;
		}
		else
		{
			if (managerDispatcher.accountDispatcher * managerDispatcher.workerDispatcher < 0)
			{
				if (Math.Abs(managerDispatcher.accountDispatcher) <= 1)
				{
					refDispatcherList_0.accountDispatcher = ((refDispatcherList_0.workerDispatcher == 0) ? 1 : refDispatcherList_0.workerDispatcher);
				}
				else if (managerDispatcher.workerDispatcher * refDispatcherList_0.workerDispatcher < 0)
				{
					refDispatcherList_0.accountDispatcher = managerDispatcher.accountDispatcher;
				}
				else
				{
					refDispatcherList_0.accountDispatcher = managerDispatcher.accountDispatcher + refDispatcherList_0.workerDispatcher;
				}
			}
			else if (refDispatcherList_0.workerDispatcher == 0)
			{
				refDispatcherList_0.accountDispatcher = ((managerDispatcher.accountDispatcher < 0) ? (managerDispatcher.accountDispatcher - 1) : (managerDispatcher.accountDispatcher + 1));
			}
			else if (managerDispatcher.workerDispatcher * refDispatcherList_0.workerDispatcher < 0)
			{
				refDispatcherList_0.accountDispatcher = managerDispatcher.accountDispatcher;
			}
			else
			{
				refDispatcherList_0.accountDispatcher = managerDispatcher.accountDispatcher + refDispatcherList_0.workerDispatcher;
			}
			refDispatcherList_0._StateDispatcher = managerDispatcher._StateDispatcher;
			managerDispatcher = managerDispatcher.mapperDispatcher;
		}
		if (SortDefinition(refDispatcherList_0))
		{
			while (managerDispatcher != refDispatcherList_0)
			{
				if (managerDispatcher.workerDispatcher != 0)
				{
					refDispatcherList_0._StateDispatcher = ((refDispatcherList_0._StateDispatcher == 0) ? 1 : 0);
				}
				managerDispatcher = managerDispatcher.mapperDispatcher;
			}
		}
		else
		{
			while (managerDispatcher != refDispatcherList_0)
			{
				refDispatcherList_0._StateDispatcher += managerDispatcher.workerDispatcher;
				managerDispatcher = managerDispatcher.mapperDispatcher;
			}
		}
	}

	private void FlushDefinition(RefDispatcherList refDispatcherList_0)
	{
		if (_FilterDispatcher == null)
		{
			_FilterDispatcher = refDispatcherList_0;
			refDispatcherList_0.m_ProducerDispatcher = null;
			refDispatcherList_0._GetterDispatcher = null;
		}
		else
		{
			refDispatcherList_0._GetterDispatcher = _FilterDispatcher;
			refDispatcherList_0.m_ProducerDispatcher = null;
			_FilterDispatcher.m_ProducerDispatcher = refDispatcherList_0;
			_FilterDispatcher = refDispatcherList_0;
		}
	}

	private void ForgotDefinition()
	{
		for (RefDispatcherList refDispatcherList = (_FilterDispatcher = _TaskDispatcher); refDispatcherList != null; refDispatcherList = refDispatcherList.mapperDispatcher)
		{
			refDispatcherList.m_ProducerDispatcher = refDispatcherList._ManagerDispatcher;
			refDispatcherList._GetterDispatcher = refDispatcherList.mapperDispatcher;
		}
	}

	private void CollectDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		if (refDispatcherList_0.mapperDispatcher == refDispatcherList_0._ManagerDispatcher || refDispatcherList_1.mapperDispatcher == refDispatcherList_1._ManagerDispatcher)
		{
			return;
		}
		if (refDispatcherList_0.mapperDispatcher == refDispatcherList_1)
		{
			RefDispatcherList mapperDispatcher = refDispatcherList_1.mapperDispatcher;
			if (mapperDispatcher != null)
			{
				mapperDispatcher._ManagerDispatcher = refDispatcherList_0;
			}
			RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher;
			if (managerDispatcher != null)
			{
				managerDispatcher.mapperDispatcher = refDispatcherList_1;
			}
			refDispatcherList_1._ManagerDispatcher = managerDispatcher;
			refDispatcherList_1.mapperDispatcher = refDispatcherList_0;
			refDispatcherList_0._ManagerDispatcher = refDispatcherList_1;
			refDispatcherList_0.mapperDispatcher = mapperDispatcher;
		}
		else if (refDispatcherList_1.mapperDispatcher == refDispatcherList_0)
		{
			RefDispatcherList mapperDispatcher2 = refDispatcherList_0.mapperDispatcher;
			if (mapperDispatcher2 != null)
			{
				mapperDispatcher2._ManagerDispatcher = refDispatcherList_1;
			}
			RefDispatcherList managerDispatcher2 = refDispatcherList_1._ManagerDispatcher;
			if (managerDispatcher2 != null)
			{
				managerDispatcher2.mapperDispatcher = refDispatcherList_0;
			}
			refDispatcherList_0._ManagerDispatcher = managerDispatcher2;
			refDispatcherList_0.mapperDispatcher = refDispatcherList_1;
			refDispatcherList_1._ManagerDispatcher = refDispatcherList_0;
			refDispatcherList_1.mapperDispatcher = mapperDispatcher2;
		}
		else
		{
			RefDispatcherList mapperDispatcher3 = refDispatcherList_0.mapperDispatcher;
			RefDispatcherList managerDispatcher3 = refDispatcherList_0._ManagerDispatcher;
			refDispatcherList_0.mapperDispatcher = refDispatcherList_1.mapperDispatcher;
			if (refDispatcherList_0.mapperDispatcher != null)
			{
				refDispatcherList_0.mapperDispatcher._ManagerDispatcher = refDispatcherList_0;
			}
			refDispatcherList_0._ManagerDispatcher = refDispatcherList_1._ManagerDispatcher;
			if (refDispatcherList_0._ManagerDispatcher != null)
			{
				refDispatcherList_0._ManagerDispatcher.mapperDispatcher = refDispatcherList_0;
			}
			refDispatcherList_1.mapperDispatcher = mapperDispatcher3;
			if (refDispatcherList_1.mapperDispatcher != null)
			{
				refDispatcherList_1.mapperDispatcher._ManagerDispatcher = refDispatcherList_1;
			}
			refDispatcherList_1._ManagerDispatcher = managerDispatcher3;
			if (refDispatcherList_1._ManagerDispatcher != null)
			{
				refDispatcherList_1._ManagerDispatcher.mapperDispatcher = refDispatcherList_1;
			}
		}
		if (refDispatcherList_0._ManagerDispatcher == null)
		{
			_TaskDispatcher = refDispatcherList_0;
		}
		else if (refDispatcherList_1._ManagerDispatcher == null)
		{
			_TaskDispatcher = refDispatcherList_1;
		}
	}

	private void OrderDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		if ((refDispatcherList_0._GetterDispatcher == null && refDispatcherList_0.m_ProducerDispatcher == null) || (refDispatcherList_1._GetterDispatcher == null && refDispatcherList_1.m_ProducerDispatcher == null))
		{
			return;
		}
		if (refDispatcherList_0._GetterDispatcher == refDispatcherList_1)
		{
			RefDispatcherList getterDispatcher = refDispatcherList_1._GetterDispatcher;
			if (getterDispatcher != null)
			{
				getterDispatcher.m_ProducerDispatcher = refDispatcherList_0;
			}
			RefDispatcherList producerDispatcher = refDispatcherList_0.m_ProducerDispatcher;
			if (producerDispatcher != null)
			{
				producerDispatcher._GetterDispatcher = refDispatcherList_1;
			}
			refDispatcherList_1.m_ProducerDispatcher = producerDispatcher;
			refDispatcherList_1._GetterDispatcher = refDispatcherList_0;
			refDispatcherList_0.m_ProducerDispatcher = refDispatcherList_1;
			refDispatcherList_0._GetterDispatcher = getterDispatcher;
		}
		else if (refDispatcherList_1._GetterDispatcher == refDispatcherList_0)
		{
			RefDispatcherList getterDispatcher2 = refDispatcherList_0._GetterDispatcher;
			if (getterDispatcher2 != null)
			{
				getterDispatcher2.m_ProducerDispatcher = refDispatcherList_1;
			}
			RefDispatcherList producerDispatcher2 = refDispatcherList_1.m_ProducerDispatcher;
			if (producerDispatcher2 != null)
			{
				producerDispatcher2._GetterDispatcher = refDispatcherList_0;
			}
			refDispatcherList_0.m_ProducerDispatcher = producerDispatcher2;
			refDispatcherList_0._GetterDispatcher = refDispatcherList_1;
			refDispatcherList_1.m_ProducerDispatcher = refDispatcherList_0;
			refDispatcherList_1._GetterDispatcher = getterDispatcher2;
		}
		else
		{
			RefDispatcherList getterDispatcher3 = refDispatcherList_0._GetterDispatcher;
			RefDispatcherList producerDispatcher3 = refDispatcherList_0.m_ProducerDispatcher;
			refDispatcherList_0._GetterDispatcher = refDispatcherList_1._GetterDispatcher;
			if (refDispatcherList_0._GetterDispatcher != null)
			{
				refDispatcherList_0._GetterDispatcher.m_ProducerDispatcher = refDispatcherList_0;
			}
			refDispatcherList_0.m_ProducerDispatcher = refDispatcherList_1.m_ProducerDispatcher;
			if (refDispatcherList_0.m_ProducerDispatcher != null)
			{
				refDispatcherList_0.m_ProducerDispatcher._GetterDispatcher = refDispatcherList_0;
			}
			refDispatcherList_1._GetterDispatcher = getterDispatcher3;
			if (refDispatcherList_1._GetterDispatcher != null)
			{
				refDispatcherList_1._GetterDispatcher.m_ProducerDispatcher = refDispatcherList_1;
			}
			refDispatcherList_1.m_ProducerDispatcher = producerDispatcher3;
			if (refDispatcherList_1.m_ProducerDispatcher != null)
			{
				refDispatcherList_1.m_ProducerDispatcher._GetterDispatcher = refDispatcherList_1;
			}
		}
		if (refDispatcherList_0.m_ProducerDispatcher == null)
		{
			_FilterDispatcher = refDispatcherList_0;
		}
		else if (refDispatcherList_1.m_ProducerDispatcher == null)
		{
			_FilterDispatcher = refDispatcherList_1;
		}
	}

	private void RegisterDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1, IntPoint intPoint_0)
	{
		CountVal(refDispatcherList_0, intPoint_0);
		if (refDispatcherList_1.workerDispatcher == 0)
		{
			CountVal(refDispatcherList_1, intPoint_0);
		}
		if (refDispatcherList_0.m_AuthenticationDispatcher == refDispatcherList_1.m_AuthenticationDispatcher)
		{
			refDispatcherList_0.m_AuthenticationDispatcher = -1;
			refDispatcherList_1.m_AuthenticationDispatcher = -1;
		}
		else if (refDispatcherList_0.m_AuthenticationDispatcher < refDispatcherList_1.m_AuthenticationDispatcher)
		{
			CallVal(refDispatcherList_0, refDispatcherList_1);
		}
		else
		{
			CallVal(refDispatcherList_1, refDispatcherList_0);
		}
	}

	private PredicateThreadBridge ManageDefinition(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1, IntPoint intPoint_0)
	{
		PredicateThreadBridge predicateThreadBridge;
		RefDispatcherList refDispatcherList;
		RefDispatcherList refDispatcherList2;
		if (!ClipperBase.QueryVal(refDispatcherList_1) && refDispatcherList_0.m_AttributeDispatcher <= refDispatcherList_1.m_AttributeDispatcher)
		{
			predicateThreadBridge = CountVal(refDispatcherList_1, intPoint_0);
			refDispatcherList_0.m_AuthenticationDispatcher = refDispatcherList_1.m_AuthenticationDispatcher;
			refDispatcherList_0.globalDispatcher = EdgeSide.esRight;
			refDispatcherList_1.globalDispatcher = EdgeSide.esLeft;
			refDispatcherList = refDispatcherList_1;
			refDispatcherList2 = ((refDispatcherList._ManagerDispatcher == refDispatcherList_0) ? refDispatcherList_0._ManagerDispatcher : refDispatcherList._ManagerDispatcher);
		}
		else
		{
			predicateThreadBridge = CountVal(refDispatcherList_0, intPoint_0);
			refDispatcherList_1.m_AuthenticationDispatcher = refDispatcherList_0.m_AuthenticationDispatcher;
			refDispatcherList_0.globalDispatcher = EdgeSide.esLeft;
			refDispatcherList_1.globalDispatcher = EdgeSide.esRight;
			refDispatcherList = refDispatcherList_0;
			refDispatcherList2 = ((refDispatcherList._ManagerDispatcher == refDispatcherList_1) ? refDispatcherList_1._ManagerDispatcher : refDispatcherList._ManagerDispatcher);
		}
		if (refDispatcherList2 != null && refDispatcherList2.m_AuthenticationDispatcher >= 0 && FillVal(refDispatcherList2, intPoint_0.Y) == FillVal(refDispatcherList, intPoint_0.Y) && ClipperBase.CalcVal(refDispatcherList, refDispatcherList2, _StrategyDispatcher) && refDispatcherList.workerDispatcher != 0 && refDispatcherList2.workerDispatcher != 0)
		{
			PredicateThreadBridge predicateThreadBridge_ = CountVal(refDispatcherList2, intPoint_0);
			DefineDefinition(predicateThreadBridge, predicateThreadBridge_, refDispatcherList.Top);
		}
		return predicateThreadBridge;
	}

	private RulesConfigObject RevertDefinition()
	{
		RulesConfigObject rulesConfigObject = new RulesConfigObject();
		rulesConfigObject.m_MethodDispatcher = -1;
		rulesConfigObject.serviceDispatcher = false;
		rulesConfigObject.m_SystemDispatcher = false;
		rulesConfigObject.candidateDispatcher = null;
		rulesConfigObject._BaseDispatcher = null;
		rulesConfigObject.policyDispatcher = null;
		rulesConfigObject.m_BroadcasterDispatcher = null;
		_ReponseDispatcher.Add(rulesConfigObject);
		rulesConfigObject.m_MethodDispatcher = _ReponseDispatcher.Count - 1;
		return rulesConfigObject;
	}

	private PredicateThreadBridge CountVal(RefDispatcherList refDispatcherList_0, IntPoint intPoint_0)
	{
		bool flag = refDispatcherList_0.globalDispatcher == EdgeSide.esLeft;
		if (refDispatcherList_0.m_AuthenticationDispatcher < 0)
		{
			RulesConfigObject rulesConfigObject = RevertDefinition();
			rulesConfigObject.m_SystemDispatcher = refDispatcherList_0.workerDispatcher == 0;
			PredicateThreadBridge predicateThreadBridge = (rulesConfigObject._BaseDispatcher = new PredicateThreadBridge());
			predicateThreadBridge.regDispatcher = rulesConfigObject.m_MethodDispatcher;
			predicateThreadBridge.m_ParamDispatcher = intPoint_0;
			predicateThreadBridge.pageDispatcher = predicateThreadBridge;
			predicateThreadBridge._RulesDispatcher = predicateThreadBridge;
			if (!rulesConfigObject.m_SystemDispatcher)
			{
				MoveVal(refDispatcherList_0, rulesConfigObject);
			}
			refDispatcherList_0.m_AuthenticationDispatcher = rulesConfigObject.m_MethodDispatcher;
			return predicateThreadBridge;
		}
		RulesConfigObject rulesConfigObject2 = _ReponseDispatcher[refDispatcherList_0.m_AuthenticationDispatcher];
		PredicateThreadBridge baseDispatcher = rulesConfigObject2._BaseDispatcher;
		if (flag && intPoint_0 == baseDispatcher.m_ParamDispatcher)
		{
			return baseDispatcher;
		}
		if (!flag && intPoint_0 == baseDispatcher._RulesDispatcher.m_ParamDispatcher)
		{
			return baseDispatcher._RulesDispatcher;
		}
		PredicateThreadBridge predicateThreadBridge2 = new PredicateThreadBridge();
		predicateThreadBridge2.regDispatcher = rulesConfigObject2.m_MethodDispatcher;
		predicateThreadBridge2.m_ParamDispatcher = intPoint_0;
		predicateThreadBridge2.pageDispatcher = baseDispatcher;
		predicateThreadBridge2._RulesDispatcher = baseDispatcher._RulesDispatcher;
		predicateThreadBridge2._RulesDispatcher.pageDispatcher = predicateThreadBridge2;
		baseDispatcher._RulesDispatcher = predicateThreadBridge2;
		if (flag)
		{
			rulesConfigObject2._BaseDispatcher = predicateThreadBridge2;
		}
		return predicateThreadBridge2;
	}

	internal void CustomizeVal(ref IntPoint intPoint_0, ref IntPoint intPoint_1)
	{
		IntPoint intPoint = new IntPoint(intPoint_0);
		intPoint_0 = intPoint_1;
		intPoint_1 = intPoint;
	}

	private bool CloneVal(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, IntPoint intPoint_3)
	{
		if (intPoint_0.X > intPoint_2.X == intPoint_0.X < intPoint_3.X)
		{
			return true;
		}
		if (intPoint_1.X > intPoint_2.X == intPoint_1.X < intPoint_3.X)
		{
			return true;
		}
		if (intPoint_2.X > intPoint_0.X == intPoint_2.X < intPoint_1.X)
		{
			return true;
		}
		if (intPoint_3.X > intPoint_0.X == intPoint_3.X < intPoint_1.X)
		{
			return true;
		}
		if (intPoint_0.X == intPoint_2.X && intPoint_1.X == intPoint_3.X)
		{
			return true;
		}
		if (intPoint_0.X == intPoint_3.X && intPoint_1.X == intPoint_2.X)
		{
			return true;
		}
		return false;
	}

	private PredicateThreadBridge ConnectVal(PredicateThreadBridge predicateThreadBridge_0, PredicateThreadBridge predicateThreadBridge_1, IntPoint intPoint_0)
	{
		PredicateThreadBridge predicateThreadBridge = new PredicateThreadBridge();
		predicateThreadBridge.m_ParamDispatcher = intPoint_0;
		if (predicateThreadBridge_1 == predicateThreadBridge_0.pageDispatcher)
		{
			predicateThreadBridge_0.pageDispatcher = predicateThreadBridge;
			predicateThreadBridge_1._RulesDispatcher = predicateThreadBridge;
			predicateThreadBridge.pageDispatcher = predicateThreadBridge_1;
			predicateThreadBridge._RulesDispatcher = predicateThreadBridge_0;
		}
		else
		{
			predicateThreadBridge_1.pageDispatcher = predicateThreadBridge;
			predicateThreadBridge_0._RulesDispatcher = predicateThreadBridge;
			predicateThreadBridge.pageDispatcher = predicateThreadBridge_0;
			predicateThreadBridge._RulesDispatcher = predicateThreadBridge_1;
		}
		return predicateThreadBridge;
	}

	private void MoveVal(RefDispatcherList refDispatcherList_0, RulesConfigObject rulesConfigObject_0)
	{
		bool flag = false;
		for (RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher; managerDispatcher != null; managerDispatcher = managerDispatcher._ManagerDispatcher)
		{
			if (managerDispatcher.m_AuthenticationDispatcher >= 0 && managerDispatcher.workerDispatcher != 0)
			{
				flag = !flag;
				if (rulesConfigObject_0.candidateDispatcher == null)
				{
					rulesConfigObject_0.candidateDispatcher = _ReponseDispatcher[managerDispatcher.m_AuthenticationDispatcher];
				}
			}
		}
		if (flag)
		{
			rulesConfigObject_0.serviceDispatcher = true;
		}
	}

	private double DeleteVal(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		if (intPoint_0.Y == intPoint_1.Y)
		{
			return -3.4E+38;
		}
		return (double)(intPoint_1.X - intPoint_0.X) / (double)(intPoint_1.Y - intPoint_0.Y);
	}

	private bool AddVal(PredicateThreadBridge predicateThreadBridge_0, PredicateThreadBridge predicateThreadBridge_1)
	{
		PredicateThreadBridge rulesDispatcher = predicateThreadBridge_0._RulesDispatcher;
		while (rulesDispatcher.m_ParamDispatcher == predicateThreadBridge_0.m_ParamDispatcher && rulesDispatcher != predicateThreadBridge_0)
		{
			rulesDispatcher = rulesDispatcher._RulesDispatcher;
		}
		double num = Math.Abs(DeleteVal(predicateThreadBridge_0.m_ParamDispatcher, rulesDispatcher.m_ParamDispatcher));
		rulesDispatcher = predicateThreadBridge_0.pageDispatcher;
		while (rulesDispatcher.m_ParamDispatcher == predicateThreadBridge_0.m_ParamDispatcher && rulesDispatcher != predicateThreadBridge_0)
		{
			rulesDispatcher = rulesDispatcher.pageDispatcher;
		}
		double num2 = Math.Abs(DeleteVal(predicateThreadBridge_0.m_ParamDispatcher, rulesDispatcher.m_ParamDispatcher));
		rulesDispatcher = predicateThreadBridge_1._RulesDispatcher;
		while (rulesDispatcher.m_ParamDispatcher == predicateThreadBridge_1.m_ParamDispatcher && rulesDispatcher != predicateThreadBridge_1)
		{
			rulesDispatcher = rulesDispatcher._RulesDispatcher;
		}
		double num3 = Math.Abs(DeleteVal(predicateThreadBridge_1.m_ParamDispatcher, rulesDispatcher.m_ParamDispatcher));
		rulesDispatcher = predicateThreadBridge_1.pageDispatcher;
		while (rulesDispatcher.m_ParamDispatcher == predicateThreadBridge_1.m_ParamDispatcher && rulesDispatcher != predicateThreadBridge_1)
		{
			rulesDispatcher = rulesDispatcher.pageDispatcher;
		}
		double num4 = Math.Abs(DeleteVal(predicateThreadBridge_1.m_ParamDispatcher, rulesDispatcher.m_ParamDispatcher));
		if (!(num < num3) && num >= num4)
		{
			return true;
		}
		if (num2 < num3)
		{
			return false;
		}
		return num2 >= num4;
	}

	private PredicateThreadBridge DestroyVal(PredicateThreadBridge predicateThreadBridge_0)
	{
		PredicateThreadBridge predicateThreadBridge = null;
		PredicateThreadBridge pageDispatcher;
		for (pageDispatcher = predicateThreadBridge_0.pageDispatcher; pageDispatcher != predicateThreadBridge_0; pageDispatcher = pageDispatcher.pageDispatcher)
		{
			if (pageDispatcher.m_ParamDispatcher.Y <= predicateThreadBridge_0.m_ParamDispatcher.Y)
			{
				if (pageDispatcher.m_ParamDispatcher.Y == predicateThreadBridge_0.m_ParamDispatcher.Y && pageDispatcher.m_ParamDispatcher.X <= predicateThreadBridge_0.m_ParamDispatcher.X)
				{
					if (pageDispatcher.m_ParamDispatcher.X < predicateThreadBridge_0.m_ParamDispatcher.X)
					{
						predicateThreadBridge = null;
						predicateThreadBridge_0 = pageDispatcher;
					}
					else if (pageDispatcher.pageDispatcher != predicateThreadBridge_0 && pageDispatcher._RulesDispatcher != predicateThreadBridge_0)
					{
						predicateThreadBridge = pageDispatcher;
					}
				}
			}
			else
			{
				predicateThreadBridge_0 = pageDispatcher;
				predicateThreadBridge = null;
			}
		}
		if (predicateThreadBridge != null)
		{
			while (predicateThreadBridge != pageDispatcher)
			{
				if (!AddVal(pageDispatcher, predicateThreadBridge))
				{
					predicateThreadBridge_0 = predicateThreadBridge;
				}
				predicateThreadBridge = predicateThreadBridge.pageDispatcher;
				while (predicateThreadBridge.m_ParamDispatcher != predicateThreadBridge_0.m_ParamDispatcher)
				{
					predicateThreadBridge = predicateThreadBridge.pageDispatcher;
				}
			}
		}
		return predicateThreadBridge_0;
	}

	private RulesConfigObject ComputeVal(RulesConfigObject rulesConfigObject_0, RulesConfigObject rulesConfigObject_1)
	{
		if (rulesConfigObject_0.policyDispatcher == null)
		{
			rulesConfigObject_0.policyDispatcher = DestroyVal(rulesConfigObject_0._BaseDispatcher);
		}
		if (rulesConfigObject_1.policyDispatcher == null)
		{
			rulesConfigObject_1.policyDispatcher = DestroyVal(rulesConfigObject_1._BaseDispatcher);
		}
		PredicateThreadBridge policyDispatcher = rulesConfigObject_0.policyDispatcher;
		PredicateThreadBridge policyDispatcher2 = rulesConfigObject_1.policyDispatcher;
		if (policyDispatcher.m_ParamDispatcher.Y <= policyDispatcher2.m_ParamDispatcher.Y)
		{
			if (policyDispatcher.m_ParamDispatcher.Y < policyDispatcher2.m_ParamDispatcher.Y)
			{
				return rulesConfigObject_1;
			}
			if (policyDispatcher.m_ParamDispatcher.X < policyDispatcher2.m_ParamDispatcher.X)
			{
				return rulesConfigObject_0;
			}
			if (policyDispatcher.m_ParamDispatcher.X <= policyDispatcher2.m_ParamDispatcher.X)
			{
				if (policyDispatcher.pageDispatcher == policyDispatcher)
				{
					return rulesConfigObject_1;
				}
				if (policyDispatcher2.pageDispatcher == policyDispatcher2)
				{
					return rulesConfigObject_0;
				}
				if (AddVal(policyDispatcher, policyDispatcher2))
				{
					return rulesConfigObject_0;
				}
				return rulesConfigObject_1;
			}
			return rulesConfigObject_1;
		}
		return rulesConfigObject_0;
	}

	private bool PatchVal(RulesConfigObject rulesConfigObject_0, RulesConfigObject rulesConfigObject_1)
	{
		do
		{
			rulesConfigObject_0 = rulesConfigObject_0.candidateDispatcher;
			if (rulesConfigObject_0 == rulesConfigObject_1)
			{
				return true;
			}
		}
		while (rulesConfigObject_0 != null);
		return false;
	}

	private RulesConfigObject SelectVal(int int_0)
	{
		RulesConfigObject rulesConfigObject;
		for (rulesConfigObject = _ReponseDispatcher[int_0]; rulesConfigObject != _ReponseDispatcher[rulesConfigObject.m_MethodDispatcher]; rulesConfigObject = _ReponseDispatcher[rulesConfigObject.m_MethodDispatcher])
		{
		}
		return rulesConfigObject;
	}

	private void CallVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		RulesConfigObject rulesConfigObject = _ReponseDispatcher[refDispatcherList_0.m_AuthenticationDispatcher];
		RulesConfigObject rulesConfigObject2 = _ReponseDispatcher[refDispatcherList_1.m_AuthenticationDispatcher];
		RulesConfigObject obj = (PatchVal(rulesConfigObject, rulesConfigObject2) ? rulesConfigObject2 : (PatchVal(rulesConfigObject2, rulesConfigObject) ? rulesConfigObject : ComputeVal(rulesConfigObject, rulesConfigObject2)));
		PredicateThreadBridge baseDispatcher = rulesConfigObject._BaseDispatcher;
		PredicateThreadBridge rulesDispatcher = baseDispatcher._RulesDispatcher;
		PredicateThreadBridge baseDispatcher2 = rulesConfigObject2._BaseDispatcher;
		PredicateThreadBridge rulesDispatcher2 = baseDispatcher2._RulesDispatcher;
		EdgeSide globalDispatcher;
		if (refDispatcherList_0.globalDispatcher == EdgeSide.esLeft)
		{
			if (refDispatcherList_1.globalDispatcher == EdgeSide.esLeft)
			{
				LogoutVal(baseDispatcher2);
				baseDispatcher2.pageDispatcher = baseDispatcher;
				baseDispatcher._RulesDispatcher = baseDispatcher2;
				rulesDispatcher.pageDispatcher = rulesDispatcher2;
				rulesDispatcher2._RulesDispatcher = rulesDispatcher;
				rulesConfigObject._BaseDispatcher = rulesDispatcher2;
			}
			else
			{
				rulesDispatcher2.pageDispatcher = baseDispatcher;
				baseDispatcher._RulesDispatcher = rulesDispatcher2;
				baseDispatcher2._RulesDispatcher = rulesDispatcher;
				rulesDispatcher.pageDispatcher = baseDispatcher2;
				rulesConfigObject._BaseDispatcher = baseDispatcher2;
			}
			globalDispatcher = EdgeSide.esLeft;
		}
		else
		{
			if (refDispatcherList_1.globalDispatcher == EdgeSide.esRight)
			{
				LogoutVal(baseDispatcher2);
				rulesDispatcher.pageDispatcher = rulesDispatcher2;
				rulesDispatcher2._RulesDispatcher = rulesDispatcher;
				baseDispatcher2.pageDispatcher = baseDispatcher;
				baseDispatcher._RulesDispatcher = baseDispatcher2;
			}
			else
			{
				rulesDispatcher.pageDispatcher = baseDispatcher2;
				baseDispatcher2._RulesDispatcher = rulesDispatcher;
				baseDispatcher._RulesDispatcher = rulesDispatcher2;
				rulesDispatcher2.pageDispatcher = baseDispatcher;
			}
			globalDispatcher = EdgeSide.esRight;
		}
		rulesConfigObject.policyDispatcher = null;
		if (obj == rulesConfigObject2)
		{
			if (rulesConfigObject2.candidateDispatcher != rulesConfigObject)
			{
				rulesConfigObject.candidateDispatcher = rulesConfigObject2.candidateDispatcher;
			}
			rulesConfigObject.serviceDispatcher = rulesConfigObject2.serviceDispatcher;
		}
		rulesConfigObject2._BaseDispatcher = null;
		rulesConfigObject2.policyDispatcher = null;
		rulesConfigObject2.candidateDispatcher = rulesConfigObject;
		int authenticationDispatcher = refDispatcherList_0.m_AuthenticationDispatcher;
		int authenticationDispatcher2 = refDispatcherList_1.m_AuthenticationDispatcher;
		refDispatcherList_0.m_AuthenticationDispatcher = -1;
		refDispatcherList_1.m_AuthenticationDispatcher = -1;
		RefDispatcherList refDispatcherList = _TaskDispatcher;
		while (refDispatcherList != null)
		{
			if (refDispatcherList.m_AuthenticationDispatcher != authenticationDispatcher2)
			{
				refDispatcherList = refDispatcherList.mapperDispatcher;
				continue;
			}
			refDispatcherList.m_AuthenticationDispatcher = authenticationDispatcher;
			refDispatcherList.globalDispatcher = globalDispatcher;
			break;
		}
		rulesConfigObject2.m_MethodDispatcher = rulesConfigObject.m_MethodDispatcher;
	}

	private void LogoutVal(PredicateThreadBridge predicateThreadBridge_0)
	{
		if (predicateThreadBridge_0 != null)
		{
			PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
			do
			{
				PredicateThreadBridge pageDispatcher = predicateThreadBridge.pageDispatcher;
				predicateThreadBridge.pageDispatcher = predicateThreadBridge._RulesDispatcher;
				predicateThreadBridge._RulesDispatcher = pageDispatcher;
				predicateThreadBridge = pageDispatcher;
			}
			while (predicateThreadBridge != predicateThreadBridge_0);
		}
	}

	private static void ViewVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		EdgeSide globalDispatcher = refDispatcherList_0.globalDispatcher;
		refDispatcherList_0.globalDispatcher = refDispatcherList_1.globalDispatcher;
		refDispatcherList_1.globalDispatcher = globalDispatcher;
	}

	private static void ValidateVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1)
	{
		int authenticationDispatcher = refDispatcherList_0.m_AuthenticationDispatcher;
		refDispatcherList_0.m_AuthenticationDispatcher = refDispatcherList_1.m_AuthenticationDispatcher;
		refDispatcherList_1.m_AuthenticationDispatcher = authenticationDispatcher;
	}

	private void LoginVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1, IntPoint intPoint_0, bool bool_0 = false)
	{
		bool flag = !bool_0 && refDispatcherList_0._HelperDispatcher == null && refDispatcherList_0.Top.X == intPoint_0.X && refDispatcherList_0.Top.Y == intPoint_0.Y;
		bool flag2 = !bool_0 && refDispatcherList_1._HelperDispatcher == null && refDispatcherList_1.Top.X == intPoint_0.X && refDispatcherList_1.Top.Y == intPoint_0.Y;
		bool flag3 = refDispatcherList_0.m_AuthenticationDispatcher >= 0;
		bool flag4 = refDispatcherList_1.m_AuthenticationDispatcher >= 0;
		if (refDispatcherList_0._EventDispatcher == refDispatcherList_1._EventDispatcher)
		{
			if (MapDefinition(refDispatcherList_0))
			{
				int accountDispatcher = refDispatcherList_0.accountDispatcher;
				refDispatcherList_0.accountDispatcher = refDispatcherList_1.accountDispatcher;
				refDispatcherList_1.accountDispatcher = accountDispatcher;
			}
			else
			{
				if (refDispatcherList_0.accountDispatcher + refDispatcherList_1.workerDispatcher == 0)
				{
					refDispatcherList_0.accountDispatcher = -refDispatcherList_0.accountDispatcher;
				}
				else
				{
					refDispatcherList_0.accountDispatcher += refDispatcherList_1.workerDispatcher;
				}
				if (refDispatcherList_1.accountDispatcher - refDispatcherList_0.workerDispatcher == 0)
				{
					refDispatcherList_1.accountDispatcher = -refDispatcherList_1.accountDispatcher;
				}
				else
				{
					refDispatcherList_1.accountDispatcher -= refDispatcherList_0.workerDispatcher;
				}
			}
		}
		else
		{
			if (MapDefinition(refDispatcherList_1))
			{
				refDispatcherList_0._StateDispatcher = ((refDispatcherList_0._StateDispatcher == 0) ? 1 : 0);
			}
			else
			{
				refDispatcherList_0._StateDispatcher += refDispatcherList_1.workerDispatcher;
			}
			if (MapDefinition(refDispatcherList_0))
			{
				refDispatcherList_1._StateDispatcher = ((refDispatcherList_1._StateDispatcher == 0) ? 1 : 0);
			}
			else
			{
				refDispatcherList_1._StateDispatcher -= refDispatcherList_0.workerDispatcher;
			}
		}
		PolyFillType modelDispatcher;
		PolyFillType modelDispatcher2;
		if (refDispatcherList_0._EventDispatcher == PolyType.ptSubject)
		{
			modelDispatcher = m_ModelDispatcher;
			modelDispatcher2 = composerDispatcher;
		}
		else
		{
			modelDispatcher = composerDispatcher;
			modelDispatcher2 = m_ModelDispatcher;
		}
		PolyFillType modelDispatcher3;
		PolyFillType modelDispatcher4;
		if (refDispatcherList_1._EventDispatcher == PolyType.ptSubject)
		{
			modelDispatcher3 = m_ModelDispatcher;
			modelDispatcher4 = composerDispatcher;
		}
		else
		{
			modelDispatcher3 = composerDispatcher;
			modelDispatcher4 = m_ModelDispatcher;
		}
		if (1 == 0)
		{
		}
		int num5 = modelDispatcher switch
		{
			PolyFillType.pftNegative => -refDispatcherList_0.accountDispatcher, 
			PolyFillType.pftPositive => refDispatcherList_0.accountDispatcher, 
			_ => Math.Abs(refDispatcherList_0.accountDispatcher), 
		};
		if (1 == 0)
		{
		}
		int num = num5;
		if (1 == 0)
		{
		}
		num5 = modelDispatcher3 switch
		{
			PolyFillType.pftNegative => -refDispatcherList_1.accountDispatcher, 
			PolyFillType.pftPositive => refDispatcherList_1.accountDispatcher, 
			_ => Math.Abs(refDispatcherList_1.accountDispatcher), 
		};
		if (1 == 0)
		{
		}
		int num2 = num5;
		if (flag3 && flag4)
		{
			if (!flag && !flag2 && (num == 0 || num == 1) && (num2 == 0 || num2 == 1) && (refDispatcherList_0._EventDispatcher == refDispatcherList_1._EventDispatcher || _DescriptorDispatcher == ClipType.ctXor))
			{
				CountVal(refDispatcherList_0, intPoint_0);
				CountVal(refDispatcherList_1, intPoint_0);
				ViewVal(refDispatcherList_0, refDispatcherList_1);
				ValidateVal(refDispatcherList_0, refDispatcherList_1);
			}
			else
			{
				RegisterDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
			}
		}
		else if (flag3)
		{
			if (num2 == 0 || num2 == 1)
			{
				CountVal(refDispatcherList_0, intPoint_0);
				ViewVal(refDispatcherList_0, refDispatcherList_1);
				ValidateVal(refDispatcherList_0, refDispatcherList_1);
			}
		}
		else if (flag4)
		{
			if (num == 0 || num == 1)
			{
				CountVal(refDispatcherList_1, intPoint_0);
				ViewVal(refDispatcherList_0, refDispatcherList_1);
				ValidateVal(refDispatcherList_0, refDispatcherList_1);
			}
		}
		else if ((num == 0 || num == 1) && (num2 == 0 || num2 == 1) && !flag && !flag2)
		{
			if (1 == 0)
			{
			}
			num5 = modelDispatcher2 switch
			{
				PolyFillType.pftNegative => -refDispatcherList_0._StateDispatcher, 
				PolyFillType.pftPositive => refDispatcherList_0._StateDispatcher, 
				_ => Math.Abs(refDispatcherList_0._StateDispatcher), 
			};
			if (1 == 0)
			{
			}
			long num3 = num5;
			if (1 == 0)
			{
			}
			num5 = modelDispatcher4 switch
			{
				PolyFillType.pftNegative => -refDispatcherList_1._StateDispatcher, 
				PolyFillType.pftPositive => refDispatcherList_1._StateDispatcher, 
				_ => Math.Abs(refDispatcherList_1._StateDispatcher), 
			};
			if (1 == 0)
			{
			}
			long num4 = num5;
			if (refDispatcherList_0._EventDispatcher == refDispatcherList_1._EventDispatcher)
			{
				if (num == 1 && num2 == 1)
				{
					switch (_DescriptorDispatcher)
					{
					case ClipType.ctIntersection:
						if (num3 > 0 && num4 > 0)
						{
							ManageDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
						}
						break;
					case ClipType.ctUnion:
						if (num3 <= 0 && num4 <= 0)
						{
							ManageDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
						}
						break;
					case ClipType.ctDifference:
						if ((refDispatcherList_0._EventDispatcher == PolyType.ptClip && num3 > 0 && num4 > 0) || (refDispatcherList_0._EventDispatcher == PolyType.ptSubject && num3 <= 0 && num4 <= 0))
						{
							ManageDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
						}
						break;
					case ClipType.ctXor:
						ManageDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
						break;
					}
				}
				else
				{
					ViewVal(refDispatcherList_0, refDispatcherList_1);
				}
			}
			else
			{
				ManageDefinition(refDispatcherList_0, refDispatcherList_1, intPoint_0);
			}
		}
		if (flag != flag2 && ((flag && refDispatcherList_0.m_AuthenticationDispatcher >= 0) || (flag2 && refDispatcherList_1.m_AuthenticationDispatcher >= 0)))
		{
			ViewVal(refDispatcherList_0, refDispatcherList_1);
			ValidateVal(refDispatcherList_0, refDispatcherList_1);
		}
		if (flag)
		{
			GetVal(refDispatcherList_0);
		}
		if (flag2)
		{
			GetVal(refDispatcherList_1);
		}
	}

	private void GetVal(RefDispatcherList refDispatcherList_0)
	{
		RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher;
		RefDispatcherList mapperDispatcher = refDispatcherList_0.mapperDispatcher;
		if (managerDispatcher != null || mapperDispatcher != null || refDispatcherList_0 == _TaskDispatcher)
		{
			if (managerDispatcher == null)
			{
				_TaskDispatcher = mapperDispatcher;
			}
			else
			{
				managerDispatcher.mapperDispatcher = mapperDispatcher;
			}
			if (mapperDispatcher != null)
			{
				mapperDispatcher._ManagerDispatcher = managerDispatcher;
			}
			refDispatcherList_0.mapperDispatcher = null;
			refDispatcherList_0._ManagerDispatcher = null;
		}
	}

	private void WriteVal(RefDispatcherList refDispatcherList_0)
	{
		RefDispatcherList producerDispatcher = refDispatcherList_0.m_ProducerDispatcher;
		RefDispatcherList getterDispatcher = refDispatcherList_0._GetterDispatcher;
		if (producerDispatcher != null || getterDispatcher != null || refDispatcherList_0 == _FilterDispatcher)
		{
			if (producerDispatcher == null)
			{
				_FilterDispatcher = getterDispatcher;
			}
			else
			{
				producerDispatcher._GetterDispatcher = getterDispatcher;
			}
			if (getterDispatcher != null)
			{
				getterDispatcher.m_ProducerDispatcher = producerDispatcher;
			}
			refDispatcherList_0._GetterDispatcher = null;
			refDispatcherList_0.m_ProducerDispatcher = null;
		}
	}

	private void NewVal(ref RefDispatcherList refDispatcherList_0)
	{
		if (refDispatcherList_0._HelperDispatcher == null)
		{
			throw new InfoListenerManager("UpdateEdgeIntoAEL: invalid call");
		}
		RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher;
		RefDispatcherList mapperDispatcher = refDispatcherList_0.mapperDispatcher;
		refDispatcherList_0._HelperDispatcher.m_AuthenticationDispatcher = refDispatcherList_0.m_AuthenticationDispatcher;
		if (managerDispatcher == null)
		{
			_TaskDispatcher = refDispatcherList_0._HelperDispatcher;
		}
		else
		{
			managerDispatcher.mapperDispatcher = refDispatcherList_0._HelperDispatcher;
		}
		if (mapperDispatcher != null)
		{
			mapperDispatcher._ManagerDispatcher = refDispatcherList_0._HelperDispatcher;
		}
		refDispatcherList_0._HelperDispatcher.globalDispatcher = refDispatcherList_0.globalDispatcher;
		refDispatcherList_0._HelperDispatcher.workerDispatcher = refDispatcherList_0.workerDispatcher;
		refDispatcherList_0._HelperDispatcher.accountDispatcher = refDispatcherList_0.accountDispatcher;
		refDispatcherList_0._HelperDispatcher._StateDispatcher = refDispatcherList_0._StateDispatcher;
		refDispatcherList_0 = refDispatcherList_0._HelperDispatcher;
		refDispatcherList_0.roleDispatcher = refDispatcherList_0.m_InitializerDispatcher;
		refDispatcherList_0._ManagerDispatcher = managerDispatcher;
		refDispatcherList_0.mapperDispatcher = mapperDispatcher;
		if (!ClipperBase.QueryVal(refDispatcherList_0))
		{
			ListDefinition(refDispatcherList_0.Top.Y);
		}
	}

	private void PushVal(bool bool_0)
	{
		for (RefDispatcherList filterDispatcher = _FilterDispatcher; filterDispatcher != null; filterDispatcher = _FilterDispatcher)
		{
			WriteVal(filterDispatcher);
			ExcludeVal(filterDispatcher, bool_0);
		}
	}

	private void InvokeVal(RefDispatcherList refDispatcherList_0, out Direction direction_0, out long long_0, out long long_1)
	{
		if (refDispatcherList_0.m_InitializerDispatcher.X < refDispatcherList_0.Top.X)
		{
			long_0 = refDispatcherList_0.m_InitializerDispatcher.X;
			long_1 = refDispatcherList_0.Top.X;
			direction_0 = Direction.dLeftToRight;
		}
		else
		{
			long_0 = refDispatcherList_0.Top.X;
			long_1 = refDispatcherList_0.m_InitializerDispatcher.X;
			direction_0 = Direction.dRightToLeft;
		}
	}

	private void SetupVal(RefDispatcherList refDispatcherList_0, bool bool_0)
	{
		PredicateThreadBridge predicateThreadBridge = _ReponseDispatcher[refDispatcherList_0.m_AuthenticationDispatcher]._BaseDispatcher;
		if (refDispatcherList_0.globalDispatcher != 0)
		{
			predicateThreadBridge = predicateThreadBridge._RulesDispatcher;
		}
		if (bool_0)
		{
			if (predicateThreadBridge.m_ParamDispatcher == refDispatcherList_0.Top)
			{
				PublishDefinition(predicateThreadBridge, refDispatcherList_0.m_InitializerDispatcher);
			}
			else
			{
				PublishDefinition(predicateThreadBridge, refDispatcherList_0.Top);
			}
		}
	}

	private void ExcludeVal(RefDispatcherList refDispatcherList_0, bool bool_0)
	{
		InvokeVal(refDispatcherList_0, out var direction_, out var long_, out var long_2);
		RefDispatcherList refDispatcherList = refDispatcherList_0;
		RefDispatcherList refDispatcherList2 = null;
		while (refDispatcherList._HelperDispatcher != null && ClipperBase.QueryVal(refDispatcherList._HelperDispatcher))
		{
			refDispatcherList = refDispatcherList._HelperDispatcher;
		}
		if (refDispatcherList._HelperDispatcher == null)
		{
			refDispatcherList2 = InitVal(refDispatcherList);
		}
		while (true)
		{
			bool flag = refDispatcherList_0 == refDispatcherList;
			RefDispatcherList refDispatcherList3 = IncludeVal(refDispatcherList_0, direction_);
			while (refDispatcherList3 != null && (refDispatcherList3.roleDispatcher.X != refDispatcherList_0.Top.X || refDispatcherList_0._HelperDispatcher == null || refDispatcherList3.m_AttributeDispatcher >= refDispatcherList_0._HelperDispatcher.m_AttributeDispatcher))
			{
				RefDispatcherList refDispatcherList4 = IncludeVal(refDispatcherList3, direction_);
				if ((direction_ == Direction.dLeftToRight && refDispatcherList3.roleDispatcher.X <= long_2) || (direction_ == Direction.dRightToLeft && refDispatcherList3.roleDispatcher.X >= long_))
				{
					if (refDispatcherList_0.m_AuthenticationDispatcher >= 0 && refDispatcherList_0.workerDispatcher != 0)
					{
						SetupVal(refDispatcherList_0, bool_0);
					}
					if (refDispatcherList3 == refDispatcherList2 && flag)
					{
						if (direction_ == Direction.dLeftToRight)
						{
							LoginVal(refDispatcherList_0, refDispatcherList3, refDispatcherList3.Top);
						}
						else
						{
							LoginVal(refDispatcherList3, refDispatcherList_0, refDispatcherList3.Top);
						}
						if (refDispatcherList2.m_AuthenticationDispatcher < 0)
						{
							return;
						}
						throw new InfoListenerManager("ProcessHorizontal error");
					}
					if (direction_ == Direction.dLeftToRight)
					{
						LoginVal(intPoint_0: new IntPoint(refDispatcherList3.roleDispatcher.X, refDispatcherList_0.roleDispatcher.Y), refDispatcherList_0: refDispatcherList_0, refDispatcherList_1: refDispatcherList3, bool_0: true);
					}
					else
					{
						LoginVal(intPoint_0: new IntPoint(refDispatcherList3.roleDispatcher.X, refDispatcherList_0.roleDispatcher.Y), refDispatcherList_0: refDispatcherList3, refDispatcherList_1: refDispatcherList_0, bool_0: true);
					}
					CollectDefinition(refDispatcherList_0, refDispatcherList3);
				}
				else if ((direction_ == Direction.dLeftToRight && refDispatcherList3.roleDispatcher.X >= long_2) || (direction_ == Direction.dRightToLeft && refDispatcherList3.roleDispatcher.X <= long_))
				{
					break;
				}
				refDispatcherList3 = refDispatcherList4;
			}
			if (refDispatcherList_0.m_AuthenticationDispatcher >= 0 && refDispatcherList_0.workerDispatcher != 0)
			{
				SetupVal(refDispatcherList_0, bool_0);
			}
			if (refDispatcherList_0._HelperDispatcher == null || !ClipperBase.QueryVal(refDispatcherList_0._HelperDispatcher))
			{
				break;
			}
			NewVal(ref refDispatcherList_0);
			if (refDispatcherList_0.m_AuthenticationDispatcher >= 0)
			{
				CountVal(refDispatcherList_0, refDispatcherList_0.m_InitializerDispatcher);
			}
			InvokeVal(refDispatcherList_0, out direction_, out long_, out long_2);
		}
		if (refDispatcherList_0._HelperDispatcher == null)
		{
			if (refDispatcherList2 == null)
			{
				if (refDispatcherList_0.m_AuthenticationDispatcher >= 0)
				{
					CountVal(refDispatcherList_0, refDispatcherList_0.Top);
				}
				GetVal(refDispatcherList_0);
				return;
			}
			if (refDispatcherList2.m_AuthenticationDispatcher < 0)
			{
				GetVal(refDispatcherList_0);
				GetVal(refDispatcherList2);
				return;
			}
			if (direction_ == Direction.dLeftToRight)
			{
				LoginVal(refDispatcherList_0, refDispatcherList2, refDispatcherList_0.Top);
			}
			else
			{
				LoginVal(refDispatcherList2, refDispatcherList_0, refDispatcherList_0.Top);
			}
			if (refDispatcherList2.m_AuthenticationDispatcher < 0)
			{
				return;
			}
			throw new InfoListenerManager("ProcessHorizontal error");
		}
		if (refDispatcherList_0.m_AuthenticationDispatcher < 0)
		{
			NewVal(ref refDispatcherList_0);
			return;
		}
		PredicateThreadBridge predicateThreadBridge_ = CountVal(refDispatcherList_0, refDispatcherList_0.Top);
		NewVal(ref refDispatcherList_0);
		if (refDispatcherList_0.workerDispatcher != 0)
		{
			RefDispatcherList managerDispatcher = refDispatcherList_0._ManagerDispatcher;
			RefDispatcherList mapperDispatcher = refDispatcherList_0.mapperDispatcher;
			if (managerDispatcher != null && managerDispatcher.roleDispatcher.X == refDispatcherList_0.m_InitializerDispatcher.X && managerDispatcher.roleDispatcher.Y == refDispatcherList_0.m_InitializerDispatcher.Y && managerDispatcher.workerDispatcher != 0 && managerDispatcher.m_AuthenticationDispatcher >= 0 && managerDispatcher.roleDispatcher.Y > managerDispatcher.Top.Y && ClipperBase.CalcVal(refDispatcherList_0, managerDispatcher, _StrategyDispatcher))
			{
				PredicateThreadBridge predicateThreadBridge_2 = CountVal(managerDispatcher, refDispatcherList_0.m_InitializerDispatcher);
				DefineDefinition(predicateThreadBridge_, predicateThreadBridge_2, refDispatcherList_0.Top);
			}
			else if (mapperDispatcher != null && mapperDispatcher.roleDispatcher.X == refDispatcherList_0.m_InitializerDispatcher.X && mapperDispatcher.roleDispatcher.Y == refDispatcherList_0.m_InitializerDispatcher.Y && mapperDispatcher.workerDispatcher != 0 && mapperDispatcher.m_AuthenticationDispatcher >= 0 && mapperDispatcher.roleDispatcher.Y > mapperDispatcher.Top.Y && ClipperBase.CalcVal(refDispatcherList_0, mapperDispatcher, _StrategyDispatcher))
			{
				PredicateThreadBridge predicateThreadBridge_3 = CountVal(mapperDispatcher, refDispatcherList_0.m_InitializerDispatcher);
				DefineDefinition(predicateThreadBridge_, predicateThreadBridge_3, refDispatcherList_0.Top);
			}
		}
	}

	private RefDispatcherList IncludeVal(RefDispatcherList refDispatcherList_0, Direction direction_0)
	{
		if (direction_0 == Direction.dLeftToRight)
		{
			return refDispatcherList_0.mapperDispatcher;
		}
		return refDispatcherList_0._ManagerDispatcher;
	}

	private bool SearchVal(RefDispatcherList refDispatcherList_0)
	{
		if (refDispatcherList_0 != null && refDispatcherList_0.infoDispatcher._HelperDispatcher != refDispatcherList_0)
		{
			return refDispatcherList_0._ParamsDispatcher._HelperDispatcher != refDispatcherList_0;
		}
		return false;
	}

	private bool EnableVal(RefDispatcherList refDispatcherList_0, double double_0)
	{
		if (refDispatcherList_0 != null && (double)refDispatcherList_0.Top.Y == double_0)
		{
			return refDispatcherList_0._HelperDispatcher == null;
		}
		return false;
	}

	private bool ChangeVal(RefDispatcherList refDispatcherList_0, double double_0)
	{
		if ((double)refDispatcherList_0.Top.Y == double_0)
		{
			return refDispatcherList_0._HelperDispatcher != null;
		}
		return false;
	}

	private RefDispatcherList InitVal(RefDispatcherList refDispatcherList_0)
	{
		RefDispatcherList refDispatcherList = null;
		if (refDispatcherList_0._ParamsDispatcher.Top == refDispatcherList_0.Top && refDispatcherList_0._ParamsDispatcher._HelperDispatcher == null)
		{
			refDispatcherList = refDispatcherList_0._ParamsDispatcher;
		}
		else if (refDispatcherList_0.infoDispatcher.Top == refDispatcherList_0.Top && refDispatcherList_0.infoDispatcher._HelperDispatcher == null)
		{
			refDispatcherList = refDispatcherList_0.infoDispatcher;
		}
		if (refDispatcherList != null && (refDispatcherList.m_AuthenticationDispatcher == -2 || (refDispatcherList.mapperDispatcher == refDispatcherList._ManagerDispatcher && !ClipperBase.QueryVal(refDispatcherList))))
		{
			return null;
		}
		return refDispatcherList;
	}

	private bool CheckVal(long long_0, long long_1)
	{
		if (_TaskDispatcher == null)
		{
			return true;
		}
		try
		{
			ConcatVal(long_0, long_1);
			if (_TestsDispatcher.Count == 0)
			{
				return true;
			}
			if (_TestsDispatcher.Count != 1 && !FindVal())
			{
				return false;
			}
			SetVal();
		}
		catch
		{
			_FilterDispatcher = null;
			_TestsDispatcher.Clear();
			throw new InfoListenerManager("ProcessIntersections error");
		}
		_FilterDispatcher = null;
		return true;
	}

	private void ConcatVal(long long_0, long long_1)
	{
		if (_TaskDispatcher == null)
		{
			return;
		}
		for (RefDispatcherList refDispatcherList = (_FilterDispatcher = _TaskDispatcher); refDispatcherList != null; refDispatcherList = refDispatcherList.mapperDispatcher)
		{
			refDispatcherList.m_ProducerDispatcher = refDispatcherList._ManagerDispatcher;
			refDispatcherList._GetterDispatcher = refDispatcherList.mapperDispatcher;
			refDispatcherList.roleDispatcher.X = FillVal(refDispatcherList, long_1);
		}
		bool flag = true;
		while (flag && _FilterDispatcher != null)
		{
			flag = false;
			RefDispatcherList refDispatcherList2 = _FilterDispatcher;
			while (refDispatcherList2._GetterDispatcher != null)
			{
				RefDispatcherList getterDispatcher = refDispatcherList2._GetterDispatcher;
				if (refDispatcherList2.roleDispatcher.X <= getterDispatcher.roleDispatcher.X)
				{
					refDispatcherList2 = getterDispatcher;
					continue;
				}
				if (CalculateVal(refDispatcherList2, getterDispatcher, out var intPoint_) || refDispatcherList2.roleDispatcher.X <= getterDispatcher.roleDispatcher.X + 1)
				{
					if (intPoint_.Y > long_0)
					{
						intPoint_.Y = long_0;
						if (Math.Abs(refDispatcherList2.m_AttributeDispatcher) <= Math.Abs(getterDispatcher.m_AttributeDispatcher))
						{
							intPoint_.X = FillVal(refDispatcherList2, long_0);
						}
						else
						{
							intPoint_.X = FillVal(getterDispatcher, long_0);
						}
					}
					IntersectNode intersectNode = new IntersectNode();
					intersectNode.itemDispatcher = refDispatcherList2;
					intersectNode._SetterDispatcher = getterDispatcher;
					intersectNode.m_CreatorDispatcher = intPoint_;
					_TestsDispatcher.Add(intersectNode);
					OrderDefinition(refDispatcherList2, getterDispatcher);
					flag = true;
					continue;
				}
				throw new InfoListenerManager("Intersection error");
			}
			if (refDispatcherList2.m_ProducerDispatcher == null)
			{
				break;
			}
			refDispatcherList2.m_ProducerDispatcher._GetterDispatcher = null;
		}
		_FilterDispatcher = null;
	}

	private bool InterruptVal(IntersectNode intersectNode_0)
	{
		if (intersectNode_0.itemDispatcher._GetterDispatcher == intersectNode_0._SetterDispatcher)
		{
			return true;
		}
		return intersectNode_0.itemDispatcher.m_ProducerDispatcher == intersectNode_0._SetterDispatcher;
	}

	private static int RemoveVal(IntersectNode intersectNode_0, IntersectNode intersectNode_1)
	{
		return (int)(intersectNode_1.m_CreatorDispatcher.Y - intersectNode_0.m_CreatorDispatcher.Y);
	}

	private bool FindVal()
	{
		_TestsDispatcher.Sort(interpreterDispatcher);
		ForgotDefinition();
		int count = _TestsDispatcher.Count;
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				if (!InterruptVal(_TestsDispatcher[num]))
				{
					int i;
					for (i = num + 1; i < count && !InterruptVal(_TestsDispatcher[i]); i++)
					{
					}
					if (i == count)
					{
						break;
					}
					IntersectNode value = _TestsDispatcher[num];
					_TestsDispatcher[num] = _TestsDispatcher[i];
					_TestsDispatcher[i] = value;
				}
				OrderDefinition(_TestsDispatcher[num].itemDispatcher, _TestsDispatcher[num]._SetterDispatcher);
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private void SetVal()
	{
		for (int i = 0; i < _TestsDispatcher.Count; i++)
		{
			IntersectNode intersectNode = _TestsDispatcher[i];
			LoginVal(intersectNode.itemDispatcher, intersectNode._SetterDispatcher, intersectNode.m_CreatorDispatcher, bool_0: true);
			CollectDefinition(intersectNode.itemDispatcher, intersectNode._SetterDispatcher);
		}
		_TestsDispatcher.Clear();
	}

	internal static long Round(double double_0)
	{
		if (double_0 < 0.0)
		{
			return (long)(double_0 - 0.5);
		}
		return (long)(double_0 + 0.5);
	}

	private static long FillVal(RefDispatcherList refDispatcherList_0, long long_0)
	{
		if (long_0 == refDispatcherList_0.Top.Y)
		{
			return refDispatcherList_0.Top.X;
		}
		return refDispatcherList_0.m_InitializerDispatcher.X + Round(refDispatcherList_0.m_AttributeDispatcher * (double)(long_0 - refDispatcherList_0.m_InitializerDispatcher.Y));
	}

	private bool CalculateVal(RefDispatcherList refDispatcherList_0, RefDispatcherList refDispatcherList_1, out IntPoint intPoint_0)
	{
		intPoint_0 = default(IntPoint);
		if (!ClipperBase.CalcVal(refDispatcherList_0, refDispatcherList_1, _StrategyDispatcher) && refDispatcherList_0.m_AttributeDispatcher != refDispatcherList_1.m_AttributeDispatcher)
		{
			if (refDispatcherList_0._FactoryDispatcher.X == 0)
			{
				intPoint_0.X = refDispatcherList_0.m_InitializerDispatcher.X;
				if (ClipperBase.QueryVal(refDispatcherList_1))
				{
					intPoint_0.Y = refDispatcherList_1.m_InitializerDispatcher.Y;
				}
				else
				{
					double num = (double)refDispatcherList_1.m_InitializerDispatcher.Y - (double)refDispatcherList_1.m_InitializerDispatcher.X / refDispatcherList_1.m_AttributeDispatcher;
					intPoint_0.Y = Round((double)intPoint_0.X / refDispatcherList_1.m_AttributeDispatcher + num);
				}
			}
			else if (refDispatcherList_1._FactoryDispatcher.X == 0)
			{
				intPoint_0.X = refDispatcherList_1.m_InitializerDispatcher.X;
				if (ClipperBase.QueryVal(refDispatcherList_0))
				{
					intPoint_0.Y = refDispatcherList_0.m_InitializerDispatcher.Y;
				}
				else
				{
					double num2 = (double)refDispatcherList_0.m_InitializerDispatcher.Y - (double)refDispatcherList_0.m_InitializerDispatcher.X / refDispatcherList_0.m_AttributeDispatcher;
					intPoint_0.Y = Round((double)intPoint_0.X / refDispatcherList_0.m_AttributeDispatcher + num2);
				}
			}
			else
			{
				double num3 = (double)refDispatcherList_0.m_InitializerDispatcher.X - (double)refDispatcherList_0.m_InitializerDispatcher.Y * refDispatcherList_0.m_AttributeDispatcher;
				double num4 = (double)refDispatcherList_1.m_InitializerDispatcher.X - (double)refDispatcherList_1.m_InitializerDispatcher.Y * refDispatcherList_1.m_AttributeDispatcher;
				double num5 = (num4 - num3) / (refDispatcherList_0.m_AttributeDispatcher - refDispatcherList_1.m_AttributeDispatcher);
				intPoint_0.Y = Round(num5);
				if (Math.Abs(refDispatcherList_0.m_AttributeDispatcher) < Math.Abs(refDispatcherList_1.m_AttributeDispatcher))
				{
					intPoint_0.X = Round(refDispatcherList_0.m_AttributeDispatcher * num5 + num3);
				}
				else
				{
					intPoint_0.X = Round(refDispatcherList_1.m_AttributeDispatcher * num5 + num4);
				}
			}
			if (intPoint_0.Y < refDispatcherList_0.Top.Y || intPoint_0.Y < refDispatcherList_1.Top.Y)
			{
				if (refDispatcherList_0.Top.Y <= refDispatcherList_1.Top.Y)
				{
					intPoint_0.Y = refDispatcherList_1.Top.Y;
				}
				else
				{
					intPoint_0.Y = refDispatcherList_0.Top.Y;
				}
				if (Math.Abs(refDispatcherList_0.m_AttributeDispatcher) < Math.Abs(refDispatcherList_1.m_AttributeDispatcher))
				{
					intPoint_0.X = FillVal(refDispatcherList_0, intPoint_0.Y);
				}
				else
				{
					intPoint_0.X = FillVal(refDispatcherList_1, intPoint_0.Y);
				}
			}
			return true;
		}
		if (refDispatcherList_1.m_InitializerDispatcher.Y <= refDispatcherList_0.m_InitializerDispatcher.Y)
		{
			intPoint_0 = refDispatcherList_0.m_InitializerDispatcher;
		}
		else
		{
			intPoint_0 = refDispatcherList_1.m_InitializerDispatcher;
		}
		return false;
	}

	private void PopVal(long long_0)
	{
		RefDispatcherList refDispatcherList_ = _TaskDispatcher;
		while (refDispatcherList_ != null)
		{
			bool flag;
			if (flag = EnableVal(refDispatcherList_, long_0))
			{
				RefDispatcherList refDispatcherList = InitVal(refDispatcherList_);
				flag = refDispatcherList == null || !ClipperBase.QueryVal(refDispatcherList);
			}
			if (flag)
			{
				RefDispatcherList managerDispatcher = refDispatcherList_._ManagerDispatcher;
				InstantiateVal(refDispatcherList_);
				refDispatcherList_ = ((managerDispatcher == null) ? _TaskDispatcher : managerDispatcher.mapperDispatcher);
				continue;
			}
			if (ChangeVal(refDispatcherList_, long_0) && ClipperBase.QueryVal(refDispatcherList_._HelperDispatcher))
			{
				NewVal(ref refDispatcherList_);
				if (refDispatcherList_.m_AuthenticationDispatcher >= 0)
				{
					CountVal(refDispatcherList_, refDispatcherList_.m_InitializerDispatcher);
				}
				FlushDefinition(refDispatcherList_);
			}
			else
			{
				refDispatcherList_.roleDispatcher.X = FillVal(refDispatcherList_, long_0);
				refDispatcherList_.roleDispatcher.Y = long_0;
			}
			if (StrictlySimple)
			{
				RefDispatcherList managerDispatcher2 = refDispatcherList_._ManagerDispatcher;
				if (refDispatcherList_.m_AuthenticationDispatcher >= 0 && refDispatcherList_.workerDispatcher != 0 && managerDispatcher2 != null && managerDispatcher2.m_AuthenticationDispatcher >= 0 && managerDispatcher2.roleDispatcher.X == refDispatcherList_.roleDispatcher.X && managerDispatcher2.workerDispatcher != 0)
				{
					PredicateThreadBridge predicateThreadBridge_ = CountVal(managerDispatcher2, refDispatcherList_.roleDispatcher);
					PredicateThreadBridge predicateThreadBridge_2 = CountVal(refDispatcherList_, refDispatcherList_.roleDispatcher);
					DefineDefinition(predicateThreadBridge_, predicateThreadBridge_2, refDispatcherList_.roleDispatcher);
				}
			}
			refDispatcherList_ = refDispatcherList_.mapperDispatcher;
		}
		PushVal(bool_0: true);
		for (refDispatcherList_ = _TaskDispatcher; refDispatcherList_ != null; refDispatcherList_ = refDispatcherList_.mapperDispatcher)
		{
			if (ChangeVal(refDispatcherList_, long_0))
			{
				PredicateThreadBridge predicateThreadBridge = null;
				if (refDispatcherList_.m_AuthenticationDispatcher >= 0)
				{
					predicateThreadBridge = CountVal(refDispatcherList_, refDispatcherList_.Top);
				}
				NewVal(ref refDispatcherList_);
				RefDispatcherList managerDispatcher3 = refDispatcherList_._ManagerDispatcher;
				RefDispatcherList mapperDispatcher = refDispatcherList_.mapperDispatcher;
				if (managerDispatcher3 != null && managerDispatcher3.roleDispatcher.X == refDispatcherList_.m_InitializerDispatcher.X && managerDispatcher3.roleDispatcher.Y == refDispatcherList_.m_InitializerDispatcher.Y && predicateThreadBridge != null && managerDispatcher3.m_AuthenticationDispatcher >= 0 && managerDispatcher3.roleDispatcher.Y > managerDispatcher3.Top.Y && ClipperBase.CalcVal(refDispatcherList_, managerDispatcher3, _StrategyDispatcher) && refDispatcherList_.workerDispatcher != 0 && managerDispatcher3.workerDispatcher != 0)
				{
					PredicateThreadBridge predicateThreadBridge_3 = CountVal(managerDispatcher3, refDispatcherList_.m_InitializerDispatcher);
					DefineDefinition(predicateThreadBridge, predicateThreadBridge_3, refDispatcherList_.Top);
				}
				else if (mapperDispatcher != null && mapperDispatcher.roleDispatcher.X == refDispatcherList_.m_InitializerDispatcher.X && mapperDispatcher.roleDispatcher.Y == refDispatcherList_.m_InitializerDispatcher.Y && predicateThreadBridge != null && mapperDispatcher.m_AuthenticationDispatcher >= 0 && mapperDispatcher.roleDispatcher.Y > mapperDispatcher.Top.Y && ClipperBase.CalcVal(refDispatcherList_, mapperDispatcher, _StrategyDispatcher) && refDispatcherList_.workerDispatcher != 0 && mapperDispatcher.workerDispatcher != 0)
				{
					PredicateThreadBridge predicateThreadBridge_4 = CountVal(mapperDispatcher, refDispatcherList_.m_InitializerDispatcher);
					DefineDefinition(predicateThreadBridge, predicateThreadBridge_4, refDispatcherList_.Top);
				}
			}
		}
	}

	private void InstantiateVal(RefDispatcherList refDispatcherList_0)
	{
		RefDispatcherList refDispatcherList = InitVal(refDispatcherList_0);
		if (refDispatcherList == null)
		{
			if (refDispatcherList_0.m_AuthenticationDispatcher >= 0)
			{
				CountVal(refDispatcherList_0, refDispatcherList_0.Top);
			}
			GetVal(refDispatcherList_0);
			return;
		}
		RefDispatcherList mapperDispatcher = refDispatcherList_0.mapperDispatcher;
		while (mapperDispatcher != null && mapperDispatcher != refDispatcherList)
		{
			LoginVal(refDispatcherList_0, mapperDispatcher, refDispatcherList_0.Top, bool_0: true);
			CollectDefinition(refDispatcherList_0, mapperDispatcher);
			mapperDispatcher = refDispatcherList_0.mapperDispatcher;
		}
		if (refDispatcherList_0.m_AuthenticationDispatcher == -1 && refDispatcherList.m_AuthenticationDispatcher == -1)
		{
			GetVal(refDispatcherList_0);
			GetVal(refDispatcherList);
			return;
		}
		if (refDispatcherList_0.m_AuthenticationDispatcher < 0 || refDispatcherList.m_AuthenticationDispatcher < 0)
		{
			throw new InfoListenerManager("DoMaxima error");
		}
		LoginVal(refDispatcherList_0, refDispatcherList, refDispatcherList_0.Top);
	}

	public static void ReversePaths(List<List<IntPoint>> list_0)
	{
		foreach (List<IntPoint> item in list_0)
		{
			item.Reverse();
		}
	}

	public static bool Orientation(List<IntPoint> list_0)
	{
		return Area(list_0) >= 0.0;
	}

	private int CreateVal(PredicateThreadBridge predicateThreadBridge_0)
	{
		if (predicateThreadBridge_0 == null)
		{
			return 0;
		}
		int num = 0;
		PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
		do
		{
			num++;
			predicateThreadBridge = predicateThreadBridge.pageDispatcher;
		}
		while (predicateThreadBridge != predicateThreadBridge_0);
		return num;
	}

	private void CompareVal(List<List<IntPoint>> list_0)
	{
		list_0.Clear();
		list_0.Capacity = _ReponseDispatcher.Count;
		for (int i = 0; i < _ReponseDispatcher.Count; i++)
		{
			RulesConfigObject rulesConfigObject = _ReponseDispatcher[i];
			if (rulesConfigObject._BaseDispatcher == null)
			{
				continue;
			}
			PredicateThreadBridge rulesDispatcher = rulesConfigObject._BaseDispatcher._RulesDispatcher;
			int num = CreateVal(rulesDispatcher);
			if (num >= 2)
			{
				List<IntPoint> list = new List<IntPoint>(num);
				for (int j = 0; j < num; j++)
				{
					list.Add(rulesDispatcher.m_ParamDispatcher);
					rulesDispatcher = rulesDispatcher._RulesDispatcher;
				}
				list_0.Add(list);
			}
		}
	}

	private void ReadVal(PolyTree polyTree_0)
	{
		polyTree_0.Clear();
		polyTree_0._ProductDispatcher.Capacity = _ReponseDispatcher.Count;
		for (int i = 0; i < _ReponseDispatcher.Count; i++)
		{
			RulesConfigObject rulesConfigObject = _ReponseDispatcher[i];
			int num = CreateVal(rulesConfigObject._BaseDispatcher);
			if ((!rulesConfigObject.m_SystemDispatcher || num >= 2) && (rulesConfigObject.m_SystemDispatcher || num >= 3))
			{
				ResolveDefinition(rulesConfigObject);
				PolyNode polyNode = new PolyNode();
				polyTree_0._ProductDispatcher.Add(polyNode);
				rulesConfigObject.m_BroadcasterDispatcher = polyNode;
				polyNode.m_PrinterDispatcher.Capacity = num;
				PredicateThreadBridge rulesDispatcher = rulesConfigObject._BaseDispatcher._RulesDispatcher;
				for (int j = 0; j < num; j++)
				{
					polyNode.m_PrinterDispatcher.Add(rulesDispatcher.m_ParamDispatcher);
					rulesDispatcher = rulesDispatcher._RulesDispatcher;
				}
			}
		}
		polyTree_0.interceptorDispatcher.Capacity = _ReponseDispatcher.Count;
		for (int k = 0; k < _ReponseDispatcher.Count; k++)
		{
			RulesConfigObject rulesConfigObject2 = _ReponseDispatcher[k];
			if (rulesConfigObject2.m_BroadcasterDispatcher != null)
			{
				if (rulesConfigObject2.m_SystemDispatcher)
				{
					rulesConfigObject2.m_BroadcasterDispatcher.IsOpen = true;
					polyTree_0.ValidateWrapper(rulesConfigObject2.m_BroadcasterDispatcher);
				}
				else if (rulesConfigObject2.candidateDispatcher != null && rulesConfigObject2.candidateDispatcher.m_BroadcasterDispatcher != null)
				{
					rulesConfigObject2.candidateDispatcher.m_BroadcasterDispatcher.ValidateWrapper(rulesConfigObject2.m_BroadcasterDispatcher);
				}
				else
				{
					polyTree_0.ValidateWrapper(rulesConfigObject2.m_BroadcasterDispatcher);
				}
			}
		}
	}

	private void DisableVal(RulesConfigObject rulesConfigObject_0)
	{
		PredicateThreadBridge predicateThreadBridge = null;
		rulesConfigObject_0.policyDispatcher = null;
		PredicateThreadBridge predicateThreadBridge2 = rulesConfigObject_0._BaseDispatcher;
		while (predicateThreadBridge2._RulesDispatcher != predicateThreadBridge2 && predicateThreadBridge2._RulesDispatcher != predicateThreadBridge2.pageDispatcher)
		{
			if (!(predicateThreadBridge2.m_ParamDispatcher == predicateThreadBridge2.pageDispatcher.m_ParamDispatcher) && !(predicateThreadBridge2.m_ParamDispatcher == predicateThreadBridge2._RulesDispatcher.m_ParamDispatcher) && (!ClipperBase.SlopesEqual(predicateThreadBridge2._RulesDispatcher.m_ParamDispatcher, predicateThreadBridge2.m_ParamDispatcher, predicateThreadBridge2.pageDispatcher.m_ParamDispatcher, _StrategyDispatcher) || (base.PreserveCollinear && ManageVal(predicateThreadBridge2._RulesDispatcher.m_ParamDispatcher, predicateThreadBridge2.m_ParamDispatcher, predicateThreadBridge2.pageDispatcher.m_ParamDispatcher))))
			{
				if (predicateThreadBridge2 == predicateThreadBridge)
				{
					rulesConfigObject_0._BaseDispatcher = predicateThreadBridge2;
					return;
				}
				if (predicateThreadBridge == null)
				{
					predicateThreadBridge = predicateThreadBridge2;
				}
				predicateThreadBridge2 = predicateThreadBridge2.pageDispatcher;
			}
			else
			{
				predicateThreadBridge = null;
				predicateThreadBridge2._RulesDispatcher.pageDispatcher = predicateThreadBridge2.pageDispatcher;
				predicateThreadBridge2.pageDispatcher._RulesDispatcher = predicateThreadBridge2._RulesDispatcher;
				predicateThreadBridge2 = predicateThreadBridge2._RulesDispatcher;
			}
		}
		PrintDefinition(predicateThreadBridge2);
		rulesConfigObject_0._BaseDispatcher = null;
	}

	private PredicateThreadBridge UpdateVal(PredicateThreadBridge predicateThreadBridge_0, bool bool_0)
	{
		PredicateThreadBridge predicateThreadBridge = new PredicateThreadBridge();
		predicateThreadBridge.m_ParamDispatcher = predicateThreadBridge_0.m_ParamDispatcher;
		predicateThreadBridge.regDispatcher = predicateThreadBridge_0.regDispatcher;
		if (bool_0)
		{
			predicateThreadBridge.pageDispatcher = predicateThreadBridge_0.pageDispatcher;
			predicateThreadBridge._RulesDispatcher = predicateThreadBridge_0;
			predicateThreadBridge_0.pageDispatcher._RulesDispatcher = predicateThreadBridge;
			predicateThreadBridge_0.pageDispatcher = predicateThreadBridge;
		}
		else
		{
			predicateThreadBridge._RulesDispatcher = predicateThreadBridge_0._RulesDispatcher;
			predicateThreadBridge.pageDispatcher = predicateThreadBridge_0;
			predicateThreadBridge_0._RulesDispatcher.pageDispatcher = predicateThreadBridge;
			predicateThreadBridge_0._RulesDispatcher = predicateThreadBridge;
		}
		return predicateThreadBridge;
	}

	private bool InsertVal(long long_0, long long_1, long long_2, long long_3, out long long_4, out long long_5)
	{
		if (long_0 < long_1)
		{
			if (long_2 < long_3)
			{
				long_4 = Math.Max(long_0, long_2);
				long_5 = Math.Min(long_1, long_3);
			}
			else
			{
				long_4 = Math.Max(long_0, long_3);
				long_5 = Math.Min(long_1, long_2);
			}
		}
		else if (long_2 < long_3)
		{
			long_4 = Math.Max(long_1, long_2);
			long_5 = Math.Min(long_0, long_3);
		}
		else
		{
			long_4 = Math.Max(long_1, long_3);
			long_5 = Math.Min(long_0, long_2);
		}
		return long_4 < long_5;
	}

	private bool PrepareVal(PredicateThreadBridge predicateThreadBridge_0, PredicateThreadBridge predicateThreadBridge_1, PredicateThreadBridge predicateThreadBridge_2, PredicateThreadBridge predicateThreadBridge_3, IntPoint intPoint_0, bool bool_0)
	{
		Direction direction = ((predicateThreadBridge_0.m_ParamDispatcher.X <= predicateThreadBridge_1.m_ParamDispatcher.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		Direction direction2 = ((predicateThreadBridge_2.m_ParamDispatcher.X <= predicateThreadBridge_3.m_ParamDispatcher.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		if (direction == direction2)
		{
			return false;
		}
		if (direction == Direction.dLeftToRight)
		{
			while (predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.X <= intPoint_0.X && predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.X >= predicateThreadBridge_0.m_ParamDispatcher.X && predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.Y == intPoint_0.Y)
			{
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
			}
			if (bool_0 && predicateThreadBridge_0.m_ParamDispatcher.X != intPoint_0.X)
			{
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
			}
			predicateThreadBridge_1 = UpdateVal(predicateThreadBridge_0, !bool_0);
			if (predicateThreadBridge_1.m_ParamDispatcher != intPoint_0)
			{
				predicateThreadBridge_0 = predicateThreadBridge_1;
				predicateThreadBridge_0.m_ParamDispatcher = intPoint_0;
				predicateThreadBridge_1 = UpdateVal(predicateThreadBridge_0, !bool_0);
			}
		}
		else
		{
			while (predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.X >= intPoint_0.X && predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.X <= predicateThreadBridge_0.m_ParamDispatcher.X && predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.Y == intPoint_0.Y)
			{
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
			}
			if (!bool_0 && predicateThreadBridge_0.m_ParamDispatcher.X != intPoint_0.X)
			{
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
			}
			predicateThreadBridge_1 = UpdateVal(predicateThreadBridge_0, bool_0);
			if (predicateThreadBridge_1.m_ParamDispatcher != intPoint_0)
			{
				predicateThreadBridge_0 = predicateThreadBridge_1;
				predicateThreadBridge_0.m_ParamDispatcher = intPoint_0;
				predicateThreadBridge_1 = UpdateVal(predicateThreadBridge_0, bool_0);
			}
		}
		if (direction2 == Direction.dLeftToRight)
		{
			while (predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.X <= intPoint_0.X && predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.X >= predicateThreadBridge_2.m_ParamDispatcher.X && predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.Y == intPoint_0.Y)
			{
				predicateThreadBridge_2 = predicateThreadBridge_2.pageDispatcher;
			}
			if (bool_0 && predicateThreadBridge_2.m_ParamDispatcher.X != intPoint_0.X)
			{
				predicateThreadBridge_2 = predicateThreadBridge_2.pageDispatcher;
			}
			predicateThreadBridge_3 = UpdateVal(predicateThreadBridge_2, !bool_0);
			if (predicateThreadBridge_3.m_ParamDispatcher != intPoint_0)
			{
				predicateThreadBridge_2 = predicateThreadBridge_3;
				predicateThreadBridge_2.m_ParamDispatcher = intPoint_0;
				predicateThreadBridge_3 = UpdateVal(predicateThreadBridge_2, !bool_0);
			}
		}
		else
		{
			while (predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.X >= intPoint_0.X && predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.X <= predicateThreadBridge_2.m_ParamDispatcher.X && predicateThreadBridge_2.pageDispatcher.m_ParamDispatcher.Y == intPoint_0.Y)
			{
				predicateThreadBridge_2 = predicateThreadBridge_2.pageDispatcher;
			}
			if (!bool_0 && predicateThreadBridge_2.m_ParamDispatcher.X != intPoint_0.X)
			{
				predicateThreadBridge_2 = predicateThreadBridge_2.pageDispatcher;
			}
			predicateThreadBridge_3 = UpdateVal(predicateThreadBridge_2, bool_0);
			if (predicateThreadBridge_3.m_ParamDispatcher != intPoint_0)
			{
				predicateThreadBridge_2 = predicateThreadBridge_3;
				predicateThreadBridge_2.m_ParamDispatcher = intPoint_0;
				predicateThreadBridge_3 = UpdateVal(predicateThreadBridge_2, bool_0);
			}
		}
		if (direction == Direction.dLeftToRight == bool_0)
		{
			predicateThreadBridge_0._RulesDispatcher = predicateThreadBridge_2;
			predicateThreadBridge_2.pageDispatcher = predicateThreadBridge_0;
			predicateThreadBridge_1.pageDispatcher = predicateThreadBridge_3;
			predicateThreadBridge_3._RulesDispatcher = predicateThreadBridge_1;
		}
		else
		{
			predicateThreadBridge_0.pageDispatcher = predicateThreadBridge_2;
			predicateThreadBridge_2._RulesDispatcher = predicateThreadBridge_0;
			predicateThreadBridge_1._RulesDispatcher = predicateThreadBridge_3;
			predicateThreadBridge_3.pageDispatcher = predicateThreadBridge_1;
		}
		return true;
	}

	private bool ReflectVal(ExporterInstanceFilter exporterInstanceFilter_0, RulesConfigObject rulesConfigObject_0, RulesConfigObject rulesConfigObject_1)
	{
		PredicateThreadBridge predicateThreadBridge = exporterInstanceFilter_0.m_TemplateDispatcher;
		PredicateThreadBridge predicateThreadBridge2 = exporterInstanceFilter_0.m_MappingDispatcher;
		bool flag;
		PredicateThreadBridge pageDispatcher;
		PredicateThreadBridge pageDispatcher2;
		if ((flag = exporterInstanceFilter_0.m_TemplateDispatcher.m_ParamDispatcher.Y == exporterInstanceFilter_0.mockDispatcher.Y) && exporterInstanceFilter_0.mockDispatcher == exporterInstanceFilter_0.m_TemplateDispatcher.m_ParamDispatcher && exporterInstanceFilter_0.mockDispatcher == exporterInstanceFilter_0.m_MappingDispatcher.m_ParamDispatcher)
		{
			pageDispatcher = exporterInstanceFilter_0.m_TemplateDispatcher.pageDispatcher;
			while (pageDispatcher != predicateThreadBridge && pageDispatcher.m_ParamDispatcher == exporterInstanceFilter_0.mockDispatcher)
			{
				pageDispatcher = pageDispatcher.pageDispatcher;
			}
			bool flag2 = pageDispatcher.m_ParamDispatcher.Y > exporterInstanceFilter_0.mockDispatcher.Y;
			pageDispatcher2 = exporterInstanceFilter_0.m_MappingDispatcher.pageDispatcher;
			while (pageDispatcher2 != predicateThreadBridge2 && pageDispatcher2.m_ParamDispatcher == exporterInstanceFilter_0.mockDispatcher)
			{
				pageDispatcher2 = pageDispatcher2.pageDispatcher;
			}
			bool flag3 = pageDispatcher2.m_ParamDispatcher.Y > exporterInstanceFilter_0.mockDispatcher.Y;
			if (flag2 == flag3)
			{
				return false;
			}
			if (flag2)
			{
				pageDispatcher = UpdateVal(predicateThreadBridge, bool_0: false);
				pageDispatcher2 = UpdateVal(predicateThreadBridge2, bool_0: true);
				predicateThreadBridge._RulesDispatcher = predicateThreadBridge2;
				predicateThreadBridge2.pageDispatcher = predicateThreadBridge;
				pageDispatcher.pageDispatcher = pageDispatcher2;
				pageDispatcher2._RulesDispatcher = pageDispatcher;
				exporterInstanceFilter_0.m_TemplateDispatcher = predicateThreadBridge;
				exporterInstanceFilter_0.m_MappingDispatcher = pageDispatcher;
				return true;
			}
			pageDispatcher = UpdateVal(predicateThreadBridge, bool_0: true);
			pageDispatcher2 = UpdateVal(predicateThreadBridge2, bool_0: false);
			predicateThreadBridge.pageDispatcher = predicateThreadBridge2;
			predicateThreadBridge2._RulesDispatcher = predicateThreadBridge;
			pageDispatcher._RulesDispatcher = pageDispatcher2;
			pageDispatcher2.pageDispatcher = pageDispatcher;
			exporterInstanceFilter_0.m_TemplateDispatcher = predicateThreadBridge;
			exporterInstanceFilter_0.m_MappingDispatcher = pageDispatcher;
			return true;
		}
		if (flag)
		{
			pageDispatcher = predicateThreadBridge;
			while (predicateThreadBridge._RulesDispatcher.m_ParamDispatcher.Y == predicateThreadBridge.m_ParamDispatcher.Y && predicateThreadBridge._RulesDispatcher != pageDispatcher && predicateThreadBridge._RulesDispatcher != predicateThreadBridge2)
			{
				predicateThreadBridge = predicateThreadBridge._RulesDispatcher;
			}
			while (pageDispatcher.pageDispatcher.m_ParamDispatcher.Y == pageDispatcher.m_ParamDispatcher.Y && pageDispatcher.pageDispatcher != predicateThreadBridge && pageDispatcher.pageDispatcher != predicateThreadBridge2)
			{
				pageDispatcher = pageDispatcher.pageDispatcher;
			}
			if (pageDispatcher.pageDispatcher != predicateThreadBridge && pageDispatcher.pageDispatcher != predicateThreadBridge2)
			{
				pageDispatcher2 = predicateThreadBridge2;
				while (predicateThreadBridge2._RulesDispatcher.m_ParamDispatcher.Y == predicateThreadBridge2.m_ParamDispatcher.Y && predicateThreadBridge2._RulesDispatcher != pageDispatcher2 && predicateThreadBridge2._RulesDispatcher != pageDispatcher)
				{
					predicateThreadBridge2 = predicateThreadBridge2._RulesDispatcher;
				}
				while (pageDispatcher2.pageDispatcher.m_ParamDispatcher.Y == pageDispatcher2.m_ParamDispatcher.Y && pageDispatcher2.pageDispatcher != predicateThreadBridge2 && pageDispatcher2.pageDispatcher != predicateThreadBridge)
				{
					pageDispatcher2 = pageDispatcher2.pageDispatcher;
				}
				if (pageDispatcher2.pageDispatcher != predicateThreadBridge2 && pageDispatcher2.pageDispatcher != predicateThreadBridge)
				{
					if (InsertVal(predicateThreadBridge.m_ParamDispatcher.X, pageDispatcher.m_ParamDispatcher.X, predicateThreadBridge2.m_ParamDispatcher.X, pageDispatcher2.m_ParamDispatcher.X, out var long_, out var long_2))
					{
						IntPoint paramDispatcher;
						bool bool_;
						if (predicateThreadBridge.m_ParamDispatcher.X >= long_ && predicateThreadBridge.m_ParamDispatcher.X <= long_2)
						{
							paramDispatcher = predicateThreadBridge.m_ParamDispatcher;
							bool_ = predicateThreadBridge.m_ParamDispatcher.X > pageDispatcher.m_ParamDispatcher.X;
						}
						else if (predicateThreadBridge2.m_ParamDispatcher.X >= long_ && predicateThreadBridge2.m_ParamDispatcher.X <= long_2)
						{
							paramDispatcher = predicateThreadBridge2.m_ParamDispatcher;
							bool_ = predicateThreadBridge2.m_ParamDispatcher.X > pageDispatcher2.m_ParamDispatcher.X;
						}
						else if (pageDispatcher.m_ParamDispatcher.X >= long_ && pageDispatcher.m_ParamDispatcher.X <= long_2)
						{
							paramDispatcher = pageDispatcher.m_ParamDispatcher;
							bool_ = pageDispatcher.m_ParamDispatcher.X > predicateThreadBridge.m_ParamDispatcher.X;
						}
						else
						{
							paramDispatcher = pageDispatcher2.m_ParamDispatcher;
							bool_ = pageDispatcher2.m_ParamDispatcher.X > predicateThreadBridge2.m_ParamDispatcher.X;
						}
						exporterInstanceFilter_0.m_TemplateDispatcher = predicateThreadBridge;
						exporterInstanceFilter_0.m_MappingDispatcher = predicateThreadBridge2;
						return PrepareVal(predicateThreadBridge, pageDispatcher, predicateThreadBridge2, pageDispatcher2, paramDispatcher, bool_);
					}
					return false;
				}
				return false;
			}
			return false;
		}
		pageDispatcher = predicateThreadBridge.pageDispatcher;
		while (pageDispatcher.m_ParamDispatcher == predicateThreadBridge.m_ParamDispatcher && pageDispatcher != predicateThreadBridge)
		{
			pageDispatcher = pageDispatcher.pageDispatcher;
		}
		bool flag4;
		if (flag4 = pageDispatcher.m_ParamDispatcher.Y > predicateThreadBridge.m_ParamDispatcher.Y || !ClipperBase.SlopesEqual(predicateThreadBridge.m_ParamDispatcher, pageDispatcher.m_ParamDispatcher, exporterInstanceFilter_0.mockDispatcher, _StrategyDispatcher))
		{
			pageDispatcher = predicateThreadBridge._RulesDispatcher;
			while (pageDispatcher.m_ParamDispatcher == predicateThreadBridge.m_ParamDispatcher && pageDispatcher != predicateThreadBridge)
			{
				pageDispatcher = pageDispatcher._RulesDispatcher;
			}
			if (pageDispatcher.m_ParamDispatcher.Y > predicateThreadBridge.m_ParamDispatcher.Y || !ClipperBase.SlopesEqual(predicateThreadBridge.m_ParamDispatcher, pageDispatcher.m_ParamDispatcher, exporterInstanceFilter_0.mockDispatcher, _StrategyDispatcher))
			{
				return false;
			}
		}
		pageDispatcher2 = predicateThreadBridge2.pageDispatcher;
		while (pageDispatcher2.m_ParamDispatcher == predicateThreadBridge2.m_ParamDispatcher && pageDispatcher2 != predicateThreadBridge2)
		{
			pageDispatcher2 = pageDispatcher2.pageDispatcher;
		}
		bool flag5;
		if (flag5 = pageDispatcher2.m_ParamDispatcher.Y > predicateThreadBridge2.m_ParamDispatcher.Y || !ClipperBase.SlopesEqual(predicateThreadBridge2.m_ParamDispatcher, pageDispatcher2.m_ParamDispatcher, exporterInstanceFilter_0.mockDispatcher, _StrategyDispatcher))
		{
			pageDispatcher2 = predicateThreadBridge2._RulesDispatcher;
			while (pageDispatcher2.m_ParamDispatcher == predicateThreadBridge2.m_ParamDispatcher && pageDispatcher2 != predicateThreadBridge2)
			{
				pageDispatcher2 = pageDispatcher2._RulesDispatcher;
			}
			if (pageDispatcher2.m_ParamDispatcher.Y > predicateThreadBridge2.m_ParamDispatcher.Y || !ClipperBase.SlopesEqual(predicateThreadBridge2.m_ParamDispatcher, pageDispatcher2.m_ParamDispatcher, exporterInstanceFilter_0.mockDispatcher, _StrategyDispatcher))
			{
				return false;
			}
		}
		if (pageDispatcher != predicateThreadBridge && pageDispatcher2 != predicateThreadBridge2 && pageDispatcher != pageDispatcher2 && (rulesConfigObject_0 != rulesConfigObject_1 || flag4 != flag5))
		{
			if (flag4)
			{
				pageDispatcher = UpdateVal(predicateThreadBridge, bool_0: false);
				pageDispatcher2 = UpdateVal(predicateThreadBridge2, bool_0: true);
				predicateThreadBridge._RulesDispatcher = predicateThreadBridge2;
				predicateThreadBridge2.pageDispatcher = predicateThreadBridge;
				pageDispatcher.pageDispatcher = pageDispatcher2;
				pageDispatcher2._RulesDispatcher = pageDispatcher;
				exporterInstanceFilter_0.m_TemplateDispatcher = predicateThreadBridge;
				exporterInstanceFilter_0.m_MappingDispatcher = pageDispatcher;
				return true;
			}
			pageDispatcher = UpdateVal(predicateThreadBridge, bool_0: true);
			pageDispatcher2 = UpdateVal(predicateThreadBridge2, bool_0: false);
			predicateThreadBridge.pageDispatcher = predicateThreadBridge2;
			predicateThreadBridge2._RulesDispatcher = predicateThreadBridge;
			pageDispatcher._RulesDispatcher = pageDispatcher2;
			pageDispatcher2.pageDispatcher = pageDispatcher;
			exporterInstanceFilter_0.m_TemplateDispatcher = predicateThreadBridge;
			exporterInstanceFilter_0.m_MappingDispatcher = pageDispatcher;
			return true;
		}
		return false;
	}

	public static int PointInPolygon(IntPoint intPoint_0, List<IntPoint> list_0)
	{
		long x = intPoint_0.X;
		long y = intPoint_0.Y;
		int num = 0;
		int count = list_0.Count;
		if (count < 3)
		{
			return 0;
		}
		IntPoint intPoint = list_0[0];
		long x2 = intPoint.X;
		long y2 = intPoint.Y;
		for (int i = 1; i <= count; i++)
		{
			IntPoint obj = ((i == count) ? list_0[0] : list_0[i]);
			long x3 = obj.X;
			long y3 = obj.Y;
			if (y3 != y || (x3 != x && (y2 != y || x3 > x != x2 < x)))
			{
				if (y2 < y == y3 < y)
				{
					continue;
				}
				if (x2 < x)
				{
					if (x3 > x)
					{
						double num2 = (double)(x2 - x) * (double)(y3 - y) - (double)(x3 - x) * (double)(y2 - y);
						if (num2 == 0.0)
						{
							return -1;
						}
						if (num2 > 0.0 == y3 > y2)
						{
							num = 1 - num;
						}
					}
				}
				else if (x3 <= x)
				{
					double num3 = (double)(x2 - x) * (double)(y3 - y) - (double)(x3 - x) * (double)(y2 - y);
					if (num3 == 0.0)
					{
						return -1;
					}
					if (num3 > 0.0 == y3 > y2)
					{
						num = 1 - num;
					}
				}
				else
				{
					num = 1 - num;
				}
				continue;
			}
			return -1;
		}
		return num;
	}

	private int VisitVal(IntPoint intPoint_0, PredicateThreadBridge predicateThreadBridge_0)
	{
		int num = 0;
		PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
		do
		{
			double num2 = predicateThreadBridge_0.m_ParamDispatcher.X;
			double num3 = predicateThreadBridge_0.m_ParamDispatcher.Y;
			double num4 = predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.X;
			double num5 = predicateThreadBridge_0.pageDispatcher.m_ParamDispatcher.Y;
			if (num5 != (double)intPoint_0.Y || (num4 != (double)intPoint_0.X && (num3 != (double)intPoint_0.Y || num4 > (double)intPoint_0.X != num2 < (double)intPoint_0.X)))
			{
				if (num3 < (double)intPoint_0.Y != num5 < (double)intPoint_0.Y)
				{
					if (num2 < (double)intPoint_0.X)
					{
						if (num4 > (double)intPoint_0.X)
						{
							double num6 = (num2 - (double)intPoint_0.X) * (num5 - (double)intPoint_0.Y) - (num4 - (double)intPoint_0.X) * (num3 - (double)intPoint_0.Y);
							if (num6 == 0.0)
							{
								return -1;
							}
							if (num6 > 0.0 == num5 > num3)
							{
								num = 1 - num;
							}
						}
					}
					else if (num4 <= (double)intPoint_0.X)
					{
						double num7 = (num2 - (double)intPoint_0.X) * (num5 - (double)intPoint_0.Y) - (num4 - (double)intPoint_0.X) * (num3 - (double)intPoint_0.Y);
						if (num7 == 0.0)
						{
							return -1;
						}
						if (num7 > 0.0 == num5 > num3)
						{
							num = 1 - num;
						}
					}
					else
					{
						num = 1 - num;
					}
				}
				predicateThreadBridge_0 = predicateThreadBridge_0.pageDispatcher;
				continue;
			}
			return -1;
		}
		while (predicateThreadBridge != predicateThreadBridge_0);
		return num;
	}

	private bool RestartVal(PredicateThreadBridge predicateThreadBridge_0, PredicateThreadBridge predicateThreadBridge_1)
	{
		PredicateThreadBridge predicateThreadBridge = predicateThreadBridge_0;
		int num;
		while (true)
		{
			num = VisitVal(predicateThreadBridge.m_ParamDispatcher, predicateThreadBridge_1);
			if (num >= 0)
			{
				break;
			}
			predicateThreadBridge = predicateThreadBridge.pageDispatcher;
			if (predicateThreadBridge == predicateThreadBridge_0)
			{
				return true;
			}
		}
		return num != 0;
	}

	private void TestVal(RulesConfigObject rulesConfigObject_0, RulesConfigObject rulesConfigObject_1)
	{
		for (int i = 0; i < _ReponseDispatcher.Count; i++)
		{
			RulesConfigObject rulesConfigObject = _ReponseDispatcher[i];
			if (rulesConfigObject._BaseDispatcher != null && rulesConfigObject.candidateDispatcher == rulesConfigObject_0 && RestartVal(rulesConfigObject._BaseDispatcher, rulesConfigObject_1._BaseDispatcher))
			{
				rulesConfigObject.candidateDispatcher = rulesConfigObject_1;
			}
		}
	}

	private void StopVal(RulesConfigObject rulesConfigObject_0, RulesConfigObject rulesConfigObject_1)
	{
		foreach (RulesConfigObject item in _ReponseDispatcher)
		{
			if (item.candidateDispatcher == rulesConfigObject_0)
			{
				item.candidateDispatcher = rulesConfigObject_1;
			}
		}
	}

	private static RulesConfigObject CancelVal(RulesConfigObject rulesConfigObject_0)
	{
		while (rulesConfigObject_0 != null && rulesConfigObject_0._BaseDispatcher == null)
		{
			rulesConfigObject_0 = rulesConfigObject_0.candidateDispatcher;
		}
		return rulesConfigObject_0;
	}

	private void VerifyVal()
	{
		for (int i = 0; i < advisorDispatcher.Count; i++)
		{
			ExporterInstanceFilter exporterInstanceFilter = advisorDispatcher[i];
			RulesConfigObject rulesConfigObject = SelectVal(exporterInstanceFilter.m_TemplateDispatcher.regDispatcher);
			RulesConfigObject rulesConfigObject2 = SelectVal(exporterInstanceFilter.m_MappingDispatcher.regDispatcher);
			if (rulesConfigObject._BaseDispatcher == null || rulesConfigObject2._BaseDispatcher == null)
			{
				continue;
			}
			RulesConfigObject rulesConfigObject3 = ((rulesConfigObject == rulesConfigObject2) ? rulesConfigObject : (PatchVal(rulesConfigObject, rulesConfigObject2) ? rulesConfigObject2 : (PatchVal(rulesConfigObject2, rulesConfigObject) ? rulesConfigObject : ComputeVal(rulesConfigObject, rulesConfigObject2))));
			if (!ReflectVal(exporterInstanceFilter, rulesConfigObject, rulesConfigObject2))
			{
				continue;
			}
			if (rulesConfigObject == rulesConfigObject2)
			{
				rulesConfigObject._BaseDispatcher = exporterInstanceFilter.m_TemplateDispatcher;
				rulesConfigObject.policyDispatcher = null;
				rulesConfigObject2 = RevertDefinition();
				rulesConfigObject2._BaseDispatcher = exporterInstanceFilter.m_MappingDispatcher;
				ListVal(rulesConfigObject2);
				if (serializerDispatcher)
				{
					for (int j = 0; j < _ReponseDispatcher.Count - 1; j++)
					{
						RulesConfigObject rulesConfigObject4 = _ReponseDispatcher[j];
						if (rulesConfigObject4._BaseDispatcher != null && CancelVal(rulesConfigObject4.candidateDispatcher) == rulesConfigObject && rulesConfigObject4.serviceDispatcher != rulesConfigObject.serviceDispatcher && RestartVal(rulesConfigObject4._BaseDispatcher, exporterInstanceFilter.m_MappingDispatcher))
						{
							rulesConfigObject4.candidateDispatcher = rulesConfigObject2;
						}
					}
				}
				if (RestartVal(rulesConfigObject2._BaseDispatcher, rulesConfigObject._BaseDispatcher))
				{
					rulesConfigObject2.serviceDispatcher = !rulesConfigObject.serviceDispatcher;
					rulesConfigObject2.candidateDispatcher = rulesConfigObject;
					if (serializerDispatcher)
					{
						StopVal(rulesConfigObject2, rulesConfigObject);
					}
					if ((rulesConfigObject2.serviceDispatcher ^ ReverseSolution) == Area(rulesConfigObject2) > 0.0)
					{
						LogoutVal(rulesConfigObject2._BaseDispatcher);
					}
				}
				else if (RestartVal(rulesConfigObject._BaseDispatcher, rulesConfigObject2._BaseDispatcher))
				{
					rulesConfigObject2.serviceDispatcher = rulesConfigObject.serviceDispatcher;
					rulesConfigObject.serviceDispatcher = !rulesConfigObject2.serviceDispatcher;
					rulesConfigObject2.candidateDispatcher = rulesConfigObject.candidateDispatcher;
					rulesConfigObject.candidateDispatcher = rulesConfigObject2;
					if (serializerDispatcher)
					{
						StopVal(rulesConfigObject, rulesConfigObject2);
					}
					if ((rulesConfigObject.serviceDispatcher ^ ReverseSolution) == Area(rulesConfigObject) > 0.0)
					{
						LogoutVal(rulesConfigObject._BaseDispatcher);
					}
				}
				else
				{
					rulesConfigObject2.serviceDispatcher = rulesConfigObject.serviceDispatcher;
					rulesConfigObject2.candidateDispatcher = rulesConfigObject.candidateDispatcher;
					if (serializerDispatcher)
					{
						TestVal(rulesConfigObject, rulesConfigObject2);
					}
				}
			}
			else
			{
				rulesConfigObject2._BaseDispatcher = null;
				rulesConfigObject2.policyDispatcher = null;
				rulesConfigObject2.m_MethodDispatcher = rulesConfigObject.m_MethodDispatcher;
				rulesConfigObject.serviceDispatcher = rulesConfigObject3.serviceDispatcher;
				if (rulesConfigObject3 == rulesConfigObject2)
				{
					rulesConfigObject.candidateDispatcher = rulesConfigObject2.candidateDispatcher;
				}
				rulesConfigObject2.candidateDispatcher = rulesConfigObject;
				if (serializerDispatcher)
				{
					StopVal(rulesConfigObject2, rulesConfigObject);
				}
			}
		}
	}

	private void ListVal(RulesConfigObject rulesConfigObject_0)
	{
		PredicateThreadBridge predicateThreadBridge = rulesConfigObject_0._BaseDispatcher;
		do
		{
			predicateThreadBridge.regDispatcher = rulesConfigObject_0.m_MethodDispatcher;
			predicateThreadBridge = predicateThreadBridge._RulesDispatcher;
		}
		while (predicateThreadBridge != rulesConfigObject_0._BaseDispatcher);
	}

	private void ResolveVal()
	{
		int num = 0;
		while (num < _ReponseDispatcher.Count)
		{
			RulesConfigObject rulesConfigObject = _ReponseDispatcher[num++];
			PredicateThreadBridge predicateThreadBridge = rulesConfigObject._BaseDispatcher;
			if (predicateThreadBridge == null)
			{
				continue;
			}
			do
			{
				for (PredicateThreadBridge predicateThreadBridge2 = predicateThreadBridge.pageDispatcher; predicateThreadBridge2 != rulesConfigObject._BaseDispatcher; predicateThreadBridge2 = predicateThreadBridge2.pageDispatcher)
				{
					if (predicateThreadBridge.m_ParamDispatcher == predicateThreadBridge2.m_ParamDispatcher && predicateThreadBridge2.pageDispatcher != predicateThreadBridge && predicateThreadBridge2._RulesDispatcher != predicateThreadBridge)
					{
						PredicateThreadBridge rulesDispatcher = predicateThreadBridge._RulesDispatcher;
						(predicateThreadBridge._RulesDispatcher = predicateThreadBridge2._RulesDispatcher).pageDispatcher = predicateThreadBridge;
						predicateThreadBridge2._RulesDispatcher = rulesDispatcher;
						rulesDispatcher.pageDispatcher = predicateThreadBridge2;
						rulesConfigObject._BaseDispatcher = predicateThreadBridge;
						RulesConfigObject rulesConfigObject2 = RevertDefinition();
						rulesConfigObject2._BaseDispatcher = predicateThreadBridge2;
						ListVal(rulesConfigObject2);
						if (RestartVal(rulesConfigObject2._BaseDispatcher, rulesConfigObject._BaseDispatcher))
						{
							rulesConfigObject2.serviceDispatcher = !rulesConfigObject.serviceDispatcher;
							rulesConfigObject2.candidateDispatcher = rulesConfigObject;
						}
						else if (RestartVal(rulesConfigObject._BaseDispatcher, rulesConfigObject2._BaseDispatcher))
						{
							rulesConfigObject2.serviceDispatcher = rulesConfigObject.serviceDispatcher;
							rulesConfigObject.serviceDispatcher = !rulesConfigObject2.serviceDispatcher;
							rulesConfigObject2.candidateDispatcher = rulesConfigObject.candidateDispatcher;
							rulesConfigObject.candidateDispatcher = rulesConfigObject2;
						}
						else
						{
							rulesConfigObject2.serviceDispatcher = rulesConfigObject.serviceDispatcher;
							rulesConfigObject2.candidateDispatcher = rulesConfigObject.candidateDispatcher;
						}
						predicateThreadBridge2 = predicateThreadBridge;
					}
				}
				predicateThreadBridge = predicateThreadBridge.pageDispatcher;
			}
			while (predicateThreadBridge != rulesConfigObject._BaseDispatcher);
		}
	}

	public static double Area(List<IntPoint> list_0)
	{
		int count = list_0.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		int i = 0;
		int index = count - 1;
		for (; i < count; i++)
		{
			num += ((double)list_0[index].X + (double)list_0[i].X) * ((double)list_0[index].Y - (double)list_0[i].Y);
			index = i;
		}
		return (0.0 - num) * 0.5;
	}

	private double Area(RulesConfigObject rulesConfigObject_0)
	{
		PredicateThreadBridge predicateThreadBridge = rulesConfigObject_0._BaseDispatcher;
		if (predicateThreadBridge == null)
		{
			return 0.0;
		}
		double num = 0.0;
		do
		{
			num += (double)(predicateThreadBridge._RulesDispatcher.m_ParamDispatcher.X + predicateThreadBridge.m_ParamDispatcher.X) * (double)(predicateThreadBridge._RulesDispatcher.m_ParamDispatcher.Y - predicateThreadBridge.m_ParamDispatcher.Y);
			predicateThreadBridge = predicateThreadBridge.pageDispatcher;
		}
		while (predicateThreadBridge != rulesConfigObject_0._BaseDispatcher);
		return num * 0.5;
	}

	public static List<List<IntPoint>> OffsetPaths(List<List<IntPoint>> list_0, double double_0, JoinType joinType_0, EndType_ endType__0, double double_1)
	{
		List<List<IntPoint>> list_ = new List<List<IntPoint>>();
		ClipperOffset clipperOffset = new ClipperOffset(double_1, double_1);
		clipperOffset.AddPaths(list_0, joinType_0, (EndType)endType__0);
		clipperOffset.Execute(ref list_, double_0);
		return list_;
	}

	public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> list_0, PolyFillType polyFillType_0 = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPath(list_0, PolyType.ptSubject, bool_0: true);
		clipper.Execute(ClipType.ctUnion, list, polyFillType_0, polyFillType_0);
		return list;
	}

	public static List<List<IntPoint>> SimplifyPolygons(List<List<IntPoint>> list_0, PolyFillType polyFillType_0 = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPaths(list_0, PolyType.ptSubject, bool_0: true);
		clipper.Execute(ClipType.ctUnion, list, polyFillType_0, polyFillType_0);
		return list;
	}

	private static double PostVal(IntPoint intPoint_0, IntPoint intPoint_1)
	{
		double num = (double)intPoint_0.X - (double)intPoint_1.X;
		double num2 = (double)intPoint_0.Y - (double)intPoint_1.Y;
		return num * num + num2 * num2;
	}

	private static double RunVal(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2)
	{
		double num = intPoint_1.Y - intPoint_2.Y;
		double num2 = intPoint_2.X - intPoint_1.X;
		double num3 = num * (double)intPoint_1.X + num2 * (double)intPoint_1.Y;
		num3 = num * (double)intPoint_0.X + num2 * (double)intPoint_0.Y - num3;
		return num3 * num3 / (num * num + num2 * num2);
	}

	private static bool StartVal(IntPoint intPoint_0, IntPoint intPoint_1, IntPoint intPoint_2, double double_0)
	{
		return RunVal(intPoint_1, intPoint_0, intPoint_2) < double_0;
	}

	private static bool AssetVal(IntPoint intPoint_0, IntPoint intPoint_1, double double_0)
	{
		double num = (double)intPoint_0.X - (double)intPoint_1.X;
		double num2 = (double)intPoint_0.Y - (double)intPoint_1.Y;
		return num * num + num2 * num2 <= double_0;
	}

	private static PredicateThreadBridge PrintVal(PredicateThreadBridge predicateThreadBridge_0)
	{
		PredicateThreadBridge rulesDispatcher = predicateThreadBridge_0._RulesDispatcher;
		rulesDispatcher.pageDispatcher = predicateThreadBridge_0.pageDispatcher;
		predicateThreadBridge_0.pageDispatcher._RulesDispatcher = rulesDispatcher;
		rulesDispatcher.regDispatcher = 0;
		return rulesDispatcher;
	}

	public static List<IntPoint> CleanPolygon(List<IntPoint> list_0, double double_0 = 1.415)
	{
		int num = list_0.Count;
		if (num == 0)
		{
			return new List<IntPoint>();
		}
		PredicateThreadBridge[] array = new PredicateThreadBridge[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new PredicateThreadBridge();
		}
		for (int j = 0; j < num; j++)
		{
			array[j].m_ParamDispatcher = list_0[j];
			array[j].pageDispatcher = array[(j + 1) % num];
			array[j].pageDispatcher._RulesDispatcher = array[j];
			array[j].regDispatcher = 0;
		}
		double double_ = double_0 * double_0;
		PredicateThreadBridge predicateThreadBridge = array[0];
		while (predicateThreadBridge.regDispatcher == 0 && predicateThreadBridge.pageDispatcher != predicateThreadBridge._RulesDispatcher)
		{
			if (AssetVal(predicateThreadBridge.m_ParamDispatcher, predicateThreadBridge._RulesDispatcher.m_ParamDispatcher, double_))
			{
				predicateThreadBridge = PrintVal(predicateThreadBridge);
				num--;
			}
			else if (AssetVal(predicateThreadBridge._RulesDispatcher.m_ParamDispatcher, predicateThreadBridge.pageDispatcher.m_ParamDispatcher, double_))
			{
				PrintVal(predicateThreadBridge.pageDispatcher);
				predicateThreadBridge = PrintVal(predicateThreadBridge);
				num -= 2;
			}
			else if (StartVal(predicateThreadBridge._RulesDispatcher.m_ParamDispatcher, predicateThreadBridge.m_ParamDispatcher, predicateThreadBridge.pageDispatcher.m_ParamDispatcher, double_))
			{
				predicateThreadBridge = PrintVal(predicateThreadBridge);
				num--;
			}
			else
			{
				predicateThreadBridge.regDispatcher = 1;
				predicateThreadBridge = predicateThreadBridge.pageDispatcher;
			}
		}
		if (num < 3)
		{
			num = 0;
		}
		List<IntPoint> list = new List<IntPoint>(num);
		for (int k = 0; k < num; k++)
		{
			list.Add(predicateThreadBridge.m_ParamDispatcher);
			predicateThreadBridge = predicateThreadBridge.pageDispatcher;
		}
		array = null;
		return list;
	}

	public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> list_0, double double_0 = 1.415)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>(list_0.Count);
		for (int i = 0; i < list_0.Count; i++)
		{
			list.Add(CleanPolygon(list_0[i], double_0));
		}
		return list;
	}

	internal static List<List<IntPoint>> DefineVal(List<IntPoint> list_0, List<IntPoint> list_1, bool bool_0, bool bool_1)
	{
		int num = (bool_1 ? 1 : 0);
		int count = list_0.Count;
		int count2 = list_1.Count;
		List<List<IntPoint>> list = new List<List<IntPoint>>(count2);
		if (bool_0)
		{
			for (int i = 0; i < count2; i++)
			{
				List<IntPoint> list2 = new List<IntPoint>(count);
				foreach (IntPoint item in list_0)
				{
					list2.Add(new IntPoint(list_1[i].X + item.X, list_1[i].Y + item.Y));
				}
				list.Add(list2);
			}
		}
		else
		{
			for (int j = 0; j < count2; j++)
			{
				List<IntPoint> list3 = new List<IntPoint>(count);
				foreach (IntPoint item2 in list_0)
				{
					list3.Add(new IntPoint(list_1[j].X - item2.X, list_1[j].Y - item2.Y));
				}
				list.Add(list3);
			}
		}
		List<List<IntPoint>> list4 = new List<List<IntPoint>>((count2 + num) * (count + 1));
		for (int k = 0; k < count2 - 1 + num; k++)
		{
			for (int l = 0; l < count; l++)
			{
				List<IntPoint> list5 = new List<IntPoint>(4);
				list5.Add(list[k % count2][l % count]);
				list5.Add(list[(k + 1) % count2][l % count]);
				list5.Add(list[(k + 1) % count2][(l + 1) % count]);
				list5.Add(list[k % count2][(l + 1) % count]);
				if (!Orientation(list5))
				{
					list5.Reverse();
				}
				list4.Add(list5);
			}
		}
		Clipper clipper = new Clipper();
		clipper.AddPaths(list4, PolyType.ptSubject, bool_0: true);
		clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> list_0, List<IntPoint> list_1, bool bool_0)
	{
		return DefineVal(list_0, list_1, bool_0: true, bool_0);
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> list_0, List<List<IntPoint>> list_1, PolyFillType polyFillType_0, bool bool_0)
	{
		Clipper clipper = new Clipper();
		for (int i = 0; i < list_1.Count; i++)
		{
			List<List<IntPoint>> list_2 = DefineVal(list_0, list_1[i], bool_0: true, bool_0);
			clipper.AddPaths(list_2, PolyType.ptSubject, bool_0: true);
		}
		if (bool_0)
		{
			clipper.AddPaths(list_1, PolyType.ptClip, bool_0: true);
		}
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		clipper.Execute(ClipType.ctUnion, list, polyFillType_0, polyFillType_0);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> list_0, List<IntPoint> list_1)
	{
		return DefineVal(list_0, list_1, bool_0: false, bool_1: true);
	}

	public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polyTree_0)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polyTree_0.Total;
		PublishVal(polyTree_0, NodeType.ntAny, list);
		return list;
	}

	internal static void PublishVal(PolyNode polyNode_0, NodeType nodeType_0, List<List<IntPoint>> list_0)
	{
		bool flag = true;
		switch (nodeType_0)
		{
		case NodeType.ntClosed:
			flag = !polyNode_0.IsOpen;
			break;
		case NodeType.ntOpen:
			return;
		}
		if (polyNode_0.m_PrinterDispatcher.Count > 0 && flag)
		{
			list_0.Add(polyNode_0.m_PrinterDispatcher);
		}
		foreach (PolyNode child in polyNode_0.Childs)
		{
			PublishVal(child, nodeType_0, list_0);
		}
	}

	public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polyTree_0)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polyTree_0.ChildCount;
		for (int i = 0; i < polyTree_0.ChildCount; i++)
		{
			if (polyTree_0.Childs[i].IsOpen)
			{
				list.Add(polyTree_0.Childs[i].m_PrinterDispatcher);
			}
		}
		return list;
	}

	public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polyTree_0)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polyTree_0.Total;
		PublishVal(polyTree_0, NodeType.ntClosed, list);
		return list;
	}
}
