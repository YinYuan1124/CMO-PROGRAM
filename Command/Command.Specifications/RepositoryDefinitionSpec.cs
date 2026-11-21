using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Command.Specifications;

[CompilerGenerated]
internal sealed class RepositoryDefinitionSpec<_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar, _003CProp_0_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar _003C_003C_003Eh__TransparentIdentifier2_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CProp_0_003Ej__TPar _003CProp_0_003Ei__Field;

	public _003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar _003C_003Eh__TransparentIdentifier2 => _003C_003C_003Eh__TransparentIdentifier2_003Ei__Field;

	public _003CProp_0_003Ej__TPar Prop_0 => _003CProp_0_003Ei__Field;

	[DebuggerHidden]
	public RepositoryDefinitionSpec(_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar _003C_003Eh__TransparentIdentifier2, _003CProp_0_003Ej__TPar Prop_0)
	{
		_003C_003C_003Eh__TransparentIdentifier2_003Ei__Field = _003C_003Eh__TransparentIdentifier2;
		_003CProp_0_003Ei__Field = Prop_0;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		RepositoryDefinitionSpec<_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar, _003CProp_0_003Ej__TPar> repositoryDefinitionSpec = value as RepositoryDefinitionSpec<_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar, _003CProp_0_003Ej__TPar>;
		if (this != repositoryDefinitionSpec)
		{
			if (repositoryDefinitionSpec != null && EqualityComparer<_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar>.Default.Equals(_003C_003C_003Eh__TransparentIdentifier2_003Ei__Field, repositoryDefinitionSpec._003C_003C_003Eh__TransparentIdentifier2_003Ei__Field))
			{
				return EqualityComparer<_003CProp_0_003Ej__TPar>.Default.Equals(_003CProp_0_003Ei__Field, repositoryDefinitionSpec._003CProp_0_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (-1841511645 + EqualityComparer<_003C_003C_003Eh__TransparentIdentifier2_003Ej__TPar>.Default.GetHashCode(_003C_003C_003Eh__TransparentIdentifier2_003Ei__Field)) * -1521134295 + EqualityComparer<_003CProp_0_003Ej__TPar>.Default.GetHashCode(_003CProp_0_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		return string.Format(null, "{{ <>h__TransparentIdentifier2 = {0}, Prop_0 = {1} }}", new object[2]
		{
			_003C_003C_003Eh__TransparentIdentifier2_003Ei__Field?.ToString(),
			_003CProp_0_003Ei__Field?.ToString()
		});
	}
}
