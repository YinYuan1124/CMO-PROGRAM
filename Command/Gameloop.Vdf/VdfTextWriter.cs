using System;
using System.IO;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public sealed class VdfTextWriter : VdfWriter
{
	private readonly TextWriter m_FilterProcess;

	private int m_TestsProcess;

	public VdfTextWriter(TextWriter textWriter_0)
		: this(textWriter_0, VdfSerializerSettings.Default)
	{
	}

	public VdfTextWriter(TextWriter textWriter_0, VdfSerializerSettings vdfSerializerSettings_0)
		: base(vdfSerializerSettings_0)
	{
		if (textWriter_0 == null)
		{
			throw new ArgumentNullException("writer");
		}
		m_FilterProcess = textWriter_0;
		m_TestsProcess = 0;
	}

	public override void WriteKey(string string_0)
	{
		ConcatThread(State.Key);
		m_FilterProcess.Write('"');
		InterruptThread(string_0);
		m_FilterProcess.Write('"');
	}

	public override void WriteValue(VValue vvalue_0)
	{
		ConcatThread(State.Value);
		m_FilterProcess.Write('"');
		InterruptThread(vvalue_0.ToString());
		m_FilterProcess.Write('"');
	}

	public override void WriteObjectStart()
	{
		ConcatThread(State.ObjectStart);
		m_FilterProcess.Write('{');
		m_TestsProcess++;
	}

	public override void WriteObjectEnd()
	{
		m_TestsProcess--;
		ConcatThread(State.ObjectEnd);
		m_FilterProcess.Write('}');
		if (m_TestsProcess == 0)
		{
			ConcatThread(State.Finished);
		}
	}

	private void ConcatThread(State state_0)
	{
		if (base.state_0 == State.Start)
		{
			base.state_0 = state_0;
			return;
		}
		switch (state_0)
		{
		case State.Value:
			m_FilterProcess.Write(' ');
			break;
		case State.Key:
		case State.ObjectStart:
		case State.ObjectEnd:
			m_FilterProcess.WriteLine();
			m_FilterProcess.Write(new string('\t', m_TestsProcess));
			break;
		case State.Finished:
			m_FilterProcess.WriteLine();
			break;
		}
		base.state_0 = state_0;
	}

	private void InterruptThread(string string_0)
	{
		if (base.vdfSerializerSettings.UsesEscapeSequences)
		{
			foreach (char c in string_0)
			{
				if (VdfStructure.IsEscapable(c))
				{
					m_FilterProcess.Write('\\');
					m_FilterProcess.Write(VdfStructure.GetEscape(c));
				}
				else
				{
					m_FilterProcess.Write(c);
				}
			}
		}
		else
		{
			m_FilterProcess.Write(string_0);
		}
	}

	public override void Close()
	{
		base.Close();
		if (base.bool_0)
		{
			m_FilterProcess.Dispose();
		}
	}
}
