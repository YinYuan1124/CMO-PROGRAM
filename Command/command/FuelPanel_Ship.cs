using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Ship : DarkUserControl
{
	private IContainer m_AdvisorTests;

	private int ActualWidth;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ProgressBar1")]
	internal DarkUIProgressBar ProgressBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FuelPanel_Ship()
	{
		base.Load += ResetProduct;
		QueryProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_AdvisorTests != null)
			{
				m_AdvisorTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void QueryProduct()
	{
		Label1 = new DarkLabel();
		ProgressBar1 = new DarkUIProgressBar();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.Location = new Point(3, 26);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 4;
		Label1.Text = "Label1";
		ProgressBar1.Location = new Point(0, 0);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(231, 23);
		ProgressBar1.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(Label1);
		base.Controls.Add(ProgressBar1);
		base.Margin = new Padding(0);
		base.Name = "FuelPanel_Ship";
		base.Size = new Size(232, 85);
		ResumeLayout(performLayout: false);
		PerformLayout();
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
		double double_ = 0.0;
		double double_2 = 0.0;
		ProgressBar1.Value = (int)Math.Round(activeUnit_0.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0);
		long fuelEndurance = ((Ship)activeUnit_0).GetFuelEndurance(activeUnit_0.ThrottleSetting, null, (int)Math.Round(activeUnit_0.DesiredSpeed), 0f);
		HashSet<string> hashSet = new HashSet<string>();
		string text = "";
		foreach (FuelRec item in activeUnit_0.Fuel_ReadOnly)
		{
			hashSet.Add(item.FuelType.ToString());
		}
		if (hashSet.Count > 0)
		{
			text = " (" + string.Join(", ", hashSet.ToArray()) + ")";
			if (hashSet.Count > 1)
			{
				text = "\r\n" + text;
			}
		}
		string text2 = string.Format("{0:0.0}", double_, 0) + "燃料单元剩余";
		if (!string.IsNullOrEmpty(text))
		{
			text2 += text;
		}
		string text3 = ((activeUnit_0.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "单元完全停止" : (Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)fuelEndurance * activeUnit_0.CurrentSpeed / 3600f, 0) + "海里"));
		Label1.Text = text2 + "\r\n" + text3;
	}

	private void ResetProduct(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
