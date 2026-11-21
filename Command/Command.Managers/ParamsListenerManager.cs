using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Command.Managers;

[CompilerGenerated]
internal sealed class ParamsListenerManager<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003CgenericEntryDescription_0_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003C_003Eh__TransparentIdentifier1_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CgenericEntryDescription_0_003Ej__TPar _003CgenericEntryDescription_0_003Ei__Field;

	public _003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003Eh__TransparentIdentifier1 => _003C_003C_003Eh__TransparentIdentifier1_003Ei__Field;

	public _003CgenericEntryDescription_0_003Ej__TPar genericEntryDescription_0 => _003CgenericEntryDescription_0_003Ei__Field;

	[DebuggerHidden]
	public ParamsListenerManager(_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003Eh__TransparentIdentifier1, _003CgenericEntryDescription_0_003Ej__TPar genericEntryDescription_0)
	{
		_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field = _003C_003Eh__TransparentIdentifier1;
		_003CgenericEntryDescription_0_003Ei__Field = genericEntryDescription_0;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		ParamsListenerManager<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003CgenericEntryDescription_0_003Ej__TPar> paramsListenerManager = value as ParamsListenerManager<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003CgenericEntryDescription_0_003Ej__TPar>;
		if (this != paramsListenerManager)
		{
			if (paramsListenerManager != null && EqualityComparer<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar>.Default.Equals(_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field, paramsListenerManager._003C_003C_003Eh__TransparentIdentifier1_003Ei__Field))
			{
				return EqualityComparer<_003CgenericEntryDescription_0_003Ej__TPar>.Default.Equals(_003CgenericEntryDescription_0_003Ei__Field, paramsListenerManager._003CgenericEntryDescription_0_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (-1113243572 + EqualityComparer<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar>.Default.GetHashCode(_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field)) * -1521134295 + EqualityComparer<_003CgenericEntryDescription_0_003Ej__TPar>.Default.GetHashCode(_003CgenericEntryDescription_0_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ <>h__TransparentIdentifier1 = {0}, genericEntryDescription_0 = {1} }}", new object[2]
		{
			_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field?.ToString(),
			_003CgenericEntryDescription_0_003Ei__Field?.ToString()
		});
	}
}
