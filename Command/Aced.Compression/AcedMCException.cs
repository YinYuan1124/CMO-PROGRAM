using System;

namespace Aced.Compression;

public sealed class AcedMCException : Exception
{
	internal static void FlushObserver(string string_0)
	{
		throw new ArgumentNullException(string_0);
	}

	internal static void ForgotObserver()
	{
		throw new AcedMCException("Destination byte array is not enough to store compressed data.");
	}

	internal static void CollectObserver()
	{
		throw new AcedMCException("Destination byte array is not enough to store decompressed data.");
	}

	internal static void OrderObserver()
	{
		throw new AcedMCException("An attempt to read beyond the end of the source byte array.");
	}

	private AcedMCException(string string_0)
		: base(string_0)
	{
	}
}
