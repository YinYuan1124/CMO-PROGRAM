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
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ReferencePointManager : Form
{
	[DoNotPrune]
	[DoNotObfuscate]
	private sealed class RefPointTag
	{
		public string Name { get; set; }

		public ReferencePointFlag RedFlag { get; set; }

		public RefPointTag(string string_0, ReferencePointFlag referencePointFlag_0)
		{
			Name = string_0;
			RedFlag = referencePointFlag_0;
		}
	}

	private IContainer containerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointEditorPanel")]
	private Panel m_ComposerUtils;

	[AccessedThroughProperty("AddnewTagButton")]
	[CompilerGenerated]
	private DarkUIButton m_ModelUtils;

	[AccessedThroughProperty("DeleteTagButton")]
	[CompilerGenerated]
	private DarkUIButton _AdvisorUtils;

	[AccessedThroughProperty("RemoveTagFromRef")]
	[CompilerGenerated]
	private DarkUIButton m_CustomerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointTagListCombo")]
	private DarkUIComboBox m_SerializerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Tags")]
	private DarkListView refUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("DeleteRefPoint")]
	private DarkUIButton m_ErrorUtils;

	[AccessedThroughProperty("RefPointLongitude")]
	[CompilerGenerated]
	private DarkLabel m_CodeUtils;

	[AccessedThroughProperty("JumpToRefPointButton")]
	[CompilerGenerated]
	private DarkUIButton m_ContextUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointName")]
	private DarkUITextBox proccesorUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPointColorButton")]
	private Button m_StrategyUtils;

	[AccessedThroughProperty("Tags")]
	[CompilerGenerated]
	private DarkLabel configurationUtils;

	[AccessedThroughProperty("AddTagToRefPointButton")]
	[CompilerGenerated]
	private DarkUIButton _TokenUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("FlowPanelTabTagsFilter")]
	private FlowLayoutPanel m_ResolverUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button publisherUtils;

	[AccessedThroughProperty("LV_ReferencePoints")]
	[CompilerGenerated]
	private DarkListView serverUtils;

	[AccessedThroughProperty("RefPointListContainer")]
	[CompilerGenerated]
	private Panel adapterUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRemoveRefPointToArea")]
	private DarkUIButton m_SchemaUtils;

	[AccessedThroughProperty("ButtonAddRefPointToArea")]
	[CompilerGenerated]
	private DarkUIButton _UtilsUtils;

	[AccessedThroughProperty("ButtonCreateNewArea")]
	[CompilerGenerated]
	private DarkUIButton singletonUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonDeleteArea")]
	private DarkUIButton _RecordUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Zones")]
	private DarkTreeView _ExceptionUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTabZones")]
	private Button m_AttrUtils;

	[AccessedThroughProperty("ButtonTabNoNavZones")]
	[CompilerGenerated]
	private Button _VisitorUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonTabExclusionZones")]
	private Button m_ExporterUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesAircraft")]
	private DarkCheckBox prototypeUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("GB_Violators")]
	private DarkGroupBox comparatorUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesSubmarines")]
	private DarkCheckBox itemUtils;

	[AccessedThroughProperty("CBAppliesShips")]
	[CompilerGenerated]
	private DarkCheckBox m_SetterUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("CBAppliesLandUnits")]
	private DarkCheckBox _CreatorUtils;

	[AccessedThroughProperty("CBZoneIsLocked")]
	[CompilerGenerated]
	private DarkCheckBox templateUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_AreaName")]
	private DarkUITextBox mappingUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonImport")]
	private DarkUIButton m_MockUtils;

	[AccessedThroughProperty("ButtonExport")]
	[CompilerGenerated]
	private DarkUIButton _TagUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonSave")]
	private DarkUIButton _FieldUtils;

	[AccessedThroughProperty("DGV_ExlusionZone")]
	[CompilerGenerated]
	private DarkDataGridView m_QueueUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("lblTransform")]
	private DarkLabel regUtils;

	[AccessedThroughProperty("CBTransformTo")]
	[CompilerGenerated]
	private DarkUIComboBox m_ParamUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_AreaRPs")]
	private DarkListView m_PageUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonAddselectedRPtoArea")]
	private DarkUIButton m_RulesUtils;

	[AccessedThroughProperty("Button_ListUp")]
	[CompilerGenerated]
	private DarkButton m_MethodUtils;

	[AccessedThroughProperty("Button_ListDown")]
	[CompilerGenerated]
	private DarkButton m_ServiceUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonValidateArea")]
	private DarkUIButton _SystemUtils;

	[AccessedThroughProperty("DGV_NoNavZone")]
	[CompilerGenerated]
	private DarkDataGridView _CandidateUtils;

	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PolicyUtils;

	[AccessedThroughProperty("DataGridViewCheckBoxColumn1")]
	[CompilerGenerated]
	private DataGridViewCheckBoxColumn m_BroadcasterUtils;

	[AccessedThroughProperty("BtnApproveTransformTo")]
	[CompilerGenerated]
	private DarkUIButton _IdentifierUtils;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel printerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonZoneColorPicker")]
	private Button parserUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_ZoneColor")]
	private DarkLabel m_AlgoUtils;

	[AccessedThroughProperty("LV_ViolatorSides")]
	[CompilerGenerated]
	private DarkListView m_DatabaseUtils;

	[AccessedThroughProperty("Button_ViolatorNoChanges")]
	[CompilerGenerated]
	private DarkUIButton m_MessageUtils;

	[AccessedThroughProperty("Button_ViolatorUnfriendly")]
	[CompilerGenerated]
	private DarkUIButton m_ProductUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ViolatorHostile")]
	private DarkUIButton _AnnotationUtils;

	[AccessedThroughProperty("Description")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_FactoryUtils;

	[AccessedThroughProperty("Points")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_AttributeUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DrawPolygon")]
	private DarkUIButton _GlobalUtils;

	[AccessedThroughProperty("ButtonTabCusEnvZones")]
	[CompilerGenerated]
	private Button _WorkerUtils;

	[AccessedThroughProperty("btnCEZDet")]
	[CompilerGenerated]
	private DarkUIButton _AccountUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_CusEnvZones")]
	private DarkTreeView stateUtils;

	[AccessedThroughProperty("ZoneOpacity_Label")]
	[CompilerGenerated]
	private DarkLabel authenticationUtils;

	[AccessedThroughProperty("Num_ZoneOpacity")]
	[CompilerGenerated]
	private NumericUpDown m_ParamsUtils;

	[AccessedThroughProperty("Button_MoveDownZonePriority")]
	[CompilerGenerated]
	private DarkButton _InfoUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MoveUpZonePriority")]
	private DarkButton _HelperUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_NoFireZone")]
	private DarkCheckBox _MapperUtils;

	private Dictionary<int, ReferencePoint> m_ManagerUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("RefPoints")]
	private ObservableList<ReferencePoint> m_GetterUtils;

	public Dictionary<ReferencePointFlag, bool> Filters;

	public bool EnableReferencePointEvents;

	public List<ReferencePoint> AreaPoints;

	private ExclusionZone producerUtils;

	[AccessedThroughProperty("FD_LoadExclusionZone")]
	[CompilerGenerated]
	private OpenFileDialog procUtils;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ExportExclusionZone")]
	private SaveFileDialog m_StructPredicate;

	private Zone.ZoneType m_MerchantPredicate;

	private Zone m_CallbackPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_LoadStandardZone")]
	private OpenFileDialog decoratorPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_ExportStandardZone")]
	private SaveFileDialog _ProcessPredicate;

	private NoNavZone threadPredicate;

	[AccessedThroughProperty("FD_LoadNoNavZone")]
	[CompilerGenerated]
	private OpenFileDialog m_RulePredicate;

	[AccessedThroughProperty("FD_ExportNoNavZone")]
	[CompilerGenerated]
	private SaveFileDialog collectionPredicate;

	private CustomEnvironmentZone m_InstancePredicate;

	internal Panel RefPointEditorPanel
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerUtils = value;
		}
	}

	internal DarkUIButton AddnewTagButton
	{
		[CompilerGenerated]
		get
		{
			return m_ModelUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleProccesor;
			DarkUIButton modelUtils = m_ModelUtils;
			if (modelUtils != null)
			{
				modelUtils.Click -= value2;
			}
			m_ModelUtils = value;
			modelUtils = m_ModelUtils;
			if (modelUtils != null)
			{
				modelUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton DeleteTagButton
	{
		[CompilerGenerated]
		get
		{
			return _AdvisorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleProccesor;
			DarkUIButton advisorUtils = _AdvisorUtils;
			if (advisorUtils != null)
			{
				advisorUtils.Click -= value2;
			}
			_AdvisorUtils = value;
			advisorUtils = _AdvisorUtils;
			if (advisorUtils != null)
			{
				advisorUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton RemoveTagFromRef
	{
		[CompilerGenerated]
		get
		{
			return m_CustomerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleProccesor;
			DarkUIButton customerUtils = m_CustomerUtils;
			if (customerUtils != null)
			{
				customerUtils.Click -= value2;
			}
			m_CustomerUtils = value;
			customerUtils = m_CustomerUtils;
			if (customerUtils != null)
			{
				customerUtils.Click += value2;
			}
		}
	}

	internal DarkUIComboBox RefPointTagListCombo
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerUtils = value;
		}
	}

	internal DarkListView LV_Tags
	{
		[CompilerGenerated]
		get
		{
			return refUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleProccesor;
			DarkListView darkListView = refUtils;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			refUtils = value;
			darkListView = refUtils;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DarkUIButton DeleteRefPoint
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleProccesor;
			DarkUIButton errorUtils = m_ErrorUtils;
			if (errorUtils != null)
			{
				errorUtils.Click -= value2;
			}
			m_ErrorUtils = value;
			errorUtils = m_ErrorUtils;
			if (errorUtils != null)
			{
				errorUtils.Click += value2;
			}
		}
	}

	internal DarkLabel RefPointLongitude
	{
		[CompilerGenerated]
		get
		{
			return m_CodeUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeUtils = value;
		}
	}

	[field: AccessedThroughProperty("RefPointLatitude")]
	internal DarkLabel RefPointLatitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton JumpToRefPointButton
	{
		[CompilerGenerated]
		get
		{
			return m_ContextUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleProccesor;
			DarkUIButton contextUtils = m_ContextUtils;
			if (contextUtils != null)
			{
				contextUtils.Click -= value2;
			}
			m_ContextUtils = value;
			contextUtils = m_ContextUtils;
			if (contextUtils != null)
			{
				contextUtils.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Panel3")]
	internal Panel Panel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox RefPointName
	{
		[CompilerGenerated]
		get
		{
			return proccesorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorUtils = value;
		}
	}

	internal Button RefPointColorButton
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleProccesor;
			Button strategyUtils = m_StrategyUtils;
			if (strategyUtils != null)
			{
				strategyUtils.Click -= value2;
			}
			m_StrategyUtils = value;
			strategyUtils = m_StrategyUtils;
			if (strategyUtils != null)
			{
				strategyUtils.Click += value2;
			}
		}
	}

	internal DarkLabel Tags
	{
		[CompilerGenerated]
		get
		{
			return configurationUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationUtils = value;
		}
	}

	internal DarkUIButton AddTagToRefPointButton
	{
		[CompilerGenerated]
		get
		{
			return _TokenUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleProccesor;
			DarkUIButton tokenUtils = _TokenUtils;
			if (tokenUtils != null)
			{
				tokenUtils.Click -= value2;
			}
			_TokenUtils = value;
			tokenUtils = _TokenUtils;
			if (tokenUtils != null)
			{
				tokenUtils.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("SelectedTagTextBox")]
	internal DarkUITextBox SelectedTagTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal FlowLayoutPanel FlowPanelTabTagsFilter
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverUtils = value;
		}
	}

	internal Button Button1
	{
		[CompilerGenerated]
		get
		{
			return publisherUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherUtils = value;
		}
	}

	internal DarkListView LV_ReferencePoints
	{
		[CompilerGenerated]
		get
		{
			return serverUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleProccesor;
			MouseEventHandler value3 = SearchInterruptibleProccesor;
			DarkListView darkListView = serverUtils;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
				darkListView.MouseDoubleClick -= value3;
			}
			serverUtils = value;
			darkListView = serverUtils;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
				darkListView.MouseDoubleClick += value3;
			}
		}
	}

	internal Panel RefPointListContainer
	{
		[CompilerGenerated]
		get
		{
			return adapterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			adapterUtils = value;
		}
	}

	internal DarkUIButton ButtonRemoveRefPointToArea
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateInterruptibleProccesor;
			DarkUIButton schemaUtils = m_SchemaUtils;
			if (schemaUtils != null)
			{
				schemaUtils.Click -= value2;
			}
			m_SchemaUtils = value;
			schemaUtils = m_SchemaUtils;
			if (schemaUtils != null)
			{
				schemaUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonAddRefPointToArea
	{
		[CompilerGenerated]
		get
		{
			return _UtilsUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderInterruptibleProccesor;
			DarkUIButton utilsUtils = _UtilsUtils;
			if (utilsUtils != null)
			{
				utilsUtils.Click -= value2;
			}
			_UtilsUtils = value;
			utilsUtils = _UtilsUtils;
			if (utilsUtils != null)
			{
				utilsUtils.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelAreaEditor")]
	internal DarkLabel LabelAreaEditor
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton ButtonCreateNewArea
	{
		[CompilerGenerated]
		get
		{
			return singletonUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountInterruptibleStrategy;
			DarkUIButton darkUIButton = singletonUtils;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			singletonUtils = value;
			darkUIButton = singletonUtils;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonDeleteArea
	{
		[CompilerGenerated]
		get
		{
			return _RecordUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleProccesor;
			DarkUIButton recordUtils = _RecordUtils;
			if (recordUtils != null)
			{
				recordUtils.Click -= value2;
			}
			_RecordUtils = value;
			recordUtils = _RecordUtils;
			if (recordUtils != null)
			{
				recordUtils.Click += value2;
			}
		}
	}

	internal DarkTreeView TV_Zones
	{
		[CompilerGenerated]
		get
		{
			return _ExceptionUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleProccesor;
			DarkTreeView exceptionUtils = _ExceptionUtils;
			if (exceptionUtils != null)
			{
				exceptionUtils.SelectedNodesChanged -= value2;
			}
			_ExceptionUtils = value;
			exceptionUtils = _ExceptionUtils;
			if (exceptionUtils != null)
			{
				exceptionUtils.SelectedNodesChanged += value2;
			}
		}
	}

	internal Button ButtonTabZones
	{
		[CompilerGenerated]
		get
		{
			return m_AttrUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleProccesor;
			Button attrUtils = m_AttrUtils;
			if (attrUtils != null)
			{
				attrUtils.Click -= value2;
			}
			m_AttrUtils = value;
			attrUtils = m_AttrUtils;
			if (attrUtils != null)
			{
				attrUtils.Click += value2;
			}
		}
	}

	internal Button ButtonTabNoNavZones
	{
		[CompilerGenerated]
		get
		{
			return _VisitorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleProccesor;
			Button visitorUtils = _VisitorUtils;
			if (visitorUtils != null)
			{
				visitorUtils.Click -= value2;
			}
			_VisitorUtils = value;
			visitorUtils = _VisitorUtils;
			if (visitorUtils != null)
			{
				visitorUtils.Click += value2;
			}
		}
	}

	internal Button ButtonTabExclusionZones
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleProccesor;
			Button exporterUtils = m_ExporterUtils;
			if (exporterUtils != null)
			{
				exporterUtils.Click -= value2;
			}
			m_ExporterUtils = value;
			exporterUtils = m_ExporterUtils;
			if (exporterUtils != null)
			{
				exporterUtils.Click += value2;
			}
		}
	}

	internal DarkCheckBox CBAppliesAircraft
	{
		[CompilerGenerated]
		get
		{
			return prototypeUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = StartInterruptibleProccesor;
			EventHandler value3 = DestroyInterruptibleStrategy;
			DarkCheckBox darkCheckBox = prototypeUtils;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick -= value2;
				darkCheckBox.CheckedChanged -= value3;
			}
			prototypeUtils = value;
			darkCheckBox = prototypeUtils;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick += value2;
				darkCheckBox.CheckedChanged += value3;
			}
		}
	}

	internal DarkGroupBox GB_Violators
	{
		[CompilerGenerated]
		get
		{
			return comparatorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleStrategy;
			DarkGroupBox darkGroupBox = comparatorUtils;
			if (darkGroupBox != null)
			{
				darkGroupBox.Enter -= value2;
			}
			comparatorUtils = value;
			darkGroupBox = comparatorUtils;
			if (darkGroupBox != null)
			{
				darkGroupBox.Enter += value2;
			}
		}
	}

	internal DarkCheckBox DarkCheckBox_0
	{
		[CompilerGenerated]
		get
		{
			return itemUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = PrintInterruptibleProccesor;
			DarkCheckBox darkCheckBox = itemUtils;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick -= value2;
			}
			itemUtils = value;
			darkCheckBox = itemUtils;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CBAppliesShips
	{
		[CompilerGenerated]
		get
		{
			return m_SetterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = AssetInterruptibleProccesor;
			DarkCheckBox setterUtils = m_SetterUtils;
			if (setterUtils != null)
			{
				setterUtils.MouseClick -= value2;
			}
			m_SetterUtils = value;
			setterUtils = m_SetterUtils;
			if (setterUtils != null)
			{
				setterUtils.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox DarkCheckBox_1
	{
		[CompilerGenerated]
		get
		{
			return _CreatorUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = DefineInterruptibleProccesor;
			DarkCheckBox creatorUtils = _CreatorUtils;
			if (creatorUtils != null)
			{
				creatorUtils.MouseClick -= value2;
			}
			_CreatorUtils = value;
			creatorUtils = _CreatorUtils;
			if (creatorUtils != null)
			{
				creatorUtils.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CBZoneIsLocked
	{
		[CompilerGenerated]
		get
		{
			return templateUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templateUtils = value;
		}
	}

	internal DarkUITextBox TB_AreaName
	{
		[CompilerGenerated]
		get
		{
			return mappingUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitInterruptibleProccesor;
			DarkUITextBox darkUITextBox = mappingUtils;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave -= value2;
			}
			mappingUtils = value;
			darkUITextBox = mappingUtils;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave += value2;
			}
		}
	}

	internal DarkUIButton ButtonImport
	{
		[CompilerGenerated]
		get
		{
			return m_MockUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageInterruptibleProccesor;
			DarkUIButton mockUtils = m_MockUtils;
			if (mockUtils != null)
			{
				mockUtils.Click -= value2;
			}
			m_MockUtils = value;
			mockUtils = m_MockUtils;
			if (mockUtils != null)
			{
				mockUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonExport
	{
		[CompilerGenerated]
		get
		{
			return _TagUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertInterruptibleProccesor;
			DarkUIButton tagUtils = _TagUtils;
			if (tagUtils != null)
			{
				tagUtils.Click -= value2;
			}
			_TagUtils = value;
			tagUtils = _TagUtils;
			if (tagUtils != null)
			{
				tagUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonSave
	{
		[CompilerGenerated]
		get
		{
			return _FieldUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewInterruptibleStrategy;
			DarkUIButton fieldUtils = _FieldUtils;
			if (fieldUtils != null)
			{
				fieldUtils.Click -= value2;
			}
			_FieldUtils = value;
			fieldUtils = _FieldUtils;
			if (fieldUtils != null)
			{
				fieldUtils.Click += value2;
			}
		}
	}

	internal DarkDataGridView DGV_ExlusionZone
	{
		[CompilerGenerated]
		get
		{
			return m_QueueUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostInterruptibleProccesor;
			DataGridViewCellEventHandler value3 = AwakeInterruptibleProccesor;
			EventHandler value4 = ConnectInterruptibleStrategy;
			DarkDataGridView queueUtils = m_QueueUtils;
			if (queueUtils != null)
			{
				queueUtils.SelectionChanged -= value2;
				queueUtils.CellClick -= value3;
				queueUtils.RowHeadersDefaultCellStyleChanged -= value4;
			}
			m_QueueUtils = value;
			queueUtils = m_QueueUtils;
			if (queueUtils != null)
			{
				queueUtils.SelectionChanged += value2;
				queueUtils.CellClick += value3;
				queueUtils.RowHeadersDefaultCellStyleChanged += value4;
			}
		}
	}

	internal DarkLabel lblTransform
	{
		[CompilerGenerated]
		get
		{
			return regUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regUtils = value;
		}
	}

	internal DarkUIComboBox CBTransformTo
	{
		[CompilerGenerated]
		get
		{
			return m_ParamUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamUtils = value;
		}
	}

	internal DarkListView LB_AreaRPs
	{
		[CompilerGenerated]
		get
		{
			return m_PageUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageUtils = value;
		}
	}

	internal DarkUIButton ButtonAddselectedRPtoArea
	{
		[CompilerGenerated]
		get
		{
			return m_RulesUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetInterruptibleProccesor;
			DarkUIButton rulesUtils = m_RulesUtils;
			if (rulesUtils != null)
			{
				rulesUtils.Click -= value2;
			}
			m_RulesUtils = value;
			rulesUtils = m_RulesUtils;
			if (rulesUtils != null)
			{
				rulesUtils.Click += value2;
			}
		}
	}

	internal DarkButton Button_ListUp
	{
		[CompilerGenerated]
		get
		{
			return m_MethodUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleProccesor;
			DarkButton methodUtils = m_MethodUtils;
			if (methodUtils != null)
			{
				methodUtils.Click -= value2;
			}
			m_MethodUtils = value;
			methodUtils = m_MethodUtils;
			if (methodUtils != null)
			{
				methodUtils.Click += value2;
			}
		}
	}

	internal DarkButton Button_ListDown
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotInterruptibleProccesor;
			DarkButton serviceUtils = m_ServiceUtils;
			if (serviceUtils != null)
			{
				serviceUtils.Click -= value2;
			}
			m_ServiceUtils = value;
			serviceUtils = m_ServiceUtils;
			if (serviceUtils != null)
			{
				serviceUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton ButtonValidateArea
	{
		[CompilerGenerated]
		get
		{
			return _SystemUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectInterruptibleProccesor;
			DarkUIButton systemUtils = _SystemUtils;
			if (systemUtils != null)
			{
				systemUtils.Click -= value2;
			}
			_SystemUtils = value;
			systemUtils = _SystemUtils;
			if (systemUtils != null)
			{
				systemUtils.Click += value2;
			}
		}
	}

	internal DarkDataGridView DGV_NoNavZone
	{
		[CompilerGenerated]
		get
		{
			return _CandidateUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleProccesor;
			DarkDataGridView candidateUtils = _CandidateUtils;
			if (candidateUtils != null)
			{
				candidateUtils.SelectionChanged -= value2;
			}
			_CandidateUtils = value;
			candidateUtils = _CandidateUtils;
			if (candidateUtils != null)
			{
				candidateUtils.SelectionChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PolicyUtils = value;
		}
	}

	internal DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BroadcasterUtils = value;
		}
	}

	internal DarkUIButton BtnApproveTransformTo
	{
		[CompilerGenerated]
		get
		{
			return _IdentifierUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterruptibleStrategy;
			DarkUIButton identifierUtils = _IdentifierUtils;
			if (identifierUtils != null)
			{
				identifierUtils.Click -= value2;
			}
			_IdentifierUtils = value;
			identifierUtils = _IdentifierUtils;
			if (identifierUtils != null)
			{
				identifierUtils.Click += value2;
			}
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return printerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerUtils = value;
		}
	}

	internal Button ButtonZoneColorPicker
	{
		[CompilerGenerated]
		get
		{
			return parserUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveInterruptibleStrategy;
			Button button = parserUtils;
			if (button != null)
			{
				button.Click -= value2;
			}
			parserUtils = value;
			button = parserUtils;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal DarkLabel Label_ZoneColor
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteInterruptibleStrategy;
			DarkLabel algoUtils = m_AlgoUtils;
			if (algoUtils != null)
			{
				algoUtils.Click -= value2;
			}
			m_AlgoUtils = value;
			algoUtils = m_AlgoUtils;
			if (algoUtils != null)
			{
				algoUtils.Click += value2;
			}
		}
	}

	internal DarkListView LV_ViolatorSides
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DatabaseUtils = value;
		}
	}

	[field: AccessedThroughProperty("GBAppliesTo")]
	internal DarkGroupBox DarkGroupBox_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_ViolatorNoChanges
	{
		[CompilerGenerated]
		get
		{
			return m_MessageUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallInterruptibleStrategy;
			DarkUIButton messageUtils = m_MessageUtils;
			if (messageUtils != null)
			{
				messageUtils.Click -= value2;
			}
			m_MessageUtils = value;
			messageUtils = m_MessageUtils;
			if (messageUtils != null)
			{
				messageUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ViolatorUnfriendly
	{
		[CompilerGenerated]
		get
		{
			return m_ProductUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectInterruptibleStrategy;
			DarkUIButton productUtils = m_ProductUtils;
			if (productUtils != null)
			{
				productUtils.Click -= value2;
			}
			m_ProductUtils = value;
			productUtils = m_ProductUtils;
			if (productUtils != null)
			{
				productUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ViolatorHostile
	{
		[CompilerGenerated]
		get
		{
			return _AnnotationUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInterruptibleStrategy;
			DarkUIButton annotationUtils = _AnnotationUtils;
			if (annotationUtils != null)
			{
				annotationUtils.Click -= value2;
			}
			_AnnotationUtils = value;
			annotationUtils = _AnnotationUtils;
			if (annotationUtils != null)
			{
				annotationUtils.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal DarkLabel DarkLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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
			return m_FactoryUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FactoryUtils = value;
		}
	}

	internal DataGridViewTextBoxColumn Points
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeUtils = value;
		}
	}

	[field: AccessedThroughProperty("Active")]
	internal DataGridViewCheckBoxColumn Active
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_DrawPolygon
	{
		[CompilerGenerated]
		get
		{
			return _GlobalUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutInterruptibleStrategy;
			DarkUIButton globalUtils = _GlobalUtils;
			if (globalUtils != null)
			{
				globalUtils.Click -= value2;
			}
			_GlobalUtils = value;
			globalUtils = _GlobalUtils;
			if (globalUtils != null)
			{
				globalUtils.Click += value2;
			}
		}
	}

	internal Button ButtonTabCusEnvZones
	{
		[CompilerGenerated]
		get
		{
			return _WorkerUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleProccesor;
			Button workerUtils = _WorkerUtils;
			if (workerUtils != null)
			{
				workerUtils.Click -= value2;
			}
			_WorkerUtils = value;
			workerUtils = _WorkerUtils;
			if (workerUtils != null)
			{
				workerUtils.Click += value2;
			}
		}
	}

	internal DarkUIButton DarkUIButton_0
	{
		[CompilerGenerated]
		get
		{
			return _AccountUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeInterruptibleStrategy;
			DarkUIButton accountUtils = _AccountUtils;
			if (accountUtils != null)
			{
				accountUtils.Click -= value2;
			}
			_AccountUtils = value;
			accountUtils = _AccountUtils;
			if (accountUtils != null)
			{
				accountUtils.Click += value2;
			}
		}
	}

	internal DarkTreeView TV_CusEnvZones
	{
		[CompilerGenerated]
		get
		{
			return stateUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateInterruptibleStrategy;
			DarkTreeView darkTreeView = stateUtils;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
			}
			stateUtils = value;
			darkTreeView = stateUtils;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	internal DarkLabel ZoneOpacity_Label
	{
		[CompilerGenerated]
		get
		{
			return authenticationUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			authenticationUtils = value;
		}
	}

	internal NumericUpDown Num_ZoneOpacity
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginInterruptibleStrategy;
			NumericUpDown paramsUtils = m_ParamsUtils;
			if (paramsUtils != null)
			{
				paramsUtils.ValueChanged -= value2;
			}
			m_ParamsUtils = value;
			paramsUtils = m_ParamsUtils;
			if (paramsUtils != null)
			{
				paramsUtils.ValueChanged += value2;
			}
		}
	}

	internal DarkButton Button_MoveDownZonePriority
	{
		[CompilerGenerated]
		get
		{
			return _InfoUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteInterruptibleStrategy;
			DarkButton infoUtils = _InfoUtils;
			if (infoUtils != null)
			{
				infoUtils.Click -= value2;
			}
			_InfoUtils = value;
			infoUtils = _InfoUtils;
			if (infoUtils != null)
			{
				infoUtils.Click += value2;
			}
		}
	}

	internal DarkButton Button_MoveUpZonePriority
	{
		[CompilerGenerated]
		get
		{
			return _HelperUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetInterruptibleStrategy;
			DarkButton helperUtils = _HelperUtils;
			if (helperUtils != null)
			{
				helperUtils.Click -= value2;
			}
			_HelperUtils = value;
			helperUtils = _HelperUtils;
			if (helperUtils != null)
			{
				helperUtils.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_NoFireZone
	{
		[CompilerGenerated]
		get
		{
			return _MapperUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewInterruptibleStrategy;
			DarkCheckBox mapperUtils = _MapperUtils;
			if (mapperUtils != null)
			{
				mapperUtils.CheckedChanged -= value2;
			}
			_MapperUtils = value;
			mapperUtils = _MapperUtils;
			if (mapperUtils != null)
			{
				mapperUtils.CheckedChanged += value2;
			}
		}
	}

	public ObservableList<ReferencePoint> RefPoints
	{
		[CompilerGenerated]
		get
		{
			return m_GetterUtils;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<ReferencePoint>> value2 = PushInterruptibleProccesor;
			EventHandler<ObservableListModified<ReferencePoint>> value3 = InvokeInterruptibleProccesor;
			ObservableList<ReferencePoint> getterUtils = m_GetterUtils;
			if (getterUtils != null)
			{
				getterUtils.ItemsRemoved -= value2;
				getterUtils.ItemsAdded -= value3;
			}
			m_GetterUtils = value;
			getterUtils = m_GetterUtils;
			if (getterUtils != null)
			{
				getterUtils.ItemsRemoved += value2;
				getterUtils.ItemsAdded += value3;
			}
		}
	}

	public ExclusionZone SelectedExlusionZone
	{
		get
		{
			return producerUtils;
		}
		set
		{
			producerUtils = value;
			if (Information.IsNothing(value))
			{
				PopInterruptibleProccesor(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				CBAppliesAircraft.Checked = producerUtils.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
				CBAppliesShips.Checked = producerUtils.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
				DarkCheckBox_0.Checked = producerUtils.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
				DarkCheckBox_1.Checked = producerUtils.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
				CompareInterruptibleProccesor();
				PopInterruptibleProccesor(producerUtils.Area);
			}
			bool flag = false;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (ExclusionZone exclusionZone in side.ExclusionZones)
				{
					if (exclusionZone != SelectedExlusionZone)
					{
						continue;
					}
					foreach (ReferencePoint item in SelectedExlusionZone.Area)
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
			Client.MustRefreshMainForm = true;
		}
	}

	public Zone SelectedStandardZone
	{
		get
		{
			return m_CallbackPredicate;
		}
		set
		{
			m_CallbackPredicate = value;
			if (Information.IsNothing(value))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				PopInterruptibleProccesor(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				ButtonZoneColorPicker.BackColor = m_CallbackPredicate.AreaColor;
				PopInterruptibleProccesor(m_CallbackPredicate.Area);
			}
			bool flag = false;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (NoNavZone noNavZone in side.NoNavZones)
				{
					if (noNavZone != SelectedNoNavZone)
					{
						continue;
					}
					foreach (ReferencePoint item in SelectedNoNavZone.Area)
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
			Client.MustRefreshMainForm = true;
		}
	}

	public NoNavZone SelectedNoNavZone
	{
		get
		{
			return threadPredicate;
		}
		set
		{
			threadPredicate = value;
			if (Information.IsNothing(value))
			{
				PopInterruptibleProccesor(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				CBAppliesAircraft.Checked = threadPredicate.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
				CBAppliesShips.Checked = threadPredicate.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
				DarkCheckBox_0.Checked = threadPredicate.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
				DarkCheckBox_1.Checked = threadPredicate.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
				CBZoneIsLocked.Checked = threadPredicate.IsLocked;
				CB_NoFireZone.Checked = threadPredicate.NoFireZone;
				PopInterruptibleProccesor(threadPredicate.Area);
				QueryInterruptibleProccesor();
			}
			Client.MustRefreshMainForm = true;
		}
	}

	public CustomEnvironmentZone SelectedCustomEnvironmentZone
	{
		get
		{
			return m_InstancePredicate;
		}
		set
		{
			m_InstancePredicate = value;
			if (Information.IsNothing(value))
			{
				PopInterruptibleProccesor(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				PopInterruptibleProccesor(m_InstancePredicate.Area);
			}
			if (Information.IsNothing(value))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				PopInterruptibleProccesor(null);
			}
			else
			{
				TB_AreaName.Text = value.Description;
				ButtonZoneColorPicker.BackColor = m_InstancePredicate.AreaColor;
				PopInterruptibleProccesor(m_InstancePredicate.Area);
			}
			bool flag = false;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (NoNavZone noNavZone in side.NoNavZones)
				{
					if (noNavZone != SelectedNoNavZone)
					{
						continue;
					}
					foreach (ReferencePoint item in SelectedNoNavZone.Area)
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
			Client.MustRefreshMainForm = true;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog PushInterruptibleToken()
	{
		return procUtils;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InvokeInterruptibleToken(OpenFileDialog openFileDialog_0)
	{
		procUtils = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog ExcludeInterruptibleToken()
	{
		return m_StructPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void IncludeInterruptibleToken(SaveFileDialog saveFileDialog_0)
	{
		m_StructPredicate = saveFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog EnableInterruptibleToken()
	{
		return decoratorPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ChangeInterruptibleToken(OpenFileDialog openFileDialog_0)
	{
		decoratorPredicate = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog CheckInterruptibleToken()
	{
		return _ProcessPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ConcatInterruptibleToken(SaveFileDialog saveFileDialog_0)
	{
		_ProcessPredicate = saveFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog RemoveInterruptibleToken()
	{
		return m_RulePredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void FindInterruptibleToken(OpenFileDialog openFileDialog_0)
	{
		m_RulePredicate = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog FillInterruptibleToken()
	{
		return collectionPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CalculateInterruptibleToken(SaveFileDialog saveFileDialog_0)
	{
		collectionPredicate = saveFileDialog_0;
	}

	public ReferencePointManager()
	{
		base.Load += WriteInterruptibleProccesor;
		m_ManagerUtils = new Dictionary<int, ReferencePoint>();
		RefPoints = new ObservableList<ReferencePoint>();
		Filters = new Dictionary<ReferencePointFlag, bool>();
		EnableReferencePointEvents = true;
		m_MerchantPredicate = Zone.ZoneType.Zone;
		GetInterruptibleProccesor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && containerUtils != null)
			{
				containerUtils.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GetInterruptibleProccesor()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(ReferencePointManager));
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		RefPointEditorPanel = new Panel();
		DarkLabel1 = new DarkLabel();
		RefPointColorButton = new Button();
		RefPointName = new DarkUITextBox();
		JumpToRefPointButton = new DarkUIButton();
		RemoveTagFromRef = new DarkUIButton();
		RefPointTagListCombo = new DarkUIComboBox();
		DeleteRefPoint = new DarkUIButton();
		RefPointLongitude = new DarkLabel();
		RefPointLatitude = new DarkLabel();
		Panel3 = new Panel();
		SelectedTagTextBox = new DarkUITextBox();
		Tags = new DarkLabel();
		AddTagToRefPointButton = new DarkUIButton();
		LV_Tags = new DarkListView();
		DeleteTagButton = new DarkUIButton();
		AddnewTagButton = new DarkUIButton();
		FlowPanelTabTagsFilter = new FlowLayoutPanel();
		Button1 = new Button();
		RefPointListContainer = new Panel();
		LV_ReferencePoints = new DarkListView();
		ButtonTabZones = new Button();
		ButtonTabNoNavZones = new Button();
		ButtonTabExclusionZones = new Button();
		ButtonZoneColorPicker = new Button();
		DarkLabel3 = new DarkLabel();
		Label_ZoneColor = new DarkLabel();
		DGV_NoNavZone = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
		Button_ListDown = new DarkButton();
		Button_ListUp = new DarkButton();
		LB_AreaRPs = new DarkListView();
		lblTransform = new DarkLabel();
		DGV_ExlusionZone = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Points = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		CBZoneIsLocked = new DarkCheckBox();
		GB_Violators = new DarkGroupBox();
		LV_ViolatorSides = new DarkListView();
		DarkLabel4 = new DarkLabel();
		Button_ViolatorNoChanges = new DarkUIButton();
		Button_ViolatorUnfriendly = new DarkUIButton();
		Button_ViolatorHostile = new DarkUIButton();
		DarkGroupBox_0 = new DarkGroupBox();
		CBAppliesShips = new DarkCheckBox();
		CBAppliesAircraft = new DarkCheckBox();
		DarkCheckBox_0 = new DarkCheckBox();
		DarkCheckBox_1 = new DarkCheckBox();
		TV_Zones = new DarkTreeView();
		LabelAreaEditor = new DarkLabel();
		ButtonTabCusEnvZones = new Button();
		TV_CusEnvZones = new DarkTreeView();
		DarkUIButton_0 = new DarkUIButton();
		Button_DrawPolygon = new DarkUIButton();
		BtnApproveTransformTo = new DarkUIButton();
		ButtonValidateArea = new DarkUIButton();
		ButtonAddselectedRPtoArea = new DarkUIButton();
		CBTransformTo = new DarkUIComboBox();
		ButtonSave = new DarkUIButton();
		ButtonExport = new DarkUIButton();
		ButtonImport = new DarkUIButton();
		TB_AreaName = new DarkUITextBox();
		ButtonDeleteArea = new DarkUIButton();
		ButtonCreateNewArea = new DarkUIButton();
		ButtonAddRefPointToArea = new DarkUIButton();
		ButtonRemoveRefPointToArea = new DarkUIButton();
		ZoneOpacity_Label = new DarkLabel();
		Num_ZoneOpacity = new NumericUpDown();
		Button_MoveDownZonePriority = new DarkButton();
		Button_MoveUpZonePriority = new DarkButton();
		CB_NoFireZone = new DarkCheckBox();
		RefPointEditorPanel.SuspendLayout();
		Panel3.SuspendLayout();
		FlowPanelTabTagsFilter.SuspendLayout();
		RefPointListContainer.SuspendLayout();
		((ISupportInitialize)DGV_NoNavZone).BeginInit();
		((ISupportInitialize)DGV_ExlusionZone).BeginInit();
		GB_Violators.SuspendLayout();
		DarkGroupBox_0.SuspendLayout();
		((ISupportInitialize)Num_ZoneOpacity).BeginInit();
		SuspendLayout();
		RefPointEditorPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RefPointEditorPanel.BackColor = Color.FromArgb(80, 80, 80);
		RefPointEditorPanel.Controls.Add(DarkLabel1);
		RefPointEditorPanel.Controls.Add(RefPointColorButton);
		RefPointEditorPanel.Controls.Add(RefPointName);
		RefPointEditorPanel.Controls.Add(JumpToRefPointButton);
		RefPointEditorPanel.Controls.Add(RemoveTagFromRef);
		RefPointEditorPanel.Controls.Add(RefPointTagListCombo);
		RefPointEditorPanel.Controls.Add(DeleteRefPoint);
		RefPointEditorPanel.Controls.Add(RefPointLongitude);
		RefPointEditorPanel.Controls.Add(RefPointLatitude);
		RefPointEditorPanel.Location = new Point(12, 343);
		RefPointEditorPanel.Name = "RefPointEditorPanel";
		RefPointEditorPanel.Size = new Size(314, 154);
		RefPointEditorPanel.TabIndex = 2;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(32, 104);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(89, 13);
		DarkLabel1.TabIndex = 12;
		DarkLabel1.Text = "改变参考点颜色";
		RefPointColorButton.BackColor = SystemColors.Control;
		RefPointColorButton.FlatAppearance.BorderSize = 0;
		RefPointColorButton.Location = new Point(3, 119);
		RefPointColorButton.Name = "RefPointColorButton";
		RefPointColorButton.Size = new Size(147, 29);
		RefPointColorButton.TabIndex = 11;
		RefPointColorButton.UseVisualStyleBackColor = false;
		RefPointName.AutoCompleteCustomSource = null;
		RefPointName.AutoCompleteMode = AutoCompleteMode.None;
		RefPointName.AutoCompleteSource = AutoCompleteSource.None;
		RefPointName.BackColor = Color.Transparent;
		RefPointName.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		RefPointName.ForeColor = Color.FromArgb(189, 189, 189);
		RefPointName.Image = null;
		RefPointName.Lines = null;
		RefPointName.Location = new Point(15, 7);
		RefPointName.MaxLength = 32767;
		RefPointName.Multiline = false;
		RefPointName.Name = "RefPointName";
		RefPointName.ReadOnly = false;
		RefPointName.ScrollBars = ScrollBars.None;
		RefPointName.SelectionStart = 0;
		RefPointName.Size = new Size(135, 21);
		RefPointName.TabIndex = 10;
		RefPointName.TextAlign = HorizontalAlignment.Center;
		RefPointName.UseSystemPasswordChar = false;
		RefPointName.WatermarkText = "";
		JumpToRefPointButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		JumpToRefPointButton.BackColor = Color.Transparent;
		JumpToRefPointButton.DialogResult = DialogResult.None;
		JumpToRefPointButton.ForeColor = SystemColors.Control;
		JumpToRefPointButton.Location = new Point(156, 128);
		JumpToRefPointButton.Name = "JumpToRefPointButton";
		JumpToRefPointButton.RoundRadius = 0;
		JumpToRefPointButton.Size = new Size(151, 23);
		JumpToRefPointButton.TabIndex = 9;
		JumpToRefPointButton.Text = "跳转到参考点";
		RemoveTagFromRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RemoveTagFromRef.BackColor = Color.Transparent;
		RemoveTagFromRef.DialogResult = DialogResult.None;
		RemoveTagFromRef.ForeColor = SystemColors.Control;
		RemoveTagFromRef.Location = new Point(156, 34);
		RemoveTagFromRef.Name = "RemoveTagFromRef";
		RemoveTagFromRef.RoundRadius = 0;
		RemoveTagFromRef.Size = new Size(151, 23);
		RemoveTagFromRef.TabIndex = 6;
		RemoveTagFromRef.Text = "删除标签";
		RefPointTagListCombo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RefPointTagListCombo.BackColor = Color.Transparent;
		RefPointTagListCombo.DrawMode = DrawMode.OwnerDrawFixed;
		RefPointTagListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
		RefPointTagListCombo.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		RefPointTagListCombo.FormattingEnabled = true;
		RefPointTagListCombo.Location = new Point(156, 7);
		RefPointTagListCombo.Name = "RefPointTagListCombo";
		RefPointTagListCombo.Size = new Size(151, 21);
		RefPointTagListCombo.TabIndex = 5;
		DeleteRefPoint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DeleteRefPoint.BackColor = Color.Transparent;
		DeleteRefPoint.DialogResult = DialogResult.None;
		DeleteRefPoint.ForeColor = SystemColors.Control;
		DeleteRefPoint.Location = new Point(156, 99);
		DeleteRefPoint.Name = "DeleteRefPoint";
		DeleteRefPoint.RoundRadius = 0;
		DeleteRefPoint.Size = new Size(151, 23);
		DeleteRefPoint.TabIndex = 3;
		DeleteRefPoint.Text = "删除参考点";
		RefPointLongitude.AutoSize = true;
		RefPointLongitude.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		RefPointLongitude.ForeColor = Color.FromArgb(220, 220, 220);
		RefPointLongitude.Location = new Point(14, 49);
		RefPointLongitude.Name = "RefPointLongitude";
		RefPointLongitude.Size = new Size(0, 17);
		RefPointLongitude.TabIndex = 2;
		RefPointLatitude.AutoSize = true;
		RefPointLatitude.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		RefPointLatitude.ForeColor = Color.FromArgb(220, 220, 220);
		RefPointLatitude.Location = new Point(14, 31);
		RefPointLatitude.Name = "RefPointLatitude";
		RefPointLatitude.Size = new Size(0, 17);
		RefPointLatitude.TabIndex = 1;
		Panel3.BackColor = Color.FromArgb(80, 80, 80);
		Panel3.Controls.Add(SelectedTagTextBox);
		Panel3.Controls.Add(Tags);
		Panel3.Controls.Add(AddTagToRefPointButton);
		Panel3.Controls.Add(LV_Tags);
		Panel3.Controls.Add(DeleteTagButton);
		Panel3.Controls.Add(AddnewTagButton);
		Panel3.Location = new Point(332, 344);
		Panel3.Name = "Panel3";
		Panel3.Size = new Size(219, 153);
		Panel3.TabIndex = 3;
		SelectedTagTextBox.AutoCompleteCustomSource = null;
		SelectedTagTextBox.AutoCompleteMode = AutoCompleteMode.None;
		SelectedTagTextBox.AutoCompleteSource = AutoCompleteSource.None;
		SelectedTagTextBox.BackColor = Color.Transparent;
		SelectedTagTextBox.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		SelectedTagTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		SelectedTagTextBox.Image = null;
		SelectedTagTextBox.Lines = null;
		SelectedTagTextBox.Location = new Point(45, 3);
		SelectedTagTextBox.MaxLength = 32767;
		SelectedTagTextBox.Multiline = false;
		SelectedTagTextBox.Name = "SelectedTagTextBox";
		SelectedTagTextBox.ReadOnly = false;
		SelectedTagTextBox.ScrollBars = ScrollBars.None;
		SelectedTagTextBox.SelectionStart = 0;
		SelectedTagTextBox.Size = new Size(170, 17);
		SelectedTagTextBox.TabIndex = 12;
		SelectedTagTextBox.TextAlign = HorizontalAlignment.Center;
		SelectedTagTextBox.UseSystemPasswordChar = false;
		SelectedTagTextBox.WatermarkText = "";
		Tags.AutoSize = true;
		Tags.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Tags.ForeColor = Color.FromArgb(220, 220, 220);
		Tags.Location = new Point(3, 3);
		Tags.Name = "Tags";
		Tags.Size = new Size(40, 17);
		Tags.TabIndex = 12;
		Tags.Text = "标签";
		AddTagToRefPointButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		AddTagToRefPointButton.BackColor = Color.Transparent;
		AddTagToRefPointButton.DialogResult = DialogResult.None;
		AddTagToRefPointButton.ForeColor = SystemColors.Control;
		AddTagToRefPointButton.Location = new Point(3, 127);
		AddTagToRefPointButton.Name = "AddTagToRefPointButton";
		AddTagToRefPointButton.RoundRadius = 0;
		AddTagToRefPointButton.Size = new Size(54, 23);
		AddTagToRefPointButton.TabIndex = 9;
		AddTagToRefPointButton.Text = "< 添加";
		LV_Tags.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LV_Tags.BackColor = Color.FromArgb(70, 70, 70);
		LV_Tags.Location = new Point(3, 29);
		LV_Tags.Name = "LV_Tags";
		LV_Tags.RelatedInfos = null;
		LV_Tags.Size = new Size(209, 93);
		LV_Tags.TabIndex = 4;
		LV_Tags.Text = "DarkListView2";
		DeleteTagButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DeleteTagButton.BackColor = Color.Transparent;
		DeleteTagButton.DialogResult = DialogResult.None;
		DeleteTagButton.ForeColor = SystemColors.Control;
		DeleteTagButton.Location = new Point(63, 127);
		DeleteTagButton.Name = "DeleteTagButton";
		DeleteTagButton.RoundRadius = 0;
		DeleteTagButton.Size = new Size(62, 23);
		DeleteTagButton.TabIndex = 7;
		DeleteTagButton.Text = "删除";
		AddnewTagButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		AddnewTagButton.BackColor = Color.Transparent;
		AddnewTagButton.DialogResult = DialogResult.None;
		AddnewTagButton.ForeColor = SystemColors.Control;
		AddnewTagButton.Location = new Point(130, 127);
		AddnewTagButton.Name = "AddnewTagButton";
		AddnewTagButton.RoundRadius = 0;
		AddnewTagButton.Size = new Size(81, 23);
		AddnewTagButton.TabIndex = 8;
		AddnewTagButton.Text = "创建新的";
		FlowPanelTabTagsFilter.AutoScroll = true;
		FlowPanelTabTagsFilter.AutoScrollMinSize = new Size(10, 10);
		FlowPanelTabTagsFilter.Controls.Add(Button1);
		FlowPanelTabTagsFilter.Location = new Point(10, 21);
		FlowPanelTabTagsFilter.Margin = new Padding(2);
		FlowPanelTabTagsFilter.Name = "FlowPanelTabTagsFilter";
		FlowPanelTabTagsFilter.Size = new Size(542, 47);
		FlowPanelTabTagsFilter.TabIndex = 1;
		FlowPanelTabTagsFilter.WrapContents = false;
		Button1.BackColor = Color.Gray;
		Button1.FlatStyle = FlatStyle.Flat;
		Button1.ForeColor = SystemColors.ButtonFace;
		Button1.Location = new Point(3, 3);
		Button1.Name = "Button1";
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 0;
		Button1.Text = "Button1";
		Button1.UseVisualStyleBackColor = false;
		RefPointListContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		RefPointListContainer.AutoSize = true;
		RefPointListContainer.Controls.Add(LV_ReferencePoints);
		RefPointListContainer.Location = new Point(12, 83);
		RefPointListContainer.Name = "RefPointListContainer";
		RefPointListContainer.Size = new Size(539, 258);
		RefPointListContainer.TabIndex = 1;
		LV_ReferencePoints.BackColor = Color.FromArgb(70, 70, 70);
		LV_ReferencePoints.Location = new Point(0, 0);
		LV_ReferencePoints.MultiSelect = true;
		LV_ReferencePoints.Name = "LV_ReferencePoints";
		LV_ReferencePoints.RelatedInfos = null;
		LV_ReferencePoints.Size = new Size(536, 254);
		LV_ReferencePoints.TabIndex = 0;
		LV_ReferencePoints.Text = "LV_ReferencePoints";
		ButtonTabZones.BackColor = Color.Gray;
		ButtonTabZones.FlatStyle = FlatStyle.Flat;
		ButtonTabZones.ForeColor = SystemColors.ActiveCaptionText;
		ButtonTabZones.Location = new Point(557, 24);
		ButtonTabZones.Name = "ButtonTabZones";
		ButtonTabZones.Size = new Size(69, 23);
		ButtonTabZones.TabIndex = 1;
		ButtonTabZones.Text = "所有区域";
		ButtonTabZones.UseVisualStyleBackColor = false;
		ButtonTabNoNavZones.BackColor = Color.Gray;
		ButtonTabNoNavZones.FlatStyle = FlatStyle.Flat;
		ButtonTabNoNavZones.ForeColor = SystemColors.ActiveCaptionText;
		ButtonTabNoNavZones.Location = new Point(632, 24);
		ButtonTabNoNavZones.Name = "ButtonTabNoNavZones";
		ButtonTabNoNavZones.Size = new Size(90, 23);
		ButtonTabNoNavZones.TabIndex = 12;
		ButtonTabNoNavZones.Text = "禁航区域";
		ButtonTabNoNavZones.UseVisualStyleBackColor = false;
		ButtonTabExclusionZones.BackColor = Color.Gray;
		ButtonTabExclusionZones.FlatStyle = FlatStyle.Flat;
		ButtonTabExclusionZones.ForeColor = SystemColors.ActiveCaptionText;
		ButtonTabExclusionZones.Location = new Point(728, 24);
		ButtonTabExclusionZones.Name = "ButtonTabExclusionZones";
		ButtonTabExclusionZones.Size = new Size(102, 23);
		ButtonTabExclusionZones.TabIndex = 13;
		ButtonTabExclusionZones.Text = "封锁区";
		ButtonTabExclusionZones.UseVisualStyleBackColor = false;
		ButtonZoneColorPicker.BackColor = SystemColors.Control;
		ButtonZoneColorPicker.FlatAppearance.BorderSize = 0;
		ButtonZoneColorPicker.Location = new Point(626, 409);
		ButtonZoneColorPicker.Name = "ButtonZoneColorPicker";
		ButtonZoneColorPicker.Size = new Size(51, 21);
		ButtonZoneColorPicker.TabIndex = 13;
		ButtonZoneColorPicker.UseVisualStyleBackColor = false;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(561, 383);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(35, 13);
		DarkLabel3.TabIndex = 35;
		DarkLabel3.Text = "名称";
		Label_ZoneColor.AutoSize = true;
		Label_ZoneColor.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ZoneColor.Location = new Point(561, 413);
		Label_ZoneColor.Name = "Label_ZoneColor";
		Label_ZoneColor.Size = new Size(59, 13);
		Label_ZoneColor.TabIndex = 13;
		Label_ZoneColor.Text = "区域颜色";
		DGV_NoNavZone.AllowUserToAddRows = false;
		DGV_NoNavZone.AllowUserToDeleteRows = false;
		DGV_NoNavZone.AllowUserToOrderColumns = true;
		DGV_NoNavZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_NoNavZone.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_NoNavZone.BorderStyle = BorderStyle.Fixed3D;
		DGV_NoNavZone.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_NoNavZone.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_NoNavZone.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_NoNavZone.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_NoNavZone.Columns.AddRange(DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewCheckBoxColumn1);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_NoNavZone.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_NoNavZone.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_NoNavZone.EnableHeadersVisualStyles = false;
		DGV_NoNavZone.Location = new Point(557, 49);
		DGV_NoNavZone.MultiSelect = false;
		DGV_NoNavZone.Name = "DGV_NoNavZone";
		DGV_NoNavZone.ReadOnly = true;
		DGV_NoNavZone.RowHeadersVisible = false;
		DGV_NoNavZone.RowHeadersWidth = 62;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_NoNavZone.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_NoNavZone.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_NoNavZone.ShowCellToolTips = false;
		DGV_NoNavZone.ShowEditingIcon = false;
		DGV_NoNavZone.ShowRowErrors = false;
		DGV_NoNavZone.Size = new Size(582, 141);
		DGV_NoNavZone.TabIndex = 33;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.HeaderText = "ID";
		DataGridViewTextBoxColumn1.MinimumWidth = 8;
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn1.Visible = false;
		DataGridViewTextBoxColumn1.Width = 150;
		DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridViewTextBoxColumn2.DataPropertyName = "Description";
		DataGridViewTextBoxColumn2.HeaderText = "描述";
		DataGridViewTextBoxColumn2.MinimumWidth = 8;
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DataGridViewCheckBoxColumn1.DataPropertyName = "IsActive";
		DataGridViewCheckBoxColumn1.HeaderText = "启用";
		DataGridViewCheckBoxColumn1.MinimumWidth = 8;
		DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1";
		DataGridViewCheckBoxColumn1.ReadOnly = true;
		DataGridViewCheckBoxColumn1.Width = 150;
		Button_ListDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_ListDown.BackColor = Color.Transparent;
		Button_ListDown.BackgroundImage = componentResourceManager.GetObject("Button_ListDown.BackgroundImage");
		Button_ListDown.Font = new Font("Segoe UI", 10f);
		Button_ListDown.ForeColor = Color.FromArgb(220, 220, 220);
		Button_ListDown.Image = componentResourceManager.GetObject("Button_ListDown.Image");
		Button_ListDown.Location = new Point(560, 355);
		Button_ListDown.Name = "Button_ListDown";
		Button_ListDown.Padding = new Padding(5);
		Button_ListDown.Size = new Size(19, 17);
		Button_ListDown.TabIndex = 31;
		Button_ListUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_ListUp.BackColor = Color.Transparent;
		Button_ListUp.BackgroundImage = componentResourceManager.GetObject("Button_ListUp.BackgroundImage");
		Button_ListUp.Font = new Font("Segoe UI", 10f);
		Button_ListUp.ForeColor = Color.FromArgb(220, 220, 220);
		Button_ListUp.Image = componentResourceManager.GetObject("Button_ListUp.Image");
		Button_ListUp.Location = new Point(560, 334);
		Button_ListUp.Name = "Button_ListUp";
		Button_ListUp.Padding = new Padding(5);
		Button_ListUp.Size = new Size(19, 17);
		Button_ListUp.TabIndex = 30;
		LB_AreaRPs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LB_AreaRPs.BackColor = Color.FromArgb(80, 80, 80);
		LB_AreaRPs.Location = new Point(584, 219);
		LB_AreaRPs.MultiSelect = true;
		LB_AreaRPs.Name = "LB_AreaRPs";
		LB_AreaRPs.RelatedInfos = null;
		LB_AreaRPs.Size = new Size(246, 154);
		LB_AreaRPs.TabIndex = 28;
		lblTransform.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lblTransform.AutoSize = true;
		lblTransform.ForeColor = Color.FromArgb(220, 220, 220);
		lblTransform.Location = new Point(562, 471);
		lblTransform.Name = "lblTransform";
		lblTransform.Size = new Size(72, 13);
		lblTransform.TabIndex = 26;
		lblTransform.Text = "改变为：";
		DGV_ExlusionZone.AllowUserToAddRows = false;
		DGV_ExlusionZone.AllowUserToDeleteRows = false;
		DGV_ExlusionZone.AllowUserToOrderColumns = true;
		DGV_ExlusionZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_ExlusionZone.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_ExlusionZone.BorderStyle = BorderStyle.Fixed3D;
		DGV_ExlusionZone.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_ExlusionZone.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DGV_ExlusionZone.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DGV_ExlusionZone.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_ExlusionZone.Columns.AddRange(ID, Description, Points, Active);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		DGV_ExlusionZone.DefaultCellStyle = dataGridViewCellStyle5;
		DGV_ExlusionZone.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_ExlusionZone.EnableHeadersVisualStyles = false;
		DGV_ExlusionZone.Location = new Point(557, 49);
		DGV_ExlusionZone.MultiSelect = false;
		DGV_ExlusionZone.Name = "DGV_ExlusionZone";
		DGV_ExlusionZone.ReadOnly = true;
		DGV_ExlusionZone.RowHeadersVisible = false;
		DGV_ExlusionZone.RowHeadersWidth = 62;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DGV_ExlusionZone.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DGV_ExlusionZone.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_ExlusionZone.ShowCellToolTips = false;
		DGV_ExlusionZone.ShowEditingIcon = false;
		DGV_ExlusionZone.ShowRowErrors = false;
		DGV_ExlusionZone.Size = new Size(582, 141);
		DGV_ExlusionZone.TabIndex = 25;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.MinimumWidth = 8;
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "名称";
		Description.MinimumWidth = 8;
		Description.Name = "Description";
		Description.ReadOnly = true;
		Points.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Points.DataPropertyName = "MarkViolatorAs";
		Points.HeaderText = "未知违反者标记为：";
		Points.MinimumWidth = 8;
		Points.Name = "Points";
		Points.ReadOnly = true;
		Active.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Active.DataPropertyName = "IsActive";
		Active.FillWeight = 70f;
		Active.HeaderText = "启用";
		Active.MinimumWidth = 8;
		Active.Name = "Active";
		Active.ReadOnly = true;
		CBZoneIsLocked.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CBZoneIsLocked.AutoSize = true;
		CBZoneIsLocked.Location = new Point(561, 432);
		CBZoneIsLocked.Name = "CBZoneIsLocked";
		CBZoneIsLocked.Size = new Size(186, 17);
		CBZoneIsLocked.TabIndex = 18;
		CBZoneIsLocked.Text = "锁定的区域（用户不可编辑）";
		GB_Violators.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GB_Violators.Controls.Add(LV_ViolatorSides);
		GB_Violators.Controls.Add(DarkLabel4);
		GB_Violators.Controls.Add(Button_ViolatorNoChanges);
		GB_Violators.Controls.Add(Button_ViolatorUnfriendly);
		GB_Violators.Controls.Add(Button_ViolatorHostile);
		GB_Violators.ForeColor = Color.FromArgb(220, 220, 220);
		GB_Violators.Location = new Point(924, 197);
		GB_Violators.Name = "GB_Violators";
		GB_Violators.Size = new Size(214, 301);
		GB_Violators.TabIndex = 15;
		GB_Violators.TabStop = false;
		GB_Violators.Text = "违反者";
		LV_ViolatorSides.BackColor = Color.FromArgb(40, 43, 45);
		LV_ViolatorSides.Location = new Point(6, 19);
		LV_ViolatorSides.Name = "LV_ViolatorSides";
		LV_ViolatorSides.RelatedInfos = null;
		LV_ViolatorSides.Size = new Size(200, 230);
		LV_ViolatorSides.TabIndex = 18;
		LV_ViolatorSides.Text = "DarkListView1";
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(6, 256);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(51, 13);
		DarkLabel4.TabIndex = 36;
		DarkLabel4.Text = "标记为：";
		Button_ViolatorNoChanges.BackColor = Color.Transparent;
		Button_ViolatorNoChanges.DialogResult = DialogResult.None;
		Button_ViolatorNoChanges.ForeColor = SystemColors.Control;
		Button_ViolatorNoChanges.Location = new Point(135, 271);
		Button_ViolatorNoChanges.Name = "Button_ViolatorNoChanges";
		Button_ViolatorNoChanges.RoundRadius = 0;
		Button_ViolatorNoChanges.Size = new Size(72, 23);
		Button_ViolatorNoChanges.TabIndex = 21;
		Button_ViolatorNoChanges.Text = "不改变";
		Button_ViolatorUnfriendly.BackColor = Color.Transparent;
		Button_ViolatorUnfriendly.DialogResult = DialogResult.None;
		Button_ViolatorUnfriendly.ForeColor = Color.Orange;
		Button_ViolatorUnfriendly.Location = new Point(70, 271);
		Button_ViolatorUnfriendly.Name = "Button_ViolatorUnfriendly";
		Button_ViolatorUnfriendly.RoundRadius = 0;
		Button_ViolatorUnfriendly.Size = new Size(58, 23);
		Button_ViolatorUnfriendly.TabIndex = 20;
		Button_ViolatorUnfriendly.Text = "非友方";
		Button_ViolatorHostile.BackColor = Color.Transparent;
		Button_ViolatorHostile.DialogResult = DialogResult.None;
		Button_ViolatorHostile.ForeColor = Color.FromArgb(255, 70, 70);
		Button_ViolatorHostile.Location = new Point(7, 271);
		Button_ViolatorHostile.Name = "Button_ViolatorHostile";
		Button_ViolatorHostile.RoundRadius = 0;
		Button_ViolatorHostile.Size = new Size(58, 23);
		Button_ViolatorHostile.TabIndex = 19;
		Button_ViolatorHostile.Text = "敌方";
		DarkGroupBox_0.Controls.Add(CBAppliesShips);
		DarkGroupBox_0.Controls.Add(CBAppliesAircraft);
		DarkGroupBox_0.Controls.Add(DarkCheckBox_0);
		DarkGroupBox_0.Controls.Add(DarkCheckBox_1);
		DarkGroupBox_0.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox_0.Location = new Point(788, 379);
		DarkGroupBox_0.Name = "GBAppliesTo";
		DarkGroupBox_0.Size = new Size(130, 115);
		DarkGroupBox_0.TabIndex = 36;
		DarkGroupBox_0.TabStop = false;
		DarkGroupBox_0.Text = "应用于";
		CBAppliesShips.AutoSize = true;
		CBAppliesShips.Location = new Point(8, 63);
		CBAppliesShips.Name = "CBAppliesShips";
		CBAppliesShips.Size = new Size(47, 17);
		CBAppliesShips.TabIndex = 15;
		CBAppliesShips.Text = "舰船";
		CBAppliesAircraft.AutoSize = true;
		CBAppliesAircraft.Location = new Point(8, 17);
		CBAppliesAircraft.Name = "CBAppliesAircraft";
		CBAppliesAircraft.Size = new Size(59, 17);
		CBAppliesAircraft.TabIndex = 14;
		CBAppliesAircraft.Text = "飞机";
		DarkCheckBox_0.AutoSize = true;
		DarkCheckBox_0.Location = new Point(8, 41);
		DarkCheckBox_0.Name = "CBAppliesSubmarines";
		DarkCheckBox_0.Size = new Size(76, 17);
		DarkCheckBox_0.TabIndex = 16;
		DarkCheckBox_0.Text = "潜艇";
		DarkCheckBox_1.AutoSize = true;
		DarkCheckBox_1.Location = new Point(8, 86);
		DarkCheckBox_1.Name = "CBAppliesLandUnits";
		DarkCheckBox_1.Size = new Size(72, 17);
		DarkCheckBox_1.TabIndex = 17;
		DarkCheckBox_1.Text = "陆上单元";
		TV_Zones.BackColor = Color.FromArgb(70, 70, 70);
		TV_Zones.Location = new Point(582, 50);
		TV_Zones.MaxDragChange = 20;
		TV_Zones.Name = "TV_Zones";
		TV_Zones.Size = new Size(349, 141);
		TV_Zones.TabIndex = 11;
		TV_Zones.Text = "DarkTreeView1";
		LabelAreaEditor.AutoSize = true;
		LabelAreaEditor.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LabelAreaEditor.ForeColor = Color.FromArgb(220, 220, 220);
		LabelAreaEditor.Location = new Point(686, 2);
		LabelAreaEditor.Name = "LabelAreaEditor";
		LabelAreaEditor.Size = new Size(89, 20);
		LabelAreaEditor.TabIndex = 6;
		LabelAreaEditor.Text = "区域编辑";
		LabelAreaEditor.TextAlign = ContentAlignment.MiddleCenter;
		ButtonTabCusEnvZones.BackColor = Color.Gray;
		ButtonTabCusEnvZones.FlatStyle = FlatStyle.Flat;
		ButtonTabCusEnvZones.ForeColor = SystemColors.ActiveCaptionText;
		ButtonTabCusEnvZones.Location = new Point(834, 24);
		ButtonTabCusEnvZones.Name = "ButtonTabCusEnvZones";
		ButtonTabCusEnvZones.Size = new Size(102, 23);
		ButtonTabCusEnvZones.TabIndex = 38;
		ButtonTabCusEnvZones.Text = "自定义环境区域";
		ButtonTabCusEnvZones.UseVisualStyleBackColor = false;
		TV_CusEnvZones.BackColor = Color.FromArgb(70, 70, 70);
		TV_CusEnvZones.Location = new Point(582, 50);
		TV_CusEnvZones.MaxDragChange = 20;
		TV_CusEnvZones.Name = "TV_CusEnvZones";
		TV_CusEnvZones.Size = new Size(349, 141);
		TV_CusEnvZones.TabIndex = 41;
		DarkUIButton_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		DarkUIButton_0.BackColor = Color.Transparent;
		DarkUIButton_0.DialogResult = DialogResult.None;
		DarkUIButton_0.ForeColor = SystemColors.Control;
		DarkUIButton_0.Location = new Point(836, 327);
		DarkUIButton_0.Name = "btnCEZDet";
		DarkUIButton_0.RoundRadius = 0;
		DarkUIButton_0.Size = new Size(82, 20);
		DarkUIButton_0.TabIndex = 40;
		DarkUIButton_0.Text = "编辑自定义环境区域数据";
		Button_DrawPolygon.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_DrawPolygon.BackColor = Color.Transparent;
		Button_DrawPolygon.DialogResult = DialogResult.None;
		Button_DrawPolygon.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button_DrawPolygon.ForeColor = SystemColors.Control;
		Button_DrawPolygon.Location = new Point(742, 195);
		Button_DrawPolygon.Name = "Button_DrawPolygon";
		Button_DrawPolygon.RoundRadius = 0;
		Button_DrawPolygon.Size = new Size(88, 20);
		Button_DrawPolygon.TabIndex = 37;
		Button_DrawPolygon.Text = "绘制矩形";
		BtnApproveTransformTo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BtnApproveTransformTo.BackColor = Color.Transparent;
		BtnApproveTransformTo.DialogResult = DialogResult.None;
		BtnApproveTransformTo.ForeColor = SystemColors.Control;
		BtnApproveTransformTo.Location = new Point(758, 470);
		BtnApproveTransformTo.Name = "BtnApproveTransformTo";
		BtnApproveTransformTo.RoundRadius = 0;
		BtnApproveTransformTo.Size = new Size(24, 22);
		BtnApproveTransformTo.TabIndex = 34;
		BtnApproveTransformTo.Text = "开始";
		ButtonValidateArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonValidateArea.BackColor = Color.Transparent;
		ButtonValidateArea.DialogResult = DialogResult.None;
		ButtonValidateArea.ForeColor = SystemColors.Control;
		ButtonValidateArea.Location = new Point(836, 261);
		ButtonValidateArea.Name = "ButtonValidateArea";
		ButtonValidateArea.RoundRadius = 0;
		ButtonValidateArea.Size = new Size(82, 20);
		ButtonValidateArea.TabIndex = 32;
		ButtonValidateArea.Text = "检查";
		ButtonAddselectedRPtoArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonAddselectedRPtoArea.BackColor = Color.Transparent;
		ButtonAddselectedRPtoArea.DialogResult = DialogResult.None;
		ButtonAddselectedRPtoArea.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonAddselectedRPtoArea.ForeColor = SystemColors.Control;
		ButtonAddselectedRPtoArea.Location = new Point(584, 195);
		ButtonAddselectedRPtoArea.Name = "ButtonAddselectedRPtoArea";
		ButtonAddselectedRPtoArea.RoundRadius = 0;
		ButtonAddselectedRPtoArea.Size = new Size(152, 20);
		ButtonAddselectedRPtoArea.TabIndex = 29;
		ButtonAddselectedRPtoArea.Text = "添加地图上高亮的点";
		CBTransformTo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CBTransformTo.BackColor = Color.Transparent;
		CBTransformTo.DrawMode = DrawMode.OwnerDrawFixed;
		CBTransformTo.DropDownStyle = ComboBoxStyle.DropDownList;
		CBTransformTo.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CBTransformTo.FormattingEnabled = true;
		CBTransformTo.Items.AddRange(new object[4] { "区域", "禁航区", "封锁区", "Custom Environment Zone" });
		CBTransformTo.Location = new Point(640, 468);
		CBTransformTo.Name = "CBTransformTo";
		CBTransformTo.Size = new Size(110, 21);
		CBTransformTo.TabIndex = 27;
		ButtonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonSave.BackColor = Color.Transparent;
		ButtonSave.DialogResult = DialogResult.None;
		ButtonSave.ForeColor = SystemColors.Control;
		ButtonSave.Location = new Point(836, 349);
		ButtonSave.Name = "ButtonSave";
		ButtonSave.RoundRadius = 0;
		ButtonSave.Size = new Size(82, 20);
		ButtonSave.TabIndex = 23;
		ButtonSave.Text = "保存";
		ButtonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonExport.BackColor = Color.Transparent;
		ButtonExport.DialogResult = DialogResult.None;
		ButtonExport.ForeColor = SystemColors.Control;
		ButtonExport.Location = new Point(836, 306);
		ButtonExport.Name = "ButtonExport";
		ButtonExport.RoundRadius = 0;
		ButtonExport.Size = new Size(82, 20);
		ButtonExport.TabIndex = 22;
		ButtonExport.Text = "导出";
		ButtonImport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonImport.BackColor = Color.Transparent;
		ButtonImport.DialogResult = DialogResult.None;
		ButtonImport.ForeColor = SystemColors.Control;
		ButtonImport.Location = new Point(836, 284);
		ButtonImport.Name = "ButtonImport";
		ButtonImport.RoundRadius = 0;
		ButtonImport.Size = new Size(82, 20);
		ButtonImport.TabIndex = 13;
		ButtonImport.Text = "导入";
		TB_AreaName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TB_AreaName.AutoCompleteCustomSource = null;
		TB_AreaName.AutoCompleteMode = AutoCompleteMode.None;
		TB_AreaName.AutoCompleteSource = AutoCompleteSource.None;
		TB_AreaName.BackColor = Color.Transparent;
		TB_AreaName.ForeColor = Color.FromArgb(189, 189, 189);
		TB_AreaName.Image = null;
		TB_AreaName.Lines = null;
		TB_AreaName.Location = new Point(626, 379);
		TB_AreaName.MaxLength = 32767;
		TB_AreaName.Multiline = false;
		TB_AreaName.Name = "TB_AreaName";
		TB_AreaName.ReadOnly = false;
		TB_AreaName.ScrollBars = ScrollBars.None;
		TB_AreaName.SelectionStart = 0;
		TB_AreaName.Size = new Size(154, 24);
		TB_AreaName.TabIndex = 19;
		TB_AreaName.TextAlign = HorizontalAlignment.Left;
		TB_AreaName.UseSystemPasswordChar = false;
		TB_AreaName.WatermarkText = "Area name . . .";
		ButtonDeleteArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonDeleteArea.BackColor = Color.Transparent;
		ButtonDeleteArea.DialogResult = DialogResult.None;
		ButtonDeleteArea.ForeColor = SystemColors.Control;
		ButtonDeleteArea.Location = new Point(836, 217);
		ButtonDeleteArea.Name = "ButtonDeleteArea";
		ButtonDeleteArea.RoundRadius = 0;
		ButtonDeleteArea.Size = new Size(82, 20);
		ButtonDeleteArea.TabIndex = 8;
		ButtonDeleteArea.Text = "删除区域";
		ButtonCreateNewArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonCreateNewArea.BackColor = Color.Transparent;
		ButtonCreateNewArea.DialogResult = DialogResult.None;
		ButtonCreateNewArea.ForeColor = SystemColors.Control;
		ButtonCreateNewArea.Location = new Point(836, 239);
		ButtonCreateNewArea.Name = "ButtonCreateNewArea";
		ButtonCreateNewArea.RoundRadius = 0;
		ButtonCreateNewArea.Size = new Size(82, 20);
		ButtonCreateNewArea.TabIndex = 7;
		ButtonCreateNewArea.Text = "创建新的";
		ButtonAddRefPointToArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonAddRefPointToArea.BackColor = Color.Transparent;
		ButtonAddRefPointToArea.DialogResult = DialogResult.None;
		ButtonAddRefPointToArea.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonAddRefPointToArea.ForeColor = SystemColors.Control;
		ButtonAddRefPointToArea.Location = new Point(559, 221);
		ButtonAddRefPointToArea.Name = "ButtonAddRefPointToArea";
		ButtonAddRefPointToArea.RoundRadius = 0;
		ButtonAddRefPointToArea.Size = new Size(19, 57);
		ButtonAddRefPointToArea.TabIndex = 5;
		ButtonAddRefPointToArea.Text = ">";
		ButtonRemoveRefPointToArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonRemoveRefPointToArea.BackColor = Color.Transparent;
		ButtonRemoveRefPointToArea.DialogResult = DialogResult.None;
		ButtonRemoveRefPointToArea.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonRemoveRefPointToArea.ForeColor = SystemColors.Control;
		ButtonRemoveRefPointToArea.Location = new Point(559, 279);
		ButtonRemoveRefPointToArea.Name = "ButtonRemoveRefPointToArea";
		ButtonRemoveRefPointToArea.RoundRadius = 0;
		ButtonRemoveRefPointToArea.Size = new Size(19, 54);
		ButtonRemoveRefPointToArea.TabIndex = 4;
		ButtonRemoveRefPointToArea.Text = "<";
		ZoneOpacity_Label.AutoSize = true;
		ZoneOpacity_Label.ForeColor = Color.FromArgb(220, 220, 220);
		ZoneOpacity_Label.Location = new Point(680, 413);
		ZoneOpacity_Label.Name = "ZoneOpacity_Label";
		ZoneOpacity_Label.Size = new Size(54, 13);
		ZoneOpacity_Label.TabIndex = 42;
		ZoneOpacity_Label.Text = "透明度 %";
		Num_ZoneOpacity.Location = new Point(737, 410);
		Num_ZoneOpacity.Name = "Num_ZoneOpacity";
		Num_ZoneOpacity.Size = new Size(44, 20);
		Num_ZoneOpacity.TabIndex = 43;
		Button_MoveDownZonePriority.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_MoveDownZonePriority.BackColor = Color.Transparent;
		Button_MoveDownZonePriority.BackgroundImage = componentResourceManager.GetObject("Button_MoveDownZonePriority.BackgroundImage");
		Button_MoveDownZonePriority.Font = new Font("Segoe UI", 10f);
		Button_MoveDownZonePriority.ForeColor = Color.FromArgb(220, 220, 220);
		Button_MoveDownZonePriority.Image = componentResourceManager.GetObject("Button_MoveDownZonePriority.Image");
		Button_MoveDownZonePriority.Location = new Point(559, 120);
		Button_MoveDownZonePriority.Name = "Button_MoveDownZonePriority";
		Button_MoveDownZonePriority.Padding = new Padding(5);
		Button_MoveDownZonePriority.Size = new Size(19, 17);
		Button_MoveDownZonePriority.TabIndex = 45;
		Button_MoveUpZonePriority.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_MoveUpZonePriority.BackColor = Color.Transparent;
		Button_MoveUpZonePriority.BackgroundImage = componentResourceManager.GetObject("Button_MoveUpZonePriority.BackgroundImage");
		Button_MoveUpZonePriority.Font = new Font("Segoe UI", 10f);
		Button_MoveUpZonePriority.ForeColor = Color.FromArgb(220, 220, 220);
		Button_MoveUpZonePriority.Image = componentResourceManager.GetObject("Button_MoveUpZonePriority.Image");
		Button_MoveUpZonePriority.Location = new Point(559, 99);
		Button_MoveUpZonePriority.Name = "Button_MoveUpZonePriority";
		Button_MoveUpZonePriority.Padding = new Padding(5);
		Button_MoveUpZonePriority.Size = new Size(19, 17);
		Button_MoveUpZonePriority.TabIndex = 44;
		CB_NoFireZone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CB_NoFireZone.AutoSize = true;
		CB_NoFireZone.Location = new Point(561, 449);
		CB_NoFireZone.Name = "CB_NoFireZone";
		CB_NoFireZone.Size = new Size(226, 17);
		CB_NoFireZone.TabIndex = 46;
		CB_NoFireZone.Text = "禁止开火区域（舍弃区域内目标）";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(1145, 497);
		base.Controls.Add(CB_NoFireZone);
		base.Controls.Add(Button_MoveDownZonePriority);
		base.Controls.Add(Button_MoveUpZonePriority);
		base.Controls.Add(Num_ZoneOpacity);
		base.Controls.Add(ZoneOpacity_Label);
		base.Controls.Add(TV_CusEnvZones);
		base.Controls.Add(DarkUIButton_0);
		base.Controls.Add(ButtonTabCusEnvZones);
		base.Controls.Add(Button_DrawPolygon);
		base.Controls.Add(DarkLabel3);
		base.Controls.Add(DarkGroupBox_0);
		base.Controls.Add(Label_ZoneColor);
		base.Controls.Add(ButtonZoneColorPicker);
		base.Controls.Add(BtnApproveTransformTo);
		base.Controls.Add(DGV_NoNavZone);
		base.Controls.Add(ButtonValidateArea);
		base.Controls.Add(Button_ListDown);
		base.Controls.Add(Button_ListUp);
		base.Controls.Add(ButtonAddselectedRPtoArea);
		base.Controls.Add(LB_AreaRPs);
		base.Controls.Add(CBTransformTo);
		base.Controls.Add(lblTransform);
		base.Controls.Add(DGV_ExlusionZone);
		base.Controls.Add(ButtonSave);
		base.Controls.Add(ButtonExport);
		base.Controls.Add(ButtonImport);
		base.Controls.Add(TB_AreaName);
		base.Controls.Add(CBZoneIsLocked);
		base.Controls.Add(GB_Violators);
		base.Controls.Add(ButtonTabExclusionZones);
		base.Controls.Add(ButtonTabNoNavZones);
		base.Controls.Add(TV_Zones);
		base.Controls.Add(ButtonTabZones);
		base.Controls.Add(ButtonDeleteArea);
		base.Controls.Add(ButtonCreateNewArea);
		base.Controls.Add(LabelAreaEditor);
		base.Controls.Add(ButtonAddRefPointToArea);
		base.Controls.Add(ButtonRemoveRefPointToArea);
		base.Controls.Add(FlowPanelTabTagsFilter);
		base.Controls.Add(Panel3);
		base.Controls.Add(RefPointEditorPanel);
		base.Controls.Add(RefPointListContainer);
		MaximumSize = new Size(1161, 536);
		MinimumSize = new Size(1161, 536);
		base.Name = "ReferencePointManager";
		base.ShowIcon = false;
		Text = "区域和参考点管理";
		base.TopMost = true;
		RefPointEditorPanel.ResumeLayout(performLayout: false);
		RefPointEditorPanel.PerformLayout();
		Panel3.ResumeLayout(performLayout: false);
		Panel3.PerformLayout();
		FlowPanelTabTagsFilter.ResumeLayout(performLayout: false);
		RefPointListContainer.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGV_NoNavZone).EndInit();
		((ISupportInitialize)DGV_ExlusionZone).EndInit();
		GB_Violators.ResumeLayout(performLayout: false);
		GB_Violators.PerformLayout();
		DarkGroupBox_0.ResumeLayout(performLayout: false);
		DarkGroupBox_0.PerformLayout();
		((ISupportInitialize)Num_ZoneOpacity).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			RefPoints.Clear();
			m_ManagerUtils.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void WriteInterruptibleProccesor(object sender, EventArgs e)
	{
		RefPoints = Client.CurrentSide.RefPoints;
		NewInterruptibleProccesor();
		FillInterruptibleProccesor();
		InterruptInterruptibleProccesor();
		CreateInterruptibleProccesor(Zone.ZoneType.Zone);
		Client.CurrentScenario.GetNatureSide();
		ButtonTabCusEnvZones.Visible = Client.CurrentGame.IsScenEditGameMode;
	}

	private void NewInterruptibleProccesor(bool bool_0 = false)
	{
		List<int> list = new List<int>();
		foreach (int selectedIndex in LV_ReferencePoints.SelectedIndices)
		{
			list.Add(selectedIndex);
		}
		m_ManagerUtils.Clear();
		LV_ReferencePoints.Items.Clear();
		foreach (ReferencePoint item in Client.CurrentSide.RefPoints.OrderBy((ReferencePoint x) => x.Name).ToList())
		{
			bool flag = false;
			if (item.Tags.Count > 0)
			{
				flag = true;
				foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag in item.Tags)
				{
					if (Filters.ContainsKey(tag.Key) && Filters[tag.Key])
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				continue;
			}
			string text = "";
			if (item.Tags.Count > 0)
			{
				List<string> list2 = new List<string>();
				foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag2 in item.Tags)
				{
					list2.Add(tag2.Value.Name);
				}
				text = "  [" + string.Join(",", list2) + "]";
			}
			LV_ReferencePoints.Items.Add(new DarkListItem(item.Name + text));
			LV_ReferencePoints.Items.ElementAt(LV_ReferencePoints.Items.Count - 1).TextColor = item.color;
			if (!m_ManagerUtils.ContainsKey(LV_ReferencePoints.Items.Count - 1))
			{
				m_ManagerUtils.Add(LV_ReferencePoints.Items.Count - 1, item);
			}
		}
		if (m_ManagerUtils.Count > 0)
		{
			if (bool_0)
			{
				try
				{
					LV_ReferencePoints.SelectItems(list);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					LV_ReferencePoints.SelectItem(m_ManagerUtils.ElementAt(0).Key);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				LV_ReferencePoints.SelectItem(m_ManagerUtils.ElementAt(0).Key);
			}
		}
		SetupInterruptibleProccesor();
		CalculateInterruptibleProccesor();
	}

	private void PushInterruptibleProccesor(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		if (EnableReferencePointEvents)
		{
			NewInterruptibleProccesor();
		}
	}

	private void InvokeInterruptibleProccesor(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		if (EnableReferencePointEvents)
		{
			NewInterruptibleProccesor();
		}
	}

	private void SetupInterruptibleProccesor()
	{
		if (LV_ReferencePoints.SelectedIndices.Count == 0)
		{
			ExcludeInterruptibleProccesor(bool_0: false);
			return;
		}
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint == null)
		{
			ExcludeInterruptibleProccesor(bool_0: false);
			return;
		}
		ExcludeInterruptibleProccesor(bool_0: true);
		referencePoint = m_ManagerUtils[LV_ReferencePoints.SelectedIndices.ElementAt(0)];
		RefPointName.Text = referencePoint.Name;
		RefPointLatitude.Text = Misc.LatitudeToEnglish(referencePoint.Latitude);
		RefPointLongitude.Text = Misc.LongitudeToEnglish(referencePoint.Longitude);
		RefPointColorButton.BackColor = referencePoint.color;
		Client.HighlightedRefPoints.Clear();
		Client.HighlightedRefPoints.Add(referencePoint);
		CalculateInterruptibleProccesor();
	}

	private void ExcludeInterruptibleProccesor(bool bool_0)
	{
		RefPointLongitude.Visible = bool_0;
		RefPointEditorPanel.Visible = bool_0;
	}

	public ReferencePoint GetReferencePoint()
	{
		if (LV_ReferencePoints.SelectedIndices.Count == 0)
		{
			return null;
		}
		if (m_ManagerUtils.ContainsKey(LV_ReferencePoints.SelectedIndices.ElementAt(0)))
		{
			return m_ManagerUtils[LV_ReferencePoints.SelectedIndices.ElementAt(0)];
		}
		return null;
	}

	public List<ReferencePoint> GetReferencePointMultipleSelection()
	{
		if (LV_ReferencePoints.SelectedIndices.Count == 0)
		{
			return null;
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		foreach (int selectedIndex in LV_ReferencePoints.SelectedIndices)
		{
			if (m_ManagerUtils.ContainsKey(selectedIndex))
			{
				list.Add(m_ManagerUtils[selectedIndex]);
			}
		}
		return list;
	}

	private void IncludeInterruptibleProccesor(object sender, EventArgs e)
	{
		SetupInterruptibleProccesor();
	}

	private void SearchInterruptibleProccesor(object sender, EventArgs e)
	{
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
		}
	}

	private void EnableInterruptibleProccesor(object sender, EventArgs e)
	{
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
		}
	}

	private void ChangeInterruptibleProccesor(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		EnableReferencePointEvents = false;
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			Client.CurrentSide.RefPoints.Remove(item);
		}
		EnableReferencePointEvents = true;
		if (LV_ReferencePoints.Items.Count > 1)
		{
			LV_ReferencePoints.SelectItem(LV_ReferencePoints.SelectedIndices.ElementAt(0) - 1, bool_0: false);
		}
		NewInterruptibleProccesor();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		if (m.WParam.ToInt32() == 13)
		{
			RestartInterruptibleProccesor();
			List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
			if (referencePointMultipleSelection != null && referencePointMultipleSelection.Count > 0)
			{
				foreach (ReferencePoint item in referencePointMultipleSelection)
				{
					item.Name = RefPointName.Text;
				}
				NewInterruptibleProccesor(bool_0: true);
			}
			switch (m_MerchantPredicate)
			{
			case Zone.ZoneType.CustomEnvironmentZone:
				if (!Information.IsNothing(SelectedCustomEnvironmentZone))
				{
					SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedCustomEnvironmentZone.AreaColor.R, SelectedCustomEnvironmentZone.AreaColor.G, SelectedCustomEnvironmentZone.AreaColor.B);
				}
				break;
			case Zone.ZoneType.Zone:
				if (!Information.IsNothing(SelectedStandardZone))
				{
					SelectedStandardZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedStandardZone.AreaColor.R, SelectedStandardZone.AreaColor.G, SelectedStandardZone.AreaColor.B);
				}
				break;
			}
			if (LV_Tags.SelectedItems.Count > 0)
			{
				ReferencePointFlag referencePointFlag = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
				if (Client.CurrentSide.RefPointsTag.ContainsKey(referencePointFlag))
				{
					referencePointFlag.Name = SelectedTagTextBox.Text;
				}
			}
			InterruptInterruptibleProccesor();
			FillInterruptibleProccesor();
			return true;
		}
		return base.ProcessCmdKey(ref m, keyData);
	}

	private void InitInterruptibleProccesor(object sender, EventArgs e)
	{
		Client.CurrentSide.TagsCumulativeCount++;
		string string_ = "Tag" + Client.CurrentSide.TagsCumulativeCount;
		if (Operators.CompareString(SelectedTagTextBox.Text, "", TextCompare: true) != 0)
		{
			string_ = SelectedTagTextBox.Text;
		}
		Client.CurrentSide.RefPointsTag.Add(new ReferencePointFlag(string_), new Dictionary<ReferencePoint, ReferencePoint>());
		InterruptInterruptibleProccesor();
		CalculateInterruptibleProccesor();
		FillInterruptibleProccesor();
	}

	private void CheckInterruptibleProccesor(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedItems.Count == 0)
		{
			return;
		}
		ReferencePointFlag key = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
		if (!Client.CurrentSide.RefPointsTag.ContainsKey(key))
		{
			return;
		}
		foreach (KeyValuePair<ReferencePoint, ReferencePoint> item in Client.CurrentSide.RefPointsTag[key])
		{
			if (item.Key.Tags.ContainsKey(key))
			{
				item.Key.Tags.Remove(key);
			}
		}
		Client.CurrentSide.RefPointsTag.Remove(key);
		InterruptInterruptibleProccesor();
		CalculateInterruptibleProccesor();
		FillInterruptibleProccesor();
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.Tags.ContainsKey(key))
			{
				refPoint.Tags.Remove(key);
			}
		}
		NewInterruptibleProccesor();
	}

	private void ConcatInterruptibleProccesor(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedIndices.Count != 0)
		{
			SelectedTagTextBox.Text = LV_Tags.SelectedItems.ElementAt(0).Text;
		}
	}

	private void InterruptInterruptibleProccesor()
	{
		LV_Tags.Items.Clear();
		if (Client.CurrentSide.RefPointsTag.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> item in Client.CurrentSide.RefPointsTag)
		{
			DarkListItem darkListItem = new DarkListItem(item.Key.Name);
			darkListItem.Tag = item.Key;
			LV_Tags.Items.Add(darkListItem);
		}
		SelectedTagTextBox.Text = Client.CurrentSide.RefPointsTag.ElementAt(0).Key.Name;
		LV_Tags.SelectItem(LV_Tags.Items.Count - 1);
	}

	private void RemoveInterruptibleProccesor(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		ColorDialog colorDialog = new ColorDialog();
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			foreach (ReferencePoint item in referencePointMultipleSelection)
			{
				item.color = colorDialog.Color;
			}
		}
		NewInterruptibleProccesor();
	}

	private void FindInterruptibleProccesor(object sender, EventArgs e)
	{
		if (LV_Tags.SelectedIndices.Count == 0)
		{
			return;
		}
		ReferencePointFlag referencePointFlag = (ReferencePointFlag)LV_Tags.SelectedItems.ElementAt(0).Tag;
		if (!Client.CurrentSide.RefPointsTag.ContainsKey(referencePointFlag))
		{
			return;
		}
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (!item.Tags.ContainsKey(referencePointFlag))
			{
				item.Tags.Add(referencePointFlag, referencePointFlag);
				continue;
			}
			return;
		}
		CalculateInterruptibleProccesor();
		NewInterruptibleProccesor();
	}

	private void SetInterruptibleProccesor(object sender, EventArgs e)
	{
		if (RefPointTagListCombo.SelectedItem == null)
		{
			return;
		}
		ReferencePointFlag redFlag = ((RefPointTag)RefPointTagListCombo.SelectedItem).RedFlag;
		bool flag = false;
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0)
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (item.Tags.ContainsKey(redFlag))
			{
				item.Tags.Remove(redFlag);
				flag = true;
			}
		}
		if (flag)
		{
			CalculateInterruptibleProccesor();
			NewInterruptibleProccesor();
		}
	}

	public void TagFilterButtonClick(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		ReferencePointFlag key = (ReferencePointFlag)button.Tag;
		Filters[key] = !Filters[key];
		if (Filters[key])
		{
			button.BackColor = Color.FromArgb(60, 90, 60);
		}
		else
		{
			button.BackColor = Color.FromArgb(90, 60, 60);
		}
		NewInterruptibleProccesor();
	}

	private void FillInterruptibleProccesor()
	{
		List<Button> list = new List<Button>();
		FlowPanelTabTagsFilter.Controls.Clear();
		foreach (KeyValuePair<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> item in Client.CurrentSide.RefPointsTag)
		{
			list.Add(new Button());
			if (!Filters.ContainsKey(item.Key))
			{
				Filters.Add(item.Key, value: true);
			}
			Button button = list[list.Count - 1];
			button.Text = item.Key.Name;
			if (Filters[item.Key])
			{
				button.BackColor = Color.FromArgb(60, 90, 60);
			}
			else
			{
				button.BackColor = Color.FromArgb(90, 60, 60);
			}
			button.ForeColor = Color.White;
			button.FlatStyle = FlatStyle.Flat;
			button.Tag = item.Key;
			button.Click += TagFilterButtonClick;
			FlowPanelTabTagsFilter.Controls.Add(button);
		}
		NewInterruptibleProccesor(bool_0: true);
	}

	private void CalculateInterruptibleProccesor()
	{
		RefPointTagListCombo.Items.Clear();
		ReferencePoint referencePoint = GetReferencePoint();
		if (referencePoint == null || LV_Tags.SelectedIndices.Count == 0)
		{
			return;
		}
		RefPointTagListCombo.DisplayMember = "Name";
		RefPointTagListCombo.Tag = "RedFlag";
		foreach (KeyValuePair<ReferencePointFlag, ReferencePointFlag> tag in referencePoint.Tags)
		{
			if (Client.CurrentSide.RefPointsTag.ContainsKey(tag.Key))
			{
				RefPointTagListCombo.Items.Add(new RefPointTag(tag.Key.Name, tag.Key));
			}
		}
		if (RefPointTagListCombo.Items.Count > 0)
		{
			RefPointTagListCombo.SelectedIndex = 0;
		}
	}

	private void PopInterruptibleProccesor(List<ReferencePoint> list_0)
	{
		AreaPoints = list_0;
		InstantiateInterruptibleProccesor();
	}

	private void InstantiateInterruptibleProccesor()
	{
		LB_AreaRPs.Items.Clear();
		if (Information.IsNothing(AreaPoints))
		{
			return;
		}
		foreach (ReferencePoint areaPoint in AreaPoints)
		{
			DarkListItem darkListItem = new DarkListItem(areaPoint.Name);
			darkListItem.Tag = areaPoint;
			LB_AreaRPs.Items.Add(darkListItem);
		}
	}

	private void CreateInterruptibleProccesor(Zone.ZoneType zoneType_0, bool bool_0 = true)
	{
		Num_ZoneOpacity.ValueChanged -= LoginInterruptibleStrategy;
		switch (zoneType_0)
		{
		case Zone.ZoneType.Zone:
			if (bool_0)
			{
				InsertInterruptibleProccesor();
			}
			LabelAreaEditor.Text = "所有区域";
			GB_Violators.Visible = false;
			DarkGroupBox_0.Visible = false;
			CBZoneIsLocked.Visible = false;
			Button_MoveDownZonePriority.Visible = true;
			Button_MoveUpZonePriority.Visible = true;
			m_MerchantPredicate = Zone.ZoneType.Zone;
			TV_Zones.Visible = true;
			DGV_ExlusionZone.Visible = false;
			DGV_NoNavZone.Visible = false;
			ButtonImport.Visible = false;
			ButtonExport.Visible = false;
			ZoneOpacity_Label.Visible = true;
			Num_ZoneOpacity.Visible = true;
			CB_NoFireZone.Visible = false;
			ButtonZoneColorPicker.Visible = true;
			if (Information.IsNothing(SelectedStandardZone))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				Num_ZoneOpacity.Value = 100m;
			}
			else
			{
				ButtonZoneColorPicker.BackColor = SelectedStandardZone.AreaColor;
				Num_ZoneOpacity.Value = Math.Min(new decimal((float)(int)SelectedStandardZone.AreaColor.A / 255f * 100f), 100m);
			}
			Label_ZoneColor.Visible = true;
			TV_CusEnvZones.Visible = false;
			DarkUIButton_0.Visible = false;
			CBTransformTo.Visible = true;
			lblTransform.Visible = true;
			BtnApproveTransformTo.Visible = true;
			break;
		case Zone.ZoneType.NoNavZone:
			if (bool_0)
			{
				UpdateInterruptibleProccesor();
			}
			LabelAreaEditor.Text = "禁航区域";
			GB_Violators.Visible = true;
			DarkGroupBox_0.Visible = true;
			CBZoneIsLocked.Visible = true;
			m_MerchantPredicate = Zone.ZoneType.NoNavZone;
			TV_Zones.Visible = false;
			DGV_ExlusionZone.Visible = false;
			DGV_NoNavZone.Visible = true;
			ButtonImport.Visible = true;
			ButtonExport.Visible = true;
			Button_MoveDownZonePriority.Visible = false;
			Button_MoveUpZonePriority.Visible = false;
			ButtonZoneColorPicker.Visible = false;
			Label_ZoneColor.Visible = false;
			TV_CusEnvZones.Visible = false;
			DarkUIButton_0.Visible = false;
			CBTransformTo.Visible = true;
			lblTransform.Visible = true;
			BtnApproveTransformTo.Visible = true;
			ZoneOpacity_Label.Visible = false;
			Num_ZoneOpacity.Visible = false;
			CB_NoFireZone.Visible = true;
			break;
		case Zone.ZoneType.ExclusionZone:
			if (bool_0)
			{
				DisableInterruptibleProccesor();
			}
			LabelAreaEditor.Text = "封锁区";
			GB_Violators.Visible = true;
			DarkGroupBox_0.Visible = true;
			CBZoneIsLocked.Visible = false;
			CB_NoFireZone.Visible = false;
			m_MerchantPredicate = Zone.ZoneType.ExclusionZone;
			TV_Zones.Visible = false;
			Button_MoveDownZonePriority.Visible = false;
			Button_MoveUpZonePriority.Visible = false;
			DGV_ExlusionZone.Visible = true;
			DGV_NoNavZone.Visible = false;
			ButtonImport.Visible = true;
			ButtonExport.Visible = true;
			ButtonZoneColorPicker.Visible = false;
			Label_ZoneColor.Visible = false;
			ZoneOpacity_Label.Visible = false;
			Num_ZoneOpacity.Visible = false;
			TV_CusEnvZones.Visible = false;
			DarkUIButton_0.Visible = false;
			CBTransformTo.Visible = true;
			lblTransform.Visible = true;
			BtnApproveTransformTo.Visible = true;
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (bool_0)
			{
				PrepareInterruptibleProccesor();
			}
			LabelAreaEditor.Text = "自定义环境区域";
			GB_Violators.Visible = false;
			DarkGroupBox_0.Visible = false;
			CBZoneIsLocked.Visible = false;
			m_MerchantPredicate = Zone.ZoneType.CustomEnvironmentZone;
			TV_Zones.Visible = true;
			DGV_ExlusionZone.Visible = false;
			DGV_NoNavZone.Visible = false;
			TV_CusEnvZones.Visible = true;
			Button_MoveDownZonePriority.Visible = true;
			Button_MoveUpZonePriority.Visible = true;
			ButtonImport.Visible = false;
			ButtonExport.Visible = false;
			ButtonZoneColorPicker.Visible = true;
			Label_ZoneColor.Visible = true;
			DarkUIButton_0.Visible = true;
			CBTransformTo.Visible = false;
			lblTransform.Visible = false;
			BtnApproveTransformTo.Visible = false;
			if (Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				Num_ZoneOpacity.Value = 100m;
			}
			else
			{
				ButtonZoneColorPicker.BackColor = SelectedCustomEnvironmentZone.AreaColor;
				Num_ZoneOpacity.Value = Math.Min(new decimal((float)(int)SelectedCustomEnvironmentZone.AreaColor.A / 255f * 100f), 100m);
			}
			CB_NoFireZone.Visible = false;
			break;
		}
		Num_ZoneOpacity.ValueChanged += LoginInterruptibleStrategy;
	}

	private void CompareInterruptibleProccesor()
	{
		LV_ViolatorSides.Items.Clear();
		DarkListItem darkListItem = new DarkListItem();
		darkListItem.Text = "未知";
		if (!SelectedExlusionZone.ViolatorsStance.ContainsKey("UnknownContactSide"))
		{
			SelectedExlusionZone.ViolatorsStance.Add("UnknownContactSide", SelectedExlusionZone.MarkViolatorAs);
		}
		switch (SelectedExlusionZone.ViolatorsStance["UnknownContactSide"])
		{
		case Misc.PostureStance.Unfriendly:
			darkListItem.TextColor = Color.Orange;
			break;
		case Misc.PostureStance.Hostile:
			darkListItem.TextColor = Color.FromArgb(255, 70, 70);
			break;
		case Misc.PostureStance.Unknown:
			darkListItem.TextColor = Color.White;
			break;
		}
		darkListItem.Tag = "UnknownContactSide";
		LV_ViolatorSides.Items.Add(darkListItem);
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (Operators.CompareString(side.ObjectID, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				if (!SelectedExlusionZone.ViolatorsStance.ContainsKey(side.ObjectID))
				{
					SelectedExlusionZone.ViolatorsStance.Add(side.ObjectID, SelectedExlusionZone.MarkViolatorAs);
				}
				DarkListItem darkListItem2 = new DarkListItem();
				darkListItem2.Text = side.Name;
				switch (SelectedExlusionZone.ViolatorsStance[side.ObjectID])
				{
				case Misc.PostureStance.Unfriendly:
					darkListItem2.TextColor = Color.Orange;
					break;
				case Misc.PostureStance.Hostile:
					darkListItem2.TextColor = Color.FromArgb(255, 70, 70);
					break;
				case Misc.PostureStance.Unknown:
					darkListItem2.TextColor = Color.White;
					break;
				}
				darkListItem2.Tag = side.ObjectID;
				LV_ViolatorSides.Items.Add(darkListItem2);
			}
		}
	}

	private void ReadInterruptibleProccesor()
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
			if (exclusionZone.ViolatorsStance.ContainsKey("UnknownContactSide"))
			{
				dataRow["MarkViolatorAs"] = exclusionZone.ViolatorsStance["UnknownContactSide"].ToString();
			}
			else
			{
				dataRow["MarkViolatorAs"] = exclusionZone.MarkViolatorAs.ToString();
			}
			dataRow["IsActive"] = exclusionZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		DGV_ExlusionZone.DataSource = dataTable;
		DGV_NoNavZone.Refresh();
	}

	private void DisableInterruptibleProccesor()
	{
		ReadInterruptibleProccesor();
		if (Client.CurrentSide.ExclusionZones.Count <= 0)
		{
			SelectedExlusionZone = null;
		}
		else if (Information.IsNothing(SelectedExlusionZone))
		{
			SelectedExlusionZone = Client.CurrentSide.ExclusionZones[0];
		}
	}

	private void UpdateInterruptibleProccesor()
	{
		MapInterruptibleProccesor();
		if (Client.CurrentSide.NoNavZones.Count <= 0)
		{
			SelectedNoNavZone = null;
		}
		else if (Information.IsNothing(SelectedNoNavZone))
		{
			SelectedNoNavZone = Client.CurrentSide.NoNavZones[0];
		}
	}

	private void InsertInterruptibleProccesor()
	{
		SortInterruptibleProccesor();
		if (Client.CurrentSide.StandardZones.Count <= 0)
		{
			SelectedStandardZone = null;
		}
		else if (Information.IsNothing(SelectedStandardZone))
		{
			SelectedStandardZone = Client.CurrentSide.StandardZones[0];
		}
	}

	private void PrepareInterruptibleProccesor()
	{
		CalcInterruptibleProccesor();
		if (Client.CurrentScenario.NatureSideExists())
		{
			if (Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Count <= 0)
			{
				SelectedCustomEnvironmentZone = null;
			}
			else if (Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[0];
			}
		}
	}

	private void ReflectInterruptibleProccesor(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedExlusionZone))
		{
			ReadInterruptibleProccesor();
		}
	}

	private void VisitInterruptibleProccesor(object sender, EventArgs e)
	{
		RestartInterruptibleProccesor();
	}

	private void RestartInterruptibleProccesor()
	{
		int num = -1;
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing(SelectedStandardZone))
			{
				SelectedStandardZone.Description = TB_AreaName.Text;
				SortInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing(SelectedNoNavZone))
			{
				SelectedNoNavZone.Description = TB_AreaName.Text;
				if (DGV_NoNavZone.SelectedRows.Count > 0)
				{
					num = DGV_NoNavZone.SelectedRows[0].Index;
				}
				MapInterruptibleProccesor();
				if (num != -1)
				{
					DGV_NoNavZone.Rows[num].Selected = true;
				}
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (!Information.IsNothing(SelectedExlusionZone))
			{
				SelectedExlusionZone.Description = TB_AreaName.Text;
				if (DGV_ExlusionZone.SelectedRows.Count > 0)
				{
					num = DGV_ExlusionZone.SelectedRows[0].Index;
				}
				ReadInterruptibleProccesor();
				if (num != -1)
				{
					DGV_ExlusionZone.Rows[num].Selected = true;
				}
			}
			break;
		}
	}

	private void TestInterruptibleProccesor(object sender, EventArgs e)
	{
		CreateInterruptibleProccesor(Zone.ZoneType.Zone);
	}

	private void StopInterruptibleProccesor(object sender, EventArgs e)
	{
		CreateInterruptibleProccesor(Zone.ZoneType.NoNavZone);
	}

	private void CancelInterruptibleProccesor(object sender, EventArgs e)
	{
		CreateInterruptibleProccesor(Zone.ZoneType.ExclusionZone);
	}

	private void VerifyInterruptibleProccesor(object sender, EventArgs e)
	{
		CreateInterruptibleProccesor(Zone.ZoneType.CustomEnvironmentZone);
	}

	private void ListInterruptibleProccesor(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing(SelectedStandardZone))
			{
				Client.CurrentSide.StandardZones.Remove(SelectedStandardZone);
				SelectedStandardZone = null;
				SortInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing(SelectedNoNavZone))
			{
				Client.CurrentSide.NoNavZones.Remove(SelectedNoNavZone);
				SelectedNoNavZone = null;
				MapInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (!Information.IsNothing(SelectedExlusionZone))
			{
				Client.CurrentSide.ExclusionZones.Remove(SelectedExlusionZone);
				SelectedExlusionZone = null;
				ReadInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Remove(SelectedCustomEnvironmentZone);
				SelectedCustomEnvironmentZone = null;
				CalcInterruptibleProccesor();
			}
			break;
		}
	}

	private void ResolveInterruptibleProccesor(object sender, EventArgs e)
	{
		if (DGV_NoNavZone.SelectedRows.Count != 0)
		{
			int num = DGV_NoNavZone.Rows.IndexOf(DGV_NoNavZone.SelectedRows[0]);
			if (num != -1)
			{
				SelectedNoNavZone = Client.CurrentSide.NoNavZones[num];
				InstantiateInterruptibleProccesor();
			}
		}
	}

	private void PostInterruptibleProccesor(object sender, EventArgs e)
	{
		if (DGV_ExlusionZone.SelectedRows.Count != 0)
		{
			int num = DGV_ExlusionZone.Rows.IndexOf(DGV_ExlusionZone.SelectedRows[0]);
			if (num != -1)
			{
				SelectedExlusionZone = Client.CurrentSide.ExclusionZones[num];
				InstantiateInterruptibleProccesor();
			}
		}
	}

	private void RunInterruptibleProccesor(object sender, EventArgs e)
	{
		if (TV_Zones.SelectedNodes != null && TV_Zones.SelectedNodes.Count != 0)
		{
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			InstantiateInterruptibleProccesor();
			if (Information.IsNothing(SelectedStandardZone))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				PopInterruptibleProccesor(null);
				return;
			}
			TB_AreaName.Text = SelectedStandardZone.Description;
			ButtonZoneColorPicker.BackColor = m_CallbackPredicate.AreaColor;
			PopInterruptibleProccesor(m_CallbackPredicate.Area);
			CreateInterruptibleProccesor(m_MerchantPredicate, bool_0: false);
		}
	}

	private void StartInterruptibleProccesor(object sender, EventArgs e)
	{
		PublishInterruptibleProccesor();
	}

	private void AssetInterruptibleProccesor(object sender, EventArgs e)
	{
		PublishInterruptibleProccesor();
	}

	private void PrintInterruptibleProccesor(object sender, EventArgs e)
	{
		PublishInterruptibleProccesor();
	}

	private void DefineInterruptibleProccesor(object sender, EventArgs e)
	{
		PublishInterruptibleProccesor();
	}

	private void PublishInterruptibleProccesor()
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.NoNavZone:
			if (Information.IsNothing(SelectedNoNavZone))
			{
				if (Client.CurrentSide.NoNavZones.Count <= 0)
				{
					break;
				}
				SelectedNoNavZone = Client.CurrentSide.NoNavZones[0];
			}
			SelectedNoNavZone.AffectedUnitTypes.Clear();
			if (CBAppliesAircraft.Checked)
			{
				SelectedNoNavZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
			}
			if (CBAppliesShips.Checked)
			{
				SelectedNoNavZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
			}
			if (DarkCheckBox_0.Checked)
			{
				SelectedNoNavZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
			}
			if (DarkCheckBox_1.Checked)
			{
				SelectedNoNavZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (Information.IsNothing(SelectedExlusionZone))
			{
				if (Client.CurrentSide.ExclusionZones.Count <= 0)
				{
					break;
				}
				SelectedExlusionZone = Client.CurrentSide.ExclusionZones[0];
			}
			SelectedExlusionZone.AffectedUnitTypes.Clear();
			if (CBAppliesAircraft.Checked)
			{
				SelectedExlusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
			}
			if (CBAppliesShips.Checked)
			{
				SelectedExlusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
			}
			if (DarkCheckBox_0.Checked)
			{
				SelectedExlusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
			}
			if (DarkCheckBox_1.Checked)
			{
				SelectedExlusionZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
			}
			break;
		case Zone.ZoneType.Zone:
			break;
		}
	}

	private void AwakeInterruptibleProccesor(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || Operators.CompareString(DGV_ExlusionZone.Columns[e.ColumnIndex].Name, "Active", TextCompare: true) != 0)
		{
			return;
		}
		DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)DGV_ExlusionZone[e.ColumnIndex, e.RowIndex];
		ExclusionZone exclusionZone = null;
		string right = Conversions.ToString(DGV_ExlusionZone.Rows[e.RowIndex].Cells["ID"].Value);
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
			ReadInterruptibleProccesor();
		}
	}

	private void QueryInterruptibleProccesor()
	{
		if (!Information.IsNothing(SelectedNoNavZone) && Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CBZoneIsLocked.Visible = SelectedNoNavZone.IsLocked;
			CBZoneIsLocked.Enabled = false;
			TB_AreaName.Enabled = !SelectedNoNavZone.IsLocked;
			CBAppliesAircraft.Enabled = !SelectedNoNavZone.IsLocked;
			CBAppliesShips.Enabled = !SelectedNoNavZone.IsLocked;
			DarkCheckBox_0.Enabled = !SelectedNoNavZone.IsLocked;
			DarkCheckBox_1.Enabled = !SelectedNoNavZone.IsLocked;
			CBZoneIsLocked.Checked = SelectedNoNavZone.IsLocked;
			LB_AreaRPs.Enabled = !SelectedNoNavZone.IsLocked;
			ButtonDeleteArea.Enabled = !SelectedNoNavZone.IsLocked;
		}
	}

	private void ResetInterruptibleProccesor(object sender, EventArgs e)
	{
		string string_ = "新建区域";
		if (Operators.CompareString(TB_AreaName.Text, "", TextCompare: true) != 0)
		{
			string_ = TB_AreaName.Text;
		}
		AreaPoints = new List<ReferencePoint>();
		foreach (ReferencePoint refPoint in Client.CurrentSide.RefPoints)
		{
			if (refPoint.IsHighlighted && !Information.IsNothing(AreaPoints) && !AreaPoints.Contains(refPoint))
			{
				DarkListItem darkListItem = new DarkListItem(refPoint.Name);
				AreaPoints.Add(refPoint);
				darkListItem.Tag = refPoint;
				LB_AreaRPs.Items.Add(darkListItem);
			}
		}
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			if (Information.IsNothing(SelectedStandardZone))
			{
				Client.CurrentSide.StandardZones.Add(new Zone("新建区域", new List<ReferencePoint>()));
				SelectedStandardZone = Client.CurrentSide.StandardZones.ElementAt(Client.CurrentSide.StandardZones.Count - 1);
				SortInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (Information.IsNothing(SelectedNoNavZone))
			{
				Client.CurrentSide.NoNavZones.Add(new NoNavZone("新建区域", new List<ReferencePoint>(), Client.CurrentScenario, Client.CurrentSide));
				SelectedNoNavZone = Client.CurrentSide.NoNavZones.ElementAt(Client.CurrentSide.NoNavZones.Count - 1);
				MapInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (Information.IsNothing(SelectedExlusionZone))
			{
				Client.CurrentSide.ExclusionZones.Add(new ExclusionZone("新建区域", Client.CurrentSide, new List<ReferencePoint>(), Misc.PostureStance.Hostile));
				SelectedExlusionZone = Client.CurrentSide.ExclusionZones.ElementAt(Client.CurrentSide.ExclusionZones.Count - 1);
				ReadInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			Client.CurrentScenario.CreateNatureSideIfNeeded();
			RegisterInterruptibleProccesor();
			if (Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				RegisterInterruptibleProccesor();
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(string_, AreaPoints, Client.CurrentScenario, Client.CurrentScenario.GetNatureSide(), new Weather.WeatherProfile()));
				SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Last();
				CalcInterruptibleProccesor();
			}
			break;
		}
		foreach (ReferencePoint refPoint2 in Client.CurrentSide.RefPoints)
		{
			if (refPoint2.IsHighlighted && !Information.IsNothing(AreaPoints) && !AreaPoints.Contains(refPoint2))
			{
				DarkListItem darkListItem2 = new DarkListItem(refPoint2.Name);
				AreaPoints.Add(refPoint2);
				darkListItem2.Tag = refPoint2;
				LB_AreaRPs.Items.Add(darkListItem2);
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void MapInterruptibleProccesor()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		foreach (NoNavZone noNavZone in Client.CurrentSide.NoNavZones)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = noNavZone.ObjectID;
			dataRow["Description"] = noNavZone.Description;
			dataRow["IsActive"] = noNavZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		DGV_NoNavZone.DataSource = dataTable;
		DGV_NoNavZone.Refresh();
	}

	private void SortInterruptibleProccesor()
	{
		TV_Zones.SelectedNodesChanged -= RunInterruptibleProccesor;
		TV_Zones.Nodes.Clear();
		foreach (Zone standardZone in Client.CurrentSide.StandardZones)
		{
			DarkTreeNode darkTreeNode = new DarkTreeNode("[" + standardZone.GetLayer(Client.CurrentSide) + "] " + standardZone.Description);
			darkTreeNode.Tag = standardZone;
			TV_Zones.Nodes.Add(darkTreeNode);
		}
		TV_Zones.Refresh();
		TV_Zones.SelectedNodesChanged += RunInterruptibleProccesor;
	}

	private void CalcInterruptibleProccesor()
	{
		TV_CusEnvZones.SelectedNodesChanged -= ValidateInterruptibleStrategy;
		TV_CusEnvZones.Nodes.Clear();
		if (Client.CurrentScenario.NatureSideExists())
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode("[" + customEnvironmentZone.GetLayer(Client.CurrentSide) + "] " + customEnvironmentZone.Description);
				darkTreeNode.Tag = customEnvironmentZone;
				TV_CusEnvZones.Nodes.Add(darkTreeNode);
			}
		}
		TV_CusEnvZones.SelectedNodesChanged += ValidateInterruptibleStrategy;
	}

	private void RateInterruptibleProccesor(object sender, EventArgs e)
	{
		if (Information.IsNothing(AreaPoints))
		{
			return;
		}
		foreach (DarkListItem selectedItem in LB_AreaRPs.SelectedItems)
		{
			AreaPoints.Remove((ReferencePoint)selectedItem.Tag);
		}
		InstantiateInterruptibleProccesor();
		Client.MustRefreshMainForm = true;
	}

	private void FlushInterruptibleProccesor(object sender, EventArgs e)
	{
		if (LB_AreaRPs.SelectedItems.Count <= 1)
		{
			if (LB_AreaRPs.SelectedIndices.Count != 0)
			{
				int num = LB_AreaRPs.SelectedIndices[0];
				if (num != -1 && num > 0)
				{
					DarkListItem item = LB_AreaRPs.Items[num];
					ReferencePoint item2 = AreaPoints[num];
					LB_AreaRPs.Items.RemoveAt(num);
					AreaPoints.RemoveAt(num);
					num--;
					AreaPoints.Insert(num, item2);
					LB_AreaRPs.Items.Insert(num, item);
					LB_AreaRPs.SelectItem(num);
					Client.MustRefreshMainForm = true;
				}
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新排列一个参考点", "一次一点！");
		}
	}

	private void ForgotInterruptibleProccesor(object sender, EventArgs e)
	{
		if (LB_AreaRPs.SelectedItems.Count <= 1)
		{
			if (LB_AreaRPs.SelectedIndices.Count != 0)
			{
				int num = LB_AreaRPs.SelectedIndices[0];
				if (num != -1 && num < LB_AreaRPs.Items.Count - 1)
				{
					DarkListItem item = LB_AreaRPs.Items[num];
					ReferencePoint item2 = AreaPoints[num];
					LB_AreaRPs.Items.RemoveAt(num);
					AreaPoints.RemoveAt(num);
					num++;
					AreaPoints.Insert(num, item2);
					LB_AreaRPs.Items.Insert(num, item);
					LB_AreaRPs.SelectItem(num);
					Client.MustRefreshMainForm = true;
				}
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新排列一个参考点", "一次一点！");
		}
	}

	private void CollectInterruptibleProccesor(object sender, EventArgs e)
	{
		if (!Information.IsNothing(AreaPoints))
		{
			string string_ = null;
			if (ActiveUnit_Navigator.ValidateArea(ref AreaPoints, ref string_, null, Client.CurrentScenario, ""))
			{
				DarkMessageBox.ShowInformation("区域验证正确。", "");
			}
			else
			{
				DarkMessageBox.ShowWarning(string_, "");
			}
		}
	}

	private void OrderInterruptibleProccesor(object sender, EventArgs e)
	{
		List<ReferencePoint> referencePointMultipleSelection = GetReferencePointMultipleSelection();
		if (referencePointMultipleSelection == null || referencePointMultipleSelection.Count == 0 || Information.IsNothing(AreaPoints))
		{
			return;
		}
		foreach (ReferencePoint item in referencePointMultipleSelection)
		{
			if (!AreaPoints.Contains(item))
			{
				DarkListItem darkListItem = new DarkListItem(item.Name);
				AreaPoints.Add(item);
				darkListItem.Tag = referencePointMultipleSelection;
				LB_AreaRPs.Items.Add(darkListItem);
			}
		}
	}

	private void RegisterInterruptibleProccesor()
	{
		if (!Client.CurrentScenario.NatureSideExists())
		{
			return;
		}
		foreach (ReferencePoint areaPoint in AreaPoints)
		{
			if (!Client.CurrentScenario.GetNatureSide().RefPoints.Contains(areaPoint))
			{
				Client.CurrentScenario.GetNatureSide().RefPoints.Add(areaPoint);
				Client.CurrentSide.RefPoints.Remove(areaPoint);
			}
		}
	}

	private void ManageInterruptibleProccesor(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.NoNavZone:
		{
			if (SelectedNoNavZone != null)
			{
				switch (DarkMessageBox.ShowInformation("请选择禁航区。", "未选择区域", DarkDialogButton.YesNoCancel))
				{
				case DialogResult.Yes:
					SelectedNoNavZone = null;
					break;
				case DialogResult.Cancel:
					return;
				}
			}
			FindInterruptibleToken(new OpenFileDialog());
			RemoveInterruptibleToken().InitialDirectory = GameGeneral.ScenariosRootPath;
			if (RemoveInterruptibleToken().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			FileStream fileStream2 = new FileStream(RemoveInterruptibleToken().FileName, FileMode.Open, FileAccess.Read);
			XmlDocument xmlDocument2 = new XmlDocument();
			try
			{
				using (fileStream2)
				{
					try
					{
						xmlDocument2.Load(fileStream2);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						DarkMessageBox.ShowError("文件格式不正确，读取失败！", "读取错误");
						ProjectData.ClearProjectError();
					}
				}
				Zone zone2 = new Zone();
				bool isLocked = false;
				bool flag3 = true;
				XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("/NoNavZone");
				if (Information.IsNothing(xmlNode3))
				{
					xmlNode3 = xmlDocument2.SelectSingleNode("/ExclusionZone");
					flag3 = false;
				}
				if (xmlNode3 == null)
				{
					DarkMessageBox.ShowError("找不到XML数据。", "Error");
				}
				else
				{
					IEnumerator enumerator3 = null;
					try
					{
						enumerator3 = xmlNode3.ChildNodes.GetEnumerator();
						IEnumerator enumerator4 = null;
						while (enumerator3.MoveNext())
						{
							XmlNode xmlNode4 = (XmlNode)enumerator3.Current;
							string name2 = xmlNode4.Name;
							if (Operators.CompareString(name2, "Description", TextCompare: true) == 0)
							{
								zone2.Description = xmlNode4.InnerText;
							}
							else if (Operators.CompareString(name2, "Area", TextCompare: true) == 0)
							{
								try
								{
									enumerator4 = xmlNode4.ChildNodes.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										XmlNode xmlNode_2 = (XmlNode)enumerator4.Current;
										ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_2 = null;
										ReferencePoint referencePoint2 = ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_2);
										if (!flag3)
										{
											referencePoint2.ResetIDs();
										}
										zone2.Area.Add(referencePoint2);
									}
								}
								finally
								{
									if (enumerator4 is IDisposable)
									{
										(enumerator4 as IDisposable).Dispose();
									}
								}
							}
							else if (Operators.CompareString(name2, "AffectedUnitTypes", TextCompare: true) == 0)
							{
								zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
								string[] array2 = xmlNode4.InnerText.Split('_');
								string[] array5 = array2;
								foreach (string text2 in array5)
								{
									if (Versioned.IsNumeric(text2))
									{
										int num2 = Conversions.ToInteger(text2);
										zone2.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num2);
									}
								}
							}
							else if (Operators.CompareString(name2, "IsLocked", TextCompare: true) == 0)
							{
								isLocked = Conversions.ToBoolean(xmlNode4.InnerText);
							}
						}
					}
					finally
					{
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
					}
					if (Information.IsNothing(zone2.AffectedUnitTypes))
					{
						zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
						{
							GlobalVariables.ActiveUnitType.Aircraft,
							GlobalVariables.ActiveUnitType.Ship,
							GlobalVariables.ActiveUnitType.Submarine,
							GlobalVariables.ActiveUnitType.Facility
						};
					}
					if (SelectedNoNavZone == null)
					{
						NoNavZone noNavZone = new NoNavZone(zone2.Description, zone2.Area, Client.CurrentScenario, Client.CurrentSide, zone2.AffectedUnitTypes);
						noNavZone.IsLocked = isLocked;
						Client.CurrentSide.NoNavZones.Add(noNavZone);
						SelectedNoNavZone = noNavZone;
					}
					else
					{
						SelectedNoNavZone.Description = zone2.Description;
						SelectedNoNavZone.Area = zone2.Area;
						SelectedNoNavZone.AffectedUnitTypes = zone2.AffectedUnitTypes;
						SelectedNoNavZone.IsLocked = isLocked;
					}
					InstantiateInterruptibleProccesor();
					bool flag4 = false;
					Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
					Side[] array6 = sides_ReadOnly2;
					foreach (Side side2 in array6)
					{
						foreach (NoNavZone noNavZone2 in side2.NoNavZones)
						{
							if (noNavZone2 != SelectedNoNavZone)
							{
								continue;
							}
							foreach (ReferencePoint item in SelectedNoNavZone.Area)
							{
								if (!side2.RefPoints.Contains(item))
								{
									side2.RefPoints.Add(item);
								}
							}
							flag4 = true;
							break;
						}
						if (flag4)
						{
							break;
						}
					}
					MapInterruptibleProccesor();
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 101278", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Client.MustRefreshMainForm = true;
			break;
		}
		case Zone.ZoneType.ExclusionZone:
		{
			if (SelectedExlusionZone != null)
			{
				switch (DarkMessageBox.ShowInformation("请选择禁航区。", "封锁区", DarkDialogButton.YesNoCancel))
				{
				case DialogResult.Yes:
					SelectedExlusionZone = null;
					break;
				case DialogResult.Cancel:
					return;
				}
			}
			InvokeInterruptibleToken(new OpenFileDialog());
			PushInterruptibleToken().InitialDirectory = GameGeneral.ScenariosRootPath;
			if (PushInterruptibleToken().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			FileStream fileStream = new FileStream(PushInterruptibleToken().FileName, FileMode.Open, FileAccess.Read);
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
								string[] array3 = array;
								foreach (string text in array3)
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
					if (SelectedExlusionZone == null)
					{
						ExclusionZone exclusionZone = new ExclusionZone(zone.Description, Client.CurrentSide, zone.Area, postureStance, zone.AffectedUnitTypes);
						Client.CurrentSide.ExclusionZones.Add(exclusionZone);
						SelectedExlusionZone = exclusionZone;
					}
					else
					{
						SelectedExlusionZone.Description = zone.Description;
						SelectedExlusionZone.Area = zone.Area;
						SelectedExlusionZone.AffectedUnitTypes = zone.AffectedUnitTypes;
						SelectedExlusionZone.MarkViolatorAs = postureStance;
					}
					InstantiateInterruptibleProccesor();
					bool flag2 = false;
					Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
					Side[] array4 = sides_ReadOnly;
					foreach (Side side in array4)
					{
						foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
						{
							if (exclusionZone2 != SelectedExlusionZone)
							{
								continue;
							}
							foreach (ReferencePoint item2 in SelectedExlusionZone.Area)
							{
								if (!side.RefPoints.Contains(item2))
								{
									side.RefPoints.Add(item2);
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
					ReadInterruptibleProccesor();
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
			break;
		}
		case Zone.ZoneType.Zone:
			break;
		}
	}

	private void RevertInterruptibleProccesor(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.NoNavZone:
			if (Information.IsNothing(SelectedNoNavZone))
			{
				DarkMessageBox.ShowError("Please select a No Novigation Zone.", "未选择区域");
				break;
			}
			CalculateInterruptibleToken(new SaveFileDialog());
			FillInterruptibleToken().InitialDirectory = GameGeneral.ScenariosRootPath;
			if (FillInterruptibleToken().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				FileStream fileStream2 = File.Create(FillInterruptibleToken().FileName);
				XmlWriterSettings settings2 = new XmlWriterSettings();
				using MemoryStream memoryStream2 = RCMS.recyclableMemoryStreamManager_0.GetStream();
				using (XmlWriter xmlWriter2 = XmlWriter.Create(memoryStream2, settings2))
				{
					xmlWriter2.WriteStartElement("NoNavZone");
					xmlWriter2.WriteElementString("Description", SelectedNoNavZone.Description);
					xmlWriter2.WriteStartElement("Area");
					foreach (ReferencePoint item in SelectedNoNavZone.Area)
					{
						HashSet<string> hashSet_2 = null;
						xmlWriter2.WriteRaw(item.ToXML(ref hashSet_2));
						xmlWriter2.Flush();
					}
					xmlWriter2.WriteEndElement();
					xmlWriter2.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedNoNavZone.AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
					{
						int num = (int)theType;
						return num.ToString();
					})));
					xmlWriter2.WriteElementString("IsLocked", SelectedNoNavZone.IsLocked.ToString());
					xmlWriter2.WriteEndElement();
				}
				fileStream2.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Position);
				fileStream2.Close();
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 101279", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Client.MustRefreshMainForm = true;
			break;
		case Zone.ZoneType.ExclusionZone:
			if (Information.IsNothing(SelectedExlusionZone))
			{
				DarkMessageBox.ShowError("Please select a Exclusion Zone.", "未选择区域");
				break;
			}
			IncludeInterruptibleToken(new SaveFileDialog());
			ExcludeInterruptibleToken().InitialDirectory = GameGeneral.ScenariosRootPath;
			if (ExcludeInterruptibleToken().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				FileStream fileStream = File.Create(ExcludeInterruptibleToken().FileName);
				XmlWriterSettings settings = new XmlWriterSettings();
				using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
				using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
				{
					xmlWriter.WriteStartElement("ExclusionZone");
					xmlWriter.WriteElementString("Description", SelectedExlusionZone.Description);
					xmlWriter.WriteStartElement("Area");
					foreach (ReferencePoint item2 in SelectedExlusionZone.Area)
					{
						HashSet<string> hashSet_ = null;
						xmlWriter.WriteRaw(item2.ToXML(ref hashSet_));
						xmlWriter.Flush();
					}
					xmlWriter.WriteEndElement();
					byte markViolatorAs = (byte)SelectedExlusionZone.MarkViolatorAs;
					xmlWriter.WriteElementString("MarkViolatorAs", markViolatorAs.ToString());
					xmlWriter.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedExlusionZone.AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
					{
						int num2 = (int)theType;
						return num2.ToString();
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
			break;
		case Zone.ZoneType.Zone:
			break;
		}
	}

	private void CountInterruptibleStrategy(object sender, EventArgs e)
	{
		string text = TB_AreaName.Text;
		if (string.IsNullOrEmpty(text))
		{
			text = "新建区域";
		}
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			Client.CurrentSide.StandardZones.Add(new Zone(text, new List<ReferencePoint>()));
			SelectedStandardZone = Client.CurrentSide.StandardZones.ElementAt(Client.CurrentSide.StandardZones.Count - 1);
			SelectedStandardZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			CreateInterruptibleProccesor(Zone.ZoneType.Zone);
			break;
		case Zone.ZoneType.NoNavZone:
			Client.CurrentSide.NoNavZones.Add(new NoNavZone(text, new List<ReferencePoint>(), Client.CurrentScenario, Client.CurrentSide));
			SelectedNoNavZone = Client.CurrentSide.NoNavZones.ElementAt(Client.CurrentSide.NoNavZones.Count - 1);
			SelectedNoNavZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			CreateInterruptibleProccesor(Zone.ZoneType.NoNavZone);
			break;
		case Zone.ZoneType.ExclusionZone:
			Client.CurrentSide.ExclusionZones.Add(new ExclusionZone(text, Client.CurrentSide, new List<ReferencePoint>(), Misc.PostureStance.Hostile));
			SelectedExlusionZone = Client.CurrentSide.ExclusionZones.ElementAt(Client.CurrentSide.ExclusionZones.Count - 1);
			SelectedExlusionZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			CreateInterruptibleProccesor(Zone.ZoneType.ExclusionZone);
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			Client.CurrentScenario.CreateNatureSideIfNeeded();
			Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Add(new CustomEnvironmentZone(TB_AreaName.Text, new List<ReferencePoint>(), Client.CurrentScenario, Client.CurrentScenario.GetNatureSide(), new Weather.WeatherProfile()));
			SelectedCustomEnvironmentZone = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.Last();
			SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb(60, 100, 100, 100);
			CreateInterruptibleProccesor(Zone.ZoneType.CustomEnvironmentZone);
			break;
		}
	}

	private void CustomizeInterruptibleStrategy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedCustomEnvironmentZone))
		{
			if (Operators.CompareString(TB_AreaName.Text, "", TextCompare: true) == 0)
			{
				TB_AreaName.Text = "温度";
			}
			SelectedCustomEnvironmentZone.Description = TB_AreaName.Text;
			EditCustomEnvironmentArea editCustomEnvironmentArea = new EditCustomEnvironmentArea();
			CustomEnvironmentZone customEnvironmentZone_ = SelectedCustomEnvironmentZone;
			editCustomEnvironmentArea.CustomizeField(ref customEnvironmentZone_);
			SelectedCustomEnvironmentZone = customEnvironmentZone_;
			editCustomEnvironmentArea.TopMost = true;
			editCustomEnvironmentArea.Show();
		}
	}

	private void CloneInterruptibleStrategy(object sender, EventArgs e)
	{
		string left = CBTransformTo.Text;
		if (Operators.CompareString(left, "Zone", TextCompare: true) == 0)
		{
			switch (m_MerchantPredicate)
			{
			case Zone.ZoneType.NoNavZone:
				Zone.TransformTo(SelectedNoNavZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				Zone.TransformTo(SelectedExlusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				Zone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			SortInterruptibleProccesor();
		}
		else if (Operators.CompareString(left, "禁航区", TextCompare: true) == 0)
		{
			switch (m_MerchantPredicate)
			{
			case Zone.ZoneType.Zone:
				NoNavZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				NoNavZone.TransformTo(SelectedExlusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				NoNavZone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			MapInterruptibleProccesor();
		}
		else if (Operators.CompareString(left, "封锁区", TextCompare: true) == 0)
		{
			switch (m_MerchantPredicate)
			{
			case Zone.ZoneType.Zone:
				ExclusionZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.NoNavZone:
				ExclusionZone.TransformTo(SelectedNoNavZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.CustomEnvironmentZone:
				ExclusionZone.TransformTo(SelectedCustomEnvironmentZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			ReadInterruptibleProccesor();
		}
		else if (Operators.CompareString(left, "Custom Environment Zone", TextCompare: true) == 0)
		{
			switch (m_MerchantPredicate)
			{
			case Zone.ZoneType.Zone:
				CustomEnvironmentZone.TransformTo(SelectedStandardZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.NoNavZone:
				CustomEnvironmentZone.TransformTo(SelectedNoNavZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			case Zone.ZoneType.ExclusionZone:
				CustomEnvironmentZone.TransformTo(SelectedExlusionZone, Client.CurrentSide, Client.CurrentScenario);
				break;
			}
			ReadInterruptibleProccesor();
			SortInterruptibleProccesor();
			MapInterruptibleProccesor();
			CalcInterruptibleProccesor();
		}
	}

	private void ConnectInterruptibleStrategy(object sender, EventArgs e)
	{
	}

	private void MoveInterruptibleStrategy(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				ColorDialog colorDialog2 = new ColorDialog();
				if (colorDialog2.ShowDialog() == DialogResult.OK)
				{
					SelectedCustomEnvironmentZone.AreaColor = colorDialog2.Color;
					ButtonZoneColorPicker.BackColor = SelectedCustomEnvironmentZone.AreaColor;
				}
			}
			break;
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing(SelectedStandardZone))
			{
				ColorDialog colorDialog = new ColorDialog();
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					SelectedStandardZone.AreaColor = colorDialog.Color;
					ButtonZoneColorPicker.BackColor = SelectedStandardZone.AreaColor;
				}
			}
			break;
		}
	}

	private void DeleteInterruptibleStrategy(object sender, EventArgs e)
	{
	}

	private void AddInterruptibleStrategy(object sender, EventArgs e)
	{
	}

	private void DestroyInterruptibleStrategy(object sender, EventArgs e)
	{
	}

	private void ComputeInterruptibleStrategy(Misc.PostureStance postureStance_0)
	{
		if (LV_ViolatorSides.SelectedItems.Count != 0)
		{
			string key = (string)LV_ViolatorSides.SelectedItems.ElementAt(0).Tag;
			if (SelectedExlusionZone.ViolatorsStance.ContainsKey(key))
			{
				SelectedExlusionZone.ViolatorsStance[key] = postureStance_0;
			}
			int num = -1;
			if (DGV_ExlusionZone.SelectedRows.Count > 0)
			{
				num = DGV_ExlusionZone.SelectedRows[0].Index;
			}
			ReadInterruptibleProccesor();
			if (num != -1)
			{
				DGV_ExlusionZone.Rows[num].Selected = true;
			}
			CompareInterruptibleProccesor();
		}
	}

	private void PatchInterruptibleStrategy(object sender, EventArgs e)
	{
		ComputeInterruptibleStrategy(Misc.PostureStance.Hostile);
	}

	private void SelectInterruptibleStrategy(object sender, EventArgs e)
	{
		ComputeInterruptibleStrategy(Misc.PostureStance.Unfriendly);
	}

	private void CallInterruptibleStrategy(object sender, EventArgs e)
	{
		ComputeInterruptibleStrategy(Misc.PostureStance.Unknown);
	}

	private void LogoutInterruptibleStrategy(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			Client.AreaInPolygonDraw = SelectedStandardZone;
			break;
		case Zone.ZoneType.NoNavZone:
			Client.AreaInPolygonDraw = SelectedNoNavZone;
			break;
		case Zone.ZoneType.ExclusionZone:
			Client.AreaInPolygonDraw = SelectedExlusionZone;
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			Client.AreaInPolygonDraw = SelectedCustomEnvironmentZone;
			break;
		}
	}

	private void ViewInterruptibleStrategy(object sender, EventArgs e)
	{
		LoginInterruptibleStrategy(Num_ZoneOpacity, null);
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing(SelectedStandardZone))
			{
				SelectedStandardZone.Name = TB_AreaName.Text;
				SelectedStandardZone.Description = TB_AreaName.Text;
				SelectedStandardZone.Area = AreaPoints;
				int index4 = Client.CurrentSide.StandardZones.IndexOf(SelectedStandardZone);
				Client.CurrentSide.StandardZones[index4].Name = TB_AreaName.Text;
				Client.CurrentSide.StandardZones[index4].Description = TB_AreaName.Text;
				SortInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.NoNavZone:
			if (!Information.IsNothing(SelectedNoNavZone))
			{
				SelectedNoNavZone.Name = TB_AreaName.Text;
				SelectedNoNavZone.Description = TB_AreaName.Text;
				SelectedNoNavZone.Area = AreaPoints;
				int index2 = Client.CurrentSide.NoNavZones.IndexOf(SelectedNoNavZone);
				Client.CurrentSide.NoNavZones[index2].Name = TB_AreaName.Text;
				Client.CurrentSide.NoNavZones[index2].Description = TB_AreaName.Text;
				MapInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.ExclusionZone:
			if (!Information.IsNothing(SelectedExlusionZone))
			{
				SelectedExlusionZone.Name = TB_AreaName.Text;
				SelectedExlusionZone.Description = TB_AreaName.Text;
				SelectedExlusionZone.Area = AreaPoints;
				int index3 = Client.CurrentSide.ExclusionZones.IndexOf(SelectedExlusionZone);
				Client.CurrentSide.ExclusionZones[index3].Name = TB_AreaName.Text;
				Client.CurrentSide.ExclusionZones[index3].Description = TB_AreaName.Text;
				ReadInterruptibleProccesor();
			}
			break;
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				Client.CurrentScenario.CreateNatureSideIfNeeded();
				SelectedCustomEnvironmentZone.Name = TB_AreaName.Text;
				SelectedCustomEnvironmentZone.Description = TB_AreaName.Text;
				SelectedCustomEnvironmentZone.Area = AreaPoints;
				int index = Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones.IndexOf(SelectedCustomEnvironmentZone);
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[index].Name = TB_AreaName.Text;
				Client.CurrentScenario.GetNatureSide().CustomEnvironmentZones[index].Description = TB_AreaName.Text;
				CalcInterruptibleProccesor();
			}
			break;
		}
	}

	private void ValidateInterruptibleStrategy(object sender, EventArgs e)
	{
		if (TV_CusEnvZones.SelectedNodes != null && TV_CusEnvZones.SelectedNodes.Count != 0)
		{
			SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
			InstantiateInterruptibleProccesor();
			if (Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				ButtonZoneColorPicker.BackColor = Color.White;
				PopInterruptibleProccesor(null);
				return;
			}
			TB_AreaName.Text = SelectedCustomEnvironmentZone.Description;
			ButtonZoneColorPicker.BackColor = SelectedCustomEnvironmentZone.AreaColor;
			PopInterruptibleProccesor(SelectedCustomEnvironmentZone.Area);
			CreateInterruptibleProccesor(m_MerchantPredicate, bool_0: false);
		}
	}

	private void LoginInterruptibleStrategy(object sender, EventArgs e)
	{
		switch (m_MerchantPredicate)
		{
		case Zone.ZoneType.CustomEnvironmentZone:
			if (!Information.IsNothing(SelectedCustomEnvironmentZone))
			{
				SelectedCustomEnvironmentZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedCustomEnvironmentZone.AreaColor.R, SelectedCustomEnvironmentZone.AreaColor.G, SelectedCustomEnvironmentZone.AreaColor.B);
			}
			break;
		case Zone.ZoneType.Zone:
			if (!Information.IsNothing(SelectedStandardZone))
			{
				SelectedStandardZone.AreaColor = Color.FromArgb((byte)Math.Round(Math.Min(Convert.ToDouble(Num_ZoneOpacity.Value) * 2.55, 255.0)), SelectedStandardZone.AreaColor.R, SelectedStandardZone.AreaColor.G, SelectedStandardZone.AreaColor.B);
			}
			break;
		}
	}

	private void GetInterruptibleStrategy(object sender, EventArgs e)
	{
		if (m_MerchantPredicate == Zone.ZoneType.CustomEnvironmentZone)
		{
			if (TV_CusEnvZones.SelectedNodes != null && TV_CusEnvZones.SelectedNodes.Count != 0)
			{
				SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
				if (!Information.IsNothing(SelectedCustomEnvironmentZone))
				{
					CustomEnvironmentZone selectedCustomEnvironmentZone;
					Side currentSide;
					(selectedCustomEnvironmentZone = SelectedCustomEnvironmentZone).SetLayer(currentSide = Client.CurrentSide, selectedCustomEnvironmentZone.GetLayer(currentSide) - 1);
					CreateInterruptibleProccesor(m_MerchantPredicate);
				}
			}
		}
		else if (m_MerchantPredicate == Zone.ZoneType.Zone && TV_Zones.SelectedNodes != null && TV_Zones.SelectedNodes.Count != 0)
		{
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing(SelectedStandardZone))
			{
				Zone selectedStandardZone;
				Side currentSide2;
				(selectedStandardZone = SelectedStandardZone).SetLayer(currentSide2 = Client.CurrentSide, selectedStandardZone.GetLayer(currentSide2) - 1);
				CreateInterruptibleProccesor(m_MerchantPredicate);
			}
		}
	}

	private void WriteInterruptibleStrategy(object sender, EventArgs e)
	{
		if (m_MerchantPredicate == Zone.ZoneType.CustomEnvironmentZone)
		{
			if (TV_CusEnvZones.SelectedNodes != null && TV_CusEnvZones.SelectedNodes.Count != 0)
			{
				SelectedCustomEnvironmentZone = (CustomEnvironmentZone)TV_CusEnvZones.SelectedNodes.ElementAt(0).Tag;
				if (!Information.IsNothing(SelectedCustomEnvironmentZone))
				{
					CustomEnvironmentZone selectedCustomEnvironmentZone;
					Side currentSide;
					(selectedCustomEnvironmentZone = SelectedCustomEnvironmentZone).SetLayer(currentSide = Client.CurrentSide, selectedCustomEnvironmentZone.GetLayer(currentSide) + 1);
					CreateInterruptibleProccesor(m_MerchantPredicate);
				}
			}
		}
		else if (m_MerchantPredicate == Zone.ZoneType.Zone && TV_Zones.SelectedNodes != null && TV_Zones.SelectedNodes.Count != 0)
		{
			SelectedStandardZone = (Zone)TV_Zones.SelectedNodes.ElementAt(0).Tag;
			if (!Information.IsNothing(SelectedStandardZone))
			{
				Zone selectedStandardZone;
				Side currentSide2;
				(selectedStandardZone = SelectedStandardZone).SetLayer(currentSide2 = Client.CurrentSide, selectedStandardZone.GetLayer(currentSide2) + 1);
				CreateInterruptibleProccesor(m_MerchantPredicate);
			}
		}
	}

	private void NewInterruptibleStrategy(object sender, EventArgs e)
	{
		threadPredicate.NoFireZone = CB_NoFireZone.Checked;
	}
}
