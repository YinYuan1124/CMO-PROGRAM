using System;
using System.Net;
using System.Runtime.Caching;

namespace CSMaterial;

public static class HTTPHelper
{
	[ThreadStatic]
	private static WebClient _ProxyDispatcher;

	private static MemoryCache m_ReaderDispatcher;

	private static CacheItemPolicy m_PropertyDispatcher;

	private static CacheItemPolicy RemoveDefinition()
	{
		if (m_PropertyDispatcher == null)
		{
			m_PropertyDispatcher = new CacheItemPolicy
			{
				SlidingExpiration = new TimeSpan(0, 0, 15)
			};
		}
		return m_PropertyDispatcher;
	}

	public static byte[] DownloadTile(string string_0)
	{
		if (m_ReaderDispatcher.Get(string_0) == null)
		{
			if (_ProxyDispatcher == null)
			{
				_ProxyDispatcher = new WebClient();
			}
			try
			{
				return _ProxyDispatcher.DownloadData(string_0);
			}
			catch (Exception)
			{
				m_ReaderDispatcher.Add(string_0, true, RemoveDefinition());
				return null;
			}
		}
		return null;
	}

	static HTTPHelper()
	{
		m_ReaderDispatcher = new MemoryCache("Bad Tile URLs Cache");
	}
}
