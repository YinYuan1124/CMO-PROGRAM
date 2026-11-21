using System;

namespace DotSpatial.Topology;

public class MatrixD : IMatrix, IMatrixD
{
	private int m_AttributeProcess;

	private int m_EventProcess;

	private double[,] _GlobalProcess;

	public int M => m_AttributeProcess;

	public int N => m_EventProcess;

	public int NumRows => m_AttributeProcess;

	public int NumColumns => m_EventProcess;

	public double[,] Values
	{
		get
		{
			return _GlobalProcess;
		}
		set
		{
			_GlobalProcess = value;
			m_AttributeProcess = _GlobalProcess.GetLength(0);
			m_EventProcess = _GlobalProcess.GetLength(1);
		}
	}

	public MatrixD(int int_0)
	{
		_GlobalProcess = new double[int_0, int_0];
		m_AttributeProcess = int_0;
		m_EventProcess = int_0;
	}

	public MatrixD(int int_0, int int_1)
	{
		_GlobalProcess = new double[int_0, int_1];
		m_AttributeProcess = int_0;
		m_EventProcess = int_1;
	}

	public MatrixD(double[,] double_0)
	{
		_GlobalProcess = double_0;
		m_AttributeProcess = double_0.GetLength(0);
		m_EventProcess = double_0.GetLength(1);
	}

	public IMatrixD Multiply(IMatrixD imatrixD_0)
	{
		if (imatrixD_0.NumRows == NumColumns)
		{
			int numRows = NumRows;
			int numColumns = imatrixD_0.NumColumns;
			double[,] array = new double[numRows, numColumns];
			for (int i = 0; i < numRows; i++)
			{
				for (int j = 0; j < numColumns; j++)
				{
					array[i, j] = 0.0;
					for (int k = 0; k < NumColumns; k++)
					{
						array[i, j] += _GlobalProcess[i, k] * imatrixD_0.Values[k, j];
					}
				}
			}
			return new MatrixD(array);
		}
		throw new ArgumentException("Matrix multiplication only works if the number of columns of the first matrix is the same as the number of rows of the second matrix");
	}

	IMatrix IMatrix.Multiply(IMatrix imatrix_0)
	{
		if (!(imatrix_0 is IMatrixD imatrixD_))
		{
			throw new ArgumentException("Invalid Matrix provided for inMatrix");
		}
		return Multiply(imatrixD_);
	}

	public IMatrixD Multiply(double double_0)
	{
		double[,] array = new double[NumRows, NumColumns];
		for (int i = 0; i < NumRows; i++)
		{
			for (int j = 0; j < NumColumns; j++)
			{
				array[i, j] = _GlobalProcess[i, j] * double_0;
			}
		}
		return new MatrixD(array);
	}
}
