namespace Gameloop.Vdf;

public static class VdfStructure
{
	public const char Quote = '"';

	public const char Escape = '\\';

	public const char Comment = '/';

	public const char Assign = ' ';

	public const char Indent = '\t';

	public const char ConditionalStart = '[';

	public const char ConditionalEnd = ']';

	public const char ObjectStart = '{';

	public const char ObjectEnd = '}';

	public const string string_0 = "$X360";

	public const string ConditionalWin32 = "$WIN32";

	public const string ConditionalWindows = "$WINDOWS";

	public const string ConditionalOSX = "$OSX";

	public const string ConditionalLinux = "$LINUX";

	public const string ConditionalPosix = "$POSIX";

	private static readonly bool[] _RequestProcess;

	private static readonly char[] m_ValueProcess;

	private static readonly char[] _TokenizerProcess;

	private static readonly char[,] stubProcess;

	static VdfStructure()
	{
		stubProcess = new char[11, 2]
		{
			{ '\n', 'n' },
			{ '\t', 't' },
			{ '\v', 'v' },
			{ '\b', 'b' },
			{ '\r', 'r' },
			{ '\f', 'f' },
			{ '\a', 'a' },
			{ '\\', '\\' },
			{ '?', '?' },
			{ '\'', '\'' },
			{ '"', '"' }
		};
		_RequestProcess = new bool[128];
		m_ValueProcess = new char[128];
		_TokenizerProcess = new char[128];
		for (int i = 0; (long)i < 128L; i++)
		{
			char[] valueProcess = m_ValueProcess;
			int num = i;
			valueProcess[num] = (_TokenizerProcess[i] = (char)i);
		}
		for (int j = 0; j < stubProcess.GetLength(0); j++)
		{
			char c2 = stubProcess[j, 0];
			char c3 = stubProcess[j, 1];
			_RequestProcess[(uint)c2] = true;
			m_ValueProcess[(uint)c2] = c3;
			_TokenizerProcess[(uint)c3] = c2;
		}
	}

	public static bool IsEscapable(char char_0)
	{
		if ((uint)char_0 < 128u)
		{
			return _RequestProcess[(uint)char_0];
		}
		return false;
	}

	public static char GetEscape(char char_0)
	{
		if ((uint)char_0 < 128u)
		{
			return m_ValueProcess[(uint)char_0];
		}
		return char_0;
	}

	public static char GetUnescape(char char_0)
	{
		if ((uint)char_0 < 128u)
		{
			return _TokenizerProcess[(uint)char_0];
		}
		return char_0;
	}
}
