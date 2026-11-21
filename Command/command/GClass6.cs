using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class GClass6 : INotifyPropertyChanged
{
	[CompilerGenerated]
	private double facadeResolver;

	[CompilerGenerated]
	private double proxyResolver;

	[CompilerGenerated]
	private double readerResolver;

	[CompilerGenerated]
	private double _PropertyResolver;

	[CompilerGenerated]
	private double m_ImporterResolver;

	[CompilerGenerated]
	private double m_RepositoryResolver;

	[CompilerGenerated]
	private string _BridgeResolver;

	[CompilerGenerated]
	private string _InvocationResolver;

	[CompilerGenerated]
	private object classResolver;

	[CompilerGenerated]
	private double _RequestResolver;

	[CompilerGenerated]
	private double m_ValueResolver;

	[CompilerGenerated]
	private double tokenizerResolver;

	[CompilerGenerated]
	private bool m_StubResolver;

	[CompilerGenerated]
	private Color _WriterResolver;

	[CompilerGenerated]
	private double _SpecificationResolver;

	[CompilerGenerated]
	private double watcherResolver;

	[CompilerGenerated]
	private double reponseResolver;

	[CompilerGenerated]
	private double _DescriptorResolver;

	[CompilerGenerated]
	private double poolResolver;

	[CompilerGenerated]
	private double taskResolver;

	[NonSerialized]
	private PropertyChangedEventHandler filterResolver;

	public double CanvasLeft
	{
		[CompilerGenerated]
		get
		{
			return facadeResolver;
		}
		[CompilerGenerated]
		set
		{
			if (facadeResolver != value)
			{
				facadeResolver = value;
				OnPropertyChanged("CanvasLeft");
			}
		}
	}

	public double CanvasTop
	{
		[CompilerGenerated]
		get
		{
			return proxyResolver;
		}
		[CompilerGenerated]
		set
		{
			if (proxyResolver != value)
			{
				proxyResolver = value;
				OnPropertyChanged("CanvasTop");
			}
		}
	}

	public double StemCanvasLeft
	{
		[CompilerGenerated]
		get
		{
			return readerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (readerResolver != value)
			{
				readerResolver = value;
				OnPropertyChanged("StemCanvasLeft");
			}
		}
	}

	public double StemCanvasTop
	{
		[CompilerGenerated]
		get
		{
			return _PropertyResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_PropertyResolver != value)
			{
				_PropertyResolver = value;
				OnPropertyChanged("StemCanvasTop");
			}
		}
	}

	public double ObservedHeight
	{
		[CompilerGenerated]
		get
		{
			return m_ImporterResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_ImporterResolver != value)
			{
				m_ImporterResolver = value;
				OnPropertyChanged("ObservedHeight");
			}
		}
	}

	public double ObservedWidth
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_RepositoryResolver != value)
			{
				m_RepositoryResolver = value;
				OnPropertyChanged("ObservedWidth");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _BridgeResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_BridgeResolver, value, StringComparison.Ordinal))
			{
				_BridgeResolver = value;
				OnPropertyChanged("Text");
			}
		}
	}

	public string Summary
	{
		[CompilerGenerated]
		get
		{
			return _InvocationResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_InvocationResolver, value, StringComparison.Ordinal))
			{
				_InvocationResolver = value;
				OnPropertyChanged("Summary");
			}
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return classResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(classResolver, value))
			{
				classResolver = RuntimeHelpers.GetObjectValue(value);
				OnPropertyChanged("Tag");
			}
		}
	}

	public double Lat
	{
		[CompilerGenerated]
		get
		{
			return _RequestResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_RequestResolver != value)
			{
				_RequestResolver = value;
				OnPropertyChanged("Lat");
			}
		}
	}

	public double Lon
	{
		[CompilerGenerated]
		get
		{
			return m_ValueResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_ValueResolver != value)
			{
				m_ValueResolver = value;
				OnPropertyChanged("Lon");
			}
		}
	}

	public double Opacity
	{
		[CompilerGenerated]
		get
		{
			return tokenizerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (tokenizerResolver != value)
			{
				tokenizerResolver = value;
				OnPropertyChanged("Opacity");
			}
		}
	}

	public bool Hover
	{
		[CompilerGenerated]
		get
		{
			return m_StubResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_StubResolver != value)
			{
				m_StubResolver = value;
				OnPropertyChanged("Hover");
			}
		}
	}

	public Color Color
	{
		[CompilerGenerated]
		get
		{
			return _WriterResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_WriterResolver != value)
			{
				_WriterResolver = value;
				OnPropertyChanged("Color");
			}
		}
	}

	public double X1
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_SpecificationResolver != value)
			{
				_SpecificationResolver = value;
				OnPropertyChanged("X1");
			}
		}
	}

	public double X2
	{
		[CompilerGenerated]
		get
		{
			return watcherResolver;
		}
		[CompilerGenerated]
		set
		{
			if (watcherResolver != value)
			{
				watcherResolver = value;
				OnPropertyChanged("X2");
			}
		}
	}

	public double Y1
	{
		[CompilerGenerated]
		get
		{
			return reponseResolver;
		}
		[CompilerGenerated]
		set
		{
			if (reponseResolver != value)
			{
				reponseResolver = value;
				OnPropertyChanged("Y1");
			}
		}
	}

	public double Y2
	{
		[CompilerGenerated]
		get
		{
			return _DescriptorResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_DescriptorResolver != value)
			{
				_DescriptorResolver = value;
				OnPropertyChanged("Y2");
			}
		}
	}

	public double Radius
	{
		[CompilerGenerated]
		get
		{
			return poolResolver;
		}
		[CompilerGenerated]
		set
		{
			if (poolResolver != value)
			{
				poolResolver = value;
				OnPropertyChanged("Radius");
			}
		}
	}

	public double Theta
	{
		[CompilerGenerated]
		get
		{
			return taskResolver;
		}
		[CompilerGenerated]
		set
		{
			if (taskResolver != value)
			{
				taskResolver = value;
				OnPropertyChanged("Theta");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = filterResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref filterResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = filterResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref filterResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		filterResolver?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
