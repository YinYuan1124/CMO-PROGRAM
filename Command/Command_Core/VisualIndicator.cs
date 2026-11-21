using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class VisualIndicator
{
	public Control ContainingControl;

	public bool Animation_IsShrinkink;

	public int Animation_CurrentStep;

	private ToolStripItem procProxy;

	private Control _StructReader;

	private ToolStrip m_MerchantReader;

	public string AnchorType;

	public bool SubmenuHighlight;

	public Color RetaindedElementColor;

	public Color DrawColor;

	public VisualIndicatorDesign DesignShape;

	public float LifeTime;

	public DateTime TimeStamp;

	public Rectangle Bounds;

	public bool Activated;

	public List<VisualIndicator> ChildIndicators;

	public Module_Unit.Unit TargetUnit;

	public VisualIndicator(Control control_0, Module_Unit.Unit unit_0, bool bool_0 = true, Color color_0 = default(Color))
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "UnitTracking";
		if (bool_0)
		{
			DesignShape = VisualIndicatorDesign.AnimatedCircle;
		}
		else
		{
			DesignShape = VisualIndicatorDesign.StaticCircle;
		}
		TargetUnit = unit_0;
		DrawColor = color_0;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Activated = true;
		ContainingControl = control_0;
	}

	public VisualIndicator(ToolStripItem toolStripItem_0, VisualIndicatorDesign visualIndicatorDesign_0, Color color_0, bool bool_0, Control control_0)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "ToolStripItem";
		procProxy = toolStripItem_0;
		DesignShape = visualIndicatorDesign_0;
		DrawColor = color_0;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = procProxy.Bounds;
		Activated = true;
		SubmenuHighlight = bool_0;
		RetaindedElementColor = toolStripItem_0.BackColor;
		ContainingControl = control_0;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(Control control_0, VisualIndicatorDesign visualIndicatorDesign_0, Color color_0, bool bool_0, Control control_1)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "Control";
		_StructReader = control_0;
		DesignShape = visualIndicatorDesign_0;
		DrawColor = color_0;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = _StructReader.Bounds;
		Activated = true;
		SubmenuHighlight = bool_0;
		RetaindedElementColor = control_0.BackColor;
		ContainingControl = control_1;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(ToolStrip toolStrip_0, VisualIndicatorDesign visualIndicatorDesign_0, Color color_0, Control control_0)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "ToolStrip";
		m_MerchantReader = toolStrip_0;
		DesignShape = visualIndicatorDesign_0;
		DrawColor = color_0;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = m_MerchantReader.Bounds;
		RetaindedElementColor = toolStrip_0.BackColor;
		ContainingControl = control_0;
		Activated = true;
		RefreshSubMenuHighlight();
	}

	public VisualIndicator(Point point_0, Size size_0, Color color_0, Control control_0, VisualIndicatorDesign visualIndicatorDesign_0 = VisualIndicatorDesign.AnimatedCircle)
	{
		LifeTime = -1f;
		Activated = true;
		ChildIndicators = new List<VisualIndicator>();
		AnchorType = "None";
		DesignShape = visualIndicatorDesign_0;
		DrawColor = color_0;
		if (DrawColor.IsEmpty)
		{
			DrawColor = Color.Red;
		}
		Bounds = new Rectangle(point_0, size_0);
		ContainingControl = control_0;
		Activated = true;
	}

	public void RefreshSubMenuHighlight()
	{
		if (!SubmenuHighlight && DesignShape != VisualIndicatorDesign.Highlight)
		{
			return;
		}
		if (Operators.CompareString(AnchorType, "ToolStripItem", TextCompare: false) == 0)
		{
			if (Activated)
			{
				procProxy.BackColor = DrawColor;
			}
			else
			{
				procProxy.BackColor = DrawColor;
			}
		}
		else if (Operators.CompareString(AnchorType, "Control", TextCompare: false) == 0)
		{
			if (Activated)
			{
				_StructReader.BackColor = DrawColor;
			}
			else
			{
				_StructReader.BackColor = DrawColor;
			}
		}
		else if (Operators.CompareString(AnchorType, "ToolStrip", TextCompare: false) == 0)
		{
			if (Activated)
			{
				m_MerchantReader.BackColor = DrawColor;
			}
			else
			{
				m_MerchantReader.BackColor = DrawColor;
			}
		}
	}

	internal Size SelectReponse()
	{
		if (Operators.CompareString(AnchorType, "ToolStripItem", TextCompare: false) == 0)
		{
			return procProxy.Size;
		}
		if (Operators.CompareString(AnchorType, "Control", TextCompare: false) == 0)
		{
			return _StructReader.Size;
		}
		Size result = default(Size);
		if (Operators.CompareString(AnchorType, "ToolStrip", TextCompare: false) == 0)
		{
			IEnumerator enumerator = null;
			int num = 0;
			try
			{
				enumerator = m_MerchantReader.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ToolStripItem toolStripItem = (ToolStripItem)RuntimeHelpers.GetObjectValue(enumerator.Current);
					num += toolStripItem.Width;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			result = new Size(num, m_MerchantReader.Height);
		}
		else if (Operators.CompareString(AnchorType, "None", TextCompare: false) == 0)
		{
			return Bounds.Size;
		}
		return result;
	}

	internal bool CallReponse()
	{
		if (SubmenuHighlight)
		{
			RefreshSubMenuHighlight();
			return false;
		}
		if (Operators.CompareString(AnchorType, "ToolStripItem", TextCompare: false) == 0)
		{
			return procProxy.Visible;
		}
		if (Operators.CompareString(AnchorType, "Control", TextCompare: false) == 0)
		{
			return _StructReader.Visible;
		}
		if (Operators.CompareString(AnchorType, "ToolStrip", TextCompare: false) == 0)
		{
			return m_MerchantReader.Visible;
		}
		return true;
	}

	internal Point LogoutReponse()
	{
		if (Operators.CompareString(AnchorType, "ToolStripItem", TextCompare: false) == 0)
		{
			Point location = procProxy.Bounds.Location;
			Point location2 = procProxy.GetCurrentParent().Bounds.Location;
			return new Point(location.X + location2.X, location.Y + location2.Y);
		}
		if (Operators.CompareString(AnchorType, "Control", TextCompare: false) == 0)
		{
			Point point_ = default(Point);
			GetCumulativeOffset(_StructReader, ref point_);
			return _StructReader.Location;
		}
		if (Operators.CompareString(AnchorType, "ToolStrip", TextCompare: false) == 0)
		{
			return m_MerchantReader.Location;
		}
		if (Operators.CompareString(AnchorType, "None", TextCompare: false) == 0)
		{
			return Bounds.Location;
		}
		return default(Point);
	}

	public void GetCumulativeOffset(Control control_0, ref Point point_0)
	{
		if (control_0.Parent == null)
		{
			point_0.Offset(control_0.PointToScreen(default(Point)));
			return;
		}
		point_0.Offset(control_0.Location);
		GetCumulativeOffset(control_0.Parent, ref point_0);
	}
}
