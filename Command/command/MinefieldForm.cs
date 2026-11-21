using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MinefieldForm : DarkSecondaryFormBase
{
	private IContainer _ImporterContext;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Weapon")]
	private DarkUIComboBox m_BridgeContext;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_InvocationContext;

	[AccessedThroughProperty("NumericUpDown1")]
	[CompilerGenerated]
	private GControl1 classContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton m_RequestContext;

	public List<ReferencePoint> theArea;

	private DataTable _TokenizerContext;

	private DataView _StubContext;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker writerContext;

	private int specificationContext;

	private int m_WatcherContext;

	private int reponseContext;

	private HashSet<string> _DescriptorContext;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Weapon
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BridgeContext = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationContext = value;
		}
	}

	internal GControl1 NumericUpDown1
	{
		[CompilerGenerated]
		get
		{
			return classContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			classContext = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_RequestContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetInterruptibleDefinition;
			DarkUIButton requestContext = m_RequestContext;
			if (requestContext != null)
			{
				requestContext.Click -= value2;
			}
			m_RequestContext = value;
			requestContext = m_RequestContext;
			if (requestContext != null)
			{
				requestContext.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ProgressBar1")]
	internal DarkUIProgressBar ProgressBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker SetInterruptibleDefinition()
	{
		return writerContext;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void FillInterruptibleDefinition(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = WriteInterruptibleDefinition;
		RunWorkerCompletedEventHandler value2 = NewInterruptibleDefinition;
		BackgroundWorker backgroundWorker = writerContext;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		writerContext = backgroundWorker_0;
		backgroundWorker = writerContext;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public MinefieldForm()
	{
		base.Load += LoginInterruptibleDefinition;
		base.KeyDown += PushInterruptibleDefinition;
		base.FormClosing += InvokeInterruptibleDefinition;
		theArea = new List<ReferencePoint>();
		_TokenizerContext = new DataTable();
		FillInterruptibleDefinition(new BackgroundWorker());
		_DescriptorContext = new HashSet<string>();
		ValidateInterruptibleDefinition();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ImporterContext != null)
			{
				_ImporterContext.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ValidateInterruptibleDefinition()
	{
		Label1 = new DarkLabel();
		CB_Weapon = new DarkUIComboBox();
		Label2 = new DarkLabel();
		NumericUpDown1 = new GControl1();
		Button1 = new DarkUIButton();
		ProgressBar1 = new DarkUIProgressBar();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(47, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(34, 16);
		Label1.TabIndex = 0;
		Label1.Text = "类型：";
		CB_Weapon.BackColor = Color.Transparent;
		CB_Weapon.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Weapon.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Weapon.Font = new Font("Segoe UI", 10f);
		CB_Weapon.FormattingEnabled = true;
		CB_Weapon.Location = new Point(82, 8);
		CB_Weapon.Name = "CB_Weapon";
		CB_Weapon.Size = new Size(392, 26);
		CB_Weapon.TabIndex = 1;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(13, 44);
		Label2.Name = "Label2";
		Label2.Size = new Size(68, 16);
		Label2.TabIndex = 2;
		Label2.Text = "数量：";
		NumericUpDown1.BackColor = Color.Transparent;
		NumericUpDown1.Font = new Font("Segoe UI", 10f);
		NumericUpDown1.Location = new Point(82, 39);
		NumericUpDown1.Maximum = 100;
		NumericUpDown1.Minimum = 1;
		NumericUpDown1.Name = "NumericUpDown1";
		NumericUpDown1.Size = new Size(124, 26);
		NumericUpDown1.TabIndex = 3;
		NumericUpDown1.Value = 1;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(399, 38);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 29);
		Button1.TabIndex = 4;
		Button1.Text = "添加";
		ProgressBar1.BackColor = Color.Transparent;
		ProgressBar1.CustomForeColor = Color.Transparent;
		ProgressBar1.Font = new Font("Segoe UI", 9f);
		ProgressBar1.Location = new Point(16, 72);
		ProgressBar1.Maximum = 100;
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.ShowProgressLines = true;
		ProgressBar1.ShowProgressValue = false;
		ProgressBar1.ShowText = false;
		ProgressBar1.Size = new Size(458, 12);
		ProgressBar1.TabIndex = 5;
		ProgressBar1.Value = 0;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(486, 95);
		base.Controls.Add(ProgressBar1);
		base.Controls.Add(Button1);
		base.Controls.Add(NumericUpDown1);
		base.Controls.Add(Label2);
		base.Controls.Add(CB_Weapon);
		base.Controls.Add(Label1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MinefieldForm";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "在指定区域添加雷";
		ResumeLayout(performLayout: false);
	}

	private void LoginInterruptibleDefinition(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Scenario scenario_ = Client.CurrentScenario;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		_TokenizerContext = DBFunctions.GetAllWeapons(bool_0: true, ref scenario_, ref sqliteConnection_);
		if (!_TokenizerContext.Columns.Contains("FullName"))
		{
			_TokenizerContext.Columns.Add("FullName", typeof(string));
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = _TokenizerContext.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				if (Client.CurrentScenario.FeatureCompatibility.GetWeaponAGL_ASL(Client.CurrentScenario.DBConnection))
				{
					dataRow["FullName"] = Strings.Trim(Conversions.ToString(dataRow["Name"])) + " [" + Conversions.ToString(Math.Abs(Conversions.ToInteger(dataRow["TargetAltitudeMax_ASL"]))) + "m - " + Conversions.ToString(Math.Abs(Conversions.ToInteger(dataRow["TargetAltitudeMin_ASL"]))) + "m]";
				}
				else
				{
					dataRow["FullName"] = Strings.Trim(Conversions.ToString(dataRow["Name"])) + " [" + Conversions.ToString(Math.Abs(Conversions.ToInteger(dataRow["TargetAltitudeMax"]))) + "m - " + Conversions.ToString(Math.Abs(Conversions.ToInteger(dataRow["TargetAltitudeMin"]))) + "m]";
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
		_StubContext = new DataView(_TokenizerContext);
		_StubContext.Sort = "FULLNAME ASC";
		_StubContext.RowFilter = "TYPE IN (4004, 4005, 4006, 4007, 4008, 4009, 4011)";
		CB_Weapon.DataSource = _StubContext;
		CB_Weapon.DisplayMember = "FullName";
		CB_Weapon.ValueMember = "ID";
		ProgressBar1.Visible = false;
	}

	private void GetInterruptibleDefinition(object sender, EventArgs e)
	{
		Button1.Text = "请等待...";
		Button1.Enabled = false;
		ProgressBar1.Visible = true;
		specificationContext = Conversions.ToInteger(CB_Weapon.SelectedValue);
		SetInterruptibleDefinition().RunWorkerAsync();
	}

	private void WriteInterruptibleDefinition(object sender, DoWorkEventArgs e)
	{
		m_WatcherContext = NumericUpDown1.Value;
		reponseContext = 0;
		string string_ = null;
		_DescriptorContext.Clear();
		int watcherContext = m_WatcherContext;
		int num;
		for (num = 0; num <= watcherContext; num++)
		{
			num++;
			UnguidedWeapon expression = Client.CurrentScenario.AddNewMine(Client.CurrentSide, specificationContext, theArea, ref string_);
			if (string_ != null && !_DescriptorContext.Contains(string_))
			{
				_DescriptorContext.Add(string_);
			}
			if (!Information.IsNothing(expression))
			{
				reponseContext++;
			}
		}
	}

	private void NewInterruptibleDefinition(object sender, RunWorkerCompletedEventArgs e)
	{
		Button1.Text = "添加";
		Button1.Enabled = true;
		ProgressBar1.Visible = false;
		Client.MustRefreshMainForm = true;
		string text = "";
		if (m_WatcherContext == reponseContext)
		{
			text = "所有地雷都成功铺设。";
		}
		else
		{
			text = ((reponseContext == 0) ? "No mine was succesfully laid. Failures are due to the following reasons : " : ("只有" + Conversions.ToString(reponseContext) + " of the mines were laid successfully. Failures are due to the following reasons : "));
			text += Environment.NewLine;
			foreach (string item in _DescriptorContext)
			{
				text += item;
				text += Environment.NewLine;
			}
		}
		DarkMessageBox.ShowInformation(text, "地雷安置完成！");
	}

	private void PushInterruptibleDefinition(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void InvokeInterruptibleDefinition(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
