using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Command.Listeners;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class FuelPanel_WPF : UserControl, IComponentConnector
{
	private ActiveUnit _IndexerTests;

	private bool m_ResolverTests;

	internal Label LblAirborneTime;

	internal Button JettisonButton;

	private bool _contentLoaded;

	public FuelPanel_WPF()
	{
		InitializeComponent();
	}

	public void Refresh(ActiveUnit activeUnit_0)
	{
		JettisonButton.Visibility = Visibility.Collapsed;
		try
		{
			_IndexerTests = activeUnit_0;
			if (activeUnit_0 == null)
			{
				base.Visibility = Visibility.Collapsed;
				base.DataContext = null;
				return;
			}
			if (activeUnit_0.IsAircraft)
			{
				List<WeaponRec> list = ((Aircraft)_IndexerTests).SetupFacade(Weapon._WeaponType.DropTank);
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					JettisonButton.Visibility = Visibility.Visible;
				}
				Aircraft aircraft = (Aircraft)activeUnit_0;
				if (aircraft.AirborneTime <= 0f)
				{
					LblAirborneTime.Visibility = Visibility.Collapsed;
				}
				else
				{
					LblAirborneTime.Visibility = Visibility.Visible;
					string text = Misc.UpdateRequest((long)Math.Round(aircraft.AirborneTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
					if (aircraft.MAX_Exhaustion == float.MaxValue)
					{
						LblAirborneTime.Foreground = Brushes.White;
						LblAirborneTime.Content = text + " 飞行时间";
					}
					else
					{
						float current_Exhaustion = ((Aircraft)activeUnit_0).Current_Exhaustion;
						float mAX_Exhaustion = ((Aircraft)activeUnit_0).MAX_Exhaustion;
						float num = current_Exhaustion / mAX_Exhaustion * 100f;
						if (num >= 70f && num <= 100f)
						{
							LblAirborneTime.Foreground = Brushes.Red;
						}
						else if (num >= 50f && num <= 70f)
						{
							LblAirborneTime.Foreground = Brushes.Orange;
						}
						else if (num >= 30f && num <= 50f)
						{
							LblAirborneTime.Foreground = Brushes.Yellow;
						}
						else if (num >= 10f && num <= 30f)
						{
							LblAirborneTime.Foreground = Brushes.Lime;
						}
						else if (num >= 0f && num <= 10f)
						{
							LblAirborneTime.Foreground = Brushes.LightGreen;
						}
						LblAirborneTime.Content = "飞行时间：" + text + " / " + Misc.UpdateRequest((long)Math.Round(mAX_Exhaustion));
					}
				}
			}
			else
			{
				LblAirborneTime.Visibility = Visibility.Collapsed;
			}
			if ((activeUnit_0.CommStuff.IsConnectedToSideNetwork || InterpreterObjectListener.CollectInterruptibleTask(activeUnit_0) || Client.CurrentMapProfile.GodsEye) && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				base.Visibility = Visibility.Visible;
				if (base.DataContext == null)
				{
					base.DataContext = new FuelViewModel(activeUnit_0);
					return;
				}
				FuelViewModel fuelViewModel = (FuelViewModel)base.DataContext;
				if (fuelViewModel.theUnit == activeUnit_0)
				{
					fuelViewModel.Refresh();
				}
				else
				{
					base.DataContext = new FuelViewModel(activeUnit_0);
				}
			}
			else
			{
				base.Visibility = Visibility.Collapsed;
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
	}

	private void PatchAnnotation(object sender, RoutedEventArgs e)
	{
		if (_IndexerTests != null && _IndexerTests.IsAircraft)
		{
			((Aircraft)_IndexerTests).Weaponry.JettisonOrdnance(bool_1: true, bool_2: true, bool_3: false, bool_4: false, bool_5: false, bool_6: false, bool_7: false);
			JettisonButton.Visibility = Visibility.Collapsed;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/fuelpanel_wpf.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
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
			LblAirborneTime = (Label)target;
			break;
		case 2:
			JettisonButton = (Button)target;
			JettisonButton.Click += PatchAnnotation;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
