using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;
using OpenDis.Candidates;

namespace OpenDis.Pages;

[HideModuleName]
[StandardModule]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class MerchantMerchantPage
{
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class StateCollectionRecord
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type SetInterruptibleParam()
		{
			return typeof(StateCollectionRecord);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T FillInterruptibleParam<T>(T gparam_0) where T : new()
		{
			if (gparam_0 == null)
			{
				return new T();
			}
			return gparam_0;
		}

		[DebuggerHidden]
		private void CalculateInterruptibleParam<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public StateCollectionRecord()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class AuthenticationParameterMock<T> where T : new()
	{
		private readonly ContextValue<T> threadSetter;

		internal static object ruleSetter;

		[SpecialName]
		[DebuggerHidden]
		internal T CreateInterruptibleParam()
		{
			T val = threadSetter.Value;
			if (val == null)
			{
				val = new T();
				threadSetter.Value = val;
			}
			return val;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public AuthenticationParameterMock()
		{
			threadSetter = new ContextValue<T>();
		}

		internal static bool PopInterruptibleParam()
		{
			return ruleSetter == null;
		}
	}

	private static readonly AuthenticationParameterMock<StructMerchantPage> _RegReader;

	private static readonly AuthenticationParameterMock<QueueReader> paramReader;

	private static readonly AuthenticationParameterMock<User> pageReader;

	private static readonly AuthenticationParameterMock<StateCollectionRecord> m_RulesReader;

	[HelpKeyword("My.Computer")]
	internal static StructMerchantPage SelectList
	{
		[DebuggerHidden]
		get
		{
			return _RegReader.CreateInterruptibleParam();
		}
	}

	[HelpKeyword("My.Application")]
	internal static QueueReader LogoutList
	{
		[DebuggerHidden]
		get
		{
			return paramReader.CreateInterruptibleParam();
		}
	}

	[HelpKeyword("My.User")]
	internal static User ValidateList
	{
		[DebuggerHidden]
		get
		{
			return pageReader.CreateInterruptibleParam();
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static StateCollectionRecord GetList
	{
		[DebuggerHidden]
		get
		{
			return m_RulesReader.CreateInterruptibleParam();
		}
	}

	static MerchantMerchantPage()
	{
		_RegReader = new AuthenticationParameterMock<StructMerchantPage>();
		paramReader = new AuthenticationParameterMock<QueueReader>();
		pageReader = new AuthenticationParameterMock<User>();
		m_RulesReader = new AuthenticationParameterMock<StateCollectionRecord>();
	}
}
