using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class DockFacility : PlatformComponent
{
	public enum DockFacilityType : short
	{
		None = 1001,
		DockWell = 2001,
		Davit = 3001,
		DryDockShelter = 4001,
		ROV_UUV = 5001,
		Pier = 9001
	}

	public enum DockingPhysicalSize : short
	{
		None = 1001,
		const_1 = 2001,
		SmallPier = 2002,
		MediumPier = 2003,
		LargePier = 2004,
		const_5 = 2005,
		const_6 = 2006,
		VSmallDockDavit = 3001,
		SmallDockDavit = 3002,
		MediumDock = 3003,
		LargeDock = 3004,
		DryDockShelter = 4001,
		ROV_UUV = 5001
	}

	public DockingPhysicalSize Size;

	public DockFacilityType Type;

	public byte Capacity;

	public TDictionary<string, ActiveUnit> HostedBoats;

	[ThreadStatic]
	private static StringBuilder _SerializerIssuer;

	public bool IsOpenDockFacility
	{
		get
		{
			DockFacilityType type = Type;
			if (type != DockFacilityType.DockWell && type != DockFacilityType.DryDockShelter)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsPier
	{
		get
		{
			if ((uint)(Size - 2001) <= 5u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsDock
	{
		get
		{
			DockingPhysicalSize size = Size;
			if ((uint)(size - 3001) > 3u && size != DockingPhysicalSize.DryDockShelter && size != DockingPhysicalSize.ROV_UUV)
			{
				return false;
			}
			return true;
		}
	}

	public int MaximumSingleBoatLength
	{
		get
		{
			switch (Size)
			{
			case DockingPhysicalSize.const_5:
				return 200;
			case DockingPhysicalSize.const_6:
				return 500;
			case DockingPhysicalSize.None:
				return 0;
			default:
				return 0;
			case DockingPhysicalSize.ROV_UUV:
				return 10;
			case DockingPhysicalSize.DryDockShelter:
				return 20;
			case DockingPhysicalSize.const_1:
			case DockingPhysicalSize.VSmallDockDavit:
				return 11;
			case DockingPhysicalSize.SmallDockDavit:
				return 17;
			case DockingPhysicalSize.MediumPier:
			case DockingPhysicalSize.MediumDock:
				return 25;
			case DockingPhysicalSize.LargePier:
			case DockingPhysicalSize.LargeDock:
				return 45;
			}
		}
	}

	public int TotalCapacity_Free
	{
		get
		{
			try
			{
				int num = MaximumSingleBoatLength * Capacity;
				int num2 = 0;
				foreach (ActiveUnit value in HostedBoats.Values)
				{
					if (value.IsShip)
					{
						num2 = (int)Math.Round((float)num2 + ((Ship)value).Length);
						continue;
					}
					if (value.IsSubmarine)
					{
						num2 = (int)Math.Round((float)num2 + ((Submarine)value).Length);
						continue;
					}
					if (value.IsVehicle)
					{
						num2 = (int)Math.Round((float)num2 + ((Vehicle)value).Length);
						continue;
					}
					throw new NotImplementedException();
				}
				return num - num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100668", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}
	}

	internal bool AddRepository()
	{
		return HostedBoats.Count > 0;
	}

	internal TDictionary<string, ActiveUnit> DestroyRepository()
	{
		return HostedBoats;
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (_SerializerIssuer == null)
			{
				_SerializerIssuer = new StringBuilder();
			}
			else
			{
				_SerializerIssuer.Clear();
			}
			_SerializerIssuer.Append("<DockFacility>");
			_SerializerIssuer.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					_SerializerIssuer.Append("</DockFacility>");
					return _SerializerIssuer.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			_SerializerIssuer.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (_Status != 0)
			{
				StringBuilder stringBuilder = _SerializerIssuer.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				_SerializerIssuer.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			_SerializerIssuer.Append("</DockFacility>");
			return _SerializerIssuer.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100664", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static DockFacility FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			XmlNode xmlNode = Misc.StartRequest(xmlNode_0.ChildNodes, "DBID");
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (DockFacility)concurrentDictionary_0[text];
			}
			int int_ = Conversions.ToInteger(xmlNode.InnerText);
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			DockFacility dockFacility = DBFunctions.GetDockFacility(int_, ref sqliteConnection_);
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (DockFacility)concurrentDictionary_0[text];
			}
			dockFacility.ObjectID_Set(text);
			concurrentDictionary_0.TryAdd(dockFacility.ObjectID, dockFacility);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					string name = xmlNode2.Name;
					if (Operators.CompareString(name, "Status", TextCompare: false) == 0)
					{
						switch (xmlNode2.InnerText)
						{
						default:
							dockFacility._Status = (_ComponentStatus)Conversions.ToByte(xmlNode2.InnerText);
							break;
						case "Operational":
							dockFacility._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							dockFacility._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							dockFacility._Status = _ComponentStatus.Damaged;
							break;
						}
					}
					else if (Operators.CompareString(name, "DamageSeverity", TextCompare: false) == 0)
					{
						dockFacility.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode2.InnerText);
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
			return dockFacility;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100665", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public DockFacility(ActiveUnit activeUnit_0, string string_0, DockFacilityType dockFacilityType_0, DockingPhysicalSize dockingPhysicalSize_0, byte byte_0)
		: base(activeUnit_0)
	{
		HostedBoats = new TDictionary<string, ActiveUnit>();
		Name = string_0;
		Type = dockFacilityType_0;
		Size = dockingPhysicalSize_0;
		Capacity = byte_0;
	}

	public DockingOpsAttemptResult CanHostThisBoat(short short_0, DockingPhysicalSize dockingPhysicalSize_0)
	{
		if (IsPier)
		{
			return ComputeRepository(short_0);
		}
		if (ActiveUnit_DockingOps.CanParkOnDock(dockingPhysicalSize_0))
		{
			return ComputeRepository(short_0);
		}
		return DockingOpsAttemptResult.Cannot_park_on_dock;
	}

	public override void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (HostedBoats.Count > 0)
			{
				foreach (ActiveUnit value in HostedBoats.Values)
				{
					value.ParentScen.DestroyThisUnit(value, "Dock was destroyed", "Host Destruction");
				}
			}
			base.Destroy(side_0, bool_0, bool_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100666", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Damage(_DamageSeverityFactor _DamageSeverityFactor_0)
	{
		try
		{
			int num = 0;
			if (HostedBoats.Count > 0)
			{
				switch (_DamageSeverityFactor_0)
				{
				case _DamageSeverityFactor.Light:
					num = (int)Math.Round((double)HostedBoats.Count / 3.0);
					break;
				case _DamageSeverityFactor.Medium:
					num = (int)Math.Round((double)HostedBoats.Count / 2.0);
					break;
				case _DamageSeverityFactor.Heavy:
					num = (int)Math.Round((double)(2 * HostedBoats.Count) / 3.0);
					break;
				}
			}
			int num2 = 0;
			foreach (ActiveUnit value in HostedBoats.Values)
			{
				string text = "";
				if (Operators.CompareString(value.Name, value.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + value.UnitClass + ")";
				}
				base.ParentPlatform.AddMessage(value.Name + text + "被托管在" + Name + "并且已经被破坏了！", value.Name + " 被摧毁！", LoggedMessage.MessageType.UnitLost, 2, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
				value.ParentScen.DestroyThisUnit(value, value.Name + text + "被托管在" + Name + "并且已经被破坏了！", "Host Destruction");
				num2++;
				if (num2 == num)
				{
					break;
				}
			}
			base.Damage(_DamageSeverityFactor_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100667", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private DockingOpsAttemptResult ComputeRepository(float float_0)
	{
		int maximumSingleBoatLength = MaximumSingleBoatLength;
		if (float_0 <= (float)maximumSingleBoatLength)
		{
			if ((float)TotalCapacity_Free < float_0)
			{
				return DockingOpsAttemptResult.Not_enough_space;
			}
			return DockingOpsAttemptResult.Success;
		}
		return DockingOpsAttemptResult.Boat_too_long;
	}
}
