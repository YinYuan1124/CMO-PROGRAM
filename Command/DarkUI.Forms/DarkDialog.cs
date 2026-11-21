using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;

namespace DarkUI.Forms;

public class DarkDialog : DarkForm
{
	private DarkDialogButton m_ServiceObject;

	private List<DarkButton> m_SystemObject;

	protected DarkButton btnOk;

	protected DarkButton btnCancel;

	protected DarkButton btnClose;

	protected DarkButton btnYes;

	protected DarkButton btnNo;

	protected DarkButton btnAbort;

	protected DarkButton btnRetry;

	protected DarkButton btnIgnore;

	private IContainer candidateObject;

	private Panel baseObject;

	private FlowLayoutPanel policyObject;

	[Description("Determines the type of the dialog window.")]
	[DefaultValue(DarkDialogButton.Ok)]
	public DarkDialogButton DialogButtons
	{
		get
		{
			return m_ServiceObject;
		}
		set
		{
			if (m_ServiceObject != value)
			{
				m_ServiceObject = value;
				CloneListener();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int TotalButtonSize { get; private set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new IButtonControl AcceptButton
	{
		get
		{
			return base.AcceptButton;
		}
		private set
		{
			base.AcceptButton = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public new IButtonControl CancelButton
	{
		get
		{
			return base.CancelButton;
		}
		private set
		{
			base.CancelButton = value;
		}
	}

	public DarkDialog()
	{
		DeleteListener();
		m_SystemObject = new List<DarkButton> { btnAbort, btnRetry, btnIgnore, btnOk, btnCancel, btnClose, btnYes, btnNo };
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		CloneListener();
	}

	private void CloneListener()
	{
		foreach (DarkButton item in m_SystemObject)
		{
			item.Visible = false;
		}
		switch (m_ServiceObject)
		{
		case DarkDialogButton.Ok:
			ConnectListener(btnOk, bool_0: true);
			AcceptButton = btnOk;
			break;
		case DarkDialogButton.Close:
			ConnectListener(btnClose, bool_0: true);
			AcceptButton = btnClose;
			CancelButton = btnClose;
			break;
		case DarkDialogButton.OkCancel:
			ConnectListener(btnOk);
			ConnectListener(btnCancel, bool_0: true);
			AcceptButton = btnOk;
			CancelButton = btnCancel;
			break;
		case DarkDialogButton.YesNo:
			ConnectListener(btnYes);
			ConnectListener(btnNo, bool_0: true);
			AcceptButton = btnYes;
			CancelButton = btnNo;
			break;
		case DarkDialogButton.YesNoCancel:
			ConnectListener(btnYes);
			ConnectListener(btnNo);
			ConnectListener(btnCancel, bool_0: true);
			AcceptButton = btnYes;
			CancelButton = btnCancel;
			break;
		case DarkDialogButton.AbortRetryIgnore:
			ConnectListener(btnAbort);
			ConnectListener(btnRetry);
			ConnectListener(btnIgnore, bool_0: true);
			AcceptButton = btnAbort;
			CancelButton = btnIgnore;
			break;
		case DarkDialogButton.RetryCancel:
			ConnectListener(btnRetry);
			ConnectListener(btnCancel, bool_0: true);
			AcceptButton = btnRetry;
			CancelButton = btnCancel;
			break;
		}
		MoveListener();
	}

	private void ConnectListener(DarkButton darkButton_0, bool bool_0 = false)
	{
		darkButton_0.SendToBack();
		if (!bool_0)
		{
			darkButton_0.Margin = new Padding(0, 0, 10, 0);
		}
		darkButton_0.Visible = true;
	}

	private void MoveListener()
	{
		int num = policyObject.Padding.Horizontal;
		foreach (DarkButton item in m_SystemObject)
		{
			if (item.Visible)
			{
				num += item.Width + item.Margin.Right;
			}
		}
		policyObject.Width = num;
		TotalButtonSize = num;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && candidateObject != null)
		{
			candidateObject.Dispose();
		}
		base.Dispose(disposing);
	}

	private void DeleteListener()
	{
		baseObject = new Panel();
		policyObject = new FlowLayoutPanel();
		btnOk = new DarkButton();
		btnCancel = new DarkButton();
		btnClose = new DarkButton();
		btnYes = new DarkButton();
		btnNo = new DarkButton();
		btnAbort = new DarkButton();
		btnRetry = new DarkButton();
		btnIgnore = new DarkButton();
		baseObject.SuspendLayout();
		policyObject.SuspendLayout();
		SuspendLayout();
		baseObject.Controls.Add(policyObject);
		baseObject.Dock = DockStyle.Bottom;
		baseObject.Location = new Point(0, 357);
		baseObject.Name = "pnlFooter";
		baseObject.Size = new Size(767, 45);
		baseObject.TabIndex = 1;
		policyObject.Controls.Add(btnOk);
		policyObject.Controls.Add(btnCancel);
		policyObject.Controls.Add(btnClose);
		policyObject.Controls.Add(btnYes);
		policyObject.Controls.Add(btnNo);
		policyObject.Controls.Add(btnAbort);
		policyObject.Controls.Add(btnRetry);
		policyObject.Controls.Add(btnIgnore);
		policyObject.Dock = DockStyle.Right;
		policyObject.Location = new Point(104, 0);
		policyObject.Name = "flowInner";
		policyObject.Padding = new Padding(10);
		policyObject.Size = new Size(663, 45);
		policyObject.TabIndex = 10014;
		btnOk.DialogResult = DialogResult.OK;
		btnOk.Location = new Point(10, 10);
		btnOk.Margin = new Padding(0);
		btnOk.Name = "btnOk";
		btnOk.Padding = new Padding(5);
		btnOk.Size = new Size(75, 26);
		btnOk.TabIndex = 3;
		btnOk.Text = "Ok";
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.Location = new Point(85, 10);
		btnCancel.Margin = new Padding(0);
		btnCancel.Name = "btnCancel";
		btnCancel.Padding = new Padding(5);
		btnCancel.Size = new Size(75, 26);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Cancel";
		btnClose.DialogResult = DialogResult.Cancel;
		btnClose.Location = new Point(160, 10);
		btnClose.Margin = new Padding(0);
		btnClose.Name = "btnClose";
		btnClose.Padding = new Padding(5);
		btnClose.Size = new Size(75, 26);
		btnClose.TabIndex = 5;
		btnClose.Text = "Close";
		btnYes.DialogResult = DialogResult.Yes;
		btnYes.Location = new Point(235, 10);
		btnYes.Margin = new Padding(0);
		btnYes.Name = "btnYes";
		btnYes.Padding = new Padding(5);
		btnYes.Size = new Size(75, 26);
		btnYes.TabIndex = 6;
		btnYes.Text = "Yes";
		btnNo.DialogResult = DialogResult.No;
		btnNo.Location = new Point(310, 10);
		btnNo.Margin = new Padding(0);
		btnNo.Name = "btnNo";
		btnNo.Padding = new Padding(5);
		btnNo.Size = new Size(75, 26);
		btnNo.TabIndex = 7;
		btnNo.Text = "No";
		btnAbort.DialogResult = DialogResult.Abort;
		btnAbort.Location = new Point(385, 10);
		btnAbort.Margin = new Padding(0);
		btnAbort.Name = "btnAbort";
		btnAbort.Padding = new Padding(5);
		btnAbort.Size = new Size(75, 26);
		btnAbort.TabIndex = 8;
		btnAbort.Text = "Abort";
		btnRetry.DialogResult = DialogResult.Retry;
		btnRetry.Location = new Point(460, 10);
		btnRetry.Margin = new Padding(0);
		btnRetry.Name = "btnRetry";
		btnRetry.Padding = new Padding(5);
		btnRetry.Size = new Size(75, 26);
		btnRetry.TabIndex = 9;
		btnRetry.Text = "Retry";
		btnIgnore.DialogResult = DialogResult.Ignore;
		btnIgnore.Location = new Point(535, 10);
		btnIgnore.Margin = new Padding(0);
		btnIgnore.Name = "btnIgnore";
		btnIgnore.Padding = new Padding(5);
		btnIgnore.Size = new Size(75, 26);
		btnIgnore.TabIndex = 10;
		btnIgnore.Text = "Ignore";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.ClientSize = new Size(767, 402);
		base.Controls.Add(baseObject);
		base.Name = "DarkDialog";
		Text = "DarkDialog";
		baseObject.ResumeLayout(performLayout: false);
		policyObject.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
