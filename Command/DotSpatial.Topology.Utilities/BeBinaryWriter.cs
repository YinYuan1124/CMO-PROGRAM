using System;
using System.IO;
using System.Text;

namespace DotSpatial.Topology.Utilities;

public class BeBinaryWriter : BinaryWriter
{
	public BeBinaryWriter()
	{
	}

	public BeBinaryWriter(Stream stream_0)
		: base(stream_0)
	{
	}

	public BeBinaryWriter(Stream stream_0, Encoding encoding_0)
		: base(stream_0, encoding_0)
	{
	}

	public override void Write(short value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes, 0, 2);
		Write(bytes);
	}

	public override void Write(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes, 0, 4);
		Write(bytes);
	}

	public override void Write(long value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes, 0, 8);
		Write(bytes);
	}

	public override void Write(float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes, 0, 4);
		Write(bytes);
	}

	public override void Write(double value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes, 0, 8);
		Write(bytes);
	}

	public override void Write(string value)
	{
		throw new NotImplementedException();
	}

	public override void Write(decimal value)
	{
		throw new NotImplementedException();
	}
}
