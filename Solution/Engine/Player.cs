namespace Engine;


public class Player<T>
{   
    private estrategia estrategia;
    public Player(estrategia a){
        this.estrategia = a;
    }
    public int Juega(infopartida estado, List<jugadas> posiblesjugadas, Mano<IFicha<T>> hand)
    {
        return estrategia(estado, posiblesjugadas, hand);
    }
}
public class estrategiarandom<T>{
    public estrategiarandom(){

    }
    public int Juega(infopartida estado, List<jugadas> posiblesjugadas, Mano<IFicha<T>> hand){
        Random r = new Random();
        return r.Next(posiblesjugadas.Count);
    }
}
