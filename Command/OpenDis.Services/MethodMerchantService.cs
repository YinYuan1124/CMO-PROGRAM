using System;
using System.Runtime.CompilerServices;
using Command.Filter;
using Command.Maps;
using DotSpatial.Topology.Voronoi;
using OpenDis.Database;

namespace OpenDis.Services;

internal abstract class MethodMerchantService
{
	private MethodMerchantService m_RuleThread;

	private MethodMerchantService collectionThread;

	private MethodMerchantService _InstanceThread;

	private MethodMerchantService Left
	{
		get
		{
			return m_RuleThread;
		}
		set
		{
			m_RuleThread = value;
			value.PopRule(this);
		}
	}

	private MethodMerchantService Right
	{
		get
		{
			return _InstanceThread;
		}
		set
		{
			_InstanceThread = value;
			value.PopRule(this);
		}
	}

	[SpecialName]
	private MethodMerchantService CalculateRule()
	{
		return collectionThread;
	}

	[SpecialName]
	private void PopRule(MethodMerchantService methodMerchantService_0)
	{
		collectionThread = methodMerchantService_0;
	}

	private void ExcludeRule(MethodMerchantService methodMerchantService_0, MethodMerchantService methodMerchantService_1)
	{
		if (Left == methodMerchantService_0)
		{
			Left = methodMerchantService_1;
		}
		else
		{
			if (Right != methodMerchantService_0)
			{
				throw new Exception("Child not found!");
			}
			Right = methodMerchantService_1;
		}
		methodMerchantService_0.PopRule(null);
	}

	private static DicListenerMapping IncludeRule(MethodMerchantService methodMerchantService_0)
	{
		MethodMerchantService methodMerchantService = methodMerchantService_0;
		while (true)
		{
			if (methodMerchantService.CalculateRule() != null)
			{
				if (methodMerchantService.CalculateRule().Left != methodMerchantService)
				{
					break;
				}
				methodMerchantService = methodMerchantService.CalculateRule();
				continue;
			}
			return null;
		}
		methodMerchantService = methodMerchantService.CalculateRule();
		methodMerchantService = methodMerchantService.Left;
		while (methodMerchantService.Right != null)
		{
			methodMerchantService = methodMerchantService.Right;
		}
		return (DicListenerMapping)methodMerchantService;
	}

	private static DicListenerMapping SearchRule(MethodMerchantService methodMerchantService_0)
	{
		MethodMerchantService methodMerchantService = methodMerchantService_0;
		while (true)
		{
			if (methodMerchantService.CalculateRule() != null)
			{
				if (methodMerchantService.CalculateRule().Right != methodMerchantService)
				{
					break;
				}
				methodMerchantService = methodMerchantService.CalculateRule();
				continue;
			}
			return null;
		}
		methodMerchantService = methodMerchantService.CalculateRule();
		methodMerchantService = methodMerchantService.Right;
		while (methodMerchantService.Left != null)
		{
			methodMerchantService = methodMerchantService.Left;
		}
		return (DicListenerMapping)methodMerchantService;
	}

	private static CallbackThread EnableRule(MethodMerchantService methodMerchantService_0)
	{
		MethodMerchantService methodMerchantService = methodMerchantService_0;
		while (true)
		{
			if (methodMerchantService.CalculateRule() != null)
			{
				if (methodMerchantService.CalculateRule().Right != methodMerchantService)
				{
					break;
				}
				methodMerchantService = methodMerchantService.CalculateRule();
				continue;
			}
			throw new Exception("No Left Leaf found!");
		}
		methodMerchantService = methodMerchantService.CalculateRule();
		return (CallbackThread)methodMerchantService;
	}

	private static DicListenerMapping ChangeRule(MethodMerchantService methodMerchantService_0, double double_0, double double_1)
	{
		MethodMerchantService methodMerchantService = methodMerchantService_0;
		while (!(methodMerchantService is DicListenerMapping))
		{
			methodMerchantService = ((((CallbackThread)methodMerchantService).SetupRule(double_0, double_1) < 0.0) ? methodMerchantService.Left : methodMerchantService.Right);
		}
		return (DicListenerMapping)methodMerchantService;
	}

	public static MethodMerchantService InitRule(object object_0, object object_1, HashSet<VoronoiEdge> hashSet_0, double double_0, out DicListenerMapping[] dicListenerMapping_0)
	{
		if (object_1 == null)
		{
			object_1 = new DicListenerMapping(((ProcProcess)object_0).m_StructThread);
			dicListenerMapping_0 = new DicListenerMapping[1] { (DicListenerMapping)object_1 };
			return (MethodMerchantService)object_1;
		}
		MethodMerchantService methodMerchantService = ChangeRule((MethodMerchantService)object_1, double_0, ((ProcProcess)object_0).m_StructThread.X);
		VoronoiEdge voronoiEdge = new VoronoiEdge();
		voronoiEdge.LeftData = ((DicListenerMapping)methodMerchantService)._MerchantThread;
		voronoiEdge.RightData = ((ProcProcess)object_0).m_StructThread;
		voronoiEdge.VVertexA = Fortune.VVUnkown;
		voronoiEdge.VVertexB = Fortune.VVUnkown;
		((VoronoiGraph)(object)hashSet_0).Edges.Add(voronoiEdge);
		MethodMerchantService methodMerchantService2;
		if (Math.Abs(voronoiEdge.LeftData.Y - voronoiEdge.RightData.Y) < 1E-10)
		{
			if (voronoiEdge.LeftData.X < voronoiEdge.RightData.X)
			{
				methodMerchantService2 = new CallbackThread(voronoiEdge, bool_0: false);
				methodMerchantService2.Left = new DicListenerMapping(voronoiEdge.LeftData);
				methodMerchantService2.Right = new DicListenerMapping(voronoiEdge.RightData);
			}
			else
			{
				methodMerchantService2 = new CallbackThread(voronoiEdge, bool_0: true);
				methodMerchantService2.Left = new DicListenerMapping(voronoiEdge.RightData);
				methodMerchantService2.Right = new DicListenerMapping(voronoiEdge.LeftData);
			}
			dicListenerMapping_0 = new DicListenerMapping[2]
			{
				(DicListenerMapping)methodMerchantService2.Left,
				(DicListenerMapping)methodMerchantService2.Right
			};
		}
		else
		{
			methodMerchantService2 = new CallbackThread(voronoiEdge, bool_0: false);
			methodMerchantService2.Left = new DicListenerMapping(voronoiEdge.LeftData);
			methodMerchantService2.Right = new CallbackThread(voronoiEdge, bool_0: true);
			methodMerchantService2.Right.Left = new DicListenerMapping(voronoiEdge.RightData);
			methodMerchantService2.Right.Right = new DicListenerMapping(voronoiEdge.LeftData);
			dicListenerMapping_0 = new DicListenerMapping[3]
			{
				(DicListenerMapping)methodMerchantService2.Left,
				(DicListenerMapping)methodMerchantService2.Right.Left,
				(DicListenerMapping)methodMerchantService2.Right.Right
			};
		}
		if (methodMerchantService.CalculateRule() == null)
		{
			return methodMerchantService2;
		}
		methodMerchantService.CalculateRule().ExcludeRule(methodMerchantService, methodMerchantService2);
		return (MethodMerchantService)object_1;
	}

	public static MethodMerchantService CheckRule(DicListenerMapping dicListenerMapping_0, object object_0, HashSet<VoronoiEdge> hashSet_0, out DicListenerMapping[] dicListenerMapping_1)
	{
		DicListenerMapping managerProcess = ((ClassDecoratorEntry)(object)dicListenerMapping_0)._ManagerProcess;
		DicListenerMapping dicListenerMapping = IncludeRule(managerProcess);
		DicListenerMapping dicListenerMapping2 = SearchRule(managerProcess);
		if (dicListenerMapping != null && managerProcess.CalculateRule() != null && dicListenerMapping2 != null && dicListenerMapping._MerchantThread.Equals(((ClassDecoratorEntry)(object)dicListenerMapping_0)._MapperProcess._MerchantThread) && dicListenerMapping2._MerchantThread.Equals(((ClassDecoratorEntry)(object)dicListenerMapping_0)._GetterProcess._MerchantThread))
		{
			CallbackThread callbackThread = (CallbackThread)managerProcess.CalculateRule();
			dicListenerMapping_1 = new DicListenerMapping[2] { dicListenerMapping, dicListenerMapping2 };
			Vector2 vector = new Vector2(((ClassDecoratorEntry)(object)dicListenerMapping_0).Center.X, ((ClassDecoratorEntry)(object)dicListenerMapping_0).Center.Y);
			((VoronoiGraph)(object)hashSet_0).Vertices.Add(vector);
			CallbackThread callbackThread2;
			if (callbackThread.Left == managerProcess)
			{
				callbackThread2 = EnableRule(dicListenerMapping);
				callbackThread.CalculateRule().ExcludeRule(callbackThread, callbackThread.Right);
			}
			else
			{
				callbackThread2 = EnableRule(managerProcess);
				callbackThread.CalculateRule().ExcludeRule(callbackThread, callbackThread.Left);
			}
			callbackThread.m_DecoratorThread.AddVertex(vector);
			callbackThread2.m_DecoratorThread.AddVertex(vector);
			VoronoiEdge voronoiEdge = new VoronoiEdge();
			voronoiEdge.LeftData = dicListenerMapping._MerchantThread;
			voronoiEdge.RightData = dicListenerMapping2._MerchantThread;
			voronoiEdge.AddVertex(vector);
			((VoronoiGraph)(object)hashSet_0).Edges.Add(voronoiEdge);
			CallbackThread callbackThread3 = new CallbackThread(voronoiEdge, bool_0: false);
			callbackThread3.Left = callbackThread2.Left;
			callbackThread3.Right = callbackThread2.Right;
			if (callbackThread2.CalculateRule() == null)
			{
				return callbackThread3;
			}
			callbackThread2.CalculateRule().ExcludeRule(callbackThread2, callbackThread3);
			return (MethodMerchantService)object_0;
		}
		dicListenerMapping_1 = new DicListenerMapping[0];
		return (MethodMerchantService)object_0;
	}

	public static ClassDecoratorEntry ConcatRule(object object_0, double double_0)
	{
		DicListenerMapping dicListenerMapping = IncludeRule((MethodMerchantService)object_0);
		DicListenerMapping dicListenerMapping2 = SearchRule((MethodMerchantService)object_0);
		if (dicListenerMapping != null && dicListenerMapping2 != null && !(dicListenerMapping._MerchantThread == dicListenerMapping2._MerchantThread) && !(dicListenerMapping._MerchantThread == ((DicListenerMapping)object_0)._MerchantThread) && !(((DicListenerMapping)object_0)._MerchantThread == dicListenerMapping2._MerchantThread))
		{
			if (MathTools.Ccw(dicListenerMapping._MerchantThread.X, dicListenerMapping._MerchantThread.Y, ((DicListenerMapping)object_0)._MerchantThread.X, ((DicListenerMapping)object_0)._MerchantThread.Y, dicListenerMapping2._MerchantThread.X, dicListenerMapping2._MerchantThread.Y, bool_0: false) <= 0)
			{
				return null;
			}
			Vector2 center = Fortune.WriteRule(dicListenerMapping._MerchantThread, ((DicListenerMapping)object_0)._MerchantThread, dicListenerMapping2._MerchantThread);
			ClassDecoratorEntry classDecoratorEntry = new ClassDecoratorEntry();
			classDecoratorEntry._ManagerProcess = (DicListenerMapping)object_0;
			classDecoratorEntry._MapperProcess = dicListenerMapping;
			classDecoratorEntry._GetterProcess = dicListenerMapping2;
			classDecoratorEntry.Center = center;
			classDecoratorEntry._ProducerProcess = true;
			if (classDecoratorEntry.Y < double_0)
			{
				return null;
			}
			return classDecoratorEntry;
		}
		return null;
	}

	public static void InterruptRule(MethodMerchantService methodMerchantService_0)
	{
		if (methodMerchantService_0 is DicListenerMapping)
		{
			return;
		}
		if (methodMerchantService_0 is CallbackThread callbackThread)
		{
			while (callbackThread.m_DecoratorThread.VVertexB == Fortune.VVUnkown)
			{
				callbackThread.m_DecoratorThread.AddVertex(Fortune.vector2_0);
			}
			if (callbackThread.m_ProcessThread)
			{
				Vector2 leftData = callbackThread.m_DecoratorThread.LeftData;
				callbackThread.m_DecoratorThread.LeftData = callbackThread.m_DecoratorThread.RightData;
				callbackThread.m_DecoratorThread.RightData = leftData;
			}
			callbackThread.m_DecoratorThread._ObjectThread = true;
		}
		InterruptRule(methodMerchantService_0.Left);
		InterruptRule(methodMerchantService_0.Right);
	}
}
