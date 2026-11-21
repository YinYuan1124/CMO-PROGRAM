using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Command.Messages;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ScenarioFeatures : Window, IComponentConnector
{
	private bool m_TagPredicate;

	internal StackPanel StackPanel1;

	internal CheckBox CB_GunfireControl;

	internal CheckBox CB_UnlimitedBaseMags;

	internal CheckBox CB_ACDamage;

	internal CheckBox CB_RealisticSubComms;

	internal CheckBox CB_TerrainTypeEffects;

	internal CheckBox CB_TerrainTypeEffects_Advanced;

	internal CheckBox CB_CommsDisruption;

	internal CheckBox CB_CommsJamming;

	internal CheckBox CB_WeatherAffectsShipSpeed;

	internal CheckBox CB_LandingPlannerInstantLoading;

	internal CheckBox CB_AC_NAW_Loadout;

	internal Button Button_OK;

	internal Button Button_Cancel;

	private bool _contentLoaded;

	public ScenarioFeatures()
	{
		base.Loaded += DisableInterruptibleResolver;
		base.KeyDown += PrepareInterruptibleResolver;
		base.Closing += ReflectInterruptibleResolver;
		InitializeComponent();
	}

	private void DisableInterruptibleResolver(object sender, RoutedEventArgs e)
	{
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			Button_OK.Visibility = Visibility.Visible;
			Button_Cancel.Visibility = Visibility.Visible;
			CB_GunfireControl.IsEnabled = true;
			CB_UnlimitedBaseMags.IsEnabled = true;
			if (Licensing.UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption.AircraftDamage))
			{
				CB_ACDamage.IsEnabled = true;
				((Control)CB_ACDamage.Content).Foreground = Brushes.White;
			}
			else
			{
				CB_ACDamage.IsEnabled = false;
				((Control)CB_ACDamage.Content).Foreground = Brushes.Gray;
			}
			if (Licensing.UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption.CommsDisruption))
			{
				CB_CommsDisruption.IsEnabled = true;
				((Control)CB_CommsDisruption.Content).Foreground = Brushes.White;
			}
			else
			{
				CB_CommsDisruption.IsEnabled = false;
				((Control)CB_CommsDisruption.Content).Foreground = Brushes.Gray;
			}
			if (Licensing.UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption.CommsJamming))
			{
				CB_CommsJamming.Visibility = Visibility.Visible;
			}
			else
			{
				CB_CommsJamming.Visibility = Visibility.Collapsed;
			}
		}
		else
		{
			Button_OK.Visibility = Visibility.Collapsed;
			Button_Cancel.Visibility = Visibility.Collapsed;
			CB_GunfireControl.IsEnabled = false;
			CB_UnlimitedBaseMags.IsEnabled = false;
			CB_CommsJamming.IsEnabled = false;
			CB_CommsDisruption.IsEnabled = false;
			CB_ACDamage.IsEnabled = false;
		}
		CB_GunfireControl.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		CB_UnlimitedBaseMags.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		CB_RealisticSubComms.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms);
		CB_TerrainTypeEffects.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
		CB_TerrainTypeEffects_Advanced.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		CB_CommsJamming.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsJamming);
		CB_CommsDisruption.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption);
		CB_ACDamage.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage);
		CB_WeatherAffectsShipSpeed.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		CB_LandingPlannerInstantLoading.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		CB_AC_NAW_Loadout.IsChecked = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		base.Height = StackPanel1.Height + 5.0;
	}

	private void UpdateInterruptibleResolver(object sender, RoutedEventArgs e)
	{
		if (CB_GunfireControl.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.DetailedGunFireControl);
		}
		if (CB_UnlimitedBaseMags.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		}
		string text = "";
		if (CB_RealisticSubComms.IsChecked.GetValueOrDefault())
		{
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
			{
				text = "Enabling 'Realistic Sub Communications' has changed the default WRA Doctrine for new missions that target submarines to 'Tight' to prevent friendly fire. Existing missions have not been changed.";
			}
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.RealisticSubComms);
		}
		else
		{
			if (Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms))
			{
				text = "Disabling 'Realistic Sub Communications' has changed the default WRA Doctrine for new missions that target submarines to 'Free.' Existing missions have not been changed.";
			}
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.RealisticSubComms);
		}
		if (CB_TerrainTypeEffects.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.LandTypeEffects);
		}
		if (CB_TerrainTypeEffects_Advanced.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced);
		}
		if (CB_CommsJamming.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.CommsJamming);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.CommsJamming);
		}
		if (CB_ACDamage.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.AircraftDamage);
		}
		if (CB_WeatherAffectsShipSpeed.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		}
		if (CB_LandingPlannerInstantLoading.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
		}
		if (CB_CommsDisruption.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.CommsDisruption);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.CommsDisruption);
		}
		if (CB_AC_NAW_Loadout.IsChecked.GetValueOrDefault())
		{
			Client.CurrentScenario.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		}
		else
		{
			Client.CurrentScenario.DeclaredFeatures.Remove(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustToScenActiveFeatureChanges();
		Close();
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			DarkMessageBox.ShowWarning(text, "");
		}
	}

	private void InsertInterruptibleResolver(object sender, RoutedEventArgs e)
	{
		Close();
	}

	private void PrepareInterruptibleResolver(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Select && base.Visibility == Visibility.Visible)
		{
			Close();
		}
		else if (e.Key == Key.Delete)
		{
			_ = base.Visibility;
		}
	}

	private void ReflectInterruptibleResolver(object sender, CancelEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void VisitInterruptibleResolver(object sender, RoutedEventArgs e)
	{
		if (CB_ACDamage.IsChecked.GetValueOrDefault())
		{
			DarkMessageBox.ShowWarning("您似乎正在激活“飞机损坏”功能。如果此想定已在v1.12之前构建且之后未重建，则可能是一架或多架飞机未设置其正确的DP值，并且可能在想定运行时立即显示为损坏甚至毁坏。请确保在测试和发布之前对想定进行了深度重建。", "CAUTION!");
		}
	}

	private void RestartInterruptibleResolver(object sender, RoutedEventArgs e)
	{
		if (CB_AC_NAW_Loadout.IsChecked.GetValueOrDefault())
		{
			DarkMessageBox.ShowWarning("It appears that you are activating the 'Aircraft Loadout weather TOD limitation' feature. If this scenario has been built prior to the introduction of this feature, it is likely that one or more aircraft will not take off due to their loadout not being able to fly during night time or in heavy rain. This might also lead some aircraft to crash when landing if they are trying to do that in unfavourable conditions. This could lead to losing them and to serious damage to the runway", "CAUTION!");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/scenariofeatures.xaml", UriKind.Relative);
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
			StackPanel1 = (StackPanel)target;
			break;
		case 2:
			CB_GunfireControl = (CheckBox)target;
			break;
		case 3:
			CB_UnlimitedBaseMags = (CheckBox)target;
			break;
		case 4:
			CB_ACDamage = (CheckBox)target;
			break;
		case 5:
			CB_RealisticSubComms = (CheckBox)target;
			break;
		case 6:
			CB_TerrainTypeEffects = (CheckBox)target;
			break;
		case 7:
			CB_TerrainTypeEffects_Advanced = (CheckBox)target;
			break;
		case 8:
			CB_CommsDisruption = (CheckBox)target;
			break;
		case 9:
			CB_CommsJamming = (CheckBox)target;
			break;
		case 10:
			CB_WeatherAffectsShipSpeed = (CheckBox)target;
			break;
		case 11:
			CB_LandingPlannerInstantLoading = (CheckBox)target;
			break;
		case 12:
			CB_AC_NAW_Loadout = (CheckBox)target;
			CB_AC_NAW_Loadout.Checked += RestartInterruptibleResolver;
			CB_AC_NAW_Loadout.Unchecked += RestartInterruptibleResolver;
			break;
		case 13:
			Button_OK = (Button)target;
			Button_OK.Click += UpdateInterruptibleResolver;
			break;
		case 14:
			Button_Cancel = (Button)target;
			Button_Cancel.Click += InsertInterruptibleResolver;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
