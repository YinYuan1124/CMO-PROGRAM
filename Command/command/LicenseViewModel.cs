using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using OpenDis.Database;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class LicenseViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string advisorComposer;

	[CompilerGenerated]
	private string customerComposer;

	[CompilerGenerated]
	private bool serializerComposer;

	[CompilerGenerated]
	private bool m_RefComposer;

	[CompilerGenerated]
	private Licensing.ModuleLicense errorComposer;

	[CompilerGenerated]
	private RelayCommand m_CodeComposer;

	[CompilerGenerated]
	private static BitmapImage connectionComposer;

	[CompilerGenerated]
	private static BitmapImage m_ContextComposer;

	[NonSerialized]
	private PropertyChangedEventHandler m_StatusComposer;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return advisorComposer;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(advisorComposer, value, StringComparison.Ordinal))
			{
				advisorComposer = value;
				OnPropertyChanged("Title");
			}
		}
	}

	public string Subtitle
	{
		[CompilerGenerated]
		get
		{
			return customerComposer;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(customerComposer, value, StringComparison.Ordinal))
			{
				customerComposer = value;
				OnPropertyChanged("Subtitle");
			}
		}
	}

	public bool Required
	{
		[CompilerGenerated]
		get
		{
			return serializerComposer;
		}
		[CompilerGenerated]
		set
		{
			if (serializerComposer != value)
			{
				serializerComposer = value;
				OnPropertyChanged("Required");
			}
		}
	}

	public bool Owned
	{
		[CompilerGenerated]
		get
		{
			return m_RefComposer;
		}
		[CompilerGenerated]
		set
		{
			if (m_RefComposer != value)
			{
				m_RefComposer = value;
				OnPropertyChanged("Owned");
			}
		}
	}

	public Licensing.ModuleLicense AssociatedLicense
	{
		[CompilerGenerated]
		get
		{
			return errorComposer;
		}
		[CompilerGenerated]
		set
		{
			if (errorComposer != value)
			{
				errorComposer = value;
				OnPropertyChanged("AssociatedLicense");
			}
		}
	}

	public RelayCommand UnlockCommand
	{
		[CompilerGenerated]
		get
		{
			return m_CodeComposer;
		}
		[CompilerGenerated]
		set
		{
			if (m_CodeComposer != value)
			{
				m_CodeComposer = value;
				OnPropertyChanged("UnlockCommand");
			}
		}
	}

	public static BitmapImage LockImage
	{
		[CompilerGenerated]
		get
		{
			return connectionComposer;
		}
	}

	public static BitmapImage PositiveImage
	{
		[CompilerGenerated]
		get
		{
			return m_ContextComposer;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_StatusComposer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_StatusComposer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_StatusComposer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_StatusComposer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static LicenseViewModel()
	{
		connectionComposer = StubDecoratorEntry.FindInterruptibleMap("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAkCAMAAACpD3pbAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAMAUExURQAAAABVUwBXVABXVQBXVwBXWABYWABZWgBdWwBeWwBfYABgXQBgYABiYABkYQBmZwBpaABraABraQBragBtagBubABubgBubwBwbgBzdAB0cQB1cgB1dAB2dAB2dQB3dgB2dwB1eQB1egB3eQB5eAB6ewB7fAB7fwB9ewB9fAB9fwB+gQx8hBF/hgCDgQGDhgGDhwCFgwCFhACFhgCFhwCJhwGKjACNjACNjgCNjwCOjACPjgCPjwWJjgmDjACPkAWOkwmJkgmKkgmLlAiNlQmNlgiOlgCQkQCTkQCSkgCRlQCTlACVlQCUlgCVlwCWlgCWlwCYmACYmQCZmgCamACamgCanQCcnACcnwCengCfnwmQmAiQmQmRmhGAhhKNlBGOlRWPlBKUmxKVnBGYnwCdoACfogufpgufpwChoACioQCiogCipACkpACmpQCnpgClqACopwCpqACqqQCsqgCurQCwrgCxrwC2swC2tQC5tgC6uAC7uQC7uwC8ugC+uwC+vw61uhOmqxuvshG5vhG5vxuzthq8vxe/xADBvgDCvgDCvwDHwwDJxQDLxgDLxwDNyQDOywDQywLSzwDT0gDX1wjb2xLKzxjExxnEyBvIyhTQ1R/d3hDd4Rne4Q7l6BHi5hDn6xfp7Bfq7R3s7R3s7iLT0iLW1SPX1iPX1yLc3CTf3iXn5SPt7CTr6iHz8yj28wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB8/qLMAAAEAdFJOU////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////wBT9wclAAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAGHRFWHRTb2Z0d2FyZQBwYWludC5uZXQgNC4wLjlsM35OAAACN0lEQVQ4T5WQ6VsSURSHKcwWtSzT1JQi9zQrDTVzNxUyI1RUXFLLFgqZRlzASXEpl1IZwLDccNos9/9wuvfcE9FTX3o/vef3PnM/jEL+RefUN2SqEydZDuSH01sHyNb0IxwDuevD6h7Wg73Vj104Y+6Z+bK/u7P9Y3Pz+/bO7v7XmR62Y3698ml9ebKbavfk8vrnlTcwYy5Z25CWJh6Ay1cmlqSNtRJwliskSRrPAiVkjZOzAvR3fgoGPPtHbgMD2v4vl/+dy8FYriR3OxjQTs5KMJaryN0BBnSQswqM5dt+vz/4a3JWg7Fc7PP5ysCAMnIWg7F81ev15oEBeeS8BsZyjcfjMYEBJnLWgLHcS+5Ryx3EMkrOXgg0q+sdbtHlXnyPLLpdottRr8asH3wrztodI2PIiMM+K74bvM9yqTAvuuzmVstLxNJqti+I80IpzQXPh51OwWZsaHmCtDQYbYLTOfyigOSBfp7jrCZDcDaYrBzH9w/IirS5IeNdiqHpMdJkgME4NJemUL/i9TpKbd09pK4WBj0vXCKPm3W3KEU3AxTBoDOTx2Vbo+Y6JSf3BpKbA4Om0UZynzZdRUlOvYykJsOQru0jmS+MP0uJjbuIxMXCEF/IB+XomHNITDQMf+aoyFNIZBQMLHOaMycpEeEnkPAIGE5rOJKt2WGHKcqQI0iIEoawbCvJzRnHD1GUoUeRUCUMxzKaSc5MSTxPSVBdQFQJMCSmZJIsJ+VrKfAjERjyk2T5J1HVVoo17z2HAAAAAElFTkSuQmCC");
		m_ContextComposer = StubDecoratorEntry.FindInterruptibleMap("iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAMAAAD04JH5AAAABGdBTUEAALGPC/xhBQAAAwBQTFRFAAAAV6UGVqsBV6oDV6sEVqsGVqwAV6wBV6wCV6wDV6wFVqwGWKsAWKoCWKoEWKwAWKwBWawCWawDWa4BWa4CWKwEWKwFWKwGWawHW64EWq4GXK8HWawIWqwJWq0LWq4IWq4KXK0KXK4IXK8JXK4KXK0MXa4NXa4OXa4QX7AMX7AOXrAPYKgVYLEPYLARYrESYrEVY7EWYrAXY7IWZbEXZrMXZLEaZbIYZbIaZbIcZ7MdZrQaZrQcZ7QfaLMcarMfaLQaaLQdaLQea7YfbqwvabQgarQiarYgarYharYia7Yja7cka7YlbLYjbLUkbLYkbrYnb7cob7cpbrgob7grcrcrcbgqcLgrcLgscbgtcrkuc7ouc7oydLkydLowdLoxdboydro0d7s2d7o3d7w3d7s4d7w5eLs2eLs3eLw3eLs4ebs6ebs8eLw4eLw5eLw6ebw7er08erw9er0+er48e74+fb0/fL49fL4+e71Afb5Bf75Cfr9EfsBCf8BFgL9Egb9Fi75XgMBDgcBFgsBGgsBHgsBIgsJJhMFKhcJKhsNMhsNNicNPh8RQicNSiMRQiMVRicRSicRTicRUi8RVi8ZXjMZVj8dXjcZYjsdZjsdajsdbj8hZkcZbkcddkchbkclekchfk8pdlMlfkchgk8phlcljlspilspklstmlsxlmMtlmMxnmcxrm85tns5wn890n9BzoNByoNB0otB2otF3otJ3o9F4o9J4o9J6pNF4pNF5pNJ5pNJ6pdJ7ptJ8ptN+qNR+qNOAqdSAqtSDq9aDq9SErNWGrNWHrdaGr9iMudyZudyau92cvN2cw9Sy1+vE3O3K3O7I3e7N3u7O3+/Q4O/P4O/Q4e/S4fDS4/DV4/HW5PHU5PHW5PLV5PLX5fHZ5fLY5/Pb6PTc7vbj7PXk7fbk7vbm7/fp8Pfm8Pbo8ffq8Pjo8fjq8vjs8/nu8/ru9Pnt9Pnu9Prx+fvz+vv2+vz1+fz2+vv4/P34/Pz6/P76/P38/f78/v7+AAAAZILJawAAAQB0Uk5T////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AFP3ByUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAAYdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuOWwzfk4AAAgySURBVHhevZt3nBXVGYZvJAobxfudI3fBVcGCrsZAYoxedLHsKrjYULESsQRNNMoCgnEFERvYSyI/ewFFEyuxRQ0IUQiBiElULGDFwkrZjTXExdnjmZn33jt95ky5zz87O+V73/OdMueemcmJmPx15tRhA3ekfJ62Gdg8YeZz2K1MDAOPjqvfnDEiRnmpr0OMccY2r295BKcooGjg2WN60FamqhdENUc9gVMjomLgjoE1XBY7GOI9dr8XF0QhsoH5+9QwaITC+N4v4LJQIhq4tlZWeljhK8hzf3QFLg0hkoELwjPvglGhBZcHEsHAr7hC2SvIa7ofjxABhBqYUYglD9h1CONLiIF52yVQ16G+8xHKh2ADp3HEiQ0RPwHBvAky8JfeiJIMVvsYAnoRYOBs2fMQIxFy0P4NQnrgb2Bn9a7nB7G+COrGz8DiPqnJS4j6PI3ATnwM3MYjj7sR4b9HaAfeBsalU/s2aDSC2/E08MvEvc8L7jkuehk4ybf4yfLCDoCAFQ8Dx6Vd/WXY0ZCw4DZwSmb6+XyvwyFSwWVgUob6sjuOh0wZp4FZWepL+I0QKuEwsCS94c8H9jykgMNAquOfJ9QbUsBu4OcZV4DBrhAzsRk4J4MB0A07C3IGVgOLCtXQl78crDcmq4ECzsicWgjqWAyMqkYDMOCnQ1JSMbAo8x5oYQFErQbqq6ifr4eoxcAdmdyC/eA3QbZioLaaCZAzZciWDVxeVX3ZF38L4ZKBqnVBQBzCMDCtal2wBPudqQwDtdhdRQqmsmnggQxaQFhIdrMhbRronb4BCqtU2taQNgz8I/0WwIb8PaRjE1tcNuA/D48LHbGqc1l//ONHU9lA2n2QCs0rtK5vl/UJHl17lAw8lXYN0PCPta4ubeOy/sGpnQUDe6RcA1wvv07ny3WBoYfAQE2qBogO+8iQlznQXvHJgZnzbqaBhenWAGtesREGumQ76IfddkxbJKcF0sBk45/UGPYBxA06/9U/oHynGgZ2xn/p0PRuJ7QNtM5ldTjiQY1hIM0aYMM/hDLQtNUjcMwD0g0sTbEJ0pBVEC6htY0NKqBu4Kr0DBSGv2/2vxKy/GfwoPjTpIGfpmWAWOMqu74sf4uj/I7fXoOlgU2xnRh2xMpQfaeBftJAd2wnhLi7/J+2OLLrSjaXBlLqBDQM42+F9l+HxmYi92LAQ7AyVLjncmx6Q/wQZ/m7Ph0b/luLFubmYDMQdveG/7YGRCNqcpZfax+9BY4GwO7KzcZmALTlg99oXR3T/FcPeLOr/lePCy2+hK7NXY1Nf6jnrG/1kB2Tfbo0UeNbdn1NaxsTqW3RsbmDsekLbfnQ/8zwHdO9K5Uf6qr/1WOjlF8GH5Q7CJt+ULf7NyBqV/sU5i4X8aY3cbyEtibyaveA3IHY8qPnwxsqt/cvrnQbYM0ffIfDQPukJfJaw065Irb8uO9rhDVov9j5IIEPcdX/2olR5fP5uhADW1z6f1t47fMr7CtZNPSdSoIMtE/GRNeXBhqw5c0P/u1sXusus+aANb3l1P/sfAV9WQUhjfAnrzkcaF9NLTsgal6J3SVC7v8uBuROxZYfDW8gdJl1U0rjAdvfNf6tnai21tUQOhBR8VVnLXw52eiNxJvfxh4gx58WtcVWOil8KGbFFYhfQh8T5QEqrnT2vzXjVZe6rolwM+INrzoaWlfHJE7Mo/9FGv+t0K25haG3Y+JF162+46JCw3vO+lcvf569FGlCwga72sEXt77p1G8/r5dqAuS8XBoIv4pY0ZFuPeHYKNEWQ9+YkkWZlFKhaTl0fJDlV5fPkz4pjTQtJ/aL5Y4mb0NrmxBDP0+N0sBVkUYu4vsF5EDrmBhrqZmmSwNLI17Kiq87qx3I8ecCpfG3DJsjDUSelzO/dqC1K46/Zcxfx/X4LxTunYONbXHan0HBMDA16vBNMgduB9ra1nj5l5xsGFikcH3xdchWWDMxtj79zTCgtEjV+IY9B9r6KTHrX+9ZWCXbAzsiYc+BJssfV19O52Dgz0o53P/tcg60jesmxZaX3Wo2DIhu2BONQeXeKO9/avMPOz11bcPAidgTDdoXMxStPUn58/n9ygYUl+vZvsZ4oK2P3/8MjKeXhgHV1wbYPjIH2voL47c/ne0MadPAbMWiUOPy7zpak+nbHtmoP7Qq/uf8wPW3cPDcDgamK99Nkz5ppVZTGQZErNt5ApwPLsUlCQukCp0J4ZKBKrw/Y8X98FrMSNanFSmU3y4sGxC74lhV2AWiVgNLk3VrJfRnNaBiQIzqhcOZw0ZCUmIxILatUgrw1NjEauCf1RkM/F9kEmqrKzEh/1e5qvIyG1HAy2yyGeC07KA6SAGHgYWZt0P2LKSAw4CYnXFDZDdAqITTgBifaQ7oXMiUcRkQp2XYEPlREKngNiCGZ+WAmFvfy4AYmZEDdiQErHgZECOzeLGL+DEIb8PTgJiU8DV2D4jGIbgdbwPizoRTXjeFPyC0Ax8DYkm/dKcHdXMR2ImfATlDSi8JxOzjvxV/A2JMWg6Y9S1aJwEGxNx0PnSiPo8joBdBBoQ4PYVvnQojEMybYANiwQ4JDdD2TyKUDyEGhLglyY9A6n09wvgSakCIs2O+6kXET0GIACIYEOK8TRBTBapN65NPnatrlV79l+f+cCouDSGiASHmDY4+VyI26BlcFkpkA5Lb9qwN/QaOGC/87G5cEAUVA5JnRvTwHhnMnVuxmqFzcGpEFA3o/Kl1r+0Z6R9Cl6zIv8R53z1b/4hTFIhhwOTpmROafrw1dd+Mtt6tafTtft8zhiDE963c4Wu7kDZMAAAAAElFTkSuQmCC");
	}

	public LicenseViewModel()
	{
		UnlockCommand = new RelayCommand(delegate
		{
			UnlockClick();
		});
	}

	public void UnlockClick()
	{
		ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { AssociatedLicense };
		ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_StatusComposer?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void ResolveRole(object object_0)
	{
		UnlockClick();
	}
}
