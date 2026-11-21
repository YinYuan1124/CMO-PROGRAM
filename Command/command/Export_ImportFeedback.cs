using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class Export_ImportFeedback : Form
{
	private IContainer _IteratorList;

	[AccessedThroughProperty("LV_Main")]
	[CompilerGenerated]
	private DarkListView initializerList;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_RoleList;

	internal virtual DarkListView LV_Main
	{
		[CompilerGenerated]
		get
		{
			return initializerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerList = value;
		}
	}

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_RoleList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RoleList = value;
		}
	}

	public Export_ImportFeedback()
	{
		GetSystem();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _IteratorList != null)
			{
				_IteratorList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GetSystem()
	{
		LV_Main = new DarkListView();
		DarkLabel1 = new DarkLabel();
		SuspendLayout();
		LV_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_Main.BackColor = Color.FromArgb(50, 53, 55);
		LV_Main.Location = new Point(12, 40);
		LV_Main.Name = "LV_Main";
		LV_Main.RelatedInfos = null;
		LV_Main.Size = new Size(776, 398);
		LV_Main.TabIndex = 0;
		LV_Main.Text = "DarkListView1";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(13, 13);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(259, 13);
		DarkLabel1.TabIndex = 1;
		DarkLabel1.Text = "Your import attempt contains either warnings or errors.";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(800, 450);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(LV_Main);
		base.Name = "Export_ImportFeedback";
		Text = "Log";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
