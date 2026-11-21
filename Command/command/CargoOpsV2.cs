using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
public class CargoOpsV2 : DarkSecondaryFormBase, GInterface9
{
	protected enum CargoOpsMode
	{
		SingleUnitDisplay,
		SingleUnitUnloadToMap,
		SingleUnitTransferToNearbyUnits,
		HostUnitAndHostedUnit
	}

	protected class CargoMovementRecord
	{
		public Cargo cargo;

		public ActiveUnit source;

		public ActiveUnit destination;
	}

	private IContainer _ThreadClass;

	[CompilerGenerated]
	[AccessedThroughProperty("HostPanel")]
	private DarkSectionPanel m_RuleClass;

	[AccessedThroughProperty("HostCrewBar")]
	[CompilerGenerated]
	private DarkUIProgressBar collectionClass;

	[CompilerGenerated]
	[AccessedThroughProperty("HostMassBar")]
	private DarkUIProgressBar m_ObjectClass;

	[CompilerGenerated]
	[AccessedThroughProperty("TargetCrewBar")]
	private DarkUIProgressBar expressionClass;

	[CompilerGenerated]
	[AccessedThroughProperty("TargetAreaBar")]
	private DarkUIProgressBar dispatcherClass;

	[CompilerGenerated]
	[AccessedThroughProperty("TargetMassBar")]
	private DarkUIProgressBar m_ListenerClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirm")]
	private DarkUIButton _ConfigClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _RegistryClass;

	[CompilerGenerated]
	[AccessedThroughProperty("DestinationCargoGridView")]
	private DarkDataGridView m_DefinitionClass;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitCargoGridView")]
	private DarkDataGridView m_ValClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnloadOne")]
	private DarkUIButton _WrapperClass;

	[AccessedThroughProperty("ButtonUnloadAll")]
	[CompilerGenerated]
	private DarkUIButton m_ObserverClass;

	[AccessedThroughProperty("ButtonLoadAll")]
	[CompilerGenerated]
	private DarkUIButton _IssuerClass;

	[AccessedThroughProperty("ButtonLoadOne")]
	[CompilerGenerated]
	private DarkUIButton clientClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonUnloadMode")]
	private DarkUIButton m_DicClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTransferMode")]
	private DarkUIButton consumerClass;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonContainerMode")]
	private DarkUIButton facadeClass;

	[AccessedThroughProperty("Check_GroupByUnitType")]
	[CompilerGenerated]
	private DarkUICheckBox m_ProxyClass;

	[CompilerGenerated]
	[AccessedThroughProperty("HostColSize")]
	private DataGridViewTextBoxColumn repositoryClass;

	[AccessedThroughProperty("HostColMass")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_BridgeClass;

	[CompilerGenerated]
	[AccessedThroughProperty("HostColArea")]
	private DataGridViewTextBoxColumn m_InvocationClass;

	[CompilerGenerated]
	[AccessedThroughProperty("HostColCrew")]
	private DataGridViewTextBoxColumn m_ClassClass;

	[AccessedThroughProperty("TargetColName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_RequestClass;

	[CompilerGenerated]
	[AccessedThroughProperty("TargetColSize")]
	private DataGridViewTextBoxColumn m_ValueClass;

	public ActiveUnit HostUnit;

	public ActiveUnit CargoUnit;

	protected ActiveUnit SelectedHostUnit;

	protected CargoOpsMode Mode;

	protected bool GroupUnitsByType;

	protected float CargoUnitAvailableMass;

	protected float CargoUnitAvailableArea;

	protected float CargoUnitAvailableCrew;

	protected float HostUnitAvailableMass;

	protected float HostUnitAvailableArea;

	protected float HostUnitAvailableCrew;

	protected List<Cargo> CargoUnitWorkingCargoList;

	protected List<Cargo> HostUnitWorkingCargoList;

	protected List<CargoMovementRecord> CargoActions;

	protected int MarginWidth;

	protected int FormBorderWidth;

	internal virtual DarkSectionPanel HostPanel
	{
		[CompilerGenerated]
		get
		{
			return m_RuleClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RuleClass = value;
		}
	}

	internal virtual DarkUIProgressBar HostCrewBar
	{
		[CompilerGenerated]
		get
		{
			return collectionClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionClass = value;
		}
	}

	[field: AccessedThroughProperty("HostAreaBar")]
	internal virtual DarkUIProgressBar HostAreaBar
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIProgressBar HostMassBar
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectClass = value;
		}
	}

	[field: AccessedThroughProperty("TargetPanel")]
	internal virtual DarkSectionPanel TargetPanel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIProgressBar TargetCrewBar
	{
		[CompilerGenerated]
		get
		{
			return expressionClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionClass = value;
		}
	}

	internal virtual DarkUIProgressBar TargetAreaBar
	{
		[CompilerGenerated]
		get
		{
			return dispatcherClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherClass = value;
		}
	}

	internal virtual DarkUIProgressBar TargetMassBar
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ListenerClass = value;
		}
	}

	internal virtual DarkUIButton ButtonConfirm
	{
		[CompilerGenerated]
		get
		{
			return _ConfigClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountStrategy;
			DarkUIButton configClass = _ConfigClass;
			if (configClass != null)
			{
				configClass.Click -= value2;
			}
			_ConfigClass = value;
			configClass = _ConfigClass;
			if (configClass != null)
			{
				configClass.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return _RegistryClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeStrategy;
			DarkUIButton registryClass = _RegistryClass;
			if (registryClass != null)
			{
				registryClass.Click -= value2;
			}
			_RegistryClass = value;
			registryClass = _RegistryClass;
			if (registryClass != null)
			{
				registryClass.Click += value2;
			}
		}
	}

	internal virtual DarkDataGridView DestinationCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateStrategy;
			DarkDataGridView definitionClass = m_DefinitionClass;
			if (definitionClass != null)
			{
				definitionClass.SelectionChanged -= value2;
			}
			m_DefinitionClass = value;
			definitionClass = m_DefinitionClass;
			if (definitionClass != null)
			{
				definitionClass.SelectionChanged += value2;
			}
		}
	}

	internal virtual DarkDataGridView UnitCargoGridView
	{
		[CompilerGenerated]
		get
		{
			return m_ValClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewStrategy;
			DarkDataGridView valClass = m_ValClass;
			if (valClass != null)
			{
				valClass.SelectionChanged -= value2;
			}
			m_ValClass = value;
			valClass = m_ValClass;
			if (valClass != null)
			{
				valClass.SelectionChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadOne
	{
		[CompilerGenerated]
		get
		{
			return _WrapperClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallStrategy;
			DarkUIButton wrapperClass = _WrapperClass;
			if (wrapperClass != null)
			{
				wrapperClass.Click -= value2;
			}
			_WrapperClass = value;
			wrapperClass = _WrapperClass;
			if (wrapperClass != null)
			{
				wrapperClass.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadAll
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutStrategy;
			DarkUIButton observerClass = m_ObserverClass;
			if (observerClass != null)
			{
				observerClass.Click -= value2;
			}
			m_ObserverClass = value;
			observerClass = m_ObserverClass;
			if (observerClass != null)
			{
				observerClass.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoadAll
	{
		[CompilerGenerated]
		get
		{
			return _IssuerClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchStrategy;
			DarkUIButton issuerClass = _IssuerClass;
			if (issuerClass != null)
			{
				issuerClass.Click -= value2;
			}
			_IssuerClass = value;
			issuerClass = _IssuerClass;
			if (issuerClass != null)
			{
				issuerClass.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoadOne
	{
		[CompilerGenerated]
		get
		{
			return clientClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectStrategy;
			DarkUIButton darkUIButton = clientClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			clientClass = value;
			darkUIButton = clientClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonUnloadMode
	{
		[CompilerGenerated]
		get
		{
			return m_DicClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectStrategy;
			DarkUIButton dicClass = m_DicClass;
			if (dicClass != null)
			{
				dicClass.Click -= value2;
			}
			m_DicClass = value;
			dicClass = m_DicClass;
			if (dicClass != null)
			{
				dicClass.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonTransferMode
	{
		[CompilerGenerated]
		get
		{
			return consumerClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveStrategy;
			DarkUIButton darkUIButton = consumerClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			consumerClass = value;
			darkUIButton = consumerClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonContainerMode
	{
		[CompilerGenerated]
		get
		{
			return facadeClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteStrategy;
			DarkUIButton darkUIButton = facadeClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			facadeClass = value;
			darkUIButton = facadeClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUICheckBox Check_GroupByUnitType
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = CloneStrategy;
			DarkUICheckBox proxyClass = m_ProxyClass;
			if (proxyClass != null)
			{
				proxyClass.CheckedChanged -= value2;
			}
			m_ProxyClass = value;
			proxyClass = m_ProxyClass;
			if (proxyClass != null)
			{
				proxyClass.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("HostSizeLabel")]
	internal virtual DarkLabel HostSizeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TargetSizeLabel")]
	internal virtual DarkLabel TargetSizeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HostColName")]
	internal virtual DataGridViewTextBoxColumn HostColName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridViewTextBoxColumn HostColSize
	{
		[CompilerGenerated]
		get
		{
			return repositoryClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			repositoryClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn HostColMass
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BridgeClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn HostColArea
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn HostColCrew
	{
		[CompilerGenerated]
		get
		{
			return m_ClassClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClassClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColName
	{
		[CompilerGenerated]
		get
		{
			return m_RequestClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RequestClass = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn TargetColSize
	{
		[CompilerGenerated]
		get
		{
			return m_ValueClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValueClass = value;
		}
	}

	[field: AccessedThroughProperty("TargetColMass")]
	internal virtual DataGridViewTextBoxColumn TargetColMass
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TargetColArea")]
	internal virtual DataGridViewTextBoxColumn TargetColArea
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TargetColPax")]
	internal virtual DataGridViewTextBoxColumn TargetColPax
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public bool TransferModeEnable
	{
		get
		{
			if (CargoUnit == null)
			{
				return false;
			}
			if (CargoUnit.IsFixedFacility)
			{
				return true;
			}
			return CargoUnit.IsVehicle;
		}
	}

	public bool UnloadModeEnable
	{
		get
		{
			if (CargoUnit == null)
			{
				return false;
			}
			return CargoUnit.HasCargo;
		}
	}

	public bool ContainerModeEnable
	{
		get
		{
			if (CargoUnit != null && CargoUnit.IsFixedFacility && UnitCargoGridView.SelectedRows.Count > 0 && UnitCargoGridView.SelectedRows[0].Tag != null)
			{
				if (UnitCargoGridView.SelectedRows[0].Tag is Cargo)
				{
					return ((Cargo)UnitCargoGridView.SelectedRows[0].Tag).CurrentType == Cargo.CargoObjectType.CargoContainer;
				}
				if (UnitCargoGridView.SelectedRows[0].Tag is CargoManifestItem)
				{
					return ((CargoManifestItem)UnitCargoGridView.SelectedRows[0].Tag).objectType == Cargo.CargoObjectType.CargoContainer;
				}
			}
			return false;
		}
	}

	public bool LoadingButtonsEnable
	{
		get
		{
			if (DestinationCargoGridView.SelectedRows.Count > 0)
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = DestinationCargoGridView.SelectedRows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
						if (dataGridViewRow.Tag != null && !(dataGridViewRow.Tag is ActiveUnit))
						{
							return true;
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
			}
			return false;
		}
	}

	public bool UnloadingButtonsEnable
	{
		get
		{
			if (UnitCargoGridView.SelectedRows.Count > 0)
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = UnitCargoGridView.SelectedRows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
						if (dataGridViewRow.Tag != null && !(dataGridViewRow.Tag is ActiveUnit))
						{
							return true;
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
			}
			return false;
		}
	}

	public CargoOpsV2()
	{
		base.Load += ForgotProccesor;
		Mode = CargoOpsMode.SingleUnitDisplay;
		GroupUnitsByType = false;
		CargoActions = new List<CargoMovementRecord>();
		MarginWidth = 0;
		FormBorderWidth = 0;
		RateProccesor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ThreadClass != null)
			{
				_ThreadClass.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RateProccesor()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		HostPanel = new DarkSectionPanel();
		HostSizeLabel = new DarkLabel();
		DestinationCargoGridView = new DarkDataGridView();
		HostCrewBar = new DarkUIProgressBar();
		HostAreaBar = new DarkUIProgressBar();
		HostMassBar = new DarkUIProgressBar();
		TargetPanel = new DarkSectionPanel();
		TargetSizeLabel = new DarkLabel();
		UnitCargoGridView = new DarkDataGridView();
		TargetCrewBar = new DarkUIProgressBar();
		TargetAreaBar = new DarkUIProgressBar();
		TargetMassBar = new DarkUIProgressBar();
		ButtonConfirm = new DarkUIButton();
		ButtonCancel = new DarkUIButton();
		ButtonUnloadOne = new DarkUIButton();
		ButtonUnloadAll = new DarkUIButton();
		ButtonLoadAll = new DarkUIButton();
		ButtonLoadOne = new DarkUIButton();
		ButtonUnloadMode = new DarkUIButton();
		ButtonTransferMode = new DarkUIButton();
		ButtonContainerMode = new DarkUIButton();
		Check_GroupByUnitType = new DarkUICheckBox();
		HostColName = new DataGridViewTextBoxColumn();
		HostColSize = new DataGridViewTextBoxColumn();
		HostColMass = new DataGridViewTextBoxColumn();
		HostColArea = new DataGridViewTextBoxColumn();
		HostColCrew = new DataGridViewTextBoxColumn();
		TargetColName = new DataGridViewTextBoxColumn();
		TargetColSize = new DataGridViewTextBoxColumn();
		TargetColMass = new DataGridViewTextBoxColumn();
		TargetColArea = new DataGridViewTextBoxColumn();
		TargetColPax = new DataGridViewTextBoxColumn();
		HostPanel.SuspendLayout();
		((ISupportInitialize)DestinationCargoGridView).BeginInit();
		TargetPanel.SuspendLayout();
		((ISupportInitialize)UnitCargoGridView).BeginInit();
		SuspendLayout();
		HostPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		HostPanel.BorderStyle = BorderStyle.FixedSingle;
		HostPanel.Controls.Add(HostSizeLabel);
		HostPanel.Controls.Add(DestinationCargoGridView);
		HostPanel.Controls.Add(HostCrewBar);
		HostPanel.Controls.Add(HostAreaBar);
		HostPanel.Controls.Add(HostMassBar);
		HostPanel.Location = new Point(0, 0);
		HostPanel.Name = "HostPanel";
		HostPanel.SectionHeader = "Host/Destination Cargo";
		HostPanel.Size = new Size(412, 465);
		HostPanel.TabIndex = 23;
		HostSizeLabel.ForeColor = Color.White;
		HostSizeLabel.Location = new Point(48, 25);
		HostSizeLabel.Name = "HostSizeLabel";
		HostSizeLabel.Size = new Size(298, 20);
		HostSizeLabel.TabIndex = 24;
		HostSizeLabel.Text = "最大尺寸：";
		HostSizeLabel.TextAlign = ContentAlignment.MiddleLeft;
		DestinationCargoGridView.AllowUserToAddRows = false;
		DestinationCargoGridView.AllowUserToDeleteRows = false;
		DestinationCargoGridView.AllowUserToOrderColumns = true;
		DestinationCargoGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DestinationCargoGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		DestinationCargoGridView.BorderStyle = BorderStyle.None;
		DestinationCargoGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DestinationCargoGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		DestinationCargoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DestinationCargoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DestinationCargoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DestinationCargoGridView.Columns.AddRange(HostColName, HostColSize, HostColMass, HostColArea, HostColCrew);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DestinationCargoGridView.DefaultCellStyle = dataGridViewCellStyle2;
		DestinationCargoGridView.EnableHeadersVisualStyles = false;
		DestinationCargoGridView.Location = new Point(0, 126);
		DestinationCargoGridView.Name = "DestinationCargoGridView";
		DestinationCargoGridView.ReadOnly = true;
		DestinationCargoGridView.RowHeadersVisible = false;
		DestinationCargoGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DestinationCargoGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DestinationCargoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DestinationCargoGridView.Size = new Size(412, 353);
		DestinationCargoGridView.TabIndex = 23;
		HostCrewBar.BackColor = Color.Transparent;
		HostCrewBar.CustomForeColor = Color.Transparent;
		HostCrewBar.Location = new Point(48, 94);
		HostCrewBar.Maximum = 100;
		HostCrewBar.Name = "HostCrewBar";
		HostCrewBar.ShowProgressLines = false;
		HostCrewBar.ShowProgressValue = false;
		HostCrewBar.ShowText = true;
		HostCrewBar.Size = new Size(290, 20);
		HostCrewBar.TabIndex = 22;
		HostCrewBar.Text = "PAX:";
		HostCrewBar.Value = 0;
		HostAreaBar.BackColor = Color.Transparent;
		HostAreaBar.CustomForeColor = Color.Transparent;
		HostAreaBar.Location = new Point(48, 71);
		HostAreaBar.Maximum = 100;
		HostAreaBar.Name = "HostAreaBar";
		HostAreaBar.ShowProgressLines = false;
		HostAreaBar.ShowProgressValue = false;
		HostAreaBar.ShowText = true;
		HostAreaBar.Size = new Size(290, 20);
		HostAreaBar.TabIndex = 21;
		HostAreaBar.Text = "Area:";
		HostAreaBar.Value = 0;
		HostMassBar.BackColor = Color.Transparent;
		HostMassBar.CustomForeColor = Color.Transparent;
		HostMassBar.Location = new Point(48, 48);
		HostMassBar.Maximum = 100;
		HostMassBar.Name = "HostMassBar";
		HostMassBar.ShowProgressLines = false;
		HostMassBar.ShowProgressValue = false;
		HostMassBar.ShowText = true;
		HostMassBar.Size = new Size(290, 20);
		HostMassBar.TabIndex = 20;
		HostMassBar.Text = "Mass:";
		HostMassBar.Value = 0;
		TargetPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TargetPanel.BorderStyle = BorderStyle.FixedSingle;
		TargetPanel.Controls.Add(TargetSizeLabel);
		TargetPanel.Controls.Add(UnitCargoGridView);
		TargetPanel.Controls.Add(TargetCrewBar);
		TargetPanel.Controls.Add(TargetAreaBar);
		TargetPanel.Controls.Add(TargetMassBar);
		TargetPanel.Location = new Point(414, 0);
		TargetPanel.Name = "TargetPanel";
		TargetPanel.SectionHeader = "Selected Unit Cargo";
		TargetPanel.Size = new Size(412, 465);
		TargetPanel.TabIndex = 24;
		TargetSizeLabel.ForeColor = Color.White;
		TargetSizeLabel.Location = new Point(45, 25);
		TargetSizeLabel.Name = "TargetSizeLabel";
		TargetSizeLabel.Size = new Size(298, 20);
		TargetSizeLabel.TabIndex = 25;
		TargetSizeLabel.Text = "最大尺寸：";
		TargetSizeLabel.TextAlign = ContentAlignment.MiddleLeft;
		UnitCargoGridView.AllowUserToAddRows = false;
		UnitCargoGridView.AllowUserToDeleteRows = false;
		UnitCargoGridView.AllowUserToOrderColumns = true;
		UnitCargoGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		UnitCargoGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		UnitCargoGridView.BorderStyle = BorderStyle.None;
		UnitCargoGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		UnitCargoGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		UnitCargoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		UnitCargoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		UnitCargoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		UnitCargoGridView.Columns.AddRange(TargetColName, TargetColSize, TargetColMass, TargetColArea, TargetColPax);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		UnitCargoGridView.DefaultCellStyle = dataGridViewCellStyle5;
		UnitCargoGridView.EnableHeadersVisualStyles = false;
		UnitCargoGridView.Location = new Point(0, 126);
		UnitCargoGridView.Name = "UnitCargoGridView";
		UnitCargoGridView.ReadOnly = true;
		UnitCargoGridView.RowHeadersVisible = false;
		UnitCargoGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		UnitCargoGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
		UnitCargoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		UnitCargoGridView.Size = new Size(412, 353);
		UnitCargoGridView.TabIndex = 24;
		TargetCrewBar.BackColor = Color.Transparent;
		TargetCrewBar.CustomForeColor = Color.Transparent;
		TargetCrewBar.Location = new Point(48, 94);
		TargetCrewBar.Maximum = 100;
		TargetCrewBar.Name = "TargetCrewBar";
		TargetCrewBar.ShowProgressLines = false;
		TargetCrewBar.ShowProgressValue = false;
		TargetCrewBar.ShowText = true;
		TargetCrewBar.Size = new Size(290, 20);
		TargetCrewBar.TabIndex = 22;
		TargetCrewBar.Text = "PAX:";
		TargetCrewBar.Value = 0;
		TargetAreaBar.BackColor = Color.Transparent;
		TargetAreaBar.CustomForeColor = Color.Transparent;
		TargetAreaBar.Location = new Point(48, 71);
		TargetAreaBar.Maximum = 100;
		TargetAreaBar.Name = "TargetAreaBar";
		TargetAreaBar.ShowProgressLines = false;
		TargetAreaBar.ShowProgressValue = false;
		TargetAreaBar.ShowText = true;
		TargetAreaBar.Size = new Size(290, 20);
		TargetAreaBar.TabIndex = 21;
		TargetAreaBar.Text = "Area:";
		TargetAreaBar.Value = 0;
		TargetMassBar.BackColor = Color.Transparent;
		TargetMassBar.CustomForeColor = Color.Transparent;
		TargetMassBar.Location = new Point(48, 48);
		TargetMassBar.Maximum = 100;
		TargetMassBar.Name = "TargetMassBar";
		TargetMassBar.ShowProgressLines = false;
		TargetMassBar.ShowProgressValue = false;
		TargetMassBar.ShowText = true;
		TargetMassBar.Size = new Size(290, 20);
		TargetMassBar.TabIndex = 20;
		TargetMassBar.Text = "Mass:";
		TargetMassBar.Value = 0;
		ButtonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonConfirm.BackColor = Color.Transparent;
		ButtonConfirm.DialogResult = DialogResult.None;
		ButtonConfirm.ForeColor = SystemColors.Control;
		ButtonConfirm.Location = new Point(310, 505);
		ButtonConfirm.Name = "ButtonConfirm";
		ButtonConfirm.Padding = new Padding(5);
		ButtonConfirm.RoundRadius = 0;
		ButtonConfirm.Size = new Size(91, 23);
		ButtonConfirm.TabIndex = 29;
		ButtonConfirm.Text = "确认";
		ButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonCancel.BackColor = Color.Transparent;
		ButtonCancel.DialogResult = DialogResult.None;
		ButtonCancel.ForeColor = SystemColors.Control;
		ButtonCancel.Location = new Point(426, 505);
		ButtonCancel.Name = "ButtonCancel";
		ButtonCancel.Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		ButtonCancel.Size = new Size(91, 23);
		ButtonCancel.TabIndex = 30;
		ButtonCancel.Text = "取消";
		ButtonUnloadOne.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonUnloadOne.BackColor = Color.Transparent;
		ButtonUnloadOne.DialogResult = DialogResult.None;
		ButtonUnloadOne.ForeColor = SystemColors.Control;
		ButtonUnloadOne.Location = new Point(534, 476);
		ButtonUnloadOne.Name = "ButtonUnloadOne";
		ButtonUnloadOne.Padding = new Padding(5);
		ButtonUnloadOne.RoundRadius = 0;
		ButtonUnloadOne.Size = new Size(91, 23);
		ButtonUnloadOne.TabIndex = 32;
		ButtonUnloadOne.Text = "< Unload One";
		ButtonUnloadAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonUnloadAll.BackColor = Color.Transparent;
		ButtonUnloadAll.DialogResult = DialogResult.None;
		ButtonUnloadAll.ForeColor = SystemColors.Control;
		ButtonUnloadAll.Location = new Point(437, 476);
		ButtonUnloadAll.Name = "ButtonUnloadAll";
		ButtonUnloadAll.Padding = new Padding(5);
		ButtonUnloadAll.RoundRadius = 0;
		ButtonUnloadAll.Size = new Size(91, 23);
		ButtonUnloadAll.TabIndex = 31;
		ButtonUnloadAll.Text = "<< Unload All";
		ButtonLoadAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ButtonLoadAll.BackColor = Color.Transparent;
		ButtonLoadAll.DialogResult = DialogResult.None;
		ButtonLoadAll.ForeColor = SystemColors.Control;
		ButtonLoadAll.Location = new Point(298, 476);
		ButtonLoadAll.Name = "ButtonLoadAll";
		ButtonLoadAll.Padding = new Padding(5);
		ButtonLoadAll.RoundRadius = 0;
		ButtonLoadAll.Size = new Size(91, 23);
		ButtonLoadAll.TabIndex = 30;
		ButtonLoadAll.Text = "Load All >>";
		ButtonLoadOne.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ButtonLoadOne.BackColor = Color.Transparent;
		ButtonLoadOne.DialogResult = DialogResult.None;
		ButtonLoadOne.ForeColor = SystemColors.Control;
		ButtonLoadOne.Location = new Point(201, 475);
		ButtonLoadOne.Name = "ButtonLoadOne";
		ButtonLoadOne.Padding = new Padding(5);
		ButtonLoadOne.RoundRadius = 0;
		ButtonLoadOne.Size = new Size(91, 23);
		ButtonLoadOne.TabIndex = 29;
		ButtonLoadOne.Text = "Load One >";
		ButtonUnloadMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonUnloadMode.BackColor = Color.Transparent;
		ButtonUnloadMode.DialogResult = DialogResult.None;
		ButtonUnloadMode.ForeColor = SystemColors.Control;
		ButtonUnloadMode.Location = new Point(685, 505);
		ButtonUnloadMode.Name = "ButtonUnloadMode";
		ButtonUnloadMode.Padding = new Padding(5);
		ButtonUnloadMode.RoundRadius = 0;
		ButtonUnloadMode.Size = new Size(96, 23);
		ButtonUnloadMode.TabIndex = 34;
		ButtonUnloadMode.Text = "卸货";
		ButtonTransferMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonTransferMode.BackColor = Color.Transparent;
		ButtonTransferMode.DialogResult = DialogResult.None;
		ButtonTransferMode.ForeColor = SystemColors.Control;
		ButtonTransferMode.Location = new Point(583, 505);
		ButtonTransferMode.Name = "ButtonTransferMode";
		ButtonTransferMode.Padding = new Padding(5);
		ButtonTransferMode.RoundRadius = 0;
		ButtonTransferMode.Size = new Size(96, 23);
		ButtonTransferMode.TabIndex = 35;
		ButtonTransferMode.Text = "Transfer Cargo";
		ButtonContainerMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonContainerMode.BackColor = Color.Transparent;
		ButtonContainerMode.DialogResult = DialogResult.None;
		ButtonContainerMode.ForeColor = SystemColors.Control;
		ButtonContainerMode.Location = new Point(481, 505);
		ButtonContainerMode.Name = "ButtonContainerMode";
		ButtonContainerMode.Padding = new Padding(5);
		ButtonContainerMode.RoundRadius = 0;
		ButtonContainerMode.Size = new Size(96, 23);
		ButtonContainerMode.TabIndex = 36;
		ButtonContainerMode.Text = "Container...";
		Check_GroupByUnitType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Check_GroupByUnitType.BackColor = Color.Transparent;
		Check_GroupByUnitType.Checked = false;
		Check_GroupByUnitType.Cursor = Cursors.Hand;
		Check_GroupByUnitType.ForeColor = Color.FromArgb(209, 209, 209);
		Check_GroupByUnitType.Location = new Point(689, 477);
		Check_GroupByUnitType.Name = "Check_GroupByUnitType";
		Check_GroupByUnitType.Size = new Size(132, 18);
		Check_GroupByUnitType.TabIndex = 37;
		Check_GroupByUnitType.Text = "Group by Unit Type";
		HostColName.HeaderText = "名称";
		HostColName.MinimumWidth = 6;
		HostColName.Name = "HostColName";
		HostColName.ReadOnly = true;
		HostColName.SortMode = DataGridViewColumnSortMode.NotSortable;
		HostColName.Width = 192;
		HostColSize.HeaderText = "尺寸";
		HostColSize.MinimumWidth = 6;
		HostColSize.Name = "HostColSize";
		HostColSize.ReadOnly = true;
		HostColSize.Width = 64;
		HostColMass.HeaderText = "Mass";
		HostColMass.MinimumWidth = 6;
		HostColMass.Name = "HostColMass";
		HostColMass.ReadOnly = true;
		HostColMass.Width = 50;
		HostColArea.HeaderText = "区域";
		HostColArea.MinimumWidth = 6;
		HostColArea.Name = "HostColArea";
		HostColArea.ReadOnly = true;
		HostColArea.Width = 50;
		HostColCrew.HeaderText = "PAX";
		HostColCrew.MinimumWidth = 6;
		HostColCrew.Name = "HostColCrew";
		HostColCrew.ReadOnly = true;
		HostColCrew.Width = 36;
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
		TargetColArea.Width = 50;
		TargetColPax.HeaderText = "PAX";
		TargetColPax.MinimumWidth = 6;
		TargetColPax.Name = "TargetColPax";
		TargetColPax.ReadOnly = true;
		TargetColPax.Width = 36;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(827, 535);
		base.Controls.Add(ButtonUnloadOne);
		base.Controls.Add(Check_GroupByUnitType);
		base.Controls.Add(ButtonUnloadAll);
		base.Controls.Add(ButtonContainerMode);
		base.Controls.Add(ButtonLoadOne);
		base.Controls.Add(ButtonLoadAll);
		base.Controls.Add(ButtonTransferMode);
		base.Controls.Add(ButtonUnloadMode);
		base.Controls.Add(ButtonCancel);
		base.Controls.Add(ButtonConfirm);
		base.Controls.Add(TargetPanel);
		base.Controls.Add(HostPanel);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CargoOpsV2";
		Text = "货运操作";
		HostPanel.ResumeLayout(performLayout: false);
		((ISupportInitialize)DestinationCargoGridView).EndInit();
		TargetPanel.ResumeLayout(performLayout: false);
		((ISupportInitialize)UnitCargoGridView).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void FlushProccesor()
	{
		CargoUnitWorkingCargoList = new List<Cargo>();
		HostUnitWorkingCargoList = new List<Cargo>();
		if (CargoUnit.IsGroup)
		{
			bool flag = false;
			foreach (ActiveUnit value in ((Group)CargoUnit).Units.Values)
			{
				if (value is ICargoHost)
				{
					CargoUnitWorkingCargoList.AddRange(value.OnboardCargo);
					flag = true;
				}
			}
			if (!flag)
			{
				DarkMessageBox.ShowWarning("Cannot perform cargo operations on the selected group. The group contains no cargo hosts.", "货运操作");
				Close();
			}
		}
		else
		{
			CargoUnitWorkingCargoList.AddRange(CargoUnit.OnboardCargo);
		}
		SelectedHostUnit = HostUnit;
		if (HostUnit == null)
		{
			Mode = CargoOpsMode.SingleUnitDisplay;
			return;
		}
		Mode = CargoOpsMode.HostUnitAndHostedUnit;
		if (HostUnit.IsGroup)
		{
			bool flag2 = false;
			foreach (ActiveUnit value2 in ((Group)HostUnit).Units.Values)
			{
				if (value2 is ICargoHost)
				{
					HostUnitWorkingCargoList.AddRange(value2.OnboardCargo);
					flag2 = true;
				}
			}
			if (!flag2)
			{
				DarkMessageBox.ShowWarning("Cannot perform cargo operations. The selected unit's host group does not contain a cargo host.", "货运操作");
				Close();
			}
		}
		else if (HostUnit is ICargoHost)
		{
			HostUnitWorkingCargoList.AddRange(HostUnit.OnboardCargo);
		}
		else
		{
			DarkMessageBox.ShowWarning("Cannot perform cargo operations. The selected unit's host is not a cargo host.", "货运操作");
			Close();
		}
	}

	private void ForgotProccesor(object sender, EventArgs e)
	{
		if (CargoUnit == null)
		{
			DarkMessageBox.ShowWarning("No unit selected for cargo operations.", "货运操作");
			Close();
		}
		else if (!(CargoUnit is ICargoHost) && !CargoUnit.IsGroup)
		{
			DarkMessageBox.ShowWarning("Cannot perform cargo operations on the selected unit. The unit is not a cargo host.", "货运操作");
			Close();
		}
		FlushProccesor();
		MarginWidth = TargetPanel.Left - (HostPanel.Left + HostPanel.Width);
		FormBorderWidth = base.Width - base.ClientSize.Width;
		ResetUI();
		ManageProccesor();
	}

	public void RefreshForm()
	{
		FlushProccesor();
		ResetUI();
		ManageProccesor();
	}

	public void ResetUI()
	{
		if (Check_GroupByUnitType.Checked != GroupUnitsByType)
		{
			Check_GroupByUnitType.Checked = GroupUnitsByType;
		}
		string name = CargoUnit.Name;
		name = (CargoUnit.IsGroup ? (name + " [Selected Group]") : (name + " [Selected Unit]"));
		TargetPanel.SectionHeader = name;
		if (Mode == CargoOpsMode.SingleUnitDisplay)
		{
			HostPanel.SectionHeader = "";
			HostPanel.Visible = false;
			ButtonLoadOne.Visible = false;
			ButtonLoadAll.Visible = false;
			ButtonUnloadOne.Visible = false;
			ButtonUnloadAll.Visible = false;
			ButtonConfirm.Visible = false;
			ButtonCancel.Visible = false;
			ButtonContainerMode.Visible = true;
			ButtonTransferMode.Visible = true;
			ButtonUnloadMode.Visible = true;
			ButtonContainerMode.Enabled = ContainerModeEnable;
			ButtonTransferMode.Enabled = TransferModeEnable;
			ButtonUnloadMode.Enabled = UnloadModeEnable;
			base.Width = TargetPanel.Width + FormBorderWidth;
			TargetPanel.Left = 0;
			return;
		}
		switch (Mode)
		{
		case CargoOpsMode.SingleUnitUnloadToMap:
			HostPanel.SectionHeader = "[Cargo to Unload]";
			break;
		case CargoOpsMode.SingleUnitTransferToNearbyUnits:
			name = SelectedHostUnit.Name;
			name = (SelectedHostUnit.IsGroup ? (name + " [Trasnfer to Group]") : (name + " [Transfer to Unit]"));
			HostPanel.SectionHeader = name;
			break;
		case CargoOpsMode.HostUnitAndHostedUnit:
			name = SelectedHostUnit.Name;
			name = (SelectedHostUnit.IsGroup ? (name + " [Hosting Group]") : (name + " [Hosting Unit]"));
			HostPanel.SectionHeader = name;
			break;
		}
		HostPanel.Visible = true;
		ButtonLoadOne.Visible = true;
		ButtonLoadAll.Visible = true;
		ButtonUnloadOne.Visible = true;
		ButtonUnloadAll.Visible = true;
		ButtonConfirm.Visible = true;
		ButtonCancel.Visible = true;
		ButtonContainerMode.Visible = false;
		ButtonTransferMode.Visible = false;
		ButtonUnloadMode.Visible = false;
		CollectProccesor();
		base.Width = HostPanel.Left + HostPanel.Width + MarginWidth + TargetPanel.Width + FormBorderWidth;
		TargetPanel.Left = HostPanel.Left + HostPanel.Width + MarginWidth;
	}

	private void CollectProccesor()
	{
		ButtonLoadOne.Enabled = LoadingButtonsEnable;
		ButtonLoadAll.Enabled = ButtonLoadOne.Enabled;
		ButtonUnloadOne.Enabled = UnloadingButtonsEnable;
		ButtonUnloadAll.Enabled = ButtonUnloadOne.Enabled;
		if (ButtonContainerMode.Visible)
		{
			ButtonContainerMode.Enabled = ContainerModeEnable;
		}
	}

	private void OrderProccesor()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		CargoUnitAvailableMass = 0f;
		CargoUnitAvailableArea = 0f;
		CargoUnitAvailableCrew = 0f;
		if (CargoUnit.IsGroup)
		{
			list.AddRange(((Group)CargoUnit).Units.Values.ToList());
		}
		else
		{
			list.Add(CargoUnit);
		}
		foreach (ICargoHost item in list)
		{
			CargoUnitAvailableMass += item.GetCargo_Mass();
			CargoUnitAvailableArea += item.GetCargo_Area();
			CargoUnitAvailableCrew += item.GetCargo_Crew();
		}
		foreach (Cargo cargoUnitWorkingCargo in CargoUnitWorkingCargoList)
		{
			CargoUnitAvailableMass -= cargoUnitWorkingCargo.RequiredMass;
			CargoUnitAvailableArea -= cargoUnitWorkingCargo.RequiredArea;
			CargoUnitAvailableCrew -= cargoUnitWorkingCargo.RequiredCrewSpace;
		}
		if (SelectedHostUnit == null)
		{
			if (Mode != CargoOpsMode.SingleUnitUnloadToMap)
			{
				return;
			}
			{
				foreach (Cargo hostUnitWorkingCargo in HostUnitWorkingCargoList)
				{
					HostUnitAvailableMass += hostUnitWorkingCargo.RequiredMass;
					HostUnitAvailableArea += hostUnitWorkingCargo.RequiredArea;
					HostUnitAvailableCrew += hostUnitWorkingCargo.RequiredCrewSpace;
				}
				return;
			}
		}
		list.Clear();
		HostUnitAvailableMass = 0f;
		HostUnitAvailableArea = 0f;
		HostUnitAvailableCrew = 0f;
		if (SelectedHostUnit.IsGroup)
		{
			list.AddRange(((Group)SelectedHostUnit).Units.Values.ToList());
		}
		else
		{
			list.Add(SelectedHostUnit);
		}
		foreach (ICargoHost item2 in list)
		{
			HostUnitAvailableMass += item2.GetCargo_Mass();
			HostUnitAvailableArea += item2.GetCargo_Area();
			HostUnitAvailableCrew += item2.GetCargo_Crew();
		}
		foreach (Cargo hostUnitWorkingCargo2 in HostUnitWorkingCargoList)
		{
			HostUnitAvailableMass -= hostUnitWorkingCargo2.RequiredMass;
			HostUnitAvailableArea -= hostUnitWorkingCargo2.RequiredArea;
			HostUnitAvailableCrew -= hostUnitWorkingCargo2.RequiredCrewSpace;
		}
	}

	private void RegisterProccesor(DarkDataGridView darkDataGridView_0, ActiveUnit activeUnit_0, float float_0, float float_1, float float_2)
	{
		int index = 1;
		int index2 = 2;
		int index3 = 3;
		int index4 = 4;
		int num = 5000;
		if (activeUnit_0 != null && activeUnit_0 is ICargoHost)
		{
			num = (int)((ICargoHost)activeUnit_0).GetCargo_Type();
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = ((IEnumerable)darkDataGridView_0.Rows).GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (activeUnit_0 == null)
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = darkDataGridView_0.DefaultCellStyle.ForeColor;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = darkDataGridView_0.DefaultCellStyle.SelectionForeColor;
				}
				else if (!(dataGridViewRow.Tag is ActiveUnit) && (dataGridViewRow.Tag is Cargo || dataGridViewRow.Tag is CargoManifestItem))
				{
					if (Conversions.ToInteger(dataGridViewRow.Cells[index].Tag) <= num && Conversions.ToSingle(dataGridViewRow.Cells[index2].Value) <= float_0 && Conversions.ToSingle(dataGridViewRow.Cells[index3].Value) <= float_1 && Conversions.ToSingle(dataGridViewRow.Cells[index4].Value) <= float_2)
					{
						dataGridViewRow.DefaultCellStyle.ForeColor = darkDataGridView_0.DefaultCellStyle.ForeColor;
						dataGridViewRow.DefaultCellStyle.SelectionForeColor = darkDataGridView_0.DefaultCellStyle.SelectionForeColor;
					}
					else
					{
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
						dataGridViewRow.DefaultCellStyle.SelectionForeColor = Color.Red;
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
	}

	private void ManageProccesor()
	{
		if (CargoUnit == null || (!(CargoUnit is ICargoHost) && !CargoUnit.IsGroup))
		{
			return;
		}
		OrderProccesor();
		new List<ActiveUnit>(new ActiveUnit[1] { CargoUnit });
		MapperListenerManager.CheckStrategy(UnitCargoGridView, CargoUnit, CargoUnitWorkingCargoList, GroupUnitsByType);
		MapperListenerManager.InterruptStrategy(CargoUnit, TargetSizeLabel, TargetMassBar, CargoUnitAvailableMass, TargetAreaBar, CargoUnitAvailableArea, TargetCrewBar, CargoUnitAvailableCrew);
		switch (Mode)
		{
		case CargoOpsMode.SingleUnitTransferToNearbyUnits:
		case CargoOpsMode.HostUnitAndHostedUnit:
			if (SelectedHostUnit != null)
			{
				MapperListenerManager.CheckStrategy(DestinationCargoGridView, SelectedHostUnit, HostUnitWorkingCargoList, GroupUnitsByType);
				MapperListenerManager.InterruptStrategy(SelectedHostUnit, HostSizeLabel, HostMassBar, HostUnitAvailableMass, HostAreaBar, HostUnitAvailableArea, HostCrewBar, HostUnitAvailableCrew);
			}
			break;
		default:
			DestinationCargoGridView.Rows.Clear();
			break;
		case CargoOpsMode.SingleUnitUnloadToMap:
			MapperListenerManager.CheckStrategy(DestinationCargoGridView, null, HostUnitWorkingCargoList, GroupUnitsByType);
			MapperListenerManager.InterruptStrategy(null, HostSizeLabel, HostMassBar, HostUnitAvailableMass, HostAreaBar, HostUnitAvailableArea, HostCrewBar, HostUnitAvailableCrew);
			break;
		}
		RegisterProccesor(UnitCargoGridView, SelectedHostUnit, HostUnitAvailableMass, HostUnitAvailableArea, HostUnitAvailableCrew);
		RegisterProccesor(DestinationCargoGridView, CargoUnit, CargoUnitAvailableMass, CargoUnitAvailableArea, CargoUnitAvailableCrew);
		ViewStrategy(null, null);
		ValidateStrategy(null, null);
	}

	private bool RevertProccesor()
	{
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		List<ActiveUnit> list3 = new List<ActiveUnit>();
		if (Mode == CargoOpsMode.SingleUnitUnloadToMap)
		{
			if (CargoUnit.IsGroup)
			{
				list3.AddRange(((Group)CargoUnit).Units.Values);
			}
			else
			{
				list3.Add(CargoUnit);
			}
			CoreClientCode.CargoOpsAction_Core(list3, null, HostUnitWorkingCargoList);
		}
		else
		{
			List<Cargo> list4 = (CargoUnit.IsGroup ? MapperListenerManager.ChangeStrategy(CargoUnit) : CargoUnit.OnboardCargo.ToList());
			foreach (Cargo cargoUnitWorkingCargo in CargoUnitWorkingCargoList)
			{
				if (!list4.Contains(cargoUnitWorkingCargo))
				{
					list2.Add(cargoUnitWorkingCargo);
				}
			}
			List<Cargo> list5 = (SelectedHostUnit.IsGroup ? MapperListenerManager.ChangeStrategy(SelectedHostUnit) : SelectedHostUnit.OnboardCargo.ToList());
			foreach (Cargo hostUnitWorkingCargo in HostUnitWorkingCargoList)
			{
				if (!list5.Contains(hostUnitWorkingCargo))
				{
					list.Add(hostUnitWorkingCargo);
				}
			}
			switch (Mode)
			{
			case CargoOpsMode.HostUnitAndHostedUnit:
				if (list.Count > 0)
				{
					list3.Clear();
					list3.Add(CargoUnit);
					CoreClientCode.CargoOpsAction_Core(list3, SelectedHostUnit, list);
				}
				if (list2.Count > 0)
				{
					list3.Clear();
					if (SelectedHostUnit.IsGroup)
					{
						list3.AddRange(((Group)SelectedHostUnit).Units.Values);
					}
					else
					{
						list3.Add(SelectedHostUnit);
					}
					CoreClientCode.CargoOpsAction_Core(list3, CargoUnit, list2);
				}
				break;
			case CargoOpsMode.SingleUnitTransferToNearbyUnits:
				if (list.Count > 0)
				{
					if (CargoUnit.IsGroup)
					{
						list3.AddRange(((Group)CargoUnit).Units.Values);
					}
					else
					{
						list3.Add(CargoUnit);
					}
					CoreClientCode.CargoOpsAction_Core(list3, SelectedHostUnit, list);
				}
				if (list2.Count > 0)
				{
					list3.Clear();
					list3.Add(SelectedHostUnit);
					CoreClientCode.CargoOpsAction_Core(list3, CargoUnit, list2);
				}
				break;
			}
		}
		return true;
	}

	private void CountStrategy(object sender, EventArgs e)
	{
		if (!RevertProccesor())
		{
			DarkMessageBox.ShowWarning("One or more cargo items could not be moved due to capacity limitations.", "货运操作");
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		Close();
	}

	private void CustomizeStrategy(object sender, EventArgs e)
	{
		Close();
	}

	private void CloneStrategy(object object_0)
	{
		GroupUnitsByType = Check_GroupByUnitType.Checked;
		ManageProccesor();
	}

	private void ConnectStrategy(object sender, EventArgs e)
	{
		string text = Cargo.CanUnloadToMap(CargoUnit);
		if (Operators.CompareString(text, "Ok", TextCompare: true) == 0)
		{
			Mode = CargoOpsMode.SingleUnitUnloadToMap;
			ResetUI();
		}
		else
		{
			DarkMessageBox.ShowWarning(text, "货运操作");
		}
	}

	private void MoveStrategy(object sender, EventArgs e)
	{
		List<ActiveUnit> possibleTransferDestinations = Cargo.GetPossibleTransferDestinations(CargoUnit);
		SelectedHostUnit = null;
		if (possibleTransferDestinations.Count == 1)
		{
			SelectedHostUnit = possibleTransferDestinations[0];
		}
		else if (possibleTransferDestinations.Count <= 0)
		{
			DarkMessageBox.ShowWarning("No valid destination units are nearby (less than 2nm distance.)", "货运操作");
		}
		else
		{
			List<ActiveUnit> list_ = new List<ActiveUnit>();
			UnitSelection.CallDialogWithUnits(possibleTransferDestinations, bool_0: false, ref list_);
			if (list_.Count > 0)
			{
				SelectedHostUnit = list_[0];
			}
		}
		HostUnit = SelectedHostUnit;
		if (SelectedHostUnit != null)
		{
			Mode = CargoOpsMode.SingleUnitTransferToNearbyUnits;
			if (SelectedHostUnit.IsGroup)
			{
				HostUnitWorkingCargoList = MapperListenerManager.ChangeStrategy(SelectedHostUnit);
			}
			else
			{
				HostUnitWorkingCargoList = SelectedHostUnit.OnboardCargo.ToList();
			}
			ResetUI();
			ManageProccesor();
		}
	}

	private void DeleteStrategy(object sender, EventArgs e)
	{
		if (UnitCargoGridView.SelectedRows.Count <= 0 || UnitCargoGridView.SelectedRows[0].Tag == null)
		{
			return;
		}
		Cargo cargo = null;
		if (UnitCargoGridView.SelectedRows[0].Tag is Cargo)
		{
			if (((Cargo)UnitCargoGridView.SelectedRows[0].Tag).CurrentType == Cargo.CargoObjectType.CargoContainer)
			{
				cargo = (Cargo)UnitCargoGridView.SelectedRows[0].Tag;
			}
		}
		else if (UnitCargoGridView.SelectedRows[0].Tag is CargoManifestItem)
		{
			CargoManifestItem cargoManifestItem = (CargoManifestItem)UnitCargoGridView.SelectedRows[0].Tag;
			if (cargoManifestItem.objectType == Cargo.CargoObjectType.CargoContainer)
			{
				cargo = CargoHostHelper.FindMatchingCargo(CargoUnitWorkingCargoList, cargoManifestItem);
			}
		}
		if (cargo == null)
		{
			return;
		}
		if (CargoUnit.IsFixedFacility)
		{
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsContainer.SelectedContainer = cargo.CargoObjectContainer;
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsContainer.SelectedHost = CargoUnit;
			if (ItemExporter.ConnectInterruptibleTemplate.CargoOpsContainer.ShowDialog() == DialogResult.OK)
			{
				ManageProccesor();
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("Container contents can only be loaded or unloaded while the container is in a fixed facility.", "货运操作");
		}
	}

	private List<Cargo> AddStrategy(DarkDataGridView darkDataGridView_0, List<Cargo> list_0, bool bool_0)
	{
		List<Cargo> list = new List<Cargo>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = darkDataGridView_0.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag == null || dataGridViewRow.Tag is ActiveUnit)
				{
					continue;
				}
				if (dataGridViewRow.Tag is CargoManifestItem)
				{
					CargoManifestItem cargoManifestItem = (CargoManifestItem)dataGridViewRow.Tag;
					int num = 1;
					if (bool_0)
					{
						num = cargoManifestItem.quantity;
					}
					foreach (Cargo item2 in list_0)
					{
						if (cargoManifestItem.IsMatch(item2) && !list.Contains(item2))
						{
							list.Add(item2);
							num--;
						}
						if (num < 1)
						{
							break;
						}
					}
				}
				else if (dataGridViewRow.Tag is Cargo)
				{
					Cargo item = (Cargo)dataGridViewRow.Tag;
					if (list_0.Contains(item) && !list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	public int GetGroupCargoSizeMaximum(ActiveUnit activeUnit_0)
	{
		int num = 0;
		if (activeUnit_0.IsGroup)
		{
			foreach (ActiveUnit item in ((Group)activeUnit_0).Units.Values.ToList())
			{
				if (item is ICargoHost)
				{
					ICargoHost cargoHost = (ICargoHost)item;
					if ((int)cargoHost.GetCargo_Type() > num)
					{
						num = (int)cargoHost.GetCargo_Type();
					}
				}
			}
			return num;
		}
		return num;
	}

	private void DestroyStrategy(bool bool_0, bool bool_1)
	{
		List<Cargo> list = AddStrategy(DestinationCargoGridView, HostUnitWorkingCargoList, bool_0);
		if (bool_1)
		{
			List<Cargo> list2 = new List<Cargo>();
			float num = CargoUnitAvailableMass;
			float num2 = CargoUnitAvailableArea;
			float num3 = CargoUnitAvailableCrew;
			int num4 = 0;
			num4 = (CargoUnit.IsGroup ? GetGroupCargoSizeMaximum(CargoUnit) : ((int)((ICargoHost)CargoUnit).GetCargo_Type()));
			foreach (Cargo item in list)
			{
				if ((int)item.RequiredCargoType <= num4)
				{
					if (!(num - item.RequiredMass < 0f) && !(num2 - item.RequiredArea < 0f) && num3 - item.RequiredCrewSpace >= 0f)
					{
						num -= item.RequiredMass;
						num2 -= item.RequiredArea;
						num3 -= item.RequiredCrewSpace;
					}
					else
					{
						list2.Add(item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			if (list2.Count > 0)
			{
				list = list.Except(list2).ToList();
				DarkMessageBox.ShowWarning("One or more of the selected cargo items could not be loaded due to cargo size category, mass, area, or PAX capacity limits.", "货运操作");
			}
		}
		if (list.Count > 0)
		{
			HostUnitWorkingCargoList = HostUnitWorkingCargoList.Except(list).ToList();
			CargoUnitWorkingCargoList.AddRange(list);
			ManageProccesor();
		}
	}

	private void ComputeStrategy(bool bool_0, bool bool_1)
	{
		List<Cargo> list = AddStrategy(UnitCargoGridView, CargoUnitWorkingCargoList, bool_0);
		if (bool_1)
		{
			List<Cargo> list2 = new List<Cargo>();
			float num = HostUnitAvailableMass;
			float num2 = HostUnitAvailableArea;
			float num3 = HostUnitAvailableCrew;
			int num4 = 0;
			num4 = (SelectedHostUnit.IsGroup ? GetGroupCargoSizeMaximum(SelectedHostUnit) : ((int)((ICargoHost)SelectedHostUnit).GetCargo_Type()));
			foreach (Cargo item in list)
			{
				if ((int)item.RequiredCargoType <= num4)
				{
					if (!(num - item.RequiredMass < 0f) && !(num2 - item.RequiredArea < 0f) && num3 - item.RequiredCrewSpace >= 0f)
					{
						num -= item.RequiredMass;
						num2 -= item.RequiredArea;
						num3 -= item.RequiredCrewSpace;
					}
					else
					{
						list2.Add(item);
					}
				}
				else
				{
					list2.Add(item);
				}
			}
			if (list2.Count > 0)
			{
				list = list.Except(list2).ToList();
				DarkMessageBox.ShowWarning("One or more of the selected cargo items could not be transferred due to cargo size category, mass, area, or PAX capacity limits.", "货运操作");
			}
		}
		if (list.Count > 0)
		{
			CargoUnitWorkingCargoList = CargoUnitWorkingCargoList.Except(list).ToList();
			HostUnitWorkingCargoList.AddRange(list);
			ManageProccesor();
		}
	}

	private void PatchStrategy(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		DestroyStrategy(bool_0: true, bool_);
	}

	private void SelectStrategy(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		DestroyStrategy(bool_0: false, bool_);
	}

	private void CallStrategy(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		ComputeStrategy(bool_0: false, bool_);
	}

	private void LogoutStrategy(object sender, EventArgs e)
	{
		bool bool_ = Mode != CargoOpsMode.SingleUnitUnloadToMap;
		ComputeStrategy(bool_0: true, bool_);
	}

	private void ViewStrategy(object sender, EventArgs e)
	{
		CollectProccesor();
	}

	private void ValidateStrategy(object sender, EventArgs e)
	{
		CollectProccesor();
	}
}
