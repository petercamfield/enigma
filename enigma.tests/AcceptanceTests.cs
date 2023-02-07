namespace enigma.tests;

public class AcceptanceTests
{

    //With the rotors I, II and III (from left to right),
    //wide B-reflector, all ring settings in A-position,
    //and start position AAA, typing AAAAA will produce the encoded sequence BDZGO

    private const int A = 'A';
    private const string Decoded = "AAAAA";
    private const string Encoded = "BDZGO";

    private char ToChar(int pin) => (char)(pin + A);

    private readonly IPlugboard _plugboard = Plugboard.Create("");
    private readonly IReflector _reflectorB = Reflector.Create("YRUHQSLDPXNGOKMIEBFZCWVJAT");

    private IRotor _rotor1 = null!;
    private IRotor _rotor2 = null!;
    private IRotor _rotor3 = null!;

    [SetUp]
    public void BeforeEveryTest()
    {
        _rotor1 = Rotor.Create("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'A');
        _rotor2 = Rotor.Create("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'A');
        _rotor3 = Rotor.Create("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'A');
    }

    [Test]
    public void Enigma_WithSimpleConfig_ReturnsEncodedString()
    {
        var result = Decoded.Select(TypeCharacter);
        Assert.That(result, Is.EqualTo(Encoded));
    }

    [Test]
    public void Enigma_WithSimpleConfig_ReturnsDecodedString()
    {
        var result = Encoded.Select(TypeCharacter);
        Assert.That(result, Is.EqualTo(Decoded));
    }

    private char TypeCharacter(char character)
    {
        _rotor3.Rotate();

        var step0 = _plugboard.Encode(character - A);
        var step1 = _rotor3.EncodeOutbound(step0);
        var step2 = _rotor2.EncodeOutbound(step1);
        var step3 = _rotor1.EncodeOutbound(step2);
        var step4 = _reflectorB.Encode(step3);
        var step5 = _rotor1.EncodeInbound(step4);
        var step6 = _rotor2.EncodeInbound(step5);
        var step7 = _rotor3.EncodeInbound(step6);
        var step8 = _plugboard.Encode(step7);

        return ToChar(step8);
    }

}