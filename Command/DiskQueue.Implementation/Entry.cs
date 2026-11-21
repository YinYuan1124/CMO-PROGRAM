using System;
using System.Runtime.CompilerServices;

namespace DiskQueue.Implementation;

public sealed class Entry : IEquatable<Entry>
{
	[CompilerGenerated]
	private byte[] m_TokenizerObject;

	[CompilerGenerated]
	private int m_StubObject;

	[CompilerGenerated]
	private int writerObject;

	public byte[] Data
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerObject;
		}
		[CompilerGenerated]
		set
		{
			m_TokenizerObject = value;
		}
	}

	public int FileNumber
	{
		[CompilerGenerated]
		get
		{
			return m_StubObject;
		}
		[CompilerGenerated]
		set
		{
			m_StubObject = value;
		}
	}

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return writerObject;
		}
		[CompilerGenerated]
		set
		{
			writerObject = value;
		}
	}

	public int Length { get; set; }

	public Entry(int int_0, int int_1, int int_2)
	{
		FileNumber = int_0;
		Start = int_1;
		Length = int_2;
	}

	public Entry(Operation operation_0)
		: this(operation_0.FileNumber, operation_0.Start, operation_0.Length)
	{
	}

	public bool Equals(Entry other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (other.FileNumber == FileNumber && other.Start == Start)
		{
			return other.Length == Length;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as Entry);
	}

	public override int GetHashCode()
	{
		return (((FileNumber * 397) ^ Start) * 397) ^ Length;
	}

	public static bool operator ==(Entry entry_0, Entry entry_1)
	{
		return object.Equals(entry_0, entry_1);
	}

	public static bool operator !=(Entry entry_0, Entry entry_1)
	{
		return !object.Equals(entry_0, entry_1);
	}
}
