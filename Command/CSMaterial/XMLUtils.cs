using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace CSMaterial;

public static class XMLUtils
{
	[CompilerGenerated]
	private sealed class _003CStreamElement_003Ed__0 : IEnumerable<XElement>, IEnumerable, IEnumerator<XElement>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private XElement _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string string_0;

		public string _003C_003E3__string_0;

		private string string_1;

		public string _003C_003E3__string_1;

		private XmlReader _003Creader_003E5__1;

		XElement IEnumerator<XElement>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CStreamElement_003Ed__0(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003Creader_003E5__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			bool result;
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					result = false;
					goto end_IL_0000;
				case 0:
					_003C_003E1__state = -1;
					_003Creader_003E5__1 = XmlReader.Create(new StringReader(string_0));
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003Creader_003E5__1.Name == string_1 || _003Creader_003E5__1.ReadToFollowing(string_1))
				{
					_003C_003E2__current = (XElement)XNode.ReadFrom(_003Creader_003E5__1);
					_003C_003E1__state = 1;
					result = true;
				}
				else
				{
					result = false;
					_003C_003Em__Finally1();
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
			return result;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003Creader_003E5__1 != null)
			{
				((IDisposable)_003Creader_003E5__1).Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<XElement> IEnumerable<XElement>.GetEnumerator()
		{
			_003CStreamElement_003Ed__0 _003CStreamElement_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CStreamElement_003Ed__ = this;
			}
			else
			{
				_003CStreamElement_003Ed__ = new _003CStreamElement_003Ed__0(0);
			}
			_003CStreamElement_003Ed__.string_0 = _003C_003E3__string_0;
			_003CStreamElement_003Ed__.string_1 = _003C_003E3__string_1;
			return _003CStreamElement_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<XElement>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CStreamElement_003Ed__0))]
	public static IEnumerable<XElement> StreamElement(string string_0, string string_1)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CStreamElement_003Ed__0(-2)
		{
			_003C_003E3__string_0 = string_0,
			_003C_003E3__string_1 = string_1
		};
	}
}
