using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SelectSAO : DarkSecondaryFormBase
{
	private IContainer m_VisitorSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip m_ExporterSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage m_PrototypeSingleton;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView m_ComparatorSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl itemSingleton;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton setterSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Column_name")]
	private DataGridViewTextBoxColumn _CreatorSingleton;

	[AccessedThroughProperty("Type")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_TemplateSingleton;

	[AccessedThroughProperty("GUID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_MappingSingleton;

	private List<ScenAttachmentObject> mockSingleton;

	public List<ScenAttachmentObject> SelectedSAOs;

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterSingleton = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrototypeSingleton = value;
		}
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComparatorSingleton = value;
		}
	}

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return itemSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemSingleton = value;
		}
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return setterSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountInterruptibleAdapter;
			ToolStripButton toolStripButton = setterSingleton;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			setterSingleton = value;
			toolStripButton = setterSingleton;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TemplateSingleton = value;
		}
	}

	internal DataGridViewTextBoxColumn GUID
	{
		[CompilerGenerated]
		get
		{
			return m_MappingSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingSingleton = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn LogoutInterruptibleAdapter()
	{
		return _CreatorSingleton;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ViewInterruptibleAdapter(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		_CreatorSingleton = dataGridViewTextBoxColumn_0;
	}

	public SelectSAO()
	{
		base.Shown += RevertInterruptibleServer;
		base.Load += CustomizeInterruptibleAdapter;
		SelectedSAOs = new List<ScenAttachmentObject>();
		ManageInterruptibleServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_VisitorSingleton != null)
			{
				m_VisitorSingleton.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ManageInterruptibleServer()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(SelectSAO));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		TabPage1 = new TabPage();
		DataGridView1 = new DarkDataGridView();
		ViewInterruptibleAdapter(new DataGridViewTextBoxColumn());
		Type = new DataGridViewTextBoxColumn();
		GUID = new DataGridViewTextBoxColumn();
		TabControl1 = new DarkUITabControl();
		ToolStrip1.SuspendLayout();
		TabPage1.SuspendLayout();
		((ISupportInitialize)DataGridView1).BeginInit();
		TabControl1.SuspendLayout();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[1] { ToolStripButton1 });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(845, 25);
		ToolStrip1.TabIndex = 2;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.Image = componentResourceManager.GetObject("ToolStripButton1.Image");
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(176, 22);
		ToolStripButton1.Text = "加载选定的附件";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(DataGridView1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(837, 294);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "本地存储库";
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.Fixed3D;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridView1.Columns.AddRange(LogoutInterruptibleAdapter(), Type, GUID);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.Dock = DockStyle.Fill;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(3, 3);
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(831, 288);
		DataGridView1.TabIndex = 0;
		LogoutInterruptibleAdapter().AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		LogoutInterruptibleAdapter().HeaderText = "名称";
		LogoutInterruptibleAdapter().Name = "Name";
		LogoutInterruptibleAdapter().ReadOnly = true;
		LogoutInterruptibleAdapter().Width = 58;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Type.HeaderText = "类型";
		Type.Name = "Type";
		Type.ReadOnly = true;
		Type.Width = 54;
		GUID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		GUID.HeaderText = "GUID";
		GUID.Name = "GUID";
		GUID.ReadOnly = true;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 28);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(845, 322);
		TabControl1.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(845, 347);
		base.Controls.Add(TabControl1);
		base.Controls.Add(ToolStrip1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Select SAO";
		base.ShowIcon = false;
		Text = "加载现有想定附件";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TabPage1.ResumeLayout(performLayout: false);
		((ISupportInitialize)DataGridView1).EndInit();
		TabControl1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void RevertInterruptibleServer(object sender, EventArgs e)
	{
		SelectedSAOs.Clear();
		RefreshRepoAttachments();
	}

	public void RefreshRepoAttachments()
	{
		List<ScenAttachmentObject> list = new List<ScenAttachmentObject>();
		string[] directories = Directory.GetDirectories(GameGeneral.AttachmentRepoPath);
		for (int i = 0; i < directories.Length; i = checked(i + 1))
		{
			ScenAttachmentObject item = ScenAttachmentObject.ReadFromFolder(directories[i]);
			list.Add(item);
		}
		DataGridView1.SuspendLayout();
		DataGridView1.Rows.Clear();
		foreach (ScenAttachmentObject item2 in list)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.CreateCells(DataGridView1);
			dataGridViewRow.Cells[0].Value = item2.Name;
			dataGridViewRow.Cells[1].Value = item2.Type.ToString();
			dataGridViewRow.Cells[2].Value = item2.ObjectID;
			dataGridViewRow.Tag = item2;
			DataGridView1.Rows.Add(dataGridViewRow);
		}
		DataGridView1.ResumeLayout();
	}

	private void CountInterruptibleAdapter(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = DataGridView1.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ScenAttachmentObject item = (ScenAttachmentObject)NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(enumerator.Current), null, "tag", new object[0], null, null, null);
				SelectedSAOs.Add(item);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void CustomizeInterruptibleAdapter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
