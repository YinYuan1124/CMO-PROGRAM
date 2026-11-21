using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using Command.Filters;

namespace Catfood.Shapefile;

public sealed class Shapefile : IEnumerator<Shape>, IDisposable, IEnumerator, IEnumerable<Shape>, IEnumerable
{
	public const string ConnectionStringTemplateJet = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV";

	public const string ConnectionStringTemplateAce = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=dBase IV";

	private bool m_WatcherListener;

	private bool m_ReponseListener;

	private bool descriptorListener;

	private int m_PoolListener = -1;

	private int taskListener;

	private RectangleD filterListener;

	private ShapeType testsListener;

	private string m_InterpreterListener;

	private string _ContainerListener;

	private string _ComposerListener;

	private string _ModelListener;

	private FileStream m_AdvisorListener;

	private FileStream m_CustomerListener;

	private Header m_SerializerListener;

	private Header _RefListener;

	private string _ErrorListener;

	public string ConnectionStringTemplate
	{
		get
		{
			return _ErrorListener;
		}
		set
		{
			_ErrorListener = value;
		}
	}

	public bool RawMetadataOnly
	{
		get
		{
			return descriptorListener;
		}
		set
		{
			descriptorListener = value;
		}
	}

	public int Count
	{
		get
		{
			if (m_WatcherListener)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!m_ReponseListener)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return taskListener;
		}
	}

	public RectangleD BoundingBox
	{
		get
		{
			if (m_WatcherListener)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!m_ReponseListener)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return filterListener;
		}
	}

	public ShapeType Type
	{
		get
		{
			if (m_WatcherListener)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!m_ReponseListener)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return testsListener;
		}
	}

	public Shape Current
	{
		get
		{
			if (m_WatcherListener)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (m_ReponseListener)
			{
				StringDictionary stringDictionary_ = null;
				if (!RawMetadataOnly)
				{
					stringDictionary_ = new StringDictionary();
				}
				byte[] array = new byte[8];
				m_CustomerListener.Seek(100 + m_PoolListener * 8, SeekOrigin.Begin);
				m_CustomerListener.Read(array, 0, array.Length);
				int num = EndianBitConverter.ToInt32(array, 0, ProvidedOrder.Big);
				int num2 = EndianBitConverter.ToInt32(array, 4, ProvidedOrder.Big) * 2 + 8;
				byte[] array2 = new byte[num2];
				m_AdvisorListener.Seek(num * 2, SeekOrigin.Begin);
				m_AdvisorListener.Read(array2, 0, num2);
				return SpecificationListener.DestroyObserver(array2, stringDictionary_, null);
			}
			throw new InvalidOperationException("Shapefile not open.");
		}
	}

	object IEnumerator.Current
	{
		get
		{
			if (m_WatcherListener)
			{
				throw new ObjectDisposedException("Shapefile");
			}
			if (!m_ReponseListener)
			{
				throw new InvalidOperationException("Shapefile not open.");
			}
			return Current;
		}
	}

	public Shapefile()
		: this(null, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV")
	{
	}

	public Shapefile(string string_0)
		: this(string_0, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=dBase IV")
	{
	}

	public Shapefile(string string_0, string string_1)
	{
		if (string_1 == null)
		{
			throw new ArgumentNullException("connectionStringTemplate");
		}
		ConnectionStringTemplate = string_1;
		if (string_0 != null)
		{
			Open(string_0);
		}
	}

	public void Open(string string_0)
	{
		if (m_WatcherListener)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (string_0 == null)
		{
			throw new ArgumentNullException("path");
		}
		if (string_0.Length <= 0)
		{
			throw new ArgumentException("path parameter is empty", "path");
		}
		m_InterpreterListener = Path.ChangeExtension(string_0, "shp");
		_ContainerListener = Path.ChangeExtension(string_0, "shx");
		_ComposerListener = Path.ChangeExtension(string_0, "dbf");
		if (FileExistsNative.FileExistsFast(m_InterpreterListener))
		{
			if (FileExistsNative.FileExistsFast(_ContainerListener))
			{
				if (FileExistsNative.FileExistsFast(_ComposerListener))
				{
					m_AdvisorListener = File.Open(m_InterpreterListener, FileMode.Open, FileAccess.Read, FileShare.Read);
					m_CustomerListener = File.Open(_ContainerListener, FileMode.Open, FileAccess.Read, FileShare.Read);
					if (m_AdvisorListener.Length < 100)
					{
						throw new InvalidOperationException("Shapefile main file does not contain a valid header");
					}
					if (m_CustomerListener.Length < 100)
					{
						throw new InvalidOperationException("Shapefile index file does not contain a valid header");
					}
					byte[] array = new byte[100];
					m_AdvisorListener.Read(array, 0, 100);
					m_SerializerListener = new Header(array);
					m_CustomerListener.Read(array, 0, 100);
					_RefListener = new Header(array);
					testsListener = m_SerializerListener.MapWrapper();
					filterListener = new RectangleD(m_SerializerListener.CalcWrapper(), m_SerializerListener.FlushWrapper(), m_SerializerListener.CollectWrapper(), m_SerializerListener.RegisterWrapper());
					taskListener = (_RefListener.AwakeWrapper() - 50) / 4;
					ComputeObserver();
					m_ReponseListener = true;
					return;
				}
				throw new FileNotFoundException("Shapefile dBase file not found", _ComposerListener);
			}
			throw new FileNotFoundException("Shapefile index file not found", _ContainerListener);
		}
		throw new FileNotFoundException("Shapefile main file not found", m_InterpreterListener);
	}

	public void Close()
	{
		Dispose();
	}

	private void ComputeObserver()
	{
	}

	private void PatchObserver()
	{
	}

	~Shapefile()
	{
		SelectObserver(bool_0: false);
	}

	public void Dispose()
	{
		SelectObserver(bool_0: true);
		GC.SuppressFinalize(this);
	}

	private void SelectObserver(bool bool_0)
	{
		if (m_WatcherListener)
		{
			return;
		}
		if (bool_0)
		{
			if (m_AdvisorListener != null)
			{
				m_AdvisorListener.Close();
				m_AdvisorListener = null;
			}
			if (m_CustomerListener != null)
			{
				m_CustomerListener.Close();
				m_CustomerListener = null;
			}
			PatchObserver();
		}
		m_WatcherListener = true;
		m_ReponseListener = false;
	}

	public bool MoveNext()
	{
		if (m_WatcherListener)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (m_ReponseListener)
		{
			if (m_PoolListener++ < taskListener - 1)
			{
				return true;
			}
			return false;
		}
		throw new InvalidOperationException("Shapefile not open.");
	}

	public void Reset()
	{
		if (m_WatcherListener)
		{
			throw new ObjectDisposedException("Shapefile");
		}
		if (!m_ReponseListener)
		{
			throw new InvalidOperationException("Shapefile not open.");
		}
		PatchObserver();
		ComputeObserver();
		m_PoolListener = -1;
	}

	public IEnumerator<Shape> GetEnumerator()
	{
		return this;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this;
	}
}
