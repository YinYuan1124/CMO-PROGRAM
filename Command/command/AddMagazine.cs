using System;
using System.Collections;
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
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddMagazine : DarkSecondaryFormBase
{
	private IContainer listenerProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView configProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker registryProperty;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton definitionProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox _ValProperty;

	[AccessedThroughProperty("CB_Filter1")]
	[CompilerGenerated]
	private DarkCheckBox m_WrapperProperty;

	private DataTable _ClientProperty;

	private DataView m_DicProperty;

	private bool m_ConsumerProperty;

	public Form FormThatCalledMe;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return configProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configProperty = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return definitionProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefinePool;
			DarkUIButton darkUIButton = definitionProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			definitionProperty = value;
			darkUIButton = definitionProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return _ValProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = AwakePool;
			EventHandler value3 = SortPool;
			EventHandler value4 = CalcPool;
			DarkUITextBox valProperty = _ValProperty;
			if (valProperty != null)
			{
				valProperty.TextChanged -= value2;
				valProperty.Enter -= value3;
				valProperty.Leave -= value4;
			}
			_ValProperty = value;
			valProperty = _ValProperty;
			if (valProperty != null)
			{
				valProperty.TextChanged += value2;
				valProperty.Enter += value3;
				valProperty.Leave += value4;
			}
		}
	}

	internal DarkCheckBox CB_Filter1
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushPool;
			DarkCheckBox wrapperProperty = m_WrapperProperty;
			if (wrapperProperty != null)
			{
				wrapperProperty.CheckedChanged -= value2;
			}
			m_WrapperProperty = value;
			wrapperProperty = m_WrapperProperty;
			if (wrapperProperty != null)
			{
				wrapperProperty.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Description")]
	internal DataGridViewTextBoxColumn Description
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker RegisterPool()
	{
		return registryProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ManagePool(BackgroundWorker backgroundWorker_0)
	{
		registryProperty = backgroundWorker_0;
	}

	public AddMagazine()
	{
		base.Shown += PrintPool;
		base.KeyDown += MapPool;
		base.FormClosing += RatePool;
		base.Load += ForgotPool;
		AssetPool();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && listenerProperty != null)
			{
				listenerProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AssetPool()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		ManagePool(new BackgroundWorker());
		Button1 = new DarkUIButton();
		TB_Find = new DarkUITextBox();
		CB_Filter1 = new DarkCheckBox();
		((ISupportInitialize)DataGridView1).BeginInit();
		SuspendLayout();
		DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.Fixed3D;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridView1.Columns.AddRange(ID, Description);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(0, 71);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(401, 435);
		DataGridView1.TabIndex = 1;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Width = 41;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(7, 12);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(89, 23);
		Button1.TabIndex = 3;
		Button1.Text = "添加所选项";
		TB_Find.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = AutoCompleteMode.None;
		TB_Find.AutoCompleteSource = AutoCompleteSource.None;
		TB_Find.BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 10f);
		TB_Find.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		TB_Find.Location = new Point(132, 45);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		TB_Find.Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.SelectionStart = 0;
		TB_Find.Size = new Size(269, 20);
		TB_Find.TabIndex = 12;
		TB_Find.TextAlign = HorizontalAlignment.Left;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "";
		CB_Filter1.AutoSize = true;
		CB_Filter1.Location = new Point(7, 47);
		CB_Filter1.Name = "CB_Filter1";
		CB_Filter1.Size = new Size(119, 19);
		CB_Filter1.TabIndex = 13;
		CB_Filter1.Text = "按关键字过滤：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(401, 506);
		base.Controls.Add(CB_Filter1);
		base.Controls.Add(TB_Find);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddMagazine";
		base.ShowIcon = false;
		Text = "添加弹药";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PrintPool(object sender, EventArgs e)
	{
		PublishPool();
	}

	private void DefinePool(object sender, EventArgs e)
	{
		Magazine magazine = DBFunctions.GetMagazine(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value), ref Client.theMagazinesWindow.SelectedUnit.ParentScen);
		magazine.ParentPlatform = (ActiveUnit)Client.SelectedUnit;
		((Platform)Client.theMagazinesWindow.SelectedUnit).AddSharedMagazine(magazine);
	}

	private void PublishPool()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		_ClientProperty = DBFunctions.GetAllMags(ref sqliteConnection_);
		if (!_ClientProperty.Columns.Contains("Description"))
		{
			_ClientProperty.Columns.Add("Description", typeof(string));
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = _ClientProperty.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				dataRow["Description"] = RuntimeHelpers.GetObjectValue(dataRow["Name"]);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		ResetPool();
	}

	private void AwakePool(object object_0)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			QueryPool();
		}
	}

	private void QueryPool()
	{
		DataView dataView = new DataView(_ClientProperty);
		dataView.Sort = "Description ASC";
		dataView.RowFilter = "Description LIKE '%" + TB_Find.Text + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void ResetPool()
	{
		m_DicProperty = new DataView(_ClientProperty);
		m_DicProperty.Sort = "Description ASC";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = m_DicProperty;
	}

	private void MapPool(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (m_ConsumerProperty)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				CB_Filter1.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!m_ConsumerProperty && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void SortPool(object sender, EventArgs e)
	{
		m_ConsumerProperty = true;
	}

	private void CalcPool(object sender, EventArgs e)
	{
		m_ConsumerProperty = false;
		CB_Filter1.Select();
	}

	private void RatePool(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void FlushPool(object sender, EventArgs e)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			QueryPool();
		}
		else
		{
			PublishPool();
		}
	}

	private void ForgotPool(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
