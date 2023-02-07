namespace enigma;

public class RotorMap
{
    public RotorMap(string wiring)
    {
        Inbound = GetInboundMap(wiring);
        Outbound = GetOutboundMap(wiring);
    }

    private const int A = 'A';

    public int[] Outbound { get; }
    public int[] Inbound { get; }

    private static int[] GetInboundMap(string wiring)
    {
        return "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            .Take(wiring.Length)
            .Select(character => wiring.IndexOf(character))
            .ToArray();
    }

    private static int[] GetOutboundMap(string wiring)
    {
        return wiring
            .Select(character => character - A)
            .ToArray();
    }
}