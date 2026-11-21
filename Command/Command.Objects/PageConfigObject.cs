using System;

namespace Command.Objects;

internal class PageConfigObject
{
	private readonly double contextCollection = 1.79769E+30;

	private int statusCollection;

	private int _ProccesorCollection;

	private object[] _StrategyCollection;

	private double[] _ConfigurationCollection;

	public PageConfigObject()
	{
		CallParameter(20);
	}

	public PageConfigObject(int int_0)
	{
		CallParameter(int_0);
	}

	public PageConfigObject(int int_0, double double_0)
	{
		contextCollection = double_0;
		CallParameter(int_0);
	}

	private void CallParameter(int int_0)
	{
		statusCollection = int_0;
		_StrategyCollection = new object[statusCollection + 1];
		_ConfigurationCollection = new double[statusCollection + 1];
		_ConfigurationCollection[0] = contextCollection;
		_StrategyCollection[0] = null;
	}

	public void Add(object object_0, double double_0)
	{
		if (_ProccesorCollection++ >= statusCollection)
		{
			GetParameter();
		}
		_ConfigurationCollection[_ProccesorCollection] = double_0;
		_StrategyCollection[_ProccesorCollection] = object_0;
		LoginParameter(_ProccesorCollection);
	}

	public object Remove()
	{
		if (_ProccesorCollection == 0)
		{
			return null;
		}
		object result = _StrategyCollection[1];
		_StrategyCollection[1] = _StrategyCollection[_ProccesorCollection];
		_ConfigurationCollection[1] = _ConfigurationCollection[_ProccesorCollection];
		_StrategyCollection[_ProccesorCollection] = null;
		_ConfigurationCollection[_ProccesorCollection] = 0.0;
		_ProccesorCollection--;
		ValidateParameter(1);
		return result;
	}

	public object LogoutParameter()
	{
		return _StrategyCollection[1];
	}

	public double ViewParameter()
	{
		return _ConfigurationCollection[1];
	}

	private void ValidateParameter(int int_0)
	{
		object obj = _StrategyCollection[int_0];
		double num = _ConfigurationCollection[int_0];
		while (int_0 * 2 <= _ProccesorCollection)
		{
			int num2 = int_0 * 2;
			if (num2 != _ProccesorCollection && _ConfigurationCollection[num2] < _ConfigurationCollection[num2 + 1])
			{
				num2++;
			}
			if (!(num < _ConfigurationCollection[num2]))
			{
				break;
			}
			_ConfigurationCollection[int_0] = _ConfigurationCollection[num2];
			_StrategyCollection[int_0] = _StrategyCollection[num2];
			int_0 = num2;
		}
		_ConfigurationCollection[int_0] = num;
		_StrategyCollection[int_0] = obj;
	}

	private void LoginParameter(int int_0)
	{
		object obj = _StrategyCollection[int_0];
		double num = _ConfigurationCollection[int_0];
		while (_ConfigurationCollection[int_0 / 2] < num)
		{
			_ConfigurationCollection[int_0] = _ConfigurationCollection[int_0 / 2];
			_StrategyCollection[int_0] = _StrategyCollection[int_0 / 2];
			int_0 /= 2;
		}
		_ConfigurationCollection[int_0] = num;
		_StrategyCollection[int_0] = obj;
	}

	private void GetParameter()
	{
		statusCollection = _ProccesorCollection * 2;
		object[] array = new object[statusCollection + 1];
		double[] array2 = new double[statusCollection + 1];
		Array.Copy(_StrategyCollection, 0, array, 0, _StrategyCollection.Length);
		Array.Copy(_ConfigurationCollection, 0, array2, 0, _StrategyCollection.Length);
		_StrategyCollection = array;
		_ConfigurationCollection = array2;
	}

	public void WriteParameter()
	{
		for (int i = 1; i < _ProccesorCollection; i++)
		{
			_StrategyCollection[i] = null;
		}
		_ProccesorCollection = 0;
	}

	public int NewParameter()
	{
		return _ProccesorCollection;
	}
}
