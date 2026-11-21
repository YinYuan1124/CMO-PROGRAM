using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoContainer : PlatformComponent, ICargoClient, ICargoHost
{
	public enum CargoContainerType
	{
		None = 0,
		Standard = 1001,
		OpenTop = 1002,
		Tank = 2001,
		Pallet = 3001
	}

	public readonly CargoContainerType ContainerType;

	public readonly float Length;

	public readonly float Width;

	public readonly float Height;

	public readonly float Weight;

	public readonly float PayloadMass;

	public readonly float PayloadVolume;

	public readonly bool isHold;

	private CargoType m_ComparatorObserver;

	private float itemObserver;

	private float _SetterObserver;

	private float m_CreatorObserver;

	private bool m_TemplateObserver;

	private CargoType mappingObserver;

	private float _MockObserver;

	private float tagObserver;

	private float m_FieldObserver;

	private bool _QueueObserver;

	private float _RegObserver;

	public Cargo[] OnboardCargo;

	public ICargoHost Parent;

	private float _ParamObserver;

	private float pageObserver;

	private float rulesObserver;

	private float _MethodObserver;

	public Cargo[] CargoArray
	{
		get
		{
			return OnboardCargo;
		}
		set
		{
			OnboardCargo = value;
		}
	}

	public CargoContainer(CargoContainerType cargoContainerType_0, CargoType cargoType_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, bool bool_0, bool bool_1, bool bool_2)
	{
		OnboardCargo = new Cargo[0];
		ContainerType = cargoContainerType_0;
		Length = float_0;
		Width = float_1;
		Height = float_2;
		Weight = float_3;
		PayloadMass = float_4;
		PayloadVolume = float_5;
		isHold = bool_0;
		m_ComparatorObserver = cargoType_0;
		itemObserver = DBFunctions.TestList(Length, Width);
		_SetterObserver = PayloadMass / 1000f;
		m_CreatorObserver = 0f;
		m_TemplateObserver = bool_1;
		mappingObserver = m_ComparatorObserver;
		_MockObserver = itemObserver;
		tagObserver = Weight / 1000f;
		m_FieldObserver = 0f;
		_RegObserver = _MockObserver * Height;
		_QueueObserver = bool_2;
	}

	public void RecalculateCurrentLoad()
	{
		_ParamObserver = 0f;
		pageObserver = 0f;
		rulesObserver = 0f;
		Cargo[] onboardCargo = OnboardCargo;
		Cargo[] array = onboardCargo;
		foreach (Cargo cargo in array)
		{
			_ParamObserver += cargo.RequiredArea;
			pageObserver += cargo.RequiredMass;
			rulesObserver += cargo.RequiredCrewSpace;
		}
	}

	internal float CancelProperty()
	{
		return m_CreatorObserver;
	}

	float ICargoHost.GetCargo_Crew()
	{
		return CancelProperty();
	}

	internal float VerifyProperty()
	{
		return itemObserver;
	}

	float ICargoHost.GetCargo_Area()
	{
		return VerifyProperty();
	}

	internal CargoType ListProperty()
	{
		return m_ComparatorObserver;
	}

	CargoType ICargoHost.GetCargo_Type()
	{
		return ListProperty();
	}

	internal float ResolveProperty()
	{
		return _SetterObserver;
	}

	float ICargoHost.GetCargo_Mass()
	{
		return ResolveProperty();
	}

	public float GetCargo_TowingCapacity()
	{
		return 0f;
	}

	public float GetCargo_MassAvailable()
	{
		return CargoHostHelper.GetAvailableMass(this, OnboardCargo);
	}

	internal bool PostProperty()
	{
		return m_TemplateObserver;
	}

	bool ICargoHost.GetCargo_ParadropCapable()
	{
		return PostProperty();
	}

	internal bool RunProperty()
	{
		return Height > 0f;
	}

	bool ICargoHost.CanStackCargo()
	{
		return RunProperty();
	}

	public float GetCargo_Height()
	{
		return Height;
	}

	internal int StartProperty(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_LOAD_TIME;
	}

	int ICargoHost.GetLoadTime(List<Cargo> list_0)
	{
		return StartProperty(list_0);
	}

	internal int AssetProperty(List<Cargo> list_0)
	{
		return ActiveUnit_DockingOps.DEFAULT_CARGO_UNLOAD_TIME;
	}

	int ICargoHost.GetUnloadTime(List<Cargo> list_0)
	{
		return AssetProperty(list_0);
	}

	internal bool PrintProperty(ICargoClient icargoClient_0)
	{
		bool flag = false;
		CargoContainerContent cargoContainerContent = null;
		if (Parent != null && icargoClient_0.GetRequiredMass() > Parent.GetCargo_MassAvailable())
		{
			return false;
		}
		if (icargoClient_0 is CargoContainerContent)
		{
			cargoContainerContent = (CargoContainerContent)icargoClient_0;
			flag = cargoContainerContent.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel;
		}
		if (ContainerType == CargoContainerType.Tank)
		{
			if (flag)
			{
				CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent;
				float num = PayloadVolume;
				if (OnboardCargo.Count() > 0)
				{
					if (OnboardCargo[0].CargoObjectContainerContents == null)
					{
						num = 0f;
					}
					else
					{
						CargoLiquidFuel cargoLiquidFuel2 = (CargoLiquidFuel)OnboardCargo[0].CargoObjectContainerContents;
						if (cargoLiquidFuel2 == null)
						{
							num = 0f;
						}
						else
						{
							if (cargoLiquidFuel2.FuelType != cargoLiquidFuel.FuelType)
							{
								return false;
							}
							num -= cargoLiquidFuel2.Volume;
						}
					}
				}
				if (cargoLiquidFuel.Volume <= num)
				{
					return true;
				}
			}
		}
		else if (!flag)
		{
			return CargoHostHelper.CanLoad(this, OnboardCargo, icargoClient_0);
		}
		return false;
	}

	bool ICargoHost.CanLoad(ICargoClient icargoClient_0)
	{
		return PrintProperty(icargoClient_0);
	}

	public bool Add(Cargo cargo_0)
	{
		if (PrintProperty(cargo_0.GetCargoClient))
		{
			if (ContainerType == CargoContainerType.Tank)
			{
				if (OnboardCargo.Count() > 0)
				{
					CargoLiquidFuel obj = (CargoLiquidFuel)OnboardCargo[0].GetCargoClient;
					CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargo_0.GetCargoClient;
					obj.CurrentQuantity += cargoLiquidFuel.CurrentQuantity;
					RecalculateCurrentLoad();
					return true;
				}
			}
			else if (cargo_0.CurrentType == Cargo.CargoObjectType.CargoContainerContent && cargo_0.CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
			{
				CargoAmmunition cargoAmmunition = (CargoAmmunition)cargo_0.CargoObjectContainerContents;
				Cargo[] onboardCargo = OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo in array)
				{
					if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainerContent && cargo.CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.Ammunition)
					{
						CargoAmmunition cargoAmmunition2 = (CargoAmmunition)cargo.CargoObjectContainerContents;
						if (cargoAmmunition.int_0 == cargoAmmunition2.int_0)
						{
							cargoAmmunition2.WeaponQuantity += cargoAmmunition.WeaponQuantity;
							RecalculateCurrentLoad();
							return true;
						}
					}
				}
			}
			ArrayExtensions.Add(ref OnboardCargo, cargo_0);
			RecalculateCurrentLoad();
			return true;
		}
		return false;
	}

	public bool Remove(Cargo cargo_0)
	{
		if (OnboardCargo.Contains(cargo_0))
		{
			ArrayExtensions.Remove(ref OnboardCargo, cargo_0);
			RecalculateCurrentLoad();
			return true;
		}
		return false;
	}

	public bool CanTow(ICargoClient icargoClient_0)
	{
		return false;
	}

	public void imethod_1()
	{
		Cargo[] onboardCargo = OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			onboardCargo[i].ResetIDs();
		}
		ResetIDs();
	}

	public void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		Cargo[] onboardCargo = OnboardCargo;
		for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
		{
			onboardCargo[i].Destroy(side_0, bool_0, bool_1);
		}
		Destroy(side_0, bool_0, bool_1);
	}

	internal CargoType DefineProperty()
	{
		CargoContainerType containerType = ContainerType;
		if (containerType != CargoContainerType.OpenTop)
		{
		}
		return mappingObserver;
	}

	CargoType ICargoClient.GetRequiredCargoType()
	{
		return DefineProperty();
	}

	internal float PublishProperty()
	{
		return m_FieldObserver;
	}

	float ICargoClient.GetRequiredCrewSpace()
	{
		return PublishProperty();
	}

	internal float AwakeProperty()
	{
		return _MockObserver;
	}

	float ICargoClient.GetRequiredArea()
	{
		return AwakeProperty();
	}

	public float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_0)
	{
		return AwakeProperty() * (float)int_0;
	}

	internal float QueryProperty()
	{
		return tagObserver + pageObserver;
	}

	float ICargoClient.GetRequiredMass()
	{
		return QueryProperty();
	}

	internal bool ResetProperty()
	{
		return _QueueObserver;
	}

	bool ICargoClient.GetParadropCapable()
	{
		return ResetProperty();
	}

	internal string MapProperty()
	{
		if (OnboardCargo.Count() <= 0)
		{
			return Name;
		}
		string text = Name + " (";
		CargoContainerContent cargoContainerContent = null;
		int num = OnboardCargo.Count();
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			cargoContainerContent = OnboardCargo[i].CargoObjectContainerContents;
			if (cargoContainerContent != null)
			{
				text = text + cargoContainerContent.GetRequiredMass().ToString("N2") + "t " + cargoContainerContent.Name;
				if (i < num - 1)
				{
					text += ", ";
				}
			}
		}
		return text + ")";
	}

	string ICargoClient.GetCargoName()
	{
		return MapProperty();
	}

	internal string SortProperty()
	{
		return ObjectID;
	}

	string ICargoClient.GetCargoObjectID()
	{
		return SortProperty();
	}

	internal int CalcProperty()
	{
		return DBID;
	}

	private int GetCargoObjectDBID()
	{
		return CalcProperty();
	}

	internal _ComponentStatus RateProperty()
	{
		return Status;
	}

	_ComponentStatus ICargoClient.GetCargoObjectStatus()
	{
		return RateProperty();
	}

	internal _DamageSeverityFactor FlushProperty()
	{
		return base.DamageSeverity;
	}

	_DamageSeverityFactor ICargoClient.GetCargoObjectDamageSeverity()
	{
		return FlushProperty();
	}

	internal string ForgotProperty()
	{
		return ReasonForInoperative;
	}

	string ICargoClient.GetCargoObjectReasonForInoperative()
	{
		return ForgotProperty();
	}

	internal string CollectProperty()
	{
		return "Container_" + DBID;
	}

	string ICargoClient.GetCargoObjectLossString()
	{
		return CollectProperty();
	}

	internal string OrderProperty(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return ToXML(ref hashSet_0, scenario_0);
	}

	string ICargoClient.CargoObjectToXML(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return OrderProperty(hashSet_0, scenario_0);
	}

	internal bool RegisterProperty()
	{
		return false;
	}

	bool ICargoClient.WantsToUnload()
	{
		return RegisterProperty();
	}

	internal bool ManageProperty()
	{
		return false;
	}

	bool ICargoClient.IsTowable()
	{
		return ManageProperty();
	}

	internal bool RevertProperty()
	{
		return false;
	}

	bool ICargoClient.IsStackable()
	{
		return RevertProperty();
	}

	internal float CountImporter()
	{
		return 0f;
	}

	float ICargoClient.GetRequiredHeight()
	{
		return CountImporter();
	}

	internal int CustomizeImporter()
	{
		return 1;
	}

	int ICargoClient.GetCargoQuantity()
	{
		return CustomizeImporter();
	}

	internal bool CloneImporter(Cargo cargo_0)
	{
		if (cargo_0 != null && cargo_0.CargoObjectContainer != null && cargo_0.CargoObjectDBID == DBID)
		{
			return true;
		}
		return false;
	}

	bool ICargoClient.isMatch(Cargo cargo_0)
	{
		return CloneImporter(cargo_0);
	}

	public string ToXML(ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<CargoContainer>");
			stringBuilder.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					stringBuilder.Append("</CargoContainer>");
					return stringBuilder.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			stringBuilder.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (!string.IsNullOrEmpty(Name))
			{
				stringBuilder.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			if (_Status != 0)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder2.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				stringBuilder.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			if (OnboardCargo.Count() > 0)
			{
				stringBuilder.Append("<OnboardCargo>");
				Cargo[] onboardCargo = OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo in array)
				{
					stringBuilder.Append(cargo.ToXML(hashSet_0, scenario_0));
				}
				stringBuilder.Append("</OnboardCargo>");
			}
			stringBuilder.Append("</CargoContainer>");
			return stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100901", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return "";
	}

	public static CargoContainer FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, Scenario scenario_0, ActiveUnit activeUnit_0, ICargoHost icargoHost_0 = null)
	{
		try
		{
			CargoContainer cargoContainer = DBFunctions.GetCargoContainer(Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "DBID").InnerText), ref scenario_0);
			cargoContainer.Parent = icargoHost_0;
			string innerText = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (!Information.IsNothing(concurrentDictionary_0))
			{
				if (concurrentDictionary_0.ContainsKey(innerText))
				{
					return (CargoContainer)concurrentDictionary_0[innerText];
				}
				cargoContainer.ObjectID_Set(innerText);
				concurrentDictionary_0.TryAdd(cargoContainer.ObjectID, cargoContainer);
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					try
					{
						switch (xmlNode.Name)
						{
						case "Status":
							switch (xmlNode.InnerText)
							{
							default:
								cargoContainer._Status = (_ComponentStatus)Conversions.ToByte(xmlNode.InnerText);
								break;
							case "Operational":
								cargoContainer._Status = _ComponentStatus.Operational;
								break;
							case "Destroyed":
								cargoContainer._Status = _ComponentStatus.Destroyed;
								break;
							case "Damaged":
								cargoContainer._Status = _ComponentStatus.Damaged;
								break;
							}
							break;
						case "OnboardCargo":
							try
							{
								enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
									Cargo cargo = Cargo.FromXML(ref xmlNode_, ref concurrentDictionary_0, scenario_0, activeUnit_0, cargoContainer);
									ArrayExtensions.Add(ref cargoContainer.OnboardCargo, cargo);
									cargo.ParentPlatform = activeUnit_0;
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
						case "Name":
							cargoContainer.Name = xmlNode.InnerText;
							break;
						case "DamageSeverity":
							cargoContainer.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode.InnerText);
							break;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
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
			cargoContainer.RecalculateCurrentLoad();
			return cargoContainer;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100902", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public int imethod_0()
	{
		throw new NotImplementedException();
	}
}
