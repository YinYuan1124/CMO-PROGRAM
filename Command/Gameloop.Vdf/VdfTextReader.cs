using System;
using System.IO;

namespace Gameloop.Vdf;

public sealed class VdfTextReader : VdfReader
{
	private readonly TextReader writerProcess;

	private readonly char[] _SpecificationProcess;

	private readonly char[] m_WatcherProcess;

	private int reponseProcess;

	private int m_DescriptorProcess;

	private int poolProcess;

	private bool _TaskProcess;

	public VdfTextReader(TextReader textReader_0)
		: this(textReader_0, VdfSerializerSettings.Default)
	{
	}

	public VdfTextReader(TextReader textReader_0, VdfSerializerSettings vdfSerializerSettings_0)
		: base(vdfSerializerSettings_0)
	{
		if (textReader_0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		writerProcess = textReader_0;
		_SpecificationProcess = new char[1024];
		m_WatcherProcess = new char[4096];
		m_DescriptorProcess = 0;
		reponseProcess = 0;
		poolProcess = 0;
		_TaskProcess = false;
	}

	public override bool ReadToken()
	{
		if (ChangeThread())
		{
			poolProcess = 0;
			while (true)
			{
				if (CheckThread())
				{
					char c = _SpecificationProcess[reponseProcess];
					switch (c)
					{
					case '\\':
						m_WatcherProcess[poolProcess++] = (base.Settings.UsesEscapeSequences ? VdfStructure.GetUnescape(_SpecificationProcess[++reponseProcess]) : c);
						reponseProcess++;
						continue;
					default:
						if (!_TaskProcess && char.IsWhiteSpace(c))
						{
							break;
						}
						if (c != '{' && c != '}')
						{
							m_WatcherProcess[poolProcess++] = c;
							reponseProcess++;
							continue;
						}
						if (_TaskProcess)
						{
							m_WatcherProcess[poolProcess++] = c;
							reponseProcess++;
							continue;
						}
						if (poolProcess == 0)
						{
							base.Value = c.ToString();
							base.CurrentState = State.Object;
							reponseProcess++;
							return true;
						}
						base.Value = new string(m_WatcherProcess, 0, poolProcess);
						base.CurrentState = State.Property;
						return true;
					case '"':
						break;
					}
					break;
				}
				return false;
			}
			base.Value = new string(m_WatcherProcess, 0, poolProcess);
			base.CurrentState = State.Property;
			reponseProcess++;
			return true;
		}
		return false;
	}

	private bool ChangeThread()
	{
		while (true)
		{
			if (CheckThread())
			{
				if (char.IsWhiteSpace(_SpecificationProcess[reponseProcess]))
				{
					reponseProcess++;
					continue;
				}
				if (_SpecificationProcess[reponseProcess] != '"')
				{
					if (_SpecificationProcess[reponseProcess] != '/')
					{
						break;
					}
					InitThread();
					reponseProcess++;
					continue;
				}
				_TaskProcess = true;
				reponseProcess++;
				return true;
			}
			return false;
		}
		_TaskProcess = false;
		return true;
	}

	private bool InitThread()
	{
		do
		{
			if (!CheckThread())
			{
				return false;
			}
		}
		while (_SpecificationProcess[++reponseProcess] != '\n');
		return true;
	}

	private bool CheckThread()
	{
		if (reponseProcess < m_DescriptorProcess - 1)
		{
			return true;
		}
		int num = m_DescriptorProcess - reponseProcess;
		_SpecificationProcess[0] = _SpecificationProcess[(m_DescriptorProcess - 1) * num];
		m_DescriptorProcess = writerProcess.Read(_SpecificationProcess, num, 1024 - num) + num;
		reponseProcess = 0;
		return m_DescriptorProcess != 0;
	}

	public override void Close()
	{
		base.Close();
		if (base.CloseInput)
		{
			writerProcess.Dispose();
		}
	}
}
