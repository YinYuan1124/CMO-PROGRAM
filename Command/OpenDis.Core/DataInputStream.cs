using System;

namespace OpenDis.Core;

public class DataInputStream
{
	private DataStream itemCallback;

	public Endian Endian
	{
		get
		{
			return itemCallback.Endian;
		}
		set
		{
			itemCallback.Endian = value;
		}
	}

	public DataInputStream()
		: this(Endian.Little)
	{
	}

	public DataInputStream(Endian endian_0)
	{
		itemCallback = new DataStream();
		itemCallback.StreamCounter = 0;
		Endian = endian_0;
	}

	public DataInputStream(byte[] byte_0, Endian endian_0)
		: this(endian_0)
	{
		itemCallback.StreamByteArray = byte_0;
		itemCallback.Endian = endian_0;
	}

	public byte ReadByte()
	{
		byte result = itemCallback.StreamByteArray[itemCallback.StreamCounter];
		itemCallback.StreamCounter++;
		return result;
	}

	public byte[] ReadByteArray(int int_0)
	{
		byte[] result = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, int_0);
		itemCallback.StreamCounter += int_0;
		return result;
	}

	public double ReadDouble()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		double result = BitConverter.ToDouble(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public float ReadFloat()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		float result = BitConverter.ToSingle(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public int ReadInt()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		int result = BitConverter.ToInt32(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public long ReadLong()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		long result = BitConverter.ToInt64(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public short ReadShort()
	{
		int num = 2;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 2);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		short result = BitConverter.ToInt16(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public byte ReadUnsignedByte()
	{
		return ReadByte();
	}

	public uint ReadUnsignedInt()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		uint result = BitConverter.ToUInt32(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public ulong ReadUnsignedLong()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		ulong result = BitConverter.ToUInt64(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}

	public ushort ReadUnsignedShort()
	{
		int num = 2;
		byte[] array = DataStream.ReturnByteArray(itemCallback.StreamByteArray, itemCallback.StreamCounter, 2);
		if (Endian == Endian.Big)
		{
			Array.Reverse(array);
		}
		ushort result = BitConverter.ToUInt16(array, 0);
		itemCallback.StreamCounter += num;
		return result;
	}
}
