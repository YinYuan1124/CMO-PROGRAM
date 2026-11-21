using System.Drawing;
using System.Runtime.CompilerServices;
using DarkUI.Docking;

namespace OpenDis.Candidates;

internal class TokenCallbackCandidate
{
	[CompilerGenerated]
	private DarkDockPanel m_InterpreterParameter;

	[CompilerGenerated]
	private DockInsertType m_ContainerParameter;

	[CompilerGenerated]
	private Rectangle composerParameter;

	[CompilerGenerated]
	private Rectangle _ModelParameter;

	[CompilerGenerated]
	private DarkDockRegion advisorParameter;

	[CompilerGenerated]
	private DarkDockGroup _CustomerParameter;

	[SpecialName]
	[CompilerGenerated]
	internal DarkDockPanel CalculateConfig()
	{
		return m_InterpreterParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void PopConfig(DarkDockPanel darkDockPanel_0)
	{
		m_InterpreterParameter = darkDockPanel_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Rectangle CreateConfig()
	{
		return composerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void CompareConfig(Rectangle rectangle_0)
	{
		composerParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Rectangle DisableConfig()
	{
		return _ModelParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void UpdateConfig(Rectangle rectangle_0)
	{
		_ModelParameter = rectangle_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DarkDockRegion PrepareConfig()
	{
		return advisorParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void ReflectConfig(DarkDockRegion darkDockRegion_0)
	{
		advisorParameter = darkDockRegion_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DarkDockGroup RestartConfig()
	{
		return _CustomerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void TestConfig(DarkDockGroup darkDockGroup_0)
	{
		_CustomerParameter = darkDockGroup_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DockInsertType CancelConfig()
	{
		return m_ContainerParameter;
	}

	[SpecialName]
	[CompilerGenerated]
	private void VerifyConfig(DockInsertType dockInsertType_0)
	{
		m_ContainerParameter = dockInsertType_0;
	}

	internal TokenCallbackCandidate(DarkDockPanel darkDockPanel_0, DarkDockRegion darkDockRegion_0)
	{
		PopConfig(darkDockPanel_0);
		ReflectConfig(darkDockRegion_0);
		VerifyConfig(DockInsertType.None);
		FindConfig();
	}

	internal TokenCallbackCandidate(DarkDockPanel darkDockPanel_0, DarkDockGroup darkDockGroup_0, DockInsertType dockInsertType_0)
	{
		PopConfig(darkDockPanel_0);
		TestConfig(darkDockGroup_0);
		VerifyConfig(dockInsertType_0);
		FindConfig();
	}

	internal void FindConfig()
	{
		if (PrepareConfig() == null)
		{
			if (RestartConfig() != null)
			{
				FillConfig();
			}
		}
		else
		{
			SetConfig();
		}
	}

	private void SetConfig()
	{
		switch (PrepareConfig().DockArea)
		{
		case DarkDockArea.Left:
		{
			Rectangle rectangle3 = default(Rectangle);
			rectangle3.X = CalculateConfig().PointToScreen(Point.Empty).X;
			rectangle3.Y = CalculateConfig().PointToScreen(Point.Empty).Y;
			rectangle3.Width = 50;
			rectangle3.Height = CalculateConfig().Height;
			Rectangle rectangle_2;
			CompareConfig(rectangle_2 = rectangle3);
			UpdateConfig(rectangle_2);
			break;
		}
		case DarkDockArea.Right:
		{
			Rectangle rectangle2 = default(Rectangle);
			rectangle2.X = CalculateConfig().PointToScreen(Point.Empty).X + CalculateConfig().Width - 50;
			rectangle2.Y = CalculateConfig().PointToScreen(Point.Empty).Y;
			rectangle2.Width = 50;
			rectangle2.Height = CalculateConfig().Height;
			Rectangle rectangle_3;
			CompareConfig(rectangle_3 = rectangle2);
			UpdateConfig(rectangle_3);
			break;
		}
		case DarkDockArea.Bottom:
		{
			int num = CalculateConfig().PointToScreen(Point.Empty).X;
			int num2 = CalculateConfig().Width;
			if (CalculateConfig().Regions[DarkDockArea.Left].Visible)
			{
				num += CalculateConfig().Regions[DarkDockArea.Left].Width;
				num2 -= CalculateConfig().Regions[DarkDockArea.Left].Width;
			}
			if (CalculateConfig().Regions[DarkDockArea.Right].Visible)
			{
				num2 -= CalculateConfig().Regions[DarkDockArea.Right].Width;
			}
			Rectangle rectangle = default(Rectangle);
			rectangle.X = num;
			rectangle.Y = CalculateConfig().PointToScreen(Point.Empty).Y + CalculateConfig().Height - 50;
			rectangle.Width = num2;
			rectangle.Height = 50;
			Rectangle rectangle_;
			CompareConfig(rectangle_ = rectangle);
			UpdateConfig(rectangle_);
			break;
		}
		}
	}

	private void FillConfig()
	{
		switch (CancelConfig())
		{
		case DockInsertType.None:
		{
			Rectangle rectangle2 = default(Rectangle);
			rectangle2.X = RestartConfig().PointToScreen(Point.Empty).X;
			rectangle2.Y = RestartConfig().PointToScreen(Point.Empty).Y;
			rectangle2.Width = RestartConfig().Width;
			rectangle2.Height = RestartConfig().Height;
			Rectangle rectangle_2;
			CompareConfig(rectangle_2 = rectangle2);
			UpdateConfig(rectangle_2);
			break;
		}
		case DockInsertType.Before:
		{
			int width = RestartConfig().Width;
			int height = RestartConfig().Height;
			switch (RestartConfig().DockArea)
			{
			case DarkDockArea.Bottom:
				width = RestartConfig().Width / 4;
				break;
			case DarkDockArea.Left:
			case DarkDockArea.Right:
				height = RestartConfig().Height / 4;
				break;
			}
			Rectangle rectangle3 = default(Rectangle);
			rectangle3.X = RestartConfig().PointToScreen(Point.Empty).X;
			rectangle3.Y = RestartConfig().PointToScreen(Point.Empty).Y;
			rectangle3.Width = width;
			rectangle3.Height = height;
			Rectangle rectangle_3;
			CompareConfig(rectangle_3 = rectangle3);
			UpdateConfig(rectangle_3);
			break;
		}
		case DockInsertType.After:
		{
			int x = RestartConfig().PointToScreen(Point.Empty).X;
			int y = RestartConfig().PointToScreen(Point.Empty).Y;
			int num = RestartConfig().Width;
			int num2 = RestartConfig().Height;
			switch (RestartConfig().DockArea)
			{
			case DarkDockArea.Bottom:
				num = RestartConfig().Width / 4;
				x = RestartConfig().PointToScreen(Point.Empty).X + RestartConfig().Width - num;
				break;
			case DarkDockArea.Left:
			case DarkDockArea.Right:
				num2 = RestartConfig().Height / 4;
				y = RestartConfig().PointToScreen(Point.Empty).Y + RestartConfig().Height - num2;
				break;
			}
			Rectangle rectangle = default(Rectangle);
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = num;
			rectangle.Height = num2;
			Rectangle rectangle_;
			CompareConfig(rectangle_ = rectangle);
			UpdateConfig(rectangle_);
			break;
		}
		}
	}
}
