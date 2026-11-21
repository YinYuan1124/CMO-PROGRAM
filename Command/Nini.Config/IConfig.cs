namespace Nini.Config;

public interface IConfig
{
	IConfigSource ConfigSource { get; }

	string Name { get; set; }

	AliasText Alias { get; }

	event ConfigKeyEventHandler KeySet;

	event ConfigKeyEventHandler KeyRemoved;

	bool Contains(string string_0);

	string Get(string string_0);

	string Get(string string_0, string string_1);

	string GetExpanded(string string_0);

	string GetString(string string_0);

	string GetString(string string_0, string string_1);

	int GetInt(string string_0);

	int GetInt(string string_0, bool bool_0);

	int GetInt(string string_0, int int_0);

	int GetInt(string string_0, int int_0, bool bool_0);

	long GetLong(string string_0);

	long GetLong(string string_0, long long_0);

	bool GetBoolean(string string_0);

	bool GetBoolean(string string_0, bool bool_0);

	float GetFloat(string string_0);

	float GetFloat(string string_0, float float_0);

	double GetDouble(string string_0);

	double GetDouble(string string_0, double double_0);

	string[] GetKeys();

	string[] GetValues();

	void Set(string string_0, object object_0);

	void Remove(string string_0);
}
