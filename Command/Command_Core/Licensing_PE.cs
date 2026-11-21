using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Licensing_PE
{
	public delegate void LicensingCheckErrorOccuredEventHandler(string theErrorMessage);

	public enum ProgramExecutionMode
	{
		Undefined,
		FullGUIClient,
		CLI
	}

	public enum ProExtension
	{
		TestScripts
	}

	public enum _ProLicenseVersion
	{
		FullVersion,
		EvaluationVersion
	}

	[CompilerGenerated]
	private static LicensingCheckErrorOccuredEventHandler visitorDic;

	private static int exporterDic;

	public static event LicensingCheckErrorOccuredEventHandler LicensingCheckErrorOccured
	{
		[CompilerGenerated]
		add
		{
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler = visitorDic;
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler2;
			do
			{
				licensingCheckErrorOccuredEventHandler2 = licensingCheckErrorOccuredEventHandler;
				LicensingCheckErrorOccuredEventHandler value2 = (LicensingCheckErrorOccuredEventHandler)Delegate.Combine(licensingCheckErrorOccuredEventHandler2, value);
				licensingCheckErrorOccuredEventHandler = Interlocked.CompareExchange(ref visitorDic, value2, licensingCheckErrorOccuredEventHandler2);
			}
			while ((object)licensingCheckErrorOccuredEventHandler != licensingCheckErrorOccuredEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler = visitorDic;
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler2;
			do
			{
				licensingCheckErrorOccuredEventHandler2 = licensingCheckErrorOccuredEventHandler;
				LicensingCheckErrorOccuredEventHandler value2 = (LicensingCheckErrorOccuredEventHandler)Delegate.Remove(licensingCheckErrorOccuredEventHandler2, value);
				licensingCheckErrorOccuredEventHandler = Interlocked.CompareExchange(ref visitorDic, value2, licensingCheckErrorOccuredEventHandler2);
			}
			while ((object)licensingCheckErrorOccuredEventHandler != licensingCheckErrorOccuredEventHandler2);
		}
	}

	static Licensing_PE()
	{
		exporterDic = 0;
	}

	public static string LoadAndParsePELicense(ProgramExecutionMode programExecutionMode_0)
	{
		return null;
	}

	public static string AttemptToObtainFloatingLicense()
	{
		return null;
	}

	public static void AttemptToReturnFloatingLicense()
	{
	}

	private static void WriteClass(object object_0, object object_1)
	{
	}
}
