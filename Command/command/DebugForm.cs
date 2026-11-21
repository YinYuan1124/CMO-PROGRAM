using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Command.Filters;
using Command.Tacview;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Worldwind.Component;

namespace Command;

[DesignerGenerated]
public sealed class DebugForm : Form
{
	[CompilerGenerated]
	private sealed class ReaderMap
	{
		public string Local_s;
	}

	[CompilerGenerated]
	private sealed class ConnectionDecoratorEntry
	{
		public DebugForm Me;

		public ReaderMap CS_0024_003C_003E8__locals1;

		internal void NewInterruptiblePage()
		{
			Me.TextBox1.AppendText(CS_0024_003C_003E8__locals1.Local_s);
		}
	}

	private IContainer _InstanceTokenizer;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox objectTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer _ParameterTokenizer;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label m_ExpressionTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox2")]
	private TextBox dispatcherTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button _ListenerTokenizer;

	[AccessedThroughProperty("CheckedListBox1")]
	[CompilerGenerated]
	private CheckedListBox m_ConfigTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private Button registryTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private Button m_DefinitionTokenizer;

	private Dispatcher valTokenizer;

	private ConcurrentQueue<string> wrapperTokenizer;

	private Thread m_ObserverTokenizer;

	private bool m_IssuerTokenizer;

	private bool m_ClientTokenizer;

	internal TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return objectTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectTokenizer = value;
		}
	}

	internal Label Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExpressionTokenizer = value;
		}
	}

	internal TextBox TextBox2
	{
		[CompilerGenerated]
		get
		{
			return dispatcherTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherTokenizer = value;
		}
	}

	internal Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _ListenerTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindServer;
			Button listenerTokenizer = _ListenerTokenizer;
			if (listenerTokenizer != null)
			{
				listenerTokenizer.Click -= value2;
			}
			_ListenerTokenizer = value;
			listenerTokenizer = _ListenerTokenizer;
			if (listenerTokenizer != null)
			{
				listenerTokenizer.Click += value2;
			}
		}
	}

	internal CheckedListBox CheckedListBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ItemCheckEventHandler value2 = SetServer;
			CheckedListBox configTokenizer = m_ConfigTokenizer;
			if (configTokenizer != null)
			{
				configTokenizer.ItemCheck -= value2;
			}
			m_ConfigTokenizer = value;
			configTokenizer = m_ConfigTokenizer;
			if (configTokenizer != null)
			{
				configTokenizer.ItemCheck += value2;
			}
		}
	}

	internal Button Button2
	{
		[CompilerGenerated]
		get
		{
			return registryTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillServer;
			Button button = registryTokenizer;
			if (button != null)
			{
				button.Click -= value2;
			}
			registryTokenizer = value;
			button = registryTokenizer;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal Button Button3
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateServer;
			Button definitionTokenizer = m_DefinitionTokenizer;
			if (definitionTokenizer != null)
			{
				definitionTokenizer.Click -= value2;
			}
			m_DefinitionTokenizer = value;
			definitionTokenizer = m_DefinitionTokenizer;
			if (definitionTokenizer != null)
			{
				definitionTokenizer.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer CreateServer()
	{
		return _ParameterTokenizer;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CompareServer(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = RemoveServer;
		System.Windows.Forms.Timer parameterTokenizer = _ParameterTokenizer;
		if (parameterTokenizer != null)
		{
			parameterTokenizer.Tick -= value;
		}
		_ParameterTokenizer = timer_0;
		parameterTokenizer = _ParameterTokenizer;
		if (parameterTokenizer != null)
		{
			parameterTokenizer.Tick += value;
		}
	}

	public DebugForm()
	{
		base.FormClosing += ConcatServer;
		base.Load += InterruptServer;
		wrapperTokenizer = new ConcurrentQueue<string>();
		m_IssuerTokenizer = false;
		m_ClientTokenizer = false;
		CheckServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _InstanceTokenizer != null)
			{
				_InstanceTokenizer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CheckServer()
	{
		_InstanceTokenizer = new Container();
		TextBox1 = new TextBox();
		CompareServer(new System.Windows.Forms.Timer(_InstanceTokenizer));
		Label1 = new Label();
		TextBox2 = new TextBox();
		Button1 = new Button();
		CheckedListBox1 = new CheckedListBox();
		Button2 = new Button();
		Button3 = new Button();
		SuspendLayout();
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.Location = new Point(12, 12);
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.Size = new Size(511, 725);
		TextBox1.TabIndex = 0;
		CreateServer().Enabled = true;
		CreateServer().Interval = 1000;
		Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label1.AutoSize = true;
		Label1.Location = new Point(885, 12);
		Label1.Name = "Label1";
		Label1.Size = new Size(37, 13);
		Label1.TabIndex = 1;
		Label1.Text = "状态";
		TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TextBox2.Location = new Point(884, 28);
		TextBox2.Multiline = true;
		TextBox2.Name = "TextBox2";
		TextBox2.Size = new Size(229, 652);
		TextBox2.TabIndex = 2;
		Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button1.Location = new Point(888, 713);
		Button1.Name = "Button1";
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 3;
		Button1.Text = "重置DX";
		Button1.UseVisualStyleBackColor = true;
		CheckedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		CheckedListBox1.ColumnWidth = 160;
		CheckedListBox1.FormattingEnabled = true;
		CheckedListBox1.Location = new Point(529, 12);
		CheckedListBox1.MultiColumn = true;
		CheckedListBox1.Name = "CheckedListBox1";
		CheckedListBox1.Size = new Size(349, 724);
		CheckedListBox1.TabIndex = 4;
		Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button2.Location = new Point(1013, 686);
		Button2.Name = "Button2";
		Button2.Size = new Size(100, 23);
		Button2.TabIndex = 3;
		Button2.Text = "重置TacView";
		Button2.UseVisualStyleBackColor = true;
		Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button3.Location = new Point(969, 715);
		Button3.Name = "Button3";
		Button3.Size = new Size(144, 23);
		Button3.TabIndex = 3;
		Button3.Text = "向TacView发送测试数据";
		Button3.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1129, 748);
		base.Controls.Add(CheckedListBox1);
		base.Controls.Add(Button3);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox2);
		base.Controls.Add(Label1);
		base.Controls.Add(TextBox1);
		base.Name = "DebugForm";
		Text = "DebugForm";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public bool isInitialised()
	{
		return m_ClientTokenizer;
	}

	public void Init()
	{
		valTokenizer = Dispatcher.CurrentDispatcher;
		m_ObserverTokenizer = new Thread(ThreadSubroutine);
		m_ObserverTokenizer.Start();
		CheckedListBox1.Items.Add("DrawArea1", isChecked: true);
		CheckedListBox1.Items.Add("DrawEllipse1", isChecked: true);
		CheckedListBox1.Items.Add("FillEllipse1", isChecked: true);
		CheckedListBox1.Items.Add("FillRectangle1", isChecked: true);
		CheckedListBox1.Items.Add("FillPolygon1", isChecked: true);
		CheckedListBox1.Items.Add("FillPolygon2", isChecked: true);
		CheckedListBox1.Items.Add("FillPolygon3", isChecked: true);
		CheckedListBox1.Items.Add("DrawTransientBitmap", isChecked: true);
		CheckedListBox1.Items.Add("DrawIcon1", isChecked: true);
		CheckedListBox1.Items.Add("DrawIconRotated", isChecked: true);
		CheckedListBox1.Items.Add("DrawLine1", isChecked: true);
		CheckedListBox1.Items.Add("DrawLine2", isChecked: true);
		CheckedListBox1.Items.Add("DrawLine3", isChecked: true);
		CheckedListBox1.Items.Add("DrawDashedLine1", isChecked: true);
		CheckedListBox1.Items.Add("DrawDashedLine2", isChecked: true);
		CheckedListBox1.Items.Add("DrawLine4", isChecked: true);
		CheckedListBox1.Items.Add("DrawLine5", isChecked: true);
		CheckedListBox1.Items.Add("DrawClosedPointLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawDashedClosedPointLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawGraphicsPathLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawPrimitiveLineStrip", isChecked: true);
		CheckedListBox1.Items.Add("DrawPrimitiveLineList", isChecked: true);
		CheckedListBox1.Items.Add("DrawGradientLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawLoxodromicLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawOrthodromicLine", isChecked: true);
		CheckedListBox1.Items.Add("DrawGeoText", isChecked: true);
		CheckedListBox1.Items.Add("DrawText", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawUncertaintyArea", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawActiveUnit", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFormationStation", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawActiveUnitDatablock", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMovementVector", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMouseHoverRectangleAndDatablock", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawContact", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawHealthBarForThisContact", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFireDamageBarForThisContact", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFloodDamageBarForThisContact", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawContactDatablock", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawContactEmissions", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMissionAreas", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMissionArea", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPatrolBox", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawLOS", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawArea", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawPathIfPointsVisible", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPlottedCourses", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPlottedCourse", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawSalvoPlottedCourse", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFlightPlans_Planned", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFlightPlan", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawWeaponRoute", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawWeaponRouteWaypoints", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFlightPlan", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawFlightPlanWaypoints", isChecked: true);
		CheckedListBox1.Items.Add("CL_RangeWedgeArc_Draw", isChecked: true);
		CheckedListBox1.Items.Add("CL_RangeCircle_Draw", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_Merged_Friendly", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_NonFriendly", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_SelectedUnit", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_SelectedUnit_Nonfriendly", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_SingleUnits", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_SingleGroups", isChecked: true);
		CheckedListBox1.Items.Add("CLX_DrawRangeSymbols_SingleGroups_Nonfriendly", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawRangeSymbols", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCZRings", isChecked: true);
		CheckedListBox1.Items.Add("CL_RangeWedges_Draw", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPathIfPointsVisible", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPathIfPointsVisible2", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawUnderwaterUnguidedWeapons", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawUnguidedWeapons", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawChaffClouds", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawTargetingVectors", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawIlluminationVectors", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCommLinks", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawTargettingVector", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawIlluminationVector", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCommLink", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawEventBalloons", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawStatusCaption", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawSelectedUnitsText", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawDataCursor", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMeasuringLine", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawEventEditorAreas", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawWaterSplashes", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawGroundImpacts", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawMineSweep", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawSelectedMountArcs", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawOrbitPath", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawGroupLeashes", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawGroupLeash", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawHealthBars", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawHealthBarForThisUnit", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFuelBars", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawFuelBarForThisUnit", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawUnitSelectionRectangles", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawSelectionRectangle", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawWeaponImpacts", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawExplosions", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCanals", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawPierLanes", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawExclusionZone", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawNoNavZones", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawRefPoints", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCoursePreview", isChecked: true);
		CheckedListBox1.Items.Add("CL_DrawCustomEnvironmentZones", isChecked: true);
		m_ClientTokenizer = true;
	}

	public void ThreadSubroutine()
	{
		string Local_s = null;
		while (!m_IssuerTokenizer)
		{
			try
			{
				Thread.Sleep(100);
				StringBuilder stringBuilder = new StringBuilder();
				while (wrapperTokenizer.TryDequeue(out Local_s))
				{
					stringBuilder.Append(Local_s + "\r\n");
				}
				Local_s = stringBuilder.ToString();
				try
				{
					valTokenizer.Invoke(delegate
					{
						TextBox1.AppendText(Local_s);
					});
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Write(string string_0)
	{
		try
		{
			wrapperTokenizer.Enqueue(string_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			wrapperTokenizer.Enqueue("Error in DebugForm.Write!");
			ProjectData.ClearProjectError();
		}
	}

	public void WriteException(string string_0, Exception exception_0)
	{
		try
		{
			wrapperTokenizer.Enqueue("WriteException()");
			wrapperTokenizer.Enqueue("Message: " + string_0);
			wrapperTokenizer.Enqueue($"e == null: {exception_0 == null}");
			wrapperTokenizer.Enqueue("e.GetType().Name: " + exception_0.GetType().Name);
			wrapperTokenizer.Enqueue("e.Message: " + exception_0.Message);
			wrapperTokenizer.Enqueue("e.StackTrace: " + exception_0.StackTrace);
			wrapperTokenizer.Enqueue($"e.InnerException  == null: {exception_0.InnerException == null}");
			if (exception_0.InnerException != null)
			{
				wrapperTokenizer.Enqueue("e.InnerException .GetType().Name: " + exception_0.GetType().Name);
				wrapperTokenizer.Enqueue("e.InnerException .Message: " + exception_0.Message);
				wrapperTokenizer.Enqueue("e.InnerException .StackTrace: " + exception_0.StackTrace);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void ConcatServer(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			base.Visible = false;
		}
		else
		{
			m_IssuerTokenizer = true;
		}
	}

	private void InterruptServer(object sender, EventArgs e)
	{
	}

	private void RemoveServer(object sender, EventArgs e)
	{
		CreateServer().Enabled = false;
	}

	private void FindServer(object sender, EventArgs e)
	{
	}

	private void SetServer(object sender, ItemCheckEventArgs e)
	{
		CommandLayer.SetAlaCarteDisabled(Conversions.ToString(CheckedListBox1.Items[e.Index]), e.NewValue == CheckState.Checked);
	}

	private void FillServer(object sender, EventArgs e)
	{
		TacviewClient tacviewClient = ConfigurationRegistryFilter.PublishInterruptibleMap().FirstOrDefault();
		if (tacviewClient == null)
		{
			Interaction.MsgBox("No TVC");
			return;
		}
		tacviewClient.Close();
		ConfigurationRegistryFilter.AssetInterruptibleMap();
	}

	private void CalculateServer(object sender, EventArgs e)
	{
		if (ConfigurationRegistryFilter.PublishInterruptibleMap().FirstOrDefault() == null)
		{
			Interaction.MsgBox("No TVC");
		}
	}
}
