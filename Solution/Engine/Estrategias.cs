namespace Engine;

public delegate int Estrategia<T>(ITablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand);
public static class Estrategias<T>
{
    public static int Estrategiarandom(ITablero<T> estado, List<Movimiento<T>> posiblesjugadas, Mano<T> hand){
        Random r = new Random();
        return r.Next(posiblesjugadas.Count);
    }
    
}