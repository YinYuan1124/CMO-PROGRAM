using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command_Core.Lua;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command;

[DesignerGenerated]
public class AdvancedDialog : Form
{
	private IContainer m_DicImporter;

	[AccessedThroughProperty("DarkUIButton1")]
	[CompilerGenerated]
	private DarkUIButton m_FacadeImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton2")]
	private DarkUIButton m_ProxyImporter;

	[AccessedThroughProperty("DarkUIButton3")]
	[CompilerGenerated]
	private DarkUIButton m_ReaderImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Main")]
	private DarkRichTextBox propertyImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("WebBrowser1")]
	private WebBrowser importerImporter;

	public string LastInteraction;

	public HashSet<string> Interactions;

	private Dictionary<string, string> repositoryImporter;

	[field: AccessedThroughProperty("InteractionButtonContainer")]
	internal virtual FlowLayoutPanel InteractionButtonContainer
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton DarkUIButton1
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FacadeImporter = value;
		}
	}

	internal virtual DarkUIButton DarkUIButton2
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyImporter = value;
		}
	}

	internal virtual DarkUIButton DarkUIButton3
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReaderImporter = value;
		}
	}

	internal virtual DarkRichTextBox TB_Main
	{
		[CompilerGenerated]
		get
		{
			return propertyImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			propertyImporter = value;
		}
	}

	internal virtual WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return importerImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			importerImporter = value;
		}
	}

	public AdvancedDialog()
	{
		LastInteraction = "none";
		Interactions = new HashSet<string>();
		repositoryImporter = new Dictionary<string, string>();
		ConnectContainer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DicImporter != null)
			{
				m_DicImporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ConnectContainer()
	{
		InteractionButtonContainer = new FlowLayoutPanel();
		DarkUIButton1 = new DarkUIButton();
		DarkUIButton2 = new DarkUIButton();
		DarkUIButton3 = new DarkUIButton();
		TB_Main = new DarkRichTextBox();
		WebBrowser1 = new WebBrowser();
		InteractionButtonContainer.SuspendLayout();
		SuspendLayout();
		InteractionButtonContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		InteractionButtonContainer.AutoScroll = true;
		InteractionButtonContainer.Controls.Add(DarkUIButton1);
		InteractionButtonContainer.Controls.Add(DarkUIButton2);
		InteractionButtonContainer.Controls.Add(DarkUIButton3);
		InteractionButtonContainer.FlowDirection = FlowDirection.TopDown;
		InteractionButtonContainer.Location = new Point(16, 381);
		InteractionButtonContainer.Margin = new Padding(4, 4, 4, 4);
		InteractionButtonContainer.Name = "InteractionButtonContainer";
		InteractionButtonContainer.Size = new Size(705, 62);
		InteractionButtonContainer.TabIndex = 1;
		DarkUIButton1.BackColor = Color.Transparent;
		DarkUIButton1.DialogResult = DialogResult.None;
		DarkUIButton1.ForeColor = SystemColors.Control;
		DarkUIButton1.Location = new Point(4, 4);
		DarkUIButton1.Margin = new Padding(4, 4, 4, 4);
		DarkUIButton1.Name = "DarkUIButton1";
		DarkUIButton1.RoundRadius = 0;
		DarkUIButton1.Size = new Size(315, 31);
		DarkUIButton1.TabIndex = 0;
		DarkUIButton1.Text = "Ceci est un texte normal pour mesurer la taille";
		DarkUIButton2.BackColor = Color.Transparent;
		DarkUIButton2.DialogResult = DialogResult.None;
		DarkUIButton2.ForeColor = SystemColors.Control;
		DarkUIButton2.Location = new Point(327, 4);
		DarkUIButton2.Margin = new Padding(4, 4, 4, 4);
		DarkUIButton2.Name = "DarkUIButton2";
		DarkUIButton2.RoundRadius = 0;
		DarkUIButton2.Size = new Size(149, 32);
		DarkUIButton2.TabIndex = 1;
		DarkUIButton2.Text = "DarkUIButton2";
		DarkUIButton3.BackColor = Color.Transparent;
		DarkUIButton3.DialogResult = DialogResult.None;
		DarkUIButton3.ForeColor = SystemColors.Control;
		DarkUIButton3.Location = new Point(484, 4);
		DarkUIButton3.Margin = new Padding(4, 4, 4, 4);
		DarkUIButton3.Name = "DarkUIButton3";
		DarkUIButton3.RoundRadius = 0;
		DarkUIButton3.Size = new Size(149, 32);
		DarkUIButton3.TabIndex = 2;
		DarkUIButton3.Text = "DarkUIButton3";
		TB_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_Main.BackColor = Color.FromArgb(50, 53, 55);
		TB_Main.Enabled = false;
		TB_Main.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Main.Location = new Point(16, 15);
		TB_Main.Margin = new Padding(4, 4, 4, 4);
		TB_Main.Name = "TB_Main";
		TB_Main.ReadOnly = true;
		TB_Main.Size = new Size(703, 358);
		TB_Main.TabIndex = 2;
		TB_Main.Text = "";
		WebBrowser1.AllowWebBrowserDrop = false;
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.IsWebBrowserContextMenuEnabled = false;
		WebBrowser1.Location = new Point(16, 15);
		WebBrowser1.Margin = new Padding(4, 4, 4, 4);
		WebBrowser1.MinimumSize = new Size(27, 25);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(705, 359);
		WebBrowser1.TabIndex = 23;
		WebBrowser1.WebBrowserShortcutsEnabled = false;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(737, 451);
		base.Controls.Add(WebBrowser1);
		base.Controls.Add(InteractionButtonContainer);
		base.Controls.Add(TB_Main);
		base.Margin = new Padding(4, 4, 4, 4);
		base.Name = "AdvancedDialog";
		Text = "Advanced Dialog";
		InteractionButtonContainer.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public static string CallDialog(string string_0, string string_1, string[] string_2)
	{
		AdvancedDialog advancedDialog = new AdvancedDialog();
		advancedDialog.PopulateButtons(string_2);
		advancedDialog.Text = string_0;
		advancedDialog.TB_Main.Text = string_1;
		advancedDialog.TB_Main.Enabled = true;
		advancedDialog.TB_Main.Visible = true;
		advancedDialog.WebBrowser1.Visible = false;
		if (advancedDialog.ShowDialog() == DialogResult.OK)
		{
			return advancedDialog.LastInteraction;
		}
		return "";
	}

	public static object CallHTMLDialog(string string_0, string string_1, string[] string_2)
	{
		AdvancedDialog advancedDialog = new AdvancedDialog();
		advancedDialog.PopulateButtons(string_2);
		advancedDialog.TB_Main.Enabled = false;
		advancedDialog.TB_Main.Visible = false;
		advancedDialog.WebBrowser1.Visible = true;
		InterpreterObjectListener.AwakeInterruptibleTask(advancedDialog.WebBrowser1, string_1);
		DialogResult num = advancedDialog.ShowDialog();
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		if (num == DialogResult.OK)
		{
			val["pressed"] = advancedDialog.LastInteraction;
			advancedDialog.MoveContainer(advancedDialog.WebBrowser1);
			foreach (KeyValuePair<string, string> item in advancedDialog.repositoryImporter)
			{
				val[item.Key] = item.Value;
			}
			return val;
		}
		return val;
	}

	private void MoveContainer(WebBrowser webBrowser_0)
	{
		repositoryImporter.Clear();
		HtmlDocument document = webBrowser_0.Document;
		IEnumerator enumerator = null;
		try
		{
			enumerator = document.All.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HtmlElement htmlElement = (HtmlElement)enumerator.Current;
				if (string.IsNullOrEmpty(htmlElement.Name))
				{
					continue;
				}
				string attribute = htmlElement.GetAttribute("type");
				string attribute2 = htmlElement.GetAttribute("value");
				string value = (Versioned.IsNumeric(attribute2) ? attribute2 : ("'" + attribute2 + "'"));
				if (Operators.CompareString(attribute, "radio", TextCompare: true) == 0)
				{
					if (Conversions.ToBoolean(htmlElement.GetAttribute("checked")))
					{
						repositoryImporter.Add(htmlElement.Name, value);
					}
				}
				else if (Operators.CompareString(attribute, "checkbox", TextCompare: true) == 0)
				{
					if (Conversions.ToBoolean(htmlElement.GetAttribute("checked")))
					{
						repositoryImporter.Add(htmlElement.Name, value);
					}
				}
				else if (Operators.CompareString(attribute, "select-one", TextCompare: true) == 0 || Operators.CompareString(attribute, "text", TextCompare: true) == 0)
				{
					repositoryImporter.Add(htmlElement.Name, value);
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	public void PopulateButtons(string[] string_0)
	{
		Interactions = string_0.ToHashSet();
		InteractionButtonContainer.Controls.Clear();
		foreach (string interaction in Interactions)
		{
			DarkUIButton darkUIButton = new DarkUIButton();
			darkUIButton.Size = new Size(Math.Max((int)Math.Round(5.4f * (float)interaction.Length + 15f), 10), 25);
			darkUIButton.Text = interaction;
			darkUIButton.DialogResult = DialogResult.OK;
			darkUIButton.Click += DeleteContainer;
			InteractionButtonContainer.Controls.Add(darkUIButton);
		}
	}

	private void DeleteContainer(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		LastInteraction = ((DarkUIButton)sender).Text;
	}

	private void AddContainer(object sender, EventArgs e)
	{
	}
}
