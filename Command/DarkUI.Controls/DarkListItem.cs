using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkListItem
{
	[CompilerGenerated]
	private EventHandler configExpression;

	private string registryExpression;

	[CompilerGenerated]
	private Color m_ValExpression;

	[CompilerGenerated]
	private FontStyle wrapperExpression;

	[CompilerGenerated]
	private object m_IssuerExpression;

	public string Text
	{
		get
		{
			return registryExpression;
		}
		set
		{
			registryExpression = value;
			if (configExpression != null)
			{
				configExpression(this, new EventArgs());
			}
		}
	}

	public Rectangle Area { get; set; }

	public Color TextColor
	{
		[CompilerGenerated]
		get
		{
			return m_ValExpression;
		}
		[CompilerGenerated]
		set
		{
			m_ValExpression = value;
		}
	}

	public FontStyle FontStyle
	{
		[CompilerGenerated]
		get
		{
			return wrapperExpression;
		}
		[CompilerGenerated]
		set
		{
			wrapperExpression = value;
		}
	}

	public Bitmap Icon { get; set; }

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerExpression;
		}
		[CompilerGenerated]
		set
		{
			m_IssuerExpression = value;
		}
	}

	public event EventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = configExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref configExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = configExpression;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref configExpression, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkListItem()
	{
		TextColor = Colors.LightText;
		FontStyle = FontStyle.Regular;
	}

	public DarkListItem(string string_0)
		: this()
	{
		Text = string_0;
	}
}
