namespace enigma;

public class Plugboard : IPlugboard
{
    private readonly IDictionary<int, int> _plugs;

    private const int A = 'A';

    private Plugboard(IDictionary<int, int> plugs)
    {
        _plugs = plugs;
    }

    public static IPlugboard Create(string wiring)
    {
        var pairs = wiring.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var plugs = pairs.ToDictionary(pair => pair[0] - A, pair => pair[1] - A)
            .Union(pairs.ToDictionary(pair => pair[1] - A, pair => pair[0] - A))
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        return new Plugboard(plugs);
    }

    public int Encode(int pinIn)
    {
        return _plugs.ContainsKey(pinIn) ? _plugs[pinIn] : pinIn;
    }
}