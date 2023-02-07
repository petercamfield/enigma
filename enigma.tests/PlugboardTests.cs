namespace enigma.tests;

public class PlugboardTests
{
    private const string Wiring = "AB CD EF";
    private const int A = 'A';

    [TestCase('G')]
    [TestCase('Z')]
    public void Plugboard_WhenLetterIsUnplugged_PassesThrough(int input)
    {
        var plugboard = Plugboard.Create(Wiring);
        var result = plugboard.Encode(input - A);
        Assert.That(result, Is.EqualTo(input - A));
    }

    [TestCase('A', 'B')]
    [TestCase('C', 'D')]
    [TestCase('E', 'F')]
    [TestCase('B', 'A')]
    [TestCase('D', 'C')]
    [TestCase('F', 'E')]
    public void Plugboard_WhenLetterIsPlugged_SwapsLetter(int input, int output)
    {
        var plugboard = Plugboard.Create(Wiring);
        var result = plugboard.Encode(input - A);
        Assert.That(result, Is.EqualTo(output - A));
    }

    [TestCase('A')]
    [TestCase('Z')]
    public void Plugboard_WhenAllLettersAreUnplugged_PassesThrough(int input)
    {
        var plugboard = Plugboard.Create("");
        var result = plugboard.Encode(input - A);
        Assert.That(result, Is.EqualTo(input - A));
    }
}