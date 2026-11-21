using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Module_Contact
{
	[CompilerGenerated]
	private sealed class ReponseItem
	{
		public Contact Local_theContact;

		public List<ActiveUnit> Local_theSideUnits;

		public TList<Platform> Local_theBag;

		internal void VisitInterruptibleQueue(int i)
		{
			ActiveUnit activeUnit;
			try
			{
				activeUnit = Local_theSideUnits[i];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
			if (activeUnit.IsPlatform)
			{
				ActiveUnit_AI aI = activeUnit.AI;
				if (aI.PrimaryTarget != null && activeUnit.IsOperating() && aI.PrimaryTarget == Local_theContact)
				{
					Local_theBag.Add((Platform)activeUnit);
				}
			}
		}
	}

	internal static List<Platform> PostTokenizer(Contact contact_0, Side side, bool bool_0, ActiveUnit activeUnit_0 = null, bool bool_1 = true)
	{
		if (contact_0.ActualUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.TryGetValue(contact_0.ObjectID, out var value))
		{
			List<Platform> list = new List<Platform>(value);
			if (activeUnit_0 != null && list.Contains((Platform)activeUnit_0))
			{
				list.Remove((Platform)activeUnit_0);
			}
			if (bool_0)
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				foreach (Platform item in list)
				{
					if (item.IsGroupWingman())
					{
						list2.Add(item);
					}
				}
				if (list2.Count > 0)
				{
					foreach (ActiveUnit item2 in list2)
					{
						list.Remove((Platform)item2);
					}
				}
			}
			return list;
		}
		value = new List<Platform>();
		try
		{
			if (side == null)
			{
				return value;
			}
			if (side.Units.Count == 0)
			{
				return value;
			}
			List<ActiveUnit> Local_theSideUnits = side.Units;
			int count = Local_theSideUnits.Count;
			if (bool_1)
			{
				TList<Platform> Local_theBag = new TList<Platform>();
				Parallel.For(0, count, delegate(int i)
				{
					ActiveUnit activeUnit2;
					try
					{
						activeUnit2 = Local_theSideUnits[i];
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
						return;
					}
					if (activeUnit2.IsPlatform)
					{
						ActiveUnit_AI aI2 = activeUnit2.AI;
						if (aI2.PrimaryTarget != null && activeUnit2.IsOperating() && aI2.PrimaryTarget == contact_0)
						{
							Local_theBag.Add((Platform)activeUnit2);
						}
					}
				});
				value = Local_theBag.ToList();
			}
			else
			{
				int num = count - 1;
				for (int j = 0; j <= num; j++)
				{
					ActiveUnit activeUnit;
					try
					{
						activeUnit = Local_theSideUnits[j];
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						continue;
					}
					if (activeUnit.IsPlatform)
					{
						ActiveUnit_AI aI = activeUnit.AI;
						if (aI.PrimaryTarget != null && activeUnit.IsOperating() && aI.PrimaryTarget == contact_0)
						{
							value.Add((Platform)activeUnit);
						}
					}
				}
			}
			contact_0.ActualUnit.ParentScen.Cache_PrimaryTargetForWhichPlatforms.AddIfNotExistsElseUpdate(contact_0.ObjectID, value);
			List<Platform> list3 = new List<Platform>(value);
			if (activeUnit_0 != null && list3.Contains((Platform)activeUnit_0))
			{
				list3.Remove((Platform)activeUnit_0);
			}
			if (bool_0)
			{
				List<ActiveUnit> list4 = new List<ActiveUnit>();
				foreach (Platform item3 in list3)
				{
					if (item3.IsGroupWingman())
					{
						list4.Add(item3);
					}
				}
				if (list4.Count > 0)
				{
					foreach (ActiveUnit item4 in list4)
					{
						list3.Remove((Platform)item4);
					}
				}
			}
			return list3;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100491", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Platform> result = value;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal static float RunTokenizer(object object_0, double double_0, double double_1)
	{
		try
		{
			if (((Contact)object_0).UncertaintyArea == null)
			{
				return 0f;
			}
			if (((Contact)object_0).UncertaintyArea.Count == 0)
			{
				return 0f;
			}
			double longitude = ((Module_Unit.Unit)object_0).GetLongitude();
			double latitude = ((Module_Unit.Unit)object_0).GetLatitude();
			float float_ = Math2.PublishClass(double_0, double_1, latitude, longitude);
			double num = double.MinValue;
			double num2 = double.MaxValue;
			List<Geopoint_Struct> uncertaintyArea = ((Contact)object_0).UncertaintyArea;
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
			foreach (Geopoint_Struct item in uncertaintyArea)
			{
				double num3 = MathFunctions.DeleteRequest(float_, Math2.PublishClass(double_0, double_1, item.Latitude, item.Longitude));
				if (num3 > num)
				{
					num = num3;
					geopoint_Struct = item;
				}
				if (num3 < num2)
				{
					num2 = num3;
					geopoint_Struct2 = item;
				}
			}
			float num4 = MathFunctions.ClosestDistance_Geographic(new Geopoint_Struct(double_1, double_0), new Geopoint_Struct(longitude, latitude), new Geopoint_Struct(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude));
			float num5 = MathFunctions.ClosestDistance_Geographic(new Geopoint_Struct(double_1, double_0), new Geopoint_Struct(longitude, latitude), new Geopoint_Struct(geopoint_Struct.Longitude, geopoint_Struct.Latitude));
			return num4 + num5;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100487", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return float.MaxValue;
		}
	}

	internal static float StartTokenizer(Contact contact_0, Module_Unit.Unit unit_0)
	{
		float result = 0f;
		try
		{
			if (contact_0.UncertaintyArea == null)
			{
				result = 0f;
				return result;
			}
			if (contact_0.UncertaintyArea.Count == 0)
			{
				result = 0f;
				return result;
			}
			double num = double.MaxValue;
			double num2 = 0.0;
			foreach (Geopoint_Struct item in contact_0.UncertaintyArea)
			{
				Geopoint_Struct current = item;
				double num3 = Module_Unit.RangeToPoint_Horiz_Angular(unit_0, ref current.Latitude, ref current.Longitude);
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			result = (float)(num2 - num);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100488", "");
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
