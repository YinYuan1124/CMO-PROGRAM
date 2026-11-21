using System.Globalization;
using System.Runtime.CompilerServices;

namespace Magic.Samples.DisplaySettings;

public struct DisplaySettings
{
	[CompilerGenerated]
	private int serializerDecorator;

	[CompilerGenerated]
	private int refDecorator;

	[CompilerGenerated]
	private int m_ErrorDecorator;

	[CompilerGenerated]
	private Orientation m_CodeDecorator;

	[CompilerGenerated]
	private int m_ConnectionDecorator;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return serializerDecorator;
		}
		[CompilerGenerated]
		set
		{
			serializerDecorator = value;
		}
	}

	public int Width
	{
		[CompilerGenerated]
		readonly get
		{
			return refDecorator;
		}
		[CompilerGenerated]
		set
		{
			refDecorator = value;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		readonly get
		{
			return m_ErrorDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ErrorDecorator = value;
		}
	}

	public Orientation Orientation
	{
		[CompilerGenerated]
		readonly get
		{
			return m_CodeDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_CodeDecorator = value;
		}
	}

	public int BitCount
	{
		[CompilerGenerated]
		readonly get
		{
			return m_ConnectionDecorator;
		}
		[CompilerGenerated]
		set
		{
			m_ConnectionDecorator = value;
		}
	}

	public int Frequency { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0} by {1}, {2}, {3} Bit, {4} Hertz", Width, Height, (int)Orientation, BitCount, Frequency);
	}
}
