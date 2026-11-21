using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Vector2FConverter : ExpandableObjectConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is Vector2F vector2F)
		{
			return vector2F.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value.GetType() == typeof(string))
		{
			return Vector2F.Parse((string)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new object[3]
		{
			Vector2F.Zero,
			Vector2F.XAxis,
			Vector2F.YAxis
		});
	}
}
