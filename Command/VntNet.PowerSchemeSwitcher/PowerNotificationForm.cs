using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using OpenDis.Pages;
using OpenDis.Services;

namespace VntNet.PowerSchemeSwitcher;

public class PowerNotificationForm : Form
{
	private RulesMerchantService printerMerchant;

	private HelperPage parserMerchant;

	private string _AlgoMerchant;

	private RulesMerchantService.PowerSavingLevelEnum _DatabaseMerchant;

	[CompilerGenerated]
	private Action<string, RulesMerchantService.PowerSavingLevelEnum> m_InterceptorMerchant;

	private IContainer messageMerchant;

	internal event Action<string, RulesMerchantService.PowerSavingLevelEnum> PrintMerchant
	{
		[CompilerGenerated]
		add
		{
			Action<string, RulesMerchantService.PowerSavingLevelEnum> action = m_InterceptorMerchant;
			Action<string, RulesMerchantService.PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<string, RulesMerchantService.PowerSavingLevelEnum> value2 = (Action<string, RulesMerchantService.PowerSavingLevelEnum>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref m_InterceptorMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<string, RulesMerchantService.PowerSavingLevelEnum> action = m_InterceptorMerchant;
			Action<string, RulesMerchantService.PowerSavingLevelEnum> action2;
			do
			{
				action2 = action;
				Action<string, RulesMerchantService.PowerSavingLevelEnum> value2 = (Action<string, RulesMerchantService.PowerSavingLevelEnum>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref m_InterceptorMerchant, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public PowerNotificationForm()
	{
		PostMerchant();
		parserMerchant = new HelperPage();
		_AlgoMerchant = HelperPage.SetMerchant().ToString();
		parserMerchant.InsertMerchant += PrepareMerchant;
		parserMerchant.CompareMerchant += VerifyMerchant;
	}

	private void PrepareMerchant(int int_0)
	{
		ReflectMerchant();
	}

	protected override void WndProc(ref Message m)
	{
		if (printerMerchant == null)
		{
			base.WndProc(ref m);
		}
		else if (!printerMerchant.FlushMerchant(ref m))
		{
			base.WndProc(ref m);
		}
		int num = 22;
		if (m.Msg == 17)
		{
			m.Result = (IntPtr)1;
		}
		else if (m.Msg == num)
		{
			CancelMerchant();
			m.Result = (IntPtr)0;
			Close();
			Application.Exit();
		}
	}

	private void ReflectMerchant()
	{
		if (m_InterceptorMerchant != null)
		{
			m_InterceptorMerchant(_AlgoMerchant, _DatabaseMerchant);
		}
	}

	private void VisitMerchant(object sender, EventArgs e)
	{
		Hide();
	}

	private void RestartMerchant(object sender, EventArgs e)
	{
		StopMerchant();
	}

	private void TestMerchant(object sender, FormClosingEventArgs e)
	{
		CancelMerchant();
	}

	private void StopMerchant()
	{
		printerMerchant = new RulesMerchantService(this);
		printerMerchant.CountCallback += ResolveMerchant;
	}

	private void CancelMerchant()
	{
		printerMerchant.CollectMerchant();
	}

	private void VerifyMerchant(HelperPage.PowerLineStatus powerLineStatus_0)
	{
		_AlgoMerchant = HelperPage.SetMerchant().ToString();
		ReflectMerchant();
	}

	private void ResolveMerchant(RulesMerchantService.PowerSavingLevelEnum powerSavingLevelEnum_0)
	{
		_DatabaseMerchant = powerSavingLevelEnum_0;
		ReflectMerchant();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && messageMerchant != null)
		{
			messageMerchant.Dispose();
		}
		base.Dispose(disposing);
	}

	private void PostMerchant()
	{
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.ClientSize = new Size(284, 262);
		base.Name = "PowerNotificationForm";
		Text = "PowerNotificationForm";
		base.FormClosing += TestMerchant;
		base.Load += RestartMerchant;
		base.Shown += VisitMerchant;
		ResumeLayout(performLayout: false);
	}
}
