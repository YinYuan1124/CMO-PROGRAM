using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class MapProfile
{
	public delegate void GodsEyeStatusChangedEventHandler(MapProfile theProfile);

	public struct _RangeSymbol_Colors
	{
		public Color AASensor;

		public Color AAWeapon;

		public Color ASSensor;

		public Color ASWeapon;

		public Color AGWeapon;

		public Color color_0;

		public Color color_1;

		public Color ACRange;
	}

	public enum _ShowElement : short
	{
		All,
		SelectedUnit,
		DontShow
	}

	public enum _ShowEmissionTypes : short
	{
		All,
		FireControlOnly,
		All_SelectedUnitOnly
	}

	public enum MapViewMode : byte
	{
		GroupView,
		UnitView
	}

	private bool _PageDic;

	private bool rulesDic;

	private bool m_MethodDic;

	private bool _ServiceDic;

	private bool m_SystemDic;

	private bool m_CandidateDic;

	private bool _BaseDic;

	private bool policyDic;

	private bool _BroadcasterDic;

	private bool m_IdentifierDic;

	private bool printerDic;

	private bool _ParserDic;

	private bool algoDic;

	private bool databaseDic;

	private bool m_InterceptorDic;

	private bool messageDic;

	private _ShowElement productDic;

	private _ShowEmissionTypes m_AnnotationDic;

	public _RangeSymbol_Colors RangeSymbol_Colors;

	private _ShowElement _IteratorDic;

	private _ShowElement m_InitializerDic;

	private _ShowElement _RoleDic;

	private _ShowElement factoryDic;

	private _ShowElement m_AttributeDic;

	public MapViewMode ViewMode;

	private bool _EventDic;

	private string globalDic;

	private bool workerDic;

	private Color _AccountDic;

	private Color m_StateDic;

	[ThreadStatic]
	private static StringBuilder authenticationDic;

	private _ShowElement m_ParamsDic;

	private _ShowElement infoDic;

	private _ShowElement m_HelperDic;

	private _ShowElement _MapperDic;

	private _ShowElement _ManagerDic;

	private _ShowElement getterDic;

	private _ShowElement _ProducerDic;

	private _ShowElement procDic;

	[CompilerGenerated]
	private static GodsEyeStatusChangedEventHandler structConsumer;

	public bool GodsEye
	{
		get
		{
			return _EventDic;
		}
		set
		{
			bool num = _EventDic != value;
			_EventDic = value;
			if (num)
			{
				structConsumer?.Invoke(this);
			}
		}
	}

	public bool ShowDynamicNoiseSignature
	{
		get
		{
			return m_MethodDic;
		}
		set
		{
			m_MethodDic = value;
		}
	}

	public bool ShowLatLonGrid
	{
		get
		{
			return _PageDic;
		}
		set
		{
			_PageDic = value;
		}
	}

	public bool ShowBaseEarth
	{
		get
		{
			return rulesDic;
		}
		set
		{
			rulesDic = value;
		}
	}

	public bool Layer_Sentinel2
	{
		get
		{
			return _ServiceDic;
		}
		set
		{
			_ServiceDic = value;
		}
	}

	public bool Layer_VirtualEarth
	{
		get
		{
			return algoDic;
		}
		set
		{
			algoDic = value;
		}
	}

	public bool Layer_BMNG
	{
		get
		{
			return m_SystemDic;
		}
		set
		{
			m_SystemDic = value;
		}
	}

	public bool Layer_Relief
	{
		get
		{
			return m_CandidateDic;
		}
		set
		{
			m_CandidateDic = value;
		}
	}

	public bool Layer_StamenTerrain
	{
		get
		{
			return _BaseDic;
		}
		set
		{
			_BaseDic = value;
		}
	}

	public bool Layer_StamenRoads
	{
		get
		{
			return policyDic;
		}
		set
		{
			policyDic = value;
		}
	}

	public bool Layer_Borders
	{
		get
		{
			return _BroadcasterDic;
		}
		set
		{
			_BroadcasterDic = value;
		}
	}

	public bool Layer_Placenames
	{
		get
		{
			return m_IdentifierDic;
		}
		set
		{
			m_IdentifierDic = value;
		}
	}

	public bool Layer_LandCover
	{
		get
		{
			return printerDic;
		}
		set
		{
			printerDic = value;
		}
	}

	public bool Layer_OpenTopoMap
	{
		get
		{
			return _ParserDic;
		}
		set
		{
			_ParserDic = value;
		}
	}

	public bool DayNightLighting
	{
		get
		{
			return databaseDic;
		}
		set
		{
			databaseDic = value;
		}
	}

	public bool MergeRangeSymbols
	{
		get
		{
			return m_InterceptorDic;
		}
		set
		{
			m_InterceptorDic = value;
		}
	}

	public bool ShowNonFriendly
	{
		get
		{
			return messageDic;
		}
		set
		{
			messageDic = value;
		}
	}

	public bool ColorDatablocks
	{
		get
		{
			return workerDic;
		}
		set
		{
			workerDic = value;
		}
	}

	public _ShowElement RangeSymbol_AASensor
	{
		get
		{
			return m_ParamsDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			m_ParamsDic = value;
		}
	}

	public _ShowElement RangeSymbol_AAWeapon
	{
		get
		{
			return infoDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			infoDic = value;
		}
	}

	public _ShowElement RangeSymbol_ASSensor
	{
		get
		{
			return m_HelperDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			m_HelperDic = value;
		}
	}

	public _ShowElement RangeSymbol_ASWeapon
	{
		get
		{
			return _MapperDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_MapperDic = value;
		}
	}

	public _ShowElement RangeSymbol_AGWeapon
	{
		get
		{
			return _ManagerDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ManagerDic = value;
		}
	}

	public _ShowElement RangeSymbol_ASWSensor
	{
		get
		{
			return getterDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			getterDic = value;
		}
	}

	public _ShowElement RangeSymbol_ASWWeapon
	{
		get
		{
			return _ProducerDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ProducerDic = value;
		}
	}

	public _ShowElement RangeSymbol_ACRange
	{
		get
		{
			return procDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			procDic = value;
		}
	}

	public Color RPColor
	{
		get
		{
			return _AccountDic;
		}
		set
		{
			_AccountDic = value;
		}
	}

	public Color WPColor
	{
		get
		{
			return m_StateDic;
		}
		set
		{
			m_StateDic = value;
		}
	}

	public _ShowElement ShowDatalinks
	{
		get
		{
			return m_InitializerDic;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			m_InitializerDic = value;
		}
	}

	public _ShowElement ShowDatablocks
	{
		get
		{
			return _RoleDic;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_RoleDic = value;
		}
	}

	public _ShowElement ShowTargetingVectors
	{
		get
		{
			return _IteratorDic;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_IteratorDic = value;
		}
	}

	public _ShowElement ShowIlluminationVectors
	{
		get
		{
			return factoryDic;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			factoryDic = value;
		}
	}

	public _ShowElement ShowContactEmissions
	{
		get
		{
			return productDic;
		}
		set
		{
			productDic = value;
		}
	}

	public _ShowEmissionTypes ShowContactEmissions_Details
	{
		get
		{
			return m_AnnotationDic;
		}
		set
		{
			m_AnnotationDic = value;
		}
	}

	public _ShowElement ShowRangeSymbols
	{
		get
		{
			return m_AttributeDic;
		}
		set
		{
			m_AttributeDic = value;
		}
	}

	public string String_0
	{
		get
		{
			return globalDic;
		}
		set
		{
			globalDic = value;
		}
	}

	public static event GodsEyeStatusChangedEventHandler GodsEyeStatusChanged
	{
		[CompilerGenerated]
		add
		{
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler = structConsumer;
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler2;
			do
			{
				godsEyeStatusChangedEventHandler2 = godsEyeStatusChangedEventHandler;
				GodsEyeStatusChangedEventHandler value2 = (GodsEyeStatusChangedEventHandler)Delegate.Combine(godsEyeStatusChangedEventHandler2, value);
				godsEyeStatusChangedEventHandler = Interlocked.CompareExchange(ref structConsumer, value2, godsEyeStatusChangedEventHandler2);
			}
			while ((object)godsEyeStatusChangedEventHandler != godsEyeStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler = structConsumer;
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler2;
			do
			{
				godsEyeStatusChangedEventHandler2 = godsEyeStatusChangedEventHandler;
				GodsEyeStatusChangedEventHandler value2 = (GodsEyeStatusChangedEventHandler)Delegate.Remove(godsEyeStatusChangedEventHandler2, value);
				godsEyeStatusChangedEventHandler = Interlocked.CompareExchange(ref structConsumer, value2, godsEyeStatusChangedEventHandler2);
			}
			while ((object)godsEyeStatusChangedEventHandler != godsEyeStatusChangedEventHandler2);
		}
	}

	public string ToXML()
	{
		string result = null;
		try
		{
			if (authenticationDic == null)
			{
				authenticationDic = new StringBuilder();
			}
			else
			{
				authenticationDic.Clear();
			}
			authenticationDic.Append("<MapProfile>");
			authenticationDic.Append("<ShowLatLonGrid>").Append(_PageDic.ToString()).Append("</ShowLatLonGrid>");
			authenticationDic.Append("<ShowBaseEarth>").Append(rulesDic.ToString()).Append("</ShowBaseEarth>");
			authenticationDic.Append("<ShowDynamicNoiseSignature>").Append(m_MethodDic.ToString()).Append("</ShowDynamicNoiseSignature>");
			authenticationDic.Append("<Layer_Sentinel2>").Append(_ServiceDic.ToString()).Append("</Layer_Sentinel2>");
			authenticationDic.Append("<Layer_BMNG>").Append(m_SystemDic.ToString()).Append("</Layer_BMNG>");
			authenticationDic.Append("<Layer_Relief>").Append(m_CandidateDic.ToString()).Append("</Layer_Relief>");
			authenticationDic.Append("<Layer_StamenTerrain>").Append(_BaseDic.ToString()).Append("</Layer_StamenTerrain>");
			authenticationDic.Append("<Layer_StamenRoads>").Append(policyDic.ToString()).Append("</Layer_StamenRoads>");
			authenticationDic.Append("<Layer_Borders>").Append(_BroadcasterDic.ToString()).Append("</Layer_Borders>");
			authenticationDic.Append("<Layer_Placenames>").Append(m_IdentifierDic.ToString()).Append("</Layer_Placenames>");
			authenticationDic.Append("<Layer_LandCover>").Append(printerDic.ToString()).Append("</Layer_LandCover>");
			authenticationDic.Append("<Layer_VirtualEarth>").Append(algoDic.ToString()).Append("</Layer_VirtualEarth>");
			authenticationDic.Append("<DayNightLighting>").Append(databaseDic.ToString()).Append("</DayNightLighting>");
			authenticationDic.Append("<RSVisible_AASensor>").Append(((short)RangeSymbol_AASensor).ToString()).Append("</RSVisible_AASensor>");
			authenticationDic.Append("<RSVisible_ASSensor>").Append(((short)RangeSymbol_ASSensor).ToString()).Append("</RSVisible_ASSensor>");
			authenticationDic.Append("<RSVisible_ASWSensor>").Append(((short)RangeSymbol_ASWSensor).ToString()).Append("</RSVisible_ASWSensor>");
			authenticationDic.Append("<RSVisible_AAWeapon>").Append(((short)RangeSymbol_AAWeapon).ToString()).Append("</RSVisible_AAWeapon>");
			authenticationDic.Append("<RSVisible_ASWeapon>").Append(((short)RangeSymbol_ASWeapon).ToString()).Append("</RSVisible_ASWeapon>");
			authenticationDic.Append("<RSVisible_AGWeapon>").Append(((short)RangeSymbol_AGWeapon).ToString()).Append("</RSVisible_AGWeapon>");
			authenticationDic.Append("<RSVisible_ASWWeapon>").Append(((short)RangeSymbol_ASWWeapon).ToString()).Append("</RSVisible_ASWWeapon>");
			authenticationDic.Append("<RSVisible_ACRange>").Append(((short)RangeSymbol_ACRange).ToString()).Append("</RSVisible_ACRange>");
			authenticationDic.Append("<ShowRangeSymbols>").Append(((byte)m_AttributeDic).ToString()).Append("</ShowRangeSymbols>");
			if (MergeRangeSymbols)
			{
				authenticationDic.Append("<MergeRangeSymbols>True</MergeRangeSymbols>");
			}
			if (ShowNonFriendly)
			{
				authenticationDic.Append("<ShowNonFriendly>True</ShowNonFriendly>");
			}
			if (ColorDatablocks)
			{
				authenticationDic.Append("<ColorDatablocks>True</ColorDatablocks>");
			}
			authenticationDic.Append("<ShowTargetingVectors>").Append(((byte)ShowTargetingVectors).ToString()).Append("</ShowTargetingVectors>");
			authenticationDic.Append("<ShowDatalinks>").Append(((byte)ShowDatalinks).ToString()).Append("</ShowDatalinks>");
			authenticationDic.Append("<ShowDatablocks>").Append(((byte)ShowDatablocks).ToString()).Append("</ShowDatablocks>");
			authenticationDic.Append("<ShowIlluminationVectors>").Append(((byte)ShowIlluminationVectors).ToString()).Append("</ShowIlluminationVectors>");
			authenticationDic.Append("<ShowContactEmissions>").Append(((byte)ShowContactEmissions).ToString()).Append("</ShowContactEmissions>");
			authenticationDic.Append("<ShowContactEmissions_Details>").Append(((byte)ShowContactEmissions_Details).ToString()).Append("</ShowContactEmissions_Details>");
			StringBuilder stringBuilder = authenticationDic.Append("<ViewMode>");
			byte viewMode = (byte)ViewMode;
			stringBuilder.Append(viewMode.ToString()).Append("</ViewMode>");
			if (GodsEye)
			{
				authenticationDic.Append("<GodsEye>True</GodsEye>");
			}
			if (!string.IsNullOrEmpty(globalDic))
			{
				authenticationDic.Append("<IsolatedPOVObjectID>").Append(globalDic).Append("</IsolatedPOVObjectID>");
			}
			authenticationDic.Append("<RPColor>").Append(XmlConvert.ToString(_AccountDic.ToArgb())).Append("</RPColor>");
			authenticationDic.Append("<WPColor>").Append(XmlConvert.ToString(m_StateDic.ToArgb())).Append("</WPColor>");
			authenticationDic.Append("</MapProfile>");
			result = authenticationDic.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101013", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static MapProfile FromXML(XmlNode xmlNode_0)
	{
		MapProfile result = null;
		try
		{
			MapProfile mapProfile = new MapProfile();
			mapProfile.m_MethodDic = true;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "RSVisible_ASWeapon":
					{
						string innerText4 = xmlNode.InnerText;
						if (Operators.CompareString(innerText4, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWeapon = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText4, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWeapon = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ASWeapon = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "RSVisible_ASWWeapon":
					{
						string innerText8 = xmlNode.InnerText;
						if (Operators.CompareString(innerText8, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWWeapon = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText8, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWWeapon = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ASWWeapon = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "WPColor":
						mapProfile.InterruptClass("WPColor", Color.FromArgb(XmlConvert.ToInt32(xmlNode.InnerText)));
						break;
					case "Layer_BMNG":
						mapProfile.m_SystemDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "IsolatedPOVObjectID":
						mapProfile.globalDic = xmlNode.InnerText;
						break;
					case "ShowTargetingVectors":
						mapProfile._IteratorDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "Layer_StamenTerrain":
						mapProfile._BaseDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RSVisible_ASWSensor":
					{
						string innerText7 = xmlNode.InnerText;
						if (Operators.CompareString(innerText7, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWSensor = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText7, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASWSensor = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ASWSensor = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "ShowIlluminationVectors":
						mapProfile.factoryDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "RSVisible_ASSensor":
					{
						string innerText3 = xmlNode.InnerText;
						if (Operators.CompareString(innerText3, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASSensor = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText3, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ASSensor = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ASSensor = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "DayNightLighting":
						mapProfile.databaseDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Layer_LandCover":
						mapProfile.printerDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ViewMode":
						mapProfile.ViewMode = (MapViewMode)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "GodsEye":
						mapProfile._EventDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Layer_Sentinel2":
						mapProfile._ServiceDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowLatLonGrid":
						mapProfile._PageDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RPColor":
						mapProfile.InterruptClass("RPColor", Color.FromArgb(XmlConvert.ToInt32(xmlNode.InnerText)));
						break;
					case "ShowNonFriendly":
						mapProfile.ShowNonFriendly = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowDatalinks":
						mapProfile.m_InitializerDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "ShowRangeSymbols":
						mapProfile.m_AttributeDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "Layer_StamenRoads":
						mapProfile.policyDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Layer_Borders":
						mapProfile._BroadcasterDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowBaseEarth":
						mapProfile.rulesDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowContactEmissions":
						mapProfile.productDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "ColorDatablocks":
						mapProfile.ColorDatablocks = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RSVisible_AAWeapon":
					{
						string innerText6 = xmlNode.InnerText;
						if (Operators.CompareString(innerText6, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AAWeapon = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText6, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AAWeapon = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_AAWeapon = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "Layer_Relief":
						mapProfile.m_CandidateDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RSVisible_ACRange":
					{
						string innerText5 = xmlNode.InnerText;
						if (Operators.CompareString(innerText5, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ACRange = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText5, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_ACRange = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ACRange = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "Layer_Placenames":
						mapProfile.m_IdentifierDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "RSVisible_AGWeapon":
					{
						string innerText2 = xmlNode.InnerText;
						if (Operators.CompareString(innerText2, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AGWeapon = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText2, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AGWeapon = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_AGWeapon = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
					}
					case "ShowContactEmissions_Details":
						mapProfile.m_AnnotationDic = (_ShowEmissionTypes)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "MergeRangeSymbols":
						mapProfile.MergeRangeSymbols = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowDynamicNoiseSignature":
					case "ShowDinamicNoiseSignature":
						mapProfile.m_MethodDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Layer_VirtualEarth":
						mapProfile.algoDic = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "ShowDatablocks":
						mapProfile._RoleDic = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "RSVisible_AASensor":
					{
						string innerText = xmlNode.InnerText;
						if (Operators.CompareString(innerText, "True", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AASensor = _ShowElement.All;
						}
						else if (Operators.CompareString(innerText, "False", TextCompare: false) == 0)
						{
							mapProfile.RangeSymbol_AASensor = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_AASensor = (_ShowElement)Conversions.ToShort(xmlNode.InnerText);
						}
						break;
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
			result = mapProfile;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101014", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void InterruptClass(string string_0, Color color_0)
	{
		if (color_0 == default(Color) || Operators.CompareString(color_0.Name, "0", TextCompare: false) == 0)
		{
			color_0 = Color.White;
		}
		PropertyInfo property = GetType().GetProperty(string_0);
		if ((object)property != null && property.CanWrite)
		{
			property.SetValue(this, color_0, null);
		}
	}

	public static MapProfile FromXML(string string_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(string_0);
		return FromXML(xmlDocument.DocumentElement);
	}

	public static MapProfile GetDefaultProfile()
	{
		return new MapProfile();
	}

	private MapProfile()
	{
		RangeSymbol_Colors = default(_RangeSymbol_Colors);
		_IteratorDic = _ShowElement.All;
		m_InitializerDic = _ShowElement.All;
		_RoleDic = _ShowElement.All;
		ViewMode = MapViewMode.GroupView;
		RangeSymbol_Colors.AASensor = Color.White;
		RangeSymbol_AASensor = _ShowElement.All;
		RangeSymbol_Colors.AAWeapon = Color.FromArgb(255, 105, 105);
		RangeSymbol_AAWeapon = _ShowElement.All;
		RangeSymbol_Colors.ASSensor = Color.Yellow;
		RangeSymbol_ASSensor = _ShowElement.All;
		RangeSymbol_Colors.ASWeapon = Color.Red;
		RangeSymbol_ASWeapon = _ShowElement.All;
		RangeSymbol_Colors.AGWeapon = Color.Chocolate;
		RangeSymbol_AGWeapon = _ShowElement.All;
		RangeSymbol_Colors.color_0 = Color.FromArgb(123, 199, 123);
		RangeSymbol_ASWSensor = _ShowElement.All;
		RangeSymbol_Colors.color_1 = Color.Green;
		RangeSymbol_ASWWeapon = _ShowElement.All;
		RangeSymbol_Colors.ACRange = Color.DodgerBlue;
		RangeSymbol_ACRange = _ShowElement.SelectedUnit;
		_RoleDic = _ShowElement.SelectedUnit;
		m_InitializerDic = _ShowElement.DontShow;
		factoryDic = _ShowElement.All;
		_IteratorDic = _ShowElement.DontShow;
		productDic = _ShowElement.All;
		m_AnnotationDic = _ShowEmissionTypes.All;
		_ServiceDic = true;
		m_SystemDic = true;
		m_CandidateDic = false;
		_BroadcasterDic = true;
		_ParserDic = false;
		m_IdentifierDic = true;
		rulesDic = true;
		databaseDic = false;
		_PageDic = false;
		m_MethodDic = true;
		m_InterceptorDic = true;
		messageDic = true;
		ViewMode = MapViewMode.GroupView;
	}
}
