using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command.Messages;
using Command_Core;
using DarkUI.Collections;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ExclusionZonesWindow : DarkSecondaryFormBase
{
	private IContainer tokenList;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView indexerList;

	[AccessedThroughProperty("CB_MarkViolatorAs")]
	[CompilerGenerated]
	private DarkUIComboBox _ResolverList;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel publisherList;

	[AccessedThroughProperty("TB_Description")]
	[CompilerGenerated]
	private DarkUITextBox _ServerList;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel adapterList;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_SchemaList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SetDescription")]
	private DarkUIButton m_UtilsList;

	[AccessedThroughProperty("CB_Facility")]
	[CompilerGenerated]
	private DarkCheckBox m_PredicateList;

	[AccessedThroughProperty("CB_Submarine")]
	[CompilerGenerated]
	private DarkCheckBox m_SingletonList;

	[AccessedThroughProperty("CB_Ship")]
	[CompilerGenerated]
	private DarkCheckBox recordList;

	[AccessedThroughProperty("CB_Aircraft")]
	[CompilerGenerated]
	private DarkCheckBox _ExceptionList;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel m_AttrList;

	[AccessedThroughProperty("AreaEditor1")]
	[CompilerGenerated]
	private AreaEditor m_VisitorList;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel exporterList;

	[CompilerGenerated]
	[AccessedThroughProperty("ImportZone")]
	private DarkUIButton _PrototypeList;

	[AccessedThroughProperty("ExportZone")]
	[CompilerGenerated]
	private DarkUIButton comparatorList;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn itemList;

	[CompilerGenerated]
	[AccessedThroughProperty("Description")]
	private DataGridViewTextBoxColumn m_SetterList;

	[AccessedThroughProperty("Points")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn creatorList;

	[AccessedThroughProperty("CB_VisibleRP")]
	[CompilerGenerated]
	private DarkCheckBox m_MappingList;

	private ExclusionZone m_MockList;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_LoadExclusionZone")]
	private OpenFileDialog tagList;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ExportExclusionZone")]
	private SaveFileDialog m_FieldList;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return indexerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableService;
			DataGridViewCellEventHandler value3 = CalculateService;
			DarkDataGridView darkDataGridView = indexerList;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
				darkDataGridView.CellClick -= value3;
			}
			indexerList = value;
			darkDataGridView = indexerList;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
				darkDataGridView.CellClick += value3;
			}
		}
	}

	internal DarkUIComboBox CB_MarkViolatorAs
	{
		[CompilerGenerated]
		get
		{
			return _ResolverList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeService;
			DarkUIComboBox resolverList = _ResolverList;
			if (resolverList != null)
			{
				resolverList.SelectionChangeCommitted -= value2;
			}
			_ResolverList = value;
			resolverList = _ResolverList;
			if (resolverList != null)
			{
				resolverList.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return publisherList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherList = value;
		}
	}

	internal DarkUITextBox TB_Description
	{
		[CompilerGenerated]
		get
		{
			return _ServerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeService;
			DarkUITextBox serverList = _ServerList;
			if (serverList != null)
			{
				serverList.Leave -= value2;
			}
			_ServerList = value;
			serverList = _ServerList;
			if (serverList != null)
			{
				serverList.Leave += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return adapterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			adapterList = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchService;
			DarkUIButton schemaList = m_SchemaList;
			if (schemaList != null)
			{
				schemaList.Click -= value2;
			}
			m_SchemaList = value;
			schemaList = m_SchemaList;
			if (schemaList != null)
			{
				schemaList.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_SetDescription
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_UtilsList = value;
		}
	}

	internal DarkCheckBox CB_Facility
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ConcatService;
			DarkCheckBox predicateList = m_PredicateList;
			if (predicateList != null)
			{
				predicateList.MouseClick -= value2;
			}
			m_PredicateList = value;
			predicateList = m_PredicateList;
			if (predicateList != null)
			{
				predicateList.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CB_Submarine
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CheckService;
			DarkCheckBox singletonList = m_SingletonList;
			if (singletonList != null)
			{
				singletonList.MouseClick -= value2;
			}
			m_SingletonList = value;
			singletonList = m_SingletonList;
			if (singletonList != null)
			{
				singletonList.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CB_Ship
	{
		[CompilerGenerated]
		get
		{
			return recordList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = InitService;
			DarkCheckBox darkCheckBox = recordList;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick -= value2;
			}
			recordList = value;
			darkCheckBox = recordList;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CB_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return _ExceptionList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeService;
			DarkCheckBox exceptionList = _ExceptionList;
			if (exceptionList != null)
			{
				exceptionList.Enter -= value2;
			}
			_ExceptionList = value;
			exceptionList = _ExceptionList;
			if (exceptionList != null)
			{
				exceptionList.Enter += value2;
			}
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_AttrList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrList = value;
		}
	}

	internal AreaEditor AreaEditor1
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_VisitorList = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return exporterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterList = value;
		}
	}

	internal DarkUIButton ImportZone
	{
		[CompilerGenerated]
		get
		{
			return _PrototypeList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetService;
			DarkUIButton prototypeList = _PrototypeList;
			if (prototypeList != null)
			{
				prototypeList.Click -= value2;
			}
			_PrototypeList = value;
			prototypeList = _PrototypeList;
			if (prototypeList != null)
			{
				prototypeList.Click += value2;
			}
		}
	}

	internal DarkUIButton ExportZone
	{
		[CompilerGenerated]
		get
		{
			return comparatorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindService;
			DarkUIButton darkUIButton = comparatorList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			comparatorList = value;
			darkUIButton = comparatorList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return itemList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemList = value;
		}
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return m_SetterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterList = value;
		}
	}

	internal DataGridViewTextBoxColumn Points
	{
		[CompilerGenerated]
		get
		{
			return creatorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			creatorList = value;
		}
	}

	[field: AccessedThroughProperty("Active")]
	internal DataGridViewCheckBoxColumn Active
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_VisibleRP
	{
		[CompilerGenerated]
		get
		{
			return m_MappingList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillService;
			DarkCheckBox mappingList = m_MappingList;
			if (mappingList != null)
			{
				mappingList.Click -= value2;
			}
			m_MappingList = value;
			mappingList = m_MappingList;
			if (mappingList != null)
			{
				mappingList.Click += value2;
			}
		}
	}

	public ExclusionZone SelectedZone
	{
		get
		{
			return m_MockList;
		}
		set
		{
			m_MockList = value;
			if (!Information.IsNothing(value))
			{
				TB_Description.Text = value.Description;
				switch (value.MarkViolatorAs)
				{
				case Misc.PostureStance.Hostile:
					CB_MarkViolatorAs.SelectedIndex = 1;
					break;
				case Misc.PostureStance.Unfriendly:
					CB_MarkViolatorAs.SelectedIndex = 0;
					break;
				}
				CB_Aircraft.Checked = m_MockList.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
				CB_Ship.Checked = m_MockList.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
				CB_Submarine.Checked = m_MockList.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
				CB_Facility.Checked = m_MockList.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
				AreaEditor1.AreaPoints = m_MockList.Area;
				AreaEditor1.Title = "区域";
				AreaEditor1.RefreshForm();
			}
			bool flag = false;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (ExclusionZone exclusionZone in side.ExclusionZones)
				{
					if (exclusionZone != SelectedZone)
					{
						continue;
					}
					foreach (ReferencePoint item in SelectedZone.Area)
					{
						if (side.RefPoints.Contains(item))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					break;
				}
				if (flag)
				{
					break;
				}
			}
			CB_VisibleRP.Checked = flag;
			Client.MustRefreshMainForm = true;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog MoveSystem()
	{
		return tagList;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void DeleteSystem(OpenFileDialog openFileDialog_0)
	{
		tagList = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog DestroySystem()
	{
		return m_FieldList;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ComputeSystem(SaveFileDialog saveFileDialog_0)
	{
		m_FieldList = saveFileDialog_0;
	}

	public ExclusionZonesWindow()
	{
		base.FormClosing += InvokeService;
		base.KeyDown += RemoveService;
		base.Shown += PopService;
		PushService();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && tokenList != null)
			{
				tokenList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PushService()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		CB_VisibleRP = new DarkCheckBox();
		ImportZone = new DarkUIButton();
		ExportZone = new DarkUIButton();
		Label4 = new DarkLabel();
		AreaEditor1 = new AreaEditor();
		CB_Facility = new DarkCheckBox();
		CB_Submarine = new DarkCheckBox();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Points = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		CB_Ship = new DarkCheckBox();
		Label1 = new DarkLabel();
		CB_Aircraft = new DarkCheckBox();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		Button_SetDescription = new DarkUIButton();
		CB_MarkViolatorAs = new DarkUIComboBox();
		Button2 = new DarkUIButton();
		TB_Description = new DarkUITextBox();
		((ISupportInitialize)DataGridView1).BeginInit();
		CB_VisibleRP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CB_VisibleRP.Location = new Point(297, 497);
		CB_VisibleRP.Name = "CB_VisibleRP";
		CB_VisibleRP.Size = new Size(141, 17);
		CB_VisibleRP.TabIndex = 32;
		CB_VisibleRP.Text = "显示参考点";
		ImportZone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ImportZone.BackColor = Color.Transparent;
		ImportZone.DialogResult = DialogResult.None;
		ImportZone.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ImportZone.ForeColor = SystemColors.Control;
		ImportZone.Location = new Point(573, 521);
		ImportZone.Name = "ImportZone";
		ImportZone.RoundRadius = 0;
		ImportZone.Size = new Size(75, 23);
		ImportZone.TabIndex = 31;
		ImportZone.Text = "导入";
		ExportZone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ExportZone.BackColor = Color.Transparent;
		ExportZone.DialogResult = DialogResult.None;
		ExportZone.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ExportZone.ForeColor = SystemColors.Control;
		ExportZone.Location = new Point(472, 521);
		ExportZone.Name = "ExportZone";
		ExportZone.RoundRadius = 0;
		ExportZone.Size = new Size(75, 23);
		ExportZone.TabIndex = 30;
		ExportZone.Text = "导出";
		Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label4.Font = new Font("Segoe UI", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(8, 379);
		Label4.Name = "Label4";
		Label4.Size = new Size(116, 18);
		Label4.TabIndex = 13;
		Label4.Text = "选区";
		AreaEditor1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		AreaEditor1.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor1.Location = new Point(297, 367);
		AreaEditor1.Name = "AreaEditor1";
		AreaEditor1.Size = new Size(351, 124);
		AreaEditor1.TabIndex = 12;
		AreaEditor1.Title = null;
		CB_Facility.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Facility.AutoSize = true;
		CB_Facility.Location = new Point(99, 444);
		CB_Facility.Name = "CB_Facility";
		CB_Facility.Size = new Size(81, 19);
		CB_Facility.TabIndex = 11;
		CB_Facility.Text = "地面单元";
		CB_Submarine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Submarine.AutoSize = true;
		CB_Submarine.Location = new Point(16, 444);
		CB_Submarine.Name = "CB_Submarine";
		CB_Submarine.Size = new Size(88, 19);
		CB_Submarine.TabIndex = 10;
		CB_Submarine.Text = "潜艇";
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
		DataGridView1.Columns.AddRange(ID, Description, Points, Active);
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
		DataGridView1.Location = new Point(-3, 1);
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
		DataGridView1.Size = new Size(662, 365);
		DataGridView1.TabIndex = 1;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Points.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Points.DataPropertyName = "MarkViolatorAs";
		Points.HeaderText = "违规者标记为：";
		Points.Name = "Points";
		Points.ReadOnly = true;
		Active.DataPropertyName = "IsActive";
		Active.HeaderText = "启用";
		Active.Name = "Active";
		Active.ReadOnly = true;
		CB_Ship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Ship.AutoSize = true;
		CB_Ship.Location = new Point(99, 421);
		CB_Ship.Name = "CB_Ship";
		CB_Ship.Size = new Size(54, 19);
		CB_Ship.TabIndex = 9;
		CB_Ship.Text = "舰船";
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 477);
		Label1.Name = "Label1";
		Label1.Size = new Size(72, 17);
		Label1.TabIndex = 0;
		Label1.Text = "描述：";
		CB_Aircraft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Aircraft.AutoSize = true;
		CB_Aircraft.Location = new Point(16, 421);
		CB_Aircraft.Name = "CB_Aircraft";
		CB_Aircraft.Size = new Size(65, 19);
		CB_Aircraft.TabIndex = 8;
		CB_Aircraft.Text = "飞机";
		Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(15, 408);
		Label3.Name = "Label3";
		Label3.Size = new Size(60, 13);
		Label3.TabIndex = 7;
		Label3.Text = "适用于：";
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 505);
		Label2.Name = "Label2";
		Label2.Size = new Size(101, 16);
		Label2.TabIndex = 3;
		Label2.Text = "将违规者标记为：";
		Button_SetDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_SetDescription.BackColor = Color.Transparent;
		Button_SetDescription.DialogResult = DialogResult.None;
		Button_SetDescription.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_SetDescription.ForeColor = SystemColors.Control;
		Button_SetDescription.Location = new Point(297, 521);
		Button_SetDescription.Name = "Button_SetDescription";
		Button_SetDescription.RoundRadius = 0;
		Button_SetDescription.Size = new Size(47, 23);
		Button_SetDescription.TabIndex = 6;
		Button_SetDescription.Text = "保存";
		CB_MarkViolatorAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_MarkViolatorAs.BackColor = Color.Transparent;
		CB_MarkViolatorAs.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MarkViolatorAs.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MarkViolatorAs.Font = new Font("Segoe UI", 7f);
		CB_MarkViolatorAs.FormattingEnabled = true;
		CB_MarkViolatorAs.Items.AddRange(new object[2] { "非友方", "敌方" });
		CB_MarkViolatorAs.Location = new Point(116, 500);
		CB_MarkViolatorAs.Name = "CB_MarkViolatorAs";
		CB_MarkViolatorAs.Size = new Size(167, 21);
		CB_MarkViolatorAs.TabIndex = 4;
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.IndianRed;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = Color.IndianRed;
		Button2.Location = new Point(373, 521);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 5;
		Button2.Text = "删除";
		TB_Description.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_Description.AutoCompleteCustomSource = null;
		TB_Description.AutoCompleteMode = AutoCompleteMode.None;
		TB_Description.AutoCompleteSource = AutoCompleteSource.None;
		TB_Description.BackColor = Color.Transparent;
		TB_Description.Font = new Font("Segoe UI", 10f);
		TB_Description.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Description.Image = null;
		TB_Description.Lines = null;
		TB_Description.Location = new Point(116, 474);
		TB_Description.MaxLength = 32767;
		TB_Description.Multiline = false;
		TB_Description.Name = "TB_Description";
		TB_Description.ReadOnly = false;
		TB_Description.SelectionStart = 0;
		TB_Description.Size = new Size(167, 20);
		TB_Description.TabIndex = 1;
		TB_Description.TextAlign = HorizontalAlignment.Left;
		TB_Description.UseSystemPasswordChar = false;
		TB_Description.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(655, 548);
		base.Controls.Add(CB_VisibleRP);
		base.Controls.Add(ImportZone);
		base.Controls.Add(ExportZone);
		base.Controls.Add(Label4);
		base.Controls.Add(AreaEditor1);
		base.Controls.Add(CB_Facility);
		base.Controls.Add(CB_Submarine);
		base.Controls.Add(DataGridView1);
		base.Controls.Add(CB_Ship);
		base.Controls.Add(Label1);
		base.Controls.Add(CB_Aircraft);
		base.Controls.Add(TB_Description);
		base.Controls.Add(Label3);
		base.Controls.Add(Label2);
		base.Controls.Add(Button_SetDescription);
		base.Controls.Add(CB_MarkViolatorAs);
		base.Controls.Add(Button2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ExclusionZonesWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑封锁区";
		((ISupportInitialize)DataGridView1).EndInit();
	}

	private void InvokeService(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		SelectedZone = null;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void SetupService()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("MarkViolatorAs", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		foreach (ExclusionZone exclusionZone in Client.CurrentSide.ExclusionZones)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = exclusionZone.ObjectID;
			dataRow["Description"] = exclusionZone.Description;
			dataRow["MarkViolatorAs"] = exclusionZone.MarkViolatorAs.ToString();
			dataRow["IsActive"] = exclusionZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		DataGridView1.DataSource = dataTable;
	}

	private void ExcludeService(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			switch (CB_MarkViolatorAs.SelectedIndex)
			{
			case 1:
				SelectedZone.MarkViolatorAs = Misc.PostureStance.Hostile;
				break;
			case 0:
				SelectedZone.MarkViolatorAs = Misc.PostureStance.Unfriendly;
				break;
			}
			SetupService();
		}
	}

	private void IncludeService(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			SelectedZone.Description = TB_Description.Text;
			SetupService();
		}
	}

	private void SearchService(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			Client.CurrentSide.ExclusionZones.Remove(SelectedZone);
			SelectedZone = null;
			SetupService();
		}
	}

	private void EnableService(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			int num = DataGridView1.Rows.IndexOf(DataGridView1.SelectedRows[0]);
			if (num != -1)
			{
				SelectedZone = Client.CurrentSide.ExclusionZones[num];
			}
		}
	}

	private void ChangeService(object sender, EventArgs e)
	{
		InterruptService();
	}

	private void InitService(object sender, EventArgs e)
	{
		InterruptService();
	}

	private void CheckService(object sender, EventArgs e)
	{
		InterruptService();
	}

	private void ConcatService(object sender, EventArgs e)
	{
		InterruptService();
	}

	private void InterruptService()
	{
		if (Information.IsNothing(SelectedZone))
		{
			if (Client.CurrentSide.ExclusionZones.Count <= 0)
			{
				return;
			}
			SelectedZone = Client.CurrentSide.ExclusionZones[0];
		}
		SelectedZone.AffectedUnitTypes.Clear();
		if (CB_Aircraft.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
		}
		if (CB_Ship.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
		}
		if (CB_Submarine.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
		}
		if (CB_Facility.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
		}
	}

	private void RemoveService(object sender, KeyEventArgs e)
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

	private void FindService(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedZone))
		{
			DarkMessageBox.ShowError("Please select a Exclusion Zone.", "未选择区域");
			return;
		}
		ComputeSystem(new SaveFileDialog());
		DestroySystem().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (DestroySystem().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			FileStream fileStream = File.Create(DestroySystem().FileName);
			XmlWriterSettings settings = new XmlWriterSettings();
			using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
			{
				xmlWriter.WriteStartElement("ExclusionZone");
				xmlWriter.WriteElementString("Description", SelectedZone.Description);
				xmlWriter.WriteStartElement("Area");
				foreach (ReferencePoint item in SelectedZone.Area)
				{
					HashSet<string> hashSet_ = null;
					xmlWriter.WriteRaw(item.ToXML(ref hashSet_));
					xmlWriter.Flush();
				}
				xmlWriter.WriteEndElement();
				byte markViolatorAs = (byte)SelectedZone.MarkViolatorAs;
				xmlWriter.WriteElementString("MarkViolatorAs", markViolatorAs.ToString());
				xmlWriter.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedZone.AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
				{
					int num = (int)theType;
					return num.ToString();
				})));
				xmlWriter.WriteEndElement();
			}
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
			fileStream.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101277", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void SetService(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			switch (DarkMessageBox.ShowInformation("请选择禁航区。", "封锁区", DarkDialogButton.YesNoCancel))
			{
			case DialogResult.Yes:
				SelectedZone = null;
				break;
			case DialogResult.Cancel:
				return;
			}
		}
		DeleteSystem(new OpenFileDialog());
		MoveSystem().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (MoveSystem().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		FileStream fileStream = new FileStream(MoveSystem().FileName, FileMode.Open, FileAccess.Read);
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					xmlDocument.Load(fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("文件格式不正确，读取失败！", "Error");
					ProjectData.ClearProjectError();
				}
			}
			Zone zone = new Zone();
			bool flag = true;
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/ExclusionZone");
			if (Information.IsNothing(xmlNode))
			{
				xmlNode = xmlDocument.SelectSingleNode("/NoNavZone");
				flag = false;
			}
			if (xmlNode == null)
			{
				DarkMessageBox.ShowError("找不到XML数据。", "Error");
			}
			else
			{
				IEnumerator enumerator = null;
				Misc.PostureStance postureStance = Misc.PostureStance.Neutral;
				try
				{
					enumerator = xmlNode.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator.Current;
						string name = xmlNode2.Name;
						if (Operators.CompareString(name, "Description", TextCompare: true) == 0)
						{
							zone.Description = xmlNode2.InnerText;
						}
						else if (Operators.CompareString(name, "Area", TextCompare: true) == 0)
						{
							try
							{
								enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
									ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
									ReferencePoint referencePoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_);
									if (!flag)
									{
										referencePoint.ResetIDs();
									}
									zone.Area.Add(referencePoint);
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
						else if (Operators.CompareString(name, "AffectedUnitTypes", TextCompare: true) == 0)
						{
							zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
							string[] array = xmlNode2.InnerText.Split('_');
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (Versioned.IsNumeric(text))
								{
									int num = Conversions.ToInteger(text);
									zone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
								}
							}
						}
						else if (Operators.CompareString(name, "MarkViolatorAs", TextCompare: true) == 0)
						{
							postureStance = (Misc.PostureStance)Conversions.ToByte(xmlNode2.InnerText);
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
				if (Information.IsNothing(zone.AffectedUnitTypes))
				{
					zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
					{
						GlobalVariables.ActiveUnitType.Aircraft,
						GlobalVariables.ActiveUnitType.Ship,
						GlobalVariables.ActiveUnitType.Submarine,
						GlobalVariables.ActiveUnitType.Facility
					};
				}
				if (SelectedZone == null)
				{
					ExclusionZone exclusionZone = new ExclusionZone(zone.Description, Client.CurrentSide, zone.Area, postureStance, zone.AffectedUnitTypes);
					Client.CurrentSide.ExclusionZones.Add(exclusionZone);
					SelectedZone = exclusionZone;
				}
				else
				{
					SelectedZone.Description = zone.Description;
					SelectedZone.Area = zone.Area;
					SelectedZone.AffectedUnitTypes = zone.AffectedUnitTypes;
					SelectedZone.MarkViolatorAs = postureStance;
				}
				AreaEditor1.RefreshForm();
				bool flag2 = false;
				Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
				Side[] array3 = sides_ReadOnly;
				foreach (Side side in array3)
				{
					foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
					{
						if (exclusionZone2 != SelectedZone)
						{
							continue;
						}
						foreach (ReferencePoint item in SelectedZone.Area)
						{
							if (!side.RefPoints.Contains(item))
							{
								side.RefPoints.Add(item);
							}
						}
						flag2 = true;
						break;
					}
					if (flag2)
					{
						break;
					}
				}
				SetupService();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101276", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void FillService(object sender, EventArgs e)
	{
		bool flag = false;
		flag = CB_VisibleRP.Checked;
		bool flag2 = false;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				if (exclusionZone != SelectedZone)
				{
					continue;
				}
				foreach (ReferencePoint item in SelectedZone.Area)
				{
					if (flag)
					{
						if (!side.RefPoints.Contains(item))
						{
							side.RefPoints.Add(item);
						}
					}
					else if (side.RefPoints.Contains(item))
					{
						side.RefPoints.Remove(item);
					}
				}
				flag2 = true;
				break;
			}
			if (flag2)
			{
				break;
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void CalculateService(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || Operators.CompareString(DataGridView1.Columns[e.ColumnIndex].Name, "Active", TextCompare: true) != 0)
		{
			return;
		}
		DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)DataGridView1[e.ColumnIndex, e.RowIndex];
		ExclusionZone exclusionZone = null;
		string right = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
		foreach (ExclusionZone exclusionZone2 in Client.CurrentSide.ExclusionZones)
		{
			if (Operators.CompareString(exclusionZone2.ObjectID, right, TextCompare: true) == 0)
			{
				exclusionZone = exclusionZone2;
				break;
			}
		}
		if (!Information.IsNothing(exclusionZone))
		{
			if (exclusionZone.IsActive)
			{
				dataGridViewCheckBoxCell.Value = false;
				exclusionZone.IsActive = false;
			}
			else
			{
				dataGridViewCheckBoxCell.Value = true;
				exclusionZone.IsActive = true;
			}
			Client.MustRefreshMainForm = true;
			SetupService();
		}
	}

	private void PopService(object sender, EventArgs e)
	{
		SetupService();
		if (Client.CurrentSide.ExclusionZones.Count > 0 && Information.IsNothing(SelectedZone))
		{
			SelectedZone = Client.CurrentSide.ExclusionZones[0];
		}
	}
}
