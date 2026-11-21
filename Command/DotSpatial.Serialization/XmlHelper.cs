using System.Text;

namespace DotSpatial.Serialization;

public static class XmlHelper
{
	public static string EscapeInvalidCharacters(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '&':
				if (RevertExpression(string_0, i))
				{
					stringBuilder.Append(string_0[i]);
				}
				else
				{
					stringBuilder.Append("&amp;");
				}
				break;
			case '"':
				stringBuilder.Append("&quot;");
				break;
			default:
				stringBuilder.Append(string_0[i]);
				break;
			case '>':
				stringBuilder.Append("&gt;");
				break;
			case '<':
				stringBuilder.Append("&lt;");
				break;
			case '\'':
				stringBuilder.Append("&apos;");
				break;
			}
		}
		return stringBuilder.ToString();
	}

	public static string UnEscapeInvalidCharacters(string string_0)
	{
		string_0 = string_0.Replace("&lt;", "<");
		string_0 = string_0.Replace("&gt;", ">");
		string_0 = string_0.Replace("&quot;", "\"");
		string_0 = string_0.Replace("&apos;", "'");
		string_0 = string_0.Replace("&amp;", "&");
		return string_0;
	}

	private static bool RevertExpression(string string_0, int int_0)
	{
		int num = string_0.Length - int_0;
		if (num < 6)
		{
			if (num < 5)
			{
				if (num < 4)
				{
					return false;
				}
				if (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';')
				{
					return true;
				}
				if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
				{
					return string_0[int_0 + 3] == ';';
				}
				return false;
			}
			if ((string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'm' && string_0[int_0 + 3] == 'p' && string_0[int_0 + 4] == ';') || (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';'))
			{
				return true;
			}
			if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
			{
				return string_0[int_0 + 3] == ';';
			}
			return false;
		}
		if ((string_0[int_0 + 1] == 'q' && string_0[int_0 + 2] == 'u' && string_0[int_0 + 3] == 'o' && string_0[int_0 + 4] == 't' && string_0[int_0 + 5] == ';') || (string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'p' && string_0[int_0 + 3] == 'o' && string_0[int_0 + 4] == 's' && string_0[int_0 + 5] == ';') || (string_0[int_0 + 1] == 'a' && string_0[int_0 + 2] == 'm' && string_0[int_0 + 3] == 'p' && string_0[int_0 + 4] == ';') || (string_0[int_0 + 1] == 'l' && string_0[int_0 + 2] == 't' && string_0[int_0 + 3] == ';'))
		{
			return true;
		}
		if (string_0[int_0 + 1] == 'g' && string_0[int_0 + 2] == 't')
		{
			return string_0[int_0 + 3] == ';';
		}
		return false;
	}
}
