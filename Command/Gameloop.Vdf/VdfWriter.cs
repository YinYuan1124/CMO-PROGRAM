using System;
using System.Runtime.CompilerServices;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public abstract class VdfWriter : IDisposable
{
	protected internal enum State
	{
		Start,
		Key,
		Value,
		ObjectStart,
		ObjectEnd,
		Finished,
		Closed
	}

	[CompilerGenerated]
	private bool m_ContainerProcess;

	[CompilerGenerated]
	private State composerProcess;

	public VdfSerializerSettings vdfSerializerSettings { get; }

	public bool bool_0
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerProcess;
		}
		[CompilerGenerated]
		set
		{
			m_ContainerProcess = value;
		}
	}

	protected internal State state_0
	{
		[CompilerGenerated]
		get
		{
			return composerProcess;
		}
		[CompilerGenerated]
		protected set
		{
			composerProcess = value;
		}
	}

	protected VdfWriter()
		: this(VdfSerializerSettings.Default)
	{
	}

	protected VdfWriter(VdfSerializerSettings vdfSerializerSettings_0)
	{
		vdfSerializerSettings = vdfSerializerSettings_0;
		state_0 = State.Start;
		bool_0 = true;
	}

	public abstract void WriteObjectStart();

	public abstract void WriteObjectEnd();

	public abstract void WriteKey(string string_0);

	public abstract void WriteValue(VValue vvalue_0);

	void IDisposable.Dispose()
	{
		if (state_0 != State.Closed)
		{
			Close();
		}
	}

	public virtual void Close()
	{
		state_0 = State.Closed;
	}
}
