using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Command.Filters;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitStatus_WPF : System.Windows.Controls.UserControl, IComponentConnector
{
	public delegate void PanelSizeChangedEventHandler();

	public delegate void DamageDetailsFormRequestedEventHandler();

	public delegate void MagazinesFormRequestedEventHandler();

	public delegate void WeaponsFormRequestedEventHandler();

	public delegate void SensorsFormRequestedEventHandler();

	public delegate void CommsFormRequestedEventHandler();

	[CompilerGenerated]
	private sealed class ClientMerchantPage
	{
		public string Local_UCString;

		internal bool RestartInterruptibleMethod(ActiveUnit theAU)
		{
			return string.CompareOrdinal(Misc.ReadRequest(theAU.UnitClass), Local_UCString) == 0;
		}
	}

	[CompilerGenerated]
	private static PanelSizeChangedEventHandler m_AccountVisitor;

	[CompilerGenerated]
	private static CommsFormRequestedEventHandler stateVisitor;

	private Group _AuthenticationVisitor;

	private ActiveUnit paramsVisitor;

	private Contact _InfoVisitor;

	private string _HelperVisitor;

	private int m_MapperVisitor;

	private DBOps.DBFileCheckResult _ManagerVisitor;

	private BitmapImage m_GetterVisitor;

	private string m_ProducerVisitor;

	private BitmapImage m_ProcVisitor;

	[CompilerGenerated]
	private static DamageDetailsFormRequestedEventHandler _StructExporter;

	[CompilerGenerated]
	private static MagazinesFormRequestedEventHandler _MerchantExporter;

	[CompilerGenerated]
	private static WeaponsFormRequestedEventHandler m_CallbackExporter;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler decoratorExporter;

	private bool processExporter;

	internal Grid MasterGrid;

	internal System.Windows.Controls.Label Label_UnitName;

	internal Image Image_UnitImage;

	internal TextBlock OuterTextBlock_UnitClass;

	internal Hyperlink Hyperlink_UnitClass;

	internal Run TextBlock_UnitClass;

	internal TextBlock OuterTextBlock_UnitCategory;

	internal Run TextBlock_UnitCategory;

	internal TextBlock OuterTextBlock_UnitType;

	internal Run TextBlock_UnitType;

	internal TextBlock OuterTextBlock_FiringParent;

	internal Run TextBlock_FiringParent;

	internal System.Windows.Controls.Label Label_UnitProficiency;

	internal System.Windows.Controls.Button Button_ContactReport;

	internal System.Windows.Controls.Button Button_UnitMessageLog;

	internal Expander Expander_GroupMembers;

	internal System.Windows.Controls.ListView ListView_GroupMembers;

	internal TextBlock TextBlock_Loadout;

	internal Hyperlink Hyperlink_Loadout;

	internal Run TextBlock_LoadoutName;

	internal System.Windows.Controls.Label Label_UnitSide;

	internal System.Windows.Controls.Label Label_UnitCourse;

	internal System.Windows.Controls.Label Label_UnitSpeed;

	internal System.Windows.Controls.Label Label_UnitAlt;

	internal System.Windows.Controls.CheckBox CB_GroupLeadSlowDown;

	internal System.Windows.Controls.Label Label_DamageLabel;

	internal TextBlock Label_UnitDamage;

	internal System.Windows.Controls.Button Button_Damage;

	internal System.Windows.Controls.Label ComponentStatusLabel;

	internal DockPanel ComponentStatusDockPanel;

	internal System.Windows.Controls.ProgressBar PB_ComponentsDestroyed;

	internal System.Windows.Controls.ProgressBar PB_ComponentsHeavyDamage;

	internal System.Windows.Controls.ProgressBar PB_ComponentsMediumDamage;

	internal System.Windows.Controls.ProgressBar PB_ComponentsLightDamage;

	internal System.Windows.Controls.ProgressBar PB_ComponentsOK;

	internal System.Windows.Controls.Label Label_FireDamage;

	internal System.Windows.Controls.ProgressBar PB_FireDamage;

	internal System.Windows.Controls.Label Label_FloodDamage;

	internal System.Windows.Controls.ProgressBar PB_FloodDamage;

	internal System.Windows.Controls.Label Label_GTolerance;

	internal System.Windows.Controls.ProgressBar PB_GTolerance;

	internal System.Windows.Controls.Button Button_MCM;

	internal System.Windows.Controls.Button Button_CargoOps;

	internal System.Windows.Controls.Button Button_Magazines;

	internal System.Windows.Controls.Button Button_DockOps;

	internal System.Windows.Controls.Button Button_AirOps;

	internal System.Windows.Controls.Label Label_Supply;

	internal System.Windows.Controls.ComboBox Combo_Supplier;

	internal DockPanel Dockpanel_EditHosted;

	internal System.Windows.Controls.Button Button_EditHostCargo;

	internal System.Windows.Controls.Button Button_EditHostedBoats;

	internal System.Windows.Controls.Button Button_EditHostedAC;

	internal TextBlock TextBlock_AssignedHost;

	internal TextBlock TextBlock_Mission;

	internal Hyperlink Hyperlink_Mission;

	internal Run TextBlock_MissionName;

	internal TextBlock TextBlock_QueuedMission;

	internal System.Windows.Controls.ToolTip tip1;

	internal TextBlock TextBlock_UnitStatus;

	internal TextBlock TextBlock_PrimaryTarget;

	internal TextBlock TextBlock_TimeUnderway;

	internal Expander Expander_TankerClients;

	internal System.Windows.Controls.ListView ListView_TankerClients;

	internal System.Windows.Controls.Button Button_Sensors;

	internal System.Windows.Controls.Button Button_Comms;

	internal System.Windows.Controls.Button Button_Weapons;

	internal System.Windows.Controls.Label Label_ContactWRAType;

	private bool _contentLoaded;

	public static event PanelSizeChangedEventHandler PanelSizeChanged
	{
		[CompilerGenerated]
		add
		{
			PanelSizeChangedEventHandler panelSizeChangedEventHandler = m_AccountVisitor;
			PanelSizeChangedEventHandler panelSizeChangedEventHandler2;
			do
			{
				panelSizeChangedEventHandler2 = panelSizeChangedEventHandler;
				PanelSizeChangedEventHandler value2 = (PanelSizeChangedEventHandler)Delegate.Combine(panelSizeChangedEventHandler2, value);
				panelSizeChangedEventHandler = Interlocked.CompareExchange(ref m_AccountVisitor, value2, panelSizeChangedEventHandler2);
			}
			while ((object)panelSizeChangedEventHandler != panelSizeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PanelSizeChangedEventHandler panelSizeChangedEventHandler = m_AccountVisitor;
			PanelSizeChangedEventHandler panelSizeChangedEventHandler2;
			do
			{
				panelSizeChangedEventHandler2 = panelSizeChangedEventHandler;
				PanelSizeChangedEventHandler value2 = (PanelSizeChangedEventHandler)Delegate.Remove(panelSizeChangedEventHandler2, value);
				panelSizeChangedEventHandler = Interlocked.CompareExchange(ref m_AccountVisitor, value2, panelSizeChangedEventHandler2);
			}
			while ((object)panelSizeChangedEventHandler != panelSizeChangedEventHandler2);
		}
	}

	public static event DamageDetailsFormRequestedEventHandler DamageDetailsFormRequested
	{
		[CompilerGenerated]
		add
		{
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler = _StructExporter;
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler2;
			do
			{
				damageDetailsFormRequestedEventHandler2 = damageDetailsFormRequestedEventHandler;
				DamageDetailsFormRequestedEventHandler value2 = (DamageDetailsFormRequestedEventHandler)Delegate.Combine(damageDetailsFormRequestedEventHandler2, value);
				damageDetailsFormRequestedEventHandler = Interlocked.CompareExchange(ref _StructExporter, value2, damageDetailsFormRequestedEventHandler2);
			}
			while ((object)damageDetailsFormRequestedEventHandler != damageDetailsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler = _StructExporter;
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler2;
			do
			{
				damageDetailsFormRequestedEventHandler2 = damageDetailsFormRequestedEventHandler;
				DamageDetailsFormRequestedEventHandler value2 = (DamageDetailsFormRequestedEventHandler)Delegate.Remove(damageDetailsFormRequestedEventHandler2, value);
				damageDetailsFormRequestedEventHandler = Interlocked.CompareExchange(ref _StructExporter, value2, damageDetailsFormRequestedEventHandler2);
			}
			while ((object)damageDetailsFormRequestedEventHandler != damageDetailsFormRequestedEventHandler2);
		}
	}

	public static event MagazinesFormRequestedEventHandler MagazinesFormRequested
	{
		[CompilerGenerated]
		add
		{
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler = _MerchantExporter;
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler2;
			do
			{
				magazinesFormRequestedEventHandler2 = magazinesFormRequestedEventHandler;
				MagazinesFormRequestedEventHandler value2 = (MagazinesFormRequestedEventHandler)Delegate.Combine(magazinesFormRequestedEventHandler2, value);
				magazinesFormRequestedEventHandler = Interlocked.CompareExchange(ref _MerchantExporter, value2, magazinesFormRequestedEventHandler2);
			}
			while ((object)magazinesFormRequestedEventHandler != magazinesFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler = _MerchantExporter;
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler2;
			do
			{
				magazinesFormRequestedEventHandler2 = magazinesFormRequestedEventHandler;
				MagazinesFormRequestedEventHandler value2 = (MagazinesFormRequestedEventHandler)Delegate.Remove(magazinesFormRequestedEventHandler2, value);
				magazinesFormRequestedEventHandler = Interlocked.CompareExchange(ref _MerchantExporter, value2, magazinesFormRequestedEventHandler2);
			}
			while ((object)magazinesFormRequestedEventHandler != magazinesFormRequestedEventHandler2);
		}
	}

	public static event WeaponsFormRequestedEventHandler WeaponsFormRequested
	{
		[CompilerGenerated]
		add
		{
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler = m_CallbackExporter;
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler2;
			do
			{
				weaponsFormRequestedEventHandler2 = weaponsFormRequestedEventHandler;
				WeaponsFormRequestedEventHandler value2 = (WeaponsFormRequestedEventHandler)Delegate.Combine(weaponsFormRequestedEventHandler2, value);
				weaponsFormRequestedEventHandler = Interlocked.CompareExchange(ref m_CallbackExporter, value2, weaponsFormRequestedEventHandler2);
			}
			while ((object)weaponsFormRequestedEventHandler != weaponsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler = m_CallbackExporter;
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler2;
			do
			{
				weaponsFormRequestedEventHandler2 = weaponsFormRequestedEventHandler;
				WeaponsFormRequestedEventHandler value2 = (WeaponsFormRequestedEventHandler)Delegate.Remove(weaponsFormRequestedEventHandler2, value);
				weaponsFormRequestedEventHandler = Interlocked.CompareExchange(ref m_CallbackExporter, value2, weaponsFormRequestedEventHandler2);
			}
			while ((object)weaponsFormRequestedEventHandler != weaponsFormRequestedEventHandler2);
		}
	}

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = decoratorExporter;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref decoratorExporter, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = decoratorExporter;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref decoratorExporter, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public static event CommsFormRequestedEventHandler CommsFormRequested
	{
		[CompilerGenerated]
		add
		{
			CommsFormRequestedEventHandler commsFormRequestedEventHandler = stateVisitor;
			CommsFormRequestedEventHandler commsFormRequestedEventHandler2;
			do
			{
				commsFormRequestedEventHandler2 = commsFormRequestedEventHandler;
				CommsFormRequestedEventHandler value2 = (CommsFormRequestedEventHandler)Delegate.Combine(commsFormRequestedEventHandler2, value);
				commsFormRequestedEventHandler = Interlocked.CompareExchange(ref stateVisitor, value2, commsFormRequestedEventHandler2);
			}
			while ((object)commsFormRequestedEventHandler != commsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CommsFormRequestedEventHandler commsFormRequestedEventHandler = stateVisitor;
			CommsFormRequestedEventHandler commsFormRequestedEventHandler2;
			do
			{
				commsFormRequestedEventHandler2 = commsFormRequestedEventHandler;
				CommsFormRequestedEventHandler value2 = (CommsFormRequestedEventHandler)Delegate.Remove(commsFormRequestedEventHandler2, value);
				commsFormRequestedEventHandler = Interlocked.CompareExchange(ref stateVisitor, value2, commsFormRequestedEventHandler2);
			}
			while ((object)commsFormRequestedEventHandler != commsFormRequestedEventHandler2);
		}
	}

	private string InitInterruptibleSetter(ActiveUnit activeUnit_0)
	{
		string text;
		if (activeUnit_0.IsAircraft)
		{
			text = "Aircraft";
		}
		else if (activeUnit_0.IsShip)
		{
			text = "Ship";
		}
		else if (activeUnit_0.IsSubmarine)
		{
			text = "Submarine";
		}
		else if (activeUnit_0.IsFacility)
		{
			text = "Facility";
		}
		else if (activeUnit_0.IsMobileGroundUnit)
		{
			text = "GroundUnit";
		}
		else if (activeUnit_0.IsSatellite)
		{
			text = "Satellite";
		}
		else
		{
			if (!activeUnit_0.IsWeapon)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			text = "Weapon";
		}
		string text2 = "";
		switch (DBOps.GetDBRecordByHash(Client.CurrentScenario.DBUsed, ref _ManagerVisitor, bool_0: false, bool_1: false).DBID)
		{
		case 1:
			text2 = "DB3000";
			break;
		case 2:
			text2 = "CWDB";
			break;
		case 3:
			text2 = "WW2DB";
			break;
		}
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Images\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		return Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + ".jpg");
	}

	public UnitStatus_WPF()
	{
		base.SizeChanged += VisitInterruptibleSetter;
		base.Loaded += AssetInterruptibleSetter;
		_AuthenticationVisitor = null;
		paramsVisitor = null;
		_InfoVisitor = null;
		_HelperVisitor = null;
		InitializeComponent();
	}

	private void CheckInterruptibleSetter(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.OrderIssuer().Count == 0)
		{
			PB_ComponentsDestroyed.Width = 0.0;
			PB_ComponentsHeavyDamage.Width = 0.0;
			PB_ComponentsMediumDamage.Width = 0.0;
			PB_ComponentsLightDamage.Width = 0.0;
			PB_ComponentsOK.Width = 0.0;
			return;
		}
		int num = (int)Math.Round(base.ActualWidth * (2.0 / 3.0));
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		foreach (PlatformComponent item in activeUnit_0.OrderIssuer())
		{
			switch (item.Status)
			{
			case PlatformComponent._ComponentStatus.Operational:
				num6++;
				break;
			case PlatformComponent._ComponentStatus.Damaged:
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num3++;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num4++;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num2++;
					break;
				}
				break;
			case PlatformComponent._ComponentStatus.Destroyed:
				num5++;
				break;
			}
		}
		try
		{
			if (num5 <= 0)
			{
				PB_ComponentsDestroyed.Width = 0.0;
			}
			else
			{
				PB_ComponentsDestroyed.Width = (int)Math.Round((double)(num * num5) / (double)activeUnit_0.OrderIssuer().Count);
			}
			if (num2 <= 0)
			{
				PB_ComponentsHeavyDamage.Width = 0.0;
			}
			else
			{
				PB_ComponentsHeavyDamage.Width = (int)Math.Round((double)(num * num2) / (double)activeUnit_0.OrderIssuer().Count);
			}
			if (num4 <= 0)
			{
				PB_ComponentsMediumDamage.Width = 0.0;
			}
			else
			{
				PB_ComponentsMediumDamage.Width = (int)Math.Round((double)(num * num4) / (double)activeUnit_0.OrderIssuer().Count);
			}
			if (num3 <= 0)
			{
				PB_ComponentsLightDamage.Width = 0.0;
			}
			else
			{
				PB_ComponentsLightDamage.Width = (int)Math.Round((double)(num * num3) / (double)activeUnit_0.OrderIssuer().Count);
			}
			if (num6 <= 0)
			{
				PB_ComponentsOK.Width = 0.0;
			}
			else
			{
				PB_ComponentsOK.Width = (int)Math.Round((double)(num * num6) / (double)activeUnit_0.OrderIssuer().Count);
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

	private void ConcatInterruptibleSetter(ActiveUnit activeUnit_0)
	{
		try
		{
			m_ProducerVisitor = StrategyRegistryFilter.ConnectInterruptibleComparator(activeUnit_0);
			if (Operators.CompareString(_HelperVisitor, m_ProducerVisitor, TextCompare: true) != 0)
			{
				m_ProcVisitor = StrategyRegistryFilter.CountInterruptibleComparator(m_ProducerVisitor);
				if (m_ProcVisitor == null)
				{
					Image_UnitImage.Source = null;
					Image_UnitImage.Visibility = Visibility.Collapsed;
					StrategyRegistryFilter.CustomizeInterruptibleComparator(m_ProducerVisitor);
				}
				else
				{
					InterruptInterruptibleSetter();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (Image_UnitImage.Source != null)
			{
				Image_UnitImage.Source = null;
				Image_UnitImage.Visibility = Visibility.Collapsed;
			}
			exception_.Data.Add("Error at 200371", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InterruptInterruptibleSetter()
	{
		if (Operators.CompareString(_HelperVisitor, m_ProducerVisitor, TextCompare: true) == 0 && Image_UnitImage.Source != null)
		{
			return;
		}
		if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
		{
			if ((m_ProcVisitor == null) & (m_GetterVisitor != null))
			{
				Image_UnitImage.Source = null;
				Image_UnitImage.Visibility = Visibility.Collapsed;
				m_GetterVisitor = null;
			}
			else if (!((m_ProcVisitor == null) & (m_GetterVisitor == null)))
			{
				if (m_ProcVisitor != null && m_GetterVisitor != null && Operators.CompareString(m_ProcVisitor.ToString(), m_GetterVisitor.ToString(), TextCompare: true) == 0)
				{
					Image_UnitImage.Visibility = Visibility.Visible;
					if (Image_UnitImage.Source == null)
					{
						Image_UnitImage.Source = m_ProcVisitor;
					}
				}
				else
				{
					Image_UnitImage.Source = m_ProcVisitor;
					Image_UnitImage.Visibility = Visibility.Visible;
					m_GetterVisitor = m_ProcVisitor;
				}
			}
		}
		else if (m_GetterVisitor != null)
		{
			Image_UnitImage.Source = null;
			Image_UnitImage.Visibility = Visibility.Collapsed;
			m_GetterVisitor = null;
		}
		_HelperVisitor = m_ProducerVisitor;
	}

	private void RemoveInterruptibleSetter(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
		SetTextBlock_MissionVisibility(Visibility.Collapsed);
		TextBlock_Loadout.Visibility = Visibility.Collapsed;
		Expander_GroupMembers.Visibility = Visibility.Collapsed;
		Expander_TankerClients.Visibility = Visibility.Collapsed;
		TextBlock_UnitStatus.Visibility = Visibility.Collapsed;
		TextBlock_PrimaryTarget.Visibility = Visibility.Collapsed;
		Button_ContactReport.Visibility = Visibility.Visible;
		Button_Weapons.Visibility = Visibility.Hidden;
		Button_MCM.Visibility = Visibility.Collapsed;
		SetTextBlock_AssignedHostVisibility(Visibility.Collapsed);
		Label_UnitProficiency.Visibility = Visibility.Collapsed;
		Button_Damage.Visibility = Visibility.Collapsed;
		method_0(Visibility.Collapsed);
		SetCB_GroupLeadSlowDownVisibility(Visibility.Collapsed);
		Button_CargoOps.Visibility = Visibility.Collapsed;
		Button_UnitMessageLog.Visibility = Visibility.Collapsed;
		Label_GTolerance.Visibility = Visibility.Collapsed;
		PB_GTolerance.Visibility = Visibility.Collapsed;
		Dockpanel_EditHosted.Visibility = Visibility.Collapsed;
		TextBlock_TimeUnderway.Visibility = Visibility.Collapsed;
		Label_Supply.Visibility = Visibility.Collapsed;
		Combo_Supplier.Visibility = Visibility.Collapsed;
		_InfoVisitor = (Contact)unit_0;
		if (_InfoVisitor.ActualUnit == null || (!side_0.Contacts.ContainsKey(_InfoVisitor.ActualUnit.ObjectID) && !side_0.BaseContacts.ContainsKey(_InfoVisitor.ActualUnit.ObjectID)))
		{
			return;
		}
		Label_UnitName.Content = _InfoVisitor.Name;
		switch (_InfoVisitor.IDStatus)
		{
		case Contact_Base.IdentificationStatus.Unknown:
			OuterTextBlock_UnitCategory.Visibility = Visibility.Collapsed;
			OuterTextBlock_UnitClass.Visibility = Visibility.Collapsed;
			Hyperlink_UnitClass.IsEnabled = false;
			Image_UnitImage.Source = null;
			Image_UnitImage.Visibility = Visibility.Collapsed;
			break;
		case Contact_Base.IdentificationStatus.KnownDomain:
			OuterTextBlock_UnitCategory.Visibility = Visibility.Visible;
			TextBlock_UnitCategory.Text = _InfoVisitor.DescriptionString;
			OuterTextBlock_UnitClass.Visibility = Visibility.Collapsed;
			Hyperlink_UnitClass.IsEnabled = false;
			Image_UnitImage.Source = null;
			Image_UnitImage.Visibility = Visibility.Collapsed;
			break;
		case Contact_Base.IdentificationStatus.KnownType:
			OuterTextBlock_UnitCategory.Visibility = Visibility.Visible;
			if (_InfoVisitor.ActualUnit.IsFacility)
			{
				Facility facility2 = (Facility)_InfoVisitor.ActualUnit;
				TextBlock_UnitCategory.Text = facility2.Type_Description;
			}
			else
			{
				TextBlock_UnitCategory.Text = _InfoVisitor.ActualUnit.SubTypeDescription;
			}
			OuterTextBlock_UnitClass.Visibility = Visibility.Collapsed;
			Hyperlink_UnitClass.IsEnabled = false;
			Image_UnitImage.Source = null;
			Image_UnitImage.Visibility = Visibility.Collapsed;
			break;
		case Contact_Base.IdentificationStatus.KnownClass:
		case Contact_Base.IdentificationStatus.PreciseID:
			OuterTextBlock_UnitCategory.Visibility = Visibility.Visible;
			if (_InfoVisitor.ActualUnit.IsFacility)
			{
				Facility facility = (Facility)_InfoVisitor.ActualUnit;
				TextBlock_UnitCategory.Text = facility.Type_Description;
			}
			else
			{
				TextBlock_UnitCategory.Text = _InfoVisitor.ActualUnit.SubTypeDescription;
			}
			OuterTextBlock_UnitClass.Visibility = Visibility.Visible;
			TextBlock_UnitClass.Text = Misc.ReadRequest(_InfoVisitor.ActualUnit.UnitClass);
			Hyperlink_UnitClass.IsEnabled = true;
			if (_InfoVisitor.Type != Contact_Base.ContactType.Installation && _InfoVisitor.Type != Contact_Base.ContactType.MobileGroup && _InfoVisitor.Type != Contact_Base.ContactType.AirBase && _InfoVisitor.Type != Contact_Base.ContactType.NavalBase)
			{
				ConcatInterruptibleSetter(_InfoVisitor.ActualUnit);
				break;
			}
			Image_UnitImage.Source = null;
			Image_UnitImage.Visibility = Visibility.Collapsed;
			break;
		}
		Label_UnitCourse.Content = "朝向：" + _InfoVisitor.HeadingString();
		if ((_InfoVisitor.Type == Contact_Base.ContactType.Air || _InfoVisitor.Type == Contact_Base.ContactType.Missile) && _InfoVisitor.AltitudeIsKnown)
		{
			Label_UnitSpeed.Content = "速度：" + Conversions.ToString((int)Math.Round(_InfoVisitor.CurrentSpeed)) + " 节 (马赫 " + $"{Physics.CompareStub(_InfoVisitor.GetCurrentAltitude(), _InfoVisitor.CurrentSpeed):0.00}" + ")";
		}
		else
		{
			Label_UnitSpeed.Content = "速度：" + _InfoVisitor.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit, "Unknown");
		}
		if (_InfoVisitor.SideIsKnown)
		{
			if (_InfoVisitor.ActualUnit.GetUnitSide() != null)
			{
				Label_UnitSide.Content = "分方：" + _InfoVisitor.ActualUnit.GetUnitSide().Name;
			}
		}
		else
		{
			Label_UnitSide.Content = "分方：未知";
		}
		if (!_InfoVisitor.ActualUnit.IsShip && !_InfoVisitor.ActualUnit.IsFacility)
		{
			Label_UnitAlt.Content = "高度：" + _InfoVisitor.AltitudeString(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet);
		}
		else
		{
			Label_UnitAlt.Content = "";
		}
		method_1(Visibility.Collapsed);
		if (!_InfoVisitor.ActualUnit.IsAircraft && !_InfoVisitor.ActualUnit.IsWeapon)
		{
			method_4(Visibility.Visible);
			method_3(Visibility.Visible);
			if (!_InfoVisitor.ActualUnit.IsShip && !_InfoVisitor.ActualUnit.IsSubmarine)
			{
				method_2(Visibility.Collapsed);
			}
			else
			{
				method_2(Visibility.Visible);
			}
			Label_UnitDamage.Text = "损伤：" + Misc.FlushRequest(_InfoVisitor.BDA_StructuralIntegrity);
			if (!_InfoVisitor.ActualUnit.IsShip && !_InfoVisitor.ActualUnit.IsSubmarine)
			{
				Label_FloodDamage.Visibility = Visibility.Collapsed;
				PB_FloodDamage.Visibility = Visibility.Collapsed;
			}
			else
			{
				Label_FloodDamage.Visibility = Visibility.Visible;
				PB_FloodDamage.Visibility = Visibility.Visible;
				if (_InfoVisitor.BDA_FloodLevel.HasValue)
				{
					Label_FloodDamage.Content = "漏水：";
					ActiveUnit_Damage.FloodingIntensityLevel? bDA_FloodLevel = _InfoVisitor.BDA_FloodLevel;
					byte? b = (byte?)bDA_FloodLevel;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						PB_FloodDamage.Value = 0.0;
					}
					else
					{
						b = (byte?)bDA_FloodLevel;
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							PB_FloodDamage.Value = 25.0;
						}
						else
						{
							b = (byte?)bDA_FloodLevel;
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								PB_FloodDamage.Value = 50.0;
							}
							else
							{
								b = (byte?)bDA_FloodLevel;
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									PB_FloodDamage.Value = 75.0;
								}
								else
								{
									b = (byte?)bDA_FloodLevel;
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null).GetValueOrDefault())
									{
										PB_FloodDamage.Value = 100.0;
									}
								}
							}
						}
					}
				}
				else
				{
					PB_FloodDamage.Visibility = Visibility.Collapsed;
					Label_FloodDamage.Content = "漏水：未知";
				}
			}
			Label_FireDamage.Visibility = Visibility.Visible;
			PB_FireDamage.Visibility = Visibility.Visible;
			if (_InfoVisitor.BDA_FireLevel.HasValue)
			{
				Label_FireDamage.Content = "火情：";
				ActiveUnit_Damage.FireIntensityLevel? bDA_FireLevel = _InfoVisitor.BDA_FireLevel;
				byte? b2 = (byte?)bDA_FireLevel;
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					PB_FireDamage.Value = 0.0;
				}
				else
				{
					b2 = (byte?)bDA_FireLevel;
					if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						PB_FireDamage.Value = 25.0;
					}
					else
					{
						b2 = (byte?)bDA_FireLevel;
						if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							PB_FireDamage.Value = 50.0;
						}
						else
						{
							b2 = (byte?)bDA_FireLevel;
							if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								PB_FireDamage.Value = 75.0;
							}
							else
							{
								b2 = (byte?)bDA_FireLevel;
								if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									PB_FireDamage.Value = 100.0;
								}
							}
						}
					}
				}
			}
			else
			{
				PB_FireDamage.Visibility = Visibility.Collapsed;
				Label_FireDamage.Content = "火情：未知";
			}
		}
		else
		{
			method_4(Visibility.Collapsed);
			method_3(Visibility.Collapsed);
			method_2(Visibility.Collapsed);
		}
		if (_InfoVisitor.ActualUnit.IsGroup)
		{
			Label_ContactWRAType.Visibility = Visibility.Hidden;
		}
		else
		{
			Label_ContactWRAType.Visibility = Visibility.Visible;
			ref Contact infoVisitor = ref _InfoVisitor;
			bool? nullable_ = false;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref infoVisitor, null, ref nullable_);
			bool? nullable_2 = null;
			Doctrine.WRA_DetermineTargetType(ref _InfoVisitor, null, ref nullable_2);
			Label_ContactWRAType.Content = "武器释放授权：" + Doctrine.WRA_TargetType_String(wRA_WeaponTargetType_, nullable_2.Value);
		}
		Button_Magazines.Visibility = Visibility.Collapsed;
		method_5(Visibility.Collapsed);
		if (_InfoVisitor.ActualUnit != null && _InfoVisitor.ActualUnit.GetisTaggedAsDecoyByThisSide(Client.CurrentSide.ObjectID))
		{
			string text = "[DECOY] ";
			Label_UnitName.Content = Operators.ConcatenateObject(text, Label_UnitName.Content);
			TextBlock_UnitCategory.Text = text + TextBlock_UnitCategory.Text;
			TextBlock_UnitType.Text = text + TextBlock_UnitType.Text;
			TextBlock_UnitClass.Text = text + TextBlock_UnitClass.Text;
		}
	}

	private void FindInterruptibleSetter(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
		Label_ContactWRAType.Visibility = Visibility.Collapsed;
		Label_Supply.Visibility = Visibility.Collapsed;
		Combo_Supplier.Visibility = Visibility.Collapsed;
		_AuthenticationVisitor = (Group)unit_0;
		if (_AuthenticationVisitor == null || _AuthenticationVisitor.GroupLead == null)
		{
			return;
		}
		ConcatInterruptibleSetter(_AuthenticationVisitor.GroupLead);
		SetTextBlock_UnitStatusVisibility(Visibility.Visible);
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			Dockpanel_EditHosted.Visibility = Visibility.Visible;
		}
		else
		{
			Dockpanel_EditHosted.Visibility = Visibility.Collapsed;
		}
		TextBlock_UnitStatus.Visibility = Visibility.Visible;
		TextBlock_PrimaryTarget.Visibility = Visibility.Visible;
		Button_ContactReport.Visibility = Visibility.Collapsed;
		Button_Weapons.Visibility = Visibility.Hidden;
		Button_MCM.Visibility = Visibility.Collapsed;
		Button_CargoOps.Visibility = Visibility.Collapsed;
		Button_Magazines.Visibility = Visibility.Collapsed;
		method_4(Visibility.Collapsed);
		method_3(Visibility.Collapsed);
		method_2(Visibility.Collapsed);
		Expander_GroupMembers.Visibility = Visibility.Visible;
		Expander_TankerClients.Visibility = Visibility.Collapsed;
		SetTextBlock_AssignedHostVisibility(Visibility.Collapsed);
		Label_UnitProficiency.Visibility = Visibility.Collapsed;
		OuterTextBlock_UnitClass.Visibility = Visibility.Visible;
		TextBlock_UnitStatus.Visibility = Visibility.Visible;
		TextBlock_PrimaryTarget.Visibility = Visibility.Visible;
		method_0(Visibility.Collapsed);
		Hyperlink_UnitClass.IsEnabled = true;
		Button_UnitMessageLog.Visibility = Visibility.Collapsed;
		Label_GTolerance.Visibility = Visibility.Collapsed;
		PB_GTolerance.Visibility = Visibility.Collapsed;
		TextBlock_TimeUnderway.Visibility = Visibility.Collapsed;
		switch (_AuthenticationVisitor.Type)
		{
		default:
			SetCB_GroupLeadSlowDownVisibility(Visibility.Visible);
			CB_GroupLeadSlowDown.IsChecked = _AuthenticationVisitor.Kinematics.LeadAllowedToSlowDown;
			break;
		case Group.GroupType.AirGroup:
		case Group.GroupType.Installation:
		case Group.GroupType.AirBase:
		case Group.GroupType.NavalBase:
			SetCB_GroupLeadSlowDownVisibility(Visibility.Collapsed);
			break;
		}
		if (Expander_GroupMembers.IsExpanded)
		{
			ReadInterruptibleSetter();
		}
		OuterTextBlock_UnitClass.Visibility = Visibility.Visible;
		if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
		{
			if (_AuthenticationVisitor.Units.Count > 0)
			{
				if ((from theU in _AuthenticationVisitor.Units.Values
					group theU by theU.UnitClass).Count() == 1)
				{
					TextBlock_UnitClass.Text = "(" + Conversions.ToString(_AuthenticationVisitor.Units.Count) + "x " + Misc.ReadRequest(_AuthenticationVisitor.Units.Values.ElementAtOrDefault(0).UnitClass) + ")";
				}
				else
				{
					TextBlock_UnitClass.Text = "(" + Conversions.ToString(_AuthenticationVisitor.Units.Count) + "x mixed aircraft)";
				}
			}
			TextBlock_Loadout.Visibility = Visibility.Visible;
			if (_AuthenticationVisitor.Units.Count > 0)
			{
				TextBlock_LoadoutName.Text = Misc.ReadRequest(((Aircraft)_AuthenticationVisitor.Units.Values.ElementAtOrDefault(0)).LoadoutName);
				Hyperlink_Loadout.Tag = ((Aircraft)_AuthenticationVisitor.Units.Values.ElementAtOrDefault(0)).Int32_0;
			}
		}
		else
		{
			TextBlock_UnitClass.Text = _AuthenticationVisitor.TypeDescription + " (" + Conversions.ToString(_AuthenticationVisitor.Units.Count) + "单元）";
			TextBlock_Loadout.Visibility = Visibility.Collapsed;
		}
		OuterTextBlock_UnitCategory.Visibility = Visibility.Visible;
		TextBlock_UnitCategory.Text = _AuthenticationVisitor.TypeDescription;
		if (!_AuthenticationVisitor.HasAirFacilities && !_AuthenticationVisitor.HasDockFacilities)
		{
			method_5(Visibility.Collapsed);
		}
		else
		{
			method_5(Visibility.Visible);
			if (_AuthenticationVisitor.HasAirFacilities)
			{
				Button_AirOps.Visibility = Visibility.Visible;
				Button_AirOps.Content = "飞机：" + Conversions.ToString(_AuthenticationVisitor.AirOps.ReadyAircraft.Count()) + "/" + Conversions.ToString(_AuthenticationVisitor.AirOps.EmbarkedAircraft_ReadOnly.Count);
				Button_EditHostedAC.Visibility = Visibility.Visible;
			}
			else
			{
				Button_AirOps.Visibility = Visibility.Hidden;
				Button_EditHostedAC.Visibility = Visibility.Hidden;
			}
			if (_AuthenticationVisitor.HasDockFacilities)
			{
				Button_DockOps.Visibility = Visibility.Visible;
				Button_DockOps.Content = "船：" + Conversions.ToString(ActiveUnit_DockingOps.ReadyBoats(_AuthenticationVisitor.DockingOps).Count()) + "/" + Conversions.ToString(_AuthenticationVisitor.DockingOps.EmbarkedBoats.Count);
				Button_EditHostedBoats.Visibility = Visibility.Visible;
			}
			else
			{
				Button_DockOps.Visibility = Visibility.Hidden;
				Button_EditHostedBoats.Visibility = Visibility.Hidden;
			}
			int num = 0;
			bool flag = false;
			foreach (ActiveUnit value in _AuthenticationVisitor.Units.Values)
			{
				if (value is ICargoHost)
				{
					flag = true;
					if (value.OnboardCargo.Count() > 0)
					{
						num += value.OnboardCargo.Count();
					}
				}
			}
			if (flag)
			{
				Button_EditHostCargo.Visibility = Visibility.Visible;
				if (num > 0)
				{
					Button_CargoOps.Visibility = Visibility.Visible;
					Button_CargoOps.Content = "货运：" + Conversions.ToString(num);
				}
			}
			else
			{
				Button_EditHostCargo.Visibility = Visibility.Hidden;
			}
		}
		Label_UnitName.Content = unit_0.Name;
		Label_UnitCourse.Content = "朝向：" + Misc.FillRequest(unit_0.CurrentHeading).ToString() + " 度";
		if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
		{
			if (_AuthenticationVisitor.GroupLead != null)
			{
				Label_UnitSpeed.Content = "速度：" + string.Format("{0:0.0}", unit_0.CurrentSpeed, 0).ToString() + " 节 (马赫 " + $"{Physics.CompareStub(_AuthenticationVisitor.GroupLead.GetCurrentAltitude(), _AuthenticationVisitor.GroupLead.CurrentSpeed):0.00}" + "[EMPTY SLOT x 1]（" + Misc.PostRequest(_AuthenticationVisitor.GroupLead.ThrottleSetting, _AuthenticationVisitor.GroupLead) + ")";
			}
		}
		else if (_AuthenticationVisitor.GroupLead != null)
		{
			Label_UnitSpeed.Content = "速度：" + string.Format("{0:0.0}", unit_0.CurrentSpeed, 0).ToString() + " 节 (" + Misc.PostRequest(_AuthenticationVisitor.GroupLead.ThrottleSetting, _AuthenticationVisitor.GroupLead) + ")";
		}
		if (_AuthenticationVisitor.GroupLead != null && _AuthenticationVisitor.GroupLead.AI.MustSlowDownToAllowGroupFormUp())
		{
			Label_UnitSpeed.Content = Label_UnitSpeed.Content.ToString() + "\r\n(降低速度以形成编组)";
		}
		if (unit_0.GetUnitSide() == null)
		{
			Label_UnitSide.Content = "None";
		}
		else
		{
			Label_UnitSide.Content = unit_0.GetUnitSide().Name;
		}
		if (unit_0.GetUnitSide() == side_0)
		{
			method_1(Visibility.Visible);
		}
		else
		{
			method_1(Visibility.Collapsed);
		}
		if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			if (unit_0.CurrentAltitude_AGL <= 3048f)
			{
				if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
				{
					if (Module_Unit.ResetTokenizer(unit_0))
					{
						Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + $"{unit_0.CurrentAltitude_AGL * 3.28084f:0}" + "英尺 真高）";
					}
					else
					{
						Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " ft ASL";
					}
				}
				else
				{
					Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}".ToString() + " 英尺";
				}
			}
			else if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
			{
				Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}".ToString() + " ft ASL";
			}
			else
			{
				Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}".ToString() + " 英尺";
			}
		}
		else if (unit_0.CurrentAltitude_AGL <= 3048f)
		{
			if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
			{
				if (Module_Unit.ResetTokenizer(unit_0))
				{
					Label_UnitAlt.Content = "高度：" + string.Format("{0:0.0}", unit_0.GetCurrentAltitude(), 0) + " 米 海高 (" + string.Format("{0:0.0}", unit_0.CurrentAltitude_AGL, 0) + "米 真高）";
				}
				else
				{
					Label_UnitAlt.Content = "高度：" + string.Format("{0:0.0}", unit_0.GetCurrentAltitude(), 0) + " 米 海高";
				}
			}
			else
			{
				Label_UnitAlt.Content = "高度：" + string.Format("{0:0.0}", unit_0.GetCurrentAltitude(), 0).ToString() + " 米";
			}
		}
		else if (_AuthenticationVisitor.Type == Group.GroupType.AirGroup)
		{
			Label_UnitAlt.Content = "高度：" + string.Format("{0:0.0}", unit_0.GetCurrentAltitude(), 0).ToString() + " 米 海高";
		}
		else
		{
			Label_UnitAlt.Content = "高度：" + string.Format("{0:0.0}", unit_0.GetCurrentAltitude(), 0).ToString() + " 米";
		}
		method_4(Visibility.Collapsed);
		if (_AuthenticationVisitor.IsLandInstallation)
		{
			if (unit_0.GetUnitSide() == side_0)
			{
				Button_Magazines.Visibility = Visibility.Visible;
			}
			else
			{
				Button_Magazines.Visibility = Visibility.Collapsed;
			}
		}
		else
		{
			Button_Magazines.Visibility = Visibility.Collapsed;
		}
		TextBlock_UnitStatus.Text = "状态：" + Misc.ToEnglishString(_AuthenticationVisitor.Status, _AuthenticationVisitor);
		if (_AuthenticationVisitor.AI.PrimaryTarget == null)
		{
			TextBlock_PrimaryTarget.Visibility = Visibility.Collapsed;
		}
		else
		{
			TextBlock_PrimaryTarget.Visibility = Visibility.Visible;
			TextBlock_PrimaryTarget.Text = "Target:" + _AuthenticationVisitor.AI.PrimaryTarget.Name;
		}
		if (_AuthenticationVisitor.GroupLead != null && _AuthenticationVisitor.GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint && _AuthenticationVisitor.GroupLead.UnitType == GlobalVariables.ActiveUnitType.Aircraft && ((Aircraft)_AuthenticationVisitor.GroupLead).AirOps.A2AR_Destination != null)
		{
			TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + "（开始：" + ((Aircraft)_AuthenticationVisitor.GroupLead).AirOps.A2AR_Destination.Name + ")";
		}
		if (_AuthenticationVisitor.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
		{
			int num2 = _AuthenticationVisitor.Units.Values.Where((ActiveUnit AU) => AU.IsOperating()).Count();
			TextBlock_UnitStatus.Text = "形成：" + Conversions.ToString(num2) + "/" + Conversions.ToString(_AuthenticationVisitor.Units.Count);
		}
		if (_AuthenticationVisitor.AssignedMissionOrPackage() != null && _AuthenticationVisitor.GetUnitSide() == Client.CurrentSide)
		{
			SetTextBlock_MissionVisibility(Visibility.Visible);
			Hyperlink_Mission.Tag = _AuthenticationVisitor.AssignedMissionOrPackage();
			string text = "";
			if (_AuthenticationVisitor.GroupLead != null && _AuthenticationVisitor.GroupLead.AI.IsEscort)
			{
				text = "（护航）";
			}
			text = text + _AuthenticationVisitor.AssignedMissionOrPackage().Name + " (" + _AuthenticationVisitor.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + ")";
			TextBlock_MissionName.Text = text;
		}
		else
		{
			SetTextBlock_MissionVisibility(Visibility.Collapsed);
		}
		if (_AuthenticationVisitor.AssignedMissionsQueue.Count > 0 && _AuthenticationVisitor.GetUnitSide() == Client.CurrentSide)
		{
			TextBlock_QueuedMission.Visibility = Visibility.Visible;
			tip1.IsEnabled = false;
			string text2 = "";
			if (_AuthenticationVisitor.AssignedMissionsQueue.Count <= 0)
			{
				TextBlock_QueuedMission.Text = "";
			}
			else
			{
				TextBlock_QueuedMission.Text = _AuthenticationVisitor.AssignedMissionsQueue.Count + " 个队列中任务";
				foreach (KeyValuePair<Mission, Mission> item in _AuthenticationVisitor.AssignedMissionsQueue.OrderBy((KeyValuePair<Mission, Mission> x) => x.Key.PriorityWeight).ToList())
				{
					text2 = text2 + item.Value.Name + " 优先级 " + item.Value.PriorityWeight;
					text2 += Environment.NewLine;
				}
			}
			tip1.Content = text2;
		}
		else
		{
			TextBlock_QueuedMission.Visibility = Visibility.Collapsed;
			tip1.IsEnabled = false;
			tip1.Content = "";
			TextBlock_QueuedMission.Text = "";
		}
	}

	private void SetInterruptibleSetter(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		try
		{
			OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
			Label_ContactWRAType.Visibility = Visibility.Collapsed;
			paramsVisitor = (ActiveUnit)unit_0;
			if (paramsVisitor == null)
			{
				return;
			}
			ConcatInterruptibleSetter(paramsVisitor);
			Button_UnitMessageLog.Visibility = Visibility.Visible;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				Dockpanel_EditHosted.Visibility = Visibility.Visible;
			}
			else
			{
				Dockpanel_EditHosted.Visibility = Visibility.Collapsed;
			}
			OuterTextBlock_UnitCategory.Visibility = Visibility.Visible;
			OuterTextBlock_UnitType.Visibility = Visibility.Collapsed;
			if (paramsVisitor.IsSubmarine | paramsVisitor.IsShip | paramsVisitor.IsVehicle)
			{
				TextBlock_TimeUnderway.Visibility = Visibility.Visible;
				TextBlock_TimeUnderway.Text = Misc.UpdateRequest((long)Math.Round(paramsVisitor.TimeUnderway), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " Time Underway";
			}
			else
			{
				TextBlock_TimeUnderway.Visibility = Visibility.Collapsed;
			}
			if (paramsVisitor.IsFacility)
			{
				Facility facility = (Facility)paramsVisitor;
				TextBlock_UnitCategory.Text = facility.Type_Description;
			}
			else
			{
				TextBlock_UnitCategory.Text = paramsVisitor.SubTypeDescription;
			}
			Button_CargoOps.Visibility = Visibility.Collapsed;
			if (Expander_GroupMembers.Visibility != Visibility.Collapsed)
			{
				Expander_GroupMembers.Visibility = Visibility.Collapsed;
			}
			if (paramsVisitor.IsAircraft && ((Aircraft)paramsVisitor).IsTanker)
			{
				Expander_TankerClients.Visibility = Visibility.Visible;
				Aircraft_AirOps airOps = ((Aircraft)paramsVisitor).AirOps;
				Expander_TankerClients.Header = "加油队列：" + Conversions.ToString(airOps.RefuellingQueue.Count + airOps.A2AR_Connections.Count) + "[加油中：" + Conversions.ToString(airOps.A2AR_NumberOfReceiverHookups.Where((ActiveUnit_Struct x) => x.DBID != 0).Count()) + "]";
				if (Expander_TankerClients.IsExpanded)
				{
					ReflectInterruptibleSetter(ref paramsVisitor);
				}
			}
			else if (paramsVisitor.IsShip && ((Ship)paramsVisitor).GetCanPhysicallyReplenishThisUnit(paramsVisitor))
			{
				Expander_TankerClients.Visibility = Visibility.Visible;
				ActiveUnit_DockingOps dockingOps = ((Ship)paramsVisitor).DockingOps;
				int num = 0;
				if (dockingOps.UNREP_Queue.Count > 0 || !string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) || !string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) || !string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
				{
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID))
					{
						num++;
					}
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID))
					{
						num++;
					}
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
					{
						num++;
					}
					foreach (string item in dockingOps.UNREP_Queue)
					{
						num++;
					}
				}
				Expander_TankerClients.Header = "补给队列：" + Conversions.ToString(num);
				if (Expander_TankerClients.IsExpanded)
				{
					ReflectInterruptibleSetter(ref paramsVisitor);
				}
			}
			else if (Expander_TankerClients.Visibility != Visibility.Collapsed)
			{
				Expander_TankerClients.Visibility = Visibility.Collapsed;
			}
			if (TextBlock_UnitStatus.Visibility != 0)
			{
				TextBlock_UnitStatus.Visibility = Visibility.Visible;
			}
			if (Button_ContactReport.Visibility != Visibility.Collapsed)
			{
				Button_ContactReport.Visibility = Visibility.Collapsed;
			}
			if (unit_0.IsWeapon)
			{
				Button_Weapons.Visibility = Visibility.Collapsed;
				OuterTextBlock_FiringParent.Visibility = Visibility.Visible;
				try
				{
					if (unit_0.GetUnitSide() != null && (Operators.CompareString(unit_0.GetUnitSide().ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) == 0 || Module_Side.IsAlliedWithThisSide(unit_0.GetUnitSide(), Client.CurrentSide)) && ((Weapon)unit_0).FiringParent != null)
					{
						TextBlock_FiringParent.Text = "发射平台：" + ((Weapon)unit_0).FiringParent.Name;
					}
					else
					{
						OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Button_Weapons.Visibility = Visibility.Visible;
				OuterTextBlock_FiringParent.Visibility = Visibility.Collapsed;
			}
			SetCB_GroupLeadSlowDownVisibility(Visibility.Collapsed);
			if (unit_0.IsWeapon)
			{
				SetTextBlock_AssignedHostVisibility(Visibility.Collapsed);
			}
			else
			{
				SetTextBlock_AssignedHostVisibility(Visibility.Visible);
			}
			OuterTextBlock_UnitClass.Visibility = Visibility.Visible;
			if (paramsVisitor.IsWeapon)
			{
				Label_UnitProficiency.Visibility = Visibility.Collapsed;
				Label_Supply.Visibility = Visibility.Collapsed;
				Combo_Supplier.Visibility = Visibility.Collapsed;
			}
			else
			{
				Label_UnitProficiency.Visibility = Visibility.Visible;
				Label_UnitProficiency.Content = Misc.TestRequest(paramsVisitor.Proficiency.Value);
				Label_Supply.Visibility = Visibility.Visible;
				Combo_Supplier.Visibility = Visibility.Visible;
				Combo_Supplier.SelectedIndex = (int)paramsVisitor.DesignatedSupplier;
			}
			Hyperlink_UnitClass.IsEnabled = true;
			if (unit_0.IsAircraft)
			{
				TextBlock_Loadout.Visibility = Visibility.Visible;
				Loadout loadout = ((Aircraft)unit_0).Loadout;
				Aircraft_AirOps airOps2 = ((Aircraft)unit_0).AirOps;
				if (loadout == null)
				{
					TextBlock_LoadoutName.Text = "没有";
					Hyperlink_Loadout.Tag = null;
				}
				else
				{
					if (airOps2.QuickTurnaround_Enabled)
					{
						TextBlock_LoadoutName.Text = Misc.ReadRequest(loadout.Name) + "，快速再次出动已启用，" + Conversions.ToString(airOps2.QuickTurnaround_SortiesFlown) + " / " + Conversions.ToString(airOps2.QuickTurnaround_SortiesTotal) + "架次";
					}
					else
					{
						TextBlock_LoadoutName.Text = Misc.ReadRequest(loadout.Name);
					}
					Hyperlink_Loadout.Tag = loadout.DBID;
				}
			}
			else
			{
				TextBlock_Loadout.Visibility = Visibility.Collapsed;
			}
			ActiveUnit activeUnit = null;
			string text = "";
			activeUnit = (paramsVisitor.IsAircraft ? ((Aircraft)paramsVisitor).AirOps.GetAssignedHostUnit() : paramsVisitor.DockingOps.GetAssignedHostUnit());
			if (activeUnit == null)
			{
				TextBlock_AssignedHost.Text = "指定基地：无";
			}
			else
			{
				text = ((!activeUnit.IsFacility || !activeUnit.IsGroupMember()) ? activeUnit.Name : activeUnit.GetParentGroup().Name);
				TextBlock_AssignedHost.Text = "指定基地：" + text;
			}
			if ((!paramsVisitor.HasAirFacilities && !paramsVisitor.HasDockFacilities && !(paramsVisitor is ICargoHost)) || (!paramsVisitor.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient))
			{
				method_5(Visibility.Collapsed);
				Button_EditHostedAC.Visibility = Visibility.Collapsed;
				Button_EditHostedBoats.Visibility = Visibility.Collapsed;
				Button_EditHostCargo.Visibility = Visibility.Collapsed;
			}
			else
			{
				method_5(Visibility.Visible);
				if (paramsVisitor.HasAirFacilities)
				{
					Button_AirOps.Visibility = Visibility.Visible;
					Button_AirOps.Content = "飞机：" + Conversions.ToString(paramsVisitor.AirOps.ReadyAircraft.Count()) + "/" + Conversions.ToString(paramsVisitor.AirOps.EmbarkedAircraft_ReadOnly.Count);
					Button_EditHostedAC.Visibility = Visibility.Visible;
				}
				else
				{
					Button_AirOps.Visibility = Visibility.Collapsed;
					Button_EditHostedAC.Visibility = Visibility.Collapsed;
				}
				if (paramsVisitor.HasDockFacilities)
				{
					Button_DockOps.Visibility = Visibility.Visible;
					Button_DockOps.Content = "船：" + Conversions.ToString(ActiveUnit_DockingOps.ReadyBoats(paramsVisitor.DockingOps).Count()) + "/" + Conversions.ToString(paramsVisitor.DockingOps.EmbarkedBoats.Count);
					Button_EditHostedBoats.Visibility = Visibility.Visible;
				}
				else
				{
					Button_DockOps.Visibility = Visibility.Collapsed;
					Button_EditHostedBoats.Visibility = Visibility.Collapsed;
				}
				if (paramsVisitor is ICargoHost)
				{
					Button_EditHostCargo.Visibility = Visibility.Visible;
					if (paramsVisitor.HasCargo)
					{
						Button_CargoOps.Visibility = Visibility.Visible;
						Button_CargoOps.Content = "货运：" + Conversions.ToString(paramsVisitor.OnboardCargo.Count());
					}
					else
					{
						Button_CargoOps.Visibility = Visibility.Collapsed;
					}
				}
				else
				{
					Button_EditHostCargo.Visibility = Visibility.Collapsed;
					Button_CargoOps.Visibility = Visibility.Collapsed;
				}
			}
			if (paramsVisitor.IsGroupLead())
			{
				if (paramsVisitor.Navigator.HasFlight)
				{
					Label_UnitName.Content = "[领队]" + paramsVisitor.Name + "（编队" + paramsVisitor.Navigator.GetFlight().Callsign + ")";
				}
				else
				{
					Label_UnitName.Content = unit_0.Name;
				}
			}
			else if (paramsVisitor.Navigator.HasFlight)
			{
				Label_UnitName.Content = unit_0.Name + "（编队" + paramsVisitor.Navigator.GetFlight().Callsign + ")";
			}
			else
			{
				Label_UnitName.Content = unit_0.Name;
			}
			OuterTextBlock_UnitClass.Visibility = Visibility.Visible;
			TextBlock_UnitClass.Text = Misc.ReadRequest(unit_0.UnitClass);
			if (!paramsVisitor.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				Label_UnitCourse.Content = "朝向：XXX";
			}
			else
			{
				if (paramsVisitor.IsDumbAU)
				{
					Label_UnitCourse.Content = null;
					Label_UnitSpeed.Content = null;
				}
				else if (paramsVisitor.IsFixedFacility)
				{
					Label_UnitCourse.Content = null;
					Label_UnitSpeed.Content = null;
				}
				else
				{
					Label_UnitCourse.Content = "朝向：" + Conversions.ToString(Math.Round(unit_0.CurrentHeading, 0)) + " 度";
				}
				if (paramsVisitor.Navigator.PathFindingInProgress)
				{
					Label_UnitCourse.Content = Conversions.ToString(Label_UnitCourse.Content) + "（寻路中..." + Conversions.ToString((int)Math.Round(paramsVisitor.Navigator.Pathfinding_PercentComplete * 100f)) + "%)";
				}
			}
			if (!paramsVisitor.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				Label_UnitSpeed.Content = "速度：XXX";
			}
			else if ((unit_0.IsAircraft || unit_0.IsMissile) | (unit_0.IsWeapon && ((Weapon)unit_0).IsPalletWeapon))
			{
				if (unit_0.SupportsAttitude_Pitch && !double.IsNaN(unit_0.Attitude_Pitch))
				{
					Label_UnitSpeed.Content = "速度:\r\n真空速" + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " 节 (马赫 " + $"{Physics.CompareStub(unit_0.GetCurrentAltitude(), unit_0.CurrentSpeed):0.00}" + ") - 俯仰角:  " + Conversions.ToString(Math.Round(unit_0.Attitude_Pitch, 1)) + "\r\n地速 " + Conversions.ToString((int)Math.Round((double)unit_0.CurrentSpeed * Math2.PopClass(unit_0.Attitude_Pitch))) + " 节 (" + (paramsVisitor.Kinematics.DesiredSpeedOverride.HasValue ? "手动: " : "自动: ") + Misc.PostRequest(paramsVisitor.ThrottleSetting, paramsVisitor) + ")";
				}
				else
				{
					Label_UnitSpeed.Content = "速度：" + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " 节 (马赫 " + $"{Physics.CompareStub(unit_0.GetCurrentAltitude(), unit_0.CurrentSpeed):0.00}" + "[EMPTY SLOT x 1]（" + Misc.PostRequest(paramsVisitor.ThrottleSetting, paramsVisitor) + ")";
				}
			}
			else if (unit_0.IsSatellite)
			{
				Label_UnitSpeed.Content = "速度：" + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " 节";
			}
			else
			{
				Label_UnitSpeed.Foreground = Brushes.White;
				if (paramsVisitor.IsShip)
				{
					Ship ship = (Ship)paramsVisitor;
					Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(ship.ParentScen, ship.GetLatitude(), ship.GetLongitude(), 0);
					if (ship.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed) && ship.Kinematics.GetMaximumSpeed() > Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherAtThisTimeAndPlace.SeaState))
					{
						Label_UnitSpeed.Content = "由于海况最大速度降低，海况：" + weatherAtThisTimeAndPlace.SeaState + Environment.NewLine + "速度：" + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.PostRequest(paramsVisitor.ThrottleSetting, (ActiveUnit)unit_0) + ")";
						Label_UnitSpeed.Foreground = Brushes.Orange;
					}
					else
					{
						Label_UnitSpeed.Content = "速度：" + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.PostRequest(paramsVisitor.ThrottleSetting, (ActiveUnit)unit_0) + ")";
					}
				}
				else
				{
					Label_UnitSpeed.Content = "速度：" + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.PostRequest(paramsVisitor.ThrottleSetting, (ActiveUnit)unit_0) + ")";
				}
			}
			if (unit_0.GetUnitSide() == null)
			{
				Label_UnitSide.Content = "分方：无";
			}
			else
			{
				Label_UnitSide.Content = "分方：" + unit_0.GetUnitSide().Name;
			}
			if (unit_0.GetUnitSide() == side_0 && (paramsVisitor.CommStuff.IsConnectedToSideNetwork || InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
			{
				method_1(Visibility.Visible);
			}
			else
			{
				method_1(Visibility.Collapsed);
			}
			if (!unit_0.IsWeapon && (paramsVisitor.CommStuff.IsConnectedToSideNetwork || InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
			{
				method_4(Visibility.Visible);
				method_3(Visibility.Visible);
				if (!unit_0.IsShip && !unit_0.IsSubmarine)
				{
					method_2(Visibility.Collapsed);
				}
				else
				{
					method_2(Visibility.Visible);
				}
				Button_Damage.Visibility = Visibility.Visible;
				if (unit_0.IsShip && ((Ship)unit_0).IsSinking)
				{
					Label_UnitDamage.Text = "SINKING";
				}
				else
				{
					Label_UnitDamage.Text = string.Format("{0:0.0}", paramsVisitor.Damage.DamagePercent, 1) + "%";
				}
				if (!unit_0.IsShip && !unit_0.IsSubmarine)
				{
					Label_FloodDamage.Visibility = Visibility.Collapsed;
					PB_FloodDamage.Visibility = Visibility.Collapsed;
				}
				else
				{
					Label_FloodDamage.Visibility = Visibility.Visible;
					PB_FloodDamage.Visibility = Visibility.Visible;
					Label_FloodDamage.Content = "漏水：";
					switch (paramsVisitor.Damage.FloodIntensity)
					{
					case ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding:
						PB_FloodDamage.Value = 0.0;
						Label_FloodDamage.Visibility = Visibility.Collapsed;
						PB_FloodDamage.Visibility = Visibility.Collapsed;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Minor:
						PB_FloodDamage.Value = 25.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Major:
						PB_FloodDamage.Value = 50.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Severe:
						PB_FloodDamage.Value = 75.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Capsizing:
						PB_FloodDamage.Value = 100.0;
						break;
					}
				}
				if (unit_0.IsAircraft && ((Aircraft)unit_0).Kinematics.IsInCombatManouvers && !((Aircraft)unit_0).IsHelicopter)
				{
					Label_GTolerance.Visibility = Visibility.Visible;
					PB_GTolerance.Visibility = Visibility.Visible;
					Aircraft aircraft = (Aircraft)unit_0;
					PB_GTolerance.Value = 100f * (aircraft.G_StrainAccumulated / aircraft.G_Tolerance);
					float num2 = aircraft.G_StrainAccumulated / aircraft.G_Tolerance;
					if (num2 < 0.5f)
					{
						PB_GTolerance.Foreground = Brushes.Green;
					}
					else if (num2 < 0.75f)
					{
						PB_GTolerance.Foreground = Brushes.Yellow;
					}
					else
					{
						PB_GTolerance.Foreground = Brushes.Red;
					}
				}
				else
				{
					Label_GTolerance.Visibility = Visibility.Collapsed;
					PB_GTolerance.Visibility = Visibility.Collapsed;
				}
				Label_FireDamage.Visibility = Visibility.Visible;
				PB_FireDamage.Visibility = Visibility.Visible;
				Label_FireDamage.Content = "火情：";
				switch (paramsVisitor.Damage.FireIntensity)
				{
				case ActiveUnit_Damage.FireIntensityLevel.NoFire:
					PB_FireDamage.Value = 0.0;
					Label_FireDamage.Visibility = Visibility.Collapsed;
					PB_FireDamage.Visibility = Visibility.Collapsed;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Minor:
					PB_FireDamage.Value = 25.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Major:
					PB_FireDamage.Value = 50.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Severe:
					PB_FireDamage.Value = 75.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
					PB_FireDamage.Value = 100.0;
					break;
				}
			}
			else
			{
				method_4(Visibility.Collapsed);
				method_3(Visibility.Collapsed);
				method_2(Visibility.Collapsed);
			}
			GlobalVariables.ActiveUnitType unitType = ((ActiveUnit)unit_0).UnitType;
			if (unitType != GlobalVariables.ActiveUnitType.Ship && unitType != GlobalVariables.ActiveUnitType.Facility)
			{
				if (!paramsVisitor.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
				{
					Label_UnitAlt.Content = "海拔高度：XXX";
				}
				else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
				{
					if (unit_0.GetCurrentAltitude() <= 45720f)
					{
						if (unit_0.CurrentAltitude_AGL <= 3048f)
						{
							if (!unit_0.IsAircraft && !unit_0.IsWeapon)
							{
								Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺（" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
							}
							else if (Module_Unit.ResetTokenizer(unit_0))
							{
								Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + $"{unit_0.CurrentAltitude_AGL * 3.28084f:0}" + " 英尺 真高) (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
							}
							else
							{
								Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
							}
						}
						else if (!unit_0.IsAircraft && !unit_0.IsWeapon)
						{
							Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺（" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
						else
						{
							Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
					}
					else
					{
						Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() / 1000f:0.0}" + " 千米 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
				}
				else if (unit_0.GetCurrentAltitude() <= 45720f)
				{
					if (unit_0.CurrentAltitude_AGL <= 3048f)
					{
						if (!unit_0.IsAircraft && !unit_0.IsWeapon)
						{
							Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude():0.0}" + " 米 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
						else if (Module_Unit.ResetTokenizer(unit_0))
						{
							Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude():0.0}" + " 米 海高 (" + string.Format("{0:0.0}", unit_0.CurrentAltitude_AGL, 0) + " 米 真高) (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
						else
						{
							Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude():0.0}" + " 米 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
					}
					else if (!unit_0.IsAircraft && !unit_0.IsWeapon)
					{
						Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude():0.0}" + " 米 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
					else
					{
						Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude():0.0}" + " 米 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
				}
				else
				{
					Label_UnitAlt.Content = "高度：" + $"{unit_0.GetCurrentAltitude() / 1000f:0.0}" + " 千米 海高 (" + (paramsVisitor.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
				}
			}
			else
			{
				Label_UnitAlt.Content = "";
			}
			if (unit_0.IsPlatform && Client.CanSeeAllPrivateInformationOnThisUnit(unit_0))
			{
				if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit && ((Platform)unit_0).Magazines.Count() <= 0)
				{
					bool flag = false;
					if ((unit_0.IsShip || unit_0.IsFacility) && ((Platform)unit_0).Mounts.Count > 0)
					{
						foreach (Mount mount in ((Platform)unit_0).Mounts)
						{
							if (mount.MountMagazine.Weapons.Count > 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						Button_Magazines.Visibility = Visibility.Visible;
					}
					else
					{
						Button_Magazines.Visibility = Visibility.Collapsed;
					}
				}
				else if (paramsVisitor.IsAircraft)
				{
					Button_Magazines.Visibility = Visibility.Collapsed;
				}
				else if (unit_0.GetUnitSide() == side_0)
				{
					Button_Magazines.Visibility = Visibility.Visible;
				}
				else
				{
					Button_Magazines.Visibility = Visibility.Collapsed;
				}
			}
			else
			{
				Button_Magazines.Visibility = Visibility.Collapsed;
			}
			if (paramsVisitor.HasMineCountermeasures() && Client.CanSeeAllPrivateInformationOnThisUnit(unit_0))
			{
				Button_MCM.Visibility = Visibility.Visible;
			}
			else
			{
				Button_MCM.Visibility = Visibility.Collapsed;
			}
			if (unit_0.IsShip && ((Ship)unit_0).IsSinking)
			{
				TextBlock_UnitStatus.Text = "状态：沉没";
			}
			else if (!paramsVisitor.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(paramsVisitor) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				TextBlock_UnitStatus.Text = "状态：未知（通讯中断）";
			}
			else if (paramsVisitor.IsWeapon && ((Weapon)paramsVisitor).Type == Weapon._WeaponType.Sonobuoy)
			{
				TextBlock_UnitStatus.Text = "生存时间：" + Misc.UpdateRequest((long)Math.Round(paramsVisitor.Fuel_ReadOnly[0].CurrentQuantity));
			}
			else
			{
				TextBlock_UnitStatus.Text = "状态：" + Misc.ToEnglishString(paramsVisitor.Status, paramsVisitor);
				if (paramsVisitor.AI.PrimaryTarget == null)
				{
					TextBlock_PrimaryTarget.Visibility = Visibility.Collapsed;
				}
				else
				{
					TextBlock_PrimaryTarget.Visibility = Visibility.Visible;
					TextBlock_PrimaryTarget.Text = "Target: " + paramsVisitor.AI.PrimaryTarget.Name;
				}
				if ((unit_0.IsShip || unit_0.IsSubmarine) && paramsVisitor.Navigator.SprintDrift)
				{
					switch (paramsVisitor.Kinematics.SprintAndDriftCadence)
					{
					case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
						TextBlock_UnitStatus.Text += "（漂流";
						break;
					case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
						TextBlock_UnitStatus.Text += "（冲刺";
						break;
					}
					float num3 = paramsVisitor.Navigator.CalculateDic();
					if (num3 > 0f)
					{
						TextBlock_UnitStatus.Text += " for ";
						if (num3 < 1f)
						{
							TextBlock_UnitStatus.Text += num3.ToString("F1");
						}
						else
						{
							TextBlock_UnitStatus.Text += num3.ToString("F0");
						}
						TextBlock_UnitStatus.Text += "nm";
					}
					TextBlock_UnitStatus.Text += ")";
				}
				if (paramsVisitor.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					if (paramsVisitor.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
					{
						if (((Aircraft)paramsVisitor).AirOps.A2AR_Destination == null)
						{
							if (paramsVisitor.IsGroupWingman() && !paramsVisitor.IsGroupLead())
							{
								ActiveUnit groupLead = paramsVisitor.GetParentGroup().GroupLead;
								if (((Aircraft)groupLead).AirOps.A2AR_Destination != null)
								{
									TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + "（开始：" + ((Aircraft)groupLead).AirOps.A2AR_Destination.Name + ")";
								}
							}
						}
						else
						{
							TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + "（开始：" + ((Aircraft)paramsVisitor).AirOps.A2AR_Destination.Name + ")";
						}
					}
					else if (paramsVisitor.DockingOps.UNREP_Destination != null)
					{
						TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + "（开始：" + paramsVisitor.DockingOps.UNREP_Destination.Name + ")";
					}
				}
				if (unit_0.IsAircraft)
				{
					if (((Aircraft)unit_0).AirOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB)
					{
						string text2 = " (" + ((Aircraft)unit_0).AirOps.ConditionString;
						Aircraft_AirOps._AirOpsCondition condition = ((Aircraft)paramsVisitor).AirOps.Condition;
						if (condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || condition == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
						{
							text2 = ((paramsVisitor.CurrentAltitude_AGL <= 45.72f) ? (text2 + " (" + Misc.UpdateRequest((long)Math.Round(((Aircraft)paramsVisitor).AirOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ")") : (text2 + "，调整海拔高度"));
						}
						text2 += ")";
						TextBlock_UnitStatus.Text += text2;
					}
				}
				else
				{
					if (paramsVisitor.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						string text3 = string.Empty;
						int fuelWeCanSupplyToThisUnit = paramsVisitor.DockingOps.UNREP_Destination.DockingOps.GetFuelWeCanSupplyToThisUnit(paramsVisitor);
						int materialWeCanSupplyToThisUnit = paramsVisitor.DockingOps.UNREP_Destination.DockingOps.GetMaterialWeCanSupplyToThisUnit(paramsVisitor);
						if (fuelWeCanSupplyToThisUnit > 0)
						{
							text3 = text3 + "加油（" + Conversions.ToString(fuelWeCanSupplyToThisUnit) + "千克剩余）";
						}
						if (materialWeCanSupplyToThisUnit > 0)
						{
							if (fuelWeCanSupplyToThisUnit > 0)
							{
								text3 += " - ";
							}
							text3 = text3 + "补给（" + Conversions.ToString(materialWeCanSupplyToThisUnit) + "物品剩余）";
						}
						TextBlock_UnitStatus.Text = "状态：" + text3;
					}
					if (paramsVisitor.DockingOps.IsCurrentlyProvidingUNREP)
					{
						string text4 = "\r\nProviding UNREP: ";
						ActiveUnit activeUnit2 = null;
						if (!string.IsNullOrEmpty(paramsVisitor.DockingOps.UNREP_Port_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[paramsVisitor.DockingOps.UNREP_Port_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text4 = text4 + "\r\n左舷: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						if (!string.IsNullOrEmpty(paramsVisitor.DockingOps.UNREP_Starboard_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[paramsVisitor.DockingOps.UNREP_Starboard_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text4 = text4 + "\r\n右舷: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						if (!string.IsNullOrEmpty(paramsVisitor.DockingOps.UNREP_Astern_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[paramsVisitor.DockingOps.UNREP_Astern_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text4 = text4 + "\r\n船尾: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						TextBlock_UnitStatus.Text += text4;
					}
					else if (paramsVisitor.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo && paramsVisitor.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo)
					{
						if (!paramsVisitor.IsFixedFacility || paramsVisitor.DockingOps.Condition != 0)
						{
							TextBlock textBlock_UnitStatus;
							(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + " (" + paramsVisitor.DockingOps.ConditionString + ")";
						}
					}
					else
					{
						TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (" + paramsVisitor.DockingOps.ConditionString + " (" + Misc.UpdateRequest((long)Math.Round(paramsVisitor.DockingOps.ConditionTimer), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "))";
					}
				}
			}
			if (paramsVisitor.AssignedMissionOrPackage() != null && paramsVisitor.GetUnitSide() == Client.CurrentSide)
			{
				SetTextBlock_MissionVisibility(Visibility.Visible);
				Hyperlink_Mission.Tag = paramsVisitor.AssignedMissionOrPackage();
				string text5 = "";
				if (paramsVisitor.AI.IsEscort)
				{
					text5 = "（护航）";
				}
				text5 += paramsVisitor.AssignedMissionOrPackage().Name;
				if (!string.IsNullOrEmpty(paramsVisitor.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario)))
				{
					text5 = text5 + " (" + paramsVisitor.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + ")";
				}
				TextBlock_MissionName.Text = text5;
				if (!paramsVisitor.AssignedMissionOrPackage().IsActive)
				{
					TextBlock_MissionName.Text += " - 无效";
				}
			}
			else
			{
				SetTextBlock_MissionVisibility(Visibility.Collapsed);
			}
			if (paramsVisitor.CommStuff.IsConnectedToSideNetwork)
			{
				method_0(Visibility.Visible);
				CheckInterruptibleSetter(paramsVisitor);
			}
			else
			{
				method_0(Visibility.Collapsed);
			}
			if (paramsVisitor.AssignedMissionsQueue.Count > 0 && paramsVisitor.GetUnitSide() == Client.CurrentSide)
			{
				TextBlock_QueuedMission.Visibility = Visibility.Visible;
				string text6 = "";
				if (paramsVisitor.AssignedMissionsQueue.Count <= 0)
				{
					TextBlock_QueuedMission.Text = "";
				}
				else
				{
					TextBlock_QueuedMission.Text = paramsVisitor.AssignedMissionsQueue.Count + " 个队列中任务";
					foreach (KeyValuePair<Mission, Mission> item2 in paramsVisitor.AssignedMissionsQueue.OrderBy((KeyValuePair<Mission, Mission> x) => x.Key.PriorityWeight).ToList())
					{
						text6 = text6 + item2.Value.Name + " 优先级 " + item2.Value.PriorityWeight;
						text6 += Environment.NewLine;
					}
				}
				tip1.Content = text6;
			}
			else
			{
				TextBlock_QueuedMission.Visibility = Visibility.Collapsed;
				tip1.IsEnabled = false;
				tip1.Content = "";
				TextBlock_QueuedMission.Text = "";
			}
			if (paramsVisitor.IsDecoy)
			{
				string text7 = "[DECOY] ";
				Label_UnitName.Content = Operators.ConcatenateObject(text7, Label_UnitName.Content);
				TextBlock_UnitCategory.Text = text7 + TextBlock_UnitCategory.Text;
				TextBlock_UnitType.Text = text7 + TextBlock_UnitType.Text;
				TextBlock_UnitClass.Text = text7 + TextBlock_UnitClass.Text;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 32165474243245", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			_AuthenticationVisitor = null;
			paramsVisitor = null;
			_InfoVisitor = null;
			Hyperlink_Mission.Tag = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshPanel(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		TextBlock_UnitCategory.Text = "";
		TextBlock_UnitType.Text = "";
		if (unit_0 != null)
		{
			_AuthenticationVisitor = null;
			paramsVisitor = null;
			_InfoVisitor = null;
			if (unit_0.DisableWriter())
			{
				RemoveInterruptibleSetter(scenario_0, side_0, unit_0);
			}
			else if (unit_0.IsGroup)
			{
				FindInterruptibleSetter(scenario_0, side_0, unit_0);
			}
			else if (unit_0.IsActiveUnit)
			{
				SetInterruptibleSetter(scenario_0, side_0, unit_0);
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	private void FillInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		_StructExporter?.Invoke();
	}

	private void CalculateInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		Client.ShowAirOps();
	}

	private void PopInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		_MerchantExporter?.Invoke();
	}

	private void InstantiateInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		decoratorExporter?.Invoke();
	}

	private void CreateInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		m_CallbackExporter?.Invoke();
	}

	private void CompareInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		stateVisitor?.Invoke();
	}

	private void ReadInterruptibleSetter()
	{
		if (_AuthenticationVisitor == null)
		{
			return;
		}
		ListView_GroupMembers.Items.Clear();
		if (_AuthenticationVisitor.Type != 0 && _AuthenticationVisitor.Type != Group.GroupType.SurfaceGroup && _AuthenticationVisitor.Type != Group.GroupType.SubGroup)
		{
			foreach (string item in (from theAU in _AuthenticationVisitor.Units.Values
				select Misc.ReadRequest(theAU.UnitClass) into UC
				orderby UC
				select UC).Distinct())
			{
				string Local_UCString = item;
				IEnumerable<ActiveUnit> source = from theAU in _AuthenticationVisitor.Units.Values
					select (theAU) into theAU
					where string.CompareOrdinal(Misc.ReadRequest(theAU.UnitClass), Local_UCString) == 0
					select theAU;
				int num = source.Count();
				System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem();
				listViewItem.Text = Conversions.ToString(num) + "x " + Local_UCString;
				string text;
				if (source.ElementAtOrDefault(0).IsAircraft)
				{
					text = "Aircraft";
				}
				else if (source.ElementAtOrDefault(0).IsShip)
				{
					text = "Ship";
				}
				else if (source.ElementAtOrDefault(0).IsSubmarine)
				{
					text = "Submarine";
				}
				else if (source.ElementAtOrDefault(0).IsFacility)
				{
					text = "Facility";
				}
				else if (source.ElementAtOrDefault(0).IsMobileGroundUnit)
				{
					text = "GroundUnit";
				}
				else if (source.ElementAtOrDefault(0).IsSatellite)
				{
					text = "Satellite";
				}
				else
				{
					if (!source.ElementAtOrDefault(0).IsSatellite)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						continue;
					}
					text = "Weapon";
				}
				listViewItem.Tag = text + "_" + Conversions.ToString(source.ElementAtOrDefault(0).DBID);
				ListView_GroupMembers.Items.Add(listViewItem);
			}
			return;
		}
		foreach (ActiveUnit item2 in from theAU in _AuthenticationVisitor.Units.Values
			select (theAU) into theAU
			orderby theAU.Name
			select theAU)
		{
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
			listViewItem2.Text = item2.Name + " (" + item2.UnitClass + ")";
			listViewItem2.Tag = item2.ObjectID;
			ListView_GroupMembers.Items.Add(listViewItem2);
		}
	}

	private void DisableInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		Expander_GroupMembers.Header = "编队组成：";
	}

	private void UpdateInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		Expander_GroupMembers.Header = "编队组成：";
		ReadInterruptibleSetter();
	}

	private void InsertInterruptibleSetter(object sender, RoutedEventArgs e)
	{
	}

	private void PrepareInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			ActiveUnit activeUnit_ = (ActiveUnit)Client.SelectedUnit;
			ReflectInterruptibleSetter(ref activeUnit_);
		}
	}

	private void ReflectInterruptibleSetter(ref ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 == null)
		{
			return;
		}
		ListView_TankerClients.Items.Clear();
		if (activeUnit_0.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			List<KeyValuePair<string, Aircraft_AirOps.GEnum6>> list = new List<KeyValuePair<string, Aircraft_AirOps.GEnum6>>();
			list.AddRange(aircraft.AirOps.A2AR_Connections);
			Aircraft aircraft2 = null;
			foreach (KeyValuePair<string, Aircraft_AirOps.GEnum6> item in list)
			{
				if (Client.CurrentScenario.ActiveUnits.ContainsKey(item.Key))
				{
					aircraft2 = (Aircraft)Client.CurrentScenario.ActiveUnits[item.Key];
					System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem();
					listViewItem.Text = "加油：" + aircraft2.Name + " (" + aircraft2.UnitClass + ")";
					listViewItem.Tag = "飞机_" + Conversions.ToString(aircraft2.DBID);
					ListView_TankerClients.Items.Add(listViewItem);
				}
				else
				{
					ConcurrentDictionary<string, Aircraft_AirOps.GEnum6> a2AR_Connections = aircraft.AirOps.A2AR_Connections;
					string key = item.Key;
					Aircraft_AirOps.GEnum6 value = Aircraft_AirOps.GEnum6.Drogue;
					a2AR_Connections.TryRemove(key, out value);
					aircraft.AirOps.A2AR_NumberOfReceiverHookups.Add(new ActiveUnit_Struct(aircraft2.GetUnitSide(), aircraft2.ObjectID, aircraft2.Name, aircraft2.DBID));
				}
			}
			List<KeyValuePair<string, byte>> list2 = new List<KeyValuePair<string, byte>>();
			list2.AddRange(aircraft.AirOps.RefuellingQueue);
			{
				foreach (KeyValuePair<string, byte> item2 in list2)
				{
					if (Client.CurrentScenario.ActiveUnits.ContainsKey(item2.Key))
					{
						aircraft2 = (Aircraft)Client.CurrentScenario.ActiveUnits[item2.Key];
						System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
						listViewItem2.Text = "在队列中：" + aircraft2.Name + " (" + aircraft2.UnitClass + ")";
						listViewItem2.Tag = "飞机_" + Conversions.ToString(aircraft2.DBID);
						ListView_TankerClients.Items.Add(listViewItem2);
					}
					else
					{
						ConcurrentDictionary<string, byte> refuellingQueue = aircraft.AirOps.RefuellingQueue;
						string key2 = item2.Key;
						byte value2 = 0;
						refuellingQueue.TryRemove(key2, out value2);
					}
				}
				return;
			}
		}
		if (!activeUnit_0.IsShip)
		{
			return;
		}
		Ship ship = (Ship)activeUnit_0;
		if (!string.IsNullOrEmpty(((Ship)activeUnit_0).DockingOps.UNREP_Starboard_ReceiverUnitID))
		{
			Ship ship2 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_0).DockingOps.UNREP_Starboard_ReceiverUnitID];
			if (ship2 != null)
			{
				System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
				listViewItem3.Text = "补给，右舷：" + ship2.Name + " (" + ship2.UnitClass + ")";
				listViewItem3.Tag = "舰船_" + Conversions.ToString(ship2.DBID);
				ListView_TankerClients.Items.Add(listViewItem3);
			}
		}
		if (!string.IsNullOrEmpty(((Ship)activeUnit_0).DockingOps.UNREP_Port_ReceiverUnitID))
		{
			Ship ship3 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_0).DockingOps.UNREP_Port_ReceiverUnitID];
			if (ship3 != null)
			{
				System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
				listViewItem4.Text = "补给，左舷：" + ship3.Name + " (" + ship3.UnitClass + ")";
				listViewItem4.Tag = "舰船_" + Conversions.ToString(ship3.DBID);
				ListView_TankerClients.Items.Add(listViewItem4);
			}
		}
		if (!string.IsNullOrEmpty(((Ship)activeUnit_0).DockingOps.UNREP_Astern_ReceiverUnitID))
		{
			Ship ship4 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_0).DockingOps.UNREP_Astern_ReceiverUnitID];
			if (ship4 != null)
			{
				System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem();
				listViewItem5.Text = "补给，船尾：" + ship4.Name + " (" + ship4.UnitClass + ")";
				listViewItem5.Tag = "舰船_" + Conversions.ToString(ship4.DBID);
				ListView_TankerClients.Items.Add(listViewItem5);
			}
		}
		foreach (string item3 in ship.DockingOps.UNREP_Queue)
		{
			Ship ship5 = (Ship)Client.CurrentScenario.ActiveUnits[item3];
			if (ship5 != null)
			{
				System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
				listViewItem6.Text = "在队列中：" + ship5.Name + " (" + ship5.UnitClass + ")";
				listViewItem6.Tag = "舰船_" + Conversions.ToString(ship5.DBID);
				ListView_TankerClients.Items.Add(listViewItem6);
			}
		}
	}

	private void VisitInterruptibleSetter(object sender, SizeChangedEventArgs e)
	{
		m_AccountVisitor?.Invoke();
	}

	private void RestartInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (_InfoVisitor == null)
			{
				return;
			}
			ItemExporter.ConnectInterruptibleTemplate.ContactReport.theContact = _InfoVisitor;
		}
		else
		{
			if (!Client.SelectedUnit.DisableWriter())
			{
				return;
			}
			ItemExporter.ConnectInterruptibleTemplate.ContactReport.theContact = (Contact)Client.SelectedUnit;
		}
		ItemExporter.ConnectInterruptibleTemplate.ContactReport.Show();
	}

	private void TestInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.ShowCargoOps();
	}

	private void StopInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		Client.ShowDockingOps();
	}

	private void CancelInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MCMWindow_0.Show();
		}
	}

	private void VerifyInterruptibleSetter(object sender, SelectionChangedEventArgs e)
	{
		if (ListView_GroupMembers.SelectedItem == null)
		{
			return;
		}
		if ((int)_AuthenticationVisitor.Type <= 2)
		{
			string text = Conversions.ToString(NewLateBinding.LateGet(ListView_GroupMembers.SelectedItem, null, "Tag", new object[0], null, null, null));
			if (Client.CurrentScenario.ActiveUnits.ContainsKey(text))
			{
				Client.SelectThisUnit(Client.CurrentScenario.ActiveUnits[text], bool_0: true);
				if (Client.CurrentMapProfile.ViewMode == MapProfile.MapViewMode.GroupView)
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.SwitchView();
				}
			}
		}
		else
		{
			string text2 = Conversions.ToString(NewLateBinding.LateGet(ListView_GroupMembers.SelectedItem, null, "Tag", new object[0], null, null, null));
			string string_ = text2.ToString().Split('_')[0];
			int int_ = Conversions.ToInteger(text2.ToString().Split('_')[1]);
			Client.smethod_0(string_, int_);
		}
	}

	private void ListInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsGroup)
		{
			((Group)Client.SelectedUnit).Kinematics.LeadAllowedToSlowDown = CB_GroupLeadSlowDown.IsChecked.Value;
		}
	}

	private void ResolveInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Hyperlink_Mission.Tag != null)
		{
			Client.MissionEditorWindow.SelectedMissionLink = (Mission)Hyperlink_Mission.Tag;
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAll();
			}
			else
			{
				Client.MissionEditorWindow.Show();
			}
		}
	}

	private void PostInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (paramsVisitor == null)
			{
				return;
			}
		}
		else
		{
			paramsVisitor = null;
			if (Client.SelectedUnit.IsActiveUnit)
			{
				paramsVisitor = (ActiveUnit)Client.SelectedUnit;
			}
			if (Client.SelectedUnit.DisableWriter())
			{
				paramsVisitor = ((Contact)Client.SelectedUnit).ActualUnit;
			}
			if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				paramsVisitor = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
			}
			if (paramsVisitor == null)
			{
				return;
			}
		}
		Client.smethod_1(paramsVisitor);
	}

	private void RunInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (paramsVisitor == null)
			{
				return;
			}
		}
		else
		{
			paramsVisitor = null;
			if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				paramsVisitor = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
			}
			else
			{
				if (!Client.SelectedUnit.IsAircraft)
				{
					return;
				}
				paramsVisitor = (ActiveUnit)Client.SelectedUnit;
			}
			if (paramsVisitor == null)
			{
				return;
			}
		}
		Client.smethod_1(paramsVisitor, "Loadout" + Conversions.ToString(((Aircraft)paramsVisitor).Int32_0));
	}

	private void StartInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (paramsVisitor == null)
			{
				return;
			}
			ItemExporter.ConnectInterruptibleTemplate.UnitMessageLog.SelectedUnitID = paramsVisitor.ObjectID;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.UnitMessageLog.SelectedUnitID = Client.SelectedUnit.ObjectID;
		}
		ItemExporter.ConnectInterruptibleTemplate.UnitMessageLog.Show();
	}

	private void AssetInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		MasterGrid.ShowGridLines = GameGeneral.Beta_UIGridLines;
	}

	[SpecialName]
	private void SetTextBlock_MissionVisibility(Visibility visibility_0)
	{
		TextBlock_Mission.Visibility = visibility_0;
	}

	[SpecialName]
	private void SetTextBlock_AssignedHostVisibility(Visibility visibility_0)
	{
		TextBlock_AssignedHost.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_0(Visibility visibility_0)
	{
		ComponentStatusLabel.Visibility = visibility_0;
		ComponentStatusDockPanel.Visibility = visibility_0;
	}

	[SpecialName]
	private void SetCB_GroupLeadSlowDownVisibility(Visibility visibility_0)
	{
		CB_GroupLeadSlowDown.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_1(Visibility visibility_0)
	{
		Button_Sensors.Visibility = visibility_0;
		Button_Weapons.Visibility = visibility_0;
		Button_Comms.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_2(Visibility visibility_0)
	{
		Label_FloodDamage.Visibility = visibility_0;
		PB_FloodDamage.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_3(Visibility visibility_0)
	{
		Label_FireDamage.Visibility = visibility_0;
		PB_FireDamage.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_4(Visibility visibility_0)
	{
		Label_DamageLabel.Visibility = visibility_0;
		Label_UnitDamage.Visibility = visibility_0;
		Button_Damage.Visibility = visibility_0;
	}

	[SpecialName]
	private void method_5(Visibility visibility_0)
	{
		Button_DockOps.Visibility = visibility_0;
		Button_AirOps.Visibility = visibility_0;
	}

	[SpecialName]
	private void SetTextBlock_UnitStatusVisibility(Visibility visibility_0)
	{
		TextBlock_UnitStatus.Visibility = visibility_0;
	}

	private void PrintInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.AddRemoveDockedBoats();
	}

	private void DefineInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.AddRemoveAircraft();
	}

	private void PublishInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.AddRemoveCargo();
	}

	private void AwakeInterruptibleSetter(object sender, SelectionChangedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			((ActiveUnit)Client.SelectedUnit).DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)Combo_Supplier.SelectedIndex;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unitstatus_wpf.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			MasterGrid = (Grid)target;
			break;
		case 2:
			Label_UnitName = (System.Windows.Controls.Label)target;
			break;
		case 3:
			Image_UnitImage = (Image)target;
			break;
		case 4:
			OuterTextBlock_UnitClass = (TextBlock)target;
			break;
		case 5:
			Hyperlink_UnitClass = (Hyperlink)target;
			Hyperlink_UnitClass.Click += PostInterruptibleSetter;
			break;
		case 6:
			TextBlock_UnitClass = (Run)target;
			break;
		case 7:
			OuterTextBlock_UnitCategory = (TextBlock)target;
			break;
		case 8:
			TextBlock_UnitCategory = (Run)target;
			break;
		case 9:
			OuterTextBlock_UnitType = (TextBlock)target;
			break;
		case 10:
			TextBlock_UnitType = (Run)target;
			break;
		case 11:
			OuterTextBlock_FiringParent = (TextBlock)target;
			break;
		case 12:
			TextBlock_FiringParent = (Run)target;
			break;
		case 13:
			Label_UnitProficiency = (System.Windows.Controls.Label)target;
			break;
		case 14:
			Button_ContactReport = (System.Windows.Controls.Button)target;
			Button_ContactReport.Click += RestartInterruptibleSetter;
			break;
		case 15:
			Button_UnitMessageLog = (System.Windows.Controls.Button)target;
			Button_UnitMessageLog.Click += StartInterruptibleSetter;
			break;
		case 16:
			Expander_GroupMembers = (Expander)target;
			Expander_GroupMembers.Collapsed += DisableInterruptibleSetter;
			Expander_GroupMembers.Expanded += UpdateInterruptibleSetter;
			break;
		case 17:
			ListView_GroupMembers = (System.Windows.Controls.ListView)target;
			break;
		case 18:
			TextBlock_Loadout = (TextBlock)target;
			break;
		case 19:
			Hyperlink_Loadout = (Hyperlink)target;
			Hyperlink_Loadout.Click += RunInterruptibleSetter;
			break;
		case 20:
			TextBlock_LoadoutName = (Run)target;
			break;
		case 21:
			Label_UnitSide = (System.Windows.Controls.Label)target;
			break;
		case 22:
			Label_UnitCourse = (System.Windows.Controls.Label)target;
			break;
		case 23:
			Label_UnitSpeed = (System.Windows.Controls.Label)target;
			break;
		case 24:
			Label_UnitAlt = (System.Windows.Controls.Label)target;
			break;
		case 25:
			CB_GroupLeadSlowDown = (System.Windows.Controls.CheckBox)target;
			CB_GroupLeadSlowDown.Click += ListInterruptibleSetter;
			break;
		case 26:
			Label_DamageLabel = (System.Windows.Controls.Label)target;
			break;
		case 27:
			Label_UnitDamage = (TextBlock)target;
			break;
		case 28:
			Button_Damage = (System.Windows.Controls.Button)target;
			Button_Damage.Click += FillInterruptibleSetter;
			break;
		case 29:
			ComponentStatusLabel = (System.Windows.Controls.Label)target;
			break;
		case 30:
			ComponentStatusDockPanel = (DockPanel)target;
			break;
		case 31:
			PB_ComponentsDestroyed = (System.Windows.Controls.ProgressBar)target;
			break;
		case 32:
			PB_ComponentsHeavyDamage = (System.Windows.Controls.ProgressBar)target;
			break;
		case 33:
			PB_ComponentsMediumDamage = (System.Windows.Controls.ProgressBar)target;
			break;
		case 34:
			PB_ComponentsLightDamage = (System.Windows.Controls.ProgressBar)target;
			break;
		case 35:
			PB_ComponentsOK = (System.Windows.Controls.ProgressBar)target;
			break;
		case 36:
			Label_FireDamage = (System.Windows.Controls.Label)target;
			break;
		case 37:
			PB_FireDamage = (System.Windows.Controls.ProgressBar)target;
			break;
		case 38:
			Label_FloodDamage = (System.Windows.Controls.Label)target;
			break;
		case 39:
			PB_FloodDamage = (System.Windows.Controls.ProgressBar)target;
			break;
		case 40:
			Label_GTolerance = (System.Windows.Controls.Label)target;
			break;
		case 41:
			PB_GTolerance = (System.Windows.Controls.ProgressBar)target;
			break;
		case 42:
			Button_MCM = (System.Windows.Controls.Button)target;
			Button_MCM.Click += CancelInterruptibleSetter;
			break;
		case 43:
			Button_CargoOps = (System.Windows.Controls.Button)target;
			Button_CargoOps.Click += TestInterruptibleSetter;
			break;
		case 44:
			Button_Magazines = (System.Windows.Controls.Button)target;
			Button_Magazines.Click += PopInterruptibleSetter;
			break;
		case 45:
			Button_DockOps = (System.Windows.Controls.Button)target;
			Button_DockOps.Click += StopInterruptibleSetter;
			break;
		case 46:
			Button_AirOps = (System.Windows.Controls.Button)target;
			Button_AirOps.Click += CalculateInterruptibleSetter;
			break;
		case 47:
			Label_Supply = (System.Windows.Controls.Label)target;
			break;
		case 48:
			Combo_Supplier = (System.Windows.Controls.ComboBox)target;
			Combo_Supplier.SelectionChanged += AwakeInterruptibleSetter;
			break;
		case 49:
			Dockpanel_EditHosted = (DockPanel)target;
			break;
		case 50:
			Button_EditHostCargo = (System.Windows.Controls.Button)target;
			Button_EditHostCargo.Click += PublishInterruptibleSetter;
			break;
		case 51:
			Button_EditHostedBoats = (System.Windows.Controls.Button)target;
			Button_EditHostedBoats.Click += PrintInterruptibleSetter;
			break;
		case 52:
			Button_EditHostedAC = (System.Windows.Controls.Button)target;
			Button_EditHostedAC.Click += DefineInterruptibleSetter;
			break;
		case 53:
			TextBlock_AssignedHost = (TextBlock)target;
			break;
		case 54:
			TextBlock_Mission = (TextBlock)target;
			break;
		case 55:
			Hyperlink_Mission = (Hyperlink)target;
			Hyperlink_Mission.Click += ResolveInterruptibleSetter;
			break;
		case 56:
			TextBlock_MissionName = (Run)target;
			break;
		case 57:
			TextBlock_QueuedMission = (TextBlock)target;
			break;
		case 58:
			tip1 = (System.Windows.Controls.ToolTip)target;
			break;
		case 59:
			TextBlock_UnitStatus = (TextBlock)target;
			break;
		case 60:
			TextBlock_PrimaryTarget = (TextBlock)target;
			break;
		case 61:
			TextBlock_TimeUnderway = (TextBlock)target;
			break;
		case 62:
			Expander_TankerClients = (Expander)target;
			Expander_TankerClients.Expanded += PrepareInterruptibleSetter;
			Expander_TankerClients.Collapsed += InsertInterruptibleSetter;
			break;
		case 63:
			ListView_TankerClients = (System.Windows.Controls.ListView)target;
			break;
		case 64:
			Button_Sensors = (System.Windows.Controls.Button)target;
			Button_Sensors.Click += InstantiateInterruptibleSetter;
			break;
		case 65:
			Button_Comms = (System.Windows.Controls.Button)target;
			Button_Comms.Click += CompareInterruptibleSetter;
			break;
		case 66:
			Button_Weapons = (System.Windows.Controls.Button)target;
			Button_Weapons.Click += CreateInterruptibleSetter;
			break;
		case 67:
			Label_ContactWRAType = (System.Windows.Controls.Label)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
