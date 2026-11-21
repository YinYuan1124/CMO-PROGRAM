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
public sealed class ScoringWindow : DarkSecondaryFormBase
{
	private IContainer _TestsSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_ContainerSingleton;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel composerSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MajorVictory")]
	private DarkLabel modelSingleton;

	[AccessedThroughProperty("Label_MinorVictory")]
	[CompilerGenerated]
	private DarkLabel advisorSingleton;

	[AccessedThroughProperty("Label_Average")]
	[CompilerGenerated]
	private DarkLabel customerSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MajorDefeat")]
	private DarkLabel refSingleton;

	[AccessedThroughProperty("NUD_Disaster")]
	[CompilerGenerated]
	private DarkNumericUpDown errorSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Triumph")]
	private DarkNumericUpDown codeSingleton;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ContainerSingleton = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return composerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerSingleton = value;
		}
	}

	internal DarkLabel Label_MajorVictory
	{
		[CompilerGenerated]
		get
		{
			return modelSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelSingleton = value;
		}
	}

	internal DarkLabel Label_MinorVictory
	{
		[CompilerGenerated]
		get
		{
			return advisorSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			advisorSingleton = value;
		}
	}

	internal DarkLabel Label_Average
	{
		[CompilerGenerated]
		get
		{
			return customerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerSingleton = value;
		}
	}

	[field: AccessedThroughProperty("Label_MinorDefeat")]
	internal DarkLabel Label_MinorDefeat
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_MajorDefeat
	{
		[CompilerGenerated]
		get
		{
			return refSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			refSingleton = value;
		}
	}

	internal DarkNumericUpDown NUD_Disaster
	{
		[CompilerGenerated]
		get
		{
			return errorSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate
			{
				ComputeInterruptibleServer();
			};
			DarkNumericUpDown darkNumericUpDown = errorSingleton;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.ValueChanged -= value2;
			}
			errorSingleton = value;
			darkNumericUpDown = errorSingleton;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.ValueChanged += value2;
			}
		}
	}

	internal DarkNumericUpDown NUD_Triumph
	{
		[CompilerGenerated]
		get
		{
			return codeSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate
			{
				PatchInterruptibleServer();
			};
			DarkNumericUpDown darkNumericUpDown = codeSingleton;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.ValueChanged -= value2;
			}
			codeSingleton = value;
			darkNumericUpDown = codeSingleton;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.ValueChanged += value2;
			}
		}
	}

	public ScoringWindow()
	{
		base.Load += delegate
		{
			NUD_Disaster.Maximum = 2147483647m;
			NUD_Disaster.Minimum = -2147483648m;
			NUD_Triumph.Maximum = 2147483647m;
			NUD_Triumph.Minimum = -2147483648m;
			if (!Client.CurrentSide.Scoring_Disaster.HasValue)
			{
				Client.CurrentSide.Scoring_Disaster = -100;
			}
			NUD_Disaster.Value = new decimal(Client.CurrentSide.Scoring_Disaster.Value);
			if (!Client.CurrentSide.Scoring_Triumph.HasValue)
			{
				Client.CurrentSide.Scoring_Triumph = 100;
			}
			NUD_Triumph.Value = new decimal(Client.CurrentSide.Scoring_Triumph.Value);
		};
		base.KeyDown += SelectInterruptibleServer;
		base.FormClosing += CallInterruptibleServer;
		AddInterruptibleServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _TestsSingleton != null)
			{
				_TestsSingleton.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AddInterruptibleServer()
	{
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label8 = new DarkLabel();
		Label_MajorVictory = new DarkLabel();
		Label_MinorVictory = new DarkLabel();
		Label_Average = new DarkLabel();
		Label_MinorDefeat = new DarkLabel();
		Label_MajorDefeat = new DarkLabel();
		NUD_Disaster = new DarkNumericUpDown();
		NUD_Triumph = new DarkNumericUpDown();
		((ISupportInitialize)NUD_Disaster).BeginInit();
		((ISupportInitialize)NUD_Triumph).BeginInit();
		SuspendLayout();
		Label1.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(217, 20);
		Label1.TabIndex = 0;
		Label1.Text = "获胜阀值";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(14, 56);
		Label2.Name = "Label2";
		Label2.Size = new Size(56, 13);
		Label2.TabIndex = 1;
		Label2.Text = "灾难：";
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(14, 228);
		Label8.Name = "Label8";
		Label8.Size = new Size(56, 13);
		Label8.TabIndex = 11;
		Label8.Text = "胜利：";
		Label_MajorVictory.AutoSize = true;
		Label_MajorVictory.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MajorVictory.Location = new Point(14, 199);
		Label_MajorVictory.Name = "Label_MajorVictory";
		Label_MajorVictory.Size = new Size(81, 15);
		Label_MajorVictory.TabIndex = 10;
		Label_MajorVictory.Text = "主要胜利：";
		Label_MinorVictory.AutoSize = true;
		Label_MinorVictory.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MinorVictory.Location = new Point(14, 171);
		Label_MinorVictory.Name = "Label_MinorVictory";
		Label_MinorVictory.Size = new Size(82, 15);
		Label_MinorVictory.TabIndex = 9;
		Label_MinorVictory.Text = "小胜利：";
		Label_Average.AutoSize = true;
		Label_Average.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Average.Location = new Point(14, 142);
		Label_Average.Name = "Label_Average";
		Label_Average.Size = new Size(53, 15);
		Label_Average.TabIndex = 7;
		Label_Average.Text = "平均：";
		Label_MinorDefeat.AutoSize = true;
		Label_MinorDefeat.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MinorDefeat.Location = new Point(14, 114);
		Label_MinorDefeat.Name = "Label_MinorDefeat";
		Label_MinorDefeat.Size = new Size(79, 15);
		Label_MinorDefeat.TabIndex = 5;
		Label_MinorDefeat.Text = "轻微失败：";
		Label_MajorDefeat.AutoSize = true;
		Label_MajorDefeat.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MajorDefeat.Location = new Point(14, 87);
		Label_MajorDefeat.Name = "Label_MajorDefeat";
		Label_MajorDefeat.Size = new Size(78, 15);
		Label_MajorDefeat.TabIndex = 3;
		Label_MajorDefeat.Text = "重大失败：";
		NUD_Disaster.BackColor = Color.FromArgb(28, 28, 28);
		NUD_Disaster.BorderStyle = BorderStyle.None;
		NUD_Disaster.Font = new Font("Segoe UI", 12f);
		NUD_Disaster.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_Disaster.Location = new Point(98, 52);
		NUD_Disaster.Name = "NUD_Disaster";
		NUD_Disaster.Size = new Size(132, 25);
		NUD_Disaster.TabIndex = 24;
		NUD_Triumph.BackColor = Color.FromArgb(28, 28, 28);
		NUD_Triumph.BorderStyle = BorderStyle.None;
		NUD_Triumph.Font = new Font("Segoe UI", 12f);
		NUD_Triumph.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_Triumph.Location = new Point(98, 224);
		NUD_Triumph.Name = "NUD_Triumph";
		NUD_Triumph.Size = new Size(132, 25);
		NUD_Triumph.TabIndex = 25;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(243, 260);
		base.Controls.Add(NUD_Triumph);
		base.Controls.Add(NUD_Disaster);
		base.Controls.Add(Label_MajorVictory);
		base.Controls.Add(Label_MinorVictory);
		base.Controls.Add(Label_Average);
		base.Controls.Add(Label_MinorDefeat);
		base.Controls.Add(Label_MajorDefeat);
		base.Controls.Add(Label8);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ScoringWindow";
		base.ShowIcon = false;
		Text = "分数";
		((ISupportInitialize)NUD_Disaster).EndInit();
		((ISupportInitialize)NUD_Triumph).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void DestroyInterruptibleServer(object sender, EventArgs e)
	{
		NUD_Disaster.Maximum = 2147483647m;
		NUD_Disaster.Minimum = -2147483648m;
		NUD_Triumph.Maximum = 2147483647m;
		NUD_Triumph.Minimum = -2147483648m;
		if (!Client.CurrentSide.Scoring_Disaster.HasValue)
		{
			Client.CurrentSide.Scoring_Disaster = -100;
		}
		NUD_Disaster.Value = new decimal(Client.CurrentSide.Scoring_Disaster.Value);
		if (!Client.CurrentSide.Scoring_Triumph.HasValue)
		{
			Client.CurrentSide.Scoring_Triumph = 100;
		}
		NUD_Triumph.Value = new decimal(Client.CurrentSide.Scoring_Triumph.Value);
	}

	private void ComputeInterruptibleServer()
	{
		if (Versioned.IsNumeric(NUD_Disaster.Value))
		{
			Client.CurrentSide.Scoring_Disaster = Convert.ToInt32(NUD_Disaster.Value);
			Label_MajorDefeat.Text = "重大失败：" + Conversions.ToString(Client.CurrentSide.Scoring_MajorDefeat);
			Label_MinorDefeat.Text = "轻微失败：" + Conversions.ToString(Client.CurrentSide.Scoring_MinorDefeat);
			Label_Average.Text = "平均：" + Conversions.ToString(Client.CurrentSide.Scoring_Average);
			Label_MinorVictory.Text = "小胜利：" + Conversions.ToString(Client.CurrentSide.Scoring_MinorVictory);
			Label_MajorVictory.Text = "主要胜利：" + Conversions.ToString(Client.CurrentSide.Scoring_MajorVictory);
		}
	}

	private void PatchInterruptibleServer()
	{
		if (Versioned.IsNumeric(NUD_Triumph.Value))
		{
			Client.CurrentSide.Scoring_Triumph = Convert.ToInt32(NUD_Triumph.Value);
			Label_MajorDefeat.Text = "重大失败：" + Conversions.ToString(Client.CurrentSide.Scoring_MajorDefeat);
			Label_MinorDefeat.Text = "轻微失败：" + Conversions.ToString(Client.CurrentSide.Scoring_MinorDefeat);
			Label_Average.Text = "平均：" + Conversions.ToString(Client.CurrentSide.Scoring_Average);
			Label_MinorVictory.Text = "小胜利：" + Conversions.ToString(Client.CurrentSide.Scoring_MinorVictory);
			Label_MajorVictory.Text = "主要胜利：" + Conversions.ToString(Client.CurrentSide.Scoring_MajorVictory);
		}
	}

	private void SelectInterruptibleServer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.End && e.KeyCode != Keys.Home && (e.KeyCode != Keys.C || e.Modifiers != Keys.Control) && (e.KeyCode != Keys.X || e.Modifiers != Keys.Control) && (e.KeyCode != Keys.V || e.Modifiers != Keys.Control)))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CallInterruptibleServer(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	[SpecialName]
	[CompilerGenerated]
	private void NUD_Disaster_ValueChanged(object sender, EventArgs e)
	{
		ComputeInterruptibleServer();
	}

	[SpecialName]
	[CompilerGenerated]
	private void NUD_Triumph_ValueChanged(object sender, EventArgs e)
	{
		PatchInterruptibleServer();
	}

	[CompilerGenerated]
	private void LogoutInterruptibleServer(object sender, EventArgs e)
	{
		ComputeInterruptibleServer();
	}

	[CompilerGenerated]
	private void ViewInterruptibleServer(object sender, EventArgs e)
	{
		PatchInterruptibleServer();
	}

	[CompilerGenerated]
	private void ValidateInterruptibleServer(object sender, EventArgs e)
	{
		NUD_Disaster.Maximum = 2147483647m;
		NUD_Disaster.Minimum = -2147483648m;
		NUD_Triumph.Maximum = 2147483647m;
		NUD_Triumph.Minimum = -2147483648m;
		if (!Client.CurrentSide.Scoring_Disaster.HasValue)
		{
			Client.CurrentSide.Scoring_Disaster = -100;
		}
		NUD_Disaster.Value = new decimal(Client.CurrentSide.Scoring_Disaster.Value);
		if (!Client.CurrentSide.Scoring_Triumph.HasValue)
		{
			Client.CurrentSide.Scoring_Triumph = 100;
		}
		NUD_Triumph.Value = new decimal(Client.CurrentSide.Scoring_Triumph.Value);
	}
}
