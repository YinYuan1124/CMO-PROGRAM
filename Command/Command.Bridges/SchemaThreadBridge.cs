using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Command.Bridges;

[CompilerGenerated]
internal sealed class SchemaThreadBridge<_003Cm_003Ej__TPar, _003Carg_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cm_003Ej__TPar _003Cm_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Carg_003Ej__TPar _003Carg_003Ei__Field;

	public _003Cm_003Ej__TPar m => _003Cm_003Ei__Field;

	public _003Carg_003Ej__TPar arg => _003Carg_003Ei__Field;

	[DebuggerHidden]
	public SchemaThreadBridge(_003Cm_003Ej__TPar m, _003Carg_003Ej__TPar arg)
	{
		_003Cm_003Ei__Field = m;
		_003Carg_003Ei__Field = arg;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		SchemaThreadBridge<_003Cm_003Ej__TPar, _003Carg_003Ej__TPar> schemaThreadBridge = value as SchemaThreadBridge<_003Cm_003Ej__TPar, _003Carg_003Ej__TPar>;
		if (this != schemaThreadBridge)
		{
			if (schemaThreadBridge != null && EqualityComparer<_003Cm_003Ej__TPar>.Default.Equals(_003Cm_003Ei__Field, schemaThreadBridge._003Cm_003Ei__Field))
			{
				return EqualityComparer<_003Carg_003Ej__TPar>.Default.Equals(_003Carg_003Ei__Field, schemaThreadBridge._003Carg_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (1280158517 + EqualityComparer<_003Cm_003Ej__TPar>.Default.GetHashCode(_003Cm_003Ei__Field)) * -1521134295 + EqualityComparer<_003Carg_003Ej__TPar>.Default.GetHashCode(_003Carg_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ m = {0}, arg = {1} }}", new object[2]
		{
			_003Cm_003Ei__Field?.ToString(),
			_003Carg_003Ei__Field?.ToString()
		});
	}
}
