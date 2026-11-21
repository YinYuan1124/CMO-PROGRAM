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
public sealed class ListTriggers : DarkSecondaryFormBase
{
	private IContainer m_WorkerComposer;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _AccountComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSelected")]
	private DarkUIButton _StateComposer;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton _AuthenticationComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton paramsComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TriggerType")]
	private DarkUIComboBox infoComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton helperComposer;

	[AccessedThroughProperty("Description")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn managerComposer;

	[AccessedThroughProperty("Type")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn getterComposer;

	private EditTrigger _ProducerComposer;

	private string _ProcComposer;

	private bool _StructModel;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _AccountComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareFactory;
			DataGridViewCellEventHandler value3 = DisableFactory;
			DarkDataGridView accountComposer = _AccountComposer;
			if (accountComposer != null)
			{
				accountComposer.SelectionChanged -= value2;
				accountComposer.CellDoubleClick -= value3;
			}
			_AccountComposer = value;
			accountComposer = _AccountComposer;
			if (accountComposer != null)
			{
				accountComposer.SelectionChanged += value2;
				accountComposer.CellDoubleClick += value3;
			}
		}
	}

	internal DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return _StateComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetFactory;
			DarkUIButton stateComposer = _StateComposer;
			if (stateComposer != null)
			{
				stateComposer.Click -= value2;
			}
			_StateComposer = value;
			stateComposer = _StateComposer;
			if (stateComposer != null)
			{
				stateComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillFactory;
			DarkUIButton authenticationComposer = _AuthenticationComposer;
			if (authenticationComposer != null)
			{
				authenticationComposer.Click -= value2;
			}
			_AuthenticationComposer = value;
			authenticationComposer = _AuthenticationComposer;
			if (authenticationComposer != null)
			{
				authenticationComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return paramsComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindFactory;
			DarkUIButton darkUIButton = paramsComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			paramsComposer = value;
			darkUIButton = paramsComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_TriggerType
	{
		[CompilerGenerated]
		get
		{
			return infoComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			infoComposer = value;
		}
	}

	internal DarkUIButton Button_CloneSelected
	{
		[CompilerGenerated]
		get
		{
			return helperComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateFactory;
			DarkUIButton darkUIButton = helperComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			helperComposer = value;
			darkUIButton = helperComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return managerComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerComposer = value;
		}
	}

	internal DataGridViewTextBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return getterComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterComposer = value;
		}
	}

	public ListTriggers()
	{
		base.Shown += CalculateFactory;
		base.KeyDown += PopFactory;
		base.FormClosing += InstantiateFactory;
		base.Load += ReadFactory;
		RemoveFactory();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_WorkerComposer != null)
			{
				m_WorkerComposer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RemoveFactory()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		CB_TriggerType = new DarkUIComboBox();
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
		DataGridView1.TabIndex = 2;
		Button_EditSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_EditSelected.BackColor = Color.Transparent;
		Button_EditSelected.DialogResult = DialogResult.None;
		Button_EditSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_EditSelected.ForeColor = SystemColors.Control;
		Button_EditSelected.Location = new Point(455, 370);
		Button_EditSelected.Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		Button_EditSelected.Size = new Size(98, 21);
		Button_EditSelected.TabIndex = 10;
		Button_EditSelected.Text = "编辑选中";
		Button_DeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_DeleteSelected.BackColor = Color.Transparent;
		Button_DeleteSelected.DialogResult = DialogResult.None;
		Button_DeleteSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_DeleteSelected.ForeColor = SystemColors.Control;
		Button_DeleteSelected.Location = new Point(559, 370);
		Button_DeleteSelected.Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		Button_DeleteSelected.Size = new Size(99, 21);
		Button_DeleteSelected.TabIndex = 9;
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
		Button1.TabIndex = 8;
		Button1.Text = "创建新触发器：";
		CB_TriggerType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_TriggerType.BackColor = Color.Transparent;
		CB_TriggerType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TriggerType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TriggerType.Font = new Font("Segoe UI", 7f);
		CB_TriggerType.FormattingEnabled = true;
		CB_TriggerType.Items.AddRange(new object[12]
		{
			"单元被摧毁", "单元被毁伤", "分方分数", "时间", "单元停留在区域内", "单元进入区域", "随机时间", "单元被探测", "想定被加载", "延迟一段时间",
			"想定结束", "Base Ops Status"
		});
		CB_TriggerType.Location = new Point(115, 370);
		CB_TriggerType.Name = "CB_TriggerType";
		CB_TriggerType.Size = new Size(173, 21);
		CB_TriggerType.TabIndex = 11;
		Button_CloneSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_CloneSelected.BackColor = Color.Transparent;
		Button_CloneSelected.DialogResult = DialogResult.None;
		Button_CloneSelected.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CloneSelected.ForeColor = SystemColors.Control;
		Button_CloneSelected.Location = new Point(342, 370);
		Button_CloneSelected.Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		Button_CloneSelected.Size = new Size(107, 21);
		Button_CloneSelected.TabIndex = 12;
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
		base.Controls.Add(CB_TriggerType);
		base.Controls.Add(Button_EditSelected);
		base.Controls.Add(Button_DeleteSelected);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ListTriggers";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "事件触发器";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void RefreshGrid()
	{
		try
		{
			_StructModel = true;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("Type", typeof(string));
			foreach (EventTrigger item in Client.CurrentScenario.EventTriggers.Values.OrderBy((EventTrigger theTrigger) => theTrigger.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["Type"] = item.Type.ToString();
				dataTable.Rows.Add(dataRow);
			}
			DataGridView1.DataSource = dataTable;
			DataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			DataGridView1.ResumeLayout();
			_StructModel = false;
			if (string.IsNullOrEmpty(_ProcComposer))
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
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Cells", new object[1] { "ID" }, null, null, null), null, "Value", new object[0], null, null, null), _ProcComposer, TextCompare: true))
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
			exception_?.Data.Add("Error at 200382", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FindFactory(object sender, EventArgs e)
	{
		if (CB_TriggerType.SelectedIndex <= -1)
		{
			return;
		}
		EventTrigger eventTrigger = null;
		switch (CB_TriggerType.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return;
		case 0:
			eventTrigger = new EventTrigger_UnitDestroyed();
			break;
		case 1:
			eventTrigger = new EventTrigger_UnitDamaged();
			break;
		case 2:
			eventTrigger = new EventTrigger_Points();
			break;
		case 3:
			eventTrigger = new EventTrigger_Time(Client.CurrentScenario.Time.AddMinutes(30.0));
			break;
		case 4:
			eventTrigger = new EventTrigger_UnitRemainsInArea();
			break;
		case 5:
			eventTrigger = new EventTrigger_UnitEntersArea();
			((EventTrigger_UnitEntersArea)eventTrigger).dateTime_0 = Client.CurrentScenario.Time;
			((EventTrigger_UnitEntersArea)eventTrigger).dateTime_1 = ((EventTrigger_UnitEntersArea)eventTrigger).dateTime_0.AddYears(1);
			break;
		case 6:
			eventTrigger = new EventTrigger_RandomTime(Client.CurrentScenario.Time.AddMinutes(30.0), Client.CurrentScenario.Time.AddMinutes(120.0));
			break;
		case 7:
			eventTrigger = new EventTrigger_UnitDetected();
			break;
		case 8:
			eventTrigger = new EventTrigger_ScenLoaded();
			break;
		case 9:
			eventTrigger = new EventTrigger_RegularTime();
			break;
		case 10:
			if (Client.CurrentScenario.IsRunningInCampaignMode)
			{
				eventTrigger = new EventTrigger_ScenLoaded();
			}
			break;
		case 11:
			eventTrigger = new EventTrigger_UnitBaseStatus();
			break;
		case 12:
			eventTrigger = new EventTrigger_UnitEmissions();
			break;
		case 13:
			eventTrigger = new EventTrigger_UnitCargoMoved();
			break;
		}
		if (CB_TriggerType.SelectedIndex == 8)
		{
			EventTrigger_ScenLoaded eventTrigger_ScenLoaded = new EventTrigger_ScenLoaded();
			eventTrigger_ScenLoaded.Description = "想定被加载";
			Client.CurrentScenario.EventTriggers.Add(eventTrigger_ScenLoaded.ObjectID, eventTrigger_ScenLoaded);
			RefreshGrid();
		}
		else if (CB_TriggerType.SelectedIndex == 10)
		{
			EventTrigger_ScenEnded eventTrigger_ScenEnded = new EventTrigger_ScenEnded();
			eventTrigger_ScenEnded.Description = "Campaign/Scenario has Ended";
			Client.CurrentScenario.EventTriggers.Add(eventTrigger_ScenEnded.ObjectID, eventTrigger_ScenEnded);
			RefreshGrid();
		}
		else
		{
			_ProducerComposer = new EditTrigger();
			_ProducerComposer.theTrigger = eventTrigger;
			_ProducerComposer.Action = EditTrigger._FormAction.AddNew;
			_ProducerComposer.Show();
		}
	}

	private void SetFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventTrigger theTrigger = Client.CurrentScenario.EventTriggers[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			_ProducerComposer = new EditTrigger();
			_ProducerComposer.theTrigger = theTrigger;
			_ProducerComposer.Action = EditTrigger._FormAction.EditExisting;
			_ProducerComposer.Show();
		}
	}

	private void FillFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		EventTrigger eventTrigger = Client.CurrentScenario.EventTriggers[text];
		if (Information.IsNothing(eventTrigger))
		{
			return;
		}
		bool flag = false;
		foreach (SimEvent value in Client.CurrentScenario.SimEvents.Values)
		{
			if (value.Triggers.Contains(eventTrigger))
			{
				flag = true;
				break;
			}
		}
		if (flag && DarkMessageBox.ShowWarning("此触发器至少由一个事件使用，您确定要删除它吗？", "触发器正在使用中！", DarkDialogButton.YesNo) == DialogResult.No)
		{
			return;
		}
		Client.CurrentScenario.EventTriggers.Remove(eventTrigger.ObjectID);
		foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
		{
			value2.Triggers.Remove(eventTrigger);
		}
		RefreshGrid();
	}

	private void CalculateFactory(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void PopFactory(object sender, KeyEventArgs e)
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

	private void InstantiateFactory(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CreateFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			EventTrigger eventTrigger = Client.CurrentScenario.EventTriggers[text].Clone();
			Client.CurrentScenario.EventTriggers.Add(eventTrigger.ObjectID, eventTrigger);
			RefreshGrid();
		}
	}

	private void CompareFactory(object sender, EventArgs e)
	{
		if (!_StructModel && DataGridView1.SelectedRows.Count != 0)
		{
			_ProcComposer = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		}
	}

	private void ReadFactory(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void DisableFactory(object sender, DataGridViewCellEventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			EventTrigger theTrigger = Client.CurrentScenario.EventTriggers[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			_ProducerComposer = new EditTrigger();
			_ProducerComposer.theTrigger = theTrigger;
			_ProducerComposer.Action = EditTrigger._FormAction.EditExisting;
			_ProducerComposer.Show();
		}
	}

	public void ShowEditTrigger(EventTrigger eventTrigger_0)
	{
		_ProducerComposer = new EditTrigger();
		_ProducerComposer.theTrigger = eventTrigger_0;
		_ProducerComposer.Action = EditTrigger._FormAction.EditExisting;
		_ProducerComposer.Show();
	}
}
