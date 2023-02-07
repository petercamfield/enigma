namespace enigma.tests;

public class ReflectorTests {
    [TestCase(0,24)]
    [TestCase(24,0)]
    [TestCase(25,19)]
    [TestCase(19,25)]
    public void Reflector_WhenPinIn_ReturnsPinOut(int pinIn, int pinOut)
  {
      var reflectorB = Reflector.Create("YRUHQSLDPXNGOKMIEBFZCWVJAT");
      var reflected = reflectorB.Encode(pinIn);
      Assert.That(reflected, Is.EqualTo(pinOut));
  }
}