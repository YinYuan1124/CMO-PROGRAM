using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SpecialActionsForm : DarkSecondaryFormBase
{
	private IContainer threadRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView m_RuleRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn collectionRecord;

	[AccessedThroughProperty("ActionName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn instanceRecord;

	[AccessedThroughProperty("ExecuteAction")]
	[CompilerGenerated]
	private DataGridViewButtonColumn objectRecord;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel m_ExpressionRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("txtDesc")]
	private DarkUITextBox m_DispatcherRecord;

	private Keys[] listenerRecord;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_RuleRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = SetInterruptibleSchema;
			DataGridViewCellFormattingEventHandler value3 = CalculateInterruptibleSchema;
			DarkDataGridView ruleRecord = m_RuleRecord;
			if (ruleRecord != null)
			{
				ruleRecord.CellClick -= value2;
				ruleRecord.CellFormatting -= value3;
			}
			m_RuleRecord = value;
			ruleRecord = m_RuleRecord;
			if (ruleRecord != null)
			{
				ruleRecord.CellClick += value2;
				ruleRecord.CellFormatting += value3;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return collectionRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionRecord = value;
		}
	}

	internal DataGridViewTextBoxColumn ActionName
	{
		[CompilerGenerated]
		get
		{
			return instanceRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instanceRecord = value;
		}
	}

	internal DataGridViewButtonColumn ExecuteAction
	{
		[CompilerGenerated]
		get
		{
			return objectRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectRecord = value;
		}
	}

	[field: AccessedThroughProperty("CB_AllowActionPopup")]
	internal DarkCheckBox CB_AllowActionPopup
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExpressionRecord = value;
		}
	}

	internal DarkUITextBox txtDesc
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DispatcherRecord = value;
		}
	}

	public SpecialActionsForm()
	{
		base.VisibleChanged += FindInterruptibleSchema;
		base.Load += FillInterruptibleSchema;
		listenerRecord = new Keys[1] { Keys.Escape };
		RemoveInterruptibleSchema();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && threadRecord != null)
			{
				threadRecord.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RemoveInterruptibleSchema()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ActionName = new DataGridViewTextBoxColumn();
		ExecuteAction = new DataGridViewButtonColumn();
		CB_AllowActionPopup = new DarkCheckBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		txtDesc = new DarkUITextBox();
		((ISupportInitialize)DataGridView1).BeginInit();
		TableLayoutPanel1.SuspendLayout();
		SuspendLayout();
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToOrderColumns = true;
		DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.Fixed3D;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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
		DataGridView1.Columns.AddRange(ID, ActionName, ExecuteAction);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(3, 3);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersWidth = 62;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.Size = new Size(762, 227);
		DataGridView1.TabIndex = 0;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.MinimumWidth = 8;
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		ID.Width = 150;
		ActionName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ActionName.DataPropertyName = "Name";
		ActionName.HeaderText = "名称";
		ActionName.MinimumWidth = 8;
		ActionName.Name = "ActionName";
		ActionName.ReadOnly = true;
		ExecuteAction.HeaderText = "";
		ExecuteAction.MinimumWidth = 8;
		ExecuteAction.Name = "ExecuteAction";
		ExecuteAction.ReadOnly = true;
		ExecuteAction.Text = "执行";
		ExecuteAction.UseColumnTextForButtonValue = true;
		ExecuteAction.Width = 150;
		CB_AllowActionPopup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_AllowActionPopup.AutoSize = true;
		CB_AllowActionPopup.Checked = true;
		CB_AllowActionPopup.CheckState = CheckState.Checked;
		CB_AllowActionPopup.Location = new Point(3, 475);
		CB_AllowActionPopup.Name = "CB_AllowActionPopup";
		CB_AllowActionPopup.Size = new Size(391, 29);
		CB_AllowActionPopup.TabIndex = 2;
		CB_AllowActionPopup.Text = "显示带反馈的弹出消息";
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		TableLayoutPanel1.Controls.Add(DataGridView1, 0, 0);
		TableLayoutPanel1.Controls.Add(CB_AllowActionPopup, 0, 2);
		TableLayoutPanel1.Controls.Add(txtDesc, 0, 1);
		TableLayoutPanel1.Dock = DockStyle.Fill;
		TableLayoutPanel1.Location = new Point(0, 0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 3;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8f));
		TableLayoutPanel1.Size = new Size(768, 507);
		TableLayoutPanel1.TabIndex = 3;
		txtDesc.AutoCompleteCustomSource = null;
		txtDesc.AutoCompleteMode = AutoCompleteMode.None;
		txtDesc.AutoCompleteSource = AutoCompleteSource.None;
		txtDesc.BackColor = Color.Transparent;
		txtDesc.Dock = DockStyle.Fill;
		txtDesc.ForeColor = Color.FromArgb(189, 189, 189);
		txtDesc.Image = null;
		txtDesc.Lines = null;
		txtDesc.Location = new Point(3, 236);
		txtDesc.MaxLength = 32767;
		txtDesc.Multiline = true;
		txtDesc.Name = "txtDesc";
		txtDesc.ReadOnly = false;
		txtDesc.ScrollBars = ScrollBars.Vertical;
		txtDesc.SelectionStart = 0;
		txtDesc.Size = new Size(762, 227);
		txtDesc.TabIndex = 3;
		txtDesc.TextAlign = HorizontalAlignment.Left;
		txtDesc.UseSystemPasswordChar = false;
		txtDesc.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(768, 507);
		base.Controls.Add(TableLayoutPanel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SpecialActionsForm";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "特殊动作";
		((ISupportInitialize)DataGridView1).EndInit();
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = listenerRecord;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys keys = array[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		Close();
		return true;
	}

	private void FindInterruptibleSchema(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			RefreshGrid();
		}
	}

	public void RefreshGrid()
	{
		if (Client.CurrentSide == null)
		{
			return;
		}
		try
		{
			SpecialAction specialAction = null;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			foreach (SpecialAction item in from theAction in Client.CurrentSide.SpecialActions.Values
				where theAction.IsActive
				orderby theAction.Name
				select theAction)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Name"] = item.Name;
				dataTable.Rows.Add(dataRow);
				if (dataTable.Rows.Count == 1)
				{
					specialAction = item;
				}
			}
			DataGridView1.AutoGenerateColumns = false;
			DataGridView1.DataSource = dataTable;
			DataGridView1.ResumeLayout();
			if (DataGridView1.Rows.Count > 0)
			{
				DataGridView1.Rows[0].Selected = true;
				DataGridView1.Rows[0].Cells[0].ToolTipText = specialAction.Description;
				txtDesc.Visible = true;
				txtDesc.Text = specialAction.Description;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200406", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Refresh();
			ProjectData.ClearProjectError();
		}
	}

	private void SetInterruptibleSchema(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || e.RowIndex > DataGridView1.Rows.Count - 1)
		{
			return;
		}
		DataGridViewColumn dataGridViewColumn = DataGridView1.Columns[e.ColumnIndex];
		string key = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
		if (!Client.CurrentSide.SpecialActions.ContainsKey(key))
		{
			return;
		}
		SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
		txtDesc.Visible = true;
		txtDesc.Text = specialAction.Description;
		if (Operators.CompareString(dataGridViewColumn.Name, "ExecuteAction", TextCompare: true) == 0)
		{
			string text = specialAction.MoveSpecification(Client.CurrentScenario);
			if (CB_AllowActionPopup.Checked)
			{
				if (text != null && Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					DarkMessageBox.ShowInformation(text, "");
				}
				else
				{
					DarkMessageBox.ShowError("特殊动作脚本错误！", "Error");
				}
			}
			RefreshGrid();
		}
		Client.MustRefreshMainForm = true;
	}

	private void FillInterruptibleSchema(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void CalculateInterruptibleSchema(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (Client.CurrentSide.SpecialActions.Count > 0)
		{
			string key = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
			if (Client.CurrentSide.SpecialActions.ContainsKey(key))
			{
				SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
				DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = specialAction.Description;
			}
		}
	}
}
