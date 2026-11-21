using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class InteractiveManual : Form
{
	public class ManualNode
	{
		public bool IsFolder;

		public string Name;

		public string iPath;

		public Dictionary<ManualNode, ManualNode> ChildNodes;

		private InteractiveManual m_PoolMap;

		public ManualNode ParentNode;

		public void AddChildNode(ManualNode manualNode_0)
		{
			ChildNodes.Add(manualNode_0, manualNode_0);
			manualNode_0.ParentNode = this;
		}

		public void RemoveChildNode(ManualNode manualNode_0)
		{
			manualNode_0.ParentNode = null;
			ChildNodes.Remove(manualNode_0);
		}

		public void GenerateNode(string string_0, ManualNode manualNode_0)
		{
			string[] files = Directory.GetFiles(string_0);
			string[] array = files;
			foreach (string path in array)
			{
				ManualNode manualNode = new ManualNode(bool_0: false, Path.GetFileName(path), string_0, m_PoolMap);
				m_PoolMap.Nodes.Add(manualNode, manualNode);
				manualNode_0.AddChildNode(manualNode);
			}
			files = Directory.GetDirectories(string_0);
			string[] array2 = files;
			foreach (string path2 in array2)
			{
				ManualNode manualNode2 = new ManualNode(bool_0: true, Path.GetFileName(path2), string_0, m_PoolMap);
				m_PoolMap.Nodes.Add(manualNode2, manualNode2);
				manualNode_0.AddChildNode(manualNode2);
			}
		}

		public ManualNode(bool bool_0, string string_0, string string_1, InteractiveManual interactiveManual_0)
		{
			ChildNodes = new Dictionary<ManualNode, ManualNode>();
			IsFolder = bool_0;
			Name = string_0;
			iPath = string_1;
			m_PoolMap = interactiveManual_0;
			string text = Path.Combine(string_1, string_0);
			string key = Strings.Replace(string_0, ".mht", "", 1, -1, CompareMethod.Text);
			if (!bool_0 && !interactiveManual_0.FilesByFullPath.ContainsKey(key))
			{
				interactiveManual_0.FilesByFullPath.Add(key, text);
			}
			if (bool_0)
			{
				GenerateNode(text, this);
			}
		}
	}

	private IContainer m_RegContainer;

	[AccessedThroughProperty("WebBrowser")]
	[CompilerGenerated]
	private WebBrowser m_ParamContainer;

	[AccessedThroughProperty("TV_ManualPages")]
	[CompilerGenerated]
	private TreeView pageContainer;

	public Dictionary<ManualNode, ManualNode> Nodes;

	public Dictionary<string, string> FilesByFullPath;

	public Dictionary<string, TreeNode> FilesByTreeNode;

	public string _Rootpath;

	internal virtual WebBrowser WebBrowser
	{
		[CompilerGenerated]
		get
		{
			return m_ParamContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamContainer = value;
		}
	}

	internal virtual TreeView TV_ManualPages
	{
		[CompilerGenerated]
		get
		{
			return pageContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TreeViewEventHandler value2 = ResolveIterator;
			TreeView treeView = pageContainer;
			if (treeView != null)
			{
				treeView.AfterSelect -= value2;
			}
			pageContainer = value;
			treeView = pageContainer;
			if (treeView != null)
			{
				treeView.AfterSelect += value2;
			}
		}
	}

	public string Rootpath
	{
		get
		{
			if (string.IsNullOrEmpty(_Rootpath))
			{
				_Rootpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Manuals\\InteractiveManual");
			}
			return _Rootpath;
		}
	}

	public InteractiveManual()
	{
		Nodes = new Dictionary<ManualNode, ManualNode>();
		FilesByFullPath = new Dictionary<string, string>();
		FilesByTreeNode = new Dictionary<string, TreeNode>();
		_Rootpath = "";
		ListIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RegContainer != null)
			{
				m_RegContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ListIterator()
	{
		WebBrowser = new WebBrowser();
		TV_ManualPages = new TreeView();
		SuspendLayout();
		WebBrowser.AllowWebBrowserDrop = false;
		WebBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser.IsWebBrowserContextMenuEnabled = false;
		WebBrowser.Location = new Point(202, 12);
		WebBrowser.MinimumSize = new Size(20, 20);
		WebBrowser.Name = "WebBrowser";
		WebBrowser.Size = new Size(713, 439);
		WebBrowser.TabIndex = 24;
		WebBrowser.WebBrowserShortcutsEnabled = false;
		TV_ManualPages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TV_ManualPages.Location = new Point(4, 12);
		TV_ManualPages.Name = "TV_ManualPages";
		TV_ManualPages.Size = new Size(192, 439);
		TV_ManualPages.TabIndex = 25;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(927, 463);
		base.Controls.Add(WebBrowser);
		base.Controls.Add(TV_ManualPages);
		base.Name = "InteractiveManual";
		Text = "Interactive Manual";
		ResumeLayout(performLayout: false);
	}

	public new void Show()
	{
		Show("Main");
	}

	public void Show(string string_0)
	{
		try
		{
			PopulateTV();
			LoadPage(string_0);
			base.Show();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2007377", ex2.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			MessageBox.Show("Impossible to load the interactive manual, the Interactive manual may be missing.", "Error : interactive manual");
			ProjectData.ClearProjectError();
		}
	}

	public void LoadPage(string string_0)
	{
		if (FilesByFullPath.ContainsKey(string_0))
		{
			WebBrowser.Url = new Uri("file:///" + FilesByFullPath[string_0]);
			TV_ManualPages.SelectedNode = FilesByTreeNode[string_0];
		}
		else
		{
			MessageBox.Show("File not found", "Error : File not found");
		}
	}

	public void PopulateTV()
	{
		string rootpath = Rootpath;
		ManualNode manualNode = new ManualNode(bool_0: true, "", rootpath, this);
		Nodes.Add(manualNode, manualNode);
		TVNode(manualNode, null);
	}

	public void TVNode(ManualNode manualNode_0, TreeNode treeNode_0)
	{
		string key = Strings.Replace(manualNode_0.Name, ".mht", "", 1, -1, CompareMethod.Text);
		TreeNode treeNode = new TreeNode(key);
		if (!manualNode_0.IsFolder && !FilesByTreeNode.ContainsKey(key))
		{
			FilesByTreeNode.Add(key, treeNode);
		}
		treeNode.Tag = manualNode_0;
		if (treeNode_0 == null)
		{
			TV_ManualPages.Nodes.Add(treeNode);
		}
		else
		{
			treeNode_0.Nodes.Add(treeNode);
		}
		foreach (KeyValuePair<ManualNode, ManualNode> childNode in manualNode_0.ChildNodes)
		{
			TVNode(childNode.Key, treeNode);
		}
	}

	private void ResolveIterator(object sender, TreeViewEventArgs e)
	{
		ManualNode manualNode = (ManualNode)TV_ManualPages.SelectedNode.Tag;
		if (!manualNode.IsFolder)
		{
			LoadPage(Strings.Replace(manualNode.Name, ".mht", "", 1, -1, CompareMethod.Text));
		}
	}
}
