using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Weapon_Navigator : ActiveUnit_Navigator
{
	internal Geopoint_Struct? _ProccesorReader;

	private Weapon m_StrategyReader;

	protected Weapon myWeapon
	{
		get
		{
			if (m_StrategyReader == null)
			{
				m_StrategyReader = (Weapon)myUnit;
			}
			return m_StrategyReader;
		}
	}

	public new Waypoint[] PlottedCourse
	{
		get
		{
			return base.PlottedCourse;
		}
		set
		{
			base.PlottedCourse = value;
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Weapon_Navigator");
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
			if (ManualPlotOverride)
			{
				xmlWriter_0.WriteElementString("MPO", "True");
			}
			if (myUnit.IsGroupMember())
			{
				xmlWriter_0.WriteElementString("FS_B", XmlConvert.ToString(base.UnitFormationStation.Bearing));
				xmlWriter_0.WriteElementString("FS_D", XmlConvert.ToString(base.UnitFormationStation.Distance));
				xmlWriter_0.WriteElementString("FS_BT", XmlConvert.ToString((byte)base.UnitFormationStation.BearingType));
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
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100983", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public new static Weapon_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Weapon_Navigator weapon_Navigator = new Weapon_Navigator(ref activeUnit_0);
			weapon_Navigator.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							weapon_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							weapon_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						weapon_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "FS_B":
					case "FormationStation_Bearing":
						weapon_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "MPO":
					case "ManualPlotOverride":
						weapon_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "FS_BT":
						weapon_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PC":
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_2 = (XmlNode)enumerator2.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref weapon_Navigator._PlottedCourse, theAC);
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
					case "FS_D":
					case "FormationStation_Distance":
						weapon_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						weapon_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_0);
						break;
					}
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
			return weapon_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100984", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon_Navigator result = new Weapon_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void FollowPlottedCourse(float float_0)
	{
		try
		{
			bool bool_ = false;
			bool bool_2 = false;
			CheckIfReachedWaypoint(float_0, ref bool_, ref bool_2);
			HeadToFirstWaypoint(float_0);
			if (myUnit.configurationVal && (int)myUnit.ThrottleSetting < 2)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100985", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool HaveReachedPoint(double double_0, double double_1, float float_0, bool bool_1 = true, bool bool_2 = false, float? nullable_0 = null)
	{
		return base.HaveReachedPoint(double_0, double_1, float_0, bool_1);
	}

	private float InterruptDescriptor(double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		Geopoint_Struct geopoint_Struct = new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude());
		Geopoint_Struct geopoint_Struct_ = new Geopoint_Struct(double_1, double_0, float_0);
		float num = geopoint_Struct.RangeToPoint_Slant(geopoint_Struct_);
		Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, float_5 / 360000f, float_4);
		geopoint_Struct.Altitude += float_6 * 1852f / 360000f;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, float_2 / 360000f, float_1);
		geopoint_Struct_.Altitude += float_3 * 1852f / 360000f;
		float num2 = geopoint_Struct.RangeToPoint_Slant(geopoint_Struct_);
		return (num - num2) * 360000f;
	}

	internal Geopoint_Struct RemoveDescriptor(Contact contact_0, bool bool_1 = false)
	{
		if (!bool_1 && _ProccesorReader.HasValue)
		{
			return _ProccesorReader.Value;
		}
		Weapon_Kinematics kinematics = myWeapon.Kinematics;
		try
		{
			float num = kinematics.GetMaximumSpeed();
			bool flag = contact_0.ActualUnit.IsWeapon && ((Weapon)contact_0.ActualUnit).IsBallisticTargetManeuvering();
			bool flag2 = myUnit.CurrentSpeed < num && (!myWeapon.UsesBoostCoastModel.Value || myWeapon.TimeSinceLaunch <= (float)myWeapon.TotalBurnTime);
			DateTime dateTime_ = myWeapon.ParentScen.Time;
			if (myWeapon._FacadeReader)
			{
				dateTime_ = dateTime_.AddSeconds(myWeapon.TimeSinceLaunch);
			}
			float num12 = Module_Unit.RangeToUnit_Slant(myUnit, contact_0);
			float float_;
			float float_2;
			if (flag2)
			{
				float num16 = Math.Max(myUnit.GetCurrentAltitude(), kinematics.GetMinimumAltitude());
				float num17 = Module_Unit.RangeToUnit_Horiz(myUnit, contact_0) / num12;
				float num18 = (contact_0.GetCurrentAltitude() - num16) * 0.000539957f / num12;
				float_ = num * num17;
				float_2 = num * num18;
			}
			else
			{
				float_ = Module_Unit.CalcTokenizer(myWeapon);
				float_2 = myUnit.CurrentSpeed * (float)Math2.FillClass(myUnit.Attitude_Pitch);
			}
			float num19 = Module_Unit.CalcTokenizer(contact_0.ActualUnit);
			float num20 = contact_0.ActualUnit.CurrentSpeed * (float)Math2.FillClass(contact_0.ActualUnit.Attitude_Pitch);
			bool flag3 = false;
			int num21 = 0;
			float num22 = 0f;
			float num2 = 0f;
			while (true)
			{
				num21++;
				float num3 = InterruptDescriptor(contact_0.GetLatitude(), contact_0.GetLongitude(), contact_0.GetCurrentAltitude(), contact_0.CurrentHeading, num19, num20, myUnit.CurrentHeading, float_, float_2);
				if (!(num3 <= 0f))
				{
					num22 = num2;
					num2 = num12 / num3 * 3600f;
					if (!(num2 >= 1f))
					{
						break;
					}
					if (myWeapon._FacadeReader)
					{
						int num4 = 0;
						num4 = (myWeapon.FlightEndurance.HasValue ? myWeapon.FlightEndurance.Value : myWeapon.FuelCapacityCurrent);
						if (!(num2 + myWeapon.TimeSinceLaunch <= (float)num4))
						{
							_ProccesorReader = default(Geopoint_Struct);
							return _ProccesorReader.Value;
						}
					}
					if (!flag)
					{
						if (contact_0.mapperObserver.Length == 0)
						{
							contact_0.mapperObserver = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(contact_0, myUnit.ParentScen);
						}
						Geopoint_Struct geopoint_Struct_ = new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude());
						DateTime dateTime_2 = dateTime_.AddSeconds(num2);
						TrajectoryPoint trajectoryPoint_ = new TrajectoryPoint(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude(), dateTime_);
						TrajectoryPoint? exactPointAtTime = TrajectoryPoint.GetExactPointAtTime(contact_0.mapperObserver, trajectoryPoint_, dateTime_2);
						if (exactPointAtTime.HasValue)
						{
							Geopoint_Struct geopoint_Struct_2 = exactPointAtTime.Value.FillWatcher();
							num19 = Math2.StartClass(ref geopoint_Struct_, ref geopoint_Struct_2) / num2 * 3600f;
							num20 = (geopoint_Struct_2.Altitude - geopoint_Struct_.Altitude) * 0.000539957f / num2 * 3600f;
							flag3 = true;
						}
					}
					if (flag2)
					{
						GeoPoint geoPoint = new GeoPoint(contact_0.GetLongitude(), contact_0.GetLatitude());
						double longitude = contact_0.GetLongitude();
						double latitude = contact_0.GetLatitude();
						double double_ = geoPoint.Longitude;
						double double_2 = geoPoint.Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, num19 / 3600f * num2, contact_0.CurrentHeading);
						geoPoint.Latitude = double_2;
						geoPoint.Longitude = double_;
						geoPoint.Altitude = contact_0.GetCurrentAltitude() + num20 * 1852f / 3600f * num2;
						float num5 = Module_Unit.RangeToPoint_Slant(myUnit, geoPoint);
						float num6 = Module_Unit.RangeToPoint_Horiz(myUnit, geoPoint) / num5;
						float num7 = (geoPoint.Altitude - myUnit.GetCurrentAltitude()) * 0.000539957f / num5;
						float num8 = myUnit.CurrentSpeed;
						float num9 = myUnit.CurrentSpeed;
						float num10 = myUnit.GetCurrentAltitude();
						float num11 = num;
						float num13 = num2;
						for (float num14 = 1f; num14 <= num13; num14 += 1f)
						{
							num10 += num9 * num7 / 3600f * 1852f;
							num11 = kinematics.GetMaximumSpeed(num10);
							if (num9 < num11)
							{
								num9 += kinematics.Acceleration_Actual(ActiveUnit.Throttle.Cruise, num10, num11);
							}
							if (num9 > num11)
							{
								num9 = num11;
							}
							num8 += num9;
						}
						num8 /= num2;
						float_ = num8 * num6;
						float_2 = num8 * num7;
						flag3 = true;
					}
					if (flag3 && Math.Abs(num22 - num2) >= 1f && num21 < 3)
					{
						continue;
					}
					if (flag)
					{
						Geopoint_Struct result = default(Geopoint_Struct);
						float float_3 = Module_Unit.CalcTokenizer(contact_0.ActualUnit) / 3600f * num2;
						float num15 = (float)((double)(num20 / 3600f) * 1852.0) * num2;
						Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref result.Longitude, ref result.Latitude, float_3, contact_0.CurrentHeading);
						result.Altitude = contact_0.GetCurrentAltitude() + num15;
						if (result.Altitude >= 0f && (myWeapon.MaxTargetAlt_ASL <= 0f || result.Altitude <= myWeapon.MaxTargetAlt_ASL))
						{
							return result;
						}
						_ProccesorReader = default(Geopoint_Struct);
						return _ProccesorReader.Value;
					}
					DateTime dateTime = dateTime_.AddSeconds(num2);
					if (contact_0.mapperObserver.Length == 0)
					{
						contact_0.mapperObserver = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(contact_0, myWeapon.ParentScen);
					}
					if (DateTime.Compare(contact_0.mapperObserver[contact_0.mapperObserver.Length - 1].TimeZulu, dateTime) < 0)
					{
						_ProccesorReader = default(Geopoint_Struct);
						return _ProccesorReader.Value;
					}
					TrajectoryPoint trajectoryPoint_2 = new TrajectoryPoint(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude(), dateTime_);
					TrajectoryPoint? exactPointAtTime2 = TrajectoryPoint.GetExactPointAtTime(contact_0.mapperObserver, trajectoryPoint_2, dateTime);
					if (exactPointAtTime2.HasValue)
					{
						if (!(exactPointAtTime2.Value.Altitude <= myUnit.Kinematics.GetMaximumAltitude()))
						{
							return default(Geopoint_Struct);
						}
						_ProccesorReader = exactPointAtTime2.Value.FillWatcher();
					}
					else
					{
						_ProccesorReader = new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude());
					}
					return _ProccesorReader.Value;
				}
				_ProccesorReader = default(Geopoint_Struct);
				return _ProccesorReader.Value;
			}
			_ProccesorReader = new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude());
			return _ProccesorReader.Value;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Geopoint_Struct result2 = new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude());
			ProjectData.ClearProjectError();
			return result2;
		}
	}

	public override void ClearPlottedCourse()
	{
		ArrayExtensions.Clear(ref _PlottedCourse);
		ArrayExtensions.Clear(ref _PlottedCourse_PrePlanned);
	}

	public Geopoint_Struct ComputeInterceptPoint_BruteForce(float float_0, Contact contact_0, float? nullable_0)
	{
		try
		{
			if (contact_0.CurrentSpeed == 0f && Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen) == 0f)
			{
				return new Geopoint_Struct(contact_0.GetLongitude(), contact_0.GetLatitude(), contact_0.GetCurrentAltitude());
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = Module_Unit.ClosureSpeed(myUnit, contact_0, float_0, myUnit.CurrentHeading);
			}
			float? num = nullable_0;
			if (!(num.HasValue ? new bool?(num.GetValueOrDefault() <= 0f) : null).GetValueOrDefault() && !double.IsNaN(nullable_0.Value))
			{
				bool num2 = contact_0.ActualUnit != null && contact_0.ActualUnit.SupportsAttitude_Pitch && Math.Abs(contact_0.ActualUnit.Attitude_Pitch) > 60f;
				float num3 = (long)Math.Round((Module_Unit.RangeToUnit_Horiz(myUnit, contact_0) / nullable_0 * 3600f).Value);
				_ = contact_0.CurrentSpeed;
				double double_ = 0.0;
				double double_2 = 0.0;
				float float_ = (num2 ? (num3 / 3600f * Module_Unit.CalcTokenizer(contact_0.ActualUnit)) : (num3 / 3600f * contact_0.CurrentSpeed));
				Geodesic_EdWilliams.CalcPoint_Williams(contact_0.GetLongitude(), contact_0.GetLatitude(), ref double_, ref double_2, float_, contact_0.CurrentHeading);
				float num4 = (contact_0.IsBallisticTarget() ? (contact_0.GetCurrentAltitude() + Module_Unit.RateTokenizer(contact_0, myUnit.ParentScen) * num3) : contact_0.GetCurrentAltitude());
				if (num4 < (float)Terrain.GlobalMaxTerrainElevation)
				{
					short elevation = Terrain.GetElevation(double_2, double_, bool_0: false, myUnit.ParentScen);
					if (num4 < (float)elevation)
					{
						num4 = (float)((double)elevation + 0.01);
						if (myWeapon.IsMissile && num4 < 0f)
						{
							num4 = 0.01f;
						}
					}
				}
				return new Geopoint_Struct(double_, double_2, num4);
			}
			return default(Geopoint_Struct);
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
			return default(Geopoint_Struct);
		}
	}

	internal (bool result, double ETA) FindDescriptor(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(myUnit.AI.PrimaryTarget))
		{
			return (result: false, ETA: 0.0);
		}
		float num = Module_Unit.RangeToUnit_Horiz(activeUnit_0, myUnit.AI.PrimaryTarget);
		float num2 = Module_Unit.BearingToUnit_True(activeUnit_0, myUnit.AI.PrimaryTarget);
		float maxRangeForThisTarget = ((Weapon)myUnit).GetMaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, bool_0: false, activeUnit_0.Doctrine, bool_1: false);
		List<Waypoint> list = new List<Waypoint>();
		LockRandom lockRandom_ = GameGeneral.LockRandom_0;
		if (myUnit.AI.PrimaryTarget.ActualUnit != null)
		{
			if (myUnit.AI.PrimaryTarget.IsSurfaceContact && (myWeapon.IsMissile & myWeapon.SupportsWaypoints))
			{
				try
				{
					if (myUnit.Doctrine.GetUseWPMissileOnASuW(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value != Doctrine._UseWpMissileAgainstShips.Yes)
					{
						AddWaypoint(new Waypoint(myUnit.AI.PrimaryTarget.GetLongitude(), myUnit.AI.PrimaryTarget.GetLatitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (myWeapon.FiringParent != null && myWeapon.FiringParent.Doctrine.GetUseWPMissileOnASuW(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false).Value != Doctrine._UseWpMissileAgainstShips.Yes)
					{
						AddWaypoint(new Waypoint(myUnit.AI.PrimaryTarget.GetLongitude(), myUnit.AI.PrimaryTarget.GetLatitude(), myUnit.AI.PrimaryTarget.GetCurrentAltitude(), Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
					ProjectData.ClearProjectError();
				}
			}
			if (PlottedCourse.Length != 0)
			{
				return SetDescriptor(activeUnit_0, myUnit.AI.PrimaryTarget);
			}
			int num3 = 1;
			double double_ = 0.0;
			double double_2 = 0.0;
			do
			{
				int num4 = ((!activeUnit_0.IsAircraft) ? lockRandom_.Next(-80, 81) : lockRandom_.Next(-45, 46));
				int num5 = lockRandom_.Next(1, (int)Math.Round(num / 2f));
				Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), ref double_, ref double_2, num5, Math2.UpdateClass(num2 + (float)num4));
				float num6 = Module_Unit.RangeToPoint_Horiz(activeUnit_0, double_2, double_);
				float num7 = Module_Unit.RangeToPoint_Horiz(myUnit.AI.PrimaryTarget, double_2, double_);
				if (num6 + num7 < maxRangeForThisTarget)
				{
					list.Add(new Waypoint(double_, double_2, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
				num3++;
			}
			while (num3 <= 10000);
			if (list.Count == 0)
			{
				return SetDescriptor(activeUnit_0, myUnit.AI.PrimaryTarget);
			}
			if (list.Count == 1)
			{
				AddWaypoint(list[0]);
			}
			else
			{
				Waypoint waypoint_ = list[lockRandom_.Next(0, list.Count)];
				AddWaypoint(waypoint_);
			}
		}
		AddWaypoint(new Waypoint(myUnit.AI.PrimaryTarget.GetLongitude(), myUnit.AI.PrimaryTarget.GetLatitude(), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
		return SetDescriptor(activeUnit_0, myUnit.AI.PrimaryTarget);
	}

	private (bool, double) SetDescriptor(ActiveUnit activeUnit_0, Contact contact_0)
	{
		int num = PlottedCourse.Length - 1;
		double num2 = 0.0;
		for (int i = 0; i <= num; i++)
		{
			if (i == 0)
			{
				num2 = Math2.VerifyClass(myWeapon.FiringParent.GetLatitude(), myWeapon.FiringParent.GetLongitude(), PlottedCourse[i].Latitude, PlottedCourse[i].Longitude);
			}
			else if (PlottedCourse.Length > i + 1)
			{
				float num3 = Math2.VerifyClass(PlottedCourse[i].Latitude, PlottedCourse[i].Longitude, PlottedCourse[i + 1].Latitude, PlottedCourse[i + 1].Longitude);
				num2 += (double)num3;
			}
		}
		float num4 = 0f;
		if (((contact_0 != null) & (PlottedCourse != null)) && PlottedCourse.Count() > 0)
		{
			Module_Unit.BearingToUnit_True(activeUnit_0, myUnit.AI.PrimaryTarget);
			num4 = Module_Unit.ClosureSpeed(myUnit, myUnit.AI.PrimaryTarget, myUnit.CurrentSpeed, myUnit.CurrentHeading);
		}
		num2 -= (double)num4;
		double item = num2 * 1852.0 / ((double)(myWeapon.MaxSpeed + num4) * 0.514444);
		return (true, item);
	}

	private bool FillDescriptor(float float_0)
	{
		try
		{
			if (myUnit.AI.PrimaryTarget != null)
			{
				Waypoint waypoint = new Waypoint();
				Weapon weapon = (Weapon)myUnit;
				waypoint.Type = Waypoint.WaypointType.TerminalPoint;
				double latitude;
				double longitude;
				float num;
				if (HasPlottedCourse())
				{
					if (PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
					{
						if (PlottedCourse.Count() <= 1)
						{
							latitude = myUnit.GetLatitude();
							longitude = myUnit.GetLongitude();
							num = myUnit.GetCurrentAltitude();
						}
						else
						{
							latitude = PlottedCourse[PlottedCourse.Count() - 2].Latitude;
							longitude = PlottedCourse[PlottedCourse.Count() - 2].Longitude;
							num = PlottedCourse[PlottedCourse.Count() - 2].Altitude;
						}
					}
					else
					{
						latitude = PlottedCourse[PlottedCourse.Count() - 1].Latitude;
						longitude = PlottedCourse[PlottedCourse.Count() - 1].Longitude;
						num = PlottedCourse[PlottedCourse.Count() - 1].Altitude;
					}
				}
				else
				{
					latitude = myUnit.GetLatitude();
					longitude = myUnit.GetLongitude();
					num = myUnit.GetCurrentAltitude();
				}
				double num11 = 0.0;
				waypoint.Altitude = myUnit.AI.PrimaryTarget.GetCurrentAltitude();
				if (weapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
				{
					try
					{
						if (myUnit.AI.PrimaryTarget.CurrentSpeed <= 0f)
						{
							waypoint.Latitude = myUnit.AI.PrimaryTarget.GetLatitude();
							waypoint.Longitude = myUnit.AI.PrimaryTarget.GetLongitude();
						}
						else
						{
							double? num12 = ActiveUnit_Navigator.CalculateInterceptHeading(latitude, longitude, myUnit.CurrentHeading, myUnit.AI.PrimaryTarget, float_0);
							if (!num12.HasValue)
							{
								(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, myUnit.AI.PrimaryTarget);
								if (!Information.IsNothing(tuple.Item1))
								{
									num12 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
								}
							}
							if (!num12.HasValue)
							{
								return false;
							}
							Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
							if (num12.Value < 0.0)
							{
								geopoint_Struct = ComputeInterceptPoint_BruteForce(float_0, myUnit.AI.PrimaryTarget, null);
								num12 = Module_Unit.BearingToPoint_True(myWeapon, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
							}
							float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, myUnit.AI.BearingToUnit_True(myUnit.AI.PrimaryTarget));
							if ((relativeBearing > 10f && relativeBearing < 350f) || (relativeBearing > 170f && relativeBearing < 190f))
							{
								geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num12.Value, new Geopoint_Struct(myUnit.AI.PrimaryTarget.GetLongitude(), myUnit.AI.PrimaryTarget.GetLatitude()), myUnit.AI.PrimaryTarget.CurrentHeading);
							}
							if (geopoint_Struct.HasZeroCoords)
							{
								Geopoint_Struct geopoint_Struct2 = ComputeInterceptPoint_BruteForce(float_0, myUnit.AI.PrimaryTarget, null);
								if (geopoint_Struct2.HasZeroCoords)
								{
									waypoint.Latitude = myUnit.AI.PrimaryTarget.GetLatitude();
									waypoint.Longitude = myUnit.AI.PrimaryTarget.GetLongitude();
								}
								else
								{
									waypoint.Latitude = geopoint_Struct2.Latitude;
									waypoint.Longitude = geopoint_Struct2.Longitude;
								}
							}
							else
							{
								waypoint.Latitude = geopoint_Struct.Latitude;
								waypoint.Longitude = geopoint_Struct.Longitude;
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 101230", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						double[] array = new double[myUnit.Sensors_ReadOnly().Length + 1];
						if (myUnit.Sensors_ReadOnly().Length == 0)
						{
							Warhead[] warheads = weapon.Warheads;
							Warhead[] array2 = warheads;
							foreach (Warhead warhead in array2)
							{
								if (warhead.Type != Warhead.WarheadType.Weapon)
								{
									continue;
								}
								Weapon carriedWeapon = warhead.GetCarriedWeapon(weapon.ParentScen);
								int num13 = carriedWeapon.Sensors_ReadOnly().Length - 1;
								for (int i = 0; i <= num13; i++)
								{
									if (carriedWeapon.Sensors_ReadOnly()[i].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
									{
										array[i] = carriedWeapon.Sensors_ReadOnly()[i].maxRange;
									}
								}
							}
							num11 = array.Max();
						}
						else
						{
							int num14 = myUnit.Sensors_ReadOnly().Length - 1;
							for (int j = 0; j <= num14; j++)
							{
								if (myUnit.Sensors_ReadOnly()[j].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
								{
									array[j] = myUnit.Sensors_ReadOnly()[j].maxRange;
								}
							}
							num11 = array.Max();
						}
						if (((Weapon)myUnit).IsMissile && myUnit.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
						{
							num11 = 0.0;
							waypoint.Latitude = myUnit.AI.PrimaryTarget.GetLatitude();
							waypoint.Longitude = myUnit.AI.PrimaryTarget.GetLongitude();
							waypoint.Altitude = 0f;
						}
						float num15;
						float num17;
						double num2;
						double num3;
						double num5;
						double? num6;
						if (myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
						{
							num15 = Math2.VerifyClass(myUnit.AI.PrimaryTarget.GetLatitude(), myUnit.AI.PrimaryTarget.GetLongitude(), latitude, longitude);
							float num16 = Module_Unit.RangeToPoint_Slant(myUnit.AI.PrimaryTarget, latitude, longitude, num);
							num17 = myUnit.CurrentSpeed / 3600f * 2f * myUnit.ParentScen.GameResolution;
							double num18 = num11 * 0.75;
							num2 = Module_Unit.GrazingAngleToUnit(myWeapon, myUnit.AI.PrimaryTarget);
							num3 = num18 * Math2.CalculateClass(num2);
							double num4 = num18 * Math2.SetClass(num2) * 1852.0;
							waypoint.Altitude = (float)num4;
							if (myUnit.AI.PrimaryTarget.CurrentSpeed <= 0f)
							{
								if ((double)num16 <= num11)
								{
									num5 = (double)num15 * 0.5;
									if (num5 < (double)num17)
									{
										num5 = 0.0001;
									}
								}
								else
								{
									num5 = (double)num15 - num3;
									if (num5 < (double)num17)
									{
										num5 = 0.0001;
									}
								}
								double double_ = longitude;
								double double_5 = latitude;
								Waypoint waypoint2;
								double double_6 = (waypoint2 = waypoint).Longitude;
								Waypoint waypoint3;
								double double_7 = (waypoint3 = waypoint).Latitude;
								Geodesic_EdWilliams.CalcPoint_Williams(double_, double_5, ref double_6, ref double_7, (float)num5, Math2.PublishClass(latitude, longitude, myUnit.AI.PrimaryTarget.GetLatitude(), myUnit.AI.PrimaryTarget.GetLongitude()));
								waypoint3.Latitude = double_7;
								waypoint2.Longitude = double_6;
								goto IL_0d43;
							}
							num6 = ActiveUnit_Navigator.CalculateInterceptHeading(latitude, longitude, myUnit.CurrentHeading, myUnit.AI.PrimaryTarget, float_0);
							if (num6.HasValue)
							{
								double? num7 = num6;
								if (!(num7.HasValue ? new bool?(num7.GetValueOrDefault() < 0.0) : null).GetValueOrDefault())
								{
									goto IL_0b06;
								}
							}
							(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, myUnit.AI.PrimaryTarget);
							if (!tuple2.Item1.HasZeroCoords)
							{
								num6 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
							}
							goto IL_0b06;
						}
						waypoint.Latitude = myUnit.AI.PrimaryTarget.GetLatitude();
						waypoint.Longitude = myUnit.AI.PrimaryTarget.GetLongitude();
						goto end_IL_0579;
						IL_0b06:
						if (!num6.HasValue)
						{
							return false;
						}
						Geopoint_Struct geopoint_Struct3 = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num6.Value, new Geopoint_Struct(myUnit.AI.PrimaryTarget.GetLongitude(), myUnit.AI.PrimaryTarget.GetLatitude()), myUnit.AI.PrimaryTarget.CurrentHeading);
						if (geopoint_Struct3.HasZeroCoords)
						{
							if ((double)num15 <= num3)
							{
								num5 = 0.0001;
							}
							else
							{
								num5 = num15 / 2f;
								if (num5 < (double)num17)
								{
									num5 = 0.0001;
								}
							}
							double double_8 = longitude;
							double double_9 = latitude;
							double double_10 = waypoint.Longitude;
							double double_11 = waypoint.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(double_8, double_9, ref double_10, ref double_11, (float)num5, (float)num6.Value);
							waypoint.Latitude = double_11;
							waypoint.Longitude = double_10;
						}
						else
						{
							float num8 = Math2.VerifyClass(latitude, longitude, geopoint_Struct3.Latitude, geopoint_Struct3.Longitude);
							if ((double)num8 < num3)
							{
								num5 = 0.0001;
							}
							else if ((double)num8 <= (double)num15 - num3)
							{
								num5 = (double)num8 - num3;
								if (num5 < (double)num17)
								{
									num5 = 0.0001;
								}
							}
							else
							{
								num5 = num8 - (float)((double)num8 - ((double)num15 - num3));
								if (num5 <= 0.0)
								{
									num5 = 0.0001;
								}
								if (num5 < (double)num17)
								{
									num5 = 0.0001;
								}
							}
							double double_12 = longitude;
							double double_2 = latitude;
							double double_3 = waypoint.Longitude;
							double double_4 = waypoint.Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(double_12, double_2, ref double_3, ref double_4, (float)num5, Math2.PublishClass(latitude, longitude, geopoint_Struct3.Latitude, geopoint_Struct3.Longitude));
							waypoint.Latitude = double_4;
							waypoint.Longitude = double_3;
						}
						goto IL_0d43;
						IL_0d43:
						waypoint.Altitude = num - (float)(num5 * Math2.SetClass(num2) * 1852.0);
						end_IL_0579:;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 101231", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				if (((Weapon)myUnit).Warheads.Length != 0)
				{
					if (((Weapon)myUnit).Warheads[0].GetIsAirburst((Weapon)myUnit, myUnit.AI.PrimaryTarget.ActualUnit))
					{
						waypoint.Altitude = myUnit.AI.PrimaryTarget.GetCurrentAltitude() + (float)((Weapon)myUnit).GetOptimumBurstHeight_AGL(myUnit.AI.PrimaryTarget.ActualUnit);
					}
					else
					{
						waypoint.Altitude = myUnit.AI.PrimaryTarget.GetCurrentAltitude();
						if (weapon.HasTerminalGuidance)
						{
							double num9 = num11 * 0.75;
							double @class = Module_Unit.GrazingAngleToUnit(myWeapon, myUnit.AI.PrimaryTarget);
							double num10 = num9 * Math2.SetClass(@class) * 1852.0;
							waypoint.Altitude = (float)num10;
						}
					}
				}
				if (((Weapon)myUnit).Type == Weapon._WeaponType.Decoy_Expendable)
				{
					waypoint.Altitude = myUnit.GetCurrentAltitude();
				}
				else if (((Weapon)myUnit).IsAAW && !((Weapon)myUnit).IsASuW_Land && !((Weapon)myUnit).IsASuW_Naval)
				{
					Contact_Base.ContactType type = myUnit.AI.PrimaryTarget.Type;
					if (type == Contact_Base.ContactType.Aimpoint || type == Contact_Base.ContactType.ActivationPoint)
					{
						waypoint.Altitude = myUnit.GetCurrentAltitude();
					}
				}
				if (HasNonPathfindPlottedCourse() && PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
				{
					PlottedCourse[PlottedCourse.Count() - 1].Latitude = waypoint.Latitude;
					PlottedCourse[PlottedCourse.Count() - 1].Longitude = waypoint.Longitude;
					PlottedCourse[PlottedCourse.Count() - 1].Altitude = waypoint.Altitude;
				}
				else
				{
					AddWaypoint(waypoint.Latitude, waypoint.Longitude, waypoint.Altitude, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
				return true;
			}
			return false;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 1023402354934956349568349586123", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	internal bool CalculateDescriptor(float float_0, bool bool_1)
	{
		if (myWeapon.IsReEntryVehicle)
		{
			return FillDescriptor(float_0);
		}
		Weapon_AI aI = myWeapon.AI;
		try
		{
			if (aI.PrimaryTarget != null)
			{
				bool flag = aI.PrimaryTarget.IsAir_Missile_Orbital_Contact && aI.PrimaryTarget.IsBallisticTarget();
				Weapon weapon = (Weapon)myUnit;
				Waypoint[] array = null;
				double latitude;
				double longitude;
				if (HasPlottedCourse())
				{
					array = PlottedCourse;
					if (array[array.Length - 1].Type == Waypoint.WaypointType.TerminalPoint)
					{
						if (array.Length <= 1)
						{
							latitude = myUnit.GetLatitude();
							longitude = myUnit.GetLongitude();
						}
						else
						{
							latitude = array[array.Length - 2].Latitude;
							longitude = array[array.Length - 2].Longitude;
						}
					}
					else
					{
						latitude = array[array.Length - 1].Latitude;
						longitude = array[array.Length - 1].Longitude;
					}
				}
				else
				{
					latitude = myUnit.GetLatitude();
					longitude = myUnit.GetLongitude();
				}
				double num = 0.0;
				Weapon.WeaponGuidanceType guidance = weapon.Guidance;
				Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
				Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
				if (guidance == Weapon.WeaponGuidanceType.Inertial)
				{
					try
					{
						if (weapon.Type == Weapon._WeaponType.PalletWeapon)
						{
							geopoint_Struct_.Latitude = weapon.GetLatitude();
							geopoint_Struct_.Longitude = weapon.GetLongitude();
							geopoint_Struct_.Altitude = 0f;
						}
						else if (aI.PrimaryTarget.CurrentSpeed <= 0f)
						{
							geopoint_Struct_.Latitude = aI.PrimaryTarget.GetLatitude();
							geopoint_Struct_.Longitude = aI.PrimaryTarget.GetLongitude();
						}
						else
						{
							double? num12 = ((aI.PrimaryTarget.CurrentSpeed == 0f) ? new double?(Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), aI.PrimaryTarget.GetLatitude(), aI.PrimaryTarget.GetLongitude())) : ActiveUnit_Navigator.CalculateInterceptHeading(latitude, longitude, myUnit.CurrentHeading, aI.PrimaryTarget, float_0));
							if (!num12.HasValue)
							{
								(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, aI.PrimaryTarget);
								if (!Information.IsNothing(tuple.Item1))
								{
									num12 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
								}
							}
							if (!num12.HasValue)
							{
								return false;
							}
							if (num12.Value < 0.0)
							{
								geopoint_Struct = ComputeInterceptPoint_BruteForce(float_0, aI.PrimaryTarget, null);
								num12 = Module_Unit.BearingToPoint_True(myWeapon, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
							}
							float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, aI.BearingToUnit_True(aI.PrimaryTarget));
							if ((relativeBearing > 10f && relativeBearing < 350f) || (relativeBearing > 170f && relativeBearing < 190f))
							{
								geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num12.Value, new Geopoint_Struct(aI.PrimaryTarget.GetLongitude(), aI.PrimaryTarget.GetLatitude()), aI.PrimaryTarget.CurrentHeading);
							}
							if (geopoint_Struct.HasZeroCoords)
							{
								Geopoint_Struct geopoint_Struct2 = ComputeInterceptPoint_BruteForce(float_0, aI.PrimaryTarget, null);
								if (geopoint_Struct2.HasZeroCoords)
								{
									geopoint_Struct_.Latitude = aI.PrimaryTarget.GetLatitude();
									geopoint_Struct_.Longitude = aI.PrimaryTarget.GetLongitude();
								}
								else
								{
									geopoint_Struct_.Latitude = geopoint_Struct2.Latitude;
									geopoint_Struct_.Longitude = geopoint_Struct2.Longitude;
								}
							}
							else
							{
								geopoint_Struct_.Latitude = geopoint_Struct.Latitude;
								geopoint_Struct_.Longitude = geopoint_Struct.Longitude;
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 101230", "");
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						double[] array2 = new double[myUnit.Sensors_ReadOnly().Length + 1];
						if (myUnit.Sensors_ReadOnly().Length == 0)
						{
							Warhead[] warheads = weapon.Warheads;
							Warhead[] array6 = warheads;
							foreach (Warhead warhead in array6)
							{
								if (warhead.Type != Warhead.WarheadType.Weapon)
								{
									continue;
								}
								Weapon carriedWeapon = warhead.GetCarriedWeapon(weapon.ParentScen);
								int num19 = carriedWeapon.Sensors_ReadOnly().Length - 1;
								for (int i = 0; i <= num19; i++)
								{
									if (carriedWeapon.Sensors_ReadOnly()[i].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
									{
										array2[i] = carriedWeapon.Sensors_ReadOnly()[i].maxRange;
									}
								}
							}
						}
						else
						{
							int num20 = myUnit.Sensors_ReadOnly().Length - 1;
							for (int j = 0; j <= num20; j++)
							{
								if (myUnit.Sensors_ReadOnly()[j].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
								{
									array2[j] = myUnit.Sensors_ReadOnly()[j].maxRange;
								}
							}
						}
						double[] array3 = array2;
						double[] array7 = array3;
						foreach (double num21 in array7)
						{
							if (num21 > num)
							{
								num = num21;
							}
						}
						if (((Weapon)myUnit).IsMissile && aI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
						{
							num = 0.0;
						}
						if (bool_1 && aI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine && ((Weapon)myUnit).Flags.SearchPattern)
						{
							num = 0.0;
						}
						float num22;
						float num23;
						double? num24;
						if (aI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && aI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
						{
							num22 = Math2.VerifyClass(aI.PrimaryTarget.GetLatitude(), aI.PrimaryTarget.GetLongitude(), latitude, longitude);
							num23 = myUnit.CurrentSpeed / 3600f * 2f;
							if (!(aI.PrimaryTarget.CurrentSpeed <= 0f))
							{
								num24 = ActiveUnit_Navigator.CalculateInterceptHeading(latitude, longitude, myUnit.CurrentHeading, aI.PrimaryTarget, float_0);
								if (num24.HasValue)
								{
									double? num25 = num24;
									if (!(num25.HasValue ? new bool?(num25.GetValueOrDefault() < 0.0) : null).GetValueOrDefault())
									{
										goto IL_09de;
									}
								}
								(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, aI.PrimaryTarget);
								if (!Information.IsNothing(tuple2))
								{
									num24 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
								}
								goto IL_09de;
							}
							double num2;
							if ((double)num22 <= num)
							{
								num2 = (double)num22 * 0.5;
								if (num2 < (double)num23)
								{
									num2 = 0.0001;
								}
							}
							else
							{
								num2 = (double)num22 - num * 0.8;
								if (num2 < (double)num23)
								{
									num2 = 0.0001;
								}
							}
							Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, (float)num2, Math2.PublishClass(latitude, longitude, aI.PrimaryTarget.GetLatitude(), aI.PrimaryTarget.GetLongitude()));
						}
						else
						{
							geopoint_Struct_.Latitude = aI.PrimaryTarget.GetLatitude();
							geopoint_Struct_.Longitude = aI.PrimaryTarget.GetLongitude();
						}
						goto end_IL_055d;
						IL_09de:
						if (!num24.HasValue && !flag)
						{
							return false;
						}
						if (aI.PrimaryTarget.IsAir_Missile_Orbital_Contact)
						{
							float float_ = float_0;
							if (weapon.UsesBoostCoastModel.Value && weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime)
							{
								float_ = myWeapon.CurrentSpeed;
							}
							float num3 = Module_Unit.ClosureSpeed(myUnit, aI.PrimaryTarget, float_, myUnit.CurrentHeading);
							float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, aI.BearingToUnit_True(aI.PrimaryTarget));
							if (aI.PrimaryTarget.IsBallisticTarget())
							{
								geopoint_Struct = RemoveDescriptor(aI.PrimaryTarget);
								if (geopoint_Struct.HasZeroCoords)
								{
									return false;
								}
							}
							else
							{
								if (num3 > 0f && relativeBearing2 > 89f && relativeBearing2 < 271f && num3 < myUnit.CurrentSpeed)
								{
									num3 = -1f;
								}
								if (((relativeBearing2 > 5f && relativeBearing2 < 355f) || (relativeBearing2 > 175f && relativeBearing2 < 185f)) && (double)num3 < (double)myUnit.CurrentSpeed * 1.25)
								{
									geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num24.Value, new Geopoint_Struct(aI.PrimaryTarget.GetLongitude(), aI.PrimaryTarget.GetLatitude()), aI.PrimaryTarget.CurrentHeading);
								}
								geopoint_Struct = ComputeInterceptPoint_BruteForce(float_0, aI.PrimaryTarget, num3);
								if (geopoint_Struct.HasZeroCoords && ((relativeBearing2 > 10f && relativeBearing2 < 350f) || (relativeBearing2 > 170f && relativeBearing2 < 190f)))
								{
									geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num24.Value, new Geopoint_Struct(aI.PrimaryTarget.GetLongitude(), aI.PrimaryTarget.GetLatitude()), aI.PrimaryTarget.CurrentHeading);
								}
							}
							if (geopoint_Struct.HasZeroCoords)
							{
								double num4;
								if ((double)num22 <= num * 0.8)
								{
									num4 = 0.0001;
								}
								else
								{
									num4 = num22 / 2f;
									if (num4 < (double)num23)
									{
										num4 = 0.0001;
									}
								}
								Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, (float)num4, (float)num24.Value);
							}
							else
							{
								float num5 = Math2.VerifyClass(latitude, longitude, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
								double num6 = (((double)num22 < num) ? ((num5 < num22) ? ((double)num5 * 0.75) : ((double)num22 * 0.75)) : ((num5 < num22) ? ((double)num5 - num * 0.75) : ((double)num22 - num * 0.75)));
								if (num6 < (double)num23)
								{
									num6 = 0.0001;
								}
								Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, (float)num6, Math2.PublishClass(latitude, longitude, geopoint_Struct.Latitude, geopoint_Struct.Longitude));
							}
						}
						else
						{
							geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(longitude, latitude), num24.Value, new Geopoint_Struct(aI.PrimaryTarget.GetLongitude(), aI.PrimaryTarget.GetLatitude()), aI.PrimaryTarget.CurrentHeading);
							if (!Information.IsNothing(geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
							{
								float num7 = Math2.VerifyClass(latitude, longitude, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
								double num8;
								if ((double)num22 < num * 0.8)
								{
									num8 = ((num7 < num22) ? ((double)num7 * 0.75) : ((double)num22 * 0.75));
								}
								else if ((double)num7 <= (double)num22 - num * 0.8)
								{
									num8 = (double)num7 - num * 0.8;
									if (num8 < (double)num23)
									{
										num8 = 0.0001;
									}
								}
								else
								{
									num8 = num7 - (float)((double)num7 - ((double)num22 - num * 0.8));
									if (num8 <= 0.0)
									{
										num8 = 0.0001;
									}
									if (num8 < (double)num23)
									{
										num8 = 0.0001;
									}
								}
								Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, (float)num8, Math2.PublishClass(latitude, longitude, geopoint_Struct.Latitude, geopoint_Struct.Longitude));
							}
							else
							{
								double num9;
								if ((double)num22 <= num * 0.8)
								{
									num9 = 0.0001;
								}
								else
								{
									num9 = num22 / 2f;
									if (num9 < (double)num23)
									{
										num9 = 0.0001;
									}
								}
								Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref geopoint_Struct_.Longitude, ref geopoint_Struct_.Latitude, (float)num9, (float)num24.Value);
							}
						}
						end_IL_055d:;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 101231", "");
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				geopoint_Struct_.Altitude = aI.PrimaryTarget.GetCurrentAltitude();
				if (myWeapon.IsAAW && num > 0.0)
				{
					if (myWeapon.AI.PrimaryTarget != null)
					{
						if (flag && !geopoint_Struct.HasZeroCoords)
						{
							float num10 = Module_Unit.RangeToPoint_Horiz(myWeapon, geopoint_Struct);
							float num11 = Module_Unit.RangeToPoint_Horiz(myWeapon, geopoint_Struct_);
							if (geopoint_Struct.Altitude <= myWeapon.AI.PrimaryTarget.GetCurrentAltitude())
							{
								geopoint_Struct_.Altitude = geopoint_Struct.Altitude * (num11 / num10);
							}
							else
							{
								float num13 = geopoint_Struct.Altitude - myWeapon.GetCurrentAltitude();
								geopoint_Struct_.Altitude = geopoint_Struct.Altitude - num13 * (1f - num11 / num10);
							}
						}
						else
						{
							float num14 = Module_Unit.RangeToUnit_Horiz(myWeapon, myWeapon.AI.PrimaryTarget);
							float num15 = Module_Unit.RangeToPoint_Horiz(myWeapon, geopoint_Struct_);
							float currentAltitude = myWeapon.AI.PrimaryTarget.GetCurrentAltitude();
							float num16 = myWeapon.GetCurrentAltitude() - currentAltitude;
							if (num14 <= num15)
							{
								geopoint_Struct_.Altitude = currentAltitude + num16 * num14 / num15;
							}
							else
							{
								geopoint_Struct_.Altitude = currentAltitude + num16 * num15 / num14;
							}
						}
					}
				}
				else if (((Weapon)myUnit).Warheads.Length != 0)
				{
					if (((Weapon)myUnit).Warheads[0].GetIsAirburst((Weapon)myUnit, aI.PrimaryTarget.ActualUnit))
					{
						geopoint_Struct_.Altitude = aI.PrimaryTarget.GetCurrentAltitude() + (float)((Weapon)myUnit).GetOptimumBurstHeight_AGL(aI.PrimaryTarget.ActualUnit);
					}
					else
					{
						geopoint_Struct_.Altitude = aI.PrimaryTarget.GetCurrentAltitude();
						if (weapon.HasTerminalGuidance)
						{
							if (weapon.IsBallisticMissile || weapon.IsReEntryVehicle)
							{
								float num17 = 0f;
								if (weapon.Sensors_ReadOnly().Length == 0)
								{
									if (weapon.Warheads.Length != 0 && weapon.Warheads[0].GetCarriedWeapon(myUnit.ParentScen).Sensors_ReadOnly().Length != 0)
									{
										Sensor[] array4 = weapon.Warheads[0].GetCarriedWeapon(myUnit.ParentScen).Sensors_ReadOnly();
										Sensor[] array8 = array4;
										foreach (Sensor sensor in array8)
										{
											if (sensor.maxRange > num17)
											{
												num17 = sensor.maxRange;
											}
										}
										geopoint_Struct_.Altitude = (float)((double)num17 * 1852.0 / 2.0);
									}
								}
								else
								{
									Sensor[] array5 = weapon.Sensors_ReadOnly();
									Sensor[] array9 = array5;
									foreach (Sensor sensor2 in array9)
									{
										if (sensor2.maxRange > num17)
										{
											num17 = sensor2.maxRange;
										}
									}
									geopoint_Struct_.Altitude = (float)((double)num17 * 1852.0 / 2.0);
								}
							}
							if (weapon.ValidTargets.Radar && (aI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || aI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint))
							{
								int num18 = (int)Math.Round(num * 1852.0 * Math2.PopClass(45f) * 0.9);
								geopoint_Struct_.Altitude = Math.Min(num18, (((Weapon)myUnit).CruiseAltitude_AGL <= 0f) ? ((Weapon)myUnit).CruiseAltitude_ASL : ((Weapon)myUnit).CruiseAltitude_AGL);
							}
						}
					}
				}
				if (((Weapon)myUnit).Type == Weapon._WeaponType.Decoy_Expendable)
				{
					geopoint_Struct_.Altitude = myUnit.GetCurrentAltitude();
				}
				else if (((Weapon)myUnit).IsAAW && !((Weapon)myUnit).IsASuW_Land && !((Weapon)myUnit).IsASuW_Naval)
				{
					Contact_Base.ContactType type = aI.PrimaryTarget.Type;
					if (type != Contact_Base.ContactType.Aimpoint && type != Contact_Base.ContactType.ActivationPoint)
					{
						if (!aI.PrimaryTarget.IsBallisticTarget())
						{
							geopoint_Struct_.Altitude = aI.PrimaryTarget.GetCurrentAltitude();
						}
					}
					else
					{
						geopoint_Struct_.Altitude = myUnit.GetCurrentAltitude();
					}
				}
				if (HasNonPathfindPlottedCourse() && PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
				{
					if (array == null)
					{
						array = PlottedCourse;
					}
					array[array.Count() - 1].Latitude = geopoint_Struct_.Latitude;
					array[array.Count() - 1].Longitude = geopoint_Struct_.Longitude;
					array[array.Count() - 1].Altitude = geopoint_Struct_.Altitude;
				}
				else
				{
					AddWaypoint(geopoint_Struct_.Latitude, geopoint_Struct_.Longitude, geopoint_Struct_.Altitude, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
				return true;
			}
			return false;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100987", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override void CheckIfReachedWaypoint(float float_0, ref bool bool_1, ref bool bool_2)
	{
		Weapon weapon = myWeapon;
		int num = PlottedCourse.Length;
		if ((myWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial && !weapon.IsTorpedo && weapon.Type != Weapon._WeaponType.Decoy_Vehicle && weapon.Type != Weapon._WeaponType.UAV_Expendable && num == 1) || (weapon.AI.PrimaryTarget != null && weapon.HasTorpedoPayload && (weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint) && num == 1))
		{
			return;
		}
		if (num > 0)
		{
			Scenario parentScen = myUnit.ParentScen;
			DateTime t = parentScen.Time;
			if (myWeapon._FacadeReader)
			{
				t = t.AddSeconds(myWeapon.TimeSinceLaunch);
			}
			if (DateTime.Compare(WP_reach_cache_memory.theTime, t) == 0)
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
			if (HaveReachedPoint(waypoint, float_0))
			{
				if (num >= 2)
				{
					ApplyWaypointSpeedAltToUnit(waypoint);
					ApplyWaypointDoctrineToUnit(waypoint);
				}
				RemoveWaypoint_Soft(waypoint, bool_1: false);
				if (PlottedCourse.Length != 0)
				{
					HeadToFirstWaypoint(float_0);
				}
			}
		}
		if (PlottedCourse.Length == 0 && (weapon.Type == Weapon._WeaponType.Decoy_Vehicle || weapon.Type == Weapon._WeaponType.UAV_Expendable))
		{
			myUnit.AI.PrimaryTarget = null;
		}
	}
}
