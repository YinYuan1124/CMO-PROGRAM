using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using CSMaterial;
using CSMaterial.ClipperLib;
using Command.Specifications;
using DotSpatial.Topology;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Navigator
{
	public class FormationStation
	{
		public float Bearing;

		public float Distance;

		public ReferencePoint.OrientationType BearingType;

		[SpecialName]
		public double GetLatitude(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude(), ref double_, ref double_2, Distance, GetResultantBearing(activeUnit_0));
			return double_2;
		}

		[SpecialName]
		public double GetLongitude(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude(), ref double_, ref double_2, Distance, GetResultantBearing(activeUnit_0));
			return double_;
		}

		[SpecialName]
		public Tuple<double, double> GetLatitudeAndLongitude(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude(), ref double_, ref double_2, Distance, GetResultantBearing(activeUnit_0));
			return new Tuple<double, double>(double_2, double_);
		}

		[SpecialName]
		public float GetResultantBearing(ActiveUnit activeUnit_0)
		{
			switch (BearingType)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return 0f;
			case ReferencePoint.OrientationType.Rotating:
				return Math2.UpdateClass(activeUnit_0.GetParentGroup().GroupLead.CurrentHeading + Bearing);
			case ReferencePoint.OrientationType.Fixed:
				return Bearing;
			}
		}

		[SpecialName]
		public Tuple<double, double> GetValidatedLatitudeAndLongitude(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
		{
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude(), ref double_, ref double_2, Distance, GetResultantBearing(activeUnit_0));
			double double_3 = double_2;
			double double_4 = double_;
			int int_ = 0;
			bool bool_ = true;
			bool bool_2 = true;
			List<ActiveUnit> list_ = null;
			string string_ = "";
			bool bool_3 = false;
			if (!activeUnit_0.CanMoveToThisLocation(double_3, double_4, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
			{
				ActiveUnit_Navigator navigator = activeUnit_0.Navigator;
				double latitude = activeUnit_1.GetLatitude();
				double longitude = activeUnit_1.GetLongitude();
				double double_5 = double_2;
				double double_6 = double_;
				list_ = null;
				GeoPoint geoPoint = navigator.LastAccessiblePointOnPath(latitude, longitude, double_5, double_6, 0f, null, 0f, ref list_);
				if (geoPoint != null)
				{
					double_2 = geoPoint.Latitude;
					double_ = geoPoint.Longitude;
				}
			}
			return new Tuple<double, double>(double_2, double_);
		}
	}

	public class WP_reach_cache
	{
		public Geopoint_Struct theWaypoint;

		public DateTime theTime;

		public bool theResult;

		public double theDistance;

		public Geopoint_Struct UnitLocation;

		public WP_reach_cache()
		{
		}

		public WP_reach_cache(Geopoint_Struct geopoint_Struct_0, DateTime dateTime_0, bool bool_0, double double_0, Geopoint_Struct geopoint_Struct_1)
		{
			theWaypoint = geopoint_Struct_0;
			theTime = dateTime_0;
			theResult = bool_0;
			theDistance = double_0;
			UnitLocation = geopoint_Struct_1;
		}

		public WP_reach_cache(double double_0, double double_1, DateTime dateTime_0, bool bool_0, double double_2, Geopoint_Struct geopoint_Struct_0)
		{
			theWaypoint = new Geopoint_Struct(double_1, double_0);
			theTime = dateTime_0;
			theResult = bool_0;
			theDistance = double_2;
			UnitLocation = geopoint_Struct_0;
		}
	}

	[CompilerGenerated]
	private sealed class ExporterCallbackCandidate
	{
		public double Local_TakeOffPoint_Lat;

		public double Local_TakeOffPoint_Lon;

		internal float CountInterruptibleTag(ReferencePoint theP)
		{
			return Math2.VerifyClass(theP.Latitude, theP.Longitude, Local_TakeOffPoint_Lat, Local_TakeOffPoint_Lon);
		}
	}

	protected ActiveUnit myUnit;

	protected Waypoint[] _PlottedCourse;

	protected Waypoint[] _PlottedCourse_PrePlanned;

	protected Mission.Flight _Flight;

	protected string _Flight_ID;

	public bool ManualPlotOverride;

	private FormationStation _InterpreterWrapper;

	public ReferencePoint SupportMission_NextRefPoint;

	public ReferencePoint PatrolLoop_NextRefPoint;

	public bool bool_0;

	public float TimeToNextPathfinderCheck;

	[CompilerGenerated]
	private bool m_ContainerWrapper;

	public float Pathfinding_PercentComplete;

	public bool PathFindingAbortNextPath;

	public bool TankerIsBlockedByNoNavZone;

	public bool? TankerFollowsMe;

	public int TankerFollowsMe_NumberOfWaypoints;

	internal int _ComposerWrapper;

	internal int modelWrapper;

	protected List<Waypoint> PF_GeneratedCourse;

	public double TimeToNextIsInsideMissionAreaEvaluation_NoBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer;

	public double TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer;

	public double TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer;

	public bool InsideMissionArea_NoBuffer;

	public bool InsideMissionArea_1nmBuffer;

	public bool InsideMissionArea_2nmBuffer;

	public bool InsideMissionArea_5nmBuffer;

	public bool InsideMissionArea_10nmBuffer;

	public bool InsideMissionArea_30nmBuffer;

	public bool InsideProsecutionArea_NoBuffer;

	public bool InsideProsecutionArea_5nmBuffer;

	public double TimeToNextPlottedCourseLeadsToMissionAreaEvaluation;

	public bool CourseLeadsToMissionArea;

	public double TimeToNextUnitDistanceToNearestNoNavZoneEvaluation;

	public bool CheckNoNavZones_UnitMovementOnEveryPulse;

	public float? GetNearestAccessibleSpotHeading;

	public DateTime? PreviousWaypointTime;

	public double? PreviousWaypointLatitude;

	public double? PreviousWaypointLongitude;

	public Waypoint.WaypointType? PreviousWaypointType;

	public double ExtendTimer;

	private bool _AdvisorWrapper;

	private float? _CustomerWrapper;

	private GeoPoint _SerializerWrapper;

	public bool AvoidCavitation;

	private bool? refWrapper;

	internal bool m_ErrorWrapper;

	internal const float _CodeWrapper = 6f;

	private GeoPoint connectionWrapper;

	private bool m_ContextWrapper;

	public WP_reach_cache WP_reach_cache_memory;

	[CompilerGenerated]
	private float m_StatusWrapper;

	[CompilerGenerated]
	private float proccesorWrapper;

	public bool PathFindingInProgress
	{
		get
		{
			return method_0();
		}
		set
		{
			method_1(value);
		}
	}

	public virtual bool SprintDrift
	{
		get
		{
			return _AdvisorWrapper;
		}
		set
		{
			bool num = value != _AdvisorWrapper;
			_AdvisorWrapper = value;
			if (num)
			{
				if (_AdvisorWrapper)
				{
					SetSprintDriftMarker(bool_1: true);
				}
				else
				{
					SprintDrift_AverageSpeed = null;
				}
			}
		}
	}

	public virtual float? SprintDrift_AverageSpeed
	{
		get
		{
			return _CustomerWrapper;
		}
		set
		{
			bool flag = false;
			if (Information.IsNothing(value) && !Information.IsNothing(_CustomerWrapper))
			{
				flag = true;
			}
			if (!flag && !Information.IsNothing(value) && Information.IsNothing(_CustomerWrapper))
			{
				flag = true;
			}
			if (!flag)
			{
				float? num = value;
				float? customerWrapper = _CustomerWrapper;
				if (((num.HasValue & customerWrapper.HasValue) ? new bool?(num.GetValueOrDefault() != customerWrapper.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead))
				{
					value = (myUnit.GetParentGroup().GroupLead.Navigator.SprintDrift ? myUnit.GetParentGroup().GroupLead.Navigator.SprintDrift_AverageSpeed : new float?(myUnit.GetParentGroup().GroupLead.DesiredSpeed));
				}
				_CustomerWrapper = value;
			}
		}
	}

	public virtual GeoPoint SprintDrift_Marker
	{
		get
		{
			return _SerializerWrapper;
		}
		set
		{
			_SerializerWrapper = value;
		}
	}

	public FormationStation UnitFormationStation
	{
		get
		{
			if (_InterpreterWrapper == null)
			{
				_InterpreterWrapper = new FormationStation();
				if (myUnit.GetParentGroup() != null && myUnit.GetParentGroup().GroupLead != null)
				{
					_InterpreterWrapper.BearingType = ReferencePoint.OrientationType.Rotating;
					CalculateFormationStationRelativeData();
				}
			}
			return _InterpreterWrapper;
		}
		set
		{
			_InterpreterWrapper = value;
		}
	}

	public Waypoint[] PlottedCourse
	{
		get
		{
			List<Waypoint> list = (myUnit.IsGroupLead() ? myUnit.GetParentGroup().Navigator.PlottedCourse.ToList() : _PlottedCourse.ToList());
			if ((list == null || list.Count == 0) && myUnit.Navigator.HasFlight && myUnit.Navigator.HasFlightPlan)
			{
				Waypoint[] flightPlan = myUnit.Navigator.GetFlight().FlightPlan;
				Waypoint[] array = flightPlan;
				foreach (Waypoint item in array)
				{
					list.Add(item);
				}
				if ((myUnit.IsAircraft && ((Aircraft)myUnit).AirborneTime > 0f) & !HaveReachedPoint(list.Last(), (int)myUnit.ParentScen.TimeCompression))
				{
					list = PopDic(list.ToArray()).ToList();
				}
			}
			if (list != null && list.Count > 0 && ((list[0].Type == Waypoint.WaypointType.WeaponTarget) & !myUnit.IsWeapon))
			{
				list.Remove(list[0]);
			}
			_PlottedCourse = list.ToArray();
			return list.ToArray();
		}
		set
		{
			_PlottedCourse = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.GetParentGroup().Navigator.PlottedCourse = value;
			}
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
	}

	public Waypoint[] PlottedCourse_PrePlanned
	{
		get
		{
			if (myUnit.IsGroupLead())
			{
				return myUnit.GetParentGroup().Navigator.PlottedCourse_PrePlanned;
			}
			return _PlottedCourse_PrePlanned;
		}
		set
		{
			_PlottedCourse_PrePlanned = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.GetParentGroup().Navigator.PlottedCourse_PrePlanned = value;
			}
		}
	}

	public bool IsInSupportTransit
	{
		get
		{
			if (myUnit.AssignedMissionOrPackage() == null)
			{
				return false;
			}
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
			{
				bool flag = false;
				SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(supportMission.NavigationCourse))
				{
					return false;
				}
				if (supportMission.NavigationCourse.Count == 0)
				{
					return false;
				}
				flag = (myUnit.IsAircraft ? (!DisableDic(ref supportMission.NavigationCourse, ref supportMission.NavigationCourse_10nm_Buffered, ref supportMission.NavigationCourse_10nm_ChangeCheck, 10, bool_1: false, bool_2: false)) : (!DisableDic(ref supportMission.NavigationCourse, ref supportMission.NavigationCourse_2nm_Buffered, ref supportMission.NavigationCourse_2nm_ChangeCheck, 2, bool_1: false, bool_2: false)));
				if (myUnit.IsRTB)
				{
					flag = true;
				}
				return flag;
			}
			return false;
		}
	}

	public bool IsInsidePatrolArea
	{
		get
		{
			try
			{
				if (myUnit.AssignedMissionOrPackage() == null)
				{
					return false;
				}
				if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
					if (myUnit.IsAircraft)
					{
						return DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_10nm_Buffered, ref patrol.PatrolArea_10nm_ChangeCheck, 10, bool_1: false, bool_2: false);
					}
					return DisableDic(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, bool_1: false, bool_2: false);
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100211", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_AttackIngressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					switch (PlottedCourse[0].Type)
					{
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.Refuel:
					{
						Waypoint[] plottedCourse = PlottedCourse;
						int num = 0;
						Waypoint waypoint;
						while (true)
						{
							if (num >= plottedCourse.Length)
							{
								return false;
							}
							waypoint = plottedCourse[num];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num++;
						}
						switch (waypoint.Type)
						{
						default:
							return false;
						case Waypoint.WaypointType.InitialPoint:
						case Waypoint.WaypointType.Target:
						case Waypoint.WaypointType.WeaponLaunch:
						case Waypoint.WaypointType.WeaponTarget:
							return true;
						}
					}
					default:
						return false;
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (myUnit.AI.IsEscort)
				{
					return false;
				}
				Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
				int? num = (int?)waypointType;
				bool? flag;
				bool? flag12 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 5) : null));
				bool? flag21;
				bool? flag22;
				if (flag12.HasValue && flag.GetValueOrDefault())
				{
					flag21 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag12 = (flag22 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 26) : null));
					flag21 = ((!flag12.HasValue) ? null : (flag22.GetValueOrDefault() | flag));
				}
				bool? flag23 = flag21;
				flag22 = flag21;
				bool? flag24;
				bool? flag25;
				if (flag22.HasValue && flag23.GetValueOrDefault())
				{
					flag24 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag22 = (flag25 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 27) : null));
					flag24 = ((!flag22.HasValue) ? null : (flag25.GetValueOrDefault() | flag23));
				}
				bool? flag26 = flag24;
				flag25 = flag24;
				bool? flag27;
				bool? flag2;
				if (flag25.HasValue && flag26.GetValueOrDefault())
				{
					flag27 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag25 = (flag2 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 8) : null));
					flag27 = ((!flag25.HasValue) ? null : (flag2.GetValueOrDefault() | flag26));
				}
				bool? flag3 = flag27;
				flag2 = flag27;
				bool? flag4;
				bool? flag5;
				if (flag2.HasValue && flag3.GetValueOrDefault())
				{
					flag4 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag2 = (flag5 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 7) : null));
					flag4 = ((!flag2.HasValue) ? null : (flag5.GetValueOrDefault() | flag3));
				}
				bool? flag6 = flag4;
				flag5 = flag4;
				bool? flag7;
				bool? flag8;
				if (flag5.HasValue && flag6.GetValueOrDefault())
				{
					flag7 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag5 = (flag8 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 17) : null));
					flag7 = ((!flag5.HasValue) ? null : (flag8.GetValueOrDefault() | flag6));
				}
				bool? flag9 = flag7;
				flag8 = flag7;
				bool? flag10;
				bool? flag11;
				if (flag8.HasValue && flag9.GetValueOrDefault())
				{
					flag10 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag8 = (flag11 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 10) : null));
					flag10 = ((!flag8.HasValue) ? null : (flag11.GetValueOrDefault() | flag9));
				}
				bool? flag13 = flag10;
				flag11 = flag10;
				bool? flag14;
				bool? flag15;
				if (flag11.HasValue && flag13.GetValueOrDefault())
				{
					flag14 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag11 = (flag15 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 19) : null));
					flag14 = ((!flag11.HasValue) ? null : (flag15.GetValueOrDefault() | flag13));
				}
				bool? flag16 = flag14;
				flag15 = flag14;
				bool? flag17;
				bool? flag18;
				if (flag15.HasValue && flag16.GetValueOrDefault())
				{
					flag17 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag15 = (flag18 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 12) : null));
					flag17 = ((!flag15.HasValue) ? null : (flag18.GetValueOrDefault() | flag16));
				}
				flag18 = flag17;
				if (flag18.GetValueOrDefault())
				{
					return true;
				}
				num = (int?)waypointType;
				flag11 = (flag15 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null));
				bool? flag19;
				if (flag11.HasValue && flag15.GetValueOrDefault())
				{
					flag19 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag11 = (flag13 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 14) : null));
					flag19 = ((!flag11.HasValue) ? null : (flag13.GetValueOrDefault() | flag15));
				}
				flag18 = flag19;
				flag13 = flag19;
				bool? flag20;
				if (flag13.HasValue && flag18.GetValueOrDefault())
				{
					flag20 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag13 = (flag16 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null));
					flag20 = ((!flag13.HasValue) ? null : (flag16.GetValueOrDefault() | flag18));
				}
				flag16 = flag20;
				if (flag16.GetValueOrDefault())
				{
					Waypoint[] plottedCourse = PlottedCourse;
					int num2 = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num2 < plottedCourse.Length)
						{
							waypoint = plottedCourse[num2];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num2++;
							continue;
						}
						return false;
					}
					switch (waypoint.Type)
					{
					default:
						return false;
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_FinalTargetRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					switch (PlottedCourse[0].Type)
					{
					default:
						return false;
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.Refuel:
					{
						Waypoint[] plottedCourse = PlottedCourse;
						int num = 0;
						Waypoint waypoint;
						while (true)
						{
							if (num >= plottedCourse.Length)
							{
								return false;
							}
							waypoint = plottedCourse[num];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num++;
						}
						Waypoint.WaypointType type = waypoint.Type;
						if (type != Waypoint.WaypointType.Target && type != Waypoint.WaypointType.WeaponTarget)
						{
							return false;
						}
						return true;
					}
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (myUnit.AI.IsEscort)
				{
					return false;
				}
				Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
				int? num = (int?)waypointType;
				bool? flag;
				bool? flag2 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 13) : null));
				bool? flag3;
				bool? flag4;
				if (flag2.HasValue && flag.GetValueOrDefault())
				{
					flag3 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag2 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 9) : null));
					flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
				}
				bool? flag5 = flag3;
				flag4 = flag3;
				bool? flag6;
				bool? flag7;
				if (flag4.HasValue && flag5.GetValueOrDefault())
				{
					flag6 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag4 = (flag7 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 11) : null));
					flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() | flag5));
				}
				flag7 = flag6;
				if (flag7.GetValueOrDefault())
				{
					return true;
				}
				num = (int?)waypointType;
				flag2 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null));
				bool? flag8;
				if (flag2.HasValue && flag4.GetValueOrDefault())
				{
					flag8 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag2 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 14) : null));
					flag8 = ((!flag2.HasValue) ? null : (flag.GetValueOrDefault() | flag4));
				}
				flag7 = flag8;
				flag = flag8;
				bool? flag9;
				if (flag.HasValue && flag7.GetValueOrDefault())
				{
					flag9 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag = (flag5 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null));
					flag9 = ((!flag.HasValue) ? null : (flag5.GetValueOrDefault() | flag7));
				}
				flag5 = flag9;
				if (flag5.GetValueOrDefault())
				{
					Waypoint[] plottedCourse = PlottedCourse;
					int num2 = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num2 < plottedCourse.Length)
						{
							waypoint = plottedCourse[num2];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num2++;
							continue;
						}
						return false;
					}
					switch (waypoint.Type)
					{
					default:
						return false;
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeEgress:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (myUnit.AI.IsEscort)
				{
					return false;
				}
				Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
				int? num = (int?)waypointType;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 11) : null).GetValueOrDefault())
				{
					return true;
				}
				num = (int?)waypointType;
				bool? flag;
				bool? flag2 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null));
				bool? flag3;
				bool? flag4;
				if (flag2.HasValue && flag.GetValueOrDefault())
				{
					flag3 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag2 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 14) : null));
					flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
				}
				bool? flag5 = flag3;
				flag4 = flag3;
				bool? flag6;
				bool? flag7;
				if (flag4.HasValue && flag5.GetValueOrDefault())
				{
					flag6 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag4 = (flag7 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null));
					flag6 = ((!flag4.HasValue) ? null : (flag7.GetValueOrDefault() | flag5));
				}
				flag7 = flag6;
				if (flag7.GetValueOrDefault())
				{
					Waypoint[] plottedCourse = PlottedCourse;
					int num2 = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num2 < plottedCourse.Length)
						{
							waypoint = plottedCourse[num2];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num2++;
							continue;
						}
						return false;
					}
					if (waypoint.Type == Waypoint.WaypointType.LandingMarshal)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_StationIngressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				switch (PlottedCourse[0].Type)
				{
				default:
					return false;
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
					return true;
				case Waypoint.WaypointType.PathfindingPoint:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.Refuel:
				{
					Waypoint[] plottedCourse = PlottedCourse;
					int num = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num >= plottedCourse.Length)
						{
							return false;
						}
						waypoint = plottedCourse[num];
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							break;
						}
						num++;
					}
					switch (waypoint.Type)
					{
					default:
						return false;
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
						return true;
					case Waypoint.WaypointType.LandingMarshal:
						return false;
					}
				}
				case Waypoint.WaypointType.LandingMarshal:
					return false;
				}
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HoldOrAssemble
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint.WaypointType type = PlottedCourse[0].Type;
				if (type != Waypoint.WaypointType.Assemble && (uint)(type - 26) > 1u)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_StationEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint.WaypointType type = PlottedCourse[0].Type;
				if (type <= Waypoint.WaypointType.TurningPoint)
				{
					if (type != Waypoint.WaypointType.PathfindingPoint && type != Waypoint.WaypointType.TurningPoint)
					{
						return false;
					}
				}
				else
				{
					switch (type)
					{
					default:
						return false;
					case Waypoint.WaypointType.LandingMarshal:
						return true;
					case Waypoint.WaypointType.Refuel:
						break;
					}
				}
				Waypoint[] plottedCourse = PlottedCourse;
				int num = 0;
				Waypoint waypoint;
				while (true)
				{
					if (num < plottedCourse.Length)
					{
						waypoint = plottedCourse[num];
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				if (waypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_OnStation
	{
		get
		{
			if (HasPlottedCourse())
			{
				if ((uint)(PlottedCourse[0].Type - 20) <= 4u)
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseIngressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					switch (PlottedCourse[0].Type)
					{
					case Waypoint.WaypointType.Split:
						return true;
					default:
					{
						bool flag = false;
						Waypoint[] plottedCourse = PlottedCourse;
						Waypoint[] array = plottedCourse;
						foreach (Waypoint waypoint in array)
						{
							if (waypoint.Type == Waypoint.WaypointType.Formate || waypoint.Type == Waypoint.WaypointType.StrikeIngress || waypoint.Type == Waypoint.WaypointType.StrikeEgress)
							{
								flag = true;
								break;
							}
						}
						if (PlottedCourse[0].Type != Waypoint.WaypointType.InitialPoint && PlottedCourse[0].Type != Waypoint.WaypointType.WeaponLaunch)
						{
							plottedCourse = PlottedCourse;
							Waypoint[] array2 = plottedCourse;
							foreach (Waypoint waypoint2 in array2)
							{
								if (waypoint2.Type != Waypoint.WaypointType.TurningPoint && waypoint2.Type != Waypoint.WaypointType.Refuel && waypoint2.Type != Waypoint.WaypointType.PathfindingPoint)
								{
									switch (waypoint2.Type)
									{
									case Waypoint.WaypointType.Split:
										return true;
									case Waypoint.WaypointType.InitialPoint:
									case Waypoint.WaypointType.WeaponLaunch:
										if (flag)
										{
											return false;
										}
										return true;
									case Waypoint.WaypointType.Formate:
									case Waypoint.WaypointType.Target:
									case Waypoint.WaypointType.LandingMarshal:
									case Waypoint.WaypointType.StrikeIngress:
									case Waypoint.WaypointType.StrikeEgress:
									case Waypoint.WaypointType.WeaponTarget:
										return false;
									}
									break;
								}
							}
							return false;
						}
						if (flag)
						{
							return false;
						}
						return true;
					}
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.WeaponTarget:
						return false;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_AttackEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (myUnit.AI.IsEscort)
				{
					return false;
				}
				switch (PlottedCourse[0].Type)
				{
				default:
					return false;
				case Waypoint.WaypointType.PathfindingPoint:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.Refuel:
				{
					Waypoint[] plottedCourse = PlottedCourse;
					Waypoint[] array = plottedCourse;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							Waypoint.WaypointType type = waypoint.Type;
							if (type != Waypoint.WaypointType.Formate && type != Waypoint.WaypointType.StrikeEgress)
							{
								return false;
							}
							return true;
						}
					}
					return false;
				}
				case Waypoint.WaypointType.Formate:
				case Waypoint.WaypointType.StrikeEgress:
					return true;
				}
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HasLeftTargetArea
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (Information.IsNothing(PreviousWaypointType))
				{
					return false;
				}
				if (myUnit.AI.IsEscort)
				{
					return false;
				}
				Waypoint.WaypointType? previousWaypointType = PreviousWaypointType;
				int? num = (int?)previousWaypointType;
				bool? flag;
				bool? flag2 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 13) : null));
				bool? flag3;
				bool? flag4;
				if (flag2.HasValue && flag.GetValueOrDefault())
				{
					flag3 = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag2 = (flag4 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 9) : null));
					flag3 = ((!flag2.HasValue) ? null : (flag4.GetValueOrDefault() | flag));
				}
				flag4 = flag3;
				if (flag4.GetValueOrDefault())
				{
					return true;
				}
				num = (int?)previousWaypointType;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 11) : null).GetValueOrDefault())
				{
					return true;
				}
				num = (int?)previousWaypointType;
				bool? flag5 = (flag2 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 6) : null));
				bool? flag6;
				bool? flag7;
				if (flag5.HasValue && flag2.GetValueOrDefault())
				{
					flag6 = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag5 = (flag7 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 14) : null));
					flag6 = ((!flag5.HasValue) ? null : (flag7.GetValueOrDefault() | flag2));
				}
				flag4 = flag6;
				flag7 = flag6;
				bool? flag8;
				if (flag7.HasValue && flag4.GetValueOrDefault())
				{
					flag8 = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag7 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null));
					flag8 = ((!flag7.HasValue) ? null : (flag.GetValueOrDefault() | flag4));
				}
				flag = flag8;
				if (flag.GetValueOrDefault())
				{
					Waypoint[] plottedCourse = PlottedCourse;
					Waypoint[] array = plottedCourse;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							switch (waypoint.Type)
							{
							case Waypoint.WaypointType.LandingMarshal:
								return true;
							default:
								return false;
							case Waypoint.WaypointType.Formate:
							case Waypoint.WaypointType.StrikeEgress:
								return true;
							}
						}
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HasObjectiveWaypoints
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint[] plottedCourse = PlottedCourse;
				for (int i = 0; i < plottedCourse.Length; i = checked(i + 1))
				{
					switch (plottedCourse[i].Type)
					{
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
						return true;
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint[] plottedCourse = PlottedCourse;
				for (int i = 0; i < plottedCourse.Length; i = checked(i + 1))
				{
					switch (plottedCourse[i].Type)
					{
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.Refuel:
					{
						Waypoint[] plottedCourse2 = PlottedCourse;
						Waypoint[] array = plottedCourse2;
						foreach (Waypoint waypoint in array)
						{
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								switch (waypoint.Type)
								{
								case Waypoint.WaypointType.StationStart_Racetrack:
								case Waypoint.WaypointType.StationStart_FigureEight:
								case Waypoint.WaypointType.StationStart_Area:
								case Waypoint.WaypointType.StationStart_RaceTrackRandom:
								case Waypoint.WaypointType.StationEnd:
									return true;
								default:
									return false;
								case Waypoint.WaypointType.Assemble:
								case Waypoint.WaypointType.InitialPoint:
								case Waypoint.WaypointType.Split:
								case Waypoint.WaypointType.Formate:
								case Waypoint.WaypointType.Target:
								case Waypoint.WaypointType.LandingMarshal:
								case Waypoint.WaypointType.StrikeIngress:
								case Waypoint.WaypointType.StrikeEgress:
								case Waypoint.WaypointType.WeaponLaunch:
								case Waypoint.WaypointType.WeaponTarget:
								case Waypoint.WaypointType.HoldStart:
								case Waypoint.WaypointType.HoldEnd:
									return true;
								}
							}
						}
						break;
					}
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
						return true;
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnLocalizationRun
	{
		get
		{
			if (PlottedCourse.Count() <= 0)
			{
				return false;
			}
			return PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun;
		}
	}

	public bool HasPathfindingPlottedCourse
	{
		get
		{
			try
			{
				if (Information.IsNothing(PlottedCourse))
				{
					return false;
				}
				if (PlottedCourse.Count() == 0)
				{
					return false;
				}
				if (Information.IsNothing(PlottedCourse[0]))
				{
					return false;
				}
				return PlottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint;
			}
			catch (NullReferenceException projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200031", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public bool NextWaypointIsManual
	{
		get
		{
			if (HasPlottedCourse())
			{
				return PlottedCourse[0].Type == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			}
			return false;
		}
	}

	public bool HasFlight => !Information.IsNothing(GetFlight());

	public bool HasFlightPlan
	{
		get
		{
			bool result = false;
			try
			{
				Waypoint[] array = GetFlight()?.FlightPlan;
				if (array == null)
				{
					result = false;
					return false;
				}
				return result = array.Length != 0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101249", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public virtual bool UseCostBasedPathfinder
	{
		get
		{
			if (Information.IsNothing(refWrapper))
			{
				if (myUnit.IsAircraft)
				{
					refWrapper = false;
				}
				else
				{
					refWrapper = true;
				}
			}
			return refWrapper.Value;
		}
	}

	public float AC_WP_Distance_threashold
	{
		[CompilerGenerated]
		get
		{
			return proccesorWrapper;
		}
		[CompilerGenerated]
		set
		{
			proccesorWrapper = value;
		}
	}

	public float HELI_WP_Distance_threashold
	{
		[CompilerGenerated]
		get
		{
			return m_StatusWrapper;
		}
		[CompilerGenerated]
		set
		{
			m_StatusWrapper = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_0()
	{
		return m_ContainerWrapper;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(bool bool_1)
	{
		m_ContainerWrapper = bool_1;
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit_Navigator");
			if (!myUnit.IsGroupLead() && PlottedCourse.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("PC");
				List<Waypoint> list = new List<Waypoint>();
				list.AddRange(PlottedCourse);
				foreach (Waypoint item in list)
				{
					if (!Information.IsNothing(item))
					{
						item.ToXML(ref xmlWriter_0, ref hashSet_0);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (PlottedCourse_PrePlanned.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("PC_PP");
				List<Waypoint> list2 = new List<Waypoint>();
				list2.AddRange(PlottedCourse_PrePlanned);
				foreach (Waypoint item2 in list2)
				{
					if (!Information.IsNothing(item2))
					{
						item2.ToXML(ref xmlWriter_0, ref hashSet_0);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(_Flight))
			{
				xmlWriter_0.WriteElementString("Flight", _Flight.ObjectID);
			}
			xmlWriter_0.WriteElementString("MPO", ManualPlotOverride.ToString());
			if (!Information.IsNothing(TankerFollowsMe))
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe", TankerFollowsMe.Value.ToString());
			}
			if (TankerFollowsMe_NumberOfWaypoints != 0)
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe_NumberOfWaypoints", TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (myUnit.IsGroupMember())
			{
				if (UnitFormationStation.Bearing != 0f)
				{
					xmlWriter_0.WriteElementString("FS_B", XmlConvert.ToString(UnitFormationStation.Bearing));
				}
				if (UnitFormationStation.Distance != 0f)
				{
					xmlWriter_0.WriteElementString("FS_D", XmlConvert.ToString(UnitFormationStation.Distance));
				}
				xmlWriter_0.WriteElementString("FS_BT", XmlConvert.ToString((byte)UnitFormationStation.BearingType));
			}
			if (!Information.IsNothing(SupportMission_NextRefPoint))
			{
				xmlWriter_0.WriteStartElement("SM_NRP");
				xmlWriter_0.WriteRaw(SupportMission_NextRefPoint.ToXML(ref hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (PreviousWaypointTime.HasValue)
			{
				xmlWriter_0.WriteElementString("PreviousWaypointTime", PreviousWaypointTime.Value.ToBinary().ToString());
			}
			if (PreviousWaypointType.HasValue)
			{
				xmlWriter_0.WriteElementString("PreviousWaypointType", PreviousWaypointType.Value.ToString());
			}
			xmlWriter_0.WriteElementString("TTNPC", ManualPlotOverride.ToString());
			if (SprintDrift)
			{
				xmlWriter_0.WriteElementString("SD", "True");
				xmlWriter_0.WriteElementString("SD_Avg", XmlConvert.ToString(SprintDrift_AverageSpeed.Value));
				xmlWriter_0.WriteElementString("SD_M", XmlConvert.ToString(SprintDrift_Marker.Longitude) + "_" + XmlConvert.ToString(SprintDrift_Marker.Latitude));
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100199", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_Navigator activeUnit_Navigator = new ActiveUnit_Navigator(ref activeUnit_0);
			activeUnit_Navigator.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TankerFollowsMe_NumberOfWaypoints":
						activeUnit_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "SD_M":
					{
						string[] array = xmlNode.InnerText.Split('_');
						activeUnit_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
						break;
					}
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						activeUnit_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "Flight":
						activeUnit_Navigator._Flight_ID = xmlNode.InnerText;
						break;
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							activeUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							activeUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "SD":
						activeUnit_Navigator.SprintDrift = true;
						break;
					case "SD_Avg":
						activeUnit_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "MPO":
					case "ManualPlotOverride":
						activeUnit_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "TimeToNextPathfinderCheck":
					case "TTNPC":
						activeUnit_Navigator.TimeToNextPathfinderCheck = Conversions.ToSingle(xmlNode.InnerText);
						if (activeUnit_Navigator.TimeToNextPathfinderCheck > 15f)
						{
							activeUnit_Navigator.TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(2, 15);
						}
						break;
					case "FS_B":
					case "FormationStation_Bearing":
						activeUnit_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_3 = xmlNode.ChildNodes[0];
						activeUnit_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0);
						break;
					}
					case "FS_BT":
						activeUnit_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PC":
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								Waypoint theAC2 = Waypoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref activeUnit_Navigator._PlottedCourse, theAC2);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "PC_PP":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator3.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref activeUnit_Navigator._PlottedCourse_PrePlanned, theAC);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "FS_D":
					case "FormationStation_Distance":
						activeUnit_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TankerFollowsMe":
						activeUnit_Navigator.TankerFollowsMe = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return activeUnit_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100200", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_Navigator result = new ActiveUnit_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_1)
	{
		if (!myUnit.IsAircraft)
		{
			return;
		}
		bool flag = false;
		foreach (Mission mission in myUnit.GetUnitSide().Missions)
		{
			if (myUnit.AssignedMissionOrPackage() != mission || !mission.RestartValue())
			{
				continue;
			}
			foreach (Mission.Flight flight in mission.FlightList)
			{
				if (!Information.IsNothing(flight.ObjectID) && Operators.CompareString(flight.ObjectID, _Flight_ID, TextCompare: false) == 0)
				{
					SetFlight(bool_1: true, flight);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			break;
		}
	}

	public virtual void ResetTimeToNextPathfinderCheck()
	{
		if (TimeToNextPathfinderCheck > 2f)
		{
			TimeToNextPathfinderCheck = 2f;
		}
	}

	internal float CalculateDic()
	{
		float num = 0f;
		float num2 = 0f;
		if (myUnit.IsGroupWingman())
		{
			return 0f;
		}
		if (PlottedCourse.Length != 0 && !Information.IsNothing(PlottedCourse.First()))
		{
			num2 = Module_Unit.RangeToPoint_Horiz(myUnit, PlottedCourse.First().Latitude, PlottedCourse.First().Longitude);
		}
		num = num2;
		if (!Information.IsNothing(SprintDrift_Marker) && !Information.IsNothing(SprintDrift_AverageSpeed) && myUnit.DesiredSpeed > 0f)
		{
			float num3 = Module_Unit.RangeToPoint_Horiz(myUnit, SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude);
			switch (myUnit.Kinematics.SprintAndDriftCadence)
			{
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
			{
				float desiredSpeed2 = myUnit.DesiredSpeed;
				float? sprintDrift_AverageSpeed2 = SprintDrift_AverageSpeed;
				if ((sprintDrift_AverageSpeed2.HasValue ? new bool?(desiredSpeed2 < sprintDrift_AverageSpeed2.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					num = (6f - num3) / (SprintDrift_AverageSpeed.Value - myUnit.DesiredSpeed) * myUnit.DesiredSpeed;
				}
				break;
			}
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
			{
				float desiredSpeed = myUnit.DesiredSpeed;
				float? sprintDrift_AverageSpeed = SprintDrift_AverageSpeed;
				if ((sprintDrift_AverageSpeed.HasValue ? new bool?(desiredSpeed > sprintDrift_AverageSpeed.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					num = num3 / (myUnit.DesiredSpeed - SprintDrift_AverageSpeed.Value) * myUnit.DesiredSpeed;
				}
				break;
			}
			}
		}
		if (num > num2)
		{
			num = num2;
		}
		return num;
	}

	public void SetSprintDriftMarker(bool bool_1)
	{
		SprintDrift_Marker = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude());
		if (bool_1)
		{
			SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
		}
		myUnit.Kinematics.DesiredSpeedOverride = null;
	}

	public void PerformSprintDrift(float float_0)
	{
		try
		{
			if (Debugger.IsAttached && !myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				Debugger.Break();
			}
			float num = Math.Max(1f, float_0);
			if (Information.IsNothing(SprintDrift_Marker))
			{
				SprintDrift_Marker = new GeoPoint(myUnit.GetLongitude(), myUnit.GetLatitude());
			}
			if (Information.IsNothing(SprintDrift_AverageSpeed))
			{
				SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
			}
			float? sprintDrift_AverageSpeed = SprintDrift_AverageSpeed;
			if ((sprintDrift_AverageSpeed.HasValue ? new bool?(sprintDrift_AverageSpeed.GetValueOrDefault() <= 0f) : null).GetValueOrDefault() && !myUnit.IsGroupWingman())
			{
				myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
				SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
			}
			float float_;
			if (myUnit.IsGroupWingman())
			{
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				if (Information.IsNothing(groupLead))
				{
					return;
				}
				double longitude = groupLead.GetLongitude();
				double latitude = groupLead.GetLatitude();
				GeoPoint sprintDrift_Marker = SprintDrift_Marker;
				double double_ = sprintDrift_Marker.Longitude;
				GeoPoint sprintDrift_Marker2 = SprintDrift_Marker;
				double double_2 = sprintDrift_Marker2.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, UnitFormationStation.Distance, UnitFormationStation.GetResultantBearing(myUnit));
				sprintDrift_Marker2.Latitude = double_2;
				sprintDrift_Marker.Longitude = double_;
				float_ = groupLead.CurrentHeading;
				if (groupLead.Navigator.SprintDrift)
				{
					SprintDrift_AverageSpeed = groupLead.Navigator.SprintDrift_AverageSpeed;
				}
				else
				{
					SprintDrift_AverageSpeed = groupLead.DesiredSpeed;
				}
			}
			else
			{
				if (!SprintDrift_AverageSpeed.HasValue)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (PlottedCourse.Length == 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					SetSprintDriftMarker(bool_1: false);
					return;
				}
				if (!(Math.Abs(MathFunctions.DeleteRequest(Module_Unit.BearingToPoint_True(myUnit, PlottedCourse.First().Latitude, PlottedCourse.First().Longitude), myUnit.CurrentHeading)) <= 2f))
				{
					myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(myUnit, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
					SetSprintDriftMarker(bool_1: false);
					return;
				}
				double double_3 = SprintDrift_AverageSpeed.Value * (num / 3600f);
				GeoPoint geoPoint = PlottedCourse.First();
				float_ = Math2.PublishClass(SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude, geoPoint.Latitude, geoPoint.Longitude);
				double longitude2 = SprintDrift_Marker.Longitude;
				double latitude2 = SprintDrift_Marker.Latitude;
				GeoPoint sprintDrift_Marker3 = SprintDrift_Marker;
				double double_4 = sprintDrift_Marker3.Longitude;
				GeoPoint sprintDrift_Marker4 = SprintDrift_Marker;
				double double_5 = sprintDrift_Marker4.Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams_NoRef(longitude2, latitude2, ref double_4, ref double_5, ref double_3, ref float_);
				sprintDrift_Marker4.Latitude = double_5;
				sprintDrift_Marker3.Longitude = double_4;
			}
			switch (myUnit.Kinematics.SprintAndDriftCadence)
			{
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, float_);
				myUnit.DesiredSpeed = Math.Max(2f, Math.Min(myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false), SprintDrift_AverageSpeed.Value - 1f));
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				if (Module_Unit.RangeToPoint_Horiz(myUnit, SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude) > 6f)
				{
					myUnit.Kinematics.SprintAndDriftCadence = ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint;
				}
				break;
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
			{
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude));
				myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude());
				if (myUnit.Navigator.AvoidCavitation)
				{
					myUnit.Kinematics.AdjustSpeedForCavitation();
				}
				ActiveUnit.Throttle throttleSuitableForThisSpeed = myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), myUnit.DesiredSpeed);
				if ((int)throttleSuitableForThisSpeed > 2 && myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries && Operators.CompareString(myUnit.ParentScen.GetCurrentSide().ObjectID, myUnit.GetUnitSide().ObjectID, TextCompare: false) != 0)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					SetSprintDriftMarker(bool_1: false);
				}
				else
				{
					myUnit.SetThrottle(throttleSuitableForThisSpeed);
				}
				if (HaveReachedPoint(SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude, float_0))
				{
					myUnit.Kinematics.SprintAndDriftCadence = ActiveUnit_Kinematics._SprintAndDriftCadence.Drift;
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101419", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Waypoint[] PopDic(Waypoint[] waypoint_0)
	{
		Waypoint waypoint = null;
		foreach (Waypoint item in waypoint_0.OrderBy((Waypoint waypoint_0) => Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude)).ToList())
		{
			if ((Math.Abs(Module_Unit.BearingToPoint_Relative(myUnit, item.Latitude, item.Longitude)) < 30f) | (Math.Abs(Module_Unit.BearingToPoint_Relative(myUnit, item.Latitude, item.Longitude)) > 330f))
			{
				waypoint = item;
				break;
			}
		}
		if (waypoint == null)
		{
			waypoint = waypoint_0.OrderBy((Waypoint waypoint_0) => Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude)).FirstOrDefault();
		}
		if (waypoint == null)
		{
			return waypoint_0;
		}
		List<Waypoint> list = new List<Waypoint>();
		Waypoint[] array = waypoint_0;
		Waypoint[] array2 = array;
		foreach (Waypoint waypoint2 in array2)
		{
			if (Operators.CompareString(waypoint2.ObjectID, waypoint.ObjectID, TextCompare: false) == 0)
			{
				break;
			}
			list.Add(waypoint2);
		}
		foreach (Waypoint item2 in list)
		{
			ArrayExtensions.Remove(ref waypoint_0, item2);
		}
		return waypoint_0;
	}

	[SpecialName]
	public Mission.Flight GetFlight(bool bool_1 = true)
	{
		if (bool_1)
		{
			if (myUnit.IsGroupLead())
			{
				return myUnit.GetParentGroup().Navigator.GetFlight();
			}
			return _Flight;
		}
		return _Flight;
	}

	[SpecialName]
	public void SetFlight(bool bool_1, Mission.Flight flight_0)
	{
		_Flight = flight_0;
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.SetFlight(bool_1: true, flight_0);
		}
	}

	public ActiveUnit_Navigator(ref ActiveUnit activeUnit_0)
	{
		_PlottedCourse = new Waypoint[0];
		_PlottedCourse_PrePlanned = new Waypoint[0];
		TankerIsBlockedByNoNavZone = false;
		TankerFollowsMe = null;
		TankerFollowsMe_NumberOfWaypoints = 0;
		TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 0.0;
		CheckNoNavZones_UnitMovementOnEveryPulse = true;
		connectionWrapper = new GeoPoint();
		m_ContextWrapper = false;
		WP_reach_cache_memory = new WP_reach_cache();
		AC_WP_Distance_threashold = 1f;
		HELI_WP_Distance_threashold = 0.01f;
		myUnit = activeUnit_0;
	}

	public virtual void ClearPlottedCourse()
	{
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.ClearPlottedCourse();
			return;
		}
		ArrayExtensions.Clear(ref _PlottedCourse);
		ArrayExtensions.Clear(ref _PlottedCourse_PrePlanned);
		if (!myUnit.IsGroup)
		{
			Pathfinding.CancelPathfindRequests(myUnit, null);
			PathFindingInProgress = false;
		}
	}

	public virtual void ClearFlight()
	{
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.ClearFlight();
			return;
		}
		SetFlight(bool_1: true, null);
		if (!myUnit.Navigator.HasPlottedCourse())
		{
			return;
		}
		Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
		Waypoint[] array = plottedCourse;
		foreach (Waypoint waypoint in array)
		{
			if (waypoint.Category == Waypoint.WaypointCategory.FlightPlan)
			{
				waypoint.Category = Waypoint.WaypointCategory.PlottedCourse;
			}
			waypoint.Type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
		}
	}

	public Waypoint GetNearestAccessibleSpot(double double_0, double double_1, ref List<ActiveUnit> list_0)
	{
		Waypoint waypoint = null;
		int int_ = 1;
		double double_2 = 0.0;
		double double_3 = 0.0;
		do
		{
			int int_2 = 0;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ref double_1, ref double_0, ref double_2, ref double_3, ref int_, ref int_2);
				ActiveUnit activeUnit = myUnit;
				double double_4 = double_3;
				double double_5 = double_2;
				int int_3 = 0;
				bool bool_ = true;
				bool bool_2 = true;
				string string_ = "";
				bool bool_3 = false;
				if (!activeUnit.CanMoveToThisLocation(double_4, double_5, ref int_3, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_0, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
				{
					int_2++;
					continue;
				}
				waypoint = new Waypoint(double_2, double_3, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				break;
			}
			while (int_2 <= 359);
			if (!Information.IsNothing(waypoint))
			{
				break;
			}
			int_++;
		}
		while (int_ <= 10000);
		return waypoint;
	}

	public bool GetNearestAccessibleSpot(double double_0, double double_1, ref double double_2, ref double double_3, bool bool_1, bool bool_2, bool bool_3, float float_0, ref List<ActiveUnit> list_0, bool bool_4)
	{
		int int_ = 1;
		do
		{
			int int_2 = 0;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ref double_1, ref double_0, ref double_3, ref double_2, ref int_, ref int_2);
				ActiveUnit activeUnit = myUnit;
				double double_4 = double_2;
				double double_5 = double_3;
				int int_3 = 0;
				bool bool_5 = true;
				bool bool_6 = true;
				string string_ = "";
				bool bool_7 = false;
				if (!activeUnit.CanMoveToThisLocation(double_4, double_5, ref int_3, bool_1, bool_2, bool_3, ref bool_5, bool_4: false, ref bool_6, null, null, ref list_0, float_0, bool_4, bool_7: false, ref string_, ref bool_7))
				{
					int_2++;
					continue;
				}
				return true;
			}
			while (int_2 <= 359);
			int_++;
		}
		while (int_ <= 10000);
		return false;
	}

	public void Housekeeping(float float_0)
	{
		try
		{
			if (myUnit.IsFixedFacility)
			{
				bool_0 = false;
				return;
			}
			TimeToNextPathfinderCheck -= float_0;
			if (TimeToNextPathfinderCheck <= 0f && myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				ActiveUnit string_ = myUnit;
				Exception exception_ = null;
				if (!Pathfinding.FindStub(string_, null, ref exception_))
				{
					bool_0 = true;
				}
				if (myUnit.IsAircraft)
				{
					TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(30, 61);
				}
				else if (myUnit.IsFixedFacility)
				{
					TimeToNextPathfinderCheck = float.MaxValue;
				}
				else if (myUnit.IsFacility)
				{
					TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(180, 361);
				}
				else
				{
					TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(360, 721);
				}
				if (myUnit.IsMCMPlatform && (myUnit.IsShip || myUnit.IsSubmarine))
				{
					if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()) && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
					{
						MineClearingMission mineClearingMission = (MineClearingMission)myUnit.AssignedMissionOrPackage();
						if (!Information.IsNothing(mineClearingMission) && myUnit.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false))
						{
							TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(10, 16);
						}
					}
				}
				else if (myUnit.IsMineLayingPlatform && (myUnit.IsShip || myUnit.IsSubmarine) && !Information.IsNothing(myUnit.AssignedMissionOrPackage()) && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
				{
					MiningMission miningMission = (MiningMission)myUnit.AssignedMissionOrPackage();
					if (!Information.IsNothing(miningMission) && myUnit.Navigator.DisableDic(ref miningMission.Area, ref miningMission.Area_1nm_Buffered, ref miningMission.Area_1nm_ChangeCheck, 1, bool_1: false, bool_2: false))
					{
						TimeToNextPathfinderCheck = GameGeneral.LockRandom_0.Next(10, 16);
					}
				}
			}
			else
			{
				bool_0 = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 100201", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool InstantiateDic(double double_0, double double_1, float float_0, float float_1, float float_2, Misc.ExtendPhase extendPhase_0 = Misc.ExtendPhase.Standard)
	{
		try
		{
			if (extendPhase_0 != Misc.ExtendPhase.LiningUp && extendPhase_0 != 0)
			{
				if (myUnit.CurrentSpeed == 0f)
				{
					return false;
				}
				float float_3 = Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_0, double_1);
				if ((double)Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, float_3)) < 0.5)
				{
					return false;
				}
				float num = Module_Unit.RangeToPoint_Horiz(myUnit, double_0, double_1);
				float num2;
				if (myUnit.IsWeapon)
				{
					float_0 = 0f;
					num2 = 0f;
				}
				else
				{
					num2 = Math.Min(myUnit.CurrentSpeed / (3600f / float_0), float_1 * 2f);
				}
				float num3 = Misc.TurnRadius(myUnit.CurrentSpeed, float_2);
				float num4 = num2 + float_1;
				if (num > num3 * 2f && extendPhase_0 == Misc.ExtendPhase.Standard)
				{
					return false;
				}
				if (float_1 > 0f && num < num4)
				{
					return true;
				}
				if (extendPhase_0 == Misc.ExtendPhase.Extending || extendPhase_0 == Misc.ExtendPhase.Standard)
				{
					float float_4;
					float float_5;
					if (myUnit.IsWeapon)
					{
						float_4 = Math2.UpdateClass(myUnit.CurrentHeading - 135f);
						float_5 = Math2.UpdateClass(myUnit.CurrentHeading + 135f);
					}
					else
					{
						float_4 = Math2.UpdateClass(myUnit.CurrentHeading - 90f);
						float_5 = Math2.UpdateClass(myUnit.CurrentHeading + 90f);
					}
					double double_2 = 0.0;
					double double_3 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_2, ref double_3, num3 + num4, float_4);
					if (Math2.VerifyClass(double_3, double_2, double_0, double_1) < num3 + num4)
					{
						return true;
					}
					double double_4 = 0.0;
					double double_5 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_4, ref double_5, num3 + num4, float_5);
					if (Math2.VerifyClass(double_5, double_4, double_0, double_1) < num3 + num4)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101258", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void ExtendIfNecessary(float float_0, ref Waypoint waypoint_0, double double_0, double double_1, float float_1, float float_2, float float_3, Misc.ExtendPhase extendPhase_0 = Misc.ExtendPhase.Standard)
	{
		try
		{
			bool flag;
			if (ExtendTimer <= 0.0)
			{
				if (flag = InstantiateDic(double_0, double_1, float_1, float_2, float_3, extendPhase_0))
				{
					ExtendTimer = 5.0;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (myUnit.IsAircraft && IsOnAutoPlannerPlottedCourse && !Information.IsNothing(waypoint_0) && !waypoint_0.IncludeReponse() && !waypoint_0.ConcatReponse() && ((waypoint_0.Type != Waypoint.WaypointType.Target && waypoint_0.Type != Waypoint.WaypointType.WeaponTarget) || myUnit.WeaponState != 0))
				{
					bool bool_ = true;
					bool bool_2 = false;
					CheckIfReachedWaypoint(1f, ref bool_, ref bool_2);
					ExtendTimer = 0.0;
				}
				else if (!Information.IsNothing(waypoint_0) && waypoint_0.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					bool bool_3 = true;
					bool bool_4 = false;
					CheckIfReachedWaypoint(1f, ref bool_3, ref bool_4);
					ExtendTimer = 0.0;
				}
				else
				{
					float float_4 = Math2.PublishClass(double_0, double_1, myUnit.GetLatitude(), myUnit.GetLongitude());
					myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, float_4);
					ExtendTimer -= float_0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100202", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsFinishingSupportMissionCourse(float float_0)
	{
		try
		{
			SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
			if (supportMission.NavigationLoopType == SupportMission.SupportMissionNavigationLoopType.ContinousLoop)
			{
				return false;
			}
			if (Information.IsNothing(SupportMission_NextRefPoint))
			{
				return false;
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, float_0))
			{
				if (supportMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) == supportMission.NavigationCourse.Count - 1)
				{
					SupportMission_NextRefPoint = null;
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100203", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return true;
		}
	}

	public virtual void EgressToRejoinPoint(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
			{
				byte? b = (byte?)myUnit.Doctrine.GetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					myUnit.Doctrine.SetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.No);
				}
			}
			List<Waypoint> list = PlottedCourse.ToList();
			List<Waypoint> list2 = new List<Waypoint>();
			foreach (Waypoint item in list)
			{
				Waypoint waypoint_ = item;
				if (waypoint_.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list2.Add(waypoint_);
				}
				else if (waypoint_.Type == Waypoint.WaypointType.InitialPoint || waypoint_.Type == Waypoint.WaypointType.WeaponLaunch || waypoint_.Type == Waypoint.WaypointType.Target || waypoint_.Type == Waypoint.WaypointType.WeaponTarget || waypoint_.Type == Waypoint.WaypointType.StrikeIngress)
				{
					ApplyWaypointSpeedAltToUnit(waypoint_);
					ApplyWaypointDoctrineToUnit(waypoint_);
					list2.Add(waypoint_);
					AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_);
				}
			}
			foreach (Waypoint item2 in list2)
			{
				ApplyWaypointSpeedAltToUnit(item2);
				ApplyWaypointDoctrineToUnit(item2);
				RemoveWaypoint_Soft(item2, bool_1: false);
			}
			if (myUnit.Navigator.HasFlight)
			{
				myUnit.Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne_EgressLeg);
			}
			HeadToFirstWaypoint(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101371", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AdjustTankerMustFollowMe_NumberOfWaypoints(ref Waypoint waypoint_0)
	{
		if (Information.IsNothing(TankerFollowsMe))
		{
			TankerFollowsMe_NumberOfWaypoints = 0;
			return;
		}
		if (TankerFollowsMe_NumberOfWaypoints == -98)
		{
			if (waypoint_0.IncludeReponse())
			{
				TankerFollowsMe = null;
				TankerFollowsMe_NumberOfWaypoints = 0;
			}
		}
		else if (TankerFollowsMe_NumberOfWaypoints == -97)
		{
			if (waypoint_0.InitReponse())
			{
				TankerFollowsMe = null;
				TankerFollowsMe_NumberOfWaypoints = 0;
			}
		}
		else if (TankerFollowsMe_NumberOfWaypoints == -99)
		{
			if (waypoint_0.Type == Waypoint.WaypointType.LandingMarshal || waypoint_0.Type == Waypoint.WaypointType.Land)
			{
				TankerFollowsMe = null;
				TankerFollowsMe_NumberOfWaypoints = 0;
			}
		}
		else if (PlottedCourse.Count() <= 0)
		{
			TankerFollowsMe_NumberOfWaypoints = 0;
		}
		else
		{
			TankerFollowsMe_NumberOfWaypoints--;
		}
		if (!myUnit.IsGroupLead())
		{
			return;
		}
		foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
		{
			if (value != myUnit && !value.Navigator.HasPlottedCourse())
			{
				value.Navigator.TankerFollowsMe = TankerFollowsMe;
				value.Navigator.TankerFollowsMe_NumberOfWaypoints = TankerFollowsMe_NumberOfWaypoints;
			}
		}
	}

	public virtual bool EgressToRejoinPoint_CallOff(float float_0)
	{
		try
		{
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101372", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void FollowSupportMissionCourse(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage() == null || myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Support)
			{
				return;
			}
			SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
			if (supportMission == null || supportMission.NavigationCourse == null || supportMission.NavigationCourse.Count == 0)
			{
				return;
			}
			if (SupportMission_NextRefPoint == null)
			{
				SupportMission_NextRefPoint = supportMission.NavigationCourse[0];
			}
			else if (!supportMission.NavigationCourse.Contains(SupportMission_NextRefPoint))
			{
				SupportMission_NextRefPoint = supportMission.NavigationCourse[0];
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, float_0))
			{
				if (supportMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) == supportMission.NavigationCourse.Count - 1)
				{
					if (supportMission.NavigationLoopType == SupportMission.SupportMissionNavigationLoopType.ContinousLoop)
					{
						SupportMission_NextRefPoint = supportMission.NavigationCourse[0];
						if (supportMission.MarkAsSatisfiedUponReachingDestination)
						{
							supportMission.SetPhase(myUnit.ParentScen, myUnit.GetUnitSide(), MissionPhase.Completed);
						}
					}
					else if (supportMission.NavigationLoopType == SupportMission.SupportMissionNavigationLoopType.SingleLoop)
					{
						if (supportMission.MarkAsSatisfiedUponReachingDestination)
						{
							supportMission.SetPhase(myUnit.ParentScen, myUnit.GetUnitSide(), MissionPhase.Completed);
						}
						SupportMission_NextRefPoint = null;
						if (supportMission.RTBUponCompletion)
						{
							if (myUnit.IsAircraft)
							{
								myUnit.AirOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true);
							}
							else
							{
								myUnit.DockingOps.AttemptToRTB(bool_0: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, bool_1: true, ActiveUnit._ActiveUnitStatus.RTB_Group, bool_2: false, bool_3: true);
							}
						}
						else
						{
							ActiveUnit activeUnit = myUnit;
							Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
							activeUnit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
						}
					}
				}
				else
				{
					SupportMission_NextRefPoint = supportMission.NavigationCourse[supportMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) + 1];
				}
			}
			if (HasPlottedCourse())
			{
				FollowPlottedCourse(float_0);
			}
			else if (SupportMission_NextRefPoint != null)
			{
				HeadToPoint(SupportMission_NextRefPoint);
				Waypoint waypoint_ = null;
				ExtendIfNecessary(float_0, ref waypoint_, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (!myUnit.IsAircraft && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (bool_1)
				{
					if (myUnit.IsSubmarine)
					{
						myUnit.SetThrottle(supportMission.TransitThrottle_Submarine);
					}
					else if (myUnit.IsShip)
					{
						myUnit.SetThrottle(supportMission.TransitThrottle_Ship);
					}
					else if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					else
					{
						myUnit.SetThrottle(supportMission.TransitThrottle_Facility);
					}
				}
				else if (myUnit.IsSubmarine)
				{
					if (Information.IsNothing(supportMission.StationThrottle_Submarine))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(supportMission.StationThrottle_Submarine);
					}
				}
				else if (myUnit.IsShip)
				{
					if (Information.IsNothing(supportMission.StationThrottle_Ship))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(supportMission.StationThrottle_Ship);
					}
				}
				else if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else if (Information.IsNothing(supportMission.StationThrottle_Facility))
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else
				{
					myUnit.SetThrottle(supportMission.StationThrottle_Facility);
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.GetRechargePercentagePatrol(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.PostSpecification(value, bool_0: false, bool_1: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (bool_1)
			{
				if (supportMission.TransitDepth_Submarine.HasValue)
				{
					float value2 = supportMission.TransitDepth_Submarine.Value;
					if (!(Math.Round(value2) < -20.0) && !aI.ListSpecification(bool_0: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (supportMission.StationDepth_Submarine.HasValue)
			{
				float value3 = supportMission.StationDepth_Submarine.Value;
				if (!(Math.Round(value3) < -20.0) && !aI.ListSpecification(bool_0: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100204", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void FollowPatrolRepeatableLoopCourse(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage() == null || myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
			{
				return;
			}
			Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
			if (patrol.PatrolArea == null || patrol.PatrolArea.Count == 0)
			{
				return;
			}
			if (SupportMission_NextRefPoint == null)
			{
				SupportMission_NextRefPoint = patrol.PatrolArea[0];
			}
			else if (!patrol.PatrolArea.Contains(SupportMission_NextRefPoint))
			{
				SupportMission_NextRefPoint = patrol.PatrolArea[0];
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, float_0))
			{
				if (patrol.PatrolArea.IndexOf(SupportMission_NextRefPoint) == patrol.PatrolArea.Count - 1)
				{
					SupportMission_NextRefPoint = patrol.PatrolArea[0];
				}
				else
				{
					SupportMission_NextRefPoint = patrol.PatrolArea[patrol.PatrolArea.IndexOf(SupportMission_NextRefPoint) + 1];
				}
			}
			if (HasPlottedCourse())
			{
				FollowPlottedCourse(float_0);
			}
			else if (SupportMission_NextRefPoint != null)
			{
				HeadToPoint(SupportMission_NextRefPoint);
				Waypoint waypoint_ = null;
				ExtendIfNecessary(float_0, ref waypoint_, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (myUnit.IsGroup)
			{
				if (!(!myUnit.Kinematics.DesiredSpeedOverride.HasValue && bool_1))
				{
					return;
				}
				ActiveUnit groupLead = ((Group)myUnit).GroupLead;
				if (groupLead != null)
				{
					if (groupLead.IsAircraft)
					{
						Aircraft obj = (Aircraft)groupLead;
						Aircraft_AirOps airOps = obj.AirOps;
						Aircraft_Navigator navigator = obj.Navigator;
						navigator.SetPatrolThrottle(bool_1: false, airOps.Condition);
						navigator.SetPatrolAltitude(bool_1: false, airOps.Condition);
					}
					else if (groupLead.IsSubmarine)
					{
						groupLead.SetThrottle(patrol.TransitThrottle_Submarine);
					}
					else if (groupLead.IsShip)
					{
						groupLead.SetThrottle(patrol.TransitThrottle_Ship);
					}
					else
					{
						groupLead.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				return;
			}
			if (!myUnit.IsAircraft && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (bool_1)
				{
					if (myUnit.IsSubmarine)
					{
						myUnit.SetThrottle(patrol.TransitThrottle_Submarine);
					}
					else if (myUnit.IsShip)
					{
						myUnit.SetThrottle(patrol.TransitThrottle_Ship);
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else if (myUnit.IsSubmarine)
				{
					myUnit.SetThrottle(patrol.StationThrottle_Submarine);
				}
				else if (myUnit.IsShip)
				{
					myUnit.SetThrottle(patrol.StationThrottle_Ship);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.GetRechargePercentagePatrol(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.PostSpecification(value, bool_0: false, bool_1: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (bool_1)
			{
				if (patrol.TransitDepth_Submarine.HasValue)
				{
					float value2 = patrol.TransitDepth_Submarine.Value;
					if (!(Math.Round(value2) < -20.0) && !aI.ListSpecification(bool_0: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (patrol.StationDepth_Submarine.HasValue)
			{
				float value3 = patrol.StationDepth_Submarine.Value;
				if (!(Math.Round(value3) < -20.0) && !aI.ListSpecification(bool_0: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10324509326043132845904329", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void FollowMineClearingMissionCourse(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage() == null || myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
			{
				return;
			}
			MineClearingMission mineClearingMission = (MineClearingMission)myUnit.AssignedMissionOrPackage();
			if (mineClearingMission == null || mineClearingMission.Area == null || mineClearingMission.Area.Count == 0)
			{
				return;
			}
			if (SupportMission_NextRefPoint == null)
			{
				ReferencePoint referencePoint = null;
				double num = 0.0;
				foreach (ReferencePoint item in mineClearingMission.Area)
				{
					double num2 = Math2.CancelClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item.Latitude, item.Longitude);
					if (referencePoint == null)
					{
						referencePoint = item;
						num = num2;
					}
					else if (num2 < num)
					{
						referencePoint = item;
						num = num2;
					}
				}
				if (referencePoint == null)
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[0];
				}
				else
				{
					SupportMission_NextRefPoint = referencePoint;
				}
				bool_1 = true;
			}
			else if (!mineClearingMission.Area.Contains(SupportMission_NextRefPoint))
			{
				SupportMission_NextRefPoint = mineClearingMission.Area[0];
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, float_0))
			{
				if (mineClearingMission.Area.IndexOf(SupportMission_NextRefPoint) == mineClearingMission.Area.Count - 1)
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[0];
				}
				else
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[mineClearingMission.Area.IndexOf(SupportMission_NextRefPoint) + 1];
				}
			}
			if (HasPlottedCourse())
			{
				FollowPlottedCourse(float_0);
			}
			else if (SupportMission_NextRefPoint != null)
			{
				HeadToPoint(SupportMission_NextRefPoint);
				Waypoint waypoint_ = null;
				ExtendIfNecessary(float_0, ref waypoint_, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (!myUnit.IsAircraft && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (bool_1)
				{
					if (myUnit.IsSubmarine)
					{
						myUnit.SetThrottle(mineClearingMission.TransitThrottle_Submarine);
					}
					else if (myUnit.IsShip)
					{
						myUnit.SetThrottle(mineClearingMission.TransitThrottle_Ship);
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else if (myUnit.IsSubmarine)
				{
					if (Information.IsNothing(mineClearingMission.StationThrottle_Submarine))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(mineClearingMission.StationThrottle_Submarine);
					}
				}
				else if (myUnit.IsShip)
				{
					if (Information.IsNothing(mineClearingMission.StationThrottle_Ship))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(mineClearingMission.StationThrottle_Ship);
					}
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.GetRechargePercentagePatrol(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.PostSpecification(value, bool_0: false, bool_1: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (bool_1)
			{
				if (mineClearingMission.TransitDepth_Submarine.HasValue)
				{
					float value2 = mineClearingMission.TransitDepth_Submarine.Value;
					if (!(Math.Round(value2) < -20.0) && !aI.ListSpecification(bool_0: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (mineClearingMission.StationDepth_Submarine.HasValue)
			{
				float value3 = mineClearingMission.StationDepth_Submarine.Value;
				if (!(Math.Round(value3) < -20.0) && !aI.ListSpecification(bool_0: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100204", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TriggerPathfinderThread(Waypoint waypoint_0, ActiveUnit activeUnit_0, Mission.Flight flight_0, bool bool_1, float float_0, double double_0, double double_1, Scenario scenario_0, bool bool_2)
	{
		_ = Debugger.IsAttached;
		try
		{
			if ((activeUnit_0 != null && activeUnit_0.ThrottleSetting == ActiveUnit.Throttle.FullStop && activeUnit_0.CurrentSpeed == 0f) || activeUnit_0 == null || (!bool_0 && flight_0 == null) || PathFindingInProgress)
			{
				return;
			}
			Exception exception_ = null;
			if (!Pathfinding.FindStub(activeUnit_0, flight_0, ref exception_) && Information.IsNothing(exception_))
			{
				PathFindingInProgress = true;
				PathfindRequest pathfindRequest = new PathfindRequest();
				pathfindRequest.theUnit = activeUnit_0;
				pathfindRequest.theScenario = scenario_0;
				pathfindRequest.theFlightPlan = flight_0;
				pathfindRequest.theFlightPlanIngressPath = bool_1;
				pathfindRequest.StartWP = waypoint_0;
				pathfindRequest.ProximityThreshold_Deg = float_0;
				pathfindRequest.DestLat = double_0;
				pathfindRequest.DestLon = double_1;
				pathfindRequest.Age = 0;
				if (myUnit.IsAircraft)
				{
					pathfindRequest.Distance = 0;
				}
				else
				{
					pathfindRequest.Distance = (int)Math.Round(Module_Unit.RangeToPoint_Horiz(myUnit, double_0, double_1));
				}
				pathfindRequest.ManouverTowardsTarget = bool_2;
				Pathfinding.SubmitPathfindRequest(pathfindRequest, scenario_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_2 = ex;
			exception_2?.Data.Add("Error at 100205", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void StartPathfinding(Waypoint waypoint_0, ActiveUnit activeUnit_0, Mission.Flight flight_0, bool bool_1, float float_0, double double_0, double double_1, Scenario scenario_0, bool bool_2)
	{
		PathFindingInProgress = true;
		try
		{
			if (PathFindingAbortNextPath)
			{
				PathFindingAbortNextPath = false;
				PathFindingInProgress = false;
				return;
			}
			PerformPathfinding(waypoint_0, activeUnit_0, flight_0, bool_1, float_0, double_0, double_1, bool_2);
			if (PathFindingAbortNextPath)
			{
				PathFindingAbortNextPath = false;
				PF_GeneratedCourse = null;
				PathFindingInProgress = false;
				return;
			}
			if (PF_GeneratedCourse != null && !UseCostBasedPathfinder)
			{
				bool bool_3 = false;
				bool bool_4 = !Information.IsNothing(flight_0);
				while (!bool_3)
				{
					if (!scenario_0.ThreadedOpsMustStop)
					{
						VisitDic(PF_GeneratedCourse, bool_4, float_0, ref bool_3, ref flight_0, ref bool_1);
						continue;
					}
					PathFindingInProgress = false;
					return;
				}
			}
			if (!Information.IsNothing(PF_GeneratedCourse))
			{
				int count = PF_GeneratedCourse.Count;
				if (Information.IsNothing(waypoint_0))
				{
					if (Information.IsNothing(flight_0))
					{
						int num = count - 1;
						for (int i = 0; i <= num; i++)
						{
							AddWaypoint(i, PF_GeneratedCourse[i]);
						}
					}
					else if (bool_1)
					{
						int num2 = count - 1;
						for (int j = 0; j <= num2; j++)
						{
							Mission.Flight flight = flight_0;
							Waypoint[] waypoint_ = flight.FlightPlan_Pathfinder_Ingress_1;
							AddWaypoint(ref waypoint_, j, PF_GeneratedCourse[j]);
							flight.FlightPlan_Pathfinder_Ingress_1 = waypoint_;
						}
						flight_0.Pathfinder_Ingress_RequestBeingProcessed = false;
					}
					else
					{
						int num3 = count - 1;
						for (int k = 0; k <= num3; k++)
						{
							Mission.Flight flight2 = flight_0;
							Waypoint[] waypoint_2 = flight2.FlightPlan_Pathfinder_Egress_1;
							AddWaypoint(ref waypoint_2, k, PF_GeneratedCourse[k]);
							flight2.FlightPlan_Pathfinder_Egress_1 = waypoint_2;
						}
						flight_0.Pathfinder_Egress_RequestBeingProcessed = false;
					}
				}
				else if (Information.IsNothing(flight_0))
				{
					int num4 = Array.IndexOf(PlottedCourse, waypoint_0);
					int num5 = count - 1;
					for (int l = 0; l <= num5; l++)
					{
						AddWaypoint(num4 + 1 + l, PF_GeneratedCourse[l]);
					}
				}
				else if (!bool_1)
				{
					int num6 = count - 1;
					for (int m = 0; m <= num6; m++)
					{
						Mission.Flight flight3 = flight_0;
						Waypoint[] waypoint_3 = flight3.FlightPlan_Pathfinder_Egress_1;
						AddWaypoint(ref waypoint_3, m, PF_GeneratedCourse[m]);
						flight3.FlightPlan_Pathfinder_Egress_1 = waypoint_3;
					}
					flight_0.Pathfinder_Egress_RequestBeingProcessed = false;
				}
			}
			if (Information.IsNothing(PF_GeneratedCourse) && Information.IsNothing(flight_0) && bool_2)
			{
				string text = "";
				if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + myUnit.UnitClass + ")";
				}
				string text2 = "";
				if (!Information.IsNothing(myUnit.AI.PrimaryTarget))
				{
					text2 = " (" + myUnit.AI.PrimaryTarget.Name + ")";
				}
				myUnit.AddMessage(myUnit.Name + text + "从目标列表中删除所有目标（原因：导航器无法规划路径到主目标" + text2 + "，这意味着它无法到达。该单元现在将根据当前的目标可用性和可到达性重新构建其目标列表。", myUnit.Name + " 丢弃所有目标", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				myUnit.AI.ClearAllTargets(ref myUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200330", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathFindingInProgress = false;
		if (TimeToNextPathfinderCheck < 300f)
		{
			TimeToNextPathfinderCheck = 300f;
		}
	}

	public virtual void FollowPlottedCourse(float float_0)
	{
		if (myUnit.AI.HoldPosition)
		{
			return;
		}
		try
		{
			if ((PlottedCourse.Count() == 0) & HasFlightPlan)
			{
				PlottedCourse = GetFlight().FlightPlan;
			}
			if (PlottedCourse.Count() == 0)
			{
				return;
			}
			int int_ = 0;
			GeoPoint geoPoint_ = new GeoPoint();
			if (bool_0 && !PathFindingInProgress)
			{
				if (HasPathfindingPlottedCourse)
				{
					if (PlottedCourse.Count() > 1 && PlottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint)
					{
						double latitude = myUnit.GetLatitude();
						double longitude = myUnit.GetLongitude();
						double latitude2 = PlottedCourse[0].Latitude;
						double longitude2 = PlottedCourse[0].Longitude;
						float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
						GeoPoint geoPoint_2 = null;
						if (PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, nullable_, ref int_, ref geoPoint_2))
						{
							TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, myUnit.ParentScen, bool_2: false);
						}
						double latitude3 = myUnit.GetLatitude();
						double longitude3 = myUnit.GetLongitude();
						double latitude4 = PlottedCourse[1].Latitude;
						double longitude4 = PlottedCourse[1].Longitude;
						float? nullable_2 = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
						geoPoint_2 = null;
						if (!PathLineIsInterrupted(latitude3, longitude3, latitude4, longitude4, bool_1: true, 0f, bool_2: false, null, bool_3: true, bool_4: false, bool_5: true, nullable_2, ref int_, ref geoPoint_2))
						{
							if (myUnit.IsAircraft)
							{
								ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
								ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
								RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
							}
							else if (Math2.CancelClass(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude) < 0.05)
							{
								ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
								ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
								RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
							}
						}
					}
				}
				else if (PathLineIsInterrupted(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, Pathfinding.visitorConsumer.DegreeInterval_Finegrained, ref int_, ref geoPoint_))
				{
					if (myUnit.IsMCMPlatform && myUnit.IsOnActiveMineClearingMission && (int_ & 1) == 1)
					{
						GeoPoint geoPoint = new GeoPoint();
						Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude);
						float num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude);
						if (num <= 1f)
						{
							ActiveUnit activeUnit = myUnit;
							bool? nullable_3 = null;
							double double_ = activeUnit.GetLongitude(nullable_3);
							ActiveUnit activeUnit2 = myUnit;
							bool? nullable_4 = null;
							double double_2 = activeUnit2.GetLatitude(nullable_4);
							double double_3 = geoPoint.Longitude;
							double double_4 = geoPoint.Latitude;
							double double_5 = 0.5;
							float float_ = Math2.UpdateClass(180f + Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_3, ref double_4, ref double_5, ref float_);
							geoPoint.Latitude = double_4;
							geoPoint.Longitude = double_3;
							activeUnit2.SetLatitude(nullable_4, double_2);
							activeUnit.SetLongitude(nullable_3, double_);
							RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
							AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
							myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint.Latitude, geoPoint.Longitude));
						}
						else
						{
							double longitude5 = myUnit.GetLongitude();
							double latitude5 = myUnit.GetLatitude();
							GeoPoint geoPoint2;
							double double_6 = (geoPoint2 = geoPoint).Longitude;
							GeoPoint geoPoint3;
							double double_7 = (geoPoint3 = geoPoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref double_6, ref double_7, Math.Max(1f, 2f * num / 3f), Math2.UpdateClass(Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude)));
							geoPoint3.Latitude = double_7;
							geoPoint2.Longitude = double_6;
							RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
							AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
					}
					else
					{
						TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, myUnit.ParentScen, bool_2: false);
					}
				}
			}
			HeadToFirstWaypoint(float_0);
			bool bool_ = false;
			bool bool_2 = false;
			CheckIfReachedWaypoint(float_0, ref bool_, ref bool_2);
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				return;
			}
			if (myUnit.IsAircraft && (int)myUnit.ThrottleSetting <= 2)
			{
				if (myUnit.AssignedMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsAircraft && myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead))
			{
				myUnit.SetThrottle(myUnit.GetParentGroup().GroupLead.ThrottleSetting);
			}
			else if (myUnit.IsSubmarine && (int)myUnit.ThrottleSetting <= 2 && ((Submarine)myUnit).DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
			{
				if (myUnit.AssignedMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsShip && (int)myUnit.ThrottleSetting <= 2)
			{
				if (myUnit.AssignedMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsGroupWingman() && !Information.IsNothing(myUnit.GetParentGroup().GroupLead))
			{
				myUnit.SetThrottle(myUnit.GetParentGroup().GroupLead.ThrottleSetting);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200321", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearPathfindingWaypoints()
	{
		try
		{
			List<Waypoint> list = new List<Waypoint>();
			Waypoint[] plottedCourse = PlottedCourse;
			Waypoint[] array = plottedCourse;
			foreach (Waypoint waypoint in array)
			{
				if (waypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list.Add(waypoint);
				}
			}
			foreach (Waypoint item in list)
			{
				RemoveWaypoint_Soft(item, bool_1: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100208", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HeadToPoint(GeoPoint geoPoint_0)
	{
		try
		{
			if (HasPathfindingPlottedCourse || PathFindingInProgress || PathFindingInProgress)
			{
				return;
			}
			int int_ = 0;
			GeoPoint geoPoint_ = new GeoPoint();
			if (myUnit.Navigator.bool_0 && PathLineIsInterrupted(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: true, Pathfinding.visitorConsumer.DegreeInterval_Finegrained, ref int_, ref geoPoint_))
			{
				if (myUnit.IsMCMPlatform && myUnit.IsOnActiveMineClearingMission && (int_ & 1) == 1)
				{
					GeoPoint geoPoint = new GeoPoint();
					Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude);
					float num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude);
					if (num <= 1f)
					{
						ActiveUnit activeUnit = myUnit;
						bool? nullable_ = null;
						double double_ = activeUnit.GetLongitude(nullable_);
						ActiveUnit activeUnit2 = myUnit;
						bool? nullable_2 = null;
						double double_2 = activeUnit2.GetLatitude(nullable_2);
						double double_3 = geoPoint.Longitude;
						double double_4 = geoPoint.Latitude;
						double double_5 = 0.5;
						float float_ = Math2.UpdateClass(180f + Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_, ref double_2, ref double_3, ref double_4, ref double_5, ref float_);
						geoPoint.Latitude = double_4;
						geoPoint.Longitude = double_3;
						activeUnit2.SetLatitude(nullable_2, double_2);
						activeUnit.SetLongitude(nullable_, double_);
						RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
						AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint.Latitude, geoPoint.Longitude));
					}
					else
					{
						double longitude = myUnit.GetLongitude();
						double latitude = myUnit.GetLatitude();
						GeoPoint geoPoint2;
						double double_6 = (geoPoint2 = geoPoint).Longitude;
						GeoPoint geoPoint3;
						double double_7 = (geoPoint3 = geoPoint).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_6, ref double_7, Math.Max(1f, 2f * num / 3f), Math2.UpdateClass(Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_.Latitude, geoPoint_.Longitude)));
						geoPoint3.Latitude = double_7;
						geoPoint2.Longitude = double_6;
						RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
						AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
				}
				else
				{
					myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude));
					TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, geoPoint_0.Latitude, geoPoint_0.Longitude, myUnit.ParentScen, bool_2: false);
				}
			}
			else if (HasPathfindingPlottedCourse)
			{
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
			}
			else
			{
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geoPoint_0.Latitude, geoPoint_0.Longitude));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100209", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual void HeadToFirstWaypoint(float float_0)
	{
		try
		{
			if (!myUnit.Navigator.SprintDrift)
			{
				Waypoint[] plottedCourse = PlottedCourse;
				if (plottedCourse.Length == 0)
				{
					ManualPlotOverride = false;
					return;
				}
				Waypoint waypoint_ = plottedCourse[0];
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, waypoint_.Latitude, waypoint_.Longitude));
				ExtendIfNecessary(float_0, ref waypoint_, waypoint_.Latitude, waypoint_.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100210", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HaveReachedPoint(GeoPoint geoPoint_0, float float_0, bool bool_1 = true, bool bool_2 = false, float? nullable_0 = null)
	{
		return HaveReachedPoint(geoPoint_0.Latitude, geoPoint_0.Longitude, float_0, bool_1, bool_2, nullable_0);
	}

	public virtual bool HaveReachedPoint(double double_0, double double_1, float float_0, bool bool_1 = true, bool bool_2 = false, float? nullable_0 = null)
	{
		try
		{
			if (bool_2)
			{
				float num = Math2.VerifyClass(double_0, double_1, myUnit.GetLatitude(), myUnit.GetLongitude());
				if (myUnit.IsAircraft)
				{
					if (((Aircraft)myUnit).IsHelicopter)
					{
						if ((double)num < Math.Min(HELI_WP_Distance_threashold / float_0, 0.01))
						{
							return true;
						}
					}
					else if ((double)num < Math.Min(AC_WP_Distance_threashold / float_0, 0.1))
					{
						return true;
					}
				}
			}
			if (Module_Unit.RangeToPoint_Horiz_Angular(myUnit, ref double_0, ref double_1) <= Misc.AngularDistance_5nm)
			{
				double num2 = Math2.VerifyClass(double_0, double_1, myUnit.GetLatitude(), myUnit.GetLongitude());
				if (num2 <= 10.0)
				{
					if (myUnit.CurrentSpeed == 0f && myUnit.DesiredSpeed == 0f && num2 < 0.01)
					{
						return true;
					}
					double num3 = 0.0;
					if (bool_1)
					{
						num3 = Math.Max(myUnit.CurrentSpeed / 3600f * 2f * float_0, 0.01f);
					}
					else
					{
						double num4 = myUnit.CurrentSpeed;
						while (num4 > 0.1)
						{
							double decelerationCapacity = myUnit.Kinematics.GetDecelerationCapacity(myUnit.GetCurrentAltitude(), (float)num4, 1f);
							num3 += num4 / 3600.0;
							num4 -= decelerationCapacity;
						}
					}
					bool result = num2 < num3;
					WP_reach_cache_memory = new WP_reach_cache(double_0, double_1, myUnit.ParentScen.Time, result, num2, myUnit.Location);
					return result;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100212", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool HaveReachedPoint_Threshold(double double_0, double double_1, float float_0)
	{
		try
		{
			return Module_Unit.RangeToPoint_Horiz(myUnit, double_0, double_1) <= float_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100212234120349123054324509326", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual void CheckIfReachedWaypoint(float float_0, ref bool bool_1, ref bool bool_2)
	{
		try
		{
			if (PlottedCourse.Count() == 0)
			{
				return;
			}
			Scenario parentScen = myUnit.ParentScen;
			if (DateTime.Compare(WP_reach_cache_memory.theTime, parentScen.Time) == 0)
			{
				if (parentScen.GameContext.GameMode != Game._GameMode.ScenEdit || myUnit.Location == WP_reach_cache_memory.UnitLocation)
				{
					return;
				}
			}
			else if (((PlottedCourse[0].Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & (PlottedCourse[0].Longitude == WP_reach_cache_memory.theWaypoint.Longitude)) && myUnit.Location == WP_reach_cache_memory.UnitLocation)
			{
				return;
			}
			Waypoint waypoint = PlottedCourse[0];
			if (HaveReachedPoint(waypoint, float_0, waypoint.OvershootWaypoint))
			{
				ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
				ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
				PreviousWaypointTime = myUnit.ParentScen.Time;
				PreviousWaypointLatitude = waypoint.Latitude;
				PreviousWaypointLongitude = waypoint.Longitude;
				PreviousWaypointType = waypoint.Type;
				RemoveWaypoint_Soft(PlottedCourse[0], bool_1: false);
				if (PlottedCourse.Count() > 0 && ((waypoint.Type != Waypoint.WaypointType.PickupPoint && waypoint.Type != Waypoint.WaypointType.DropOffPoint) || !myUnit.DockingOps.SettleForCargoTransfer()))
				{
					HeadToFirstWaypoint(float_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100213", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyWaypointSpeedAltToUnit(Waypoint waypoint_0)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			bool flag = myUnit.IsAircraft || (myUnit.IsWeapon && myUnit.SupportsAltitude_Control && myUnit.Kinematics.GetMaximumAltitude() > 0f);
			bool flag2 = myUnit.IsSubmarine || (myUnit.IsWeapon && myUnit.SupportsAltitude_Control && myUnit.Kinematics.GetMinimumAltitude() < 0f);
			myUnit.AI.TimeToNextSpeedAdjustmentForToTEvaluation = null;
			myUnit.AI.IsPerformingSpeedAdjustmentToT = false;
			if (myUnit.IsAircraft && myUnit.IsGroupWingman() && myUnit.Navigator.PlottedCourse.Count() == 1)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.DesiredAltitudeOverride = false;
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
			else
			{
				if (waypoint_0.DesiredSpeedOverride.HasValue && waypoint_0.DesiredSpeed.HasValue)
				{
					myUnit.DesiredSpeed = waypoint_0.DesiredSpeed.Value;
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
					myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
				else if (waypoint_0.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					myUnit.Kinematics.ThrottlePreset = waypoint_0.ThrottlePreset;
					myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), (ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, bool_0: false);
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
				}
				if (waypoint_0.DesiredAltitudeOverride)
				{
					if (myUnit.IsSubmarine)
					{
						((Submarine)myUnit).AI.DepthPreset = waypoint_0.DepthPreset;
					}
					if (myUnit.IsAircraft)
					{
						((Aircraft)myUnit).AI.AltitudePreset = waypoint_0.AltitudePreset;
					}
					if (waypoint_0.AltitudePreset != 0 && myUnit.IsAircraft)
					{
						((Aircraft)myUnit).AI.FollowAltitudePreset();
					}
					else if (waypoint_0.DepthPreset != 0 && myUnit.IsSubmarine)
					{
						((Submarine)myUnit).AI.FollowDepthPreset(bool_0: true);
					}
					else if ((flag || flag2) && waypoint_0.DesiredAltitude.HasValue)
					{
						myUnit.DesiredAltitude = waypoint_0.DesiredAltitude.Value;
						float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
						float minimumAltitude = myUnit.Kinematics.GetMinimumAltitude();
						if (myUnit.DesiredAltitude <= maximumAltitude)
						{
							if (myUnit.DesiredAltitude < minimumAltitude)
							{
								myUnit.DesiredAltitude = minimumAltitude;
							}
						}
						else
						{
							myUnit.DesiredAltitude = maximumAltitude;
						}
					}
					if ((flag || flag2) && waypoint_0.DesiredAltitude_TerrainFollowing.HasValue && waypoint_0.TerrainFollowing)
					{
						myUnit.DesiredAltitude_AGL = waypoint_0.DesiredAltitude_TerrainFollowing.Value;
						myUnit.AI.PerformTerrainFollowingIfNecessary();
					}
					if (myUnit.IsAircraft)
					{
						if (waypoint_0.DesiredAltitude_TerrainFollowing.HasValue)
						{
							myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, waypoint_0.TerrainFollowing);
							myUnit.TerrainFollowingType = waypoint_0.TerrainFollowingType;
							myUnit.AI.PerformTerrainFollowingIfNecessary();
						}
						else
						{
							myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_0: false);
						}
					}
				}
				else
				{
					myUnit.Kinematics.DesiredAltitudeOverride = false;
				}
			}
			myUnit.DesiredTurnRate = ActiveUnit.TurnRate.Navigation;
			if (!Information.IsNothing(myUnit.Navigator.GetFlight()) && myUnit.Navigator.PlottedCourse.Count() > 1)
			{
				myUnit.DesiredTurnRate_Navigation = waypoint_0.TurnRate_Navigation;
			}
			else
			{
				myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			}
			if (!Information.IsNothing(waypoint_0.SprintDrift))
			{
				myUnit.Navigator.SprintDrift = waypoint_0.SprintDrift.Value;
				bool? sprintDrift = waypoint_0.SprintDrift;
				if (((!sprintDrift) ?? sprintDrift).GetValueOrDefault())
				{
					myUnit.Navigator.SprintDrift_AverageSpeed = null;
				}
				else
				{
					sprintDrift = waypoint_0.SprintDrift;
					if (sprintDrift.GetValueOrDefault(true) && !Information.IsNothing(waypoint_0.SprintDrift_AverageSpeed) && sprintDrift.HasValue)
					{
						myUnit.Navigator.SprintDrift_AverageSpeed = waypoint_0.SprintDrift_AverageSpeed;
					}
				}
			}
			if (!Information.IsNothing(waypoint_0.AvoidCavitation))
			{
				myUnit.Navigator.AvoidCavitation = waypoint_0.AvoidCavitation.Value;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100216", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyWaypointDoctrineToUnit(Waypoint waypoint_0)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			if (myUnit.IsGroupLead())
			{
				foreach (ActiveUnit item in new List<ActiveUnit>(myUnit.GetParentGroup().Units.Values))
				{
					if (item == myUnit)
					{
						CreateDic(item, waypoint_0);
					}
					else if (!item.Navigator.HasPlottedCourse())
					{
						CreateDic(item, waypoint_0);
					}
				}
				return;
			}
			ActiveUnit activeUnit_ = myUnit;
			CreateDic(activeUnit_, waypoint_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 101305", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CreateDic(ActiveUnit activeUnit_0, Waypoint waypoint_0)
	{
		if (!waypoint_0.HasDoctrine)
		{
			return;
		}
		try
		{
			Doctrine doctrine = waypoint_0.Doctrine;
			if (doctrine.NukesAllowed_Inherits())
			{
				activeUnit_0.Doctrine.SetNukesAllowed(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b = (byte?)doctrine.GetNukesAllowed(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetNukesAllowed(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetNukesAllowed(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WeaponControlStatus_Air_Inherits())
			{
				activeUnit_0.Doctrine.SetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b12 = (byte?)doctrine.GetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
				bool? flag12 = (b12.HasValue ? new bool?(b12.GetValueOrDefault() == 4) : null);
				if (((!flag12) ?? flag12).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, doctrine.GetWeaponControlStatus_Air(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WeaponControlStatus_Land_Inherits())
			{
				activeUnit_0.Doctrine.SetWeaponControlStatus_Land(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b22 = (byte?)doctrine.GetWeaponControlStatus_Land(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
				bool? flag23 = (b22.HasValue ? new bool?(b22.GetValueOrDefault() == 4) : null);
				if (((!flag23) ?? flag23).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWeaponControlStatus_Land(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, doctrine.GetWeaponControlStatus_Land(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WeaponControlStatus_Surface_Inherits())
			{
				activeUnit_0.Doctrine.SetWeaponControlStatus_Surface(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b23 = (byte?)doctrine.GetWeaponControlStatus_Surface(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
				bool? flag34 = (b23.HasValue ? new bool?(b23.GetValueOrDefault() == 4) : null);
				if (((!flag34) ?? flag34).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWeaponControlStatus_Surface(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, doctrine.GetWeaponControlStatus_Surface(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WeaponControlStatus_Submarine_Inherits())
			{
				activeUnit_0.Doctrine.SetWeaponControlStatus_Submarine(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b24 = (byte?)doctrine.GetWeaponControlStatus_Submarine(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
				bool? flag35 = (b24.HasValue ? new bool?(b24.GetValueOrDefault() == 4) : null);
				if (((!flag35) ?? flag35).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWeaponControlStatus_Submarine(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, doctrine.GetWeaponControlStatus_Submarine(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.GunStrafing_Inherits())
			{
				activeUnit_0.Doctrine.SetGunStrafing(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b25 = (byte?)doctrine.GetGunStrafing(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag36 = (b25.HasValue ? new bool?(b25.GetValueOrDefault() == 3) : null);
				if (((!flag36) ?? flag36).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetGunStrafing(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetGunStrafing(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.IgnorePlottedCourse_Inherits())
			{
				activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b26 = (byte?)doctrine.GetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false);
				bool? flag37 = (b26.HasValue ? new bool?(b26.GetValueOrDefault() == 3) : null);
				if (((!flag37) ?? flag37).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, doctrine.GetIgnorePlottedCourse(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.BehaviorTowardsAmbigousTarget_Inherits())
			{
				activeUnit_0.Doctrine.SetBehaviorTowardsAmbigousTarget(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b27 = (byte?)doctrine.GetBehaviorTowardsAmbigousTarget(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag38 = (b27.HasValue ? new bool?(b27.GetValueOrDefault() == 4) : null);
				if (((!flag38) ?? flag38).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetBehaviorTowardsAmbigousTarget(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetBehaviorTowardsAmbigousTarget(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.AutoEvade_Inherits())
			{
				activeUnit_0.Doctrine.SetAutoEvade(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b28 = (byte?)doctrine.GetAutoEvade(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag39 = (b28.HasValue ? new bool?(b28.GetValueOrDefault() == 3) : null);
				if (((!flag39) ?? flag39).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetAutoEvade(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetAutoEvade(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.MaintainStandoff_Inherits())
			{
				activeUnit_0.Doctrine.SetMaintainStandoff(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b2 = (byte?)doctrine.GetMaintainStandoff(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag2 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
				if (((!flag2) ?? flag2).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetMaintainStandoff(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetMaintainStandoff(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.UseReplenishment_Inherits())
			{
				activeUnit_0.Doctrine.SetUseReplenishment(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				byte? b3 = (byte?)doctrine.GetUseReplenishment(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag3 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 4) : null);
				if (((!flag3) ?? flag3).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetUseReplenishment(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetUseReplenishment(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.ReplenishmentSelection_Inherits())
			{
				activeUnit_0.Doctrine.SetReplenishmentSelection(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				byte? b4 = (byte?)doctrine.GetReplenishmentSelection(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag4 = (b4.HasValue ? new bool?(b4.GetValueOrDefault() == 4) : null);
				if (((!flag4) ?? flag4).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetReplenishmentSelection(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetReplenishmentSelection(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.ShootTourists_Inherits())
			{
				activeUnit_0.Doctrine.SetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b5 = (byte?)doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag5 = (b5.HasValue ? new bool?(b5.GetValueOrDefault() == 3) : null);
				if (((!flag5) ?? flag5).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetShootTourists(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.UseSAMsOnASuW_Inherits())
			{
				activeUnit_0.Doctrine.SetUseSAMsOnASuW(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b6 = (byte?)doctrine.GetUseSAMsOnASuW(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag6 = (b6.HasValue ? new bool?(b6.GetValueOrDefault() == 3) : null);
				if (((!flag6) ?? flag6).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetUseSAMsOnASuW(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetUseSAMsOnASuW(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.IgnoreEMCONunderAttack_Inherits())
			{
				activeUnit_0.Doctrine.SetIgnoreEMCONunderAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b7 = (byte?)doctrine.GetIgnoreEMCONunderAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag7 = (b7.HasValue ? new bool?(b7.GetValueOrDefault() == 3) : null);
				if (((!flag7) ?? flag7).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetIgnoreEMCONunderAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetIgnoreEMCONunderAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.QuickTurnAroundForAicraft_Inherits())
			{
				activeUnit_0.Doctrine.SetQuickTurnAroundForAicraft(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				byte? b8 = (byte?)doctrine.GetQuickTurnAroundForAicraft(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag8 = (b8.HasValue ? new bool?(b8.GetValueOrDefault() == 4) : null);
				if (((!flag8) ?? flag8).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetQuickTurnAroundForAicraft(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetQuickTurnAroundForAicraft(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.AirOpsTempo_Inherits())
			{
				activeUnit_0.Doctrine.SetAirOpsTempo(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				byte? b9 = (byte?)doctrine.GetAirOpsTempo(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag9 = (b9.HasValue ? new bool?(b9.GetValueOrDefault() == 3) : null);
				if (((!flag9) ?? flag9).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetAirOpsTempo(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetAirOpsTempo(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.WinchesterShotgun_Inherits())
			{
				activeUnit_0.Doctrine.SetWinchesterShotgun(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				int? num = (int?)doctrine.GetWinchesterShotgun(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag10 = (num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null);
				if (((!flag10) ?? flag10).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWinchesterShotgun(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetWinchesterShotgun(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.WinchesterShotgunRTB_Inherits())
			{
				activeUnit_0.Doctrine.SetWinchesterShotgunRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b10 = (byte?)doctrine.GetWinchesterShotgunRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag11 = (b10.HasValue ? new bool?(b10.GetValueOrDefault() == 5) : null);
				if (((!flag11) ?? flag11).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWinchesterShotgunRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetWinchesterShotgunRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.BingoJoker_Inherits())
			{
				activeUnit_0.Doctrine.SetBingoJoker(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				byte? b11 = (byte?)doctrine.GetBingoJoker(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				bool? flag13 = (b11.HasValue ? new bool?(b11.GetValueOrDefault() == 14) : null);
				if (((!flag13) ?? flag13).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetBingoJoker(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false, doctrine.GetBingoJoker(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
				}
			}
			if (doctrine.BingoJokerRTB_Inherits())
			{
				activeUnit_0.Doctrine.SetBingoJokerRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b13 = (byte?)doctrine.GetBingoJokerRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag14 = (b13.HasValue ? new bool?(b13.GetValueOrDefault() == 5) : null);
				if (((!flag14) ?? flag14).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetBingoJokerRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetBingoJokerRTB(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.JettisonOrdnance_Inherits())
			{
				activeUnit_0.Doctrine.SetJettison(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b14 = (byte?)doctrine.GetJettison(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag15 = (b14.HasValue ? new bool?(b14.GetValueOrDefault() == 3) : null);
				if (((!flag15) ?? flag15).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetJettison(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetJettison(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.BVRLogic_Inherits())
			{
				activeUnit_0.Doctrine.method_1(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b15 = (byte?)doctrine.method_0(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag16 = (b15.HasValue ? new bool?(b15.GetValueOrDefault() == 4) : null);
				if (((!flag16) ?? flag16).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.method_1(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.method_0(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.UseKinematicRangeForTorpedoes_Inherits())
			{
				activeUnit_0.Doctrine.SetUseKinematicRangeForTorpedoes(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b16 = (byte?)doctrine.GetUseKinematicRangeForTorpedoes(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag17 = (b16.HasValue ? new bool?(b16.GetValueOrDefault() == 4) : null);
				if (((!flag17) ?? flag17).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetUseKinematicRangeForTorpedoes(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetUseKinematicRangeForTorpedoes(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RefuelAllies_Inherits())
			{
				activeUnit_0.Doctrine.SetRefuelAllies(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b17 = (byte?)doctrine.GetRefuelAllies(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag18 = (b17.HasValue ? new bool?(b17.GetValueOrDefault() == 5) : null);
				if (((!flag18) ?? flag18).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRefuelAllies(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRefuelAllies(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.AvoidContact_Inherits())
			{
				activeUnit_0.Doctrine.SetAvoidContact(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b18 = (byte?)doctrine.GetAvoidContact(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag19 = (b18.HasValue ? new bool?(b18.GetValueOrDefault() == 4) : null);
				if (((!flag19) ?? flag19).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetAvoidContact(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetAvoidContact(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.DiveWhenThreatsDetected_Inherits())
			{
				activeUnit_0.Doctrine.SetDiveWhenThreatsDetected(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b19 = (byte?)doctrine.GetDiveWhenThreatsDetected(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag20 = (b19.HasValue ? new bool?(b19.GetValueOrDefault() == 5) : null);
				if (((!flag20) ?? flag20).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetDiveWhenThreatsDetected(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetDiveWhenThreatsDetected(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RechargePercentagePatrol_Inherits())
			{
				activeUnit_0.Doctrine.SetRechargePercentagePatrol(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				int? num4 = (int?)doctrine.GetRechargePercentagePatrol(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag21 = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == -101) : null);
				if (((!flag21) ?? flag21).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRechargePercentagePatrol(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRechargePercentagePatrol(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RechargePercentageAttack_Inherits())
			{
				activeUnit_0.Doctrine.SetRechargePercentageAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				int? num5 = (int?)doctrine.GetRechargePercentageAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag22 = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == -101) : null);
				if (((!flag22) ?? flag22).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRechargePercentageAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRechargePercentageAttack(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.AIPUsage_Inherits())
			{
				activeUnit_0.Doctrine.method_3(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b20 = (byte?)doctrine.method_2(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag24 = (b20.HasValue ? new bool?(b20.GetValueOrDefault() == 4) : null);
				if (((!flag24) ?? flag24).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.method_3(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.method_2(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.DippingSonar_Inherits())
			{
				activeUnit_0.Doctrine.SetDippingSonar(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				byte? b21 = (byte?)doctrine.GetDippingSonar(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag25 = (b21.HasValue ? new bool?(b21.GetValueOrDefault() == 3) : null);
				if (((!flag25) ?? flag25).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetDippingSonar(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetDippingSonar(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WithdrawDamageThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetWithdrawDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num6 = (short?)doctrine.GetWithdrawDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag26 = (num6.HasValue ? new bool?(num6.GetValueOrDefault() == 6) : null);
				if (((!flag26) ?? flag26).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWithdrawDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetWithdrawDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WithdrawFuelThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetWithdrawFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num7 = (short?)doctrine.GetWithdrawFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag27 = (num7.HasValue ? new bool?(num7.GetValueOrDefault() == 7) : null);
				if (((!flag27) ?? flag27).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWithdrawFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetWithdrawFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WithdrawAttackThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetWithdrawAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num8 = (short?)doctrine.GetWithdrawAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag28 = (num8.HasValue ? new bool?(num8.GetValueOrDefault() == 8) : null);
				if (((!flag28) ?? flag28).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWithdrawAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetWithdrawAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WithdrawDefenceThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetWithdrawDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num9 = (short?)doctrine.GetWithdrawDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag29 = (num9.HasValue ? new bool?(num9.GetValueOrDefault() == 8) : null);
				if (((!flag29) ?? flag29).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetWithdrawDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetWithdrawDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.WeaponControlStatus_Land_Inherits())
			{
				activeUnit_0.Doctrine.SetWeaponControlStatus_Land(activeUnit_0.ParentScen, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num10 = (short?)doctrine.GetRedeployDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag30 = (num10.HasValue ? new bool?(num10.GetValueOrDefault() == 6) : null);
				if (((!flag30) ?? flag30).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRedeployDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRedeployDamageThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RedeployFuelThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetRedeployFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num11 = (short?)doctrine.GetRedeployFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag31 = (num11.HasValue ? new bool?(num11.GetValueOrDefault() == 7) : null);
				if (((!flag31) ?? flag31).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRedeployFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRedeployFuelThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RedeployAttackThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetRedeployAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num2 = (short?)doctrine.GetRedeployAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag32 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 8) : null);
				if (((!flag32) ?? flag32).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRedeployAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRedeployAttackThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.RedeployDefenceThreshold_Inherits())
			{
				activeUnit_0.Doctrine.SetRedeployDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				short? num3 = (short?)doctrine.GetRedeployDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
				bool? flag33 = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == 8) : null);
				if (((!flag33) ?? flag33).GetValueOrDefault())
				{
					activeUnit_0.Doctrine.SetRedeployDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, doctrine.GetRedeployDefenceThreshold(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false));
				}
			}
			if (doctrine.EMCON_Inherits)
			{
				return;
			}
			if (doctrine.NewRepository(activeUnit_0.ParentScen).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && doctrine.NewRepository(activeUnit_0.ParentScen).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && doctrine.NewRepository(activeUnit_0.ParentScen).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				activeUnit_0.Doctrine.EMCON_Inherits = true;
			}
			else
			{
				if (doctrine.NewRepository(activeUnit_0.ParentScen).LoginInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_Radar(doctrine.NewRepository(activeUnit_0.ParentScen).LoginInterruptibleField(), activeUnit_0.ParentScen);
				}
				if (doctrine.NewRepository(activeUnit_0.ParentScen).GetInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_Sonar(doctrine.NewRepository(activeUnit_0.ParentScen).GetInterruptibleField(), activeUnit_0.ParentScen);
				}
				if (doctrine.NewRepository(activeUnit_0.ParentScen).OECM() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_OECM(doctrine.NewRepository(activeUnit_0.ParentScen).OECM(), activeUnit_0.ParentScen);
				}
			}
			activeUnit_0.Sensory.vmethod_0(activeUnit_0.Sensors_Cached);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 101304", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HaveReachedPatrolStation()
	{
		return DistanceFromPatrolStation() < 0.5;
	}

	public virtual bool HaveReachedFormationStation()
	{
		if (myUnit.GetParentGroup() == null)
		{
			return false;
		}
		if (myUnit.GetParentGroup().GroupLead == null)
		{
			return false;
		}
		Tuple<double, double> latitudeAndLongitude = UnitFormationStation.GetLatitudeAndLongitude(myUnit, myUnit.GetParentGroup().GroupLead);
		double item = latitudeAndLongitude.Item1;
		double item2 = latitudeAndLongitude.Item2;
		if ((double)Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item, item2) < 0.25)
		{
			return true;
		}
		if ((double)Math.Abs(new Geopoint_Struct(item2, item).UpdateInvocation(myUnit)) > 90.0 && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.GetParentGroup().GroupLead.CurrentHeading)) < 20f)
		{
			return true;
		}
		return false;
	}

	public double DistanceFromPatrolStation()
	{
		if (HasNonPathfindPlottedCourse())
		{
			return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), PlottedCourse[PlottedCourse.Count() - 1].Latitude, PlottedCourse[PlottedCourse.Count() - 1].Longitude);
		}
		return 0.0;
	}

	public virtual void HeadToFormationStation(float float_0)
	{
		try
		{
			if (myUnit.GetParentGroup().GroupLead == null)
			{
				myUnit.GetParentGroup().PrintInvocation();
				if (myUnit.GetParentGroup().GroupLead == null)
				{
					return;
				}
			}
			if (myUnit is Aircraft)
			{
				Aircraft aircraft = (Aircraft)myUnit;
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				if (groupLead != myUnit && Module_Unit.RangeToUnit_Horiz(myUnit, groupLead) < 4f)
				{
					aircraft.AI.HasCaughtUpWithGroup = true;
				}
			}
			if (myUnit.IsGroupMember() && myUnit.GetParentGroup().GroupLead != null && (myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling) && myUnit.GetParentGroup().GroupLead.DockingOps.UNREP_Destination == myUnit)
			{
				if (myUnit.GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
				{
					Waypoint waypoint = myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse[0];
					myUnit.SetDesiredHeading(myUnit.GetParentGroup().GroupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint.Latitude, waypoint.Longitude));
					Waypoint waypoint_ = null;
					ExtendIfNecessary(float_0, ref waypoint_, waypoint.Latitude, waypoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
			}
			else
			{
				if (myUnit.IsGroupLead())
				{
					return;
				}
				if (HasPathfindingPlottedCourse)
				{
					FollowPlottedCourse(float_0);
					return;
				}
				ActiveUnit groupLead2 = myUnit.GetParentGroup().GroupLead;
				if (groupLead2 == null)
				{
					return;
				}
				Tuple<double, double> validatedLatitudeAndLongitude = UnitFormationStation.GetValidatedLatitudeAndLongitude(myUnit, groupLead2);
				double num = validatedLatitudeAndLongitude.Item1;
				double num2 = validatedLatitudeAndLongitude.Item2;
				if (SprintDrift)
				{
					PerformSprintDrift(float_0);
				}
				else
				{
					if (HaveReachedPoint(num, num2, float_0))
					{
						float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
						if (relativeBearing > 90f && relativeBearing < 270f)
						{
							myUnit.SetDesiredHeading(groupLead2.DesiredTurnRate, myUnit.GetParentGroup().DesiredHeading);
							myUnit.DesiredSpeed = myUnit.GetParentGroup().GroupLead.CurrentSpeed - 1f;
						}
						else
						{
							myUnit.SetDesiredHeading(groupLead2.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
							myUnit.DesiredSpeed = myUnit.GetParentGroup().DesiredSpeed;
						}
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
						return;
					}
					m_ErrorWrapper = true;
					myUnit.SetDesiredHeading(groupLead2.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						if (myUnit.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
						}
						else
						{
							myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
						}
					}
					else if (myUnit.IsGroupMember())
					{
						if ((int)myUnit.GetParentGroup().GroupLead.ThrottleSetting <= 3)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Full);
					}
				}
				if (groupLead2.CurrentSpeed > 0f)
				{
					double double_ = 0.0;
					double double_2 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref double_, ref double_2, UnitFormationStation.Distance, groupLead2.CurrentHeading);
					ActiveUnit activeUnit = myUnit;
					double double_3 = double_2;
					double double_4 = double_;
					int int_ = 0;
					bool bool_ = true;
					bool bool_2 = true;
					List<ActiveUnit> list_ = null;
					string string_ = "";
					bool bool_3 = false;
					if (!activeUnit.CanMoveToThisLocation(double_3, double_4, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
					{
						num = groupLead2.GetLatitude();
						num2 = groupLead2.GetLongitude();
					}
				}
				myUnit.AI.NavDestination = new Geopoint_Struct(num2, num);
				if (HasPathfindingPlottedCourse || PathFindingInProgress)
				{
					return;
				}
				if (myUnit.Navigator.bool_0)
				{
					double latitude = myUnit.GetLatitude();
					double longitude = myUnit.GetLongitude();
					double double_5 = num;
					double double_6 = num2;
					float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
					int int_2 = 0;
					GeoPoint geoPoint_ = null;
					if (PathLineIsInterrupted(latitude, longitude, double_5, double_6, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: true, nullable_, ref int_2, ref geoPoint_))
					{
						TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, num, num2, myUnit.ParentScen, bool_2: false);
						return;
					}
				}
				if (SprintDrift)
				{
					float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					if (relativeBearing2 > 90f && relativeBearing2 < 270f && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.GetParentGroup().CurrentHeading)) <= 30f)
					{
						myUnit.SetDesiredHeading(groupLead2.DesiredTurnRate, myUnit.GetParentGroup().CurrentHeading);
						myUnit.DesiredSpeed = (float)((double)myUnit.GetParentGroup().CurrentSpeed * 0.2);
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					}
					else
					{
						myUnit.SetDesiredHeading(groupLead2.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100217", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PlottedCourseLeadsToMissionArea(ref List<ReferencePoint> list_0, ref List<ReferencePoint> list_1, ref List<ReferencePoint> list_2, float float_0, bool bool_1)
	{
		if (PlottedCourse.Count() == 0)
		{
			return false;
		}
		if (list_0.Count == 0)
		{
			return false;
		}
		Waypoint waypoint = PlottedCourse.LastOrDefault();
		if (waypoint == null)
		{
			return false;
		}
		try
		{
			bool flag = CompareDic(list_0, list_2);
			if (!bool_1 && !flag)
			{
				if (!(TimeToNextPlottedCourseLeadsToMissionAreaEvaluation <= 0.0))
				{
					return CourseLeadsToMissionArea;
				}
				TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 60.0;
			}
			if (list_1 != null && (list_1.Count == 0 || flag))
			{
				CalculateAreaWithThresholdAdded_NM(float_0, ref list_0, ref list_1, ref list_2);
			}
			int num = list_0.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					ReferencePoint referencePoint = list_0[i];
					if (referencePoint.Latitude == waypoint.Latitude && referencePoint.Longitude == waypoint.Longitude)
					{
						CourseLeadsToMissionArea = true;
						return CourseLeadsToMissionArea;
					}
					if (float_0 > 0f && Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, referencePoint.Latitude, referencePoint.Longitude) <= float_0 * 2f)
					{
						CourseLeadsToMissionArea = true;
						return CourseLeadsToMissionArea;
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			if (list_0.Count == 1)
			{
				CourseLeadsToMissionArea = Math2.VerifyClass(waypoint.Latitude, waypoint.Longitude, list_0[0].Latitude, list_0[0].Longitude) <= float_0;
			}
			else if (list_0.Count > 1)
			{
				if (list_1 != null && list_1.Count != 0 && list_2 != null && float_0 != 0f)
				{
					CourseLeadsToMissionArea = GeoPoint.IsInsideThisArea(waypoint.Latitude, waypoint.Longitude, list_1.ToList());
				}
				else
				{
					CourseLeadsToMissionArea = GeoPoint.IsInsideThisArea(waypoint.Latitude, waypoint.Longitude, list_0);
				}
			}
			return CourseLeadsToMissionArea;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200341", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool CompareDic(List<ReferencePoint> list_0, List<ReferencePoint> list_1)
	{
		try
		{
			if (list_1 == null)
			{
				return true;
			}
			if (list_0.Count != list_1.Count)
			{
				return true;
			}
			int num = list_0.Count - 1;
			int i = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			for (; i <= num; i++)
			{
				double latitude;
				double longitude;
				try
				{
					if (list_1.Count == 0)
					{
						return false;
					}
					ReferencePoint referencePoint = list_0[i];
					latitude = referencePoint.Latitude;
					longitude = referencePoint.Longitude;
					if (list_1 != null && list_1.Count > i)
					{
						ReferencePoint referencePoint2 = list_1[i];
						if (referencePoint2 != null)
						{
							num2 = referencePoint2.Latitude;
							num3 = referencePoint2.Longitude;
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					continue;
				}
				if (latitude == num2 || Math.Abs(latitude - num2) <= 0.1)
				{
					if (longitude != num3 && !(Math.Abs(longitude - num3) <= 0.1))
					{
						return true;
					}
					continue;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200322", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool ReadDic(List<GeoPoint> list_0, List<GeoPoint> list_1)
	{
		try
		{
			if (Information.IsNothing(list_1))
			{
				return true;
			}
			if (list_0.Count == list_1.Count)
			{
				int num = list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list_0[i].Latitude != list_1[i].Latitude || list_0[i].Longitude != list_1[i].Longitude)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200566", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool DisableDic(ref List<ReferencePoint> list_0, ref List<ReferencePoint> list_1, ref List<ReferencePoint> list_2, int int_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (list_0.Count == 0)
			{
				return false;
			}
			bool flag = CompareDic(list_0, list_2);
			if (!bool_1 && !flag)
			{
				if (list_1 == null || list_2 == null)
				{
					goto IL_01f8;
				}
				switch (int_0)
				{
				case 10:
					break;
				case 1:
					goto IL_00cd;
				default:
					goto IL_0109;
				case 2:
					goto IL_0145;
				case 5:
					goto IL_0181;
				case 0:
					goto IL_01f8;
				}
				if (!(TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer <= 0.0))
				{
					return InsideMissionArea_10nmBuffer;
				}
				TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer = 60.0;
			}
			goto IL_026f;
			IL_01f8:
			if (bool_2)
			{
				if (!(TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer <= 0.0))
				{
					return InsideProsecutionArea_NoBuffer;
				}
				TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer = 60.0;
			}
			else
			{
				if (!(TimeToNextIsInsideMissionAreaEvaluation_NoBuffer <= 0.0))
				{
					return InsideMissionArea_NoBuffer;
				}
				TimeToNextIsInsideMissionAreaEvaluation_NoBuffer = 60.0;
			}
			goto IL_026f;
			IL_00cd:
			if (TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer <= 0.0)
			{
				TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer = 60.0;
				goto IL_026f;
			}
			return InsideMissionArea_1nmBuffer;
			IL_0109:
			if (TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer <= 0.0)
			{
				TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer = 60.0;
				goto IL_026f;
			}
			return InsideMissionArea_30nmBuffer;
			IL_026f:
			if ((list_0.Count > 1 && list_1 != null && list_1.Count == 0) || flag)
			{
				CalculateAreaWithThresholdAdded_NM(int_0, ref list_0, ref list_1, ref list_2);
			}
			if (list_0.Count == 1)
			{
				switch (int_0)
				{
				case 10:
					InsideMissionArea_10nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
					return InsideMissionArea_10nmBuffer;
				case 0:
					InsideMissionArea_NoBuffer = false;
					InsideProsecutionArea_NoBuffer = false;
					return false;
				case 1:
					InsideMissionArea_1nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
					return InsideMissionArea_1nmBuffer;
				case 2:
					InsideMissionArea_2nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
					return InsideMissionArea_2nmBuffer;
				default:
					InsideMissionArea_30nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
					return InsideMissionArea_30nmBuffer;
				case 5:
					if (bool_2)
					{
						InsideProsecutionArea_5nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
						return InsideProsecutionArea_5nmBuffer;
					}
					InsideMissionArea_5nmBuffer = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), list_0[0].Latitude, list_0[0].Longitude) <= (float)int_0;
					return InsideMissionArea_5nmBuffer;
				}
			}
			if (list_0.Count <= 1)
			{
				return false;
			}
			if (!Information.IsNothing(list_1) && !Information.IsNothing(list_2))
			{
				switch (int_0)
				{
				case 10:
					InsideMissionArea_10nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
					return InsideMissionArea_10nmBuffer;
				case 1:
					InsideMissionArea_1nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
					return InsideMissionArea_1nmBuffer;
				case 2:
					InsideMissionArea_2nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
					return InsideMissionArea_2nmBuffer;
				default:
					InsideMissionArea_30nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
					return InsideMissionArea_30nmBuffer;
				case 5:
					if (bool_2)
					{
						InsideProsecutionArea_5nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
						return InsideProsecutionArea_5nmBuffer;
					}
					InsideMissionArea_5nmBuffer = myUnit.GetIsInsideThisArea(list_1.ToList(), myUnit.ParentScen, bool_0: false);
					return InsideMissionArea_5nmBuffer;
				case 0:
					break;
				}
			}
			if (bool_2)
			{
				InsideProsecutionArea_NoBuffer = myUnit.GetIsInsideThisArea(list_0.ToList(), myUnit.ParentScen, bool_0: false);
				return InsideProsecutionArea_NoBuffer;
			}
			InsideMissionArea_NoBuffer = myUnit.GetIsInsideThisArea(list_0.ToList(), myUnit.ParentScen, bool_0: false);
			return InsideMissionArea_NoBuffer;
			IL_0145:
			if (TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer <= 0.0)
			{
				TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer = 60.0;
				goto IL_026f;
			}
			return InsideMissionArea_2nmBuffer;
			IL_0181:
			if (bool_2)
			{
				if (!(TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer <= 0.0))
				{
					return InsideProsecutionArea_5nmBuffer;
				}
				TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer = 60.0;
			}
			else
			{
				if (!(TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer <= 0.0))
				{
					return InsideMissionArea_5nmBuffer;
				}
				TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer = 60.0;
			}
			goto IL_026f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200319", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool IsInsideUncertaintryArea(ref List<GeoPoint> list_0, float float_0)
	{
		if (list_0.Count == 0)
		{
			return false;
		}
		try
		{
			if (float_0 == 0f)
			{
				return myUnit.GetIsInsideThisArea(list_0, myUnit.ParentScen, bool_0: true);
			}
			List<GeoPoint> list_ = new List<GeoPoint>();
			CalculateAreaWithThresholdAdded_NM(float_0, ref list_0, ref list_);
			return myUnit.GetIsInsideThisArea(list_, myUnit.ParentScen, bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101261", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool IsInsideUncertaintryArea(ref List<Geopoint_Struct> list_0, float float_0)
	{
		if (list_0.Count == 0)
		{
			return false;
		}
		try
		{
			if (float_0 == 0f)
			{
				return myUnit.GetIsInsideThisArea(list_0, myUnit.ParentScen, bool_0: true);
			}
			List<GeoPoint> list_ = new List<GeoPoint>();
			CalculateAreaWithThresholdAdded_NM(float_0, ref list_0, ref list_);
			return myUnit.GetIsInsideThisArea(list_, myUnit.ParentScen, bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 3095732967", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float float_0, ref List<ReferencePoint> list_0, ref List<ReferencePoint> list_1, ref List<ReferencePoint> list_2)
	{
		try
		{
			list_2.Clear();
			List<ReferencePoint> list = new List<ReferencePoint>();
			int count = list_0.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			int num2 = count - 1;
			int index;
			for (int i = 0; i <= num2; i++)
			{
				List<ReferencePoint> obj = list_0;
				ReferencePoint referencePoint_ = obj[index = i];
				ReferencePoint item = ReferencePoint.CopyRefPoint(ref referencePoint_);
				obj[index] = referencePoint_;
				list.Add(item);
			}
			list_2 = list;
			if (float_0 == 0f)
			{
				return;
			}
			float num3 = float_0 * 1852f;
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			index = count - 1;
			for (int j = 0; j <= index; j++)
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(list_0[j].Longitude, list_0[j].Latitude);
				array[j] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			list_1.Clear();
			List<ReferencePoint> list2 = new List<ReferencePoint>();
			IGeometry geometry = null;
			if (count <= 2)
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(num3, 3);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200309", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					Point point = new Point(array[0]);
					try
					{
						geometry = point.Buffer(num3, 3);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200310", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			else
			{
				List<IntPoint> list3 = new List<IntPoint>();
				Coordinate[] array2 = array;
				Coordinate[] array3 = array2;
				foreach (Coordinate coordinate in array3)
				{
					list3.Add(new IntPoint(coordinate.X, coordinate.Y));
				}
				ClipperOffset clipperOffset = new ClipperOffset();
				clipperOffset.AddPath(list3, JoinType.jtSquare, EndType.etClosedPolygon);
				List<List<IntPoint>> list_3 = new List<List<IntPoint>>();
				try
				{
					clipperOffset.Execute(ref list_3, num3);
					List<Coordinate> list4 = new List<Coordinate>();
					foreach (IntPoint item2 in list_3[0])
					{
						list4.Add(new Coordinate(item2.X, item2.Y));
					}
					geometry = new Polygon(list4);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200304", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			IList<Coordinate> list5 = geometry?.Coordinates;
			if (Debugger.IsAttached && (geometry == null || list5.Count == 0))
			{
				Debugger.Break();
			}
			if (geometry != null)
			{
				int num4 = list5.Count - 2;
				for (int k = 0; k <= num4; k++)
				{
					MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(list5[k].X, list5[k].Y);
					list2.Add(new ReferencePoint(tCoord.Lon, tCoord.Lat, bool_0: false));
				}
				list_1 = list2;
			}
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 200303", exception_4.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float float_0, ref List<GeoPoint> list_0, ref List<GeoPoint> list_1)
	{
		try
		{
			int count = list_0.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (float_0 == 0f)
			{
				return;
			}
			float num2 = float_0 * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(list_0[0].Latitude, list_0[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			double double_ = 0.0;
			double double_2 = 0.0;
			for (int i = 0; i <= num3; i++)
			{
				array[i] = new Coordinate(double_, double_2);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			list_1.Clear();
			List<GeoPoint> list = new List<GeoPoint>();
			IGeometry geometry = null;
			if (count <= 2)
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(num2, 3);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200317", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					Point point = new Point(array[0]);
					try
					{
						geometry = point.Buffer(num2, 3);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200318", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			else
			{
				List<IntPoint> list2 = new List<IntPoint>();
				double num4 = 10000.0;
				Coordinate[] array2 = array;
				Coordinate[] array3 = array2;
				foreach (Coordinate coordinate in array3)
				{
					list2.Add(new IntPoint(coordinate.X * num4, coordinate.Y * num4));
				}
				ClipperOffset clipperOffset = new ClipperOffset();
				clipperOffset.AddPath(list2, JoinType.jtSquare, EndType.etClosedPolygon);
				List<List<IntPoint>> list_2 = new List<List<IntPoint>>();
				try
				{
					clipperOffset.Execute(ref list_2, (double)num2 * num4);
					if (list_2.Count > 0)
					{
						List<Coordinate> list3 = new List<Coordinate>();
						foreach (IntPoint item in list_2[0])
						{
							list3.Add(new Coordinate((double)item.X / num4, (double)item.Y / num4));
						}
						geometry = new Polygon(list3);
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200305", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (geometry == null)
			{
				return;
			}
			IList<Coordinate> coordinates = geometry.Coordinates;
			int num5 = coordinates.Count - 2;
			double double_3 = 0.0;
			double double_4 = 0.0;
			for (int j = 0; j <= num5; j++)
			{
				tLocalTM.CustomizeInterruptibleQueue(coordinates[j].X, coordinates[j].Y, ref double_3, ref double_4);
				if (double_4 <= 180.0)
				{
					if (double_4 < -180.0)
					{
						double_4 = -180.0;
					}
				}
				else
				{
					double_4 = 180.0;
				}
				if (double_3 <= 90.0)
				{
					if (double_3 < -90.0)
					{
						double_3 = -90.0;
					}
				}
				else
				{
					double_3 = 90.0;
				}
				list.Add(new GeoPoint(double_4, double_3));
			}
			list_1 = list;
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 200306", exception_4.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float float_0, ref List<Geopoint_Struct> list_0, ref List<GeoPoint> list_1)
	{
		try
		{
			int count = list_0.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (float_0 == 0f)
			{
				return;
			}
			float num2 = float_0 * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(list_0[0].Latitude, list_0[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			int i = 0;
			double double_ = 0.0;
			double double_2 = 0.0;
			IGeometry geometry = null;
			double double_3 = 0.0;
			double double_4 = 0.0;
			for (; i <= num3; i++)
			{
				if (tLocalTM.CountInterruptibleQueue(list_0[i].Latitude, list_0[i].Longitude, ref double_, ref double_2, bool_0: false))
				{
					array[i] = new Coordinate(double_, double_2);
					continue;
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			list_1.Clear();
			List<GeoPoint> list = new List<GeoPoint>();
			if (count <= 2)
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(num2, 3);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200317", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					Point point = new Point(array[0]);
					try
					{
						geometry = point.Buffer(num2, 3);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200318", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			else
			{
				List<IntPoint> list2 = new List<IntPoint>();
				double num4 = 10000.0;
				Coordinate[] array2 = array;
				Coordinate[] array3 = array2;
				foreach (Coordinate coordinate in array3)
				{
					list2.Add(new IntPoint(coordinate.X * num4, coordinate.Y * num4));
				}
				ClipperOffset clipperOffset = new ClipperOffset();
				clipperOffset.AddPath(list2, JoinType.jtSquare, EndType.etClosedPolygon);
				List<List<IntPoint>> list_2 = new List<List<IntPoint>>();
				try
				{
					clipperOffset.Execute(ref list_2, (double)num2 * num4);
					if (list_2.Count > 0)
					{
						List<Coordinate> list3 = new List<Coordinate>();
						foreach (IntPoint item in list_2[0])
						{
							list3.Add(new Coordinate((double)item.X / num4, (double)item.Y / num4));
						}
						geometry = new Polygon(list3);
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200305", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (geometry == null)
			{
				return;
			}
			IList<Coordinate> coordinates = geometry.Coordinates;
			int num5 = coordinates.Count - 2;
			for (int j = 0; j <= num5; j++)
			{
				tLocalTM.CustomizeInterruptibleQueue(coordinates[j].X, coordinates[j].Y, ref double_3, ref double_4);
				if (double_4 <= 180.0)
				{
					if (double_4 < -180.0)
					{
						double_4 = -180.0;
					}
				}
				else
				{
					double_4 = 180.0;
				}
				if (double_3 <= 90.0)
				{
					if (double_3 < -90.0)
					{
						double_3 = -90.0;
					}
				}
				else
				{
					double_3 = 90.0;
				}
				list.Add(new GeoPoint(double_4, double_3));
			}
			list_1 = list;
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 34573409587239867345", exception_4.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PlotCourseToCargoDestination(ActiveUnit activeUnit_0)
	{
		try
		{
			ClearPlottedCourse();
			if (activeUnit_0 != null)
			{
				AddWaypoint(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, bool_1: false);
				if (PlottedCourse.Count() > 0)
				{
					PlottedCourse[0].Description = "Cargo delivery destination";
				}
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude()));
				ResetTimeToNextPathfinderCheck();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at KJHKJHLHJBSSGZ", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PlotCourseToArea(List<ReferencePoint> list_0, bool bool_1 = false, Waypoint.WaypointType waypointType_0 = Waypoint.WaypointType.PatrolStation)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			switch (list_0.Count)
			{
			default:
			{
				bool flag = false;
				int num3 = 0;
				while (!flag)
				{
					Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(list_0);
					if (!geopoint_Struct.HasZeroCoords)
					{
						ActiveUnit activeUnit2 = myUnit;
						double latitude = geopoint_Struct.Latitude;
						double longitude = geopoint_Struct.Longitude;
						int int_ = 0;
						bool bool_2 = true;
						bool bool_3 = true;
						List<ActiveUnit> list_ = null;
						string string_ = "";
						bool bool_4 = false;
						if (activeUnit2.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_3, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_4))
						{
							flag = true;
							num = geopoint_Struct.Latitude;
							num2 = geopoint_Struct.Longitude;
						}
						num3++;
						if (num3 >= 32767)
						{
							return;
						}
						continue;
					}
					myUnit.AddMessage(myUnit.Name + "无法在参考点定义的区域内选择合适的点：" + string.Join(" - ", list_0.Select((ReferencePoint theP) => theP.Name)), "无法选取一个点", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					return;
				}
				break;
			}
			case 0:
			{
				ActiveUnit activeUnit = myUnit;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: true, ref missionAssignmentAttemptResult_);
				ClearPlottedCourse();
				return;
			}
			case 1:
				num = list_0[0].Latitude;
				num2 = list_0[0].Longitude;
				break;
			case 2:
			{
				List<ReferencePoint> list = list_0.OrderByDescending((ReferencePoint referencePoint_0) => Module_Unit.RangeToPoint_Horiz(myUnit, referencePoint_0.Latitude, referencePoint_0.Longitude)).ToList();
				num2 = list[0].Longitude;
				num = list[0].Latitude;
				break;
			}
			}
			ClearPlottedCourse();
			AddWaypoint(num, num2, 0f, waypointType_0, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, bool_1);
			myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num, num2));
			ResetTimeToNextPathfinderCheck();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at KJHKJHLHJBSSGY", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PlotCourseToPickupPoint()
	{
		if (Information.IsNothing(myUnit.AI.PrimaryPickupTarget))
		{
			return;
		}
		ClearPlottedCourse();
		double latitude = myUnit.AI.PrimaryPickupTarget.GetLatitude();
		double longitude = myUnit.AI.PrimaryPickupTarget.GetLongitude();
		if (!myUnit.IsAircraft)
		{
			List<GeoPoint> list = myUnit.DockingOps.ManageClient(myUnit, myUnit.AI.PrimaryPickupTarget);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			latitude = list.First().Latitude;
			longitude = list.First().Longitude;
		}
		AddWaypoint(latitude, longitude, 0f, Waypoint.WaypointType.PickupPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, bool_1: false);
	}

	public virtual void PlotCourseToStationArea(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.ParentScen.UserIsPlottingCourse)
			{
				return;
			}
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				if (((Patrol)myUnit.AssignedMissionOrPackage()).MovementStyle == Patrol.PatrolMovementStyle.RepeatableLoop)
				{
					FollowPatrolRepeatableLoopCourse(float_0, !IsInsidePatrolArea);
					return;
				}
				Aircraft aircraft = null;
				if (myUnit.IsAircraft)
				{
					aircraft = (Aircraft)myUnit;
				}
				if (myUnit.IsGroup)
				{
					ActiveUnit groupLead = ((Group)myUnit).GroupLead;
					if (groupLead.IsAircraft)
					{
						aircraft = (Aircraft)groupLead;
					}
				}
				if (aircraft != null)
				{
					Aircraft_AirOps airOps = aircraft.AirOps;
					Aircraft_Navigator navigator = aircraft.Navigator;
					navigator.SetPatrolThrottle(bool_1: false, airOps.Condition);
					navigator.SetPatrolAltitude(bool_1: false, airOps.Condition);
				}
			}
			else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myUnit.AssignedMissionOrPackage();
				bool flag = myUnit.Navigator.DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false);
				if (((MineClearingMission)myUnit.AssignedMissionOrPackage()).MovementStyle == Mission.MissionMovementStyle.RepeatableLoop)
				{
					FollowMineClearingMissionCourse(float_0, !flag);
				}
				else
				{
					PlotCourseToArea(mineClearingMission.Area);
				}
				return;
			}
			if (myUnit.AssignedMissionOrPackage() == null)
			{
				return;
			}
			List<ReferencePoint> list;
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				if (patrol == null || patrol.PatrolArea == null)
				{
					return;
				}
				list = patrol.PatrolArea;
			}
			else
			{
				if (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Support)
				{
					return;
				}
				SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
				if (supportMission == null || supportMission.NavigationCourse == null)
				{
					return;
				}
				list = supportMission.NavigationCourse;
			}
			double? num = null;
			double? num2 = null;
			switch (list.Count)
			{
			default:
			{
				if (!(Information.IsNothing(PlottedCourse) || PlottedCourse.Count() == 0 || bool_1))
				{
					break;
				}
				bool flag2 = false;
				int num3 = 0;
				while (!flag2)
				{
					num3++;
					Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(list);
					if (!Information.IsNothing(geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
					{
						ActiveUnit activeUnit = myUnit;
						double latitude = geopoint_Struct.Latitude;
						double longitude = geopoint_Struct.Longitude;
						int int_ = 0;
						bool bool_2 = true;
						bool bool_3 = true;
						List<ActiveUnit> list_ = null;
						string string_ = "";
						bool bool_4 = false;
						if (!activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_2, bool_4: true, ref bool_3, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_4))
						{
							if (num3 > 1000)
							{
								myUnit.AddMessage(myUnit.Name + "无法在参考点定义的巡逻区域内选择合适的点：" + string.Join(" - ", list.Select((ReferencePoint theP) => theP.Name)), "无法选取一个点", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
								return;
							}
							continue;
						}
						flag2 = true;
						num = geopoint_Struct.Latitude;
						num2 = geopoint_Struct.Longitude;
						break;
					}
					myUnit.AddMessage(myUnit.Name + "无法在参考点定义的巡逻区域内选择合适的点：" + string.Join(" - ", list.Select((ReferencePoint theP) => theP.Name)), "无法选取一个点", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					return;
				}
				break;
			}
			case 0:
				if (HasFlightPlan)
				{
					return;
				}
				if (Information.IsNothing(PlottedCourse) || PlottedCourse.Count() == 0)
				{
					myUnit.AddMessage(myUnit.Name + "已从任务中删除：" + myUnit.AssignedMissionOrPackage().Name + "（巡逻区域未定义！）", myUnit.Name + " 起飞任务", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					ActiveUnit activeUnit2 = myUnit;
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
					activeUnit2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				}
				break;
			case 1:
				if (Information.IsNothing(PlottedCourse) || PlottedCourse.Count() == 0 || bool_1)
				{
					num = list[0].Latitude;
					num2 = list[0].Longitude;
				}
				break;
			case 2:
				if (Information.IsNothing(PlottedCourse) || PlottedCourse.Count() == 0 || bool_1)
				{
					ReferencePoint referencePoint = null;
					referencePoint = list.OrderByDescending(delegate(ReferencePoint referencePoint_0)
					{
						ActiveUnit unit_ = myUnit;
						ReferencePoint referencePoint2;
						double double_ = (referencePoint2 = referencePoint_0).Latitude;
						ReferencePoint referencePoint3;
						double double_2 = (referencePoint3 = referencePoint_0).Longitude;
						double result = Module_Unit.RangeToPoint_Horiz_Angular(unit_, ref double_, ref double_2);
						referencePoint3.Longitude = double_2;
						referencePoint2.Latitude = double_;
						return result;
					}).ElementAtOrDefault(0);
					num2 = referencePoint.Longitude;
					num = referencePoint.Latitude;
				}
				break;
			}
			if (num.HasValue && num2.HasValue)
			{
				if (bool_1 && myUnit.Navigator.PlottedCourse.Count() > 0)
				{
					myUnit.Navigator.ClearPathfindingWaypoints();
					Waypoint waypoint_ = new Waypoint(num2.Value, num.Value, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					ActiveUnit_Navigator navigator2 = myUnit.Navigator;
					Waypoint[] waypoint_2 = navigator2.PlottedCourse;
					AddWaypoint(ref waypoint_2, 0, waypoint_);
					navigator2.PlottedCourse = waypoint_2;
				}
				else
				{
					ClearPlottedCourse();
					AddWaypoint(num.Value, num2.Value, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), num.Value, num2.Value));
			}
			ResetTimeToNextPathfinderCheck();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100221", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool UpdateDic(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref float float_0)
	{
		try
		{
			double Local_TakeOffPoint_Lon = 0.0;
			double Local_TakeOffPoint_Lat = 0.0;
			if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				return false;
			}
			Mission mission = myUnit.AssignedMissionOrPackage();
			List<ReferencePoint> list;
			if (mission.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(patrol))
				{
					return false;
				}
				if (Information.IsNothing(patrol.PatrolArea))
				{
					return false;
				}
				list = patrol.PatrolArea;
			}
			else
			{
				if (mission.MissionClass != Mission._MissionClass.Support)
				{
					return false;
				}
				SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(supportMission))
				{
					return false;
				}
				if (Information.IsNothing(supportMission.NavigationCourse))
				{
					return false;
				}
				list = supportMission.NavigationCourse;
			}
			if (myUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)myUnit;
				if (Information.IsNothing(aircraft.AirOps.CurrentHostUnit))
				{
					if (Information.IsNothing(aircraft.AirOps.HostAirFacility))
					{
						Local_TakeOffPoint_Lat = aircraft.GetLatitude();
						Local_TakeOffPoint_Lon = aircraft.GetLongitude();
					}
					else
					{
						Local_TakeOffPoint_Lat = aircraft.AirOps.CurrentHostUnit.GetLatitude();
						Local_TakeOffPoint_Lon = aircraft.AirOps.CurrentHostUnit.GetLongitude();
					}
				}
				else
				{
					Local_TakeOffPoint_Lat = aircraft.AirOps.CurrentHostUnit.GetLatitude();
					Local_TakeOffPoint_Lon = aircraft.AirOps.CurrentHostUnit.GetLongitude();
				}
			}
			else
			{
				Local_TakeOffPoint_Lat = myUnit.GetLatitude();
				Local_TakeOffPoint_Lon = myUnit.GetLongitude();
			}
			switch (list.Count)
			{
			default:
			{
				bool flag = false;
				int num5 = 0;
				while (true)
				{
					if (!flag)
					{
						num5++;
						Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(list);
						Geopoint_Struct geopoint_Struct2 = Math2.RandomPointWithinThisArea(list);
						if (Information.IsNothing(geopoint_Struct) || geopoint_Struct.HasZeroCoords || Information.IsNothing(geopoint_Struct2) || geopoint_Struct2.HasZeroCoords)
						{
							break;
						}
						ActiveUnit activeUnit = myUnit;
						double latitude = geopoint_Struct.Latitude;
						double longitude = geopoint_Struct.Longitude;
						int int_ = 0;
						bool bool_ = true;
						bool bool_2 = true;
						List<ActiveUnit> list_ = null;
						string string_ = "";
						bool bool_3 = false;
						if (activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
						{
							ActiveUnit activeUnit2 = myUnit;
							double latitude2 = geopoint_Struct2.Latitude;
							double longitude2 = geopoint_Struct2.Longitude;
							int_ = 0;
							bool_3 = true;
							bool_2 = true;
							list_ = null;
							string_ = "";
							bool_ = false;
							if (activeUnit2.CanMoveToThisLocation(latitude2, longitude2, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_3, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_))
							{
								flag = true;
								double_0 = geopoint_Struct.Latitude;
								double_1 = geopoint_Struct.Longitude;
								double_2 = geopoint_Struct2.Latitude;
								double_3 = geopoint_Struct2.Longitude;
								float num6 = Math2.VerifyClass(double_0, double_1, double_2, double_3);
								if (num6 <= float_0)
								{
									if (num6 < float_0)
									{
										float_0 = num6;
										float num7 = Math2.PublishClass(double_0, double_1, double_2, double_3);
										float float_3 = (float_0 - num6) / 2f;
										Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_1, ref double_0, float_3, Math2.UpdateClass(num7 + 180f));
										Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_3, num7);
									}
								}
								else
								{
									float num8 = Math2.PublishClass(double_0, double_1, double_2, double_3);
									float float_4 = (num6 - float_0) / 2f;
									Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_1, ref double_0, float_4, num8);
									Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_4, Math2.UpdateClass(num8 + 180f));
								}
								return true;
							}
						}
						if (num5 > 1000)
						{
							myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select((ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							return false;
						}
						continue;
					}
					myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select((ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					return false;
				}
				myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select((ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				return false;
			}
			case 0:
			{
				myUnit.AddMessage("任务" + mission.Name + " has no station area defined!", "Mission has no station area!", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				ActiveUnit activeUnit3 = myUnit;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				activeUnit3.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				return false;
			}
			case 1:
			{
				double_0 = list[0].Latitude;
				double_1 = list[0].Longitude;
				float num4 = Math2.PublishClass(Local_TakeOffPoint_Lat, Local_TakeOffPoint_Lon, double_0, double_1);
				num4 += (float)GameGeneral.LockRandom_0.Next(-60, 60);
				Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_3, ref double_2, float_0, num4);
				return true;
			}
			case 2:
			{
				List<ReferencePoint> list2 = list.OrderByDescending((ReferencePoint theP) => Math2.VerifyClass(theP.Latitude, theP.Longitude, Local_TakeOffPoint_Lat, Local_TakeOffPoint_Lon)).ToList();
				double_1 = list2[0].Longitude;
				double_0 = list2[0].Latitude;
				double_3 = list2[1].Longitude;
				double_2 = list2[1].Latitude;
				float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
				if (num <= float_0)
				{
					if (num < float_0)
					{
						float_0 = num;
						float num2 = Math2.PublishClass(double_0, double_1, double_2, double_3);
						float float_ = (float_0 - num) / 2f;
						Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_1, ref double_0, float_, Math2.UpdateClass(num2 + 180f));
						Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_, num2);
					}
				}
				else
				{
					float num3 = Math2.PublishClass(double_0, double_1, double_2, double_3);
					float float_2 = (num - float_0) / 2f;
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_1, ref double_0, float_2, num3);
					Geodesic_EdWilliams.CalcPoint_Williams(double_3, double_2, ref double_3, ref double_2, float_2, Math2.UpdateClass(num3 + 180f));
				}
				return true;
			}
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
			return false;
		}
	}

	public bool HasNonPathfindPlottedCourse()
	{
		int num = PlottedCourse.Length;
		if (num == 0)
		{
			return false;
		}
		try
		{
			int num2 = num - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					Waypoint waypoint;
					try
					{
						waypoint = PlottedCourse[num3];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						goto IL_0073;
					}
					if (waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						break;
					}
					goto IL_0073;
				}
				return false;
				IL_0073:
				num3++;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200008", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public bool HasPlottedCourse()
	{
		return PlottedCourse.Length != 0;
	}

	public virtual void AddWaypoint(double double_0, double double_1, float float_0, Waypoint.WaypointType waypointType_0, Waypoint.WaypointCreator waypointCreator_0, Waypoint.WaypointCategory waypointCategory_0, bool bool_1 = true)
	{
		try
		{
			if (myUnit.IsGroupLead())
			{
				myUnit.GetParentGroup().Navigator.AddWaypoint(new Waypoint(double_1, double_0, float_0, waypointType_0, waypointCreator_0, waypointCategory_0));
			}
			else
			{
				ArrayExtensions.Add(ref _PlottedCourse, new Waypoint(double_1, double_0, float_0, waypointType_0, waypointCreator_0, waypointCategory_0, bool_1));
			}
			ManualPlotOverride = waypointType_0 == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100222", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddWaypoint(Waypoint waypoint_0)
	{
		_ = Debugger.IsAttached;
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.AddWaypoint(waypoint_0);
		}
		else
		{
			ArrayExtensions.Add(ref _PlottedCourse, waypoint_0);
		}
	}

	public void AddWaypoint(int int_0, Waypoint waypoint_0)
	{
		_ = Debugger.IsAttached;
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.AddWaypoint(int_0, waypoint_0);
			return;
		}
		List<Waypoint> list = _PlottedCourse.ToList();
		list.Insert(int_0, waypoint_0);
		_PlottedCourse = list.ToArray();
	}

	public static void AddWaypoint(ref Waypoint[] waypoint_0, int int_0, Waypoint waypoint_1)
	{
		_ = Debugger.IsAttached;
		ArrayExtensions.Insert(ref waypoint_0, int_0, waypoint_1);
	}

	public void PlotLocalizationCourse()
	{
		try
		{
			if (myUnit.PlayerIsPlottingCourse || Information.IsNothing(myUnit.AI.PrimaryTarget))
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (myUnit.Navigator.HasNonPathfindPlottedCourse())
			{
				if (!GeoPoint.IsInsideThisArea(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, myUnit.AI.PrimaryTarget.UncertaintyArea))
				{
					ClearPlottedCourse();
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			Geopoint_Struct geopoint_Struct = new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude());
			int num = 0;
			double double_ = 0.0;
			double double_2 = 0.0;
			string text;
			while (true)
			{
				geopoint_Struct = Math2.RandomCornerWithinThisArea(myUnit.AI.PrimaryTarget.UncertaintyArea, myUnit.GetLatitude(), myUnit.GetLongitude(), bool_0: true);
				ActiveUnit activeUnit = myUnit;
				double latitude = geopoint_Struct.Latitude;
				double longitude = geopoint_Struct.Longitude;
				int int_ = 0;
				bool bool_ = true;
				bool bool_2 = true;
				List<ActiveUnit> list_ = null;
				string string_ = "";
				bool bool_3 = false;
				if (!activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: true, bool_7: false, ref string_, ref bool_3))
				{
					text = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					if (flag2)
					{
						break;
					}
					if (flag3)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + text + "正在尝试规划路径以确定目标位置" + myUnit.AI.PrimaryTarget.Name + "但是目标是地面（设施）类型，搜索区域在海上！内置导航器找不到合适的位置来开始搜索。", myUnit.Name + " 无法规划定位", LoggedMessage.MessageType.AirOps, 0, null, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						return;
					}
					if (flag4)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + text + "正在尝试规划路径以确定目标位置" + myUnit.AI.PrimaryTarget.Name + "然而，目标是一个水下（潜艇）类型，而搜索区域在冰下！内置导航器找不到合适的位置来开始搜索。", myUnit.Name + " 无法规划定位", LoggedMessage.MessageType.AirOps, 0, null, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						return;
					}
					if (num == 10)
					{
						ActiveUnit_Navigator navigator = myUnit.Navigator;
						double latitude2 = geopoint_Struct.Latitude;
						double longitude2 = geopoint_Struct.Longitude;
						list_ = null;
						if (!navigator.GetNearestAccessibleSpot(latitude2, longitude2, ref double_, ref double_2, bool_1: false, bool_2: false, bool_3: true, 0f, ref list_, bool_4: true))
						{
							myUnit.ParentScen.AddMessage("飞机" + myUnit.Name + text + "正在尝试规划路径以确定目标位置" + myUnit.AI.PrimaryTarget.Name + "，但是不确定区域位于禁航区或其他不允许飞机进入的位置！内置导航器找不到合适的位置来开始搜索。", myUnit.Name + " 无法规划精确定位", LoggedMessage.MessageType.AirOps, 0, null, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							return;
						}
						geopoint_Struct.Latitude = double_;
						geopoint_Struct.Longitude = double_2;
						myUnit.ParentScen.AddMessage("飞机" + myUnit.Name + text + "正在尝试规划路径以确定目标位置" + myUnit.AI.PrimaryTarget.Name + "，但是不确定区域位于禁航区或其他不允许飞机进入的位置！", myUnit.Name + " 无法规划精确定位", LoggedMessage.MessageType.AirOps, 0, null, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						goto IL_0685;
					}
				}
				else
				{
					if (Information.IsNothing(myUnit.AI.PrimaryTarget))
					{
						goto IL_0685;
					}
					if (!myUnit.AI.PrimaryTarget.IsSubmergedContact && !myUnit.AI.PrimaryTarget.IsSurfaceContact)
					{
						if (!myUnit.AI.PrimaryTarget.IsGroundContact || !geopoint_Struct.ReflectInvocation(myUnit.ParentScen))
						{
							goto IL_0685;
						}
						flag3 = true;
					}
					else if (geopoint_Struct.PrepareInvocation(myUnit.ParentScen))
					{
						flag2 = true;
					}
					else
					{
						if (!myUnit.IsAircraft || !myUnit.AI.PrimaryTarget.IsSubmergedContact || !SeaIceProvider.PrepareWriter(geopoint_Struct.Longitude, geopoint_Struct.Latitude))
						{
							goto IL_0685;
						}
						flag4 = true;
					}
				}
				num++;
				if (num <= 10)
				{
					continue;
				}
				goto IL_0685;
				IL_0685:
				Waypoint waypoint_ = new Waypoint(geopoint_Struct.Longitude, geopoint_Struct.Latitude, myUnit.GetCurrentAltitude(), Waypoint.WaypointType.LocalizationRun, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				myUnit.Navigator.AddWaypoint(waypoint_);
				geopoint_Struct = default(Geopoint_Struct);
				byte? b = (byte?)myUnit.Doctrine.GetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					myUnit.Doctrine.SetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.No);
					string text2 = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
					{
						text2 = " (" + myUnit.UnitClass + ")";
					}
					myUnit.AddMessage(myUnit.Name + text2 + "将“忽略规划路径”条令从“是”更改为“否”（原因：在尝试定位目标时需要遵循本地化路径）。", myUnit.Name + " 规划路径设置已改变", LoggedMessage.MessageType.UnitAI, 5, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				return;
			}
			myUnit.ParentScen.AddMessage(myUnit.Name + text + "正在尝试规划路径以确定目标位置" + myUnit.AI.PrimaryTarget.Name + "但是目标是海军类型，搜索区域是陆上的！内置导航器找不到合适的位置来开始搜索。", myUnit.Name + " 无法规划定位", LoggedMessage.MessageType.AirOps, 0, null, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100394", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveWaypoint_Soft(Waypoint waypoint_0, bool bool_1)
	{
		if (myUnit.IsGroupLead())
		{
			myUnit.GetParentGroup().Navigator.RemoveWaypoint_Soft(waypoint_0, bool_1);
			return;
		}
		if (bool_1)
		{
			InsertDic(ref waypoint_0);
		}
		ArrayExtensions.Remove(ref _PlottedCourse, waypoint_0);
	}

	public static void RemoveWaypoint_Hard(Scenario scenario_0, Mission mission_0, Mission.Flight flight_0, Waypoint waypoint_0)
	{
		InsertDic(ref waypoint_0);
		Waypoint[] gparam_ = flight_0.FlightPlan;
		ArrayExtensions.Remove(ref gparam_, waypoint_0);
		flight_0.FlightPlan = gparam_;
		ActiveUnit referenceUnit = flight_0.GetReferenceUnit(scenario_0);
		gparam_ = flight_0.FlightPlan;
		float float_ = 0f;
		float float_2 = 0f;
		MissionPlanner.ConnectTokenizer(scenario_0, mission_0, referenceUnit, flight_0, ref gparam_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
		flight_0.FlightPlan = gparam_;
	}

	private static void InsertDic(ref Waypoint waypoint_0)
	{
		if (!Information.IsNothing(waypoint_0.Waypoint_LeadElementWingman))
		{
			waypoint_0.Waypoint_LeadElementWingman = null;
		}
		if (!Information.IsNothing(waypoint_0.Waypoint_SecondElement))
		{
			waypoint_0.Waypoint_SecondElement = null;
		}
		if (!Information.IsNothing(waypoint_0.Waypoint_SecondElementWingman))
		{
			waypoint_0.Waypoint_SecondElementWingman = null;
		}
		if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElement))
		{
			waypoint_0.Waypoint_ThirdElement = null;
		}
		if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElementWingman))
		{
			waypoint_0.Waypoint_ThirdElementWingman = null;
		}
	}

	public virtual void CalculateFormationStationRelativeData()
	{
		try
		{
			if (myUnit.GetParentGroup() != null && !myUnit.IsGroupLead())
			{
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				float num = Math2.PublishClass(groupLead.GetLatitude(), groupLead.GetLongitude(), myUnit.GetLatitude(), myUnit.GetLongitude());
				if (UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					UnitFormationStation.Bearing = MathFunctions.DeleteRequest(groupLead.CurrentHeading, num);
				}
				else
				{
					UnitFormationStation.Bearing = num;
				}
				UnitFormationStation.Distance = Module_Unit.RangeToUnit_Horiz(myUnit, groupLead);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100223", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CalculateFormationStationRelativeData(double double_0, double double_1, bool bool_1)
	{
		try
		{
			if (myUnit.GetParentGroup() == null || myUnit.IsGroupLead())
			{
				return;
			}
			ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
			if (!Information.IsNothing(groupLead) && (bool_1 || (UnitFormationStation.Bearing == 0f && UnitFormationStation.Distance == 0f)))
			{
				float num = Math2.PublishClass(groupLead.GetLatitude(), groupLead.GetLongitude(), double_1, double_0);
				if (UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					UnitFormationStation.Bearing = MathFunctions.DeleteRequest(groupLead.CurrentHeading, num);
				}
				else
				{
					UnitFormationStation.Bearing = num;
				}
				UnitFormationStation.Distance = Math2.VerifyClass(groupLead.GetLatitude(), groupLead.GetLongitude(), double_1, double_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100224", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static (Geopoint_Struct InterceptPoint, TimeSpan ETA) ComputeInterceptPoint_BruteForce(Module_Unit.Unit unit_0, float float_0, Module_Unit.Unit unit_1)
	{
		try
		{
			float num = Module_Unit.ClosureSpeed(unit_0, unit_1, float_0, unit_0.CurrentHeading);
			if (!(num <= 0f) && !double.IsNaN(num))
			{
				float num2 = (long)Math.Round(Module_Unit.RangeToUnit_Horiz(unit_0, unit_1) / num * 3600f);
				if (unit_1.CurrentSpeed == 0f)
				{
					return (InterceptPoint: new Geopoint_Struct(unit_1.GetLongitude(), unit_1.GetLatitude()), ETA: TimeSpan.FromSeconds(num2));
				}
				float float_ = num2 / 3600f * unit_1.CurrentSpeed;
				double double_ = 0.0;
				double double_2 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(unit_1.GetLongitude(), unit_1.GetLatitude(), ref double_, ref double_2, float_, unit_1.CurrentHeading);
				return (InterceptPoint: new Geopoint_Struct(double_, double_2), ETA: TimeSpan.FromSeconds(num2));
			}
			return (InterceptPoint: default(Geopoint_Struct), ETA: default(TimeSpan));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100986", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return default((Geopoint_Struct, TimeSpan));
		}
	}

	public static double? CalculateInterceptHeading(double double_0, double double_1, double double_2, Module_Unit.Unit unit_0, float float_0, float float_1 = 1f)
	{
		try
		{
			if (unit_0 == null)
			{
				return null;
			}
			if (!double.IsInfinity(unit_0.GetLatitude()) && !double.IsInfinity(unit_0.GetLongitude()))
			{
				if (unit_0.CurrentSpeed == 0f)
				{
					return Math2.PublishClass(double_0, double_1, unit_0.GetLatitude(), unit_0.GetLongitude());
				}
				float num = Math2.VerifyClass(double_0, double_1, unit_0.GetLatitude(), unit_0.GetLongitude());
				if (Math.Max(float_0, 1f) * num * float_1 > 50000f)
				{
					double? num2 = SphereIntercept.InterceptHeading_deg(unit_0.GetLatitude(), unit_0.GetLongitude(), num, unit_0.CurrentHeading, unit_0.CurrentSpeed, double_0, double_1, float_0);
					if (num2.HasValue && num2.Value != double.MaxValue)
					{
						return Math2.DisableClass(num2.Value);
					}
				}
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(double_1, double_0);
				MercatorProjection.MercatorPixel mercatorPixel2 = new MercatorProjection.MercatorPixel(unit_0.GetLongitude(), unit_0.GetLatitude());
				double? result = PrepareDic(mercatorPixel.x, mercatorPixel.y, double_2, mercatorPixel2.x, mercatorPixel2.y, unit_0.CurrentHeading, unit_0.CurrentSpeed, float_0);
				if (result.HasValue)
				{
					return Math2.DisableClass(result.Value);
				}
				return result;
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100225", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private static double? PrepareDic(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, bool bool_1 = true)
	{
		try
		{
			if (bool_1)
			{
				double_2 *= CSMath.PI_dividedBy_180;
				double_5 *= CSMath.PI_dividedBy_180;
			}
			double num = Math.Atan2(double_3 - double_0, double_4 - double_1);
			double num2 = double_2 - num;
			double num3 = double_5 - num;
			double num4 = 1.0 * Math.Sin(num2);
			double num5 = 1.0 * Math.Cos(num2);
			double num6 = double_6 * Math.Sin(num3);
			double num7 = double_6 * Math.Cos(num3);
			double num8 = Math.Asin((num6 - num4) / double_7);
			double num9 = Math.Cos(num8) * double_7;
			if (!double.IsNaN(num8) && num7 - num5 < num9)
			{
				return Math2.DisableClass(new double?(bool_1 ? ((num8 + num) * 180.0 / 3.14159265358979) : (num8 + num)).Value);
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100226", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private bool ReflectDic(double double_0, double double_1, double double_2, double double_3)
	{
		bool result = false;
		try
		{
			return result = Terrain.LoginWatcher(double_0, double_1, double_2, double_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100227", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void VisitDic(List<Waypoint> list_0, bool bool_1, float float_0, ref bool bool_2, ref Mission.Flight flight_0, ref bool bool_3)
	{
		if (Information.IsNothing(list_0))
		{
			return;
		}
		int count = list_0.Count;
		if (list_0.Count <= 2)
		{
			bool_2 = true;
			return;
		}
		float float_ = ((float_0 <= 0f) ? 0f : 0.15f);
		double latitude;
		double longitude;
		if (!(Information.IsNothing(flight_0) | bool_3) && !Information.IsNothing(flight_0.PrimaryTarget))
		{
			latitude = flight_0.PrimaryTarget.GetLatitude();
			longitude = flight_0.PrimaryTarget.GetLongitude();
		}
		else
		{
			latitude = myUnit.GetLatitude();
			longitude = myUnit.GetLongitude();
		}
		try
		{
			while (!bool_2)
			{
				bool_2 = true;
				Waypoint waypoint = null;
				count = list_0.Count;
				int value = myUnit.Navigator.modelWrapper;
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					Waypoint waypoint2;
					try
					{
						waypoint2 = list_0[i];
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200427", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
					if (waypoint2.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						continue;
					}
					int num2 = list_0.IndexOf(waypoint2);
					if (num2 >= count - 1)
					{
						continue;
					}
					Waypoint waypoint3 = list_0[num2 + 1];
					if (num2 == 0)
					{
						if (!ReflectDic(latitude, longitude, waypoint3.Latitude, waypoint3.Longitude))
						{
							double double_ = latitude;
							double double_2 = longitude;
							double latitude2 = waypoint3.Latitude;
							double longitude2 = waypoint3.Longitude;
							int? nullable_ = value;
							int int_ = 0;
							GeoPoint geoPoint_ = null;
							if (PathLineIsInterrupted(double_, double_2, latitude2, longitude2, bool_1: true, float_, bool_2: false, nullable_, bool_3: true, bool_4: true, bool_5: false, null, ref int_, ref geoPoint_))
							{
								continue;
							}
							waypoint = waypoint2;
							break;
						}
						waypoint = waypoint2;
						break;
					}
					Waypoint waypoint4 = list_0[num2 - 1];
					if (!ReflectDic(waypoint4.Latitude, waypoint4.Longitude, waypoint3.Latitude, waypoint3.Longitude))
					{
						double latitude3 = waypoint4.Latitude;
						double longitude3 = waypoint4.Longitude;
						double latitude4 = waypoint3.Latitude;
						double longitude4 = waypoint3.Longitude;
						int? nullable_2 = value;
						int int_2 = 0;
						GeoPoint geoPoint_2 = null;
						if (PathLineIsInterrupted(latitude3, longitude3, latitude4, longitude4, bool_1: true, float_, bool_2: false, nullable_2, bool_3: true, bool_4: true, bool_5: false, null, ref int_2, ref geoPoint_2))
						{
							continue;
						}
						waypoint = waypoint2;
						break;
					}
					waypoint = waypoint2;
					break;
				}
				if (!Information.IsNothing(waypoint))
				{
					list_0.Remove(waypoint);
					bool_2 = false;
				}
			}
			if (!bool_1)
			{
				return;
			}
			bool_2 = false;
			while (!bool_2)
			{
				bool_2 = true;
				Waypoint waypoint5 = null;
				count = list_0.Count;
				int value2 = myUnit.Navigator.modelWrapper;
				for (int j = count - 1; j >= 0; j += -1)
				{
					Waypoint waypoint6 = list_0[j];
					if (waypoint6.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						continue;
					}
					int num3 = list_0.IndexOf(waypoint6);
					if (num3 >= count - 1)
					{
						continue;
					}
					Waypoint waypoint7 = list_0[num3 + 1];
					if (num3 == 0)
					{
						if (!ReflectDic(latitude, longitude, waypoint7.Latitude, waypoint7.Longitude))
						{
							double double_3 = latitude;
							double double_4 = longitude;
							double latitude5 = waypoint7.Latitude;
							double longitude5 = waypoint7.Longitude;
							int? nullable_3 = value2;
							int int_3 = 0;
							GeoPoint geoPoint_3 = null;
							if (!PathLineIsInterrupted(double_3, double_4, latitude5, longitude5, bool_1: true, float_, bool_2: false, nullable_3, bool_3: true, bool_4: true, bool_5: false, null, ref int_3, ref geoPoint_3))
							{
								waypoint5 = waypoint6;
								break;
							}
							continue;
						}
						waypoint5 = waypoint6;
						break;
					}
					Waypoint waypoint8 = list_0[num3 - 1];
					if (!ReflectDic(waypoint7.Latitude, waypoint7.Longitude, waypoint8.Latitude, waypoint8.Longitude))
					{
						double latitude6 = waypoint7.Latitude;
						double longitude6 = waypoint7.Longitude;
						double latitude7 = waypoint8.Latitude;
						double longitude7 = waypoint8.Longitude;
						int? nullable_4 = value2;
						int int_4 = 0;
						GeoPoint geoPoint_4 = null;
						if (!PathLineIsInterrupted(latitude6, longitude6, latitude7, longitude7, bool_1: true, float_, bool_2: false, nullable_4, bool_3: true, bool_4: true, bool_5: false, null, ref int_4, ref geoPoint_4))
						{
							waypoint5 = waypoint6;
							break;
						}
						continue;
					}
					waypoint5 = waypoint6;
					break;
				}
				if (!Information.IsNothing(waypoint5))
				{
					list_0.Remove(waypoint5);
					bool_2 = false;
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100228", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual List<Waypoint> PathfindingCourse(double double_0, double double_1, double double_2, double double_3, float float_0, bool bool_1, float float_1, ref List<ActiveUnit> list_0, bool bool_2)
	{
		List<Waypoint> list = new List<Waypoint>();
		List<Waypoint> result = null;
		try
		{
			if (!UseCostBasedPathfinder && bool_1)
			{
				float float_2 = ((float_1 <= 0f) ? 5f : 15f);
				GeoPoint geoPoint = LastAccessiblePointOnPath(double_0, double_1, double_2, double_3, float_2, null, float_1, ref list_0);
				GeoPoint geoPoint2 = LastAccessiblePointOnPath(double_2, double_3, double_0, double_1, float_2, null, float_1, ref list_0);
				if (!Information.IsNothing(geoPoint) && !Information.IsNothing(geoPoint2))
				{
					list = PathfindingCourse(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude, float_0, bool_1: false, float_1, ref list_0, bool_2);
					if (!Information.IsNothing(list))
					{
						list.Insert(0, new Waypoint(double_1, double_0, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
						if (myUnit.IsAircraft)
						{
							list.Add(new Waypoint(double_3, double_2, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
						}
						else
						{
							ActiveUnit activeUnit = myUnit;
							int int_ = 0;
							bool bool_3 = true;
							bool bool_4 = true;
							string string_ = "";
							bool bool_5 = false;
							if (activeUnit.CanMoveToThisLocation(double_2, double_3, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_3, bool_4: true, ref bool_4, null, null, ref list_0, float_1, bool_6: false, bool_7: false, ref string_, ref bool_5))
							{
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								double latitude = list[list.Count - 1].Latitude;
								double longitude = list[list.Count - 1].Longitude;
								float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
								int_ = 0;
								GeoPoint geoPoint_ = null;
								if (!navigator.PathLineIsInterrupted(double_2, double_3, latitude, longitude, bool_1: false, 0f, bool_2: true, null, bool_3: true, bool_4: true, bool_5: false, nullable_, ref int_, ref geoPoint_))
								{
									list.Add(new Waypoint(double_3, double_2, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
								}
							}
						}
					}
					result = list;
					return result;
				}
				result = list;
				return result;
			}
			if (myUnit.IsAircraft)
			{
				if (UseCostBasedPathfinder)
				{
					list = Pathfinding.visitorConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, 2f, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: true);
					if (list == null)
					{
						list = Pathfinding.visitorConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, 20f, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: true);
					}
				}
				else
				{
					list = Pathfinding._AttrConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, 2f, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: false);
					if (list == null)
					{
						list = Pathfinding._AttrConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, 20f, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: false);
					}
				}
			}
			else if (Math2.VerifyClass(double_0, double_1, double_2, double_3) < myUnit.ParentScen.Navigation_FinegrainedMaxDistance)
			{
				if (myUnit.ParentScen.ThreadedOpsMustStop)
				{
					PathFindingInProgress = false;
					result = null;
					return result;
				}
				list = (UseCostBasedPathfinder ? Pathfinding.visitorConsumer.SolvePF_Finegrained(myUnit, double_0, double_1, double_2, double_3, float_0, myUnit.ParentScen.Navigation_FinegrainedThresholdDistance, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2) : Pathfinding._AttrConsumer.SolvePF_Finegrained(myUnit, double_0, double_1, double_2, double_3, float_0, myUnit.ParentScen.Navigation_FinegrainedThresholdDistance, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2));
			}
			else
			{
				float float_3 = 20f;
				list = (UseCostBasedPathfinder ? Pathfinding.visitorConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, float_3, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: true) : Pathfinding._AttrConsumer.SolvePF_Coarse(myUnit, double_0, double_1, double_2, double_3, float_0, float_3, float_1, ref list_0, ref Pathfinding_PercentComplete, bool_2, bool_1: false));
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100229", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static float NearestDistanceToLand(double double_0, double double_1, Scenario scenario_0)
	{
		if (Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0) < 0)
		{
			float num = 0.5f;
			double double_2 = 0.0;
			double double_3 = 0.0;
			do
			{
				int num2 = 0;
				do
				{
					Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_2, ref double_3, num, num2);
					if (Terrain.GetElevation(double_3, double_2, bool_0: false, scenario_0) < 0)
					{
						num2++;
						continue;
					}
					return num;
				}
				while (num2 <= 359);
				num += 0.5f;
			}
			while (num <= float.MaxValue);
			return float.MaxValue;
		}
		return 0f;
	}

	private List<Geopoint_Struct> RestartDic(double double_0, double double_1, double double_2, double double_3, double double_4, float float_0, float float_1, ref List<ActiveUnit> list_0)
	{
		List<Geopoint_Struct> result = null;
		try
		{
			List<Geopoint_Struct> list = new List<Geopoint_Struct>();
			float num = (float)(double_4 / 100.0);
			float num2 = (float)double_4;
			float num3 = Math.Max(num, 1f);
			bool flag = num3 >= 0f;
			double double_6 = 0.0;
			double double_7 = 0.0;
			for (float num4 = num; (!flag) ? (num4 >= num2) : (num4 <= num2); num4 += num3)
			{
				short num5 = 180;
				do
				{
					if (!myUnit.ParentScen.ThreadedOpsMustStop)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_3, ref double_6, ref double_7, num4, float_0 + (float)num5);
						ActiveUnit activeUnit = myUnit;
						double double_8 = double_6;
						double double_9 = double_7;
						int int_ = 0;
						bool bool_ = true;
						bool bool_2 = true;
						string string_ = "";
						bool bool_3 = false;
						if (activeUnit.CanMoveToThisLocation(double_8, double_9, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, null, null, ref list_0, float_1, bool_6: true, bool_7: false, ref string_, ref bool_3))
						{
							list.Add(new Geopoint_Struct(double_7, double_6));
						}
						Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_3, ref double_6, ref double_7, num4, float_0 - (float)num5);
						ActiveUnit activeUnit2 = myUnit;
						double double_10 = double_6;
						double double_5 = double_7;
						int_ = 0;
						bool_3 = true;
						bool_2 = true;
						string_ = "";
						bool_ = false;
						if (activeUnit2.CanMoveToThisLocation(double_10, double_5, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_3, bool_4: true, ref bool_2, null, null, ref list_0, float_1, bool_6: true, bool_7: false, ref string_, ref bool_))
						{
							list.Add(new Geopoint_Struct(double_7, double_6));
						}
						num5 += -1;
						continue;
					}
					return result;
				}
				while (num5 >= 0);
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100230", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	protected virtual void PerformPathfinding(Waypoint waypoint_0, ActiveUnit activeUnit_0, Mission.Flight flight_0, bool bool_1, float float_0, double double_0, double double_1, bool bool_2)
	{
		try
		{
			bool bool_6 = false;
			double double_4 = 0.0;
			double double_5 = 0.0;
			float float_ = 0f;
			if (Information.IsNothing(waypoint_0))
			{
				if (Information.IsNothing(activeUnit_0))
				{
					if (!Information.IsNothing(flight_0))
					{
						bool_6 = true;
						if (bool_1)
						{
							double_4 = flight_0.GetReferenceUnit(null).GetLatitude();
							double_5 = flight_0.GetReferenceUnit(null).GetLongitude();
							float_ = flight_0.GetReferenceUnit(null).CurrentHeading;
						}
						else if (Information.IsNothing(flight_0.PrimaryTarget))
						{
							double_4 = flight_0.GetReferenceUnit(null).GetLatitude();
							double_5 = flight_0.GetReferenceUnit(null).GetLongitude();
							float_ = flight_0.GetReferenceUnit(null).CurrentHeading;
						}
						else
						{
							double_4 = flight_0.PrimaryTarget.GetLatitude();
							double_5 = flight_0.PrimaryTarget.GetLongitude();
							float_ = Math2.PublishClass(double_4, double_5, double_0, double_1);
						}
					}
				}
				else
				{
					double_4 = activeUnit_0.GetLatitude();
					double_5 = activeUnit_0.GetLongitude();
					float_ = activeUnit_0.CurrentHeading;
				}
			}
			else
			{
				double_4 = waypoint_0.Latitude;
				double_5 = waypoint_0.Longitude;
				float_ = Math2.PublishClass(double_4, double_5, double_0, double_1);
			}
			List<Waypoint> list = null;
			List<ActiveUnit> list_ = myUnit.DockingOps.OrderClient();
			if (!Information.IsNothing(activeUnit_0) && float_0 == 0.15f)
			{
				ActiveUnit activeUnit = myUnit;
				double double_6 = double_4;
				double double_7 = double_5;
				int int_ = 0;
				bool bool_7 = true;
				bool bool_8 = true;
				float? nullable_ = 0f;
				string string_ = "";
				bool bool_9 = false;
				if (!activeUnit.CanMoveToThisLocation(double_6, double_7, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_7, bool_4: true, ref bool_8, nullable_, null, ref list_, float_0, bool_2, bool_7: false, ref string_, ref bool_9) && !GetNearestAccessibleSpot(double_4, double_5, ref double_4, ref double_5, bool_1: true, bool_2: true, bool_3: false, float_0, ref list_, bool_2))
				{
					return;
				}
				ActiveUnit activeUnit2 = myUnit;
				double double_8 = double_0;
				double double_9 = double_1;
				int_ = 0;
				bool_9 = true;
				bool_8 = true;
				float? nullable_2 = 0f;
				string_ = "";
				bool_7 = false;
				if (!activeUnit2.CanMoveToThisLocation(double_8, double_9, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_9, bool_4: true, ref bool_8, nullable_2, null, ref list_, float_0, bool_2, bool_7: false, ref string_, ref bool_7) && !GetNearestAccessibleSpot(double_0, double_1, ref double_0, ref double_1, bool_1: true, bool_2: true, bool_3: false, float_0, ref list_, bool_2))
				{
					return;
				}
			}
			if (!Information.IsNothing(activeUnit_0))
			{
				double double_10 = double_0;
				double double_11 = double_1;
				int int_2 = 0;
				bool bool_10 = true;
				bool bool_11 = true;
				string string_2 = "";
				bool bool_12 = false;
				if (activeUnit_0.CanMoveToThisLocation(double_10, double_11, ref int_2, bool_0: true, bool_1: true, bool_2: false, ref bool_10, bool_4: true, ref bool_11, null, null, ref list_, float_0, bool_6: false, bool_7: false, ref string_2, ref bool_12))
				{
					activeUnit_0.AI.NavDestination = new Geopoint_Struct(double_1, double_0);
					list = PathfindingCourse(double_4, double_5, double_0, double_1, float_, bool_1: true, float_0, ref list_, bool_6);
					if (Information.IsNothing(list) || list.Count != 0)
					{
						PF_GeneratedCourse = list;
					}
					return;
				}
			}
			if (!Information.IsNothing(flight_0) && !Information.IsNothing(flight_0.GetReferenceUnit(null)))
			{
				ActiveUnit referenceUnit = flight_0.GetReferenceUnit(null);
				double double_2 = double_0;
				double double_3 = double_1;
				int int_3 = 0;
				bool bool_3 = true;
				bool bool_4 = true;
				string string_3 = "";
				bool bool_5 = false;
				if (referenceUnit.CanMoveToThisLocation(double_2, double_3, ref int_3, bool_0: true, bool_1: true, bool_2: false, ref bool_3, bool_4: true, ref bool_4, null, null, ref list_, float_0, bool_6: false, bool_7: false, ref string_3, ref bool_5))
				{
					list = flight_0.GetReferenceUnit(null).Navigator.PathfindingCourse(double_4, double_5, double_0, double_1, float_, bool_1: true, float_0, ref list_, bool_6);
					if (Information.IsNothing(list) || list.Count != 0)
					{
						PF_GeneratedCourse = list;
					}
					return;
				}
			}
			try
			{
				double num = 0.0;
				double num2 = 0.0;
				num = Math2.VerifyClass(double_4, double_5, double_0, double_1);
				num2 = Math2.CancelClass(double_4, double_5, double_0, double_1);
				if (num <= 0.0)
				{
					return;
				}
				foreach (Geopoint_Struct item in RestartDic(double_4, double_5, double_0, double_1, num, float_, float_0, ref list_))
				{
					if (GeoPoint.RangeToPoint_Horiz_Angular(item.Longitude, item.Latitude, double_1, double_0) <= num2)
					{
						if (!Information.IsNothing(activeUnit_0))
						{
							activeUnit_0.AI.NavDestination = item;
						}
						list = PathfindingCourse(double_4, double_5, item.Latitude, item.Longitude, float_, bool_1: true, float_0, ref list_, bool_6);
						if (!Information.IsNothing(list))
						{
							PF_GeneratedCourse = list;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200010", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100231", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public GeoPoint LastAccessiblePointOnPath(double double_0, double double_1, double double_2, double double_3, float float_0, int? nullable_0, float float_1, ref List<ActiveUnit> list_0)
	{
		GeoPoint result = null;
		try
		{
			double double_4 = double_0;
			double double_5 = double_1;
			float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
			if (!float.IsNaN(num) && num != 0f)
			{
				float num2 = (myUnit.IsAircraft ? (UseCostBasedPathfinder ? Pathfinding.visitorConsumer.DegreeInterval_Coarse : Pathfinding._AttrConsumer.DegreeInterval_Coarse) : ((num < myUnit.ParentScen.Navigation_FinegrainedMaxDistance) ? (UseCostBasedPathfinder ? Pathfinding.visitorConsumer.DegreeInterval_Finegrained : Pathfinding._AttrConsumer.DegreeInterval_Finegrained) : (UseCostBasedPathfinder ? Pathfinding.visitorConsumer.DegreeInterval_Coarse : Pathfinding._AttrConsumer.DegreeInterval_Coarse)));
				ExWorldWind.Angle angle_ = default(ExWorldWind.Angle);
				angle_.Degrees = double_1;
				ExWorldWind.Angle angle_2 = default(ExWorldWind.Angle);
				angle_2.Degrees = double_0;
				ExWorldWind.Angle angle_3 = default(ExWorldWind.Angle);
				angle_3.Degrees = double_3;
				ExWorldWind.Angle angle_4 = default(ExWorldWind.Angle);
				angle_4.Degrees = double_2;
				ExWorldWind.Angle angle_5 = default(ExWorldWind.Angle);
				ExWorldWind.Angle angle_6 = default(ExWorldWind.Angle);
				ExWorldWind.Angle angle_7 = World.ApproxAngularDistance(angle_2, angle_, angle_4, angle_3);
				float num3 = (float)angle_7.Degrees;
				if (num3 < num2 * 2f)
				{
					result = null;
					return result;
				}
				int num4 = (int)Math.Round(num3 / num2);
				for (int i = 1; i <= num4; i++)
				{
					World.smethod_0(num2 * (float)i / num3, angle_2, angle_, angle_4, angle_3, angle_7, out angle_6, out angle_5);
					double degrees = angle_6.Degrees;
					double degrees2 = angle_5.Degrees;
					_ = Debugger.IsAttached;
					ActiveUnit activeUnit = myUnit;
					int int_ = 0;
					bool bool_ = true;
					bool bool_2 = true;
					float? nullable_ = nullable_0;
					string string_ = "";
					bool bool_3 = false;
					if (!activeUnit.CanMoveToThisLocation(degrees, degrees2, ref int_, bool_0: true, bool_1: true, bool_2: false, ref bool_, bool_4: true, ref bool_2, nullable_, null, ref list_0, float_1, bool_6: false, bool_7: false, ref string_, ref bool_3))
					{
						break;
					}
					double_4 = degrees;
					double_5 = degrees2;
				}
				float num5 = Math2.VerifyClass(double_0, double_1, double_4, double_5);
				float float_2 = ((num5 <= float_0) ? ((float)((double)num5 * 0.2)) : (num5 - float_0));
				float float_3 = Math2.PublishClass(double_0, double_1, double_2, double_3);
				double double_6 = 0.0;
				double double_7 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref double_6, ref double_7, float_2, float_3);
				result = new GeoPoint(double_6, double_7);
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100232", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool TestDic(double double_0, double double_1, double double_2, double double_3, float float_0)
	{
		Tuple<double, double> tuple_ = new Tuple<double, double>(MathFunctions.DestroyRequest(double_0), MathFunctions.DestroyRequest(double_1));
		Tuple<double, double> tuple_2 = new Tuple<double, double>(MathFunctions.DestroyRequest(double_2), MathFunctions.DestroyRequest(double_3));
		double num = Math.Min(MathFunctions.DestroyRequest(double_0), MathFunctions.DestroyRequest(double_2));
		double num2 = Math.Max(MathFunctions.DestroyRequest(double_0), MathFunctions.DestroyRequest(double_2));
		double num3 = Math.Min(MathFunctions.DestroyRequest(double_1), MathFunctions.DestroyRequest(double_3));
		double num4 = Math.Max(MathFunctions.DestroyRequest(double_1), MathFunctions.DestroyRequest(double_3));
		foreach (NoNavZone noNavZone in myUnit.GetUnitSide().NoNavZones)
		{
			if (noNavZone.Area.Count == 0 || !noNavZone.GetAffectsThisUnit(myUnit))
			{
				continue;
			}
			List<Tuple<Tuple<double, double>, Tuple<double, double>>> list;
			if (float_0 == 0.2f)
			{
				if (noNavZone.Area_GeoPoints_020deg_Buffered.Count == 0 || noNavZone.FlushDescriptor(noNavZone.Area_RefPoints_020deg_ChangeCheck))
				{
					noNavZone.CalculateAreaWithThresholdAdded(float_0, ref noNavZone.Area_GeoPoints_020deg_Buffered, ref noNavZone.Area_RefPoints_020deg_ChangeCheck);
				}
				list = noNavZone.Area_GeoPoints_020deg_Buffered.Take(noNavZone.Area_GeoPoints_020deg_Buffered.Count - 1).Zip(noNavZone.Area_GeoPoints_020deg_Buffered.Skip(1), (Geopoint_Struct a, Geopoint_Struct b) => new Tuple<Tuple<double, double>, Tuple<double, double>>(new Tuple<double, double>(MathFunctions.DestroyRequest(a.Latitude), MathFunctions.DestroyRequest(a.Longitude)), new Tuple<double, double>(MathFunctions.DestroyRequest(b.Latitude), MathFunctions.DestroyRequest(b.Longitude)))).ToList();
				if (list.Count > 0)
				{
					list.Add(new Tuple<Tuple<double, double>, Tuple<double, double>>(list.Last().Item2, list.First().Item1));
				}
			}
			else if (float_0 == 0.15f)
			{
				if (noNavZone.Area_GeoPoints_015deg_Buffered.Count == 0 || noNavZone.FlushDescriptor(noNavZone.Area_RefPoints_015deg_ChangeCheck))
				{
					noNavZone.CalculateAreaWithThresholdAdded(float_0, ref noNavZone.Area_GeoPoints_015deg_Buffered, ref noNavZone.Area_RefPoints_015deg_ChangeCheck);
				}
				list = noNavZone.Area_GeoPoints_015deg_Buffered.Take(noNavZone.Area_GeoPoints_015deg_Buffered.Count - 1).Zip(noNavZone.Area_GeoPoints_015deg_Buffered.Skip(1), (Geopoint_Struct a, Geopoint_Struct b) => new Tuple<Tuple<double, double>, Tuple<double, double>>(new Tuple<double, double>(MathFunctions.DestroyRequest(a.Latitude), MathFunctions.DestroyRequest(a.Longitude)), new Tuple<double, double>(MathFunctions.DestroyRequest(b.Latitude), MathFunctions.DestroyRequest(b.Longitude)))).ToList();
				if (list.Count > 0)
				{
					list.Add(new Tuple<Tuple<double, double>, Tuple<double, double>>(list.Last().Item2, list.First().Item1));
				}
			}
			else
			{
				list = new List<Tuple<Tuple<double, double>, Tuple<double, double>>>();
				int num5 = noNavZone.Area.Count - 2;
				for (int i = 0; i <= num5; i++)
				{
					ReferencePoint referencePoint = noNavZone.Area[i];
					ReferencePoint referencePoint2 = noNavZone.Area[i + 1];
					list.Add(new Tuple<Tuple<double, double>, Tuple<double, double>>(new Tuple<double, double>(MathFunctions.DestroyRequest(referencePoint.Latitude), MathFunctions.DestroyRequest(referencePoint.Longitude)), new Tuple<double, double>(MathFunctions.DestroyRequest(referencePoint2.Latitude), MathFunctions.DestroyRequest(referencePoint2.Longitude))));
				}
				list.Add(new Tuple<Tuple<double, double>, Tuple<double, double>>(list.Last().Item2, list.First().Item1));
			}
			foreach (Tuple<Tuple<double, double>, Tuple<double, double>> item in list)
			{
				Tuple<double, double> tuple = Math2.ManageClass(tuple_, tuple_2, item.Item1, item.Item2);
				if (!Information.IsNothing(tuple))
				{
					double num6 = Math.Min(item.Item1.Item1, item.Item2.Item1);
					double num7 = Math.Max(item.Item1.Item1, item.Item2.Item1);
					double num8 = Math.Min(item.Item1.Item2, item.Item2.Item2);
					double num9 = Math.Max(item.Item1.Item2, item.Item2.Item2);
					if (tuple.Item1 < num2 && tuple.Item1 > num && tuple.Item2 < num4 && tuple.Item2 > num3 && tuple.Item1 < num7 && tuple.Item1 > num6 && tuple.Item2 < num9 && !(tuple.Item2 <= num8))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual bool PathLineIsInterrupted(double double_0, double double_1, double double_2, double double_3, bool bool_1, float float_0, bool bool_2, int? nullable_0, bool bool_3, bool bool_4, bool bool_5, float? nullable_1, ref int int_0, ref GeoPoint geoPoint_0)
	{
		try
		{
			bool bool_8 = false;
			bool bool_9 = false;
			if (bool_2)
			{
				ActiveUnit activeUnit = myUnit;
				double latitude = myUnit.GetLatitude();
				double longitude = myUnit.GetLongitude();
				int int_ = 0;
				bool bool_10 = false;
				float? nullable_2 = 0f;
				List<ActiveUnit> list_ = null;
				string string_ = "";
				bool bool_11 = false;
				if (!(activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_3, bool_4, bool_2: false, ref bool_10, bool_4: true, ref bool_8, nullable_2, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_11) || bool_8))
				{
					return false;
				}
				if (bool_8)
				{
					int_0 = 1;
					if (geoPoint_0 != null)
					{
						geoPoint_0.Latitude = myUnit.GetLatitude();
						geoPoint_0.Longitude = myUnit.GetLongitude();
					}
					return true;
				}
			}
			if (TestDic(double_0, double_1, double_2, double_3, float_0))
			{
				return true;
			}
			float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
			if (!float.IsNaN(num) && num != 0f)
			{
				if (Information.IsNothing(nullable_1))
				{
					nullable_1 = (myUnit.IsAircraft ? (UseCostBasedPathfinder ? new float?(Pathfinding.visitorConsumer.DegreeInterval_Coarse) : new float?(Pathfinding._AttrConsumer.DegreeInterval_Coarse)) : ((num < myUnit.ParentScen.Navigation_FinegrainedMaxDistance) ? (UseCostBasedPathfinder ? new float?(Pathfinding.visitorConsumer.DegreeInterval_Finegrained) : new float?(Pathfinding._AttrConsumer.DegreeInterval_Finegrained)) : (UseCostBasedPathfinder ? new float?(Pathfinding.visitorConsumer.DegreeInterval_Coarse) : new float?(Pathfinding._AttrConsumer.DegreeInterval_Coarse))));
				}
				if (Information.IsNothing(nullable_1))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return true;
				}
				bool result = false;
				ExWorldWind.Angle angle_ = default(ExWorldWind.Angle);
				angle_.Degrees = double_1;
				ExWorldWind.Angle angle_2 = default(ExWorldWind.Angle);
				angle_2.Degrees = double_0;
				ExWorldWind.Angle angle_3 = default(ExWorldWind.Angle);
				angle_3.Degrees = double_3;
				ExWorldWind.Angle angle_4 = default(ExWorldWind.Angle);
				angle_4.Degrees = double_2;
				ExWorldWind.Angle angle_5 = World.ApproxAngularDistance(angle_2, angle_, angle_4, angle_3);
				float num2 = (float)angle_5.Degrees;
				float num3 = num2;
				float? num4 = nullable_1 * 2f;
				if ((num4.HasValue ? new bool?(num3 < num4.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					return false;
				}
				int num5 = (int)Math.Round((num2 / nullable_1).Value);
				List<ActiveUnit> list_2 = myUnit.DockingOps.OrderClient();
				bool bool_6 = (myUnit.IsShip && !((Ship)myUnit).IsIcebreaker) || (myUnit.IsSubmarine && !((Submarine)myUnit).IsNuke);
				ExWorldWind.Angle angle_6 = default(ExWorldWind.Angle);
				ExWorldWind.Angle angle_7 = default(ExWorldWind.Angle);
				int int_2 = num5;
				for (int i = 1; i <= int_2; i++)
				{
					World.smethod_0(nullable_1.Value * (float)i / num2, angle_2, angle_, angle_4, angle_3, angle_5, out angle_7, out angle_6);
					double degrees = angle_7.Degrees;
					double degrees2 = angle_6.Degrees;
					ActiveUnit activeUnit2 = myUnit;
					int int_3 = 0;
					float? nullable_3 = nullable_0;
					string string_2 = "";
					bool bool_7 = false;
					if (!activeUnit2.CanMoveToThisLocation(degrees, degrees2, ref int_3, bool_3, bool_4, bool_5, ref bool_9, bool_6, ref bool_8, nullable_3, null, ref list_2, float_0, bool_6: false, bool_7: false, ref string_2, ref bool_7))
					{
						if (bool_8)
						{
							int_0++;
						}
						if (bool_9)
						{
							int_0 += 2;
						}
						if (geoPoint_0 != null)
						{
							geoPoint_0.Latitude = degrees;
							geoPoint_0.Longitude = degrees2;
						}
						result = true;
						break;
					}
				}
				return result;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100233", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static bool ValidateArea(ref List<ReferencePoint> list_0, ref string string_0, Side side_0, Scenario scenario_0, string string_1)
	{
		try
		{
			if (list_0 != null && list_0.Count >= 3)
			{
				int count = list_0.Count;
				string text = (Information.IsNothing(side_0) ? "" : side_0.Name);
				Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(list_0[0].Latitude, list_0[0].Longitude);
				Coordinate[] array = new Coordinate[count + 1];
				bool flag = false;
				int num = count - 1;
				double double_ = 0.0;
				double double_2 = 0.0;
				for (int i = 0; i <= num; i++)
				{
					if (tLocalTM.CountInterruptibleQueue(list_0[i].Latitude, list_0[i].Longitude, ref double_, ref double_2, bool_0: true))
					{
						array[i] = new Coordinate(double_, double_2);
						continue;
					}
					flag = true;
					break;
				}
				if (flag)
				{
					if (Math2.PolygonCrossesAntimeridian(ref list_0))
					{
						int num2 = count - 1;
						for (int j = 0; j <= num2; j++)
						{
							array[j] = new Coordinate(Math2.VisitClass(list_0[j].Longitude + 180.0), list_0[j].Latitude);
						}
					}
					else
					{
						int num3 = count - 1;
						for (int k = 0; k <= num3; k++)
						{
							double_ = StubDefinitionSpec.PushList(list_0[k].Longitude);
							double_2 = StubDefinitionSpec.InvokeList(list_0[k].Latitude);
							array[k] = new Coordinate(double_, double_2);
						}
					}
				}
				array[count] = array[0];
				Polygon polygon = new Polygon(new LinearRing(array));
				try
				{
					if (polygon.IsValid)
					{
						string_0 = "";
						return true;
					}
					if (string.IsNullOrEmpty(string_1) && string.IsNullOrEmpty(text))
					{
						string_0 = "警告！区域验证失败！构成该区域的多边形自身交叉，这意味着它是无效的！这将导致AI导航出现问题。请检查该区域的形状，并确保它在任何时候都不会穿过自身！";
					}
					else if (string.IsNullOrEmpty(text))
					{
						string_0 = "警告！区域验证" + string_1 + "失败了！构成该区域的多边形自身交叉，这意味着它是无效的！这将导致AI导航出现问题。请检查该区域的形状，并确保它在任何时候都不会穿过自身！";
					}
					else
					{
						string_0 = "警告！区域验证" + string_1 + "属于分方" + text + "失败了！构成该区域的多边形自身交叉，这意味着它是无效的！这将导致AI导航出现问题。请检查该区域的形状，并确保它在任何时候都不会穿过自身！";
					}
					return false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200324", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (string.IsNullOrEmpty(string_1) && string.IsNullOrEmpty(side_0.Name))
					{
						string_0 = "警告！区域验证失败！这将导致AI导航器出现问题。请检查该区域的形状，并确保它是有效的。";
					}
					else if (string.IsNullOrEmpty(side_0.Name))
					{
						string_0 = "警告！区域验证" + string_1 + "失败了！这将导致AI导航出现问题。请检查该区域的形状，并确保它是有效的。";
					}
					else
					{
						string_0 = "警告！区域验证" + string_1 + "属于分方" + text + "失败了！这将导致AI导航出现问题。请检查该区域的形状，并确保它是有效的。";
					}
					ProjectData.ClearProjectError();
					return false;
				}
			}
			return true;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101270", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[CompilerGenerated]
	private float StopDic(Waypoint waypoint_0)
	{
		return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude);
	}

	[CompilerGenerated]
	private float CancelDic(Waypoint waypoint_0)
	{
		return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint_0.Latitude, waypoint_0.Longitude);
	}

	[CompilerGenerated]
	private float VerifyDic(ReferencePoint referencePoint_0)
	{
		return Module_Unit.RangeToPoint_Horiz(myUnit, referencePoint_0.Latitude, referencePoint_0.Longitude);
	}

	[CompilerGenerated]
	private double ListDic(ReferencePoint referencePoint_0)
	{
		ActiveUnit unit_ = myUnit;
		ReferencePoint referencePoint;
		double double_ = (referencePoint = referencePoint_0).Latitude;
		ReferencePoint referencePoint2;
		double double_2 = (referencePoint2 = referencePoint_0).Longitude;
		double result = Module_Unit.RangeToPoint_Horiz_Angular(unit_, ref double_, ref double_2);
		referencePoint2.Longitude = double_2;
		referencePoint.Latitude = double_;
		return result;
	}
}
