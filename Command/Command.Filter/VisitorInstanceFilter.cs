using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Command.Filter;

[CompilerGenerated]
internal sealed class VisitorInstanceFilter<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003Cspecific_0_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003C_003Eh__TransparentIdentifier1_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cspecific_0_003Ej__TPar _003Cspecific_0_003Ei__Field;

	public _003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003Eh__TransparentIdentifier1 => _003C_003C_003Eh__TransparentIdentifier1_003Ei__Field;

	public _003Cspecific_0_003Ej__TPar specific_0 => _003Cspecific_0_003Ei__Field;

	[DebuggerHidden]
	public VisitorInstanceFilter(_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar _003C_003Eh__TransparentIdentifier1, _003Cspecific_0_003Ej__TPar specific_0)
	{
		_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field = _003C_003Eh__TransparentIdentifier1;
		_003Cspecific_0_003Ei__Field = specific_0;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		VisitorInstanceFilter<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003Cspecific_0_003Ej__TPar> visitorInstanceFilter = value as VisitorInstanceFilter<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar, _003Cspecific_0_003Ej__TPar>;
		if (this != visitorInstanceFilter)
		{
			if (visitorInstanceFilter != null && EqualityComparer<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar>.Default.Equals(_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field, visitorInstanceFilter._003C_003C_003Eh__TransparentIdentifier1_003Ei__Field))
			{
				return EqualityComparer<_003Cspecific_0_003Ej__TPar>.Default.Equals(_003Cspecific_0_003Ei__Field, visitorInstanceFilter._003Cspecific_0_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (-1355605053 + EqualityComparer<_003C_003C_003Eh__TransparentIdentifier1_003Ej__TPar>.Default.GetHashCode(_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field)) * -1521134295 + EqualityComparer<_003Cspecific_0_003Ej__TPar>.Default.GetHashCode(_003Cspecific_0_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ <>h__TransparentIdentifier1 = {0}, specific_0 = {1} }}", new object[2]
		{
			_003C_003C_003Eh__TransparentIdentifier1_003Ei__Field?.ToString(),
			_003Cspecific_0_003Ei__Field?.ToString()
		});
	}
}
