using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace GodSharp.Sockets;

public class SocketAggregateException : Exception
{
	[CompilerGenerated]
	private ICollection<Exception> predicateDecorator;

	[CompilerGenerated]
	private readonly ReadOnlyCollection<Exception> m_SingletonDecorator;

	public int Count
	{
		get
		{
			if (InnerExceptions == null)
			{
				return 0;
			}
			return InnerExceptions.Count;
		}
	}

	public ReadOnlyCollection<Exception> InnerExceptions
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonDecorator;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ICollection<Exception> method_0()
	{
		return predicateDecorator;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(ICollection<Exception> icollection_0)
	{
		predicateDecorator = icollection_0;
	}

	public SocketAggregateException()
	{
	}

	public SocketAggregateException(string string_0)
		: this(string_0, (Exception[])null)
	{
	}

	public SocketAggregateException(string string_0, params Exception[] exceptions)
		: base(string_0)
	{
		if (exceptions != null && exceptions.Length != 0)
		{
			m_SingletonDecorator = new ReadOnlyCollection<Exception>(exceptions);
		}
	}
}
