using System.IO;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public sealed class VdfSerializer
{
	private readonly VdfSerializerSettings _ClassProcess;

	public VdfSerializer()
		: this(VdfSerializerSettings.Default)
	{
	}

	public VdfSerializer(VdfSerializerSettings vdfSerializerSettings_0)
	{
		_ClassProcess = vdfSerializerSettings_0;
	}

	public void Serialize(TextWriter textWriter_0, VToken vtoken_0)
	{
		using VdfWriter vdfWriter_ = new VdfTextWriter(textWriter_0, _ClassProcess);
		vtoken_0.WriteTo(vdfWriter_);
	}

	public VProperty Deserialize(TextReader textReader_0)
	{
		using VdfReader vdfReader = new VdfTextReader(textReader_0, _ClassProcess);
		if (!vdfReader.ReadToken())
		{
			throw new VdfException("Incomplete VDF data.");
		}
		return SearchThread(vdfReader);
	}

	private VProperty SearchThread(VdfReader vdfReader_0)
	{
		VProperty vProperty = new VProperty();
		vProperty.string_0 = vdfReader_0.Value;
		if (vdfReader_0.ReadToken())
		{
			if (vdfReader_0.CurrentState == VdfReader.State.Property)
			{
				vProperty.Value = new VValue(vdfReader_0.Value);
			}
			else
			{
				vProperty.Value = EnableThread(vdfReader_0);
			}
			return vProperty;
		}
		throw new VdfException("Incomplete VDF data.");
	}

	private VObject EnableThread(VdfReader vdfReader_0)
	{
		VObject vObject = new VObject();
		if (vdfReader_0.ReadToken())
		{
			while (vdfReader_0.CurrentState != VdfReader.State.Object || vdfReader_0.Value != '}'.ToString())
			{
				vObject.Add(SearchThread(vdfReader_0));
				if (!vdfReader_0.ReadToken())
				{
					throw new VdfException("Incomplete VDF data.");
				}
			}
			return vObject;
		}
		throw new VdfException("Incomplete VDF data.");
	}
}
