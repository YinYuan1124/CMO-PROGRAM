using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using ThreadSafeCollections;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public class LuaWrapper_ActiveUnit
{
	internal ActiveUnit au;

	protected Scenario ScenarioContext;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			PropertyInfo[] array3 = array;
			MethodInfo[] array2;
			foreach (PropertyInfo propertyInfo in array3)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				array2 = methods;
				MethodInfo[] array4 = array2;
				foreach (MethodInfo obj2 in array4)
				{
					string right = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, right, TextCompare: false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			array2 = methods;
			MethodInfo[] array5 = array2;
			foreach (MethodInfo methodInfo in array5)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text2 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text2 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text2 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text2 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (au.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(au.Doctrine, ScenarioContext);
		}
	}

	[DoNotPrune]
	public bool AllowMultiMission
	{
		get
		{
			return au.AllowMultiMission;
		}
		set
		{
			au.AllowMultiMission = value;
		}
	}

	[DoNotPrune]
	public bool UseCustomIntermittentEmissionOnly
	{
		get
		{
			return au.Sensory.InterruptConsumer().UseCustomPresetOnly;
		}
		set
		{
			au.Sensory.InterruptConsumer().UseCustomPresetOnly = value;
		}
	}

	[DoNotPrune]
	public LuaTable AssignedMissionsQueue
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			new List<Mission>();
			List<Mission> list = au.AssignedMissionsQueue.Values.ToList();
			int num = 1;
			foreach (Mission item in list)
			{
				val[num] = item.ObjectID;
				num++;
			}
			return val;
		}
		set
		{
			foreach (object item in LuaUtility.ToArray(value.GetEnumerator()))
			{
				string text = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				Mission mission = LuaMission.ValidateMissionBySceanrio(text, ScenarioContext);
				if (mission != null && Operators.CompareString(mission.ObjectID, text, TextCompare: false) == 0)
				{
					au.AssignMissionInQueue(mission);
				}
			}
		}
	}

	[DoNotPrune]
	public object __obj => au;

	[DoNotPrune]
	public bool IsMine
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsMine;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsUnguidedBallisticWeapon
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsUnguidedBallisticWeapon;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsBallisticMissile
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsBallisticMissile;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsDecoy
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsDecoy;
			}
			return au.Decoy;
		}
	}

	[DoNotPrune]
	public bool IsNuke
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsNuke.Value;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsDestroyed => false;

	[DoNotPrune]
	public bool WasPickedUp
	{
		get
		{
			if (au.IsActiveUnit)
			{
				return au.IsBeingPickedUp;
			}
			return false;
		}
	}

	[DoNotPrune]
	public string pickedUpBy
	{
		get
		{
			if (au.PickUpUnit == null)
			{
				return null;
			}
			return au.PickUpUnit.ObjectID;
		}
	}

	[DoNotPrune]
	public string subtype
	{
		get
		{
			if ((int)au.UnitType <= 0)
			{
				return "None";
			}
			return au.SubType.ToString();
		}
	}

	[DoNotPrune]
	public string type
	{
		get
		{
			if ((int)au.UnitType <= 0)
			{
				if (au.IsGroup)
				{
					return "Group";
				}
				return "None";
			}
			return au.UnitType.ToString();
		}
	}

	[DoNotPrune]
	public int typeN
	{
		get
		{
			if ((int)au.UnitType <= 0)
			{
				return 0;
			}
			return (int)au.UnitType;
		}
	}

	public string category
	{
		get
		{
			switch (type)
			{
			default:
				if (au.IsGroup)
				{
					return "Group";
				}
				return null;
			case "Submarine":
				return ((Submarine)au).Category.ToString("d");
			case "Ship":
				return ((Ship)au).Category.ToString("d");
			case "Satellite":
				return ((Satellite)au).Category.ToString("d");
			case "Facility":
				if (au.IsFixedFacility)
				{
					return ((Facility)au).Category.ToString("d");
				}
				return ((Facility)au).EnableBridge().ToString("d");
			case "Aircraft":
				return ((Aircraft)au).Category.ToString("d");
			}
		}
	}

	[DoNotPrune]
	public int dbid => au.DBID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return au.Name;
		}
		set
		{
			au.Name = value;
		}
	}

	[DoNotPrune]
	public virtual double latitude
	{
		get
		{
			return au.GetLatitude();
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual double longitude
	{
		get
		{
			return au.GetLongitude();
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual double SettledTime
	{
		get
		{
			return au.SettledTime;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual bool autodetectable
	{
		get
		{
			return au.GetIsAutoDetectable(null);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public string guid => au.ObjectID;

	[DoNotPrune]
	public string side
	{
		get
		{
			if (au.IsWeapon)
			{
				if (((Weapon)au).FiringParent == null)
				{
					return null;
				}
				return ((Weapon)au).FiringParent.GetUnitSide().Name;
			}
			return au.GetUnitSide().Name;
		}
	}

	[DoNotPrune]
	public object mission
	{
		get
		{
			if (au.AssignedMissionOrPackage() == null)
			{
				return null;
			}
			return new LuaWrapper_Mission(au.AssignedMissionOrPackage(), ScenarioContext);
		}
		set
		{
			if (!(value is string))
			{
				throw new LuaError("请提供任务的名称。");
			}
			PrivateMethods.ScenEdit_AssignUnitToMission(au.ObjectID, Conversions.ToString(value), ScenarioContext, null, bool_0: false, bool_1: false);
		}
	}

	[DoNotPrune]
	public bool holdposition
	{
		get
		{
			return au.AI.HoldPosition;
		}
		set
		{
			au.AI.HoldPosition = value;
		}
	}

	[DoNotPrune]
	public object holdfire
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Doctrine doctrine = au.Doctrine;
			if (doctrine.WeaponControlStatus_Air_Inherits())
			{
				val["Air"] = "Inherit";
			}
			else
			{
				val["Air"] = ((byte)doctrine.GetWeaponControlStatus_Air(ScenarioContext, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
			}
			if (doctrine.WeaponControlStatus_Surface_Inherits())
			{
				val["Surface"] = "Inherit";
			}
			else
			{
				val["Surface"] = ((byte)doctrine.GetWeaponControlStatus_Surface(ScenarioContext, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
			}
			if (doctrine.WeaponControlStatus_Submarine_Inherits())
			{
				val["SubSurface"] = "Inherit";
			}
			else
			{
				val["Subsurface"] = ((byte)doctrine.GetWeaponControlStatus_Submarine(ScenarioContext, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
			}
			if (doctrine.WeaponControlStatus_Land_Inherits())
			{
				val["Land"] = "Inherit";
			}
			else
			{
				val["Land"] = ((byte)doctrine.GetWeaponControlStatus_Land(ScenarioContext, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
			}
			return val;
		}
		set
		{
			throw new LuaError("This is a Doctrine property for a normal active unit. Please use SetDoctrine instead.");
		}
	}

	[DoNotPrune]
	public virtual object group
	{
		get
		{
			if ((au.GetParentGroup() != null) | au.IsGroup)
			{
				if (au.GetParentGroup() == null)
				{
					return new LuaWrapper_Group((Group)au, ScenarioContext);
				}
				return new LuaWrapper_Group(au.GetParentGroup(), ScenarioContext);
			}
			return null;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object altitude
	{
		get
		{
			return au.GetCurrentAltitude(bool_0: true);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public object airbornetime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.UpdateRequest((long)Math.Round(((Aircraft)au).AirborneTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object airbornetime_v
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return (long)Math.Round(((Aircraft)au).AirborneTime);
			}
			return null;
		}
	}

	public object timeunderway
	{
		get
		{
			try
			{
				if ((object)au.GetType() == typeof(Aircraft))
				{
					return Misc.UpdateRequest((long)Math.Round(((Aircraft)au).AirborneTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
				}
				return Misc.UpdateRequest((long)Math.Round(au.TimeUnderway), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return null;
			}
		}
	}

	[DoNotPrune]
	public object timeunderway_v
	{
		get
		{
			try
			{
				if ((object)au.GetType() == typeof(Aircraft))
				{
					return (long)Math.Round(((Aircraft)au).AirborneTime);
				}
				return (long)Math.Round(au.TimeUnderway);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return null;
			}
		}
	}

	[DoNotPrune]
	public object readytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.UpdateRequest((long)Math.Round(((Aircraft)au).AirOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
			}
			if (Information.IsNothing(au.DockingOps))
			{
				return null;
			}
			return Misc.UpdateRequest((long)Math.Round(au.DockingOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
		}
	}

	[DoNotPrune]
	public object loadoutdbid
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (Information.IsNothing(((Aircraft)au).Loadout))
				{
					return 0;
				}
				return ((Aircraft)au).Loadout.DBID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public virtual object speed
	{
		get
		{
			return au.CurrentSpeed;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object throttle
	{
		get
		{
			return au.ThrottleSetting;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable damage
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			ActiveUnit_Damage activeUnit_Damage = au.Damage;
			float damagePercent = au.Damage.DamagePercent;
			LuaUtility.FromDict(new Dictionary<string, object>
			{
				{
					"DP",
					au.GetDamagePts()
				},
				{
					"FLOOD",
					activeUnit_Damage.FloodIntensity.ToString()
				},
				{
					"FIRES",
					activeUnit_Damage.FireIntensity.ToString()
				},
				{
					"STARTDP",
					au.InitialDP.ToString()
				},
				{
					"DP_PERCENT",
					au.utilsVal.ToString()
				},
				{
					"DP_PERCENT_NOW",
					damagePercent.ToString()
				}
			}, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable ascontact
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Side[] sides_ReadOnly = au.ParentScen.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (!Information.IsNothing(side) && side.Name != this.side)
				{
					foreach (Contact contacts_ in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_.ActualUnit.ObjectID, au.ObjectID, TextCompare: false) == 0)
						{
							LuaTable val2 = LuaSandBox.Singleton().CreateTable();
							val2["side"] = side.ObjectID;
							val2["guid"] = contacts_.ObjectID;
							val2["name"] = contacts_.Name;
							val[val.Keys.Count + 1] = val2;
						}
					}
				}
				foreach (string key in side.m_InfoFacade.Keys)
				{
					if (!side.Contacts_List.Contains(side.m_InfoFacade[key]))
					{
						Contact contact = side.m_InfoFacade[key];
						LuaTable val3 = LuaSandBox.Singleton().CreateTable();
						val3["side"] = side.ObjectID;
						val3["guid"] = contact.ObjectID;
						val3["name"] = contact.Name;
						val[val.Keys.Count + 1] = val3;
					}
				}
			}
			return val;
		}
	}

	[DoNotPrune]
	public virtual object desiredheading
	{
		get
		{
			return au.DesiredHeading;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.SetDesiredHeading(ActiveUnit.TurnRate.Max, result);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public virtual object heading
	{
		get
		{
			return au.CurrentHeading;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable weather
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			Weather.WeatherProfile weatherAtMyLocation = au.WeatherAtMyLocation;
			obj["temp"] = weatherAtMyLocation.GetActualTemp(Weather.TTimeOfDayType.tod_Day);
			obj["rainfall"] = weatherAtMyLocation.RainfallRate;
			obj["undercloud"] = weatherAtMyLocation.FractionUnderRain;
			obj["seastate"] = weatherAtMyLocation.SeaState;
			return obj;
		}
	}

	[DoNotPrune]
	public virtual string proficiency
	{
		get
		{
			string result = null;
			if (au.IsWeapon)
			{
				return null;
			}
			GlobalVariables.ProficiencyLevel? proficiencyLevel = au.Proficiency;
			int? num = (int?)proficiencyLevel;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				result = "Novice";
			}
			else
			{
				num = (int?)proficiencyLevel;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					result = "Cadet";
				}
				else
				{
					num = (int?)proficiencyLevel;
					if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						result = "Regular";
					}
					else
					{
						num = (int?)proficiencyLevel;
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 3) : null).GetValueOrDefault())
						{
							result = "Veteran";
						}
						else
						{
							num = (int?)proficiencyLevel;
							if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 4) : null).GetValueOrDefault())
							{
								result = "Ace";
							}
						}
					}
				}
			}
			return result;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable course
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
			Waypoint[] array = plottedCourse;
			foreach (Waypoint waypoint in array)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["latitude"] = waypoint.Latitude;
				val2["longitude"] = waypoint.Longitude;
				val[num] = val2;
				num++;
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable fuel
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (FuelRec item in au.Fuel_ReadOnly)
			{
				if (val[Convert.ToInt32((short)item.FuelType)] == null)
				{
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					val2["current"] = item.CurrentQuantity;
					val2["max"] = item.MaxQuantity;
					val2["name"] = item.FuelType.ToString();
					val2["type"] = Convert.ToInt32((short)item.FuelType);
					val[Convert.ToInt32((short)item.FuelType)] = val2;
				}
				else
				{
					LuaTable val3 = (LuaTable)val[Convert.ToInt32((short)item.FuelType)];
					val3["current"] = Conversions.ToSingle(val3["current"]) + item.CurrentQuantity;
					val3["max"] = Conversions.ToSingle(val3["max"]) + (float)item.MaxQuantity;
				}
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable fuels
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (FuelRec item in au.Fuel_ReadOnly)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["current"] = item.CurrentQuantity;
				val2["max"] = item.MaxQuantity;
				val2["name"] = item.FuelType.ToString();
				val2["type"] = Convert.ToInt32((short)item.FuelType);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public virtual LuaTable formation
	{
		get
		{
			if (Information.IsNothing(au.GetParentGroup()))
			{
				if (au.IsGroup)
				{
					Group group = (Group)au;
					ActiveUnit groupLead = group.GroupLead;
					LuaTable obj = LuaSandBox.Singleton().CreateTable();
					obj["lead"] = groupLead.ObjectID;
					obj["name"] = group.LastFormationSet;
					obj["spacing"] = group.LastFormationSpacing;
					obj["spacing_unit"] = group.LastFormationSpacingUnits;
					return obj;
				}
				return null;
			}
			ActiveUnit groupLead2 = au.GetParentGroup().GroupLead;
			LuaTable obj2 = LuaSandBox.Singleton().CreateTable();
			ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
			obj2["guid"] = au.ObjectID;
			obj2["bearing"] = unitFormationStation.Bearing;
			obj2["type"] = unitFormationStation.BearingType.ToString();
			obj2["distance"] = unitFormationStation.Distance;
			obj2["sprint"] = au.Navigator.SprintDrift.ToString();
			Tuple<double, double> latitudeAndLongitude = unitFormationStation.GetLatitudeAndLongitude(au, groupLead2);
			obj2["latitude"] = latitudeAndLongitude.Item1;
			obj2["longitude"] = latitudeAndLongitude.Item2;
			return obj2;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable magazines
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Magazine[] totalMagazines = au.TotalMagazines;
			Magazine[] array = totalMagazines;
			foreach (Magazine magazine in array)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				LuaTable val3 = LuaSandBox.Singleton().CreateTable();
				if (magazine.DBID == 0)
				{
					val2["mag_capacity"] = magazine.Capacity;
					val2["mag_dbid"] = magazine.DBID;
					val2["mag_guid"] = magazine.ObjectID;
					val2["mag_name"] = magazine.Name;
					foreach (WeaponRec weapon in magazine.Weapons)
					{
						LuaTable val4 = LuaSandBox.Singleton().CreateTable();
						val4["wpn_guid"] = weapon.ObjectID;
						val4["wpn_current"] = weapon.CurrentLoad;
						val4["wpn_maxcap"] = weapon.MaxLoad;
						val4["wpn_default"] = weapon.DefaultLoad;
						val4["wpn_dbid"] = weapon.int_0;
						val4["wpn_name"] = weapon.GetReferenceWeapon(ScenarioContext).Name;
						val3[val3.Keys.Count + 1] = val4;
					}
					val2["mag_weapons"] = val3;
					val[val.Keys.Count + 1] = val2;
					continue;
				}
				val2["mag_capacity"] = magazine.Capacity;
				val2["mag_dbid"] = magazine.DBID;
				val2["mag_guid"] = magazine.ObjectID;
				val2["mag_name"] = magazine.Name;
				foreach (WeaponRec weapon2 in magazine.Weapons)
				{
					LuaTable val5 = LuaSandBox.Singleton().CreateTable();
					val5["wpn_guid"] = weapon2.ObjectID;
					val5["wpn_current"] = weapon2.CurrentLoad;
					val5["wpn_maxcap"] = weapon2.MaxLoad;
					val5["wpn_default"] = weapon2.DefaultLoad;
					val5["wpn_dbid"] = weapon2.int_0;
					val5["wpn_name"] = weapon2.GetReferenceWeapon(ScenarioContext).Name;
					val3[val3.Keys.Count + 1] = val5;
				}
				val2["mag_weapons"] = val3;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable mounts
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (Mount mount in au.Mounts)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				LuaTable val3 = LuaSandBox.Singleton().CreateTable();
				if (mount.DBID == 0)
				{
					continue;
				}
				val2["mount_dbid"] = mount.DBID;
				val2["mount_guid"] = mount.ObjectID;
				val2["mount_name"] = mount.Name;
				val2["mount_status"] = mount.Status.ToString();
				if (mount.Status != 0)
				{
					val2["mount_statusR"] = mount.ReasonForInoperative;
					val2["mount_damage"] = mount.DamageSeverity.ToString();
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					LuaTable val4 = LuaSandBox.Singleton().CreateTable();
					val4["wpn_guid"] = mountWeapon.ObjectID;
					val4["wpn_current"] = mountWeapon.CurrentLoad;
					val4["wpn_maxcap"] = mountWeapon.MaxLoad;
					val4["wpn_default"] = mountWeapon.DefaultLoad;
					val4["wpn_dbid"] = mountWeapon.int_0;
					val4["wpn_name"] = mountWeapon.GetReferenceWeapon(ScenarioContext).Name;
					val4["wpn_type"] = (int)DBFunctions.GetWeaponType(mountWeapon.int_0, ScenarioContext);
					val3[val3.Keys.Count + 1] = val4;
				}
				val2["mount_weapons"] = val3;
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable sensors
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			Sensor[] array = au.Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["sensor_dbid"] = sensor.DBID;
				val2["sensor_guid"] = sensor.ObjectID;
				val2["sensor_name"] = sensor.Name;
				val2["sensor_type"] = (short)sensor.Type;
				val2["sensor_role"] = (long)sensor.Role;
				val2["sensor_maxrange"] = sensor.maxRange;
				val2["sensor_status"] = sensor.Status.ToString();
				val2["sensor_isactive"] = sensor.IsActive;
				if (sensor.Status != 0)
				{
					val2["sensor_statusR"] = sensor.ReasonForInoperative;
					val2["sensor_damage"] = sensor.DamageSeverity.ToString();
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("无法在普通活动单元上设置此属性。请改用ActiveUnit_SE实体。");
		}
	}

	[DoNotPrune]
	public virtual LuaTable airFacilities
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (au.AirFacilities_ReadOnly.Count() == 0)
			{
				return null;
			}
			AirFacility[] airFacilities_ReadOnly = au.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility in array)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["air_capacity"] = airFacility.Capacity;
				val2["air_dbid"] = airFacility.DBID;
				val2["air_guid"] = airFacility.ObjectID;
				val2["air_name"] = airFacility.Name;
				val2["air_facility"] = new LuaWrapper_Facility(airFacility, ScenarioContext);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable dockFacilities
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (au.DockFacilities_ReadOnly.Count() == 0)
			{
				return null;
			}
			DockFacility[] dockFacilities_ReadOnly = au.DockFacilities_ReadOnly;
			DockFacility[] array = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in array)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["dock_capacity"] = (int)dockFacility.Capacity;
				val2["dock_dbid"] = dockFacility.DBID;
				val2["dock_guid"] = dockFacility.ObjectID;
				val2["dock_name"] = dockFacility.Name;
				val2["dock_facility"] = new LuaWrapper_Facility(dockFacility, ScenarioContext);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable components
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (au.OrderIssuer().Count <= 0)
			{
				return val;
			}
			foreach (PlatformComponent item in au.OrderIssuer())
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["comp_guid"] = item.ObjectID;
				val2["comp_dbid"] = item.DBID;
				val2["comp_name"] = item.Name;
				val2["comp_type"] = item.GetType().Name;
				val2["comp_status"] = item.Status.ToString();
				if (item.Status != 0)
				{
					val2["comp_damage"] = item.DamageSeverity.ToString();
					val2["comp_statusR"] = item.ReasonForInoperative;
				}
				if (item.GetType() == typeof(Cargo))
				{
					val2["comp_name"] = ((Cargo)item).CargoObjectName;
					val2["comp_type"] = (int)((Cargo)item).CurrentType;
					val2["comp_dbid"] = ((Cargo)item).CargoObjectDBID;
					val2["comp_guid"] = ((Cargo)item).CargoObjectID;
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
		set
		{
			throw new LuaError("无法在普通活动单元上设置此属性。请改用ActiveUnit_SE实体。");
		}
	}

	[DoNotPrune]
	public LuaTable cargo
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			List<ActiveUnit> list = new List<ActiveUnit>();
			if (au is Group)
			{
				foreach (ActiveUnit value in ((Group)au).Units.Values)
				{
					if (value.OnboardCargo.Count() > 0)
					{
						list.Add(value);
					}
				}
			}
			else if (au.OnboardCargo.Count() > 0)
			{
				list.Add(au);
			}
			if (list.Count <= 0)
			{
				return val;
			}
			foreach (ActiveUnit item2 in list)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["name"] = item2.Name;
				val2["guid"] = item2.ObjectID;
				if (item2.OnboardCargo.Count() > 0)
				{
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					List<Tuple<int, Cargo>> list2 = new List<Tuple<int, Cargo>>();
					Cargo[] onboardCargo = item2.OnboardCargo;
					Cargo[] array = onboardCargo;
					foreach (Cargo Local_theM in array)
					{
						int num = list2.FindIndex((Tuple<int, Cargo> x) => x.Item2.CargoObjectDBID == Local_theM.CargoObjectDBID && Local_theM.CurrentType == Cargo.CargoObjectType.Mount);
						if (num == -1)
						{
							list2.Add(new Tuple<int, Cargo>(1, Local_theM));
							continue;
						}
						int item = list2[num].Item1 + 1;
						list2[num] = new Tuple<int, Cargo>(item, Local_theM);
					}
					foreach (Tuple<int, Cargo> item3 in list2)
					{
						LuaTable val4 = LuaSandBox.Singleton().CreateTable();
						val4["name"] = item3.Item2.CargoObjectName;
						val4["Type"] = (int)item3.Item2.CurrentType;
						val4["dbid"] = item3.Item2.CargoObjectDBID;
						val4["guid"] = item3.Item2.CargoObjectID;
						val4["status"] = item3.Item2.CargoObjectStatus.ToString();
						val4["area"] = item3.Item2.RequiredArea;
						val4["crew"] = item3.Item2.RequiredCrewSpace;
						val4["mass"] = item3.Item2.RequiredMass;
						val4["quantity"] = item3.Item1;
						if (item3.Item2.CargoObjectStatus != 0)
						{
							val4["damage"] = item3.Item2.CargoObjectDamageSeverity.ToString();
							val4["statusR"] = item3.Item2.CargoObjectReasonForInoperative;
						}
						val3[val3.Keys.Count + 1] = val4;
					}
					val2["cargo"] = val3;
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public string old_condition
	{
		get
		{
			switch (type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.OldCondition.ToString();
				}
				break;
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).OldCondition.ToString();
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string condition
	{
		get
		{
			switch (type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.ConditionString;
				}
				break;
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).ConditionString;
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string condition_v
	{
		get
		{
			switch (type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.Condition.ToString();
				}
				break;
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).Condition.ToString();
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string unitstate => au.Status.ToString();

	[DoNotPrune]
	public string fuelstate => au.FuelState.ToString();

	[DoNotPrune]
	public string weaponstate => au.WeaponState.ToString();

	[DoNotPrune]
	public virtual object manualSpeed
	{
		get
		{
			return au.Kinematics.DesiredSpeedOverride;
		}
		set
		{
			throw new LuaError("无法在普通活动单元上设置此属性。请改用ActiveUnit_SE实体。");
		}
	}

	[DoNotPrune]
	public virtual LuaTable OODA
	{
		get
		{
			LuaTable obj = LuaSandBox.Singleton().CreateTable();
			obj["detection"] = au.m_TokenVal;
			obj["targeting"] = au._IndexerVal;
			obj["evasion"] = au._ResolverVal;
			return obj;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object manualAltitude
	{
		get
		{
			return au.Kinematics.DesiredAltitudeOverride;
		}
		set
		{
			throw new LuaError("无法在普通活动单元上设置此属性。请改用ActiveUnit_SE实体。");
		}
	}

	[DoNotPrune]
	public object weapon
	{
		get
		{
			if (au.IsWeapon)
			{
				LuaTable val = LuaSandBox.Singleton().CreateTable();
				Weapon obj = (Weapon)au;
				ActiveUnit firingParent = obj.FiringParent;
				Contact primaryTarget = obj.AI.PrimaryTarget;
				bool invocationReader = obj._InvocationReader;
				if (firingParent != null)
				{
					val["shooter"] = new LuaWrapper_ActiveUnit(firingParent, ScenarioContext);
				}
				if (primaryTarget != null)
				{
					val["contact"] = new LuaWrapper_Contact(primaryTarget, ScenarioContext, au.GetUnitSide());
				}
				if (invocationReader)
				{
					val["detonated"] = invocationReader.ToString();
				}
				return val;
			}
			return null;
		}
	}

	[DoNotPrune]
	public virtual LuaWrapper_ActiveUnit @base
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			switch (type)
			{
			case "Ship":
			case "Submarine":
			{
				if (au.DockingOps == null)
				{
					break;
				}
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.CurrentHostUnit == null)
				{
					if (dockingOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(dockingOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(dockingOps.CurrentHostUnit, ScenarioContext);
				}
				break;
			}
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
				if (aircraft_AirOps.CurrentHostUnit == null)
				{
					if (aircraft_AirOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(aircraft_AirOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(aircraft_AirOps.CurrentHostUnit, ScenarioContext);
				}
				break;
			}
			}
			return result;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaWrapper_Facility hostFacility
	{
		get
		{
			LuaWrapper_Facility result = null;
			switch (type)
			{
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = au.DockingOps;
					if (dockingOps.HostDockFacility != null)
					{
						result = new LuaWrapper_Facility(dockingOps.HostDockFacility, ScenarioContext);
					}
				}
				break;
			case "Aircraft":
				if (au.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
					if (aircraft_AirOps.HostAirFacility != null)
					{
						result = new LuaWrapper_Facility(aircraft_AirOps.HostAirFacility, ScenarioContext);
					}
				}
				break;
			}
			return result;
		}
	}

	[DoNotPrune]
	public LuaTable areaTriggersFired
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			List<string> activeEnterAreaTriggers = au.ActiveEnterAreaTriggers;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			if (activeEnterAreaTriggers.Count > 0)
			{
				foreach (string item in activeEnterAreaTriggers)
				{
					dictionary.Add(num.ToString(), item);
					num++;
				}
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable areaRemainInTriggersFired
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			TDictionary<string, DateTime> activeRemainAreaTriggers = au.ActiveRemainAreaTriggers;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			if (activeRemainAreaTriggers.Count > 0)
			{
				foreach (KeyValuePair<string, DateTime> item in activeRemainAreaTriggers)
				{
					dictionary.Add(num.ToString(), item);
					num++;
				}
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable hostedUnits => embarkedUnits;

	[DoNotPrune]
	public LuaTable embarkedUnits
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (au.DockingOps != null)
			{
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.EmbarkedBoats.Count <= 0)
				{
					val["Boats"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					foreach (ActiveUnit embarkedBoat in dockingOps.EmbarkedBoats)
					{
						val2[num.ToString()] = embarkedBoat.ObjectID;
						val2[num] = embarkedBoat.ObjectID;
						num++;
					}
					val["Boats"] = val2;
				}
			}
			if (au.AirOps != null)
			{
				num = 1;
				ActiveUnit_AirOps airOps = au.AirOps;
				if (airOps.EmbarkedAircraft_ReadOnly.Count <= 0)
				{
					val["Aircraft"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					foreach (Aircraft item in airOps.EmbarkedAircraft_ReadOnly)
					{
						val3[num.ToString()] = item.ObjectID;
						val3[num] = item.ObjectID;
						num++;
					}
					val["Aircraft"] = val3;
				}
			}
			return val;
		}
	}

	[DoNotPrune]
	public LuaTable assignedUnits
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (au.DockingOps != null)
			{
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.AssignedBoats.Count <= 0)
				{
					val["Boats"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					foreach (ActiveUnit assignedBoat in dockingOps.AssignedBoats)
					{
						val2[num] = assignedBoat.ObjectID;
						num++;
					}
					val["Boats"] = val2;
				}
			}
			if (au.AirOps != null)
			{
				num = 1;
				ActiveUnit_AirOps airOps = au.AirOps;
				if (airOps.AssignedAircraft.Count <= 0)
				{
					val["Aircraft"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					foreach (Aircraft item in airOps.AssignedAircraft)
					{
						val3[num] = item.ObjectID;
						num++;
					}
					val["Aircraft"] = val3;
				}
			}
			return val;
		}
	}

	[DoNotPrune]
	public object targetedBy
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				Contact[] targets_ReadOnly = value.AI.Targets_ReadOnly;
				for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
				{
					if (targets_ReadOnly[i].ActualUnit == au && !dictionary.ContainsValue(value.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
					}
				}
				if (!Information.IsNothing(value.AI.PrimaryTarget) && value.AI.PrimaryTarget.ActualUnit == au && !dictionary.ContainsValue(value.ObjectID))
				{
					dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public object firingAt
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing(primaryTarget) && au == firingParent && !dictionary.ContainsValue(primaryTarget.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), primaryTarget.ObjectID);
					}
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public object firedOn
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing(primaryTarget) && au == primaryTarget.ActualUnit && !dictionary.ContainsValue(firingParent.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), firingParent.ObjectID);
					}
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, val);
			return val;
		}
	}

	[DoNotPrune]
	public bool isOperating => au.IsOperating();

	[DoNotPrune]
	public bool isEscort => au.AI.IsEscort;

	[DoNotPrune]
	public bool IsLoadedAsCargo => au.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo;

	[DoNotPrune]
	public virtual bool sprintDrift
	{
		get
		{
			if (Information.IsNothing(au.Navigator))
			{
				return false;
			}
			return au.Navigator.SprintDrift;
		}
		set
		{
			throw new LuaError("无法在普通活动单元上设置此属性。请改用ActiveUnit_SE实体（通过ScenEdit_SetUnit）。");
		}
	}

	[DoNotPrune]
	public string classname
	{
		get
		{
			if (au.UnitClass == null)
			{
				return "None";
			}
			return au.UnitClass;
		}
	}

	[DoNotPrune]
	public bool outOfComms => !au.CommStuff.IsConnectedToSideNetwork;

	[DoNotPrune]
	public bool jammed
	{
		get
		{
			if (!au.Sensory.JammerUnitsAreAffectingMe && !au.CommStuff.CommJamUnitsAreAffectingMe)
			{
				return false;
			}
			return true;
		}
	}

	[DoNotPrune]
	public bool jammer
	{
		get
		{
			if (ActiveUnit_Sensory.smethod_0(au))
			{
				return true;
			}
			return false;
		}
	}

	[DoNotPrune]
	public float groundSpeed
	{
		get
		{
			if ((au.IsAircraft || au.IsMissile) && au.SupportsAttitude_Pitch)
			{
				return (float)((double)au.CurrentSpeed * Math2.PopClass(au.Attitude_Pitch));
			}
			return 0f;
		}
	}

	[DoNotPrune]
	public float pitch
	{
		get
		{
			if (au.SupportsAttitude_Pitch)
			{
				return au.Attitude_Pitch;
			}
			return 0f;
		}
	}

	[DoNotPrune]
	public float roll => au.Attitude_Roll;

	[DoNotPrune]
	public int crew
	{
		get
		{
			Type type = au.GetType();
			if (type == typeof(Submarine))
			{
				return ((Submarine)au).Crew;
			}
			if (type == typeof(Ship))
			{
				return ((Ship)au).Crew;
			}
			if (type == typeof(Aircraft))
			{
				return ((Aircraft)au).Crew;
			}
			if (type == typeof(Facility))
			{
				return ((Facility)au).Crew;
			}
			return 0;
		}
	}

	[DoNotPrune]
	public float currentExhaustion => au.Current_Exhaustion;

	[DoNotPrune]
	public float maxExhaustion => au.MAX_Exhaustion;

	[DoNotPrune]
	public LuaTable signature
	{
		get
		{
			if (au.IsWeapon)
			{
				switch (((Weapon)au).Type)
				{
				case Weapon._WeaponType.None:
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.TrainingRound:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.SensorPod:
				case Weapon._WeaponType.DropTank:
				case Weapon._WeaponType.BuddyStore:
				case Weapon._WeaponType.FerryTank:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.Sonobuoy:
				case Weapon._WeaponType.HeliTowedPackage:
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.Microwave:
				case Weapon._WeaponType.Cargo:
				case Weapon._WeaponType.Troops:
				case Weapon._WeaponType.Paratroops:
					return null;
				}
			}
			Loadout loadout = null;
			if (au.IsAircraft)
			{
				loadout = ((Aircraft)au).Loadout;
			}
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (loadout != null)
			{
				val["loadout"] = loadout.DBID;
			}
			try
			{
				XSection[] xSections_ReadOnly = au.XSections_ReadOnly;
				XSection[] array = xSections_ReadOnly;
				foreach (XSection xSection in array)
				{
					if ((xSection.GetFront(au) == 0f && xSection.GetSide(au) == 0f && xSection.GetRear(au) == 0f) || xSection.GetFront(au) == -10000f || xSection.GetSide(au) == -10000f || xSection.GetRear(au) == -10000f)
					{
						continue;
					}
					LuaTable val2 = LuaSandBox.Singleton().CreateTable();
					LuaTable val3 = LuaSandBox.Singleton().CreateTable();
					val2["type"] = xSection.SignatureType.ToString();
					val2["typeN"] = (int)xSection.SignatureType;
					string text;
					string text2;
					string text3;
					if (xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_VLF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_LF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_MF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_HF && xSection.SignatureType != XSection._SignatureType.ActiveSonar)
					{
						if (xSection.SignatureType != XSection._SignatureType.Visual_Detect && xSection.SignatureType != XSection._SignatureType.Visual_ID && xSection.SignatureType != XSection._SignatureType.IR_Detect && xSection.SignatureType != XSection._SignatureType.IR_ID)
						{
							if (xSection.SignatureType != XSection._SignatureType.Radar_A_D && xSection.SignatureType != XSection._SignatureType.Radar_E_M)
							{
								val2["type"] = null;
								text = "";
								text2 = "";
								text3 = "";
							}
							else
							{
								double num = Math.Pow(10.0, xSection.GetFront(au) / 10f);
								double num2 = Math.Pow(10.0, xSection.GetFront(au) / 10f);
								double num3 = Math.Pow(10.0, xSection.GetSide(au) / 10f);
								double num4 = Math.Pow(10.0, xSection.GetRear(au) / 10f);
								if (num < 1.0 && num >= 0.1)
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.00}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.00}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.00}" + "平方米";
								}
								else if (num < 0.1 && num >= 0.01)
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.000}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.000}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.000}" + "平方米";
								}
								else if (num < 0.01 && num >= 0.001)
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.0000}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.0000}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.0000}" + "平方米";
								}
								else if (num < 0.001 && num >= 0.0001)
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.00000}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.00000}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.00000}" + "平方米";
								}
								else if (num < 0.0001 && num >= 1E-05)
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.000000}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.000000}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.000000}" + "平方米";
								}
								else
								{
									text = $"{xSection.GetFront(au):0.00}" + " 分贝平方米(dBsm), " + $"{num2:0.0}" + "平方米";
									text2 = $"{xSection.GetSide(au):0.00}" + " 分贝平方米(dBsm), " + $"{num3:0.0}" + "平方米";
									text3 = $"{xSection.GetRear(au):0.00}" + " 分贝平方米(dBsm), " + $"{num4:0.0}" + "平方米";
								}
								val3["front"] = Math.Round(num2, 6);
								val3["side"] = Math.Round(num3, 6);
								val3["rear"] = Math.Round(num4, 6);
								val2["sqm"] = val3;
							}
						}
						else
						{
							text = $"{xSection.GetFront(au):0.00}" + "海里";
							text2 = $"{xSection.GetSide(au):0.00}" + "海里";
							text3 = $"{xSection.GetRear(au):0.00}" + "海里";
						}
					}
					else
					{
						text = $"{xSection.GetFront(au):0.00}" + "分贝";
						text2 = $"{xSection.GetSide(au):0.00}" + "分贝";
						text3 = $"{xSection.GetRear(au):0.00}" + "分贝";
					}
					val3 = LuaSandBox.Singleton().CreateTable();
					val3["front"] = Math.Round(xSection.GetFront(au), 5);
					val3["side"] = Math.Round(xSection.GetSide(au), 5);
					val3["rear"] = Math.Round(xSection.GetRear(au), 5);
					val2["rcs"] = val3;
					val3 = LuaSandBox.Singleton().CreateTable();
					val3["front"] = text;
					val3["side"] = text2;
					val3["rear"] = text3;
					val2["text"] = val3;
					val[val.Keys.Count + 1] = val2;
				}
				return val;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaTable noiseLevel
	{
		get
		{
			try
			{
				if (au.IsBoat)
				{
					LuaTable obj = LuaSandBox.Singleton().CreateTable();
					List<(float, float, float)> source = new List<(float, float, float)>
					{
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.VLF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.LF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.MF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.HF_Sonar)
					};
					obj["front"] = Math.Round(source.Select<(float, float, float), float>(((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.FrontValue).Max(), 2);
					obj["side"] = Math.Round(source.Select<(float, float, float), float>(((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.SideValue).Max(), 2);
					obj["rear"] = Math.Round(source.Select<(float, float, float), float>(((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.RearValue).Max(), 2);
					return obj;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[DoNotPrune]
	public bool TF
	{
		get
		{
			return au.GetDesiredAltitude_UseTerrainFollowing(au);
		}
		set
		{
			au.SetDesiredAltitude_UseTerrainFollowing(au, value);
		}
	}

	[DoNotPrune]
	public int TFType
	{
		get
		{
			return (int)au.TerrainFollowingType;
		}
		set
		{
			au.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)value;
		}
	}

	public LuaWrapper_ActiveUnit(ActiveUnit activeUnit_0, Scenario scenario_0)
	{
		au = activeUnit_0;
		ScenarioContext = scenario_0;
	}

	public LuaWrapper_ActiveUnit(UnguidedWeapon unguidedWeapon_0, Scenario scenario_0)
	{
		au = new Weapon(ref scenario_0);
		ScenarioContext = scenario_0;
		au.ObjectID = unguidedWeapon_0.ObjectID;
		au.UnitClass = unguidedWeapon_0.UnitClass;
		au.SetUnitSide(bool_0: false, unguidedWeapon_0.GetUnitSide());
		((Weapon)au).Type = unguidedWeapon_0.Type;
		au.DBID = Conversions.ToInteger(Strings.Split(unguidedWeapon_0.AnnexAndDBID, "_")[1]);
		au.Name = unguidedWeapon_0.Name;
		au.SetLatitude(null, unguidedWeapon_0.GetLatitude());
		au.SetLongitude(null, unguidedWeapon_0.GetLongitude());
		au.SetCurrentAltitude(bool_0: false, unguidedWeapon_0.GetCurrentAltitude());
	}

	[DoNotPrune]
	public LuaWrapper_Waypoint getwaypoint(LuaTable luaTable_0)
	{
		if (luaTable_0 != null)
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
			if (dictionary.ContainsKey("GUID"))
			{
				string right = Conversions.ToString(dictionary["GUID"]);
				Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
				Waypoint[] array = plottedCourse;
				foreach (Waypoint waypoint in array)
				{
					if (Operators.CompareString(waypoint.ObjectID, right, TextCompare: false) == 0)
					{
						return new LuaWrapper_Waypoint(waypoint, ScenarioContext);
					}
				}
			}
			return null;
		}
		throw new LuaError("Provided parameter is not a valid Lua table!");
	}

	[DoNotPrune]
	public LuaTable filterOnComponent(string string_0, int int_0 = 0)
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		if (au.OrderIssuer().Count <= 0)
		{
			return val;
		}
		foreach (PlatformComponent item in au.OrderIssuer())
		{
			if ((string.Equals(item.GetType().Name, string_0, StringComparison.OrdinalIgnoreCase) || Operators.CompareString(string_0, "", TextCompare: false) == 0) && (int_0 == 0 || int_0 == item.DBID))
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["comp_guid"] = item.ObjectID;
				val2["comp_dbid"] = item.DBID;
				val2["comp_name"] = item.Name;
				val2["comp_type"] = item.GetType().Name;
				val2["comp_status"] = item.Status.ToString();
				if (item.Status != 0)
				{
					val2["comp_damage"] = item.DamageSeverity.ToString();
					val2["comp_statusR"] = item.ReasonForInoperative;
				}
				if (item.GetType() == typeof(Cargo))
				{
					val2["comp_name"] = ((Cargo)item).CargoObjectName;
					val2["comp_type"] = (int)((Cargo)item).CurrentType;
					val2["comp_dbid"] = ((Cargo)item).CargoObjectDBID;
					val2["comp_guid"] = ((Cargo)item).CargoObjectID;
				}
				if (item.GetType() == typeof(CommDevice))
				{
					val2["comp_comms_jammed"] = ((CommDevice)item).IsJammed;
				}
				else if (item.GetType() == typeof(Sensor))
				{
					val2["comp_sensor_jammed"] = ((Sensor)item).IsNeutralized;
				}
				val[val.Keys.Count + 1] = val2;
			}
		}
		return val;
	}

	[DoNotPrune]
	public float rangetotarget(string string_0)
	{
		Contact contact = PrivateMethods.ValidateContactBySceanrio(string_0, ScenarioContext);
		float result = 0f;
		if (contact != null)
		{
			Module_Unit.RangeToUnit_Horiz_Angular(au, contact);
			float num = Module_Unit.RangeToUnit_Horiz(au, contact);
			result = ((num == float.MaxValue) ? 0f : num);
		}
		return result;
	}

	[DoNotPrune]
	public bool inArea(LuaTable luaTable_0)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		au.GetUnitSide();
		list.Clear();
		foreach (object item in LuaUtility.ToArray(luaTable_0.GetEnumerator()))
		{
			object Local_o = RuntimeHelpers.GetObjectValue(item);
			ReferencePoint referencePoint = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (!Information.IsNothing(side.RefPoints.FirstOrDefault((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase))))
				{
					referencePoint = side.RefPoints.First((ReferencePoint s) => string.Equals(s.Name, Local_o.ToString(), StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_o.ToString(), StringComparison.OrdinalIgnoreCase));
					break;
				}
			}
			if (!Information.IsNothing(referencePoint))
			{
				list.Add(referencePoint);
			}
		}
		if (list == null)
		{
			throw new LuaError("参考点错误！");
		}
		return au.GetIsInsideThisArea(list, ScenarioContext, bool_0: false);
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "unit {\r\n type = '" + type + "', \r\n subtype = '" + subtype + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n guid = '" + guid.ToString() + "', \r\n class = '" + classname.ToString() + "', \r\n proficiency = '" + proficiency + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n altitude = '" + altitude.ToString() + "', \r\n heading = '" + heading.ToString() + "', \r\n speed = '" + speed.ToString() + "', \r\n throttle = '" + ((ActiveUnit.Throttle)Conversions.ToByte(throttle)).ToString() + "', \r\n autodetectable = '" + autodetectable + "', \r\n";
		if (@base != null)
		{
			text = text + " base = '" + @base.name + "', \r\n";
		}
		if (((group != null) | au.IsGroup) && group != null)
		{
			LuaWrapper_Group luaWrapper_Group = (LuaWrapper_Group)group;
			text = text + " group = '" + luaWrapper_Group.name + "', \r\n";
		}
		if (mission != null)
		{
			LuaWrapper_Mission luaWrapper_Mission = (LuaWrapper_Mission)mission;
			text = text + " mission = '" + luaWrapper_Mission.name + "', \r\n";
		}
		if (Operators.CompareString(type, "None", TextCompare: false) != 0)
		{
			try
			{
				if (au.Mounts != null)
				{
					text = text + " mounts = '" + au.Mounts.Count + "', \r\n";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (au.TotalMagazines != null)
				{
					text = text + " magazines = '" + au.TotalMagazines.Count() + "', \r\n";
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		text = text + " unitstate = '" + au.Status.ToString() + "', \r\n";
		text = text + " fuelstate = '" + au.FuelState.ToString() + "', \r\n";
		text = text + " weaponstate = '" + au.WeaponState.ToString() + "', \r\n";
		text = text + " AllowMultiMission = '" + au.AllowMultiMission + "', \r\n";
		text = text + " AssignedMissionsQueue = '" + AssignedMissionsQueue.ToString() + "', \r\n";
		text = text + " Decoy = '" + au.IsDecoy + "', \r\n";
		return text + "}";
	}

	[DoNotPrune]
	public float angleOnBowToUnit(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			ActiveUnit activeUnit = null;
			if (ScenarioContext.ActiveUnits.TryGetValue(string_0, ref activeUnit))
			{
				ActiveUnit unit_ = activeUnit;
				ActiveUnit unit_2 = au;
				string string_ = "";
				return Module_Unit.PrintTokenizer(unit_, unit_2, bool_0: true, ref string_);
			}
		}
		return 0f;
	}

	[DoNotPrune]
	public LuaWrapper_Device_Magazine getUnitMagazine(string string_0)
	{
		Magazine[] totalMagazines = au.TotalMagazines;
		Magazine[] array = totalMagazines;
		foreach (Magazine magazine in array)
		{
			if (Operators.CompareString(magazine.ObjectID, string_0, TextCompare: false) == 0)
			{
				return new LuaWrapper_Device_Magazine(magazine, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Device_Mount getUnitMount(string string_0)
	{
		foreach (Mount mount in au.Mounts)
		{
			if (Operators.CompareString(mount.ObjectID, string_0, TextCompare: false) == 0)
			{
				return new LuaWrapper_Device_Mount(mount, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Device_Magazine getUnitMountMagazine(string string_0)
	{
		foreach (Mount mount in au.Mounts)
		{
			if (Operators.CompareString(mount.ObjectID, string_0, TextCompare: false) == 0)
			{
				return new LuaWrapper_Device_Magazine(mount.MountMagazine, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Cargo getUnitCargo(string string_0)
	{
		Cargo[] onboardCargo = au.OnboardCargo;
		int num = 0;
		Cargo cargo;
		while (true)
		{
			if (num < onboardCargo.Length)
			{
				cargo = onboardCargo[num];
				if (Operators.CompareString(cargo.CargoObjectID, string_0, TextCompare: false) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return new LuaWrapper_Cargo(cargo, ScenarioContext);
	}
}
