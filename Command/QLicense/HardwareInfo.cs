using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using OpenDis.Common;

namespace QLicense;

public sealed class HardwareInfo
{
	[CompilerGenerated]
	private sealed class _003CDestroyDecorator_003Ed__3 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private object object_0;

		public object _003C_003E3__object_0;

		private int int_0;

		public int _003C_003E3__int_0;

		private int _003Ci_003E5__1;

		string IEnumerator<string>.Current
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
		public _003CDestroyDecorator_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (object_0 != null)
				{
					if (int_0 <= 0)
					{
						throw new ArgumentException("Part length has to be positive.", "partLength");
					}
					_003Ci_003E5__1 = 0;
					goto IL_00c1;
				}
				throw new ArgumentNullException("input");
			case 1:
				{
					_003C_003E1__state = -1;
					_003Ci_003E5__1 += int_0;
					goto IL_00c1;
				}
				IL_00c1:
				if (_003Ci_003E5__1 < ((string)object_0).Length)
				{
					_003C_003E2__current = ((string)object_0).Substring(_003Ci_003E5__1, Math.Min(int_0, ((string)object_0).Length - _003Ci_003E5__1));
					_003C_003E1__state = 1;
					return true;
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CDestroyDecorator_003Ed__3 _003CDestroyDecorator_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CDestroyDecorator_003Ed__ = this;
			}
			else
			{
				_003CDestroyDecorator_003Ed__ = new _003CDestroyDecorator_003Ed__3(0);
			}
			_003CDestroyDecorator_003Ed__.object_0 = _003C_003E3__object_0;
			_003CDestroyDecorator_003Ed__.int_0 = _003C_003E3__int_0;
			return _003CDestroyDecorator_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private static string MoveDecorator()
	{
		try
		{
			ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.deviceid=\"c:\"");
			managementObject.Get();
			return managementObject["VolumeSerialNumber"].ToString();
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string DeleteDecorator()
	{
		try
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get();
			string result = string.Empty;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator())
			{
				if (managementObjectEnumerator.MoveNext())
				{
					result = ((ManagementObject)managementObjectEnumerator.Current)["ProcessorId"].ToString();
				}
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string AddDecorator()
	{
		try
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard").Get();
			string result = string.Empty;
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator())
			{
				if (managementObjectEnumerator.MoveNext())
				{
					result = ((ManagementObject)managementObjectEnumerator.Current)["SerialNumber"].ToString();
				}
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}

	[IteratorStateMachine(typeof(_003CDestroyDecorator_003Ed__3))]
	private static IEnumerable<string> DestroyDecorator(object object_0, int int_0)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDestroyDecorator_003Ed__3(-2)
		{
			_003C_003E3__object_0 = object_0,
			_003C_003E3__int_0 = int_0
		};
	}

	public static string smethod_0(string string_0)
	{
		string s = string_0 + DeleteDecorator() + AddDecorator() + MoveDecorator();
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		byte[] value = new MD5CryptoServiceProvider().ComputeHash(bytes);
		string text = ConnectionCallback.CloneDecorator(BitConverter.ToUInt32(value, 0));
		string text2 = ConnectionCallback.CloneDecorator(BitConverter.ToUInt32(value, 4));
		string text3 = ConnectionCallback.CloneDecorator(BitConverter.ToUInt32(value, 8));
		string text4 = ConnectionCallback.CloneDecorator(BitConverter.ToUInt32(value, 12));
		return text + "-" + text2 + "-" + text3 + "-" + text4;
	}

	public static byte[] GetUIDInBytes(string string_0)
	{
		string[] array = string_0.Split('-');
		if (array.Length != 4)
		{
			throw new ArgumentException("Wrong UID");
		}
		byte[] array2 = new byte[16];
		Buffer.BlockCopy(BitConverter.GetBytes(ConnectionCallback.CustomizeDecorator(array[0])), 0, array2, 0, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(ConnectionCallback.CustomizeDecorator(array[1])), 0, array2, 8, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(ConnectionCallback.CustomizeDecorator(array[2])), 0, array2, 16, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(ConnectionCallback.CustomizeDecorator(array[3])), 0, array2, 24, 8);
		return array2;
	}

	public static bool ValidateUIDFormat(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		return string_0.Split('-').Length == 4;
	}
}
