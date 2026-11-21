using System;
using System.IO;
using System.Text;

namespace Nini.Ini;

public class IniWriter : IDisposable
{
	private int m_StructDecorator;

	private bool merchantDecorator;

	private IniWriteState _CallbackDecorator;

	private char m_DecoratorDecorator = ';';

	private char m_ProcessDecorator = '=';

	private TextWriter threadDecorator;

	private string ruleDecorator = "\r\n";

	private StringBuilder collectionDecorator = new StringBuilder();

	private Stream m_InstanceDecorator;

	private bool objectDecorator;

	public int Indentation
	{
		get
		{
			return m_StructDecorator;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Negative values are illegal");
			}
			m_StructDecorator = value;
			collectionDecorator.Remove(0, collectionDecorator.Length);
			for (int i = 0; i < value; i++)
			{
				collectionDecorator.Append(' ');
			}
		}
	}

	public bool UseValueQuotes
	{
		get
		{
			return merchantDecorator;
		}
		set
		{
			merchantDecorator = value;
		}
	}

	public IniWriteState WriteState => _CallbackDecorator;

	public char CommentDelimiter
	{
		get
		{
			return m_DecoratorDecorator;
		}
		set
		{
			m_DecoratorDecorator = value;
		}
	}

	public char AssignDelimiter
	{
		get
		{
			return m_ProcessDecorator;
		}
		set
		{
			m_ProcessDecorator = value;
		}
	}

	public Stream BaseStream => m_InstanceDecorator;

	public IniWriter(string string_0)
		: this(new FileStream(string_0, FileMode.Create, FileAccess.Write, FileShare.None))
	{
	}

	public IniWriter(TextWriter textWriter_0)
	{
		threadDecorator = textWriter_0;
		if (textWriter_0 is StreamWriter streamWriter)
		{
			m_InstanceDecorator = streamWriter.BaseStream;
		}
	}

	public IniWriter(Stream stream_0)
		: this(new StreamWriter(stream_0))
	{
	}

	public void Close()
	{
		threadDecorator.Close();
		_CallbackDecorator = IniWriteState.Closed;
	}

	public void Flush()
	{
		threadDecorator.Flush();
	}

	public override string ToString()
	{
		return threadDecorator.ToString();
	}

	public void WriteSection(string string_0)
	{
		DisableDecorator();
		_CallbackDecorator = IniWriteState.Section;
		PrepareDecorator("[" + string_0 + "]");
	}

	public void WriteSection(string string_0, string string_1)
	{
		DisableDecorator();
		_CallbackDecorator = IniWriteState.Section;
		PrepareDecorator("[" + string_0 + "]" + UpdateDecorator(string_1));
	}

	public void WriteKey(string string_0, string string_1)
	{
		ReadDecorator();
		PrepareDecorator(string_0 + " " + m_ProcessDecorator + " " + CompareDecorator(string_1));
	}

	public void WriteKey(string string_0, string string_1, string string_2)
	{
		ReadDecorator();
		PrepareDecorator(string_0 + " " + m_ProcessDecorator + " " + CompareDecorator(string_1) + UpdateDecorator(string_2));
	}

	public void WriteEmpty()
	{
		DisableDecorator();
		if (_CallbackDecorator == IniWriteState.Start)
		{
			_CallbackDecorator = IniWriteState.BeforeFirstSection;
		}
		PrepareDecorator("");
	}

	public void WriteEmpty(string string_0)
	{
		DisableDecorator();
		if (_CallbackDecorator == IniWriteState.Start)
		{
			_CallbackDecorator = IniWriteState.BeforeFirstSection;
		}
		if (string_0 == null)
		{
			PrepareDecorator("");
		}
		else
		{
			PrepareDecorator(m_DecoratorDecorator + " " + string_0);
		}
	}

	public void Dispose()
	{
		Dispose(bool_0: true);
	}

	protected virtual void Dispose(bool bool_0)
	{
		if (!objectDecorator)
		{
			if (threadDecorator != null)
			{
				threadDecorator.Close();
			}
			if (m_InstanceDecorator != null)
			{
				m_InstanceDecorator.Close();
			}
			objectDecorator = true;
			if (bool_0)
			{
				GC.SuppressFinalize(this);
			}
		}
	}

	~IniWriter()
	{
		Dispose(bool_0: false);
	}

	private string CompareDecorator(string string_0)
	{
		if (merchantDecorator)
		{
			return ReflectDecorator("\"" + string_0 + "\"");
		}
		return ReflectDecorator(string_0);
	}

	private void ReadDecorator()
	{
		DisableDecorator();
		switch (_CallbackDecorator)
		{
		case IniWriteState.Closed:
			throw new InvalidOperationException("The writer is closed");
		case IniWriteState.Start:
		case IniWriteState.BeforeFirstSection:
			throw new InvalidOperationException("The WriteState is not Section");
		}
	}

	private void DisableDecorator()
	{
		if (_CallbackDecorator == IniWriteState.Closed)
		{
			throw new InvalidOperationException("The writer is closed");
		}
	}

	private string UpdateDecorator(string string_0)
	{
		if (string_0 == null)
		{
			return "";
		}
		return " " + m_DecoratorDecorator + " " + string_0;
	}

	private void InsertDecorator(string string_0)
	{
		threadDecorator.Write(collectionDecorator.ToString() + string_0);
	}

	private void PrepareDecorator(string string_0)
	{
		InsertDecorator(string_0 + ruleDecorator);
	}

	private string ReflectDecorator(string string_0)
	{
		return string_0.Replace("\n", "");
	}
}
