using System;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SelectLoadout : DarkSecondaryFormBase
{
	private IContainer m_ConnectionSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Loadouts")]
	private DarkDataGridView m_ContextSingleton;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel proccesorSingleton;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_StrategySingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _ConfigurationSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("ComponentID")]
	private DataGridViewTextBoxColumn indexerSingleton;

	[AccessedThroughProperty("Item")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PublisherSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("OptionalWeapon")]
	private DataGridViewTextBoxColumn adapterSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn schemaSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Loadout")]
	private DataGridViewTextBoxColumn utilsSingleton;

	public string AircraftName;

	public int AircraftID;

	public Side AircraftSide;

	private int singletonSingleton;

	private Geopoint_Struct recordSingleton;

	private DataTable _ExceptionSingleton;

	private DataTable m_AttrSingleton;

	internal DarkDataGridView DGV_Loadouts
	{
		[CompilerGenerated]
		get
		{
			return m_ContextSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = DisableInterruptibleServer;
			EventHandler value3 = UpdateInterruptibleServer;
			DarkDataGridView contextSingleton = m_ContextSingleton;
			if (contextSingleton != null)
			{
				contextSingleton.KeyDown -= value2;
				contextSingleton.SelectionChanged -= value3;
			}
			m_ContextSingleton = value;
			contextSingleton = m_ContextSingleton;
			if (contextSingleton != null)
			{
				contextSingleton.KeyDown += value2;
				contextSingleton.SelectionChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("DGV_LoadoutItems")]
	internal DarkDataGridView DGV_LoadoutItems
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return proccesorSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorSingleton = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_StrategySingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleServer;
			DarkUIButton strategySingleton = m_StrategySingleton;
			if (strategySingleton != null)
			{
				strategySingleton.Click -= value2;
			}
			m_StrategySingleton = value;
			strategySingleton = m_StrategySingleton;
			if (strategySingleton != null)
			{
				strategySingleton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ConfigurationSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleServer;
			DarkUIButton configurationSingleton = _ConfigurationSingleton;
			if (configurationSingleton != null)
			{
				configurationSingleton.Click -= value2;
			}
			_ConfigurationSingleton = value;
			configurationSingleton = _ConfigurationSingleton;
			if (configurationSingleton != null)
			{
				configurationSingleton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ComponentID
	{
		[CompilerGenerated]
		get
		{
			return indexerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			indexerSingleton = value;
		}
	}

	[field: AccessedThroughProperty("Quantity")]
	internal DataGridViewTextBoxColumn Quantity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Item
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PublisherSingleton = value;
		}
	}

	[field: AccessedThroughProperty("Internal")]
	internal DataGridViewTextBoxColumn Internal
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn OptionalWeapon
	{
		[CompilerGenerated]
		get
		{
			return adapterSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			adapterSingleton = value;
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return schemaSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			schemaSingleton = value;
		}
	}

	internal DataGridViewTextBoxColumn Loadout
	{
		[CompilerGenerated]
		get
		{
			return utilsSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsSingleton = value;
		}
	}

	[field: AccessedThroughProperty("AttackAltitude")]
	internal DataGridViewTextBoxColumn AttackAltitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public SelectLoadout()
	{
		base.Load += PopInterruptibleServer;
		base.KeyDown += InsertInterruptibleServer;
		base.FormClosing += PrepareInterruptibleServer;
		_ExceptionSingleton = new DataTable();
		m_AttrSingleton = new DataTable();
		CalculateInterruptibleServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ConnectionSingleton != null)
			{
				m_ConnectionSingleton.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateInterruptibleServer()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DGV_Loadouts = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		AttackAltitude = new DataGridViewTextBoxColumn();
		DGV_LoadoutItems = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		ComponentID = new DataGridViewTextBoxColumn();
		Quantity = new DataGridViewTextBoxColumn();
		Item = new DataGridViewTextBoxColumn();
		Internal = new DataGridViewTextBoxColumn();
		OptionalWeapon = new DataGridViewTextBoxColumn();
		Label1 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		((ISupportInitialize)DGV_Loadouts).BeginInit();
		((ISupportInitialize)DGV_LoadoutItems).BeginInit();
		SuspendLayout();
		DGV_Loadouts.AllowUserToAddRows = false;
		DGV_Loadouts.AllowUserToDeleteRows = false;
		DGV_Loadouts.AllowUserToResizeRows = false;
		DGV_Loadouts.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Loadouts.BorderStyle = BorderStyle.Fixed3D;
		DGV_Loadouts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Loadouts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Loadouts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Loadouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Loadouts.Columns.AddRange(ID, Loadout, AttackAltitude);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_Loadouts.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_Loadouts.Dock = DockStyle.Top;
		DGV_Loadouts.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Loadouts.EnableHeadersVisualStyles = false;
		DGV_Loadouts.Location = new Point(0, 0);
		DGV_Loadouts.MultiSelect = false;
		DGV_Loadouts.Name = "DGV_Loadouts";
		DGV_Loadouts.RowHeadersVisible = false;
		DGV_Loadouts.RowHeadersWidth = 10;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_Loadouts.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Loadouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Loadouts.Size = new Size(442, 279);
		DGV_Loadouts.TabIndex = 7;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		Loadout.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Loadout.DataPropertyName = "Name";
		Loadout.HeaderText = "挂载";
		Loadout.Name = "Loadout";
		Loadout.ReadOnly = true;
		AttackAltitude.DataPropertyName = "AttackAltitude";
		AttackAltitude.HeaderText = "攻击高度";
		AttackAltitude.Name = "AttackAltitude";
		AttackAltitude.ReadOnly = true;
		DGV_LoadoutItems.AllowUserToAddRows = false;
		DGV_LoadoutItems.AllowUserToDeleteRows = false;
		DGV_LoadoutItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_LoadoutItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		DGV_LoadoutItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_LoadoutItems.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_LoadoutItems.BorderStyle = BorderStyle.Fixed3D;
		DGV_LoadoutItems.CausesValidation = false;
		DGV_LoadoutItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DGV_LoadoutItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DGV_LoadoutItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DGV_LoadoutItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_LoadoutItems.ColumnHeadersVisible = false;
		DGV_LoadoutItems.Columns.AddRange(DataGridViewTextBoxColumn1, ComponentID, Quantity, Item, Internal, OptionalWeapon);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		DGV_LoadoutItems.DefaultCellStyle = dataGridViewCellStyle5;
		DGV_LoadoutItems.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_LoadoutItems.Enabled = false;
		DGV_LoadoutItems.EnableHeadersVisualStyles = false;
		DGV_LoadoutItems.Location = new Point(3, 302);
		DGV_LoadoutItems.MultiSelect = false;
		DGV_LoadoutItems.Name = "DGV_LoadoutItems";
		DGV_LoadoutItems.RowHeadersVisible = false;
		DGV_LoadoutItems.RowHeadersWidth = 4;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DGV_LoadoutItems.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DGV_LoadoutItems.RowTemplate.Height = 15;
		DGV_LoadoutItems.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_LoadoutItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_LoadoutItems.Size = new Size(439, 115);
		DGV_LoadoutItems.TabIndex = 9;
		DataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.HeaderText = "ID";
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.Visible = false;
		ComponentID.DataPropertyName = "ComponentID";
		ComponentID.HeaderText = "ComponentID";
		ComponentID.Name = "ComponentID";
		ComponentID.Visible = false;
		ComponentID.Width = 5;
		Quantity.DataPropertyName = "Quantity";
		Quantity.HeaderText = "数量";
		Quantity.Name = "Quantity";
		Quantity.Visible = false;
		Quantity.Width = 5;
		Item.DataPropertyName = "Fill";
		Item.HeaderText = "项目";
		Item.Name = "Item";
		Item.Width = 5;
		Internal.DataPropertyName = "Internal";
		Internal.HeaderText = "内部";
		Internal.Name = "Internal";
		Internal.Visible = false;
		Internal.Width = 5;
		OptionalWeapon.DataPropertyName = "Optional";
		OptionalWeapon.HeaderText = "OptionalWeapon";
		OptionalWeapon.Name = "OptionalWeapon";
		OptionalWeapon.Visible = false;
		OptionalWeapon.Width = 5;
		Label1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 286);
		Label1.Name = "Label1";
		Label1.Size = new Size(90, 13);
		Label1.TabIndex = 10;
		Label1.Text = "挂载列表：";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(3, 438);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 11;
		Button1.Text = "确定";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.Cancel;
		Button2.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(367, 438);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 12;
		Button2.Text = "取消";
		base.AcceptButton = Button1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.CancelButton = Button2;
		base.ClientSize = new Size(442, 464);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label1);
		base.Controls.Add(DGV_LoadoutItems);
		base.Controls.Add(DGV_Loadouts);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SelectLoadout";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "选择挂载";
		((ISupportInitialize)DGV_Loadouts).EndInit();
		((ISupportInitialize)DGV_LoadoutItems).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void PopInterruptibleServer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		recordSingleton = ItemExporter.ConnectInterruptibleTemplate.MainForm.mapperCode;
		DGV_Loadouts.AutoGenerateColumns = false;
		int aircraftID = AircraftID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool bool_ = false;
		Scenario scenario_ = null;
		Aircraft aircraft_ = null;
		int int_ = 0;
		bool bool_2 = false;
		_ExceptionSingleton = DBFunctions.LoadoutsForThisAircraft_DT(aircraftID, null, ref sqliteConnection_, currentScenario, ref bool_, ref scenario_, ref aircraft_, ref int_, ref bool_2);
		DGV_Loadouts.DataSource = _ExceptionSingleton;
		DGV_LoadoutItems.DataSource = ReadInterruptibleServer(singletonSingleton);
		singletonSingleton = Conversions.ToInteger(DGV_Loadouts.Rows[0].Cells["ID"].Value);
		if (Client.AddingDecoyPlatform & AddUnit.Unarmed)
		{
			CreateInterruptibleServer();
		}
	}

	private void InstantiateInterruptibleServer(object sender, EventArgs e)
	{
		CreateInterruptibleServer();
	}

	private void CreateInterruptibleServer()
	{
		Aircraft aircraft_ = Client.CurrentScenario.AddNewAircraft(AircraftSide, AircraftName, recordSingleton.Longitude, recordSingleton.Latitude, AircraftID, singletonSingleton, 100f, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, ItemExporter.ConnectInterruptibleTemplate.AddUnit.string_0);
		Aircraft aircraft = aircraft_;
		Aircraft aircraft2 = aircraft_;
		ActiveUnit activeUnit_;
		bool bool_ = aircraft2.GetDesiredAltitude_UseTerrainFollowing(activeUnit_ = aircraft_);
		float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_);
		aircraft2.SetDesiredAltitude_UseTerrainFollowing(activeUnit_, bool_);
		aircraft.DesiredAltitude = desiredAltitude;
		aircraft_.SetCurrentAltitude(bool_1: false, aircraft_.DesiredAltitude);
		short elevation = Terrain.GetElevation(aircraft_.GetLatitude(), aircraft_.GetLongitude(), bool_0: false, Client.CurrentScenario);
		if (aircraft_.DesiredAltitude < (float)(elevation + 1))
		{
			aircraft_.SetCurrentAltitude(bool_1: false, elevation + 1);
		}
		else
		{
			aircraft_.SetCurrentAltitude(bool_1: false, aircraft_.DesiredAltitude);
		}
		if (!Information.IsNothing(aircraft_.Loadout))
		{
			WeaponRec[] weapons = aircraft_.Loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				weapons[i].GetReferenceWeapon(aircraft_.ParentScen).SetCurrentAltitude(bool_0: false, aircraft_.GetCurrentAltitude());
			}
		}
		if (Client.AddingDecoyPlatform & AddUnit.Unarmed)
		{
			aircraft_.Decoy = true;
			aircraft_.Weaponry.Disarm();
		}
		AddUnit.theAddedUnit = aircraft_;
		Client.MustRefreshMainForm = true;
		if (ItemExporter.ConnectInterruptibleTemplate.AddUnit.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AddUnit.Close();
		}
		Close();
	}

	private void CompareInterruptibleServer(object sender, EventArgs e)
	{
		Close();
	}

	private DataTable ReadInterruptibleServer(int int_0)
	{
		int int_ = singletonSingleton;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		bool bool_ = false;
		return DBFunctions.ItemsForThisLoadout(int_, ref sqliteConnection_, ref bool_);
	}

	private void DisableInterruptibleServer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			CreateInterruptibleServer();
		}
	}

	private void UpdateInterruptibleServer(object sender, EventArgs e)
	{
		if (DGV_Loadouts.SelectedRows.Count != 0)
		{
			singletonSingleton = Conversions.ToInteger(DGV_Loadouts.SelectedRows[0].Cells["ID"].Value);
			DGV_LoadoutItems.DataSource = ReadInterruptibleServer(singletonSingleton);
		}
	}

	private void InsertInterruptibleServer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void PrepareInterruptibleServer(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
