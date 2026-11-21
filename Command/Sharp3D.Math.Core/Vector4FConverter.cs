using System;
using System.ComponentModel;
using System.Globalization;

namespace Sharp3D.Math.Core;

public sealed class Vector4FConverter : ExpandableObjectConverter
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
		if (destinationType == typeof(string) && value is Vector4F vector4F)
		{
			return vector4F.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value.GetType() == typeof(string))
		{
			return Vector4F.Parse((string)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return new StandardValuesCollection(new object[5]
		{
			Vector4F.Zero,
			Vector4F.XAxis,
			Vector4F.YAxis,
			Vector4F.ZAxis,
			Vector4F.WAxis
		});
	}
}
