using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Magic.Samples.DisplaySettings;

public static class DisplayManager
{
	[CompilerGenerated]
	private sealed class _003CGetModesEnumerator_003Ed__2 : IEnumerator<DisplaySettings>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private DisplaySettings _003C_003E2__current;

		private SafeNativeMethods.DEVMODE _003Cmode_003E5__1;

		private int _003Cidx_003E5__2;

		DisplaySettings IEnumerator<DisplaySettings>.Current
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
		public _003CGetModesEnumerator_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cmode_003E5__1 = default(SafeNativeMethods.DEVMODE);
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
				_003Cmode_003E5__1 = default(SafeNativeMethods.DEVMODE);
				_003Cmode_003E5__1.Initialize();
				_003Cidx_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (SafeNativeMethods.EnumDisplaySettings(null, _003Cidx_003E5__2, ref _003Cmode_003E5__1))
			{
				_003C_003E2__current = CreateProcess(_003Cidx_003E5__2++, _003Cmode_003E5__1);
				_003C_003E1__state = 1;
				return true;
			}
			return false;
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
	}

	public static DisplaySettings GetCurrentSettings()
	{
		return CreateProcess(-1, CompareProcess());
	}

	public static void SetDisplaySettings(DisplaySettings displaySettings_0)
	{
		SafeNativeMethods.DEVMODE devmode_ = CompareProcess();
		devmode_.dmPelsWidth = (uint)displaySettings_0.Width;
		devmode_.dmPelsHeight = (uint)displaySettings_0.Height;
		devmode_.dmDisplayOrientation = (uint)displaySettings_0.Orientation;
		devmode_.dmBitsPerPel = (uint)displaySettings_0.BitCount;
		devmode_.dmDisplayFrequency = (uint)displaySettings_0.Frequency;
		DisplayChangeResult displayChangeResult = (DisplayChangeResult)SafeNativeMethods.ChangeDisplaySettings(ref devmode_, 0u);
		string text = null;
		switch (displayChangeResult)
		{
		case DisplayChangeResult.BadDualView:
			text = "The settings change was unsuccessful because system is DualView capable.";
			break;
		case DisplayChangeResult.BadParam:
			text = "An invalid parameter was passed in. This can include an invalid flag or combination of flags.";
			break;
		case DisplayChangeResult.BadFlags:
			text = "An invalid set of flags was passed in.";
			break;
		case DisplayChangeResult.NotUpdated:
			text = "Unable to write settings to the registry.";
			break;
		case DisplayChangeResult.BadMode:
			text = "The graphics mode is not supported.";
			break;
		case DisplayChangeResult.Failed:
			text = "The display driver failed the specified graphics mode.";
			break;
		case DisplayChangeResult.Restart:
			text = "The computer must be restarted in order for the graphics mode to work.";
			break;
		}
		if (text != null)
		{
			throw new InvalidOperationException(text);
		}
	}

	[IteratorStateMachine(typeof(_003CGetModesEnumerator_003Ed__2))]
	public static IEnumerator<DisplaySettings> GetModesEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetModesEnumerator_003Ed__2(0);
	}

	public static void RotateScreen(bool bool_0)
	{
		DisplaySettings currentSettings = GetCurrentSettings();
		int height = currentSettings.Height;
		currentSettings.Height = currentSettings.Width;
		currentSettings.Width = height;
		if (bool_0)
		{
			currentSettings.Orientation++;
		}
		else
		{
			currentSettings.Orientation--;
		}
		if (currentSettings.Orientation < Orientation.Default)
		{
			currentSettings.Orientation = Orientation.Clockwise270;
		}
		else if (currentSettings.Orientation > Orientation.Clockwise270)
		{
			currentSettings.Orientation = Orientation.Default;
		}
		SetDisplaySettings(currentSettings);
	}

	private static DisplaySettings CreateProcess(int int_0, SafeNativeMethods.DEVMODE devmode_0)
	{
		DisplaySettings result = default(DisplaySettings);
		result.Index = int_0;
		result.Width = (int)devmode_0.dmPelsWidth;
		result.Height = (int)devmode_0.dmPelsHeight;
		result.Orientation = (Orientation)devmode_0.dmDisplayOrientation;
		result.BitCount = (int)devmode_0.dmBitsPerPel;
		result.Frequency = (int)devmode_0.dmDisplayFrequency;
		return result;
	}

	private static SafeNativeMethods.DEVMODE CompareProcess()
	{
		SafeNativeMethods.DEVMODE devmode_ = default(SafeNativeMethods.DEVMODE);
		devmode_.Initialize();
		if (!SafeNativeMethods.EnumDisplaySettings(null, -1, ref devmode_))
		{
			throw new InvalidOperationException(ReadProcess());
		}
		return devmode_;
	}

	private static string ReadProcess()
	{
		int lastWin32Error = Marshal.GetLastWin32Error();
		if (SafeNativeMethods.FormatMessage(4864u, 2048u, (uint)lastWin32Error, 0u, out var string_, 0u, 0u) == 0)
		{
			return "Fatal error.";
		}
		return string_;
	}
}
