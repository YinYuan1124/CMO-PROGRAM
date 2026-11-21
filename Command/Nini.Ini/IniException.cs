using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Nini.Ini;

[Serializable]
public class IniException : SystemException
{
	private IniReader iniReader;

	private string message = "";

	public int LinePosition
	{
		get
		{
			if (iniReader == null)
			{
				return 0;
			}
			return iniReader.LinePosition;
		}
	}

	public int LineNumber
	{
		get
		{
			if (iniReader == null)
			{
				return 0;
			}
			return iniReader.LineNumber;
		}
	}

	public override string Message
	{
		get
		{
			if (iniReader == null)
			{
				return base.Message;
			}
			return string.Format(CultureInfo.InvariantCulture, "{0} - Line: {1}, Position: {2}.", message, LineNumber, LinePosition);
		}
	}

	public IniException()
	{
		message = "An error has occurred";
	}

	public IniException(string string_0, Exception exception_0)
		: base(string_0, exception_0)
	{
	}

	public IniException(string string_0)
		: base(string_0)
	{
		message = string_0;
	}

	internal IniException(IniReader iniReader_0, string string_0)
		: this(string_0)
	{
		iniReader = iniReader_0;
		message = string_0;
	}

	protected IniException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		: base(serializationInfo_0, streamingContext_0)
	{
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		if (iniReader != null)
		{
			info.AddValue("lineNumber", iniReader.LineNumber);
			info.AddValue("linePosition", iniReader.LinePosition);
		}
	}
}
