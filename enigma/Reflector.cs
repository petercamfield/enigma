namespace enigma;

public class Reflector: IReflector {
    private readonly int[] _map;

    private Reflector(int[] map)
    {
        _map = map;
    }

    public static IReflector Create(string wiring)
    {
        var map = new RotorMap(wiring).Outbound;
        return new Reflector(map);
    }

    public int Encode(int pinIn)
    {
        return _map[pinIn];
    }
}