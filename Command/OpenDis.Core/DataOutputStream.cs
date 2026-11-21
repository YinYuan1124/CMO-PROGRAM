using System;
using OpenDis.Dis1998;

namespace OpenDis.Core;

public class DataOutputStream
{
	private DataStream setterCallback;

	public DataStream DS => setterCallback;

	public Endian Endian
	{
		get
		{
			return DS.Endian;
		}
		set
		{
			DS.Endian = value;
		}
	}

	public DataOutputStream(DataStream dataStream_0, Endian endian_0)
	{
		setterCallback = dataStream_0;
		Endian = endian_0;
	}

	public DataOutputStream()
		: this(Endian.Little)
	{
	}

	public DataOutputStream(Endian endian_0)
	{
		setterCallback = new DataStream();
		Endian = endian_0;
	}

	public byte[] ConvertToBytes(Pdu pdu_0)
	{
		byte[] array = new byte[pdu_0.Length];
		byte[] array2 = DS.ConvertToBytes();
		for (int i = 0; i < array2.Length; i++)
		{
			array[i] = array2[i];
		}
		return array;
	}

	public void WriteByte(byte byte_0)
	{
		LogoutDecorator(byte_0);
	}

	public void WriteByte(byte[] byte_0)
	{
		ViewDecorator(byte_0);
	}

	public void WriteDouble(double double_0)
	{
		byte[] bytes = BitConverter.GetBytes(double_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteFloat(float float_0)
	{
		byte[] bytes = BitConverter.GetBytes(float_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteInt(int int_0)
	{
		byte[] bytes = BitConverter.GetBytes(int_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteLong(long long_0)
	{
		byte[] bytes = BitConverter.GetBytes(long_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteShort(short short_0)
	{
		byte[] bytes = BitConverter.GetBytes(short_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteUnsignedByte(byte byte_0)
	{
		LogoutDecorator(byte_0);
	}

	public void WriteUnsignedByte(byte[] byte_0)
	{
		ViewDecorator(byte_0);
	}

	public void WriteUnsignedInt(uint uint_0)
	{
		byte[] bytes = BitConverter.GetBytes(uint_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteUnsignedLong(ulong ulong_0)
	{
		byte[] bytes = BitConverter.GetBytes(ulong_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	public void WriteUnsignedShort(ushort ushort_0)
	{
		byte[] bytes = BitConverter.GetBytes(ushort_0);
		if (Endian == Endian.Big)
		{
			Array.Reverse(bytes);
		}
		ViewDecorator(bytes);
	}

	private void LogoutDecorator(byte byte_0)
	{
		setterCallback.Append(byte_0);
		setterCallback.StreamCounter++;
	}

	private void ViewDecorator(byte[] byte_0)
	{
		setterCallback.Append(byte_0);
		setterCallback.StreamCounter += byte_0.Length;
	}
}
