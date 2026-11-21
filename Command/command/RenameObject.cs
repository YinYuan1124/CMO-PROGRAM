using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RenameObject : DarkSecondaryFormBase
{
	public enum E_RenamingOption
	{
		ReferencePoint,
		Unit,
		Unit_Generic
	}

	private IContainer configPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox registryPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton definitionPredicate;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton valPredicate;

	public string SelectedName;

	public E_RenamingOption RenamingOption;

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return registryPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			registryPredicate = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return definitionPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button1_Click;
			DarkUIButton darkUIButton = definitionPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			definitionPredicate = value;
			darkUIButton = definitionPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return valPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitInterruptibleToken;
			DarkUIButton darkUIButton = valPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			valPredicate = value;
			darkUIButton = valPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public RenameObject()
	{
		base.FormClosing += PrepareInterruptibleToken;
		base.Load += ReflectInterruptibleToken;
		base.KeyDown += RestartInterruptibleToken;
		InsertInterruptibleToken();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && configPredicate != null)
			{
				configPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InsertInterruptibleToken()
	{
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		SuspendLayout();
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(12, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(317, 20);
		TextBox1.TabIndex = 0;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.OK;
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(12, 44);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 1;
		Button1.Text = "确定";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.Cancel;
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(254, 44);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 2;
		Button2.Text = "取消";
		base.AcceptButton = Button1;
		base.AutoScaleMode = AutoScaleMode.None;
		AutoValidate = AutoValidate.EnableAllowFocusChange;
		base.CancelButton = Button2;
		base.ClientSize = new Size(341, 77);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "RenameObject";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "重命名对象";
		ResumeLayout(performLayout: false);
	}

	private void PrepareInterruptibleToken(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Client.MustRefreshMainForm = true;
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.AirOps) && ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AirOps.RefreshForm();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (ItemExporter.ConnectInterruptibleTemplate.ScenAttachmentsWindow.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.ScenAttachmentsWindow.RefreshForm();
		}
	}

	private void ReflectInterruptibleToken(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		if (RenamingOption == E_RenamingOption.ReferencePoint)
		{
			if (Client.HighlightedRefPoints.Count < 1)
			{
				return;
			}
			SelectedName = Client.HighlightedRefPoints[0].Name;
			Text = "重命名参考点";
		}
		else if (RenamingOption == E_RenamingOption.Unit)
		{
			SelectedName = Client.SelectedUnit.Name;
			Text = "重命名单元";
		}
		else if (RenamingOption == E_RenamingOption.Unit_Generic)
		{
			Text = "重命名单元";
		}
		TextBox1.Text = SelectedName;
		TextBox1._T.Select();
		TextBox1.SelectionStart = 0;
		TextBox1._T.SelectionLength = SelectedName.Length;
	}

	public void Button1_Click(object sender, EventArgs e)
	{
		ConfirmRenaming();
	}

	public void ConfirmRenaming()
	{
		SelectedName = TextBox1.Text;
		base.DialogResult = DialogResult.OK;
		if (RenamingOption == E_RenamingOption.ReferencePoint)
		{
			if (Client.HighlightedRefPoints.Count < 1)
			{
				return;
			}
			Client.HighlightedRefPoints[0].Name = SelectedName;
		}
		else if (RenamingOption == E_RenamingOption.Unit)
		{
			if (Client.SelectedUnit == null)
			{
				return;
			}
			Client.SelectedUnit.Name = SelectedName;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshRightColumn();
		}
		Close();
	}

	private void VisitInterruptibleToken(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void RestartInterruptibleToken(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			_ = base.Visible;
		}
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Escape:
			Close();
			return true;
		default:
			return false;
		case Keys.Return:
			ConfirmRenaming();
			return true;
		}
	}
}
