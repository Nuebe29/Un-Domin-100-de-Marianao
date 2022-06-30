namespace Engine;

public interface IMatcher<T>{
    public bool matchea(IFicha<T> ficha, ITablero<T> tablero);
}
public class MatcherClasico : IMatcher<int>
{
    
    public bool matchea(IFicha<int> ficha, TableroClásico tablero){
        foreach(var nodo in tablero){
            if(matchea(ficha, tablero.Hoja))return true;
        }
        return false;
    }
    public bool matchea(IFicha<int> ficha, ITablero<int> tablero)
    {
        if(ficha.cara1== nodo.Entrada|| ficha.cara2== nodo.Entrada)return true;
        return false;
    }
}