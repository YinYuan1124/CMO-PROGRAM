using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Helper
{
	internal static Color _IndexerDic;

	internal static Color _ResolverDic;

	internal static Color publisherDic;

	internal static Color serverDic;

	internal static Color m_AdapterDic;

	internal static Color _SchemaDic;

	internal static Color _UtilsDic;

	internal static Color _PredicateDic;

	static Helper()
	{
		_IndexerDic = Color.FromArgb(255, 82, 255, 255);
		_ResolverDic = Color.Yellow;
		publisherDic = Color.LightGreen;
		serverDic = Color.Orange;
		m_AdapterDic = Color.Red;
		_SchemaDic = Color.FromArgb(75, Color.DodgerBlue);
		_UtilsDic = Color.FromArgb(255, Color.White);
		_PredicateDic = Color.FromArgb(255, Color.White);
	}

	[SpecialName]
	internal static Color GetColorFromStance(Misc.PostureStance postureStance_0)
	{
		if (1 == 0)
		{
		}
		Color result = postureStance_0 switch
		{
			Misc.PostureStance.Neutral => publisherDic, 
			Misc.PostureStance.Friendly => _IndexerDic, 
			Misc.PostureStance.Unfriendly => serverDic, 
			Misc.PostureStance.Hostile => m_AdapterDic, 
			Misc.PostureStance.Unknown => _ResolverDic, 
			_ => default(Color), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
