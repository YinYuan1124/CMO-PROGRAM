using System;
using System.Drawing;
using System.Text;

namespace Command_Core;

public sealed class RangeSymbol
{
	public enum SymbolType : byte
	{
		Circle = 1,
		Wedge
	}

	public string Description;

	public double RangeNM;

	public float LeftArc;

	public float RightArc;

	public SymbolType Type;

	public Color Color;

	[ThreadStatic]
	private static StringBuilder m_ProducerConsumer;

	public RangeSymbol(SymbolType symbolType_0, string string_0, double double_0, float float_0, float float_1, Color color_0)
	{
		Type = symbolType_0;
		Description = string_0;
		RangeNM = double_0;
		LeftArc = float_0;
		RightArc = float_1;
		Color = color_0;
	}

	public RangeSymbol(SymbolType symbolType_0, string string_0, double double_0, Color color_0)
	{
		Type = symbolType_0;
		Description = string_0;
		RangeNM = double_0;
		Color = color_0;
	}
}
