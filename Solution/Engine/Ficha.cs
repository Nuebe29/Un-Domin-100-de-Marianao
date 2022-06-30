namespace Engine;

public interface IFicha<T>
{
<<<<<<< HEAD
    public T cara1 { get; }
    public T cara2 { get; }
    public int peso { get; }
=======
    public T Cara1 { get; }
    public T Cara2 { get; }
    public int Peso { get; }
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
}

public class FichaClásica : IFicha<int>
{

    public FichaClásica(int a, int b)
    {
<<<<<<< HEAD
        cara1 = a;
        cara2 = b;
    }

    public int cara1 { get; }

    public int cara2 { get; }



    public int peso => cara1 + cara2;

    public override string ToString()
    {
        return $"[{cara1},{cara2}]";
=======
        Cara1 = a;
        Cara2 = b;
    }

    public int Cara1 { get; }

    public int Cara2 { get; }



    public int Peso => Cara1 + Cara2;

    public override string ToString()
    {
        return $"[{Cara1},{Cara2}]";
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
    }
}