namespace enigma.tests;

public class RotorTests
{
    const string TestWiring = "BDECA";

    public class Rotation
    {
        [Test]
        public void Rotor_WhenRotated_ReportsNewPosition()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            rotor.Rotate();
            Assert.That(rotor.CurrentPosition, Is.EqualTo('B'));
        }

        [Test]
        public void Rotor_WhenRotatedAtEnd_ReportsPositionAtStart()
        {
            var rotor = Rotor.Create(TestWiring, 'E');
            rotor.Rotate();
            Assert.That(rotor.CurrentPosition, Is.EqualTo('A'));
        }
    }

    public class OutboundEncoding
    {
        [Test]
        public void Rotor_WhenAtPositionA_EncodesOutboundPin0ToPin1()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            var encoded = rotor.EncodeOutbound(0);
            Assert.That(encoded, Is.EqualTo(1));
        }

        [Test]
        public void Rotor_WhenAtPositionA_EncodesOutboundPin1ToPin3()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            var translated = rotor.EncodeOutbound(1);
            Assert.That(translated, Is.EqualTo(3));
        }

        [Test]
        public void Rotor_WhenAtPositionA_EncodesOutboundPin3toPin2()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            var translated = rotor.EncodeOutbound(3);
            Assert.That(translated, Is.EqualTo(2));
        }

        [Test]
        public void Rotor_WhenAtPositionB_EncodesOutboundPin0ToPin2()
        {
            var rotor = Rotor.Create(TestWiring, 'B');
            var translated = rotor.EncodeOutbound(0);
            Assert.That(translated, Is.EqualTo(2));
        }

        [Test]
        public void Rotor_WhenAtPositionE_EncodesOutboundPin0toPin1()
        {
            var rotor = Rotor.Create(TestWiring, 'E');
            var translated = rotor.EncodeOutbound(0);
            Assert.That(translated, Is.EqualTo(1));
        }
    }

    public class InboundEncoding
    {
        [Test]
        public void Rotor_WhenAtPositionA_EncodesInboundPin0toPin4()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            var translated = rotor.EncodeInbound(0);
            Assert.That(translated, Is.EqualTo(4));
        }

        [Test]
        public void Rotor_WhenAtPositionB_EncodesInboundPin0toPin4()
        {
            var rotor = Rotor.Create(TestWiring, 'B');
            var translated = rotor.EncodeInbound(0);
            Assert.That(translated, Is.EqualTo(4));
        }

        [Test]
        public void Rotor_WhenAtPositionC_EncodesInboundPin0toPin1()
        {
            var rotor = Rotor.Create(TestWiring, 'C');
            var translated = rotor.EncodeInbound(0);
            Assert.That(translated, Is.EqualTo(1));
        }

        [Test]
        public void Rotor_WhenAtPositionD_EncodesInboundPin0toPin3()
        {
            var rotor = Rotor.Create(TestWiring, 'D');
            var translated = rotor.EncodeInbound(0);
            Assert.That(translated, Is.EqualTo(3));
        }

        [Test]
        public void Rotor_WhenAtPositionE_EncodesInboundPin0toPin3()
        {
            var rotor = Rotor.Create(TestWiring, 'E');
            var translated = rotor.EncodeInbound(0);
            Assert.That(translated, Is.EqualTo(3));
        }

        [Test]
        public void Rotor_WhenAtPositionA_EncodesInboundPin1toPin0()
        {
            var rotor = Rotor.Create(TestWiring, 'A');
            var translated = rotor.EncodeInbound(1);
            Assert.That(translated, Is.EqualTo(0));
        }
    }
}