using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RenameSide : DarkSecondaryFormBase
{
	private IContainer wrapperPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_ObserverPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox _IssuerPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _ClientPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton dicPredicate;

	private bool m_ConsumerPredicate;

	public Side SelectedSide;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObserverPredicate = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _IssuerPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = StartInterruptibleToken;
			EventHandler value3 = PublishInterruptibleToken;
			EventHandler value4 = AwakeInterruptibleToken;
			DarkUITextBox issuerPredicate = _IssuerPredicate;
			if (issuerPredicate != null)
			{
				issuerPredicate.TextChanged -= value2;
				issuerPredicate.Enter -= value3;
				issuerPredicate.Leave -= value4;
			}
			_IssuerPredicate = value;
			issuerPredicate = _IssuerPredicate;
			if (issuerPredicate != null)
			{
				issuerPredicate.TextChanged += value2;
				issuerPredicate.Enter += value3;
				issuerPredicate.Leave += value4;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _ClientPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleToken;
			DarkUIButton clientPredicate = _ClientPredicate;
			if (clientPredicate != null)
			{
				clientPredicate.Click -= value2;
			}
			_ClientPredicate = value;
			clientPredicate = _ClientPredicate;
			if (clientPredicate != null)
			{
				clientPredicate.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return dicPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetInterruptibleToken;
			DarkUIButton darkUIButton = dicPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			dicPredicate = value;
			darkUIButton = dicPredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public RenameSide()
	{
		base.Load += PrintInterruptibleToken;
		base.KeyDown += DefineInterruptibleToken;
		PostInterruptibleToken();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && wrapperPredicate != null)
			{
				wrapperPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PostInterruptibleToken()
	{
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(61, 13);
		Label1.TabIndex = 0;
		Label1.Text = "新名字：";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(16, 30);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(298, 24);
		TextBox1.TabIndex = 1;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button1.BackColor = Color.Transparent;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button1.Location = new Point(16, 66);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 2;
		Button1.Text = "确定";
		Button2.BackColor = Color.Transparent;
		Button2.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button2.Location = new Point(239, 66);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 3;
		Button2.Text = "取消";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(326, 95);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "RenameSide";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "重命名分方";
		ResumeLayout(performLayout: false);
	}

	private void RunInterruptibleToken(object sender, EventArgs e)
	{
		SelectedSide.Name = TextBox1.Text;
		if (ItemExporter.ConnectInterruptibleTemplate.Sides.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.Sides.RefreshForm();
		}
		Close();
	}

	private void StartInterruptibleToken(object object_0)
	{
		Button1.Enabled = Operators.CompareString(TextBox1.Text, "", TextCompare: true) != 0;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			if (string.Compare(sides_ReadOnly[i].Name, TextBox1.Text, ignoreCase: false) == 0)
			{
				Button1.Enabled = false;
			}
		}
	}

	private void AssetInterruptibleToken(object sender, EventArgs e)
	{
		Close();
	}

	private void PrintInterruptibleToken(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TextBox1.Text = SelectedSide.Name;
	}

	private void DefineInterruptibleToken(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (m_ConsumerPredicate)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				Label1.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!m_ConsumerPredicate && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PublishInterruptibleToken(object sender, EventArgs e)
	{
		m_ConsumerPredicate = true;
	}

	private void AwakeInterruptibleToken(object sender, EventArgs e)
	{
		m_ConsumerPredicate = false;
		Label1.Select();
	}
}
