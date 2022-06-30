namespace Engine;


public class Player<T>
{   
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
