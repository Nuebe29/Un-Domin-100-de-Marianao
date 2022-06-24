namespace Engine;

public interface IFicha<T>
{
    public T cara1 { get; }
    public T cara2 { get; }
    public int peso { get; }
}

public class FichaClásica : IFicha<int>
{

    public FichaClásica(int a, int b)
    {
        cara1 = a;
        cara2 = b;
    }

    public int cara1 { get; }

    public int cara2 { get; }



    public int peso => cara1 + cara2;

    public override string ToString()
    {
        return $"[{cara1},{cara2}]";
    }
}