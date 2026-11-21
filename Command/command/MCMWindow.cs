using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MCMWindow : DarkSecondaryFormBase
{
	private IContainer _IdentifierConnection;

	[AccessedThroughProperty("DGV_Sensors")]
	[CompilerGenerated]
	private DarkDataGridView _PrinterConnection;

	[AccessedThroughProperty("SensorType")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_AlgoConnection;

	private DataTable _DatabaseConnection;

	internal DarkDataGridView DGV_Sensors
	{
		[CompilerGenerated]
		get
		{
			return _PrinterConnection;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = PublishInterruptibleConfig;
			DataGridViewCellEventHandler value3 = AwakeInterruptibleConfig;
			DarkDataGridView printerConnection = _PrinterConnection;
			if (printerConnection != null)
			{
				printerConnection.CellClick -= value2;
				printerConnection.CellContentClick -= value3;
			}
			_PrinterConnection = value;
			printerConnection = _PrinterConnection;
			if (printerConnection != null)
			{
				printerConnection.CellClick += value2;
				printerConnection.CellContentClick += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Sensor")]
	internal DataGridViewTextBoxColumn Sensor
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn SensorType
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoConnection;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AlgoConnection = value;
		}
	}

	public MCMWindow()
	{
		base.Load += PrintInterruptibleConfig;
		base.KeyDown += QueryInterruptibleConfig;
		base.FormClosing += ResetInterruptibleConfig;
		_DatabaseConnection = new DataTable();
		AssetInterruptibleConfig();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _IdentifierConnection != null)
			{
				_IdentifierConnection.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AssetInterruptibleConfig()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DGV_Sensors = new DarkDataGridView();
		Sensor = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		((ISupportInitialize)DGV_Sensors).BeginInit();
		SuspendLayout();
		DGV_Sensors.AllowUserToAddRows = false;
		DGV_Sensors.AllowUserToDeleteRows = false;
		DGV_Sensors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		DGV_Sensors.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_Sensors.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Sensors.BorderStyle = BorderStyle.Fixed3D;
		DGV_Sensors.CausesValidation = false;
		DGV_Sensors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Sensors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Sensors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Sensors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Sensors.Columns.AddRange(Sensor, SensorType);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.LightGray;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_Sensors.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_Sensors.Dock = DockStyle.Fill;
		DGV_Sensors.EnableHeadersVisualStyles = false;
		DGV_Sensors.Location = new Point(0, 0);
		DGV_Sensors.MultiSelect = false;
		DGV_Sensors.Name = "DGV_Sensors";
		DGV_Sensors.RowHeadersVisible = false;
		DGV_Sensors.RowHeadersWidth = 4;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_Sensors.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Sensors.RowTemplate.Height = 20;
		DGV_Sensors.ScrollBars = ScrollBars.Vertical;
		DGV_Sensors.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_Sensors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Sensors.Size = new Size(523, 205);
		DGV_Sensors.TabIndex = 9;
		Sensor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Sensor.DataPropertyName = "Sensor";
		Sensor.HeaderText = "传感器";
		Sensor.Name = "Sensor";
		SensorType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SensorType.DataPropertyName = "SensorType";
		SensorType.HeaderText = "传感器类型";
		SensorType.Name = "SensorType";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		AutoSize = true;
		base.ClientSize = new Size(523, 205);
		base.Controls.Add(DGV_Sensors);
		DoubleBuffered = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "MCMWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "反雷措施MCM";
		((ISupportInitialize)DGV_Sensors).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PrintInterruptibleConfig(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Text = "MCM和Podded设备";
		BuildForm_Detailed();
	}

	public void BuildForm_Detailed()
	{
		DefineInterruptibleConfig();
		DGV_Sensors.DataSource = _DatabaseConnection;
		DGV_Sensors.Columns["CanBeActive"].Visible = false;
		DGV_Sensors.Columns["Order#"].Visible = false;
		IEnumerator enumerator = null;
		try
		{
			enumerator = ((IEnumerable)DGV_Sensors.Rows).GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (!((ActiveUnit)Client.SelectedUnit).MineCountermeasures[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)].CanBeActive)
				{
					dataGridViewRow.ReadOnly = true;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = DGV_Sensors.Columns.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_ = (DataGridViewColumn)enumerator2.Current;
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

	private void DefineInterruptibleConfig()
	{
		DGV_Sensors.DataSource = null;
		DGV_Sensors.Rows.Clear();
		_DatabaseConnection.Columns.Clear();
		_DatabaseConnection.Rows.Clear();
		_DatabaseConnection.Columns.Add("Order#", typeof(int));
		_DatabaseConnection.Columns.Add("CanBeActive", typeof(bool));
		_DatabaseConnection.Columns.Add("Sensor", typeof(string));
		_DatabaseConnection.Columns.Add("SensorType", typeof(string));
		_DatabaseConnection.Columns.Add("Active", typeof(bool));
		_DatabaseConnection.Columns.Add("Status", typeof(string));
		int num = ((ActiveUnit)Client.SelectedUnit).MineCountermeasures.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = ((ActiveUnit)Client.SelectedUnit).MineCountermeasures[i];
			DataRow dataRow = _DatabaseConnection.NewRow();
			dataRow["Order#"] = i;
			dataRow["CanBeActive"] = sensor.CanBeActive;
			dataRow["Sensor"] = Misc.ReadRequest(sensor.Name);
			dataRow["SensorType"] = sensor.RoleDescription;
			dataRow["Active"] = sensor.IsActive;
			dataRow["Status"] = sensor.Status.ToString();
			_DatabaseConnection.Rows.Add(dataRow);
		}
	}

	private void PublishInterruptibleConfig(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && e.ColumnIndex != -1)
		{
			DataGridViewRow dataGridViewRow = DGV_Sensors.Rows[e.RowIndex];
			if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[e.RowIndex].Status == PlatformComponent._ComponentStatus.Destroyed)
			{
				dataGridViewRow.Selected = false;
			}
		}
	}

	private void AwakeInterruptibleConfig(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
		{
			return;
		}
		DataGridViewColumn dataGridViewColumn = DGV_Sensors.Columns[e.ColumnIndex];
		if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[e.RowIndex].Status != 0 || Operators.CompareString(dataGridViewColumn.Name, "Active", TextCompare: true) != 0)
		{
			return;
		}
		int index = Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value);
		if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[index].CanBeActive)
		{
			if (((ActiveUnit)Client.SelectedUnit).MineCountermeasures[index].IsActive)
			{
				((ActiveUnit)Client.SelectedUnit).MineCountermeasures[index].GoPassive();
				DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value = false;
			}
			else
			{
				((ActiveUnit)Client.SelectedUnit).MineCountermeasures[index].GoActive();
				DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value = true;
			}
			Client.MustRefreshMainForm = true;
			Client.MustRefreshMainForm = true;
		}
	}

	private void QueryInterruptibleConfig(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ResetInterruptibleConfig(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
