using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenDis.Resolver;

[CompilerGenerated]
internal sealed class Struct<_003Ce_003Ej__TPar, _003Cj_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Ce_003Ej__TPar _003Ce_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cj_003Ej__TPar _003Cj_003Ei__Field;

	public _003Ce_003Ej__TPar e => _003Ce_003Ei__Field;

	public _003Cj_003Ej__TPar j => _003Cj_003Ei__Field;

	[DebuggerHidden]
	public Struct(_003Ce_003Ej__TPar e, _003Cj_003Ej__TPar j)
	{
		_003Ce_003Ei__Field = e;
		_003Cj_003Ei__Field = j;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		Struct<_003Ce_003Ej__TPar, _003Cj_003Ej__TPar> @struct = value as Struct<_003Ce_003Ej__TPar, _003Cj_003Ej__TPar>;
		if (this != @struct)
		{
			if (@struct != null && EqualityComparer<_003Ce_003Ej__TPar>.Default.Equals(_003Ce_003Ei__Field, @struct._003Ce_003Ei__Field))
			{
				return EqualityComparer<_003Cj_003Ej__TPar>.Default.Equals(_003Cj_003Ei__Field, @struct._003Cj_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (-137024757 + EqualityComparer<_003Ce_003Ej__TPar>.Default.GetHashCode(_003Ce_003Ei__Field)) * -1521134295 + EqualityComparer<_003Cj_003Ej__TPar>.Default.GetHashCode(_003Cj_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ e = {0}, j = {1} }}", new object[2]
		{
			_003Ce_003Ei__Field?.ToString(),
			_003Cj_003Ei__Field?.ToString()
		});
	}
}
