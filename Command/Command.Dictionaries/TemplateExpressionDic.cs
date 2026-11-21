using System.Windows.Forms;
using ScintillaNET;

namespace Command.Dictionaries;

internal class TemplateExpressionDic
{
	public static Scintilla _ValueCallback;

	public static Control tokenizerCallback;

	public static string _StubCallback;

	public static int m_WriterCallback;

	public static void CalcCallback(bool bool_0, bool bool_1)
	{
		_ = _StubCallback != tokenizerCallback.Text;
		_StubCallback = tokenizerCallback.Text;
		if (_StubCallback.Length > 0)
		{
			if (bool_0)
			{
				_ValueCallback.TargetStart = m_WriterCallback - 1;
				_ValueCallback.TargetEnd = m_WriterCallback + (_StubCallback.Length + 1);
				_ValueCallback.SearchFlags = SearchFlags.None;
				if (!bool_1 || _ValueCallback.SearchInTarget(_StubCallback) == -1)
				{
					_ValueCallback.TargetStart = _ValueCallback.CurrentPosition;
					_ValueCallback.TargetEnd = _ValueCallback.TextLength;
					_ValueCallback.SearchFlags = SearchFlags.None;
					if (_ValueCallback.SearchInTarget(_StubCallback) == -1)
					{
						_ValueCallback.TargetStart = 0;
						_ValueCallback.TargetEnd = _ValueCallback.TextLength;
						if (_ValueCallback.SearchInTarget(_StubCallback) == -1)
						{
							_ValueCallback.ClearSelections();
							return;
						}
					}
				}
			}
			else
			{
				_ValueCallback.TargetStart = 0;
				_ValueCallback.TargetEnd = _ValueCallback.CurrentPosition;
				_ValueCallback.SearchFlags = SearchFlags.None;
				if (_ValueCallback.SearchInTarget(_StubCallback) == -1)
				{
					_ValueCallback.TargetStart = _ValueCallback.CurrentPosition;
					_ValueCallback.TargetEnd = _ValueCallback.TextLength;
					if (_ValueCallback.SearchInTarget(_StubCallback) == -1)
					{
						_ValueCallback.ClearSelections();
						return;
					}
				}
			}
			m_WriterCallback = _ValueCallback.TargetStart;
			_ValueCallback.SetSelection(_ValueCallback.TargetEnd, _ValueCallback.TargetStart);
			_ValueCallback.ScrollCaret();
		}
		tokenizerCallback.Focus();
	}

	static TemplateExpressionDic()
	{
		_StubCallback = "";
	}
}
