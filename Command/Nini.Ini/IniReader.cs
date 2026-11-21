using System;
using System.IO;
using System.Text;

namespace Nini.Ini;

public class IniReader : IDisposable
{
	private int messageCallback = 1;

	private int _ProductCallback = 1;

	private IniType annotationCallback = IniType.Empty;

	private TextReader iteratorCallback;

	private bool _InitializerCallback;

	private StringBuilder _RoleCallback = new StringBuilder();

	private StringBuilder factoryCallback = new StringBuilder();

	private StringBuilder attributeCallback = new StringBuilder();

	private IniReadState m_EventCallback = IniReadState.Initial;

	private bool m_GlobalCallback;

	private bool workerCallback;

	private bool _AccountCallback;

	private bool _StateCallback = true;

	private bool m_AuthenticationCallback;

	private bool _ParamsCallback;

	private char[] m_InfoCallback = new char[1] { ';' };

	private char[] helperCallback = new char[1] { '=' };

	public string Name => _RoleCallback.ToString();

	public string Value => factoryCallback.ToString();

	public IniType Type => annotationCallback;

	public string Comment
	{
		get
		{
			if (m_GlobalCallback)
			{
				return attributeCallback.ToString();
			}
			return null;
		}
	}

	public int LineNumber => messageCallback;

	public int LinePosition => _ProductCallback;

	public bool IgnoreComments
	{
		get
		{
			return _InitializerCallback;
		}
		set
		{
			_InitializerCallback = value;
		}
	}

	public IniReadState ReadState => m_EventCallback;

	public bool LineContinuation
	{
		get
		{
			return _AccountCallback;
		}
		set
		{
			_AccountCallback = value;
		}
	}

	public bool AcceptCommentAfterKey
	{
		get
		{
			return _StateCallback;
		}
		set
		{
			_StateCallback = value;
		}
	}

	public bool AcceptNoAssignmentOperator
	{
		get
		{
			return m_AuthenticationCallback;
		}
		set
		{
			m_AuthenticationCallback = value;
		}
	}

	public bool ConsumeAllKeyText
	{
		get
		{
			return _ParamsCallback;
		}
		set
		{
			_ParamsCallback = value;
		}
	}

	public IniReader(string string_0)
	{
		iteratorCallback = new StreamReader(string_0);
	}

	public IniReader(TextReader textReader_0)
	{
		iteratorCallback = textReader_0;
	}

	public IniReader(Stream stream_0)
		: this(new StreamReader(stream_0))
	{
	}

	public bool Read()
	{
		bool result = false;
		if (m_EventCallback != IniReadState.EndOfFile || m_EventCallback != 0)
		{
			m_EventCallback = IniReadState.Interactive;
			result = IncludeDecorator();
		}
		return result;
	}

	public bool MoveToNextSection()
	{
		bool flag = false;
		do
		{
			flag = Read();
		}
		while (annotationCallback != IniType.Section && flag);
		return flag;
	}

	public bool MoveToNextKey()
	{
		bool flag = false;
		do
		{
			flag = Read();
			if (annotationCallback == IniType.Section)
			{
				flag = false;
				break;
			}
		}
		while (annotationCallback != IniType.Key && flag);
		return flag;
	}

	public void Close()
	{
		ExcludeDecorator();
		m_EventCallback = IniReadState.Closed;
		if (iteratorCallback != null)
		{
			iteratorCallback.Close();
		}
	}

	public void Dispose()
	{
		Dispose(bool_0: true);
	}

	public char[] GetCommentDelimiters()
	{
		char[] array = new char[m_InfoCallback.Length];
		Array.Copy(m_InfoCallback, 0, array, 0, m_InfoCallback.Length);
		return array;
	}

	public void SetCommentDelimiters(char[] char_0)
	{
		if (char_0.Length < 1)
		{
			throw new ArgumentException("Must supply at least one delimiter");
		}
		m_InfoCallback = char_0;
	}

	public char[] GetAssignDelimiters()
	{
		char[] array = new char[helperCallback.Length];
		Array.Copy(helperCallback, 0, array, 0, helperCallback.Length);
		return array;
	}

	public void SetAssignDelimiters(char[] char_0)
	{
		if (char_0.Length < 1)
		{
			throw new ArgumentException("Must supply at least one delimiter");
		}
		helperCallback = char_0;
	}

	protected virtual void Dispose(bool bool_0)
	{
		if (!workerCallback)
		{
			iteratorCallback.Close();
			workerCallback = true;
			if (bool_0)
			{
				GC.SuppressFinalize(this);
			}
		}
	}

	~IniReader()
	{
		Dispose(bool_0: false);
	}

	private void ExcludeDecorator()
	{
		_RoleCallback.Remove(0, _RoleCallback.Length);
		factoryCallback.Remove(0, factoryCallback.Length);
		attributeCallback.Remove(0, attributeCallback.Length);
		annotationCallback = IniType.Empty;
		m_GlobalCallback = false;
	}

	private bool IncludeDecorator()
	{
		bool result = true;
		int num = FindDecorator();
		ExcludeDecorator();
		if (SetDecorator(num))
		{
			annotationCallback = IniType.Empty;
			RemoveDecorator();
			SearchDecorator();
			return result;
		}
		switch (num)
		{
		case 10:
			RemoveDecorator();
			break;
		case -1:
			m_EventCallback = IniReadState.EndOfFile;
			result = false;
			break;
		default:
			ChangeDecorator();
			break;
		case 91:
			CheckDecorator();
			break;
		case 9:
		case 13:
		case 32:
			InstantiateDecorator();
			IncludeDecorator();
			break;
		}
		return result;
	}

	private void SearchDecorator()
	{
		int num = -1;
		InstantiateDecorator();
		m_GlobalCallback = true;
		do
		{
			num = RemoveDecorator();
			attributeCallback.Append((char)num);
		}
		while (!CreateDecorator(num));
		EnableDecorator(attributeCallback);
	}

	private void EnableDecorator(StringBuilder stringBuilder_0)
	{
		string text = stringBuilder_0.ToString();
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
		stringBuilder_0.Append(text.TrimEnd(null));
	}

	private void ChangeDecorator()
	{
		int num = -1;
		annotationCallback = IniType.Key;
		while (true)
		{
			num = FindDecorator();
			if (!FillDecorator(num))
			{
				if (!CreateDecorator(num))
				{
					_RoleCallback.Append((char)RemoveDecorator());
					continue;
				}
				if (m_AuthenticationCallback)
				{
					break;
				}
				throw new IniException(this, $"Expected assignment operator ({helperCallback[0]})");
			}
			RemoveDecorator();
			break;
		}
		InitDecorator();
		ConcatDecorator();
		EnableDecorator(_RoleCallback);
	}

	private void InitDecorator()
	{
		int num = -1;
		bool flag = false;
		int num2 = 0;
		InstantiateDecorator();
		while (true)
		{
			num = FindDecorator();
			if (!PopDecorator(num))
			{
				num2++;
			}
			if (!ConsumeAllKeyText && num == 34)
			{
				RemoveDecorator();
				if (flag || num2 != 1)
				{
					break;
				}
				flag = true;
				continue;
			}
			if (!flag || !CreateDecorator(num))
			{
				if (_AccountCallback && num == 92)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)RemoveDecorator());
					while (FindDecorator() != 10 && PopDecorator(FindDecorator()))
					{
						if (FindDecorator() == 13)
						{
							RemoveDecorator();
						}
						else
						{
							stringBuilder.Append((char)RemoveDecorator());
						}
					}
					if (FindDecorator() == 10)
					{
						RemoveDecorator();
						continue;
					}
					factoryCallback.Append(stringBuilder.ToString());
				}
				if ((!ConsumeAllKeyText && _StateCallback && SetDecorator(num) && !flag) || CreateDecorator(num))
				{
					break;
				}
				factoryCallback.Append((char)RemoveDecorator());
				continue;
			}
			throw new IniException(this, "Expected closing quote (\")");
		}
		if (!flag)
		{
			EnableDecorator(factoryCallback);
		}
	}

	private void CheckDecorator()
	{
		int num = -1;
		annotationCallback = IniType.Section;
		num = RemoveDecorator();
		while (true)
		{
			num = FindDecorator();
			if (num == 93)
			{
				break;
			}
			if (!CreateDecorator(num))
			{
				_RoleCallback.Append((char)RemoveDecorator());
				continue;
			}
			throw new IniException(this, "Expected section end (])");
		}
		InterruptDecorator();
		EnableDecorator(_RoleCallback);
	}

	private void ConcatDecorator()
	{
		int num = RemoveDecorator();
		while (true)
		{
			if (!CreateDecorator(num))
			{
				if (SetDecorator(num))
				{
					break;
				}
				num = RemoveDecorator();
				continue;
			}
			return;
		}
		if (_InitializerCallback)
		{
			InterruptDecorator();
		}
		else
		{
			SearchDecorator();
		}
	}

	private void InterruptDecorator()
	{
		int num = -1;
		do
		{
			num = RemoveDecorator();
		}
		while (!CreateDecorator(num));
	}

	private int RemoveDecorator()
	{
		int num = iteratorCallback.Read();
		if (num == 10)
		{
			messageCallback++;
			_ProductCallback = 1;
			return num;
		}
		_ProductCallback++;
		return num;
	}

	private int FindDecorator()
	{
		return iteratorCallback.Peek();
	}

	private bool SetDecorator(int int_0)
	{
		return CalculateDecorator(m_InfoCallback, int_0);
	}

	private bool FillDecorator(int int_0)
	{
		return CalculateDecorator(helperCallback, int_0);
	}

	private bool CalculateDecorator(char[] char_0, int int_0)
	{
		bool result = false;
		for (int i = 0; i < char_0.Length; i++)
		{
			if (int_0 == char_0[i])
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private bool PopDecorator(int int_0)
	{
		if (int_0 != 32 && int_0 != 9 && int_0 != 13)
		{
			return int_0 == 10;
		}
		return true;
	}

	private void InstantiateDecorator()
	{
		while (PopDecorator(FindDecorator()) && !CreateDecorator(FindDecorator()))
		{
			RemoveDecorator();
		}
	}

	private bool CreateDecorator(int int_0)
	{
		if (int_0 == 10)
		{
			return true;
		}
		return int_0 == -1;
	}
}
