using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class IconItem : UserControl
{
	private IContainer _ContainerContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button")]
	private Button _ComposerContainer;

	public IconeCustomizer ParentCustomizer;

	public string IconFile;

	internal virtual Button Button
	{
		[CompilerGenerated]
		get
		{
			return _ComposerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveIterator;
			Button composerContainer = _ComposerContainer;
			if (composerContainer != null)
			{
				composerContainer.Click -= value2;
			}
			_ComposerContainer = value;
			composerContainer = _ComposerContainer;
			if (composerContainer != null)
			{
				composerContainer.Click += value2;
			}
		}
	}

	public IconItem()
	{
		InterruptIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ContainerContainer != null)
			{
				_ContainerContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InterruptIterator()
	{
		Button = new Button();
		SuspendLayout();
		Button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button.BackgroundImage = Resources.Aircraft;
		Button.BackgroundImageLayout = ImageLayout.Stretch;
		Button.FlatStyle = FlatStyle.Flat;
		Button.Location = new Point(0, 0);
		Button.Name = "Button";
		Button.Size = new Size(40, 40);
		Button.TabIndex = 0;
		Button.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(Button);
		base.Name = "IconItem";
		base.Size = new Size(40, 40);
		ResumeLayout(performLayout: false);
	}

	private void RemoveIterator(object sender, EventArgs e)
	{
		ParentCustomizer.CurrentIconSelected = IconFile;
	}

	public void Refresh(string string_0, IconeCustomizer iconeCustomizer_0)
	{
		IconFile = string_0;
		ParentCustomizer = iconeCustomizer_0;
		Button.BackgroundImage = Image.FromFile(Client.GetCustomIconPath(IconFile));
	}
}
