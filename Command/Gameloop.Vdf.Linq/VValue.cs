using System.Runtime.CompilerServices;

namespace Gameloop.Vdf.Linq;

public sealed class VValue : VToken
{
	[CompilerGenerated]
	private object configurationProcess;

	public new object Value
	{
		[CompilerGenerated]
		get
		{
			return configurationProcess;
		}
		[CompilerGenerated]
		set
		{
			configurationProcess = value;
		}
	}

	public VValue(object object_0)
	{
		Value = object_0;
	}

	public override void WriteTo(VdfWriter vdfWriter_0)
	{
		vdfWriter_0.WriteValue(this);
	}

	public override string ToString()
	{
		object value = Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0032;
			}
		}
		obj = string.Empty;
		goto IL_0032;
		IL_0032:
		return (string)obj;
	}
}
