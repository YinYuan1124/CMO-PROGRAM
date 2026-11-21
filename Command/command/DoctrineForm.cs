using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DoctrineForm : DarkSecondaryFormBase
{
	private IContainer _IdentifierStub;

	[AccessedThroughProperty("TabControl1A")]
	[CompilerGenerated]
	private DarkUITabControl printerStub;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage algoStub;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_Radar")]
	private DarkUIComboBox m_DatabaseStub;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel interceptorStub;

	[AccessedThroughProperty("CB_EMCON_Inherits")]
	[CompilerGenerated]
	private DarkCheckBox m_MessageStub;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_OECM")]
	private DarkUIComboBox m_ProductStub;

	[AccessedThroughProperty("CB_EMCON_Sonar")]
	[CompilerGenerated]
	private DarkUIComboBox iteratorStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label9")]
	private DarkLabel m_InitializerStub;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage roleStub;

	[AccessedThroughProperty("TGV_WRA")]
	[CompilerGenerated]
	private DarkTreeGridView factoryStub;

	[AccessedThroughProperty("Button_ResetCurrent_WRA")]
	[CompilerGenerated]
	private DarkUIButton attributeStub;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel eventStub;

	[AccessedThroughProperty("Label16")]
	[CompilerGenerated]
	private DarkLabel m_GlobalStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label15")]
	private DarkLabel workerStub;

	[AccessedThroughProperty("Label14")]
	[CompilerGenerated]
	private DarkLabel accountStub;

	[AccessedThroughProperty("Label10")]
	[CompilerGenerated]
	private DarkLabel authenticationStub;

	[AccessedThroughProperty("Label12")]
	[CompilerGenerated]
	private DarkLabel m_InfoStub;

	[AccessedThroughProperty("CB_WeaponStateRTB_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox m_HelperStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label13")]
	private DarkLabel mapperStub;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeaponControlStatus_Air_PlayerEditable")]
	private DarkCheckBox managerStub;

	[AccessedThroughProperty("CB_UseNukes_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _GetterStub;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_ProducerStub;

	[AccessedThroughProperty("Combo_WeaponStateRTB")]
	[CompilerGenerated]
	private DarkUIComboBox _ProcStub;

	[AccessedThroughProperty("Combo_WeaponControlStatus_Air")]
	[CompilerGenerated]
	private DarkUIComboBox _StructWriter;

	[AccessedThroughProperty("Combo_UseNukes")]
	[CompilerGenerated]
	private DarkUIComboBox merchantWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel callbackWriter;

	[AccessedThroughProperty("Combo_BehaviorTowardsAmbigousTarget")]
	[CompilerGenerated]
	private DarkUIComboBox m_DecoratorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BehaviorTowardsAmbigousTarget_PlayerEditable")]
	private DarkCheckBox _ProcessWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_AutoEvade")]
	private DarkUIComboBox _RuleWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AutoEvade_PlayerEditable")]
	private DarkCheckBox collectionWriter;

	[AccessedThroughProperty("Combo_Standoff")]
	[CompilerGenerated]
	private DarkUIComboBox instanceWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Standoff_PlayerEditable")]
	private DarkCheckBox objectWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_UseRefuel")]
	private DarkUIComboBox m_ParameterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UseRefuel_PlayerEditable")]
	private DarkCheckBox m_ExpressionWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_ShootTourists")]
	private DarkUIComboBox m_DispatcherWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShootTourists_PlayerEditable")]
	private DarkCheckBox _ListenerWriter;

	[AccessedThroughProperty("Combo_UseSAMsOnASuW")]
	[CompilerGenerated]
	private DarkUIComboBox configWriter;

	[AccessedThroughProperty("CB_UseSAMsOnASuW_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox m_RegistryWriter;

	[AccessedThroughProperty("Combo_IgnoreEMCONunderAttack")]
	[CompilerGenerated]
	private DarkUIComboBox definitionWriter;

	[AccessedThroughProperty("CB_IgnoreEMCONunderAttack_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _ValWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_QuickTurnAroundForAicraft")]
	private DarkUIComboBox _ObserverWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_UseKinematicRangeForTorpedoes")]
	private DarkUIComboBox _IssuerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnAroundForAicraft_PlayerEditable")]
	private DarkCheckBox m_ClientWriter;

	[AccessedThroughProperty("CB_UseKinematicRangeForTorpedoes_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox dicWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label18")]
	private DarkLabel consumerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_AirOpsTempo")]
	private DarkUIComboBox _FacadeWriter;

	[AccessedThroughProperty("CB_AirOpsTempo_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _ProxyWriter;

	[AccessedThroughProperty("Label19")]
	[CompilerGenerated]
	private DarkLabel readerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label22")]
	private DarkLabel m_RepositoryWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedMissions_Doctrine")]
	private DarkUIButton _ClassWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedUnits_Doctrine")]
	private DarkUIButton m_RequestWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetCurrent_Doctrine")]
	private DarkUIButton _ValueWriter;

	[AccessedThroughProperty("Button_ResetAffectedMissions_WRA")]
	[CompilerGenerated]
	private DarkUIButton _TokenizerWriter;

	[AccessedThroughProperty("Button_ResetAffectedUnits_WRA")]
	[CompilerGenerated]
	private DarkUIButton stubWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedMissions_EMCON")]
	private DarkUIButton writerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetAffectedUnits_EMCON")]
	private DarkUIButton _SpecificationWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetCurrent_EMCON")]
	private DarkUIButton watcherWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_IgnorePlottedCourse")]
	private DarkUIComboBox descriptorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IgnorePlottedCourse_PlayerEditable")]
	private DarkCheckBox _PoolWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_TaskWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label23")]
	private DarkLabel m_FilterWriter;

	[AccessedThroughProperty("Label26")]
	[CompilerGenerated]
	private DarkLabel m_TestsWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeaponControlStatus_Surface_PlayerEditable")]
	private DarkCheckBox m_InterpreterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeaponControlStatus_Submarine_PlayerEditable")]
	private DarkCheckBox m_ContainerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeaponControlStatus_Land_PlayerEditable")]
	private DarkCheckBox m_ComposerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WeaponControlStatus_Surface")]
	private DarkUIComboBox modelWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WeaponControlStatus_Submarine")]
	private DarkUIComboBox advisorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WeaponControlStatus_Land")]
	private DarkUIComboBox _CustomerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label27")]
	private DarkLabel serializerWriter;

	[AccessedThroughProperty("CB_GunStrafing_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox refWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_GunStrafing")]
	private DarkUIComboBox errorWriter;

	[AccessedThroughProperty("Combo_WithdrawDefenceThreshold")]
	[CompilerGenerated]
	private DarkUIComboBox connectionWriter;

	[AccessedThroughProperty("Combo_WithdrawAttackThreshold")]
	[CompilerGenerated]
	private DarkUIComboBox _ContextWriter;

	[AccessedThroughProperty("Combo_WithdrawFuelThreshold")]
	[CompilerGenerated]
	private DarkUIComboBox statusWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label45")]
	private DarkLabel proccesorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label43")]
	private DarkLabel m_StrategyWriter;

	[AccessedThroughProperty("Label44")]
	[CompilerGenerated]
	private DarkLabel configurationWriter;

	[AccessedThroughProperty("Label42")]
	[CompilerGenerated]
	private DarkLabel tokenWriter;

	[AccessedThroughProperty("Combo_WithdrawDamageThreshold")]
	[CompilerGenerated]
	private DarkUIComboBox m_IndexerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_RedeployDefenceThreshold")]
	private DarkUIComboBox m_PublisherWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_RedeployAttackThreshold")]
	private DarkUIComboBox serverWriter;

	[AccessedThroughProperty("Combo_RedeployFuelThreshold")]
	[CompilerGenerated]
	private DarkUIComboBox _AdapterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label47")]
	private DarkLabel utilsWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label48")]
	private DarkLabel predicateWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_RedeployDamageThreshold")]
	private DarkUIComboBox _RecordWriter;

	[AccessedThroughProperty("TargetType")]
	[CompilerGenerated]
	private TreeGridColumn m_AttrWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponsPerSalvo")]
	private DataGridViewComboBoxColumn visitorWriter;

	[AccessedThroughProperty("ShootersPerSalvo")]
	[CompilerGenerated]
	private DataGridViewComboBoxColumn m_ExporterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("SelfDefenceRange")]
	private DataGridViewComboBoxColumn comparatorWriter;

	[AccessedThroughProperty("Label51")]
	[CompilerGenerated]
	private DarkLabel itemWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ReplenishmentSelection_PlayerEditable")]
	private DarkCheckBox setterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_ReplenishmentSelection")]
	private DarkUIComboBox _CreatorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label28")]
	private DarkLabel templateWriter;

	[AccessedThroughProperty("Label29")]
	[CompilerGenerated]
	private DarkLabel m_MappingWriter;

	[AccessedThroughProperty("Label30")]
	[CompilerGenerated]
	private DarkLabel mockWriter;

	[AccessedThroughProperty("CB_FuelState_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _TagWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_WeaponState_PlayerEditable")]
	private DarkCheckBox _FieldWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label31")]
	private DarkLabel m_QueueWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_JettisonOrdnance_PlayerEditable")]
	private DarkCheckBox regWriter;

	[AccessedThroughProperty("CB_FuelStateRTB_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _ParamWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label32")]
	private DarkLabel pageWriter;

	[AccessedThroughProperty("Label33")]
	[CompilerGenerated]
	private DarkLabel rulesWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label34")]
	private DarkLabel methodWriter;

	[AccessedThroughProperty("CB_RefuelAllies_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox serviceWriter;

	[AccessedThroughProperty("CB_AvoidContact_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox baseWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DiveWhenThreatsDetected_PlayerEditable")]
	private DarkCheckBox _PolicyWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label37")]
	private DarkLabel m_BroadcasterWriter;

	[AccessedThroughProperty("CB_BatteryRechargePatrol_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _IdentifierWriter;

	[AccessedThroughProperty("Label38")]
	[CompilerGenerated]
	private DarkLabel m_PrinterWriter;

	[AccessedThroughProperty("CB_BatteryRechargeAttack_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox m_ParserWriter;

	[AccessedThroughProperty("Label39")]
	[CompilerGenerated]
	private DarkLabel algoWriter;

	[AccessedThroughProperty("CB_AIP_Usage_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox databaseWriter;

	[AccessedThroughProperty("Label40")]
	[CompilerGenerated]
	private DarkLabel interceptorWriter;

	[AccessedThroughProperty("CB_DippingSonar_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox m_MessageWriter;

	[AccessedThroughProperty("Combo_FuelState")]
	[CompilerGenerated]
	private DarkUIComboBox m_ProductWriter;

	[AccessedThroughProperty("Combo_WeaponState")]
	[CompilerGenerated]
	private DarkUIComboBox _AnnotationWriter;

	[AccessedThroughProperty("Combo_Jettison")]
	[CompilerGenerated]
	private DarkUIComboBox iteratorWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_FuelStateRTB")]
	private DarkUIComboBox m_InitializerWriter;

	[AccessedThroughProperty("Combo_RefuelAllies")]
	[CompilerGenerated]
	private DarkUIComboBox roleWriter;

	[AccessedThroughProperty("Combo_AvoidContact")]
	[CompilerGenerated]
	private DarkUIComboBox _FactoryWriter;

	[AccessedThroughProperty("Combo_DiveWhenThreatsDetected")]
	[CompilerGenerated]
	private DarkUIComboBox _AttributeWriter;

	[AccessedThroughProperty("Combo_BatteryRechargePatrol")]
	[CompilerGenerated]
	private DarkUIComboBox m_EventWriter;

	[AccessedThroughProperty("Combo_BatteryRechargeAttack")]
	[CompilerGenerated]
	private DarkUIComboBox globalWriter;

	[AccessedThroughProperty("Combo_AIP_Usage")]
	[CompilerGenerated]
	private DarkUIComboBox workerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_DippingSonar")]
	private DarkUIComboBox accountWriter;

	[AccessedThroughProperty("CB_BVRLogic_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _AuthenticationWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_BVRLogic")]
	private DarkUIComboBox paramsWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel1")]
	private DarkLabel m_InfoWriter;

	[AccessedThroughProperty("DarkLabel4")]
	[CompilerGenerated]
	private DarkLabel managerWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Surface_Navigation_PlayerEditable")]
	private DarkCheckBox _GetterWriter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Submarine_Navigation_PlayerEditable")]
	private DarkCheckBox _ProducerWriter;

	[AccessedThroughProperty("CB_Land_Navigation_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox _ProcWriter;

	[AccessedThroughProperty("Combo_Surface_Navigation")]
	[CompilerGenerated]
	private DarkUIComboBox _StructOrder;

	[AccessedThroughProperty("Combo_Submarine_Navigation")]
	[CompilerGenerated]
	private DarkUIComboBox merchantOrder;

	[AccessedThroughProperty("Combo_Land_Navigation")]
	[CompilerGenerated]
	private DarkUIComboBox callbackOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("UseIntervalGroup")]
	private DarkGroupBox decoratorOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("EmissionIntervalTABControl")]
	private DarkUITabControl m_ProcessOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("BlueAlert")]
	private TabPage m_RuleOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_AEI_2")]
	private DarkLabel collectionOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("IntervalVariation")]
	private DarkUITextBox _InstanceOrder;

	[AccessedThroughProperty("Interval")]
	[CompilerGenerated]
	private DarkUITextBox m_ObjectOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("YellowAlert")]
	private TabPage m_ParameterOrder;

	[AccessedThroughProperty("OrangeAlert")]
	[CompilerGenerated]
	private TabPage expressionOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("BackToSleepTime")]
	private DarkUITextBox m_ListenerOrder;

	[AccessedThroughProperty("CBWakeWhenDetectingThreat")]
	[CompilerGenerated]
	private DarkUICheckBox _ConfigOrder;

	[AccessedThroughProperty("Label_AEI_1")]
	[CompilerGenerated]
	private DarkLabel registryOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("IntermittantToggle")]
	private DarkUIButton _ValOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_AEI_0")]
	private DarkLabel m_WrapperOrder;

	[AccessedThroughProperty("EmissionDurationTextBox")]
	[CompilerGenerated]
	private DarkUITextBox issuerOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_AlertLevel")]
	private DarkUIComboBox m_ClientOrder;

	[AccessedThroughProperty("DEBUGINTERMITTENT1")]
	[CompilerGenerated]
	private DarkLabel m_DicOrder;

	[AccessedThroughProperty("DefoncLabel2")]
	[CompilerGenerated]
	private DarkLabel m_FacadeOrder;

	[AccessedThroughProperty("CB_IncludesID_Unknown")]
	[CompilerGenerated]
	private CheckBox readerOrder;

	[AccessedThroughProperty("CB_IncludesStance_Unknown")]
	[CompilerGenerated]
	private CheckBox m_PropertyOrder;

	[AccessedThroughProperty("CB_IncludesStance_Hostile")]
	[CompilerGenerated]
	private CheckBox _ImporterOrder;

	[AccessedThroughProperty("CB_IncludesStance_Unfriendly")]
	[CompilerGenerated]
	private CheckBox _RepositoryOrder;

	[AccessedThroughProperty("CB_IncludesStance_Neutral")]
	[CompilerGenerated]
	private CheckBox m_BridgeOrder;

	[AccessedThroughProperty("CB_IncludesStance_Friendly")]
	[CompilerGenerated]
	private CheckBox _InvocationOrder;

	[AccessedThroughProperty("CB_EmconFollowsWRARules")]
	[CompilerGenerated]
	private DarkUICheckBox classOrder;

	[AccessedThroughProperty("CB_IncludesID_KnownDomain")]
	[CompilerGenerated]
	private CheckBox valueOrder;

	[AccessedThroughProperty("CB_IncludesID_KnownID")]
	[CompilerGenerated]
	private CheckBox _TokenizerOrder;

	[AccessedThroughProperty("CB_IncludesID_KnowType")]
	[CompilerGenerated]
	private CheckBox m_StubOrder;

	[AccessedThroughProperty("CB_IncludesID_KnownClass")]
	[CompilerGenerated]
	private CheckBox _WriterOrder;

	[AccessedThroughProperty("Includes")]
	[CompilerGenerated]
	private DarkGroupBox specificationOrder;

	[AccessedThroughProperty("CB_IntermittentEmission_USECUSTOM")]
	[CompilerGenerated]
	private DarkUICheckBox m_WatcherOrder;

	[AccessedThroughProperty("Custom")]
	[CompilerGenerated]
	private TabPage reponseOrder;

	[AccessedThroughProperty("DarkLabel7")]
	[CompilerGenerated]
	private DarkLabel descriptorOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel6")]
	private DarkLabel m_PoolOrder;

	[AccessedThroughProperty("CBIntermittentEmission_InheritFromGroup")]
	[CompilerGenerated]
	private DarkUICheckBox taskOrder;

	[AccessedThroughProperty("DarkUICheckBox1")]
	[CompilerGenerated]
	private DarkUICheckBox m_FilterOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("BingoThresholdCombo")]
	private DarkUIComboBox _TestsOrder;

	[AccessedThroughProperty("CB_BongoThreshold_PlayerEditable")]
	[CompilerGenerated]
	private DarkCheckBox interpreterOrder;

	[AccessedThroughProperty("DarkLabel8")]
	[CompilerGenerated]
	private DarkLabel containerOrder;

	[AccessedThroughProperty("DarkLabel9")]
	[CompilerGenerated]
	private DarkLabel composerOrder;

	[AccessedThroughProperty("SaveTemplate")]
	[CompilerGenerated]
	private DarkUIButton m_AdvisorOrder;

	[AccessedThroughProperty("LoadTemplate")]
	[CompilerGenerated]
	private DarkUIButton customerOrder;

	[AccessedThroughProperty("lblUseMissileWaypoints")]
	[CompilerGenerated]
	private DarkLabel m_SerializerOrder;

	[AccessedThroughProperty("Combo_UseWPMissilesOnASuW")]
	[CompilerGenerated]
	private DarkUIComboBox _RefOrder;

	[AccessedThroughProperty("CB_UseWPMissilesOnASuW")]
	[CompilerGenerated]
	private DarkCheckBox _ErrorOrder;

	[AccessedThroughProperty("DarkLabel13")]
	[CompilerGenerated]
	private DarkLabel connectionOrder;

	[AccessedThroughProperty("DarkLabel12")]
	[CompilerGenerated]
	private DarkLabel contextOrder;

	[AccessedThroughProperty("Btn_PTLDelete")]
	[CompilerGenerated]
	private DarkUIButton m_StrategyOrder;

	[AccessedThroughProperty("Btn_PTLAdd")]
	[CompilerGenerated]
	private DarkUIButton m_ConfigurationOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_PTLMoveDown")]
	private DarkUIButton tokenOrder;

	[AccessedThroughProperty("Btn_PTLMoveUp")]
	[CompilerGenerated]
	private DarkUIButton _IndexerOrder;

	[AccessedThroughProperty("List_TargetPriority")]
	[CompilerGenerated]
	private DarkListView m_ResolverOrder;

	[AccessedThroughProperty("Btn_PTLRemove")]
	[CompilerGenerated]
	private DarkUIButton m_PublisherOrder;

	[AccessedThroughProperty("Btn_PTLCreate")]
	[CompilerGenerated]
	private DarkUIButton serverOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel15")]
	private DarkLabel m_SchemaOrder;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel16")]
	private DarkLabel m_PredicateOrder;

	private ScenarioObject singletonOrder;

	public List<ActiveUnit> _SelectedUnits;

	public bool UnitIsOperating;

	private Doctrine recordOrder;

	private Dictionary<int, Doctrine.WRA_Weapon> m_ExceptionOrder;

	private List<int> attrOrder;

	private int m_VisitorOrder;

	private int _ExporterOrder;

	private int _PrototypeOrder;

	private int comparatorOrder;

	private int _ItemOrder;

	private int m_SetterOrder;

	private int _CreatorOrder;

	private int m_TemplateOrder;

	private int m_MappingOrder;

	private int _MockOrder;

	private int _TagOrder;

	private int _FieldOrder;

	private int m_QueueOrder;

	private int m_RegOrder;

	private int paramOrder;

	private int m_PageOrder;

	private int _RulesOrder;

	private int _MethodOrder;

	private int m_ServiceOrder;

	private int m_SystemOrder;

	private int candidateOrder;

	private int baseOrder;

	private int policyOrder;

	private int _BroadcasterOrder;

	private int identifierOrder;

	private int m_PrinterOrder;

	private int parserOrder;

	private int m_AlgoOrder;

	private int m_DatabaseOrder;

	private int _InterceptorOrder;

	private int messageOrder;

	private int _ProductOrder;

	private int annotationOrder;

	private int m_IteratorOrder;

	private int initializerOrder;

	private int roleOrder;

	private int factoryOrder;

	private int _AttributeOrder;

	private int m_EventOrder;

	private int m_GlobalOrder;

	private int m_WorkerOrder;

	private int m_AccountOrder;

	private int stateOrder;

	private int authenticationOrder;

	private Doctrine._UseNukesAllowed? m_ParamsOrder;

	private Doctrine._WCS? _InfoOrder;

	private Doctrine._WCS? _HelperOrder;

	private Doctrine._WCS? m_MapperOrder;

	private Doctrine._WCS? m_ManagerOrder;

	private Doctrine._UseIgnorePlottedCourse? m_GetterOrder;

	private Doctrine._WeaponStateRTB? _ProducerOrder;

	private Doctrine._FuelStateRTB? procOrder;

	private Doctrine._JettisonOrdnance? m_StructSpecification;

	private Doctrine._BVRLogicEnum? _MerchantSpecification;

	private Doctrine._BehaviorTowardsTargetAmbiguity? m_CallbackSpecification;

	private Doctrine._UseAutoEvade? m_DecoratorSpecification;

	private Doctrine._UseMaintainStandoff? m_ProcessSpecification;

	private Doctrine._UseUnderwayRefuelAndReplenishment? threadSpecification;

	private Doctrine._UnderwayRefuelAndReplenishmentSelection? _RuleSpecification;

	private Doctrine._UseShootTourists? m_CollectionSpecification;

	private Doctrine._UseSAMsAgainstShips? _InstanceSpecification;

	private Doctrine._UseWpMissileAgainstShips? objectSpecification;

	private Doctrine._UseIgnoreEMCONunderAttack? _ParameterSpecification;

	private Doctrine._QuickTurnAroundForAicraft? expressionSpecification;

	private Doctrine._AirOpsTempo? _DispatcherSpecification;

	private Doctrine._FuelState? m_ListenerSpecification;

	private Doctrine._WeaponState? _ConfigSpecification;

	private Doctrine._UseKinematicRangeForTorpedoes? _RegistrySpecification;

	private Doctrine.EMCONSettings._EMCONSetting definitionSpecification;

	private Doctrine.EMCONSettings._EMCONSetting _ValSpecification;

	private Doctrine.EMCONSettings._EMCONSetting wrapperSpecification;

	private Doctrine._GunStrafeGroundTargets? observerSpecification;

	private Doctrine._RefuelAlliedUnits? issuerSpecification;

	private Doctrine._BingoThreshold_E? clientSpecification;

	private Doctrine._AvoidContactWhenPossible? m_DicSpecification;

	private Doctrine._DiveOnContact? m_ConsumerSpecification;

	private Doctrine._RechargeBatteryPercentage? facadeSpecification;

	private Doctrine._RechargeBatteryPercentage? _ProxySpecification;

	private Doctrine._UseAIP? m_ReaderSpecification;

	private Doctrine._UseDippingSonar? propertySpecification;

	private Doctrine._NavigationMethod? _ImporterSpecification;

	private Doctrine._NavigationMethod? repositorySpecification;

	private Doctrine._NavigationMethod? m_BridgeSpecification;

	private Doctrine._DamageThreshold? m_InvocationSpecification;

	private Doctrine._FuelQuantityThreshold? _ClassSpecification;

	private Doctrine._WeaponQuantityThreshold? m_RequestSpecification;

	private Doctrine._WeaponQuantityThreshold? m_ValueSpecification;

	private Doctrine._DamageThreshold? _TokenizerSpecification;

	private Doctrine._FuelQuantityThreshold? _StubSpecification;

	private Doctrine._WeaponQuantityThreshold? writerSpecification;

	private Doctrine._WeaponQuantityThreshold? m_SpecificationSpecification;

	private bool watcherSpecification;

	public bool isAirOps;

	public bool isBoatOps;

	public bool isMissionEdit;

	public bool isEscorts;

	public Alertlevels? IntermittentEmissionSelectedAlertLevel;

	private ActiveEmissionInterval_Config m_ReponseSpecification;

	[AccessedThroughProperty("FD_ImportTemplate")]
	[CompilerGenerated]
	private OpenFileDialog m_DescriptorSpecification;

	[AccessedThroughProperty("FD_ExportTemplate")]
	[CompilerGenerated]
	private SaveFileDialog m_PoolSpecification;

	public int[] IntervalComboboxReference;

	private Keys[] m_TaskSpecification;

	private bool m_FilterSpecification;

	private bool _TestsSpecification;

	internal DarkUITabControl TabControl1A
	{
		[CompilerGenerated]
		get
		{
			return printerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintSingleton;
			DarkUITabControl darkUITabControl = printerStub;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged -= value2;
			}
			printerStub = value;
			darkUITabControl = printerStub;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return algoStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoStub = value;
		}
	}

	internal DarkUIComboBox CB_EMCON_Radar
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeRecord;
			DarkUIComboBox databaseStub = m_DatabaseStub;
			if (databaseStub != null)
			{
				databaseStub.SelectionChangeCommitted -= value2;
			}
			m_DatabaseStub = value;
			databaseStub = m_DatabaseStub;
			if (databaseStub != null)
			{
				databaseStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return interceptorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorStub = value;
		}
	}

	internal DarkCheckBox CB_EMCON_Inherits
	{
		[CompilerGenerated]
		get
		{
			return m_MessageStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupRecord;
			DarkCheckBox messageStub = m_MessageStub;
			if (messageStub != null)
			{
				messageStub.Click -= value2;
			}
			m_MessageStub = value;
			messageStub = m_MessageStub;
			if (messageStub != null)
			{
				messageStub.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_EMCON_OECM
	{
		[CompilerGenerated]
		get
		{
			return m_ProductStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeRecord;
			DarkUIComboBox productStub = m_ProductStub;
			if (productStub != null)
			{
				productStub.SelectionChangeCommitted -= value2;
			}
			m_ProductStub = value;
			productStub = m_ProductStub;
			if (productStub != null)
			{
				productStub.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal DarkLabel Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_EMCON_Sonar
	{
		[CompilerGenerated]
		get
		{
			return iteratorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchRecord;
			DarkUIComboBox darkUIComboBox = iteratorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			iteratorStub = value;
			darkUIComboBox = iteratorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerStub = value;
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return roleStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleStub = value;
		}
	}

	private DarkTreeGridView TGV_WRA
	{
		[CompilerGenerated]
		get
		{
			return factoryStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = OrderRecord;
			DataGridViewCellEventHandler value3 = RegisterRecord;
			EventHandler value4 = ManageRecord;
			ExpandingEventHandler value5 = CustomizeException;
			CollapsingEventHandler value6 = CloneException;
			DataGridViewDataErrorEventHandler value7 = InvokeException;
			DarkTreeGridView darkTreeGridView = factoryStub;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.CellClick -= value2;
				darkTreeGridView.CellValueChanged -= value3;
				darkTreeGridView.CurrentCellDirtyStateChanged -= value4;
				darkTreeGridView.NodeExpanding -= value5;
				darkTreeGridView.NodeCollapsing -= value6;
				darkTreeGridView.DataError -= value7;
			}
			factoryStub = value;
			darkTreeGridView = factoryStub;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.CellClick += value2;
				darkTreeGridView.CellValueChanged += value3;
				darkTreeGridView.CurrentCellDirtyStateChanged += value4;
				darkTreeGridView.NodeExpanding += value5;
				darkTreeGridView.NodeCollapsing += value6;
				darkTreeGridView.DataError += value7;
			}
		}
	}

	internal DarkUIButton Button_ResetCurrent_WRA
	{
		[CompilerGenerated]
		get
		{
			return attributeStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectException;
			DarkUIButton darkUIButton = attributeStub;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			attributeStub = value;
			darkUIButton = attributeStub;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return eventStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eventStub = value;
		}
	}

	internal DarkLabel Label16
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalStub = value;
		}
	}

	internal DarkLabel Label15
	{
		[CompilerGenerated]
		get
		{
			return workerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			workerStub = value;
		}
	}

	internal DarkLabel Label14
	{
		[CompilerGenerated]
		get
		{
			return accountStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountStub = value;
		}
	}

	[field: AccessedThroughProperty("Label11")]
	internal DarkLabel Label11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return authenticationStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			authenticationStub = value;
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label12
	{
		[CompilerGenerated]
		get
		{
			return m_InfoStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoStub = value;
		}
	}

	internal DarkCheckBox CB_WeaponStateRTB_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_HelperStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeRecord;
			DarkCheckBox helperStub = m_HelperStub;
			if (helperStub != null)
			{
				helperStub.Click -= value2;
			}
			m_HelperStub = value;
			helperStub = m_HelperStub;
			if (helperStub != null)
			{
				helperStub.Click += value2;
			}
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return mapperStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperStub = value;
		}
	}

	internal DarkCheckBox CB_WeaponControlStatus_Air_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return managerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetSingleton;
			DarkCheckBox darkCheckBox = managerStub;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			managerStub = value;
			darkCheckBox = managerStub;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_UseNukes_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _GetterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishSingleton;
			DarkCheckBox getterStub = _GetterStub;
			if (getterStub != null)
			{
				getterStub.Click -= value2;
			}
			_GetterStub = value;
			getterStub = _GetterStub;
			if (getterStub != null)
			{
				getterStub.Click += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProducerStub = value;
		}
	}

	internal DarkUIComboBox Combo_WeaponStateRTB
	{
		[CompilerGenerated]
		get
		{
			return _ProcStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableRecord;
			EventHandler value3 = ChangeRecord;
			DarkUIComboBox procStub = _ProcStub;
			if (procStub != null)
			{
				procStub.Enter -= value2;
				procStub.SelectionChangeCommitted -= value3;
			}
			_ProcStub = value;
			procStub = _ProcStub;
			if (procStub != null)
			{
				procStub.Enter += value2;
				procStub.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Air
	{
		[CompilerGenerated]
		get
		{
			return _StructWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectRecord;
			EventHandler value3 = ValidateRecord;
			DarkUIComboBox structWriter = _StructWriter;
			if (structWriter != null)
			{
				structWriter.Enter -= value2;
				structWriter.SelectionChangeCommitted -= value3;
			}
			_StructWriter = value;
			structWriter = _StructWriter;
			if (structWriter != null)
			{
				structWriter.Enter += value2;
				structWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_UseNukes
	{
		[CompilerGenerated]
		get
		{
			return merchantWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterSingleton;
			EventHandler value3 = ComputeRecord;
			DarkUIComboBox darkUIComboBox = merchantWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			merchantWriter = value;
			darkUIComboBox = merchantWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return callbackWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackWriter = value;
		}
	}

	internal DarkUIComboBox Combo_BehaviorTowardsAmbigousTarget
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetRecord;
			EventHandler value3 = FillRecord;
			DarkUIComboBox decoratorWriter = m_DecoratorWriter;
			if (decoratorWriter != null)
			{
				decoratorWriter.Enter -= value2;
				decoratorWriter.SelectionChangeCommitted -= value3;
			}
			m_DecoratorWriter = value;
			decoratorWriter = m_DecoratorWriter;
			if (decoratorWriter != null)
			{
				decoratorWriter.Enter += value2;
				decoratorWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_BehaviorTowardsAmbigousTarget_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ProcessWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateRecord;
			DarkCheckBox processWriter = _ProcessWriter;
			if (processWriter != null)
			{
				processWriter.Click -= value2;
			}
			_ProcessWriter = value;
			processWriter = _ProcessWriter;
			if (processWriter != null)
			{
				processWriter.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_AutoEvade
	{
		[CompilerGenerated]
		get
		{
			return _RuleWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopRecord;
			EventHandler value3 = InstantiateRecord;
			DarkUIComboBox ruleWriter = _RuleWriter;
			if (ruleWriter != null)
			{
				ruleWriter.Enter -= value2;
				ruleWriter.SelectionChangeCommitted -= value3;
			}
			_RuleWriter = value;
			ruleWriter = _RuleWriter;
			if (ruleWriter != null)
			{
				ruleWriter.Enter += value2;
				ruleWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_AutoEvade_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return collectionWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateRecord;
			DarkCheckBox darkCheckBox = collectionWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			collectionWriter = value;
			darkCheckBox = collectionWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Standoff
	{
		[CompilerGenerated]
		get
		{
			return instanceWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadRecord;
			EventHandler value3 = InsertException;
			DarkUIComboBox darkUIComboBox = instanceWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
			}
			instanceWriter = value;
			darkUIComboBox = instanceWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
			}
		}
	}

	internal DarkCheckBox CB_Standoff_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return objectWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareRecord;
			DarkCheckBox darkCheckBox = objectWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			objectWriter = value;
			darkCheckBox = objectWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_UseRefuel
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertRecord;
			EventHandler value3 = PrepareRecord;
			DarkUIComboBox parameterWriter = m_ParameterWriter;
			if (parameterWriter != null)
			{
				parameterWriter.Enter -= value2;
				parameterWriter.SelectionChangeCommitted -= value3;
			}
			m_ParameterWriter = value;
			parameterWriter = m_ParameterWriter;
			if (parameterWriter != null)
			{
				parameterWriter.Enter += value2;
				parameterWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_UseRefuel_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushSingleton;
			DarkCheckBox expressionWriter = m_ExpressionWriter;
			if (expressionWriter != null)
			{
				expressionWriter.Click -= value2;
			}
			m_ExpressionWriter = value;
			expressionWriter = m_ExpressionWriter;
			if (expressionWriter != null)
			{
				expressionWriter.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_ShootTourists
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableRecord;
			EventHandler value3 = UpdateRecord;
			DarkUIComboBox dispatcherWriter = m_DispatcherWriter;
			if (dispatcherWriter != null)
			{
				dispatcherWriter.Enter -= value2;
				dispatcherWriter.SelectionChangeCommitted -= value3;
			}
			m_DispatcherWriter = value;
			dispatcherWriter = m_DispatcherWriter;
			if (dispatcherWriter != null)
			{
				dispatcherWriter.Enter += value2;
				dispatcherWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_ShootTourists_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ListenerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostRecord;
			DarkCheckBox listenerWriter = _ListenerWriter;
			if (listenerWriter != null)
			{
				listenerWriter.Click -= value2;
			}
			_ListenerWriter = value;
			listenerWriter = _ListenerWriter;
			if (listenerWriter != null)
			{
				listenerWriter.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_UseSAMsOnASuW
	{
		[CompilerGenerated]
		get
		{
			return configWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunRecord;
			EventHandler value3 = StartRecord;
			EventHandler value4 = AssetRecord;
			DarkUIComboBox darkUIComboBox = configWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Click -= value2;
				darkUIComboBox.Enter -= value3;
				darkUIComboBox.SelectionChangeCommitted -= value4;
			}
			configWriter = value;
			darkUIComboBox = configWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Click += value2;
				darkUIComboBox.Enter += value3;
				darkUIComboBox.SelectionChangeCommitted += value4;
			}
		}
	}

	internal DarkCheckBox CB_UseSAMsOnASuW_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectSingleton;
			EventHandler value3 = CollectSingleton;
			DarkCheckBox registryWriter = m_RegistryWriter;
			if (registryWriter != null)
			{
				registryWriter.CheckedChanged -= value2;
				registryWriter.Click -= value3;
			}
			m_RegistryWriter = value;
			registryWriter = m_RegistryWriter;
			if (registryWriter != null)
			{
				registryWriter.CheckedChanged += value2;
				registryWriter.Click += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_IgnoreEMCONunderAttack
	{
		[CompilerGenerated]
		get
		{
			return definitionWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeRecord;
			EventHandler value3 = QueryRecord;
			EventHandler value4 = ResetRecord;
			DarkUIComboBox darkUIComboBox = definitionWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Click -= value2;
				darkUIComboBox.Enter -= value3;
				darkUIComboBox.SelectionChangeCommitted -= value4;
			}
			definitionWriter = value;
			darkUIComboBox = definitionWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Click += value2;
				darkUIComboBox.Enter += value3;
				darkUIComboBox.SelectionChangeCommitted += value4;
			}
		}
	}

	internal DarkCheckBox CB_IgnoreEMCONunderAttack_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ValWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateSingleton;
			DarkCheckBox valWriter = _ValWriter;
			if (valWriter != null)
			{
				valWriter.Click -= value2;
			}
			_ValWriter = value;
			valWriter = _ValWriter;
			if (valWriter != null)
			{
				valWriter.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label17")]
	internal DarkLabel Label17
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_QuickTurnAroundForAicraft
	{
		[CompilerGenerated]
		get
		{
			return _ObserverWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageSingleton;
			EventHandler value3 = PatchRecord;
			DarkUIComboBox observerWriter = _ObserverWriter;
			if (observerWriter != null)
			{
				observerWriter.Enter -= value2;
				observerWriter.SelectionChangeCommitted -= value3;
			}
			_ObserverWriter = value;
			observerWriter = _ObserverWriter;
			if (observerWriter != null)
			{
				observerWriter.Enter += value2;
				observerWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_UseKinematicRangeForTorpedoes
	{
		[CompilerGenerated]
		get
		{
			return _IssuerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneRecord;
			EventHandler value3 = ViewRecord;
			DarkUIComboBox issuerWriter = _IssuerWriter;
			if (issuerWriter != null)
			{
				issuerWriter.Enter -= value2;
				issuerWriter.SelectionChangeCommitted -= value3;
			}
			_IssuerWriter = value;
			issuerWriter = _IssuerWriter;
			if (issuerWriter != null)
			{
				issuerWriter.Enter += value2;
				issuerWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_QuickTurnAroundForAicraft_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_ClientWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortRecord;
			DarkCheckBox clientWriter = m_ClientWriter;
			if (clientWriter != null)
			{
				clientWriter.Click -= value2;
			}
			m_ClientWriter = value;
			clientWriter = m_ClientWriter;
			if (clientWriter != null)
			{
				clientWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_UseKinematicRangeForTorpedoes_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return dicWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectRecord;
			DarkCheckBox darkCheckBox = dicWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			dicWriter = value;
			darkCheckBox = dicWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkLabel Label18
	{
		[CompilerGenerated]
		get
		{
			return consumerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			consumerWriter = value;
		}
	}

	internal DarkUIComboBox Combo_AirOpsTempo
	{
		[CompilerGenerated]
		get
		{
			return _FacadeWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertSingleton;
			EventHandler value3 = SelectRecord;
			DarkUIComboBox facadeWriter = _FacadeWriter;
			if (facadeWriter != null)
			{
				facadeWriter.Enter -= value2;
				facadeWriter.SelectionChangeCommitted -= value3;
			}
			_FacadeWriter = value;
			facadeWriter = _FacadeWriter;
			if (facadeWriter != null)
			{
				facadeWriter.Enter += value2;
				facadeWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_AirOpsTempo_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ProxyWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapRecord;
			DarkCheckBox proxyWriter = _ProxyWriter;
			if (proxyWriter != null)
			{
				proxyWriter.Click -= value2;
			}
			_ProxyWriter = value;
			proxyWriter = _ProxyWriter;
			if (proxyWriter != null)
			{
				proxyWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label19
	{
		[CompilerGenerated]
		get
		{
			return readerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			readerWriter = value;
		}
	}

	[field: AccessedThroughProperty("Label20")]
	internal DarkLabel Label20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label21")]
	internal DarkLabel Label21
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label22
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RepositoryWriter = value;
		}
	}

	[field: AccessedThroughProperty("Label24")]
	internal DarkLabel Label24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label25")]
	internal DarkLabel Label25
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_ResetAffectedMissions_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _ClassWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeException;
			DarkUIButton classWriter = _ClassWriter;
			if (classWriter != null)
			{
				classWriter.Click -= value2;
			}
			_ClassWriter = value;
			classWriter = _ClassWriter;
			if (classWriter != null)
			{
				classWriter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetAffectedUnits_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return m_RequestWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyException;
			DarkUIButton requestWriter = m_RequestWriter;
			if (requestWriter != null)
			{
				requestWriter.Click -= value2;
			}
			m_RequestWriter = value;
			requestWriter = m_RequestWriter;
			if (requestWriter != null)
			{
				requestWriter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetCurrent_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return _ValueWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddException;
			DarkUIButton valueWriter = _ValueWriter;
			if (valueWriter != null)
			{
				valueWriter.Click -= value2;
			}
			_ValueWriter = value;
			valueWriter = _ValueWriter;
			if (valueWriter != null)
			{
				valueWriter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetAffectedMissions_WRA
	{
		[CompilerGenerated]
		get
		{
			return _TokenizerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteException;
			DarkUIButton tokenizerWriter = _TokenizerWriter;
			if (tokenizerWriter != null)
			{
				tokenizerWriter.Click -= value2;
			}
			_TokenizerWriter = value;
			tokenizerWriter = _TokenizerWriter;
			if (tokenizerWriter != null)
			{
				tokenizerWriter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetAffectedUnits_WRA
	{
		[CompilerGenerated]
		get
		{
			return stubWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveException;
			DarkUIButton darkUIButton = stubWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			stubWriter = value;
			darkUIButton = stubWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetAffectedMissions_EMCON
	{
		[CompilerGenerated]
		get
		{
			return writerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallException;
			DarkUIButton darkUIButton = writerWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			writerWriter = value;
			darkUIButton = writerWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetAffectedUnits_EMCON
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectException;
			DarkUIButton specificationWriter = _SpecificationWriter;
			if (specificationWriter != null)
			{
				specificationWriter.Click -= value2;
			}
			_SpecificationWriter = value;
			specificationWriter = _SpecificationWriter;
			if (specificationWriter != null)
			{
				specificationWriter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetCurrent_EMCON
	{
		[CompilerGenerated]
		get
		{
			return watcherWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchException;
			DarkUIButton darkUIButton = watcherWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			watcherWriter = value;
			darkUIButton = watcherWriter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_IgnorePlottedCourse
	{
		[CompilerGenerated]
		get
		{
			return descriptorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QuerySingleton;
			EventHandler value3 = PushRecord;
			DarkUIComboBox darkUIComboBox = descriptorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			descriptorWriter = value;
			darkUIComboBox = descriptorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkCheckBox CB_IgnorePlottedCourse_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _PoolWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeSingleton;
			DarkCheckBox poolWriter = _PoolWriter;
			if (poolWriter != null)
			{
				poolWriter.Click -= value2;
			}
			_PoolWriter = value;
			poolWriter = _PoolWriter;
			if (poolWriter != null)
			{
				poolWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_TaskWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskWriter = value;
		}
	}

	internal DarkLabel Label23
	{
		[CompilerGenerated]
		get
		{
			return m_FilterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterWriter = value;
		}
	}

	internal DarkLabel Label26
	{
		[CompilerGenerated]
		get
		{
			return m_TestsWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsWriter = value;
		}
	}

	internal DarkCheckBox CB_WeaponControlStatus_Surface_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapSingleton;
			DarkCheckBox interpreterWriter = m_InterpreterWriter;
			if (interpreterWriter != null)
			{
				interpreterWriter.Click -= value2;
			}
			m_InterpreterWriter = value;
			interpreterWriter = m_InterpreterWriter;
			if (interpreterWriter != null)
			{
				interpreterWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_WeaponControlStatus_Submarine_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortSingleton;
			DarkCheckBox containerWriter = m_ContainerWriter;
			if (containerWriter != null)
			{
				containerWriter.Click -= value2;
			}
			m_ContainerWriter = value;
			containerWriter = m_ContainerWriter;
			if (containerWriter != null)
			{
				containerWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_WeaponControlStatus_Land_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcSingleton;
			DarkCheckBox composerWriter = m_ComposerWriter;
			if (composerWriter != null)
			{
				composerWriter.Click -= value2;
			}
			m_ComposerWriter = value;
			composerWriter = m_ComposerWriter;
			if (composerWriter != null)
			{
				composerWriter.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Surface
	{
		[CompilerGenerated]
		get
		{
			return modelWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveRecord;
			EventHandler value3 = LoginRecord;
			DarkUIComboBox darkUIComboBox = modelWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			modelWriter = value;
			darkUIComboBox = modelWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Submarine
	{
		[CompilerGenerated]
		get
		{
			return advisorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteRecord;
			EventHandler value3 = GetRecord;
			DarkUIComboBox darkUIComboBox = advisorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			advisorWriter = value;
			darkUIComboBox = advisorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Land
	{
		[CompilerGenerated]
		get
		{
			return _CustomerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddRecord;
			EventHandler value3 = WriteRecord;
			DarkUIComboBox customerWriter = _CustomerWriter;
			if (customerWriter != null)
			{
				customerWriter.Enter -= value2;
				customerWriter.SelectionChangeCommitted -= value3;
			}
			_CustomerWriter = value;
			customerWriter = _CustomerWriter;
			if (customerWriter != null)
			{
				customerWriter.Enter += value2;
				customerWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel Label27
	{
		[CompilerGenerated]
		get
		{
			return serializerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerWriter = value;
		}
	}

	internal DarkCheckBox CB_GunStrafing_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return refWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderSingleton;
			DarkCheckBox darkCheckBox = refWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			refWriter = value;
			darkCheckBox = refWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_GunStrafing
	{
		[CompilerGenerated]
		get
		{
			return errorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyRecord;
			EventHandler value3 = NewRecord;
			DarkUIComboBox darkUIComboBox = errorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			errorWriter = value;
			darkUIComboBox = errorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_WithdrawDefenceThreshold
	{
		[CompilerGenerated]
		get
		{
			return connectionWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishException;
			EventHandler value3 = AwakeException;
			DarkUIComboBox darkUIComboBox = connectionWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			connectionWriter = value;
			darkUIComboBox = connectionWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WithdrawAttackThreshold
	{
		[CompilerGenerated]
		get
		{
			return _ContextWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartException;
			EventHandler value3 = AssetException;
			DarkUIComboBox contextWriter = _ContextWriter;
			if (contextWriter != null)
			{
				contextWriter.Enter -= value2;
				contextWriter.SelectionChangeCommitted -= value3;
			}
			_ContextWriter = value;
			contextWriter = _ContextWriter;
			if (contextWriter != null)
			{
				contextWriter.Enter += value2;
				contextWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WithdrawFuelThreshold
	{
		[CompilerGenerated]
		get
		{
			return statusWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListException;
			EventHandler value3 = ResolveException;
			DarkUIComboBox darkUIComboBox = statusWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			statusWriter = value;
			darkUIComboBox = statusWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel Label45
	{
		[CompilerGenerated]
		get
		{
			return proccesorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorWriter = value;
		}
	}

	internal DarkLabel Label43
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StrategyWriter = value;
		}
	}

	internal DarkLabel Label44
	{
		[CompilerGenerated]
		get
		{
			return configurationWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationWriter = value;
		}
	}

	internal DarkLabel Label42
	{
		[CompilerGenerated]
		get
		{
			return tokenWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenWriter = value;
		}
	}

	internal DarkUIComboBox Combo_WithdrawDamageThreshold
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestException;
			EventHandler value3 = CancelException;
			DarkUIComboBox indexerWriter = m_IndexerWriter;
			if (indexerWriter != null)
			{
				indexerWriter.Enter -= value2;
				indexerWriter.SelectionChangeCommitted -= value3;
			}
			m_IndexerWriter = value;
			indexerWriter = m_IndexerWriter;
			if (indexerWriter != null)
			{
				indexerWriter.Enter += value2;
				indexerWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label41")]
	internal DarkLabel Label41
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_RedeployDefenceThreshold
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryException;
			EventHandler value3 = ResetException;
			DarkUIComboBox publisherWriter = m_PublisherWriter;
			if (publisherWriter != null)
			{
				publisherWriter.Enter -= value2;
				publisherWriter.SelectionChangeCommitted -= value3;
			}
			m_PublisherWriter = value;
			publisherWriter = m_PublisherWriter;
			if (publisherWriter != null)
			{
				publisherWriter.Enter += value2;
				publisherWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_RedeployAttackThreshold
	{
		[CompilerGenerated]
		get
		{
			return serverWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintException;
			EventHandler value3 = DefineException;
			DarkUIComboBox darkUIComboBox = serverWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			serverWriter = value;
			darkUIComboBox = serverWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_RedeployFuelThreshold
	{
		[CompilerGenerated]
		get
		{
			return _AdapterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostException;
			EventHandler value3 = RunException;
			DarkUIComboBox adapterWriter = _AdapterWriter;
			if (adapterWriter != null)
			{
				adapterWriter.Enter -= value2;
				adapterWriter.SelectionChangeCommitted -= value3;
			}
			_AdapterWriter = value;
			adapterWriter = _AdapterWriter;
			if (adapterWriter != null)
			{
				adapterWriter.Enter += value2;
				adapterWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label46")]
	internal DarkLabel Label46
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label47
	{
		[CompilerGenerated]
		get
		{
			return utilsWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsWriter = value;
		}
	}

	internal DarkLabel Label48
	{
		[CompilerGenerated]
		get
		{
			return predicateWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicateWriter = value;
		}
	}

	[field: AccessedThroughProperty("Label49")]
	internal DarkLabel Label49
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_RedeployDamageThreshold
	{
		[CompilerGenerated]
		get
		{
			return _RecordWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopException;
			EventHandler value3 = VerifyException;
			DarkUIComboBox recordWriter = _RecordWriter;
			if (recordWriter != null)
			{
				recordWriter.Enter -= value2;
				recordWriter.SelectionChangeCommitted -= value3;
			}
			_RecordWriter = value;
			recordWriter = _RecordWriter;
			if (recordWriter != null)
			{
				recordWriter.Enter += value2;
				recordWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label50")]
	internal DarkLabel Label50
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TreeGridColumn TargetType
	{
		[CompilerGenerated]
		get
		{
			return m_AttrWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrWriter = value;
		}
	}

	internal DataGridViewComboBoxColumn WeaponsPerSalvo
	{
		[CompilerGenerated]
		get
		{
			return visitorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorWriter = value;
		}
	}

	internal DataGridViewComboBoxColumn ShootersPerSalvo
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterWriter = value;
		}
	}

	[field: AccessedThroughProperty("FiringRange")]
	internal DataGridViewComboBoxColumn FiringRange
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewComboBoxColumn SelfDefenceRange
	{
		[CompilerGenerated]
		get
		{
			return comparatorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			comparatorWriter = value;
		}
	}

	internal DarkLabel Label51
	{
		[CompilerGenerated]
		get
		{
			return itemWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemWriter = value;
		}
	}

	internal DarkCheckBox CB_ReplenishmentSelection_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return setterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotSingleton;
			DarkCheckBox darkCheckBox = setterWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			setterWriter = value;
			darkCheckBox = setterWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_ReplenishmentSelection
	{
		[CompilerGenerated]
		get
		{
			return _CreatorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectRecord;
			EventHandler value3 = VisitRecord;
			DarkUIComboBox creatorWriter = _CreatorWriter;
			if (creatorWriter != null)
			{
				creatorWriter.Enter -= value2;
				creatorWriter.SelectionChangeCommitted -= value3;
			}
			_CreatorWriter = value;
			creatorWriter = _CreatorWriter;
			if (creatorWriter != null)
			{
				creatorWriter.Enter += value2;
				creatorWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel Label28
	{
		[CompilerGenerated]
		get
		{
			return templateWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templateWriter = value;
		}
	}

	internal DarkLabel Label29
	{
		[CompilerGenerated]
		get
		{
			return m_MappingWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingWriter = value;
		}
	}

	internal DarkLabel Label30
	{
		[CompilerGenerated]
		get
		{
			return mockWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mockWriter = value;
		}
	}

	internal DarkCheckBox CB_FuelState_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _TagWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateRecord;
			DarkCheckBox tagWriter = _TagWriter;
			if (tagWriter != null)
			{
				tagWriter.Click -= value2;
			}
			_TagWriter = value;
			tagWriter = _TagWriter;
			if (tagWriter != null)
			{
				tagWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_WeaponState_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _FieldWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcRecord;
			DarkCheckBox fieldWriter = _FieldWriter;
			if (fieldWriter != null)
			{
				fieldWriter.Click -= value2;
			}
			_FieldWriter = value;
			fieldWriter = _FieldWriter;
			if (fieldWriter != null)
			{
				fieldWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label31
	{
		[CompilerGenerated]
		get
		{
			return m_QueueWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_QueueWriter = value;
		}
	}

	internal DarkCheckBox CB_JettisonOrdnance_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return regWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeException;
			DarkCheckBox darkCheckBox = regWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			regWriter = value;
			darkCheckBox = regWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_FuelStateRTB_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ParamWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupException;
			DarkCheckBox paramWriter = _ParamWriter;
			if (paramWriter != null)
			{
				paramWriter.Click -= value2;
			}
			_ParamWriter = value;
			paramWriter = _ParamWriter;
			if (paramWriter != null)
			{
				paramWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label32
	{
		[CompilerGenerated]
		get
		{
			return pageWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pageWriter = value;
		}
	}

	internal DarkLabel Label33
	{
		[CompilerGenerated]
		get
		{
			return rulesWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesWriter = value;
		}
	}

	internal DarkLabel Label34
	{
		[CompilerGenerated]
		get
		{
			return methodWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodWriter = value;
		}
	}

	internal DarkCheckBox CB_RefuelAllies_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return serviceWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeException;
			DarkCheckBox darkCheckBox = serviceWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			serviceWriter = value;
			darkCheckBox = serviceWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label35")]
	internal DarkLabel Label35
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label36")]
	internal DarkLabel Label36
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_AvoidContact_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return baseWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchException;
			DarkCheckBox darkCheckBox = baseWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			baseWriter = value;
			darkCheckBox = baseWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DiveWhenThreatsDetected_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _PolicyWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableException;
			DarkCheckBox policyWriter = _PolicyWriter;
			if (policyWriter != null)
			{
				policyWriter.Click -= value2;
			}
			_PolicyWriter = value;
			policyWriter = _PolicyWriter;
			if (policyWriter != null)
			{
				policyWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label37
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BroadcasterWriter = value;
		}
	}

	internal DarkCheckBox CB_BatteryRechargePatrol_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _IdentifierWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeException;
			DarkCheckBox identifierWriter = _IdentifierWriter;
			if (identifierWriter != null)
			{
				identifierWriter.Click -= value2;
			}
			_IdentifierWriter = value;
			identifierWriter = _IdentifierWriter;
			if (identifierWriter != null)
			{
				identifierWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label38
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrinterWriter = value;
		}
	}

	internal DarkCheckBox CB_BatteryRechargeAttack_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_ParserWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitException;
			DarkCheckBox parserWriter = m_ParserWriter;
			if (parserWriter != null)
			{
				parserWriter.Click -= value2;
			}
			m_ParserWriter = value;
			parserWriter = m_ParserWriter;
			if (parserWriter != null)
			{
				parserWriter.Click += value2;
			}
		}
	}

	internal DarkLabel Label39
	{
		[CompilerGenerated]
		get
		{
			return algoWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoWriter = value;
		}
	}

	internal DarkCheckBox CB_AIP_Usage_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return databaseWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckException;
			DarkCheckBox darkCheckBox = databaseWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			databaseWriter = value;
			darkCheckBox = databaseWriter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkLabel Label40
	{
		[CompilerGenerated]
		get
		{
			return interceptorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorWriter = value;
		}
	}

	internal DarkCheckBox CB_DippingSonar_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return m_MessageWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatException;
			DarkCheckBox messageWriter = m_MessageWriter;
			if (messageWriter != null)
			{
				messageWriter.Click -= value2;
			}
			m_MessageWriter = value;
			messageWriter = m_MessageWriter;
			if (messageWriter != null)
			{
				messageWriter.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_FuelState
	{
		[CompilerGenerated]
		get
		{
			return m_ProductWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountRecord;
			EventHandler value3 = CallRecord;
			DarkUIComboBox productWriter = m_ProductWriter;
			if (productWriter != null)
			{
				productWriter.Enter -= value2;
				productWriter.SelectionChangeCommitted -= value3;
			}
			m_ProductWriter = value;
			productWriter = m_ProductWriter;
			if (productWriter != null)
			{
				productWriter.Enter += value2;
				productWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponState
	{
		[CompilerGenerated]
		get
		{
			return _AnnotationWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeRecord;
			EventHandler value3 = LogoutRecord;
			DarkUIComboBox annotationWriter = _AnnotationWriter;
			if (annotationWriter != null)
			{
				annotationWriter.Enter -= value2;
				annotationWriter.SelectionChangeCommitted -= value3;
			}
			_AnnotationWriter = value;
			annotationWriter = _AnnotationWriter;
			if (annotationWriter != null)
			{
				annotationWriter.Enter += value2;
				annotationWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_Jettison
	{
		[CompilerGenerated]
		get
		{
			return iteratorWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatRecord;
			EventHandler value3 = InterruptRecord;
			DarkUIComboBox darkUIComboBox = iteratorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			iteratorWriter = value;
			darkUIComboBox = iteratorWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_FuelStateRTB
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitRecord;
			EventHandler value3 = CheckRecord;
			DarkUIComboBox initializerWriter = m_InitializerWriter;
			if (initializerWriter != null)
			{
				initializerWriter.Enter -= value2;
				initializerWriter.SelectionChangeCommitted -= value3;
			}
			m_InitializerWriter = value;
			initializerWriter = m_InitializerWriter;
			if (initializerWriter != null)
			{
				initializerWriter.Enter += value2;
				initializerWriter.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_RefuelAllies
	{
		[CompilerGenerated]
		get
		{
			return roleWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveException;
			EventHandler value3 = CompareException;
			DarkUIComboBox darkUIComboBox = roleWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
			}
			roleWriter = value;
			darkUIComboBox = roleWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_AvoidContact
	{
		[CompilerGenerated]
		get
		{
			return _FactoryWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetException;
			EventHandler value3 = DisableException;
			DarkUIComboBox factoryWriter = _FactoryWriter;
			if (factoryWriter != null)
			{
				factoryWriter.SelectionChangeCommitted -= value2;
				factoryWriter.Enter -= value3;
			}
			_FactoryWriter = value;
			factoryWriter = _FactoryWriter;
			if (factoryWriter != null)
			{
				factoryWriter.SelectionChangeCommitted += value2;
				factoryWriter.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_DiveWhenThreatsDetected
	{
		[CompilerGenerated]
		get
		{
			return _AttributeWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillException;
			EventHandler value3 = UpdateException;
			DarkUIComboBox attributeWriter = _AttributeWriter;
			if (attributeWriter != null)
			{
				attributeWriter.SelectionChangeCommitted -= value2;
				attributeWriter.Enter -= value3;
			}
			_AttributeWriter = value;
			attributeWriter = _AttributeWriter;
			if (attributeWriter != null)
			{
				attributeWriter.SelectionChangeCommitted += value2;
				attributeWriter.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_BatteryRechargePatrol
	{
		[CompilerGenerated]
		get
		{
			return m_EventWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateException;
			EventHandler value3 = PrepareException;
			DarkUIComboBox eventWriter = m_EventWriter;
			if (eventWriter != null)
			{
				eventWriter.SelectionChangeCommitted -= value2;
				eventWriter.Enter -= value3;
			}
			m_EventWriter = value;
			eventWriter = m_EventWriter;
			if (eventWriter != null)
			{
				eventWriter.SelectionChangeCommitted += value2;
				eventWriter.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_BatteryRechargeAttack
	{
		[CompilerGenerated]
		get
		{
			return globalWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopException;
			EventHandler value3 = ReflectException;
			DarkUIComboBox darkUIComboBox = globalWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
			}
			globalWriter = value;
			darkUIComboBox = globalWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_AIP_Usage
	{
		[CompilerGenerated]
		get
		{
			return workerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateException;
			EventHandler value3 = VisitException;
			DarkUIComboBox darkUIComboBox = workerWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
			}
			workerWriter = value;
			darkUIComboBox = workerWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_DippingSonar
	{
		[CompilerGenerated]
		get
		{
			return accountWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateException;
			EventHandler value3 = RestartException;
			DarkUIComboBox darkUIComboBox = accountWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
			}
			accountWriter = value;
			darkUIComboBox = accountWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label52")]
	internal DarkLabel Label52
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_BVRLogic_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeException;
			EventHandler value3 = InterruptException;
			DarkCheckBox authenticationWriter = _AuthenticationWriter;
			if (authenticationWriter != null)
			{
				authenticationWriter.Click -= value2;
				authenticationWriter.Click -= value3;
			}
			_AuthenticationWriter = value;
			authenticationWriter = _AuthenticationWriter;
			if (authenticationWriter != null)
			{
				authenticationWriter.Click += value2;
				authenticationWriter.Click += value3;
			}
		}
	}

	internal DarkUIComboBox Combo_BVRLogic
	{
		[CompilerGenerated]
		get
		{
			return paramsWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveRecord;
			EventHandler value3 = FindRecord;
			DarkUIComboBox darkUIComboBox = paramsWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			paramsWriter = value;
			darkUIComboBox = paramsWriter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.Enter += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_InfoWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoWriter = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal DarkLabel DarkLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel4
	{
		[CompilerGenerated]
		get
		{
			return managerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerWriter = value;
		}
	}

	internal DarkCheckBox CB_Surface_Navigation_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _GetterWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartRecord;
			DarkCheckBox getterWriter = _GetterWriter;
			if (getterWriter != null)
			{
				getterWriter.Click -= value2;
			}
			_GetterWriter = value;
			getterWriter = _GetterWriter;
			if (getterWriter != null)
			{
				getterWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Submarine_Navigation_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ProducerWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopRecord;
			DarkCheckBox producerWriter = _ProducerWriter;
			if (producerWriter != null)
			{
				producerWriter.Click -= value2;
			}
			_ProducerWriter = value;
			producerWriter = _ProducerWriter;
			if (producerWriter != null)
			{
				producerWriter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Land_Navigation_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return _ProcWriter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyRecord;
			DarkCheckBox procWriter = _ProcWriter;
			if (procWriter != null)
			{
				procWriter.Click -= value2;
			}
			_ProcWriter = value;
			procWriter = _ProcWriter;
			if (procWriter != null)
			{
				procWriter.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Surface_Navigation
	{
		[CompilerGenerated]
		get
		{
			return _StructOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestRecord;
			DarkUIComboBox structOrder = _StructOrder;
			if (structOrder != null)
			{
				structOrder.SelectionChangeCommitted -= value2;
			}
			_StructOrder = value;
			structOrder = _StructOrder;
			if (structOrder != null)
			{
				structOrder.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Submarine_Navigation
	{
		[CompilerGenerated]
		get
		{
			return merchantOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelRecord;
			DarkUIComboBox darkUIComboBox = merchantOrder;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			merchantOrder = value;
			darkUIComboBox = merchantOrder;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Land_Navigation
	{
		[CompilerGenerated]
		get
		{
			return callbackOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListRecord;
			DarkUIComboBox darkUIComboBox = callbackOrder;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			callbackOrder = value;
			darkUIComboBox = callbackOrder;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkGroupBox UseIntervalGroup
	{
		[CompilerGenerated]
		get
		{
			return decoratorOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			decoratorOrder = value;
		}
	}

	internal DarkUITabControl EmissionIntervalTABControl
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapException;
			DarkUITabControl processOrder = m_ProcessOrder;
			if (processOrder != null)
			{
				processOrder.SelectedIndexChanged -= value2;
			}
			m_ProcessOrder = value;
			processOrder = m_ProcessOrder;
			if (processOrder != null)
			{
				processOrder.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GreenAlert")]
	internal TabPage GreenAlert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage BlueAlert
	{
		[CompilerGenerated]
		get
		{
			return m_RuleOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RuleOrder = value;
		}
	}

	internal DarkLabel Label_AEI_2
	{
		[CompilerGenerated]
		get
		{
			return collectionOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionOrder = value;
		}
	}

	internal DarkUITextBox IntervalVariation
	{
		[CompilerGenerated]
		get
		{
			return _InstanceOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeAttr;
			DarkUITextBox instanceOrder = _InstanceOrder;
			if (instanceOrder != null)
			{
				instanceOrder.Leave -= value2;
			}
			_InstanceOrder = value;
			instanceOrder = _InstanceOrder;
			if (instanceOrder != null)
			{
				instanceOrder.Leave += value2;
			}
		}
	}

	internal DarkUITextBox Interval
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountAttr;
			DarkUITextBox objectOrder = m_ObjectOrder;
			if (objectOrder != null)
			{
				objectOrder.Leave -= value2;
			}
			m_ObjectOrder = value;
			objectOrder = m_ObjectOrder;
			if (objectOrder != null)
			{
				objectOrder.Leave += value2;
			}
		}
	}

	internal TabPage YellowAlert
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParameterOrder = value;
		}
	}

	internal TabPage OrangeAlert
	{
		[CompilerGenerated]
		get
		{
			return expressionOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionOrder = value;
		}
	}

	[field: AccessedThroughProperty("Label_AEI_3")]
	internal DarkLabel Label_AEI_3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox BackToSleepTime
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneAttr;
			DarkUITextBox listenerOrder = m_ListenerOrder;
			if (listenerOrder != null)
			{
				listenerOrder.Leave -= value2;
			}
			m_ListenerOrder = value;
			listenerOrder = m_ListenerOrder;
			if (listenerOrder != null)
			{
				listenerOrder.Leave += value2;
			}
		}
	}

	internal DarkUICheckBox CBWakeWhenDetectingThreat
	{
		[CompilerGenerated]
		get
		{
			return _ConfigOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = MoveAttr;
			DarkUICheckBox configOrder = _ConfigOrder;
			if (configOrder != null)
			{
				configOrder.CheckedChanged -= value2;
			}
			_ConfigOrder = value;
			configOrder = _ConfigOrder;
			if (configOrder != null)
			{
				configOrder.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel Label_AEI_1
	{
		[CompilerGenerated]
		get
		{
			return registryOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			registryOrder = value;
		}
	}

	[field: AccessedThroughProperty("RedAlert")]
	internal TabPage RedAlert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton IntermittantToggle
	{
		[CompilerGenerated]
		get
		{
			return _ValOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageException;
			DarkUIButton valOrder = _ValOrder;
			if (valOrder != null)
			{
				valOrder.Click -= value2;
			}
			_ValOrder = value;
			valOrder = _ValOrder;
			if (valOrder != null)
			{
				valOrder.Click += value2;
			}
		}
	}

	internal DarkLabel Label_AEI_0
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WrapperOrder = value;
		}
	}

	[field: AccessedThroughProperty("EmissionIntervalPhonyTab")]
	internal Panel EmissionIntervalPhonyTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox EmissionDurationTextBox
	{
		[CompilerGenerated]
		get
		{
			return issuerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectAttr;
			DarkUITextBox darkUITextBox = issuerOrder;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave -= value2;
			}
			issuerOrder = value;
			darkUITextBox = issuerOrder;
			if (darkUITextBox != null)
			{
				darkUITextBox.Leave += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_AlertLevel
	{
		[CompilerGenerated]
		get
		{
			return m_ClientOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteAttr;
			DarkUIComboBox clientOrder = m_ClientOrder;
			if (clientOrder != null)
			{
				clientOrder.SelectedIndexChanged -= value2;
			}
			m_ClientOrder = value;
			clientOrder = m_ClientOrder;
			if (clientOrder != null)
			{
				clientOrder.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel_0
	{
		[CompilerGenerated]
		get
		{
			return m_DicOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DicOrder = value;
		}
	}

	[field: AccessedThroughProperty("LabelPlus")]
	internal DarkLabel LabelPlus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DefoncLabel2
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FacadeOrder = value;
		}
	}

	[field: AccessedThroughProperty("WakeGroupBox")]
	internal DarkGroupBox WakeGroupBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal CheckBox CB_IncludesID_Unknown
	{
		[CompilerGenerated]
		get
		{
			return readerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallAttr;
			CheckBox checkBox = readerOrder;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			readerOrder = value;
			checkBox = readerOrder;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesStance_Unknown
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectAttr;
			CheckBox propertyOrder = m_PropertyOrder;
			if (propertyOrder != null)
			{
				propertyOrder.CheckedChanged -= value2;
			}
			m_PropertyOrder = value;
			propertyOrder = m_PropertyOrder;
			if (propertyOrder != null)
			{
				propertyOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesStance_Hostile
	{
		[CompilerGenerated]
		get
		{
			return _ImporterOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchAttr;
			CheckBox importerOrder = _ImporterOrder;
			if (importerOrder != null)
			{
				importerOrder.CheckedChanged -= value2;
			}
			_ImporterOrder = value;
			importerOrder = _ImporterOrder;
			if (importerOrder != null)
			{
				importerOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesStance_Unfriendly
	{
		[CompilerGenerated]
		get
		{
			return _RepositoryOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeAttr;
			CheckBox repositoryOrder = _RepositoryOrder;
			if (repositoryOrder != null)
			{
				repositoryOrder.CheckedChanged -= value2;
			}
			_RepositoryOrder = value;
			repositoryOrder = _RepositoryOrder;
			if (repositoryOrder != null)
			{
				repositoryOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesStance_Neutral
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyAttr;
			CheckBox bridgeOrder = m_BridgeOrder;
			if (bridgeOrder != null)
			{
				bridgeOrder.CheckedChanged -= value2;
			}
			m_BridgeOrder = value;
			bridgeOrder = m_BridgeOrder;
			if (bridgeOrder != null)
			{
				bridgeOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesStance_Friendly
	{
		[CompilerGenerated]
		get
		{
			return _InvocationOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddAttr;
			CheckBox invocationOrder = _InvocationOrder;
			if (invocationOrder != null)
			{
				invocationOrder.CheckedChanged -= value2;
			}
			_InvocationOrder = value;
			invocationOrder = _InvocationOrder;
			if (invocationOrder != null)
			{
				invocationOrder.CheckedChanged += value2;
			}
		}
	}

	internal DarkUICheckBox CB_EmconFollowsWRARules
	{
		[CompilerGenerated]
		get
		{
			return classOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = GetAttr;
			DarkUICheckBox darkUICheckBox = classOrder;
			if (darkUICheckBox != null)
			{
				darkUICheckBox.CheckedChanged -= value2;
			}
			classOrder = value;
			darkUICheckBox = classOrder;
			if (darkUICheckBox != null)
			{
				darkUICheckBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("IncludesIDGroup")]
	internal DarkGroupBox IncludesIDGroup
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal CheckBox CB_IncludesID_KnownDomain
	{
		[CompilerGenerated]
		get
		{
			return valueOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutAttr;
			CheckBox checkBox = valueOrder;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			valueOrder = value;
			checkBox = valueOrder;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesID_KnownID
	{
		[CompilerGenerated]
		get
		{
			return _TokenizerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginAttr;
			CheckBox tokenizerOrder = _TokenizerOrder;
			if (tokenizerOrder != null)
			{
				tokenizerOrder.CheckedChanged -= value2;
			}
			_TokenizerOrder = value;
			tokenizerOrder = _TokenizerOrder;
			if (tokenizerOrder != null)
			{
				tokenizerOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesID_KnowType
	{
		[CompilerGenerated]
		get
		{
			return m_StubOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewAttr;
			CheckBox stubOrder = m_StubOrder;
			if (stubOrder != null)
			{
				stubOrder.CheckedChanged -= value2;
			}
			m_StubOrder = value;
			stubOrder = m_StubOrder;
			if (stubOrder != null)
			{
				stubOrder.CheckedChanged += value2;
			}
		}
	}

	internal CheckBox CB_IncludesID_KnownClass
	{
		[CompilerGenerated]
		get
		{
			return _WriterOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateAttr;
			CheckBox writerOrder = _WriterOrder;
			if (writerOrder != null)
			{
				writerOrder.CheckedChanged -= value2;
			}
			_WriterOrder = value;
			writerOrder = _WriterOrder;
			if (writerOrder != null)
			{
				writerOrder.CheckedChanged += value2;
			}
		}
	}

	internal DarkGroupBox Includes
	{
		[CompilerGenerated]
		get
		{
			return specificationOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationOrder = value;
		}
	}

	internal DarkUICheckBox CB_IntermittentEmission_USECUSTOM
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = WriteAttr;
			DarkUICheckBox watcherOrder = m_WatcherOrder;
			if (watcherOrder != null)
			{
				watcherOrder.CheckedChanged -= value2;
			}
			m_WatcherOrder = value;
			watcherOrder = m_WatcherOrder;
			if (watcherOrder != null)
			{
				watcherOrder.CheckedChanged += value2;
			}
		}
	}

	internal TabPage Custom
	{
		[CompilerGenerated]
		get
		{
			return reponseOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			reponseOrder = value;
		}
	}

	internal DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return descriptorOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorOrder = value;
		}
	}

	internal DarkLabel DarkLabel6
	{
		[CompilerGenerated]
		get
		{
			return m_PoolOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PoolOrder = value;
		}
	}

	internal DarkUICheckBox CBIntermittentEmission_InheritFromGroup
	{
		[CompilerGenerated]
		get
		{
			return taskOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = NewAttr;
			DarkUICheckBox darkUICheckBox = taskOrder;
			if (darkUICheckBox != null)
			{
				darkUICheckBox.CheckedChanged -= value2;
			}
			taskOrder = value;
			darkUICheckBox = taskOrder;
			if (darkUICheckBox != null)
			{
				darkUICheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUICheckBox DarkUICheckBox1
	{
		[CompilerGenerated]
		get
		{
			return m_FilterOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterOrder = value;
		}
	}

	internal DarkUIComboBox BingoThresholdCombo
	{
		[CompilerGenerated]
		get
		{
			return _TestsOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindException;
			EventHandler value3 = ReadException;
			DarkUIComboBox testsOrder = _TestsOrder;
			if (testsOrder != null)
			{
				testsOrder.SelectionChangeCommitted -= value2;
				testsOrder.Enter -= value3;
			}
			_TestsOrder = value;
			testsOrder = _TestsOrder;
			if (testsOrder != null)
			{
				testsOrder.SelectionChangeCommitted += value2;
				testsOrder.Enter += value3;
			}
		}
	}

	internal DarkCheckBox CB_BongoThreshold_PlayerEditable
	{
		[CompilerGenerated]
		get
		{
			return interpreterOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeAttr;
			DarkCheckBox darkCheckBox = interpreterOrder;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			interpreterOrder = value;
			darkCheckBox = interpreterOrder;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel8
	{
		[CompilerGenerated]
		get
		{
			return containerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerOrder = value;
		}
	}

	internal DarkLabel DarkLabel9
	{
		[CompilerGenerated]
		get
		{
			return composerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerOrder = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal DarkLabel DarkLabel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton SaveTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotRecord;
			DarkUIButton advisorOrder = m_AdvisorOrder;
			if (advisorOrder != null)
			{
				advisorOrder.Click -= value2;
			}
			m_AdvisorOrder = value;
			advisorOrder = m_AdvisorOrder;
			if (advisorOrder != null)
			{
				advisorOrder.Click += value2;
			}
		}
	}

	internal DarkUIButton LoadTemplate
	{
		[CompilerGenerated]
		get
		{
			return customerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushRecord;
			DarkUIButton darkUIButton = customerOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			customerOrder = value;
			darkUIButton = customerOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkLabel lblUseMissileWaypoints
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerOrder = value;
		}
	}

	internal DarkUIComboBox Combo_UseWPMissilesOnASuW
	{
		[CompilerGenerated]
		get
		{
			return _RefOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintRecord;
			EventHandler value3 = DefineRecord;
			EventHandler value4 = PublishRecord;
			DarkUIComboBox refOrder = _RefOrder;
			if (refOrder != null)
			{
				refOrder.Click -= value2;
				refOrder.Enter -= value3;
				refOrder.SelectionChangeCommitted -= value4;
			}
			_RefOrder = value;
			refOrder = _RefOrder;
			if (refOrder != null)
			{
				refOrder.Click += value2;
				refOrder.Enter += value3;
				refOrder.SelectionChangeCommitted += value4;
			}
		}
	}

	internal DarkCheckBox CB_UseWPMissilesOnASuW
	{
		[CompilerGenerated]
		get
		{
			return _ErrorOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushAttr;
			DarkCheckBox errorOrder = _ErrorOrder;
			if (errorOrder != null)
			{
				errorOrder.CheckedChanged -= value2;
			}
			_ErrorOrder = value;
			errorOrder = _ErrorOrder;
			if (errorOrder != null)
			{
				errorOrder.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal TabPage TabPage5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel_1
	{
		[CompilerGenerated]
		get
		{
			return connectionOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionOrder = value;
		}
	}

	internal DarkLabel DarkLabel_2
	{
		[CompilerGenerated]
		get
		{
			return contextOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			contextOrder = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel11")]
	internal DarkLabel DarkLabel_3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel10")]
	internal DarkLabel DarkLabel_4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Btn_PTLDelete
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchAttr;
			DarkUIButton strategyOrder = m_StrategyOrder;
			if (strategyOrder != null)
			{
				strategyOrder.Click -= value2;
			}
			m_StrategyOrder = value;
			strategyOrder = m_StrategyOrder;
			if (strategyOrder != null)
			{
				strategyOrder.Click += value2;
			}
		}
	}

	internal DarkUIButton Btn_PTLAdd
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeAttr;
			DarkUIButton configurationOrder = m_ConfigurationOrder;
			if (configurationOrder != null)
			{
				configurationOrder.Click -= value2;
			}
			m_ConfigurationOrder = value;
			configurationOrder = m_ConfigurationOrder;
			if (configurationOrder != null)
			{
				configurationOrder.Click += value2;
			}
		}
	}

	internal DarkUIButton Btn_PTLMoveDown
	{
		[CompilerGenerated]
		get
		{
			return tokenOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeAttr;
			DarkUIButton darkUIButton = tokenOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			tokenOrder = value;
			darkUIButton = tokenOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Btn_PTLMoveUp
	{
		[CompilerGenerated]
		get
		{
			return _IndexerOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupAttr;
			DarkUIButton indexerOrder = _IndexerOrder;
			if (indexerOrder != null)
			{
				indexerOrder.Click -= value2;
			}
			_IndexerOrder = value;
			indexerOrder = _IndexerOrder;
			if (indexerOrder != null)
			{
				indexerOrder.Click += value2;
			}
		}
	}

	internal DarkListView List_TargetPriority
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableAttr;
			DarkListView resolverOrder = m_ResolverOrder;
			if (resolverOrder != null)
			{
				resolverOrder.SelectedIndicesChanged -= value2;
			}
			m_ResolverOrder = value;
			resolverOrder = m_ResolverOrder;
			if (resolverOrder != null)
			{
				resolverOrder.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DarkUIButton Btn_PTLRemove
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckAttr;
			DarkUIButton publisherOrder = m_PublisherOrder;
			if (publisherOrder != null)
			{
				publisherOrder.Click -= value2;
			}
			m_PublisherOrder = value;
			publisherOrder = m_PublisherOrder;
			if (publisherOrder != null)
			{
				publisherOrder.Click += value2;
			}
		}
	}

	internal DarkUIButton Btn_PTLCreate
	{
		[CompilerGenerated]
		get
		{
			return serverOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitAttr;
			DarkUIButton darkUIButton = serverOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			serverOrder = value;
			darkUIButton = serverOrder;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_PTLSource")]
	internal DarkLabel Label_PTLSource
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel_5
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaOrder = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel14")]
	internal DarkLabel DarkLabel_6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel_7
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PredicateOrder = value;
		}
	}

	public ScenarioObject Subject
	{
		get
		{
			return singletonOrder;
		}
		set
		{
			singletonOrder = value;
			if (!Information.IsNothing(singletonOrder))
			{
				StopSingleton();
			}
		}
	}

	public List<ActiveUnit> SelectedUnits
	{
		get
		{
			if (isMissionEdit)
			{
				return null;
			}
			return _SelectedUnits;
		}
		set
		{
			_SelectedUnits = value;
		}
	}

	public ActiveEmissionInterval_Config IntervalConfigs
	{
		get
		{
			if (Information.IsNothing(m_ReponseSpecification))
			{
				m_ReponseSpecification = ForgotException();
			}
			return m_ReponseSpecification;
		}
		set
		{
			m_ReponseSpecification = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog ConcatSetter()
	{
		return m_DescriptorSpecification;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void InterruptSetter(OpenFileDialog openFileDialog_0)
	{
		m_DescriptorSpecification = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog FindSetter()
	{
		return m_PoolSpecification;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void SetSetter(SaveFileDialog saveFileDialog_0)
	{
		m_PoolSpecification = saveFileDialog_0;
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _IdentifierStub != null)
			{
				_IdentifierStub.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ReflectSingleton()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		UseIntervalGroup = new DarkGroupBox();
		CBIntermittentEmission_InheritFromGroup = new DarkUICheckBox();
		DarkUICheckBox1 = new DarkUICheckBox();
		CB_IntermittentEmission_USECUSTOM = new DarkUICheckBox();
		EmissionIntervalTABControl = new DarkUITabControl();
		GreenAlert = new TabPage();
		BlueAlert = new TabPage();
		YellowAlert = new TabPage();
		OrangeAlert = new TabPage();
		RedAlert = new TabPage();
		Custom = new TabPage();
		SaveTemplate = new DarkUIButton();
		LoadTemplate = new DarkUIButton();
		IntermittantToggle = new DarkUIButton();
		Label_AEI_3 = new DarkLabel();
		BackToSleepTime = new DarkUITextBox();
		CBWakeWhenDetectingThreat = new DarkUICheckBox();
		Label_AEI_1 = new DarkLabel();
		IntervalVariation = new DarkUITextBox();
		Interval = new DarkUITextBox();
		Label_AEI_2 = new DarkLabel();
		TGV_WRA = new DarkTreeGridView();
		TargetType = new TreeGridColumn();
		WeaponsPerSalvo = new DataGridViewComboBoxColumn();
		ShootersPerSalvo = new DataGridViewComboBoxColumn();
		FiringRange = new DataGridViewComboBoxColumn();
		SelfDefenceRange = new DataGridViewComboBoxColumn();
		TabControl1A = new DarkUITabControl();
		TabPage1 = new TabPage();
		Button_ResetCurrent_Doctrine = new DarkUIButton();
		Button_ResetAffectedMissions_Doctrine = new DarkUIButton();
		Button_ResetAffectedUnits_Doctrine = new DarkUIButton();
		TableLayoutPanel1 = new TableLayoutPanel();
		DarkLabel_5 = new DarkLabel();
		DarkLabel_6 = new DarkLabel();
		BingoThresholdCombo = new DarkUIComboBox();
		Combo_WeaponControlStatus_Air = new DarkUIComboBox();
		Combo_UseNukes = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Combo_BehaviorTowardsAmbigousTarget = new DarkUIComboBox();
		Label19 = new DarkLabel();
		Label20 = new DarkLabel();
		Label12 = new DarkLabel();
		Combo_ShootTourists = new DarkUIComboBox();
		Label1 = new DarkLabel();
		Combo_IgnorePlottedCourse = new DarkUIComboBox();
		Label13 = new DarkLabel();
		Label2 = new DarkLabel();
		Label23 = new DarkLabel();
		Label26 = new DarkLabel();
		Combo_WeaponControlStatus_Surface = new DarkUIComboBox();
		Combo_WeaponControlStatus_Submarine = new DarkUIComboBox();
		Combo_WeaponControlStatus_Land = new DarkUIComboBox();
		CB_UseNukes_PlayerEditable = new DarkCheckBox();
		CB_WeaponControlStatus_Submarine_PlayerEditable = new DarkCheckBox();
		CB_WeaponControlStatus_Air_PlayerEditable = new DarkCheckBox();
		CB_WeaponControlStatus_Surface_PlayerEditable = new DarkCheckBox();
		CB_WeaponControlStatus_Land_PlayerEditable = new DarkCheckBox();
		CB_IgnorePlottedCourse_PlayerEditable = new DarkCheckBox();
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable = new DarkCheckBox();
		Label22 = new DarkLabel();
		Label18 = new DarkLabel();
		Label17 = new DarkLabel();
		CB_AirOpsTempo_PlayerEditable = new DarkCheckBox();
		CB_QuickTurnAroundForAicraft_PlayerEditable = new DarkCheckBox();
		Label28 = new DarkLabel();
		Combo_AirOpsTempo = new DarkUIComboBox();
		Combo_QuickTurnAroundForAicraft = new DarkUIComboBox();
		Label30 = new DarkLabel();
		Combo_FuelState = new DarkUIComboBox();
		CB_FuelState_PlayerEditable = new DarkCheckBox();
		Combo_Standoff = new DarkUIComboBox();
		Label6 = new DarkLabel();
		Label14 = new DarkLabel();
		Combo_UseSAMsOnASuW = new DarkUIComboBox();
		CB_Standoff_PlayerEditable = new DarkCheckBox();
		CB_UseSAMsOnASuW_PlayerEditable = new DarkCheckBox();
		Label21 = new DarkLabel();
		Label27 = new DarkLabel();
		Combo_GunStrafing = new DarkUIComboBox();
		CB_GunStrafing_PlayerEditable = new DarkCheckBox();
		Label4 = new DarkLabel();
		Combo_WeaponStateRTB = new DarkUIComboBox();
		CB_WeaponStateRTB_PlayerEditable = new DarkCheckBox();
		Label29 = new DarkLabel();
		Combo_WeaponState = new DarkUIComboBox();
		CB_WeaponState_PlayerEditable = new DarkCheckBox();
		Combo_Jettison = new DarkUIComboBox();
		Label31 = new DarkLabel();
		CB_JettisonOrdnance_PlayerEditable = new DarkCheckBox();
		CB_FuelStateRTB_PlayerEditable = new DarkCheckBox();
		Combo_FuelStateRTB = new DarkUIComboBox();
		Label32 = new DarkLabel();
		Label11 = new DarkLabel();
		CB_ShootTourists_PlayerEditable = new DarkCheckBox();
		Label52 = new DarkLabel();
		CB_BVRLogic_PlayerEditable = new DarkCheckBox();
		Combo_BVRLogic = new DarkUIComboBox();
		Label40 = new DarkLabel();
		CB_DippingSonar_PlayerEditable = new DarkCheckBox();
		Combo_DippingSonar = new DarkUIComboBox();
		Label39 = new DarkLabel();
		Label38 = new DarkLabel();
		Label37 = new DarkLabel();
		Label36 = new DarkLabel();
		Label35 = new DarkLabel();
		Label34 = new DarkLabel();
		Combo_AIP_Usage = new DarkUIComboBox();
		Combo_BatteryRechargeAttack = new DarkUIComboBox();
		Combo_BatteryRechargePatrol = new DarkUIComboBox();
		Combo_DiveWhenThreatsDetected = new DarkUIComboBox();
		Combo_AvoidContact = new DarkUIComboBox();
		CB_AIP_Usage_PlayerEditable = new DarkCheckBox();
		CB_BatteryRechargeAttack_PlayerEditable = new DarkCheckBox();
		CB_BatteryRechargePatrol_PlayerEditable = new DarkCheckBox();
		CB_DiveWhenThreatsDetected_PlayerEditable = new DarkCheckBox();
		CB_AvoidContact_PlayerEditable = new DarkCheckBox();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		CB_Surface_Navigation_PlayerEditable = new DarkCheckBox();
		CB_Submarine_Navigation_PlayerEditable = new DarkCheckBox();
		Combo_Surface_Navigation = new DarkUIComboBox();
		Combo_Submarine_Navigation = new DarkUIComboBox();
		Combo_Land_Navigation = new DarkUIComboBox();
		Label25 = new DarkLabel();
		Label15 = new DarkLabel();
		Label24 = new DarkLabel();
		Label16 = new DarkLabel();
		Label7 = new DarkLabel();
		Combo_IgnoreEMCONunderAttack = new DarkUIComboBox();
		Combo_UseKinematicRangeForTorpedoes = new DarkUIComboBox();
		Combo_AutoEvade = new DarkUIComboBox();
		Combo_UseRefuel = new DarkUIComboBox();
		Combo_ReplenishmentSelection = new DarkUIComboBox();
		Combo_RefuelAllies = new DarkUIComboBox();
		CB_IgnoreEMCONunderAttack_PlayerEditable = new DarkCheckBox();
		CB_UseKinematicRangeForTorpedoes_PlayerEditable = new DarkCheckBox();
		CB_AutoEvade_PlayerEditable = new DarkCheckBox();
		Label10 = new DarkLabel();
		Label51 = new DarkLabel();
		Label33 = new DarkLabel();
		CB_RefuelAllies_PlayerEditable = new DarkCheckBox();
		CB_ReplenishmentSelection_PlayerEditable = new DarkCheckBox();
		CB_UseRefuel_PlayerEditable = new DarkCheckBox();
		CB_BongoThreshold_PlayerEditable = new DarkCheckBox();
		DarkLabel8 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		CB_Land_Navigation_PlayerEditable = new DarkCheckBox();
		lblUseMissileWaypoints = new DarkLabel();
		Combo_UseWPMissilesOnASuW = new DarkUIComboBox();
		CB_UseWPMissilesOnASuW = new DarkCheckBox();
		DarkLabel_7 = new DarkLabel();
		TabPage2 = new TabPage();
		DarkLabel9 = new DarkLabel();
		DefoncLabel2 = new DarkLabel();
		DarkLabel_0 = new DarkLabel();
		EmissionIntervalPhonyTab = new Panel();
		WakeGroupBox = new DarkGroupBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		IncludesIDGroup = new DarkGroupBox();
		CB_IncludesID_Unknown = new CheckBox();
		CB_IncludesID_KnownDomain = new CheckBox();
		CB_IncludesID_KnownID = new CheckBox();
		CB_IncludesID_KnowType = new CheckBox();
		CB_IncludesID_KnownClass = new CheckBox();
		Includes = new DarkGroupBox();
		CB_IncludesStance_Hostile = new CheckBox();
		CB_IncludesStance_Friendly = new CheckBox();
		CB_IncludesStance_Neutral = new CheckBox();
		CB_IncludesStance_Unfriendly = new CheckBox();
		CB_IncludesStance_Unknown = new CheckBox();
		CB_EmconFollowsWRARules = new DarkUICheckBox();
		LabelPlus = new DarkLabel();
		EmissionDurationTextBox = new DarkUITextBox();
		Label_AEI_0 = new DarkLabel();
		Combo_AlertLevel = new DarkUIComboBox();
		Button_ResetAffectedMissions_EMCON = new DarkUIButton();
		Button_ResetAffectedUnits_EMCON = new DarkUIButton();
		Button_ResetCurrent_EMCON = new DarkUIButton();
		CB_EMCON_Sonar = new DarkUIComboBox();
		Label9 = new DarkLabel();
		CB_EMCON_OECM = new DarkUIComboBox();
		Label8 = new DarkLabel();
		CB_EMCON_Inherits = new DarkCheckBox();
		CB_EMCON_Radar = new DarkUIComboBox();
		Label3 = new DarkLabel();
		TabPage3 = new TabPage();
		Button_ResetAffectedMissions_WRA = new DarkUIButton();
		Button_ResetAffectedUnits_WRA = new DarkUIButton();
		Button_ResetCurrent_WRA = new DarkUIButton();
		TabPage4 = new TabPage();
		Combo_RedeployDefenceThreshold = new DarkUIComboBox();
		Combo_RedeployAttackThreshold = new DarkUIComboBox();
		Combo_RedeployFuelThreshold = new DarkUIComboBox();
		Label46 = new DarkLabel();
		Label47 = new DarkLabel();
		Label48 = new DarkLabel();
		Label49 = new DarkLabel();
		Combo_RedeployDamageThreshold = new DarkUIComboBox();
		Label50 = new DarkLabel();
		Combo_WithdrawDefenceThreshold = new DarkUIComboBox();
		Combo_WithdrawAttackThreshold = new DarkUIComboBox();
		Combo_WithdrawFuelThreshold = new DarkUIComboBox();
		Label45 = new DarkLabel();
		Label43 = new DarkLabel();
		Label44 = new DarkLabel();
		Label42 = new DarkLabel();
		Combo_WithdrawDamageThreshold = new DarkUIComboBox();
		Label41 = new DarkLabel();
		TabPage5 = new TabPage();
		Btn_PTLRemove = new DarkUIButton();
		Btn_PTLCreate = new DarkUIButton();
		Label_PTLSource = new DarkLabel();
		DarkLabel_1 = new DarkLabel();
		DarkLabel_2 = new DarkLabel();
		DarkLabel_3 = new DarkLabel();
		DarkLabel_4 = new DarkLabel();
		Btn_PTLDelete = new DarkUIButton();
		Btn_PTLAdd = new DarkUIButton();
		Btn_PTLMoveDown = new DarkUIButton();
		Btn_PTLMoveUp = new DarkUIButton();
		List_TargetPriority = new DarkListView();
		UseIntervalGroup.SuspendLayout();
		EmissionIntervalTABControl.SuspendLayout();
		((ISupportInitialize)TGV_WRA).BeginInit();
		TabControl1A.SuspendLayout();
		TabPage1.SuspendLayout();
		TableLayoutPanel1.SuspendLayout();
		TabPage2.SuspendLayout();
		EmissionIntervalPhonyTab.SuspendLayout();
		WakeGroupBox.SuspendLayout();
		IncludesIDGroup.SuspendLayout();
		Includes.SuspendLayout();
		TabPage3.SuspendLayout();
		TabPage4.SuspendLayout();
		TabPage5.SuspendLayout();
		SuspendLayout();
		UseIntervalGroup.Controls.Add(CBIntermittentEmission_InheritFromGroup);
		UseIntervalGroup.Controls.Add(DarkUICheckBox1);
		UseIntervalGroup.Controls.Add(CB_IntermittentEmission_USECUSTOM);
		UseIntervalGroup.Controls.Add(EmissionIntervalTABControl);
		UseIntervalGroup.ForeColor = Color.FromArgb(220, 220, 220);
		UseIntervalGroup.Location = new Point(12, 152);
		UseIntervalGroup.Name = "UseIntervalGroup";
		UseIntervalGroup.Size = new Size(473, 301);
		UseIntervalGroup.TabIndex = 18;
		UseIntervalGroup.TabStop = false;
		UseIntervalGroup.Text = "开机间隔时间";
		CBIntermittentEmission_InheritFromGroup.BackColor = Color.Transparent;
		CBIntermittentEmission_InheritFromGroup.Checked = false;
		CBIntermittentEmission_InheritFromGroup.Cursor = Cursors.Hand;
		CBIntermittentEmission_InheritFromGroup.ForeColor = Color.FromArgb(209, 209, 209);
		CBIntermittentEmission_InheritFromGroup.Location = new Point(154, 274);
		CBIntermittentEmission_InheritFromGroup.Name = "CBIntermittentEmission_InheritFromGroup";
		CBIntermittentEmission_InheritFromGroup.Size = new Size(186, 18);
		CBIntermittentEmission_InheritFromGroup.TabIndex = 36;
		CBIntermittentEmission_InheritFromGroup.Text = "使用所在编组参数";
		DarkUICheckBox1.BackColor = Color.Transparent;
		DarkUICheckBox1.Checked = false;
		DarkUICheckBox1.Cursor = Cursors.Hand;
		DarkUICheckBox1.ForeColor = Color.FromArgb(209, 209, 209);
		DarkUICheckBox1.Location = new Point(143, 141);
		DarkUICheckBox1.Name = "DarkUICheckBox1";
		DarkUICheckBox1.Size = new Size(186, 18);
		DarkUICheckBox1.TabIndex = 36;
		DarkUICheckBox1.Text = "仅使用自定义预设值";
		CB_IntermittentEmission_USECUSTOM.BackColor = Color.Transparent;
		CB_IntermittentEmission_USECUSTOM.Checked = false;
		CB_IntermittentEmission_USECUSTOM.Cursor = Cursors.Hand;
		CB_IntermittentEmission_USECUSTOM.ForeColor = Color.FromArgb(209, 209, 209);
		CB_IntermittentEmission_USECUSTOM.Location = new Point(6, 274);
		CB_IntermittentEmission_USECUSTOM.Name = "CB_IntermittentEmission_USECUSTOM";
		CB_IntermittentEmission_USECUSTOM.Size = new Size(186, 18);
		CB_IntermittentEmission_USECUSTOM.TabIndex = 35;
		CB_IntermittentEmission_USECUSTOM.Text = "仅使用自定义预设值";
		EmissionIntervalTABControl.Controls.Add(GreenAlert);
		EmissionIntervalTABControl.Controls.Add(BlueAlert);
		EmissionIntervalTABControl.Controls.Add(YellowAlert);
		EmissionIntervalTABControl.Controls.Add(OrangeAlert);
		EmissionIntervalTABControl.Controls.Add(RedAlert);
		EmissionIntervalTABControl.Controls.Add(Custom);
		EmissionIntervalTABControl.Cursor = Cursors.Hand;
		EmissionIntervalTABControl.ItemSize = new Size(80, 20);
		EmissionIntervalTABControl.Location = new Point(6, 21);
		EmissionIntervalTABControl.Name = "EmissionIntervalTABControl";
		EmissionIntervalTABControl.SelectedIndex = 0;
		EmissionIntervalTABControl.Size = new Size(458, 247);
		EmissionIntervalTABControl.TabIndex = 0;
		GreenAlert.BackColor = Color.FromArgb(60, 63, 65);
		GreenAlert.Location = new Point(4, 24);
		GreenAlert.Name = "GreenAlert";
		GreenAlert.Padding = new Padding(3);
		GreenAlert.Size = new Size(450, 219);
		GreenAlert.TabIndex = 0;
		GreenAlert.Tag = "Green";
		GreenAlert.Text = "绿色";
		BlueAlert.BackColor = Color.FromArgb(60, 63, 65);
		BlueAlert.Location = new Point(4, 24);
		BlueAlert.Name = "BlueAlert";
		BlueAlert.Padding = new Padding(3);
		BlueAlert.Size = new Size(450, 219);
		BlueAlert.TabIndex = 1;
		BlueAlert.Tag = "Blue";
		BlueAlert.Text = "蓝色";
		YellowAlert.BackColor = Color.FromArgb(60, 63, 65);
		YellowAlert.Location = new Point(4, 24);
		YellowAlert.Name = "YellowAlert";
		YellowAlert.Size = new Size(450, 219);
		YellowAlert.TabIndex = 2;
		YellowAlert.Tag = "Yellow";
		YellowAlert.Text = "黄色";
		OrangeAlert.BackColor = Color.FromArgb(60, 63, 65);
		OrangeAlert.Location = new Point(4, 24);
		OrangeAlert.Name = "OrangeAlert";
		OrangeAlert.Size = new Size(450, 219);
		OrangeAlert.TabIndex = 3;
		OrangeAlert.Tag = "Orange";
		OrangeAlert.Text = "橙色";
		RedAlert.BackColor = Color.FromArgb(60, 63, 65);
		RedAlert.Location = new Point(4, 24);
		RedAlert.Name = "RedAlert";
		RedAlert.Size = new Size(450, 219);
		RedAlert.TabIndex = 4;
		RedAlert.Tag = "Red";
		RedAlert.Text = "红色";
		Custom.BackColor = Color.FromArgb(60, 63, 65);
		Custom.Location = new Point(4, 24);
		Custom.Name = "Custom";
		Custom.Size = new Size(450, 219);
		Custom.TabIndex = 5;
		Custom.Tag = "Custom";
		Custom.Text = "自定义";
		SaveTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		SaveTemplate.BackColor = Color.Transparent;
		SaveTemplate.DialogResult = DialogResult.None;
		SaveTemplate.Font = new Font("Segoe UI", 8.25f);
		SaveTemplate.ForeColor = SystemColors.Control;
		SaveTemplate.Location = new Point(905, 622);
		SaveTemplate.Name = "SaveTemplate";
		SaveTemplate.Padding = new Padding(5);
		SaveTemplate.RoundRadius = 0;
		SaveTemplate.Size = new Size(87, 23);
		SaveTemplate.TabIndex = 9;
		SaveTemplate.Text = "保存为模板";
		LoadTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LoadTemplate.BackColor = Color.Transparent;
		LoadTemplate.DialogResult = DialogResult.None;
		LoadTemplate.Font = new Font("Segoe UI", 8.25f);
		LoadTemplate.ForeColor = SystemColors.Control;
		LoadTemplate.Location = new Point(811, 622);
		LoadTemplate.Name = "LoadTemplate";
		LoadTemplate.Padding = new Padding(5);
		LoadTemplate.RoundRadius = 0;
		LoadTemplate.Size = new Size(88, 23);
		LoadTemplate.TabIndex = 8;
		LoadTemplate.Text = "从模板加载";
		IntermittantToggle.BackColor = Color.Transparent;
		IntermittantToggle.DialogResult = DialogResult.None;
		IntermittantToggle.ForeColor = SystemColors.Control;
		IntermittantToggle.Location = new Point(3, 6);
		IntermittantToggle.Name = "IntermittantToggle";
		IntermittantToggle.RoundRadius = 0;
		IntermittantToggle.Size = new Size(188, 40);
		IntermittantToggle.TabIndex = 22;
		IntermittantToggle.Text = "间断工作模式";
		Label_AEI_3.AutoSize = true;
		Label_AEI_3.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AEI_3.Location = new Point(3, 21);
		Label_AEI_3.Name = "Label_AEI_3";
		Label_AEI_3.Size = new Size(233, 21);
		Label_AEI_3.TabIndex = 21;
		Label_AEI_3.Text = "到此时间后睡眠(秒)";
		BackToSleepTime.AutoCompleteCustomSource = null;
		BackToSleepTime.AutoCompleteMode = AutoCompleteMode.None;
		BackToSleepTime.AutoCompleteSource = AutoCompleteSource.None;
		BackToSleepTime.BackColor = Color.Transparent;
		BackToSleepTime.ForeColor = Color.FromArgb(189, 189, 189);
		BackToSleepTime.Image = null;
		BackToSleepTime.Lines = null;
		BackToSleepTime.Location = new Point(6, 37);
		BackToSleepTime.MaxLength = 32767;
		BackToSleepTime.Multiline = false;
		BackToSleepTime.Name = "BackToSleepTime";
		BackToSleepTime.ReadOnly = false;
		BackToSleepTime.ScrollBars = ScrollBars.None;
		BackToSleepTime.SelectionStart = 0;
		BackToSleepTime.Size = new Size(159, 24);
		BackToSleepTime.TabIndex = 20;
		BackToSleepTime.Text = "5";
		BackToSleepTime.TextAlign = HorizontalAlignment.Center;
		BackToSleepTime.UseSystemPasswordChar = false;
		BackToSleepTime.WatermarkText = "";
		CBWakeWhenDetectingThreat.BackColor = Color.Transparent;
		CBWakeWhenDetectingThreat.Checked = false;
		CBWakeWhenDetectingThreat.Cursor = Cursors.Hand;
		CBWakeWhenDetectingThreat.ForeColor = Color.FromArgb(209, 209, 209);
		CBWakeWhenDetectingThreat.Location = new Point(19, 92);
		CBWakeWhenDetectingThreat.Name = "CBWakeWhenDetectingThreat";
		CBWakeWhenDetectingThreat.Size = new Size(172, 18);
		CBWakeWhenDetectingThreat.TabIndex = 19;
		CBWakeWhenDetectingThreat.Text = "当探测到威胁时开机";
		Label_AEI_1.AutoSize = true;
		Label_AEI_1.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AEI_1.Location = new Point(208, 46);
		Label_AEI_1.Name = "Label_AEI_1";
		Label_AEI_1.Size = new Size(261, 21);
		Label_AEI_1.TabIndex = 18;
		Label_AEI_1.Text = "间隔随机变量(秒)";
		IntervalVariation.AutoCompleteCustomSource = null;
		IntervalVariation.AutoCompleteMode = AutoCompleteMode.None;
		IntervalVariation.AutoCompleteSource = AutoCompleteSource.None;
		IntervalVariation.BackColor = Color.Transparent;
		IntervalVariation.ForeColor = Color.FromArgb(189, 189, 189);
		IntervalVariation.Image = null;
		IntervalVariation.Lines = null;
		IntervalVariation.Location = new Point(211, 62);
		IntervalVariation.MaxLength = 32767;
		IntervalVariation.Multiline = false;
		IntervalVariation.Name = "IntervalVariation";
		IntervalVariation.ReadOnly = false;
		IntervalVariation.ScrollBars = ScrollBars.None;
		IntervalVariation.SelectionStart = 0;
		IntervalVariation.Size = new Size(188, 24);
		IntervalVariation.TabIndex = 16;
		IntervalVariation.Text = "20";
		IntervalVariation.TextAlign = HorizontalAlignment.Center;
		IntervalVariation.UseSystemPasswordChar = false;
		IntervalVariation.WatermarkText = "";
		Interval.AutoCompleteCustomSource = null;
		Interval.AutoCompleteMode = AutoCompleteMode.None;
		Interval.AutoCompleteSource = AutoCompleteSource.None;
		Interval.BackColor = Color.Transparent;
		Interval.ForeColor = Color.FromArgb(189, 189, 189);
		Interval.Image = null;
		Interval.Lines = null;
		Interval.Location = new Point(3, 62);
		Interval.MaxLength = 32767;
		Interval.Multiline = false;
		Interval.Name = "Interval";
		Interval.ReadOnly = false;
		Interval.ScrollBars = ScrollBars.None;
		Interval.SelectionStart = 0;
		Interval.Size = new Size(188, 24);
		Interval.TabIndex = 15;
		Interval.Text = "90";
		Interval.TextAlign = HorizontalAlignment.Center;
		Interval.UseSystemPasswordChar = false;
		Interval.WatermarkText = "";
		Label_AEI_2.AutoSize = true;
		Label_AEI_2.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AEI_2.Location = new Point(3, 46);
		Label_AEI_2.Name = "Label_AEI_2";
		Label_AEI_2.Size = new Size(132, 21);
		Label_AEI_2.TabIndex = 17;
		Label_AEI_2.Text = "间隔(秒)";
		TGV_WRA.AllowUserToAddRows = false;
		TGV_WRA.AllowUserToDeleteRows = false;
		TGV_WRA.AllowUserToOrderColumns = true;
		TGV_WRA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_WRA.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_WRA.BorderStyle = BorderStyle.Fixed3D;
		TGV_WRA.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_WRA.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_WRA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_WRA.ColumnHeadersHeight = 34;
		TGV_WRA.Columns.AddRange(TargetType, WeaponsPerSalvo, ShootersPerSalvo, FiringRange, SelfDefenceRange);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_WRA.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_WRA.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_WRA.EnableHeadersVisualStyles = false;
		TGV_WRA.ImageList = null;
		TGV_WRA.Location = new Point(0, 0);
		TGV_WRA.MultiSelect = false;
		TGV_WRA.Name = "TGV_WRA";
		TGV_WRA.RowHeadersVisible = false;
		TGV_WRA.RowHeadersWidth = 20;
		TGV_WRA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_WRA.ShowLines = false;
		TGV_WRA.Size = new Size(1000, 622);
		TGV_WRA.TabIndex = 8;
		TargetType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		TargetType.DefaultNodeImage = null;
		TargetType.HeaderText = "武器与目标类型";
		TargetType.MinimumWidth = 8;
		TargetType.Name = "TargetType";
		TargetType.Resizable = DataGridViewTriState.True;
		TargetType.SortMode = DataGridViewColumnSortMode.NotSortable;
		WeaponsPerSalvo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		WeaponsPerSalvo.DropDownWidth = 2;
		WeaponsPerSalvo.FlatStyle = FlatStyle.Flat;
		WeaponsPerSalvo.HeaderText = "每个齐射的波次";
		WeaponsPerSalvo.MaxDropDownItems = 20;
		WeaponsPerSalvo.MinimumWidth = 170;
		WeaponsPerSalvo.Name = "WeaponsPerSalvo";
		WeaponsPerSalvo.Width = 170;
		ShootersPerSalvo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		ShootersPerSalvo.DropDownWidth = 2;
		ShootersPerSalvo.FlatStyle = FlatStyle.Flat;
		ShootersPerSalvo.HeaderText = "每个齐射参与单元数";
		ShootersPerSalvo.MaxDropDownItems = 20;
		ShootersPerSalvo.MinimumWidth = 170;
		ShootersPerSalvo.Name = "ShootersPerSalvo";
		ShootersPerSalvo.Resizable = DataGridViewTriState.True;
		ShootersPerSalvo.Width = 170;
		FiringRange.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		FiringRange.DropDownWidth = 2;
		FiringRange.FlatStyle = FlatStyle.Flat;
		FiringRange.HeaderText = "自动射击范围";
		FiringRange.MinimumWidth = 170;
		FiringRange.Name = "FiringRange";
		FiringRange.Resizable = DataGridViewTriState.True;
		FiringRange.Width = 170;
		SelfDefenceRange.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		SelfDefenceRange.DropDownWidth = 2;
		SelfDefenceRange.FlatStyle = FlatStyle.Flat;
		SelfDefenceRange.HeaderText = "自卫";
		SelfDefenceRange.MaxDropDownItems = 20;
		SelfDefenceRange.MinimumWidth = 170;
		SelfDefenceRange.Name = "SelfDefenceRange";
		SelfDefenceRange.Width = 170;
		TabControl1A.Controls.Add(TabPage1);
		TabControl1A.Controls.Add(TabPage2);
		TabControl1A.Controls.Add(TabPage3);
		TabControl1A.Controls.Add(TabPage4);
		TabControl1A.Controls.Add(TabPage5);
		TabControl1A.Cursor = Cursors.Hand;
		TabControl1A.Dock = DockStyle.Fill;
		TabControl1A.Font = new Font("Segoe UI", 8f);
		TabControl1A.ItemSize = new Size(80, 32);
		TabControl1A.Location = new Point(0, 0);
		TabControl1A.Name = "TabControl1A";
		TabControl1A.SelectedIndex = 0;
		TabControl1A.Size = new Size(1008, 691);
		TabControl1A.TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Button_ResetCurrent_Doctrine);
		TabPage1.Controls.Add(Button_ResetAffectedMissions_Doctrine);
		TabPage1.Controls.Add(Button_ResetAffectedUnits_Doctrine);
		TabPage1.Controls.Add(TableLayoutPanel1);
		TabPage1.Controls.Add(SaveTemplate);
		TabPage1.Controls.Add(LoadTemplate);
		TabPage1.Location = new Point(4, 36);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(1000, 651);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "通用";
		Button_ResetCurrent_Doctrine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetCurrent_Doctrine.BackColor = Color.Transparent;
		Button_ResetCurrent_Doctrine.DialogResult = DialogResult.None;
		Button_ResetCurrent_Doctrine.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetCurrent_Doctrine.ForeColor = SystemColors.Control;
		Button_ResetCurrent_Doctrine.Location = new Point(3, 622);
		Button_ResetCurrent_Doctrine.Name = "Button_ResetCurrent_Doctrine";
		Button_ResetCurrent_Doctrine.Padding = new Padding(5);
		Button_ResetCurrent_Doctrine.RoundRadius = 0;
		Button_ResetCurrent_Doctrine.Size = new Size(230, 23);
		Button_ResetCurrent_Doctrine.TabIndex = 0;
		Button_ResetCurrent_Doctrine.Text = "重置条令（使用继承的设置）";
		Button_ResetAffectedMissions_Doctrine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedMissions_Doctrine.BackColor = Color.Transparent;
		Button_ResetAffectedMissions_Doctrine.DialogResult = DialogResult.None;
		Button_ResetAffectedMissions_Doctrine.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedMissions_Doctrine.ForeColor = SystemColors.Control;
		Button_ResetAffectedMissions_Doctrine.Location = new Point(502, 622);
		Button_ResetAffectedMissions_Doctrine.Name = "Button_ResetAffectedMissions_Doctrine";
		Button_ResetAffectedMissions_Doctrine.Padding = new Padding(5);
		Button_ResetAffectedMissions_Doctrine.RoundRadius = 0;
		Button_ResetAffectedMissions_Doctrine.Size = new Size(271, 23);
		Button_ResetAffectedMissions_Doctrine.TabIndex = 2;
		Button_ResetAffectedMissions_Doctrine.Text = "重置受影响的任务（继承自上述原则）";
		Button_ResetAffectedUnits_Doctrine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedUnits_Doctrine.BackColor = Color.Transparent;
		Button_ResetAffectedUnits_Doctrine.DialogResult = DialogResult.None;
		Button_ResetAffectedUnits_Doctrine.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedUnits_Doctrine.ForeColor = SystemColors.Control;
		Button_ResetAffectedUnits_Doctrine.Location = new Point(241, 622);
		Button_ResetAffectedUnits_Doctrine.Name = "Button_ResetAffectedUnits_Doctrine";
		Button_ResetAffectedUnits_Doctrine.Padding = new Padding(5);
		Button_ResetAffectedUnits_Doctrine.RoundRadius = 0;
		Button_ResetAffectedUnits_Doctrine.Size = new Size(255, 23);
		Button_ResetAffectedUnits_Doctrine.TabIndex = 1;
		Button_ResetAffectedUnits_Doctrine.Text = "重置受影响的单元（继承自上述原则）";
		TableLayoutPanel1.ColumnCount = 6;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23f));
		TableLayoutPanel1.Controls.Add(DarkLabel_5, 0, 26);
		TableLayoutPanel1.Controls.Add(DarkLabel_6, 0, 26);
		TableLayoutPanel1.Controls.Add(BingoThresholdCombo, 1, 19);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Air, 1, 3);
		TableLayoutPanel1.Controls.Add(Combo_UseNukes, 1, 1);
		TableLayoutPanel1.Controls.Add(Label5, 0, 8);
		TableLayoutPanel1.Controls.Add(Combo_BehaviorTowardsAmbigousTarget, 1, 8);
		TableLayoutPanel1.Controls.Add(Label19, 0, 0);
		TableLayoutPanel1.Controls.Add(Label20, 0, 2);
		TableLayoutPanel1.Controls.Add(Label12, 0, 1);
		TableLayoutPanel1.Controls.Add(Combo_ShootTourists, 1, 9);
		TableLayoutPanel1.Controls.Add(Label1, 0, 7);
		TableLayoutPanel1.Controls.Add(Combo_IgnorePlottedCourse, 1, 7);
		TableLayoutPanel1.Controls.Add(Label13, 0, 3);
		TableLayoutPanel1.Controls.Add(Label2, 0, 4);
		TableLayoutPanel1.Controls.Add(Label23, 0, 5);
		TableLayoutPanel1.Controls.Add(Label26, 0, 6);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Surface, 1, 4);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Submarine, 1, 5);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Land, 1, 6);
		TableLayoutPanel1.Controls.Add(CB_UseNukes_PlayerEditable, 2, 1);
		TableLayoutPanel1.Controls.Add(CB_WeaponControlStatus_Submarine_PlayerEditable, 2, 5);
		TableLayoutPanel1.Controls.Add(CB_WeaponControlStatus_Air_PlayerEditable, 2, 3);
		TableLayoutPanel1.Controls.Add(CB_WeaponControlStatus_Surface_PlayerEditable, 2, 4);
		TableLayoutPanel1.Controls.Add(CB_WeaponControlStatus_Land_PlayerEditable, 2, 6);
		TableLayoutPanel1.Controls.Add(CB_IgnorePlottedCourse_PlayerEditable, 2, 7);
		TableLayoutPanel1.Controls.Add(CB_BehaviorTowardsAmbigousTarget_PlayerEditable, 2, 8);
		TableLayoutPanel1.Controls.Add(Label22, 3, 0);
		TableLayoutPanel1.Controls.Add(Label18, 3, 1);
		TableLayoutPanel1.Controls.Add(Label17, 3, 2);
		TableLayoutPanel1.Controls.Add(CB_AirOpsTempo_PlayerEditable, 5, 1);
		TableLayoutPanel1.Controls.Add(CB_QuickTurnAroundForAicraft_PlayerEditable, 5, 2);
		TableLayoutPanel1.Controls.Add(Label28, 3, 3);
		TableLayoutPanel1.Controls.Add(Combo_AirOpsTempo, 4, 1);
		TableLayoutPanel1.Controls.Add(Combo_QuickTurnAroundForAicraft, 4, 2);
		TableLayoutPanel1.Controls.Add(Label30, 1, 0);
		TableLayoutPanel1.Controls.Add(Combo_FuelState, 4, 3);
		TableLayoutPanel1.Controls.Add(CB_FuelState_PlayerEditable, 5, 3);
		TableLayoutPanel1.Controls.Add(Combo_Standoff, 4, 12);
		TableLayoutPanel1.Controls.Add(Label6, 3, 12);
		TableLayoutPanel1.Controls.Add(Label14, 3, 11);
		TableLayoutPanel1.Controls.Add(Combo_UseSAMsOnASuW, 4, 11);
		TableLayoutPanel1.Controls.Add(CB_Standoff_PlayerEditable, 5, 12);
		TableLayoutPanel1.Controls.Add(CB_UseSAMsOnASuW_PlayerEditable, 5, 11);
		TableLayoutPanel1.Controls.Add(Label21, 3, 10);
		TableLayoutPanel1.Controls.Add(Label27, 3, 7);
		TableLayoutPanel1.Controls.Add(Combo_GunStrafing, 4, 7);
		TableLayoutPanel1.Controls.Add(CB_GunStrafing_PlayerEditable, 5, 7);
		TableLayoutPanel1.Controls.Add(Label4, 3, 6);
		TableLayoutPanel1.Controls.Add(Combo_WeaponStateRTB, 4, 6);
		TableLayoutPanel1.Controls.Add(CB_WeaponStateRTB_PlayerEditable, 5, 6);
		TableLayoutPanel1.Controls.Add(Label29, 3, 5);
		TableLayoutPanel1.Controls.Add(Combo_WeaponState, 4, 5);
		TableLayoutPanel1.Controls.Add(CB_WeaponState_PlayerEditable, 5, 5);
		TableLayoutPanel1.Controls.Add(Combo_Jettison, 4, 8);
		TableLayoutPanel1.Controls.Add(Label31, 3, 8);
		TableLayoutPanel1.Controls.Add(CB_JettisonOrdnance_PlayerEditable, 5, 8);
		TableLayoutPanel1.Controls.Add(CB_FuelStateRTB_PlayerEditable, 5, 4);
		TableLayoutPanel1.Controls.Add(Combo_FuelStateRTB, 4, 4);
		TableLayoutPanel1.Controls.Add(Label32, 3, 4);
		TableLayoutPanel1.Controls.Add(Label11, 0, 9);
		TableLayoutPanel1.Controls.Add(CB_ShootTourists_PlayerEditable, 2, 9);
		TableLayoutPanel1.Controls.Add(Label52, 3, 9);
		TableLayoutPanel1.Controls.Add(CB_BVRLogic_PlayerEditable, 5, 9);
		TableLayoutPanel1.Controls.Add(Combo_BVRLogic, 4, 9);
		TableLayoutPanel1.Controls.Add(Label40, 3, 21);
		TableLayoutPanel1.Controls.Add(CB_DippingSonar_PlayerEditable, 5, 21);
		TableLayoutPanel1.Controls.Add(Combo_DippingSonar, 4, 21);
		TableLayoutPanel1.Controls.Add(Label39, 3, 20);
		TableLayoutPanel1.Controls.Add(Label38, 3, 19);
		TableLayoutPanel1.Controls.Add(Label37, 3, 18);
		TableLayoutPanel1.Controls.Add(Label36, 3, 17);
		TableLayoutPanel1.Controls.Add(Label35, 3, 16);
		TableLayoutPanel1.Controls.Add(Label34, 3, 15);
		TableLayoutPanel1.Controls.Add(Combo_AIP_Usage, 4, 20);
		TableLayoutPanel1.Controls.Add(Combo_BatteryRechargeAttack, 4, 19);
		TableLayoutPanel1.Controls.Add(Combo_BatteryRechargePatrol, 4, 18);
		TableLayoutPanel1.Controls.Add(Combo_DiveWhenThreatsDetected, 4, 17);
		TableLayoutPanel1.Controls.Add(Combo_AvoidContact, 4, 16);
		TableLayoutPanel1.Controls.Add(CB_AIP_Usage_PlayerEditable, 5, 20);
		TableLayoutPanel1.Controls.Add(CB_BatteryRechargeAttack_PlayerEditable, 5, 19);
		TableLayoutPanel1.Controls.Add(CB_BatteryRechargePatrol_PlayerEditable, 5, 18);
		TableLayoutPanel1.Controls.Add(CB_DiveWhenThreatsDetected_PlayerEditable, 5, 17);
		TableLayoutPanel1.Controls.Add(CB_AvoidContact_PlayerEditable, 5, 16);
		TableLayoutPanel1.Controls.Add(DarkLabel1, 3, 13);
		TableLayoutPanel1.Controls.Add(DarkLabel2, 3, 22);
		TableLayoutPanel1.Controls.Add(CB_Surface_Navigation_PlayerEditable, 5, 13);
		TableLayoutPanel1.Controls.Add(CB_Submarine_Navigation_PlayerEditable, 5, 22);
		TableLayoutPanel1.Controls.Add(Combo_Surface_Navigation, 4, 13);
		TableLayoutPanel1.Controls.Add(Combo_Submarine_Navigation, 4, 22);
		TableLayoutPanel1.Controls.Add(Combo_Land_Navigation, 1, 23);
		TableLayoutPanel1.Controls.Add(Label25, 0, 10);
		TableLayoutPanel1.Controls.Add(Label15, 0, 11);
		TableLayoutPanel1.Controls.Add(Label24, 0, 12);
		TableLayoutPanel1.Controls.Add(Label16, 0, 13);
		TableLayoutPanel1.Controls.Add(Label7, 0, 14);
		TableLayoutPanel1.Controls.Add(Combo_IgnoreEMCONunderAttack, 1, 11);
		TableLayoutPanel1.Controls.Add(Combo_UseKinematicRangeForTorpedoes, 1, 13);
		TableLayoutPanel1.Controls.Add(Combo_AutoEvade, 1, 14);
		TableLayoutPanel1.Controls.Add(Combo_UseRefuel, 1, 16);
		TableLayoutPanel1.Controls.Add(Combo_ReplenishmentSelection, 1, 17);
		TableLayoutPanel1.Controls.Add(Combo_RefuelAllies, 1, 18);
		TableLayoutPanel1.Controls.Add(CB_IgnoreEMCONunderAttack_PlayerEditable, 2, 11);
		TableLayoutPanel1.Controls.Add(CB_UseKinematicRangeForTorpedoes_PlayerEditable, 2, 13);
		TableLayoutPanel1.Controls.Add(CB_AutoEvade_PlayerEditable, 2, 14);
		TableLayoutPanel1.Controls.Add(Label10, 0, 16);
		TableLayoutPanel1.Controls.Add(Label51, 0, 17);
		TableLayoutPanel1.Controls.Add(Label33, 0, 18);
		TableLayoutPanel1.Controls.Add(CB_RefuelAllies_PlayerEditable, 2, 18);
		TableLayoutPanel1.Controls.Add(CB_ReplenishmentSelection_PlayerEditable, 2, 17);
		TableLayoutPanel1.Controls.Add(CB_UseRefuel_PlayerEditable, 2, 16);
		TableLayoutPanel1.Controls.Add(CB_BongoThreshold_PlayerEditable, 2, 19);
		TableLayoutPanel1.Controls.Add(DarkLabel8, 0, 19);
		TableLayoutPanel1.Controls.Add(DarkLabel3, 0, 22);
		TableLayoutPanel1.Controls.Add(DarkLabel4, 0, 23);
		TableLayoutPanel1.Controls.Add(CB_Land_Navigation_PlayerEditable, 2, 23);
		TableLayoutPanel1.Controls.Add(lblUseMissileWaypoints, 3, 14);
		TableLayoutPanel1.Controls.Add(Combo_UseWPMissilesOnASuW, 4, 14);
		TableLayoutPanel1.Controls.Add(CB_UseWPMissilesOnASuW, 5, 14);
		TableLayoutPanel1.Controls.Add(DarkLabel_7, 0, 15);
		TableLayoutPanel1.Dock = DockStyle.Top;
		TableLayoutPanel1.Location = new Point(3, 3);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 27;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.Size = new Size(994, 613);
		TableLayoutPanel1.TabIndex = 7;
		DarkLabel_5.AutoSize = true;
		DarkLabel_5.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_5.Location = new Point(0, 659);
		DarkLabel_5.Margin = new Padding(0, 9, 0, 0);
		DarkLabel_5.Name = "DarkLabel15";
		DarkLabel_5.Size = new Size(52, 11);
		DarkLabel_5.TabIndex = 79;
		DarkLabel_5.Text = "其它";
		DarkLabel_6.AutoSize = true;
		DarkLabel_6.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_6.Location = new Point(308, 659);
		DarkLabel_6.Margin = new Padding(0, 9, 0, 0);
		DarkLabel_6.Name = "DarkLabel14";
		DarkLabel_6.Size = new Size(52, 11);
		DarkLabel_6.TabIndex = 78;
		DarkLabel_6.Text = "其它";
		BingoThresholdCombo.BackColor = Color.Transparent;
		BingoThresholdCombo.Dock = DockStyle.Fill;
		BingoThresholdCombo.DrawMode = DrawMode.OwnerDrawFixed;
		BingoThresholdCombo.DropDownStyle = ComboBoxStyle.DropDownList;
		BingoThresholdCombo.Font = new Font("Segoe UI", 7f);
		BingoThresholdCombo.FormattingEnabled = true;
		BingoThresholdCombo.Items.AddRange(new object[7] { "30%", "40%", "50%", "60% (default)", "70%", "80%", "继承" });
		BingoThresholdCombo.Location = new Point(308, 478);
		BingoThresholdCombo.Margin = new Padding(0, 3, 0, 3);
		BingoThresholdCombo.Name = "BingoThresholdCombo";
		BingoThresholdCombo.Size = new Size(167, 27);
		BingoThresholdCombo.TabIndex = 72;
		Combo_WeaponControlStatus_Air.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Air.Dock = DockStyle.Fill;
		Combo_WeaponControlStatus_Air.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Air.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Air.DropDownWidth = 450;
		Combo_WeaponControlStatus_Air.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Air.FormattingEnabled = true;
		Combo_WeaponControlStatus_Air.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_WeaponControlStatus_Air.Location = new Point(308, 78);
		Combo_WeaponControlStatus_Air.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponControlStatus_Air.Name = "Combo_WeaponControlStatus_Air";
		Combo_WeaponControlStatus_Air.Size = new Size(167, 27);
		Combo_WeaponControlStatus_Air.TabIndex = 1;
		Combo_UseNukes.BackColor = Color.Transparent;
		Combo_UseNukes.Dock = DockStyle.Fill;
		Combo_UseNukes.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseNukes.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseNukes.DropDownWidth = 450;
		Combo_UseNukes.Font = new Font("Segoe UI", 7f);
		Combo_UseNukes.FormattingEnabled = true;
		Combo_UseNukes.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_UseNukes.Location = new Point(308, 28);
		Combo_UseNukes.Margin = new Padding(0, 3, 0, 3);
		Combo_UseNukes.Name = "Combo_UseNukes";
		Combo_UseNukes.Size = new Size(167, 27);
		Combo_UseNukes.TabIndex = 0;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(0, 206);
		Label5.Margin = new Padding(0, 6, 0, 0);
		Label5.Name = "Label5";
		Label5.Size = new Size(198, 19);
		Label5.TabIndex = 5;
		Label5.Text = "攻击位置不确定目标：";
		Combo_BehaviorTowardsAmbigousTarget.BackColor = Color.Transparent;
		Combo_BehaviorTowardsAmbigousTarget.Dock = DockStyle.Fill;
		Combo_BehaviorTowardsAmbigousTarget.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BehaviorTowardsAmbigousTarget.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BehaviorTowardsAmbigousTarget.Font = new Font("Segoe UI", 7f);
		Combo_BehaviorTowardsAmbigousTarget.FormattingEnabled = true;
		Combo_BehaviorTowardsAmbigousTarget.Items.AddRange(new object[4] { "忽略偏差", "乐观，位置不确定区域必须小于武器允许偏差范围3倍", "悲观，位置不确定区域必须小于武器允许偏差范围", "继承" });
		Combo_BehaviorTowardsAmbigousTarget.Location = new Point(308, 203);
		Combo_BehaviorTowardsAmbigousTarget.Margin = new Padding(0, 3, 0, 3);
		Combo_BehaviorTowardsAmbigousTarget.Name = "Combo_BehaviorTowardsAmbigousTarget";
		Combo_BehaviorTowardsAmbigousTarget.Size = new Size(167, 27);
		Combo_BehaviorTowardsAmbigousTarget.TabIndex = 6;
		Label19.AutoSize = true;
		Label19.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label19.ForeColor = Color.FromArgb(220, 220, 220);
		Label19.Location = new Point(0, 9);
		Label19.Margin = new Padding(0, 9, 0, 0);
		Label19.Name = "Label19";
		Label19.Size = new Size(91, 16);
		Label19.TabIndex = 28;
		Label19.Text = "战略武器";
		Label20.AutoSize = true;
		Label20.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label20.ForeColor = Color.FromArgb(220, 220, 220);
		Label20.Location = new Point(0, 59);
		Label20.Margin = new Padding(0, 9, 0, 0);
		Label20.Name = "Label20";
		Label20.Size = new Size(253, 16);
		Label20.TabIndex = 29;
		Label20.Text = "交战规则（RoE）";
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(0, 31);
		Label12.Margin = new Padding(0, 6, 0, 0);
		Label12.Name = "Label12";
		Label12.Size = new Size(160, 19);
		Label12.TabIndex = 4;
		Label12.Text = "使用核武器：";
		Combo_ShootTourists.BackColor = Color.Transparent;
		Combo_ShootTourists.Dock = DockStyle.Fill;
		Combo_ShootTourists.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_ShootTourists.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_ShootTourists.Font = new Font("Segoe UI", 7f);
		Combo_ShootTourists.FormattingEnabled = true;
		Combo_ShootTourists.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_ShootTourists.Location = new Point(308, 228);
		Combo_ShootTourists.Margin = new Padding(0, 3, 0, 3);
		Combo_ShootTourists.Name = "Combo_ShootTourists";
		Combo_ShootTourists.Size = new Size(167, 27);
		Combo_ShootTourists.TabIndex = 7;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 181);
		Label1.Margin = new Padding(0, 6, 0, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(270, 19);
		Label1.TabIndex = 35;
		Label1.Text = "攻击时忽略规划路线：";
		Combo_IgnorePlottedCourse.BackColor = Color.Transparent;
		Combo_IgnorePlottedCourse.Dock = DockStyle.Fill;
		Combo_IgnorePlottedCourse.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_IgnorePlottedCourse.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_IgnorePlottedCourse.Font = new Font("Segoe UI", 7f);
		Combo_IgnorePlottedCourse.FormattingEnabled = true;
		Combo_IgnorePlottedCourse.Location = new Point(308, 178);
		Combo_IgnorePlottedCourse.Margin = new Padding(0, 3, 0, 3);
		Combo_IgnorePlottedCourse.Name = "Combo_IgnorePlottedCourse";
		Combo_IgnorePlottedCourse.Size = new Size(167, 27);
		Combo_IgnorePlottedCourse.TabIndex = 5;
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(0, 81);
		Label13.Margin = new Padding(0, 6, 0, 0);
		Label13.Name = "Label13";
		Label13.Size = new Size(245, 19);
		Label13.TabIndex = 5;
		Label13.Text = "武器控制状态（WCS），空中：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(0, 106);
		Label2.Margin = new Padding(0, 6, 0, 0);
		Label2.Name = "Label2";
		Label2.Size = new Size(277, 19);
		Label2.TabIndex = 5;
		Label2.Text = "武器控制状态（WCS），水面：";
		Label23.AutoSize = true;
		Label23.ForeColor = Color.FromArgb(220, 220, 220);
		Label23.Location = new Point(0, 131);
		Label23.Margin = new Padding(0, 6, 0, 0);
		Label23.Name = "Label23";
		Label23.Size = new Size(308, 19);
		Label23.TabIndex = 5;
		Label23.Text = "武器控制状态（WCS），水下：";
		Label26.AutoSize = true;
		Label26.ForeColor = Color.FromArgb(220, 220, 220);
		Label26.Location = new Point(0, 156);
		Label26.Margin = new Padding(0, 6, 0, 0);
		Label26.Name = "Label26";
		Label26.Size = new Size(257, 19);
		Label26.TabIndex = 5;
		Label26.Text = "武器控制状态（WCS），地面：";
		Combo_WeaponControlStatus_Surface.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Surface.Dock = DockStyle.Fill;
		Combo_WeaponControlStatus_Surface.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Surface.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Surface.DropDownWidth = 450;
		Combo_WeaponControlStatus_Surface.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Surface.FormattingEnabled = true;
		Combo_WeaponControlStatus_Surface.Location = new Point(308, 103);
		Combo_WeaponControlStatus_Surface.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponControlStatus_Surface.Name = "Combo_WeaponControlStatus_Surface";
		Combo_WeaponControlStatus_Surface.Size = new Size(167, 27);
		Combo_WeaponControlStatus_Surface.TabIndex = 2;
		Combo_WeaponControlStatus_Submarine.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Submarine.Dock = DockStyle.Fill;
		Combo_WeaponControlStatus_Submarine.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Submarine.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Submarine.DropDownWidth = 450;
		Combo_WeaponControlStatus_Submarine.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Submarine.FormattingEnabled = true;
		Combo_WeaponControlStatus_Submarine.Location = new Point(308, 128);
		Combo_WeaponControlStatus_Submarine.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponControlStatus_Submarine.Name = "Combo_WeaponControlStatus_Submarine";
		Combo_WeaponControlStatus_Submarine.Size = new Size(167, 27);
		Combo_WeaponControlStatus_Submarine.TabIndex = 3;
		Combo_WeaponControlStatus_Land.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Land.Dock = DockStyle.Fill;
		Combo_WeaponControlStatus_Land.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Land.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Land.DropDownWidth = 450;
		Combo_WeaponControlStatus_Land.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Land.FormattingEnabled = true;
		Combo_WeaponControlStatus_Land.Location = new Point(308, 153);
		Combo_WeaponControlStatus_Land.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponControlStatus_Land.Name = "Combo_WeaponControlStatus_Land";
		Combo_WeaponControlStatus_Land.Size = new Size(167, 27);
		Combo_WeaponControlStatus_Land.TabIndex = 4;
		CB_UseNukes_PlayerEditable.Location = new Point(478, 31);
		CB_UseNukes_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_UseNukes_PlayerEditable.Name = "CB_UseNukes_PlayerEditable";
		CB_UseNukes_PlayerEditable.Size = new Size(15, 14);
		CB_UseNukes_PlayerEditable.TabIndex = 29;
		CB_WeaponControlStatus_Submarine_PlayerEditable.Location = new Point(478, 131);
		CB_WeaponControlStatus_Submarine_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponControlStatus_Submarine_PlayerEditable.Name = "CB_WeaponControlStatus_Submarine_PlayerEditable";
		CB_WeaponControlStatus_Submarine_PlayerEditable.Size = new Size(15, 14);
		CB_WeaponControlStatus_Submarine_PlayerEditable.TabIndex = 32;
		CB_WeaponControlStatus_Air_PlayerEditable.Location = new Point(478, 81);
		CB_WeaponControlStatus_Air_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponControlStatus_Air_PlayerEditable.Name = "CB_WeaponControlStatus_Air_PlayerEditable";
		CB_WeaponControlStatus_Air_PlayerEditable.Size = new Size(15, 14);
		CB_WeaponControlStatus_Air_PlayerEditable.TabIndex = 30;
		CB_WeaponControlStatus_Surface_PlayerEditable.Location = new Point(478, 106);
		CB_WeaponControlStatus_Surface_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponControlStatus_Surface_PlayerEditable.Name = "CB_WeaponControlStatus_Surface_PlayerEditable";
		CB_WeaponControlStatus_Surface_PlayerEditable.Size = new Size(15, 14);
		CB_WeaponControlStatus_Surface_PlayerEditable.TabIndex = 31;
		CB_WeaponControlStatus_Land_PlayerEditable.Location = new Point(478, 156);
		CB_WeaponControlStatus_Land_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponControlStatus_Land_PlayerEditable.Name = "CB_WeaponControlStatus_Land_PlayerEditable";
		CB_WeaponControlStatus_Land_PlayerEditable.Size = new Size(15, 14);
		CB_WeaponControlStatus_Land_PlayerEditable.TabIndex = 33;
		CB_IgnorePlottedCourse_PlayerEditable.Location = new Point(478, 181);
		CB_IgnorePlottedCourse_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_IgnorePlottedCourse_PlayerEditable.Name = "CB_IgnorePlottedCourse_PlayerEditable";
		CB_IgnorePlottedCourse_PlayerEditable.Size = new Size(15, 14);
		CB_IgnorePlottedCourse_PlayerEditable.TabIndex = 34;
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Location = new Point(478, 206);
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Name = "CB_BehaviorTowardsAmbigousTarget_PlayerEditable";
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Size = new Size(15, 14);
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.TabIndex = 35;
		Label22.AutoSize = true;
		TableLayoutPanel1.SetColumnSpan(Label22, 2);
		Label22.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label22.ForeColor = Color.FromArgb(220, 220, 220);
		Label22.Location = new Point(505, 9);
		Label22.Margin = new Padding(0, 9, 0, 0);
		Label22.Name = "Label22";
		Label22.Size = new Size(225, 16);
		Label22.TabIndex = 31;
		Label22.Text = "空中作战";
		Label18.AutoSize = true;
		Label18.ForeColor = Color.FromArgb(220, 220, 220);
		Label18.Location = new Point(505, 31);
		Label18.Margin = new Padding(0, 6, 0, 0);
		Label18.Name = "Label18";
		Label18.Size = new Size(164, 19);
		Label18.TabIndex = 27;
		Label18.Text = "空中作战强度：";
		Label17.AutoSize = true;
		Label17.ForeColor = Color.FromArgb(220, 220, 220);
		Label17.Location = new Point(505, 56);
		Label17.Margin = new Padding(0, 6, 0, 0);
		Label17.Name = "Label17";
		Label17.Size = new Size(136, 19);
		Label17.TabIndex = 27;
		Label17.Text = "快速再次出动：";
		CB_AirOpsTempo_PlayerEditable.Location = new Point(973, 31);
		CB_AirOpsTempo_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_AirOpsTempo_PlayerEditable.Name = "CB_AirOpsTempo_PlayerEditable";
		CB_AirOpsTempo_PlayerEditable.Size = new Size(17, 16);
		CB_AirOpsTempo_PlayerEditable.TabIndex = 42;
		CB_AirOpsTempo_PlayerEditable.Text = "参演方可编辑";
		CB_QuickTurnAroundForAicraft_PlayerEditable.Location = new Point(973, 56);
		CB_QuickTurnAroundForAicraft_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_QuickTurnAroundForAicraft_PlayerEditable.Name = "CB_QuickTurnAroundForAicraft_PlayerEditable";
		CB_QuickTurnAroundForAicraft_PlayerEditable.Size = new Size(17, 16);
		CB_QuickTurnAroundForAicraft_PlayerEditable.TabIndex = 43;
		CB_QuickTurnAroundForAicraft_PlayerEditable.Text = "参演方可编辑";
		Label28.AutoSize = true;
		Label28.ForeColor = Color.FromArgb(220, 220, 220);
		Label28.Location = new Point(505, 81);
		Label28.Margin = new Padding(0, 6, 0, 0);
		Label28.Name = "Label28";
		Label28.Size = new Size(172, 19);
		Label28.TabIndex = 5;
		Label28.Text = "燃料状态，预先计划：";
		Combo_AirOpsTempo.BackColor = Color.Transparent;
		Combo_AirOpsTempo.Dock = DockStyle.Fill;
		Combo_AirOpsTempo.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AirOpsTempo.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AirOpsTempo.Font = new Font("Segoe UI", 7f);
		Combo_AirOpsTempo.FormattingEnabled = true;
		Combo_AirOpsTempo.Items.AddRange(new object[2] { "高强度", "一般强度" });
		Combo_AirOpsTempo.Location = new Point(803, 28);
		Combo_AirOpsTempo.Margin = new Padding(0, 3, 0, 3);
		Combo_AirOpsTempo.Name = "Combo_AirOpsTempo";
		Combo_AirOpsTempo.Size = new Size(167, 27);
		Combo_AirOpsTempo.TabIndex = 13;
		Combo_QuickTurnAroundForAicraft.BackColor = Color.Transparent;
		Combo_QuickTurnAroundForAicraft.Dock = DockStyle.Fill;
		Combo_QuickTurnAroundForAicraft.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_QuickTurnAroundForAicraft.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_QuickTurnAroundForAicraft.Font = new Font("Segoe UI", 7f);
		Combo_QuickTurnAroundForAicraft.FormattingEnabled = true;
		Combo_QuickTurnAroundForAicraft.Items.AddRange(new object[4] { "是", "战斗机 & 空地武器", "否", "继承" });
		Combo_QuickTurnAroundForAicraft.Location = new Point(803, 53);
		Combo_QuickTurnAroundForAicraft.Margin = new Padding(0, 3, 0, 3);
		Combo_QuickTurnAroundForAicraft.Name = "Combo_QuickTurnAroundForAicraft";
		Combo_QuickTurnAroundForAicraft.Size = new Size(167, 27);
		Combo_QuickTurnAroundForAicraft.TabIndex = 14;
		Label30.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label30.AutoSize = true;
		TableLayoutPanel1.SetColumnSpan(Label30, 2);
		Label30.ForeColor = Color.FromArgb(220, 220, 220);
		Label30.Location = new Point(308, 6);
		Label30.Margin = new Padding(0, 6, 0, 0);
		Label30.Name = "Label30";
		Label30.RightToLeft = RightToLeft.No;
		Label30.Size = new Size(197, 19);
		Label30.TabIndex = 58;
		Label30.Text = " 提示：用勾选框设置条令是否可由用户编辑：";
		Combo_FuelState.BackColor = Color.Transparent;
		Combo_FuelState.Dock = DockStyle.Fill;
		Combo_FuelState.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_FuelState.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_FuelState.DropDownWidth = 550;
		Combo_FuelState.Font = new Font("Segoe UI", 7f);
		Combo_FuelState.FormattingEnabled = true;
		Combo_FuelState.Location = new Point(803, 78);
		Combo_FuelState.Margin = new Padding(0, 3, 0, 3);
		Combo_FuelState.Name = "Combo_FuelState";
		Combo_FuelState.Size = new Size(167, 27);
		Combo_FuelState.TabIndex = 15;
		CB_FuelState_PlayerEditable.Location = new Point(973, 81);
		CB_FuelState_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_FuelState_PlayerEditable.Name = "CB_FuelState_PlayerEditable";
		CB_FuelState_PlayerEditable.Size = new Size(17, 16);
		CB_FuelState_PlayerEditable.TabIndex = 44;
		CB_FuelState_PlayerEditable.Text = "参演方可编辑";
		Combo_Standoff.BackColor = Color.Transparent;
		Combo_Standoff.Dock = DockStyle.Fill;
		Combo_Standoff.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Standoff.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Standoff.Font = new Font("Segoe UI", 7f);
		Combo_Standoff.FormattingEnabled = true;
		Combo_Standoff.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_Standoff.Location = new Point(803, 303);
		Combo_Standoff.Margin = new Padding(0, 3, 0, 3);
		Combo_Standoff.Name = "Combo_Standoff";
		Combo_Standoff.Size = new Size(167, 27);
		Combo_Standoff.TabIndex = 22;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(505, 306);
		Label6.Margin = new Padding(0, 6, 0, 0);
		Label6.Name = "Label6";
		Label6.Size = new Size(198, 19);
		Label6.TabIndex = 11;
		Label6.Text = "保持与目标对峙：";
		Label14.AutoSize = true;
		Label14.ForeColor = Color.FromArgb(220, 220, 220);
		Label14.Location = new Point(505, 281);
		Label14.Margin = new Padding(0, 6, 0, 0);
		Label14.Name = "Label14";
		Label14.Size = new Size(191, 19);
		Label14.TabIndex = 21;
		Label14.Text = "反水面战（ASuW）中使用地空导弹SAM：";
		Combo_UseSAMsOnASuW.BackColor = Color.Transparent;
		Combo_UseSAMsOnASuW.Dock = DockStyle.Fill;
		Combo_UseSAMsOnASuW.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseSAMsOnASuW.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseSAMsOnASuW.Font = new Font("Segoe UI", 7f);
		Combo_UseSAMsOnASuW.FormattingEnabled = true;
		Combo_UseSAMsOnASuW.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_UseSAMsOnASuW.Location = new Point(803, 278);
		Combo_UseSAMsOnASuW.Margin = new Padding(0, 3, 0, 3);
		Combo_UseSAMsOnASuW.Name = "Combo_UseSAMsOnASuW";
		Combo_UseSAMsOnASuW.Size = new Size(167, 27);
		Combo_UseSAMsOnASuW.TabIndex = 21;
		CB_Standoff_PlayerEditable.Location = new Point(973, 306);
		CB_Standoff_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_Standoff_PlayerEditable.Name = "CB_Standoff_PlayerEditable";
		CB_Standoff_PlayerEditable.Size = new Size(17, 16);
		CB_Standoff_PlayerEditable.TabIndex = 51;
		CB_Standoff_PlayerEditable.Text = "参演方可编辑";
		CB_UseSAMsOnASuW_PlayerEditable.Location = new Point(973, 281);
		CB_UseSAMsOnASuW_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_UseSAMsOnASuW_PlayerEditable.Name = "CB_UseSAMsOnASuW_PlayerEditable";
		CB_UseSAMsOnASuW_PlayerEditable.Size = new Size(17, 16);
		CB_UseSAMsOnASuW_PlayerEditable.TabIndex = 50;
		CB_UseSAMsOnASuW_PlayerEditable.Text = "参演方可编辑";
		Label21.AutoSize = true;
		TableLayoutPanel1.SetColumnSpan(Label21, 2);
		Label21.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label21.ForeColor = Color.FromArgb(220, 220, 220);
		Label21.Location = new Point(505, 259);
		Label21.Margin = new Padding(0, 9, 0, 0);
		Label21.Name = "Label21";
		Label21.Size = new Size(274, 16);
		Label21.TabIndex = 30;
		Label21.Text = "反水面战（ASuW）";
		Label27.AutoSize = true;
		Label27.ForeColor = Color.FromArgb(220, 220, 220);
		Label27.Location = new Point(505, 181);
		Label27.Margin = new Padding(0, 6, 0, 0);
		Label27.Name = "Label27";
		Label27.Size = new Size(138, 19);
		Label27.TabIndex = 5;
		Label27.Text = "空对地扫射（航炮）：";
		Combo_GunStrafing.BackColor = Color.Transparent;
		Combo_GunStrafing.Dock = DockStyle.Fill;
		Combo_GunStrafing.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_GunStrafing.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_GunStrafing.Font = new Font("Segoe UI", 7f);
		Combo_GunStrafing.FormattingEnabled = true;
		Combo_GunStrafing.Location = new Point(803, 178);
		Combo_GunStrafing.Margin = new Padding(0, 3, 0, 3);
		Combo_GunStrafing.Name = "Combo_GunStrafing";
		Combo_GunStrafing.Size = new Size(167, 27);
		Combo_GunStrafing.TabIndex = 19;
		CB_GunStrafing_PlayerEditable.Location = new Point(973, 181);
		CB_GunStrafing_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_GunStrafing_PlayerEditable.Name = "CB_GunStrafing_PlayerEditable";
		CB_GunStrafing_PlayerEditable.Size = new Size(17, 16);
		CB_GunStrafing_PlayerEditable.TabIndex = 48;
		CB_GunStrafing_PlayerEditable.Text = "参演方可编辑";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(505, 156);
		Label4.Margin = new Padding(0, 6, 0, 0);
		Label4.Name = "Label4";
		Label4.Size = new Size(138, 19);
		Label4.TabIndex = 5;
		Label4.Text = "武器状态，返回基地：";
		Combo_WeaponStateRTB.BackColor = Color.Transparent;
		Combo_WeaponStateRTB.Dock = DockStyle.Fill;
		Combo_WeaponStateRTB.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponStateRTB.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponStateRTB.DropDownWidth = 550;
		Combo_WeaponStateRTB.Font = new Font("Segoe UI", 7f);
		Combo_WeaponStateRTB.FormattingEnabled = true;
		Combo_WeaponStateRTB.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_WeaponStateRTB.Location = new Point(803, 153);
		Combo_WeaponStateRTB.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponStateRTB.Name = "Combo_WeaponStateRTB";
		Combo_WeaponStateRTB.Size = new Size(167, 27);
		Combo_WeaponStateRTB.TabIndex = 18;
		CB_WeaponStateRTB_PlayerEditable.Location = new Point(973, 156);
		CB_WeaponStateRTB_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponStateRTB_PlayerEditable.Name = "CB_WeaponStateRTB_PlayerEditable";
		CB_WeaponStateRTB_PlayerEditable.Size = new Size(17, 16);
		CB_WeaponStateRTB_PlayerEditable.TabIndex = 47;
		CB_WeaponStateRTB_PlayerEditable.Text = "参演方可编辑";
		Label29.AutoSize = true;
		Label29.ForeColor = Color.FromArgb(220, 220, 220);
		Label29.Location = new Point(505, 131);
		Label29.Margin = new Padding(0, 6, 0, 0);
		Label29.Name = "Label29";
		Label29.Size = new Size(200, 19);
		Label29.TabIndex = 5;
		Label29.Text = "武器状态，预先规划：";
		Combo_WeaponState.BackColor = Color.Transparent;
		Combo_WeaponState.Dock = DockStyle.Fill;
		Combo_WeaponState.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponState.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponState.DropDownWidth = 750;
		Combo_WeaponState.Font = new Font("Segoe UI", 7f);
		Combo_WeaponState.FormattingEnabled = true;
		Combo_WeaponState.Location = new Point(803, 128);
		Combo_WeaponState.Margin = new Padding(0, 3, 0, 3);
		Combo_WeaponState.Name = "Combo_WeaponState";
		Combo_WeaponState.Size = new Size(167, 27);
		Combo_WeaponState.TabIndex = 17;
		CB_WeaponState_PlayerEditable.Location = new Point(973, 131);
		CB_WeaponState_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_WeaponState_PlayerEditable.Name = "CB_WeaponState_PlayerEditable";
		CB_WeaponState_PlayerEditable.Size = new Size(17, 16);
		CB_WeaponState_PlayerEditable.TabIndex = 46;
		CB_WeaponState_PlayerEditable.Text = "参演方可编辑";
		Combo_Jettison.BackColor = Color.Transparent;
		Combo_Jettison.Dock = DockStyle.Fill;
		Combo_Jettison.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Jettison.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Jettison.Font = new Font("Segoe UI", 7f);
		Combo_Jettison.FormattingEnabled = true;
		Combo_Jettison.Location = new Point(803, 203);
		Combo_Jettison.Margin = new Padding(0, 3, 0, 3);
		Combo_Jettison.Name = "Combo_Jettison";
		Combo_Jettison.Size = new Size(167, 27);
		Combo_Jettison.TabIndex = 20;
		Label31.AutoSize = true;
		Label31.ForeColor = Color.FromArgb(220, 220, 220);
		Label31.Location = new Point(505, 206);
		Label31.Margin = new Padding(0, 6, 0, 0);
		Label31.Name = "Label31";
		Label31.Size = new Size(138, 19);
		Label31.TabIndex = 5;
		Label31.Text = "丢弃军械：";
		CB_JettisonOrdnance_PlayerEditable.Location = new Point(973, 206);
		CB_JettisonOrdnance_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_JettisonOrdnance_PlayerEditable.Name = "CB_JettisonOrdnance_PlayerEditable";
		CB_JettisonOrdnance_PlayerEditable.Size = new Size(17, 16);
		CB_JettisonOrdnance_PlayerEditable.TabIndex = 49;
		CB_JettisonOrdnance_PlayerEditable.Text = "参演方可编辑";
		CB_FuelStateRTB_PlayerEditable.Location = new Point(973, 106);
		CB_FuelStateRTB_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_FuelStateRTB_PlayerEditable.Name = "CB_FuelStateRTB_PlayerEditable";
		CB_FuelStateRTB_PlayerEditable.Size = new Size(17, 16);
		CB_FuelStateRTB_PlayerEditable.TabIndex = 45;
		CB_FuelStateRTB_PlayerEditable.Text = "参演方可编辑";
		Combo_FuelStateRTB.BackColor = Color.Transparent;
		Combo_FuelStateRTB.Dock = DockStyle.Fill;
		Combo_FuelStateRTB.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_FuelStateRTB.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_FuelStateRTB.DropDownWidth = 550;
		Combo_FuelStateRTB.Font = new Font("Segoe UI", 7f);
		Combo_FuelStateRTB.FormattingEnabled = true;
		Combo_FuelStateRTB.Location = new Point(803, 103);
		Combo_FuelStateRTB.Margin = new Padding(0, 3, 0, 3);
		Combo_FuelStateRTB.Name = "Combo_FuelStateRTB";
		Combo_FuelStateRTB.Size = new Size(167, 27);
		Combo_FuelStateRTB.TabIndex = 16;
		Label32.AutoSize = true;
		Label32.ForeColor = Color.FromArgb(220, 220, 220);
		Label32.Location = new Point(505, 106);
		Label32.Margin = new Padding(0, 6, 0, 0);
		Label32.Name = "Label32";
		Label32.Size = new Size(110, 19);
		Label32.TabIndex = 5;
		Label32.Text = "燃料状态，返回基地：";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(0, 231);
		Label11.Margin = new Padding(0, 6, 0, 0);
		Label11.Name = "Label11";
		Label11.Size = new Size(202, 19);
		Label11.TabIndex = 19;
		Label11.Text = "攻击合适目标：";
		CB_ShootTourists_PlayerEditable.Location = new Point(478, 231);
		CB_ShootTourists_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_ShootTourists_PlayerEditable.Name = "CB_ShootTourists_PlayerEditable";
		CB_ShootTourists_PlayerEditable.Size = new Size(15, 14);
		CB_ShootTourists_PlayerEditable.TabIndex = 36;
		Label52.AutoSize = true;
		Label52.ForeColor = Color.FromArgb(220, 220, 220);
		Label52.Location = new Point(505, 231);
		Label52.Margin = new Padding(0, 6, 0, 0);
		Label52.Name = "Label52";
		Label52.Size = new Size(170, 19);
		Label52.TabIndex = 5;
		Label52.Text = "超视距BVR交战逻辑：";
		CB_BVRLogic_PlayerEditable.Location = new Point(973, 231);
		CB_BVRLogic_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_BVRLogic_PlayerEditable.Name = "CB_BVRLogic_PlayerEditable";
		CB_BVRLogic_PlayerEditable.Size = new Size(17, 16);
		CB_BVRLogic_PlayerEditable.TabIndex = 49;
		CB_BVRLogic_PlayerEditable.Text = "参演方可编辑";
		Combo_BVRLogic.BackColor = Color.Transparent;
		Combo_BVRLogic.Dock = DockStyle.Fill;
		Combo_BVRLogic.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BVRLogic.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BVRLogic.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_BVRLogic.FormattingEnabled = true;
		Combo_BVRLogic.Location = new Point(803, 228);
		Combo_BVRLogic.Margin = new Padding(0, 3, 0, 3);
		Combo_BVRLogic.Name = "Combo_BVRLogic";
		Combo_BVRLogic.Size = new Size(167, 27);
		Combo_BVRLogic.TabIndex = 59;
		Label40.AutoSize = true;
		Label40.ForeColor = Color.FromArgb(220, 220, 220);
		Label40.Location = new Point(505, 531);
		Label40.Margin = new Padding(0, 6, 0, 0);
		Label40.Name = "Label40";
		Label40.Size = new Size(111, 19);
		Label40.TabIndex = 11;
		Label40.Text = "浸入声纳：";
		CB_DippingSonar_PlayerEditable.Location = new Point(973, 531);
		CB_DippingSonar_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_DippingSonar_PlayerEditable.Name = "CB_DippingSonar_PlayerEditable";
		CB_DippingSonar_PlayerEditable.Size = new Size(17, 16);
		CB_DippingSonar_PlayerEditable.TabIndex = 57;
		CB_DippingSonar_PlayerEditable.Text = "参演方可编辑";
		Combo_DippingSonar.BackColor = Color.Transparent;
		Combo_DippingSonar.Dock = DockStyle.Fill;
		Combo_DippingSonar.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_DippingSonar.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_DippingSonar.DropDownWidth = 450;
		Combo_DippingSonar.Font = new Font("Segoe UI", 7f);
		Combo_DippingSonar.FormattingEnabled = true;
		Combo_DippingSonar.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_DippingSonar.Location = new Point(803, 528);
		Combo_DippingSonar.Margin = new Padding(0, 3, 0, 3);
		Combo_DippingSonar.Name = "Combo_DippingSonar";
		Combo_DippingSonar.Size = new Size(167, 27);
		Combo_DippingSonar.TabIndex = 28;
		Label39.AutoSize = true;
		Label39.ForeColor = Color.FromArgb(220, 220, 220);
		Label39.Location = new Point(505, 506);
		Label39.Margin = new Padding(0, 6, 0, 0);
		Label39.Name = "Label39";
		Label39.Size = new Size(287, 19);
		Label39.TabIndex = 11;
		Label39.Text = "不依赖空气推进（AIP）用法：";
		Label38.AutoSize = true;
		Label38.ForeColor = Color.FromArgb(220, 220, 220);
		Label38.Location = new Point(505, 481);
		Label38.Margin = new Padding(0, 6, 0, 0);
		Label38.Name = "Label38";
		Label38.Size = new Size(298, 19);
		Label38.TabIndex = 11;
		Label38.Text = "电池充电 %, 进攻/防御：";
		Label37.AutoSize = true;
		Label37.ForeColor = Color.FromArgb(220, 220, 220);
		Label37.Location = new Point(505, 456);
		Label37.Margin = new Padding(0, 6, 0, 0);
		Label37.Name = "Label37";
		Label37.Size = new Size(260, 19);
		Label37.TabIndex = 11;
		Label37.Text = "电池充电 %，出航/巡逻：";
		Label36.AutoSize = true;
		Label36.ForeColor = Color.FromArgb(220, 220, 220);
		Label36.Location = new Point(505, 431);
		Label36.Margin = new Padding(0, 6, 0, 0);
		Label36.Name = "Label36";
		Label36.Size = new Size(209, 19);
		Label36.TabIndex = 11;
		Label36.Text = "探测到威胁时潜水：";
		Label35.AutoSize = true;
		Label35.ForeColor = Color.FromArgb(220, 220, 220);
		Label35.Location = new Point(505, 406);
		Label35.Margin = new Padding(0, 6, 0, 0);
		Label35.Name = "Label35";
		Label35.Size = new Size(107, 19);
		Label35.TabIndex = 11;
		Label35.Text = "避免目标：";
		Label34.AutoSize = true;
		Label34.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label34.ForeColor = Color.FromArgb(220, 220, 220);
		Label34.Location = new Point(505, 384);
		Label34.Margin = new Padding(0, 9, 0, 0);
		Label34.Name = "Label34";
		Label34.Size = new Size(292, 16);
		Label34.TabIndex = 30;
		Label34.Text = "反潜战（ASW）";
		Combo_AIP_Usage.BackColor = Color.Transparent;
		Combo_AIP_Usage.Dock = DockStyle.Fill;
		Combo_AIP_Usage.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AIP_Usage.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AIP_Usage.DropDownWidth = 450;
		Combo_AIP_Usage.Font = new Font("Segoe UI", 7f);
		Combo_AIP_Usage.FormattingEnabled = true;
		Combo_AIP_Usage.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_AIP_Usage.Location = new Point(803, 503);
		Combo_AIP_Usage.Margin = new Padding(0, 3, 0, 3);
		Combo_AIP_Usage.Name = "Combo_AIP_Usage";
		Combo_AIP_Usage.Size = new Size(167, 27);
		Combo_AIP_Usage.TabIndex = 27;
		Combo_BatteryRechargeAttack.BackColor = Color.Transparent;
		Combo_BatteryRechargeAttack.Dock = DockStyle.Fill;
		Combo_BatteryRechargeAttack.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BatteryRechargeAttack.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BatteryRechargeAttack.Font = new Font("Segoe UI", 7f);
		Combo_BatteryRechargeAttack.FormattingEnabled = true;
		Combo_BatteryRechargeAttack.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_BatteryRechargeAttack.Location = new Point(803, 478);
		Combo_BatteryRechargeAttack.Margin = new Padding(0, 3, 0, 3);
		Combo_BatteryRechargeAttack.Name = "Combo_BatteryRechargeAttack";
		Combo_BatteryRechargeAttack.Size = new Size(167, 27);
		Combo_BatteryRechargeAttack.TabIndex = 26;
		Combo_BatteryRechargePatrol.BackColor = Color.Transparent;
		Combo_BatteryRechargePatrol.Dock = DockStyle.Fill;
		Combo_BatteryRechargePatrol.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BatteryRechargePatrol.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BatteryRechargePatrol.Font = new Font("Segoe UI", 7f);
		Combo_BatteryRechargePatrol.FormattingEnabled = true;
		Combo_BatteryRechargePatrol.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_BatteryRechargePatrol.Location = new Point(803, 453);
		Combo_BatteryRechargePatrol.Margin = new Padding(0, 3, 0, 3);
		Combo_BatteryRechargePatrol.Name = "Combo_BatteryRechargePatrol";
		Combo_BatteryRechargePatrol.Size = new Size(167, 27);
		Combo_BatteryRechargePatrol.TabIndex = 25;
		Combo_DiveWhenThreatsDetected.BackColor = Color.Transparent;
		Combo_DiveWhenThreatsDetected.Dock = DockStyle.Fill;
		Combo_DiveWhenThreatsDetected.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_DiveWhenThreatsDetected.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_DiveWhenThreatsDetected.DropDownWidth = 450;
		Combo_DiveWhenThreatsDetected.Font = new Font("Segoe UI", 7f);
		Combo_DiveWhenThreatsDetected.FormattingEnabled = true;
		Combo_DiveWhenThreatsDetected.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_DiveWhenThreatsDetected.Location = new Point(803, 428);
		Combo_DiveWhenThreatsDetected.Margin = new Padding(0, 3, 0, 3);
		Combo_DiveWhenThreatsDetected.Name = "Combo_DiveWhenThreatsDetected";
		Combo_DiveWhenThreatsDetected.Size = new Size(167, 27);
		Combo_DiveWhenThreatsDetected.TabIndex = 24;
		Combo_AvoidContact.BackColor = Color.Transparent;
		Combo_AvoidContact.Dock = DockStyle.Fill;
		Combo_AvoidContact.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AvoidContact.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AvoidContact.Font = new Font("Segoe UI", 7f);
		Combo_AvoidContact.FormattingEnabled = true;
		Combo_AvoidContact.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_AvoidContact.Location = new Point(803, 403);
		Combo_AvoidContact.Margin = new Padding(0, 3, 0, 3);
		Combo_AvoidContact.Name = "Combo_AvoidContact";
		Combo_AvoidContact.Size = new Size(167, 27);
		Combo_AvoidContact.TabIndex = 23;
		CB_AIP_Usage_PlayerEditable.Location = new Point(973, 506);
		CB_AIP_Usage_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_AIP_Usage_PlayerEditable.Name = "CB_AIP_Usage_PlayerEditable";
		CB_AIP_Usage_PlayerEditable.Size = new Size(17, 16);
		CB_AIP_Usage_PlayerEditable.TabIndex = 56;
		CB_AIP_Usage_PlayerEditable.Text = "参演方可编辑";
		CB_BatteryRechargeAttack_PlayerEditable.Location = new Point(973, 481);
		CB_BatteryRechargeAttack_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_BatteryRechargeAttack_PlayerEditable.Name = "CB_BatteryRechargeAttack_PlayerEditable";
		CB_BatteryRechargeAttack_PlayerEditable.Size = new Size(17, 16);
		CB_BatteryRechargeAttack_PlayerEditable.TabIndex = 55;
		CB_BatteryRechargeAttack_PlayerEditable.Text = "参演方可编辑";
		CB_BatteryRechargePatrol_PlayerEditable.Location = new Point(973, 456);
		CB_BatteryRechargePatrol_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_BatteryRechargePatrol_PlayerEditable.Name = "CB_BatteryRechargePatrol_PlayerEditable";
		CB_BatteryRechargePatrol_PlayerEditable.Size = new Size(17, 16);
		CB_BatteryRechargePatrol_PlayerEditable.TabIndex = 54;
		CB_BatteryRechargePatrol_PlayerEditable.Text = "参演方可编辑";
		CB_DiveWhenThreatsDetected_PlayerEditable.Location = new Point(973, 431);
		CB_DiveWhenThreatsDetected_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_DiveWhenThreatsDetected_PlayerEditable.Name = "CB_DiveWhenThreatsDetected_PlayerEditable";
		CB_DiveWhenThreatsDetected_PlayerEditable.Size = new Size(17, 16);
		CB_DiveWhenThreatsDetected_PlayerEditable.TabIndex = 53;
		CB_DiveWhenThreatsDetected_PlayerEditable.Text = "参演方可编辑";
		CB_AvoidContact_PlayerEditable.Location = new Point(973, 406);
		CB_AvoidContact_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_AvoidContact_PlayerEditable.Name = "CB_AvoidContact_PlayerEditable";
		CB_AvoidContact_PlayerEditable.Size = new Size(17, 16);
		CB_AvoidContact_PlayerEditable.TabIndex = 52;
		CB_AvoidContact_PlayerEditable.Text = "参演方可编辑";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(505, 331);
		DarkLabel1.Margin = new Padding(0, 6, 0, 0);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(89, 19);
		DarkLabel1.TabIndex = 60;
		DarkLabel1.Text = "导航：";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(505, 556);
		DarkLabel2.Margin = new Padding(0, 6, 0, 0);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(89, 19);
		DarkLabel2.TabIndex = 61;
		DarkLabel2.Text = "导航：";
		CB_Surface_Navigation_PlayerEditable.AutoSize = true;
		CB_Surface_Navigation_PlayerEditable.Location = new Point(973, 331);
		CB_Surface_Navigation_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_Surface_Navigation_PlayerEditable.Name = "CB_Surface_Navigation_PlayerEditable";
		CB_Surface_Navigation_PlayerEditable.Size = new Size(18, 16);
		CB_Surface_Navigation_PlayerEditable.TabIndex = 64;
		CB_Surface_Navigation_PlayerEditable.Text = "DarkCheckBox1";
		CB_Submarine_Navigation_PlayerEditable.AutoSize = true;
		CB_Submarine_Navigation_PlayerEditable.Location = new Point(973, 556);
		CB_Submarine_Navigation_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_Submarine_Navigation_PlayerEditable.Name = "CB_Submarine_Navigation_PlayerEditable";
		CB_Submarine_Navigation_PlayerEditable.Size = new Size(18, 16);
		CB_Submarine_Navigation_PlayerEditable.TabIndex = 65;
		CB_Submarine_Navigation_PlayerEditable.Text = "DarkCheckBox2";
		Combo_Surface_Navigation.BackColor = Color.Transparent;
		Combo_Surface_Navigation.Dock = DockStyle.Fill;
		Combo_Surface_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Surface_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Surface_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Surface_Navigation.FormattingEnabled = true;
		Combo_Surface_Navigation.Location = new Point(803, 328);
		Combo_Surface_Navigation.Margin = new Padding(0, 3, 0, 3);
		Combo_Surface_Navigation.Name = "Combo_Surface_Navigation";
		Combo_Surface_Navigation.Size = new Size(167, 27);
		Combo_Surface_Navigation.TabIndex = 67;
		Combo_Submarine_Navigation.BackColor = Color.Transparent;
		Combo_Submarine_Navigation.Dock = DockStyle.Fill;
		Combo_Submarine_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Submarine_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Submarine_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Submarine_Navigation.FormattingEnabled = true;
		Combo_Submarine_Navigation.Location = new Point(803, 553);
		Combo_Submarine_Navigation.Margin = new Padding(0, 3, 0, 3);
		Combo_Submarine_Navigation.Name = "Combo_Submarine_Navigation";
		Combo_Submarine_Navigation.Size = new Size(167, 27);
		Combo_Submarine_Navigation.TabIndex = 68;
		Combo_Land_Navigation.BackColor = Color.Transparent;
		Combo_Land_Navigation.Dock = DockStyle.Fill;
		Combo_Land_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Land_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Land_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Land_Navigation.FormattingEnabled = true;
		Combo_Land_Navigation.Location = new Point(308, 578);
		Combo_Land_Navigation.Margin = new Padding(0, 3, 0, 3);
		Combo_Land_Navigation.Name = "Combo_Land_Navigation";
		Combo_Land_Navigation.Size = new Size(167, 27);
		Combo_Land_Navigation.TabIndex = 69;
		Label25.AutoSize = true;
		Label25.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label25.ForeColor = Color.FromArgb(220, 220, 220);
		Label25.Location = new Point(0, 259);
		Label25.Margin = new Padding(0, 9, 0, 0);
		Label25.Name = "Label25";
		Label25.Size = new Size(250, 16);
		Label25.TabIndex = 34;
		Label25.Text = "电磁管控（EMCON）";
		Label15.AutoSize = true;
		Label15.ForeColor = Color.FromArgb(220, 220, 220);
		Label15.Location = new Point(0, 281);
		Label15.Margin = new Padding(0, 6, 0, 0);
		Label15.Name = "Label15";
		Label15.Size = new Size(249, 19);
		Label15.TabIndex = 25;
		Label15.Text = "在受到攻击时忽略电磁管控规则EMCON：";
		Label24.AutoSize = true;
		Label24.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		Label24.ForeColor = Color.FromArgb(220, 220, 220);
		Label24.Location = new Point(0, 309);
		Label24.Margin = new Padding(0, 9, 0, 0);
		Label24.Name = "Label24";
		Label24.Size = new Size(52, 16);
		Label24.TabIndex = 33;
		Label24.Text = "其它";
		Label16.AutoSize = true;
		Label16.ForeColor = Color.FromArgb(220, 220, 220);
		Label16.Location = new Point(0, 331);
		Label16.Margin = new Padding(0, 6, 0, 0);
		Label16.Name = "Label16";
		Label16.Size = new Size(223, 19);
		Label16.TabIndex = 26;
		Label16.Text = "鱼雷发射距离：";
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(0, 356);
		Label7.Margin = new Padding(0, 6, 0, 0);
		Label7.Name = "Label7";
		Label7.Size = new Size(141, 19);
		Label7.TabIndex = 7;
		Label7.Text = "自动规避：";
		Combo_IgnoreEMCONunderAttack.BackColor = Color.Transparent;
		Combo_IgnoreEMCONunderAttack.Dock = DockStyle.Fill;
		Combo_IgnoreEMCONunderAttack.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_IgnoreEMCONunderAttack.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_IgnoreEMCONunderAttack.Font = new Font("Segoe UI", 7f);
		Combo_IgnoreEMCONunderAttack.FormattingEnabled = true;
		Combo_IgnoreEMCONunderAttack.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_IgnoreEMCONunderAttack.Location = new Point(308, 278);
		Combo_IgnoreEMCONunderAttack.Margin = new Padding(0, 3, 0, 3);
		Combo_IgnoreEMCONunderAttack.Name = "Combo_IgnoreEMCONunderAttack";
		Combo_IgnoreEMCONunderAttack.Size = new Size(167, 27);
		Combo_IgnoreEMCONunderAttack.TabIndex = 8;
		Combo_UseKinematicRangeForTorpedoes.BackColor = Color.Transparent;
		Combo_UseKinematicRangeForTorpedoes.Dock = DockStyle.Fill;
		Combo_UseKinematicRangeForTorpedoes.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseKinematicRangeForTorpedoes.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseKinematicRangeForTorpedoes.Font = new Font("Segoe UI", 7f);
		Combo_UseKinematicRangeForTorpedoes.FormattingEnabled = true;
		Combo_UseKinematicRangeForTorpedoes.Items.AddRange(new object[4] { "自动和手动攻击均在最大动力范围发射", "仅手动攻击在最大动力范围发射", "否", "继承" });
		Combo_UseKinematicRangeForTorpedoes.Location = new Point(308, 328);
		Combo_UseKinematicRangeForTorpedoes.Margin = new Padding(0, 3, 0, 3);
		Combo_UseKinematicRangeForTorpedoes.Name = "Combo_UseKinematicRangeForTorpedoes";
		Combo_UseKinematicRangeForTorpedoes.Size = new Size(167, 27);
		Combo_UseKinematicRangeForTorpedoes.TabIndex = 9;
		Combo_AutoEvade.BackColor = Color.Transparent;
		Combo_AutoEvade.Dock = DockStyle.Fill;
		Combo_AutoEvade.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AutoEvade.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AutoEvade.Font = new Font("Segoe UI", 7f);
		Combo_AutoEvade.FormattingEnabled = true;
		Combo_AutoEvade.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_AutoEvade.Location = new Point(308, 353);
		Combo_AutoEvade.Margin = new Padding(0, 3, 0, 3);
		Combo_AutoEvade.Name = "Combo_AutoEvade";
		Combo_AutoEvade.Size = new Size(167, 27);
		Combo_AutoEvade.TabIndex = 10;
		Combo_UseRefuel.BackColor = Color.Transparent;
		Combo_UseRefuel.Dock = DockStyle.Fill;
		Combo_UseRefuel.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseRefuel.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseRefuel.DropDownWidth = 450;
		Combo_UseRefuel.Font = new Font("Segoe UI", 7f);
		Combo_UseRefuel.FormattingEnabled = true;
		Combo_UseRefuel.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_UseRefuel.Location = new Point(308, 403);
		Combo_UseRefuel.Margin = new Padding(0, 3, 0, 3);
		Combo_UseRefuel.Name = "Combo_UseRefuel";
		Combo_UseRefuel.Size = new Size(167, 27);
		Combo_UseRefuel.TabIndex = 11;
		Combo_ReplenishmentSelection.BackColor = Color.Transparent;
		Combo_ReplenishmentSelection.Dock = DockStyle.Fill;
		Combo_ReplenishmentSelection.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_ReplenishmentSelection.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_ReplenishmentSelection.DropDownWidth = 450;
		Combo_ReplenishmentSelection.Font = new Font("Segoe UI", 7f);
		Combo_ReplenishmentSelection.FormattingEnabled = true;
		Combo_ReplenishmentSelection.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_ReplenishmentSelection.Location = new Point(308, 428);
		Combo_ReplenishmentSelection.Margin = new Padding(0, 3, 0, 3);
		Combo_ReplenishmentSelection.Name = "Combo_ReplenishmentSelection";
		Combo_ReplenishmentSelection.Size = new Size(167, 27);
		Combo_ReplenishmentSelection.TabIndex = 11;
		Combo_RefuelAllies.BackColor = Color.Transparent;
		Combo_RefuelAllies.Dock = DockStyle.Fill;
		Combo_RefuelAllies.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RefuelAllies.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RefuelAllies.Font = new Font("Segoe UI", 7f);
		Combo_RefuelAllies.FormattingEnabled = true;
		Combo_RefuelAllies.Items.AddRange(new object[3] { "是", "否", "继承" });
		Combo_RefuelAllies.Location = new Point(308, 453);
		Combo_RefuelAllies.Margin = new Padding(0, 3, 0, 3);
		Combo_RefuelAllies.Name = "Combo_RefuelAllies";
		Combo_RefuelAllies.Size = new Size(167, 27);
		Combo_RefuelAllies.TabIndex = 12;
		CB_IgnoreEMCONunderAttack_PlayerEditable.Location = new Point(478, 281);
		CB_IgnoreEMCONunderAttack_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_IgnoreEMCONunderAttack_PlayerEditable.Name = "CB_IgnoreEMCONunderAttack_PlayerEditable";
		CB_IgnoreEMCONunderAttack_PlayerEditable.Size = new Size(15, 14);
		CB_IgnoreEMCONunderAttack_PlayerEditable.TabIndex = 37;
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.Location = new Point(478, 331);
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.Name = "CB_UseKinematicRangeForTorpedoes_PlayerEditable";
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.Size = new Size(15, 14);
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.TabIndex = 38;
		CB_AutoEvade_PlayerEditable.Location = new Point(478, 356);
		CB_AutoEvade_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_AutoEvade_PlayerEditable.Name = "CB_AutoEvade_PlayerEditable";
		CB_AutoEvade_PlayerEditable.Size = new Size(15, 14);
		CB_AutoEvade_PlayerEditable.TabIndex = 39;
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(0, 406);
		Label10.Margin = new Padding(0, 6, 0, 0);
		Label10.Name = "Label10";
		Label10.Size = new Size(113, 19);
		Label10.TabIndex = 15;
		Label10.Text = "加油/补给：";
		Label51.AutoSize = true;
		Label51.Font = new Font("Segoe UI", 8.25f);
		Label51.ForeColor = Color.FromArgb(220, 220, 220);
		Label51.Location = new Point(0, 431);
		Label51.Margin = new Padding(0, 6, 0, 0);
		Label51.Name = "Label51";
		Label51.Size = new Size(194, 19);
		Label51.TabIndex = 15;
		Label51.Text = "加油/补给 对于所选单元：";
		Label33.AutoSize = true;
		Label33.Font = new Font("Segoe UI", 8.25f);
		Label33.ForeColor = Color.FromArgb(220, 220, 220);
		Label33.Location = new Point(0, 456);
		Label33.Margin = new Padding(0, 6, 0, 0);
		Label33.Name = "Label33";
		Label33.Size = new Size(209, 19);
		Label33.TabIndex = 15;
		Label33.Text = "加油/补给 对于友军单元：";
		CB_RefuelAllies_PlayerEditable.Location = new Point(478, 456);
		CB_RefuelAllies_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_RefuelAllies_PlayerEditable.Name = "CB_RefuelAllies_PlayerEditable";
		CB_RefuelAllies_PlayerEditable.Size = new Size(15, 14);
		CB_RefuelAllies_PlayerEditable.TabIndex = 41;
		CB_ReplenishmentSelection_PlayerEditable.Location = new Point(478, 431);
		CB_ReplenishmentSelection_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_ReplenishmentSelection_PlayerEditable.Name = "CB_ReplenishmentSelection_PlayerEditable";
		CB_ReplenishmentSelection_PlayerEditable.Size = new Size(15, 14);
		CB_ReplenishmentSelection_PlayerEditable.TabIndex = 40;
		CB_UseRefuel_PlayerEditable.Location = new Point(478, 406);
		CB_UseRefuel_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_UseRefuel_PlayerEditable.Name = "CB_UseRefuel_PlayerEditable";
		CB_UseRefuel_PlayerEditable.Size = new Size(15, 14);
		CB_UseRefuel_PlayerEditable.TabIndex = 40;
		CB_BongoThreshold_PlayerEditable.Location = new Point(478, 481);
		CB_BongoThreshold_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_BongoThreshold_PlayerEditable.Name = "CB_BongoThreshold_PlayerEditable";
		CB_BongoThreshold_PlayerEditable.Size = new Size(15, 14);
		CB_BongoThreshold_PlayerEditable.TabIndex = 73;
		DarkLabel8.AutoSize = true;
		DarkLabel8.Font = new Font("Segoe UI", 8.25f);
		DarkLabel8.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel8.Location = new Point(0, 481);
		DarkLabel8.Margin = new Padding(0, 6, 0, 0);
		DarkLabel8.Name = "DarkLabel8";
		DarkLabel8.Size = new Size(217, 19);
		DarkLabel8.TabIndex = 74;
		DarkLabel8.Text = "给加油机加油阈值：";
		DarkLabel3.AutoSize = true;
		DarkLabel3.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(0, 559);
		DarkLabel3.Margin = new Padding(0, 9, 0, 0);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(132, 16);
		DarkLabel3.TabIndex = 62;
		DarkLabel3.Text = "地面作战";
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(0, 581);
		DarkLabel4.Margin = new Padding(0, 6, 0, 0);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(89, 19);
		DarkLabel4.TabIndex = 63;
		DarkLabel4.Text = "导航：";
		CB_Land_Navigation_PlayerEditable.AutoSize = true;
		CB_Land_Navigation_PlayerEditable.Location = new Point(478, 581);
		CB_Land_Navigation_PlayerEditable.Margin = new Padding(3, 6, 3, 3);
		CB_Land_Navigation_PlayerEditable.Name = "CB_Land_Navigation_PlayerEditable";
		CB_Land_Navigation_PlayerEditable.Size = new Size(22, 16);
		CB_Land_Navigation_PlayerEditable.TabIndex = 66;
		lblUseMissileWaypoints.AutoSize = true;
		lblUseMissileWaypoints.ForeColor = Color.FromArgb(220, 220, 220);
		lblUseMissileWaypoints.Location = new Point(505, 356);
		lblUseMissileWaypoints.Margin = new Padding(0, 6, 0, 0);
		lblUseMissileWaypoints.Name = "lblUseMissileWaypoints";
		lblUseMissileWaypoints.Size = new Size(163, 19);
		lblUseMissileWaypoints.TabIndex = 75;
		lblUseMissileWaypoints.Text = "使用导弹路径点：";
		Combo_UseWPMissilesOnASuW.BackColor = Color.Transparent;
		Combo_UseWPMissilesOnASuW.Dock = DockStyle.Fill;
		Combo_UseWPMissilesOnASuW.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseWPMissilesOnASuW.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseWPMissilesOnASuW.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_UseWPMissilesOnASuW.FormattingEnabled = true;
		Combo_UseWPMissilesOnASuW.Location = new Point(803, 353);
		Combo_UseWPMissilesOnASuW.Margin = new Padding(0, 3, 0, 3);
		Combo_UseWPMissilesOnASuW.Name = "Combo_UseWPMissilesOnASuW";
		Combo_UseWPMissilesOnASuW.Size = new Size(167, 27);
		Combo_UseWPMissilesOnASuW.TabIndex = 76;
		CB_UseWPMissilesOnASuW.AutoSize = true;
		CB_UseWPMissilesOnASuW.Location = new Point(973, 353);
		CB_UseWPMissilesOnASuW.Name = "CB_UseWPMissilesOnASuW";
		CB_UseWPMissilesOnASuW.Size = new Size(18, 19);
		CB_UseWPMissilesOnASuW.TabIndex = 77;
		CB_UseWPMissilesOnASuW.Text = "DarkCheckBox1";
		DarkLabel_7.AutoSize = true;
		DarkLabel_7.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_7.Location = new Point(0, 384);
		DarkLabel_7.Margin = new Padding(0, 9, 0, 0);
		DarkLabel_7.Name = "DarkLabel16";
		DarkLabel_7.Size = new Size(68, 16);
		DarkLabel_7.TabIndex = 80;
		DarkLabel_7.Text = "加油";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(DarkLabel9);
		TabPage2.Controls.Add(DefoncLabel2);
		TabPage2.Controls.Add(DarkLabel_0);
		TabPage2.Controls.Add(EmissionIntervalPhonyTab);
		TabPage2.Controls.Add(Combo_AlertLevel);
		TabPage2.Controls.Add(UseIntervalGroup);
		TabPage2.Controls.Add(Button_ResetAffectedMissions_EMCON);
		TabPage2.Controls.Add(Button_ResetAffectedUnits_EMCON);
		TabPage2.Controls.Add(Button_ResetCurrent_EMCON);
		TabPage2.Controls.Add(CB_EMCON_Sonar);
		TabPage2.Controls.Add(Label9);
		TabPage2.Controls.Add(CB_EMCON_OECM);
		TabPage2.Controls.Add(Label8);
		TabPage2.Controls.Add(CB_EMCON_Inherits);
		TabPage2.Controls.Add(CB_EMCON_Radar);
		TabPage2.Controls.Add(Label3);
		TabPage2.Location = new Point(4, 36);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(1000, 651);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "电磁管控设置";
		DarkLabel9.AutoSize = true;
		DarkLabel9.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel9.Location = new Point(11, 31);
		DarkLabel9.Name = "DarkLabel9";
		DarkLabel9.Size = new Size(46, 21);
		DarkLabel9.TabIndex = 28;
		DarkLabel9.Text = "警报等级：";
		DefoncLabel2.AutoSize = true;
		DefoncLabel2.ForeColor = Color.IndianRed;
		DefoncLabel2.Location = new Point(229, 31);
		DefoncLabel2.Name = "DefoncLabel2";
		DefoncLabel2.Size = new Size(199, 21);
		DefoncLabel2.TabIndex = 27;
		DefoncLabel2.Text = "!影响分方警报等级!";
		DarkLabel_0.AutoSize = true;
		DarkLabel_0.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_0.Location = new Point(15, 471);
		DarkLabel_0.Name = "DEBUGINTERMITTENT1";
		DarkLabel_0.Size = new Size(271, 21);
		DarkLabel_0.TabIndex = 26;
		DarkLabel_0.Text = "DEBUG INTERVAL TIME REMAINING : ";
		DarkLabel_0.Visible = false;
		EmissionIntervalPhonyTab.BackColor = Color.Magenta;
		EmissionIntervalPhonyTab.Controls.Add(CBWakeWhenDetectingThreat);
		EmissionIntervalPhonyTab.Controls.Add(WakeGroupBox);
		EmissionIntervalPhonyTab.Controls.Add(LabelPlus);
		EmissionIntervalPhonyTab.Controls.Add(EmissionDurationTextBox);
		EmissionIntervalPhonyTab.Controls.Add(Label_AEI_0);
		EmissionIntervalPhonyTab.Controls.Add(IntermittantToggle);
		EmissionIntervalPhonyTab.Controls.Add(Label_AEI_2);
		EmissionIntervalPhonyTab.Controls.Add(Interval);
		EmissionIntervalPhonyTab.Controls.Add(IntervalVariation);
		EmissionIntervalPhonyTab.Controls.Add(Label_AEI_1);
		EmissionIntervalPhonyTab.Location = new Point(21, 197);
		EmissionIntervalPhonyTab.Name = "EmissionIntervalPhonyTab";
		EmissionIntervalPhonyTab.Size = new Size(450, 218);
		EmissionIntervalPhonyTab.TabIndex = 19;
		WakeGroupBox.Controls.Add(DarkLabel5);
		WakeGroupBox.Controls.Add(DarkLabel7);
		WakeGroupBox.Controls.Add(DarkLabel6);
		WakeGroupBox.Controls.Add(IncludesIDGroup);
		WakeGroupBox.Controls.Add(Includes);
		WakeGroupBox.Controls.Add(CB_EmconFollowsWRARules);
		WakeGroupBox.Controls.Add(BackToSleepTime);
		WakeGroupBox.Controls.Add(Label_AEI_3);
		WakeGroupBox.ForeColor = Color.FromArgb(220, 220, 220);
		WakeGroupBox.Location = new Point(6, 92);
		WakeGroupBox.Name = "WakeGroupBox";
		WakeGroupBox.Size = new Size(439, 122);
		WakeGroupBox.TabIndex = 27;
		WakeGroupBox.TabStop = false;
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(284, 51);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(38, 21);
		DarkLabel5.TabIndex = 37;
		DarkLabel5.Text = "And";
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(284, 65);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(40, 21);
		DarkLabel7.TabIndex = 36;
		DarkLabel7.Text = "Also";
		DarkLabel6.AutoSize = true;
		DarkLabel6.Font = new Font("Segoe UI", 8.25f);
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(0, 481);
		DarkLabel6.Margin = new Padding(0, 6, 0, 0);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(41, 23);
		DarkLabel6.TabIndex = 35;
		DarkLabel6.Text = "And";
		IncludesIDGroup.Controls.Add(CB_IncludesID_Unknown);
		IncludesIDGroup.Controls.Add(CB_IncludesID_KnownDomain);
		IncludesIDGroup.Controls.Add(CB_IncludesID_KnownID);
		IncludesIDGroup.Controls.Add(CB_IncludesID_KnowType);
		IncludesIDGroup.Controls.Add(CB_IncludesID_KnownClass);
		IncludesIDGroup.ForeColor = Color.FromArgb(220, 220, 220);
		IncludesIDGroup.Location = new Point(314, 18);
		IncludesIDGroup.Name = "IncludesIDGroup";
		IncludesIDGroup.Size = new Size(119, 98);
		IncludesIDGroup.TabIndex = 34;
		IncludesIDGroup.TabStop = false;
		IncludesIDGroup.Text = "包含识别分类";
		CB_IncludesID_Unknown.AutoSize = true;
		CB_IncludesID_Unknown.Location = new Point(7, 16);
		CB_IncludesID_Unknown.Name = "CB_IncludesID_Unknown";
		CB_IncludesID_Unknown.Size = new Size(103, 25);
		CB_IncludesID_Unknown.TabIndex = 28;
		CB_IncludesID_Unknown.Text = "未知";
		CB_IncludesID_Unknown.UseVisualStyleBackColor = true;
		CB_IncludesID_KnownDomain.AutoSize = true;
		CB_IncludesID_KnownDomain.Location = new Point(7, 32);
		CB_IncludesID_KnownDomain.Name = "CB_IncludesID_KnownDomain";
		CB_IncludesID_KnownDomain.Size = new Size(143, 25);
		CB_IncludesID_KnownDomain.TabIndex = 29;
		CB_IncludesID_KnownDomain.Text = "已知分方";
		CB_IncludesID_KnownDomain.UseVisualStyleBackColor = true;
		CB_IncludesID_KnownID.AutoSize = true;
		CB_IncludesID_KnownID.Location = new Point(7, 78);
		CB_IncludesID_KnownID.Name = "CB_IncludesID_KnownID";
		CB_IncludesID_KnownID.Size = new Size(103, 25);
		CB_IncludesID_KnownID.TabIndex = 32;
		CB_IncludesID_KnownID.Text = "已知具体编号";
		CB_IncludesID_KnownID.UseVisualStyleBackColor = true;
		CB_IncludesID_KnowType.AutoSize = true;
		CB_IncludesID_KnowType.Location = new Point(7, 48);
		CB_IncludesID_KnowType.Name = "CB_IncludesID_KnowType";
		CB_IncludesID_KnowType.Size = new Size(120, 25);
		CB_IncludesID_KnowType.TabIndex = 30;
		CB_IncludesID_KnowType.Text = "已知类型";
		CB_IncludesID_KnowType.UseVisualStyleBackColor = true;
		CB_IncludesID_KnownClass.AutoSize = true;
		CB_IncludesID_KnownClass.Location = new Point(7, 63);
		CB_IncludesID_KnownClass.Name = "CB_IncludesID_KnownClass";
		CB_IncludesID_KnownClass.Size = new Size(124, 25);
		CB_IncludesID_KnownClass.TabIndex = 31;
		CB_IncludesID_KnownClass.Text = "已知型号";
		CB_IncludesID_KnownClass.UseVisualStyleBackColor = true;
		Includes.Controls.Add(CB_IncludesStance_Hostile);
		Includes.Controls.Add(CB_IncludesStance_Friendly);
		Includes.Controls.Add(CB_IncludesStance_Neutral);
		Includes.Controls.Add(CB_IncludesStance_Unfriendly);
		Includes.Controls.Add(CB_IncludesStance_Unknown);
		Includes.ForeColor = Color.FromArgb(220, 220, 220);
		Includes.Location = new Point(180, 18);
		Includes.Name = "Includes";
		Includes.Size = new Size(102, 98);
		Includes.TabIndex = 33;
		Includes.TabStop = false;
		Includes.Text = "包含分方";
		CB_IncludesStance_Hostile.AutoSize = true;
		CB_IncludesStance_Hostile.Location = new Point(6, 62);
		CB_IncludesStance_Hostile.Name = "CB_IncludesStance_Hostile";
		CB_IncludesStance_Hostile.Size = new Size(84, 25);
		CB_IncludesStance_Hostile.TabIndex = 26;
		CB_IncludesStance_Hostile.Text = "敌方";
		CB_IncludesStance_Hostile.UseVisualStyleBackColor = true;
		CB_IncludesStance_Friendly.AutoSize = true;
		CB_IncludesStance_Friendly.Location = new Point(6, 15);
		CB_IncludesStance_Friendly.Name = "CB_IncludesStance_Friendly";
		CB_IncludesStance_Friendly.Size = new Size(92, 25);
		CB_IncludesStance_Friendly.TabIndex = 23;
		CB_IncludesStance_Friendly.Text = "友方";
		CB_IncludesStance_Friendly.UseVisualStyleBackColor = true;
		CB_IncludesStance_Neutral.AutoSize = true;
		CB_IncludesStance_Neutral.Location = new Point(6, 31);
		CB_IncludesStance_Neutral.Name = "CB_IncludesStance_Neutral";
		CB_IncludesStance_Neutral.Size = new Size(88, 25);
		CB_IncludesStance_Neutral.TabIndex = 24;
		CB_IncludesStance_Neutral.Text = "中立";
		CB_IncludesStance_Neutral.UseVisualStyleBackColor = true;
		CB_IncludesStance_Unfriendly.AutoSize = true;
		CB_IncludesStance_Unfriendly.Location = new Point(6, 47);
		CB_IncludesStance_Unfriendly.Name = "CB_IncludesStance_Unfriendly";
		CB_IncludesStance_Unfriendly.Size = new Size(109, 25);
		CB_IncludesStance_Unfriendly.TabIndex = 25;
		CB_IncludesStance_Unfriendly.Text = "非友方";
		CB_IncludesStance_Unfriendly.UseVisualStyleBackColor = true;
		CB_IncludesStance_Unknown.AutoSize = true;
		CB_IncludesStance_Unknown.Location = new Point(6, 77);
		CB_IncludesStance_Unknown.Name = "CB_IncludesStance_Unknown";
		CB_IncludesStance_Unknown.Size = new Size(103, 25);
		CB_IncludesStance_Unknown.TabIndex = 27;
		CB_IncludesStance_Unknown.Text = "未知";
		CB_IncludesStance_Unknown.UseVisualStyleBackColor = true;
		CB_EmconFollowsWRARules.BackColor = Color.Transparent;
		CB_EmconFollowsWRARules.Checked = false;
		CB_EmconFollowsWRARules.Cursor = Cursors.Hand;
		CB_EmconFollowsWRARules.ForeColor = Color.FromArgb(209, 209, 209);
		CB_EmconFollowsWRARules.Location = new Point(6, 67);
		CB_EmconFollowsWRARules.Name = "CB_EmconFollowsWRARules";
		CB_EmconFollowsWRARules.Size = new Size(171, 18);
		CB_EmconFollowsWRARules.TabIndex = 22;
		CB_EmconFollowsWRARules.Text = "Follow WRA rules";
		CB_EmconFollowsWRARules.Visible = false;
		LabelPlus.AutoSize = true;
		LabelPlus.ForeColor = Color.FromArgb(220, 220, 220);
		LabelPlus.Location = new Point(193, 66);
		LabelPlus.Name = "LabelPlus";
		LabelPlus.Size = new Size(21, 21);
		LabelPlus.TabIndex = 26;
		LabelPlus.Text = "+";
		EmissionDurationTextBox.AutoCompleteCustomSource = null;
		EmissionDurationTextBox.AutoCompleteMode = AutoCompleteMode.None;
		EmissionDurationTextBox.AutoCompleteSource = AutoCompleteSource.None;
		EmissionDurationTextBox.BackColor = Color.Transparent;
		EmissionDurationTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		EmissionDurationTextBox.Image = null;
		EmissionDurationTextBox.Lines = null;
		EmissionDurationTextBox.Location = new Point(211, 22);
		EmissionDurationTextBox.MaxLength = 32767;
		EmissionDurationTextBox.Multiline = false;
		EmissionDurationTextBox.Name = "EmissionDurationTextBox";
		EmissionDurationTextBox.ReadOnly = false;
		EmissionDurationTextBox.ScrollBars = ScrollBars.None;
		EmissionDurationTextBox.SelectionStart = 0;
		EmissionDurationTextBox.Size = new Size(188, 24);
		EmissionDurationTextBox.TabIndex = 25;
		EmissionDurationTextBox.Text = "20";
		EmissionDurationTextBox.TextAlign = HorizontalAlignment.Center;
		EmissionDurationTextBox.UseSystemPasswordChar = false;
		EmissionDurationTextBox.WatermarkText = "";
		Label_AEI_0.AutoSize = true;
		Label_AEI_0.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AEI_0.Location = new Point(208, 6);
		Label_AEI_0.Name = "Label_AEI_0";
		Label_AEI_0.Size = new Size(214, 21);
		Label_AEI_0.TabIndex = 24;
		Label_AEI_0.Text = "持续开机时间(秒)：";
		Combo_AlertLevel.BackColor = Color.Transparent;
		Combo_AlertLevel.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AlertLevel.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AlertLevel.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_AlertLevel.FormattingEnabled = true;
		Combo_AlertLevel.Items.AddRange(new object[5] { "绿色", "蓝色", "黄色", "橙色", "红色" });
		Combo_AlertLevel.Location = new Point(75, 29);
		Combo_AlertLevel.Name = "Combo_AlertLevel";
		Combo_AlertLevel.Size = new Size(146, 27);
		Combo_AlertLevel.TabIndex = 24;
		Button_ResetAffectedMissions_EMCON.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedMissions_EMCON.BackColor = Color.Transparent;
		Button_ResetAffectedMissions_EMCON.DialogResult = DialogResult.None;
		Button_ResetAffectedMissions_EMCON.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedMissions_EMCON.ForeColor = SystemColors.Control;
		Button_ResetAffectedMissions_EMCON.Location = new Point(531, 631);
		Button_ResetAffectedMissions_EMCON.Name = "Button_ResetAffectedMissions_EMCON";
		Button_ResetAffectedMissions_EMCON.Padding = new Padding(5);
		Button_ResetAffectedMissions_EMCON.RoundRadius = 0;
		Button_ResetAffectedMissions_EMCON.Size = new Size(272, 23);
		Button_ResetAffectedMissions_EMCON.TabIndex = 14;
		Button_ResetAffectedMissions_EMCON.Text = "重置受影响的任务（继承自上述电磁管控规则EMCON）";
		Button_ResetAffectedUnits_EMCON.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedUnits_EMCON.BackColor = Color.Transparent;
		Button_ResetAffectedUnits_EMCON.DialogResult = DialogResult.None;
		Button_ResetAffectedUnits_EMCON.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedUnits_EMCON.ForeColor = SystemColors.Control;
		Button_ResetAffectedUnits_EMCON.Location = new Point(265, 631);
		Button_ResetAffectedUnits_EMCON.Name = "Button_ResetAffectedUnits_EMCON";
		Button_ResetAffectedUnits_EMCON.Padding = new Padding(5);
		Button_ResetAffectedUnits_EMCON.RoundRadius = 0;
		Button_ResetAffectedUnits_EMCON.Size = new Size(265, 23);
		Button_ResetAffectedUnits_EMCON.TabIndex = 13;
		Button_ResetAffectedUnits_EMCON.Text = "重置受影响的单元（继承自上述电磁管控规则EMCON）";
		Button_ResetCurrent_EMCON.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetCurrent_EMCON.BackColor = Color.Transparent;
		Button_ResetCurrent_EMCON.DialogResult = DialogResult.None;
		Button_ResetCurrent_EMCON.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetCurrent_EMCON.ForeColor = SystemColors.Control;
		Button_ResetCurrent_EMCON.Location = new Point(-1, 631);
		Button_ResetCurrent_EMCON.Name = "Button_ResetCurrent_EMCON";
		Button_ResetCurrent_EMCON.Padding = new Padding(5);
		Button_ResetCurrent_EMCON.RoundRadius = 0;
		Button_ResetCurrent_EMCON.Size = new Size(265, 23);
		Button_ResetCurrent_EMCON.TabIndex = 12;
		Button_ResetCurrent_EMCON.Text = "重置电磁管控规则EMCON（使用继承的设置）";
		CB_EMCON_Sonar.BackColor = Color.Transparent;
		CB_EMCON_Sonar.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_Sonar.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_Sonar.Font = new Font("Segoe UI", 7f);
		CB_EMCON_Sonar.FormattingEnabled = true;
		CB_EMCON_Sonar.Location = new Point(75, 86);
		CB_EMCON_Sonar.Name = "CB_EMCON_Sonar";
		CB_EMCON_Sonar.Size = new Size(146, 27);
		CB_EMCON_Sonar.TabIndex = 6;
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(11, 86);
		Label9.Name = "Label9";
		Label9.Size = new Size(54, 21);
		Label9.TabIndex = 5;
		Label9.Text = "声纳：";
		CB_EMCON_OECM.BackColor = Color.Transparent;
		CB_EMCON_OECM.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_OECM.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_OECM.Font = new Font("Segoe UI", 7f);
		CB_EMCON_OECM.FormattingEnabled = true;
		CB_EMCON_OECM.Location = new Point(75, 112);
		CB_EMCON_OECM.Name = "CB_EMCON_OECM";
		CB_EMCON_OECM.Size = new Size(146, 27);
		CB_EMCON_OECM.TabIndex = 4;
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(11, 114);
		Label8.Name = "Label8";
		Label8.Size = new Size(57, 21);
		Label8.TabIndex = 3;
		Label8.Text = "进攻性电磁武器OECM：";
		CB_EMCON_Inherits.Location = new Point(12, 6);
		CB_EMCON_Inherits.Name = "CB_EMCON_Inherits";
		CB_EMCON_Inherits.Size = new Size(111, 17);
		CB_EMCON_Inherits.TabIndex = 2;
		CB_EMCON_Inherits.Text = "从父级继承";
		CB_EMCON_Radar.BackColor = Color.Transparent;
		CB_EMCON_Radar.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_Radar.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_Radar.Font = new Font("Segoe UI", 7f);
		CB_EMCON_Radar.FormattingEnabled = true;
		CB_EMCON_Radar.Location = new Point(75, 56);
		CB_EMCON_Radar.Name = "CB_EMCON_Radar";
		CB_EMCON_Radar.Size = new Size(146, 27);
		CB_EMCON_Radar.TabIndex = 1;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(11, 58);
		Label3.Name = "Label3";
		Label3.Size = new Size(54, 21);
		Label3.TabIndex = 0;
		Label3.Text = "雷达：";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(Button_ResetAffectedMissions_WRA);
		TabPage3.Controls.Add(Button_ResetAffectedUnits_WRA);
		TabPage3.Controls.Add(Button_ResetCurrent_WRA);
		TabPage3.Controls.Add(TGV_WRA);
		TabPage3.Location = new Point(4, 36);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(1000, 651);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "武器投放授权（WRA）";
		Button_ResetAffectedMissions_WRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedMissions_WRA.BackColor = Color.Transparent;
		Button_ResetAffectedMissions_WRA.DialogResult = DialogResult.None;
		Button_ResetAffectedMissions_WRA.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedMissions_WRA.ForeColor = SystemColors.Control;
		Button_ResetAffectedMissions_WRA.Location = new Point(542, 628);
		Button_ResetAffectedMissions_WRA.Name = "Button_ResetAffectedMissions_WRA";
		Button_ResetAffectedMissions_WRA.Padding = new Padding(5);
		Button_ResetAffectedMissions_WRA.RoundRadius = 0;
		Button_ResetAffectedMissions_WRA.Size = new Size(265, 23);
		Button_ResetAffectedMissions_WRA.TabIndex = 11;
		Button_ResetAffectedMissions_WRA.Text = "重置受影响的任务（继承自上述WRA）";
		Button_ResetAffectedUnits_WRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetAffectedUnits_WRA.BackColor = Color.Transparent;
		Button_ResetAffectedUnits_WRA.DialogResult = DialogResult.None;
		Button_ResetAffectedUnits_WRA.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetAffectedUnits_WRA.ForeColor = SystemColors.Control;
		Button_ResetAffectedUnits_WRA.Location = new Point(271, 628);
		Button_ResetAffectedUnits_WRA.Name = "Button_ResetAffectedUnits_WRA";
		Button_ResetAffectedUnits_WRA.Padding = new Padding(5);
		Button_ResetAffectedUnits_WRA.RoundRadius = 0;
		Button_ResetAffectedUnits_WRA.Size = new Size(265, 23);
		Button_ResetAffectedUnits_WRA.TabIndex = 10;
		Button_ResetAffectedUnits_WRA.Text = "重置受影响的单元（继承自上述WRA）";
		Button_ResetCurrent_WRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ResetCurrent_WRA.BackColor = Color.Transparent;
		Button_ResetCurrent_WRA.DialogResult = DialogResult.None;
		Button_ResetCurrent_WRA.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetCurrent_WRA.ForeColor = SystemColors.Control;
		Button_ResetCurrent_WRA.Location = new Point(0, 628);
		Button_ResetCurrent_WRA.Name = "Button_ResetCurrent_WRA";
		Button_ResetCurrent_WRA.Padding = new Padding(5);
		Button_ResetCurrent_WRA.RoundRadius = 0;
		Button_ResetCurrent_WRA.Size = new Size(265, 23);
		Button_ResetCurrent_WRA.TabIndex = 9;
		Button_ResetCurrent_WRA.Text = "重置WRA（使用继承的设置）";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(Combo_RedeployDefenceThreshold);
		TabPage4.Controls.Add(Combo_RedeployAttackThreshold);
		TabPage4.Controls.Add(Combo_RedeployFuelThreshold);
		TabPage4.Controls.Add(Label46);
		TabPage4.Controls.Add(Label47);
		TabPage4.Controls.Add(Label48);
		TabPage4.Controls.Add(Label49);
		TabPage4.Controls.Add(Combo_RedeployDamageThreshold);
		TabPage4.Controls.Add(Label50);
		TabPage4.Controls.Add(Combo_WithdrawDefenceThreshold);
		TabPage4.Controls.Add(Combo_WithdrawAttackThreshold);
		TabPage4.Controls.Add(Combo_WithdrawFuelThreshold);
		TabPage4.Controls.Add(Label45);
		TabPage4.Controls.Add(Label43);
		TabPage4.Controls.Add(Label44);
		TabPage4.Controls.Add(Label42);
		TabPage4.Controls.Add(Combo_WithdrawDamageThreshold);
		TabPage4.Controls.Add(Label41);
		TabPage4.Location = new Point(4, 36);
		TabPage4.Name = "TabPage4";
		TabPage4.Size = new Size(1000, 651);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "撤退和重新部署（舰艇/潜艇/地面）";
		Combo_RedeployDefenceThreshold.BackColor = Color.Transparent;
		Combo_RedeployDefenceThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RedeployDefenceThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RedeployDefenceThreshold.Font = new Font("Segoe UI", 7f);
		Combo_RedeployDefenceThreshold.FormattingEnabled = true;
		Combo_RedeployDefenceThreshold.Location = new Point(261, 307);
		Combo_RedeployDefenceThreshold.Name = "Combo_RedeployDefenceThreshold";
		Combo_RedeployDefenceThreshold.Size = new Size(159, 27);
		Combo_RedeployDefenceThreshold.TabIndex = 17;
		Combo_RedeployAttackThreshold.BackColor = Color.Transparent;
		Combo_RedeployAttackThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RedeployAttackThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RedeployAttackThreshold.Font = new Font("Segoe UI", 7f);
		Combo_RedeployAttackThreshold.FormattingEnabled = true;
		Combo_RedeployAttackThreshold.Location = new Point(261, 280);
		Combo_RedeployAttackThreshold.Name = "Combo_RedeployAttackThreshold";
		Combo_RedeployAttackThreshold.Size = new Size(159, 27);
		Combo_RedeployAttackThreshold.TabIndex = 16;
		Combo_RedeployFuelThreshold.BackColor = Color.Transparent;
		Combo_RedeployFuelThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RedeployFuelThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RedeployFuelThreshold.Font = new Font("Segoe UI", 7f);
		Combo_RedeployFuelThreshold.FormattingEnabled = true;
		Combo_RedeployFuelThreshold.Location = new Point(261, 253);
		Combo_RedeployFuelThreshold.Name = "Combo_RedeployFuelThreshold";
		Combo_RedeployFuelThreshold.Size = new Size(159, 27);
		Combo_RedeployFuelThreshold.TabIndex = 15;
		Label46.AutoSize = true;
		Label46.ForeColor = Color.FromArgb(220, 220, 220);
		Label46.Location = new Point(10, 310);
		Label46.Name = "Label46";
		Label46.Size = new Size(333, 21);
		Label46.TabIndex = 14;
		Label46.Text = "并且主要防御武器至少有：";
		Label47.AutoSize = true;
		Label47.Font = new Font("Segoe UI", 16f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label47.ForeColor = Color.FromArgb(220, 220, 220);
		Label47.Location = new Point(8, 185);
		Label47.Name = "Label47";
		Label47.Size = new Size(265, 45);
		Label47.TabIndex = 13;
		Label47.Text = "重新部署当......";
		Label48.AutoSize = true;
		Label48.ForeColor = Color.FromArgb(220, 220, 220);
		Label48.Location = new Point(10, 283);
		Label48.Name = "Label48";
		Label48.Size = new Size(320, 21);
		Label48.TabIndex = 11;
		Label48.Text = "并且主要攻击武器至少在：";
		Label49.AutoSize = true;
		Label49.ForeColor = Color.FromArgb(220, 220, 220);
		Label49.Location = new Point(10, 256);
		Label49.Name = "Label49";
		Label49.Size = new Size(164, 21);
		Label49.TabIndex = 12;
		Label49.Text = "并且燃料至少有：";
		Combo_RedeployDamageThreshold.BackColor = Color.Transparent;
		Combo_RedeployDamageThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RedeployDamageThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RedeployDamageThreshold.Font = new Font("Segoe UI", 7f);
		Combo_RedeployDamageThreshold.FormattingEnabled = true;
		Combo_RedeployDamageThreshold.Location = new Point(261, 226);
		Combo_RedeployDamageThreshold.Name = "Combo_RedeployDamageThreshold";
		Combo_RedeployDamageThreshold.Size = new Size(159, 27);
		Combo_RedeployDamageThreshold.TabIndex = 10;
		Label50.AutoSize = true;
		Label50.ForeColor = Color.FromArgb(220, 220, 220);
		Label50.Location = new Point(10, 229);
		Label50.Name = "Label50";
		Label50.Size = new Size(151, 21);
		Label50.TabIndex = 9;
		Label50.Text = "毁伤小于：";
		Combo_WithdrawDefenceThreshold.BackColor = Color.Transparent;
		Combo_WithdrawDefenceThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WithdrawDefenceThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WithdrawDefenceThreshold.Font = new Font("Segoe UI", 7f);
		Combo_WithdrawDefenceThreshold.FormattingEnabled = true;
		Combo_WithdrawDefenceThreshold.Location = new Point(261, 135);
		Combo_WithdrawDefenceThreshold.Name = "Combo_WithdrawDefenceThreshold";
		Combo_WithdrawDefenceThreshold.Size = new Size(159, 27);
		Combo_WithdrawDefenceThreshold.TabIndex = 8;
		Combo_WithdrawAttackThreshold.BackColor = Color.Transparent;
		Combo_WithdrawAttackThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WithdrawAttackThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WithdrawAttackThreshold.Font = new Font("Segoe UI", 7f);
		Combo_WithdrawAttackThreshold.FormattingEnabled = true;
		Combo_WithdrawAttackThreshold.Location = new Point(261, 108);
		Combo_WithdrawAttackThreshold.Name = "Combo_WithdrawAttackThreshold";
		Combo_WithdrawAttackThreshold.Size = new Size(159, 27);
		Combo_WithdrawAttackThreshold.TabIndex = 7;
		Combo_WithdrawFuelThreshold.BackColor = Color.Transparent;
		Combo_WithdrawFuelThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WithdrawFuelThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WithdrawFuelThreshold.Font = new Font("Segoe UI", 7f);
		Combo_WithdrawFuelThreshold.FormattingEnabled = true;
		Combo_WithdrawFuelThreshold.Location = new Point(261, 81);
		Combo_WithdrawFuelThreshold.Name = "Combo_WithdrawFuelThreshold";
		Combo_WithdrawFuelThreshold.Size = new Size(159, 27);
		Combo_WithdrawFuelThreshold.TabIndex = 6;
		Label45.AutoSize = true;
		Label45.ForeColor = Color.FromArgb(220, 220, 220);
		Label45.Location = new Point(10, 138);
		Label45.Name = "Label45";
		Label45.Size = new Size(334, 21);
		Label45.TabIndex = 5;
		Label45.Text = "或主要防御武器低于：";
		Label43.AutoSize = true;
		Label43.Font = new Font("Segoe UI", 16f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label43.ForeColor = Color.FromArgb(220, 220, 220);
		Label43.Location = new Point(8, 13);
		Label43.Name = "Label43";
		Label43.Size = new Size(269, 45);
		Label43.TabIndex = 4;
		Label43.Text = "退出当....";
		Label44.AutoSize = true;
		Label44.ForeColor = Color.FromArgb(220, 220, 220);
		Label44.Location = new Point(10, 111);
		Label44.Name = "Label44";
		Label44.Size = new Size(321, 21);
		Label44.TabIndex = 2;
		Label44.Text = "或主要攻击武器低于：";
		Label42.AutoSize = true;
		Label42.ForeColor = Color.FromArgb(220, 220, 220);
		Label42.Location = new Point(10, 84);
		Label42.Name = "Label42";
		Label42.Size = new Size(148, 21);
		Label42.TabIndex = 2;
		Label42.Text = "或燃料少于：";
		Combo_WithdrawDamageThreshold.BackColor = Color.Transparent;
		Combo_WithdrawDamageThreshold.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WithdrawDamageThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WithdrawDamageThreshold.Font = new Font("Segoe UI", 7f);
		Combo_WithdrawDamageThreshold.FormattingEnabled = true;
		Combo_WithdrawDamageThreshold.Location = new Point(261, 54);
		Combo_WithdrawDamageThreshold.Name = "Combo_WithdrawDamageThreshold";
		Combo_WithdrawDamageThreshold.Size = new Size(159, 27);
		Combo_WithdrawDamageThreshold.TabIndex = 1;
		Label41.AutoSize = true;
		Label41.ForeColor = Color.FromArgb(220, 220, 220);
		Label41.Location = new Point(10, 57);
		Label41.Name = "Label41";
		Label41.Size = new Size(162, 21);
		Label41.TabIndex = 0;
		Label41.Text = "毁伤超过：";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Controls.Add(Btn_PTLRemove);
		TabPage5.Controls.Add(Btn_PTLCreate);
		TabPage5.Controls.Add(Label_PTLSource);
		TabPage5.Controls.Add(DarkLabel_1);
		TabPage5.Controls.Add(DarkLabel_2);
		TabPage5.Controls.Add(DarkLabel_3);
		TabPage5.Controls.Add(DarkLabel_4);
		TabPage5.Controls.Add(Btn_PTLDelete);
		TabPage5.Controls.Add(Btn_PTLAdd);
		TabPage5.Controls.Add(Btn_PTLMoveDown);
		TabPage5.Controls.Add(Btn_PTLMoveUp);
		TabPage5.Controls.Add(List_TargetPriority);
		TabPage5.Location = new Point(4, 36);
		TabPage5.Name = "TabPage5";
		TabPage5.Size = new Size(1000, 651);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "目标优先级";
		Btn_PTLRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLRemove.BackColor = Color.Transparent;
		Btn_PTLRemove.DialogResult = DialogResult.None;
		Btn_PTLRemove.ForeColor = Color.Red;
		Btn_PTLRemove.Location = new Point(92, 610);
		Btn_PTLRemove.Name = "Btn_PTLRemove";
		Btn_PTLRemove.RoundRadius = 0;
		Btn_PTLRemove.Size = new Size(75, 23);
		Btn_PTLRemove.TabIndex = 11;
		Btn_PTLRemove.Text = "删除";
		Btn_PTLCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLCreate.BackColor = Color.Transparent;
		Btn_PTLCreate.DialogResult = DialogResult.None;
		Btn_PTLCreate.ForeColor = SystemColors.Control;
		Btn_PTLCreate.Location = new Point(11, 610);
		Btn_PTLCreate.Name = "Btn_PTLCreate";
		Btn_PTLCreate.RoundRadius = 0;
		Btn_PTLCreate.Size = new Size(75, 23);
		Btn_PTLCreate.TabIndex = 10;
		Btn_PTLCreate.Text = "创建";
		Label_PTLSource.AutoSize = true;
		Label_PTLSource.ForeColor = Color.FromArgb(220, 220, 220);
		Label_PTLSource.Location = new Point(8, 584);
		Label_PTLSource.Name = "Label_PTLSource";
		Label_PTLSource.Size = new Size(179, 21);
		Label_PTLSource.TabIndex = 9;
		Label_PTLSource.Text = "从条令继承：";
		DarkLabel_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel_1.AutoSize = true;
		DarkLabel_1.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_1.ImageAlign = ContentAlignment.BottomCenter;
		DarkLabel_1.Location = new Point(822, 8);
		DarkLabel_1.Name = "DarkLabel13";
		DarkLabel_1.Size = new Size(191, 25);
		DarkLabel_1.TabIndex = 8;
		DarkLabel_1.Text = "交战时间";
		DarkLabel_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel_2.AutoSize = true;
		DarkLabel_2.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_2.ImageAlign = ContentAlignment.BottomCenter;
		DarkLabel_2.Location = new Point(418, 8);
		DarkLabel_2.Name = "DarkLabel12";
		DarkLabel_2.Size = new Size(98, 25);
		DarkLabel_2.TabIndex = 7;
		DarkLabel_2.Text = "单元类别";
		DarkLabel_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel_3.AutoSize = true;
		DarkLabel_3.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_3.ImageAlign = ContentAlignment.BottomCenter;
		DarkLabel_3.Location = new Point(204, 8);
		DarkLabel_3.Name = "DarkLabel11";
		DarkLabel_3.Size = new Size(129, 25);
		DarkLabel_3.TabIndex = 6;
		DarkLabel_3.Text = "单元子类型";
		DarkLabel_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel_4.AutoSize = true;
		DarkLabel_4.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
		DarkLabel_4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_4.ImageAlign = ContentAlignment.BottomCenter;
		DarkLabel_4.Location = new Point(44, 8);
		DarkLabel_4.Name = "DarkLabel10";
		DarkLabel_4.Size = new Size(97, 25);
		DarkLabel_4.TabIndex = 5;
		DarkLabel_4.Text = "单元类型";
		Btn_PTLDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLDelete.BackColor = Color.Transparent;
		Btn_PTLDelete.DialogResult = DialogResult.None;
		Btn_PTLDelete.ForeColor = SystemColors.Control;
		Btn_PTLDelete.Location = new Point(620, 610);
		Btn_PTLDelete.Name = "Btn_PTLDelete";
		Btn_PTLDelete.RoundRadius = 0;
		Btn_PTLDelete.Size = new Size(75, 23);
		Btn_PTLDelete.TabIndex = 4;
		Btn_PTLDelete.Text = "删除条目";
		Btn_PTLAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLAdd.BackColor = Color.Transparent;
		Btn_PTLAdd.DialogResult = DialogResult.None;
		Btn_PTLAdd.ForeColor = SystemColors.Control;
		Btn_PTLAdd.Location = new Point(539, 610);
		Btn_PTLAdd.Name = "Btn_PTLAdd";
		Btn_PTLAdd.RoundRadius = 0;
		Btn_PTLAdd.Size = new Size(75, 23);
		Btn_PTLAdd.TabIndex = 3;
		Btn_PTLAdd.Text = "添加条目";
		Btn_PTLMoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLMoveDown.BackColor = Color.Transparent;
		Btn_PTLMoveDown.DialogResult = DialogResult.None;
		Btn_PTLMoveDown.ForeColor = SystemColors.Control;
		Btn_PTLMoveDown.Location = new Point(413, 610);
		Btn_PTLMoveDown.Name = "Btn_PTLMoveDown";
		Btn_PTLMoveDown.RoundRadius = 0;
		Btn_PTLMoveDown.Size = new Size(75, 23);
		Btn_PTLMoveDown.TabIndex = 2;
		Btn_PTLMoveDown.Text = "下移";
		Btn_PTLMoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Btn_PTLMoveUp.BackColor = Color.Transparent;
		Btn_PTLMoveUp.DialogResult = DialogResult.None;
		Btn_PTLMoveUp.ForeColor = SystemColors.Control;
		Btn_PTLMoveUp.Location = new Point(332, 610);
		Btn_PTLMoveUp.Name = "Btn_PTLMoveUp";
		Btn_PTLMoveUp.RoundRadius = 0;
		Btn_PTLMoveUp.Size = new Size(75, 23);
		Btn_PTLMoveUp.TabIndex = 1;
		Btn_PTLMoveUp.Text = "上移";
		List_TargetPriority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		List_TargetPriority.Location = new Point(3, 28);
		List_TargetPriority.Name = "List_TargetPriority";
		List_TargetPriority.RelatedInfos = null;
		List_TargetPriority.Size = new Size(996, 553);
		List_TargetPriority.TabIndex = 0;
		List_TargetPriority.Text = "DarkListView1";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 691);
		base.Controls.Add(TabControl1A);
		base.KeyPreview = true;
		base.Location = new Point(0, 0);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DoctrineForm";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "条令窗口";
		UseIntervalGroup.ResumeLayout(performLayout: false);
		EmissionIntervalTABControl.ResumeLayout(performLayout: false);
		((ISupportInitialize)TGV_WRA).EndInit();
		TabControl1A.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
		EmissionIntervalPhonyTab.ResumeLayout(performLayout: false);
		EmissionIntervalPhonyTab.PerformLayout();
		WakeGroupBox.ResumeLayout(performLayout: false);
		WakeGroupBox.PerformLayout();
		IncludesIDGroup.ResumeLayout(performLayout: false);
		IncludesIDGroup.PerformLayout();
		Includes.ResumeLayout(performLayout: false);
		Includes.PerformLayout();
		TabPage3.ResumeLayout(performLayout: false);
		TabPage4.ResumeLayout(performLayout: false);
		TabPage4.PerformLayout();
		TabPage5.ResumeLayout(performLayout: false);
		TabPage5.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			Subject = null;
			SelectedUnits = null;
			recordOrder = null;
			m_ExceptionOrder = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		if (base.ParentForm == null)
		{
			Keys[] taskSpecification = m_TaskSpecification;
			int num = 0;
			while (true)
			{
				if (num < taskSpecification.Length)
				{
					Keys keys = taskSpecification[num];
					if (keyData == keys)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			Close();
			return true;
		}
		return false;
	}

	private void VisitSingleton(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (!bool_1 && !bool_3 && !Information.IsNothing(scenarioObject_0) && scenarioObject_0.IsActiveUnit && ((ActiveUnit)scenarioObject_0).IsOperating() && (!bool_0 || scenarioObject_0 == Client.SelectedUnit) && !Information.IsNothing(nullable_0) && base.Visible && (scenarioObject_0 == Subject || Information.IsNothing(Subject)) && TabControl1A.SelectedIndex == 0)
			{
				DefineSingleton();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 999999", "");
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	private void RestartSingleton(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		try
		{
			if (!bool_1 && !bool_3 && !Information.IsNothing(scenarioObject_0) && scenarioObject_0.IsActiveUnit && (!bool_0 || scenarioObject_0 == Client.SelectedUnit) && watcherSpecification && !Information.IsNothing(nullable_0) && base.Visible && (scenarioObject_0 == Subject || Information.IsNothing(Subject)) && TabControl1A.SelectedIndex == 1)
			{
				DefineSingleton();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 999999", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void TestSingleton(object sender, EventArgs e)
	{
		Doctrine.DoctrineChanged += VisitSingleton;
		Doctrine.EmconChanged += RestartSingleton;
		TabControl1A.SizeMode = TabSizeMode.Normal;
		StopSingleton();
		TabControl1A.SelectedIndex = 0;
		DefineSingleton();
		IntermittentEmissionSelectedAlertLevel = null;
		SortException();
		IntervalComboboxReference = new int[12]
		{
			1, 5, 10, 15, 30, 45, 60, 300, 600, 900,
			3600, 7200
		};
		CancelSingleton();
	}

	private void StopSingleton()
	{
		if (!Information.IsNothing(SelectedUnits) && SelectedUnits.Count > 0)
		{
			if (isAirOps)
			{
				Text = "在地面上飞机的条令和交战规则";
			}
			else if (isBoatOps)
			{
				Text = "停靠舰船的条令 & 交战规则";
			}
			else
			{
				Text = "多个单元的条令和交战规则";
			}
			recordOrder = ValidateException();
			return;
		}
		if (!Information.IsNothing(Subject))
		{
			if ((object)Subject.GetType() == typeof(Side))
			{
				Text = "分方的条令和交战规则：" + ((Side)Subject).Name;
				recordOrder = ((Side)Subject).Doctrine;
			}
			else if (Subject.IsMission)
			{
				if (isEscorts)
				{
					Text = "任务护航的条令和交战规则：" + ((Mission)Subject).Name;
					recordOrder = ((Strike)Subject).Doctrine_Escorts;
				}
				else
				{
					Text = "任务的条令和交战规则：" + ((Mission)Subject).Name;
					recordOrder = ((Mission)Subject).Doctrine;
				}
			}
			else if ((object)Subject.GetType() == typeof(Group))
			{
				Text = "编队的条令和交战规则：" + ((Group)Subject).Name;
				recordOrder = ((Group)Subject).Doctrine;
			}
			else if ((object)Subject.GetType() == typeof(Waypoint))
			{
				string text = ((Waypoint)Subject).Name;
				if (string.IsNullOrEmpty(text))
				{
					text = "没有命名";
				}
				Text = "航点的条令和交战规则：" + text + "（类型：" + Waypoint.GetWaypointTypeString(((Waypoint)Subject).Type) + ")";
				recordOrder = ((Waypoint)Subject).Doctrine;
			}
			else if (Subject.IsActiveUnit)
			{
				Text = "单元的条令和交战规则：" + ((ActiveUnit)Subject).Name;
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				recordOrder = activeUnit.Doctrine;
			}
		}
		if (!Information.IsNothing(recordOrder))
		{
			recordOrder.ClearCachedParentDoctrine();
		}
	}

	private void CancelSingleton()
	{
		float[] tabStops = new float[4]
		{
			DarkLabel_4.Left - List_TargetPriority.Left,
			DarkLabel_3.Left - DarkLabel_4.Left,
			DarkLabel_2.Left - DarkLabel_3.Left,
			DarkLabel_1.Left - DarkLabel_2.Left
		};
		List_TargetPriority.tabStops = tabStops;
	}

	private void VerifySingleton()
	{
		NewException();
		if (Information.IsNothing(Subject))
		{
			Button_ResetCurrent_Doctrine.Enabled = true;
			Button_ResetAffectedUnits_Doctrine.Enabled = false;
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsGroup)
				{
					Button_ResetAffectedUnits_Doctrine.Enabled = true;
					break;
				}
			}
			Button_ResetAffectedMissions_Doctrine.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Side))
		{
			Button_ResetCurrent_Doctrine.Enabled = false;
			Button_ResetAffectedUnits_Doctrine.Enabled = true;
			Button_ResetAffectedMissions_Doctrine.Enabled = true;
		}
		else if (Subject.IsMission)
		{
			Button_ResetCurrent_Doctrine.Enabled = true;
			Button_ResetAffectedUnits_Doctrine.Enabled = true;
			Button_ResetAffectedMissions_Doctrine.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Group))
		{
			Button_ResetCurrent_Doctrine.Enabled = true;
			Button_ResetAffectedUnits_Doctrine.Enabled = true;
			Button_ResetAffectedMissions_Doctrine.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Waypoint))
		{
			Button_ResetCurrent_Doctrine.Enabled = false;
			Button_ResetAffectedUnits_Doctrine.Enabled = false;
			Button_ResetAffectedMissions_Doctrine.Enabled = false;
		}
		else
		{
			Button_ResetCurrent_Doctrine.Enabled = true;
			Button_ResetAffectedUnits_Doctrine.Enabled = false;
			Button_ResetAffectedMissions_Doctrine.Enabled = false;
		}
		Doctrine doctrine = null;
		Doctrine doctrine12 = null;
		if (SelectedUnits == null)
		{
			if (Subject.IsActiveUnit && Subject.IsGroup)
			{
				doctrine12 = GetException((Group)Subject);
				Doctrine doctrine23 = recordOrder;
				Scenario currentScenario = Client.CurrentScenario;
				bool bool_ = true;
				doctrine = doctrine23.GetParentDoctrine(currentScenario, ref bool_);
			}
			else if (Subject.IsActiveUnit)
			{
				Doctrine doctrine34 = recordOrder;
				Scenario currentScenario12 = Client.CurrentScenario;
				bool bool_2 = true;
				doctrine = doctrine34.GetParentDoctrine(currentScenario12, ref bool_2);
				doctrine12 = recordOrder;
			}
		}
		else
		{
			recordOrder = ValidateException();
		}
		if (recordOrder == null)
		{
			return;
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			Label30.Visible = false;
		}
		Color empty = Color.Empty;
		Color red = Color.Red;
		Color yellow = Color.Yellow;
		Color orange = Color.Orange;
		CB_UseNukes_PlayerEditable.Checked = recordOrder.GetNukesAllowed_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_UseNukes_PlayerEditable.Enabled = false;
			Combo_UseNukes.Enabled = recordOrder.GetNukesAllowed_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine45 = recordOrder;
			Scenario currentScenario23 = Client.CurrentScenario;
			Doctrine._UseNukesAllowed? nukesAllowed;
			Doctrine._UseNukesAllowed? useNukesAllowed = (nukesAllowed = recordOrder.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine45.GetRepository(currentScenario23, useNukesAllowed.HasValue ? nukesAllowed : doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label12.ForeColor = empty;
		}
		Doctrine doctrine56 = recordOrder;
		DarkUIComboBox combo_UseNukes = Combo_UseNukes;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine56.Populate_Combo_UseNukes(combo_UseNukes, ref scenario_, m_ParamsOrder);
		CB_WeaponControlStatus_Air_PlayerEditable.Checked = recordOrder.GetWeaponControlStatus_Air_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponControlStatus_Air_PlayerEditable.Enabled = false;
			Combo_WeaponControlStatus_Air.Enabled = recordOrder.GetWeaponControlStatus_Air_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false), doctrine12.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine67 = recordOrder;
			Scenario currentScenario33 = Client.CurrentScenario;
			Doctrine._WCS? weaponControlStatus_Air;
			Doctrine._WCS? wCS = (weaponControlStatus_Air = recordOrder.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
			if (doctrine67.GetRepository(currentScenario33, wCS.HasValue ? weaponControlStatus_Air : doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false), doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label13.ForeColor = empty;
		}
		Doctrine doctrine75 = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Air = Combo_WeaponControlStatus_Air;
		scenario_ = Client.CurrentScenario;
		doctrine75.Populate_Combo_WeaponControlStatus_Air(combo_WeaponControlStatus_Air, ref scenario_, _InfoOrder);
		CB_WeaponControlStatus_Surface_PlayerEditable.Checked = recordOrder.GetWeaponControlStatus_Surface_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponControlStatus_Surface_PlayerEditable.Enabled = false;
			Combo_WeaponControlStatus_Surface.Enabled = recordOrder.GetWeaponControlStatus_Surface_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false), doctrine12.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine76 = recordOrder;
			Scenario currentScenario34 = Client.CurrentScenario;
			Doctrine._WCS? weaponControlStatus_Surface;
			Doctrine._WCS? wCS2 = (weaponControlStatus_Surface = recordOrder.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
			if (doctrine76.GetRepository(currentScenario34, wCS2.HasValue ? weaponControlStatus_Surface : doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false), doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label2.ForeColor = empty;
		}
		Doctrine doctrine2 = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Surface = Combo_WeaponControlStatus_Surface;
		scenario_ = Client.CurrentScenario;
		doctrine2.Populate_Combo_WeaponControlStatus_Surface(combo_WeaponControlStatus_Surface, ref scenario_, _HelperOrder);
		CB_WeaponControlStatus_Submarine_PlayerEditable.Checked = recordOrder.GetWeaponControlStatus_Submarine_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponControlStatus_Submarine_PlayerEditable.Enabled = false;
			Combo_WeaponControlStatus_Submarine.Enabled = recordOrder.GetWeaponControlStatus_Submarine_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false), doctrine12.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine3 = recordOrder;
			Scenario currentScenario35 = Client.CurrentScenario;
			Doctrine._WCS? weaponControlStatus_Submarine;
			Doctrine._WCS? wCS3 = (weaponControlStatus_Submarine = recordOrder.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
			if (doctrine3.GetRepository(currentScenario35, wCS3.HasValue ? weaponControlStatus_Submarine : doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false), doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label23.ForeColor = empty;
		}
		Doctrine doctrine4 = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Submarine = Combo_WeaponControlStatus_Submarine;
		scenario_ = Client.CurrentScenario;
		doctrine4.Populate_Combo_WeaponControlStatus_Submarine(combo_WeaponControlStatus_Submarine, ref scenario_, m_MapperOrder);
		CB_WeaponControlStatus_Land_PlayerEditable.Checked = recordOrder.GetWeaponControlStatus_Land_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponControlStatus_Land_PlayerEditable.Enabled = false;
			Combo_WeaponControlStatus_Land.Enabled = recordOrder.GetWeaponControlStatus_Land_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false), doctrine12.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine5 = recordOrder;
			Scenario currentScenario36 = Client.CurrentScenario;
			Doctrine._WCS? weaponControlStatus_Land;
			Doctrine._WCS? wCS4 = (weaponControlStatus_Land = recordOrder.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
			if (doctrine5.GetRepository(currentScenario36, wCS4.HasValue ? weaponControlStatus_Land : doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false), doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label26.ForeColor = empty;
		}
		Doctrine doctrine6 = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Land = Combo_WeaponControlStatus_Land;
		scenario_ = Client.CurrentScenario;
		doctrine6.Populate_Combo_WeaponControlStatus_Land(combo_WeaponControlStatus_Land, ref scenario_, m_ManagerOrder);
		CB_GunStrafing_PlayerEditable.Checked = recordOrder.GetGunStrafing_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_GunStrafing_PlayerEditable.Enabled = false;
			Combo_GunStrafing.Enabled = recordOrder.GetGunStrafing_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetGunStrafing(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine7 = recordOrder;
			Scenario currentScenario37 = Client.CurrentScenario;
			Doctrine._GunStrafeGroundTargets? gunStrafing;
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = (gunStrafing = recordOrder.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine7.GetRepository(currentScenario37, gunStrafeGroundTargets.HasValue ? gunStrafing : doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label27.ForeColor = empty;
		}
		Doctrine doctrine8 = recordOrder;
		DarkUIComboBox combo_GunStrafing = Combo_GunStrafing;
		scenario_ = Client.CurrentScenario;
		doctrine8.Populate_Combo_GunStrafing(combo_GunStrafing, ref scenario_, observerSpecification);
		CB_IgnorePlottedCourse_PlayerEditable.Checked = recordOrder.GetIgnorePlottedCourse_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_IgnorePlottedCourse_PlayerEditable.Enabled = false;
			Combo_IgnorePlottedCourse.Enabled = recordOrder.GetIgnorePlottedCourse_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false), doctrine12.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine9 = recordOrder;
			Scenario currentScenario38 = Client.CurrentScenario;
			Doctrine._UseIgnorePlottedCourse? ignorePlottedCourse;
			Doctrine._UseIgnorePlottedCourse? useIgnorePlottedCourse = (ignorePlottedCourse = recordOrder.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
			if (doctrine9.GetRepository(currentScenario38, useIgnorePlottedCourse.HasValue ? ignorePlottedCourse : doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false), doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: true, false, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label1.ForeColor = empty;
		}
		Doctrine doctrine10 = recordOrder;
		DarkUIComboBox combo_IgnorePlottedCourse = Combo_IgnorePlottedCourse;
		scenario_ = Client.CurrentScenario;
		doctrine10.Populate_Combo_IgnorePlottedCourse(combo_IgnorePlottedCourse, ref scenario_, m_GetterOrder);
		CB_WeaponStateRTB_PlayerEditable.Checked = recordOrder.GetWinchesterShotgunRTB_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponStateRTB_PlayerEditable.Enabled = false;
			Combo_WeaponStateRTB.Enabled = recordOrder.GetWinchesterShotgunRTB_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine11 = recordOrder;
			Scenario currentScenario2 = Client.CurrentScenario;
			Doctrine._WeaponStateRTB? winchesterShotgunRTB;
			Doctrine._WeaponStateRTB? weaponStateRTB = (winchesterShotgunRTB = recordOrder.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine11.GetRepository(currentScenario2, weaponStateRTB.HasValue ? winchesterShotgunRTB : doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label4.ForeColor = empty;
		}
		Doctrine doctrine13 = recordOrder;
		DarkUIComboBox combo_WeaponStateRTB = Combo_WeaponStateRTB;
		scenario_ = Client.CurrentScenario;
		doctrine13.Populate_Combo_WinchesterShotgunRTB(combo_WeaponStateRTB, ref scenario_, _ProducerOrder);
		CB_FuelStateRTB_PlayerEditable.Checked = recordOrder.GetBingoJokerRTB_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_FuelStateRTB_PlayerEditable.Enabled = false;
			Combo_FuelStateRTB.Enabled = recordOrder.GetBingoJokerRTB_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetBingoJokerRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine14 = recordOrder;
			Scenario currentScenario3 = Client.CurrentScenario;
			Doctrine._FuelStateRTB? bingoJokerRTB;
			Doctrine._FuelStateRTB? fuelStateRTB = (bingoJokerRTB = recordOrder.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine14.GetRepository(currentScenario3, fuelStateRTB.HasValue ? bingoJokerRTB : doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label32.ForeColor = empty;
		}
		Doctrine doctrine15 = recordOrder;
		DarkUIComboBox combo_FuelStateRTB = Combo_FuelStateRTB;
		scenario_ = Client.CurrentScenario;
		doctrine15.Populate_Combo_BingoJokerRTB(combo_FuelStateRTB, ref scenario_, procOrder);
		CB_JettisonOrdnance_PlayerEditable.Checked = recordOrder.GetJettisonOrdnance_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_JettisonOrdnance_PlayerEditable.Enabled = false;
			Combo_Jettison.Enabled = recordOrder.GetJettisonOrdnance_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetJettison(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine16 = recordOrder;
			Scenario currentScenario4 = Client.CurrentScenario;
			Doctrine._JettisonOrdnance? jettison;
			Doctrine._JettisonOrdnance? jettisonOrdnance = (jettison = recordOrder.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine16.GetRepository(currentScenario4, jettisonOrdnance.HasValue ? jettison : doctrine.GetJettison(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetJettison(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label31.ForeColor = empty;
		}
		Doctrine doctrine17 = recordOrder;
		DarkUIComboBox combo_Jettison = Combo_Jettison;
		scenario_ = Client.CurrentScenario;
		doctrine17.Populate_Combo_JettisonOrdnance(combo_Jettison, ref scenario_, m_StructSpecification);
		CB_BVRLogic_PlayerEditable.Checked = recordOrder.GetBVRLogic_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_BVRLogic_PlayerEditable.Enabled = false;
			Combo_BVRLogic.Enabled = recordOrder.GetBVRLogic_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.method_0(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine18 = recordOrder;
			Scenario currentScenario5 = Client.CurrentScenario;
			Doctrine._BVRLogicEnum? bVRLogicEnum;
			Doctrine._BVRLogicEnum? bVRLogicEnum2 = (bVRLogicEnum = recordOrder.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine18.GetRepository(currentScenario5, bVRLogicEnum2.HasValue ? bVRLogicEnum : doctrine.method_0(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.method_0(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label52.ForeColor = empty;
		}
		Doctrine doctrine19 = recordOrder;
		DarkUIComboBox combo_BVRLogic = Combo_BVRLogic;
		scenario_ = Client.CurrentScenario;
		doctrine19.Populate_Combo_BVRLogic(combo_BVRLogic, ref scenario_, _MerchantSpecification);
		CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Checked = recordOrder.GetBehaviorTowardsAmbigousTarget_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Enabled = false;
			Combo_BehaviorTowardsAmbigousTarget.Enabled = recordOrder.GetBehaviorTowardsAmbigousTarget_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine20 = recordOrder;
			Scenario currentScenario6 = Client.CurrentScenario;
			Doctrine._BehaviorTowardsTargetAmbiguity? behaviorTowardsAmbigousTarget;
			Doctrine._BehaviorTowardsTargetAmbiguity? behaviorTowardsTargetAmbiguity = (behaviorTowardsAmbigousTarget = recordOrder.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine20.GetRepository(currentScenario6, behaviorTowardsTargetAmbiguity.HasValue ? behaviorTowardsAmbigousTarget : doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label5.ForeColor = empty;
		}
		Doctrine doctrine21 = recordOrder;
		DarkUIComboBox combo_BehaviorTowardsAmbigousTarget = Combo_BehaviorTowardsAmbigousTarget;
		scenario_ = Client.CurrentScenario;
		doctrine21.Populate_Combo_BehaviorTowardsAmbigousTarget(combo_BehaviorTowardsAmbigousTarget, ref scenario_, m_CallbackSpecification);
		CB_AutoEvade_PlayerEditable.Checked = recordOrder.GetAutoEvade_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_AutoEvade_PlayerEditable.Enabled = false;
			Combo_AutoEvade.Enabled = recordOrder.GetAutoEvade_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine22 = recordOrder;
			Scenario currentScenario7 = Client.CurrentScenario;
			Doctrine._UseAutoEvade? autoEvade;
			Doctrine._UseAutoEvade? useAutoEvade = (autoEvade = recordOrder.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine22.GetRepository(currentScenario7, useAutoEvade.HasValue ? autoEvade : doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label17.ForeColor = empty;
		}
		Doctrine doctrine24 = recordOrder;
		DarkUIComboBox combo_AutoEvade = Combo_AutoEvade;
		scenario_ = Client.CurrentScenario;
		doctrine24.Populate_Combo_AutoEvade(combo_AutoEvade, ref scenario_, m_DecoratorSpecification);
		CB_Standoff_PlayerEditable.Checked = recordOrder.GetMaintainStandoff_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_Standoff_PlayerEditable.Enabled = false;
			Combo_Standoff.Enabled = recordOrder.GetMaintainStandoff_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine25 = recordOrder;
			Scenario currentScenario8 = Client.CurrentScenario;
			Doctrine._UseMaintainStandoff? maintainStandoff;
			Doctrine._UseMaintainStandoff? useMaintainStandoff = (maintainStandoff = recordOrder.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine25.GetRepository(currentScenario8, useMaintainStandoff.HasValue ? maintainStandoff : doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label6.ForeColor = empty;
		}
		Doctrine doctrine26 = recordOrder;
		DarkUIComboBox combo_Standoff = Combo_Standoff;
		scenario_ = Client.CurrentScenario;
		doctrine26.Populate_Combo_Standoff(combo_Standoff, ref scenario_, m_ProcessSpecification);
		CB_UseRefuel_PlayerEditable.Checked = recordOrder.GetUseReplenishment_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_UseRefuel_PlayerEditable.Enabled = false;
			Combo_UseRefuel.Enabled = recordOrder.GetUseReplenishment_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetUseReplenishment(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine27 = recordOrder;
			Scenario currentScenario9 = Client.CurrentScenario;
			Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment;
			Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = (useReplenishment = recordOrder.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine27.GetRepository(currentScenario9, useUnderwayRefuelAndReplenishment.HasValue ? useReplenishment : doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label10.ForeColor = empty;
		}
		Doctrine doctrine28 = recordOrder;
		DarkUIComboBox combo_UseRefuel = Combo_UseRefuel;
		scenario_ = Client.CurrentScenario;
		doctrine28.Populate_Combo_UseRefuel(combo_UseRefuel, ref scenario_, threadSpecification);
		CB_ReplenishmentSelection_PlayerEditable.Checked = recordOrder.GetReplenishmentSelection_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_ReplenishmentSelection_PlayerEditable.Enabled = false;
			Combo_ReplenishmentSelection.Enabled = recordOrder.GetReplenishmentSelection_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetReplenishmentSelection(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine29 = recordOrder;
			Scenario currentScenario10 = Client.CurrentScenario;
			Doctrine._UnderwayRefuelAndReplenishmentSelection? replenishmentSelection;
			Doctrine._UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection = (replenishmentSelection = recordOrder.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine29.GetRepository(currentScenario10, underwayRefuelAndReplenishmentSelection.HasValue ? replenishmentSelection : doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label51.ForeColor = empty;
		}
		Doctrine doctrine30 = recordOrder;
		DarkUIComboBox combo_ReplenishmentSelection = Combo_ReplenishmentSelection;
		scenario_ = Client.CurrentScenario;
		doctrine30.Populate_Combo_ReplenishmentSelection(combo_ReplenishmentSelection, ref scenario_, _RuleSpecification);
		CB_ShootTourists_PlayerEditable.Checked = recordOrder.GetShootTourists_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_ShootTourists_PlayerEditable.Enabled = false;
			Combo_ShootTourists.Enabled = recordOrder.GetShootTourists_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetShootTourists(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine31 = recordOrder;
			Scenario currentScenario11 = Client.CurrentScenario;
			Doctrine._UseShootTourists? shootTourists;
			Doctrine._UseShootTourists? useShootTourists = (shootTourists = recordOrder.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine31.GetRepository(currentScenario11, useShootTourists.HasValue ? shootTourists : doctrine.GetShootTourists(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetShootTourists(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label11.ForeColor = empty;
		}
		Doctrine doctrine32 = recordOrder;
		DarkUIComboBox combo_ShootTourists = Combo_ShootTourists;
		scenario_ = Client.CurrentScenario;
		doctrine32.Populate_Combo_ShootTourists(combo_ShootTourists, ref scenario_, m_CollectionSpecification);
		CB_UseSAMsOnASuW_PlayerEditable.Checked = recordOrder.GetUseSAMsOnASuW_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_UseSAMsOnASuW_PlayerEditable.Enabled = false;
			Combo_UseSAMsOnASuW.Enabled = recordOrder.GetUseSAMsOnASuW_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine33 = recordOrder;
			Scenario currentScenario13 = Client.CurrentScenario;
			Doctrine._UseSAMsAgainstShips? useSAMsOnASuW;
			Doctrine._UseSAMsAgainstShips? useSAMsAgainstShips = (useSAMsOnASuW = recordOrder.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine33.GetRepository(currentScenario13, useSAMsAgainstShips.HasValue ? useSAMsOnASuW : doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label14.ForeColor = empty;
		}
		Doctrine doctrine35 = recordOrder;
		DarkUIComboBox combo_UseSAMsOnASuW = Combo_UseSAMsOnASuW;
		scenario_ = Client.CurrentScenario;
		doctrine35.Populate_Combo_UseSAMsOnASuW(combo_UseSAMsOnASuW, ref scenario_, _InstanceSpecification);
		CB_UseWPMissilesOnASuW.Checked = recordOrder.GetUseWPMissileOnASuW_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_UseWPMissilesOnASuW.Enabled = false;
			Combo_UseWPMissilesOnASuW.Enabled = recordOrder.GetUseWPMissileOnASuW_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetUseWPMissileOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetUseWPMissileOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine36 = recordOrder;
			Scenario currentScenario14 = Client.CurrentScenario;
			Doctrine._UseWpMissileAgainstShips? useWPMissileOnASuW;
			Doctrine._UseWpMissileAgainstShips? useWpMissileAgainstShips = (useWPMissileOnASuW = recordOrder.GetUseWPMissileOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine36.GetRepository(currentScenario14, useWpMissileAgainstShips.HasValue ? useWPMissileOnASuW : doctrine.GetUseWPMissileOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetUseWPMissileOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label14.ForeColor = empty;
		}
		Doctrine doctrine37 = recordOrder;
		DarkUIComboBox combo_UseWPMissilesOnASuW = Combo_UseWPMissilesOnASuW;
		scenario_ = Client.CurrentScenario;
		doctrine37.Populate_Combo_UseWPWeaponOnASuW(combo_UseWPMissilesOnASuW, ref scenario_, objectSpecification);
		CB_IgnoreEMCONunderAttack_PlayerEditable.Checked = recordOrder.GetIgnoreEMCONunderAttack_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_IgnoreEMCONunderAttack_PlayerEditable.Enabled = false;
			Combo_IgnoreEMCONunderAttack.Enabled = recordOrder.GetIgnoreEMCONunderAttack_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine38 = recordOrder;
			Scenario currentScenario15 = Client.CurrentScenario;
			Doctrine._UseIgnoreEMCONunderAttack? ignoreEMCONunderAttack;
			Doctrine._UseIgnoreEMCONunderAttack? useIgnoreEMCONunderAttack = (ignoreEMCONunderAttack = recordOrder.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine38.GetRepository(currentScenario15, useIgnoreEMCONunderAttack.HasValue ? ignoreEMCONunderAttack : doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label15.ForeColor = empty;
		}
		Doctrine doctrine39 = recordOrder;
		DarkUIComboBox combo_IgnoreEMCONunderAttack = Combo_IgnoreEMCONunderAttack;
		scenario_ = Client.CurrentScenario;
		doctrine39.Populate_Combo_IgnoreEMCONunderAttack(combo_IgnoreEMCONunderAttack, ref scenario_, _ParameterSpecification);
		CB_QuickTurnAroundForAicraft_PlayerEditable.Checked = recordOrder.GetQuickTurnAroundForAicraft_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_QuickTurnAroundForAicraft_PlayerEditable.Enabled = false;
			Combo_QuickTurnAroundForAicraft.Enabled = recordOrder.GetQuickTurnAroundForAicraft_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine40 = recordOrder;
			Scenario currentScenario16 = Client.CurrentScenario;
			Doctrine._QuickTurnAroundForAicraft? quickTurnAroundForAicraft;
			Doctrine._QuickTurnAroundForAicraft? quickTurnAroundForAicraft2 = (quickTurnAroundForAicraft = recordOrder.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine40.GetRepository(currentScenario16, quickTurnAroundForAicraft2.HasValue ? quickTurnAroundForAicraft : doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label7.ForeColor = empty;
		}
		Doctrine doctrine41 = recordOrder;
		DarkUIComboBox combo_QuickTurnAroundForAicraft = Combo_QuickTurnAroundForAicraft;
		scenario_ = Client.CurrentScenario;
		doctrine41.Populate_Combo_QuickTurnAroundForAicraft(combo_QuickTurnAroundForAicraft, ref scenario_, ref UnitIsOperating, expressionSpecification);
		CB_AirOpsTempo_PlayerEditable.Checked = recordOrder.GetAirOpsTempo_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_AirOpsTempo_PlayerEditable.Enabled = false;
			Combo_AirOpsTempo.Enabled = recordOrder.GetAirOpsTempo_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetAirOpsTempo(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine42 = recordOrder;
			Scenario currentScenario17 = Client.CurrentScenario;
			Doctrine._AirOpsTempo? airOpsTempo;
			Doctrine._AirOpsTempo? airOpsTempo2 = (airOpsTempo = recordOrder.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine42.GetRepository(currentScenario17, airOpsTempo2.HasValue ? airOpsTempo : doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label8.ForeColor = empty;
		}
		Doctrine doctrine43 = recordOrder;
		DarkUIComboBox combo_AirOpsTempo = Combo_AirOpsTempo;
		scenario_ = Client.CurrentScenario;
		doctrine43.Populate_Combo_AirOpsTempo(combo_AirOpsTempo, ref scenario_, ref UnitIsOperating, _DispatcherSpecification);
		CB_FuelState_PlayerEditable.Checked = recordOrder.GetBingoJoker_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_FuelState_PlayerEditable.Enabled = false;
			Combo_FuelState.Enabled = recordOrder.GetBingoJoker_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetBingoJoker(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine44 = recordOrder;
			Scenario currentScenario18 = Client.CurrentScenario;
			Doctrine._FuelState? bingoJoker;
			Doctrine._FuelState? fuelState = (bingoJoker = recordOrder.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine44.GetRepository(currentScenario18, fuelState.HasValue ? bingoJoker : doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label32.ForeColor = empty;
		}
		Doctrine doctrine46 = recordOrder;
		DarkUIComboBox combo_FuelState = Combo_FuelState;
		scenario_ = Client.CurrentScenario;
		doctrine46.Populate_Combo_BingoJoker(combo_FuelState, ref scenario_, ref UnitIsOperating, m_ListenerSpecification);
		CB_WeaponState_PlayerEditable.Checked = recordOrder.GetWinchesterShotgun_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_WeaponState_PlayerEditable.Enabled = false;
			Combo_WeaponState.Enabled = recordOrder.GetWinchesterShotgun_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false), doctrine12.GetWinchesterShotgun(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine47 = recordOrder;
			Scenario currentScenario19 = Client.CurrentScenario;
			Doctrine._WeaponState? winchesterShotgun;
			Doctrine._WeaponState? weaponState = (winchesterShotgun = recordOrder.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
			if (doctrine47.GetRepository(currentScenario19, weaponState.HasValue ? winchesterShotgun : doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false), doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label29.ForeColor = empty;
		}
		Doctrine doctrine48 = recordOrder;
		DarkUIComboBox combo_WeaponState = Combo_WeaponState;
		scenario_ = Client.CurrentScenario;
		doctrine48.Populate_Combo_WinchesterShotgun(combo_WeaponState, ref scenario_, ref UnitIsOperating, _ConfigSpecification);
		CB_UseKinematicRangeForTorpedoes_PlayerEditable.Checked = recordOrder.GetUseKinematicRangeForTorpedoes_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_UseKinematicRangeForTorpedoes_PlayerEditable.Enabled = false;
			Combo_UseKinematicRangeForTorpedoes.Enabled = recordOrder.GetUseKinematicRangeForTorpedoes_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine49 = recordOrder;
			Scenario currentScenario20 = Client.CurrentScenario;
			Doctrine._UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes;
			Doctrine._UseKinematicRangeForTorpedoes? useKinematicRangeForTorpedoes2 = (useKinematicRangeForTorpedoes = recordOrder.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine49.GetRepository(currentScenario20, useKinematicRangeForTorpedoes2.HasValue ? useKinematicRangeForTorpedoes : doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label16.ForeColor = empty;
		}
		Doctrine doctrine50 = recordOrder;
		DarkUIComboBox combo_UseKinematicRangeForTorpedoes = Combo_UseKinematicRangeForTorpedoes;
		scenario_ = Client.CurrentScenario;
		doctrine50.Populate_Combo_UseKinematicRangeForTorpedoes(combo_UseKinematicRangeForTorpedoes, ref scenario_, _RegistrySpecification);
		CB_RefuelAllies_PlayerEditable.Checked = recordOrder.GetRefuelAllies_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_RefuelAllies_PlayerEditable.Enabled = false;
			Combo_RefuelAllies.Enabled = recordOrder.GetRefuelAllies_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine51 = recordOrder;
			Scenario currentScenario21 = Client.CurrentScenario;
			Doctrine._RefuelAlliedUnits? refuelAllies;
			Doctrine._RefuelAlliedUnits? refuelAlliedUnits = (refuelAllies = recordOrder.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine51.GetRepository(currentScenario21, refuelAlliedUnits.HasValue ? refuelAllies : doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label33.ForeColor = empty;
		}
		Doctrine doctrine52 = recordOrder;
		DarkUIComboBox combo_RefuelAllies = Combo_RefuelAllies;
		scenario_ = Client.CurrentScenario;
		doctrine52.Populate_Combo_RefuelAllies(combo_RefuelAllies, ref scenario_, issuerSpecification);
		CB_BongoThreshold_PlayerEditable.Checked = recordOrder.GetBingoRefuel_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_BongoThreshold_PlayerEditable.Enabled = false;
			BingoThresholdCombo.Enabled = recordOrder.GetBingoRefuel_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine53 = recordOrder;
			Scenario currentScenario22 = Client.CurrentScenario;
			Doctrine._BingoThreshold_E? bingoThreshold;
			Doctrine._BingoThreshold_E? bingoThreshold_E = (bingoThreshold = recordOrder.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine53.GetRepository(currentScenario22, bingoThreshold_E.HasValue ? bingoThreshold : doctrine.GetBingoThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetBingoThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			DarkLabel8.ForeColor = empty;
		}
		Doctrine doctrine54 = recordOrder;
		DarkUIComboBox bingoThresholdCombo = BingoThresholdCombo;
		scenario_ = Client.CurrentScenario;
		doctrine54.Populate_Combo_BingoRefuel(bingoThresholdCombo, ref scenario_, clientSpecification);
		CB_AvoidContact_PlayerEditable.Checked = recordOrder.GetAvoidContact_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_AvoidContact_PlayerEditable.Enabled = false;
			Combo_AvoidContact.Enabled = recordOrder.GetAvoidContact_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine55 = recordOrder;
			Scenario currentScenario24 = Client.CurrentScenario;
			Doctrine._AvoidContactWhenPossible? avoidContact;
			Doctrine._AvoidContactWhenPossible? avoidContactWhenPossible = (avoidContact = recordOrder.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine55.GetRepository(currentScenario24, avoidContactWhenPossible.HasValue ? avoidContact : doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label35.ForeColor = empty;
		}
		Doctrine doctrine57 = recordOrder;
		DarkUIComboBox combo_AvoidContact = Combo_AvoidContact;
		scenario_ = Client.CurrentScenario;
		doctrine57.Populate_Combo_AvoidContact(combo_AvoidContact, ref scenario_, m_DicSpecification);
		CB_DiveWhenThreatsDetected_PlayerEditable.Checked = recordOrder.GetDiveWhenThreatsDetected_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_DiveWhenThreatsDetected_PlayerEditable.Enabled = false;
			Combo_DiveWhenThreatsDetected.Enabled = recordOrder.GetDiveWhenThreatsDetected_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine58 = recordOrder;
			Scenario currentScenario25 = Client.CurrentScenario;
			Doctrine._DiveOnContact? diveWhenThreatsDetected;
			Doctrine._DiveOnContact? diveOnContact = (diveWhenThreatsDetected = recordOrder.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine58.GetRepository(currentScenario25, diveOnContact.HasValue ? diveWhenThreatsDetected : doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label36.ForeColor = empty;
		}
		Doctrine doctrine59 = recordOrder;
		DarkUIComboBox combo_DiveWhenThreatsDetected = Combo_DiveWhenThreatsDetected;
		scenario_ = Client.CurrentScenario;
		doctrine59.Populate_Combo_DiveWhenThreatsDetected(combo_DiveWhenThreatsDetected, ref scenario_, m_ConsumerSpecification);
		CB_BatteryRechargePatrol_PlayerEditable.Checked = recordOrder.GetRechargePercentagePatrol_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_BatteryRechargePatrol_PlayerEditable.Enabled = false;
			Combo_BatteryRechargePatrol.Enabled = recordOrder.GetRechargePercentagePatrol_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine60 = recordOrder;
			Scenario currentScenario26 = Client.CurrentScenario;
			Doctrine._RechargeBatteryPercentage? rechargePercentagePatrol;
			Doctrine._RechargeBatteryPercentage? rechargeBatteryPercentage = (rechargePercentagePatrol = recordOrder.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine60.GetRepository(currentScenario26, rechargeBatteryPercentage.HasValue ? rechargePercentagePatrol : doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label37.ForeColor = empty;
		}
		Doctrine doctrine61 = recordOrder;
		DarkUIComboBox combo_BatteryRechargePatrol = Combo_BatteryRechargePatrol;
		scenario_ = Client.CurrentScenario;
		doctrine61.Populate_Combo_RechargePercentagePatrol(combo_BatteryRechargePatrol, ref scenario_, facadeSpecification);
		CB_BatteryRechargeAttack_PlayerEditable.Checked = recordOrder.GetRechargePercentageAttack_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_BatteryRechargeAttack_PlayerEditable.Enabled = false;
			Combo_BatteryRechargeAttack.Enabled = recordOrder.GetRechargePercentageAttack_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine62 = recordOrder;
			Scenario currentScenario27 = Client.CurrentScenario;
			Doctrine._RechargeBatteryPercentage? rechargePercentageAttack;
			Doctrine._RechargeBatteryPercentage? rechargeBatteryPercentage2 = (rechargePercentageAttack = recordOrder.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine62.GetRepository(currentScenario27, rechargeBatteryPercentage2.HasValue ? rechargePercentageAttack : doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label38.ForeColor = empty;
		}
		Doctrine doctrine63 = recordOrder;
		DarkUIComboBox combo_BatteryRechargeAttack = Combo_BatteryRechargeAttack;
		scenario_ = Client.CurrentScenario;
		doctrine63.Populate_Combo_RechargePercentageAttack(combo_BatteryRechargeAttack, ref scenario_, _ProxySpecification);
		CB_AIP_Usage_PlayerEditable.Checked = recordOrder.GetAIPUsage_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_AIP_Usage_PlayerEditable.Enabled = false;
			Combo_AIP_Usage.Enabled = recordOrder.GetAIPUsage_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine64 = recordOrder;
			Scenario currentScenario28 = Client.CurrentScenario;
			Doctrine._UseAIP? useAIP;
			Doctrine._UseAIP? useAIP2 = (useAIP = recordOrder.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine64.GetRepository(currentScenario28, useAIP2.HasValue ? useAIP : doctrine.method_2(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.method_2(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label39.ForeColor = empty;
		}
		Doctrine doctrine65 = recordOrder;
		DarkUIComboBox combo_AIP_Usage = Combo_AIP_Usage;
		scenario_ = Client.CurrentScenario;
		doctrine65.Populate_Combo_AIPUsage(combo_AIP_Usage, ref scenario_, m_ReaderSpecification);
		CB_DippingSonar_PlayerEditable.Checked = recordOrder.GetDippingSonar_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_DippingSonar_PlayerEditable.Enabled = false;
			Combo_DippingSonar.Enabled = recordOrder.GetDippingSonar_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine66 = recordOrder;
			Scenario currentScenario29 = Client.CurrentScenario;
			Doctrine._UseDippingSonar? dippingSonar;
			Doctrine._UseDippingSonar? useDippingSonar = (dippingSonar = recordOrder.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine66.GetRepository(currentScenario29, useDippingSonar.HasValue ? dippingSonar : doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			Label40.ForeColor = empty;
		}
		Doctrine doctrine68 = recordOrder;
		DarkUIComboBox combo_DippingSonar = Combo_DippingSonar;
		scenario_ = Client.CurrentScenario;
		doctrine68.Populate_Combo_DippingSonar(combo_DippingSonar, ref scenario_, propertySpecification);
		CB_Surface_Navigation_PlayerEditable.Checked = recordOrder.GetSurfaceNavigation_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_Surface_Navigation_PlayerEditable.Enabled = false;
			Combo_Surface_Navigation.Enabled = recordOrder.GetSurfaceNavigation_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine69 = recordOrder;
			Scenario currentScenario30 = Client.CurrentScenario;
			Doctrine._NavigationMethod? surfaceNavigation;
			Doctrine._NavigationMethod? navigationMethod = (surfaceNavigation = recordOrder.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine69.GetRepository(currentScenario30, navigationMethod.HasValue ? surfaceNavigation : doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			DarkLabel1.ForeColor = empty;
		}
		Doctrine doctrine70 = recordOrder;
		DarkUIComboBox combo_Surface_Navigation = Combo_Surface_Navigation;
		scenario_ = Client.CurrentScenario;
		doctrine70.Populate_Combo_SurfaceNavigation(combo_Surface_Navigation, ref scenario_, _ImporterSpecification);
		CB_Submarine_Navigation_PlayerEditable.Checked = recordOrder.GetSubmarineNavigation_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_Submarine_Navigation_PlayerEditable.Enabled = false;
			Combo_Submarine_Navigation.Enabled = recordOrder.GetSubmarineNavigation_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine71 = recordOrder;
			Scenario currentScenario31 = Client.CurrentScenario;
			Doctrine._NavigationMethod? submarineNavigation;
			Doctrine._NavigationMethod? navigationMethod2 = (submarineNavigation = recordOrder.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine71.GetRepository(currentScenario31, navigationMethod2.HasValue ? submarineNavigation : doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			DarkLabel2.ForeColor = empty;
		}
		Doctrine doctrine72 = recordOrder;
		DarkUIComboBox combo_Submarine_Navigation = Combo_Submarine_Navigation;
		scenario_ = Client.CurrentScenario;
		doctrine72.Populate_Combo_SubmarineNavigation(combo_Submarine_Navigation, ref scenario_, repositorySpecification);
		CB_Land_Navigation_PlayerEditable.Checked = recordOrder.GetLandNavigation_PlayerEditable(Client.CurrentScenario);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_Land_Navigation_PlayerEditable.Enabled = false;
			Combo_Land_Navigation.Enabled = recordOrder.GetLandNavigation_PlayerEditable(Client.CurrentScenario);
		}
		empty = Color.Empty;
		if (doctrine12 != null && recordOrder.GetRepository(Client.CurrentScenario, recordOrder.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false), doctrine12.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false)))
		{
			empty = red;
		}
		if (doctrine != null)
		{
			Doctrine doctrine73 = recordOrder;
			Scenario currentScenario32 = Client.CurrentScenario;
			Doctrine._NavigationMethod? landNavigation;
			Doctrine._NavigationMethod? navigationMethod3 = (landNavigation = recordOrder.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
			if (doctrine73.GetRepository(currentScenario32, navigationMethod3.HasValue ? landNavigation : doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false), doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false)))
			{
				empty = ((empty == Color.Empty) ? yellow : orange);
			}
		}
		if (empty != Color.Empty)
		{
			DarkLabel4.ForeColor = empty;
		}
		Doctrine doctrine74 = recordOrder;
		DarkUIComboBox combo_Land_Navigation = Combo_Land_Navigation;
		scenario_ = Client.CurrentScenario;
		doctrine74.Populate_Combo_LandNavigation(combo_Land_Navigation, ref scenario_, m_BridgeSpecification);
		PushException();
	}

	private void ListSingleton()
	{
		NewException();
		if (Information.IsNothing(Subject))
		{
			Button_ResetCurrent_EMCON.Enabled = true;
			Button_ResetAffectedUnits_EMCON.Enabled = false;
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsGroup)
				{
					Button_ResetAffectedUnits_EMCON.Enabled = true;
					break;
				}
			}
			Button_ResetAffectedMissions_EMCON.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Side))
		{
			Button_ResetCurrent_EMCON.Enabled = false;
			Button_ResetAffectedUnits_EMCON.Enabled = true;
			Button_ResetAffectedMissions_EMCON.Enabled = true;
		}
		else if (Subject.IsMission)
		{
			Button_ResetCurrent_EMCON.Enabled = true;
			Button_ResetAffectedUnits_EMCON.Enabled = true;
			Button_ResetAffectedMissions_EMCON.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Group))
		{
			Button_ResetCurrent_EMCON.Enabled = true;
			Button_ResetAffectedUnits_EMCON.Enabled = true;
			Button_ResetAffectedMissions_EMCON.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Waypoint))
		{
			Button_ResetCurrent_EMCON.Enabled = false;
			Button_ResetAffectedUnits_EMCON.Enabled = false;
			Button_ResetAffectedMissions_EMCON.Enabled = false;
		}
		else
		{
			Button_ResetCurrent_EMCON.Enabled = true;
			Button_ResetAffectedUnits_EMCON.Enabled = false;
			Button_ResetAffectedMissions_EMCON.Enabled = false;
		}
		if (!Information.IsNothing(SelectedUnits))
		{
			recordOrder = ValidateException();
		}
		recordOrder.DoctrineRefresh = true;
		Doctrine doctrine = recordOrder;
		DarkCheckBox cB_EMCON_Inherits = CB_EMCON_Inherits;
		ScenarioObject scenarioObject_ = Subject;
		doctrine.Set_Checkbox_EMCON_Inherit(cB_EMCON_Inherits, ref scenarioObject_, ref recordOrder);
		Subject = scenarioObject_;
		recordOrder.DoctrineRefresh = false;
		Doctrine doctrine2 = recordOrder;
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine2.Populate_Combo_EMCON_Radar(cB_EMCON_Radar, ref scenario_, ref recordOrder);
		Doctrine doctrine3 = recordOrder;
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		scenario_ = Client.CurrentScenario;
		doctrine3.Populate_Combo_EMCON_OECM(cB_EMCON_OECM, ref scenario_, ref recordOrder);
		Doctrine doctrine4 = recordOrder;
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		scenario_ = Client.CurrentScenario;
		doctrine4.Populate_Combo_EMCON_Sonar(cB_EMCON_Sonar, ref scenario_, ref recordOrder);
		PushException();
	}

	private void ResolveSingleton()
	{
		if (_TestsSpecification)
		{
			RefreshSelectedUnits(Subject);
		}
		if (Subject == null)
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = false;
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsGroup)
				{
					Button_ResetAffectedUnits_WRA.Enabled = true;
					break;
				}
			}
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Side))
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = true;
			Button_ResetAffectedMissions_WRA.Enabled = true;
			Button_ResetCurrent_WRA.Text = "重置武器释放规则（使用系统默认值）";
		}
		else if (Subject.IsMission)
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = true;
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Group))
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = true;
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		else if ((object)Subject.GetType() == typeof(Waypoint))
		{
			Button_ResetCurrent_WRA.Enabled = false;
			Button_ResetAffectedUnits_WRA.Enabled = false;
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		else
		{
			Button_ResetCurrent_WRA.Enabled = true;
			Button_ResetAffectedUnits_WRA.Enabled = false;
			Button_ResetAffectedMissions_WRA.Enabled = false;
		}
		try
		{
			if (Client.CurrentSide == null || Client.CurrentSide.Units.Count == 0)
			{
				return;
			}
			NewException();
			int num = 0;
			int index = 0;
			int firstDisplayedScrollingRowIndex = TGV_WRA.FirstDisplayedScrollingRowIndex;
			if (TGV_WRA.SelectedCells.Count > 0)
			{
				num = TGV_WRA.SelectedCells[0].RowIndex;
				index = TGV_WRA.SelectedCells[0].ColumnIndex;
			}
			TGV_WRA.Nodes.Clear();
			m_ExceptionOrder = new Dictionary<int, Doctrine.WRA_Weapon>();
			if (Information.IsNothing(SelectedUnits))
			{
				StartSingleton(ref recordOrder);
			}
			else
			{
				foreach (ActiveUnit selectedUnit2 in SelectedUnits)
				{
					StartSingleton(ref selectedUnit2.Doctrine);
				}
			}
			if (!Information.IsNothing(Subject) && (object)Subject.GetType() == typeof(Side))
			{
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in m_ExceptionOrder)
				{
					int key = item.Key;
					Weapon weapon = item.Value.WriteInterruptibleField(Client.CurrentScenario, key);
					if (Information.IsNothing(weapon.Doctrine.WRA))
					{
						continue;
					}
					foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item3 in weapon.Doctrine.WRA)
					{
						Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item3.Value.WRA_WeaponTargets;
						Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
						foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
						{
							Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = item.Value.WRA_WeaponTargets;
							Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets2;
							foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 in array2)
							{
								if (wRA_FiringDoctrineEntry2.TargetType == wRA_FiringDoctrineEntry.TargetType)
								{
									wRA_FiringDoctrineEntry2.WeaponQty = -1;
									wRA_FiringDoctrineEntry2.ShooterQty = -1;
									wRA_FiringDoctrineEntry2.SelfDefenceRange = -1f;
									break;
								}
							}
						}
					}
				}
			}
			if (!Information.IsNothing(SelectedUnits))
			{
				LoginException();
			}
			AssetSingleton(ref recordOrder);
			List<KeyValuePair<int, Doctrine.WRA_Weapon>> list = m_ExceptionOrder.OrderBy((KeyValuePair<int, Doctrine.WRA_Weapon> theKVP) => theKVP.Value.WriteInterruptibleField(Client.CurrentScenario, theKVP.Key).Name, new NaturalSortComparer<string[]>()).ToList();
			int num2 = attrOrder.Count;
			foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item2 in list)
			{
				TreeGridNode treeGridNode = TGV_WRA.Nodes.Add(item2.Value.WriteInterruptibleField(Client.CurrentScenario, item2.Key).Name, null, null);
				treeGridNode.Tag = item2;
				treeGridNode.Nodes.Add("Temp only");
				DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
				dataGridViewTextBoxCell3.Value = "";
				TGV_WRA[WeaponsPerSalvo.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell;
				TGV_WRA[ShootersPerSalvo.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell4;
				TGV_WRA[FiringRange.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell2;
				TGV_WRA[SelfDefenceRange.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell3;
				dataGridViewTextBoxCell.ReadOnly = true;
				dataGridViewTextBoxCell2.ReadOnly = true;
				dataGridViewTextBoxCell3.ReadOnly = true;
				dataGridViewTextBoxCell4.ReadOnly = true;
				if (num2 > 0 && attrOrder.Contains(item2.Key))
				{
					num2--;
					treeGridNode.Expand();
				}
			}
			if (TGV_WRA.Rows.Count != 0 && num != 0)
			{
				TGV_WRA.Rows[num].Cells[index].Selected = true;
				if (firstDisplayedScrollingRowIndex != -1)
				{
					TGV_WRA.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				}
			}
			PushException();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101195", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			try
			{
				PushException();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PostSingleton()
	{
		NewException();
		if (!Information.IsNothing(SelectedUnits))
		{
			recordOrder = ValidateException();
		}
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WithdrawDamageThreshold = Combo_WithdrawDamageThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.Populate_Combo_WithdrawDamageThreshold(combo_WithdrawDamageThreshold, ref scenario_, m_InvocationSpecification);
		Doctrine doctrine2 = recordOrder;
		DarkUIComboBox combo_WithdrawFuelThreshold = Combo_WithdrawFuelThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine2.Populate_Combo_WithdrawFuelThreshold(combo_WithdrawFuelThreshold, ref scenario_, _ClassSpecification);
		Doctrine doctrine3 = recordOrder;
		DarkUIComboBox combo_WithdrawAttackThreshold = Combo_WithdrawAttackThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine3.Populate_Combo_WithdrawAttackThreshold(combo_WithdrawAttackThreshold, ref scenario_, m_RequestSpecification);
		Doctrine doctrine4 = recordOrder;
		DarkUIComboBox combo_WithdrawDefenceThreshold = Combo_WithdrawDefenceThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine4.Populate_Combo_WithdrawDefenceThreshold(combo_WithdrawDefenceThreshold, ref scenario_, m_ValueSpecification);
		Doctrine doctrine5 = recordOrder;
		DarkUIComboBox combo_RedeployDamageThreshold = Combo_RedeployDamageThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine5.Populate_Combo_RedeployDamageThreshold(combo_RedeployDamageThreshold, ref scenario_, _TokenizerSpecification);
		Doctrine doctrine6 = recordOrder;
		DarkUIComboBox combo_RedeployFuelThreshold = Combo_RedeployFuelThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine6.Populate_Combo_RedeployFuelThreshold(combo_RedeployFuelThreshold, ref scenario_, _StubSpecification);
		Doctrine doctrine7 = recordOrder;
		DarkUIComboBox combo_RedeployAttackThreshold = Combo_RedeployAttackThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine7.Populate_Combo_RedeployAttackThreshold(combo_RedeployAttackThreshold, ref scenario_, writerSpecification);
		Doctrine doctrine8 = recordOrder;
		DarkUIComboBox combo_RedeployDefenceThreshold = Combo_RedeployDefenceThreshold;
		scenario_ = Client.CurrentScenario;
		doctrine8.Populate_Combo_RedeployDefenceThreshold(combo_RedeployDefenceThreshold, ref scenario_, m_SpecificationSpecification);
		PushException();
	}

	private void RunSingleton()
	{
		List_TargetPriority.Items.Clear();
		Doctrine doctrine = recordOrder.LogoutRepository(Client.CurrentScenario);
		if (doctrine == null)
		{
			Label_PTLSource.ForeColor = Color.Red;
			Label_PTLSource.Text = "不存在目标优先级列表。点击“创建”按钮以创建一个列表。";
			List_TargetPriority.Enabled = false;
			Btn_PTLCreate.Enabled = true;
			Btn_PTLRemove.Enabled = false;
			Btn_PTLDelete.Enabled = false;
			Btn_PTLAdd.Enabled = false;
			Btn_PTLMoveDown.Enabled = false;
			Btn_PTLMoveUp.Enabled = false;
			return;
		}
		if (doctrine == recordOrder)
		{
			Label_PTLSource.ForeColor = Color.White;
			Label_PTLSource.Text = "编辑目标优先级列表。点击“删除”按钮将完全删除目标优先级列表。";
			Btn_PTLCreate.Enabled = false;
			Btn_PTLRemove.Enabled = true;
			recordOrder.Populate_List_PriorityTarget(List_TargetPriority, Client.CurrentScenario);
			List_TargetPriority.Enabled = true;
			bool enabled = List_TargetPriority.SelectedIndices.Count > 0;
			Btn_PTLDelete.Enabled = enabled;
			Btn_PTLAdd.Enabled = enabled;
			enabled = List_TargetPriority.Items.Count > 1;
			Btn_PTLMoveDown.Enabled = enabled;
			Btn_PTLMoveUp.Enabled = enabled;
			if (base.Visible)
			{
				string text = recordOrder.SelectRepository(Client.CurrentScenario);
				if (!string.IsNullOrEmpty(text))
				{
					DarkMessageBox.ShowInformation(text, "Doctrine", DarkDialogButton.Close);
				}
			}
			return;
		}
		string text2 = "Priority Target List inherited from Doctrine for '";
		if ((object)doctrine.Subject.GetType() == typeof(Side))
		{
			text2 = text2 + "side: " + ((Side)doctrine.Subject).Name;
		}
		else if (doctrine.Subject.IsMission)
		{
			text2 = text2 + "mission: " + ((Mission)doctrine.Subject).Name;
		}
		else if ((object)doctrine.Subject.GetType() == typeof(Group))
		{
			text2 = text2 + "group: " + ((Group)doctrine.Subject).Name;
		}
		else if ((object)doctrine.Subject.GetType() == typeof(Waypoint))
		{
			string text3 = ((Waypoint)doctrine.Subject).Name;
			if (string.IsNullOrEmpty(text3))
			{
				text3 = "没有命名";
			}
			text2 = text2 + "waypoint: " + text3 + "（类型：" + Waypoint.GetWaypointTypeString(((Waypoint)doctrine.Subject).Type) + ")";
		}
		else if (doctrine.Subject.IsActiveUnit)
		{
			text2 = text2 + "unit: " + ((ActiveUnit)doctrine.Subject).Name;
		}
		text2 += "' Open that Doctrine to edit the list or use 'Create' to override in this Doctrine.";
		Label_PTLSource.ForeColor = Color.Red;
		Label_PTLSource.Text = text2;
		doctrine.Populate_List_PriorityTarget(List_TargetPriority, Client.CurrentScenario);
		List_TargetPriority.Enabled = true;
		Btn_PTLCreate.Enabled = true;
		Btn_PTLRemove.Enabled = false;
		Btn_PTLDelete.Enabled = false;
		Btn_PTLAdd.Enabled = false;
		Btn_PTLMoveDown.Enabled = false;
		Btn_PTLMoveUp.Enabled = false;
	}

	public void RefreshPriorityTargetList(Doctrine doctrine_0, int int_0 = -1)
	{
		RunSingleton();
		if (int_0 >= 0)
		{
			if (int_0 >= List_TargetPriority.Items.Count)
			{
				int_0 = List_TargetPriority.Items.Count - 1;
			}
			List_TargetPriority.SelectItem(int_0);
		}
	}

	private void StartSingleton(ref Doctrine doctrine_0)
	{
		foreach (ActiveUnit item in doctrine_0.LoginRepository(Client.CurrentScenario, isEscorts))
		{
			if (item == null || item.GetUnitSide() != Client.CurrentSide)
			{
				continue;
			}
			if (item.IsAircraft)
			{
				WRA_RetreiveMountWeapons(item);
				WRA_RetreiveLoadoutWeapons(item);
			}
			else if (!item.IsShip && !item.IsSubmarine && !item.IsFacility)
			{
				if (item.IsPalletWeapon)
				{
					WRA_RetreiveePalletWeapons(item);
				}
			}
			else
			{
				WRA_RetreiveMountWeapons(item);
				WRA_RetreiveMagazineWeapons(item);
			}
		}
	}

	private void AssetSingleton(ref Doctrine doctrine_0)
	{
		if (Information.IsNothing(doctrine_0.WRA))
		{
			return;
		}
		foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in doctrine_0.WRA)
		{
			int key = item.Key;
			Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
			Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
			foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
			{
				if (!m_ExceptionOrder.ContainsKey(key))
				{
					continue;
				}
				Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
				m_ExceptionOrder.TryGetValue(key, out value);
				Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = value.WRA_WeaponTargets;
				Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets2;
				foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 in array2)
				{
					if (wRA_FiringDoctrineEntry2.TargetType == wRA_FiringDoctrineEntry.TargetType)
					{
						wRA_FiringDoctrineEntry2.WeaponQty = wRA_FiringDoctrineEntry.WeaponQty;
						wRA_FiringDoctrineEntry2.ShooterQty = wRA_FiringDoctrineEntry.ShooterQty;
						wRA_FiringDoctrineEntry2.SelfDefenceRange = wRA_FiringDoctrineEntry.SelfDefenceRange;
						wRA_FiringDoctrineEntry2.FiringRange = wRA_FiringDoctrineEntry.FiringRange;
						break;
					}
				}
			}
		}
	}

	public void WRA_RetreiveLoadoutWeapons(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec weaponRec in array)
		{
			if (weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).IsPalletWeapon)
			{
				if (weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).Warheads.Count() <= 0)
				{
					continue;
				}
				Warhead[] warheads = weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).Warheads;
				Warhead[] array2 = warheads;
				foreach (Warhead warhead in array2)
				{
					if (warhead.GetCarriedWeapon(activeUnit_0.ParentScen) != null && !m_ExceptionOrder.ContainsKey(warhead.GetCarriedWeapon(activeUnit_0.ParentScen).DBID))
					{
						Weapon weapon_ = warhead.GetCarriedWeapon(activeUnit_0.ParentScen);
						WRA_AddWeapon(ref weapon_);
					}
				}
			}
			else
			{
				Doctrine doctrine = recordOrder;
				Weapon weapon_2 = weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen);
				if (doctrine.InsertRepository(ref weapon_2))
				{
					weapon_2 = weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen);
					WRA_AddWeapon(ref weapon_2);
				}
			}
		}
	}

	public void WRA_RetreiveePalletWeapons(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing((Weapon)activeUnit_0))
		{
			return;
		}
		if (((Weapon)activeUnit_0).WeaponWeapons.Count == 0)
		{
			((Weapon)activeUnit_0).InitializeWeaponWeaponsPallet();
		}
		foreach (WeaponRec weaponWeapon in ((Weapon)activeUnit_0).WeaponWeapons)
		{
			if (weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).IsPalletWeapon)
			{
				if (weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).Warheads.Count() <= 0)
				{
					continue;
				}
				Warhead[] warheads = weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen).Warheads;
				Warhead[] array = warheads;
				foreach (Warhead warhead in array)
				{
					if (warhead.GetCarriedWeapon(activeUnit_0.ParentScen) != null && !m_ExceptionOrder.ContainsKey(warhead.GetCarriedWeapon(activeUnit_0.ParentScen).DBID))
					{
						Weapon weapon_ = warhead.GetCarriedWeapon(activeUnit_0.ParentScen);
						WRA_AddWeapon(ref weapon_);
					}
				}
			}
			else
			{
				Doctrine doctrine = recordOrder;
				Weapon weapon_2 = weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen);
				if (doctrine.InsertRepository(ref weapon_2))
				{
					weapon_2 = weaponWeapon.GetReferenceWeapon(activeUnit_0.ParentScen);
					WRA_AddWeapon(ref weapon_2);
				}
			}
		}
	}

	public void WRA_RetreiveMagazineWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon weapon_ = weapon.GetReferenceWeapon(Client.CurrentScenario);
				if (recordOrder.InsertRepository(ref weapon_))
				{
					WRA_AddWeapon(ref weapon_);
				}
			}
		}
	}

	public void WRA_RetreiveMountWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon_ = mountWeapon.GetReferenceWeapon(Client.CurrentScenario);
				if (recordOrder.InsertRepository(ref weapon_))
				{
					WRA_AddWeapon(ref weapon_);
				}
			}
		}
	}

	public void WRA_AddWeapon(ref Weapon weapon_0)
	{
		if (!m_ExceptionOrder.ContainsKey(weapon_0.DBID))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon(ref weapon_0, Client.CurrentScenario);
			m_ExceptionOrder.Add(weapon_0.DBID, value);
		}
	}

	private void PrintSingleton(object sender, EventArgs e)
	{
		DefineSingleton();
	}

	internal void DefineSingleton()
	{
		if (!ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Refreshing && (!Information.IsNothing(Subject) || !Information.IsNothing(SelectedUnits)))
		{
			switch (TabControl1A.SelectedIndex)
			{
			case 0:
				VerifySingleton();
				break;
			case 1:
				ListSingleton();
				break;
			case 2:
				ResolveSingleton();
				break;
			case 3:
				PostSingleton();
				break;
			case 4:
				RunSingleton();
				break;
			}
		}
	}

	private void PublishSingleton(object sender, EventArgs e)
	{
		recordOrder.SetNukesAllowed_PlayerEditable(Client.CurrentScenario, CB_UseNukes_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void AwakeSingleton(object sender, EventArgs e)
	{
		recordOrder.SetIgnorePlottedCourse_PlayerEditable(Client.CurrentScenario, CB_IgnorePlottedCourse_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void QuerySingleton(object sender, EventArgs e)
	{
		m_SetterOrder = Combo_IgnorePlottedCourse.SelectedIndex;
	}

	private void ResetSingleton(object sender, EventArgs e)
	{
		recordOrder.SetWeaponControlStatus_Air_PlayerEditable(Client.CurrentScenario, CB_WeaponControlStatus_Air_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void MapSingleton(object sender, EventArgs e)
	{
		recordOrder.SetWeaponControlStatus_Surface_PlayerEditable(Client.CurrentScenario, CB_WeaponControlStatus_Surface_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void SortSingleton(object sender, EventArgs e)
	{
		recordOrder.SetWeaponControlStatus_Submarine_PlayerEditable(Client.CurrentScenario, CB_WeaponControlStatus_Submarine_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CalcSingleton(object sender, EventArgs e)
	{
		recordOrder.SetWeaponControlStatus_Land_PlayerEditable(Client.CurrentScenario, CB_WeaponControlStatus_Land_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void RateSingleton(object sender, EventArgs e)
	{
		recordOrder.SetIgnoreEMCONunderAttack_PlayerEditable(Client.CurrentScenario, CB_IgnoreEMCONunderAttack_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void FlushSingleton(object sender, EventArgs e)
	{
		recordOrder.SetUseReplenishment_PlayerEditable(Client.CurrentScenario, CB_UseRefuel_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ForgotSingleton(object sender, EventArgs e)
	{
		recordOrder.SetReplenishmentSelection_PlayerEditable(Client.CurrentScenario, CB_ReplenishmentSelection_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CollectSingleton(object sender, EventArgs e)
	{
		recordOrder.SetUseSAMsOnASuW_PlayerEditable(Client.CurrentScenario, CB_UseSAMsOnASuW_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void OrderSingleton(object sender, EventArgs e)
	{
		recordOrder.SetGunStrafing_PlayerEditable(Client.CurrentScenario, CB_GunStrafing_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void RegisterSingleton(object sender, EventArgs e)
	{
		m_VisitorOrder = Combo_UseNukes.SelectedIndex;
	}

	private void ManageSingleton(object sender, EventArgs e)
	{
		_MethodOrder = Combo_QuickTurnAroundForAicraft.SelectedIndex;
	}

	private void RevertSingleton(object sender, EventArgs e)
	{
		m_ServiceOrder = Combo_AirOpsTempo.SelectedIndex;
	}

	private void CountRecord(object sender, EventArgs e)
	{
		m_SystemOrder = Combo_FuelState.SelectedIndex;
	}

	private void CustomizeRecord(object sender, EventArgs e)
	{
		baseOrder = Combo_WeaponState.SelectedIndex;
	}

	private void CloneRecord(object sender, EventArgs e)
	{
		_BroadcasterOrder = Combo_UseKinematicRangeForTorpedoes.SelectedIndex;
	}

	private void ConnectRecord(object sender, EventArgs e)
	{
		_ExporterOrder = Combo_WeaponControlStatus_Air.SelectedIndex;
	}

	private void MoveRecord(object sender, EventArgs e)
	{
		_PrototypeOrder = Combo_WeaponControlStatus_Surface.SelectedIndex;
	}

	private void DeleteRecord(object sender, EventArgs e)
	{
		comparatorOrder = Combo_WeaponControlStatus_Submarine.SelectedIndex;
	}

	private void AddRecord(object sender, EventArgs e)
	{
		_ItemOrder = Combo_WeaponControlStatus_Land.SelectedIndex;
	}

	private void DestroyRecord(object sender, EventArgs e)
	{
		identifierOrder = Combo_GunStrafing.SelectedIndex;
	}

	private void ComputeRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_UseNukes = Combo_UseNukes;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_UseNukes(combo_UseNukes, ref scenario_, ref m_VisitorOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void PatchRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_QuickTurnAroundForAicraft = Combo_QuickTurnAroundForAicraft;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_QuickTurnAroundForAicraft(combo_QuickTurnAroundForAicraft, ref scenario_, ref _MethodOrder, ref UnitIsOperating, bool_1: true, bool_2: false);
		DefineSingleton();
	}

	private void SelectRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_AirOpsTempo = Combo_AirOpsTempo;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_AirOpsTempo(combo_AirOpsTempo, ref scenario_, ref m_ServiceOrder, ref UnitIsOperating, bool_1: true, bool_2: false);
		DefineSingleton();
	}

	private void CallRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_FuelState = Combo_FuelState;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_BingoJoker(combo_FuelState, ref scenario_, ref m_SystemOrder, ref UnitIsOperating, ref isEscorts, bool_2: true, bool_3: false);
		DefineSingleton();
	}

	private void LogoutRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponState = Combo_WeaponState;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WinchesterShotgun(combo_WeaponState, ref scenario_, ref baseOrder, ref UnitIsOperating, bool_1: true, bool_2: false);
		DefineSingleton();
	}

	private void ViewRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_UseKinematicRangeForTorpedoes = Combo_UseKinematicRangeForTorpedoes;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_UseKinematicRangeForTorpedoes(combo_UseKinematicRangeForTorpedoes, ref scenario_, ref _BroadcasterOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void ValidateRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Air = Combo_WeaponControlStatus_Air;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WeaponControlStatus_Air(combo_WeaponControlStatus_Air, ref scenario_, ref _ExporterOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void LoginRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Surface = Combo_WeaponControlStatus_Surface;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WeaponControlStatus_Surface(combo_WeaponControlStatus_Surface, ref scenario_, ref _PrototypeOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void GetRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Submarine = Combo_WeaponControlStatus_Submarine;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WeaponControlStatus_Submarine(combo_WeaponControlStatus_Submarine, ref scenario_, ref comparatorOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void WriteRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponControlStatus_Land = Combo_WeaponControlStatus_Land;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WeaponControlStatus_Land(combo_WeaponControlStatus_Land, ref scenario_, ref _ItemOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void NewRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_GunStrafing = Combo_GunStrafing;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_GunStrafing(combo_GunStrafing, ref scenario_, ref identifierOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void PushRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_IgnorePlottedCourse = Combo_IgnorePlottedCourse;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_IgnorePlottedCourse(combo_IgnorePlottedCourse, ref scenario_, ref m_SetterOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void InvokeRecord(object sender, EventArgs e)
	{
		recordOrder.SetWinchesterShotgunRTB_PlayerEditable(Client.CurrentScenario, CB_WeaponStateRTB_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void SetupRecord(object sender, EventArgs e)
	{
		Doctrine doctrine_ = recordOrder;
		doctrine_.Set_Checkbox_State_Visibility_EMCON(CB_EMCON_Inherits, CB_EMCON_Radar, CB_EMCON_OECM, CB_EMCON_Sonar, ref doctrine_, Client.CurrentScenario, bool_0: true, bool_1: false);
		Doctrine doctrine = doctrine_;
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.Populate_Combo_EMCON_Radar(cB_EMCON_Radar, ref scenario_, ref doctrine_);
		Doctrine doctrine2 = doctrine_;
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		scenario_ = Client.CurrentScenario;
		doctrine2.Populate_Combo_EMCON_OECM(cB_EMCON_OECM, ref scenario_, ref doctrine_);
		Doctrine doctrine3 = doctrine_;
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		scenario_ = Client.CurrentScenario;
		doctrine3.Populate_Combo_EMCON_Sonar(cB_EMCON_Sonar, ref scenario_, ref doctrine_);
		if (Information.IsNothing(SelectedUnits))
		{
			Doctrine doctrine4 = recordOrder;
			Side side_ = Client.CurrentSide;
			scenario_ = Client.CurrentScenario;
			doctrine4.ApplyEMCON_For_AffectedUnits(ref side_, ref scenario_, ref isEscorts);
			Client.CurrentSide = side_;
		}
		else
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				Doctrine doctrine5 = selectedUnit.Doctrine;
				Side side_2 = Client.CurrentSide;
				scenario_ = Client.CurrentScenario;
				doctrine5.ApplyEMCON_For_AffectedUnits(ref side_2, ref scenario_, ref isEscorts);
				Client.CurrentSide = side_2;
			}
		}
		watcherSpecification = false;
		recordOrder.FireEvent_EmconChanged(Subject, false, !Information.IsNothing(SelectedUnits) && SelectedUnits.Count > 1, bool_1: true, bool_2: false, bool_3: false);
		watcherSpecification = true;
		Client.MustRefreshMainForm = true;
	}

	private void ExcludeRecord(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario scenario_ = Client.CurrentScenario;
		ref Doctrine doctrine_ = ref recordOrder;
		bool bool_ = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_Radar(cB_EMCON_Radar, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref isEscorts, bool_3: true, bool_4: false);
		Client.MustRefreshMainForm = true;
		DefineSingleton();
	}

	private void IncludeRecord(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		Scenario scenario_ = Client.CurrentScenario;
		ref Doctrine doctrine_ = ref recordOrder;
		bool bool_ = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_OECM(cB_EMCON_OECM, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref isEscorts, bool_3: true, bool_4: false);
		Client.MustRefreshMainForm = true;
		DefineSingleton();
	}

	private void SearchRecord(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		Scenario scenario_ = Client.CurrentScenario;
		ref Doctrine doctrine_ = ref recordOrder;
		bool bool_ = !isAirOps && !isBoatOps;
		EmconControl.SelectionChanged_Combo_EMCON_Sonar(cB_EMCON_Sonar, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref isEscorts, bool_3: true, bool_4: false);
		Client.MustRefreshMainForm = true;
		DefineSingleton();
	}

	private void EnableRecord(object sender, EventArgs e)
	{
		policyOrder = Combo_WeaponStateRTB.SelectedIndex;
	}

	private void ChangeRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WeaponStateRTB = Combo_WeaponStateRTB;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_WinchesterShotgunRTB(combo_WeaponStateRTB, ref scenario_, ref policyOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void InitRecord(object sender, EventArgs e)
	{
		candidateOrder = Combo_FuelStateRTB.SelectedIndex;
	}

	private void CheckRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_FuelStateRTB = Combo_FuelStateRTB;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_BingoJokerRTB(combo_FuelStateRTB, ref scenario_, ref candidateOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void ConcatRecord(object sender, EventArgs e)
	{
		_CreatorOrder = Combo_Jettison.SelectedIndex;
	}

	private void InterruptRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_Jettison = Combo_Jettison;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_JettisonOrdnance(combo_Jettison, ref scenario_, ref _CreatorOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void RemoveRecord(object sender, EventArgs e)
	{
		m_TemplateOrder = Combo_BVRLogic.SelectedIndex;
	}

	private void FindRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_BVRLogic = Combo_BVRLogic;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_BVRLogic(combo_BVRLogic, ref scenario_, ref m_TemplateOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void SetRecord(object sender, EventArgs e)
	{
		m_MappingOrder = Combo_BehaviorTowardsAmbigousTarget.SelectedIndex;
	}

	private void FillRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_BehaviorTowardsAmbigousTarget = Combo_BehaviorTowardsAmbigousTarget;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_BehaviorTowardsAmbigousTarget(combo_BehaviorTowardsAmbigousTarget, ref scenario_, ref m_MappingOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void CalculateRecord(object sender, EventArgs e)
	{
		recordOrder.SetBehaviorTowardsAmbigousTarget_PlayerEditable(Client.CurrentScenario, CB_BehaviorTowardsAmbigousTarget_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void PopRecord(object sender, EventArgs e)
	{
		_MockOrder = Combo_AutoEvade.SelectedIndex;
	}

	private void InstantiateRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_AutoEvade = Combo_AutoEvade;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_AutoEvade(combo_AutoEvade, ref scenario_, ref _MockOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void CreateRecord(object sender, EventArgs e)
	{
		recordOrder.SetAutoEvade_PlayerEditable(Client.CurrentScenario, CB_AutoEvade_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CompareRecord(object sender, EventArgs e)
	{
		recordOrder.SetMaintainStandoff_PlayerEditable(Client.CurrentScenario, CB_Standoff_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ReadRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_Standoff = Combo_Standoff;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_Standoff(combo_Standoff, ref scenario_, ref _TagOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void DisableRecord(object sender, EventArgs e)
	{
		m_RegOrder = Combo_ShootTourists.SelectedIndex;
	}

	private void UpdateRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_ShootTourists = Combo_ShootTourists;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_ShootTourists(combo_ShootTourists, ref scenario_, ref m_RegOrder, bool_0: true, bool_1: false);
		Doctrine doctrine2 = recordOrder;
		scenario_ = Client.CurrentScenario;
		Side side_ = Client.CurrentSide;
		doctrine2.ResetMission_TimeSincePlayerNotification(ref scenario_, ref side_);
		Client.CurrentSide = side_;
		DefineSingleton();
	}

	private void InsertRecord(object sender, EventArgs e)
	{
		_FieldOrder = Combo_UseRefuel.SelectedIndex;
	}

	private void PrepareRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		int selectedIndex = Combo_UseRefuel.SelectedIndex;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_UseRefuel(selectedIndex, ref scenario_, ref _FieldOrder, bool_0: true, bool_1: false, bool_2: false);
		DefineSingleton();
	}

	private void ReflectRecord(object sender, EventArgs e)
	{
		m_QueueOrder = Combo_ReplenishmentSelection.SelectedIndex;
	}

	private void VisitRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		int selectedIndex = Combo_ReplenishmentSelection.SelectedIndex;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_ReplenishmentSelection(selectedIndex, ref scenario_, ref m_QueueOrder, bool_0: true, bool_1: false, bool_2: false);
		DefineSingleton();
	}

	private void RestartRecord(object sender, EventArgs e)
	{
		recordOrder.SetSurfaceNavigation_PlayerEditable(Client.CurrentScenario, CB_Surface_Navigation_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void TestRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_Surface_Navigation = Combo_Surface_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_SurfaceNavigation(combo_Surface_Navigation, ref scenario_, ref annotationOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void StopRecord(object sender, EventArgs e)
	{
		recordOrder.SetSubmarineNavigation_PlayerEditable(Client.CurrentScenario, CB_Submarine_Navigation_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CancelRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_Submarine_Navigation = Combo_Submarine_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_SubmarineNavigation(combo_Submarine_Navigation, ref scenario_, ref m_IteratorOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void VerifyRecord(object sender, EventArgs e)
	{
		recordOrder.SetLandNavigation_PlayerEditable(Client.CurrentScenario, CB_Land_Navigation_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ListRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_Land_Navigation = Combo_Land_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_LandNavigation(combo_Land_Navigation, ref scenario_, ref initializerOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void ResolveRecord(object sender, KeyEventArgs e)
	{
		if (base.ParentForm == null)
		{
			if (e.KeyCode == Keys.Escape && base.Visible)
			{
				Close();
				return;
			}
			if (e.KeyCode == Keys.F9 && e.Control && base.Visible)
			{
				Close();
				return;
			}
		}
		if (base.ParentForm == null && (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PostRecord(object sender, EventArgs e)
	{
		recordOrder.SetShootTourists_PlayerEditable(Client.CurrentScenario, CB_ShootTourists_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void RunRecord(object sender, EventArgs e)
	{
		recordOrder.SetUseSAMsOnASuW_PlayerEditable(Client.CurrentScenario, CB_UseSAMsOnASuW_PlayerEditable.Checked);
	}

	private void StartRecord(object sender, EventArgs e)
	{
		paramOrder = Combo_UseSAMsOnASuW.SelectedIndex;
	}

	private void AssetRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_UseSAMsOnASuW = Combo_UseSAMsOnASuW;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_UseSAMsOnASuW(combo_UseSAMsOnASuW, ref scenario_, ref _RulesOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void PrintRecord(object sender, EventArgs e)
	{
		recordOrder.SetUseWPMissileOnASuW_PlayerEditable(Client.CurrentScenario, CB_UseWPMissilesOnASuW.Checked);
	}

	private void DefineRecord(object sender, EventArgs e)
	{
		paramOrder = Combo_UseSAMsOnASuW.SelectedIndex;
	}

	private void PublishRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_UseWPMissilesOnASuW = Combo_UseWPMissilesOnASuW;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_UseWPMissilesOnASuW(combo_UseWPMissilesOnASuW, ref scenario_, ref m_PageOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void AwakeRecord(object sender, EventArgs e)
	{
		recordOrder.SetIgnoreEMCONunderAttack_PlayerEditable(Client.CurrentScenario, CB_IgnoreEMCONunderAttack_PlayerEditable.Checked);
	}

	private void QueryRecord(object sender, EventArgs e)
	{
		_RulesOrder = Combo_IgnoreEMCONunderAttack.SelectedIndex;
	}

	private void ResetRecord(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_IgnoreEMCONunderAttack = Combo_IgnoreEMCONunderAttack;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_IgnoreEMCONunderAttack(combo_IgnoreEMCONunderAttack, ref scenario_, ref _RulesOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void MapRecord(object sender, EventArgs e)
	{
		recordOrder.SetAirOpsTempo_PlayerEditable(Client.CurrentScenario, CB_AirOpsTempo_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void SortRecord(object sender, EventArgs e)
	{
		recordOrder.SetQuickTurnAroundForAicraft_PlayerEditable(Client.CurrentScenario, CB_QuickTurnAroundForAicraft_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CalcRecord(object sender, EventArgs e)
	{
		recordOrder.SetWinchesterShotgun_PlayerEditable(Client.CurrentScenario, CB_WeaponState_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void RateRecord(object sender, EventArgs e)
	{
		recordOrder.SetBingoJoker_PlayerEditable(Client.CurrentScenario, CB_FuelState_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void FlushRecord(object sender, EventArgs e)
	{
		InterruptSetter(new OpenFileDialog());
		ConcatSetter().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (ConcatSetter().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			object object_ = recordOrder.Subject;
			OpenFileDialog openFileDialog = ConcatSetter();
			string string_ = openFileDialog.FileName;
			ref Doctrine doctrine_ = ref recordOrder;
			Scenario scenario_ = Client.CurrentScenario;
			LuaDoctrine.FromXML_Private(ref object_, ref string_, ref doctrine_, ref scenario_);
			openFileDialog.FileName = string_;
			DarkMessageBox.ShowInformation("Doctrine loaded", "Doctrine", DarkDialogButton.Close);
			Close();
			if (Client.MissionEditorWindow.Visible)
			{
				if (Client.MissionEditorWindow.SelectedMission != null)
				{
					Client.MissionEditorWindow.EMCON_WRA_Panel.Controls.Clear();
					if (Information.IsNothing(Client.MissionEditorWindow.SelectedMission))
					{
						return;
					}
					ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm.Subject = Client.MissionEditorWindow.SelectedMission;
					ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm.isEscorts = false;
					ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm = MissionEditor.AwakeInterruptibleConsumer(ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm);
					Client.MissionEditorWindow.EMCON_WRA_Panel.Controls.Add(ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm);
					ItemExporter.ConnectInterruptibleTemplate.MissionEditor.theDoctrineForm.Show();
					Client.MissionEditorWindow.EMCON_WRA_Mission = Client.MissionEditorWindow.SelectedMission.ObjectID;
				}
			}
			else if (Client.SelectedUnit != null && Client.CurrentSide.SelectedUnits.Count != 0)
			{
				MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				Module_Unit.Unit selectedUnit = Client.SelectedUnit;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
				List<ActiveUnit> list_ = null;
				mainForm.ShowDoctrineROE(selectedUnit, ref readOnlyCollection_, ref list_, bool_0: true);
			}
			else if (Client.SelectedWaypoint == null)
			{
				if (Client.CurrentSide != null)
				{
					MainForm mainForm2 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
					Side currentSide = Client.CurrentSide;
					ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_2 = null;
					List<ActiveUnit> list_2 = null;
					mainForm2.ShowDoctrineROE(currentSide, ref readOnlyCollection_2, ref list_2, bool_0: true);
				}
			}
			else
			{
				MainForm mainForm3 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				Waypoint selectedWaypoint = Client.SelectedWaypoint;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_3 = null;
				List<ActiveUnit> list_3 = null;
				mainForm3.ShowDoctrineROE(selectedWaypoint, ref readOnlyCollection_3, ref list_3, bool_0: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error in DoctrineForm", "LoadTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void ForgotRecord(object sender, EventArgs e)
	{
		SetSetter(new SaveFileDialog());
		FindSetter().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (FindSetter().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			FileStream fileStream = File.Create(FindSetter().FileName);
			using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
			{
				ref Doctrine doctrine_ = ref recordOrder;
				MemoryStream memoryStream_ = memoryStream;
				Scenario scenario_ = Client.CurrentScenario;
				LuaDoctrine.ToXML_Private(ref doctrine_, ref memoryStream_, ref scenario_);
				fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
				fileStream.Close();
			}
			DarkMessageBox.ShowInformation("Doctrine saved as " + FindSetter().FileName, "Doctrine", DarkDialogButton.Close);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error in DoctrineForm", "SaveTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void CollectRecord(object sender, EventArgs e)
	{
		recordOrder.SetUseKinematicRangeForTorpedoes_PlayerEditable(Client.CurrentScenario, CB_UseKinematicRangeForTorpedoes_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void OrderRecord(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_WRA.Nodes)
			{
				if (node.Selected)
				{
					break;
				}
				int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)node.Tag).Key;
				Weapon weapon_ = ((KeyValuePair<int, Doctrine.WRA_Weapon>)node.Tag).Value.WriteInterruptibleField(Client.CurrentScenario, key);
				foreach (TreeGridNode node2 in node.Nodes)
				{
					int rowIndex = node2.RowIndex;
					object objectValue = RuntimeHelpers.GetObjectValue(node2.Tag);
					if (node2.Selected && rowIndex != -1)
					{
						DataTable dataTable_ = new DataTable();
						DataTable dataTable_2 = new DataTable();
						DataTable dataTable_3 = new DataTable();
						DataTable dataTable_4 = new DataTable();
						Doctrine._WRA_WeaponTargetType targetType = ((Doctrine.WRA_FiringDoctrineEntry)objectValue).TargetType;
						DataGridViewColumn dataGridViewColumn = TGV_WRA.Columns[e.ColumnIndex];
						if (Operators.CompareString(dataGridViewColumn.Name, "WeaponsPerSalvo", TextCompare: true) == 0)
						{
							DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)TGV_WRA[WeaponsPerSalvo.Index, rowIndex];
							recordOrder.ComboBoxDataSource_WeaponQty(ref dataTable_, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell.Value));
							dataGridViewComboBoxCell.DataSource = dataTable_;
							dataGridViewComboBoxCell.DisplayMember = "Description";
							dataGridViewComboBoxCell.ValueMember = "ID";
							dataGridViewComboBoxCell.DropDownWidth = 500;
							TGV_WRA.BeginEdit(selectAll: true);
							((DataGridViewComboBoxEditingControl)TGV_WRA.EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(dataGridViewColumn.Name, "ShootersPerSalvo", TextCompare: true) == 0)
						{
							DataGridViewComboBoxCell dataGridViewComboBoxCell2 = (DataGridViewComboBoxCell)TGV_WRA[ShootersPerSalvo.Index, rowIndex];
							recordOrder.ComboBoxDataSource_ShooterQty(ref dataTable_2, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell2.Value));
							dataGridViewComboBoxCell2.DataSource = dataTable_2;
							dataGridViewComboBoxCell2.DisplayMember = "Description";
							dataGridViewComboBoxCell2.ValueMember = "ID";
							dataGridViewComboBoxCell2.DropDownWidth = 500;
							TGV_WRA.BeginEdit(selectAll: true);
							((DataGridViewComboBoxEditingControl)TGV_WRA.EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(dataGridViewColumn.Name, "SelfDefenceRange", TextCompare: true) == 0)
						{
							DataGridViewComboBoxCell dataGridViewComboBoxCell3 = (DataGridViewComboBoxCell)TGV_WRA[SelfDefenceRange.Index, rowIndex];
							recordOrder.ComboBoxDataSource_SelfDefenceRange(ref dataTable_3, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell3.Value));
							dataGridViewComboBoxCell3.DataSource = dataTable_3;
							dataGridViewComboBoxCell3.DropDownWidth = 500;
							dataGridViewComboBoxCell3.DisplayMember = "Description";
							dataGridViewComboBoxCell3.ValueMember = "ID";
							TGV_WRA.BeginEdit(selectAll: true);
							((DataGridViewComboBoxEditingControl)TGV_WRA.EditingControl).DroppedDown = true;
							break;
						}
						if (Operators.CompareString(dataGridViewColumn.Name, "FiringRange", TextCompare: true) == 0)
						{
							DataGridViewComboBoxCell dataGridViewComboBoxCell4 = (DataGridViewComboBoxCell)TGV_WRA[FiringRange.Index, rowIndex];
							recordOrder.ComboBoxDataSource_FiringRange(ref dataTable_4, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell4.Value));
							dataGridViewComboBoxCell4.DataSource = dataTable_4;
							dataGridViewComboBoxCell4.DropDownWidth = 500;
							dataGridViewComboBoxCell4.DisplayMember = "Description";
							dataGridViewComboBoxCell4.ValueMember = "ID";
							TGV_WRA.BeginEdit(selectAll: true);
							((DataGridViewComboBoxEditingControl)TGV_WRA.EditingControl).DroppedDown = true;
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 20012300002", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RegisterRecord(object sender, DataGridViewCellEventArgs e)
	{
		if (TGV_WRA.SelectedRows.Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = null;
		bool flag = false;
		foreach (TreeGridNode node in TGV_WRA.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!Information.IsNothing(treeGridNode) && !Information.IsNothing(treeGridNode.Parent))
		{
			TreeGridNode treeGridNode_ = treeGridNode.Parent;
			RevertRecord(e, treeGridNode, treeGridNode_);
		}
	}

	private void ManageRecord(object sender, EventArgs e)
	{
		if (TGV_WRA.IsCurrentCellDirty)
		{
			m_FilterSpecification = true;
			TGV_WRA.CommitEdit(DataGridViewDataErrorContexts.Commit);
			m_FilterSpecification = false;
			ResolveSingleton();
		}
	}

	private void RevertRecord(DataGridViewCellEventArgs dataGridViewCellEventArgs_0, TreeGridNode treeGridNode_0, TreeGridNode treeGridNode_1)
	{
		RuntimeHelpers.GetObjectValue(TGV_WRA[dataGridViewCellEventArgs_0.ColumnIndex, dataGridViewCellEventArgs_0.RowIndex].Value);
		object object_ = RuntimeHelpers.GetObjectValue(TGV_WRA[WeaponsPerSalvo.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object object_2 = RuntimeHelpers.GetObjectValue(TGV_WRA[ShootersPerSalvo.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object object_3 = RuntimeHelpers.GetObjectValue(TGV_WRA[SelfDefenceRange.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object object_4 = RuntimeHelpers.GetObjectValue(TGV_WRA[FiringRange.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = ((Doctrine.WRA_FiringDoctrineEntry)treeGridNode_0.Tag).TargetType;
		bool bool_ = false;
		int? nullable_ = null;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == WeaponsPerSalvo.Index)
		{
			bool_ = true;
			nullable_ = recordOrder.SetRepository(ref _WRA_WeaponTargetType_, ref object_);
		}
		bool bool_2 = false;
		int? nullable_2 = null;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == ShootersPerSalvo.Index)
		{
			bool_2 = true;
			nullable_2 = recordOrder.CalculateRepository(ref object_2);
		}
		bool bool_3 = false;
		float? nullable_3 = null;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == SelfDefenceRange.Index)
		{
			bool_3 = true;
			nullable_3 = recordOrder.InstantiateRepository(ref _WRA_WeaponTargetType_, ref object_3);
		}
		bool bool_4 = false;
		float? nullable_4 = null;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == FiringRange.Index)
		{
			bool_4 = true;
			nullable_4 = recordOrder.CompareRepository(ref object_4);
		}
		int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)treeGridNode_1.Tag).Key;
		_ = (KeyValuePair<int, Doctrine.WRA_Weapon>)treeGridNode_1.Tag;
		CountException(ref recordOrder, nullable_, bool_, nullable_2, bool_2, nullable_4, bool_4, nullable_3, bool_3, key, _WRA_WeaponTargetType_);
		if (!Information.IsNothing(SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				CountException(ref selectedUnit.Doctrine, nullable_, bool_, nullable_2, bool_2, nullable_4, bool_4, nullable_3, bool_3, key, _WRA_WeaponTargetType_);
			}
		}
		if (Doctrine.WRA_IsTopNodeTargetType(ref _WRA_WeaponTargetType_) && !m_FilterSpecification)
		{
			DefineSingleton();
		}
	}

	private void CountException(ref Doctrine doctrine_0, int? nullable_0, bool bool_0, int? nullable_1, bool bool_1, float? nullable_2, bool bool_2, float? nullable_3, bool bool_3, int int_0, Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_0)
	{
		new Doctrine.WRA_FiringDoctrineEntry();
		bool flag = false;
		if (doctrine_0.WRA != null && doctrine_0.WRA.ContainsKey(int_0))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
			doctrine_0.WRA.TryGetValue(int_0, out value);
			if (value != null)
			{
				Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = value.WRA_WeaponTargets;
				Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets2;
				foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
				{
					if (wRA_FiringDoctrineEntry.TargetType == _WRA_WeaponTargetType_0)
					{
						if (bool_0)
						{
							wRA_FiringDoctrineEntry.WeaponQty = nullable_0;
						}
						else if (bool_1)
						{
							wRA_FiringDoctrineEntry.ShooterQty = nullable_1;
						}
						else if (bool_3)
						{
							wRA_FiringDoctrineEntry.SelfDefenceRange = nullable_3;
						}
						else if (bool_2)
						{
							wRA_FiringDoctrineEntry.FiringRange = nullable_2;
						}
						flag = true;
					}
				}
			}
		}
		if (!flag)
		{
			doctrine_0.ScenarioContext = Client.CurrentScenario;
			if (doctrine_0.WRA == null)
			{
				doctrine_0.WRA = new Dictionary<int, Doctrine.WRA_Weapon>();
			}
			if (!doctrine_0.WRA.ContainsKey(int_0))
			{
				doctrine_0.WRA.Add(int_0, null);
			}
			Doctrine.WRA_Weapon value2 = new Doctrine.WRA_Weapon();
			doctrine_0.WRA.TryGetValue(int_0, out value2);
			if (value2 == null)
			{
				value2 = new Doctrine.WRA_Weapon();
				if (doctrine_0.WRA.ContainsKey(int_0))
				{
					doctrine_0.WRA[int_0] = value2;
				}
			}
			Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets3 = value2.WRA_WeaponTargets;
			bool flag2 = false;
			for (int i = 0; i < wRA_WeaponTargets3.Length; i = checked(i + 1))
			{
				if (wRA_WeaponTargets3[i].TargetType == _WRA_WeaponTargetType_0)
				{
					flag2 = true;
					break;
				}
			}
			Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 = new Doctrine.WRA_FiringDoctrineEntry(_WRA_WeaponTargetType_0);
			if (!flag2)
			{
				if (bool_0)
				{
					wRA_FiringDoctrineEntry2.WeaponQty = nullable_0;
				}
				else if (bool_1)
				{
					wRA_FiringDoctrineEntry2.ShooterQty = nullable_1;
				}
				else if (bool_3)
				{
					wRA_FiringDoctrineEntry2.SelfDefenceRange = nullable_3;
				}
				else if (bool_2)
				{
					wRA_FiringDoctrineEntry2.FiringRange = nullable_2;
				}
				ArrayExtensions.Add(ref value2.WRA_WeaponTargets, wRA_FiringDoctrineEntry2);
			}
		}
		if (doctrine_0.WRA == null || nullable_0.HasValue || nullable_1.HasValue || nullable_3.HasValue || nullable_2.HasValue)
		{
			return;
		}
		List<Doctrine.WRA_FiringDoctrineEntry> list = new List<Doctrine.WRA_FiringDoctrineEntry>();
		Doctrine.WRA_Weapon value3 = new Doctrine.WRA_Weapon();
		if (doctrine_0.WRA.Count > 0)
		{
			doctrine_0.WRA.TryGetValue(int_0, out value3);
			if (value3.WRA_WeaponTargets != null)
			{
				Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = value3.WRA_WeaponTargets;
				Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets;
				foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry3 in array2)
				{
					if (wRA_FiringDoctrineEntry3.TargetType == _WRA_WeaponTargetType_0 && !wRA_FiringDoctrineEntry3.WeaponQty.HasValue && !wRA_FiringDoctrineEntry3.SelfDefenceRange.HasValue && !wRA_FiringDoctrineEntry3.FiringRange.HasValue)
					{
						list.Add(wRA_FiringDoctrineEntry3);
					}
				}
				if (list.Count > 0)
				{
					foreach (Doctrine.WRA_FiringDoctrineEntry item in list)
					{
						ArrayExtensions.Remove(ref value3.WRA_WeaponTargets, item);
					}
				}
				if (value3.WRA_WeaponTargets.Count() == 0)
				{
					value3.WRA_WeaponTargets = null;
				}
			}
		}
		if (value3.WRA_WeaponTargets == null)
		{
			doctrine_0.WRA.Remove(int_0);
		}
		if (doctrine_0.WRA == null || doctrine_0.WRA.Count == 0)
		{
			doctrine_0.WRA = null;
		}
	}

	private void CustomizeException(object sender, ExpandingEventArgs e)
	{
		if (e.Node.Level != 1)
		{
			return;
		}
		int key = ((KeyValuePair<int, Doctrine.WRA_Weapon>)e.Node.Tag).Key;
		if (!attrOrder.Contains(key))
		{
			attrOrder.Add(key);
		}
		Weapon weapon_ = ((KeyValuePair<int, Doctrine.WRA_Weapon>)e.Node.Tag).Value.WriteInterruptibleField(Client.CurrentScenario, key);
		KeyValuePair<int, Doctrine.WRA_Weapon> keyValuePair = (KeyValuePair<int, Doctrine.WRA_Weapon>)e.Node.Tag;
		e.Node.Nodes.Clear();
		Contact contact_ = null;
		if (Client.SelectedUnit != null)
		{
			contact_ = (Client.SelectedUnit.DisableWriter() ? ((Contact)Client.SelectedUnit) : Client.CurrentSide.Contacts.Where((KeyValuePair<string, Contact> x) => x.Value.ActualUnit != null && Operators.CompareString(x.Value.ActualUnit.ObjectID, Client.SelectedUnit.ObjectID, TextCompare: true) == 0).FirstOrDefault().Value);
		}
		Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = keyValuePair.Value.WRA_WeaponTargets;
		Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
		foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
		{
			int num = recordOrder.FillRepository(ref wRA_FiringDoctrineEntry.TargetType, wRA_FiringDoctrineEntry.WeaponQty);
			int num2 = recordOrder.PopRepository(wRA_FiringDoctrineEntry.ShooterQty);
			int num3 = recordOrder.CreateRepository(ref wRA_FiringDoctrineEntry.TargetType, wRA_FiringDoctrineEntry.SelfDefenceRange);
			int num4 = recordOrder.ReadRepository(wRA_FiringDoctrineEntry.FiringRange);
			TreeGridNode treeGridNode = e.Node.Nodes.Add(Doctrine.WRA_TargetType_String(wRA_FiringDoctrineEntry.TargetType, bool_0: false), num, num2, num4, num3);
			treeGridNode.Tag = wRA_FiringDoctrineEntry;
			if (Doctrine.WRA_IsTopNodeTargetType(ref wRA_FiringDoctrineEntry.TargetType))
			{
				treeGridNode.DefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
			}
			if (contact_ != null)
			{
				Weapon weapon_2 = weapon_;
				bool? nullable_ = false;
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_2, ref nullable_);
				Weapon weapon_3 = weapon_;
				nullable_ = null;
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType2 = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_3, ref nullable_);
				if ((wRA_FiringDoctrineEntry.TargetType == wRA_WeaponTargetType) | (wRA_FiringDoctrineEntry.TargetType == wRA_WeaponTargetType2))
				{
					treeGridNode.DefaultCellStyle.ForeColor = Color.LightGreen;
				}
			}
		}
		foreach (TreeGridNode node in e.Node.Nodes)
		{
			DataTable dataTable_ = new DataTable();
			DataTable dataTable_2 = new DataTable();
			DataTable dataTable_3 = new DataTable();
			DataTable dataTable_4 = new DataTable();
			Doctrine._WRA_WeaponTargetType targetType = ((Doctrine.WRA_FiringDoctrineEntry)node.Tag).TargetType;
			DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)node.Cells[WeaponsPerSalvo.Index];
			DataGridViewComboBoxCell dataGridViewComboBoxCell2 = (DataGridViewComboBoxCell)node.Cells[ShootersPerSalvo.Index];
			DataGridViewComboBoxCell dataGridViewComboBoxCell3 = (DataGridViewComboBoxCell)node.Cells[SelfDefenceRange.Index];
			DataGridViewComboBoxCell dataGridViewComboBoxCell4 = (DataGridViewComboBoxCell)node.Cells[FiringRange.Index];
			recordOrder.ComboBoxDataSource_WeaponQty(ref dataTable_, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell.Value));
			recordOrder.ComboBoxDataSource_ShooterQty(ref dataTable_2, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell2.Value));
			recordOrder.ComboBoxDataSource_SelfDefenceRange(ref dataTable_3, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell3.Value));
			recordOrder.ComboBoxDataSource_FiringRange(ref dataTable_4, targetType, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell4.Value));
			if (Conversions.ToInteger(dataGridViewComboBoxCell3.Value) > dataTable_3.Rows.Count)
			{
				dataTable_3.Rows.Add(dataGridViewComboBoxCell3.Value, recordOrder.DisableRepository(((Doctrine.WRA_FiringDoctrineEntry)node.Tag).SelfDefenceRange, bool_0: false));
			}
			if (Conversions.ToInteger(dataGridViewComboBoxCell4.Value) > dataTable_4.Rows.Count)
			{
				dataTable_4.Rows.Add(dataGridViewComboBoxCell4.Value, recordOrder.UpdateRepository(((Doctrine.WRA_FiringDoctrineEntry)node.Tag).FiringRange, bool_0: false));
			}
			dataGridViewComboBoxCell.DataSource = dataTable_;
			dataGridViewComboBoxCell.DisplayMember = "Description";
			dataGridViewComboBoxCell.ValueMember = "ID";
			dataGridViewComboBoxCell2.DataSource = dataTable_2;
			dataGridViewComboBoxCell2.DisplayMember = "Description";
			dataGridViewComboBoxCell2.ValueMember = "ID";
			dataGridViewComboBoxCell3.DataSource = dataTable_3;
			dataGridViewComboBoxCell3.DisplayMember = "Description";
			dataGridViewComboBoxCell3.ValueMember = "ID";
			dataGridViewComboBoxCell4.DataSource = dataTable_4;
			dataGridViewComboBoxCell4.DisplayMember = "Description";
			dataGridViewComboBoxCell4.ValueMember = "ID";
		}
	}

	private void CloneException(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			attrOrder.Remove(((KeyValuePair<int, Doctrine.WRA_Weapon>)e.Node.Tag).Key);
		}
	}

	private void ConnectException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if ((object)Subject.GetType() == typeof(Side))
			{
				if (!Information.IsNothing(((Side)Subject).Doctrine.WRA))
				{
					((Side)Subject).Doctrine.WRA = null;
				}
			}
			else if (Subject.IsMission)
			{
				if (isEscorts)
				{
					if (((Strike)Subject).MissionClass == Mission._MissionClass.Strike && !Information.IsNothing(((Strike)Subject).Doctrine_Escorts.WRA))
					{
						((Strike)Subject).Doctrine_Escorts.WRA = null;
					}
				}
				else if (!Information.IsNothing(((Mission)Subject).Doctrine.WRA))
				{
					((Mission)Subject).Doctrine.WRA = null;
				}
			}
			else if (Subject.IsGroup)
			{
				if (!Information.IsNothing(((Group)Subject).Doctrine.WRA))
				{
					((Group)Subject).Doctrine.WRA = null;
				}
			}
			else if (Subject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				if (activeUnit.IsWeapon)
				{
					return;
				}
				if (!Information.IsNothing(activeUnit.Doctrine.WRA))
				{
					activeUnit.Doctrine.WRA = null;
				}
			}
		}
		else
		{
			if (!Information.IsNothing(recordOrder.WRA))
			{
				recordOrder.WRA = null;
			}
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (!Information.IsNothing(selectedUnit.Doctrine.WRA))
				{
					selectedUnit.Doctrine.WRA = null;
				}
			}
		}
		ResolveSingleton();
	}

	private void MoveException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if (Information.IsNothing(Subject))
			{
				return;
			}
			if ((object)Subject.GetType() == typeof(Side))
			{
				foreach (ActiveUnit unit in Client.CurrentSide.Units)
				{
					if (!unit.IsWeapon && !Information.IsNothing(unit.Doctrine.WRA))
					{
						unit.Doctrine.WRA = null;
					}
				}
				return;
			}
			{
				foreach (ActiveUnit item in recordOrder.LoginRepository(Client.CurrentScenario, isEscorts))
				{
					if (item.IsGroup)
					{
						if (!Information.IsNothing(item.Doctrine.WRA))
						{
							item.Doctrine.WRA = null;
						}
					}
					else if (item.IsActiveUnit && !item.IsWeapon && !Information.IsNothing(item.Doctrine.WRA))
					{
						item.Doctrine.WRA = null;
					}
				}
				return;
			}
		}
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			foreach (ActiveUnit item2 in selectedUnit.Doctrine.LoginRepository(Client.CurrentScenario, isEscorts))
			{
				if (item2.IsGroup)
				{
					if (!Information.IsNothing(item2.Doctrine.WRA))
					{
						item2.Doctrine.WRA = null;
					}
				}
				else if (item2.IsActiveUnit && !item2.IsWeapon && !Information.IsNothing(item2.Doctrine.WRA))
				{
					item2.Doctrine.WRA = null;
				}
			}
		}
	}

	private void DeleteException(object sender, EventArgs e)
	{
		if (Information.IsNothing(Subject) || (object)Subject.GetType() != typeof(Side))
		{
			return;
		}
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!Information.IsNothing(mission.Doctrine.WRA))
			{
				mission.Doctrine.WRA = null;
			}
		}
	}

	private void AddException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if ((object)Subject.GetType() != typeof(Side))
			{
				if (Subject.IsMission)
				{
					Doctrine doctrine_ = (isEscorts ? ((Strike)Subject).Doctrine_Escorts : ((Mission)Subject).Doctrine);
					ActiveUnit activeUnit_ = null;
					Doctrine.ResetDoctrineSettings(ref activeUnit_, ref doctrine_, Client.CurrentScenario);
				}
				else if (Subject.IsGroup)
				{
					Doctrine doctrine_2 = ((Group)Subject).Doctrine;
					ActiveUnit activeUnit_2 = null;
					Doctrine.ResetDoctrineSettings(ref activeUnit_2, ref doctrine_2, Client.CurrentScenario);
				}
				else if (Subject.IsActiveUnit)
				{
					ActiveUnit activeUnit_3 = (ActiveUnit)Subject;
					if (activeUnit_3.IsWeapon)
					{
						return;
					}
					Doctrine.ResetDoctrineSettings(ref activeUnit_3, ref activeUnit_3.Doctrine, Client.CurrentScenario);
				}
			}
			recordOrder.ClearCachedParentDoctrine();
		}
		else
		{
			ActiveUnit activeUnit_4 = null;
			Doctrine.ResetDoctrineSettings(ref activeUnit_4, ref recordOrder, Client.CurrentScenario);
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				ActiveUnit activeUnit_5 = selectedUnit;
				if (!activeUnit_5.IsWeapon)
				{
					Doctrine.ResetDoctrineSettings(ref activeUnit_5, ref activeUnit_5.Doctrine, Client.CurrentScenario);
				}
			}
			recordOrder = ValidateException();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: true);
		VerifySingleton();
	}

	private void DestroyException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if (!Information.IsNothing(Subject))
			{
				if ((object)Subject.GetType() == typeof(Side))
				{
					foreach (ActiveUnit unit in Client.CurrentSide.Units)
					{
						ActiveUnit activeUnit_ = unit;
						if (activeUnit_.IsGroup)
						{
							Doctrine.ResetDoctrineSettings(ref activeUnit_, ref activeUnit_.Doctrine, Client.CurrentScenario);
						}
						else if (activeUnit_.IsActiveUnit && !activeUnit_.IsWeapon)
						{
							Doctrine.ResetDoctrineSettings(ref activeUnit_, ref activeUnit_.Doctrine, Client.CurrentScenario);
						}
					}
				}
				else
				{
					foreach (ActiveUnit item in recordOrder.LoginRepository(Client.CurrentScenario, isEscorts))
					{
						ActiveUnit activeUnit_2 = item;
						if (activeUnit_2.IsGroup)
						{
							Doctrine.ResetDoctrineSettings(ref activeUnit_2, ref activeUnit_2.Doctrine, Client.CurrentScenario);
						}
						else if (activeUnit_2.IsActiveUnit && !activeUnit_2.IsWeapon)
						{
							Doctrine.ResetDoctrineSettings(ref activeUnit_2, ref activeUnit_2.Doctrine, Client.CurrentScenario);
						}
					}
				}
			}
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: true);
			VerifySingleton();
			return;
		}
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			foreach (ActiveUnit item2 in selectedUnit.Doctrine.LoginRepository(Client.CurrentScenario, isEscorts))
			{
				ActiveUnit activeUnit_3 = item2;
				if (activeUnit_3.IsGroup)
				{
					Doctrine.ResetDoctrineSettings(ref activeUnit_3, ref activeUnit_3.Doctrine, Client.CurrentScenario);
				}
				else if (activeUnit_3.IsActiveUnit && !activeUnit_3.IsWeapon)
				{
					Doctrine.ResetDoctrineSettings(ref activeUnit_3, ref activeUnit_3.Doctrine, Client.CurrentScenario);
				}
			}
		}
	}

	private void ComputeException(object sender, EventArgs e)
	{
		if (!Information.IsNothing(Subject) && (object)Subject.GetType() == typeof(Side))
		{
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				ActiveUnit activeUnit_ = null;
				Doctrine.ResetDoctrineSettings(ref activeUnit_, ref mission.Doctrine, Client.CurrentScenario);
			}
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: true);
		VerifySingleton();
	}

	private void PatchException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if ((object)Subject.GetType() != typeof(Side))
			{
				if (Subject.IsMission)
				{
					if (isEscorts)
					{
						if (!((Strike)Subject).Doctrine_Escorts.EMCON_Inherits)
						{
							((Strike)Subject).Doctrine_Escorts.EMCON_Inherits = true;
						}
					}
					else if (!((Mission)Subject).Doctrine.EMCON_Inherits)
					{
						((Mission)Subject).Doctrine.EMCON_Inherits = true;
					}
				}
				else if (Subject.IsGroup)
				{
					if (!((Group)Subject).Doctrine.EMCON_Inherits)
					{
						((Group)Subject).Doctrine.EMCON_Inherits = true;
					}
				}
				else if (Subject.IsActiveUnit)
				{
					ActiveUnit activeUnit = (ActiveUnit)Subject;
					if (activeUnit.IsWeapon)
					{
						return;
					}
					if (!activeUnit.Doctrine.EMCON_Inherits)
					{
						activeUnit.Doctrine.EMCON_Inherits = true;
					}
				}
			}
		}
		else
		{
			ActiveUnit activeUnit_ = null;
			Doctrine.ResetDoctrineSettings(ref activeUnit_, ref recordOrder, Client.CurrentScenario);
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				if (selectedUnit.IsGroup)
				{
					if (!((Group)selectedUnit).Doctrine.EMCON_Inherits)
					{
						((Group)selectedUnit).Doctrine.EMCON_Inherits = true;
					}
				}
				else if (selectedUnit.IsActiveUnit)
				{
					ActiveUnit activeUnit2 = selectedUnit;
					if (activeUnit2.IsWeapon)
					{
						return;
					}
					if (!activeUnit2.Doctrine.EMCON_Inherits)
					{
						activeUnit2.Doctrine.EMCON_Inherits = true;
					}
				}
			}
		}
		if (!isAirOps && !isBoatOps)
		{
			Scenario scenario_ = Client.CurrentScenario;
			EmconControl.AskEMCONObedience(ref scenario_, ref recordOrder, ref isEscorts, bool_1: true, bool_2: false);
			Client.MustRefreshMainForm = true;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
		ListSingleton();
	}

	private void SelectException(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedUnits))
		{
			if ((object)Subject.GetType() == typeof(Side))
			{
				foreach (ActiveUnit unit in Client.CurrentSide.Units)
				{
					if (unit.IsGroup)
					{
						if (!unit.Doctrine.EMCON_Inherits)
						{
							unit.Doctrine.EMCON_Inherits = true;
						}
					}
					else if (unit.IsActiveUnit)
					{
						if (unit.IsWeapon)
						{
							continue;
						}
						if (!unit.Doctrine.EMCON_Inherits)
						{
							unit.Doctrine.EMCON_Inherits = true;
						}
					}
					unit.Sensory.vmethod_0(unit.Sensors_Cached);
				}
			}
			else
			{
				foreach (ActiveUnit item in recordOrder.LoginRepository(Client.CurrentScenario, isEscorts))
				{
					if (item.IsGroup)
					{
						if (!item.Doctrine.EMCON_Inherits)
						{
							item.Doctrine.EMCON_Inherits = true;
						}
					}
					else if (item.IsActiveUnit)
					{
						if (item.IsWeapon)
						{
							continue;
						}
						if (!item.Doctrine.EMCON_Inherits)
						{
							item.Doctrine.EMCON_Inherits = true;
						}
					}
					item.Sensory.vmethod_0(item.Sensors_Cached);
				}
			}
		}
		else
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				foreach (ActiveUnit item2 in selectedUnit.Doctrine.LoginRepository(Client.CurrentScenario, isEscorts))
				{
					if (item2.IsGroup)
					{
						if (!item2.Doctrine.EMCON_Inherits)
						{
							item2.Doctrine.EMCON_Inherits = true;
						}
					}
					else if (item2.IsActiveUnit)
					{
						if (item2.IsWeapon)
						{
							continue;
						}
						if (!item2.Doctrine.EMCON_Inherits)
						{
							item2.Doctrine.EMCON_Inherits = true;
						}
					}
					item2.Sensory.vmethod_0(item2.Sensors_Cached);
				}
			}
		}
		if (Information.IsNothing(SelectedUnits))
		{
			recordOrder.FireEvent_EmconChanged(Subject, false, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		}
		else
		{
			foreach (ActiveUnit selectedUnit2 in SelectedUnits)
			{
				selectedUnit2.Doctrine.FireEvent_EmconChanged(selectedUnit2, false, bool_0: true, bool_1: true, bool_2: false, bool_3: false);
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
		ListSingleton();
	}

	private void CallException(object sender, EventArgs e)
	{
		if (!Information.IsNothing(Subject) && (object)Subject.GetType() == typeof(Side))
		{
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (!mission.Doctrine.EMCON_Inherits)
				{
					mission.Doctrine.EMCON_Inherits = true;
				}
			}
		}
		if (Information.IsNothing(SelectedUnits))
		{
			recordOrder.FireEvent_EmconChanged(Subject, false, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
		}
		else
		{
			foreach (ActiveUnit selectedUnit in SelectedUnits)
			{
				selectedUnit.Doctrine.FireEvent_EmconChanged(selectedUnit, false, bool_0: true, bool_1: true, bool_2: false, bool_3: false);
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
		ListSingleton();
	}

	private void LogoutException(object sender, FormClosedEventArgs e)
	{
		Doctrine.DoctrineChanged -= VisitSingleton;
		Doctrine.EmconChanged -= RestartSingleton;
	}

	private void ViewException(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (Information.IsNothing(Subject) || (object)Subject.GetType() != typeof(Waypoint))
		{
			return;
		}
		bool flag = false;
		Waypoint value = (Waypoint)Subject;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i++)
		{
			foreach (Mission mission in sides_ReadOnly[i].Missions)
			{
				foreach (Mission.Flight flight2 in mission.FlightList)
				{
					if (flight2.FlightPlan.Contains(value))
					{
						Scenario currentScenario = Client.CurrentScenario;
						ActiveUnit referenceUnit = flight2.GetReferenceUnit(Client.CurrentScenario);
						Mission.Flight flight;
						Waypoint[] waypoint_ = (flight = flight2).FlightPlan;
						float float_ = 0f;
						float float_2 = 0f;
						MissionPlanner.ConnectTokenizer(currentScenario, mission, referenceUnit, flight2, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
						flight.FlightPlan = waypoint_;
						RegistryParameterMessage.AwakeCustomer();
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (Client.FlightPlanEditorWindow.Visible)
		{
			Client.FlightPlanEditorWindow.InvokePolicy();
		}
	}

	private Doctrine ValidateException()
	{
		int num = 0;
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			selectedUnit.Doctrine.ClearCachedParentDoctrine();
			num++;
			if (num == 1)
			{
				Aircraft aircraft = new Aircraft(ref selectedUnit.ParentScen);
				aircraft.SetUnitSide(bool_0: false, selectedUnit.GetUnitSide());
				if (selectedUnit.AssignedMissionOrPackage() != null)
				{
					Mission mission_ = selectedUnit.AssignedMissionOrPackage();
					Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
					aircraft.Set_AssignedMissionOrPackage(mission_, bool_0: true, bool_1: false, ref missionAssignmentAttemptResult_);
				}
				aircraft.AI.IsEscort = selectedUnit.AI.IsEscort;
				if (selectedUnit.IsAircraft)
				{
					aircraft.AirOps.Condition = ((Aircraft)selectedUnit).AirOps.Condition;
				}
				else
				{
					aircraft.DockingOps.Condition = selectedUnit.DockingOps.Condition;
				}
				List<ActiveUnit> list_ = SelectedUnits;
				Doctrine doctrine = new Doctrine(aircraft, ref list_);
				SelectedUnits = list_;
				recordOrder = doctrine;
				m_ParamsOrder = null;
				_InfoOrder = null;
				_HelperOrder = null;
				m_MapperOrder = null;
				m_ManagerOrder = null;
				observerSpecification = null;
				m_GetterOrder = null;
				_ProducerOrder = null;
				_ConfigSpecification = null;
				m_ListenerSpecification = null;
				procOrder = null;
				m_CallbackSpecification = null;
				m_DecoratorSpecification = null;
				m_ProcessSpecification = null;
				threadSpecification = null;
				_RuleSpecification = null;
				m_CollectionSpecification = null;
				_InstanceSpecification = null;
				_ParameterSpecification = null;
				expressionSpecification = null;
				_DispatcherSpecification = null;
				_RegistrySpecification = null;
				definitionSpecification = Doctrine.EMCONSettings._EMCONSetting.Passive;
				_ValSpecification = Doctrine.EMCONSettings._EMCONSetting.Passive;
				wrapperSpecification = Doctrine.EMCONSettings._EMCONSetting.Passive;
				issuerSpecification = null;
				clientSpecification = null;
				m_DicSpecification = null;
				m_ConsumerSpecification = null;
				facadeSpecification = null;
				facadeSpecification = null;
				m_ReaderSpecification = null;
				propertySpecification = null;
				m_StructSpecification = null;
				_ImporterSpecification = null;
				repositorySpecification = null;
				m_BridgeSpecification = null;
				m_InvocationSpecification = null;
				_ClassSpecification = null;
				m_RequestSpecification = null;
				m_ValueSpecification = null;
				_TokenizerSpecification = null;
				_StubSpecification = null;
				writerSpecification = null;
				m_SpecificationSpecification = null;
				if (selectedUnit.Doctrine.NukesAllowed_Inherits())
				{
					m_ParamsOrder = selectedUnit.Doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine12 = selectedUnit.Doctrine;
					Scenario currentScenario = Client.CurrentScenario;
					bool bool_ = true;
					m_ParamsOrder = doctrine12.GetParentDoctrine(currentScenario, ref bool_).GetNukesAllowed(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					_InfoOrder = selectedUnit.Doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
					Doctrine doctrine23 = selectedUnit.Doctrine;
					Scenario currentScenario12 = Client.CurrentScenario;
					bool bool_12 = true;
					_InfoOrder = doctrine23.GetParentDoctrine(currentScenario12, ref bool_12).GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: true, null, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					_HelperOrder = selectedUnit.Doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
					Doctrine doctrine34 = selectedUnit.Doctrine;
					Scenario currentScenario23 = Client.CurrentScenario;
					bool bool_23 = true;
					_HelperOrder = doctrine34.GetParentDoctrine(currentScenario23, ref bool_23).GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: true, null, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					m_MapperOrder = selectedUnit.Doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
					Doctrine doctrine45 = selectedUnit.Doctrine;
					Scenario currentScenario34 = Client.CurrentScenario;
					bool bool_34 = true;
					m_MapperOrder = doctrine45.GetParentDoctrine(currentScenario34, ref bool_34).GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: true, null, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					m_ManagerOrder = selectedUnit.Doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
					Doctrine doctrine56 = selectedUnit.Doctrine;
					Scenario currentScenario45 = Client.CurrentScenario;
					bool bool_45 = true;
					m_ManagerOrder = doctrine56.GetParentDoctrine(currentScenario45, ref bool_45).GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: true, null, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.GunStrafing_Inherits())
				{
					observerSpecification = selectedUnit.Doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine67 = selectedUnit.Doctrine;
					Scenario currentScenario56 = Client.CurrentScenario;
					bool bool_56 = true;
					observerSpecification = doctrine67.GetParentDoctrine(currentScenario56, ref bool_56).GetGunStrafing(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.IgnorePlottedCourse_Inherits())
				{
					m_GetterOrder = selectedUnit.Doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false));
					Doctrine doctrine78 = selectedUnit.Doctrine;
					Scenario currentScenario67 = Client.CurrentScenario;
					bool bool_67 = true;
					m_GetterOrder = doctrine78.GetParentDoctrine(currentScenario67, ref bool_67).GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: true, null, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					_ProducerOrder = selectedUnit.Doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine85 = selectedUnit.Doctrine;
					Scenario currentScenario78 = Client.CurrentScenario;
					bool bool_78 = true;
					_ProducerOrder = doctrine85.GetParentDoctrine(currentScenario78, ref bool_78).GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WinchesterShotgun_Inherits())
				{
					_ConfigSpecification = selectedUnit.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, selectedUnit.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
					Doctrine doctrine2 = selectedUnit.Doctrine;
					Scenario currentScenario84 = Client.CurrentScenario;
					bool bool_84 = true;
					_ConfigSpecification = doctrine2.GetParentDoctrine(currentScenario84, ref bool_84).GetWinchesterShotgun(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.BingoJokerRTB_Inherits())
				{
					procOrder = selectedUnit.Doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine3 = selectedUnit.Doctrine;
					Scenario currentScenario2 = Client.CurrentScenario;
					bool bool_2 = true;
					procOrder = doctrine3.GetParentDoctrine(currentScenario2, ref bool_2).GetBingoJokerRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.BingoJoker_Inherits())
				{
					m_ListenerSpecification = selectedUnit.Doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, selectedUnit.Doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
					Doctrine doctrine4 = selectedUnit.Doctrine;
					Scenario currentScenario3 = Client.CurrentScenario;
					bool bool_3 = true;
					m_ListenerSpecification = doctrine4.GetParentDoctrine(currentScenario3, ref bool_3).GetBingoJoker(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					m_CallbackSpecification = selectedUnit.Doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine5 = selectedUnit.Doctrine;
					Scenario currentScenario4 = Client.CurrentScenario;
					bool bool_4 = true;
					m_CallbackSpecification = doctrine5.GetParentDoctrine(currentScenario4, ref bool_4).GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.AutoEvade_Inherits())
				{
					m_DecoratorSpecification = selectedUnit.Doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine6 = selectedUnit.Doctrine;
					Scenario currentScenario5 = Client.CurrentScenario;
					bool bool_5 = true;
					m_DecoratorSpecification = doctrine6.GetParentDoctrine(currentScenario5, ref bool_5).GetAutoEvade(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.MaintainStandoff_Inherits())
				{
					m_ProcessSpecification = selectedUnit.Doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine7 = selectedUnit.Doctrine;
					Scenario currentScenario6 = Client.CurrentScenario;
					bool bool_6 = true;
					m_ProcessSpecification = doctrine7.GetParentDoctrine(currentScenario6, ref bool_6).GetMaintainStandoff(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.UseReplenishment_Inherits())
				{
					threadSpecification = selectedUnit.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, selectedUnit.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
					Doctrine doctrine8 = selectedUnit.Doctrine;
					Scenario currentScenario7 = Client.CurrentScenario;
					bool bool_7 = true;
					threadSpecification = doctrine8.GetParentDoctrine(currentScenario7, ref bool_7).GetUseReplenishment(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.ReplenishmentSelection_Inherits())
				{
					_RuleSpecification = selectedUnit.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, selectedUnit.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false));
					Doctrine doctrine9 = selectedUnit.Doctrine;
					Scenario currentScenario8 = Client.CurrentScenario;
					bool bool_8 = true;
					_RuleSpecification = doctrine9.GetParentDoctrine(currentScenario8, ref bool_8).GetReplenishmentSelection(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.ShootTourists_Inherits())
				{
					m_CollectionSpecification = selectedUnit.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine10 = selectedUnit.Doctrine;
					Scenario currentScenario9 = Client.CurrentScenario;
					bool bool_9 = true;
					m_CollectionSpecification = doctrine10.GetParentDoctrine(currentScenario9, ref bool_9).GetShootTourists(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.UseSAMsOnASuW_Inherits())
				{
					_InstanceSpecification = selectedUnit.Doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine11 = selectedUnit.Doctrine;
					Scenario currentScenario10 = Client.CurrentScenario;
					bool bool_10 = true;
					_InstanceSpecification = doctrine11.GetParentDoctrine(currentScenario10, ref bool_10).GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					_ParameterSpecification = selectedUnit.Doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine13 = selectedUnit.Doctrine;
					Scenario currentScenario11 = Client.CurrentScenario;
					bool bool_11 = true;
					_ParameterSpecification = doctrine13.GetParentDoctrine(currentScenario11, ref bool_11).GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					expressionSpecification = selectedUnit.Doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, selectedUnit.Doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false));
					expressionSpecification = selectedUnit.Doctrine.GetParentDoctrine(Client.CurrentScenario, ref UnitIsOperating).GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: true, bool_1: true, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.AirOpsTempo_Inherits())
				{
					_DispatcherSpecification = selectedUnit.Doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
				}
				else
				{
					recordOrder.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, selectedUnit.Doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false));
					_DispatcherSpecification = selectedUnit.Doctrine.GetParentDoctrine(Client.CurrentScenario, ref UnitIsOperating).GetAirOpsTempo(Client.CurrentScenario, bool_0: true, bool_1: true, bool_2: false, bool_3: false);
				}
				if (selectedUnit.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					_RegistrySpecification = selectedUnit.Doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine14 = selectedUnit.Doctrine;
					Scenario currentScenario13 = Client.CurrentScenario;
					bool bool_13 = true;
					_RegistrySpecification = doctrine14.GetParentDoctrine(currentScenario13, ref bool_13).GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					m_InvocationSpecification = selectedUnit.Doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine15 = selectedUnit.Doctrine;
					Scenario currentScenario14 = Client.CurrentScenario;
					bool bool_14 = true;
					m_InvocationSpecification = doctrine15.GetParentDoctrine(currentScenario14, ref bool_14).GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					_ClassSpecification = selectedUnit.Doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine16 = selectedUnit.Doctrine;
					Scenario currentScenario15 = Client.CurrentScenario;
					bool bool_15 = true;
					_ClassSpecification = doctrine16.GetParentDoctrine(currentScenario15, ref bool_15).GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					m_RequestSpecification = selectedUnit.Doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine17 = selectedUnit.Doctrine;
					Scenario currentScenario16 = Client.CurrentScenario;
					bool bool_16 = true;
					m_RequestSpecification = doctrine17.GetParentDoctrine(currentScenario16, ref bool_16).GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					m_ValueSpecification = selectedUnit.Doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine18 = selectedUnit.Doctrine;
					Scenario currentScenario17 = Client.CurrentScenario;
					bool bool_17 = true;
					m_ValueSpecification = doctrine18.GetParentDoctrine(currentScenario17, ref bool_17).GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RedeployDamageThreshold_Inherits())
				{
					_TokenizerSpecification = selectedUnit.Doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine19 = selectedUnit.Doctrine;
					Scenario currentScenario18 = Client.CurrentScenario;
					bool bool_18 = true;
					_TokenizerSpecification = doctrine19.GetParentDoctrine(currentScenario18, ref bool_18).GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RedeployFuelThreshold_Inherits())
				{
					_StubSpecification = selectedUnit.Doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine20 = selectedUnit.Doctrine;
					Scenario currentScenario19 = Client.CurrentScenario;
					bool bool_19 = true;
					_StubSpecification = doctrine20.GetParentDoctrine(currentScenario19, ref bool_19).GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RedeployAttackThreshold_Inherits())
				{
					writerSpecification = selectedUnit.Doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine21 = selectedUnit.Doctrine;
					Scenario currentScenario20 = Client.CurrentScenario;
					bool bool_20 = true;
					writerSpecification = doctrine21.GetParentDoctrine(currentScenario20, ref bool_20).GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					m_SpecificationSpecification = selectedUnit.Doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine22 = selectedUnit.Doctrine;
					Scenario currentScenario21 = Client.CurrentScenario;
					bool bool_21 = true;
					m_SpecificationSpecification = doctrine22.GetParentDoctrine(currentScenario21, ref bool_21).GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.EMCON_Inherits)
				{
					recordOrder.EMCON_Inherits = true;
					definitionSpecification = selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField();
					_ValSpecification = selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField();
					wrapperSpecification = selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM();
				}
				else
				{
					recordOrder.EMCON_Inherits = false;
					recordOrder.SetEMCON_Radar(selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField(), Client.CurrentScenario);
					recordOrder.SetEMCON_Sonar(selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField(), Client.CurrentScenario);
					recordOrder.SetEMCON_OECM(selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM(), Client.CurrentScenario);
				}
				if (selectedUnit.Doctrine.RefuelAllies_Inherits())
				{
					issuerSpecification = selectedUnit.Doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine24 = selectedUnit.Doctrine;
					Scenario currentScenario22 = Client.CurrentScenario;
					bool bool_22 = true;
					issuerSpecification = doctrine24.GetParentDoctrine(currentScenario22, ref bool_22).GetRefuelAllies(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.BingoThreshold_Inherits)
				{
					clientSpecification = selectedUnit.Doctrine.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine25 = selectedUnit.Doctrine;
					Scenario currentScenario24 = Client.CurrentScenario;
					bool bool_24 = true;
					clientSpecification = doctrine25.GetParentDoctrine(currentScenario24, ref bool_24).GetBingoThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.AvoidContact_Inherits())
				{
					m_DicSpecification = selectedUnit.Doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine26 = selectedUnit.Doctrine;
					Scenario currentScenario25 = Client.CurrentScenario;
					bool bool_25 = true;
					m_DicSpecification = doctrine26.GetParentDoctrine(currentScenario25, ref bool_25).GetAvoidContact(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					m_ConsumerSpecification = selectedUnit.Doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine27 = selectedUnit.Doctrine;
					Scenario currentScenario26 = Client.CurrentScenario;
					bool bool_26 = true;
					m_ConsumerSpecification = doctrine27.GetParentDoctrine(currentScenario26, ref bool_26).GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RechargePercentagePatrol_Inherits())
				{
					facadeSpecification = selectedUnit.Doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine28 = selectedUnit.Doctrine;
					Scenario currentScenario27 = Client.CurrentScenario;
					bool bool_27 = true;
					facadeSpecification = doctrine28.GetParentDoctrine(currentScenario27, ref bool_27).GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.RechargePercentageAttack_Inherits())
				{
					_ProxySpecification = selectedUnit.Doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine29 = selectedUnit.Doctrine;
					Scenario currentScenario28 = Client.CurrentScenario;
					bool bool_28 = true;
					_ProxySpecification = doctrine29.GetParentDoctrine(currentScenario28, ref bool_28).GetRechargePercentageAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.AIPUsage_Inherits())
				{
					m_ReaderSpecification = selectedUnit.Doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine30 = selectedUnit.Doctrine;
					Scenario currentScenario29 = Client.CurrentScenario;
					bool bool_29 = true;
					m_ReaderSpecification = doctrine30.GetParentDoctrine(currentScenario29, ref bool_29).method_2(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.DippingSonar_Inherits())
				{
					propertySpecification = selectedUnit.Doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine31 = selectedUnit.Doctrine;
					Scenario currentScenario30 = Client.CurrentScenario;
					bool bool_30 = true;
					propertySpecification = doctrine31.GetParentDoctrine(currentScenario30, ref bool_30).GetDippingSonar(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.JettisonOrdnance_Inherits())
				{
					m_StructSpecification = selectedUnit.Doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine32 = selectedUnit.Doctrine;
					Scenario currentScenario31 = Client.CurrentScenario;
					bool bool_31 = true;
					m_StructSpecification = doctrine32.GetParentDoctrine(currentScenario31, ref bool_31).GetJettison(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.BVRLogic_Inherits())
				{
					_MerchantSpecification = selectedUnit.Doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine33 = selectedUnit.Doctrine;
					Scenario currentScenario32 = Client.CurrentScenario;
					bool bool_32 = true;
					_MerchantSpecification = doctrine33.GetParentDoctrine(currentScenario32, ref bool_32).method_0(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.SurfaceNavigation_Inherits())
				{
					_ImporterSpecification = selectedUnit.Doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine35 = selectedUnit.Doctrine;
					Scenario currentScenario33 = Client.CurrentScenario;
					bool bool_33 = true;
					_ImporterSpecification = doctrine35.GetParentDoctrine(currentScenario33, ref bool_33).GetSurfaceNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.SubmarineNavigation_Inherits())
				{
					repositorySpecification = selectedUnit.Doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				}
				else
				{
					recordOrder.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
					Doctrine doctrine36 = selectedUnit.Doctrine;
					Scenario currentScenario35 = Client.CurrentScenario;
					bool bool_35 = true;
					repositorySpecification = doctrine36.GetParentDoctrine(currentScenario35, ref bool_35).GetSubmarineNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				}
				if (selectedUnit.Doctrine.LandNavigation_Inherits())
				{
					m_BridgeSpecification = selectedUnit.Doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					continue;
				}
				recordOrder.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, selectedUnit.Doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false));
				Doctrine doctrine37 = selectedUnit.Doctrine;
				Scenario currentScenario36 = Client.CurrentScenario;
				bool bool_36 = true;
				m_BridgeSpecification = doctrine37.GetParentDoctrine(currentScenario36, ref bool_36).GetLandNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
				continue;
			}
			byte? b = (byte?)recordOrder.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			byte? b2;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.NukesAllowed_Inherits() && !selectedUnit.Doctrine.NukesAllowed_Inherits())
				{
					b = (byte?)recordOrder.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
					}
				}
				else if (recordOrder.NukesAllowed_Inherits() && !selectedUnit.Doctrine.NukesAllowed_Inherits())
				{
					recordOrder.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
				}
				else if (!recordOrder.NukesAllowed_Inherits() && selectedUnit.Doctrine.NukesAllowed_Inherits())
				{
					recordOrder.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
				}
			}
			b2 = (byte?)m_ParamsOrder;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.NukesAllowed_Inherits())
				{
					b = (byte?)m_ParamsOrder;
					b2 = (byte?)selectedUnit.Doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ParamsOrder = Doctrine._UseNukesAllowed.Various;
					}
				}
				else
				{
					b2 = (byte?)m_ParamsOrder;
					Doctrine doctrine38 = selectedUnit.Doctrine;
					Scenario currentScenario37 = Client.CurrentScenario;
					bool bool_37 = true;
					b = (byte?)doctrine38.GetParentDoctrine(currentScenario37, ref bool_37).GetNukesAllowed(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ParamsOrder = Doctrine._UseNukesAllowed.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WeaponControlStatus_Air_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					b2 = (byte?)recordOrder.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (recordOrder.WeaponControlStatus_Air_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!recordOrder.WeaponControlStatus_Air_Inherits() && selectedUnit.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b = (byte?)_InfoOrder;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					b2 = (byte?)_InfoOrder;
					b = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_InfoOrder = Doctrine._WCS.Various;
					}
				}
				else
				{
					b = (byte?)_InfoOrder;
					Doctrine doctrine39 = selectedUnit.Doctrine;
					Scenario currentScenario38 = Client.CurrentScenario;
					bool bool_38 = true;
					b2 = (byte?)doctrine39.GetParentDoctrine(currentScenario38, ref bool_38).GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_InfoOrder = Doctrine._WCS.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WeaponControlStatus_Surface_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					b = (byte?)recordOrder.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (recordOrder.WeaponControlStatus_Surface_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!recordOrder.WeaponControlStatus_Surface_Inherits() && selectedUnit.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b2 = (byte?)_HelperOrder;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					b = (byte?)_HelperOrder;
					b2 = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_HelperOrder = Doctrine._WCS.Various;
					}
				}
				else
				{
					b2 = (byte?)_HelperOrder;
					Doctrine doctrine40 = selectedUnit.Doctrine;
					Scenario currentScenario39 = Client.CurrentScenario;
					bool bool_39 = true;
					b = (byte?)doctrine40.GetParentDoctrine(currentScenario39, ref bool_39).GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_HelperOrder = Doctrine._WCS.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WeaponControlStatus_Submarine_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					b2 = (byte?)recordOrder.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (recordOrder.WeaponControlStatus_Submarine_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!recordOrder.WeaponControlStatus_Submarine_Inherits() && selectedUnit.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b = (byte?)m_MapperOrder;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					b2 = (byte?)m_MapperOrder;
					b = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_MapperOrder = Doctrine._WCS.Various;
					}
				}
				else
				{
					b = (byte?)m_MapperOrder;
					Doctrine doctrine41 = selectedUnit.Doctrine;
					Scenario currentScenario40 = Client.CurrentScenario;
					bool bool_40 = true;
					b2 = (byte?)doctrine41.GetParentDoctrine(currentScenario40, ref bool_40).GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_MapperOrder = Doctrine._WCS.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WeaponControlStatus_Land_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					b = (byte?)recordOrder.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (recordOrder.WeaponControlStatus_Land_Inherits() && !selectedUnit.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!recordOrder.WeaponControlStatus_Land_Inherits() && selectedUnit.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					recordOrder.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b2 = (byte?)m_ManagerOrder;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					b = (byte?)m_ManagerOrder;
					b2 = (byte?)selectedUnit.Doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ManagerOrder = Doctrine._WCS.Various;
					}
				}
				else
				{
					b2 = (byte?)m_ManagerOrder;
					Doctrine doctrine42 = selectedUnit.Doctrine;
					Scenario currentScenario41 = Client.CurrentScenario;
					bool bool_41 = true;
					b = (byte?)doctrine42.GetParentDoctrine(currentScenario41, ref bool_41).GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ManagerOrder = Doctrine._WCS.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.GunStrafing_Inherits() && !selectedUnit.Doctrine.GunStrafing_Inherits())
				{
					b2 = (byte?)recordOrder.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
					}
				}
				else if (recordOrder.GunStrafing_Inherits() && !selectedUnit.Doctrine.GunStrafing_Inherits())
				{
					recordOrder.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
				}
				else if (!recordOrder.GunStrafing_Inherits() && selectedUnit.Doctrine.GunStrafing_Inherits())
				{
					recordOrder.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
				}
			}
			b = (byte?)observerSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.GunStrafing_Inherits())
				{
					b2 = (byte?)observerSpecification;
					b = (byte?)selectedUnit.Doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						observerSpecification = Doctrine._GunStrafeGroundTargets.Various;
					}
				}
				else
				{
					b = (byte?)observerSpecification;
					Doctrine doctrine43 = selectedUnit.Doctrine;
					Scenario currentScenario42 = Client.CurrentScenario;
					bool bool_42 = true;
					b2 = (byte?)doctrine43.GetParentDoctrine(currentScenario42, ref bool_42).GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						observerSpecification = Doctrine._GunStrafeGroundTargets.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.IgnorePlottedCourse_Inherits() && !selectedUnit.Doctrine.IgnorePlottedCourse_Inherits())
				{
					b = (byte?)recordOrder.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
					}
				}
				else if (recordOrder.IgnorePlottedCourse_Inherits() && !selectedUnit.Doctrine.IgnorePlottedCourse_Inherits())
				{
					recordOrder.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
				}
				else if (!recordOrder.IgnorePlottedCourse_Inherits() && selectedUnit.Doctrine.IgnorePlottedCourse_Inherits())
				{
					recordOrder.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
				}
			}
			b2 = (byte?)m_GetterOrder;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.IgnorePlottedCourse_Inherits())
				{
					b = (byte?)m_GetterOrder;
					b2 = (byte?)selectedUnit.Doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_GetterOrder = Doctrine._UseIgnorePlottedCourse.Various;
					}
				}
				else
				{
					b2 = (byte?)m_GetterOrder;
					Doctrine doctrine44 = selectedUnit.Doctrine;
					Scenario currentScenario43 = Client.CurrentScenario;
					bool bool_43 = true;
					b = (byte?)doctrine44.GetParentDoctrine(currentScenario43, ref bool_43).GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_GetterOrder = Doctrine._UseIgnorePlottedCourse.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WinchesterShotgunRTB_Inherits() && !selectedUnit.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					b2 = (byte?)recordOrder.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
					}
				}
				else if (recordOrder.WinchesterShotgunRTB_Inherits() && !selectedUnit.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					recordOrder.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
				}
				else if (!recordOrder.WinchesterShotgunRTB_Inherits() && selectedUnit.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					recordOrder.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
				}
			}
			b = (byte?)_ProducerOrder;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					b2 = (byte?)_ProducerOrder;
					b = (byte?)selectedUnit.Doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ProducerOrder = Doctrine._WeaponStateRTB.Various;
					}
				}
				else
				{
					b = (byte?)_ProducerOrder;
					Doctrine doctrine46 = selectedUnit.Doctrine;
					Scenario currentScenario44 = Client.CurrentScenario;
					bool bool_44 = true;
					b2 = (byte?)doctrine46.GetParentDoctrine(currentScenario44, ref bool_44).GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ProducerOrder = Doctrine._WeaponStateRTB.Various;
					}
				}
			}
			int? num2 = (int?)recordOrder.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null);
			int? num3;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WinchesterShotgun_Inherits() && !selectedUnit.Doctrine.WinchesterShotgun_Inherits())
				{
					num2 = (int?)recordOrder.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					num3 = (int?)selectedUnit.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
					}
				}
				else if (recordOrder.WinchesterShotgun_Inherits() && !selectedUnit.Doctrine.WinchesterShotgun_Inherits())
				{
					recordOrder.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
				}
				else if (!recordOrder.WinchesterShotgun_Inherits() && selectedUnit.Doctrine.WinchesterShotgun_Inherits())
				{
					recordOrder.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
				}
			}
			num3 = (int?)_ConfigSpecification;
			flag = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WinchesterShotgun_Inherits())
				{
					num2 = (int?)_ConfigSpecification;
					num3 = (int?)selectedUnit.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ConfigSpecification = Doctrine._WeaponState.Various;
					}
				}
				else
				{
					num3 = (int?)_ConfigSpecification;
					Doctrine doctrine47 = selectedUnit.Doctrine;
					Scenario currentScenario46 = Client.CurrentScenario;
					bool bool_46 = true;
					num2 = (int?)doctrine47.GetParentDoctrine(currentScenario46, ref bool_46).GetWinchesterShotgun(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() != num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ConfigSpecification = Doctrine._WeaponState.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.BingoJokerRTB_Inherits() && !selectedUnit.Doctrine.BingoJokerRTB_Inherits())
				{
					b = (byte?)recordOrder.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
					}
				}
				else if (recordOrder.BingoJokerRTB_Inherits() && !selectedUnit.Doctrine.BingoJokerRTB_Inherits())
				{
					recordOrder.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
				}
				else if (!recordOrder.BingoJokerRTB_Inherits() && selectedUnit.Doctrine.BingoJokerRTB_Inherits())
				{
					recordOrder.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
				}
			}
			b2 = (byte?)procOrder;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.BingoJokerRTB_Inherits())
				{
					b = (byte?)procOrder;
					b2 = (byte?)selectedUnit.Doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						procOrder = Doctrine._FuelStateRTB.Various;
					}
				}
				else
				{
					b2 = (byte?)procOrder;
					Doctrine doctrine48 = selectedUnit.Doctrine;
					Scenario currentScenario47 = Client.CurrentScenario;
					bool bool_47 = true;
					b = (byte?)doctrine48.GetParentDoctrine(currentScenario47, ref bool_47).GetBingoJokerRTB(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						procOrder = Doctrine._FuelStateRTB.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 12) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.BingoJoker_Inherits() && !selectedUnit.Doctrine.BingoJoker_Inherits())
				{
					b2 = (byte?)recordOrder.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b = (byte?)selectedUnit.Doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
					}
				}
				else if (recordOrder.BingoJoker_Inherits() && !selectedUnit.Doctrine.BingoJoker_Inherits())
				{
					recordOrder.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
				}
				else if (!recordOrder.BingoJoker_Inherits() && selectedUnit.Doctrine.BingoJoker_Inherits())
				{
					recordOrder.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
				}
			}
			b = (byte?)m_ListenerSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 12) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.BingoJoker_Inherits())
				{
					b2 = (byte?)m_ListenerSpecification;
					b = (byte?)selectedUnit.Doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ListenerSpecification = Doctrine._FuelState.Various;
					}
				}
				else
				{
					b = (byte?)m_ListenerSpecification;
					Doctrine doctrine49 = selectedUnit.Doctrine;
					Scenario currentScenario48 = Client.CurrentScenario;
					bool bool_48 = true;
					b2 = (byte?)doctrine49.GetParentDoctrine(currentScenario48, ref bool_48).GetBingoJoker(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ListenerSpecification = Doctrine._FuelState.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.BehaviorTowardsAmbigousTarget_Inherits() && !selectedUnit.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					b = (byte?)recordOrder.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
					}
				}
				else if (recordOrder.BehaviorTowardsAmbigousTarget_Inherits() && !selectedUnit.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					recordOrder.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
				}
				else if (!recordOrder.BehaviorTowardsAmbigousTarget_Inherits() && selectedUnit.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					recordOrder.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
				}
			}
			b2 = (byte?)m_CallbackSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					b = (byte?)m_CallbackSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_CallbackSpecification = Doctrine._BehaviorTowardsTargetAmbiguity.Various;
					}
				}
				else
				{
					b2 = (byte?)m_CallbackSpecification;
					Doctrine doctrine50 = selectedUnit.Doctrine;
					Scenario currentScenario49 = Client.CurrentScenario;
					bool bool_49 = true;
					b = (byte?)doctrine50.GetParentDoctrine(currentScenario49, ref bool_49).GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_CallbackSpecification = Doctrine._BehaviorTowardsTargetAmbiguity.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.AutoEvade_Inherits() && !selectedUnit.Doctrine.AutoEvade_Inherits())
				{
					b2 = (byte?)recordOrder.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
					}
				}
				else if (recordOrder.AutoEvade_Inherits() && !selectedUnit.Doctrine.AutoEvade_Inherits())
				{
					recordOrder.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
				}
				else if (!recordOrder.AutoEvade_Inherits() && selectedUnit.Doctrine.AutoEvade_Inherits())
				{
					recordOrder.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
				}
			}
			b = (byte?)m_DecoratorSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.AutoEvade_Inherits())
				{
					b2 = (byte?)m_DecoratorSpecification;
					b = (byte?)selectedUnit.Doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_DecoratorSpecification = Doctrine._UseAutoEvade.Various;
					}
				}
				else
				{
					b = (byte?)m_DecoratorSpecification;
					Doctrine doctrine51 = selectedUnit.Doctrine;
					Scenario currentScenario50 = Client.CurrentScenario;
					bool bool_50 = true;
					b2 = (byte?)doctrine51.GetParentDoctrine(currentScenario50, ref bool_50).GetAutoEvade(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_DecoratorSpecification = Doctrine._UseAutoEvade.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.MaintainStandoff_Inherits() && !selectedUnit.Doctrine.MaintainStandoff_Inherits())
				{
					b = (byte?)recordOrder.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
					}
				}
				else if (recordOrder.MaintainStandoff_Inherits() && !selectedUnit.Doctrine.MaintainStandoff_Inherits())
				{
					recordOrder.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
				}
				else if (!recordOrder.MaintainStandoff_Inherits() && selectedUnit.Doctrine.MaintainStandoff_Inherits())
				{
					recordOrder.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
				}
			}
			b2 = (byte?)m_ProcessSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.MaintainStandoff_Inherits())
				{
					b = (byte?)m_ProcessSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ProcessSpecification = Doctrine._UseMaintainStandoff.Various;
					}
				}
				else
				{
					b2 = (byte?)m_ProcessSpecification;
					Doctrine doctrine52 = selectedUnit.Doctrine;
					Scenario currentScenario51 = Client.CurrentScenario;
					bool bool_51 = true;
					b = (byte?)doctrine52.GetParentDoctrine(currentScenario51, ref bool_51).GetMaintainStandoff(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ProcessSpecification = Doctrine._UseMaintainStandoff.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.UseReplenishment_Inherits() && !selectedUnit.Doctrine.UseReplenishment_Inherits())
				{
					b2 = (byte?)recordOrder.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b = (byte?)selectedUnit.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
					}
				}
				else if (recordOrder.UseReplenishment_Inherits() && !selectedUnit.Doctrine.UseReplenishment_Inherits())
				{
					recordOrder.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
				}
				else if (!recordOrder.UseReplenishment_Inherits() && selectedUnit.Doctrine.UseReplenishment_Inherits())
				{
					recordOrder.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
				}
			}
			b = (byte?)threadSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.UseReplenishment_Inherits())
				{
					b2 = (byte?)threadSpecification;
					b = (byte?)selectedUnit.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						threadSpecification = Doctrine._UseUnderwayRefuelAndReplenishment.Various;
					}
				}
				else
				{
					b = (byte?)threadSpecification;
					Doctrine doctrine53 = selectedUnit.Doctrine;
					Scenario currentScenario52 = Client.CurrentScenario;
					bool bool_52 = true;
					b2 = (byte?)doctrine53.GetParentDoctrine(currentScenario52, ref bool_52).GetUseReplenishment(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						threadSpecification = Doctrine._UseUnderwayRefuelAndReplenishment.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.ReplenishmentSelection_Inherits() && !selectedUnit.Doctrine.ReplenishmentSelection_Inherits())
				{
					b = (byte?)recordOrder.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b2 = (byte?)selectedUnit.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
					}
				}
				else if (recordOrder.ReplenishmentSelection_Inherits() && !selectedUnit.Doctrine.ReplenishmentSelection_Inherits())
				{
					recordOrder.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
				}
				else if (!recordOrder.ReplenishmentSelection_Inherits() && selectedUnit.Doctrine.ReplenishmentSelection_Inherits())
				{
					recordOrder.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
				}
			}
			b2 = (byte?)_RuleSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.ReplenishmentSelection_Inherits())
				{
					b = (byte?)_RuleSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_RuleSpecification = Doctrine._UnderwayRefuelAndReplenishmentSelection.Various;
					}
				}
				else
				{
					b2 = (byte?)_RuleSpecification;
					Doctrine doctrine54 = selectedUnit.Doctrine;
					Scenario currentScenario53 = Client.CurrentScenario;
					bool bool_53 = true;
					b = (byte?)doctrine54.GetParentDoctrine(currentScenario53, ref bool_53).GetReplenishmentSelection(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_RuleSpecification = Doctrine._UnderwayRefuelAndReplenishmentSelection.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.ShootTourists_Inherits() && !selectedUnit.Doctrine.ShootTourists_Inherits())
				{
					b2 = (byte?)recordOrder.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
					}
				}
				else if (recordOrder.ShootTourists_Inherits() && !selectedUnit.Doctrine.ShootTourists_Inherits())
				{
					recordOrder.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
				}
				else if (!recordOrder.ShootTourists_Inherits() && selectedUnit.Doctrine.ShootTourists_Inherits())
				{
					recordOrder.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
				}
			}
			b = (byte?)m_CollectionSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.ShootTourists_Inherits())
				{
					b2 = (byte?)m_CollectionSpecification;
					b = (byte?)selectedUnit.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_CollectionSpecification = Doctrine._UseShootTourists.Various;
					}
				}
				else
				{
					b = (byte?)m_CollectionSpecification;
					Doctrine doctrine55 = selectedUnit.Doctrine;
					Scenario currentScenario54 = Client.CurrentScenario;
					bool bool_54 = true;
					b2 = (byte?)doctrine55.GetParentDoctrine(currentScenario54, ref bool_54).GetShootTourists(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_CollectionSpecification = Doctrine._UseShootTourists.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.UseSAMsOnASuW_Inherits() && !selectedUnit.Doctrine.UseSAMsOnASuW_Inherits())
				{
					b = (byte?)recordOrder.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
					}
				}
				else if (recordOrder.UseSAMsOnASuW_Inherits() && !selectedUnit.Doctrine.UseSAMsOnASuW_Inherits())
				{
					recordOrder.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
				}
				else if (!recordOrder.UseSAMsOnASuW_Inherits() && selectedUnit.Doctrine.UseSAMsOnASuW_Inherits())
				{
					recordOrder.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
				}
			}
			b2 = (byte?)_InstanceSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.UseSAMsOnASuW_Inherits())
				{
					b = (byte?)_InstanceSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_InstanceSpecification = Doctrine._UseSAMsAgainstShips.Various;
					}
				}
				else
				{
					b2 = (byte?)_InstanceSpecification;
					Doctrine doctrine57 = selectedUnit.Doctrine;
					Scenario currentScenario55 = Client.CurrentScenario;
					bool bool_55 = true;
					b = (byte?)doctrine57.GetParentDoctrine(currentScenario55, ref bool_55).GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_InstanceSpecification = Doctrine._UseSAMsAgainstShips.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.IgnoreEMCONunderAttack_Inherits() && !selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					b2 = (byte?)recordOrder.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
					}
				}
				else if (recordOrder.IgnoreEMCONunderAttack_Inherits() && !selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					recordOrder.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
				}
				else if (!recordOrder.IgnoreEMCONunderAttack_Inherits() && selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					recordOrder.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
				}
			}
			b = (byte?)_ParameterSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					b2 = (byte?)_ParameterSpecification;
					b = (byte?)selectedUnit.Doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ParameterSpecification = Doctrine._UseIgnoreEMCONunderAttack.Various;
					}
				}
				else
				{
					b = (byte?)_ParameterSpecification;
					Doctrine doctrine58 = selectedUnit.Doctrine;
					Scenario currentScenario57 = Client.CurrentScenario;
					bool bool_57 = true;
					b2 = (byte?)doctrine58.GetParentDoctrine(currentScenario57, ref bool_57).GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ParameterSpecification = Doctrine._UseIgnoreEMCONunderAttack.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.QuickTurnAroundForAicraft_Inherits() && !selectedUnit.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					b = (byte?)recordOrder.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					b2 = (byte?)selectedUnit.Doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
					}
				}
				else if (recordOrder.QuickTurnAroundForAicraft_Inherits() && !selectedUnit.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					recordOrder.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
				}
				else if (!recordOrder.QuickTurnAroundForAicraft_Inherits() && selectedUnit.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					recordOrder.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
				}
			}
			b2 = (byte?)expressionSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					b = (byte?)expressionSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						expressionSpecification = Doctrine._QuickTurnAroundForAicraft.Various;
					}
				}
				else
				{
					b2 = (byte?)expressionSpecification;
					Doctrine doctrine59 = selectedUnit.Doctrine;
					Scenario currentScenario58 = Client.CurrentScenario;
					bool bool_58 = true;
					b = (byte?)doctrine59.GetParentDoctrine(currentScenario58, ref bool_58).GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						expressionSpecification = Doctrine._QuickTurnAroundForAicraft.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.AirOpsTempo_Inherits() && !selectedUnit.Doctrine.AirOpsTempo_Inherits())
				{
					b2 = (byte?)recordOrder.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					b = (byte?)selectedUnit.Doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
					}
				}
				else if (recordOrder.AirOpsTempo_Inherits() && !selectedUnit.Doctrine.AirOpsTempo_Inherits())
				{
					recordOrder.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
				}
				else if (!recordOrder.AirOpsTempo_Inherits() && selectedUnit.Doctrine.AirOpsTempo_Inherits())
				{
					recordOrder.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
				}
			}
			b = (byte?)_DispatcherSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.AirOpsTempo_Inherits())
				{
					b2 = (byte?)_DispatcherSpecification;
					b = (byte?)selectedUnit.Doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_DispatcherSpecification = Doctrine._AirOpsTempo.Various;
					}
				}
				else
				{
					b = (byte?)_DispatcherSpecification;
					Doctrine doctrine60 = selectedUnit.Doctrine;
					Scenario currentScenario59 = Client.CurrentScenario;
					bool bool_59 = true;
					b2 = (byte?)doctrine60.GetParentDoctrine(currentScenario59, ref bool_59).GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_DispatcherSpecification = Doctrine._AirOpsTempo.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.UseKinematicRangeForTorpedoes_Inherits() && !selectedUnit.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					b = (byte?)recordOrder.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
					}
				}
				else if (recordOrder.UseKinematicRangeForTorpedoes_Inherits() && !selectedUnit.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					recordOrder.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
				}
				else if (!recordOrder.UseKinematicRangeForTorpedoes_Inherits() && selectedUnit.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					recordOrder.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
				}
			}
			b2 = (byte?)_RegistrySpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					b = (byte?)_RegistrySpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_RegistrySpecification = Doctrine._UseKinematicRangeForTorpedoes.Various;
					}
				}
				else
				{
					b2 = (byte?)_RegistrySpecification;
					Doctrine doctrine61 = selectedUnit.Doctrine;
					Scenario currentScenario60 = Client.CurrentScenario;
					bool bool_60 = true;
					b = (byte?)doctrine61.GetParentDoctrine(currentScenario60, ref bool_60).GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_RegistrySpecification = Doctrine._UseKinematicRangeForTorpedoes.Various;
					}
				}
			}
			short? num4 = (short?)recordOrder.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			short? num5;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WithdrawDamageThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					num4 = (short?)recordOrder.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)selectedUnit.Doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
					}
				}
				else if (recordOrder.WithdrawDamageThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					recordOrder.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
				else if (!recordOrder.WithdrawDamageThreshold_Inherits() && selectedUnit.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					recordOrder.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
			}
			num5 = (short?)m_InvocationSpecification;
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					num4 = (short?)m_InvocationSpecification;
					num5 = (short?)selectedUnit.Doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_InvocationSpecification = Doctrine._DamageThreshold.Various;
					}
				}
				else
				{
					num5 = (short?)m_InvocationSpecification;
					Doctrine doctrine62 = selectedUnit.Doctrine;
					Scenario currentScenario61 = Client.CurrentScenario;
					bool bool_61 = true;
					num4 = (short?)doctrine62.GetParentDoctrine(currentScenario61, ref bool_61).GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_InvocationSpecification = Doctrine._DamageThreshold.Various;
					}
				}
			}
			num5 = (short?)recordOrder.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WithdrawFuelThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					num5 = (short?)recordOrder.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)selectedUnit.Doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
					}
				}
				else if (recordOrder.WithdrawFuelThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					recordOrder.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
				else if (!recordOrder.WithdrawFuelThreshold_Inherits() && selectedUnit.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					recordOrder.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
			}
			num4 = (short?)_ClassSpecification;
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					num5 = (short?)_ClassSpecification;
					num4 = (short?)selectedUnit.Doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ClassSpecification = Doctrine._FuelQuantityThreshold.Various;
					}
				}
				else
				{
					num4 = (short?)_ClassSpecification;
					Doctrine doctrine63 = selectedUnit.Doctrine;
					Scenario currentScenario62 = Client.CurrentScenario;
					bool bool_62 = true;
					num5 = (short?)doctrine63.GetParentDoctrine(currentScenario62, ref bool_62).GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ClassSpecification = Doctrine._FuelQuantityThreshold.Various;
					}
				}
			}
			num4 = (short?)recordOrder.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WithdrawAttackThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					num4 = (short?)recordOrder.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)selectedUnit.Doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (recordOrder.WithdrawAttackThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					recordOrder.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!recordOrder.WithdrawAttackThreshold_Inherits() && selectedUnit.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					recordOrder.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num5 = (short?)m_RequestSpecification;
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					num4 = (short?)m_RequestSpecification;
					num5 = (short?)selectedUnit.Doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_RequestSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
				else
				{
					num5 = (short?)m_RequestSpecification;
					Doctrine doctrine64 = selectedUnit.Doctrine;
					Scenario currentScenario63 = Client.CurrentScenario;
					bool bool_63 = true;
					num4 = (short?)doctrine64.GetParentDoctrine(currentScenario63, ref bool_63).GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_RequestSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
			}
			num5 = (short?)recordOrder.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.WithdrawDefenceThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					num5 = (short?)recordOrder.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)selectedUnit.Doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (recordOrder.WithdrawDefenceThreshold_Inherits() && !selectedUnit.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					recordOrder.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!recordOrder.WithdrawDefenceThreshold_Inherits() && selectedUnit.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					recordOrder.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num4 = (short?)m_ValueSpecification;
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					num5 = (short?)m_ValueSpecification;
					num4 = (short?)selectedUnit.Doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ValueSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
				else
				{
					num4 = (short?)m_ValueSpecification;
					Doctrine doctrine65 = selectedUnit.Doctrine;
					Scenario currentScenario64 = Client.CurrentScenario;
					bool bool_64 = true;
					num5 = (short?)doctrine65.GetParentDoctrine(currentScenario64, ref bool_64).GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ValueSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
			}
			num4 = (short?)recordOrder.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RedeployDamageThreshold_Inherits() && !selectedUnit.Doctrine.RedeployDamageThreshold_Inherits())
				{
					num4 = (short?)recordOrder.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)selectedUnit.Doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
					}
				}
				else if (recordOrder.RedeployDamageThreshold_Inherits() && !selectedUnit.Doctrine.RedeployDamageThreshold_Inherits())
				{
					recordOrder.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
				else if (!recordOrder.RedeployDamageThreshold_Inherits() && selectedUnit.Doctrine.RedeployDamageThreshold_Inherits())
				{
					recordOrder.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
			}
			num5 = (short?)_TokenizerSpecification;
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RedeployDamageThreshold_Inherits())
				{
					num4 = (short?)_TokenizerSpecification;
					num5 = (short?)selectedUnit.Doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_TokenizerSpecification = Doctrine._DamageThreshold.Various;
					}
				}
				else
				{
					num5 = (short?)_TokenizerSpecification;
					Doctrine doctrine66 = selectedUnit.Doctrine;
					Scenario currentScenario65 = Client.CurrentScenario;
					bool bool_65 = true;
					num4 = (short?)doctrine66.GetParentDoctrine(currentScenario65, ref bool_65).GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_TokenizerSpecification = Doctrine._DamageThreshold.Various;
					}
				}
			}
			num5 = (short?)recordOrder.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RedeployFuelThreshold_Inherits() && !selectedUnit.Doctrine.RedeployFuelThreshold_Inherits())
				{
					num5 = (short?)recordOrder.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)selectedUnit.Doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
					}
				}
				else if (recordOrder.RedeployFuelThreshold_Inherits() && !selectedUnit.Doctrine.RedeployFuelThreshold_Inherits())
				{
					recordOrder.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
				else if (!recordOrder.RedeployFuelThreshold_Inherits() && selectedUnit.Doctrine.RedeployFuelThreshold_Inherits())
				{
					recordOrder.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
			}
			num4 = (short?)_StubSpecification;
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RedeployFuelThreshold_Inherits())
				{
					num5 = (short?)_StubSpecification;
					num4 = (short?)selectedUnit.Doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_StubSpecification = Doctrine._FuelQuantityThreshold.Various;
					}
				}
				else
				{
					num4 = (short?)_StubSpecification;
					Doctrine doctrine68 = selectedUnit.Doctrine;
					Scenario currentScenario66 = Client.CurrentScenario;
					bool bool_66 = true;
					num5 = (short?)doctrine68.GetParentDoctrine(currentScenario66, ref bool_66).GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_StubSpecification = Doctrine._FuelQuantityThreshold.Various;
					}
				}
			}
			num4 = (short?)recordOrder.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RedeployAttackThreshold_Inherits() && !selectedUnit.Doctrine.RedeployAttackThreshold_Inherits())
				{
					num4 = (short?)recordOrder.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)selectedUnit.Doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (recordOrder.RedeployAttackThreshold_Inherits() && !selectedUnit.Doctrine.RedeployAttackThreshold_Inherits())
				{
					recordOrder.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!recordOrder.RedeployAttackThreshold_Inherits() && selectedUnit.Doctrine.RedeployAttackThreshold_Inherits())
				{
					recordOrder.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num5 = (short?)writerSpecification;
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RedeployAttackThreshold_Inherits())
				{
					num4 = (short?)writerSpecification;
					num5 = (short?)selectedUnit.Doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						writerSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
				else
				{
					num5 = (short?)writerSpecification;
					Doctrine doctrine69 = selectedUnit.Doctrine;
					Scenario currentScenario68 = Client.CurrentScenario;
					bool bool_68 = true;
					num4 = (short?)doctrine69.GetParentDoctrine(currentScenario68, ref bool_68).GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						writerSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
			}
			num5 = (short?)recordOrder.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RedeployDefenceThreshold_Inherits() && !selectedUnit.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					num5 = (short?)recordOrder.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)selectedUnit.Doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (recordOrder.RedeployDefenceThreshold_Inherits() && !selectedUnit.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					recordOrder.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!recordOrder.RedeployDefenceThreshold_Inherits() && selectedUnit.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					recordOrder.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num4 = (short?)m_SpecificationSpecification;
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					num5 = (short?)m_SpecificationSpecification;
					num4 = (short?)selectedUnit.Doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_SpecificationSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
				else
				{
					num4 = (short?)m_SpecificationSpecification;
					Doctrine doctrine70 = selectedUnit.Doctrine;
					Scenario currentScenario69 = Client.CurrentScenario;
					bool bool_69 = true;
					num5 = (short?)doctrine70.GetParentDoctrine(currentScenario69, ref bool_69).GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_SpecificationSpecification = Doctrine._WeaponQuantityThreshold.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RefuelAllies_Inherits() && !selectedUnit.Doctrine.RefuelAllies_Inherits())
				{
					b2 = (byte?)recordOrder.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
					}
				}
				else if (recordOrder.RefuelAllies_Inherits() && !selectedUnit.Doctrine.RefuelAllies_Inherits())
				{
					recordOrder.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
				}
				else if (!recordOrder.RefuelAllies_Inherits() && selectedUnit.Doctrine.RefuelAllies_Inherits())
				{
					recordOrder.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
				}
			}
			b = (byte?)issuerSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RefuelAllies_Inherits())
				{
					b2 = (byte?)issuerSpecification;
					b = (byte?)selectedUnit.Doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						issuerSpecification = Doctrine._RefuelAlliedUnits.Various;
					}
				}
				else
				{
					b = (byte?)issuerSpecification;
					Doctrine doctrine71 = selectedUnit.Doctrine;
					Scenario currentScenario70 = Client.CurrentScenario;
					bool bool_70 = true;
					b2 = (byte?)doctrine71.GetParentDoctrine(currentScenario70, ref bool_70).GetRefuelAllies(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						issuerSpecification = Doctrine._RefuelAlliedUnits.Various;
					}
				}
			}
			b = (byte?)clientSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.BingoThreshold_Inherits)
				{
					b2 = (byte?)clientSpecification;
					b = (byte?)selectedUnit.Doctrine.GetBingoThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						clientSpecification = Doctrine._BingoThreshold_E.Various;
					}
				}
				else
				{
					b = (byte?)clientSpecification;
					Doctrine doctrine72 = selectedUnit.Doctrine;
					Scenario currentScenario71 = Client.CurrentScenario;
					bool bool_71 = true;
					b2 = (byte?)doctrine72.GetParentDoctrine(currentScenario71, ref bool_71).GetBingoThreshold(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						clientSpecification = Doctrine._BingoThreshold_E.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.AvoidContact_Inherits() && !selectedUnit.Doctrine.AvoidContact_Inherits())
				{
					b = (byte?)recordOrder.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
					}
				}
				else if (recordOrder.AvoidContact_Inherits() && !selectedUnit.Doctrine.AvoidContact_Inherits())
				{
					recordOrder.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
				}
				else if (!recordOrder.AvoidContact_Inherits() && selectedUnit.Doctrine.AvoidContact_Inherits())
				{
					recordOrder.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
				}
			}
			b2 = (byte?)m_DicSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.AvoidContact_Inherits())
				{
					b = (byte?)m_DicSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_DicSpecification = Doctrine._AvoidContactWhenPossible.Various;
					}
				}
				else
				{
					b2 = (byte?)m_DicSpecification;
					Doctrine doctrine73 = selectedUnit.Doctrine;
					Scenario currentScenario72 = Client.CurrentScenario;
					bool bool_72 = true;
					b = (byte?)doctrine73.GetParentDoctrine(currentScenario72, ref bool_72).GetAvoidContact(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_DicSpecification = Doctrine._AvoidContactWhenPossible.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.DiveWhenThreatsDetected_Inherits() && !selectedUnit.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					b2 = (byte?)recordOrder.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
					}
				}
				else if (recordOrder.DiveWhenThreatsDetected_Inherits() && !selectedUnit.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					recordOrder.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
				}
				else if (!recordOrder.DiveWhenThreatsDetected_Inherits() && selectedUnit.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					recordOrder.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
				}
			}
			b = (byte?)m_ConsumerSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					b2 = (byte?)m_ConsumerSpecification;
					b = (byte?)selectedUnit.Doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ConsumerSpecification = Doctrine._DiveOnContact.Various;
					}
				}
				else
				{
					b = (byte?)m_ConsumerSpecification;
					Doctrine doctrine74 = selectedUnit.Doctrine;
					Scenario currentScenario73 = Client.CurrentScenario;
					bool bool_73 = true;
					b2 = (byte?)doctrine74.GetParentDoctrine(currentScenario73, ref bool_73).GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ConsumerSpecification = Doctrine._DiveOnContact.Various;
					}
				}
			}
			num3 = (int?)recordOrder.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RechargePercentagePatrol_Inherits() && !selectedUnit.Doctrine.RechargePercentagePatrol_Inherits())
				{
					num3 = (int?)recordOrder.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num2 = (int?)selectedUnit.Doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() != num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
					}
				}
				else if (recordOrder.RechargePercentagePatrol_Inherits() && !selectedUnit.Doctrine.RechargePercentagePatrol_Inherits())
				{
					recordOrder.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
				else if (!recordOrder.RechargePercentagePatrol_Inherits() && selectedUnit.Doctrine.RechargePercentagePatrol_Inherits())
				{
					recordOrder.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
			}
			num2 = (int?)facadeSpecification;
			flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RechargePercentagePatrol_Inherits())
				{
					num3 = (int?)facadeSpecification;
					num2 = (int?)selectedUnit.Doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() != num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						facadeSpecification = Doctrine._RechargeBatteryPercentage.Various;
					}
				}
				else
				{
					num2 = (int?)facadeSpecification;
					Doctrine doctrine75 = selectedUnit.Doctrine;
					Scenario currentScenario74 = Client.CurrentScenario;
					bool bool_74 = true;
					num3 = (int?)doctrine75.GetParentDoctrine(currentScenario74, ref bool_74).GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						facadeSpecification = Doctrine._RechargeBatteryPercentage.Various;
					}
				}
			}
			num2 = (int?)recordOrder.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.RechargePercentageAttack_Inherits() && !selectedUnit.Doctrine.RechargePercentageAttack_Inherits())
				{
					num2 = (int?)recordOrder.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num3 = (int?)selectedUnit.Doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
					}
				}
				else if (recordOrder.RechargePercentageAttack_Inherits() && !selectedUnit.Doctrine.RechargePercentageAttack_Inherits())
				{
					recordOrder.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
				else if (!recordOrder.RechargePercentageAttack_Inherits() && selectedUnit.Doctrine.RechargePercentageAttack_Inherits())
				{
					recordOrder.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
			}
			num3 = (int?)_ProxySpecification;
			flag = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.RechargePercentageAttack_Inherits())
				{
					num2 = (int?)_ProxySpecification;
					num3 = (int?)selectedUnit.Doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ProxySpecification = Doctrine._RechargeBatteryPercentage.Various;
					}
				}
				else
				{
					num3 = (int?)_ProxySpecification;
					Doctrine doctrine76 = selectedUnit.Doctrine;
					Scenario currentScenario75 = Client.CurrentScenario;
					bool bool_75 = true;
					num2 = (int?)doctrine76.GetParentDoctrine(currentScenario75, ref bool_75).GetRechargePercentageAttack(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() != num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ProxySpecification = Doctrine._RechargeBatteryPercentage.Various;
					}
				}
			}
			b = (byte?)recordOrder.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.AIPUsage_Inherits() && !selectedUnit.Doctrine.AIPUsage_Inherits())
				{
					b = (byte?)recordOrder.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
					}
				}
				else if (recordOrder.AIPUsage_Inherits() && !selectedUnit.Doctrine.AIPUsage_Inherits())
				{
					recordOrder.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
				}
				else if (!recordOrder.AIPUsage_Inherits() && selectedUnit.Doctrine.AIPUsage_Inherits())
				{
					recordOrder.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
				}
			}
			b2 = (byte?)m_ReaderSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.AIPUsage_Inherits())
				{
					b = (byte?)m_ReaderSpecification;
					b2 = (byte?)selectedUnit.Doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ReaderSpecification = Doctrine._UseAIP.Various;
					}
				}
				else
				{
					b2 = (byte?)m_ReaderSpecification;
					Doctrine doctrine77 = selectedUnit.Doctrine;
					Scenario currentScenario76 = Client.CurrentScenario;
					bool bool_76 = true;
					b = (byte?)doctrine77.GetParentDoctrine(currentScenario76, ref bool_76).method_2(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_ReaderSpecification = Doctrine._UseAIP.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.DippingSonar_Inherits() && !selectedUnit.Doctrine.DippingSonar_Inherits())
				{
					b2 = (byte?)recordOrder.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
					}
				}
				else if (recordOrder.DippingSonar_Inherits() && !selectedUnit.Doctrine.DippingSonar_Inherits())
				{
					recordOrder.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
				}
				else if (!recordOrder.DippingSonar_Inherits() && selectedUnit.Doctrine.DippingSonar_Inherits())
				{
					recordOrder.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
				}
			}
			b = (byte?)propertySpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.DippingSonar_Inherits())
				{
					b2 = (byte?)propertySpecification;
					b = (byte?)selectedUnit.Doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						propertySpecification = Doctrine._UseDippingSonar.Various;
					}
				}
				else
				{
					b = (byte?)propertySpecification;
					Doctrine doctrine79 = selectedUnit.Doctrine;
					Scenario currentScenario77 = Client.CurrentScenario;
					bool bool_77 = true;
					b2 = (byte?)doctrine79.GetParentDoctrine(currentScenario77, ref bool_77).GetDippingSonar(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						propertySpecification = Doctrine._UseDippingSonar.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.JettisonOrdnance_Inherits() && !selectedUnit.Doctrine.JettisonOrdnance_Inherits())
				{
					b = (byte?)recordOrder.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
					}
				}
				else if (recordOrder.JettisonOrdnance_Inherits() && !selectedUnit.Doctrine.JettisonOrdnance_Inherits())
				{
					recordOrder.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
				}
				else if (!recordOrder.JettisonOrdnance_Inherits() && selectedUnit.Doctrine.JettisonOrdnance_Inherits())
				{
					recordOrder.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
				}
			}
			b2 = (byte?)m_StructSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.JettisonOrdnance_Inherits())
				{
					b = (byte?)m_StructSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_StructSpecification = Doctrine._JettisonOrdnance.Various;
					}
				}
				else
				{
					b2 = (byte?)m_StructSpecification;
					Doctrine doctrine80 = selectedUnit.Doctrine;
					Scenario currentScenario79 = Client.CurrentScenario;
					bool bool_79 = true;
					b = (byte?)doctrine80.GetParentDoctrine(currentScenario79, ref bool_79).GetJettison(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						m_StructSpecification = Doctrine._JettisonOrdnance.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.BVRLogic_Inherits() && !selectedUnit.Doctrine.BVRLogic_Inherits())
				{
					b2 = (byte?)recordOrder.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
					}
				}
				else if (recordOrder.BVRLogic_Inherits() && !selectedUnit.Doctrine.BVRLogic_Inherits())
				{
					recordOrder.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
				}
				else if (!recordOrder.BVRLogic_Inherits() && selectedUnit.Doctrine.BVRLogic_Inherits())
				{
					recordOrder.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
				}
			}
			b = (byte?)_MerchantSpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.BVRLogic_Inherits())
				{
					b2 = (byte?)_MerchantSpecification;
					b = (byte?)selectedUnit.Doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_MerchantSpecification = Doctrine._BVRLogicEnum.Various;
					}
				}
				else
				{
					b = (byte?)_MerchantSpecification;
					Doctrine doctrine81 = selectedUnit.Doctrine;
					Scenario currentScenario80 = Client.CurrentScenario;
					bool bool_80 = true;
					b2 = (byte?)doctrine81.GetParentDoctrine(currentScenario80, ref bool_80).method_0(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_MerchantSpecification = Doctrine._BVRLogicEnum.Various;
					}
				}
			}
			if (recordOrder.EMCON_Inherits != selectedUnit.Doctrine.EMCON_Inherits && !recordOrder.EMCON_Inherits)
			{
				recordOrder.EMCON_Inherits = true;
			}
			if (Information.IsNothing(definitionSpecification))
			{
				if (recordOrder.NewRepository(Client.CurrentScenario).LoginInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.Various && recordOrder.NewRepository(Client.CurrentScenario).LoginInterruptibleField() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField())
				{
					recordOrder.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
				}
			}
			else if (selectedUnit.Doctrine.EMCON_Inherits)
			{
				if (definitionSpecification != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField())
				{
					definitionSpecification = Doctrine.EMCONSettings._EMCONSetting.Various;
				}
			}
			else if (recordOrder.NewRepository(Client.CurrentScenario).LoginInterruptibleField() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField())
			{
				recordOrder.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
			}
			if (Information.IsNothing(_ValSpecification))
			{
				if (recordOrder.NewRepository(Client.CurrentScenario).GetInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.Various && recordOrder.NewRepository(Client.CurrentScenario).GetInterruptibleField() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField())
				{
					recordOrder.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
				}
			}
			else if (selectedUnit.Doctrine.EMCON_Inherits)
			{
				if (_ValSpecification != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField())
				{
					_ValSpecification = Doctrine.EMCONSettings._EMCONSetting.Various;
				}
			}
			else if (recordOrder.NewRepository(Client.CurrentScenario).GetInterruptibleField() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField())
			{
				recordOrder.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
			}
			if (Information.IsNothing(wrapperSpecification))
			{
				if (recordOrder.NewRepository(Client.CurrentScenario).OECM() != Doctrine.EMCONSettings._EMCONSetting.Various && recordOrder.NewRepository(Client.CurrentScenario).OECM() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM())
				{
					recordOrder.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
				}
			}
			else if (selectedUnit.Doctrine.EMCON_Inherits)
			{
				if (wrapperSpecification != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM())
				{
					wrapperSpecification = Doctrine.EMCONSettings._EMCONSetting.Various;
				}
			}
			else if (recordOrder.NewRepository(Client.CurrentScenario).OECM() != selectedUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM())
			{
				recordOrder.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Various, Client.CurrentScenario);
			}
			b = (byte?)recordOrder.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.SurfaceNavigation_Inherits() && !selectedUnit.Doctrine.SurfaceNavigation_Inherits())
				{
					b = (byte?)recordOrder.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
					}
				}
				else if (recordOrder.SurfaceNavigation_Inherits() && !selectedUnit.Doctrine.SurfaceNavigation_Inherits())
				{
					recordOrder.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
				else if (!recordOrder.SurfaceNavigation_Inherits() && selectedUnit.Doctrine.SurfaceNavigation_Inherits())
				{
					recordOrder.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			b2 = (byte?)_ImporterSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.SurfaceNavigation_Inherits())
				{
					b = (byte?)_ImporterSpecification;
					b2 = (byte?)selectedUnit.Doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ImporterSpecification = Doctrine._NavigationMethod.Various;
					}
				}
				else
				{
					b2 = (byte?)_ImporterSpecification;
					Doctrine doctrine82 = selectedUnit.Doctrine;
					Scenario currentScenario81 = Client.CurrentScenario;
					bool bool_81 = true;
					b = (byte?)doctrine82.GetParentDoctrine(currentScenario81, ref bool_81).GetSurfaceNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						_ImporterSpecification = Doctrine._NavigationMethod.Various;
					}
				}
			}
			b2 = (byte?)recordOrder.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.SubmarineNavigation_Inherits() && !selectedUnit.Doctrine.SubmarineNavigation_Inherits())
				{
					b2 = (byte?)recordOrder.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)selectedUnit.Doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
					}
				}
				else if (recordOrder.SubmarineNavigation_Inherits() && !selectedUnit.Doctrine.SubmarineNavigation_Inherits())
				{
					recordOrder.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
				else if (!recordOrder.SubmarineNavigation_Inherits() && selectedUnit.Doctrine.SubmarineNavigation_Inherits())
				{
					recordOrder.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			b = (byte?)repositorySpecification;
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (selectedUnit.Doctrine.SubmarineNavigation_Inherits())
				{
					b2 = (byte?)repositorySpecification;
					b = (byte?)selectedUnit.Doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						repositorySpecification = Doctrine._NavigationMethod.Various;
					}
				}
				else
				{
					b = (byte?)repositorySpecification;
					Doctrine doctrine83 = selectedUnit.Doctrine;
					Scenario currentScenario82 = Client.CurrentScenario;
					bool bool_82 = true;
					b2 = (byte?)doctrine83.GetParentDoctrine(currentScenario82, ref bool_82).GetSubmarineNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						repositorySpecification = Doctrine._NavigationMethod.Various;
					}
				}
			}
			b = (byte?)recordOrder.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!recordOrder.LandNavigation_Inherits() && !selectedUnit.Doctrine.LandNavigation_Inherits())
				{
					b = (byte?)recordOrder.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)selectedUnit.Doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						recordOrder.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
					}
				}
				else if (recordOrder.LandNavigation_Inherits() && !selectedUnit.Doctrine.LandNavigation_Inherits())
				{
					recordOrder.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
				else if (!recordOrder.LandNavigation_Inherits() && selectedUnit.Doctrine.LandNavigation_Inherits())
				{
					recordOrder.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			b2 = (byte?)m_BridgeSpecification;
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 6) : null);
			if (!((!flag) ?? flag).GetValueOrDefault())
			{
				continue;
			}
			if (selectedUnit.Doctrine.LandNavigation_Inherits())
			{
				b = (byte?)m_BridgeSpecification;
				b2 = (byte?)selectedUnit.Doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					m_BridgeSpecification = Doctrine._NavigationMethod.Various;
				}
				continue;
			}
			b2 = (byte?)m_BridgeSpecification;
			Doctrine doctrine84 = selectedUnit.Doctrine;
			Scenario currentScenario83 = Client.CurrentScenario;
			bool bool_83 = true;
			b = (byte?)doctrine84.GetParentDoctrine(currentScenario83, ref bool_83).GetLandNavigation(Client.CurrentScenario, bool_0: true, bool_1: false, bool_2: false);
			if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				m_BridgeSpecification = Doctrine._NavigationMethod.Various;
			}
		}
		return recordOrder;
	}

	private void LoginException()
	{
		int num = 0;
		foreach (ActiveUnit selectedUnit in SelectedUnits)
		{
			num++;
			if (num == 1)
			{
				if (Information.IsNothing(selectedUnit.Doctrine.WRA))
				{
					continue;
				}
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item3 in selectedUnit.Doctrine.WRA)
				{
					int key = item3.Key;
					Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
					selectedUnit.Doctrine.WRA.TryGetValue(key, out value);
					foreach (Doctrine.WRA_FiringDoctrineEntry item2 in value.WRA_WeaponTargets.ToList())
					{
						recordOrder.ScenarioContext = Client.CurrentScenario;
						if (recordOrder.WRA == null)
						{
							recordOrder.WRA = new Dictionary<int, Doctrine.WRA_Weapon>();
						}
						if (!recordOrder.WRA.ContainsKey(key))
						{
							Doctrine.WRA_Weapon value2 = new Doctrine.WRA_Weapon();
							recordOrder.WRA.Add(key, value2);
						}
						if (recordOrder.WRA.ContainsKey(key))
						{
							Doctrine.WRA_Weapon value3 = new Doctrine.WRA_Weapon();
							recordOrder.WRA.TryGetValue(key, out value3);
							Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new Doctrine.WRA_FiringDoctrineEntry(item2.TargetType);
							wRA_FiringDoctrineEntry.WeaponQty = item2.WeaponQty;
							wRA_FiringDoctrineEntry.ShooterQty = item2.ShooterQty;
							wRA_FiringDoctrineEntry.SelfDefenceRange = item2.SelfDefenceRange;
							wRA_FiringDoctrineEntry.FiringRange = item2.FiringRange;
							ArrayExtensions.Add(ref value3.WRA_WeaponTargets, wRA_FiringDoctrineEntry);
						}
					}
				}
				continue;
			}
			if (!Information.IsNothing(recordOrder.WRA))
			{
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item4 in recordOrder.WRA)
				{
					int key2 = item4.Key;
					Doctrine.WRA_Weapon value4 = new Doctrine.WRA_Weapon();
					recordOrder.WRA.TryGetValue(key2, out value4);
					Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = value4.WRA_WeaponTargets;
					Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
					foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 in array)
					{
						if (Information.IsNothing(selectedUnit.Doctrine.WRA) || !selectedUnit.Doctrine.WRA.ContainsKey(key2))
						{
							continue;
						}
						Doctrine.WRA_Weapon value5 = new Doctrine.WRA_Weapon();
						selectedUnit.Doctrine.WRA.TryGetValue(key2, out value5);
						if (Information.IsNothing(value5))
						{
							continue;
						}
						Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets3 = value5.WRA_WeaponTargets;
						Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets3;
						foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry3 in array2)
						{
							if (wRA_FiringDoctrineEntry2.TargetType == wRA_FiringDoctrineEntry3.TargetType)
							{
								break;
							}
						}
					}
				}
			}
			if (Information.IsNothing(selectedUnit.Doctrine.WRA))
			{
				continue;
			}
			foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item5 in selectedUnit.Doctrine.WRA)
			{
				int key3 = item5.Key;
				Doctrine.WRA_Weapon value6 = new Doctrine.WRA_Weapon();
				selectedUnit.Doctrine.WRA.TryGetValue(key3, out value6);
				recordOrder.ScenarioContext = Client.CurrentScenario;
				Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = value6.WRA_WeaponTargets;
				Doctrine.WRA_FiringDoctrineEntry[] array3 = wRA_WeaponTargets2;
				foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry4 in array3)
				{
					if (Information.IsNothing(recordOrder.WRA))
					{
						recordOrder.WRA = new Dictionary<int, Doctrine.WRA_Weapon>();
					}
					if (!recordOrder.WRA.ContainsKey(key3))
					{
						Doctrine.WRA_Weapon value7 = new Doctrine.WRA_Weapon();
						recordOrder.WRA.Add(key3, value7);
					}
					if (!recordOrder.WRA.ContainsKey(key3))
					{
						continue;
					}
					Doctrine.WRA_Weapon value8 = new Doctrine.WRA_Weapon();
					recordOrder.WRA.TryGetValue(key3, out value8);
					bool flag = false;
					Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets4 = value8.WRA_WeaponTargets;
					Doctrine.WRA_FiringDoctrineEntry[] array4 = wRA_WeaponTargets4;
					foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry5 in array4)
					{
						if (wRA_FiringDoctrineEntry5.TargetType != wRA_FiringDoctrineEntry4.TargetType)
						{
							continue;
						}
						flag = true;
						int? weaponQty = wRA_FiringDoctrineEntry5.WeaponQty;
						bool? flag2 = (weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() == -100) : null);
						int? weaponQty2;
						if (((!flag2) ?? flag2).GetValueOrDefault() || Information.IsNothing(wRA_FiringDoctrineEntry5.WeaponQty))
						{
							if (!Information.IsNothing(wRA_FiringDoctrineEntry5.WeaponQty) && !Information.IsNothing(wRA_FiringDoctrineEntry4.WeaponQty))
							{
								weaponQty = wRA_FiringDoctrineEntry5.WeaponQty;
								weaponQty2 = wRA_FiringDoctrineEntry4.WeaponQty;
								if (((weaponQty.HasValue & weaponQty2.HasValue) ? new bool?(weaponQty.GetValueOrDefault() != weaponQty2.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									wRA_FiringDoctrineEntry5.WeaponQty = -100;
								}
							}
							else if (Information.IsNothing(wRA_FiringDoctrineEntry5.WeaponQty) && !Information.IsNothing(wRA_FiringDoctrineEntry4.WeaponQty))
							{
								wRA_FiringDoctrineEntry5.WeaponQty = -100;
							}
							else if (!Information.IsNothing(wRA_FiringDoctrineEntry5.WeaponQty) && Information.IsNothing(wRA_FiringDoctrineEntry4.WeaponQty))
							{
								wRA_FiringDoctrineEntry5.WeaponQty = -100;
							}
						}
						weaponQty2 = wRA_FiringDoctrineEntry5.ShooterQty;
						flag2 = (weaponQty2.HasValue ? new bool?(weaponQty2.GetValueOrDefault() == -100) : null);
						if (((!flag2) ?? flag2).GetValueOrDefault() || Information.IsNothing(wRA_FiringDoctrineEntry5.ShooterQty))
						{
							if (!Information.IsNothing(wRA_FiringDoctrineEntry5.ShooterQty) && !Information.IsNothing(wRA_FiringDoctrineEntry4.ShooterQty))
							{
								weaponQty2 = wRA_FiringDoctrineEntry5.ShooterQty;
								weaponQty = wRA_FiringDoctrineEntry4.ShooterQty;
								if (((weaponQty2.HasValue & weaponQty.HasValue) ? new bool?(weaponQty2.GetValueOrDefault() != weaponQty.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									wRA_FiringDoctrineEntry5.ShooterQty = -100;
								}
							}
							else if (Information.IsNothing(wRA_FiringDoctrineEntry5.ShooterQty) && !Information.IsNothing(wRA_FiringDoctrineEntry4.ShooterQty))
							{
								wRA_FiringDoctrineEntry5.ShooterQty = -100;
							}
							else if (!Information.IsNothing(wRA_FiringDoctrineEntry5.ShooterQty) && Information.IsNothing(wRA_FiringDoctrineEntry4.ShooterQty))
							{
								wRA_FiringDoctrineEntry5.ShooterQty = -100;
							}
						}
						float? selfDefenceRange = wRA_FiringDoctrineEntry5.SelfDefenceRange;
						flag2 = (selfDefenceRange.HasValue ? new bool?(selfDefenceRange.GetValueOrDefault() == -100f) : null);
						float? selfDefenceRange2;
						if (((!flag2) ?? flag2).GetValueOrDefault() || Information.IsNothing(wRA_FiringDoctrineEntry5.SelfDefenceRange))
						{
							if (!Information.IsNothing(wRA_FiringDoctrineEntry5.SelfDefenceRange) && !Information.IsNothing(wRA_FiringDoctrineEntry4.SelfDefenceRange))
							{
								selfDefenceRange = wRA_FiringDoctrineEntry5.SelfDefenceRange;
								selfDefenceRange2 = wRA_FiringDoctrineEntry4.SelfDefenceRange;
								if (((selfDefenceRange.HasValue & selfDefenceRange2.HasValue) ? new bool?(selfDefenceRange.GetValueOrDefault() != selfDefenceRange2.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									wRA_FiringDoctrineEntry5.SelfDefenceRange = -100f;
								}
							}
							else if (Information.IsNothing(wRA_FiringDoctrineEntry5.SelfDefenceRange) && !Information.IsNothing(wRA_FiringDoctrineEntry4.SelfDefenceRange))
							{
								wRA_FiringDoctrineEntry5.SelfDefenceRange = -100f;
							}
							else if (!Information.IsNothing(wRA_FiringDoctrineEntry5.SelfDefenceRange) && Information.IsNothing(wRA_FiringDoctrineEntry4.SelfDefenceRange))
							{
								wRA_FiringDoctrineEntry5.SelfDefenceRange = -100f;
							}
						}
						selfDefenceRange2 = wRA_FiringDoctrineEntry5.FiringRange;
						flag2 = (selfDefenceRange2.HasValue ? new bool?(selfDefenceRange2.GetValueOrDefault() == -100f) : null);
						if (!((!flag2) ?? flag2).GetValueOrDefault() && !Information.IsNothing(wRA_FiringDoctrineEntry5.FiringRange))
						{
							break;
						}
						if (!Information.IsNothing(wRA_FiringDoctrineEntry5.FiringRange) && !Information.IsNothing(wRA_FiringDoctrineEntry4.FiringRange))
						{
							selfDefenceRange2 = wRA_FiringDoctrineEntry5.FiringRange;
							selfDefenceRange = wRA_FiringDoctrineEntry4.FiringRange;
							if (((selfDefenceRange2.HasValue & selfDefenceRange.HasValue) ? new bool?(selfDefenceRange2.GetValueOrDefault() != selfDefenceRange.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								wRA_FiringDoctrineEntry5.FiringRange = -100f;
							}
						}
						else if (Information.IsNothing(wRA_FiringDoctrineEntry5.FiringRange) && !Information.IsNothing(wRA_FiringDoctrineEntry4.FiringRange))
						{
							wRA_FiringDoctrineEntry5.FiringRange = -100f;
						}
						else if (!Information.IsNothing(wRA_FiringDoctrineEntry5.FiringRange) && Information.IsNothing(wRA_FiringDoctrineEntry4.FiringRange))
						{
							wRA_FiringDoctrineEntry5.FiringRange = -100f;
						}
						break;
					}
					if (!flag)
					{
						Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry6 = new Doctrine.WRA_FiringDoctrineEntry(wRA_FiringDoctrineEntry4.TargetType);
						if (!Information.IsNothing(wRA_FiringDoctrineEntry4.WeaponQty))
						{
							wRA_FiringDoctrineEntry6.WeaponQty = -100;
						}
						if (!Information.IsNothing(wRA_FiringDoctrineEntry4.ShooterQty))
						{
							wRA_FiringDoctrineEntry6.ShooterQty = -100;
						}
						if (!Information.IsNothing(wRA_FiringDoctrineEntry4.SelfDefenceRange))
						{
							wRA_FiringDoctrineEntry6.SelfDefenceRange = -100f;
						}
						if (!Information.IsNothing(wRA_FiringDoctrineEntry4.FiringRange))
						{
							wRA_FiringDoctrineEntry6.FiringRange = -100f;
						}
						ArrayExtensions.Add(ref value8.WRA_WeaponTargets, wRA_FiringDoctrineEntry6);
					}
				}
			}
		}
	}

	private Doctrine GetException(Group group_0)
	{
		int num = 0;
		Doctrine doctrine = null;
		foreach (KeyValuePair<string, ActiveUnit> unit in group_0.Units)
		{
			ActiveUnit value = unit.Value;
			value.Doctrine.ClearCachedParentDoctrine();
			num++;
			if (num == 1)
			{
				Doctrine doctrine2 = value.Doctrine;
				ref Doctrine doctrine3 = ref value.Doctrine;
				Scenario scenario_ = Client.CurrentScenario;
				doctrine = doctrine2.PatchRepository(ref doctrine3, value, ref scenario_);
				continue;
			}
			byte? b = (byte?)doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			byte? b2;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.NukesAllowed_Inherits() && !value.Doctrine.NukesAllowed_Inherits())
				{
					b = (byte?)doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
					}
				}
				else if (doctrine.NukesAllowed_Inherits() && !value.Doctrine.NukesAllowed_Inherits())
				{
					doctrine.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
				}
				else if (!doctrine.NukesAllowed_Inherits() && value.Doctrine.NukesAllowed_Inherits())
				{
					doctrine.SetNukesAllowed(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseNukesAllowed.Various);
				}
			}
			b2 = (byte?)doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WeaponControlStatus_Air_Inherits() && !value.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					b2 = (byte?)doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (doctrine.WeaponControlStatus_Air_Inherits() && !value.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					doctrine.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!doctrine.WeaponControlStatus_Air_Inherits() && value.Doctrine.WeaponControlStatus_Air_Inherits())
				{
					doctrine.SetWeaponControlStatus_Air(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b = (byte?)doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WeaponControlStatus_Surface_Inherits() && !value.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					b = (byte?)doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (doctrine.WeaponControlStatus_Surface_Inherits() && !value.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					doctrine.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!doctrine.WeaponControlStatus_Surface_Inherits() && value.Doctrine.WeaponControlStatus_Surface_Inherits())
				{
					doctrine.SetWeaponControlStatus_Surface(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b2 = (byte?)doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WeaponControlStatus_Submarine_Inherits() && !value.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					b2 = (byte?)doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (doctrine.WeaponControlStatus_Submarine_Inherits() && !value.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					doctrine.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!doctrine.WeaponControlStatus_Submarine_Inherits() && value.Doctrine.WeaponControlStatus_Submarine_Inherits())
				{
					doctrine.SetWeaponControlStatus_Submarine(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b = (byte?)doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WeaponControlStatus_Land_Inherits() && !value.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					b = (byte?)doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
					}
				}
				else if (doctrine.WeaponControlStatus_Land_Inherits() && !value.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					doctrine.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
				else if (!doctrine.WeaponControlStatus_Land_Inherits() && value.Doctrine.WeaponControlStatus_Land_Inherits())
				{
					doctrine.SetWeaponControlStatus_Land(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._WCS.Various);
				}
			}
			b2 = (byte?)doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.GunStrafing_Inherits() && !value.Doctrine.GunStrafing_Inherits())
				{
					b2 = (byte?)doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
					}
				}
				else if (doctrine.GunStrafing_Inherits() && !value.Doctrine.GunStrafing_Inherits())
				{
					doctrine.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
				}
				else if (!doctrine.GunStrafing_Inherits() && value.Doctrine.GunStrafing_Inherits())
				{
					doctrine.SetGunStrafing(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._GunStrafeGroundTargets.Various);
				}
			}
			b = (byte?)doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.IgnorePlottedCourse_Inherits() && !value.Doctrine.IgnorePlottedCourse_Inherits())
				{
					b = (byte?)doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
					}
				}
				else if (doctrine.IgnorePlottedCourse_Inherits() && !value.Doctrine.IgnorePlottedCourse_Inherits())
				{
					doctrine.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
				}
				else if (!doctrine.IgnorePlottedCourse_Inherits() && value.Doctrine.IgnorePlottedCourse_Inherits())
				{
					doctrine.SetIgnorePlottedCourse(Client.CurrentScenario, bool_0: false, false, bool_1: true, bool_2: true, Doctrine._UseIgnorePlottedCourse.Various);
				}
			}
			b2 = (byte?)doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WinchesterShotgunRTB_Inherits() && !value.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					b2 = (byte?)doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
					}
				}
				else if (doctrine.WinchesterShotgunRTB_Inherits() && !value.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					doctrine.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
				}
				else if (!doctrine.WinchesterShotgunRTB_Inherits() && value.Doctrine.WinchesterShotgunRTB_Inherits())
				{
					doctrine.SetWinchesterShotgunRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponStateRTB.Various);
				}
			}
			int? num2 = (int?)doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null);
			int? num3;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WinchesterShotgun_Inherits() && !value.Doctrine.WinchesterShotgun_Inherits())
				{
					num2 = (int?)doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					num3 = (int?)value.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
					}
				}
				else if (doctrine.WinchesterShotgun_Inherits() && !value.Doctrine.WinchesterShotgun_Inherits())
				{
					doctrine.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
				}
				else if (!doctrine.WinchesterShotgun_Inherits() && value.Doctrine.WinchesterShotgun_Inherits())
				{
					doctrine.SetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._WeaponState.Various);
				}
			}
			b = (byte?)doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.BingoJokerRTB_Inherits() && !value.Doctrine.BingoJokerRTB_Inherits())
				{
					b = (byte?)doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
					}
				}
				else if (doctrine.BingoJokerRTB_Inherits() && !value.Doctrine.BingoJokerRTB_Inherits())
				{
					doctrine.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
				}
				else if (!doctrine.BingoJokerRTB_Inherits() && value.Doctrine.BingoJokerRTB_Inherits())
				{
					doctrine.SetBingoJokerRTB(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelStateRTB.Various);
				}
			}
			b2 = (byte?)doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 12) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.BingoJoker_Inherits() && !value.Doctrine.BingoJoker_Inherits())
				{
					b2 = (byte?)doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b = (byte?)value.Doctrine.GetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
					}
				}
				else if (doctrine.BingoJoker_Inherits() && !value.Doctrine.BingoJoker_Inherits())
				{
					doctrine.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
				}
				else if (!doctrine.BingoJoker_Inherits() && value.Doctrine.BingoJoker_Inherits())
				{
					doctrine.SetBingoJoker(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: true, bool_3: true, Doctrine._FuelState.Various);
				}
			}
			b = (byte?)doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.BehaviorTowardsAmbigousTarget_Inherits() && !value.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					b = (byte?)doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
					}
				}
				else if (doctrine.BehaviorTowardsAmbigousTarget_Inherits() && !value.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					doctrine.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
				}
				else if (!doctrine.BehaviorTowardsAmbigousTarget_Inherits() && value.Doctrine.BehaviorTowardsAmbigousTarget_Inherits())
				{
					doctrine.SetBehaviorTowardsAmbigousTarget(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BehaviorTowardsTargetAmbiguity.Various);
				}
			}
			b2 = (byte?)doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.AutoEvade_Inherits() && !value.Doctrine.AutoEvade_Inherits())
				{
					b2 = (byte?)doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
					}
				}
				else if (doctrine.AutoEvade_Inherits() && !value.Doctrine.AutoEvade_Inherits())
				{
					doctrine.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
				}
				else if (!doctrine.AutoEvade_Inherits() && value.Doctrine.AutoEvade_Inherits())
				{
					doctrine.SetAutoEvade(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAutoEvade.Various);
				}
			}
			b = (byte?)doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.MaintainStandoff_Inherits() && !value.Doctrine.MaintainStandoff_Inherits())
				{
					b = (byte?)doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
					}
				}
				else if (doctrine.MaintainStandoff_Inherits() && !value.Doctrine.MaintainStandoff_Inherits())
				{
					doctrine.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
				}
				else if (!doctrine.MaintainStandoff_Inherits() && value.Doctrine.MaintainStandoff_Inherits())
				{
					doctrine.SetMaintainStandoff(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseMaintainStandoff.Various);
				}
			}
			b2 = (byte?)doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.UseReplenishment_Inherits() && !value.Doctrine.UseReplenishment_Inherits())
				{
					b2 = (byte?)doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b = (byte?)value.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
					}
				}
				else if (doctrine.UseReplenishment_Inherits() && !value.Doctrine.UseReplenishment_Inherits())
				{
					doctrine.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
				}
				else if (!doctrine.UseReplenishment_Inherits() && value.Doctrine.UseReplenishment_Inherits())
				{
					doctrine.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UseUnderwayRefuelAndReplenishment.Various);
				}
			}
			b = (byte?)doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.ReplenishmentSelection_Inherits() && !value.Doctrine.ReplenishmentSelection_Inherits())
				{
					b = (byte?)doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					b2 = (byte?)value.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
					}
				}
				else if (doctrine.ReplenishmentSelection_Inherits() && !value.Doctrine.ReplenishmentSelection_Inherits())
				{
					doctrine.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
				}
				else if (!doctrine.ReplenishmentSelection_Inherits() && value.Doctrine.ReplenishmentSelection_Inherits())
				{
					doctrine.SetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, bool_3: false, Doctrine._UnderwayRefuelAndReplenishmentSelection.Various);
				}
			}
			b2 = (byte?)doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.ShootTourists_Inherits() && !value.Doctrine.ShootTourists_Inherits())
				{
					b2 = (byte?)doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
					}
				}
				else if (doctrine.ShootTourists_Inherits() && !value.Doctrine.ShootTourists_Inherits())
				{
					doctrine.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
				}
				else if (!doctrine.ShootTourists_Inherits() && value.Doctrine.ShootTourists_Inherits())
				{
					doctrine.SetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseShootTourists.Various);
				}
			}
			b = (byte?)doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.UseSAMsOnASuW_Inherits() && !value.Doctrine.UseSAMsOnASuW_Inherits())
				{
					b = (byte?)doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
					}
				}
				else if (doctrine.UseSAMsOnASuW_Inherits() && !value.Doctrine.UseSAMsOnASuW_Inherits())
				{
					doctrine.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
				}
				else if (!doctrine.UseSAMsOnASuW_Inherits() && value.Doctrine.UseSAMsOnASuW_Inherits())
				{
					doctrine.SetUseSAMsOnASuW(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseSAMsAgainstShips.Various);
				}
			}
			b2 = (byte?)doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.IgnoreEMCONunderAttack_Inherits() && !value.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					b2 = (byte?)doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
					}
				}
				else if (doctrine.IgnoreEMCONunderAttack_Inherits() && !value.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					doctrine.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
				}
				else if (!doctrine.IgnoreEMCONunderAttack_Inherits() && value.Doctrine.IgnoreEMCONunderAttack_Inherits())
				{
					doctrine.SetIgnoreEMCONunderAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseIgnoreEMCONunderAttack.Various);
				}
			}
			b = (byte?)doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.QuickTurnAroundForAicraft_Inherits() && !value.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					b = (byte?)doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					b2 = (byte?)value.Doctrine.GetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
					}
				}
				else if (doctrine.QuickTurnAroundForAicraft_Inherits() && !value.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					doctrine.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
				}
				else if (!doctrine.QuickTurnAroundForAicraft_Inherits() && value.Doctrine.QuickTurnAroundForAicraft_Inherits())
				{
					doctrine.SetQuickTurnAroundForAicraft(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._QuickTurnAroundForAicraft.Various);
				}
			}
			b2 = (byte?)doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.AirOpsTempo_Inherits() && !value.Doctrine.AirOpsTempo_Inherits())
				{
					b2 = (byte?)doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					b = (byte?)value.Doctrine.GetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: false, bool_3: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
					}
				}
				else if (doctrine.AirOpsTempo_Inherits() && !value.Doctrine.AirOpsTempo_Inherits())
				{
					doctrine.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
				}
				else if (!doctrine.AirOpsTempo_Inherits() && value.Doctrine.AirOpsTempo_Inherits())
				{
					doctrine.SetAirOpsTempo(Client.CurrentScenario, bool_0: false, UnitIsOperating, bool_2: true, bool_3: true, Doctrine._AirOpsTempo.Various);
				}
			}
			b = (byte?)doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.UseKinematicRangeForTorpedoes_Inherits() && !value.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					b = (byte?)doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
					}
				}
				else if (doctrine.UseKinematicRangeForTorpedoes_Inherits() && !value.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					doctrine.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
				}
				else if (!doctrine.UseKinematicRangeForTorpedoes_Inherits() && value.Doctrine.UseKinematicRangeForTorpedoes_Inherits())
				{
					doctrine.SetUseKinematicRangeForTorpedoes(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseKinematicRangeForTorpedoes.Various);
				}
			}
			short? num4 = (short?)doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			short? num5;
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WithdrawDamageThreshold_Inherits() && !value.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					num4 = (short?)doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)value.Doctrine.GetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
					}
				}
				else if (doctrine.WithdrawDamageThreshold_Inherits() && !value.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					doctrine.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
				else if (!doctrine.WithdrawDamageThreshold_Inherits() && value.Doctrine.WithdrawDamageThreshold_Inherits())
				{
					doctrine.SetWithdrawDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
			}
			num5 = (short?)doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WithdrawFuelThreshold_Inherits() && !value.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					num5 = (short?)doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)value.Doctrine.GetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
					}
				}
				else if (doctrine.WithdrawFuelThreshold_Inherits() && !value.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					doctrine.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
				else if (!doctrine.WithdrawFuelThreshold_Inherits() && value.Doctrine.WithdrawFuelThreshold_Inherits())
				{
					doctrine.SetWithdrawFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
			}
			num4 = (short?)doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WithdrawAttackThreshold_Inherits() && !value.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					num4 = (short?)doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)value.Doctrine.GetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (doctrine.WithdrawAttackThreshold_Inherits() && !value.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					doctrine.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!doctrine.WithdrawAttackThreshold_Inherits() && value.Doctrine.WithdrawAttackThreshold_Inherits())
				{
					doctrine.SetWithdrawAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num5 = (short?)doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.WithdrawDefenceThreshold_Inherits() && !value.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					num5 = (short?)doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)value.Doctrine.GetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (doctrine.WithdrawDefenceThreshold_Inherits() && !value.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					doctrine.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!doctrine.WithdrawDefenceThreshold_Inherits() && value.Doctrine.WithdrawDefenceThreshold_Inherits())
				{
					doctrine.SetWithdrawDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num4 = (short?)doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 5) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RedeployDamageThreshold_Inherits() && !value.Doctrine.RedeployDamageThreshold_Inherits())
				{
					num4 = (short?)doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)value.Doctrine.GetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
					}
				}
				else if (doctrine.RedeployDamageThreshold_Inherits() && !value.Doctrine.RedeployDamageThreshold_Inherits())
				{
					doctrine.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
				else if (!doctrine.RedeployDamageThreshold_Inherits() && value.Doctrine.RedeployDamageThreshold_Inherits())
				{
					doctrine.SetRedeployDamageThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DamageThreshold.Various);
				}
			}
			num5 = (short?)doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RedeployFuelThreshold_Inherits() && !value.Doctrine.RedeployFuelThreshold_Inherits())
				{
					num5 = (short?)doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)value.Doctrine.GetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
					}
				}
				else if (doctrine.RedeployFuelThreshold_Inherits() && !value.Doctrine.RedeployFuelThreshold_Inherits())
				{
					doctrine.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
				else if (!doctrine.RedeployFuelThreshold_Inherits() && value.Doctrine.RedeployFuelThreshold_Inherits())
				{
					doctrine.SetRedeployFuelThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._FuelQuantityThreshold.Various);
				}
			}
			num4 = (short?)doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RedeployAttackThreshold_Inherits() && !value.Doctrine.RedeployAttackThreshold_Inherits())
				{
					num4 = (short?)doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num5 = (short?)value.Doctrine.GetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num4.HasValue & num5.HasValue) ? new bool?(num4.GetValueOrDefault() != num5.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (doctrine.RedeployAttackThreshold_Inherits() && !value.Doctrine.RedeployAttackThreshold_Inherits())
				{
					doctrine.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!doctrine.RedeployAttackThreshold_Inherits() && value.Doctrine.RedeployAttackThreshold_Inherits())
				{
					doctrine.SetRedeployAttackThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			num5 = (short?)doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 7) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RedeployDefenceThreshold_Inherits() && !value.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					num5 = (short?)doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num4 = (short?)value.Doctrine.GetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num5.HasValue & num4.HasValue) ? new bool?(num5.GetValueOrDefault() != num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
					}
				}
				else if (doctrine.RedeployDefenceThreshold_Inherits() && !value.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					doctrine.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
				else if (!doctrine.RedeployDefenceThreshold_Inherits() && value.Doctrine.RedeployDefenceThreshold_Inherits())
				{
					doctrine.SetRedeployDefenceThreshold(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._WeaponQuantityThreshold.Various);
				}
			}
			b2 = (byte?)doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RefuelAllies_Inherits() && !value.Doctrine.RefuelAllies_Inherits())
				{
					b2 = (byte?)doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
					}
				}
				else if (doctrine.RefuelAllies_Inherits() && !value.Doctrine.RefuelAllies_Inherits())
				{
					doctrine.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
				}
				else if (!doctrine.RefuelAllies_Inherits() && value.Doctrine.RefuelAllies_Inherits())
				{
					doctrine.SetRefuelAllies(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RefuelAlliedUnits.Various);
				}
			}
			b = (byte?)doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.AvoidContact_Inherits() && !value.Doctrine.AvoidContact_Inherits())
				{
					b = (byte?)doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
					}
				}
				else if (doctrine.AvoidContact_Inherits() && !value.Doctrine.AvoidContact_Inherits())
				{
					doctrine.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
				}
				else if (!doctrine.AvoidContact_Inherits() && value.Doctrine.AvoidContact_Inherits())
				{
					doctrine.SetAvoidContact(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._AvoidContactWhenPossible.Various);
				}
			}
			b2 = (byte?)doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 4) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.DiveWhenThreatsDetected_Inherits() && !value.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					b2 = (byte?)doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
					}
				}
				else if (doctrine.DiveWhenThreatsDetected_Inherits() && !value.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					doctrine.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
				}
				else if (!doctrine.DiveWhenThreatsDetected_Inherits() && value.Doctrine.DiveWhenThreatsDetected_Inherits())
				{
					doctrine.SetDiveWhenThreatsDetected(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._DiveOnContact.Various);
				}
			}
			num3 = (int?)doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num3.HasValue ? new bool?(num3.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RechargePercentagePatrol_Inherits() && !value.Doctrine.RechargePercentagePatrol_Inherits())
				{
					num3 = (int?)doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num2 = (int?)value.Doctrine.GetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num3.HasValue & num2.HasValue) ? new bool?(num3.GetValueOrDefault() != num2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
					}
				}
				else if (doctrine.RechargePercentagePatrol_Inherits() && !value.Doctrine.RechargePercentagePatrol_Inherits())
				{
					doctrine.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
				else if (!doctrine.RechargePercentagePatrol_Inherits() && value.Doctrine.RechargePercentagePatrol_Inherits())
				{
					doctrine.SetRechargePercentagePatrol(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
			}
			num2 = (int?)doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == -100) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.RechargePercentageAttack_Inherits() && !value.Doctrine.RechargePercentageAttack_Inherits())
				{
					num2 = (int?)doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					num3 = (int?)value.Doctrine.GetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((num2.HasValue & num3.HasValue) ? new bool?(num2.GetValueOrDefault() != num3.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
					}
				}
				else if (doctrine.RechargePercentageAttack_Inherits() && !value.Doctrine.RechargePercentageAttack_Inherits())
				{
					doctrine.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
				else if (!doctrine.RechargePercentageAttack_Inherits() && value.Doctrine.RechargePercentageAttack_Inherits())
				{
					doctrine.SetRechargePercentageAttack(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._RechargeBatteryPercentage.Various);
				}
			}
			b = (byte?)doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.AIPUsage_Inherits() && !value.Doctrine.AIPUsage_Inherits())
				{
					b = (byte?)doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.method_2(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
					}
				}
				else if (doctrine.AIPUsage_Inherits() && !value.Doctrine.AIPUsage_Inherits())
				{
					doctrine.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
				}
				else if (!doctrine.AIPUsage_Inherits() && value.Doctrine.AIPUsage_Inherits())
				{
					doctrine.method_3(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseAIP.Various);
				}
			}
			b2 = (byte?)doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.DippingSonar_Inherits() && !value.Doctrine.DippingSonar_Inherits())
				{
					b2 = (byte?)doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
					}
				}
				else if (doctrine.DippingSonar_Inherits() && !value.Doctrine.DippingSonar_Inherits())
				{
					doctrine.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
				}
				else if (!doctrine.DippingSonar_Inherits() && value.Doctrine.DippingSonar_Inherits())
				{
					doctrine.SetDippingSonar(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._UseDippingSonar.Various);
				}
			}
			b = (byte?)doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.JettisonOrdnance_Inherits() && !value.Doctrine.JettisonOrdnance_Inherits())
				{
					b = (byte?)doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetJettison(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
					}
				}
				else if (doctrine.JettisonOrdnance_Inherits() && !value.Doctrine.JettisonOrdnance_Inherits())
				{
					doctrine.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
				}
				else if (!doctrine.JettisonOrdnance_Inherits() && value.Doctrine.JettisonOrdnance_Inherits())
				{
					doctrine.SetJettison(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._JettisonOrdnance.Various);
				}
			}
			b2 = (byte?)doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 3) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.BVRLogic_Inherits() && !value.Doctrine.BVRLogic_Inherits())
				{
					b2 = (byte?)doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.method_0(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
					}
				}
				else if (doctrine.BVRLogic_Inherits() && !value.Doctrine.BVRLogic_Inherits())
				{
					doctrine.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
				}
				else if (!doctrine.BVRLogic_Inherits() && value.Doctrine.BVRLogic_Inherits())
				{
					doctrine.method_1(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._BVRLogicEnum.Various);
				}
			}
			if (doctrine.EMCON_Inherits != value.Doctrine.EMCON_Inherits && !doctrine.EMCON_Inherits)
			{
				doctrine.EMCON_Inherits = true;
			}
			b = (byte?)doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.SurfaceNavigation_Inherits() && !value.Doctrine.SurfaceNavigation_Inherits())
				{
					b = (byte?)doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b2 = (byte?)value.Doctrine.GetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
					}
				}
				else if (doctrine.SurfaceNavigation_Inherits() && !value.Doctrine.SurfaceNavigation_Inherits())
				{
					doctrine.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
				else if (!doctrine.SurfaceNavigation_Inherits() && value.Doctrine.SurfaceNavigation_Inherits())
				{
					doctrine.SetSurfaceNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			b2 = (byte?)doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 6) : null);
			if (((!flag) ?? flag).GetValueOrDefault())
			{
				if (!doctrine.SubmarineNavigation_Inherits() && !value.Doctrine.SubmarineNavigation_Inherits())
				{
					b2 = (byte?)doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					b = (byte?)value.Doctrine.GetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
					if (((b2.HasValue & b.HasValue) ? new bool?(b2.GetValueOrDefault() != b.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						doctrine.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
					}
				}
				else if (doctrine.SubmarineNavigation_Inherits() && !value.Doctrine.SubmarineNavigation_Inherits())
				{
					doctrine.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
				else if (!doctrine.SubmarineNavigation_Inherits() && value.Doctrine.SubmarineNavigation_Inherits())
				{
					doctrine.SetSubmarineNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			b = (byte?)doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
			flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 6) : null);
			if (!((!flag) ?? flag).GetValueOrDefault())
			{
				continue;
			}
			if (!doctrine.LandNavigation_Inherits() && !value.Doctrine.LandNavigation_Inherits())
			{
				b = (byte?)doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				b2 = (byte?)value.Doctrine.GetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				if (((b.HasValue & b2.HasValue) ? new bool?(b.GetValueOrDefault() != b2.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					doctrine.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
				}
			}
			else if (doctrine.LandNavigation_Inherits() && !value.Doctrine.LandNavigation_Inherits())
			{
				doctrine.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
			}
			else if (!doctrine.LandNavigation_Inherits() && value.Doctrine.LandNavigation_Inherits())
			{
				doctrine.SetLandNavigation(Client.CurrentScenario, bool_0: false, bool_1: true, bool_2: true, Doctrine._NavigationMethod.Various);
			}
		}
		return doctrine;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	public DoctrineForm()
	{
		base.Load += TestSingleton;
		base.KeyDown += ResolveRecord;
		base.FormClosed += LogoutException;
		base.FormClosing += ViewException;
		attrOrder = new List<int>();
		watcherSpecification = true;
		isAirOps = false;
		isBoatOps = false;
		isMissionEdit = false;
		isEscorts = false;
		IntermittentEmissionSelectedAlertLevel = null;
		IntervalComboboxReference = new int[13];
		m_TaskSpecification = new Keys[1] { Keys.Escape };
		m_FilterSpecification = false;
		_TestsSpecification = true;
		ReflectSingleton();
	}

	private void NewException()
	{
		SendMessage(base.Handle, 11, new IntPtr(0), IntPtr.Zero);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.SuspendRefresh();
	}

	private void PushException(bool bool_0 = true)
	{
		SendMessage(base.Handle, 11, new IntPtr(-1), IntPtr.Zero);
		if (bool_0)
		{
			Refresh();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.ResumeRefresh();
	}

	private void InvokeException(object sender, DataGridViewDataErrorEventArgs e)
	{
	}

	public void RefreshSelectedUnits(ScenarioObject scenarioObject_0, ref ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_0, ref List<ActiveUnit> list_0)
	{
		_TestsSpecification = false;
		if (Information.IsNothing(list_0))
		{
			if (!Information.IsNothing(readOnlyCollection_0) && readOnlyCollection_0.Count > 1)
			{
				SelectedUnits = new List<ActiveUnit>();
				foreach (Module_Unit.Unit item2 in readOnlyCollection_0)
				{
					if (!item2.DisableWriter() && item2.GetUnitSide() == Client.CurrentSide && !item2.IsWeapon)
					{
						ActiveUnit item = (ActiveUnit)item2;
						SelectedUnits.Add(item);
					}
				}
				Subject = null;
			}
			else
			{
				if (Information.IsNothing(scenarioObject_0))
				{
					return;
				}
				if (scenarioObject_0.IsActiveUnit)
				{
					ActiveUnit activeUnit = (ActiveUnit)scenarioObject_0;
					if (!activeUnit.DisableWriter() && activeUnit.GetUnitSide() == Client.CurrentSide)
					{
						Subject = scenarioObject_0;
					}
				}
				else if ((object)scenarioObject_0.GetType() == typeof(Side))
				{
					Subject = scenarioObject_0;
				}
				else if ((object)scenarioObject_0.GetType() == typeof(Waypoint))
				{
					Subject = scenarioObject_0;
				}
			}
			return;
		}
		if (list_0.Count == 1)
		{
			if (!list_0[0].DisableWriter() && list_0[0].GetUnitSide() == Client.CurrentSide)
			{
				Subject = list_0[0];
				SelectedUnits = null;
			}
			return;
		}
		SelectedUnits = new List<ActiveUnit>();
		isAirOps = true;
		foreach (ActiveUnit item3 in list_0)
		{
			if (!item3.DisableWriter() && item3.GetUnitSide() == Client.CurrentSide)
			{
				SelectedUnits.Add(item3);
			}
		}
		Subject = null;
	}

	public void RefreshSelectedUnits(ScenarioObject scenarioObject_0)
	{
		if (scenarioObject_0 != null && (object)scenarioObject_0.GetType() == typeof(Side))
		{
			return;
		}
		if (Information.IsNothing(SelectedUnits))
		{
			SelectedUnits = new List<ActiveUnit>();
		}
		else
		{
			SelectedUnits.Clear();
		}
		Subject = null;
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (!Information.IsNothing(scenarioObject_0))
		{
			if (scenarioObject_0.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)scenarioObject_0;
				if (activeUnit.GetUnitSide() == Client.CurrentSide)
				{
					Subject = scenarioObject_0;
					list.Add(activeUnit);
				}
			}
			else if ((object)scenarioObject_0.GetType() == typeof(Side))
			{
				Subject = scenarioObject_0;
				list.AddRange(((Side)Subject).Units);
			}
			else if (scenarioObject_0.IsMission)
			{
				Subject = scenarioObject_0;
				list.AddRange(((Mission)Subject).UnitsAssignedToMission.Values);
				list.AddRange(((Mission)Subject).UnitsQueuedToMission.Values);
			}
			else if (scenarioObject_0.IsGroup)
			{
				Subject = scenarioObject_0;
				list.AddRange(((Group)Subject).Units.Values);
			}
		}
		for (int i = list.Count - 1; i >= 0; i += -1)
		{
			if (list[i].DisableWriter() || list[i].IsWeapon)
			{
				list.RemoveAt(i);
			}
		}
		if (!isMissionEdit)
		{
			SelectedUnits.AddRange(list);
		}
	}

	private void SetupException(object sender, EventArgs e)
	{
		recordOrder.SetBingoJokerRTB_PlayerEditable(Client.CurrentScenario, CB_FuelStateRTB_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ExcludeException(object sender, EventArgs e)
	{
		recordOrder.SetJettisonOrdnance_PlayerEditable(Client.CurrentScenario, CB_JettisonOrdnance_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void IncludeException(object sender, EventArgs e)
	{
		recordOrder.SetRefuelAllies_PlayerEditable(Client.CurrentScenario, CB_RefuelAllies_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void SearchException(object sender, EventArgs e)
	{
		recordOrder.SetAvoidContact_PlayerEditable(Client.CurrentScenario, CB_AvoidContact_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void EnableException(object sender, EventArgs e)
	{
		recordOrder.SetDiveWhenThreatsDetected_PlayerEditable(Client.CurrentScenario, CB_DiveWhenThreatsDetected_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ChangeException(object sender, EventArgs e)
	{
		recordOrder.SetRechargePercentagePatrol_PlayerEditable(Client.CurrentScenario, CB_BatteryRechargePatrol_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void InitException(object sender, EventArgs e)
	{
		recordOrder.SetRechargePercentageAttack_PlayerEditable(Client.CurrentScenario, CB_BatteryRechargeAttack_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void CheckException(object sender, EventArgs e)
	{
		recordOrder.SetAIPUsage_PlayerEditable(Client.CurrentScenario, CB_AIP_Usage_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void ConcatException(object sender, EventArgs e)
	{
		recordOrder.SetDippingSonar_PlayerEditable(Client.CurrentScenario, CB_DippingSonar_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void InterruptException(object sender, EventArgs e)
	{
		recordOrder.SetBVRLogic_PlayerEditable(Client.CurrentScenario, CB_BVRLogic_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void RemoveException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_RefuelAllies = Combo_RefuelAllies;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_RefuelAllies(combo_RefuelAllies, ref scenario_, ref m_PrinterOrder, bool_0: true, bool_1: false);
		Doctrine doctrine2 = recordOrder;
		scenario_ = Client.CurrentScenario;
		Side side_ = Client.CurrentSide;
		doctrine2.ResetMission_TimeSincePlayerNotification(ref scenario_, ref side_);
		Client.CurrentSide = side_;
		DefineSingleton();
	}

	private void FindException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox bingoThresholdCombo = BingoThresholdCombo;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_BingoThresholdCombo(bingoThresholdCombo, ref scenario_, ref authenticationOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void SetException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_AvoidContact = Combo_AvoidContact;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_AvoidContact(combo_AvoidContact, ref scenario_, ref parserOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void FillException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_DiveWhenThreatsDetected = Combo_DiveWhenThreatsDetected;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_DiveWhenThreatsDetected(combo_DiveWhenThreatsDetected, ref scenario_, ref m_AlgoOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void CalculateException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_BatteryRechargePatrol = Combo_BatteryRechargePatrol;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_RechargePercentagePatrol(combo_BatteryRechargePatrol, ref scenario_, ref m_DatabaseOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void PopException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_BatteryRechargeAttack = Combo_BatteryRechargeAttack;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_RechargePercentageAttack(combo_BatteryRechargeAttack, ref scenario_, ref _InterceptorOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void InstantiateException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_AIP_Usage = Combo_AIP_Usage;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_AIPUsage(combo_AIP_Usage, ref scenario_, ref messageOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void CreateException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_DippingSonar = Combo_DippingSonar;
		Scenario scenario_ = Client.CurrentScenario;
		doctrine.SelectionChanged_Combo_DippingSonar(combo_DippingSonar, ref scenario_, ref _ProductOrder, bool_0: true, bool_1: false);
		DefineSingleton();
	}

	private void CompareException(object sender, EventArgs e)
	{
		m_PrinterOrder = Combo_RefuelAllies.SelectedIndex;
	}

	private void ReadException(object sender, EventArgs e)
	{
		authenticationOrder = BingoThresholdCombo.SelectedIndex;
	}

	private void DisableException(object sender, EventArgs e)
	{
		parserOrder = Combo_AvoidContact.SelectedIndex;
	}

	private void UpdateException(object sender, EventArgs e)
	{
		m_AlgoOrder = Combo_DiveWhenThreatsDetected.SelectedIndex;
	}

	private void InsertException(object sender, EventArgs e)
	{
		_TagOrder = Combo_Standoff.SelectedIndex;
	}

	private void PrepareException(object sender, EventArgs e)
	{
		m_DatabaseOrder = Combo_BatteryRechargePatrol.SelectedIndex;
	}

	private void ReflectException(object sender, EventArgs e)
	{
		_InterceptorOrder = Combo_BatteryRechargeAttack.SelectedIndex;
	}

	private void VisitException(object sender, EventArgs e)
	{
		messageOrder = Combo_AIP_Usage.SelectedIndex;
	}

	private void RestartException(object sender, EventArgs e)
	{
		_ProductOrder = Combo_DippingSonar.SelectedIndex;
	}

	private void TestException(object sender, EventArgs e)
	{
		roleOrder = Combo_WithdrawDamageThreshold.SelectedIndex;
	}

	private void StopException(object sender, EventArgs e)
	{
		m_GlobalOrder = Combo_RedeployDamageThreshold.SelectedIndex;
	}

	private void CancelException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WithdrawDamageThreshold = Combo_WithdrawDamageThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_WithdrawDamageThreshold(combo_WithdrawDamageThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void VerifyException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_RedeployDamageThreshold = Combo_RedeployDamageThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_RedeployDamageThreshold(combo_RedeployDamageThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void ListException(object sender, EventArgs e)
	{
		factoryOrder = Combo_WithdrawFuelThreshold.SelectedIndex;
	}

	private void ResolveException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WithdrawFuelThreshold = Combo_WithdrawFuelThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_WithdrawFuelThreshold(combo_WithdrawFuelThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void PostException(object sender, EventArgs e)
	{
		m_WorkerOrder = Combo_RedeployFuelThreshold.SelectedIndex;
	}

	private void RunException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_RedeployFuelThreshold = Combo_RedeployFuelThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_RedeployFuelThreshold(combo_RedeployFuelThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void StartException(object sender, EventArgs e)
	{
		_AttributeOrder = Combo_WithdrawAttackThreshold.SelectedIndex;
	}

	private void AssetException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WithdrawAttackThreshold = Combo_WithdrawAttackThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_WithdrawAttackThreshold(combo_WithdrawAttackThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void PrintException(object sender, EventArgs e)
	{
		m_AccountOrder = Combo_RedeployAttackThreshold.SelectedIndex;
	}

	private void DefineException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_RedeployAttackThreshold = Combo_RedeployAttackThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_RedeployAttackThreshold(combo_RedeployAttackThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void PublishException(object sender, EventArgs e)
	{
		m_EventOrder = Combo_WithdrawDefenceThreshold.SelectedIndex;
	}

	private void AwakeException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_WithdrawDefenceThreshold = Combo_WithdrawDefenceThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_WithdrawDefenceThreshold(combo_WithdrawDefenceThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void QueryException(object sender, EventArgs e)
	{
		stateOrder = Combo_RedeployDefenceThreshold.SelectedIndex;
	}

	private void ResetException(object sender, EventArgs e)
	{
		Doctrine doctrine = recordOrder;
		DarkUIComboBox combo_RedeployDefenceThreshold = Combo_RedeployDefenceThreshold;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		doctrine.SelectionChanged_Combo_RedeployDefenceThreshold(combo_RedeployDefenceThreshold, ref scenario_, ref int_, bool_0: true, bool_1: true);
		DefineSingleton();
	}

	private void MapException(object sender, EventArgs e)
	{
		IntermittentEmissionSelectedAlertLevel = EmconLevel.GetAlertEnumWithString(EmissionIntervalTABControl.SelectedTab.Tag.ToString());
		SortException();
	}

	private void SortException()
	{
		try
		{
			if (!Information.IsNothing(Subject) && Subject.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)Subject;
				EmconLevel emconAlertness = activeUnit.GetUnitSide().EmconAlertness;
				if (!IntermittentEmissionSelectedAlertLevel.HasValue)
				{
					if (activeUnit.Sensory.InterruptConsumer().UseCustomPresetOnly)
					{
						IntermittentEmissionSelectedAlertLevel = Alertlevels.Custom;
					}
					else
					{
						IntermittentEmissionSelectedAlertLevel = emconAlertness.Level;
					}
				}
				int? num = (int?)IntermittentEmissionSelectedAlertLevel;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() != 999) : null).GetValueOrDefault())
				{
					EmissionIntervalTABControl.SelectedIndex = (int)IntermittentEmissionSelectedAlertLevel.Value;
				}
				Combo_AlertLevel.SelectedIndex = (int)activeUnit.GetUnitSide().EmconAlertness.Level;
				if (activeUnit.IsGroup)
				{
					CBIntermittentEmission_InheritFromGroup.Visible = false;
				}
				else
				{
					if (activeUnit.Sensors_ReadOnly().Length == 0)
					{
						RegisterException(bool_0: false);
						return;
					}
					CBIntermittentEmission_InheritFromGroup.Visible = true;
				}
				IntervalConfigs = ForgotException();
				ActiveEmissionInterval activeEmissionInterval = activeUnit.Sensory.InterruptConsumer();
				if (IntervalConfigs != null)
				{
					RegisterException(bool_0: true);
					OrderException(IntervalConfigs.UseEmissionInterval);
					if (IntervalConfigs.UseEmissionInterval)
					{
						IntermittantToggle.Text = "间断工作模式";
					}
					else
					{
						IntermittantToggle.Text = "连续工作模式";
					}
					Interval.Text = IntervalConfigs.EmissionInterval.ToString();
					IntervalVariation.Text = IntervalConfigs.EmissionIntervalVariation.ToString();
					CBWakeWhenDetectingThreat.Checked = IntervalConfigs.WakeWhenDetectingThreat;
					BackToSleepTime.Text = IntervalConfigs.SleepModeDelay.ToString();
					CB_IntermittentEmission_USECUSTOM.Checked = activeEmissionInterval.UseCustomPresetOnly;
					CBIntermittentEmission_InheritFromGroup.Checked = activeEmissionInterval.InheritParentGroupConfig;
					CalcException(activeUnit);
					EmissionDurationTextBox.Text = IntervalConfigs.EmissionDuration.ToString();
					DarkLabel_0.Text = activeEmissionInterval.SortIssuer().ToString();
					EmissionIntervalPhonyTab.BackColor = EmconLevel.GetAlertColor(IntermittentEmissionSelectedAlertLevel.Value, bool_0: true);
					RateException();
				}
			}
			else
			{
				RegisterException(bool_0: false);
				Combo_AlertLevel.SelectedIndex = (int)Client.CurrentSide.EmconAlertness.Level;
			}
		}
		catch (Exception exception_)
		{
			ProjectData.SetProjectError(exception_);
			exception_?.Data.Add("Error at INTER_E_01", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcException(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(activeUnit_0))
		{
			activeUnit_0 = (ActiveUnit)Subject;
		}
		if (!Information.IsNothing(activeUnit_0))
		{
			if (Information.IsNothing(activeUnit_0.GetParentGroup()))
			{
				CB_IntermittentEmission_USECUSTOM.Visible = true;
				CBIntermittentEmission_InheritFromGroup.Visible = false;
			}
			else
			{
				CB_IntermittentEmission_USECUSTOM.Visible = !activeUnit_0.Sensory.InterruptConsumer().InheritParentGroupConfig;
				CBIntermittentEmission_InheritFromGroup.Visible = true;
			}
		}
	}

	private void RateException()
	{
		CBWakeWhenDetectingThreat.Visible = IntervalConfigs.UseEmissionInterval;
		WakeGroupBox.Visible = IntervalConfigs.UseEmissionInterval && IntervalConfigs.WakeWhenDetectingThreat;
		if (IntervalConfigs.WakeWhenDetectingThreat)
		{
			BackToSleepTime.Text = IntervalConfigs.SleepModeDelay.ToString();
			CB_IncludesStance_Friendly.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Friendly];
			CB_IncludesStance_Neutral.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Neutral];
			CB_IncludesStance_Unfriendly.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly];
			CB_IncludesStance_Hostile.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Hostile];
			CB_IncludesStance_Unknown.Checked = IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unknown];
			CB_IncludesID_Unknown.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown];
			CB_IncludesID_KnownDomain.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain];
			CB_IncludesID_KnowType.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType];
			CB_IncludesID_KnownClass.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass];
			CB_IncludesID_KnownID.Checked = IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID];
		}
	}

	private void FlushException(bool bool_0)
	{
		Label_AEI_3.Visible = bool_0;
		BackToSleepTime.Visible = bool_0;
		Includes.Visible = bool_0;
		CB_IncludesStance_Friendly.Visible = bool_0;
		CB_IncludesStance_Neutral.Visible = bool_0;
		CB_IncludesStance_Unfriendly.Visible = bool_0;
		CB_IncludesStance_Hostile.Visible = bool_0;
		CB_IncludesStance_Unknown.Visible = bool_0;
		DarkLabel6.Visible = bool_0;
		DarkLabel7.Visible = bool_0;
		IncludesIDGroup.Visible = bool_0;
		CB_IncludesID_Unknown.Visible = bool_0;
		CB_IncludesID_KnownDomain.Visible = bool_0;
		CB_IncludesID_KnowType.Visible = bool_0;
		CB_IncludesID_KnownClass.Visible = bool_0;
		CB_IncludesID_KnownID.Visible = bool_0;
	}

	private ActiveEmissionInterval_Config ForgotException()
	{
		if (!Information.IsNothing(Subject) && Subject.IsActiveUnit)
		{
			return ((ActiveUnit)Subject).Sensory.InterruptConsumer().Configs[IntermittentEmissionSelectedAlertLevel.Value];
		}
		return null;
	}

	private ActiveEmissionInterval CollectException()
	{
		if (IntervalConfigs == null)
		{
			return null;
		}
		if (!Information.IsNothing(Subject) && Subject.IsActiveUnit)
		{
			return ((ActiveUnit)Subject).Sensory.InterruptConsumer();
		}
		return null;
	}

	private void OrderException(bool bool_0, bool bool_1 = true)
	{
		IntermittantToggle.Visible = bool_1;
		EmissionDurationTextBox.Visible = bool_0;
		Interval.Visible = bool_0;
		IntervalVariation.Visible = bool_0;
		LabelPlus.Visible = bool_0;
		BackToSleepTime.Visible = bool_0;
		Label_AEI_0.Visible = bool_0;
		Label_AEI_1.Visible = bool_0;
		Label_AEI_2.Visible = bool_0;
		Label_AEI_3.Visible = bool_0;
	}

	private void RegisterException(bool bool_0)
	{
		UseIntervalGroup.Visible = bool_0;
		EmissionIntervalPhonyTab.Visible = bool_0;
	}

	private void ManageException(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = CollectException();
		if (activeEmissionInterval != null)
		{
			activeEmissionInterval.ToggleEmissionMode(ForgotException());
			SortException();
		}
	}

	private void RevertException(object sender, EventArgs e)
	{
		ActiveEmissionInterval activeEmissionInterval = CollectException();
		if (activeEmissionInterval != null)
		{
			activeEmissionInterval.ToggleSleep_Wake();
			SortException();
		}
	}

	private void CountAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			if (!Versioned.IsNumeric(Interval.Text))
			{
				Interval.Text = "0";
			}
			IntervalConfigs.EmissionInterval = Convert.ToSingle(Interval.Text);
		}
	}

	private void CustomizeAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			if (!Versioned.IsNumeric(IntervalVariation.Text))
			{
				IntervalVariation.Text = "0";
			}
			IntervalConfigs.EmissionIntervalVariation = Convert.ToSingle(IntervalVariation.Text);
		}
	}

	private void CloneAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			if (!Versioned.IsNumeric(BackToSleepTime.Text))
			{
				BackToSleepTime.Text = "0";
			}
			IntervalConfigs.SleepModeDelay = Convert.ToSingle(BackToSleepTime.Text);
		}
	}

	private void ConnectAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			if (!Versioned.IsNumeric(EmissionDurationTextBox.Text))
			{
				EmissionDurationTextBox.Text = "0";
			}
			IntervalConfigs.EmissionDuration = Convert.ToSingle(EmissionDurationTextBox.Text);
		}
	}

	private void MoveAttr(object object_0)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.WakeWhenDetectingThreat = CBWakeWhenDetectingThreat.Checked;
			RateException();
		}
	}

	private void DeleteAttr(object sender, EventArgs e)
	{
		if (!Information.IsNothing(Client.CurrentSide))
		{
			Client.CurrentSide.EmconAlertness.Level = (Alertlevels)Combo_AlertLevel.SelectedIndex;
		}
	}

	private void AddAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Friendly] = CB_IncludesStance_Friendly.Checked;
		}
	}

	private void DestroyAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Neutral] = CB_IncludesStance_Neutral.Checked;
		}
	}

	private void ComputeAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = CB_IncludesStance_Unfriendly.Checked;
		}
	}

	private void PatchAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Hostile] = CB_IncludesStance_Hostile.Checked;
		}
	}

	private void SelectAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactStance[Misc.PostureStance.Unknown] = CB_IncludesStance_Unknown.Checked;
		}
	}

	private void CallAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = CB_IncludesID_Unknown.Checked;
		}
	}

	private void LogoutAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = CB_IncludesID_KnownDomain.Checked;
		}
	}

	private void ViewAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = CB_IncludesID_KnowType.Checked;
		}
	}

	private void ValidateAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = CB_IncludesID_KnownClass.Checked;
		}
	}

	private void LoginAttr(object sender, EventArgs e)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = CB_IncludesID_KnownID.Checked;
		}
	}

	private void GetAttr(object object_0)
	{
		if (IntervalConfigs != null)
		{
			IntervalConfigs.FollowWRAforWakeBehavior = CB_EmconFollowsWRARules.Checked;
		}
	}

	private void WriteAttr(object object_0)
	{
		ActiveEmissionInterval activeEmissionInterval = CollectException();
		if (activeEmissionInterval != null && IntervalConfigs != null)
		{
			activeEmissionInterval.UseCustomPresetOnly = CB_IntermittentEmission_USECUSTOM.Checked;
			CalcException(null);
		}
	}

	private void NewAttr(object object_0)
	{
		ActiveEmissionInterval activeEmissionInterval = CollectException();
		if (activeEmissionInterval != null && IntervalConfigs != null)
		{
			activeEmissionInterval.InheritParentGroupConfig = CBIntermittentEmission_InheritFromGroup.Checked;
			CalcException(null);
		}
	}

	private void PushAttr(object sender, EventArgs e)
	{
		recordOrder.SetUseWPMissileOnASuW_PlayerEditable(Client.CurrentScenario, CB_UseWPMissilesOnASuW.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void InvokeAttr(object sender, EventArgs e)
	{
		recordOrder.SetBingoRefuel_PlayerEditable(Client.CurrentScenario, CB_BongoThreshold_PlayerEditable.Checked);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.DoctrineControl1.RefreshPanel(bool_0: false);
	}

	private void SetupAttr(object sender, EventArgs e)
	{
		int num = ChangeAttr();
		if (num > -1)
		{
			recordOrder.SwapPriorityTargetListEntry(num, bool_0: true);
			if (num > 0)
			{
				RefreshPriorityTargetList(recordOrder, num - 1);
			}
		}
	}

	private void ExcludeAttr(object sender, EventArgs e)
	{
		int num = ChangeAttr();
		if (num > -1)
		{
			recordOrder.SwapPriorityTargetListEntry(num, bool_0: false);
			RefreshPriorityTargetList(recordOrder, num + 1);
		}
	}

	private void IncludeAttr(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.PriorityTargetForm.ParentDoctrine = recordOrder;
		ItemExporter.ConnectInterruptibleTemplate.PriorityTargetForm.MainDoctrineForm = this;
		ItemExporter.ConnectInterruptibleTemplate.PriorityTargetForm.InsertIndex = ChangeAttr();
		ItemExporter.ConnectInterruptibleTemplate.PriorityTargetForm.Show();
	}

	private void SearchAttr(object sender, EventArgs e)
	{
		int num = ChangeAttr();
		if (num > -1)
		{
			recordOrder.DeletePriorityTargetListEntry(num);
			RefreshPriorityTargetList(recordOrder, num);
		}
	}

	private void EnableAttr(object sender, EventArgs e)
	{
	}

	private int ChangeAttr()
	{
		if (List_TargetPriority.SelectedIndices != null && List_TargetPriority.SelectedIndices.Count > 0)
		{
			return List_TargetPriority.SelectedIndices.FirstOrDefault();
		}
		return -1;
	}

	private void InitAttr(object sender, EventArgs e)
	{
		recordOrder.CreatePriorityTargetList();
		RunSingleton();
	}

	private void CheckAttr(object sender, EventArgs e)
	{
		recordOrder.RemovePriorityTargetList();
		RunSingleton();
	}
}
