using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Command.Filters;
using Command.Listeners;
using Command.Managers;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class HoverInfoViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class DescriptorMap
	{
		public int Local_temp_AIR_SR;

		public int Local_temp_AIR_MR;

		public int Local_temp_AIR_LR;

		public int Local_temp_SURF_SR;

		public int Local_temp_SURF_MR;

		public int Local_temp_SURF_LR;

		public int Local_temp_LAND_SR;

		public int Local_temp_LAND_MR;

		public int Local_temp_LAND_LR;

		public int Local_temp_SUB_SR;

		public int Local_temp_SUB_MR;

		public int Local_temp_SUB_LR;

		public HoverInfoViewModel _003C_003E4__this;

		internal void AssetInterruptiblePage(Weapon myWeapon, int myCount)
		{
			if (myWeapon.IsAAW)
			{
				if (myWeapon.MaxAirRange <= 25f)
				{
					if (myWeapon.MaxAirRange <= 5f)
					{
						Local_temp_AIR_SR += myCount;
					}
					else
					{
						Local_temp_AIR_MR += myCount;
					}
				}
				else
				{
					Local_temp_AIR_LR += myCount;
				}
			}
			if (myWeapon.IsASuW_Naval)
			{
				if (myWeapon.MaxSurfaceRange <= 25f)
				{
					if (myWeapon.MaxSurfaceRange <= 5f)
					{
						Local_temp_SURF_SR += myCount;
					}
					else
					{
						Local_temp_SURF_MR += myCount;
					}
				}
				else
				{
					Local_temp_SURF_LR += myCount;
				}
			}
			if (myWeapon.IsASuW_Land)
			{
				if (myWeapon.MaxLandRange <= 25f)
				{
					if (myWeapon.MaxLandRange <= 5f)
					{
						Local_temp_LAND_SR += myCount;
					}
					else
					{
						Local_temp_LAND_MR += myCount;
					}
				}
				else
				{
					Local_temp_LAND_LR += myCount;
				}
			}
			if (!myWeapon.IsASW)
			{
				return;
			}
			if (myWeapon.MaxSubsurfaceRange <= 25f)
			{
				if (myWeapon.MaxSubsurfaceRange <= 5f)
				{
					Local_temp_SUB_SR += myCount;
				}
				else
				{
					Local_temp_SUB_MR += myCount;
				}
			}
			else
			{
				Local_temp_SUB_LR += myCount;
			}
		}

		internal string PrintInterruptiblePage(Tuple<Weapon, int> F)
		{
			return _003C_003E4__this.CallIterator(F.Item1);
		}
	}

	[CompilerGenerated]
	private Module_Unit.Unit poolInterpreter;

	[CompilerGenerated]
	private string m_TaskInterpreter;

	[CompilerGenerated]
	private string m_FilterInterpreter;

	[CompilerGenerated]
	private string _TestsInterpreter;

	[CompilerGenerated]
	private string interpreterInterpreter;

	[CompilerGenerated]
	private string _ContainerInterpreter;

	[CompilerGenerated]
	private string _ComposerInterpreter;

	[CompilerGenerated]
	private string _ModelInterpreter;

	[CompilerGenerated]
	private string advisorInterpreter;

	[CompilerGenerated]
	private BitmapImage _CustomerInterpreter;

	[CompilerGenerated]
	private List<BitmapImage> serializerInterpreter;

	[CompilerGenerated]
	private Visibility refInterpreter;

	[CompilerGenerated]
	private List<HoverInfoGroupMemberViewModel> _ErrorInterpreter;

	[CompilerGenerated]
	private Visibility codeInterpreter;

	[CompilerGenerated]
	private string connectionInterpreter;

	[CompilerGenerated]
	private string _ContextInterpreter;

	[CompilerGenerated]
	private string _StatusInterpreter;

	[CompilerGenerated]
	private string _ProccesorInterpreter;

	[CompilerGenerated]
	private int strategyInterpreter;

	[CompilerGenerated]
	private int configurationInterpreter;

	[CompilerGenerated]
	private int m_TokenInterpreter;

	[CompilerGenerated]
	private int m_IndexerInterpreter;

	[CompilerGenerated]
	private int resolverInterpreter;

	[CompilerGenerated]
	private int m_PublisherInterpreter;

	[CompilerGenerated]
	private int m_ServerInterpreter;

	[CompilerGenerated]
	private int m_AdapterInterpreter;

	[CompilerGenerated]
	private int schemaInterpreter;

	[CompilerGenerated]
	private int m_UtilsInterpreter;

	[CompilerGenerated]
	private int _PredicateInterpreter;

	[CompilerGenerated]
	private int m_SingletonInterpreter;

	[CompilerGenerated]
	private Visibility _RecordInterpreter;

	[CompilerGenerated]
	private Visibility exceptionInterpreter;

	[CompilerGenerated]
	private Visibility m_AttrInterpreter;

	[CompilerGenerated]
	private Visibility visitorInterpreter;

	[CompilerGenerated]
	private Visibility exporterInterpreter;

	[CompilerGenerated]
	private Visibility m_PrototypeInterpreter;

	[CompilerGenerated]
	private Visibility m_ComparatorInterpreter;

	[CompilerGenerated]
	private Visibility m_ItemInterpreter;

	[CompilerGenerated]
	private List<HoverInfoParasiteViewModel> m_SetterInterpreter;

	[CompilerGenerated]
	private Visibility creatorInterpreter;

	[CompilerGenerated]
	private List<HoverInfoParasiteViewModel> templateInterpreter;

	[CompilerGenerated]
	private Visibility _MappingInterpreter;

	[CompilerGenerated]
	private List<HoverInfoCargoViewModel> m_MockInterpreter;

	[CompilerGenerated]
	private Visibility _TagInterpreter;

	[CompilerGenerated]
	private Visibility _FieldInterpreter;

	[CompilerGenerated]
	private Visibility queueInterpreter;

	[CompilerGenerated]
	private List<HoverInfoWeaponViewModel> regInterpreter;

	[CompilerGenerated]
	private Visibility _ParamInterpreter;

	[CompilerGenerated]
	private List<HoverInfoMountViewModel> pageInterpreter;

	[CompilerGenerated]
	private string _RulesInterpreter;

	[CompilerGenerated]
	private string methodInterpreter;

	private static DispatcherTimer serviceInterpreter;

	private ContentControl m_SystemInterpreter;

	private ElementHost candidateInterpreter;

	[CompilerGenerated]
	private FuelViewModel _BaseInterpreter;

	[CompilerGenerated]
	private Visibility m_PolicyInterpreter;

	[CompilerGenerated]
	private Visibility _BroadcasterInterpreter;

	[CompilerGenerated]
	private Visibility m_IdentifierInterpreter;

	[CompilerGenerated]
	private Visibility _PrinterInterpreter;

	[CompilerGenerated]
	private Visibility parserInterpreter;

	[CompilerGenerated]
	private Visibility _AlgoInterpreter;

	[CompilerGenerated]
	private Visibility _DatabaseInterpreter;

	[CompilerGenerated]
	private GridLength m_InterceptorInterpreter;

	[CompilerGenerated]
	private GridLength messageInterpreter;

	[CompilerGenerated]
	private GridLength m_ProductInterpreter;

	[CompilerGenerated]
	private GridLength m_AnnotationInterpreter;

	[CompilerGenerated]
	private GridLength _IteratorInterpreter;

	[CompilerGenerated]
	private int initializerInterpreter;

	[CompilerGenerated]
	private int _RoleInterpreter;

	[CompilerGenerated]
	private int _FactoryInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler m_AttributeInterpreter;

	public Module_Unit.Unit Unit
	{
		[CompilerGenerated]
		get
		{
			return poolInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (poolInterpreter != value)
			{
				poolInterpreter = value;
				OnPropertyChanged("Unit");
			}
		}
	}

	public string UnitName
	{
		[CompilerGenerated]
		get
		{
			return m_TaskInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_TaskInterpreter, value, StringComparison.Ordinal))
			{
				m_TaskInterpreter = value;
				OnPropertyChanged("UnitName");
			}
		}
	}

	public string UnitType
	{
		[CompilerGenerated]
		get
		{
			return m_FilterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_FilterInterpreter, value, StringComparison.Ordinal))
			{
				m_FilterInterpreter = value;
				OnPropertyChanged("UnitType");
			}
		}
	}

	public string SideString
	{
		[CompilerGenerated]
		get
		{
			return _TestsInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_TestsInterpreter, value, StringComparison.Ordinal))
			{
				_TestsInterpreter = value;
				OnPropertyChanged("SideString");
			}
		}
	}

	public string CourseString
	{
		[CompilerGenerated]
		get
		{
			return interpreterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(interpreterInterpreter, value, StringComparison.Ordinal))
			{
				interpreterInterpreter = value;
				OnPropertyChanged("CourseString");
			}
		}
	}

	public string SpeedString
	{
		[CompilerGenerated]
		get
		{
			return _ContainerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ContainerInterpreter, value, StringComparison.Ordinal))
			{
				_ContainerInterpreter = value;
				OnPropertyChanged("SpeedString");
			}
		}
	}

	public string AltString
	{
		[CompilerGenerated]
		get
		{
			return _ComposerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ComposerInterpreter, value, StringComparison.Ordinal))
			{
				_ComposerInterpreter = value;
				OnPropertyChanged("AltString");
			}
		}
	}

	public string StatusString
	{
		[CompilerGenerated]
		get
		{
			return _ModelInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ModelInterpreter, value, StringComparison.Ordinal))
			{
				_ModelInterpreter = value;
				OnPropertyChanged("StatusString");
			}
		}
	}

	public string LoadoutString
	{
		[CompilerGenerated]
		get
		{
			return advisorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(advisorInterpreter, value, StringComparison.Ordinal))
			{
				advisorInterpreter = value;
				OnPropertyChanged("LoadoutString");
			}
		}
	}

	public BitmapImage ImageSource
	{
		[CompilerGenerated]
		get
		{
			return _CustomerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_CustomerInterpreter != value)
			{
				_CustomerInterpreter = value;
				OnPropertyChanged("ImageSource");
			}
		}
	}

	public List<BitmapImage> GroupImages
	{
		[CompilerGenerated]
		get
		{
			return serializerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (serializerInterpreter != value)
			{
				serializerInterpreter = value;
				OnPropertyChanged("GroupImages");
			}
		}
	}

	public Visibility GroupMembersVisibility
	{
		[CompilerGenerated]
		get
		{
			return refInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (refInterpreter != value)
			{
				refInterpreter = value;
				OnPropertyChanged("GroupMembersVisibility");
			}
		}
	}

	public List<HoverInfoGroupMemberViewModel> GroupMembers
	{
		[CompilerGenerated]
		get
		{
			return _ErrorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_ErrorInterpreter != value)
			{
				_ErrorInterpreter = value;
				OnPropertyChanged("GroupMembers");
			}
		}
	}

	public Visibility MissionVisibility
	{
		[CompilerGenerated]
		get
		{
			return codeInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (codeInterpreter != value)
			{
				codeInterpreter = value;
				OnPropertyChanged("MissionVisibility");
			}
		}
	}

	public string MissionName
	{
		[CompilerGenerated]
		get
		{
			return connectionInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(connectionInterpreter, value, StringComparison.Ordinal))
			{
				connectionInterpreter = value;
				OnPropertyChanged("MissionName");
			}
		}
	}

	public string MissionClass
	{
		[CompilerGenerated]
		get
		{
			return _ContextInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ContextInterpreter, value, StringComparison.Ordinal))
			{
				_ContextInterpreter = value;
				OnPropertyChanged("MissionClass");
			}
		}
	}

	public string MissionStatus
	{
		[CompilerGenerated]
		get
		{
			return _StatusInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_StatusInterpreter, value, StringComparison.Ordinal))
			{
				_StatusInterpreter = value;
				OnPropertyChanged("MissionStatus");
			}
		}
	}

	public string TypeString
	{
		[CompilerGenerated]
		get
		{
			return _ProccesorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ProccesorInterpreter, value, StringComparison.Ordinal))
			{
				_ProccesorInterpreter = value;
				OnPropertyChanged("TypeString");
			}
		}
	}

	public int AIR_LR
	{
		[CompilerGenerated]
		get
		{
			return strategyInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (strategyInterpreter != value)
			{
				strategyInterpreter = value;
				OnPropertyChanged("AIR_LR");
			}
		}
	}

	public int SURF_LR
	{
		[CompilerGenerated]
		get
		{
			return configurationInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (configurationInterpreter != value)
			{
				configurationInterpreter = value;
				OnPropertyChanged("SURF_LR");
			}
		}
	}

	public int LAND_LR
	{
		[CompilerGenerated]
		get
		{
			return m_TokenInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_TokenInterpreter != value)
			{
				m_TokenInterpreter = value;
				OnPropertyChanged("LAND_LR");
			}
		}
	}

	public int SUB_LR
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_IndexerInterpreter != value)
			{
				m_IndexerInterpreter = value;
				OnPropertyChanged("SUB_LR");
			}
		}
	}

	public int AIR_MR
	{
		[CompilerGenerated]
		get
		{
			return resolverInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (resolverInterpreter != value)
			{
				resolverInterpreter = value;
				OnPropertyChanged("AIR_MR");
			}
		}
	}

	public int SURF_MR
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_PublisherInterpreter != value)
			{
				m_PublisherInterpreter = value;
				OnPropertyChanged("SURF_MR");
			}
		}
	}

	public int LAND_MR
	{
		[CompilerGenerated]
		get
		{
			return m_ServerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ServerInterpreter != value)
			{
				m_ServerInterpreter = value;
				OnPropertyChanged("LAND_MR");
			}
		}
	}

	public int SUB_MR
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_AdapterInterpreter != value)
			{
				m_AdapterInterpreter = value;
				OnPropertyChanged("SUB_MR");
			}
		}
	}

	public int AIR_SR
	{
		[CompilerGenerated]
		get
		{
			return schemaInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (schemaInterpreter != value)
			{
				schemaInterpreter = value;
				OnPropertyChanged("AIR_SR");
			}
		}
	}

	public int SURF_SR
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_UtilsInterpreter != value)
			{
				m_UtilsInterpreter = value;
				OnPropertyChanged("SURF_SR");
			}
		}
	}

	public int LAND_SR
	{
		[CompilerGenerated]
		get
		{
			return _PredicateInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_PredicateInterpreter != value)
			{
				_PredicateInterpreter = value;
				OnPropertyChanged("LAND_SR");
			}
		}
	}

	public int SUB_SR
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_SingletonInterpreter != value)
			{
				m_SingletonInterpreter = value;
				OnPropertyChanged("SUB_SR");
			}
		}
	}

	public Visibility RadarOnVisibility
	{
		[CompilerGenerated]
		get
		{
			return _RecordInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_RecordInterpreter != value)
			{
				_RecordInterpreter = value;
				OnPropertyChanged("RadarOnVisibility");
			}
		}
	}

	public Visibility SonarOnVisibility
	{
		[CompilerGenerated]
		get
		{
			return exceptionInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (exceptionInterpreter != value)
			{
				exceptionInterpreter = value;
				OnPropertyChanged("SonarOnVisibility");
			}
		}
	}

	public Visibility OECMOnVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_AttrInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_AttrInterpreter != value)
			{
				m_AttrInterpreter = value;
				OnPropertyChanged("OECMOnVisibility");
			}
		}
	}

	public Visibility RadarOffVisibility
	{
		[CompilerGenerated]
		get
		{
			return visitorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (visitorInterpreter != value)
			{
				visitorInterpreter = value;
				OnPropertyChanged("RadarOffVisibility");
			}
		}
	}

	public Visibility SonarOffVisibility
	{
		[CompilerGenerated]
		get
		{
			return exporterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (exporterInterpreter != value)
			{
				exporterInterpreter = value;
				OnPropertyChanged("SonarOffVisibility");
			}
		}
	}

	public Visibility OECMOffVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_PrototypeInterpreter != value)
			{
				m_PrototypeInterpreter = value;
				OnPropertyChanged("OECMOffVisibility");
			}
		}
	}

	public Visibility SensorVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ComparatorInterpreter != value)
			{
				m_ComparatorInterpreter = value;
				OnPropertyChanged("SensorVisibility");
			}
		}
	}

	public Visibility AirParasiteVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_ItemInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ItemInterpreter != value)
			{
				m_ItemInterpreter = value;
				OnPropertyChanged("AirParasiteVisibility");
			}
		}
	}

	public List<HoverInfoParasiteViewModel> AirParasites
	{
		[CompilerGenerated]
		get
		{
			return m_SetterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_SetterInterpreter != value)
			{
				m_SetterInterpreter = value;
				OnPropertyChanged("AirParasites");
			}
		}
	}

	public Visibility BoatParasiteVisibility
	{
		[CompilerGenerated]
		get
		{
			return creatorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (creatorInterpreter != value)
			{
				creatorInterpreter = value;
				OnPropertyChanged("BoatParasiteVisibility");
			}
		}
	}

	public List<HoverInfoParasiteViewModel> BoatParasites
	{
		[CompilerGenerated]
		get
		{
			return templateInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (templateInterpreter != value)
			{
				templateInterpreter = value;
				OnPropertyChanged("BoatParasites");
			}
		}
	}

	public Visibility CargoVisibility
	{
		[CompilerGenerated]
		get
		{
			return _MappingInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_MappingInterpreter != value)
			{
				_MappingInterpreter = value;
				OnPropertyChanged("CargoVisibility");
			}
		}
	}

	public List<HoverInfoCargoViewModel> Cargo
	{
		[CompilerGenerated]
		get
		{
			return m_MockInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_MockInterpreter != value)
			{
				m_MockInterpreter = value;
				OnPropertyChanged("Cargo");
			}
		}
	}

	public Visibility WeaponSummaryVisibility
	{
		[CompilerGenerated]
		get
		{
			return _TagInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_TagInterpreter != value)
			{
				_TagInterpreter = value;
				OnPropertyChanged("WeaponSummaryVisibility");
			}
		}
	}

	public Visibility WeaponDetailsVisibility
	{
		[CompilerGenerated]
		get
		{
			return _FieldInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_FieldInterpreter != value)
			{
				_FieldInterpreter = value;
				OnPropertyChanged("WeaponDetailsVisibility");
			}
		}
	}

	public Visibility WeaponVisibility
	{
		[CompilerGenerated]
		get
		{
			return queueInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (queueInterpreter != value)
			{
				queueInterpreter = value;
				OnPropertyChanged("WeaponVisibility");
			}
		}
	}

	public List<HoverInfoWeaponViewModel> WeaponsDetails
	{
		[CompilerGenerated]
		get
		{
			return regInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (regInterpreter != value)
			{
				regInterpreter = value;
				OnPropertyChanged("WeaponsDetails");
			}
		}
	}

	public Visibility MountsDetailsVisibility
	{
		[CompilerGenerated]
		get
		{
			return _ParamInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_ParamInterpreter != value)
			{
				_ParamInterpreter = value;
				OnPropertyChanged("MountsDetailsVisibility");
			}
		}
	}

	public List<HoverInfoMountViewModel> MountsDetails
	{
		[CompilerGenerated]
		get
		{
			return pageInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (pageInterpreter != value)
			{
				pageInterpreter = value;
				OnPropertyChanged("MountsDetails");
			}
		}
	}

	public string ContactClass
	{
		[CompilerGenerated]
		get
		{
			return _RulesInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_RulesInterpreter, value, StringComparison.Ordinal))
			{
				_RulesInterpreter = value;
				OnPropertyChanged("ContactClass");
			}
		}
	}

	public string UnitDamage
	{
		[CompilerGenerated]
		get
		{
			return methodInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(methodInterpreter, value, StringComparison.Ordinal))
			{
				methodInterpreter = value;
				OnPropertyChanged("UnitDamage");
			}
		}
	}

	public FuelViewModel FuelViewModel
	{
		[CompilerGenerated]
		get
		{
			return _BaseInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_BaseInterpreter != value)
			{
				_BaseInterpreter = value;
				OnPropertyChanged("FuelViewModel");
			}
		}
	}

	public Visibility FuelSummaryVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_PolicyInterpreter != value)
			{
				m_PolicyInterpreter = value;
				OnPropertyChanged("FuelSummaryVisibility");
			}
		}
	}

	public Visibility FuelDetailsVisibility
	{
		[CompilerGenerated]
		get
		{
			return _BroadcasterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_BroadcasterInterpreter != value)
			{
				_BroadcasterInterpreter = value;
				OnPropertyChanged("FuelDetailsVisibility");
			}
		}
	}

	public Visibility DamageVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_IdentifierInterpreter != value)
			{
				m_IdentifierInterpreter = value;
				OnPropertyChanged("DamageVisibility");
			}
		}
	}

	public Visibility DamageComponentVisibility
	{
		[CompilerGenerated]
		get
		{
			return _PrinterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_PrinterInterpreter != value)
			{
				_PrinterInterpreter = value;
				OnPropertyChanged("DamageComponentVisibility");
			}
		}
	}

	public Visibility DamageFireVisibility
	{
		[CompilerGenerated]
		get
		{
			return parserInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (parserInterpreter != value)
			{
				parserInterpreter = value;
				OnPropertyChanged("DamageFireVisibility");
			}
		}
	}

	public Visibility DamageFloodVisibility
	{
		[CompilerGenerated]
		get
		{
			return _AlgoInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_AlgoInterpreter != value)
			{
				_AlgoInterpreter = value;
				OnPropertyChanged("DamageFloodVisibility");
			}
		}
	}

	public Visibility DamagePointsVisibility
	{
		[CompilerGenerated]
		get
		{
			return _DatabaseInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_DatabaseInterpreter != value)
			{
				_DatabaseInterpreter = value;
				OnPropertyChanged("DamagePointsVisibility");
			}
		}
	}

	public GridLength DamageComponentOK
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_InterceptorInterpreter != value)
			{
				m_InterceptorInterpreter = value;
				OnPropertyChanged("DamageComponentOK");
			}
		}
	}

	public GridLength DamageComponentLight
	{
		[CompilerGenerated]
		get
		{
			return messageInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (messageInterpreter != value)
			{
				messageInterpreter = value;
				OnPropertyChanged("DamageComponentLight");
			}
		}
	}

	public GridLength DamageComponentMedium
	{
		[CompilerGenerated]
		get
		{
			return m_ProductInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ProductInterpreter != value)
			{
				m_ProductInterpreter = value;
				OnPropertyChanged("DamageComponentMedium");
			}
		}
	}

	public GridLength DamageComponentHeavy
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_AnnotationInterpreter != value)
			{
				m_AnnotationInterpreter = value;
				OnPropertyChanged("DamageComponentHeavy");
			}
		}
	}

	public GridLength DamageComponentDestroyed
	{
		[CompilerGenerated]
		get
		{
			return _IteratorInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_IteratorInterpreter != value)
			{
				_IteratorInterpreter = value;
				OnPropertyChanged("DamageComponentDestroyed");
			}
		}
	}

	public int DamageFlood
	{
		[CompilerGenerated]
		get
		{
			return initializerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (initializerInterpreter != value)
			{
				initializerInterpreter = value;
				OnPropertyChanged("DamageFlood");
			}
		}
	}

	public int DamageFire
	{
		[CompilerGenerated]
		get
		{
			return _RoleInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_RoleInterpreter != value)
			{
				_RoleInterpreter = value;
				OnPropertyChanged("DamageFire");
			}
		}
	}

	public int DamagePoints
	{
		[CompilerGenerated]
		get
		{
			return _FactoryInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_FactoryInterpreter != value)
			{
				_FactoryInterpreter = value;
				OnPropertyChanged("DamagePoints");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_AttributeInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_AttributeInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_AttributeInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_AttributeInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static HoverInfoViewModel()
	{
		serviceInterpreter = new DispatcherTimer();
	}

	public HoverInfoViewModel(ContentControl contentControl_0, ElementHost elementHost_0)
	{
		m_SystemInterpreter = contentControl_0;
		candidateInterpreter = elementHost_0;
	}

	public void Update(Module_Unit.Unit unit_0)
	{
		Unit = unit_0;
		UnitName = unit_0.Name;
		UnitType = unit_0.UnitClass;
		if (!unit_0.DisableWriter())
		{
			SideString = "分方: " + unit_0.GetUnitSide().Name;
			CourseString = $"Course: {unit_0.CurrentHeading:00}°";
			SpeedString = $"速度: {unit_0.CurrentSpeed:0} 节";
		}
		WorldWindow worldWindow = ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1;
		DrawArgs utilsResolver = InterpreterObjectListener._UtilsResolver;
		bool? nullable_ = null;
		double double_ = unit_0.GetLatitude(nullable_);
		bool? nullable_2 = null;
		double double_2 = unit_0.GetLongitude(nullable_2);
		int int_ = 0;
		int int_2 = 0;
		ManagerListenerManager.InstantiateInterruptibleMap(worldWindow, utilsResolver, ref double_, ref double_2, ref int_, ref int_2);
		unit_0.SetLongitude(nullable_2, double_2);
		unit_0.SetLatitude(nullable_, double_);
		candidateInterpreter.Top = 0;
		candidateInterpreter.Left = -1000;
		candidateInterpreter.Height = 1000;
		if (unit_0 is Weapon)
		{
			Weapon weapon = (Weapon)unit_0;
			StatusString = "状态：" + Misc.ToEnglishString(weapon.Status, weapon);
			LoadoutString = "";
			LoginIterator();
		}
		else if (unit_0 is Contact)
		{
			ConnectIterator();
		}
		else if (unit_0 is Group)
		{
			Group group = (Group)unit_0;
			StatusString = "状态：" + Misc.ToEnglishString(group.Status, group);
			LoadoutString = "";
			if (group.Units.Values.Any((ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
			{
				LoadoutString = ((Aircraft)group.Units.Values.First()).LoadoutName;
			}
			NewIterator();
			ComputeIterator();
			ValidateIterator();
			LogoutIterator();
			ViewIterator();
			GetIterator();
			WriteIterator();
			DeleteIterator();
			CustomizeIterator();
		}
		else if (unit_0 is ActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)unit_0;
			StatusString = "状态：" + Misc.ToEnglishString(activeUnit.Status, activeUnit);
			if (activeUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
			{
				LoadoutString = ((Aircraft)activeUnit).LoadoutName;
			}
			AddIterator();
			LoginIterator();
			NewIterator();
			CloneIterator();
			DestroyIterator();
			ViewIterator();
			GetIterator();
			WriteIterator();
			DeleteIterator();
			CustomizeIterator();
		}
		serviceInterpreter.Interval = TimeSpan.FromMilliseconds(1.0);
		serviceInterpreter.Tick += MoveIterator;
		serviceInterpreter.Start();
	}

	private void CustomizeIterator()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		if (activeUnit.IsShip && ((Ship)activeUnit).IsNuke)
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			FuelDetailsVisibility = Visibility.Collapsed;
		}
		else if (activeUnit.IsSubmarine && (((Submarine)activeUnit).IsNuke || ((Submarine)activeUnit).Fuel_ReadOnly.Count == 0))
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			FuelDetailsVisibility = Visibility.Collapsed;
		}
		else if (activeUnit.IsFacility)
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			FuelDetailsVisibility = Visibility.Collapsed;
		}
		else if (activeUnit.IsWeapon)
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			FuelDetailsVisibility = Visibility.Collapsed;
		}
		else if (activeUnit.IsSatellite)
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			FuelDetailsVisibility = Visibility.Collapsed;
		}
		else
		{
			FuelViewModel = new FuelViewModel(activeUnit);
			FuelSummaryVisibility = Visibility.Visible;
			FuelDetailsVisibility = Visibility.Visible;
		}
		if (HoverInfoOptionsViewModel.Singleton.Fuel == HoverInfoEnableDetailedEnum.ShowDetailed)
		{
			FuelSummaryVisibility = Visibility.Collapsed;
			return;
		}
		if (HoverInfoOptionsViewModel.Singleton.Fuel == HoverInfoEnableDetailedEnum.ShowSummary)
		{
			FuelDetailsVisibility = Visibility.Collapsed;
			return;
		}
		FuelSummaryVisibility = Visibility.Collapsed;
		FuelDetailsVisibility = Visibility.Collapsed;
	}

	private void CloneIterator()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		foreach (PlatformComponent item in activeUnit.OrderIssuer())
		{
			switch (item.Status)
			{
			case PlatformComponent._ComponentStatus.Operational:
				num5++;
				break;
			case PlatformComponent._ComponentStatus.Damaged:
				switch (item.DamageSeverity)
				{
				case PlatformComponent._DamageSeverityFactor.Light:
					num2++;
					break;
				case PlatformComponent._DamageSeverityFactor.Medium:
					num3++;
					break;
				case PlatformComponent._DamageSeverityFactor.Heavy:
					num++;
					break;
				}
				break;
			case PlatformComponent._ComponentStatus.Destroyed:
				num4++;
				break;
			}
			num6++;
		}
		DamageComponentOK = new GridLength(num5, GridUnitType.Star);
		DamageComponentLight = new GridLength(num2, GridUnitType.Star);
		DamageComponentMedium = new GridLength(num3, GridUnitType.Star);
		DamageComponentHeavy = new GridLength(num, GridUnitType.Star);
		DamageComponentDestroyed = new GridLength(num4, GridUnitType.Star);
		switch (activeUnit.Damage.FloodIntensity)
		{
		case ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding:
			DamageFlood = 0;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Minor:
			DamageFlood = 25;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Major:
			DamageFlood = 50;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Severe:
			DamageFlood = 75;
			break;
		case ActiveUnit_Damage.FloodingIntensityLevel.Capsizing:
			DamageFlood = 100;
			break;
		}
		switch (activeUnit.Damage.FireIntensity)
		{
		case ActiveUnit_Damage.FireIntensityLevel.NoFire:
			DamageFire = 0;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Minor:
			DamageFire = 25;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Major:
			DamageFire = 50;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Severe:
			DamageFire = 75;
			break;
		case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
			DamageFire = 100;
			break;
		}
		DamagePoints = (int)Math.Round(activeUnit.Damage.DamagePercent);
		if (HoverInfoOptionsViewModel.Singleton.Damage == HoverInfoEnableEnum.Hide)
		{
			DamageVisibility = Visibility.Collapsed;
			DamageComponentVisibility = Visibility.Collapsed;
			DamageFireVisibility = Visibility.Collapsed;
			DamageFloodVisibility = Visibility.Collapsed;
			DamagePointsVisibility = Visibility.Collapsed;
			return;
		}
		DamageVisibility = Visibility.Collapsed;
		if (DamageFire <= 1)
		{
			DamageFireVisibility = Visibility.Collapsed;
		}
		else
		{
			DamageVisibility = Visibility.Visible;
			DamageFireVisibility = Visibility.Visible;
		}
		if (DamageFlood <= 1)
		{
			DamageFloodVisibility = Visibility.Collapsed;
		}
		else
		{
			DamageVisibility = Visibility.Visible;
			DamageFloodVisibility = Visibility.Visible;
		}
		if (DamagePoints <= 1)
		{
			DamagePointsVisibility = Visibility.Collapsed;
		}
		else
		{
			DamageVisibility = Visibility.Visible;
			DamagePointsVisibility = Visibility.Visible;
		}
		if (num6 == num5)
		{
			DamageComponentVisibility = Visibility.Collapsed;
			return;
		}
		DamageVisibility = Visibility.Visible;
		DamageComponentVisibility = Visibility.Visible;
	}

	private void ConnectIterator()
	{
		Contact contact = (Contact)Unit;
		if (contact.IDStatus <= Contact_Base.IdentificationStatus.KnownType)
		{
			ContactClass = "未知的类型";
		}
		else
		{
			ContactClass = Misc.ReadRequest(contact.ActualUnit.UnitClass);
			if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
			{
				ImageSource = StrategyRegistryFilter.CountInterruptibleComparator(StrategyRegistryFilter.ConnectInterruptibleComparator(contact.ActualUnit));
			}
		}
		CourseString = "朝向: " + contact.HeadingString();
		if (((contact.Type == Contact_Base.ContactType.Air) | (contact.Type == Contact_Base.ContactType.Missile)) & contact.AltitudeIsKnown)
		{
			SpeedString = "速度：" + Conversions.ToString((int)Math.Round(contact.CurrentSpeed)) + " 节 (马赫 " + $"{Physics.CompareStub(contact.GetCurrentAltitude(), contact.CurrentSpeed):0.00}" + ")";
		}
		else
		{
			SpeedString = "速度：" + contact.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit, "Unknown");
		}
		if (contact.SideIsKnown)
		{
			if (!Information.IsNothing(contact.ActualUnit.GetUnitSide()))
			{
				SideString = "分方：" + contact.ActualUnit.GetUnitSide().Name;
			}
		}
		else
		{
			SideString = "分方：未知";
		}
		UnitDamage = "损伤：" + Misc.FlushRequest(contact.BDA_StructuralIntegrity);
	}

	private void MoveIterator(object sender, EventArgs e)
	{
		serviceInterpreter.Stop();
		serviceInterpreter.Tick -= MoveIterator;
		WorldWindow worldWindow = ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1;
		DrawArgs utilsResolver = InterpreterObjectListener._UtilsResolver;
		Module_Unit.Unit unit = Unit;
		bool? nullable_ = null;
		double double_ = unit.GetLatitude(nullable_);
		Module_Unit.Unit unit2 = Unit;
		bool? nullable_2 = null;
		double double_2 = unit2.GetLongitude(nullable_2);
		int int_ = 0;
		int int_2 = 0;
		ManagerListenerManager.InstantiateInterruptibleMap(worldWindow, utilsResolver, ref double_, ref double_2, ref int_, ref int_2);
		unit2.SetLongitude(nullable_2, double_2);
		unit.SetLatitude(nullable_, double_);
		candidateInterpreter.Left = int_ + 25;
		candidateInterpreter.Height = (int)Math.Round(m_SystemInterpreter.ActualHeight + 25.0);
		candidateInterpreter.Top = (int)Math.Round(Math.Max(0.0, (double)int_2 - (double)candidateInterpreter.Height / 2.0));
		candidateInterpreter.BringToFront();
	}

	private void DeleteIterator()
	{
		Cargo = (from F in PatchIterator().SelectMany((ActiveUnit F) => F.OnboardCargo)
			group F by F.CargoObjectName into F
			select new HoverInfoCargoViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			}).ToList();
		if (Cargo.Any())
		{
			CargoVisibility = Visibility.Visible;
		}
		else
		{
			CargoVisibility = Visibility.Collapsed;
		}
		if (HoverInfoOptionsViewModel.Singleton.Cargo == HoverInfoEnableEnum.Hide)
		{
			CargoVisibility = Visibility.Collapsed;
		}
	}

	private void AddIterator()
	{
		_ = (ActiveUnit)Unit;
		if (HoverInfoOptionsViewModel.Singleton.Sensor == HoverInfoEnableEnum.Show)
		{
			SensorVisibility = Visibility.Visible;
		}
		else
		{
			SensorVisibility = Visibility.Collapsed;
		}
	}

	private void DestroyIterator()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		MountsDetails = (from F in activeUnit.Mounts
			select F.Name into F
			group F by F into F
			select new HoverInfoMountViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			} into F
			orderby F.Header
			select F).ToList();
		if (MountsDetails.Any())
		{
			if (HoverInfoOptionsViewModel.Singleton.Vehicles == HoverInfoEnableEnum.Show)
			{
				MountsDetailsVisibility = Visibility.Visible;
			}
			else
			{
				MountsDetailsVisibility = Visibility.Collapsed;
			}
		}
		else
		{
			MountsDetailsVisibility = Visibility.Collapsed;
		}
	}

	private void ComputeIterator()
	{
		Group group = (Group)Unit;
		if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			if (group.CurrentAltitude_AGL <= 3048f)
			{
				if (group.Type == Group.GroupType.AirGroup)
				{
					if (Module_Unit.ResetTokenizer(group))
					{
						AltString = "高度：" + $"{group.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + $"{group.CurrentAltitude_AGL * 3.28084f:0}" + "英尺 真高）";
					}
					else
					{
						AltString = "高度：" + $"{group.GetCurrentAltitude() * 3.28084f:0}" + " ft ASL";
					}
				}
				else
				{
					AltString = "高度：" + $"{group.GetCurrentAltitude() * 3.28084f:0}".ToString() + " 英尺";
				}
			}
			else if (group.Type == Group.GroupType.AirGroup)
			{
				AltString = "高度：" + $"{group.GetCurrentAltitude() * 3.28084f:0}".ToString() + " ft ASL";
			}
			else
			{
				AltString = "高度：" + $"{group.GetCurrentAltitude() * 3.28084f:0}".ToString() + " 英尺";
			}
		}
		else if (group.CurrentAltitude_AGL <= 3048f)
		{
			if (group.Type == Group.GroupType.AirGroup)
			{
				if (Module_Unit.ResetTokenizer(group))
				{
					AltString = "高度：" + string.Format("{0:0.0}", group.GetCurrentAltitude(), 0) + " 米 海高 (" + string.Format("{0:0.0}", group.CurrentAltitude_AGL, 0) + "米 真高）";
				}
				else
				{
					AltString = "高度：" + string.Format("{0:0.0}", group.GetCurrentAltitude(), 0) + " 米 海高";
				}
			}
			else
			{
				AltString = "高度：" + string.Format("{0:0.0}", group.GetCurrentAltitude(), 0).ToString() + " 米";
			}
		}
		else if (group.Type == Group.GroupType.AirGroup)
		{
			AltString = "高度：" + string.Format("{0:0.0}", group.GetCurrentAltitude(), 0).ToString() + " 米 海高";
		}
		else
		{
			AltString = "高度：" + string.Format("{0:0.0}", group.GetCurrentAltitude(), 0).ToString() + " 米";
		}
	}

	private IEnumerable<ActiveUnit> PatchIterator()
	{
		if (Unit is Group)
		{
			return ((Group)Unit).Units.Values;
		}
		return new List<ActiveUnit> { (ActiveUnit)Unit };
	}

	private string SelectIterator(string string_0, bool bool_0 = true)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length * 2);
		stringBuilder.Append(string_0[0]);
		int num = string_0.Length - 1;
		for (int i = 1; i <= num; i++)
		{
			if (char.IsUpper(string_0[i]) && ((string_0[i - 1] != ' ' && !char.IsUpper(string_0[i - 1])) || (bool_0 && char.IsUpper(string_0[i - 1]) && i < string_0.Length - 1 && !char.IsUpper(string_0[i + 1]))))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append(string_0[i]);
		}
		return stringBuilder.Replace('_', ' ').Replace("  ", " ").Replace("  ", " ")
			.ToString();
	}

	private string CallIterator(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 is Ship)
		{
			Ship ship = (Ship)activeUnit_0;
			return SelectIterator(ship.Type.ToString());
		}
		if (activeUnit_0 is Aircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			return SelectIterator(aircraft.Type.ToString());
		}
		if (activeUnit_0 is Submarine)
		{
			Submarine submarine = (Submarine)activeUnit_0;
			return SelectIterator(submarine.Type.ToString());
		}
		if (activeUnit_0 is Facility)
		{
			Facility facility = (Facility)activeUnit_0;
			return SelectIterator(facility.Category.ToString());
		}
		if (activeUnit_0 is Weapon)
		{
			return Misc.ForgotRequest(((Weapon)activeUnit_0).Type);
		}
		if (activeUnit_0 is Satellite)
		{
			Satellite satellite = (Satellite)activeUnit_0;
			return SelectIterator(satellite.Type.ToString());
		}
		return "Unit";
	}

	private void LogoutIterator()
	{
		Group group = (Group)Unit;
		GroupMembers = (from F in @group.Units.Values.GroupBy(CallIterator)
			select new HoverInfoGroupMemberViewModel
			{
				Header = F.Key,
				Quantity = F.Count()
			} into F
			orderby F.Header
			select F).ToList();
		if (HoverInfoOptionsViewModel.Singleton.GroupMembers == HoverInfoEnableEnum.Show)
		{
			GroupMembersVisibility = Visibility.Visible;
		}
		else
		{
			GroupMembersVisibility = Visibility.Collapsed;
		}
	}

	private void ViewIterator()
	{
		AirParasites = PatchIterator().SelectMany((ActiveUnit F) => F.AirOps.EmbarkedAircraft_ReadOnly).GroupBy(CallIterator).Select(delegate(IGrouping<string, Aircraft> F)
		{
			Aircraft[] source2 = F.ToArray();
			int num3 = source2.Count();
			int num4 = source2.Count((Aircraft aircraft_0) => aircraft_0.AirOps.ConditionTimer <= 0f);
			return new HoverInfoParasiteViewModel
			{
				Header = F.Key,
				Ready = $"{num4}/{num3}"
			};
		})
			.ToList();
		BoatParasites = PatchIterator().SelectMany((ActiveUnit F0) => F0.DockingOps.EmbarkedBoats).GroupBy(CallIterator).Select(delegate(IGrouping<string, ActiveUnit> F)
		{
			ActiveUnit[] source = F.ToArray();
			int num = source.Count();
			int num2 = source.Count((ActiveUnit activeUnit_0) => activeUnit_0.DockingOps.ConditionTimer <= 0f);
			return new HoverInfoParasiteViewModel
			{
				Header = F.Key,
				Ready = $"{num2}/{num}"
			};
		})
			.ToList();
		if (AirParasites.Any())
		{
			AirParasiteVisibility = Visibility.Visible;
		}
		else
		{
			AirParasiteVisibility = Visibility.Collapsed;
		}
		if (BoatParasites.Any())
		{
			BoatParasiteVisibility = Visibility.Visible;
		}
		else
		{
			BoatParasiteVisibility = Visibility.Collapsed;
		}
		if (HoverInfoOptionsViewModel.Singleton.AirParasite == HoverInfoEnableEnum.Hide)
		{
			AirParasiteVisibility = Visibility.Collapsed;
		}
		if (HoverInfoOptionsViewModel.Singleton.BoatParasite == HoverInfoEnableEnum.Hide)
		{
			BoatParasiteVisibility = Visibility.Collapsed;
		}
	}

	private void ValidateIterator()
	{
		Group group = (Group)Unit;
		if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
		{
			GroupImages = (from F in @group.Units.Select(delegate(KeyValuePair<string, ActiveUnit> F)
				{
					KeyValuePair<string, ActiveUnit> keyValuePair = F;
					return StrategyRegistryFilter.CountInterruptibleComparator(StrategyRegistryFilter.ConnectInterruptibleComparator(keyValuePair.Value));
				})
				where F != null
				select F).ToList();
		}
	}

	private void LoginIterator()
	{
		ActiveUnit scenario_ = (ActiveUnit)Unit;
		if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
		{
			ImageSource = StrategyRegistryFilter.CountInterruptibleComparator(StrategyRegistryFilter.ConnectInterruptibleComparator(scenario_));
		}
	}

	private void GetIterator()
	{
		ActiveUnit activeUnit = (ActiveUnit)Unit;
		if (activeUnit.AssignedMissionOrPackage() == null)
		{
			MissionVisibility = Visibility.Collapsed;
			return;
		}
		MissionName = activeUnit.AssignedMissionOrPackage().Name ?? "";
		MissionClass = $"{activeUnit.AssignedMissionOrPackage().MissionClass}";
		MissionStatus = $"{activeUnit.AssignedMissionOrPackage().GetStatus(Client.CurrentScenario)}";
		if (HoverInfoOptionsViewModel.Singleton.Mission == HoverInfoEnableEnum.Hide)
		{
			MissionVisibility = Visibility.Collapsed;
		}
		if (HoverInfoOptionsViewModel.Singleton.Mission == HoverInfoEnableEnum.Show)
		{
			MissionVisibility = Visibility.Visible;
		}
	}

	private void WriteIterator()
	{
		int Local_temp_AIR_LR = 0;
		int Local_temp_AIR_MR = 0;
		int Local_temp_AIR_SR = 0;
		int Local_temp_SURF_LR = 0;
		int Local_temp_SURF_MR = 0;
		int Local_temp_SURF_SR = 0;
		int Local_temp_LAND_LR = 0;
		int Local_temp_LAND_MR = 0;
		int Local_temp_LAND_SR = 0;
		int Local_temp_SUB_LR = 0;
		int Local_temp_SUB_MR = 0;
		int Local_temp_SUB_SR = 0;
		List<Tuple<Weapon, int>> list = new List<Tuple<Weapon, int>>();
		VB_0024AnonymousDelegate_1<Weapon, int> vB_0024AnonymousDelegate_ = delegate(Weapon myWeapon, int myCount)
		{
			if (myWeapon.IsAAW)
			{
				if (myWeapon.MaxAirRange <= 25f)
				{
					if (myWeapon.MaxAirRange <= 5f)
					{
						Local_temp_AIR_SR += myCount;
					}
					else
					{
						Local_temp_AIR_MR += myCount;
					}
				}
				else
				{
					Local_temp_AIR_LR += myCount;
				}
			}
			if (myWeapon.IsASuW_Naval)
			{
				if (myWeapon.MaxSurfaceRange <= 25f)
				{
					if (myWeapon.MaxSurfaceRange <= 5f)
					{
						Local_temp_SURF_SR += myCount;
					}
					else
					{
						Local_temp_SURF_MR += myCount;
					}
				}
				else
				{
					Local_temp_SURF_LR += myCount;
				}
			}
			if (myWeapon.IsASuW_Land)
			{
				if (myWeapon.MaxLandRange <= 25f)
				{
					if (myWeapon.MaxLandRange <= 5f)
					{
						Local_temp_LAND_SR += myCount;
					}
					else
					{
						Local_temp_LAND_MR += myCount;
					}
				}
				else
				{
					Local_temp_LAND_LR += myCount;
				}
			}
			if (myWeapon.IsASW)
			{
				if (myWeapon.MaxSubsurfaceRange <= 25f)
				{
					if (myWeapon.MaxSubsurfaceRange <= 5f)
					{
						Local_temp_SUB_SR += myCount;
					}
					else
					{
						Local_temp_SUB_MR += myCount;
					}
				}
				else
				{
					Local_temp_SUB_LR += myCount;
				}
			}
		};
		foreach (ActiveUnit item in PatchIterator())
		{
			foreach (Mount mount in item.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(mountWeapon.int_0);
					int currentLoad = mountWeapon.CurrentLoad;
					list.Add(new Tuple<Weapon, int>(weapon, currentLoad));
					vB_0024AnonymousDelegate_(weapon, currentLoad);
				}
			}
			Magazine[] totalMagazines = item.TotalMagazines;
			for (int i = 0; i < totalMagazines.Length; i++)
			{
				foreach (WeaponRec weapon4 in totalMagazines[i].Weapons)
				{
					Weapon weapon2 = Client.CurrentScenario.Cache_GetWeapon(weapon4.int_0);
					int currentLoad2 = weapon4.CurrentLoad;
					list.Add(new Tuple<Weapon, int>(weapon2, currentLoad2));
					vB_0024AnonymousDelegate_(weapon2, currentLoad2);
				}
			}
			if (item.IsAircraft && ((Aircraft)item).Loadout != null)
			{
				WeaponRec[] weapons = ((Aircraft)item).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					Weapon weapon3 = Client.CurrentScenario.Cache_GetWeapon(weaponRec.int_0);
					int currentLoad3 = weaponRec.CurrentLoad;
					list.Add(new Tuple<Weapon, int>(weapon3, currentLoad3));
					vB_0024AnonymousDelegate_(weapon3, currentLoad3);
				}
			}
		}
		AIR_LR = Local_temp_AIR_LR;
		AIR_MR = Local_temp_AIR_MR;
		AIR_SR = Local_temp_AIR_SR;
		SURF_LR = Local_temp_SURF_LR;
		SURF_MR = Local_temp_SURF_MR;
		SURF_SR = Local_temp_SURF_SR;
		LAND_LR = Local_temp_LAND_LR;
		LAND_MR = Local_temp_LAND_MR;
		LAND_SR = Local_temp_LAND_SR;
		SUB_LR = Local_temp_SUB_LR;
		SUB_MR = Local_temp_SUB_MR;
		SUB_SR = Local_temp_SUB_SR;
		WeaponsDetails = (from F in list
			group F by CallIterator(F.Item1) into F
			select new HoverInfoWeaponViewModel
			{
				Header = F.Key,
				Quantity = F.Sum((Tuple<Weapon, int> tuple_0) => tuple_0.Item2)
			} into F
			where F.Quantity > 0
			orderby F.Header
			select F).ToList();
		if (WeaponsDetails.Any())
		{
			WeaponVisibility = Visibility.Visible;
			if (HoverInfoOptionsViewModel.Singleton.Weapons == HoverInfoEnableDetailedEnum.ShowDetailed)
			{
				WeaponDetailsVisibility = Visibility.Visible;
				WeaponSummaryVisibility = Visibility.Collapsed;
			}
			if (HoverInfoOptionsViewModel.Singleton.Weapons == HoverInfoEnableDetailedEnum.ShowSummary)
			{
				WeaponDetailsVisibility = Visibility.Collapsed;
				WeaponSummaryVisibility = Visibility.Visible;
			}
		}
		else
		{
			WeaponDetailsVisibility = Visibility.Collapsed;
			WeaponSummaryVisibility = Visibility.Collapsed;
			WeaponVisibility = Visibility.Collapsed;
		}
	}

	private void NewIterator()
	{
		ActiveUnit obj = (ActiveUnit)Unit;
		bool flag = false;
		bool flag2 = false;
		flag = obj.Sensors_ReadOnly().Any((Sensor F) => (F.Type == Sensor.Sensor_Type.Radar) & F.IsActive);
		flag2 = obj.Sensors_ReadOnly().Any((Sensor F) => F.IsSonar & F.IsActive);
		bool num = obj.Sensors_ReadOnly().Any((Sensor F) => F.IsOECM & F.IsActive);
		if (flag)
		{
			RadarOnVisibility = Visibility.Visible;
			RadarOffVisibility = Visibility.Collapsed;
		}
		else
		{
			RadarOnVisibility = Visibility.Collapsed;
			RadarOffVisibility = Visibility.Visible;
		}
		if (flag2)
		{
			SonarOnVisibility = Visibility.Visible;
			SonarOffVisibility = Visibility.Collapsed;
		}
		else
		{
			SonarOnVisibility = Visibility.Collapsed;
			SonarOffVisibility = Visibility.Visible;
		}
		if (num)
		{
			OECMOnVisibility = Visibility.Visible;
			OECMOffVisibility = Visibility.Collapsed;
		}
		else
		{
			OECMOnVisibility = Visibility.Collapsed;
			OECMOffVisibility = Visibility.Visible;
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_AttributeInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
