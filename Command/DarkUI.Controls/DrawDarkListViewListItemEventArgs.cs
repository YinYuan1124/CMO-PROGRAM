using System;
using System.Drawing;

namespace DarkUI.Controls;

public sealed class DrawDarkListViewListItemEventArgs : EventArgs
{
	public int m_index;

	public Rectangle m_rect;

	public DarkListItem m_item;

	public Graphics m_graphics;

	public bool m_selected;
}
