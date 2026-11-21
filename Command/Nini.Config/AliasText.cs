using System;
using System.Collections;

namespace Nini.Config;

public class AliasText
{
	private Hashtable parameterDecorator;

	private Hashtable _ExpressionDecorator;

	public AliasText()
	{
		parameterDecorator = TestDecorator();
		_ExpressionDecorator = TestDecorator();
		VisitDecorator();
	}

	public void AddAlias(string string_0, string string_1, int int_0)
	{
		if (parameterDecorator.Contains(string_0))
		{
			((Hashtable)parameterDecorator[string_0])[string_1] = int_0;
			return;
		}
		Hashtable hashtable = TestDecorator();
		hashtable[string_1] = int_0;
		parameterDecorator.Add(string_0, hashtable);
	}

	public void AddAlias(string string_0, bool bool_0)
	{
		_ExpressionDecorator[string_0] = bool_0;
	}

	public void AddAlias(string string_0, Enum enum_0)
	{
		RestartDecorator(string_0, enum_0);
	}

	public bool ContainsBoolean(string string_0)
	{
		return _ExpressionDecorator.Contains(string_0);
	}

	public bool ContainsInt(string string_0, string string_1)
	{
		bool result = false;
		if (parameterDecorator.Contains(string_0))
		{
			result = ((Hashtable)parameterDecorator[string_0]).Contains(string_1);
		}
		return result;
	}

	public bool GetBoolean(string string_0)
	{
		if (!_ExpressionDecorator.Contains(string_0))
		{
			throw new ArgumentException("Alias does not exist for text");
		}
		return (bool)_ExpressionDecorator[string_0];
	}

	public int GetInt(string string_0, string string_1)
	{
		if (parameterDecorator.Contains(string_0))
		{
			Hashtable hashtable = (Hashtable)parameterDecorator[string_0];
			if (!hashtable.Contains(string_1))
			{
				throw new ArgumentException("Config value does not match a supplied alias");
			}
			return (int)hashtable[string_1];
		}
		throw new ArgumentException("Alias does not exist for key");
	}

	private void VisitDecorator()
	{
		AddAlias("true", bool_0: true);
		AddAlias("false", bool_0: false);
	}

	private void RestartDecorator(string string_0, Enum enum_0)
	{
		string[] names = Enum.GetNames(enum_0.GetType());
		int[] array = (int[])Enum.GetValues(enum_0.GetType());
		for (int i = 0; i < names.Length; i++)
		{
			AddAlias(string_0, names[i], array[i]);
		}
	}

	private Hashtable TestDecorator()
	{
		return new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
	}
}
