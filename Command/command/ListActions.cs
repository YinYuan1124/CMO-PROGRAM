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
public sealed class ListActions : DarkSecondaryFormBase
{
	private IContainer _ConfigurationComposer;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView tokenComposer;

	[AccessedThroughProperty("CB_ActionType")]
	[CompilerGenerated]
	private DarkUIComboBox indexerComposer;

	[AccessedThroughProperty("Button_EditSelected")]
	[CompilerGenerated]
	private DarkUIButton m_ResolverComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteSelected")]
	private DarkUIButton _PublisherComposer;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton serverComposer;

	[AccessedThroughProperty("Button_CloneSelected")]
	[CompilerGenerated]
	private DarkUIButton m_AdapterComposer;

	private EditAction _SingletonComposer;

	private string _RecordComposer;

	private bool _ExceptionComposer;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return tokenComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateRole;
			DataGridViewCellEventHandler value3 = ForgotRole;
			DarkDataGridView darkDataGridView = tokenComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
				darkDataGridView.CellDoubleClick -= value3;
			}
			tokenComposer = value;
			darkDataGridView = tokenComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
				darkDataGridView.CellDoubleClick += value3;
			}
		}
	}

	internal DarkUIComboBox CB_ActionType
	{
		[CompilerGenerated]
		get
		{
			return indexerComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			indexerComposer = value;
		}
	}

	internal DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeRole;
			DarkUIButton resolverComposer = m_ResolverComposer;
			if (resolverComposer != null)
			{
				resolverComposer.Click -= value2;
			}
			m_ResolverComposer = value;
			resolverComposer = m_ResolverComposer;
			if (resolverComposer != null)
			{
				resolverComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return _PublisherComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryRole;
			DarkUIButton publisherComposer = _PublisherComposer;
			if (publisherComposer != null)
			{
				publisherComposer.Click -= value2;
			}
			_PublisherComposer = value;
			publisherComposer = _PublisherComposer;
			if (publisherComposer != null)
			{
				publisherComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return serverComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishRole;
			DarkUIButton darkUIButton = serverComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			serverComposer = value;
			darkUIButton = serverComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_CloneSelected
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcRole;
			DarkUIButton adapterComposer = m_AdapterComposer;
			if (adapterComposer != null)
			{
				adapterComposer.Click -= value2;
			}
			m_AdapterComposer = value;
			adapterComposer = m_AdapterComposer;
			if (adapterComposer != null)
			{
				adapterComposer.Click += value2;
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

	[field: AccessedThroughProperty("Type")]
	internal DataGridViewTextBoxColumn Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public ListActions()
	{
		base.Shown += ResetRole;
		base.KeyDown += MapRole;
		base.FormClosing += SortRole;
		base.Load += FlushRole;
		DefineRole();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ConfigurationComposer != null)
			{
				_ConfigurationComposer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DefineRole()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		CB_ActionType = new DarkUIComboBox();
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
		DataGridView1.RowHeadersVisible = false;
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
		CB_ActionType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_ActionType.BackColor = Color.Transparent;
		CB_ActionType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ActionType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ActionType.Font = new Font("Segoe UI", 7f);
		CB_ActionType.FormattingEnabled = true;
		CB_ActionType.Items.AddRange(new object[6] { "改变分数", "结束想定", "传送到区域", "消息", "修改任务状态", "Lua脚本" });
		CB_ActionType.Location = new Point(115, 370);
		CB_ActionType.Name = "CB_ActionType";
		CB_ActionType.Size = new Size(173, 21);
		CB_ActionType.TabIndex = 15;
		Button_EditSelected.Anchor = AnchorStyles.Bottom;
		Button_EditSelected.BackColor = Color.Transparent;
		Button_EditSelected.DialogResult = DialogResult.None;
		Button_EditSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_EditSelected.ForeColor = SystemColors.Control;
		Button_EditSelected.Location = new Point(437, 370);
		Button_EditSelected.Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		Button_EditSelected.Size = new Size(110, 21);
		Button_EditSelected.TabIndex = 14;
		Button_EditSelected.Text = "编辑选中";
		Button_DeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_DeleteSelected.BackColor = Color.Transparent;
		Button_DeleteSelected.DialogResult = DialogResult.None;
		Button_DeleteSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_DeleteSelected.ForeColor = SystemColors.Control;
		Button_DeleteSelected.Location = new Point(553, 370);
		Button_DeleteSelected.Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		Button_DeleteSelected.Size = new Size(105, 21);
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
		Button1.Text = "创建新动作：";
		Button_CloneSelected.Anchor = AnchorStyles.Bottom;
		Button_CloneSelected.BackColor = Color.Transparent;
		Button_CloneSelected.DialogResult = DialogResult.None;
		Button_CloneSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CloneSelected.ForeColor = SystemColors.Control;
		Button_CloneSelected.Location = new Point(315, 370);
		Button_CloneSelected.Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		Button_CloneSelected.Size = new Size(116, 21);
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
		base.Controls.Add(CB_ActionType);
		base.Controls.Add(Button_EditSelected);
		base.Controls.Add(Button_DeleteSelected);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ListActions";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑动作";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void RefreshGrid()
	{
		try
		{
			_ExceptionComposer = true;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventAction item in Client.CurrentScenario.EventActions.Values.OrderBy((EventAction theAction) => theAction.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["Type"] = item.Type.ToString();
				dataTable.Rows.Add(dataRow);
			}
			DataGridView1.DataSource = dataTable;
			DataGridView1.ResumeLayout();
			_ExceptionComposer = false;
			if (string.IsNullOrEmpty(_RecordComposer))
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
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Cells", new object[1] { "ID" }, null, null, null), null, "Value", new object[0], null, null, null), _RecordComposer, TextCompare: true))
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
			RefreshGrid();
			exception_?.Data.Add("Error at 200380", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PublishRole(object sender, EventArgs e)
	{
		if (CB_ActionType.SelectedIndex <= -1)
		{
			return;
		}
		EventAction theEA;
		switch (CB_ActionType.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			theEA = new EventAction_Points();
			break;
		case 1:
			theEA = new EventAction_EndScenario();
			break;
		case 2:
			theEA = new EventAction_TeleportInArea();
			break;
		case 3:
			theEA = new EventAction_Message();
			break;
		case 4:
			theEA = new EventAction_ChangeMissionStatus();
			break;
		case 5:
			theEA = new EventAction_LuaScript();
			break;
		}
		_SingletonComposer = new EditAction();
		_SingletonComposer.theEA = theEA;
		_SingletonComposer.Action = EditAction._FormAction.AddNew;
		_SingletonComposer.Show();
	}

	private void AwakeRole(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventAction theEA = Client.CurrentScenario.EventActions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			_SingletonComposer = new EditAction();
			_SingletonComposer.theEA = theEA;
			_SingletonComposer.Action = EditAction._FormAction.EditExisting;
			_SingletonComposer.Show();
		}
	}

	private void QueryRole(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		EventAction eventAction = Client.CurrentScenario.EventActions[text];
		if (Information.IsNothing(eventAction))
		{
			return;
		}
		bool flag = false;
		foreach (SimEvent value in Client.CurrentScenario.SimEvents.Values)
		{
			if (value.Actions.Contains(eventAction))
			{
				flag = true;
				break;
			}
		}
		if (flag && DarkMessageBox.ShowWarning("此动作至少正被一个事件使用，您确定要删除它吗？", "动作正被使用中！", DarkDialogButton.YesNo) == DialogResult.No)
		{
			return;
		}
		Client.CurrentScenario.EventActions.Remove(eventAction.ObjectID);
		foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
		{
			value2.Actions.Remove(eventAction);
		}
		RefreshGrid();
	}

	private void ResetRole(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void MapRole(object sender, KeyEventArgs e)
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

	private void SortRole(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CalcRole(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			EventAction eventAction = Client.CurrentScenario.EventActions[text].Clone();
			Client.CurrentScenario.EventActions.Add(eventAction.ObjectID, eventAction);
			RefreshGrid();
		}
	}

	private void RateRole(object sender, EventArgs e)
	{
		if (!_ExceptionComposer && DataGridView1.SelectedRows.Count != 0)
		{
			_RecordComposer = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		}
	}

	private void FlushRole(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void ForgotRole(object sender, DataGridViewCellEventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventAction theEA = Client.CurrentScenario.EventActions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			_SingletonComposer = new EditAction();
			_SingletonComposer.theEA = theEA;
			_SingletonComposer.Action = EditAction._FormAction.EditExisting;
			_SingletonComposer.Show();
		}
	}

	public void ShowEditTrigger(EventAction eventAction_0)
	{
		_SingletonComposer = new EditAction();
		_SingletonComposer.theEA = eventAction_0;
		_SingletonComposer.Action = EditAction._FormAction.EditExisting;
		_SingletonComposer.Show();
	}
}
