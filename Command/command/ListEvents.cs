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
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListEvents : DarkSecondaryFormBase
{
	private IContainer queueComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView m_RegComposer;

	[AccessedThroughProperty("Button_EditSelected")]
	[CompilerGenerated]
	private DarkUIButton _ParamComposer;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton pageComposer;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _RulesComposer;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_MethodComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Description")]
	private DataGridViewTextBoxColumn serviceComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("IsRepeatable")]
	private DataGridViewCheckBoxColumn m_SystemComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CloneSelected")]
	private DarkUIButton policyComposer;

	private EditEvent _BroadcasterComposer;

	private string identifierComposer;

	private bool m_PrinterComposer;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_RegComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelTest;
			DataGridViewCellEventHandler value3 = ListTest;
			DataGridViewCellEventHandler value4 = ResolveTest;
			DarkDataGridView regComposer = m_RegComposer;
			if (regComposer != null)
			{
				regComposer.SelectionChanged -= value2;
				regComposer.CellContentClick -= value3;
				regComposer.CellContentDoubleClick -= value4;
			}
			m_RegComposer = value;
			regComposer = m_RegComposer;
			if (regComposer != null)
			{
				regComposer.SelectionChanged += value2;
				regComposer.CellContentClick += value3;
				regComposer.CellContentDoubleClick += value4;
			}
		}
	}

	internal DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return _ParamComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareTest;
			DarkUIButton paramComposer = _ParamComposer;
			if (paramComposer != null)
			{
				paramComposer.Click -= value2;
			}
			_ParamComposer = value;
			paramComposer = _ParamComposer;
			if (paramComposer != null)
			{
				paramComposer.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return pageComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectTest;
			DarkUIButton darkUIButton = pageComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			pageComposer = value;
			darkUIButton = pageComposer;
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
			return _RulesComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertTest;
			DarkUIButton rulesComposer = _RulesComposer;
			if (rulesComposer != null)
			{
				rulesComposer.Click -= value2;
			}
			_RulesComposer = value;
			rulesComposer = _RulesComposer;
			if (rulesComposer != null)
			{
				rulesComposer.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_MethodComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodComposer = value;
		}
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return serviceComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceComposer = value;
		}
	}

	internal DataGridViewCheckBoxColumn IsRepeatable
	{
		[CompilerGenerated]
		get
		{
			return m_SystemComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemComposer = value;
		}
	}

	[field: AccessedThroughProperty("IsActive")]
	internal DataGridViewCheckBoxColumn IsActive
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Probability")]
	internal DataGridViewTextBoxColumn Probability
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_CloneSelected
	{
		[CompilerGenerated]
		get
		{
			return policyComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopTest;
			DarkUIButton darkUIButton = policyComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			policyComposer = value;
			darkUIButton = policyComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public ListEvents()
	{
		base.Shown += VisitTest;
		base.KeyDown += RestartTest;
		base.FormClosing += TestTest;
		base.Load += VerifyTest;
		UpdateTest();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && queueComposer != null)
			{
				queueComposer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void UpdateTest()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		IsRepeatable = new DataGridViewCheckBoxColumn();
		IsActive = new DataGridViewCheckBoxColumn();
		Probability = new DataGridViewTextBoxColumn();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
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
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridView1.Columns.AddRange(ID, Description, IsRepeatable, IsActive, Probability);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(2, 2);
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
		DataGridView1.Size = new Size(678, 361);
		DataGridView1.TabIndex = 1;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Description.Width = 335;
		IsRepeatable.DataPropertyName = "IsRepeatable";
		IsRepeatable.HeaderText = "可重复";
		IsRepeatable.Name = "IsRepeatable";
		IsRepeatable.ReadOnly = true;
		IsActive.DataPropertyName = "IsActive";
		IsActive.HeaderText = "启用";
		IsActive.Name = "IsActive";
		IsActive.ReadOnly = true;
		Probability.DataPropertyName = "Probability";
		Probability.HeaderText = "概率（％）";
		Probability.Name = "Probability";
		Probability.ReadOnly = true;
		Button_EditSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_EditSelected.BackColor = Color.Transparent;
		Button_EditSelected.DialogResult = DialogResult.None;
		Button_EditSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_EditSelected.ForeColor = SystemColors.Control;
		Button_EditSelected.Location = new Point(432, 369);
		Button_EditSelected.Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		Button_EditSelected.Size = new Size(121, 21);
		Button_EditSelected.TabIndex = 7;
		Button_EditSelected.Text = "编辑选中";
		Button_DeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_DeleteSelected.BackColor = Color.Transparent;
		Button_DeleteSelected.DialogResult = DialogResult.None;
		Button_DeleteSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_DeleteSelected.ForeColor = SystemColors.Control;
		Button_DeleteSelected.Location = new Point(559, 369);
		Button_DeleteSelected.Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		Button_DeleteSelected.Size = new Size(121, 21);
		Button_DeleteSelected.TabIndex = 6;
		Button_DeleteSelected.Text = "删除所选";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(2, 369);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(133, 21);
		Button1.TabIndex = 5;
		Button1.Text = "创建新事件";
		Button_CloneSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_CloneSelected.BackColor = Color.Transparent;
		Button_CloneSelected.DialogResult = DialogResult.None;
		Button_CloneSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CloneSelected.ForeColor = SystemColors.Control;
		Button_CloneSelected.Location = new Point(305, 369);
		Button_CloneSelected.Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		Button_CloneSelected.Size = new Size(121, 21);
		Button_CloneSelected.TabIndex = 8;
		Button_CloneSelected.Text = "克隆已选中";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(682, 392);
		base.Controls.Add(Button_CloneSelected);
		base.Controls.Add(Button_EditSelected);
		base.Controls.Add(Button_DeleteSelected);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ListEvents";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "事件";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void RefreshGrid()
	{
		try
		{
			m_PrinterComposer = true;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Description", typeof(string));
			dataTable.Columns.Add("IsRepeatable", typeof(bool));
			dataTable.Columns.Add("IsActive", typeof(bool));
			dataTable.Columns.Add("IsShown", typeof(bool));
			dataTable.Columns.Add("Probability", typeof(short));
			foreach (SimEvent item in Client.CurrentScenario.SimEvents.Values.OrderBy((SimEvent theEvent) => theEvent.Description))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Description"] = item.Description;
				dataRow["IsRepeatable"] = item.IsRepeatable;
				dataRow["IsActive"] = item.IsActive;
				dataRow["IsShown"] = item.IsShown;
				dataRow["Probability"] = item.Probability;
				dataTable.Rows.Add(dataRow);
			}
			DataGridView1.DataSource = dataTable;
			DataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			DataGridView1.ResumeLayout();
			m_PrinterComposer = false;
			if (string.IsNullOrEmpty(identifierComposer))
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
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Cells", new object[1] { "ID" }, null, null, null), null, "Value", new object[0], null, null, null), identifierComposer, TextCompare: true))
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
			exception_?.Data.Add("Error at 200102", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			RefreshGrid();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InsertTest(object sender, EventArgs e)
	{
		try
		{
			SimEvent theEvent = new SimEvent();
			_BroadcasterComposer = new EditEvent();
			_BroadcasterComposer.theEvent = theEvent;
			_BroadcasterComposer.Action = EditEvent._FormAction.AddNew;
			_BroadcasterComposer.Show();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void PrepareTest(object sender, EventArgs e)
	{
		try
		{
			if (DataGridView1.SelectedRows.Count != 0)
			{
				SimEvent theEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
				_BroadcasterComposer = new EditEvent();
				_BroadcasterComposer.theEvent = theEvent;
				_BroadcasterComposer.Action = EditEvent._FormAction.EditExisting;
				_BroadcasterComposer.Show();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectTest(object sender, EventArgs e)
	{
		try
		{
			if (DataGridView1.SelectedRows.Count != 0)
			{
				SimEvent simEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
				Client.CurrentScenario.SimEvents.Remove(simEvent.ObjectID);
				RefreshGrid();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void VisitTest(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void RestartTest(object sender, KeyEventArgs e)
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

	private void TestTest(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void StopTest(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			SimEvent simEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)].Clone();
			Client.CurrentScenario.SimEvents.Add(simEvent.ObjectID, simEvent);
			RefreshGrid();
		}
	}

	private void CancelTest(object sender, EventArgs e)
	{
		if (!m_PrinterComposer && DataGridView1.SelectedRows.Count != 0)
		{
			identifierComposer = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
		}
	}

	private void VerifyTest(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void ListTest(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1)
			{
				return;
			}
			DataGridViewColumn dataGridViewColumn = DataGridView1.Columns[e.ColumnIndex];
			if ((object)dataGridViewColumn.CellType == typeof(DataGridViewCheckBoxCell))
			{
				DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
				string text = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
				SimEvent simEvent = Client.CurrentScenario.SimEvents[text];
				dataGridViewCheckBoxCell.Value = Operators.NotObject(dataGridViewCheckBoxCell.Value);
				string name = dataGridViewColumn.Name;
				if (Operators.CompareString(name, "IsRepeatable", TextCompare: true) == 0)
				{
					simEvent.IsRepeatable = Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
				}
				else if (Operators.CompareString(name, "IsActive", TextCompare: true) == 0)
				{
					simEvent.IsActive = Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
				}
				else if (Operators.CompareString(name, "IsShown", TextCompare: true) == 0)
				{
					simEvent.IsShown = Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			RefreshGrid();
			ProjectData.ClearProjectError();
		}
	}

	private void ResolveTest(object sender, DataGridViewCellEventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			SimEvent theEvent = Client.CurrentScenario.SimEvents[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			_BroadcasterComposer = new EditEvent();
			_BroadcasterComposer.theEvent = theEvent;
			_BroadcasterComposer.Action = EditEvent._FormAction.EditExisting;
			_BroadcasterComposer.Show();
		}
	}
}
