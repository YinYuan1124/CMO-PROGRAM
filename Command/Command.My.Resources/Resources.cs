using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.My.Resources;

[StandardModule]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[HideModuleName]
[CompilerGenerated]
public sealed class Resources
{
	private static QResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static QResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new QResourceManager("Command.Resources", typeof(Resources).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	public static Bitmap Aircraft => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Aircraft", cultureInfo_0));

	public static Bitmap ArrowDown => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("ArrowDown", cultureInfo_0));

	public static Bitmap ArrowUp => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("ArrowUp", cultureInfo_0));

	public static Bitmap CloudBottom => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("CloudBottom", cultureInfo_0));

	public static Bitmap CloudTop => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("CloudTop", cultureInfo_0));

	public static Bitmap CrossHairRedCursor_32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("CrossHairRedCursor_32", cultureInfo_0));

	public static Bitmap Escort32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Escort32", cultureInfo_0));

	public static Bitmap GroudLevel => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("GroudLevel", cultureInfo_0));

	public static Bitmap LayerBottom => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("LayerBottom", cultureInfo_0));

	public static Bitmap LayerTop => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("LayerTop", cultureInfo_0));

	public static Bitmap No => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("No", cultureInfo_0));

	public static Bitmap Radar32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Radar32", cultureInfo_0));

	public static Bitmap Rebase32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Rebase32", cultureInfo_0));

	public static Bitmap RefuelCursor32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("RefuelCursor32", cultureInfo_0));

	public static Bitmap RTB32 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("RTB32", cultureInfo_0));

	public static Bitmap sattelite => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("sattelite", cultureInfo_0));

	public static Bitmap SeaFloor => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("SeaFloor", cultureInfo_0));

	public static Bitmap Ship => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Ship", cultureInfo_0));

	public static Bitmap Tank => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Tank", cultureInfo_0));

	public static Bitmap Tank1 => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Tank1", cultureInfo_0));

	public static Bitmap Ticker => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Ticker", cultureInfo_0));

	public static Bitmap Yes => (Bitmap)RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("Yes", cultureInfo_0));
}
