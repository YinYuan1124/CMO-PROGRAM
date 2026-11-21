namespace Nini.Config;

public class IniConfig : ConfigBase
{
	private IniConfigSource m_StubDecorator;

	public IniConfig(string string_0, IConfigSource iconfigSource_0)
		: base(string_0, iconfigSource_0)
	{
		m_StubDecorator = (IniConfigSource)iconfigSource_0;
	}

	public override string Get(string string_0)
	{
		if (!m_StubDecorator.CaseSensitive)
		{
			string_0 = RevertDecorator(string_0);
		}
		return base.Get(string_0);
	}

	public override void Set(string string_0, object object_0)
	{
		if (!m_StubDecorator.CaseSensitive)
		{
			string_0 = RevertDecorator(string_0);
		}
		base.Set(string_0, object_0);
	}

	public override void Remove(string string_0)
	{
		if (!m_StubDecorator.CaseSensitive)
		{
			string_0 = RevertDecorator(string_0);
		}
		base.Remove(string_0);
	}

	private string RevertDecorator(string string_0)
	{
		string text = null;
		string text2 = string_0.ToLower();
		foreach (string key in keys.Keys)
		{
			if (key.ToLower() == text2)
			{
				text = key;
				break;
			}
		}
		if (text == null)
		{
			return string_0;
		}
		return text;
	}
}
