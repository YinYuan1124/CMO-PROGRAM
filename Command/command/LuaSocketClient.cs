using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class LuaSocketClient : Form
{
	private IContainer _ParamsModel;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button infoModel;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox mapperModel;

	private TcpClient m_ManagerModel;

	internal Button Button1
	{
		[CompilerGenerated]
		get
		{
			return infoModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortGlobal;
			Button button = infoModel;
			if (button != null)
			{
				button.Click -= value2;
			}
			infoModel = value;
			button = infoModel;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextBox2")]
	internal TextBox TextBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return mapperModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperModel = value;
		}
	}

	public LuaSocketClient()
	{
		base.Load += ResetGlobal;
		m_ManagerModel = new TcpClient();
		QueryGlobal();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ParamsModel != null)
			{
				_ParamsModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void QueryGlobal()
	{
		Button1 = new Button();
		TextBox2 = new TextBox();
		TextBox1 = new TextBox();
		SuspendLayout();
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button1.Location = new Point(558, 281);
		Button1.Name = "Button1";
		Button1.Size = new Size(126, 21);
		Button1.TabIndex = 5;
		Button1.Text = "运行脚本";
		Button1.UseVisualStyleBackColor = true;
		TextBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox2.Font = new Font("Lucida Console", 8.25f);
		TextBox2.Location = new Point(3, 227);
		TextBox2.Multiline = true;
		TextBox2.Name = "TextBox2";
		TextBox2.ScrollBars = ScrollBars.Both;
		TextBox2.Size = new Size(548, 110);
		TextBox2.TabIndex = 4;
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.BackColor = SystemColors.ControlLightLight;
		TextBox1.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TextBox1.Location = new Point(3, 12);
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.ScrollBars = ScrollBars.Both;
		TextBox1.Size = new Size(681, 184);
		TextBox1.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(747, 342);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox2);
		base.Controls.Add(TextBox1);
		base.Name = "LuaSocketClient";
		Text = "Lua网络客户端";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ResetGlobal(object sender, EventArgs e)
	{
		MapGlobal("客户端已启动");
		m_ManagerModel.Connect("127.0.0.1", 8888);
		Text = "连接成功！";
	}

	private void MapGlobal(string string_0)
	{
		Console.WriteLine(">> " + Strings.Trim(string_0));
	}

	private void SortGlobal(object sender, EventArgs e)
	{
		NetworkStream stream = m_ManagerModel.GetStream();
		byte[] bytes = Encoding.BigEndianUnicode.GetBytes(TextBox2.Text);
		stream.Write(bytes, 0, bytes.Length);
		stream.Flush();
		byte[] array = new byte[m_ManagerModel.ReceiveBufferSize + 1];
		stream.Read(array, 0, m_ManagerModel.ReceiveBufferSize);
		string @string = Encoding.BigEndianUnicode.GetString(array);
		@string = @string.Replace("\0", "");
		@string = @string.Remove(@string.Length - 1);
		TextBox1.Text = @string;
		Client.MustRefreshMainForm = true;
	}
}
