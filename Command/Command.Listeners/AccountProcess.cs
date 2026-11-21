using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Command.Listeners;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class AccountProcess
{
	private static QResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static QResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new QResourceManager("Command.Listeners.AccountProcess", typeof(AccountProcess).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		set
		{
			resourceCulture = value;
		}
	}

	internal static string ArgumentCannotBeNegative_S => ResourceManager.GetString("ArgumentCannotBeNegative_S", resourceCulture);

	internal static string ArgumentCouldNotBeCast_S1_S2 => ResourceManager.GetString("ArgumentCouldNotBeCast_S1_S2", resourceCulture);

	internal static string ArgumentOutOfRangeException_S => ResourceManager.GetString("ArgumentOutOfRangeException_S", resourceCulture);

	internal static string ClassNotSupportedException_S => ResourceManager.GetString("ClassNotSupportedException_S", resourceCulture);

	internal static string CoordinateMismatchException => ResourceManager.GetString("CoordinateMismatchException", resourceCulture);

	internal static string DuplicateEdgeException => ResourceManager.GetString("DuplicateEdgeException", resourceCulture);

	internal static string GeometryCollectionNotSupportedException => ResourceManager.GetString("GeometryCollectionNotSupportedException", resourceCulture);

	internal static string InsufficientDimensions => ResourceManager.GetString("InsufficientDimensions", resourceCulture);

	internal static string InsufficientDimensions_S => ResourceManager.GetString("InsufficientDimensions_S", resourceCulture);

	internal static string InvalidOctantException_S => ResourceManager.GetString("InvalidOctantException_S", resourceCulture);

	internal static string KeyDuplicateException => ResourceManager.GetString("KeyDuplicateException", resourceCulture);

	internal static string KeyMissingException => ResourceManager.GetString("KeyMissingException", resourceCulture);

	internal static string KeySizeException => ResourceManager.GetString("KeySizeException", resourceCulture);

	internal static string NullEdgeException => ResourceManager.GetString("NullEdgeException", resourceCulture);

	internal static string PolygonException_HoleElementNull => ResourceManager.GetString("PolygonException_HoleElementNull", resourceCulture);

	internal static string PolygonException_ShellEmptyButHolesNot => ResourceManager.GetString("PolygonException_ShellEmptyButHolesNot", resourceCulture);

	internal static string ReadOnlyException => ResourceManager.GetString("ReadOnlyException", resourceCulture);

	internal static string ShellHoleIdentityException => ResourceManager.GetString("ShellHoleIdentityException", resourceCulture);

	internal static string ShouldNeverReachHereException => ResourceManager.GetString("ShouldNeverReachHereException", resourceCulture);

	internal static string SideLocationConflict => ResourceManager.GetString("SideLocationConflict", resourceCulture);

	internal static string SingleNullSide => ResourceManager.GetString("SingleNullSide", resourceCulture);

	internal static string TopologyException_Depth => ResourceManager.GetString("TopologyException_Depth", resourceCulture);

	internal static string TwoHorizontalEdgesException => ResourceManager.GetString("TwoHorizontalEdgesException", resourceCulture);

	internal static string UnsupportedGeometryException => ResourceManager.GetString("UnsupportedGeometryException", resourceCulture);

	internal AccountProcess()
	{
	}
}
