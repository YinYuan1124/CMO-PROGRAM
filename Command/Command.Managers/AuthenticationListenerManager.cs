using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Command.Managers;

[CompilerGenerated]
internal sealed class AuthenticationListenerManager<_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar, _003Ck_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar _003C_003C_003Eh__TransparentIdentifier0_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Ck_003Ej__TPar _003Ck_003Ei__Field;

	public _003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar _003C_003Eh__TransparentIdentifier0 => _003C_003C_003Eh__TransparentIdentifier0_003Ei__Field;

	public _003Ck_003Ej__TPar k => _003Ck_003Ei__Field;

	[DebuggerHidden]
	public AuthenticationListenerManager(_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar _003C_003Eh__TransparentIdentifier0, _003Ck_003Ej__TPar k)
	{
		_003C_003C_003Eh__TransparentIdentifier0_003Ei__Field = _003C_003Eh__TransparentIdentifier0;
		_003Ck_003Ei__Field = k;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		AuthenticationListenerManager<_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar, _003Ck_003Ej__TPar> authenticationListenerManager = value as AuthenticationListenerManager<_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar, _003Ck_003Ej__TPar>;
		if (this != authenticationListenerManager)
		{
			if (authenticationListenerManager != null && EqualityComparer<_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar>.Default.Equals(_003C_003C_003Eh__TransparentIdentifier0_003Ei__Field, authenticationListenerManager._003C_003C_003Eh__TransparentIdentifier0_003Ei__Field))
			{
				return EqualityComparer<_003Ck_003Ej__TPar>.Default.Equals(_003Ck_003Ei__Field, authenticationListenerManager._003Ck_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (1512541104 + EqualityComparer<_003C_003C_003Eh__TransparentIdentifier0_003Ej__TPar>.Default.GetHashCode(_003C_003C_003Eh__TransparentIdentifier0_003Ei__Field)) * -1521134295 + EqualityComparer<_003Ck_003Ej__TPar>.Default.GetHashCode(_003Ck_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ <>h__TransparentIdentifier0 = {0}, k = {1} }}", new object[2]
		{
			_003C_003C_003Eh__TransparentIdentifier0_003Ei__Field?.ToString(),
			_003Ck_003Ei__Field?.ToString()
		});
	}
}
