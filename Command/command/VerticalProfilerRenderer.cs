using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class VerticalProfilerRenderer : Form
{
	private IContainer observerExporter;

	[AccessedThroughProperty("ElementHost1")]
	[CompilerGenerated]
	private ElementHost issuerExporter;

	[AccessedThroughProperty("Label_TopAltitude")]
	[CompilerGenerated]
	private Label m_ClientExporter;

	[AccessedThroughProperty("Label_BottomAltitude")]
	[CompilerGenerated]
	private Label m_DicExporter;

	[AccessedThroughProperty("PictureBox1")]
	[CompilerGenerated]
	private PictureBox facadeExporter;

	public SensorTerrainRendererControl Renderer;

	internal ElementHost ElementHost1
	{
		[CompilerGenerated]
		get
		{
			return issuerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			issuerExporter = value;
		}
	}

	internal Label Label_TopAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_ClientExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClientExporter = value;
		}
	}

	internal Label Label_BottomAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_DicExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DicExporter = value;
		}
	}

	[field: AccessedThroughProperty("PictureSubjectA")]
	internal PictureBox PictureSubjectA
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return facadeExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			facadeExporter = value;
		}
	}

	public VerticalProfilerRenderer()
	{
		base.Load += RegisterInterruptibleSetter;
		OrderInterruptibleSetter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && observerExporter != null)
			{
				observerExporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void OrderInterruptibleSetter()
	{
		ElementHost1 = new ElementHost();
		Label_TopAltitude = new Label();
		Label_BottomAltitude = new Label();
		PictureSubjectA = new PictureBox();
		PictureBox1 = new PictureBox();
		((ISupportInitialize)PictureSubjectA).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		ElementHost1.Location = new Point(80, 24);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(1350, 800);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = null;
		Label_TopAltitude.AutoSize = true;
		Label_TopAltitude.Location = new Point(77, 9);
		Label_TopAltitude.Name = "Label_TopAltitude";
		Label_TopAltitude.Size = new Size(51, 13);
		Label_TopAltitude.TabIndex = 1;
		Label_TopAltitude.Text = "100000m";
		Label_BottomAltitude.AutoSize = true;
		Label_BottomAltitude.Location = new Point(77, 827);
		Label_BottomAltitude.Name = "Label_BottomAltitude";
		Label_BottomAltitude.Size = new Size(51, 13);
		Label_BottomAltitude.TabIndex = 2;
		Label_BottomAltitude.Text = "100000m";
		PictureSubjectA.BackgroundImageLayout = ImageLayout.Stretch;
		PictureSubjectA.Location = new Point(22, 24);
		PictureSubjectA.Name = "PictureSubjectA";
		PictureSubjectA.Size = new Size(32, 32);
		PictureSubjectA.SizeMode = PictureBoxSizeMode.StretchImage;
		PictureSubjectA.TabIndex = 3;
		PictureSubjectA.TabStop = false;
		PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
		PictureBox1.Location = new Point(1455, 24);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(32, 32);
		PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		PictureBox1.TabIndex = 4;
		PictureBox1.TabStop = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1508, 845);
		base.Controls.Add(PictureBox1);
		base.Controls.Add(PictureSubjectA);
		base.Controls.Add(Label_BottomAltitude);
		base.Controls.Add(Label_TopAltitude);
		base.Controls.Add(ElementHost1);
		base.Name = "SensorTerrainRenderer";
		Text = "Vertical Profiler";
		((ISupportInitialize)PictureSubjectA).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public bool IsReadyToRender()
	{
		if (Information.IsNothing(Renderer))
		{
			return false;
		}
		return Renderer.IsReadyToRender();
	}

	private void RegisterInterruptibleSetter(object sender, EventArgs e)
	{
		Renderer = new SensorTerrainRendererControl();
		int count = Client.CurrentSide.SelectedUnits.Count;
		if (count <= 2)
		{
			if (count < 2)
			{
				DarkMessageBox.ShowWarning("You have selected " + count + " subject, please select 2 subjects (reference point or units) ", "Not enough subjects", DarkDialogButton.Close);
				return;
			}
			List<SensorTerrainRendererControl.Subject> list = new List<SensorTerrainRendererControl.Subject>();
			foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
			{
				list.Add(new SensorTerrainRendererControl.Subject(selectedUnit));
			}
			ElementHost1.Child = Renderer;
			Renderer.Refresh(list.ElementAt(0), list.ElementAt(1), this);
		}
		else
		{
			DarkMessageBox.ShowWarning("You have selected " + count + " subject, please select only 2 subjects (reference point or units) ", "Too many subjects", DarkDialogButton.Close);
		}
	}
}
