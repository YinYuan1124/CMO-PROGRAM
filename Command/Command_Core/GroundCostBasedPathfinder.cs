using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Algorithms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class GroundCostBasedPathfinder : GInterface8
{
	private sealed class RegistryMerchantPage
	{
		public double ruleItem;

		public double _CollectionItem;

		private bool? m_InstanceItem;

		private short? m_ObjectItem;

		private int m_ParameterItem;

		private List<ActiveUnit> _ExpressionItem;

		private float _DispatcherItem;

		[SpecialName]
		public short method_0(Scenario scenario_0)
		{
			if (Information.IsNothing(m_ObjectItem))
			{
				m_ObjectItem = Pathfinding._PredicateConsumer.GetElev(ruleItem, _CollectionItem, scenario_0);
			}
			return m_ObjectItem.Value;
		}

		[SpecialName]
		public float method_1()
		{
			return _DispatcherItem;
		}

		[SpecialName]
		public void method_2(float float_0)
		{
			_DispatcherItem = float_0;
		}

		[SpecialName]
		public List<ActiveUnit> method_3()
		{
			return _ExpressionItem;
		}

		[SpecialName]
		public void method_4(List<ActiveUnit> list_0)
		{
			_ExpressionItem = list_0;
		}

		[SpecialName]
		public int method_5()
		{
			return m_ParameterItem;
		}

		[SpecialName]
		public void method_6(int int_0)
		{
			m_ParameterItem = int_0;
		}

		internal bool SelectInterruptibleQueue(ActiveUnit activeUnit_0)
		{
			if (!m_InstanceItem.HasValue)
			{
				double double_ = ruleItem;
				double collectionItem = _CollectionItem;
				int int_ = method_5();
				bool bool_ = true;
				bool bool_2 = true;
				short? nullable_ = method_0(activeUnit_0.ParentScen);
				List<ActiveUnit> list_ = method_3();
				float float_ = method_1();
				string string_ = "";
				bool bool_3 = false;
				bool value = activeUnit_0.CanMoveToThisLocation(double_, collectionItem, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, nullable_, ref list_, float_, bool_6: false, bool_7: false, ref string_, ref bool_3);
				method_4(list_);
				method_6(int_);
				m_InstanceItem = value;
			}
			return m_InstanceItem.Value;
		}

		public void CallInterruptibleQueue()
		{
			m_InstanceItem = false;
		}

		public RegistryMerchantPage(double double_0, double double_1)
		{
			_DispatcherItem = 0f;
			ruleItem = double_0;
			_CollectionItem = double_1;
		}
	}

	private sealed class ListenerItem
	{
		public double _ConfigItem;

		public double m_RegistryItem;

		private bool? definitionItem;

		private short? m_ValItem;

		public int m_WrapperItem;

		private float observerItem;

		private List<ActiveUnit> m_IssuerItem;

		[SpecialName]
		public void method_0(float float_0)
		{
			observerItem = float_0;
		}

		[SpecialName]
		public void method_1(List<ActiveUnit> list_0)
		{
			m_IssuerItem = list_0;
		}

		internal bool LogoutInterruptibleQueue(ActiveUnit activeUnit_0)
		{
			if (!definitionItem.HasValue)
			{
				if (!m_ValItem.HasValue)
				{
					m_ValItem = Terrain.GetElevation(_ConfigItem, m_RegistryItem, bool_0: false, activeUnit_0.ParentScen);
				}
				double configItem = _ConfigItem;
				double registryItem = m_RegistryItem;
				ref int wrapperItem = ref m_WrapperItem;
				bool bool_ = true;
				bool bool_2 = true;
				short? valItem = m_ValItem;
				ref List<ActiveUnit> issuerItem = ref m_IssuerItem;
				float float_ = observerItem;
				string string_ = "";
				bool bool_3 = false;
				definitionItem = activeUnit_0.CanMoveToThisLocation(configItem, registryItem, ref wrapperItem, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, valItem, ref issuerItem, float_, bool_6: false, bool_7: false, ref string_, ref bool_3);
			}
			return definitionItem.Value;
		}

		public ListenerItem(double double_0, double double_1)
		{
			observerItem = 0f;
			_ConfigItem = double_0;
			m_RegistryItem = double_1;
		}

		public void ViewInterruptibleQueue()
		{
			definitionItem = false;
		}
	}

	public const int MAX_PATHGRID_ALLOCATE = 4096;

	public const float DEGREE_INTERVAL_COARSE = 0.05f;

	public const float DEGREE_INTERVAL_FINE = 0.025f;

	public const double MAX_SOLVABLE_DEGREES = 102.4000015258789;

	public const int MIN_INTERCONTINENTAL_CHECK = 1800;

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.025f;

	public static bool CanSolve(double double_0, double double_1, double double_2, double double_3)
	{
		if (Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3))
		{
			if (double_1 <= 0.0)
			{
				if (Math.Abs(double_0 - double_2) <= 102.4000015258789)
				{
					return Math.Abs(180.0 - double_3 + (180.0 + double_1)) <= 102.4000015258789;
				}
				return false;
			}
			if (Math.Abs(double_0 - double_2) <= 102.4000015258789)
			{
				return Math.Abs(180.0 - double_1 + (180.0 + double_3)) <= 102.4000015258789;
			}
			return false;
		}
		if (Math.Abs(double_0 - double_2) <= 102.4000015258789)
		{
			return Math.Abs(double_1 - double_3) <= 102.4000015258789;
		}
		return false;
	}

	internal List<Waypoint> StopInvocation(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		throw new Exception();
	}

	List<Waypoint> GInterface8.SolvePF_Coarse(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		return StopInvocation(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0, bool_1);
	}

	private bool CancelInvocation(int int_0, double double_0, double double_1, double double_2, double double_3)
	{
		if (int_0 > 1800)
		{
			if (double_0 < -60.0 && double_2 >= -60.0)
			{
				return true;
			}
			if (double_0 < -10.0 && double_0 > -40.0 && double_1 > 110.0 && double_1 < 160.0 && (double_2 >= -10.0 || double_2 <= -40.0 || double_3 <= 110.0 || double_3 >= 160.0))
			{
				return true;
			}
			if (double_1 > -20.0 && double_1 < 168.5)
			{
				if (double_3 <= -20.0 || double_3 >= 168.5)
				{
					return true;
				}
			}
			else if (double_3 >= -20.0 && double_3 <= 168.5)
			{
				return true;
			}
		}
		return false;
	}

	internal List<Waypoint> VerifyInvocation(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0)
	{
		if (activeUnit_0.IsFacility)
		{
			Facility facility_ = (Facility)activeUnit_0;
			try
			{
				if (facility_.ParentScen.ThreadedOpsMustStop)
				{
					return null;
				}
				bool flag = Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3);
				float num = Math.Min((float)(short)Math.Round(Math.Max(double_0, double_2)) + float_1, 90f);
				float num12 = Math.Max((float)(short)Math.Round(Math.Min(double_0, double_2)) - float_1, -90f);
				short num23 = (short)Math.Round(Math.Abs(num - num12) / DegreeInterval_Finegrained);
				float num34;
				float num45;
				short num52;
				if (flag)
				{
					num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) + float_1;
					num45 = (float)(short)Math.Round(Math.Max(double_1, double_3)) - float_1;
					num52 = Math.Abs((short)Math.Round((180f - Math.Abs(num34) + (180f - num45)) / DegreeInterval_Finegrained));
				}
				else
				{
					num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) - float_1;
					num45 = (float)(short)Math.Round(Math.Max(double_1, double_3)) + float_1;
					num52 = Math.Abs((short)Math.Round(Math.Abs(num45 - num34) / DegreeInterval_Finegrained));
				}
				long num53 = (long)num52 * (long)num23;
				facility_.Doctrine.GetLandNavigation(facility_.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				int i;
				for (i = 1; !(Math.Pow(2.0, i) > (double)num23) || !(Math.Pow(2.0, i) > (double)num52); i++)
				{
				}
				int num54 = (int)Math.Round(Math.Pow(2.0, i));
				int num55 = (int)Math.Round(Math.Pow(2.0, i));
				if (num54 <= 4096 && !CancelInvocation(num54, double_0, double_1, double_2, double_3))
				{
					ListenerItem[,] array = new ListenerItem[num55 - 1 + 1, num54 - 1 + 1];
					int num2 = num52 - 1;
					short? nullable_ = null;
					short short_ = 0;
					short? nullable_2 = null;
					short short_2 = 0;
					long num3 = 0L;
					for (int j = 0; j <= num2; j++)
					{
						double num4 = (flag ? ((double)Math2.RestartClass(num34 - (float)j * DegreeInterval_Finegrained)) : ((double)Math2.RestartClass(num34 + (float)j * DegreeInterval_Finegrained)));
						int num5 = num23 - 1;
						for (int k = 0; k <= num5; k++)
						{
							if (!facility_.ParentScen.ThreadedOpsMustStop)
							{
								if (bool_0 || !facility_.IsDestroyed)
								{
									double num6 = Math2.ReflectClass(num12 + (float)k * DegreeInterval_Finegrained);
									ListenerItem listenerItem = new ListenerItem(num6, num4);
									listenerItem.method_0(float_2);
									listenerItem.method_1(list_0);
									if (listenerItem.LogoutInterruptibleQueue(facility_))
									{
										int maximumSpeed = facility_.Kinematics.GetMaximumSpeed();
										int maximumSpeedAtThisLocation = facility_.Kinematics.GetMaximumSpeedAtThisLocation(num6, num4, bool_0: false);
										listenerItem.m_WrapperItem = ((maximumSpeedAtThisLocation != 0) ? ((maximumSpeed <= maximumSpeedAtThisLocation) ? 1 : ((int)Math.Round(100.0 * Math.Pow(maximumSpeed - maximumSpeedAtThisLocation, 2.0)))) : 0);
										if (Math.Abs(double_1 - num4) < (double)DegreeInterval_Finegrained && (!nullable_.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
										{
											nullable_ = (short)j;
										}
										if (Math.Abs(double_3 - num4) < (double)DegreeInterval_Finegrained)
										{
											short_ = (short)j;
										}
										if (Math.Abs(double_0 - num6) < (double)DegreeInterval_Finegrained && (!nullable_2.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
										{
											nullable_2 = (short)k;
										}
										if (Math.Abs(double_2 - num6) < (double)DegreeInterval_Finegrained)
										{
											short_2 = (short)k;
										}
									}
									else
									{
										listenerItem.m_WrapperItem = 0;
									}
									array[j, k] = listenerItem;
									num3++;
									continue;
								}
								return null;
							}
							return null;
						}
						float_3 = (float)((double)num3 / (double)num53);
					}
					if (!nullable_2.HasValue)
					{
						try
						{
							double num7 = double.MaxValue;
							GeoPoint geoPoint = new GeoPoint(double_1, double_0);
							num3 = 0L;
							float num8 = num;
							float degreeInterval_Finegrained = DegreeInterval_Finegrained;
							bool flag2 = degreeInterval_Finegrained >= 0f;
							for (float num9 = num12; (!flag2) ? (num9 >= num8) : (num9 <= num8); num9 += degreeInterval_Finegrained)
							{
								double num10 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num9);
								if (num10 < num7)
								{
									num7 = num10;
									nullable_2 = (short)num3;
								}
								num3++;
							}
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
							double num11 = double.MaxValue;
							GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
							num3 = 0L;
							float num13 = num34;
							float num14 = num45;
							float degreeInterval_Finegrained2 = DegreeInterval_Finegrained;
							bool flag3 = degreeInterval_Finegrained2 >= 0f;
							float num15 = num13;
							while ((!flag3) ? (num15 >= num14) : (num15 <= num14))
							{
								num15 = Math2.RestartClass(num15);
								double num16 = geoPoint2.RangeToPoint_Horiz_Angular(num15, double_0);
								if (num16 < num11)
								{
									num11 = num16;
									nullable_ = (short)num3;
								}
								num3++;
								num15 += degreeInterval_Finegrained2;
							}
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
					RegistryMerchantPage[,] registryMerchantPage_ = null;
					ResolveInvocation(ref facility_, ref nullable_, ref nullable_2, ref short_, ref short_2, ref registryMerchantPage_, array, num52, num23);
					int[,] array2 = new int[num55 - 1 + 1, num54 - 1 + 1];
					int num17 = num55 - 1;
					for (int l = 0; l <= num17; l++)
					{
						int num18 = num54 - 1;
						for (int m = 0; m <= num18; m++)
						{
							if (Information.IsNothing(array[l, m]))
							{
								array2[l, m] = 0;
							}
							else
							{
								array2[l, m] = array[l, m].m_WrapperItem;
							}
						}
					}
					List<PathFinderNode> list = new PathFinderFast(array2)
					{
						Formula = HeuristicFormula.Euclidean,
						Diagonals = true,
						HeavyDiagonals = false,
						PunishChangeDirection = true,
						PunishWalkingOnEdge = false,
						TrimAutoNavPoints = true,
						TieBreaker = true,
						SearchLimit = int.MaxValue,
						DebugProgress = false,
						ReopenCloseNodes = true,
						EdgeCost = 0
					}.FindPath(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2));
					if (list == null)
					{
						return null;
					}
					List<Waypoint> list2 = new List<Waypoint>();
					list.Reverse();
					foreach (PathFinderNode item in list)
					{
						double double_4 = (flag ? ((double)Math2.RestartClass(num34 - (float)item.X * DegreeInterval_Finegrained)) : ((double)Math2.RestartClass(num34 + (float)item.X * DegreeInterval_Finegrained)));
						double double_5 = Math2.ReflectClass(num12 + (float)item.Y * DegreeInterval_Finegrained);
						list2.Add(new Waypoint(double_4, double_5, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
					}
					return list2;
				}
				return null;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 101334", "");
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
		}
		Vehicle vehicle_ = (Vehicle)activeUnit_0;
		try
		{
			if (vehicle_.ParentScen.ThreadedOpsMustStop)
			{
				return null;
			}
			bool flag4 = Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3);
			float num19 = Math.Min((float)(short)Math.Round(Math.Max(double_0, double_2)) + float_1, 90f);
			float num20 = Math.Max((float)(short)Math.Round(Math.Min(double_0, double_2)) - float_1, -90f);
			short num21 = (short)Math.Round(Math.Abs(num19 - num20) / DegreeInterval_Finegrained);
			float num22;
			float num24;
			short num25;
			if (flag4)
			{
				num22 = (float)(short)Math.Round(Math.Min(double_1, double_3)) + float_1;
				num24 = (float)(short)Math.Round(Math.Max(double_1, double_3)) - float_1;
				num25 = Math.Abs((short)Math.Round((180f - Math.Abs(num22) + (180f - num24)) / DegreeInterval_Finegrained));
			}
			else
			{
				num22 = (float)(short)Math.Round(Math.Min(double_1, double_3)) - float_1;
				num24 = (float)(short)Math.Round(Math.Max(double_1, double_3)) + float_1;
				num25 = Math.Abs((short)Math.Round(Math.Abs(num24 - num22) / DegreeInterval_Finegrained));
			}
			long num26 = (long)num25 * (long)num21;
			vehicle_.Doctrine.GetLandNavigation(vehicle_.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			int n;
			for (n = 1; !(Math.Pow(2.0, n) > (double)num21) || !(Math.Pow(2.0, n) > (double)num25); n++)
			{
			}
			int num27 = (int)Math.Round(Math.Pow(2.0, n));
			int num28 = (int)Math.Round(Math.Pow(2.0, n));
			if (num27 <= 4096 && !CancelInvocation(num27, double_0, double_1, double_2, double_3))
			{
				ListenerItem[,] array3 = new ListenerItem[num28 - 1 + 1, num27 - 1 + 1];
				int num29 = num25 - 1;
				short? nullable_3 = null;
				short short_3 = 0;
				short? nullable_4 = null;
				short short_4 = 0;
				long num30 = 0L;
				for (int num31 = 0; num31 <= num29; num31++)
				{
					double num32 = (flag4 ? ((double)Math2.RestartClass(num22 - (float)num31 * DegreeInterval_Finegrained)) : ((double)Math2.RestartClass(num22 + (float)num31 * DegreeInterval_Finegrained)));
					int num33 = num21 - 1;
					for (int num35 = 0; num35 <= num33; num35++)
					{
						if (!vehicle_.ParentScen.ThreadedOpsMustStop)
						{
							if (bool_0 || !vehicle_.IsDestroyed)
							{
								double num36 = Math2.ReflectClass(num20 + (float)num35 * DegreeInterval_Finegrained);
								ListenerItem listenerItem2 = new ListenerItem(num36, num32);
								listenerItem2.method_0(float_2);
								listenerItem2.method_1(list_0);
								if (listenerItem2.LogoutInterruptibleQueue(vehicle_))
								{
									int maximumSpeed2 = vehicle_.Kinematics.GetMaximumSpeed();
									int num37 = Convert.ToInt32(vehicle_.Kinematics.PatchReponse(num36, num32));
									listenerItem2.m_WrapperItem = ((num37 != 0) ? ((maximumSpeed2 <= num37) ? 1 : ((int)Math.Round(100.0 * Math.Pow(maximumSpeed2 - num37, 2.0)))) : 0);
									if (Math.Abs(double_1 - num32) < (double)DegreeInterval_Finegrained && (!nullable_3.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num36, num32))) < 90f))
									{
										nullable_3 = (short)num31;
									}
									if (Math.Abs(double_3 - num32) < (double)DegreeInterval_Finegrained)
									{
										short_3 = (short)num31;
									}
									if (Math.Abs(double_0 - num36) < (double)DegreeInterval_Finegrained && (!nullable_4.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num36, num32))) < 90f))
									{
										nullable_4 = (short)num35;
									}
									if (Math.Abs(double_2 - num36) < (double)DegreeInterval_Finegrained)
									{
										short_4 = (short)num35;
									}
								}
								else
								{
									listenerItem2.m_WrapperItem = 0;
								}
								array3[num31, num35] = listenerItem2;
								num30++;
								continue;
							}
							return null;
						}
						return null;
					}
					float_3 = (float)((double)num30 / (double)num26);
				}
				if (!nullable_4.HasValue)
				{
					try
					{
						double num38 = double.MaxValue;
						GeoPoint geoPoint3 = new GeoPoint(double_1, double_0);
						num30 = 0L;
						float num39 = num19;
						float degreeInterval_Finegrained3 = DegreeInterval_Finegrained;
						bool flag5 = degreeInterval_Finegrained3 >= 0f;
						for (float num40 = num20; (!flag5) ? (num40 >= num39) : (num40 <= num39); num40 += degreeInterval_Finegrained3)
						{
							double num41 = geoPoint3.RangeToPoint_Horiz_Angular(double_1, num40);
							if (num41 < num38)
							{
								num38 = num41;
								nullable_4 = (short)num30;
							}
							num30++;
						}
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 999999", "");
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return null;
					}
				}
				if (!nullable_3.HasValue)
				{
					try
					{
						double num42 = double.MaxValue;
						GeoPoint geoPoint4 = new GeoPoint(double_1, double_0);
						num30 = 0L;
						float num43 = num22;
						float num44 = num24;
						float degreeInterval_Finegrained4 = DegreeInterval_Finegrained;
						bool flag6 = degreeInterval_Finegrained4 >= 0f;
						float num46 = num43;
						while ((!flag6) ? (num46 >= num44) : (num46 <= num44))
						{
							num46 = Math2.RestartClass(num46);
							double num47 = geoPoint4.RangeToPoint_Horiz_Angular(num46, double_0);
							if (num47 < num42)
							{
								num42 = num47;
								nullable_3 = (short)num30;
							}
							num30++;
							num46 += degreeInterval_Finegrained4;
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception exception_5 = ex5;
						exception_5?.Data.Add("Error at 999999", "");
						GameGeneral.WriteExceptionsToLog(ref exception_5);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return null;
					}
				}
				RegistryMerchantPage[,] registryMerchantPage_2 = null;
				PostInvocation(ref vehicle_, ref nullable_3, ref nullable_4, ref short_3, ref short_4, ref registryMerchantPage_2, array3, num25, num21);
				int[,] array4 = new int[num28 - 1 + 1, num27 - 1 + 1];
				int num48 = num28 - 1;
				for (int num49 = 0; num49 <= num48; num49++)
				{
					int num50 = num27 - 1;
					for (int num51 = 0; num51 <= num50; num51++)
					{
						if (Information.IsNothing(array3[num49, num51]))
						{
							array4[num49, num51] = 0;
						}
						else
						{
							array4[num49, num51] = array3[num49, num51].m_WrapperItem;
						}
					}
				}
				List<PathFinderNode> list3 = new PathFinderFast(array4)
				{
					Formula = HeuristicFormula.Euclidean,
					Diagonals = true,
					HeavyDiagonals = false,
					PunishChangeDirection = true,
					PunishWalkingOnEdge = false,
					TrimAutoNavPoints = true,
					TieBreaker = true,
					SearchLimit = int.MaxValue,
					DebugProgress = false,
					ReopenCloseNodes = true,
					EdgeCost = 0
				}.FindPath(new Point(nullable_3.Value, nullable_4.Value), new Point(short_3, short_4));
				if (list3 == null)
				{
					return null;
				}
				List<Waypoint> list4 = new List<Waypoint>();
				list3.Reverse();
				foreach (PathFinderNode item2 in list3)
				{
					double double_6 = (flag4 ? ((double)Math2.RestartClass(num22 - (float)item2.X * DegreeInterval_Finegrained)) : ((double)Math2.RestartClass(num22 + (float)item2.X * DegreeInterval_Finegrained)));
					double double_7 = Math2.ReflectClass(num20 + (float)item2.Y * DegreeInterval_Finegrained);
					list4.Add(new Waypoint(double_6, double_7, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
				}
				return list4;
			}
			return null;
		}
		catch (Exception ex6)
		{
			ProjectData.SetProjectError(ex6);
			Exception exception_6 = ex6;
			exception_6?.Data.Add("Error at 101334", "");
			GameGeneral.WriteExceptionsToLog(ref exception_6);
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
		return VerifyInvocation(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0);
	}

	private void ListInvocation(ref ListenerItem[,] listenerItem_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && listenerItem_0[int_0, int_1 - 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && listenerItem_0[int_0 + 1, int_1 - 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_0 < int_4 - 1 && listenerItem_0[int_0 + 1, int_1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && listenerItem_0[int_0 + 1, int_1 + 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_1 < int_5 - 1 && listenerItem_0[int_0, int_1 + 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && listenerItem_0[int_0 - 1, int_1 + 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_0 > 0 && listenerItem_0[int_0 - 1, int_1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && listenerItem_0[int_0 - 1, int_1 - 1].m_WrapperItem == int_2)
			{
				listenerItem_0[int_0, int_1].m_WrapperItem = int_3;
			}
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
		}
	}

	private void ResolveInvocation(ref Facility facility_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref RegistryMerchantPage[,] registryMerchantPage_0, ListenerItem[,] listenerItem_0, short short_2, short short_3)
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
					if (!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[nullable_0.Value, nullable_1.Value].SelectInterruptibleQueue(facility_0))
					{
						if (num33 != short_3 - 1 && registryMerchantPage_0[num32, num33 + 1].SelectInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num33 != 0 && registryMerchantPage_0[num32, num33 - 1].SelectInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num32 != 0 && registryMerchantPage_0[num32 - 1, num33].SelectInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && registryMerchantPage_0[num32 + 1, num33].SelectInterruptibleQueue(facility_0))
						{
							num3++;
						}
					}
					else if (!Information.IsNothing(listenerItem_0) && listenerItem_0[nullable_0.Value, nullable_1.Value].LogoutInterruptibleQueue(facility_0))
					{
						if (num33 != short_3 - 1 && listenerItem_0[num32, num33 + 1].LogoutInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num33 != 0 && listenerItem_0[num32, num33 - 1].LogoutInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num32 != 0 && listenerItem_0[num32 - 1, num33].LogoutInterruptibleQueue(facility_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && listenerItem_0[num32 + 1, num33].LogoutInterruptibleQueue(facility_0))
						{
							num3++;
						}
					}
					if (num3 <= 0)
					{
						if (!Information.IsNothing(registryMerchantPage_0))
						{
							registryMerchantPage_0[num32, num33].CallInterruptibleQueue();
						}
						if (!Information.IsNothing(listenerItem_0))
						{
							listenerItem_0[num32, num33].ViewInterruptibleQueue();
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
									if (facility_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num15 = (short)(num8 + num14);
									if (num15 >= 0 && num15 <= short_3 - 1 && (num10 == 0 || num10 == num5 - 1 || num14 == 0 || num14 == num5 - 1) && ((!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[num11, num15].SelectInterruptibleQueue(facility_0)) || (!Information.IsNothing(listenerItem_0) && listenerItem_0[num11, num15].LogoutInterruptibleQueue(facility_0))))
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
					if (!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[short_0, short_1].SelectInterruptibleQueue(facility_0))
					{
						if (num35 != short_3 - 1 && registryMerchantPage_0[num34, num35 + 1].SelectInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num35 != 0 && registryMerchantPage_0[num34, num35 - 1].SelectInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num34 != 0 && registryMerchantPage_0[num34 - 1, num35].SelectInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && registryMerchantPage_0[num34 + 1, num35].SelectInterruptibleQueue(facility_0))
						{
							num17++;
						}
					}
					else if (!Information.IsNothing(listenerItem_0) && listenerItem_0[short_0, short_1].LogoutInterruptibleQueue(facility_0))
					{
						if (num35 != short_3 - 1 && listenerItem_0[num34, num35 + 1].LogoutInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num35 != 0 && listenerItem_0[num34, num35 - 1].LogoutInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num34 != 0 && listenerItem_0[num34 - 1, num35].LogoutInterruptibleQueue(facility_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && listenerItem_0[num34 + 1, num35].LogoutInterruptibleQueue(facility_0))
						{
							num17++;
						}
					}
					if (num17 <= 0)
					{
						if (!Information.IsNothing(registryMerchantPage_0))
						{
							registryMerchantPage_0[num34, num35].CallInterruptibleQueue();
						}
						if (!Information.IsNothing(listenerItem_0))
						{
							listenerItem_0[num34, num35].ViewInterruptibleQueue();
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
									if (facility_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num29 = (short)(num22 + num28);
									if (num29 >= 0 && num29 <= short_3 - 1 && (num25 == 0 || num25 == num19 - 1 || num28 == 0 || num28 == num19 - 1) && ((!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[num26, num29].SelectInterruptibleQueue(facility_0)) || (!Information.IsNothing(listenerItem_0) && listenerItem_0[num26, num29].LogoutInterruptibleQueue(facility_0))))
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
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PostInvocation(ref Vehicle vehicle_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref RegistryMerchantPage[,] registryMerchantPage_0, ListenerItem[,] listenerItem_0, short short_2, short short_3)
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
					if (!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[nullable_0.Value, nullable_1.Value].SelectInterruptibleQueue(vehicle_0))
					{
						if (num33 != short_3 - 1 && registryMerchantPage_0[num32, num33 + 1].SelectInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num33 != 0 && registryMerchantPage_0[num32, num33 - 1].SelectInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num32 != 0 && registryMerchantPage_0[num32 - 1, num33].SelectInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && registryMerchantPage_0[num32 + 1, num33].SelectInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
					}
					else if (!Information.IsNothing(listenerItem_0) && listenerItem_0[nullable_0.Value, nullable_1.Value].LogoutInterruptibleQueue(vehicle_0))
					{
						if (num33 != short_3 - 1 && listenerItem_0[num32, num33 + 1].LogoutInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num33 != 0 && listenerItem_0[num32, num33 - 1].LogoutInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num32 != 0 && listenerItem_0[num32 - 1, num33].LogoutInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && listenerItem_0[num32 + 1, num33].LogoutInterruptibleQueue(vehicle_0))
						{
							num3++;
						}
					}
					if (num3 <= 0)
					{
						if (!Information.IsNothing(registryMerchantPage_0))
						{
							registryMerchantPage_0[num32, num33].CallInterruptibleQueue();
						}
						if (!Information.IsNothing(listenerItem_0))
						{
							listenerItem_0[num32, num33].ViewInterruptibleQueue();
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
									if (vehicle_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num15 = (short)(num8 + num14);
									if (num15 >= 0 && num15 <= short_3 - 1 && (num10 == 0 || num10 == num5 - 1 || num14 == 0 || num14 == num5 - 1) && ((!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[num11, num15].SelectInterruptibleQueue(vehicle_0)) || (!Information.IsNothing(listenerItem_0) && listenerItem_0[num11, num15].LogoutInterruptibleQueue(vehicle_0))))
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
					if (!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[short_0, short_1].SelectInterruptibleQueue(vehicle_0))
					{
						if (num35 != short_3 - 1 && registryMerchantPage_0[num34, num35 + 1].SelectInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num35 != 0 && registryMerchantPage_0[num34, num35 - 1].SelectInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num34 != 0 && registryMerchantPage_0[num34 - 1, num35].SelectInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && registryMerchantPage_0[num34 + 1, num35].SelectInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
					}
					else if (!Information.IsNothing(listenerItem_0) && listenerItem_0[short_0, short_1].LogoutInterruptibleQueue(vehicle_0))
					{
						if (num35 != short_3 - 1 && listenerItem_0[num34, num35 + 1].LogoutInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num35 != 0 && listenerItem_0[num34, num35 - 1].LogoutInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num34 != 0 && listenerItem_0[num34 - 1, num35].LogoutInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && listenerItem_0[num34 + 1, num35].LogoutInterruptibleQueue(vehicle_0))
						{
							num17++;
						}
					}
					if (num17 <= 0)
					{
						if (!Information.IsNothing(registryMerchantPage_0))
						{
							registryMerchantPage_0[num34, num35].CallInterruptibleQueue();
						}
						if (!Information.IsNothing(listenerItem_0))
						{
							listenerItem_0[num34, num35].ViewInterruptibleQueue();
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
									if (vehicle_0.ParentScen.ThreadedOpsMustStop)
									{
										return;
									}
									short num29 = (short)(num22 + num28);
									if (num29 >= 0 && num29 <= short_3 - 1 && (num25 == 0 || num25 == num19 - 1 || num28 == 0 || num28 == num19 - 1) && ((!Information.IsNothing(registryMerchantPage_0) && registryMerchantPage_0[num26, num29].SelectInterruptibleQueue(vehicle_0)) || (!Information.IsNothing(listenerItem_0) && listenerItem_0[num26, num29].LogoutInterruptibleQueue(vehicle_0))))
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
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
