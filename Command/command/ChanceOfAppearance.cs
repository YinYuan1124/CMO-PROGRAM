using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ChanceOfAppearance : DarkSecondaryFormBase
{
	private IContainer itemClass;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _SetterClass;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _CreatorClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ChanceOfAppearance_TrackBar")]
	private TrackBar mappingClass;

	[AccessedThroughProperty("ChanceOfAppearance_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox _MockClass;

	public string SelectedUnitID;

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _SetterClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetStrategy;
			DarkUIButton setterClass = _SetterClass;
			if (setterClass != null)
			{
				setterClass.Click -= value2;
			}
			_SetterClass = value;
			setterClass = _SetterClass;
			if (setterClass != null)
			{
				setterClass.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _CreatorClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillStrategy;
			DarkUIButton creatorClass = _CreatorClass;
			if (creatorClass != null)
			{
				creatorClass.Click -= value2;
			}
			_CreatorClass = value;
			creatorClass = _CreatorClass;
			if (creatorClass != null)
			{
				creatorClass.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar ChanceOfAppearance_TrackBar
	{
		[CompilerGenerated]
		get
		{
			return mappingClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateStrategy;
			TrackBar trackBar = mappingClass;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			mappingClass = value;
			trackBar = mappingClass;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	internal DarkUITextBox ChanceOfAppearance_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _MockClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = PopStrategy;
			DarkUITextBox mockClass = _MockClass;
			if (mockClass != null)
			{
				mockClass.TextChanged -= value2;
			}
			_MockClass = value;
			mockClass = _MockClass;
			if (mockClass != null)
			{
				mockClass.TextChanged += value2;
			}
		}
	}

	public ChanceOfAppearance()
	{
		base.Shown += FindStrategy;
		RemoveStrategy();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && itemClass != null)
			{
				itemClass.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RemoveStrategy()
	{
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		ChanceOfAppearance_TrackBar = new TrackBar();
		ChanceOfAppearance_TextBox = new DarkUITextBox();
		((ISupportInitialize)ChanceOfAppearance_TrackBar).BeginInit();
		SuspendLayout();
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.Cancel;
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(274, 89);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 5;
		Button2.Text = "取消";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(8, 89);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 4;
		Button1.Text = "确定";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(5, 6);
		Label1.Name = "Label1";
		Label1.Size = new Size(344, 15);
		Label1.TabIndex = 7;
		Label1.Text = "设置想定加载时单元将出现的概率（％）：";
		ChanceOfAppearance_TrackBar.Location = new Point(8, 38);
		ChanceOfAppearance_TrackBar.Maximum = 100;
		ChanceOfAppearance_TrackBar.Name = "ChanceOfAppearance_TrackBar";
		ChanceOfAppearance_TrackBar.Size = new Size(341, 45);
		ChanceOfAppearance_TrackBar.TabIndex = 8;
		ChanceOfAppearance_TrackBar.TickFrequency = 5;
		ChanceOfAppearance_TextBox.AutoCompleteCustomSource = null;
		ChanceOfAppearance_TextBox.AutoCompleteMode = AutoCompleteMode.None;
		ChanceOfAppearance_TextBox.AutoCompleteSource = AutoCompleteSource.None;
		ChanceOfAppearance_TextBox.BackColor = Color.Transparent;
		ChanceOfAppearance_TextBox.ForeColor = Color.FromArgb(189, 189, 189);
		ChanceOfAppearance_TextBox.Image = null;
		ChanceOfAppearance_TextBox.Lines = null;
		ChanceOfAppearance_TextBox.Location = new Point(164, 74);
		ChanceOfAppearance_TextBox.MaxLength = 2;
		ChanceOfAppearance_TextBox.Multiline = false;
		ChanceOfAppearance_TextBox.Name = "ChanceOfAppearance_TextBox";
		ChanceOfAppearance_TextBox.ReadOnly = false;
		ChanceOfAppearance_TextBox.ScrollBars = ScrollBars.None;
		ChanceOfAppearance_TextBox.SelectionStart = 0;
		ChanceOfAppearance_TextBox.Size = new Size(35, 24);
		ChanceOfAppearance_TextBox.TabIndex = 9;
		ChanceOfAppearance_TextBox.Text = "0";
		ChanceOfAppearance_TextBox.TextAlign = HorizontalAlignment.Center;
		ChanceOfAppearance_TextBox.UseSystemPasswordChar = false;
		ChanceOfAppearance_TextBox.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(358, 122);
		base.Controls.Add(ChanceOfAppearance_TextBox);
		base.Controls.Add(ChanceOfAppearance_TrackBar);
		base.Controls.Add(Label1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.FormBorderStyle = FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ChanceOfAppearance";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "出现的可能性";
		((ISupportInitialize)ChanceOfAppearance_TrackBar).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void FindStrategy(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(SelectedUnitID))
		{
			ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
			ChanceOfAppearance_TextBox.Text = Conversions.ToString(activeUnit.ChanceOfAppearance);
		}
	}

	private void SetStrategy(object sender, EventArgs e)
	{
		Close();
	}

	private void FillStrategy(object sender, EventArgs e)
	{
		try
		{
			if (int.TryParse(ChanceOfAppearance_TextBox.Text, out var result))
			{
				result = Conversions.ToInteger(ChanceOfAppearance_TextBox.Text);
				if (result == 0 && DarkMessageBox.ShowWarning("Setting the chance of appearance to 0% will cause the unit to always appear, is this what you want?", "Warning") == DialogResult.No)
				{
					return;
				}
			}
			else if (DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == DialogResult.OK)
			{
				ChanceOfAppearance_TextBox.Text = "0";
				return;
			}
			Client.CurrentScenario.ActiveUnits[SelectedUnitID].ChanceOfAppearance = result;
			Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalculateStrategy(object sender, EventArgs e)
	{
		ChanceOfAppearance_TextBox.Text = Conversions.ToString(ChanceOfAppearance_TrackBar.Value);
	}

	private void PopStrategy(object object_0)
	{
		if (int.TryParse(ChanceOfAppearance_TextBox.Text, out var result))
		{
			if (result > 100)
			{
				result = 100;
			}
			if (result < 0)
			{
				result = 0;
			}
			ChanceOfAppearance_TrackBar.Value = result;
		}
	}
}
