namespace Engine;


public class Player<T>
{   
    private Estrategia<T> estrategia;
    public Player(Estrategia<T> a){
        this.estrategia = a;
    }
    public int Juega(ITablero<T> tablero, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {
        return estrategia(tablero, posiblesjugadas, hand);
    }
}

