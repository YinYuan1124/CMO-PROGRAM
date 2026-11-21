using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;
using Odyssey.Controls;

namespace Command;

[DesignerGenerated]
public class RightColumnWPF : UserControl, IComponentConnector
{
	private bool _TokenizerPredicate;

	public bool Refreshing;

	private bool stubPredicate;

	private bool writerPredicate;

	internal ScrollViewer MyScrollViewer;

	internal Grid MyGrid;

	internal RowDefinition RowDefinition_UsedSpace;

	internal RowDefinition RowDefinition_ExtraSpace;

	internal ColumnDefinition ColumnDefinition_UsedSpace;

	internal StackPanel StackPanel_Main;

	internal OdcExpander Expander_UnitStatus;

	internal UnitStatus_WPF WPFControl_UnitStatus;

	internal OdcExpander Expander_AltSpeed;

	internal UnitSpeedAlt WPFControl_AltSpeed;

	internal OdcExpander Expander_ContactLastDetections;

	internal RecentDetections_WPF WPFControl_RecentDetections;

	internal OdcExpander Expander_UnitWeapons;

	internal UnitWeapons_WPF WPFControl_UnitWeapons;

	internal OdcExpander Expander_UnitFuel;

	internal FuelPanel_WPF WPFControl_FuelPanel;

	internal OdcExpander Expander_UnitEMCON;

	internal UnitEMCON_WPF WPFControl_UnitEMCON;

	internal OdcExpander Expander_UnitDoctrine;

	internal UnitDoctrine_WPF WPFControl_UnitDoctrine;

	private bool _contentLoaded;

	public RightColumnWPF()
	{
		_TokenizerPredicate = true;
		Refreshing = false;
		stubPredicate = false;
		InitializeComponent();
	}

	public void SuspendRefresh()
	{
		_TokenizerPredicate = false;
	}

	public void ResumeRefresh()
	{
		_TokenizerPredicate = true;
		RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
	}

	public void ReleaseReferences()
	{
		try
		{
			Expander_UnitWeapons.Visibility = Visibility.Collapsed;
			Expander_UnitFuel.Visibility = Visibility.Collapsed;
			Expander_UnitEMCON.Visibility = Visibility.Collapsed;
			Expander_UnitDoctrine.Visibility = Visibility.Collapsed;
			Expander_ContactLastDetections.Visibility = Visibility.Collapsed;
			WPFControl_UnitStatus.ReleaseReferences();
			WPFControl_FuelPanel.Refresh(null);
			UnitWeapons_WPF wpfcontrol_UnitWeapons = WPFControl_UnitWeapons;
			bool flag = false;
			bool flag2 = false;
			wpfcontrol_UnitWeapons.Refresh(null, ref flag, ref flag2);
			WPFControl_UnitEMCON.Refresh(null);
			WPFControl_UnitDoctrine.Refresh(null);
			WPFControl_RecentDetections.RefreshPanel(null, null);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshPanels(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		if (!_TokenizerPredicate)
		{
			return;
		}
		if (Client.CurrentSide == null)
		{
			((UIElement)Expander_UnitWeapons).Visibility = Visibility.Collapsed;
			((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
			((UIElement)Expander_UnitEMCON).Visibility = Visibility.Collapsed;
			((UIElement)Expander_UnitDoctrine).Visibility = Visibility.Collapsed;
			((UIElement)Expander_ContactLastDetections).Visibility = Visibility.Collapsed;
			WPFControl_FuelPanel.Refresh(null);
			UnitWeapons_WPF wPFControl_UnitWeapons = WPFControl_UnitWeapons;
			bool bool_ = false;
			bool bool_2 = false;
			wPFControl_UnitWeapons.Refresh(null, ref bool_, ref bool_2);
			WPFControl_UnitEMCON.Refresh(null);
			WPFControl_UnitDoctrine.Refresh(null);
			WPFControl_RecentDetections.RefreshPanel(null, scenario_0);
		}
		else
		{
			if (Client.SelectedUnit == null)
			{
				return;
			}
			try
			{
				Refreshing = true;
				((UIElement)Expander_UnitStatus).IsEnabled = unit_0 != null;
				if (scenario_0 == null || side_0 == null || unit_0 == null)
				{
					return;
				}
				bool bool_3 = false;
				if (unit_0.IsActiveUnit && (unit_0.GetUnitSide() == Client.CurrentSide || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
				{
					if (unit_0.IsGroup)
					{
						((HeaderedContentControl)Expander_UnitStatus).Header = "编组状态";
						((HeaderedContentControl)Expander_AltSpeed).Header = "编组高度 / 速度";
						((HeaderedContentControl)Expander_UnitWeapons).Header = "编组武器";
						((HeaderedContentControl)Expander_UnitFuel).Header = "编组燃料";
						((HeaderedContentControl)Expander_UnitEMCON).Header = "编组电磁管控";
					}
					else
					{
						((HeaderedContentControl)Expander_UnitStatus).Header = "单元状态";
						((HeaderedContentControl)Expander_AltSpeed).Header = "单元高度 / 速度";
						((HeaderedContentControl)Expander_UnitWeapons).Header = "单元武器";
						((HeaderedContentControl)Expander_UnitFuel).Header = "单元燃料";
						((HeaderedContentControl)Expander_UnitEMCON).Header = "单元电磁管控";
					}
					bool bool_4 = Expander_UnitWeapons.IsExpanded;
					WPFControl_UnitWeapons.Refresh((ActiveUnit)unit_0, ref bool_3, ref bool_4);
					if (Expander_UnitWeapons.IsExpanded != bool_4 && bool_4)
					{
						Expander_UnitWeapons.IsExpanded = true;
						Expander_UnitWeapons.IsExpanded = false;
					}
					if (bool_3)
					{
						((UIElement)Expander_UnitWeapons).Visibility = Visibility.Visible;
					}
					else
					{
						((UIElement)Expander_UnitWeapons).Visibility = Visibility.Collapsed;
					}
					((UIElement)Expander_UnitEMCON).Visibility = Visibility.Visible;
					((UIElement)Expander_UnitDoctrine).Visibility = Visibility.Visible;
					((UIElement)Expander_AltSpeed).Visibility = Visibility.Visible;
					if (unit_0.IsGroup)
					{
						Group group = (Group)unit_0;
						if (group.Type == Group.GroupType.NavalBase || group.Type == Group.GroupType.AirBase)
						{
							((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
						}
					}
					WPFControl_UnitEMCON.Refresh((ActiveUnit)unit_0);
					WPFControl_UnitDoctrine.Refresh((ActiveUnit)unit_0);
					WPFControl_AltSpeed.Refresh(bool_0: true);
					if (unit_0.IsShip && ((Ship)unit_0).IsNuke)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
					}
					else if (unit_0.IsSubmarine && (((Submarine)unit_0).IsNuke || ((Submarine)unit_0).Fuel_ReadOnly.Count == 0))
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
					}
					else if (unit_0.IsFacility && ((ActiveUnit)unit_0).Fuel_ReadOnly.Count < 1)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
						((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					}
					else if (unit_0.IsWeapon)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
						((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					}
					else if (unit_0.IsSatellite)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
						((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					}
					else
					{
						WPFControl_FuelPanel.Refresh((ActiveUnit)unit_0);
						((UIElement)Expander_UnitFuel).Visibility = Visibility.Visible;
					}
					if (Expander_UnitFuel.IsExpanded)
					{
						Expander_UnitFuel.IsExpanded = false;
						Expander_UnitFuel.IsExpanded = true;
					}
					else
					{
						Expander_UnitFuel.IsExpanded = true;
						Expander_UnitFuel.IsExpanded = false;
					}
					if (Expander_AltSpeed.IsExpanded)
					{
						Expander_AltSpeed.IsExpanded = false;
						Expander_AltSpeed.IsExpanded = true;
					}
					else
					{
						Expander_AltSpeed.IsExpanded = true;
						Expander_AltSpeed.IsExpanded = false;
					}
				}
				else if (unit_0.DisableWriter())
				{
					((HeaderedContentControl)Expander_UnitStatus).Header = "目标状态";
					((UIElement)Expander_UnitWeapons).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitEMCON).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitDoctrine).Visibility = Visibility.Collapsed;
					((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					WPFControl_FuelPanel.Refresh(null);
					UnitWeapons_WPF wPFControl_UnitWeapons2 = WPFControl_UnitWeapons;
					bool bool_5 = false;
					wPFControl_UnitWeapons2.Refresh(null, ref bool_3, ref bool_5);
					WPFControl_UnitEMCON.Refresh(null);
					WPFControl_UnitDoctrine.Refresh(null);
				}
				else
				{
					((UIElement)Expander_UnitWeapons).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitFuel).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitEMCON).Visibility = Visibility.Collapsed;
					((UIElement)Expander_UnitDoctrine).Visibility = Visibility.Collapsed;
					((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					WPFControl_FuelPanel.Refresh(null);
					UnitWeapons_WPF wPFControl_UnitWeapons3 = WPFControl_UnitWeapons;
					bool bool_6 = false;
					wPFControl_UnitWeapons3.Refresh(null, ref bool_3, ref bool_6);
					WPFControl_UnitEMCON.Refresh(null);
					WPFControl_UnitDoctrine.Refresh(null);
				}
				if (unit_0.DisableWriter())
				{
					((UIElement)Expander_ContactLastDetections).Visibility = Visibility.Visible;
					WPFControl_RecentDetections.Visibility = Visibility.Visible;
					((UIElement)Expander_AltSpeed).Visibility = Visibility.Collapsed;
					if (Expander_ContactLastDetections.IsExpanded)
					{
						WPFControl_RecentDetections.RefreshPanel((Contact)unit_0, scenario_0);
					}
				}
				else
				{
					((UIElement)Expander_ContactLastDetections).Visibility = Visibility.Collapsed;
					WPFControl_RecentDetections.Visibility = Visibility.Collapsed;
				}
				if (Expander_UnitStatus.IsExpanded)
				{
					WPFControl_UnitStatus.RefreshPanel(scenario_0, side_0, unit_0);
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
			finally
			{
				Refreshing = false;
			}
		}
	}

	public double GetElementPixelSize(UIElement uielement_0)
	{
		PresentationSource presentationSource = PresentationSource.FromVisual(uielement_0);
		Matrix transformToDevice;
		if (presentationSource == null)
		{
			using HwndSource hwndSource = new HwndSource(default(HwndSourceParameters));
			transformToDevice = hwndSource.CompositionTarget.TransformToDevice;
		}
		else
		{
			transformToDevice = presentationSource.CompositionTarget.TransformToDevice;
		}
		return transformToDevice.M11;
	}

	public void PositionCorrectlyWithinMainform(MainForm mainForm_0)
	{
		if (Client.theElementHostRightColumn != null)
		{
			double elementPixelSize = GetElementPixelSize(this);
			MyScrollViewer.MaxHeight = (double)(mainForm_0.WorldWindow1.Height + 110) / elementPixelSize;
			if (!stubPredicate)
			{
				stubPredicate = true;
				Client.theElementHostRightColumn.Width = (int)Math.Round(270.0 * elementPixelSize);
			}
			MainForm mainForm = (MainForm)Client.theElementHostRightColumn.Parent;
			if (mainForm != null)
			{
				_ = mainForm.Size.Width;
				_ = Client.theElementHostRightColumn.Width;
				Client.theElementHostRightColumn.Top = mainForm.MenuStrip1.Top;
			}
		}
	}

	private void DestroyInterruptibleIndexer(object sender, EventArgs e)
	{
		if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
		{
			return;
		}
		double actualHeight = StackPanel_Main.ActualHeight;
		if (Client.theElementHostRightColumn != null)
		{
			if (actualHeight > (double)(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Height - 75))
			{
				MyScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
			}
			if (actualHeight < (double)(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Height - 75) * 0.9)
			{
				MyScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
			}
		}
	}

	private void ComputeInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void PatchInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void SelectInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void CallInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void LogoutInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void ViewInterruptibleIndexer(object sender, RoutedEventArgs e)
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/rightcolumnwpf.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			MyScrollViewer = (ScrollViewer)target;
			break;
		case 2:
			MyGrid = (Grid)target;
			break;
		case 3:
			RowDefinition_UsedSpace = (RowDefinition)target;
			break;
		case 4:
			RowDefinition_ExtraSpace = (RowDefinition)target;
			break;
		case 5:
			ColumnDefinition_UsedSpace = (ColumnDefinition)target;
			break;
		case 6:
			StackPanel_Main = (StackPanel)target;
			StackPanel_Main.LayoutUpdated += DestroyInterruptibleIndexer;
			break;
		case 7:
			Expander_UnitStatus = (OdcExpander)target;
			Expander_UnitStatus.Expanded += ComputeInterruptibleIndexer;
			break;
		case 8:
			WPFControl_UnitStatus = (UnitStatus_WPF)target;
			break;
		case 9:
			Expander_AltSpeed = (OdcExpander)target;
			break;
		case 10:
			WPFControl_AltSpeed = (UnitSpeedAlt)target;
			break;
		case 11:
			Expander_ContactLastDetections = (OdcExpander)target;
			break;
		case 12:
			WPFControl_RecentDetections = (RecentDetections_WPF)target;
			break;
		case 13:
			Expander_UnitWeapons = (OdcExpander)target;
			Expander_UnitWeapons.Expanded += PatchInterruptibleIndexer;
			break;
		case 14:
			WPFControl_UnitWeapons = (UnitWeapons_WPF)target;
			break;
		case 15:
			Expander_UnitFuel = (OdcExpander)target;
			Expander_UnitFuel.Expanded += SelectInterruptibleIndexer;
			break;
		case 16:
			WPFControl_FuelPanel = (FuelPanel_WPF)target;
			break;
		case 17:
			Expander_UnitEMCON = (OdcExpander)target;
			Expander_UnitEMCON.Expanded += CallInterruptibleIndexer;
			break;
		case 18:
			WPFControl_UnitEMCON = (UnitEMCON_WPF)target;
			break;
		case 19:
			Expander_UnitDoctrine = (OdcExpander)target;
			Expander_UnitDoctrine.Expanded += LogoutInterruptibleIndexer;
			break;
		case 20:
			WPFControl_UnitDoctrine = (UnitDoctrine_WPF)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
