using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DarkUI.Collections;

public sealed class ObservableListModified<T> : EventArgs
{
	[CompilerGenerated]
	private IEnumerable<T> processDispatcher;

	public IEnumerable<T> Items
	{
		[CompilerGenerated]
		get
		{
			return processDispatcher;
		}
		[CompilerGenerated]
		private set
		{
			processDispatcher = value;
		}
	}

	public ObservableListModified(IEnumerable<T> ienumerable_0)
	{
		Items = ienumerable_0;
	}
}
