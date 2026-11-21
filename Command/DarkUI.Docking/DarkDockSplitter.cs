using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using OpenDis.Database;

namespace DarkUI.Docking;

public sealed class DarkDockSplitter
{
	private Control m_ConfigParameter;

	private Control _RegistryParameter;

	private DarkSplitterType definitionParameter;

	private int m_ValParameter;

	private int _WrapperParameter;

	private ValueDecoratorEntry m_ObserverParameter;

	[CompilerGenerated]
	private Rectangle issuerParameter;

	public Rectangle Bounds
	{
		[CompilerGenerated]
		get
		{
			return issuerParameter;
		}
		[CompilerGenerated]
		set
		{
			issuerParameter = value;
		}
	}

	public Cursor ResizeCursor { get; private set; }

	public DarkDockSplitter(Control control_0, Control control_1, DarkSplitterType darkSplitterType_0)
	{
		m_ConfigParameter = control_0;
		_RegistryParameter = control_1;
		definitionParameter = darkSplitterType_0;
		switch (definitionParameter)
		{
		case DarkSplitterType.Top:
		case DarkSplitterType.Bottom:
			ResizeCursor = Cursors.SizeNS;
			break;
		case DarkSplitterType.Left:
		case DarkSplitterType.Right:
			ResizeCursor = Cursors.SizeWE;
			break;
		}
	}

	public void ShowOverlay()
	{
		m_ObserverParameter = new ValueDecoratorEntry(Color.Black);
		m_ObserverParameter.Visible = true;
		UpdateOverlay(new Point(0, 0));
	}

	public void HideOverlay()
	{
		m_ObserverParameter.Visible = false;
	}

	public void UpdateOverlay(Point point_0)
	{
		Rectangle bounds = new Rectangle(Bounds.Location, Bounds.Size);
		switch (definitionParameter)
		{
		case DarkSplitterType.Left:
		{
			int num2 = Math.Max(bounds.Location.X - point_0.X, m_ValParameter);
			if (_WrapperParameter != 0 && num2 > _WrapperParameter)
			{
				num2 = _WrapperParameter;
			}
			bounds.Location = new Point(num2, bounds.Location.Y);
			break;
		}
		case DarkSplitterType.Right:
		{
			int num3 = Math.Max(bounds.Location.X - point_0.X, m_ValParameter);
			if (_WrapperParameter != 0 && num3 > _WrapperParameter)
			{
				num3 = _WrapperParameter;
			}
			bounds.Location = new Point(num3, bounds.Location.Y);
			break;
		}
		case DarkSplitterType.Top:
		{
			int num4 = Math.Max(bounds.Location.Y - point_0.Y, m_ValParameter);
			if (_WrapperParameter != 0 && num4 > _WrapperParameter)
			{
				num4 = _WrapperParameter;
			}
			bounds.Location = new Point(bounds.Location.X, num4);
			break;
		}
		case DarkSplitterType.Bottom:
		{
			int num = Math.Max(bounds.Location.Y - point_0.Y, m_ValParameter);
			if (_WrapperParameter == 0 || num > _WrapperParameter)
			{
			}
			bounds.Location = new Point(bounds.Location.X, num);
			break;
		}
		}
		m_ObserverParameter.Bounds = bounds;
	}

	public void Move(Point point_0)
	{
		switch (definitionParameter)
		{
		case DarkSplitterType.Left:
			_RegistryParameter.Width += point_0.X;
			break;
		case DarkSplitterType.Right:
			_RegistryParameter.Width -= point_0.X;
			break;
		case DarkSplitterType.Top:
			_RegistryParameter.Height += point_0.Y;
			break;
		case DarkSplitterType.Bottom:
			_RegistryParameter.Height -= point_0.Y;
			break;
		}
		UpdateBounds();
	}

	public void UpdateBounds()
	{
		Rectangle rectangle = m_ConfigParameter.RectangleToScreen(_RegistryParameter.Bounds);
		switch (definitionParameter)
		{
		case DarkSplitterType.Left:
			Bounds = new Rectangle(rectangle.Left - 2, rectangle.Top, 5, rectangle.Height);
			_WrapperParameter = rectangle.Right - 2 - _RegistryParameter.MinimumSize.Width;
			break;
		case DarkSplitterType.Right:
			Bounds = new Rectangle(rectangle.Right - 2, rectangle.Top, 5, rectangle.Height);
			m_ValParameter = rectangle.Left - 2 + _RegistryParameter.MinimumSize.Width;
			break;
		case DarkSplitterType.Top:
			Bounds = new Rectangle(rectangle.Left, rectangle.Top - 2, rectangle.Width, 5);
			_WrapperParameter = rectangle.Bottom - 2 - _RegistryParameter.MinimumSize.Height;
			break;
		case DarkSplitterType.Bottom:
			Bounds = new Rectangle(rectangle.Left, rectangle.Bottom - 2, rectangle.Width, 5);
			m_ValParameter = rectangle.Top - 2 + _RegistryParameter.MinimumSize.Height;
			break;
		}
	}
}
