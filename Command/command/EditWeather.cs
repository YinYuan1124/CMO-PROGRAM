using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditWeather : DarkSecondaryFormBase
{
	private IContainer m_FactoryDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripLabel1")]
	private ToolStripLabel m_EventDescriptor;

	[AccessedThroughProperty("TC_WeatherLevel")]
	[CompilerGenerated]
	private DarkUITabControl workerDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage accountDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel stateDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label7")]
	private DarkLabel m_InfoDescriptor;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel m_HelperDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel mapperDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel managerDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Rainfall")]
	private TrackBar m_GetterDescriptor;

	[AccessedThroughProperty("TrackBar_FUR")]
	[CompilerGenerated]
	private TrackBar producerDescriptor;

	[AccessedThroughProperty("TrackBar_AverageTemp")]
	[CompilerGenerated]
	private TrackBar m_StructList;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel merchantList;

	[CompilerGenerated]
	[AccessedThroughProperty("Label10")]
	private DarkLabel callbackList;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_SeaState")]
	private TrackBar _DecoratorList;

	private Weather.WeatherProfile _ThreadList;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal DarkToolStrip ToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripLabel ToolStripLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_EventDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TSDD_WeatherLevel")]
	internal ToolStripDropDownButton TSDD_WeatherLevel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITabControl TC_WeatherLevel
	{
		[CompilerGenerated]
		get
		{
			return workerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			workerDescriptor = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return accountDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountDescriptor = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return stateDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stateDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_InfoDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoDescriptor = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return m_HelperDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_HelperDescriptor = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return mapperDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperDescriptor = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return managerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerDescriptor = value;
		}
	}

	internal TrackBar TrackBar_Rainfall
	{
		[CompilerGenerated]
		get
		{
			return m_GetterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateRules;
			TrackBar getterDescriptor = m_GetterDescriptor;
			if (getterDescriptor != null)
			{
				getterDescriptor.Scroll -= value2;
			}
			m_GetterDescriptor = value;
			getterDescriptor = m_GetterDescriptor;
			if (getterDescriptor != null)
			{
				getterDescriptor.Scroll += value2;
			}
		}
	}

	internal TrackBar TrackBar_FUR
	{
		[CompilerGenerated]
		get
		{
			return producerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateRules;
			TrackBar trackBar = producerDescriptor;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			producerDescriptor = value;
			trackBar = producerDescriptor;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_AverageTemp")]
	internal DarkLabel Label_AverageTemp
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TrackBar_AverageTemp
	{
		[CompilerGenerated]
		get
		{
			return m_StructList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopRules;
			TrackBar structList = m_StructList;
			if (structList != null)
			{
				structList.Scroll -= value2;
			}
			m_StructList = value;
			structList = m_StructList;
			if (structList != null)
			{
				structList.Scroll += value2;
			}
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return merchantList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			merchantList = value;
		}
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return callbackList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackList = value;
		}
	}

	internal TrackBar TrackBar_SeaState
	{
		[CompilerGenerated]
		get
		{
			return _DecoratorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareRules;
			TrackBar decoratorList = _DecoratorList;
			if (decoratorList != null)
			{
				decoratorList.Scroll -= value2;
			}
			_DecoratorList = value;
			decoratorList = _DecoratorList;
			if (decoratorList != null)
			{
				decoratorList.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal DarkLabel Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public EditWeather()
	{
		base.Load += CalculateRules;
		base.KeyDown += ReadRules;
		base.FormClosing += DisableRules;
		FillRules();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_FactoryDescriptor != null)
			{
				m_FactoryDescriptor.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FillRules()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(EditWeather));
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSDD_WeatherLevel = new ToolStripDropDownButton();
		TC_WeatherLevel = new DarkUITabControl();
		TabPage1 = new TabPage();
		Label9 = new DarkLabel();
		Label10 = new DarkLabel();
		TrackBar_SeaState = new TrackBar();
		Label8 = new DarkLabel();
		Label_AverageTemp = new DarkLabel();
		TrackBar_AverageTemp = new TrackBar();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		TrackBar_Rainfall = new TrackBar();
		TrackBar_FUR = new TrackBar();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		ToolStrip1.SuspendLayout();
		TC_WeatherLevel.SuspendLayout();
		TabPage1.SuspendLayout();
		((ISupportInitialize)TrackBar_SeaState).BeginInit();
		((ISupportInitialize)TrackBar_AverageTemp).BeginInit();
		((ISupportInitialize)TrackBar_Rainfall).BeginInit();
		((ISupportInitialize)TrackBar_FUR).BeginInit();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[2] { ToolStripLabel1, TSDD_WeatherLevel });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(563, 25);
		ToolStrip1.TabIndex = 0;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(138, 22);
		ToolStripLabel1.Text = "天气建模水平：";
		TSDD_WeatherLevel.BackColor = Color.FromArgb(60, 63, 65);
		TSDD_WeatherLevel.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSDD_WeatherLevel.ForeColor = Color.FromArgb(220, 220, 220);
		TSDD_WeatherLevel.Image = componentResourceManager.GetObject("TSDD_WeatherLevel.Image");
		TSDD_WeatherLevel.ImageTransparentColor = Color.Magenta;
		TSDD_WeatherLevel.Name = "TSDD_WeatherLevel";
		TSDD_WeatherLevel.Size = new Size(56, 22);
		TSDD_WeatherLevel.Text = "0级";
		TC_WeatherLevel.Controls.Add(TabPage1);
		TC_WeatherLevel.Cursor = Cursors.Hand;
		TC_WeatherLevel.Dock = DockStyle.Fill;
		TC_WeatherLevel.ItemSize = new Size(80, 20);
		TC_WeatherLevel.Location = new Point(0, 25);
		TC_WeatherLevel.Multiline = true;
		TC_WeatherLevel.Name = "TC_WeatherLevel";
		TC_WeatherLevel.SelectedIndex = 0;
		TC_WeatherLevel.Size = new Size(563, 172);
		TC_WeatherLevel.TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Label9);
		TabPage1.Controls.Add(Label10);
		TabPage1.Controls.Add(TrackBar_SeaState);
		TabPage1.Controls.Add(Label8);
		TabPage1.Controls.Add(Label_AverageTemp);
		TabPage1.Controls.Add(TrackBar_AverageTemp);
		TabPage1.Controls.Add(Label7);
		TabPage1.Controls.Add(Label6);
		TabPage1.Controls.Add(Label5);
		TabPage1.Controls.Add(Label4);
		TabPage1.Controls.Add(TrackBar_Rainfall);
		TabPage1.Controls.Add(TrackBar_FUR);
		TabPage1.Controls.Add(Label3);
		TabPage1.Controls.Add(Label2);
		TabPage1.Controls.Add(Label1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(555, 144);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "0级";
		Label9.AutoSize = true;
		Label9.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(410, 113);
		Label9.Name = "Label9";
		Label9.Size = new Size(57, 13);
		Label9.TabIndex = 14;
		Label9.Text = "飓风";
		Label10.AutoSize = true;
		Label10.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(144, 111);
		Label10.Name = "Label10";
		Label10.Size = new Size(33, 13);
		Label10.TabIndex = 13;
		Label10.Text = "无风";
		TrackBar_SeaState.AutoSize = false;
		TrackBar_SeaState.LargeChange = 10;
		TrackBar_SeaState.Location = new Point(177, 109);
		TrackBar_SeaState.Maximum = 9;
		TrackBar_SeaState.Name = "TrackBar_SeaState";
		TrackBar_SeaState.Size = new Size(239, 31);
		TrackBar_SeaState.TabIndex = 12;
		Label8.AutoSize = true;
		Label8.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(8, 109);
		Label8.Name = "Label8";
		Label8.Size = new Size(126, 21);
		Label8.TabIndex = 11;
		Label8.Text = "风力/海况：";
		Label_AverageTemp.AutoSize = true;
		Label_AverageTemp.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label_AverageTemp.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AverageTemp.Location = new Point(410, 20);
		Label_AverageTemp.Name = "Label_AverageTemp";
		Label_AverageTemp.Size = new Size(21, 13);
		Label_AverageTemp.TabIndex = 10;
		Label_AverageTemp.Text = "°C";
		TrackBar_AverageTemp.AutoSize = false;
		TrackBar_AverageTemp.LargeChange = 10;
		TrackBar_AverageTemp.Location = new Point(177, 15);
		TrackBar_AverageTemp.Maximum = 50;
		TrackBar_AverageTemp.Minimum = -50;
		TrackBar_AverageTemp.Name = "TrackBar_AverageTemp";
		TrackBar_AverageTemp.Size = new Size(239, 31);
		TrackBar_AverageTemp.SmallChange = 5;
		TrackBar_AverageTemp.TabIndex = 9;
		Label7.AutoSize = true;
		Label7.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(410, 82);
		Label7.Name = "Label7";
		Label7.Size = new Size(117, 13);
		Label7.TabIndex = 8;
		Label7.Text = "浓密云层";
		Label6.AutoSize = true;
		Label6.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(142, 82);
		Label6.Name = "Label6";
		Label6.Size = new Size(33, 13);
		Label6.TabIndex = 7;
		Label6.Text = "清空";
		Label5.AutoSize = true;
		Label5.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(410, 51);
		Label5.Name = "Label5";
		Label5.Size = new Size(72, 13);
		Label5.TabIndex = 6;
		Label5.Text = "特大暴雨";
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(130, 49);
		Label4.Name = "Label4";
		Label4.Size = new Size(46, 13);
		Label4.TabIndex = 5;
		Label4.Text = "无雨";
		TrackBar_Rainfall.AutoSize = false;
		TrackBar_Rainfall.LargeChange = 10;
		TrackBar_Rainfall.Location = new Point(177, 46);
		TrackBar_Rainfall.Maximum = 50;
		TrackBar_Rainfall.Name = "TrackBar_Rainfall";
		TrackBar_Rainfall.Size = new Size(239, 31);
		TrackBar_Rainfall.SmallChange = 5;
		TrackBar_Rainfall.TabIndex = 4;
		TrackBar_FUR.AutoSize = false;
		TrackBar_FUR.LargeChange = 10;
		TrackBar_FUR.Location = new Point(177, 80);
		TrackBar_FUR.Name = "TrackBar_FUR";
		TrackBar_FUR.Size = new Size(239, 31);
		TrackBar_FUR.TabIndex = 3;
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(8, 77);
		Label3.Name = "Label3";
		Label3.Size = new Size(80, 21);
		Label3.TabIndex = 2;
		Label3.Text = "天气：";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(8, 46);
		Label2.Name = "Label2";
		Label2.Size = new Size(96, 21);
		Label2.TabIndex = 1;
		Label2.Text = "雨量：";
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(8, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(160, 21);
		Label1.TabIndex = 0;
		Label1.Text = "平均温度：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(563, 197);
		base.Controls.Add(TC_WeatherLevel);
		base.Controls.Add(ToolStrip1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		MaximumSize = new Size(579, 236);
		base.MinimizeBox = false;
		MinimumSize = new Size(579, 236);
		base.Name = "EditWeather";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "天气编辑";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TC_WeatherLevel.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		((ISupportInitialize)TrackBar_SeaState).EndInit();
		((ISupportInitialize)TrackBar_AverageTemp).EndInit();
		((ISupportInitialize)TrackBar_Rainfall).EndInit();
		((ISupportInitialize)TrackBar_FUR).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void CalculateRules(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		_ThreadList = Client.CurrentScenario.GlobalWeather;
		TrackBar_AverageTemp.Value = (int)Math.Round(_ThreadList.AverageTemp);
		Label_AverageTemp.Text = Conversions.ToString(_ThreadList.AverageTemp) + " °C";
		TrackBar_Rainfall.Value = (int)Math.Round(_ThreadList.RainfallRate);
		TrackBar_FUR.Value = (int)Math.Round(_ThreadList.FractionUnderRain * 10f);
		TrackBar_SeaState.Value = _ThreadList.SeaState;
	}

	private void PopRules(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.AverageTemp = TrackBar_AverageTemp.Value;
		Label_AverageTemp.Text = Conversions.ToString(Client.CurrentScenario.GlobalWeather.AverageTemp) + " °C";
	}

	private void InstantiateRules(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.RainfallRate = TrackBar_Rainfall.Value;
	}

	private void CreateRules(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.FractionUnderRain = (float)((double)TrackBar_FUR.Value * 0.1);
	}

	private void CompareRules(object sender, EventArgs e)
	{
		Client.CurrentScenario.GlobalWeather.SeaState = TrackBar_SeaState.Value;
	}

	private void ReadRules(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void DisableRules(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
