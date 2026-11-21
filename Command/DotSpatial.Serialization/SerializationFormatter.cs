namespace DotSpatial.Serialization;

public abstract class SerializationFormatter
{
	public abstract string ToString(object object_0);

	public abstract object FromString(string string_0);
}
