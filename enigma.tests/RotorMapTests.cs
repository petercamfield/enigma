namespace enigma.tests;

public class RotorMapTests
{
    const string Wiring = "JGDQOXUSCAMIFRVTPNEWKBLZYH"; // Rotor I - 7 February 1941 - German Railway (Rocket)
    private readonly RotorMap _map = new RotorMap(Wiring);

    [TestCase(0, 9)]
    [TestCase(1, 6)]
    [TestCase(8, 2)]
    [TestCase(9, 0)]
    public void OutboundRotorMap_WhenPinIn_ReturnsPinOut(int pinIn, int pinOut)
    {
        Assert.That(_map.Outbound[pinIn], Is.EqualTo(pinOut));
    }

    [TestCase(0, 9)]
    [TestCase(1, 21)]
    [TestCase(9, 0)]
    [TestCase(3, 2)]
    public void InboundRotorMap_WhenPinIn_ReturnsPinOut(int pinIn, int pinOut)
    {
        Assert.That(_map.Inbound[pinIn], Is.EqualTo(pinOut));
    }
}