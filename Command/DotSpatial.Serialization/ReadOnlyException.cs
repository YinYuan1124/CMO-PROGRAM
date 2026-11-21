using System;
using DotSpatial.Serialization.Properties;

namespace DotSpatial.Serialization;

public class ReadOnlyException : ApplicationException
{
	public ReadOnlyException()
		: base(Resources.ReadOnly)
	{
	}

	public ReadOnlyException(string string_0)
		: base(string_0)
	{
	}
}
