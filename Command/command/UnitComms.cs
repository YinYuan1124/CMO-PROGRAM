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
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitComms : DarkSecondaryFormBase, GInterface9
{
	private IContainer _SerializerAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddSensor")]
	private ToolStripButton _ErrorAttr;

	[AccessedThroughProperty("TSB_RemoveSensor")]
	[CompilerGenerated]
	private ToolStripButton m_CodeAttr;

	[AccessedThroughProperty("Timer_Refresh")]
	[CompilerGenerated]
	private Timer m_ConnectionAttr;

	[AccessedThroughProperty("DGV_Comms")]
	[CompilerGenerated]
	private DarkDataGridView _ContextAttr;

	[AccessedThroughProperty("SensorColumn")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn proccesorAttr;

	[AccessedThroughProperty("SensorType")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_StrategyAttr;

	[AccessedThroughProperty("Status")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn configurationAttr;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton m_TokenAttr;

	private DataTable _IndexerAttr;

	private bool resolverAttr;

	private string publisherAttr;

	private ActiveUnit m_ServerAttr;

	[field: AccessedThroughProperty("TS_Edit")]
	internal DarkToolStrip TS_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AddSensor
	{
		[CompilerGenerated]
		get
		{
			return _ErrorAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeInterruptibleExporter;
			ToolStripButton errorAttr = _ErrorAttr;
			if (errorAttr != null)
			{
				errorAttr.Click -= value2;
			}
			_ErrorAttr = value;
			errorAttr = _ErrorAttr;
			if (errorAttr != null)
			{
				errorAttr.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveSensor
	{
		[CompilerGenerated]
		get
		{
			return m_CodeAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleExporter;
			ToolStripButton codeAttr = m_CodeAttr;
			if (codeAttr != null)
			{
				codeAttr.Click -= value2;
			}
			m_CodeAttr = value;
			codeAttr = m_CodeAttr;
			if (codeAttr != null)
			{
				codeAttr.Click += value2;
			}
		}
	}

	internal DarkDataGridView DGV_Comms
	{
		[CompilerGenerated]
		get
		{
			return _ContextAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = WriteInterruptibleExporter;
			DataGridViewCellEventHandler value3 = NewInterruptibleExporter;
			DataGridViewCellEventHandler value4 = PushInterruptibleExporter;
			EventHandler value5 = EnableInterruptibleExporter;
			DarkDataGridView contextAttr = _ContextAttr;
			if (contextAttr != null)
			{
				contextAttr.CellClick -= value2;
				contextAttr.CellContentClick -= value3;
				contextAttr.CellContentDoubleClick -= value4;
				contextAttr.SelectionChanged -= value5;
			}
			_ContextAttr = value;
			contextAttr = _ContextAttr;
			if (contextAttr != null)
			{
				contextAttr.CellClick += value2;
				contextAttr.CellContentClick += value3;
				contextAttr.CellContentDoubleClick += value4;
				contextAttr.SelectionChanged += value5;
			}
		}
	}

	[field: AccessedThroughProperty("ObjectID")]
	internal DataGridViewTextBoxColumn ObjectID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn SensorColumn
	{
		[CompilerGenerated]
		get
		{
			return proccesorAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorAttr = value;
		}
	}

	internal DataGridViewTextBoxColumn SensorType
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StrategyAttr = value;
		}
	}

	internal DataGridViewTextBoxColumn Status
	{
		[CompilerGenerated]
		get
		{
			return configurationAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationAttr = value;
		}
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return m_TokenAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenAttr = value;
		}
	}

	public ActiveUnit theSelectedUnit
	{
		get
		{
			return m_ServerAttr;
		}
		set
		{
			bool flag = false;
			if (value != null)
			{
				flag = value != m_ServerAttr;
			}
			m_ServerAttr = value;
			if (flag && base.Visible)
			{
				BuildForm();
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer PopInterruptibleExporter()
	{
		return m_ConnectionAttr;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InstantiateInterruptibleExporter(Timer timer_0)
	{
		EventHandler value = InitInterruptibleExporter;
		Timer connectionAttr = m_ConnectionAttr;
		if (connectionAttr != null)
		{
			connectionAttr.Tick -= value;
		}
		m_ConnectionAttr = timer_0;
		connectionAttr = m_ConnectionAttr;
		if (connectionAttr != null)
		{
			connectionAttr.Tick += value;
		}
	}

	public UnitComms()
	{
		base.FormClosing += LogoutInterruptibleExporter;
		base.Load += ViewInterruptibleExporter;
		base.Shown += ValidateInterruptibleExporter;
		base.SizeChanged += LoginInterruptibleExporter;
		base.KeyDown += CheckInterruptibleExporter;
		base.FormClosed += ConcatInterruptibleExporter;
		_IndexerAttr = new DataTable();
		CallInterruptibleExporter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && _SerializerAttr != null)
		{
			_SerializerAttr.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void CallInterruptibleExporter()
	{
		_SerializerAttr = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(UnitComms));
		InstantiateInterruptibleExporter(new Timer(_SerializerAttr));
		DGV_Comms = new DarkDataGridView();
		ObjectID = new DataGridViewTextBoxColumn();
		SensorColumn = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TS_Edit = new DarkToolStrip();
		TSB_AddSensor = new ToolStripButton();
		TSB_RemoveSensor = new ToolStripButton();
		ToolStripButton1 = new ToolStripButton();
		((ISupportInitialize)DGV_Comms).BeginInit();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		DGV_Comms.AllowUserToAddRows = false;
		DGV_Comms.AllowUserToDeleteRows = false;
		DGV_Comms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_Comms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		DGV_Comms.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_Comms.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Comms.BorderStyle = BorderStyle.Fixed3D;
		DGV_Comms.CausesValidation = false;
		DGV_Comms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Comms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Comms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Comms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Comms.Columns.AddRange(ObjectID, SensorColumn, SensorType, Status);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.LightGray;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_Comms.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_Comms.EnableHeadersVisualStyles = false;
		DGV_Comms.Location = new Point(0, 25);
		DGV_Comms.MultiSelect = false;
		DGV_Comms.Name = "DGV_Comms";
		DGV_Comms.RowHeadersVisible = false;
		DGV_Comms.RowHeadersWidth = 4;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_Comms.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Comms.RowTemplate.Height = 20;
		DGV_Comms.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_Comms.ScrollBars = ScrollBars.Vertical;
		DGV_Comms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Comms.Size = new Size(681, 288);
		DGV_Comms.TabIndex = 8;
		ObjectID.DataPropertyName = "ObjectID";
		ObjectID.HeaderText = "对象ID";
		ObjectID.Name = "ObjectID";
		ObjectID.ReadOnly = true;
		ObjectID.Visible = false;
		SensorColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SensorColumn.DataPropertyName = "Sensor";
		SensorColumn.FillWeight = 92.72417f;
		SensorColumn.HeaderText = "设备";
		SensorColumn.Name = "SensorColumn";
		SensorColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		SensorType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SensorType.DataPropertyName = "SensorType";
		SensorType.FillWeight = 92.72417f;
		SensorType.HeaderText = "设备类型";
		SensorType.Name = "SensorType";
		SensorType.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Status.DataPropertyName = "Status";
		Status.FillWeight = 92.72417f;
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.Resizable = DataGridViewTriState.True;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		TS_Edit.AutoSize = false;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.Items.AddRange(new ToolStripItem[2] { TSB_AddSensor, TSB_RemoveSensor });
		TS_Edit.Location = new Point(0, 313);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(681, 25);
		TS_Edit.TabIndex = 14;
		TS_Edit.Text = "ToolStrip1";
		TSB_AddSensor.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddSensor.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddSensor.Image = componentResourceManager.GetObject("TSB_AddSensor.Image");
		TSB_AddSensor.ImageTransparentColor = Color.Magenta;
		TSB_AddSensor.Name = "TSB_AddSensor";
		TSB_AddSensor.Size = new Size(126, 22);
		TSB_AddSensor.Text = "添加通信设备";
		TSB_RemoveSensor.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveSensor.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveSensor.Image = componentResourceManager.GetObject("TSB_RemoveSensor.Image");
		TSB_RemoveSensor.ImageTransparentColor = Color.Magenta;
		TSB_RemoveSensor.Name = "TSB_RemoveSensor";
		TSB_RemoveSensor.Size = new Size(147, 22);
		TSB_RemoveSensor.Text = "移除通信设备";
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(23, 23);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(681, 338);
		base.Controls.Add(DGV_Comms);
		base.Controls.Add(TS_Edit);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(200, 200);
		base.Name = "UnitComms";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "通信设备：";
		((ISupportInitialize)DGV_Comms).EndInit();
		TS_Edit.ResumeLayout(performLayout: false);
		TS_Edit.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void LogoutInterruptibleExporter(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (ItemExporter.ConnectInterruptibleTemplate.AddComms.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AddComms.Close();
		}
	}

	private void ViewInterruptibleExporter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.SelectedUnit.IsActiveUnit)
		{
			m_ServerAttr = (ActiveUnit)Client.SelectedUnit;
		}
		Text = "通信设备和链路：" + Client.SelectedUnit.Name;
		Client.SelectedUnitChanged += GetInterruptibleExporter;
	}

	private void ValidateInterruptibleExporter(object sender, EventArgs e)
	{
		DGV_Comms.ForeColor = Color.Black;
		DGV_Comms.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		BuildForm();
		BuildForm();
	}

	private void LoginInterruptibleExporter(object sender, EventArgs e)
	{
		BuildForm();
	}

	private void GetInterruptibleExporter(Module_Unit.Unit unit_0)
	{
		if (base.Visible && !Information.IsNothing(unit_0) && unit_0.IsActiveUnit)
		{
			m_ServerAttr = (ActiveUnit)unit_0;
			BuildForm();
		}
	}

	public void BuildForm()
	{
		BuildForm_Detailed();
	}

	public void BuildForm_Detailed()
	{
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		if (Information.IsNothing(m_ServerAttr) || !m_ServerAttr.IsActiveUnit)
		{
			return;
		}
		InvokeInterruptibleExporter();
		if (Information.IsNothing(m_ServerAttr) || !m_ServerAttr.IsActiveUnit)
		{
			return;
		}
		Text = "通信设备和链路：" + m_ServerAttr.Name;
		DGV_Comms.DataSource = _IndexerAttr;
		IEnumerator enumerator = null;
		try
		{
			enumerator = DGV_Comms.Columns.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewColumn obj = (DataGridViewColumn)enumerator.Current;
				obj.SortMode = DataGridViewColumnSortMode.NotSortable;
				obj.ReadOnly = true;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		DGV_Comms.Columns["Order#"].Visible = false;
		DGV_Comms.Columns["ObjectID"].Visible = false;
	}

	public void RefreshForm()
	{
		if (resolverAttr)
		{
			return;
		}
		resolverAttr = true;
		try
		{
			if (Information.IsNothing(m_ServerAttr))
			{
				DGV_Comms.Columns.Clear();
			}
			else if (m_ServerAttr.GetUnitSide() == Client.CurrentSide)
			{
				BuildForm();
			}
			else
			{
				DGV_Comms.Columns.Clear();
			}
			TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200107", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		resolverAttr = false;
	}

	private void WriteInterruptibleExporter(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex != -1 && !DGV_Comms.ReadOnly && DGV_Comms.Rows.Count != 0)
			{
				DataGridViewRow dataGridViewRow = DGV_Comms.Rows[e.RowIndex];
				if (m_ServerAttr.Comms_ReadOnly[Conversions.ToInteger(DGV_Comms.Rows[e.RowIndex].Cells["Order#"].Value)].Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					dataGridViewRow.Selected = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200108", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void NewInterruptibleExporter(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && !DGV_Comms.ReadOnly && DGV_Comms.Rows.Count != 0)
			{
				_ = DGV_Comms.Columns[e.ColumnIndex];
				_ = m_ServerAttr.Comms_ReadOnly[Conversions.ToInteger(DGV_Comms.Rows[e.RowIndex].Cells["Order#"].Value)].Status;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200109", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PushInterruptibleExporter(object sender, DataGridViewCellEventArgs e)
	{
		BuildForm();
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
	}

	private void InvokeInterruptibleExporter()
	{
		if (Information.IsNothing(m_ServerAttr) || !m_ServerAttr.IsActiveUnit)
		{
			return;
		}
		DGV_Comms.DataSource = null;
		DGV_Comms.Rows.Clear();
		_IndexerAttr.Columns.Clear();
		_IndexerAttr.Rows.Clear();
		_IndexerAttr.Columns.Add("Sensor", typeof(string));
		_IndexerAttr.Columns.Add("SensorType", typeof(string));
		_IndexerAttr.Columns.Add("Status", typeof(string));
		_IndexerAttr.Columns.Add("ObjectID", typeof(string));
		_IndexerAttr.Columns.Add("Order#", typeof(int));
		CommDevice[] comms_ReadOnly = m_ServerAttr.Comms_ReadOnly;
		int num = comms_ReadOnly.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			CommDevice commDevice = comms_ReadOnly[i];
			DataRow dataRow = _IndexerAttr.NewRow();
			dataRow["ObjectID"] = commDevice.ObjectID;
			dataRow["Order#"] = i;
			dataRow["Sensor"] = Misc.ReadRequest(commDevice.Name + (string)Interaction.IIf(commDevice.IsCommsInMount, "^", ""));
			dataRow["SensorType"] = DBFunctions.Description(commDevice.Type, Client.CurrentScenario);
			string text = commDevice.Status.ToString();
			if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && Operators.CompareString(commDevice.ReasonForInoperative, "None", TextCompare: true) != 0)
			{
				text = "未工作（" + commDevice.ReasonForInoperative + ")";
			}
			else if (commDevice.IsJammed)
			{
				text += " - 被干扰";
			}
			dataRow["Status"] = text;
			_IndexerAttr.Rows.Add(dataRow);
		}
	}

	private void SetupInterruptibleExporter()
	{
		int num = DGV_Comms.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow dataGridViewRow = DGV_Comms.Rows[i];
			CommDevice commDevice = null;
			commDevice = m_ServerAttr.Comms_ReadOnly[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)];
			if (commDevice.Status == PlatformComponent._ComponentStatus.Operational)
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = Color.LightGray;
			}
			else
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = GetComponentDamageColor(commDevice);
				dataGridViewRow.ReadOnly = true;
			}
			_ = DGV_Comms.Rows[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)].Cells["Active"];
		}
	}

	private void ExcludeInterruptibleExporter(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddComms.FormThatCalledMe = this;
		ItemExporter.ConnectInterruptibleTemplate.AddComms.Show();
		Client.MustRefreshMainForm = true;
	}

	private void IncludeInterruptibleExporter(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex <= -1 || e.ColumnIndex != DGV_Comms.Columns.IndexOf(DGV_Comms.Columns["Active"]))
		{
			return;
		}
		if (Conversions.ToBoolean(DGV_Comms.Rows[e.RowIndex].Cells["CanBeActive"].Value))
		{
			if (Operators.CompareString(Conversions.ToString(DGV_Comms.Rows[e.RowIndex].Cells["Status"].Value), "Damaged", TextCompare: true) == 0 || Operators.CompareString(Conversions.ToString(DGV_Comms.Rows[e.RowIndex].Cells["Status"].Value), "Destroyed", TextCompare: true) == 0)
			{
				e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
				e.Handled = true;
			}
		}
		else
		{
			e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
			e.Handled = true;
		}
	}

	private void SearchInterruptibleExporter(object sender, EventArgs e)
	{
		if (DGV_Comms.ReadOnly)
		{
			DGV_Comms.ForeColor = Color.Gray;
			DGV_Comms.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			DGV_Comms.ForeColor = Color.Black;
			DGV_Comms.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
	}

	private void EnableInterruptibleExporter(object sender, EventArgs e)
	{
		if (DGV_Comms.SelectedRows.Count > 0)
		{
			publisherAttr = Conversions.ToString(DGV_Comms.SelectedRows[0].Cells["ObjectID"].Value);
		}
	}

	private void ChangeInterruptibleExporter(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(publisherAttr) || !m_ServerAttr.IsActiveUnit)
		{
			return;
		}
		ActiveUnit serverAttr = m_ServerAttr;
		CommDevice commDevice = null;
		CommDevice[] comms_ReadOnly = serverAttr.Comms_ReadOnly;
		CommDevice[] array = comms_ReadOnly;
		foreach (CommDevice commDevice2 in array)
		{
			if (Operators.CompareString(commDevice2.ObjectID, publisherAttr, TextCompare: true) == 0)
			{
				commDevice = commDevice2;
				break;
			}
		}
		if (!Information.IsNothing(commDevice))
		{
			serverAttr.RemoveCommDevice(commDevice);
			BuildForm();
		}
		Client.MustRefreshMainForm = true;
	}

	private void InitInterruptibleExporter(object sender, EventArgs e)
	{
		RefreshForm();
		PopInterruptibleExporter().Stop();
	}

	private void CheckInterruptibleExporter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ConcatInterruptibleExporter(object sender, FormClosedEventArgs e)
	{
		Client.SelectedUnitChanged -= GetInterruptibleExporter;
	}
}
