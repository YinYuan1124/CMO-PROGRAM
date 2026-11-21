using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Command;
using DarkUI.Controls;

namespace DarkUI.Forms;

public class DarkMessageBox : DarkDialog
{
	private string printerObject;

	private int _ParserObject = 350;

	private IContainer algoObject;

	private PictureBox _DatabaseObject;

	private DarkLabel _InterceptorObject;

	[DefaultValue(350)]
	[Description("Determines the maximum width of the message box when it autosizes around the displayed message.")]
	public int MaximumWidth
	{
		get
		{
			return _ParserObject;
		}
		set
		{
			_ParserObject = value;
			CallListener();
		}
	}

	public DarkMessageBox()
	{
		LogoutListener();
	}

	public DarkMessageBox(string string_0, string string_1, DarkMessageBoxIcon darkMessageBoxIcon_0, DarkDialogButton darkDialogButton_0)
		: this()
	{
		Text = string_1;
		printerObject = string_0;
		base.DialogButtons = darkDialogButton_0;
		SelectListener(darkMessageBoxIcon_0);
	}

	public DarkMessageBox(string string_0)
		: this(string_0, "Command", DarkMessageBoxIcon.None, DarkDialogButton.Ok)
	{
	}

	public DarkMessageBox(string string_0, string string_1)
		: this(string_0, string_1, DarkMessageBoxIcon.None, DarkDialogButton.Ok)
	{
	}

	public DarkMessageBox(string string_0, string string_1, DarkDialogButton darkDialogButton_0)
		: this(string_0, string_1, DarkMessageBoxIcon.None, darkDialogButton_0)
	{
	}

	public DarkMessageBox(string string_0, string string_1, DarkMessageBoxIcon darkMessageBoxIcon_0)
		: this(string_0, string_1, darkMessageBoxIcon_0, DarkDialogButton.Ok)
	{
	}

	public static DialogResult ShowInformation(string string_0, string string_1, DarkDialogButton darkDialogButton_0 = DarkDialogButton.Ok)
	{
		return PatchListener(string_0, string_1, DarkMessageBoxIcon.Information, darkDialogButton_0);
	}

	public static DialogResult ShowWarning(string string_0, string string_1, DarkDialogButton darkDialogButton_0 = DarkDialogButton.Ok)
	{
		return PatchListener(string_0, string_1, DarkMessageBoxIcon.Warning, darkDialogButton_0);
	}

	public static DialogResult ShowError(string string_0, string string_1, DarkDialogButton darkDialogButton_0 = DarkDialogButton.Ok)
	{
		return PatchListener(string_0, string_1, DarkMessageBoxIcon.Error, darkDialogButton_0);
	}

	private static DialogResult PatchListener(string string_0, string string_1, DarkMessageBoxIcon darkMessageBoxIcon_0, DarkDialogButton darkDialogButton_0)
	{
		using DarkMessageBox darkMessageBox = new DarkMessageBox(string_0, string_1, darkMessageBoxIcon_0, darkDialogButton_0);
		return darkMessageBox.ShowDialog();
	}

	private void SelectListener(DarkMessageBoxIcon darkMessageBoxIcon_0)
	{
		switch (darkMessageBoxIcon_0)
		{
		case DarkMessageBoxIcon.None:
			_DatabaseObject.Visible = false;
			_InterceptorObject.Left = 10;
			break;
		case DarkMessageBoxIcon.Information:
			_DatabaseObject.Image = QResourceHelper.GetImage("info");
			break;
		case DarkMessageBoxIcon.Warning:
			_DatabaseObject.Image = QResourceHelper.GetImage("warning");
			break;
		case DarkMessageBoxIcon.Error:
			_DatabaseObject.Image = QResourceHelper.GetImage("error");
			break;
		}
	}

	private void CallListener()
	{
		int num = 260;
		int num2 = 124;
		base.Size = new Size(260, 124);
		_InterceptorObject.Text = string.Empty;
		_InterceptorObject.AutoSize = true;
		_InterceptorObject.Text = printerObject;
		int num3 = Math.Max(260, base.TotalButtonSize + 15);
		int num4 = _InterceptorObject.Right + 25;
		if (num4 < _ParserObject)
		{
			num = num4;
			_InterceptorObject.Top = _DatabaseObject.Top + _DatabaseObject.Height / 2 - _InterceptorObject.Height / 2;
		}
		else
		{
			num = _ParserObject;
			int num5 = base.Height - _DatabaseObject.Height;
			_InterceptorObject.AutoUpdateHeight = true;
			_InterceptorObject.Width = num - _InterceptorObject.Left - 25;
			num2 = num5 + _InterceptorObject.Height;
		}
		if (num < num3)
		{
			num = num3;
		}
		base.Size = new Size(num, num2);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		CallListener();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && algoObject != null)
		{
			algoObject.Dispose();
		}
		base.Dispose(disposing);
	}

	private void LogoutListener()
	{
		_DatabaseObject = new PictureBox();
		_InterceptorObject = new DarkLabel();
		((ISupportInitialize)_DatabaseObject).BeginInit();
		SuspendLayout();
		_DatabaseObject.Location = new Point(10, 10);
		_DatabaseObject.Name = "picIcon";
		_DatabaseObject.Size = new Size(32, 32);
		_DatabaseObject.TabIndex = 3;
		_DatabaseObject.TabStop = false;
		_InterceptorObject.AutoSize = true;
		_InterceptorObject.ForeColor = Color.FromArgb(220, 220, 220);
		_InterceptorObject.Location = new Point(50, 9);
		_InterceptorObject.Name = "lblText";
		_InterceptorObject.Size = new Size(185, 15);
		_InterceptorObject.TabIndex = 4;
		_InterceptorObject.Text = "Something something something";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.ClientSize = new Size(244, 86);
		base.Controls.Add(_InterceptorObject);
		base.Controls.Add(_DatabaseObject);
		Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DarkMessageBox";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Message box";
		base.TopMost = true;
		base.Controls.SetChildIndex(_DatabaseObject, 0);
		base.Controls.SetChildIndex(_InterceptorObject, 0);
		((ISupportInitialize)_DatabaseObject).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
