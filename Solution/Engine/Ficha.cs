namespace Engine;

public interface IFicha<T>
{
    public T Cara1 { get; }
    public T Cara2 { get; }
    public int Peso { get; }
}

public class FichaClásica : IFicha<int>
{

    public FichaClásica(int a, int b)
    {
        Cara1 = a;
        Cara2 = b;
    }

    public int Cara1 { get; }

    public int Cara2 { get; }



    public int Peso => Cara1 + Cara2;

    public override string ToString()
    {
        return $"[{Cara1},{Cara2}]";
    }
}