using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[DesignerGenerated]
public sealed class SteamUpdateScenarioForm : DarkSecondaryFormBase
{
	private IContainer _CustomerException;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _SerializerException;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _RefException;

	public static SteamWorkshop.SteamWorkshopScenario steam_scenario;

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _SerializerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeInterruptibleException;
			DarkUIButton serializerException = _SerializerException;
			if (serializerException != null)
			{
				serializerException.Click -= value2;
			}
			_SerializerException = value;
			serializerException = _SerializerException;
			if (serializerException != null)
			{
				serializerException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _RefException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleException;
			DarkUIButton refException = _RefException;
			if (refException != null)
			{
				refException.Click -= value2;
			}
			_RefException = value;
			refException = _RefException;
			if (refException != null)
			{
				refException.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ListView1")]
	internal DarkListView ListView1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public SteamUpdateScenarioForm()
	{
		base.Load += AddInterruptibleException;
		base.Load += PatchInterruptibleException;
		DeleteInterruptibleException();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _CustomerException != null)
			{
				_CustomerException.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DeleteInterruptibleException()
	{
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		ListView1 = new DarkListView();
		SuspendLayout();
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.Location = new Point(6, 322);
		Button1.Name = "Button1";
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 1;
		Button1.Text = "更新";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.Location = new Point(359, 322);
		Button2.Name = "Button2";
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 2;
		Button2.Text = "取消";
		ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListView1.Location = new Point(6, 5);
		ListView1.Name = "ListView1";
		ListView1.Size = new Size(428, 311);
		ListView1.TabIndex = 3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(437, 348);
		base.Controls.Add(ListView1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SteamUpdateScenarioForm";
		base.ShowIcon = false;
		Text = "Steam Workshop Update Selection";
		ResumeLayout(performLayout: false);
	}

	private void AddInterruptibleException(object sender, EventArgs e)
	{
		DarkListItem[] array = SteamWorkshop.UserScens.Select(delegate(SteamUGCDetails_t us)
		{
			SteamUGCDetails_t steamUGCDetails_t = us;
			return new DarkListItem(steamUGCDetails_t.m_rgchTitle)
			{
				Tag = us
			};
		}).ToArray();
		DarkListItem[] array2 = array;
		foreach (DarkListItem item in array2)
		{
			ListView1.Items.Add(item);
		}
	}

	private void DestroyInterruptibleException(object sender, EventArgs e)
	{
		Close();
	}

	private void ComputeInterruptibleException(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count == 1)
		{
			object tag = ListView1.SelectedItems[0].Tag;
			SteamUGCDetails_t steamUGCDetails_t_ = ((tag == null) ? default(SteamUGCDetails_t) : ((SteamUGCDetails_t)tag));
			SteamWorkshop.Update(steam_scenario, steamUGCDetails_t_);
			Close();
		}
	}

	private void PatchInterruptibleException(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
