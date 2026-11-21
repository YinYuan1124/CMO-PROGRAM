using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanelContainer : DarkUserControl
{
	private IContainer _FilterTests;

	private int ActualWidth;

	public FuelPanelContainer()
	{
		base.Load += VerifyProduct;
		CancelProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _FilterTests != null)
			{
				_FilterTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CancelProduct()
	{
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		BackColor = SystemColors.Control;
		DoubleBuffered = true;
		ForeColor = SystemColors.ButtonShadow;
		base.Margin = new Padding(0);
		base.Name = "FuelPanelContainer";
		base.Size = new Size(232, 20);
		ResumeLayout(performLayout: false);
	}

	public void RefreshPanel(ActiveUnit activeUnit_0)
	{
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
		base.Enabled = !Information.IsNothing(activeUnit_0);
		if (Information.IsNothing(activeUnit_0))
		{
			return;
		}
		CheckForCorrectPanelType(activeUnit_0);
		if (base.Controls.Count > 0)
		{
			switch (activeUnit_0.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				((FuelPanel_Aircraft)base.Controls[0]).RefreshPanel(activeUnit_0);
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				((FuelPanel_Ship)base.Controls[0]).RefreshPanel(activeUnit_0);
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				((FuelPanel_Submarine)base.Controls[0]).RefreshPanel(activeUnit_0);
				break;
			}
		}
	}

	public void CheckForCorrectPanelType(ActiveUnit activeUnit_0)
	{
		if (base.Controls.Count == 0)
		{
			return;
		}
		switch (activeUnit_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if ((object)base.Controls[0].GetType() != typeof(FuelPanel_Aircraft))
			{
				base.Controls.Clear();
				FuelPanel_Aircraft fuelPanel_Aircraft = new FuelPanel_Aircraft();
				base.Controls.Add(fuelPanel_Aircraft);
				fuelPanel_Aircraft.Enabled = true;
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			if ((object)base.Controls[0].GetType() != typeof(FuelPanel_Ship))
			{
				base.Controls.Clear();
				FuelPanel_Ship fuelPanel_Ship = new FuelPanel_Ship();
				base.Controls.Add(fuelPanel_Ship);
				fuelPanel_Ship.Enabled = true;
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			if ((object)base.Controls[0].GetType() != typeof(FuelPanel_Submarine))
			{
				base.Controls.Clear();
				FuelPanel_Submarine fuelPanel_Submarine = new FuelPanel_Submarine();
				base.Controls.Add(fuelPanel_Submarine);
				fuelPanel_Submarine.Enabled = true;
			}
			break;
		}
	}

	public void AdjustToSelectionChange(Module_Unit.Unit unit_0, ref bool bool_0)
	{
		base.Controls.Clear();
		if (unit_0.IsActiveUnit)
		{
			base.Visible = true;
			if (unit_0.IsAircraft)
			{
				FuelPanel_Aircraft fuelPanel_Aircraft = new FuelPanel_Aircraft();
				base.Controls.Add(fuelPanel_Aircraft);
				fuelPanel_Aircraft.Enabled = true;
				bool_0 = true;
			}
			else if (unit_0.IsShip && !((Ship)unit_0).IsNuke)
			{
				FuelPanel_Ship fuelPanel_Ship = new FuelPanel_Ship();
				base.Controls.Add(fuelPanel_Ship);
				fuelPanel_Ship.Enabled = true;
				bool_0 = true;
			}
			else if (unit_0.IsSubmarine && (!((Submarine)unit_0).IsNuke || ((Submarine)unit_0).Fuel_ReadOnly.Count != 0))
			{
				FuelPanel_Submarine fuelPanel_Submarine = new FuelPanel_Submarine();
				base.Controls.Add(fuelPanel_Submarine);
				fuelPanel_Submarine.Enabled = true;
				bool_0 = true;
			}
			else
			{
				base.Visible = false;
				base.Height = 0;
				bool_0 = false;
			}
		}
		else
		{
			base.Visible = false;
			base.Height = 0;
			bool_0 = false;
		}
		if (base.Controls.Count > 0)
		{
			base.Height = base.Controls[0].Height;
		}
	}

	private void VerifyProduct(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
