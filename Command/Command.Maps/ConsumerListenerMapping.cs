using System.IO;
using System.Text;
using Aced.Compression;
using Command_Core;
using LZ4;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command.Maps;

[StandardModule]
internal sealed class ConsumerListenerMapping
{
	internal static MemoryTributary GetImporter(Stream stream_0, CompressionLevel compressionLevel_0)
	{
		MemoryTributary memoryTributary = new MemoryTributary();
		SevenZipCompressor sevenZipCompressor = new SevenZipCompressor();
		sevenZipCompressor.CompressionMethod = CompressionMethod.Lzma;
		sevenZipCompressor.CompressionLevel = compressionLevel_0;
		sevenZipCompressor.CompressStream(stream_0, memoryTributary, GameGeneral.m_StructDic);
		return memoryTributary;
	}

	internal static byte[] WriteImporter(object object_0, AcedCompressionLevel acedCompressionLevel_0)
	{
		byte[] array = new byte[(int)((Stream)object_0).Length + 1];
		if ((object)object_0.GetType() == typeof(MemoryStream))
		{
			array = ((MemoryStream)object_0).ToArray();
		}
		else if ((object)object_0.GetType() == typeof(MemoryStream))
		{
			array = ((MemoryStream)object_0).GetBuffer();
		}
		byte[] result = new AcedDeflator().Compress(array, 0, array.Length, acedCompressionLevel_0, 0, 0);
		array = null;
		return result;
	}

	public static string NewImporter(byte[] byte_0)
	{
		AcedInflator acedInflator = new AcedInflator();
		byte[] array = new byte[byte_0.Length + 1];
		array = byte_0;
		byte[] bytes = acedInflator.Decompress(array, 0, 0, 0);
		array = null;
		string @string = Encoding.UTF8.GetString(bytes);
		bytes = null;
		return @string;
	}

	internal static MemoryTributary PushImporter(Stream stream_0)
	{
		MemoryTributary memoryTributary = new MemoryTributary();
		LZ4Stream val = new LZ4Stream(memoryTributary, LZ4StreamMode.Compress, LZ4StreamFlags.IsolateInnerStream);
		stream_0.Seek(0L, SeekOrigin.Begin);
		stream_0.CopyTo(val);
		((Stream)val).Close();
		return memoryTributary;
	}
}
