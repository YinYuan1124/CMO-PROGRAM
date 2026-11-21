using System;
using System.Globalization;
using System.IO;
using System.Text;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public static class VdfConvert
{
	public static string Serialize(VToken vtoken_0)
	{
		return Serialize(vtoken_0, VdfSerializerSettings.Common);
	}

	public static string Serialize(VToken vtoken_0, VdfSerializerSettings vdfSerializerSettings_0)
	{
		if (vtoken_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		StringWriter stringWriter = new StringWriter(new StringBuilder(256), CultureInfo.InvariantCulture);
		new VdfSerializer(vdfSerializerSettings_0).Serialize(stringWriter, vtoken_0);
		return stringWriter.ToString();
	}

	public static VProperty Deserialize(string string_0)
	{
		return Deserialize(string_0, VdfSerializerSettings.Common);
	}

	public static VProperty Deserialize(string string_0, VdfSerializerSettings vdfSerializerSettings_0)
	{
		return Deserialize(new StringReader(string_0), vdfSerializerSettings_0);
	}

	public static VProperty Deserialize(TextReader textReader_0)
	{
		return Deserialize(textReader_0, VdfSerializerSettings.Common);
	}

	public static VProperty Deserialize(TextReader textReader_0, VdfSerializerSettings vdfSerializerSettings_0)
	{
		if (textReader_0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		return new VdfSerializer(vdfSerializerSettings_0).Deserialize(textReader_0);
	}
}
