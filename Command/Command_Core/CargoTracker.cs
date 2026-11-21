namespace Command_Core;

public sealed class CargoTracker
{
	public Cargo _cargo;

	public int _loaded;

	public int _unloaded;

	public CargoTracker(Cargo cargo_0, int int_0, int int_1)
	{
		_cargo = cargo_0;
		_loaded = int_0;
		_unloaded = int_1;
	}
}
