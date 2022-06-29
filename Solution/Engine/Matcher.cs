namespace Engine;

public interface IMatcher<T>{
    public bool matchea(IFicha<T> ficha, Nodo<T> nodo);
}
public class MatcherClasico : IMatcher<int>
{
    
    public bool matchea(IFicha<int> ficha, TableroClásico tablero){
        foreach(var nodo in tablero){
            if(matchea(ficha, tablero.Hoja))return true;
        }
        return false;
    }
    public bool matchea(IFicha<int> ficha, Nodo<int> nodo)
    {
        if(ficha.Cara1== nodo.Entrada|| ficha.Cara2== nodo.Entrada)return true;
        return false;
    }
}