using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.Listeners;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RecentDetections_WPF : UserControl, IComponentConnector
{
	[CompilerGenerated]
	private sealed class ServiceExpressionDic
	{
		public (string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode DetectionMode, DateTime theTime) Local_theDetectionRecord;

		internal bool NewInterruptibleMethod(Sensor theS)
		{
			return Operators.CompareString(theS.ObjectID, Local_theDetectionRecord.DetectingSensorID, TextCompare: true) == 0;
		}
	}

	private ObservableCollection<RecentDetectionViewModel> m_InstanceUtils;

	private bool objectUtils;

	private bool _contentLoaded;

	public RecentDetections_WPF()
	{
		m_InstanceUtils = new ObservableCollection<RecentDetectionViewModel>();
		InitializeComponent();
		base.DataContext = new AllRecentDetectionsViewModel
		{
			Items = m_InstanceUtils
		};
	}

	public void RefreshPanel(Contact contact_0, Scenario scenario_0)
	{
		try
		{
			if (contact_0 == null)
			{
				m_InstanceUtils.Clear();
				base.Visibility = Visibility.Collapsed;
				return;
			}
			if (contact_0.LastDetections.Count == 0)
			{
				if (m_InstanceUtils.Count > 0)
				{
					m_InstanceUtils.Clear();
				}
				return;
			}
			List<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)> source = new List<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime)>(contact_0.LastDetections);
			source = source.OrderByDescending<(string, string, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime), DateTime>(((string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode DetectionMode, DateTime theTime) theRec) => theRec.theTime).ToList();
			int num = Math.Min(20, source.Count);
			while (m_InstanceUtils.Count < num)
			{
				m_InstanceUtils.Add(new RecentDetectionViewModel());
			}
			while (m_InstanceUtils.Count > num)
			{
				m_InstanceUtils.Remove(m_InstanceUtils.Last());
			}
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				(string DetectorUnitID, string DetectingSensorID, float RangeEstimate, ActiveUnit_Sensory.SpecialDetectionMode DetectionMode, DateTime theTime) Local_theDetectionRecord = source[i];
				ActiveUnit activeUnit = null;
				Sensor sensor = null;
				if (!string.IsNullOrEmpty(Local_theDetectionRecord.DetectorUnitID) && Client.CurrentScenario.ActiveUnits.ContainsKey(Local_theDetectionRecord.DetectorUnitID))
				{
					activeUnit = Client.CurrentScenario.ActiveUnits[Local_theDetectionRecord.DetectorUnitID];
					sensor = (from theS in activeUnit.Sensors_ReadOnly()
						where Operators.CompareString(theS.ObjectID, Local_theDetectionRecord.DetectingSensorID, TextCompare: true) == 0
						select theS).FirstOrDefault();
				}
				bool? flag = activeUnit?.CommStuff.IsConnectedToSideNetwork;
				bool? flag2 = (!flag) ?? flag;
				if (flag2.GetValueOrDefault(true))
				{
					flag = ((activeUnit == null) ? null : new bool?(InterpreterObjectListener.CollectInterruptibleTask(activeUnit)));
					if (((!flag) ?? flag).GetValueOrDefault() && flag2.HasValue)
					{
						continue;
					}
				}
				float item = Local_theDetectionRecord.RangeEstimate;
				ActiveUnit_Sensory.SpecialDetectionMode item2 = Local_theDetectionRecord.DetectionMode;
				DateTime item3 = Local_theDetectionRecord.theTime;
				RecentDetectionViewModel recentDetectionViewModel = m_InstanceUtils[i];
				if (sensor == null)
				{
					recentDetectionViewModel.PlatformName = "[Unknown]";
					if (activeUnit != null)
					{
						recentDetectionViewModel.PlatformDBID = activeUnit.DBID;
						recentDetectionViewModel.PlatformName = activeUnit.Name;
						recentDetectionViewModel.PlatformGUID = activeUnit.ObjectID;
					}
					recentDetectionViewModel.SensorName = "[Unknown]";
					switch (item2)
					{
					case ActiveUnit_Sensory.SpecialDetectionMode.SubAssumedFromTorpedoDetection:
						recentDetectionViewModel.SensorName = "来自鱼雷检测的POSSUB";
						break;
					case ActiveUnit_Sensory.SpecialDetectionMode.SubAssumedFromMissileDetection:
						recentDetectionViewModel.SensorName = "POSSUB来自导弹探测";
						break;
					case ActiveUnit_Sensory.SpecialDetectionMode.FlamingDatum:
						recentDetectionViewModel.SensorName = "鱼雷爆炸的POSSUB（火焰基准）";
						break;
					case ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection:
						recentDetectionViewModel.SensorName = "自动检测";
						break;
					case ActiveUnit_Sensory.SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination:
						recentDetectionViewModel.SensorName = "潜在导弹目标来自半主动照射探测";
						break;
					case ActiveUnit_Sensory.SpecialDetectionMode.CounterBatteryTrack:
						recentDetectionViewModel.SensorName = "Probable artillery (counter-battery detection)";
						break;
					}
				}
				else
				{
					recentDetectionViewModel.Int32_0 = sensor.DBID;
					recentDetectionViewModel.SensorName = sensor.Name;
					if (activeUnit == null)
					{
						recentDetectionViewModel.CoreUnitGUID = "";
					}
					else
					{
						recentDetectionViewModel.CoreUnitGUID = activeUnit.ObjectID;
					}
					activeUnit = sensor.ParentPlatform;
					if (activeUnit.IsWeapon)
					{
						Weapon weapon = (Weapon)activeUnit;
						if (weapon.AttachedTo != null)
						{
							activeUnit = weapon.AttachedTo;
						}
					}
					if (activeUnit != null)
					{
						recentDetectionViewModel.PlatformDBID = activeUnit.DBID;
						recentDetectionViewModel.PlatformName = activeUnit.Name;
						recentDetectionViewModel.PlatformGUID = activeUnit.ObjectID;
					}
				}
				if (contact_0.UncertaintyArea == null)
				{
					recentDetectionViewModel.DetectionRange_String = $"{item:0.0}" + "nm";
				}
				else if (sensor == null)
				{
					recentDetectionViewModel.DetectionRange_String = "Unknown";
				}
				else
				{
					recentDetectionViewModel.DetectionRange_String = "估计" + $"{Module_Unit.RangeToUnit_Horiz(sensor.ParentPlatform, contact_0):0.0}" + "nm";
				}
				recentDetectionViewModel.DetectionRange_String = " - Range: " + recentDetectionViewModel.DetectionRange_String;
				recentDetectionViewModel.TimeSinceDetection = (long)Math.Round((Client.CurrentScenario.Time - item3).TotalSeconds);
				recentDetectionViewModel.TimeSinceDetection_String = Misc.UpdateRequest(recentDetectionViewModel.TimeSinceDetection, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " ago ";
				if (item2 == ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection)
				{
					recentDetectionViewModel.TimeSinceDetection_String = null;
					recentDetectionViewModel.DetectionRange_String = null;
				}
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

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/recentdetections_wpf.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}
}
