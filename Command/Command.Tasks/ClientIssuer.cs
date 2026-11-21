using System;
using System.Diagnostics;
using System.IO;
using BitMiracle.LibTiff.Classic;

namespace Command.Tasks;

internal class ClientIssuer : TiffErrorHandler
{
	public override void ErrorHandler(Tiff tiff_0, string string_0, string string_1, params object[] ap)
	{
		_ = Debugger.IsAttached;
		using TextWriter textWriter = Console.Out;
		if (string_0 != null)
		{
			textWriter.Write("{0}: ", string_0);
		}
		textWriter.Write(string_1, ap);
		textWriter.Write(".\n");
	}

	public override void WarningHandler(Tiff tiff_0, string string_0, string string_1, params object[] ap)
	{
	}
}
