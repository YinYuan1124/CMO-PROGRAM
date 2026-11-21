using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class AddReferencePointAtLocation : DarkSecondaryFormBase
{
	private IContainer _TokenProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton indexerProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private DarkUIButton _ResolverProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_Latitude")]
	private DarkUITextBox m_PublisherProperty;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel serverProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_Longitude")]
	private DarkUITextBox m_AdapterProperty;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel schemaProperty;

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return indexerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptFilter;
			DarkUIButton darkUIButton = indexerProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			indexerProperty = value;
			darkUIButton = indexerProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _ResolverProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatFilter;
			DarkUIButton resolverProperty = _ResolverProperty;
			if (resolverProperty != null)
			{
				resolverProperty.Click -= value2;
			}
			_ResolverProperty = value;
			resolverProperty = _ResolverProperty;
			if (resolverProperty != null)
			{
				resolverProperty.Click += value2;
			}
		}
	}

	internal virtual DarkUITextBox TextBox_Latitude
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PublisherProperty = value;
		}
	}

	internal virtual DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return serverProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverProperty = value;
		}
	}

	internal virtual DarkUITextBox TextBox_Longitude
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterProperty = value;
		}
	}

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return schemaProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			schemaProperty = value;
		}
	}

	public AddReferencePointAtLocation()
	{
		base.Load += CheckFilter;
		InitFilter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _TokenProperty != null)
			{
				_TokenProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InitFilter()
	{
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		TextBox_Latitude = new DarkUITextBox();
		Label1 = new DarkLabel();
		TextBox_Longitude = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		SuspendLayout();
		Button_Cancel.BackColor = Color.Transparent;
		Button_Cancel.DialogResult = DialogResult.None;
		Button_Cancel.Font = new Font("Segoe UI", 10f);
		Button_Cancel.ForeColor = SystemColors.Control;
		Button_Cancel.Location = new Point(165, 100);
		Button_Cancel.Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		Button_Cancel.Size = new Size(75, 23);
		Button_Cancel.TabIndex = 3;
		Button_Cancel.Text = "取消";
		Button_OK.BackColor = Color.Transparent;
		Button_OK.DialogResult = DialogResult.None;
		Button_OK.Font = new Font("Segoe UI", 10f);
		Button_OK.ForeColor = SystemColors.Control;
		Button_OK.Location = new Point(60, 100);
		Button_OK.Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		Button_OK.Size = new Size(75, 23);
		Button_OK.TabIndex = 2;
		Button_OK.Text = "确定";
		TextBox_Latitude.AutoCompleteCustomSource = null;
		TextBox_Latitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_Latitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_Latitude.BackColor = Color.Transparent;
		TextBox_Latitude.Font = new Font("Segoe UI", 10f);
		TextBox_Latitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Latitude.Image = null;
		TextBox_Latitude.Lines = null;
		TextBox_Latitude.Location = new Point(114, 12);
		TextBox_Latitude.MaxLength = 32767;
		TextBox_Latitude.Multiline = false;
		TextBox_Latitude.Name = "TextBox_Latitude";
		TextBox_Latitude.ReadOnly = false;
		TextBox_Latitude.ScrollBars = ScrollBars.None;
		TextBox_Latitude.SelectionStart = 0;
		TextBox_Latitude.Size = new Size(159, 20);
		TextBox_Latitude.TabIndex = 0;
		TextBox_Latitude.TextAlign = HorizontalAlignment.Left;
		TextBox_Latitude.UseSystemPasswordChar = false;
		TextBox_Latitude.WatermarkText = "";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(38, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(56, 23);
		Label1.TabIndex = 10;
		Label1.Text = "纬度：";
		TextBox_Longitude.AutoCompleteCustomSource = null;
		TextBox_Longitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_Longitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_Longitude.BackColor = Color.Transparent;
		TextBox_Longitude.Font = new Font("Segoe UI", 10f);
		TextBox_Longitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Longitude.Image = null;
		TextBox_Longitude.Lines = null;
		TextBox_Longitude.Location = new Point(114, 51);
		TextBox_Longitude.MaxLength = 32767;
		TextBox_Longitude.Multiline = false;
		TextBox_Longitude.Name = "TextBox_Longitude";
		TextBox_Longitude.ReadOnly = false;
		TextBox_Longitude.ScrollBars = ScrollBars.None;
		TextBox_Longitude.SelectionStart = 0;
		TextBox_Longitude.Size = new Size(159, 20);
		TextBox_Longitude.TabIndex = 1;
		TextBox_Longitude.TextAlign = HorizontalAlignment.Left;
		TextBox_Longitude.UseSystemPasswordChar = false;
		TextBox_Longitude.WatermarkText = "";
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(28, 55);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(66, 23);
		DarkLabel1.TabIndex = 12;
		DarkLabel1.Text = "经度：";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(301, 140);
		base.Controls.Add(TextBox_Longitude);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(TextBox_Latitude);
		base.Controls.Add(Label1);
		base.Controls.Add(Button_Cancel);
		base.Controls.Add(Button_OK);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddReferencePointAtLocation";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		Text = "在指定位置添加参考点";
		ResumeLayout(performLayout: false);
	}

	private void CheckFilter(object sender, EventArgs e)
	{
	}

	private void ConcatFilter(object sender, EventArgs e)
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		try
		{
			num = LuaUtility.ParseLatitudeString(TextBox_Latitude.Text);
			num2 = LuaUtility.ParseLongitudeString(TextBox_Longitude.Text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (ex2 is LuaError)
			{
				DarkMessageBox.ShowError(((LuaError)ex2).sMessage, "Coordinate Parsing Error");
			}
			if (num == double.MaxValue)
			{
				TextBox_Latitude.Focus();
			}
			else if (num2 == double.MaxValue)
			{
				TextBox_Longitude.Focus();
			}
			ProjectData.ClearProjectError();
			return;
		}
		num = Math2.ReflectClass(num);
		num2 = Math2.VisitClass(num2);
		ReferencePoint referencePoint = new ReferencePoint();
		referencePoint.Longitude = num2;
		referencePoint.Latitude = num;
		Client.CurrentScenario.UnitsAutoIncrement = Client.CurrentScenario.UnitsAutoIncrement + 1;
		referencePoint.Name = "RP-" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		referencePoint.color = Color.White;
		Client.CurrentSide.RefPoints.Add(referencePoint);
		Close();
	}

	private void InterruptFilter(object sender, EventArgs e)
	{
		TextBox_Latitude.Text = "";
		TextBox_Longitude.Text = "";
		Close();
	}
}
