using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace OpenDis.Core;

public class DataStream : IDisposable
{
	private Endian creatorCallback;

	[CompilerGenerated]
	private MemoryStream templateCallback;

	public Endian Endian
	{
		get
		{
			return creatorCallback;
		}
		set
		{
			creatorCallback = value;
		}
	}

	public MemoryStream Stream
	{
		[CompilerGenerated]
		get
		{
			return templateCallback;
		}
		[CompilerGenerated]
		set
		{
			templateCallback = value;
		}
	}

	public byte[] StreamByteArray { get; set; }

	public int StreamCounter { get; set; }

	public DataStream()
	{
		creatorCallback = (BitConverter.IsLittleEndian ? Endian.Little : Endian.Big);
		Stream = new MemoryStream();
	}

	public void Append(byte[] byte_0)
	{
		Stream.Seek(Stream.Length, SeekOrigin.Begin);
		Stream.Write(byte_0, 0, byte_0.Length);
	}

	public void Append(byte byte_0)
	{
		Stream.Seek(Stream.Length, SeekOrigin.Begin);
		Stream.WriteByte(byte_0);
	}

	public void Clear()
	{
		StreamCounter = 0;
		Stream = new MemoryStream();
	}

	public byte[] ConvertToBytes()
	{
		return ReturnByteArray(Stream.GetBuffer(), 0, (int)Stream.Length);
	}

	public void Dispose()
	{
		if (Stream != null)
		{
			try
			{
				Stream.Close();
				Stream.Dispose();
			}
			catch
			{
			}
		}
	}

	public static byte[] ReturnByteArray(byte[] byte_0, int int_0, int int_1)
	{
		byte[] array = new byte[int_1];
		Array.Copy(byte_0, int_0, array, 0, int_1);
		return array;
	}
}
