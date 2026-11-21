using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddPatrol : DarkSecondaryFormBase
{
	private IContainer _WriterProperty;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel specificationProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Cancel_Button")]
	private DarkUIButton m_ReponseProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel descriptorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_PatrolName")]
	private DarkUITextBox _PoolProperty;

	private bool _TaskProperty;

	public double OffsetFromAxis;

	public double theDistance;

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return specificationProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationProperty = value;
		}
	}

	[field: AccessedThroughProperty("OK_Button")]
	internal DarkUIButton OK_Button
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Cancel_Button
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertTask;
			DarkUIButton reponseProperty = m_ReponseProperty;
			if (reponseProperty != null)
			{
				reponseProperty.Click -= value2;
			}
			m_ReponseProperty = value;
			reponseProperty = m_ReponseProperty;
			if (reponseProperty != null)
			{
				reponseProperty.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return descriptorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorProperty = value;
		}
	}

	internal DarkUITextBox TB_PatrolName
	{
		[CompilerGenerated]
		get
		{
			return _PoolProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitTask;
			EventHandler value3 = RestartTask;
			DarkUITextBox poolProperty = _PoolProperty;
			if (poolProperty != null)
			{
				poolProperty.Enter -= value2;
				poolProperty.Leave -= value3;
			}
			_PoolProperty = value;
			poolProperty = _PoolProperty;
			if (poolProperty != null)
			{
				poolProperty.Enter += value2;
				poolProperty.Leave += value3;
			}
		}
	}

	public AddPatrol()
	{
		base.FormClosing += PrepareTask;
		base.KeyDown += ReflectTask;
		base.Load += TestTask;
		UpdateTask();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _WriterProperty != null)
			{
				_WriterProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void UpdateTask()
	{
		TableLayoutPanel1 = new TableLayoutPanel();
		OK_Button = new DarkUIButton();
		Cancel_Button = new DarkUIButton();
		Label1 = new DarkLabel();
		TB_PatrolName = new DarkUITextBox();
		TableLayoutPanel1.SuspendLayout();
		SuspendLayout();
		TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.Controls.Add(OK_Button, 0, 0);
		TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0);
		TableLayoutPanel1.Location = new Point(154, 45);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.Size = new Size(146, 29);
		TableLayoutPanel1.TabIndex = 0;
		OK_Button.Anchor = AnchorStyles.None;
		OK_Button.Location = new Point(3, 3);
		OK_Button.Name = "OK_Button";
		OK_Button.Size = new Size(67, 23);
		OK_Button.TabIndex = 0;
		OK_Button.Text = "确定";
		Cancel_Button.Anchor = AnchorStyles.None;
		Cancel_Button.Location = new Point(76, 3);
		Cancel_Button.Name = "Cancel_Button";
		Cancel_Button.Size = new Size(67, 23);
		Cancel_Button.TabIndex = 1;
		Cancel_Button.Text = "取消";
		Label1.AutoSize = true;
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(63, 13);
		Label1.TabIndex = 1;
		Label1.Text = "Patrol name";
		TB_PatrolName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_PatrolName.Location = new Point(82, 10);
		TB_PatrolName.Name = "TB_PatrolName";
		TB_PatrolName.Size = new Size(215, 20);
		TB_PatrolName.TabIndex = 2;
		base.AcceptButton = OK_Button;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.CancelButton = Cancel_Button;
		base.ClientSize = new Size(312, 86);
		base.Controls.Add(TB_PatrolName);
		base.Controls.Add(Label1);
		base.Controls.Add(TableLayoutPanel1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddPatrol";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Add new Patrol";
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void InsertTask(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void PrepareTask(object sender, FormClosingEventArgs e)
	{
		Client.CurrentUserAction = Client.UserAction.None;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ReflectTask(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (_TaskProperty)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				OK_Button.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!_TaskProperty && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void VisitTask(object sender, EventArgs e)
	{
		_TaskProperty = true;
	}

	private void RestartTask(object sender, EventArgs e)
	{
		_TaskProperty = false;
		OK_Button.Select();
	}

	private void TestTask(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
