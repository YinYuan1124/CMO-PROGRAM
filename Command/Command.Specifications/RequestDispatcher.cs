namespace Command.Specifications;

internal class RequestDispatcher<K, V>
{
	public K _ValueDispatcher;

	public V _TokenizerDispatcher;

	public RequestDispatcher(K k, V v)
	{
		_ValueDispatcher = k;
		_TokenizerDispatcher = v;
	}
}
