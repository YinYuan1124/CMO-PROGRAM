using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Nini.Ini;

public class IniDocument
{
	private IniSectionCollection broadcasterCallback = new IniSectionCollection();

	private ArrayList _IdentifierCallback = new ArrayList();

	private IniFileType printerCallback;

	public IniFileType FileType
	{
		get
		{
			return printerCallback;
		}
		set
		{
			printerCallback = value;
		}
	}

	public IniSectionCollection Sections => broadcasterCallback;

	public IniDocument(string string_0)
	{
		printerCallback = IniFileType.Standard;
		Load(string_0);
	}

	public IniDocument(string string_0, IniFileType iniFileType_0)
	{
		printerCallback = iniFileType_0;
		Load(string_0);
	}

	public IniDocument(TextReader textReader_0)
	{
		printerCallback = IniFileType.Standard;
		Load(textReader_0);
	}

	public IniDocument(TextReader textReader_0, IniFileType iniFileType_0)
	{
		printerCallback = iniFileType_0;
		Load(textReader_0);
	}

	public IniDocument(Stream stream_0)
	{
		printerCallback = IniFileType.Standard;
		Load(stream_0);
	}

	public IniDocument(Stream stream_0, IniFileType iniFileType_0)
	{
		printerCallback = iniFileType_0;
		Load(stream_0);
	}

	public IniDocument(IniReader iniReader_0)
	{
		printerCallback = IniFileType.Standard;
		Load(iniReader_0);
	}

	public IniDocument()
	{
	}

	public void Load(string string_0)
	{
		Load(new StreamReader(string_0));
	}

	public void Load(TextReader textReader_0)
	{
		Load(InvokeDecorator(textReader_0, printerCallback));
	}

	public void Load(Stream stream_0)
	{
		Load(new StreamReader(stream_0));
	}

	public void Load(IniReader iniReader_0)
	{
		PushDecorator(iniReader_0);
	}

	public void Save(TextWriter textWriter_0)
	{
		IniWriter iniWriter = SetupDecorator(textWriter_0, printerCallback);
		IniItem iniItem = null;
		IniSection iniSection = null;
		foreach (string item in _IdentifierCallback)
		{
			iniWriter.WriteEmpty(item);
		}
		for (int i = 0; i < broadcasterCallback.Count; i++)
		{
			iniSection = broadcasterCallback[i];
			iniWriter.WriteSection(iniSection.Name, iniSection.Comment);
			for (int j = 0; j < iniSection.ItemCount; j++)
			{
				iniItem = iniSection.GetItem(j);
				if (iniItem.Name == "ConnectionString" && iniItem.Value != null && iniItem.Value.Count() > 0)
				{
					if (iniItem.Value.First() != '"')
					{
						iniItem.Value = "\"" + iniItem.Value;
					}
					if (iniItem.Value.Last() != '"')
					{
						iniItem.Value += "\"";
					}
				}
				switch (iniItem.Type)
				{
				case IniType.Empty:
					iniWriter.WriteEmpty(iniItem.Comment);
					break;
				case IniType.Key:
					iniWriter.WriteKey(iniItem.Name, iniItem.Value, iniItem.Comment);
					break;
				}
			}
		}
		iniWriter.Close();
	}

	public void Save(string string_0)
	{
		StreamWriter streamWriter = new StreamWriter(string_0);
		Save(streamWriter);
		streamWriter.Close();
	}

	public void Save(Stream stream_0)
	{
		Save(new StreamWriter(stream_0));
	}

	private void PushDecorator(IniReader iniReader_0)
	{
		iniReader_0.IgnoreComments = false;
		bool flag = false;
		IniSection iniSection = null;
		try
		{
			while (iniReader_0.Read())
			{
				switch (iniReader_0.Type)
				{
				case IniType.Section:
					flag = true;
					if (broadcasterCallback[iniReader_0.Name] != null)
					{
						broadcasterCallback.Remove(iniReader_0.Name);
					}
					iniSection = new IniSection(iniReader_0.Name, iniReader_0.Comment);
					broadcasterCallback.Add(iniSection);
					break;
				case IniType.Key:
					if (iniSection.GetValue(iniReader_0.Name) == null)
					{
						iniSection.Set(iniReader_0.Name, iniReader_0.Value, iniReader_0.Comment);
					}
					break;
				case IniType.Empty:
					if (flag)
					{
						iniSection.Set(iniReader_0.Comment);
					}
					else
					{
						_IdentifierCallback.Add(iniReader_0.Comment);
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			iniReader_0.Close();
		}
	}

	private IniReader InvokeDecorator(TextReader textReader_0, IniFileType iniFileType_0)
	{
		IniReader iniReader = new IniReader(textReader_0);
		switch (iniFileType_0)
		{
		case IniFileType.PythonStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.SetCommentDelimiters(new char[2] { ';', '#' });
			iniReader.SetAssignDelimiters(new char[1] { ':' });
			break;
		case IniFileType.SambaStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.SetCommentDelimiters(new char[2] { ';', '#' });
			iniReader.LineContinuation = true;
			break;
		case IniFileType.MysqlStyle:
			iniReader.AcceptCommentAfterKey = false;
			iniReader.AcceptNoAssignmentOperator = true;
			iniReader.SetCommentDelimiters(new char[1] { '#' });
			iniReader.SetAssignDelimiters(new char[2] { ':', '=' });
			break;
		case IniFileType.WindowsStyle:
			iniReader.ConsumeAllKeyText = true;
			break;
		}
		return iniReader;
	}

	private IniWriter SetupDecorator(TextWriter textWriter_0, IniFileType iniFileType_0)
	{
		IniWriter iniWriter = new IniWriter(textWriter_0);
		switch (iniFileType_0)
		{
		case IniFileType.SambaStyle:
		case IniFileType.MysqlStyle:
			iniWriter.AssignDelimiter = '=';
			iniWriter.CommentDelimiter = '#';
			break;
		case IniFileType.PythonStyle:
			iniWriter.AssignDelimiter = ':';
			iniWriter.CommentDelimiter = '#';
			break;
		}
		return iniWriter;
	}
}
