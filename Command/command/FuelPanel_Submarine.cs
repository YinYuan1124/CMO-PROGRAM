using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Submarine : DarkUserControl
{
	private IContainer refTests;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel errorTests;

	[AccessedThroughProperty("Label_AIP")]
	[CompilerGenerated]
	private DarkLabel m_CodeTests;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_Battery")]
	private DarkUIProgressBar m_ProccesorTests;

	private int ActualWidth;

	private FuelRec._FuelType _ConfigurationTests;

	private FuelRec._FuelType _TokenTests;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return errorTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorTests = value;
		}
	}

	internal DarkLabel Label_AIP
	{
		[CompilerGenerated]
		get
		{
			return m_CodeTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeTests = value;
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_Endurance")]
	internal DarkLabel Label_Endurance
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PB_Diesel")]
	internal DarkUIProgressBar PB_Diesel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIProgressBar PB_Battery
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProccesorTests = value;
		}
	}

	[field: AccessedThroughProperty("PB_AIP")]
	internal DarkUIProgressBar PB_AIP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FuelPanel_Submarine()
	{
		base.Load += ForgotProduct;
		FlushProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && refTests != null)
			{
				refTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FlushProduct()
	{
		Label_Endurance = new DarkLabel();
		Label_AIP = new DarkLabel();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		PB_Diesel = new DarkUIProgressBar();
		PB_Battery = new DarkUIProgressBar();
		PB_AIP = new DarkUIProgressBar();
		SuspendLayout();
		Label_Endurance.AutoSize = true;
		Label_Endurance.BackColor = Color.Transparent;
		Label_Endurance.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label_Endurance.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Endurance.Location = new Point(3, 61);
		Label_Endurance.Name = "Label_Endurance";
		Label_Endurance.Size = new Size(62, 13);
		Label_Endurance.TabIndex = 8;
		Label_Endurance.Text = "Endurance:";
		Label_AIP.AutoSize = true;
		Label_AIP.BackColor = Color.Transparent;
		Label_AIP.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label_AIP.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AIP.Location = new Point(3, 42);
		Label_AIP.Name = "Label_AIP";
		Label_AIP.Size = new Size(27, 13);
		Label_AIP.TabIndex = 6;
		Label_AIP.Text = "AIP:";
		Label2.AutoSize = true;
		Label2.BackColor = Color.Transparent;
		Label2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(3, 23);
		Label2.Name = "Label2";
		Label2.Size = new Size(43, 13);
		Label2.TabIndex = 4;
		Label2.Text = "Battery:";
		Label1.AutoSize = true;
		Label1.BackColor = Color.Transparent;
		Label1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 2);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 2;
		Label1.Text = "Diesel:";
		PB_Diesel.BackColor = Color.Transparent;
		PB_Diesel.Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		PB_Diesel.Location = new Point(51, 0);
		PB_Diesel.Maximum = 100;
		PB_Diesel.Name = "PB_Diesel";
		PB_Diesel.ShowProgressLines = true;
		PB_Diesel.ShowProgressValue = true;
		PB_Diesel.Size = new Size(180, 18);
		PB_Diesel.TabIndex = 9;
		PB_Diesel.Value = 0;
		PB_Battery.BackColor = Color.Transparent;
		PB_Battery.Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		PB_Battery.Location = new Point(51, 20);
		PB_Battery.Maximum = 100;
		PB_Battery.Name = "PB_Battery";
		PB_Battery.ShowProgressLines = true;
		PB_Battery.ShowProgressValue = true;
		PB_Battery.Size = new Size(180, 18);
		PB_Battery.TabIndex = 10;
		PB_Battery.Value = 0;
		PB_AIP.BackColor = Color.Transparent;
		PB_AIP.Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		PB_AIP.Location = new Point(51, 40);
		PB_AIP.Maximum = 100;
		PB_AIP.Name = "PB_AIP";
		PB_AIP.ShowProgressLines = true;
		PB_AIP.ShowProgressValue = true;
		PB_AIP.Size = new Size(180, 18);
		PB_AIP.TabIndex = 11;
		PB_AIP.Value = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(PB_AIP);
		base.Controls.Add(PB_Battery);
		base.Controls.Add(PB_Diesel);
		base.Controls.Add(Label_Endurance);
		base.Controls.Add(Label1);
		base.Controls.Add(Label_AIP);
		base.Controls.Add(Label2);
		base.Margin = new Padding(0);
		base.Name = "FuelPanel_Submarine";
		base.Size = new Size(232, 102);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void RefreshPanel(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.Fuel_ReadOnly.Count == 0)
		{
			return;
		}
		if (Client._StateClass != 1f)
		{
			if (ActualWidth == 0)
			{
				ActualWidth = base.Width;
			}
			if (ActualWidth == base.Width)
			{
				base.Width = (int)Math.Round((float)base.Width * Client._StateClass);
			}
		}
		FuelRec fuelRec = activeUnit_0.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
		if (!Information.IsNothing(fuelRec))
		{
			PB_Diesel.Value = (int)Math.Round(fuelRec.PercentFull * 100f);
			PB_Diesel.Text = string.Format("{0:0.0}", fuelRec.CurrentQuantity, 0) + "燃料单元剩余";
		}
		FuelRec fuelRec2 = activeUnit_0.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
		if (!Information.IsNothing(fuelRec2))
		{
			PB_Battery.Value = (int)Math.Round(fuelRec2.PercentFull * 100f);
			PB_Battery.Text = string.Format("{0:0.0}", fuelRec2.CurrentQuantity, 0) + "燃料单元剩余";
		}
		Submarine submarine = (Submarine)activeUnit_0;
		if (submarine.IsAIP)
		{
			Label_AIP.Visible = true;
			PB_AIP.Visible = true;
			FuelRec fuelRec3 = activeUnit_0.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
			PB_AIP.Value = (int)Math.Round(fuelRec3.PercentFull * 100f);
			PB_AIP.Text = string.Format("{0:0.0}", fuelRec3.CurrentQuantity, 0) + "燃料单元剩余";
		}
		else
		{
			Label_AIP.Visible = false;
			PB_AIP.Visible = false;
		}
		_TokenTests = submarine.AI.SelectFuelTypeToConsume(submarine.PrimaryEngine);
		if (_TokenTests != _ConfigurationTests)
		{
			Label1.Font = new Font(Label1.Font, FontStyle.Regular);
			Label2.Font = new Font(Label2.Font, FontStyle.Regular);
			Label_AIP.Font = new Font(Label_AIP.Font, FontStyle.Regular);
			switch (_TokenTests)
			{
			case FuelRec._FuelType.AirIndepedent:
				Label_AIP.Font = new Font(Label_AIP.Font, FontStyle.Bold);
				break;
			case FuelRec._FuelType.Battery:
				Label2.Font = new Font(Label2.Font, FontStyle.Bold);
				break;
			case FuelRec._FuelType.DieselFuel:
				Label1.Font = new Font(Label1.Font, FontStyle.Bold);
				break;
			}
			_ConfigurationTests = _TokenTests;
		}
		long fuelEndurance = submarine.GetFuelEndurance(activeUnit_0.ThrottleSetting, null, (int)Math.Round(activeUnit_0.DesiredSpeed), activeUnit_0.GetCurrentAltitude(), submarine.PrimaryEngine, submarine.PrimaryEngineNo);
		string text = ((activeUnit_0.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "单元完全停止" : (Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)fuelEndurance * activeUnit_0.CurrentSpeed / 3600f, 0) + "海里"));
		Label_Endurance.Text = "续航：" + text;
	}

	private void ForgotProduct(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
