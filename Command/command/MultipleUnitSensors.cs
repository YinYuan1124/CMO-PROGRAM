using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MultipleUnitSensors : DarkSecondaryFormBase
{
	private IContainer _RegistryPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_radar")]
	private DarkCheckBox _DefinitionPublisher;

	[AccessedThroughProperty("CB_Sonar")]
	[CompilerGenerated]
	private DarkCheckBox m_ValPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ECM")]
	private DarkCheckBox wrapperPublisher;

	public List<Module_Unit.Unit> SelectedUnits;

	private List<Sensor> issuerPublisher;

	private List<Sensor> _ClientPublisher;

	private List<Sensor> _DicPublisher;

	private IEnumerable<Module_Unit.Unit> m_ConsumerPublisher;

	private Keys[] m_FacadePublisher;

	internal DarkCheckBox CB_radar
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleTests;
			DarkCheckBox definitionPublisher = _DefinitionPublisher;
			if (definitionPublisher != null)
			{
				definitionPublisher.Click -= value2;
			}
			_DefinitionPublisher = value;
			definitionPublisher = _DefinitionPublisher;
			if (definitionPublisher != null)
			{
				definitionPublisher.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Sonar
	{
		[CompilerGenerated]
		get
		{
			return m_ValPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleTests;
			DarkCheckBox valPublisher = m_ValPublisher;
			if (valPublisher != null)
			{
				valPublisher.Click -= value2;
			}
			m_ValPublisher = value;
			valPublisher = m_ValPublisher;
			if (valPublisher != null)
			{
				valPublisher.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_ECM
	{
		[CompilerGenerated]
		get
		{
			return wrapperPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleTests;
			DarkCheckBox darkCheckBox = wrapperPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			wrapperPublisher = value;
			darkCheckBox = wrapperPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public MultipleUnitSensors()
	{
		base.Load += StopInterruptibleTests;
		base.KeyDown += PostInterruptibleTests;
		base.FormClosing += RunInterruptibleTests;
		issuerPublisher = new List<Sensor>();
		_ClientPublisher = new List<Sensor>();
		_DicPublisher = new List<Sensor>();
		m_FacadePublisher = new Keys[2]
		{
			Keys.F9,
			Keys.Escape
		};
		TestInterruptibleTests();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _RegistryPublisher != null)
			{
				_RegistryPublisher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void TestInterruptibleTests()
	{
		CB_radar = new DarkCheckBox();
		CB_Sonar = new DarkCheckBox();
		CB_ECM = new DarkCheckBox();
		Label1 = new DarkLabel();
		SuspendLayout();
		CB_radar.AutoSize = true;
		CB_radar.CheckAlign = ContentAlignment.MiddleRight;
		CB_radar.Location = new Point(8, 31);
		CB_radar.Name = "CB_radar";
		CB_radar.RightToLeft = RightToLeft.Yes;
		CB_radar.Size = new Size(61, 19);
		CB_radar.TabIndex = 4;
		CB_radar.Text = "雷达";
		CB_Sonar.AutoSize = true;
		CB_Sonar.CheckAlign = ContentAlignment.MiddleRight;
		CB_Sonar.Location = new Point(83, 31);
		CB_Sonar.Name = "CB_Sonar";
		CB_Sonar.RightToLeft = RightToLeft.Yes;
		CB_Sonar.Size = new Size(61, 19);
		CB_Sonar.TabIndex = 5;
		CB_Sonar.Text = "声呐";
		CB_ECM.AutoSize = true;
		CB_ECM.CheckAlign = ContentAlignment.MiddleRight;
		CB_ECM.Location = new Point(151, 31);
		CB_ECM.Name = "CB_ECM";
		CB_ECM.RightToLeft = RightToLeft.Yes;
		CB_ECM.Size = new Size(104, 19);
		CB_ECM.TabIndex = 6;
		CB_ECM.Text = "进攻性ECM";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(5, 5);
		Label1.Name = "Label1";
		Label1.Size = new Size(115, 23);
		Label1.TabIndex = 7;
		Label1.Text = "(勾选 = 打开)";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(251, 55);
		base.Controls.Add(Label1);
		base.Controls.Add(CB_ECM);
		base.Controls.Add(CB_radar);
		base.Controls.Add(CB_Sonar);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MultipleUnitSensors";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "多单元传感器";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] facadePublisher = m_FacadePublisher;
		if (facadePublisher.Length != 0)
		{
			if (base.ActiveControl == null)
			{
				Activate();
			}
			else
			{
				Close();
			}
			return true;
		}
		return false;
	}

	private void StopInterruptibleTests(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			if (Client.SelectedUnit.IsActiveUnit)
			{
				Text = "多个传感器：" + Client.SelectedUnit.Name;
			}
		}
		else if (Operators.CompareString(Client.SelectedWaypoint.Name, "", TextCompare: true) == 0)
		{
			Text = "传感器：Navigation Waypoint";
		}
		else
		{
			Text = "传感器：" + Client.SelectedWaypoint.Name;
		}
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			m_ConsumerPublisher = SelectedUnits.Where((Module_Unit.Unit theAU) => theAU.IsActiveUnit & (theAU.GetUnitSide() == Client.CurrentSide));
			foreach (ActiveUnit item in m_ConsumerPublisher)
			{
				Sensor[] array = item.Sensors_ReadOnly();
				Sensor[] array4 = array;
				foreach (Sensor sensor in array4)
				{
					if (sensor.Type == Sensor.Sensor_Type.Radar)
					{
						issuerPublisher.Add(sensor);
					}
				}
			}
			IEnumerable<Sensor> source = issuerPublisher.Where((Sensor theS) => theS.IsActive);
			if (source.Count() == 0)
			{
				CB_radar.Checked = false;
			}
			else if (source.Count() == issuerPublisher.Count)
			{
				CB_radar.Checked = true;
			}
			else
			{
				CB_radar.CheckState = CheckState.Indeterminate;
			}
			foreach (ActiveUnit item2 in m_ConsumerPublisher)
			{
				Sensor[] array3 = item2.Sensors_ReadOnly();
				Sensor[] array5 = array3;
				foreach (Sensor sensor2 in array5)
				{
					if (sensor2.IsSonar)
					{
						_ClientPublisher.Add(sensor2);
					}
				}
			}
			IEnumerable<Sensor> source2 = _ClientPublisher.Where((Sensor theS) => theS.IsActive);
			if (source2.Count() == 0)
			{
				CB_Sonar.Checked = false;
			}
			else if (source2.Count() == _ClientPublisher.Count)
			{
				CB_Sonar.Checked = true;
			}
			else
			{
				CB_Sonar.CheckState = CheckState.Indeterminate;
			}
			foreach (ActiveUnit item3 in m_ConsumerPublisher)
			{
				Sensor[] array2 = item3.Sensors_ReadOnly();
				Sensor[] array6 = array2;
				foreach (Sensor sensor3 in array6)
				{
					if (sensor3.IsOECM)
					{
						_DicPublisher.Add(sensor3);
					}
				}
			}
			IEnumerable<Sensor> source3 = _DicPublisher.Where((Sensor theS) => theS.IsActive);
			if (source3.Count() == 0)
			{
				CB_ECM.Checked = false;
			}
			else if (source3.Count() == _DicPublisher.Count)
			{
				CB_ECM.Checked = true;
			}
			else
			{
				CB_ECM.CheckState = CheckState.Indeterminate;
			}
		}
		else
		{
			if (Client.SelectedWaypoint.Doctrine.EMCON_Inherits)
			{
				CB_radar.CheckState = CheckState.Indeterminate;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
			{
				CB_radar.Checked = true;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				CB_radar.CheckState = CheckState.Indeterminate;
			}
			else
			{
				CB_radar.Checked = false;
			}
			if (Client.SelectedWaypoint.Doctrine.EMCON_Inherits)
			{
				CB_Sonar.CheckState = CheckState.Indeterminate;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
			{
				CB_Sonar.Checked = true;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				CB_Sonar.CheckState = CheckState.Indeterminate;
			}
			else
			{
				CB_Sonar.Checked = false;
			}
			if (Client.SelectedWaypoint.Doctrine.EMCON_Inherits)
			{
				CB_ECM.CheckState = CheckState.Indeterminate;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
			{
				CB_ECM.Checked = true;
			}
			else if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				CB_ECM.CheckState = CheckState.Indeterminate;
			}
			else
			{
				CB_ECM.Checked = false;
			}
		}
	}

	private bool CancelInterruptibleTests()
	{
		bool result = DarkMessageBox.ShowWarning("如果存在，则优先严格遵守EMCON设置？", "覆盖EMCON？", DarkDialogButton.YesNo) == DialogResult.Yes;
		try
		{
			string left = "";
			foreach (Module_Unit.Unit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsActiveUnit && ((ActiveUnit)selectedUnit).IsGroupMember())
				{
					if (Operators.CompareString(left, "", TextCompare: true) == 0)
					{
						left = ((ActiveUnit)selectedUnit).GetParentGroup().ObjectID;
					}
					else if (Operators.CompareString(left, ((ActiveUnit)selectedUnit).GetParentGroup().ObjectID, TextCompare: true) != 0)
					{
						left = "NO";
					}
				}
			}
			if ((Operators.CompareString(left, "", TextCompare: true) != 0) & (Operators.CompareString(left, "NO", TextCompare: true) != 0))
			{
				((ActiveUnit)SelectedUnits[0]).GetParentGroup().Sensory.Boolean_0 = false;
				((ActiveUnit)SelectedUnits[0]).GetParentGroup().Doctrine.EMCON_Inherits = false;
				return result;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 564654321657", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void VerifyInterruptibleTests(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			bool flag = CancelInterruptibleTests();
			bool @checked;
			if (@checked = CB_radar.Checked)
			{
				if (@checked)
				{
					foreach (Sensor item in issuerPublisher)
					{
						if (!item.ParentPlatform.Sensory.Boolean_0 || flag)
						{
							item.ParentPlatform.Sensory.Boolean_0 = false;
							if (!item.IsPureIlluminator && !item.IsActive)
							{
								item.GoActive();
							}
						}
					}
				}
			}
			else
			{
				foreach (Sensor item2 in issuerPublisher)
				{
					if (!item2.ParentPlatform.Sensory.Boolean_0 || flag)
					{
						item2.ParentPlatform.Sensory.Boolean_0 = false;
						if (!item2.IsPureIlluminator && item2.IsActive)
						{
							item2.GoPassive();
						}
					}
				}
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshRightColumn();
			return;
		}
		CB_radar.ThreeState = true;
		switch (CB_radar.CheckState)
		{
		case CheckState.Unchecked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
			break;
		case CheckState.Checked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
			break;
		case CheckState.Indeterminate:
			if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				Client.SelectedWaypoint.Doctrine.EMCON_Inherits = true;
			}
			Client.SelectedWaypoint.Doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
			break;
		}
	}

	private void ListInterruptibleTests(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			bool flag = CancelInterruptibleTests();
			bool @checked;
			if (@checked = CB_Sonar.Checked)
			{
				if (@checked)
				{
					foreach (Sensor item in _ClientPublisher)
					{
						if (!item.ParentPlatform.Sensory.Boolean_0 || flag)
						{
							item.ParentPlatform.Sensory.Boolean_0 = false;
							if (!item.IsPureIlluminator && (!item.IsActive & item.CanBeActive))
							{
								item.GoActive();
							}
						}
					}
				}
			}
			else
			{
				foreach (Sensor item2 in _ClientPublisher)
				{
					if (!item2.ParentPlatform.Sensory.Boolean_0 || flag)
					{
						item2.ParentPlatform.Sensory.Boolean_0 = false;
						if (!item2.IsPureIlluminator && item2.IsActive)
						{
							item2.GoPassive();
						}
					}
				}
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshRightColumn();
			return;
		}
		CB_Sonar.ThreeState = true;
		switch (CB_Sonar.CheckState)
		{
		case CheckState.Unchecked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
			break;
		case CheckState.Checked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
			break;
		case CheckState.Indeterminate:
			if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				Client.SelectedWaypoint.Doctrine.EMCON_Inherits = true;
			}
			Client.SelectedWaypoint.Doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
			break;
		}
	}

	private void ResolveInterruptibleTests(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			bool flag = CancelInterruptibleTests();
			bool @checked;
			if (@checked = CB_ECM.Checked)
			{
				if (@checked)
				{
					foreach (Sensor item in _DicPublisher)
					{
						if ((!item.ParentPlatform.Sensory.Boolean_0 || flag) && !item.IsActive)
						{
							item.GoActive();
						}
					}
				}
			}
			else
			{
				foreach (Sensor item2 in _DicPublisher)
				{
					if ((!item2.ParentPlatform.Sensory.Boolean_0 || flag) && item2.IsActive)
					{
						item2.GoPassive();
					}
				}
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshRightColumn();
			return;
		}
		CB_ECM.ThreeState = true;
		switch (CB_ECM.CheckState)
		{
		case CheckState.Unchecked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Passive, Client.CurrentScenario);
			break;
		case CheckState.Checked:
			Client.SelectedWaypoint.Doctrine.EMCON_Inherits = false;
			Client.SelectedWaypoint.Doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Active, Client.CurrentScenario);
			break;
		case CheckState.Indeterminate:
			if (Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && Client.SelectedWaypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				Client.SelectedWaypoint.Doctrine.EMCON_Inherits = true;
			}
			Client.SelectedWaypoint.Doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.NotConfigured, Client.CurrentScenario);
			break;
		}
	}

	private void PostInterruptibleTests(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F9 && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Space))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RunInterruptibleTests(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
