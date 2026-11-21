using System;
using System.Runtime.CompilerServices;

namespace Gameloop.Vdf;

public abstract class VdfReader : IDisposable
{
	protected internal enum State
	{
		Start,
		Property,
		Object,
		Conditional,
		Finished,
		Closed
	}

	protected const int MaximumTokenSize = 4096;

	[CompilerGenerated]
	private readonly VdfSerializerSettings importerProcess;

	[CompilerGenerated]
	private bool repositoryProcess;

	[CompilerGenerated]
	private string m_BridgeProcess;

	[CompilerGenerated]
	private State m_InvocationProcess;

	public VdfSerializerSettings Settings
	{
		[CompilerGenerated]
		get
		{
			return importerProcess;
		}
	}

	public bool CloseInput
	{
		[CompilerGenerated]
		get
		{
			return repositoryProcess;
		}
		[CompilerGenerated]
		set
		{
			repositoryProcess = value;
		}
	}

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeProcess;
		}
		[CompilerGenerated]
		set
		{
			m_BridgeProcess = value;
		}
	}

	protected internal State CurrentState
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationProcess;
		}
		[CompilerGenerated]
		protected set
		{
			m_InvocationProcess = value;
		}
	}

	protected VdfReader()
		: this(VdfSerializerSettings.Default)
	{
	}

	protected VdfReader(VdfSerializerSettings vdfSerializerSettings_0)
	{
		importerProcess = vdfSerializerSettings_0;
		CurrentState = State.Start;
		Value = null;
		CloseInput = true;
	}

	public abstract bool ReadToken();

	void IDisposable.Dispose()
	{
		if (CurrentState != State.Closed)
		{
			Close();
		}
	}

	public virtual void Close()
	{
		CurrentState = State.Closed;
		Value = null;
	}
}
