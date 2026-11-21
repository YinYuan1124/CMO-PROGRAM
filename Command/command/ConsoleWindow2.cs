using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;
using ScintillaNET;
using ScintillaNET.Demo.Utils;

namespace Command;

[DesignerGenerated]
public sealed class ConsoleWindow2 : DarkSecondaryFormBase
{
	private IContainer m_TemplateRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("menuStrip1")]
	private DarkMenuStrip m_MappingRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("toolStripSeparator3")]
	private ToolStripSeparator fieldRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("toolStripSeparator4")]
	private ToolStripSeparator regRequest;

	[AccessedThroughProperty("toolStripSeparator5")]
	[CompilerGenerated]
	private ToolStripSeparator paramRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("TextPanel")]
	private Panel m_PageRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog1")]
	private OpenFileDialog rulesRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkTextBox m_MethodRequest;

	[AccessedThroughProperty("Button_InsertScript")]
	[CompilerGenerated]
	private DarkUIButton m_ServiceRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox1")]
	private DarkUIComboBox m_SystemRequest;

	[AccessedThroughProperty("Button_Run")]
	[CompilerGenerated]
	private DarkUIButton m_CandidateRequest;

	[AccessedThroughProperty("CB_EchoInput")]
	[CompilerGenerated]
	private DarkCheckBox m_BaseRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("openToolStripMenuItem")]
	private DarkToolStripMenuItem broadcasterRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("editToolStripMenuItem")]
	private DarkToolStripMenuItem identifierRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("cutToolStripMenuItem")]
	private DarkToolStripMenuItem m_PrinterRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("copyToolStripMenuItem")]
	private DarkToolStripMenuItem m_ParserRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("pasteToolStripMenuItem")]
	private DarkToolStripMenuItem algoRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("selectLineToolStripMenuItem")]
	private DarkToolStripMenuItem databaseRequest;

	[AccessedThroughProperty("selectAllToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_InterceptorRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("clearSelectionToolStripMenuItem")]
	private DarkToolStripMenuItem m_MessageRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("indentSelectionToolStripMenuItem")]
	private DarkToolStripMenuItem m_ProductRequest;

	[AccessedThroughProperty("outdentSelectionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem annotationRequest;

	[AccessedThroughProperty("uppercaseSelectionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _IteratorRequest;

	[AccessedThroughProperty("lowercaseSelectionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_InitializerRequest;

	[AccessedThroughProperty("searchToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem roleRequest;

	[AccessedThroughProperty("findToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_FactoryRequest;

	[AccessedThroughProperty("findDialogToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_AttributeRequest;

	[AccessedThroughProperty("findAndReplaceToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_EventRequest;

	[AccessedThroughProperty("goToLineToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem globalRequest;

	[AccessedThroughProperty("wordWrapItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _AccountRequest;

	[AccessedThroughProperty("indentGuidesItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _StateRequest;

	[AccessedThroughProperty("hiddenCharactersItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem authenticationRequest;

	[AccessedThroughProperty("zoomInToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem paramsRequest;

	[AccessedThroughProperty("zoomOutToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem infoRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("zoom100ToolStripMenuItem")]
	private DarkToolStripMenuItem m_HelperRequest;

	[AccessedThroughProperty("collapseAllToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _MapperRequest;

	[AccessedThroughProperty("expandAllToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem managerRequest;

	[AccessedThroughProperty("EncloseSelectionInToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_GetterRequest;

	[AccessedThroughProperty("TSMI_EncloseInQuotes")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_ProducerRequest;

	[AccessedThroughProperty("TSMI_EncloseInParentheses")]
	[CompilerGenerated]
	private DarkToolStripMenuItem procRequest;

	[AccessedThroughProperty("TSMI_EncloseInBrackets")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_StructValue;

	[AccessedThroughProperty("ExternalLinksToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem m_MerchantValue;

	[AccessedThroughProperty("CommandLuaDocsToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _CallbackValue;

	[AccessedThroughProperty("SearchSelectedCommandInTheDocsToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem decoratorValue;

	[AccessedThroughProperty("WeaponsReleaseScriptRepositoryToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem m_ProcessValue;

	[AccessedThroughProperty("SplitContainer1")]
	[CompilerGenerated]
	private SplitContainer threadValue;

	[CompilerGenerated]
	[AccessedThroughProperty("SplitContainer2")]
	private SplitContainer ruleValue;

	[CompilerGenerated]
	[AccessedThroughProperty("GB_LuaMethods")]
	private DarkGroupBox collectionValue;

	[AccessedThroughProperty("Button_UnhookSelected")]
	[CompilerGenerated]
	private DarkUIButton m_ObjectValue;

	[AccessedThroughProperty("Label_CurrentHooks")]
	[CompilerGenerated]
	private DarkLabel parameterValue;

	[AccessedThroughProperty("TextArea")]
	[CompilerGenerated]
	private Scintilla m_ListenerValue;

	private LuaSandBox configValue;

	private bool _RegistryValue;

	private DarkMenuStrip menuStrip1
	{
		[CompilerGenerated]
		get
		{
			return m_MappingRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingRequest = value;
		}
	}

	[field: AccessedThroughProperty("toolStripSeparator1")]
	private ToolStripSeparator toolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("toolStripSeparator2")]
	private ToolStripSeparator toolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private ToolStripSeparator toolStripSeparator3
	{
		[CompilerGenerated]
		get
		{
			return fieldRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fieldRequest = value;
		}
	}

	[field: AccessedThroughProperty("toolStripSeparator7")]
	private ToolStripSeparator toolStripSeparator7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private ToolStripSeparator toolStripSeparator4
	{
		[CompilerGenerated]
		get
		{
			return regRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regRequest = value;
		}
	}

	private ToolStripSeparator toolStripSeparator5
	{
		[CompilerGenerated]
		get
		{
			return paramRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramRequest = value;
		}
	}

	private Panel TextPanel
	{
		[CompilerGenerated]
		get
		{
			return m_PageRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageRequest = value;
		}
	}

	internal OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return rulesRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesRequest = value;
		}
	}

	internal DarkTextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_MethodRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodRequest = value;
		}
	}

	internal DarkUIButton Button_InsertScript
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageToken;
			DarkUIButton serviceRequest = m_ServiceRequest;
			if (serviceRequest != null)
			{
				serviceRequest.Click -= value2;
			}
			m_ServiceRequest = value;
			serviceRequest = m_ServiceRequest;
			if (serviceRequest != null)
			{
				serviceRequest.Click += value2;
			}
		}
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return m_SystemRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemRequest = value;
		}
	}

	internal DarkUIButton Button_Run
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterToken;
			DarkUIButton candidateRequest = m_CandidateRequest;
			if (candidateRequest != null)
			{
				candidateRequest.Click -= value2;
			}
			m_CandidateRequest = value;
			candidateRequest = m_CandidateRequest;
			if (candidateRequest != null)
			{
				candidateRequest.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_EchoInput
	{
		[CompilerGenerated]
		get
		{
			return m_BaseRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BaseRequest = value;
		}
	}

	[field: AccessedThroughProperty("fileToolStripMenuItem")]
	private DarkToolStripMenuItem fileToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private DarkToolStripMenuItem openToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return broadcasterRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveToken;
			DarkToolStripMenuItem darkToolStripMenuItem = broadcasterRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			broadcasterRequest = value;
			darkToolStripMenuItem = broadcasterRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem editToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return identifierRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierRequest = value;
		}
	}

	private DarkToolStripMenuItem cutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostToken;
			DarkToolStripMenuItem printerRequest = m_PrinterRequest;
			if (printerRequest != null)
			{
				printerRequest.Click -= value2;
			}
			m_PrinterRequest = value;
			printerRequest = m_PrinterRequest;
			if (printerRequest != null)
			{
				printerRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem copyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_ParserRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunToken;
			DarkToolStripMenuItem parserRequest = m_ParserRequest;
			if (parserRequest != null)
			{
				parserRequest.Click -= value2;
			}
			m_ParserRequest = value;
			parserRequest = m_ParserRequest;
			if (parserRequest != null)
			{
				parserRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem pasteToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return algoRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartToken;
			DarkToolStripMenuItem darkToolStripMenuItem = algoRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			algoRequest = value;
			darkToolStripMenuItem = algoRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem selectLineToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return databaseRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetToken;
			DarkToolStripMenuItem darkToolStripMenuItem = databaseRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			databaseRequest = value;
			darkToolStripMenuItem = databaseRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem selectAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintToken;
			DarkToolStripMenuItem interceptorRequest = m_InterceptorRequest;
			if (interceptorRequest != null)
			{
				interceptorRequest.Click -= value2;
			}
			m_InterceptorRequest = value;
			interceptorRequest = m_InterceptorRequest;
			if (interceptorRequest != null)
			{
				interceptorRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem clearSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_MessageRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineToken;
			DarkToolStripMenuItem messageRequest = m_MessageRequest;
			if (messageRequest != null)
			{
				messageRequest.Click -= value2;
			}
			m_MessageRequest = value;
			messageRequest = m_MessageRequest;
			if (messageRequest != null)
			{
				messageRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem indentSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_ProductRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishToken;
			DarkToolStripMenuItem productRequest = m_ProductRequest;
			if (productRequest != null)
			{
				productRequest.Click -= value2;
			}
			m_ProductRequest = value;
			productRequest = m_ProductRequest;
			if (productRequest != null)
			{
				productRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem outdentSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return annotationRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeToken;
			DarkToolStripMenuItem darkToolStripMenuItem = annotationRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			annotationRequest = value;
			darkToolStripMenuItem = annotationRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem uppercaseSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _IteratorRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryToken;
			DarkToolStripMenuItem iteratorRequest = _IteratorRequest;
			if (iteratorRequest != null)
			{
				iteratorRequest.Click -= value2;
			}
			_IteratorRequest = value;
			iteratorRequest = _IteratorRequest;
			if (iteratorRequest != null)
			{
				iteratorRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem lowercaseSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetToken;
			DarkToolStripMenuItem initializerRequest = m_InitializerRequest;
			if (initializerRequest != null)
			{
				initializerRequest.Click -= value2;
			}
			m_InitializerRequest = value;
			initializerRequest = m_InitializerRequest;
			if (initializerRequest != null)
			{
				initializerRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem searchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return roleRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleRequest = value;
		}
	}

	private DarkToolStripMenuItem findToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FactoryRequest = value;
		}
	}

	private DarkToolStripMenuItem findDialogToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeRequest = value;
		}
	}

	private DarkToolStripMenuItem findAndReplaceToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_EventRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventRequest = value;
		}
	}

	private DarkToolStripMenuItem goToLineToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return globalRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			globalRequest = value;
		}
	}

	[field: AccessedThroughProperty("viewToolStripMenuItem")]
	private DarkToolStripMenuItem viewToolStripMenuItem
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private DarkToolStripMenuItem wordWrapItem
	{
		[CompilerGenerated]
		get
		{
			return _AccountRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapToken;
			DarkToolStripMenuItem accountRequest = _AccountRequest;
			if (accountRequest != null)
			{
				accountRequest.Click -= value2;
			}
			_AccountRequest = value;
			accountRequest = _AccountRequest;
			if (accountRequest != null)
			{
				accountRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem indentGuidesItem
	{
		[CompilerGenerated]
		get
		{
			return _StateRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortToken;
			DarkToolStripMenuItem stateRequest = _StateRequest;
			if (stateRequest != null)
			{
				stateRequest.Click -= value2;
			}
			_StateRequest = value;
			stateRequest = _StateRequest;
			if (stateRequest != null)
			{
				stateRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem hiddenCharactersItem
	{
		[CompilerGenerated]
		get
		{
			return authenticationRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcToken;
			DarkToolStripMenuItem darkToolStripMenuItem = authenticationRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			authenticationRequest = value;
			darkToolStripMenuItem = authenticationRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem zoomInToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return paramsRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateToken;
			DarkToolStripMenuItem darkToolStripMenuItem = paramsRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			paramsRequest = value;
			darkToolStripMenuItem = paramsRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem zoomOutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return infoRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushToken;
			DarkToolStripMenuItem darkToolStripMenuItem = infoRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			infoRequest = value;
			darkToolStripMenuItem = infoRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem zoom100ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_HelperRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotToken;
			DarkToolStripMenuItem helperRequest = m_HelperRequest;
			if (helperRequest != null)
			{
				helperRequest.Click -= value2;
			}
			m_HelperRequest = value;
			helperRequest = m_HelperRequest;
			if (helperRequest != null)
			{
				helperRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem collapseAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _MapperRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectToken;
			DarkToolStripMenuItem mapperRequest = _MapperRequest;
			if (mapperRequest != null)
			{
				mapperRequest.Click -= value2;
			}
			_MapperRequest = value;
			mapperRequest = _MapperRequest;
			if (mapperRequest != null)
			{
				mapperRequest.Click += value2;
			}
		}
	}

	private DarkToolStripMenuItem expandAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return managerRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderToken;
			DarkToolStripMenuItem darkToolStripMenuItem = managerRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			managerRequest = value;
			darkToolStripMenuItem = managerRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem EncloseSelectionInToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_GetterRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GetterRequest = value;
		}
	}

	internal DarkToolStripMenuItem TSMI_EncloseInQuotes
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertToken;
			DarkToolStripMenuItem producerRequest = m_ProducerRequest;
			if (producerRequest != null)
			{
				producerRequest.Click -= value2;
			}
			m_ProducerRequest = value;
			producerRequest = m_ProducerRequest;
			if (producerRequest != null)
			{
				producerRequest.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem TSMI_EncloseInParentheses
	{
		[CompilerGenerated]
		get
		{
			return procRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeIndexer;
			DarkToolStripMenuItem darkToolStripMenuItem = procRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			procRequest = value;
			darkToolStripMenuItem = procRequest;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem TSMI_EncloseInBrackets
	{
		[CompilerGenerated]
		get
		{
			return m_StructValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneIndexer;
			DarkToolStripMenuItem structValue = m_StructValue;
			if (structValue != null)
			{
				structValue.Click -= value2;
			}
			m_StructValue = value;
			structValue = m_StructValue;
			if (structValue != null)
			{
				structValue.Click += value2;
			}
		}
	}

	internal ToolStripMenuItem ExternalLinksToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MerchantValue = value;
		}
	}

	internal ToolStripMenuItem CommandLuaDocsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _CallbackValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveIndexer;
			ToolStripMenuItem callbackValue = _CallbackValue;
			if (callbackValue != null)
			{
				callbackValue.Click -= value2;
			}
			_CallbackValue = value;
			callbackValue = _CallbackValue;
			if (callbackValue != null)
			{
				callbackValue.Click += value2;
			}
		}
	}

	internal ToolStripMenuItem SearchSelectedCommandInTheDocsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return decoratorValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyIndexer;
			ToolStripMenuItem toolStripMenuItem = decoratorValue;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			decoratorValue = value;
			toolStripMenuItem = decoratorValue;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal ToolStripMenuItem WeaponsReleaseScriptRepositoryToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeIndexer;
			ToolStripMenuItem processValue = m_ProcessValue;
			if (processValue != null)
			{
				processValue.Click -= value2;
			}
			m_ProcessValue = value;
			processValue = m_ProcessValue;
			if (processValue != null)
			{
				processValue.Click += value2;
			}
		}
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return threadValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			threadValue = value;
		}
	}

	internal SplitContainer SplitContainer2
	{
		[CompilerGenerated]
		get
		{
			return ruleValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ruleValue = value;
		}
	}

	internal DarkGroupBox GB_LuaMethods
	{
		[CompilerGenerated]
		get
		{
			return collectionValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionValue = value;
		}
	}

	[field: AccessedThroughProperty("GB_LuaHooks")]
	internal DarkGroupBox GB_LuaHooks
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_UnhookSelected
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectValue = value;
		}
	}

	internal DarkLabel Label_CurrentHooks
	{
		[CompilerGenerated]
		get
		{
			return parameterValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			parameterValue = value;
		}
	}

	[field: AccessedThroughProperty("Button_InsertHook")]
	internal DarkUIButton Button_InsertHook
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Combo_LuaHooksSelection")]
	internal DarkUIComboBox Combo_LuaHooksSelection
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private Scintilla TestResolver()
	{
		return m_ListenerValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void StopResolver(Scintilla scintilla_0)
	{
		DragEventHandler value = InvokeToken;
		DragEventHandler value2 = SetupToken;
		Scintilla listenerValue = m_ListenerValue;
		if (listenerValue != null)
		{
			((Control)listenerValue).DragEnter -= value;
			((Control)listenerValue).DragDrop -= value2;
		}
		m_ListenerValue = scintilla_0;
		listenerValue = m_ListenerValue;
		if (listenerValue != null)
		{
			((Control)listenerValue).DragEnter += value;
			((Control)listenerValue).DragDrop += value2;
		}
	}

	public ConsoleWindow2()
	{
		base.Load += CountToken;
		base.Closing += ConnectIndexer;
		_RegistryValue = false;
		RevertConfiguration();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_TemplateRequest != null)
			{
				m_TemplateRequest.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RevertConfiguration()
	{
		menuStrip1 = new DarkMenuStrip();
		fileToolStripMenuItem = new DarkToolStripMenuItem();
		openToolStripMenuItem = new DarkToolStripMenuItem();
		editToolStripMenuItem = new DarkToolStripMenuItem();
		cutToolStripMenuItem = new DarkToolStripMenuItem();
		copyToolStripMenuItem = new DarkToolStripMenuItem();
		pasteToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator1 = new ToolStripSeparator();
		selectLineToolStripMenuItem = new DarkToolStripMenuItem();
		selectAllToolStripMenuItem = new DarkToolStripMenuItem();
		clearSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator2 = new ToolStripSeparator();
		indentSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		outdentSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator3 = new ToolStripSeparator();
		uppercaseSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		lowercaseSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		EncloseSelectionInToolStripMenuItem = new DarkToolStripMenuItem();
		TSMI_EncloseInQuotes = new DarkToolStripMenuItem();
		TSMI_EncloseInParentheses = new DarkToolStripMenuItem();
		TSMI_EncloseInBrackets = new DarkToolStripMenuItem();
		searchToolStripMenuItem = new DarkToolStripMenuItem();
		findToolStripMenuItem = new DarkToolStripMenuItem();
		findDialogToolStripMenuItem = new DarkToolStripMenuItem();
		findAndReplaceToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator7 = new ToolStripSeparator();
		goToLineToolStripMenuItem = new DarkToolStripMenuItem();
		viewToolStripMenuItem = new DarkToolStripMenuItem();
		wordWrapItem = new DarkToolStripMenuItem();
		indentGuidesItem = new DarkToolStripMenuItem();
		hiddenCharactersItem = new DarkToolStripMenuItem();
		toolStripSeparator4 = new ToolStripSeparator();
		zoomInToolStripMenuItem = new DarkToolStripMenuItem();
		zoomOutToolStripMenuItem = new DarkToolStripMenuItem();
		zoom100ToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator5 = new ToolStripSeparator();
		collapseAllToolStripMenuItem = new DarkToolStripMenuItem();
		expandAllToolStripMenuItem = new DarkToolStripMenuItem();
		ExternalLinksToolStripMenuItem = new ToolStripMenuItem();
		CommandLuaDocsToolStripMenuItem = new ToolStripMenuItem();
		SearchSelectedCommandInTheDocsToolStripMenuItem = new ToolStripMenuItem();
		WeaponsReleaseScriptRepositoryToolStripMenuItem = new ToolStripMenuItem();
		TextPanel = new Panel();
		OpenFileDialog1 = new OpenFileDialog();
		TextBox1 = new DarkTextBox();
		Button_InsertScript = new DarkUIButton();
		ComboBox1 = new DarkUIComboBox();
		Button_Run = new DarkUIButton();
		CB_EchoInput = new DarkCheckBox();
		SplitContainer1 = new SplitContainer();
		SplitContainer2 = new SplitContainer();
		GB_LuaMethods = new DarkGroupBox();
		GB_LuaHooks = new DarkGroupBox();
		Button_UnhookSelected = new DarkUIButton();
		Label_CurrentHooks = new DarkLabel();
		Button_InsertHook = new DarkUIButton();
		Combo_LuaHooksSelection = new DarkUIComboBox();
		menuStrip1.SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		((ISupportInitialize)SplitContainer2).BeginInit();
		SplitContainer2.Panel1.SuspendLayout();
		SplitContainer2.Panel2.SuspendLayout();
		SplitContainer2.SuspendLayout();
		GB_LuaMethods.SuspendLayout();
		GB_LuaHooks.SuspendLayout();
		SuspendLayout();
		menuStrip1.BackColor = Color.FromArgb(60, 63, 65);
		menuStrip1.Font = new Font("Segoe UI", 10.2f, FontStyle.Regular, GraphicsUnit.Point, 0);
		menuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		menuStrip1.Items.AddRange(new ToolStripItem[5] { fileToolStripMenuItem, editToolStripMenuItem, searchToolStripMenuItem, viewToolStripMenuItem, ExternalLinksToolStripMenuItem });
		menuStrip1.Location = new Point(0, 0);
		menuStrip1.Name = "menuStrip1";
		menuStrip1.Padding = new Padding(3, 2, 0, 2);
		menuStrip1.Size = new Size(831, 27);
		menuStrip1.TabIndex = 3;
		menuStrip1.Text = "menuStrip1";
		fileToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1] { openToolStripMenuItem });
		fileToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		fileToolStripMenuItem.Size = new Size(41, 23);
		fileToolStripMenuItem.Text = "文件";
		openToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		openToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		openToolStripMenuItem.Name = "openToolStripMenuItem";
		openToolStripMenuItem.Size = new Size(121, 24);
		openToolStripMenuItem.Text = "打开...";
		editToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[14]
		{
			cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator1, selectLineToolStripMenuItem, selectAllToolStripMenuItem, clearSelectionToolStripMenuItem, toolStripSeparator2, indentSelectionToolStripMenuItem, outdentSelectionToolStripMenuItem,
			toolStripSeparator3, uppercaseSelectionToolStripMenuItem, lowercaseSelectionToolStripMenuItem, EncloseSelectionInToolStripMenuItem
		});
		editToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		editToolStripMenuItem.Name = "editToolStripMenuItem";
		editToolStripMenuItem.Size = new Size(44, 23);
		editToolStripMenuItem.Text = "编辑";
		cutToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		cutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		cutToolStripMenuItem.Name = "cutToolStripMenuItem";
		cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
		cutToolStripMenuItem.Size = new Size(204, 24);
		cutToolStripMenuItem.Text = "剪切";
		copyToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		copyToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
		copyToolStripMenuItem.Size = new Size(204, 24);
		copyToolStripMenuItem.Text = "复制";
		pasteToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		pasteToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
		pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
		pasteToolStripMenuItem.Size = new Size(204, 24);
		pasteToolStripMenuItem.Text = "粘贴";
		toolStripSeparator1.Name = "toolStripSeparator1";
		toolStripSeparator1.Size = new Size(201, 6);
		selectLineToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		selectLineToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		selectLineToolStripMenuItem.Name = "selectLineToolStripMenuItem";
		selectLineToolStripMenuItem.Size = new Size(204, 24);
		selectLineToolStripMenuItem.Text = "选择线";
		selectAllToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		selectAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
		selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
		selectAllToolStripMenuItem.Size = new Size(204, 24);
		selectAllToolStripMenuItem.Text = "全选";
		clearSelectionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		clearSelectionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
		clearSelectionToolStripMenuItem.Size = new Size(204, 24);
		clearSelectionToolStripMenuItem.Text = "清除所选";
		toolStripSeparator2.Name = "toolStripSeparator2";
		toolStripSeparator2.Size = new Size(201, 6);
		indentSelectionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		indentSelectionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		indentSelectionToolStripMenuItem.Name = "indentSelectionToolStripMenuItem";
		indentSelectionToolStripMenuItem.ShortcutKeyDisplayString = "Tab";
		indentSelectionToolStripMenuItem.Size = new Size(204, 24);
		indentSelectionToolStripMenuItem.Text = "缩进";
		outdentSelectionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		outdentSelectionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		outdentSelectionToolStripMenuItem.Name = "outdentSelectionToolStripMenuItem";
		outdentSelectionToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Tab";
		outdentSelectionToolStripMenuItem.Size = new Size(204, 24);
		outdentSelectionToolStripMenuItem.Text = "减少缩进";
		toolStripSeparator3.Name = "toolStripSeparator3";
		toolStripSeparator3.Size = new Size(201, 6);
		uppercaseSelectionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		uppercaseSelectionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		uppercaseSelectionToolStripMenuItem.Name = "uppercaseSelectionToolStripMenuItem";
		uppercaseSelectionToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+U";
		uppercaseSelectionToolStripMenuItem.Size = new Size(204, 24);
		uppercaseSelectionToolStripMenuItem.Text = "大写";
		lowercaseSelectionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		lowercaseSelectionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		lowercaseSelectionToolStripMenuItem.Name = "lowercaseSelectionToolStripMenuItem";
		lowercaseSelectionToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+L";
		lowercaseSelectionToolStripMenuItem.Size = new Size(204, 24);
		lowercaseSelectionToolStripMenuItem.Text = "小写";
		EncloseSelectionInToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		EncloseSelectionInToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3] { TSMI_EncloseInQuotes, TSMI_EncloseInParentheses, TSMI_EncloseInBrackets });
		EncloseSelectionInToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		EncloseSelectionInToolStripMenuItem.Name = "EncloseSelectionInToolStripMenuItem";
		EncloseSelectionInToolStripMenuItem.Size = new Size(204, 24);
		EncloseSelectionInToolStripMenuItem.Text = "附上选择...";
		TSMI_EncloseInQuotes.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_EncloseInQuotes.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_EncloseInQuotes.Name = "TSMI_EncloseInQuotes";
		TSMI_EncloseInQuotes.Size = new Size(195, 24);
		TSMI_EncloseInQuotes.Text = "引号 - “abc”";
		TSMI_EncloseInParentheses.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_EncloseInParentheses.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_EncloseInParentheses.Name = "TSMI_EncloseInParentheses";
		TSMI_EncloseInParentheses.Size = new Size(195, 24);
		TSMI_EncloseInParentheses.Text = "小括号 - （abc）";
		TSMI_EncloseInBrackets.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_EncloseInBrackets.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_EncloseInBrackets.Name = "TSMI_EncloseInBrackets";
		TSMI_EncloseInBrackets.Size = new Size(195, 24);
		TSMI_EncloseInBrackets.Text = "大括号 -  {abc}";
		searchToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		searchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5] { findToolStripMenuItem, findDialogToolStripMenuItem, findAndReplaceToolStripMenuItem, toolStripSeparator7, goToLineToolStripMenuItem });
		searchToolStripMenuItem.Enabled = false;
		searchToolStripMenuItem.ForeColor = Color.FromArgb(153, 153, 153);
		searchToolStripMenuItem.Name = "searchToolStripMenuItem";
		searchToolStripMenuItem.Size = new Size(61, 23);
		searchToolStripMenuItem.Text = "搜索";
		findToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		findToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		findToolStripMenuItem.Name = "findToolStripMenuItem";
		findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
		findToolStripMenuItem.Size = new Size(241, 24);
		findToolStripMenuItem.Text = "快速查找...";
		findDialogToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		findDialogToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		findDialogToolStripMenuItem.Name = "findDialogToolStripMenuItem";
		findDialogToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+F";
		findDialogToolStripMenuItem.Size = new Size(241, 24);
		findDialogToolStripMenuItem.Text = "查找...";
		findAndReplaceToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		findAndReplaceToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		findAndReplaceToolStripMenuItem.Name = "findAndReplaceToolStripMenuItem";
		findAndReplaceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+H";
		findAndReplaceToolStripMenuItem.Size = new Size(241, 24);
		findAndReplaceToolStripMenuItem.Text = "查找和替换...";
		toolStripSeparator7.Name = "toolStripSeparator7";
		toolStripSeparator7.Size = new Size(238, 6);
		goToLineToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		goToLineToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		goToLineToolStripMenuItem.Name = "goToLineToolStripMenuItem";
		goToLineToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
		goToLineToolStripMenuItem.Size = new Size(241, 24);
		goToLineToolStripMenuItem.Text = "转到行...";
		viewToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[10] { wordWrapItem, indentGuidesItem, hiddenCharactersItem, toolStripSeparator4, zoomInToolStripMenuItem, zoomOutToolStripMenuItem, zoom100ToolStripMenuItem, toolStripSeparator5, collapseAllToolStripMenuItem, expandAllToolStripMenuItem });
		viewToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		viewToolStripMenuItem.Name = "viewToolStripMenuItem";
		viewToolStripMenuItem.Size = new Size(50, 23);
		viewToolStripMenuItem.Text = "查看";
		wordWrapItem.BackColor = Color.FromArgb(60, 63, 65);
		wordWrapItem.ForeColor = Color.FromArgb(220, 220, 220);
		wordWrapItem.Name = "wordWrapItem";
		wordWrapItem.Size = new Size(221, 24);
		wordWrapItem.Text = "自动换行";
		indentGuidesItem.BackColor = Color.FromArgb(60, 63, 65);
		indentGuidesItem.Checked = true;
		indentGuidesItem.CheckState = CheckState.Checked;
		indentGuidesItem.ForeColor = Color.FromArgb(220, 220, 220);
		indentGuidesItem.Name = "indentGuidesItem";
		indentGuidesItem.Size = new Size(221, 24);
		indentGuidesItem.Text = "显示缩进指南";
		hiddenCharactersItem.BackColor = Color.FromArgb(60, 63, 65);
		hiddenCharactersItem.ForeColor = Color.FromArgb(220, 220, 220);
		hiddenCharactersItem.Name = "hiddenCharactersItem";
		hiddenCharactersItem.Size = new Size(221, 24);
		hiddenCharactersItem.Text = "显示空白";
		toolStripSeparator4.BackColor = Color.FromArgb(60, 63, 65);
		toolStripSeparator4.ForeColor = Color.FromArgb(220, 220, 220);
		toolStripSeparator4.Margin = new Padding(0, 0, 0, 1);
		toolStripSeparator4.Name = "toolStripSeparator4";
		toolStripSeparator4.Size = new Size(218, 6);
		zoomInToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		zoomInToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
		zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Plus";
		zoomInToolStripMenuItem.Size = new Size(221, 24);
		zoomInToolStripMenuItem.Text = "放大";
		zoomOutToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		zoomOutToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
		zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Minus";
		zoomOutToolStripMenuItem.Size = new Size(221, 24);
		zoomOutToolStripMenuItem.Text = "缩小";
		zoom100ToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		zoom100ToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
		zoom100ToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+0";
		zoom100ToolStripMenuItem.Size = new Size(221, 24);
		zoom100ToolStripMenuItem.Text = "放大100％";
		toolStripSeparator5.BackColor = Color.FromArgb(60, 63, 65);
		toolStripSeparator5.ForeColor = Color.FromArgb(220, 220, 220);
		toolStripSeparator5.Margin = new Padding(0, 0, 0, 1);
		toolStripSeparator5.Name = "toolStripSeparator5";
		toolStripSeparator5.Size = new Size(218, 6);
		collapseAllToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		collapseAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
		collapseAllToolStripMenuItem.Size = new Size(221, 24);
		collapseAllToolStripMenuItem.Text = "全部收缩";
		expandAllToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		expandAllToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
		expandAllToolStripMenuItem.Size = new Size(221, 24);
		expandAllToolStripMenuItem.Text = "展开全部";
		ExternalLinksToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		ExternalLinksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3] { CommandLuaDocsToolStripMenuItem, SearchSelectedCommandInTheDocsToolStripMenuItem, WeaponsReleaseScriptRepositoryToolStripMenuItem });
		ExternalLinksToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		ExternalLinksToolStripMenuItem.Name = "ExternalLinksToolStripMenuItem";
		ExternalLinksToolStripMenuItem.Size = new Size(104, 23);
		ExternalLinksToolStripMenuItem.Text = "External Links";
		CommandLuaDocsToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		CommandLuaDocsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		CommandLuaDocsToolStripMenuItem.Name = "CommandLuaDocsToolStripMenuItem";
		CommandLuaDocsToolStripMenuItem.Size = new Size(359, 24);
		CommandLuaDocsToolStripMenuItem.Text = "Command Lua Docs";
		SearchSelectedCommandInTheDocsToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		SearchSelectedCommandInTheDocsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		SearchSelectedCommandInTheDocsToolStripMenuItem.Name = "SearchSelectedCommandInTheDocsToolStripMenuItem";
		SearchSelectedCommandInTheDocsToolStripMenuItem.Size = new Size(359, 24);
		SearchSelectedCommandInTheDocsToolStripMenuItem.Text = "Search Selected Instruction in the Online Docs";
		WeaponsReleaseScriptRepositoryToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		WeaponsReleaseScriptRepositoryToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		WeaponsReleaseScriptRepositoryToolStripMenuItem.Name = "WeaponsReleaseScriptRepositoryToolStripMenuItem";
		WeaponsReleaseScriptRepositoryToolStripMenuItem.Size = new Size(359, 24);
		WeaponsReleaseScriptRepositoryToolStripMenuItem.Text = "Weapons Release Script Repository";
		TextPanel.BackColor = Color.FromArgb(60, 63, 65);
		TextPanel.BorderStyle = BorderStyle.Fixed3D;
		TextPanel.Dock = DockStyle.Fill;
		TextPanel.Location = new Point(0, 0);
		TextPanel.Margin = new Padding(3, 4, 3, 4);
		TextPanel.Name = "TextPanel";
		TextPanel.Size = new Size(831, 289);
		TextPanel.TabIndex = 11;
		OpenFileDialog1.FileName = "OpenFileDialog1";
		TextBox1.BackColor = Color.FromArgb(69, 73, 74);
		TextBox1.BorderStyle = BorderStyle.FixedSingle;
		TextBox1.Dock = DockStyle.Fill;
		TextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox1.Location = new Point(0, 0);
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.Size = new Size(821, 170);
		TextBox1.TabIndex = 12;
		Button_InsertScript.BackColor = Color.Transparent;
		Button_InsertScript.DialogResult = DialogResult.None;
		Button_InsertScript.Font = new Font("Segoe UI", 10f);
		Button_InsertScript.ForeColor = SystemColors.Control;
		Button_InsertScript.Location = new Point(7, 45);
		Button_InsertScript.Name = "Button_InsertScript";
		Button_InsertScript.RoundRadius = 0;
		Button_InsertScript.Size = new Size(277, 23);
		Button_InsertScript.TabIndex = 14;
		Button_InsertScript.Text = "插入";
		ComboBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Location = new Point(7, 17);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(277, 20);
		ComboBox1.TabIndex = 13;
		Button_Run.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Run.BackColor = Color.Transparent;
		Button_Run.DialogResult = DialogResult.None;
		Button_Run.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_Run.ForeColor = Color.LightGreen;
		Button_Run.Location = new Point(626, 7);
		Button_Run.Name = "Button_Run";
		Button_Run.RoundRadius = 0;
		Button_Run.Size = new Size(190, 47);
		Button_Run.TabIndex = 15;
		Button_Run.Text = "运行";
		CB_EchoInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		CB_EchoInput.AutoSize = true;
		CB_EchoInput.Checked = true;
		CB_EchoInput.CheckState = CheckState.Checked;
		CB_EchoInput.Location = new Point(626, 60);
		CB_EchoInput.Name = "CB_EchoInput";
		CB_EchoInput.Size = new Size(190, 19);
		CB_EchoInput.TabIndex = 16;
		CB_EchoInput.Text = "在结果文本中显示输入脚本";
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(SplitContainer2);
		SplitContainer1.Panel2.Controls.Add(TextPanel);
		SplitContainer1.Size = new Size(831, 583);
		SplitContainer1.SplitterDistance = 290;
		SplitContainer1.TabIndex = 14;
		SplitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SplitContainer2.Location = new Point(3, 29);
		SplitContainer2.Margin = new Padding(3, 20, 3, 3);
		SplitContainer2.Name = "SplitContainer2";
		SplitContainer2.Orientation = Orientation.Horizontal;
		SplitContainer2.Panel1.Controls.Add(TextBox1);
		SplitContainer2.Panel2.Controls.Add(GB_LuaMethods);
		SplitContainer2.Panel2.Controls.Add(GB_LuaHooks);
		SplitContainer2.Panel2.Controls.Add(Button_Run);
		SplitContainer2.Panel2.Controls.Add(CB_EchoInput);
		SplitContainer2.Panel2MinSize = 80;
		SplitContainer2.Size = new Size(821, 261);
		SplitContainer2.SplitterDistance = 170;
		SplitContainer2.TabIndex = 0;
		GB_LuaMethods.Controls.Add(Button_InsertScript);
		GB_LuaMethods.Controls.Add(ComboBox1);
		GB_LuaMethods.ForeColor = Color.FromArgb(220, 220, 220);
		GB_LuaMethods.Location = new Point(3, 3);
		GB_LuaMethods.Name = "GB_LuaMethods";
		GB_LuaMethods.Size = new Size(295, 76);
		GB_LuaMethods.TabIndex = 19;
		GB_LuaMethods.TabStop = false;
		GB_LuaMethods.Text = "Methods";
		GB_LuaHooks.Controls.Add(Button_UnhookSelected);
		GB_LuaHooks.Controls.Add(Label_CurrentHooks);
		GB_LuaHooks.Controls.Add(Button_InsertHook);
		GB_LuaHooks.Controls.Add(Combo_LuaHooksSelection);
		GB_LuaHooks.ForeColor = Color.FromArgb(220, 220, 220);
		GB_LuaHooks.Location = new Point(304, 3);
		GB_LuaHooks.Name = "GB_LuaHooks";
		GB_LuaHooks.Size = new Size(316, 76);
		GB_LuaHooks.TabIndex = 18;
		GB_LuaHooks.TabStop = false;
		GB_LuaHooks.Text = "Hooks";
		Button_UnhookSelected.BackColor = Color.Transparent;
		Button_UnhookSelected.DialogResult = DialogResult.None;
		Button_UnhookSelected.Font = new Font("Segoe UI", 10f);
		Button_UnhookSelected.ForeColor = SystemColors.Control;
		Button_UnhookSelected.Location = new Point(171, 45);
		Button_UnhookSelected.Name = "Button_UnhookSelected";
		Button_UnhookSelected.RoundRadius = 0;
		Button_UnhookSelected.Size = new Size(139, 23);
		Button_UnhookSelected.TabIndex = 19;
		Button_UnhookSelected.Text = "Unhook selected";
		Label_CurrentHooks.AutoSize = true;
		Label_CurrentHooks.ForeColor = Color.FromArgb(220, 220, 220);
		Label_CurrentHooks.Location = new Point(228, 2);
		Label_CurrentHooks.Name = "Label_CurrentHooks";
		Label_CurrentHooks.Size = new Size(82, 15);
		Label_CurrentHooks.TabIndex = 18;
		Label_CurrentHooks.Text = "x active hooks";
		Button_InsertHook.BackColor = Color.Transparent;
		Button_InsertHook.DialogResult = DialogResult.None;
		Button_InsertHook.Font = new Font("Segoe UI", 10f);
		Button_InsertHook.ForeColor = SystemColors.Control;
		Button_InsertHook.Location = new Point(6, 45);
		Button_InsertHook.Name = "Button_InsertHook";
		Button_InsertHook.RoundRadius = 0;
		Button_InsertHook.Size = new Size(159, 23);
		Button_InsertHook.TabIndex = 15;
		Button_InsertHook.Text = "插入";
		Combo_LuaHooksSelection.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Combo_LuaHooksSelection.BackColor = Color.Transparent;
		Combo_LuaHooksSelection.DisplayMember = "Name";
		Combo_LuaHooksSelection.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_LuaHooksSelection.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_LuaHooksSelection.Font = new Font("Lucida Console", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_LuaHooksSelection.FormattingEnabled = true;
		Combo_LuaHooksSelection.Location = new Point(6, 19);
		Combo_LuaHooksSelection.Name = "Combo_LuaHooksSelection";
		Combo_LuaHooksSelection.Size = new Size(304, 21);
		Combo_LuaHooksSelection.TabIndex = 17;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(831, 583);
		base.Controls.Add(menuStrip1);
		base.Controls.Add(SplitContainer1);
		MinimumSize = new Size(400, 400);
		base.Name = "ConsoleWindow2";
		Text = "Lua Console v2";
		menuStrip1.ResumeLayout(performLayout: false);
		menuStrip1.PerformLayout();
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		SplitContainer2.Panel1.ResumeLayout(performLayout: false);
		SplitContainer2.Panel1.PerformLayout();
		SplitContainer2.Panel2.ResumeLayout(performLayout: false);
		SplitContainer2.Panel2.PerformLayout();
		((ISupportInitialize)SplitContainer2).EndInit();
		SplitContainer2.ResumeLayout(performLayout: false);
		GB_LuaMethods.ResumeLayout(performLayout: false);
		GB_LuaHooks.ResumeLayout(performLayout: false);
		GB_LuaHooks.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CountToken(object sender, EventArgs e)
	{
		StopResolver(new Scintilla());
		TextPanel.Controls.Add(TestResolver());
		((Control)TestResolver()).Dock = DockStyle.Fill;
		TestResolver().WrapMode = WrapMode.None;
		TestResolver().IndentationGuides = IndentView.LookBoth;
		ConnectToken();
		DeleteToken();
		DestroyToken();
		ComputeToken();
		PatchToken();
		InitDragDropFile();
		MoveToken();
		GB_LuaHooks.Visible = false;
		configValue = Client.CurrentScenario.Scenario_LuaSandbox;
		TextBox1.AppendText("Lua版本：" + configValue.RunScript("_VERSION", bool_0: true)[0].ToString());
		ComboBox.ObjectCollection items = ComboBox1.Items;
		object[] array = LuaSandBox.LuaMethods.OrderBy((string s) => s).ToArray();
		object[] items2 = array;
		items.AddRange(items2);
		ComboBox1.SelectedIndex = 0;
		configValue.LuaPrint += CloneToken;
		Client.ScenarioChanging += CustomizeToken;
	}

	private void CustomizeToken()
	{
		Close();
	}

	private void CloneToken(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(object_0)));
		if (configValue.RunInteractive)
		{
			try
			{
				TextBox1.AppendText("\r\n" + stringBuilder.ToString());
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ConnectToken()
	{
		TestResolver().SetSelectionBackColor(use: true, Color.FromArgb(1133980));
	}

	private void MoveToken()
	{
		HotKeyManager.AddHotKey(this, CallToken, Keys.F, bool_0: true);
		HotKeyManager.AddHotKey(this, NewToken, Keys.F, bool_0: true, bool_1: false, bool_2: true);
		HotKeyManager.AddHotKey(this, PushToken, Keys.R, bool_0: true);
		HotKeyManager.AddHotKey(this, PushToken, Keys.H, bool_0: true);
		HotKeyManager.AddHotKey(this, VisitToken, Keys.U, bool_0: true);
		HotKeyManager.AddHotKey(this, ReflectToken, Keys.L, bool_0: true);
		HotKeyManager.AddHotKey(this, CancelToken, Keys.Oemplus, bool_0: true);
		HotKeyManager.AddHotKey(this, VerifyToken, Keys.OemMinus, bool_0: true);
		HotKeyManager.AddHotKey(this, ListToken, Keys.D0, bool_0: true);
		HotKeyManager.AddHotKey(this, LogoutToken, Keys.Escape);
		TestResolver().ClearCmdKey(Keys.F | Keys.Control);
		TestResolver().ClearCmdKey(Keys.R | Keys.Control);
		TestResolver().ClearCmdKey(Keys.H | Keys.Control);
		TestResolver().ClearCmdKey(Keys.L | Keys.Control);
		TestResolver().ClearCmdKey(Keys.U | Keys.Control);
	}

	private void DeleteToken()
	{
		string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text2 = "0123456789";
		string text3 = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
		TestResolver().StyleResetDefault();
		TestResolver().Styles[32].Font = "Consolas";
		TestResolver().Styles[32].Size = 10;
		TestResolver().StyleClearAll();
		TestResolver().Styles[0].ForeColor = Color.Silver;
		TestResolver().Styles[1].ForeColor = Color.LightGreen;
		TestResolver().Styles[2].ForeColor = Color.LightGreen;
		TestResolver().Styles[4].ForeColor = Color.Olive;
		TestResolver().Styles[5].ForeColor = Color.Blue;
		TestResolver().Styles[13].ForeColor = Color.BlueViolet;
		TestResolver().Styles[14].ForeColor = Color.DarkSlateBlue;
		TestResolver().Styles[15].ForeColor = Color.DarkSlateBlue;
		TestResolver().Styles[6].ForeColor = Color.Red;
		TestResolver().Styles[7].ForeColor = Color.Red;
		TestResolver().Styles[8].ForeColor = Color.Red;
		TestResolver().Styles[12].BackColor = Color.Pink;
		TestResolver().Styles[10].ForeColor = Color.Purple;
		TestResolver().Styles[9].ForeColor = Color.Maroon;
		TestResolver().Lexer = Lexer.Lua;
		TestResolver().WordChars = text + text2 + text3;
		TestResolver().SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
		TestResolver().SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
		TestResolver().SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
		TestResolver().SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");
		TestResolver().SetProperty("fold", "1");
		TestResolver().SetProperty("fold.compact", "1");
		TestResolver().Margins[2].Type = MarginType.Symbol;
		TestResolver().Margins[2].Mask = 4261412864u;
		TestResolver().Margins[2].Sensitive = true;
		TestResolver().Margins[2].Width = 20;
		int num = 25;
		do
		{
			TestResolver().Markers[num].SetForeColor(SystemColors.ControlLightLight);
			TestResolver().Markers[num].SetBackColor(SystemColors.ControlDark);
			num++;
		}
		while (num <= 31);
		TestResolver().Markers[30].Symbol = MarkerSymbol.BoxPlus;
		TestResolver().Markers[31].Symbol = MarkerSymbol.BoxMinus;
		TestResolver().Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
		TestResolver().Markers[27].Symbol = MarkerSymbol.TCorner;
		TestResolver().Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
		TestResolver().Markers[29].Symbol = MarkerSymbol.VLine;
		TestResolver().Markers[28].Symbol = MarkerSymbol.LCorner;
		TestResolver().AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
	}

	private void AddToken(object sender, EventArgs e)
	{
	}

	private void DestroyToken()
	{
		TestResolver().Styles[33].BackColor = Color.FromArgb(2760988);
		TestResolver().Styles[33].ForeColor = Color.FromArgb(12040119);
		TestResolver().Styles[37].ForeColor = Color.FromArgb(12040119);
		TestResolver().Styles[37].BackColor = Color.FromArgb(2760988);
		Margin obj = TestResolver().Margins[1];
		obj.Width = 30;
		obj.Type = MarginType.Number;
		obj.Sensitive = true;
		obj.Mask = 0u;
		TestResolver().MarginClick += SelectToken;
	}

	private void ComputeToken()
	{
		Margin obj = TestResolver().Margins[2];
		obj.Width = 20;
		obj.Sensitive = true;
		obj.Type = MarginType.Symbol;
		obj.Mask = 4u;
		Marker obj2 = TestResolver().Markers[2];
		obj2.Symbol = MarkerSymbol.Circle;
		obj2.SetBackColor(Color.FromArgb(16711739));
		obj2.SetForeColor(Color.FromArgb(0));
		obj2.SetAlpha(100);
	}

	private void PatchToken()
	{
		TestResolver().SetFoldMarginColor(use: true, Color.FromArgb(2760988));
		TestResolver().SetFoldMarginHighlightColor(use: true, Color.FromArgb(2760988));
		TestResolver().SetProperty("fold", "1");
		TestResolver().SetProperty("fold.compact", "1");
		TestResolver().Margins[3].Type = MarginType.Symbol;
		TestResolver().Margins[3].Mask = 4261412864u;
		TestResolver().Margins[3].Sensitive = true;
		TestResolver().Margins[3].Width = 20;
		int num = 25;
		do
		{
			TestResolver().Markers[num].SetForeColor(Color.FromArgb(2760988));
			TestResolver().Markers[num].SetBackColor(Color.FromArgb(12040119));
			num++;
		}
		while (num <= 31);
		TestResolver().Markers[30].Symbol = MarkerSymbol.CirclePlus;
		TestResolver().Markers[31].Symbol = MarkerSymbol.CircleMinus;
		TestResolver().Markers[25].Symbol = MarkerSymbol.CirclePlusConnected;
		TestResolver().Markers[27].Symbol = MarkerSymbol.TCorner;
		TestResolver().Markers[26].Symbol = MarkerSymbol.CircleMinusConnected;
		TestResolver().Markers[29].Symbol = MarkerSymbol.VLine;
		TestResolver().Markers[28].Symbol = MarkerSymbol.LCorner;
		TestResolver().AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
	}

	private void SelectToken(object sender, MarginClickEventArgs e)
	{
		if (e.Margin == 2)
		{
			Line val = TestResolver().Lines[TestResolver().LineFromPosition(e.Position)];
			if ((long)(val.MarkerGet() & 4) <= 0L)
			{
				val.MarkerAdd(2);
			}
			else
			{
				val.MarkerDelete(2);
			}
		}
	}

	private void CallToken()
	{
	}

	private void LogoutToken()
	{
	}

	private void ViewToken(object sender, EventArgs e)
	{
		LogoutToken();
	}

	private void ValidateToken(object sender, EventArgs e)
	{
	}

	private void LoginToken(object sender, EventArgs e)
	{
	}

	private void GetToken(object sender, EventArgs e)
	{
	}

	private void WriteToken(object sender, KeyEventArgs e)
	{
	}

	private void NewToken()
	{
	}

	private void PushToken()
	{
	}

	public void InitDragDropFile()
	{
		((Control)TestResolver()).AllowDrop = true;
	}

	private void InvokeToken(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void SetupToken(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
			if (array != null)
			{
				string string_ = array.GetValue(0).ToString();
				ExcludeToken(string_);
			}
		}
	}

	private void ExcludeToken(string string_0)
	{
		if (FileExistsNative.FileExistsFast(string_0))
		{
			((Control)TestResolver()).Text = File.ReadAllText(string_0);
		}
	}

	private void IncludeToken(object sender, EventArgs e)
	{
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			ExcludeToken(OpenFileDialog1.FileName);
		}
	}

	private void SearchToken(object sender, EventArgs e)
	{
	}

	private void EnableToken(object sender, EventArgs e)
	{
	}

	private void ChangeToken(object sender, EventArgs e)
	{
	}

	private void InitToken(object sender, EventArgs e)
	{
		TestResolver().Cut();
	}

	private void CheckToken(object sender, EventArgs e)
	{
		TestResolver().Copy();
	}

	private void ConcatToken(object sender, EventArgs e)
	{
		TestResolver().Paste();
	}

	private void InterruptToken(object sender, EventArgs e)
	{
		TestResolver().SelectAll();
	}

	private void RemoveToken(object sender, EventArgs e)
	{
		Line val = TestResolver().Lines[TestResolver().CurrentLine];
		TestResolver().SetSelection(val.Position + val.Length, val.Position);
	}

	private void FindToken(object sender, EventArgs e)
	{
		TestResolver().SetEmptySelection(0);
	}

	private void SetToken(object sender, EventArgs e)
	{
		RestartToken();
	}

	private void FillToken(object sender, EventArgs e)
	{
		TestToken();
	}

	private void CalculateToken(object sender, EventArgs e)
	{
		VisitToken();
	}

	private void PopToken(object sender, EventArgs e)
	{
		ReflectToken();
	}

	private void InstantiateToken(object sender, EventArgs e)
	{
		wordWrapItem.Checked = !wordWrapItem.Checked;
		TestResolver().WrapMode = (wordWrapItem.Checked ? WrapMode.Word : WrapMode.None);
	}

	private void CreateToken(object sender, EventArgs e)
	{
		indentGuidesItem.Checked = !indentGuidesItem.Checked;
		TestResolver().IndentationGuides = (indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None);
	}

	private void CompareToken(object sender, EventArgs e)
	{
		hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
		TestResolver().ViewWhitespace = (hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible);
	}

	private void ReadToken(object sender, EventArgs e)
	{
		CancelToken();
	}

	private void DisableToken(object sender, EventArgs e)
	{
		VerifyToken();
	}

	private void UpdateToken(object sender, EventArgs e)
	{
		ListToken();
	}

	private void InsertToken(object sender, EventArgs e)
	{
		TestResolver().FoldAll(FoldAction.Contract);
	}

	private void PrepareToken(object sender, EventArgs e)
	{
		TestResolver().FoldAll(FoldAction.Expand);
	}

	private void ReflectToken()
	{
		int selectionStart = TestResolver().SelectionStart;
		int selectionEnd = TestResolver().SelectionEnd;
		TestResolver().ReplaceSelection(TestResolver().GetTextRange(selectionStart, selectionEnd - selectionStart).ToLower());
		TestResolver().SetSelection(selectionStart, selectionEnd);
	}

	private void VisitToken()
	{
		int selectionStart = TestResolver().SelectionStart;
		int selectionEnd = TestResolver().SelectionEnd;
		TestResolver().ReplaceSelection(TestResolver().GetTextRange(selectionStart, selectionEnd - selectionStart).ToUpper());
		TestResolver().SetSelection(selectionStart, selectionEnd);
	}

	private void RestartToken()
	{
		StopToken("{TAB}");
	}

	private void TestToken()
	{
		StopToken("+{TAB}");
	}

	private void StopToken(string string_0)
	{
		HotKeyManager.Enable = false;
		((Control)TestResolver()).Focus();
		SendKeys.Send(string_0);
		HotKeyManager.Enable = true;
	}

	private void CancelToken()
	{
		TestResolver().ZoomIn();
	}

	private void VerifyToken()
	{
		TestResolver().ZoomOut();
	}

	private void ListToken()
	{
		TestResolver().Zoom = 0;
	}

	private void ResolveToken(object sender, EventArgs e)
	{
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			ExcludeToken(OpenFileDialog1.FileName);
		}
	}

	public static Color IntToColor(int int_0)
	{
		return Color.FromArgb(int_0);
	}

	public void InvokeIfNeeded(Action action_0)
	{
		if (base.InvokeRequired)
		{
			BeginInvoke(action_0);
		}
		else
		{
			action_0();
		}
	}

	private void PostToken(object sender, EventArgs e)
	{
		TestResolver().Cut();
	}

	private void RunToken(object sender, EventArgs e)
	{
		TestResolver().Copy();
	}

	private void StartToken(object sender, EventArgs e)
	{
		TestResolver().Paste();
	}

	private void AssetToken(object sender, EventArgs e)
	{
		Line val = TestResolver().Lines[TestResolver().CurrentLine];
		TestResolver().SetSelection(val.Position + val.Length, val.Position);
	}

	private void PrintToken(object sender, EventArgs e)
	{
		TestResolver().SelectAll();
	}

	private void DefineToken(object sender, EventArgs e)
	{
		TestResolver().SetEmptySelection(0);
	}

	private void PublishToken(object sender, EventArgs e)
	{
		RestartToken();
	}

	private void AwakeToken(object sender, EventArgs e)
	{
		TestToken();
	}

	private void QueryToken(object sender, EventArgs e)
	{
		VisitToken();
	}

	private void ResetToken(object sender, EventArgs e)
	{
		ReflectToken();
	}

	private void MapToken(object sender, EventArgs e)
	{
		wordWrapItem.Checked = !wordWrapItem.Checked;
		TestResolver().WrapMode = (wordWrapItem.Checked ? WrapMode.Word : WrapMode.None);
	}

	private void SortToken(object sender, EventArgs e)
	{
		indentGuidesItem.Checked = !indentGuidesItem.Checked;
		TestResolver().IndentationGuides = (indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None);
	}

	private void CalcToken(object sender, EventArgs e)
	{
		hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
		TestResolver().ViewWhitespace = (hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible);
	}

	private void RateToken(object sender, EventArgs e)
	{
		CancelToken();
	}

	private void FlushToken(object sender, EventArgs e)
	{
		VerifyToken();
	}

	private void ForgotToken(object sender, EventArgs e)
	{
		ListToken();
	}

	private void CollectToken(object sender, EventArgs e)
	{
		TestResolver().FoldAll(FoldAction.Contract);
	}

	private void OrderToken(object sender, EventArgs e)
	{
		TestResolver().FoldAll(FoldAction.Expand);
	}

	private void RegisterToken(object sender, EventArgs e)
	{
		if (!Client.CurrentScenario.Scenario_LuaSandbox.Equals(configValue))
		{
			configValue.LuaPrint -= CloneToken;
			configValue = Client.CurrentScenario.Scenario_LuaSandbox;
			configValue.LuaPrint += CloneToken;
		}
		if (Operators.CompareString(((Control)TestResolver()).Text.ToString(), "", TextCompare: true) == 0)
		{
			return;
		}
		if (CB_EchoInput.Checked)
		{
			DarkTextBox textBox;
			(textBox = TextBox1).Text = textBox.Text + "\r\n>> " + ((Control)TestResolver()).Text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (((Control)TestResolver()).Text.Length != 0)
		{
			stringBuilder.Append(((Control)TestResolver()).Text);
			string string_ = "控制台：";
			object object_ = stringBuilder.ToString();
			LuaUtility.AddToLuaHistoryFile(ref string_, ref object_, bool_0: true);
			stringBuilder.Clear();
		}
		object[] array = null;
		try
		{
			array = configValue.RunScript(((Control)TestResolver()).Text, bool_0: true, "Console");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			TextBox1.AppendText("\r\nInternal ERROR: " + ex2.Message);
			stringBuilder.Append("内部错误：" + ex2.Message).Append("\r\n");
			ProjectData.ClearProjectError();
		}
		if (!Information.IsNothing(array) && array.Count() > 0 && array[0] != null)
		{
			if ((object)array[0].GetType() == typeof(LuaScriptException))
			{
				if (Information.IsNothing(((LuaScriptException)array[0]).InnerException))
				{
					TextBox1.AppendText("\r\nERROR: " + ((LuaScriptException)array[0]).Source + " " + ((LuaScriptException)array[0]).Message);
					stringBuilder.Append("错误：" + ((LuaScriptException)array[0]).Source + " " + ((LuaScriptException)array[0]).Message).Append("\r\n");
				}
				else
				{
					TextBox1.AppendText("\r\nERROR: " + ((LuaScriptException)array[0]).InnerException.Message);
					stringBuilder.Append("错误：" + ((LuaScriptException)array[0]).InnerException.Message).Append("\r\n");
				}
			}
			else
			{
				TextBox1.AppendText("\r\n" + LuaUtility.LuaInterpret(array));
				stringBuilder.Append(LuaUtility.LuaInterpret(array));
			}
		}
		TextBox1.Select(TextBox1.TextLength, 0);
		TextBox1.ScrollToCaret();
		Client.MustRefreshMainForm = true;
		if (stringBuilder != null)
		{
			if (stringBuilder.Length <= 0)
			{
				string string_2 = "...";
				object object_2 = "";
				LuaUtility.AddToLuaHistoryFile(ref string_2, ref object_2);
			}
			else
			{
				string string_3 = "";
				object object_3 = stringBuilder.ToString();
				LuaUtility.AddToLuaHistoryFile(ref string_3, ref object_3);
			}
		}
	}

	private void ManageToken(object sender, EventArgs e)
	{
		TestResolver().ReplaceSelection(Conversions.ToString(ComboBox1.SelectedItem));
	}

	private void RevertToken(object sender, EventArgs e)
	{
		CountIndexer("\"", "\"");
	}

	private void CountIndexer(string string_0, string string_1)
	{
		int selectionStart = TestResolver().SelectionStart;
		int selectionEnd = TestResolver().SelectionEnd;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string_0);
		stringBuilder.Append(TestResolver().GetTextRange(selectionStart, selectionEnd - selectionStart));
		stringBuilder.Append(string_1);
		TestResolver().ReplaceSelection(stringBuilder.ToString());
	}

	private void CustomizeIndexer(object sender, EventArgs e)
	{
		CountIndexer("(", ")");
	}

	private void CloneIndexer(object sender, EventArgs e)
	{
		CountIndexer("{", "}");
	}

	private void ConnectIndexer(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		Hide();
	}

	private void MoveIndexer(object sender, EventArgs e)
	{
		DeleteIndexer();
	}

	private void DeleteIndexer(string string_0 = "")
	{
		Process.Start("https://commandlua.github.io/index2.html" + string_0);
	}

	private void AddIndexer(string string_0 = "")
	{
		Process.Start("https://commandlua.github.io/" + string_0);
	}

	private void DestroyIndexer(object sender, EventArgs e)
	{
		string text = "";
		if (Operators.CompareString(ComboBox1.Text, "", TextCompare: true) != 0 && ComboBox1.Text.Contains("("))
		{
			text = ComboBox1.Text.Substring(0, ComboBox1.Text.LastIndexOf("("));
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				text = "assets/Function_" + text + ".html";
			}
		}
		AddIndexer(text);
	}

	private void ComputeIndexer(object sender, EventArgs e)
	{
		Process.Start("https://wiki.weaponsrelease.com/index.php/Script_Repository");
	}
}
