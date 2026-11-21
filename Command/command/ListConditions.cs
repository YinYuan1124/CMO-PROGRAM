using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListConditions : DarkSecondaryFormBase
{
	private IContainer m_AttrComposer;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView visitorComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ConditionType")]
	private DarkUIComboBox m_ExporterComposer;

	[AccessedThroughProperty("Button_EditSelected")]
	[CompilerGenerated]
	private DarkUIButton m_PrototypeComposer;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton comparatorComposer;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_ItemComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton _SetterComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Type")]
	private DataGridViewTextBoxColumn m_MappingComposer;

	private EditCondition m_MockComposer;

	private string tagComposer;

	private bool _FieldComposer;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return visitorComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupTest;
			DataGridViewCellEventHandler value3 = IncludeTest;
			DarkDataGridView darkDataGridView = visitorComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
				darkDataGridView.CellDoubleClick -= value3;
			}
			visitorComposer = value;
			darkDataGridView = visitorComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
				darkDataGridView.CellDoubleClick += value3;
			}
		}
	}

	internal DarkUIComboBox CB_ConditionType
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterComposer = value;
		}
	}

	internal DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginTest;
			DarkUIButton prototypeComposer = m_PrototypeComposer;
			if (prototypeComposer != null)
			{
				prototypeComposer.Click -= value2;
			}
			m_PrototypeComposer = value;
			prototypeComposer = m_PrototypeComposer;
			if (prototypeComposer != null)
			{
				prototypeComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return comparatorComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetTest;
			DarkUIButton darkUIButton = comparatorComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			comparatorComposer = value;
			darkUIButton = comparatorComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ItemComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateTest;
			DarkUIButton itemComposer = m_ItemComposer;
			if (itemComposer != null)
			{
				itemComposer.Click -= value2;
			}
			m_ItemComposer = value;
			itemComposer = m_ItemComposer;
			if (itemComposer != null)
			{
				itemComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_CloneSelected
	{
		[CompilerGenerated]
		get
		{
			return _SetterComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeTest;
			DarkUIButton setterComposer = _SetterComposer;
			if (setterComposer != null)
			{
				setterComposer.Click -= value2;
			}
			_SetterComposer = value;
			setterComposer = _SetterComposer;
			if (setterComposer != null)
			{
				setterComposer.Click += value2;
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

	internal DataGridViewTextBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return m_MappingComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingComposer = value;
		}
	}

	public ListConditions()
	{
		base.Shown += WriteTest;
		base.KeyDown += NewTest;
		base.FormClosing += PushTest;
		base.Load += ExcludeTest;
		ViewTest();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_AttrComposer != null)
			{
				m_AttrComposer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ViewTest()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		CB_ConditionType = new DarkUIComboBox();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		((ISupportInitialize)DataGridView1).BeginInit();
		SuspendLayout();
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToDeleteRows = false;
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
		DataGridView1.Columns.AddRange(ID, Description, Type);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(3, 3);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.ReadOnly = true;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.ShowCellToolTips = false;
		DataGridView1.ShowEditingIcon = false;
		DataGridView1.ShowRowErrors = false;
		DataGridView1.Size = new Size(655, 365);
		DataGridView1.TabIndex = 3;
		CB_ConditionType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_ConditionType.BackColor = Color.Transparent;
		CB_ConditionType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ConditionType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ConditionType.Font = new Font("Segoe UI", 7f);
		CB_ConditionType.FormattingEnabled = true;
		CB_ConditionType.Items.AddRange(new object[3] { "与分方关系", "想定已开始", "Lua脚本" });
		CB_ConditionType.Location = new Point(115, 370);
		CB_ConditionType.Name = "CB_ConditionType";
		CB_ConditionType.Size = new Size(173, 21);
		CB_ConditionType.TabIndex = 15;
		Button_EditSelected.Anchor = AnchorStyles.Bottom;
		Button_EditSelected.BackColor = Color.Transparent;
		Button_EditSelected.DialogResult = DialogResult.None;
		Button_EditSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_EditSelected.ForeColor = SystemColors.Control;
		Button_EditSelected.Location = new Point(435, 370);
		Button_EditSelected.Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		Button_EditSelected.Size = new Size(107, 21);
		Button_EditSelected.TabIndex = 14;
		Button_EditSelected.Text = "编辑选中";
		Button_DeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_DeleteSelected.BackColor = Color.Transparent;
		Button_DeleteSelected.DialogResult = DialogResult.None;
		Button_DeleteSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_DeleteSelected.ForeColor = SystemColors.Control;
		Button_DeleteSelected.Location = new Point(548, 370);
		Button_DeleteSelected.Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		Button_DeleteSelected.Size = new Size(110, 21);
		Button_DeleteSelected.TabIndex = 13;
		Button_DeleteSelected.Text = "删除所选";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(3, 370);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(106, 21);
		Button1.TabIndex = 12;
		Button1.Text = "创建新的：";
		Button_CloneSelected.Anchor = AnchorStyles.Bottom;
		Button_CloneSelected.BackColor = Color.Transparent;
		Button_CloneSelected.DialogResult = DialogResult.None;
		Button_CloneSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CloneSelected.ForeColor = SystemColors.Control;
		Button_CloneSelected.Location = new Point(318, 370);
		Button_CloneSelected.Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		Button_CloneSelected.Size = new Size(111, 21);
		Button_CloneSelected.TabIndex = 16;
		Button_CloneSelected.Text = "克隆已选中";
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		ID.Width = 10;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		Type.DataPropertyName = "Type";
		Type.HeaderText = "类型";
		Type.MinimumWidth = 50;
		Type.Name = "Type";
		Type.ReadOnly = true;
		Type.Width = 54;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(661, 397);
		base.Controls.Add(Button_CloneSelected);
		base.Controls.Add(CB_ConditionType);
		base.Controls.Add(Button_EditSelected);
		base.Controls.Add(Button_DeleteSelected);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ListConditions";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "事件条件";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void RefreshGrid()
	{
		try
		{
			_FieldComposer = true;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventCondition item in Client.CurrentScenario.EventConditions.Values.OrderBy((EventCondition theCondition) => theCondition.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["Type"] = item.Type.ToString();
				dataTable.Rows.Add(dataRow);
			}
			DataGridView1.DataSource = dataTable;
			DataGridView1.ResumeLayout();
			_FieldComposer = false;
			if (string.IsNullOrEmpty(tagComposer))
			{
				return;
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = ((IEnumerable)DataGridView1.Rows).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object objectValue = RuntimeHelpers.GetObjectValue(enumerator2.Current);
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Cells", new object[1] { "ID" }, null, null, null), null, "Value", new object[0], null, null, null), tagComposer, TextCompare: true))
					{
						DataGridView1.CurrentCell = (DataGridViewCell)NewLateBinding.LateGet(objectValue, null, "cells", new object[1] { 1 }, null, null, null);
						break;
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200105", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			RefreshGrid();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ValidateTest(object sender, EventArgs e)
	{
		if (CB_ConditionType.SelectedIndex <= -1)
		{
			return;
		}
		EventCondition theEC;
		switch (CB_ConditionType.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			theEC = new EventCondition_SidePosture();
			break;
		case 1:
			theEC = new EventCondition_ScenHasStarted();
			break;
		case 2:
			theEC = new EventCondition_LuaScript();
			break;
		}
		m_MockComposer = new EditCondition();
		m_MockComposer.theEC = theEC;
		m_MockComposer.Action = EditCondition._FormAction.AddNew;
		m_MockComposer.Show();
	}

	private void LoginTest(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventCondition theEC = Client.CurrentScenario.EventConditions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			m_MockComposer = new EditCondition();
			m_MockComposer.theEC = theEC;
			m_MockComposer.Action = EditCondition._FormAction.EditExisting;
			m_MockComposer.Show();
		}
	}

	private void GetTest(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		EventCondition eventCondition = Client.CurrentScenario.EventConditions[text];
		if (Information.IsNothing(eventCondition))
		{
			return;
		}
		bool flag = false;
		foreach (SimEvent value in Client.CurrentScenario.SimEvents.Values)
		{
			if (value.Conditions.Contains(eventCondition))
			{
				flag = true;
				break;
			}
		}
		if (flag && DarkMessageBox.ShowWarning("此条件至少正被一个事件使用，您确定要删除它吗？", "条件正被使用中！", DarkDialogButton.YesNo) == DialogResult.No)
		{
			return;
		}
		Client.CurrentScenario.EventConditions.Remove(eventCondition.ObjectID);
		foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
		{
			value2.Conditions.Remove(eventCondition);
		}
		RefreshGrid();
	}

	private void WriteTest(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void NewTest(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PushTest(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void InvokeTest(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			EventCondition eventCondition = Client.CurrentScenario.EventConditions[text].Clone();
			Client.CurrentScenario.EventConditions.Add(eventCondition.ObjectID, eventCondition);
			RefreshGrid();
		}
	}

	private void SetupTest(object sender, EventArgs e)
	{
		if (!_FieldComposer && DataGridView1.SelectedRows.Count != 0)
		{
			tagComposer = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		}
	}

	private void ExcludeTest(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void IncludeTest(object sender, DataGridViewCellEventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventCondition theEC = Client.CurrentScenario.EventConditions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			m_MockComposer = new EditCondition();
			m_MockComposer.theEC = theEC;
			m_MockComposer.Action = EditCondition._FormAction.EditExisting;
			m_MockComposer.Show();
		}
	}

	public void ShowEditTrigger(EventCondition eventCondition_0)
	{
		m_MockComposer = new EditCondition();
		m_MockComposer.theEC = eventCondition_0;
		m_MockComposer.Action = EditCondition._FormAction.EditExisting;
		m_MockComposer.Show();
	}
}
