namespace enigma;

public interface IPlugboard
{
    int Encode (int input);
}

public interface IRotor
{
    char CurrentPosition {get;}
    void Rotate();
    int EncodeOutbound(int pinIn);
    int EncodeInbound(int pinIn);
}

public interface IReflector
{
    int Encode(int pinIn);
}



