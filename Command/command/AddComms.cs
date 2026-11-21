using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddComms : DarkSecondaryFormBase
{
	private IContainer authenticationReader;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView m_ParamsReader;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker m_InfoReader;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton m_HelperReader;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter1")]
	private DarkCheckBox m_MapperReader;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox managerReader;

	[AccessedThroughProperty("Button_Add10K")]
	[CompilerGenerated]
	private DarkUIButton getterReader;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ProducerReader;

	[AccessedThroughProperty("Type")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn structProperty;

	[AccessedThroughProperty("CB_Filter3")]
	[CompilerGenerated]
	private DarkCheckBox m_MerchantProperty;

	private DataTable _CallbackProperty;

	private DataView m_DecoratorProperty;

	private bool m_ProcessProperty;

	public Form FormThatCalledMe;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = ViewPool;
			DarkDataGridView paramsReader = m_ParamsReader;
			if (paramsReader != null)
			{
				paramsReader.CellDoubleClick -= value2;
			}
			m_ParamsReader = value;
			paramsReader = m_ParamsReader;
			if (paramsReader != null)
			{
				paramsReader.CellDoubleClick += value2;
			}
		}
	}

	internal DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return m_HelperReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountPool;
			DarkUIButton helperReader = m_HelperReader;
			if (helperReader != null)
			{
				helperReader.Click -= value2;
			}
			m_HelperReader = value;
			helperReader = m_HelperReader;
			if (helperReader != null)
			{
				helperReader.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Filter1
	{
		[CompilerGenerated]
		get
		{
			return m_MapperReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidatePool;
			EventHandler value3 = LoginPool;
			DarkCheckBox mapperReader = m_MapperReader;
			if (mapperReader != null)
			{
				mapperReader.CheckedChanged -= value2;
				mapperReader.CheckedChanged -= value3;
			}
			m_MapperReader = value;
			mapperReader = m_MapperReader;
			if (mapperReader != null)
			{
				mapperReader.CheckedChanged += value2;
				mapperReader.CheckedChanged += value3;
			}
		}
	}

	internal DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return managerReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ConnectPool;
			EventHandler value3 = PatchPool;
			EventHandler value4 = SelectPool;
			DarkUITextBox darkUITextBox = managerReader;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				darkUITextBox.Enter -= value3;
				darkUITextBox.Leave -= value4;
			}
			managerReader = value;
			darkUITextBox = managerReader;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				darkUITextBox.Enter += value3;
				darkUITextBox.Leave += value4;
			}
		}
	}

	internal DarkUIButton Button_Add10K
	{
		[CompilerGenerated]
		get
		{
			return getterReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterReader = value;
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerReader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProducerReader = value;
		}
	}

	[field: AccessedThroughProperty("Description")]
	internal DataGridViewTextBoxColumn Description
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return structProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			structProperty = value;
		}
	}

	internal DarkCheckBox CB_Filter3
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginPool;
			DarkCheckBox merchantProperty = m_MerchantProperty;
			if (merchantProperty != null)
			{
				merchantProperty.CheckedChanged -= value2;
			}
			m_MerchantProperty = value;
			merchantProperty = m_MerchantProperty;
			if (merchantProperty != null)
			{
				merchantProperty.CheckedChanged += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker PushPool()
	{
		return m_InfoReader;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InvokePool(BackgroundWorker backgroundWorker_0)
	{
		m_InfoReader = backgroundWorker_0;
	}

	public AddComms()
	{
		base.Shown += DestroyPool;
		base.KeyDown += ComputePool;
		base.FormClosing += CallPool;
		base.Load += LogoutPool;
		RevertList();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && authenticationReader != null)
			{
				authenticationReader.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RevertList()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		InvokePool(new BackgroundWorker());
		Button_AddSelected = new DarkUIButton();
		CB_Filter1 = new DarkCheckBox();
		TB_Find = new DarkUITextBox();
		CB_Filter3 = new DarkCheckBox();
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
		DataGridView1.Columns.AddRange(ID, Description, Type);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(0, 93);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(331, 413);
		DataGridView1.TabIndex = 1;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Width = 41;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Name";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Type.DataPropertyName = "Type";
		Type.HeaderText = "类型";
		Type.Name = "Type";
		Type.ReadOnly = true;
		Button_AddSelected.BackColor = Color.Transparent;
		Button_AddSelected.DialogResult = DialogResult.None;
		Button_AddSelected.Font = new Font("Segoe UI", 10f);
		Button_AddSelected.ForeColor = SystemColors.Control;
		Button_AddSelected.Location = new Point(7, 12);
		Button_AddSelected.Name = "Button_AddSelected";
		Button_AddSelected.RoundRadius = 0;
		Button_AddSelected.Size = new Size(89, 23);
		Button_AddSelected.TabIndex = 3;
		Button_AddSelected.Text = "添加所选项";
		CB_Filter1.AutoSize = true;
		CB_Filter1.Location = new Point(7, 47);
		CB_Filter1.Name = "CB_Filter1";
		CB_Filter1.Size = new Size(119, 19);
		CB_Filter1.TabIndex = 13;
		CB_Filter1.Text = "按关键字过滤：";
		TB_Find.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = AutoCompleteMode.None;
		TB_Find.AutoCompleteSource = AutoCompleteSource.None;
		TB_Find.BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 8f);
		TB_Find.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		TB_Find.Location = new Point(132, 45);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		TB_Find.Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = ScrollBars.None;
		TB_Find.SelectionStart = 0;
		TB_Find.Size = new Size(187, 20);
		TB_Find.TabIndex = 12;
		TB_Find.TextAlign = HorizontalAlignment.Left;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "";
		CB_Filter3.AutoSize = true;
		CB_Filter3.Location = new Point(7, 72);
		CB_Filter3.Name = "CB_Filter3";
		CB_Filter3.Size = new Size(97, 19);
		CB_Filter3.TabIndex = 15;
		CB_Filter3.Text = "按类型过滤：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(331, 506);
		base.Controls.Add(CB_Filter3);
		base.Controls.Add(CB_Filter1);
		base.Controls.Add(TB_Find);
		base.Controls.Add(Button_AddSelected);
		base.Controls.Add(DataGridView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddComms";
		base.ShowIcon = false;
		Text = "添加通信设备";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CountPool(object sender, EventArgs e)
	{
		CustomizePool();
	}

	private void CustomizePool()
	{
		if (FormThatCalledMe == Client.theCommsWindow && Client.theCommsWindow.theSelectedUnit != null)
		{
			int int_ = Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value);
			UnitComms theCommsWindow;
			ActiveUnit activeUnit_ = (theCommsWindow = Client.theCommsWindow).theSelectedUnit;
			CommDevice commDevice = DBFunctions.GetCommDevice(int_, ref activeUnit_);
			theCommsWindow.theSelectedUnit = activeUnit_;
			CommDevice commDevice2 = commDevice;
			if (commDevice2 != null)
			{
				Client.theCommsWindow.theSelectedUnit.AddCommDevice(commDevice2);
			}
			if (Client.theCommsWindow.Visible)
			{
				Client.theCommsWindow.BuildForm();
			}
		}
	}

	private void ClonePool()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		_CallbackProperty = DBFunctions.GetAllCommDevices(ref sqliteConnection_);
	}

	private void ConnectPool(object object_0)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			MovePool();
		}
		else if (CB_Filter3.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			DeletePool();
		}
	}

	private void MovePool()
	{
		DataView dataView = new DataView(_CallbackProperty);
		dataView.RowFilter = "Name LIKE '%" + Misc.PatchValue(TB_Find.Text) + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void DeletePool()
	{
		DataView dataView = new DataView(_CallbackProperty);
		dataView.RowFilter = "Type LIKE '%" + Misc.PatchValue(TB_Find.Text) + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void AddPool()
	{
		if (_CallbackProperty == null)
		{
			ClonePool();
		}
		Invoke((VB_0024AnonymousDelegate_0)delegate
		{
			m_DecoratorProperty = new DataView(_CallbackProperty);
			m_DecoratorProperty.Sort = "Name ASC";
			DataGridView1.DataSource = m_DecoratorProperty;
		});
	}

	public void InjectFilterByKeyword(string string_0)
	{
		ClonePool();
		CB_Filter1.Checked = false;
		TB_Find.Text = string_0;
		MovePool();
	}

	private void DestroyPool(object sender, EventArgs e)
	{
		Task.Factory.StartNew(AddPool);
	}

	private void ComputePool(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (m_ProcessProperty)
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
		if (!m_ProcessProperty && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PatchPool(object sender, EventArgs e)
	{
		m_ProcessProperty = true;
	}

	private void SelectPool(object sender, EventArgs e)
	{
		m_ProcessProperty = false;
		CB_Filter1.Select();
	}

	private void CallPool(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LogoutPool(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		DataGridView1.AutoGenerateColumns = false;
	}

	private void ViewPool(object sender, DataGridViewCellEventArgs e)
	{
		CustomizePool();
	}

	private void ValidatePool(object sender, EventArgs e)
	{
		if (!CB_Filter1.Checked && !CB_Filter3.Checked)
		{
			DataGridView1.AutoGenerateColumns = false;
			DataGridView1.DataSource = _CallbackProperty;
			DataGridView1.Refresh();
		}
		else if (CB_Filter1.Checked)
		{
			CB_Filter3.Checked = false;
			MovePool();
		}
	}

	private void LoginPool(object sender, EventArgs e)
	{
		if (!CB_Filter1.Checked && !CB_Filter3.Checked)
		{
			DataGridView1.AutoGenerateColumns = false;
			DataGridView1.DataSource = _CallbackProperty;
			DataGridView1.Refresh();
		}
		else if (CB_Filter3.Checked)
		{
			CB_Filter1.Checked = false;
			DeletePool();
		}
	}

	[CompilerGenerated]
	private void GetPool()
	{
		m_DecoratorProperty = new DataView(_CallbackProperty);
		m_DecoratorProperty.Sort = "Name ASC";
		DataGridView1.DataSource = m_DecoratorProperty;
	}
}
