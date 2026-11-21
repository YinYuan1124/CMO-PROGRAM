using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditSpecialAction : DarkSecondaryFormBase
{
	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer registryDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Name")]
	private DarkUITextBox m_DefinitionDescriptor;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_ValDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel wrapperDescriptor;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton observerDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _IssuerDescriptor;

	[AccessedThroughProperty("TB_Description")]
	[CompilerGenerated]
	private DarkUITextBox m_ClientDescriptor;

	[AccessedThroughProperty("NUD_LuaScript")]
	[CompilerGenerated]
	private GControl1 m_ConsumerDescriptor;

	[AccessedThroughProperty("Label13")]
	[CompilerGenerated]
	private DarkLabel facadeDescriptor;

	[AccessedThroughProperty("Button_AddLuaScript")]
	[CompilerGenerated]
	private DarkUIButton proxyDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_LuaTemplate")]
	private DarkUIComboBox m_ReaderDescriptor;

	[AccessedThroughProperty("Label12")]
	[CompilerGenerated]
	private DarkLabel m_PropertyDescriptor;

	public SpecialAction theSA;

	public _FormAction Action;

	internal DarkUITextBox TB_Name
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = DisableReg;
			DarkUITextBox definitionDescriptor = m_DefinitionDescriptor;
			if (definitionDescriptor != null)
			{
				definitionDescriptor.TextChanged -= value2;
			}
			m_DefinitionDescriptor = value;
			definitionDescriptor = m_DefinitionDescriptor;
			if (definitionDescriptor != null)
			{
				definitionDescriptor.TextChanged += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ValDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValDescriptor = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return wrapperDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wrapperDescriptor = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return observerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareReg;
			DarkUIButton darkUIButton = observerDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			observerDescriptor = value;
			darkUIButton = observerDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _IssuerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadReg;
			DarkUIButton issuerDescriptor = _IssuerDescriptor;
			if (issuerDescriptor != null)
			{
				issuerDescriptor.Click -= value2;
			}
			_IssuerDescriptor = value;
			issuerDescriptor = _IssuerDescriptor;
			if (issuerDescriptor != null)
			{
				issuerDescriptor.Click += value2;
			}
		}
	}

	internal DarkUITextBox TB_Description
	{
		[CompilerGenerated]
		get
		{
			return m_ClientDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClientDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GControl1 NUD_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareReg;
			EventHandler value3 = ReflectReg;
			GControl1 consumerDescriptor = m_ConsumerDescriptor;
			if (consumerDescriptor != null)
			{
				consumerDescriptor.TextChanged -= value2;
				consumerDescriptor.Click -= value3;
			}
			m_ConsumerDescriptor = value;
			consumerDescriptor = m_ConsumerDescriptor;
			if (consumerDescriptor != null)
			{
				consumerDescriptor.TextChanged += value2;
				consumerDescriptor.Click += value3;
			}
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return facadeDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			facadeDescriptor = value;
		}
	}

	internal DarkUIButton Button_AddLuaScript
	{
		[CompilerGenerated]
		get
		{
			return proxyDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertReg;
			DarkUIButton darkUIButton = proxyDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			proxyDescriptor = value;
			darkUIButton = proxyDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_LuaTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReaderDescriptor = value;
		}
	}

	internal DarkLabel Label12
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PropertyDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TB_Script")]
	internal DarkUITextBox TB_Script
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public EditSpecialAction()
	{
		base.FormClosing += InstantiateReg;
		base.Load += CreateReg;
		base.KeyDown += UpdateReg;
		PopReg();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && registryDescriptor != null)
			{
				registryDescriptor.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PopReg()
	{
		TB_Name = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		TB_Description = new DarkUITextBox();
		Label1 = new DarkLabel();
		NUD_LuaScript = new GControl1();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TB_Script = new DarkUITextBox();
		SuspendLayout();
		TB_Name.AutoCompleteCustomSource = null;
		TB_Name.AutoCompleteMode = AutoCompleteMode.None;
		TB_Name.AutoCompleteSource = AutoCompleteSource.None;
		TB_Name.BackColor = Color.Transparent;
		TB_Name.Font = new Font("Segoe UI", 10f);
		TB_Name.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Name.Image = null;
		TB_Name.Lines = null;
		TB_Name.Location = new Point(90, 12);
		TB_Name.MaxLength = 32767;
		TB_Name.Multiline = false;
		TB_Name.Name = "TB_Name";
		TB_Name.ReadOnly = false;
		TB_Name.ScrollBars = ScrollBars.None;
		TB_Name.SelectionStart = 0;
		TB_Name.Size = new Size(632, 20);
		TB_Name.TabIndex = 6;
		TB_Name.TextAlign = HorizontalAlignment.Left;
		TB_Name.UseSystemPasswordChar = false;
		TB_Name.WatermarkText = "";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(4, 16);
		Label2.Name = "Label2";
		Label2.Size = new Size(41, 13);
		Label2.TabIndex = 5;
		Label2.Text = "名称:";
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(4, 48);
		Label3.Name = "Label3";
		Label3.Size = new Size(69, 13);
		Label3.TabIndex = 21;
		Label3.Text = "描述：";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(647, 614);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 24;
		Button2.Text = "取消";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(4, 614);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 23;
		Button1.Text = "确定";
		TB_Description.AutoCompleteCustomSource = null;
		TB_Description.AutoCompleteMode = AutoCompleteMode.None;
		TB_Description.AutoCompleteSource = AutoCompleteSource.None;
		TB_Description.BackColor = Color.Transparent;
		TB_Description.Font = new Font("Segoe UI", 10f);
		TB_Description.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Description.Image = null;
		TB_Description.Lines = null;
		TB_Description.Location = new Point(7, 64);
		TB_Description.MaxLength = 32767;
		TB_Description.Multiline = true;
		TB_Description.Name = "TB_Description";
		TB_Description.ReadOnly = false;
		TB_Description.ScrollBars = ScrollBars.None;
		TB_Description.SelectionStart = 0;
		TB_Description.Size = new Size(715, 96);
		TB_Description.TabIndex = 25;
		TB_Description.TextAlign = HorizontalAlignment.Left;
		TB_Description.UseSystemPasswordChar = false;
		TB_Description.WatermarkText = "";
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(4, 174);
		Label1.Name = "Label1";
		Label1.Size = new Size(61, 13);
		Label1.TabIndex = 21;
		Label1.Text = "Lua脚本：";
		NUD_LuaScript.BackColor = Color.Transparent;
		NUD_LuaScript.Font = new Font("Segoe UI", 10f);
		NUD_LuaScript.Location = new Point(658, 192);
		NUD_LuaScript.Maximum = 100;
		NUD_LuaScript.Minimum = 0;
		NUD_LuaScript.Name = "NUD_LuaScript";
		NUD_LuaScript.Size = new Size(64, 26);
		NUD_LuaScript.TabIndex = 31;
		NUD_LuaScript.Value = 0;
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(605, 197);
		Label13.Name = "Label13";
		Label13.Size = new Size(54, 15);
		Label13.TabIndex = 30;
		Label13.Text = "字体大小：";
		Button_AddLuaScript.BackColor = Color.Transparent;
		Button_AddLuaScript.DialogResult = DialogResult.None;
		Button_AddLuaScript.Font = new Font("Segoe UI", 10f);
		Button_AddLuaScript.ForeColor = SystemColors.Control;
		Button_AddLuaScript.Location = new Point(529, 193);
		Button_AddLuaScript.Name = "Button_AddLuaScript";
		Button_AddLuaScript.RoundRadius = 0;
		Button_AddLuaScript.Size = new Size(75, 24);
		Button_AddLuaScript.TabIndex = 29;
		Button_AddLuaScript.Text = "添加";
		CB_LuaTemplate.BackColor = Color.Transparent;
		CB_LuaTemplate.DrawMode = DrawMode.OwnerDrawFixed;
		CB_LuaTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_LuaTemplate.Font = new Font("Segoe UI", 7f);
		CB_LuaTemplate.FormattingEnabled = true;
		CB_LuaTemplate.Location = new Point(124, 193);
		CB_LuaTemplate.Name = "CB_LuaTemplate";
		CB_LuaTemplate.Size = new Size(400, 21);
		CB_LuaTemplate.TabIndex = 28;
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(4, 197);
		Label12.Name = "Label12";
		Label12.Size = new Size(114, 15);
		Label12.TabIndex = 27;
		Label12.Text = "添加脚本模板：";
		TB_Script.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_Script.AutoCompleteCustomSource = null;
		TB_Script.AutoCompleteMode = AutoCompleteMode.None;
		TB_Script.AutoCompleteSource = AutoCompleteSource.None;
		TB_Script.BackColor = Color.Transparent;
		TB_Script.Font = new Font("Segoe UI", 10f);
		TB_Script.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Script.Image = null;
		TB_Script.Lines = null;
		TB_Script.Location = new Point(4, 221);
		TB_Script.MaxLength = 999999999;
		TB_Script.Multiline = true;
		TB_Script.Name = "TB_Script";
		TB_Script.ReadOnly = false;
		TB_Script.ScrollBars = ScrollBars.Vertical;
		TB_Script.SelectionStart = 0;
		TB_Script.Size = new Size(718, 387);
		TB_Script.TabIndex = 26;
		TB_Script.TextAlign = HorizontalAlignment.Left;
		TB_Script.UseSystemPasswordChar = false;
		TB_Script.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(726, 639);
		base.Controls.Add(NUD_LuaScript);
		base.Controls.Add(Label13);
		base.Controls.Add(Button_AddLuaScript);
		base.Controls.Add(CB_LuaTemplate);
		base.Controls.Add(Label12);
		base.Controls.Add(TB_Script);
		base.Controls.Add(TB_Description);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label1);
		base.Controls.Add(Label3);
		base.Controls.Add(TB_Name);
		base.Controls.Add(Label2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditSpecialAction";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑特殊动作";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void InstantiateReg(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.ListSpecialActions.RefreshGrid();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CreateReg(object sender, EventArgs e)
	{
		if (Information.IsNothing(theSA))
		{
			Close();
		}
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TB_Name.Text = theSA.Name;
		TB_Description.Text = theSA.Description;
		Button1.Visible = true;
		Button2.Visible = Button1.Visible;
		if (!string.IsNullOrEmpty(theSA.ScriptText))
		{
			TB_Script.Text = theSA.ScriptText;
		}
		NUD_LuaScript.Value = (int)Math.Round(TB_Script.Font.Size);
		ComboBox.ObjectCollection items = CB_LuaTemplate.Items;
		object[] array = LuaSandBox.LuaMethods.OrderBy((string s) => s).ToArray();
		object[] items2 = array;
		items.AddRange(items2);
		CB_LuaTemplate.SelectedIndex = 0;
	}

	private void CompareReg(object sender, EventArgs e)
	{
		Close();
	}

	private void ReadReg(object sender, EventArgs e)
	{
		theSA.Name = TB_Name.Text;
		theSA.ScriptText = TB_Script.Text;
		theSA.Description = TB_Description.Text;
		if (Action == _FormAction.AddNew)
		{
			Client.CurrentSide.SpecialActions.Add(theSA.ObjectID, theSA);
		}
		Close();
	}

	private void DisableReg(object object_0)
	{
		theSA.Name = TB_Name.Text;
	}

	private void UpdateReg(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void InsertReg(object sender, EventArgs e)
	{
		TB_Script.Text = TB_Script.Text.Insert(TB_Script.SelectionStart, Conversions.ToString(CB_LuaTemplate.SelectedItem));
	}

	private void PrepareReg(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript))
		{
			TB_Script.Font = new Font(TB_Script.Font.FontFamily, NUD_LuaScript.Value);
		}
	}

	private void ReflectReg(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript.Value))
		{
			TB_Script.Font = new Font(TB_Script.Font.FontFamily, NUD_LuaScript.Value);
		}
	}
}
