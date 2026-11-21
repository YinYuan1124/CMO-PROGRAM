using System.Drawing;
using System.Runtime.CompilerServices;

namespace DarkUI.Controls;

public sealed class DarkDropdownItem
{
	[CompilerGenerated]
	private Bitmap singletonParameter;

	public string Text { get; set; }

	public string Value { get; set; }

	public Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return singletonParameter;
		}
		[CompilerGenerated]
		set
		{
			singletonParameter = value;
		}
	}

	public DarkDropdownItem()
	{
	}

	public DarkDropdownItem(string string_0)
	{
		Text = string_0;
	}

	public DarkDropdownItem(string string_0, string string_1)
	{
		Text = string_0;
		Value = string_1;
	}

	public DarkDropdownItem(string string_0, Bitmap bitmap_0)
		: this(string_0)
	{
		Icon = bitmap_0;
	}
}
