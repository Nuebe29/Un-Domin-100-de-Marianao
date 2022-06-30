namespace Engine;

public class Movimiento<T>
{
    public Movimiento(T a, T b)
    {
        Entrada = a;
        Salida  = b;
    }
    
    public bool EsPase { get; }
    public T Entrada { get; }
    public T Salida { get; }
}