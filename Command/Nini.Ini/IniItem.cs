namespace Nini.Ini;

public class IniItem
{
	private IniType _ParserCallback = IniType.Empty;

	private string algoCallback = "";

	private string databaseCallback = "";

	private string _InterceptorCallback;

	public IniType Type
	{
		get
		{
			return _ParserCallback;
		}
		set
		{
			_ParserCallback = value;
		}
	}

	public string Value
	{
		get
		{
			return databaseCallback;
		}
		set
		{
			databaseCallback = value;
		}
	}

	public string Name => algoCallback;

	public string Comment
	{
		get
		{
			return _InterceptorCallback;
		}
		set
		{
			_InterceptorCallback = value;
		}
	}

	protected internal IniItem(string string_0, string string_1, IniType iniType_0, string string_2)
	{
		algoCallback = string_0;
		databaseCallback = string_1;
		_ParserCallback = iniType_0;
		_InterceptorCallback = string_2;
	}
}
