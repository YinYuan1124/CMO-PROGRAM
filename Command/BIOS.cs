using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using SmartAssembly.Attributes;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
internal class BIOS : BaseWin32Entity
{
	[CompilerGenerated]
	private IEnumerable<BiosCharacteristics> _Object;

	[CompilerGenerated]
	private string parameter;

	public string SerialNumber
	{
		[CompilerGenerated]
		get
		{
			return parameter;
		}
		[CompilerGenerated]
		private set
		{
			parameter = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public IEnumerable<BiosCharacteristics> NewStruct()
	{
		return _Object;
	}

	[SpecialName]
	[CompilerGenerated]
	private void PushStruct(IEnumerable<BiosCharacteristics> ienumerable_0)
	{
		_Object = ienumerable_0;
	}

	public BIOS(ManagementBaseObject managementBaseObject_0)
		: base(managementBaseObject_0)
	{
		ushort[] source = (ushort[])managementBaseObject_0["BiosCharacteristics"];
		PushStruct(source.Select((ushort c) => (BiosCharacteristics)c).ToArray());
		SerialNumber = MoveStruct<string>(managementBaseObject_0, "SerialNumber");
		if (!string.IsNullOrEmpty(SerialNumber))
		{
			SerialNumber = SerialNumber.ToLower();
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(CustomizeStruct());
		foreach (BiosCharacteristics item in NewStruct())
		{
			string name = Enum.GetName(typeof(BiosCharacteristics), item);
			stringBuilder.AppendLine(name);
		}
		return stringBuilder.ToString();
	}
}
