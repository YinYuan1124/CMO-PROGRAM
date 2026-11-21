using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SettlersEngine;

namespace Command_Core;

public sealed class SettlersEnginePathfinder : GInterface8
{
	private sealed class CandidateItem : IPathNode<ActiveUnit>
	{
		public double baseItem;

		public double m_PolicyItem;

		private bool? m_BroadcasterItem;

		private short? _IdentifierItem;

		private List<ActiveUnit> _PrinterItem;

		private float _ParserItem;

		[SpecialName]
		private short method_0(Scenario scenario_0)
		{
			if (Information.IsNothing(_IdentifierItem))
			{
				_IdentifierItem = Pathfinding._PredicateConsumer.GetElev(baseItem, m_PolicyItem, scenario_0);
			}
			return _IdentifierItem.Value;
		}

		[SpecialName]
		public float method_1()
		{
			return _ParserItem;
		}

		[SpecialName]
		public void method_2(float float_0)
		{
			_ParserItem = float_0;
		}

		[SpecialName]
		public List<ActiveUnit> method_3()
		{
			return _PrinterItem;
		}

		[SpecialName]
		public void method_4(List<ActiveUnit> list_0)
		{
			_PrinterItem = list_0;
		}

		internal bool VerifyInterruptibleReg(ActiveUnit activeUnit_0)
		{
			if (!m_BroadcasterItem.HasValue)
			{
				double double_ = baseItem;
				double policyItem = m_PolicyItem;
				int int_ = 0;
				bool bool_ = true;
				bool bool_2 = true;
				short? nullable_ = method_0(activeUnit_0.ParentScen);
				List<ActiveUnit> list_ = method_3();
				float float_ = method_1();
				string string_ = "";
				bool bool_3 = false;
				bool value = activeUnit_0.CanMoveToThisLocation(double_, policyItem, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, nullable_, ref list_, float_, bool_6: false, bool_7: false, ref string_, ref bool_3);
				method_4(list_);
				m_BroadcasterItem = value;
			}
			return m_BroadcasterItem.Value;
		}

		bool IPathNode<ActiveUnit>.IsWalkable(ActiveUnit inContext)
		{
			return VerifyInterruptibleReg(inContext);
		}

		public void ListInterruptibleReg()
		{
			m_BroadcasterItem = false;
		}

		public CandidateItem(double double_0, double double_1)
		{
			_ParserItem = 0f;
			baseItem = double_0;
			m_PolicyItem = double_1;
		}
	}

	private sealed class CustomerDecoratorEntry : IPathNode<ActiveUnit>
	{
		public double m_AlgoItem;

		public double _DatabaseItem;

		private bool? interceptorItem;

		private short? _MessageItem;

		private float m_ProductItem;

		private List<ActiveUnit> _AnnotationItem;

		[SpecialName]
		private short method_0(Scenario scenario_0)
		{
			if (Information.IsNothing(_MessageItem))
			{
				_MessageItem = Terrain.GetElevation(m_AlgoItem, _DatabaseItem, bool_0: false, scenario_0);
			}
			return _MessageItem.Value;
		}

		[SpecialName]
		public float method_1()
		{
			return m_ProductItem;
		}

		[SpecialName]
		public void method_2(float float_0)
		{
			m_ProductItem = float_0;
		}

		[SpecialName]
		public List<ActiveUnit> method_3()
		{
			return _AnnotationItem;
		}

		[SpecialName]
		public void method_4(List<ActiveUnit> list_0)
		{
			_AnnotationItem = list_0;
		}

		internal bool ResolveInterruptibleReg(ActiveUnit activeUnit_0)
		{
			if (Information.IsNothing(interceptorItem))
			{
				double algoItem = m_AlgoItem;
				double databaseItem = _DatabaseItem;
				int int_ = 0;
				bool bool_ = true;
				bool bool_2 = true;
				short? nullable_ = method_0(activeUnit_0.ParentScen);
				List<ActiveUnit> list_ = method_3();
				float float_ = method_1();
				string string_ = "";
				bool bool_3 = false;
				bool value = activeUnit_0.CanMoveToThisLocation(algoItem, databaseItem, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, nullable_, ref list_, float_, bool_6: false, bool_7: false, ref string_, ref bool_3);
				method_4(list_);
				interceptorItem = value;
			}
			return interceptorItem.Value;
		}

		bool IPathNode<ActiveUnit>.IsWalkable(ActiveUnit inContext)
		{
			return ResolveInterruptibleReg(inContext);
		}

		public CustomerDecoratorEntry(double double_0, double double_1)
		{
			m_ProductItem = 0f;
			m_AlgoItem = double_0;
			_DatabaseItem = double_1;
		}

		public void PostInterruptibleReg()
		{
			interceptorItem = false;
		}
	}

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.005f;

	internal List<Waypoint> EnableOrder(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		try
		{
			if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
			{
				return null;
			}
			bool flag = Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3);
			float num = Math.Min((float)(short)Math.Round(Math.Max(double_0, double_2)) + float_1, 90f);
			float num12 = Math.Max((float)(short)Math.Round(Math.Min(double_0, double_2)) - float_1, -90f);
			short num17 = (short)Math.Round(Math.Abs(num - num12) / DegreeInterval_Coarse);
			float num18;
			float num19;
			short num20;
			if (flag)
			{
				num18 = (float)(short)Math.Round(Math.Min(double_1, double_3)) + float_1;
				num19 = (float)(short)Math.Round(Math.Max(double_1, double_3)) - float_1;
				num20 = Math.Abs((short)Math.Round((180f - Math.Abs(num18) + (180f - num19)) / DegreeInterval_Coarse));
			}
			else
			{
				num18 = (float)(short)Math.Round(Math.Min(double_1, double_3)) - float_1;
				num19 = (float)(short)Math.Round(Math.Max(double_1, double_3)) + float_1;
				num20 = Math.Abs((short)Math.Round(Math.Abs(num19 - num18) / DegreeInterval_Coarse));
			}
			if (num17 == 0)
			{
				num17 = 1;
			}
			if (num20 == 0)
			{
				num20 = 1;
			}
			long num21 = (long)num20 * (long)num17;
			CandidateItem[,] candidateItem_ = new CandidateItem[num20 - 1 + 1, num17 - 1 + 1];
			int num22 = num20 - 1;
			short? nullable_ = null;
			short short_ = 0;
			short? nullable_2 = null;
			short short_2 = 0;
			long num23 = 0L;
			for (int i = 0; i <= num22; i++)
			{
				double num2 = (flag ? ((double)Math2.RestartClass(num18 - (float)i * DegreeInterval_Coarse)) : ((double)Math2.RestartClass(num18 + (float)i * DegreeInterval_Coarse)));
				int num3 = num17 - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (!activeUnit_0.ParentScen.ThreadedOpsMustStop)
					{
						double num4 = Math2.ReflectClass(num12 + (float)j * DegreeInterval_Coarse);
						CandidateItem candidateItem = new CandidateItem(num4, num2);
						candidateItem.method_2(float_2);
						candidateItem.method_4(list_0);
						if (bool_0 || !activeUnit_0.IsDestroyed)
						{
							if (candidateItem.VerifyInterruptibleReg(activeUnit_0))
							{
								if (Math.Abs(double_1 - num2) < (double)DegreeInterval_Coarse && (!nullable_.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num4, num2))) < 90f))
								{
									nullable_ = (short)i;
								}
								if (Math.Abs(double_3 - num2) < (double)DegreeInterval_Coarse)
								{
									short_ = (short)i;
								}
								if (Math.Abs(double_0 - num4) < (double)DegreeInterval_Coarse && (!nullable_2.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num4, num2))) < 90f))
								{
									nullable_2 = (short)j;
								}
								if (Math.Abs(double_2 - num4) < (double)DegreeInterval_Coarse)
								{
									short_2 = (short)j;
								}
							}
							candidateItem_[i, j] = candidateItem;
							num23++;
							continue;
						}
						return null;
					}
					return null;
				}
				float_3 = (float)((double)num23 / (double)num21);
			}
			if (!nullable_2.HasValue)
			{
				try
				{
					double num5 = double.MaxValue;
					GeoPoint geoPoint = new GeoPoint(double_1, double_0);
					float num6 = num - DegreeInterval_Coarse;
					float degreeInterval_Coarse = DegreeInterval_Coarse;
					bool flag2 = degreeInterval_Coarse >= 0f;
					float num7 = 0f;
					for (float num8 = num12; (!flag2) ? (num8 >= num6) : (num8 <= num6); num8 += degreeInterval_Coarse)
					{
						double num9 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num8);
						if (num9 < num5)
						{
							num5 = num9;
							num7 = num23;
						}
					}
					nullable_2 = (short)Math.Round(num7);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
			}
			if (!nullable_.HasValue)
			{
				try
				{
					double num10 = double.MaxValue;
					GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
					float num11 = num18;
					float num13 = num19 - DegreeInterval_Coarse;
					float degreeInterval_Coarse2 = DegreeInterval_Coarse;
					bool flag3 = degreeInterval_Coarse2 >= 0f;
					float num14 = num11;
					float num15 = 0f;
					while ((!flag3) ? (num14 >= num13) : (num14 <= num13))
					{
						num14 = Math2.RestartClass(num14);
						double num16 = geoPoint2.RangeToPoint_Horiz_Angular(num14, double_0);
						if (num16 < num10)
						{
							num10 = num16;
							num15 = num23;
						}
						num14 += degreeInterval_Coarse2;
					}
					nullable_ = (short)Math.Round(num15);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
			}
			InitOrder(ref activeUnit_0, ref nullable_, ref nullable_2, ref short_, ref short_2, ref candidateItem_, null, num20, num17);
			if (candidateItem_[nullable_.Value, nullable_2.Value].VerifyInterruptibleReg(activeUnit_0))
			{
				if (candidateItem_[short_, short_2].VerifyInterruptibleReg(activeUnit_0))
				{
					LinkedList<CandidateItem> linkedList = new SpatialAStar<CandidateItem, ActiveUnit>(candidateItem_).Search(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2), activeUnit_0);
					candidateItem_ = null;
					if (Information.IsNothing(linkedList))
					{
						return null;
					}
					List<Waypoint> list = new List<Waypoint>();
					foreach (CandidateItem item in linkedList)
					{
						list.Add(new Waypoint(item.m_PolicyItem, item.baseItem, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
					}
					return list;
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return null;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return null;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101112", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	List<Waypoint> GInterface8.SolvePF_Coarse(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		return EnableOrder(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0, bool_1);
	}

	internal List<Waypoint> ChangeOrder(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0)
	{
		try
		{
			if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
			{
				return null;
			}
			float num = (float)Math.Min(Math.Max(double_0, double_2) + (double)float_1, 90.0);
			float num12 = (float)Math.Max(Math.Min(double_0, double_2) - (double)float_1, -90.0);
			float num16 = (float)Math.Max(Math.Min(double_1, double_3) - (double)float_1, -180.0);
			float num17 = (float)Math.Min(Math.Max(double_1, double_3) + (double)float_1, 180.0);
			short num18 = (short)Math.Round(Math.Abs(num - num12) / DegreeInterval_Finegrained);
			short num19 = (short)Math.Round(Math.Abs(num17 - num16) / DegreeInterval_Finegrained);
			if (num18 == 0)
			{
				num18 = 1;
			}
			if (num19 == 0)
			{
				num19 = 1;
			}
			long num20 = (long)num19 * (long)num18;
			CustomerDecoratorEntry[,] array = new CustomerDecoratorEntry[num19 - 1 + 1, num18 - 1 + 1];
			List<CustomerDecoratorEntry> list = new List<CustomerDecoratorEntry>();
			int num21 = num19 - 1;
			short? nullable_ = null;
			short short_ = 0;
			short? nullable_2 = null;
			short short_2 = 0;
			long num22 = 0L;
			for (int i = 0; i <= num21; i++)
			{
				double num2 = Math2.RestartClass(num16 + (float)i * DegreeInterval_Finegrained);
				int num3 = num18 - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (!activeUnit_0.ParentScen.ThreadedOpsMustStop)
					{
						double num4 = Math2.ReflectClass(num12 + (float)j * DegreeInterval_Finegrained);
						CustomerDecoratorEntry customerDecoratorEntry = new CustomerDecoratorEntry(num4, num2);
						customerDecoratorEntry.method_2(float_2);
						customerDecoratorEntry.method_4(list_0);
						if (customerDecoratorEntry.ResolveInterruptibleReg(activeUnit_0))
						{
							if (Math.Abs(double_1 - num2) < (double)DegreeInterval_Finegrained && (!nullable_.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num4, num2))) < 90f))
							{
								nullable_ = (short)i;
							}
							if (Math.Abs(double_3 - num2) < (double)DegreeInterval_Finegrained)
							{
								short_ = (short)i;
							}
							if (Math.Abs(double_0 - num4) < (double)DegreeInterval_Finegrained && (!nullable_2.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num4, num2))) < 90f))
							{
								nullable_2 = (short)j;
							}
							if (Math.Abs(double_2 - num4) < (double)DegreeInterval_Finegrained)
							{
								short_2 = (short)j;
							}
						}
						array[i, j] = customerDecoratorEntry;
						list.Add(customerDecoratorEntry);
						num22++;
						continue;
					}
					return null;
				}
				float_3 = (float)((double)num22 / (double)num20);
			}
			if (!nullable_2.HasValue)
			{
				try
				{
					double num5 = double.MaxValue;
					GeoPoint geoPoint = new GeoPoint(double_1, double_0);
					float num6 = num;
					float degreeInterval_Coarse = DegreeInterval_Coarse;
					bool flag = degreeInterval_Coarse >= 0f;
					float num7 = 0f;
					for (float num8 = num12; (!flag) ? (num8 >= num6) : (num8 <= num6); num8 += degreeInterval_Coarse)
					{
						double num9 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num8);
						if (num9 < num5)
						{
							num5 = num9;
							num7 = num22;
						}
					}
					nullable_2 = (short)Math.Round(num7);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
			}
			if (!nullable_.HasValue)
			{
				try
				{
					double num10 = double.MaxValue;
					GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
					float num11 = num17 - DegreeInterval_Finegrained;
					float degreeInterval_Finegrained = DegreeInterval_Finegrained;
					bool flag2 = degreeInterval_Finegrained >= 0f;
					float num13 = num16;
					float num14 = 0f;
					while ((!flag2) ? (num13 >= num11) : (num13 <= num11))
					{
						num13 = Math2.RestartClass(num13);
						double num15 = geoPoint2.RangeToPoint_Horiz_Angular(num13, double_0);
						if (num15 < num10)
						{
							num10 = num15;
							num14 = num22;
						}
						num22++;
						num13 += degreeInterval_Finegrained;
					}
					nullable_ = (short)Math.Round(num14);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception exception_2 = ex2;
					exception_2?.Data.Add("Error at 999999", "");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
			}
			CandidateItem[,] candidateItem_ = null;
			InitOrder(ref activeUnit_0, ref nullable_, ref nullable_2, ref short_, ref short_2, ref candidateItem_, array, num19, num18);
			if (array[nullable_.Value, nullable_2.Value].ResolveInterruptibleReg(activeUnit_0))
			{
				if (array[short_, short_2].ResolveInterruptibleReg(activeUnit_0))
				{
					SpatialAStar<CustomerDecoratorEntry, ActiveUnit> spatialAStar = new SpatialAStar<CustomerDecoratorEntry, ActiveUnit>(array);
					LinkedList<CustomerDecoratorEntry> linkedList = null;
					try
					{
						linkedList = spatialAStar.Search(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2), activeUnit_0);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at 200096", exception_3.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					array = null;
					spatialAStar = null;
					if (Information.IsNothing(linkedList))
					{
						return null;
					}
					List<Waypoint> list2 = new List<Waypoint>();
					foreach (CustomerDecoratorEntry item in linkedList)
					{
						list2.Add(new Waypoint(item._DatabaseItem, item.m_AlgoItem, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
					}
					return list2;
				}
				return null;
			}
			return null;
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 101111", "");
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	List<Waypoint> GInterface8.SolvePF_Finegrained(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0)
	{
		return ChangeOrder(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0);
	}

	private void InitOrder(ref ActiveUnit activeUnit_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref CandidateItem[,] candidateItem_0, CustomerDecoratorEntry[,] customerDecoratorEntry_0, short short_2, short short_3)
	{
		bool flag = false;
		bool flag2 = false;
		short num = 1;
		short num12 = 1;
		short num23 = 0;
		short num31 = 0;
		short num32 = nullable_0.Value;
		short num33 = nullable_1.Value;
		short num34 = short_0;
		short num35 = short_1;
		int num36 = 0;
		int num2 = Math.Min(short_2, short_3);
		try
		{
			do
			{
				if (!flag)
				{
					int num3 = 0;
					if (!Information.IsNothing(candidateItem_0) && candidateItem_0[nullable_0.Value, nullable_1.Value].VerifyInterruptibleReg(activeUnit_0))
					{
						if (num33 != short_3 - 1 && candidateItem_0[num32, num33 + 1].VerifyInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num33 != 0 && candidateItem_0[num32, num33 - 1].VerifyInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num32 != 0 && candidateItem_0[num32 - 1, num33].VerifyInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && candidateItem_0[num32 + 1, num33].VerifyInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
					}
					else if (!Information.IsNothing(customerDecoratorEntry_0) && customerDecoratorEntry_0[nullable_0.Value, nullable_1.Value].ResolveInterruptibleReg(activeUnit_0))
					{
						if (num33 != short_3 - 1 && customerDecoratorEntry_0[num32, num33 + 1].ResolveInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num33 != 0 && customerDecoratorEntry_0[num32, num33 - 1].ResolveInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num32 != 0 && customerDecoratorEntry_0[num32 - 1, num33].ResolveInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && customerDecoratorEntry_0[num32 + 1, num33].ResolveInterruptibleReg(activeUnit_0))
						{
							num3++;
						}
					}
					if (num3 <= 0)
					{
						if (!Information.IsNothing(candidateItem_0))
						{
							candidateItem_0[num32, num33].ListInterruptibleReg();
						}
						if (!Information.IsNothing(customerDecoratorEntry_0))
						{
							customerDecoratorEntry_0[num32, num33].PostInterruptibleReg();
						}
						double num4 = double.MaxValue;
						short num5 = (short)(num * 2 + 1);
						num23 = 0;
						short num6 = (short)((num == 1) ? 1 : ((short)Math.Round((double)(num5 + 1) / 2.0)));
						short num7 = (short)(nullable_0.Value - num);
						short num8 = (short)(nullable_1.Value - num);
						short num9 = (short)(num5 - 1);
						for (short num10 = 0; num10 <= num9; num10++)
						{
							short num11 = (short)(num7 + num10);
							if (num11 >= 0 && num11 <= short_2 - 1)
							{
								short num13 = (short)(num5 - 1);
								for (short num14 = 0; num14 <= num13; num14++)
								{
									if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num15 = (short)(num8 + num14);
									if (num15 >= 0 && num15 <= short_3 - 1 && (num10 == 0 || num10 == num5 - 1 || num14 == 0 || num14 == num5 - 1) && ((!Information.IsNothing(candidateItem_0) && candidateItem_0[num11, num15].VerifyInterruptibleReg(activeUnit_0)) || (!Information.IsNothing(customerDecoratorEntry_0) && customerDecoratorEntry_0[num11, num15].ResolveInterruptibleReg(activeUnit_0))))
									{
										double num16 = Math.Min(Math.Abs((short)(num10 - num6)), Math.Abs((short)(num14 - num6)));
										if (num16 < num4)
										{
											num4 = num16;
											num32 = num11;
											num33 = num15;
										}
										num23++;
									}
								}
							}
						}
						nullable_0 = num32;
						nullable_1 = num33;
						if (num23 == 0)
						{
							num++;
						}
					}
					else
					{
						flag = true;
					}
				}
				if (!flag2)
				{
					int num17 = 0;
					if (!Information.IsNothing(candidateItem_0) && candidateItem_0[short_0, short_1].VerifyInterruptibleReg(activeUnit_0))
					{
						if (num35 != short_3 - 1 && candidateItem_0[num34, num35 + 1].VerifyInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num35 != 0 && candidateItem_0[num34, num35 - 1].VerifyInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num34 != 0 && candidateItem_0[num34 - 1, num35].VerifyInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && candidateItem_0[num34 + 1, num35].VerifyInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
					}
					else if (!Information.IsNothing(customerDecoratorEntry_0) && customerDecoratorEntry_0[short_0, short_1].ResolveInterruptibleReg(activeUnit_0))
					{
						if (num35 != short_3 - 1 && customerDecoratorEntry_0[num34, num35 + 1].ResolveInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num35 != 0 && customerDecoratorEntry_0[num34, num35 - 1].ResolveInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num34 != 0 && customerDecoratorEntry_0[num34 - 1, num35].ResolveInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && customerDecoratorEntry_0[num34 + 1, num35].ResolveInterruptibleReg(activeUnit_0))
						{
							num17++;
						}
					}
					if (num17 <= 0)
					{
						if (!Information.IsNothing(candidateItem_0))
						{
							candidateItem_0[num34, num35].ListInterruptibleReg();
						}
						if (!Information.IsNothing(customerDecoratorEntry_0))
						{
							customerDecoratorEntry_0[num34, num35].PostInterruptibleReg();
						}
						double num18 = double.MaxValue;
						short num19 = (short)(num * 2 + 1);
						num31 = 0;
						short num20 = (short)((num12 == 1) ? 1 : ((short)Math.Round((double)(num19 + 1) / 2.0)));
						short num21 = (short)(short_0 - num12);
						short num22 = (short)(short_1 - num12);
						short num24 = (short)(num19 - 1);
						for (short num25 = 0; num25 <= num24; num25++)
						{
							short num26 = (short)(num21 + num25);
							if (num26 >= 0 && num26 <= short_2 - 1)
							{
								short num27 = (short)(num19 - 1);
								for (short num28 = 0; num28 <= num27; num28++)
								{
									if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num29 = (short)(num22 + num28);
									if (num29 >= 0 && num29 <= short_3 - 1 && (num25 == 0 || num25 == num19 - 1 || num28 == 0 || num28 == num19 - 1) && ((!Information.IsNothing(candidateItem_0) && candidateItem_0[num26, num29].VerifyInterruptibleReg(activeUnit_0)) || (!Information.IsNothing(customerDecoratorEntry_0) && customerDecoratorEntry_0[num26, num29].ResolveInterruptibleReg(activeUnit_0))))
									{
										double num30 = Math.Min(Math.Abs((short)(num25 - num20)), Math.Abs((short)(num28 - num20)));
										if (num30 < num18)
										{
											num18 = num30;
											num34 = num26;
											num35 = num29;
										}
										num31++;
									}
								}
							}
						}
						short_0 = num34;
						short_1 = num35;
						if (num31 == 0)
						{
							num12++;
						}
					}
					else
					{
						flag2 = true;
					}
				}
				if (!(flag && flag2))
				{
					num36++;
					continue;
				}
				break;
			}
			while (num2 != num36);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101267", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
