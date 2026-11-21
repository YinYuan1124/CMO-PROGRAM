using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Command.Maps;
using Command.Tasks;
using OpenDis.Database;
using OpenDis.Services;

namespace DotSpatial.Topology.Voronoi;

public abstract class Fortune
{
	public static readonly Vector2 VVUnkown;

	public static readonly Vector2 vector2_0;

	public static bool DoCleanup;

	internal static double GetRule(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		if (double_0 == double_2 && double_1 == double_3)
		{
			throw new ArgumentException("Identical datapoints are not allowed!");
		}
		if (double_1 == double_4 && double_3 == double_4)
		{
			return (double_0 + double_2) / 2.0;
		}
		if (double_1 == double_4)
		{
			return double_0;
		}
		if (double_3 == double_4)
		{
			return double_2;
		}
		double num = 1.0 / (2.0 * (double_1 - double_4));
		double num2 = 1.0 / (2.0 * (double_3 - double_4));
		if (num == num2)
		{
			return (double_0 + double_2) / 2.0;
		}
		double num3 = Math.Sqrt(-8.0 * num * double_0 * num2 * double_2 - 2.0 * num * double_1 + 2.0 * num * double_3 + 4.0 * num * num2 * double_2 * double_2 + 2.0 * num2 * double_1 + 4.0 * num2 * num * double_0 * double_0 - 2.0 * num2 * double_3);
		double num4 = 0.5 / (2.0 * num - 2.0 * num2) * (4.0 * num * double_0 - 4.0 * num2 * double_2 + 2.0 * num3);
		double num5 = 0.5 / (2.0 * num - 2.0 * num2) * (4.0 * num * double_0 - 4.0 * num2 * double_2 - 2.0 * num3);
		if (num4 > num5)
		{
			double num6 = num4;
			num4 = num5;
			num5 = num6;
		}
		if (double_1 < double_3)
		{
			return num4;
		}
		return num5;
	}

	internal static Vector2 WriteRule(Vector2 vector2_1, Vector2 vector2_2, Vector2 vector2_3)
	{
		if (!(vector2_1 == vector2_2) && !(vector2_2 == vector2_3) && !(vector2_1 == vector2_3))
		{
			double num = (vector2_1.X + vector2_3.X) / 2.0;
			double num2 = (vector2_1.Y + vector2_3.Y) / 2.0;
			double num3 = (vector2_2.X + vector2_3.X) / 2.0;
			double num4 = (vector2_2.Y + vector2_3.Y) / 2.0;
			double num5;
			double num6;
			if (vector2_1.X == vector2_3.X)
			{
				num5 = 1.0;
				num6 = 0.0;
			}
			else
			{
				num5 = (vector2_3.Y - vector2_1.Y) / (vector2_1.X - vector2_3.X);
				num6 = 1.0;
			}
			double num7;
			double num8;
			if (vector2_2.X == vector2_3.X)
			{
				num7 = -1.0;
				num8 = 0.0;
			}
			else
			{
				num7 = (vector2_2.Y - vector2_3.Y) / (vector2_2.X - vector2_3.X);
				num8 = -1.0;
			}
			double num9 = (num8 * (num3 - num) - num7 * (num4 - num2)) / (num5 * num8 - num7 * num6);
			return new Vector2(num + num9 * num5, num2 + num9 * num6);
		}
		throw new ArgumentException("Need three different points!");
	}

	public static VoronoiGraph ComputeVoronoiGraph(double[] double_0, double double_1, bool bool_0)
	{
		Vector2.Tolerance = double_1;
		DoCleanup = bool_0;
		return ComputeVoronoiGraph(double_0);
	}

	public static VoronoiGraph ComputeVoronoiGraph(double[] double_0)
	{
		SortedDictionary<ThreadThread, ThreadThread> sortedDictionary = new SortedDictionary<ThreadThread, ThreadThread>();
		Dictionary<DicListenerMapping, ClassDecoratorEntry> dictionary = new Dictionary<DicListenerMapping, ClassDecoratorEntry>();
		VoronoiGraph voronoiGraph = new VoronoiGraph();
		MethodMerchantService methodMerchantService = null;
		for (int i = 0; i < double_0.Length / 2; i++)
		{
			ProcProcess procProcess = new ProcProcess(new Vector2(double_0, i * 2));
			if (!sortedDictionary.ContainsKey(procProcess))
			{
				sortedDictionary.Add(procProcess, procProcess);
			}
		}
		while (sortedDictionary.Count > 0)
		{
			ThreadThread key = sortedDictionary.First().Key;
			sortedDictionary.Remove(key);
			DicListenerMapping[] dicListenerMapping_ = new DicListenerMapping[0];
			if (key is ProcProcess)
			{
				methodMerchantService = MethodMerchantService.InitRule(key as ProcProcess, methodMerchantService, (HashSet<VoronoiEdge>)(object)voronoiGraph, key.Y, out dicListenerMapping_);
			}
			else if (key is ClassDecoratorEntry)
			{
				dictionary.Remove(((ClassDecoratorEntry)key)._ManagerProcess);
				if (!((ClassDecoratorEntry)key)._ProducerProcess)
				{
					continue;
				}
				methodMerchantService = MethodMerchantService.CheckRule((DicListenerMapping)(object)(key as ClassDecoratorEntry), methodMerchantService, (HashSet<VoronoiEdge>)(object)voronoiGraph, out dicListenerMapping_);
			}
			else if (key != null)
			{
				throw new Exception("Got event of type " + key.GetType()?.ToString() + "!");
			}
			DicListenerMapping[] array = dicListenerMapping_;
			DicListenerMapping[] array2 = array;
			foreach (DicListenerMapping dicListenerMapping in array2)
			{
				if (dictionary.ContainsKey(dicListenerMapping))
				{
					dictionary[dicListenerMapping]._ProducerProcess = false;
					dictionary.Remove(dicListenerMapping);
				}
				if (key != null)
				{
					ClassDecoratorEntry classDecoratorEntry = MethodMerchantService.ConcatRule(dicListenerMapping, key.Y);
					if (classDecoratorEntry != null)
					{
						sortedDictionary.Add(classDecoratorEntry, classDecoratorEntry);
						dictionary[dicListenerMapping] = classDecoratorEntry;
					}
				}
			}
			if (!(key is ProcProcess))
			{
				continue;
			}
			Vector2 structThread = ((ProcProcess)key).m_StructThread;
			foreach (ClassDecoratorEntry value in dictionary.Values)
			{
				if (MathTools.Dist(structThread.X, structThread.Y, value.Center.X, value.Center.Y) < value.Y - value.Center.Y && Math.Abs(MathTools.Dist(structThread.X, structThread.Y, value.Center.X, value.Center.Y) - (value.Y - value.Center.Y)) > 1E-10)
				{
					value._ProducerProcess = false;
				}
			}
		}
		if (DoCleanup)
		{
			MethodMerchantService.InterruptRule(methodMerchantService);
			foreach (VoronoiEdge edge in voronoiGraph.Edges)
			{
				if (!edge._ObjectThread && edge.VVertexB == VVUnkown)
				{
					edge.AddVertex(vector2_0);
					if (Math.Abs(edge.LeftData.Y - edge.RightData.Y) < 1E-10 && edge.LeftData.X < edge.RightData.X)
					{
						Vector2 leftData = edge.LeftData;
						edge.LeftData = edge.RightData;
						edge.RightData = leftData;
					}
				}
			}
			ArrayList arrayList = new ArrayList();
			foreach (VoronoiEdge edge2 in voronoiGraph.Edges)
			{
				if (edge2.IsPartlyInfinite || !edge2.VVertexA.Equals(edge2.VVertexB))
				{
					continue;
				}
				arrayList.Add(edge2);
				foreach (VoronoiEdge edge3 in voronoiGraph.Edges)
				{
					if (edge3.VVertexA.Equals(edge2.VVertexA))
					{
						edge3.VVertexA = edge2.VVertexA;
					}
					if (edge3.VVertexB.Equals(edge2.VVertexA))
					{
						edge3.VVertexB = edge2.VVertexA;
					}
				}
			}
			foreach (VoronoiEdge item in arrayList)
			{
				voronoiGraph.Edges.Remove(item);
			}
			return voronoiGraph;
		}
		return voronoiGraph;
	}

	public static VoronoiGraph FilterVg(VoronoiGraph voronoiGraph_0, double double_0)
	{
		VoronoiGraph voronoiGraph = new VoronoiGraph();
		foreach (VoronoiEdge edge in voronoiGraph_0.Edges)
		{
			if (edge.LeftData.Distance(edge.RightData) >= double_0)
			{
				voronoiGraph.Edges.Add(edge);
			}
		}
		foreach (VoronoiEdge edge2 in voronoiGraph.Edges)
		{
			voronoiGraph.Vertices.Add(edge2.VVertexA);
			voronoiGraph.Vertices.Add(edge2.VVertexB);
		}
		return voronoiGraph;
	}

	static Fortune()
	{
		VVUnkown = new Vector2(double.NaN, double.NaN);
		vector2_0 = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
	}
}
