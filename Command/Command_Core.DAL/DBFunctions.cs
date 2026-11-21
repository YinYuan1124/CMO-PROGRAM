using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.DAL;

[StandardModule]
public sealed class DBFunctions
{
	private struct AuthenticationCollectionRecord : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string collectionSetter;

		public long m_InstanceSetter;

		public long _ObjectSetter;

		public double parameterSetter;

		public double expressionSetter;

		public double _DispatcherSetter;

		public double listenerSetter;

		public double _ConfigSetter;

		public double m_RegistrySetter;

		public double definitionSetter;

		public double valSetter;

		public long m_WrapperSetter;

		public long observerSetter;

		public long _IssuerSetter;

		public long m_ClientSetter;

		public double m_DicSetter;

		public double consumerSetter;

		public double facadeSetter;

		public double proxySetter;

		public double _ReaderSetter;

		public double _PropertySetter;

		public double m_ImporterSetter;

		public double _RepositorySetter;

		public double bridgeSetter;

		public double _InvocationSetter;

		public double classSetter;

		public double m_RequestSetter;

		public double valueSetter;

		public long m_TokenizerSetter;

		public long _StubSetter;

		public double writerSetter;

		public double _SpecificationSetter;

		public double watcherSetter;

		public double _ReponseSetter;

		public long _DescriptorSetter;

		public long m_PoolSetter;

		public double _TaskSetter;

		public double filterSetter;

		public double m_TestsSetter;

		public double _InterpreterSetter;

		public double m_ContainerSetter;

		public bool _ComposerSetter;

		public long modelSetter;

		public long _AdvisorSetter;

		public long customerSetter;

		public double serializerSetter;

		public long refSetter;

		public double errorSetter;

		public bool m_CodeSetter;

		public long m_ConnectionSetter;

		public double m_ContextSetter;

		public double m_StatusSetter;

		public double m_ProccesorSetter;

		public bool _StrategySetter;

		public long _ConfigurationSetter;

		public bool tokenSetter;

		public bool _IndexerSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref collectionSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InstanceSetter, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ObjectSetter, "Generation");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref parameterSetter, "Length");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref expressionSetter, "Span");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _DispatcherSetter, "Diameter");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref listenerSetter, "Weight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ConfigSetter, "BurnoutTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_RegistrySetter, "BurnoutWeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref definitionSetter, "CruiseAltitude");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref valSetter, "CruiseAltitude_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_WrapperSetter, "WaypointNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref observerSetter, "IlluminationTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _IssuerSetter, "CEP");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ClientSetter, "CEPSurface");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_DicSetter, "AirPoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref consumerSetter, "SurfacePoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref facadeSetter, "LandPoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref proxySetter, "SubsurfacePoK");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ReaderSetter, "ClimbRate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _PropertySetter, "AirRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ImporterSetter, "AirRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _RepositorySetter, "SurfaceRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref bridgeSetter, "SurfaceRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _InvocationSetter, "LandRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref classSetter, "LandRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_RequestSetter, "SubsurfaceRangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref valueSetter, "SubsurfaceRangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_TokenizerSetter, "LaunchSpeedMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _StubSetter, "LaunchSpeedMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref writerSetter, "LaunchAltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _SpecificationSetter, "LaunchAltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref watcherSetter, "LaunchAltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ReponseSetter, "LaunchAltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _DescriptorSetter, "TargetSpeedMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PoolSetter, "TargetSpeedMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _TaskSetter, "TargetAltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref filterSetter, "TargetAltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_TestsSetter, "TargetAltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _InterpreterSetter, "TargetAltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ContainerSetter, "SnapUpDownAltitude");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ComposerSetter, "CanActAsSensor");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref modelSetter, "MaxFlightTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AdvisorSetter, "DetonationDelay");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref customerSetter, "TorpedoSpeedCruise");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref serializerSetter, "TorpedoRangeCruise");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref refSetter, "TorpedoSpeedFull");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref errorSetter, "TorpedoRangeFull");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_CodeSetter, "BuddyIlluminationForCEC");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ConnectionSetter, "Cargo_Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ContextSetter, "Cargo_Mass");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StatusSetter, "Cargo_Volume");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ProccesorSetter, "Cargo_Crew");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _StrategySetter, "Cargo_ParadropCapable");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ConfigurationSetter, "Cost");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref tokenSetter, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _IndexerSetter, "Deprecated");
		}
	}

	private struct ClientProcessProducer : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public long resolverSetter;

		public string m_PublisherSetter;

		public bool _ServerSetter;

		public double? _AdapterSetter;

		public double m_SchemaSetter;

		public double _UtilsSetter;

		public double predicateSetter;

		public double _SingletonSetter;

		public bool _RecordSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref resolverSetter, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PublisherSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ServerSetter, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AdapterSetter, "NumberOfEngines");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_SchemaSetter, "ThrustPerEngineMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _UtilsSetter, "ThrustPerEngineAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref predicateSetter, "SFCMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _SingletonSetter, "SFCAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _RecordSetter, "Deprecated");
		}
	}

	private struct CodeObjectListener : DBCache.I_CacheableRow
	{
		public long m_ExceptionSetter;

		public long ID;

		public long _AttrSetter;

		public long m_VisitorSetter;

		public bool exporterSetter;

		public bool _PrototypeSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ExceptionSetter, "CommID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AttrSetter, "ComponentNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_VisitorSetter, "ComponentID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref exporterSetter, "ParentSpecific");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _PrototypeSetter, "IsRelay");
		}
	}

	private struct ComparatorSetter : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string _ItemSetter;

		public long setterSetter;

		public double DamagePoints;

		public long m_CreatorSetter;

		public long _TemplateSetter;

		public double m_MappingSetter;

		public long m_MockSetter;

		public long _TagSetter;

		public long _FieldSetter;

		public bool m_QueueSetter;

		public bool m_RegSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ItemSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref setterSetter, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref DamagePoints, "DamagePoints");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_CreatorSetter, "ProjectileCaliber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _TemplateSetter, "ExplosivesType");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_MappingSetter, "ExplosivesWeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_MockSetter, "NumberOfWarheads");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _TagSetter, "ClusterBombDispersionAreaLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _FieldSetter, "ClusterBombDispersionAreaWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_QueueSetter, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_RegSetter, "Deprecated");
		}
	}

	private struct ParamSetter : DBCache.I_CacheableRow
	{
		public double m_PageSetter;

		public double _RulesSetter;

		public double _MethodSetter;

		public double serviceSetter;

		public double m_SystemSetter;

		public double m_CandidateSetter;

		public double _BaseSetter;

		public long policySetter;

		public double _BroadcasterSetter;

		public double m_IdentifierSetter;

		public double m_PrinterSetter;

		public double _ParserSetter;

		public double _AlgoSetter;

		public double m_DatabaseSetter;

		public double interceptorSetter;

		public long _MessageSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PageSetter, "RadarHorizontalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _RulesSetter, "RadarVerticalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _MethodSetter, "RadarSystemNoiseLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref serviceSetter, "RadarProcessingGainLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_SystemSetter, "RadarPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_CandidateSetter, "RadarPulseWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _BaseSetter, "RadarBlindTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref policySetter, "RadarPRF");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _BroadcasterSetter, "RadarHorizontalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_IdentifierSetter, "RadarVerticalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PrinterSetter, "RadarSystemNoiseLevelIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ParserSetter, "RadarProcessingGainLossIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AlgoSetter, "RadarPeakPowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_DatabaseSetter, "RadarPulseWidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref interceptorSetter, "RadarBlindTimeIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _MessageSetter, "RadarPRFIlluminate");
		}
	}

	private struct ClassListenerMapping : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public long _ProductSetter;

		public string annotationSetter;

		public bool m_IteratorSetter;

		public double m_InitializerSetter;

		public double _RoleSetter;

		public double _FactorySetter;

		public double m_AttributeSetter;

		public double m_EventSetter;

		public bool globalSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ProductSetter, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref annotationSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_IteratorSetter, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InitializerSetter, "NumberOfEngines");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _RoleSetter, "ThrustPerEngineMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _FactorySetter, "ThrustPerEngineAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_AttributeSetter, "SFCMilitary");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_EventSetter, "SFCAfterburner");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref globalSetter, "Deprecated");
		}
	}

	private struct PageExpressionDic : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string _WorkerSetter;

		public long m_AccountSetter;

		public long m_StateSetter;

		public long authenticationSetter;

		public bool _ParamsSetter;

		public bool m_InfoSetter;

		public bool m_HelperSetter;

		public bool m_MapperSetter;

		public long _ManagerSetter;

		public long m_GetterSetter;

		public long producerSetter;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _WorkerSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_AccountSetter, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StateSetter, "Range");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref authenticationSetter, "Channels");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ParamsSetter, "IsOptional");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InfoSetter, "WeaponLinkRequiresSensor");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_HelperSetter, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_MapperSetter, "Deprecated");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ManagerSetter, "QualityGrade");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_GetterSetter, "RefreshRateGrade");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref producerSetter, "RefreshRate");
		}
	}

	private struct DicProcessProducer : DBCache.I_CacheableRow
	{
		public long ID;

		public string Name;

		public string m_ProcSetter;

		public long m_StructCreator;

		public long Role;

		public long m_MerchantCreator;

		public long callbackCreator;

		public double _DecoratorCreator;

		public double _ProcessCreator;

		public long _ThreadCreator;

		public long _RuleCreator;

		public long m_CollectionCreator;

		public long m_InstanceCreator;

		public long _ObjectCreator;

		public double m_ParameterCreator;

		public long _ExpressionCreator;

		public double m_DispatcherCreator;

		public double _ListenerCreator;

		public long configCreator;

		public long registryCreator;

		public long definitionCreator;

		public long _ValCreator;

		public long m_WrapperCreator;

		public double m_ObserverCreator;

		public double issuerCreator;

		public double _ClientCreator;

		public double dicCreator;

		public double consumerCreator;

		public double m_FacadeCreator;

		public double proxyCreator;

		public double m_ReaderCreator;

		public double m_PropertyCreator;

		public double _ImporterCreator;

		public double repositoryCreator;

		public long _BridgeCreator;

		public double m_InvocationCreator;

		public double _ClassCreator;

		public double m_RequestCreator;

		public double valueCreator;

		public double m_TokenizerCreator;

		public double m_StubCreator;

		public double m_WriterCreator;

		public long _SpecificationCreator;

		public double m_WatcherCreator;

		public double reponseCreator;

		public double descriptorCreator;

		public bool _PoolCreator;

		public double taskCreator;

		public double m_FilterCreator;

		public double m_TestsCreator;

		public long _InterpreterCreator;

		public double containerCreator;

		public double m_ComposerCreator;

		public double _ModelCreator;

		public double m_AdvisorCreator;

		public double _CustomerCreator;

		public double serializerCreator;

		public double refCreator;

		public double m_ErrorCreator;

		public double codeCreator;

		public double _ConnectionCreator;

		public long m_ContextCreator;

		public double m_StatusCreator;

		public double proccesorCreator;

		public double _StrategyCreator;

		public double _ConfigurationCreator;

		public long MineSweepWidth;

		public long indexerCreator;

		public long m_ResolverCreator;

		public long MineSweepMaximumSpeed;

		public bool _ServerCreator;

		public double _AdapterCreator;

		public double schemaCreator;

		public double m_UtilsCreator;

		public double _PredicateCreator;

		public double singletonCreator;

		public double recordCreator;

		public bool exceptionCreator;

		public string Description;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Name, "Name");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ProcSetter, "Comments");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StructCreator, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Role, "Role");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_MerchantCreator, "Generation");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref callbackCreator, "MasqueradeAs");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _DecoratorCreator, "RangeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ProcessCreator, "RangeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ThreadCreator, "AltitudeMin");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _RuleCreator, "AltitudeMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_CollectionCreator, "AltitudeMin_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InstanceCreator, "AltitudeMax_ASL");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ObjectCreator, "ScanInterval");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ParameterCreator, "ResolutionRange");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ExpressionCreator, "ResolutionHeight");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_DispatcherCreator, "ResolutionAngle");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ListenerCreator, "DirectionFindingAccuracy");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref configCreator, "MaxContactsAir");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref registryCreator, "MaxContactsSurface");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref definitionCreator, "MaxContactsSubmarine");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ValCreator, "MaxContactsIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_WrapperCreator, "Availability");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ObserverCreator, "FrequencyUpper");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref issuerCreator, "FrequencyLower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ClientCreator, "FrequencyLowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref dicCreator, "FrequencyUpperIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref consumerCreator, "RadarHorizontalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_FacadeCreator, "RadarVerticalBeamwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref proxyCreator, "RadarSystemNoiseLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ReaderCreator, "RadarProcessingGainLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PropertyCreator, "RadarPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ImporterCreator, "RadarPulseWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref repositoryCreator, "RadarBlindTime");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _BridgeCreator, "RadarPRF");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InvocationCreator, "RadarHorizontalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ClassCreator, "RadarVerticalBeamwidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_RequestCreator, "RadarSystemNoiseLevelIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref valueCreator, "RadarProcessingGainLossIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_TokenizerCreator, "RadarPeakPowerIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StubCreator, "RadarPulseWidthIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_WriterCreator, "RadarBlindTimeIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _SpecificationCreator, "RadarPRFIlluminate");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_WatcherCreator, "ESMSensitivity");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref reponseCreator, "ESMSystemLoss");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref descriptorCreator, "ESMNumberOfChannels");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _PoolCreator, "ESMPreciseEmitterID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref taskCreator, "ECMGain");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_FilterCreator, "ECMPeakPower");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_TestsCreator, "ECMBandwidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _InterpreterCreator, "ECMNumberOfTargets");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref containerCreator, "ECMPoKReduction");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ComposerCreator, "SonarSourceLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ModelCreator, "SonarPulseLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_AdvisorCreator, "SonarDirectivityIndex");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _CustomerCreator, "SonarRecognitionDifferentialActive");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref serializerCreator, "SonarRecognitionDifferentialPassive");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref refCreator, "SonarSensorToMachineryDistance");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ErrorCreator, "SonarTowLength");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref codeCreator, "SonarMinimumDeploymentDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ConnectionCreator, "SonarMaximumDeploymentDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ContextCreator, "SonarCZNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StatusCreator, "VisualDetectionZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref proccesorCreator, "VisualClassificationZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _StrategyCreator, "IRDetectionZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ConfigurationCreator, "IRClassificationZoomLevel");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref MineSweepWidth, "MineSweepWidth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref indexerCreator, "MineSweepMinimumDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ResolverCreator, "MineSweepMaximumDepth");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref MineSweepMaximumSpeed, "MineSweepMaximumSpeed");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ServerCreator, "Hypothetical");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AdapterCreator, "MinimumSignature_Radar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref schemaCreator, "MinimumSignature_Visual");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_UtilsCreator, "MinimumSignature_IR");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _PredicateCreator, "MinimumSignature_ESM");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref singletonCreator, "MinimumSignature_ActiveSonar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref recordCreator, "MinimumSignature_PassiveSonar");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref exceptionCreator, "Deprecated");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref Description, "Description");
		}
	}

	private struct ConnectionObjectListener
	{
		public PlatformComponent._Coverage m_AttrCreator;

		public PlatformComponent._Coverage _VisitorCreator;
	}

	private struct ContextObjectListener : DBCache.I_CacheableRow
	{
		public long ID;

		public long m_ExporterCreator;

		public long m_PrototypeCreator;

		public long comparatorCreator;

		public long itemCreator;

		public long setterCreator;

		public bool _CreatorCreator;

		public bool m_TemplateCreator;

		public bool mappingCreator;

		public bool m_MockCreator;

		public bool tagCreator;

		public bool m_FieldCreator;

		public bool queueCreator;

		public bool regCreator;

		public bool m_ParamCreator;

		public bool m_PageCreator;

		public bool rulesCreator;

		public bool _MethodCreator;

		public bool m_ServiceCreator;

		public bool _SystemCreator;

		public bool _CandidateCreator;

		public bool baseCreator;

		public long policyCreator;

		public bool broadcasterCreator;

		public bool _IdentifierCreator;

		public bool _PrinterCreator;

		public bool m_ParserCreator;

		public bool _AlgoCreator;

		public bool m_DatabaseCreator;

		public bool m_InterceptorCreator;

		public bool messageCreator;

		public bool _ProductCreator;

		public bool _AnnotationCreator;

		public bool _IteratorCreator;

		public bool m_InitializerCreator;

		public bool roleCreator;

		public bool factoryCreator;

		public bool attributeCreator;

		public bool m_EventCreator;

		public long _GlobalCreator;

		public long _WorkerCreator;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ExporterCreator, "SensorID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PrototypeCreator, "SensorType");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref comparatorCreator, "ComponentNumber");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref itemCreator, "ComponentID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref setterCreator, "DegOverride");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _CreatorCreator, "SB1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_TemplateCreator, "SB2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref mappingCreator, "SMF1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_MockCreator, "SMF2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref tagCreator, "SMA1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_FieldCreator, "SMA2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref queueCreator, "SS1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref regCreator, "SS2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ParamCreator, "PB1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_PageCreator, "PB2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref rulesCreator, "PMF1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _MethodCreator, "PMF2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ServiceCreator, "PMA1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _SystemCreator, "PMA2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _CandidateCreator, "PS1");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref baseCreator, "PS2");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref policyCreator, "DegOverrideMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref broadcasterCreator, "SB1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _IdentifierCreator, "SB2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _PrinterCreator, "SMF1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_ParserCreator, "SMF2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AlgoCreator, "SMA1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_DatabaseCreator, "SMA2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InterceptorCreator, "SS1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref messageCreator, "SS2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _ProductCreator, "PB1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _AnnotationCreator, "PB2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _IteratorCreator, "PMF1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_InitializerCreator, "PMF2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref roleCreator, "PMA1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref factoryCreator, "PMA2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref attributeCreator, "PS1Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_EventCreator, "PS2Max");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _GlobalCreator, "VerticalDegMax");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref _WorkerCreator, "MastHeight");
		}
	}

	private struct AlgoConfigObject : DBCache.I_CacheableRow
	{
		public long ID;

		public long m_AccountCreator;

		public long m_StateCreator;

		public void setValuesFromDataTableTyped(DataTableTyped dataTableTyped_0, DtrRow dtrRow_0)
		{
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref ID, "ID");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_AccountCreator, "Type");
			DBCache.SetValueIfDataTableHasFieldOfCorrectType(dataTableTyped_0, dtrRow_0, ref m_StateCreator, "Capacity");
		}
	}

	private struct ContainerRuleWatcher
	{
		public int ID;

		public string Name;

		public GlobalVariables.ArmorRating _AuthenticationCreator;

		public int _ParamsCreator;

		public int infoCreator;

		public int helperCreator;

		public int _MapperCreator;

		public float DamagePoints;

		public bool m_ManagerCreator;

		public bool _GetterCreator;

		public bool m_ProducerCreator;

		public float _ProcCreator;

		public bool m_StructMap;

		public bool _MerchantMap;

		public bool m_CallbackMap;

		public bool decoratorMap;

		public CargoType processMap;

		public float m_ThreadMap;

		public float m_RuleMap;

		public int _CollectionMap;

		public bool _InstanceMap;

		public IMobileGroundUnit._MobileUnitCategory _ObjectMap;
	}

	private static Dictionary<string, bool> _AlgoReader;

	private static Dictionary<string, bool> _DatabaseReader;

	[ThreadStatic]
	private static string _InterceptorReader;

	public static DatabaseCache CurrentDatabaseCache;

	private static ConcurrentDictionary<string, bool> m_MessageReader;

	[ThreadStatic]
	private static StringBuilder m_ProductReader;

	static DBFunctions()
	{
		_AlgoReader = new Dictionary<string, bool>();
		_DatabaseReader = new Dictionary<string, bool>();
		CurrentDatabaseCache = new DatabaseCache();
		m_MessageReader = new ConcurrentDictionary<string, bool>();
	}

	public static void GetPlatformLists(ref DataTable dataTable_0, ref DataTable dataTable_1, ref DataTable dataTable_2, ref DataTable dataTable_3, ref DataTable dataTable_4, ref DataTable dataTable_5, ref DataTable dataTable_6, ref SQLiteConnection sqliteConnection_0)
	{
		dataTable_0 = GetAllAircraft(sqliteConnection_0);
		dataTable_1 = GetAllShips(sqliteConnection_0);
		dataTable_2 = GetAllSubmarines(sqliteConnection_0);
		dataTable_3 = GetAllFacilities(sqliteConnection_0);
		dataTable_4 = GetAllGroundUnits(sqliteConnection_0);
		dataTable_6 = GetAllWeapons(sqliteConnection_0);
		try
		{
			dataTable_5 = GetAllSatellites(sqliteConnection_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200066", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool CheckObjectIsDeprecated(string string_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		bool result = false;
		try
		{
			if (CheckColumnExists_SQLite(string_0, "Deprecated", sqliteConnection_0))
			{
				string string_ = "Select Deprecated from " + string_0 + " WHERE ID=" + Conversions.ToString(int_0);
				string left = sQLiteHelper.SelectSpecification(string_);
				if (Operators.CompareString(left, "0", TextCompare: false) != 0 && Operators.CompareString(left, "False", TextCompare: false) != 0)
				{
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			result = false;
			return false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static bool CheckColumnExists_SQLite(string string_0, string string_1, SQLiteConnection sqliteConnection_0)
	{
		if (m_ProductReader == null)
		{
			m_ProductReader = new StringBuilder();
		}
		else
		{
			m_ProductReader.Clear();
		}
		m_ProductReader.Append(((DbConnection)sqliteConnection_0).ConnectionString).Append("_").Append(string_0)
			.Append("_")
			.Append(string_1);
		if (m_MessageReader.TryGetValue(m_ProductReader.ToString(), out var value))
		{
			return value;
		}
		value = false;
		if (sqliteConnection_0.State != ConnectionState.Open)
		{
			sqliteConnection_0.Open();
		}
		SQLiteDataReader val = new SQLiteCommand("PRAGMA table_info('" + string_0 + "')", sqliteConnection_0).ExecuteReader();
		while (((DbDataReader)val).Read())
		{
			object objectValue = RuntimeHelpers.GetObjectValue(((DbDataReader)val).GetValue(1));
			if (string_1.Equals(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				((DbDataReader)val).Close();
				value = true;
				break;
			}
		}
		((DbDataReader)val).Close();
		m_MessageReader.TryAdd(m_ProductReader.ToString(), value);
		return value;
	}

	public static DataTable GetAllAircraft(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable result = null;
		try
		{
			string text = "Select DataAircraft.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Type, PhysicalSizeCode as Size, RunwayLengthCode as RunwaySizeNeeded";
			if (CheckColumnExists_SQLite("DataAircraft", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated";
			}
			text += " From DataAircraft, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataAircraft.OperatorCountry And EOS.ID = DataAircraft.OperatorService And Type > 1001 ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			if (!CheckFeatureCompatibility(0, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			DBOps.DBHasLegacyRunwayLengthEnum = sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumAircraftRunwayLength");
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static DataTable GetAllShips(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		DataTable result = null;
		try
		{
			string text = "Select DataShip.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Length, PhysicalSizeCode, Type ";
			if (CheckColumnExists_SQLite("DataShip", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated";
			}
			text += " From DataShip, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataShip.OperatorCountry And EOS.ID = DataShip.OperatorService And Type > 1001 Order By Name, EOC.Description, EOS.Description, YearCommissioned";
			if (!CheckFeatureCompatibility(0, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static DataTable GetAllSubmarines(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string text = "Select DataSubmarine.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Length, PhysicalSizeCode, Type ";
		if (CheckColumnExists_SQLite("DataSubmarines", "Deprecated", sqliteConnection_0))
		{
			text += ", Deprecated";
		}
		text += " From DataSubmarine, EnumOperatorCountry As EOC, EnumOperatorService As EOS Where EOC.ID = DataSubmarine.OperatorCountry And EOS.ID = DataSubmarine.OperatorService And Type > 1001 Order By Name, EOC.Description, EOS.Description, YearCommissioned";
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			text = text.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllFacilities(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataFacility.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END");
		GameGeneral.ThreadStaticSB.Append(" || ");
		GameGeneral.ThreadStaticSB.Append(" CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END");
		GameGeneral.ThreadStaticSB.Append(" as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category from DataFacility, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataFacility.OperatorCountry and EOS.ID = DataFacility.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned");
		if (CheckColumnExists_SQLite("DataFacility", "Deprecated", sqliteConnection_0))
		{
			GameGeneral.ThreadStaticSB.Append(" AND Deprecated=0 ");
		}
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			GameGeneral.ThreadStaticSB.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString());
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllGroundUnits(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			string text = "SELECT DataGroundUnit.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName , OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Category, Length from DataGroundUnit, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EOC.ID = DataGroundUnit.OperatorCountry and EOS.ID = DataGroundUnit.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			if (!CheckFeatureCompatibility(0, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			return datatable;
		}
		return new DataTable();
	}

	public static DataTable GetAllSatellites(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		DataTable result = null;
		try
		{
			string text = "SELECT DataSatellite.ID, Name, Name || ' -- ' || EOC.Description || ' (' || EOS.Description || ')' ||  CASE WHEN YearCommissioned = '0' AND YearDecommissioned = '0' THEN '' ELSE ', ' END ||  CASE WHEN YearCommissioned = '0' THEN '' ELSE YearCommissioned END ||  CASE WHEN YearDecommissioned = '0' THEN '' ELSE '-' || YearDecommissioned END ||  CASE WHEN Comments = '-' THEN '' ELSE ', ' || Comments END as LongName, EnumSatelliteType.Description as TypeString, OperatorCountry, EOC.Description as CountryString, YearCommissioned, YearDecommissioned, Hypothetical, Type ";
			if (CheckColumnExists_SQLite("DataSatellite", "Deprecated", sqliteConnection_0))
			{
				text += ", Deprecated ";
			}
			text += " from DataSatellite, EnumSatelliteType, EnumOperatorCountry as EOC, EnumOperatorService as EOS where EnumSatelliteType.ID = DataSatellite.Type and EOC.ID = DataSatellite.OperatorCountry and EOS.ID = DataSatellite.OperatorService ORDER BY Name, EOC.Description, EOS.Description, YearCommissioned";
			if (!CheckFeatureCompatibility(0, sqliteConnection_0))
			{
				text = text.Replace(", Hypothetical", "");
			}
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
			if (!datatable.Columns.Contains("Hypothetical"))
			{
				DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
				dataColumn.DefaultValue = "0";
				datatable.Columns.Add(dataColumn);
			}
			result = datatable;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static DataTable GetAllWeapons(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string text = "SELECT ID, Name, Name ||  CASE WHEN Comments = '-' THEN '' ELSE ' -- ' || Comments END as LongName, Type, Hypothetical ";
		if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
		{
			text += ", Deprecated ";
		}
		text += "from DataWeapon where Type > 1001";
		if (!CheckFeatureCompatibility(0, sqliteConnection_0))
		{
			text = text.Replace(", Hypothetical", "");
		}
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
		if (!datatable.Columns.Contains("Hypothetical"))
		{
			DataColumn dataColumn = new DataColumn("Hypothetical", typeof(short));
			dataColumn.DefaultValue = "0";
			datatable.Columns.Add(dataColumn);
		}
		return datatable;
	}

	public static DataTable GetAllCommDevices(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT ID, Name || ' (' || Comments || ')' as Name, (select description from enumcommtype where id = type) as Type from DataComm";
		return DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
	}

	public static DataTable GetOrbitsForThisSatellite(int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "Select * from DataSatelliteOrbits where ID=" + Conversions.ToString(int_0) + " AND Operational <>0";
		return DBCache.GetDatatable(sqliteHelper_, string_);
	}

	public static string GetSatelliteName(int int_0, int int_1, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "Select MissionName from DataSatelliteOrbits where ID=" + Conversions.ToString(int_0) + " and ComponentNumber=" + Conversions.ToString(int_1);
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static DataTable GetAllCountries(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT ID, Description from EnumOperatorCountry ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ";
		return DBCache.GetDatatable(sqliteHelper_, string_);
	}

	public static DataTable GetAllAirFacilities(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "Select * from DataAircraftFacility";
		return DBCache.GetDatatable(sqliteHelper_, string_);
	}

	public static DataTable GetAllDockFacilities(SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "Select * from DataDockingFacility";
		return DBCache.GetDatatable(sqliteHelper_, string_);
	}

	public static int EW_GetNumberOfBasicVariants(List<int> list_0, GlobalVariables.ActiveUnitType activeUnitType_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			break;
		}
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT COUNT(DISTINCT Name) FROM " + text + " where ID in (" + string.Join(",", list_0.ToArray()) + ")";
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_));
	}

	public static List<int> EW_GetAllUnitsMatchingTheseEmissions(List<int> list_0, GlobalVariables.ActiveUnitType activeUnitType_0, Scenario scenario_0, SQLiteConnection sqliteConnection_0)
	{
		try
		{
			List<int> list = new List<int>();
			if (list_0.Count == 0)
			{
				return list;
			}
			list_0 = list_0.OrderBy((int theInt) => theInt).ToList();
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
			string string_ = "EmitterIDs_" + activeUnitType_0.ToString() + "_" + string.Join("_", list_0);
			object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sqliteHelper_, string_));
			if (objectValue == null)
			{
				new List<int>();
				DataTable dataTable = null;
				int count = list_0.Count;
				switch (activeUnitType_0)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					dataTable = GetAllAircraft(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					dataTable = GetAllShips(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					dataTable = GetAllSubmarines(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					dataTable = GetAllFacilities(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					dataTable = GetAllWeapons(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					dataTable = GetAllSatellites(sqliteConnection_0);
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					dataTable = GetAllGroundUnits(sqliteConnection_0);
					break;
				}
				IEnumerator enumerator = null;
				try
				{
					enumerator = dataTable.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						int num = Conversions.ToInteger(((DataRow)enumerator.Current)["ID"]);
						List<int> second = EW_GetAllPossibleEmissionsForThisUnit(activeUnitType_0, num, scenario_0.DBConnection);
						if (list_0.Intersect(second).Count() == count)
						{
							list.Add(num);
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
				DBCache.SetCustomObject(sqliteHelper_, string_, list);
				return list;
			}
			return (List<int>)objectValue;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101082", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<int> result = new List<int>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static List<int> EW_GetAllPossibleEmissionsForThisUnit(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string value = "";
		HashSet<int> value2 = new HashSet<int>();
		SQLiteHelper sQLiteHelper = null;
		try
		{
			switch (activeUnitType_0)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				text = "DataAircraftSensors";
				value = "DataAircraftMounts";
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				text = "DataShipSensors";
				value = "DataShipMounts";
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				text = "DataSubmarineSensors";
				value = "DataSubmarineMounts";
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				text = "DataFacilitySensors";
				value = "DataFacilityMounts";
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				text = "DataWeaponSensors";
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				text = "DataSatelliteSensors";
				value = "DataSatelliteMounts";
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
				text = "DataGroundUnitSensors";
				value = "DataGroundUnitMounts";
				break;
			}
			string key = text + "_" + Conversions.ToString(int_0);
			if (CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryGetValue(key, out value2))
			{
				return new List<int>(value2);
			}
			if (value2 == null)
			{
				value2 = new HashSet<int>();
			}
			sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, ").Append(text).Append(" as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ")
				.Append(int_0);
			foreach (DtrRow row in DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString()).Rows)
			{
				if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row["SensorType"])))
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["MasqueradeAs"])) && Conversions.ToInteger(row["MasqueradeAs"]) != 1001)
					{
						value2.Add(Conversions.ToInteger(row["MasqueradeAs"]));
					}
					else
					{
						value2.Add(Conversions.ToInteger(row["SensorID"]));
					}
				}
			}
			GameGeneral.ThreadStaticSB.Clear();
			if (!string.IsNullOrEmpty(value))
			{
				GameGeneral.ThreadStaticSB.Append("SELECT DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, DataMountSensors, ").Append(value).Append(" where DataSensor.ID = DataMountSensors.ComponentID and DataMountSensors.ID = ")
					.Append(value)
					.Append(".ComponentID and ")
					.Append(value)
					.Append(".ID = ")
					.Append(int_0);
				foreach (DtrRow row2 in DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString()).Rows)
				{
					if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row2["SensorType"])))
					{
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["MasqueradeAs"])) && Conversions.ToInteger(row2["MasqueradeAs"]) != 1001)
						{
							value2.Add(Conversions.ToInteger(row2["MasqueradeAs"]));
						}
						else
						{
							value2.Add(Conversions.ToInteger(row2["SensorID"]));
						}
					}
				}
			}
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("SELECT DataSensor.ID as SensorID, DataSensor.Type as SensorType, DataSensor.MasqueradeAs from DataSensor, DataSensorSensorGroups, ").Append(text).Append(" where ")
				.Append(text)
				.Append(".ID = ")
				.Append(int_0)
				.Append(" And DataSensorSensorGroups.ID = ")
				.Append(text)
				.Append(".ComponentID And DataSensor.ID = DataSensorSensorGroups.ComponentID");
			foreach (DtrRow row3 in DBCache.GetDatatableTyped(sQLiteHelper, GameGeneral.ThreadStaticSB.ToString()).Rows)
			{
				if (Misc.HasActiveMode((Sensor.Sensor_Type)Conversions.ToShort(row3["SensorType"])))
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["MasqueradeAs"])) && Conversions.ToInteger(row3["MasqueradeAs"]) != 1001)
					{
						value2.Add(Conversions.ToInteger(row3["MasqueradeAs"]));
					}
					else
					{
						value2.Add(Conversions.ToInteger(row3["SensorID"]));
					}
				}
			}
			CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit.TryAdd(key, value2);
			return new List<int>(value2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (sQLiteHelper != null && (sQLiteHelper.theConnection == null || ((DbConnection)sQLiteHelper.theConnection).State != ConnectionState.Open))
			{
				throw;
			}
			exception_?.Data.Add("Error at 200067", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<int> result = value2.ToList();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static int GetActiveUnitIDByName(string string_0, GlobalVariables.ActiveUnitType activeUnitType_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "";
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			string_ = "SELECT ID FROM DataAircraft where Name = '" + string_0 + "'";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			string_ = "SELECT ID FROM DataShip where Name = '" + string_0 + "'";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			string_ = "SELECT ID FROM DataSubmarine where Name = '" + string_0 + "'";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			string_ = "SELECT ID FROM DataFacility where Name = '" + string_0 + "'";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			string_ = "SELECT ID FROM DataWeapon where Name = '" + string_0 + "'";
			break;
		}
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_));
	}

	public static string GetActiveUnitName(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		string result = "(error)";
		string text;
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		default:
			return result;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			break;
		}
		string string_ = "Select Name from " + text + " where ID=" + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(new SQLiteHelper(sqliteConnection_0), string_);
		if (datatable.Rows.Count > 0)
		{
			result = datatable.Rows[0]["Name"].ToString();
		}
		return result;
	}

	public static List<float> GetEngineDetails(int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		List<float> list = new List<float>();
		try
		{
			string string_ = "Select NumberOfEngines, ThrustPerEngineMilitary, ThrustPerEngineAfterburner, SFCMilitary, SFCAfterburner from DataPropulsion where ID=" + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
			if (datatable.Rows.Count == 0)
			{
				return list;
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					list.Add(Conversions.ToSingle(dataRow["NumberOfEngines"]));
					list.Add(Conversions.ToSingle(dataRow["ThrustPerEngineMilitary"]));
					list.Add(Conversions.ToSingle(dataRow["ThrustPerEngineAfterburner"]));
					list.Add(Conversions.ToSingle(dataRow["SFCMilitary"]));
					list.Add(Conversions.ToSingle(dataRow["SFCAfterburner"]));
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200068", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public static List<float> GetTorpedoKinematicRange(int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		List<float> list = new List<float>();
		try
		{
			string string_ = "Select TorpedoSpeedCruise, TorpedoRangeCruise, TorpedoSpeedFull, TorpedoRangeFull from DataWeapon where ID=" + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
			if (datatable.Rows.Count == 0)
			{
				return list;
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					list.Add(Conversions.ToSingle(dataRow["TorpedoSpeedCruise"]));
					list.Add(Conversions.ToSingle(dataRow["TorpedoRangeCruise"]));
					list.Add(Conversions.ToSingle(dataRow["TorpedoSpeedFull"]));
					list.Add(Conversions.ToSingle(dataRow["TorpedoRangeFull"]));
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200069", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public static void smethod_0(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, SQLiteConnection sqliteConnection_0, ref int int_1, ref int int_2, ref int int_3)
	{
		if (activeUnitType_0 == GlobalVariables.ActiveUnitType.Weapon)
		{
			return;
		}
		string text = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			break;
		}
		try
		{
			_InterceptorReader = "SELECT OODADetectionCycle, OODATargetingCycle, OODAEvasiveCycle FROM " + text + " where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					int_1 = Conversions.ToInteger(dataRow["OODADetectionCycle"]);
					int_2 = Conversions.ToInteger(dataRow["OODATargetingCycle"]);
					int_3 = Conversions.ToInteger(dataRow["OODAEvasiveCycle"]);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_InterceptorReader = "SELECT  OODATargetingCycle, OODAEvasiveCycle FROM " + text + " where ID = " + Conversions.ToString(int_0);
			DataTable datatable2 = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = datatable2.Rows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow dataRow2 = (DataRow)enumerator2.Current;
					int_1 = 15;
					int_2 = Conversions.ToInteger(dataRow2["OODATargetingCycle"]);
					int_3 = Conversions.ToInteger(dataRow2["OODAEvasiveCycle"]);
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			ProjectData.ClearProjectError();
		}
	}

	public static List<string> GetUnitFlagDescriptions(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string text2 = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		List<string> list = new List<string>();
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftCodes";
			text2 = "EnumAircraftCode";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipCodes";
			text2 = "EnumShipCode";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineCodes";
			text2 = "EnumSubmarineCode";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeaponCodes";
			text2 = "EnumWeaponCode";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatelliteCodes";
			text2 = "EnumSatelliteCode";
			break;
		}
		_InterceptorReader = "SELECT EC.* from " + text2 + " as EC, " + text + " as DC where EC.ID = DC.CodeID and DC.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			return list;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				list.Add(Conversions.ToString(dataRow["Description"]));
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

	internal static string Description(CommDevice.CommLinkType commLinkType_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string string_ = "Select Description from EnumCommType where ID=" + Conversions.ToString((int)commLinkType_0);
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static string Description(XSection._SignatureType _SignatureType_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string string_ = "Select Description from EnumSignatureType where ID=" + Conversions.ToString((int)_SignatureType_0);
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) ConcatList(ref Scenario scenario_0, int int_0, bool bool_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumAircraftCockpitGen"))
		{
			_InterceptorReader = "Select * from EnumAircraftCockpitGen where ID = " + Conversions.ToString(int_0);
			DataRow dataRow = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader).Rows[0];
			string item;
			if (dataRow["Description"] is string)
			{
				item = Conversions.ToString(dataRow["Description"]);
			}
			else
			{
				item = "";
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			string item2;
			if (dataRow["Example"] is string)
			{
				item2 = Conversions.ToString(dataRow["Example"]);
			}
			else
			{
				item2 = "";
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			if (short.TryParse(dataRow["OODADetectionCycle"].ToString(), out var result))
			{
				result = Conversions.ToShort(dataRow["OODADetectionCycle"]);
			}
			else
			{
				result = 0;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			if (short.TryParse(dataRow["OODATargetingCycle"].ToString(), out var result2))
			{
				result2 = Conversions.ToShort(dataRow["OODATargetingCycle"]);
			}
			else
			{
				result2 = 0;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			if (short.TryParse(dataRow["OODAEvasiveCycle"].ToString(), out var result3))
			{
				result3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"]);
			}
			else
			{
				result3 = 0;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			return (Description: item, Example: item2, OODA_Detection: result, OODA_Targeting: result2, OODA_Evasion: result3);
		}
		return (Description: string.Empty, Example: string.Empty, OODA_Detection: 0, OODA_Targeting: 0, OODA_Evasion: 0);
	}

	public static void GetAircraft(ref Scenario scenario_0, ref Aircraft aircraft_0, int int_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataAircraft where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No aircraft with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		DataRow dataRow = datatable.Rows[0];
		if (datatable.Columns.Contains("CockpitGen") && Conversions.ToInteger(dataRow["CockpitGen"]) > 0)
		{
			aircraft_0.CockpitGen = Conversions.ToInteger(dataRow["CockpitGen"]);
			(string, string, short, short, short) tuple = ConcatList(ref scenario_0, aircraft_0.CockpitGen, bool_0: false);
			aircraft_0.m_TokenVal = tuple.Item3;
			aircraft_0._IndexerVal = tuple.Item4;
			aircraft_0._ResolverVal = tuple.Item5;
		}
		else
		{
			if (!datatable.Columns.Contains("OODADetectionCycle"))
			{
				datatable.Columns.Add("OODADetectionCycle", typeof(string));
				dataRow["OODADetectionCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODATargetingCycle"))
			{
				datatable.Columns.Add("OODATargetingCycle", typeof(string));
				dataRow["OODATargetingCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODAEvasiveCycle"))
			{
				datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
				dataRow["OODAEvasiveCycle"] = 0;
			}
		}
		aircraft_0.Category = (Aircraft._AircraftCategory)Conversions.ToShort(dataRow["Category"]);
		aircraft_0.Type = (Aircraft._AircraftType)Conversions.ToInteger(dataRow["Type"]);
		aircraft_0.DBID = int_0;
		aircraft_0.UnitClass = Strings.Trim(Conversions.ToString(dataRow["Name"]));
		aircraft_0.Kinematics.SetClimbRate_Nominal(bool_0: true, Conversions.ToSingle(dataRow["ClimbRate"].ToString()));
		aircraft_0.Agility_Nominal = Conversions.ToSingle(dataRow["Agility"].ToString());
		aircraft_0.Length = Conversions.ToSingle(dataRow["Length"].ToString());
		aircraft_0.EmptyWeight = Conversions.ToInteger(dataRow["WeightEmpty"].ToString());
		aircraft_0.MaxWeight = Conversions.ToInteger(dataRow["WeightMax"].ToString());
		aircraft_0.MaxPayloadWeight = Conversions.ToInteger(dataRow["WeightPayload"].ToString());
		aircraft_0.Span = Conversions.ToSingle(dataRow["Span"].ToString());
		aircraft_0.Height = Conversions.ToSingle(dataRow["Height"].ToString());
		aircraft_0.Crew = Conversions.ToInteger(dataRow["Crew"].ToString());
		aircraft_0.TotalEndurance = Conversions.ToInteger(dataRow["TotalEndurance"].ToString());
		aircraft_0.Category = (Aircraft._AircraftCategory)Conversions.ToShort(dataRow["Category"]);
		aircraft_0.RunwayLengthNeeded = InsertList(Conversions.ToInteger(dataRow["RunwayLengthCode"]));
		int num = Conversions.ToInteger(dataRow["PhysicalSizeCode"]);
		aircraft_0.Size = PrepareList(num);
		if (aircraft_0.Size == GlobalVariables.AircraftSizeClass.None && num != 1001 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (datatable.Columns.Contains("DamagePoints") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["DamagePoints"])) && Conversions.ToInteger(dataRow["DamagePoints"]) != 0)
		{
			aircraft_0.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			aircraft_0.SetDamagePts(bool_1: true, null, aircraft_0.InitialDP);
		}
		else if (aircraft_0.IsAerostat)
		{
			aircraft_0.InitialDP = Aircraft.smethod_0((int)Math.Round(aircraft_0.Length));
			aircraft_0.SetDamagePts(bool_1: true, null, aircraft_0.InitialDP);
		}
		else
		{
			switch (aircraft_0.Size)
			{
			case GlobalVariables.AircraftSizeClass.Small:
				aircraft_0.InitialDP = 3;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
				aircraft_0.InitialDP = 1;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
				aircraft_0.InitialDP = 2;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
			case GlobalVariables.AircraftSizeClass.UAS_Class2:
				aircraft_0.InitialDP = 3;
				break;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case GlobalVariables.AircraftSizeClass.VLarge:
				aircraft_0.InitialDP = 20;
				break;
			case GlobalVariables.AircraftSizeClass.Large:
				aircraft_0.InitialDP = 10;
				break;
			case GlobalVariables.AircraftSizeClass.Medium:
				aircraft_0.InitialDP = 5;
				break;
			}
			aircraft_0.SetDamagePts(bool_1: true, null, aircraft_0.InitialDP);
		}
		if (datatable.Columns.Contains("Visibility"))
		{
			scenario_0.FeatureCompatibility.CockpitVisibility = true;
			try
			{
				string[] array = (dataRow["Visibility"].ToString().Contains(",") ? dataRow["Visibility"].ToString().Split(Conversions.ToCharArrayRankOne(",")) : dataRow["Visibility"].ToString().Split(Conversions.ToCharArrayRankOne(".")));
				switch (array[0])
				{
				case "C":
					aircraft_0.VisibilityForward = Aircraft.CockpitVisibility.Poor;
					break;
				case "B":
					aircraft_0.VisibilityForward = Aircraft.CockpitVisibility.Average;
					break;
				case "A":
					aircraft_0.VisibilityForward = Aircraft.CockpitVisibility.Excellent;
					break;
				}
				switch (array[1])
				{
				case "C":
					aircraft_0.VisibilitySideways = Aircraft.CockpitVisibility.Poor;
					break;
				case "B":
					aircraft_0.VisibilitySideways = Aircraft.CockpitVisibility.Average;
					break;
				case "A":
					aircraft_0.VisibilitySideways = Aircraft.CockpitVisibility.Excellent;
					break;
				}
				switch (array[2])
				{
				case "C":
					aircraft_0.VisibilityAft = Aircraft.CockpitVisibility.Poor;
					break;
				case "B":
					aircraft_0.VisibilityAft = Aircraft.CockpitVisibility.Average;
					break;
				case "A":
					aircraft_0.VisibilityAft = Aircraft.CockpitVisibility.Excellent;
					break;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (datatable.Columns.Contains("FuelOffloadRate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelOffloadRate"])))
		{
			aircraft_0.accountWrapper = Conversions.ToSingle(dataRow["FuelOffloadRate"]);
		}
		if (datatable.Columns.Contains("AircraftEngineArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftEngineArmor"])))
		{
			aircraft_0.Armor_Powerplant = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftEngineArmor"]);
		}
		else
		{
			aircraft_0.Armor_Powerplant = GlobalVariables.ArmorRating.None;
		}
		if (datatable.Columns.Contains("AircraftCockpitArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftCockpitArmor"])))
		{
			aircraft_0.Armor_Cockpit = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftCockpitArmor"]);
		}
		else
		{
			aircraft_0.Armor_Cockpit = GlobalVariables.ArmorRating.None;
		}
		if (datatable.Columns.Contains("AircraftFuselageArmor") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AircraftFuselageArmor"])))
		{
			aircraft_0.Armor_Fuselage = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["AircraftFuselageArmor"]);
		}
		else
		{
			aircraft_0.Armor_Fuselage = GlobalVariables.ArmorRating.None;
		}
		aircraft_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
		aircraft_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
		aircraft_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
		aircraft_0.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
		try
		{
			aircraft_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		Aircraft aircraft_ = aircraft_0;
		GetAircraftFlags(ref aircraft_, int_0);
		if (bool_0)
		{
			PopulateSensors(aircraft_0, int_0);
			PopulateComms(aircraft_0, int_0);
			ActiveUnit activeUnit_ = aircraft_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
			PopulatePropulsion(aircraft_0, int_0);
			PopulateFuel(aircraft_0, int_0);
		}
	}

	public static int GetAircraftType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Type from DataAircraft where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetAircraftType_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumAircraftType where ID = (Select Type from DataAircraft Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static int GetShipType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Type from DataShip where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetShipType_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumShipType where ID = (Select Type from DataShip Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static int GetSubmarineType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Type from DataSubmarine where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetSubmarineType_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumSubmarineType where ID = (Select Type from DataSubmarine Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string GetFacilityName(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT Name from DataFacility where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static int GetFacilityType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Category from DataFacility where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static int GetSatelliteType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Type from DataSatellite where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetSatelliteType_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumSatelliteType where ID = (Select Type from DataSatellite Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static int GetWeaponType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Type from DataWeapon where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetWeaponType_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumWeaponType where ID = (Select Type from DataWeapon Where ID = " + Conversions.ToString(int_0) + ")";
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string Get_WRA_WeaponTargetType_WeaponQty_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumWeaponWRAWeaponQty where ID = " + Conversions.ToString(int_0);
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string Get_WRA_WeaponTargetType_ShooterQty_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumWeaponWRAShooterQty where ID = " + Conversions.ToString(int_0);
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string Get_WRA_WeaponTargetType_SelfDefenceRange_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumWeaponWRASelfDefenceRange where ID = " + Conversions.ToString(int_0);
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string Get_Sensor_Generation_String(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Description from EnumSensorGeneration where ID = " + Conversions.ToString(int_0);
		return DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader);
	}

	public static string Get_Sensor_Type_String(ref SQLiteConnection sqliteConnection_0, int int_0)
	{
		string string_ = "Select Description from EnumSensorType where ID = " + Conversions.ToString(int_0);
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), string_);
	}

	public static string GetFacilityType_String(ref Scenario scenario_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string @string = DBCache.GetString(sqliteHelper_, "FacilityType_" + Conversions.ToString(int_0));
		if (string.IsNullOrEmpty(@string))
		{
			_InterceptorReader = "Select Name, Category from Datafacility where ID = " + Conversions.ToString(int_0);
			DataRow dataRow = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader).Rows[0];
			Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(dataRow["Category"]);
			string text = (((uint)(facilityCategory - 5001) <= 1u) ? Facility.MobileUnitCategory(dataRow["Name"].ToString()).ToString() : facilityCategory.ToString());
			DBCache.SetString(sqliteHelper_, "FacilityType_" + Conversions.ToString(int_0), text);
			return text;
		}
		return @string;
	}

	public static string GetGroundUnitType_String(ref Scenario scenario_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string @string = DBCache.GetString(sqliteHelper_, "GroundUnitType_" + Conversions.ToString(int_0));
		if (string.IsNullOrEmpty(@string))
		{
			_InterceptorReader = "Select Name, Category from DataGroundUnit where ID = " + Conversions.ToString(int_0);
			string text = Misc.ToEnglishString((IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(DBCache.GetDatatable(sqliteHelper_, _InterceptorReader).Rows[0]["Category"]));
			DBCache.SetString(sqliteHelper_, "GroundUnitType_" + Conversions.ToString(int_0), text);
			return text;
		}
		return @string;
	}

	public static string GetCargoContainerName(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT Name from DataContainer where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static void GetAircraftFlags(ref Aircraft aircraft_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(aircraft_0.ParentScen.DBConnection);
		_InterceptorReader = "Select * from DataAircraftCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			switch (Conversions.ToInteger(dataRow["CodeID"]))
			{
			case 5002:
				aircraft_0.bool_0 = true;
				break;
			case 4001:
				aircraft_0.SuperManouverable = true;
				break;
			case 6012:
				aircraft_0.NightNavigationAttackCapable = true;
				break;
			case 6011:
				aircraft_0.NightNavigationCapable = true;
				break;
			case 5999:
				aircraft_0.LandCoverMaskingCapability = true;
				break;
			case 6001:
				aircraft_0.TerrainAvoidanceCapability = true;
				break;
			case 6002:
				aircraft_0.TerrainFollowingCapability = true;
				break;
			case 6003:
				aircraft_0.FlyByWire = true;
				break;
			case 6004:
				aircraft_0.HasBlipEnhancer = true;
				break;
			case 8001:
				aircraft_0.ProbeRefuelling = true;
				break;
			case 7010:
				aircraft_0.HasHelmetMountedSight = true;
				break;
			case 7001:
				aircraft_0.BombSightTech = Aircraft._BombsightTech.Basic;
				break;
			case 7002:
				aircraft_0.BombSightTech = Aircraft._BombsightTech.Ballistic;
				break;
			case 7003:
				aircraft_0.BombSightTech = Aircraft._BombsightTech.Computing;
				break;
			case 7004:
				aircraft_0.BombSightTech = Aircraft._BombsightTech.Advanced;
				break;
			case 9001:
				aircraft_0.CenterlineDrogue = true;
				break;
			case 9002:
				aircraft_0.WingDrogue = true;
				break;
			case 9003:
				aircraft_0.CenterlineBoom = true;
				break;
			case 8002:
				aircraft_0.BoomRefuelling = true;
				break;
			case 9101:
			case 9102:
			case 9103:
			case 9104:
			case 9111:
			case 9112:
			case 9113:
			case 9114:
			case 9121:
			case 9122:
			case 9123:
			case 9124:
			case 9185:
			case 9186:
			case 9191:
			case 9192:
			case 9199:
				aircraft_0.FuselageStructure = (Aircraft._AircraftFuselageStructure)Conversions.ToInteger(dataRow["CodeID"]);
				break;
			case 10102:
				aircraft_0.RCSS_ExposedFanBlockers = true;
				break;
			case 10101:
				aircraft_0.RCSS_SShapedIntakes = true;
				break;
			case 10001:
				aircraft_0.RCSS_ActiveCancellation = true;
				break;
			default:
				_ = Debugger.IsAttached;
				break;
			case 11201:
				aircraft_0.IRSS_PeakTempReduction = true;
				break;
			case 11101:
				aircraft_0.IRSS_ShieldedExhaustAntiStrela = true;
				break;
			case 11102:
				aircraft_0.IRSS_MaskedExhaust = true;
				break;
			case 11103:
				aircraft_0.IRSS_MaskedExhaust_Slit = true;
				break;
			case 10201:
				aircraft_0.RCCS_StealthPylons = true;
				break;
			}
		}
	}

	public static string GetLoadoutWeaponStateDescription(int int_0, int int_1, ref SQLiteConnection sqliteConnection_0, Scenario scenario_0, bool bool_0, Loadout.LoadoutRole loadoutRole_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		if (bool_0)
		{
			_InterceptorReader = "Select EnumLoadoutWinchesterShotgun.Description from EnumLoadoutWinchesterShotgun where EnumLoadoutWinchesterShotgun.ID = " + Conversions.ToString(int_1);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			if (datatable.Rows.Count <= 0)
			{
				return "Winchester: Mission-specific weapons have been expended. Disengage immediately.";
			}
			return datatable.Rows[0]["Description"].ToString();
		}
		return Aircraft.LoadoutWeaponStateDescirption(int_0, int_1, loadoutRole_0, scenario_0);
	}

	public static AircraftMissionProfile GetLoadoutMissionProfile(int int_0, ref SQLiteConnection sqliteConnection_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT DefaultMissionProfile from DataLoadout where ID=" + Conversions.ToString(int_0);
		return GetAircraftMissionProfile(Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, _InterceptorReader)), ref sqliteConnection_0, scenario_0);
	}

	public static AircraftMissionProfile GetAircraftMissionProfile(int int_0, ref SQLiteConnection sqliteConnection_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		DataTable datatable;
		try
		{
			if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
			{
				_InterceptorReader = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeIngressTerrainFollowing, CruiseAltitudeEgress, CruiseAltitudeEgressTerrainFollowing, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeIngressTerrainFollowing, AttackAltitudeEgress, AttackAltitudeEgressTerrainFollowing, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationAltitudeTerrainFollowing, StationThrottleSetting, ReservePercentage, ReserveLoiterTime, ReserveLoiterAltitude from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(int_0);
			}
			else
			{
				_InterceptorReader = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeEgress, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeEgress, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationThrottleSetting, ReservePercentage, ReserveLoiterTime, ReserveLoiterAltitude from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(int_0);
			}
			datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_InterceptorReader = "Select Description, FormUpTime, FormUpAltitude, CruiseAltitudeIngress, CruiseAltitudeEgress, CruiseThrottleSettingIngress, CruiseThrottleSettingEgress, CruiseOneWayOnly, CruiseAtOptimumAltitude, AttackAltitudeIngress, AttackAltitudeEgress, AttackThrottleSetting, AttackDistanceIngress, AttackDistanceEgress, DropBombsAtMaxRange, StationAltitude, StationThrottleSetting, ReservePercentage from EnumLoadoutMissionProfile where ID = " + Conversions.ToString(int_0);
			datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			ProjectData.ClearProjectError();
		}
		AircraftMissionProfile aircraftMissionProfile = new AircraftMissionProfile();
		if (datatable.Rows.Count == 0)
		{
			return null;
		}
		DataRow dataRow = datatable.Rows[0];
		aircraftMissionProfile.DBID = (short)int_0;
		aircraftMissionProfile.Description = Conversions.ToString(dataRow["Description"]);
		aircraftMissionProfile.FormUpTime = Conversions.ToInteger(dataRow["FormUpTime"]);
		aircraftMissionProfile.FormUpAltitude = (float)Conversions.ToInteger(dataRow["FormUpAltitude"]) / 3.28084f;
		aircraftMissionProfile.CruiseAltitudeIngress = (float)Conversions.ToInteger(dataRow["CruiseAltitudeIngress"]) / 3.28084f;
		aircraftMissionProfile.CruiseAltitudeEgress = (float)Conversions.ToInteger(dataRow["CruiseAltitudeEgress"]) / 3.28084f;
		aircraftMissionProfile.CruiseThrottleSettingIngress = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["CruiseThrottleSettingIngress"]);
		aircraftMissionProfile.CruiseThrottleSettingEgress = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["CruiseThrottleSettingEgress"]);
		aircraftMissionProfile.CruiseOneWayOnly = Conversions.ToBoolean(dataRow["CruiseOneWayOnly"]);
		aircraftMissionProfile.CruiseAtOptimumAltitude = Conversions.ToBoolean(dataRow["CruiseAtOptimumAltitude"]);
		aircraftMissionProfile.AttackAltitudeIngress = (float)Conversions.ToInteger(dataRow["AttackAltitudeIngress"]) / 3.28084f;
		aircraftMissionProfile.AttackAltitudeEgress = (float)Conversions.ToInteger(dataRow["AttackAltitudeEgress"]) / 3.28084f;
		aircraftMissionProfile.AttackThrottleSetting = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["AttackThrottleSetting"]);
		aircraftMissionProfile.AttackDistanceIngress = Conversions.ToInteger(dataRow["AttackDistanceIngress"]);
		aircraftMissionProfile.AttackDistanceEgress = Conversions.ToInteger(dataRow["AttackDistanceEgress"]);
		aircraftMissionProfile.DropBombsAtMaxRange = Conversions.ToBoolean(dataRow["DropBombsAtMaxRange"]);
		aircraftMissionProfile.StationAltitude = (float)Conversions.ToInteger(dataRow["StationAltitude"]) / 3.28084f;
		aircraftMissionProfile.StationThrottleSetting = (ActiveUnit.Throttle)Conversions.ToByte(dataRow["StationThrottleSetting"]);
		aircraftMissionProfile.ReservePercentage = Conversions.ToInteger(dataRow["ReservePercentage"]);
		if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
		{
			aircraftMissionProfile.CruiseAltitudeIngressTerrainFollowing = Conversions.ToBoolean(dataRow["CruiseAltitudeIngressTerrainFollowing"]);
			aircraftMissionProfile.CruiseAltitudeEgressTerrainFollowing = Conversions.ToBoolean(dataRow["CruiseAltitudeEgressTerrainFollowing"]);
			aircraftMissionProfile.AttackAltitudeIngressTerrainFollowing = Conversions.ToBoolean(dataRow["AttackAltitudeIngressTerrainFollowing"]);
			aircraftMissionProfile.AttackAltitudeEgressTerrainFollowing = Conversions.ToBoolean(dataRow["AttackAltitudeEgressTerrainFollowing"]);
			aircraftMissionProfile.StationAltitudeTerrainFollowing = Conversions.ToBoolean(dataRow["StationAltitudeTerrainFollowing"]);
		}
		else
		{
			aircraftMissionProfile.CruiseAltitudeIngressTerrainFollowing = false;
			aircraftMissionProfile.CruiseAltitudeEgressTerrainFollowing = false;
			aircraftMissionProfile.AttackAltitudeIngressTerrainFollowing = false;
			aircraftMissionProfile.AttackAltitudeEgressTerrainFollowing = false;
			aircraftMissionProfile.StationAltitudeTerrainFollowing = false;
		}
		if (datatable.Columns.Contains("ReserveLoiterTime"))
		{
			aircraftMissionProfile.ReserveLoiterTime = Conversions.ToInteger(dataRow["ReserveLoiterTime"]);
		}
		if (datatable.Columns.Contains("ReserveLoiterAltitude"))
		{
			aircraftMissionProfile.ReserveLoiterAltitude = (float)Conversions.ToInteger(dataRow["ReserveLoiterAltitude"]) / 3.28084f;
		}
		return aircraftMissionProfile;
	}

	public static Dictionary<int, int> GetSelectedAircraftTotalWeaponQty(List<Aircraft> list_0, ref SQLiteConnection sqliteConnection_0, ref bool bool_0)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (!bool_0 && !Information.IsNothing(list_0))
		{
			foreach (Aircraft item in list_0)
			{
				if (Information.IsNothing(item.Loadout))
				{
					continue;
				}
				DataTable dataTable = new DataTable();
				dataTable = ItemsForThisLoadout(item.Loadout.DBID, ref sqliteConnection_0, ref item.Loadout.NoOptionalWeapons);
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DataRow dataRow = dataTable.Rows[i];
					int num2 = Conversions.ToInteger(dataRow["ComponentID"]);
					if (!Weapon.WeaponIsNonRivalrous(num2, ref item.ParentScen))
					{
						if (dictionary.ContainsKey(num2))
						{
							dictionary[num2] += Conversions.ToInteger(dataRow["Quantity"]);
						}
						else
						{
							dictionary.Add(num2, Conversions.ToInteger(dataRow["Quantity"]));
						}
					}
				}
			}
			return dictionary;
		}
		return dictionary;
	}

	public static List<Loadout> LoadoutsForThisAircraft(int int_0, Scenario scenario_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		List<Loadout> list = new List<Loadout>();
		_InterceptorReader = "Select ComponentID from DataAircraftLoadouts where ID=" + Conversions.ToString(int_0);
		DataTable dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
		IEnumerator enumerator = null;
		try
		{
			enumerator = dataTable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				Loadout loadout = GetLoadout(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), bool_0: false, bool_1: false);
				list.Add(loadout);
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

	public static DataTable LoadoutsForThisAircraft_DT(int int_0, Dictionary<int, int> dictionary_0, ref SQLiteConnection sqliteConnection_0, Scenario scenario_0, ref bool bool_0, ref Scenario scenario_1, ref Aircraft aircraft_0, ref int int_1, ref bool bool_1)
	{
		if (!Information.IsNothing(aircraft_0) && Information.IsNothing(aircraft_0.AirOps.CurrentHostUnit))
		{
			return null;
		}
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		DataTable dataTable;
		if (int_1 <= 0)
		{
			if (scenario_1 == null)
			{
				if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
				{
					_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime, ReadyTime_Sustained, LoadoutRole, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
				}
				else
				{
					try
					{
						_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime, ReadyTime_Sustained, LoadoutRole, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
						dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, ReadyTime AS ReadyTime, LoadoutRole from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
						dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
			{
				_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
				dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
			}
			else
			{
				try
				{
					_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					_InterceptorReader = "SELECT DataLoadout.ID, DataLoadout.Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile from DataLoadout, DataAircraftLoadouts where DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataLoadout.Name ASC";
					dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
					ProjectData.ClearProjectError();
				}
			}
		}
		else if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
		{
			_InterceptorReader = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay, WinchesterShotgun from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_1);
			dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
		}
		else
		{
			try
			{
				_InterceptorReader = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, QuickTurnaround, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_MaxSorties, QuickTurnaround_AdditionalTimePenalty, QuickTurnaround_TimeofDay from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_1);
				dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				_InterceptorReader = "SELECT ID, Name, RequiresBuddyIllumination, LoadoutRole, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile from DataLoadout where DataLoadout.ID = " + Conversions.ToString(int_1);
				dataTable = sQLiteHelper.ComputeSpecification(_InterceptorReader);
				ProjectData.ClearProjectError();
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround"))
		{
			dataTable.Columns.Add("QuickTurnaround", typeof(string));
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((DataRow)enumerator.Current)["QuickTurnaround"] = 0;
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
		if (!dataTable.Columns.Contains("QuickTurnaround_ReadyTime"))
		{
			dataTable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = dataTable.Rows.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					((DataRow)enumerator5.Current)["QuickTurnaround_ReadyTime"] = 0;
				}
			}
			finally
			{
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_MaxSorties"))
		{
			dataTable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
			IEnumerator enumerator6 = null;
			try
			{
				enumerator6 = dataTable.Rows.GetEnumerator();
				while (enumerator6.MoveNext())
				{
					((DataRow)enumerator6.Current)["QuickTurnaround_MaxSorties"] = 0;
				}
			}
			finally
			{
				if (enumerator6 is IDisposable)
				{
					(enumerator6 as IDisposable).Dispose();
				}
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
		{
			dataTable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
			IEnumerator enumerator7 = null;
			try
			{
				enumerator7 = dataTable.Rows.GetEnumerator();
				while (enumerator7.MoveNext())
				{
					((DataRow)enumerator7.Current)["QuickTurnaround_AdditionalTimePenalty"] = 0;
				}
			}
			finally
			{
				if (enumerator7 is IDisposable)
				{
					(enumerator7 as IDisposable).Dispose();
				}
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_AirborneTime"))
		{
			dataTable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
			IEnumerator enumerator8 = null;
			try
			{
				enumerator8 = dataTable.Rows.GetEnumerator();
				while (enumerator8.MoveNext())
				{
					((DataRow)enumerator8.Current)["QuickTurnaround_AirborneTime"] = 0;
				}
			}
			finally
			{
				if (enumerator8 is IDisposable)
				{
					(enumerator8 as IDisposable).Dispose();
				}
			}
		}
		if (!dataTable.Columns.Contains("QuickTurnaround_TimeofDay"))
		{
			dataTable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
			IEnumerator enumerator9 = null;
			try
			{
				enumerator9 = dataTable.Rows.GetEnumerator();
				while (enumerator9.MoveNext())
				{
					((DataRow)enumerator9.Current)["QuickTurnaround_TimeofDay"] = 0;
				}
			}
			finally
			{
				if (enumerator9 is IDisposable)
				{
					(enumerator9 as IDisposable).Dispose();
				}
			}
		}
		if (!dataTable.Columns.Contains("WinchesterShotgun"))
		{
			dataTable.Columns.Add("WinchesterShotgun", typeof(string));
			IEnumerator enumerator10 = null;
			try
			{
				enumerator10 = dataTable.Rows.GetEnumerator();
				while (enumerator10.MoveNext())
				{
					((DataRow)enumerator10.Current)["WinchesterShotgun"] = 0;
				}
			}
			finally
			{
				if (enumerator10 is IDisposable)
				{
					(enumerator10 as IDisposable).Dispose();
				}
			}
		}
		if (scenario_1 != null)
		{
			if (!dataTable.Columns.Contains("NumberOfLoadouts"))
			{
				dataTable.Columns.Add("NumberOfLoadouts", typeof(string));
			}
			if (!dataTable.Columns.Contains("NumberOfLoadoutsIncludingMountedWeapons"))
			{
				dataTable.Columns.Add("NumberOfLoadoutsIncludingMountedWeapons", typeof(string));
			}
			if (!dataTable.Columns.Contains("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"))
			{
				dataTable.Columns.Add("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly", typeof(string));
			}
			if (!dataTable.Columns.Contains("QuickTurnaroundDescription"))
			{
				dataTable.Columns.Add("QuickTurnaroundDescription", typeof(string));
			}
			if (!dataTable.Columns.Contains("WinchesterShotgunDescription"))
			{
				dataTable.Columns.Add("WinchesterShotgunDescription", typeof(string));
			}
			DataTable dataTable2 = new DataTable();
			IEnumerator enumerator11 = null;
			try
			{
				enumerator11 = dataTable.Rows.GetEnumerator();
				IEnumerator enumerator12 = null;
				int num = 0;
				while (enumerator11.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator11.Current;
					int num9 = int.MaxValue;
					int num10 = int.MaxValue;
					int num11 = int.MaxValue;
					dataTable2 = ItemsForThisLoadout(Conversions.ToInteger(dataRow["ID"]), ref sqliteConnection_0, ref bool_1);
					if (!bool_0)
					{
						try
						{
							enumerator12 = dataTable2.Rows.GetEnumerator();
							while (enumerator12.MoveNext())
							{
								DataRow obj = (DataRow)enumerator12.Current;
								num = Conversions.ToInteger(obj["ComponentID"]);
								int num12 = Conversions.ToInteger(obj["Quantity"]);
								bool flag = Conversions.ToBoolean(obj["Optional"]);
								if (Weapon.WeaponIsNonRivalrous(num, ref scenario_1))
								{
									continue;
								}
								int num13 = aircraft_0.AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(num);
								int num14 = 0;
								if (!Information.IsNothing(dictionary_0) && dictionary_0.ContainsKey(num))
								{
									num14 = dictionary_0[num];
								}
								if (num12 <= 0)
								{
									continue;
								}
								int num15 = num13 / num12;
								if (num15 < num9)
								{
									num9 = num15;
								}
								num15 = (num13 + num14) / num12;
								if (num15 < num10)
								{
									num10 = num15;
								}
								if (!flag)
								{
									num15 = (num13 + num14) / num12;
									if (num15 < num11)
									{
										num11 = num15;
									}
								}
							}
						}
						finally
						{
							if (enumerator12 is IDisposable)
							{
								(enumerator12 as IDisposable).Dispose();
							}
						}
					}
					if ((num9 == int.MaxValue) | bool_0)
					{
						dataRow["NumberOfLoadouts"] = "Unlimited";
					}
					else
					{
						dataRow["NumberOfLoadouts"] = num9;
					}
					if ((num10 == int.MaxValue) | bool_0)
					{
						dataRow["NumberOfLoadoutsIncludingMountedWeapons"] = "Unlimited";
					}
					else
					{
						dataRow["NumberOfLoadoutsIncludingMountedWeapons"] = num10;
					}
					if ((num11 == int.MaxValue) | bool_0)
					{
						dataRow["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"] = "Unlimited";
					}
					else
					{
						dataRow["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"] = num11;
					}
					if (Conversions.ToBoolean(dataRow["QuickTurnaround"]))
					{
						int num16 = Conversions.ToInteger(dataRow["QuickTurnaround_ReadyTime"]);
						int num2 = Conversions.ToInteger(dataRow["QuickTurnaround_MaxSorties"]);
						int num3 = Conversions.ToInteger(dataRow["QuickTurnaround_AirborneTime"]);
						_InterceptorReader = "Select EnumLoadoutTimeOfDay.Description from EnumLoadoutTimeOfDay, DataLoadout where EnumLoadoutTimeOfDay.ID = DataLoadout.QuickTurnaround_TimeofDay and DataLoadout.ID = " + dataRow["ID"].ToString();
						DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
						string text = ((datatable.Rows.Count <= 0) ? "No time-of-day description" : datatable.Rows[0]["Description"].ToString());
						dataRow["QuickTurnaroundDescription"] = text + ", " + Conversions.ToString(num2) + " sorties @ " + Misc.UpdateRequest(num16 * 60) + ", " + Misc.UpdateRequest(num3 * 60) + " flying time";
					}
					else
					{
						dataRow["QuickTurnaroundDescription"] = "-";
					}
					if (Conversions.ToBoolean(dataRow["WinchesterShotgun"]) && Conversions.ToInteger(dataRow["WinchesterShotgun"]) != 0)
					{
						dataRow["WinchesterShotgunDescription"] = GetLoadoutWeaponStateDescription(num, Conversions.ToInteger(dataRow["WinchesterShotgun"]), ref sqliteConnection_0, scenario_1, bool_0: false, (Loadout.LoadoutRole)Conversions.ToInteger(dataRow["LoadoutRole"]));
					}
					else
					{
						dataRow["WinchesterShotgunDescription"] = "Winchester: Mission-specific weapons have been expended. Disengage immediately.";
					}
				}
			}
			finally
			{
				if (enumerator11 is IDisposable)
				{
					(enumerator11 as IDisposable).Dispose();
				}
			}
		}
		if (scenario_1 != null)
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = dataTable.Rows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow dataRow2 = (DataRow)enumerator2.Current;
					if (!dataTable.Columns.Contains("RangeProfileDescription"))
					{
						dataTable.Columns.Add("RangeProfileDescription", typeof(string));
					}
					if (!dataTable.Columns.Contains("LoadoutRoleDescription"))
					{
						dataTable.Columns.Add("LoadoutRoleDescription", typeof(string));
					}
					if (!dataTable.Columns.Contains("Weather"))
					{
						dataTable.Columns.Add("Weather", typeof(string));
					}
					if (!dataTable.Columns.Contains("TimeofDay"))
					{
						dataTable.Columns.Add("TimeofDay", typeof(string));
					}
					if (!dataTable.Columns.Contains("ReadyTime"))
					{
						dataTable.Columns.Add("ReadyTime", typeof(string));
					}
					if (!dataTable.Columns.Contains("ReadyTime_Sustained"))
					{
						dataTable.Columns.Add("ReadyTime_Sustained", typeof(string));
					}
					string description = GetLoadoutMissionProfile(Conversions.ToInteger(dataRow2["ID"]), ref sqliteConnection_0, scenario_0).Description;
					int num4 = Conversions.ToInteger(dataRow2["DefaultCombatRadius"]);
					int num5 = Conversions.ToInteger(dataRow2["DefaultTimeOnStation"]);
					string text2 = ((Conversions.ToInteger(dataRow2["DefaultMissionProfile"]) == 1001) ? "" : ((num5 <= 0) ? (Conversions.ToString(num4) + " nm ") : (Conversions.ToString(num5) + " minutes at " + Conversions.ToString(num4) + " nm ")));
					dataRow2["RangeProfileDescription"] = text2 + description;
					_InterceptorReader = "Select EnumLoadoutRole.Description from EnumLoadoutRole, DataLoadout where EnumLoadoutRole.ID =  DataLoadout.LoadoutRole and DataLoadout.ID = " + Conversions.ToString(Conversions.ToInteger(dataRow2["ID"]));
					DataTable datatable2 = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
					if (datatable2.Rows.Count <= 0)
					{
						dataRow2["LoadoutRoleDescription"] = "Loadout Role: None";
					}
					else
					{
						string text3 = Conversions.ToString(datatable2.Rows[0]["Description"]);
						dataRow2["LoadoutRoleDescription"] = "Loadout Role: " + text3;
					}
					_InterceptorReader = "Select EnumLoadoutWeather.Description from EnumLoadoutWeather, DataLoadout where EnumLoadoutWeather.ID = DataLoadout.Weather and DataLoadout.ID = " + Conversions.ToString(Conversions.ToInteger(dataRow2["ID"]));
					DataTable datatable3 = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
					if (datatable3.Rows.Count <= 0)
					{
						dataRow2["Weather"] = "";
					}
					else
					{
						dataRow2["Weather"] = Conversions.ToString(datatable3.Rows[0]["Description"]);
					}
					_InterceptorReader = "Select EnumLoadoutTimeOfDay.Description from EnumLoadoutTimeOfDay, DataLoadout where EnumLoadoutTimeOfDay.ID = DataLoadout.TimeofDay and DataLoadout.ID = " + dataRow2["ID"].ToString();
					DataTable datatable4 = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
					if (datatable4.Rows.Count <= 0)
					{
						dataRow2["TimeofDay"] = "";
					}
					else
					{
						dataRow2["TimeofDay"] = datatable4.Rows[0]["Description"].ToString();
					}
					try
					{
						_InterceptorReader = "SELECT ReadyTime, ReadyTime_Sustained from DataLoadout where DataLoadout.ID = " + dataRow2["ID"].ToString();
						DataTable datatable5 = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
						if (datatable5.Rows.Count <= 0)
						{
							dataRow2["ReadyTime"] = "";
							dataRow2["ReadyTime_Sustained"] = "";
							continue;
						}
						DataRow dataRow3 = datatable5.Rows[0];
						long num6 = Conversions.ToLong(dataRow3["ReadyTime"]);
						long num7 = Conversions.ToLong(dataRow3["ReadyTime_Sustained"]);
						if (num6 <= 0)
						{
							dataRow2["ReadyTime"] = "n/a";
						}
						else
						{
							dataRow2["ReadyTime"] = Misc.UpdateRequest(num6 * 60);
						}
						if (num7 <= 0)
						{
							dataRow2["ReadyTime_Sustained"] = "n/a";
						}
						else
						{
							dataRow2["ReadyTime_Sustained"] = Misc.UpdateRequest(num7 * 60);
						}
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						_InterceptorReader = "SELECT ReadyTime as ReadyTime from DataLoadout where DataLoadout.ID = " + dataRow2["ID"].ToString();
						DataTable datatable6 = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
						if (datatable6.Rows.Count <= 0)
						{
							dataRow2["ReadyTime"] = "";
						}
						else
						{
							long num8 = Conversions.ToLong(datatable6.Rows[0]["ReadyTime"]);
							if (num8 <= 0)
							{
								dataRow2["ReadyTime"] = "n/a";
							}
							else
							{
								dataRow2["ReadyTime"] = Misc.UpdateRequest(num8 * 60);
							}
						}
						dataRow2["ReadyTime_Sustained"] = "-";
						ProjectData.ClearProjectError();
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
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = dataTable.Rows.GetEnumerator();
			IEnumerator enumerator4 = null;
			while (enumerator3.MoveNext())
			{
				_ = (DataRow)enumerator3.Current;
				if (dataTable.Columns.Contains("AttackAltitude"))
				{
					continue;
				}
				dataTable.Columns.Add("AttackAltitude", typeof(string));
				try
				{
					enumerator4 = dataTable.Rows.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						DataRow dataRow4 = (DataRow)enumerator4.Current;
						if (Information.IsNothing(GetLoadoutMissionProfile(Conversions.ToInteger(dataRow4["ID"]), ref sqliteConnection_0, scenario_0)))
						{
							continue;
						}
						float attackAltitudeIngress = GetLoadoutMissionProfile(Conversions.ToInteger(dataRow4["ID"]), ref sqliteConnection_0, scenario_0).AttackAltitudeIngress;
						string text4 = "";
						if (attackAltitudeIngress == 0f)
						{
							switch (Conversions.ToInteger(dataRow4["LoadoutRole"]))
							{
							default:
								dataRow4["AttackAltitude"] = "-";
								break;
							case 3001:
							case 3002:
							case 3003:
							case 3004:
							case 3005:
							case 3101:
							case 3102:
							case 3103:
							case 3104:
							case 3105:
							case 3201:
							case 3202:
							case 3203:
							case 3204:
							case 3205:
							case 3401:
							case 4301:
							case 6002:
								attackAltitudeIngress = GetLoadoutMissionProfile(Conversions.ToInteger(dataRow4["ID"]), ref sqliteConnection_0, scenario_0).CruiseAltitudeIngress;
								if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
								{
									text4 = (GetLoadoutMissionProfile(Conversions.ToInteger(dataRow4["ID"]), ref sqliteConnection_0, scenario_0).CruiseAltitudeIngressTerrainFollowing ? " AGL (Terrain Following / Avoidance)" : " ASL");
								}
								if (attackAltitudeIngress == 0f)
								{
									dataRow4["AttackAltitude"] = "-";
								}
								else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									dataRow4["AttackAltitude"] = Conversions.ToString(Math.Round(attackAltitudeIngress * 3.28084f, 0)) + " ft" + text4;
								}
								else
								{
									dataRow4["AttackAltitude"] = "Attack Altitude: " + Conversions.ToString(attackAltitudeIngress) + " m" + text4;
								}
								break;
							}
						}
						else
						{
							if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
							{
								text4 = (GetLoadoutMissionProfile(Conversions.ToInteger(dataRow4["ID"]), ref sqliteConnection_0, scenario_0).AttackAltitudeIngressTerrainFollowing ? " AGL (Terrain Following / Avoidance)" : " ASL");
							}
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								dataRow4["AttackAltitude"] = Conversions.ToString(Math.Round(attackAltitudeIngress * 3.28084f, 0)) + " ft" + text4;
							}
							else
							{
								dataRow4["AttackAltitude"] = "Attack Altitude: " + Conversions.ToString(attackAltitudeIngress) + " m" + text4;
							}
						}
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
			return dataTable;
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
	}

	public static List<int> WeaponsCarriedByThisAircraft(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		List<int> list = new List<int>();
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT DISTINCT DataWeapon.ID from DataWeapon, DataLoadout, DataLoadoutWeapons, DataAircraftLoadouts, DataWeaponRecord where DataWeapon.ID = DataWeaponRecord.ComponentID and DataWeaponRecord.ID = DataLoadoutWeapons.ComponentID and DataLoadoutWeapons.ID = DataLoadout.ID and DataLoadout.ID = DataAircraftLoadouts.ComponentID and DataAircraftLoadouts.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			list.Add(Conversions.ToInteger(dataRow["ID"]));
		}
		return list;
	}

	public static DataTable ItemsForThisLoadout(int int_0, ref SQLiteConnection sqliteConnection_0, ref bool bool_0)
	{
		DataTable dataTable = new DataTable();
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT DataLoadoutWeapons.ComponentID, DataLoadoutWeapons.Optional, DataLoadoutWeapons.Internal FROM DataLoadoutWeapons, DataWeaponRecord, DataWeapon WHERE DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID AND DataWeapon.ID = DataWeaponRecord.ComponentID AND DataLoadoutWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name, DataWeaponRecord.DefaultLoad ASC";
		DataTable datatable;
		try
		{
			datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_InterceptorReader = "SELECT DataLoadoutWeapons.ComponentID FROM DataLoadoutWeapons, DataWeaponRecord, DataWeapon WHERE DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID AND DataWeapon.ID = DataWeaponRecord.ComponentID AND DataLoadoutWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
			datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			ProjectData.ClearProjectError();
		}
		dataTable.Columns.Add("ComponentID", typeof(int));
		dataTable.Columns.Add("Quantity", typeof(int));
		dataTable.Columns.Add("Item", typeof(string));
		dataTable.Columns.Add("Optional", typeof(bool));
		dataTable.Columns.Add("Internal", typeof(bool));
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (!((datatable.Columns.Contains("Optional") && Conversions.ToBoolean(dataRow["Optional"])) & bool_0))
			{
				_InterceptorReader = "Select DataWeapon.ID as ID, DataWeapon.NAME, DataWeaponRecord.DefaultLoad from DataWeapon, DataWeaponRecord where DataWeapon.ID = DataWeaponRecord.ComponentID and DataWeaponRecord.ID =" + dataRow["ComponentID"].ToString();
				SQLiteDataReader val = sQLiteHelper.DestroySpecification(_InterceptorReader);
				((DbDataReader)val).Read();
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2["ComponentID"] = RuntimeHelpers.GetObjectValue(((DbDataReader)val)["ID"]);
				dataRow2["Quantity"] = RuntimeHelpers.GetObjectValue(((DbDataReader)val)["DefaultLoad"]);
				if (datatable.Columns.Contains("Optional"))
				{
					dataRow2["Optional"] = RuntimeHelpers.GetObjectValue(dataRow["Optional"]);
				}
				else
				{
					dataRow2["Optional"] = false;
				}
				if (datatable.Columns.Contains("Internal"))
				{
					dataRow2["Internal"] = RuntimeHelpers.GetObjectValue(dataRow["Internal"]);
				}
				else
				{
					dataRow2["Internal"] = false;
				}
				if (Conversions.ToBoolean(dataRow2["Optional"]) && Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = ((DbDataReader)val)["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(((DbDataReader)val)["Name"])) + "   (Internal, Optional)";
				}
				else if (Conversions.ToBoolean(dataRow2["Optional"]) && !Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = ((DbDataReader)val)["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(((DbDataReader)val)["Name"])) + "   (Optional)";
				}
				else if (!Conversions.ToBoolean(dataRow2["Optional"]) && Conversions.ToBoolean(dataRow2["Internal"]))
				{
					dataRow2["Item"] = ((DbDataReader)val)["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(((DbDataReader)val)["Name"])) + "   (Internal)";
				}
				else
				{
					dataRow2["Item"] = ((DbDataReader)val)["DefaultLoad"].ToString() + "x " + Strings.Trim(Conversions.ToString(((DbDataReader)val)["Name"]));
				}
				dataTable.Rows.Add(dataRow2);
				((DbDataReader)val).Close();
				val = null;
			}
		}
		return dataTable;
	}

	public static Loadout GetReserveLoadoutForThisAircraft(ref Scenario scenario_0, int int_0)
	{
		try
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
			_InterceptorReader = "Select ComponentID from DataAircraftLoadouts where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					Loadout loadout = GetLoadout(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), bool_0: false, bool_1: false);
					if (loadout.Role == Loadout.LoadoutRole.Reserve)
					{
						return loadout;
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
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101259", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static Loadout GetMaintenanceLoadoutForThisAircraft(ref Scenario scenario_0, int int_0)
	{
		try
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
			_InterceptorReader = "Select ComponentID from DataAircraftLoadouts where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					Loadout loadout = GetLoadout(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), bool_0: false, bool_1: false);
					if (loadout.Role == Loadout.LoadoutRole.Unavailable)
					{
						return loadout;
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
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101260", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static Loadout GetLoadout(ref Scenario scenario_0, int int_0, bool bool_0, bool bool_1)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataLoadout where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count <= 0)
		{
			throw new PlatformComponentNotFoundException("This loadout ID does not exist in the database.");
		}
		DataRow dataRow = datatable.Rows[0];
		if (!datatable.Columns.Contains("QuickTurnaround"))
		{
			datatable.Columns.Add("QuickTurnaround", typeof(string));
			dataRow["QuickTurnaround"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_ReadyTime"))
		{
			datatable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
			dataRow["QuickTurnaround_ReadyTime"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_MaxSorties"))
		{
			datatable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
			dataRow["QuickTurnaround_MaxSorties"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
		{
			datatable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
			dataRow["QuickTurnaround_AdditionalTimePenalty"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_AirborneTime"))
		{
			datatable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
			dataRow["QuickTurnaround_AirborneTime"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_TimeofDay"))
		{
			datatable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
			dataRow["QuickTurnaround_TimeofDay"] = 0;
		}
		if (!datatable.Columns.Contains("ReadyTime_Sustained"))
		{
			datatable.Columns.Add("ReadyTime_Sustained", typeof(string));
			dataRow["ReadyTime_Sustained"] = 0;
		}
		if (!datatable.Columns.Contains("WinchesterShotgun"))
		{
			datatable.Columns.Add("WinchesterShotgun", typeof(string));
			dataRow["WinchesterShotgun"] = 0;
		}
		Loadout loadout_ = new Loadout(int_0, dataRow["Name"].ToString(), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToInteger(dataRow["ReadyTime"]), Conversions.ToInteger(dataRow["ReadyTime_Sustained"]), (Loadout.LoadoutRole)Conversions.ToInteger(dataRow["LoadoutRole"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["TimeofDay"]), (Loadout._LoadoutWeather)Conversions.ToShort(dataRow["Weather"]), Conversions.ToSingle(dataRow["PayloadWeightDragModifier"]), Conversions.ToInteger(dataRow["DefaultCombatRadius"]), Conversions.ToShort(dataRow["DefaultTimeOnStation"]), Conversions.ToBoolean(dataRow["RequiresBuddyIllumination"]), bool_0, Conversions.ToBoolean(dataRow["QuickTurnaround"]), Conversions.ToInteger(dataRow["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(dataRow["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(dataRow["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(dataRow["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["QuickTurnaround_TimeofDay"]), (Doctrine._WeaponState)Conversions.ToInteger(dataRow["WinchesterShotgun"]));
		try
		{
			loadout_.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (datatable.Columns.Contains("Cargo_Crew"))
		{
			try
			{
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
				{
					loadout_.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
				{
					loadout_.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
				{
					loadout_.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
				{
					loadout_.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_ParadropCapable"])))
				{
					loadout_.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		GetLoadoutWeapons(ref scenario_0, ref loadout_, int_0, bool_0);
		if (bool_1)
		{
			GetLoadoutPayloadWeight(ref scenario_0, ref loadout_);
		}
		return loadout_;
	}

	public static void GetLoadout(ref Aircraft aircraft_0, int int_0, bool bool_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(aircraft_0.ParentScen.DBConnection);
		_InterceptorReader = "Select * from DataLoadout where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count <= 0)
		{
			throw new PlatformComponentNotFoundException("Unable to equip aircraft: " + aircraft_0.Name + " with loadout #ID: " + Conversions.ToString(int_0) + ". This loadout ID does not exist in the database.");
		}
		DataRow dataRow = datatable.Rows[0];
		string text = dataRow["Name"].ToString();
		if (bool_0)
		{
			text += " - Mandatory Weapons Only";
		}
		if (!datatable.Columns.Contains("QuickTurnaround"))
		{
			datatable.Columns.Add("QuickTurnaround", typeof(string));
			dataRow["QuickTurnaround"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_ReadyTime"))
		{
			datatable.Columns.Add("QuickTurnaround_ReadyTime", typeof(string));
			dataRow["QuickTurnaround_ReadyTime"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_MaxSorties"))
		{
			datatable.Columns.Add("QuickTurnaround_MaxSorties", typeof(string));
			dataRow["QuickTurnaround_MaxSorties"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_AdditionalTimePenalty"))
		{
			datatable.Columns.Add("QuickTurnaround_AdditionalTimePenalty", typeof(string));
			dataRow["QuickTurnaround_AdditionalTimePenalty"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_AirborneTime"))
		{
			datatable.Columns.Add("QuickTurnaround_AirborneTime", typeof(string));
			dataRow["QuickTurnaround_AirborneTime"] = 0;
		}
		if (!datatable.Columns.Contains("QuickTurnaround_TimeofDay"))
		{
			datatable.Columns.Add("QuickTurnaround_TimeofDay", typeof(string));
			dataRow["QuickTurnaround_TimeofDay"] = 0;
		}
		if (!datatable.Columns.Contains("ReadyTime_Sustained"))
		{
			datatable.Columns.Add("ReadyTime_Sustained", typeof(string));
			dataRow["ReadyTime_Sustained"] = 0;
		}
		if (!datatable.Columns.Contains("WinchesterShotgun"))
		{
			datatable.Columns.Add("WinchesterShotgun", typeof(string));
			dataRow["WinchesterShotgun"] = 2001;
		}
		Loadout loadout_ = null;
		try
		{
			loadout_ = new Loadout(int_0, text, Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToInteger(dataRow["ReadyTime"]), Conversions.ToInteger(dataRow["ReadyTime_Sustained"]), (Loadout.LoadoutRole)Conversions.ToInteger(dataRow["LoadoutRole"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["TimeofDay"]), (Loadout._LoadoutWeather)Conversions.ToShort(dataRow["Weather"]), Conversions.ToSingle(dataRow["PayloadWeightDragModifier"]), Conversions.ToInteger(dataRow["DefaultCombatRadius"]), Conversions.ToShort(dataRow["DefaultTimeOnStation"]), Conversions.ToBoolean(dataRow["RequiresBuddyIllumination"]), bool_0, Conversions.ToBoolean(dataRow["QuickTurnaround"]), Conversions.ToInteger(dataRow["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(dataRow["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(dataRow["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(dataRow["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)Conversions.ToShort(dataRow["QuickTurnaround_TimeofDay"]), (Doctrine._WeaponState)Conversions.ToInteger(dataRow["WinchesterShotgun"]));
			loadout_.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200473", exception_.Message + " [ on loadout id " + Conversions.ToString(int_0) + " for " + aircraft_0.AnnexAndDBID + " ]");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (loadout_ == null)
			{
				aircraft_0.Loadout = loadout_;
				ProjectData.ClearProjectError();
				return;
			}
			ProjectData.ClearProjectError();
		}
		if (datatable.Columns.Contains("Cargo_Crew"))
		{
			try
			{
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
				{
					loadout_.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
				{
					loadout_.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
				{
					loadout_.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
				{
					loadout_.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_ParadropCapable"])))
				{
					loadout_.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		GetLoadoutWeapons(ref aircraft_0.ParentScen, ref loadout_, int_0, bool_0);
		GetLoadoutPayloadWeight(ref aircraft_0.ParentScen, ref loadout_);
		aircraft_0.Loadout = loadout_;
	}

	public static void GetLoadoutWeapons(ref Scenario scenario_0, ref Loadout loadout_0, int int_0, bool bool_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT DataWeaponRecord.*, DataLoadoutWeapons.ComponentNumber, DataLoadoutWeapons.Optional, DataLoadoutWeapons.Internal from DataLoadoutWeapons, DataWeaponRecord, DataWeapon where DataWeaponRecord.ID =DataLoadoutWeapons.ComponentID And DataWeapon.ID=DataWeaponRecord.ComponentID And DataLoadoutWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name";
		DataTable datatable;
		try
		{
			datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_InterceptorReader = "SELECT DataWeaponRecord.*, DataLoadoutWeapons.ComponentNumber from DataLoadoutWeapons, DataWeaponRecord, DataWeapon where DataWeaponRecord.ID =DataLoadoutWeapons.ComponentID And DataWeapon.ID=DataWeaponRecord.ComponentID And DataLoadoutWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name";
			datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			ProjectData.ClearProjectError();
		}
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			bool flag = datatable.Columns.Contains("Optional") && Conversions.ToBoolean(dataRow["Optional"]);
			bool bool_ = datatable.Columns.Contains("Internal") && Conversions.ToBoolean(dataRow["Internal"]);
			if (!flag || !bool_0)
			{
				WeaponRec weaponRec_ = new WeaponRec(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), flag, bool_);
				loadout_0.AddWeaponRec(weaponRec_);
			}
		}
	}

	public static void GetLoadoutPayloadWeight(ref Scenario scenario_0, ref Loadout loadout_0)
	{
		try
		{
			WeaponRec[] weapons = loadout_0.Weapons;
			int num = 0;
			int num2 = 0;
			WeaponRec[] array = weapons;
			WeaponRec[] array2 = array;
			foreach (WeaponRec weaponRec in array2)
			{
				num += weaponRec.GetReferenceWeapon(scenario_0).EmptyWeight * weaponRec.CurrentLoad;
				if (loadout_0.GetMissionProfile(scenario_0).DropBombsAtMaxRange)
				{
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(scenario_0);
					if (referenceWeapon.IsASuW_Land || referenceWeapon.IsASuW_Naval || referenceWeapon.IsAntiradar)
					{
						num2 += referenceWeapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			loadout_0.PayloadWeight = num;
			loadout_0.PayloadWeightDroppable = num2;
			loadout_0.PayloadWeight_TakeOff = num;
			loadout_0.PayloadWeightDroppable_TakeOff = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetLoadoutPayloadTakeOffWeight_Current(ref Scenario scenario_0, ref Loadout loadout_0)
	{
		try
		{
			WeaponRec[] weapons = loadout_0.Weapons;
			int num = 0;
			int num2 = 0;
			WeaponRec[] array = weapons;
			WeaponRec[] array2 = array;
			foreach (WeaponRec weaponRec in array2)
			{
				num += weaponRec.GetReferenceWeapon(scenario_0).EmptyWeight * weaponRec.CurrentLoad;
				if (loadout_0.GetMissionProfile(scenario_0).DropBombsAtMaxRange)
				{
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(scenario_0);
					if (referenceWeapon.IsASuW_Land || referenceWeapon.IsASuW_Naval || referenceWeapon.IsAntiradar)
					{
						num2 += referenceWeapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			loadout_0.PayloadWeight = num;
			loadout_0.PayloadWeightDroppable = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetLoadoutPayloadTakeOffWeight_Static(ref Scenario scenario_0, ref Loadout loadout_0)
	{
		try
		{
			WeaponRec[] weapons = loadout_0.Weapons;
			int num = 0;
			int num2 = 0;
			WeaponRec[] array = weapons;
			WeaponRec[] array2 = array;
			foreach (WeaponRec weaponRec in array2)
			{
				num += weaponRec.GetReferenceWeapon(scenario_0).EmptyWeight * weaponRec.CurrentLoad;
				if (loadout_0.GetMissionProfile(scenario_0).DropBombsAtMaxRange)
				{
					Weapon referenceWeapon = weaponRec.GetReferenceWeapon(scenario_0);
					if (referenceWeapon.IsASuW_Land || referenceWeapon.IsASuW_Naval || referenceWeapon.IsAntiradar)
					{
						num2 += referenceWeapon.EmptyWeight * weaponRec.CurrentLoad;
					}
				}
			}
			loadout_0.PayloadWeight_TakeOff = num;
			loadout_0.PayloadWeightDroppable_TakeOff = num2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) InterruptList(ref Scenario scenario_0, int int_0, bool bool_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumShipCSGen"))
		{
			_InterceptorReader = "Select * from EnumShipCSGen where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			DataRow dataRow = datatable.Rows[0];
			short item = 0;
			short item2 = 0;
			short item3 = 0;
			string item4 = "";
			string item5 = "";
			if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
			{
				item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
			{
				item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
			{
				item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
			{
				item5 = Conversions.ToString(dataRow["Description"]);
			}
			if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
			{
				item4 = Conversions.ToString(dataRow["Example"]);
			}
			return (Description: item5, Example: item4, OODA_Detection: item, OODA_Targeting: item2, OODA_Evasion: item3);
		}
		return (Description: string.Empty, Example: string.Empty, OODA_Detection: 0, OODA_Targeting: 0, OODA_Evasion: 0);
	}

	public static void GetShip(ref Scenario scenario_0, ref Ship ship_0, int int_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataShip where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No ship with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				ship_0.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) tuple = InterruptList(ref scenario_0, ship_0.CombatSystemGen, bool_0: false);
				ship_0.m_TokenVal = tuple.Item3;
				ship_0._IndexerVal = tuple.Item4;
				ship_0._ResolverVal = tuple.Item5;
			}
			else
			{
				if (datatable.Columns.Contains("OODADetectionCycle"))
				{
					ship_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				else
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
					ship_0.m_TokenVal = 0;
				}
				if (datatable.Columns.Contains("OODATargetingCycle"))
				{
					ship_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				else
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
					ship_0._IndexerVal = 0;
				}
				if (datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					ship_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
				else
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
					ship_0._ResolverVal = 0;
				}
			}
			ship_0.Category = (Ship._ShipCategory)Conversions.ToInteger(dataRow["Category"].ToString());
			ship_0.Type = (Ship._ShipType)Conversions.ToInteger(dataRow["Type"].ToString());
			ship_0.DBID = int_0;
			ship_0.UnitClass = Strings.Trim(dataRow["Name"].ToString());
			ship_0.Length = Conversions.ToSingle(dataRow["Length"].ToString());
			try
			{
				ship_0.DockingPhysicalSize = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSizeCode"].ToString());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				ship_0.DockingPhysicalSize = ReadList(ship_0.Length);
				exception_?.Data.Add("Error at 200072", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			ship_0.Crew = Conversions.ToInteger(dataRow["Crew"]);
			ship_0.Armor_Belt = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBelt"]);
			ship_0.Armor_Bridge = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBridge"]);
			ship_0.Armor_Bulkhead = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorBulkheads"]);
			ship_0.Armor_CIC = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorCIC"]);
			ship_0.Armor_Deck = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorDeck"]);
			ship_0.Armor_Engineering = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorEngineering"]);
			ship_0.Armor_Rudder = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorRudder"]);
			ship_0.MaxSeaState = Conversions.ToByte(dataRow["MaxSeaState"]);
			ship_0.RepairCapacity = (short)Conversions.ToInteger(dataRow["RepairCapacity"]);
			ship_0.TroopCapacity = (short)Conversions.ToInteger(dataRow["TroopCapacity"]);
			ship_0.CargoCapacity = Conversions.ToInteger(dataRow["CargoCapacity"]);
			ship_0.MissileDefense = Conversions.ToShort(dataRow["MissileDefense"]);
			ship_0.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			ship_0.SetDamagePts(bool_0: false, null, Conversions.ToSingle(dataRow["DamagePoints"]));
			ship_0.Displacement_Empty = Conversions.ToSingle(dataRow["DisplacementEmpty"]);
			ship_0.Displacement_Standard = Conversions.ToSingle(dataRow["DisplacementStandard"]);
			ship_0.Displacement_Full = Conversions.ToSingle(dataRow["DisplacementFull"]);
			ship_0.EmptyWeight = (int)Math.Round(ship_0.Displacement_Standard);
			ship_0.Beam = Conversions.ToSingle(dataRow["Beam"]);
			ship_0.Draft = Conversions.ToSingle(dataRow["Draft"]);
			ship_0.Height = Conversions.ToSingle(dataRow["Height"]);
			if (datatable.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
					{
						ship_0.Cargo_Crew = Conversions.ToSingle(dataRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
					{
						ship_0.Cargo_Area = Conversions.ToSingle(dataRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
					{
						ship_0.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
					{
						ship_0.Cargo_Mass = Conversions.ToSingle(dataRow["Cargo_Mass"]);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			ship_0.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			try
			{
				ship_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200475", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		GeDataShipFlags(ref ship_0, int_0);
		if (bool_0)
		{
			PopulateSensors(ship_0, int_0);
			PopulateComms(ship_0, int_0);
			ActiveUnit activeUnit_ = ship_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
			PopulatePropulsion(ship_0, int_0);
			PopulateFuel(ship_0, int_0);
			Platform platform_ = ship_0;
			PopulateMagazines(ref platform_, int_0);
			platform_ = ship_0;
			PopulateAirFacilities(ref platform_, int_0);
			platform_ = ship_0;
			PopulateDockFacilities(ref platform_, int_0);
		}
	}

	public static void GeDataShipFlags(ref Ship ship_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(ship_0.ParentScen.DBConnection);
		_InterceptorReader = "Select * from DataShipCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i]["CodeID"]))
			{
			case 1011:
				ship_0.Flags.PrairieMasker = true;
				continue;
			case 1002:
				ship_0.Flags.ShockResistant = true;
				continue;
			case 1001:
				ship_0.Flags.AviationVessel = true;
				continue;
			case 2001:
				ship_0.Flags.bool_0 = true;
				continue;
			case 1012:
				ship_0.Flags.AdvancedQuieting = true;
				continue;
			case 3001:
				ship_0.Flags.PassiveOrSingleStabilizers = true;
				continue;
			case 3002:
				ship_0.Flags.DualOrTripleStabilizers = true;
				continue;
			case 3003:
				ship_0.Flags.AluminumConstruction = true;
				continue;
			case 3004:
				ship_0.Flags.CivilianConstruction = true;
				continue;
			case 2101:
				ship_0.Flags.CanLaunchCargoDirectlyToSea = true;
				continue;
			case 4020:
				ship_0.Flags.bool_1 = true;
				continue;
			case 4001:
				ship_0.Flags.LowConstructionStandards = true;
				continue;
			case 4002:
				ship_0.Flags.AllAluminumConstruction = true;
				continue;
			case 4003:
				ship_0.Flags.AluminumSuperstructureOnly = true;
				continue;
			case 4006:
				ship_0.Flags.WoodenHullConstruction = true;
				continue;
			case 4007:
				ship_0.Flags.GRP_Construction = true;
				continue;
			case 4011:
				ship_0.Flags.Hovercraft_SES = true;
				continue;
			case 4012:
				ship_0.Flags.CatamaranTrimaranMultihull = true;
				continue;
			case 6001:
				ship_0.Flags.MCM_DegaussedSteelHull = true;
				continue;
			case 6002:
				ship_0.Flags.MCM_OnboardDegaussingGear = true;
				continue;
			case 6003:
				ship_0.Flags.MCM_WoodenHull = true;
				continue;
			case 6004:
				ship_0.Flags.MCM_GRPHull = true;
				continue;
			case 4022:
				ship_0.Flags.BuiltToMercantileStandards = true;
				continue;
			case 8101:
				ship_0.UNREP_Capabilities.m_CollectionComparator = 1;
				continue;
			case 8102:
				ship_0.UNREP_Capabilities.m_CollectionComparator = 2;
				continue;
			case 8103:
				ship_0.UNREP_Capabilities.m_CollectionComparator = 3;
				continue;
			case 8104:
				ship_0.UNREP_Capabilities.m_CollectionComparator = 4;
				continue;
			case 8105:
				ship_0.UNREP_Capabilities.m_CollectionComparator = 5;
				continue;
			case 8106:
				ship_0.UNREP_Capabilities.m_ObjectComparator = 1;
				continue;
			case 8107:
				ship_0.UNREP_Capabilities.m_ObjectComparator = 2;
				continue;
			case 8108:
				ship_0.UNREP_Capabilities.m_ObjectComparator = 3;
				continue;
			case 8109:
				ship_0.UNREP_Capabilities.m_ObjectComparator = 4;
				continue;
			case 8110:
				ship_0.UNREP_Capabilities.m_ObjectComparator = 5;
				continue;
			case 8111:
				ship_0.UNREP_Capabilities._ThreadComparator = 1;
				continue;
			case 8112:
				ship_0.UNREP_Capabilities._ThreadComparator = 2;
				continue;
			case 8001:
				ship_0.UNREP_Capabilities.instanceComparator = 1;
				continue;
			case 8002:
				ship_0.UNREP_Capabilities.instanceComparator = 2;
				continue;
			case 8003:
				ship_0.UNREP_Capabilities.instanceComparator = 3;
				continue;
			case 8004:
				ship_0.UNREP_Capabilities.instanceComparator = 4;
				continue;
			case 8005:
				ship_0.UNREP_Capabilities.m_ParameterComparator = 1;
				continue;
			case 8006:
				ship_0.UNREP_Capabilities.m_ParameterComparator = 2;
				continue;
			case 8007:
				ship_0.UNREP_Capabilities.m_ParameterComparator = 3;
				continue;
			case 8008:
				ship_0.UNREP_Capabilities.m_ParameterComparator = 4;
				continue;
			case 8011:
				ship_0.UNREP_Capabilities.m_RuleComparator = 1;
				continue;
			case 8012:
				ship_0.UNREP_Capabilities.m_RuleComparator = 2;
				continue;
			case 9101:
				ship_0.UNREP_Capabilities.expressionComparator = 1;
				continue;
			case 9102:
				ship_0.UNREP_Capabilities.expressionComparator = 2;
				continue;
			case 9103:
				ship_0.UNREP_Capabilities.expressionComparator = 3;
				continue;
			case 9104:
				ship_0.UNREP_Capabilities.expressionComparator = 4;
				continue;
			case 9105:
				ship_0.UNREP_Capabilities.listenerComparator = 1;
				continue;
			case 9106:
				ship_0.UNREP_Capabilities.listenerComparator = 2;
				continue;
			case 9107:
				ship_0.UNREP_Capabilities.listenerComparator = 3;
				continue;
			case 9108:
				ship_0.UNREP_Capabilities.listenerComparator = 4;
				continue;
			case 9001:
				ship_0.UNREP_Capabilities.m_DispatcherComparator = 1;
				continue;
			case 9002:
				ship_0.UNREP_Capabilities.m_DispatcherComparator = 2;
				continue;
			case 9003:
				ship_0.UNREP_Capabilities.m_DispatcherComparator = 3;
				continue;
			case 9004:
				ship_0.UNREP_Capabilities.m_DispatcherComparator = 4;
				continue;
			case 9005:
				ship_0.UNREP_Capabilities.m_ConfigComparator = 1;
				continue;
			case 9006:
				ship_0.UNREP_Capabilities.m_ConfigComparator = 2;
				continue;
			case 9007:
				ship_0.UNREP_Capabilities.m_ConfigComparator = 3;
				continue;
			case 9008:
				ship_0.UNREP_Capabilities.m_ConfigComparator = 4;
				continue;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal static (string Description, string Example, string Architecture, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) RemoveList(ref Scenario scenario_0, int int_0, bool bool_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumSubmarineCSGen"))
		{
			_InterceptorReader = "Select * from EnumSubmarineCSGen where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			DataRow dataRow = datatable.Rows[0];
			short item = 0;
			short item2 = 0;
			short item3 = 0;
			string item4 = string.Empty;
			string item5 = string.Empty;
			string item6 = string.Empty;
			if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
			{
				item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
			{
				item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
			}
			if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
			{
				item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
			{
				item5 = Conversions.ToString(dataRow["Description"]);
			}
			if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
			{
				item4 = Conversions.ToString(dataRow["Example"]);
			}
			if (datatable.Columns.Contains("Architecture") && dataRow["Architecture"].ToString().Length > 0)
			{
				item6 = Conversions.ToString(dataRow["Architecture"]);
			}
			return (Description: item5, Example: item4, Architecture: item6, OODA_Detection: item, OODA_Targeting: item2, OODA_Evasion: item3);
		}
		return (Description: string.Empty, Example: string.Empty, Architecture: string.Empty, OODA_Detection: 0, OODA_Targeting: 0, OODA_Evasion: 0);
	}

	public static void GetSubmarine(ref Scenario scenario_0, ref Submarine submarine_0, int int_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataSubmarine where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No submarine with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		DataRow dataRow = datatable.Rows[0];
		if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
		{
			submarine_0.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
			(string, string, string, short, short, short) tuple = RemoveList(ref scenario_0, submarine_0.CombatSystemGen, bool_0: false);
			submarine_0.m_TokenVal = tuple.Item4;
			submarine_0._IndexerVal = tuple.Item5;
			submarine_0._ResolverVal = tuple.Item6;
		}
		else
		{
			if (!datatable.Columns.Contains("OODADetectionCycle"))
			{
				datatable.Columns.Add("OODADetectionCycle", typeof(string));
				dataRow["OODADetectionCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODATargetingCycle"))
			{
				datatable.Columns.Add("OODATargetingCycle", typeof(string));
				dataRow["OODATargetingCycle"] = 0;
			}
			if (!datatable.Columns.Contains("OODAEvasiveCycle"))
			{
				datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
				dataRow["OODAEvasiveCycle"] = 0;
			}
			submarine_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
			submarine_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
			submarine_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
		}
		submarine_0.Category = (Submarine._SubmarineCategory)Conversions.ToInteger(dataRow["Category"]);
		submarine_0.Type = (Submarine._SubmarineType)Conversions.ToInteger(dataRow["Type"]);
		submarine_0.DBID = int_0;
		submarine_0.UnitClass = Strings.Trim(dataRow["Name"].ToString());
		submarine_0.Length = Conversions.ToSingle(dataRow["Length"]);
		try
		{
			submarine_0.DockingPhysicalSize = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSizeCode"]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			submarine_0.DockingPhysicalSize = ReadList(submarine_0.Length);
			exception_?.Data.Add("Error at 200074", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		submarine_0.EmptyWeight = (int)Math.Round(Conversions.ToDouble(dataRow["DisplacementStandard"].ToString()));
		submarine_0.Crew = Conversions.ToInteger(dataRow["Crew"]);
		submarine_0.MaxDepth = Conversions.ToInteger(dataRow["MaxDepth"]);
		submarine_0.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
		submarine_0.SetDamagePts(bool_0: false, null, Conversions.ToSingle(dataRow["DamagePoints"]));
		submarine_0.Kinematics.SetClimbRate_Nominal(bool_0: true, 1f);
		submarine_0.Beam = Conversions.ToSingle(dataRow["Beam"]);
		submarine_0.Draft = Conversions.ToSingle(dataRow["Draft"]);
		submarine_0.Height = Conversions.ToSingle(dataRow["Height"]);
		if (datatable.Columns.Contains("DisplacementEmpty"))
		{
			submarine_0.Displacement_Empty = Conversions.ToSingle(dataRow["DisplacementEmpty"]);
		}
		if (datatable.Columns.Contains("DisplacementStandard"))
		{
			submarine_0.Displacement_Standard = Conversions.ToSingle(dataRow["DisplacementStandard"]);
		}
		if (datatable.Columns.Contains("DisplacementFull"))
		{
			submarine_0.Displacement_Full = Conversions.ToSingle(dataRow["DisplacementFull"]);
		}
		submarine_0.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
		if (datatable.Columns.Contains("ROVRadius"))
		{
			submarine_0.ROVControlRadius_m = Conversions.ToShort(dataRow["ROVRadius"].ToString());
		}
		try
		{
			submarine_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		GetSubmarineFlags(submarine_0, int_0);
		if (bool_0)
		{
			PopulateSensors(submarine_0, int_0);
			PopulateComms(submarine_0, int_0);
			ActiveUnit activeUnit_ = submarine_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
			PopulatePropulsion(submarine_0, int_0);
			PopulateFuel(submarine_0, int_0);
			Platform platform_ = submarine_0;
			PopulateMagazines(ref platform_, int_0);
			platform_ = submarine_0;
			PopulateDockFacilities(ref platform_, int_0);
		}
	}

	public static void GetSubmarineFlags(Submarine submarine_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(submarine_0.ParentScen.DBConnection);
		_InterceptorReader = "Select * from DataSubmarineCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i]["CodeID"]))
			{
			case 2002:
				submarine_0.Flags.ShockResistant = true;
				continue;
			case 1001:
				submarine_0.Flags.AnechoicCoating = true;
				continue;
			case 1002:
				submarine_0.Flags.NonmagneticHull = true;
				continue;
			case 1003:
				submarine_0.Flags.NoLaunchTransient = true;
				continue;
			case 1004:
				submarine_0.Flags.ShroudedPropulsor = true;
				continue;
			case 1005:
				submarine_0.Flags.AdvancedPropulsor = true;
				continue;
			case 9001:
				submarine_0.Flags.HasSnorkel = true;
				continue;
			case 5001:
				submarine_0.Flags.UsesLiOnBattery = true;
				continue;
			case 4001:
				submarine_0.Flags.LowConstructionStandards = true;
				continue;
			case 4002:
				submarine_0.Flags.NonmagneticHull = true;
				continue;
			case 4003:
				submarine_0.Flags.bool_0 = true;
				continue;
			case 2001:
			case 4004:
				submarine_0.Flags.DoubleHull = true;
				continue;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) FindList(ref Scenario scenario_0, int int_0, bool bool_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		(string, string, short, short, short) result;
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumFacilityCSGen"))
		{
			_InterceptorReader = "Select * from EnumFacilityCSGen where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			if (datatable.Rows.Count >= 1)
			{
				DataRow dataRow = datatable.Rows[0];
				short item = 0;
				short item2 = 0;
				short item3 = 0;
				string item4 = "";
				string item5 = "";
				if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
				{
					item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
				{
					item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
				{
					item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
				if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
				{
					item5 = Conversions.ToString(dataRow["Description"]);
				}
				if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
				{
					item4 = Conversions.ToString(dataRow["Example"]);
				}
				return (Description: item5, Example: item4, OODA_Detection: item, OODA_Targeting: item2, OODA_Evasion: item3);
			}
			result = (int_0.ToString(), string.Empty, 0, 0, 0);
		}
		else
		{
			result = (string.Empty, string.Empty, 0, 0, 0);
		}
		return result;
	}

	public static void GetFacility(ref Scenario scenario_0, ref Facility facility_0, int int_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataFacility where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No facility with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				facility_0.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) tuple = FindList(ref scenario_0, facility_0.CombatSystemGen, bool_0: false);
				facility_0.m_TokenVal = tuple.Item3;
				facility_0._IndexerVal = tuple.Item4;
				facility_0._ResolverVal = tuple.Item5;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
				}
				facility_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				facility_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				facility_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			facility_0.DBID = int_0;
			facility_0.UnitClass = dataRow["Name"].ToString();
			facility_0.Armor_General = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			facility_0.MastHeight = Conversions.ToInteger(dataRow["MastHeight"]);
			facility_0.MissileDefense = Conversions.ToInteger(dataRow["MissileDefense"]);
			facility_0.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			facility_0.SetDamagePts(bool_0: false, null, Conversions.ToSingle(dataRow["DamagePoints"]));
			facility_0.Category = (Facility._FacilityCategory)Conversions.ToShort(dataRow["Category"]);
			facility_0.Length = Conversions.ToSingle(dataRow["Length"]);
			facility_0.Width = Conversions.ToSingle(dataRow["Width"]);
			facility_0.Area = Conversions.ToDouble(dataRow["Area"]);
			facility_0.HasAimpoints = Conversions.ToBoolean(dataRow["MountsAreAimpoints"]);
			facility_0.AimpointDispersalRadius = Conversions.ToInteger(dataRow["Radius"]);
			facility_0.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			try
			{
				facility_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200476", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		if (bool_0)
		{
			PopulateSensors(facility_0, int_0);
			PopulateComms(facility_0, int_0);
			ActiveUnit activeUnit_ = facility_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
			PopulateFuel(facility_0, int_0);
			Platform platform_ = facility_0;
			PopulateMagazines(ref platform_, int_0);
			platform_ = facility_0;
			PopulateAirFacilities(ref platform_, int_0);
			platform_ = facility_0;
			PopulateDockFacilities(ref platform_, int_0);
		}
	}

	internal static (string Description, string Example, short OODA_Detection, short OODA_Targeting, short OODA_Evasion) SetList(ref Scenario scenario_0, int int_0, bool bool_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		(string, string, short, short, short) result;
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "EnumGroundUnitCSGen"))
		{
			_InterceptorReader = "Select * from EnumGroundUnitCSGen where ID = " + Conversions.ToString(int_0);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			if (datatable.Rows.Count >= 1)
			{
				DataRow dataRow = datatable.Rows[0];
				short item = 0;
				short item2 = 0;
				short item3 = 0;
				string item4 = "";
				string item5 = "";
				if (datatable.Columns.Contains("OODADetectionCycle") && dataRow["OODADetectionCycle"].ToString().Length > 0)
				{
					item = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODATargetingCycle") && dataRow["OODATargetingCycle"].ToString().Length > 0)
				{
					item2 = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				}
				if (datatable.Columns.Contains("OODAEvasiveCycle") && dataRow["OODAEvasiveCycle"].ToString().Length > 0)
				{
					item3 = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
				}
				if (datatable.Columns.Contains("Description") && dataRow["Description"].ToString().Length > 0)
				{
					item5 = Conversions.ToString(dataRow["Description"]);
				}
				if (datatable.Columns.Contains("Example") && dataRow["Example"].ToString().Length > 0)
				{
					item4 = Conversions.ToString(dataRow["Example"]);
				}
				return (Description: item5, Example: item4, OODA_Detection: item, OODA_Targeting: item2, OODA_Evasion: item3);
			}
			result = (int_0.ToString(), string.Empty, 0, 0, 0);
		}
		else
		{
			result = (string.Empty, string.Empty, 0, 0, 0);
		}
		return result;
	}

	public static void GetVehicle(ref Scenario scenario_0, ref Vehicle vehicle_0, int int_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataGroundUnit where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int count = datatable.Rows.Count;
		if (count == 0)
		{
			throw new Exception("No ground unit with ID: " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			if (datatable.Columns.Contains("CSGen") && Conversions.ToInteger(dataRow["CSGen"]) > 0)
			{
				vehicle_0.CombatSystemGen = Conversions.ToInteger(dataRow["CSGen"]);
				(string, string, short, short, short) tuple = SetList(ref scenario_0, vehicle_0.CombatSystemGen, bool_0: false);
				vehicle_0.m_TokenVal = tuple.Item3;
				vehicle_0._IndexerVal = tuple.Item4;
				vehicle_0._ResolverVal = tuple.Item5;
			}
			else
			{
				if (!datatable.Columns.Contains("OODADetectionCycle"))
				{
					datatable.Columns.Add("OODADetectionCycle", typeof(string));
					dataRow["OODADetectionCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODATargetingCycle"))
				{
					datatable.Columns.Add("OODATargetingCycle", typeof(string));
					dataRow["OODATargetingCycle"] = 0;
				}
				if (!datatable.Columns.Contains("OODAEvasiveCycle"))
				{
					datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
					dataRow["OODAEvasiveCycle"] = 0;
				}
				vehicle_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
				vehicle_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
				vehicle_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
			}
			vehicle_0.DBID = int_0;
			vehicle_0.UnitClass = dataRow["Name"].ToString();
			vehicle_0.Crew = Conversions.ToInteger(dataRow["Crew"].ToString());
			vehicle_0.Mass = Conversions.ToSingle(dataRow["Mass"]);
			vehicle_0.Armor_General = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			vehicle_0.MastHeight = Conversions.ToInteger(dataRow["MastHeight"]);
			vehicle_0.MissileDefense = Conversions.ToInteger(dataRow["MissileDefense"]);
			vehicle_0.InitialDP = Conversions.ToInteger(dataRow["DamagePoints"]);
			vehicle_0.SetDamagePts(bool_0: false, null, Conversions.ToSingle(dataRow["DamagePoints"]));
			vehicle_0.MobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(dataRow["Category"]);
			vehicle_0.Length = Conversions.ToSingle(dataRow["Length"]);
			vehicle_0.Width = Conversions.ToSingle(dataRow["Width"]);
			vehicle_0.Area = Conversions.ToDouble(dataRow["Area"]);
			vehicle_0.OperatorCountryCode = Conversions.ToInteger(dataRow["OperatorCountry"].ToString());
			vehicle_0.MaxSeaState = Conversions.ToInteger(dataRow["MaxSeaState"].ToString());
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Type"])))
			{
				vehicle_0.Cargo_Type = VisitList(vehicle_0.Width);
			}
			else
			{
				vehicle_0.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Self_Cargo_Type"]);
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Area"])))
			{
				vehicle_0.Cargo_Area = (float)vehicle_0.Area;
			}
			else
			{
				vehicle_0.Cargo_Area = Conversions.ToSingle(dataRow["Self_Cargo_Area"]);
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Crew"])))
			{
				vehicle_0.Cargo_Crew = vehicle_0.Crew;
			}
			else
			{
				vehicle_0.Cargo_Crew = Conversions.ToInteger(dataRow["Self_Cargo_Crew"]);
			}
			if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Mass"])))
			{
				vehicle_0.Cargo_Mass = vehicle_0.Mass;
			}
			else
			{
				vehicle_0.Cargo_Mass = Conversions.ToSingle(dataRow["Self_Cargo_Mass"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_ParadropCapable"])))
			{
				vehicle_0.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Self_Cargo_ParadropCapable"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Type"])))
			{
				vehicle_0.Cargo_Capacity_Type = (CargoType)Conversions.ToInteger(dataRow["Carry_Cargo_Type"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Area"])))
			{
				vehicle_0.Cargo_Capacity_Area = Conversions.ToSingle(dataRow["Carry_Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Crew"])))
			{
				vehicle_0.Cargo_Capacity_Crew = Conversions.ToInteger(dataRow["Carry_Cargo_Crew"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Carry_Cargo_Mass"])))
			{
				vehicle_0.Cargo_Capacity_Mass = Conversions.ToSingle(dataRow["Carry_Cargo_Mass"]);
			}
			if (datatable.Columns.Contains("Tow_Mass") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Tow_Mass"])))
			{
				vehicle_0.Cargo_Capacity_Towing = Conversions.ToSingle(dataRow["Tow_Mass"]);
			}
			try
			{
				vehicle_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200476", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		GetVehicleFlags(ref vehicle_0, int_0);
		if (bool_0)
		{
			PopulateSensors(vehicle_0, int_0);
			PopulateComms(vehicle_0, int_0);
			ActiveUnit activeUnit_ = vehicle_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
			PopulatePropulsion(vehicle_0, int_0);
			PopulateFuel(vehicle_0, int_0);
			Platform platform_ = vehicle_0;
			PopulateMagazines(ref platform_, int_0);
			platform_ = vehicle_0;
			PopulateAirFacilities(ref platform_, int_0);
			platform_ = vehicle_0;
			PopulateDockFacilities(ref platform_, int_0);
		}
	}

	public static bool IsSeaworthyAmphibiousVehicle(Scenario scenario_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataGroundUnitCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (Conversions.ToInteger(datatable.Rows[num2]["CodeID"]) == 2001)
				{
					_InterceptorReader = "Select distinct DataPropulsionPerformance.AltitudeBand from DataPropulsionPerformance left join DataGroundUnitPropulsion on DataPropulsionPerformance.ID = DataGroundUnitPropulsion.ComponentID left join DataGroundUnit on DataGroundUnitPropulsion.ID = DataGroundUnit.ID where DataGroundUnit.ID = " + Conversions.ToString(int_0);
					if (DBCache.GetDatatable(sqliteHelper_, _InterceptorReader).Rows.Count > 1)
					{
						break;
					}
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static void GetVehicleFlags(ref Vehicle vehicle_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(vehicle_0.ParentScen.DBConnection);
		_InterceptorReader = "Select * from DataGroundUnitCodes where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int num2 = Conversions.ToInteger(datatable.Rows[i]["CodeID"]);
			switch (num2)
			{
			case 2001:
				vehicle_0.IsAmphibious = true;
				break;
			default:
				_ = Debugger.IsAttached;
				break;
			case 4001:
				vehicle_0.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4002:
				vehicle_0.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4003:
				vehicle_0.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 4004:
				vehicle_0.TractionMode = (Vehicle.TractionType)num2;
				break;
			case 1001:
			case 1002:
			case 3002:
			case 3003:
				break;
			}
		}
	}

	public static int GetVehicleType_Int(ref Scenario scenario_0, int int_0)
	{
		_InterceptorReader = "Select Category from DataGroundUnit where ID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(new SQLiteHelper(scenario_0.DBConnection), _InterceptorReader));
	}

	public static string GetVehicleName(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT Name from DataGroundUnit where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static CargoType GetVehicleCargoType(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		float result2;
		if (CheckColumnExists_SQLite("DataGroundUnit", "Self_Cargo_Type", sqliteConnection_0))
		{
			if (int.TryParse(DBCache.GetScalar(sqliteHelper_, "SELECT Self_Cargo_Type from DataGroundUnit where ID='" + Conversions.ToString(int_0) + "'"), out var result))
			{
				return (CargoType)result;
			}
		}
		else if (float.TryParse(DBCache.GetScalar(sqliteHelper_, "SELECT Width from DataGroundUnit where ID='" + Conversions.ToString(int_0) + "'"), out result2))
		{
			if (result2 < 1f)
			{
				return CargoType.Personnel;
			}
			if (result2 < 5f)
			{
				return CargoType.SmallCargo;
			}
			if (result2 < 7f)
			{
				return CargoType.MediumCargo;
			}
			if (result2 < 9f)
			{
				return CargoType.LargeCargo;
			}
			return CargoType.const_5;
		}
		return CargoType.NoCargo;
	}

	public static void GetPersonnelCargoValues(Scenario scenario_0, ref float float_0, ref float float_1)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		float_0 = 0.1f;
		float_1 = 0.16f;
		if (!sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			return;
		}
		_InterceptorReader = "Select * from DataGroundUnit where Category = 1000";
		DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
		if (datatable.Rows.Count != 0)
		{
			DataRow dataRow = datatable.Rows[0];
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Area"])))
			{
				float_1 = Conversions.ToSingle(dataRow["Self_Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Self_Cargo_Mass"])))
			{
				float_0 = Conversions.ToSingle(dataRow["Self_Cargo_Mass"]);
			}
		}
	}

	public static Weapon._WeaponType GetWeaponType(int int_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT Type from DataWeapon where ID = " + Conversions.ToString(int_0);
		Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, _InterceptorReader));
		if (weaponType == Weapon._WeaponType.GuidedWeapon)
		{
			_InterceptorReader = "SELECT COUNT(*) from DataWeaponCodes where ID = " + Conversions.ToString(int_0) + " AND CodeID = 4010";
			if (Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, _InterceptorReader)) > 0)
			{
				weaponType = Weapon._WeaponType.BallisticMissile;
			}
		}
		return weaponType;
	}

	public static WeaponRec GetWeaponRec(int int_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT * from DataWeaponRecord where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		DataRow dataRow = datatable.Rows[0];
		return new WeaponRec(ref scenario_0, bool_0: datatable.Columns.Contains("Optional") && Conversions.ToBoolean(dataRow["Optional"]), bool_1: datatable.Columns.Contains("Internal") && Conversions.ToBoolean(dataRow["Internal"]), int_1: Conversions.ToInteger(dataRow["ComponentID"]), int_2: Conversions.ToInteger(dataRow["DefaultLoad"]), int_3: Conversions.ToInteger(dataRow["MaxLoad"]), int_4: Conversions.ToInteger(dataRow["ROF"]), int_5: Conversions.ToInteger(dataRow["Multiple"]));
	}

	public static bool CheckWeaponIsInAircraftLoadouts(SQLiteConnection sqliteConnection_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT Count(*) from DataLoadout, DataLoadoutWeapons, DataWeaponRecord where DataLoadoutWeapons.ID = DataLoadout.ID AND DataLoadoutWeapons.ComponentID = DataWeaponRecord.ID and DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, _InterceptorReader)) > 0;
	}

	public static void GetWeapon(SQLiteConnection sqliteConnection_0, Weapon weapon_0, int int_0, Scenario scenario_0, bool bool_0 = true)
	{
		try
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("SELECT * from DataWeapon where ID = ").Append(int_0);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			AuthenticationCollectionRecord authenticationCollectionRecord = DBCache.AssetImporter<AuthenticationCollectionRecord>(sqliteHelper_, _InterceptorReader).First();
			weapon_0.SnapUpDown = (float)authenticationCollectionRecord.m_ContainerSetter;
			string text = Strings.Trim(authenticationCollectionRecord.Name);
			weapon_0.DBID = int_0;
			weapon_0.UnitClass = text;
			weapon_0.Name = text;
			if ((object)weapon_0.GetType() == typeof(Weapon))
			{
				weapon_0.Type = (Weapon._WeaponType)authenticationCollectionRecord.m_InstanceSetter;
			}
			weapon_0.TechGeneration = (GlobalVariables.TechGenerationClass)authenticationCollectionRecord._ObjectSetter;
			weapon_0.Length = (float)authenticationCollectionRecord.parameterSetter;
			weapon_0.Span = (float)authenticationCollectionRecord.expressionSetter;
			weapon_0.Diameter = (float)authenticationCollectionRecord._DispatcherSetter;
			weapon_0.EmptyWeight = (int)Math.Round(authenticationCollectionRecord.listenerSetter);
			weapon_0.MaxWeight = (int)Math.Round(authenticationCollectionRecord.listenerSetter);
			weapon_0.classReader = (int)Math.Round(authenticationCollectionRecord.m_RegistrySetter);
			weapon_0.CEP_Surface_Nominal = (int)authenticationCollectionRecord.m_ClientSetter;
			if (weapon_0.CEP_Surface_Nominal == 0)
			{
				weapon_0.CEP_Surface_Nominal = (int)authenticationCollectionRecord._IssuerSetter;
			}
			weapon_0.CEP_Surface = weapon_0.CEP_Surface_Nominal;
			weapon_0.CEP_Land_Nominal = (int)authenticationCollectionRecord._IssuerSetter;
			weapon_0.CEP_Land = weapon_0.CEP_Land_Nominal;
			weapon_0.m_ObserverReader = authenticationCollectionRecord._AdvisorSetter;
			weapon_0.CanActAsSensor = authenticationCollectionRecord._ComposerSetter;
			if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(sqliteConnection_0))
			{
				weapon_0.CruiseAltitude_ASL = (float)authenticationCollectionRecord.valSetter;
			}
			else
			{
				weapon_0.CruiseAltitude_ASL = (float)authenticationCollectionRecord.definitionSetter;
			}
			weapon_0.CruiseAltitude_AGL = (float)authenticationCollectionRecord.definitionSetter;
			weapon_0.Waypoints = (int)authenticationCollectionRecord.m_WrapperSetter;
			weapon_0.IlluminationTime = (int)authenticationCollectionRecord.observerSetter;
			weapon_0.SurfPOK = (int)Math.Round(authenticationCollectionRecord.consumerSetter);
			try
			{
				weapon_0.LandPOK = (int)Math.Round(authenticationCollectionRecord.facadeSetter);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				weapon_0.LandPOK = 0;
				ProjectData.ClearProjectError();
			}
			weapon_0.SubPOK = (int)Math.Round(authenticationCollectionRecord.proxySetter);
			weapon_0.AirPOK = (int)Math.Round(authenticationCollectionRecord.m_DicSetter);
			weapon_0.Kinematics.SetClimbRate_Nominal(bool_0: true, (float)authenticationCollectionRecord._ReaderSetter);
			weapon_0.MaxLaunchSpeed = (int)authenticationCollectionRecord.m_TokenizerSetter;
			weapon_0.MinLaunchSpeed = (int)authenticationCollectionRecord._StubSetter;
			weapon_0.MaxAirRange = (float)authenticationCollectionRecord._PropertySetter;
			weapon_0.MinAirRange = (float)authenticationCollectionRecord.m_ImporterSetter;
			weapon_0.MaxSurfaceRange = (float)authenticationCollectionRecord._RepositorySetter;
			weapon_0.MinSurfaceRange = (float)authenticationCollectionRecord.bridgeSetter;
			weapon_0.MaxLandRange = (float)authenticationCollectionRecord._InvocationSetter;
			weapon_0.MinLandRange = (float)authenticationCollectionRecord.classSetter;
			weapon_0.MaxSubsurfaceRange = (float)authenticationCollectionRecord.m_RequestSetter;
			weapon_0.MinSubsurfaceRange = (float)authenticationCollectionRecord.valueSetter;
			if (weapon_0.IsTorpedo)
			{
				((Torpedo)weapon_0).MaxKinematicRange_Full = (float)authenticationCollectionRecord.errorSetter;
				((Torpedo)weapon_0).MaxKinematicRange_Cruise = (float)authenticationCollectionRecord.serializerSetter;
			}
			if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(sqliteConnection_0))
			{
				weapon_0.MaxLaunchAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord.watcherSetter, 1);
				weapon_0.MinLaunchAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord._ReponseSetter, 1);
				weapon_0.MaxTargetAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord.m_TestsSetter, 1);
				weapon_0.MinTargetAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord._InterpreterSetter, 1);
			}
			weapon_0.MaxLaunchAlt_AGL = (float)Math.Round((float)authenticationCollectionRecord.writerSetter, 1);
			weapon_0.MinLaunchAlt_AGL = (float)Math.Round((float)authenticationCollectionRecord._SpecificationSetter, 1);
			weapon_0.MaxTargetAlt_AGL = (float)Math.Round((float)authenticationCollectionRecord._TaskSetter, 1);
			weapon_0.MinTargetAlt_AGL = (float)Math.Round((float)authenticationCollectionRecord.filterSetter, 1);
			weapon_0.MaxTargetSpeed = (int)authenticationCollectionRecord._DescriptorSetter;
			weapon_0.MinTargetSpeed = (int)authenticationCollectionRecord.m_PoolSetter;
			weapon_0.InitialDP = 1;
			try
			{
				weapon_0.Hypothetical = authenticationCollectionRecord.tokenSetter;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200477", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
			{
				weapon_0.CruiseAltitude_ASL = (float)authenticationCollectionRecord.valSetter;
				weapon_0.MaxLaunchAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord.watcherSetter, 1);
				weapon_0.MinLaunchAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord._ReponseSetter, 1);
				weapon_0.MaxTargetAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord.m_TestsSetter, 1);
				weapon_0.MinTargetAlt_ASL = (float)Math.Round((float)authenticationCollectionRecord._InterpreterSetter, 1);
			}
			if (weapon_0.IsTorpedo && weapon_0.MaxSurfaceRange == 6f && weapon_0.MaxSubsurfaceRange == 6f)
			{
				weapon_0.MaxSurfaceRange = 8f;
				weapon_0.MaxSubsurfaceRange = 8f;
			}
			weapon_0.ValidTargets = new WeaponTargets(int_0, ref sqliteConnection_0);
			CalculateList(ref weapon_0, int_0);
			PopulateWeaponWeapons(ref scenario_0, ref weapon_0, int_0);
			PopulateWeaponFlags(ref weapon_0, ref weapon_0.Flags);
			if (!weapon_0._FacadeReader)
			{
				Doctrine doctrine = weapon_0.Doctrine;
				Dictionary<int, Doctrine.WRA_Weapon> dictionary_ = doctrine.WRA;
				PopulateWeaponWRA(ref weapon_0, ref dictionary_);
				doctrine.WRA = dictionary_;
			}
			if (bool_0)
			{
				FillList(ref weapon_0);
			}
			if (weapon_0.MaxSurfaceRange > 0f && weapon_0.MaxLandRange == 0f && (weapon_0.ValidTargets.AerostatMooring || weapon_0.ValidTargets.AirBaseSingleUnit || weapon_0.ValidTargets.LandStructure_Hard || weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.Runway || weapon_0.ValidTargets.Radar || weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.MobileTarget_Soft || weapon_0.ValidTargets.UnderwaterStructure))
			{
				weapon_0.MaxLandRange = weapon_0.MaxSurfaceRange;
				weapon_0.MinLandRange = weapon_0.MinSurfaceRange;
				weapon_0.LandPOK = weapon_0.SurfPOK;
			}
			if (weapon_0.IsASuW_Naval && !weapon_0.IsTorpedo && !weapon_0.IsDecoy && !weapon_0.IsMine && weapon_0.Type != Weapon._WeaponType.Laser && weapon_0.Type != Weapon._WeaponType.Microwave && weapon_0.Type != Weapon._WeaponType.UAV_Expendable && weapon_0.Type != Weapon._WeaponType.LaserDazzler && weapon_0.CEP_Surface_Nominal == 0)
			{
				_ = Debugger.IsAttached;
			}
			if (weapon_0.IsBallisticMissile || weapon_0.IsReEntryVehicle)
			{
				weapon_0.Flags.BearingOnlyLaunch = true;
			}
			if (weapon_0.IsTorpedo && weapon_0.Sensors_Cached.Count() > 0)
			{
				weapon_0.Flags.ReAttack_Capability = true;
			}
			Warhead[] warheads = weapon_0.Warheads;
			Warhead[] array = warheads;
			foreach (Warhead warhead in array)
			{
				if (warhead.DP == (float)weapon_0.DBID)
				{
					Exception exception_2 = new Exception("DB error for weapon #" + weapon_0.DBID + " , circular reference with carried weapon");
					GameGeneral.WriteExceptionsToLog(ref exception_2);
					warhead.DP = -1f;
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_3 = ex2;
			exception_3?.Data.Add("Error at 200274", exception_3.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void FillList(ref Weapon weapon_0)
	{
		int dBID = weapon_0.DBID;
		PopulatePropulsion(weapon_0, dBID);
		PopulateSensors(weapon_0, dBID);
		PopulateFuel(weapon_0, dBID);
		PopulateComms(weapon_0, dBID);
		PopulateWarheads(ref weapon_0.Warheads, ref weapon_0);
	}

	private static void CalculateList(ref Weapon weapon_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID from DataSensor, DataWeaponDirectors as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "ID");
		int count = list.Count;
		if (count > 0)
		{
			weapon_0.Directors = new List<int>(count);
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				weapon_0.Directors.Add((int)list[i]);
			}
		}
	}

	public static void PopulateWeaponWeapons(ref Scenario scenario_0, ref Weapon weapon_0, int int_0)
	{
		if (weapon_0.ParentScen.FeatureCompatibility.GetLPI_Radars(weapon_0.ParentScen.DBConnection))
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("SELECT DataWeaponRecord.* FROM DataWeaponWeapons, DataWeaponRecord, DataWeapon WHERE DataWeaponWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataWeaponWeapons.ID = ").Append(int_0).Append(" ORDER BY DataWeapon.Type, DataWeapon.Name ASC");
			DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString());
			int num = datatableTyped.Rows.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				DtrRow dtrRow = datatableTyped.Rows[i];
				WeaponRec weaponRec = new WeaponRec(ref scenario_0, Conversions.ToInteger(dtrRow["ComponentID"]), Conversions.ToInteger(dtrRow["DefaultLoad"]), Conversions.ToInteger(dtrRow["MaxLoad"]), Conversions.ToInteger(dtrRow["ROF"]), Conversions.ToInteger(dtrRow["Multiple"]), bool_0: false, bool_1: false);
				weaponRec.WRecDBID = Conversions.ToInteger(dtrRow["ID"]);
				weapon_0.WeaponWeapons.Add(weaponRec);
			}
		}
	}

	private static void PopList(Scenario scenario_0, ref Mount mount_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID from DataSensor, DataMountDirectors as theTable where DataSensor.ID = theTable.ComponentID and theTable.ID = ").Append(mount_0.DBID);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, _InterceptorReader);
		int num = datatableTyped.Rows.Count();
		mount_0.CompatibleDirectors.Clear();
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			mount_0.CompatibleDirectors.Add(Conversions.ToInteger(dtrRow["ID"]));
		}
	}

	public static void PopulateWeaponFlags(ref Weapon weapon_0, ref Weapon.WeaponFlags weaponFlags_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
		_InterceptorReader = "SELECT CodeID from DataWeaponCodes where ID = " + Conversions.ToString(weapon_0.DBID);
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "CodeID");
		weaponFlags_0.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic;
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num5 = list[i];
			if (num5 <= 6301)
			{
				if (num5 <= 6001)
				{
					if (num5 <= 2025)
					{
						if (num5 <= 1101)
						{
							long num6 = num5 - 1001;
							if ((ulong)num6 <= 2uL && (ulong)num6 <= 2uL)
							{
								long num13 = num6;
								long num14 = num13;
								if ((ulong)num14 <= 2uL)
								{
									switch (num14)
									{
									case 0L:
										weaponFlags_0.IlluminateAtLaunch = true;
										continue;
									case 1L:
										weaponFlags_0.TerminalIllumination = true;
										continue;
									case 2L:
										weaponFlags_0.SupportsBuddyIllumination = true;
										continue;
									}
								}
							}
							if (num5 == 1101)
							{
								weaponFlags_0.HomeOnJam = true;
							}
							continue;
						}
						long num7 = num5 - 2001;
						if ((ulong)num7 <= 11uL && (ulong)num7 <= 11uL)
						{
							long num15 = num7;
							long num16 = num15;
							if ((ulong)num16 <= 11uL)
							{
								switch (num16)
								{
								case 0L:
									weaponFlags_0.SternChase_AAM = true;
									continue;
								case 1L:
									weaponFlags_0.RearAspect_AAM = true;
									continue;
								case 2L:
									weaponFlags_0.AllAspect_AAM = true;
									continue;
								case 3L:
									weaponFlags_0.HOB_AAM = true;
									continue;
								case 4L:
									weaponFlags_0.NoDivingTargetMod = true;
									continue;
								case 5L:
									weaponFlags_0.CapableVsSeaskimmer = true;
									continue;
								case 8L:
									weaponFlags_0.C_RAM = true;
									continue;
								case 9L:
									weaponFlags_0.LOAL_CEC = true;
									continue;
								case 10L:
									weaponFlags_0.TerrainFollowing = true;
									continue;
								case 11L:
									weaponFlags_0.LOAL = true;
									continue;
								case 6L:
								case 7L:
									continue;
								}
							}
						}
						if (num5 == 2025)
						{
							weaponFlags_0.LauncherOccupiedDuringGuidance = true;
						}
					}
					else if (num5 <= 4003)
					{
						long num8 = num5 - 3001;
						if ((ulong)num8 <= 3uL && (ulong)num8 <= 3uL)
						{
							long num17 = num8;
							long num18 = num17;
							if ((ulong)num18 <= 3uL)
							{
								switch (num18)
								{
								case 0L:
									weaponFlags_0.ARMTargetMemory = true;
									continue;
								case 2L:
									weaponFlags_0.LoiterCapability = true;
									continue;
								case 3L:
									weaponFlags_0.ParachuteLoiter = true;
									continue;
								case 1L:
									continue;
								}
							}
						}
						long num9 = num5 - 4001;
						if ((ulong)num9 > 2uL || (ulong)num9 > 2uL)
						{
							continue;
						}
						long num19 = num9;
						long num20 = num19;
						if ((ulong)num20 <= 2uL)
						{
							switch (num20)
							{
							case 0L:
								weaponFlags_0.SearchPattern = true;
								break;
							case 1L:
								weaponFlags_0.DriveThroughLogic = true;
								break;
							case 2L:
								weaponFlags_0.BearingOnlyLaunch = true;
								break;
							}
						}
					}
					else
					{
						switch (num5)
						{
						case 6001L:
							weaponFlags_0.Pod_TerrainAvoidance = true;
							break;
						case 4012L:
							weaponFlags_0.IsMultiStageMissile = true;
							break;
						case 4010L:
							weaponFlags_0.IsBallisticMissile = true;
							break;
						}
					}
					continue;
				}
				if (num5 <= 6022)
				{
					if (num5 <= 6012)
					{
						if (num5 == 6002)
						{
							weaponFlags_0.Pod_TerrainFollowing = true;
							continue;
						}
						long num10 = num5 - 6009;
						if ((ulong)num10 > 3uL || (ulong)num10 > 3uL)
						{
							continue;
						}
						long num21 = num10;
						long num22 = num21;
						if ((ulong)num22 <= 3uL)
						{
							switch (num22)
							{
							case 0L:
								weaponFlags_0.Pod_DayOnlyNavigation = true;
								break;
							case 1L:
								weaponFlags_0.Pod_DayOnlyNavigationAttack = true;
								break;
							case 2L:
								weaponFlags_0.Pod_NightNavigation = true;
								break;
							case 3L:
								weaponFlags_0.Pod_NightNavigationAttack = true;
								break;
							}
						}
					}
					else
					{
						switch (num5)
						{
						case 6022L:
							weaponFlags_0.Pod_ReconNight = true;
							break;
						case 6021L:
							weaponFlags_0.Pod_ReconDayOnly = true;
							break;
						}
					}
					continue;
				}
				if (num5 <= 6111)
				{
					long num11 = num5 - 6101;
					if ((ulong)num11 <= 2uL && (ulong)num11 <= 2uL)
					{
						long num23 = num11;
						long num24 = num23;
						if ((ulong)num24 <= 2uL)
						{
							switch (num24)
							{
							case 0L:
								weaponFlags_0.Navigation_INS = true;
								continue;
							case 1L:
								weaponFlags_0.Navigation_INS_GPS = true;
								continue;
							case 2L:
								weaponFlags_0.Navigation_TERCOM = true;
								continue;
							}
						}
					}
					if (num5 == 6111)
					{
						weaponFlags_0.PreBriefedTargetOnly = true;
					}
					continue;
				}
				long num12 = num5 - 6121;
				if ((ulong)num12 <= 12uL && (ulong)num12 <= 12uL)
				{
					long num25 = num12;
					long num26 = num25;
					if ((ulong)num26 <= 12uL)
					{
						switch (num26)
						{
						case 0L:
							weaponFlags_0.TerminalManeuver_PopUp = true;
							continue;
						case 1L:
							weaponFlags_0.TerminalManeuver_ZigZag = true;
							continue;
						case 2L:
							weaponFlags_0.TerminalManeuver_Random = true;
							continue;
						case 8L:
							weaponFlags_0.ReAttack_Capability = true;
							continue;
						case 9L:
							weaponFlags_0.Navigation_AltitudeControl = true;
							continue;
						case 10L:
							weaponFlags_0.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Aerodynamic;
							continue;
						case 11L:
							weaponFlags_0.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.NonAerodynamic;
							continue;
						case 12L:
							weaponFlags_0.AttitudeControl = Weapon.WeaponFlags.AttitudeControlEnum.Combined;
							continue;
						case 3L:
						case 4L:
						case 5L:
						case 6L:
						case 7L:
							continue;
						}
					}
				}
				switch (num5)
				{
				case 6301L:
					weaponFlags_0.Mine_ContactFuze = true;
					break;
				case 6201L:
					weaponFlags_0.UsesImagingSeeker = true;
					break;
				}
				continue;
			}
			if (num5 <= 6501)
			{
				switch (num5)
				{
				case 6312L:
					weaponFlags_0.Mine_TotalFieldMagnetometerFuze = true;
					break;
				case 6311L:
					weaponFlags_0.Mine_SimpleMagneticFuze = true;
					break;
				case 6322L:
					weaponFlags_0.Mine_PassiveNarrowBandAcousticFuze = true;
					break;
				case 6321L:
					weaponFlags_0.Mine_PassiveBroadBandAcousticFuze = true;
					break;
				case 6341L:
					weaponFlags_0.Mine_SeismicFuze = true;
					break;
				case 6331L:
					weaponFlags_0.Mine_PressureFuze = true;
					break;
				case 6501L:
					weaponFlags_0.Mine_TargetDiscriminationAndIdentification = true;
					break;
				case 6402L:
					weaponFlags_0.Mine_ArmingDelay = true;
					break;
				case 6401L:
					weaponFlags_0.Mine_DelayCounter = true;
					break;
				}
				continue;
			}
			if (num5 <= 7110)
			{
				if (num5 <= 7003)
				{
					if (num5 == 6511)
					{
						weaponFlags_0.Mine_RemoteControlled = true;
						continue;
					}
					long num2 = num5 - 7001;
					if ((ulong)num2 > 2uL || (ulong)num2 > 2uL)
					{
						continue;
					}
					long num27 = num2;
					long num28 = num27;
					if ((ulong)num28 <= 2uL)
					{
						switch (num28)
						{
						case 0L:
							weaponFlags_0.Warhead_SingleRV = true;
							break;
						case 1L:
							weaponFlags_0.Warhead_MRV = true;
							break;
						case 2L:
							weaponFlags_0.Warhead_MIRV = true;
							break;
						}
					}
					continue;
				}
				long num3 = num5 - 7101;
				if ((ulong)num3 <= 2uL && (ulong)num3 <= 2uL)
				{
					long num29 = num3;
					long num30 = num29;
					if ((ulong)num30 <= 2uL)
					{
						switch (num30)
						{
						case 0L:
							weaponFlags_0.Fuze_Impact = true;
							continue;
						case 1L:
							weaponFlags_0.Fuze_Barometric_Altimeter = true;
							continue;
						case 2L:
							weaponFlags_0.Fuze_Proximity = true;
							continue;
						}
					}
				}
				if (num5 == 7110)
				{
					weaponFlags_0.Fuze_Combination = true;
				}
				continue;
			}
			if (num5 <= 8001)
			{
				switch (num5)
				{
				case 8001L:
					weaponFlags_0.CapableVsMobileTarget = true;
					break;
				case 7111L:
					weaponFlags_0.Fuze_ShockFactor_Under_Keel_Optimized = true;
					break;
				}
				continue;
			}
			if (num5 == 8002)
			{
				weaponFlags_0.IsRetardedWeapon = true;
				continue;
			}
			long num4 = num5 - 9001;
			if ((ulong)num4 <= 3uL && (ulong)num4 <= 3uL)
			{
				long num31 = num4;
				long num32 = num31;
				if ((ulong)num32 <= 3uL)
				{
					switch (num32)
					{
					case 0L:
						weaponFlags_0.Torpedo_StraightRunning = true;
						continue;
					case 1L:
						weaponFlags_0.Torpedo_WakeHoming = true;
						continue;
					case 2L:
						weaponFlags_0.Torpedo_StraightRunningTimeDetonation = true;
						continue;
					case 3L:
						weaponFlags_0.Torpedo_PatternRunning = true;
						continue;
					}
				}
			}
			if (num5 == 9999)
			{
				weaponFlags_0.LevelCruiseFlight = true;
			}
		}
	}

	public static void PopulateWeaponWRA(ref Weapon weapon_0, ref Dictionary<int, Doctrine.WRA_Weapon> dictionary_0)
	{
		if (!weapon_0.Doctrine.InsertRepository(ref weapon_0))
		{
			return;
		}
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
		if (dictionary_0 == null)
		{
			dictionary_0 = new Dictionary<int, Doctrine.WRA_Weapon>();
		}
		if (!dictionary_0.ContainsKey(weapon_0.DBID))
		{
			dictionary_0.Add(weapon_0.DBID, new Doctrine.WRA_Weapon());
		}
		if (weapon_0.ParentScen.FeatureCompatibility.GetWRA(weapon_0.ParentScen.DBConnection))
		{
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("SELECT * from DataWeaponWRA where ID = ").Append(weapon_0.DBID);
			object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString()));
			List<(int, int, int, int, int)> list;
			if (objectValue == null)
			{
				DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString(), bool_0: false);
				int num = datatableTyped.Rows.Count();
				list = new List<(int, int, int, int, int)>(datatableTyped.Rows.Count());
				if (num > 0)
				{
					int num2 = num - 1;
					(int, int, int, int, int) item = default((int, int, int, int, int));
					for (int i = 0; i <= num2; i++)
					{
						DtrRow dtrRow = datatableTyped.Rows[i];
						item.Item1 = weapon_0.DBID;
						item.Item2 = Conversions.ToInteger(dtrRow["CodeID"]);
						item.Item3 = Conversions.ToInteger(dtrRow["WeaponQty"]);
						item.Item4 = Conversions.ToInteger(dtrRow["ShooterQty"]);
						item.Item5 = Conversions.ToInteger(dtrRow["SelfDefenceRange"]);
						list.Add(item);
					}
					DBCache.SetCustomObject(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString(), list);
				}
			}
			else
			{
				list = (List<(int, int, int, int, int)>)objectValue;
			}
			{
				foreach (var item2 in list)
				{
					Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry = new Doctrine.WRA_FiringDoctrineEntry((Doctrine._WRA_WeaponTargetType)item2.Item2);
					wRA_FiringDoctrineEntry.WeaponQty = item2.Item3;
					wRA_FiringDoctrineEntry.ShooterQty = item2.Item4;
					wRA_FiringDoctrineEntry.SelfDefenceRange = item2.Item5;
					ArrayExtensions.Add(ref dictionary_0[weapon_0.DBID].WRA_WeaponTargets, wRA_FiringDoctrineEntry);
				}
				return;
			}
		}
		dictionary_0[weapon_0.DBID].WRA_Skeleton(ref weapon_0);
	}

	public static bool GetWeaponCargoData(ref SQLiteConnection sqliteConnection_0, int int_0, ref CargoAmmunition cargoAmmunition_0)
	{
		if (sqliteConnection_0 != null && cargoAmmunition_0 != null)
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
			string string_ = "SELECT Name, Length, Span, Diameter, Weight FROM DataWeapon WHERE id=" + int_0;
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, string_);
			if (datatable.Rows.Count <= 0)
			{
				return false;
			}
			DataRow dataRow = datatable.Rows[0];
			float float_ = Conversions.ToSingle(dataRow["Length"]);
			float float_2 = Conversions.ToSingle(dataRow["Span"]);
			float float_3 = Conversions.ToSingle(dataRow["Diameter"]);
			float float_4 = Conversions.ToSingle(dataRow["Weight"]);
			cargoAmmunition_0.Name = Conversions.ToString(dataRow["Name"]);
			cargoAmmunition_0.Crew = 0f;
			if (float_ != 0f && float_2 != 0f && float_4 != 0f)
			{
				cargoAmmunition_0.Area = float_ * float_2 * 1.1f;
				cargoAmmunition_0.Height = float_2;
				cargoAmmunition_0.Volume = cargoAmmunition_0.Area * cargoAmmunition_0.Height;
				cargoAmmunition_0.Size = RestartList(float_, float_2, float_2);
				cargoAmmunition_0.Mass = float_4 / 1000f;
			}
			else if (EstimateCargoWeaponData(ref sqliteConnection_0, int_0, ref float_, ref float_2, ref float_3, ref float_4))
			{
				cargoAmmunition_0.Area = float_ * float_2;
				cargoAmmunition_0.Height = float_3;
				cargoAmmunition_0.Volume = cargoAmmunition_0.Area * cargoAmmunition_0.Height;
				cargoAmmunition_0.Size = RestartList(float_, float_2, float_3);
				cargoAmmunition_0.Mass = float_4;
			}
			else
			{
				cargoAmmunition_0.Size = CargoType.NoCargo;
			}
			return true;
		}
		return false;
	}

	public static bool EstimateCargoWeaponData(ref SQLiteConnection sqliteConnection_0, int int_0, ref float float_0, ref float float_1, ref float float_2, ref float float_3)
	{
		if (sqliteConnection_0 == null)
		{
			return false;
		}
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT DataWeapon.ID AS ID, DataWarhead.ProjectileCaliber AS Caliber FROM DataWeapon LEFT JOIN DataWeaponWarheads ON DataWeapon.ID = DataWeaponWarheads.ID LEFT JOIN DataWarhead ON DataWeaponWarheads.ComponentID = DataWarhead.ID WHERE DataWeapon.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count <= 0)
		{
			return false;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(datatable.Rows[0]["Caliber"]);
		if (objectValue is int)
		{
			switch (Conversions.ToInteger(objectValue))
			{
			default:
				return false;
			case 2001:
			case 3001:
				float_0 = 0.26f;
				float_1 = 0.1f;
				float_2 = 0.16f;
				float_3 = 0.03f;
				break;
			case 2002:
			case 3002:
				float_0 = 0.43f;
				float_1 = 0.19f;
				float_2 = 0.36f;
				float_3 = 0.04f;
				break;
			case 2003:
			case 3003:
				float_0 = 0.1f;
				float_1 = 0.05f;
				float_2 = 0.16f;
				float_3 = 0.003f;
				break;
			case 2004:
			case 3004:
				float_0 = 0.12f;
				float_1 = 0.05f;
				float_2 = 0.2f;
				float_3 = 0.005f;
				break;
			case 2005:
			case 3005:
				float_0 = 0.34f;
				float_1 = 0.13f;
				float_2 = 0.08f;
				float_3 = 0.03f;
				break;
			case 2006:
			case 3006:
				float_0 = 0.6f;
				float_1 = 0.16f;
				float_2 = 0.16f;
				float_3 = 0.05f;
				break;
			case 2007:
			case 3007:
				float_0 = 0.8f;
				float_1 = 0.21f;
				float_2 = 0.21f;
				float_3 = 0.12f;
				break;
			case 2008:
			case 3008:
				float_0 = 3.2f;
				float_1 = 0.41f;
				float_2 = 0.41f;
				float_3 = 0.9f;
				break;
			}
			return true;
		}
		float_0 = 1f;
		float_1 = 1f;
		float_2 = 1f;
		float_3 = 0.1f;
		return true;
	}

	public static DataTable GetAllMounts(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT ID, Name || ' (' || Comments || ')' as Name ";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			_InterceptorReader += ", Deprecated ";
		}
		_InterceptorReader += " from DataMount";
		return DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
	}

	public static DataTable GetAllCargoWeapons(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		bool flag = false;
		_InterceptorReader = "SELECT ID, Name, Length, Span, Weight";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
			{
				flag = true;
				_InterceptorReader += ", Deprecated";
			}
			else
			{
				_InterceptorReader += ", 'FALSE' AS Deprecated";
			}
		}
		_InterceptorReader += " FROM DataWeapon WHERE ((Length <> 0 AND Span <> 0 AND Weight <> 0) OR Type = 2004) ORDER BY Name";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("unitType", typeof(string));
		dataTable.Columns.Add("ID", typeof(int));
		dataTable.Columns.Add("Name", typeof(string));
		dataTable.Columns.Add("Cargo_Type", typeof(int));
		dataTable.Columns.Add("Cargo_Mass", typeof(float));
		dataTable.Columns.Add("Cargo_Area", typeof(float));
		dataTable.Columns.Add("Cargo_Crew", typeof(int));
		dataTable.Columns.Add("Cargo_ParadropCapable", typeof(bool));
		dataTable.Columns.Add("Deprecated");
		int num = 0;
		bool flag2 = false;
		for (int i = datatable.Rows.Count - 1; i >= 0; i += -1)
		{
			DataRow dataRow = datatable.Rows[i];
			if (!flag || !Conversions.ToBoolean(dataRow["Deprecated"]))
			{
				int num2 = Conversions.ToInteger(dataRow["ID"]);
				string text = Conversions.ToString(dataRow["Name"]);
				float float_ = Conversions.ToSingle(dataRow["Length"]);
				float float_2 = Conversions.ToSingle(dataRow["Span"]);
				float float_3 = 0f;
				float float_4 = Conversions.ToSingle(dataRow["Weight"]);
				CargoType cargoType = CargoType.NoCargo;
				float num3 = float_ * float_2 * 1.1f;
				if (float_ != 0f && float_2 != 0f && float_4 != 0f)
				{
					cargoType = RestartList(float_, float_2, float_2);
					float_4 /= 1000f;
				}
				else if (EstimateCargoWeaponData(ref sqliteConnection_0, num2, ref float_, ref float_2, ref float_3, ref float_4))
				{
					num3 = float_ * float_2;
					cargoType = RestartList(float_, float_2, float_3);
				}
				if (cargoType != 0)
				{
					object[] values = new object[9] { "Munition", num2, text, cargoType, float_4, num3, num, flag2, false };
					dataTable.Rows.Add(values);
				}
			}
		}
		dataTable.DefaultView.Sort = "Name ASC";
		return dataTable.DefaultView.ToTable();
	}

	public static DataTable GetAllCargoMounts(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT 'Mount' AS UnitType, ID, Name || ' (' || Comments || ')' as Name, Cargo_Type, Cargo_Mass, Cargo_Area, Cargo_Crew, Cargo_ParadropCapable";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			_InterceptorReader += ", Deprecated";
		}
		_InterceptorReader += " from DataMount where Cargo_Type <> 0 order by Name";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				if (Conversions.ToInteger(dataRow["Cargo_Type"]) == 1000 && (Conversions.ToSingle(dataRow["Cargo_Mass"]) == 0f || Conversions.ToSingle(dataRow["Cargo_Area"]) == 0f))
				{
					int num = Conversions.ToInteger(dataRow["Cargo_Crew"]);
					dataRow["Cargo_Mass"] = (float)num * Mount.PersonnelMass;
					dataRow["Cargo_Area"] = (float)num * Mount.PersonnelArea;
				}
			}
			return datatable;
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	public static DataTable GetAllCargoContainers(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataContainer"))
		{
			_InterceptorReader = "Select * ";
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (CheckColumnExists_SQLite("DataContainer", "Deprecated", sqliteConnection_0))
				{
					_InterceptorReader += ", Deprecated";
				}
				else
				{
					_InterceptorReader += ", 'FALSE' AS Deprecated";
				}
			}
			_InterceptorReader += " FROM DataContainer WHERE IsHold != 1 ORDER BY Name";
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("UnitType");
			dataTable.Columns.Add("ID");
			dataTable.Columns.Add("Name");
			dataTable.Columns.Add("Cargo_Type");
			dataTable.Columns.Add("Cargo_Mass");
			dataTable.Columns.Add("Cargo_Area");
			dataTable.Columns.Add("Cargo_Crew");
			dataTable.Columns.Add("Cargo_ParadropCapable");
			bool flag = CheckColumnExists_SQLite("DataContainer", "Container_ParadropCapable", sqliteConnection_0);
			bool flag2 = CheckColumnExists_SQLite("DataContainer", "Container_Crew", sqliteConnection_0);
			for (int i = datatable.Rows.Count - 1; i >= 0; i += -1)
			{
				DataRow dataRow = datatable.Rows[i];
				if (!Conversions.ToBoolean(dataRow["IsHold"]))
				{
					float float_ = Conversions.ToSingle(dataRow["Length"]);
					float float_2 = Conversions.ToSingle(dataRow["Width"]);
					float float_3 = Conversions.ToSingle(dataRow["Height"]);
					int num = (int)((Conversions.ToInteger(dataRow["Type"]) == 3001) ? RestartList(float_, float_2, 0f) : RestartList(float_, float_2, float_3));
					bool flag3 = flag && Conversions.ToBoolean(dataRow["Container_ParadropCapable"]);
					float num2 = (flag2 ? Conversions.ToSingle(dataRow["Container_Crew"]) : 0f);
					float num3 = TestList(float_, float_2);
					dataTable.Rows.Add("Container", dataRow["ID"], dataRow["Name"], num, Conversions.ToSingle(dataRow["Weight"]) / 1000f, num3, num2, flag3);
				}
			}
			return dataTable;
		}
		return new DataTable();
	}

	public static DataTable GetAllCargoGroundUnits(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			if (CheckColumnExists_SQLite("DataGroundUnit", "Self_Cargo_Type", sqliteConnection_0))
			{
				_InterceptorReader = "SELECT 'Ground Unit' AS UnitType, ID, Name || ' (' || Comments || ')' as Name, Self_Cargo_Type AS Cargo_Type, Self_Cargo_Mass as Cargo_Mass, Self_Cargo_Area as Cargo_Area, CASE WHEN Self_Cargo_Crew IS NULL OR Self_Cargo_Crew = 0 THEN Crew ELSE Self_Cargo_Crew END AS Cargo_Crew, Self_Cargo_ParadropCapable as Cargo_ParadropCapable";
			}
			else
			{
				_InterceptorReader = "SELECT 'Ground Unit' AS UnitType, ID, Name || ' (' || Comments || ')' as Name, CASE WHEN Category = 1000 THEN '1000' ELSE '4000' END AS Cargo_Type, Mass / 1000 as Cargo_Mass, Area as Cargo_Area, Crew as Cargo_Crew, 'FALSE' as Cargo_ParadropCapable";
			}
			if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
			{
				if (CheckColumnExists_SQLite("DataGroundUnit", "Deprecated", sqliteConnection_0))
				{
					_InterceptorReader += ", Deprecated";
				}
				else
				{
					_InterceptorReader += ", 'FALSE' AS Deprecated";
				}
			}
			_InterceptorReader += " from DataGroundUnit order by Name";
			return DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
		}
		return new DataTable();
	}

	public static DataTable GetAllCargoFacilities(ref SQLiteConnection sqliteConnection_0, DataTable dataTable_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string text = "Select 'Mobile Facility' as UnitType, ID, Name || ' (' || Comments || ')' as Name";
		text += ", 3000 AS Cargo_Type, 0 as Cargo_Mass, 0 AS Cargo_Area, 0 AS Cargo_Crew, 'FALSE' AS Cargo_ParadropCapable";
		if (CheckColumnExists_SQLite("DataMount", "Deprecated", sqliteConnection_0))
		{
			text = (CheckColumnExists_SQLite("DataFacility", "Deprecated", sqliteConnection_0) ? (text + ", Deprecated") : (text + ", 'FALSE' AS Deprecated"));
		}
		text += " FROM DataFacility WHERE MountsAreAimpoints <> 0 AND (Category = 5001 OR Category = 5002 OR Category = 5003 OR Category = 5004 OR Category = 5005)";
		text += " ORDER BY Name";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
		DataTable datatable2 = DBCache.GetDatatable(sqliteHelper_, "SELECT ID, ComponentID FROM DataFacilityMounts ORDER BY ID");
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				CargoType cargoType = CargoType.NoCargo;
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				bool flag = true;
				DataRow[] array = datatable2.Select("ID = " + dataRow["ID"].ToString());
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					DataRow[] array2 = dataTable_0.Select("ID = " + Conversions.ToInteger(array[i]["ComponentID"]));
					if (array2.Count() > 0)
					{
						CargoType cargoType2 = (CargoType)Conversions.ToInteger(array2[0]["Cargo_Type"]);
						if (cargoType2 != 0)
						{
							if (cargoType2 > cargoType)
							{
								cargoType = cargoType2;
							}
							num += Conversions.ToSingle(array2[0]["Cargo_Mass"]);
							num2 += Conversions.ToSingle(array2[0]["Cargo_Area"]);
							num3 += Conversions.ToSingle(array2[0]["Cargo_Crew"]);
							if (flag)
							{
								flag = Conversions.ToBoolean(array2[0]["Cargo_ParadropCapable"]);
							}
							if (cargoType == CargoType.Personnel && (num == 0f || num2 == 0f))
							{
								num = num3 * Mount.PersonnelMass;
								num2 = num3 * Mount.PersonnelArea;
							}
							dataRow["Cargo_Type"] = cargoType;
							dataRow["Cargo_Mass"] = num;
							dataRow["Cargo_Area"] = num2;
							dataRow["Cargo_Crew"] = num3;
							dataRow["Cargo_ParadropCapable"] = flag;
							continue;
						}
						dataRow["Cargo_Type"] = 0;
						break;
					}
					dataRow["Cargo_Type"] = 0;
					break;
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
		for (int j = datatable.Rows.Count - 1; j >= 0; j += -1)
		{
			if (Conversions.ToInteger(datatable.Rows[j]["Cargo_Type"]) == 0)
			{
				datatable.Rows.RemoveAt(j);
			}
		}
		return datatable;
	}

	public static DataTable GetAllCargoItems(ref SQLiteConnection sqliteConnection_0)
	{
		DataTable allCargoGroundUnits = GetAllCargoGroundUnits(ref sqliteConnection_0);
		DataTable allCargoMounts = GetAllCargoMounts(ref sqliteConnection_0);
		DataTable allCargoFacilities = GetAllCargoFacilities(ref sqliteConnection_0, allCargoMounts);
		DataTable allCargoContainers = GetAllCargoContainers(ref sqliteConnection_0);
		DataTable dataTable = allCargoGroundUnits;
		if (dataTable.Rows.Count <= 0)
		{
			dataTable = allCargoContainers;
		}
		else
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = allCargoContainers.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					dataTable.Rows.Add(dataRow.ItemArray);
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
		if (dataTable.Rows.Count <= 0)
		{
			dataTable = allCargoFacilities;
		}
		else
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = allCargoFacilities.Rows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow dataRow2 = (DataRow)enumerator2.Current;
					dataTable.Rows.Add(dataRow2.ItemArray);
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
		if (dataTable.Rows.Count <= 0)
		{
			return allCargoMounts;
		}
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = allCargoMounts.Rows.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				DataRow dataRow3 = (DataRow)enumerator3.Current;
				dataTable.Rows.Add(dataRow3.ItemArray);
			}
			return dataTable;
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
	}

	public static DataTable GetAllMags(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT ID, Name || ' (' || Comments || ')' as Name from DataMagazine";
		return DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
	}

	public static DataTable GetAllSensors(ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT ID, Name || ' (' || Comments || ')' as Name, Name || ' (' || Comments || ')' as LongName, Type";
		if (CheckColumnExists_SQLite("DataWeaponSensor", "Deprecated", sqliteConnection_0))
		{
			_InterceptorReader += ", Deprecated ";
		}
		_InterceptorReader += " from DataSensor";
		return DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
	}

	public static DataTable GetAllWeaponRecs_Preformatted(ref SQLiteConnection sqliteConnection_0)
	{
		DataTable result = null;
		try
		{
			SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
			DataTable dataTable = new DataTable();
			_InterceptorReader = "SELECT DataWeaponRecord.ID, DataWeaponRecord.ComponentID, DataWeaponRecord.DefaultLoad, DataWeaponRecord.MaxLoad, DataWeaponRecord.ROF, DataWeaponRecord.Multiple, DataWeapon.Name";
			if (CheckColumnExists_SQLite("DataWeaponRecord", "Deprecated", sqliteConnection_0))
			{
				_InterceptorReader += ", DataWeaponRecord.Deprecated ";
			}
			_InterceptorReader += " from DataWeaponRecord INNER JOIN DataWeapon on DataWeapon.ID = DataWeaponRecord.ComponentID";
			object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sQLiteHelper, _InterceptorReader));
			if (objectValue == null)
			{
				sQLiteHelper.OpenConnection();
				SQLiteDataReader val;
				using (DbCommand dbCommand = sQLiteHelper.theConnection.CreateCommand())
				{
					dbCommand.CommandText = _InterceptorReader;
					val = (SQLiteDataReader)dbCommand.ExecuteReader();
				}
				int fieldCount = ((DbDataReader)val).FieldCount;
				int num = fieldCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dataTable.Columns.Add(((DbDataReader)val).GetName(i), ((DbDataReader)val).GetFieldType(i));
				}
				dataTable.Columns.Add("Description", typeof(string));
				StringBuilder stringBuilder = new StringBuilder();
				while (((DbDataReader)val).Read())
				{
					DataRow dataRow = dataTable.NewRow();
					int num2 = fieldCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						dataRow[j] = RuntimeHelpers.GetObjectValue(((DbDataReader)val)[j]);
					}
					stringBuilder.Clear();
					stringBuilder.Append(RuntimeHelpers.GetObjectValue(dataRow[6])).Append(" (").Append(RuntimeHelpers.GetObjectValue(dataRow[2]))
						.Append("/")
						.Append(RuntimeHelpers.GetObjectValue(dataRow[3]))
						.Append(") - ROF:")
						.Append(RuntimeHelpers.GetObjectValue(dataRow[4]));
					dataRow[fieldCount] = stringBuilder.ToString();
					dataTable.Rows.Add(dataRow);
				}
				((DbDataReader)val).Close();
				val = null;
				sQLiteHelper.CloseConnection();
				DBCache.SetCustomObject(sQLiteHelper, _InterceptorReader, dataTable);
				result = dataTable;
				return result;
			}
			result = (DataTable)objectValue;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static DataTable GetAllWeapons(bool bool_0, ref Scenario scenario_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		if (bool_0)
		{
			if (!Information.IsNothing(scenario_0) && !scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
			{
				_InterceptorReader = "SELECT DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin";
				if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					_InterceptorReader += ", Deprecated";
				}
				_InterceptorReader += " from DataWeapon";
			}
			else
			{
				_InterceptorReader = "SELECT DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin, DataWeapon.TargetAltitudeMax_ASL, DataWeapon.TargetAltitudeMin_ASL";
				if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
				{
					_InterceptorReader += ", Deprecated";
				}
				_InterceptorReader += " from DataWeapon";
			}
		}
		else if (!Information.IsNothing(scenario_0) && !scenario_0.FeatureCompatibility.GetWeaponAGL_ASL(scenario_0.DBConnection))
		{
			_InterceptorReader = "Select DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin";
			if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
			{
				_InterceptorReader += ", Deprecated";
			}
			_InterceptorReader += " from DataWeapon where DataWeapon.Type Not In (2005, 2006, 2007, 2008, 3001, 3002, 3003, 3004, 4003, 9001, 9002, 9003)";
		}
		else
		{
			_InterceptorReader = "Select DataWeapon.ID, DataWeapon.Name, DataWeapon.Type, DataWeapon.TargetAltitudeMax, DataWeapon.TargetAltitudeMin, DataWeapon.TargetAltitudeMax_ASL, DataWeapon.TargetAltitudeMin_ASL";
			if (CheckColumnExists_SQLite("DataWeapon", "Deprecated", sqliteConnection_0))
			{
				_InterceptorReader += ", Deprecated";
			}
			_InterceptorReader += " From DataWeapon Where DataWeapon.Type Not In (2005, 2006, 2007, 2008, 3001, 3002, 3003, 3004, 4003, 9001, 9002, 9003)";
		}
		return DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
	}

	public static Weapon._WeaponType GetWeaponType(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "Select type from DataWeapon where ID=" + Conversions.ToString(int_0);
		return (Weapon._WeaponType)Conversions.ToShort(DBCache.GetScalar(sqliteHelper_, _InterceptorReader));
	}

	public static void GetSatellite(ref Scenario scenario_0, ref Satellite satellite_0, int int_0, int int_1 = 0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * from DataSatellite where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new Exception("No satellite With ID " + Conversions.ToString(int_0) + " was found in the current database!");
		}
		DataRow dataRow = datatable.Rows[0];
		satellite_0.DBID = int_0;
		satellite_0.UnitClass = dataRow["Name"].ToString();
		if (!datatable.Columns.Contains("OODADetectionCycle"))
		{
			datatable.Columns.Add("OODADetectionCycle", typeof(string));
			dataRow["OODADetectionCycle"] = 0;
		}
		if (!datatable.Columns.Contains("OODATargetingCycle"))
		{
			datatable.Columns.Add("OODATargetingCycle", typeof(string));
			dataRow["OODATargetingCycle"] = 0;
		}
		if (!datatable.Columns.Contains("OODAEvasiveCycle"))
		{
			datatable.Columns.Add("OODAEvasiveCycle", typeof(string));
			dataRow["OODAEvasiveCycle"] = 0;
		}
		satellite_0.m_TokenVal = Conversions.ToShort(dataRow["OODADetectionCycle"].ToString());
		satellite_0._IndexerVal = Conversions.ToShort(dataRow["OODATargetingCycle"].ToString());
		satellite_0._ResolverVal = Conversions.ToShort(dataRow["OODAEvasiveCycle"].ToString());
		if (datatable.Columns.Contains("Category"))
		{
			satellite_0.Category = (Satellite._SatelliteCategory)Conversions.ToInteger(dataRow["Category"]);
		}
		if (datatable.Columns.Contains("Type"))
		{
			satellite_0.Type = (Satellite._SatelliteType)Conversions.ToInteger(dataRow["Type"]);
		}
		if (datatable.Columns.Contains("Length"))
		{
			satellite_0.Length = Conversions.ToSingle(dataRow["Length"]);
		}
		if (datatable.Columns.Contains("Span"))
		{
			satellite_0.Span = Conversions.ToSingle(dataRow["Span"]);
		}
		if (datatable.Columns.Contains("Height"))
		{
			satellite_0.Height = Conversions.ToSingle(dataRow["Height"]);
		}
		if (datatable.Columns.Contains("WeightEmpty"))
		{
			satellite_0.WeightEmpty = Conversions.ToDouble(dataRow["WeightEmpty"]);
		}
		if (datatable.Columns.Contains("WeightMax"))
		{
			satellite_0.WeightMax = Conversions.ToDouble(dataRow["WeightMax"]);
		}
		if (datatable.Columns.Contains("WeightPayload"))
		{
			satellite_0.WeightPayload = Conversions.ToDouble(dataRow["WeightPayload"]);
		}
		if (datatable.Columns.Contains("Armor"))
		{
			satellite_0.Armor = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["Armor"]);
		}
		if (datatable.Columns.Contains("DamagePoints"))
		{
			satellite_0.DamagePoints = Conversions.ToSingle(dataRow["DamagePoints"]);
		}
		try
		{
			satellite_0.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (int_1 != 0)
		{
			_InterceptorReader = "Select * from DataSatelliteOrbits where ID = " + Conversions.ToString(int_0) + " And ComponentNumber = " + Conversions.ToString(int_1);
			datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
			dataRow = datatable.Rows[0];
			satellite_0.Name = dataRow["MissonName"].ToString();
			if (datatable.Columns.Contains("TLE") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["TLE"])) && Operators.CompareString(dataRow["TLE"].ToString(), "-", TextCompare: false) != 0)
			{
				string[] orbit_OT = (from theStr in Conversions.ToString(dataRow["TLE"]).Split(Conversions.ToCharArrayRankOne(Environment.NewLine))
					where !string.IsNullOrEmpty(theStr)
					select theStr).ToArray();
				satellite_0.Kinematics.SetOrbit_OT(orbit_OT);
			}
			else
			{
				long num = Conversions.ToLong(dataRow["Apogee"]) * 1000;
				long num2 = Conversions.ToLong(dataRow["Perigee"]) * 1000;
				if (num < num2)
				{
					num ^= num2;
					num2 = num ^ num2;
					num ^= num2;
				}
				satellite_0.Kinematics.SetOrbit_Tukey(Conversions.ToSingle(dataRow["Inclination"]), num, num2);
			}
			satellite_0.LaunchDate = Conversions.ToDate(dataRow["LaunchDate"]);
			satellite_0.DeOrbitDate = Conversions.ToDate(dataRow["DeOrbitingDate"]);
		}
		if (bool_0)
		{
			PopulateSensors(satellite_0, int_0);
			PopulateComms(satellite_0, int_0);
			ActiveUnit activeUnit_ = satellite_0;
			PopulateMounts(ref scenario_0, ref activeUnit_, int_0);
		}
	}

	public static void PopulateAirFacilities(ref Platform platform_0, int int_0)
	{
		string text = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(platform_0.ParentScen.DBConnection);
		switch (platform_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineAircraftFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityAircraftFacilities";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitAircraftFacilities";
			break;
		}
		_InterceptorReader = "select * from " + text + " where id = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int int_ = Conversions.ToInteger(datatable.Rows[i]["ComponentID"]);
			SQLiteConnection sqliteConnection_ = platform_0.ParentScen.DBConnection;
			AirFacility airFacility = GetAirFacility(int_, ref sqliteConnection_, platform_0);
			platform_0.AddAirFacility(airFacility);
		}
	}

	public static void PopulateDockFacilities(ref Platform platform_0, int int_0)
	{
		string text = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(platform_0.ParentScen.DBConnection);
		switch (platform_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineDockingFacilities";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityDockingFacilities";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitDockingFacilities";
			break;
		}
		_InterceptorReader = "select * from " + text + " where id = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			int int_ = Conversions.ToInteger(datatable.Rows[i]["ComponentID"]);
			SQLiteConnection sqliteConnection_ = platform_0.ParentScen.DBConnection;
			DockFacility dockFacility = GetDockFacility(int_, ref sqliteConnection_, platform_0);
			platform_0.AddDockFacility(dockFacility);
		}
	}

	internal static IMobileGroundUnit._MobileUnitCategory InstantiateList(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		Dictionary<IMobileGroundUnit._MobileUnitCategory, int> dictionary = new Dictionary<IMobileGroundUnit._MobileUnitCategory, int>();
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "select DataFacility.ID, DataFacility.Name from DataFacility, DataFacilityMounts where DataFacilityMounts.ID = DataFacility.ID and DataFacilityMounts.ComponentID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IMobileGroundUnit._MobileUnitCategory key = Facility.MobileUnitCategory(((DataRow)enumerator.Current)["Name"].ToString());
				if (dictionary.ContainsKey(key))
				{
					dictionary[key]++;
				}
				else
				{
					dictionary.Add(key, 1);
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
		if (dictionary.Count == 0)
		{
			return IMobileGroundUnit._MobileUnitCategory.None;
		}
		return dictionary.OrderByDescending((KeyValuePair<IMobileGroundUnit._MobileUnitCategory, int> theKVP) => theKVP.Value).First().Key;
	}

	public static AirFacility GetAirFacility(int int_0, ref SQLiteConnection sqliteConnection_0, ActiveUnit activeUnit_0 = null)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "Select * from DataAircraftFacility where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		_ = datatable.Rows.Count;
		DataRow dataRow = datatable.Rows[0];
		string scalar = DBCache.GetScalar(sqliteHelper_, "Select Description from EnumAircraftFacilityType where ID = " + dataRow["Type"].ToString());
		int num = Conversions.ToInteger(dataRow["PhysicalSize"]);
		GlobalVariables.AircraftSizeClass aircraftSizeClass = PrepareList(num);
		if (aircraftSizeClass == GlobalVariables.AircraftSizeClass.None && num != 1001 && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		string text = "";
		text = (DBOps.DBHasLegacyRunwayLengthEnum ? DBCache.GetScalar(sqliteHelper_, "Select Description from EnumAircraftFacilityPhysicalSize where ID = " + dataRow["PhysicalSize"].ToString()) : Misc.Description(aircraftSizeClass, sqliteConnection_0));
		GlobalVariables.RunwayLengthClass runwayLengthClass_ = InsertList(Conversions.ToInteger(dataRow["RunwayLength"]));
		return new AirFacility(activeUnit_0, scalar + " (" + dataRow["capacity"].ToString() + "x " + text + ")", (AirFacility._AirFacType)Conversions.ToShort(dataRow["Type"]), (int)aircraftSizeClass, Conversions.ToInteger(dataRow["Capacity"]), runwayLengthClass_)
		{
			DBID = int_0
		};
	}

	public static DockFacility GetDockFacility(int int_0, ref SQLiteConnection sqliteConnection_0, ActiveUnit activeUnit_0 = null)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "Select * from DataDockingFacility where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		_ = datatable.Rows.Count;
		DataRow dataRow = datatable.Rows[0];
		string scalar = DBCache.GetScalar(sqliteHelper_, "Select Description from EnumDockingFacilityType where ID = " + dataRow["Type"].ToString());
		string scalar2 = DBCache.GetScalar(sqliteHelper_, "Select Description from EnumDockingFacilityPhysicalSize where ID = " + dataRow["PhysicalSize"].ToString());
		DockFacility.DockingPhysicalSize dockingPhysicalSize_ = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSize"]);
		return new DockFacility(activeUnit_0, scalar + " (" + dataRow["capacity"].ToString() + "x " + scalar2 + ")", (DockFacility.DockFacilityType)Conversions.ToShort(dataRow["Type"]), dockingPhysicalSize_, Conversions.ToByte(dataRow["Capacity"]))
		{
			DBID = int_0
		};
	}

	public static int GetCommDeviceID(string string_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "Select ID from DataComm where Name = '" + string_0 + "'";
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, _InterceptorReader));
	}

	public static void PopulateMagazines(ref Platform platform_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(platform_0.ParentScen.DBConnection);
		string text = null;
		switch (platform_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraftMagazines";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShipMagazines";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarineMagazines";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacilityMagazines";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnitMagazines";
			break;
		}
		_InterceptorReader = "SELECT theTable.* FROM " + text + " as theTable, DataMagazine WHERE theTable.ComponentID = DataMagazine.ID And theTable.ID = " + Conversions.ToString(int_0) + " ORDER BY DataMagazine.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Magazine magazine = GetMagazine(Conversions.ToInteger(datatable.Rows[i]["ComponentID"]), ref platform_0.ParentScen);
			platform_0.AddSharedMagazine(magazine);
			magazine.ParentPlatform = platform_0;
		}
	}

	public static int smethod_1(string string_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT ID from DataMagazine where Name='" + Misc.ReadRequest(string_0) + "'";
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_));
	}

	public static Magazine GetMagazine(int int_0, ref Scenario scenario_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select * From DataMagazine where ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		DataRow dataRow = datatable.Rows[0];
		Magazine magazine_ = new Magazine(null, Conversions.ToInteger(dataRow["ID"]), Conversions.ToString(dataRow["Name"]), (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Capacity"]), Conversions.ToBoolean(dataRow["AviationMagazine"]));
		try
		{
			magazine_.Hypothetical = Conversions.ToBoolean(dataRow["Hypothetical"]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200478", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
		if (bool_0)
		{
			CreateList(ref magazine_, ref scenario_0);
		}
		return magazine_;
	}

	private static void CreateList(ref Magazine magazine_0, ref Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT DataWeaponRecord.* FROM DataMagazineWeapons, DataWeaponRecord, DataWeapon WHERE DataMagazineWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMagazineWeapons.ID = " + Conversions.ToString(magazine_0.DBID) + " ORDER BY DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec weaponRec = new WeaponRec(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), bool_0: false, bool_1: false);
			weaponRec.ResetTimeToFire();
			magazine_0.Weapons.Add(weaponRec);
		}
	}

	public static Tuple<string, string, string> GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, Scenario scenario_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		string text = null;
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			text = "DataAircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			text = "DataShip";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			text = "DataSubmarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			text = "DataFacility";
			break;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			text = "DataWeapon";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			text = "DataSatellite";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			text = "DataGroundUnit";
			break;
		}
		_InterceptorReader = "Select EnumOperatorCountry.Description As Country, YearCommissioned, YearDecommissioned FROM " + text + " Left Join EnumOperatorCountry On EnumOperatorCountry.ID = " + text + ".OperatorCountry where " + text + ".ID=" + Conversions.ToString(int_0);
		DataRow dataRow = sQLiteHelper.ComputeSpecification(_InterceptorReader).Rows[0];
		string item = Conversions.ToString(dataRow["Country"]);
		string item2 = Conversions.ToString(dataRow["YearCommissioned"]);
		string item3 = Conversions.ToString(dataRow["YearDecommissioned"]);
		return new Tuple<string, string, string>(item, item2, item3);
	}

	public static string[] GetPlatformsThatCarryThisWeapon(int int_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		HashSet<string> hashSet = new HashSet<string>();
		_InterceptorReader = "Select DISTINCT DataAircraft.ID As ID, DataAircraft.Name, EnumOperatorCountry.Description As Country, YearCommissioned FROM DataAircraft \r\n    Left JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry\r\n\tLEFT JOIN DataAircraftLoadouts ON DataAircraftLoadouts.ID = DataAircraft.ID \r\n\tLEFT JOIN DataLoadoutWeapons ON DataLoadoutWeapons.ID = DataAircraftLoadouts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataLoadoutWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Country"])) ? "N/A" : Conversions.ToString(dataRow["Country"]));
				hashSet.Add("飞机_" + Conversions.ToString(dataRow["ID"]) + "_" + Conversions.ToString(dataRow["Name"]) + "_" + text + "_" + Conversions.ToString(dataRow["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		_InterceptorReader = "SELECT DISTINCT DataAircraft.ID, DataAircraft.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataAircraft\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry  \r\n\tLeft Join DataAircraftMounts ON DataAircraftMounts.ID = DataAircraft.ID \r\n    Left Join DataMountWeapons ON DataMountWeapons.ID = DataAircraftMounts.ComponentID \r\n    Left Join DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n    WHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = datatable.Rows.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DataRow dataRow2 = (DataRow)enumerator2.Current;
				string text2 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow2["Country"])) ? "N/A" : Conversions.ToString(dataRow2["Country"]));
				hashSet.Add("飞机_" + Conversions.ToString(dataRow2["ID"]) + "_" + Conversions.ToString(dataRow2["Name"]) + "_" + text2 + "_" + Conversions.ToString(dataRow2["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		_InterceptorReader = "SELECT DISTINCT DataShip.ID, DataShip.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataShip\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataShip.OperatorCountry\r\n\tLEFT JOIN DataShipMounts ON DataShipMounts.ID = DataShip.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataShipMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = datatable.Rows.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				DataRow dataRow3 = (DataRow)enumerator3.Current;
				string text3 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow3["Country"])) ? "N/A" : Conversions.ToString(dataRow3["Country"]));
				hashSet.Add("舰船_" + Conversions.ToString(dataRow3["ID"]) + "_" + Conversions.ToString(dataRow3["Name"]) + "_" + text3 + "_" + Conversions.ToString(dataRow3["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
		_InterceptorReader = "SELECT DISTINCT DataSubmarine.ID, DataSubmarine.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSubmarine\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSubmarine.OperatorCountry\r\n\tLEFT JOIN DataSubmarineMounts ON DataSubmarineMounts.ID = DataSubmarine.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataSubmarineMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator4 = null;
		try
		{
			enumerator4 = datatable.Rows.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				DataRow dataRow4 = (DataRow)enumerator4.Current;
				string text4 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow4["Country"])) ? "N/A" : Conversions.ToString(dataRow4["Country"]));
				hashSet.Add("潜艇_" + Conversions.ToString(dataRow4["ID"]) + "_" + Conversions.ToString(dataRow4["Name"]) + "_" + text4 + "_" + Conversions.ToString(dataRow4["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator4 is IDisposable)
			{
				(enumerator4 as IDisposable).Dispose();
			}
		}
		_InterceptorReader = "SELECT DISTINCT DataFacility.ID, DataFacility.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataFacility\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataFacility.OperatorCountry \r\n\tLEFT JOIN DataFacilityMounts ON DataFacilityMounts.ID = DataFacility.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataFacilityMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator5 = null;
		try
		{
			enumerator5 = datatable.Rows.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				DataRow dataRow5 = (DataRow)enumerator5.Current;
				string text5 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow5["Country"])) ? "N/A" : Conversions.ToString(dataRow5["Country"]));
				hashSet.Add("设施_" + Conversions.ToString(dataRow5["ID"]) + "_" + Conversions.ToString(dataRow5["Name"]) + "_" + text5 + "_" + Conversions.ToString(dataRow5["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator5 is IDisposable)
			{
				(enumerator5 as IDisposable).Dispose();
			}
		}
		_InterceptorReader = "SELECT DISTINCT DataSatellite.ID, DataSatellite.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSatellite\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSatellite.OperatorCountry\r\n\tLEFT JOIN DataSatelliteMounts ON DataSatelliteMounts.ID = DataSatellite.ID \r\n\tLEFT JOIN DataMountWeapons ON DataMountWeapons.ID = DataSatelliteMounts.ComponentID \r\n\tLEFT JOIN DataWeaponRecord ON DataWeaponRecord.ID = DataMountWeapons.ComponentID \r\n\tWHERE DataWeaponRecord.ComponentID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		IEnumerator enumerator6 = null;
		try
		{
			enumerator6 = datatable.Rows.GetEnumerator();
			while (enumerator6.MoveNext())
			{
				DataRow dataRow6 = (DataRow)enumerator6.Current;
				string text6 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow6["Country"])) ? "N/A" : Conversions.ToString(dataRow6["Country"]));
				hashSet.Add("卫星_" + Conversions.ToString(dataRow6["ID"]) + "_" + Conversions.ToString(dataRow6["Name"]) + "_" + text6 + "_" + Conversions.ToString(dataRow6["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator6 is IDisposable)
			{
				(enumerator6 as IDisposable).Dispose();
			}
		}
		return hashSet.ToArray();
	}

	public static string[] GetPlatformsThatCarryThisSensor(int int_0, Scenario scenario_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		HashSet<string> hashSet = new HashSet<string>();
		string string_ = "SELECT DISTINCT DataAircraft.ID, DataAircraft.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataAircraft\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataAircraft.OperatorCountry  \r\n\tJOIN DataAircraftSensors ON DataAircraftSensors.ID = DataAircraft.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataAircraftSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				string text = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Country"])) ? "N/A" : Conversions.ToString(dataRow["Country"]));
				hashSet.Add("飞机_" + Conversions.ToString(dataRow["ID"]) + "_" + Conversions.ToString(dataRow["Name"]) + "_" + text + "_" + Conversions.ToString(dataRow["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		string_ = "SELECT DISTINCT DataShip.ID, DataShip.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataShip\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataShip.OperatorCountry\r\n\tJOIN DataShipSensors ON DataShipSensors.ID = DataShip.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataShipSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = datatable.Rows.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DataRow dataRow2 = (DataRow)enumerator2.Current;
				string text2 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow2["Country"])) ? "N/A" : Conversions.ToString(dataRow2["Country"]));
				hashSet.Add("舰船_" + Conversions.ToString(dataRow2["ID"]) + "_" + Conversions.ToString(dataRow2["Name"]) + "_" + text2 + "_" + Conversions.ToString(dataRow2["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		string_ = "Select DISTINCT DataSubmarine.ID, DataSubmarine.Name, EnumOperatorCountry.Description As Country, YearCommissioned From DataSubmarine\r\n    Left Join EnumOperatorCountry ON EnumOperatorCountry.ID = DataSubmarine.OperatorCountry\r\n    Join DataSubmarineSensors ON DataSubmarineSensors.ID = DataSubmarine.ID \r\n    Join DataSensor ON DataSensor.ID = DataSubmarineSensors.ComponentID\r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = datatable.Rows.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				DataRow dataRow3 = (DataRow)enumerator3.Current;
				string text3 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow3["Country"])) ? "N/A" : Conversions.ToString(dataRow3["Country"]));
				hashSet.Add("潜艇_" + Conversions.ToString(dataRow3["ID"]) + "_" + Conversions.ToString(dataRow3["Name"]) + "_" + text3 + "_" + Conversions.ToString(dataRow3["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
		string_ = "SELECT DISTINCT DataFacility.ID, DataFacility.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataFacility\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataFacility.OperatorCountry \r\n\tJOIN DataFacilitySensors ON DataFacilitySensors.ID = DataFacility.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataFacilitySensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator4 = null;
		try
		{
			enumerator4 = datatable.Rows.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				DataRow dataRow4 = (DataRow)enumerator4.Current;
				string text4 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow4["Country"])) ? "N/A" : Conversions.ToString(dataRow4["Country"]));
				hashSet.Add("设施_" + Conversions.ToString(dataRow4["ID"]) + "_" + Conversions.ToString(dataRow4["Name"]) + "_" + text4 + "_" + Conversions.ToString(dataRow4["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator4 is IDisposable)
			{
				(enumerator4 as IDisposable).Dispose();
			}
		}
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataGroundUnit"))
		{
			string_ = "SELECT DISTINCT DataGroundUnit.ID, DataGroundUnit.Name, EnumOperatorCountry.Description As Country, YearCommissioned From DataGroundUnit\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataGroundUnit.OperatorCountry \r\n    JOIN DataGroundUnitSensors ON DataGroundUnitSensors.ID = DataGroundUnit.ID \r\n    JOIN DataSensor ON DataSensor.ID = DataGroundUnitSensors.ComponentID \r\n    WHERE DataSensor.ID = " + Conversions.ToString(int_0);
			datatable = DBCache.GetDatatable(sQLiteHelper, string_);
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = datatable.Rows.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					DataRow dataRow5 = (DataRow)enumerator5.Current;
					string text5 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow5["Country"])) ? "N/A" : Conversions.ToString(dataRow5["Country"]));
					hashSet.Add("GroundUnit_" + Conversions.ToString(dataRow5["ID"]) + "_" + Conversions.ToString(dataRow5["Name"]) + "_" + text5 + "_" + Conversions.ToString(dataRow5["YearCommissioned"]));
				}
			}
			finally
			{
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
		}
		string_ = "SELECT DISTINCT DataSatellite.ID, DataSatellite.Name, EnumOperatorCountry.Description as Country, YearCommissioned FROM DataSatellite\r\n    LEFT JOIN EnumOperatorCountry ON EnumOperatorCountry.ID = DataSatellite.OperatorCountry\r\n\tJOIN DataSatelliteSensors ON DataSatelliteSensors.ID = DataSatellite.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataSatelliteSensors.ComponentID \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator6 = null;
		try
		{
			enumerator6 = datatable.Rows.GetEnumerator();
			while (enumerator6.MoveNext())
			{
				DataRow dataRow6 = (DataRow)enumerator6.Current;
				string text6 = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow6["Country"])) ? "N/A" : Conversions.ToString(dataRow6["Country"]));
				hashSet.Add("卫星_" + Conversions.ToString(dataRow6["ID"]) + "_" + Conversions.ToString(dataRow6["Name"]) + "_" + text6 + "_" + Conversions.ToString(dataRow6["YearCommissioned"]));
			}
		}
		finally
		{
			if (enumerator6 is IDisposable)
			{
				(enumerator6 as IDisposable).Dispose();
			}
		}
		string_ = "SELECT  DISTINCT DataWeapon.ID, DataWeapon.Name FROM DataWeapon\r\n\tJOIN DataWeaponSensors ON DataWeaponSensors.ID = DataWeapon.ID \r\n\tJOIN DataSensor ON DataSensor.ID = DataWeaponSensors.ComponentID  \r\n\tWHERE DataSensor.ID = " + Conversions.ToString(int_0);
		datatable = DBCache.GetDatatable(sQLiteHelper, string_);
		IEnumerator enumerator7 = null;
		try
		{
			enumerator7 = datatable.Rows.GetEnumerator();
			while (enumerator7.MoveNext())
			{
				DataRow dataRow7 = (DataRow)enumerator7.Current;
				string text7 = "N/A";
				hashSet.Add("武器_" + Conversions.ToString(dataRow7["ID"]) + "_" + Conversions.ToString(dataRow7["Name"]) + "_" + text7 + "_" + Conversions.ToString(0));
			}
		}
		finally
		{
			if (enumerator7 is IDisposable)
			{
				(enumerator7 as IDisposable).Dispose();
			}
		}
		return hashSet.ToArray();
	}

	public static void PopulatePropulsion(ActiveUnit activeUnit_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		string value = "";
		switch (activeUnit_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			value = "DataAircraftPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			value = "DataShipPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			value = "DataSubmarinePropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			value = "DataFacilityPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			value = "DataWeaponPropulsion";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			value = "DataGroundUnitPropulsion";
			break;
		}
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataPropulsion.* from DataPropulsion, ").Append(value).Append(" As theTable where DataPropulsion.ID = theTable.ComponentID And theTable.ID = ")
			.Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<ClientProcessProducer> list = DBCache.AssetImporter<ClientProcessProducer>(sqliteHelper_, _InterceptorReader);
		int count = list.Count;
		if (activeUnit_0.IsAircraft)
		{
			foreach (ClientProcessProducer item in list)
			{
				long iD = item.ID;
				int int_ = Conversions.ToInteger(iD.ToString());
				string text = item.Name;
				if (text.Split(Conversions.ToCharArrayRankOne(" ")).ToArray().Length > 1 && text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0].EndsWith("x"))
				{
					string text2 = text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0];
					text = text.Substring(text2.Length + 1);
				}
				if (item._AdapterSetter.HasValue)
				{
					int num = (int)Math.Round(item._AdapterSetter.Value);
					if (num <= 0)
					{
						Exception exception_ = new Exception("Incomplete propulsion - AC database # " + Conversions.ToString(int_0) + " has 0 engines");
						GameGeneral.WriteExceptionsToLog(ref exception_);
					}
					else
					{
						int num2 = num;
						for (int i = 1; i <= num2; i++)
						{
							iD = item.ID;
							Engine engine = GetEngine(Conversions.ToInteger(iD.ToString()), ref activeUnit_0);
							engine.Name = text + " #" + Conversions.ToString(i);
							activeUnit_0.Propulsion.Add(engine);
						}
					}
				}
				else if (text.Split(Conversions.ToCharArrayRankOne(" ")).ToArray().Length > 1 && text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0].EndsWith("x"))
				{
					string text3 = text.Split(Conversions.ToCharArrayRankOne(" ")).ToList()[0];
					int num3 = Conversions.ToInteger(text3.Substring(0, text3.Length - 1));
					for (int j = 1; j <= num3; j++)
					{
						Engine engine2 = GetEngine(int_, ref activeUnit_0);
						engine2.Name = text + " #" + Conversions.ToString(j);
						activeUnit_0.Propulsion.Add(engine2);
					}
				}
				else
				{
					int num4 = count - 1;
					for (int k = 0; k <= num4; k++)
					{
						_ = list[k];
						Engine engine3 = GetEngine(int_, ref activeUnit_0);
						activeUnit_0.Propulsion.Add(engine3);
					}
				}
			}
			return;
		}
		int num5 = count - 1;
		for (int l = 0; l <= num5; l++)
		{
			Engine engine4 = GetEngine(Conversions.ToInteger(list[l].ID.ToString()), ref activeUnit_0);
			activeUnit_0.Propulsion.Add(engine4);
		}
	}

	public static void PopulateComms(ActiveUnit activeUnit_0, int int_0)
	{
		string value = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		if (activeUnit_0.IsAircraft)
		{
			value = "DataAircraftComms";
		}
		else if (activeUnit_0.IsWeapon)
		{
			value = "DataWeaponComms";
		}
		else if (activeUnit_0.IsShip)
		{
			value = "DataShipComms";
		}
		else if (activeUnit_0.IsSubmarine)
		{
			value = "DataSubmarineComms";
		}
		else if (activeUnit_0.IsFacility)
		{
			value = "DataFacilityComms";
		}
		else if (activeUnit_0.IsMobileGroundUnit)
		{
			value = "DataGroundUnitComms";
		}
		else if (activeUnit_0.IsSatellite)
		{
			value = "DataSatelliteComms";
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataComm.ID As CommID, theTable.* From DataComm, ").Append(value).Append(" As theTable Where DataComm.ID = theTable.ComponentID And theTable.ID = ")
			.Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<CodeObjectListener> list = DBCache.AssetImporter<CodeObjectListener>(sqliteHelper_, _InterceptorReader);
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			CodeObjectListener codeObjectListener = list[i];
			CommDevice commDevice = GetCommDevice((int)codeObjectListener.m_ExceptionSetter, ref activeUnit_0);
			commDevice.ParentSpecific = codeObjectListener.exporterSetter;
			if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Sonobuoy)
			{
				commDevice.ParentSpecific = false;
			}
			activeUnit_0.AddCommDevice(commDevice);
		}
	}

	public static void PopulateWarheads(ref Warhead[] warhead_0, ref Weapon weapon_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(weapon_0.ParentScen.DBConnection);
		_InterceptorReader = "Select ComponentID From DataWeaponWarheads Where ID =" + Conversions.ToString(weapon_0.DBID);
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "ComponentID");
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Warhead warhead = GetWarhead(weapon_0.ParentScen, (int)list[i]);
			ArrayExtensions.Add(ref warhead_0, warhead);
		}
	}

	public static Warhead GetWarhead(Scenario scenario_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataWarhead.* From DataWarhead Where ID =").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		ComparatorSetter comparatorSetter = DBCache.AssetImporter<ComparatorSetter>(sqliteHelper_, _InterceptorReader).Last();
		return new Warhead(comparatorSetter.Name, (float)comparatorSetter.DamagePoints, (Warhead.WarheadType)comparatorSetter.setterSetter, (Warhead.WarheadExplosivesType)comparatorSetter._TemplateSetter, (Warhead.WarheadCaliber)comparatorSetter.m_CreatorSetter, comparatorSetter.m_MockSetter.ToString())
		{
			DBID = int_0,
			ClusterBombDispersionAreaLength = (short)comparatorSetter._TagSetter,
			ClusterBombDispersionAreaWidth = (short)comparatorSetter._FieldSetter,
			ExplosivesWeight = (float)comparatorSetter.m_MappingSetter,
			Hypothetical = comparatorSetter.m_QueueSetter
		};
	}

	public static void GetESMSpecificParameters(ref Sensor sensor_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * From DataSensor Where ID = ").Append(sensor_0.DBID);
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString());
		int num = datatableTyped.Rows.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			sensor_0.m_Sensitivity = Conversions.ToSingle(dtrRow["ESMSensitivity"]);
			sensor_0.m_SystemLoss = Conversions.ToSingle(dtrRow["ESMSystemLoss"]);
			sensor_0.m_ESMNumberOfChannels = Conversions.ToShort(dtrRow["ESMNumberOfChannels"]);
			sensor_0.ESM_PreciseEmitterID = Conversions.ToBoolean(dtrRow["ESMPreciseEmitterID"]);
		}
	}

	public static void GetCommDeviceFlags(ref CommDevice commDevice_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "Select CodeID From DataCommCapabilities Where ID = " + Conversions.ToString(commDevice_0.DBID);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			switch (Conversions.ToInteger(datatable.Rows[i]["CodeID"]))
			{
			case 1300:
				commDevice_0.Flags.LOS_Limited = true;
				continue;
			case 1201:
				commDevice_0.Flags.Receive_Only = true;
				continue;
			case 1200:
				commDevice_0.Flags.Send_Only = true;
				continue;
			case 1450:
				commDevice_0.Flags.Low_Probability_Of_Intercept = true;
				continue;
			case 1402:
				commDevice_0.Flags.Broadcast = true;
				continue;
			case 1401:
				commDevice_0.Flags.Secure = true;
				continue;
			case 3001:
				commDevice_0.Flags.ELF_Radio = true;
				continue;
			case 3002:
				commDevice_0.Flags.SLF_Radio = true;
				continue;
			case 3003:
				commDevice_0.Flags.ULF_Radio = true;
				continue;
			case 3004:
				commDevice_0.Flags.VLF_Radio = true;
				continue;
			case 3005:
				commDevice_0.Flags.LF_Radio = true;
				continue;
			case 3006:
				commDevice_0.Flags.MF_Radio = true;
				continue;
			case 3007:
				commDevice_0.Flags.HF_Radio = true;
				continue;
			case 3008:
				commDevice_0.Flags.VHF_Radio = true;
				continue;
			case 3009:
				commDevice_0.Flags.UHF_Radio = true;
				continue;
			case 3010:
				commDevice_0.Flags.SHF_Radio = true;
				continue;
			case 3011:
				commDevice_0.Flags.EHF_Radio = true;
				continue;
			case 1500:
				commDevice_0.Flags.Jam_Resistant = true;
				continue;
			case 1475:
				commDevice_0.Flags.Phased_Array_Antenna = true;
				continue;
			case 4000:
				commDevice_0.Flags.DaisyChain = true;
				continue;
			case 3110:
				commDevice_0.Flags.BLOS_MEO = true;
				continue;
			case 3100:
				commDevice_0.Flags.BLOS_LEO = true;
				continue;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public static void GetRadarSpecificParameters(ref Sensor sensor_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * From DataSensor Where ID = ").Append(sensor_0.DBID);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		ParamSetter paramSetter = DBCache.AssetImporter<ParamSetter>(sqliteHelper_, _InterceptorReader).First();
		sensor_0.m_RadarHorBeamwidth = (float)paramSetter.m_PageSetter;
		sensor_0.m_RadarVerBeamwidth = (float)paramSetter._RulesSetter;
		sensor_0.m_SystemNoiseLevel_SearchOrTrack = (float)paramSetter._MethodSetter;
		sensor_0.m_ProcessingGain_SearchOrTrack = (float)paramSetter.serviceSetter;
		sensor_0.m_PowerOutputW_SearchOrTrack = (float)paramSetter.m_SystemSetter;
		sensor_0.m_PulseWidth_SearchOrTrack = (float)paramSetter.m_CandidateSetter;
		sensor_0.m_RadarBlindTime_SearchOrTrack = (float)paramSetter._BaseSetter;
		sensor_0.m_PRF_SearchOrTrack = paramSetter.policySetter;
		sensor_0.m_RadarHorBeamwidth_Illuminate = (float)paramSetter._BroadcasterSetter;
		sensor_0.m_RadarVerBeamwidth_Illuminate = (float)paramSetter.m_IdentifierSetter;
		sensor_0.m_SystemNoiseLevel_Illuminate = (float)paramSetter.m_PrinterSetter;
		sensor_0.m_ProcessingGain_Illuminate = (float)paramSetter._ParserSetter;
		sensor_0.m_PowerOutputW_Illuminate = (float)paramSetter._AlgoSetter;
		sensor_0.m_PulseWidth_Illuminate = (float)paramSetter.m_DatabaseSetter;
		sensor_0.m_RadarBlindTimeIlluminate = (float)paramSetter.interceptorSetter;
		sensor_0.m_PRF_Illuminate = paramSetter._MessageSetter;
	}

	private static AltBand[] CompareList(int int_0, ref ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.ParentScen.Cache_PowerplantAltBands.TryGetValue(int_0, out var value))
		{
			return value;
		}
		GameGeneral.ThreadStaticSB.Clear();
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		GameGeneral.ThreadStaticSB.Append("Select * From DataPropulsionPerformance As tPAS Where tPAS.ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, _InterceptorReader);
		bool flag = !datatableTyped.Columns.Contains("AltitudeBand");
		int num = datatableTyped.Rows.Count();
		Dictionary<int, AltBand> dictionary = new Dictionary<int, AltBand>(num);
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			int key = (flag ? Conversions.ToInteger(dtrRow["Band"]) : Conversions.ToInteger(dtrRow["AltitudeBand"]));
			AltBand altBand;
			if (dictionary.ContainsKey(key))
			{
				altBand = dictionary[key];
			}
			else
			{
				altBand = new AltBand(Conversions.ToSingle(dtrRow["AltitudeMax"]), Conversions.ToSingle(dtrRow["AltitudeMin"]));
				dictionary.Add(key, altBand);
			}
			switch (Conversions.ToByte(dtrRow["Throttle"]))
			{
			case 1:
				altBand.Consumption_Loiter = Conversions.ToSingle(dtrRow["Consumption"]);
				altBand.Speed_Loiter = Conversions.ToInteger(dtrRow["Speed"]);
				break;
			case 2:
				altBand.Consumption_Cruise = Conversions.ToSingle(dtrRow["Consumption"]);
				altBand.Speed_Cruise = Conversions.ToInteger(dtrRow["Speed"]);
				break;
			case 3:
				altBand.Consumption_Full = Conversions.ToSingle(Conversions.ToString(dtrRow["Consumption"]));
				altBand.Speed_Full = (long?)dtrRow["Speed"];
				break;
			case 4:
				altBand.Consumption_Flank = Conversions.ToSingle(Conversions.ToString(dtrRow["Consumption"]));
				altBand.Speed_Flank = (long?)dtrRow["Speed"];
				break;
			}
		}
		value = dictionary.Values.ToArray();
		activeUnit_0.ParentScen.Cache_PowerplantAltBands.TryAdd(int_0, value);
		return value;
	}

	public static Engine GetEngine(int int_0, ref ActiveUnit activeUnit_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataPropulsion.* From DataPropulsion Where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<ClassListenerMapping> list = DBCache.AssetImporter<ClassListenerMapping>(sqliteHelper_, _InterceptorReader);
		if (list.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		_ = list.Count;
		ClassListenerMapping classListenerMapping = list.First();
		return new Engine(activeUnit_0, (int)classListenerMapping.ID, classListenerMapping.Name, (Engine.EngineType)classListenerMapping._ProductSetter)
		{
			ParentPlatform = activeUnit_0,
			Hypothetical = classListenerMapping.m_IteratorSetter,
			AltBands = CompareList(int_0, ref activeUnit_0)
		};
	}

	public static CommDevice GetCommDevice(int int_0, ref ActiveUnit activeUnit_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * From DataComm Where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<PageExpressionDic> list = DBCache.AssetImporter<PageExpressionDic>(sqliteHelper_, _InterceptorReader);
		if (list.Count == 0)
		{
			throw new PlatformComponentNotFoundException();
		}
		CommDevice commDevice_ = null;
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			PageExpressionDic pageExpressionDic = list[i];
			commDevice_ = new CommDevice(activeUnit_0, activeUnit_0.ParentScen, (int)pageExpressionDic.ID, pageExpressionDic.Name, (CommDevice.CommLinkType)pageExpressionDic.m_AccountSetter, pageExpressionDic.m_StateSetter, (int)pageExpressionDic.authenticationSetter, pageExpressionDic._ParamsSetter);
			commDevice_.DBID = int_0;
			try
			{
				commDevice_.Hypothetical = pageExpressionDic.m_HelperSetter;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200481", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		GetCommDeviceFreqs(ref commDevice_, activeUnit_0.ParentScen.DBConnection);
		return commDevice_;
	}

	public static string GetSensorName(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT Name from DataSensor where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static Sensor GetSensor(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		if (int_0 == 0)
		{
			return Sensor.GetEyeball(sqliteConnection_0);
		}
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		Sensor sensor = null;
		Sensor result = null;
		try
		{
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select DataSensor.*, EnumSensorRole.Description from DataSensor, EnumSensorRole where EnumSensorRole.ID = DataSensor.Role and DataSensor.ID = ").Append(int_0);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			List<DicProcessProducer> list = DBCache.AssetImporter<DicProcessProducer>(sqliteHelper_, _InterceptorReader);
			if (list.Count == 0)
			{
				throw new PlatformComponentNotFoundException("No valid sensor with ID #" + Conversions.ToString(int_0) + " ! Please pester the DB author to fix this!");
			}
			DicProcessProducer dicProcessProducer = list.First();
			int int_ = (int)dicProcessProducer.ID;
			string name = dicProcessProducer.Name;
			float float_ = (float)dicProcessProducer.m_StatusCreator;
			float float_12 = (float)dicProcessProducer.proccesorCreator;
			float float_14 = (float)dicProcessProducer._StrategyCreator;
			float float_15 = (float)dicProcessProducer._ConfigurationCreator;
			Sensor.Sensor_Type sensor_Type_ = (Sensor.Sensor_Type)dicProcessProducer.m_StructCreator;
			Sensor.Sensor_Role role = (Sensor.Sensor_Role)dicProcessProducer.Role;
			GlobalVariables.TechGenerationClass techGenerationClass_ = (GlobalVariables.TechGenerationClass)dicProcessProducer.m_MerchantCreator;
			float float_16 = (float)dicProcessProducer._ProcessCreator;
			float float_17 = (float)dicProcessProducer._DecoratorCreator;
			short _MineSweepWidth = (short)dicProcessProducer.MineSweepWidth;
			short _MineSweepMaximumSpeed = (short)dicProcessProducer.MineSweepMaximumSpeed;
			int int_2 = (int)dicProcessProducer._ValCreator;
			float float_18 = (int)dicProcessProducer._RuleCreator;
			float float_19 = (int)dicProcessProducer._ThreadCreator;
			float float_20 = (int)dicProcessProducer.m_InstanceCreator;
			float float_2 = (int)dicProcessProducer.m_CollectionCreator;
			int int_3 = (int)dicProcessProducer._ObjectCreator;
			float float_3 = (float)dicProcessProducer.m_ParameterCreator;
			float float_4 = dicProcessProducer._ExpressionCreator;
			float float_5 = (float)dicProcessProducer.m_DispatcherCreator;
			short short_3 = (short)dicProcessProducer.callbackCreator;
			short short_4 = (short)dicProcessProducer.configCreator;
			short short_5 = (short)dicProcessProducer.registryCreator;
			short short_6 = (short)dicProcessProducer.definitionCreator;
			float float_6 = dicProcessProducer.m_WrapperCreator;
			long long_ = (long)Math.Round(dicProcessProducer.m_ObserverCreator);
			long long_2 = (long)Math.Round(dicProcessProducer.issuerCreator);
			long long_3 = (long)Math.Round(dicProcessProducer.dicCreator);
			long long_4 = (long)Math.Round(dicProcessProducer._ClientCreator);
			float float_7 = (float)dicProcessProducer.taskCreator;
			float float_8 = (float)dicProcessProducer.m_FilterCreator;
			float float_9 = (float)dicProcessProducer.containerCreator;
			float float_10 = (float)dicProcessProducer.m_TestsCreator;
			float float_11 = dicProcessProducer._InterpreterCreator;
			float float_13 = (float)dicProcessProducer._ListenerCreator;
			bool serverCreator = dicProcessProducer._ServerCreator;
			sensor = new Sensor(ref sqliteConnection_0, int_, name, sensor_Type_, role, techGenerationClass_, float_16, float_17, 0, 0, 0, int_2, float_18, float_19, float_20, float_2, int_3, float_3, float_5, float_4, bool_0: false, short_3, short_4, short_5, short_6, float_6, long_, long_2, long_3, long_4, float_7, float_8, float_10, float_11, float_9, float_13, _MineSweepWidth, _MineSweepMaximumSpeed, float_, float_12, float_14, float_15, serverCreator);
			sensor.RoleDescription = dicProcessProducer.Description;
			if (Operators.CompareString(sensor.RoleDescription, "None", TextCompare: false) == 0)
			{
				sensor.RoleDescription = Get_Sensor_Type_String(ref sqliteConnection_0, (int)sensor.Type);
			}
			GetSensorDefaultAcrs(ref sensor, sqliteConnection_0);
			if (sensor.IsPingIntercept)
			{
				sensor.maxRange = 150f;
			}
			result = sensor;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static void GetSensorDefaultAcrs(ref Sensor sensor_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		try
		{
			if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "MiscSensorDefault"))
			{
				_InterceptorReader = "Select * from MiscSensorDefault WHERE ID = " + Conversions.ToString(sensor_0.DBID);
				ConnectionObjectListener connectionObjectListener = default(ConnectionObjectListener);
				connectionObjectListener.m_AttrCreator = new PlatformComponent._Coverage();
				connectionObjectListener._VisitorCreator = new PlatformComponent._Coverage();
				object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sQLiteHelper, _InterceptorReader));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && (object)objectValue.GetType() == typeof(ConnectionObjectListener))
				{
					connectionObjectListener = ((objectValue == null) ? default(ConnectionObjectListener) : ((ConnectionObjectListener)objectValue));
				}
				else
				{
					connectionObjectListener.m_AttrCreator = new PlatformComponent._Coverage();
					connectionObjectListener._VisitorCreator = new PlatformComponent._Coverage();
					DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sQLiteHelper, _InterceptorReader);
					if (datatableTyped.Rows.Count() == 0)
					{
						return;
					}
					DtrRow dtrRow = datatableTyped.Rows[0];
					connectionObjectListener.m_AttrCreator.PB1 = Conversions.ToBoolean(dtrRow["PB1"]);
					connectionObjectListener.m_AttrCreator.PB2 = Conversions.ToBoolean(dtrRow["PB2"]);
					connectionObjectListener.m_AttrCreator.PMF1 = Conversions.ToBoolean(dtrRow["PMF1"]);
					connectionObjectListener.m_AttrCreator.PMF2 = Conversions.ToBoolean(dtrRow["PMF2"]);
					connectionObjectListener.m_AttrCreator.PMA1 = Conversions.ToBoolean(dtrRow["PMA1"]);
					connectionObjectListener.m_AttrCreator.PMA2 = Conversions.ToBoolean(dtrRow["PMA2"]);
					connectionObjectListener.m_AttrCreator.PS1 = Conversions.ToBoolean(dtrRow["PS1"]);
					connectionObjectListener.m_AttrCreator.PS2 = Conversions.ToBoolean(dtrRow["PS2"]);
					connectionObjectListener.m_AttrCreator.SB1 = Conversions.ToBoolean(dtrRow["SB1"]);
					connectionObjectListener.m_AttrCreator.SB2 = Conversions.ToBoolean(dtrRow["SB2"]);
					connectionObjectListener.m_AttrCreator.SMF1 = Conversions.ToBoolean(dtrRow["SMF1"]);
					connectionObjectListener.m_AttrCreator.SMF2 = Conversions.ToBoolean(dtrRow["SMF2"]);
					connectionObjectListener.m_AttrCreator.SMA1 = Conversions.ToBoolean(dtrRow["SMA1"]);
					connectionObjectListener.m_AttrCreator.SMA2 = Conversions.ToBoolean(dtrRow["SMA2"]);
					connectionObjectListener.m_AttrCreator.SS1 = Conversions.ToBoolean(dtrRow["SS1"]);
					connectionObjectListener.m_AttrCreator.SS2 = Conversions.ToBoolean(dtrRow["SS2"]);
					connectionObjectListener._VisitorCreator.PB1 = Conversions.ToBoolean(dtrRow["PB1Max"]);
					connectionObjectListener._VisitorCreator.PB2 = Conversions.ToBoolean(dtrRow["PB2Max"]);
					connectionObjectListener._VisitorCreator.PMF1 = Conversions.ToBoolean(dtrRow["PMF1Max"]);
					connectionObjectListener._VisitorCreator.PMF2 = Conversions.ToBoolean(dtrRow["PMF2Max"]);
					connectionObjectListener._VisitorCreator.PMA1 = Conversions.ToBoolean(dtrRow["PMA1Max"]);
					connectionObjectListener._VisitorCreator.PMA2 = Conversions.ToBoolean(dtrRow["PMA2Max"]);
					connectionObjectListener._VisitorCreator.PS1 = Conversions.ToBoolean(dtrRow["PS1Max"]);
					connectionObjectListener._VisitorCreator.PS2 = Conversions.ToBoolean(dtrRow["PS2Max"]);
					connectionObjectListener._VisitorCreator.SB1 = Conversions.ToBoolean(dtrRow["SB1Max"]);
					connectionObjectListener._VisitorCreator.SB2 = Conversions.ToBoolean(dtrRow["SB2Max"]);
					connectionObjectListener._VisitorCreator.SMF1 = Conversions.ToBoolean(dtrRow["SMF1Max"]);
					connectionObjectListener._VisitorCreator.SMF2 = Conversions.ToBoolean(dtrRow["SMF2Max"]);
					connectionObjectListener._VisitorCreator.SMA1 = Conversions.ToBoolean(dtrRow["SMA1Max"]);
					connectionObjectListener._VisitorCreator.SMA2 = Conversions.ToBoolean(dtrRow["SMA2Max"]);
					connectionObjectListener._VisitorCreator.SS1 = Conversions.ToBoolean(dtrRow["SS1Max"]);
					connectionObjectListener._VisitorCreator.SS2 = Conversions.ToBoolean(dtrRow["SS2Max"]);
					DBCache.SetCustomObject(sQLiteHelper, _InterceptorReader, connectionObjectListener);
				}
				Sensor obj = sensor_0;
				obj.Coverage.PB1 = connectionObjectListener.m_AttrCreator.PB1;
				obj.Coverage.PB2 = connectionObjectListener.m_AttrCreator.PB2;
				obj.Coverage.PMF1 = connectionObjectListener.m_AttrCreator.PMF1;
				obj.Coverage.PMF2 = connectionObjectListener.m_AttrCreator.PMF2;
				obj.Coverage.PMA1 = connectionObjectListener.m_AttrCreator.PMA1;
				obj.Coverage.PMA2 = connectionObjectListener.m_AttrCreator.PMA2;
				obj.Coverage.PS1 = connectionObjectListener.m_AttrCreator.PS1;
				obj.Coverage.PS2 = connectionObjectListener.m_AttrCreator.PS2;
				obj.Coverage.SB1 = connectionObjectListener.m_AttrCreator.SB1;
				obj.Coverage.SB2 = connectionObjectListener.m_AttrCreator.SB2;
				obj.Coverage.SMF1 = connectionObjectListener.m_AttrCreator.SMF1;
				obj.Coverage.SMF2 = connectionObjectListener.m_AttrCreator.SMF2;
				obj.Coverage.SMA1 = connectionObjectListener.m_AttrCreator.SMA1;
				obj.Coverage.SMA2 = connectionObjectListener.m_AttrCreator.SMA2;
				obj.Coverage.SS1 = connectionObjectListener.m_AttrCreator.SS1;
				obj.Coverage.SS2 = connectionObjectListener.m_AttrCreator.SS2;
				obj.Coverage_Illuminate.PB1 = connectionObjectListener._VisitorCreator.PB1;
				obj.Coverage_Illuminate.PB2 = connectionObjectListener._VisitorCreator.PB2;
				obj.Coverage_Illuminate.PMF1 = connectionObjectListener._VisitorCreator.PMF1;
				obj.Coverage_Illuminate.PMF2 = connectionObjectListener._VisitorCreator.PMF2;
				obj.Coverage_Illuminate.PMA1 = connectionObjectListener._VisitorCreator.PMA1;
				obj.Coverage_Illuminate.PMA2 = connectionObjectListener._VisitorCreator.PMA2;
				obj.Coverage_Illuminate.PS1 = connectionObjectListener._VisitorCreator.PS1;
				obj.Coverage_Illuminate.PS2 = connectionObjectListener._VisitorCreator.PS2;
				obj.Coverage_Illuminate.SB1 = connectionObjectListener._VisitorCreator.SB1;
				obj.Coverage_Illuminate.SB2 = connectionObjectListener._VisitorCreator.SB2;
				obj.Coverage_Illuminate.SMF1 = connectionObjectListener._VisitorCreator.SMF1;
				obj.Coverage_Illuminate.SMF2 = connectionObjectListener._VisitorCreator.SMF2;
				obj.Coverage_Illuminate.SMA1 = connectionObjectListener._VisitorCreator.SMA1;
				obj.Coverage_Illuminate.SMA2 = connectionObjectListener._VisitorCreator.SMA2;
				obj.Coverage_Illuminate.SS1 = connectionObjectListener._VisitorCreator.SS1;
				obj.Coverage_Illuminate.SS2 = connectionObjectListener._VisitorCreator.SS2;
			}
			else
			{
				Sensor obj2 = sensor_0;
				obj2.Coverage.PB1 = true;
				obj2.Coverage.PB2 = true;
				obj2.Coverage.PMF1 = true;
				obj2.Coverage.PMF2 = true;
				obj2.Coverage.PMA1 = true;
				obj2.Coverage.PMA2 = true;
				obj2.Coverage.PS1 = true;
				obj2.Coverage.PS2 = true;
				obj2.Coverage.SB1 = true;
				obj2.Coverage.SB2 = true;
				obj2.Coverage.SMF1 = true;
				obj2.Coverage.SMF2 = true;
				obj2.Coverage.SMA1 = true;
				obj2.Coverage.SMA2 = true;
				obj2.Coverage.SS1 = true;
				obj2.Coverage.SS2 = true;
				obj2.Coverage_Illuminate.PB1 = true;
				obj2.Coverage_Illuminate.PB2 = true;
				obj2.Coverage_Illuminate.PMF1 = true;
				obj2.Coverage_Illuminate.PMF2 = true;
				obj2.Coverage_Illuminate.PMA1 = true;
				obj2.Coverage_Illuminate.PMA2 = true;
				obj2.Coverage_Illuminate.PS1 = true;
				obj2.Coverage_Illuminate.PS2 = true;
				obj2.Coverage_Illuminate.SB1 = true;
				obj2.Coverage_Illuminate.SB2 = true;
				obj2.Coverage_Illuminate.SMF1 = true;
				obj2.Coverage_Illuminate.SMF2 = true;
				obj2.Coverage_Illuminate.SMA1 = true;
				obj2.Coverage_Illuminate.SMA2 = true;
				obj2.Coverage_Illuminate.SS1 = true;
				obj2.Coverage_Illuminate.SS2 = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void PopulateSensors(ActiveUnit activeUnit_0, int int_0)
	{
		string text = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		try
		{
			if (activeUnit_0.IsAircraft)
			{
				text = "DataAircraftSensors";
			}
			else if (activeUnit_0.IsWeapon)
			{
				text = "DataWeaponSensors";
			}
			else if (activeUnit_0.IsShip)
			{
				text = "DataShipSensors";
			}
			else if (activeUnit_0.IsSubmarine)
			{
				text = "DataSubmarineSensors";
			}
			else if (activeUnit_0.IsFacility)
			{
				text = "DataFacilitySensors";
			}
			else if (activeUnit_0.IsMobileGroundUnit)
			{
				text = "DataGroundUnitSensors";
			}
			else if (activeUnit_0.IsSatellite)
			{
				text = "DataSatelliteSensors";
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select DataSensor.ID As SensorID, DataSensor.Type As SensorType, theTable.* FROM DataSensor, ").Append(text).Append(" As theTable WHERE DataSensor.ID = theTable.ComponentID And theTable.ID = ")
				.Append(int_0)
				.Append(" ORDER BY DataSensor.Type, DataSensor.Name ASC");
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			List<ContextObjectListener> list = DBCache.AssetImporter<ContextObjectListener>(sqliteHelper_, _InterceptorReader);
			Operators.CompareString(text, "DataWeaponSensors", TextCompare: false);
			bool flag = CheckColumnExists_SQLite(text, "MastHeight", activeUnit_0.ParentScen.DBConnection);
			foreach (ContextObjectListener item in list)
			{
				int int_ = (int)item.m_ExporterCreator;
				SQLiteConnection sqliteConnection_ = activeUnit_0.ParentScen.DBConnection;
				Sensor sensor = GetSensor(int_, ref sqliteConnection_);
				if (sensor.Type == Sensor.Sensor_Type.SensorGroup)
				{
					_InterceptorReader = "Select ComponentID from DataSensorSensorGroups where ID = " + Conversions.ToString(sensor.DBID);
					foreach (long item2 in DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "ComponentID"))
					{
						int int_2 = (int)item2;
						sqliteConnection_ = activeUnit_0.ParentScen.DBConnection;
						Sensor sensor2 = GetSensor(int_2, ref sqliteConnection_);
						sensor2.IsSensorInGroup = sensor.DBID;
						sensor2.Coverage.PB1 = item.m_ParamCreator;
						sensor2.Coverage.PMA1 = item.m_ServiceCreator;
						sensor2.Coverage.PMF1 = item.rulesCreator;
						sensor2.Coverage.PS1 = item._CandidateCreator;
						sensor2.Coverage.SB1 = item._CreatorCreator;
						sensor2.Coverage.SMA1 = item.tagCreator;
						sensor2.Coverage.SMF1 = item.mappingCreator;
						sensor2.Coverage.SS1 = item.queueCreator;
						sensor2.Coverage.PB2 = item.m_PageCreator;
						sensor2.Coverage.PMA2 = item._SystemCreator;
						sensor2.Coverage.PMF2 = item._MethodCreator;
						sensor2.Coverage.PS2 = item.baseCreator;
						sensor2.Coverage.SB2 = item.m_TemplateCreator;
						sensor2.Coverage.SMA2 = item.m_FieldCreator;
						sensor2.Coverage.SMF2 = item.m_MockCreator;
						sensor2.Coverage.SS2 = item.regCreator;
						sensor2.Coverage_Illuminate.PB1 = item._ProductCreator;
						sensor2.Coverage_Illuminate.PMA1 = item.roleCreator;
						sensor2.Coverage_Illuminate.PMF1 = item._IteratorCreator;
						sensor2.Coverage_Illuminate.PS1 = item.attributeCreator;
						sensor2.Coverage_Illuminate.SB1 = item.broadcasterCreator;
						sensor2.Coverage_Illuminate.SMA1 = item._AlgoCreator;
						sensor2.Coverage_Illuminate.SMF1 = item._PrinterCreator;
						sensor2.Coverage_Illuminate.SS1 = item.m_InterceptorCreator;
						sensor2.Coverage_Illuminate.PB2 = item._AnnotationCreator;
						sensor2.Coverage_Illuminate.PMA2 = item.factoryCreator;
						sensor2.Coverage_Illuminate.PMF2 = item.m_InitializerCreator;
						sensor2.Coverage_Illuminate.PS2 = item.m_EventCreator;
						sensor2.Coverage_Illuminate.SB2 = item._IdentifierCreator;
						sensor2.Coverage_Illuminate.SMA2 = item.m_DatabaseCreator;
						sensor2.Coverage_Illuminate.SMF2 = item.m_ParserCreator;
						sensor2.Coverage_Illuminate.SS2 = item.messageCreator;
						if (flag)
						{
							sensor2.MastHeight = (int)item._WorkerCreator;
						}
						sensor2.ParentPlatform = activeUnit_0;
						activeUnit_0.AddSensor(sensor2);
					}
				}
				else
				{
					sensor.Coverage.PB1 = item.m_ParamCreator;
					sensor.Coverage.PMA1 = item.m_ServiceCreator;
					sensor.Coverage.PMF1 = item.rulesCreator;
					sensor.Coverage.PS1 = item._CandidateCreator;
					sensor.Coverage.SB1 = item._CreatorCreator;
					sensor.Coverage.SMA1 = item.tagCreator;
					sensor.Coverage.SMF1 = item.mappingCreator;
					sensor.Coverage.SS1 = item.queueCreator;
					sensor.Coverage.PB2 = item.m_PageCreator;
					sensor.Coverage.PMA2 = item._SystemCreator;
					sensor.Coverage.PMF2 = item._MethodCreator;
					sensor.Coverage.PS2 = item.baseCreator;
					sensor.Coverage.SB2 = item.m_TemplateCreator;
					sensor.Coverage.SMA2 = item.m_FieldCreator;
					sensor.Coverage.SMF2 = item.m_MockCreator;
					sensor.Coverage.SS2 = item.regCreator;
					sensor.Coverage_Illuminate.PB1 = item._ProductCreator;
					sensor.Coverage_Illuminate.PMA1 = item.roleCreator;
					sensor.Coverage_Illuminate.PMF1 = item._IteratorCreator;
					sensor.Coverage_Illuminate.PS1 = item.attributeCreator;
					sensor.Coverage_Illuminate.SB1 = item.broadcasterCreator;
					sensor.Coverage_Illuminate.SMA1 = item._AlgoCreator;
					sensor.Coverage_Illuminate.SMF1 = item._PrinterCreator;
					sensor.Coverage_Illuminate.SS1 = item.m_InterceptorCreator;
					sensor.Coverage_Illuminate.PB2 = item._AnnotationCreator;
					sensor.Coverage_Illuminate.PMA2 = item.factoryCreator;
					sensor.Coverage_Illuminate.PMF2 = item.m_InitializerCreator;
					sensor.Coverage_Illuminate.PS2 = item.m_EventCreator;
					sensor.Coverage_Illuminate.SB2 = item._IdentifierCreator;
					sensor.Coverage_Illuminate.SMA2 = item.m_DatabaseCreator;
					sensor.Coverage_Illuminate.SMF2 = item.m_ParserCreator;
					sensor.Coverage_Illuminate.SS2 = item.messageCreator;
					if (flag)
					{
						sensor.MastHeight = (int)item._WorkerCreator;
					}
					sensor.ParentPlatform = activeUnit_0;
					activeUnit_0.AddSensor(sensor);
				}
			}
			if (activeUnit_0.IsPlatform && (((Platform)activeUnit_0).Crew > 0 || (!activeUnit_0.IsFixedFacility && !activeUnit_0.IsSatellite && (!activeUnit_0.IsShip || ((Ship)activeUnit_0).Type != Ship._ShipType.NGSBuoy) && (!activeUnit_0.IsAircraft || (((Aircraft)activeUnit_0).Type != Aircraft._AircraftType.UAV && ((Aircraft)activeUnit_0).Type != Aircraft._AircraftType.UCAV)) && (!activeUnit_0.IsSubmarine || (((Submarine)activeUnit_0).Type != Submarine._SubmarineType.UUV && ((Submarine)activeUnit_0).Type != Submarine._SubmarineType.ROV)))))
			{
				Sensor eyeball = Sensor.GetEyeball(activeUnit_0.ParentScen.DBConnection);
				eyeball.Coverage.PB1 = true;
				eyeball.Coverage.PMA1 = true;
				eyeball.Coverage.PMF1 = true;
				eyeball.Coverage.PS1 = true;
				eyeball.Coverage.SB1 = true;
				eyeball.Coverage.SMA1 = true;
				eyeball.Coverage.SMF1 = true;
				eyeball.Coverage.SS1 = true;
				eyeball.Coverage.PB2 = true;
				eyeball.Coverage.PMA2 = true;
				eyeball.Coverage.PMF2 = true;
				eyeball.Coverage.PS2 = true;
				eyeball.Coverage.SB2 = true;
				eyeball.Coverage.SMA2 = true;
				eyeball.Coverage.SMF2 = true;
				eyeball.Coverage.SS2 = true;
				eyeball.ParentPlatform = activeUnit_0;
				activeUnit_0.AddSensor(eyeball);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetSensorCodes(ref Sensor sensor_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorCodes where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "CodeID");
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = list[i];
			if (num2 <= 2011)
			{
				if (num2 <= 1021)
				{
					if (num2 <= 1011)
					{
						long num3 = num2 - 1001;
						if ((ulong)num3 <= 3uL && (ulong)num3 <= 3uL)
						{
							long num8 = num3;
							long num9 = num8;
							if ((ulong)num9 <= 3uL)
							{
								switch (num9)
								{
								case 0L:
									sensor_0.Codes.IFF_Capable = true;
									continue;
								case 1L:
									sensor_0.Codes.Classification = true;
									continue;
								case 2L:
									sensor_0.Codes.NCTR_JEM = true;
									continue;
								case 3L:
									sensor_0.Codes.NCTR_NBILST = true;
									continue;
								}
							}
						}
						if (num2 == 1011)
						{
							sensor_0.Codes.ContinuousTrackingCapable = true;
						}
					}
					else
					{
						switch (num2)
						{
						case 1021L:
							sensor_0.Codes.ContinousTrackingCapable_Visual = true;
							break;
						case 1012L:
							sensor_0.Codes.ContinousTrackingCapable_RadarTracker = true;
							break;
						}
					}
				}
				else if (num2 <= 2001)
				{
					long num4 = num2 - 1031;
					if ((ulong)num4 <= 2uL && (ulong)num4 <= 2uL)
					{
						long num10 = num4;
						long num11 = num10;
						if ((ulong)num11 <= 2uL)
						{
							switch (num11)
							{
							case 0L:
								sensor_0.Codes.PeriscopeSearch_Basic = true;
								continue;
							case 1L:
								sensor_0.Codes.PeriscopeAndSurfaceSearch_FineRangeResolution = true;
								continue;
							case 2L:
								sensor_0.Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing = true;
								continue;
							}
						}
					}
					if (num2 == 2001)
					{
						sensor_0.Codes.TWS = true;
					}
				}
				else
				{
					switch (num2)
					{
					case 2011L:
						sensor_0.Codes.LPI = true;
						break;
					case 2002L:
						sensor_0.Codes.MTI = true;
						break;
					}
				}
			}
			else if (num2 <= 4003)
			{
				if (num2 <= 3003)
				{
					if (num2 == 2701)
					{
						sensor_0.Codes.VisualNightCapable = true;
						continue;
					}
					long num5 = num2 - 3001;
					if ((ulong)num5 > 2uL || (ulong)num5 > 2uL)
					{
						continue;
					}
					long num12 = num5;
					long num13 = num12;
					if ((ulong)num13 <= 2uL)
					{
						switch (num13)
						{
						case 0L:
							sensor_0.Codes.Pulse_only = true;
							break;
						case 1L:
							sensor_0.Codes.Doppler_LDSD_Full = true;
							break;
						case 2L:
							sensor_0.Codes.Doppler_LDSD_Limited = true;
							break;
						}
					}
					continue;
				}
				long num6 = num2 - 3011;
				if ((ulong)num6 <= 2uL && (ulong)num6 <= 2uL)
				{
					long num14 = num6;
					long num15 = num14;
					if ((ulong)num15 <= 2uL)
					{
						switch (num15)
						{
						case 0L:
							sensor_0.Codes.PESA = true;
							continue;
						case 1L:
							sensor_0.Codes.AESA = true;
							continue;
						case 2L:
							sensor_0.Codes.SyntheticApertureRadar = true;
							continue;
						}
					}
				}
				long num7 = num2 - 4001;
				if ((ulong)num7 > 2uL || (ulong)num7 > 2uL)
				{
					continue;
				}
				long num16 = num7;
				long num17 = num16;
				if ((ulong)num17 <= 2uL)
				{
					switch (num17)
					{
					case 0L:
						sensor_0.Codes.CWI = true;
						break;
					case 1L:
						sensor_0.Codes.ICWI = true;
						break;
					case 2L:
						sensor_0.Codes.bool_0 = true;
						break;
					}
				}
			}
			else
			{
				switch (num2)
				{
				case 6001L:
					sensor_0.Codes.GeneratesAAWFireControl = true;
					break;
				case 5001L:
					sensor_0.Codes.FrequencyAgile = true;
					break;
				case 9102L:
					sensor_0.Codes.ShallowWaterCapable_Full = true;
					break;
				case 9101L:
					sensor_0.Codes.ShallowWaterCapable_Partial = true;
					break;
				}
			}
		}
	}

	public static List<string> GetSensorFlagDescriptions(int int_0, SQLiteConnection sqliteConnection_0)
	{
		string text = "";
		string text2 = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		List<string> list = new List<string>();
		text = "DataSensorCodes";
		text2 = "EnumSensorCode";
		_InterceptorReader = "SELECT EC.* from " + text2 + " as EC, " + text + " as DC where EC.ID = DC.CodeID and DC.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (datatable.Rows.Count == 0)
		{
			return list;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = datatable.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				list.Add(Conversions.ToString(dataRow["Description"]));
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

	public static void GetSensorCapabilities(ref Sensor sensor_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		try
		{
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select CodeID from DataSensorCapabilities where ID = ").Append(int_0);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "CodeID");
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				long num2 = list[i];
				if (num2 <= 4005)
				{
					if (num2 <= 1023)
					{
						long num3 = num2 - 1001;
						if ((ulong)num3 <= 10uL && (ulong)num3 <= 10uL)
						{
							long num7 = num3;
							long num8 = num7;
							if ((ulong)num8 <= 10uL)
							{
								switch (num8)
								{
								case 0L:
									break;
								case 2L:
									goto IL_0313;
								case 1L:
									goto IL_0326;
								default:
									goto IL_0339;
								case 7L:
								case 8L:
								case 9L:
									goto IL_03bf;
								case 10L:
									goto IL_03d5;
								case 6L:
									goto IL_03e5;
								case 5L:
									goto IL_03f5;
								case 4L:
									goto IL_0405;
								case 3L:
									goto IL_0415;
								}
								sensor_0.Capabilities.AirSearch = true;
								continue;
							}
						}
						goto IL_0339;
					}
					long num4 = num2 - 2001;
					if ((ulong)num4 <= 3uL && (ulong)num4 <= 3uL)
					{
						long num9 = num4;
						long num10 = num9;
						if ((ulong)num10 <= 3uL)
						{
							switch (num10)
							{
							case 0L:
								sensor_0.Capabilities.RangeInfo = true;
								continue;
							case 1L:
								sensor_0.Capabilities.AltitudeInfo = true;
								continue;
							case 2L:
								sensor_0.Capabilities.SpeedInfo = true;
								continue;
							case 3L:
								sensor_0.Capabilities.HeadingInfo = true;
								continue;
							}
						}
					}
					long num5 = num2 - 4001;
					if ((ulong)num5 <= 4uL && (ulong)num5 <= 4uL)
					{
						long num11 = num5;
						long num12 = num11;
						if ((ulong)num12 <= 4uL)
						{
							switch (num12)
							{
							case 0L:
								sensor_0.Capabilities.NavigationOnly = true;
								continue;
							case 1L:
								sensor_0.Capabilities.GroundMappingOnly = true;
								continue;
							case 2L:
								sensor_0.Capabilities.TerrainAvoidanceFollowingOnly = true;
								continue;
							case 3L:
								sensor_0.Capabilities.WeatherOnly = true;
								continue;
							case 4L:
								sensor_0.Capabilities.WeatherAndNavigationOnly = true;
								continue;
							}
						}
					}
				}
				else
				{
					switch (num2)
					{
					case 9002L:
						sensor_0.Capabilities.OTH_SurfaceWave = true;
						continue;
					case 9001L:
						sensor_0.Capabilities.OTH_Backscatter = true;
						continue;
					case 10001L:
					case 10002L:
						continue;
					}
				}
				goto IL_03bf;
				IL_03d5:
				sensor_0.Capabilities.SpaceSearch_ABM = true;
				continue;
				IL_0326:
				sensor_0.Capabilities.SurfaceSearch = true;
				continue;
				IL_0339:
				long num6 = num2 - 1021;
				if ((ulong)num6 <= 2uL && (ulong)num6 <= 2uL)
				{
					long num13 = num6;
					long num14 = num13;
					if ((ulong)num14 <= 2uL)
					{
						switch (num14)
						{
						case 0L:
							sensor_0.Capabilities.Mine_Obstacle_Search = true;
							continue;
						case 1L:
							sensor_0.Capabilities.TorpedoWarning = true;
							continue;
						case 2L:
							sensor_0.Capabilities.MissileApproachWarning = true;
							continue;
						}
					}
				}
				goto IL_03bf;
				IL_0313:
				sensor_0.Capabilities.SubSearch = true;
				continue;
				IL_03bf:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				continue;
				IL_0415:
				sensor_0.Capabilities.LandSearch_Fixed = true;
				continue;
				IL_0405:
				sensor_0.Capabilities.LandSearch_Mobile = true;
				continue;
				IL_03f5:
				sensor_0.Capabilities.PeriscopeSearch = true;
				continue;
				IL_03e5:
				sensor_0.Capabilities.C_RAM = true;
			}
			if (sensor_0.Type == Sensor.Sensor_Type.ESM)
			{
				sensor_0.Capabilities.AirSearch = true;
				sensor_0.Capabilities.SurfaceSearch = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetCommDeviceFreqs(ref CommDevice commDevice_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		try
		{
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select * from DataCommCapabilities where ID = ").Append(commDevice_0.DBID);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "CodeID");
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				long num2 = list[i];
				if ((ulong)(num2 - 1200) > 1uL && num2 != 1300 && (ulong)(num2 - 1401) > 1uL)
				{
					Sensor.FrequencyBand item = (Sensor.FrequencyBand)list[i];
					commDevice_0.UsedFrequencies.Add(item);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void GetSensorSearchFreqs(ref Sensor sensor_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		if (sensor_0.Type == Sensor.Sensor_Type.NonDetectingEmitter && sensor_0.SearchFreqs.Count() == 0 && sensor_0.IlluminationFreqs.Count() == 0 && sensor_0.classFacade != 0)
		{
			int_0 = sensor_0.classFacade;
		}
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorFrequencySearchAndTrack where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "Frequency");
		int count = list.Count;
		sensor_0.SearchFreqs = new Sensor.RadioElectronicFrequency[count - 1 + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor.RadioElectronicFrequency radioElectronicFrequency = new Sensor.RadioElectronicFrequency((Sensor.FrequencyBand)list[i]);
			sensor_0.SearchFreqs[i] = radioElectronicFrequency;
		}
	}

	public static void GetSensorIlluminationFreqs(ref Sensor sensor_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		if (sensor_0.Type == Sensor.Sensor_Type.NonDetectingEmitter && sensor_0.SearchFreqs.Count() == 0 && sensor_0.IlluminationFreqs.Count() == 0 && sensor_0.classFacade != 0)
		{
			int_0 = sensor_0.classFacade;
		}
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * from DataSensorFrequencyIlluminate where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, _InterceptorReader);
		int num = datatableTyped.Rows.Count();
		sensor_0.IlluminationFreqs = new Sensor.RadioElectronicFrequency[num - 1 + 1];
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			Sensor.RadioElectronicFrequency radioElectronicFrequency = new Sensor.RadioElectronicFrequency((Sensor.FrequencyBand)Conversions.ToLong(datatableTyped.Rows[i]["Frequency"]));
			sensor_0.IlluminationFreqs[i] = radioElectronicFrequency;
		}
	}

	public static bool CheckFeatureCompatibility(int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "Select count(*) FROM sqlite_master WHERE type='table' AND name='Capabilities'";
		if (Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_)) == 0)
		{
			return false;
		}
		if (int_0 == 0)
		{
			return true;
		}
		string_ = "SELECT Count(*) from Capabilities where ID='" + Conversions.ToString(int_0) + "'";
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_)) > 0;
	}

	public static XSection[] GetXSections(ActiveUnit activeUnit_0)
	{
		string value = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
		switch (activeUnit_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			value = "DataAircraftSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			value = "DataShipSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			value = "DataSubmarineSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			value = "DataFacilitySignatures";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			value = "DataWeaponSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Satellite:
			value = "DataSatelliteSignatures";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			value = "DataGroundUnitSignatures";
			break;
		}
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select * From ").Append(value).Append(" as theTable where theTable.ID = ")
			.Append(activeUnit_0.DBID);
		DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, GameGeneral.ThreadStaticSB.ToString());
		int num = datatableTyped.Rows.Count();
		XSection[] array = new XSection[num - 1 + 1];
		int num2 = num - 1;
		for (int i = 0; i <= num2; i++)
		{
			DtrRow dtrRow = datatableTyped.Rows[i];
			array[i] = new XSection((XSection._SignatureType)Conversions.ToShort(dtrRow["Type"]), Conversions.ToSingle(dtrRow["Front"]), Conversions.ToSingle(dtrRow["Side"]), Conversions.ToSingle(dtrRow["Rear"]), 0f);
		}
		return array;
	}

	public static void PopulateFuel(ActiveUnit activeUnit_0, int int_0)
	{
		string value = "";
		try
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(activeUnit_0.ParentScen.DBConnection);
			switch (activeUnit_0.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				value = "DataAircraftFuel";
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				value = "DataShipFuel";
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				value = "DataSubmarineFuel";
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				value = "DataFacilityFuel";
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				value = "DataWeaponFuel";
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				value = "DataGroundUnitFuel";
				break;
			}
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select * From ").Append(value).Append(" as theTable where theTable.ID = ")
				.Append(int_0);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "ComponentID");
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				GameGeneral.ThreadStaticSB.Clear();
				GameGeneral.ThreadStaticSB.Append("Select * From DataFuel where ID = ").Append(list[i].ToString());
				_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
				AlgoConfigObject algoConfigObject = DBCache.AssetImporter<AlgoConfigObject>(sqliteHelper_, _InterceptorReader).First();
				FuelRec fuelRec = new FuelRec((int)algoConfigObject.m_StateCreator, (short)algoConfigObject.m_AccountCreator);
				fuelRec.DBID = (int)algoConfigObject.ID;
				activeUnit_0.AddFuelRec(fuelRec);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101291", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static int GetMountIDByName(string string_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT ID from DataMount where Name='" + string_0 + "'";
		return Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_));
	}

	public static string GetMountName(int int_0, ref Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		string string_ = "SELECT Name from DataMount where ID='" + Conversions.ToString(int_0) + "'";
		return DBCache.GetScalar(sqliteHelper_, string_);
	}

	public static CargoType GetMountCargoType(int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		string string_ = "SELECT Cargo_Type from DataMount where ID='" + Conversions.ToString(int_0) + "'";
		return (CargoType)Conversions.ToInteger(DBCache.GetScalar(sqliteHelper_, string_));
	}

	public static int GetNearestAimpointfacilityMatchForThisMount(int int_0, ref Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT ID, Name from DataFacility where MountsAreAimpoints<>0 AND ID in (Select ID from DataFacilityMounts where ComponentID = " + Conversions.ToString(int_0) + ")";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		switch (datatable.Rows.Count)
		{
		default:
		{
			string mountName = GetMountName(int_0, ref scenario_0);
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					dictionary.Add(Conversions.ToInteger(dataRow["ID"]), Misc.LevenshteinDistance(mountName, Conversions.ToString(dataRow["Name"])));
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return dictionary.OrderBy((KeyValuePair<int, int> theKVP) => theKVP.Value).ElementAtOrDefault(0).Key;
		}
		case 1:
			return Conversions.ToInteger(datatable.Rows[0]["ID"]);
		case 0:
			return 0;
		}
	}

	public static Mount GetMount(int int_0, ref Scenario scenario_0, bool bool_0 = true)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("Select DataMount.* from DataMount WHERE DataMount.ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		object objectValue = RuntimeHelpers.GetObjectValue(DBCache.GetCustomObject(sqliteHelper_, _InterceptorReader));
		ContainerRuleWatcher containerRuleWatcher;
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && (object)objectValue.GetType() == typeof(ContainerRuleWatcher))
		{
			containerRuleWatcher = ((objectValue == null) ? default(ContainerRuleWatcher) : ((ContainerRuleWatcher)objectValue));
		}
		else
		{
			DataTableTyped datatableTyped = DBCache.GetDatatableTyped(sqliteHelper_, _InterceptorReader);
			if (datatableTyped.Rows.Count() == 0)
			{
				throw new PlatformComponentNotFoundException();
			}
			DtrRow dtrRow = datatableTyped.Rows[0];
			containerRuleWatcher = default(ContainerRuleWatcher);
			containerRuleWatcher.ID = int_0;
			containerRuleWatcher.Name = Conversions.ToString(dtrRow["Name"]);
			containerRuleWatcher._AuthenticationCreator = (GlobalVariables.ArmorRating)Conversions.ToShort(dtrRow["ArmorGeneral"]);
			containerRuleWatcher._ParamsCreator = Conversions.ToInteger(dtrRow["ROF"]);
			containerRuleWatcher.helperCreator = Conversions.ToInteger(dtrRow["MagazineROF"]);
			containerRuleWatcher.infoCreator = Conversions.ToInteger(dtrRow["Capacity"]);
			containerRuleWatcher._MapperCreator = Conversions.ToInteger(dtrRow["MagazineCapacity"]);
			containerRuleWatcher._MerchantMap = Conversions.ToBoolean(dtrRow["Autonomous"]);
			containerRuleWatcher.m_ManagerCreator = Conversions.ToBoolean(dtrRow["Logistic"]);
			containerRuleWatcher.m_ProducerCreator = Conversions.ToBoolean(dtrRow["CanHotReload"]);
			containerRuleWatcher.m_CallbackMap = Conversions.ToBoolean(dtrRow["LocalControl"]);
			containerRuleWatcher.m_StructMap = Conversions.ToBoolean(dtrRow["Trainable"]);
			containerRuleWatcher.DamagePoints = Conversions.ToSingle(dtrRow["DamagePoints"]);
			containerRuleWatcher._GetterCreator = Conversions.ToBoolean(dtrRow["ReserveTarget"]);
			if (datatableTyped.Columns.Contains("Hypothetical"))
			{
				containerRuleWatcher.decoratorMap = Conversions.ToBoolean(dtrRow["Hypothetical"]);
			}
			if (datatableTyped.Columns.Contains("Cargo_Crew"))
			{
				try
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Crew"])))
					{
						containerRuleWatcher._CollectionMap = Conversions.ToInteger(dtrRow["Cargo_Crew"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Area"])))
					{
						containerRuleWatcher.m_RuleMap = Conversions.ToSingle(dtrRow["Cargo_Area"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Type"])))
					{
						containerRuleWatcher.processMap = (CargoType)Conversions.ToInteger(dtrRow["Cargo_Type"].ToString());
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_Mass"])))
					{
						containerRuleWatcher.m_ThreadMap = Conversions.ToSingle(dtrRow["Cargo_Mass"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["Cargo_ParadropCapable"])))
					{
						containerRuleWatcher._InstanceMap = Conversions.ToBoolean(dtrRow["Cargo_ParadropCapable"]);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (datatableTyped.Columns.Contains("MobileUnitCategory") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtrRow["MobileUnitCategory"])))
				{
					containerRuleWatcher._ObjectMap = (IMobileGroundUnit._MobileUnitCategory)Math.Round((double)Conversions.ToInteger(dtrRow["MobileUnitCategory"]) / 1000.0);
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			DBCache.SetCustomObject(sqliteHelper_, _InterceptorReader, containerRuleWatcher);
		}
		Mount mount = null;
		mount = new Mount();
		Mount mount2 = mount;
		mount2.DBID = int_0;
		mount2.Name = containerRuleWatcher.Name;
		mount2.ArmorRating = containerRuleWatcher._AuthenticationCreator;
		mount2.ROF = containerRuleWatcher._ParamsCreator;
		mount2.MountMagazine.ROF = containerRuleWatcher.helperCreator;
		mount2.MaxCapacity = containerRuleWatcher.infoCreator;
		mount2.MountMagazine.Capacity = containerRuleWatcher._MapperCreator;
		mount2.IsAutonomous = containerRuleWatcher._MerchantMap;
		mount2.IsLogistic = containerRuleWatcher.m_ManagerCreator;
		mount2.CanHotReload = containerRuleWatcher.m_ProducerCreator;
		mount2.LocalControl = containerRuleWatcher.m_CallbackMap;
		mount2.IsTrainable = containerRuleWatcher.m_StructMap;
		mount2.DP = containerRuleWatcher.DamagePoints;
		mount2.ReserveTarget = containerRuleWatcher._GetterCreator;
		mount2.Hypothetical = containerRuleWatcher.decoratorMap;
		mount2.Cargo_Crew = containerRuleWatcher._CollectionMap;
		mount2.Cargo_Area = containerRuleWatcher.m_RuleMap;
		mount2.Cargo_Type = containerRuleWatcher.processMap;
		mount2.Cargo_Mass = containerRuleWatcher.m_ThreadMap;
		mount2.Cargo_ParadropCapable = containerRuleWatcher._InstanceMap;
		mount2.MobileUnitCategory = containerRuleWatcher._ObjectMap;
		PopList(scenario_0, ref mount);
		GetMountDefaultArcs(ref mount, scenario_0.DBConnection);
		if (bool_0)
		{
			PopulateMountSensors(ref mount, int_0, scenario_0.DBConnection);
			PopulateMountComms(ref mount, int_0, scenario_0);
			PopulateMountWeapons(ref scenario_0, ref mount, int_0);
			PopulateMountMagazineWeapons(ref scenario_0, ref mount, int_0);
		}
		PopulateMountMissingCargoData(mount);
		return mount;
	}

	public static void GetMountDefaultArcs(ref Mount mount_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(sqliteConnection_0);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "MiscMountDefault"))
		{
			_InterceptorReader = "Select * from MiscMountDefault WHERE ID = " + Conversions.ToString(mount_0.DBID);
			DataTable datatable = DBCache.GetDatatable(sQLiteHelper, _InterceptorReader);
			if (datatable.Rows.Count > 0)
			{
				DataRow dataRow = datatable.Rows[0];
				Mount obj = mount_0;
				obj.Coverage.PB1 = Conversions.ToBoolean(dataRow["PB1"]);
				obj.Coverage.PB2 = Conversions.ToBoolean(dataRow["PB2"]);
				obj.Coverage.PMF1 = Conversions.ToBoolean(dataRow["PMF1"]);
				obj.Coverage.PMF2 = Conversions.ToBoolean(dataRow["PMF2"]);
				obj.Coverage.PMA1 = Conversions.ToBoolean(dataRow["PMA1"]);
				obj.Coverage.PMA2 = Conversions.ToBoolean(dataRow["PMA2"]);
				obj.Coverage.PS1 = Conversions.ToBoolean(dataRow["PS1"]);
				obj.Coverage.PS2 = Conversions.ToBoolean(dataRow["PS2"]);
				obj.Coverage.SB1 = Conversions.ToBoolean(dataRow["SB1"]);
				obj.Coverage.SB2 = Conversions.ToBoolean(dataRow["SB2"]);
				obj.Coverage.SMF1 = Conversions.ToBoolean(dataRow["SMF1"]);
				obj.Coverage.SMF2 = Conversions.ToBoolean(dataRow["SMF2"]);
				obj.Coverage.SMA1 = Conversions.ToBoolean(dataRow["SMA1"]);
				obj.Coverage.SMA2 = Conversions.ToBoolean(dataRow["SMA2"]);
				obj.Coverage.SS1 = Conversions.ToBoolean(dataRow["SS1"]);
				obj.Coverage.SS2 = Conversions.ToBoolean(dataRow["SS2"]);
			}
		}
		else
		{
			Mount obj2 = mount_0;
			obj2.Coverage.PB1 = true;
			obj2.Coverage.PB2 = true;
			obj2.Coverage.PMF1 = true;
			obj2.Coverage.PMF2 = true;
			obj2.Coverage.PMA1 = true;
			obj2.Coverage.PMA2 = true;
			obj2.Coverage.PS1 = true;
			obj2.Coverage.PS2 = true;
			obj2.Coverage.SB1 = true;
			obj2.Coverage.SB2 = true;
			obj2.Coverage.SMF1 = true;
			obj2.Coverage.SMF2 = true;
			obj2.Coverage.SMA1 = true;
			obj2.Coverage.SMA2 = true;
			obj2.Coverage.SS1 = true;
			obj2.Coverage.SS2 = true;
		}
	}

	public static void PopulateMounts(ref Scenario scenario_0, ref ActiveUnit activeUnit_0, int int_0)
	{
		string text = "";
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		if (activeUnit_0.IsAircraft)
		{
			text = "DataAircraftMounts";
		}
		else if (activeUnit_0.IsWeapon)
		{
			text = "DataWeaponMounts";
		}
		else if (activeUnit_0.IsShip)
		{
			text = "DataShipMounts";
		}
		else if (activeUnit_0.IsSubmarine)
		{
			text = "DataSubmarineMounts";
		}
		else if (activeUnit_0.IsFacility)
		{
			text = "DataFacilityMounts";
		}
		else if (activeUnit_0.IsMobileGroundUnit)
		{
			text = "DataGroundUnitMounts";
		}
		else if (activeUnit_0.IsSatellite)
		{
			text = "DataSatelliteMounts";
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		_InterceptorReader = "SELECT DataMount.*, theTable.PB1, theTable.PB2, theTable.PMF1, theTable.PMF2, theTable.PMA1, theTable.PMA2, theTable.PS1, theTable.PS2, theTable.SB1, theTable.SB2, theTable.SMF1, theTable.SMF2, theTable.SMA1, theTable.SMA2, theTable.SS1, theTable.SS2 FROM DataMount, " + text + " AS theTable WHERE DataMount.ID = theTable.ComponentID And theTable.ID = " + Conversions.ToString(int_0) + " ORDER BY DataMount.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			Mount mount_ = new Mount();
			Mount mount = mount_;
			mount.ParentPlatform = activeUnit_0;
			mount.DBID = Conversions.ToInteger(dataRow["ID"]);
			mount.Name = Conversions.ToString(dataRow["Name"]);
			mount.ArmorRating = (GlobalVariables.ArmorRating)Conversions.ToShort(dataRow["ArmorGeneral"]);
			mount.ROF = Conversions.ToInteger(dataRow["ROF"]);
			mount.MountMagazine.ROF = Conversions.ToInteger(dataRow["MagazineROF"]);
			mount.MaxCapacity = Conversions.ToInteger(dataRow["Capacity"]);
			mount.MountMagazine.Capacity = Conversions.ToInteger(dataRow["MagazineCapacity"]);
			mount.IsAutonomous = Conversions.ToBoolean(dataRow["Autonomous"]);
			mount.IsLogistic = Conversions.ToBoolean(dataRow["Logistic"]);
			mount.CanHotReload = Conversions.ToBoolean(dataRow["CanHotReload"]);
			mount.LocalControl = Conversions.ToBoolean(dataRow["LocalControl"]);
			mount.IsTrainable = Conversions.ToBoolean(dataRow["Trainable"]);
			mount.DP = Conversions.ToSingle(dataRow["DamagePoints"]);
			mount.ReserveTarget = Conversions.ToBoolean(dataRow["ReserveTarget"]);
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Type"])))
			{
				mount.Cargo_Type = (CargoType)Conversions.ToInteger(dataRow["Cargo_Type"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Area"])))
			{
				mount.Cargo_Area = Conversions.ToInteger(dataRow["Cargo_Area"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Crew"])))
			{
				mount.Cargo_Crew = Conversions.ToInteger(dataRow["Cargo_Crew"]);
			}
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Cargo_Mass"])))
			{
				mount.Cargo_Mass = Conversions.ToInteger(dataRow["Cargo_Mass"]);
			}
			mount.Cargo_ParadropCapable = Conversions.ToBoolean(dataRow["Cargo_ParadropCapable"]);
			mount.Coverage.PB1 = Conversions.ToBoolean(dataRow["PB1"]);
			mount.Coverage.PB2 = Conversions.ToBoolean(dataRow["PB2"]);
			mount.Coverage.PMF1 = Conversions.ToBoolean(dataRow["PMF1"]);
			mount.Coverage.PMF2 = Conversions.ToBoolean(dataRow["PMF2"]);
			mount.Coverage.PMA1 = Conversions.ToBoolean(dataRow["PMA1"]);
			mount.Coverage.PMA2 = Conversions.ToBoolean(dataRow["PMA2"]);
			mount.Coverage.PS1 = Conversions.ToBoolean(dataRow["PS1"]);
			mount.Coverage.PS2 = Conversions.ToBoolean(dataRow["PS2"]);
			mount.Coverage.SB1 = Conversions.ToBoolean(dataRow["SB1"]);
			mount.Coverage.SB2 = Conversions.ToBoolean(dataRow["SB2"]);
			mount.Coverage.SMF1 = Conversions.ToBoolean(dataRow["SMF1"]);
			mount.Coverage.SMF2 = Conversions.ToBoolean(dataRow["SMF2"]);
			mount.Coverage.SMA1 = Conversions.ToBoolean(dataRow["SMA1"]);
			mount.Coverage.SMA2 = Conversions.ToBoolean(dataRow["SMA2"]);
			mount.Coverage.SS1 = Conversions.ToBoolean(dataRow["SS1"]);
			mount.Coverage.SS2 = Conversions.ToBoolean(dataRow["SS2"]);
			mount = null;
			PopulateMountSensors(ref mount_, Conversions.ToInteger(dataRow["ID"]), scenario_0.DBConnection);
			PopulateMountComms(ref mount_, Conversions.ToInteger(dataRow["ID"]), scenario_0);
			PopulateMountWeapons(ref scenario_0, ref mount_, Conversions.ToInteger(dataRow["ID"]));
			PopulateMountMagazineWeapons(ref scenario_0, ref mount_, Conversions.ToInteger(dataRow["ID"]));
			PopulateMountMissingCargoData(mount_);
			PopList(scenario_0, ref mount_);
			activeUnit_0.Mounts.Add(mount_);
		}
	}

	public static void PopulateMountMissingCargoData(Mount mount_0)
	{
		if (mount_0.Cargo_Type == CargoType.Personnel && (mount_0.Cargo_Mass == 0f || mount_0.Cargo_Area == 0f))
		{
			mount_0.Cargo_Mass = (float)mount_0.Cargo_Crew * Mount.PersonnelMass;
			mount_0.Cargo_Area = (float)mount_0.Cargo_Crew * Mount.PersonnelArea;
		}
	}

	public static void PopulateMountComms(ref Mount mount_0, int int_0, Scenario scenario_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "Select DataComm.ID as CommID, DataComm.Name, DataComm.Type, DataComm.Range, DataComm.Channels, DataComm.IsOptional, theTable.* from DataComm, DataMountComms as theTable where DataComm.ID = theTable.ComponentID and theTable.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			CommDevice theAC = new CommDevice(mount_0.ParentPlatform, scenario_0, Conversions.ToInteger(dataRow["CommID"]), Conversions.ToString(dataRow["Name"]), (CommDevice.CommLinkType)Conversions.ToInteger(dataRow["Type"]), Conversions.ToDouble(dataRow["Range"]), Conversions.ToInteger(dataRow["Channels"]), Conversions.ToBoolean(dataRow["IsOptional"]));
			ArrayExtensions.Add(ref mount_0.CommDevices, theAC);
		}
	}

	public static void PopulateMountSensors(ref Mount mount_0, int int_0, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		_InterceptorReader = "SELECT S.ID from DataMountSensors as MS, DataSensor as S where S.ID = MS.ComponentID and MS.ID = " + Conversions.ToString(int_0);
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		if (!Information.IsNothing(mount_0.ParentPlatform))
		{
			_ = mount_0.ParentPlatform;
		}
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = GetSensor(Conversions.ToInteger(datatable.Rows[i]["ID"]), ref sqliteConnection_0);
			sensor.ParentPlatform = mount_0.ParentPlatform;
			sensor.Coverage.PB1 = mount_0.Coverage.PB1;
			sensor.Coverage.PMA1 = mount_0.Coverage.PMA1;
			sensor.Coverage.PMF1 = mount_0.Coverage.PMF1;
			sensor.Coverage.PS1 = mount_0.Coverage.PS1;
			sensor.Coverage.SB1 = mount_0.Coverage.SB1;
			sensor.Coverage.SMA1 = mount_0.Coverage.SMA1;
			sensor.Coverage.SMF1 = mount_0.Coverage.SMF1;
			sensor.Coverage.SS1 = mount_0.Coverage.SS1;
			sensor.Coverage.PB2 = mount_0.Coverage.PB2;
			sensor.Coverage.PMA2 = mount_0.Coverage.PMA2;
			sensor.Coverage.PMF2 = mount_0.Coverage.PMF2;
			sensor.Coverage.PS2 = mount_0.Coverage.PS2;
			sensor.Coverage.SB2 = mount_0.Coverage.SB2;
			sensor.Coverage.SMA2 = mount_0.Coverage.SMA2;
			sensor.Coverage.SMF2 = mount_0.Coverage.SMF2;
			sensor.Coverage.SS2 = mount_0.Coverage.SS2;
			sensor.Coverage_Illuminate.PB1 = mount_0.Coverage.PB1;
			sensor.Coverage_Illuminate.PMA1 = mount_0.Coverage.PMA1;
			sensor.Coverage_Illuminate.PMF1 = mount_0.Coverage.PMF1;
			sensor.Coverage_Illuminate.PS1 = mount_0.Coverage.PS1;
			sensor.Coverage_Illuminate.SB1 = mount_0.Coverage.SB1;
			sensor.Coverage_Illuminate.SMA1 = mount_0.Coverage.SMA1;
			sensor.Coverage_Illuminate.SMF1 = mount_0.Coverage.SMF1;
			sensor.Coverage_Illuminate.SS1 = mount_0.Coverage.SS1;
			sensor.Coverage_Illuminate.PB2 = mount_0.Coverage.PB2;
			sensor.Coverage_Illuminate.PMA2 = mount_0.Coverage.PMA2;
			sensor.Coverage_Illuminate.PMF2 = mount_0.Coverage.PMF2;
			sensor.Coverage_Illuminate.PS2 = mount_0.Coverage.PS2;
			sensor.Coverage_Illuminate.SB2 = mount_0.Coverage.SB2;
			sensor.Coverage_Illuminate.SMA2 = mount_0.Coverage.SMA2;
			sensor.Coverage_Illuminate.SMF2 = mount_0.Coverage.SMF2;
			sensor.Coverage_Illuminate.SS2 = mount_0.Coverage.SS2;
			mount_0.AddSensor(sensor);
		}
	}

	public static void PopulateMountWeapons(ref Scenario scenario_0, ref Mount mount_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT DataWeaponRecord.* FROM DataMountWeapons, DataWeaponRecord, DataWeapon WHERE DataMountWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMountWeapons.ID = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec item = new WeaponRec(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), bool_0: false, bool_1: false);
			mount_0.MountWeapons.Add(item);
		}
	}

	public static void PopulateMountMagazineWeapons(ref Scenario scenario_0, ref Mount mount_0, int int_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(scenario_0.DBConnection);
		_InterceptorReader = "SELECT DataWeaponRecord.*, DataMountMagazineWeapons.ComponentNumber FROM DataMountMagazineWeapons, DataWeaponRecord, DataWeapon WHERE DataMountMagazineWeapons.ComponentID = DataWeaponRecord.ID And DataWeapon.ID = DataWeaponRecord.ComponentID And DataMountMagazineWeapons.ID  = " + Conversions.ToString(int_0) + " ORDER BY DataWeapon.Type, DataWeapon.Name ASC";
		DataTable datatable = DBCache.GetDatatable(sqliteHelper_, _InterceptorReader);
		int num = datatable.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataRow dataRow = datatable.Rows[i];
			WeaponRec item = new WeaponRec(ref scenario_0, Conversions.ToInteger(dataRow["ComponentID"]), Conversions.ToInteger(dataRow["DefaultLoad"]), Conversions.ToInteger(dataRow["MaxLoad"]), Conversions.ToInteger(dataRow["ROF"]), Conversions.ToInteger(dataRow["Multiple"]), bool_0: false, bool_1: false);
			mount_0.MountMagazine.Weapons.Add(item);
		}
	}

	public static void PopulateWeaponTargets(ref WeaponTargets weaponTargets_0, int int_0, ref SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(sqliteConnection_0);
		GameGeneral.ThreadStaticSB.Clear();
		GameGeneral.ThreadStaticSB.Append("SELECT CodeID from DataWeaponTargets where ID = ").Append(int_0);
		_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
		List<long> list = DBCache.PrintImporter<long>(sqliteHelper_, _InterceptorReader, "CodeID");
		int count = list.Count;
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			long num2 = list[i];
			if (num2 <= 3004)
			{
				long num3 = num2 - 1001;
				if ((ulong)num3 <= 4uL && (ulong)num3 <= 4uL)
				{
					long num7 = num3;
					long num8 = num7;
					if ((ulong)num8 <= 4uL)
					{
						switch (num8)
						{
						case 0L:
							weaponTargets_0.Aircraft = true;
							continue;
						case 1L:
							weaponTargets_0.Helicopter = true;
							continue;
						case 2L:
							weaponTargets_0.Missile = true;
							continue;
						case 3L:
							weaponTargets_0.Satellite = true;
							continue;
						case 4L:
							weaponTargets_0.RAMB = true;
							continue;
						}
					}
				}
				long num4 = num2 - 2001;
				if ((ulong)num4 <= 3uL && (ulong)num4 <= 3uL)
				{
					long num9 = num4;
					long num10 = num9;
					if ((ulong)num10 <= 3uL)
					{
						switch (num10)
						{
						case 0L:
							weaponTargets_0.SurfaceVessel = true;
							continue;
						case 1L:
							weaponTargets_0.Submarine = true;
							continue;
						case 2L:
							weaponTargets_0.Mine = true;
							continue;
						case 3L:
							weaponTargets_0.Torpedo = true;
							continue;
						}
					}
				}
				long num5 = num2 - 3001;
				if ((ulong)num5 <= 3uL && (ulong)num5 <= 3uL)
				{
					long num11 = num5;
					long num12 = num11;
					if ((ulong)num12 <= 3uL)
					{
						switch (num12)
						{
						case 0L:
							weaponTargets_0.LandStructure_Soft = true;
							continue;
						case 1L:
							weaponTargets_0.LandStructure_Hard = true;
							continue;
						case 2L:
							weaponTargets_0.Runway = true;
							continue;
						case 3L:
							weaponTargets_0.Radar = true;
							continue;
						}
					}
				}
			}
			else if (num2 <= 5001)
			{
				long num6 = num2 - 4001;
				if ((ulong)num6 <= 2uL && (ulong)num6 <= 2uL)
				{
					long num13 = num6;
					long num14 = num13;
					if ((ulong)num14 <= 2uL)
					{
						switch (num14)
						{
						case 0L:
							weaponTargets_0.MobileTarget_Soft = true;
							continue;
						case 1L:
							weaponTargets_0.MobileTarget_Hard = true;
							continue;
						case 2L:
							weaponTargets_0.MobileTarget_Personnel = true;
							continue;
						}
					}
				}
				if (num2 == 5001)
				{
					weaponTargets_0.UnderwaterStructure = true;
					continue;
				}
			}
			else
			{
				switch (num2)
				{
				case 9001L:
					weaponTargets_0.AirBaseSingleUnit = true;
					continue;
				case 6001L:
					weaponTargets_0.AerostatMooring = true;
					continue;
				}
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (count > 1)
		{
			weaponTargets_0.MultipleTypes = true;
		}
	}

	public static CargoContainer GetCargoContainer(int int_0, ref Scenario scenario_0, bool bool_0 = true)
	{
		SQLiteHelper sQLiteHelper = new SQLiteHelper(scenario_0.DBConnection);
		if (sQLiteHelper.LogoutSpecification(GameGeneral.ThreadStaticSB, "DataContainer"))
		{
			GameGeneral.ThreadStaticSB.Clear();
			GameGeneral.ThreadStaticSB.Append("Select DataContainer.* from DataContainer WHERE DataContainer.ID = ").Append(int_0);
			_InterceptorReader = GameGeneral.ThreadStaticSB.ToString();
			DataTableTyped datatableTyped;
			try
			{
				datatableTyped = DBCache.GetDatatableTyped(sQLiteHelper, _InterceptorReader);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return null;
			}
			if (datatableTyped.Rows.Count() < 1)
			{
				return null;
			}
			DtrRow dtrRow = datatableTyped.Rows[0];
			string name = Conversions.ToString(dtrRow["Name"]);
			CargoContainer.CargoContainerType cargoContainerType = (CargoContainer.CargoContainerType)Conversions.ToInteger(dtrRow["Type"]);
			float float_ = Conversions.ToSingle(dtrRow["Length"]);
			float float_2 = Conversions.ToSingle(dtrRow["Width"]);
			float float_3 = Conversions.ToSingle(dtrRow["Height"]);
			bool flag = Conversions.ToBoolean(dtrRow["IsHold"]);
			float float_4 = Conversions.ToInteger(dtrRow["Weight"]);
			float float_5 = Conversions.ToInteger(dtrRow["PayloadCapacity"]);
			float float_6 = Conversions.ToInteger(dtrRow["CubicCapacity"]);
			bool bool_ = false;
			bool bool_2 = false;
			if (CheckColumnExists_SQLite("DataContainer", "Container_ParadropCapable", scenario_0.DBConnection))
			{
				bool_2 = Conversions.ToBoolean(dtrRow["Container_ParadropCapable"]);
			}
			CargoType cargoType_ = ((!flag) ? ((cargoContainerType == CargoContainer.CargoContainerType.Pallet) ? RestartList(float_, float_2, 0f) : RestartList(float_, float_2, float_3)) : CargoType.NoCargo);
			return new CargoContainer(cargoContainerType, cargoType_, float_, float_2, float_3, float_4, float_5, float_6, flag, bool_, bool_2)
			{
				Name = name,
				DBID = int_0
			};
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return null;
	}

	internal static DockFacility.DockingPhysicalSize ReadList(float float_0)
	{
		if (float_0 <= 11f)
		{
			return DockFacility.DockingPhysicalSize.const_1;
		}
		if (float_0 <= 17f)
		{
			return DockFacility.DockingPhysicalSize.SmallPier;
		}
		if (float_0 <= 25f)
		{
			return DockFacility.DockingPhysicalSize.MediumPier;
		}
		if (float_0 <= 45f)
		{
			return DockFacility.DockingPhysicalSize.LargePier;
		}
		if (float_0 <= 200f)
		{
			return DockFacility.DockingPhysicalSize.const_5;
		}
		return DockFacility.DockingPhysicalSize.const_6;
	}

	internal static DockFacility.DockingPhysicalSize DisableList(float float_0)
	{
		if (float_0 <= 11f)
		{
			return DockFacility.DockingPhysicalSize.VSmallDockDavit;
		}
		if (float_0 <= 17f)
		{
			return DockFacility.DockingPhysicalSize.SmallDockDavit;
		}
		if (float_0 <= 25f)
		{
			return DockFacility.DockingPhysicalSize.MediumDock;
		}
		if (float_0 <= 45f)
		{
			return DockFacility.DockingPhysicalSize.LargeDock;
		}
		return DockFacility.DockingPhysicalSize.None;
	}

	internal static int UpdateList(GlobalVariables.RunwayLengthClass runwayLengthClass_0)
	{
		switch (runwayLengthClass_0)
		{
		case GlobalVariables.RunwayLengthClass.VTOL:
			return 2001;
		case GlobalVariables.RunwayLengthClass.CatapultLaunched:
			return 1101;
		case GlobalVariables.RunwayLengthClass.ManualLaunch:
			return 1002;
		case GlobalVariables.RunwayLengthClass.Between_451_900m:
			return 2003;
		case GlobalVariables.RunwayLengthClass.Between_1_450m:
			return 2002;
		case GlobalVariables.RunwayLengthClass.Between_1_250m:
			if (DBOps.DBHasLegacyRunwayLengthEnum)
			{
				return 2010;
			}
			return 3005;
		case GlobalVariables.RunwayLengthClass.Between_2001_2600m:
			return 2006;
		case GlobalVariables.RunwayLengthClass.Between_1401_2000m:
			return 2005;
		case GlobalVariables.RunwayLengthClass.Between_901_1400m:
			return 2004;
		default:
			return 1001;
		case GlobalVariables.RunwayLengthClass.Between_4000_5600m:
			return 2009;
		case GlobalVariables.RunwayLengthClass.Between_3201_4000m:
			return 2008;
		case GlobalVariables.RunwayLengthClass.Between_2601_3200m:
			return 2007;
		}
	}

	internal static GlobalVariables.RunwayLengthClass InsertList(int int_0)
	{
		switch (int_0)
		{
		case 1101:
			return GlobalVariables.RunwayLengthClass.CatapultLaunched;
		case 1002:
			return GlobalVariables.RunwayLengthClass.ManualLaunch;
		case 3005:
			return GlobalVariables.RunwayLengthClass.Between_1_250m;
		case 2001:
			return GlobalVariables.RunwayLengthClass.VTOL;
		case 2002:
			return GlobalVariables.RunwayLengthClass.Between_1_450m;
		case 2003:
			return GlobalVariables.RunwayLengthClass.Between_451_900m;
		case 2004:
			return GlobalVariables.RunwayLengthClass.Between_901_1400m;
		case 2005:
			return GlobalVariables.RunwayLengthClass.Between_1401_2000m;
		case 2006:
			return GlobalVariables.RunwayLengthClass.Between_2001_2600m;
		case 2007:
			return GlobalVariables.RunwayLengthClass.Between_2601_3200m;
		case 2008:
			return GlobalVariables.RunwayLengthClass.Between_3201_4000m;
		case 2009:
			return GlobalVariables.RunwayLengthClass.Between_4000_5600m;
		case 2010:
			if (DBOps.DBHasLegacyRunwayLengthEnum)
			{
				return GlobalVariables.RunwayLengthClass.Between_1_250m;
			}
			break;
		}
		return GlobalVariables.RunwayLengthClass.None;
	}

	internal static GlobalVariables.AircraftSizeClass PrepareList(int int_0)
	{
		switch (int_0)
		{
		default:
			return GlobalVariables.AircraftSizeClass.None;
		case 3002:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Mini;
		case 3003:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Small;
		case 3004:
			return GlobalVariables.AircraftSizeClass.UAS_Class2;
		case 2000:
		case 3001:
			return GlobalVariables.AircraftSizeClass.UAS_Class1_Micro;
		case 2001:
			return GlobalVariables.AircraftSizeClass.Small;
		case 2002:
			return GlobalVariables.AircraftSizeClass.Medium;
		case 2003:
			return GlobalVariables.AircraftSizeClass.Large;
		case 2004:
			return GlobalVariables.AircraftSizeClass.VLarge;
		case 1001:
			return GlobalVariables.AircraftSizeClass.None;
		}
	}

	internal static int ReflectList(GlobalVariables.AircraftSizeClass aircraftSizeClass_0)
	{
		if (1 == 0)
		{
		}
		int result = aircraftSizeClass_0 switch
		{
			GlobalVariables.AircraftSizeClass.Medium => 2002, 
			GlobalVariables.AircraftSizeClass.None => 1001, 
			GlobalVariables.AircraftSizeClass.UAS_Class1_Micro => 3001, 
			GlobalVariables.AircraftSizeClass.UAS_Class1_Mini => 3002, 
			GlobalVariables.AircraftSizeClass.UAS_Class1_Small => 3003, 
			GlobalVariables.AircraftSizeClass.UAS_Class2 => 3004, 
			GlobalVariables.AircraftSizeClass.Small => 2001, 
			GlobalVariables.AircraftSizeClass.VLarge => 2004, 
			GlobalVariables.AircraftSizeClass.Large => 2003, 
			_ => 1001, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static CargoType VisitList(float float_0)
	{
		if (float_0 == 0f)
		{
			return CargoType.NoCargo;
		}
		if (float_0 < 1f)
		{
			return CargoType.Personnel;
		}
		if (float_0 < 5f)
		{
			return CargoType.SmallCargo;
		}
		if (float_0 < 7f)
		{
			return CargoType.MediumCargo;
		}
		if (float_0 < 9f)
		{
			return CargoType.LargeCargo;
		}
		return CargoType.const_5;
	}

	internal static CargoType RestartList(float float_0, float float_1, float float_2)
	{
		if (float_2 == 0f)
		{
			return VisitList(Math.Min(float_0, float_1));
		}
		if (!(float_0 < float_1) && float_0 >= float_2)
		{
			return VisitList(Math.Max(float_1, float_2));
		}
		if (!(float_1 < float_0) && float_1 >= float_2)
		{
			return VisitList(Math.Max(float_0, float_2));
		}
		if (!(float_2 < float_0) && float_2 >= float_1)
		{
			return VisitList(Math.Max(float_0, float_1));
		}
		return CargoType.NoCargo;
	}

	internal static float TestList(float float_0, float float_1)
	{
		float num = float_0 * float_1;
		if (num > 10f)
		{
			num = (float)Math.Round(num, MidpointRounding.AwayFromZero);
		}
		return num;
	}
}
