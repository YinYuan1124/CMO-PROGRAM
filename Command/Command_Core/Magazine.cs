using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Magazine : PlatformComponent
{
	public delegate void MagazineWeaponRecordAddedEventHandler(string MagazineObjectID, string WeaponRecObjectID);

	public delegate void MagazineWeaponRecordRemovedEventHandler(string MagazineObjectID, string WeaponRecObjectID);

	public GlobalVariables.ArmorRating Armor;

	public int ROF;

	public int Capacity;

	[AccessedThroughProperty("Weapons")]
	[CompilerGenerated]
	private ObservableList<WeaponRec> m_TagDic;

	public bool IsAviationMag;

	private float fieldDic;

	public bool Hypothetical;

	[CompilerGenerated]
	private static MagazineWeaponRecordAddedEventHandler queueDic;

	[CompilerGenerated]
	private static MagazineWeaponRecordRemovedEventHandler m_RegDic;

	[ThreadStatic]
	private static StringBuilder _ParamDic;

	public ObservableList<WeaponRec> Weapons
	{
		[CompilerGenerated]
		get
		{
			return m_TagDic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponRec>> value2 = CheckClass;
			EventHandler<ObservableListModified<WeaponRec>> value3 = ConcatClass;
			ObservableList<WeaponRec> tagDic = m_TagDic;
			if (tagDic != null)
			{
				tagDic.ItemsAdded -= value2;
				tagDic.ItemsRemoved -= value3;
			}
			m_TagDic = value;
			tagDic = m_TagDic;
			if (tagDic != null)
			{
				tagDic.ItemsAdded += value2;
				tagDic.ItemsRemoved += value3;
			}
		}
	}

	public float TimeToFire
	{
		get
		{
			return fieldDic;
		}
		set
		{
			fieldDic = value;
		}
	}

	public static event MagazineWeaponRecordAddedEventHandler MagazineWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler = queueDic;
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler2;
			do
			{
				magazineWeaponRecordAddedEventHandler2 = magazineWeaponRecordAddedEventHandler;
				MagazineWeaponRecordAddedEventHandler value2 = (MagazineWeaponRecordAddedEventHandler)Delegate.Combine(magazineWeaponRecordAddedEventHandler2, value);
				magazineWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref queueDic, value2, magazineWeaponRecordAddedEventHandler2);
			}
			while ((object)magazineWeaponRecordAddedEventHandler != magazineWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler = queueDic;
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler2;
			do
			{
				magazineWeaponRecordAddedEventHandler2 = magazineWeaponRecordAddedEventHandler;
				MagazineWeaponRecordAddedEventHandler value2 = (MagazineWeaponRecordAddedEventHandler)Delegate.Remove(magazineWeaponRecordAddedEventHandler2, value);
				magazineWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref queueDic, value2, magazineWeaponRecordAddedEventHandler2);
			}
			while ((object)magazineWeaponRecordAddedEventHandler != magazineWeaponRecordAddedEventHandler2);
		}
	}

	public static event MagazineWeaponRecordRemovedEventHandler MagazineWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler = m_RegDic;
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler2;
			do
			{
				magazineWeaponRecordRemovedEventHandler2 = magazineWeaponRecordRemovedEventHandler;
				MagazineWeaponRecordRemovedEventHandler value2 = (MagazineWeaponRecordRemovedEventHandler)Delegate.Combine(magazineWeaponRecordRemovedEventHandler2, value);
				magazineWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref m_RegDic, value2, magazineWeaponRecordRemovedEventHandler2);
			}
			while ((object)magazineWeaponRecordRemovedEventHandler != magazineWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler = m_RegDic;
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler2;
			do
			{
				magazineWeaponRecordRemovedEventHandler2 = magazineWeaponRecordRemovedEventHandler;
				MagazineWeaponRecordRemovedEventHandler value2 = (MagazineWeaponRecordRemovedEventHandler)Delegate.Remove(magazineWeaponRecordRemovedEventHandler2, value);
				magazineWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref m_RegDic, value2, magazineWeaponRecordRemovedEventHandler2);
			}
			while ((object)magazineWeaponRecordRemovedEventHandler != magazineWeaponRecordRemovedEventHandler2);
		}
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		foreach (WeaponRec weapon in Weapons)
		{
			weapon.ResetIDs();
		}
	}

	public string ToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			if (_ParamDic == null)
			{
				_ParamDic = new StringBuilder();
			}
			else
			{
				_ParamDic.Clear();
			}
			_ParamDic.Append("<Magazine>");
			_ParamDic.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					_ParamDic.Append("</Magazine>");
					return _ParamDic.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			_ParamDic.Append("<TTF>").Append(XmlConvert.ToString(fieldDic)).Append("</TTF>");
			if (_Status != 0)
			{
				StringBuilder stringBuilder = _ParamDic.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				_ParamDic.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			_ParamDic.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (m_TagDic.Count > 0)
			{
				_ParamDic.Append("<Weapons>");
				int num = m_TagDic.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_ParamDic.Append(m_TagDic[i].ToXML(hashSet_0, scenario_0));
				}
				_ParamDic.Append("</Weapons>");
			}
			_ParamDic.Append("</Magazine>");
			return _ParamDic.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100671", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Magazine()
	{
		Weapons = new ObservableList<WeaponRec>();
	}

	public static Magazine FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		Magazine result = null;
		try
		{
			Magazine magazine = new Magazine();
			XmlNode xmlNode = Misc.StartRequest(xmlNode_0.ChildNodes, "DBID");
			magazine = DBFunctions.GetMagazine(Information.IsNothing(xmlNode) ? DBFunctions.smethod_1(Misc.StartRequest(xmlNode_0.ChildNodes, "Name").InnerText, scenario_0.DBConnection) : Conversions.ToInteger(xmlNode.InnerText), ref scenario_0, bool_0: false);
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (concurrentDictionary_0.ContainsKey(innerText))
			{
				result = (Magazine)concurrentDictionary_0[innerText];
				return result;
			}
			magazine.ObjectID_Set(innerText);
			concurrentDictionary_0.TryAdd(magazine.ObjectID, magazine);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					switch (xmlNode2.Name)
					{
					case "Weapons":
						try
						{
							enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								WeaponRec item = WeaponRec.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
								magazine.Weapons.Add(item);
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
					case "TimeToFire":
					case "TTF":
						magazine.fieldDic = XmlConvert.ToSingle(xmlNode2.InnerText);
						break;
					case "Status":
						switch (xmlNode2.InnerText)
						{
						default:
							magazine._Status = (_ComponentStatus)Conversions.ToByte(xmlNode2.InnerText);
							break;
						case "Operational":
							magazine._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							magazine._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							magazine._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "DamageSeverity":
						magazine.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode2.InnerText);
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
			result = magazine;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100672", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public void ResetTimeToFire()
	{
		TimeToFire = ROF;
	}

	public Magazine(ActiveUnit activeUnit_0, int int_0, string string_0, GlobalVariables.ArmorRating armorRating_0, int int_1, int int_2, bool bool_0)
		: base(activeUnit_0)
	{
		Weapons = new ObservableList<WeaponRec>();
		DBID = int_0;
		Name = string_0;
		Armor = armorRating_0;
		ROF = int_1;
		fieldDic = ROF;
		Capacity = int_2;
		IsAviationMag = bool_0;
	}

	public string WeaponSpaceinMagazine(int int_0)
	{
		string result = null;
		try
		{
			int int_ = 0;
			int int_2 = 0;
			if (InitClass(ref int_, ref int_2) < Capacity)
			{
				foreach (WeaponRec weapon in Weapons)
				{
					if (weapon.GetReferenceWeapon(base.ParentPlatform.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad)
					{
						result = "OK";
						return result;
					}
				}
				result = "找不到合适的武器记录";
				return result;
			}
			result = "Magazine full";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100673", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public string AddWeapon(int int_0, bool bool_0 = false)
	{
		string result = null;
		try
		{
			int int_ = 0;
			int int_2 = 0;
			int num = InitClass(ref int_, ref int_2);
			if (Capacity < 10000)
			{
				if (bool_0)
				{
					if (num > Capacity)
					{
						result = "Magazine full";
						return result;
					}
				}
				else if (num >= Capacity)
				{
					result = "Magazine full";
					return result;
				}
			}
			foreach (WeaponRec weapon in Weapons)
			{
				if (weapon.GetReferenceWeapon(base.ParentPlatform.ParentScen).DBID == int_0 && weapon.CurrentLoad < weapon.MaxLoad)
				{
					weapon.CurrentLoad++;
					RaiseEventStatusChanged();
					result = "OK";
					return result;
				}
			}
			result = "找不到合适的武器记录";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100673", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal int InitClass(ref int int_0, ref int int_1)
	{
		int_0 = 0;
		int_1 = 0;
		foreach (WeaponRec weapon in Weapons)
		{
			if (weapon.CurrentLoad == 0)
			{
				continue;
			}
			if (weapon.Multiple <= 1)
			{
				int_0 += weapon.CurrentLoad;
				continue;
			}
			float num = (float)weapon.CurrentLoad / (float)weapon.Multiple;
			if (num == (float)(int)Math.Round(num))
			{
				int_0 += (int)Math.Round(num);
				continue;
			}
			int_1++;
			int_0 += (int)Math.Floor((double)weapon.CurrentLoad / (double)weapon.Multiple);
		}
		return int_0 + int_1;
	}

	public string RemoveWeapon(int int_0, bool bool_0, ref float float_0)
	{
		bool flag = false;
		bool flag2 = false;
		string result = null;
		try
		{
			int num = Weapons.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				WeaponRec weaponRec = Weapons[i];
				if (weaponRec.int_0 != int_0)
				{
					continue;
				}
				if (weaponRec.CurrentLoad <= 0)
				{
					flag2 = true;
					continue;
				}
				if (!bool_0)
				{
					if (weaponRec.TimeToFire != 0f)
					{
						flag = true;
						continue;
					}
					weaponRec.CurrentLoad--;
					float_0 = weaponRec.ReloadTime;
					RaiseEventStatusChanged();
					result = "OK";
					return result;
				}
				weaponRec.CurrentLoad--;
				weaponRec.ResetTimeToFire();
				RaiseEventStatusChanged();
				result = "OK";
				return result;
			}
			if (flag)
			{
				result = "已找到合适的武器记录但尚未准备好";
				return result;
			}
			if (flag2)
			{
				result = "找不到合适的武器记录";
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100674", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void CheckClass(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			queueDic?.Invoke(ObjectID, item.ObjectID);
		}
	}

	private void ConcatClass(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			if (!Information.IsNothing(item))
			{
				m_RegDic?.Invoke(ObjectID, item.ObjectID);
			}
		}
	}
}
