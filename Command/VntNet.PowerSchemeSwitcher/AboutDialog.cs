using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command;

namespace VntNet.PowerSchemeSwitcher;

public class AboutDialog : Form
{
	private IContainer _FieldMerchant;

	private Label m_QueueMerchant;

	private Label regMerchant;

	private Label _ParamMerchant;

	private Button pageMerchant;

	private TableLayoutPanel m_RulesMerchant;

	private PictureBox methodMerchant;

	private TextBox m_ServiceMerchant;

	private LinkLabel _SystemMerchant;

	public AboutDialog()
	{
		ChangeMerchant();
		Text = string.Format(Text, smethod_0());
		m_QueueMerchant.Text = YjBnkrbvqCh();
		regMerchant.Text = string.Format(regMerchant.Text, smethod_1(), smethod_2());
		_ParamMerchant.Text = smethod_5();
		m_ServiceMerchant.Text = smethod_3();
		_ParamMerchant.Visible = false;
		m_ServiceMerchant.Visible = false;
		_SystemMerchant.Links.Remove(_SystemMerchant.Links[0]);
		_SystemMerchant.Links.Add(0, _SystemMerchant.Text.Length, "http://powerschemeswitcher.codeplex.com");
	}

	[SpecialName]
	private static string smethod_0()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		object[] customAttributes = executingAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return executingAssembly.GetName().Name;
		}
		return ((AssemblyTitleAttribute)customAttributes[0]).Title;
	}

	[SpecialName]
	private static string smethod_1()
	{
		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}

	[SpecialName]
	private static string smethod_2()
	{
		return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
	}

	[SpecialName]
	private static string smethod_3()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return string.Empty;
		}
		return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
	}

	[SpecialName]
	private static string YjBnkrbvqCh()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return string.Empty;
		}
		return ((AssemblyProductAttribute)customAttributes[0]).Product;
	}

	[SpecialName]
	private static string smethod_4()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return string.Empty;
		}
		return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
	}

	[SpecialName]
	private static string smethod_5()
	{
		object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
		if (customAttributes.Length == 0)
		{
			return string.Empty;
		}
		return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
	}

	private void EnableMerchant(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()));
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _FieldMerchant != null)
		{
			_FieldMerchant.Dispose();
		}
		base.Dispose(disposing);
	}

	private void ChangeMerchant()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(AboutDialog));
		m_QueueMerchant = new Label();
		regMerchant = new Label();
		_ParamMerchant = new Label();
		pageMerchant = new Button();
		m_RulesMerchant = new TableLayoutPanel();
		methodMerchant = new PictureBox();
		m_ServiceMerchant = new TextBox();
		_SystemMerchant = new LinkLabel();
		m_RulesMerchant.SuspendLayout();
		((ISupportInitialize)methodMerchant).BeginInit();
		SuspendLayout();
		m_QueueMerchant.Dock = DockStyle.Fill;
		m_QueueMerchant.ImeMode = ImeMode.NoControl;
		m_QueueMerchant.Location = new Point(141, 0);
		m_QueueMerchant.Margin = new Padding(6, 0, 3, 0);
		m_QueueMerchant.MaximumSize = new Size(0, 17);
		m_QueueMerchant.Name = "labelProductName";
		m_QueueMerchant.Size = new Size(266, 17);
		m_QueueMerchant.TabIndex = 19;
		m_QueueMerchant.Text = "Product Name";
		m_QueueMerchant.TextAlign = ContentAlignment.MiddleLeft;
		regMerchant.Dock = DockStyle.Fill;
		regMerchant.ImeMode = ImeMode.NoControl;
		regMerchant.Location = new Point(141, 25);
		regMerchant.Margin = new Padding(6, 0, 3, 0);
		regMerchant.MaximumSize = new Size(0, 17);
		regMerchant.Name = "labelVersion";
		regMerchant.Size = new Size(266, 17);
		regMerchant.TabIndex = 0;
		regMerchant.Text = "Version {0} ({1})";
		regMerchant.TextAlign = ContentAlignment.MiddleLeft;
		_ParamMerchant.Dock = DockStyle.Fill;
		_ParamMerchant.ImeMode = ImeMode.NoControl;
		_ParamMerchant.Location = new Point(141, 75);
		_ParamMerchant.Margin = new Padding(6, 0, 3, 0);
		_ParamMerchant.MaximumSize = new Size(0, 17);
		_ParamMerchant.Name = "labelCompanyName";
		_ParamMerchant.Size = new Size(266, 17);
		_ParamMerchant.TabIndex = 22;
		_ParamMerchant.Text = "Company Name";
		_ParamMerchant.TextAlign = ContentAlignment.MiddleLeft;
		pageMerchant.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		pageMerchant.DialogResult = DialogResult.Cancel;
		pageMerchant.ImeMode = ImeMode.NoControl;
		pageMerchant.Location = new Point(332, 233);
		pageMerchant.Name = "okButton";
		pageMerchant.Size = new Size(75, 23);
		pageMerchant.TabIndex = 24;
		pageMerchant.Text = "OK";
		m_RulesMerchant.ColumnCount = 2;
		m_RulesMerchant.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		m_RulesMerchant.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
		m_RulesMerchant.Controls.Add(methodMerchant, 0, 0);
		m_RulesMerchant.Controls.Add(m_QueueMerchant, 1, 0);
		m_RulesMerchant.Controls.Add(regMerchant, 1, 1);
		m_RulesMerchant.Controls.Add(_ParamMerchant, 1, 3);
		m_RulesMerchant.Controls.Add(m_ServiceMerchant, 1, 4);
		m_RulesMerchant.Controls.Add(pageMerchant, 1, 5);
		m_RulesMerchant.Controls.Add(_SystemMerchant, 1, 2);
		m_RulesMerchant.Dock = DockStyle.Fill;
		m_RulesMerchant.Location = new Point(0, 0);
		m_RulesMerchant.Name = "tableLayoutPanel";
		m_RulesMerchant.RowCount = 6;
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		m_RulesMerchant.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
		m_RulesMerchant.Size = new Size(410, 259);
		m_RulesMerchant.TabIndex = 1;
		methodMerchant.Dock = DockStyle.Fill;
		methodMerchant.ImeMode = ImeMode.NoControl;
		methodMerchant.Location = new Point(3, 3);
		methodMerchant.Name = "logoPictureBox";
		m_RulesMerchant.SetRowSpan(methodMerchant, 6);
		methodMerchant.Size = new Size(129, 253);
		methodMerchant.SizeMode = PictureBoxSizeMode.StretchImage;
		methodMerchant.TabIndex = 12;
		methodMerchant.TabStop = false;
		m_ServiceMerchant.Dock = DockStyle.Fill;
		m_ServiceMerchant.Location = new Point(141, 103);
		m_ServiceMerchant.Margin = new Padding(6, 3, 3, 3);
		m_ServiceMerchant.Multiline = true;
		m_ServiceMerchant.Name = "textBoxDescription";
		m_ServiceMerchant.ReadOnly = true;
		m_ServiceMerchant.ScrollBars = ScrollBars.Both;
		m_ServiceMerchant.Size = new Size(266, 123);
		m_ServiceMerchant.TabIndex = 23;
		m_ServiceMerchant.TabStop = false;
		m_ServiceMerchant.Text = "Description";
		_SystemMerchant.AutoSize = true;
		_SystemMerchant.Location = new Point(141, 50);
		_SystemMerchant.Margin = new Padding(6, 0, 6, 0);
		_SystemMerchant.Name = "linkLabel1";
		_SystemMerchant.Size = new Size(217, 13);
		_SystemMerchant.TabIndex = 25;
		_SystemMerchant.TabStop = true;
		_SystemMerchant.Text = "http://powerschemeswitcher.codeplex.com/";
		_SystemMerchant.LinkClicked += EnableMerchant;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.ClientSize = new Size(410, 259);
		base.Controls.Add(m_RulesMerchant);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = componentResourceManager.GetIcon("$this.Icon");
		base.Name = "AboutDialog";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "About {0}";
		m_RulesMerchant.ResumeLayout(performLayout: false);
		m_RulesMerchant.PerformLayout();
		((ISupportInitialize)methodMerchant).EndInit();
		ResumeLayout(performLayout: false);
	}
}
