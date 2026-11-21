using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class BinGridModule
{
	public sealed class TBinGrid
	{
		internal class ContainerMapping
		{
			private CandidateExpressionDic _ComposerMapping;

			private CacheItemPolicy m_ModelMapping;

			public ContainerMapping()
			{
				_ComposerMapping = new CandidateExpressionDic();
			}

			[SpecialName]
			private CacheItemPolicy method_0()
			{
				if (m_ModelMapping == null)
				{
					CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
					cacheItemPolicy.SlidingExpiration = new TimeSpan(0, 0, 15);
					m_ModelMapping = cacheItemPolicy;
				}
				return m_ModelMapping;
			}

			public short? IncludeInterruptiblePolicy(short short_0, short short_1)
			{
				try
				{
					if (!_ComposerMapping.TryGetValue(short_0, out var value))
					{
						value = _ComposerMapping.Add(short_0);
					}
					if (value.TryGetValue(short_1, out var value2))
					{
						return value2;
					}
					return null;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200494", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return null;
				}
			}

			public void SearchInterruptiblePolicy(short short_0, short short_1, short short_2)
			{
				try
				{
					if (_ComposerMapping.TryGetValue(short_0, out var value))
					{
						if (value.ContainsKey(short_1))
						{
							value[short_1] = short_2;
						}
						else
						{
							value.Add(short_1, short_2);
						}
					}
					else
					{
						value = _ComposerMapping.Add(short_0);
						value.Add(short_1, short_2);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200496", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}

		internal class AdvisorMapping : ConcurrentDictionary<short, short>
		{
			public AdvisorMapping Add(short short_0, short short_1)
			{
				TryAdd(short_0, short_1);
				return this;
			}
		}

		internal class CandidateExpressionDic : ConcurrentDictionary<short, AdvisorMapping>
		{
			internal AdvisorMapping Add(short short_0)
			{
				if (ContainsKey(short_0))
				{
					return base[short_0];
				}
				AdvisorMapping advisorMapping = new AdvisorMapping();
				TryAdd(short_0, advisorMapping);
				return advisorMapping;
			}
		}

		public double dx;

		public double dy;

		public double xllcenter;

		public double yllcenter;

		public int ncols;

		public int nrows;

		public int datatype;

		public int i4nodata;

		public short i2nodata;

		public double r8nodata;

		public float r4nodata;

		public byte[] projection;

		public byte[] notes;

		public int[][] i4array;

		public short[][] i2array;

		public double[][] r8array;

		public float[][] r4array;

		private string m_DescriptorComparator;

		internal ContainerMapping poolComparator;

		private object taskComparator;

		public bool ReadingInProgress;

		protected FileStream _fs;

		protected BinaryReader _BR;

		public string Filename => m_DescriptorComparator;

		public double xurcenter
		{
			get
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				CellToProj(ncols - 1, 0, ref double_, ref double_2);
				return double_;
			}
		}

		public double yurcenter
		{
			get
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				CellToProj(ncols - 1, 0, ref double_, ref double_2);
				return double_2;
			}
		}

		public double xExtent
		{
			get
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				CellToProj(ncols - 1, 0, ref double_, ref double_2);
				return double_ - xllcenter;
			}
		}

		public double yExtent
		{
			get
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				CellToProj(ncols - 1, 0, ref double_, ref double_2);
				return double_2 - yllcenter;
			}
		}

		internal float[,] RunInterruptibleTag()
		{
			float[,] array = new float[nrows - 1 + 1, ncols - 1 + 1];
			switch (datatype)
			{
			case 0:
			{
				int num8 = nrows - 1;
				for (int num9 = 0; num9 <= num8; num9++)
				{
					int num10 = ncols - 1;
					for (int num2 = 0; num2 <= num10; num2++)
					{
						array[num9, num2] = i2array[num9][num2];
					}
				}
				break;
			}
			case 1:
			{
				int num4 = nrows - 1;
				for (int k = 0; k <= num4; k++)
				{
					int num5 = ncols - 1;
					for (int l = 0; l <= num5; l++)
					{
						array[k, l] = i4array[k][l];
					}
				}
				break;
			}
			case 2:
			{
				int num6 = nrows - 1;
				for (int m = 0; m <= num6; m++)
				{
					int num7 = ncols - 1;
					for (int n = 0; n <= num7; n++)
					{
						array[m, n] = r4array[m][n];
					}
				}
				break;
			}
			case 3:
			{
				int num = nrows - 1;
				for (int i = 0; i <= num; i++)
				{
					int num3 = ncols - 1;
					for (int j = 0; j <= num3; j++)
					{
						array[i, j] = (float)r8array[i][j];
					}
				}
				break;
			}
			}
			return array;
		}

		internal (int, int) StartInterruptibleTag(ref double double_0, ref double double_1)
		{
			try
			{
				int num = (int)Math.Round((double_0 - xllcenter) / dx);
				int num2 = (int)Math.Round((double)nrows - Math.Round((double_1 - yllcenter) / dy) - 1.0);
				_ = Debugger.IsAttached;
				if (num2 >= nrows)
				{
					num2 = nrows;
				}
				if (num2 == -1)
				{
					num2 = 0;
				}
				if (num >= ncols)
				{
					num = ncols;
				}
				if (num == -1)
				{
					num = 0;
				}
				return (num2, num);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200300", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				(int, int) result = (0, 0);
				ProjectData.ClearProjectError();
				return result;
			}
		}

		public void CellToProj(int int_0, int int_1, ref double double_0, ref double double_1)
		{
			try
			{
				if (int_1 < 0 || int_1 >= nrows)
				{
					throw new Exception("row doesn't belong to this tile");
				}
				if (int_0 < 0 || int_0 >= ncols)
				{
					throw new Exception("column doesn't belong to this tile");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200227", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			double_0 = xllcenter + (double)int_0 * dx;
			double_1 = yllcenter + (double)(nrows - int_1 - 1) * dy;
		}

		private short AssetInterruptibleTag()
		{
			try
			{
				if (i2array == null)
				{
					throw new Exception("i2array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200228", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			short num = short.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					short num4 = i2array[i][j];
					if (num4 != i2nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		private short PrintInterruptibleTag()
		{
			try
			{
				if (i2array == null)
				{
					throw new Exception("i2array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200229", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			short num = short.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					short num4 = i2array[i][j];
					if (num4 != i2nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		private int DefineInterruptibleTag()
		{
			try
			{
				if (i4array == null)
				{
					throw new Exception("i4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200234", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int num = int.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = i4array[i][j];
					if (num4 != i4nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal int PublishInterruptibleTag()
		{
			try
			{
				if (i4array == null)
				{
					throw new Exception("i4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200235", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int num = int.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = i4array[i][j];
					if (num4 != i4nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal float AwakeInterruptibleTag()
		{
			try
			{
				if (r4array == null)
				{
					throw new Exception("r4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200236", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			float num = float.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					float num4 = r4array[i][j];
					if (num4 != r4nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal float QueryInterruptibleTag()
		{
			try
			{
				if (r4array == null)
				{
					throw new Exception("r4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200237", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			float num = float.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					float num4 = r4array[i][j];
					if (num4 != r4nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal double ResetInterruptibleTag()
		{
			try
			{
				if (r8array == null)
				{
					throw new Exception("r8array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200238", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			double num = double.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					double num4 = r8array[i][j];
					if (num4 != r8nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal double MapInterruptibleTag()
		{
			try
			{
				if (r8array == null)
				{
					throw new Exception("r8array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200239", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			double num = double.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					double num4 = r8array[i][j];
					if (num4 != r8nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal int SortInterruptibleTag(double double_0)
		{
			if (Math.Ceiling(double_0) - double_0 <= 0.5)
			{
				return (int)Math.Ceiling(double_0);
			}
			return RadarModel.PrintStub(double_0);
		}

		protected void dealloc()
		{
			if (i2array != null)
			{
				int num = nrows - 1;
				for (int i = 0; i <= num; i++)
				{
					i2array[i] = null;
				}
				i2array = null;
			}
			if (i4array != null)
			{
				int num2 = nrows - 1;
				for (int j = 0; j <= num2; j++)
				{
					i4array[j] = null;
				}
				i4array = null;
			}
			if (r4array != null)
			{
				int num3 = nrows - 1;
				for (int k = 0; k <= num3; k++)
				{
					r4array[k] = null;
				}
				r4array = null;
			}
			if (r8array != null)
			{
				int num4 = nrows - 1;
				for (int l = 0; l <= num4; l++)
				{
					r8array[l] = null;
				}
				r8array = null;
			}
		}

		protected void method_0()
		{
			i2array = new short[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				i2array[i] = new short[ncols - 1 + 1];
			}
		}

		protected void method_1()
		{
			i4array = new int[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				i4array[i] = new int[ncols - 1 + 1];
			}
		}

		protected void method_2()
		{
			r4array = new float[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				r4array[i] = new float[ncols - 1 + 1];
			}
		}

		protected void method_3()
		{
			r8array = new double[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				r8array[i] = new double[ncols - 1 + 1];
			}
		}

		internal bool CalcInterruptibleTag(string string_0)
		{
			FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.SequentialScan);
			BinaryReader binaryReader = new BinaryReader(fileStream, new ASCIIEncoding());
			try
			{
				int num = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				dx = binaryReader.ReadDouble();
				dy = binaryReader.ReadDouble();
				xllcenter = binaryReader.ReadDouble();
				yllcenter = binaryReader.ReadDouble();
				int num3 = binaryReader.ReadInt32();
				if (num3 != datatype)
				{
					dealloc();
				}
				datatype = num3;
				switch (datatype)
				{
				default:
					try
					{
						throw new Exception("invalid datatype");
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200241", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				case 0:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_0();
					}
					i2nodata = binaryReader.ReadInt16();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array3 = new byte[ncols * 2 - 1 + 1];
					int num6 = nrows;
					for (int k = 1; k <= num6; k++)
					{
						fileStream.Read(array3, 0, ncols * 2);
						Buffer.BlockCopy(array3, 0, i2array[k - 1], 0, ncols * 2);
					}
					break;
				}
				case 1:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_1();
					}
					i4nodata = binaryReader.ReadInt32();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array2 = new byte[ncols * 4 - 1 + 1];
					int num5 = nrows;
					for (int j = 1; j <= num5; j++)
					{
						fileStream.Read(array2, 0, ncols * 4);
						Buffer.BlockCopy(array2, 0, i4array[j - 1], 0, ncols * 4);
					}
					break;
				}
				case 2:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_2();
					}
					r4nodata = binaryReader.ReadSingle();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array4 = new byte[ncols * 4 - 1 + 1];
					int num7 = nrows;
					for (int l = 1; l <= num7; l++)
					{
						fileStream.Read(array4, 0, ncols * 4);
						Buffer.BlockCopy(array4, 0, r4array[l - 1], 0, ncols * 4);
					}
					break;
				}
				case 3:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_3();
					}
					r8nodata = binaryReader.ReadDouble();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array = new byte[ncols * 8 - 1 + 1];
					int num4 = nrows;
					for (int i = 1; i <= num4; i++)
					{
						fileStream.Read(array, 0, ncols * 8);
						Buffer.BlockCopy(array, 0, r8array[i - 1], 0, ncols * 8);
					}
					break;
				}
				case 4:
					try
					{
						throw new Exception("unknown datatype");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200240", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 200242", exception_3.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
			finally
			{
				binaryReader.Close();
			}
			return true;
		}

		public TBinGrid(string string_0)
		{
			datatype = -1;
			projection = new byte[255];
			notes = new byte[255];
			taskComparator = RuntimeHelpers.GetObjectValue(new object());
			m_DescriptorComparator = string_0;
		}

		public void CloseTile()
		{
			try
			{
				if (!Information.IsNothing(_BR))
				{
					_BR.Close();
					_BR = null;
				}
				if (!Information.IsNothing(_fs))
				{
					_fs = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		private void RateInterruptibleTag(double double_0, double double_1, ref short short_0)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 0)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200243", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			(int, int) tuple = StartInterruptibleTag(ref double_0, ref double_1);
			_fs.Seek(556 + tuple.Item1 * ncols * 2 + tuple.Item2 * 2, SeekOrigin.Begin);
			short_0 = _BR.ReadInt16();
		}

		internal Terrain.TerrainRasterCell FlushInterruptibleTag(double double_0, double double_1)
		{
			try
			{
				ReadingInProgress = true;
				if (_fs == null || double.IsNaN(xllcenter) || double.IsNaN(yllcenter) || xllcenter == 0.0 || yllcenter == 0.0 || xllcenter < -180.0 || xllcenter > 180.0 || yllcenter < -90.0 || yllcenter > 90.0 || (xllcenter < 1.0 && xllcenter > -1.0) || (yllcenter < 1.0 && yllcenter > -1.0) || double.IsNaN(xllcenter) || double.IsNaN(yllcenter))
				{
					object obj = taskComparator;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						ManageInterruptibleTag(GameGeneral.GISFolderPath + "\\Terrain\\SRTM30Plus\\" + Filename);
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(obj);
						}
					}
				}
				ReadingInProgress = false;
				double_1 = Math2.VisitClass(double_1);
				double_0 = Math2.ReflectClass(double_0);
				int num;
				int num2;
				try
				{
					(num, num2) = StartInterruptibleTag(ref double_1, ref double_0);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 20023452456546344442221", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return default(Terrain.TerrainRasterCell);
				}
				if (num > nrows - 1)
				{
					_ = Debugger.IsAttached;
					num = nrows - 1;
				}
				if (num2 > ncols - 1)
				{
					_ = Debugger.IsAttached;
					num2 = ncols - 1;
				}
				double double_2 = 0.0;
				double double_3 = 0.0;
				CellToProj(num2, num, ref double_2, ref double_3);
				Terrain.TerrainRasterCell result = default(Terrain.TerrainRasterCell);
				result.CenterLatitude = double_3;
				result.CenterLongitude = double_2;
				result.UniqueKey = "SRTM30PLUS_" + Filename + "_" + Conversions.ToString(num2) + "_" + Conversions.ToString(num);
				return result;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 101292353453266662", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return default(Terrain.TerrainRasterCell);
			}
		}

		internal short ForgotInterruptibleTag(double double_0, double double_1, bool bool_0)
		{
			try
			{
				ReadingInProgress = true;
				if (_fs == null || double.IsNaN(xllcenter) || double.IsNaN(yllcenter) || xllcenter == 0.0 || yllcenter == 0.0 || xllcenter < -180.0 || xllcenter > 180.0 || yllcenter < -90.0 || yllcenter > 90.0 || (xllcenter < 1.0 && xllcenter > -1.0) || (yllcenter < 1.0 && yllcenter > -1.0) || double.IsNaN(xllcenter) || double.IsNaN(yllcenter))
				{
					ManageInterruptibleTag(Path.Combine(BinaryGridProvider._TokenObserver, m_DescriptorComparator));
				}
				if (poolComparator == null)
				{
					poolComparator = new ContainerMapping();
				}
				double_0 = Math2.VisitClass(double_0);
				double_1 = Math2.ReflectClass(double_1);
				int num;
				int num2;
				try
				{
					(num, num2) = StartInterruptibleTag(ref double_0, ref double_1);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200030", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return 0;
				}
				if (num > nrows - 1)
				{
					_ = Debugger.IsAttached;
					num = nrows - 1;
				}
				if (num2 > ncols - 1)
				{
					_ = Debugger.IsAttached;
					num2 = ncols - 1;
				}
				short? num3 = poolComparator.IncludeInterruptiblePolicy((short)num, (short)num2);
				if (num3.HasValue)
				{
					int? num4 = num3;
					if (!(num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						goto IL_0309;
					}
				}
				int int_ = 0;
				try
				{
					ReadValueFromOpenTile(num, num2, ref int_);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ReadValueFromOpenTile(num, num2, ref int_);
					ProjectData.ClearProjectError();
				}
				num3 = ((int_ > 32767 || int_ < -32768) ? new short?(0) : new short?((short)int_));
				if (num >= 0 && num2 >= 0)
				{
					poolComparator.SearchInterruptiblePolicy((short)num, (short)num2, num3.Value);
				}
				goto IL_0309;
				IL_0309:
				short short_ = num3.Value;
				CollectInterruptibleTag(ref short_);
				return num3.Value;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 101294", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
			finally
			{
				ReadingInProgress = false;
			}
		}

		private void CollectInterruptibleTag(ref short short_0)
		{
			if (short_0 < 0 && short_0 > -20)
			{
				short_0 = -20;
			}
		}

		public void ReadValueFromOpenTile(int int_0, int int_1, ref int int_2)
		{
			try
			{
				object obj = taskComparator;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (_fs == null)
					{
						ManageInterruptibleTag(Path.Combine(BinaryGridProvider._TokenObserver, m_DescriptorComparator));
					}
					if (datatype != 1)
					{
						throw new Exception("invalid data type");
					}
					_fs.Seek(558 + int_0 * ncols * 4 + int_1 * 4, SeekOrigin.Begin);
					int_2 = _BR.ReadInt32();
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200245", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		private void OrderInterruptibleTag(double double_0, double double_1, ref float float_0)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 2)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200246", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			var (num, num2) = StartInterruptibleTag(ref double_0, ref double_1);
			_fs.Seek(558 + num * ncols * 4 + num2 * 4, SeekOrigin.Begin);
			float_0 = _BR.ReadSingle();
		}

		private void RegisterInterruptibleTag(double double_0, double double_1, ref double double_2)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 3)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200247", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			var (num, num2) = StartInterruptibleTag(ref double_0, ref double_1);
			_fs.Seek(562 + num * ncols * 8 + num2 * 8, SeekOrigin.Begin);
			double_2 = _BR.ReadDouble();
		}

		internal bool ManageInterruptibleTag(string string_0)
		{
			object obj = taskComparator;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				_fs = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.RandomAccess);
				_BR = new BinaryReader(_fs, new ASCIIEncoding());
				try
				{
					_fs.Seek(0L, SeekOrigin.Begin);
					int num = _BR.ReadInt32();
					int num2 = _BR.ReadInt32();
					dx = _BR.ReadDouble();
					dy = _BR.ReadDouble();
					xllcenter = _BR.ReadDouble();
					yllcenter = _BR.ReadDouble();
					datatype = _BR.ReadInt32();
					switch (datatype)
					{
					default:
						try
						{
							throw new Exception("invalid datatype");
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 200249", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							_ = Debugger.IsAttached;
							throw;
						}
					case 0:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						i2nodata = _BR.ReadInt16();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 1:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						i4nodata = _BR.ReadInt32();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 2:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						r4nodata = _BR.ReadSingle();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 3:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						r8nodata = _BR.ReadDouble();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 4:
						try
						{
							throw new Exception("unknown datatype");
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200248", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 200250", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return false;
				}
				return true;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}

		internal bool RevertInterruptibleTag(string string_0, bool bool_0)
		{
			FileMode mode = ((!bool_0) ? FileMode.CreateNew : FileMode.Create);
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(string_0, mode, FileAccess.Write, FileShare.None, 65536, FileOptions.SequentialScan);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return false;
			}
			BinaryWriter binaryWriter = new BinaryWriter(fileStream, new ASCIIEncoding());
			try
			{
				binaryWriter.Write(ncols);
				binaryWriter.Write(nrows);
				binaryWriter.Write(dx);
				binaryWriter.Write(dy);
				binaryWriter.Write(xllcenter);
				binaryWriter.Write(yllcenter);
				binaryWriter.Write(datatype);
				switch (datatype)
				{
				default:
					try
					{
						throw new Exception("invalid datatype");
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200252", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				case 0:
				{
					binaryWriter.Write(i2nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr4 = Marshal.AllocHGlobal(2 * ncols);
					byte[] array4 = new byte[ncols * 2 - 1 + 1];
					int num4 = nrows;
					for (int l = 1; l <= num4; l++)
					{
						Marshal.Copy(i2array[l - 1], 0, intPtr4, ncols);
						Marshal.Copy(intPtr4, array4, 0, ncols * 2);
						fileStream.Write(array4, 0, ncols * 2);
					}
					Marshal.FreeHGlobal(intPtr4);
					break;
				}
				case 1:
				{
					binaryWriter.Write(i4nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr2 = Marshal.AllocHGlobal(4 * ncols);
					byte[] array2 = new byte[ncols * 4 - 1 + 1];
					int num2 = nrows;
					for (int j = 1; j <= num2; j++)
					{
						Marshal.Copy(i4array[j - 1], 0, intPtr2, ncols);
						Marshal.Copy(intPtr2, array2, 0, ncols * 4);
						fileStream.Write(array2, 0, ncols * 4);
					}
					Marshal.FreeHGlobal(intPtr2);
					break;
				}
				case 2:
				{
					binaryWriter.Write(r4nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr3 = Marshal.AllocHGlobal(4 * ncols);
					byte[] array3 = new byte[ncols * 4 - 1 + 1];
					int num3 = nrows;
					for (int k = 1; k <= num3; k++)
					{
						Marshal.Copy(r4array[k - 1], 0, intPtr3, ncols);
						Marshal.Copy(intPtr3, array3, 0, ncols * 4);
						fileStream.Write(array3, 0, ncols * 4);
					}
					Marshal.FreeHGlobal(intPtr3);
					break;
				}
				case 3:
				{
					binaryWriter.Write(r8nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr = Marshal.AllocHGlobal(8 * ncols);
					byte[] array = new byte[ncols * 8 - 1 + 1];
					int num = nrows;
					for (int i = 1; i <= num; i++)
					{
						Marshal.Copy(r8array[i - 1], 0, intPtr, ncols);
						Marshal.Copy(intPtr, array, 0, ncols * 8);
						fileStream.Write(array, 0, ncols * 8);
					}
					Marshal.FreeHGlobal(intPtr);
					break;
				}
				case 4:
					try
					{
						throw new Exception("unknown datatype");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200251", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 200253", exception_3.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
			finally
			{
				binaryWriter.Close();
			}
			return true;
		}
	}

	public const string ModuleVersion = "version 0.06";

	public const string ModuleCredits = "MapWindow 6 developers for new info on copying raw data";
}
