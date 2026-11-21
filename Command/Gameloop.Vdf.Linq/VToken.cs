using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Command.Watchers;
using OpenDis.Pages;

namespace Gameloop.Vdf.Linq;

public abstract class VToken : IVEnumerable<VToken>, IEnumerable<VToken>, IEnumerable, IDynamicMetaObjectProvider
{
	[CompilerGenerated]
	private VToken statusProcess;

	public VToken Parent
	{
		[CompilerGenerated]
		get
		{
			return statusProcess;
		}
		[CompilerGenerated]
		internal set
		{
			statusProcess = value;
		}
	}

	public VToken Previous { get; internal set; }

	public VToken Next { get; internal set; }

	IVEnumerable<VToken> IVEnumerable<VToken>.this[object object_0] => this[object_0];

	public virtual VToken this[object object_0]
	{
		get
		{
			throw new InvalidOperationException($"Cannot access child value on {GetType()}.");
		}
		set
		{
			throw new InvalidOperationException($"Cannot set child value on {GetType()}.");
		}
	}

	public abstract void WriteTo(VdfWriter vdfWriter_0);

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<VToken>)this).GetEnumerator();
	}

	IEnumerator<VToken> IEnumerable<VToken>.GetEnumerator()
	{
		return Children().GetEnumerator();
	}

	public virtual T Value<T>(object object_0)
	{
		VToken vToken = this[object_0];
		if (vToken == null)
		{
			return default(T);
		}
		return vToken.StartThread<VToken, T>();
	}

	public virtual IEnumerable<VProperty> Children()
	{
		return Enumerable.Empty<VProperty>();
	}

	public IEnumerable<T> Children<T>() where T : VToken
	{
		return Children().OfType<T>();
	}

	protected virtual DynamicMetaObject GetMetaObject(Expression expression_0)
	{
		return new WatcherRuleWatcher<VToken>(expression_0, this, new ManagerPage<VToken>());
	}

	DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
	{
		return GetMetaObject(parameter);
	}

	public override string ToString()
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		VdfTextWriter vdfWriter_ = new VdfTextWriter(stringWriter);
		WriteTo(vdfWriter_);
		return stringWriter.ToString();
	}
}
