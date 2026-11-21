using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.IO;

public sealed class MemoryTributary : Stream
{
	[CompilerGenerated]
	private long callbackCallback;

	protected long length;

	protected long blockSize = 65536L;

	protected List<byte[]> blocks = new List<byte[]>();

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => true;

	public override long Length => length;

	public override long Position
	{
		[CompilerGenerated]
		get
		{
			return callbackCallback;
		}
		[CompilerGenerated]
		set
		{
			callbackCallback = value;
		}
	}

	protected byte[] block
	{
		get
		{
			while (blocks.Count <= blockId)
			{
				blocks.Add(new byte[blockSize]);
			}
			return blocks[(int)blockId];
		}
	}

	protected long blockId => Position / blockSize;

	protected long blockOffset => Position % blockSize;

	public MemoryTributary()
	{
		Position = 0L;
	}

	public MemoryTributary(byte[] byte_0)
	{
		Write(byte_0, 0, byte_0.Length);
		Position = 0L;
	}

	public MemoryTributary(int int_0)
	{
		SetLength(int_0);
		Position = int_0;
		_ = block;
		Position = 0L;
	}

	public override void Flush()
	{
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		long num = count;
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException("count", num, "Number of bytes to copy cannot be negative.");
		}
		long num2 = length - Position;
		if (num > num2)
		{
			num = num2;
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer", "Buffer cannot be null.");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", offset, "Destination offset cannot be negative.");
		}
		int num3 = 0;
		long num4 = 0L;
		do
		{
			num4 = Math.Min(num, blockSize - blockOffset);
			Buffer.BlockCopy(block, (int)blockOffset, buffer, offset, (int)num4);
			num -= num4;
			offset += (int)num4;
			num3 += (int)num4;
			Position += num4;
		}
		while (num > 0);
		return num3;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		switch (origin)
		{
		case SeekOrigin.Begin:
			Position = offset;
			break;
		case SeekOrigin.Current:
			Position += offset;
			break;
		case SeekOrigin.End:
			Position = Length - offset;
			break;
		}
		return Position;
	}

	public override void SetLength(long value)
	{
		length = value;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		long position = Position;
		try
		{
			do
			{
				int num = Math.Min(count, (int)(blockSize - blockOffset));
				EnsureCapacity(Position + num);
				Buffer.BlockCopy(buffer, offset, block, (int)blockOffset, num);
				count -= num;
				offset += num;
				Position += num;
			}
			while (count > 0);
		}
		catch (Exception ex)
		{
			Position = position;
			throw ex;
		}
	}

	public override int ReadByte()
	{
		if (Position < length)
		{
			byte result = block[blockOffset];
			Position++;
			return result;
		}
		return -1;
	}

	public override void WriteByte(byte value)
	{
		EnsureCapacity(Position + 1);
		block[blockOffset] = value;
		Position++;
	}

	protected void EnsureCapacity(long long_0)
	{
		if (long_0 > length)
		{
			length = long_0;
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public byte[] ToArray()
	{
		long position = Position;
		Position = 0L;
		byte[] array = new byte[Length];
		Read(array, 0, (int)Length);
		Position = position;
		return array;
	}

	public void ReadFrom(Stream stream_0, long long_0)
	{
		byte[] buffer = new byte[4096];
		do
		{
			int num = stream_0.Read(buffer, 0, (int)Math.Min(4096L, long_0));
			long_0 -= num;
			Write(buffer, 0, num);
		}
		while (long_0 > 0);
	}

	public void WriteTo(Stream stream_0)
	{
		long position = Position;
		Position = 0L;
		CopyTo(stream_0);
		Position = position;
	}
}
