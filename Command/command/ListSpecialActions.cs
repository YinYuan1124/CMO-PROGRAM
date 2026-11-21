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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ListSpecialActions : DarkSecondaryFormBase
{
	private IContainer parserComposer;

	[AccessedThroughProperty("Button_EditSelected")]
	[CompilerGenerated]
	private DarkUIButton algoComposer;

	[AccessedThroughProperty("Button_DeleteSelected")]
	[CompilerGenerated]
	private DarkUIButton databaseComposer;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton interceptorComposer;

	[AccessedThroughProperty("Button_CloneSelected")]
	[CompilerGenerated]
	private DarkUIButton _MessageComposer;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn productComposer;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView roleComposer;

	[AccessedThroughProperty("Label_ActionDescription")]
	[CompilerGenerated]
	private DarkLabel factoryComposer;

	private EditSpecialAction m_AttributeComposer;

	private string _EventComposer;

	private bool m_GlobalComposer;

	internal DarkUIButton Button_EditSelected
	{
		[CompilerGenerated]
		get
		{
			return algoComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeFactory;
			DarkUIButton darkUIButton = algoComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			algoComposer = value;
			darkUIButton = algoComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteSelected
	{
		[CompilerGenerated]
		get
		{
			return databaseComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneFactory;
			DarkUIButton darkUIButton = databaseComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			databaseComposer = value;
			darkUIButton = databaseComposer;
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
			return interceptorComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountFactory;
			DarkUIButton darkUIButton = interceptorComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			interceptorComposer = value;
			darkUIButton = interceptorComposer;
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
			return _MessageComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddFactory;
			DarkUIButton messageComposer = _MessageComposer;
			if (messageComposer != null)
			{
				messageComposer.Click -= value2;
			}
			_MessageComposer = value;
			messageComposer = _MessageComposer;
			if (messageComposer != null)
			{
				messageComposer.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return productComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productComposer = value;
		}
	}

	[field: AccessedThroughProperty("ActionName")]
	internal DataGridViewTextBoxColumn ActionName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("IsActive")]
	internal DataGridViewCheckBoxColumn IsActive
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("IsRepeatable")]
	internal DataGridViewCheckBoxColumn IsRepeatable
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return roleComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyFactory;
			DataGridViewCellEventHandler value3 = ComputeFactory;
			DataGridViewCellEventHandler value4 = SelectFactory;
			DarkDataGridView darkDataGridView = roleComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
				darkDataGridView.CellClick -= value3;
				darkDataGridView.CellDoubleClick -= value4;
			}
			roleComposer = value;
			darkDataGridView = roleComposer;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
				darkDataGridView.CellClick += value3;
				darkDataGridView.CellDoubleClick += value4;
			}
		}
	}

	internal DarkLabel Label_ActionDescription
	{
		[CompilerGenerated]
		get
		{
			return factoryComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			factoryComposer = value;
		}
	}

	public ListSpecialActions()
	{
		base.Shown += ConnectFactory;
		base.KeyDown += MoveFactory;
		base.FormClosing += DeleteFactory;
		base.Load += PatchFactory;
		RevertTest();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && parserComposer != null)
			{
				parserComposer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RevertTest()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ActionName = new DataGridViewTextBoxColumn();
		IsActive = new DataGridViewCheckBoxColumn();
		IsRepeatable = new DataGridViewCheckBoxColumn();
		Button_EditSelected = new DarkUIButton();
		Button_DeleteSelected = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button_CloneSelected = new DarkUIButton();
		Label_ActionDescription = new DarkLabel();
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
		DataGridView1.Columns.AddRange(ID, ActionName, IsActive, IsRepeatable);
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
		DataGridView1.Size = new Size(496, 365);
		DataGridView1.TabIndex = 3;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		ActionName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ActionName.DataPropertyName = "Name";
		ActionName.HeaderText = "名称";
		ActionName.Name = "ActionName";
		ActionName.ReadOnly = true;
		IsActive.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		IsActive.DataPropertyName = "IsActive";
		IsActive.HeaderText = "启用";
		IsActive.Name = "IsActive";
		IsActive.ReadOnly = true;
		IsActive.Width = 52;
		IsRepeatable.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		IsRepeatable.DataPropertyName = "IsRepeatable";
		IsRepeatable.HeaderText = "可重复";
		IsRepeatable.Name = "IsRepeatable";
		IsRepeatable.ReadOnly = true;
		IsRepeatable.Width = 77;
		Button_EditSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_EditSelected.BackColor = Color.Transparent;
		Button_EditSelected.DialogResult = DialogResult.None;
		Button_EditSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_EditSelected.ForeColor = SystemColors.Control;
		Button_EditSelected.Location = new Point(276, 373);
		Button_EditSelected.Name = "Button_EditSelected";
		Button_EditSelected.RoundRadius = 0;
		Button_EditSelected.Size = new Size(110, 21);
		Button_EditSelected.TabIndex = 14;
		Button_EditSelected.Text = "编辑选中";
		Button_DeleteSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_DeleteSelected.BackColor = Color.Transparent;
		Button_DeleteSelected.DialogResult = DialogResult.None;
		Button_DeleteSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_DeleteSelected.ForeColor = SystemColors.Control;
		Button_DeleteSelected.Location = new Point(392, 373);
		Button_DeleteSelected.Name = "Button_DeleteSelected";
		Button_DeleteSelected.RoundRadius = 0;
		Button_DeleteSelected.Size = new Size(105, 21);
		Button_DeleteSelected.TabIndex = 13;
		Button_DeleteSelected.Text = "删除所选";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(3, 373);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(145, 21);
		Button1.TabIndex = 12;
		Button1.Text = "创建新的特殊动作";
		Button_CloneSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_CloneSelected.BackColor = Color.Transparent;
		Button_CloneSelected.DialogResult = DialogResult.None;
		Button_CloneSelected.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CloneSelected.ForeColor = SystemColors.Control;
		Button_CloneSelected.Location = new Point(154, 373);
		Button_CloneSelected.Name = "Button_CloneSelected";
		Button_CloneSelected.RoundRadius = 0;
		Button_CloneSelected.Size = new Size(116, 21);
		Button_CloneSelected.TabIndex = 16;
		Button_CloneSelected.Text = "克隆已选中";
		Label_ActionDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label_ActionDescription.AutoSize = true;
		Label_ActionDescription.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ActionDescription.Location = new Point(505, 3);
		Label_ActionDescription.MaximumSize = new Size(185, 0);
		Label_ActionDescription.Name = "Label_ActionDescription";
		Label_ActionDescription.Size = new Size(39, 13);
		Label_ActionDescription.TabIndex = 17;
		Label_ActionDescription.Text = "Label1";
		Label_ActionDescription.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(693, 397);
		base.Controls.Add(Label_ActionDescription);
		base.Controls.Add(Button_CloneSelected);
		base.Controls.Add(Button_EditSelected);
		base.Controls.Add(Button_DeleteSelected);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ListSpecialActions";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "此分方的特殊动作";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void RefreshGrid()
	{
		if (Client.CurrentSide == null)
		{
			return;
		}
		try
		{
			m_GlobalComposer = true;
			DataGridView1.SuspendLayout();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(string));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("IsActive", typeof(string));
			dataTable.Columns.Add("IsRepeatable", typeof(string));
			foreach (SpecialAction item in Client.CurrentSide.SpecialActions.Values.OrderBy((SpecialAction theAction) => theAction.Name))
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["ID"] = item.ObjectID;
				dataRow["Name"] = item.Name;
				dataRow["IsActive"] = item.IsActive;
				dataRow["IsRepeatable"] = item.IsRepeatable;
				dataTable.Rows.Add(dataRow);
			}
			DataGridView1.DataSource = dataTable;
			DataGridView1.ResumeLayout();
			m_GlobalComposer = false;
			if (string.IsNullOrEmpty(_EventComposer))
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
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Cells", new object[1] { "ID" }, null, null, null), null, "Value", new object[0], null, null, null), _EventComposer, TextCompare: true))
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
			exception_?.Data.Add("Error at 200381", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CountFactory(object sender, EventArgs e)
	{
		SpecialAction theSA = new SpecialAction();
		m_AttributeComposer = new EditSpecialAction();
		m_AttributeComposer.theSA = theSA;
		m_AttributeComposer.Action = EditSpecialAction._FormAction.AddNew;
		m_AttributeComposer.Show();
	}

	private void CustomizeFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			SpecialAction theSA = Client.CurrentSide.SpecialActions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			m_AttributeComposer = new EditSpecialAction();
			m_AttributeComposer.theSA = theSA;
			m_AttributeComposer.Action = EditSpecialAction._FormAction.EditExisting;
			m_AttributeComposer.Show();
		}
	}

	private void CloneFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string key = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
			if (!Information.IsNothing(specialAction))
			{
				Client.CurrentSide.SpecialActions.Remove(specialAction.ObjectID);
				RefreshGrid();
			}
		}
	}

	private void ConnectFactory(object sender, EventArgs e)
	{
		RefreshGrid();
	}

	private void MoveFactory(object sender, KeyEventArgs e)
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

	private void DeleteFactory(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void AddFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string key = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key].Clone();
			Client.CurrentSide.SpecialActions.Add(specialAction.ObjectID, specialAction);
			RefreshGrid();
		}
	}

	private void DestroyFactory(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			Label_ActionDescription.Visible = false;
			return;
		}
		Label_ActionDescription.Visible = true;
		if (DataGridView1.SelectedRows.Count != 0)
		{
			string key = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
			Label_ActionDescription.Text = specialAction.Description;
			if (!m_GlobalComposer)
			{
				_EventComposer = Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value);
			}
		}
	}

	private void ComputeFactory(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1)
		{
			return;
		}
		DataGridViewColumn dataGridViewColumn = DataGridView1.Columns[e.ColumnIndex];
		if ((Operators.CompareString(dataGridViewColumn.Name, "IsActive", TextCompare: true) == 0) | (Operators.CompareString(dataGridViewColumn.Name, "IsRepeatable", TextCompare: true) == 0))
		{
			DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)DataGridView1[e.ColumnIndex, e.RowIndex];
			string key = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
			SpecialAction specialAction = Client.CurrentSide.SpecialActions[key];
			dataGridViewCheckBoxCell.Value = !Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
			if (Operators.CompareString(dataGridViewColumn.Name, "IsActive", TextCompare: true) == 0)
			{
				specialAction.IsActive = Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
			}
			else if (Operators.CompareString(dataGridViewColumn.Name, "IsRepeatable", TextCompare: true) == 0)
			{
				specialAction.IsRepeatable = Conversions.ToBoolean(dataGridViewCheckBoxCell.Value);
			}
		}
	}

	private void PatchFactory(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void SelectFactory(object sender, DataGridViewCellEventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			SpecialAction theSA = Client.CurrentSide.SpecialActions[Conversions.ToString(DataGridView1.SelectedRows[0].Cells["ID"].Value)];
			m_AttributeComposer = new EditSpecialAction();
			m_AttributeComposer.theSA = theSA;
			m_AttributeComposer.Action = EditSpecialAction._FormAction.EditExisting;
			m_AttributeComposer.Show();
		}
	}
}
