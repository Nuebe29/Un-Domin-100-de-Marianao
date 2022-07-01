namespace Engine;

public class Movimiento<T>
{
    public Movimiento(IFicha<T> a, Nodo<T> b, bool esPase)
    {
        Ficha = a;
        Nodo  = b;
        EsPase = esPase;
    }
    
    public bool EsPase { get; }
    public IFicha<T> Ficha { get; }
    public Nodo<T> Nodo { get; }
}