using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class LicenseTweaker : Window, IComponentConnector
{
	private bool m_ModelComposer;

	internal CheckBox CB_CMANOBase;

	internal CheckBox CB_NorthernInferno;

	internal CheckBox CB_ChainsOfWar;

	internal CheckBox CB_ShiftingSands;

	internal CheckBox CB_TheSilentService;

	internal CheckBox CB_DesertStorm;

	internal CheckBox CB_KashmirFire;

	internal CheckBox CB_RedTide;

	internal CheckBox CB_Falklands;

	internal CheckBox CB_CLIVE1;

	internal CheckBox CB_CLIVE2;

	internal CheckBox CB_CLIVE3;

	internal CheckBox CB_CLIVE4;

	internal CheckBox CB_CLIVE5;

	internal CheckBox CB_CLIVE6;

	internal CheckBox CB_CLIVE7;

	internal CheckBox CB_CLIVE8;

	internal CheckBox CB_CLIVE9;

	internal CheckBox CB_CLIVE10;

	internal CheckBox CB_CLIVE11;

	internal CheckBox CB_CLIVE12;

	internal CheckBox CB_CLIVE13;

	internal CheckBox CB_CSHOW1;

	internal CheckBox CB_CSHOW2;

	internal CheckBox CB_CSHOW3;

	internal CheckBox CB_CSHOW4;

	private bool _contentLoaded;

	public LicenseTweaker()
	{
		base.Loaded += ChangeRole;
		InitializeComponent();
	}

	private void ChangeRole(object sender, RoutedEventArgs e)
	{
		CB_CMANOBase.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion);
		CB_NorthernInferno.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.NorthernInferno);
		CB_ChainsOfWar.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.ChainsOfWar);
		CB_ShiftingSands.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.ShiftingSands);
		CB_TheSilentService.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.TheSilentService);
		CB_DesertStorm.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.DesertStorm);
		CB_KashmirFire.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.KashmirFire);
		CB_RedTide.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.RedTide);
		CB_Falklands.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.const_23);
		CB_CLIVE1.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_OldGrudges);
		CB_CLIVE2.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Brexit);
		CB_CLIVE3.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Spratly);
		CB_CLIVE4.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Don);
		CB_CLIVE5.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Korea);
		CB_CLIVE6.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Pole);
		CB_CLIVE7.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_BlackGold);
		CB_CLIVE8.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Commonwealth);
		CB_CLIVE9.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_Kuril);
		CB_CLIVE10.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_KingOfTheBorder);
		CB_CLIVE11.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_BrokenShield300);
		CB_CLIVE12.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_AegeanInFlames);
		CB_CLIVE13.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.LIVE_SahelSlugfest);
		CB_CSHOW1.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.Showcase_QueenElizabeth);
		CB_CSHOW2.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.Showcase_FordClass);
		CB_CSHOW3.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.Showcase_DesertFalcon);
		CB_CSHOW4.IsChecked = Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.Showcase_Icebreakers);
	}

	private void InitRole(object sender, RoutedEventArgs e)
	{
		if (CB_CMANOBase.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.CommandFullVersion);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.CommandFullVersion);
		}
	}

	private void CheckRole(object sender, RoutedEventArgs e)
	{
		if (CB_NorthernInferno.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.NorthernInferno);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.NorthernInferno);
		}
	}

	private void ConcatRole(object sender, RoutedEventArgs e)
	{
		if (CB_ChainsOfWar.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.ChainsOfWar);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.ChainsOfWar);
		}
	}

	private void InterruptRole(object sender, RoutedEventArgs e)
	{
		if (CB_ShiftingSands.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.ShiftingSands);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.ShiftingSands);
		}
	}

	private void RemoveRole(object sender, RoutedEventArgs e)
	{
		if (CB_TheSilentService.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.TheSilentService);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.TheSilentService);
		}
	}

	private void FindRole(object sender, RoutedEventArgs e)
	{
		if (CB_DesertStorm.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.DesertStorm);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.DesertStorm);
		}
	}

	private void SetRole(object sender, RoutedEventArgs e)
	{
		if (CB_KashmirFire.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.KashmirFire);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.KashmirFire);
		}
	}

	private void FillRole(object sender, RoutedEventArgs e)
	{
		if (CB_RedTide.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.RedTide);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.RedTide);
		}
	}

	private void CalculateRole(object sender, RoutedEventArgs e)
	{
		if (CB_Falklands.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.const_23);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.const_23);
		}
	}

	private void PopRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE1.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_OldGrudges);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_OldGrudges);
		}
	}

	private void InstantiateRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE2.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Brexit);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Brexit);
		}
	}

	private void CreateRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE3.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Spratly);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Spratly);
		}
	}

	private void CompareRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE4.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Don);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Don);
		}
	}

	private void ReadRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE5.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Korea);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Korea);
		}
	}

	private void DisableRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE6.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Pole);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Pole);
		}
	}

	private void UpdateRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE7.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_BlackGold);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_BlackGold);
		}
	}

	private void InsertRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE8.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Commonwealth);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Commonwealth);
		}
	}

	private void PrepareRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE9.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_Kuril);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_Kuril);
		}
	}

	private void ReflectRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE10.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_KingOfTheBorder);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_KingOfTheBorder);
		}
	}

	private void VisitRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE11.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_BrokenShield300);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_BrokenShield300);
		}
	}

	private void RestartRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE12.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_AegeanInFlames);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_AegeanInFlames);
		}
	}

	private void TestRole(object sender, RoutedEventArgs e)
	{
		if (CB_CLIVE13.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.LIVE_SahelSlugfest);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.LIVE_SahelSlugfest);
		}
	}

	private void StopRole(object sender, RoutedEventArgs e)
	{
		if (CB_CSHOW1.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.Showcase_QueenElizabeth);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.Showcase_QueenElizabeth);
		}
	}

	private void CancelRole(object sender, RoutedEventArgs e)
	{
		if (CB_CSHOW2.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.Showcase_FordClass);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.Showcase_FordClass);
		}
	}

	private void VerifyRole(object sender, RoutedEventArgs e)
	{
		if (CB_CSHOW3.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.Showcase_DesertFalcon);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.Showcase_DesertFalcon);
		}
	}

	private void ListRole(object sender, RoutedEventArgs e)
	{
		if (CB_CSHOW4.IsChecked.GetValueOrDefault())
		{
			Licensing.ActivateLicense(Licensing.ModuleLicense.Showcase_Icebreakers);
		}
		else
		{
			Licensing.DeactivateLicense(Licensing.ModuleLicense.Showcase_Icebreakers);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/licensetweaker.xaml", UriKind.Relative);
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
			CB_CMANOBase = (CheckBox)target;
			break;
		case 2:
			CB_NorthernInferno = (CheckBox)target;
			break;
		case 3:
			CB_ChainsOfWar = (CheckBox)target;
			break;
		case 4:
			CB_ShiftingSands = (CheckBox)target;
			break;
		case 5:
			CB_TheSilentService = (CheckBox)target;
			break;
		case 6:
			CB_DesertStorm = (CheckBox)target;
			break;
		case 7:
			CB_KashmirFire = (CheckBox)target;
			break;
		case 8:
			CB_RedTide = (CheckBox)target;
			break;
		case 9:
			CB_Falklands = (CheckBox)target;
			break;
		case 10:
			CB_CLIVE1 = (CheckBox)target;
			break;
		case 11:
			CB_CLIVE2 = (CheckBox)target;
			break;
		case 12:
			CB_CLIVE3 = (CheckBox)target;
			break;
		case 13:
			CB_CLIVE4 = (CheckBox)target;
			break;
		case 14:
			CB_CLIVE5 = (CheckBox)target;
			break;
		case 15:
			CB_CLIVE6 = (CheckBox)target;
			break;
		case 16:
			CB_CLIVE7 = (CheckBox)target;
			break;
		case 17:
			CB_CLIVE8 = (CheckBox)target;
			break;
		case 18:
			CB_CLIVE9 = (CheckBox)target;
			break;
		case 19:
			CB_CLIVE10 = (CheckBox)target;
			break;
		case 20:
			CB_CLIVE11 = (CheckBox)target;
			break;
		case 21:
			CB_CLIVE12 = (CheckBox)target;
			break;
		case 22:
			CB_CLIVE13 = (CheckBox)target;
			break;
		case 23:
			CB_CSHOW1 = (CheckBox)target;
			break;
		case 24:
			CB_CSHOW2 = (CheckBox)target;
			break;
		case 25:
			CB_CSHOW3 = (CheckBox)target;
			break;
		case 26:
			CB_CSHOW4 = (CheckBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
