namespace Engine;

public interface IMatcher<T>{
<<<<<<< HEAD
    public bool matchea(IFicha<T> ficha, ITablero<T> tablero);
=======
    public bool matchea(IFicha<T> ficha, Nodo<T> nodo);
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
}
public class MatcherClasico : IMatcher<int>
{
    
    public bool matchea(IFicha<int> ficha, TableroClásico tablero){
        foreach(var nodo in tablero){
            if(matchea(ficha, tablero.Hoja))return true;
        }
        return false;
    }
<<<<<<< HEAD
    public bool matchea(IFicha<int> ficha, ITablero<int> tablero)
    {
        if(ficha.cara1== nodo.Entrada|| ficha.cara2== nodo.Entrada)return true;
=======
    public bool matchea(IFicha<int> ficha, Nodo<int> nodo)
    {
        if(ficha.Cara1== nodo.Entrada|| ficha.Cara2== nodo.Entrada)return true;
>>>>>>> 0fbaf73d60127f9bca9bb720a32eddcf6a5a070a
        return false;
    }
}