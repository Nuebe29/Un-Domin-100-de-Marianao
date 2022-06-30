namespace Engine;


public class Player<T>
{   
<<<<<<< HEAD
    private estrategia estrategia;
    public Player(estrategia a){
        this.estrategia = a;
    }
    public int Juega(ITablero<T> estado, List<IFicha<T>> posiblesjugadas, Mano<T> hand)
    {
        return estrategia(estado, posiblesjugadas, hand);
    }
}
public class estrategiarandom<T>{
    public estrategiarandom(){

    }
    public int Juega(ITablero<T> estado, List<IFicha<T>> posiblesjugadas, Mano<T> hand){
        Random r = new Random();
        return r.Next(posiblesjugadas.Count);
    }
}
=======
    private Estrategia<T> estrategia;
    public Player(Estrategia<T> a){
        this.estrategia = a;
    }
    public int Juega(ITablero<T> tablero, List<Movimiento<T>> posiblesjugadas, Mano<T> hand)
    {
        return estrategia(tablero, posiblesjugadas, hand);
    }
}

>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
