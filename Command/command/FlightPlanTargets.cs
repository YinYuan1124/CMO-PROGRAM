using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanTargets : DarkSecondaryFormBase
{
	private IContainer ruleFilter;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage m_InstanceFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage m_ObjectFilter;

	[AccessedThroughProperty("RadioButton_FlightTargets")]
	[CompilerGenerated]
	private DarkRadioButton dispatcherFilter;

	[AccessedThroughProperty("RadioButton_AircraftTargets")]
	[CompilerGenerated]
	private DarkRadioButton listenerFilter;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private Label m_ConfigFilter;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label registryFilter;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private Label definitionFilter;

	[field: AccessedThroughProperty("TabControl1")]
	internal TabControl TabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InstanceFilter = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectFilter = value;
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("RadioButton_MissionTargets")]
	internal DarkRadioButton RadioButton_MissionTargets
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkRadioButton RadioButton_FlightTargets
	{
		[CompilerGenerated]
		get
		{
			return dispatcherFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherFilter = value;
		}
	}

	internal DarkRadioButton RadioButton_AircraftTargets
	{
		[CompilerGenerated]
		get
		{
			return listenerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerFilter = value;
		}
	}

	internal Label Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigFilter = value;
		}
	}

	internal Label Label1
	{
		[CompilerGenerated]
		get
		{
			return registryFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			registryFilter = value;
		}
	}

	internal Label Label3
	{
		[CompilerGenerated]
		get
		{
			return definitionFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			definitionFilter = value;
		}
	}

	public FlightPlanTargets()
	{
		NewParser();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && ruleFilter != null)
			{
				ruleFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void NewParser()
	{
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		RadioButton_MissionTargets = new DarkRadioButton();
		RadioButton_FlightTargets = new DarkRadioButton();
		RadioButton_AircraftTargets = new DarkRadioButton();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		SuspendLayout();
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Location = new Point(75, 78);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(765, 256);
		TabControl1.TabIndex = 0;
		TabPage1.Controls.Add(Label2);
		TabPage1.Controls.Add(Label1);
		TabPage1.Location = new Point(4, 22);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(757, 230);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "使用任务目标";
		TabPage1.UseVisualStyleBackColor = true;
		TabPage2.Location = new Point(4, 22);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(757, 230);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Flight targets";
		TabPage2.UseVisualStyleBackColor = true;
		TabPage3.Location = new Point(4, 22);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(757, 230);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Aircraft targets";
		TabPage3.UseVisualStyleBackColor = true;
		RadioButton_MissionTargets.AutoSize = true;
		RadioButton_MissionTargets.Location = new Point(12, 12);
		RadioButton_MissionTargets.Name = "RadioButton_MissionTargets";
		RadioButton_MissionTargets.Size = new Size(148, 17);
		RadioButton_MissionTargets.TabIndex = 1;
		RadioButton_MissionTargets.TabStop = true;
		RadioButton_MissionTargets.Text = "Mission / package targets";
		RadioButton_FlightTargets.AutoSize = true;
		RadioButton_FlightTargets.Location = new Point(12, 35);
		RadioButton_FlightTargets.Name = "RadioButton_FlightTargets";
		RadioButton_FlightTargets.Size = new Size(85, 17);
		RadioButton_FlightTargets.TabIndex = 2;
		RadioButton_FlightTargets.TabStop = true;
		RadioButton_FlightTargets.Text = "Flight targets";
		RadioButton_AircraftTargets.AutoSize = true;
		RadioButton_AircraftTargets.Location = new Point(12, 55);
		RadioButton_AircraftTargets.Name = "RadioButton_AircraftTargets";
		RadioButton_AircraftTargets.Size = new Size(111, 17);
		RadioButton_AircraftTargets.TabIndex = 2;
		RadioButton_AircraftTargets.TabStop = true;
		RadioButton_AircraftTargets.Text = "Per-aircraft targets";
		Label1.AutoSize = true;
		Label1.Location = new Point(13, 20);
		Label1.Name = "Label1";
		Label1.Size = new Size(377, 13);
		Label1.TabIndex = 0;
		Label1.Text = "The flight will attack targets given in the Target List of the mission or package. ";
		Label2.AutoSize = true;
		Label2.Location = new Point(13, 49);
		Label2.Name = "Label2";
		Label2.Size = new Size(566, 13);
		Label2.TabIndex = 0;
		Label2.Text = "Weapon allocation will be per Weapon Release Authorization (WRA) setting for each weapon/target type combination.";
		Label3.AutoSize = true;
		Label3.Location = new Point(228, 27);
		Label3.Name = "Label3";
		Label3.Size = new Size(244, 13);
		Label3.TabIndex = 3;
		Label3.Text = "Options: Drop ordnance, bring back home, jettison";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 691);
		base.Controls.Add(Label3);
		base.Controls.Add(RadioButton_AircraftTargets);
		base.Controls.Add(RadioButton_FlightTargets);
		base.Controls.Add(RadioButton_MissionTargets);
		base.Controls.Add(TabControl1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(1024, 730);
		base.Name = "FlightPlanTargets";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "选择编队或单个飞机的目标";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
