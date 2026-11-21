using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class QuickBattle : DarkSecondaryFormBase
{
	private IContainer m_CodeSchema;

	[AccessedThroughProperty("TV_Scens")]
	[CompilerGenerated]
	private DarkTreeView m_ConnectionSchema;

	[AccessedThroughProperty("theBrowser")]
	[CompilerGenerated]
	private WebBrowser contextSchema;

	[AccessedThroughProperty("Button_Start")]
	[CompilerGenerated]
	private DarkUIButton m_StatusSchema;

	private Dictionary<string, string> proccesorSchema;

	internal DarkTreeView TV_Scens
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleConnection;
			DarkTreeView connectionSchema = m_ConnectionSchema;
			if (connectionSchema != null)
			{
				connectionSchema.SelectedNodesChanged -= value2;
			}
			m_ConnectionSchema = value;
			connectionSchema = m_ConnectionSchema;
			if (connectionSchema != null)
			{
				connectionSchema.SelectedNodesChanged += value2;
			}
		}
	}

	internal WebBrowser theBrowser
	{
		[CompilerGenerated]
		get
		{
			return contextSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			contextSchema = value;
		}
	}

	internal DarkUIButton Button_Start
	{
		[CompilerGenerated]
		get
		{
			return m_StatusSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleConnection;
			DarkUIButton statusSchema = m_StatusSchema;
			if (statusSchema != null)
			{
				statusSchema.Click -= value2;
			}
			m_StatusSchema = value;
			statusSchema = m_StatusSchema;
			if (statusSchema != null)
			{
				statusSchema.Click += value2;
			}
		}
	}

	public string QuickBattlesRootPath => "QuickBattle";

	public QuickBattle()
	{
		base.Shown += PopInterruptibleConnection;
		proccesorSchema = new Dictionary<string, string>();
		CalculateInterruptibleConnection();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_CodeSchema != null)
			{
				m_CodeSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateInterruptibleConnection()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(QuickBattle));
		TV_Scens = new DarkTreeView();
		theBrowser = new WebBrowser();
		Button_Start = new DarkUIButton();
		SuspendLayout();
		TV_Scens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TV_Scens.Location = new Point(7, 5);
		TV_Scens.MaxDragChange = 20;
		TV_Scens.Name = "TV_Scens";
		TV_Scens.Size = new Size(209, 479);
		TV_Scens.TabIndex = 6;
		theBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		theBrowser.Location = new Point(222, 0);
		theBrowser.MinimumSize = new Size(20, 20);
		theBrowser.Name = "theBrowser";
		theBrowser.Size = new Size(629, 529);
		theBrowser.TabIndex = 16;
		theBrowser.Visible = false;
		Button_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_Start.BackColor = Color.Transparent;
		Button_Start.DialogResult = DialogResult.None;
		Button_Start.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_Start.ForeColor = SystemColors.Control;
		Button_Start.Location = new Point(66, 490);
		Button_Start.Name = "Button_Start";
		Button_Start.RoundRadius = 0;
		Button_Start.Size = new Size(79, 29);
		Button_Start.TabIndex = 17;
		Button_Start.Text = "开始";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(850, 530);
		base.Controls.Add(Button_Start);
		base.Controls.Add(theBrowser);
		base.Controls.Add(TV_Scens);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = componentResourceManager.GetIcon("$this.Icon");
		base.Name = "QuickBattle";
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "快速生成想定";
		ResumeLayout(performLayout: false);
	}

	private void PopInterruptibleConnection(object sender, EventArgs e)
	{
		InstantiateInterruptibleConnection();
	}

	private void InstantiateInterruptibleConnection()
	{
		TV_Scens.Nodes.Clear();
		string[] directories = Directory.GetDirectories(QuickBattlesRootPath);
		string[] array = directories;
		foreach (string text in array)
		{
			if (CreateInterruptibleConnection(text))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(text));
				TV_Scens.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = text;
			}
		}
		if (TV_Scens.Nodes.Count > 0)
		{
			TV_Scens.SelectNode(TV_Scens.Nodes[0]);
		}
	}

	private bool CreateInterruptibleConnection(string string_0)
	{
		if (Directory.GetFiles(string_0).Count() > 0)
		{
			string[] files = Directory.GetFiles(string_0);
			for (int i = 0; i < files.Length; i = checked(i + 1))
			{
				if (files[i].EndsWith(".html"))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void CompareInterruptibleConnection(object sender, EventArgs e)
	{
		try
		{
			ReadInterruptibleConnection();
			if (proccesorSchema.ContainsKey("DB"))
			{
				string left = proccesorSchema["DB"];
				if (Operators.CompareString(left, "'DB3000'", TextCompare: true) == 0)
				{
					Client.IncludeConfiguration(Conversions.ToString(1));
				}
				else
				{
					if (Operators.CompareString(left, "'CWDB'", TextCompare: true) != 0)
					{
						DarkMessageBox.ShowError("The provided value for element 'DB' is not a valid value. ABorting...", "Invalid DB value!");
						return;
					}
					Client.IncludeConfiguration(Conversions.ToString(2));
				}
			}
			else
			{
				Client.IncludeConfiguration(Conversions.ToString(1));
			}
			Client.CreateNewScenario();
			foreach (KeyValuePair<string, string> item in proccesorSchema)
			{
				Client.CurrentScenario.Scenario_LuaSandbox.RunScript(item.Key + " = " + item.Value, bool_0: false);
			}
			DisableInterruptibleConnection();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, Client.CurrentSide.MapCenter);
			Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("错误：" + ex2.Message, "Error");
			ProjectData.ClearProjectError();
		}
	}

	private void ReadInterruptibleConnection()
	{
		proccesorSchema.Clear();
		HtmlDocument document = theBrowser.Document;
		IEnumerator enumerator = null;
		try
		{
			enumerator = document.All.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HtmlElement htmlElement = (HtmlElement)enumerator.Current;
				if (!string.IsNullOrEmpty(htmlElement.Name))
				{
					string attribute = htmlElement.GetAttribute("value");
					string value = (Versioned.IsNumeric(attribute) ? attribute : ("'" + attribute + "'"));
					proccesorSchema.Add(htmlElement.Name, value);
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

	private void DisableInterruptibleConnection()
	{
		string text = Path.Combine(Conversions.ToString(TV_Scens.SelectedNodes[0].Tag), "Script.lua");
		string string_ = File.ReadAllText(text);
		Client.CurrentScenario.Scenario_LuaSandbox.RunScript(string_, bool_0: false, "QuickBattleInit", text);
	}

	private void UpdateInterruptibleConnection(object sender, EventArgs e)
	{
		if (TV_Scens.SelectedNodes.Count > 0)
		{
			string path = Path.Combine(Conversions.ToString(TV_Scens.SelectedNodes[0].Tag), "Form.html");
			InterpreterObjectListener.AwakeInterruptibleTask(theBrowser, File.ReadAllText(path));
			theBrowser.Visible = true;
		}
	}
}
