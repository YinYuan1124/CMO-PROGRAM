using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Geodesic_Haversine
{
	[CompilerGenerated]
	private sealed class _003CUnitsWithinDistanceFromPoint_003Ed__4 : IEnumerable<ActiveUnit>, IEnumerable, IEnumerator<ActiveUnit>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private ActiveUnit _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<ActiveUnit> list_0;

		public List<ActiveUnit> _003C_003E3__list_0;

		private bool bool_0;

		public bool _003C_003E3__bool_0;

		private double double_0;

		public double _003C_003E3__double_0;

		private double double_1;

		public double _003C_003E3__double_1;

		private double double_2;

		public double _003C_003E3__double_2;

		private bool _003Cflag_003E5__1;

		private double _003CLocal_AngularDistance_003E5__2;

		private bool _003CLocal_CanUseLatitudeShortcut_003E5__3;

		private double _003CLocal_MaxLat_003E5__4;

		private double _003CLocal_MinLat_003E5__5;

		private bool? _003CLocal_OperatingHint_003E5__6;

		private int _003Ccount_003E5__7;

		private int _003Ci5_003E5__8;

		private ActiveUnit _003CactiveUnit_003E5__9;

		private double _003Cnum_003E5__10;

		private double _003Cnum2_003E5__11;

		ActiveUnit IEnumerator<ActiveUnit>.Current
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
		public _003CUnitsWithinDistanceFromPoint_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CactiveUnit_003E5__9 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_0225;
			}
			_003C_003E1__state = -1;
			_003Cflag_003E5__1 = bool_0;
			if (list_0.Count == 0)
			{
				return false;
			}
			_003CLocal_AngularDistance_003E5__2 = Math2.TestClass(double_2);
			_003CLocal_CanUseLatitudeShortcut_003E5__3 = true;
			_003CLocal_MaxLat_003E5__4 = double_0 + _003CLocal_AngularDistance_003E5__2;
			_003CLocal_MinLat_003E5__5 = double_0 - _003CLocal_AngularDistance_003E5__2;
			if (_003CLocal_MaxLat_003E5__4 > 90.0 || _003CLocal_MinLat_003E5__5 < -90.0)
			{
				_003CLocal_CanUseLatitudeShortcut_003E5__3 = false;
			}
			_003CLocal_OperatingHint_003E5__6 = null;
			if (_003Cflag_003E5__1)
			{
				_003CLocal_OperatingHint_003E5__6 = true;
			}
			_003Ccount_003E5__7 = list_0.Count;
			_003Ci5_003E5__8 = 0;
			goto IL_023f;
			IL_023f:
			if (_003Ci5_003E5__8 < _003Ccount_003E5__7)
			{
				_003CactiveUnit_003E5__9 = list_0[_003Ci5_003E5__8];
				if (_003CactiveUnit_003E5__9 == null)
				{
					goto IL_022d;
				}
				_003Cnum_003E5__10 = _003CactiveUnit_003E5__9.m_SerializerVal;
				_003Cnum2_003E5__11 = _003CactiveUnit_003E5__9._CustomerVal;
				if (_003Cnum_003E5__10 == 0.0)
				{
					_003Cnum_003E5__10 = _003CactiveUnit_003E5__9.GetLatitude(_003CLocal_OperatingHint_003E5__6);
				}
				if (!_003CLocal_CanUseLatitudeShortcut_003E5__3 || (!(_003CLocal_MaxLat_003E5__4 < _003Cnum_003E5__10) && !(_003CLocal_MinLat_003E5__5 > _003Cnum_003E5__10)))
				{
					if (_003Cnum2_003E5__11 == 0.0)
					{
						_003Cnum2_003E5__11 = _003CactiveUnit_003E5__9.GetLongitude(_003CLocal_OperatingHint_003E5__6);
					}
					if (!(Distance_Horiz_Angular_Approx_Deg(double_0, double_1, _003Cnum_003E5__10, _003Cnum2_003E5__11) > _003CLocal_AngularDistance_003E5__2))
					{
						_003C_003E2__current = _003CactiveUnit_003E5__9;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_0225;
			}
			return false;
			IL_0225:
			_003CactiveUnit_003E5__9 = null;
			goto IL_022d;
			IL_022d:
			_003Ci5_003E5__8++;
			goto IL_023f;
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
		IEnumerator<ActiveUnit> IEnumerable<ActiveUnit>.GetEnumerator()
		{
			_003CUnitsWithinDistanceFromPoint_003Ed__4 _003CUnitsWithinDistanceFromPoint_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CUnitsWithinDistanceFromPoint_003Ed__ = this;
			}
			else
			{
				_003CUnitsWithinDistanceFromPoint_003Ed__ = new _003CUnitsWithinDistanceFromPoint_003Ed__4(0);
			}
			_003CUnitsWithinDistanceFromPoint_003Ed__.list_0 = _003C_003E3__list_0;
			_003CUnitsWithinDistanceFromPoint_003Ed__.bool_0 = _003C_003E3__bool_0;
			_003CUnitsWithinDistanceFromPoint_003Ed__.double_0 = _003C_003E3__double_0;
			_003CUnitsWithinDistanceFromPoint_003Ed__.double_1 = _003C_003E3__double_1;
			_003CUnitsWithinDistanceFromPoint_003Ed__.double_2 = _003C_003E3__double_2;
			return _003CUnitsWithinDistanceFromPoint_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ActiveUnit>)this).GetEnumerator();
		}
	}

	public static double Distance_Horiz_Angular_Approx_Rad(double double_0, double double_1, double double_2, double double_3)
	{
		double d = double_0 * 0.0174532925199433;
		double d2 = double_2 * 0.0174532925199433;
		double num = (double_2 - double_0) * 0.0174532925199433;
		double num2 = (double_3 - double_1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		return 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5));
	}

	public static double Distance_Horiz_Angular_Approx_Deg(double double_0, double double_1, double double_2, double double_3)
	{
		double d = double_0 * 0.0174532925199433;
		double d2 = double_2 * 0.0174532925199433;
		double num = (double_2 - double_0) * 0.0174532925199433;
		double num2 = (double_3 - double_1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		return 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)) * 57.2957795130823;
	}

	public static double Distance_Horiz_Approx_nm(double double_0, double double_1, double double_2, double double_3)
	{
		double d = double_0 * 0.0174532925199433;
		double d2 = double_2 * 0.0174532925199433;
		double num = (double_2 - double_0) * 0.0174532925199433;
		double num2 = (double_3 - double_1) * 0.0174532925199433;
		double num3 = Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0);
		double num5 = num3 * num3 + Math.Cos(d) * Math.Cos(d2) * (num4 * num4);
		double num6 = 2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5));
		return 3441.6865234375 * num6;
	}

	public static bool PointIsWithinDistanceFromPoint(double double_0, double double_1, double double_2, double double_3, float float_0)
	{
		double num = Math2.TestClass(float_0);
		bool flag = true;
		double num2 = double_0 + num;
		double num3 = double_0 - num;
		if (num2 > 90.0 || num3 < -90.0)
		{
			flag = false;
		}
		if (flag && (num2 < double_2 || num3 > double_2))
		{
			return false;
		}
		if (Distance_Horiz_Angular_Approx_Deg(double_0, double_1, double_2, double_3) <= num)
		{
			return true;
		}
		return false;
	}

	[IteratorStateMachine(typeof(_003CUnitsWithinDistanceFromPoint_003Ed__4))]
	public static IEnumerable<ActiveUnit> UnitsWithinDistanceFromPoint(List<ActiveUnit> list_0, bool bool_0, double double_0, double double_1, double double_2)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CUnitsWithinDistanceFromPoint_003Ed__4(-2)
		{
			_003C_003E3__list_0 = list_0,
			_003C_003E3__bool_0 = bool_0,
			_003C_003E3__double_0 = double_0,
			_003C_003E3__double_1 = double_1,
			_003C_003E3__double_2 = double_2
		};
	}
}
