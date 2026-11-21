using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Effects;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class NegativeEffect : ShaderEffect
{
	public static readonly DependencyProperty InputProperty;

	private static PixelShader m_ClassPublisher;

	public Brush Input
	{
		get
		{
			return (Brush)GetValue(InputProperty);
		}
		set
		{
			SetValue(InputProperty, value);
		}
	}

	static NegativeEffect()
	{
		InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(NegativeEffect), 0);
		m_ClassPublisher = new PixelShader();
		m_ClassPublisher.UriSource = new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Shaders/Negative.ps");
	}

	public NegativeEffect()
	{
		base.PixelShader = m_ClassPublisher;
		UpdateShaderValue(InputProperty);
	}
}
