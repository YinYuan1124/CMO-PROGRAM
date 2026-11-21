using System;
using System.Runtime.CompilerServices;

namespace Gameloop.Vdf.Linq;

public sealed class VProperty : VToken
{
	[CompilerGenerated]
	private string connectionProcess;

	public string string_0
	{
		[CompilerGenerated]
		get
		{
			return connectionProcess;
		}
		[CompilerGenerated]
		set
		{
			connectionProcess = value;
		}
	}

	public new VToken Value { get; set; }

	public VProperty()
	{
	}

	public VProperty(string string_0, VToken vtoken_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("key");
		}
		this.string_0 = string_0;
		Value = vtoken_0;
	}

	public override void WriteTo(VdfWriter vdfWriter_0)
	{
		vdfWriter_0.WriteKey(string_0);
		Value.WriteTo(vdfWriter_0);
	}
}
