namespace enigma;

public class Rotor : IRotor
{
    private readonly RotorMap _map;
    private const char A = 'A';

    private Rotor(RotorMap map, char position)
    {
        _map = map;
        CurrentPosition = position;
    }

    public static IRotor Create(string wiring, char position)
    {
        var map = new RotorMap(wiring);
        return new Rotor(map, position);
    }

    public char CurrentPosition { get; private set; }

    public void Rotate()
    {
        CurrentPosition++;
        if (Offset >= _map.Outbound.Length) CurrentPosition = A;
    }

    public int EncodeOutbound(int pinIn) => Encode(pinIn, input => _map.Outbound[input]);
    
    public int EncodeInbound(int pinIn) => Encode(pinIn, input => _map.Inbound[input]);

    private int Encode(int pinIn, Func<int, int> map)
    {
        var encodingPipeline = new []
        {
            AddOffset,
            KeepInBounds,
            map,
            RemoveOffset,
            KeepInBounds,
        };

        var pinOut = encodingPipeline.Aggregate(pinIn, (value, func) => func(value));
        return pinOut;
    }

    private int AddOffset(int input) => input + Offset;

    private int RemoveOffset(int input) => input - Offset;

    private int KeepInBounds(int input) =>
        input < 0
            ? (input % _map.Outbound.Length) + _map.Outbound.Length
            : input % _map.Outbound.Length;

    private int Offset => CurrentPosition - A;
}
