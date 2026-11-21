using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
public sealed class Form_SetFuelAndAirborneTime : DarkSecondaryFormBase
{
	private IContainer bridgeTests;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_InvocationTests;

	[AccessedThroughProperty("TB_RemainingFuel")]
	[CompilerGenerated]
	private TextBox m_ClassTests;

	[AccessedThroughProperty("TB_AirborneTime")]
	[CompilerGenerated]
	private MaskedTextBox m_RequestTests;

	[AccessedThroughProperty("TB_AltitudeDepth")]
	[CompilerGenerated]
	private TextBox m_ValueTests;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel tokenizerTests;

	[AccessedThroughProperty("CheckBox1")]
	[CompilerGenerated]
	private DarkCheckBox _StubTests;

	[AccessedThroughProperty("FuelTypeCombo")]
	[CompilerGenerated]
	private DarkUIComboBox writerTests;

	private bool m_WatcherTests;

	private ActiveUnit m_ReponseTests;

	private decimal m_DescriptorTests;

	private FuelRec _PoolTests;

	private List<FuelRec> m_TaskTests;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationTests = value;
		}
	}

	internal TextBox TB_RemainingFuel
	{
		[CompilerGenerated]
		get
		{
			return m_ClassTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableProduct;
			EventHandler value3 = ConcatProduct;
			KeyEventHandler value4 = InterruptProduct;
			TextBox classTests = m_ClassTests;
			if (classTests != null)
			{
				classTests.Enter -= value2;
				classTests.Validated -= value3;
				classTests.KeyDown -= value4;
			}
			m_ClassTests = value;
			classTests = m_ClassTests;
			if (classTests != null)
			{
				classTests.Enter += value2;
				classTests.Validated += value3;
				classTests.KeyDown += value4;
			}
		}
	}

	internal MaskedTextBox TB_AirborneTime
	{
		[CompilerGenerated]
		get
		{
			return m_RequestTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveProduct;
			KeyEventHandler value3 = FindProduct;
			MaskedTextBox requestTests = m_RequestTests;
			if (requestTests != null)
			{
				requestTests.Validated -= value2;
				requestTests.KeyDown -= value3;
			}
			m_RequestTests = value;
			requestTests = m_RequestTests;
			if (requestTests != null)
			{
				requestTests.Validated += value2;
				requestTests.KeyDown += value3;
			}
		}
	}

	internal TextBox TB_AltitudeDepth
	{
		[CompilerGenerated]
		get
		{
			return m_ValueTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetProduct;
			TextBox valueTests = m_ValueTests;
			if (valueTests != null)
			{
				valueTests.Validated -= value2;
			}
			m_ValueTests = value;
			valueTests = m_ValueTests;
			if (valueTests != null)
			{
				valueTests.Validated += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return tokenizerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerTests = value;
		}
	}

	internal DarkCheckBox CheckBox1
	{
		[CompilerGenerated]
		get
		{
			return _StubTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteProduct;
			DarkCheckBox stubTests = _StubTests;
			if (stubTests != null)
			{
				stubTests.CheckedChanged -= value2;
			}
			_StubTests = value;
			stubTests = _StubTests;
			if (stubTests != null)
			{
				stubTests.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIComboBox FuelTypeCombo
	{
		[CompilerGenerated]
		get
		{
			return writerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckProduct;
			DarkUIComboBox darkUIComboBox = writerTests;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			writerTests = value;
			darkUIComboBox = writerTests;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_AltitudeDepthLabel")]
	internal DarkLabel TB_AltitudeDepthLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_SetFuelAndAirborneTime()
	{
		base.Load += SetupProduct;
		base.KeyDown += SearchProduct;
		base.FormClosing += ChangeProduct;
		m_TaskTests = new List<FuelRec>();
		GetProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && bridgeTests != null)
			{
				bridgeTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GetProduct()
	{
		Label1 = new DarkLabel();
		TB_RemainingFuel = new TextBox();
		TB_AirborneTime = new MaskedTextBox();
		TB_AltitudeDepth = new TextBox();
		Label2 = new DarkLabel();
		CheckBox1 = new DarkCheckBox();
		FuelTypeCombo = new DarkUIComboBox();
		TB_AltitudeDepthLabel = new DarkLabel();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(17, 51);
		Label1.Name = "Label1";
		Label1.Size = new Size(157, 20);
		Label1.TabIndex = 0;
		Label1.Text = "剩余燃料（单元）：";
		TB_RemainingFuel.BackColor = Color.Black;
		TB_RemainingFuel.ForeColor = Color.LightGray;
		TB_RemainingFuel.Location = new Point(180, 51);
		TB_RemainingFuel.Name = "TB_RemainingFuel";
		TB_RemainingFuel.Size = new Size(112, 27);
		TB_RemainingFuel.TabIndex = 1;
		TB_AirborneTime.BackColor = Color.Black;
		TB_AirborneTime.ForeColor = Color.LightGray;
		TB_AirborneTime.Location = new Point(215, 7);
		TB_AirborneTime.Mask = "00:00:00";
		TB_AirborneTime.Name = "TB_AirborneTime";
		TB_AirborneTime.Size = new Size(77, 27);
		TB_AirborneTime.TabIndex = 2;
		TB_AltitudeDepth.BackColor = Color.Black;
		TB_AltitudeDepth.ForeColor = Color.LightGray;
		TB_AltitudeDepth.Location = new Point(215, 84);
		TB_AltitudeDepth.Name = "TB_AltitudeDepth";
		TB_AltitudeDepth.Size = new Size(77, 27);
		TB_AltitudeDepth.TabIndex = 2;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(10, 14);
		Label2.Name = "Label2";
		Label2.Size = new Size(199, 20);
		Label2.TabIndex = 3;
		Label2.Text = "滞空时间（小时：分：秒）：";
		CheckBox1.Location = new Point(316, 7);
		CheckBox1.Name = "CheckBox1";
		CheckBox1.Size = new Size(210, 37);
		CheckBox1.TabIndex = 4;
		CheckBox1.Text = "自动调节燃油（最佳海拔高度+ 10％）";
		FuelTypeCombo.BackColor = Color.Transparent;
		FuelTypeCombo.DrawMode = DrawMode.OwnerDrawFixed;
		FuelTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
		FuelTypeCombo.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		FuelTypeCombo.FormattingEnabled = true;
		FuelTypeCombo.Location = new Point(316, 54);
		FuelTypeCombo.Name = "FuelTypeCombo";
		FuelTypeCombo.Size = new Size(134, 24);
		FuelTypeCombo.TabIndex = 5;
		FuelTypeCombo.Visible = false;
		TB_AltitudeDepthLabel.AutoSize = true;
		TB_AltitudeDepthLabel.ForeColor = Color.FromArgb(220, 220, 220);
		TB_AltitudeDepthLabel.Location = new Point(17, 82);
		TB_AltitudeDepthLabel.Name = "TB_AltitudeDepthLabel";
		TB_AltitudeDepthLabel.Size = new Size(65, 20);
		TB_AltitudeDepthLabel.TabIndex = 3;
		TB_AltitudeDepthLabel.Text = "Altitude:";
		base.AutoScaleMode = AutoScaleMode.None;
		AutoSize = true;
		base.ClientSize = new Size(581, 172);
		base.Controls.Add(FuelTypeCombo);
		base.Controls.Add(CheckBox1);
		base.Controls.Add(Label2);
		base.Controls.Add(TB_AirborneTime);
		base.Controls.Add(TB_RemainingFuel);
		base.Controls.Add(Label1);
		base.Controls.Add(TB_AltitudeDepth);
		base.Controls.Add(TB_AltitudeDepthLabel);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_SetFuelAndAirborneTime";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "设置单元属性：";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void WriteProduct(object sender, EventArgs e)
	{
		if (!Information.IsNothing(m_ReponseTests) && m_ReponseTests.IsAircraft && CheckBox1.Checked)
		{
			NewProduct();
		}
	}

	private void NewProduct()
	{
		float num = m_ReponseTests.FuelConsumption(ActiveUnit.Throttle.Cruise, m_ReponseTests.Propulsion[0].GetOptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise), null, null, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
		float airborneTime = ((Aircraft)m_ReponseTests).AirborneTime;
		float num2 = (float)((double)num * 1.1 * (double)airborneTime);
		Aircraft aircraft = (Aircraft)m_ReponseTests;
		float num3 = (float)aircraft.FuelCapacityMax - num2;
		if (num3 <= 0f)
		{
			DarkMessageBox.ShowWarning("燃油量为零或负值。跳过自动计算燃油量。", "");
			return;
		}
		aircraft.FuelCapacitySet(num3);
		m_WatcherTests = false;
		TB_RemainingFuel.Text = Conversions.ToString(num3);
		m_WatcherTests = true;
	}

	private void PushProduct(object sender, EventArgs e)
	{
		if (!Information.IsNothing(m_ReponseTests) && m_WatcherTests && Versioned.IsNumeric(TB_RemainingFuel.Text))
		{
			float float_ = Conversions.ToSingle(TB_RemainingFuel.Text);
			InitProduct(float_);
		}
	}

	private void InvokeProduct()
	{
		m_TaskTests.Clear();
		if (m_ReponseTests == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		IEnumerator enumerator = null;
		try
		{
			enumerator = Enum.GetValues(typeof(FuelRec._FuelType)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				FuelRec._FuelType fuelType = (FuelRec._FuelType)Conversions.ToShort(objectValue);
				num = 0;
				num2 = 0;
				foreach (FuelRec item in m_ReponseTests.Fuel_ReadOnly)
				{
					if ((int)item.FuelType == Conversions.ToShort(objectValue))
					{
						num = item.MaxQuantity;
						num2 = (int)Math.Round(item.CurrentQuantity);
					}
				}
				if (num > 0 || (m_ReponseTests.IsFixedFacility && fuelType >= FuelRec._FuelType.AviationFuel && fuelType <= FuelRec._FuelType.Gasoline))
				{
					FuelRec fuelRec = new FuelRec(num, Conversions.ToShort(objectValue));
					fuelRec.CurrentQuantity = num2;
					m_TaskTests.Add(fuelRec);
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
	}

	private void SetupProduct(object sender, EventArgs e)
	{
		DataTable dataTable_ = new DataTable();
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		m_WatcherTests = false;
		if (Client.SelectedUnit == null || Client.SelectedUnit.IsGroup)
		{
			return;
		}
		Text = Text + " " + Client.SelectedUnit.Name;
		TB_RemainingFuel.Enabled = true;
		if (Information.IsNothing(Client.SelectedUnit))
		{
			return;
		}
		m_ReponseTests = (ActiveUnit)Client.SelectedUnit;
		InvokeProduct();
		if (Client.SelectedUnit.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)m_ReponseTests;
			Label2.Text = "滞空时间（小时：分：秒）：";
			TB_AirborneTime.Mask = "00:00:00";
			TB_AirborneTime.Text = IncludeProduct((int)Math.Round(aircraft.AirborneTime));
			TB_AltitudeDepthLabel.Text = "Current Altitude " + (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? "(FT):" : "(M):");
			TB_AltitudeDepth.Text = Conversions.ToString(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (3.28084f * Client.SelectedUnit.GetCurrentAltitude()) : Client.SelectedUnit.GetCurrentAltitude());
		}
		else if (Client.SelectedUnit.IsBoat)
		{
			Label2.Text = "Time at sea (days: hr : min : sec):";
			TB_AirborneTime.Mask = "00:00:00:00";
			TB_AirborneTime.Text = ExcludeProduct((int)Math.Round(m_ReponseTests.TimeUnderway));
			if (Client.SelectedUnit.IsSubmarine)
			{
				TB_AltitudeDepthLabel.Text = "Current Depth " + (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? "(FT):" : "(M):");
				TB_AltitudeDepth.Text = Conversions.ToString(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (3.28084f * Client.SelectedUnit.GetCurrentAltitude()) : Client.SelectedUnit.GetCurrentAltitude());
			}
			else
			{
				TB_AltitudeDepthLabel.Enabled = false;
				TB_AltitudeDepthLabel.Visible = false;
				TB_AltitudeDepth.Enabled = false;
				TB_AltitudeDepth.Visible = false;
			}
		}
		else
		{
			TB_AirborneTime.Enabled = false;
			TB_AirborneTime.Visible = false;
			Label2.Enabled = false;
			Label2.Visible = false;
			TB_AltitudeDepthLabel.Enabled = false;
			TB_AltitudeDepthLabel.Visible = false;
			TB_AltitudeDepth.Enabled = false;
			TB_AltitudeDepth.Visible = false;
		}
		if (Client.SelectedUnit.IsActiveUnit)
		{
			if (Client.SelectedUnit.IsAircraft)
			{
				Aircraft aircraft2 = (Aircraft)m_ReponseTests;
				TB_RemainingFuel.Text = Conversions.ToString(aircraft2.FuelCapacityCurrent);
			}
			else if (m_TaskTests.Count == 0)
			{
				TB_RemainingFuel.Enabled = false;
			}
			else
			{
				CheckBox1.Enabled = false;
				CheckBox1.Visible = false;
				FuelTypeCombo.Visible = true;
				DarkUIComboBox darkUIComboBox_ = FuelTypeCombo;
				BindCombobox_FuelType(ref darkUIComboBox_, ref dataTable_, 0);
				FuelTypeCombo = darkUIComboBox_;
				if (m_ReponseTests.IsAircraft)
				{
					_PoolTests = m_ReponseTests.Fuel_ReadOnly[0];
					TB_RemainingFuel.Text = Conversions.ToString(new decimal(m_ReponseTests.Fuel_ReadOnly[0].CurrentQuantity));
					if (m_ReponseTests.Fuel_ReadOnly.Count == 1)
					{
						FuelTypeCombo.Enabled = false;
					}
				}
				else
				{
					_PoolTests = m_TaskTests[0];
					TB_RemainingFuel.Text = Conversions.ToString(new decimal(m_TaskTests[0].CurrentQuantity));
					if (m_TaskTests.Count == 1)
					{
						FuelTypeCombo.Enabled = false;
					}
				}
				m_DescriptorTests = Conversions.ToDecimal(TB_RemainingFuel.Text);
			}
		}
		m_WatcherTests = true;
	}

	private string ExcludeProduct(int int_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(int_0);
		if (timeSpan.Days <= 0)
		{
			if (timeSpan.Hours <= 0)
			{
				if (timeSpan.Minutes <= 0)
				{
					if (timeSpan.Seconds <= 0)
					{
						return "00:00:00:00";
					}
					return "00:00:00:" + Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds);
				}
				return "00:00:" + Interaction.IIf(timeSpan.Minutes < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Minutes) + ":" + Interaction.IIf(timeSpan.Seconds == 0, "00", Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds)).ToString();
			}
			return "00:" + Interaction.IIf(timeSpan.Hours < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, "00", Interaction.IIf(timeSpan.Minutes < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Minutes)).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, "00", Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds)).ToString();
		}
		return Interaction.IIf(timeSpan.Days < 10, "0", "").ToString() + timeSpan.Days + ":" + Interaction.IIf(timeSpan.Hours < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, "00", Interaction.IIf(timeSpan.Minutes < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Minutes)).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, "00", Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds)).ToString();
	}

	private string IncludeProduct(int int_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(int_0);
		if (timeSpan.Hours <= 0)
		{
			if (timeSpan.Minutes <= 0)
			{
				if (timeSpan.Seconds <= 0)
				{
					return "00:00:00";
				}
				return "00:00:" + Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds);
			}
			return "00:" + Interaction.IIf(timeSpan.Minutes < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Minutes) + ":" + Interaction.IIf(timeSpan.Seconds == 0, "00", Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds)).ToString();
		}
		return Interaction.IIf(timeSpan.Hours < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, "00", Interaction.IIf(timeSpan.Minutes < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Minutes)).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, "00", Interaction.IIf(timeSpan.Seconds < 10, "0", "").ToString() + Conversions.ToString(timeSpan.Seconds)).ToString();
	}

	private void SearchProduct(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if ((e.KeyCode != Keys.Return || !base.Visible) && (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void EnableProduct(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(TB_RemainingFuel.Text))
		{
			m_DescriptorTests = Conversions.ToDecimal(TB_RemainingFuel.Text);
		}
	}

	private void ChangeProduct(object sender, FormClosingEventArgs e)
	{
		if (m_ReponseTests != null && !m_ReponseTests.IsAircraft)
		{
			FuelRec fuelRec = null;
			foreach (FuelRec taskTest in m_TaskTests)
			{
				fuelRec = null;
				foreach (FuelRec item in m_ReponseTests.Fuel_ReadOnly)
				{
					if (item.FuelType == taskTest.FuelType)
					{
						fuelRec = item;
						break;
					}
				}
				if (fuelRec == null)
				{
					if (taskTest.CurrentQuantity > 0f)
					{
						m_ReponseTests.AddFuelRec(taskTest);
					}
				}
				else
				{
					fuelRec.MaxQuantity = taskTest.MaxQuantity;
					fuelRec.CurrentQuantity = taskTest.CurrentQuantity;
				}
			}
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Client.MustRefreshMainForm = true;
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		}
	}

	public void BindCombobox_FuelType(ref DarkUIComboBox darkUIComboBox_0, ref DataTable dataTable_0, short short_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		int num = 0;
		foreach (FuelRec taskTest in m_TaskTests)
		{
			dataTable_0.Rows.Add(num, taskTest.FuelType.ToString());
			if (num == short_0)
			{
				_PoolTests = taskTest;
			}
			num++;
		}
		DarkUIComboBox obj = darkUIComboBox_0;
		obj.DataSource = dataTable_0;
		obj.DisplayMember = "Description";
		obj.ValueMember = "ID";
		obj.SelectedIndex = short_0;
	}

	private void InitProduct(float float_0)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		if (float_0 <= 0f && (m_ReponseTests.IsAircraft || float_0 != 0f))
		{
			TB_RemainingFuel.Text = Conversions.ToString(m_DescriptorTests);
			if (m_ReponseTests.IsAircraft)
			{
				DarkMessageBox.ShowError("燃料量不能为0或负数.", "");
			}
			else
			{
				DarkMessageBox.ShowError("Fuel quantity cannot be negative.", "");
			}
			return;
		}
		if (m_ReponseTests.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)m_ReponseTests;
			aircraft.FuelCapacitySet(Conversions.ToSingle(TB_RemainingFuel.Text));
			TB_RemainingFuel.Text = Conversions.ToString(aircraft.FuelCapacityCurrent);
			return;
		}
		if (float_0 > (float)_PoolTests.MaxQuantity)
		{
			if (m_ReponseTests.IsFixedFacility)
			{
				_PoolTests.MaxQuantity = (int)Math.Ceiling(float_0);
			}
			else
			{
				float_0 = _PoolTests.MaxQuantity;
				TB_RemainingFuel.Text = Conversions.ToString(new decimal(float_0));
			}
		}
		_PoolTests.CurrentQuantity = float_0;
	}

	private void CheckProduct(object sender, EventArgs e)
	{
		if (m_ReponseTests.IsAircraft)
		{
			_PoolTests = m_ReponseTests.Fuel_ReadOnly[FuelTypeCombo.SelectedIndex];
		}
		else
		{
			_PoolTests = m_TaskTests[FuelTypeCombo.SelectedIndex];
		}
		TB_RemainingFuel.Text = Conversions.ToString(new decimal(_PoolTests.CurrentQuantity));
		m_DescriptorTests = Conversions.ToDecimal(TB_RemainingFuel.Text);
	}

	private void ConcatProduct(object sender, EventArgs e)
	{
		if (!Information.IsNothing(m_ReponseTests) && m_WatcherTests && Versioned.IsNumeric(TB_RemainingFuel.Text))
		{
			float float_ = Conversions.ToSingle(TB_RemainingFuel.Text);
			InitProduct(float_);
		}
	}

	private void InterruptProduct(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			ConcatProduct(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RemoveProduct(object sender, EventArgs e)
	{
		List<string> list = TB_AirborneTime.Text.Replace(".", ":").Split(':').ToList();
		if (list.Count == 3)
		{
			if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
			{
				return;
			}
		}
		else if (list.Count != 4 || !(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2]) & Versioned.IsNumeric(list[3])))
		{
			return;
		}
		TimeSpan timeSpan = default(TimeSpan);
		if (list.Count == 3)
		{
			timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		}
		if (list.Count == 4)
		{
			timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]), Conversions.ToInteger(list[3]));
		}
		if (m_ReponseTests.IsAircraft)
		{
			((Aircraft)m_ReponseTests).AirborneTime = (float)timeSpan.TotalSeconds;
		}
		else if (m_ReponseTests.IsBoat)
		{
			m_ReponseTests.TimeUnderway = (float)timeSpan.TotalSeconds;
		}
		if (CheckBox1.Checked)
		{
			NewProduct();
		}
	}

	private void FindProduct(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			RemoveProduct(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void SetProduct(object sender, EventArgs e)
	{
		if (m_ReponseTests.IsAircraft)
		{
			if (Conversions.ToSingle(TB_AltitudeDepth.Text) >= 0f)
			{
				m_ReponseTests.SetCurrentAltitude(bool_0: false, SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (Conversions.ToSingle(TB_AltitudeDepth.Text) / 3.28084f) : Conversions.ToSingle(TB_AltitudeDepth.Text));
				m_ReponseTests.DesiredAltitude = m_ReponseTests.GetCurrentAltitude();
			}
		}
		else if (m_ReponseTests.IsSubmarine && Conversions.ToSingle(TB_AltitudeDepth.Text) <= 0f)
		{
			m_ReponseTests.SetCurrentAltitude(bool_0: false, SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (Conversions.ToSingle(TB_AltitudeDepth.Text) / 3.28084f) : Conversions.ToSingle(TB_AltitudeDepth.Text));
			m_ReponseTests.DesiredAltitude = m_ReponseTests.GetCurrentAltitude();
		}
	}
}
