using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Managers;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class CargoOpsContainer : DarkSecondaryFormBase
{
	public enum CargoOpsContainerMode
	{
		None,
		Munitions,
		Fuel
	}

	private IContainer _MessageInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("ContainerPanel")]
	private DarkSectionPanel annotationInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("CrewBar")]
	private DarkUIProgressBar m_IteratorInvocation;

	[AccessedThroughProperty("AreaBar")]
	[CompilerGenerated]
	private DarkUIProgressBar initializerInvocation;

	[AccessedThroughProperty("UnloadButton")]
	[CompilerGenerated]
	private DarkUIButton _AttributeInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("UnloadCounter")]
	private DarkNumericUpDown eventInvocation;

	[AccessedThroughProperty("HostPanel")]
	[CompilerGenerated]
	private DarkSectionPanel m_GlobalInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadButton")]
	private DarkUIButton _WorkerInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("ContainerCargoGridView")]
	private DarkDataGridView stateInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton authenticationInvocation;

	[AccessedThroughProperty("ButtonConfirm")]
	[CompilerGenerated]
	private DarkUIButton m_ParamsInvocation;

	[AccessedThroughProperty("HostCargoGridView")]
	[CompilerGenerated]
	private DarkDataGridView m_InfoInvocation;

	[AccessedThroughProperty("TargetColName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_HelperInvocation;

	[AccessedThroughProperty("TargetColSize")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn mapperInvocation;

	[AccessedThroughProperty("TargetColMass")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn managerInvocation;

	[AccessedThroughProperty("TargetColArea")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn getterInvocation;

	[AccessedThroughProperty("TargetColPax")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn producerInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	private DataGridViewTextBoxColumn procInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn m_StructClass;

	[AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_CallbackClass;

	[AccessedThroughProperty("DataGridViewTextBoxColumn5")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn decoratorClass;

	public CargoContainer SelectedContainer;

	public ActiveUnit SelectedHost;

	public ICargoHost SelectedHostCargoHost;

	protected List<CargoContainerContent> ContainerWorkingContents;

	protected List<CargoContainerContent> HostWorkingContents;

	protected float ContainerAvailableMass;

	protected float ContainerAvailableArea;

	protected float ContainerAvailableCrew;

	protected float ContainerAvailableVolume;

	protected int Mode;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkSectionPanel ContainerPanel
	{
		[CompilerGenerated]
		get
		{
			return annotationInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			annotationInvocation = value;
		}
	}

	internal virtual DarkUIProgressBar CrewBar
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IteratorInvocation = value;
		}
	}

	internal virtual DarkUIProgressBar AreaBar
	{
		[CompilerGenerated]
		get
		{
			return initializerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerInvocation = value;
		}
	}

	[field: AccessedThroughProperty("MassBar")]
	internal virtual DarkUIProgressBar MassBar
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SizeLabel")]
	internal virtual DarkLabel SizeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton UnloadButton
	{
		[CompilerGenerated]
		get
		{
			return _AttributeInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeProccesor;
			DarkUIButton attributeInvocation = _AttributeInvocation;
			if (attributeInvocation != null)
			{
				attributeInvocation.Click -= value2;
			}
			_AttributeInvocation = value;
			attributeInvocation = _AttributeInvocation;
			if (attributeInvocation != null)
			{
				attributeInvocation.Click += value2;
			}
		}
	}

	internal virtual DarkNumericUpDown UnloadCounter
	{
		[CompilerGenerated]
		get
		{
			return eventInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eventInvocation = value;
		}
	}

	internal virtual DarkSectionPanel HostPanel
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalInvocation = value;
		}
	}

	internal virtual DarkUIButton LoadButton
	{
		[CompilerGenerated]
		get
		{
			return _WorkerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryProccesor;
			DarkUIButton workerInvocation = _WorkerInvocation;
			if (workerInvocation != null)
			{
				workerInvocation.Click -= value2;
			}
			_WorkerInvocation = value;
			workerInvocation = _WorkerInvocation;
			if (workerInvocation != null)
			{
				workerInvocation.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadCounter")]
	internal virtual DarkNumericUpDown LoadCounter
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkDataGridView ContainerCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return stateInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortProccesor;
			DarkDataGridView darkDataGridView = stateInvocation;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
			}
			stateInvocation = value;
			darkDataGridView = stateInvocation;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return authenticationInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineProccesor;
			DarkUIButton darkUIButton = authenticationInvocation;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			authenticationInvocation = value;
			darkUIButton = authenticationInvocation;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonConfirm
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintProccesor;
			DarkUIButton paramsInvocation = m_ParamsInvocation;
			if (paramsInvocation != null)
			{
				paramsInvocation.Click -= value2;
			}
			m_ParamsInvocation = value;
			paramsInvocation = m_ParamsInvocation;
			if (paramsInvocation != null)
			{
				paramsInvocation.Click += value2;
			}
		}
	}

	internal virtual DarkDataGridView HostCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return m_InfoInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcProccesor;
			DarkDataGridView infoInvocation = m_InfoInvocation;
			if (infoInvocation != null)
			{
				infoInvocation.SelectionChanged -= value2;
			}
			m_InfoInvocation = value;
			infoInvocation = m_InfoInvocation;
			if (infoInvocation != null)
			{
				infoInvocation.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColName
	{
		[CompilerGenerated]
		get
		{
			return m_HelperInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_HelperInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColSize
	{
		[CompilerGenerated]
		get
		{
			return mapperInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColMass
	{
		[CompilerGenerated]
		get
		{
			return managerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColArea
	{
		[CompilerGenerated]
		get
		{
			return getterInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColPax
	{
		[CompilerGenerated]
		get
		{
			return producerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return procInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			procInvocation = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return m_StructClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StructClass = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CallbackClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn5
	{
		[CompilerGenerated]
		get
		{
			return decoratorClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			decoratorClass = value;
		}
	}

	public CargoOpsContainer()
	{
		base.Load += StopProccesor;
		RestartProccesor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _MessageInvocation != null)
			{
				_MessageInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RestartProccesor()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		TableLayoutPanel1 = new TableLayoutPanel();
		ContainerPanel = new DarkSectionPanel();
		ContainerCargoGridView = new DarkDataGridView();
		TargetColName = new DataGridViewTextBoxColumn();
		TargetColSize = new DataGridViewTextBoxColumn();
		TargetColMass = new DataGridViewTextBoxColumn();
		TargetColArea = new DataGridViewTextBoxColumn();
		TargetColPax = new DataGridViewTextBoxColumn();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		UnloadButton = new DarkUIButton();
		UnloadCounter = new DarkNumericUpDown();
		HostPanel = new DarkSectionPanel();
		HostCargoGridView = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		LoadButton = new DarkUIButton();
		LoadCounter = new DarkNumericUpDown();
		ButtonCancel = new DarkUIButton();
		ButtonConfirm = new DarkUIButton();
		TableLayoutPanel1.SuspendLayout();
		ContainerPanel.SuspendLayout();
		((ISupportInitialize)ContainerCargoGridView).BeginInit();
		((ISupportInitialize)UnloadCounter).BeginInit();
		HostPanel.SuspendLayout();
		((ISupportInitialize)HostCargoGridView).BeginInit();
		((ISupportInitialize)LoadCounter).BeginInit();
		SuspendLayout();
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 412f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 424f));
		TableLayoutPanel1.Controls.Add(ContainerPanel, 0, 0);
		TableLayoutPanel1.Controls.Add(HostPanel, 1, 0);
		TableLayoutPanel1.Location = new Point(4, 3);
		TableLayoutPanel1.Margin = new Padding(0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel1.Size = new Size(836, 464);
		TableLayoutPanel1.TabIndex = 10;
		ContainerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ContainerPanel.Controls.Add(ContainerCargoGridView);
		ContainerPanel.Controls.Add(CrewBar);
		ContainerPanel.Controls.Add(AreaBar);
		ContainerPanel.Controls.Add(MassBar);
		ContainerPanel.Controls.Add(SizeLabel);
		ContainerPanel.Controls.Add(UnloadButton);
		ContainerPanel.Controls.Add(UnloadCounter);
		ContainerPanel.Location = new Point(0, 0);
		ContainerPanel.Margin = new Padding(0);
		ContainerPanel.Name = "ContainerPanel";
		ContainerPanel.SectionHeader = "Container Contents:";
		ContainerPanel.Size = new Size(412, 464);
		ContainerPanel.TabIndex = 0;
		ContainerCargoGridView.AllowUserToAddRows = false;
		ContainerCargoGridView.AllowUserToDeleteRows = false;
		ContainerCargoGridView.AllowUserToOrderColumns = true;
		ContainerCargoGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ContainerCargoGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		ContainerCargoGridView.BorderStyle = BorderStyle.None;
		ContainerCargoGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		ContainerCargoGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		ContainerCargoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		ContainerCargoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		ContainerCargoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		ContainerCargoGridView.Columns.AddRange(TargetColName, TargetColSize, TargetColMass, TargetColArea, TargetColPax);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		ContainerCargoGridView.DefaultCellStyle = dataGridViewCellStyle2;
		ContainerCargoGridView.EnableHeadersVisualStyles = false;
		ContainerCargoGridView.Location = new Point(0, 28);
		ContainerCargoGridView.Name = "ContainerCargoGridView";
		ContainerCargoGridView.ReadOnly = true;
		ContainerCargoGridView.RowHeadersVisible = false;
		ContainerCargoGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		ContainerCargoGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
		ContainerCargoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		ContainerCargoGridView.Size = new Size(412, 312);
		ContainerCargoGridView.TabIndex = 25;
		TargetColName.HeaderText = "名称";
		TargetColName.MinimumWidth = 6;
		TargetColName.Name = "TargetColName";
		TargetColName.ReadOnly = true;
		TargetColName.SortMode = DataGridViewColumnSortMode.NotSortable;
		TargetColName.Width = 192;
		TargetColSize.HeaderText = "尺寸";
		TargetColSize.MinimumWidth = 6;
		TargetColSize.Name = "TargetColSize";
		TargetColSize.ReadOnly = true;
		TargetColSize.Width = 64;
		TargetColMass.HeaderText = "Mass";
		TargetColMass.MinimumWidth = 6;
		TargetColMass.Name = "TargetColMass";
		TargetColMass.ReadOnly = true;
		TargetColMass.Width = 50;
		TargetColArea.HeaderText = "区域";
		TargetColArea.MinimumWidth = 6;
		TargetColArea.Name = "TargetColArea";
		TargetColArea.ReadOnly = true;
		TargetColArea.Width = 56;
		TargetColPax.HeaderText = "PAX";
		TargetColPax.MinimumWidth = 6;
		TargetColPax.Name = "TargetColPax";
		TargetColPax.ReadOnly = true;
		TargetColPax.Width = 30;
		CrewBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CrewBar.BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		CrewBar.Location = new Point(8, 412);
		CrewBar.Maximum = 100;
		CrewBar.Name = "CrewBar";
		CrewBar.ShowProgressLines = false;
		CrewBar.ShowProgressValue = false;
		CrewBar.ShowText = true;
		CrewBar.Size = new Size(396, 20);
		CrewBar.TabIndex = 16;
		CrewBar.Text = "PAX:";
		CrewBar.Value = 0;
		AreaBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		AreaBar.BackColor = Color.Transparent;
		AreaBar.CustomForeColor = Color.Transparent;
		AreaBar.Location = new Point(8, 389);
		AreaBar.Maximum = 100;
		AreaBar.Name = "AreaBar";
		AreaBar.ShowProgressLines = false;
		AreaBar.ShowProgressValue = false;
		AreaBar.ShowText = true;
		AreaBar.Size = new Size(396, 20);
		AreaBar.TabIndex = 15;
		AreaBar.Text = "Area:";
		AreaBar.Value = 0;
		MassBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		MassBar.BackColor = Color.Transparent;
		MassBar.CustomForeColor = Color.Transparent;
		MassBar.Location = new Point(8, 366);
		MassBar.Maximum = 100;
		MassBar.Name = "MassBar";
		MassBar.ShowProgressLines = false;
		MassBar.ShowProgressValue = false;
		MassBar.ShowText = true;
		MassBar.Size = new Size(396, 20);
		MassBar.TabIndex = 14;
		MassBar.Text = "Mass:";
		MassBar.Value = 0;
		SizeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SizeLabel.ForeColor = Color.White;
		SizeLabel.Location = new Point(8, 343);
		SizeLabel.Name = "SizeLabel";
		SizeLabel.Size = new Size(396, 20);
		SizeLabel.TabIndex = 13;
		SizeLabel.Text = "最大尺寸：";
		SizeLabel.TextAlign = ContentAlignment.MiddleLeft;
		UnloadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		UnloadButton.BackColor = Color.Transparent;
		UnloadButton.DialogResult = DialogResult.None;
		UnloadButton.ForeColor = SystemColors.Control;
		UnloadButton.Location = new Point(162, 438);
		UnloadButton.Name = "UnloadButton";
		UnloadButton.Padding = new Padding(5);
		UnloadButton.RoundRadius = 0;
		UnloadButton.Size = new Size(124, 23);
		UnloadButton.TabIndex = 2;
		UnloadButton.Text = "Unload Selected";
		UnloadCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		UnloadCounter.BackColor = Color.FromArgb(43, 43, 43);
		UnloadCounter.BorderStyle = BorderStyle.None;
		UnloadCounter.Font = new Font("Segoe UI", 12f);
		UnloadCounter.ForeColor = Color.FromArgb(220, 220, 220);
		UnloadCounter.Location = new Point(93, 436);
		UnloadCounter.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		UnloadCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		UnloadCounter.Name = "UnloadCounter";
		UnloadCounter.Size = new Size(64, 25);
		UnloadCounter.TabIndex = 3;
		UnloadCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		HostPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		HostPanel.Controls.Add(HostCargoGridView);
		HostPanel.Controls.Add(LoadButton);
		HostPanel.Controls.Add(LoadCounter);
		HostPanel.Location = new Point(412, 0);
		HostPanel.Margin = new Padding(0);
		HostPanel.Name = "HostPanel";
		HostPanel.SectionHeader = "Host Contents:";
		HostPanel.Size = new Size(424, 464);
		HostPanel.TabIndex = 1;
		HostCargoGridView.AllowUserToAddRows = false;
		HostCargoGridView.AllowUserToDeleteRows = false;
		HostCargoGridView.AllowUserToOrderColumns = true;
		HostCargoGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		HostCargoGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		HostCargoGridView.BorderStyle = BorderStyle.None;
		HostCargoGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		HostCargoGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		HostCargoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		HostCargoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		HostCargoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		HostCargoGridView.Columns.AddRange(DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		HostCargoGridView.DefaultCellStyle = dataGridViewCellStyle5;
		HostCargoGridView.EnableHeadersVisualStyles = false;
		HostCargoGridView.Location = new Point(5, 27);
		HostCargoGridView.Name = "HostCargoGridView";
		HostCargoGridView.ReadOnly = true;
		HostCargoGridView.RowHeadersVisible = false;
		HostCargoGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		HostCargoGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
		HostCargoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		HostCargoGridView.Size = new Size(412, 382);
		HostCargoGridView.TabIndex = 27;
		DataGridViewTextBoxColumn1.HeaderText = "名称";
		DataGridViewTextBoxColumn1.MinimumWidth = 6;
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
		DataGridViewTextBoxColumn1.Width = 192;
		DataGridViewTextBoxColumn2.HeaderText = "尺寸";
		DataGridViewTextBoxColumn2.MinimumWidth = 6;
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DataGridViewTextBoxColumn2.Width = 64;
		DataGridViewTextBoxColumn3.HeaderText = "Mass";
		DataGridViewTextBoxColumn3.MinimumWidth = 6;
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		DataGridViewTextBoxColumn3.ReadOnly = true;
		DataGridViewTextBoxColumn3.Width = 50;
		DataGridViewTextBoxColumn4.HeaderText = "区域";
		DataGridViewTextBoxColumn4.MinimumWidth = 6;
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		DataGridViewTextBoxColumn4.ReadOnly = true;
		DataGridViewTextBoxColumn4.Width = 56;
		DataGridViewTextBoxColumn5.HeaderText = "PAX";
		DataGridViewTextBoxColumn5.MinimumWidth = 6;
		DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
		DataGridViewTextBoxColumn5.ReadOnly = true;
		DataGridViewTextBoxColumn5.Width = 30;
		LoadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LoadButton.BackColor = Color.Transparent;
		LoadButton.DialogResult = DialogResult.None;
		LoadButton.ForeColor = SystemColors.Control;
		LoadButton.Location = new Point(177, 438);
		LoadButton.Name = "LoadButton";
		LoadButton.Padding = new Padding(5);
		LoadButton.RoundRadius = 0;
		LoadButton.Size = new Size(124, 23);
		LoadButton.TabIndex = 5;
		LoadButton.Text = "Load Selected";
		LoadCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LoadCounter.BackColor = Color.FromArgb(43, 43, 43);
		LoadCounter.BorderStyle = BorderStyle.None;
		LoadCounter.Font = new Font("Segoe UI", 12f);
		LoadCounter.ForeColor = Color.FromArgb(220, 220, 220);
		LoadCounter.Location = new Point(107, 436);
		LoadCounter.Margin = new Padding(0);
		LoadCounter.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		LoadCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		LoadCounter.Name = "LoadCounter";
		LoadCounter.Size = new Size(64, 25);
		LoadCounter.TabIndex = 6;
		LoadCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		ButtonCancel.BackColor = Color.Transparent;
		ButtonCancel.DialogResult = DialogResult.None;
		ButtonCancel.ForeColor = SystemColors.Control;
		ButtonCancel.Location = new Point(433, 487);
		ButtonCancel.Name = "ButtonCancel";
		ButtonCancel.Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		ButtonCancel.Size = new Size(91, 23);
		ButtonCancel.TabIndex = 32;
		ButtonCancel.Text = "取消";
		ButtonConfirm.BackColor = Color.Transparent;
		ButtonConfirm.DialogResult = DialogResult.None;
		ButtonConfirm.ForeColor = SystemColors.Control;
		ButtonConfirm.Location = new Point(317, 487);
		ButtonConfirm.Name = "ButtonConfirm";
		ButtonConfirm.Padding = new Padding(5);
		ButtonConfirm.RoundRadius = 0;
		ButtonConfirm.Size = new Size(91, 23);
		ButtonConfirm.TabIndex = 31;
		ButtonConfirm.Text = "确认";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(843, 523);
		base.Controls.Add(ButtonCancel);
		base.Controls.Add(ButtonConfirm);
		base.Controls.Add(TableLayoutPanel1);
		base.Name = "CargoOpsContainer";
		Text = "Cargo Operations - Container";
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		ContainerPanel.ResumeLayout(performLayout: false);
		((ISupportInitialize)ContainerCargoGridView).EndInit();
		((ISupportInitialize)UnloadCounter).EndInit();
		HostPanel.ResumeLayout(performLayout: false);
		((ISupportInitialize)HostCargoGridView).EndInit();
		((ISupportInitialize)LoadCounter).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void TestProccesor(List<CargoContainerContent> list_0, List<CargoContainerContent> list_1)
	{
		list_0.Clear();
		Cargo[] cargoArray = SelectedContainer.CargoArray;
		Cargo[] array = cargoArray;
		foreach (Cargo cargo in array)
		{
			if (cargo.CargoObjectContainerContents != null)
			{
				CargoContainerContent cargoContainerContent = null;
				CargoContainerContent.CargoContainerContentType contentType = cargo.CargoObjectContainerContents.ContentType;
				if (1 == 0)
				{
				}
				CargoContainerContent item = contentType switch
				{
					CargoContainerContent.CargoContainerContentType.LiquidFuel => new CargoLiquidFuel((CargoLiquidFuel)cargo.CargoObjectContainerContents), 
					CargoContainerContent.CargoContainerContentType.Ammunition => new CargoAmmunition((CargoAmmunition)cargo.CargoObjectContainerContents), 
					_ => new CargoContainerContent(cargo.CargoObjectContainerContents), 
				};
				if (1 == 0)
				{
				}
				list_0.Add(item);
			}
		}
		list_1.Clear();
		if (SelectedContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
		{
			Mode = 2;
			ListProccesor(SelectedHost, list_1);
		}
		else
		{
			Mode = 1;
			ResolveProccesor(SelectedHost, list_1);
		}
	}

	private void StopProccesor(object sender, EventArgs e)
	{
		if (SelectedContainer == null)
		{
			DarkMessageBox.ShowWarning("No container selected.", "Cargo Operations - Container");
			Close();
		}
		if (SelectedHost == null || !(SelectedHost is ICargoHost))
		{
			DarkMessageBox.ShowWarning("No container host selected.", "Cargo Operations - Container");
			Close();
		}
		if (!SelectedHost.IsFixedFacility)
		{
			DarkMessageBox.ShowWarning("Manual container management can only be done when the container is at a fixed facility.", "Cargo Operations - Container");
			Close();
		}
		SelectedHostCargoHost = (ICargoHost)SelectedHost;
		ContainerWorkingContents = new List<CargoContainerContent>();
		HostWorkingContents = new List<CargoContainerContent>();
		TestProccesor(ContainerWorkingContents, HostWorkingContents);
		RunProccesor();
	}

	private void CancelProccesor()
	{
		ContainerAvailableMass = SelectedContainer.ResolveProperty();
		ContainerAvailableArea = SelectedContainer.VerifyProperty();
		ContainerAvailableCrew = SelectedContainer.CancelProperty();
		ContainerAvailableVolume = SelectedContainer.PayloadVolume * 1000f;
		foreach (CargoContainerContent containerWorkingContent in ContainerWorkingContents)
		{
			ContainerAvailableMass -= containerWorkingContent.GetRequiredMass();
			ContainerAvailableArea -= containerWorkingContent.GetRequiredArea();
			ContainerAvailableCrew -= containerWorkingContent.GetRequiredCrewSpace();
			if (containerWorkingContent is CargoLiquidFuel)
			{
				ContainerAvailableVolume -= ((CargoLiquidFuel)containerWorkingContent).CurrentQuantity;
			}
		}
	}

	private void VerifyProccesor(DarkDataGridView darkDataGridView_0, ICargoHost icargoHost_0, List<CargoContainerContent> list_0)
	{
		int num = -1;
		if (darkDataGridView_0.SelectedRows.Count > 0)
		{
			num = darkDataGridView_0.SelectedRows[0].Index;
		}
		darkDataGridView_0.Rows.Clear();
		if (list_0 == null || list_0.Count < 1)
		{
			return;
		}
		int num2 = 0;
		int index = 0;
		int index2 = 1;
		int num3 = 1;
		int num4 = 2;
		int num5 = 3;
		bool flag;
		if (flag = darkDataGridView_0.ColumnCount > 4)
		{
			num3++;
			num4++;
			num5++;
		}
		if (Mode == 2)
		{
			darkDataGridView_0.Columns[num4].HeaderText = "Volume";
		}
		else
		{
			darkDataGridView_0.Columns[num4].HeaderText = "区域";
		}
		foreach (CargoContainerContent item in list_0)
		{
			num2 = darkDataGridView_0.Rows.Add();
			DataGridViewRow dataGridViewRow = darkDataGridView_0.Rows[num2];
			dataGridViewRow.Cells[index].Value = item.GetCargoName();
			dataGridViewRow.Cells[index].ToolTipText = item.GetCargoName();
			if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				dataGridViewRow.Cells[num3].Value = Cargo.DisplayValueMass(item.GetRequiredMass(), bool_0: true).ToString("N");
			}
			else
			{
				dataGridViewRow.Cells[num3].Value = item.GetRequiredMass().ToString("N");
			}
			if (Mode == 2)
			{
				CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)item;
				if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					dataGridViewRow.Cells[num4].Value = Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, bool_0: true).ToString("N");
				}
				else
				{
					dataGridViewRow.Cells[num4].Value = cargoLiquidFuel.CurrentQuantity.ToString("N");
				}
			}
			else if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				dataGridViewRow.Cells[num4].Value = Cargo.DisplayValueArea(item.GetRequiredArea(), bool_0: true).ToString("N");
			}
			else
			{
				dataGridViewRow.Cells[num4].Value = item.GetRequiredArea().ToString("N");
			}
			dataGridViewRow.Cells[num5].Value = item.GetRequiredCrewSpace().ToString();
			if (flag)
			{
				dataGridViewRow.Cells[index2].Value = MapperListenerManager.SearchStrategy((int)item.GetRequiredCargoType());
				dataGridViewRow.Cells[index2].Tag = (int)item.GetRequiredCargoType();
			}
			dataGridViewRow.Tag = item;
		}
		darkDataGridView_0.Refresh();
		if (darkDataGridView_0.Rows.Count > 0 && num > -1)
		{
			darkDataGridView_0.ClearSelection();
			if (num >= darkDataGridView_0.Rows.Count)
			{
				num = darkDataGridView_0.Rows.Count - 1;
			}
			darkDataGridView_0.Rows[num].Selected = true;
		}
	}

	public void UpdateCapacityLabels(CargoContainer cargoContainer_0, DarkLabel darkLabel_0, DarkUIProgressBar darkUIProgressBar_0, float float_0, DarkUIProgressBar darkUIProgressBar_1, float float_1, DarkUIProgressBar darkUIProgressBar_2, float float_2)
	{
		if (cargoContainer_0 == null)
		{
			if (darkLabel_0 != null)
			{
				darkLabel_0.Text = "Max Size: Unlimted";
			}
			darkUIProgressBar_0.Text = "质量：" + float_0.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			darkUIProgressBar_0.ForeColor = Color.White;
			darkUIProgressBar_1.Text = "区域：" + float_1.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			darkUIProgressBar_1.ForeColor = Color.White;
			darkUIProgressBar_2.Text = "PAX: " + float_2 + " Pers.";
			darkUIProgressBar_2.ForeColor = Color.White;
			return;
		}
		float num = (float)((ICargoHost)cargoContainer_0).GetCargo_Type();
		float cargo_Mass = ((ICargoHost)cargoContainer_0).GetCargo_Mass();
		float cargo_Crew = ((ICargoHost)cargoContainer_0).GetCargo_Crew();
		float num2 = ((Mode == 2) ? (cargoContainer_0.PayloadVolume * 1000f) : ((ICargoHost)cargoContainer_0).GetCargo_Area());
		if (darkLabel_0 != null)
		{
			darkLabel_0.Text = "Max Size: ";
			float num3 = num;
			if (num3 == 0f)
			{
				darkLabel_0.Text += CargoHostHelper.c0000;
			}
			else if (num3 == 1000f)
			{
				darkLabel_0.Text += CargoHostHelper.c1000;
			}
			else if (num3 == 2000f)
			{
				darkLabel_0.Text += CargoHostHelper.c2000;
			}
			else if (num3 == 3000f)
			{
				darkLabel_0.Text += CargoHostHelper.c3000;
			}
			else if (num3 == 4000f)
			{
				darkLabel_0.Text += CargoHostHelper.c4000;
			}
			else if (num3 == 5000f)
			{
				darkLabel_0.Text += CargoHostHelper.c5000;
			}
		}
		float num4 = cargo_Mass;
		float num5 = Cargo.DisplayValueMass(num4 - float_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num6 = Cargo.DisplayValueMass(num4, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		darkUIProgressBar_0.Text = "质量：" + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num4 == 0f)
		{
			darkUIProgressBar_0.Value = 100;
		}
		else
		{
			darkUIProgressBar_0.Value = (int)Math.Round(100f * ((num4 - float_0) / num4));
		}
		if (float_0 == 0f)
		{
			darkUIProgressBar_0.ForeColor = Color.LightGray;
			darkUIProgressBar_0.Text = "[FULL] " + darkUIProgressBar_0.Text;
		}
		else
		{
			darkUIProgressBar_0.ForeColor = Color.White;
		}
		num4 = num2;
		num5 = Cargo.DisplayValueArea(num4 - float_1, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num6 = Cargo.DisplayValueArea(num4, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (Mode == 2)
		{
			darkUIProgressBar_1.Text = "Volume: " + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		}
		else
		{
			darkUIProgressBar_1.Text = "区域：" + num5.ToString("N") + " / " + num6.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		}
		if (num4 == 0f)
		{
			darkUIProgressBar_1.Value = 100;
		}
		else
		{
			darkUIProgressBar_1.Value = (int)Math.Round(100f * ((num4 - float_1) / num4));
		}
		if (float_1 == 0f)
		{
			darkUIProgressBar_1.ForeColor = Color.LightGray;
			darkUIProgressBar_1.Text = "[FULL] " + darkUIProgressBar_1.Text;
		}
		else
		{
			darkUIProgressBar_1.ForeColor = Color.White;
		}
		num4 = cargo_Crew;
		darkUIProgressBar_2.Text = "PAX: " + (num4 - float_2) + " / " + num4.ToString("N0") + " Pers.";
		if (num4 == 0f)
		{
			darkUIProgressBar_2.Value = 100;
		}
		else
		{
			darkUIProgressBar_2.Value = (int)Math.Round(100f * ((num4 - float_2) / num4));
		}
		if (float_2 == 0f)
		{
			darkUIProgressBar_2.ForeColor = Color.LightGray;
			darkUIProgressBar_2.Text = "[FULL] " + darkUIProgressBar_2.Text;
		}
		else
		{
			darkUIProgressBar_2.ForeColor = Color.White;
		}
	}

	private void ListProccesor(ActiveUnit activeUnit_0, List<CargoContainerContent> list_0)
	{
		list_0.Clear();
		if (activeUnit_0 == null)
		{
			return;
		}
		foreach (FuelRec item in activeUnit_0.Fuel_ReadOnly)
		{
			CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
			cargoLiquidFuel.FuelType = item.FuelType;
			cargoLiquidFuel.Mass = item.CurrentQuantity;
			cargoLiquidFuel.CurrentQuantity = cargoLiquidFuel.MoveImporter(item.CurrentQuantity);
			list_0.Add(cargoLiquidFuel);
		}
	}

	private void ResolveProccesor(ActiveUnit activeUnit_0, List<CargoContainerContent> list_0)
	{
		list_0.Clear();
		if (activeUnit_0 == null)
		{
			return;
		}
		Magazine[] totalMagazines = activeUnit_0.TotalMagazines;
		for (int i = 0; i < totalMagazines.Length; i++)
		{
			foreach (WeaponRec weapon in totalMagazines[i].Weapons)
			{
				if (weapon.CurrentLoad > 0)
				{
					CargoAmmunition item = new CargoAmmunition(weapon.int_0, weapon.CurrentLoad, activeUnit_0.ParentScen);
					list_0.Add(item);
				}
			}
		}
	}

	private void PostProccesor(DarkDataGridView darkDataGridView_0, float float_0, float float_1, float float_2, float float_3)
	{
	}

	private void RunProccesor()
	{
		CancelProccesor();
		if (Mode == 2)
		{
			UpdateCapacityLabels(SelectedContainer, SizeLabel, MassBar, ContainerAvailableMass, AreaBar, ContainerAvailableVolume, CrewBar, ContainerAvailableCrew);
		}
		else
		{
			UpdateCapacityLabels(SelectedContainer, SizeLabel, MassBar, ContainerAvailableMass, AreaBar, ContainerAvailableArea, CrewBar, ContainerAvailableCrew);
		}
		VerifyProccesor(ContainerCargoGridView, SelectedContainer, ContainerWorkingContents);
		SortProccesor(null, null);
		VerifyProccesor(HostCargoGridView, SelectedHostCargoHost, HostWorkingContents);
		CalcProccesor(null, null);
		PostProccesor(HostCargoGridView, ContainerAvailableMass, ContainerAvailableArea, ContainerAvailableVolume, ContainerAvailableCrew);
	}

	private void StartProccesor(List<CargoContainerContent> list_0, List<CargoContainerContent> list_1, List<CargoContainerContent> list_2)
	{
		foreach (CargoContainerContent item in list_0)
		{
			CargoContainerContent cargoContainerContent = null;
			foreach (CargoContainerContent item2 in list_1)
			{
				if (item.isMatch(item2))
				{
					cargoContainerContent = item2;
					break;
				}
			}
			if (cargoContainerContent == null)
			{
				list_2.Add(item);
			}
			else if (!item.isExactMatch(cargoContainerContent))
			{
				float quantityDifference = item.GetQuantityDifference(cargoContainerContent);
				if (quantityDifference > 0f)
				{
					list_2.Add(item.CreateNewContentMatching(quantityDifference));
				}
			}
		}
	}

	private bool AssetProccesor()
	{
		List<CargoContainerContent> list = new List<CargoContainerContent>();
		List<CargoContainerContent> list2 = new List<CargoContainerContent>();
		List<CargoContainerContent> list3 = new List<CargoContainerContent>();
		List<CargoContainerContent> list_ = new List<CargoContainerContent>();
		TestProccesor(list3, list_);
		StartProccesor(HostWorkingContents, list_, list);
		StartProccesor(ContainerWorkingContents, list3, list2);
		if (list.Count > 0 && !Cargo.UnloadContainerContentsToUnit(SelectedContainer, list, SelectedHost))
		{
			return false;
		}
		if (list2.Count > 0 && !Cargo.LoadContainerContentsFromUnit(SelectedHost, SelectedContainer, list2))
		{
			return false;
		}
		return true;
	}

	private void PrintProccesor(object sender, EventArgs e)
	{
		if (!AssetProccesor())
		{
			DarkMessageBox.ShowWarning("One or more cargo items could not be moved due to capacity limitations.", "货运操作");
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void DefineProccesor(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void PublishProccesor(List<CargoContainerContent> list_0, List<CargoContainerContent> list_1, CargoContainerContent cargoContainerContent_0, int int_0, CargoContainer cargoContainer_0)
	{
		if (int_0 < 1)
		{
			return;
		}
		if (int_0 > cargoContainerContent_0.GetCargoQuantity())
		{
			int_0 = cargoContainerContent_0.GetCargoQuantity();
		}
		if (cargoContainerContent_0 is CargoLiquidFuel)
		{
			CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoContainerContent_0;
			CargoLiquidFuel cargoLiquidFuel2 = null;
			float num = Math.Min(int_0, cargoLiquidFuel.CurrentQuantity);
			foreach (CargoContainerContent item in list_1)
			{
				if (item is CargoLiquidFuel)
				{
					CargoLiquidFuel cargoLiquidFuel3 = (CargoLiquidFuel)item;
					if (cargoLiquidFuel3.FuelType == cargoLiquidFuel.FuelType)
					{
						cargoLiquidFuel2 = cargoLiquidFuel3;
						break;
					}
				}
			}
			if (cargoContainer_0 != null)
			{
				if (cargoLiquidFuel2 == null && list_1.Count > 0)
				{
					DarkMessageBox.ShowWarning("The type of fuel does not match the fuel already in the container.", "Cargo Operations - Container");
					return;
				}
				if (ContainerAvailableVolume < cargoLiquidFuel.CurrentQuantity)
				{
					num = ContainerAvailableVolume;
					if (num <= 0f)
					{
						DarkMessageBox.ShowWarning("The requested fuel could not be loaded. The container volume is already full.", "Cargo Operations - Container");
						return;
					}
					DarkMessageBox.ShowWarning("Only some of the requested fuel could be loaded due to container volume limit.", "Cargo Operations - Container");
				}
				if (ContainerAvailableMass < cargoLiquidFuel.GetRequiredMass())
				{
					num = 1000f * cargoLiquidFuel.MoveImporter(ContainerAvailableMass);
					if (num <= 0f)
					{
						DarkMessageBox.ShowWarning("The requested fuel could not be loaded. The container is already at maximum mass.", "Cargo Operations - Container");
						return;
					}
					DarkMessageBox.ShowWarning("Only some of the requested fuel could be loaded due to container mass limit.", "Cargo Operations - Container");
				}
			}
			if (cargoLiquidFuel2 == null)
			{
				if (cargoLiquidFuel.CurrentQuantity <= num)
				{
					cargoLiquidFuel.Parent = cargoContainer_0;
					list_0.Remove(cargoLiquidFuel);
					list_1.Add(cargoLiquidFuel);
					return;
				}
				cargoLiquidFuel2 = new CargoLiquidFuel();
				cargoLiquidFuel2.Parent = cargoContainer_0;
				cargoLiquidFuel2.FuelType = cargoLiquidFuel.FuelType;
				cargoLiquidFuel2.CurrentQuantity = num;
				cargoLiquidFuel2.Mass = cargoLiquidFuel2.DeleteImporter(cargoLiquidFuel2.CurrentQuantity);
				list_1.Add(cargoLiquidFuel2);
				cargoLiquidFuel.CurrentQuantity -= num;
				cargoLiquidFuel.Mass = cargoLiquidFuel.DeleteImporter(cargoLiquidFuel.CurrentQuantity);
			}
			else
			{
				cargoLiquidFuel2.CurrentQuantity += num;
				cargoLiquidFuel2.Mass = cargoLiquidFuel2.DeleteImporter(cargoLiquidFuel2.CurrentQuantity);
				cargoLiquidFuel.CurrentQuantity -= num;
				if (cargoLiquidFuel.CurrentQuantity <= 0f)
				{
					list_0.Remove(cargoLiquidFuel);
				}
				else
				{
					cargoLiquidFuel.Mass = cargoLiquidFuel.DeleteImporter(cargoLiquidFuel.CurrentQuantity);
				}
			}
		}
		else
		{
			if (!(cargoContainerContent_0 is CargoAmmunition))
			{
				return;
			}
			CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoContainerContent_0;
			CargoAmmunition cargoAmmunition2 = null;
			foreach (CargoContainerContent item2 in list_1)
			{
				if (item2 is CargoAmmunition)
				{
					CargoAmmunition cargoAmmunition3 = (CargoAmmunition)item2;
					if (cargoAmmunition3.int_0 == cargoAmmunition.int_0)
					{
						cargoAmmunition2 = cargoAmmunition3;
						break;
					}
				}
			}
			if (cargoContainer_0 != null)
			{
				if (cargoAmmunition.GetRequiredCargoType() > cargoContainer_0.ListProperty())
				{
					DarkMessageBox.ShowWarning("The size of the requested munition is too large for the container.", "Cargo Operations - Container");
					return;
				}
				float num2 = cargoAmmunition.Area * (float)int_0;
				float num3 = cargoAmmunition.Mass * (float)int_0;
				if (ContainerAvailableArea < num2)
				{
					bool flag = false;
					if (cargoAmmunition.IsStackable() && cargoContainer_0.RunProperty())
					{
						int num4 = 0;
						float num5 = 0f;
						if (cargoAmmunition2 != null)
						{
							num4 = cargoAmmunition2.GetCargoQuantity();
							num5 = cargoAmmunition2.GetRequiredArea();
						}
						if (ContainerAvailableArea + num5 < cargoAmmunition.GetRequiredAreaStacked(cargoContainer_0, int_0 + num4))
						{
							bool flag2 = false;
							for (int i = int_0 - 1; i >= 1; i += -1)
							{
								if (!(ContainerAvailableArea + num5 < cargoAmmunition.GetRequiredAreaStacked(cargoContainer_0, i + num4)))
								{
									int_0 = i;
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								int_0 = 0;
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						int_0 = (int)Math.Floor(ContainerAvailableArea / cargoAmmunition.Area);
					}
					if (!flag)
					{
						if (int_0 < 1)
						{
							DarkMessageBox.ShowWarning("The requested munitions could not be loaded. The container area limit has been reached.", "Cargo Operations - Container");
							return;
						}
						DarkMessageBox.ShowWarning("Only some of the requested munitions could be loaded due to container area limit.", "Cargo Operations - Container");
					}
				}
				if (ContainerAvailableMass < num3)
				{
					int_0 = (int)Math.Round(Math.Min(Math.Floor(ContainerAvailableMass / cargoAmmunition.Mass), int_0));
					if (int_0 < 1)
					{
						DarkMessageBox.ShowWarning("The requested munitions could not be loaded. The container mass limit has been reached.", "Cargo Operations - Container");
						return;
					}
					DarkMessageBox.ShowWarning("Only some of the requested munitions could be loaded due to container mass limit.", "Cargo Operations - Container");
				}
			}
			if (cargoAmmunition2 == null)
			{
				if (cargoAmmunition.WeaponQuantity <= int_0)
				{
					cargoAmmunition.Parent = cargoContainer_0;
					list_0.Remove(cargoAmmunition);
					list_1.Add(cargoAmmunition);
				}
				else
				{
					cargoAmmunition2 = new CargoAmmunition(cargoAmmunition.int_0, int_0, SelectedHost.ParentScen);
					cargoAmmunition2.Parent = cargoContainer_0;
					list_1.Add(cargoAmmunition2);
					cargoAmmunition.WeaponQuantity -= int_0;
				}
			}
			else
			{
				cargoAmmunition2.WeaponQuantity += int_0;
				cargoAmmunition.WeaponQuantity -= int_0;
				if (cargoAmmunition.WeaponQuantity <= 0)
				{
					list_0.Remove(cargoAmmunition);
				}
			}
		}
	}

	private void AwakeProccesor(object sender, EventArgs e)
	{
		if (decimal.Compare(UnloadCounter.Value, 1m) < 0)
		{
			return;
		}
		int int_ = Convert.ToInt32(UnloadCounter.Value);
		IEnumerator enumerator = null;
		try
		{
			enumerator = ContainerCargoGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag != null)
				{
					CargoContainerContent cargoContainerContent_ = (CargoContainerContent)dataGridViewRow.Tag;
					PublishProccesor(ContainerWorkingContents, HostWorkingContents, cargoContainerContent_, int_, null);
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
		RunProccesor();
	}

	private void QueryProccesor(object sender, EventArgs e)
	{
		if (decimal.Compare(LoadCounter.Value, 1m) < 0)
		{
			return;
		}
		int int_ = Convert.ToInt32(LoadCounter.Value);
		IEnumerator enumerator = null;
		try
		{
			enumerator = HostCargoGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag != null)
				{
					CargoContainerContent cargoContainerContent_ = (CargoContainerContent)dataGridViewRow.Tag;
					PublishProccesor(HostWorkingContents, ContainerWorkingContents, cargoContainerContent_, int_, SelectedContainer);
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
		RunProccesor();
	}

	private void ResetProccesor(DarkNumericUpDown darkNumericUpDown_0, DarkDataGridView darkDataGridView_0)
	{
		darkNumericUpDown_0.Minimum = 0m;
		darkNumericUpDown_0.Maximum = 0m;
		darkNumericUpDown_0.Value = 0m;
		IEnumerator enumerator = null;
		try
		{
			enumerator = darkDataGridView_0.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag != null)
				{
					int cargoQuantity = ((CargoContainerContent)dataGridViewRow.Tag).GetCargoQuantity();
					if (decimal.Compare(new decimal(cargoQuantity), darkNumericUpDown_0.Maximum) > 0)
					{
						darkNumericUpDown_0.Maximum = new decimal(cargoQuantity);
					}
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
		if (decimal.Compare(darkNumericUpDown_0.Maximum, 0m) > 0)
		{
			darkNumericUpDown_0.Minimum = 1m;
			darkNumericUpDown_0.Value = darkNumericUpDown_0.Maximum;
		}
	}

	private void MapProccesor()
	{
		UnloadButton.Enabled = decimal.Compare(UnloadCounter.Maximum, 0m) > 0;
		LoadButton.Enabled = decimal.Compare(LoadCounter.Maximum, 0m) > 0;
	}

	private void SortProccesor(object sender, EventArgs e)
	{
		ResetProccesor(UnloadCounter, ContainerCargoGridView);
		MapProccesor();
	}

	private void CalcProccesor(object sender, EventArgs e)
	{
		ResetProccesor(LoadCounter, HostCargoGridView);
		MapProccesor();
	}
}
