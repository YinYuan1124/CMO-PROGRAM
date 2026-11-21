using System;
using System.Collections.Generic;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddWeaponRecord : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class StatusObjectListener
	{
		public AddWeaponRecord Me;

		public DataView Local_DV;

		internal void UpdateInterruptibleParam()
		{
			Me.DataGridView1.DataSource = Local_DV;
			Me.DataGridView1.Refresh();
		}
	}

	private IContainer objectImporter;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _ParameterImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker expressionImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddSelected")]
	private DarkUIButton m_DispatcherImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter1")]
	private DarkCheckBox _ListenerImporter;

	[AccessedThroughProperty("TB_Find")]
	[CompilerGenerated]
	private DarkUITextBox m_ConfigImporter;

	[AccessedThroughProperty("CB_Filter2")]
	[CompilerGenerated]
	private DarkCheckBox registryImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Add10K")]
	private DarkUIButton _DefinitionImporter;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn valImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Description")]
	private DataGridViewTextBoxColumn wrapperImporter;

	private DataTable observerImporter;

	private DataView _IssuerImporter;

	private bool clientImporter;

	public Form FormThatCalledMe;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _ParameterImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = AssetInterpreter;
			DarkDataGridView parameterImporter = _ParameterImporter;
			if (parameterImporter != null)
			{
				parameterImporter.CellDoubleClick -= value2;
			}
			_ParameterImporter = value;
			parameterImporter = _ParameterImporter;
			if (parameterImporter != null)
			{
				parameterImporter.CellDoubleClick += value2;
			}
		}
	}

	internal DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadInterpreter;
			DarkUIButton dispatcherImporter = m_DispatcherImporter;
			if (dispatcherImporter != null)
			{
				dispatcherImporter.Click -= value2;
			}
			m_DispatcherImporter = value;
			dispatcherImporter = m_DispatcherImporter;
			if (dispatcherImporter != null)
			{
				dispatcherImporter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Filter1
	{
		[CompilerGenerated]
		get
		{
			return _ListenerImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterpreter;
			DarkCheckBox listenerImporter = _ListenerImporter;
			if (listenerImporter != null)
			{
				listenerImporter.CheckedChanged -= value2;
			}
			_ListenerImporter = value;
			listenerImporter = _ListenerImporter;
			if (listenerImporter != null)
			{
				listenerImporter.CheckedChanged += value2;
			}
		}
	}

	internal DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = InsertInterpreter;
			EventHandler value3 = ListInterpreter;
			EventHandler value4 = ResolveInterpreter;
			DarkUITextBox configImporter = m_ConfigImporter;
			if (configImporter != null)
			{
				configImporter.TextChanged -= value2;
				configImporter.Enter -= value3;
				configImporter.Leave -= value4;
			}
			m_ConfigImporter = value;
			configImporter = m_ConfigImporter;
			if (configImporter != null)
			{
				configImporter.TextChanged += value2;
				configImporter.Enter += value3;
				configImporter.Leave += value4;
			}
		}
	}

	internal DarkCheckBox CB_Filter2
	{
		[CompilerGenerated]
		get
		{
			return registryImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartInterpreter;
			DarkCheckBox darkCheckBox = registryImporter;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			registryImporter = value;
			darkCheckBox = registryImporter;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIButton Button_Add10K
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterpreter;
			DarkUIButton definitionImporter = _DefinitionImporter;
			if (definitionImporter != null)
			{
				definitionImporter.Click -= value2;
			}
			_DefinitionImporter = value;
			definitionImporter = _DefinitionImporter;
			if (definitionImporter != null)
			{
				definitionImporter.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return valImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valImporter = value;
		}
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return wrapperImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wrapperImporter = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker AwakeInterpreter()
	{
		return expressionImporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void QueryInterpreter(BackgroundWorker backgroundWorker_0)
	{
		expressionImporter = backgroundWorker_0;
	}

	public AddWeaponRecord()
	{
		base.Shown += CancelInterpreter;
		base.KeyDown += VerifyInterpreter;
		base.FormClosing += PostInterpreter;
		base.Load += StartInterpreter;
		CompareInterpreter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && objectImporter != null)
			{
				objectImporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CompareInterpreter()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		QueryInterpreter(new BackgroundWorker());
		Button_AddSelected = new DarkUIButton();
		CB_Filter1 = new DarkCheckBox();
		TB_Find = new DarkUITextBox();
		CB_Filter2 = new DarkCheckBox();
		Button_Add10K = new DarkUIButton();
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
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
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
		TB_Find.SelectionStart = 0;
		TB_Find.Size = new Size(187, 20);
		TB_Find.TabIndex = 12;
		TB_Find.TextAlign = HorizontalAlignment.Left;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "";
		CB_Filter2.Location = new Point(7, 70);
		CB_Filter2.Name = "CB_Filter2";
		CB_Filter2.Size = new Size(340, 17);
		CB_Filter2.TabIndex = 14;
		CB_Filter2.Text = "仅显示与托管飞机兼容的武器";
		Button_Add10K.BackColor = Color.Transparent;
		Button_Add10K.DialogResult = DialogResult.None;
		Button_Add10K.Font = new Font("Segoe UI", 10f);
		Button_Add10K.ForeColor = SystemColors.Control;
		Button_Add10K.Location = new Point(121, 12);
		Button_Add10K.Name = "Button_Add10K";
		Button_Add10K.RoundRadius = 0;
		Button_Add10K.Size = new Size(198, 23);
		Button_Add10K.TabIndex = 15;
		Button_Add10K.Text = "添加所选的“10000”版本";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(331, 506);
		base.Controls.Add(Button_Add10K);
		base.Controls.Add(CB_Filter2);
		base.Controls.Add(CB_Filter1);
		base.Controls.Add(TB_Find);
		base.Controls.Add(Button_AddSelected);
		base.Controls.Add(DataGridView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddWeaponRecord";
		base.ShowIcon = false;
		Text = "添加武器记录";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ReadInterpreter(object sender, EventArgs e)
	{
		DisableInterpreter();
	}

	private void DisableInterpreter()
	{
		if (FormThatCalledMe == Client.theWeaponsWindow)
		{
			WeaponRec weaponRec = DBFunctions.GetWeaponRec(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value), Client.CurrentScenario);
			Client.theWeaponsWindow.AddWeaponRec(weaponRec);
		}
		if (FormThatCalledMe == Client.theMagazinesWindow)
		{
			WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value), Client.theMagazinesWindow.SelectedUnit.ParentScen);
			Client.theMagazinesWindow.SelectedMag.Weapons.Add(weaponRec2);
		}
	}

	private void UpdateInterpreter()
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		observerImporter = DBFunctions.GetAllWeaponRecs_Preformatted(ref sqliteConnection_);
	}

	private void InsertInterpreter(object object_0)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			PrepareInterpreter();
		}
	}

	private void PrepareInterpreter()
	{
		DataView dataView = new DataView(observerImporter);
		dataView.Sort = "Description ASC";
		dataView.RowFilter = "Description LIKE '%" + Misc.PatchValue(TB_Find.Text) + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void ReflectInterpreter(object sender, EventArgs e)
	{
		if (CB_Filter1.Checked)
		{
			CB_Filter2.Checked = false;
		}
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			PrepareInterpreter();
		}
		else
		{
			VisitInterpreter();
		}
	}

	private void VisitInterpreter()
	{
		if (observerImporter == null)
		{
			UpdateInterpreter();
		}
		Invoke((VB_0024AnonymousDelegate_0)delegate
		{
			_IssuerImporter = new DataView(observerImporter);
			_IssuerImporter.Sort = "Description ASC";
			DataGridView1.DataSource = _IssuerImporter;
		});
	}

	private void RestartInterpreter(object sender, EventArgs e)
	{
		if (CB_Filter2.Checked)
		{
			CB_Filter1.Checked = false;
			TestInterpreter();
		}
		else
		{
			VisitInterpreter();
		}
	}

	private void TestInterpreter()
	{
		if (observerImporter == null)
		{
			UpdateInterpreter();
		}
		List<int> list = new List<int>();
		foreach (Aircraft item in StopInterpreter())
		{
			int dBID = item.DBID;
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			foreach (int item2 in DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_))
			{
				if (!list.Contains(item2))
				{
					list.Add(item2);
				}
			}
		}
		DataView Local_DV = new DataView(observerImporter);
		Local_DV.Sort = "Description ASC";
		if (list.Count <= 0)
		{
			Local_DV.RowFilter = "1=2";
		}
		else
		{
			string text = "(";
			foreach (int item3 in list)
			{
				text = text + Conversions.ToString(item3) + ",";
			}
			text += ")";
			Local_DV.RowFilter = "ComponentID IN " + text;
		}
		Invoke((VB_0024AnonymousDelegate_0)delegate
		{
			DataGridView1.DataSource = Local_DV;
			DataGridView1.Refresh();
		});
	}

	private List<Aircraft> StopInterpreter()
	{
		if (FormThatCalledMe == Client.theMagazinesWindow)
		{
			ActiveUnit parentPlatform = Client.theMagazinesWindow.SelectedMag.ParentPlatform;
			if (parentPlatform.IsGroupMember())
			{
				if (parentPlatform.GetParentGroup().IsLandInstallation)
				{
					return parentPlatform.GetParentGroup().AirOps.EmbarkedAircraft_ReadOnly;
				}
				return parentPlatform.AirOps.EmbarkedAircraft_ReadOnly;
			}
			return parentPlatform.AirOps.EmbarkedAircraft_ReadOnly;
		}
		return null;
	}

	private void CancelInterpreter(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.theMagazinesWindow))
		{
			CB_Filter2.Visible = false;
		}
		else if (FormThatCalledMe == Client.theMagazinesWindow)
		{
			List<Aircraft> list = StopInterpreter();
			CB_Filter2.Visible = !Information.IsNothing(list) && list.Count > 0;
		}
		else
		{
			CB_Filter2.Visible = false;
		}
		if (CB_Filter2.Visible)
		{
			CB_Filter2.Checked = true;
			Task.Factory.StartNew(TestInterpreter);
		}
		else
		{
			Task.Factory.StartNew(VisitInterpreter);
		}
	}

	private void VerifyInterpreter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (clientImporter)
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
		if (!clientImporter && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ListInterpreter(object sender, EventArgs e)
	{
		clientImporter = true;
	}

	private void ResolveInterpreter(object sender, EventArgs e)
	{
		clientImporter = false;
		CB_Filter1.Select();
	}

	private void PostInterpreter(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void RunInterpreter(object sender, EventArgs e)
	{
		if (FormThatCalledMe == Client.theWeaponsWindow)
		{
			WeaponRec weaponRec = DBFunctions.GetWeaponRec(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value), Client.CurrentScenario);
			weaponRec.WRecDBID = null;
			weaponRec.CurrentLoad = 10000;
			weaponRec.MaxLoad = 10000;
			Client.theWeaponsWindow.AddWeaponRec(weaponRec);
		}
		if (FormThatCalledMe == Client.theMagazinesWindow)
		{
			WeaponRec weaponRec2 = DBFunctions.GetWeaponRec(Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value), Client.theMagazinesWindow.SelectedUnit.ParentScen);
			weaponRec2.WRecDBID = null;
			weaponRec2.MaxLoad = 10000;
			Client.theMagazinesWindow.SelectedMag.Weapons.Add(weaponRec2);
		}
	}

	private void StartInterpreter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		DataGridView1.AutoGenerateColumns = false;
	}

	private void AssetInterpreter(object sender, DataGridViewCellEventArgs e)
	{
		DisableInterpreter();
	}

	[CompilerGenerated]
	private void PrintInterpreter()
	{
		_IssuerImporter = new DataView(observerImporter);
		_IssuerImporter.Sort = "Description ASC";
		DataGridView1.DataSource = _IssuerImporter;
	}
}
