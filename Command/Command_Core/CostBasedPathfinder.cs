using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using Algorithms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CostBasedPathfinder : GInterface8
{
	private sealed class MapInstanceFilter
	{
		public float testsComparator;

		public float m_InterpreterComparator;

		private byte m_ContainerComparator;

		private short m_ComposerComparator;

		public int m_ModelComparator;

		public List<ActiveUnit> advisorComparator;

		public float _CustomerComparator;

		[SpecialName]
		public short method_0(Scenario scenario_0)
		{
			if (m_ComposerComparator == short.MaxValue)
			{
				m_ComposerComparator = Pathfinding._PredicateConsumer.GetElev(testsComparator, m_InterpreterComparator, scenario_0);
			}
			return m_ComposerComparator;
		}

		internal bool CountInterruptibleField(ActiveUnit activeUnit_0)
		{
			if (m_ContainerComparator == byte.MaxValue)
			{
				double double_ = testsComparator;
				double double_2 = m_InterpreterComparator;
				ref int modelComparator = ref m_ModelComparator;
				bool bool_ = true;
				bool bool_2 = true;
				short? nullable_ = method_0(activeUnit_0.ParentScen);
				ref List<ActiveUnit> list_ = ref advisorComparator;
				float customerComparator = _CustomerComparator;
				string string_ = "";
				bool bool_3 = false;
				if (activeUnit_0.CanMoveToThisLocation(double_, double_2, ref modelComparator, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, nullable_, ref list_, customerComparator, bool_6: false, bool_7: false, ref string_, ref bool_3))
				{
					m_ContainerComparator = 1;
				}
				else
				{
					m_ContainerComparator = 0;
				}
			}
			return m_ContainerComparator == 1;
		}

		public void CustomizeInterruptibleField()
		{
			m_ContainerComparator = 0;
		}

		public MapInstanceFilter()
		{
			_CustomerComparator = 0f;
			m_ContainerComparator = byte.MaxValue;
			m_ComposerComparator = short.MaxValue;
		}

		public MapInstanceFilter(double double_0, double double_1)
		{
			_CustomerComparator = 0f;
			testsComparator = (float)double_0;
			m_InterpreterComparator = (float)double_1;
			m_ContainerComparator = byte.MaxValue;
			m_ComposerComparator = short.MaxValue;
		}
	}

	private sealed class MessageMerchantService
	{
		public float _SerializerComparator;

		public float _RefComparator;

		private byte m_ErrorComparator;

		private short _CodeComparator;

		public int _ConnectionComparator;

		public float contextComparator;

		public List<ActiveUnit> m_StatusComparator;

		[SpecialName]
		public short method_0(Scenario scenario_0)
		{
			if (_CodeComparator == short.MaxValue)
			{
				_CodeComparator = Terrain.GetElevation(_SerializerComparator, _RefComparator, bool_0: false, scenario_0);
			}
			return _CodeComparator;
		}

		internal bool CloneInterruptibleField(ActiveUnit activeUnit_0)
		{
			if (m_ErrorComparator == byte.MaxValue)
			{
				double double_ = _SerializerComparator;
				double double_2 = _RefComparator;
				ref int connectionComparator = ref _ConnectionComparator;
				bool bool_ = true;
				bool bool_2 = true;
				short? nullable_ = method_0(activeUnit_0.ParentScen);
				ref List<ActiveUnit> statusComparator = ref m_StatusComparator;
				float float_ = contextComparator;
				string string_ = "";
				bool bool_3 = false;
				if (activeUnit_0.CanMoveToThisLocation(double_, double_2, ref connectionComparator, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, nullable_, ref statusComparator, float_, bool_6: false, bool_7: false, ref string_, ref bool_3))
				{
					m_ErrorComparator = 1;
				}
				else
				{
					m_ErrorComparator = 0;
				}
			}
			return m_ErrorComparator == 1;
		}

		public MessageMerchantService()
		{
			contextComparator = 0f;
			m_ErrorComparator = byte.MaxValue;
			_CodeComparator = short.MaxValue;
		}

		public MessageMerchantService(double double_0, double double_1)
		{
			contextComparator = 0f;
			_SerializerComparator = (float)double_0;
			_RefComparator = (float)double_1;
			m_ErrorComparator = byte.MaxValue;
			_CodeComparator = short.MaxValue;
		}

		public void ConnectInterruptibleField()
		{
			m_ErrorComparator = 0;
		}
	}

	public float DegreeInterval_Global => 0.18f;

	public float DegreeInterval_Coarse => 0.05f;

	public float DegreeInterval_Finegrained => 0.005f;

	internal List<Waypoint> ReflectImporter(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		float degreeInterval_Global = DegreeInterval_Global;
		try
		{
			if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
			{
				return null;
			}
			bool flag = Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3);
			float num = 90f;
			float num12 = -90f;
			float num23 = (float)Math2.VisitClass(double_1 + 180.0);
			float num34 = (float)Math2.VisitClass(double_1 - 180.0);
			short num45 = (short)Math.Round(180f / degreeInterval_Global);
			short num56 = (short)Math.Round(360f / degreeInterval_Global);
			int i;
			for (i = 1; !(Math.Pow(2.0, i) > (double)num45) || !(Math.Pow(2.0, i) > (double)num56); i++)
			{
			}
			int num58 = (int)Math.Round(Math.Pow(2.0, i));
			int num59 = (int)Math.Round(Math.Pow(2.0, i));
			long num60 = (long)num56 * (long)num45;
			MapInstanceFilter[,] mapInstanceFilter_ = new MapInstanceFilter[num56 - 1 + 1, num45 - 1 + 1];
			Doctrine._NavigationMethod? navigationMethod;
			if (Information.IsNothing(activeUnit_0))
			{
				navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
			}
			else if (activeUnit_0.IsShip)
			{
				navigationMethod = activeUnit_0.Doctrine.GetSurfaceNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			else if (activeUnit_0.IsSubmarine)
			{
				navigationMethod = activeUnit_0.Doctrine.GetSubmarineNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			else
			{
				if (activeUnit_0.IsFacility)
				{
					throw new Exception();
				}
				navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
			}
			int num2 = num56 - 1;
			short? nullable_ = null;
			short short_ = 0;
			short? nullable_2 = null;
			short short_2 = 0;
			long num3 = 0L;
			MapInstanceFilter mapInstanceFilter;
			for (int j = 0; j <= num2; j++)
			{
				double num4 = (flag ? ((double)Math2.RestartClass(num23 - (float)j * degreeInterval_Global)) : ((double)Math2.RestartClass(num23 + (float)j * degreeInterval_Global)));
				int num5 = num45 - 1;
				for (int k = 0; k <= num5; k++)
				{
					if (!activeUnit_0.ParentScen.ThreadedOpsMustStop)
					{
						if (bool_0 || !activeUnit_0.IsDestroyed)
						{
							double num6 = Math2.ReflectClass(num12 + (float)k * degreeInterval_Global);
							mapInstanceFilter = new MapInstanceFilter(num6, num4);
							mapInstanceFilter._CustomerComparator = float_2;
							mapInstanceFilter.advisorComparator = list_0;
							if (mapInstanceFilter.CountInterruptibleField(activeUnit_0))
							{
								int modelComparator;
								if (activeUnit_0.IsShip)
								{
									short num7 = mapInstanceFilter.method_0(activeUnit_0.ParentScen);
									Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
									byte? b = (byte?)navigationMethod2;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
									{
										modelComparator = ((num7 >= -50) ? 1000 : ((num7 >= -200) ? 600 : ((num7 >= -305) ? 300 : ((num7 >= -365) ? 300 : ((num7 >= -1000) ? 300 : ((num7 < -1525) ? 100 : 300))))));
									}
									else
									{
										b = (byte?)navigationMethod2;
										modelComparator = ((!(b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault()) ? 100 : ((num7 < -200) ? 1000 : 100));
									}
								}
								else if (activeUnit_0.IsSubmarine)
								{
									short num8 = mapInstanceFilter.method_0(activeUnit_0.ParentScen);
									Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
									byte? b2 = (byte?)navigationMethod3;
									if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
									{
										modelComparator = ((num8 >= -40) ? 1000 : ((num8 >= -300) ? 600 : ((num8 < -1525) ? 100 : 300)));
									}
									else
									{
										b2 = (byte?)navigationMethod3;
										if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
										{
											modelComparator = ((num8 >= -40) ? 1000 : ((num8 < -300) ? 100 : 300));
										}
										else
										{
											b2 = (byte?)navigationMethod3;
											modelComparator = ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 5) : null).GetValueOrDefault() ? ((num8 >= -40) ? 1000 : ((num8 < -300) ? 1000 : 100)) : ((num8 < -40) ? 100 : 1000));
										}
									}
								}
								else
								{
									if (activeUnit_0.IsFacility)
									{
										throw new Exception();
									}
									modelComparator = 100;
								}
								mapInstanceFilter.m_ModelComparator = modelComparator;
								if (Math.Abs(double_1 - num4) < (double)degreeInterval_Global && (!nullable_.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
								{
									nullable_ = (short)j;
								}
								if (Math.Abs(double_3 - num4) < (double)degreeInterval_Global)
								{
									short_ = (short)j;
								}
								if (Math.Abs(double_0 - num6) < (double)degreeInterval_Global && (!nullable_2.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
								{
									nullable_2 = (short)k;
								}
								if (Math.Abs(double_2 - num6) < (double)degreeInterval_Global)
								{
									short_2 = (short)k;
								}
							}
							else
							{
								mapInstanceFilter.m_ModelComparator = 0;
							}
							mapInstanceFilter_[j, k] = mapInstanceFilter;
							num3++;
							continue;
						}
						return null;
					}
					return null;
				}
				float_3 = (float)((double)num3 / (double)num60);
			}
			if (!nullable_2.HasValue)
			{
				try
				{
					double num9 = double.MaxValue;
					GeoPoint geoPoint = new GeoPoint(double_1, double_0);
					num3 = 0L;
					float num10 = num - degreeInterval_Global;
					float num11 = degreeInterval_Global;
					bool flag2 = num11 >= 0f;
					for (float num13 = num12; (!flag2) ? (num13 >= num10) : (num13 <= num10); num13 += num11)
					{
						double num14 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num13);
						if (num14 < num9)
						{
							num9 = num14;
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
					double num15 = double.MaxValue;
					GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
					num3 = 0L;
					float num16 = num34 - degreeInterval_Global;
					float num17 = degreeInterval_Global;
					bool flag3 = num17 >= 0f;
					float num18 = num23;
					while ((!flag3) ? (num18 >= num16) : (num18 <= num16))
					{
						num18 = Math2.RestartClass(num18);
						double num19 = geoPoint2.RangeToPoint_Horiz_Angular(num18, double_0);
						if (num19 < num15)
						{
							num15 = num19;
							nullable_ = (short)num3;
						}
						num3++;
						num18 += num17;
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
			CancelImporter(ref activeUnit_0, ref nullable_, ref nullable_2, ref short_, ref short_2, ref mapInstanceFilter_, null, num56, num45);
			int num20 = 10000;
			int num21 = num56 - 1;
			for (int l = 0; l <= num21; l++)
			{
				int num22 = num45 - 1;
				for (int m = 0; m <= num22; m++)
				{
					if (mapInstanceFilter_[l, m].m_ModelComparator != 0)
					{
						RestartImporter(ref mapInstanceFilter_, l, m, 0, num20, num56, num45);
					}
				}
			}
			if (activeUnit_0.IsSubmarine || activeUnit_0.IsShip)
			{
				List<int> list = new List<int>();
				Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
				byte? b3 = (byte?)navigationMethod4;
				if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					list.Add(50);
					list.Add(60);
					list.Add(70);
					list.Add(80);
					list.Add(90);
				}
				else
				{
					b3 = (byte?)navigationMethod4;
					if (!(b3.HasValue ? new bool?(b3.GetValueOrDefault() == 5) : null).GetValueOrDefault())
					{
						list.Add(6000);
						list.Add(3000);
						list.Add(1500);
					}
				}
				int num24 = num20;
				num3 = list.Count;
				b3 = (byte?)navigationMethod;
				if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					long num25 = num3 - 1;
					for (long num26 = 0L; num26 <= num25; num26++)
					{
						int num27 = list[(int)num26];
						int num28 = num56 - 1;
						for (int n = 0; n <= num28; n++)
						{
							int num29 = num45 - 1;
							for (int num30 = 0; num30 <= num29; num30++)
							{
								if (mapInstanceFilter_[n, num30].m_ModelComparator != 0 && mapInstanceFilter_[n, num30].m_ModelComparator != num20 && (num24 >= 100 || mapInstanceFilter_[n, num30].m_ModelComparator > num24))
								{
									RestartImporter(ref mapInstanceFilter_, n, num30, num24, num27, num56, num45);
								}
							}
						}
						num24 = num27;
					}
				}
				else
				{
					long num31 = num3 - 1;
					for (long num32 = 0L; num32 <= num31; num32++)
					{
						int num33 = list[(int)num32];
						int num35 = num56 - 1;
						for (int num36 = 0; num36 <= num35; num36++)
						{
							int num37 = num45 - 1;
							for (int num38 = 0; num38 <= num37; num38++)
							{
								if (mapInstanceFilter_[num36, num38].m_ModelComparator != 0 && mapInstanceFilter_[num36, num38].m_ModelComparator < num24)
								{
									RestartImporter(ref mapInstanceFilter_, num36, num38, num24, num33, num56, num45);
								}
							}
						}
						num24 = num33;
					}
				}
			}
			int[,] array = new int[num59 - 1 + 1, num58 - 1 + 1];
			int num39 = num56 - 1;
			for (int num40 = 0; num40 <= num39; num40++)
			{
				int num41 = num45 - 1;
				for (int num42 = 0; num42 <= num41; num42++)
				{
					array[num40, num42] = mapInstanceFilter_[num40, num42].m_ModelComparator;
				}
			}
			mapInstanceFilter = null;
			mapInstanceFilter_ = null;
			List<PathFinderNode> list2 = new PathFinderFast(array)
			{
				Formula = HeuristicFormula.Euclidean,
				Diagonals = true,
				HeavyDiagonals = false,
				PunishChangeDirection = false,
				PunishWalkingOnEdge = true,
				TrimAutoNavPoints = true,
				TieBreaker = true,
				SearchLimit = int.MaxValue,
				DebugProgress = false,
				ReopenCloseNodes = true,
				EdgeCost = num20
			}.FindPath(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2));
			if (Information.IsNothing(list2))
			{
				return null;
			}
			List<Waypoint> list3 = new List<Waypoint>();
			list2.Reverse();
			num3 = list2.Count;
			double num43 = double_0;
			double num44 = double_1;
			long num46 = num3 - 1;
			double num47 = 0.0;
			double num48 = 0.0;
			for (long num49 = 0L; num49 <= num46; num49++)
			{
				PathFinderNode pathFinderNode = list2[(int)num49];
				double num50 = (flag ? ((double)Math2.RestartClass(num23 - (float)pathFinderNode.X * degreeInterval_Global)) : ((double)Math2.RestartClass(num23 + (float)pathFinderNode.X * degreeInterval_Global)));
				double num51 = Math2.ReflectClass(num12 + (float)pathFinderNode.Y * degreeInterval_Global);
				double num52;
				double num53;
				if (num49 == 0)
				{
					num52 = double_0;
					num53 = double_1;
				}
				else
				{
					num52 = num43;
					num53 = num44;
				}
				if (pathFinderNode.E)
				{
					int int_;
					GeoPoint geoPoint_;
					if (num49 == 0L && num3 > 1)
					{
						PathFinderNode pathFinderNode2 = list2[(int)num49 + 1];
						num47 = (flag ? ((double)Math2.RestartClass(num23 - (float)pathFinderNode2.X * degreeInterval_Global)) : ((double)Math2.RestartClass(num23 + (float)pathFinderNode2.X * degreeInterval_Global)));
						num48 = Math2.ReflectClass(num12 + (float)pathFinderNode2.Y * degreeInterval_Global);
						ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
						double double_10 = num52;
						double double_11 = num53;
						double double_12 = num48;
						double double_13 = num47;
						float? nullable_3 = DegreeInterval_Finegrained;
						int_ = 0;
						geoPoint_ = null;
						if (!navigator.PathLineIsInterrupted(double_10, double_11, double_12, double_13, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_3, ref int_, ref geoPoint_))
						{
							continue;
						}
					}
					long num54 = 0L;
					bool flag4 = false;
					if (num49 == num3 - 1)
					{
						num48 = double_2;
						num47 = double_3;
					}
					else
					{
						long num55 = num49 + 1;
						long num57 = num3 - 1;
						for (num54 = num55; num54 <= num57; num54++)
						{
							PathFinderNode pathFinderNode3 = list2[(int)num49 + 1];
							if (pathFinderNode3.E)
							{
								num49 = num54;
								continue;
							}
							flag4 = true;
							num47 = (flag ? ((double)Math2.RestartClass(num23 - (float)pathFinderNode3.X * degreeInterval_Global)) : ((double)Math2.RestartClass(num23 + (float)pathFinderNode3.X * degreeInterval_Global)));
							num48 = Math2.ReflectClass(num12 + (float)pathFinderNode3.Y * degreeInterval_Global);
							break;
						}
						if (!flag4)
						{
							num48 = double_2;
							num47 = double_3;
							num49 = num3 - 1;
						}
					}
					ActiveUnit_Navigator navigator2 = activeUnit_0.Navigator;
					double double_14 = num52;
					double double_15 = num53;
					double double_4 = num48;
					double double_5 = num47;
					float? nullable_4 = DegreeInterval_Coarse;
					int_ = 0;
					geoPoint_ = null;
					if (!navigator2.PathLineIsInterrupted(double_14, double_15, double_4, double_5, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_4, ref int_, ref geoPoint_))
					{
						num43 = num48;
						num44 = num47;
						continue;
					}
					List<Waypoint> list4 = Pathfinding.visitorConsumer.SolvePF_Coarse(activeUnit_0, num52, num53, num48, num47, float_0, 2f, float_2, ref list_0, ref float_3, bool_0, bool_1);
					if (!Information.IsNothing(list4))
					{
						foreach (Waypoint item in list4)
						{
							if (!(Math.Abs(item.Latitude - num48) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item.Longitude - num47) < (double)DegreeInterval_Finegrained))
							{
								list3.Add(item);
								continue;
							}
							break;
						}
						num43 = num48;
						num44 = num47;
						continue;
					}
				}
				else
				{
					num48 = num51;
					num47 = num50;
					ActiveUnit_Navigator navigator3 = activeUnit_0.Navigator;
					double double_6 = num52;
					double double_7 = num53;
					double double_8 = num48;
					double double_9 = num47;
					float? nullable_5 = DegreeInterval_Coarse;
					int int_2 = 0;
					GeoPoint geoPoint_2 = null;
					if (navigator3.PathLineIsInterrupted(double_6, double_7, double_8, double_9, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_5, ref int_2, ref geoPoint_2))
					{
						List<Waypoint> list5 = Pathfinding.visitorConsumer.SolvePF_Coarse(activeUnit_0, num52, num53, num48, num47, float_0, 2f, float_2, ref list_0, ref float_3, bool_0, bool_1);
						if (!Information.IsNothing(list5))
						{
							foreach (Waypoint item2 in list5)
							{
								if (!(Math.Abs(item2.Latitude - num48) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item2.Longitude - num47) < (double)DegreeInterval_Finegrained))
								{
									list3.Add(item2);
									continue;
								}
								break;
							}
							num43 = num48;
							num44 = num47;
							continue;
						}
					}
				}
				num43 = num51;
				num44 = num50;
				list3.Add(new Waypoint(num50, num51, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
			}
			return list3;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101333", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal List<Waypoint> VisitImporter(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0, bool bool_1)
	{
		float degreeInterval_Coarse = DegreeInterval_Coarse;
		try
		{
			if (activeUnit_0.ParentScen.ThreadedOpsMustStop)
			{
				return null;
			}
			bool flag = Math2.LineCrossesAntimeridian(double_0, double_1, double_2, double_3);
			float num = Math.Min((float)(short)Math.Round(Math.Max(double_0, double_2)) + float_1, 90f);
			float num12 = Math.Max((float)(short)Math.Round(Math.Min(double_0, double_2)) - float_1, -90f);
			short num23 = (short)Math.Round(Math.Abs(num - num12) / degreeInterval_Coarse);
			float num34;
			float num45;
			short num56;
			if (flag)
			{
				num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) + float_1;
				num45 = (float)(short)Math.Round(Math.Max(double_1, double_3)) - float_1;
				num56 = Math.Abs((short)Math.Round((180f - Math.Abs(num34) + (180f - num45)) / degreeInterval_Coarse));
			}
			else
			{
				num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) - float_1;
				num45 = (float)(short)Math.Round(Math.Max(double_1, double_3)) + float_1;
				num56 = Math.Abs((short)Math.Round(Math.Abs(num45 - num34) / degreeInterval_Coarse));
			}
			int i;
			for (i = 1; !(Math.Pow(2.0, i) >= (double)num23) || !(Math.Pow(2.0, i) >= (double)num56); i++)
			{
			}
			int num59 = (int)Math.Round(Math.Pow(2.0, i));
			int num60 = (int)Math.Round(Math.Pow(2.0, i));
			if (num59 <= 2048)
			{
				long num61 = (long)num56 * (long)num23;
				MapInstanceFilter[,] mapInstanceFilter_ = new MapInstanceFilter[num56 - 1 + 1, num23 - 1 + 1];
				Doctrine._NavigationMethod? navigationMethod;
				if (Information.IsNothing(activeUnit_0))
				{
					navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
				}
				else if (activeUnit_0.IsShip)
				{
					navigationMethod = activeUnit_0.Doctrine.GetSurfaceNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				}
				else if (activeUnit_0.IsSubmarine)
				{
					navigationMethod = activeUnit_0.Doctrine.GetSubmarineNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					if (activeUnit_0.IsFacility)
					{
						throw new Exception();
					}
					navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
				}
				int num2 = num56 - 1;
				short? nullable_ = null;
				short short_ = 0;
				short? nullable_2 = null;
				short short_2 = 0;
				long num3 = 0L;
				MapInstanceFilter mapInstanceFilter;
				for (int j = 0; j <= num2; j++)
				{
					double num4 = (flag ? ((double)Math2.RestartClass(num34 - (float)j * degreeInterval_Coarse)) : ((double)Math2.RestartClass(num34 + (float)j * degreeInterval_Coarse)));
					int num5 = num23 - 1;
					for (int k = 0; k <= num5; k++)
					{
						if (!activeUnit_0.ParentScen.ThreadedOpsMustStop)
						{
							if (bool_0 || !activeUnit_0.IsDestroyed)
							{
								double num6 = Math2.ReflectClass(num12 + (float)k * degreeInterval_Coarse);
								mapInstanceFilter = new MapInstanceFilter(num6, num4);
								mapInstanceFilter._CustomerComparator = float_2;
								mapInstanceFilter.advisorComparator = list_0;
								if (mapInstanceFilter.CountInterruptibleField(activeUnit_0))
								{
									int modelComparator;
									if (activeUnit_0.IsShip)
									{
										short num7 = mapInstanceFilter.method_0(activeUnit_0.ParentScen);
										Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
										byte? b = (byte?)navigationMethod2;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
										{
											modelComparator = ((num7 >= -50) ? 1000 : ((num7 >= -200) ? 600 : ((num7 >= -305) ? 300 : ((num7 >= -365) ? 300 : ((num7 >= -1000) ? 300 : ((num7 < -1525) ? 100 : 300))))));
										}
										else
										{
											b = (byte?)navigationMethod2;
											modelComparator = ((!(b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault()) ? 100 : ((num7 < -200) ? 1000 : 100));
										}
									}
									else if (activeUnit_0.IsSubmarine)
									{
										short num8 = mapInstanceFilter.method_0(activeUnit_0.ParentScen);
										Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
										byte? b2 = (byte?)navigationMethod3;
										if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
										{
											modelComparator = ((num8 >= -40) ? 1000 : ((num8 >= -300) ? 600 : ((num8 < -1525) ? 100 : 300)));
										}
										else
										{
											b2 = (byte?)navigationMethod3;
											if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
											{
												modelComparator = ((num8 >= -40) ? 1000 : ((num8 < -300) ? 100 : 300));
											}
											else
											{
												b2 = (byte?)navigationMethod3;
												modelComparator = ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 5) : null).GetValueOrDefault() ? ((num8 >= -40) ? 1000 : ((num8 < -300) ? 1000 : 100)) : ((num8 < -40) ? 100 : 1000));
											}
										}
									}
									else
									{
										if (activeUnit_0.IsFacility)
										{
											throw new Exception();
										}
										modelComparator = 100;
									}
									mapInstanceFilter.m_ModelComparator = modelComparator;
									if (Math.Abs(double_1 - num4) < (double)degreeInterval_Coarse && (!nullable_.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
									{
										nullable_ = (short)j;
									}
									if (Math.Abs(double_3 - num4) < (double)degreeInterval_Coarse)
									{
										short_ = (short)j;
									}
									if (Math.Abs(double_0 - num6) < (double)degreeInterval_Coarse && (!nullable_2.HasValue || Math.Abs(MathFunctions.DeleteRequest(float_0, Math2.PublishClass(double_0, double_1, num6, num4))) < 90f))
									{
										nullable_2 = (short)k;
									}
									if (Math.Abs(double_2 - num6) < (double)degreeInterval_Coarse)
									{
										short_2 = (short)k;
									}
								}
								else
								{
									mapInstanceFilter.m_ModelComparator = 0;
								}
								mapInstanceFilter_[j, k] = mapInstanceFilter;
								num3++;
								continue;
							}
							return null;
						}
						return null;
					}
					float_3 = (float)((double)num3 / (double)num61);
				}
				if (!nullable_2.HasValue)
				{
					try
					{
						double num9 = double.MaxValue;
						GeoPoint geoPoint = new GeoPoint(double_1, double_0);
						num3 = 0L;
						float num10 = num - degreeInterval_Coarse;
						float num11 = degreeInterval_Coarse;
						bool flag2 = num11 >= 0f;
						for (float num13 = num12; (!flag2) ? (num13 >= num10) : (num13 <= num10); num13 += num11)
						{
							double num14 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num13);
							if (num14 < num9)
							{
								num9 = num14;
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
						double num15 = double.MaxValue;
						GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
						num3 = 0L;
						float num16 = num34;
						float num17 = num45 - degreeInterval_Coarse;
						float num18 = degreeInterval_Coarse;
						bool flag3 = num18 >= 0f;
						float num19 = num16;
						while ((!flag3) ? (num19 >= num17) : (num19 <= num17))
						{
							num19 = Math2.RestartClass(num19);
							double num20 = geoPoint2.RangeToPoint_Horiz_Angular(num19, double_0);
							if (num20 < num15)
							{
								num15 = num20;
								nullable_ = (short)num3;
							}
							num3++;
							num19 += num18;
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
				CancelImporter(ref activeUnit_0, ref nullable_, ref nullable_2, ref short_, ref short_2, ref mapInstanceFilter_, null, num56, num23);
				int num21 = 10000;
				int num22 = num56 - 1;
				for (int l = 0; l <= num22; l++)
				{
					int num24 = num23 - 1;
					for (int m = 0; m <= num24; m++)
					{
						if (mapInstanceFilter_[l, m].m_ModelComparator != 0)
						{
							RestartImporter(ref mapInstanceFilter_, l, m, 0, num21, num56, num23);
						}
					}
				}
				if (activeUnit_0.IsSubmarine || activeUnit_0.IsShip)
				{
					List<int> list = new List<int>();
					Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
					byte? b3 = (byte?)navigationMethod4;
					if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						list.Add(50);
						list.Add(60);
						list.Add(70);
						list.Add(80);
						list.Add(90);
					}
					else
					{
						b3 = (byte?)navigationMethod4;
						if (!(b3.HasValue ? new bool?(b3.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							list.Add(6000);
							list.Add(3000);
							list.Add(1500);
						}
					}
					int num25 = num21;
					num3 = list.Count;
					b3 = (byte?)navigationMethod;
					if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						long num26 = num3 - 1;
						for (long num27 = 0L; num27 <= num26; num27++)
						{
							int num28 = list[(int)num27];
							int num29 = num56 - 1;
							for (int n = 0; n <= num29; n++)
							{
								int num30 = num23 - 1;
								for (int num31 = 0; num31 <= num30; num31++)
								{
									if (mapInstanceFilter_[n, num31].m_ModelComparator != 0 && mapInstanceFilter_[n, num31].m_ModelComparator != num21 && (num25 >= 100 || mapInstanceFilter_[n, num31].m_ModelComparator > num25))
									{
										RestartImporter(ref mapInstanceFilter_, n, num31, num25, num28, num56, num23);
									}
								}
							}
							num25 = num28;
						}
					}
					else
					{
						long num32 = num3 - 1;
						for (long num33 = 0L; num33 <= num32; num33++)
						{
							int num35 = list[(int)num33];
							int num36 = num56 - 1;
							for (int num37 = 0; num37 <= num36; num37++)
							{
								int num38 = num23 - 1;
								for (int num39 = 0; num39 <= num38; num39++)
								{
									if (mapInstanceFilter_[num37, num39].m_ModelComparator != 0 && mapInstanceFilter_[num37, num39].m_ModelComparator < num25)
									{
										RestartImporter(ref mapInstanceFilter_, num37, num39, num25, num35, num56, num23);
									}
								}
							}
							num25 = num35;
						}
					}
				}
				int[,] array = new int[num60 - 1 + 1, num59 - 1 + 1];
				int num40 = num56 - 1;
				for (int num41 = 0; num41 <= num40; num41++)
				{
					int num42 = num23 - 1;
					for (int num43 = 0; num43 <= num42; num43++)
					{
						array[num41, num43] = mapInstanceFilter_[num41, num43].m_ModelComparator;
					}
				}
				mapInstanceFilter = null;
				mapInstanceFilter_ = null;
				List<PathFinderNode> list2 = new PathFinderFast(array)
				{
					Formula = HeuristicFormula.Euclidean,
					Diagonals = true,
					HeavyDiagonals = false,
					PunishChangeDirection = false,
					PunishWalkingOnEdge = true,
					TrimAutoNavPoints = true,
					TieBreaker = true,
					SearchLimit = int.MaxValue,
					DebugProgress = false,
					ReopenCloseNodes = true,
					EdgeCost = num21
				}.FindPath(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2));
				if (Information.IsNothing(list2))
				{
					return null;
				}
				List<Waypoint> list3 = new List<Waypoint>();
				list2.Reverse();
				num3 = list2.Count;
				double num44 = double_0;
				double num46 = double_1;
				long num47 = num3 - 1;
				double num48 = 0.0;
				double num49 = 0.0;
				for (long num50 = 0L; num50 <= num47; num50++)
				{
					PathFinderNode pathFinderNode = list2[(int)num50];
					double num51 = (flag ? ((double)Math2.RestartClass(num34 - (float)pathFinderNode.X * degreeInterval_Coarse)) : ((double)Math2.RestartClass(num34 + (float)pathFinderNode.X * degreeInterval_Coarse)));
					double num52 = Math2.ReflectClass(num12 + (float)pathFinderNode.Y * degreeInterval_Coarse);
					if (bool_1)
					{
						double num53;
						double num54;
						if (num50 == 0)
						{
							num53 = double_0;
							num54 = double_1;
						}
						else
						{
							num53 = num44;
							num54 = num46;
						}
						if (pathFinderNode.E)
						{
							int int_;
							GeoPoint geoPoint_;
							if (num50 == 0L && num3 > 1)
							{
								PathFinderNode pathFinderNode2 = list2[(int)num50 + 1];
								num48 = (flag ? ((double)Math2.RestartClass(num34 - (float)pathFinderNode2.X * degreeInterval_Coarse)) : ((double)Math2.RestartClass(num34 + (float)pathFinderNode2.X * degreeInterval_Coarse)));
								num49 = Math2.ReflectClass(num12 + (float)pathFinderNode2.Y * degreeInterval_Coarse);
								ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
								double double_10 = num53;
								double double_11 = num54;
								double double_12 = num49;
								double double_13 = num48;
								float? nullable_3 = DegreeInterval_Finegrained;
								int_ = 0;
								geoPoint_ = null;
								if (!navigator.PathLineIsInterrupted(double_10, double_11, double_12, double_13, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_3, ref int_, ref geoPoint_))
								{
									continue;
								}
							}
							long num55 = 0L;
							bool flag4 = false;
							if (num50 == num3 - 1)
							{
								num49 = double_2;
								num48 = double_3;
							}
							else
							{
								long num57 = num50 + 1;
								long num58 = num3 - 1;
								for (num55 = num57; num55 <= num58; num55++)
								{
									PathFinderNode pathFinderNode3 = list2[(int)num50 + 1];
									if (pathFinderNode3.E)
									{
										num50 = num55;
										continue;
									}
									flag4 = true;
									num48 = (flag ? ((double)Math2.RestartClass(num34 - (float)pathFinderNode3.X * degreeInterval_Coarse)) : ((double)Math2.RestartClass(num34 + (float)pathFinderNode3.X * degreeInterval_Coarse)));
									num49 = Math2.ReflectClass(num12 + (float)pathFinderNode3.Y * degreeInterval_Coarse);
									break;
								}
								if (!flag4)
								{
									num49 = double_2;
									num48 = double_3;
									num50 = num3 - 1;
								}
							}
							ActiveUnit_Navigator navigator2 = activeUnit_0.Navigator;
							double double_14 = num53;
							double double_15 = num54;
							double double_4 = num49;
							double double_5 = num48;
							float? nullable_4 = DegreeInterval_Finegrained;
							int_ = 0;
							geoPoint_ = null;
							if (!navigator2.PathLineIsInterrupted(double_14, double_15, double_4, double_5, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_4, ref int_, ref geoPoint_))
							{
								num44 = num49;
								num46 = num48;
								continue;
							}
							List<Waypoint> list4 = Pathfinding.visitorConsumer.SolvePF_Finegrained(activeUnit_0, num53, num54, num49, num48, float_0, 2f, float_2, ref list_0, ref float_3, bool_0);
							if (!Information.IsNothing(list4))
							{
								foreach (Waypoint item in list4)
								{
									if (!(Math.Abs(item.Latitude - num49) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item.Longitude - num48) < (double)DegreeInterval_Finegrained))
									{
										list3.Add(item);
										continue;
									}
									break;
								}
								num44 = num49;
								num46 = num48;
								continue;
							}
						}
						else
						{
							num49 = num52;
							num48 = num51;
							ActiveUnit_Navigator navigator3 = activeUnit_0.Navigator;
							double double_6 = num53;
							double double_7 = num54;
							double double_8 = num49;
							double double_9 = num48;
							float? nullable_5 = DegreeInterval_Finegrained;
							int int_2 = 0;
							GeoPoint geoPoint_2 = null;
							if (navigator3.PathLineIsInterrupted(double_6, double_7, double_8, double_9, bool_1: false, 0f, bool_2: false, null, bool_3: false, bool_4: false, bool_5: false, nullable_5, ref int_2, ref geoPoint_2))
							{
								List<Waypoint> list5 = Pathfinding.visitorConsumer.SolvePF_Finegrained(activeUnit_0, num53, num54, num49, num48, float_0, 2f, float_2, ref list_0, ref float_3, bool_0);
								if (!Information.IsNothing(list5))
								{
									foreach (Waypoint item2 in list5)
									{
										if (!(Math.Abs(item2.Latitude - num49) < (double)DegreeInterval_Finegrained) || !(Math.Abs(item2.Longitude - num48) < (double)DegreeInterval_Finegrained))
										{
											list3.Add(item2);
											continue;
										}
										break;
									}
									num44 = num49;
									num46 = num48;
									continue;
								}
							}
						}
						num44 = num52;
						num46 = num51;
					}
					list3.Add(new Waypoint(num51, num52, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
				}
				return list3;
			}
			return ReflectImporter(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0, bool_1);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 101333", "");
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
		return VisitImporter(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0, bool_1);
	}

	private void RestartImporter(ref MapInstanceFilter[,] mapInstanceFilter_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && mapInstanceFilter_0[int_0, int_1 - 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && mapInstanceFilter_0[int_0 + 1, int_1 - 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_0 < int_4 - 1 && mapInstanceFilter_0[int_0 + 1, int_1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && mapInstanceFilter_0[int_0 + 1, int_1 + 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && mapInstanceFilter_0[int_0, int_1 + 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && mapInstanceFilter_0[int_0 - 1, int_1 + 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_0 > 0 && mapInstanceFilter_0[int_0 - 1, int_1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && mapInstanceFilter_0[int_0 - 1, int_1 - 1].m_ModelComparator == int_2)
			{
				mapInstanceFilter_0[int_0, int_1].m_ModelComparator = int_3;
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

	internal List<Waypoint> TestImporter(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0)
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
			short num23 = (short)Math.Round(Math.Abs(num - num12) / DegreeInterval_Finegrained);
			float num34;
			float num42;
			short num43;
			if (flag)
			{
				num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) + float_1;
				num42 = (float)(short)Math.Round(Math.Max(double_1, double_3)) - float_1;
				num43 = Math.Abs((short)Math.Round((180f - Math.Abs(num34) + (180f - num42)) / DegreeInterval_Finegrained));
			}
			else
			{
				num34 = (float)(short)Math.Round(Math.Min(double_1, double_3)) - float_1;
				num42 = (float)(short)Math.Round(Math.Max(double_1, double_3)) + float_1;
				num43 = Math.Abs((short)Math.Round(Math.Abs(num42 - num34) / DegreeInterval_Finegrained));
			}
			long num44 = (long)num43 * (long)num23;
			Doctrine._NavigationMethod? navigationMethod;
			if (Information.IsNothing(activeUnit_0))
			{
				navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
			}
			else if (activeUnit_0.IsShip)
			{
				navigationMethod = activeUnit_0.Doctrine.GetSurfaceNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			else if (activeUnit_0.IsSubmarine)
			{
				navigationMethod = activeUnit_0.Doctrine.GetSubmarineNavigation(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			else
			{
				if (activeUnit_0.IsFacility)
				{
					throw new Exception();
				}
				navigationMethod = Doctrine._NavigationMethod.ShortestRoute;
			}
			int i;
			for (i = 1; !(Math.Pow(2.0, i) > (double)num23) || !(Math.Pow(2.0, i) > (double)num43); i++)
			{
			}
			int num45 = (int)Math.Round(Math.Pow(2.0, i));
			int num46 = (int)Math.Round(Math.Pow(2.0, i));
			if (num46 <= 2048)
			{
				MessageMerchantService[,] messageMerchantService_ = new MessageMerchantService[num46 - 1 + 1, num45 - 1 + 1];
				int num2 = num43 - 1;
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
						if (!activeUnit_0.ParentScen.ThreadedOpsMustStop)
						{
							if (bool_0 || !activeUnit_0.IsDestroyed)
							{
								double num6 = Math2.ReflectClass(num12 + (float)k * DegreeInterval_Finegrained);
								MessageMerchantService messageMerchantService = new MessageMerchantService(num6, num4);
								messageMerchantService.contextComparator = float_2;
								messageMerchantService.m_StatusComparator = list_0;
								if (messageMerchantService.CloneInterruptibleField(activeUnit_0))
								{
									int connectionComparator;
									if (activeUnit_0.IsShip)
									{
										short num7 = messageMerchantService.method_0(activeUnit_0.ParentScen);
										Doctrine._NavigationMethod? navigationMethod2 = navigationMethod;
										byte? b = (byte?)navigationMethod2;
										if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
										{
											connectionComparator = ((num7 >= -50) ? 1000 : ((num7 >= -200) ? 600 : ((num7 >= -305) ? 300 : ((num7 >= -365) ? 300 : ((num7 >= -1000) ? 300 : ((num7 < -1525) ? 100 : 300))))));
										}
										else
										{
											b = (byte?)navigationMethod2;
											connectionComparator = ((!(b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault()) ? 100 : ((num7 < -200) ? 1000 : 100));
										}
									}
									else if (activeUnit_0.IsSubmarine)
									{
										short num8 = messageMerchantService.method_0(activeUnit_0.ParentScen);
										Doctrine._NavigationMethod? navigationMethod3 = navigationMethod;
										byte? b2 = (byte?)navigationMethod3;
										if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
										{
											connectionComparator = ((num8 >= -40) ? 1000 : ((num8 < -300) ? 100 : 300));
										}
										else
										{
											b2 = (byte?)navigationMethod3;
											if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
											{
												connectionComparator = ((num8 >= -40) ? 1000 : ((num8 >= -200) ? 600 : ((num8 < -300) ? 100 : 300)));
											}
											else
											{
												b2 = (byte?)navigationMethod3;
												connectionComparator = ((!(b2.HasValue ? new bool?(b2.GetValueOrDefault() == 5) : null).GetValueOrDefault()) ? 100 : ((num8 >= -40) ? 1000 : ((num8 < -300) ? 1000 : 100)));
											}
										}
									}
									else
									{
										if (activeUnit_0.IsFacility)
										{
											throw new Exception();
										}
										connectionComparator = 100;
									}
									messageMerchantService._ConnectionComparator = connectionComparator;
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
									messageMerchantService._ConnectionComparator = 0;
								}
								messageMerchantService_[j, k] = messageMerchantService;
								num3++;
								continue;
							}
							return null;
						}
						return null;
					}
					float_3 = (float)((double)num3 / (double)num44);
				}
				if (!nullable_2.HasValue)
				{
					try
					{
						double num9 = double.MaxValue;
						GeoPoint geoPoint = new GeoPoint(double_1, double_0);
						num3 = 0L;
						float num10 = num;
						float degreeInterval_Finegrained = DegreeInterval_Finegrained;
						bool flag2 = degreeInterval_Finegrained >= 0f;
						for (float num11 = num12; (!flag2) ? (num11 >= num10) : (num11 <= num10); num11 += degreeInterval_Finegrained)
						{
							double num13 = geoPoint.RangeToPoint_Horiz_Angular(double_1, num11);
							if (num13 < num9)
							{
								num9 = num13;
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
						double num14 = double.MaxValue;
						GeoPoint geoPoint2 = new GeoPoint(double_1, double_0);
						num3 = 0L;
						float num15 = num34;
						float num16 = num42;
						float degreeInterval_Finegrained2 = DegreeInterval_Finegrained;
						bool flag3 = degreeInterval_Finegrained2 >= 0f;
						float num17 = num15;
						while ((!flag3) ? (num17 >= num16) : (num17 <= num16))
						{
							num17 = Math2.RestartClass(num17);
							double num18 = geoPoint2.RangeToPoint_Horiz_Angular(num17, double_0);
							if (num18 < num14)
							{
								num14 = num18;
								nullable_ = (short)num3;
							}
							num3++;
							num17 += degreeInterval_Finegrained2;
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
				MapInstanceFilter[,] mapInstanceFilter_ = null;
				CancelImporter(ref activeUnit_0, ref nullable_, ref nullable_2, ref short_, ref short_2, ref mapInstanceFilter_, messageMerchantService_, num43, num23);
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				int num22 = 0;
				do
				{
					byte? b3 = (byte?)navigationMethod;
					if ((b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						switch (num20)
						{
						case 1:
							num22 = 300;
							break;
						case 0:
							num22 = 10000;
							num21 = 10000;
							break;
						}
					}
					else
					{
						switch (num20)
						{
						case 6:
							num22 = 10000;
							break;
						case 1:
							num22 = 15000;
							break;
						case 0:
							num22 = 20000;
							num21 = 20000;
							break;
						}
					}
					int num24 = num43 - 1;
					for (int l = 0; l <= num24; l++)
					{
						int num25 = num23 - 1;
						for (int m = 0; m <= num25; m++)
						{
							if (messageMerchantService_[l, m]._ConnectionComparator != 0 && (num19 <= 0 || messageMerchantService_[l, m]._ConnectionComparator < num19))
							{
								StopImporter(ref messageMerchantService_, l, m, num19, num22, num43, num23);
							}
						}
					}
					num19 = num22;
					num22--;
					num20++;
				}
				while (num20 <= 9);
				if (activeUnit_0.IsSubmarine || activeUnit_0.IsShip)
				{
					List<int> list = new List<int>();
					Doctrine._NavigationMethod? navigationMethod4 = navigationMethod;
					byte? b4 = (byte?)navigationMethod4;
					if ((b4.HasValue ? new bool?(b4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						list.Add(50);
						list.Add(60);
						list.Add(70);
						list.Add(80);
						list.Add(90);
					}
					else
					{
						b4 = (byte?)navigationMethod4;
						if (!(b4.HasValue ? new bool?(b4.GetValueOrDefault() == 5) : null).GetValueOrDefault())
						{
							list.Add(6000);
							list.Add(3000);
							list.Add(1500);
						}
					}
					num3 = list.Count;
					long num26 = num3 - 1;
					for (long num27 = 0L; num27 <= num26; num27++)
					{
						num22 = list[(int)num27];
						b4 = (byte?)navigationMethod;
						if ((b4.HasValue ? new bool?(b4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							int num28 = 0;
							do
							{
								int num29 = num43 - 1;
								for (int n = 0; n <= num29; n++)
								{
									int num30 = num23 - 1;
									for (int num31 = 0; num31 <= num30; num31++)
									{
										if (messageMerchantService_[n, num31]._ConnectionComparator != 0 && messageMerchantService_[n, num31]._ConnectionComparator != num21 && (messageMerchantService_[n, num31]._ConnectionComparator > 300 || messageMerchantService_[n, num31]._ConnectionComparator <= 290) && (num19 >= 100 || messageMerchantService_[n, num31]._ConnectionComparator > num19))
										{
											StopImporter(ref messageMerchantService_, n, num31, num19, num22, num43, num23);
										}
									}
								}
								num19 = num22;
								num22++;
								num28++;
							}
							while (num28 <= 9);
							continue;
						}
						int num32 = 0;
						do
						{
							int num33 = num43 - 1;
							for (int num35 = 0; num35 <= num33; num35++)
							{
								int num36 = num23 - 1;
								for (int num37 = 0; num37 <= num36; num37++)
								{
									if (messageMerchantService_[num35, num37]._ConnectionComparator != 0 && messageMerchantService_[num35, num37]._ConnectionComparator < num19)
									{
										StopImporter(ref messageMerchantService_, num35, num37, num19, num22, num43, num23);
									}
								}
							}
							num19 = num22;
							num22--;
							num32++;
						}
						while (num32 <= 9);
					}
				}
				int[,] array = new int[num46 - 1 + 1, num45 - 1 + 1];
				int num38 = num46 - 1;
				for (int num39 = 0; num39 <= num38; num39++)
				{
					int num40 = num45 - 1;
					for (int num41 = 0; num41 <= num40; num41++)
					{
						if (Information.IsNothing(messageMerchantService_[num39, num41]))
						{
							array[num39, num41] = 0;
						}
						else
						{
							array[num39, num41] = messageMerchantService_[num39, num41]._ConnectionComparator;
						}
					}
				}
				messageMerchantService_ = null;
				PathFinderFast pathFinderFast = new PathFinderFast(array);
				pathFinderFast.Formula = HeuristicFormula.Manhattan;
				if (activeUnit_0.IsFacility)
				{
					pathFinderFast.Formula = HeuristicFormula.EuclideanNoSQR;
				}
				pathFinderFast.Diagonals = true;
				pathFinderFast.HeavyDiagonals = false;
				pathFinderFast.PunishChangeDirection = false;
				pathFinderFast.PunishWalkingOnEdge = true;
				pathFinderFast.TrimAutoNavPoints = true;
				pathFinderFast.TieBreaker = true;
				pathFinderFast.SearchLimit = int.MaxValue;
				pathFinderFast.DebugProgress = false;
				pathFinderFast.ReopenCloseNodes = true;
				pathFinderFast.EdgeCost = num21;
				List<PathFinderNode> list2 = pathFinderFast.FindPath(new Point(nullable_.Value, nullable_2.Value), new Point(short_, short_2));
				if (Information.IsNothing(list2))
				{
					return null;
				}
				List<Waypoint> list3 = new List<Waypoint>();
				list2.Reverse();
				foreach (PathFinderNode item in list2)
				{
					double double_4 = (flag ? ((double)Math2.RestartClass(num34 - (float)item.X * DegreeInterval_Finegrained)) : ((double)Math2.RestartClass(num34 + (float)item.X * DegreeInterval_Finegrained)));
					double double_5 = Math2.ReflectClass(num12 + (float)item.Y * DegreeInterval_Finegrained);
					list3.Add(new Waypoint(double_4, double_5, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
				}
				return list3;
			}
			return VisitImporter(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0, bool_1: false);
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

	List<Waypoint> GInterface8.SolvePF_Finegrained(ActiveUnit activeUnit_0, double double_0, double double_1, double double_2, double double_3, float float_0, float float_1, float float_2, ref List<ActiveUnit> list_0, ref float float_3, bool bool_0)
	{
		return TestImporter(activeUnit_0, double_0, double_1, double_2, double_3, float_0, float_1, float_2, ref list_0, ref float_3, bool_0);
	}

	private void StopImporter(ref MessageMerchantService[,] messageMerchantService_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		try
		{
			if (int_1 > 0 && messageMerchantService_0[int_0, int_1 - 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_1 > 0 && int_0 < int_4 - 1 && messageMerchantService_0[int_0 + 1, int_1 - 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_0 < int_4 - 1 && messageMerchantService_0[int_0 + 1, int_1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 < int_4 - 1 && messageMerchantService_0[int_0 + 1, int_1 + 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && messageMerchantService_0[int_0, int_1 + 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_1 < int_5 - 1 && int_0 > 0 && messageMerchantService_0[int_0 - 1, int_1 + 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_0 > 0 && messageMerchantService_0[int_0 - 1, int_1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
			}
			else if (int_1 > 0 && int_0 > 0 && messageMerchantService_0[int_0 - 1, int_1 - 1]._ConnectionComparator == int_2)
			{
				messageMerchantService_0[int_0, int_1]._ConnectionComparator = int_3;
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

	private void CancelImporter(ref ActiveUnit activeUnit_0, ref short? nullable_0, ref short? nullable_1, ref short short_0, ref short short_1, ref MapInstanceFilter[,] mapInstanceFilter_0, MessageMerchantService[,] messageMerchantService_0, short short_2, short short_3)
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
					if (!Information.IsNothing(mapInstanceFilter_0) && mapInstanceFilter_0[nullable_0.Value, nullable_1.Value].CountInterruptibleField(activeUnit_0))
					{
						if (num33 != short_3 - 1 && mapInstanceFilter_0[num32, num33 + 1].CountInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num33 != 0 && mapInstanceFilter_0[num32, num33 - 1].CountInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num32 != 0 && mapInstanceFilter_0[num32 - 1, num33].CountInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && mapInstanceFilter_0[num32 + 1, num33].CountInterruptibleField(activeUnit_0))
						{
							num3++;
						}
					}
					else if (!Information.IsNothing(messageMerchantService_0) && messageMerchantService_0[nullable_0.Value, nullable_1.Value].CloneInterruptibleField(activeUnit_0))
					{
						if (num33 != short_3 - 1 && messageMerchantService_0[num32, num33 + 1].CloneInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num33 != 0 && messageMerchantService_0[num32, num33 - 1].CloneInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num32 != 0 && messageMerchantService_0[num32 - 1, num33].CloneInterruptibleField(activeUnit_0))
						{
							num3++;
						}
						if (num32 != short_2 - 1 && messageMerchantService_0[num32 + 1, num33].CloneInterruptibleField(activeUnit_0))
						{
							num3++;
						}
					}
					if (num3 <= 0)
					{
						if (!Information.IsNothing(mapInstanceFilter_0))
						{
							mapInstanceFilter_0[num32, num33].CustomizeInterruptibleField();
						}
						if (!Information.IsNothing(messageMerchantService_0))
						{
							messageMerchantService_0[num32, num33].ConnectInterruptibleField();
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
									if (num15 >= 0 && num15 <= short_3 - 1 && (num10 == 0 || num10 == num5 - 1 || num14 == 0 || num14 == num5 - 1) && ((!Information.IsNothing(mapInstanceFilter_0) && mapInstanceFilter_0[num11, num15].CountInterruptibleField(activeUnit_0)) || (!Information.IsNothing(messageMerchantService_0) && messageMerchantService_0[num11, num15].CloneInterruptibleField(activeUnit_0))))
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
					if (!Information.IsNothing(mapInstanceFilter_0) && mapInstanceFilter_0[short_0, short_1].CountInterruptibleField(activeUnit_0))
					{
						if (num35 != short_3 - 1 && mapInstanceFilter_0[num34, num35 + 1].CountInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num35 != 0 && mapInstanceFilter_0[num34, num35 - 1].CountInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num34 != 0 && mapInstanceFilter_0[num34 - 1, num35].CountInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && mapInstanceFilter_0[num34 + 1, num35].CountInterruptibleField(activeUnit_0))
						{
							num17++;
						}
					}
					else if (!Information.IsNothing(messageMerchantService_0) && messageMerchantService_0[short_0, short_1].CloneInterruptibleField(activeUnit_0))
					{
						if (num35 != short_3 - 1 && messageMerchantService_0[num34, num35 + 1].CloneInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num35 != 0 && messageMerchantService_0[num34, num35 - 1].CloneInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num34 != 0 && messageMerchantService_0[num34 - 1, num35].CloneInterruptibleField(activeUnit_0))
						{
							num17++;
						}
						if (num34 != short_2 - 1 && messageMerchantService_0[num34 + 1, num35].CloneInterruptibleField(activeUnit_0))
						{
							num17++;
						}
					}
					if (num17 <= 0)
					{
						if (!Information.IsNothing(mapInstanceFilter_0))
						{
							mapInstanceFilter_0[num34, num35].CustomizeInterruptibleField();
						}
						if (!Information.IsNothing(messageMerchantService_0))
						{
							messageMerchantService_0[num34, num35].ConnectInterruptibleField();
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
									if (num29 >= 0 && num29 <= short_3 - 1 && (num25 == 0 || num25 == num19 - 1 || num28 == 0 || num28 == num19 - 1) && ((!Information.IsNothing(mapInstanceFilter_0) && mapInstanceFilter_0[num26, num29].CountInterruptibleField(activeUnit_0)) || (!Information.IsNothing(messageMerchantService_0) && messageMerchantService_0[num26, num29].CloneInterruptibleField(activeUnit_0))))
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
