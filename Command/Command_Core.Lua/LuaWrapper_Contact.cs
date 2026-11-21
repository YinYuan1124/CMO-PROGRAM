using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_Contact
{
	private Contact myContact;

	private Scenario ScenarioContext;

	private Side fromSidePerspective;

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
	public object __obj => myContact;

	[DoNotPrune]
	public string objectid => guid;

	[DoNotPrune]
	public string guid => myContact.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return myContact.Name;
		}
		set
		{
			myContact.Name = value;
		}
	}

	[DoNotPrune]
	public string actualunitid
	{
		get
		{
			if (Information.IsNothing(myContact.ActualUnit))
			{
				return "";
			}
			return myContact.ActualUnit.ObjectID;
		}
	}

	[DoNotPrune]
	public double latitude => myContact.GetLatitude();

	[DoNotPrune]
	public double longitude => myContact.GetLongitude();

	[DoNotPrune]
	public object speed
	{
		get
		{
			if (myContact.SpeedIsKnown)
			{
				return myContact.CurrentSpeed;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object heading
	{
		get
		{
			if (myContact.HeadingIsKnown)
			{
				return myContact.CurrentHeading;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object altitude
	{
		get
		{
			if (myContact.AltitudeIsKnown)
			{
				return myContact.GetCurrentAltitude();
			}
			return null;
		}
	}

	[DoNotPrune]
	public string posture
	{
		get
		{
			string result;
			if (!myContact.SideIsKnown)
			{
				Misc.PostureStance stance = myContact.GetStance(fromSidePerspective);
				if (1 == 0)
				{
				}
				result = stance switch
				{
					Misc.PostureStance.Neutral => "N", 
					Misc.PostureStance.Friendly => "F", 
					Misc.PostureStance.Unfriendly => "U", 
					Misc.PostureStance.Hostile => "H", 
					Misc.PostureStance.Unknown => "X", 
					_ => "X", 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			Misc.PostureStance stance2 = myContact.GetStance(fromSidePerspective);
			if (1 == 0)
			{
			}
			result = stance2 switch
			{
				Misc.PostureStance.Neutral => "N", 
				Misc.PostureStance.Friendly => "F", 
				Misc.PostureStance.Unfriendly => "U", 
				Misc.PostureStance.Hostile => "H", 
				Misc.PostureStance.Unknown => "X", 
				_ => "X", 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		set
		{
			if (myContact.SideIsKnown)
			{
				switch (value)
				{
				default:
					throw new LuaError("无效的交战关系代码：" + value);
				case "X":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Unknown);
					break;
				case "U":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Unfriendly);
					break;
				case "N":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Neutral);
					break;
				case "H":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Friendly);
					break;
				}
			}
			else
			{
				switch (value)
				{
				default:
					throw new LuaError("无效的交战关系代码：" + value);
				case "X":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Unknown);
					break;
				case "U":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Unfriendly);
					break;
				case "N":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Neutral);
					break;
				case "H":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					myContact.SetStance(fromSidePerspective, bool_0: false, Misc.PostureStance.Friendly);
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public Side observer
	{
		get
		{
			if (myContact.OriginalDetectorSide != null && Operators.CompareString(myContact.OriginalDetectorSide.ObjectID, fromSidePerspective.ObjectID, TextCompare: false) != 0)
			{
				return myContact.OriginalDetectorSide;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string observer_posture
	{
		get
		{
			string result;
			if (!myContact.SideIsKnown)
			{
				Misc.PostureStance stance = myContact.GetStance(myContact.OriginalDetectorSide);
				if (1 == 0)
				{
				}
				result = stance switch
				{
					Misc.PostureStance.Neutral => "N", 
					Misc.PostureStance.Friendly => "F", 
					Misc.PostureStance.Unfriendly => "U", 
					Misc.PostureStance.Hostile => "H", 
					Misc.PostureStance.Unknown => "X", 
					_ => "X", 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			Misc.PostureStance stance2 = myContact.GetStance(myContact.OriginalDetectorSide);
			if (1 == 0)
			{
			}
			result = stance2 switch
			{
				Misc.PostureStance.Neutral => "N", 
				Misc.PostureStance.Friendly => "F", 
				Misc.PostureStance.Unfriendly => "U", 
				Misc.PostureStance.Hostile => "H", 
				Misc.PostureStance.Unknown => "X", 
				_ => "X", 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		set
		{
			if (myContact.SideIsKnown)
			{
				switch (value)
				{
				default:
					throw new LuaError("无效的交战关系代码：" + value);
				case "X":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Unknown);
					break;
				case "U":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Unfriendly);
					break;
				case "N":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Neutral);
					break;
				case "H":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Friendly);
					break;
				}
			}
			else
			{
				switch (value)
				{
				default:
					throw new LuaError("无效的交战关系代码：" + value);
				case "X":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Unknown);
					break;
				case "U":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Unfriendly);
					break;
				case "N":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Neutral);
					break;
				case "H":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					myContact.SetStance(myContact.OriginalDetectorSide, bool_0: false, Misc.PostureStance.Friendly);
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public LuaTable areaofuncertainty
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (Information.IsNothing(myContact.UncertaintyArea))
			{
				return val;
			}
			foreach (Geopoint_Struct item in myContact.UncertaintyArea)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["longitude"] = item.Longitude;
				val2["latitude"] = item.Latitude;
				val[num] = val2;
				num++;
			}
			return val;
		}
	}

	[DoNotPrune]
	public string type => myContact.ContactType_String;

	[DoNotPrune]
	public int typed => (int)myContact.Type;

	[DoNotPrune]
	public string type_description => myContact.DescriptionString;

	[DoNotPrune]
	public int actualunitdbid
	{
		get
		{
			if (myContact.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && !Information.IsNothing(myContact.ActualUnit))
			{
				return myContact.ActualUnit.DBID;
			}
			return 0;
		}
	}

	[DoNotPrune]
	public int classificationlevel => (int)myContact.IDStatus;

	[DoNotPrune]
	public LuaTable potentialmatches
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			DataRow[] array = null;
			foreach (int possibleMatchesBasedOnEmission in myContact.PossibleMatchesBasedOnEmissions)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["DBID"] = possibleMatchesBasedOnEmission;
				switch (myContact.Type)
				{
				case Contact_Base.ContactType.Air:
					array = ScenarioContext.Cache_Aircraft_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Aircraft aircraft_ = new Aircraft(ref ScenarioContext);
						DBFunctions.GetAircraft(ref ScenarioContext, ref aircraft_, possibleMatchesBasedOnEmission, bool_0: false);
						val2["TYPE"] = aircraft_.Type;
						val2["SUBTYPE"] = aircraft_.SubType;
						val2["CATEGORY"] = aircraft_.Category;
					}
					break;
				case Contact_Base.ContactType.Surface:
					array = ScenarioContext.Cache_Ships_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Ship ship_ = new Ship(ref ScenarioContext);
						DBFunctions.GetShip(ref ScenarioContext, ref ship_, possibleMatchesBasedOnEmission, bool_0: false);
						val2["TYPE"] = ship_.Type;
						val2["SUBTYPE"] = ship_.SubType;
						val2["CATEGORY"] = ship_.Category;
						val2["MISSILE_DEFENCE"] = ship_.MissileDefense;
					}
					break;
				case Contact_Base.ContactType.Submarine:
					array = ScenarioContext.Cache_Subs_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Submarine submarine_ = new Submarine(ref ScenarioContext);
						DBFunctions.GetSubmarine(ref ScenarioContext, ref submarine_, possibleMatchesBasedOnEmission, bool_0: false);
						val2["TYPE"] = submarine_.Type;
						val2["SUBTYPE"] = submarine_.SubType;
						val2["CATEGORY"] = submarine_.Category;
					}
					break;
				case Contact_Base.ContactType.Orbital:
					array = ScenarioContext.Cache_Satellites_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Satellite satellite_ = new Satellite(ref ScenarioContext);
						DBFunctions.GetSatellite(ref ScenarioContext, ref satellite_, possibleMatchesBasedOnEmission);
						val2["TYPE"] = satellite_.Type;
						val2["SUBTYPE"] = satellite_.SubType;
						val2["CATEGORY"] = satellite_.Category;
					}
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
					array = ScenarioContext.Cache_Facilities_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Facility facility_ = new Facility(ref ScenarioContext);
						DBFunctions.GetFacility(ref ScenarioContext, ref facility_, possibleMatchesBasedOnEmission, bool_0: false);
						val2["SUBTYPE"] = facility_.SubType;
						val2["CATEGORY"] = facility_.Category;
						val2["MISSILE_DEFENCE"] = facility_.MissileDefense;
					}
					break;
				case Contact_Base.ContactType.Missile:
				case Contact_Base.ContactType.Torpedo:
					array = ScenarioContext.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Weapon newWeapon = Weapon.GetNewWeapon(ref ScenarioContext, 0, bool_0: true);
						DBFunctions.GetWeapon(ScenarioContext.DBConnection, newWeapon, possibleMatchesBasedOnEmission, ScenarioContext);
						val2["TYPE"] = newWeapon.Type;
						val2["SUBTYPE"] = newWeapon.SubType;
					}
					break;
				}
				if (array != null && array.Count() > 0)
				{
					val2["NAME"] = Misc.ReadRequest(array[0]["Name"].ToString());
				}
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public object side
	{
		get
		{
			if (myContact.SideIsKnown)
			{
				return new LuaWrapper_Side(myContact.GetUnitSide(), ScenarioContext);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object fromside
	{
		get
		{
			if (fromSidePerspective == null)
			{
				return null;
			}
			return new LuaWrapper_Side(fromSidePerspective, ScenarioContext);
		}
	}

	[DoNotPrune]
	public object detectedBySide => new LuaWrapper_Side(myContact.OriginalDetectorSide, ScenarioContext);

	[DoNotPrune]
	public int missile_defence
	{
		get
		{
			if (myContact.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && !Information.IsNothing(myContact.ActualUnit))
			{
				switch (myContact.Type)
				{
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
					return ((Facility)myContact.ActualUnit).MissileDefense;
				default:
					return -1;
				case Contact_Base.ContactType.Surface:
					return ((Ship)myContact.ActualUnit).MissileDefense;
				}
			}
			return 0;
		}
	}

	[DoNotPrune]
	public float age => myContact.TimeSinceDetection;

	[DoNotPrune]
	public object BDA
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (!Information.IsNothing(myContact.BDA_FloodLevel))
			{
				val["FLOOD"] = Misc.RateRequest(myContact.BDA_FloodLevel);
			}
			if (!Information.IsNothing(myContact.BDA_FireLevel))
			{
				val["FIRES"] = Misc.CalcRequest(myContact.BDA_FireLevel);
			}
			if (!Information.IsNothing(myContact.BDA_StructuralIntegrity))
			{
				val["STRUCTURAL"] = Misc.FlushRequest(myContact.BDA_StructuralIntegrity);
			}
			if (val.Keys.Count == 0)
			{
				return null;
			}
			return val;
		}
	}

	[DoNotPrune]
	public object emissions
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (myContact.HasDetectedEmissions)
			{
				List<int> list = myContact.DetectedEmissions.Keys.ToList();
				if (myContact.DetectedEmissions.Count > 0)
				{
					foreach (int item in list)
					{
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						EmissionContainer emissionContainer = myContact.DetectedEmissions[item];
						string iD_Description = emissionContainer.GetID_Description(item, ScenarioContext);
						float num = emissionContainer.Age;
						bool preciseID = emissionContainer.PreciseID;
						val2["Name"] = iD_Description;
						val2["Age"] = num;
						val2["Solid"] = preciseID;
						val2["name"] = iD_Description;
						val2["age"] = num;
						val2["solid"] = preciseID;
						SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
						Sensor sensor = DBFunctions.GetSensor(item, ref sqliteConnection_);
						val2["sensor_dbid"] = sensor.DBID;
						val2["sensor_name"] = sensor.Name;
						val2["sensor_type"] = (short)sensor.Type;
						val2["sensor_role"] = (long)sensor.Role;
						val2["sensor_maxrange"] = sensor.maxRange;
						val[val.Keys.Count + 1] = val2;
					}
				}
				return val;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object detectionBy
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (!Information.IsNothing(myContact.m_EventObserver))
			{
				val["Radar"] = myContact.m_EventObserver;
			}
			if (!Information.IsNothing(myContact.globalObserver))
			{
				val["ESM"] = myContact.globalObserver;
			}
			if (!Information.IsNothing(myContact.m_WorkerObserver))
			{
				val["Visual"] = myContact.m_WorkerObserver;
			}
			if (!Information.IsNothing(myContact.m_AccountObserver))
			{
				val["Infrared"] = myContact.m_AccountObserver;
			}
			if (!Information.IsNothing(myContact.stateObserver))
			{
				val["SonarActive"] = myContact.stateObserver;
			}
			if (!Information.IsNothing(myContact.authenticationObserver))
			{
				val["SonarPassive"] = myContact.authenticationObserver;
			}
			if (val.Keys.Count == 0)
			{
				return null;
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
					if (targets_ReadOnly[i].ActualUnit == myContact.ActualUnit && !dictionary.ContainsValue(value.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
					}
				}
				if (!Information.IsNothing(value.AI.PrimaryTarget) && value.AI.PrimaryTarget.ActualUnit == myContact.ActualUnit && !dictionary.ContainsValue(value.ObjectID))
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
					if (!Information.IsNothing(primaryTarget) && myContact.ActualUnit == firingParent && !dictionary.ContainsValue(primaryTarget.ObjectID))
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
					if (!Information.IsNothing(primaryTarget) && myContact.ActualUnit == primaryTarget.ActualUnit && !dictionary.ContainsValue(firingParent.ObjectID))
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
	public object FilterOut
	{
		get
		{
			return myContact.IsFilteredOut;
		}
		set
		{
			bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
			if (flag.HasValue)
			{
				myContact.IsFilteredOut = flag.Value;
			}
		}
	}

	[DoNotPrune]
	public LuaTable weather
	{
		get
		{
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			if (Information.IsNothing(longitude) & Information.IsNothing(longitude))
			{
				return null;
			}
			float num = 0f;
			if (myContact.AltitudeIsKnown)
			{
				num = myContact.GetCurrentAltitude();
			}
			Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(ScenarioContext, latitude, longitude, (int)Math.Round(num));
			val["temp"] = weatherAtThisTimeAndPlace.GetActualTemp(Weather.TTimeOfDayType.tod_Day);
			val["rainfall"] = weatherAtThisTimeAndPlace.RainfallRate;
			val["undercloud"] = weatherAtThisTimeAndPlace.FractionUnderRain;
			val["seastate"] = weatherAtThisTimeAndPlace.SeaState;
			return val;
		}
	}

	[DoNotPrune]
	public object lastDetections
	{
		get
		{
			if (myContact.LastDetections.Count == 0)
			{
				return null;
			}
			List<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)> list = new List<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)>(myContact.LastDetections).OrderByDescending<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime), DateTime>(((string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode DetectionMode, DateTime theTime) theRec) => theRec.theTime).ToList();
			LuaTable val = LuaSandBox.Singleton().CreateTable();
			foreach (var item in list)
			{
				LuaTable val2 = LuaSandBox.Singleton().CreateTable();
				val2["detector_guid"] = item.Item1 + (ScenarioContext.ActiveUnits.ContainsKey(item.Item1) ? "" : "?");
				val2["detect_sensor_guid"] = item.Item2;
				val2["range"] = item.Item3;
				val2["special_mode"] = item.Item4;
				val2["age"] = (long)Math.Round((ScenarioContext.Time - item.Item5).TotalSeconds);
				val[val.Keys.Count + 1] = val2;
			}
			return val;
		}
	}

	[DoNotPrune]
	public bool markedAsDecoy
	{
		get
		{
			return myContact.ActualUnit.GetisTaggedAsDecoyByThisSide(fromSidePerspective.ObjectID);
		}
		set
		{
			bool flag = myContact.ActualUnit.GetisTaggedAsDecoyByThisSide(fromSidePerspective.ObjectID);
			if (value)
			{
				if (!flag)
				{
					myContact.ActualUnit.ToggleUnitAsDecoyForCurrentSide(fromSidePerspective.ObjectID);
				}
			}
			else if (flag)
			{
				myContact.ActualUnit.ToggleUnitAsDecoyForCurrentSide(fromSidePerspective.ObjectID);
			}
		}
	}

	public LuaWrapper_Contact(Contact contact_0, Scenario scenario_0, Side side_0)
	{
		myContact = contact_0;
		ScenarioContext = scenario_0;
		fromSidePerspective = side_0;
	}

	[DoNotPrune]
	public object DropContact()
	{
		fromSidePerspective.DropContact(myContact, ref ScenarioContext, bool_0: true);
		return "ok";
	}

	[DoNotPrune]
	public bool inArea(LuaTable luaTable_0)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		myContact.GetUnitSide();
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
		return myContact.GetIsInsideThisArea(list, ScenarioContext, bool_0: false);
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("contact {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n type = '" + type.ToString() + "', \r\n", "}");
	}

	[DoNotPrune]
	public LuaTable ToLuaTable()
	{
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		if (myContact.LastDetections.Count <= 0)
		{
			val["DATE"] = ScenarioContext.Time.ToString("dd:MM:yyyy");
			val["TIME"] = ScenarioContext.Time.ToString("HH:mm:ss");
			val["RANGE"] = "-1";
			val["SENSORPARENTID"] = "-1";
			val["SENSORID"] = "-1";
			val["TARGETID"] = "-1";
			val["NAME"] = "Generated Contact";
			val["UNCERTAINITYAREA"] = "";
			val["POSTURE"] = "X";
		}
		else
		{
			(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime) tuple = myContact.LastDetections.ElementAt(myContact.LastDetections.Count - 1);
			val["DATE"] = tuple.Item5.ToString("dd:MM:yyyy");
			val["TIME"] = tuple.Item5.ToString("HH:mm:ss");
			val["RANGE"] = tuple.Item3.ToString();
			val["SENSORPARENTID"] = tuple.Item1;
			val["SENSORID"] = tuple.Item2;
			val["TARGETID"] = myContact.ActualUnit.ObjectID;
			val["NAME"] = myContact.Name;
			val["POSTURE"] = posture;
			if (myContact.UncertaintyArea != null)
			{
				List<string> list = new List<string>();
				foreach (Geopoint_Struct item in myContact.UncertaintyArea)
				{
					double num = item.Longitude;
					string text = num.ToString();
					num = item.Latitude;
					list.Add(text + ";" + num);
				}
				if (list.Count > 2)
				{
					val["UNCERTAINITYAREA"] = string.Join("|", list);
				}
			}
		}
		return val;
	}

	[DoNotPrune]
	public LuaTable FromLuaTable()
	{
		LuaTable obj = LuaSandBox.Singleton().CreateTable();
		obj["TEST"] = "A";
		return obj;
	}
}
